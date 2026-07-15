//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupBatchJobProcessor.cs
//   Description : Batch Job Processor Definition form
//
//   MES Version : 5.3.1.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Table() : View General Code Table definition
//       - View_Table_List() : View all table list which is included in one factory
//       - Update_Table() : Create/Update/Delete General code Table definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2013-08-21 : Created by DM KIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;

namespace Miracom.BASCore
{
    public partial class frmBASSetupBatchJobProcessor : Miracom.MESCore.SetupForm02
    {
        public frmBASSetupBatchJobProcessor()
        {
            InitializeComponent();
        }

        #region " Variable Definition"

        bool b_LoadFlag = false;

        #endregion

        #region "Function Definition"

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {

            try
            {
                switch (FuncName)
                {
                    case "UPDATE":

                        if (txtBatPrc.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtBatPrc.Select();
                            return false;
                        }
                        switch (ProcStep)
                        {
                            case MPGC.MP_STEP_CREATE:

                                if (MPCF.CheckValue(txtExecCycle, 1) == false)
                                {
                                    return false;
                                }

                                if (MPCF.CheckValue(cboExecMethod, 1) == false)
                                {
                                    return false;
                                }

                                if (numPriority.Value < 1)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(114));
                                    numPriority.Focus();
                                    return false;
                                }

                                if (MPCF.CheckValue(cdvModule, 1) == false)
                                {
                                    return false;
                                }

                                if (MPCF.CheckValue(cdvService, 1) == false)
                                {
                                    return false;
                                }

                                return true;

                            case MPGC.MP_STEP_UPDATE:

                                if (MPCF.CheckValue(txtExecCycle, 1) == false)
                                {
                                    return false;
                                }

                                if (MPCF.CheckValue(cboExecMethod, 1) == false)
                                {
                                    return false;
                                }

                                if (numPriority.Value < 1)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(114));
                                    numPriority.Focus();
                                    return false;
                                }

                                if (MPCF.CheckValue(cdvModule, 1) == false)
                                {
                                    return false;
                                }

                                if (MPCF.CheckValue(cdvService, 1) == false)
                                {
                                    return false;
                                }


                                return true;

                            case MPGC.MP_STEP_DELETE:

                                return true;

                        }
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

        private void ClearData(string ProcStep)
        {

            try
            {

                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this.pnlRight, txtExecCycleEx);
                }
                else if (ProcStep == "2")
                {
                    MPCF.ClearList(lisBatPrc, true);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        //
        // View_Batch_Process()
        //       - View Batch Process Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Batch_Process()
        {
            TRSNode in_node = new TRSNode("VIEW_BATCH_PROCESS_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_PROCESS_OUT");

            try
            {
                ClearData("1");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("JOB_PROC_ID", lisBatPrc.SelectedItems[0].Text, true);

                if (MPCR.CallService("BAS", "BAS_View_Batch_Job_Processor", in_node, ref out_node) == false)
                {
                    return false;
                }

                //General
                txtBatPrc.Text = MPCF.Trim(out_node.GetString("JOB_PROC_ID"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("JOB_PROC_DESC"));
                txtExecCycle.Text = MPCF.Trim(out_node.GetString("PROC_CYCLE"));

                switch (out_node.GetChar("PROC_METHOD"))
                {
                    case 'S': cboExecMethod.SelectedIndex = 0; break;
                    case 'M': cboExecMethod.SelectedIndex = 1; break;
                }

                chkApplyStart.Checked = false;
                if (out_node.GetString("APPLY_START_TIME") != "")
                {
                    chkApplyStart.Checked = true;
                    dtpApplyStartDate.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                    dtpApplyStartTime.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                }

                chkApplyEnd.Checked = false;
                if (out_node.GetString("APPLY_END_TIME") != "")
                {
                    chkApplyEnd.Checked = true;
                    dtpApplyEndDate.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                    dtpApplyEndTime.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                }


                numPriority.Value = out_node.GetInt("JOB_PRIORITY");
                
                cdvCompAlarm.Text = MPCF.Trim(out_node.GetString("COMPLETE_ALARM_ID"));
                chkActFlag.Checked = (out_node.GetChar("ACTIVATE_FLAG") == 'Y') ? true : false;

                cdvModule.Text = MPCF.Trim(out_node.GetString("SERVICE_MODULE"));
                cdvService.Text = MPCF.Trim(out_node.GetString("SERVICE_NAME"));
                txtMesChannel.Text = MPCF.Trim(out_node.GetString("MES_CHANNEL"));
                
                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // Update_Batch_Process()
        //       - Create/Update/Delete Batch Process
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_Batch_Process(char ProcStep)
        {

            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_BATCH_PROCESS_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("JOB_PROC_ID", MPCF.Trim(txtBatPrc.Text));
                in_node.AddString("JOB_PROC_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddString("PROC_CYCLE", MPCF.Trim(txtExecCycle.Text));
                in_node.AddChar("ACTIVATE_FLAG", (chkActFlag.Checked == true ? 'Y' : ' '));

                in_node.AddString("SERVICE_MODULE", MPCF.Trim(cdvModule.Text));
                in_node.AddString("SERVICE_NAME", MPCF.Trim(cdvService.Text));
                in_node.AddString("MES_CHANNEL", MPCF.Trim(txtMesChannel.Text));

                switch (cboExecMethod.Text.Substring(0, 1))
                {
                    case "S": in_node.AddChar("PROC_METHOD", 'S'); break;
                    case "M": in_node.AddChar("PROC_METHOD", 'M'); break;
                }

                in_node.AddString("COMPLETE_ALARM_ID", MPCF.Trim(cdvCompAlarm.Text));
                in_node.AddInt("JOB_PRIORITY", MPCF.ToInt(numPriority.Value));

                if (chkApplyStart.Checked == true)
                {
                    in_node.AddString("APPLY_START_TIME", MPCF.ToStandardTime(dtpApplyStartDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpApplyStartTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                if (chkApplyEnd.Checked == true)
                {
                    in_node.AddString("APPLY_END_TIME", MPCF.ToStandardTime(dtpApplyEndDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpApplyEndTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                if (MPCR.CallService("BAS", "BAS_Update_Batch_Job_Processor", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisBatPrc.Items.Add(txtBatPrc.Text, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        itm.SubItems.Add(txtDesc.Text);
                        itm.Selected = true;
                        lisBatPrc.Sorting = SortOrder.Ascending;
                        lisBatPrc.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisBatPrc, MPCF.Trim(txtBatPrc.Text), false) == true)
                        {
                            lisBatPrc.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisBatPrc, MPCF.Trim(txtBatPrc.Text), false);
                        if (idx != -1)
                        {
                            lisBatPrc.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisBatPrc.Items.Count.ToString();
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Get First Focust Item
        /// </summary>
        /// <returns></returns>
        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.lisBatPrc;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        /// <summary>
        /// Get Module List
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        private bool View_Module_List(ListView listView, char step)
        {
            TRSNode in_node = new TRSNode("VIEW_MODULE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_MODULE_LIST_OUT");
            ListViewItem viewItem;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (MPCR.CallService("SVM", "SVM_View_Module_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (int i = 0; i < out_node.GetList(0).Count; i++)
            {
                viewItem = listView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("MODULE_NAME"),
                                                               (int)SMALLICON_INDEX.IDX_MODULE));
            }

            return true;

        }

        /// <summary>
        /// View Service List
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="cStep"></param>
        /// <returns></returns>
        private bool ViewServiceList(Control control)
        {
            TRSNode in_node = new TRSNode("View_Service_List_In");
            TRSNode out_node = new TRSNode("View_Service_List_Out");
            ListViewItem itmx;
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MODULE_NAME", cdvModule.Text);

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_NAME")), (int)SMALLICON_INDEX.IDX_KEY);
                    if (((ListView)control).Columns.Count > 1)
                    {
                        itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SERVICE_DESC")));
                    }
                    ((ListView)control).Items.Add(itmx);
                }

                in_node.SetString("NEXT_MODULE_NAME", out_node.GetString("NEXT_MODULE_NAME"));
                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));
            } while (in_node.GetString("NEXT_MODULE_NAME") != "" && in_node.GetString("NEXT_SERVICE_NAME") != "");

            return true;
        }

        #endregion

        private void frmBASSetupBatchJobProcessor_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_LoadFlag == false)
                {
                    if (BASLIST.ViewBatchJobProcessorList(lisBatPrc, '1', 1, null, "") == true)
                    {
                        lblDataCount.Text = lisBatPrc.Items.Count.ToString();
                        if (lisBatPrc.Items.Count > 0)
                        {
                            lisBatPrc.Items[0].Selected = true;
                        }
                    }

                    b_LoadFlag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("UPDATE", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Batch_Process(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("UPDATE", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Batch_Process(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }


                if (CheckCondition("UPDATE", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Batch_Process(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    MPCF.FieldClear(this.pnlRight, txtExecCycleEx);
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisBatPrc, txtFind.Text, true, false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                if (BASLIST.ViewBatchJobProcessorList(lisBatPrc, '1', 1, null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisBatPrc.Items.Count.ToString();
                if (lisBatPrc.Items.Count > 0)
                {
                    MPCF.FindListItem(lisBatPrc, txtBatPrc.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ExportToExcel(lisBatPrc, this.Text, "");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

            MPCF.FindListItemPartial(lisBatPrc, txtFind.Text, 0, true, false);
        }

        private void lisBatPrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight, txtExecCycleEx);

                if (lisBatPrc.SelectedItems.Count > 0)
                {
                    txtBatPrc.Text = lisBatPrc.SelectedItems[0].Text;
                    View_Batch_Process();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvCompAlarm_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvCompAlarm.Init();
                MPCF.InitListView(cdvCompAlarm.GetListView);
                cdvCompAlarm.Columns.Add("Alarm ID", 100, HorizontalAlignment.Left);
                cdvCompAlarm.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvCompAlarm.SelectedSubItemIndex = 0;

                ALMLIST.ViewAlarmMsgList(cdvCompAlarm.GetListView, '1', ' ');
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
           
        }

        private void cdvModule_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvModule.Init();
                MPCF.InitListView(cdvModule.GetListView);
                cdvModule.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
                cdvModule.SelectedSubItemIndex = 0;

                View_Module_List(cdvModule.GetListView, '4');
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvService_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvService.Init();
                MPCF.InitListView(cdvService.GetListView);
                cdvService.Columns.Add("Service", 150, HorizontalAlignment.Left);
                cdvService.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvService.SelectedSubItemIndex = 0;

                ViewServiceList(cdvService.GetListView);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvModule_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                cdvService.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            
        }

        private void chkApplyStart_CheckedChanged(object sender, EventArgs e)
        {
            dtpApplyStartDate.Enabled = chkApplyStart.Checked;
            dtpApplyStartTime.Enabled = chkApplyStart.Checked;
        }

        private void chkApplyEnd_CheckedChanged(object sender, EventArgs e)
        {
            dtpApplyEndDate.Enabled = chkApplyEnd.Checked;
            dtpApplyEndTime.Enabled = chkApplyEnd.Checked;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("BATSERVER_IN");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.AddString("JOB_PROC_ID", txtBatPrc.Text);

                if (MPCR.CallService(cdvModule.Text, cdvService.Text, in_node, txtMesChannel.Text, 0, DeliveryMode.Unicast, false) == false)
                {
                    return;
                }
                MPCF.ShowMsgBox(MPCF.GetMessage(52));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

    }
}
