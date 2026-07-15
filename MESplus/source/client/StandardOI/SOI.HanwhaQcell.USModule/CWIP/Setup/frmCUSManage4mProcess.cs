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
    public partial class frmCUSManage4mProcess : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private static string FM_TYPE = "PT";

        public enum FM_LIST
        {
            WORK_DATE,
            APPLY_TIME,
            WORK_LINE,
            MACHINE,
            MACHINE_DETAIL,
            ISSUE,
            BEFORE,
            AFTER,
            PERSON,
            CHARGE_USER,
            UNUSUAL_DESC,
            CREATE_USER,
            CREATE_TIME,
            UPDATE_USER,
            UPDATE_TIME
        }

        #endregion

        #region Constructor

        public frmCUSManage4mProcess()
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
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            dtpApplyTime.Value = DateTime.Now;
            cdvUserID.Text = MPGV.gsUserID;

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
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvWorkLine.Text = cdvWorkLine.Show(cdvWorkLine, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLine.Text) == true)
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
                in_node.ProcStep = '3';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FM_TYPE", FM_TYPE);
                
                if (dtpFrom.Value != null)
                {
                    DateTime dtpDateTimeOut = new DateTime();
                    bool bTrySuccess = DateTime.TryParse(dtpFrom.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("FROM_DATE", dtpDateTimeOut.ToString("yyyyMMdd") + "060000");
                    }
                }
                
                if (dtpTo.Value != null)
                {
                    DateTime dtpDateTimeOut = new DateTime();
                    bool bTrySuccess = DateTime.TryParse(dtpTo.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("TO_DATE", dtpDateTimeOut.AddDays(1).ToString("yyyyMMdd") + "055959");
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


                if (cdvMachineS.Tag != null && cdvMachineS.Tag.ToString() != "")
                {
                    in_node.AddString("MACHINE", MPCF.Trim(cdvMachineS.Tag.ToString()));
                }
                else
                {
                    in_node.AddString("MACHINE", "%");
                }



                if (cdvMDetailS.Tag != null && cdvMDetailS.Tag.ToString() != "")
                {
                    in_node.AddString("MACHINE_DETAIL", MPCF.Trim(cdvMDetailS.Tag.ToString()));
                }
                else
                {
                    in_node.AddString("MACHINE_DETAIL", "%");
                }



                if (cdvIssueS.Tag != null && cdvIssueS.Tag.ToString() != "")
                {
                    in_node.AddString("ISSUE", MPCF.Trim(cdvIssueS.Tag.ToString()));
                }
                else
                {
                    in_node.AddString("ISSUE", "%");
                }


                if (cdvPersonS.Tag != null && cdvPersonS.Tag.ToString() != "")
                {
                    in_node.AddString("PERSON", MPCF.Trim(cdvPersonS.Tag.ToString()));
                }
                else
                {
                    in_node.AddString("PERSON", "%");
                }
                

                if (MPCF.CallService("CWIP", "CWIP_View_4m_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                // Clear
                MPCF.ClearList(this.spdE10TroubleList);
                
                // Bind
                spdE10TroubleList.ActiveSheet.RowCount = out_node.GetList(0).Count;
                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdE10TroubleList.ActiveSheet.RowHeader.Cells[i, 0].Tag = out_node.GetList(0)[i].GetInt("SEQ_NUM");

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_DATE].Tag = out_node.GetList(0)[i].GetString("WORK_DATE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_DATE].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("WORK_DATE"));

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.APPLY_TIME].Tag = out_node.GetList(0)[i].GetString("APPLY_TIME");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.APPLY_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_TIME"), DATE_TIME_FORMAT.DATETIME);
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_LINE].Value = out_node.GetList(0)[i].GetString("LINE_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.WORK_LINE].Tag = out_node.GetList(0)[i].GetString("LINE_ID");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.MACHINE].Value = out_node.GetList(0)[i].GetString("MACHINE_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.MACHINE].Tag = out_node.GetList(0)[i].GetString("MACHINE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.MACHINE_DETAIL].Value = out_node.GetList(0)[i].GetString("MACHINE_DETAIL_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.MACHINE_DETAIL].Tag = out_node.GetList(0)[i].GetString("MACHINE_DETAIL");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.ISSUE].Value = out_node.GetList(0)[i].GetString("ISSUE_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.ISSUE].Tag = out_node.GetList(0)[i].GetString("ISSUE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.BEFORE].Value = out_node.GetList(0)[i].GetString("BEFORE");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.AFTER].Value = out_node.GetList(0)[i].GetString("AFTER");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.PERSON].Value = out_node.GetList(0)[i].GetString("PERSON_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.PERSON].Tag = out_node.GetList(0)[i].GetString("PERSON");

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CHARGE_USER].Value = out_node.GetList(0)[i].GetString("CHARGE_USER_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CHARGE_USER].Tag = out_node.GetList(0)[i].GetString("CHARGE_USER_ID");

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UNUSUAL_DESC].Value = out_node.GetList(0)[i].GetString("UNUSUAL_DESC");

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_USER].Value = out_node.GetList(0)[i].GetString("CREATE_USER_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_USER].Tag = out_node.GetList(0)[i].GetString("CREATE_USER_ID");

                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("CREATE_TIME")) == "")
                    {
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_TIME].Tag = out_node.GetList(0)[i].GetString("CREATE_TIME");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.CREATE_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                    }

                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_USER].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_DESC");
                    spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_USER].Tag = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");

                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("UPDATE_TIME")) == "")
                    {
                    }
                    else
                    {
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_TIME].Tag = out_node.GetList(0)[i].GetString("UPDATE_TIME");
                        spdE10TroubleList.ActiveSheet.Cells[i, (int)FM_LIST.UPDATE_TIME].Value = MPCF.ToDate(out_node.GetList(0)[i].GetString("UPDATE_TIME"));
                    }
                }

                // Fit Column Hedaer
                MPCF.FitColumnHeader(spdE10TroubleList);

                lblSumQty_W.Text = spdE10TroubleList.ActiveSheet.RowCount.ToString();



                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private bool View4mData(int row)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_E0_TROUBLE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_E0_TROUBLE_LIST_OUT");

                //  Call Service
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '4';
                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FM_TYPE", FM_TYPE);

                if (spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_DATE].Tag != null || MPCF.Trim(spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_DATE].Tag.ToString()) == "")
                {
                    in_node.AddString("WORK_DATE", spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_DATE].Tag.ToString());
                }


                if (spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_LINE].Tag != null && MPCF.Trim(spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_LINE].Tag.ToString()) != "")
                {
                    in_node.AddString("LINE_ID", MPCF.Trim(spdE10TroubleList.ActiveSheet.Cells[row, (int)FM_LIST.WORK_LINE].Tag.ToString()));
                }
                else
                {
                    return false;
                }

                if (spdE10TroubleList.ActiveSheet.RowHeader.Cells[row, 0].Tag != null)
                {
                    in_node.AddInt("SEQ_NUM", spdE10TroubleList.ActiveSheet.RowHeader.Cells[row, 0].Tag);
                }
                else
                {
                    return false;
                }


                if (MPCF.CallService("CWIP", "CWIP_View_4m_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtSeq.Text = out_node.GetInt("SEQ_NUM").ToString();
                if (MPCF.Trim(out_node.GetString("APPLY_TIME")) == "")
                {
                }
                else
                {
                    dtpApplyTime.Value = MPCF.ToDate(out_node.GetString("APPLY_TIME"));
                }
                cdvWorkLineI.Text = out_node.GetString("LINE_ID");
                cdvMachine.Text = out_node.GetString("MACHINE");
                cdvMachine.Description = out_node.GetString("MACHINE_DESC");
                cdvMDetail.Text = out_node.GetString("MACHINE_DETAIL");
                cdvMDetail.Description = out_node.GetString("MACHINE_DETAIL_DESC");
                cdvIssue.Text = out_node.GetString("ISSUE");
                cdvIssue.Description = out_node.GetString("ISSUE_DESC");
                txtBefore.Text = out_node.GetString("BEFORE");
                txtAfter.Text = out_node.GetString("AFTER");
                cdvPerson.Text = out_node.GetString("PERSON");
                cdvPerson.Description = out_node.GetString("PERSON_DESC");

                cdvUserID.Text = out_node.GetString("CHARGE_USER_ID");

                txtUnusualDesc.Text = out_node.GetString("UNUSUAL_DESC");               

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

        private bool Update_Daily_Work_List(char cProcStep)
        {
            TRSNode in_node = new TRSNode("TRAN_IN");
            TRSNode out_node = new TRSNode("TRAN_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cProcStep;

                in_node.AddString("FACTORY", MPGV.gsFactory);
                in_node.AddString("FM_TYPE", FM_TYPE);
                DateTime dtpDateTimeOut = new DateTime();

                if (cProcStep == MPGC.MP_STEP_CREATE)
                {
                    bool bTrySuccess = DateTime.TryParse(dtpApplyTime.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                        in_node.AddString("APPLY_TIME", dtpDateTimeOut.ToString("yyyyMMddHHmmss"));                        
                    }
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineI.Text));
                    in_node.AddString("MACHINE", MPCF.Trim(cdvMachine.Text));
                    in_node.AddString("MACHINE_DETAIL", MPCF.Trim(cdvMDetail.Text));
                    in_node.AddString("ISSUE", MPCF.Trim(cdvIssue.Text));                    
                    in_node.AddString("BEFORE", MPCF.Trim(txtBefore.Text));
                    in_node.AddString("AFTER", MPCF.Trim(txtAfter.Text));
                    in_node.AddString("PERSON", MPCF.Trim(cdvPerson.Text));
                    in_node.AddString("CHARGE_USER_ID", MPCF.Trim(cdvUserID.Text));
                    in_node.AddString("UNUSUAL_DESC", MPCF.Trim(txtUnusualDesc.Text));
                }
                else if ((cProcStep == MPGC.MP_STEP_UPDATE) || (cProcStep == MPGC.MP_STEP_DELETE))
                {
                    bool bTrySuccess = DateTime.TryParse(dtpApplyTime.Value.ToString(), out dtpDateTimeOut);
                    if (bTrySuccess == true)
                    {
                        in_node.AddString("WORK_DATE", dtpDateTimeOut.ToString("yyyyMMdd"));
                        in_node.AddString("APPLY_TIME", dtpDateTimeOut.ToString("yyyyMMddHHmmss"));
                    }
                    in_node.AddInt("SEQ_NUM", MPCF.ToInt(MPCF.Trim(txtSeq.Text)));
                    in_node.AddString("LINE_ID", MPCF.Trim(cdvWorkLineI.Text));
                    in_node.AddString("MACHINE", MPCF.Trim(cdvMachine.Text));
                    in_node.AddString("MACHINE_DETAIL", MPCF.Trim(cdvMDetail.Text));
                    in_node.AddString("ISSUE", MPCF.Trim(cdvIssue.Text));
                    in_node.AddString("BEFORE", MPCF.Trim(txtBefore.Text));
                    in_node.AddString("AFTER", MPCF.Trim(txtAfter.Text));
                    in_node.AddString("PERSON", MPCF.Trim(cdvPerson.Text));
                    in_node.AddString("CHARGE_USER_ID", MPCF.Trim(cdvUserID.Text));
                    in_node.AddString("UNUSUAL_DESC", MPCF.Trim(txtUnusualDesc.Text));
                }

                if (MPCF.CallService("CWIP", "CWIP_Update_4m", in_node, ref out_node) == false)
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
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvWorkLine.Text = cdvWorkLine.Show(cdvWorkLine, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLine.Text) == true)
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



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLineI, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(txtSeq, false) == false)
                {
                    return;
                }


                if (spdE10TroubleList.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(536), MSG_LEVEL.ERROR, false);
                    return;
                }

                if (Update_Daily_Work_List(MPGC.MP_STEP_UPDATE) == false)
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

        private void cdvWorkLineI_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_LINE_CODE));
                in_node.AddString("LINE_GROUP", MPCF.Trim(HQGC.AREA_MA));

                string[] header = new string[] { "Line Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvWorkLineI.Text = cdvWorkLineI.Show(cdvWorkLineI, "Code List", "CWIP", "CWIP_View_Line_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvWorkLineI.Text) == true)
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

        private void cdvUserID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_USER_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FACTORY", MPGV.gsFactory);

                // Display and Header Text Setup
                string[] header = new string[] { "User ID", "User Desc" };
                string[] display = new string[] { "USER_ID", "USER_DESC" };

                // Show CodeView and Get Return
                cdvUserID.Text = cdvUserID.Show(cdvUserID, "View User List", "SEC", "SEC_View_User_List", in_node, "LIST", display, header, "USER_ID");

                // Validation
                if (string.IsNullOrEmpty(cdvUserID.Text) == true)
                {
                    MPCF.SetFocus(cdvUserID);
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLineI, false) == false)
                {
                    return;
                }

                if (Update_Daily_Work_List(MPGC.MP_STEP_CREATE) == false)                
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

        private void spdE10TroubleList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Row < 0 || e.ColumnHeader == true)
            {
                return;
            }

            if (View4mData(e.Row) == false)
            {
                return;
            }
        }

        private void cdvWorkLineI_ValueChanged(object sender, EventArgs e)
        {
            cdvMDetail.Text = "";
            cdvIssue.Text = "";
        }        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvWorkLineI, false) == false)
                {
                    return;
                }

                if (MPCF.CheckValue(txtSeq, false) == false)
                {
                    return;
                }


                if (spdE10TroubleList.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowMessage(MPCF.GetMessage(536), MSG_LEVEL.ERROR, false);
                    return;
                }

                if (Update_Daily_Work_List(MPGC.MP_STEP_DELETE) == false)                
                {
                    return;
                }
                else
                {
                    btnProcess.PerformClick();
                    txtSeq.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }
       

        private void cdvMachine_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_MACHINE));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvMachine.Text = cdvMachine.Show(cdvMachine, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvMachine.Text) == true)
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

        private void cdvMDetail_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_MACHINE_DTL));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvMDetail.Text = cdvMDetail.Show(cdvMDetail, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvMDetail.Text) == true)
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

        private void cdvIssue_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_ISSUE));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvIssue.Text = cdvIssue.Show(cdvIssue, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvIssue.Text) == true)
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

        private void cdvPerson_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_PERSON));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvPerson.Text = cdvPerson.Show(cdvPerson, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                // Validation
                if (string.IsNullOrEmpty(cdvPerson.Text) == true)
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

        private void cdvMachineS_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_MACHINE));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvMachineS.Text = cdvMachineS.Show(cdvMachineS, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");
                if (cdvMachineS.returnDatas != null && cdvMachineS.returnDatas.Count > 0)
                {
                    cdvMachineS.Tag = cdvMachineS.returnDatas[0];
                }

                // Validation
                if (string.IsNullOrEmpty(cdvMachineS.Text) == true)
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

        private void cdvMDetailS_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_MACHINE_DTL));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvMDetailS.Text = cdvMDetailS.Show(cdvMDetailS, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");
                if (cdvMDetailS.returnDatas != null && cdvMDetailS.returnDatas.Count > 0)
                {
                    cdvMDetailS.Tag = cdvMDetailS.returnDatas[0];
                }

                // Validation
                if (string.IsNullOrEmpty(cdvMDetailS.Text) == true)
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

        private void cdvIssueS_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_ISSUE));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvIssueS.Text = cdvIssueS.Show(cdvIssueS, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");
                if (cdvIssueS.returnDatas != null && cdvIssueS.returnDatas.Count > 0)
                {
                    cdvIssueS.Tag = cdvIssueS.returnDatas[0];
                }

                // Validation
                if (string.IsNullOrEmpty(cdvIssueS.Text) == true)
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

        private void cdvPersonS_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_GCM_DATA_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(HQGC.GCM_4M_PERSON));

                string[] header = new string[] { "Code", "Description" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvPersonS.Text = cdvPersonS.Show(cdvPersonS, "Code List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");
                if (cdvPersonS.returnDatas != null && cdvPersonS.returnDatas.Count > 0)
                {
                    cdvPersonS.Tag = cdvPersonS.returnDatas[0];
                }

                // Validation
                if (string.IsNullOrEmpty(cdvPersonS.Text) == true)
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

        public void resetButtonClick(object sender, EventArgs e)
        {
            dtpApplyTime.Value = DateTime.Now;
            cdvWorkLineI.Text = string.Empty;
            cdvWorkLineI.Description = string.Empty;
            cdvMachine.Text = string.Empty;
            cdvMachine.Description = string.Empty;
            cdvMDetail.Text = string.Empty;
            cdvMDetail.Description = string.Empty;
            cdvIssue.Text = string.Empty;
            cdvIssue.Description = string.Empty;
            txtBefore.Text = string.Empty;
            txtAfter.Text = string.Empty;
            cdvPerson.Text = string.Empty;
            cdvPerson.Description = string.Empty;
            cdvUserID.Text = string.Empty;
            txtUnusualDesc.Text = string.Empty;  
        }
    }
}
