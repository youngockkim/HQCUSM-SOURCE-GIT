//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASSetupCarrierGroup.vb
//   Description : Carrier Setup Group Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData : Intialize Form Field
//       - CheckCondition : Check the conditions before transaction
//       - Update_Carrier_Group : Create/Update/Delete Carrier
//       - View_Carrier_Group_List :View Carrier list
//       - View_Carrier_Group : View Carrier Information
//
//   Detail Description
//       - Update_Carrier_Group
//         ProcStep="C" - Create New Carrier
//         ProcStep="U" - Update Carrier
//         ProcStep="D" - Delete Carrier
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2007-11-23 : Created by Aiden
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _CRR = True Then

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.UI;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;
namespace Miracom.RASCore
{
    public partial class frmRASSetupCarrierGroup : Miracom.MESCore.SetupForm02
    {
        public frmRASSetupCarrierGroup()
        {
            InitializeComponent();
        }

        #region " Variable definition "
        bool b_load_flag;
        #endregion

        #region " Function definition"

        private bool CheckCondition()
        {
            if (MPCF.CheckValue(txtCarrierGroup, 1) == false) return false;

            return true;
        }

        // UpdateCarrierGroup()
        //       -  Update Carrier Group
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateCarrierGroup(char proc_step)
        {
            TRSNode in_node = new TRSNode("Update_Carrier_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
           
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = proc_step;

                in_node.AddString("CRR_GROUP", MPCF.Trim(txtCarrierGroup.Text));
                in_node.AddString("CRR_GRP_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddInt("USAGE_LIMIT_COUNT", (int)numUsageLimitCount.Value);
                in_node.AddInt("USAGE_LIMIT_TIME", (int)numUsageLimitTime.Value);
                in_node.AddString("USAGE_LIMIT_ALARM", MPCF.Trim(cdvUsageLimitAlarm.Text));
                in_node.AddInt("CLEAN_LIMIT_COUNT", (int)numCleanLimitCount.Value);
                in_node.AddString("CLEAN_LIMIT_ALARM", MPCF.Trim(cdvCleanLimitAlarm.Text));

                if (chkPlanTerminate.Checked == true)
                    in_node.AddString("PLAN_TERMINATE_TIME", MPCF.ToStandardTime(dtpPlanTermDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpPlanTermTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));



                if (MPCR.CallService("RAS", "RAS_Update_Carrier_Group", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (proc_step == MPGC.MP_STEP_CREATE)
                    {
                        ListViewItem item;
                        item = lisList.Items.Add(txtCarrierGroup.Text, (int)SMALLICON_INDEX.IDX_MODULE);
                        item.SubItems.Add(txtDesc.Text);
                        item.Selected = true;
                        lisList.Sorting = SortOrder.Ascending;
                        lisList.Sort();
                        item.EnsureVisible();
                        lblDataCount.Text = lisList.Items.Count.ToString();
                    }
                    else if (proc_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisList, MPCF.Trim(txtCarrierGroup.Text), false) == true)
                        {
                            lisList.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                        lblDataCount.Text = lisList.Items.Count.ToString();
                    }
                    else if (proc_step == MPGC.MP_STEP_DELETE)
                    {
                        int idx;
                        idx = MPCF.FindListItemIndex(lisList, MPCF.Trim(txtCarrierGroup.Text), false);
                        if (idx > -1)
                        {
                            lisList.Items[idx].Remove();
                        }
                        lblDataCount.Text = lisList.Items.Count.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }

        // ViewCarrierGroup()
        //       -  View Carrier Group
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCarrierGroup()
        {
            TRSNode in_node = new TRSNode("Crr_Grp_In");
            TRSNode out_node = new TRSNode("Crr_Grp_Out");
          
            try
            {
                MPCF.FieldClear(this.pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_GROUP", MPCF.Trim(lisList.SelectedItems[0].Text));

                if (MPCR.CallService("RAS", "RAS_View_Carrier_Group", in_node, ref out_node) == false)
                {
                    return false;
                }


                txtCarrierGroup.Text = out_node.GetString("CRR_GROUP");
                txtDesc.Text = out_node.GetString("CRR_GRP_DESC");

                numUsageLimitCount.Value = out_node.GetInt("USAGE_LIMIT_COUNT");
                numUsageLimitTime.Value = out_node.GetInt("USAGE_LIMIT_TIME");
                numCleanLimitCount.Value = out_node.GetInt("CLEAN_LIMIT_COUNT");

                cdvUsageLimitAlarm.Text = out_node.GetString("USAGE_LIMIT_ALARM");
                cdvUsageLimitAlarm.DescText = out_node.GetString("USAGE_LIMIT_ALARM_DESC");
                cdvCleanLimitAlarm.Text = out_node.GetString("CLEAN_LIMIT_ALARM");
                cdvCleanLimitAlarm.DescText = out_node.GetString("CLEAN_LIMIT_ALARM_DESC");

                chkPlanTerminate.Checked = false;
                if (out_node.GetString("PLAN_TERMINATE_TIME") != "")
                {
                    chkPlanTerminate.Checked = true;
                    dtpPlanTermDate.Value = MPCF.ToDate(out_node.GetString("PLAN_TERMINATE_TIME"));
                    dtpPlanTermTime.Value = MPCF.ToDate(out_node.GetString("PLAN_TERMINATE_TIME"));
                }

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

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.txtCarrierGroup;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmRASSetupCarrierGroup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.InitListView(lisList);
                dtpPlanTermDate.Value = DateTime.Now;
                dtpPlanTermTime.Value = MPCF.ToDate(MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATE_FORMAT) + MPGV.gShiftInfor.sShift1StartTime);
                
                btnRefresh.PerformClick();
                b_load_flag = true;

            }

        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition() == false) return;

                if (UpdateCarrierGroup(MPGC.MP_STEP_CREATE) == false) return;
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition() == false) return;

                if (UpdateCarrierGroup(MPGC.MP_STEP_UPDATE) == false) return;
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
                if (CheckCondition() == false) return;

                if (UpdateCarrierGroup(MPGC.MP_STEP_DELETE) == true)
                {
                    MPCF.FieldClear(this.pnlRight);
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

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (RASLIST.ViewCarrierGroupList(lisList) == false) return;

                MPCF.FitColumnHeader(lisList);
                if (lisList.Items.Count > 0)
                {
                    lisList.Items[0].Selected = true;
                }
                lblDataCount.Text = lisList.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisList, this.Text, "");
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisList, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisList, txtFind.Text, 0, true, false);
        }

        private void lisList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FieldClear(this.pnlRight);
            if (lisList.SelectedItems.Count > 0)
            {
                txtCarrierGroup.Text = lisList.SelectedItems[0].Text;
                ViewCarrierGroup();
            }

        }

        private void chkPlanTerminate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlanTerminate.Checked == true)
            {
                dtpPlanTermDate.Value = DateTime.Now;
                dtpPlanTermTime.Value = MPCF.ToDate(MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATE_FORMAT) + MPGV.gShiftInfor.sShift1StartTime);

                dtpPlanTermDate.Visible = true;
                dtpPlanTermTime.Visible = true;
            }
            else
            {
                dtpPlanTermDate.Visible = false;
                dtpPlanTermTime.Visible = false;
            }
        }

        private void cdvUsageLimitAlarm_ButtonPress(object sender, EventArgs e)
        {
            cdvUsageLimitAlarm.Init();
            MPCF.InitListView(cdvUsageLimitAlarm.GetListView);
            cdvUsageLimitAlarm.Columns.Add("Alarm ID", 50, HorizontalAlignment.Left);
            cdvUsageLimitAlarm.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            ALMLIST.ViewAlarmMsgList(cdvUsageLimitAlarm.GetListView, '1', 'N');
            cdvUsageLimitAlarm.InsertEmptyRow(0, 1);
        }

        private void cdvCleanLimitAlarm_ButtonPress(object sender, EventArgs e)
        {
            cdvCleanLimitAlarm.Init();
            MPCF.InitListView(cdvCleanLimitAlarm.GetListView);
            cdvCleanLimitAlarm.Columns.Add("Alarm ID", 50, HorizontalAlignment.Left);
            cdvCleanLimitAlarm.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            ALMLIST.ViewAlarmMsgList(cdvCleanLimitAlarm.GetListView, '1', 'N');
            cdvCleanLimitAlarm.InsertEmptyRow(0, 1);
        }
    }
}
    //#End If '_CRR    

