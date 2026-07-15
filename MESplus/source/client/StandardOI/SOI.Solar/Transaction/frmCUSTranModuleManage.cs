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
    public partial class frmCUSTranModuleManage : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion

        public frmCUSTranModuleManage()
        {
            InitializeComponent();
        }

        public enum TRAY
        {
            STRING,
            CELL_1,
            CELL_2,
            CELL_3,
            CELL_4,
            CELL_5,
            CELL_6,
            CELL_7,
            CELL_8,
            CELL_9,
            CELL_10,
            CELL_11,
            CELL_12,
			MAT_ID
        }

        public enum SOLDER
        {
            LOCATION,
            POSIOTION,
            LOSS_CODE,
            LOSS_CODE_BTN,
            LOSS_CODE_DESC,
            RESULT_CODE,
            RESULT_CODE_DESC
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

                        if (string.IsNullOrEmpty(txtPosition.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Position]"));
                            MPCF.SetFocus(txtPosition);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvLossCode.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Loss Code]"));
                            MPCF.SetFocus(cdvLossCode);
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
                    MPCF.ClearList(spdOkTray);
                    MPCF.ClearList(spdNgTray);
                    MPCF.ClearList(spdSolderingDefect);
                    MPCF.ClearList(spdModuleInfo);
                    spdModuleInfo.ActiveSheet.RowCount = 6;
                    spdModuleInfo_Sheet1.RowHeader.Cells.Get(0, 0).Value = "A";
                    spdModuleInfo_Sheet1.RowHeader.Cells.Get(1, 0).Value = "B";
                    spdModuleInfo_Sheet1.RowHeader.Cells.Get(2, 0).Value = "C";
                    spdModuleInfo_Sheet1.RowHeader.Cells.Get(3, 0).Value = "D";
                    spdModuleInfo_Sheet1.RowHeader.Cells.Get(4, 0).Value = "E";
                    spdModuleInfo_Sheet1.RowHeader.Cells.Get(5, 0).Value = "F";
                    spdModuleInfo_Sheet1.Columns[1].BackColor = System.Drawing.Color.PowderBlue;
                    spdModuleInfo_Sheet1.Columns[14].BackColor = System.Drawing.Color.PowderBlue;
                }
                else if (ProcStep == "2")
                {
                    MPCF.ClearList(spdSolderingDefect);
                    MPCF.ClearList(spdModuleInfo);
                    txtGubun.Text = "";
                    txtPosition.Text = "";

                    if (i_string_row_cnt < 0)
                    {
                        spdModuleInfo.ActiveSheet.RowCount = 6;
                        spdModuleInfo_Sheet1.RowHeader.Cells.Get(0, 0).Value = "A";
                        spdModuleInfo_Sheet1.RowHeader.Cells.Get(1, 0).Value = "B";
                        spdModuleInfo_Sheet1.RowHeader.Cells.Get(2, 0).Value = "C";
                        spdModuleInfo_Sheet1.RowHeader.Cells.Get(3, 0).Value = "D";
                        spdModuleInfo_Sheet1.RowHeader.Cells.Get(4, 0).Value = "E";
                        spdModuleInfo_Sheet1.RowHeader.Cells.Get(5, 0).Value = "F";
                        spdModuleInfo_Sheet1.Columns[1].BackColor = System.Drawing.Color.PowderBlue;
                        spdModuleInfo_Sheet1.Columns[14].BackColor = System.Drawing.Color.PowderBlue;
                    }
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
        private bool Tran_String_Change(char cStep, string sTray_type, string sTray_ID)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                if (string.IsNullOrEmpty(sTray_ID) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                    if (sTray_type == "OK")
                        MPCF.SetFocus(txtOkTray);
                    else
                        MPCF.SetFocus(txtNGTray);
                    return false;
                }

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cStep;
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("TRAY_TYPE", MPCF.Trim(sTray_type));
                in_node.AddString("TRAY_ID", MPCF.Trim(sTray_ID));

                //모듈에서 제거
                if(cStep == '1')
                {
                    in_node.AddString("STRING_ID", MPCF.Trim(spdModuleInfo.ActiveSheet.Cells[spdModuleInfo.ActiveSheet.ActiveRowIndex, 0].Text));                    
                }
                else if (cStep == '2')
                {
                    in_node.AddString("STRING_LINE", MPCF.Trim(spdModuleInfo.ActiveSheet.RowHeader.Cells[spdModuleInfo.ActiveSheet.ActiveRowIndex, 0].Text));

                    if(string.IsNullOrEmpty(spdModuleInfo.ActiveSheet.Cells[spdModuleInfo.ActiveSheet.ActiveRowIndex, 0].Text) == false)
                    {
                        MPCF.ShowErrorMessage("모듈내 비어있는 LINE을 선택해 주세요.");
                        return false;
                    }

                    //트레이의 마지막 STRING 제거
                    if(sTray_type == "OK")
                    {
                        in_node.AddString("STRING_ID", MPCF.Trim(spdOkTray.ActiveSheet.Cells[0, 0].Text));                    
                    }
                    else
                    {
                        in_node.AddString("STRING_ID", MPCF.Trim(spdNgTray.ActiveSheet.Cells[0, 0].Text));                            
                    }                    
                }

                if (MPCF.CallService("CUS", "CWIP_Tran_String_Change", in_node, ref out_node) == false)
                {
                    return false;
                }                

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// 작업지시 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Lot_Info()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                ClearData("2");

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_STRING_LIST", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }                

                i_cell_col_cnt = MPCF.ToInt(dt.Rows[0]["MAT_CMF_11"].ToString());
                i_string_row_cnt  = MPCF.ToInt(dt.Rows[0]["MAT_CMF_12"].ToString());

                spdModuleInfo.ActiveSheet.RowCount = i_string_row_cnt;
				//Spred 디자이너에서 설정한 항목들 사용하지 않고 런타임으로 컬럼 만듬
                spdModuleInfo.ActiveSheet.Columns.Count = 2; 

                char c_alphabet = 'A';

                for(int q= 0; q < i_string_row_cnt; q++)
                {
                    spdModuleInfo.ActiveSheet.RowHeader.Cells[q, 0].Text = ((char)(int)(c_alphabet)).ToString();
                    c_alphabet++;
                }

                for(int k =0; k < i_cell_col_cnt +1; k++)
                {
                    spdModuleInfo.ActiveSheet.Columns.Count++;

                    if (k == i_cell_col_cnt)
                    {
                        spdModuleInfo.ActiveSheet.ColumnHeader.Cells[0, i_cell_col_cnt + 2].Text = "Soldering 하단";
                        spdModuleInfo_Sheet1.Columns.Get(i_cell_col_cnt + 2).Width = 100F;
                        spdModuleInfo_Sheet1.Columns[i_cell_col_cnt + 2].BackColor = System.Drawing.Color.PowderBlue;
                        spdModuleInfo.ActiveSheet.Columns[i_cell_col_cnt + 2].Locked = true;
                        spdModuleInfo_Sheet1.Columns[i_cell_col_cnt + 2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdModuleInfo_Sheet1.Columns[i_cell_col_cnt + 2].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    }
                    else
                    {
                        spdModuleInfo.ActiveSheet.ColumnHeader.Cells[0, k + 2].Text = (k + 1).ToString();
                        spdModuleInfo.ActiveSheet.Columns[k + 2].Locked = true;
                        spdModuleInfo_Sheet1.Columns[k + 2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                        spdModuleInfo_Sheet1.Columns[k + 2].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                    }
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdModuleInfo.ActiveSheet.Cells[i, 1].Text = "";
                    spdModuleInfo.ActiveSheet.Columns[1].BackColor = System.Drawing.Color.PowderBlue;

                    for (int k = 0; k < spdModuleInfo.ActiveSheet.RowHeader.Rows.Count; k++)
                    {
                        if (spdModuleInfo.ActiveSheet.RowHeader.Rows[k].Label == dt.Rows[i]["STRING_LINE"].ToString())
                        {
                            spdModuleInfo.ActiveSheet.Cells[k, 0].Value = dt.Rows[i]["STRING_ID"].ToString();
							
                            break;
                        }
                    }
                }

				spdModuleInfo_Sheet1.Columns[0].Width = 100f;	//스트링 아이디
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 작업지시 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Cell_Info()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;
            int i_col_seq = 0;

            try
            {
                MPCF.ClearList(spdSolderingDefect);

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

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

                    for (int k = 0; k < spdModuleInfo.ActiveSheet.Rows.Count; k++)
                    {
                        if (spdModuleInfo.ActiveSheet.Cells[k, 0].Text == MPCF.Trim(dt.Rows[i]["STRING_ID"].ToString()))
                        {
                            if (dt.Rows[i]["LOSS_TYPE"].ToString() == "CELL" && MPCF.Trim(dt.Rows[i]["LOSS_CODE"].ToString()) != "")
                            {
                                spdModuleInfo.ActiveSheet.Cells[k, i_col_seq + 1].Text = "√";
                                spdModuleInfo.ActiveSheet.Cells[k, i_col_seq + 1].BackColor = Color.Red;
                            }
                        }
                        if (spdModuleInfo.ActiveSheet.Rows[k].Label == MPCF.Trim(dt.Rows[i]["POSITION"].ToString()))
                        {
                            if (dt.Rows[i]["LOSS_TYPE"].ToString() == "SOLDERING")
                            {
                                if (dt.Rows[i]["LOCATION"].ToString() == "상단")
                                {
                                    spdModuleInfo.ActiveSheet.Cells[k, 1].Text = "√";    
                                    spdModuleInfo.ActiveSheet.Cells[k, 1].BackColor = Color.Red;
                                }
                                else if (dt.Rows[i]["LOCATION"].ToString() == "하단")
                                {
                                    spdModuleInfo.ActiveSheet.Cells[k, spdModuleInfo.ActiveSheet.Columns.Count -1].Text = "√";
                                    spdModuleInfo.ActiveSheet.Cells[k, spdModuleInfo.ActiveSheet.Columns.Count - 1].BackColor = Color.Red;
                                }

                                spdSolderingDefect.ActiveSheet.RowCount++;
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.LOCATION].Text = dt.Rows[i]["LOCATION"].ToString();
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.POSIOTION].Text = dt.Rows[i]["POSITION"].ToString();
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.LOSS_CODE].Text = dt.Rows[i]["LOSS_CODE"].ToString();
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.LOSS_CODE_DESC].Text = dt.Rows[i]["LOSS_CODE_DESC"].ToString();
                                //spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.RESULT_CODE].Text = dt.Rows[i]["RESULT_CODE"].ToString();
                                //spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.RESULT_CODE_DESC].Text = dt.Rows[i]["RESULT_CODE_DESC"].ToString();
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

        /// <summary>
        /// View Lot
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Sordering_Result()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("RESULT_CODE", MPCF.Trim(cdvLossCode.Tag));
                in_node.AddString("POSITION", MPCF.Trim(txtPosition.Text));
                in_node.AddString("LOCATION", MPCF.Trim(txtGubun.Text));

                if (MPCF.CallService("CUS", "CWIP_Tran_Defect_Lot", in_node, ref out_node) == false)
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

        /// <summary>
        /// 작업지시 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Tray_Info(char sStep, string sTray)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";
            string s_Tray_type = "";
            string s_string_id = "";

            int i = 0;

            try
            {
                MPCF.ShowMessageClear();

                if (sStep == '1')
                {
                    spdOkTray_Sheet1.RowCount = 0;
                    s_Tray_type = "OK";
                }
                else
                {
                    spdNgTray_Sheet1.RowCount = 0;
                    s_Tray_type = "NG";
                }

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TRAY_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sTray);

                dvcArgu[2].sCondtion_ID = "$TRAY_TYPE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(s_Tray_type);

                //if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_STRING_LIST", dvcArgu, false, false, ref s_sql) == false)
                if (TPDR.GetDataOne("", ref dt, "VIEW_TRAY_STRING_LIST_01", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    MPCF.ShowErrorMessage("해당 Tray의 Data가 존재하지 않습니다.");
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (sStep == '1')
                    {
                        if (i == 0)
                        {
                            s_string_id = dt.Rows[i]["STRING_ID"].ToString();

                            spdOkTray.ActiveSheet.RowCount++;
                            spdOkTray.ActiveSheet.Cells[i, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                            spdOkTray_Sheet1.RowHeader.Cells.Get(i, 0).Value = dt.Rows[i]["STRING_SEQ"].ToString();

                            spdOkTray.ActiveSheet.Cells[i, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].BackColor = Color.LightGreen;
							spdOkTray.ActiveSheet.Cells[spdOkTray.ActiveSheet.RowCount-1, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        }
                        else
                        {
                            if(s_string_id != dt.Rows[i]["STRING_ID"].ToString())
                            {
                                spdOkTray.ActiveSheet.RowCount++;
                                spdOkTray.ActiveSheet.Cells[spdOkTray.ActiveSheet.RowCount - 1, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                                spdOkTray_Sheet1.RowHeader.Cells.Get(spdOkTray.ActiveSheet.RowCount - 1, 0).Value = dt.Rows[i]["STRING_SEQ"].ToString();
								spdOkTray.ActiveSheet.Cells[spdOkTray.ActiveSheet.RowCount -1, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();

                                s_string_id = dt.Rows[i]["STRING_ID"].ToString();
                            }
                            
                            spdOkTray.ActiveSheet.Cells[spdOkTray.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].BackColor = Color.LightGreen;    
                            
                        }

                        MPCF.FitColumnHeader(spdOkTray);
                        //spdOkTray.ActiveSheet.Columns[1].Width = 170;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            s_string_id = dt.Rows[i]["STRING_ID"].ToString();

                            spdNgTray.ActiveSheet.RowCount++;
                            spdNgTray.ActiveSheet.Cells[i, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                            spdNgTray.ActiveSheet.Cells[i, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].BackColor = Color.LightGreen;
                            spdNgTray_Sheet1.RowHeader.Cells.Get(i, 0).Value = dt.Rows[i]["STRING_SEQ"].ToString();
							spdNgTray.ActiveSheet.Cells[spdNgTray.ActiveSheet.RowCount - 1, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        }
                        else
                        {
                            if (s_string_id != dt.Rows[i]["STRING_ID"].ToString())
                            {
                                spdNgTray.ActiveSheet.RowCount++;
                                spdNgTray.ActiveSheet.Cells[spdNgTray.ActiveSheet.RowCount -1, (int)TRAY.STRING].Value = dt.Rows[i]["STRING_ID"].ToString();
                                spdNgTray_Sheet1.RowHeader.Cells.Get(spdNgTray.ActiveSheet.RowCount - 1, 0).Value = dt.Rows[i]["STRING_SEQ"].ToString();
								spdNgTray.ActiveSheet.Cells[spdNgTray.ActiveSheet.RowCount -1, (int)TRAY.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();

                                s_string_id = dt.Rows[i]["STRING_ID"].ToString();
                            }

                            spdNgTray.ActiveSheet.Cells[spdNgTray.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].BackColor = Color.LightGreen;
                        }

                        if (dt.Rows[i]["LOSS_CODE"].ToString() != " ")
                        {
                            spdNgTray.ActiveSheet.Cells[spdNgTray.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].Text = "√";
                            spdNgTray.ActiveSheet.Cells[spdNgTray.ActiveSheet.RowCount - 1, MPCF.ToInt(dt.Rows[i]["CELL_SEQ"].ToString())].BackColor = Color.Red;
                        }

                        MPCF.FitColumnHeader(spdNgTray);
                        //spdNgTray.ActiveSheet.Columns[1].Width = 170;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (View_Lot_Info() == true)
            {
                View_Cell_Info();
            }
        }

        private void frmCUSTranModuleManage_Load(object sender, EventArgs e)
        {
			MPCF.ConvertCaption(this);
            MPCF.ClearList(spdOkTray);
            MPCF.ClearList(spdNgTray);
            MPCF.ClearList(spdSolderingDefect);

            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;
                btnView.PerformClick();
            }
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                btnView.PerformClick();

                txtLotID.Focus();
                txtLotID.SelectAll();
            }
        }

        private void frmCUSTranModuleManage_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtLotID);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData("1");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

            if (CheckCondition("PROCESS") == false)
            {
                return;
            }

            if (Tran_Sordering_Result() == true)
            {
                txtPosition.Text = "";
                txtGubun.Text = "";
                cdvLossCode.Text = "";
                cdvLossCode.Tag = string.Empty;
                btnView.PerformClick();                
                MPCF.SetFocus(txtLotID);
            }
        }

        private void txtOkTray_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                if (string.IsNullOrEmpty(txtOkTray.Text) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                    MPCF.SetFocus(txtOkTray);
                    return;
                }

                txtOkTray.Text = MPCF.ToUpper(txtOkTray.Text); // 일괄 대문자

                if(View_Tray_Info('1', txtOkTray.Text) == false)
                {
                    txtOkTray.Text = "";
                    MPCF.SetFocus(txtOkTray);
                }

                txtOkTray.Focus();
                txtOkTray.SelectAll();
            }
        }

        private void txtNGTray_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                if (string.IsNullOrEmpty(txtNGTray.Text) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Tray ID]"));
                    MPCF.SetFocus(txtNGTray);
                    return;
                }

                txtNGTray.Text = MPCF.ToUpper(txtNGTray.Text); // 일괄 대문자

                if(View_Tray_Info('2', txtNGTray.Text) == false)
                {
                    //txtNGTray.Text = "";
                    MPCF.SetFocus(txtNGTray);
                    txtNGTray.SelectAll();
                }
            }
        }

        private void btnOKUp_Click(object sender, EventArgs e)
        {
            if(Tran_String_Change('2', "OK", txtOkTray.Text) == true)
            {
                View_Lot_Info();

                View_Cell_Info();

                View_Tray_Info('1', txtOkTray.Text);
            }
        }

        private void btnOKDown_Click(object sender, EventArgs e)
        {
            if (Tran_String_Change('1', "OK", txtOkTray.Text) == true)
            {
                View_Lot_Info();

                View_Cell_Info();

                View_Tray_Info('1', txtOkTray.Text);
            }
        }

        private void btnNGUp_Click(object sender, EventArgs e)
        {
            if (Tran_String_Change('2', "NG", txtNGTray.Text) == true)
            {
                View_Lot_Info();

                View_Cell_Info();

                View_Tray_Info('2', txtNGTray.Text);
            }
        }

        private void btnNGDown_Click(object sender, EventArgs e)
        {
            if (Tran_String_Change('1', "NG", txtNGTray.Text) == true)
            {
                View_Lot_Info();

                View_Cell_Info();

                View_Tray_Info('2', txtNGTray.Text);
            }
        }

        private void cdvLossCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
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
                        cdvLossCode.Tag = cdvDefectSoldering.returnDatas[0];
                        cdvLossCode.Text = cdvDefectSoldering.returnDatas[1];
                    }
                    else
                    {
                        cdvLossCode.Tag = "";
                        cdvLossCode.Text = "";
                    }
                }
                else
                {
                    cdvLossCode.Tag = "";
                    cdvLossCode.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void utbStringChange_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (utbStringChange.SelectedTab.Index == 0)
            {
                btnProcess.Visible = false;
            }
            else
            {
                btnProcess.Visible = true;
            }
        }

        private void spdSolderingDefect_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (spdSolderingDefect.ActiveSheet.RowCount == 0) return;

            txtGubun.Text = spdSolderingDefect.ActiveSheet.Cells[e.Row, 0].Text;
            txtPosition.Text = spdSolderingDefect.ActiveSheet.Cells[e.Row, 1].Text;
            cdvLossCode.Text = spdSolderingDefect.ActiveSheet.Cells[e.Row, 6].Text;
            cdvLossCode.Tag = spdSolderingDefect.ActiveSheet.Cells[e.Row, 5].Text;
        }

        private void btnLossRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLotID.Text) == false)
                {
                    MPGV.gsCurrentLot_ID = txtLotID.Text;
                }

                //모듈내 불량자재등록 화면
                BICF.OpenMenu("SOI2022");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            } 
        }

		private void btnTranDefectRegister_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtLotID.Text) == false)
				{
					MPGV.gsCurrentLot_ID = txtLotID.Text;
				}

				//모듈내 String 불량 의뢰
				BICF.OpenMenu("SOI2015");
			}
			catch (Exception ex)
			{
				MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
			} 			
		}
    }
}
