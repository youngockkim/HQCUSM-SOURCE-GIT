using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.CliFrx;
using SOI.OIFrx.SOIModel;

namespace SOI.HanwhaQcell.USModule
{
    public partial class frmCUSCleavingProductionGram : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCUSCleavingProductionGram()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum SCRAP_LIST
        {
            WORK_DATE = 0,
            LINE_ID,
            WORK_SHIFT,
            MAT_ID,
            MAT_SHORT_DESC,
            RES_ID,
            RES_DESC,
            EFF,
            GRADE,
            LOSS_SEQ,
            INPUT_QTY,
            OUT_QTY,
            UNPACK_BROKEN,
            UNPACK_COMMENT,
            FULL_CHIP,
            FULL_BROKEN,
            FULL_COMMENT,
            HALF_BROKEN,
            HALF_COMMENT,
            CJ,
            CJ_COMMENT,
            LINE_DESC,
            WORK_SHIFT_DESC
        }

        #endregion

        #region [Variable Definition]
        
        #endregion

        #region Event Handler

        private void frmCUSCleavingProductionGram_Load(object sender, EventArgs e)
        {
            // Init
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            dtpScrap.Value = DateTime.Today;

            TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_GCM_DATA_OUT");
            TRSNode out_list;
            MPCF.SetInMsg(in_node);

            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_CELL_POWER_GRADE));
            int i;

            if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == true)
            {
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    cboGrade.Items.Add(out_list.GetString("KEY_1"), out_list.GetString("KEY_1"));
                }
            }
           
            MPCF.ConvertCaption(this);
        }

        private void frmCUSCleavingProductionGram_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(dtpFrom);

                bIsShown = true;
            }
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
                in_node.AddString("LINE_LOCATION", "E1");//Eagle2 - 2023/08/28 이글1만 나오도록 수정

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

                string[] header = new string[] { "Shift", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvShift.Text = cdvShift.Show(cdvShift, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        
        private void cdvScrapLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            DateTime dtpScrapDateTimeOut = new DateTime();

            try
            {
                TRSNode in_node = new TRSNode("VIEW_LINE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));
                in_node.AddString("LINE_LOCATION", "E1");//Eagle2 - 2023/08/28 이글1만 나오도록 수정

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvScrapLine.Text = cdvScrapLine.Show(cdvScrapLine, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Clear
                MPCF.FieldClear(pnlScrapInfo, cdvScrapLine);

                // MatId 1개 인 경우 자동반영되도록
                TRSNode in_mat_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_MATERIAL_LIST_OUT");
                MPCF.SetInMsg(in_mat_node);
                in_mat_node.ProcStep = '1';

                bool bTrySuccess = DateTime.TryParse(dtpScrap.Value.ToString(), out dtpScrapDateTimeOut);
                if (bTrySuccess == true)
                {
                    in_mat_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                    in_mat_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLine.Text));
                    in_mat_node.AddString("OPER", "M2000");

                    if (MPCF.CallService("CWIP", "CWIP_View_Material_List_By_Production", in_mat_node, ref out_node) == true)
                    {
                        if (out_node.GetList(0).Count == 1)
                        {
                            TRSNode out_list = out_node.GetList(0)[0];
                            cdvMatID.Text = out_list.GetString("MAT_ID");
                            cdvMatID.Description = out_list.GetString("MAT_SHORT_DESC");
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvScrapShift_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

                string[] header = new string[] { "Shift", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvScrapShift.Text = cdvScrapShift.Show(cdvScrapShift, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvMatID_CodeViewButtonClick(object sender, EventArgs e)
        {
            DateTime dtpScrapDateTimeOut = new DateTime();
            try
            {
                if (CheckCondition("MATERIAL") == false)
                    return;

                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                bool bTrySuccess = DateTime.TryParse(dtpScrap.Value.ToString(), out dtpScrapDateTimeOut);
                if (bTrySuccess == true)
                {
                    in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                }
                in_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLine.Text));
                in_node.AddString("OPER", "M2000");

                string[] header = new string[] { "Material", "Description" };
                string[] display = new string[] { "MAT_ID", "MAT_SHORT_DESC" };

                cdvMatID.Text = cdvMatID.Show(cdvMatID, "Material ID", "CWIP", "CWIP_View_Material_List_By_Production", in_node, "MAT_LIST", display, header, "MAT_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvMatID.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
        
        private void cdvScrapEquip_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(HQGC.LINE_CVL01));
                in_node.AddString("OPER", "M1000");

                string[] header = new string[] { "Resource", "Description" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                cdvScrapEquip.Text = cdvScrapEquip.Show(cdvScrapEquip, "Resource ID", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvScrapEquip.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnToExcelModules_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog pop = new SaveFileDialog();
                pop.InitialDirectory = "C:\\";

                pop.FileName = MPCF.Trim(lblFormTitle.Text) + "_" + MPCF.Trim(grpScrapList.Text) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                pop.Filter = "Excel Files(*.xls)|*.xls|All files(*.*)|*.*";
                pop.FilterIndex = 1;

                if (pop.ShowDialog() == DialogResult.OK)
                {
                    spdScrap.Sheets[0].Protect = false;
                    spdScrap.SaveExcel(pop.FileName, FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);
                    spdScrap.Sheets[0].Protect = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear
                MPCF.FieldClear(pnlScrapInfo);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewScrapList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("CREATE") == false)
                {
                    return;
                }

                if (UpdateScrap(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }

                // Refresh
                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("UPDATE") == false)
                {
                    return;
                }

                if (UpdateScrap(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }

                // Refresh
                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("DELETE") == false)
                {
                    return;
                }

                if (UpdateScrap(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }

                // Refresh
                btnView.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdScrap_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                // Clear
                MPCF.FieldClear(pnlScrapInfo, cdvScrapLine);

                // Display Scrap Information
                dtpScrap.Value = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.WORK_DATE].Text;
                cdvScrapLine.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LINE_ID].Text;
                cdvScrapLine.Description = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LINE_DESC].Text;
                cdvScrapShift.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.WORK_SHIFT].Text;
                cdvScrapShift.Description = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.WORK_SHIFT_DESC].Text;
                cdvMatID.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.MAT_ID].Text;
                cdvMatID.Description = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.MAT_SHORT_DESC].Text;
                cdvScrapEquip.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.RES_ID].Text;
                cdvScrapEquip.Description = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.RES_DESC].Text;

                txtEff.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.EFF].Text;
                cboGrade.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.GRADE].Text;

                txtLossSeq.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_SEQ].Text;

                txtInputQty.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.INPUT_QTY].Text;
                txtOutputQty.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.OUT_QTY].Text;

                txtUpBrokenQty.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.UNPACK_BROKEN].Text;
                txtUpComment.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.UNPACK_COMMENT].Text;
                txtFcChipQty.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.FULL_CHIP].Text;
                txtFcBrokenQty.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.FULL_BROKEN].Text;
                txtFcComment.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.FULL_COMMENT].Text;
                txtHcBrokenQty.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.HALF_BROKEN].Text;
                txtHcComment.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.HALF_COMMENT].Text;
                txtCjBrokenQty.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.CJ].Text;
                txtCjComment.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.CJ_COMMENT].Text;




               
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        #endregion
        
        #region Function

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "MATERIAL":

                        if (MPCF.CheckValue(dtpScrap, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvScrapLine, false) == false)
                        {
                            return false;
                        }
                        break;

                    case "CREATE":

                        if (MPCF.CheckValue(cdvScrapLine, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvScrapShift, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(dtpScrap, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvScrapEquip, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvMatID, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "UPDATE":

                        if (spdScrap.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(546));
                            return false;
                        }

                        if (MPCF.CheckValue(dtpScrap, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvScrapLine, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvScrapShift, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvScrapEquip, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvMatID, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "DELETE":

                        if (spdScrap.Sheets[0].SelectionCount < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(546));
                            return false;
                        }

                        if (MPCF.CheckValue(dtpScrap, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvScrapLine, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvScrapShift, false) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(cdvScrapEquip, false) == false)
                        {
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

        private bool ViewScrapList()
        {
            try
            {
                int i;
                DateTime dtpFromDateTimeOut = new DateTime();
                DateTime dtpToDateTimeOut = new DateTime();

                MPCF.ClearList(spdScrap);

                TRSNode in_node = new TRSNode("VIEW_SCRAP_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_SCRAP_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (dtpFrom.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpFromDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_DATE", dtpFromDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (dtpTo.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpTo.Value.ToString(), out dtpToDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("TO_DATE", dtpToDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                // Line ID
                if (string.IsNullOrEmpty(MPCF.Trim(cdvLineID.Text)))
                {
                    in_node.AddString("LINE_ID", "%");
                }
                else
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvLineID.Text));
                }

                // Work Shift
                if (string.IsNullOrEmpty(MPCF.Trim(cdvShift.Text)))
                {
                    in_node.AddString("WORK_SHIFT", "%");
                }
                else
                {
                    in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvShift.Text));
                }

                if (MPCF.CallService("CWIP", "CWIP_View_Cleaving_Loss_List_Gram", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdScrap.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdScrap.ActiveSheet.RowCount++;

                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.WORK_DATE].Value = MPCF.MakeDateFormat(out_list.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);

                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LINE_ID].Value = out_list.GetString("LINE_ID");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.WORK_SHIFT].Value = out_list.GetString("WORK_SHIFT");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.MAT_ID].Value = out_list.GetString("MAT_ID");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.MAT_SHORT_DESC].Value = out_list.GetString("MAT_SHORT_DESC");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.RES_ID].Value = out_list.GetString("RES_ID");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.RES_DESC].Value = out_list.GetString("RES_DESC");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.EFF].Value = out_list.GetString("EFF");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.GRADE].Value = out_list.GetString("GRADE");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LOSS_SEQ].Value = MPCF.MakeNumberFormat(out_list.GetDouble("LOSS_SEQ"), 0);

                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.INPUT_QTY].Value = MPCF.MakeNumberFormat(out_list.GetDouble("INPUT_QTY"), 0);
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.OUT_QTY].Value = MPCF.MakeNumberFormat(out_list.GetDouble("OUT_QTY"), 0);

                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.UNPACK_BROKEN].Value = MPCF.MakeNumberFormat(out_list.GetDouble("UNPACK_BROKEN"), 0);
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.UNPACK_COMMENT].Value = out_list.GetString("UNPACK_COMMENT");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.FULL_CHIP].Value = MPCF.MakeNumberFormat(out_list.GetDouble("FULL_CHIP"), 0);
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.FULL_BROKEN].Value = MPCF.MakeNumberFormat(out_list.GetDouble("FULL_BROKEN"), 0);
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.FULL_COMMENT].Value = out_list.GetString("FULL_COMMENT");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.HALF_BROKEN].Value = MPCF.MakeNumberFormat(out_list.GetDouble("HALF_BROKEN"), 0);
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.HALF_COMMENT].Value = out_list.GetString("HALF_COMMENT");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.CJ].Value = MPCF.MakeNumberFormat(out_list.GetDouble("CJ"), 0);
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.CJ_COMMENT].Value = out_list.GetString("CJ_COMMENT");

                    // Visible = false
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LINE_DESC].Value = out_list.GetString("LINE_DESC");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.WORK_SHIFT_DESC].Value = out_list.GetString("WORK_SHIFT_DESC");
                }

                MPCF.FitColumnHeader(spdScrap);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        
        private bool UpdateScrap(char ProcStep)
        {
            try
            {
                DateTime dtpScrapDateTimeOut = new DateTime();

                TRSNode in_node = new TRSNode("UPDATE_SCRAP_LIST_IN");
                TRSNode out_node = new TRSNode("UPDATE_SCRAP_LIST_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("FACTORY", MPGV.gsFactory);

                // Scrap Date
                if (dtpScrap.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpScrap.Value.ToString(), out dtpScrapDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                in_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLine.Text));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvScrapShift.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvScrapEquip.Text));
                in_node.AddString("EFF", MPCF.Trim(txtEff.Text));
                in_node.AddString("GRADE", MPCF.Trim(cboGrade.Value));
                in_node.AddDouble("LOSS_SEQ", MPCF.ToDbl(txtLossSeq.Text));
                in_node.AddDouble("INPUT_QTY", MPCF.ToDbl(txtInputQty.Text));
                in_node.AddDouble("OUT_QTY", MPCF.ToDbl(txtOutputQty.Text));

               

                in_node.AddString("UNPACK_BROKEN", MPCF.Trim(txtUpBrokenQty.Text.Replace(",","")));
                in_node.AddString("UNPACK_COMMENT", MPCF.Trim(txtUpComment.Text.Replace(",", "")));
                in_node.AddString("FULL_CHIP", MPCF.Trim(txtFcChipQty.Text.Replace(",", "")));
                in_node.AddString("FULL_BROKEN", MPCF.Trim(txtFcBrokenQty.Text.Replace(",", "")));
                in_node.AddString("FULL_COMMENT", MPCF.Trim(txtFcComment.Text.Replace(",", "")));
                in_node.AddString("HALF_BROKEN", MPCF.Trim(txtHcBrokenQty.Text.Replace(",", "")));
                in_node.AddString("HALF_COMMENT", MPCF.Trim(txtHcComment.Text.Replace(",", "")));
                in_node.AddString("CJ", MPCF.Trim(txtCjBrokenQty.Text.Replace(",", "")));
                in_node.AddString("CJ_COMMENT", MPCF.Trim(txtCjComment.Text.Replace(",", "")));


                if (MPCF.CallService("CWIP", "CWIP_Update_Cleaving_Loss_Gram", in_node, ref out_node) == false)
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
        #endregion
    }
}
