using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupIDGenerator : Miracom.MESCore.SetupForm02
    {
        #region " Constant Definition "

        private const int COL_FIELD_ARGUMENT = 0;
        private const int COL_FIELD_VALUE = 1;

        private const int COL_HIST_GEN_ID = 0;
        private const int COL_HIST_SEQ_NUM = 1;
        private const int COL_HIST_CREATE_TIME = 2;
        private const int COL_HIST_KEY_START = 3;
        
        #endregion

        public frmWIPSetupIDGenerator()
        {
            InitializeComponent();
        }

        private void InitRightPanel()
        {
            MPCF.FieldClear(pnlRight);
            MPCF.ClearList(lisSeq);

            MPCR.ChangeControlEnabled(this, btnAdd, true);
            MPCR.ChangeControlEnabled(this, btnDel, true);
            MPCR.ChangeControlEnabled(this, btnSeqUpdate, true);
            MPCR.ChangeControlEnabled(this, btnUp, true);
            MPCR.ChangeControlEnabled(this, btnDown, true);

            txtGenString.Enabled = true;
            cboSave.Enabled = true;
            //chkApprovalFlag.Enabled = true;       // 2014.01.23 DM KIM 주석 처리
        }

        private bool CheckCondition(char s_step)
        {
            int i;
                                    
            if (MPCF.CheckValue(txtRule, 1) == false)
            {
                return false;
            }
            if (s_step == MPGC.MP_STEP_CREATE || s_step == MPGC.MP_STEP_UPDATE)
            {
                if (MPCF.CheckValue(cdvGenType, 1) == false)
                {
                    return false;
                }
                if (cboSave.SelectedIndex == -1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108) + "[Save Point]");
                    cboSave.Focus();
                    return false;
                }
                if (cboSave.SelectedIndex == 1)
                {
                    if (cboNotUsedID.SelectedIndex == -1)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108) + "[Not used ID search option]");
                        cboNotUsedID.Focus();
                        return false;
                    }
                }
            }
            else if (s_step == 'A')
            {
                if (lisRule.SelectedItems.Count <= 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    lisRule.Select();
                    return false;
                }
                if (cboRuleType.SelectedIndex == -1)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cboRuleType.Focus();
                    return false;
                }
                if (cboRuleType.SelectedIndex == 0) //Fixed String
                {
                    if (MPCF.CheckValue(txtFixedString, 1) == false)
                    {
                        return false;
                    }
                }
                else if (cboRuleType.SelectedIndex == 1) //Field Value
                {
                    if (rbnConst.Checked == false && rbnTable.Checked == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        rbnConst.Checked = true;
                        return false;
                    }
                    if (MPCF.CheckValue(cdvConstant, 1) == false)
                    {
                        return false;
                    }
                    if (rbnTable.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvCol, 1) == false)
                        {
                            return false;
                        }
                    }
                   
                }
                else if (cboRuleType.SelectedIndex == 2) //Date Value
                {
                    if (chkUseCal.Checked == true)
                    {
                        if (MPCF.CheckValue(cdvCalID, 1) == false)
                        {
                            return false;
                        }
                    }
                }
                else if (cboRuleType.SelectedIndex == 3) //Seq Value
                {
                    if (MPCF.CheckValue(txtSize, 2) == false)
                    {
                        return false;
                    }
                    if (MPCF.ToInt(txtSize.Text) <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(114));
                        txtSize.Focus();
                        return false;
                    }
                   
                    if (chkNum.Checked == false && chkAlpha.Checked == false)
                    {
                        if (MPCF.CheckValue(txtCharSet, 1) == false)
                        {
                            return false;
                        }
                    }
                    if (chkNum.Checked == true)
                    {
                        if (this.cboNumOrder.SelectedIndex == -1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cboNumOrder.Focus();
                            return false;
                        }
                        if (this.cboOdd.SelectedIndex == -1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cboOdd.Focus();
                            return false;
                        }
                    }
                    if (chkAlpha.Checked == true)
                    {
                        if (this.cboAlphaOrder.SelectedIndex == -1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cboAlphaOrder.Focus();
                            return false;
                        }
                        if (this.cboOddAlpha.SelectedIndex == -1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cboOddAlpha.Focus();
                            return false;
                        }
                        if (this.cboCase.SelectedIndex == -1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cboCase.Focus();
                            return false;
                        }
                    }
                    if (chkNum.Checked == true && chkAlpha.Checked == true)
                    {
                        if (this.cboOrder.SelectedIndex == -1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cboOrder.Focus();
                            return false;
                        }
                    }
                    if (MPCF.CheckValue(txtCreateValue, 1) == false)
                    {
                        tabSeq.SelectedTab = tbpInitial;
                        return false;
                    }
                    // 가변길이 Seq 를 지원하도록 주석처리함.
                    //if (MPCF.ToInt(txtSize.Text) != txtCreateValue.Text.Length)
                    //{
                    //    MPCF.ShowMsgBox(MPCF.GetMessage(278));
                    //    txtCreateValue.Focus();
                    //    return false;
                    //}
                    if (chkAllowCycle.Checked == true)
                    {
                        if (MPCF.CheckValue(txtCycleValue, 1) == false)
                        {
                            tabSeq.SelectedTab = tbpInitial;
                            return false;
                        }
                        // 가변길이 Seq 를 지원하도록 주석처리함.
                        //if (MPCF.ToInt(txtSize.Text) != txtCycleValue.Text.Length)
                        //{
                        //    MPCF.ShowMsgBox(MPCF.GetMessage(278));
                        //    txtCycleValue.Focus();
                        //    return false;
                        //}
                    }
                }
                else if (cboRuleType.SelectedIndex == 4) //Blank Value
                {
                    if (MPCF.CheckValue(txtBlank, 1) == false)
                    {
                       return false;
                    }
                }
            }
            else if (s_step == 'E')
            {
                if (lisRule.SelectedItems.Count <= 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    lisRule.Select();
                    return false;
                }
                if (lisSeq.SelectedItems.Count <= 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    lisSeq.Select();
                    return false;
                }
            }
                //seq up
            else if (s_step == '1')
            {
                if (lisRule.SelectedItems.Count <= 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    lisRule.Select();
                    return false;
                }
                if (lisSeq.SelectedItems.Count <= 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    lisSeq.Select();
                    return false;
                }
                if (lisSeq.SelectedItems[0].Text == "1")
                {
                    return false;
                }
            }
            //seq down
            else if (s_step == '2')
            {
                if (lisRule.SelectedItems.Count <= 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    lisRule.Select();
                    return false;
                }
                if (lisSeq.SelectedItems.Count <= 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    lisSeq.Select();
                    return false;
                }
                if (lisSeq.SelectedItems[0].Index == lisSeq.Items.Count -1)
                {
                    return false;
                }
            }
            // Test
            else if (s_step == 'T')
            {
                for (i = 0; i < spdFieldValue.Sheets[0].RowCount; i++)
                {
                    if (MPCF.Trim(spdFieldValue.Sheets[0].Cells[i, COL_FIELD_VALUE].Value) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        spdFieldValue.Sheets[0].SetActiveCell(i, COL_FIELD_VALUE);
                        return false;                      
                    }
                }
            }
            
            return true;
        }

        private bool View_Rule()
        {

            TRSNode in_node = new TRSNode("VIEW_ID_RULE_IN");
            TRSNode out_node = new TRSNode("VIEW_ID_RULE_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RULE_ID", MPCF.Trim(lisRule.SelectedItems[0].Text));

            if (MPCR.CallService("WIP", "WIP_View_ID_Rule", in_node, ref out_node) == false)
            {
                return false;
            }

            txtRuleDesc.Text = MPCF.Trim(out_node.GetString("RULE_DESC"));
            cdvGenType.Text = out_node.GetChar("GEN_TYPE").ToString();

            cboSave.SelectedIndex = MPCF.ToInt(out_node.GetChar("SAVE_POINT"));
            if (out_node.GetChar("FULFILL_SEQ") == 'Y')
            {
                chkFulFillSeq.Checked = true;
            }
            else
            {
                chkFulFillSeq.Checked = false;
            }
            if (out_node.GetChar("NOT_USED_ID_SEARCH_OPTION") == 'H')
            {
                cboNotUsedID.SelectedIndex = 0;
            }
            else
            {
                cboNotUsedID.SelectedIndex = 1;
            }

            if (out_node.GetChar("APPROVAL_FLAG") == 'Y')
            {
                chkApprovalFlag.Checked = true;
                chkFulFillSeq.Enabled = false;
                cboNotUsedID.Enabled = false;
                cboSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnAdd.Enabled = false;
                btnSeqUpdate.Enabled = false;
                btnDel.Enabled = false;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnTest.Enabled = false;

                btnApproval.Text = MPCF.FindLanguage("Cancel Approval", 1);
                btnApproval.Tag = MPGC.MP_STEP_CANCEL_APPROVAL;
            }
            else
            {
                chkApprovalFlag.Checked = false;
                cboSave.Enabled = true;
                if (cboSave.SelectedIndex == 1)
                {
                    chkFulFillSeq.Enabled = true;
                    cboNotUsedID.Enabled = true;
                }

                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnAdd, true);
                MPCR.ChangeControlEnabled(this, btnSeqUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDel, true);
                MPCR.ChangeControlEnabled(this, btnUp, true);
                MPCR.ChangeControlEnabled(this, btnDown, true);
                MPCR.ChangeControlEnabled(this, btnTest, true);

                btnApproval.Text = MPCF.FindLanguage("Approval", 1);
                btnApproval.Tag = MPGC.MP_STEP_APPROVAL;
            }

            SetArgumentList(out_node.GetInt("MAX_ARGUMENT"));

            return true;

        }

        private bool Update_Rule(char s_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_RULE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            ListViewItem itm;
            int idx;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = s_step;
            in_node.AddString("RULE_ID", MPCF.Trim(txtRule.Text));

            in_node.AddString("RULE_DESC", MPCF.Trim(txtRuleDesc.Text));
            in_node.AddChar("GEN_TYPE", MPCF.ToChar(cdvGenType.Text));

            in_node.AddChar("SAVE_POINT", MPCF.ToChar(cboSave.SelectedIndex));
            in_node.AddChar("FULFILL_SEQ", chkFulFillSeq.Checked == true ? 'Y' : ' ');
            in_node.AddChar("NOT_USED_ID_SEARCH_OPTION", cboNotUsedID.SelectedIndex == 0 ? 'H' : 'R');


            if (MPCR.CallService("WIP", "WIP_Update_ID_Rule", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            if (MPGV.gbListAutoRefresh == false)
            {
                if (s_step == MPGC.MP_STEP_CREATE)
                {
                    itm = lisRule.Items.Add(txtRule.Text, (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE);
                    itm.SubItems.Add(txtRuleDesc.Text);
                    itm.Selected = true;
                    lisRule.Sorting = SortOrder.Ascending;
                    lisRule.Sort();
                    itm.EnsureVisible();
                }
                else if (s_step == MPGC.MP_STEP_UPDATE)
                {
                    if (MPCF.FindListItem(lisRule, MPCF.Trim(txtRule.Text), false) == true)
                    {
                        lisRule.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtRuleDesc.Text);
                    }
                }
                else if (s_step == MPGC.MP_STEP_DELETE)
                {
                    idx = MPCF.FindListItemIndex(lisRule, MPCF.Trim(txtRule.Text), false);
                    if (idx != -1)
                    {
                        lisRule.Items[idx].Remove();
                    }
                }
                lblDataCount.Text = lisRule.Items.Count.ToString();
            }

            return true;

        }

        private bool Update_Rule_Def(char s_step, bool b_success_message)
        {

            TRSNode in_node = new TRSNode("UPDATE_RULE_DEF_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            string s_key_1 = "";
            string s_key_2 = "";
            DialogResult dr;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = s_step;
            in_node.AddChar("CONFIRM_FLAG", ' ');
            in_node.AddString("RULE_ID", MPCF.Trim(txtRule.Text));

            if (s_step == MPGC.MP_STEP_CREATE)
            {
                in_node.AddInt("RULE_SEQ", lisSeq.Items.Count + 1);
            }
            else
            {
                in_node.AddInt("RULE_SEQ", MPCF.ToInt(lisSeq.SelectedItems[0].Text));
            }

            if(cboRuleType.SelectedIndex == 0) //Fixed String
            {
                in_node.AddChar("RULE_TYPE", 'F');
                in_node.AddString("DATA_1", MPCF.Trim(txtFixedString.Text));
            }
            else if (cboRuleType.SelectedIndex == 1) //Field Value
            {
                in_node.AddChar("RULE_TYPE", 'V');
                in_node.AddChar("FIELD_TYPE", rbnConst.Checked == true ? 'C' : 'T');
                in_node.AddInt("START_POS", MPCF.ToInt(txtStartPos.Text));
                in_node.AddInt("LENGTH", MPCF.ToInt(txtLength.Text));
                in_node.AddString("DATA_1", MPCF.Trim(cdvConstant.Text));
                in_node.AddString("DATA_2", MPCF.Trim(cdvCol.Text));
                in_node.AddString("DATA_3", MPCF.Trim(txtQuery.Text));
            }
            else if (cboRuleType.SelectedIndex == 2) //Date Value
            {
                in_node.AddChar("RULE_TYPE", 'D');
                in_node.AddChar("USE_ALT_DATE", chkUseDate.Checked == true ? 'Y' : ' ');
                if (chkUseDate.Checked == true)
                {
                    in_node.AddChar("OVR_DATE_FLAG", chkOverride.Checked == true ? 'Y' : ' ');
                }
                in_node.AddChar("USE_CALENDAR", chkUseCal.Checked == true ? 'Y' : ' ');

                in_node.AddString("DATA_1", MPCF.Trim(txtFormat.Text));
                in_node.AddString("DATA_2", MPCF.ToStandardTime(((DateTime)(uccStart.Value)), MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(((DateTime)(udtStart.Value)), MPGC.MP_CONVERT_TIME_FORMAT));
                if (chkUseCal.Checked == true)
                {
                    in_node.AddString("DATA_3", MPCF.Trim(cdvCalID.Text));
                }

            }
            else if (cboRuleType.SelectedIndex == 3) //Seq Value
            {
                in_node.AddChar("RULE_TYPE", 'S');
                in_node.AddChar("USE_NUMERIC", chkNum.Checked == true ? 'Y' : ' ');
                if (chkNum.Checked == true)
                {
                    in_node.AddChar("NUM_INC_ORDER", MPCF.ToChar(cboNumOrder.SelectedIndex));
                    in_node.AddChar("NUM_ODD_EVEN", MPCF.ToChar(cboOdd.SelectedIndex));
                }
                in_node.AddChar("USE_ALPHA", chkAlpha.Checked == true ? 'Y' : ' ');
                if (chkAlpha.Checked == true)
                {
                    in_node.AddChar("ALP_INC_ORDER", MPCF.ToChar(cboAlphaOrder.SelectedIndex));
                    in_node.AddChar("ALP_CASE", MPCF.ToChar(cboCase.SelectedIndex));
                    in_node.AddChar("ALP_ODD_EVEN", MPCF.ToChar(cboOddAlpha.SelectedIndex));
                }
                if (chkNum.Checked == true && chkAlpha.Checked == true)
                {
                    in_node.AddChar("NUM_ALP_ORDER", MPCF.ToChar(cboOrder.SelectedIndex));
                }
                if (chkNum.Checked == false && chkAlpha.Checked == false)
                {
                    in_node.AddString("DATA_1", MPCF.Trim(txtCharSet.Text));
                }
                in_node.AddString("DATA_2", MPCF.Trim(txtExclude.Text));
                in_node.AddInt("LENGTH", MPCF.ToInt(txtSize.Text));
                in_node.AddInt("DEP_RULE_SEQ", MPCF.ToInt(cdvDepSeq.Text));
                in_node.AddChar("ALLOW_CYCLE_SEQ", chkAllowCycle.Checked == true ? 'Y' : ' ');
                if (chkAllowCycle.Checked == true)
                {
                    in_node.AddString("CYCLE_INIT_VALUE", MPCF.Trim(txtCycleValue.Text));
                }
                in_node.AddString("CREATE_INIT_VALUE", MPCF.Trim(txtCreateValue.Text));
                s_key_1 += chkMaterial.Checked == true ? 'Y' : '_';
                s_key_1 += chkMatVer.Checked == true ? 'Y' : '_';
                s_key_1 += chkFlow.Checked == true ? 'Y' : '_';
                s_key_1 += chkOper.Checked == true ? 'Y' : '_';
                s_key_1 += chkResType.Checked == true ? 'Y' : '_';
                s_key_1 += chkResGrp.Checked == true ? 'Y' : '_';
                s_key_1 += chkResource.Checked == true ? 'Y' : '_';
                s_key_1 += chkFactory.Checked == true ? 'Y' : '_';
                s_key_1 += chkLotID.Checked == true ? 'Y' : '_';
                s_key_1 += chkSublotID.Checked == true ? 'Y' : '_';
                s_key_1 += chkDatetime.Checked == true ? 'Y' : '_';
                s_key_1 += "_________";
                in_node.AddString("SEQ_KEY_1", s_key_1);

                s_key_2 += chkKey1.Checked == true ? 'Y' : '_';
                s_key_2 += chkKey2.Checked == true ? 'Y' : '_';
                s_key_2 += chkKey3.Checked == true ? 'Y' : '_';
                s_key_2 += chkKey4.Checked == true ? 'Y' : '_';
                s_key_2 += chkKey5.Checked == true ? 'Y' : '_';
                s_key_2 += chkKey6.Checked == true ? 'Y' : '_';
                s_key_2 += chkKey7.Checked == true ? 'Y' : '_';
                s_key_2 += chkKey8.Checked == true ? 'Y' : '_';
                s_key_2 += chkKey9.Checked == true ? 'Y' : '_';
                s_key_2 += chkKey10.Checked == true ? 'Y' : '_';

                in_node.AddString("SEQ_KEY_2", s_key_2);
            }
            else if (cboRuleType.SelectedIndex == 4) //Blank Value
            {
                in_node.AddChar("RULE_TYPE", 'B');
                in_node.AddInt("LENGTH", MPCF.ToInt( txtBlank.Text));
            }

            MPCR.CallService("WIP", "WIP_Update_Rule_Def", in_node, ref out_node, true);
            if (out_node.MsgCode == "WIP-0360")
            {
                dr = MPCF.ShowMsgBox(out_node.Msg, MessageBoxButtons.YesNoCancel, 3);
                if ( dr == DialogResult.Yes)
                {
                    //seq 초기화
                    in_node.SetChar("CONFIRM_FLAG", 'I');

                }
                else if (dr == DialogResult.No)
                {
                    //seq 유지
                    in_node.SetChar("CONFIRM_FLAG", 'K');
                }
                else
                {
                    return false;
                }

                if (MPCR.CallService("WIP", "WIP_Update_Rule_Def", in_node, ref out_node) == false)
                {
                    return false;
                }
            }
            else
            {
                if (MPCR.CheckContinueProc(out_node) == false)
                {
                    return false;
                }                
            }

            SetArgumentList(out_node.GetInt("MAX_ARGUMENT"));
            

            if (b_success_message == true)
            {
                MPCR.ShowSuccessMsg(out_node);
            }

            return true;

        }

        private bool View_Rule_Def()
        {

            TRSNode in_node = new TRSNode("VIEW_RULE_DEF_IN");
            TRSNode out_node = new TRSNode("VIEW_RULE_DEF_OUT");
            DateTime dtTranTime;
            string sTranTime;
            string s_key_1;
            string s_key_2;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("RULE_ID", MPCF.Trim(lisRule.SelectedItems[0].Text));
            in_node.AddInt("RULE_SEQ", MPCF.ToInt(lisSeq.SelectedItems[0].Text));

            if (MPCR.CallService("WIP", "WIP_View_Rule_Def", in_node, ref out_node) == false)
            {
                return false;
            }
            if (out_node.GetChar("RULE_TYPE") == 'F')
            {
                cboRuleType.SelectedIndex = 0;
            }
            else if (out_node.GetChar("RULE_TYPE") == 'V')
            {
                cboRuleType.SelectedIndex = 1;
            }
            if (out_node.GetChar("RULE_TYPE") == 'D')
            {
                cboRuleType.SelectedIndex = 2;
            }
            if (out_node.GetChar("RULE_TYPE") == 'S')
            {
                cboRuleType.SelectedIndex = 3;
            }
            if (out_node.GetChar("RULE_TYPE") == 'B')
            {
                cboRuleType.SelectedIndex = 4;
            }

            if (cboRuleType.SelectedIndex == 0) //Fixed String
            {
                txtFixedString.Text = MPCF.Trim(out_node.GetString("DATA_1"));
            }
            else if (cboRuleType.SelectedIndex == 1) //Field Value
            {
                if (out_node.GetChar("FIELD_TYPE") == 'C')
                {
                    rbnConst.Checked = true;
                }
                else
                {
                    rbnTable.Checked = true;
                }
                txtStartPos.Text = out_node.GetInt("START_POS").ToString();
                txtLength.Text = out_node.GetInt("LENGTH").ToString();
                cdvConstant.Text = MPCF.Trim(out_node.GetString("DATA_1"));
                cdvCol.Text = MPCF.Trim(out_node.GetString("DATA_2"));
                txtQuery.Text = MPCF.Trim(out_node.GetString("DATA_3"));

            }
            else if (cboRuleType.SelectedIndex == 2) //Date Value
            {
                if (out_node.GetChar("USE_ALT_DATE") == 'Y')
                {
                    chkUseDate.Checked = true;
                }
                else
                {
                    chkUseDate.Checked = false;
                }
                if (out_node.GetChar("OVR_DATE_FLAG") == 'Y')
                {
                    chkOverride.Checked = true;
                }
                else
                {
                    chkOverride.Checked = false;
                }
                if (out_node.GetChar("USE_CALENDAR") == 'Y')
                {
                    chkUseCal.Checked = true;
                }
                else
                {
                    chkUseCal.Checked = false;
                }
                txtFormat.Text = MPCF.Trim(out_node.GetString("DATA_1"));
                sTranTime = "";
                sTranTime = out_node.GetString("DATA_2");
                dtTranTime = new DateTime(MPCF.ToInt(MPCF.Mid(sTranTime, 0, 4)), MPCF.ToInt(MPCF.Mid(sTranTime, 4, 2)), MPCF.ToInt(MPCF.Mid(sTranTime, 6, 2))
                , MPCF.ToInt(MPCF.Mid(sTranTime, 8, 2)), MPCF.ToInt(MPCF.Mid(sTranTime, 10, 2)), MPCF.ToInt(MPCF.Mid(sTranTime, 12, 2)));

                uccStart.Value = dtTranTime;
                udtStart.Value = dtTranTime;
                cdvCalID.Text = MPCF.Trim(out_node.GetString("DATA_3"));

            }
            else if (cboRuleType.SelectedIndex == 3) //Seq Value
            {
                if (out_node.GetChar("USE_NUMERIC") == 'Y')
                {
                    chkNum.Checked = true;
                    cboNumOrder.SelectedIndex = MPCF.ToInt(out_node.GetChar("NUM_INC_ORDER"));
                    cboOdd.SelectedIndex = MPCF.ToInt(out_node.GetChar("NUM_ODD_EVEN"));
                }
                else
                {
                    chkNum.Checked = false;
                    cboNumOrder.SelectedIndex = -1;
                }
                if (out_node.GetChar("USE_ALPHA") == 'Y')
                {
                    chkAlpha.Checked = true;
                    cboAlphaOrder.SelectedIndex = MPCF.ToInt(out_node.GetChar("ALP_INC_ORDER"));
                    cboCase.SelectedIndex = MPCF.ToInt(out_node.GetChar("ALP_CASE"));
                    cboOddAlpha.SelectedIndex = MPCF.ToInt(out_node.GetChar("ALP_ODD_EVEN"));
                }
                else
                {
                    chkAlpha.Checked = false;
                    cboAlphaOrder.SelectedIndex = -1;
                    cboCase.SelectedIndex = -1;
                    cboOddAlpha.SelectedIndex = -1;
                }

                if (chkNum.Checked == true && chkAlpha.Checked == true)
                {
                    cboOrder.Enabled = true;
                    cboOrder.SelectedIndex = MPCF.ToInt(out_node.GetChar("NUM_ALP_ORDER"));
                }
                else
                {
                    cboOrder.Enabled = false;
                    cboOrder.SelectedIndex = -1;
                }
                if (chkNum.Checked == false && chkAlpha.Checked == false)
                {
                    txtCharSet.ReadOnly = false;
                }
                else
                {
                    txtCharSet.ReadOnly = true;
                }
                txtCharSet.Text = MPCF.Trim(out_node.GetString("DATA_1"));
                txtExclude.Text = MPCF.Trim(out_node.GetString("DATA_2"));
                txtSize.Text = out_node.GetInt("LENGTH").ToString();
                if (out_node.GetChar("ALLOW_CYCLE_SEQ") == 'Y')
                {
                    chkAllowCycle.Checked = true;
                    txtCycleValue.ReadOnly = false;
                    txtCycleValue.Text = MPCF.Trim(out_node.GetString("CYCLE_INIT_VALUE"));
                }
                else
                {
                    chkAllowCycle.Checked = false;
                    txtCycleValue.ReadOnly = true;
                }
                txtCreateValue.Text = MPCF.Trim(out_node.GetString("CREATE_INIT_VALUE"));
                cdvDepSeq.Text = out_node.GetInt("DEP_RULE_SEQ").ToString();
                s_key_1 = MPCF.Trim(out_node.GetString("SEQ_KEY_1"));
                s_key_2 = MPCF.Trim(out_node.GetString("SEQ_KEY_2"));


                chkMaterial.Checked = MPCF.Mid(s_key_1, 0, 1) == "Y" ? true : false;
                chkMatVer.Checked = MPCF.Mid(s_key_1, 1, 1) == "Y" ? true : false;
                chkFlow.Checked = MPCF.Mid(s_key_1, 2, 1) == "Y" ? true : false;
                chkOper.Checked = MPCF.Mid(s_key_1, 3, 1) == "Y" ? true : false;
                chkResType.Checked = MPCF.Mid(s_key_1, 4, 1) == "Y" ? true : false;
                chkResGrp.Checked = MPCF.Mid(s_key_1, 5, 1) == "Y" ? true : false;
                chkResource.Checked = MPCF.Mid(s_key_1, 6, 1) == "Y" ? true : false;
                chkFactory.Checked = MPCF.Mid(s_key_1, 7, 1) == "Y" ? true : false;
                chkLotID.Checked = MPCF.Mid(s_key_1, 8, 1) == "Y" ? true : false;
                chkSublotID.Checked = MPCF.Mid(s_key_1, 9, 1) == "Y" ? true : false;
                chkDatetime.Checked = MPCF.Mid(s_key_1, 10, 1) == "Y" ? true : false;

                chkKey1.Checked = MPCF.Mid(s_key_2, 0, 1) == "Y" ? true : false;
                chkKey2.Checked = MPCF.Mid(s_key_2, 1, 1) == "Y" ? true : false;
                chkKey3.Checked = MPCF.Mid(s_key_2, 2, 1) == "Y" ? true : false;
                chkKey4.Checked = MPCF.Mid(s_key_2, 3, 1) == "Y" ? true : false;
                chkKey5.Checked = MPCF.Mid(s_key_2, 4, 1) == "Y" ? true : false;
                chkKey6.Checked = MPCF.Mid(s_key_2, 5, 1) == "Y" ? true : false;
                chkKey7.Checked = MPCF.Mid(s_key_2, 6, 1) == "Y" ? true : false;
                chkKey8.Checked = MPCF.Mid(s_key_2, 7, 1) == "Y" ? true : false;
                chkKey9.Checked = MPCF.Mid(s_key_2, 8, 1) == "Y" ? true : false;
                chkKey10.Checked = MPCF.Mid(s_key_2, 9, 1) == "Y" ? true : false;

            }
            else if (cboRuleType.SelectedIndex == 4) //Blank Value
            {
                txtBlank.Text = out_node.GetInt("LENGTH").ToString();
            }            

            return true;

        }

        private bool Gen_String()
        {

            TRSNode in_node = new TRSNode("VIEW_RULE_DEF_IN");
            TRSNode out_node = new TRSNode("VIEW_RULE_DEF_OUT");
            string s_gen = "";
            int i, j;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            
            for (i = 0; i < lisSeq.Items.Count; i++)
            {
                in_node.SetString("RULE_ID", MPCF.Trim(lisRule.SelectedItems[0].Text));
                in_node.SetInt("RULE_SEQ", MPCF.ToInt(lisSeq.Items[i].Text));

                if (MPCR.CallService("WIP", "WIP_View_Rule_Def", in_node, ref out_node) == false)
                {
                    return false;
                }


                if (out_node.GetChar("RULE_TYPE") == 'F') //Fixed String
                {
                    s_gen += MPCF.Trim(out_node.GetString("DATA_1"));
                }
                else if (out_node.GetChar("RULE_TYPE") == 'V') //Field Value
                {
                    //if (out_node.GetChar("FIELD_TYPE") == 'C')
                    //{
                    //    s_gen += MPCF.Trim(out_node.GetString("DATA_1"));
                    //}
                    //else
                    //{
                    //    s_gen += MPCF.Trim(out_node.GetString("DATA_2"));
                    //}

                    if (out_node.GetInt("LENGTH") == 0)
                    {
                        s_gen += out_node.GetString("DATA_2");
                    }
                    else
                    {
                        for (j = 0; j < out_node.GetInt("LENGTH"); j++)
                        {
                            s_gen += "X";
                        }
                    }
                }
                else if (out_node.GetChar("RULE_TYPE") == 'D') //Date Value
                {
                    if (MPCF.Trim(out_node.GetString("DATA_1")) == "")
                    {
                        s_gen += "YYYYMMDD";
                    }
                    else
                    {
                        s_gen += out_node.GetString("DATA_1");
                    }
                }
                else if (out_node.GetChar("RULE_TYPE") == 'S') //Seq Value
                {
                    for (j = 0; j < out_node.GetInt("LENGTH"); j++)
                    {
                        s_gen += "#";
                    }

                }
                else if (out_node.GetChar("RULE_TYPE") == 'B') //Blank Value
                {
                    for (j = 0; j < out_node.GetInt("LENGTH"); j++)
                    {
                        s_gen += " ";
                    }
                }
            }
            txtGenString.Text = s_gen;
            return true;

        }

        private void ChangeSyntaxColor()
        {
            int iStart;
            int iLen = 0;
            iStart = 0;
            if (MPCF.Trim(txtQuery.Text) == "")
            {
                return;
            }
            txtQuery.SelectionStart = 0;
            txtQuery.SelectionLength = txtQuery.Text.Length;
            txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;

            while (iLen < txtQuery.Text.Length)
            {
                if (txtQuery.Text[iLen] == ' ')
                {
                    if (MPCF.IsSQLSyntax(MPCF.ToUpper(txtQuery.Text.Substring(iStart, iLen - iStart))) == true ||
                        txtQuery.Text.Substring(iStart, iLen - iStart).IndexOf("$") > 0)
                    {
                        txtQuery.SelectionStart = iStart;
                        txtQuery.SelectionLength = iLen - iStart;
                        txtQuery.SelectionColor = System.Drawing.Color.Blue;
                        txtQuery.SelectionStart = iLen;
                        txtQuery.SelectionLength = 0;
                        txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;
                    }

                    iStart = iLen;
                }

                iLen++;
            }
        }

        private bool ViewQueryResult(Control control, string sQuery)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            try
            {
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", sQuery);

                do
                {
                    if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    MPCR.FillDataView(control, out_node);

                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                } while (in_node.GetInt("NEXT_ROW") > 0);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;
        }

        private bool View_Calendar_List(char c_type, Control control)
        {

            try
            {
                TRSNode in_node = new TRSNode("VIEW_CALENDAR_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_CALENDAR_LIST_OUT");
                int i;
                ListViewItem itmx = null;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1'; // 1 : Calendar List,  2 : Work Calendar ID List
                in_node.AddChar("CALENDAR_TYPE", c_type);

                if (MPCR.CallService("BAS", "BAS_View_Calendar_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmx = new ListViewItem(out_node.GetList(0)[i].GetString("CALENDAR_ID"), (int)SMALLICON_INDEX.IDX_CALENDAR);
                    ((ListView)control).Items.Add(itmx);
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        private static void SetCMFItem(string sLabelName, Control parentControl)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            System.Collections.ArrayList chkList;
            System.Collections.ArrayList controls;
            CheckBox chkTemp;
            int i;

            try
            {
                controls = MPCF.GetIndexedControl(sLabelName, parentControl);
                for (i = 0; i <= controls.Count - 1; i++)
                {
                    ((CheckBox)controls[i]).Visible = false;
                    ((CheckBox)controls[i]).Text = "";
                }

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_RULE_SEQ_KEY, ref out_node, "", true) == false)
                {
                    return;
                }

                chkList = MPCF.GetIndexedControl(sLabelName, parentControl);

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    chkTemp = (CheckBox)chkList[i];

                    chkTemp.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT"));

                    if (chkTemp.Text != "")
                    {
                        chkTemp.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private static void SetCMFItem(string sLabelName, string sTextBoxName, Control parentControl)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            System.Collections.ArrayList lblList;
            System.Collections.ArrayList txtList;
            System.Collections.ArrayList controls;
            Label lblTemp;
            TextBox txtTemp;
            int i;

            try
            {
                controls = MPCF.GetIndexedControl(sLabelName, parentControl);
                for (i = 0; i <= controls.Count - 1; i++)
                {
                    ((Label)controls[i]).Visible = false;
                    ((Label)controls[i]).Text = "";
                }

                controls = MPCF.GetIndexedControl(sTextBoxName, parentControl);
                for (i = 0; i <= controls.Count - 1; i++)
                {
                    ((TextBox)controls[i]).Visible = false;
                    ((TextBox)controls[i]).Text = "";
                }

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_RULE_SEQ_KEY, ref out_node, "", true) == false)
                {
                    return;
                }

                lblList = MPCF.GetIndexedControl(sLabelName, parentControl);
                txtList = MPCF.GetIndexedControl(sTextBoxName, parentControl);

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (i >= txtList.Count)
                    {
                        break;
                    }

                    lblTemp = (Label)lblList[i];
                    txtTemp = (TextBox)txtList[i];

                    lblTemp.Text = out_node.GetList(0)[i].GetString("PROMPT");

                    if (lblTemp.Text != "")
                    {
                        lblTemp.Visible = true;
                        txtTemp.Visible = true;                     
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private bool ID_Gen_Test(char s_step)
        {
            TRSNode in_node = new TRSNode("ID_GEN_TEST_IN");
            TRSNode out_node = new TRSNode("ID_GEN_TEST_OUT");
            TRSNode node;
            int i;
 
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = s_step;

            in_node.AddChar("TEST_FLAG", 'Y');
            in_node.AddString("RULE_ID", MPCF.Trim(txtRule.Text));
            in_node.AddInt("GEN_ID_COUNT", MPCF.ToInt(txtGenCount.Text));

            in_node.AddString("KEY_FACTORY", MPCF.Trim(txtFactory.Text));
            in_node.AddString("MAT_ID", MPCF.Trim(txtMaterial.Text));
            in_node.AddInt("MAT_VER", MPCF.ToInt(txtMaterialVer.Text));
            in_node.AddString("FLOW", MPCF.Trim(txtFlow.Text));
            in_node.AddString("OPER", MPCF.Trim(txtOperation.Text));
            in_node.AddString("RES_TYPE", MPCF.Trim(txtResType.Text));
            in_node.AddString("RESG_ID", MPCF.Trim(txtResGroup.Text));
            in_node.AddString("RES_ID", MPCF.Trim(txtResource.Text));
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddString("OVR_TIME", MPCF.Trim(txtOvrTime.Text));
            in_node.AddString("SUBLOT_ID", MPCF.Trim(txtSublotID.Text));
            in_node.AddString("DATETIME", MPCF.Trim(txtDatetime.Text));
            in_node.AddString("SEQ_KEY_1", MPCF.Trim(txtKey1.Text));
            in_node.AddString("SEQ_KEY_2", MPCF.Trim(txtKey2.Text));
            in_node.AddString("SEQ_KEY_3", MPCF.Trim(txtKey3.Text));
            in_node.AddString("SEQ_KEY_4", MPCF.Trim(txtKey4.Text));
            in_node.AddString("SEQ_KEY_5", MPCF.Trim(txtKey5.Text));
            in_node.AddString("SEQ_KEY_6", MPCF.Trim(txtKey6.Text));
            in_node.AddString("SEQ_KEY_7", MPCF.Trim(txtKey7.Text));
            in_node.AddString("SEQ_KEY_8", MPCF.Trim(txtKey8.Text));
            in_node.AddString("SEQ_KEY_9", MPCF.Trim(txtKey9.Text));
            in_node.AddString("SEQ_KEY_10", MPCF.Trim(txtKey10.Text));

            for (i = 0; i < spdFieldValue.Sheets[0].RowCount; i++)
            {
                if (MPCF.Trim(spdFieldValue.Sheets[0].Cells[i, COL_FIELD_ARGUMENT].Value) != "")
                {
                    node = in_node.AddNode("ARGU_LIST");

                    node.AddString("ARGUMENT", MPCF.Trim(spdFieldValue.Sheets[0].Cells[i, COL_FIELD_VALUE].Value));
                }
            }

            if (MPCR.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
            {
                return false;
            }

            txtGenID.Text = out_node.GetString("GEN_ID");

            MPCR.ShowSuccessMsg(out_node);                       

            return true;        
        }

        private bool View_Gen_ID_History()
        {
            TRSNode in_node = new TRSNode("VIEW_GEN_ID_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_GEN_ID_HISTORY_OUT");
            List<TRSNode> his_list;
            FarPoint.Win.Spread.SheetView histGenID;
            int i;
            int iRow;

            try
            {
                MPCF.ClearList(spdHistory, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("RULE_ID", MPCF.Trim(txtRule.Text));
                in_node.AddString("NEXT_CREATE_TIME", "99999999999999");
                in_node.AddInt("NEXT_SEQ_NUM", int.MaxValue);

                //Modify by J.S. 2012.06.07 너무 많은 양을 가지고 올수 있기 때문에 루핑 제거
                //do
                //{
                    if (MPCR.CallService("WIP", "WIP_View_Gen_ID_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    histGenID = spdHistory.Sheets[0];
                    his_list = out_node.GetList("GEN_ID_HISTORY");
                    for (i = 0; i < his_list.Count; i++)
                    {
                        iRow = histGenID.RowCount;
                        histGenID.RowCount++;

                        histGenID.Cells[iRow, COL_HIST_SEQ_NUM].Value = his_list[i].GetInt("SEQ_NUM").ToString();
                        histGenID.Cells[iRow, COL_HIST_GEN_ID].Value = his_list[i].GetString("GEN_ID");
                        histGenID.Cells[iRow, COL_HIST_CREATE_TIME].Value = MPCF.MakeDateFormat(his_list[i].GetString("CREATE_TIME"));
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 0].Value = his_list[i].GetString("FACTORY");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 1].Value = his_list[i].GetString("MAT_ID");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 2].Value = his_list[i].GetInt("MAT_VER");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 3].Value = his_list[i].GetString("FLOW");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 4].Value = his_list[i].GetString("OPER");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 5].Value = his_list[i].GetString("RES_TYPE");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 6].Value = his_list[i].GetString("RESG_ID");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 7].Value = his_list[i].GetString("RES_ID");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 8].Value = his_list[i].GetString("LOT_ID");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 9].Value = his_list[i].GetString("SUBLOT_ID");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 10].Value = his_list[i].GetString("DATETIME");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 11].Value = his_list[i].GetString("KEY_1");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 12].Value = his_list[i].GetString("KEY_2");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 13].Value = his_list[i].GetString("KEY_3");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 14].Value = his_list[i].GetString("KEY_4");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 15].Value = his_list[i].GetString("KEY_5");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 16].Value = his_list[i].GetString("KEY_6");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 17].Value = his_list[i].GetString("KEY_7");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 18].Value = his_list[i].GetString("KEY_8");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 19].Value = his_list[i].GetString("KEY_9");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 20].Value = his_list[i].GetString("KEY_10");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 21].Value = his_list[i].GetString("CONFIRM_KEY");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 22].Value = his_list[i].GetString("SEQ_POSITION");
                        histGenID.Cells[iRow, COL_HIST_KEY_START + 23].Value = his_list[i].GetChar("ID_USED_FLAG");
                    }

                    //in_node.SetString("NEXT_CREATE_TIME", out_node.GetString("NEXT_CREATE_TIME"));
                    //in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));

                //} while (out_node.GetString("NEXT_CREATE_TIME") != "" || out_node.GetInt("NEXT_SEQ_NUM") > 0);

                MPCF.FitColumnHeader(spdHistory);
            }  
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool ID_Gen_Init(char s_step)
        {
            TRSNode in_node = new TRSNode("ID_GEN_INIT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = s_step;
            in_node.Factory = MPGV.gsFactory;

            in_node.AddString("RULE_ID", MPCF.Trim(txtRule.Text));

            if (s_step == '2')
            {
                in_node.AddString("KEY_FACTORY", MPCF.Trim(txtFactory.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(txtMaterial.Text));
                in_node.AddInt("MAT_VER", MPCF.ToInt(txtMaterialVer.Text));
                in_node.AddString("FLOW", MPCF.Trim(txtFlow.Text));
                in_node.AddString("OPER", MPCF.Trim(txtOperation.Text));
                in_node.AddString("RES_TYPE", MPCF.Trim(txtResType.Text));
                in_node.AddString("RESG_ID", MPCF.Trim(txtResGroup.Text));
                in_node.AddString("RES_ID", MPCF.Trim(txtResource.Text));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("SUBLOT_ID", MPCF.Trim(txtSublotID.Text));
                in_node.AddString("DATETIME", MPCF.Trim(txtDatetime.Text));
                in_node.AddString("SEQ_KEY_1", MPCF.Trim(txtKey1.Text));
                in_node.AddString("SEQ_KEY_2", MPCF.Trim(txtKey2.Text));
                in_node.AddString("SEQ_KEY_3", MPCF.Trim(txtKey3.Text));
                in_node.AddString("SEQ_KEY_4", MPCF.Trim(txtKey4.Text));
                in_node.AddString("SEQ_KEY_5", MPCF.Trim(txtKey5.Text));
                in_node.AddString("SEQ_KEY_6", MPCF.Trim(txtKey6.Text));
                in_node.AddString("SEQ_KEY_7", MPCF.Trim(txtKey7.Text));
                in_node.AddString("SEQ_KEY_8", MPCF.Trim(txtKey8.Text));
                in_node.AddString("SEQ_KEY_9", MPCF.Trim(txtKey9.Text));
                in_node.AddString("SEQ_KEY_10", MPCF.Trim(txtKey10.Text));
                in_node.AddString("FROM_INIT_ID", MPCF.Trim(txtFromInitID.Text));
            }

            if (MPCR.CallService("WIP", "WIP_ID_Gen_Init", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            if (MPCF.Trim(txtFromInitID.Text) != "")
            {
                txtFromInitID.Text = "";
            }

            return true;
        }

        private bool ID_Gen_Approval(char s_step)
        {
            TRSNode in_node = new TRSNode("ID_GEN_APPROVAL_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = s_step;
            in_node.Factory = MPGV.gsFactory;

            in_node.AddString("RULE_ID", MPCF.Trim(txtRule.Text));
            
            if (MPCR.CallService("WIP", "WIP_ID_Gen_Approval", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }

        private void SetArgumentList(int iMaxArgument)
        {
            int i = 0;
            string sValue;

            try
            {
                MPCF.ClearList(spdFieldValue, true);

                spdFieldValue.Sheets[0].RowCount = iMaxArgument;

                for (i = 1; i <= iMaxArgument; i++)
                {
                    sValue = "$" + i.ToString();
                    spdFieldValue.Sheets[0].Cells[i - 1, COL_FIELD_ARGUMENT].Value = sValue;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool CopyIDRule()
        {
            TRSNode in_node = new TRSNode("COPY_ID_RULE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("RULE_ID", MPCF.Trim(txtRule.Text));
            in_node.AddString("TO_FACTORY", MPCF.Trim(cdvToFactory.Text));
            in_node.AddString("TO_RULE_ID", MPCF.Trim(txtToRuleID.Text));

            if (MPCR.CallService("WIP", "WIP_Copy_ID_Rule", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }



        private void frmWIPSetupIDGenerator_Load(object sender, EventArgs e)
        {
            try
            {
                MPCF.InitListView(lisRule);
                MPCF.InitListView(lisSeq);
                SetCMFItem("chkKey", tbpSeqKey);
                SetCMFItem("lblKey", "txtKey", grpKeyInput);
                uccStart.Value = DateTime.Now;
                udtStart.Value = DateTime.Now;

                btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                if (WIPLIST.ViewRuleList(lisRule, MPCF.ToChar(cdvType.Text), chkOnlyThisFactory.Checked, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisRule.Items.Count.ToString();
                if (lisRule.Items.Count > 0)
                {
                    MPCF.FindListItem(lisRule, txtRule.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvType_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type Code", 150, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_ID_GEN_TYPE);
            cdvTemp.AddEmptyRow(1);
        }

        private void cboRuleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRuleType.SelectedIndex == 0) //Fixed String
            {
                pnlFix.BringToFront();
            }
            else if (cboRuleType.SelectedIndex == 1) //Field Value
            {
                pnlConst.BringToFront();
            }
            else if (cboRuleType.SelectedIndex == 2) //Date Value
            {
                pnlDate.BringToFront();
            }
            else if (cboRuleType.SelectedIndex == 3) //Sequence Value
            {
                pnlSeq.BringToFront();
            }
            else if (cboRuleType.SelectedIndex == 4) //Blank Value
            {
                pnlBlank.BringToFront();
            }
            else
            {
                pnlFix.BringToFront();
            }
        }

        private void lisRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);
                MPCF.InitListView(lisSeq);
                if (lisRule.SelectedItems.Count > 0)
                {
                    txtRule.Text = lisRule.SelectedItems[0].Text;
                    if (View_Rule() == false)
                    {
                        return;
                    }

                    if (WIPLIST.ViewRuleDefinitionList(lisSeq, '1', txtRule.Text, 0) == false)
                    {
                        return;
                    }
                    if (lisSeq.Items.Count > 0)
                    {
                        lisSeq.Items[0].Selected = true;
                    }
                    Gen_String();
                }
                else
                {
                    InitRightPanel();
                }
                MPCF.ClearList(spdHistory, true);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
            if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
            if (Update_Rule(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
            if (Update_Rule(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            if (Update_Rule(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string s_seq;
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
            if (CheckCondition('E') == false)
            {
                return;
            }
            s_seq = MPCF.Trim(MPCF.ToInt(lisSeq.SelectedItems[0].Text) - 1);
            if (Update_Rule_Def(MPGC.MP_STEP_DELETE, true) == false)
            {
                return;
            }
            if (WIPLIST.ViewRuleDefinitionList(lisSeq, '1', txtRule.Text, 0) == false)
            {
                return;
            }
            MPCF.FindListItem(lisSeq, s_seq, false);
            Gen_String();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string s_seq;
            s_seq = MPCF.Trim(lisSeq.Items.Count + 1);
            if (CheckCondition('A') == false)
            {
                return;
            }
            if (Update_Rule_Def(MPGC.MP_STEP_CREATE, true) == false)
            {
                return;
            }
            if (WIPLIST.ViewRuleDefinitionList(lisSeq, '1', txtRule.Text, 0) == false)
            {
                return;
            }
            MPCF.FindListItem(lisSeq, s_seq, false);
            Gen_String();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            string s_seq;
            
            if (CheckCondition('1') == false)
            {
                return;
            }
            s_seq = MPCF.Trim(MPCF.ToInt(lisSeq.SelectedItems[0].Text) - 1);
            if (Update_Rule_Def('1', false) == false)
            {
                return;
            }
            if (WIPLIST.ViewRuleDefinitionList(lisSeq, '1', txtRule.Text, 0) == false)
            {
                return;
            }
            MPCF.FindListItem(lisSeq, s_seq, false);
            Gen_String();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string s_seq;
            if (CheckCondition('2') == false)
            {
                return;
            }
            s_seq = MPCF.Trim(MPCF.ToInt(lisSeq.SelectedItems[0].Text) + 1);
            if (Update_Rule_Def('2', false) == false)
            {
                return;
            }
            if (WIPLIST.ViewRuleDefinitionList(lisSeq, '1', txtRule.Text, 0) == false)
            {
                return;
            }
            MPCF.FindListItem(lisSeq, s_seq, false);
            Gen_String();
        }

        private void lisSeq_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRuleType);
                if (lisSeq.SelectedItems.Count > 0)
                {
                    if (View_Rule_Def() == false)
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

        private void rbnConst_CheckedChanged(object sender, EventArgs e)
        {
            cdvConstant.Text = "";
            cdvCol.Text = "";
            txtQuery.Text = "";
            if (rbnConst.Checked == true)
            {
                lblCol.Visible = false;
                cdvCol.Visible = false;
                lblWhere.Visible = false;
                txtQuery.Visible = false;
                lblConstant.Text = MPCF.FindLanguage("Constant", 0);
            }
            else
            {
                lblCol.Visible = true;
                cdvCol.Visible = true;
                lblWhere.Visible = true;
                txtQuery.Visible = true;
                lblConstant.Text = MPCF.FindLanguage("Table", 0);
            }
        }

        private void chkUseDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseDate.Checked == true)
            {
                uccStart.Enabled = true;
                udtStart.Enabled = true;
                chkOverride.Enabled = true;
            }
            else
            {
                uccStart.Enabled = false;
                udtStart.Enabled = false;
                chkOverride.Enabled = false;
            }
        }

        private void chkUseCal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseCal.Checked == true)
            {
                cdvCalID.Enabled = true;
            }
            else
            {
                cdvCalID.Text = "";
                cdvCalID.Enabled = false;
            }
        }

        private void chkNum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNum.Checked == true)
            {
                cboNumOrder.Enabled = true;
                cboOdd.Enabled = true;
            }
            else
            {
                cboNumOrder.SelectedIndex = -1;
                cboOdd.SelectedIndex = -1;
                cboNumOrder.Enabled = false;
                cboOdd.Enabled = false;
            }
            if (chkNum.Checked == true && chkAlpha.Checked == true)
            {
                cboOrder.Enabled = true;
            }
            else
            {
                cboOrder.SelectedIndex = -1;
                cboOrder.Enabled = false;
            }

            if (chkNum.Checked == false && chkAlpha.Checked == false)
            {
                txtCharSet.ReadOnly = false;
            }
            else
            {
                txtCharSet.ReadOnly = true;
            }
        }

        private void chkAlpha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlpha.Checked == true)
            {
               cboAlphaOrder.Enabled = true;
               cboOddAlpha.Enabled = true;
               cboCase.Enabled = true;
            }
            else
            {
                cboAlphaOrder.SelectedIndex = -1;
                cboOddAlpha.SelectedIndex = -1;
                cboCase.SelectedIndex = -1;
                cboAlphaOrder.Enabled = false;
                cboOddAlpha.Enabled = false;
                cboCase.Enabled = false;
            }
            if (chkNum.Checked == true && chkAlpha.Checked == true)
            {
                cboOrder.Enabled = true;
            }
            else
            {
                cboOrder.SelectedIndex = -1;
                cboOrder.Enabled = false;
            }
            if (chkNum.Checked == false && chkAlpha.Checked == false)
            {
                txtCharSet.ReadOnly = false;
            }
            else
            {
                txtCharSet.ReadOnly = true;
            }
        }

        private void cdvType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void txtQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i;
            int iSel;
            txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;
            if (e.KeyChar == ' ' || e.KeyChar == '\b')
            {
                for (i = txtQuery.SelectionStart - 1; i >= 0; i--)
                {
                    if (txtQuery.Text[i] == ' ' || i == 0)
                    {
                        if (MPCF.IsSQLSyntax(MPCF.ToUpper(txtQuery.Text.Substring(i, txtQuery.SelectionStart - i))) == true ||
                    txtQuery.Text.Substring(i, txtQuery.SelectionStart - i).IndexOf("$") > 0)
                        {
                            iSel = txtQuery.SelectionStart;
                            txtQuery.SelectionStart = i;
                            txtQuery.SelectionLength = iSel - i;
                            txtQuery.SelectionColor = System.Drawing.Color.Blue;
                            txtQuery.SelectionStart = iSel;
                            txtQuery.SelectionLength = 0;
                            txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;

                            break;
                        }
                        else
                        {
                            iSel = txtQuery.SelectionStart;
                            txtQuery.SelectionStart = i;
                            txtQuery.SelectionLength = iSel - i;
                            txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;
                            txtQuery.SelectionStart = iSel;
                            txtQuery.SelectionLength = 0;
                            txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;

                            break;
                        }
                    }
                }
            }

        }
        
        private void txtQuery_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    ChangeSyntaxColor();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvConstant_ButtonPress(object sender, EventArgs e)
        {
            int i;
            cdvConstant.Init();
            MPCF.InitListView(cdvConstant.GetListView);
            cdvConstant.Columns.Add("Type Code", 150, HorizontalAlignment.Left);
            cdvConstant.SelectedSubItemIndex = 0;
            if (rbnConst.Checked == true)
            {
                for (i = 0; i < MPGV.FieldConstant.Length; i++)
                {
                    cdvConstant.Items.Add(MPGV.FieldConstant[i],(int)SMALLICON_INDEX.IDX_CODE_DATA);
                }
            }
            else
            {
                ViewQueryResult(cdvConstant.GetListView, 
                    "SELECT TNAME FROM TAB WHERE TNAME NOT IN (SELECT OBJECT_NAME FROM RECYCLEBIN) ORDER BY TNAME");
                
            }
            
        }

        private void cdvCol_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvConstant.Text) == "")
            {
                return;
            }
            cdvCol.Init();
            MPCF.InitListView(cdvCol.GetListView);
            cdvCol.Columns.Add("Type Code", 150, HorizontalAlignment.Left);
            cdvCol.SelectedSubItemIndex = 0;
            ViewQueryResult(cdvCol.GetListView, "SELECT COLUMN_NAME FROM USER_TAB_COLUMNS WHERE TABLE_NAME = '" + MPCF.Trim(cdvConstant.Text) + "' ORDER BY COLUMN_ID");
        }

        private void cdvCalID_ButtonPress(object sender, EventArgs e)
        {
            cdvCalID.Init();
            MPCF.InitListView(cdvCalID.GetListView);
            cdvCalID.Columns.Add("Cal ID", 150, HorizontalAlignment.Left);
            cdvCalID.SelectedSubItemIndex = 0;
            View_Calendar_List('F', cdvCalID.GetListView);
            View_Calendar_List('W', cdvCalID.GetListView);
        }

        private void btnSeqUpdate_Click(object sender, EventArgs e)
        {
            if (lisSeq.SelectedItems.Count < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                lisSeq.Focus();
                return;
            }
            if (CheckCondition('A') == false)
            {
                return;
            }

            string s_seq;
            s_seq = lisSeq.SelectedItems[0].Text;
            if (Update_Rule_Def(MPGC.MP_STEP_UPDATE, true) == false)
            {
                return;
            }
            if (WIPLIST.ViewRuleDefinitionList(lisSeq, '1', txtRule.Text, 0) == false)
            {
                return;
            }

            MPCF.FindListItem(lisSeq, s_seq, false);
            Gen_String();
        }

        private void chkAllowCycle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowCycle.Checked == true)
            {
                txtCycleValue.ReadOnly = false;
            }
            else
            {
                txtCycleValue.ReadOnly = true;
            }
        }

        private void cboSave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSave.SelectedIndex == 1)
            {
                chkFulFillSeq.Enabled = true;
                cboNotUsedID.Enabled = true;
            }
            else
            {
                chkFulFillSeq.Checked = false;
                chkFulFillSeq.Enabled = false;

                cboNotUsedID.Text = "";
                cboNotUsedID.Enabled = false;
            }
        }

        private void cdvDepSeq_ButtonPress(object sender, EventArgs e)
        {
            if (lisSeq.SelectedItems.Count <= 0)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                lisSeq.Select();
                return;
            }
            cdvDepSeq.Init();
            MPCF.InitListView(cdvDepSeq.GetListView);
            cdvDepSeq.Columns.Add("Seq", 150, HorizontalAlignment.Left);
            cdvDepSeq.SelectedSubItemIndex = 0;
            WIPLIST.ViewRuleDefinitionList(cdvDepSeq.GetListView, '2', txtRule.Text, MPCF.ToInt(lisSeq.SelectedItems[0].Text));
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            if (View_Gen_ID_History() == false)
            {
                return;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition('T') == false)
                {
                    return;
                }
                if (ID_Gen_Test('2') == false)
                {
                    return;
                }

                btnViewHistory.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {           
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (ID_Gen_Init('1') == false)
                {
                    return;
                }

                btnViewHistory.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnApproval_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ToChar(btnApproval.Tag) == MPGC.MP_STEP_APPROVAL)
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                }

                if (ID_Gen_Approval(MPCF.ToChar(btnApproval.Tag)) == false)
                {
                    return;
                }

                lisRule_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtRule_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        // add by doohyun 2012.01.19 Ticket #841(txtRule 필드 변경시 초기화 시킴)
        private void txtRule_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(pnlRight, txtRule);
                MPCF.ClearList(lisSeq);

                MPCR.ChangeControlEnabled(this, btnAdd, true);
                MPCR.ChangeControlEnabled(this, btnDel, true);
                MPCR.ChangeControlEnabled(this, btnSeqUpdate, true);
                MPCR.ChangeControlEnabled(this, btnUp, true);
                MPCR.ChangeControlEnabled(this, btnDown, true);

                txtGenString.Enabled = true;
                cboSave.Enabled = true;
                //chkApprovalFlag.Enabled = true;       // 2014.01.23 DM KIM 주석 처리
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnInitByKey_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (ID_Gen_Init('2') == false)
                {
                    return;
                }

                btnViewHistory.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        //End Add
        private void chkOnlyThisFactory_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            MPCF.FindListItemPartial(lisRule, txtFind.Text, 0, true, false);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtRule, 1) == false) return;
            if (MPCF.CheckValue(txtToRuleID, 1) == false) return;

            if (CopyIDRule() == false) return;

            btnRefresh.PerformClick();
        }

        private void cdvToFactory_ButtonPress(object sender, EventArgs e)
        {
            cdvToFactory.Init();
            MPCF.InitListView(cdvToFactory.GetListView);
            cdvToFactory.Columns.Add("Factory", 100, HorizontalAlignment.Left);
            cdvToFactory.Columns.Add("Factory Desc", 100, HorizontalAlignment.Left);
            cdvToFactory.SelectedSubItemIndex = 0;
            WIPLIST.ViewFactoryList(cdvToFactory.GetListView, '1', null);

            int i = 0;
            while (i < cdvToFactory.Items.Count)
            {
                if (MPCF.Trim(cdvToFactory.Items[i].Text) == MPGV.gsFactory || MPCF.Trim(cdvToFactory.Items[i].Text) == MPGV.gsCentralFactory)
                {
                    cdvToFactory.Items.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }


    }
}

