using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using SOI.WIP;
using Infragistics.Win.UltraWinGrid;

using System.Globalization;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCWIPCellScrapManagementBySingleItem : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmCWIPCellScrapManagementBySingleItem()
        {
            InitializeComponent();
        }

        #endregion

        #region [Constant Definition]

        public enum SCRAP_LIST
        {
            LINE_ID = 0,
            WORK_SHIFT,
            LOSS_OPER,
            RES_ID,
            LOSS_TYPE,
            LOSS_QTY,
            WORK_DATE,
            LOSS_COMMENT,
            CREATE_USER_ID,
            CREATE_TIME,
            UPDATE_USER_ID,
            UPDATE_TIME
        }

        #endregion

        #region [Variable Definition]

        public PrintOptionModel printOption;

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCWIPCellScrapManagementBySingleItem_Load(object sender, EventArgs e)
        {
            // Init
            dtpScrap.Value = DateTime.Today;

            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void frmCWIPCellScrapManagementBySingleItem_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                MPCF.SetFocus(cdvLineID);

                bIsShown = true;
            }
        }

        private void spdScrap_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                cdvScrapLineID.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LINE_ID].Text;
                cdvScrapShift.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.WORK_SHIFT].Text;
                dtpScrap.Value = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.WORK_DATE].Text;
                cdvScrapOper.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_OPER].Text;
                cdvScrapResID.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.RES_ID].Text;
                cdvScrapCause.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_TYPE].Text;
                txtScrapQty.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_QTY].Text;
                txtComment.Text = spdScrap.Sheets[0].Cells[e.Row, (int)SCRAP_LIST.LOSS_COMMENT].Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvLineID.Text = cdvLineID.Show(cdvLineID, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

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

        private void cdvScrapLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvScrapLineID.Text = cdvScrapLineID.Show(cdvScrapLineID, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

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

        private void cdvScrapOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvScrapLineID, false) == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLineID.Text));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvScrapOper.Text = cdvScrapOper.Show(cdvScrapOper, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                // Clear
                //MPCF.FieldClear(cdvResID);

                // Validation
                if (string.IsNullOrEmpty(cdvScrapOper.Text) == true)
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

        private void cdvScrapResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvScrapLineID, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvScrapOper, false) == false)
                {
                    return;
                }

                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLineID.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvScrapOper.Text));

                string[] header = new string[] { "Resource", "Description" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                //cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "RES_ID");
                cdvScrapResID.Text = cdvScrapResID.Show(cdvScrapResID, "Resource ID", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvScrapCause_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_CODE_IN");
                TRSNode out_node = new TRSNode("VIEW_CODE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_TERMINATE_CAUSE));

                string[] header = new string[] { "Cause Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvScrapCause.Text = cdvScrapCause.Show(cdvScrapCause, "Cause Code", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvScrapCause.Text) != "")
                {
                    if (cdvScrapCause.returnDatas.Count > 0)
                    {
                        cdvScrapCause.Tag = cdvScrapCause.returnDatas[1];
                    }

                }

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
                // Validation
                /*
                if (MPCF.CheckValue(cdvLineID, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvShift, false) == false)
                {
                    return;
                }
                */

                if (ViewScrapList() == false)
                {
                    //txtLotID.SelectAll();
                    //MPCF.SetFocus(txtLotID);
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
                // Create
                if (CheckCondition("CREATE") == false)
                {
                    return;
                }

                if (UpdateScrap(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }

                // Clear
                //MPCF.FieldClear(pnlScrapInfo);

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
                // Update
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
                // Delete
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

        #endregion

        #region Function

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "CREATE":

                        if (MPCF.CheckValue(cdvScrapLineID, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "UPDATE":

                        if (MPCF.CheckValue(cdvScrapLineID, false) == false)
                        {
                            return false;
                        }

                        break;

                    case "DELETE":

                        if (MPCF.CheckValue(cdvScrapLineID, false) == false)
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
                MPCF.ClearList(spdScrap);

                TRSNode in_node = new TRSNode("VIEW_SCRAP_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_SCRAP_LIST_OUT");
                TRSNode out_list;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1'; 

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

                if (MPCF.CallService("CWIP", "CWIP_View_Scrap_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                spdScrap.ActiveSheet.RowCount = 0;

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    out_list = out_node.GetList(0)[i];

                    spdScrap.ActiveSheet.RowCount++;

                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LINE_ID].Value = out_list.GetString("CM_KEY_1");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.WORK_SHIFT].Value = out_list.GetString("CM_KEY_2");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LOSS_OPER].Value = out_list.GetString("LOSS_OPER");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.RES_ID].Value = out_list.GetString("RES_ID");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LOSS_TYPE].Value = out_list.GetString("CM_KEY_3");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LOSS_QTY].Value = out_list.GetDouble("LOSS_QTY");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.WORK_DATE].Value = MPCF.MakeDateFormat(out_list.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.LOSS_COMMENT].Value = out_list.GetString("LOSS_COMMENT");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.CREATE_USER_ID].Value = out_list.GetString("CREATE_USER_ID");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(out_list.GetString("CREATE_TIME"), DATE_TIME_FORMAT.DATETIME);
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.UPDATE_USER_ID].Value = out_list.GetString("UPDATE_USER_ID");
                    spdScrap.ActiveSheet.Cells[i, (int)SCRAP_LIST.UPDATE_TIME].Value = MPCF.MakeDateFormat(out_list.GetString("UPDATE_TIME"), DATE_TIME_FORMAT.DATETIME);
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

                TRSNode in_node = new TRSNode("UPDATE_SCRAP_IN");
                TRSNode out_node = new TRSNode("UPDATE_SCRAP_OUT");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("LINE_ID", MPCF.Trim(cdvScrapLineID.Text));
                in_node.AddString("WORK_SHIFT", MPCF.Trim(cdvScrapShift.Text));

                if (dtpScrap.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpScrap.Value.ToString(), out dtpScrapDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpScrapDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                in_node.AddString("LOSS_OPER", MPCF.Trim(cdvScrapOper.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvScrapResID.Text));
                in_node.AddString("LOSS_TYPE", MPCF.Trim(cdvScrapCause.Text));
                in_node.AddDouble("LOSS_QTY", MPCF.Trim(txtScrapQty.Text));
                in_node.AddString("LOSS_COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCF.CallService("CWIP", "CWIP_Update_Scrap_List", in_node, ref out_node) == false)
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
