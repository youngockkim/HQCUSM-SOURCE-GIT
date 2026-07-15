//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWEMSetupWorkProcess.cs
//   Description : MES Cient Form Work Process Setup Class
//
//   MES Version : 5.3.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-11-09 : Created by Aiden
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WEMCore
{
    public partial class frmWEMSetupWorkProcess : SetupForm02
    {
        public frmWEMSetupWorkProcess()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        private const string RCVR_USER = "User";
        private const string RCVR_SEC_GROUP = "Sec Group";
        private const string RCVR_PRV_GROUP = "Prv Group";

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition(string s_func_name)
        {
            if (MPCF.CheckValue(cdvProcType, 1) == false) return false;
            if (MPCF.CheckValue(txtProcID, 1) == false) return false;

            switch (s_func_name)
            {
                case "CREATE_PROC_ID":
                case "UPDATE_PROC_ID":
                    if (MPCF.CheckValue(txtTitle, 1) == false) return false;
                    if (lisAssStepList.Items.Count < 2)
                    {
                        tabAssign.SelectedTab = tbpStep;
                        MPCF.ShowMsgBox(MPCF.GetMessage(107));
                        lisAssStepList.Focus();
                        return false;
                    }
                    break;

                case "CREATE_STEP_USER":
                    if (lisAssStepList2.SelectedItems.Count < 1)
                    {
                        tabAssign.SelectedTab = tbpAuth;
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        lisAssStepList2.Focus();
                        return false;
                    }
                    if (lisRecvList.Items.Count < 1)
                    {
                        tabAssign.SelectedTab = tbpAuth;
                        MPCF.ShowMsgBox(MPCF.GetMessage(107));
                        lisRecvList.Focus();
                        return false;
                    }
                    break;
                case "UPDATE_STEP_USER":
                    if (lisAssStepList2.SelectedItems.Count < 1)
                    {
                        tabAssign.SelectedTab = tbpAuth;
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        lisAssStepList2.Focus();
                        return false;
                    }
                    break;
            }

            return true;
        }

        private bool ViewWorkProcessID()
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_PROC_ID_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_PROC_ID_OUT");
            List<TRSNode> lis_step_list;
            ListViewItem itm;
            int i;
            int ii;

            MPCF.InitListView(lisAssStepList);
            MPCF.InitListView(lisAssStepList2);
            numMinProcCount.Enabled = false;

            for (i = 0; i < lisStepList.Items.Count; i++)
            {
                if (lisStepList.Items[i].ForeColor == Color.Blue)
                    lisStepList.Items[i].ForeColor = SystemColors.WindowText;
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(cdvProcType.Text));
            in_node.AddString("PROC_ID", MPCF.Trim(txtProcID.Text));

            if (MPCR.CallService("WEM", "WEM_View_Work_Process", in_node, ref out_node) == false)
            {
                return false;
            }

            txtProcDesc.Text = out_node.GetString("PROC_DESC");
            txtTitle.Text = out_node.GetString("TITLE");
            cdvIDRule.Text = out_node.GetString("ID_GEN_RULE");

            lis_step_list = out_node.GetList("STEP_LIST");
            for (i = 0; i < lis_step_list.Count; i++)
            {
                itm = new ListViewItem(lis_step_list[i].GetString("STEP_ID"), (int)SMALLICON_INDEX.IDX_MODULE);
                itm.SubItems.Add(lis_step_list[i].GetString("STEP_GROUP"));
                itm.SubItems.Add(lis_step_list[i].GetChar("OPTIONAL_FLAG").ToString());
                itm.SubItems.Add(lis_step_list[i].GetInt("MIN_PROC_STEP_COUNT").ToString());
                itm.SubItems.Add(lis_step_list[i].GetChar("ARBITRARY_FLAG").ToString());
                itm.SubItems.Add(lis_step_list[i].GetChar("INPUT_APPROVER_FLAG").ToString());
                itm.SubItems.Add(lis_step_list[i].GetString("NOTIFY_ALARM_ID"));
                itm.SubItems.Add(lis_step_list[i].GetString("STEP_DESC"));

                lisAssStepList.Items.Add(itm);

                ii = MPCF.FindListItemIndex(lisStepList, lis_step_list[i].GetString("STEP_ID"), false);
                if (ii >= 0)
                {
                    lisStepList.Items[ii].ForeColor = Color.Blue;
                }
            }

            itm = lisAssStepList.Items.Add("Attach ...", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
            itm.SubItems.Add("");
            itm.SubItems.Add("");
            itm.SubItems.Add("");
            itm.SubItems.Add("");
            itm.SubItems.Add("");
            itm.SubItems.Add("");
            itm.SubItems.Add("");

            if (tabAssign.SelectedTab == tbpAuth)
            {
                tabAssign_SelectedIndexChanged(null, null);
            }

            return true;
        }

        private bool ViewWorkProcessStepUser(string s_step_id)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_PROC_STEP_USER_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_PROC_STEP_USER_OUT");
            List<TRSNode> lis_user_list;
            ListViewItem itm;
            ListView lisTemp;
            int i;
            int ii;
            int i_icon_index;
            string s_rcvr_type;


            MPCF.InitListView(lisRecvList);

            for (i = 0; i < lisUserList.Items.Count; i++)
            {
                if (lisUserList.Items[i].ForeColor == Color.Blue)
                    lisUserList.Items[i].ForeColor = SystemColors.WindowText;
            }
            for (i = 0; i < lisSecGrpList.Items.Count; i++)
            {
                if (lisSecGrpList.Items[i].ForeColor == Color.Blue)
                    lisSecGrpList.Items[i].ForeColor = SystemColors.WindowText;
            }
            for (i = 0; i < lisPrvGrpList.Items.Count; i++)
            {
                if (lisPrvGrpList.Items[i].ForeColor == Color.Blue)
                    lisPrvGrpList.Items[i].ForeColor = SystemColors.WindowText;
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(cdvProcType.Text));
            in_node.AddString("PROC_ID", MPCF.Trim(txtProcID.Text));
            in_node.AddString("STEP_ID", s_step_id);

            if (MPCR.CallService("WEM", "WEM_View_Work_Process_Step_User_List", in_node, ref out_node, true) == false)
            {
                return false;
            }

            i_icon_index = (int)SMALLICON_INDEX.IDX_USER;
            s_rcvr_type = "";
            lisTemp = null;

            lis_user_list = out_node.GetList("USER_LIST");
            for (i = 0; i < lis_user_list.Count; i++)
            {
                switch (lis_user_list[i].GetChar("USER_TYPE"))
                {
                    case 'U':
                        lisTemp = lisUserList;
                        i_icon_index = (int)SMALLICON_INDEX.IDX_USER;
                        s_rcvr_type = RCVR_USER;
                        break;
                    case 'S':
                        lisTemp = lisSecGrpList;
                        i_icon_index = (int)SMALLICON_INDEX.IDX_SEC_GROUP;
                        s_rcvr_type = RCVR_SEC_GROUP;
                        break;
                    case 'P':
                        lisTemp = lisPrvGrpList;
                        i_icon_index = (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP;
                        s_rcvr_type = RCVR_PRV_GROUP;
                        break;
                }

                itm = new ListViewItem(lis_user_list[i].GetString("USER_ID"), i_icon_index);
                itm.SubItems.Add(s_rcvr_type);
                itm.SubItems.Add(lis_user_list[i].GetString("ASSIGN_OPTION"));
                lisRecvList.Items.Add(itm);

                ii = MPCF.FindListItemIndex(lisTemp, lis_user_list[i].GetString("USER_ID"), false);
                if (ii >= 0)
                {
                    lisTemp.Items[ii].ForeColor = Color.Blue;
                }
            }

            lisRecvList.ListViewItemSorter = new ListViewItemComparer(1, SortOrder.Descending, ListViewItemComparer.SORTING_OPTION.STRING_TYPE);
            lisRecvList.Sort();
            lisRecvList.ListViewItemSorter = null;

            return true;
        }

        private bool UpdateWorkProcessID(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_WORK_PROCESS_IN");
            TRSNode out_node = new TRSNode("UPDATE_WORK_PROCESS_OUT");
            TRSNode list_item;
            int i;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("WORK_PROC_TYPE", cdvProcType.Text);
            in_node.AddString("PROC_ID", txtProcID.Text);
            in_node.AddString("TITLE", txtTitle.Text);
            in_node.AddString("ID_GEN_RULE", cdvIDRule.Text);
            in_node.AddString("PROC_DESC", txtProcDesc.Text);

            if (c_step == MPGC.MP_STEP_CREATE || c_step == MPGC.MP_STEP_UPDATE)
            {
                for (i = 0; i < lisAssStepList.Items.Count - 1; i++)
                {
                    list_item = in_node.AddNode("STEP_LIST");
                    list_item.AddString("STEP_ID", MPCF.Trim(lisAssStepList.Items[i].SubItems[0].Text));
                    list_item.AddString("STEP_GROUP", MPCF.Trim(lisAssStepList.Items[i].SubItems[1].Text));
                    list_item.AddChar("OPTIONAL_FLAG", MPCF.ToChar(lisAssStepList.Items[i].SubItems[2].Text));
                    list_item.AddInt("MIN_PROC_STEP_COUNT", MPCF.ToInt(lisAssStepList.Items[i].SubItems[3].Text));
                    list_item.AddChar("ARBITRARY_FLAG", MPCF.ToChar(lisAssStepList.Items[i].SubItems[4].Text));
                    list_item.AddChar("INPUT_APPROVER_FLAG", MPCF.ToChar(lisAssStepList.Items[i].SubItems[5].Text));
                    list_item.AddString("NOTIFY_ALARM_ID", MPCF.Trim(lisAssStepList.Items[i].SubItems[6].Text));
                }
            }

            if (MPCR.CallService("WEM", "WEM_Update_Work_Process", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }

        private bool UpdateWorkProcessStepUser(char c_step, string s_step_id)
        {
            TRSNode in_node = new TRSNode("UPDATE_WORK_PROCESS_STEP_USER_IN");
            TRSNode out_node = new TRSNode("UPDATE_WORK_PROCESS_STEP_USER_OUT");
            TRSNode list_item;
            int i;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("WORK_PROC_TYPE", cdvProcType.Text);
            in_node.AddString("PROC_ID", txtProcID.Text);
            in_node.AddString("STEP_ID", s_step_id);

            if (c_step == MPGC.MP_STEP_CREATE || c_step == MPGC.MP_STEP_UPDATE)
            {
                for (i = 0; i < lisRecvList.Items.Count; i++)
                {
                    list_item = in_node.AddNode("USER_LIST");
                    list_item.AddString("USER_ID", MPCF.Trim(lisRecvList.Items[i].SubItems[0].Text));
                    list_item.AddChar("USER_TYPE", MPCF.ToChar(lisRecvList.Items[i].SubItems[1].Text));
                    list_item.AddString("ASSIGN_OPTION", MPCF.Trim(lisRecvList.Items[i].SubItems[2].Text));
                }
            }

            if (MPCR.CallService("WEM", "WEM_Update_Work_Process_Step_User", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }

        private bool CopyWorkProcess()
        {
            TRSNode in_node = new TRSNode("COPY_WORK_PROCESS_IN");
            TRSNode out_node = new TRSNode("COPY_WORK_PROCESS_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(cdvProcType.Text));
                in_node.AddString("PROC_ID", MPCF.Trim(txtProcID.Text));
                in_node.AddString("TO_PROC_ID", MPCF.Trim(txtToProcess.Text));

                if (MPCR.CallService("WEM", "WEM_Copy_Work_Process", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.cdvProcType;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmWEMSetupWorkProcess_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.InitListView(lisProcessList);
                MPCF.InitListView(lisAssStepList);
                MPCF.InitListView(lisStepList);
                MPCF.InitListView(lisAssStepList2);
                MPCF.InitListView(lisRecvList);
                numMinProcCount.Enabled = false;

                lisUserList.Dock = DockStyle.Fill;
                lisSecGrpList.Dock = DockStyle.Fill;
                lisPrvGrpList.Dock = DockStyle.Fill;
                rbnUser.Checked = true;

                SECLIST.ViewSECUserList(lisUserList);
                SECLIST.ViewSecGroupList(lisSecGrpList);
                SECLIST.ViewPrvGroupList(lisPrvGrpList);

                b_load_flag = true;
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisProcessList, this.Text, "");
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvProcType, 1) == false) return;

                lblDataCount.Text = "";
                if (WEMLIST.ViewWorkProcessList(lisProcessList, cdvProcType.Text) == false)
                {
                    return;
                }
                lblDataCount.Text = lisProcessList.Items.Count.ToString();
                if (lisProcessList.Items.Count > 0)
                {
                    MPCF.FindListItem(lisProcessList, txtProcID.Text, false);
                }
                else if (lisAssStepList.Items.Count < 1)
                {
                    ListViewItem itm = lisAssStepList.Items.Add("Attach ...", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");
                    itm.SubItems.Add("");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisProcessList, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisProcessList, txtFind.Text, 0, true, false);
        }

        private void cdvProcType_ButtonPress(object sender, EventArgs e)
        {
            cdvProcType.Init();
            MPCF.InitListView(cdvProcType.GetListView);
            cdvProcType.Columns.Add("Process Type", 150, HorizontalAlignment.Left);
            cdvProcType.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvProcType.SelectedSubItemIndex = 0;
            WEMLIST.ViewWorkProcessTypeList(cdvProcType.GetListView);
        }

        private void cdvProcType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvProcType.Text == "") return;

            btnRefresh.PerformClick();
            if (WEMLIST.ViewProcessStepList(lisStepList, cdvProcType.Text) == false) return;
        }

        private void cdvIDRule_ButtonPress(object sender, EventArgs e)
        {
            cdvIDRule.Init();
            MPCF.InitListView(cdvIDRule.GetListView);
            cdvIDRule.Columns.Add("Rule ID", 150, HorizontalAlignment.Left);
            cdvIDRule.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvIDRule.SelectedSubItemIndex = 0;
            WIPLIST.ViewRuleList(cdvIDRule.GetListView, ' ', false, "");
            cdvIDRule.InsertEmptyRow(0, 1);
        }

        private void cdvNotifyAlarmID_ButtonPress(object sender, EventArgs e)
        {
            cdvNotifyAlarmID.Init();
            MPCF.InitListView(cdvNotifyAlarmID.GetListView);
            cdvNotifyAlarmID.Columns.Add("Alarm", 150, HorizontalAlignment.Left);
            cdvNotifyAlarmID.Columns.Add("Message", 200, HorizontalAlignment.Left);
            cdvNotifyAlarmID.SelectedSubItemIndex = 0;
            ALMLIST.ViewAlarmMsgList(cdvNotifyAlarmID.GetListView, '1', ' ');
            cdvNotifyAlarmID.InsertEmptyRow(0, 1);
        }

        private void lisAssStepList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisAssStepList.SelectedItems.Count < 1) return;

            chkOptionalStep.Checked = MPCF.Trim(lisAssStepList.SelectedItems[0].SubItems[2].Text) == "Y" ? true : false;
            numMinProcCount.Value = MPCF.ToInt(lisAssStepList.SelectedItems[0].SubItems[3].Text);
            chkArbitrary.Checked = MPCF.Trim(lisAssStepList.SelectedItems[0].SubItems[4].Text) == "Y" ? true : false;
            chkInputApprover.Checked = MPCF.Trim(lisAssStepList.SelectedItems[0].SubItems[5].Text) == "Y" ? true : false;
            txtStepGroup.Text = MPCF.Trim(lisAssStepList.SelectedItems[0].SubItems[1].Text);
            cdvNotifyAlarmID.Text = MPCF.Trim(lisAssStepList.SelectedItems[0].SubItems[6].Text);

            numMinProcCount.Enabled = false;
            if (txtStepGroup.Text != "" && chkOptionalStep.Checked == true)
            {
                int i;
                int i_start_idx, i_end_idx;
                bool b_active_min_proc_count;

                b_active_min_proc_count = false;
                i_start_idx = i_end_idx = 0;
                for (i = lisAssStepList.SelectedItems[0].Index - 1; i >= 0; i--)
                {
                    if (MPCF.Trim(lisAssStepList.Items[i].SubItems[1].Text) != txtStepGroup.Text)
                    {
                        i_start_idx = i + 1;
                        break;
                    }
                }
                for (i = lisAssStepList.SelectedItems[0].Index + 1; i < lisAssStepList.Items.Count; i++)
                {
                    if (MPCF.Trim(lisAssStepList.Items[i].SubItems[1].Text) != txtStepGroup.Text)
                    {
                        i_end_idx = i - 1;
                        break;
                    }
                }

                if (i_start_idx < i_end_idx)
                {
                    b_active_min_proc_count = true;
                    for (i = i_start_idx; i <= i_end_idx; i++)
                    {
                        if (MPCF.Trim(lisAssStepList.Items[i].SubItems[2].Text) != "Y")
                        {
                            b_active_min_proc_count = false;
                            break;
                        }
                    }
                }

                if (b_active_min_proc_count == true)
                {
                    numMinProcCount.Enabled = true;
                }
            }
        }

        private void lisProcessList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisProcessList.SelectedItems.Count > 0)
            {
                //2014.03.31 Process ID를 선택했을때는 초기화 되지 않아 오동작의 위험이 있어 수정함.           
                MPCF.InitListView(lisRecvList);

                MPCF.FieldClear(this.pnlRight, this.pnlUserType);

                txtProcID.Text = lisProcessList.SelectedItems[0].Text;
                if (ViewWorkProcessID() == false) return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lisStepList.SelectedItems.Count < 1) return;
            if (lisAssStepList.SelectedItems.Count < 1) return;
            if (MPCF.CheckValue(txtProcID, 1) == false) return;

            try
            {
                ListViewItem itmX;
                int idx;
                int i;

                for (i = 0; i < lisStepList.SelectedItems.Count; i++)
                {
                    if (MPCF.FindListItemIndex(lisAssStepList, lisStepList.SelectedItems[i].Text, false) >= 0) continue;

                    itmX = lisAssStepList.Items.Insert(lisAssStepList.SelectedItems[0].Index, lisStepList.SelectedItems[i].Text, (int)SMALLICON_INDEX.IDX_MODULE);
                    itmX.SubItems.Add(txtStepGroup.Text);
                    itmX.SubItems.Add(chkOptionalStep.Checked == true ? "Y" : "");
                    itmX.SubItems.Add(numMinProcCount.Value.ToString());
                    itmX.SubItems.Add(chkArbitrary.Checked == true ? "Y" : "");
                    itmX.SubItems.Add(chkInputApprover.Checked == true ? "Y" : "");
                    itmX.SubItems.Add(cdvNotifyAlarmID.Text);
                    itmX.SubItems.Add(lisStepList.SelectedItems[i].SubItems[1].Text);

                    lisStepList.SelectedItems[i].ForeColor = Color.Blue;
                }

                if (lisStepList.SelectedItems.Count == 1)
                {
                    idx = lisStepList.SelectedItems[0].Index;
                    if (idx + 1 < lisStepList.Items.Count)
                    {
                        lisStepList.Items[idx].Selected = false;
                        lisStepList.Items[idx + 1].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lisAssStepList.SelectedItems.Count <= 0) return;
            if (lisAssStepList.SelectedItems[0].Index >= lisAssStepList.Items.Count - 1) return;

            int idx = 0;
            int i;

            for (i = lisAssStepList.SelectedItems.Count - 1; i >= 0; i--)
            {
                if (lisAssStepList.SelectedItems[i].Text == "Attach ...") continue;

                idx = MPCF.FindListItemIndex(lisStepList, lisAssStepList.SelectedItems[i].Text, false);
                if (idx >= 0)
                {
                    lisStepList.Items[idx].ForeColor = SystemColors.WindowText;
                }

                idx = lisAssStepList.SelectedItems[i].Index;
                lisAssStepList.Items.RemoveAt(idx);
            }
            if (lisAssStepList.Items.Count - 1 == idx && idx > 0)
            {
                idx--;
            }
            lisAssStepList.Items[idx].Selected = true;
        }

        private void btnStepUp_Click(object sender, EventArgs e)
        {
            int i_cur_idx, i_new_idx;
            ListViewItem itm;

            // 리스트에 아이템이 Attach를 제외하고 한개만 존재할때는 동작하지 않도록 함
            if (lisAssStepList.Items.Count < 3) return;
            // 선택된 아이템이 없는 경우 동작하지 않도록 함
            if (lisAssStepList.SelectedItems.Count < 1) return;
            // 선택된 아이템이 전체를 선택한 경우 동작하지 않도록 함
            if (lisAssStepList.SelectedItems.Count > lisAssStepList.Items.Count - 2) return;

            for (int i = 0; i < lisAssStepList.SelectedItems.Count; i++)
            {
                if (lisAssStepList.SelectedItems[i].Index == 0) continue;
                if (lisAssStepList.SelectedItems[i].Index > lisAssStepList.Items.Count - 2) continue;

                i_cur_idx = lisAssStepList.SelectedItems[i].Index;
                i_new_idx = i_cur_idx - 1;

                if (lisAssStepList.Items[i_new_idx].Selected == true) continue;

                itm = (ListViewItem)lisAssStepList.Items[i_new_idx].Clone();
                lisAssStepList.Items[i_new_idx] = (ListViewItem)lisAssStepList.Items[i_cur_idx].Clone();
                lisAssStepList.Items[i_cur_idx] = itm;

                lisAssStepList.Items[i_new_idx].Selected = true;
            }
        }

        private void btnStepDown_Click(object sender, EventArgs e)
        {
            int i_cur_idx, i_new_idx;
            ListViewItem itm;

            // 리스트에 아이템이 Attach를 제외하고 한개만 존재할때는 동작하지 않도록 함
            if (lisAssStepList.Items.Count < 3) return;
            // 선택된 아이템이 없는 경우 동작하지 않도록 함
            if (lisAssStepList.SelectedItems.Count < 1) return;
            // 선택된 아이템이 전체를 선택한 경우 동작하지 않도록 함
            if (lisAssStepList.SelectedItems.Count > lisAssStepList.Items.Count - 2) return;

            for (int i = lisAssStepList.SelectedItems.Count - 1; i >= 0; i--)
            {
                if (lisAssStepList.SelectedItems[i].Index >= lisAssStepList.Items.Count - 2) continue;

                i_cur_idx = lisAssStepList.SelectedItems[i].Index;
                i_new_idx = i_cur_idx + 1;

                if (lisAssStepList.Items[i_new_idx].Selected == true) continue;

                itm = (ListViewItem)lisAssStepList.Items[i_new_idx].Clone();
                lisAssStepList.Items[i_new_idx] = (ListViewItem)lisAssStepList.Items[i_cur_idx].Clone();
                lisAssStepList.Items[i_cur_idx] = itm;

                lisAssStepList.Items[i_new_idx].Selected = true;
            }
        }

        private void tabAssign_SelectedIndexChanged(object sender, EventArgs e)
        {
            //2014.04.02 탭마다 버튼활성 다르게 적용
            if (tabAssign.SelectedTab == tbpStep)
            {
                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);
            }
            else if (tabAssign.SelectedTab == tbpAuth)
            {
                int i;
                ListViewItem itm;

                MPCF.InitListView(lisAssStepList2);

                for (i = 0; i < lisAssStepList.Items.Count - 1; i++)
                {
                    itm = (ListViewItem)lisAssStepList.Items[i].Clone();
                    lisAssStepList2.Items.Add(itm);
                }

                MPCR.ChangeControlEnabled(this, btnCreate, false);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, false);
            }
            else
            {
                MPCR.ChangeControlEnabled(this, btnCreate, false);
                MPCR.ChangeControlEnabled(this, btnUpdate, false);
                MPCR.ChangeControlEnabled(this, btnDelete, false);
            }

        }

        private void lisAssStepList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisAssStepList2.SelectedItems.Count < 1) return;

            string s_step_id;

            MPCF.FieldClear(this.tbpAuth, this.pnlUserType);
            s_step_id = MPCF.Trim(lisAssStepList2.SelectedItems[0].Text);
            if (ViewWorkProcessStepUser(s_step_id) == false) return;
        }

        private void rbnUserType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbnTemp = (RadioButton)sender;

            switch (rbnTemp.Name)
            {
                case "rbnUser":
                    lisUserList.Visible = true;
                    lisSecGrpList.Visible = false;
                    lisPrvGrpList.Visible = false;
                    break;
                case "rbnSecGroup":
                    lisUserList.Visible = false;
                    lisSecGrpList.Visible = true;
                    lisPrvGrpList.Visible = false;
                    break;
                case "rbnPrvGroup":
                    lisUserList.Visible = false;
                    lisSecGrpList.Visible = false;
                    lisPrvGrpList.Visible = true;
                    break;
            }
        }

        private void lisRecvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisRecvList.SelectedItems.Count < 1) return;

            string s_option = MPCF.Trim(lisRecvList.SelectedItems[0].SubItems[2].Text);
            if (s_option.Length < 5) return;

            rbtReadable.Checked = false;
            rbtWritable.Checked = false;
            chkRecvNoti.Checked = false;
            chkAllowSkip.Checked = false;
            chkApprover.Checked = false;
            chkAllowGoToAny.Checked = false;

            if (s_option[0] == 'R') rbtReadable.Checked = true;
            else if (s_option[0] == 'W') rbtWritable.Checked = true;

            if (s_option[1] == 'Y') chkRecvNoti.Checked = true;
            if (s_option[2] == 'Y') chkAllowSkip.Checked = true;
            if (s_option[3] == 'Y') chkApprover.Checked = true;
            if (s_option[4] == 'Y') chkAllowGoToAny.Checked = true;
        }

        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(txtProcID, 1) == false) return;

            int i;
            ListView lisTemp;
            ListViewItem itmX;
            string s_user_type;
            string s_ass_option;
            int i_icon_index;

            string s_user_id;

            lisTemp = null;
            s_user_type = "";
            i_icon_index = (int)SMALLICON_INDEX.IDX_USER;

            if (rbnUser.Checked == true)
            {
                lisTemp = lisUserList;
                s_user_type = RCVR_USER;
                i_icon_index = (int)SMALLICON_INDEX.IDX_USER;
            }
            else if (rbnSecGroup.Checked == true)
            {
                lisTemp = lisSecGrpList;
                s_user_type = RCVR_SEC_GROUP;
                i_icon_index = (int)SMALLICON_INDEX.IDX_SEC_GROUP;
            }
            else if (rbnPrvGroup.Checked == true)
            {
                lisTemp = lisPrvGrpList;
                s_user_type = RCVR_PRV_GROUP;
                i_icon_index = (int)SMALLICON_INDEX.IDX_PRIVILEGE_GROUP;
            }

            if (lisTemp.SelectedItems.Count < 1) return;

            if (rbtReadable.Checked == false && rbtWritable.Checked == false)
            {
                rbtReadable.Checked = true;
            }

            s_ass_option = "";
            if (rbtReadable.Checked == true)        s_ass_option = "R";
            else if (rbtWritable.Checked == true)   s_ass_option = "W";

            if (chkRecvNoti.Checked == true)        s_ass_option += "Y";
            else                                    s_ass_option += "_";

            if (chkAllowSkip.Checked == true)       s_ass_option += "Y";
            else                                    s_ass_option += "_";

            if (chkApprover.Checked == true)        s_ass_option += "Y";
            else                                    s_ass_option += "_";

            if (chkAllowGoToAny.Checked == true)    s_ass_option += "Y";
            else                                    s_ass_option += "_";

            for (i = 0; i < lisTemp.SelectedItems.Count; i++)
            {
                s_user_id = lisTemp.SelectedItems[i].Text;
                if (MPCF.FindListItemIndex(lisRecvList, s_user_id, false) < 0)
                {
                    itmX = new ListViewItem(s_user_id, i_icon_index);
                    itmX.SubItems.Add(s_user_type);
                    itmX.SubItems.Add(s_ass_option);
                    lisRecvList.Items.Add(itmX);

                    lisTemp.SelectedItems[i].ForeColor = Color.Blue;
                }
            }
        }

        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            string s_user_id;
            string s_user_type;
            ListView lisTemp;
            int i_source_index;
            ArrayList a_item;

            if (lisRecvList.SelectedItems.Count < 1) return;

            a_item = new ArrayList();
            lisTemp = null;
            for (i = 0; i < lisRecvList.SelectedItems.Count; i++)
            {
                s_user_id = lisRecvList.SelectedItems[i].Text;
                s_user_type = lisRecvList.SelectedItems[i].SubItems[1].Text;

                lisTemp = null;
                switch (s_user_type)
                {
                    case RCVR_USER:
                        lisTemp = lisUserList;
                        break;
                    case RCVR_SEC_GROUP:
                        lisTemp = lisSecGrpList;
                        break;
                    case RCVR_PRV_GROUP:
                        lisTemp = lisPrvGrpList;
                        break;
                }

                i_source_index = MPCF.FindListItemIndex(lisTemp, s_user_id, false);
                if (i_source_index >= 0)
                {
                    lisTemp.Items[i_source_index].ForeColor = SystemColors.WindowText;
                }

                a_item.Add(lisRecvList.SelectedItems[i]);
            }

            for (i = 0; i < a_item.Count; i++)
            {
                lisRecvList.Items.Remove((ListViewItem)a_item[i]);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lisAssStepList.Items.Count < 1) return;
            if (lisAssStepList.SelectedItems.Count < 1) return;

            if (MPCF.Trim(lisAssStepList.SelectedItems[0].SubItems[1].Text) != "" &&
                MPCF.Trim(lisAssStepList.SelectedItems[0].SubItems[2].Text) == "Y")
            {
                int i;
                int i_start_idx, i_end_idx;

                i_start_idx = i_end_idx = 0;
                for (i = lisAssStepList.SelectedItems[0].Index - 1; i >= 0; i--)
                {
                    if (MPCF.Trim(lisAssStepList.Items[i].SubItems[1].Text) != MPCF.Trim(lisAssStepList.SelectedItems[0].SubItems[1].Text))
                    {
                        i_start_idx = i + 1;
                        break;
                    }
                }
                for (i = lisAssStepList.SelectedItems[0].Index + 1; i < lisAssStepList.Items.Count; i++)
                {
                    if (MPCF.Trim(lisAssStepList.Items[i].SubItems[1].Text) != MPCF.Trim(lisAssStepList.SelectedItems[0].SubItems[1].Text))
                    {
                        i_end_idx = i - 1;
                        break;
                    }
                }

                if (i_start_idx < i_end_idx)
                {
                    for (i = i_start_idx; i <= i_end_idx; i++)
                    {
                        lisAssStepList.Items[i].SubItems[3].Text = "0";
                    }
                }
            }

            lisAssStepList.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtStepGroup.Text);
            lisAssStepList.SelectedItems[0].SubItems[2].Text = (chkOptionalStep.Checked == true ? "Y" : "");
            lisAssStepList.SelectedItems[0].SubItems[3].Text = "0";
            lisAssStepList.SelectedItems[0].SubItems[4].Text = (chkArbitrary.Checked == true ? "Y" : "");
            lisAssStepList.SelectedItems[0].SubItems[5].Text = (chkInputApprover.Checked == true ? "Y" : "");
            lisAssStepList.SelectedItems[0].SubItems[6].Text = MPCF.Trim(cdvNotifyAlarmID.Text);

            if (txtStepGroup.Text != "" && chkOptionalStep.Checked == true)
            {
                int i;
                int i_start_idx, i_end_idx;
                bool b_active_min_proc_count;

                b_active_min_proc_count = false;
                i_start_idx = i_end_idx = 0;
                for (i = lisAssStepList.SelectedItems[0].Index - 1; i >= 0; i--)
                {
                    if (MPCF.Trim(lisAssStepList.Items[i].SubItems[1].Text) != txtStepGroup.Text)
                    {
                        i_start_idx = i + 1;
                        break;
                    }
                }
                for (i = lisAssStepList.SelectedItems[0].Index + 1; i < lisAssStepList.Items.Count; i++)
                {
                    if (MPCF.Trim(lisAssStepList.Items[i].SubItems[1].Text) != txtStepGroup.Text)
                    {
                        i_end_idx = i - 1;
                        break;
                    }
                }

                if (i_start_idx < i_end_idx)
                {
                    b_active_min_proc_count = true;
                    for (i = i_start_idx; i <= i_end_idx; i++)
                    {
                        if (MPCF.Trim(lisAssStepList.Items[i].SubItems[2].Text) != "Y")
                        {
                            b_active_min_proc_count = false;
                            break;
                        }
                    }
                    if (b_active_min_proc_count == true)
                    {
                        if (numMinProcCount.Value > 0)
                        {
                            if (i_end_idx - i_start_idx < numMinProcCount.Value)
                            {
                                numMinProcCount.Value = 0;
                            }
                            else
                            {
                                for (i = i_start_idx; i <= i_end_idx; i++)
                                {
                                    lisAssStepList.Items[i].SubItems[3].Text = numMinProcCount.Value.ToString();
                                }
                            }
                        }
                        else
                        {
                            numMinProcCount.Enabled = true;
                        }
                    }
                }
            }
        }

        private void btnModify2_Click(object sender, EventArgs e)
        {
            if (lisRecvList.Items.Count < 1) return;
            if (lisRecvList.SelectedItems.Count < 1) return;

            string s_ass_option;

            if (rbtReadable.Checked == false && rbtWritable.Checked == false)
            {
                rbtReadable.Checked = true;
            }

            s_ass_option = "";
            if (rbtReadable.Checked == true) s_ass_option = "R";
            else if (rbtWritable.Checked == true) s_ass_option = "W";

            if (chkRecvNoti.Checked == true) s_ass_option += "Y";
            else s_ass_option += "_";

            if (chkAllowSkip.Checked == true) s_ass_option += "Y";
            else s_ass_option += "_";

            if (chkApprover.Checked == true) s_ass_option += "Y";
            else s_ass_option += "_";

            if (chkAllowGoToAny.Checked == true) s_ass_option += "Y";
            else s_ass_option += "_";

            lisRecvList.SelectedItems[0].SubItems[2].Text = s_ass_option;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (tabAssign.SelectedTab == tbpStep)
            {
                if (CheckCondition("CREATE_PROC_ID") == false) return;
                if (UpdateWorkProcessID(MPGC.MP_STEP_CREATE) == false) return;

                btnRefresh.PerformClick();
            }
            else if (tabAssign.SelectedTab == tbpAuth)
            {
                string s_step_id;
                if (CheckCondition("CREATE_STEP_USER") == false) return;

                s_step_id = lisAssStepList2.SelectedItems[0].Text;
                if (UpdateWorkProcessStepUser(MPGC.MP_STEP_CREATE, s_step_id) == false) return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tabAssign.SelectedTab == tbpStep)
            {
                if (CheckCondition("UPDATE_PROC_ID") == false) return;
                if (UpdateWorkProcessID(MPGC.MP_STEP_UPDATE) == false) return;

                btnRefresh.PerformClick();
            }
            else if (tabAssign.SelectedTab == tbpAuth)
            {
                string s_step_id;
                if (CheckCondition("UPDATE_STEP_USER") == false) return;

                s_step_id = lisAssStepList2.SelectedItems[0].Text;
                if (UpdateWorkProcessStepUser(MPGC.MP_STEP_UPDATE, s_step_id) == false) return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;

            if (tabAssign.SelectedTab == tbpStep || tabAssign.SelectedTab == tbpCopyProcess)
            {
                if (CheckCondition("DELETE_PROC_ID") == false) return;
                if (UpdateWorkProcessID(MPGC.MP_STEP_DELETE) == false) return;

                MPCF.FieldClear(this, this.cdvProcType, this.pnlUserType);
                MPCF.InitListView(lisProcessList);
                MPCF.InitListView(lisAssStepList);
                MPCF.InitListView(lisStepList);
                MPCF.InitListView(lisAssStepList2);
                MPCF.InitListView(lisRecvList);
                numMinProcCount.Enabled = false;

                btnRefresh.PerformClick();
            }
            else if (tabAssign.SelectedTab == tbpAuth)
            {
                string s_step_id;
                if (CheckCondition("DELETE_STEP_USER") == false) return;

                s_step_id = lisAssStepList2.SelectedItems[0].Text;
                if (UpdateWorkProcessStepUser(MPGC.MP_STEP_DELETE, s_step_id) == false) return;

                lisAssStepList2_SelectedIndexChanged(null, null);
            }
        }

        private void btnCopyProcess_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtProcID, 1) == false) return;
            if (MPCF.CheckValue(txtToProcess, 1) == false)
            {
                tabAssign.SelectedTab = tbpCopyProcess;
                txtToProcess.Focus();
                return;
            }

            if (CopyWorkProcess() == false) return;

            btnRefresh.PerformClick();
        }



    }
}
