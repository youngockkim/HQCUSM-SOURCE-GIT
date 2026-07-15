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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WEMCore
{
    public partial class frmWEMSetupProcessStep : SetupForm02
    {
        public frmWEMSetupProcessStep()
        {
            InitializeComponent();
        }

        #region " Constant Definition "
        private int ICON_SUCCESS = (int)SMALLICON_INDEX.IDX_VERSION_REQUEST;
        private int ICON_FAIL = (int)SMALLICON_INDEX.IDX_VERSION_APPROVAL;
        private int ICON_ALWAYS = (int)SMALLICON_INDEX.IDX_VERSION;
        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private List<String> ls_deleted_status;

        #endregion

        #region " Function Definition "

        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition(char c_proc_step)
        {
            if (MPCF.CheckValue(cdvProcType, 1) == false) return false;
            if (MPCF.CheckValue(txtProcStep, 1) == false) return false;

            switch (c_proc_step)
            {
                case MPGC.MP_STEP_CREATE:
                    if (spdAStatus.ActiveSheet.RowCount < 1)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(107));
                        tabStepRelation.SelectedTab = tbpStatus;
                        spdAStatus.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvScreenID, 1) == false)
                    {
                        tabStepRelation.SelectedTab = tbpOption;
                        cdvScreenID.Focus();
                        return false;
                    }

                    break;
                case MPGC.MP_STEP_UPDATE:
                    if (spdAStatus.ActiveSheet.RowCount < 1)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(107));
                        tabStepRelation.SelectedTab = tbpStatus;
                        spdAStatus.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvScreenID, 1) == false)
                    {
                        tabStepRelation.SelectedTab = tbpOption;
                        cdvScreenID.Focus();
                        return false;
                    }
                    break;
                case MPGC.MP_STEP_DELETE:
                    break;
            }

            return true;
        }

        private bool ViewWorkProcessType()
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_PROC_TYPE_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_PROC_TYPE_OUT");
            List<TRSNode> lis_status_list;
            int i;
            int i_row;
            string s_status_type;
            string s_format;

            MPCF.ClearList(spdStatus);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(cdvProcType.Text));

            if (MPCR.CallService("WEM", "WEM_View_Work_Process_Type", in_node, ref out_node) == false)
            {
                return false;
            }

            lis_status_list = out_node.GetList("STATUS_LIST");
            for (i = 0; i < lis_status_list.Count; i++)
            {
                i_row = spdStatus.ActiveSheet.RowCount;
                spdStatus.ActiveSheet.RowCount++;

                s_status_type = "";
                switch (lis_status_list[i].GetChar("STATUS_TYPE"))
                {
                    case 'U':
                        s_status_type = MPCF.FindLanguage("User Define", CAPTION_TYPE.LABEL);
                        break;
                    case 'A':
                        s_status_type = MPCF.FindLanguage("Attribute", CAPTION_TYPE.LABEL);
                        break;
                    case 'T':
                        s_status_type = MPCF.FindLanguage("Table-Column", CAPTION_TYPE.LABEL);
                        break;
                    case 'I':
                        s_status_type = MPCF.FindLanguage("Image", CAPTION_TYPE.LABEL);
                        break;
                    case 'F':
                        s_status_type = MPCF.FindLanguage("File", CAPTION_TYPE.LABEL);
                        break;
                }

                s_format = "";
                switch (lis_status_list[i].GetChar("ST_FORMAT"))
                {
                    case 'A':
                        s_format = "A : Ascii";
                        break;
                    case 'N':
                        s_format = "N : Number";
                        break;
                    case 'F':
                        s_format = "F : Float";
                        break;
                    case 'D':
                        s_format = "D : Date";
                        break;
                    case 'T':
                        s_format = "T : Time";
                        break;
                    case 'M':
                        s_format = "M : DateTime";
                        break;
                    case 'C':
                        s_format = "C : CheckBox";
                        break;
                    case '1':
                        s_format = "1 : Current Date";
                        break;
                    case '2':
                        s_format = "2 : Current Time";
                        break;
                    case '3':
                        s_format = "3 : Current DateTime";
                        break;
                    case '4':
                        s_format = "4 : Current Shift";
                        break;
                    case '5':
                        s_format = "5 : Login User ID";
                        break;
                    case '6':
                        s_format = "6 : Login User Desc";
                        break;
                    case '7':
                        s_format = "7 : Login Factory";
                        break;
                }

                spdStatus.ActiveSheet.Cells[i_row, 0].Value = s_status_type;
                spdStatus.ActiveSheet.Cells[i_row, 0].Tag = lis_status_list[i].GetChar("STATUS_TYPE");

                spdStatus.ActiveSheet.Cells[i_row, 1].Value = lis_status_list[i].GetString("STATUS");
                spdStatus.ActiveSheet.Cells[i_row, 2].Value = lis_status_list[i].GetString("STATUS_DESC");
                spdStatus.ActiveSheet.Cells[i_row, 3].Value = s_format;
                spdStatus.ActiveSheet.Cells[i_row, 4].Value = lis_status_list[i].GetInt("ST_SIZE");
                spdStatus.ActiveSheet.Cells[i_row, 5].Value = lis_status_list[i].GetString("DATA_1");
                spdStatus.ActiveSheet.Cells[i_row, 6].Value = lis_status_list[i].GetString("DATA_2");
                spdStatus.ActiveSheet.Cells[i_row, 7].Value = lis_status_list[i].GetString("DATA_3");
            }

            return true;
        }

        private bool ViewWorkProcessStep()
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_PROC_STEP_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_PROC_STEP_OUT");
            List<TRSNode> lis_list;
            int i;
            int i_row;
            int i_argb;
            int i_continue_icon;
            string s_status_type;
            string s_format;
            string s_input_type;

            TreeNode point_node;
            TreeNode action_node;

            ClearData(2);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(cdvProcType.Text));
            in_node.AddString("STEP_ID", MPCF.Trim(txtProcStep.Text));

            if (MPCR.CallService("WEM", "WEM_View_Process_Step", in_node, ref out_node) == false)
            {
                return false;
            }

            txtProcStep.Tag = out_node.GetString("STEP_ID");
            txtProcStepDesc.Text = out_node.GetString("STEP_DESC");
            cdvColSetID.Text = out_node.GetString("COL_SET_ID");
            cdvScreenID.Text = out_node.GetString("SCREEN_ID");

            lis_list = out_node.GetList("STATUS_LIST");
            for (i = 0; i < lis_list.Count; i++)
            {
                i_row = spdAStatus.ActiveSheet.RowCount;
                spdAStatus.ActiveSheet.RowCount++;

                s_status_type = "";
                switch (lis_list[i].GetChar("STATUS_TYPE"))
                {
                    case 'U':
                        s_status_type = MPCF.FindLanguage("User Define", CAPTION_TYPE.LABEL);
                        break;
                    case 'A':
                        s_status_type = MPCF.FindLanguage("Attribute", CAPTION_TYPE.LABEL);
                        break;
                    case 'T':
                        s_status_type = MPCF.FindLanguage("Table-Column", CAPTION_TYPE.LABEL);
                        break;
                    case 'I':
                        s_status_type = MPCF.FindLanguage("Image", CAPTION_TYPE.LABEL);
                        break;
                    case 'F':
                        s_status_type = MPCF.FindLanguage("File", CAPTION_TYPE.LABEL);
                        break;
                }

                s_format = "";
                switch (lis_list[i].GetChar("ST_FORMAT"))
                {
                    case 'A':
                        s_format = "A : Ascii";
                        break;
                    case 'N':
                        s_format = "N : Number";
                        break;
                    case 'F':
                        s_format = "F : Float";
                        break;
                    case 'D':
                        s_format = "D : Date";
                        break;
                    case 'T':
                        s_format = "T : Time";
                        break;
                    case 'M':
                        s_format = "M : DateTime";
                        break;
                    case 'C':
                        s_format = "C : CheckBox";
                        break;
                    case '1':
                        s_format = "1 : Current Date";
                        break;
                    case '2':
                        s_format = "2 : Current Time";
                        break;
                    case '3':
                        s_format = "3 : Current DateTime";
                        break;
                    case '4':
                        s_format = "4 : Current Shift";
                        break;
                    case '5':
                        s_format = "5 : Login User ID";
                        break;
                    case '6':
                        s_format = "6 : Login User Desc";
                        break;
                    case '7':
                        s_format = "7 : Login Factory";
                        break;
                }

                s_input_type = "";
                switch (lis_list[i].GetChar("INPUT_TYPE"))
                {
                    case 'V':
                        s_input_type = MPCF.FindLanguage("View", CAPTION_TYPE.LABEL);
                        break;
                    case 'I':
                        s_input_type = MPCF.FindLanguage("Input", CAPTION_TYPE.LABEL);
                        break;
                    case 'A':
                        s_input_type = MPCF.FindLanguage("View and Input", CAPTION_TYPE.LABEL);
                        break;
                }

                spdAStatus.ActiveSheet.Cells[i_row, 0].Value = s_status_type;
                spdAStatus.ActiveSheet.Cells[i_row, 1].Value = s_input_type;
                spdAStatus.ActiveSheet.Cells[i_row, 1].Tag = lis_list[i].GetChar("INPUT_TYPE");
                spdAStatus.ActiveSheet.Cells[i_row, 2].Value = lis_list[i].GetString("STATUS");
                spdAStatus.ActiveSheet.Cells[i_row, 3].Value = lis_list[i].GetString("STATUS_DESC");
                spdAStatus.ActiveSheet.Cells[i_row, 4].Value = s_format;
                spdAStatus.ActiveSheet.Cells[i_row, 5].Value = lis_list[i].GetInt("ST_SIZE");
                spdAStatus.ActiveSheet.Cells[i_row, 6].Value = lis_list[i].GetString("DATA_1");
                spdAStatus.ActiveSheet.Cells[i_row, 7].Value = lis_list[i].GetString("DATA_2");
                spdAStatus.ActiveSheet.Cells[i_row, 8].Value = lis_list[i].GetString("DATA_3");

                i_argb = lis_list[i].GetInt("BACK_COLOR");
                spdAStatus.ActiveSheet.Cells[i_row, 2].BackColor = Color.FromArgb(i_argb);
                if (spdAStatus.ActiveSheet.Cells[i_row, 2].BackColor.GetBrightness() < 0.5)
                {
                    spdAStatus.ActiveSheet.Cells[i_row, 2].ForeColor = Color.White;
                }
                if (lis_list[i].GetChar("REQUIRED_FLAG") == 'Y')
                {
                    spdAStatus.ActiveSheet.Cells[i_row, 2].Font = new Font(spdAStatus.Font.Name, spdAStatus.Font.Size, FontStyle.Bold);
                }

                for (int k = 0; k < spdStatus.ActiveSheet.RowCount; k++)
                {
                    if (MPCF.Trim(spdStatus.ActiveSheet.Cells[k, 1].Value) == lis_list[i].GetString("STATUS"))
                    {
                        spdStatus.ActiveSheet.Rows[k].ForeColor = Color.Blue;
                    }
                }
            }

            lis_list = out_node.GetList("ACTION_LIST");
            for (i = 0; i < lis_list.Count; i++)
            {
                point_node = null;
                switch (lis_list[i].GetChar("POINT_TYPE"))
                {
                    case 'I': point_node = tvAction.Nodes[0]; break;
                    case 'O': point_node = tvAction.Nodes[1]; break;
                }
                if (point_node == null) continue;

                if (lis_list[i].GetInt("ACT_DEPTH") > 1)
                {
                    point_node = FindTreeNode(point_node, lis_list[i].GetString("PARENT_PATH"));
                    if (point_node == null) continue;
                }

                i_continue_icon = (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE;
                switch (lis_list[i].GetChar("CONTINUE_TYPE"))
                {
                    case 'S': i_continue_icon = ICON_SUCCESS; break;
                    case 'F': i_continue_icon = ICON_FAIL; break;
                    case 'A': i_continue_icon = ICON_ALWAYS; break;
                }

                action_node = new TreeNode(lis_list[i].GetString("ACTION_ID") + " : " + lis_list[i].GetString("ACTION_DESC"), i_continue_icon, i_continue_icon);
                action_node.Tag = MPCF.Trim(point_node.Tag) + "/" + lis_list[i].GetString("ACTION_ID");

                if (point_node.Nodes.Count > 0)
                {
                    if (point_node.Nodes[point_node.Nodes.Count - 1].Text == "Attach New Action...")
                    {
                        point_node.Nodes.Insert(point_node.Nodes.Count - 1, action_node);
                    }
                    else
                    {
                        point_node.Nodes.Add(action_node);

                        action_node = new TreeNode("Attach New Action...", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE, (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
                        action_node.ForeColor = Color.Silver;
                        point_node.Nodes.Add(action_node);
                    }
                }
                else
                {
                    point_node.Nodes.Add(action_node);

                    action_node = new TreeNode("Attach New Action...", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE, (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
                    action_node.ForeColor = Color.Silver;
                    point_node.Nodes.Add(action_node);
                }

                i_row = MPCF.FindListItemIndex(lisActionList, lis_list[i].GetString("ACTION_ID"), false);
                if (i_row >= 0)
                {
                    lisActionList.Items[i_row].ForeColor = Color.Blue;
                }
            } 
            
            ls_deleted_status.Clear();

            return true;
        }

        private TreeNode FindTreeNode(TreeNode node, string s_parent_path)
        {
            TreeNode ret_node;
            if (MPCF.Trim(node.Tag) == s_parent_path)
            {
                return node;
            }

            foreach (TreeNode TNode in node.Nodes)
            {
                if (MPCF.Trim(node.Tag) == s_parent_path) return TNode;

                ret_node = FindTreeNode(TNode, s_parent_path);
                if (ret_node != null) return ret_node;
            }

            return null;
        }

        private bool UpdateWorkProcessStep(char c_proc_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_WORK_PROC_STEP_IN");
            TRSNode out_node = new TRSNode("UPDATE_WORK_PROC_STEP_OUT");
            ListViewItem itm;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;
                in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(cdvProcType.Text));
                in_node.AddString("STEP_ID", MPCF.Trim(txtProcStep.Text));
                in_node.AddString("STEP_DESC", MPCF.Trim(txtProcStepDesc.Text));
                in_node.AddString("COL_SET_ID", MPCF.Trim(cdvColSetID.Text));
                in_node.AddString("SCREEN_ID", MPCF.Trim(cdvScreenID.Text));

                UpdateWorkProcessStepAddStatus(in_node);
                UpdateWorkProcessStepAddAction(in_node);

                if (MPCR.CallService("WEM", "WEM_Update_Process_Step", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                ls_deleted_status.Clear();

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_proc_step == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisStepList.Items.Add(txtProcStep.Text, (int)SMALLICON_INDEX.IDX_VERSION_REQUEST);
                        itm.SubItems.Add(txtProcStepDesc.Text);
                        itm.Selected = true;
                        lisStepList.Sorting = SortOrder.Ascending;
                        lisStepList.Sort();
                        itm.EnsureVisible();
                    }
                    else if (c_proc_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisStepList, MPCF.Trim(txtProcStep.Text), false) == true)
                        {
                            lisStepList.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtProcStepDesc.Text);
                        }
                    }
                    else if (c_proc_step == MPGC.MP_STEP_DELETE)
                    {
                        i = MPCF.FindListItemIndex(lisStepList, MPCF.Trim(txtProcStep.Text), false);
                        if (i != -1)
                        {
                            lisStepList.Items[i].Remove();
                        }
                    }
                    lblDataCount.Text = lisStepList.Items.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private void UpdateWorkProcessStepAddStatus(TRSNode in_node)
        {
            TRSNode item_node;
            int i;

            if (MPCF.Trim(txtProcStep.Text) != MPCF.Trim(txtProcStep.Tag))
            {
                /* 기존 스텝정보를 유지한채 스텝아이디만 변경하여 새로운 스텝을 생성하는 경우 */
                ls_deleted_status.Clear();
                for (i = 0; i < spdAStatus.ActiveSheet.RowCount; i++)
                {
                    spdAStatus.ActiveSheet.Rows[i].Tag = 'A';
                }
            }

            for (i = 0; i < ls_deleted_status.Count; i++)
            {
                item_node = in_node.AddNode("STATUS_LIST");

                item_node.AddChar("DEL_FLAG", 'Y');
                item_node.AddString("STATUS", MPCF.Trim(ls_deleted_status[i]));
            }

            for (i = 0; i < spdAStatus.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdAStatus.ActiveSheet.Rows[i].Tag) != "")
                {
                    item_node = in_node.AddNode("STATUS_LIST");

                    item_node.AddString("STATUS", MPCF.Trim(spdAStatus.ActiveSheet.Cells[i, 2].Value));
                    item_node.AddChar("INPUT_TYPE", MPCF.ToChar(spdAStatus.ActiveSheet.Cells[i, 1].Tag));
                    item_node.AddInt("BACK_COLOR", spdAStatus.ActiveSheet.Cells[i, 2].BackColor.ToArgb());
                    item_node.AddChar("REQUIRED_FLAG", (spdAStatus.ActiveSheet.Cells[i, 2].Font != null && spdAStatus.ActiveSheet.Cells[i, 2].Font.Bold == true ? 'Y' : ' '));
                }
            }
        }

        private void UpdateWorkProcessStepAddAction(TRSNode in_node)
        {
            if (tvAction.Nodes[0].Nodes.Count > 0)
            {
                UpdateWorkProcessStepAddActionSub(in_node, tvAction.Nodes[0], 'I');
            }
            if (tvAction.Nodes[1].Nodes.Count > 0)
            {
                UpdateWorkProcessStepAddActionSub(in_node, tvAction.Nodes[1], 'O');
            }
        }

        private void UpdateWorkProcessStepAddActionSub(TRSNode in_node, TreeNode node, char c_point_type)
        {
            TRSNode item_node;
            string s_action_id;

            foreach(TreeNode anode in node.Nodes)
            {
                if (anode.Text == "Attach New Action...") continue;

                item_node = in_node.AddNode("ACTION_LIST");

                s_action_id = MPCF.Trim(MPCF.SubtractString(anode.Text, ":", false, false));
                item_node.AddString("ACTION_ID", s_action_id);
                item_node.AddChar("POINT_TYPE", c_point_type);
                item_node.AddInt("ACT_DEPTH", anode.Level);
                item_node.AddInt("ACT_SEQ", anode.Index);

                if(anode.ImageIndex == ICON_SUCCESS)
                {
                    item_node.AddChar("CONTINUE_TYPE", 'S');
                }
                else if (anode.ImageIndex == ICON_FAIL)
                {
                    item_node.AddChar("CONTINUE_TYPE", 'F');
                }
                else if (anode.ImageIndex == ICON_ALWAYS)
                {
                    item_node.AddChar("CONTINUE_TYPE", 'A');
                }
                
                if (anode.Level > 1)
                {
                    item_node.AddString("PARENT_PATH", MPCF.Trim(node.Tag));
                }

                if (anode.Nodes.Count > 0)
                {
                    UpdateWorkProcessStepAddActionSub(in_node, anode, c_point_type);
                }
            }
        }

        private bool CopyWorkProcessStep()
        {
            TRSNode in_node = new TRSNode("COPY_WORK_PROC_STEP_IN");
            TRSNode out_node = new TRSNode("COPY_WORK_PROC_STEP_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("WORK_PROC_TYPE", MPCF.Trim(cdvProcType.Text));
                in_node.AddString("STEP_ID", MPCF.Trim(txtProcStep.Text));
                in_node.AddString("TO_STEP_ID", MPCF.Trim(txtToStep.Text));

                if (MPCR.CallService("WEM", "WEM_Copy_Process_Step", in_node, ref out_node) == false)
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

        private void DetachAction(TreeNode node)
        {
            string s_action_id;
            int i_source_index;

            try
            {
                if (node.Text == "Attach New Action...") return;

                s_action_id = node.Text.Substring(0, node.Text.IndexOf(':'));

                i_source_index = MPCF.FindListItemIndex(lisActionList, s_action_id, false);
                if (i_source_index >= 0)
                {
                    lisActionList.Items[i_source_index].ForeColor = SystemColors.WindowText;
                }

                while (node.Nodes.Count > 1)
                {
                    DetachAction(node.Nodes[0]);
                }

                node.Remove();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void ClearData(int i_case)
        {
            switch (i_case)
            {
                case 1:
                    MPCF.InitListView(lisStepList);
                    MPCF.ClearList(spdStatus);
                    MPCF.ClearList(spdAStatus);
                    MPCF.InitTreeView(tvAction);

                    tvAction.Nodes.Add("IN", "Step IN", (int)SMALLICON_INDEX.IDX_MODULE, (int)SMALLICON_INDEX.IDX_MODULE);
                    tvAction.Nodes.Add("OUT", "Step OUT", (int)SMALLICON_INDEX.IDX_MODULE, (int)SMALLICON_INDEX.IDX_MODULE);
                    tvAction.Nodes[0].Nodes.Add("", "Attach New Action...", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE, (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
                    tvAction.Nodes[0].Nodes[0].ForeColor = Color.Silver;
                    tvAction.Nodes[0].ExpandAll();
                    tvAction.Nodes[1].Nodes.Add("", "Attach New Action...", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE, (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
                    tvAction.Nodes[1].Nodes[0].ForeColor = Color.Silver;
                    tvAction.Nodes[1].ExpandAll();
                    break;

                case 2:
                    for (int i = 0; i < spdStatus.ActiveSheet.RowCount; i++)
                    {
                        spdStatus.ActiveSheet.Rows[i].ForeColor = SystemColors.WindowText;
                    }
                    for (int i = 0; i < lisActionList.Items.Count; i++)
                    {
                        lisActionList.Items[i].ForeColor = SystemColors.WindowText;
                    }
                    
                    MPCF.ClearList(spdAStatus);
                    MPCF.InitTreeView(tvAction);

                    tvAction.Nodes.Add("IN", "Step IN", (int)SMALLICON_INDEX.IDX_MODULE, (int)SMALLICON_INDEX.IDX_MODULE);
                    tvAction.Nodes.Add("OUT", "Step OUT", (int)SMALLICON_INDEX.IDX_MODULE, (int)SMALLICON_INDEX.IDX_MODULE);
                    tvAction.Nodes[0].Nodes.Add("", "Attach New Action...", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE, (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
                    tvAction.Nodes[0].Nodes[0].ForeColor = Color.Silver;
                    tvAction.Nodes[0].ExpandAll();
                    tvAction.Nodes[1].Nodes.Add("", "Attach New Action...", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE, (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
                    tvAction.Nodes[1].Nodes[0].ForeColor = Color.Silver;
                    tvAction.Nodes[1].ExpandAll();

                    MPCF.FieldClear(tbpOption);
                    ls_deleted_status.Clear();
                    break;
            }
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.lisStepList;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion

        private void frmWEMSetupProcessStep_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData(1);
                ls_deleted_status = new List<string>();

                b_load_flag = true;
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisStepList, this.Text, "");
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvProcType, 1) == false) return;

                lblDataCount.Text = "";
                if (WEMLIST.ViewProcessStepList(lisStepList, cdvProcType.Text) == false)
                {
                    return;
                }
                lblDataCount.Text = lisStepList.Items.Count.ToString();
                if (lisStepList.Items.Count > 0)
                {
                    MPCF.FindListItem(lisStepList, txtProcStep.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisStepList, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisStepList, txtFind.Text, 0, true, false);
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
            if (cdvProcType.Text == "") return;

            btnRefresh.PerformClick();
            if (ViewWorkProcessType() == false) return;
            if (WEMLIST.ViewStepActionList(lisActionList, cdvProcType.Text) == false) return;

            ClearData(2);
            txtProcStep.Text = "";
            txtProcStep.Tag = "";
            txtProcStepDesc.Text = "";
        }

        private void lisStepList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisStepList.SelectedItems.Count < 1) return;

            txtProcStep.Text = lisStepList.SelectedItems[0].Text;
            if (ViewWorkProcessStep() == false) return;
        }

        private void spdStatus_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            char c_status_type = MPCF.ToChar(spdStatus.ActiveSheet.Cells[e.Row, 0].Tag);

            switch (c_status_type)
            {
                case 'U':
                    rbtInput.Enabled = true;
                    rbtView.Enabled = true;
                    rbtViewInput.Enabled = true;
                    break;
                case 'A':
                    rbtInput.Enabled = false;
                    rbtView.Enabled = true;
                    rbtView.Checked = true;
                    rbtViewInput.Enabled = false;
                    break;
                case 'T':
                    rbtInput.Enabled = false;
                    rbtView.Enabled = true;
                    rbtView.Checked = true;
                    rbtViewInput.Enabled = false;
                    break;
                case 'I':
                    rbtInput.Enabled = true;
                    rbtView.Enabled = true;
                    rbtViewInput.Enabled = true;
                    break;
                case 'F':
                    rbtInput.Enabled = true;
                    rbtView.Enabled = true;
                    rbtViewInput.Enabled = true;
                    break;
            }
        }

        private void txtBackColor_Click(object sender, EventArgs e)
        {
            if (cdgBackColor.ShowDialog(this) == DialogResult.Cancel) return;

            txtBackColor.BackColor = cdgBackColor.Color;
            if (txtBackColor.BackColor.GetBrightness() < 0.5)
            {
                txtBackColor.ForeColor = Color.White;
            }
            else
            {
                txtBackColor.ForeColor = Color.Black;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string s_input_type;
            char c_input_type;
            int i_row;
            int i_src_row;

            i_src_row = spdStatus.ActiveSheet.ActiveRowIndex;
            if (i_src_row < 0) return;

            s_input_type = "";
            c_input_type = ' ';
            if(rbtView.Checked == true)
            {
                s_input_type = MPCF.FindLanguage("View", CAPTION_TYPE.LABEL);
                c_input_type = 'V';
            }
            else if(rbtInput.Checked == true)
            {
                s_input_type = MPCF.FindLanguage("Input", CAPTION_TYPE.LABEL);
                c_input_type = 'I';
            }
            else if (rbtViewInput.Checked == true)
            {
                s_input_type = MPCF.FindLanguage("View and Input", CAPTION_TYPE.LABEL);
                c_input_type = 'A';
            }
            if (s_input_type == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                rbtView.Focus();
                return;
            }

            for (i_row = 0; i_row < spdAStatus.ActiveSheet.RowCount; i_row++)
            {
                if (MPCF.Trim(spdAStatus.ActiveSheet.Cells[i_row, 2].Value) == MPCF.Trim(spdStatus.ActiveSheet.Cells[i_src_row, 1].Value))
                {
                    return;
                }
            }

            i_row = spdAStatus.ActiveSheet.RowCount;
            spdAStatus.ActiveSheet.RowCount++;

            spdAStatus.ActiveSheet.Cells[i_row, 0].Value = spdStatus.ActiveSheet.Cells[i_src_row, 0].Value; //status type
            spdAStatus.ActiveSheet.Cells[i_row, 1].Value = s_input_type;
            spdAStatus.ActiveSheet.Cells[i_row, 1].Tag = c_input_type;
            spdAStatus.ActiveSheet.Cells[i_row, 2].Value = spdStatus.ActiveSheet.Cells[i_src_row, 1].Value; //status
            spdAStatus.ActiveSheet.Cells[i_row, 3].Value = spdStatus.ActiveSheet.Cells[i_src_row, 2].Value; //status desc
            spdAStatus.ActiveSheet.Cells[i_row, 4].Value = spdStatus.ActiveSheet.Cells[i_src_row, 3].Value; //format
            spdAStatus.ActiveSheet.Cells[i_row, 5].Value = spdStatus.ActiveSheet.Cells[i_src_row, 4].Value; //size
            spdAStatus.ActiveSheet.Cells[i_row, 6].Value = spdStatus.ActiveSheet.Cells[i_src_row, 5].Value; //data1
            spdAStatus.ActiveSheet.Cells[i_row, 7].Value = spdStatus.ActiveSheet.Cells[i_src_row, 6].Value; //data2
            spdAStatus.ActiveSheet.Cells[i_row, 8].Value = spdStatus.ActiveSheet.Cells[i_src_row, 7].Value; //data3

            spdAStatus.ActiveSheet.Cells[i_row, 2].BackColor = txtBackColor.BackColor;
            if (spdAStatus.ActiveSheet.Cells[i_row, 2].BackColor.GetBrightness() < 0.5)
            {
                spdAStatus.ActiveSheet.Cells[i_row, 2].ForeColor = Color.White;
            }
            if (chkRequireFlag.Checked == true)
            {
                spdAStatus.ActiveSheet.Cells[i_row, 2].Font = new Font(spdAStatus.Font.Name, spdAStatus.Font.Size, FontStyle.Bold);
            }
            spdAStatus.ActiveSheet.Rows[i_row].Tag = 'A';

            spdStatus.ActiveSheet.Rows[i_src_row].ForeColor = Color.Blue;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int i_row = spdAStatus.ActiveSheet.ActiveRowIndex;
            if (i_row < 0) return;

            string s_status;
            s_status = MPCF.Trim(spdAStatus.ActiveSheet.Cells[i_row, 2].Value);

            if (MPCF.Trim(spdAStatus.ActiveSheet.Rows[i_row].Tag) != "A")
            {
                ls_deleted_status.Add(s_status);
            }
            spdAStatus.ActiveSheet.Rows[i_row].Remove();

            for (i_row = 0; i_row < spdStatus.ActiveSheet.RowCount; i_row++)
            {
                if (s_status == MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 1].Value))
                {
                    spdStatus.ActiveSheet.Rows[i_row].ForeColor = SystemColors.WindowText;
                    break;
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (spdAStatus.ActiveSheet.ActiveRowIndex < 0) return;

            string s_input_type;
            char c_input_type;
            int i_row;

            s_input_type = "";
            c_input_type = ' ';
            if (rbtView.Checked == true)
            {
                s_input_type = MPCF.FindLanguage("View", CAPTION_TYPE.LABEL);
                c_input_type = 'V';
            }
            else if (rbtInput.Checked == true)
            {
                s_input_type = MPCF.FindLanguage("Input", CAPTION_TYPE.LABEL);
                c_input_type = 'I';
            }
            else if (rbtViewInput.Checked == true)
            {
                s_input_type = MPCF.FindLanguage("View and Input", CAPTION_TYPE.LABEL);
                c_input_type = 'A';
            }
            if (s_input_type == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                rbtView.Focus();
                return;
            }

            i_row = spdAStatus.ActiveSheet.ActiveRowIndex;

            spdAStatus.ActiveSheet.Cells[i_row, 1].Value = s_input_type;
            spdAStatus.ActiveSheet.Cells[i_row, 1].Tag = c_input_type;
            spdAStatus.ActiveSheet.Cells[i_row, 2].BackColor = txtBackColor.BackColor;
            if (spdAStatus.ActiveSheet.Cells[i_row, 2].BackColor.GetBrightness() < 0.5)
            {
                spdAStatus.ActiveSheet.Cells[i_row, 2].ForeColor = Color.White;
            }
            if (chkRequireFlag.Checked == true)
            {
                spdAStatus.ActiveSheet.Cells[i_row, 2].Font = new Font(spdAStatus.Font.Name, spdAStatus.Font.Size, FontStyle.Bold);
            }
            else
            {
                spdAStatus.ActiveSheet.Cells[i_row, 2].Font = new Font(spdAStatus.Font.Name, spdAStatus.Font.Size, FontStyle.Regular);
            }

            spdAStatus.ActiveSheet.Rows[i_row].Tag = 'A';
        }

        private void spdAStatus_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Row < 0) return;

            switch (MPCF.Trim(spdAStatus.ActiveSheet.Cells[e.Row, 1].Tag))
            {
                case "V": rbtView.Checked = true; break;
                case "I": rbtInput.Checked = true; break;
                case "A": rbtViewInput.Checked = true; break;
            }
            txtBackColor.BackColor = spdAStatus.ActiveSheet.Cells[e.Row, 2].BackColor;
            if (txtBackColor.BackColor.GetBrightness() < 0.5)
            {
                txtBackColor.ForeColor = Color.White;
            }

            chkRequireFlag.Checked = false;
            if (spdAStatus.ActiveSheet.Cells[e.Row, 2].Font != null && spdAStatus.ActiveSheet.Cells[e.Row, 2].Font.Bold == true)
            {
                chkRequireFlag.Checked = true;
            }
        }

        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_attach_index;
            int i_continue_icon;
            TreeNode node;
            string s_select_action;
            bool b_already_attached;

            if (tvAction.SelectedNode == null) return;
            if (tvAction.SelectedNode.Parent == null) return;

            try
            {
                for (i = 0; i < lisActionList.SelectedItems.Count; i++)
                {
                    s_select_action = MPCF.Trim(lisActionList.SelectedItems[i].SubItems[0].Text) + " : " + MPCF.Trim(lisActionList.SelectedItems[i].SubItems[1].Text);
                    b_already_attached = false;

                    foreach (TreeNode TNode in tvAction.SelectedNode.Parent.Nodes)
                    {
                        if (TNode.Text == s_select_action)
                        {
                            b_already_attached = true;
                            break;
                        }
                    }
                    if (b_already_attached == true) continue;

                    if (tvAction.SelectedNode.Level == 1)
                    {
                        cboContinueAction.SelectedIndex = -1;
                    }
                    else
                    {
                        if (MPCF.CheckValue(cboContinueAction, 1) == false) return;
                    }

                    i_continue_icon = (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE;
                    switch (cboContinueAction.SelectedIndex)
                    {
                        case 0: i_continue_icon = ICON_SUCCESS; break;
                        case 1: i_continue_icon = ICON_FAIL; break;
                        case 2: i_continue_icon = ICON_ALWAYS; break;
                    }

                    i_attach_index = tvAction.SelectedNode.Index;

                    node = new TreeNode(s_select_action, i_continue_icon, i_continue_icon);
                    node.Tag = MPCF.Trim(tvAction.SelectedNode.Parent.Tag) + "/" + MPCF.Trim(lisActionList.SelectedItems[i].SubItems[0].Text);

                    tvAction.SelectedNode.Parent.Nodes.Insert(i_attach_index, node);

                    lisActionList.SelectedItems[i].ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            TreeNode node;

            if (tvAction.SelectedNode == null) return;
            if (tvAction.SelectedNode.Parent == null) return;

            try
            {
                for (i = 0; i < tvAction.SelectedNodes.Count; i++)
                {
                    node = (TreeNode)tvAction.SelectedNodes[i];
                    DetachAction(node);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            int i;
            int i_add_action;
            int i_continue_icon;
            TreeNode node;
            string s_select_action;
            bool b_insert_item;
            bool b_already_attached;

            if (tvAction.SelectedNode == null) return;
            if (tvAction.SelectedNode.Parent == null) return;
            if (MPCF.CheckValue(cboContinueAction, 1) == false) return;

            try
            {
                if (tvAction.SelectedNode.Text == "Attach New Action...") return;

                i_add_action = 0;
                b_insert_item = false;

                if (tvAction.SelectedNode.Nodes.Count > 1)
                {
                    b_insert_item = true;
                }

                for (i = 0; i < lisActionList.SelectedItems.Count; i++)
                {
                    s_select_action = MPCF.Trim(lisActionList.SelectedItems[i].SubItems[0].Text) + " : " + MPCF.Trim(lisActionList.SelectedItems[i].SubItems[1].Text);

                    b_already_attached = false;

                    foreach (TreeNode TNode in tvAction.SelectedNode.Nodes)
                    {
                        if (TNode.Text == s_select_action)
                        {
                            b_already_attached = true;
                            break;
                        }
                    }
                    if (b_already_attached == true) continue;

                    i_continue_icon = (int)SMALLICON_INDEX.IDX_VERSION_ACTIVATE;
                    switch (cboContinueAction.SelectedIndex)
                    {
                        case 0: i_continue_icon = ICON_SUCCESS; break;
                        case 1: i_continue_icon = ICON_FAIL; break;
                        case 2: i_continue_icon = ICON_ALWAYS; break;
                    }

                    node = new TreeNode(s_select_action, i_continue_icon, i_continue_icon);
                    node.Tag = MPCF.Trim(tvAction.SelectedNode.Tag) + "/" + MPCF.Trim(lisActionList.SelectedItems[i].SubItems[0].Text);

                    if (b_insert_item == true)
                    {
                        tvAction.SelectedNode.Nodes.Insert(tvAction.SelectedNode.Nodes.Count - 1, node);
                    }
                    else
                    {
                        tvAction.SelectedNode.Nodes.Add(node);
                    }

                    i_add_action++;

                    lisActionList.SelectedItems[i].ForeColor = Color.Blue;
                }

                if (i_add_action > 0 && b_insert_item == false)
                {
                    node = new TreeNode("Attach New Action...", (int)SMALLICON_INDEX.IDX_WHITE_IMAGE, (int)SMALLICON_INDEX.IDX_WHITE_IMAGE);
                    node.ForeColor = Color.Silver;
                    tvAction.SelectedNode.Nodes.Add(node);
                    tvAction.SelectedNode.Expand();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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

            if (tvAction.Nodes.Count > 0)
            {
                tvAction.Nodes[0].Expand();
                tvAction.Nodes[1].Expand();

                tvAction.Nodes[0].EnsureVisible();
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

            if (tvAction.Nodes.Count > 0)
            {
                tvAction.Nodes[0].EnsureVisible();
            }
        }

        private void btnActionUp_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_prev_index;
            TreeNode tn_parent;
            TreeNode tn_temp;
            TreeNode tn_curr;
            ArrayList al_selected_nodes;
            ArrayList al_new_selected_nodes;

            if (tvAction.SelectedNodes.Count < 1) return;
            for (i = 0; i < tvAction.SelectedNodes.Count; i++)
            {
                if (((TreeNode)tvAction.SelectedNodes[i]).Parent == null) return;
            }

            try
            {
                al_new_selected_nodes = new ArrayList();
                al_selected_nodes = (ArrayList)tvAction.SelectedNodes.Clone();
                al_selected_nodes.Sort(new TreeNodeComparer(true));

                for (i = 0; i < al_selected_nodes.Count; i++)
                {
                    tn_curr = (TreeNode)(al_selected_nodes[i]);
                    if (tn_curr.Text == "Attach New Action...") continue;

                    tn_parent = tn_curr.Parent;
                    tn_temp = tn_parent.FirstNode;

                    if (tn_curr != tn_temp)
                    {
                        if (al_selected_nodes.Contains(tn_curr.PrevNode) == false)
                        {
                            tn_temp = (TreeNode)tn_curr.Clone();

                            i_prev_index = tn_curr.PrevNode.Index;
                            tn_parent.Nodes.Insert(i_prev_index, tn_temp);
                            tn_parent.Nodes.Remove(tn_curr);
                        }
                    }

                    if (al_new_selected_nodes.Contains(tn_temp) == false)
                    {
                        tn_temp.ForeColor = Color.Black;
                        tn_temp.BackColor = Color.White;

                        al_new_selected_nodes.Add(tn_temp);
                    }
                }

                if (al_new_selected_nodes.Count > 0)
                {
                    tvAction.SelectedNode = null;
                    tvAction.SelectedNodes = al_new_selected_nodes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActionDown_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int i_next_index;
            TreeNode tn_parent;
            TreeNode tn_temp;
            TreeNode tn_curr;
            ArrayList al_selected_nodes;
            ArrayList al_new_selected_nodes;

            if (tvAction.SelectedNodes.Count < 1) return;
            for (i = 0; i < tvAction.SelectedNodes.Count; i++)
            {
                if (((TreeNode)tvAction.SelectedNodes[i]).Parent == null) return;
            }

            try
            {
                al_new_selected_nodes = new ArrayList();
                al_selected_nodes = (ArrayList)tvAction.SelectedNodes.Clone();
                al_selected_nodes.Sort(new TreeNodeComparer(false));

                for (i = 0; i < al_selected_nodes.Count; i++)
                {
                    tn_curr = (TreeNode)(al_selected_nodes[i]);
                    if (tn_curr.Text == "Attach New Action...") continue;

                    tn_parent = tn_curr.Parent;
                    tn_temp = tn_parent.LastNode.PrevNode;

                    if (tn_curr != tn_temp)
                    {
                        if (al_selected_nodes.Contains(tn_curr.NextNode) == false)
                        {
                            tn_temp = (TreeNode)tn_curr.Clone();

                            i_next_index = tn_curr.NextNode.Index + 1;
                            tn_parent.Nodes.Insert(i_next_index, tn_temp);
                            tn_parent.Nodes.Remove(tn_curr);
                        }
                    }

                    if (al_new_selected_nodes.Contains(tn_temp) == false)
                    {
                        tn_temp.ForeColor = Color.Black;
                        tn_temp.BackColor = Color.White;

                        al_new_selected_nodes.Add(tn_temp);
                    }
                }

                if (al_new_selected_nodes.Count > 0)
                {
                    tvAction.SelectedNode = null;
                    tvAction.SelectedNodes = al_new_selected_nodes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbpAction_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(tbpAction, pnlActionLeft, pnlActionRight, pnlActionArrow, 34);
        }

        private void cdvScreenID_ButtonPress(object sender, EventArgs e)
        {
            cdvScreenID.Init();
            MPCF.InitListView(cdvScreenID.GetListView);
            cdvScreenID.Columns.Add("Screen ID", 150, HorizontalAlignment.Left);
            cdvScreenID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvScreenID.SelectedSubItemIndex = 0;
            BASLIST.ViewScreenList(cdvScreenID.GetListView, '1', "", MPGV.gsFactory, null, "", false);
        }

        private void cdvColSetID_ButtonPress(object sender, EventArgs e)
        {
            cdvColSetID.Init();
            MPCF.InitListView(cdvColSetID.GetListView);
            cdvColSetID.Columns.Add("Collection Set", 50, HorizontalAlignment.Left);
            cdvColSetID.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvColSetID.SelectedSubItemIndex = 0;
            if (EDCLIST.ViewEDCColSetList(cdvColSetID.GetListView, '1', null, "", -1, -1, ' ', false) == false) return;
            cdvColSetID.InsertEmptyRow(0, 1);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;
            if (UpdateWorkProcessStep(MPGC.MP_STEP_CREATE) == false) return;

            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;
            if (UpdateWorkProcessStep(MPGC.MP_STEP_UPDATE) == false) return;

            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;
            if (UpdateWorkProcessStep(MPGC.MP_STEP_DELETE) == false) return;

            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }

            ClearData(2);
            txtProcStep.Text = "";
            txtProcStep.Tag = "";
            txtProcStepDesc.Text = "";
        }

        private void btnCopyStep_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtProcStep, 1) == false) return;
            if (MPCF.CheckValue(txtToStep, 1) == false)
            {
                tabStepRelation.SelectedTab = tbpCopyStep;
                txtToStep.Focus();
                return;
            }

            if (CopyWorkProcessStep() == false) return;

            if (MPGV.gbListAutoRefresh == true)
            {
                btnRefresh.PerformClick();
            }
        }




    }

    public class TreeNodeComparer : IComparer
    {
        private bool is_ascending;

        public TreeNodeComparer(bool isAscending)
        {
            is_ascending = isAscending;
        }

        public int Compare(object x, object y)
        {
            string sTextX;
            string sTextY;
            int i_result;

            try
            {
                sTextX = ((TreeNode)x).Level.ToString("00000") + ((TreeNode)x).Index.ToString("00000");
                sTextY = ((TreeNode)y).Level.ToString("00000") + ((TreeNode)y).Index.ToString("00000");

                i_result = sTextX.CompareTo(sTextY);
                return (is_ascending ? i_result : i_result * -1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Compare Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
    }

}
