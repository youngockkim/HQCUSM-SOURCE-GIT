//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmViewAuditResult.cs
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
    public partial class frmViewAuditResult : ViewForm01
    {
        public frmViewAuditResult()
        {
            InitializeComponent();
        }


        #region " Constant Definition "
        private enum VIEW_LIST : int
        {            
            AUDIT_ID,
            AUDIT_DESC,
            PLAN_DATE,
            CUST_CODE,
            CUST_NAME,
            AUDITOR,
            MGR_ID,
            MGR_NAME,
            AGENDA,
            AUDIT_DATE,
            STATUS,
            STATUS_DESC,
            DOCUMENT,
            ITEM_DIV,
            ITEM_DIV_DESC,
            ITEM_NAME,
            CHK_DETAIL,
            CHK_RESULT,
            FILE_NAME,
            ACT_MGR_ID,
            ACT_MGR_NAME,
            ACT_LIMIT_DT,
            ACT_DATE,
            ACT_USER_ID,
            ACT_USER_NAME,            
            ACT_RESULT,
            ACT_FILE_NAME,
            ACT_REMARKS
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

       
        private bool GetServerFile(char c_proc_step, string s_audit_id, string s_item_divi, string s_item_name, string s_file_name)
        {
            TRSNode in_node = new TRSNode("CAMS_VIEW_AUDIT_RESULT_IN");
            TRSNode out_node = new TRSNode("CAMS_VIEW_AUDIT_RESULT_OUT");
            byte[] bt_buffer;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_proc_step; // '7':CAMSADTRST.CMF_1, '8':CAMSADTITM.FILE_NAME, '9':CAMSADTITM.ACTION_FILE_NAME
                in_node.AddString("AUDIT_ID", s_audit_id);
                in_node.AddString("ITEM_DIVISION", s_item_divi);
                in_node.AddString("ITEM_NAME", s_item_name);
                in_node.AddString("FILE_NAME", s_file_name);

                if (MPCR.CallService("CAMS", "CAMS_View_Audit_Result", in_node, ref out_node) == false)
                {
                    return false;
                }

                if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
                {
                    s_file_name = Environment.GetEnvironmentVariable("TEMP") + "\\" + s_file_name;
                    try
                    {
                        System.IO.FileStream fs = System.IO.File.Open(s_file_name, System.IO.FileMode.Create);
                        System.IO.BinaryWriter writer = new System.IO.BinaryWriter(fs);
                        writer.Write(bt_buffer, 0, bt_buffer.Length);
                        writer.Close();

                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.StartInfo.FileName = s_file_name;
                        proc.Start();
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
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
            TRSNode in_node = new TRSNode("CAMS_VIEW_CAMS_JOIN_LIST_IN");
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
                    TRSNode out_node = new TRSNode("CAMS_VIEW_CAMS_JOIN_LIST_OUT");

                    if (MPCR.CallService("CAMS", "CAMS_View_Cams_Join_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);


                FarPoint.Win.Spread.SheetView with_1 = this.spdAuditList.ActiveSheet;
                int i = 0;

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> cams_join_list = out_node.GetList("CAMS_JOIN_LIST");
                    foreach (TRSNode node in cams_join_list)
                    {
                        with_1.RowCount = i + 1;                        
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.AUDIT_ID), node.GetString("AUDIT_ID"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.AUDIT_DESC), node.GetString("AUDIT_DESC"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.PLAN_DATE), node.GetString("PLAN_DATE"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.CUST_CODE), node.GetString("CUSTOMER_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.CUST_NAME), node.GetString("CUSTOMER_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.AUDITOR), node.GetString("AUDITOR"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.MGR_ID), node.GetString("MANAGER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.MGR_NAME), node.GetString("MANAGER_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.AGENDA), node.GetString("AGENDA"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.AUDIT_DATE), node.GetString("AUDIT_DATE"));
                        //with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.RESULT), node.GetString("RESULT"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.STATUS), node.GetChar("STATUS"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.STATUS_DESC), node.GetString("STATUS_DESC"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.DOCUMENT), node.GetString("DOCUMENT")); //2023.09.28 완료 문서 첨부 기능 추가로 인한 수정   
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ITEM_DIV), node.GetString("ITEM_DIVISION"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ITEM_DIV_DESC), node.GetString("ITEM_DIV_DESC"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ITEM_NAME), node.GetString("ITEM_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.CHK_DETAIL), node.GetString("CHECK_DETAIL"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.CHK_RESULT), node.GetString("CHECK_RESULT"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.FILE_NAME), node.GetString("FILE_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ACT_MGR_ID), node.GetString("ACTION_MGR_ID"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ACT_MGR_NAME), node.GetString("ACTION_MGR_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ACT_LIMIT_DT), node.GetString("ACTION_LIMIT_DATE"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ACT_DATE), node.GetString("ACTION_DATE"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ACT_USER_ID), node.GetString("ACTION_USER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ACT_USER_NAME), node.GetString("ACTION_USER_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ACT_FILE_NAME), node.GetString("ACTION_FILE_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ACT_RESULT), node.GetString("ACTION_RESULT"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ACT_REMARKS), node.GetString("REMARKS"));
                        i++;
                    }
                }

                with_1.Columns[MPCF.ToInt(VIEW_LIST.AUDIT_ID), MPCF.ToInt(VIEW_LIST.DOCUMENT)].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        private void frmViewAuditResult_Activated(object sender, System.EventArgs e)
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
            Custom.Common.HQCE.ExportToExcel(spdAuditList , this.Text, sCond, true, true, true, -1, -1, 0, false);     
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

        private void spdAuditList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                string s_audit_id = "";
                string s_item_div = "";
                string s_item_name = "";
                string s_file_name = "";

                FarPoint.Win.Spread.SheetView with_1 = this.spdAuditList.ActiveSheet;

                switch (e.Column)
                {
                    case (int)VIEW_LIST.DOCUMENT:
                        if (MPCF.Trim(with_1.GetValue(e.Row, (int)VIEW_LIST.DOCUMENT).ToString()) !="")
                        {
                            GetServerFile('7', with_1.GetValue(e.Row, (int)VIEW_LIST.AUDIT_ID).ToString() 
                                             , with_1.GetValue(e.Row, (int)VIEW_LIST.ITEM_DIV).ToString() 
                                             , with_1.GetValue(e.Row, (int)VIEW_LIST.ITEM_NAME).ToString() 
                                             , with_1.GetValue(e.Row, (int)VIEW_LIST.DOCUMENT).ToString());
                        }

                        break;
                    case (int)VIEW_LIST.FILE_NAME:
                        if (MPCF.Trim(with_1.GetValue(e.Row, (int)VIEW_LIST.FILE_NAME).ToString()) !="")
                        {
                            GetServerFile('8', with_1.GetValue(e.Row, (int)VIEW_LIST.AUDIT_ID).ToString() 
                                             , with_1.GetValue(e.Row, (int)VIEW_LIST.ITEM_DIV).ToString() 
                                             , with_1.GetValue(e.Row, (int)VIEW_LIST.ITEM_NAME).ToString() 
                                             , with_1.GetValue(e.Row, (int)VIEW_LIST.FILE_NAME).ToString());
                        }
                        break;

                    case (int)VIEW_LIST.ACT_FILE_NAME:
                        if (MPCF.Trim(with_1.GetValue(e.Row, (int)VIEW_LIST.ACT_FILE_NAME).ToString()) !="")
                        {
                            GetServerFile('9', with_1.GetValue(e.Row, (int)VIEW_LIST.AUDIT_ID).ToString() 
                                             , with_1.GetValue(e.Row, (int)VIEW_LIST.ITEM_DIV).ToString() 
                                             , with_1.GetValue(e.Row, (int)VIEW_LIST.ITEM_NAME).ToString() 
                                             , with_1.GetValue(e.Row, (int)VIEW_LIST.ACT_FILE_NAME).ToString());
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
}
