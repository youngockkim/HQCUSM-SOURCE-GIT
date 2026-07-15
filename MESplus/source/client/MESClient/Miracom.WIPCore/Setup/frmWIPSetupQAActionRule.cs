
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Data;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;


//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupQAActionRule.vb
//   Description : QA Rule Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - SetGroupCmfItem() : Set Group/Cmf property to control
//       - CheckCondition() : Check the conditions before transaction
//       - Update_Resource() : Create/Update/Delete Resource
//       - View_Resource() : Find Resource and View Resource
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-09 : Created by H.K. Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.WIPCore
{
	public partial class frmWIPSetupQAActionRule : Miracom.MESCore.SetupForm02
	{
		
		public frmWIPSetupQAActionRule()
		{
			InitializeComponent();
		}
		
		#region " Variable definition "

		bool b_load_flag;

		#endregion
		
		#region " Function definition "

		// CheckCondition()
		//       - Check the conditions before transaction
		// Return Value
		//       - boolean : True / False
		// Arguments
		//       - ByVal FuncName As String : Function Name
		//
        private bool CheckCondition(char ProcStep)
		{
            if (MPCF.CheckValue(txtRuleID, 1) == false)
			{
				return false;
			}

            switch (ProcStep)
			{
				case '1':
                    if (MPCF.CheckValue(txtRuleID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue( cdvResultFlag, 1) == false)
					{
						return false;
					}
                    if (MPCF.CheckValue(cdvProtectType, 1) == false)
                    {
                        return false;
                    }
					if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
					{
						return false;
					}
					break;
			}
			return true;
		}

		// Refresh_QARulelist()
		//       -  Refresh QA Rule List
		// Return Value
		//       - Boolean : True or False
		// Arguments
		//       -
		//
		private bool Refresh_QARulelist()
		{
			string SelectedItem;
			
			try
			{
                SelectedItem = MPCF.Trim(txtRuleID.Text);
				MPCF.FieldClear(this.pnlRight);
				lisQARule.Items.Clear();
				lblDataCount.Text = "";

                if (QCMLIST.ViewQARuleList(lisQARule, '1', txtRuleType.Text, "") == true)
				{
					lblDataCount.Text = MPCF.Trim(lisQARule.Items.Count);
				}
				
				if (lisQARule.Items.Count > 0 && SelectedItem != "")
				{
					MPCF.FindListItem(lisQARule, SelectedItem, false);
				}
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
			return true;
		}

        // View_QARule()
        //       -  View QA Rule
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Action_QARule()
        {
            TRSNode in_node = new TRSNode("VIEW_QA_RULE_ACT_IN");
            TRSNode out_node = new TRSNode("VIEW_QA_RULE_ACT_OUT");

            try
            {
                MPCF.FieldClear(this.tbpGeneral1);
                MPCF.FieldClear(this.tbpCMF);


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RULE_ID", txtRuleID.Text);
                in_node.AddString("RULE_TYPE", txtRuleType.Text);

                if (MPCR.CallService("WIP", "WIP_View_QA_Rule", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtRuleID.Text = MPCF.Trim(out_node.GetString("RULE_ID"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("RULE_DESC"));

                cdvAlarmCode.Text = MPCF.Trim(out_node.GetString("ALARM_CODE"));
                cdvResultFlag.Text = MPCF.Trim(out_node.GetString("PASS_FLAG"));
                cdvProtectType.Text = MPCF.Trim(out_node.GetChar("PROTECT_END"));

                cdvCMF1.Text = MPCF.Trim(out_node.GetString("QA_RULE_CMF_1"));
                cdvCMF2.Text = MPCF.Trim(out_node.GetString("QA_RULE_CMF_2"));
                cdvCMF3.Text = MPCF.Trim(out_node.GetString("QA_RULE_CMF_3"));
                cdvCMF4.Text = MPCF.Trim(out_node.GetString("QA_RULE_CMF_4"));
                cdvCMF5.Text = MPCF.Trim(out_node.GetString("QA_RULE_CMF_5"));
                cdvCMF6.Text = MPCF.Trim(out_node.GetString("QA_RULE_CMF_6"));
                cdvCMF7.Text = MPCF.Trim(out_node.GetString("QA_RULE_CMF_7"));
                cdvCMF8.Text = MPCF.Trim(out_node.GetString("QA_RULE_CMF_8"));
                cdvCMF9.Text = MPCF.Trim(out_node.GetString("QA_RULE_CMF_9"));
                cdvCMF10.Text = MPCF.Trim(out_node.GetString("QA_RULE_CMF_10"));

                txtActCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER"));
                txtActCreateTime.Text = MPCF.Trim(out_node.GetString("CREATE_TIME"));
                txtActUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER"));
                txtActUpdateTime.Text = MPCF.Trim(out_node.GetString("UPDATE_TIME"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // Update_Action_QARule()
        //       -  Update Action Rule
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Update_Action_QARule(char c_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_QA_RULE_IN");
            TRSNode out_node = new TRSNode("UPDATE_QA_RULE_OUT");
            ListViewItem item;

            int idx;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("RULE_ID", txtRuleID.Text);
                in_node.AddString("RULE_DESC", txtDesc.Text);
                
                in_node.AddString("PASS_FLAG", cdvResultFlag.Text);
                in_node.AddChar("PROTECT_END", MPCF.ToChar(cdvProtectType.Text));
                in_node.AddString("ALARM_CODE", cdvAlarmCode.Text);
                in_node.AddString("QA_RUL_CMF_1", cdvCMF1.Text);
                in_node.AddString("QA_RUL_CMF_2", cdvCMF2.Text);
                in_node.AddString("QA_RUL_CMF_3", cdvCMF3.Text);
                in_node.AddString("QA_RUL_CMF_4", cdvCMF4.Text);
                in_node.AddString("QA_RUL_CMF_5", cdvCMF5.Text);
                in_node.AddString("QA_RUL_CMF_6", cdvCMF6.Text);
                in_node.AddString("QA_RUL_CMF_7", cdvCMF7.Text);
                in_node.AddString("QA_RUL_CMF_8", cdvCMF8.Text);
                in_node.AddString("QA_RUL_CMF_9", cdvCMF9.Text);
                in_node.AddString("QA_RUL_CMF_10", cdvCMF10.Text);

                if (MPCR.CallService("WIP", "WIP_Update_QA_Action_Rule", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        item = lisQARule.Items.Add(txtRuleID.Text, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        item.SubItems.Add(txtDesc.Text);
                        item.Selected = true;
                        lisQARule.Sorting = SortOrder.Ascending;
                        lisQARule.Sort();
                        item.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisQARule, MPCF.Trim(txtRuleID.Text), false) == true)
                        {
                            lisQARule.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisQARule, MPCF.Trim(txtRuleID.Text), false);
                        if (idx != -1)
                        {
                                lisQARule.Items[idx].Remove();
                        }
                        lblDataCount.Text = MPCF.Trim(lisQARule.Items.Count);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            return true;
        }

        // GetFisrtFocusItem()
        //       -  Get Focus
        // Return Value
        //       
        // Arguments
        //       
        //
		public virtual Control GetFisrtFocusItem()
		{
			try
			{
				return this.txtRuleType;
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
				return null;
			}
		}

        // SetGroupCmfItem()
        //       -  Set Cmf Item
        // Return Value
        //       
        // Arguments
        //       - ByVal RuleType As String : RuleType
        //
        private void SetGroupCmfItem(string s_rule_type)
        {
            MPCR.SetCMFItem(MPGC.TAP_CMF_QA_ACTION_RULE, "lblCmf", "cdvCmf", grpCMF);
        }

        // Setting_Default()
        //       -  Set Default
        // Return Value
        //       
        // Arguments
        //       
        //
        private void Setting_Default()
        {
            MPCF.FieldClear(this);
            MPCF.FieldVisible(tbpCMF, false);
            MPCF.InitListView(lisQARule);
        }

		#endregion
		
		private void frmWIPSetupQAActionRule_Load(object sender, System.EventArgs e)
		{
            Setting_Default();
            txtRuleType.Text = MPGC.TAP_ACTION_RULE;
		}

        private void frmWIPSetupQAActionRule_Activated(object sender, System.EventArgs e)
		{	
			if (b_load_flag == false)
			{
				lisQARule.Focus();
				lblDataCount.Text = "";

                if (MPCF.Trim(txtRuleType.Text) != "")
                {
                    if (QCMLIST.ViewQARuleList(lisQARule, '1', txtRuleType.Text, "") == true)
                    {
                        if (lisQARule.Items.Count > 0)
                        {
                            lisQARule.Items[0].Selected = true;
                        }
                        lblDataCount.Text = MPCF.Trim(lisQARule.Items.Count);
                    }
                    else
                    {
                        return;
                    }
                }
				b_load_flag = true;
			}
		}
		
		private void btnCreate_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
                if (CheckCondition('1') == true)
                {
                    if (Update_Action_QARule(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                    MPCF.ShowMsgBox(MPCF.GetMessage(52));
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
		
		private void btnUpdate_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
                if (CheckCondition('1') == true)
                {
                    if (Update_Action_QARule(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }
                    MPCF.ShowMsgBox(MPCF.GetMessage(52));
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
		
		private void btnDelete_Click(System.Object sender, System.EventArgs e)
		{
            try
            {
                if (Update_Action_QARule(MPGC.MP_STEP_DELETE) == true)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(52));
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
                if (Refresh_QARulelist() == false)
				{
					return;
				}
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
			}
		}

		private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			MPCR.CheckCMFKeyPress(sender, e);
        }
		
		private void txtMaxProcCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
			{
				if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
				{
					e.Handled = true;
				}
			}
		}

		private void btnNext_Click(System.Object sender, System.EventArgs e)
		{
            MPCF.FindListItemNextPartial(lisQARule, txtFind.Text, true, false);
		}
		
		private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
		{
            MPCF.FindListItemPartial(lisQARule, txtFind.Text, 0, true, false);
		}

        private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void lisQARule_Click(object sender, EventArgs e)
        {
            if (lisQARule.SelectedItems.Count > 0)
            {
                txtRuleID.Text = lisQARule.SelectedItems[0].Text;
                View_Action_QARule();
            }
            else
            {
                btnDelete.Text = MPCF.FindLanguage("Delete", 1);
            }
        }

        private void cdvResultFlag_ButtonPress(object sender, EventArgs e)
        {
            cdvResultFlag.Init();
            MPCF.InitListView(cdvResultFlag.GetListView);
            cdvResultFlag.Columns.Add("QA Result", 50, HorizontalAlignment.Left);
            cdvResultFlag.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResultFlag.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvResultFlag.GetListView, '1', MPGC.TAP_QA_RESULT) == false)
            {
                return;
            }
        }

        private void cdvProtectType_ButtonPress(object sender, EventArgs e)
        {
            cdvProtectType.Init();
            MPCF.InitListView(cdvProtectType.GetListView);
            cdvProtectType.Columns.Add("QA Protect", 50, HorizontalAlignment.Left);
            cdvProtectType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvProtectType.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvProtectType.GetListView, '1', MPGC.TAP_YESORNO) == false)
            {
                return;
            }
        }

        private void cdvAlarmCode_ButtonPress(object sender, EventArgs e)
        {
            cdvAlarmCode.Init();
            MPCF.InitListView(cdvAlarmCode.GetListView);
            cdvAlarmCode.Columns.Add("QA Protect Type", 50, HorizontalAlignment.Left);
            cdvAlarmCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAlarmCode.SelectedSubItemIndex = 0;
            if (ALMLIST.ViewAlarmMsgList(cdvAlarmCode.GetListView, '1', MPGC.MP_ALM_NORMAL) == false)
            {
                return;
            }
        }

        private void txtRuleType_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                lisQARule.Items.Clear();
                SetGroupCmfItem(txtRuleType.Text);

                if (QCMLIST.ViewQARuleList(lisQARule, '1', txtRuleType.Text, "") == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisQARule.Items.Count);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
	}
	
}
