using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupBatchCreationRuleRelation : Miracom.MESCore.SetupForm01
    {
        private char lm_res_rel_level;
        private string lm_res_type;
        private string lm_res_group;
        private string lm_res_id;

        public frmWIPSetupBatchCreationRuleRelation()
        {
            InitializeComponent();
        }

        private bool CheckCondition(char s_step)
        {
            if (MPCF.CheckValue(cdvCreateRule, 1) == false)
            {
                return false;
            }

            return true;
        }
        
        private void InitResourceTree()
        {
            MPCF.InitTreeView(tvResList);

            if (rbtResType.Checked == true)
            {
                if (BASLIST.ViewGCMDataList(tvResList, '1', MPGC.MP_RAS_RES_TYPE) == false) return;
            }
            else if (rbtResGroup.Checked == true)
            {
                if (RASLIST.ViewResourceGroupList(tvResList, '1') == false) return;
            }
        }
        
        private bool UpdateBatchRelation(char s_step, string s_rule_id, bool b_ignore)
        {
            TRSNode in_node = new TRSNode("UPDATE_BATCH_RELATION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = s_step;

                in_node.AddChar("REL_LEVEL", lm_res_rel_level);
                in_node.AddString("RES_TYPE", lm_res_type);
                in_node.AddString("RESG_ID", lm_res_group);
                in_node.AddString("RES_ID", lm_res_id);

                in_node.AddString("CRT_RULE_ID", MPCF.Trim(s_rule_id));
                
                if (MPCR.CallService("WIP", "WIP_Update_Batch_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }
                if (b_ignore == false)
                {
                    MPCR.ShowSuccessMsg(out_node);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }
        
        private bool ViewBatchRelationList(Control control, char c_step, char c_level, string s_res_type, string s_resg_id, string s_res_id)
        {
            int i;
            TRSNode in_node = new TRSNode("RULE_LIST_IN");
            TRSNode out_node = new TRSNode("RULE_LIST_OUT");
            ListViewItem itmX;

            if (control is ListView)
            {
                MPCF.InitListView((ListView)control);
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddChar("REL_LEVEL", c_level);
            in_node.AddString("RES_TYPE", s_res_type);
            in_node.AddString("RESG_ID", s_resg_id);
            in_node.AddString("RES_ID", s_res_id);
            if (c_step != '1')
            {
                in_node.AddString("CRT_RULE_ID", lisBatchRule.SelectedItems[0].Text);
            }

            if (MPCR.CallService("WIP", "WIP_View_Batch_Relation_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                if (c_step == '1')
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("CRT_RULE_ID"), (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("CRT_RULE_DESC"));
                    ((ListView)control).Items.Add(itmX);
                }
                else if (c_step == '2')
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("RES_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE);
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RES_DESC"));
                    ((ListView)control).Items.Add(itmX);
                }
                else if (c_step == '3')
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("RES_TYPE"), (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RES_TYPE_DESC"));
                    ((ListView)control).Items.Add(itmX);
                }
                else if (c_step == '4')
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("RESG_ID"), (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP);
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RESG_DESC"));
                    ((ListView)control).Items.Add(itmX);
                }
                
            }

           
            return true;
        }

        private bool ViewResourceSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;
            char[] c_rel_level;

            MPCF.InitListView(lisResList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            c_rel_level = new char[2];
            c_rel_level[0] = ' ';
            c_rel_level[1] = ' ';

           if (rbtResType.Checked == true)
            {
                c_rel_level[0] = 'T';
                c_rel_level[1] = 'R';
            }
            else if (rbtResGroup.Checked == true)
            {
                c_rel_level[0] = 'G';
                c_rel_level[1] = 'R';
            }

            sb = new StringBuilder();

            sb.Append("SELECT FACTORY, RES_TYPE, RESG_ID, RES_ID FROM MWIPBATREL ");
            sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
            sb.Append("AND REL_LEVEL IN ('" + c_rel_level[0].ToString() + "', '" + c_rel_level[1].ToString() + "' ) ");
            sb.Append("GROUP BY FACTORY, RES_TYPE, RESG_ID, RES_ID ");
            sb.Append("ORDER BY FACTORY, RES_TYPE, RESG_ID, RES_ID");

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(lisResList, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }
        
        private void ViewResourceItem(TreeNode ParentNode)
        {
            string s_resg_id = "";
            string s_res_type = "";

            if (rbtResType.Checked == true)
            {
                s_res_type = MPCF.Trim(ParentNode.Text);
                s_res_type = MPCF.SubtractString(s_res_type, ":", false, false);
            }
            else if (rbtResGroup.Checked == true)
            {
                s_resg_id = MPCF.Trim(ParentNode.Text);
                s_resg_id = MPCF.SubtractString(s_resg_id, ":", false, false);
            }

            if (RASLIST.ViewResourceList(tvResList, '1', s_resg_id, s_res_type, "", "", "", 0, "", "", ' ', "", false, ParentNode, "") == false) return;
            ParentNode.Expand();
        }
        
        private void tvResList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string s_res_type = "";
            string s_resg_id = "";
            string s_res_id = "";
            char c_rel_level = ' ';

            if (e.Action == TreeViewAction.Collapse || e.Action == TreeViewAction.Expand || e.Action == TreeViewAction.Unknown) return;
            MPCF.InitListView(lisRule);
            switch (e.Node.Level)
            {
                case 0:
                    if (rbtResType.Checked == true)
                    {
                        c_rel_level = 'T';

                        s_res_type = MPCF.Trim(e.Node.Text);
                        s_res_type = MPCF.SubtractString(s_res_type, ":", false, false);

                        if (e.Node.GetNodeCount(true) < 1)
                        {
                            ViewResourceItem(e.Node);
                        }
                    }
                    else if (rbtResGroup.Checked == true)
                    {
                        c_rel_level = 'G';

                        s_resg_id = MPCF.Trim(e.Node.Text);
                        s_resg_id = MPCF.SubtractString(s_resg_id, ":", false, false);

                        if (e.Node.GetNodeCount(true) < 1)
                        {
                            ViewResourceItem(e.Node);
                        }
                    }
                    break;

                case 1:
                    c_rel_level = 'R';

                    s_res_id = MPCF.Trim(e.Node.Text);
                    s_res_id = MPCF.SubtractString(s_res_id, ":", false, false);
                    break;
            }

            lm_res_rel_level = c_rel_level;
            lm_res_type = s_res_type;
            lm_res_group = s_resg_id;
            lm_res_id = s_res_id;

            ViewBatchRelationList(lisRule, '1', c_rel_level, s_res_type, s_resg_id, s_res_id);
        }
        
        private void rbtResSelLevel_CheckedChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(grpTran);
            InitResourceTree();
        }
        
        private void frmWIPSetupBatchCreationRuleRelation_Load(object sender, EventArgs e)
        {
            pnlGrpMid_Resize(null, null);

            InitResourceTree();
            if (WIPLIST.ViewBatchRuleList(lisBatchRule, '1') == false)
            {
                return;
            }
            rbtRuleResource.Checked = true;
        }

        private void cdvCreateRule_ButtonPress(object sender, EventArgs e)
        {
            cdvCreateRule.Init();
            MPCF.InitListView(cdvCreateRule.GetListView);
            cdvCreateRule.Columns.Add("Rule ID", 150, HorizontalAlignment.Left);
            cdvCreateRule.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvCreateRule.SelectedSubItemIndex = 0;
            if (WIPLIST.ViewBatchRuleList(cdvCreateRule.GetListView, '1') == false)
            {
                return;
            }
        }
     
        private void chkOnlySettingData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnlySettingData.Checked == true)
            {
                lisResList.Visible = true;
                tvResList.Visible = false;

                ViewResourceSettingDataList();
            }
            else
            {
                lisResList.Visible = false;
                tvResList.Visible = true;

                InitResourceTree();
            }
        }

        private void lisResList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s_res_type = "";
            string s_resg_id = "";
            string s_res_id = "";
            char c_rel_level = ' ';

            if (lisResList.SelectedItems.Count < 1) return;

            if (rbtResType.Checked == true)
            {
                c_rel_level = 'T';

                s_res_type = MPCF.Trim(lisResList.SelectedItems[0].SubItems[1].Text);
                s_res_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[3].Text);

                if (s_res_id != "")
                    c_rel_level = 'R';
            }
            else if (rbtResGroup.Checked == true)
            {
                c_rel_level = 'G';

                s_resg_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[2].Text);
                s_res_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[3].Text);

                if (s_res_id != "")
                    c_rel_level = 'R';
            }

            lm_res_rel_level = c_rel_level;
            lm_res_type = s_res_type;
            lm_res_group = s_resg_id;
            lm_res_id = s_res_id;

            ViewBatchRelationList(lisRule, '1', c_rel_level, s_res_type, s_resg_id, s_res_id);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;

            if (UpdateBatchRelation(MPGC.MP_STEP_DELETE, cdvCreateRule.Text, false) == false) return;

            ViewBatchRelationList(lisRule, '1', lm_res_rel_level, lm_res_type, lm_res_group, lm_res_id);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
            if (UpdateBatchRelation(MPGC.MP_STEP_UPDATE, cdvCreateRule.Text, false) == false)
            {
                return;
            }
            ViewBatchRelationList(lisRule, '1', lm_res_rel_level, lm_res_type, lm_res_group, lm_res_id);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            if (UpdateBatchRelation(MPGC.MP_STEP_CREATE, cdvCreateRule.Text, false) == false)
            {
                return;
            }
            ViewBatchRelationList(lisRule, '1', lm_res_rel_level, lm_res_type, lm_res_group, lm_res_id);
        }      

        private void lisRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisRule.SelectedItems.Count > 0)
            {
               cdvCreateRule.Text = MPCF.Trim(lisRule.SelectedItems[0].Text);
            }
        }

        private void rbtRuleResource_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtRuleResource.Checked == true)
            {
                RASLIST.ViewResourceList(lisRuleResource, false);
                if (lisBatchRule.SelectedItems.Count > 0)
                {
                    ViewBatchRelationList(lisRuleRelation, '2', ' ', "", "", "");
                }
            }
        }

        private void rbtRuleResType_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtRuleResType.Checked == true)
            {
                BASLIST.ViewGCMDataList(lisRuleResource, '1', MPGC.MP_RAS_RES_TYPE);
                if (lisBatchRule.SelectedItems.Count > 0)
                {
                    ViewBatchRelationList(lisRuleRelation, '3', ' ', "", "", "");
                }
            }
        }

        private void rbtRuleResGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtRuleResGroup.Checked == true)
            {
                RASLIST.ViewResourceGroupList(lisRuleResource, '1');
                if (lisBatchRule.SelectedItems.Count > 0)
                {
                    ViewBatchRelationList(lisRuleRelation, '4', ' ', "", "", "");
                }
            }
        }

        private void lisBatchRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            char c_step = ' ';
            if (rbtRuleResource.Checked == true)
            {
                c_step = '2';
            }
            else if (rbtRuleResType.Checked == true)
            {
                c_step = '3';
            }
            else if (rbtRuleResGroup.Checked == true)
            {
                c_step = '4';
            }
            if (lisBatchRule.SelectedItems.Count > 0)
            {
                ViewBatchRelationList(lisRuleRelation, c_step, ' ', "", "", "");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i;
            char c_step = ' ';
            bool b_ignore = false;
            if (lisBatchRule.SelectedItems.Count == 0)
            {
                return;
            }
            if (lisRuleResource.SelectedItems.Count == 0)
            {
                return;
            }
            for (i = 0; i < lisRuleResource.SelectedItems.Count; i++)
            {
                if (rbtRuleResource.Checked == true)
                {
                    lm_res_rel_level = 'R';
                    lm_res_id = lisRuleResource.SelectedItems[i].Text;
                    lm_res_type = "";
                    lm_res_group = "";
                }
                else if (rbtRuleResType.Checked == true)
                {
                    lm_res_rel_level = 'T';
                    lm_res_type = lisRuleResource.SelectedItems[i].Text;
                    lm_res_id = "";
                    lm_res_group = "";
                }
                else if (rbtRuleResGroup.Checked == true)
                {
                    lm_res_rel_level = 'G';
                    lm_res_group = lisRuleResource.SelectedItems[i].Text;
                    lm_res_id = "";
                    lm_res_type = "";
                }
                if (i == lisRuleResource.SelectedItems.Count - 1)
                {
                    b_ignore = false;
                }
                else
                {
                    b_ignore = true;
                }
                if (UpdateBatchRelation(MPGC.MP_STEP_CREATE, lisBatchRule.SelectedItems[0].Text, b_ignore) == false)
                {
                    break;
                }
                
            }
            if (rbtRuleResource.Checked == true)
            {
                c_step = '2';
            }
            else if (rbtRuleResType.Checked == true)
            {
                c_step = '3';
            }
            else if (rbtRuleResGroup.Checked == true)
            {
                c_step = '4';
            }
            if (lisBatchRule.SelectedItems.Count > 0)
            {
                ViewBatchRelationList(lisRuleRelation, c_step, ' ', "", "", "");
            }
            

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int i;
            char c_step = ' ';
            bool b_ignore = false;
            if (lisBatchRule.SelectedItems.Count == 0)
            {
                return;
            }
            if (lisRuleRelation.SelectedItems.Count == 0)
            {
                return;
            }
            for (i = 0; i < lisRuleRelation.SelectedItems.Count; i++)
            {
                if (rbtRuleResource.Checked == true)
                {
                    lm_res_rel_level = 'R';
                    lm_res_id = lisRuleRelation.SelectedItems[i].Text;
                    lm_res_type = "";
                    lm_res_group = "";
                }
                else if (rbtRuleResType.Checked == true)
                {
                    lm_res_rel_level = 'T';
                    lm_res_type = lisRuleRelation.SelectedItems[i].Text;
                    lm_res_id = "";
                    lm_res_group = "";
                }
                else if (rbtRuleResGroup.Checked == true)
                {
                    lm_res_rel_level = 'G';
                    lm_res_group = lisRuleRelation.SelectedItems[i].Text;
                    lm_res_id = "";
                    lm_res_type = "";
                }

                if (i == lisRuleRelation.SelectedItems.Count - 1)
                {
                    b_ignore = false;
                }
                else
                {
                    b_ignore = true;
                }
                if (UpdateBatchRelation(MPGC.MP_STEP_DELETE, lisBatchRule.SelectedItems[0].Text, b_ignore) == false)
                {
                    break;
                }
                
            }

            if (rbtRuleResource.Checked == true)
            {
                c_step = '2';
            }
            else if (rbtRuleResType.Checked == true)
            {
                c_step = '3';
            }
            else if (rbtRuleResGroup.Checked == true)
            {
                c_step = '4';
            }
            if (lisBatchRule.SelectedItems.Count > 0)
            {
                ViewBatchRelationList(lisRuleRelation, c_step, ' ', "", "", "");
            }
            
        }

        private void btnResExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond = string.Empty;

                sCond = "Creation Rule ID" + lisBatchRule.SelectedItems[0].Text;
                MPCF.ExportToExcel(lisRuleRelation, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void pnlGrpMid_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(pnlGrpMid, pnlGrpMidLeft, pnlGrpMidRight, pnlGrpMidMid, 40);
        }

    }
  
}

