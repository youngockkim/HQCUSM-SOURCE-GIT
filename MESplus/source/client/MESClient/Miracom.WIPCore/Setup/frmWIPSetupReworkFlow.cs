//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupReworkFlow.vb
//   Description : Rework Flow Setup
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - GetMFOMatIDList() : Get Material List in M-F-O Tab
//       - GetFOFlowList() : Get Flow List in F-O Tab
//       - GetMFOFlowList() : Get Flow List by Material in M-F-O Tab
//       - GetSPOperList() : Get Operation List by Flow
//       - ViewReworkFlowList() : Get Rework Flow List
//       - UpdateReworkFlow() : Update Rework Flow
//       - SetSelectData() : Set Variable by Selected Row
//       - GetSelectData() : Get Variable by Selected Row
//       - FindTopRow() : ?ÑÏû¨ ?†ÌÉù??RowÎ•??¨Ìï®?òÎäî OperationÎ•?Í∞ÄÏß?RowÎ•?Ï∞æÎäî??
//       - FindOper() : ?ÑÏû¨ ?†ÌÉù??RowÎ•??¨Ìï®?òÎäî OperationÎ•?Ï∞æÎäî??
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2007-08-24 : Created by Aiden
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
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

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupReworkFlow : Miracom.MESCore.SetupForm02
    {

#region " Constant Definition "
#endregion

#region " Variable Definition "
#endregion

#region " Function Definition "

        public frmWIPSetupReworkFlow()
        {
            InitializeComponent();
        }

        // GetOperationReworkTable()
        //       -  Get Operation Loss Code Table
        // Return Value
        //       - String : Loss Code Table
        // Arguments
        //       -
        private string GetOperationReworkTable(string s_oper)
        {
            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", MPCF.Trim(s_oper));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return "";
            }

            return MPCF.Trim(out_node.GetString("REWORK_TBL"));
        }

        //

        // GetReworkCodeList()
        //       - Get Code List by Operation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool GetReworkCodeList(TreeNode node, string s_oper)
        {
            string s_rework_tbl;
            s_rework_tbl = GetOperationReworkTable(s_oper);

            if (s_rework_tbl != "")
            {
                node.Nodes.Add(new TreeNode("                    ", ((int)SMALLICON_INDEX.IDX_CODE_DATA), ((int)SMALLICON_INDEX.IDX_CODE_DATA)));

                if (BASLIST.ViewGCMDataList(tvMFO.GetTreeView, '1', s_rework_tbl, -1, node, "") == false)
                {
                    return false;
                }
            }

            return true;
        }
        
        //
        // ViewReworkFlowList()
        //       - Get Rework Flow List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal spdList As FarPoint.Win.Spread.SheetView : SpreadSheet
        //       - ByVal iRow As Integer : Parent Row of Selected Row
        //       - ByVal sOptLevel As String : Option Level
        //       - ByVal sMaterial As String : Material
        //       - ByVal sFlow As String : Flow
        //       - ByVal sOper As String : Operation
        //
        private bool ViewReworkFlowList(string s_rework_code)
        {
            TRSNode in_node = new TRSNode("VIEW_REWORK_FLOW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REWORK_FLOW_LIST_OUT");

            int i;
            ListViewItem itm;

            MPCF.InitListView(lisRwkList);
            MPCF.FieldClear(grpRwkInfo);
            MPCF.FieldClear(grpRetInfo);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddChar("OPT_LEVEL", tvMFO.SelectLevelChar);
            in_node.AddString("MAT_ID", MPCF.Trim(tvMFO.MatID));
            in_node.AddInt("MAT_VER", tvMFO.MatVersion);
            in_node.AddString("FLOW", MPCF.Trim(tvMFO.Flow));
            in_node.AddString("OPER", MPCF.Trim(tvMFO.Oper));
            in_node.AddString("RWK_CODE", MPCF.Trim(s_rework_code));

            if (MPCR.CallService("WIP", "WIP_View_Rework_Flow_List", in_node, ref out_node) == false)
            {
                return false;
            }

            txtReworkCode.Text = MPCF.Trim(s_rework_code);

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                itm = new ListViewItem(out_node.GetList(0)[i].GetString("RWK_FLOW"), (int)SMALLICON_INDEX.IDX_REWORK_FLOW);
                itm.SubItems.Add(out_node.GetList(0)[i].GetInt("RWK_FLOW_SEQ_NUM").ToString());
                itm.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_OPER"));
                itm.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_STOP_OPER"));
                itm.SubItems.Add(out_node.GetList(0)[i].GetString("RET_FLOW"));
                itm.SubItems.Add(out_node.GetList(0)[i].GetInt("RET_FLOW_SEQ_NUM").ToString());
                itm.SubItems.Add(out_node.GetList(0)[i].GetString("RET_OPER"));

                switch (out_node.GetList(0)[i].GetChar("RET_CLEAR_FLAG"))
                {
                    case 'Y': // Clear Rework
                        itm.SubItems.Add("Clear Rework");
                        itm.SubItems[7].Tag = 'Y';
                        break;
                    case 'A': // Clear Rework and Move to Next Oper
                        itm.SubItems.Add("Clear Rework and Move to Next Operation");
                        itm.SubItems[7].Tag = 'A';
                        break;
                    case 'B': // Keep Rework and Move to Next Oper
                        itm.SubItems.Add("Keep Rework and Move to Next Operation");
                        itm.SubItems[7].Tag = 'B';
                        break;
                    default: // keep Rework
                        itm.SubItems.Add("keep Rework");
                        itm.SubItems[7].Tag = ' ';
                        break;
                }

                lisRwkList.Items.Add(itm);
            }

            return true;
        }



        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool CheckCondition()
        {
            if (tvMFO.OnlySetDataList == false)
            {
                if (tvMFO.SelectedItem != Miracom.MESCore.Controls.TreeSelectedItem.Another)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(249));
                    tvMFO.Focus();
                    return false;
                }
            }
            //if (cdvReworkFlow.Text == "")
            //{
            //    MPCF.ShowMsgBox(MPCF.GetMessage(108));
            //    cdvReworkFlow.Focus();
            //    return false;
            //}
            if (cdvReworkOper.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvReworkOper.Focus();
                return false;
            }
            // Local Rework ¿Ã ∞°¥…«œπ«∑Œ √º≈©«œ¡ˆ æ µµ∑œ «‘.
            //if (tvMFO.Flow == MPCF.Trim(cdvReworkFlow.Text) && tvMFO.Oper == MPCF.Trim(cdvReworkOper.Text))
            //{
            //    MPCF.ShowMsgBox(MPCF.GetMessage(183));
            //    cdvReworkOper.Focus();
            //    return false;
            //}
            return true;
        }


        //
        // UpdateReworkFlow()
        //       - Update Rework Flow
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal proc_step As String : Process Step
        //       - ByVal sOptLevel As String : Option Level
        //       - ByVal sMatID As String : Material
        //       - ByVal sFlow As String : Flow
        //       - ByVal sOper As String : Operation
        //       - ByVal sRwkFlow As String : Rework Flow
        //       - ByVal sRwkOper As String : Rework Operation
        //       - ByVal sRetFlow As String : Return Flow
        //       - ByVal sRetOper As String : Return Operation
        //
        private bool UpdateReworkFlow(char proc_step, char sOptLevel, string sMatID, int iMatVer, string sFlow, string sOper,
            string sRwkCode, string sRwkFlow, int iRwkFlowSeq, string sRwkOper, string sRwkStopOper, string sRetFlow, int i_retFlowSeq, string sRetOper, char sRetClear,
            string sOldRwkCode, string sOldRwkFlow, int iOldRwkFlowSeq, string sOldRwkOper)
        {

            TRSNode in_node = new TRSNode("UPDATE_REWORK_FLOW_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = proc_step;

            in_node.AddChar("OPT_LEVEL", (sOptLevel));
            in_node.AddString("MAT_ID", MPCF.Trim(sMatID));
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", MPCF.Trim(sFlow));
            in_node.AddString("OPER", MPCF.Trim(sOper));
            in_node.AddString("RWK_CODE", MPCF.Trim(sRwkCode));
            in_node.AddString("RWK_FLOW", MPCF.Trim(sRwkFlow));
            in_node.AddInt("RWK_FLOW_SEQ_NUM", iRwkFlowSeq);
            in_node.AddString("RWK_OPER", MPCF.Trim(sRwkOper));
            in_node.AddString("RWK_STOP_OPER", MPCF.Trim(sRwkStopOper));
            in_node.AddString("RET_FLOW", MPCF.Trim(sRetFlow));
            in_node.AddInt("RET_FLOW_SEQ_NUM", i_retFlowSeq);
            in_node.AddString("RET_OPER", MPCF.Trim(sRetOper));
            in_node.AddChar("RET_CLEAR_FLAG", (sRetClear));
            in_node.AddString("OLD_RWK_CODE", MPCF.Trim(sOldRwkCode));
            in_node.AddString("OLD_RWK_FLOW", MPCF.Trim(sOldRwkFlow));
            in_node.AddInt("OLD_RWK_FLOW_SEQ_NUM", iOldRwkFlowSeq);
            in_node.AddString("OLD_RWK_OPER", MPCF.Trim(sOldRwkOper));

            if (MPCR.CallService("WIP", "WIP_Update_Rework_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }

        //
        // ViewMFOSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewMFOSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;
            ColumnHeader col;

            MPCF.InitListView(tvMFO.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            switch (tvMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT MAT_ID, MAT_VER, FLOW, OPER, RWK_CODE FROM MWIPRWKDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = '" + tvMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER, RWK_CODE ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC, RWK_CODE ASC");

                    if (tvMFO.GetListView.Columns.Count < 5)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Rework Code", 0);
                        tvMFO.GetListView.Columns.Add(col);
                    }
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT FLOW, OPER, RWK_CODE FROM MWIPRWKDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = '" + tvMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER, RWK_CODE ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC, RWK_CODE ASC");

                    if (tvMFO.GetListView.Columns.Count < 3)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Rework Code", 0);
                        tvMFO.GetListView.Columns.Add(col);
                    }
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT OPER, RWK_CODE FROM MWIPRWKDEF ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND OPT_LEVEL = '" + tvMFO.SelectLevelChar + "' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY OPER, RWK_CODE ");
                    sb.Append("ORDER BY OPER ASC, RWK_CODE ASC");

                    if (tvMFO.GetListView.Columns.Count < 2)
                    {
                        col = new ColumnHeader();
                        col.Text = MPCF.FindLanguage("Rework Code", 0);
                        tvMFO.GetListView.Columns.Add(col);
                    }
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


        private void frmWIPSetupRF_Load(object sender, EventArgs e)
        {
            MPCF.InitListView(lisRwkList);
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisRwkList, this.Text, "");
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

        // √÷ªÛ¿ß ≥ÎµÂ∞° º±≈√µ«æÓ ∏ÆΩ∫∆Æ∏¶ ∞°¡Æø‘¿ª∂ß
        private void tvMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.GetTreeView.GetNodeCount(false));
        }

        // ∞¢ ≥ÎµÂ∞° º±≈√µ«æ˙¿ª ∂ß
        private void tvMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(tvMFO.SelectedNode.GetNodeCount(false));

            if (tvMFO.SelectedItem == Miracom.MESCore.Controls.TreeSelectedItem.Another)
            {
                ViewReworkFlowList(MPCF.SubtractString(e.Node.Text, ":", false, false));
            }
        }

        // º±≈√ Level¿« ∏ª¥‹ ≥ÎµÂ∞° º±≈√µ«æ˙¿ª ∂ß
        private void tvMFO_LevelItemSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Node.GetNodeCount(true) < 1)
            {
                GetReworkCodeList(e.Node, tvMFO.Oper);
                MPCF.FieldClear(grpRwkInfo);
                MPCF.FieldClear(grpRetInfo);
            }
        }

        private void tvMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewMFOSettingDataList();
        }

        private void tvMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            int i_rework_code_index;
            string s_rework_code;

            i_rework_code_index = 0;
            s_rework_code = "";

            switch(tvMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    i_rework_code_index = 4;
                    break;
                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    i_rework_code_index = 2;
                    break;
                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    i_rework_code_index = 1;
                    break;
            }
            s_rework_code = tvMFO.GetListView.SelectedItems[0].SubItems[i_rework_code_index].Text;

            ViewReworkFlowList(s_rework_code);
        }

        private void lisRwkList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisRwkList.SelectedItems.Count < 1) return;

            cdvReworkFlow.Text = lisRwkList.SelectedItems[0].SubItems[0].Text;
            cdvReworkFlow.Sequence = MPCF.ToInt(lisRwkList.SelectedItems[0].SubItems[1].Text);
            cdvReworkOper.Text = lisRwkList.SelectedItems[0].SubItems[2].Text;
            cdvReworkStopOper.Text = lisRwkList.SelectedItems[0].SubItems[3].Text;
            cdvReturnFlow.Text = lisRwkList.SelectedItems[0].SubItems[4].Text;
            cdvReturnFlow.Sequence = MPCF.ToInt(lisRwkList.SelectedItems[0].SubItems[5].Text);
            cdvReturnOper.Text = lisRwkList.SelectedItems[0].SubItems[6].Text;

            switch (MPCF.ToChar(lisRwkList.SelectedItems[0].SubItems[7].Tag))
            {
                case 'Y': // Clear Rework
                    cboReturnOption.SelectedIndex = 1;
                    break;
                case 'A': // Clear Rework and Move to Next Oper
                    cboReturnOption.SelectedIndex = 2;
                    break;
                case 'B': // Keep Rework and Move to Next Oper
                    cboReturnOption.SelectedIndex = 3;
                    break;
                default: // keep Rework
                    cboReturnOption.SelectedIndex = 0;
                    break;
            }
        }

        private void cdvReworkFlow_ButtonPress(object sender, System.EventArgs e)
        {
            cdvReworkFlow.ListCond_Step = '1';
            cdvReworkFlow.ListCond_MatID = "";
            cdvReworkFlow.ListCond_MatVersion = 0;
        }

        private void cdvReworkFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvReworkOper.Text = "";
            cdvReworkStopOper.Text = "";
            if (MPCF.Trim(cdvReworkFlow.Text) != "" && MPCF.Trim(tvMFO.MatID) != "")
            {
                cdvReworkFlow.ListCond_Step = '2';
                cdvReworkFlow.ListCond_MatID = tvMFO.MatID;
                cdvReworkFlow.ListCond_MatVersion = tvMFO.MatVersion;
            }
        }

        private void cdvReturnFlow_ButtonPress(object sender, System.EventArgs e)
        {
            cdvReturnFlow.ListCond_Step = '1';
            cdvReturnFlow.ListCond_MatID = "";
            cdvReturnFlow.ListCond_MatVersion = 0;
        }

        private void cdvReturnFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvReturnOper.Text = "";
            if (MPCF.Trim(cdvReturnFlow.Text) != "" && MPCF.Trim(tvMFO.Text) != "")
            {
                cdvReturnFlow.ListCond_Step = '2';
                cdvReturnFlow.ListCond_MatID = tvMFO.Text;
                cdvReturnFlow.ListCond_MatVersion = tvMFO.MatVersion;
            }
        }

        private void cdvReworkOper_ButtonPress(object sender, EventArgs e)
        {
            if (cdvReworkFlow.Text == "")
            {
                switch (tvMFO.SelectLevel)
                {
                    case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    case Miracom.MESCore.Controls.MFOSelectLevel.M:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                        cdvReworkOper.ListCond_Step = '1';
                        cdvReworkOper.ListCond_Flow = "";
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.F:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MF:
                        cdvReworkOper.ListCond_Step = '2';
                        cdvReworkOper.ListCond_Flow = tvMFO.Flow;
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.NONE:
                        return;
                }
            }
            else
            {
                cdvReworkOper.ListCond_Step = '2';
                cdvReworkOper.ListCond_Flow = cdvReworkFlow.Text;
            }
        }

        private void cdvReworkStopOper_ButtonPress(object sender, EventArgs e)
        {
            if (cdvReworkFlow.Text == "")
            {
                switch (tvMFO.SelectLevel)
                {
                    case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    case Miracom.MESCore.Controls.MFOSelectLevel.M:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                        cdvReworkStopOper.ListCond_Step = '1';
                        cdvReworkStopOper.ListCond_Flow = "";
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.F:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MF:
                        cdvReworkStopOper.ListCond_Step = '2';
                        cdvReworkStopOper.ListCond_Flow = tvMFO.Flow;
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.NONE:
                        return;
                }
            }
            else
            {
                cdvReworkStopOper.ListCond_Step = '2';
                cdvReworkStopOper.ListCond_Flow = cdvReworkFlow.Text;
            }
        }

        private void cdvReturnOper_ButtonPress(object sender, EventArgs e)
        {
            

            if (cdvReturnFlow.Text == "")
            {
                switch (tvMFO.SelectLevel)
                {
                    case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    case Miracom.MESCore.Controls.MFOSelectLevel.M:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                        cdvReturnOper.ListCond_Step = '1';
                        cdvReturnOper.ListCond_Flow = "";
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    case Miracom.MESCore.Controls.MFOSelectLevel.F:
                    case Miracom.MESCore.Controls.MFOSelectLevel.MF:
                        cdvReturnOper.ListCond_Step = '2';
                        cdvReturnOper.ListCond_Flow = tvMFO.Flow;
                        break;

                    case Miracom.MESCore.Controls.MFOSelectLevel.NONE:
                        return;
                }
            }
            else
            {
                cdvReturnOper.ListCond_Step = '2';
                cdvReturnOper.ListCond_Flow = cdvReturnFlow.Text;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string sReworkFlow = string.Empty;
            int iReworkFlowSeq = 0;
            char c_return_rework_clear_flag = ' ';

            try
            {
                if (tvMFO.SelectLevel == Miracom.MESCore.Controls.MFOSelectLevel.O && cdvReworkFlow.Text == "")
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(309), MessageBoxButtons.YesNo, 2) == DialogResult.No)
                    {
                        return;
                    }
                }

                if (CheckCondition() == false) return;

                switch (cboReturnOption.SelectedIndex)
                {
                    case 0: // Keep Rework
                        c_return_rework_clear_flag = ' ';
                        break;
                    case 1: // Clear Rework
                        c_return_rework_clear_flag = 'Y';
                        break;
                    case 2: // Clear Rework and Move to Next Oper
                        c_return_rework_clear_flag = 'A';
                        break;
                    case 3: // Keep Rework and Move to Next Oper
                        c_return_rework_clear_flag = 'B';
                        break;
                }

                if (cdvReworkFlow.Text == "")
                {
                    if (tvMFO.SelectLevel == Miracom.MESCore.Controls.MFOSelectLevel.O)
                    {
                        sReworkFlow = " ";
                        iReworkFlowSeq = 0;
                    }
                    else
                    {
                        sReworkFlow = tvMFO.Flow;
                        iReworkFlowSeq = tvMFO.FlowSeqNum;
                    }
                }
                else
                {
                    sReworkFlow = cdvReworkFlow.Text;
                    iReworkFlowSeq = cdvReworkFlow.Sequence;
                }

                if (UpdateReworkFlow(MPGC.MP_STEP_CREATE, tvMFO.SelectLevelChar,
                                    tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.Oper,
                                    txtReworkCode.Text, sReworkFlow, iReworkFlowSeq, cdvReworkOper.Text, cdvReworkStopOper.Text,
                                    cdvReturnFlow.Text, cdvReturnFlow.Sequence, cdvReturnOper.Text, c_return_rework_clear_flag,
                                    "", "", 0, "") == false)
                {
                    return;
                }

                ViewReworkFlowList(txtReworkCode.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lisRwkList.SelectedItems.Count < 1) return;
            if (CheckCondition() == false) return;

            char c_return_rework_clear_flag = ' ';
            string s_rework_flow = lisRwkList.SelectedItems[0].SubItems[0].Text;
            int i_rework_flow_seq = MPCF.ToInt(lisRwkList.SelectedItems[0].SubItems[1].Text);
            string s_rework_oper = lisRwkList.SelectedItems[0].SubItems[2].Text;

            switch (cboReturnOption.SelectedIndex)
            {
                case 0: // Keep Rework
                    c_return_rework_clear_flag = ' ';
                    break;
                case 1: // Clear Rework
                    c_return_rework_clear_flag = 'Y';
                    break;
                case 2: // Clear Rework and Move to Next Oper
                    c_return_rework_clear_flag = 'A';
                    break;
                case 3: // Keep Rework and Move to Next Oper
                    c_return_rework_clear_flag = 'B';
                    break;
            }

            if (UpdateReworkFlow(MPGC.MP_STEP_UPDATE, tvMFO.SelectLevelChar,
                                tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.Oper,
                                txtReworkCode.Text, cdvReworkFlow.Text, cdvReworkFlow.Sequence, cdvReworkOper.Text, cdvReworkStopOper.Text,
                                cdvReturnFlow.Text, cdvReturnFlow.Sequence, cdvReturnOper.Text, c_return_rework_clear_flag,
                                txtReworkCode.Text, s_rework_flow, i_rework_flow_seq, s_rework_oper) == false)
            {
                return;
            }

            ViewReworkFlowList(txtReworkCode.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) == System.Windows.Forms.DialogResult.No) return;
            if (CheckCondition() == false) return;

            char c_return_rework_clear_flag = ' ';
            switch (cboReturnOption.SelectedIndex)
            {
                case 0: // Keep Rework
                    c_return_rework_clear_flag = ' ';
                    break;
                case 1: // Clear Rework
                    c_return_rework_clear_flag = 'Y';
                    break;
                case 2: // Clear Rework and Move to Next Oper
                    c_return_rework_clear_flag = 'A';
                    break;
                case 3: // Keep Rework and Move to Next Oper
                    c_return_rework_clear_flag = 'B';
                    break;
            }

            if (UpdateReworkFlow(MPGC.MP_STEP_DELETE, tvMFO.SelectLevelChar,
                                tvMFO.MatID, tvMFO.MatVersion, tvMFO.Flow, tvMFO.Oper,
                                txtReworkCode.Text, cdvReworkFlow.Text, cdvReworkFlow.Sequence, cdvReworkOper.Text, cdvReworkStopOper.Text,
                                cdvReturnFlow.Text, cdvReturnFlow.Sequence, cdvReturnOper.Text, c_return_rework_clear_flag,
                                "", "", 0, "") == false)
            {
                return;
            }

            ViewReworkFlowList(txtReworkCode.Text);

            MPCF.FieldClear(grpRwkInfo, txtReworkCode);
            MPCF.FieldClear(grpRetInfo);
        }






    }
}

