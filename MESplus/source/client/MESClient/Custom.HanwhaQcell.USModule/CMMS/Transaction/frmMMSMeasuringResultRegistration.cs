//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSMeasuringResultRegistration.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewMms() : View Mms definition
//       - TranMms() : Process Mms for transaction
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
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmMMSMeasuringResultRegistration : ViewForm01
    {
        public frmMMSMeasuringResultRegistration()
        {
            InitializeComponent();
        }


        #region " Constant Definition "
        private enum PLAN_LIST : int
        {
            PLAN_DATE = 0,
            EQUIP_ID,
            EQUIP_NAME,
            ANA_DIV,
            ANA_DATE,
            SAMPLE_CODE,
            USER_COUNT,
            SAMPLE_COUNT,
            REPEAT_COUNT,
            CREATE_TIME,
            CREATE_USER,
            UPDATE_TIME,
            UPDATE_USER,
            ANA_ID
        }

        private enum ITEM_LIST : int
        {
            DETAIL,
            ITEM_CODE,
            ITEM_NAME,
            ANA_DATE,
            LSL,
            USL,
            UNIT,
            DECIMAL_PLACE,
            ANA_ID,
            EQUIP_ID,
            EQUIP_NAME
        }

        private int iSelRow = -1;
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
            return this.cdvEquipCode;
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
            //if (MPCF.CheckValue(cdvEquipCode, 1) == false)
            //{
            //    return false;
            //}

            switch (FuncName)
            {
                case "VIEW":
                    // TODO
                    break;
                case "TRAN2":
                    // TODO
                    break;
            }

            return true;            
        }

     
        //
        // ViewAnalysisPlanList()
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

            try
            {
                MPCF.ClearList(spcMain);
                spdAnaPlanList.ActiveSheet.RowCount = 0;
                spdAnaPlanItemList.ActiveSheet.RowCount = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("EQUIP_ID", cdvEquipCode.Text);
                in_node.AddString("FROM_DATE", dtpPlanFromDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("TO_DATE", dtpPlanToDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("USE_DEPT_CODE", cdvUseDept.Text);
                in_node.AddChar("ANA_DIV", cdvAnaMethod.Text);

                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_ANALYSIS_PLAN_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Analysis_Plan_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);


                FarPoint.Win.Spread.SheetView with_1 = spdAnaPlanList.ActiveSheet;
                int i = 0;

                foreach(TRSNode out_node in out_list)
                {
                    
                    List<TRSNode> analysis_plan_list = out_node.GetList("ANALYSIS_PLAN_LIST");
                    foreach (TRSNode node in analysis_plan_list)
                    {
                        with_1.RowCount = i + 1;
                        if (MPCF.Trim(node.GetString("PLAN_DATE")) != "")
                        {
                            with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.PLAN_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_DATE"), DATE_TIME_FORMAT.DATE));
                        }
                        else
                        {
                            with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.PLAN_DATE), MPCF.Trim(node.GetString("PLAN_DATE")));
                        }
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.EQUIP_ID), node.GetString("EQUIP_ID"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.EQUIP_NAME), node.GetString("EQUIP_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.ANA_DIV), node.GetString("ANA_DIV_DESC"));
                        if (MPCF.Trim(node.GetString("ANA_DATE")) != "")
                        {
                            with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.ANA_DATE), MPCF.MakeDateFormat(node.GetString("ANA_DATE"), DATE_TIME_FORMAT.DATE));
                        }
                        else
                        {
                            with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.ANA_DATE), MPCF.Trim(node.GetString("ANA_DATE")));
                        }
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.SAMPLE_CODE), node.GetString("SAMPLE_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.USER_COUNT), node.GetInt("USER_COUNT"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.SAMPLE_COUNT), node.GetInt("SAMPLE_COUNT"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.REPEAT_COUNT), node.GetInt("REPEAT_COUNT"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.CREATE_TIME), MPCF.MakeDateFormat(node.GetString("CREATE_TIME"), DATE_TIME_FORMAT.DATETIME));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.CREATE_USER), node.GetString("CREATE_USER_ID"));
                        if (MPCF.Trim(node.GetString("UPDATE_TIME")) != "")
                            with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.UPDATE_TIME), MPCF.MakeDateFormat(node.GetString("UPDATE_TIME"), DATE_TIME_FORMAT.DATETIME));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.UPDATE_USER), node.GetString("UPDATE_USER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(PLAN_LIST.ANA_ID), node.GetString("ANA_ID"));
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
        // ViewAnalysisPlanItemList()
        //       - View Analysis_Plan Item List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewAnalysisPlanItemList(string sAnaID, string sEquipCode, string sEquipName)
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_ANALYSIS_PLAN_ITEM_IN");
            List<TRSNode> out_list = new List<TRSNode>();

            try
            {
                MPCF.ClearList(spcMain);
                spdAnaPlanItemList.ActiveSheet.RowCount = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ANA_ID", sAnaID);

                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_ANALYSIS_PLAN_ITEM_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Analysis_Plan_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);


                FarPoint.Win.Spread.SheetView with_1 = spdAnaPlanItemList.ActiveSheet;
                int i = 0;

                foreach (TRSNode out_node in out_list)
                {

                    List<TRSNode> analysis_plan_list = out_node.GetList("ANALYSIS_PLAN_ITEM_LIST");
                    foreach (TRSNode node in analysis_plan_list)
                    {
                        with_1.RowCount = i + 1;
                        //with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.DETAIL), "");
                        with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.ITEM_CODE), node.GetString("ITEM_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.ITEM_NAME), node.GetString("ITEM_NAME"));
                        if (MPCF.Trim(node.GetString("ANA_DATE")) != "")
                        {
                            with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.ANA_DATE),  MPCF.MakeDateFormat(node.GetString("ANA_DATE"), DATE_TIME_FORMAT.DATE));
                        }
                        else
                        {
                            with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.ANA_DATE), MPCF.Trim(node.GetString("ANA_DATE")));
                        }
                        
                        with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.LSL), node.GetDouble("LSL"));
                        with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.USL), node.GetDouble("USL"));
                        with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.UNIT), node.GetString("UNIT_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.DECIMAL_PLACE), node.GetInt("DECIMAL_PLACE"));
                        with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.ANA_ID), sAnaID);
                        with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.EQUIP_ID), sEquipCode);
                        with_1.SetValue(i, MPCF.ToInt(ITEM_LIST.EQUIP_NAME), sEquipName);
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

        private void frmMMSMeasuringResultRegistration_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');

                spdAnaPlanList.ActiveSheet.RowCount = 0;
                spdAnaPlanItemList.ActiveSheet.RowCount = 0;
                
                dtpPlanToDate.Value = dtpPlanFromDate.Value.AddMonths(1);

                // TODO
                b_load_flag = true;
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                iSelRow = -1;
                // TODO
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW") == false) return;

                if (ViewAnalysisPlanList() == false) return;
                iSelRow = -1;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdAnaPlanList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            string s_ana_id = "";
            string s_equip_id = "";
            string s_equip_name = "";
            try
            {
                if (e.Range.Row < 0) return;
                if (iSelRow == e.Range.Row) return;
                iSelRow = e.Range.Row;

                FarPoint.Win.Spread.SheetView with_1 = spdAnaPlanList.ActiveSheet;

                s_ana_id = MPCF.Trim(with_1.GetValue(e.Range.Row, MPCF.ToInt(PLAN_LIST.ANA_ID)));
                s_equip_id = MPCF.Trim(with_1.GetValue(e.Range.Row, MPCF.ToInt(PLAN_LIST.EQUIP_ID)));
                s_equip_name = MPCF.Trim(with_1.GetValue(e.Range.Row, MPCF.ToInt(PLAN_LIST.EQUIP_NAME)));

                ViewAnalysisPlanItemList(s_ana_id, s_equip_id, s_equip_name);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvUseDept_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvUseDept.Init();
                MPCF.InitListView(cdvUseDept.GetListView);
                cdvUseDept.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvUseDept.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvUseDept.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvUseDept.GetListView, '1', MPGC.MP_GCM_MMS_DEPT_CODE) == true)
                {
                    cdvUseDept.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvAnaMethod_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvAnaMethod.Init();
                MPCF.InitListView(cdvAnaMethod.GetListView);
                cdvAnaMethod.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvAnaMethod.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvAnaMethod.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvAnaMethod.GetListView, '1', MPGC.MP_GCM_MMS_ANA_METHOD) == true)
                {
                    cdvAnaMethod.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvEquipCode_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvEquipCode.Init();
                MPCF.InitListView(cdvEquipCode.GetListView);
                cdvEquipCode.Columns.Add("Code", 100, HorizontalAlignment.Left);
                cdvEquipCode.Columns.Add("Desc", 150, HorizontalAlignment.Left);
                if (HQCF.ViewStandardEquipmentList(cdvEquipCode.GetListView, '5', 'Y', "") == true)
                {
                    cdvEquipCode.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdAnaPlanItemList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {

                switch (e.Column)
                {
                    case (int)ITEM_LIST.DETAIL:                        
                        frmMMSMeasuringResultPopup _resultPopup = new frmMMSMeasuringResultPopup();
                        _resultPopup.ANA_ID = MPCF.Trim(spdAnaPlanItemList.ActiveSheet.GetValue(e.Row, (int)ITEM_LIST.ANA_ID));
                        _resultPopup.EQUIP_ID = MPCF.Trim(spdAnaPlanItemList.ActiveSheet.GetValue(e.Row, (int)ITEM_LIST.EQUIP_ID));
                        _resultPopup.EQUIP_NAME = MPCF.Trim(spdAnaPlanItemList.ActiveSheet.GetValue(e.Row, (int)ITEM_LIST.EQUIP_NAME));
                        _resultPopup.ITEM_CODE = MPCF.Trim(spdAnaPlanItemList.ActiveSheet.GetValue(e.Row, (int)ITEM_LIST.ITEM_CODE));
                        _resultPopup.StartPosition = FormStartPosition.CenterParent;
                        _resultPopup.ControlBox = false;
                        if (_resultPopup.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            ViewAnalysisPlanItemList(_resultPopup.ANA_ID, _resultPopup.EQUIP_ID, _resultPopup.EQUIP_NAME);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;
            sCond = "Key ID : " + dtpPlanFromDate.Value.ToShortDateString() + " - " + dtpPlanToDate.Value.ToShortDateString() + "\r";
            // sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            MPCF.ExportToExcel(spdAnaPlanList, this.Text, sCond);
        }
    }
}
