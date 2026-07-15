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

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupBinRelation : SetupForm02
    {
        public frmWIPSetupBinRelation()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        bool b_load_flag;
        #endregion

        #region " Function Definition "

        private void ClearData(int i_case)
        {
            switch(i_case)
            {
                case 1:
                    MPCF.InitListView(lisBin);
                    MPCF.FieldClear(grpLotCMF);
                    MPCF.FieldClear(grpBinDefinition);
                    break;
            }
        }

        private bool CheckCondition()
        {
            if (tabRelation.SelectedTab == tbpMFO)
            {
                if (udcMFO.SelectedItem != MESCore.Controls.TreeSelectedItem.Oper)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    udcMFO.Focus();
                    return false;
                }
            }
            else if (tabRelation.SelectedTab == tbpResource)
            {
                if (udcRes.SelectedItem == MESCore.Controls.TreeSelectedItem.None || udcRes.SelectedItem == MESCore.Controls.TreeSelectedItem.Another)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    udcRes.Focus();
                    return false;
                }
            }
            if (MPCF.CheckValue(cdvBinID, 1) == false) return false;
            if (MPCF.CheckValue(cdvBinUnit, 1) == false) return false;

            return true;
        }

        private void SetCmfItem()
        {
            ArrayList lblList;
            Label lblTemp;
            int i;

            MPCR.SetCMFItem(MPGC.MP_CMF_LOT, "lblCrtCMF", "cdvCrtCMF", grpLotCMF);
            lblList = MPCF.GetIndexedControl("lblCrtCMF", grpLotCMF);

            for (i = 0; i < 20; i++)
            {
                lisBin.Columns[i + 3].Width = 0;
                lisBin.Columns[i + 3].Text = "";

                lblTemp = (Label)lblList[i];
                if (MPCF.Trim(lblTemp.Text) != "")
                {
                    lisBin.Columns[i + 3].Width = 80;
                    lisBin.Columns[i + 3].Text = lblTemp.Text;
                }
            }
        }

        private bool ViewBinRelation(char c_rel_level, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_res_id, string s_resg_id, string s_res_type)
        {
            TRSNode in_node = new TRSNode("VIEW_BIN_RELATION_IN");
            TRSNode out_node = new TRSNode("VIEW_BIN_RELATION_OUT");
            int i;
            ListViewItem itmx;
            List<TRSNode> bin_list;

            try
            {
                ClearData(1);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("REL_LEVEL", c_rel_level);
                in_node.AddString("MAT_ID", s_mat_id);
                in_node.AddInt("MAT_VER", i_mat_ver);
                in_node.AddString("FLOW", s_flow);
                in_node.AddString("OPER", s_oper);
                in_node.AddString("RES_ID", s_res_id);
                in_node.AddString("RESG_ID", s_resg_id);
                in_node.AddString("RES_TYPE", s_res_type);

                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Bin_Relation", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    bin_list = out_node.GetList("BIN_LIST");
                    for (i = 0; i < bin_list.Count; i++)
                    {
                        itmx = new ListViewItem(bin_list[i].GetString("BIN_ID"), (int)SMALLICON_INDEX.IDX_PART);
                        itmx.SubItems.Add(bin_list[i].GetString("BIN_UNIT"));
                        itmx.SubItems.Add(bin_list[i].GetChar("COL_OTHER_UNIT_FLAG").ToString());
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_1"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_2"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_3"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_4"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_5"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_6"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_7"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_8"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_9"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_10"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_11"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_12"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_13"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_14"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_15"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_16"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_17"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_18"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_19"));
                        itmx.SubItems.Add(bin_list[i].GetString("LOT_CMF_20"));

                        lisBin.Items.Add(itmx);
                    }

                    in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
                } while (in_node.GetInt("NEXT_SEQ") > 0);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool UpdateBinRelation(char ProcStep, char c_rel_level, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, string s_res_id, string s_resg_id, string s_res_type)
        {
            TRSNode in_node = new TRSNode("UPDATE_BIN_RELATION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("BIN_ID", cdvBinID.Text);
                in_node.AddString("BIN_UNIT", cdvBinUnit.Text);
                in_node.AddChar("COL_OTHER_UNIT_FLAG", chkCollectOtherUnit.Checked == true ? 'Y' : ' ');
                in_node.AddString("LOT_CMF_1", cdvCrtCmf1.Text);
                in_node.AddString("LOT_CMF_2", cdvCrtCmf2.Text);
                in_node.AddString("LOT_CMF_3", cdvCrtCmf3.Text);
                in_node.AddString("LOT_CMF_4", cdvCrtCmf4.Text);
                in_node.AddString("LOT_CMF_5", cdvCrtCmf5.Text);
                in_node.AddString("LOT_CMF_6", cdvCrtCmf6.Text);
                in_node.AddString("LOT_CMF_7", cdvCrtCmf7.Text);
                in_node.AddString("LOT_CMF_8", cdvCrtCmf8.Text);
                in_node.AddString("LOT_CMF_9", cdvCrtCmf9.Text);
                in_node.AddString("LOT_CMF_10", cdvCrtCmf10.Text);
                in_node.AddString("LOT_CMF_11", cdvCrtCmf11.Text);
                in_node.AddString("LOT_CMF_12", cdvCrtCmf12.Text);
                in_node.AddString("LOT_CMF_13", cdvCrtCmf13.Text);
                in_node.AddString("LOT_CMF_14", cdvCrtCmf14.Text);
                in_node.AddString("LOT_CMF_15", cdvCrtCmf15.Text);
                in_node.AddString("LOT_CMF_16", cdvCrtCmf16.Text);
                in_node.AddString("LOT_CMF_17", cdvCrtCmf17.Text);
                in_node.AddString("LOT_CMF_18", cdvCrtCmf18.Text);
                in_node.AddString("LOT_CMF_19", cdvCrtCmf19.Text);
                in_node.AddString("LOT_CMF_20", cdvCrtCmf20.Text);

                in_node.AddChar("REL_LEVEL", c_rel_level);
                in_node.AddString("MAT_ID", s_mat_id);
                in_node.AddInt("MAT_VER", i_mat_ver);
                in_node.AddString("FLOW", s_flow);
                in_node.AddString("OPER", s_oper);
                in_node.AddString("RES_ID", s_res_id);
                in_node.AddString("RESG_ID", s_resg_id);
                in_node.AddString("RES_TYPE", s_res_type);

                if (MPCR.CallService("WIP", "WIP_Update_Bin_Relation", in_node, ref out_node) == false)
                {
                    return false;
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
                    sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MWIPBINREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 ");
                    sb.Append("AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT MAT_ID, MAT_VER, OPER FROM MWIPBINREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 ");
                    sb.Append("AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT FLOW, OPER FROM MWIPBINREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT OPER FROM MWIPBINREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcMFO.SelectLevelChar + "' ");
                    sb.Append("AND OPER <> ' ' ");
                    sb.Append("GROUP BY OPER ");
                    sb.Append("ORDER BY OPER ASC");
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
                    sb.Append("SELECT RES_ID FROM MWIPBINREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcRes.SelectLevelChar + "' ");
                    sb.Append("AND RES_ID <> ' ' ");
                    sb.Append("GROUP BY RES_ID ");
                    sb.Append("ORDER BY RES_ID ASC");
                    break;

                case Miracom.MESCore.Controls.ResourceSelectLevel.G:
                    sb.Append("SELECT RESG_ID FROM MWIPBINREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND REL_LEVEL = '" + udcRes.SelectLevelChar + "' ");
                    sb.Append("AND RESG_ID <> ' ' ");
                    sb.Append("GROUP BY RESG_ID ");
                    sb.Append("ORDER BY RESG_ID ASC");
                    break;

                case Miracom.MESCore.Controls.ResourceSelectLevel.T:
                    sb.Append("SELECT RES_TYPE FROM MWIPBINREL ");
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

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.lisBin;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmWIPSetupBinRelation_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.InitListView(lisBin);
                    SetCmfItem();

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCrtCmf_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCrtCmf_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
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

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisBin, this.Text, "");
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
            if (MPCF.Trim(udcMFO.Oper) != "")
            {
                ViewBinRelation(udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, "", "", "");
            }
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
            ViewBinRelation(udcRes.SelectLevelChar, "", 0, "", "", udcRes.Resource, udcRes.ResourceGroup, udcRes.ResourceType);
        }

        private void udcRes_GetOnlySetData(object sender, EventArgs e)
        {
            ViewResSettingDataList();
        }

        private void udcRes_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            udcRes_LevelItemSelect(null, null);
        }

        private void lisBin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisBin.SelectedItems.Count < 1) return;

            cdvCrtCmf1.Text = lisBin.SelectedItems[0].SubItems[3].Text;
            cdvCrtCmf2.Text = lisBin.SelectedItems[0].SubItems[4].Text;
            cdvCrtCmf3.Text = lisBin.SelectedItems[0].SubItems[5].Text;
            cdvCrtCmf4.Text = lisBin.SelectedItems[0].SubItems[6].Text;
            cdvCrtCmf5.Text = lisBin.SelectedItems[0].SubItems[7].Text;
            cdvCrtCmf6.Text = lisBin.SelectedItems[0].SubItems[8].Text;
            cdvCrtCmf7.Text = lisBin.SelectedItems[0].SubItems[9].Text;
            cdvCrtCmf8.Text = lisBin.SelectedItems[0].SubItems[10].Text;
            cdvCrtCmf9.Text = lisBin.SelectedItems[0].SubItems[11].Text;
            cdvCrtCmf10.Text = lisBin.SelectedItems[0].SubItems[12].Text;
            cdvCrtCmf11.Text = lisBin.SelectedItems[0].SubItems[13].Text;
            cdvCrtCmf12.Text = lisBin.SelectedItems[0].SubItems[14].Text;
            cdvCrtCmf13.Text = lisBin.SelectedItems[0].SubItems[15].Text;
            cdvCrtCmf14.Text = lisBin.SelectedItems[0].SubItems[16].Text;
            cdvCrtCmf15.Text = lisBin.SelectedItems[0].SubItems[17].Text;
            cdvCrtCmf16.Text = lisBin.SelectedItems[0].SubItems[18].Text;
            cdvCrtCmf17.Text = lisBin.SelectedItems[0].SubItems[19].Text;
            cdvCrtCmf18.Text = lisBin.SelectedItems[0].SubItems[20].Text;
            cdvCrtCmf19.Text = lisBin.SelectedItems[0].SubItems[21].Text;
            cdvCrtCmf20.Text = lisBin.SelectedItems[0].SubItems[22].Text;

            cdvBinID.Text = lisBin.SelectedItems[0].SubItems[0].Text;
            cdvBinUnit.Text = lisBin.SelectedItems[0].SubItems[1].Text;
            chkCollectOtherUnit.Checked = lisBin.SelectedItems[0].SubItems[2].Text == "Y" ? true : false;
        }

        private void cdvBinDef_ButtonPress(object sender, EventArgs e)
        {
            string s_filter = cdvBinID.Text;

            cdvBinID.Init();
            MPCF.InitListView(cdvBinID.GetListView);
            cdvBinID.Columns.Add("Bin ID", 50, HorizontalAlignment.Left);
            cdvBinID.Columns.Add("Description", 50, HorizontalAlignment.Left);
            cdvBinID.SelectedSubItemIndex = 0;
            cdvBinID.SelectedDescIndex = 1;
            /* 2013.06.12. Aiden. Filter 추가 */
            if (WIPLIST.ViewBinDefList(cdvBinID.GetListView, s_filter) == false) return;
        }

        private void cdvBinUnit_ButtonPress(object sender, EventArgs e)
        {
            cdvBinUnit.Init();
            MPCF.InitListView(cdvBinUnit.GetListView);
            cdvBinUnit.Columns.Add("Unit", 50, HorizontalAlignment.Left);
            cdvBinUnit.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvBinUnit.SelectedSubItemIndex = 0;
            cdvBinUnit.SelectedDescIndex = 1;
            BASLIST.ViewGCMDataList(cdvBinUnit.GetListView, '1', MPGC.MP_WIP_UNIT_TABLE);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false) return;

            if (tabRelation.SelectedTab == tbpMFO)
            {
                if (UpdateBinRelation(MPGC.MP_STEP_CREATE, udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, "", "", "") == false) return;
                udcMFO_LevelItemSelect(null, null);
            }
            else
            {
                if (UpdateBinRelation(MPGC.MP_STEP_CREATE, udcRes.SelectLevelChar, "", 0, "", "", udcRes.Resource, udcRes.ResourceGroup, udcRes.ResourceType) == false) return;
                udcRes_LevelItemSelect(null, null);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition() == false) return;

            if (tabRelation.SelectedTab == tbpMFO)
            {
                if (UpdateBinRelation(MPGC.MP_STEP_UPDATE, udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, "", "", "") == false) return;
                udcMFO_LevelItemSelect(null, null);
            }
            else
            {
                if (UpdateBinRelation(MPGC.MP_STEP_UPDATE, udcRes.SelectLevelChar, "", 0, "", "", udcRes.Resource, udcRes.ResourceGroup, udcRes.ResourceType) == false) return;
                udcRes_LevelItemSelect(null, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;

            if (CheckCondition() == false) return;

            if (tabRelation.SelectedTab == tbpMFO)
            {
                if (UpdateBinRelation(MPGC.MP_STEP_DELETE, udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, "", "", "") == false) return;
                udcMFO_LevelItemSelect(null, null);
            }
            else
            {
                if (UpdateBinRelation(MPGC.MP_STEP_DELETE, udcRes.SelectLevelChar, "", 0, "", "", udcRes.Resource, udcRes.ResourceGroup, udcRes.ResourceType) == false) return;
                udcRes_LevelItemSelect(null, null);
            }
        }

    
    }
}
