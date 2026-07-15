//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupAttachQARule.cs
//   Description : Attach QA Rule to MFO
//
//   MES Version : 4.2.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2007-08-28 : Created by Aiden
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

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupAttachQARule : Miracom.MESCore.SetupForm02
    {
        public frmWIPSetupAttachQARule()
        {
            InitializeComponent();
        }

        #region " Constant Definition "
        #endregion

        #region " Variable Definition "
        #endregion

        #region " Function Definition "

        // SelectClear()
        //       - Clear Selected Items
        // Return Value
        //       -
        // Arguments
        //       - ByVal list As ListView : ListView
        //
        private void SelectClear(ListView list)
        {
            int i;
            for (i = 0; i <= list.Items.Count - 1; i++)
            {
                list.Items[i].Selected = false;
            }
        }

        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(char ProcStep)
        {
            if (tvMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Oper)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                tvMFO.Focus();
                return false;
            }

            switch (ProcStep)
            {
                case '1':

                    if (lisQARuleList.SelectedItems.Count <= 0)
                    {
                        if (lisQARuleList.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisQARuleList.Items[0].Selected = true;
                            lisQARuleList.Focus();
                        }
                        return false;
                    }
                    break;
                case '2':

                    if (lisQARule.SelectedItems.Count <= 0)
                    {
                        if (lisQARule.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisQARule.Items[0].Selected = true;
                            lisQARule.Focus();
                        }
                        return false;
                    }
                    break;
            }
            return true;
        }

        // UpdateResourceGroupRelation()
        //       - Create/Update/Delete Resource - Group Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - char c_step           : Process Step
        //       - string s_group       : Resource group id
        //       - string s_res         : Resource ID
        //
        private bool UpdateMFOQARuleRel(char c_step, string s_rule_id)
        {
            TRSNode in_node = new TRSNode("UPDATE_MFO_QA_RULE_IN");
            TRSNode out_node = new TRSNode("UPDATE_MFO_QA_RULE_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("MAT_ID", tvMFO.MatID);
                in_node.AddInt("MAT_VER", tvMFO.MatVersion);
                in_node.AddString("FLOW", tvMFO.Flow);
                in_node.AddInt("FLOW_SEQ", tvMFO.FlowSeqNum);
                in_node.AddString("OPER", tvMFO.Oper);
                in_node.AddString("RES_ID", "");
                in_node.AddString("SUB_RES_ID", "");
                in_node.AddString("REL_TYPE", cdvType.Text);
                in_node.AddString("RULE_ID", s_rule_id);

                if (MPCR.CallService("WIP", "WIP_Update_MFO_QA_Rule", in_node, ref out_node) == false)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        // ViewSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewSettingDataList()
        {
            TRSNode in_node = new TRSNode("WIP_GET_OR_SET_GCM_LOT_MAX_SEQ_IN");
            TRSNode out_node = new TRSNode("WIP_GET_OR_SET_GCM_LOT_MAX_SEQ_OUT");

            MPCR.SetInMsg(in_node);
            StringBuilder sb;

            MPCF.InitListView(tvMFO.GetListView);

            sb = new StringBuilder();

            switch (tvMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER FROM MQCGMFOREL ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT MAT_ID, MAT_VER, OPER FROM MRASRESMFO ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT FLOW, OPER FROM MRASRESMFO ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT OPER FROM MRASRESMFO ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY OPER ");
                    sb.Append("ORDER BY OPER ASC");
                    break;
            }

            in_node.SetString("SQL",sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(tvMFO.GetListView,out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (out_node.GetInt("NEXT_ROW") != 0);

            lblDataCount.Text = tvMFO.GetListView.Items.Count.ToString();

            return true;
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

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            tvMFO.RefreshSelectedList();
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            tvMFO.GetNext(txtFind.Text);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(tvMFO.GetListView, this.Text, "");
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
            {
                btnNext_Click(null, null);
            }
        }

        private void pnlGrpMid_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(pnlGrpMid, pnlGrpMidLeft, pnlGrpMidRight, pnlGrpMidMid, 40);
        }

        private void tvMFO_LevelItemSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (QCMLIST.ViewMFOQARuleList(lisQARule, '1', cdvType.Text, "", tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow,tvMFO.FlowSeqNum, tvMFO.Oper, "", "") == false) return;
        } // 선택 Level의 말단 노드가 선택되었을 때

        private void tvMFO_GetedTreeList(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.GetTreeView.GetNodeCount(false));
        }

        private void tvMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.SelectedNode.GetNodeCount(false));
        }

        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            string s_group;
            ListViewItem itmX;
            string[] s_select = null;
            int i;
            int j;
            int i_idx = 0;

            s_select = new string[lisQARuleList.SelectedItems.Count];
            SelectClear(lisQARule);

            if (CheckCondition('1') == false) return;

            for (i = 0; i <= lisQARuleList.SelectedItems.Count - 1; i++)
            {
                s_group = lisQARuleList.SelectedItems[i].Text;
                if (MPCF.FindListItem(lisQARule, s_group, false) == false)
                {
                    if (UpdateMFOQARuleRel(MPGC.MP_STEP_CREATE,lisQARuleList.SelectedItems[0].Text) == true)
                    {
                        s_select[i] = s_group;
                        itmX = lisQARule.Items.Add(s_group, (int)SMALLICON_INDEX.IDX_RESOURCE_GROUP);
                        itmX.SubItems.Add(lisQARuleList.SelectedItems[i].SubItems[1].Text);
                        i_idx = lisQARuleList.SelectedItems[i].Index;
                    }
                    else
                    {
                        for (j = 0; j <= s_select.Length - 1; j++)
                        {
                            MPCF.FindListItem(lisQARule, s_select[j], false);
                        }
                        SelectClear(lisQARuleList);
                        return;
                    }
                }
                else
                {
                    s_select[i] = s_group;
                    i_idx = lisQARuleList.SelectedItems[i].Index;
                }
            }

            SelectClear(lisQARuleList);

            if (s_select.Length == 1)
            {
                if (i_idx < lisQARuleList.Items.Count - 1)
                {
                    lisQARuleList.Items[i_idx + 1].Selected = true;
                }
            }

            for (i = 0; i <= s_select.Length - 1; i++)
            {
                MPCF.FindListItem(lisQARule, s_select[i], false);
            }
        }

        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            string s_group;
            int i_idx = 0;
            int i;
            int i_count;

            if (CheckCondition('2') == false) return;

            i_count = lisQARule.SelectedItems.Count;
            SelectClear(lisQARuleList);

            for (i = lisQARule.SelectedItems.Count - 1; i >= 0; i--)
            {
                s_group = lisQARule.SelectedItems[i].Text;
                if (UpdateMFOQARuleRel(MPGC.MP_STEP_DELETE, lisQARule.SelectedItems[0].Text) == true)
                {
                    i_idx = lisQARule.SelectedItems[i].Index;
                    lisQARule.Items.RemoveAt(i_idx);
                    MPCF.FindListItem(lisQARuleList, s_group, false);
                }
            } 
            if (i_count == 1)
            {
                if (i_idx < lisQARule.Items.Count)
                {
                    lisQARule.Items[i_idx].Selected = true;
                }
            }
        }

        private void lisQARule1_DragEnter(System.Object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void tabOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewSettingDataList();
        }

        private void tvMFO_GettingOnlySettingData(object sender, EventArgs e)
        {
            ViewSettingDataList(); 
        }
        
        private void tvMFO_SettingDataSelectedIndexChanged(object sender, EventArgs e)
        {
            if ( QCMLIST.ViewMFOQARuleList(lisQARule, '1', cdvType.Text, "", tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.FlowSeqNum, tvMFO.Oper, "", "") == false) return;
        }

        private void cdvType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvType.Text) != "")
            {
                if (QCMLIST.ViewQARuleList(lisQARuleList, '1', cdvType.Text, "") == false)
                    return;
                if (QCMLIST.ViewMFOQARuleList(lisQARule, '1', cdvType.Text, "", tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.FlowSeqNum, tvMFO.Oper, "", "") == false) 
                    return;
            }
        }

        private void cdvType_ButtonPress(object sender, EventArgs e)
        {
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Sample Size Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvType.GetListView, '1', MPGC.TAP_QA_RULE_TYPE) == false)
            {
                return;
            }
        }

        private void tvMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewSettingDataList();
        }

        private void tvMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            if (QCMLIST.ViewMFOQARuleList(lisQARule, '1', cdvType.Text, "", tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.FlowSeqNum, tvMFO.Oper, "", "") == false) return;
        }

        private void frmWIPSetupAttachQARule_Load(object sender, EventArgs e)
        {
            MPCF.InitListView(lisQARuleList);
            MPCF.InitListView(lisQARule);

            pnlGrpMid_Resize(null, null);

            btnCreate.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }

        private void lisQARule_Click(object sender, EventArgs e)
        {
            SelectClear(lisQARuleList);
        }

        private void lisQARule_DragDrop(object sender, DragEventArgs e)
        {
            btnAdd_Click(null, null);
        }

        private void lisQARule_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lisQARule.DoDragDrop(lisQARule.SelectedItems[0].Text, DragDropEffects.Move);
        }

        private void lisQARule_MouseDown(object sender, MouseEventArgs e)
        {
            lisQARule.AllowDrop = false;
            lisQARuleList.AllowDrop = true;
        }

        private void lisQARuleList_Click(object sender, EventArgs e)
        {
            SelectClear(lisQARule);
        }

        private void lisQARuleList_DragDrop(object sender, DragEventArgs e)
        {
            btnDel_Click(null, null);
        }

        private void lisQARuleList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lisQARuleList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lisQARuleList.DoDragDrop(lisQARuleList.SelectedItems[0].Text, DragDropEffects.Copy);
        }

        private void lisQARuleList_MouseDown(object sender, MouseEventArgs e)
        {
            lisQARuleList.AllowDrop = false;
            lisQARule.AllowDrop = true;
        }
    }
}

