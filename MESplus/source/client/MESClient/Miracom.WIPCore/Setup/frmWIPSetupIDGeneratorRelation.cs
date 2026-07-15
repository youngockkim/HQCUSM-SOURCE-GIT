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
    public partial class frmWIPSetupIDGeneratorRelation : Miracom.MESCore.SetupForm02
    {
        public frmWIPSetupIDGeneratorRelation()
        {
            InitializeComponent();
        }

        private bool CheckCondition(char s_step)
        {
            if (MPCF.CheckValue(cdvRule, 1) == false)
            {
                return false;
            }
            if (s_step == MPGC.MP_STEP_CREATE || s_step == MPGC.MP_STEP_UPDATE)
            {
                if (MPCF.CheckValue(cdvTranCode, 1) == false)
                {
                    return false;
                }
            
            }

            /* Added By YJJung 161024 Relation 최종 선택이 Oper 혹은 Factory 이여야 하는 Validation 추가 */
            if (udcMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Oper && udcMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Factory)
            {
                tabRelation.SelectedTab = tbpMFO;
                MPCF.ShowMsgBox(MPCF.GetMessage(184));
                udcMFO.Focus();
                return false;
            }
            /* Added End */
            return true;
        }

        private bool ViewRuleRelationList()
        {
            int i;
            TRSNode in_node = new TRSNode("RULE_LIST_IN");
            TRSNode out_node = new TRSNode("RULE_LIST_OUT");
            ListViewItem itmX;

            MPCF.InitListView(lisRule);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (tabRelation.SelectedTab == tbpMFO)
            {
                in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                in_node.AddString("MAT_ID", udcMFO.MatID);
                in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                in_node.AddString("FLOW", udcMFO.Flow);
                in_node.AddString("OPER", udcMFO.Oper);
            }
            else if (tabRelation.SelectedTab == tbpRes)
            {
                in_node.AddChar("REL_LEVEL", udcRes.SelectLevelChar);
                in_node.AddString("RES_TYPE", udcRes.ResourceType);
                in_node.AddString("RESG_ID", udcRes.ResourceGroup);
                in_node.AddString("RES_ID", udcRes.Resource);
            }

            if (MPCR.CallService("WIP", "WIP_View_Rule_Relation_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                itmX = new ListViewItem(out_node.GetList(0)[i].GetString("RULE_ID"), (int)SMALLICON_INDEX.IDX_CODE_DATA);

                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("TRAN_CODE"));
                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("KEY_1"));
                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("KEY_2"));
                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("KEY_3"));
                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("KEY_4"));
                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("KEY_5"));
                lisRule.Items.Add(itmX);
            }

            MPCF.FitColumnHeader(lisRule);

            return true;
        }

        private bool UpdateRuleRelation(char s_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_RULE_RELATION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = s_step;

                if (tabRelation.SelectedTab == tbpMFO)
                {
                    in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
                    in_node.AddString("MAT_ID", udcMFO.MatID);
                    in_node.AddInt("MAT_VER", udcMFO.MatVersion);
                    in_node.AddString("FLOW", udcMFO.Flow);
                    in_node.AddString("OPER", udcMFO.Oper);
                }
                else
                {
                    in_node.AddChar("REL_LEVEL", udcRes.SelectLevelChar);
                    in_node.AddString("RES_TYPE", udcRes.ResourceType);
                    in_node.AddString("RESG_ID", udcRes.ResourceGroup);
                    in_node.AddString("RES_ID", udcRes.Resource);
                }
                in_node.AddString("RULE_ID", MPCF.Trim(cdvRule.Text));
                in_node.AddString("TRAN_CODE", MPCF.Trim(cdvTranCode.Text));

                in_node.AddString("KEY_1", MPCF.Trim(cdvKey1.Text));
                in_node.AddString("KEY_2", MPCF.Trim(cdvKey2.Text));
                in_node.AddString("KEY_3", MPCF.Trim(cdvKey3.Text));
                in_node.AddString("KEY_4", MPCF.Trim(cdvKey4.Text));
                in_node.AddString("KEY_5", MPCF.Trim(cdvKey5.Text));

                if (MPCR.CallService("WIP", "WIP_Update_Rule_Relation", in_node, ref out_node) == false)
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

        private bool ViewMFOSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;

            MPCF.InitListView(udcMFO.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            switch (udcMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MWIPIDGREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT MAT_ID, MAT_VER, OPER FROM MWIPIDGREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT FLOW, OPER FROM MWIPIDGREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT OPER FROM MWIPIDGREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY OPER ");
                    sb.Append("ORDER BY OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.Factory:
                    sb.Append("SELECT FACTORY FROM MWIPIDGREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER = ' ' ");
                    sb.Append("GROUP BY FACTORY ");
                    sb.Append("ORDER BY FACTORY ASC");
                    break;

            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(udcMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        private bool ViewResSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;

            MPCF.InitListView(udcRes.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            switch (udcRes.SelectLevel)
            {
                case Miracom.MESCore.Controls.ResourceSelectLevel.R:
                    sb.Append("SELECT RES_ID FROM MWIPIDGREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcRes.SelectLevelChar + "' ");
                    sb.Append("AND RES_ID <> ' ' ");
                    sb.Append("GROUP BY RES_ID ");
                    sb.Append("ORDER BY RES_ID ASC");
                    break;

                case Miracom.MESCore.Controls.ResourceSelectLevel.G:
                    sb.Append("SELECT RESG_ID FROM MWIPIDGREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcRes.SelectLevelChar + "' ");
                    sb.Append("AND RESG_ID <> ' ' ");
                    sb.Append("GROUP BY RESG_ID ");
                    sb.Append("ORDER BY RESG_ID ASC");
                    break;

                case Miracom.MESCore.Controls.ResourceSelectLevel.T:
                    sb.Append("SELECT RES_TYPE FROM MWIPIDGREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcRes.SelectLevelChar + "' ");
                    sb.Append("AND RES_TYPE <> ' ' ");
                    sb.Append("GROUP BY RES_TYPE ");
                    sb.Append("ORDER BY RES_TYPE ASC");
                    break;
            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(udcRes.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        private void frmWIPSetupIDGeneratorRelation_Load(object sender, EventArgs e)
        {
            MPCF.InitListView(lisRule);
            tabRelation_SelectedIndexChanged(null, null);

            MPCR.SetCMFItem(MPGC.MP_CMF_RULE_RELATION, "lblKey", "cdvKey", grpCMF);
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            if (tabRelation.SelectedTab == tbpMFO)
            {
                udcMFO.GetNext(txtFind.Text);
            }
            else
            {
                udcRes.GetNext(txtFind.Text);
            }
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
            {
                btnNext_Click(null, null);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            if (tabRelation.SelectedTab == tbpMFO)
            {
                udcMFO.RefreshSelectedList();
            }
            else
            {
                udcRes.RefreshSelectedList();
            }
        }

        private void cdvKey_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvKey_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }


        private void lisRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisRule.SelectedItems.Count > 0)
            {
                cdvRule.Text = MPCF.Trim(lisRule.SelectedItems[0].Text);
                cdvTranCode.Text = MPCF.Trim(lisRule.SelectedItems[0].SubItems[1].Text);
                cdvKey1.Text = MPCF.Trim(lisRule.SelectedItems[0].SubItems[2].Text);
                cdvKey2.Text = MPCF.Trim(lisRule.SelectedItems[0].SubItems[3].Text);
                cdvKey3.Text = MPCF.Trim(lisRule.SelectedItems[0].SubItems[4].Text);
                cdvKey4.Text = MPCF.Trim(lisRule.SelectedItems[0].SubItems[5].Text);
                cdvKey5.Text = MPCF.Trim(lisRule.SelectedItems[0].SubItems[6].Text);
            }

        }

        private void cdvType_ButtonPress(object sender, EventArgs e)
        {
            cdvGenType.Init();
            MPCF.InitListView(cdvGenType.GetListView);
            cdvGenType.Columns.Add("Type Code", 150, HorizontalAlignment.Left);
            cdvGenType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvGenType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvGenType.GetListView, '1', MPGC.MP_ID_GEN_TYPE);
            cdvGenType.AddEmptyRow(1);
        }

        private void cdvTranCode_ButtonPress(object sender, EventArgs e)
        {
            cdvTranCode.Init();
            MPCF.InitListView(cdvTranCode.GetListView);
            cdvTranCode.Columns.Add("Type Code", 150, HorizontalAlignment.Left);
            cdvTranCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTranCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTranCode.GetListView, '1', MPGC.MP_ID_GEN_TRAN_CODE);
            cdvTranCode.AddEmptyRow(1);
        }

        private void cdvRule_ButtonPress(object sender, EventArgs e)
        {
            cdvRule.Init();
            MPCF.InitListView(cdvRule.GetListView);
            cdvRule.Columns.Add("Rule ID", 150, HorizontalAlignment.Left);
            cdvRule.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvRule.SelectedSubItemIndex = 0;
            WIPLIST.ViewRuleList(cdvRule.GetListView, MPCF.ToChar( cdvGenType.Text), false, "");
            cdvRule.AddEmptyRow(1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
            if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
            if (UpdateRuleRelation(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
            if (tabRelation.SelectedTab == tbpMFO)
            {
                ViewRuleRelationList();
            }
            else
            {
                ViewRuleRelationList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
            if (UpdateRuleRelation(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
            if (tabRelation.SelectedTab == tbpMFO)
            {
                ViewRuleRelationList();
            }
            else
            {
                ViewRuleRelationList();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            if (UpdateRuleRelation(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            if (tabRelation.SelectedTab == tbpMFO)
            {
                ViewRuleRelationList();
            }
            else
            {
                ViewRuleRelationList();
            }
        }

        private void tabRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(grpCMF);
            MPCF.InitListView(lisRule);
        }

        private void udcMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.GetTreeView.GetNodeCount(false));
        }

        private void udcMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.SelectedNode.GetNodeCount(false));
        }

        private void udcMFO_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            MPCF.InitListView(lisRule);
            MPCF.FieldClear(grpCMF);
            MPCF.FieldClear(grpTRAN);
            ViewRuleRelationList();
        }

        private void udcMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewMFOSettingDataList();
        }

        private void udcMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            udcMFO_LevelItemSelect(null, null);
        }

        private void udcRes_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcRes.GetTreeView.GetNodeCount(false));
        }

        private void udcRes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcRes.SelectedNode.GetNodeCount(false));
        }

        private void udcRes_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            ViewRuleRelationList();
        }

        private void udcRes_GetOnlySetData(object sender, EventArgs e)
        {
            ViewResSettingDataList();
        }

        private void udcRes_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            udcRes_LevelItemSelect(null, null);
        }



    }
}

