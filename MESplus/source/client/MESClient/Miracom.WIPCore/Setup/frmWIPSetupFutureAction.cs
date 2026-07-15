//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupFutureAction.cs
//   Description : Future Action setup
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - SetUpdateItem() : 각 Transaction 별 Lot Code를 가져오고 화면을 구성함.
//       - ViewFutureActionList() : MFO의 Lot type, Lot ID의 설정 리스트를 가져옴.
//       - ViewFutureAction() : MFO, lot_type, lot_id의 설정값을 가져옴.
//       - UpdateFutureAction() : MFO, lot_type, lot_id의 설정값을 저장함.
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2007-08-27 : Created by Aiden
//
//
//   Copyright(C) 1998-2007 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.WIPCore.Setup;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupFutureAction : Miracom.MESCore.SetupForm02
    {
        public frmWIPSetupFutureAction()
        {
            InitializeComponent();
        }

#region " Constant Definition "
        private const string COND_TYPE_LOT_STATUS = "Lot Status";
        private const string COND_TYPE_LOT_ATTR = "Lot Attribute";
        private const string COND_TYPE_SUBLOT_STATUS = "Sublot Status";
        private const string COND_TYPE_SUBLOT_ATTR = "Sublot Attribute";
        private const string COND_TYPE_CUST_COND = "Custom Condition";

        private const string VALUE_TYPE_FIXED_VALUE = "Fixed Value";
        private const string VALUE_TYPE_GCM_TABLE = "GCM Table";
        private const string VALUE_TYPE_USER_SQL = "User SQL";
#endregion

#region " Variable Definition "
        private string[] S_OPER_IN_OUT_SERVICES = new string[] 
        {   
            "WIP_Adapt_Lot",
            "WIP_End_Lot", 
            "WIP_Move_Lot", 
            "WIP_Skip_Lot", 
            "WIP_Rework_Lot",
            "WIP_Repair_Lot", 
            "WIP_Repair_End_Lot", 
            "WIP_Store_Lot", 
            "WIP_Unstore_Lot",
            "WIP_Receive_Lot"
        };

        private struct ST_ACTION_TAG
        {
            public char oper_point;
            public char ba_point;
            public string tran_code;
            public string tran_comment;
            public string point_key;
            public string action_key;
            public string dependent_key;
            public string dependent_tran_code;
            public string dependent_tran_comment;
        }

        private TRSNode m_future_action_out;
        private intFutureActionControl m_int_action;
        private ST_ACTION_TAG m_selected_action;
        private bool m_b_proc_view_action_detail;

        private bool bLoadFlag;
#endregion

#region " Function Definition "

        //
        // SetTransactionValue()
        //       -
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sTranCode As String : Tran Code
        private bool SetTransactionValue(string s_tran_code)
        {
            udcFutureActionBase ctl_action;
            try
            {
                pnlActionValue.Controls.Clear();
                ctl_action = null;
                m_int_action = null;
                
                switch (s_tran_code)
                {
                    case MPGC.MP_TRAN_CODE_HOLD:
                        ctl_action = new udcFutureActionHold();
                        break;

                    case MPGC.MP_TRAN_CODE_RELEASE:
                        break;


                    case MPGC.MP_TRAN_CODE_END:
                        ctl_action = new udcFutureActionEnd();
                        break;

                    case MPGC.MP_TRAN_CODE_SKIP:
                        ctl_action = new udcFutureActionSkip();
                        break;

                    case MPGC.MP_TRAN_CODE_MOVE:
                        ctl_action = new udcFutureActionMove();
                        break;

                    case MPGC.MP_TRAN_CODE_TERMINATE:
                        ctl_action = new udcFutureActionTerminate();
                        break;

                    case MPGC.MP_TRAN_CODE_REWORK:
                        ctl_action = new udcFutureActionRework();
                        break;

                    case MPGC.MP_TRAN_CODE_ADAPT:
                        ctl_action = new udcFutureActionAdapt();
                        break;

                    case "RAISE ALARM":
                        ctl_action = new udcFutureActionRaiseAlarm();
                        break;

                    case "INPUT ATTRIBUTE":
                        ctl_action = new udcFutureActionInputAttribute();
                        break;
                    
                    case "CUSTOM ACTION":
                        ctl_action = new udcFutureActionCustom();
                        break;

                    case "ERROR ACTION":
                        ctl_action = new udcFutureActionError();
                        break;

                    case MPGC.MP_TRAN_CODE_STORE:
                        ctl_action = new udcFutureActionStore();
                        break;

                    default:
                        return false;

                }

                if (ctl_action != null)
                {
                    MPCF.ConvertMessage(ctl_action.Controls);
                    ctl_action.Dock = DockStyle.Fill;

                    m_int_action = ctl_action;
                    m_int_action.setMFO(tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.Oper);
                    m_int_action.setMFOSelectLevel(tvMFO.SelectLevel);

                    {
                        char c_oper_point = ' ';
                        char c_ba_point = ' ';
                        char c_skip_originated_service = ' ';

                        if (rbtOperIn.Checked == true) c_oper_point = 'I';
                        else if (rbtOperAt.Checked == true) c_oper_point = 'A';
                        else if (rbtOperOut.Checked == true) c_oper_point = 'O';

                        if (rbtBefore.Checked == true) c_ba_point = 'B';
                        else if (rbtAfter.Checked == true) c_ba_point = 'A';

                        if (chkSkipService.Checked == true) c_skip_originated_service = 'Y';

                        m_int_action.setPoint(c_oper_point, c_ba_point, c_skip_originated_service);
                    }

                    if (m_b_proc_view_action_detail == true)
                    {
                        m_int_action.setAction(m_future_action_out);
                    }

                    pnlActionValue.Controls.Add(ctl_action);
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
        // InitActionTree()
        //       - Initial Action Tree Control
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        private void InitActionTree(TreeView tvAction)
        {
            TreeNode node;

            MPCF.InitTreeView(tvAction);

            node = new TreeNode("Oper In  ", (int)SMALLICON_INDEX.IDX_VERSION, (int)SMALLICON_INDEX.IDX_VERSION);
            node.NodeFont = new Font(tvAction.Font, FontStyle.Bold);
            node.Tag = "I";
            tvAction.Nodes.Add(node);
            node = new TreeNode("Oper At, Before     ", (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL, (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
            node.NodeFont = new Font(tvAction.Font, FontStyle.Bold);
            node.Tag = "AB";
            tvAction.Nodes.Add(node);
            node = new TreeNode("Oper At, After     ", (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL, (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL);
            node.NodeFont = new Font(tvAction.Font, FontStyle.Bold);
            node.Tag = "AA";
            tvAction.Nodes.Add(node);
            node = new TreeNode("Oper Out, Before     ", (int)SMALLICON_INDEX.IDX_VERSION_REQUEST, (int)SMALLICON_INDEX.IDX_VERSION_REQUEST);
            node.NodeFont = new Font(tvAction.Font, FontStyle.Bold);
            node.Tag = "OB";
            tvAction.Nodes.Add(node);
            node = new TreeNode("Oper Out, After     ", (int)SMALLICON_INDEX.IDX_VERSION_REQUEST, (int)SMALLICON_INDEX.IDX_VERSION_REQUEST);
            node.NodeFont = new Font(tvAction.Font, FontStyle.Bold);
            node.Tag = "OA";
            tvAction.Nodes.Add(node);
        }

        //
        // FindActionNode()
        //       - Find Action Tree Node
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        private TreeNode FindActionNode(TreeView tree, string s_tag)
        {
            TreeNode ret_node;

            try
            {
                if (tree == null) return null;
                if (tree.Nodes == null) return null;
                if (tree.Nodes.Count < 1) return null;

                foreach (TreeNode xnode in tree.Nodes)
                {
                    ret_node = FindActionNode(xnode, s_tag);
                    if (ret_node != null) return ret_node;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return null;
        }

        //
        // FindActionNode()
        //       - Find Action Tree Node
        // Return Value
        //       - 
        // Arguments
        //       - 
        //
        private TreeNode FindActionNode(TreeNode node, string s_tag)
        {
            TreeNode ret_node;
            ST_ACTION_TAG st_action;

            try
            {
                if (node == null) return null;

                foreach (TreeNode TNode in node.Nodes)
                {
                    st_action = (ST_ACTION_TAG)TNode.Tag;
                    if (st_action.action_key == s_tag)
                    {
                        return TNode;
                    }

                    ret_node = FindActionNode(TNode, s_tag);
                    if (ret_node != null) return ret_node;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return null;
        }

        //
        // ViewFutureActionList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewFutureActionList()
        {
            TRSNode in_node = new TRSNode("VIEW_FUTURE_ACTION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FUTURE_ACTION_LIST_OUT");
            List<TRSNode> action_list;
            int i;
            string s_label;
            ST_ACTION_TAG st_action;
            TreeNode parent_node;
            TreeNode node;

            m_selected_action.point_key = "";
            m_selected_action.action_key = "";
            m_selected_action.dependent_key = "";

            InitActionTree(tvAction);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddChar("OPT_LEVEL", tvMFO.SelectLevelChar);
            in_node.AddString("MAT_ID", tvMFO.MatID);
            in_node.AddInt("MAT_VER", tvMFO.MatVersion);
            in_node.AddString("FLOW", tvMFO.Flow);
            in_node.AddString("OPER", tvMFO.Oper);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Future_Action_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                action_list = out_node.GetList("ACTION_LIST");
                for (i = 0; i < action_list.Count; i++)
                {
                    s_label = "";
                    parent_node = null;
                    st_action = new ST_ACTION_TAG();

                    st_action.oper_point = action_list[i].GetChar("OPER_POINT");
                    st_action.ba_point = action_list[i].GetChar("BA_POINT");
                    st_action.tran_code = action_list[i].GetString("TRAN_CODE");
                    st_action.tran_comment = action_list[i].GetString("TRAN_COMMENT");
                    st_action.point_key = action_list[i].GetString("POINT_KEY");
                    st_action.action_key = action_list[i].GetString("ACTION_KEY");
                    st_action.dependent_key = action_list[i].GetString("DEPENDENT_ACTION_KEY");
                    st_action.dependent_tran_code = action_list[i].GetString("DEPENDENT_TRAN_CODE");
                    st_action.dependent_tran_comment = action_list[i].GetString("DEPENDENT_TRAN_COMMENT");

                    if (st_action.oper_point == 'I')
                    {
                        parent_node = tvAction.Nodes[0];
                    }
                    else if (st_action.oper_point == 'A' && st_action.ba_point == 'B')
                    {
                        parent_node = tvAction.Nodes[1];
                    }
                    else if (st_action.oper_point == 'A' && st_action.ba_point == 'A')
                    {
                        parent_node = tvAction.Nodes[2];
                    }
                    else if (st_action.oper_point == 'O' && st_action.ba_point == 'B')
                    {
                        parent_node = tvAction.Nodes[3];
                    }
                    else if (st_action.oper_point == 'O' && st_action.ba_point == 'A')
                    {
                        parent_node = tvAction.Nodes[4];
                    }

                    s_label = st_action.tran_code;
                    s_label += " : " + st_action.tran_comment;
                    s_label += "  (" + action_list[i].GetString("CREATE_USER_ID");
                    s_label += ", " + MPCF.MakeDateFormat(action_list[i].GetString("CREATE_TIME"));
                    s_label += ", " + action_list[i].GetString("UPDATE_USER_ID");
                    s_label += ", " + MPCF.MakeDateFormat(action_list[i].GetString("UPDATE_TIME"));
                    s_label += ")";

                    node = new TreeNode(s_label, (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE, (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE);
                    node.Tag = st_action;

                    if (st_action.dependent_key != "")
                    {
                        parent_node = FindActionNode(parent_node, st_action.dependent_key);
                    }

                    if (parent_node != null)
                    {
                        parent_node.Nodes.Add(node);
                    }
                }

                in_node.SetString("NEXT_POINT_KEY", out_node.GetString("NEXT_POINT_KEY"));
                in_node.SetString("NEXT_ACTION_KEY", out_node.GetString("NEXT_ACTION_KEY"));

            } while (in_node.GetString("NEXT_POINT_KEY") != "" || in_node.GetString("NEXT_ACTION_KEY") != "");

            //foreach (TreeNode TNode in tvAction.Nodes)
            //{
            //    TNode.ExpandAll();
            //}

            m_future_action_out = null;
            if (m_int_action != null)
            {
                m_int_action.setMFO(tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.Oper);
            }

            return true;
        }

        //
        // ViewFutureActionListByPoint()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewFutureActionListByPoint(ListView lisAction, string s_point_key)
        {
            TRSNode in_node = new TRSNode("VIEW_FUTURE_ACTION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FUTURE_ACTION_LIST_OUT");
            List<TRSNode> action_list;
            ListViewItem itm;
            int i;

            MPCF.InitListView(lisAction);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';

            in_node.AddString("POINT_KEY", s_point_key);

            if (rbtOperIn.Checked == true)
                in_node.AddChar("OPER_POINT", 'I');
            else if (rbtOperAt.Checked == true)
                in_node.AddChar("OPER_POINT", 'A');
            else if (rbtOperOut.Checked == true)
                in_node.AddChar("OPER_POINT", 'O');

            if (rbtBefore.Checked == true)
                in_node.AddChar("BA_POINT", 'B');
            else if (rbtAfter.Checked == true)
                in_node.AddChar("BA_POINT", 'A');

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Future_Action_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                action_list = out_node.GetList("ACTION_LIST");
                for (i = 0; i < action_list.Count; i++)
                {
                    itm = new ListViewItem(action_list[i].GetString("TRAN_CODE"), (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE);
                    itm.SubItems.Add(action_list[i].GetString("TRAN_COMMENT"));
                    itm.SubItems.Add(action_list[i].GetString("ACTION_KEY"));

                    lisAction.Items.Add(itm);
                }

                in_node.SetString("NEXT_POINT_KEY", out_node.GetString("NEXT_POINT_KEY"));
                in_node.SetString("NEXT_ACTION_KEY", out_node.GetString("NEXT_ACTION_KEY"));

            } while (in_node.GetString("NEXT_POINT_KEY") != "" || in_node.GetString("NEXT_ACTION_KEY") != "");

            return true;
        }

        //
        // ViewFutureAction()
        //       - Get Future Action List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public bool ViewFutureAction()
        {
            TRSNode in_node = new TRSNode("VIEW_FUTURE_ACTION_IN");
            List<TRSNode> list_node;
            int i;
            int i1;
            string s_tmp;

            for (i = 0; i < lisServices.Items.Count; i++)
            {
                if (lisServices.Items[i].Checked == true)
                {
                    lisServices.Items[i].Checked = false;
                }
            }
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

            in_node.AddString("POINT_KEY", m_selected_action.point_key);
            in_node.AddString("ACTION_KEY", m_selected_action.action_key);

            if (m_future_action_out == null)
            {
                m_future_action_out = new TRSNode("VIEW_FUTURE_ACTION_OUT");
            }
            else
            {
                m_future_action_out.Init();
            }

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Future_Action", in_node, ref m_future_action_out) == false)
                {
                    return false;
                }

                list_node = m_future_action_out.GetList("SERVICE_LIST");
                for (i = 0; i < list_node.Count; i++)
                {
                    s_tmp = list_node[i].GetString("SERVICE_NAME");

                    for (i1 = 0; i1 < lisServices.Items.Count; i1++)
                    {
                        if (s_tmp == lisServices.Items[i1].SubItems[1].Text)
                        {
                            lisServices.Items[i1].Checked = true;
                            break;
                        }
                    }

                    if (rbtOperAt.Checked == true && i1 >= lisServices.Items.Count)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(303) + " [" + s_tmp + "]");
                    }
                }

                list_node = m_future_action_out.GetList("CONDITION_LIST");
                for (i = 0; i < list_node.Count; i++)
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
                    else if (s_tmp == "SS")
                        s_tmp = COND_TYPE_SUBLOT_STATUS;
                    else if (s_tmp == "SA")
                        s_tmp = COND_TYPE_SUBLOT_ATTR;
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

                in_node.SetString("NEXT_SERVICE_NAME", m_future_action_out.GetString("NEXT_SERVICE_NAME"));
                in_node.SetInt("NEXT_COND_SEQ", m_future_action_out.GetInt("NEXT_COND_SEQ"));

            } while (in_node.GetString("NEXT_SERVICE_NAME") != "" || in_node.GetInt("NEXT_COND_SEQ") > 0);

            if (m_int_action != null)
            {
                m_int_action.setAction(m_future_action_out);
            }

            MakeRelationCondition();

            return true;
        }

        // ViewFutureActionFillCMF()
        //       - Get Future Action List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public void ViewFutureActionFillCMF()
        {
            if (m_future_action_out != null)
            {
                chkSkipService.Checked = (m_future_action_out.GetChar("SKIP_SERVICE") == 'Y' ? true : false);

                cdvCMF1.Text = MPCF.Trim(m_future_action_out.GetString("CMF_1"));
                cdvCMF2.Text = MPCF.Trim(m_future_action_out.GetString("CMF_2"));
                cdvCMF3.Text = MPCF.Trim(m_future_action_out.GetString("CMF_3"));
                cdvCMF4.Text = MPCF.Trim(m_future_action_out.GetString("CMF_4"));
                cdvCMF5.Text = MPCF.Trim(m_future_action_out.GetString("CMF_5"));
                cdvCMF6.Text = MPCF.Trim(m_future_action_out.GetString("CMF_6"));
                cdvCMF7.Text = MPCF.Trim(m_future_action_out.GetString("CMF_7"));
                cdvCMF8.Text = MPCF.Trim(m_future_action_out.GetString("CMF_8"));
                cdvCMF9.Text = MPCF.Trim(m_future_action_out.GetString("CMF_9"));
                cdvCMF10.Text = MPCF.Trim(m_future_action_out.GetString("CMF_10"));
                cdvCMF11.Text = MPCF.Trim(m_future_action_out.GetString("CMF_11"));
                cdvCMF12.Text = MPCF.Trim(m_future_action_out.GetString("CMF_12"));
                cdvCMF13.Text = MPCF.Trim(m_future_action_out.GetString("CMF_13"));
                cdvCMF14.Text = MPCF.Trim(m_future_action_out.GetString("CMF_14"));
                cdvCMF15.Text = MPCF.Trim(m_future_action_out.GetString("CMF_15"));
                cdvCMF16.Text = MPCF.Trim(m_future_action_out.GetString("CMF_16"));
                cdvCMF17.Text = MPCF.Trim(m_future_action_out.GetString("CMF_17"));
                cdvCMF18.Text = MPCF.Trim(m_future_action_out.GetString("CMF_18"));
                cdvCMF19.Text = MPCF.Trim(m_future_action_out.GetString("CMF_19"));
                cdvCMF20.Text = MPCF.Trim(m_future_action_out.GetString("CMF_20"));
            }
        }

        
        //To List all Column names from the table
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

        private void MakeCond1Text()
        {
            string s_cond;

            s_cond = "";

            if(cboCondition.Text != "" )
            {
                if (cboCondition.SelectedIndex < 4) // General Condition
                {
                    switch (cboCondition.SelectedIndex)
                    {
                        case 0: // LOT STATUS
                            s_cond = "select LOT_ID from MWIPLOTSTS where lot_id = $LOT_ID and ";
                            break;

                        case 1: // LOT ATTRIBUTE
                            s_cond = "select ATTR_KEY from MATRNAMSTS where factory = $FACTORY and attr_type = '" + MPGC.MP_ATTR_TYPE_LOT +"' and attr_key = $LOT_ID and attr_name = ";
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

            if(cdvField.Text != "" )
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

            if(cboOperator.Text != "" )
            {
                s_cond += cboOperator.Text + " (";
            }

            txtCond1.Text = s_cond;
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

        private bool CheckCondition(char c_proc_step)
        {
            int i;
            bool b_match;
            int i_l_bracket;
            int i_r_bracket;

            // Check input condition
            if (c_proc_step == MPGC.MP_STEP_CONFIRM)
            {

                tabAction.SelectedTab = tbpCondition;

                //check settings start
                if (cboCondition.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cboCondition.Focus();
                    return false;
                }

                if (cboCondition.SelectedIndex < 4)
                {
                    if (cdvField.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvField.Focus();
                        return false;
                    }
                    if (cboOperator.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cboOperator.Focus();
                        return false;
                    }
                    if (cboValueType.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cboValueType.Focus();
                        return false;
                    }
                    if ((cboValueType.SelectedIndex == 0 || cboValueType.SelectedIndex == 1) && cdvValue1.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvValue1.Focus();
                        return false;
                    }
                    if (cboValueType.SelectedIndex == 1 && cdvValue2.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvValue2.Focus();
                        return false;
                    }
                    //check settings end

                    if (cboValueType.SelectedIndex == 0)
                    {
                        if (cboOperator.SelectedIndex == 6 || cboOperator.SelectedIndex == 7)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(299));
                            return false;
                        }
                    }
                    else if (cboValueType.SelectedIndex == 1)
                    {
                        if (cboOperator.SelectedIndex != 6 && cboOperator.SelectedIndex != 7)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(300));
                            return false;
                        }
                    }
                }

                b_match = true;
                for (i = 0; i < spdCond.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) != cboCondition.Text)
                        b_match = false;

                    if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 3].Value) != cdvField.Text)
                        b_match = false;

                    if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 4].Value) != cboOperator.Text)
                        b_match = false;

                    if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 5].Value) != cboValueType.Text)
                        b_match = false;

                    if (cboValueType.SelectedIndex == 0 || cboValueType.SelectedIndex == 1)
                    {
                        if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 6].Value) != cdvValue1.Text)
                            b_match = false;
                    }
                    else if (cboValueType.SelectedIndex == 2)
                    {
                        if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 6].Value) != txtCond2.Text)
                            b_match = false;
                    }

                    if (cboValueType.SelectedIndex == 1)
                    {
                        if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 7].Value) != cdvValue2.Text)
                            b_match = false;
                    }

                    if (b_match == true)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(301));
                        return false;
                    }

                    b_match = true;
                }
            }

            // Check Create/Update/Delete Condition
            else
            {
                if (tvMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Oper)
                {
                    tabAction.SelectedTab = tbpGeneral;
                    MPCF.ShowMsgBox(MPCF.GetMessage(184));
                    tvMFO.Focus();
                    return false;
                }

                // Check Update/Delete Condition
                if (c_proc_step == MPGC.MP_STEP_UPDATE || c_proc_step == MPGC.MP_STEP_DELETE)
                {
                    if (m_selected_action.action_key == "")
                    {
                        tabAction.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        tvAction.Focus();
                        return false;
                    }
                }
                
                // Check Create/Update Condition
                if (c_proc_step == MPGC.MP_STEP_CREATE || c_proc_step == MPGC.MP_STEP_UPDATE)
                {
                    if (rbtOperIn.Checked == true && rbtOperAt.Checked == true && rbtOperOut.Checked == true)
                    {
                        tabAction.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        rbtOperIn.Focus();
                        return false;
                    }

                    if (lisServices.CheckedItems.Count < 1)
                    {
                        tabAction.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        lisServices.Focus();
                        return false;
                    }

                    if (cboTransaction.SelectedIndex < 0)
                    {
                        tabAction.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        cboTransaction.Focus();
                        return false;
                    }

                    i_l_bracket = 0;
                    i_r_bracket = 0;

                    for (i = 0; i < txtRelation.Text.Length; i++)
                    {
                        if (txtRelation.Text[i] == '(')
                        {
                            i_l_bracket++;
                        }
                        else if (txtRelation.Text[i] == ')')
                        {
                            i_r_bracket++;
                        }
                    }

                    if (i_l_bracket != i_r_bracket)
                    {
                        tabAction.SelectedTab = tbpCondition;
                        MPCF.ShowMsgBox(MPCF.GetMessage(302));
                        spdCond.Focus();
                        return false;
                    }
                }

            }
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


        //
        // UpdateFutureAction()
        //       - Update Future Action
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool UpdateFutureAction(char c_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_FUTURE_ACTION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;
            int i;
            int i_tmp;
            string s_tmp;
            bool b_confirm_process;

            if (CheckCondition(c_step) == false)
            {
                return false;
            }

            b_confirm_process = true;


        SAVE_DATA:
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (b_confirm_process == true)
            {
                in_node.AddChar("CONFIRM_FLAG", 'Y');
            }

            in_node.AddChar("OPT_LEVEL", tvMFO.SelectLevelChar);
            in_node.AddString("MAT_ID", tvMFO.MatID);
            in_node.AddInt("MAT_VER", tvMFO.MatVersion);
            in_node.AddString("FLOW", tvMFO.Flow);
            in_node.AddString("OPER", tvMFO.Oper);

            if (rbtOperIn.Checked == true)
                in_node.AddChar("OPER_POINT", 'I');
            else if (rbtOperAt.Checked == true)
                in_node.AddChar("OPER_POINT", 'A');
            else if (rbtOperOut.Checked == true)
                in_node.AddChar("OPER_POINT", 'O');

            if (rbtBefore.Checked == true)
                in_node.AddChar("BA_POINT", 'B');
            else if (rbtAfter.Checked == true)
                in_node.AddChar("BA_POINT", 'A');

            if (c_step == MPGC.MP_STEP_UPDATE || c_step == MPGC.MP_STEP_DELETE)
            {
                in_node.AddString("POINT_KEY", m_selected_action.point_key);
                in_node.AddString("ACTION_KEY", m_selected_action.action_key);
            }

            if (c_step == MPGC.MP_STEP_CREATE || c_step == MPGC.MP_STEP_UPDATE)
            {
                if (chkSkipService.Checked == true)
                {
                    in_node.AddChar("SKIP_SERVICE", 'Y');
                }

                if (MPCF.Trim(cdvDependentAction.Text) != "")
                {
                    in_node.AddString("DEPENDENT_ACTION_KEY", MPCF.Trim(cdvDependentAction.Tag));
                }

                if (m_int_action.checkCondition() == false)
                {
                    tabAction.SelectedTab = tbpGeneral;
                    return false;
                }
                
                m_int_action.getAction(in_node);
                
                if (in_node.GetString("TRAN_CODE") == MPGC.MP_TRAN_CODE_REWORK)
                {
                    if ((MPCF.Trim(in_node.GetString("DATA_2")) == "" && MPCF.Trim(in_node.GetString("DATA_4")) != "") ||
                        (MPCF.Trim(in_node.GetString("DATA_5")) == "" && MPCF.Trim(in_node.GetString("DATA_7")) != "") ||
                        (MPCF.Trim(in_node.GetString("DATA_12")) == "" && MPCF.Trim(in_node.GetString("DATA_14")) != "") ||
                        (MPCF.Trim(in_node.GetString("DATA_15")) == "" && MPCF.Trim(in_node.GetString("DATA_17")) != ""))
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(309), MessageBoxButtons.YesNo, 2) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }

                if (in_node.GetMember("ACTION_TYPE") == null)
                {
                    in_node.AddChar("ACTION_TYPE", '1');
                }

                in_node.AddString("CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("CMF_20", MPCF.Trim(cdvCMF20.Text));
                in_node.AddString("TRAN_COMMENT", MPCF.Trim(txtComment.Text));

                for (i = 0; i < lisServices.CheckedItems.Count; i++)
                {
                    list_item = in_node.AddNode("SERVICE_LIST");
                    list_item.AddString("SERVICE_NAME", lisServices.CheckedItems[i].SubItems[1].Text);
                }

                for (i = 0; i < spdCond.ActiveSheet.RowCount; i++)
                {
                    list_item = in_node.AddNode("CONDITION_LIST");
                    list_item.AddString("AND_OR", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 0].Value));
                    list_item.AddString("L_BRACKET", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 1].Value));

                    s_tmp = "";
                    if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_LOT_STATUS)
                        s_tmp = "LS";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_LOT_ATTR)
                        s_tmp = "LA";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_SUBLOT_STATUS)
                        s_tmp = "SS";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_SUBLOT_ATTR)
                        s_tmp = "SA";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_CUST_COND)
                        s_tmp = "CC";

                    list_item.AddString("COND_TYPE", s_tmp);

                    list_item.AddString("FIELD_NAME", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 3].Value));
                    list_item.AddString("OPERATOR", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 4].Value));

                    s_tmp = "";
                    if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 5].Value) == VALUE_TYPE_FIXED_VALUE)
                        s_tmp = "FV";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 5].Value) == VALUE_TYPE_GCM_TABLE)
                        s_tmp = "GT";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 5].Value) == VALUE_TYPE_USER_SQL)
                        s_tmp = "US";

                    list_item.AddString("VALUE_TYPE", s_tmp);

                    i_tmp = MPCF.ByteLen(spdCond.ActiveSheet.Cells[i, 6].Value);
                    if (i_tmp > 4000)
                    {
                        s_tmp = MPCF.ByteMid(spdCond.ActiveSheet.Cells[i, 6].Value, 0, 4000);
                        list_item.AddString("VALUE_1", s_tmp);

                        s_tmp = MPCF.ByteMid(spdCond.ActiveSheet.Cells[i, 6].Value, 4000, i_tmp - 4000);
                        list_item.AddString("VALUE_2", s_tmp);
                    }
                    else
                    {
                        list_item.AddString("VALUE_1", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 6].Value));
                        list_item.AddString("VALUE_2", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 7].Value));
                    }
                    list_item.AddString("R_BRACKET", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 8].Value));
                }
            }

            if (MPCR.CallService("WIP", "WIP_Update_Future_Action", in_node, ref out_node) == false)
            {
                if (b_confirm_process == true && out_node.GetList("CONFLICT").Count > 0)
                {
                    frmWIPSetupFutureActionSub01 frmConfirm = new frmWIPSetupFutureActionSub01();
                    
                    frmConfirm.setCurrentValue(in_node.GetString("TRAN_CODE"), in_node.GetChar("ACTION_TYPE"), this.spdCond, this.txtRelation.Text);
                    frmConfirm.setConflictValue(out_node.GetList("CONFLICT")[0]);

                    if (frmConfirm.ShowDialog(this) == DialogResult.OK)
                    {
                        in_node.Init();
                        out_node.Init();

                        b_confirm_process = false;
                        goto SAVE_DATA;
                    }
                }

                return false;
            }

            if (b_confirm_process == true)
            {
                in_node.Init();
                out_node.Init();

                b_confirm_process = false;
                goto SAVE_DATA;
            }

            MPCR.ShowSuccessMsg(out_node);

            ViewFutureActionList();

            if (c_step == MPGC.MP_STEP_CREATE || c_step == MPGC.MP_STEP_UPDATE)
            {
                TreeNode xnode;

                xnode = FindActionNode(tvAction, out_node.GetString("ACTION_KEY"));
                if (xnode != null)
                {
                    tvAction.SelectedNode = xnode;
                    xnode.EnsureVisible();
                }
            }

            return true;
        }

        //
        // ViewSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewSettingDataList()
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
                    sb.Append("SELECT DISTINCT MAT_ID, MAT_VER, FLOW, OPER FROM MWIPFATDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = '1' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT DISTINCT MAT_ID, MAT_VER, OPER FROM MWIPFATDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = '4' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT DISTINCT FLOW, OPER FROM MWIPFATDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = '2' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT DISTINCT OPER FROM MWIPFATDEF ");
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

                MPCR.FillDataView(tvMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            lblDataCount.Text = tvMFO.GetListView.Items.Count.ToString();

            return true;
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


        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.tvMFO;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }


#endregion


        private void frmWIPSetupFutureAction_Load(object sender, EventArgs e)
        {
            MPCR.InitGRPCMFControl("lblCMF", "cdvCMF", grpCMF);

            MPCF.InitListView(lisServices);
            MPCF.ClearList(spdCond);

            txtCond1.Text = "(";
            txtRelation.Text = "";

            m_b_proc_view_action_detail = false;

            frmWIPSetupFutureAction_Resize(null, null);

            //Modify by J.S. 2011.12.05 베이스 폼보다 더 큰 폼을 사용하면 control의 위치가 강제로 바뀌는 경우 때문에
            //넣어 놓았던 코딩 원복(가끔 버턴이 사라지는 경우 발생), 폼을 베이스 폼에 맞추어 놓고 필요한 크기로
            //load, active시에 처리하는 것으로 수정
            this.Width = 986;
            this.Height = 650;
        }

        private void frmWIPSetupFutureAction_Activated(object sender, EventArgs e)
        {
            try
            {
                if (bLoadFlag == false)
                {
                    //Modify by J.S. 2011.12.05 위치 옴김
                    bLoadFlag = true;

                    cdvDependentAction.Init();
                    MPCF.InitListView(cdvDependentAction.GetListView);
                    cdvDependentAction.Columns.Add("Tran Code", 50, HorizontalAlignment.Left);
                    cdvDependentAction.Columns.Add("Tran Comment", 100, HorizontalAlignment.Left);
                    cdvDependentAction.Columns.Add("Action Key", 100, HorizontalAlignment.Left);
                    cdvDependentAction.SelectedSubItemIndex = 0;
                    cdvDependentAction.SelectedDescIndex = 1;
                }

                //Modify by J.S. 2011.12.05 베이스 폼보다 더 큰 폼을 사용하면 control의 위치가 강제로 바뀌는 경우 때문에
                //넣어 놓았던 코딩 원복(가끔 버턴이 사라지는 경우 발생), 폼을 베이스 폼에 맞추어 놓고 필요한 크기로
                //load, active시에 처리하는 것으로 수정
                if (this.Width < 986)
                {
                    this.Width = 986;
                }
                if (this.Height < 650)
                {
                    this.Height = 650;
                }
                frmWIPSetupFutureAction_Resize(null, null);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void frmWIPSetupFutureAction_Resize(object sender, EventArgs e)
        {
            //form에서 버턴이 자꾸 도망가는 버거 때문에 들어 있음
            //btnClose.Location = new Point(this.Width - 111, btnClose.Location.Y);
            //btnDelete.Location = new Point(this.Width - 202, btnClose.Location.Y);
            //btnUpdate.Location = new Point(this.Width - 293, btnClose.Location.Y);
            //btnCreate.Location = new Point(this.Width - 384, btnClose.Location.Y);

            tvAction_Resize(null, null);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(tvMFO.GetListView, this.Text, "");
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            tvMFO.RefreshSelectedList();
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
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

        private void cdvCMF_ButtonPress(System.Object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        private void tvMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.SelectedNode.GetNodeCount(false));
        }

        private void tvMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.GetTreeView.GetNodeCount(false));
        }

        // 선택 Level의 말단 노드가 선택되었을 때
        private void tvMFO_LevelItemSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            ViewFutureActionList();
        }

        private void tvMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewSettingDataList();
        }

        private void tvMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewFutureActionList();
        }

        private void tvMFO_SelectLevelChanged(object sender, EventArgs e)
        {
            if (m_int_action != null)
            {
                m_int_action.setMFOSelectLevel(tvMFO.SelectLevel);
            }
        }

        private void tvAction_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ST_ACTION_TAG st_action;

            if (e.Node.Parent == null) return;

            m_b_proc_view_action_detail = true;

            rbtBefore.Checked = false;
            rbtAfter.Checked = false;
            cboTransaction.Text = "";
            cboTransaction_SelectedIndexChanged(null, null);

            st_action = (ST_ACTION_TAG)e.Node.Tag;
            m_selected_action = st_action;

            if (st_action.oper_point == 'I')
            {
                rbtOperIn.Checked = true;
            }
            else if (st_action.oper_point == 'A')
            {
                rbtOperAt.Checked = true;
            }
            else if (st_action.oper_point == 'O')
            {
                rbtOperOut.Checked = true;
            }

            if (st_action.ba_point == 'B')
            {
                rbtBefore.Checked = true;
            }
            else if (st_action.ba_point == 'A')
            {
                rbtAfter.Checked = true;
            }

            if (ViewFutureAction() == false) return;

            cboTransaction.Text = st_action.tran_code;
            txtComment.Text = st_action.tran_comment;

            cdvDependentAction.Text = st_action.dependent_tran_code;
            cdvDependentAction.DescText = st_action.dependent_tran_comment;
            cdvDependentAction.Tag = st_action.dependent_key;

            cboTransaction_SelectedIndexChanged(null, null);

            // cboTransaction_SelectedIndexChanged() 에서 CMF 프롬프트를 표시하면서 값을 초기화 하여 CMF 값에 대해서만 다시 처리한다.
            ViewFutureActionFillCMF();
            ViewFutureActionListByPoint(cdvDependentAction.GetListView, st_action.point_key);

            m_b_proc_view_action_detail = false;
        }

        private void tvAction_Resize(object sender, EventArgs e)
        {
            btnCollapse.Location = new Point(tvAction.Width - 54, tvAction.Height + 4);
            btnExpand.Location = new Point(tvAction.Width - 27, tvAction.Height + 4);
        }

        private void rbtOperPoint_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ListViewItem itm;

            MPCF.InitListView(lisServices);
            rbtBefore.Checked = true;
            rbtAfter.Checked = false;
            grpBA.Enabled = true;

            if (rbtOperIn.Checked == true || rbtOperOut.Checked == true)
            {
                if (rbtOperIn.Checked == true)
                {
                    rbtBefore.Checked = false;
                    rbtAfter.Checked = false;
                    grpBA.Enabled = false;
                }

                for (i = 0; i < S_OPER_IN_OUT_SERVICES.Length; i++)
                {
                    itm = new ListViewItem();
                    itm.SubItems.Add(S_OPER_IN_OUT_SERVICES[i]);
                    itm.Checked = chkAll.Checked;

                    lisServices.Items.Add(itm);
                }
            }
            else
            {
                ListView lis_list;

                lis_list = new ListView();
                lis_list.Columns.Add(new ColumnHeader());

                BASLIST.ViewGCMDataList(lis_list, '1', MPGC.MP_FAC_OA_SERVICES);

                for (i = 0; i < lis_list.Items.Count; i++)
                {
                    itm = new ListViewItem();
                    itm.SubItems.Add(lis_list.Items[i].SubItems[0].Text);
                    itm.Checked = chkAll.Checked;

                    lisServices.Items.Add(itm);
                }
            }

            if (m_b_proc_view_action_detail == false)
            {
                if (rbtOperIn.Checked == true || rbtOperOut.Checked == true)
                {
                    chkAll.Checked = true;
                }
                else if (rbtOperAt.Checked == true)
                {
                    chkAll.Checked = false;
                }
            }

            {
                if (m_int_action != null)
                {
                    char c_oper_point = ' ';
                    char c_ba_point = ' ';
                    char c_skip_originated_service = ' ';

                    if (rbtOperIn.Checked == true) c_oper_point = 'I';
                    else if (rbtOperAt.Checked == true) c_oper_point = 'A';
                    else if (rbtOperOut.Checked == true) c_oper_point = 'O';

                    if (rbtBefore.Checked == true) c_ba_point = 'B';
                    else if (rbtAfter.Checked == true) c_ba_point = 'A';

                    if (chkSkipService.Checked == true) c_skip_originated_service = 'Y';

                    m_int_action.setPoint(c_oper_point, c_ba_point, c_skip_originated_service);
                }
            }
        }

        private void rbtBA_CheckedChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvDependentAction.Text) == "")
            {
                if (rbtBefore.Checked == true)
                {
                    chkSkipService.Enabled = true;
                    chkSkipService.Checked = true;
                }
                else
                {
                    chkSkipService.Checked = false;
                    chkSkipService.Enabled = false;
                }
            }

            {
                if (m_int_action != null)
                {
                    char c_oper_point = ' ';
                    char c_ba_point = ' ';
                    char c_skip_originated_service = ' ';

                    if (rbtOperIn.Checked == true) c_oper_point = 'I';
                    else if (rbtOperAt.Checked == true) c_oper_point = 'A';
                    else if (rbtOperOut.Checked == true) c_oper_point = 'O';

                    if (rbtBefore.Checked == true) c_ba_point = 'B';
                    else if (rbtAfter.Checked == true) c_ba_point = 'A';

                    if (chkSkipService.Checked == true) c_skip_originated_service = 'Y';

                    m_int_action.setPoint(c_oper_point, c_ba_point, c_skip_originated_service);
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            int i;

            for (i = 0; i < lisServices.Items.Count; i++)
            {
                lisServices.Items[i].Checked = chkAll.Checked;
            }
        }

        private void cboTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s_tran_cmf_code;

            // lisActionItem 선택으로인해 cboTransaction.text 의 값이 변경될 때 자동으로 발생하는 이벤트는 무시한다.
            if (m_b_proc_view_action_detail == true && sender != null)
            {
                return;
            }
            
            MPCF.FieldClear(grpCMF);

            SetTransactionValue(cboTransaction.Text);

            if (cboTransaction.Text != "")
            {
                if (cboTransaction.Text == "RAISE ALARM" ||
                    cboTransaction.Text == "INPUT ATTRIBUTE" ||
                    cboTransaction.Text == "ERROR ACTION" ||
                    cboTransaction.Text == "CUSTOM ACTION")
                {
                    ArrayList controls;
                    Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
                    int i;

                    controls = MPCF.GetIndexedControl("lblCMF", grpCMF);
                    for (i = 0; i < controls.Count; i++)
                    {
                        ((Label)controls[i]).Visible = true;
                        ((Label)controls[i]).Text = ((int)(i + 1)).ToString();
                    }

                    controls = MPCF.GetIndexedControl("cdvCMF", grpCMF);
                    for (i = 0; i < controls.Count; i++)
                    {
                        cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)controls[i];
                        cdvTemp.Init();

                        cdvTemp.VisibleButton = false;
                        cdvTemp.Visible = true;
                        cdvTemp.Text = "";
                    }

                    grpCMF.Tag = null;
                }
                else
                {
                    if (MPCF.Trim(grpCMF.Tag) != cboTransaction.Text)
                    {
                        s_tran_cmf_code = "CMF_TRN_" + cboTransaction.Text;
                        MPCR.SetCMFItem(s_tran_cmf_code, "lblCMF", "cdvCMF", grpCMF);
                        grpCMF.Tag = cboTransaction.Text;
                    }
                }
            }
        }

        private void cdvDependentAction_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvDependentAction.Tag = MPCF.Trim(e.SelectedItem.SubItems[2].Text);
        }

        private void cdvDependentAction_ButtonPress(object sender, EventArgs e)
        {
            ViewFutureActionListByPoint(cdvDependentAction.GetListView, m_selected_action.point_key);
            cdvDependentAction.InsertEmptyRow(0, 1);
        }

        private void cdvDependentAction_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvDependentAction.Text) == "")
            {
                lisServices.Enabled = true;
                chkAll.Enabled = true;
                chkSkipService.Enabled = true;
            }
            else
            {
                lisServices.Enabled = false;
                chkAll.Enabled = false;
                chkSkipService.Enabled = false;
            }
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvAction.Nodes)
            {
                if (node.GetNodeCount(false) > 0)
                {
                    node.Collapse(false);
                }
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvAction.Nodes)
            {
                if (node.GetNodeCount(false) > 0)
                {
                    node.ExpandAll();
                }
            }
        }

        private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            cdvField.Text = "";
            cboOperator.Text = "";
            
            cboValueType.Text = "";
            cdvValue1.Text = "";
            cdvValue2.Text = "";

            txtCond2.Text = "";

            if (cboCondition.SelectedIndex < 4) // General Condition
            {
                txtCond2.Enabled = true;
                txtCond2.ReadOnly = true;

                cdvField.Enabled = true;
                cdvField.BackColor = SystemColors.Window;
                cboOperator.Enabled = true;
                cboValueType.Enabled = true;

                MakeCond1Text();
            }
            else // Custom Condition
            {
                txtCond1.Text = "(";
                txtCond2.Enabled = false;
                txtCond2.ReadOnly = true;

                cdvField.Enabled = false;
                cdvField.BackColor = SystemColors.Control;
                cboOperator.Enabled = false;
                cboValueType.Enabled = false;
            }
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

        private void cdvField_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cboCondition.SelectedIndex < 4) // General Condition
            {
                MakeCond1Text();
            }
        }

        private void cboOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            MakeCond1Text();
        }

        private void cboValueType_TextChanged(object sender, EventArgs e)
        {
            if (cboValueType.Text == "")
            {
                cboValueType.SelectedIndex = -1;
                cboValueType_SelectedIndexChanged(null, null);
            }
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
                    lblValue1.Text = MPCF.FindLanguage("Value", CAPTION_TYPE.LABEL);
                    lblValue1.Visible = true;
                    txtFVUsage.Visible = true;
                    cdvValue1.Visible = true;
                    cdvValue1.ReadOnly = false;
                    break;
                case 1: // GCM TABLE
                    lblValue1.Text = MPCF.FindLanguage("Table Name", CAPTION_TYPE.LABEL);
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

        private void cdvValue1_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (cboValueType.SelectedIndex == 0)
            {
                txtCond2.Text = cdvValue1.Text;
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

        private void cdvValue1_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
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

        private void cdvValue2_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
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

        private void spdCond_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == true) return;
            if (e.RowHeader == true) return;

            spdCondCellClick(e.Row);
        }

        private void spdCond_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Row == 0 && e.Column == 0)
            {
                spdCond.ActiveSheet.Cells[0, 0].Value = null;
            }

            MakeRelationCondition();
        }

        private void txtCond2_Leave(object sender, EventArgs e)
        {
            if (cboValueType.SelectedIndex == 2)
            {
                if (MPCF.Trim(txtCond2.Text) != "")
                {
                    ChangeSQLSyntaxColor();
                }
            }
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (UpdateFutureAction(MPGC.MP_STEP_CREATE) == false) return;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateFutureAction(MPGC.MP_STEP_UPDATE) == false) return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
            if (UpdateFutureAction(MPGC.MP_STEP_DELETE) == false) return;
        }




    }
}

