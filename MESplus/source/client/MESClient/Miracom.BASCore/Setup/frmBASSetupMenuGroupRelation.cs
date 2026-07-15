using System;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
using System.Text;
using System.Collections.Generic;

namespace Miracom.BASCore
{
    public partial class frmBASSetupMenuGroupRelation : SetupForm02
    {
        public frmBASSetupMenuGroupRelation()
        {
            InitializeComponent();
        }

        #region " Variables Definition "

        private bool b_activated_flag = false;

        public struct OptionDefFormat
        {
            public char cFmt;
            public char cOpt;
        };

        OptionDefFormat[] KeyChr = new OptionDefFormat[5];

        #endregion

        #region " Function Definition "

        private bool CheckCondition(char c_step)
        {
            try
            {
                if (c_step == MPGC.MP_STEP_CREATE)
                {
                    if (MPCF.Trim(cdvMenuGrpID.Text) == "") return false;
                }
                else if (c_step == MPGC.MP_STEP_DELETE)
                {
                    if (lisMenuGrp.Items.Count == 0 || lisMenuGrp.SelectedItems.Count == 0)
                        return false;
                }
                /* Added By YJJung 161024 Relation 최종 선택이 Oper 혹은 Factory 이여야 하는 Validation 추가 */
                if (tvMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Oper && tvMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Factory)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(184));
                    tvMFO.Focus();
                    return false;
                }
                /* Added End */
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// View All Menu Group List
        /// </summary>
        /// <returns></returns>
        private bool ViewMenuGroupList()
        {
            TRSNode in_node = new TRSNode("MENU_GRP_LIST_IN");
            TRSNode out_node = new TRSNode("MENU_GRP_LIST_OUT");

            ListViewItem itmX;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPCR.CallService("BAS", "BAS_View_Menu_Group_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = cdvMenuGrpID.GetListView.Items.Add(out_node.GetList(0)[i].GetString("MENU_GRP_ID"), (int)SMALLICON_INDEX.IDX_FUNCTION_GROUP); // Group Id
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("MENU_GRP_DESC"));  // Description
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("GROUP_CATEGORY"));  // Group Category
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// View MFO related Menu Group List
        /// </summary>
        /// <returns></returns>
        private bool ViewMenuGroupList2()
        {
            TRSNode in_node = new TRSNode("VIEW_MENU_RELATION_IN");
            TRSNode out_node = new TRSNode("VIEW_MENU_RELATION_OUT");

            ListViewItem itmX;

            try
            {
                MPCF.InitListView(lisMenuGrp);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddChar("OPT_LEVEL", tvMFO.SelectLevelChar);
                in_node.AddString("MAT_ID", tvMFO.MatID);
                in_node.AddInt("MAT_VER", tvMFO.MatVersion);
                in_node.AddString("FLOW", tvMFO.Flow);
                in_node.AddInt("FLOW_SEQ_NUM", tvMFO.FlowSeqNum);
                in_node.AddString("OPER", tvMFO.Oper);

                if (MPCR.CallService("BAS", "BAS_View_Menu_Group_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }

                itmX = lisMenuGrp.Items.Add(out_node.GetString("MENU_GRP_ID"), (int)SMALLICON_INDEX.IDX_FUNCTION_GROUP); // Group Id
                itmX.SubItems.Add(out_node.GetString("MENU_GRP_DESC"));  // Description
                itmX.SubItems.Add(out_node.GetString("GROUP_CATEGORY"));  // Description

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewSetDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;

            MPCF.InitListView(tvMFO.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            switch (tvMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT DISTINCT MAT_ID, MAT_VER, FLOW, OPER FROM MWIPMFODEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPTION_NAME = '" + MPGC.MP_MFO_MENU_RELATION + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT DISTINCT MAT_ID, MAT_VER, OPER FROM MWIPMFODEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPTION_NAME = '" + MPGC.MP_MFO_MENU_RELATION + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT DISTINCT FLOW, OPER FROM MWIPMFODEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPTION_NAME = '" + MPGC.MP_MFO_MENU_RELATION + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT DISTINCT OPER FROM MWIPMFODEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPTION_NAME = '" + MPGC.MP_MFO_MENU_RELATION + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY OPER ");
                    sb.Append("ORDER BY OPER ASC");
                    break;

                case MESCore.Controls.MFOSelectLevel.Factory:
                    sb.Append("SELECT DISTINCT FACTORY FROM MWIPMFODEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPTION_NAME = '" + MPGC.MP_MFO_MENU_RELATION + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER = ' ' ");
                    break;

            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(tvMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            lblDataCount.Text = tvMFO.GetListView.Items.Count.ToString();

            return true;
        }

        private bool UpdateMenuGroupRelation(char c_step)
        {
            TRSNode in_node = new TRSNode("OPTION_DEFINITION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("OPTION_NAME", MPGC.MP_MFO_MENU_RELATION);
                in_node.AddInt("OPTION_SEQ", 0);
                in_node.AddChar("REL_LEVEL", tvMFO.SelectLevelChar);
                in_node.AddString("MAT_ID", tvMFO.MatID);
                in_node.AddInt("MAT_VER", tvMFO.MatVersion);
                in_node.AddString("FLOW", tvMFO.Flow);
                in_node.AddString("OPER", tvMFO.Oper);

                if (c_step != MPGC.MP_STEP_DELETE)
                {
                    in_node.AddString("KEY_1", MPCF.Trim(cdvKey1.Text));
                    in_node.AddString("KEY_2", MPCF.Trim(cdvKey2.Text));
                    in_node.AddString("KEY_3", MPCF.Trim(cdvKey3.Text));
                    in_node.AddString("KEY_4", MPCF.Trim(cdvKey4.Text));
                    in_node.AddString("KEY_5", MPCF.Trim(cdvKey5.Text));

                    in_node.AddString("DATA_1", MPCF.Trim(cdvMenuGrpID.Text));
                }

                if (MPCR.CallService("WIP", "WIP_Update_MFO_Option_Definition", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (c_step == MPGC.MP_STEP_DELETE) RefreshtvMFO(true);
                else RefreshtvMFO();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void RefreshtvMFO()
        {
            RefreshtvMFO(false);
        }
        private void RefreshtvMFO(bool b_refresh_result_list)
        {
            tvMFO.RefreshSelectedList();

            if (b_refresh_result_list == true)
            {
                MPCF.InitListView(lisMenuGrp);
            }
        }

        private void SetKeyOption(int iKey, TRSNode key_item)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey = null;
            Label lblKey = null;
            string strTableName = key_item.GetString("KEY_TBL");

            switch (iKey)
            {
                case 0:
                    lblKey = lblKey1;
                    cdvKey = cdvKey1;
                    break;

                case 1:
                    lblKey = lblKey2;
                    cdvKey = cdvKey2;
                    break;

                case 2:
                    lblKey = lblKey3;
                    cdvKey = cdvKey3;
                    break;

                case 3:
                    lblKey = lblKey4;
                    cdvKey = cdvKey4;
                    break;

                case 4:
                    lblKey = lblKey5;
                    cdvKey = cdvKey5;
                    break;
            }

            lblKey.Text = key_item.GetString("KEY_PMT");

            if (key_item.GetChar("KEY_OPT") == 'Y')
            {
                lblKey.Font = new System.Drawing.Font(lblKey.Font, System.Drawing.FontStyle.Bold);
            }

            lblKey.Visible = cdvKey.Visible = true;
            cdvKey.Tag = key_item.GetChar("KEY_FMT") + strTableName;
            cdvKey.VisibleButton = (strTableName == "") ? false : true;

            if (cdvKey.VisibleButton == true)
                cdvKey.ReadOnly = true;
            else
                cdvKey.ReadOnly = false;

        }

        private bool ClearData()
        {
            return ClearData('1');
        }
        private bool ClearData(char c_step)
        {
            switch (c_step)
            {
                case '1':
                    lblKey1.Text = lblKey2.Text = lblKey3.Text = lblKey4.Text = lblKey5.Text = "";
                    lblKey1.Font = lblKey2.Font = lblKey3.Font = lblKey4.Font = lblKey5.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Regular);
                    lblKey1.Visible = lblKey2.Visible = lblKey3.Visible = lblKey4.Visible = lblKey5.Visible = false;

                    cdvKey1.Text = cdvKey2.Text = cdvKey3.Text = cdvKey4.Text = cdvKey5.Text = "";
                    cdvKey1.Visible = cdvKey2.Visible = cdvKey3.Visible = cdvKey4.Visible = cdvKey5.Visible = false;
                    break;
                    
                case '2':
                    MPCF.InitListView(lisAttachedMenu);
                    MPCF.InitListView(lisMenuGrp);
                    MPCF.FieldClear(pnlGeneral);
                    break;
            }

            return true;
        }
        private bool ViewOptionPrompt()
        {
            TRSNode in_node = new TRSNode("VIEW_MFO_OPTION_PROMPT_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_OPTION_PROMPT_OUT");
            List<TRSNode> node_list;
            int i;

            try
            {
                ClearData();
                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("OPTION_NAME", MPGC.MP_MFO_MENU_RELATION);

                if (MPCR.CallService("WIP", "WIP_View_MFO_Option_Prompt", in_node, ref out_node, true) == false)
                {
                    if (out_node.MsgCode == "WIP-0334")
                    {
                        //ClearData('7');
                        return true;
                    }

                    MPCR.CheckContinueProc(out_node);
                    return false;
                }

                node_list = out_node.GetList("KEY_LIST");
                for (i = 0; i < node_list.Count; i++)
                {
                    if (node_list[i].GetString("KEY_PMT") != "" &&
                        node_list[i].GetChar("KEY_OPT") != ' ' &&
                        node_list[i].GetChar("KEY_FMT") != ' ')
                        SetKeyOption(i, node_list[i]);

                    KeyChr[i].cFmt = node_list[i].GetChar("KEY_FMT");
                    KeyChr[i].cOpt = node_list[i].GetChar("KEY_OPT");
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewMenuGroup()
        {
            TRSNode in_node = new TRSNode("MENU_GRP_IN");
            TRSNode out_node = new TRSNode("MENU_GRP_OUT");

            ListViewItem itmX;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MENU_GRP_ID", MPCF.Trim(cdvMenuGrpID.Text));

                MPCF.InitListView(lisAttachedMenu);
                if (MPCR.CallService("BAS", "BAS_View_Menu_Group", in_node, ref out_node) == true)
                {
                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = lisAttachedMenu.Items.Insert(lisAttachedMenu.Items.Count, "", (int)SMALLICON_INDEX.IDX_FUNCTION);
                    }

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = lisAttachedMenu.Items[out_node.GetList(0)[i].GetInt("TRAN_SEQ") - 1];
                        itmX.SubItems[0].Text = out_node.GetList(0)[i].GetInt("TRAN_SEQ").ToString();
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("FUNC_DESC"));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("REQUIRED_FLAG").ToString());
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("PRIORITY").ToString());
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("TRAN_CODE"));
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

        #endregion

        private void frmBASSetupMenuGroupRelation_Load(object sender, EventArgs e)
        {
            this.Width = 945;
            this.Height = 640;
        }

        private void frmBASSetupMenuGroupRelation_Activated(object sender, EventArgs e)
        {
            if (b_activated_flag == false)
            {
                b_activated_flag = true;

                ViewOptionPrompt();
            }
        }

        private void cdvMenuGrpID_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvMenuGrpID.Init();
                MPCF.InitListView(cdvMenuGrpID.GetListView);
                cdvMenuGrpID.Columns.Add("Menu Group ID", 100, HorizontalAlignment.Left);
                cdvMenuGrpID.Columns.Add("Menu Group Desc", 150, HorizontalAlignment.Left);
                cdvMenuGrpID.Columns.Add("Group Category", 100, HorizontalAlignment.Left);

                ViewMenuGroupList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tvMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewSetDataList();
        }

        private void tvMFO_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            ViewMenuGroupList2();
        }

        private void tvMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.GetTreeView.GetNodeCount(false));
        }

        private void tvMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewMenuGroupList2();
        }

        private void lisMenuGrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisMenuGrp.SelectedItems.Count < 1) return;

            cdvMenuGrpID.Text = lisMenuGrp.SelectedItems[0].SubItems[0].Text;
            txtDesc.Text = lisMenuGrp.SelectedItems[0].SubItems[1].Text;

            ViewMenuGroup();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshtvMFO();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tvMFO.GetNext(txtFind.Text);
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
            {
                btnNext_Click(null, null);
            }
        }

        private void cdvMenuGrpID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            txtDesc.Text = MPCF.Trim(cdvMenuGrpID.SelectedItem.SubItems[1].Text);
            ViewMenuGroup();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;

            UpdateMenuGroupRelation(MPGC.MP_STEP_CREATE);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;

            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            UpdateMenuGroupRelation(MPGC.MP_STEP_DELETE);

            MPCF.FieldClear(pnlGeneral);
            MPCF.InitListView(lisAttachedMenu);
        }

        private void cdvKey_ButtonPress(object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            int i;
            bool b_add_empty_row;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            MPCR.ProcGRPCMFButtonPress(cdvTemp);

            b_add_empty_row = false;
            i = MPCF.ToInt(cdvTemp.Name.Substring(6));
            if (KeyChr[i - 1].cOpt != 'Y')
                b_add_empty_row = true;

            if (b_add_empty_row == true)
            {
                cdvTemp.InsertEmptyRow(0, 1);
            }
        }

        private void cdvKey_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            char cFormat;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            if ((MPCF.Trim(cdvTemp.Tag) != ""))
            {
                cFormat = MPCF.Trim(cdvTemp.Tag)[0];
                if (cFormat == 'N' || cFormat == 'F')
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (!(e.KeyChar == (char)43 || e.KeyChar == (char)45 || e.KeyChar == (char)8))
                        {
                            if (cFormat == 'F')
                            {
                                if (cdvTemp.Text.IndexOf((char)46) > -1)
                                {
                                    e.Handled = true;
                                }

                                if (!(e.KeyChar == (char)46))
                                {
                                    e.Handled = true;
                                }
                            }
                            else
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (e.KeyChar == (char)43 || e.KeyChar == (char)45)
                            {
                                if (MPCF.Trim(cdvTemp.Text) != "")
                                {
                                    e.Handled = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void tvMFO_SelectLevelChanged(object sender, EventArgs e)
        {
            ClearData('2');
        }        
    }
}
