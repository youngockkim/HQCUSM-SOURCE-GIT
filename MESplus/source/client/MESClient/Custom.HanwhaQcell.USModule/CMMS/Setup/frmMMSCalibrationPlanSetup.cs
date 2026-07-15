//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSCalibrationPlanSetup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewCmms() : View Cmms definition
//       - UpdateCmms() : Create/Update/Delete Cmms
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-03-29 16:14:46 : XXXX Created by generator in DEV Tools
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
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmMMSCalibrationPlanSetup : SetupForm02
    {
        public frmMMSCalibrationPlanSetup()
        {
            InitializeComponent();

            //Button 초기화 
            btnCreate.Visible = false;
            btnDelete.Visible = false;
            btnUpdate.Text = "Save";
            dtpCaliPlanDate.Checked = false;
        }


        #region " Constant Definition "






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
                    dtpCaliPlanDate.Checked = false;
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

                    //if (dtpCaliPlanDate.Checked != false)
                    //{
                    //    return false;
                    //}

                    //if (dtpCaliPlanDate.Value < DateTime.Now)
                    //{
                    //    return false;
                    //}
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
                    break;
            }

            return true;            
        }

        //
        // UpdateCalibrationPlan()
        //       - Update Calibration_Plan
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateCalibrationPlan()
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_CALIBRATION_PLAN_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_CALIBRATION_PLAN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("EQUIP_ID", txtEquipCode.Text);
                if (dtpCaliPlanDate.Checked == true)
                    in_node.AddString("PLAN_DATE", dtpCaliPlanDate.Value.ToString("yyyyMMdd"));

                in_node.AddString("CALI_INSTITUTE", cdvCaliInstitute.Text);
                in_node.AddString("CALI_METHOD", txtCaliMethod.Text);
                in_node.AddString("FILE_NAME", cdvCaliPlanDoc.Text);

                if (MPCF.Trim(cdvCaliPlanDoc.GetTextBox.Tag).Equals("U"))
                {
                    if (cdvCaliPlanDoc.Tag != null)
                    {
                        byte[] file_buffer = (byte[])cdvCaliPlanDoc.Tag;
                        in_node.AddBlob(MPGC.MP_BIN_DATA_1, file_buffer);
                    }
                }

                if (chkAlarmFlag.Checked == true)
                {
                    in_node.AddChar("ALARM_FLAG", 'Y');
                    in_node.AddString("ALARM_CODE", cdvAlarmCode.Text);
                    in_node.AddInt("ALARM_PERIOD", nudAlarmPeriod.Value);
                }
                else
                {
                    in_node.AddChar("ALARM_FLAG", 'N');
                }
                if (MPCR.CallService("CMMS", "CMMS_Update_Calibration_Plan", in_node, ref out_node) == false)
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
                in_node.ProcStep = '6';

                in_node.AddString("EQUIP_TYPE", cdvViewEquipType.Text);
                in_node.AddString("USE_DEPT", cdvViewUseDept.Text);
                in_node.AddString("MGT_DEPT", cdvViewMgtDept.Text);
                in_node.AddChar("CALI_FLAG", "Y");
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


        ////
        //// ViewCalibrationPlanList()
        ////       - View Calibration_Plan List
        //// Return Value
        ////       - Boolean : True or False
        //// Arguments
        ////       -
        ////
        //private bool ViewCalibrationPlanList()
        //{
        //    TRSNode in_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LIST_IN");
        //    List<TRSNode> out_list = new List<TRSNode>();
        //    ListViewItem itmX;

        //    try
        //    {
        //        MPCF.ClearList(lisView);

        //        MPCR.SetInMsg(in_node);
        //        in_node.ProcStep = '3';

        //        in_node.AddString("USE_DEPT", cdvViewUseDept.Text);
        //        in_node.AddString("MGT_DEPT", cdvViewMgtDept.Text);

        //        do
        //        {
        //            TRSNode out_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LIST_OUT");

        //            if (MPCR.CallService("CMMS", "CMMS_View_Equipment_List", in_node, ref out_node) == false)
        //            {
        //                return false;
        //            }

        //            out_list.Add(out_node);

        //            in_node.SetString("NEXT_EQUIP_ID", out_node.GetString("NEXT_EQUIP_ID"));

        //        } while (in_node.GetString("NEXT_EQUIP_ID") != "");

        //        foreach (TRSNode out_node in out_list)
        //        {
        //            List<TRSNode> equipment_list = out_node.GetList("EQUIPMENT_LIST");
        //            foreach (TRSNode node in equipment_list)
        //            {
        //                itmX = new ListViewItem(MPCF.Trim(node.GetString("EQUIP_ID")));
        //                itmX.SubItems.Add(MPCF.Trim(node.GetString("EQUIP_NAME")));
        //                lisView.Items.Add(itmX);
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //        return false;
        //    }
        //}

        //
        // ViewCalibrationPlan()
        //       - View Calibration_Plan
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCalibrationPlan()
        {

            TRSNode in_node = new TRSNode("CMMS_VIEW_EQUIPMENT_IN");
            TRSNode out_node = new TRSNode("CMMS_VIEW_EQUIPMENT_OUT");
            byte[] bt_buffer;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("EQUIP_ID", txtEquipCode.Text);
                if (MPCR.CallService("CMMS", "CMMS_View_Equipment", in_node, ref out_node) == false)
                {
                    return false;
                }

                //General
                txtEquipCode.Text = out_node.GetString("EQUIP_ID");
                //txtEquipCode.Text = out_node.GetString("EQUIP_CODE");
                txtEquipName.Text = out_node.GetString("EQUIP_NAME");
                txtEquipNo.Text = out_node.GetString("EQUIP_NO");
                cdvMgtDept.Text = out_node.GetString("MGT_DEPT_CODE");
                cdvMgtDept.DescText = out_node.GetString("MGT_DEPT_NAME");                
                txtEquipModel.Text = out_node.GetString("EQUIP_MODEL");
                txtEquipSpec.Text = out_node.GetString("EQUIP_SPEC");
                txtEquipMaker.Text = out_node.GetString("EQUIP_MAKER");                
                nudCalibrationCycle.Value = out_node.GetInt("CALI_CYCLE");

                // 교정 정보 조회 
                TRSNode plan_in_node = new TRSNode("CMMS_VIEW_CALIBRATION_PLAN_IN");
                TRSNode plan_out_node = new TRSNode("CMMS_VIEW_CALIBRATION_PLAN_OUT");
                
                MPCR.SetInMsg(plan_in_node);
                plan_in_node.ProcStep = '1';
                
                plan_in_node.AddString("EQUIP_ID", txtEquipCode.Text);
                
                if (MPCR.CallService("CMMS", "CMMS_View_Calibration_Plan", plan_in_node, ref plan_out_node) == false)
                {
                    return false;
                }
                txtLastCaliDate.Text = MPCF.MakeDateFormat(plan_out_node.GetString("CALI_DATE"));

                if (MPCF.Trim(plan_out_node.GetString("PLAN_DATE")) != "")
                {                    
                    dtpCaliPlanDate.Value = MPCF.ToDate(plan_out_node.GetString("PLAN_DATE"));
                    dtpCaliPlanDate.Checked = true;
                }
                else
                {

                    dtpCaliPlanDate.Value = DateTime.Now;
                    dtpCaliPlanDate.Checked = false;
                }

                cdvCaliInstitute.Text = plan_out_node.GetString("CALI_INSTITUTE");
                cdvCaliInstitute.DescText = plan_out_node.GetString("CALI_INSTITUTE_NAME");

                txtCaliMethod.Text = plan_out_node.GetString("CALI_METHOD");
                cdvCaliPlanDoc.Text = plan_out_node.GetString("FILE_NAME");
                chkAlarmFlag.Checked = (plan_out_node.GetChar("ALARM_FLAG") == 'Y' ? true : false);
                nudAlarmPeriod.Value = plan_out_node.GetInt("ALARM_PERIOD");
                cdvAlarmCode.Text = plan_out_node.GetString("ALARM_CODE");
                cdvAlarmCode.DescText = plan_out_node.GetString("ALARM_CODE_NAME");
                
                txtCreateUser.Text = plan_out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(plan_out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = plan_out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(plan_out_node.GetString("UPDATE_TIME"));

                if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
                {
                    HQCF.SetAttachedFile(cdvCaliPlanDoc, bt_buffer, "");
                }
                else
                {
                    cdvCaliPlanDoc.GetTextBox.Tag = "";
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

        private void frmMMSCalibrationPlanSetup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');
               // SetGroupCmfItem();

                btnRefresh.PerformClick();

                // TODO
                b_load_flag = true;
            }
        }

        private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {            
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
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
            try
            {
                //if (CheckCondition("CREATE") == false) return;

                //if (UpdateCalibrationPlan() == false)
                //{
                //    return;
                //}
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

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("UPDATE") == false) return;

                if (UpdateCalibrationPlan() == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    ViewCalibrationPlan();
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
                //if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
                //if (CheckCondition("DELETE") == false) return;

                //if (UpdateCmms(MPGC.MP_STEP_DELETE) == false)
                //{
                //    return;
                //}

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

        private void lisView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);
                if (lisView.SelectedItems.Count > 0)
                {
                    txtEquipCode.Text = lisView.SelectedItems[0].Text;
                    txtEquipName.Text = lisView.SelectedItems[0].SubItems[1].Text;
                    ViewCalibrationPlan();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvViewControl_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.ClearList(grbMain);
            ViewEquipmentList();
        }

        private void cdvCaliInstitute_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvCaliInstitute.Init();
                MPCF.InitListView(cdvCaliInstitute.GetListView);
                cdvCaliInstitute.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvCaliInstitute.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvCaliInstitute.SelectedSubItemIndex = 0;
                if(HQCF.ViewCalibrationInstituteList(cdvCaliInstitute.GetListView, '3', ' ', 'Y') == true)
                {
                    cdvCaliInstitute.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkAlarmFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAlarmFlag.Checked == true)
                {
                    nudAlarmPeriod.Enabled = true;
                    cdvAlarmCode.Enabled = true;
                }
                else
                {
                    nudAlarmPeriod.Value = 0;
                    cdvAlarmCode.Text = "";
                    cdvAlarmCode.DescText = "";
                    nudAlarmPeriod.Enabled = false;
                    cdvAlarmCode.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvAlarmCode_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvAlarmCode.Init();
                MPCF.InitListView(cdvAlarmCode.GetListView);
                cdvAlarmCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvAlarmCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvAlarmCode.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvAlarmCode.GetListView, '1', MPGC.MP_GCM_MMS_ALARM_CODE) == true)
                {
                    cdvAlarmCode.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCaliPlanDoc_ButtonPress(object sender, EventArgs e)
        {
            //Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            System.IO.FileInfo finfo;
            System.Windows.Forms.OpenFileDialog ofdFile;

            try
            {
                ofdFile = new OpenFileDialog();
                ofdFile.Filter = "All File(*.*)|*.*";
                ofdFile.FileName = "";

                if (ofdFile.ShowDialog() == DialogResult.OK)
                {
                    finfo = new System.IO.FileInfo(ofdFile.FileName);

                    if (MPCF.ByteLen(finfo.Name) > cdvCaliPlanDoc.MaxLength)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(621)); //File name is too long.
                        return;
                    }

                    if (finfo.Exists == true)
                        HQCF.SetAttachedFile(cdvCaliPlanDoc, finfo, "U");

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            HQCF.OpenAttachedFile(cdvCaliPlanDoc);
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
            MPCF.ClearList(grbMain);
            ViewEquipmentList();
        }

    }
}
