using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.MESCore.Controls;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.BASCore
{
    public partial class frmBASSetupInquiryScreenRelation : SetupForm02
    {
        public frmBASSetupInquiryScreenRelation()
        {
            InitializeComponent();
        }

        #region " Constants Difinition "
        
        private const string COND_TYPE_LOT_STATUS = "Lot Status";
        private const string COND_TYPE_LOT_ATTR = "Lot Attribute";
        private const string COND_TYPE_SUBLOT_STATUS = "Sublot Status";
        private const string COND_TYPE_SUBLOT_ATTR = "Sublot Attribute";
        private const string COND_TYPE_CUST_COND = "Custom Condition";
        private const string COND_TYPE_RES_STATUS = "Resource Status";
        private const string COND_TYPE_RES_ATTR = "Resource Attribute";
        private const string COND_TYPE_FACTORY = "Factory";

        private const string VALUE_TYPE_FIXED_VALUE = "Fixed Value";
        private const string VALUE_TYPE_GCM_TABLE = "GCM Table";
        private const string VALUE_TYPE_USER_SQL = "User SQL";

        #endregion

        #region " Variables Definition "

        private bool b_activated_flag = false;
        private string m_selected_relation_key = string.Empty;
        private char m_opt_level;
        private string m_res_id = string.Empty;
        private string m_res_type = string.Empty;
        private string m_resg_id = string.Empty;

        #endregion

        #region " Functions Definition "

        //
        // InitResourceTree()
        //       - Initialze Resource Tree Control
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
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
            else if (rbtResource.Checked == true)
            {
                if (RASLIST.ViewResourceList(tvResList, false) == false) return;
            }
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

        //
        // ViewGCMKeyList()
        //       - Get all the Key from GCM table
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewGCMKeyList(ListView listView, string tableName)
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");
            TRSNode out_node = new TRSNode("VIEW_TABLE_OUT");
            int i;
            string s_temp_1;
            string s_temp_2;

            try
            {
                MPCF.InitListView(listView);
                listView.Columns.Add("Column");
                listView.Columns.Add("Description");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", tableName);
                in_node.AddChar("INCLUDE_CENTRAL_TABLE_FLAG", 'Y');

                if (MPCR.CallService("BAS", "BAS_View_Table", in_node, ref out_node) == false)
                {
                    return false;
                }

                ListViewItem itmx;

                //Keys List
                for (i = 1; i <= 10; i++)
                {
                    s_temp_1 = "KEY_" + i.ToString();
                    s_temp_2 = s_temp_1 + "_PRT";

                    if (out_node.GetString(s_temp_2) != "")
                    {
                        itmx = new ListViewItem(s_temp_1, (int)SMALLICON_INDEX.IDX_KEY);
                        itmx.SubItems.Add(out_node.GetString(s_temp_2));
                        listView.Items.Add(itmx);
                    }
                }

                //Datas List
                for (i = 1; i <= 10; i++)
                {
                    s_temp_1 = "DATA_" + i.ToString();
                    s_temp_2 = s_temp_1 + "_PRT";

                    if (out_node.GetString(s_temp_2) != "")
                    {
                        itmx = new ListViewItem(s_temp_1, (int)SMALLICON_INDEX.IDX_CODE_DATA);
                        itmx.SubItems.Add(out_node.GetString(s_temp_2));
                        listView.Items.Add(itmx);
                    }
                }

                MPCF.FitColumnHeader(listView);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // ViewInquiryScreenRelation()
        //       - Get inquiry screen relation information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public bool ViewInquiryScreenRelation()
        {
            TRSNode in_node = new TRSNode("VIEW_INQUIRY_SCREEN_RELATION_IN");
            TRSNode out_node = new TRSNode("VIEW_INQUIRY_SCREEN_RELATION_OUT");
            List<TRSNode> list_node;
            int i;
            int i1;
            string s_tmp;

            MPCF.FieldClear(tbpGeneral);
            MPCF.ClearList(spdCond);
            cboCondition.Text = "";
            cdvField.Text = "";
            cboOperator.Text = "";

            cboValueType.Text = "";
            cdvValue1.Text = "";
            cdvValue2.Text = "";

            txtCond1.Text = "(";
            txtCond2.Text = "";
            txtRelation.Text = "";


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("RELATION_KEY", m_selected_relation_key);

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Inquiry_Screen_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvScreenID.Text = out_node.GetString("SCREEN_ID");
                cdvScreenGrp.Text = out_node.GetString("SCREEN_GROUP");
                txtScreenDesc.Text = out_node.GetString("SCREEN_DESC");

                list_node = out_node.GetList("CONDITION_LIST");
                for (i = 0; i < list_node.Count; i++)
                {
                    if (list_node[i].GetChar("OPT_LEVEL") == 'F')
                    {


                    }
                    else
                    {
                        i1 = spdCond.ActiveSheet.RowCount;
                        spdCond.ActiveSheet.RowCount++;

                        spdCond.ActiveSheet.Cells[i1, 0].Value = list_node[i].GetString("AND_OR");
                        spdCond.ActiveSheet.Cells[i1, 1].Value = list_node[i].GetString("L_BRACKET");

                        s_tmp = list_node[i].GetString("COND_TYPE");
                        if (s_tmp == "LS")
                            s_tmp = COND_TYPE_LOT_STATUS;
                        else if (s_tmp == "LA")
                            s_tmp = COND_TYPE_LOT_ATTR;
                        else if (s_tmp == "RS")
                            s_tmp = COND_TYPE_RES_STATUS;
                        else if (s_tmp == "RA")
                            s_tmp = COND_TYPE_RES_ATTR;
                        else if (s_tmp == "CC")
                            s_tmp = COND_TYPE_CUST_COND;

                        spdCond.ActiveSheet.Cells[i1, 2].Value = s_tmp;

                        spdCond.ActiveSheet.Cells[i1, 3].Value = list_node[i].GetString("FIELD_NAME");
                        spdCond.ActiveSheet.Cells[i1, 4].Value = list_node[i].GetString("OPERATOR");

                        s_tmp = list_node[i].GetString("VALUE_TYPE");
                        if (s_tmp == "FV")
                            s_tmp = VALUE_TYPE_FIXED_VALUE;
                        else if (s_tmp == "GT")
                            s_tmp = VALUE_TYPE_GCM_TABLE;
                        else if (s_tmp == "US")
                            s_tmp = VALUE_TYPE_USER_SQL;

                        spdCond.ActiveSheet.Cells[i1, 5].Value = s_tmp;

                        spdCond.ActiveSheet.Cells[i1, 6].Value = list_node[i].GetString("VALUE_1");
                        spdCond.ActiveSheet.Cells[i1, 7].Value = list_node[i].GetString("VALUE_2");
                        spdCond.ActiveSheet.Cells[i1, 8].Value = list_node[i].GetString("R_BRACKET");
                    }
                }
                in_node.SetInt("NEXT_COND_SEQ", out_node.GetInt("NEXT_COND_SEQ"));

            } while (in_node.GetInt("NEXT_COND_SEQ") > 0);

            MakeRelationCondition();

            return true;
        }

        private void ChangeSQLSyntaxColor()
        {
            int i_start = 0;
            int i_len = 0;

            if (MPCF.Trim(txtCond2.Text) == "")
            {
                return;
            }

            if (txtCond2.Text[txtCond2.Text.Length - 1] != ' ')
            {
                txtCond2.Text += " ";
            }

            txtCond2.SelectionStart = 0;
            txtCond2.SelectionLength = txtCond2.Text.Length;
            txtCond2.SelectionColor = System.Drawing.SystemColors.ControlText;

            while (i_len < txtCond2.Text.Length)
            {
                if (txtCond2.Text[i_len] == ' ' || i_len == txtCond2.Text.Length - 1)
                {
                    if (MPCF.IsSQLSyntax(MPCF.ToUpper(txtCond2.Text.Substring(i_start, i_len - i_start))) == true ||
                        txtCond2.Text.Substring(i_start, i_len - i_start).IndexOf("$") > 0)
                    {
                        txtCond2.SelectionStart = i_start;
                        txtCond2.SelectionLength = i_len - i_start;
                        txtCond2.SelectionColor = System.Drawing.Color.Blue;
                        txtCond2.SelectionStart = i_len;
                        txtCond2.SelectionLength = 0;
                        txtCond2.SelectionColor = System.Drawing.SystemColors.ControlText;
                    }

                    i_start = i_len;
                }

                i_len++;
            }
        }

        private void MakeCond1Text()
        {
            string s_cond;

            s_cond = "";

            if (cboCondition.Text != "")
            {
                if (cboCondition.SelectedIndex < 4) // General Condition
                {
                    switch (cboCondition.SelectedIndex)
                    {
                        case 0: // LOT STATUS
                            s_cond = "select LOT_ID from MWIPLOTSTS where lot_id = $LOT_ID and ";
                            break;

                        case 1: // LOT ATTRIBUTE
                            s_cond = "select ATTR_KEY from MATRNAMSTS where factory = $FACTORY and attr_type = '" + MPGC.MP_ATTR_TYPE_LOT + "' and attr_key = $LOT_ID and attr_name = ";
                            break;

                        case 2: // SUBLOT STATUS
                            s_cond = "select SUBLOT_ID from MWIPSLTSTS where lot_id = $LOT_ID and ";
                            break;

                        case 3: // SUBLOT ATTRIBUTE
                            s_cond = "select ATTR_KEY from MATRNAMSTS where factory = $FACTORY and attr_type = '" + MPGC.MP_ATTR_TYPE_SUBLOT + "' and attr_key = $SUBLOT_ID and attr_name = ";
                            break;
                    }
                }
            }

            if (cdvField.Text != "")
            {
                if (cboCondition.SelectedIndex < 4) // General Condition
                {
                    switch (cboCondition.SelectedIndex)
                    {
                        case 0: // LOT STATUS
                        case 2: // SUBLOT STATUS
                            s_cond += cdvField.Text + " ";
                            break;

                        case 1: // LOT ATTRIBUTE
                        case 3: // SUBLOT ATTRIBUTE
                            s_cond += "'" + cdvField.Text + "' and attr_value ";
                            break;
                    }
                }
            }

            if (cboOperator.Text != "")
            {
                s_cond += cboOperator.Text + " (";
            }

            txtCond1.Text = s_cond;
        }

        
        //
        // ViewStatusColumnList()
        //       - To List all Column names from the table
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ListView : 
        //       - string : 
        //
        private bool ViewStatusColumnList(ListView listView, string tableName)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = '" + tableName + "' " +
                                     "       ORDER BY COLUMN_NAME");
            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(listView, out_node);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (out_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        //
        // ViewSetDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewSetDataList(udcMFOTreeList tv)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;

            MPCF.InitListView(tv.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            switch (tv.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT DISTINCT MAT_ID, MAT_VER, FLOW, OPER FROM MBASSCRREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = '1' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT DISTINCT MAT_ID, MAT_VER, OPER FROM MBASSCRREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = '4' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT DISTINCT FLOW, OPER FROM MBASSCRREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = '2' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT DISTINCT OPER FROM MBASSCRREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = '3' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
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

                MPCR.FillDataView(tv.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            lblDataCount.Text = tv.GetListView.Items.Count.ToString();

            return true;
        }

        private bool ViewSetDataList(ListView lisRes)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;
            ColumnHeader col;
            
            MPCF.InitListView(lisRes);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();
            col = new ColumnHeader();

            if (rbtFactory.Checked == true)
            {
                ViewScreenList();
                return true;
            }
            else if (rbtResource.Checked == true)
            {
                sb.Append("SELECT DISTINCT RES_ID FROM MBASSCRREL ");
                sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = 'R' ");
                sb.Append("AND RES_ID <> ' ' ");
                sb.Append("ORDER BY RES_ID ASC");
                
                col.Text = MPCF.FindLanguage("Resource", 0);
            }
            else if (rbtResType.Checked == true)
            {    
                sb.Append("SELECT DISTINCT RES_TYPE, OPER FROM MBASSCRREL ");
                sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = 'T' ");
                sb.Append("AND RES_TYPE <> ' ' ");
                sb.Append("ORDER BY RES_TYPE ASC");

                col.Text = MPCF.FindLanguage("Resource Type", 0);
            }
            else if (rbtResGroup.Checked == true)
            {
                sb.Append("SELECT DISTINCT RESG_ID FROM MBASSCRREL ");
                sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = 'G' ");
                sb.Append("AND RESG_ID <> ' ' ");
                sb.Append("ORDER BY RESG_ID ASC");

                col.Text = MPCF.FindLanguage("Resource Group", 0);
            }

            in_node.AddString("SQL", sb.ToString());

            while (lisRes.Columns.Count > 0)
            {
                lisRes.Columns.RemoveAt(0);
            }
            lisRes.Columns.Add(col);

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(lisRes, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            lblDataCount.Text = lisRes.Items.Count.ToString();

            MPCF.FitColumnHeader(lisRes);
            return true;
        }

        //
        // ViewScreenList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewScreenList()
        {
            TRSNode in_node = new TRSNode("VIEW_SCREEN_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SCREEN_LIST_OUT");
            ListViewItem ItmX;
            int i;

            m_selected_relation_key = "";
            MPCF.ClearList(lisScreen);
            MPCF.FieldClear(tbpGeneral);
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (tabSelectLevel.SelectedTab == tbpMFO)
            {
                in_node.AddChar("OPT_LEVEL", tvMFO.SelectLevelChar);
                in_node.AddString("MAT_ID", tvMFO.MatID);
                in_node.AddInt("MAT_VER", tvMFO.MatVersion);
                in_node.AddString("FLOW", tvMFO.Flow);
                in_node.AddInt("FLOW_SEQ_NUM", tvMFO.FlowSeqNum);
                in_node.AddString("OPER", tvMFO.Oper);
            }
            else if (tabSelectLevel.SelectedTab == tbpResource)
            {
                in_node.AddChar("OPT_LEVEL", m_opt_level);
                in_node.AddString("RES_ID", m_res_id);
                in_node.AddString("RESG_ID", m_resg_id);
                in_node.AddString("RES_TYPE", m_res_type);
            }
                
            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Inquiry_Screen_Relation_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    ItmX = new ListViewItem(out_node.GetList(0)[i].GetString("SCREEN_ID"));

                    ItmX.SubItems.Add(out_node.GetList(0)[i].GetString("MODULE_NAME"));
                    ItmX.SubItems.Add(out_node.GetList(0)[i].GetString("SERVICE_NAME"));
                    ItmX.SubItems[0].Tag = out_node.GetList(0)[i].GetString("RELATION_KEY");

                    lisScreen.Items.Add(ItmX);
                }

                in_node.SetString("NEXT_RELATION_KEY", out_node.GetString("NEXT_RELATION_KEY"));
            } while (in_node.GetString("NEXT_RELATION_KEY") != "" || in_node.GetString("NEXT_RELATION_KEY") != "");
            
            return true;
        }

        private bool CheckCondition(char c_proc_step)
        {
            //int i;
            //int i_l_bracket;
            //int i_r_bracket;

            

            // Check Create/Update/Delete Condition
            if (tabSelectLevel.SelectedTab == tbpMFO)
            {
                if (tvMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Oper)
                {
                    tabInfo.SelectedTab = tbpGeneral;
                    MPCF.ShowMsgBox(MPCF.GetMessage(184));
                    tvMFO.Focus();
                    return false;
                }
            }
            else
            {
                if ((m_opt_level == 'R' && m_res_id == "") ||
                    (m_opt_level == 'G' && m_resg_id == "") ||
                    (m_opt_level == 'T' && m_res_type == ""))
                {
                    tabInfo.SelectedTab = tbpGeneral;
                    MPCF.ShowMsgBox(MPCF.GetMessage(184));
                    tvResList.Focus();
                    return false;
                }
            }

            // Check Update/Delete Condition
            if (c_proc_step == MPGC.MP_STEP_UPDATE || c_proc_step == MPGC.MP_STEP_DELETE)
            {
                if (m_selected_relation_key == "")
                {
                    tabInfo.SelectedTab = tbpGeneral;
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    lisScreen.Focus();
                    return false;
                }
            }

            // 현재 Condition은 사용하지 않음
            // Check Create/Update Condition
            //if (c_proc_step == MPGC.MP_STEP_CREATE || c_proc_step == MPGC.MP_STEP_UPDATE)
            //{
            //    i_l_bracket = 0;
            //    i_r_bracket = 0;

            //    for (i = 0; i < txtRelation.Text.Length; i++)
            //    {
            //        if (txtRelation.Text[i] == '(')
            //        {
            //            i_l_bracket++;
            //        }
            //        else if (txtRelation.Text[i] == ')')
            //        {
            //            i_r_bracket++;
            //        }
            //    }

            //    if (i_l_bracket != i_r_bracket)
            //    {
            //        tabInfo.SelectedTab = tbpCondition;
            //        MPCF.ShowMsgBox(MPCF.GetMessage(302));
            //        spdCond.Focus();
            //        return false;
            //    }
            //}
            return true;
        }

        //
        // UpdateRelation()
        //       - Update Inquiry Screen Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool UpdateRelation(char c_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_RELATION_IN");
            TRSNode out_node = new TRSNode("UPDATE_RELATION_OUT");
            //TRSNode list_item;
            //int i;
            //int i_tmp;
            //string s_tmp;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (tabSelectLevel.SelectedTab == tbpMFO)
            {
                in_node.AddChar("OPT_LEVEL", tvMFO.SelectLevelChar);
                in_node.AddString("MAT_ID", tvMFO.MatID);
                in_node.AddInt("MAT_VER", tvMFO.MatVersion);
                in_node.AddString("FLOW", tvMFO.Flow);
                in_node.AddInt("FLOW_SEQ_NUM", tvMFO.FlowSeqNum);
                in_node.AddString("OPER", tvMFO.Oper);
            }
            else if (tabSelectLevel.SelectedTab == tbpResource)
            {
                in_node.AddChar("OPT_LEVEL", m_opt_level);
                in_node.AddString("RES_ID", m_res_id);
                in_node.AddString("RES_TYPE", m_res_type);
                in_node.AddString("RESG_ID", m_resg_id);
            }

            in_node.AddString("SCREEN_ID", cdvScreenID.Text);

            if (c_step == MPGC.MP_STEP_UPDATE || c_step == MPGC.MP_STEP_DELETE)
            {
                in_node.AddString("RELATION_KEY", m_selected_relation_key);
            }

            // 현재 Condition 은 포함하지 않는다.
            //if (c_step == MPGC.MP_STEP_CREATE || c_step == MPGC.MP_STEP_UPDATE)
            //{
            //    if (tabSelectLevel.SelectedTab == tbpResource && rbtFactory.Checked == true)
            //    {
            //        foreach (TextBox tBox in pnlFactoryCnd.Controls)
            //        {
            //            if (tBox is TextBox)
            //            {
            //                list_item = in_node.AddNode("CONDITION_LIST");
            //                list_item.AddString("COND_TYPE", "FA");
            //                list_item.AddString("VALUE_1", tBox.Text);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        for (i = 0; i < spdCond.ActiveSheet.RowCount; i++)
            //        {
            //            list_item = in_node.AddNode("CONDITION_LIST");
            //            list_item.AddString("AND_OR", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 0].Value));
            //            list_item.AddString("L_BRACKET", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 1].Value));

            //            s_tmp = "";
            //            if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_LOT_STATUS)
            //                s_tmp = "LS";
            //            else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_LOT_ATTR)
            //                s_tmp = "LA";
            //            else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_RES_STATUS)
            //                s_tmp = "RS";
            //            else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_RES_ATTR)
            //                s_tmp = "RA";
            //            else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_CUST_COND)
            //                s_tmp = "CC";

            //            list_item.AddString("COND_TYPE", s_tmp);

            //            list_item.AddString("FIELD_NAME", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 3].Value));
            //            list_item.AddString("OPERATOR", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 4].Value));

            //            s_tmp = "";
            //            if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 5].Value) == VALUE_TYPE_FIXED_VALUE)
            //                s_tmp = "FV";
            //            else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 5].Value) == VALUE_TYPE_GCM_TABLE)
            //                s_tmp = "GT";
            //            else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 5].Value) == VALUE_TYPE_USER_SQL)
            //                s_tmp = "US";

            //            list_item.AddString("VALUE_TYPE", s_tmp);

            //            i_tmp = MPCF.ByteLen(spdCond.ActiveSheet.Cells[i, 6].Value);
            //            if (i_tmp > 4000)
            //            {
            //                s_tmp = MPCF.ByteMid(spdCond.ActiveSheet.Cells[i, 6].Value, 0, 4000);
            //                list_item.AddString("VALUE_1", s_tmp);

            //                s_tmp = MPCF.ByteMid(spdCond.ActiveSheet.Cells[i, 6].Value, 4000, i_tmp - 4000);
            //                list_item.AddString("VALUE_2", s_tmp);
            //            }
            //            else
            //            {
            //                list_item.AddString("VALUE_1", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 6].Value));
            //                list_item.AddString("VALUE_2", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 7].Value));
            //            }
            //            list_item.AddString("R_BRACKET", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 8].Value));
            //        }
            //    }
            //}

            if (MPCR.CallService("BAS", "BAS_Update_Inquiry_Screen_Relation", in_node, ref out_node) == false)
            {
                
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            ViewScreenList();
            return true;
        }

        private void MakeRelationCondition()
        {
            int i;
            string s_relation;

            s_relation = "";
            for (i = 0; i < spdCond.ActiveSheet.RowCount; i++)
            {
                s_relation += MPCF.Trim(spdCond.ActiveSheet.Cells[i, 1].Value) + " " + ((int)(i + 1)).ToString() + " " + MPCF.Trim(spdCond.ActiveSheet.Cells[i, 8].Value);
                if (i < spdCond.ActiveSheet.RowCount - 1)
                {
                    s_relation += " " + MPCF.Trim(spdCond.ActiveSheet.Cells[i + 1, 0].Value) + " ";
                }
            }

            txtRelation.Text = s_relation;
        }

        private void spdCondCellClick(int i_row)
        {
            grpConditionList.Tag = i_row;

            cboCondition.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 2].Value);
            cdvField.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 3].Value);
            cboOperator.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 4].Value);

            MakeCond1Text();

            cboValueType.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 5].Value);

            cdvValue1.Text = "";
            cdvValue2.Text = "";

            if (cboValueType.SelectedIndex == 0)
            {
                cdvValue1.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 6].Value);
            }
            else if (cboValueType.SelectedIndex == 1)
            {
                cdvValue1.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 6].Value);

                cdvValue1_SelectedItemChanged(null, null);

                cdvValue2.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 7].Value);

                cdvValue2_SelectedItemChanged(null, null);
            }
            else if (cboValueType.SelectedIndex == 2)
            {
                txtCond2.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 6].Value);
                ChangeSQLSyntaxColor();
            }
        }

        #endregion

        private void frmBASSetupInquiryScreenRelation_Activated(object sender, EventArgs e)
        {
            if (b_activated_flag == false)
            {
                b_activated_flag = true;

                
                tabSelectLevel_SelectedIndexChanged(null, null);

            }
        }

        private void cdvScreenGrp_ButtonPress(object sender, EventArgs e)
        {
            cdvScreenGrp.Init();
            MPCF.InitListView(cdvScreenGrp.GetListView);
            cdvScreenGrp.Columns.Add("Screen Group", 150, HorizontalAlignment.Left);
            cdvScreenGrp.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvScreenGrp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvScreenGrp.GetListView, '1', MPGC.MP_SCREEN_GRP);
        }

        private void cdvScreenGrp_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvScreenID.Text = "";
            txtScreenDesc.Text = "";
        }
        
        private void cdvScreenID_ButtonPress(object sender, EventArgs e)
        {
            cdvScreenID.Init();
            MPCF.InitListView(cdvScreenID.GetListView);
            cdvScreenID.Columns.Add("Screen ID", 150, HorizontalAlignment.Left);
            cdvScreenID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvScreenID.SelectedSubItemIndex = 0;
            BASLIST.ViewScreenList(cdvScreenID.GetListView, '1', cdvScreenGrp.Text, MPGV.gsFactory, null, "", false);          
        }

        private void cdvScreenID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            txtScreenDesc.Text = cdvScreenID.SelectedItem.SubItems[1].Text;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }

            if (UpdateRelation(MPGC.MP_STEP_CREATE) == false) return;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }

            if (UpdateRelation(MPGC.MP_STEP_UPDATE) == false) return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }

            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (UpdateRelation(MPGC.MP_STEP_DELETE) == false) return;
        }

        private void tvMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewSetDataList(tvMFO);
        }

        private void tvMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewScreenList();
        }

        private void cdvField_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                if (cboCondition.Text != "")
                {
                    cdvField.Init();
                    MPCF.InitListView(cdvField.GetListView);

                    switch (cboCondition.SelectedIndex)
                    {
                        case 0: // LOT STATUS
                            cdvField.SelectedSubItemIndex = 0;
                            cdvField.DisplaySubItemIndex = 0;
                            ViewStatusColumnList(cdvField.GetListView, "MWIPLOTSTS");
                            break;

                        case 1: // LOT ATTRIBUTE
                            cdvField.Columns.Add("Seq", 50, HorizontalAlignment.Left);
                            cdvField.Columns.Add("Name", 100, HorizontalAlignment.Left);
                            cdvField.SelectedSubItemIndex = 1;
                            cdvField.DisplaySubItemIndex = 1;

                            BASLIST.ViewAttributeNameList(cdvField.GetListView, '1', MPGC.MP_ATTR_TYPE_LOT);
                            break;

                        case 2: // SUBLOT STATUS
                            cdvField.SelectedSubItemIndex = 0;
                            cdvField.DisplaySubItemIndex = 0;
                            ViewStatusColumnList(cdvField.GetListView, "MWIPSLTSTS");
                            break;

                        case 3: // SUBLOT ATTRIBUTE
                            cdvField.Columns.Add("Seq", 50, HorizontalAlignment.Left);
                            cdvField.Columns.Add("Name", 100, HorizontalAlignment.Left);
                            cdvField.SelectedSubItemIndex = 1;
                            cdvField.DisplaySubItemIndex = 1;

                            BASLIST.ViewAttributeNameList(cdvField.GetListView, '1', MPGC.MP_ATTR_TYPE_SUBLOT);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvField_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cboCondition.SelectedIndex < 4) // General Condition
            {
                MakeCond1Text();
            }
        }

        private void cdvValue1_ButtonPress(object sender, EventArgs e)
        {
            cdvValue1.Init();
            MPCF.InitListView(cdvValue1.GetListView);
            cdvValue1.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
            cdvValue1.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvValue1.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMTableList(cdvValue1.GetListView, '1');
        }

        private void cdvValue1_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            txtCond2.Text = "select %COLUMN% from MGCMTBLDAT where factory = $FACTORY and table_name = '" + cdvValue1.Text + "'";
            txtCond2.Tag = txtCond2.Text;

            cdvValue2.Text = "";
        }

        private void cdvValue2_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvValue1, 1) == false) return;

            cdvValue2.Init();
            cdvValue2.SelectedSubItemIndex = 0;

            ViewGCMKeyList(cdvValue2.GetListView, MPCF.Trim(cdvValue1.Text));
        }

        private void cdvValue2_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.CheckValue(cdvValue1, 1) == false) return;
            txtCond2.Text = txtCond2.Tag.ToString().Replace("%COLUMN%", cdvValue2.Text);

            ChangeSQLSyntaxColor();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CONFIRM) == false) return;

            grpConditionList.Tag = spdCond.ActiveSheet.RowCount;
            spdCond.ActiveSheet.RowCount++;

            btnModify.PerformClick();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CONFIRM) == false) return;

            int i_row;

            if (MPCF.Trim(grpConditionList.Tag) != "")
            {
                i_row = MPCF.ToInt(grpConditionList.Tag);

                spdCond.ActiveSheet.Cells[i_row, 2].Value = cboCondition.Text;
                spdCond.ActiveSheet.Cells[i_row, 3].Value = cdvField.Text;
                spdCond.ActiveSheet.Cells[i_row, 4].Value = cboOperator.Text;
                spdCond.ActiveSheet.Cells[i_row, 5].Value = cboValueType.Text;

                spdCond.ActiveSheet.Cells[i_row, 6].Value = "";
                spdCond.ActiveSheet.Cells[i_row, 7].Value = "";

                if (cboValueType.SelectedIndex == 0 || cboValueType.SelectedIndex == 1)
                {
                    spdCond.ActiveSheet.Cells[i_row, 6].Value = cdvValue1.Text;
                }
                if (cboValueType.SelectedIndex == 1)
                {
                    spdCond.ActiveSheet.Cells[i_row, 7].Value = cdvValue2.Text;
                }
                if (cboValueType.SelectedIndex == 2)
                {
                    spdCond.ActiveSheet.Cells[i_row, 6].Value = txtCond2.Text;
                }

                //default as AND
                if (i_row > 0 && MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 0].Value) == "")
                {
                    spdCond.ActiveSheet.Cells[i_row, 0].Value = "AND";
                }

                MakeRelationCondition();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int i_row;

            if (MPCF.Trim(grpConditionList.Tag) != "")
            {
                i_row = MPCF.ToInt(grpConditionList.Tag);

                spdCond.ActiveSheet.Rows[i_row].Remove();

                cboCondition.Text = "";
                cdvField.Text = "";
                cboOperator.Text = "";

                cboValueType.Text = "";
                cdvValue1.Text = "";
                cdvValue2.Text = "";

                txtCond1.Text = "(";
                txtCond2.Text = "";

                MakeRelationCondition();

                if (i_row >= spdCond.ActiveSheet.RowCount)
                {
                    i_row--;
                }

                if (i_row < 0)
                {
                    grpConditionList.Tag = null;
                }
                else
                {
                    spdCondCellClick(i_row);
                }
            }
        }

        private void rbtResource_CheckedChanged(object sender, EventArgs e)
        {
            MPCF.ClearList(lisScreen);
            MPCF.FieldClear(pnlRight);

            if (rbtFactory.Checked == true)
            {
                m_opt_level = 'F';

                InitResourceTree();
                ViewScreenList();
                return;
            }

            if (((RadioButton)sender).Checked == true)
                chkOnlySettingData_CheckedChanged(null, null);
        }

        private void chkOnlySettingData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnlySettingData.Checked == true)
            {
                lisResList.Visible = true;
                tvResList.Visible = false;

                ViewSetDataList(lisResList);
            }
            else
            {
                lisResList.Visible = false;
                tvResList.Visible = true;

                InitResourceTree();
            }
        }

        private void tvResList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            m_res_type = "";
            m_resg_id = "";
            m_res_id = "";
            m_opt_level = ' ';

            if (e.Action == TreeViewAction.Collapse || e.Action == TreeViewAction.Expand || e.Action == TreeViewAction.Unknown) return;

            if (rbtFactory.Checked == true)
            {
                m_opt_level = 'F';
                return;
            }
            else if (rbtResType.Checked == true)
            {
                m_opt_level = 'T';

                m_res_type = MPCF.Trim(e.Node.Text);
                m_res_type = MPCF.SubtractString(m_res_type, ":", false, false);
            }
            else if (rbtResGroup.Checked == true)
            {
                m_opt_level = 'G';

                m_resg_id = MPCF.Trim(e.Node.Text);
                m_resg_id = MPCF.SubtractString(m_resg_id, ":", false, false);
            }
            else if (rbtResource.Checked == true)
            {
                m_opt_level = 'R';
                m_res_id = MPCF.Trim(e.Node.Text);
                m_res_id = MPCF.SubtractString(m_res_id, ":", false, false);
            }

            ViewScreenList();
        }

        private void tabSelectLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSelectLevel.SelectedTab == tbpResource && rbtFactory.Checked == true)
            {
                m_opt_level = 'F';

                ViewScreenList();
            }
            else
                MPCF.ClearList(lisScreen);
        }

        private void lisScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (((ListView)sender).SelectedItems.Count > 0)
                {
                    m_selected_relation_key = ((ListView)sender).SelectedItems[0].SubItems[0].Tag.ToString();
                    if (ViewInquiryScreenRelation() == false) return;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tvResList_Click(object sender, EventArgs e)
        {
            tvResList.SelectedNode = null;
        }

        private void cboValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblValue1.Visible = false;
            lblValue2.Visible = false;
            txtFVUsage.Visible = false;

            cdvValue1.Text = "";
            cdvValue1.VisibleButton = false;
            cdvValue1.Visible = false;
            cdvValue1.ReadOnly = true;

            cdvValue2.Text = "";
            cdvValue2.VisibleButton = false;
            cdvValue2.Visible = false;
            cdvValue2.ReadOnly = true;

            txtCond2.Text = "";
            txtCond2.ReadOnly = true;


            switch (cboValueType.SelectedIndex)
            {
                case 0: // FIXED VALUE
                    lblValue1.Text = "Value";
                    lblValue1.Visible = true;
                    txtFVUsage.Visible = true;
                    cdvValue1.Visible = true;
                    cdvValue1.ReadOnly = false;
                    break;
                case 1: // GCM TABLE
                    lblValue1.Text = "Table Name";
                    lblValue1.Visible = true;
                    lblValue2.Visible = true;

                    cdvValue1.VisibleButton = true;
                    cdvValue1.Visible = true;
                    cdvValue2.VisibleButton = true;
                    cdvValue2.Visible = true;
                    break;
                case 2: // USER SQL
                    txtCond2.ReadOnly = false;
                    break;
            }
        }

        private void cboValueType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboValueType_TextChanged(object sender, EventArgs e)
        {
            if (cboValueType.Text == "")
            {
                cboValueType.SelectedIndex = -1;
                cboValueType_SelectedIndexChanged(null, null);
            }
        }

        private void spdCond_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == true) return;
            if (e.RowHeader == true) return;

            spdCondCellClick(e.Row);
        }

        private void cdvValue1_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (cboValueType.SelectedIndex == 0)
            {
                txtCond2.Text = cdvValue1.Text;
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (tabSelectLevel.SelectedTab == tbpMFO)
                tvMFO.RefreshSelectedList();
            else
            {
                tvResList.Refresh();
                lisResList.Refresh();
            }
        }

        private void tvMFO_LevelItemSelect(object sender, TreeViewEventArgs e)
        {
            ViewScreenList();
        }

        private void lisResList_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_res_type = "";
            m_resg_id = "";
            m_res_id = "";
            m_opt_level = ' ';

            try
            {
                if (lisResList.SelectedItems.Count < 1) return;

                if (rbtFactory.Checked == true)
                {
                    m_opt_level = 'F';
                }
                else if (rbtResType.Checked == true)
                {
                    m_opt_level = 'T';

                    m_res_type = MPCF.Trim(lisResList.SelectedItems[0].SubItems[0].Text);
                }
                else if (rbtResGroup.Checked == true)
                {
                    m_opt_level = 'G';

                    m_resg_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[0].Text);
                }
                else
                {
                    m_opt_level = 'R';

                    m_res_id = MPCF.Trim(lisResList.SelectedItems[0].SubItems[0].Text);
                }

                ViewScreenList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tvMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.GetTreeView.GetNodeCount(false));
        }

    }
}
