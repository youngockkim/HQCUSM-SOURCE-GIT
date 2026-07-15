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
    public partial class frmCUSManagePatrolCheck : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        public enum PATROL_CHK
        {
            CODE,
            NAME,
            DESC
        }

        public enum DAILY_WORK_LIST
        {
            CHK,
            RES_ID,
            RES_BTN,
            RES_DESC,
            SEQ_NUM,
            OPER_POINT,
            CHECK_CODE,
            CHECK_BTN,
            CHECK_DESC,
            FE_USER,
            BE_USER
        }

        #endregion

        #region Constructor

        public frmCUSManagePatrolCheck()
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

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            if (ViewPatrolCheckList() == false)
            {
                return;
            }
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

                cdvWorkLine.Text = cdvWorkLine.Show(cdvWorkLine, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Clear
                MPCF.FieldClear(pnlMiddleMargin, cdvWorkLine);

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLine.Text) == true)
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
                if (MPCF.ExportToExcel(spdPatrolCheck, this.Text, "", true, true, true, -1, -1) == false)
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
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
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
                if (MPCF.CheckValue(cdvOper, false) == false)
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
                //TRSNode in_node = new TRSNode("VIEW_E0_TROUBLE_LIST_IN");
                //TRSNode out_node = new TRSNode("VIEW_E0_TROUBLE_LIST_OUT");

                ////  Call Service
                //MPCF.SetInMsg(in_node);
                //in_node.ProcStep = '1';
                //in_node.AddString("FACTORY", MPGV.gsFactory);
                //DateTime dtpDateTimeOut = new DateTime();
                //if (dtpFromE.Value != null)
                //{
                //    bool bTrySuccess = DateTime.TryParse(dtpFromE.Value.ToString(), out dtpDateTimeOut);
                //    if (bTrySuccess == true)
                //    {
                //        in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                //    }
                //}

                //if (cdvWorkLine != null && cdvWorkLine.Text != "")
                //{
                //    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLine.Text));
                //}
                //else
                //{
                //    in_node.AddString("LINE_ID", "%");
                //}
                
                ////if (chkNotFinished.Checked == true)
                ////{
                ////    in_node.AddChar("RES_FLAG", 'Y');
                ////}

                //if (MPCF.CallService("CRAS", "CRAS_View_Daily_Work_List", in_node, ref out_node) == false)
                //{
                //    return false;
                //}

                //// Clear
                //MPCF.ClearList(this.spdPatrolCheck);
                
                //// Bind
                //spdPatrolCheck.ActiveSheet.RowCount = out_node.GetList(0).Count;
                //for (int i = 0; i < out_node.GetList(0).Count; i++)
                //{

                //    spdPatrolCheck.ActiveSheet.Cells[i, (int)E10_LIST.WORK_LINE].Value = out_node.GetList(0)[i].GetString("LINE_ID");
                //    //spdE10TroubleList.ActiveSheet.Cells[i, (int)E10_LIST.WORK_LINE].Tag = out_node.GetList(0)[i].GetString("LINE_ID");
                //    if (MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")) == "")
                //    {
                //    }
                //    else
                //    {
                //        spdPatrolCheck.ActiveSheet.Cells[i, (int)E10_LIST.START_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("TRAN_TIME"));
                //    }
                //    if (MPCF.Trim(out_node.GetList(0)[i].GetString("END_TIME")) == "")
                //    {
                //    }
                //    else
                //    {
                //        spdPatrolCheck.ActiveSheet.Cells[i, (int)E10_LIST.END_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("END_TIME"));
                //    }
                //    if (MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")) == "" || MPCF.Trim(out_node.GetList(0)[i].GetString("END_TIME")) == "")
                //    {
                //    }
                //    else
                //    {
                //        DateTime ts1;
                //        DateTime ts2;

                //        DateTime.TryParse(spdPatrolCheck.ActiveSheet.Cells[i, (int)E10_LIST.START_TIME].Text, out ts1);
                //        DateTime.TryParse(spdPatrolCheck.ActiveSheet.Cells[i, (int)E10_LIST.END_TIME].Text, out ts2);

                //        TimeSpan ts = ts2 - ts1;
                //        spdPatrolCheck.ActiveSheet.Cells[i, (int)E10_LIST.LEAD_TIME].Value = Math.Round(ts.TotalMinutes, 3);
                //    }
                //    spdPatrolCheck.ActiveSheet.Cells[i, (int)E10_LIST.LOSS_QTY].Value = 0;
                //    spdPatrolCheck.ActiveSheet.Cells[i, (int)E10_LIST.E10_TROUBLE_TYPE].Tag = out_node.GetList(0)[i].GetString("E10_TROUBLE_TYPE");
                //    spdPatrolCheck.ActiveSheet.Cells[i, (int)E10_LIST.E10_TROUBLE_TYPE].Value = out_node.GetList(0)[i].GetString("E10_TROUBLE_TYPE_DESC");
                //    spdPatrolCheck.ActiveSheet.Cells[i, (int)E10_LIST.RES_ID].Value = out_node.GetList(0)[i].GetString("RES_ID");
                //    spdPatrolCheck.ActiveSheet.Cells[i, (int)E10_LIST.RES_DESC].Value = out_node.GetList(0)[i].GetString("RES_DESC");
                //}

                //// Fit Column Hedaer
                //MPCF.FitColumnHeader(spdPatrolCheck);


                //spdPatrolCheck.ActiveSheet.Columns[(int)E10_LIST.START_TIME].Width = 250F;
                //spdPatrolCheck.ActiveSheet.Columns[(int)E10_LIST.END_TIME].Width = 250F;



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

                if (cdvWorkLine != null && cdvWorkLine.Text != "")
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLine.Text));
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


                if (MPCF.CallService("CRAS", "CRAS_View_Patrol_Check_Sheet", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                // Clear
                MPCF.ClearList(this.spdPatrolCheckSheet);

                // Bind
                spdPatrolCheckSheet.ActiveSheet.RowCount = out_node.GetList(0).Count;
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RES_ID].Value = out_node.GetList(0)[i].GetString("RES_ID");
                    spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RES_DESC].Value = out_node.GetList(0)[i].GetString("RES_DESC");
                    spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.SEQ_NUM].Value = out_node.GetList(0)[i].GetInt("SEQ_NUM");
                    spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.OPER_POINT].Value = out_node.GetList(0)[i].GetString("OPERATION_POINT");
                    spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHECK_CODE].Tag = out_node.GetList(0)[i].GetString("PTR_CHECK_POINT");
                    spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHECK_CODE].Value = out_node.GetList(0)[i].GetString("PTR_CHECK_POINT_NAME");
                    spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHECK_DESC].Value = out_node.GetList(0)[i].GetString("PTR_CHECK_POINT_DESC");
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("FRONT_END_USER_ID")) == "")
                    {
                    }
                    else
                    {
                        spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.FE_USER].Tag = out_node.GetList(0)[i].GetString("FRONT_END_USER_ID");
                        spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.FE_USER].Value = out_node.GetList(0)[i].GetString("FRONT_END_USER_DESC");
                    }
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("BACK_END_USER_ID")) == "")
                    {
                    }
                    else
                    {
                        spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.BE_USER].Tag = out_node.GetList(0)[i].GetString("BACK_END_USER_ID");
                        spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.BE_USER].Value = out_node.GetList(0)[i].GetString("BACK_END_USER_DESC");
                    }
                }

                // Fit Column Hedaer
                MPCF.FitColumnHeader(spdPatrolCheckSheet);

                spdPatrolCheckSheet.ActiveSheet.Columns[(int)DAILY_WORK_LIST.OPER_POINT].Width = 40F;
                spdPatrolCheckSheet.ActiveSheet.Columns[(int)DAILY_WORK_LIST.CHECK_BTN].Width = 40F;
                spdPatrolCheckSheet.ActiveSheet.Columns[(int)DAILY_WORK_LIST.CHK].Width = 40F;
                lblSumQty_W.Text = spdPatrolCheckSheet.ActiveSheet.RowCount.ToString();

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
        private bool ViewPatrolCheckList()
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_DAILY_WORK_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_DAILY_WORK_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("TABLE_NAME", HQGC.GCM_PATROL_CHECK);

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                // Clear
                MPCF.ClearList(this.spdPatrolCheck);

                // Bind
                spdPatrolCheck.ActiveSheet.RowCount = out_node.GetList(0).Count;
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdPatrolCheck.ActiveSheet.Cells[i, (int)PATROL_CHK.CODE].Value = out_node.GetList(0)[i].GetString("KEY_1");
                    spdPatrolCheck.ActiveSheet.Cells[i, (int)PATROL_CHK.NAME].Value = out_node.GetList(0)[i].GetString("DATA_1");
                    spdPatrolCheck.ActiveSheet.Cells[i, (int)PATROL_CHK.DESC].Value = out_node.GetList(0)[i].GetString("DATA_2");
                }

                // Fit Column Hedaer
                MPCF.FitColumnHeader(spdPatrolCheck);

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
                for (int i = 0; i < spdPatrolCheckSheet.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHK].Value) == true)
                    {
                        
                        work_list = in_node.AddNode("WORK_LIST");
                        work_list.AddString("LINE_ID", MPCF.Trim(cdvWorkLine.Text));
                        work_list.AddString("OPER", MPCF.Trim(cdvOper.Text));
                        DateTime dtpDateTimeOut = new DateTime();
                        bool bTrySuccess = DateTime.TryParse(dtpFromE.Value.ToString(), out dtpDateTimeOut);
                        if (bTrySuccess == true)
                        {
                            work_list.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                        }
                        if (MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RES_ID].Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(544), MSG_LEVEL.ERROR, false);
                            return false;
                        }
                        else
                        {
                            work_list.AddString("RES_ID", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RES_ID].Text));
                        }
                        if (spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.SEQ_NUM].Text == null || MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.SEQ_NUM].Text) == "")
                        {
                            work_list.AddInt("SEQ_NUM", 0);
                        }
                        else
                        {
                            work_list.AddInt("SEQ_NUM", MPCF.ToInt(spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.SEQ_NUM].Text));
                        }
                        if (spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHECK_CODE].Tag == null || MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHECK_CODE].Tag.ToString()) == "")
                        {
                        }
                        else
                        {
                            work_list.AddString("PTR_CHECK_POINT", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHECK_CODE].Tag.ToString()));
                        }
                        work_list.AddString("OPERATION_POINT", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.OPER_POINT].Text));

                        if (MPCF.Trim(cdvFEUser.Text) == "")
                        {
                        }
                        else
                        {
                            work_list.AddString("FRONT_END_USER_ID", MPCF.Trim(cdvFEUser.Text));
                        }

                        if (MPCF.Trim(cdvBEUser.Text) == "")
                        {
                        }
                        else
                        {
                            work_list.AddString("BACK_END_USER_ID", MPCF.Trim(cdvBEUser.Text));
                        }
                    }
                }

                if (MPCF.CallService("CRAS", "CRAS_Multi_Update_Patrol_Check_Sheet", in_node, ref out_node) == false)
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
                for (int i = 0; i < spdPatrolCheckSheet.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.CHK].Value) == true)
                    {
                        work_list = in_node.AddNode("WORK_LIST");
                        work_list.AddString("LINE_ID", MPCF.Trim(cdvOper.Text));
                        work_list.AddString("RES_ID", MPCF.Trim(spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.RES_ID].Text));
                        DateTime dtpDateTimeOut = new DateTime();
                        bool bTrySuccess = DateTime.TryParse(dtpFromE.Value.ToString(), out dtpDateTimeOut);
                        if (bTrySuccess == true)
                        {
                            work_list.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                        }
                        work_list.AddInt("SEQ_NUM", MPCF.ToInt(spdPatrolCheckSheet.ActiveSheet.Cells[i, (int)DAILY_WORK_LIST.SEQ_NUM].Text));
                    }
                }

                if (MPCF.CallService("CRAS", "CRAS_Multi_Update_Patrol_Check_Sheet", in_node, ref out_node) == false)
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

        }



        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvOper, false) == false)
                {
                    return;
                }

                spdPatrolCheckSheet.ActiveSheet.AddRows(spdPatrolCheckSheet.ActiveSheet.RowCount, 1);
                spdPatrolCheckSheet.ActiveSheet.Cells[spdPatrolCheckSheet.ActiveSheet.RowCount - 1, (int)DAILY_WORK_LIST.CHK].Value = true;
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
                spdPatrolCheckSheet.ActiveSheet.Rows.Remove(spdPatrolCheckSheet.ActiveSheet.RowCount - 1, 1);
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
                if (e.Column == (int)DAILY_WORK_LIST.RES_BTN)
                {
                    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLine.Text));
                    in_node.AddString("OPER", cdvOper.Text);

                    // Display and Header Text Setup
                    string[] header = new string[] { "Equip ID", "Equip Desc" };
                    string[] display = new string[] { "RES_ID", "RES_DESC" };

                    // Show CodeView and Get Return
                    cdvData_1.Text = cdvData_1.Show(cdvData_1, "View Resource List", "CRAS", "CRAS_View_Resource_List_By_Line", in_node, "RES_LIST", display, header, "RES_ID");
                    if (MPCF.Trim(cdvData_1.Text) != "")
                    {
                        if (cdvData_1.returnDatas != null && cdvData_1.returnDatas.Count > 0)
                        {
                            spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData_1.returnDatas[0];
                            spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column + 1].Text = cdvData_1.returnDatas[1];
                        }
                        else
                        {
                            spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                            spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column + 1].Text = "";
                        }
                    }
                    else
                    {
                        spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                        spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column + 1].Text = "";
                    }

                }
                else if (e.Column == (int)DAILY_WORK_LIST.CHECK_BTN)
                {
                    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                    MPCF.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_PATROL_CHECK));

                    string[] header = new string[] { "Code", "Name", "Description" };
                    string[] display = new string[] { "KEY_1", "DATA_1", "DATA_2" };

                    cdvData_2.Text = cdvData_2.Show(cdvData_2, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
                    if (MPCF.Trim(cdvData_2.Text) != "")
                    {
                        if (cdvData_2.returnDatas != null && cdvData_2.returnDatas.Count > 0)
                        {
                            spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = cdvData_2.returnDatas[0];
                            spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData_2.returnDatas[1];
                            spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column + 1].Text = cdvData_2.returnDatas[2];
                        }
                        else
                        {
                            spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                            spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                            spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column + 1].Text = "";
                        }
                    }
                    else
                    {
                        spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = "";
                        spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                        spdPatrolCheckSheet.ActiveSheet.Cells[e.Row, e.Column + 1].Text = "";
                    }

                }
                //else if (e.Column == (int)DAILY_WORK_LIST.TROUBLE_TYPE_BTN)
                //{
                //    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                //    MPCF.SetInMsg(in_node);
                //    in_node.ProcStep = '1';
                //    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_EQ_TROUBLE));

                //    string[] header = new string[] { "Code", "Description" };
                //    string[] display = new string[] { "KEY_1", "DATA_3" };

                //    cdvData_2.Text = cdvData_2.Show(cdvData_2, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
                //    if (MPCF.Trim(cdvData_2.Text) != "")
                //    {
                //        if (cdvData_2.returnDatas != null && cdvData_2.returnDatas.Count > 0)
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = cdvData_2.returnDatas[0];
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData_2.returnDatas[1];
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
                //else if (e.Column == (int)DAILY_WORK_LIST.E10_TROUBLE_TYPE_BTN)
                //{
                //    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                //    MPCF.SetInMsg(in_node);
                //    in_node.ProcStep = '1';
                //    in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_EQ_STATUS));

                //    string[] header = new string[] { "Code", "Description" };
                //    string[] display = new string[] { "KEY_1", "DATA_3" };

                //    cdvData_3.Text = cdvData_3.Show(cdvData_3, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
                //    if (MPCF.Trim(cdvData_3.Text) != "")
                //    {
                //        if (cdvData_3.returnDatas != null && cdvData_3.returnDatas.Count > 0)
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Tag = cdvData_3.returnDatas[0];
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData_3.returnDatas[1];
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
                //else if (e.Column == (int)DAILY_WORK_LIST.E10_APPLY_FLAG_BTN)
                //{
                //    TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                //    MPCF.SetInMsg(in_node);
                //    in_node.ProcStep = '1';
                //    in_node.AddString("TABLE_NAME", "YESNO");

                //    string[] header = new string[] { "Code", "Description" };
                //    string[] display = new string[] { "KEY_1", "DATA_1" };

                //    cdvData_4.Text = cdvData_4.Show(cdvData_4, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");
                //    if (MPCF.Trim(cdvData_4.Text) != "")
                //    {
                //        if (cdvData_4.returnDatas != null && cdvData_4.returnDatas.Count > 0)
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = cdvData_4.returnDatas[0];
                //        }
                //        else
                //        {
                //            spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                //        }
                //    }
                //    else
                //    {
                //        spdDailyWorkList.ActiveSheet.Cells[e.Row, e.Column - 1].Text = "";
                //    }

                //}
                


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


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(cdvOper, false) == false)
                {
                    return;
                }

                if (spdPatrolCheckSheet.ActiveSheet.RowCount == 0)
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
            try
            {
                //spdDailyWorkList.ActiveSheet.RowCount = 0;

                //cdvResID.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvResID_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //spdDailyWorkList.ActiveSheet.RowCount = 0;

                //btnProcess.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvFEUser_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);

                string[] header = new string[] { "User ID", "Description" };
                string[] display = new string[] { "USER_ID", "USER_DESC" };

                cdvFEUser.Text = cdvFEUser.Show(cdvFEUser, "User ID", "SEC", "SEC_View_User_List", in_node, "LIST", display, header, "USER_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvFEUser.Text) == true)
                {
                    return;
                }

                return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void cdvBEUser_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);

                string[] header = new string[] { "User ID", "Description" };
                string[] display = new string[] { "USER_ID", "USER_DESC" };

                cdvBEUser.Text = cdvBEUser.Show(cdvBEUser, "User ID", "SEC", "SEC_View_User_List", in_node, "LIST", display, header, "USER_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvBEUser.Text) == true)
                {
                    return;
                }

                return;

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
                if (MPCF.ExportToExcel(spdPatrolCheckSheet, this.Text, "", true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void spdPatrolCheckSheet_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.ColumnHeader && e.Column == (int)DAILY_WORK_LIST.CHK)
                {
                    //전체 헤더 선택
                    string s_hChk = string.Empty;

                    if (spdPatrolCheckSheet.Sheets[0].ColumnHeader.Cells[0, 0].Text == "True")
                    {
                        s_hChk = "False";
                    }
                    else
                    {
                        s_hChk = "True";
                    }

                    spdPatrolCheckSheet.Sheets[0].ColumnHeader.Cells[0, 0].Text = s_hChk;

                    for (int i = 0; i < spdPatrolCheckSheet.Sheets[0].Rows.Count; i++)
                    {
                        spdPatrolCheckSheet.Sheets[0].Cells[i, 0].Text = s_hChk;
                    }
                }
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
                if (MPCF.CheckValue(cdvWorkLine, false) == false)
                {
                    return;
                }


                if (spdPatrolCheckSheet.ActiveSheet.RowCount == 0)
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

        private void cdvWorkLine_ValueChanged(object sender, EventArgs e)
        {
            cdvOper.Text = "";
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLine.Text));

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


        
    }
}
