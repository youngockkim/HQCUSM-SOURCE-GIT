//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWEMSetupWorkProcessType.cs
//   Description : MES Cient Form Work Process Type Setup Class
//
//   MES Version : 5.3.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-11-01 : Created by Aiden
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
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

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
using Miracom.WEMCore.Setup;

namespace Miracom.WEMCore
{

/*

* HOLD * V
* RELEASE * V
END X
SKIP X
* REWORK * V
* REPAIR * V
* ADAPT * V
STORE
UNSTORE
* TERMINATE * V
MOVE LOT X
* MOVE STEP * V
* CHANGE STATUS * V
NEW BBS
* RESOURCE EVENT * V
CARRIER EVENT
* TOOL EVENT * V
* RAISE ALARM * V
* INPUT ATTRIBUTE * V
* RETURN MESSAGE * V
* DEACTIVATE MATERIAL * V
* CUSTOM ACTION * V

*/


    public partial class frmWEMSetupStepAction : SetupForm02
    {
        public frmWEMSetupStepAction()
        {
            InitializeComponent();
        }

        #region " Constant Definition "
        private const string COND_TYPE_LOT_STATUS = "Lot Status";
        private const string COND_TYPE_LOT_ATTR = "Lot Attribute";
        private const string COND_TYPE_RES_STATUS = "Resource Status";
        private const string COND_TYPE_RES_ATTR = "Resource Attribute";
        private const string COND_TYPE_PROC_EVENT_STATUS = "Process Event Status";
        private const string COND_TYPE_MATERIAL_PROP = "Material Property";
        private const string COND_TYPE_MATERIAL_ATTR = "Material Attribute";
        private const string COND_TYPE_SPECIFICATION = "Specification";
        private const string COND_TYPE_USER_SQL = "User SQL";
        private const string COND_TYPE_PROCESS_INPUT_VALUE = "Process Input Value";
        private const string COND_TYPE_CUST_COND = "Custom Condition";

        private const string VALUE_TYPE_FIXED_VALUE = "Fixed Value";
        private const string VALUE_TYPE_GCM_TABLE = "GCM Table";
        private const string VALUE_TYPE_USER_SQL = "User SQL";
        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private intStepActionControl m_true_action;
        private intStepActionControl m_false_action;

        #endregion

        #region " Function Definition "

        private bool ViewWorkProcessAction()
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_PROC_ACTION_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_PROC_ACTION_OUT");
            List<TRSNode> cond_list;
            int i;
            int i_row;
            string s_tmp;

            ClearField(1);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(cdvProcType.Text));
            in_node.AddString("ACTION_ID", MPCF.Trim(txtActionID.Text));

            if (MPCR.CallService("WEM", "WEM_View_Step_Action", in_node, ref out_node) == false)
            {
                return false;
            }

            txtActionDesc.Text = out_node.GetString("ACTION_DESC");

            if (out_node.GetChar("ACTION_TYPE") == '1') // Just positive condition
            {
                cboActionType.SelectedIndex = 0;
                if (SetTransactionValue('T', out_node.GetList("TRUE_ACTION")[0]) == false)
                {
                    return false;
                }
            }
            else // Action with True or False
            {
                cboActionType.SelectedIndex = 1;
                if (SetTransactionValue('T', out_node.GetList("TRUE_ACTION")[0]) == false)
                {
                    return false;
                }
                if (SetTransactionValue('F', out_node.GetList("FALSE_ACTION")[0]) == false)
                {
                    return false;
                }
            }

            cond_list = out_node.GetList("CONDITION_LIST");
            for (i = 0; i < cond_list.Count; i++)
            {
                i_row = spdCond.ActiveSheet.RowCount;
                spdCond.ActiveSheet.RowCount++;

                spdCond.ActiveSheet.Cells[i_row, 0].Value = cond_list[i].GetString("AND_OR");
                spdCond.ActiveSheet.Cells[i_row, 1].Value = cond_list[i].GetString("L_BRACKET");

                s_tmp = cond_list[i].GetString("COND_TYPE");
                if (s_tmp == "LS")
                    s_tmp = COND_TYPE_LOT_STATUS;
                else if (s_tmp == "LA")
                    s_tmp = COND_TYPE_LOT_ATTR;
                else if (s_tmp == "RS")
                    s_tmp = COND_TYPE_RES_STATUS;
                else if (s_tmp == "RA")
                    s_tmp = COND_TYPE_RES_ATTR;
                else if (s_tmp == "PE")
                    s_tmp = COND_TYPE_PROC_EVENT_STATUS;
                else if (s_tmp == "MP")
                    s_tmp = COND_TYPE_MATERIAL_PROP;
                else if (s_tmp == "MA")
                    s_tmp = COND_TYPE_MATERIAL_ATTR;
                else if (s_tmp == "SP")
                    s_tmp = COND_TYPE_SPECIFICATION;
                else if (s_tmp == "US")
                    s_tmp = COND_TYPE_USER_SQL;
                else if (s_tmp == "CC")
                    s_tmp = COND_TYPE_CUST_COND;
                else if (s_tmp == "PI")
                    s_tmp = COND_TYPE_PROCESS_INPUT_VALUE;

                spdCond.ActiveSheet.Cells[i_row, 2].Value = s_tmp;

                if (cond_list[i].GetString("COND_TYPE") == "US")
                {
                    spdCond.ActiveSheet.Cells[i_row, 3].Value = cond_list[i].GetString("SQL_FIELD");
                }
                else
                {
                    spdCond.ActiveSheet.Cells[i_row, 3].Value = cond_list[i].GetString("FIELD_NAME_1");
                    spdCond.ActiveSheet.Cells[i_row, 4].Value = cond_list[i].GetString("FIELD_NAME_2");
                }
                spdCond.ActiveSheet.Cells[i_row, 5].Value = cond_list[i].GetString("OPERATOR");

                s_tmp = cond_list[i].GetString("VALUE_TYPE");
                if (s_tmp == "FV")
                    s_tmp = VALUE_TYPE_FIXED_VALUE;
                else if (s_tmp == "GT")
                    s_tmp = VALUE_TYPE_GCM_TABLE;
                else if (s_tmp == "US")
                    s_tmp = VALUE_TYPE_USER_SQL;

                spdCond.ActiveSheet.Cells[i_row, 6].Value = s_tmp;

                spdCond.ActiveSheet.Cells[i_row, 7].Value = cond_list[i].GetString("VALUE_1");
                spdCond.ActiveSheet.Cells[i_row, 8].Value = cond_list[i].GetString("VALUE_2");
                spdCond.ActiveSheet.Cells[i_row, 9].Value = cond_list[i].GetString("R_BRACKET");
            }


            return true;
        }

        private bool UpdateWorkProcessAction(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_WORK_PROCESS_ACTION_IN");
            TRSNode out_node = new TRSNode("UPDATE_WORK_PROCESS_ACTION_OUT");
            TRSNode list_item;
            int i;
            string s_tmp;

            if (CheckCondition(c_step) == false)
            {
                return false;
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("WORK_PROC_TYPE", cdvProcType.Text);
            in_node.AddString("ACTION_ID", txtActionID.Text);
            in_node.AddString("ACTION_DESC", txtActionDesc.Text);

            if (c_step == MPGC.MP_STEP_CREATE || c_step == MPGC.MP_STEP_UPDATE)
            {
                if (m_true_action.checkCondition() == false)
                {
                    tabAction.SelectedTab = tbpAction;
                    return false;
                }

                list_item = in_node.AddNode("TRUE_ACTION");
                m_true_action.getAction(list_item);
                list_item.AddString("TRAN_COMMENT", txtTrueComment.Text);

                if (cboActionType.SelectedIndex == 0)
                {
                    in_node.AddChar("ACTION_TYPE", '1');
                }
                else if (cboActionType.SelectedIndex == 1)
                {
                    in_node.AddChar("ACTION_TYPE", '2');

                    if (m_false_action.checkCondition() == false)
                    {
                        tabAction.SelectedTab = tbpAction;
                        return false;
                    }
                    list_item = in_node.AddNode("FALSE_ACTION");
                    m_false_action.getAction(list_item);
                    list_item.AddString("TRAN_COMMENT", txtFalseComment.Text);
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
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_RES_STATUS)
                        s_tmp = "RS";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_RES_ATTR)
                        s_tmp = "RA";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_PROC_EVENT_STATUS)
                        s_tmp = "PE";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_MATERIAL_PROP)
                        s_tmp = "MP";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_MATERIAL_ATTR)
                        s_tmp = "MA";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_SPECIFICATION)
                        s_tmp = "SP";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_USER_SQL)
                        s_tmp = "US";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_CUST_COND)
                        s_tmp = "CC";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 2].Value) == COND_TYPE_PROCESS_INPUT_VALUE)
                        s_tmp = "PI";
                    
                    list_item.AddString("COND_TYPE", s_tmp);

                    if (s_tmp == "US")
                    {
                        list_item.AddString("SQL_FIELD", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 3].Value));
                    }
                    else
                    {
                        list_item.AddString("FIELD_NAME_1", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 3].Value));
                        list_item.AddString("FIELD_NAME_2", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 4].Value));
                    }
                    list_item.AddString("OPERATOR", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 5].Value));

                    s_tmp = "";
                    if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 6].Value) == VALUE_TYPE_FIXED_VALUE)
                        s_tmp = "FV";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 6].Value) == VALUE_TYPE_GCM_TABLE)
                        s_tmp = "GT";
                    else if (MPCF.Trim(spdCond.ActiveSheet.Cells[i, 6].Value) == VALUE_TYPE_USER_SQL)
                        s_tmp = "US";

                    list_item.AddString("VALUE_TYPE", s_tmp);

                    list_item.AddString("VALUE_1", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 7].Value));
                    list_item.AddString("VALUE_2", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 8].Value));
                    list_item.AddString("R_BRACKET", MPCF.Trim(spdCond.ActiveSheet.Cells[i, 9].Value));
                }
            }

            if (MPCR.CallService("WEM", "WEM_Update_Step_Action", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }

        private bool SetTransactionValue(char c_tf_flag, TRSNode action_node)
        {
            if (SetTransactionValue(c_tf_flag, action_node.GetString("TRAN_CODE"), action_node.GetString("TRAN_COMMENT")) == false)
            {
                return false;
            }

            if (c_tf_flag == 'T' && m_true_action != null)
            {
                m_true_action.setAction(action_node);
            }
            else if (c_tf_flag == 'F' && m_false_action != null)
            {
                m_false_action.setAction(action_node);
            }

            return true;
        }

        private bool SetTransactionValue(char c_tf_flag, string s_tran_code, string s_comment)
        {
            udcStepActionBase ctl_action;
            Panel pnlTranAction;

            ctl_action = null;

            if (c_tf_flag == 'T')
            {
                m_true_action = null;
                pnlTranAction = pnlTrueAction;
                cboTrueAction.Text = s_tran_code;
                txtTrueComment.Text = s_comment;
            }
            else
            {
                m_false_action = null;
                pnlTranAction = pnlFalseAction;
                cboFalseAction.Text = s_tran_code;
                txtFalseComment.Text = s_comment;
            }

            try
            {
                pnlTranAction.Controls.Clear();

                switch (s_tran_code)
                {
                    case MPGC.MP_TRAN_CODE_HOLD:
                        ctl_action = new udcStepActionHold();
                        break;

                    case MPGC.MP_TRAN_CODE_RELEASE:
                        ctl_action = new udcStepActionRelease();
                        break;

                    case MPGC.MP_TRAN_CODE_END:
                        ctl_action = new udcStepActionEnd();
                        break;

                    case MPGC.MP_TRAN_CODE_SKIP:
                        ctl_action = new udcStepActionSkip();
                        break;

                    case MPGC.MP_TRAN_CODE_TERMINATE:
                        ctl_action = new udcStepActionTerminate();
                        break;

                    case MPGC.MP_TRAN_CODE_REWORK:
                        ctl_action = new udcStepActionRework();
                        break;

                    case MPGC.MP_TRAN_CODE_ADAPT:
                        ctl_action = new udcStepActionAdapt();
                        break;

                    case MPGC.MP_TRAN_CODE_REPAIR:
                        ctl_action = new udcStepActionRepair();
                        break;

                    case MPGC.MP_TRAN_CODE_STORE:
                        ctl_action = new udcStepActionStore();
                        break;

                    case MPGC.MP_TRAN_CODE_UNSTORE:
                        ctl_action = new udcStepActionUnstore();
                        break;

                    case "MOVE LOT":
                        ctl_action = new udcStepActionMoveLot();
                        break;

                    case "MOVE STEP":
                        ctl_action = new udcStepActionMoveStep();
                        ((udcStepActionMoveStep)ctl_action).setWorkProcType(cdvProcType.Text);
                        break;

                    case "NEW BBS":
                        ctl_action = new udcStepActionNewBBS();
                        break;

                    case "RESOURCE EVENT":
                        ctl_action = new udcStepActionResourceEvent();
                        break;

                    case "RAISE ALARM":
                        ctl_action = new udcStepActionRaiseAlarm();
                        break;

                    case "INPUT ATTRIBUTE":
                        ctl_action = new udcStepActionInputAttribute();
                        break;

                    case "CARRIER EVENT":
                        ctl_action = new udcStepActionCarrierEvent();
                        break;

                    case "TOOL EVENT":
                        ctl_action = new udcStepActionToolEvent();
                        break;

                    case "CHANGE STATUS":
                        ctl_action = new udcStepActionChangeStatusValue();
                        ((udcStepActionChangeStatusValue)ctl_action).setWorkProcType(cdvProcType.Text);
                        break;

                    case "DEACTIVATE MATERIAL":
                        ctl_action = new udcStepActionDeactivateMaterial();
                        break;

                    case "RETURN MESSAGE":
                        ctl_action = new udcStepActionReturnMessage();
                        break;

                    case "CUSTOM ACTION":
                        ctl_action = new udcStepActionCustomAction();
                        break;

                    default:
                        return false;

                }

                if (ctl_action != null)
                {
                    MPCF.ConvertMessage(ctl_action.Controls);
                    ctl_action.Dock = DockStyle.Fill;

                    pnlTranAction.Controls.Add(ctl_action);

                    if (c_tf_flag == 'T')
                    {
                        m_true_action = ctl_action;
                    }
                    else
                    {
                        m_false_action = ctl_action;
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

        private void ChangeSQLSyntaxColor(RichTextBox txt)
        {
            int i_start = 0;
            int i_len = 0;

            if (MPCF.Trim(txt.Text) == "")
            {
                return;
            }

            if (txt.Text[txt.Text.Length - 1] != ' ')
            {
                txt.Text += " ";
            }

            txt.SelectionStart = 0;
            txt.SelectionLength = txt.Text.Length;
            txt.SelectionColor = System.Drawing.SystemColors.ControlText;

            while (i_len < txt.Text.Length)
            {
                if (txt.Text[i_len] == ' ' || i_len == txt.Text.Length - 1)
                {
                    if (MPCF.IsSQLSyntax(MPCF.ToUpper(txt.Text.Substring(i_start, i_len - i_start))) == true ||
                        txt.Text.Substring(i_start, i_len - i_start).IndexOf("$") > 0)
                    {
                        txt.SelectionStart = i_start;
                        txt.SelectionLength = i_len - i_start;
                        txt.SelectionColor = System.Drawing.Color.Blue;
                        txt.SelectionStart = i_len;
                        txt.SelectionLength = 0;
                        txt.SelectionColor = System.Drawing.SystemColors.ControlText;
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

                if (cboCondition.SelectedIndex < 10)
                {
                    if (cboCondition.SelectedIndex < 9 && cdvField1.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvField1.Focus();
                        return false;
                    }
                    if (cboCondition.SelectedIndex == 8 && txtCond1.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        txtCond1.Focus();
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
                    if (cboValueType.SelectedIndex == 2 && txtCond2.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        txtCond2.Focus();
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

                    if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 3].Value) != cdvField1.Text)
                        b_match = false;

                    if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 4].Value) != cdvField2.Text)
                        b_match = false;

                    if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 5].Value) != cboOperator.Text)
                        b_match = false;

                    if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 6].Value) != cboValueType.Text)
                        b_match = false;

                    if (cboValueType.SelectedIndex == 0 || cboValueType.SelectedIndex == 1)
                    {
                        if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 7].Value) != cdvValue1.Text)
                            b_match = false;
                    }
                    else if (cboValueType.SelectedIndex == 2)
                    {
                        if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 7].Value) != txtCond2.Text)
                            b_match = false;
                    }

                    if (cboValueType.SelectedIndex == 1)
                    {
                        if (b_match == true && MPCF.Trim(spdCond.ActiveSheet.Cells[i, 8].Value) != cdvValue2.Text)
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
                if (MPCF.CheckValue(cdvProcType, 1) == false) return false;
                if (MPCF.CheckValue(txtActionID, 1) == false) return false;

                // Check Create/Update Condition
                if (c_proc_step == MPGC.MP_STEP_CREATE || c_proc_step == MPGC.MP_STEP_UPDATE)
                {
                    if (cboActionType.Text == "")
                    {
                        tabAction.SelectedTab = tbpAction;
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        cboActionType.Focus();
                        return false;
                    }

                    if (cboTrueAction.SelectedIndex < 0)
                    {
                        tabAction.SelectedTab = tbpAction;
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        cboTrueAction.Focus();
                        return false;
                    }
                    if (cboActionType.SelectedIndex == 1 && cboFalseAction.SelectedIndex < 0)
                    {
                        tabAction.SelectedTab = tbpAction;
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        cboFalseAction.Focus();
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

        private void ClearField(int i_case)
        {
            switch (i_case)
            {
                case 1:
                    MPCF.FieldClear(grpProcAction, txtActionID);
                    MPCF.FieldClear(tbpAction);
                    cboCondition.SelectedIndex = -1;
                    MPCF.ClearList(spdCond);

                    m_true_action = null;
                    m_false_action = null;
                    break;

                case 2:
                    MPCF.FieldClear(grpProcAction);
                    MPCF.FieldClear(tbpAction);
                    cboCondition.SelectedIndex = -1;
                    MPCF.ClearList(spdCond);

                    m_true_action = null;
                    m_false_action = null;
                    break;
            }
        }

        private void MakeRelationCondition()
        {
            int i;
            string s_relation;

            s_relation = "";
            for (i = 0; i < spdCond.ActiveSheet.RowCount; i++)
            {
                s_relation += MPCF.Trim(spdCond.ActiveSheet.Cells[i, 1].Value) + " " + ((int)(i + 1)).ToString() + " " + MPCF.Trim(spdCond.ActiveSheet.Cells[i, 9].Value);
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
            if (cboCondition.SelectedIndex == 8)
            {
                txtCond1.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 3].Value);
                ChangeSQLSyntaxColor(txtCond1);
            }
            else
            {
                cdvField1.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 3].Value);
                cdvField2.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 4].Value);
            }
            cboOperator.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 5].Value);
            cboValueType.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 6].Value);

            cdvValue1.Text = "";
            cdvValue2.Text = "";

            if (cboValueType.SelectedIndex == 0)
            {
                cdvValue1.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 7].Value);
            }
            else if (cboValueType.SelectedIndex == 1)
            {
                cdvValue1.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 7].Value);

                cdvValue1_SelectedItemChanged(null, null);

                cdvValue2.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 8].Value);

                cdvValue2_SelectedItemChanged(null, null);
            }
            else if (cboValueType.SelectedIndex == 2)
            {
                txtCond2.Text = MPCF.Trim(spdCond.ActiveSheet.Cells[i_row, 7].Value);
                ChangeSQLSyntaxColor(txtCond2);
            }
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.cdvProcType;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion
        
        private void frmWEMSetupStepAction_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.InitListView(lisActionList);
                MPCF.ClearList(spdCond);

                cboActionType.SelectedIndex = 0;

                cdvField2.Enabled = false;
                cdvField2.BackColor = SystemColors.Control;
                txtCond2.Location = new Point(71, 109);
                txtCond2.Height = 97;
                lblUserSQL2.Location = new Point(10, 111);
                txtRelation.Text = "";

                b_load_flag = true;
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisActionList, this.Text, "");
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvProcType, 1) == false) return;

            try
            {
                lblDataCount.Text = "";
                if (WEMLIST.ViewStepActionList(lisActionList, cdvProcType.Text) == false)
                {
                    return;
                }
                lblDataCount.Text = lisActionList.Items.Count.ToString();
                if (lisActionList.Items.Count > 0)
                {
                    MPCF.FindListItem(lisActionList, txtActionID.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisActionList, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisActionList, txtFind.Text, 0, true, false);
        }

        private void cdvProcType_ButtonPress(object sender, EventArgs e)
        {
            cdvProcType.Init();
            MPCF.InitListView(cdvProcType.GetListView);
            cdvProcType.Columns.Add("Process Type", 150, HorizontalAlignment.Left);
            cdvProcType.Columns.Add("Description", 150, HorizontalAlignment.Left);
            cdvProcType.SelectedSubItemIndex = 0;
            WEMLIST.ViewWorkProcessTypeList(cdvProcType.GetListView);
        }

        private void cdvProcType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void cboActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboActionType.SelectedIndex == 0)
            {
                grpFalse.Visible = false;
                grpFalse.Width = 0;

                grpTrue.Dock = DockStyle.Fill;
            }
            else if (cboActionType.SelectedIndex == 1)
            {
                grpTrue.Dock = DockStyle.Left;
                grpTrue.Width = tbpAction.Width / 2;

                grpFalse.Visible = true;
                grpFalse.Width = grpTrue.Width;
            }
        }

        private void lisActionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisActionList.SelectedItems.Count < 1) return;

            txtActionID.Text = lisActionList.SelectedItems[0].Text;
            if (ViewWorkProcessAction() == false) return;

            MakeRelationCondition();
        }

        private void tbpAction_Resize(object sender, EventArgs e)
        {
            if (cboActionType.SelectedIndex == 1)
            {
                grpTrue.Width = tbpAction.Width / 2;
                grpFalse.Width = grpTrue.Width;
            }
        }

        private void cboTrueAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SetTransactionValue('T', cboTrueAction.Text, txtTrueComment.Text) == false) return;
        }

        private void cboFalseAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SetTransactionValue('F', cboFalseAction.Text, txtFalseComment.Text) == false) return;
        }

        private void cboCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            cdvField1.Text = "";
            cdvField2.Text = "";

            cboOperator.SelectedIndex = -1;
            cboValueType.SelectedIndex = -1;

            cdvValue1.Text = "";
            cdvValue2.Text = "";

            txtCond1.Text = "";
            txtCond2.Text = "";

            cdvField2.Enabled = false;
            cdvField2.BackColor = SystemColors.Control;
            cdvField2.Visible = true;
            lblField2.Visible = true;

            txtCond1.Visible = false;
            lblUserSQL1.Visible = false;

            txtCond2.Location = new Point(71, 109);
            txtCond2.Height = 97;
            lblUserSQL2.Location = new Point(10, 111);
            lblUserSQL2.Text = MPCF.FindLanguage("SQL", CAPTION_TYPE.LABEL);

            lblOperator.Location = new Point(10, 88);
            cboOperator.Location = new Point(71, 85);

            if (cboCondition.SelectedIndex < 10) // General Condition
            {
                txtCond2.Enabled = true;
                txtCond2.ReadOnly = true;

                cdvField1.Enabled = true;
                cdvField1.BackColor = SystemColors.Window;

                cboOperator.Enabled = true;
                cboValueType.Enabled = true;
            }
            else // Custom Condition
            {
                txtCond2.Enabled = false;
                txtCond2.ReadOnly = true;

                cdvField1.Enabled = false;
                cdvField1.BackColor = SystemColors.Control;

                cboOperator.Enabled = false;
                cboValueType.Enabled = false;
            }

            switch (cboCondition.SelectedIndex)
            {
                case 7: // Specification
                    cdvField2.Enabled = true;
                    cdvField2.BackColor = SystemColors.Window;
                    break;

                case 8: // User SQL
                    cdvField1.Enabled = false;
                    cdvField1.BackColor = SystemColors.Control;
                
                    cdvField2.Visible = false;
                    lblField2.Visible = false;

                    lblOperator.Location = new Point(10, 64);
                    cboOperator.Location = new Point(71, 61);

                    txtCond1.Visible = true;
                    lblUserSQL1.Visible = true;

                    txtCond1.Location = new Point(71, 85);
                    txtCond1.Height = 56;
                    lblUserSQL1.Location = new Point(10, 88);

                    txtCond2.Location = new Point(71, 143);
                    txtCond2.Height = 63;
                    lblUserSQL2.Location = new Point(10, 145);
                    lblUserSQL2.Text = MPCF.FindLanguage("SQL 2", CAPTION_TYPE.LABEL);
                    break;
            }
        }

        private void cdvField1_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                if (cboCondition.Text != "")
                {
                    cdvField1.Init();
                    MPCF.InitListView(cdvField1.GetListView);

                    switch (cboCondition.SelectedIndex)
                    {
                        case 0: // LOT STATUS
                            cdvField1.Columns.Add("Column", 50, HorizontalAlignment.Left);
                            cdvField1.SelectedSubItemIndex = 0;
                            cdvField1.DisplaySubItemIndex = 0;
                            MPCR.ViewLotStatusColumnList(cdvField1.GetListView);
                            break;

                        case 1: // LOT ATTRIBUTE
                            cdvField1.Columns.Add("Seq", 50, HorizontalAlignment.Left);
                            cdvField1.Columns.Add("Name", 100, HorizontalAlignment.Left);
                            cdvField1.Columns.Add("Type", 100, HorizontalAlignment.Left);
                            cdvField1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                            cdvField1.SelectedSubItemIndex = 1;
                            cdvField1.DisplaySubItemIndex = 1;
                            BASLIST.ViewAttributeNameList(cdvField1.GetListView, '1', MPGC.MP_ATTR_TYPE_LOT);
                            break;

                        case 2: // RES STATUS
                            cdvField1.Columns.Add("Column", 50, HorizontalAlignment.Left);
                            cdvField1.SelectedSubItemIndex = 0;
                            cdvField1.DisplaySubItemIndex = 0;
                            MPCR.ViewResourceStatusColumnList(cdvField1.GetListView);
                            break;

                        case 3: // RES ATTRIBUTE
                            cdvField1.Columns.Add("Seq", 50, HorizontalAlignment.Left);
                            cdvField1.Columns.Add("Name", 100, HorizontalAlignment.Left);
                            cdvField1.Columns.Add("Type", 100, HorizontalAlignment.Left);
                            cdvField1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                            cdvField1.SelectedSubItemIndex = 1;
                            cdvField1.DisplaySubItemIndex = 1;
                            BASLIST.ViewAttributeNameList(cdvField1.GetListView, '1', MPGC.MP_ATTR_TYPE_RESOURCE);
                            break;

                        case 4: // PROCESS EVENT STATUS
                            cdvField1.Columns.Add("Column", 50, HorizontalAlignment.Left);
                            cdvField1.SelectedSubItemIndex = 0;
                            cdvField1.DisplaySubItemIndex = 0;
                            MPCR.ViewProcEventStatusColumnList(cdvField1.GetListView);
                            break;

                        case 5: // MATERIAL PROPERTY
                            cdvField1.Columns.Add("Column", 50, HorizontalAlignment.Left);
                            cdvField1.SelectedSubItemIndex = 0;
                            cdvField1.DisplaySubItemIndex = 0;
                            MPCR.ViewMaterialPropertyColumnList(cdvField1.GetListView);
                            break;

                        case 6: // MATERIAL ATTRIBUTE
                            cdvField1.Columns.Add("Seq", 50, HorizontalAlignment.Left);
                            cdvField1.Columns.Add("Name", 100, HorizontalAlignment.Left);
                            cdvField1.Columns.Add("Type", 100, HorizontalAlignment.Left);
                            cdvField1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                            cdvField1.SelectedSubItemIndex = 1;
                            cdvField1.DisplaySubItemIndex = 1;
                            BASLIST.ViewAttributeNameList(cdvField1.GetListView, '1', MPGC.MP_ATTR_TYPE_MATERIAL);
                            break;

                        case 7: // SPECIFICATION
                            cdvField1.Columns.Add("Character", 50, HorizontalAlignment.Left);
                            cdvField1.Columns.Add("Description", 100, HorizontalAlignment.Left);
                            cdvField1.SelectedSubItemIndex = 0;
                            cdvField1.DisplaySubItemIndex = 0;
                            EDCLIST.ViewEDCCharacterList(cdvField1.GetListView, '1', 'S');
                            break;

                        case 9: // PROCESS INPUT VALUE
                            cdvField1.Columns.Add("Member", 50, HorizontalAlignment.Left);
                            cdvField1.Columns.Add("Description", 100, HorizontalAlignment.Left);
                            cdvField1.SelectedSubItemIndex = 0;
                            cdvField1.DisplaySubItemIndex = 0;
                            SVMLIST.ViewServiceMemberList(cdvField1.GetListView, "WEM_Process_Event", 'I', "");
                            break;
                    
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvField1_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cboCondition.SelectedIndex == 7) // SPECIFICATION
            {
                cdvField2.Text = "";
            }
        }

        private void cdvField2_ButtonPress(object sender, EventArgs e)
        {
            if (cboCondition.SelectedIndex == 7)
            {
                cdvField2.Init();
                MPCF.InitListView(cdvField2.GetListView);
                cdvField2.Columns.Add("Seq", 50, HorizontalAlignment.Left);
                cdvField2.Columns.Add("Name", 100, HorizontalAlignment.Left);
                cdvField2.SelectedSubItemIndex = 1;
                cdvField2.DisplaySubItemIndex = 1;
                BASLIST.ViewAttributeNameList(cdvField2.GetListView, '1', MPGC.MP_ATTR_TYPE_SPEC);
                cdvField2.InsertEmptyRow(0, 1);
            }
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

            ChangeSQLSyntaxColor(txtCond2);
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
                if (cboCondition.SelectedIndex == 8)
                {
                    spdCond.ActiveSheet.Cells[i_row, 3].Value = txtCond1.Text;
                }
                else
                {
                    spdCond.ActiveSheet.Cells[i_row, 3].Value = cdvField1.Text;
                    spdCond.ActiveSheet.Cells[i_row, 4].Value = cdvField2.Text;
                }
                spdCond.ActiveSheet.Cells[i_row, 5].Value = cboOperator.Text;
                spdCond.ActiveSheet.Cells[i_row, 6].Value = cboValueType.Text;

                spdCond.ActiveSheet.Cells[i_row, 7].Value = "";
                spdCond.ActiveSheet.Cells[i_row, 8].Value = "";

                if (cboValueType.SelectedIndex == 0 || cboValueType.SelectedIndex == 1)
                {
                    spdCond.ActiveSheet.Cells[i_row, 7].Value = cdvValue1.Text;
                }
                if (cboValueType.SelectedIndex == 1)
                {
                    spdCond.ActiveSheet.Cells[i_row, 8].Value = cdvValue2.Text;
                }
                if (cboValueType.SelectedIndex == 2)
                {
                    spdCond.ActiveSheet.Cells[i_row, 7].Value = txtCond2.Text;
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
                cdvField1.Text = "";
                cdvField2.Text = "";
                cboOperator.Text = "";

                cboValueType.Text = "";
                cdvValue1.Text = "";
                cdvValue2.Text = "";

                txtCond1.Text = "";
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

        private void txtCond1_Leave(object sender, EventArgs e)
        {
            if (cboCondition.SelectedIndex == 8)
            {
                if (MPCF.Trim(txtCond1.Text) != "")
                {
                    ChangeSQLSyntaxColor(txtCond1);
                }
            }
        }

        private void txtCond2_Leave(object sender, EventArgs e)
        {
            if (cboValueType.SelectedIndex == 2)
            {
                if (MPCF.Trim(txtCond2.Text) != "")
                {
                    ChangeSQLSyntaxColor(txtCond2);
                }
            }
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (UpdateWorkProcessAction(MPGC.MP_STEP_CREATE) == false) return;
            btnRefresh.PerformClick();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateWorkProcessAction(MPGC.MP_STEP_UPDATE) == false) return;
            btnRefresh.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
            if (UpdateWorkProcessAction(MPGC.MP_STEP_DELETE) == false) return;
            btnRefresh.PerformClick();

            ClearField(2);
        }
   
    
    
    }
}
