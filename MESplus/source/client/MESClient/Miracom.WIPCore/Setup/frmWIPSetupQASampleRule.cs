
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
//   File Name   : frmWIPSetupQASampleRule.vb
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
	public partial class frmWIPSetupQASampleRule : Miracom.MESCore.SetupForm02
	{
		public frmWIPSetupQASampleRule()
		{
			InitializeComponent();
		}

		#region " Variable definition "
		bool b_load_flag;

		#endregion
		
		#region " Function definition 

		// SetGroupCmfItem()
		//       - Set Group / Cmf Property to control
		// Return Value
		//       -
		// Arguments
		//		-
		
		
		// CheckCondition()
		//       - Check the conditions before transaction
		// Return Value
		//       - boolean : True / False
		// Arguments
		//       - ByVal FuncName As String : Function Name
		//
        private bool CheckCondition(char ProcStep)
		{
            int i;
            int iSum=0;

            if (MPCF.CheckValue(txtRuleID, 1) == false)
			{
				return false;
			}

            switch (ProcStep)
			{
                case '1':
                    int row_cnt;
                    int j;
                    int increase=1;

                    if (MPCF.CheckValue(txtRuleID, 1) == false)
                    {
                        return false;
                    }
                    if (chkUnit1SMPFlag.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvUnit1SMPType, 1) == false)
                        {
                            return false;
                        }
                        if(txtSMPSize1.Enabled==true && MPCF.ToDbl(txtSMPSize1.Text) == 0)
                        {
                            MPCF.ShowMsgBox( MPCF.GetMessage(108) );
                            txtSMPSize1.Focus();
                            return false;
                        }
                        if (cdvUnit1SMPSel.Enabled == true)
                        {
                            if (MPCF.CheckValue(cdvUnit1SMPSel, 1) == false)
                            {
                                return false;
                            }
                        }
                        if (spdUnit1SMP.Enabled == true)
                        {
                            for (i = 0; i < spdUnit1SMP_Sheet1.ColumnCount; i++)
                            {
                                if (spdUnit1SMP_Sheet1.GetValue(0, i).ToString() == FarPoint.Win.CheckValue.True.ToString())
                                    iSum++;
                            }

                            row_cnt = spdUnit1SMP_Sheet1.RowCount / 2;

                            for (j = 0; j < row_cnt; j++)
                            {
                                for (i = 0; i < spdUnit1SMP_Sheet1.ColumnCount; i++)
                                {
                                    if (spdUnit1SMP_Sheet1.GetValue(j + increase, i).ToString() == FarPoint.Win.CheckValue.True.ToString())
                                        iSum++;
                                }
                                increase++;
                            }

                            if(iSum != MPCF.ToInt(txtSMPSize1.Text))
                            {
                                MPCF.ShowMsgBox( MPCF.GetMessage(108) );
                                spdUnit1SMP.Focus();
                                return false;
                            }
                        }
                    }
                    if (chkUnit2SMPFlag.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvUnit2SMPType, 1) == false)
                        {
                            return false;
                        }
                        if(txtSMPSize2.Enabled==true && MPCF.ToDbl(txtSMPSize2.Text) == 0)
                        {
                            MPCF.ShowMsgBox( MPCF.GetMessage(108) );
                            txtSMPSize2.Focus();
                            return false;
                        }
                        if (cdvUnit2SMPSel.Enabled == true)
                        {
                            if (MPCF.CheckValue(cdvUnit2SMPSel, 1) == false)
                            {
                                return false;
                            }
                        }
                    }
                    break;

                case '2':

                    if (MPCF.CheckValue(txtPassCntForSkip, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtSkipCntByPass, 1) == false)
					{
						return false;
					}
                    if (MPCF.CheckValue(txtTSTCntByFail, 1) == false)
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
		private bool View_Sample_QARule()
		{
            TRSNode in_node = new TRSNode("VIEW_QA_RULE_SMP_IN");
            TRSNode out_node = new TRSNode("VIEW_QA_RULE_SMP_OUT");

            int i = 0;
            int quotient = 0;
            int remainder = 0;
            int increase = 1;
            int compare_quotient =0;

			try
			{				
                MPCF.FieldClear(this.tbpCMF);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RULE_ID", txtRuleID.Text);
                in_node.AddString("RULE_TYPE", txtRuleType.Text);

                if (MPCR.CallService("WIP", "WIP_View_QA_Rule", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (spdUnit1SMP_Sheet1.RowCount * spdUnit1SMP_Sheet1.ColumnCount / 2 < out_node.GetString("UNIT1_SMP_SEL_LOC").Length)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(319));
                    return false;
                }

                Setting_Default_Spread();

                txtRuleID.Text = MPCF.Trim(out_node.GetString("RULE_ID"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("RULE_DESC"));
                cdvSMPType.Text = MPCF.Trim(out_node.GetString("SMP_TYPE"));
                
                if (out_node.GetChar("UNIT1_SMP_FLAG")=='Y') chkUnit1SMPFlag.Checked=true;
                else chkUnit1SMPFlag.Checked = false;
                cdvUnit1SMPType.Text = "";
                cdvUnit1SMPType.Text = MPCF.Trim(out_node.GetString("UNIT1_SMP_TYPE"));
                txtSMPSize1.Text  = out_node.GetDouble("UNIT1_SMP_SIZE").ToString();
                cdvUnit1SMPSel.Text = "";
                cdvUnit1SMPSel.Text = MPCF.Trim(out_node.GetString("UNIT1_SMP_SEL_TYPE"));

                for (i = 0; i < out_node.GetString("UNIT1_SMP_SEL_LOC").Length; i++)
                {
                    quotient = i / 25;
                    remainder = i % 25;

                    if (compare_quotient != quotient)
                    {
                        increase++;
                    }
                    if (out_node.GetString("UNIT1_SMP_SEL_LOC")[i] == 'Y')
                    {
                        spdUnit1SMP_Sheet1.SetValue(quotient + increase, remainder, FarPoint.Win.CheckValue.True);
                    }
                    compare_quotient = quotient;
                }

                if (out_node.GetChar("UNIT2_SMP_FLAG")=='Y') chkUnit2SMPFlag.Checked = true;
                else chkUnit2SMPFlag.Checked = false;

                cdvUnit2SMPType.Text = MPCF.Trim(out_node.GetString("UNIT2_SMP_TYPE"));
                txtSMPSize2.Text = out_node.GetDouble("UNIT2_SMP_SIZE").ToString() ;
                cdvUnit2SMPSel.Text = MPCF.Trim(out_node.GetString("UNIT2_SMP_SEL_TYPE"));

                if (out_node.GetChar("LOT_SMP_FLAG") == 'Y') chkLotSample.Checked = true;
                else chkLotSample.Checked = false;

                txtPassCntForSkip.Text = MPCF.Trim(out_node.GetInt("PASS_CNT_FOR_SKIP"));
                txtSkipCntByPass.Text = MPCF.Trim(out_node.GetInt("SKIP_CNT_BY_PASS"));
                txtTSTCntByFail.Text = MPCF.Trim(out_node.GetInt("TST_CNT_BY_FAIL"));

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

                txtCreateUser.Text = MPCF.Trim(out_node.GetString( "CREATE_USER"));
                txtCreateTime.Text = MPCF.Trim(out_node.GetString( "CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString( "UPDATE_USER"));
                txtUpdateTime.Text = MPCF.Trim(out_node.GetString("UPDATE_TIME"));
				
				return true;
			}
			catch (Exception ex)
			{
				MPCF.ShowMsgBox(ex.Message);
                return false;
            }
		}

        // Update_Sample_QARule()
		//       -  Update Sample Qa Rule
		// Return Value
		//       - Boolean : True or False
		// Arguments
		//		- ByVal c_step As String     : Process Step
		//
		private bool Update_Sample_QARule(char c_step)
		{
            ListViewItem item;
            TRSNode in_node = new TRSNode("UPDATE_QA_RULE_IN");
            TRSNode out_node = new TRSNode("UPDATE_QA_RULE_OUT");

			int idx;
            int i;
            int row_cnt = 0;
            int j;
            int increase = 1;
            string sTemp = "";
			try
			{

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("RULE_ID", txtRuleID.Text);
                in_node.AddString("RULE_DESC", txtDesc.Text);
                in_node.AddString("SMP_TYPE", cdvSMPType.Text);

                if(chkUnit1SMPFlag.Checked==true)
                    in_node.AddChar("UNIT1_SMP_FLAG", 'Y');
                else
                    in_node.AddChar("UNIT1_SMP_FLAG", 'N');

                in_node.AddString("UNIT1_SMP_TYPE", cdvUnit1SMPType.Text);
                in_node.AddDouble("UNIT1_SMP_SIZE", MPCF.ToDbl(txtSMPSize1.Text));
                in_node.AddString("UNIT1_SMP_SEL_TYPE", cdvUnit1SMPSel.Text);

                sTemp="";

                row_cnt = spdUnit1SMP_Sheet1.RowCount / 2;

                for (j = 0; j < row_cnt; j++)
                {
                    for (i = 0; i < spdUnit1SMP_Sheet1.ColumnCount; i++)
                    {
                        if (spdUnit1SMP_Sheet1.GetValue(j + increase, i).ToString() == FarPoint.Win.CheckValue.True.ToString())
                            sTemp = sTemp + "Y";
                        else
                            sTemp = sTemp + "N";
                    }
                    increase++;
                }

                in_node.AddString("UNIT1_SMP_SEL_LOC", sTemp);

                if (chkUnit2SMPFlag.Checked == true)
                    in_node.AddChar("UNIT2_SMP_FLAG", 'Y');
                else
                    in_node.AddChar("UNIT2_SMP_FLAG", 'N');

                in_node.AddString("UNIT2_SMP_TYPE", cdvUnit2SMPType.Text);
                in_node.AddDouble("UNIT2_SMP_SIZE", MPCF.ToDbl(txtSMPSize2.Text));
                in_node.AddString("UNIT2_SMP_SEL_TYPE", cdvUnit2SMPSel.Text);

                if (chkLotSample.Checked == false)
                    in_node.AddChar("LOT_SMP_FLAG", 'N');
                else
                    in_node.AddChar("LOT_SMP_FLAG", 'Y');

                in_node.AddInt("SKIP_CNT_BY_PASS", MPCF.ToInt(txtSkipCntByPass.Text));
                in_node.AddInt("TST_CNT_BY_FAIL", MPCF.ToInt(txtTSTCntByFail.Text));
                in_node.AddInt("PASS_CNT_FOR_SKIP", MPCF.ToInt(txtPassCntForSkip.Text));

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



                if (MPCR.CallService("WIP", "WIP_Update_QA_Sample_Rule", in_node, ref out_node) == false)
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
						if (MPCF.FindListItem(lisQARule, MPCF.Trim(txtRuleID.Text),false) == true)
						{
							lisQARule.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
						}
					}
					else if (c_step == MPGC.MP_STEP_DELETE)
					{
                        idx = MPCF.FindListItemIndex(lisQARule, MPCF.Trim(txtRuleID.Text), false);
						if (idx != - 1)
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
        //		
        //
        private void SetGroupCmfItem(string s_rule_type)
        {
            MPCR.SetCMFItem(MPGC.TAP_CMF_QA_SAMPLE_RULE, "lblCmf", "cdvCmf", grpCMF);
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
            int i_sample_rule_count;

            MPCF.FieldClear(this);
            MPCF.FieldVisible(tbpCMF, false);
            MPCF.InitListView(lisQARule);

            cdvUnit1SMPType.Text = "";
            cdvUnit1SMPType.Enabled = false;
            cdvUnit1SMPType.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
            txtSMPSize1.Text = "0";
            txtSMPSize1.Enabled = false;
            txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
            cdvUnit1SMPSel.Text = "";
            cdvUnit1SMPSel.Enabled = false;
            cdvUnit1SMPSel.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
            spdUnit1SMP.Enabled = false;

            cdvUnit2SMPType.Text = "";
            cdvUnit2SMPType.Enabled = false;
            cdvUnit2SMPType.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
            txtSMPSize2.Text = "0";
            txtSMPSize2.Enabled = false;
            txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
            cdvUnit2SMPSel.Text = "";
            cdvUnit2SMPSel.Enabled = false;
            cdvUnit2SMPSel.BackColor = Color.FromKnownColor(KnownColor.MenuBar);

            i_sample_rule_count = MPGO.UseSampleCount();

            if (i_sample_rule_count == MPGC.MP_SAMPLE_RULE_COUNT_25)
            {
                this.ClientSize = new System.Drawing.Size(921, 760);
                grpUnit1Info.Size = new System.Drawing.Size(643, 153);
                spdUnit1SMP.Size = new System.Drawing.Size(507, 45);
                spdUnit1SMP_Sheet1.RemoveRows(2, 6);

            }
            else if (i_sample_rule_count == MPGC.MP_SAMPLE_RULE_COUNT_50)
            {
                this.ClientSize = new System.Drawing.Size(921, 760);
                grpUnit1Info.Size = new System.Drawing.Size(643, 193);
                spdUnit1SMP.Size = new System.Drawing.Size(507, 88);
                spdUnit1SMP_Sheet1.RemoveRows(4, 4);
            }

            else if (i_sample_rule_count == MPGC.MP_SAMPLE_RULE_COUNT_75)
            {
                this.ClientSize = new System.Drawing.Size(921, 774);
                grpUnit1Info.Size = new System.Drawing.Size(643, 233);
                spdUnit1SMP.Size = new System.Drawing.Size(507, 131);
                spdUnit1SMP_Sheet1.RemoveRows(6, 2);
            }

            else if (i_sample_rule_count == MPGC.MP_SAMPLE_RULE_MAX_COUNT)
            {
                this.ClientSize = new System.Drawing.Size(921, 818);
                grpUnit1Info.Size = new System.Drawing.Size(643, 273);
                spdUnit1SMP.Size = new System.Drawing.Size(507, 174);
            }
        }

        // Setting_Default_Spread()
        //       -  Set Spread
        // Return Value
        //       
        // Arguments
        //		
        //
        private void Setting_Default_Spread()
        {
            int row_cnt = 0;
            int i;
            int j;
            int increase = 1;

            row_cnt = spdUnit1SMP_Sheet1.RowCount /2;

            for (j = 0; j < row_cnt; j++)
            {
                for (i = 0; i < spdUnit1SMP_Sheet1.ColumnCount; i++)
                {
                    spdUnit1SMP_Sheet1.SetValue(j + increase, i, FarPoint.Win.CheckValue.False);
                }
                increase++;
            }
        }
		
		#endregion
		
		private void frmWIPSetupQASampleRule_Load(object sender, System.EventArgs e)
		{
            Setting_Default();
            txtRuleType.Text = MPGC.SAMPLE_RULE;
		}

        private void frmWIPSetupQASampleRule_Activated(object sender, System.EventArgs e)
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
		
		private void cdvType_ButtonPress(object sender, System.EventArgs e)
		{
			Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
			
			cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
			
			cdvTemp.Init();
			MPCF.InitListView(cdvTemp.GetListView);
			cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
			cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
			cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.TAP_QA_RULE_TYPE, 0, null, MPGV.gsCentralFactory);
			if (cdvTemp.AddEmptyRow(1) == false)
			{
				return;
			}
		}
		
		private void btnCreate_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
                if (CheckCondition('1') == true)
                {
                    if (chkLotSample.Checked == true)
                    {
                        if (CheckCondition('2') == false)
                        {
                            return;
                        }
                    }

                    if (Update_Sample_QARule(MPGC.MP_STEP_CREATE) == false)
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
                    if (Update_Sample_QARule(MPGC.MP_STEP_UPDATE) == false)
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
                if (Update_Sample_QARule(MPGC.MP_STEP_DELETE) == true)
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

        private void cdvAreaID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvUnit1SMPType.Text = "";
        }

        private void cdvSMPType_ButtonPress(object sender, System.EventArgs e)
		{
            cdvSMPType.Init();
			MPCF.InitListView(cdvUnit1SMPType.GetListView);
            cdvSMPType.Columns.Add("Sample Type", 50, HorizontalAlignment.Left);
            cdvSMPType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSMPType.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvSMPType.GetListView, '1', MPGC.TAP_QA_SMP_TYPE) == false)
			{
				return;
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
                View_Sample_QARule();
            }
            else
            {
                btnDelete.Text = MPCF.FindLanguage("Delete", 1);
            }
        }

        private void cdvUnit1SMPType_ButtonPress(object sender, EventArgs e)
        {
            cdvUnit1SMPType.Init();
            MPCF.InitListView(cdvUnit1SMPType.GetListView);
            cdvUnit1SMPType.Columns.Add("Sample Type", 50, HorizontalAlignment.Left);
            cdvUnit1SMPType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUnit1SMPType.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvUnit1SMPType.GetListView, '1', MPGC.TAP_QA_SMP_QTY_TYPE) == false)
            {
                return;
            }
        }

        private void cdvUnit2SMPType_ButtonPress(object sender, EventArgs e)
        {
            cdvUnit2SMPType.Init();
            MPCF.InitListView(cdvUnit2SMPType.GetListView);
            cdvUnit2SMPType.Columns.Add("Sample Type", 50, HorizontalAlignment.Left);
            cdvUnit2SMPType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUnit2SMPType.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvUnit2SMPType.GetListView, '1', MPGC.TAP_QA_SMP_QTY_TYPE) == false)
            {
                return;
            }
        }

        private void cdvUnit1SMPSel_ButtonPress(object sender, EventArgs e)
        {
            cdvUnit1SMPSel.Init();
            MPCF.InitListView(cdvUnit1SMPSel.GetListView);
            cdvUnit1SMPSel.Columns.Add("Sample Select Type", 50, HorizontalAlignment.Left);
            cdvUnit1SMPSel.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUnit1SMPSel.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvUnit1SMPSel.GetListView, '1', MPGC.TAP_QA_SMP_SEL_TYPE) == false)
            {
                return;
            }
        }

        private void cdvUnit2SMPSel_ButtonPress(object sender, EventArgs e)
        {
            cdvUnit2SMPSel.Init();
            MPCF.InitListView(cdvUnit2SMPSel.GetListView);
            cdvUnit2SMPSel.Columns.Add("Sample Select Type", 50, HorizontalAlignment.Left);
            cdvUnit2SMPSel.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUnit2SMPSel.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvUnit2SMPSel.GetListView, '1', MPGC.TAP_QA_SMP_SEL_TYPE) == false)
            {
                return;
            }
        }

        private void cdvUnit1SMPType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvUnit1SMPType.Text == MPGC.TAP_QA_SMP_QTY_TYPE_A)
            {
                txtSMPSize1.Text = "0";
                txtSMPSize1.Enabled = false;
                txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                cdvUnit1SMPSel.Text = "";
                cdvUnit1SMPSel.Enabled = false;
                cdvUnit1SMPSel.BackColor = Color.FromKnownColor(KnownColor.MenuBar);

                Setting_Default_Spread();

                spdUnit1SMP.Enabled = false;
            }
            else if (cdvUnit1SMPType.Text == MPGC.TAP_QA_SMP_QTY_TYPE_AQL)
            {
                txtSMPSize1.Text = "0";
                txtSMPSize1.Enabled = false;
                txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                cdvUnit1SMPSel.Text = MPGC.TAP_QA_SMP_QTY_TYPE_M;
                cdvUnit1SMPSel.Enabled = false;
                cdvUnit1SMPSel.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                Setting_Default_Spread();
                spdUnit1SMP.Enabled = false;
            }
            else if (cdvUnit1SMPType.Text == MPGC.TAP_QA_SMP_QTY_TYPE_R)
            {
                txtSMPSize1.Text = "0";
                txtSMPSize1.Enabled = false;
                txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                cdvUnit1SMPSel.Text = "";
                cdvUnit1SMPSel.Enabled = true;
                cdvUnit1SMPSel.BackColor = Color.FromKnownColor(KnownColor.Window);
                Setting_Default_Spread();
                spdUnit1SMP.Enabled = true;
            }
            else if (cdvUnit1SMPType.Text == MPGC.TAP_QA_SMP_QTY_TYPE_S)
            {
                txtSMPSize1.Text = "0";
                txtSMPSize1.Enabled = true;
                txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.Window);
                cdvUnit1SMPSel.Text = "";
                cdvUnit1SMPSel.Enabled = true;
                cdvUnit1SMPSel.BackColor = Color.FromKnownColor(KnownColor.Window);
                Setting_Default_Spread();
                spdUnit1SMP.Enabled = true;
            }
            else if (cdvUnit1SMPType.Text == MPGC.TAP_QA_SMP_QTY_TYPE_M)
            {
                txtSMPSize1.Text = "0";
                txtSMPSize1.Enabled = false;
                txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                cdvUnit1SMPSel.Text = "";
                cdvUnit1SMPSel.Enabled = true;
                cdvUnit1SMPSel.BackColor = Color.FromKnownColor(KnownColor.Window);
                Setting_Default_Spread();
                spdUnit1SMP.Enabled = true;
            }
        }

        private void cdvUnit1SMPSel_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvUnit1SMPSel.Text == MPGC.TAP_QA_SMP_QTY_TYPE_R)
            {
                Setting_Default_Spread();
                spdUnit1SMP.Enabled = false;
            }
            else if (cdvUnit1SMPSel.Text == MPGC.TAP_QA_SMP_QTY_TYPE_S)
            {
                Setting_Default_Spread();
                spdUnit1SMP.Enabled = true;
            }
            else if (cdvUnit1SMPSel.Text == MPGC.TAP_QA_SMP_QTY_TYPE_M)
            {
                Setting_Default_Spread();
                spdUnit1SMP.Enabled = false;
            }
        }

        private void chkUnit1SMPFlag_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkUnit1SMPFlag.Checked == false)
            {
                cdvUnit1SMPType.Text = "";
                cdvUnit1SMPType.Enabled=false;
                cdvUnit1SMPType.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                txtSMPSize1.Text = "0";
                txtSMPSize1.Enabled = false;
                txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                cdvUnit1SMPSel.Text = "";
                cdvUnit1SMPSel.Enabled = false;
                cdvUnit1SMPSel.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                Setting_Default_Spread();
                spdUnit1SMP.Enabled = false;
            }
            else
            {
                cdvUnit1SMPType.Text = "";
                cdvUnit1SMPType.Enabled = true;
                cdvUnit1SMPType.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtSMPSize1.Text = "0";
                txtSMPSize1.Enabled = true;
                txtSMPSize1.BackColor = Color.FromKnownColor(KnownColor.Window);
                cdvUnit1SMPSel.Text = "";
                cdvUnit1SMPSel.Enabled = true;
                cdvUnit1SMPSel.BackColor = Color.FromKnownColor(KnownColor.Window);
                Setting_Default_Spread();
                spdUnit1SMP.Enabled = true;
            }
        }

        private void cdvUnit2SMPType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvUnit2SMPType.Text == MPGC.TAP_QA_SMP_QTY_TYPE_A)
            {
                txtSMPSize2.Text = "0";
                txtSMPSize2.Enabled = false;
                txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                cdvUnit2SMPSel.Text = "";
                cdvUnit2SMPSel.Enabled = false;
                cdvUnit2SMPSel.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
            }
            else if (cdvUnit2SMPType.Text == MPGC.TAP_QA_SMP_QTY_TYPE_AQL)
            {
                txtSMPSize2.Text = "0";
                txtSMPSize2.Enabled = false;
                txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                cdvUnit2SMPSel.Text = "";
                cdvUnit2SMPSel.Enabled = true;
                cdvUnit2SMPSel.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            else if (cdvUnit2SMPType.Text == MPGC.TAP_QA_SMP_QTY_TYPE_R)
            {
                txtSMPSize2.Text = "0";
                txtSMPSize2.Enabled = false;
                txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                cdvUnit2SMPSel.Text = "";
                cdvUnit2SMPSel.Enabled = true;
                cdvUnit2SMPSel.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            else if (cdvUnit2SMPType.Text == MPGC.TAP_QA_SMP_QTY_TYPE_S)
            {
                txtSMPSize2.Text = "0";
                txtSMPSize2.Enabled = true;
                txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.Window);
                cdvUnit2SMPSel.Text = "";
                cdvUnit2SMPSel.Enabled = true;
                cdvUnit2SMPSel.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            else if (cdvUnit2SMPType.Text == MPGC.TAP_QA_SMP_QTY_TYPE_M)
            {
                txtSMPSize2.Text = "0";
                txtSMPSize2.Enabled = false;
                txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                cdvUnit2SMPSel.Text = "";
                cdvUnit2SMPSel.Enabled = true;
                cdvUnit2SMPSel.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
        }

        private void chkUnit2SMPFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnit2SMPFlag.Checked == false)
            {
                cdvUnit2SMPType.Text = "";
                cdvUnit2SMPType.Enabled = false;
                cdvUnit2SMPType.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                txtSMPSize2.Text = "0";
                txtSMPSize2.Enabled = false;
                txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
                cdvUnit2SMPSel.Text = "";
                cdvUnit2SMPSel.Enabled = false;
                cdvUnit2SMPSel.BackColor = Color.FromKnownColor(KnownColor.MenuBar);
            }
            else
            {
                cdvUnit2SMPType.Text = "";
                cdvUnit2SMPType.Enabled = true;
                cdvUnit2SMPType.BackColor = Color.FromKnownColor(KnownColor.Window);
                txtSMPSize2.Text = "0";
                txtSMPSize2.Enabled = true;
                txtSMPSize2.BackColor = Color.FromKnownColor(KnownColor.Window);
                cdvUnit2SMPSel.Text = "";
                cdvUnit2SMPSel.Enabled = true;
                cdvUnit2SMPSel.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
        }

        private void cdvUnit1SMPType_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvUnit1SMPType_SelectedItemChanged(null,null);
        }

        private void cdvUnit1SMPSel_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvUnit1SMPSel_SelectedItemChanged(null, null);
        }

        private void cdvUnit2SMPType_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvUnit2SMPType_SelectedItemChanged(null, null);
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
