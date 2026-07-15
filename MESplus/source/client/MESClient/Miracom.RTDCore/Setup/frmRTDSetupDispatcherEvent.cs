using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.RTDCore
{
    public partial class frmRTDSetupDispatcherEvent : Miracom.MESCore.SetupForm02
    {
        public frmRTDSetupDispatcherEvent()
        {
            InitializeComponent();
        }

        private bool CheckCondition(char s_step)
        {

            if (MPCF.CheckValue(cdvService, 1) == false)
            {
                return false;
            }

            if (MPCF.CheckValue(txtSeq, 1) == false)
            {
                return false;
            }
            if (s_step == MPGC.MP_STEP_UPDATE)
            {
                if (MPCF.Trim(txtSeq.Text) != MPCF.Trim(txtSeq.Tag))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(279));
                    txtSeq.Focus();
                    return false;
                }
            }
            if (s_step == MPGC.MP_STEP_CREATE || s_step == MPGC.MP_STEP_UPDATE)
            {
                if (MPCF.ToInt(cdvDepSeq.Text) > 0)
                {
                    if (MPCF.CheckValue(cboCombi, 1) == false)
                    {
                        return false;
                    }

                }

                if (MPCF.Trim(cboChkFlag.Text) != "" && MPCF.Mid(cboChkFlag.Text, 0, 1) != "N")
                {
                    if (MPCF.CheckValue(cdvChkMember, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.Mid(cboChkFlag.Text, 0, 1) == "T")
                    {
                        if (MPCF.CheckValue(cdvTable, 1) == false)
                        {
                            return false;
                        }                        
                    }
                    else 
                    {
                        if (MPCF.CheckValue(txtChkSts, 1) == false)
                        {
                            return false;
                        }
                    }
                    
                }
                if (MPCF.ToInt(cdvDepSeq.Text) == 0)
                {
                    if (MPCF.CheckValue(cboActFlag, 1) == false)
                    {
                        tabGeneral.SelectedTab = tbpAction;
                        cboActFlag.Focus();
                        return false;
                    }
                    
                    
                    if (cboActFlag.SelectedIndex == 3)
                    {
                        if (MPCF.CheckValue(cdvActMember1, 1) == false)
                        {
                            tabGeneral.SelectedTab = tbpAction;
                            cdvActMember1.Focus();
                            return false;
                        }
                        if (MPCF.CheckValue(cdvActMember2, 1) == false)
                        {
                            tabGeneral.SelectedTab = tbpAction;
                            cdvActMember2.Focus();
                            return false;
                        }
                    }
                    else if (cboActFlag.SelectedIndex == 7)
                    {
                        if (MPCF.CheckValue(cdvActMember1, 1) == false)
                        {
                            tabGeneral.SelectedTab = tbpAction;
                            cdvActMember1.Focus();
                            return false;
                        }
                        if (MPCF.CheckValue(cdvActMember2, 1) == false)
                        {
                            tabGeneral.SelectedTab = tbpAction;
                            cdvActMember2.Focus();
                            return false;
                        }
                        if (MPCF.CheckValue(cdvActMember3, 1) == false)
                        {
                            tabGeneral.SelectedTab = tbpAction;
                            cdvActMember3.Focus();
                            return false;
                        }
                        if (MPCF.CheckValue(cdvActMember4, 1) == false)
                        {
                            tabGeneral.SelectedTab = tbpAction;
                            cdvActMember4.Focus();
                            return false;
                        }
                    }
                    else if (cboActFlag.SelectedIndex == 8)
                    {
                        if (MPCF.CheckValue(cdvActMember1, 1) == false)
                        {
                            tabGeneral.SelectedTab = tbpAction;
                            cdvActMember1.Focus();
                            return false;
                        }
                        if (MPCF.CheckValue(cdvActMember2, 1) == false)
                        {
                            tabGeneral.SelectedTab = tbpAction;
                            cdvActMember2.Focus();
                            return false;
                        }
                    }
                    else if (cboActFlag.SelectedIndex == 9)
                    {
                        if (MPCF.CheckValue(cdvActMember1, 1) == false)
                        {
                            tabGeneral.SelectedTab = tbpAction;
                            cdvActMember1.Focus();
                            return false;
                        }
                        if (MPCF.CheckValue(cdvActMember2, 1) == false)
                        {
                            tabGeneral.SelectedTab = tbpAction;
                            cdvActMember2.Focus();
                            return false;
                        }
                        if (MPCF.CheckValue(cdvActMember3, 1) == false)
                        {
                            tabGeneral.SelectedTab = tbpAction;
                            cdvActMember3.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        if (cboActFlag.SelectedIndex != 12 && cboActFlag.SelectedIndex != 14)
                        {
                            if (MPCF.CheckValue(cdvActMember1, 1) == false)
                            {
                                tabGeneral.SelectedTab = tbpAction;
                                cdvActMember1.Focus();
                                return false;
                            }
                        }
                    }
                }
            }

            return true;

        }
        //
        // Update_Dispatcher()
        //       - Create/Update/Delete Dispatcher Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_Dispatcher_Event(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_DISPATCHER_EVENT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            int idx;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("SERVICE_NAME", MPCF.Trim(cdvService.Text));
                in_node.AddInt("SERVICE_SEQ", MPCF.ToInt(txtSeq.Text));
                in_node.AddString("SERVICE_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddInt("DEPENDENT_SEQ", MPCF.ToInt(cdvDepSeq.Text));
                in_node.AddString("DEPENDENT_COMBINATION", MPCF.Trim(cboCombi.Text));
                in_node.AddString("CHK_MEMBER", MPCF.Trim(cdvChkMember.Text));
                if (MPCF.Trim(cboChkFlag.Text) == "")
                {
                    in_node.AddChar("CHK_FLAG", 'N');
                }
                else
                {
                    in_node.AddChar("CHK_FLAG", MPCF.ToChar(MPCF.Mid(cboChkFlag.Text, 0, 1)));
                }
                in_node.AddString("CHK_STS", MPCF.Trim(txtChkSts.Text));
                in_node.AddString("CHK_TBL", MPCF.Trim(cdvTable.Text));
                in_node.AddString("ACTION_ARRAY_1", MPCF.Trim(cdvActArray1.Text));
                in_node.AddString("ACTION_ARRAY_2", MPCF.Trim(cdvActArray2.Text));
                in_node.AddString("ACTION_MEMBER_1", MPCF.Trim(cdvActMember1.Text));
                in_node.AddString("ACTION_MEMBER_2", MPCF.Trim(cdvActMember2.Text));
                in_node.AddString("ACTION_MEMBER_3", MPCF.Trim(cdvActMember3.Text));
                in_node.AddString("ACTION_MEMBER_4", MPCF.Trim(cdvActMember4.Text));
                if (cboActFlag.SelectedIndex == 12)
                {
                    in_node.AddChar("ACTION_FLAG", 'A');
                }
                else if (cboActFlag.SelectedIndex == 0)
                {
                    in_node.AddChar("ACTION_FLAG", 'L');
                }
                else if (cboActFlag.SelectedIndex == 1)
                {
                    in_node.AddChar("ACTION_FLAG", 'R');
                }
                else if (cboActFlag.SelectedIndex == 2)
                {
                    in_node.AddChar("ACTION_FLAG", 'G');
                }
                else if (cboActFlag.SelectedIndex == 3)
                {
                    in_node.AddChar("ACTION_FLAG", 'M');
                }
                else if (cboActFlag.SelectedIndex == 4)
                {
                    in_node.AddChar("ACTION_FLAG", 'F');
                }
                else if (cboActFlag.SelectedIndex == 5)
                {
                    in_node.AddChar("ACTION_FLAG", 'O');
                }
                else if (cboActFlag.SelectedIndex == 6)
                {
                    in_node.AddChar("ACTION_FLAG", 'B');
                }
                else if (cboActFlag.SelectedIndex == 7)
                {
                    in_node.AddChar("ACTION_FLAG", '1');
                }
                else if (cboActFlag.SelectedIndex == 8)
                {
                    in_node.AddChar("ACTION_FLAG", '2');
                }
                else if (cboActFlag.SelectedIndex == 9)
                {
                    in_node.AddChar("ACTION_FLAG", '3');
                }
                else if (cboActFlag.SelectedIndex == 10)
                {
                    in_node.AddChar("ACTION_FLAG", '4');
                }
                else if (cboActFlag.SelectedIndex == 11)
                {
                    in_node.AddChar("ACTION_FLAG", '5');
                }
                else if (cboActFlag.SelectedIndex == 13)  //Add by J.S. 2011.11.10 해당 Lot의 Child Lot들을 찾아서 Dispatching 
                {
                    in_node.AddChar("ACTION_FLAG", 'C');
                }
                else if (cboActFlag.SelectedIndex == 14)  //Added by Chris Jung 2013.09.06 Zero qty Lot들을 찾아서 Dispatching 
                {
                    in_node.AddChar("ACTION_FLAG", 'Z');
                }
                //Add by J.S. 2009.01.19
                if (chkUnselectCapableOnly.Checked == true)
                {
                    in_node.AddChar("UNSELECT_CAPABLE_ONLY_FLAG", 'Y');
                }
                else
                {
                    in_node.AddChar("UNSELECT_CAPABLE_ONLY_FLAG", ' ');
                }

                if (MPCR.CallService("RTD", "RTD_Update_Dispatcher_Event", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        //itm = lisService.Items.Add(MPCF.Trim(cdvService.Text), (int)SMALLICON_INDEX.IDX_DISPATCHER);
                        //itm.SubItems.Add(MPCF.Trim(txtSeq.Text));
                        //itm.Selected = true;
                        //lisService.Sorting = SortOrder.Ascending;
                        
                        //lisService.Sort();
                        //itm.EnsureVisible();
                        btnRefresh.PerformClick();
                        MPCF.FindListItem(lisService, MPCF.Trim(cdvService.Text), 0, MPCF.Trim(txtSeq.Text), 1, false);
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisService, MPCF.Trim(cdvService.Text),0, MPCF.Trim(txtSeq.Text),1, false) == true)
                        {
                            lisService.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtSeq.Text);
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisService, MPCF.Trim(cdvService.Text), 0, MPCF.Trim(txtSeq.Text), 1, false);
                        if (idx != -1)
                        {
                            lisService.Items[idx].Remove();
                        }
                    }
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
        // View_Dispatcher()
        //       - View Dispatcher Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Dispatcher_Event()
        {
            TRSNode in_node = new TRSNode("VIEW_DISPATCHER_EVENT_IN");
            TRSNode out_node = new TRSNode("VIEW_DISPATCHER_EVENT_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SERVICE_NAME", lisService.SelectedItems[0].Text);
                in_node.AddInt("SERVICE_SEQ", MPCF.ToInt(lisService.SelectedItems[0].SubItems[1].Text));

                if (MPCR.CallService("RTD", "RTD_View_Dispatcher_Event", in_node, ref out_node) == false)
                {
                    return false;
                }
                cdvService.Text = MPCF.Trim(out_node.GetString("SERVICE_NAME"));
                txtSeq.Text = MPCF.Trim(out_node.GetInt("SERVICE_SEQ"));
                txtSeq.Tag = MPCF.Trim(out_node.GetInt("SERVICE_SEQ"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("SERVICE_DESC"));

                if (out_node.GetInt("DEPENDENT_SEQ") != 0)
                {
                    cdvDepSeq.Text = MPCF.Trim(out_node.GetInt("DEPENDENT_SEQ"));
                }

                cboCombi.Text = MPCF.Trim(out_node.GetString("DEPENDENT_COMBINATION"));
                cdvChkMember.Text = MPCF.Trim(out_node.GetString("CHK_MEMBER"));
                if (out_node.GetChar("CHK_FLAG") == '=')
                {
                    cboChkFlag.SelectedIndex = 0;
                }
                else if (out_node.GetChar("CHK_FLAG") == '!')
                {
                    cboChkFlag.SelectedIndex = 1;
                }
                else if (out_node.GetChar("CHK_FLAG") == 'N')
                {
                    cboChkFlag.SelectedIndex = 2;
                }
                else if (out_node.GetChar("CHK_FLAG") == '>')
                {
                    cboChkFlag.SelectedIndex = 3;
                }
                else if (out_node.GetChar("CHK_FLAG") == '<')
                {
                    cboChkFlag.SelectedIndex = 4;
                }
                else if (out_node.GetChar("CHK_FLAG") == 'T')
                {
                    cboChkFlag.SelectedIndex = 5;
                }
                else
                {
                    cboChkFlag.SelectedIndex = -1;
                }
                txtChkSts.Text = MPCF.Trim(out_node.GetString("CHK_STS"));
                cdvTable.Text = MPCF.Trim(out_node.GetString("CHK_TBL"));
                
                if (out_node.GetChar("ACTION_FLAG") == 'A')
                {
                    cboActFlag.SelectedIndex = 12;
                }
                else if (out_node.GetChar("ACTION_FLAG") == 'L')
                {
                    cboActFlag.SelectedIndex = 0;
                }
                else if (out_node.GetChar("ACTION_FLAG") == 'R')
                {
                    cboActFlag.SelectedIndex = 1;
                }
                else if (out_node.GetChar("ACTION_FLAG") == 'G')
                {
                    cboActFlag.SelectedIndex = 2;
                }
                else if (out_node.GetChar("ACTION_FLAG") == 'M')
                {
                    cboActFlag.SelectedIndex = 3;
                }
                else if (out_node.GetChar("ACTION_FLAG") == 'F')
                {
                    cboActFlag.SelectedIndex = 4;
                }
                else if (out_node.GetChar("ACTION_FLAG") == 'O')
                {
                    cboActFlag.SelectedIndex = 5;
                }
                else if (out_node.GetChar("ACTION_FLAG") == 'B')
                {
                    cboActFlag.SelectedIndex = 6;
                }
                else if (out_node.GetChar("ACTION_FLAG") == '1')
                {
                    cboActFlag.SelectedIndex = 7;
                }
                else if (out_node.GetChar("ACTION_FLAG") == '2')
                {
                    cboActFlag.SelectedIndex = 8;
                }
                else if (out_node.GetChar("ACTION_FLAG") == '3')
                {
                    cboActFlag.SelectedIndex = 9;
                }
                else if (out_node.GetChar("ACTION_FLAG") == '4')
                {
                    cboActFlag.SelectedIndex = 10;
                }
                else if (out_node.GetChar("ACTION_FLAG") == '5')
                {
                    cboActFlag.SelectedIndex = 11;
                }
                else if (out_node.GetChar("ACTION_FLAG") == 'C') //Add by J.S. 2011.11.10 Child lot을 Dispatch
                {
                    cboActFlag.SelectedIndex = 13;
                }
                else if (out_node.GetChar("ACTION_FLAG") == 'Z') //Added by Chris Jung. 2013.09.06 zero qty lot을 Dispatch
                {
                    cboActFlag.SelectedIndex = 14;
                }

                else
                {
                    cboActFlag.SelectedIndex = -1;
                }

                cdvActArray1.Text = MPCF.Trim(out_node.GetString("ACTION_ARRAY_1"));
                cdvActArray2.Text = MPCF.Trim(out_node.GetString("ACTION_ARRAY_2"));
                cdvActMember1.Text = MPCF.Trim(out_node.GetString("ACTION_MEMBER_1"));
                cdvActMember2.Text = MPCF.Trim(out_node.GetString("ACTION_MEMBER_2"));
                cdvActMember3.Text = MPCF.Trim(out_node.GetString("ACTION_MEMBER_3"));
                cdvActMember4.Text = MPCF.Trim(out_node.GetString("ACTION_MEMBER_4"));

                //Add by J.S. 2009.01.19
                if (out_node.GetChar("UNSELECT_CAPABLE_ONLY_FLAG") == 'Y')
                {
                    chkUnselectCapableOnly.Checked = true;
                }
                else
                {
                    chkUnselectCapableOnly.Checked = false;
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

        private bool View_Service_List( Control control)
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
            } while (in_node.GetString("NEXT_MODULE_NAME") != "" && in_node.GetString("NEXT_MODULE_NAME") != "");

            return true;
        }

        private bool View_Service_Member_List(Control control, int i_depth, char c_list_flag, string s_parent)
        {
            TRSNode in_node = new TRSNode("View_Service_List_In");
            TRSNode out_node = new TRSNode("View_Service_List_Out");
            ListViewItem itmx;
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '3';
                        
            if (MPCF.Trim(cdvModule.Text) == "")
            {
                //Add by J.S. 2009.02.19 cdvService.Text 가 3자리가 안될 경우 문제 발생 부분 처리
                if (cdvService.Text.Length >= 3)
                {
                    in_node.AddString("MODULE_NAME", cdvService.Text.Substring(0, 3));
                }
                else
                {
                    in_node.AddString("MODULE_NAME", cdvService.Text);
                }
            }
            else
            {
                in_node.AddString("MODULE_NAME", cdvModule.Text);
            }
            in_node.AddString("SERVICE_NAME", cdvService.Text);
            in_node.AddString("NEXT_MEMBER_NAME", "");
            in_node.AddChar("DIRECTION", 'I');
            in_node.AddInt("MEMBER_DEPTH", i_depth);
            in_node.AddString("PARENT_MEMBER_PATH", s_parent);
            if (c_list_flag == 'Y')
            {
                in_node.AddString("MEMBER_TYPE", "List");
            }           

            if (MPCR.CallService("SVM", "SVM_View_Service_Member_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (int i = 0; i < out_node.GetList(0).Count; i++)
            {
                itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("MEMBER_NAME")), (int)SMALLICON_INDEX.IDX_KEY);
                if (((ListView)control).Columns.Count > 1)
                {

                    itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("MEMBER_DESC")));
                }
                ((ListView)control).Items.Add(itmx);
            }

            return true;
        }

        private void cdvTable_ButtonPress(object sender, EventArgs e)
        {
            cdvTable.Init();
            MPCF.InitListView(cdvTable.GetListView);
            cdvTable.Columns.Add("Bonus Code", 150, HorizontalAlignment.Left);
            cdvTable.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTable.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMTableList(cdvTable.GetListView, '1');
        }

       

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
            if (Update_Dispatcher_Event(MPGC.MP_STEP_UPDATE) == true)
            {
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                    MPCF.FindListItem(lisService, cdvService.Text, false);
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
            if (Update_Dispatcher_Event(MPGC.MP_STEP_DELETE) == true)
            {
                MPCF.FieldClear(this.pnlRight);
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            if (Update_Dispatcher_Event(MPGC.MP_STEP_CREATE) == true)
            {
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                    MPCF.FindListItem(lisService, cdvService.Text, false);
                }

            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (RTDLIST.ViewDispatcherEventList(lisService, '1', null, "", "") == true)
                {
                    lblDataCount.Text = lisService.Items.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemNextPartial(lisService, txtFind.Text, true, false);

        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisService, txtFind.Text, 0, true, false);

        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisService, this.Text, "");

        }

        private void lisService_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);
                if (lisService.SelectedItems.Count > 0)
                {
                    if (View_Dispatcher_Event() == false)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void frmRTDSetupDispatcherEvent_Load(object sender, EventArgs e)
        {
            lblDataCount.Text = "";
            if (RTDLIST.ViewDispatcherEventList(lisService, '1', null, "", "") == true)
            {
                lblDataCount.Text = lisService.Items.Count.ToString();
            }
            else
            {
                return;
            }
            if (lisService.Items.Count > 0)
            {
                lisService.Items[0].Selected = true;
            }
        }

        private void cdvDepSeq_TextChanged(object sender, EventArgs e)
        {
            if (MPCF.ToInt(cdvDepSeq.Text) > 0)
            {
                MPCF.FieldClear(tbpAction);
                MPCF.FieldEnableStatus(tbpAction, false,null, null, null, null, null);
            }
            else
            {
                cboCombi.SelectedIndex = -1;
                MPCF.FieldEnableStatus(tbpAction, true, null, null, null, null, null);
            }
        }

        private void cdvDepSeq_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvService.Text) == "")
            {
                return;
            }
            cdvDepSeq.Init();
            MPCF.InitListView(cdvDepSeq.GetListView);
            cdvDepSeq.Columns.Add("Seq", 150, HorizontalAlignment.Left);
            cdvDepSeq.SelectedSubItemIndex = 0;
            RTDLIST.ViewDispatcherEventList(cdvDepSeq.GetListView, '2', null, "", cdvService.Text);
        }

        private void cboChkFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MPCF.Mid(cboChkFlag.Text, 0, 1) == "N")
            {
                MPCF.FieldClear(grpCheck, cboChkFlag);
            }
            else if (MPCF.Mid(cboChkFlag.Text, 0, 1) == "T")
            {
                txtChkSts.Text = "";
            }
            else
            {
                cdvTable.Text = "";
            }
        }

        private void cboActFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActFlag.SelectedIndex == 12)
            {
                lblActMember1.Text = "Action Member 1";
                lblActMember2.Text = "Action Member 2";
                lblActMember3.Text = "Action Member 3";
                lblActMember4.Text = "Action Member 4";
                cdvActMember1.Text = "";
                cdvActMember1.Enabled = false;
                cdvActMember2.Text = "";
                cdvActMember2.Enabled = false;
                cdvActMember3.Text = "";
                cdvActMember3.Enabled = false;
                cdvActMember4.Text = "";
                cdvActMember4.Enabled = false;
            }
            else if(cboActFlag.SelectedIndex == 3)
            {
                lblActMember1.Text = "Member ID of " + cboActFlag.Text;
                lblActMember2.Text = "Member ID of Mat Ver";
                lblActMember3.Text = "Action Member 3";
                lblActMember4.Text = "Action Member 4";
                cdvActMember1.Enabled = true;
                cdvActMember2.Text = "";
                cdvActMember2.Enabled = true;
                cdvActMember3.Text = "";
                cdvActMember3.Enabled = false;
                cdvActMember4.Text = "";
                cdvActMember4.Enabled = false;
            }
            else if (cboActFlag.SelectedIndex == 7)
            {
                lblActMember1.Text = "Member ID of Material";
                lblActMember2.Text = "Member ID of Mat Ver";
                lblActMember3.Text = "Member ID of Flow";
                lblActMember4.Text = "Member ID of Operation";
                cdvActMember1.Enabled = true;
                cdvActMember2.Text = "";
                cdvActMember2.Enabled = true;
                cdvActMember3.Text = "";
                cdvActMember3.Enabled = true;
                cdvActMember4.Text = "";
                cdvActMember4.Enabled = true;
            }
            else if (cboActFlag.SelectedIndex == 8)
            {
                lblActMember1.Text = "Member ID of Flow";
                lblActMember2.Text = "Member ID of Operation";
                lblActMember3.Text = "Action Member 3";
                lblActMember4.Text = "Action Member 4";
                cdvActMember1.Enabled = true;
                cdvActMember2.Text = "";
                cdvActMember2.Enabled = true;
                cdvActMember3.Text = "";
                cdvActMember3.Enabled = false;
                cdvActMember4.Text = "";
                cdvActMember4.Enabled = false;
            }
            else if (cboActFlag.SelectedIndex == 9)
            {
                lblActMember1.Text = "Member ID of Material";
                lblActMember2.Text = "Member ID of Mat Ver";
                lblActMember3.Text = "Member ID of Operation";
                lblActMember4.Text = "Action Member 4";
                cdvActMember1.Enabled = true;
                cdvActMember2.Text = "";
                cdvActMember2.Enabled = true;
                cdvActMember3.Text = "";
                cdvActMember3.Enabled = true;
                cdvActMember4.Text = "";
                cdvActMember4.Enabled = false;
            }   
            else if(cboActFlag.SelectedIndex == 13)
            {
                lblActMember1.Text = "Member ID of " + "Mother Lot";
                lblActMember2.Text = "Action Member 2";
                lblActMember3.Text = "Action Member 3";
                lblActMember4.Text = "Action Member 4";
                cdvActMember1.Enabled = true;
                cdvActMember2.Text = "";
                cdvActMember2.Enabled = false;
                cdvActMember3.Text = "";
                cdvActMember3.Enabled = false;
                cdvActMember4.Text = "";
                cdvActMember4.Enabled = false;
            }
             /* Added By Chris Jung for zero qty lot calculation */
            else if (cboActFlag.SelectedIndex == 14)
            {
                lblActMember1.Text = "Member ID";
                cdvActMember1.Enabled = false;
                cdvActMember1.Text = "";
                cdvActMember2.Text = "";
                cdvActMember2.Enabled = false;
                cdvActMember3.Text = "";
                cdvActMember3.Enabled = false;
                cdvActMember4.Text = "";
                cdvActMember4.Enabled = false;
            }
            else
            {
                lblActMember1.Text = "Member ID of " + cboActFlag.Text;
                lblActMember2.Text = "Action Member 2";
                lblActMember3.Text = "Action Member 3";
                lblActMember4.Text = "Action Member 4";
                cdvActMember1.Enabled = true;
                cdvActMember2.Text = "";
                cdvActMember2.Enabled = false;
                cdvActMember3.Text = "";
                cdvActMember3.Enabled = false;
                cdvActMember4.Text = "";
                cdvActMember4.Enabled = false;
            }
           
        }

        private void cdvService_ButtonPress(object sender, EventArgs e)
        {
            cdvService.Init();
            MPCF.InitListView(cdvService.GetListView);
            cdvService.Columns.Add("Bonus Code", 150, HorizontalAlignment.Left);
            cdvService.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvService.SelectedSubItemIndex = 0;
            View_Service_List(cdvService.GetListView);
        }

        private void cdvChkMember_ButtonPress(object sender, EventArgs e)
        {
             if (MPCF.CheckValue(cdvService, 1) == false) return;
            cdvChkMember.Init();
            MPCF.InitListView(cdvChkMember.GetListView);
            cdvChkMember.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvChkMember.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvChkMember.SelectedSubItemIndex = 0;

            View_Service_Member_List(cdvChkMember.GetListView, 0, ' ', "");
        }

        private void cdvActMember1_ButtonPress(object sender, EventArgs e)
        {
            string s_parent;
            int i_depth;
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            
            cdvTemp = ((Miracom.UI.Controls.MCCodeView.MCCodeView)sender);
            if (MPCF.CheckValue(cdvService, 1) == false) return;
            if (MPCF.CheckValue(cboActFlag, 1) == false) return;

            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;

            if (MPCF.Trim(cdvActArray1.Text) != "")
            {
                if (MPCF.Trim(cdvActArray2.Text) != "")
                {
                    s_parent = cdvActArray1.Text + "/"+ cdvActArray2.Text;
                    i_depth = 2;
                }
                else
                {
                    s_parent = cdvActArray1.Text;
                    i_depth = 1;
                }
            }
            else
            {
                s_parent = "";
                i_depth = 0;
            }
            View_Service_Member_List(cdvTemp.GetListView, i_depth, ' ', s_parent);
        }

        private void cdvModule_ButtonPress(object sender, EventArgs e)
        {
            cdvModule.Init();
            MPCF.InitListView(cdvModule.GetListView);
            cdvModule.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvModule.SelectedSubItemIndex = 0;

            TRSNode in_node = new TRSNode("View_Module_List_In");
            TRSNode out_node = new TRSNode("View_Module_List_Out");
            ListViewItem viewItem;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (MPCR.CallService("SVM", "SVM_View_Module_List", in_node, ref out_node) == false)
            {
                return;
            }

            for (int i = 0; i < out_node.GetList(0).Count; i++)
            {
                viewItem = cdvModule.GetListView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("MODULE_NAME"),
                                                               (int)SMALLICON_INDEX.IDX_MODULE));
            }
        }

        private void cdvActArray1_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvService, 1) == false) return;
            cdvActArray1.Init();
            MPCF.InitListView(cdvActArray1.GetListView);
            cdvActArray1.Columns.Add("Name", 50, HorizontalAlignment.Left);
            cdvActArray1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvActArray1.SelectedSubItemIndex = 0;

            View_Service_Member_List(cdvActArray1.GetListView, 0, 'Y', "");
        }

        private void cdvActArray2_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvService, 1) == false) return;
            if (MPCF.CheckValue(cdvActArray1, 1) == false) return;
            cdvActArray2.Init();
            MPCF.InitListView(cdvActArray2.GetListView);
            cdvActArray2.Columns.Add("Name", 50, HorizontalAlignment.Left);
            cdvActArray2.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvActArray2.SelectedSubItemIndex = 0;

            View_Service_Member_List(cdvActArray2.GetListView, 1, 'Y', cdvActArray1.Text);
        }

        private void cdvActArray1_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvActArray2.Text = "";
            cdvActMember1.Text = "";
            cdvActMember2.Text = "";
            cdvActMember3.Text = "";
            cdvActMember4.Text = "";
        }

        private void cdvActArray2_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvActMember1.Text = "";
            cdvActMember2.Text = "";
            cdvActMember3.Text = "";
            cdvActMember4.Text = "";
        }     
    }
}

