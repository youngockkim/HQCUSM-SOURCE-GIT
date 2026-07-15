//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSAttributesAnalysis.cs
//   Description : 
//
//   MESplus EE Version : 5.3.4 ~
//
//   Function List
//       - ClearData() : Initalize form fields
//       - CheckCondition() : Check the conditions before transaction
//       - ViewMms() : View Mms definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2023-04-25 18:08:04 : XXXX Created by generator in DEV Tools
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
    public partial class frmMMSAttributesAnalysis : ViewForm01    {
        public frmMMSAttributesAnalysis()
        {
            InitializeComponent();
            c_ana_div = '1';
            this.spdAnalysisResultList.ActiveSheet.RowCount = 0;
            
        }


        #region " Constant Definition "
        private enum LIST : int
        {
            DETAIL = 0,
            ANA_ID,
            PLAN_DATE,
            ANA_DATE,
            ANA_RESULT,
            EQUIP_ID,
            EQUIP_NAME,
            SAMPLE_NAME,
            USER_COUNT,
            SAMPLE_COUNT,
            REPEAT_COUNT,
            ITEM_CODE,
            ITEM_NAME,
            LSL,
            USL,
            UNIT_CODE,
            DECIMAL_PLACE,
            CREATE_TIME,
            CREATE_USER,
            UPDATE_TIME,
            UPDATE_USER
        }


        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        private char c_ana_div;

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
            //if (MPCF.CheckValue(dtpPlanFromDate, 1) == false)
            //{
            //    return false;
            //}
            //if (MPCF.CheckValue(dtpPlanToDate, 1) == false)
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
        // ViewAnalysisPlanResultList()
        //       - View Analysis_Plan_Result List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewAnalysisPlanResultList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_ANALYSIS_PLAN_RESULT_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            string sResult = "";
            try
            {
                MPCF.ClearList(pnlViewMid);
                this.spdAnalysisResultList.ActiveSheet.RowCount = 0;

                FarPoint.Win.Spread.SheetView with_1 = spdAnalysisResultList.ActiveSheet;
                int i = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("PLAN_DATE", dtpPlanFromDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("ANA_DATE", dtpPlanToDate.Value.ToString("yyyyMMdd"));
                in_node.AddChar("ANA_DIV", c_ana_div);
                in_node.AddString("EQUIP_ID", MPCF.Trim(cdvEquipCode.Text));
                in_node.AddString("MGT_DEPT_CODE", MPCF.Trim(cdvMgtDept.Text));
                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_ANALYSIS_PLAN_RESULT_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Analysis_Plan_Result_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> analysis_plan_result_list = out_node.GetList("ANALYSIS_PLAN_RESULT_LIST");
                    foreach (TRSNode node in analysis_plan_result_list)
                    {
                        sResult = "";
                        if (node.GetChar("ANA_RESULT") == 'P')
                            sResult = "Pass";
                        else if (node.GetChar("ANA_RESULT") == 'F')
                            sResult = "Fail";

                        with_1.RowCount = i + 1;
                        with_1.SetValue(i, MPCF.ToInt(LIST.ANA_ID), node.GetString("ANA_ID"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLAN_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(LIST.ANA_DATE), MPCF.MakeDateFormat(node.GetString("ANA_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(LIST.ANA_RESULT), sResult);
                        with_1.SetValue(i, MPCF.ToInt(LIST.EQUIP_ID), node.GetString("EQUIP_ID"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.EQUIP_NAME), node.GetString("EQUIP_NAME"));                        
                        with_1.SetValue(i, MPCF.ToInt(LIST.SAMPLE_NAME), node.GetString("SAMPLE_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.USER_COUNT), node.GetInt("USER_COUNT"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.SAMPLE_COUNT), node.GetInt("SAMPLE_COUNT"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.REPEAT_COUNT), node.GetInt("REPEAT_COUNT"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.ITEM_CODE), node.GetString("ITEM_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.ITEM_NAME), node.GetString("ITEM_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.LSL), node.GetDouble("LSL"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.USL), node.GetDouble("USL"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.UNIT_CODE), node.GetString("UNIT_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.DECIMAL_PLACE), node.GetInt("DECIMAL_PLACE"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.CREATE_TIME), MPCF.MakeDateFormat(node.GetString("CREATE_TIME"), DATE_TIME_FORMAT.DATETIME));
                        with_1.SetValue(i, MPCF.ToInt(LIST.CREATE_USER), node.GetString("CREATE_USER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.UPDATE_TIME), MPCF.MakeDateFormat(node.GetString("UPDATE_TIME"), DATE_TIME_FORMAT.DATETIME));
                        with_1.SetValue(i, MPCF.ToInt(LIST.UPDATE_USER), node.GetString("UPDATE_USER_ID"));
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

        private void frmMMSAttributesAnalysis_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                this.dtpPlanFromDate.Value = DateTime.Now.AddMonths(-1);
                this.dtpPlanToDate.Value = DateTime.Now;

                // TODO
                b_load_flag = true;
            }
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == false) return;

            if (ViewAnalysisPlanResultList() == false) return;
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond = "";
            //sCond = "Key ID : Gage R&R Variables Analysis \r";
            sCond = sCond + "Date : " + dtpPlanFromDate.Value.ToShortDateString() + " ~ " + dtpPlanToDate.Value.ToShortDateString();
            HQCE.ExportToExcel(spdAnalysisResultList, this.Text, sCond, true, true, true, -1, -1, 0, false);            
        }

        private void spdAnalysisResultList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {

                switch (e.Column)
                {
                    case (int)LIST.DETAIL:
                        frmMMSAttributesAnalysisPopup _resultPopup = new frmMMSAttributesAnalysisPopup();
                        _resultPopup.ANA_ID = MPCF.Trim(spdAnalysisResultList.ActiveSheet.GetValue(e.Row, (int)LIST.ANA_ID));
                        _resultPopup.EQUIP_ID = MPCF.Trim(spdAnalysisResultList.ActiveSheet.GetValue(e.Row, (int)LIST.EQUIP_ID));
                        _resultPopup.ITEM_CODE = MPCF.Trim(spdAnalysisResultList.ActiveSheet.GetValue(e.Row, (int)LIST.ITEM_CODE));
                        _resultPopup.StartPosition = FormStartPosition.CenterParent;
                        _resultPopup.ControlBox = false;
                        if (_resultPopup.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                           // ViewAnalysisPlanItemList(_resultPopup.ANA_ID, _resultPopup.EQUIP_ID, _resultPopup.EQUIP_NAME);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvMgtDept_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvMgtDept.Init();
                MPCF.InitListView(cdvMgtDept.GetListView);
                cdvMgtDept.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvMgtDept.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvMgtDept.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvMgtDept.GetListView, '1', MPGC.MP_GCM_MMS_DEPT_CODE) == true)
                {
                    cdvMgtDept.InsertEmptyRow(0, 1);
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
                if (HQCF.ViewStandardEquipmentList(cdvEquipCode.GetListView, '5', 'Y', MPCF.Trim(cdvEquipType.Text)) == true)
                {
                    cdvEquipCode.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvEquipType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvEquipType.Init();
                MPCF.InitListView(cdvEquipType.GetListView);
                cdvEquipType.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvEquipType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvEquipType.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvEquipType.GetListView, '1', MPGC.MP_GCM_MMS_EQUIP_TYPE) == true)
                {
                    cdvEquipType.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


    }
}
