//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSCalibrationResultRegistration.cs
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
//       - 2023-04-03 13:07:57 : XXXX Created by generator in DEV Tools
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
    public partial class frmMMSCalibrationResultRegistration : TranForm02
    {
        public frmMMSCalibrationResultRegistration()
        {
            InitializeComponent();

            setGridDefaultDatetime();
        }

        #region " Constant Definition "
        private enum CALI_LIST : int
        {
            CHECK = 0,
            DETAIL,
            EQUIP_ID,
            EQUIP_NAME,
            EQUIP_NO,
            EQUIP_SPEC,
            EQUIP_MODEL,
            EQUIP_MAKER,
            SERIAL_NO,
            CALI_CYCLE,
            PLAN_DATE,
            LAST_CALI_DATE,
            LAST_CALI_RESULT,
            CALI_DATE,
            CALI_RESULT,
            CALI_METHOD,
            CALI_INSTI,
            CALI_INSTI_BTN,
            CALI_INSTI_NAME,
            CALI_USER,
            CALI_USER_BTN,
            CALI_USER_NAME
        }

        private enum HISTORY : int
        {
            DETAIL,
            CALI_ID,
            PLAN_DATE,
            CALI_DATE,
            CALI_INSTI,
            CALI_METHOD,
            CALI_RESULT,
            CALI_COST,
            CALI_DESC
        }
        #endregion

        #region " Variable Definition "

        private bool b_load_flag;

        private string s_equip_id;
        private string s_equip_name;
        private string s_equip_no;
        private string s_plan_date;
        private int i_cali_cycle;

        #endregion

        #region " Function Definition "

        private void setGridDefaultDatetime()
        {
            FarPoint.Win.Spread.CellType.DateTimeCellType _cell_type = (FarPoint.Win.Spread.CellType.DateTimeCellType)spdCalibrationPlanList_Sheet1.Columns.Get(13).CellType;
            _cell_type.DateDefault = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            spdCalibrationPlanList_Sheet1.Columns.Get(13).CellType = _cell_type;
        }

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

                    spdCalibrationHistory.ActiveSheet.RowCount = 0;
                    spdCalibrationPlanList.ActiveSheet.RowCount = 0;

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
            //if (MPCF.CheckValue(txtCalibrationEquipCode, 1) == false)
            //{
            //    return false;
            //}

            switch (FuncName)
            {
                case "TRAN1":
                    // TODO
                    break;
                case "TRAN2":
                    // TODO
                    break;
            }

            return true;            
        }

        //
        // SetSpreadComboboxList()
        //       - Set Spread Combobox List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool GetSpreadComboboxList()
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdCalibrationPlanList.ActiveSheet;

                ArrayList alResultCode = new ArrayList();
                ArrayList alResultName = new ArrayList();
                alResultCode.Add("");
                alResultName.Add("");
                alResultCode.Add("P");
                alResultName.Add("Pass");
                alResultCode.Add("F");
                alResultName.Add("Fail");

                FarPoint.Win.Spread.CellType.ComboBoxCellType cb1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();//CellType 정의
                cb1.ItemData = (string[])alResultCode.ToArray(typeof(string));//ItemData 값 지정.
                cb1.Items = (string[])alResultName.ToArray(typeof(string)); //Items 값 지정..
                cb1.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.ItemData; //이 부분이 빠지면 안됨..
                with_1.Columns[MPCF.ToInt(CALI_LIST.CALI_RESULT)].CellType = cb1; //CellType 지정. .
                //with_1.Columns[MPCF.ToInt(CALI_LIST.LAST_CALI_RESULT)].CellType = cb1; //CellType 지정. .

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

       
      
        //
        // UpdateCalibrationResultRegistration()
        //       - Update Calibration_Result_Registration
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateCalibrationResultRegistration()
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION_OUT");
            TRSNode list_item;

            bool bSaveCheck = false;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE; //Main 화면에서는 Create만 존재 
                in_node.AddChar("TRAN_STEP", '1');

                FarPoint.Win.Spread.SheetView with_1 = spdCalibrationPlanList.ActiveSheet;

                for (int i = 0; i < with_1.RowCount; i++)
                {
                    if (Convert.ToBoolean(with_1.Cells[i, (int)CALI_LIST.CHECK].Value) == true)
                    {
                        list_item = in_node.AddNode("CALIBRATION_RESULT_LIST");

                        list_item.AddString("EQUIP_ID", MPCF.Trim(with_1.Cells[i, (int)CALI_LIST.EQUIP_ID].Value));
                        list_item.AddString("CALI_ID", MPCF.Trim(with_1.Cells[i, (int)CALI_LIST.EQUIP_ID].Value) + DateTime.Now.ToString("yyyyMMddHHmmssfff"));

                        if (MPCF.Trim(with_1.Cells[i, (int)CALI_LIST.CALI_DATE].Value) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108)); //MN108 ERROR - 이 필드는 입력이 필요한 필드입니다. 데이타를 입력해 주십시요.
                            //with_1.Cells[i, (int)CALI_LIST.CALI_DATE].CanFocus = true;
                            with_1.SetActiveCell(i, (int)CALI_LIST.CALI_DATE);
                            return false;
                        }
                        else 
                        {
                            DateTime _date = Convert.ToDateTime(with_1.Cells[i, (int)CALI_LIST.CALI_DATE].Value);
                            DateTime _plan_date = Convert.ToDateTime(with_1.Cells[i, (int)CALI_LIST.PLAN_DATE].Value);
                            list_item.AddString("CALI_DATE", _date.ToString("yyyyMMdd"));
                            list_item.AddString("PLAN_DATE", _plan_date.ToString("yyyyMMdd"));
                            list_item.AddString("NEXT_PLAN_DATE", _date.AddMonths(MPCF.ToInt(with_1.Cells[i, (int)CALI_LIST.CALI_CYCLE].Value)).ToString("yyyyMMdd"));
                        }

                        // 결과 입력 없을 때 Error ?
                        if (MPCF.Trim(with_1.Cells[i, (int)CALI_LIST.CALI_RESULT].Value) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108)); //MN108 ERROR - 이 필드는 입력이 필요한 필드입니다. 데이타를 입력해 주십시요.
                            with_1.SetActiveCell(i, (int)CALI_LIST.CALI_RESULT);
                            return false;                            
                        }
                        list_item.AddChar("CALI_RESULT", MPCF.Trim(with_1.Cells[i, (int)CALI_LIST.CALI_RESULT].Value).Substring(0, 1));  // (P:Pass/F:Fail)
                        list_item.AddString("CALI_METHOD", MPCF.Trim(with_1.Cells[i, (int)CALI_LIST.CALI_METHOD].Value));
                        list_item.AddString("CALI_INSTITUTE", MPCF.Trim(with_1.Cells[i, (int)CALI_LIST.CALI_INSTI].Value));
                        list_item.AddString("CALI_USER_ID", MPCF.Trim(with_1.Cells[i, (int)CALI_LIST.CALI_USER].Value));

                        bSaveCheck = true;
                    }
                }

                if (bSaveCheck == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(335)); //CMN335 ERROR - Requierd Cell value is empty.
                    return false;
                }

                if (MPCR.CallService("CMMS", "CMMS_Update_Calibration_Result_Registration", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                MPCR.ShowSuccessMsg(out_node);

                btnRefresh.PerformClick();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // ViewCalibrationPlanList()
        //       - View Calibration_Plan List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCalibrationPlanList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_CALIBRATION_PLAN_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            int i;
            string s_Result = "";

            try
            {
                MPCF.ClearList(spdCalibrationPlanList, true);
                MPCF.ClearList(spdCalibrationHistory, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';

                in_node.AddString("FROM_DATE", dtpPlanFromDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("TO_DATE", dtpPlanToDate.Value.ToString("yyyyMMdd"));
                in_node.AddString("EQUIP_ID", cdvEquipCode.Text);
                //in_node.AddString("EQUIP_NAME", txtCalibrationEquipName.Text);
                in_node.AddString("USE_DEPT_CODE", cdvUseDept.Text);
                in_node.AddString("MGT_DEPT_CODE", cdvMgtDept.Text);

                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_CALIBRATION_PLAN_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Calibration_Plan_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                FarPoint.Win.Spread.SheetView with_1 = spdCalibrationPlanList.ActiveSheet;
                i = 0;

                foreach (TRSNode out_node in out_list)
                {

                    List<TRSNode> calibration_plan_list = out_node.GetList("CALIBRATION_PLAN_LIST");
                    foreach (TRSNode node in calibration_plan_list)
                    {



                        with_1.RowCount = i + 1;
                        if (node.GetChar("CALI_RESULT") == 'P')
                            s_Result = "Pass";
                        else if (node.GetChar("CALI_RESULT") == 'F')
                            s_Result = "Fail";
                        else
                            s_Result = " ";
                        
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.CHECK), false);
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.EQUIP_ID), node.GetString("EQUIP_ID"));
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.EQUIP_NAME), node.GetString("EQUIP_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.EQUIP_NO), node.GetString("EQUIP_NO"));
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.EQUIP_SPEC), node.GetString("EQUIP_SPEC"));
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.EQUIP_MODEL), node.GetString("EQUIP_MODEL"));
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.EQUIP_MAKER), node.GetString("EQUIP_MAKER"));
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.SERIAL_NO), node.GetString("PROP_NO"));
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.CALI_CYCLE), node.GetInt("CALI_CYCLE"));
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.PLAN_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.LAST_CALI_DATE), MPCF.MakeDateFormat(node.GetString("CALI_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.LAST_CALI_RESULT), s_Result);
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.CALI_DATE), "");
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.CALI_RESULT), "");
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.CALI_METHOD), "");
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.CALI_INSTI), "");
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.CALI_INSTI_NAME), "");
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.CALI_USER), "");
                        with_1.SetValue(i, MPCF.ToInt(CALI_LIST.CALI_USER_NAME), "");
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
        // ViewCalibrationHistory()
        //       - View Calibration_Result_Registration List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCalibrationHistory(string sEquipCode)
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();

            try
            {
                MPCF.ClearList(spcMain);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '3';

                in_node.AddString("EQUIP_ID", sEquipCode);

                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_CALIBRATION_RESULT_REGISTRATION_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Calibration_Result_Registration_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                } while (out_list.Count < 1);

                FarPoint.Win.Spread.SheetView with_1 = spdCalibrationHistory.ActiveSheet;
                int i = 0;

                foreach (TRSNode out_node in out_list)
                {
                    List<TRSNode> calibration_result = out_node.GetList("CALIBRATION_RESULT_REGISTRATION_LIST");
                    foreach (TRSNode node in calibration_result)
                    {
                        with_1.RowCount = i + 1;
                        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_ID), node.GetString("CALI_ID"));
                        with_1.SetValue(i, MPCF.ToInt(HISTORY.PLAN_DATE), MPCF.MakeDateFormat(node.GetString("PLAN_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_DATE), MPCF.MakeDateFormat(node.GetString("CALI_DATE"), DATE_TIME_FORMAT.DATE));
                        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_INSTI), node.GetString("CALI_INSTITUTE"));
                       // with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_USER), node.GetString("CALI_USER_ID"));
                        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_METHOD), node.GetString("CALI_METHOD"));
                        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_RESULT), node.GetChar("CALI_RESULT"));
                        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_COST), node.GetDouble("CALI_COST"));
                        with_1.SetValue(i, MPCF.ToInt(HISTORY.CALI_DESC), node.GetString("CALI_DESC"));
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

        private void frmMMSCalibrationResultRegistration_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');

                dtpPlanFromDate.Value = DateTime.Now.AddMonths(-1);
                dtpPlanToDate.Value = DateTime.Now.AddMonths(1);

                GetSpreadComboboxList();
                // TODO
                b_load_flag = true;
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                // TODO
                ViewCalibrationPlanList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("TRAN1") == false) return;

                if (UpdateCalibrationResultRegistration() == false) return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lblViewUseDept_Click(object sender, EventArgs e)
        {

        }

        private void spdCalibrationPlanList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {

                switch (e.Column)
                {
                    case (int)CALI_LIST.DETAIL:
                        FarPoint.Win.Spread.SheetView with_1 = spdCalibrationPlanList.ActiveSheet;

                        frmMMSCalibrationResultPopup _resultPopup = new frmMMSCalibrationResultPopup();
                        _resultPopup.EQUIP_ID = MPCF.Trim(with_1.GetValue(e.Row, (int)CALI_LIST.EQUIP_ID));
                        _resultPopup.EQUIP_NAME = MPCF.Trim(with_1.GetValue(e.Row, (int)CALI_LIST.EQUIP_NAME));
                        _resultPopup.EQUIP_NO = MPCF.Trim(with_1.GetValue(e.Row, (int)CALI_LIST.EQUIP_NO));
                        _resultPopup.PLAN_DATE = MPCF.Trim(with_1.GetValue(e.Row, (int)CALI_LIST.PLAN_DATE));
                        _resultPopup.CALI_CYCLE = MPCF.ToInt(with_1.GetValue(e.Row, (int)CALI_LIST.CALI_CYCLE));

                        _resultPopup.StartPosition = FormStartPosition.CenterParent;
                        _resultPopup.ControlBox = false;
                        if (_resultPopup.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {
                            ViewCalibrationPlanList();
                        }
                        break;
                    case (int)CALI_LIST.CALI_INSTI_BTN:
                        cdvDataList.Init();
                        cdvDataList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("Equip Code", 60, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Description", 80, HorizontalAlignment.Left);
                        cdvDataList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        if (HQCF.ViewCalibrationInstituteList(cdvDataList.GetListView, '3',' ', 'Y') == false)
                        {
                            return;
                        }

                        if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
                        {
                            return;
                        }
                        break;

                    case (int)CALI_LIST.CALI_USER_BTN:
                        cdvDataList.Init();
                        cdvDataList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("Equip Code", 60, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Description", 80, HorizontalAlignment.Left);
                        cdvDataList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        if (HQCF.ViewCalibrationUserList(cdvDataList.GetListView, '3', 'Y') == false)
                        {
                            return;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ViewCalibrationPlanList();
        }

        private void spdCalibrationPlanList_ComboSelChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            spdCalibrationPlanList.ActiveSheet.SetValue(e.Row, MPCF.ToInt(CALI_LIST.CHECK), true);
        }

        private void spdCalibrationPlanList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {

                if (e.Range.Row < 0) return;

                FarPoint.Win.Spread.SheetView with_1 = spdCalibrationPlanList.ActiveSheet;

                if (MPCF.Trim(txtDetailEquipID.Text) != MPCF.Trim(with_1.GetValue(e.Range.Row, MPCF.ToInt(CALI_LIST.EQUIP_ID))))
                {
                    MPCF.ClearList(spdCalibrationHistory, true);

                    s_equip_id = MPCF.Trim(with_1.GetValue(e.Range.Row, MPCF.ToInt(CALI_LIST.EQUIP_ID)));
                    s_equip_name = MPCF.Trim(with_1.GetValue(e.Range.Row, MPCF.ToInt(CALI_LIST.EQUIP_NAME)));
                    s_equip_no = MPCF.Trim(with_1.GetValue(e.Range.Row, MPCF.ToInt(CALI_LIST.EQUIP_NO)));
                    s_plan_date = MPCF.Trim(with_1.GetValue(e.Range.Row, MPCF.ToInt(CALI_LIST.PLAN_DATE)));
                    i_cali_cycle = MPCF.ToInt(with_1.GetValue(e.Range.Row, MPCF.ToInt(CALI_LIST.CALI_CYCLE)));
                    txtDetailEquipID.Text = s_equip_id;

                    ViewCalibrationHistory(s_equip_id);
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
                switch (e.Col)
                {
                    case (int)CALI_LIST.CALI_INSTI:
                        spdCalibrationPlanList.ActiveSheet.Cells[e.Row, e.Col].Value = e.SelectedItem.SubItems[0].Text;
                        spdCalibrationPlanList.ActiveSheet.Cells[e.Row, e.Col + 2].Value = e.SelectedItem.SubItems[1].Text;
                        spdCalibrationPlanList.ActiveSheet.SetValue(e.Row, MPCF.ToInt(CALI_LIST.CHECK), true);
                        break;

                    case (int)CALI_LIST.CALI_USER:
                        spdCalibrationPlanList.ActiveSheet.Cells[e.Row, e.Col].Value = e.SelectedItem.SubItems[0].Text;
                        spdCalibrationPlanList.ActiveSheet.Cells[e.Row, e.Col + 2].Value = e.SelectedItem.SubItems[1].Text;
                        spdCalibrationPlanList.ActiveSheet.SetValue(e.Row, MPCF.ToInt(CALI_LIST.CHECK), true);
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdCalibrationHistory_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {

                switch (e.Column)
                {
                    case (int)HISTORY.DETAIL:
                        frmMMSCalibrationResultPopup _resultPopup = new frmMMSCalibrationResultPopup();
                        _resultPopup.EQUIP_ID = MPCF.Trim(s_equip_id);
                        _resultPopup.EQUIP_NAME = MPCF.Trim(s_equip_name);
                        _resultPopup.EQUIP_NO = MPCF.Trim(s_equip_no);
                        _resultPopup.PLAN_DATE = MPCF.Trim(s_plan_date);
                        _resultPopup.CALI_ID = MPCF.Trim(this.spdCalibrationHistory.ActiveSheet.GetValue(e.Row, (int)HISTORY.CALI_ID));
                        _resultPopup.CALI_CYCLE = i_cali_cycle;

                        _resultPopup.StartPosition = FormStartPosition.CenterParent;
                        _resultPopup.ControlBox = false;
                        if (_resultPopup.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        {

                        }
                        break;                    
                }
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







    }
}
