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
    public partial class frmCUSViewDailyWork : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        
        public enum DAILY_WORK_LIST
        {
            WORK_LINE,
            START_TIME,
            END_TIME,
            LEAD_TIME,
            LOSS_QTY,
            DEF_QTY,
            E10_TROUBLE_TYPE,
            TROUBLE_TYPE,
            E10_APPLY_FLAG,
            OPER,
            RES_GROUP,
            RESOURCE,
            RES_CONFIG,
            DETAIL_CATEGORY,
            WORK_SHIFT,
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

        public frmCUSViewDailyWork()
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
            dtpFromW.Value = DateTime.Today;

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
        /// View Button Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
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


        
        #endregion
        
        #region Functions


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

                if (cdvOper != null && cdvOper.Text != "")
                {
                    in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
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

                spdDailyWorkList.ActiveSheet.Columns[(int)DAILY_WORK_LIST.START_TIME].Width = 250F;
                spdDailyWorkList.ActiveSheet.Columns[(int)DAILY_WORK_LIST.END_TIME].Width = 250F;
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
                    work_list = in_node.AddNode("WORK_LIST");
                    work_list.AddString("LINE_ID", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.WORK_LINE].Text));
                    work_list.AddString("RES_ID", MPCF.Trim(spdDailyWorkList.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RESOURCE].Text));
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

                // Clear
                MPCF.FieldClear(pnlMiddleMargin, cdvWorkLineW);

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
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));

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



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvOper, false) == false)
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

        private void cdvWorkLineW_ValueChanged_1(object sender, EventArgs e)
        {
            cdvOper.Text = "";
            cdvResID.Text = "";
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
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

                cdvOper.Text = cdvOper.Show(cdvOper, "View Operation List", "CWIP", "CWIP_View_Operation_List", in_node, "LIST", display, header, "OPER");

                if (cdvOper.Text == null || cdvOper.Text == string.Empty)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOper_ValueChanged(object sender, EventArgs e)
        {
            cdvResID.Text = "";
        }


        
    }
}
