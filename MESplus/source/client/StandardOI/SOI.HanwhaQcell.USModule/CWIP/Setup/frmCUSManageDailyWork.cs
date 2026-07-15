using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSManageDailyWork : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        public enum E10_LIST
        {
            WORK_LINE,
            START_TIME,
            END_TIME,
            LEAD_TIME,
            LOSS_QTY,
            E10_TROUBLE_TYPE,
            RES_ID,
            RES_DESC
        }

        public enum DAILY_WORK_LIST
        {
            CHK,
            WORK_LINE,
            START_TIME,
            END_TIME,
            LEAD_TIME,
            LOSS_QTY,
            DEF_QTY,
            E10_TROUBLE_TYPE,
            E10_TROUBLE_TYPE_BTN,
            TROUBLE_TYPE,
            TROUBLE_TYPE_BTN,
            E10_APPLY_FLAG,
            E10_APPLY_FLAG_BTN,
            OPER,
            RES_GROUP,
            RESOURCE,
            RES_CONFIG,
            DETAIL_CATEGORY,
            WORK_SHIFT,
            WORK_SHIFT_BTN,
            CHARGE_USER,
            TROUBLE_STATUS,
            CAUSE_ANALYSIS,
            CORRECTIVE_MEASURE,
            CREATE_USER,
            CREATE_TIME,
            UPDATE_USER,
            UPDATE_TIME
        }

        #endregion

        #region Constructor

        public frmCUSManageDailyWork()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // Init
            dtpFromE.Value = DateTime.Today;
            dtpFromW.Value = DateTime.Today;
            txtStateTime.Text = "1";
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) 
                bIsShown = true;
            }
        }

        /// <summary>
        /// Work Line CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvWorkLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@LINE_CODE"));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvOperE.Text = cdvOperE.Show(cdvOperE, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Clear
                MPCF.FieldClear(pnlMiddleMargin, cdvOperE);

                // Validation
                if (string.IsNullOrEmpty(cdvOperE.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);                    
            }
        }

        /// <summary>
        /// Oper CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvOperation_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "OPER", "OPER_DESC" };
                string[] header = new string[] { "Oper", "Oper Desc" };

                // Show CodeView and Get Return
                //cdvOperation.Text = cdvOperation.Show(cdvOperation, "View Operation List", "WIP", "WIP_View_Operation_List", in_node, "LIST", display, header, "Oper");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Mat ID CodeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Display and Header Text Setup
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };
                string[] header = new string[] { "Mat ID", "Mat Desc" };

                // Show CodeView and Get Return
                //cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "View Material List", "WIP", "WIP_View_Material_List", in_node, "LIST", display, header, "Mat ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Excel Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ExportToExcel(spdE10TroubleList, this.Text, "", true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLineW, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvOperW, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return;
                }

                if (ViewDailyWorkList() == false)
                {
                    return;
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
                if (MPCF.CheckValue(cdvWorkLineE, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvOperE, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvResIDE, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(txtStateTime, false) == false)
                {
                    return;
                }

                if (ViewE10TroubleList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Include Res Id CheckBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkIncludeResource_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNotFinished.Checked == true)
                {
                    spdE10TroubleList.ActiveSheet.Columns[8].Visible = true;
                }
                else
                {
                    spdE10TroubleList.ActiveSheet.Columns[8].Visible = false;
                }

                if (ViewE10TroubleList() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion
        
        #region Functions

        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        private bool ViewE10TroubleList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_E0_TROUBLE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_E0_TROUBLE_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                DateTime dtpDateTimeOut = new DateTime();
                if (dtpFromE.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFromE.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (cdvWorkLineE != null && cdvWorkLineE.Text != "")
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineE.Text));
                }
                else
                {
                    in_node.AddString("LINE_ID", "%");
                }

                if (cdvOperE != null && cdvOperE.Text != "")
                {
                    in_node.AddString("OPER", MPCF.Trim(cdvOperE.Text));
                }
                else
                {
                    in_node.AddString("OPER", "%");
                }

                if (cdvResIDE != null && cdvResIDE.Text != "")
                {
                    in_node.AddString("RES_ID", MPCF.Trim(cdvResIDE.Text));
                }
                else
                {
                    in_node.AddString("RES_ID", "%");
                }

                if (MPCF.ToDbl(txtStateTime.Value) < 1)
                {
                    return false;
                }
                else
                {
                    in_node.AddDouble("LEAD_TIME", MPCF.ToDbl(txtStateTime.Value) * 60);
                }
                
                //if (chkNotFinished.Checked == true)
                //{
                //    in_node.AddChar("RES_FLAG", 'Y');
                //}

                if (MPCF.CallService("CRAS", "CRAS_View_Daily_Work_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Clear
                MPCF.ClearList(this.spdE10TroubleList);
                
                // Bind
                spdE10TroubleList.ActiveSheet.RowCount = out_node.GetList(0).Count;
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.WORK_LINE].Value = out_node.GetList(0)[i].GetString("LINE_ID");
                    //spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.WORK_LINE].Tag = out_node.GetList(0)[i].GetString("LINE_ID");
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")) == "")
                    {
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.START_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                    }
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("END_TIME")) == "")
                    {
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.END_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("END_TIME"));
                    }
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")) == "" || MPCF.Trim(out_node.GetList(0)[i].GetString("END_TIME")) == "")
                    {
                    }
                    else
                    {
                        DateTime ts1;
                        DateTime ts2;

                        DateTime.TryParse(spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.START_TIME].Text, out ts1);
                        DateTime.TryParse(spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.END_TIME].Text, out ts2);

                        TimeSpan ts = ts2 - ts1;
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.LEAD_TIME].Value = Math.Round(ts.TotalMinutes, 3);
                    }
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.LOSS_QTY].Value = 0;
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.E10_TROUBLE_TYPE].Tag = out_node.GetList(0)[i].GetString("E10_TROUBLE_TYPE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.E10_TROUBLE_TYPE].Value = out_node.GetList(0)[i].GetString("E10_TROUBLE_TYPE_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.RES_ID].Value = out_node.GetList(0)[i].GetString("RES_ID");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.RES_DESC].Value = out_node.GetList(0)[i].GetString("RES_DESC");
                }

                // Fit Column Hedaer
                MPCF.FitColumnHeader(spdE10TroubleList);


                spdE10TroubleList.ActiveSheet.Columns[(int)E10_LIST.START_TIME].Width = 250F;
                spdE10TroubleList.ActiveSheet.Columns[(int)E10_LIST.END_TIME].Width = 250F;

                lblSumQty_E.Text = spdE10TroubleList.ActiveSheet.RowCount.ToString();


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Resource
        /// </summary>
        /// <param name="sResId"></param>
        /// <returns></returns>
        private bool ViewResource(string sResId, int iRow)
        {
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_OUT");

            try
            {

                // Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", sResId);
                if (MPCF.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Bind
                spdDailyWorkList.ActiveSheet.Cells[iRow, (int)DAILY_WORK_LIST.RESOURCE].Value = MPCF.Trim(out_node.GetString("RES_ID"));
                spdDailyWorkList.ActiveSheet.Cells[iRow, (int)DAILY_WORK_LIST.RES_CONFIG].Value = MPCF.Trim(out_node.GetString("RES_DESC"));
                spdDailyWorkList.ActiveSheet.Cells[iRow, (int)DAILY_WORK_LIST.WORK_LINE].Value = MPCF.Trim(out_node.GetString("RES_CMF_1"));
                spdDailyWorkList.ActiveSheet.Cells[iRow, (int)DAILY_WORK_LIST.OPER].Value = MPCF.Trim(out_node.GetString("RES_CMF_2"));
                spdDailyWorkList.ActiveSheet.Cells[iRow, (int)DAILY_WORK_LIST.RES_GROUP].Value = MPCF.Trim(out_node.GetString("SUB_AREA_ID"));

                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// View Productivity
        /// </summary>
        /// <returns></returns>
        private bool ViewDailyWorkList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DAILY_WORK_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_DAILY_WORK_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                DateTime dtpDateTimeOut = new DateTime();
                if (dtpFromW.Value != null)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpFromW.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                    }
                }

                if (cdvWorkLineW != null && cdvWorkLineW.Text != "")
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineW.Text));
                }
                else
                {
                    in_node.AddString("LINE_ID", "%");
                }

                if (cdvOperW != null && cdvOperW.Text != "")
                {
                    in_node.AddString("OPER", MPCF.Trim(cdvOperW.Text));
                }
                else
                {
                    in_node.AddString("OPER", "%");
                }

                if (cdvResID != null && cdvResID.Text != "")
                {
                    in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                }
                else
                {
                    in_node.AddString("RES_ID", "%");
                }

                if (cdvE10TroubleType != null && cdvE10TroubleType.Text != "")
                {
                    in_node.AddString("EQ_STATUS_CODE", MPCF.Trim(cdvE10TroubleType.Text));
                }
                else
                {
                    in_node.AddString("EQ_STATUS_CODE", "%");
                }

                if (cdvTroubleType != null && cdvTroubleType.Text != "")
                {
                    in_node.AddString("EQ_TROUBLE_CODE", MPCF.Trim(cdvTroubleType.Text));
                }
                else
                {
                    in_node.AddString("EQ_TROUBLE_CODE", "%");
                }

                if (chkNotFinished.Checked == true)
                {
                    in_node.AddString("END_FLAG", "N");
                }
                else
                {
                    in_node.AddString("END_FLAG", "%");
                }

                if (MPCF.CallService("CRAS", "CRAS_View_Daily_Work_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Clear
                MPCF.ClearList(this.spdDailyWorkList);
                
                // Bind
                spdDailyWorkList.ActiveSheet.RowCount = out_node.GetList(0).Count;
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.WORK_LINE].Tag = out_node.GetList(0)[i].GetInt("SEQ_NUM");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.WORK_LINE].Value = out_node.GetList(0)[i].GetString("LINE_ID");
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("START_TIME")) == "")
                    {
                    }
                    else
                    {
                        spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.START_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("START_TIME"));
                    }
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("END_TIME")) == "")
                    {
                    }
                    else
                    {
                        spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.END_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("END_TIME"));
                    }
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("START_TIME")) == "" || MPCF.Trim(out_node.GetList(0)[i].GetString("END_TIME")) == "")
                    {
                    }
                    else
                    {
                        DateTime ts1;
                        DateTime ts2;

                        DateTime.TryParse(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.START_TIME].Text, out ts1);
                        DateTime.TryParse(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.END_TIME].Text, out ts2);

                        TimeSpan ts = ts2 - ts1;
                        spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.LEAD_TIME].Value = Math.Round(ts.TotalMinutes, 3);
                    }
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.LOSS_QTY].Value = out_node.GetList(0)[i].GetDouble("LOSS_QTY");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.DEF_QTY].Value = out_node.GetList(0)[i].GetDouble("DEFECT_QTY");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.E10_TROUBLE_TYPE].Tag = out_node.GetList(0)[i].GetString("EQ_STATUS_CODE");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.E10_TROUBLE_TYPE].Value = out_node.GetList(0)[i].GetString("EQ_STATUS_DESC");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.TROUBLE_TYPE].Tag = out_node.GetList(0)[i].GetString("EQ_TROUBLE_CODE");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.TROUBLE_TYPE].Value = out_node.GetList(0)[i].GetString("EQ_TROUBLE_DESC");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.E10_APPLY_FLAG].Value = out_node.GetList(0)[i].GetChar("EQ_STATUS_FLAG");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.OPER].Value = out_node.GetList(0)[i].GetString("OPER");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RES_GROUP].Value = out_node.GetList(0)[i].GetString("RES_GROUP");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RESOURCE].Value = out_node.GetList(0)[i].GetString("RES_ID");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RES_CONFIG].Value = out_node.GetList(0)[i].GetString("RES_CONFIGURE");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.DETAIL_CATEGORY].Value = out_node.GetList(0)[i].GetString("DETAIL_CATEGORY");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.WORK_SHIFT].Value = out_node.GetList(0)[i].GetChar("WORK_SHIFT");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHARGE_USER].Tag = out_node.GetList(0)[i].GetString("CHARGE_USER_ID");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHARGE_USER].Value = out_node.GetList(0)[i].GetString("CHARGE_USER_DESC");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.TROUBLE_STATUS].Value = out_node.GetList(0)[i].GetString("TROUBLE_STATUS");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CAUSE_ANALYSIS].Value = out_node.GetList(0)[i].GetString("CAUSE_ANALYSIS");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CORRECTIVE_MEASURE].Value = out_node.GetList(0)[i].GetString("CORRECTIVE_MEASURE");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CREATE_USER].Tag = out_node.GetList(0)[i].GetString("CREATE_USER");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CREATE_USER].Value = out_node.GetList(0)[i].GetString("CREATE_USER_DESC");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CREATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"), DATE_TIME_FORMAT.DATETIME);
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.UPDATE_USER].Tag = out_node.GetList(0)[i].GetString("UPDATE_USER");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.UPDATE_USER].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_DESC");
                    spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.UPDATE_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"), DATE_TIME_FORMAT.DATETIME);
                }

                // Fit Column Hedaer
                MPCF.FitColumnHeader(spdDailyWorkList);

                spdDailyWorkList.ActiveSheet.Columns[(int)DAILY_WORK_LIST.E10_APPLY_FLAG_BTN].Width = 40F;
                spdDailyWorkList.ActiveSheet.Columns[(int)DAILY_WORK_LIST.E10_TROUBLE_TYPE_BTN].Width = 40F;
                spdDailyWorkList.ActiveSheet.Columns[(int)DAILY_WORK_LIST.TROUBLE_TYPE_BTN].Width = 40F;
                spdDailyWorkList.ActiveSheet.Columns[(int)DAILY_WORK_LIST.WORK_SHIFT_BTN].Width = 40F;
                spdDailyWorkList.ActiveSheet.Columns[(int)DAILY_WORK_LIST.START_TIME].Width = 250F;
                spdDailyWorkList.ActiveSheet.Columns[(int)DAILY_WORK_LIST.END_TIME].Width = 250F;
                spdDailyWorkList.ActiveSheet.Columns[(int)DAILY_WORK_LIST.CHK].Width = 40F;
                lblSumQty_W.Text = spdDailyWorkList.ActiveSheet.RowCount.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// User 정보 조회
        /// </summary>
        /// <param name="sUserId"></param>
        /// <returns></returns>
        public string ViewUserInfo(string sUserId)
        {
            TRSNode in_node = new TRSNode("VIEW_USER_IN");
            TRSNode out_node = new TRSNode("VIEW_USER_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("USER_ID", sUserId);

                if (MPCF.CallService("SEC", "SEC_View_User", in_node, ref out_node) == false)
                {
                    return "";
                }


                return out_node.GetString("USER_DESC");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, true);
                return "";
            }
        }

        private bool Update_Daily_Work_List()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode work_list = null;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                
                in_node.AddString("FACTORY", MPGV.gsFactory);
                for (int i = 0; i < spdDailyWorkList.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHK].Value) == true)
                    {
                        work_list = in_node.AddNode("WORK_LIST");
                        work_list.AddString("LINE_ID", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.WORK_LINE].Text));
                        work_list.AddString("RES_ID", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RESOURCE].Text));
                        DateTime dtpDateTimeOut = new DateTime();
                        bool bTrySuccess = DateTime.TryParse(dtpFromW.Value.ToString(), out dtpDateTimeOut);
                        if (bTrySuccess == true)
                        {
                            work_list.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                        }
                        work_list.AddString("START_TIME", MPCF.Trim(DateTime.Parse(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.START_TIME].Value.ToString()).ToString("yyyyMMddHHmmss")));
                        if (spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.WORK_LINE].Tag == null)
                        {
                            work_list.AddInt("SEQ_NUM", 0);
                        }
                        else
                        {
                            work_list.AddInt("SEQ_NUM", MPCF.ToInt(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.WORK_LINE].Tag));
                        }
                        if (spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.END_TIME].Value == null || spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.END_TIME].Value.ToString() == "")
                        {
                            work_list.AddString("END_FLAG", "N");
                        }
                        else
                        {
                            work_list.AddString("END_FLAG", "Y");
                            work_list.AddString("END_TIME", MPCF.Trim(DateTime.Parse(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.END_TIME].Value.ToString()).ToString("yyyyMMddHHmmss")));
                        }
                        work_list.AddDouble("STATE_TIME", MPCF.ToDbl(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.LEAD_TIME].Value));
                        work_list.AddDouble("LOSS_QTY", MPCF.ToDbl(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.LOSS_QTY].Value));
                        work_list.AddDouble("DEFECT_QTY", MPCF.ToDbl(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.DEF_QTY].Value));
                        if (spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.E10_TROUBLE_TYPE].Tag == null || MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.E10_TROUBLE_TYPE].Tag.ToString()) == "")
                        {
                        }
                        else
                        {
                            work_list.AddString("EQ_STATUS_CODE", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.E10_TROUBLE_TYPE].Tag.ToString()));
                        }
                        work_list.AddString("EQ_STATUS_FLAG", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.E10_APPLY_FLAG].Text));
                        if (spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.TROUBLE_TYPE].Tag == null || MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.TROUBLE_TYPE].Tag.ToString()) == "")
                        {
                        }
                        else
                        {
                            work_list.AddString("EQ_TROUBLE_CODE", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.TROUBLE_TYPE].Tag.ToString()));
                        }
                        work_list.AddString("OPER", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.OPER].Text));
                        work_list.AddString("WORK_SHIFT", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.WORK_SHIFT].Text));
                        work_list.AddString("RES_GROUP", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RES_GROUP].Text));
                        work_list.AddString("RES_CONFIGURE", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RES_CONFIG].Text));
                        work_list.AddString("DETAIL_CATEGORY", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.DETAIL_CATEGORY].Text));
                        work_list.AddString("CHARGE_USER_ID", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHARGE_USER].Tag.ToString()));
                        work_list.AddString("TROUBLE_STATUS", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.TROUBLE_STATUS].Text));
                        work_list.AddString("CAUSE_ANALYSIS", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CAUSE_ANALYSIS].Text));
                        work_list.AddString("CORRECTIVE_MEASURE", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CORRECTIVE_MEASURE].Text));
                    }
                }

                if (MPCF.CallService("CRAS", "CRAS_Multi_Update_Daily_Work_List", in_node, ref out_node) == false)
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

        private bool Delete_Daily_Work_List()
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");
            TRSNode work_list = null;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';

                in_node.AddString("FACTORY", MPGV.gsFactory);
                for (int i = 0; i < spdDailyWorkList.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHK].Value) == true)
                    {
                        work_list = in_node.AddNode("WORK_LIST");
                        work_list.AddString("LINE_ID", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.WORK_LINE].Text));
                        work_list.AddString("RES_ID", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RESOURCE].Text));
                        DateTime dtpDateTimeOut = new DateTime();
                        bool bTrySuccess = DateTime.TryParse(dtpFromW.Value.ToString(), out dtpDateTimeOut);
                        if (bTrySuccess == true)
                        {
                            work_list.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                        }
                        work_list.AddInt("SEQ_NUM", MPCF.ToInt(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.WORK_LINE].Tag));
                    }
                }

                if (MPCF.CallService("CRAS", "CRAS_Multi_Update_Daily_Work_List", in_node, ref out_node) == false)
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

        private void cdvWorkLineE_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@LINE_CODE"));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvWorkLineE.Text = cdvWorkLineE.Show(cdvWorkLineE, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLineE.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvWorkLineW_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim("@LINE_CODE"));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvWorkLineW.Text = cdvWorkLineW.Show(cdvWorkLineW, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");


                // Validation
                if (string.IsNullOrEmpty(cdvWorkLineW.Text) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineW.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvOperW.Text));

                string[] header = new string[] { "Resource", "Description" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                //cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "RES_ID");
                cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvResID.Text) == true)
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

        private void cdvE10TroubleType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_EQ_STATUS));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_3" };

                cdvE10TroubleType.Text = cdvE10TroubleType.Show(cdvE10TroubleType, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvE10TroubleType.Text) == true)
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

        private void cdvTroubleType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_EQ_TROUBLE));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_3" };

                cdvTroubleType.Text = cdvTroubleType.Show(cdvTroubleType, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvTroubleType.Text) == true)
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

        private void spdDailyWorkList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.ColumnHeader && e.Column == (int)DAILY_WORK_LIST.CHK)
                {
                    //전체 헤더 선택
                    string s_hChk = string.Empty;

                    if (spdDailyWorkList.Sheets[0].ColumnHeader.Cells[0, 0].Text == "True")
                    {
                        s_hChk = "False";
                    }
                    else
                    {
                        s_hChk = "True";
                    }

                    spdDailyWorkList.Sheets[0].ColumnHeader.Cells[0, 0].Text = s_hChk;

                    for (int i = 0; i < spdDailyWorkList.Sheets[0].Rows.Count; i++)
                    {
                        spdDailyWorkList.Sheets[0].Cells[i, 0].Text = s_hChk;
                    }
                }
                else if (e.Column == (int)DAILY_WORK_LIST.END_TIME)
                {
                    if (spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.END_TIME].Value == null || MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.END_TIME].Value.ToString()) == "")
                    {
                        spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.END_TIME].Value = DateTime.Now;

                        DateTime ts1;
                        DateTime ts2;

                        DateTime.TryParse(spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.START_TIME].Text, out ts1);
                        DateTime.TryParse(spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.END_TIME].Text, out ts2);

                        TimeSpan ts = ts2 - ts1;
                        spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.LEAD_TIME].Value = Math.Round(ts.TotalMinutes, 3);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLineW, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvOperW, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return;
                }

                spdDailyWorkList.ActiveSheet.AddRows(spdDailyWorkList.ActiveSheet.RowCount,1);
                spdDailyWorkList.ActiveSheet.Cells[spdDailyWorkList.ActiveSheet.RowCount - 1, (int)DAILY_WORK_LIST.CHK].Value = true;
                spdDailyWorkList.ActiveSheet.Cells[spdDailyWorkList.ActiveSheet.RowCount - 1, (int)DAILY_WORK_LIST.CHARGE_USER].Tag = MPGV.gsUserID;
                spdDailyWorkList.ActiveSheet.Cells[spdDailyWorkList.ActiveSheet.RowCount - 1, (int)DAILY_WORK_LIST.CHARGE_USER].Value = ViewUserInfo(MPGV.gsUserID);
                spdDailyWorkList.ActiveSheet.Cells[spdDailyWorkList.ActiveSheet.RowCount - 1, (int)DAILY_WORK_LIST.START_TIME].Value = System.DateTime.Now;
                //spdDailyWorkList.ActiveSheet.Cells[spdDailyWorkList.ActiveSheet.RowCount - 1, (int)DAILY_WORK_LIST.END_TIME].Value = System.DateTime.Now;
                spdDailyWorkList.ActiveSheet.Cells[spdDailyWorkList.ActiveSheet.RowCount - 1, (int)DAILY_WORK_LIST.LEAD_TIME].Value = 0;
                ViewResource(MPCF.Trim(cdvResID.Text), spdDailyWorkList.ActiveSheet.RowCount - 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                spdDailyWorkList.ActiveSheet.Rows.Remove(spdDailyWorkList.ActiveSheet.RowCount -1, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void spdDailyWorkList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                
                if (e.Column == (int)DAILY_WORK_LIST.WORK_SHIFT_BTN)
                {
                    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_SHIFT));

                    string[] header = new string[] { "Shift", "Description" };
                    string[] display = new string[] { "KEY_1", "DATA_1" };

                    cdvData_1.Text = cdvData_1.Show(cdvData_1, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
                    if (MPCF.Trim(cdvData_1.Text) != "")
                    {
                        if (cdvData_1.returnDatas != null && cdvData_1.returnDatas.Count > 0)
                        {
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData_1.returnDatas[0];
                        }
                        else
                        {
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                        }
                    }
                    else
                    {
                        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                    }

                }
                else if (e.Column == (int)DAILY_WORK_LIST.TROUBLE_TYPE_BTN)
                {
                    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_EQ_TROUBLE));

                    string[] header = new string[] { "Code", "Description" };
                    string[] display = new string[] { "KEY_1", "DATA_3" };

                    cdvData_2.Text = cdvData_2.Show(cdvData_2, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
                    if (MPCF.Trim(cdvData_2.Text) != "")
                    {
                        if (cdvData_2.returnDatas != null && cdvData_2.returnDatas.Count > 0)
                        {
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = cdvData_2.returnDatas[0];
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData_2.returnDatas[1];
                        }
                        else
                        {
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                        }
                    }
                    else
                    {
                        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                    }

                }
                else if (e.Column == (int)DAILY_WORK_LIST.E10_TROUBLE_TYPE_BTN)
                {
                    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_EQ_STATUS));

                    string[] header = new string[] { "Code", "Description" };
                    string[] display = new string[] { "KEY_1", "DATA_3" };

                    cdvData_3.Text = cdvData_3.Show(cdvData_3, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
                    if (MPCF.Trim(cdvData_3.Text) != "")
                    {
                        if (cdvData_3.returnDatas != null && cdvData_3.returnDatas.Count > 0)
                        {
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = cdvData_3.returnDatas[0];
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData_3.returnDatas[1];
                        }
                        else
                        {
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                        }
                    }
                    else
                    {
                        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                    }

                }
                else if (e.Column == (int)DAILY_WORK_LIST.E10_APPLY_FLAG_BTN)
                {
                    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("TABLE_NAME", "YESNO");

                    string[] header = new string[] { "Code", "Description" };
                    string[] display = new string[] { "KEY_1", "DATA_1" };

                    cdvData_4.Text = cdvData_4.Show(cdvData_4, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
                    if (MPCF.Trim(cdvData_4.Text) != "")
                    {
                        if (cdvData_4.returnDatas != null && cdvData_4.returnDatas.Count > 0)
                        {
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData_4.returnDatas[0];
                        }
                        else
                        {
                            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                        }
                    }
                    else
                    {
                        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                    }

                }
                


                //if (e.Column == (int)DAILY_WORK_LIST.WORK_LINE_BTN)
                //{
                //    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                //    MPCF.SetInMsg(in_node);
                //    in_node.ProcStep = '1';
                //    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                //    in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                //    string[] header = new string[] { "Line Code", "Description" };
                //    string[] display = new string[] { "KEY_1", "DATA_1" };

                //    cdvData.Text = cdvData.Show(cdvData, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");
                //    if (MPCF.Trim(cdvData.Text) != "")
                //    {
                //        if (cdvData.returnDatas != null && cdvData.returnDatas.Count > 0)
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = cdvData.returnDatas[0];
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData.returnDatas[1];
                //        }
                //        else
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                //        }
                //    }
                //    else
                //    {
                //        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                //        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                //    }
                    
                //}
                //else if (e.Column == (int)DAILY_WORK_LIST.RESOURCE_BTN)
                //{
                //    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                //    MPCF.SetInMsg(in_node);
                //    in_node.ProcStep = '6';
                //    in_node.AddString("LINE_ID", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.WORK_LINE].Tag.ToString()));
                //    in_node.AddString("OPER", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.OPER].Tag.ToString()));
                //    in_node.AddString("SUB_AREA_ID", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.RES_GROUP].Tag.ToString()));

                //    // Display and Header Text Setup
                //    string[] header = new string[] { "Equip ID", "Equip Desc" };
                //    string[] display = new string[] { "RES_ID", "RES_DESC" };

                //    // Show CodeView and Get Return
                //    cdvData.Text = cdvData.Show(cdvData, "View Resource List", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");
                //    if (MPCF.Trim(cdvData.Text) != "")
                //    {
                //        if (cdvData.returnDatas != null && cdvData.returnDatas.Count > 0)
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = cdvData.returnDatas[0];
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData.returnDatas[1];
                //        }
                //        else
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                //        }
                //    }
                //    else
                //    {
                //        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                //        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                //    }

                //}
                //else if (e.Column == (int)DAILY_WORK_LIST.RES_GROUP_BTN)
                //{
                //    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                //    MPCF.SetInMsg(in_node);
                //    in_node.ProcStep = '5';
                //    in_node.AddString("LINE_ID", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.WORK_LINE].Tag.ToString()));
                //    in_node.AddString("OPER", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.OPER].Tag.ToString()));

                //    // Display and Header Text Setup
                //    string[] header = new string[] { "Equip Group ID", "Equip Group Desc" };
                //    string[] display = new string[] { "SUB_AREA_ID", "SUB_AREA_DESC" };

                //    // Show CodeView and Get Return
                //    cdvData.Text = cdvData.Show(cdvData, "View Resource Group List", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "SUB_AREA_ID");
                //    if (MPCF.Trim(cdvData.Text) != "")
                //    {
                //        if (cdvData.returnDatas != null && cdvData.returnDatas.Count > 0)
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = cdvData.returnDatas[0];
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData.returnDatas[1];
                //        }
                //        else
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                //        }
                //    }
                //    else
                //    {
                //        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                //        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                //    }

                //}

                //else if (e.Column == (int)DAILY_WORK_LIST.OPER_BTN)
                //{
                //    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                //    MPCF.SetInMsg(in_node);
                //    in_node.ProcStep = '1';
                //    in_node.AddString("LINE_ID", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[e.Row, (int)DAILY_WORK_LIST.WORK_LINE].Tag.ToString()));

                //    string[] header = new string[] { "Oper", "Description" };
                //    string[] display = new string[] { "OPER", "OPER_DESC" };

                //    cdvData.Text = cdvData.Show(cdvData, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");
                //    if (MPCF.Trim(cdvData.Text) != "")
                //    {
                //        if (cdvData.returnDatas != null && cdvData.returnDatas.Count > 0)
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = cdvData.returnDatas[0];
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData.returnDatas[1];
                //        }
                //        else
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                //        }
                //    }
                //    else
                //    {
                //        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                //        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                //    }

                //}
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void spdDailyWorkList_EditModeOff(object sender, EventArgs e)
        {
            int i_column = 0;
            int i_row = 0;
            try
            {
                i_column = spdDailyWorkList.ActiveSheet.ActiveColumnIndex;
                i_row = spdDailyWorkList.ActiveSheet.ActiveRowIndex;
                if (i_column == (int)DAILY_WORK_LIST.START_TIME || i_column == (int)DAILY_WORK_LIST.END_TIME)
                {
                    DateTime ts1;
                    DateTime ts2;

                    DateTime.TryParse(spdDailyWorkList.ActiveSheet.Cells[i_row, (int)DAILY_WORK_LIST.START_TIME].Text, out ts1);
                    DateTime.TryParse(spdDailyWorkList.ActiveSheet.Cells[i_row, (int)DAILY_WORK_LIST.END_TIME].Text, out ts2);
                    
                    TimeSpan ts = ts2 - ts1;
                    spdDailyWorkList.ActiveSheet.Cells[i_row, (int)DAILY_WORK_LIST.LEAD_TIME].Value = Math.Round(ts.TotalMinutes,3);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLineW, false) == false)
                {
                    return;
                }
                if (MPCF.CheckValue(cdvOperW, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return;
                }

                if (spdDailyWorkList.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(536), MSG_LEVEL.ERROR, false);
                    return;
                }

                if (Update_Daily_Work_List() == false)
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvWorkLineW_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cdvResID_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                spdDailyWorkList.ActiveSheet.RowCount = 0;

                btnProcess.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void dtpFromW_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                spdDailyWorkList.ActiveSheet.RowCount = 0;

                cdvOperW.Text = "";
                cdvResID.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvOperW, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvResID, false) == false)
                {
                    return;
                }

                if (spdDailyWorkList.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(536), MSG_LEVEL.ERROR, false);
                    return;
                }

                if (Delete_Daily_Work_List() == false)
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void btnToExcelW_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ExportToExcel(spdDailyWorkList, this.Text, "", true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineE.Text));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOperE.Text = cdvOperE.Show(cdvOperE, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvOperE.Text == null || cdvOperE.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvResIDE_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineE.Text));
                in_node.AddString("OPER", cdvOperE.Text);

                string[] header = new string[] { "Resource", "Description" };
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                //cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "RES_ID");
                cdvResIDE.Text = cdvResIDE.Show(cdvResIDE, "Resource ID", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvResIDE.Text) == true)
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

        private void cdvWorkLineE_ValueChanged(object sender, EventArgs e)
        {
            cdvOperE.Text = "";
            cdvResIDE.Text = "";
        }

        private void cdvOperE_ValueChanged(object sender, EventArgs e)
        {
            cdvResIDE.Text = "";
        }

        private void cdvResIDE_ValueChanged(object sender, EventArgs e)
        {
            btnView.PerformClick();
        }

        private void cdvWorkLineW_ValueChanged_1(object sender, EventArgs e)
        {
            cdvOperW.Text = "";
            cdvResID.Text = "";
        }

        private void cdvOperW_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineW.Text));

                string[] header = new string[] { "Oper", "Description" };
                string[] display = new string[] { "OPER", "OPER_DESC" };

                cdvOperW.Text = cdvOperW.Show(cdvOperW, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvOperW.Text == null || cdvOperW.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOperW_ValueChanged(object sender, EventArgs e)
        {
            cdvResID.Text = "";
        }

        
    }
}
