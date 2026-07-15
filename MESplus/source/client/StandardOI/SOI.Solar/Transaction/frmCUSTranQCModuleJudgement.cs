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
    public partial class frmCUSTranQCModuleJudgement : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        public frmCUSTranQCModuleJudgement()
        {
            InitializeComponent();
        }

        #region [Constant Definition]

        public enum SOLDER
        {
            LOCATION,
            POSIOTION,
            LOSS_CODE,
            LOSS_CODE_DESC,
            RESULT_CODE,
            RESULT_CODE_DESC
        }

        public enum CELL
        {
            POSIOTION,
            LOSS_CODE,
            LOSS_CODE_DESC,
            RESULT_CODE,
            RESULT_CODE_DESC
        }

        public enum MAT
        {
            OPER,
            OPER_DESC,
            RES_ID,
            RES_DESC,
            MAT_ID,
            MAT_DESC,
            MAT_LOT_ID,
            MAT_QTY,
            UNIT_1,
            REASON_CODE,
            REASON_CODE_DESC,
            RESULT_CODE,
            RESULT_CODE_DESC,            
            TRAN_TIME,
            TRAN_USER_ID
        }

        #endregion


        #region [Variable Definition]

        private bool bIsShown = false;
        private int i_string_row_cnt = 0;
        private int i_cell_col_cnt = 0;

        #endregion


        #region [FormDefinition]

        private void frmCUSTranQCModuleJudgement_Load(object sender, EventArgs e)
        {
            ClearData("1");
        }

        private void frmCUSTranQCModuleJudgement_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtLotID);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            txtLotID.Text = MPCF.ToUpper(txtLotID.Text); // 일괄 대문자

            if (View_Lot_Info() == true)
            {
                //솔더, CELL 불량 정보 
                View_Cell_Info();

                //불량 자재 정보
                ViewUseMaterial(txtLotID.Text);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            MPCF.ShowMessageClear();

            if (!CheckCondition("PROCESS"))
                return;

            if (Tran_Module_Lot_Process() == true)
            {
                ClearData("1");

                MPCF.SetFocus(txtLotID);
            }
        }

        #endregion


        #region [Function Definition]

        private bool CheckCondition(string FuncName, int Case = 0)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_VIEW:

                        

                        break;

                    case "PROCESS":

                        if (string.IsNullOrEmpty(txtLotID.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Lot ID]"));
                            MPCF.SetFocus(txtLotID);
                            return false;
                        }

                        if (string.IsNullOrEmpty(cdvQCJudgement.Text) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Judgement]"));
                            MPCF.SetFocus(cdvQCJudgement);
                            return false;
                        }

                        if (cdvQCJudgement.Text == "NG")
                        {
                            if (string.IsNullOrEmpty(cdvResultCode.Text) == true)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(335) + Environment.NewLine + MPCF.FindLanguage("[Defect Code]"));
                                MPCF.SetFocus(cdvResultCode);
                                return false;
                            }
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
                    txtLotID.Text = "";
                    MPCF.ClearList(spdCellDefect);
                    MPCF.ClearList(spdUseMaterial);
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
                    //txtGubun.Text = "";
                    //txtPosition.Text = "";

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
                i_string_row_cnt = MPCF.ToInt(dt.Rows[0]["MAT_CMF_12"].ToString());

                spdModuleInfo.ActiveSheet.RowCount = i_string_row_cnt;
                spdModuleInfo.ActiveSheet.Columns.Count = 2;

                char c_alphabet = 'A';

                for (int q = 0; q < i_string_row_cnt; q++)
                {
                    spdModuleInfo.ActiveSheet.RowHeader.Cells[q, 0].Text = ((char)(int)(c_alphabet)).ToString();
                    c_alphabet++;
                }

                for (int k = 0; k < i_cell_col_cnt + 1; k++)
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
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 솔더링 불량 조회
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
                MPCF.ClearList(spdCellDefect);
                MPCF.ClearList(spdSolderingDefect);

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_CELL_LOSS_INFO", dvcArgu, false, false, ref s_sql) == false)
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
                            if (dt.Rows[i]["LOSS_TYPE"].ToString() == "CELL")
                            {
                                spdModuleInfo.ActiveSheet.Cells[k, i_col_seq + 2].BackColor = Color.Red;

                                spdCellDefect.ActiveSheet.RowCount++;
                                spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, (int)CELL.POSIOTION].Text = dt.Rows[i]["POSITION"].ToString();
                                spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, (int)CELL.LOSS_CODE].Text = dt.Rows[i]["LOSS_CODE"].ToString();
                                spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, (int)CELL.LOSS_CODE_DESC].Text = dt.Rows[i]["LOSS_CODE_DESC"].ToString();
                                spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, (int)CELL.RESULT_CODE].Text = dt.Rows[i]["RESULT_CODE"].ToString();
                                spdCellDefect.ActiveSheet.Cells[spdCellDefect.ActiveSheet.RowCount - 1, (int)CELL.RESULT_CODE_DESC].Text = dt.Rows[i]["RESULT_CODE_DESC"].ToString();
                            }
                            else if (dt.Rows[i]["LOSS_TYPE"].ToString() == "SOLDERING")
                            {
                                if (dt.Rows[i]["LOCATION"].ToString() == "상단")
                                {
                                    spdModuleInfo.ActiveSheet.Cells[k, 1].BackColor = Color.Red;
                                }
                                else if (dt.Rows[i]["LOCATION"].ToString() == "하단")
                                {
                                    spdModuleInfo.ActiveSheet.Cells[k, spdModuleInfo.ActiveSheet.Columns.Count - 1].BackColor = Color.Red;
                                }

                                spdSolderingDefect.ActiveSheet.RowCount++;
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.LOCATION].Text = dt.Rows[i]["LOCATION"].ToString();
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.POSIOTION].Text = dt.Rows[i]["POSITION"].ToString();
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.LOSS_CODE].Text = dt.Rows[i]["LOSS_CODE"].ToString();
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.LOSS_CODE_DESC].Text = dt.Rows[i]["LOSS_CODE_DESC"].ToString();
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.RESULT_CODE].Text = dt.Rows[i]["RESULT_CODE"].ToString();
                                spdSolderingDefect.ActiveSheet.Cells[spdSolderingDefect.ActiveSheet.RowCount - 1, (int)SOLDER.RESULT_CODE_DESC].Text = dt.Rows[i]["RESULT_CODE_DESC"].ToString();
                            }

                            break;
                        }
                    }
                }

                MPCF.FitColumnHeader(spdSolderingDefect);
                MPCF.FitColumnHeader(spdCellDefect);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool ViewUseMaterial(string sLotID)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            try
            {
                MPCF.ClearList(spdUseMaterial);

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(sLotID);

                if (TPDR.GetDataOne("", ref dt, "VIEW_USE_MATERIAL_LOSS", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();

                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["QC_RESULT"].ToString() == "NG")
                    {
                        spdUseMaterial.ActiveSheet.RowCount++;
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.OPER].Value = dt.Rows[i]["OPER"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.OPER_DESC].Value = dt.Rows[i]["OPER_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.RES_ID].Value = dt.Rows[i]["RES_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.RES_DESC].Value = dt.Rows[i]["RES_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.MAT_DESC].Value = dt.Rows[i]["MAT_SHORT_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.MAT_LOT_ID].Value = dt.Rows[i]["MAT_LOT_ID"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.MAT_QTY].Value = dt.Rows[i]["QTY_1"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.UNIT_1].Value = dt.Rows[i]["UNIT_1"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.REASON_CODE].Value = dt.Rows[i]["REASON_CODE"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.REASON_CODE_DESC].Value = dt.Rows[i]["REASON_CODE_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.RESULT_CODE].Value = dt.Rows[i]["RESULT_CODE"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.RESULT_CODE_DESC].Value = dt.Rows[i]["RESULT_CODE_DESC"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.TRAN_TIME].Value = dt.Rows[i]["TRAN_TIME"].ToString();
                        spdUseMaterial.ActiveSheet.Cells[spdUseMaterial.ActiveSheet.RowCount - 1, (int)MAT.TRAN_USER_ID].Value = dt.Rows[i]["TRAN_USER_ID"].ToString();
                    }
                }

                MPCF.FitColumnHeader(spdUseMaterial);

                spdUseMaterial.ActiveSheet.Columns[(int)MAT.MAT_DESC].Width = 220F;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 모듈 LOT 판정 처리
        /// </summary>
        /// <param name="sLotID"></param>
        /// <returns></returns>
        private bool Tran_Module_Lot_Process()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            string reson_code = string.Empty;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';

                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("QC_RESULT", MPCF.Trim(cdvQCJudgement.Text));
                in_node.AddString("QC_LOSS_CODE", MPCF.Trim(cdvResultCode.Text));

                if (MPCF.CallService("CUS", "CWIP_Tran_QC_Lot_Process", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvQCJudgement.Text = "";
                cdvResultCode.Text = "";
                txtCodeDesc.Text = "";
                txtQCDesc.Text = "";

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion              


        #region [Event Definition]

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                MPCF.ShowMessage("", MSG_LEVEL.NONE, false);

                btnView.PerformClick();
            }
        }

        private void cdvQCJudgement_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "OKNG";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvQCJudgement.Text = cdvQCJudgement.Show(cdvQCJudgement, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                if (MPCF.Trim(cdvQCJudgement.Text) != "")
                {
                    if (cdvQCJudgement.returnDatas != null && cdvQCJudgement.returnDatas.Count > 0)
                    {
                        cdvQCJudgement.Text = cdvQCJudgement.returnDatas[0];
                        txtQCDesc.Text = cdvQCJudgement.returnDatas[1];
                    }
                }
                else
                {
                    cdvQCJudgement.Text = "";
                    txtQCDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }        
        }

        private void cdvResultCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$TABLE_NAME";
                dvcArgu[1].sCondition_Value = "C@LOSS_CODE";

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Code Desc" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvResultCode.Text = cdvResultCode.Show(cdvResultCode, "Code Desc", "VIEW_GCM_DATA", dvcArgu, display, header, "DATA_1", -1);

                if (MPCF.Trim(cdvResultCode.Text) != "")
                {
                    if (cdvResultCode.returnDatas != null && cdvResultCode.returnDatas.Count > 0)
                    {
                        cdvResultCode.Text = cdvResultCode.returnDatas[0];
                        txtCodeDesc.Text = cdvResultCode.returnDatas[1];
                    }
                }
                else
                {
                    cdvResultCode.Text = "";
                    txtCodeDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion          
    }
}
