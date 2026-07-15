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
//   File Name   : frmBASSetupCheckQuery.cs
//   Description : Setup Check Query
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
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.BASCore
{
    public partial class frmBASSetupCheckQuery : Miracom.MESCore.SetupForm02
    {
        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private static bool b_load_flag = false;

        #endregion

        #region " Form Definition "

        public frmBASSetupCheckQuery()
        {
            InitializeComponent();
        }

        #endregion

        #region " Function Definition "

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            switch (MPCF.Trim(FuncName))
            {
                case "Update_Function":

                    if (MPCF.CheckValue(cdvQueryType, 1) == false) return false;
                    if (MPCF.CheckValue(txtQueryID, 1) == false) return false;
                    if (MPCF.CheckValue(cboFormat, 1) == false) return false;
                    if (MPCF.Trim(cboValTabType.Text) != "")
                    {
                        if (MPCF.CheckValue(cdvTableName, 1) == false) return false;
                    }

                    switch (ProcStep)
                    {
                        case MPGC.MP_STEP_CREATE:

                            if (MPCF.CheckValue(txtQuery, 1) == false) return false;

                            break;


                        case MPGC.MP_STEP_UPDATE:

                            if (MPCF.CheckValue(txtQueryID, 1) == false) return false;
                            if (MPCF.CheckValue(txtQuery, 1) == false) return false;

                            break;

                        case MPGC.MP_STEP_DELETE:

                            if (MPCF.CheckValue(txtQueryID, 1) == false) return false;

                            break;

                    }
                    break;

            }

            return true;

        }

        //
        // ViewCheckQuery()
        //       - View Check Query Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCheckQuery()
        {
            TRSNode in_node = new TRSNode("VIEW_CHECK_QUERY_IN");
            TRSNode out_node = new TRSNode("VIEW_CHECK_QUERY_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("QUERY_ID", lisDataCode.SelectedItems[0].Text);

                if (MPCR.CallService("BAS", "BAS_View_Check_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvQueryType.Text = out_node.GetString("QUERY_TYPE").ToString().Trim();
                txtQueryID.Text = out_node.GetString("QUERY_ID").ToString().Trim();
                txtQuery.Text = out_node.GetString("QUERY").ToString().Trim();

                cboFormat.Text = cboFormat.Items[cboFormat.FindString( out_node.GetChar("ANSWER_FMT").ToString().Trim(), 0)].ToString();
                nudSize.Value = out_node.GetInt("ANSWER_SIZE");
                if(MPCF.Trim(out_node.GetChar("VALID_TBL_TYPE")) == "")
                {
                    cboValTabType.Text = "";
                    cdvTableName.Enabled = false;
                }
                else
                {
                    cboValTabType.SelectedIndex = cboValTabType.FindString(MPCF.Trim(out_node.GetChar("VALID_TBL_TYPE")), -1);
                    cdvTableName.Enabled = true;
                }
                cdvTableName.Text = out_node.GetString("VALID_TBL_NAME").ToString().Trim();
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // Update_Function()
        //       - Create/Update/Delete Sheet Query Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("MP_STEP_CREATE" - Create, "MP_STEP_UPDATE" - Update, "MP_STEP_DELETE" - Delete)
        //
        private bool Update_Function(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_CHECK_QUERY_IN");
            TRSNode out_node = new TRSNode("UPDATE_CHECK_QUERY_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.SetString("QUERY_ID", MPCF.Trim(txtQueryID.Text));
                in_node.SetString("QUERY_TYPE", MPCF.Trim(cdvQueryType.Text));
                in_node.SetString("QUERY", MPCF.Trim(txtQuery.Text));
                in_node.SetChar("ANSWER_FMT", cboFormat.Text.Substring(0, 1));
                in_node.SetInt("ANSWER_SIZE", nudSize.Value);
                if (MPCF.Trim(cboValTabType.Text) != "")
                {
                    in_node.SetChar("VALID_TBL_TYPE", cboValTabType.Text.Substring(0, 1));
                    in_node.SetString("VALID_TBL_NAME", MPCF.Trim(cdvTableName.Text));
                }

                if (MPCR.CallService("BAS", "BAS_Update_Check_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisDataCode.Items.Add(txtQueryID.Text, (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itm.SubItems.Add(cdvQueryType.Text);
                        itm.Selected = true;
                        lisDataCode.Sorting = SortOrder.Ascending;
                        lisDataCode.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisDataCode, MPCF.Trim(cdvQueryType.Text), false) == true)
                        {
                            lisDataCode.SelectedItems[0].SubItems[1].Text = MPCF.Trim(cdvQueryType.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisDataCode, MPCF.Trim(txtQueryID.Text), false);
                        if (idx != -1)
                        {
                            lisDataCode.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisDataCode.Items.Count.ToString();
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

        #endregion

        private void frmBASSetupCheckQuery_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    btnRefresh.PerformClick();
                    cdvTableName.Enabled = false;
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FindListItemNextPartial(lisDataCode, txtFind.Text, true, false);
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
                MPCF.FindListItemPartial(lisDataCode, txtFind.Text, 0, true, false);
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
                lblDataCount.Text = "";
                if (string.IsNullOrEmpty(MPCF.Trim(cdvGroup.Text.ToString())) == true)
                    cStep = '1';
                else
                    cStep = '2';

                if (BASLIST.ViewCheckQueryList(lisDataCode, cStep, cdvGroup.Text) == false)
                {
                    return;
                }

                lblDataCount.Text = lisDataCode.Items.Count.ToString();
                if (lisDataCode.Items.Count > 0)
                {
                    if (MPCF.Trim(txtQueryID.Text) == "")
                    {
                        lisDataCode.Items[0].Selected = true;
                    }
                    else
                    {
                        MPCF.FindListItem(lisDataCode, txtQueryID.Text, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                MPCF.ExportToExcel(lisDataCode, this.Text, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvQueryType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvQueryType.Init();
                MPCF.InitListView(cdvQueryType.GetListView);
                cdvQueryType.Columns.Add("Query Type", 150, HorizontalAlignment.Left);
                cdvQueryType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvQueryType.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvQueryType.GetListView, '1', "CHECK_QUERY_TYPE") == true)
                {
                    cdvQueryType.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvGroup_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvGroup.Init();
                MPCF.InitListView(cdvGroup.GetListView);
                cdvGroup.Columns.Add("Query Type", 150, HorizontalAlignment.Left);
                cdvGroup.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvGroup.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvGroup.GetListView, '1', "CHECK_QUERY_TYPE");
                cdvGroup.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvTableName_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvTableName.Init();
                MPCF.InitListView(cdvTableName.GetListView);
                cdvTableName.Columns.Add("Table", 150, HorizontalAlignment.Left);
                cdvTableName.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvTableName.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMTableList(cdvTableName.GetListView, '1');
                cdvTableName.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvGroup_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);
                btnRefresh.PerformClick();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisDataCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lisDataCode.SelectedItems.Count > 0)
                {
                    ViewCheckQuery();
                }

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
                if (CheckCondition("Update_Function", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Function(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition("Update_Function", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Function(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Function", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Function(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    MPCF.FieldClear(this);
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cboFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nudSize.Value = 0;
                nudSize.Enabled = true;

                switch (cboFormat.SelectedIndex)
                {
                    case 4: // Datetime
                        nudSize.Value = 14;
                        nudSize.Enabled = false;
                        break;

                    case 5: // Date
                        nudSize.Value = 8;
                        nudSize.Enabled = false;
                        break;

                    case 6: // Time
                        nudSize.Value = 6;
                        nudSize.Enabled = false;
                        break;

                    default:
                        nudSize.Value = 0;
                        nudSize.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvQueryType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.FieldClear(pnlRight, cdvQueryType);
        }

        private void cboValTabType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cboValTabType.Text) == "")
            {
                cdvTableName.Enabled = false;
                cdvTableName.Text = "";
            }
            else
            {
                cdvTableName.Enabled = true;
            }
        }

    }
}
