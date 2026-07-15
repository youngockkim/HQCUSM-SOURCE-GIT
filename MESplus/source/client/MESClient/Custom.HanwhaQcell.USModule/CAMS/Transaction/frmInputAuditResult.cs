//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmInputAuditResult.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewCAMS() : View CAMS definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-05-25 14:47:59 : XXXX Created by generator in DEV Tools
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
    public partial class frmInputAuditResult : ViewForm01
    {
        public frmInputAuditResult()
        {
            InitializeComponent();
        }


        #region " Constant Definition "
        private enum PLAN_LIST : int
        {
            DETAIL,
            AUDIT_ID,
            AUDIT_DESC,
            PLAN_DATE,
            CUSTOMER_CODE,
            CUSTOMER,
            AUDITOR,
            MANAGER_ID,
            MANAGER,
            STATUS,
            STATUS_NAME,
            CREATE_TIME,
            CREATE_USER_ID,
            UPDATE_TIME,
            UPDATE_USER_ID
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
            return this.cdvCustomer;
        }

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - char c_case ("1", "2")
        //
        private void ClearData(char c_case)
        {
            try
            {
                if (c_case == '1')
                {
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
            //if (MPCF.CheckValue(txtKeyField, 1) == false)
            //{
            //    return false;
            //}

            switch (FuncName)
            {
                case "VIEW1":
                    // TODO
                    break;
                case "VIEW2":
                    // TODO
                    break;
            }

            return true;            
        }

        //
        // CAMSViewAuditPlanList()
        //       - View Audit_Plan List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewAuditPlanList()
        {
            TRSNode in_node = new TRSNode("CAMS_VIEW_AUDIT_PLAN_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();

            try
            {
                MPCF.ClearList(spdAuditList);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("FROM_DATE", dtpPlanFromDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("TO_DATE", dtpPlanToDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("CUSTOMER_CODE", cdvCustomer.Text);
                in_node.AddChar("STATUS", cdvStatus.Text);
                in_node.AddString("MANAGER_ID", cdvManager.Text);
                do
                {
                    TRSNode out_node = new TRSNode("CAMS_VIEW_AUDIT_PLAN_LIST_OUT");

                    if (MPCR.CallService("CAMS", "CAMS_View_Audit_Plan_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                FarPoint.Win.Spread.SheetView with_1 = this.spdAuditList.ActiveSheet;
                int i = 0;

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> audit_result_list = out_node.GetList("AUDIT_PLAN_LIST");
                    foreach (TRSNode node in audit_result_list)
                    {
                        with_1.RowCount = i + 1;
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.AUDIT_ID), node.GetString("AUDIT_ID"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.AUDIT_DESC), node.GetString("AUDIT_DESC"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.PLAN_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.CUSTOMER_CODE), node.GetString("CUSTOMER_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.CUSTOMER), node.GetString("CUSTOMER_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.AUDITOR), node.GetString("AUDITOR"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.MANAGER_ID), node.GetString("MANAGER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.MANAGER), node.GetString("MANAGER_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.STATUS), node.GetChar("STATUS"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.STATUS_NAME), node.GetString("STATUS_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.CREATE_TIME), MPCF.ToDate(node.GetString("CREATE_TIME")).ToString("dd/MM/yyyy h:mm:ss tt"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.CREATE_USER_ID), node.GetString("CREATE_USER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.UPDATE_TIME), MPCF.ToDate(node.GetString("UPDATE_TIME")).ToString("dd/MM/yyyy h:mm:ss tt"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.UPDATE_USER_ID), node.GetString("UPDATE_USER_ID"));

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
        
        private bool OpenAuditResultPopup(string s_audit_id)
        {
            try
            {
                frmInputAuditResultPopup _resultPopup = new frmInputAuditResultPopup();
                _resultPopup.AUDIT_ID = MPCF.Trim(s_audit_id);
                _resultPopup.StartPosition = FormStartPosition.CenterParent;
                _resultPopup.ControlBox = false;
                if (_resultPopup.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ViewAuditPlanList();
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

        private void frmInputAuditResult_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                spdAuditList.ActiveSheet.RowCount = 0;

                dtpPlanFromDate.Value = DateTime.Now.AddMonths(-1);
                dtpPlanToDate.Value = DateTime.Now.AddMonths(1); 

                // TODO
                b_load_flag = true;
            }
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == false) return;

            if (ViewAuditPlanList() == false) return;
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            sCond = "Key ID : " + MPCF.Trim(this.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpPlanFromDate)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpPlanToDate));
            Custom.Common.HQCE.ExportToExcel(spdAuditList, this.Text, sCond, true, true, true, -1, -1, 0, false);  
        }

        private void spdAuditList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                switch (e.Column)
                {
                    case (int)PLAN_LIST.DETAIL:

                        OpenAuditResultPopup(MPCF.Trim(spdAuditList.ActiveSheet.GetValue(e.Row, (int)PLAN_LIST.AUDIT_ID)));
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvManager_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvManager.Init();
                MPCF.InitListView(cdvManager.GetListView);
                cdvManager.Columns.Add("ID", 150, HorizontalAlignment.Left);
                cdvManager.Columns.Add("Name", 200, HorizontalAlignment.Left);
                cdvManager.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvManager.GetListView, '1', MPGC.MP_GCM_AMS_MANAGER) == true)
                {
                    cdvManager.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvStatus_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvStatus.Init();
                MPCF.InitListView(cdvStatus.GetListView);
                cdvStatus.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvStatus.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvStatus.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvStatus.GetListView, '1', MPGC.MP_GCM_AMS_AUDIT_STATUS) == true)
                {
                    cdvStatus.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvCustomer_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvCustomer.Init();
                MPCF.InitListView(cdvCustomer.GetListView);
                cdvCustomer.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvCustomer.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvCustomer.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvCustomer.GetListView, '1', MPGC.MP_GCM_AMS_CUSTOMER) == true)
                {
                    cdvCustomer.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


    }
}
