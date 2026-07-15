
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSVMSetupServiceUserRoutine.vb
//   Description : User Routine Setup Form
//
//   MES Version : 5.0.0
//
//   Function List
//       - 
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-10-15 : Created by Aiden
//
//
//   Copyright(C) 1998-2008 MIRACOM,INC.
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

namespace Miracom.SVMCore
{
    public partial class frmSVMSetupServiceUserRoutine : Miracom.MESCore.SetupForm01
    {
        public frmSVMSetupServiceUserRoutine()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        // ViewModuleList()
        //       -   View Module List
        // Return Value
        //       -
        // Arguments
        //       -
        private bool ViewModuleList(ListView listView)
        {
            TRSNode in_node = new TRSNode("View_Module_List_In");
            TRSNode out_node = new TRSNode("View_Module_List_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (MPCR.CallService("SVM", "SVM_View_Module_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (int i = 0; i < out_node.GetList(0).Count; i++)
            {
                listView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("MODULE_NAME"), (int)SMALLICON_INDEX.IDX_MODULE));
            }

            return true;
        }

        // ViewServiceUserRoutineList()
        //       -   View Service User Routine List
        // Return Value
        //       -
        // Arguments
        //       -
        private bool ViewServiceUserRoutineList()
        {
            TRSNode in_node = new TRSNode("View_Service_User_Routine_List_In");
            TRSNode out_node = new TRSNode("View_Service_User_Routine_List_Out");
            int i_row;

            MPCF.ClearList(spdList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MODULE_NAME", cdvModule.Text);
            in_node.AddChar("CATEGORY", MPCF.ToChar(cboCategory.Text));
            in_node.AddString("SERVICE_NAME", txtService.Text);

            do
            {
                if (MPCR.CallService("SVM", "SVM_View_Service_User_Routine_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    i_row = spdList.ActiveSheet.RowCount;
                    spdList.ActiveSheet.RowCount++;

                    spdList.ActiveSheet.Cells[i_row, 0].Value = out_node.GetList(0)[i].GetString("MODULE_NAME");
                    spdList.ActiveSheet.Cells[i_row, 1].Value = out_node.GetList(0)[i].GetChar("CATEGORY");
                    spdList.ActiveSheet.Cells[i_row, 2].Value = out_node.GetList(0)[i].GetString("SERVICE_NAME");
                    spdList.ActiveSheet.Cells[i_row, 3].Value = out_node.GetList(0)[i].GetString("SERVICE_DESC_1");

                    if (out_node.GetList(0)[i].GetChar("BEFORE") == 'Y')
                        spdList.ActiveSheet.Cells[i_row, 4].Value = "V";
                    if (out_node.GetList(0)[i].GetChar("AFTER") == 'Y')
                        spdList.ActiveSheet.Cells[i_row, 5].Value = "V";
                    if (out_node.GetList(0)[i].GetChar("OVERRIDE_FLAG") == 'Y')
                        spdList.ActiveSheet.Cells[i_row, 6].Value = "V";

                    spdList.ActiveSheet.Cells[i_row, 7].Value = out_node.GetList(0)[i].GetString("LIB_NAME");
                    spdList.ActiveSheet.Cells[i_row, 8].Value = out_node.GetList(0)[i].GetString("LIB_VER");
                    spdList.ActiveSheet.Cells[i_row, 9].Value = out_node.GetList(0)[i].GetString("CREATE_USER_ID");
                    spdList.ActiveSheet.Cells[i_row, 10].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));
                    spdList.ActiveSheet.Cells[i_row, 11].Value = out_node.GetList(0)[i].GetString("UPDATE_USER_ID");
                    spdList.ActiveSheet.Cells[i_row, 12].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME"));
                }

                in_node.SetString("NEXT_MODULE_NAME", out_node.GetString("NEXT_MODULE_NAME"));
                in_node.SetString("NEXT_SERVICE_NAME", out_node.GetString("NEXT_SERVICE_NAME"));
            } while (in_node.GetString("NEXT_MODULE_NAME") != "" && in_node.GetString("NEXT_SERVICE_NAME") != "");

           
            return true;
        }

        // UpdateServiceUserRoutineList()
        //       -   Update/Delete Service User Routine List
        // Return Value
        //       -
        // Arguments
        //       -
        private bool UpdateServiceUserRoutineList(char c_step)
        {
            TRSNode in_node = new TRSNode("Update_Service_User_Routine_List_In");
            TRSNode out_node = new TRSNode("Update_Service_User_Routine_List_Out");
            TRSNode service_item;

            FarPoint.Win.Spread.Model.CellRange[] cell_ranges;
            int i;
            int r;
            int i_row;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            cell_ranges = spdList.ActiveSheet.GetSelections();
            for (i = 0; i < cell_ranges.Length; i++)
            {
                for (r = 0; r < cell_ranges[i].RowCount; r++)
                {
                    i_row = r + cell_ranges[i].Row;

                    service_item = in_node.AddNode("SERVICE_LIST");
                    service_item.AddString("MODULE_NAME", MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 0].Value));
                    service_item.AddString("SERVICE_NAME", MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 2].Value));

                    if (c_step == MPGC.MP_STEP_DELETE)
                        continue;

                    if (chkBefore.CheckState == CheckState.Checked)
                        service_item.AddChar("BEFORE", 'Y');
                    else if (chkBefore.CheckState == CheckState.Indeterminate)
                        service_item.AddChar("BEFORE", (MPCF.ToChar(spdList.ActiveSheet.Cells[i_row, 4].Value) == 'V' ? 'Y' : ' '));

                    if (chkAfter.CheckState == CheckState.Checked)
                        service_item.AddChar("AFTER", 'Y');
                    else if (chkAfter.CheckState == CheckState.Indeterminate)
                        service_item.AddChar("AFTER", (MPCF.ToChar(spdList.ActiveSheet.Cells[i_row, 5].Value) == 'V' ? 'Y' : ' '));

                    if (chkOverride.CheckState == CheckState.Checked)
                    {
                        service_item.AddChar("OVERRIDE_FLAG", 'Y');
                        service_item.AddString("LIB_NAME", txtLibName.Text);
                        service_item.AddString("LIB_VER", txtLibVer.Text);
                    }
                    else if (chkOverride.CheckState == CheckState.Indeterminate)
                    {
                        service_item.AddChar("OVERRIDE_FLAG", (MPCF.ToChar(spdList.ActiveSheet.Cells[i_row, 6].Value) == 'V' ? 'Y' : ' '));
                        service_item.AddString("LIB_NAME", MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 7].Value));
                        service_item.AddString("LIB_VER", MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 8].Value));
                    }                    
                }
            }            
            
            if (MPCR.CallService("SVM", "SVM_Update_Service_User_Routine_List", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cdvModule;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmSVMSetupServiceUserRoutine_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdList);

                b_load_flag = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ViewServiceUserRoutineList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int i;

            FarPoint.Win.Spread.Model.CellRange[] cell_ranges;
            cell_ranges = spdList.ActiveSheet.GetSelections();

            if (cell_ranges.Length < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                return;
            }
            if (chkOverride.CheckState == CheckState.Checked)
            {
                if (MPCF.CheckValue(txtLibName, 1) == false) return;
                if (MPCF.CheckValue(txtLibVer, 1) == false) return;
            }

            if (UpdateServiceUserRoutineList(MPGC.MP_STEP_UPDATE) == false) return;

            if (MPGV.gbListAutoRefresh == true)
            {
                //Add by J.S. 2009.02.05 Update후 해당행으로 찾아 가게 수정
                i = spdList.ActiveSheet.ActiveRowIndex;
                if (i > (spdList.ActiveSheet.RowCount - 1) && i != 0)
                {
                    i = spdList.ActiveSheet.RowCount - 1;
                }

                btnCreate.PerformClick();

                spdList.ActiveSheet.SetActiveCell(i, 0);
                spdList.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.Model.CellRange[] cell_ranges;
            cell_ranges = spdList.ActiveSheet.GetSelections();

            if (cell_ranges.Length < 1)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                return;
            }

            if (UpdateServiceUserRoutineList(MPGC.MP_STEP_DELETE) == false) return;

            if (MPGV.gbListAutoRefresh == true)
            {
                btnCreate.PerformClick();
            }
        }

        private void cdvModule_ButtonPress(object sender, EventArgs e)
        {
            cdvModule.Init();
            MPCF.InitListView(cdvModule.GetListView);
            cdvModule.Columns.Add("Module Name", 50, HorizontalAlignment.Left);
            cdvModule.SelectedSubItemIndex = 0;

            ViewModuleList(cdvModule.GetListView);
        }

        private void spdList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            FarPoint.Win.Spread.Model.CellRange[] cell_ranges;
            int i;
            int r;
            int i_row;

            cell_ranges = spdList.ActiveSheet.GetSelections();
            for(i = 0; i < cell_ranges.Length; i++)
            {
                if (i == 0)
                {
                    i_row = cell_ranges[0].Row;

                    if (MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 4].Value) == "V")
                        chkBefore.CheckState = CheckState.Checked;
                    else
                        chkBefore.CheckState = CheckState.Unchecked;

                    if (MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 5].Value) == "V")
                        chkAfter.CheckState = CheckState.Checked;
                    else
                        chkAfter.CheckState = CheckState.Unchecked;

                    if (MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 6].Value) == "V")
                        chkOverride.CheckState = CheckState.Checked;
                    else
                        chkOverride.CheckState = CheckState.Unchecked;

                    txtLibName.Text = MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 7].Value);
                    txtLibVer.Text = MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 8].Value);
                }

                for (r = 0; r < cell_ranges[i].RowCount; r++)
                {
                    i_row = r + cell_ranges[i].Row;

                    if (chkBefore.CheckState == CheckState.Checked)
                    {
                        if (MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 4].Value) == "")
                        {
                            chkBefore.CheckState = CheckState.Indeterminate;
                        }
                    }
                    else if (chkBefore.CheckState == CheckState.Unchecked)
                    {
                        if (MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 4].Value) == "V")
                        {
                            chkBefore.CheckState = CheckState.Indeterminate;
                        }
                    }

                    if (chkAfter.CheckState == CheckState.Checked)
                    {
                        if (MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 5].Value) == "")
                        {
                            chkAfter.CheckState = CheckState.Indeterminate;
                        }
                    }
                    else if (chkAfter.CheckState == CheckState.Unchecked)
                    {
                        if (MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 5].Value) == "V")
                        {
                            chkAfter.CheckState = CheckState.Indeterminate;
                        }
                    }

                    if (chkOverride.CheckState == CheckState.Checked)
                    {
                        if (MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 6].Value) == "")
                        {
                            chkOverride.CheckState = CheckState.Indeterminate;
                        }
                    }
                    else if (chkOverride.CheckState == CheckState.Unchecked)
                    {
                        if (MPCF.Trim(spdList.ActiveSheet.Cells[i_row, 6].Value) == "V")
                        {
                            chkOverride.CheckState = CheckState.Indeterminate;
                        }
                    }
                }
            }
        }

        private void chkOverride_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkOverride.CheckState == CheckState.Checked)
            {
                txtLibName.ReadOnly = false;
                txtLibVer.ReadOnly = false;
            }
            else
            {
                txtLibName.ReadOnly = true;
                txtLibVer.ReadOnly = true;
            }
        }

        private void cboCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                sCond = "Module : " + cdvModule.Text + ", Category : " + cboCategory.Text + ", Service : " + txtService.Text;

                MPCF.ExportToExcel(spdList, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        
    }
}

