using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupChecklistDefinition.cs
//   Description : Attach Query to Check
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-11-14 : Created by Yeonggon Son
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.BASCore
{
    public partial class frmBASSetupChecklistDefinition : Miracom.MESCore.SetupForm02
    {
        #region " Constant Definition "

        private enum ColQUERY : int
        {
            QUERY_TYPE = 0,
            QUERY_ID,
            QUERY,
            ANSWER_FMT,
            ANSWER_SIZE,
            VALID_TBL_TYPE,
            VALID_TBL_NAME
        }

        const string EMPTY_ROW_STRING = "Add here...";

        const char MP_STEP_ATTACH = 'K';
        const char MP_STEP_DETACH = 'L';

        #endregion

        #region " Variable Definition "

        bool b_load_flag = false;
        bool b_new_flag = false;

        #endregion

        #region " Form Definition "

        public frmBASSetupChecklistDefinition()
        {
            InitializeComponent();
        }

        private void frmBASSetupChecklistDefinition_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    MPCF.InitListView(lisChecklist_ListMain);
                    MPCF.InitListView(lisAttachQuery);
                    MPCF.InitListView(lisQueryList);
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion

        #region " Function Definition "

        private bool ClearData(char ProcStep)
        {
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this, cdvCheckListTypeMain, txtCheckListID);
                    lisAttachQuery.Items.Clear();
                    spdQuery_Sheet1.RowCount = 0;
                    cdvChecklistKeyPrompt.Clear();
                    return true;
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
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As Char : Process Step
        //
        private bool CheckCondition(char ProcStep)
        {

            switch (ProcStep)
            {
                case MPGC.MP_STEP_CREATE:
                case MPGC.MP_STEP_UPDATE:
                case MPGC.MP_STEP_DELETE:
                    if (MPCF.CheckValue(txtCheckListID, 1) == false) return false;
                    if (MPCF.CheckValue(cdvCheckListType, 1) == false) return false;
                    if (MPCF.CheckValue(cboLotorRes, 1) == false) return false;
                    break;

                case MP_STEP_ATTACH:
                    if (lisAttachQuery.SelectedItems.Count == 0) return false;
                    if (lisQueryList.SelectedItems.Count == 0) return false;
                    break;
                case MP_STEP_DETACH:
                    if (lisAttachQuery.SelectedItems.Count == 0) return false;
                    if (lisAttachQuery.SelectedItems.Count == 1 && 
                        lisAttachQuery.SelectedItems[0].Text.Equals(EMPTY_ROW_STRING)) return false;
                    break;
            }

            return true;

        }

        //
        // SetGroupCmfItem()
        //       - Setup Group Field
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];

            sGrpTableName[0] = MPGC.MP_GCM_CHKLIST_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_CHKLIST_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_CHKLIST_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_CHKLIST_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_CHKLIST_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_CHKLIST_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_CHKLIST_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_CHKLIST_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_CHKLIST_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_CHKLIST_GRP_10;

            MPCR.SetGRPItem(MPGC.MP_GRP_CHKLIST, "lblGroup", "cdvGroup", grpGroup, sGrpTableName);

        }

        //
        // SetCustomizedFieldItem()
        //       - Setup Customized Field
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private void SetCustomizedFieldItem()
        {
            try
            {
                MPCR.SetCMFItem(MPGC.MP_CMF_CHKLIST, "lblCMF", "cdvCMF", grpCMF);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        //
        // ViewCheckQuery()
        //       - View Check Query Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sQueryID As String : Query ID
        //
        private bool ViewCheckQuery(string sQueryID)
        {
            TRSNode in_node = new TRSNode("VIEW_CHECK_QUERY_IN");
            TRSNode out_node = new TRSNode("VIEW_CHECK_QUERY_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("QUERY_ID", sQueryID);

                if (MPCR.CallService("BAS", "BAS_View_Check_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdQuery.ActiveSheet.RowCount++;
                spdQuery.ActiveSheet.Cells[spdQuery.ActiveSheet.RowCount - 1, (int)ColQUERY.QUERY_TYPE].Value = out_node.GetString("QUERY_TYPE").ToString().Trim();
                spdQuery.ActiveSheet.Cells[spdQuery.ActiveSheet.RowCount - 1, (int)ColQUERY.QUERY_ID].Value = out_node.GetString("QUERY_ID").ToString().Trim();
                spdQuery.ActiveSheet.Cells[spdQuery.ActiveSheet.RowCount - 1, (int)ColQUERY.QUERY].Value = out_node.GetString("QUERY").ToString().Trim();
                spdQuery.ActiveSheet.Cells[spdQuery.ActiveSheet.RowCount - 1, (int)ColQUERY.ANSWER_FMT].Value = out_node.GetChar("ANSWER_FMT").ToString().Trim();
                spdQuery.ActiveSheet.Cells[spdQuery.ActiveSheet.RowCount - 1, (int)ColQUERY.ANSWER_SIZE].Value = out_node.GetInt("ANSWER_SIZE");
                spdQuery.ActiveSheet.Cells[spdQuery.ActiveSheet.RowCount - 1, (int)ColQUERY.VALID_TBL_TYPE].Value = out_node.GetChar("VALID_TBL_TYPE").ToString().Trim();
                spdQuery.ActiveSheet.Cells[spdQuery.ActiveSheet.RowCount - 1, (int)ColQUERY.VALID_TBL_NAME].Value = out_node.GetString("VALID_TBL_NAME").ToString().Trim();

                //정렬
                spdQuery.ActiveSheet.Columns[(int)ColQUERY.QUERY_TYPE].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                spdQuery.ActiveSheet.Columns[(int)ColQUERY.ANSWER_FMT].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                spdQuery.ActiveSheet.Columns[(int)ColQUERY.ANSWER_SIZE].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                spdQuery.ActiveSheet.Columns[(int)ColQUERY.VALID_TBL_TYPE].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // ViewCheckQueryList()
        //       - View Check Query Definition List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCheckQueryList()
        {
            char cStep;

            try
            {
                if (string.IsNullOrEmpty(MPCF.Trim(cdvQryType.Text.ToString())) == true)
                    cStep = '1';
                else
                    cStep = '2';

                if (BASLIST.ViewCheckQueryList(lisQueryList, cStep, cdvQryType.Text) == false)
                {
                    return false;
                }
                lisQueryList.ForeColor = Color.Black;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // ViewChecklist()
        //       - View Checklist Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewChecklist()
        {
            TRSNode in_node = new TRSNode("VIEW_CHECKLIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CHECKLIST_OUT");
            string sNaming = string.Empty;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHKLIST_ID", lisChecklist_ListMain.SelectedItems[0].Text);

                if (MPCR.CallService("BAS", "BAS_View_Checklist", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtCheckListID.Text = out_node.GetString("CHKLIST_ID").ToString().Trim();
                txtDesc.Text = out_node.GetString("CHKLIST_DESC").ToString().Trim();
                cdvCheckListType.Text = out_node.GetString("CHKLIST_TYPE").ToString().Trim();
                for (int i = 0; i < cboLotorRes.Items.Count; i++)
                {
                    if (MPCF.Trim(cboLotorRes.Items[i]).Length > 1 && MPCF.Trim(cboLotorRes.Items[i])[0] == out_node.GetChar("LOT_OR_RES_FLAG"))
                    {
                        cboLotorRes.SelectedIndex = i;
                        break;
                    }
                }

                cdvGroup1.Text = out_node.GetString("CHKLIST_GRP_1").ToString().Trim();
                cdvGroup2.Text = out_node.GetString("CHKLIST_GRP_2").ToString().Trim();
                cdvGroup3.Text = out_node.GetString("CHKLIST_GRP_3").ToString().Trim();
                cdvGroup4.Text = out_node.GetString("CHKLIST_GRP_4").ToString().Trim();
                cdvGroup5.Text = out_node.GetString("CHKLIST_GRP_5").ToString().Trim();
                cdvGroup6.Text = out_node.GetString("CHKLIST_GRP_6").ToString().Trim();
                cdvGroup7.Text = out_node.GetString("CHKLIST_GRP_7").ToString().Trim();
                cdvGroup8.Text = out_node.GetString("CHKLIST_GRP_8").ToString().Trim();
                cdvGroup9.Text = out_node.GetString("CHKLIST_GRP_9").ToString().Trim();
                cdvGroup10.Text = out_node.GetString("CHKLIST_GRP_10").ToString().Trim();

                cdvCMF1.Text = out_node.GetString("CHKLIST_CMF_1").ToString().Trim();
                cdvCMF2.Text = out_node.GetString("CHKLIST_CMF_2").ToString().Trim();
                cdvCMF3.Text = out_node.GetString("CHKLIST_CMF_3").ToString().Trim();
                cdvCMF4.Text = out_node.GetString("CHKLIST_CMF_4").ToString().Trim();
                cdvCMF5.Text = out_node.GetString("CHKLIST_CMF_5").ToString().Trim();
                cdvCMF6.Text = out_node.GetString("CHKLIST_CMF_6").ToString().Trim();
                cdvCMF7.Text = out_node.GetString("CHKLIST_CMF_7").ToString().Trim();
                cdvCMF8.Text = out_node.GetString("CHKLIST_CMF_8").ToString().Trim();
                cdvCMF9.Text = out_node.GetString("CHKLIST_CMF_9").ToString().Trim();
                cdvCMF10.Text = out_node.GetString("CHKLIST_CMF_10").ToString().Trim();

                cdvChecklistKeyPrompt.DisplayKeyPromptSetup(ref out_node);

                b_new_flag = false;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // ViewAttachQueryList()
        //       - View Checklist Attached Query List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewAttachQueryList()
        {
            ListViewItem itmX;

            try
            {
                MPCF.InitListView(lisAttachQuery);

                if (BASLIST.ViewChecklistQueryList(lisAttachQuery, '1', MPCF.Trim(txtCheckListID.Text.ToString())) == false)
                {
                    return false;
                }

                //AddEmptyRow
                itmX = lisAttachQuery.Items.Insert(lisAttachQuery.Items.Count, EMPTY_ROW_STRING, (int)SMALLICON_INDEX.IDX_MESSAGE);
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");

                int iRow = lisAttachQuery.Items.Count - 1;
                if (iRow == -1) iRow = 0;

                if (lisAttachQuery.SelectedItems != null) lisAttachQuery.SelectedItems.Clear();
                lisAttachQuery.Items[iRow].Selected = true;
                lisAttachQuery.Items[iRow].Focused = true;

                SetAttachedQuery();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void SetAttachedQuery()
        {
            try
            {
                //Attached-NotAttached
                for (int i = 0; i < lisQueryList.Items.Count; i++)
                {
                    if (MPCF.FindListItemIndex(lisAttachQuery, lisQueryList.Items[i].Text, true) > -1)
                    {
                        lisQueryList.Items[i].ForeColor = Color.Blue;
                    }
                    else
                    {
                        lisQueryList.Items[i].ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //
        // UpdateChecklist()
        //       - Update Checklist Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - Optional ByVal ProcStep As Char : Process Step
        //
        private bool UpdateChecklist(char ProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_CHECKLIST_IN");
            TRSNode out_node = new TRSNode("UPDATE_CHECKLIST_OUT");
            TRSNode data_list;
            string sNaming = string.Empty;
            ListViewItem itm;
            int idx;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.SetString("CHKLIST_ID", MPCF.Trim(txtCheckListID.Text));
                in_node.SetString("CHKLIST_DESC", MPCF.Trim(txtDesc.Text));
                in_node.SetString("CHKLIST_TYPE", MPCF.Trim(cdvCheckListType.Text));

                if (string.IsNullOrEmpty(cboLotorRes.Text.ToString()) == false)
                {
                    in_node.SetChar("LOT_OR_RES_FLAG", MPCF.Trim(cboLotorRes.Text));
                }

                //Group Field
                in_node.SetString("CHKLIST_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.SetString("CHKLIST_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.SetString("CHKLIST_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.SetString("CHKLIST_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.SetString("CHKLIST_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.SetString("CHKLIST_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.SetString("CHKLIST_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.SetString("CHKLIST_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.SetString("CHKLIST_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.SetString("CHKLIST_GRP_10", MPCF.Trim(cdvGroup10.Text));

                //Customized Field
                in_node.SetString("CHKLIST_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.SetString("CHKLIST_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.SetString("CHKLIST_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.SetString("CHKLIST_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.SetString("CHKLIST_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.SetString("CHKLIST_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.SetString("CHKLIST_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.SetString("CHKLIST_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.SetString("CHKLIST_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.SetString("CHKLIST_CMF_10", MPCF.Trim(cdvCMF10.Text));

                //Key Prompte Setup
                cdvChecklistKeyPrompt.FillKeyPromptSetup(ref in_node);

                //Query List
                if (ProcStep == MPGC.MP_STEP_CREATE)
                {
                    for (i = 0; i < lisAttachQuery.Items.Count; i++)
                    {
                        if (lisAttachQuery.Items[i].Text.Equals(EMPTY_ROW_STRING))
                        {
                            continue;
                        }
                        data_list = in_node.AddNode("QUERY_LIST");
                        data_list.SetString("CHKLIST_ID", MPCF.Trim(txtCheckListID.Text));
                        data_list.SetString("QUERY_ID", MPCF.Trim(lisAttachQuery.Items[i].Text));
                        data_list.SetChar("REQUIRE_FLAG", MPCF.ToChar(lisAttachQuery.Items[i].SubItems[2].Text));
                    }
                }

                if (MPCR.CallService("BAS", "BAS_Update_Checklist", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisChecklist_ListMain.Items.Add(txtCheckListID.Text.ToString().Trim(), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itm.SubItems.Add(MPCF.Trim(cdvCheckListType.Text));
                        itm.SubItems.Add(txtDesc.Text.ToString().Trim());
                        itm.Selected = true;
                        lisChecklist_ListMain.Sorting = SortOrder.Ascending;
                        lisChecklist_ListMain.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisChecklist_ListMain, MPCF.Trim(txtCheckListID.Text), false) == true)
                        {
                            lisChecklist_ListMain.SelectedItems[0].SubItems[1].Text = MPCF.Trim(cdvCheckListType.Text);
                            lisChecklist_ListMain.SelectedItems[0].SubItems[2].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisChecklist_ListMain, MPCF.Trim(txtCheckListID.Text), false);
                        if (idx != -1)
                        {
                            lisChecklist_ListMain.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisChecklist_ListMain.Items.Count.ToString();
                }

                b_new_flag = false;
                MPCR.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // UpdateAttachQuery()
        //       - Update Checklist Query Relation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - Optional ByVal ProcStep As Char : Process Step
        //
        private bool UpdateQuery()
        {
            TRSNode in_node = new TRSNode("UPDATE_ATTACH_QUERY_IN");
            TRSNode out_node = new TRSNode("UPDATE_ATTACH_QUERY_OUT");
            TRSNode data_list = null;
            string sNaming = string.Empty;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;
                in_node.AddString("CHKLIST_ID", MPCF.Trim(txtCheckListID.Text));

                for (int i = 0; i < lisAttachQuery.Items.Count; i++)
                {
                    if (lisAttachQuery.Items[i].Text.Equals(EMPTY_ROW_STRING)) continue;
                    data_list = in_node.AddNode("QUERY_LIST");
                    data_list.AddString("QUERY_ID", MPCF.Trim(lisAttachQuery.Items[i].Text));
                    data_list.AddChar("REQUIRE_FLAG", MPCF.ToChar(lisAttachQuery.Items[i].SubItems[2].Text));
                    data_list.AddInt("DISP_SEQ", i +1);
                }

                if (data_list == null) return true;

                if (MPCR.CallService("BAS", "BAS_Update_Checklist_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                ViewCheckQueryList();
                ViewAttachQueryList();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool AttachQuery()
        {
            string query_id;
            int i, idx, seq, icount;
            ListViewItem itemX;

            icount = 0;
            seq = lisAttachQuery.SelectedItems[0].Index;

            for (i = 0; i < lisQueryList.SelectedItems.Count; i++)
            {
                query_id = lisQueryList.SelectedItems[i].Text;
                idx = MPCF.FindListItemIndex(lisAttachQuery, query_id, false);
                if (idx == -1)
                {
                    //Add
                    itemX = lisAttachQuery.Items.Insert(seq, query_id, (int)SMALLICON_INDEX.IDX_MESSAGE);
                    itemX.SubItems.Add(lisQueryList.SelectedItems[i].SubItems[1].Text);
                    if (chkRequireAnswer.Checked == true)
                    {
                        itemX.SubItems.Add("Y");
                    }
                    else
                    {
                        itemX.SubItems.Add("");
                    }

                    icount++;
                    seq++;
                }
            }

            SetAttachedQuery();

            if (icount == 0)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(358));
                return false;
            }

            if (b_new_flag != true)
            {
                return UpdateQuery();
            }

            return true;
        }

        private bool DetachQuery()
        {
            int i;

            for (i = lisAttachQuery.SelectedItems.Count - 1; i >= 0; i--)
            {
                if (lisAttachQuery.SelectedItems[i].Text.Equals(EMPTY_ROW_STRING)) continue;
                lisAttachQuery.SelectedItems[i].Remove();
            }

            SetAttachedQuery();
            
            if (b_new_flag != true)
            {
                return UpdateQuery();
            }
            return true;
        }

        #endregion 

        private void frmBASSetupChecklistDefinition_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    /* Init Group Cmf Field
                     */
                    SetGroupCmfItem();

                    /* Init Customized Field
                     */
                    SetCustomizedFieldItem();

                    /* View Left List(Checklist List)
                     */
                    btnRefresh.PerformClick();

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FindListItemNextPartial(lisChecklist_ListMain, txtFind.Text, true, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FindListItemPartial(lisChecklist_ListMain, txtFind.Text, 0, true, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            char cStep;

            try
            {
                if (string.IsNullOrEmpty(cdvCheckListTypeMain.Text) == true)
                {
                    cStep = '1';
                }
                else
                {
                    lisChecklist_ListMain.Columns[1].Width = 0;
                    cStep = '2';
                }

                lblDataCount.Text = "";
                ClearData('1');

                if (BASLIST.ViewChecklistList(lisChecklist_ListMain, cStep, cdvCheckListTypeMain.Text) == false)
                {
                    return;
                }
                lblDataCount.Text = lisChecklist_ListMain.Items.Count.ToString();
                if (ViewCheckQueryList() == false)
                {
                    return;
                }

                if (lisChecklist_ListMain.Items.Count == 0)
                {
                    txtCheckListID.Clear();
                    return;
                }
                if (MPCF.Trim(txtCheckListID.Text) == "")
                {
                    lisChecklist_ListMain.Items[0].Selected = true;
                }
                else
                {
                    if (MPCF.FindListItem(lisChecklist_ListMain, txtCheckListID.Text, false) == false)
                    {
                        txtCheckListID.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.ExportToExcel(lisChecklist_ListMain, this.Text, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }

        private void tbpAttachQuery_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(tbpAttachQuery, pnlEventMidLeft, pnlEventMidRight, pnlEventMidMid, 40);
        }

        private void cdvQryType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvQryType.Init();
                MPCF.InitListView(cdvQryType.GetListView);
                cdvQryType.Columns.Add("Query Type", 150, HorizontalAlignment.Left);
                cdvQryType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvQryType.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvQryType.GetListView, '1', "CHECK_QUERY_TYPE");
                cdvQryType.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvQryType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (ViewCheckQueryList() == false)
                {
                    return;
                }

                SetAttachedQuery();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvCheckListType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvCheckListType.Init();
                MPCF.InitListView(cdvCheckListType.GetListView);
                cdvCheckListType.Columns.Add("Checklist Type", 150, HorizontalAlignment.Left);
                cdvCheckListType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvCheckListType.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvCheckListType.GetListView, '1', "CHECK_LIST_TYPE");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCheckListTypeMain_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvCheckListTypeMain.Init();
                MPCF.InitListView(cdvCheckListTypeMain.GetListView);
                cdvCheckListTypeMain.Columns.Add("Checklist Type", 150, HorizontalAlignment.Left);
                cdvCheckListTypeMain.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvCheckListTypeMain.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvCheckListTypeMain.GetListView, '1', "CHECK_LIST_TYPE");
                cdvCheckListTypeMain.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCheckListTypeMain_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void txtCheckListID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCheckListID.Focused && b_new_flag == false)
                {
                    txtDesc.ResetText();
                    cdvCheckListType.ResetText();

                    ViewAttachQueryList();
                    b_new_flag = true;
                }
                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnQryExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond = string.Empty;


                sCond = "Function : " + txtCheckListID.Text.ToString().Trim();

                MPCF.ExportToExcel(lisAttachQuery, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false) return;

                if (UpdateChecklist(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }

                btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;
                
                if (UpdateChecklist(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }

                btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_DELETE) == false) return;
                
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (UpdateChecklist(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }

                btnRefresh.PerformClick();

                MPCF.FieldClear(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MP_STEP_ATTACH) == false) return;

                string sAttachRow;
                int iQueryRow;
                ListViewItem itemX;

                if (lisQueryList.SelectedItems.Count > 0)
                {
                    if (lisAttachQuery.Items.Count == 0)
                    {
                        //AddEmptyRow
                        itemX = lisAttachQuery.Items.Add(EMPTY_ROW_STRING, (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itemX.SubItems.Add("");
                        itemX.SubItems.Add("");
                        itemX.SubItems.Add("");
                        itemX.Selected = true;
                    }

                    if (lisAttachQuery.SelectedItems == null) lisAttachQuery.Items[lisAttachQuery.Items.Count - 1].Selected = true;

                    sAttachRow = lisAttachQuery.SelectedItems[0].Text;
                    iQueryRow = lisQueryList.SelectedItems[0].Index;
                    if (AttachQuery() == false)
                    {
                        return;
                    }

                    if(lisAttachQuery.SelectedItems != null) lisAttachQuery.SelectedItems.Clear();
                    if (lisAttachQuery.SelectedItems != null) lisQueryList.SelectedItems.Clear();

                    int select_row = MPCF.FindListItemIndex(lisAttachQuery, sAttachRow, true);
                    lisAttachQuery.Items[select_row].Selected = true;

                    for (int i = iQueryRow; i < lisQueryList.Items.Count; i++)
                    {
                        select_row = MPCF.FindListItemIndex(lisAttachQuery, lisQueryList.Items[i].Text, true);
                        if (select_row == -1)
                        {
                            lisQueryList.Items[i].Selected = true;
                            lisQueryList.Items[i].Focused = true;
                            break;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MP_STEP_DETACH) == false) return;

                if (DetachQuery() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void lisChecklist_ListMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lisChecklist_ListMain.SelectedItems.Count > 0)
                {
                    if (ViewChecklist() == true)
                    {
                        ViewAttachQueryList();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void tabQuery_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (lisAttachQuery.Items.Count > 0 &&
                    this.tabQuery.SelectedTab == this.tbpViewQuery)
                {
                    MPCF.ClearList(spdQuery);
                    for (int i = 0; i < lisAttachQuery.Items.Count; i++)
                    {
                        if (!lisAttachQuery.Items[i].Text.Equals(EMPTY_ROW_STRING))
                        {
                            if (ViewCheckQuery(lisAttachQuery.Items[i].Text.Trim()) == false)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvGroupCmf_ButtonPress(object sender, EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void btnToggleRequired_Click(object sender, EventArgs e)
        {
            try
            {
                if (lisAttachQuery.SelectedItems.Count == 0) return;
                
                for (int i = 0; i < lisAttachQuery.SelectedItems.Count; i++)
                {
                    if (lisAttachQuery.SelectedItems[i].Text.Equals(EMPTY_ROW_STRING))
                    {
                        if (lisAttachQuery.SelectedItems.Count == 1) return;

                        continue;
                    }

                    if (lisAttachQuery.SelectedItems[i].SubItems[2].Text == "Y")
                    {
                        lisAttachQuery.SelectedItems[i].SubItems[2].Text = "";
                    }
                    else
                    {
                        lisAttachQuery.SelectedItems[i].SubItems[2].Text = "Y";
                    }
                }

                if (b_new_flag != true)
                {
                    UpdateQuery();
                }
            }
            catch(Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
}
