//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmJobChangeSetup.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewCjcm() : View Cjcm definition
//       - UpdateCjcm() : Create/Update/Delete Cjcm
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023/07/26 15:18:33 : XXXX Created by generator in DEV Tools
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
    public partial class frmJobChangeSetup : SetupForm01
    {
        public frmJobChangeSetup()
        {
            InitializeComponent();

            this.Size = new Size(1100, 750);
            btnCreate.Location = new Point((pnlBottom.Size.Width - 400), 7);
            btnUpdate.Location = new Point((pnlBottom.Size.Width - 300), 7);
            btnDelete.Location = new Point((pnlBottom.Size.Width - 200), 7);
            btnClose.Location = new Point((pnlBottom.Size.Width - 100), 7);

            FarPoint.Win.Spread.SheetView with_1 = spdJobChangeItem.ActiveSheet;
            FarPoint.Win.Spread.CellType.DateTimeCellType _cell_type = (FarPoint.Win.Spread.CellType.DateTimeCellType)with_1.Columns[MPCF.ToInt(ITEM_LIST.PLAN_START_DATE)].CellType;
            _cell_type.DateDefault = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            with_1.Columns[MPCF.ToInt(ITEM_LIST.PLAN_START_DATE)].CellType = _cell_type;
            with_1.Columns[MPCF.ToInt(ITEM_LIST.PLAN_END_DATE)].CellType = _cell_type;
        }


        #region " Constant Definition "
        private enum ORD_LIST : int
        {
            ORDER_ID = 0,
            MAT_ID,
            MAT_DESC,
            LINE_CODE,
            LINE_NAME,
            START_DATE,
            PLAN_START_DATE,
            PLAN_END_DATE,
            MANAGER,
            STATUS
        }

        private enum ITEM_LIST : int
        {
            CHECK = 0,
            ITEM_CODE,
            ITEM_BTN,
            ITEM_NAME,
            AUTO_FLAG,
            RESPONSIBILITY,
            RESPONSIBILITY_BTN,
            PLAN_START_DATE,
            PLAN_END_DATE,
            DEPT_CODE,
            ALARM_CODE
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
            return this.txtViewOrderNumber;
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
                    //cdvOrderNumber.Text = "";
                    chkNewOrder.Checked = false;
                    cdvMaterial.Text = "";
                    cdvMaterial.DescText = "";
                    cdvManager.Text = "";
                    cdvManager.DescText = "";
                    dtpPlanDateFrom.Value = DateTime.Now;
                    dtpPlanDateTo.Value = DateTime.Now;
                    cdvAlarmCode.Text = "";
                    cdvDepeCode.Text = "";
                    spdJobChangeItem.ActiveSheet.RowCount = 0;

                }
                else if (c_case == '3')
                {
                    cdvOrderNumber.Text = "";
                    cdvMaterial.Text = "";
                    cdvMaterial.DescText = "";
                    cdvManager.Text = "";
                    cdvManager.DescText = "";
                    dtpPlanDateFrom.Value = DateTime.Now;
                    dtpPlanDateTo.Value = DateTime.Now;
                    dtpOrdStartDate.Value = DateTime.Now;
                    cdvAlarmCode.Text = "";
                    cdvDepeCode.Text = "";
                    spdJobChangeItem.ActiveSheet.RowCount = 0;
                    cdvLineCode.Text = "";
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
            if (MPCF.CheckValue(cdvOrderNumber, 1) == false)
            {
                return false;
            }

            switch (FuncName)
            {
                case "CREATE":
                case "UPDATE":

                    if (MPCF.Trim(cdvLineCode.Text) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvLineCode.Focus();
                        return false;
                    }

                    if (MPCF.Trim(cdvMaterial.Text) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvMaterial.Focus();
                        return false;
                    }

                    if (MPCF.Trim(cdvDepeCode.Text) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvDepeCode.Focus();
                        return false;
                    }
                    
                    if (MPCF.Trim(cdvManager.Text) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvManager.Focus();
                        return false;
                    }

                    if (MPCF.Trim(cdvAlarmCode.Text) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvAlarmCode.Focus();
                        return false;
                    }

                    if (dtpPlanDateFrom.Value > dtpPlanDateTo.Value)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(214));
                        return false;
                    }

                    if (spdJobChangeItem.ActiveSheet.RowCount == 0)
                    {
                       MPCF.ShowMsgBox(MPCF.GetMessage(305));
                       return false;
                    }
                                        

                    FarPoint.Win.Spread.SheetView with_1 = spdJobChangeItem.ActiveSheet;

                    for (int i = 0; i < with_1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(with_1.Cells[i, (int)ITEM_LIST.CHECK].Value) == true)
                        {
                            if (MPCF.Trim(with_1.Cells[i, (int)ITEM_LIST.ITEM_CODE].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                with_1.IsSelected(i, (int)ITEM_LIST.ITEM_CODE);
                                return false;
                            }
                            if (MPCF.Trim(with_1.Cells[i, (int)ITEM_LIST.RESPONSIBILITY].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                with_1.IsSelected(i, (int)ITEM_LIST.RESPONSIBILITY);
                                return false;
                            }
                            if (MPCF.Trim(with_1.Cells[i, (int)ITEM_LIST.DEPT_CODE].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                with_1.IsSelected(i, (int)ITEM_LIST.DEPT_CODE);
                                return false;
                            }
                            if (MPCF.Trim(with_1.Cells[i, (int)ITEM_LIST.ALARM_CODE ].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                with_1.IsSelected(i, (int)ITEM_LIST.ALARM_CODE);
                                return false;
                            }
                        }
                    }

                    // TODO
                    break;
                case "DELETE":
                    // TODO
                    break;
            }

            return true;            
        }

        //
        // ViewJobChangeStatusList()
        //       - View Job_Change_Status List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewJobChangeStatusList()
        {
            TRSNode in_node = new TRSNode("CJCM_VIEW_JOB_CHANGE_STATUS_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();

            try
            {
                MPCF.ClearList(grbCalibrationPlanList);
                MPCF.ClearList(grpJobInfo);
                MPCF.ClearList(spdJobChangeItem);
                spdOrderList.ActiveSheet.RowCount = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FROM_DATE", dtpViewOrderDateFrom.Value.ToString("yyyyMMdd"));
                in_node.AddString("TO_DATE", dtpViewOrderDateTo.Value.ToString("yyyyMMdd"));
                in_node.AddString("ORDER_ID", MPCF.Trim(txtViewOrderNumber.Text));
                in_node.AddString("LINE_ID", MPCF.Trim(cdvViewLine.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvViewMaterial.Text));
                
                do
                {
                    TRSNode out_node = new TRSNode("CJCM_VIEW_JOB_CHANGE_STATUS_LIST_OUT");

                    if (MPCR.CallService("CJCM", "CJCM_View_Job_Change_Status_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                FarPoint.Win.Spread.SheetView with_1 = spdOrderList.ActiveSheet;
                int i = 0;

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> job_change_list = out_node.GetList("JOB_CHANGE_STATUS_LIST");
                    foreach (TRSNode node in job_change_list)
                    {
                        with_1.RowCount = i + 1;
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.ORDER_ID), node.GetString("ORDER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.MAT_ID), node.GetString("MAT_ID"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.MAT_DESC), node.GetString("MAT_DESC"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.LINE_CODE), node.GetString("LINE_ID"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.LINE_NAME), node.GetString("LINE_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.START_DATE), MPCF.MakeDateFormat(node.GetString("ORD_START_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.PLAN_START_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_START_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.PLAN_END_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_END_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.MANAGER), node.GetString("MANAGER_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(ORD_LIST.STATUS), node.GetChar("STATUS").ToString() + ":" + node.GetString("STATUS_DESC"));
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

        //
        // UpdateJobChangeStatus()
        //       - Update Job_Change_Status
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateJobChangeStatus(bool c_delete_flag)
        {
            TRSNode in_node = new TRSNode("CJCM_UPDATE_JOB_CHANGE_STATUS_IN");
            TRSNode out_node = new TRSNode("CJCM_UPDATE_JOB_CHANGE_STATUS_OUT");
            TRSNode list_item;

            try
            {
                MPCR.SetInMsg(in_node);
                if (c_delete_flag == true)
                {
                    in_node.ProcStep = MPGC.MP_STEP_DELETE;
                    in_node.AddString("ORDER_ID", cdvOrderNumber.Text);
                }
                else 
                {
                    in_node.ProcStep = '1';
                    in_node.AddString("ORDER_ID", cdvOrderNumber.Text);
                    in_node.AddString("MAT_ID", cdvMaterial.Text);
                    in_node.AddString("MAT_DESC", cdvMaterial.DescText);
                    in_node.AddString("MANAGER", cdvManager.Text);
                    in_node.AddString("DEPT_CODE", cdvDepeCode.Text);
                    in_node.AddString("PLAN_START_DATE", dtpPlanDateFrom.Value.ToString("yyyyMMdd"));
                    in_node.AddString("PLAN_END_DATE", dtpPlanDateTo.Value.ToString("yyyyMMdd"));
                    in_node.AddChar("STATUS", 'W');
                    in_node.AddChar("ALARM_FLAG", 'Y');
                    in_node.AddString("ALARM_CODE", cdvAlarmCode.Text);
                    in_node.AddString("ORD_START_DATE", dtpOrdStartDate.Value.ToString("yyyyMMdd"));
                    in_node.AddString("LINE_ID", cdvLineCode.Text);
                
                    FarPoint.Win.Spread.SheetView with_1 = spdJobChangeItem.ActiveSheet;

                    for (int i = 0; i < with_1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(with_1.Cells[i, (int)ITEM_LIST.CHECK].Value) == true)
                        {
                            list_item = in_node.AddNode("JOB_CHANGE_ITEM_LIST");

                            list_item.AddString("ITEM_CODE", MPCF.Trim(with_1.Cells[i, MPCF.ToInt(ITEM_LIST.ITEM_CODE)].Value));
                            list_item.AddChar("AUTO_FLAG", Convert.ToBoolean(with_1.Cells[i, (int)ITEM_LIST.AUTO_FLAG].Value) == true ? 'Y' : 'N');
                            list_item.AddString("RESPONSIBILITY", MPCF.Trim(with_1.Cells[i, MPCF.ToInt(ITEM_LIST.RESPONSIBILITY)].Value));
                            list_item.AddString("DEPT_CODE", MPCF.Trim(with_1.Cells[i, MPCF.ToInt(ITEM_LIST.DEPT_CODE)].Value));
                            list_item.AddString("ALARM_CODE", MPCF.Trim(with_1.Cells[i, MPCF.ToInt(ITEM_LIST.ALARM_CODE)].Value));
                            list_item.AddChar("STATUS", 'W');
                            DateTime _date = Convert.ToDateTime(with_1.Cells[i, (int)ITEM_LIST.PLAN_START_DATE].Value);
                            list_item.AddString("PLAN_START_DATE", _date.ToString("yyyyMMdd"));

                            _date = Convert.ToDateTime(with_1.Cells[i, (int)ITEM_LIST.PLAN_END_DATE].Value);
                            list_item.AddString("PLAN_END_DATE", _date.ToString("yyyyMMdd"));
                        }
                    }
                }

                if (MPCR.CallService("CJCM", "CJCM_Update_Job_Change_Status", in_node, ref out_node) == false)
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
        // ViewJobChangeStatus()
        //       - View Job_Change_Status
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewJobChangeStatus(char c_Step = '1')
        {
            TRSNode in_node = new TRSNode("CJCM_VIEW_JOB_CHANGE_STATUS_IN");
            TRSNode out_node = new TRSNode("CJCM_VIEW_JOB_CHANGE_STATUS_OUT");
            List<TRSNode> out_list = new List<TRSNode>();
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_Step;

                spdJobChangeItem.ActiveSheet.RowCount = 0;

                in_node.AddString("ORDER_ID", cdvOrderNumber.Text);

                if (MPCR.CallService("CJCM", "CJCM_View_Job_Change_Status", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                //cdvOrderNumber.Text = out_node.GetString("FACTORY");
                cdvOrderNumber.Text = out_node.GetString("ORDER_ID");
                cdvMaterial.Text = out_node.GetString("MAT_ID");
                cdvMaterial.DescText = out_node.GetString("MAT_DESC");
                cdvManager.Text = out_node.GetString("MANAGER");
                cdvManager.DescText = out_node.GetString("MANAGER_NAME");
                dtpPlanDateFrom.Value = MPCF.ToDate(out_node.GetString("PLAN_START_DATE"));
                dtpPlanDateTo.Value = MPCF.ToDate(out_node.GetString("PLAN_END_DATE"));
                cdvAlarmCode.Text = out_node.GetString("ALARM_CODE");
                cdvDepeCode.Text = out_node.GetString("DEPT_CODE");
                dtpOrdStartDate.Value = MPCF.ToDate(out_node.GetString("ORD_START_DATE"));
                cdvLineCode.Text = out_node.GetString("LINE_ID");

                cdvMaterial.Text = out_node.GetString("MAT_ID");
                cdvMaterial.DescText = out_node.GetString("MAT_DESC");

                FarPoint.Win.Spread.SheetView with_1 = spdJobChangeItem.ActiveSheet;
                int i = 0;

                List<TRSNode> job_item_list = out_node.GetList("JOB_ITEM_LIST");
                foreach (TRSNode node in job_item_list)
                {
                    with_1.RowCount = i + 1;
                    with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.CHECK), false);
                    with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.ITEM_CODE), node.GetString("ITEM_CODE"));
                    with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.ITEM_NAME), node.GetString("ITEM_NAME"));
                    with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.AUTO_FLAG), (node.GetChar("AUTO_FLAG") == 'Y' ? true: false));
                    with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.RESPONSIBILITY), node.GetString("RESPONSIBILITY"));
                    with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.PLAN_START_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_START_DATE"), DATE_TIME_FORMAT.DATE));
                    with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.PLAN_END_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_END_DATE"), DATE_TIME_FORMAT.DATE));
                    with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.DEPT_CODE), node.GetString("DEPT_CODE"));
                    with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.ALARM_CODE), node.GetString("ALARM_CODE"));
                    i++;                    
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
        // ViewJobChangeStatus()
        //       - View Job_Change_Status
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewJobChangeItemInfo(string c_item_code, int i_row)
        {
            TRSNode in_node = new TRSNode("CJCM_VIEW_JOB_CHANGE_ITEM_IN");
            TRSNode out_node = new TRSNode("CJCM_VIEW_JOB_CHANGE_iTEM_OUT");
            List<TRSNode> out_list = new List<TRSNode>();
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';

               // spdJobChangeItem.ActiveSheet.RowCount = 0;

                in_node.AddString("ITEM_CODE", c_item_code);
                in_node.AddString("LINE_CODE", MPCF.Trim(cdvLineCode.Text));
                if (MPCR.CallService("CJCM", "CJCM_View_Setup_Job_Change_Item", in_node, ref out_node) == false)
                {
                    return false;
                }

                DateTime _tmp_date = dtpOrdStartDate.Value;
                string s_start_date = "";
                string s_end_date = "";
                s_start_date = _tmp_date.AddDays(out_node.GetInt("PLAN_START_DAYS_BEFORE") * -1).ToShortDateString();
                s_end_date = _tmp_date.AddDays(out_node.GetInt("PLAN_END_DAYS_BEFORE") * -1).ToShortDateString();

                spdJobChangeItem.ActiveSheet.SetValue(i_row, (int)ITEM_LIST.AUTO_FLAG, out_node.GetChar("AUTO_FLAG") == 'Y' ? true:false);
                spdJobChangeItem.ActiveSheet.SetValue(i_row, (int)ITEM_LIST.RESPONSIBILITY, out_node.GetString("RESPONSIBILITY_ID"));
                spdJobChangeItem.ActiveSheet.SetValue(i_row, (int)ITEM_LIST.ALARM_CODE, out_node.GetString("ALARM_CODE"));
                spdJobChangeItem.ActiveSheet.SetValue(i_row, (int)ITEM_LIST.PLAN_START_DATE, s_start_date);
                spdJobChangeItem.ActiveSheet.SetValue(i_row, (int)ITEM_LIST.PLAN_END_DATE, s_end_date);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void GetJobChangeItemResponsibility(string c_dept_code, int i_row)
        {
            try
            {
                if (MPCF.Trim(cdvLineCode.Text) == "") return;

                TRSNode in_node = new TRSNode("SQL_IN");
                TRSNode out_node = new TRSNode("SQL_OUT");
                StringBuilder sb;


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                sb = new StringBuilder();

                sb.Append("SELECT KEY_1, KEY_2, DATA_1 ");
                sb.Append("  FROM MGCMTBLDAT ");
                sb.Append(" WHERE FACTORY = '" + MPGV.gsFactory + "' AND TABLE_NAME = '@JCM_RESPONSIBILITY' ");
                sb.Append("  AND A.KEY_1 = '" + MPCF.Trim(cdvLineCode.Text) + "' ");
                sb.Append("  AND A.KEY_2 = '" + MPCF.Trim(c_dept_code) + "' ");
                in_node.AddString("SQL", sb.ToString());

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return;
                }

                if (out_node.GetList("ROWS").Count > 0)
                {
                    if (out_node.GetList("ROWS")[0].GetList("COLS").Count > 0)
                    {
                        spdJobChangeItem.ActiveSheet.SetValue(i_row, (int)ITEM_LIST.RESPONSIBILITY, out_node.GetList("ROWS")[0].GetList("COLS")[2].GetString("DATA"));
                    }
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        private void frmJobChangeSetup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');
                spdJobChangeItem.ActiveSheet.RowCount = 0;
                spdOrderList.ActiveSheet.RowCount = 0;

                dtpViewOrderDateFrom.Value = DateTime.Now.AddDays(-10);
                dtpViewOrderDateTo.Value = DateTime.Now.AddMonths(1);

                // TODO
                b_load_flag = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //View Btn ·Î »ç¿ë 
            ViewJobChangeStatusList();

        }

        private void spdOrderList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {

                if (e.Range.Row < 0) return;

                FarPoint.Win.Spread.SheetView with_1 = spdOrderList.ActiveSheet;

                MPCF.ClearList(grpJobInfo);
                spdJobChangeItem.ActiveSheet.RowCount = 0;

                cdvOrderNumber.Text = MPCF.Trim(with_1.GetValue(e.Range.Row, MPCF.ToInt(ORD_LIST.ORDER_ID)));
                
                ViewJobChangeStatus();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvLine_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvViewLine.Init();
                MPCF.InitListView(cdvViewLine.GetListView);
                cdvViewLine.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvViewLine.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvViewLine.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvViewLine.GetListView, '1', HQGC.GCM_LINE_CODE) == true)
                {
                    cdvViewLine.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvMaterial_ButtonPress(object sender, EventArgs e)
        {
            cdvViewMaterial.Init();
            MPCF.InitListView(cdvViewMaterial.MaterialGetListView);
            cdvViewMaterial.MaterialColumns.Add("Material", 50, HorizontalAlignment.Left);
            cdvViewMaterial.MaterialColumns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvViewMaterial.SelectedSubItemIndex = 0;
            WIPLIST.ViewMaterialList(cdvViewMaterial.MaterialGetListView, '1', "P");
        }

        private void spdJobChangeItem_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                switch (e.Column)
                {
                    case (int)ITEM_LIST.ITEM_BTN:
                        cdvDataList.Init();
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("Item Code", 200, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Description", 300, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("DeptCode", 100, HorizontalAlignment.Left);

                        if (HQCF.ViewJCMItemList(cdvDataList.GetListView) == true)
                        {
                            cdvDataList.InsertEmptyRow(0, 1);
                        }

                        if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
                        {
                            return;
                        }
                        break;

                    case (int)ITEM_LIST.RESPONSIBILITY_BTN:

                        cdvDataList.Init();
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Dept", 100, HorizontalAlignment.Left);

                        if (BASLIST.ViewGCMDataList(cdvDataList.GetListView, '1', "@JCM_USER_INFO") == true)
                        {
                            cdvDataList.InsertEmptyRow(0, 1);
                        }

                        if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
                        {
                            return;
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvDataList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdJobChangeItem.ActiveSheet;
                switch (e.Col)
                {
                    case (int)ITEM_LIST.ITEM_CODE:
                        for (int i = 0; i < with_1.RowCount; i++)
                        {
                            if (e.Row != i)
                            {
                                if (MPCF.Trim(e.SelectedItem.SubItems[0].Text).Equals(MPCF.Trim(with_1.GetValue(i, e.Col))))
                                {
                                    if (MPCF.Trim(spdJobChangeItem.ActiveSheet.GetTag(i, (int)ITEM_LIST.CHECK)) == "D")
                                    {
                                        spdJobChangeItem.ActiveSheet.SetValue(i, (int)ITEM_LIST.CHECK, true);
                                        spdJobChangeItem.ActiveSheet.SetTag(i, (int)ITEM_LIST.CHECK, "U");
                                        spdJobChangeItem.ActiveSheet.Rows[i].Visible = true;
                                    }
                                    else
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(276));
                                        return;
                                    }
                                }
                            }
                        }
                        spdJobChangeItem.ActiveSheet.SetValue(e.Row, e.Col, e.SelectedItem.SubItems[0].Text);
                        spdJobChangeItem.ActiveSheet.SetValue(e.Row, e.Col + 2, e.SelectedItem.SubItems[1].Text);
                        spdJobChangeItem.ActiveSheet.SetValue(e.Row, (int)ITEM_LIST.DEPT_CODE, e.SelectedItem.SubItems[2].Text);
                        spdJobChangeItem.ActiveSheet.SetValue(e.Row, (int)ITEM_LIST.CHECK, true);
                        ViewJobChangeItemInfo(e.SelectedItem.SubItems[0].Text, e.Row);
                        break;

                    case (int)ITEM_LIST.RESPONSIBILITY:
                        spdJobChangeItem.ActiveSheet.SetValue(e.Row, e.Col, e.SelectedItem.SubItems[0].Text);
                        spdJobChangeItem.ActiveSheet.SetValue(e.Row,(int)ITEM_LIST.DEPT_CODE, e.SelectedItem.SubItems[2].Text);
                        spdJobChangeItem.ActiveSheet.SetValue(e.Row, (int)ITEM_LIST.CHECK, true);
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvOrderNumber_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                frmViewOrderPopup _frm = new frmViewOrderPopup();
                _frm.ORDER_ID = cdvOrderNumber.Text;
                if (_frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ClearData('2');
                    cdvOrderNumber.Text = _frm.ORDER_ID;
                    ViewJobChangeStatus('2');

                    if (MPCF.Trim(cdvOrderNumber.Text) == "")
                    {
                        cdvOrderNumber.Text = _frm.ORDER_ID;
                        cdvMaterial.Text = _frm.MAT_ID;
                        cdvMaterial.DescText = _frm.MAT_DESC;
                        cdvManager.Text = _frm.MANAGER_ID;
                        cdvManager.DescText = _frm.MANAGER_NAME;
                        cdvAlarmCode.Text = _frm.ALARM_CODE;
                        cdvDepeCode.Text = _frm.DEPT;
                        cdvLineCode.Text = _frm.LINE_CODE;
                        dtpOrdStartDate.Value = MPCF.ToDate(_frm.START_DATE);

                        if (MPCF.Trim(cdvManager.Text) == "" || MPCF.Trim(cdvLineCode.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(638) + "[@JCM_LINE_MANAGER][@JCM_USER_INFO]");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int i = spdJobChangeItem.ActiveSheet.RowCount;
            spdJobChangeItem.ActiveSheet.RowCount++;
            spdJobChangeItem.ActiveSheet.SetValue(i, (int)ITEM_LIST.CHECK, true);
            spdJobChangeItem.ActiveSheet.SetTag(i, (int)ITEM_LIST.CHECK, "I");
        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = spdJobChangeItem.ActiveSheet.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToBoolean(spdJobChangeItem.ActiveSheet.GetValue(i, (int)ITEM_LIST.CHECK)) == true)
                    {
                        if (spdJobChangeItem.ActiveSheet.GetTag(i, (int)ITEM_LIST.CHECK).ToString() == "I")
                        {
                            spdJobChangeItem.ActiveSheet.Rows[i].Remove();
                        }
                        else
                        {
                            spdJobChangeItem.ActiveSheet.SetValue(i, (int)ITEM_LIST.CHECK, true);
                            spdJobChangeItem.ActiveSheet.SetTag(i, (int)ITEM_LIST.CHECK, "D");
                            spdJobChangeItem.ActiveSheet.Rows[i].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (CheckCondition("UPDATE") == false) return;

                if (UpdateJobChangeStatus(false) == false)
                {
                    return;
                }
                ViewJobChangeStatus();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;
                if (CheckCondition("DELETE") == false) return;

                if (UpdateJobChangeStatus(true) == false)
                {
                    return;
                }
                ViewJobChangeStatusList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdJobChangeItem_SubEditorClosed(object sender, FarPoint.Win.Spread.SubEditorClosedEventArgs e)
        {
            spdJobChangeItem.ActiveSheet.SetValue(e.Row, (int)ITEM_LIST.CHECK, true);
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
                if (BASLIST.ViewGCMDataList(cdvAlarmCode.GetListView, '1', "ALARM_CODE") == true)
                {
                    cdvAlarmCode.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkNewOrder_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ClearData('3');
                if (chkNewOrder.Checked == true)
                {                    
                    cdvOrderNumber.Text =  DateTime.Now.ToString("yyMMddHHmmss") + "J";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvDepeCode_ButtonPress(object sender, EventArgs e)
        {

            try
            {
                if (MPCF.Trim(cdvLineCode.Text) == "")
                {
                    return;
                }
                string[] sTemp = new string[1];
                sTemp[0] = MPCF.Trim(cdvLineCode.Text);
                cdvDepeCode.Init();
                MPCF.InitListView(cdvDepeCode.GetListView);
                cdvDepeCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvDepeCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvDepeCode.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvDepeCode.GetListView, '1', "@DEPT_CODE", (int)SMALLICON_INDEX.IDX_MESSAGE, null, MPGV.gsFactory, false, 0, 0, null, sTemp) == true)
                {
                    cdvDepeCode.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvLineCode_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvLineCode.Init();
                MPCF.InitListView(cdvLineCode.GetListView);
                cdvLineCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvLineCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvLineCode.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvLineCode.GetListView, '1', "@LINE_CODE") == true)
                {
                    cdvLineCode.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvLineCode_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("SQL_IN");
                TRSNode out_node = new TRSNode("SQL_OUT");
                StringBuilder sb;


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                sb = new StringBuilder();

                sb.Append("SELECT A.KEY_1 AS LINE_CODE, A.DATA_1 AS MANAGER, A.DATA_2 AS ALARM_CODE, B.DATA_1 AS MANAGER_NAME, B.DATA_2 AS DEPT_CODE ");
                sb.Append("  FROM MGCMTBLDAT A, MGCMTBLDAT B ");
                sb.Append(" WHERE A.FACTORY = 'USGAM1' AND A.FACTORY = B.FACTORY AND A.DATA_1 = B.KEY_1 AND A.TABLE_NAME = '@JCM_LINE_MANAGER' AND B.TABLE_NAME = '@JCM_USER_INFO' ");
                sb.Append("  AND A.FACTORY = '" + MPGV.gsFactory + "'");
                sb.Append("  AND A.KEY_1 = '" + MPCF.Trim(cdvLineCode.Text) + "' ");
                in_node.AddString("SQL", sb.ToString());

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return;
                }

                if (out_node.GetList("ROWS").Count > 0)
                {
                    if (out_node.GetList("ROWS")[0].GetList("COLS").Count > 0)
                    {
                        cdvDepeCode.Text = out_node.GetList("ROWS")[0].GetList("COLS")[4].GetString("DATA");
                        cdvManager.Text = out_node.GetList("ROWS")[0].GetList("COLS")[1].GetString("DATA");
                        cdvManager.DescText = out_node.GetList("ROWS")[0].GetList("COLS")[3].GetString("DATA");
                        cdvAlarmCode.Text = out_node.GetList("ROWS")[0].GetList("COLS")[2].GetString("DATA");
                    }
                }
                else
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(638) + "[@JCM_LINE_MANAGER][@JCM_USER_INFO]");
                    cdvDepeCode.Text = "";
                    cdvManager.Text = "";
                    cdvManager.DescText = "";
                    cdvAlarmCode.Text = "";
                    return;
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
                string[] sTemp = new string[1];
                sTemp[0] = MPCF.Trim(cdvLineCode.Text);

                cdvManager.Init();
                MPCF.InitListView(cdvManager.GetListView);
                cdvManager.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvManager.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvManager.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvManager.GetListView, '1', "@JCM_LINE_MANAGER", (int)SMALLICON_INDEX.IDX_MESSAGE, null, MPGV.gsFactory, false, 0, 0, null, sTemp) == true)
                {
                    cdvManager.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCopyTo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(cdvOrderNumber.Text) == "")
                    return;

                frmJobChangeCopyToPopup _frm = new frmJobChangeCopyToPopup();
                _frm.ORDER_ID = cdvOrderNumber.Text;
                _frm.MAT_ID =  cdvMaterial.Text;
                _frm.MAT_DESC = cdvMaterial.DescText;

                _frm.LINE_CODE = cdvLineCode.Text;
                _frm.LINE_DESC = cdvLineCode.DescText;
                _frm.START_DATE = dtpOrdStartDate.Text;
                if (_frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    ClearData('2');
                    cdvOrderNumber.Text = _frm.TO_ORDER_ID;
                    ViewJobChangeStatus('2');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

   }
}
