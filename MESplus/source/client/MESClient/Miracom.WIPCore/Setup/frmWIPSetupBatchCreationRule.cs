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
    public partial class frmWIPSetupBatchCreationRule : Miracom.MESCore.SetupForm02
    {
        public frmWIPSetupBatchCreationRule()
        {
            InitializeComponent();
        }

        private bool CheckCondition(char s_step)
        {
            if (MPCF.CheckValue(txtRule, 1) == false)
            {
                return false;
            }
            if (s_step == MPGC.MP_STEP_CREATE || s_step == MPGC.MP_STEP_UPDATE)
            {
                if (MPCF.CheckValue(cdvGenRule, 1) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cdvBatchType, 1) == false)
                {
                    return false;
                }
               
            }

            return true;
        }
        
        private void InitBatchCount()
        {
            int i;
            string[] strCount = new string[100];
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
            for (i = 1; i < 100; i++)
            {
                strCount[i - 1] = i.ToString();
            }
            strCount[99] = " ";
            cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            cboCellType.Items = strCount;
            for (i = 0; i < 5; i++)
            {
                spdBatch.Sheets[0].Columns[i].CellType = cboCellType;
            }
 
        }
        
        private void InitBatchField()
        {
            int i, j;

            for (j = 0; j < 4; j++)
            {
                for (i = 0; i < 5; i++)
                {
                    spdBatch.Sheets[0].Cells[j, i].Value = "";

                }
            }
        }

        private bool View_Batch_Rule()
        {
            int i, j, k, i_value;
            TRSNode in_node = new TRSNode("VIEW_BATCH_RULE_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_RULE_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("CRT_RULE_ID", MPCF.Trim(lisRule.SelectedItems[0].Text));

            if (MPCR.CallService("WIP", "WIP_View_Batch_Rule", in_node, ref out_node) == false)
            {
                return false;
            }

            txtRuleDesc.Text = MPCF.Trim(out_node.GetString("CRT_RULE_DESC"));
            cdvGenRule.Text = MPCF.Trim(out_node.GetString("GEN_RULE_ID"));
            cdvBatchType.Text = out_node.GetChar("BATCH_TYPE").ToString();
            txtQtime.Text = out_node.GetInt("MIN_QTIME").ToString();

            if (out_node.GetChar("OVERRIDE_FLAG") == 'Y')
            {
               chkOvrFlag.Checked = true;
            }
            else
            {
                chkOvrFlag.Checked = false;
            }
            if (out_node.GetChar("MIX_LOT_FLAG") == 'Y')
            {
                chkMixflag.Checked = true;
            }
            else
            {
                chkMixflag.Checked = false;
            }

            if (out_node.GetChar("UNDER_FLAG") == 'Y')
            {
                chkUnder.Checked = true;
            }
            else
            {
                chkUnder.Checked = false;
            }

            k = 0;

            for (j = 0; j < 4; j++)
            {
                if (k > out_node.GetString("BATCH_COUNT").Length)
                {
                    break;
                }
                for (i = 0; i < 5; i++)
                {
                    if (k > out_node.GetString("BATCH_COUNT").Length)
                    {
                        break;
                    }
                    if (out_node.GetString("BATCH_COUNT").Substring(k, 2) != "__")
                    {
                        i_value = MPCF.ToInt(out_node.GetString("BATCH_COUNT").Substring(k, 2));
                        spdBatch.Sheets[0].Cells[j, i].Value = i_value.ToString();
                    }
                    k += 2;

                }
            }

            if (out_node.GetString("MATCH_ITEM").Length > 0)
            {
                if (out_node.GetString("MATCH_ITEM").Substring(0, 1) == "X")
                {
                    chkMaterialMatch.Checked = true;
                }
            }
            if (out_node.GetString("MATCH_ITEM").Length > 1)
            {
                if (out_node.GetString("MATCH_ITEM").Substring(1, 1) == "X")
                {
                    chkMatVerMatch.Checked = true;
                }
            }
            if (out_node.GetString("MATCH_ITEM").Length > 2)
            {
                if (out_node.GetString("MATCH_ITEM").Substring(2, 1) == "X")
                {
                    chkFlowMatch.Checked = true;
                }
            }
            if (out_node.GetString("MATCH_ITEM").Length > 3)
            {
                if (out_node.GetString("MATCH_ITEM").Substring(3, 1) == "X")
                {
                    chkOperMatch.Checked = true;
                }
            }
            if (out_node.GetString("MATCH_ITEM").Length > 4)
            {
                if (out_node.GetString("MATCH_ITEM").Substring(4, 1) == "X")
                {
                    chkCurrentOper.Checked = true;
                }
            }
            
            txtNPWCount.Text = out_node.GetInt("NPW_COUNT").ToString();
            if (out_node.GetString("NPW_POSITION").Substring(0, 1) == "X")
            {
               chkBetween.Checked = true;
            }
            if (out_node.GetString("NPW_POSITION").Substring(1, 1) == "X")
            {
               chkBefore.Checked = true;
            }
            if (out_node.GetString("NPW_POSITION").Substring(2, 1) == "X")
            {
               chkAfter.Checked = true;
            }
            if (out_node.GetString("NPW_POSITION").Substring(3, 1) == "X")
            {
               chkMiddle.Checked = true;
            }

            return true;

        }

        private bool Update_Batch_Rule(char s_step)
        {
            int i, j;
            TRSNode in_node = new TRSNode("UPDATE_BATCH_RULE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            ListViewItem itm;
            string temp;
            int idx;
            int i_batch;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = s_step;
            in_node.AddString("CRT_RULE_ID", MPCF.Trim(txtRule.Text));

            in_node.AddString("CRT_RULE_DESC", MPCF.Trim(txtRuleDesc.Text));
            in_node.AddString("GEN_RULE_ID", MPCF.Trim(cdvGenRule.Text));
            in_node.AddChar("BATCH_TYPE", MPCF.ToChar(cdvBatchType.Text));
            in_node.AddInt("MIN_QTIME", MPCF.ToInt(txtQtime.Text));

            if (chkOvrFlag.Checked == true)
            {
                in_node.AddChar("OVERRIDE_FLAG", 'Y');
            }
            if (chkMixflag.Checked == true)
            {
                in_node.AddChar("MIX_LOT_FLAG", 'Y');
            }

            temp = "";
            for (j = 0; j < 4; j++)
            {
                for (i = 0; i < 5; i++)
                {
                    if (MPCF.Trim(spdBatch.Sheets[0].Cells[j, i].Value) != "")
                    {
                        i_batch = MPCF.ToInt(spdBatch.Sheets[0].Cells[j, i].Value);
                        temp += i_batch.ToString("00");
                    }
                }
            }
            for (i = temp.Length + 1; i <= 40; i++)
            {
                temp += "_";
            }
            in_node.AddString("BATCH_COUNT", temp);
            in_node.AddChar("UNDER_FLAG", chkUnder.Checked == true ? 'Y' : ' ');

            temp = "";
            temp = temp + (chkMaterialMatch.Checked == true ? "X" : "_");
            temp = temp + (chkMatVerMatch.Checked == true ? "X" : "_");
            temp = temp + (chkFlowMatch.Checked == true ? "X" : "_");
            temp = temp + (chkOperMatch.Checked == true ? "X" : "_");
            temp = temp + (chkCurrentOper.Checked == true ? "X" : "_");
            //temp = temp + (rbnHigh.Checked == true ? "X" : "_");
            in_node.AddString("MATCH_ITEM", temp);

            in_node.AddInt("NPW_COUNT", MPCF.ToInt(txtNPWCount.Text));
            temp = "";
            temp = temp + (chkBetween.Checked == true ? "X" : "_");
            temp = temp + (chkBefore.Checked == true ? "X" : "_");
            temp = temp + (chkAfter.Checked == true ? "X" : "_");
            temp = temp + (chkMiddle.Checked == true ? "X" : "_");
            in_node.AddString("NPW_POSITION", temp);

            if (MPCR.CallService("WIP", "WIP_Update_Batch_Rule", in_node, ref out_node) == false)
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


        private void frmWIPSetupBatchCreationRule_Load(object sender, EventArgs e)
        {
            MPCF.InitListView(lisRule);
            InitBatchCount();
            lblHour.Text = MPGO.QueueTimeUnit();
            if (WIPLIST.ViewBatchRuleList(lisRule, '1') == false)
            {
                return;
            }
            lblDataCount.Text = lisRule.Items.Count.ToString();
            if (lisRule.Items.Count > 0)
            {
                lisRule.Items[0].Selected = true;
            }
        }
        
        private void lisRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);
                InitBatchField();
                if (lisRule.SelectedItems.Count > 0)
                {
                    txtRule.Text = lisRule.SelectedItems[0].Text;
                    if (View_Batch_Rule() == false)
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;
            if (Update_Batch_Rule(MPGC.MP_STEP_CREATE) == false) return;
            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;
                if (Update_Batch_Rule(MPGC.MP_STEP_UPDATE) == false) return;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
            if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;
            if (Update_Batch_Rule(MPGC.MP_STEP_DELETE) == false) return;
            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                if (WIPLIST.ViewBatchRuleList(lisRule, '1') == false)
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

        private void cdvGenRule_ButtonPress(object sender, EventArgs e)
        {
            cdvGenRule.Init();
            MPCF.InitListView(cdvGenRule.GetListView);
            cdvGenRule.Columns.Add("Rule ID", 150, HorizontalAlignment.Left);
            cdvGenRule.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvGenRule.SelectedSubItemIndex = 0;
            if (WIPLIST.ViewRuleList(cdvGenRule.GetListView, 'B', false, "") == false)
            {
                return;
            }
        }

        private void cdvBatchType_ButtonPress(object sender, EventArgs e)
        {
            cdvBatchType.Init();
            MPCF.InitListView(cdvBatchType.GetListView);
            cdvBatchType.Columns.Add("Rule ID", 150, HorizontalAlignment.Left);
            cdvBatchType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvBatchType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvBatchType.GetListView, '1', MPGC.MP_BATCH_TYPE);
        }
              

        private void spdBatch_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                int i, j;

                if (MPCF.Trim(spdBatch.Sheets[0].Cells[e.Row, e.Column].Value) == "") return;

                for (j = 0; j < 4; j++)
                {
                    for (i = 0; i < 5; i++)
                    {                       
                         if (MPCF.Trim(spdBatch.Sheets[0].Cells[j, i].Value) == MPCF.Trim(spdBatch.Sheets[0].Cells[e.Row, e.Column].Value))
                            {
                                if (j != e.Row || i != e.Column)
                                {
                                MPCF.ShowMsgBox(MPCF.GetMessage(276));
                                spdBatch.Sheets[0].Cells[e.Row, e.Column].Value = " ";
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

    }
}

