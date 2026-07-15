using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOI.CliFrx;
using SOI.DNM;
using SOI.OIFrx;
using BOI.OIFrx;
using Miracom.TRSCore;

namespace SOI.Solar
{
    public partial class frmCUSTranDefectRegister : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranDefectRegister()
        {
            InitializeComponent();
        }

        public enum ORD
        {
            ORDER_DATE,
            ORDER_ID,
            ORDER_TYPE,
            SHELF_LIFE,
            MAT_ID,
            MAT_DESC,
            STATUS,
            ORDER_QTY,
            ORDER_QTY_1,
            RLT_QTY,
            UNIT,
            LINE_ID,
            RES_ID,
            BOM_TYPE,
            BOX_QTY
        }

        public enum SOLDER
        {
            LOCATION,
            POSIOTION,
            LOSS_CODE,
            LOSS_CODE_BTN,
            LOSS_CODE_DESC,
            STRING_ID
        }

        public enum CELL
        {
            LOCATION,
            POSIOTION,
            LOSS_CODE,
            LOSS_CODE_BTN,
            LOSS_CODE_DESC,
            STRING_ID,
            CELL_SEQ
        }

        private bool bIsShown = false;
        private int i_string_row_cnt = 0;
        private int i_cell_col_cnt = 0;

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "PROCESS":

                        if (string.IsNullOrEmpty(txtLotID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                            MPCF.SetFocus(txtLotID);
                            return false;
                        }

                        break;

                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.ClearList(spdCellDefect);
                    MPCF.ClearList(spdSolderingDefect);
                    MPCF.ClearList(spdModule);
                    spdModule.ActiveSheet.RowCount = 6;
                    spdModule_Sheet1.RowHeader.Cells.Get(0, 0).Value = "A";
                    spdModule_Sheet1.RowHeader.Cells.Get(1, 0).Value = "B";
                    spdModule_Sheet1.RowHeader.Cells.Get(2, 0).Value = "C";
                    spdModule_Sheet1.RowHeader.Cells.Get(3, 0).Value = "D";
                    spdModule_Sheet1.RowHeader.Cells.Get(4, 0).Value = "E";
                    spdModule_Sheet1.RowHeader.Cells.Get(5, 0).Value = "F";
                    spdModule_Sheet1.Columns[1].BackColor = System.Drawing.Color.PowderBlue;
                    spdModule_Sheet1.Columns[14].BackColor = System.Drawing.Color.PowderBlue;
                }
                else if (ProcStep == "2")
                {

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Defect_Register(string sLotID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode list_item = null;
            string s_old_string_id = string.Empty;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(sLotID));

                for (int k = 0; k < spdSolderingDefect.ActiveSheet.RowCount; k++)
                {
                    list_item = in_node.AddNode("DATA_LIST");
                    list_item.AddString("STRING_ID", MPCF.Trim(spdSolderingDefect.ActiveSheet.Cells[k, 5].Text));
                    list_item.AddString("LOCATION", MPCF.Trim(spdSolderingDefect.ActiveSheet.Cells[k, 0].Text));
                    list_item.AddString("POSITION", MPCF.Trim(spdSolderingDefect.ActiveSheet.Cells[k, 1].Text));
                    list_item.AddString("LOSS_CODE", MPCF.Trim(spdSolderingDefect.ActiveSheet.Cells[k, 2].Text));
                    list_item.AddString("TYPE", "SOLDERING");

                    if(string.IsNullOrEmpty(spdSolderingDefect.ActiveSheet.Cells[k, 2].Text) == true)
                    {
                        MPCF.ShowMsgBox("불량 코드를 입력해주세요.");
                        return false;
                    }
                }

                for (int k = 0; k < spdCellDefect.ActiveSheet.RowCount; k++)
                {
                    list_item = in_node.AddNode("DATA_LIST");
                    list_item.AddString("STRING_ID", MPCF.Trim(spdCellDefect.ActiveSheet.Cells[k, 4].Text));
                    list_item.AddString("CELL_SEQ", MPCF.Trim(spdCellDefect.ActiveSheet.Cells[k, 5].Text));
                    list_item.AddString("POSITION", MPCF.Trim(spdCellDefect.ActiveSheet.Cells[k, 0].Text));
                    list_item.AddString("LOSS_CODE", MPCF.Trim(spdCellDefect.ActiveSheet.Cells[k, 1].Text));
                    list_item.AddString("TYPE", "CELL");

                    s_old_string_id = spdCellDefect.ActiveSheet.Cells[k, 4].Text;

                    if (string.IsNullOrEmpty(spdCellDefect.ActiveSheet.Cells[k, 1].Text) == true)
                    {
                        MPCF.ShowMsgBox("불량 코드를 입력해주세요.");
                        return false;
                    }
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_Defect_Register", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool Get_Lot_ID(ref string strLot)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$INPUT";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_OR_JIG", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                if (dt.Rows.Count > 0)
                {
                    strLot = dt.Rows[0]["LOT_ID"].ToString();
                    return true;
                }
                else
                    return false;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 작업지시 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Lot_Info(string strLot)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = strLot;

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_STRING_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(122));
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                i_cell_col_cnt = MPCF.ToInt(dt.Rows[0]["MAT_CMF_11"].ToString());
                i_string_row_cnt = MPCF.ToInt(dt.Rows[0]["MAT_CMF_12"].ToString());

                spdModule.ActiveSheet.RowCount = i_string_row_cnt;
                spdModule.ActiveSheet.Columns.Count = 2;

                char c_alphabet = 'A';

                for (int q = 0; q < i_string_row_cnt; q++)
                {
                    spdModule.ActiveSheet.RowHeader.Cells[q, 0].Text = ((char)(int)(c_alphabet)).ToString();
                    c_alphabet++;
                }

                for (int k = 0; k < i_cell_col_cnt + 1; k++)
                {
                    spdModule.ActiveSheet.Columns.Count++;

                    if (k == i_cell_col_cnt)
                    {
                        spdModule.ActiveSheet.ColumnHeader.Cells[0, i_cell_col_cnt + 2].Text = "Soldering 하단";
                        spdModule_Sheet1.Columns.Get(i_cell_col_cnt + 2).Width = 85F;
                        spdModule_Sheet1.Columns[i_cell_col_cnt + 2].BackColor = System.Drawing.Color.PowderBlue;
                        spdModule.ActiveSheet.Columns[i_cell_col_cnt + 2].Locked = true;
                        spdModule_Sheet1.Columns[i_cell_col_cnt + 2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdModule_Sheet1.Columns[i_cell_col_cnt + 2].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    }
                    else
                    {
                        spdModule.ActiveSheet.ColumnHeader.Cells[0, k + 2].Text = (k + 1).ToString();
                        spdModule.ActiveSheet.Columns[k + 2].Locked = true;
                        spdModule_Sheet1.Columns[k + 2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdModule_Sheet1.Columns[k + 2].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    }
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdModule.ActiveSheet.Cells[i, 1].Text = "";
                    spdModule.ActiveSheet.Cells[i, 1].BackColor = System.Drawing.Color.PowderBlue;

                    for (int k = 0; k < spdModule.ActiveSheet.RowHeader.Rows.Count; k++)
                    {
                        if (spdModule.ActiveSheet.RowHeader.Rows[k].Label == dt.Rows[i]["STRING_LINE"].ToString())
                        {
                            spdModule.ActiveSheet.Cells[k, 0].Value = dt.Rows[i]["STRING_ID"].ToString();
                            break;
                        }
                    }
                }

				spdModule.ActiveSheet.Columns[0].Width = 100f;	//스트링 아이디
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string strLot = string.Empty;

            if (!Get_Lot_ID(ref strLot))
            {
                txtLotID.Tag = null;
                MPCF.ShowMsgBox(MPCF.GetMessage(217));
                return;
            }

            txtLotID.Tag = strLot; // JIG or LOT 입력시 결과적으로 LOT ID만 사용한다.

            if (View_Lot_Info(strLot) == true)
            {
                View_Loss_Info(strLot);
            }
        }

        /// <summary>
        /// LOSS 정보 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Loss_Info(string strLot)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            int i_col_seq = 0;

            try
            {
                MPCF.ClearList(spdSolderingDefect);
                MPCF.ClearList(spdCellDefect);

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = strLot;

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_STRING_CELL_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    i_col_seq = MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString());

                    for (int k = 0; k < spdModule.ActiveSheet.Rows.Count; k++)
                    {
                        if (spdModule.ActiveSheet.Cells[k, 0].Text == MPCF.Trim(dt.Rows[i]["STRING_ID"].ToString()))
                        {
                            if (dt.Rows[i]["LOSS_TYPE"].ToString() == "CELL" && MPCF.Trim(dt.Rows[i]["LOSS_CODE"].ToString()) != "")
                            {
                                spdModule.ActiveSheet.Cells[k, i_col_seq + 1].Text = "√";
                                spdModule.ActiveSheet.Cells[k, i_col_seq + 1].BackColor = Color.Red;

                                spdCellDefect.ActiveSheet.RowCount++;
                                spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 0].Text = dt.Rows[i]["POSITION"].ToString();
                                spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 1].Text = dt.Rows[i]["LOSS_CODE"].ToString();
                                spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 3].Text = dt.Rows[i]["LOSS_CODE_DESC"].ToString();
                                spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 4].Text = dt.Rows[i]["STRING_ID"].ToString();
                                spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 5].Text = dt.Rows[i]["CELL_SEQ"].ToString();
                            }
                        }
                        if (spdModule.ActiveSheet.Rows[k].Label == MPCF.Trim(dt.Rows[i]["POSITION"].ToString()))
                        {
                            if (dt.Rows[i]["LOSS_TYPE"].ToString() == "SOLDERING")
                            {
                                if (dt.Rows[i]["LOCATION"].ToString() == "상단")
                                {
                                    spdModule.ActiveSheet.Cells[k, 1].Text = "√";
                                    spdModule.ActiveSheet.Cells[k, 1].BackColor = Color.Red;
                                }
                                else if (dt.Rows[i]["LOCATION"].ToString() == "하단")
                                {
                                    spdModule.ActiveSheet.Cells[k, spdModule.ActiveSheet.Columns.Count - 1].Text = "√";
                                    spdModule.ActiveSheet.Cells[k, spdModule.ActiveSheet.Columns.Count - 1].BackColor = Color.Red;
                                }

                                spdSolderingDefect.ActiveSheet.RowCount++;
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.LOCATION].Text = dt.Rows[i]["LOCATION"].ToString();
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.POSIOTION].Text = dt.Rows[i]["POSITION"].ToString();
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.LOSS_CODE].Text = dt.Rows[i]["LOSS_CODE"].ToString();
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.LOSS_CODE_DESC].Text = dt.Rows[i]["LOSS_CODE_DESC"].ToString();
                            }

                            break;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void frmCUSTranDefectRegister_Load(object sender, EventArgs e)
        {
            MPCF.ClearList(spdCellDefect);
            MPCF.ClearList(spdSolderingDefect);
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                btnView.PerformClick();
            }
        }

        private void frmCUSTranDefectRegister_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtLotID);
            }
        }

        private void spdOrderInfo_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                //string s_row_header;
                //string s_column_header;

                //if (e.Column == 0) return;

                //if (string.IsNullOrEmpty(txtLotID.Text) == true)
                //{
                //    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                //    MPCF.SetFocus(txtLotID);
                //    return;
                //}

                //s_column_header = spdModule.ActiveSheet.ColumnHeader.Columns[e.Column].Label;
                //s_row_header = spdModule.ActiveSheet.RowHeader.Rows[e.Row].Label + s_column_header;

                //if(spdModule.ActiveSheet.Cells[e.Row, e.Column].Text == "√")
                //{
                //    spdModule.ActiveSheet.Cells[e.Row, e.Column].Text = "";
                //    if (e.Column == 1 || e.Column == spdModule.ActiveSheet.Columns.Count - 1)
                //    {
                //        spdModule.ActiveSheet.Cells[e.Row, e.Column].BackColor = Color.PowderBlue;

                //        for(int k =0; k < spdSolderingDefect.ActiveSheet.RowCount; k++)
                //        {
                //            if (spdSolderingDefect.ActiveSheet.Cells[k, 1].Text == s_row_header.Substring(0,1)
                //                 && spdSolderingDefect.ActiveSheet.Cells[k,0].Text == s_column_header.Substring(s_column_header.Length -2, 2))
                //            {
                //                spdSolderingDefect.Sheets[0].Rows[k].Remove();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        spdModule.ActiveSheet.Cells[e.Row, e.Column].BackColor = Color.WhiteSmoke;

                //        for (int k = 0; k < spdCellDefect.ActiveSheet.RowCount; k++)
                //        {
                //            if(spdCellDefect.ActiveSheet.Cells[k, 0].Text == s_row_header)
                //            { 
                //                spdCellDefect.Sheets[0].Rows[k].Remove();
                //            }
                //        }
                //    }

                //    return;
                //}

                //spdModule.ActiveSheet.Cells[e.Row, e.Column].BackColor = Color.Red;
                //spdModule.ActiveSheet.Cells[e.Row, e.Column].Text = "√";

                //if (e.Column == 0)
                //{
                //    return;
                //}
                //else if (e.Column == 1 || e.Column == spdModule.ActiveSheet.Columns.Count -1)
                //{
                //    spdSolderingDefect.ActiveSheet.RowCount++;
                //    spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, 0].Text = s_column_header.Substring(s_column_header.Length -2, 2);
                //    spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, 1].Text = s_row_header.Substring(0,1);
                //    spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, 3].Text = "...";
                //    //STRING ID 저장
                //    spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, 5].Text = spdModule.ActiveSheet.Cells[e.Row, 0].Text;
                //}
                //else
                //{
                //    spdCellDefect.ActiveSheet.RowCount++;
                //    spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 0].Text = s_row_header;
                //    //STRING ID 저장
                //    spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 4].Text = spdModule.ActiveSheet.Cells[e.Row, 0].Text;
                //    //CELL SEQ 저장
                //    spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 5].Text = s_column_header;
                //}
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData("1");            
        }

        private void spdSolderingDefect_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == 3)
                {
                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                    dvcArgu[0].sCondtion_ID = "$FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;


                    dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                    dvcArgu[1].sCondition_Value = "C@LOSS_REQUEST";

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1", "DATA_1" };
                    
                    // Show
                    cdvDefectSoldering.Text = cdvDefectSoldering.Show(cdvDefectSoldering, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                    if (MPCF.Trim(cdvDefectSoldering.Text) != "")
                    {
                        if (cdvDefectSoldering.returnDatas != null && cdvDefectSoldering.returnDatas.Count > 0)
                        {
                            spdSolderingDefect.ActiveSheet.Cells[e.Row, 2].Tag = cdvDefectSoldering.returnDatas[0];
                            spdSolderingDefect.ActiveSheet.Cells[e.Row, 2].Text = cdvDefectSoldering.returnDatas[0];
                            spdSolderingDefect.ActiveSheet.Cells[e.Row, 4].Text = cdvDefectSoldering.returnDatas[1];
                            spdSolderingDefect.ActiveSheet.Rows[e.Row].BackColor = Color.Salmon;
                        }
                        else
                        {
                            spdSolderingDefect.ActiveSheet.Cells[e.Row, 2].Tag = "";
                            spdSolderingDefect.ActiveSheet.Cells[e.Row, 2].Text = "";
                            spdSolderingDefect.ActiveSheet.Cells[e.Row, 4].Text = "";
                        }
                    }
                    else
                    {
                        spdSolderingDefect.ActiveSheet.Cells[e.Row, 2].Tag = "";
                        spdSolderingDefect.ActiveSheet.Cells[e.Row, 2].Text = "";
                        spdSolderingDefect.ActiveSheet.Cells[e.Row, 4].Text = "";
                    }

                    //spdSolderingDefect.ActiveSheet.Columns[4].Width = 100F;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdCellDefect_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == 2)
                {
                    TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                    dvcArgu[0].sCondtion_ID = "$FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                    dvcArgu[1].sCondition_Value = "C@LOSS_REQUEST";

                    // CodeView Column Header Setup
                    string[] header = new string[] { "Code", "Code Desc" };

                    // CodeView Display Column Setup
                    string[] display = new string[] { "KEY_1", "DATA_1" };

                    // Show
                    cdvDefectCell.Text = cdvDefectCell.Show(cdvDefectCell, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                    if (MPCF.Trim(cdvDefectCell.Text) != "")
                    {
                        if (cdvDefectCell.returnDatas != null && cdvDefectCell.returnDatas.Count > 0)
                        {
                            spdCellDefect.ActiveSheet.Cells[e.Row, 1].Tag = cdvDefectCell.returnDatas[0];
                            spdCellDefect.ActiveSheet.Cells[e.Row, 1].Text = cdvDefectCell.returnDatas[0];
                            spdCellDefect.ActiveSheet.Cells[e.Row, 3].Text = cdvDefectCell.returnDatas[1];
                            spdCellDefect.ActiveSheet.Rows[e.Row].BackColor = Color.Salmon;
                        }
                        else
                        {
                            spdCellDefect.ActiveSheet.Cells[e.Row, 1].Tag = "";
                            spdCellDefect.ActiveSheet.Cells[e.Row, 1].Text = "";
                            spdCellDefect.ActiveSheet.Cells[e.Row, 3].Text = "";
                        }
                    }
                    else
                    {
                        spdCellDefect.ActiveSheet.Cells[e.Row, 1].Tag = "";
                        spdCellDefect.ActiveSheet.Cells[e.Row, 1].Text = "";
                        spdCellDefect.ActiveSheet.Cells[e.Row, 3].Text = "";
                        spdCellDefect.ActiveSheet.Rows[e.Row].BackColor = Color.WhiteSmoke;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            MPCF.ShowMessageClear();

            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Defect_Register(MPCF.Trim(txtLotID.Tag.ToString())) == true)
            {
                btnView.PerformClick();
            }
        }

		private void btnTranModuleMaterialDefect_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtLotID.Text) == false)
				{
					MPGV.gsCurrentLot_ID = txtLotID.Text;
				}

				//모듈내 자재 불량 의뢰
				BICF.OpenMenu("SOI2022");
			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
			} 	
		}

		private void btnTranModuleManage_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtLotID.Text) == false)
				{
					MPGV.gsCurrentLot_ID = txtLotID.Text;
				}

				//모듈내 String, Soldering 관리
				BICF.OpenMenu("SOI2017");
			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
			} 	
		}

        private void spdModule_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                string s_row_header;
                string s_column_header;

                if (e.Column == 0) return;

                if (string.IsNullOrEmpty(txtLotID.Text) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                    MPCF.SetFocus(txtLotID);
                    return;
                }

                s_column_header = spdModule.ActiveSheet.ColumnHeader.Columns[e.Column].Label;
                s_row_header = spdModule.ActiveSheet.RowHeader.Rows[e.Row].Label + s_column_header;

                if (spdModule.ActiveSheet.Cells[e.Row, e.Column].Text == "√")
                {
                    spdModule.ActiveSheet.Cells[e.Row, e.Column].Text = "";
                    if (e.Column == 1 || e.Column == spdModule.ActiveSheet.Columns.Count - 1)
                    {
                        spdModule.ActiveSheet.Cells[e.Row, e.Column].BackColor = Color.PowderBlue;

                        for (int k = 0; k < spdSolderingDefect.ActiveSheet.RowCount; k++)
                        {
                            if (spdSolderingDefect.ActiveSheet.Cells[k, 1].Text == s_row_header.Substring(0, 1)
                                 && spdSolderingDefect.ActiveSheet.Cells[k, 0].Text == s_column_header.Substring(s_column_header.Length - 2, 2))
                            {
                                spdSolderingDefect.Sheets[0].Rows[k].Remove();
                            }
                        }
                    }
                    else
                    {
                        spdModule.ActiveSheet.Cells[e.Row, e.Column].BackColor = Color.WhiteSmoke;

                        for (int k = 0; k < spdCellDefect.ActiveSheet.RowCount; k++)
                        {
                            if (spdCellDefect.ActiveSheet.Cells[k, 0].Text == s_row_header)
                            {
                                spdCellDefect.Sheets[0].Rows[k].Remove();
                            }
                        }
                    }

                    return;
                }

                spdModule.ActiveSheet.Cells[e.Row, e.Column].BackColor = Color.Red;
                spdModule.ActiveSheet.Cells[e.Row, e.Column].Text = "√";

                if (e.Column == 0)
                {
                    return;
                }
                else if (e.Column == 1 || e.Column == spdModule.ActiveSheet.Columns.Count - 1)
                {
                    spdSolderingDefect.ActiveSheet.RowCount++;
                    spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, 0].Text = s_column_header.Substring(s_column_header.Length - 2, 2);
                    spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, 1].Text = s_row_header.Substring(0, 1);
                    spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, 3].Text = "...";
                    //STRING ID 저장
                    spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, 5].Text = spdModule.ActiveSheet.Cells[e.Row, 0].Text;
                }
                else
                {
                    spdCellDefect.ActiveSheet.RowCount++;
                    spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 0].Text = s_row_header;
                    //STRING ID 저장
                    spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 4].Text = spdModule.ActiveSheet.Cells[e.Row, 0].Text;
                    //CELL SEQ 저장
                    spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, 5].Text = s_column_header;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }     
        }
    }
}
