//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMeasuringPlanSetup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewMms() : View Mms definition
//       - UpdateMms() : Create/Update/Delete Mms
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-04-10 15:25:03 : XXXX Created by generator in DEV Tools
//
//   Copyright(C) 1998-2023 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmMMSMeasuringPlanSetup : SetupForm02
    {
        public frmMMSMeasuringPlanSetup()
        {
            InitializeComponent();

            btnCreate.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;            
        }


        #region " Constant Definition "
        private enum PLAN_LIST : int
        {
            CHECK = 0,
            DETAIL,
            ANA_ID,
            PLAN_DATE,
            ANA_STATUS,
            ANA_DIV,
            SAMPLE_CODE
        }


        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        //
        // GetFisrtFocusItem()
        //       - Return first focus control in form
        // Return Value
        //       - Control : Control
        // Arguments
        //       - 
        //
        public virtual Control GetFisrtFocusItem()
        {
            return this.txtEquipCode;
        }

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - char c_case ('1', '2')
        //
        private void ClearData(char c_case)
        {
            try
            {
                if (c_case == '1')
                {
                    MPCF.FieldClear(this);

                    // TODO
                }
                else if (c_case == '2')
                {
                    // TODO
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }            
        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - string FuncName : Function Name
        //
        private bool CheckCondition(string FuncName)
        {
            if (MPCF.CheckValue(txtEquipCode, 1) == false)
            {
                return false;
            }
            bool b_check_value = false;
            switch (FuncName)
            {
                case "CREATE":
                    // TODO
                    //if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                    //{
                    //    tabXXX.SelectedTab = tbpGroup;
                    //    return false;
                    //}
                    //if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    //{
                    //    tabXXX.SelectedTab = tbpCmf;
                    //    return false;
                    //}
                    break;
                case "UPDATE":
                    // TODO
                    //if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                    //{
                    //    tabXXX.SelectedTab = tbpGroup;
                    //    return false;
                    //}
                    //if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    //{
                    //    tabXXX.SelectedTab = tbpCmf;
                    //    return false;
                    //}
                    break;
                case "DELETE":
                    // TODO

                    for (int i = 0; i < spdAnaPlanList.ActiveSheet.RowCount; i++)
                    {
                        if (Convert.ToBoolean(spdAnaPlanList.ActiveSheet.GetValue(i, (int)PLAN_LIST.CHECK)) == true)
                        {
                            if (MPCF.ToChar(spdAnaPlanList.ActiveSheet.GetValue(i, (int)PLAN_LIST.ANA_STATUS)) != '0')
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(609)); // Only the standby status of the measurement can be deleted!
                                spdAnaPlanList.ActiveSheet.SetActiveCell(i, (int)PLAN_LIST.ANA_STATUS);
                                return false;
                            }
                            
                            b_check_value = true;
                        }
                    }
                    if (b_check_value == false)
                    {
                        //MPCF.ShowMsgBox(MPCF.GetMessage(22));
                        MPCF.ShowMsgBox(MPCF.GetMessage(633)); //No data to delete.
                        return false;
                    }

                    break;
            }

            return true;            
        }

        //
        // ViewEquipmentList()
        //       - View Equipment List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewEquipmentList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            ListViewItem itmX;

            try
            {
                MPCF.ClearList(lisView);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '7';

                in_node.AddString("EQUIP_TYPE", cdvViewEquipType.Text);
                in_node.AddString("USE_DEPT", cdvViewUseDept.Text);
                in_node.AddString("MGT_DEPT", cdvViewMgtDept.Text);
                in_node.AddChar("MSA_FLAG", "Y");
                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Equipment_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                    in_node.SetString("NEXT_EQUIP_ID", out_node.GetString("NEXT_EQUIP_ID"));

                } while (in_node.GetString("NEXT_EQUIP_ID") != "");

                foreach (TRSNode out_node in out_list)
                {
                    List<TRSNode> equipment_list = out_node.GetList("EQUIPMENT_LIST");
                    foreach (TRSNode node in equipment_list)
                    {
                        itmX = new ListViewItem(MPCF.Trim(node.GetString("EQUIP_ID")));
                        itmX.SubItems.Add(MPCF.Trim(node.GetString("EQUIP_NAME")));
                        lisView.Items.Add(itmX);
                    }
                }
                lblDataCount.Text = lisView.Items.Count.ToString();
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // UpdateAnalysisPlan()
        //       - Update Analysis_Plan
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateAnalysisPlan(char c_proc_step)
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_ANALYSIS_PLAN_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_ANALYSIS_PLAN_OUT");
            TRSNode list_item;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step;

                FarPoint.Win.Spread.SheetView with_1 =  spdAnaPlanList.ActiveSheet;
                for (int i = 0; i < with_1.RowCount; i++)
                {
                    if (Convert.ToBoolean(with_1.Cells[i, (int)PLAN_LIST.CHECK].Value) == true)
                    {
                        list_item = in_node.AddNode("DELETE_PLAN_LIST");
                        list_item.AddString("ANA_ID", MPCF.Trim(with_1.Cells[i, (int)PLAN_LIST.ANA_ID].Value));
                    }
                }

                if (MPCR.CallService("CMMS", "CMMS_Update_Analysis_Plan", in_node, ref out_node) == false)
                {
                    return false;
                }

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
        // CMMSViewAnalysisPlanList()
        //       - View Analysis_Plan List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewAnalysisPlanList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_ANALYSIS_PLAN_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            //ListViewItem itmX;
            try
            {
                MPCF.ClearList(spdAnaPlanList);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("EQUIP_ID", txtEquipCode.Text);
                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_ANALYSIS_PLAN_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Analysis_Plan_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                foreach(TRSNode out_node in out_list)
                {
                    FarPoint.Win.Spread.SheetView with_1 = spdAnaPlanList.ActiveSheet;
                    int i = 0;

                    List<TRSNode> plan_list = out_node.GetList("ANALYSIS_PLAN_LIST");
                    foreach (TRSNode node in plan_list)
                    {
                        with_1.RowCount = i + 1;
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.CHECK), false);
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.ANA_ID), node.GetString("ANA_ID"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.PLAN_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.ANA_STATUS), node.GetString("ANA_STATUS") + ":" + node.GetString("ANA_STATUS_DESC"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.ANA_DIV), node.GetChar("ANA_DIV").ToString() + ":" + node.GetString("ANA_DIV_DESC"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.SAMPLE_CODE), node.GetString("SAMPLE_CODE"));
                        i++;
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

        private void frmMMSMeasuringPlanSetup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');
                spdAnaPlanList.ActiveSheet.RowCount = 0;
                //SetGroupCmfItem();

                btnRefresh.PerformClick();

                // TODO
                b_load_flag = true;
            }
        }


        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisView, this.Text, "");
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                ViewEquipmentList();
                lblDataCount.Text = lisView.Items.Count.ToString();
                if (lisView.Items.Count > 0)
                {
                    MPCF.FindListItem(lisView, txtEquipCode.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisView, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisView, txtFind.Text, 0, true, false);
        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (CheckCondition("CREATE") == false) return;

            //    //if (UpdateMms(MPGC.MP_STEP_CREATE) == false)
            //    //{
            //    //    return;
            //    //}
            //    if (MPGV.gbListAutoRefresh == true)
            //    {
            //        btnRefresh.PerformClick();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMsgBox(ex.Message);
            //}
        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            //try
            //{
            //    if (CheckCondition("UPDATE") == false) return;

            //    //if (UpdateMms(MPGC.MP_STEP_UPDATE) == false)
            //    //{
            //    //    return;
            //    //}
            //    if (MPGV.gbListAutoRefresh == true)
            //    {
            //        btnRefresh.PerformClick();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMsgBox(ex.Message);
            //}
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("DELETE") == false) return;
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;

                if (UpdateAnalysisPlan(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                ViewAnalysisPlanList();

                //MPCF.FieldClear(this.pnlRight);
                //if (MPGV.gbListAutoRefresh == true)
                //{
                //    btnRefresh.PerformClick();
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);
                if (lisView.SelectedItems.Count > 0)
                {
                    txtEquipCode.Text = lisView.SelectedItems[0].Text;
                    txtEquipName.Text = lisView.SelectedItems[0].SubItems[1].Text;
                    ViewAnalysisPlanList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdAnaPlanList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                switch (e.Column)
                {
                    case (int)PLAN_LIST.DETAIL:
                        FarPoint.Win.Spread.SheetView with_1 = spdAnaPlanList.ActiveSheet;
                        frmMMSAnalisisPlanPopup _popup = new frmMMSAnalisisPlanPopup();

                        _popup.EQUIP_ID = txtEquipCode.Text;
                        _popup.EQUIP_NAME = txtEquipName.Text;
                        _popup.PLAN_DATE = MPCF.Trim(with_1.GetValue(e.Row, (int)PLAN_LIST.PLAN_DATE));
                        _popup.ANA_ID = MPCF.Trim(with_1.GetValue(e.Row, (int)PLAN_LIST.ANA_ID));

                        if (MPCF.Trim(with_1.GetValue(e.Row, (int)PLAN_LIST.ANA_STATUS)).Substring(0, 1) != "0")
                        {
                            _popup.ENABLE_FLAG = false;
                        }
                        else
                        {
                            _popup.ENABLE_FLAG = true;
                        }
                        
 
                        _popup.StartPosition = FormStartPosition.CenterParent;
                        _popup.ControlBox = false;
                        if (_popup.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            ViewAnalysisPlanList();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnAnaPlanAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(txtEquipCode.Text) == "") return;

                FarPoint.Win.Spread.SheetView with_1 = spdAnaPlanList.ActiveSheet;
                frmMMSAnalisisPlanPopup _popup = new frmMMSAnalisisPlanPopup();

                _popup.EQUIP_ID = txtEquipCode.Text;
                _popup.EQUIP_NAME = txtEquipName.Text;
                _popup.ENABLE_FLAG = true;
                _popup.StartPosition = FormStartPosition.CenterParent;
                _popup.ControlBox = false;
                if (_popup.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ViewAnalysisPlanList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void chkAnaPlanAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < spdAnaPlanList.ActiveSheet.RowCount; i++)
                {
                    spdAnaPlanList.ActiveSheet.SetValue(i, (int)PLAN_LIST.CHECK, chkAnaPlanAll.Checked);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewUseDept_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewUseDept.Init();
                MPCF.InitListView(cdvViewUseDept.GetListView);
                cdvViewUseDept.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewUseDept.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewUseDept.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewUseDept.GetListView, '1', MPGC.MP_GCM_MMS_DEPT_CODE) == true)
                {
                    cdvViewUseDept.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewMgtDept_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewMgtDept.Init();
                MPCF.InitListView(cdvViewMgtDept.GetListView);
                cdvViewMgtDept.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewMgtDept.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewMgtDept.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewMgtDept.GetListView, '1', MPGC.MP_GCM_MMS_DEPT_CODE) == true)
                {
                    cdvViewMgtDept.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewMgtDept_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(pnlRight);
            ViewEquipmentList();
        }

        private void cdvViewUseDept_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(pnlRight);
            ViewEquipmentList();
        }

        private void cdvViewEquipType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewEquipType.Init();
                MPCF.InitListView(cdvViewEquipType.GetListView);
                cdvViewEquipType.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewEquipType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewEquipType.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewEquipType.GetListView, '1', MPGC.MP_GCM_MMS_EQUIP_TYPE) == true)
                {
                    cdvViewEquipType.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewEquipType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(pnlRight);
            ViewEquipmentList();
        }

       
    }
}
