//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmViewJobChangeList.cs
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
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmViewJobChangeStatus : ViewForm01
    {
        public frmViewJobChangeStatus()
        {
            InitializeComponent();
        }


        #region " Constant Definition "
        private enum VIEW_LIST : int
        {            
            ORDER_ID,
            MAT_ID,
            MAT_DESC,
            LINE_ID,
            LINE_NAME, 
            ORD_START_DATE, 
            STATUS, 
            ITEM_CODE, 
            ITEM_NAME,
            AUTO_FLAG,
            RESPONSIBILITY,
            PLAN_START_DATE,
            PLAN_END_DATE,
            START_TIME,
            END_TIME,
            WORK_TIME,
            CHECK_FLAG,
            ERR_MSG
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
            return this.txtOrderNumber;
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
            TRSNode in_node = new TRSNode("CAMS_VIEW_CAMS_JOIN_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            string s_tmp_date = "";
            try
            {
                MPCF.ClearList(spdJobChangeList);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("FROM_DATE", dtpFromDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("TO_DATE", dtpToDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("ORDER_ID", txtOrderNumber.Text);
                in_node.AddString("LINE_ID", cdvLine.Text);
                in_node.AddString("MAT_ID", cdvMaterial.Text);
                do
                {
                    TRSNode out_node = new TRSNode("CJCM_VIEW_CJCM_JOIN_LIST_OUT");

                    if (MPCR.CallService("CJCM", "CJCM_View_Cjcm_Join_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);


                FarPoint.Win.Spread.SheetView with_1 = this.spdJobChangeList.ActiveSheet;
                int i = 0;

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> cams_join_list = out_node.GetList("CJCM_JOIN_LIST");
                    foreach (TRSNode node in cams_join_list)
                    {
                        with_1.RowCount = i + 1;
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ORDER_ID), node.GetString("ORDER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.MAT_ID), node.GetString("MAT_ID"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.MAT_DESC), node.GetString("MAT_DESC"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.LINE_ID), node.GetString("LINE_ID"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.LINE_NAME), node.GetString("LINE_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ORD_START_DATE), MPCF.MakeDateFormat(node.GetString("ORD_START_DATE"), DATE_TIME_FORMAT.DATE));
                        //with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.STATUS), node.GetChar("STATUS"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.STATUS), node.GetString("STATUS_DESC"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ITEM_CODE), node.GetString("ITEM_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ITEM_NAME), node.GetString("ITEM_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.AUTO_FLAG), node.GetChar("AUTO_FLAG"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.RESPONSIBILITY), node.GetString("RESPONSIBILITY"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.PLAN_START_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_START_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.PLAN_END_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_END_DATE"), DATE_TIME_FORMAT.DATE));
                        
                        if (MPCF.Trim(node.GetString("START_TIME")).Length == 14)
                            s_tmp_date = MPCF.MakeDateFormat(node.GetString("START_TIME"));
                        else
                            s_tmp_date = "";

                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.START_TIME), s_tmp_date);

                        if (MPCF.Trim(node.GetString("END_TIME")).Length == 14)
                            s_tmp_date = MPCF.MakeDateFormat(node.GetString("END_TIME"));
                        else
                            s_tmp_date = "";

                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.END_TIME), s_tmp_date);                        
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.WORK_TIME), node.GetInt("WORK_TIME"));
                        //with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.CHECK_FLAG), node.GetChar("CHECK_FLAG"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.CHECK_FLAG), node.GetString("ITEM_STATUS"));
                        with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.ERR_MSG), node.GetString("ERR_MSG"));

                        if (node.GetChar("CHECK_FLAG") == 'E')
                        {
                            with_1.Cells[i, MPCF.ToInt(VIEW_LIST.ITEM_CODE), i, MPCF.ToInt(VIEW_LIST.CHECK_FLAG)].BackColor = Color.DarkTurquoise;
                        }
                        else if (node.GetChar("CHECK_FLAG") == 'F')
                        {
                            with_1.Cells[i, MPCF.ToInt(VIEW_LIST.ITEM_CODE), i, MPCF.ToInt(VIEW_LIST.CHECK_FLAG)].BackColor = Color.Crimson;
                        }
                        else if (node.GetChar("CHECK_FLAG") == 'S')
                        {
                            with_1.Cells[i, MPCF.ToInt(VIEW_LIST.ITEM_CODE), i, MPCF.ToInt(VIEW_LIST.CHECK_FLAG)].BackColor = Color.LightCyan;
                        }

                        if (MPCF.Trim(with_1.GetValue(i, MPCF.ToInt(VIEW_LIST.END_TIME))) == "")
                        {
                            if (MPCF.ToDbl(MPCF.Trim(node.GetString("PLAN_END_DATE"))) > MPCF.ToDbl(MPCF.Mid(MPCF.Trim(node.GetString("SYS_DATE")), 1,8)))
                            {
                                with_1.SetValue(i, MPCF.ToInt(VIEW_LIST.CHECK_FLAG), "Delayed");
                                with_1.Cells[i, MPCF.ToInt(VIEW_LIST.ITEM_CODE), i, MPCF.ToInt(VIEW_LIST.CHECK_FLAG)].BackColor = Color.OrangeRed;
                            }
                        }
                        i++;
                    }
                }

                with_1.Columns[MPCF.ToInt(VIEW_LIST.ORDER_ID), MPCF.ToInt(VIEW_LIST.STATUS)].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        private void frmViewJobChangeStatus_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                spdJobChangeList.ActiveSheet.RowCount = 0;

                dtpFromDate.Value = DateTime.Now.AddMonths(-1);
                dtpToDate.Value = DateTime.Now.AddMonths(1); 

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
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFromDate)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpToDate));
            Custom.Common.HQCE.ExportToExcel(spdJobChangeList , this.Text, sCond, true, true, true, -1, -1, 0, false);     
        }
            
        private void cdvLine_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvLine.Init();
                MPCF.InitListView(cdvLine.GetListView);
                cdvLine.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvLine.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvLine.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvLine.GetListView, '1', HQGC.GCM_LINE_CODE) == true)
                {
                    cdvLine.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
}
