//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSCalibrationResultPopup.cs
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
using System.IO;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
using Custom.Common;

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmMMSAnalisisPlanPopup : TranForm02
    {
        public frmMMSAnalisisPlanPopup()
        {
            InitializeComponent();
            this.spdItemList.ActiveSheet.RowCount = 0;
            this.spdRaterList.ActiveSheet.RowCount = 0;
        }

        #region " Constant Definition "
        private enum RATER_LIST : int
        {
            CHECK = 0,
            USER_ID,
            USER_BUTTON,
            USER_NAME
        }

        private enum ITEM_LIST : int
        {
            CHECK = 0,
            ITEM_CODE,
            ITEM_BUTTON,
            ITEM_NAME,
            LSL,
            USL,
            UNIT_CODE,
            DECIMAL_PLACE,
            VALUE_01,
            VALUE_02,
            VALUE_03,
            VALUE_04,
            VALUE_05,
            VALUE_06,
            VALUE_07,
            VALUE_08,
            VALUE_09,
            VALUE_10,
            VALUE_11,
            VALUE_12,
            VALUE_13,
            VALUE_14,
            VALUE_15,
            VALUE_16,
            VALUE_17,
            VALUE_18,
            VALUE_19,
            VALUE_20,
            VALUE_21,
            VALUE_22,
            VALUE_23,
            VALUE_24,
            VALUE_25,
            VALUE_26,
            VALUE_27,
            VALUE_28,
            VALUE_29,
            VALUE_30
        }

        private string m_ana_id;    
        private string m_equip_id;                               
        private string m_equip_name;                              
        private string m_plan_date;
        private bool b_enable_flag;

        public string ANA_ID
        {
            get
            {
                if (m_ana_id == null)
                {
                    m_ana_id = "";
                }
                return m_ana_id;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_ana_id = "";
                }
                m_ana_id = value;
            }
        }

        public string EQUIP_ID
        {
            get
            {
                if (m_equip_id == null)
                {
                    m_equip_id = "";
                }
                return m_equip_id;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_equip_id = "";
                }
                m_equip_id = value;
            }
        }

        public string EQUIP_NAME
        {
            get
            {
                if (m_equip_name == null)
                {
                    m_equip_name = "";
                }
                return m_equip_name;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_equip_name = "";
                }
                m_equip_name = value;
            }
        }
        
        public string PLAN_DATE
        {
            get
            {
                if (m_plan_date == null)
                {
                    m_plan_date = "";
                }
                return m_plan_date;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_plan_date = "";
                }
                m_plan_date = value;
            }
        }

        public bool ENABLE_FLAG
        {
            get
            {
                return b_enable_flag;
            }
            set
            {
                b_enable_flag = value;
            }
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
                    MPCF.FieldClear(pnlMain);
                    //spdRaterList.ActiveSheet.RowCount = 1;
                    //spdItemList.ActiveSheet.RowCount = 1;

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
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - char c_case ('1', '2')
        //
        private void SetspdItemColumn(int i_col_count)
        {
            int i;
            int iCol;
            int iMaxCol;
            int iMinCol;
            try
            {
                iMinCol = (int)ITEM_LIST.VALUE_01;
                iMaxCol = (int)ITEM_LIST.VALUE_30;
                if (MPCF.Trim(cdvAnaMethod.Text) == "" || MPCF.Trim(cdvAnaMethod.Text) == "0")
                {
                    iCol = 0;
                }
                else
                {
                    iCol = iMinCol + i_col_count;
                }

                for (i = iMaxCol; i >= iMinCol; i--)
                {
                    if (i >= iCol)
                    {
                        spdItemList.ActiveSheet.Columns[i].Visible = false;
                    }
                    else
                    {
                        spdItemList.ActiveSheet.Columns[i].Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void SetSpdItemCelltype(char c_type)
        {
            try
            {
                int iMinCol = (int)ITEM_LIST.VALUE_01;
                int iMaxCol = (int)ITEM_LIST.VALUE_30;

                if (c_type == 'C')
                {
                    string[] c_item = new string[2];

                    c_item[0] = "OK";
                    c_item[1] = "NG";
                    FarPoint.Win.Spread.CellType.ComboBoxCellType cell_type = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    cell_type.Items = c_item;
                    FarPoint.Win.Spread.SheetView with_1 = spdItemList.ActiveSheet;
                    for (int i = iMinCol; i < (iMaxCol + 1); i++)
                    {
                        with_1.Columns[i].CellType = cell_type;
                    }
                }
                else
                {
                    FarPoint.Win.Spread.CellType.NumberCellType cell_type = new FarPoint.Win.Spread.CellType.NumberCellType();
                    FarPoint.Win.Spread.SheetView with_1 = spdItemList.ActiveSheet;
                    for (int i = iMinCol; i < (iMaxCol + 1); i++)
                    {
                        with_1.Columns[i].CellType = cell_type;
                    }
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
            int i;
            if (MPCF.CheckValue(txtEquipCode, 1) == false)
            {
                return false;
            }

            switch (FuncName)
            {
                case "TRAN1":
                    if (txtAnaStatus.Text != "")
                    {
                        if (txtAnaStatus.Text != "0")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(610)); //Only the standby status of the measurement can be modified!
                            return false;
                        }
                    }

                    if (dtpPlanDate.Value < DateTime.Now.Date)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(611)); //Please select the date of the plan after today.
                        return false;
                    }
                    
                    if (spdRaterList.ActiveSheet.RowCount < 1)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(612)); //Register the measuring inspector
                        return false;
                    }

                    if (spdItemList.ActiveSheet.RowCount < 1) 
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(613)); //Please enter the inspection item
                        return false;
                    }

                    for (i = 0; i < spdRaterList.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdRaterList.ActiveSheet.GetValue(i, (int)RATER_LIST.USER_ID)) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(612));
                            return false;
                        }
                    }

                    for (i = 0; i < spdItemList.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdItemList.ActiveSheet.GetValue(i, (int)ITEM_LIST.ITEM_CODE)) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(613));
                            return false;
                        }
                    }

                    // TODO
                    break;
                case "TRAN2":
                    // TODO
                    break;
            }

            return true;            
        }

        

        private bool UpdateAnalysisPlanRegistration()
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_CALIBRATION_RESULT_REGISTRATION_OUT");
            TRSNode list_item;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);

                if (MPCF.Trim(txtOriginalPlanDate.Text) != "")
                {
                    if (MPCF.Trim(txtOriginalPlanDate.Text) != dtpPlanDate.Value.ToString("yyyyMMdd"))
                    {
                        ANA_ID = ""; //계획일자가 변경 되면 신규 등록으로 처리;
                    }
                }

                if (MPCF.Trim(ANA_ID) == "")
                {
                    in_node.ProcStep = MPGC.MP_STEP_CREATE;
                    ANA_ID = MPCF.Trim(txtEquipCode.Text) + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                }
                else
                {
                    in_node.ProcStep = MPGC.MP_STEP_UPDATE; 
                }
                in_node.AddString("ANA_ID", ANA_ID);
                in_node.AddString("EQUIP_ID", MPCF.Trim(txtEquipCode.Text));
                in_node.AddString("PLAN_DATE", dtpPlanDate.Value.ToString("yyyyMMdd"));
                in_node.AddChar("ANA_DIV", MPCF.ToChar(cdvAnaMethod.Text)); //Analysis Method
                in_node.AddString("SAMPLE_CODE", MPCF.Trim(cdvSampleCode.Text));
                in_node.AddString("JUDGE_USER_ID", MPCF.Trim(cdvJudgeCode.Text));
                in_node.AddString("USE_DEPT_CODE", MPCF.Trim(cdvUseDept.Text));
                in_node.AddString("ANA_STATUS", "0"); //Wait 상태
                in_node.AddInt("SAMPLE_COUNT", nudSampleCount.Value);
                in_node.AddInt("REPEAT_COUNT", nudRepeatCount.Value);
                in_node.AddInt("USER_COUNT", spdRaterList.ActiveSheet.RowCount);

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

                ////Rater 목록 저장
                FarPoint.Win.Spread.SheetView with_1 = spdRaterList.ActiveSheet;
                for (i = 0; i < with_1.RowCount; i++)
                {
                    if (MPCF.Trim(with_1.GetValue(i, (int)RATER_LIST.USER_ID).ToString()) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(612));
                        with_1.SetActiveCell(i, (int)RATER_LIST.USER_ID);
                        return false;
                    }
                    if (MPCF.Trim(with_1.GetTag(i, (int)RATER_LIST.CHECK)) != "D")
                    {
                        list_item = in_node.AddNode("ANALYSIS_RATER_LIST");
                        list_item.AddInt("USER_SEQ", (i + 1));
                        list_item.AddString("USER_ID", MPCF.Trim(with_1.GetValue(i, (int)RATER_LIST.USER_ID)));
                    }
                }

                //Item 목록 저장 
                with_1 = spdItemList.ActiveSheet;
                for (i = 0; i < with_1.RowCount; i++)
                {
                    if (MPCF.Trim(with_1.GetValue(i, (int)ITEM_LIST.ITEM_CODE).ToString()) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(613));
                        with_1.SetActiveCell(i, (int)ITEM_LIST.ITEM_CODE);
                        return false;
                    }
                    if (MPCF.Trim(with_1.GetTag(i, (int)ITEM_LIST.CHECK)) != "D")
                    {
                        list_item = in_node.AddNode("ANALYSIS_ITEM_LIST");
                        list_item.AddInt("ITEM_ORDER", (i + 1));
                        list_item.AddString("ITEM_CODE", MPCF.Trim(with_1.GetValue(i, (int)ITEM_LIST.ITEM_CODE)));
                        list_item.AddString("ITEM_NAME", MPCF.Trim(with_1.GetValue(i, (int)ITEM_LIST.ITEM_NAME)));
                        list_item.AddDouble("LSL", MPCF.ToDbl(with_1.GetValue(i, (int)ITEM_LIST.LSL)));
                        list_item.AddDouble("USL", MPCF.ToDbl(with_1.GetValue(i, (int)ITEM_LIST.USL)));
                        list_item.AddString("UNIT_CODE", MPCF.Trim(with_1.GetValue(i, (int)ITEM_LIST.UNIT_CODE)));
                        list_item.AddInt("DECIMAL_PLACE", MPCF.ToInt(with_1.GetValue(i, (int)ITEM_LIST.DECIMAL_PLACE)));
                    }
                }

                char c_type = (cdvAnaMethod.Text == "1" ? 'C':'N');
                //Item 목록 저장 
                ////with_1 = spdItemList.ActiveSheet;                
                if (MPCF.Trim(cdvAnaMethod.Text) != "0")
                {
                    for (i = 0; i < with_1.RowCount; i++)
                    {
                        if (MPCF.Trim(with_1.GetTag(i, (int)ITEM_LIST.CHECK)) != "D")
                        {
                            int i_val_seq = 0;
                            for (int j = (int)ITEM_LIST.VALUE_01; j < ((int)ITEM_LIST.VALUE_01 + nudSampleCount.Value); j++)
                            {
                                if (with_1.GetValue(i, j) == null)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(614)); //Please enter your base value!
                                    with_1.SetActiveCell(i, j);
                                    return false;
                                }
                                if (MPCF.Trim(with_1.GetValue(i, j).ToString()) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(614));
                                    with_1.SetActiveCell(i, j);
                                    return false;
                                }
                                i_val_seq++;
                                list_item = in_node.AddNode("ANALYSIS_VALUE_LIST");
                                list_item.AddString("ITEM_CODE", MPCF.Trim(with_1.GetValue(i, (int)ITEM_LIST.ITEM_CODE)));
                                list_item.AddInt("VAL_SEQ", i_val_seq);

                                list_item.AddString("CHAR_VALUE", MPCF.Trim(with_1.GetValue(i, j)));
                                if (c_type == 'N')
                                {
                                    list_item.AddDouble("VALUE", MPCF.ToDbl(with_1.GetValue(i, j)));
                                }
                                else
                                {
                                    list_item.AddDouble("VALUE", (with_1.GetValue(i, j).ToString() == "OK" ? 0 : 1));
                                }

                                if (MPCF.CheckNumeric(with_1.GetValue(i, j)) == true)
                                {
                                    list_item.AddDouble("VALUE", MPCF.ToDbl(with_1.GetValue(i, j)));
                                }
                            }
                        }
                    }
                }

                if (MPCR.CallService("CMMS", "CMMS_Update_Analysis_Plan", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        
        //
        // ViewAnalysisPlanData()
        //       - View Calibration Data
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewAnalysisPlanData()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_ANA_PLAN_DATA_IN");
            List<TRSNode> out_list = new List<TRSNode>();
            try
            {
                MPCF.FieldClear(pnlMain);
                spdRaterList.ActiveSheet.RowCount = 0;
                spdItemList.ActiveSheet.RowCount = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("ANA_ID", ANA_ID);

                TRSNode out_node = new TRSNode("CMMS_VIEW_ANA_PLAN_DATA_OUT");

                if (MPCR.CallService("CMMS", "CMMS_View_Analysis_Plan", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                dtpPlanDate.Value = MPCF.ToDate(out_node.GetString("PLAN_DATE"));
                cdvAnaMethod.Text = out_node.GetChar("ANA_DIV").ToString();
                cdvAnaMethod.DescText = MPCF.Trim(out_node.GetString("ANA_DIV_DESC"));
                txtAnaStatus.Text = MPCF.Trim(out_node.GetString("ANA_STATUS"));
                cdvUseDept.Text = MPCF.Trim(out_node.GetString("USE_DEPT_CODE"));
                cdvUseDept.DescText = MPCF.Trim(out_node.GetString("USE_DEPT_NAME"));
                cdvJudgeCode.Text = MPCF.Trim(out_node.GetString("JUDGE_USER_ID"));
                cdvJudgeCode.DescText = MPCF.Trim(out_node.GetString("JUDGE_USER_NAME"));
                cdvSampleCode.Text = MPCF.Trim(out_node.GetString("SAMPLE_CODE"));
                cdvSampleCode.DescText = MPCF.Trim(out_node.GetString("SAMPLE_NAME"));

                txtOriginalPlanDate.Text = out_node.GetString("PLAN_DATE");

                nudSampleCount.Value = out_node.GetInt("SAMPLE_COUNT");
                nudRepeatCount.Value = out_node.GetInt("REPEAT_COUNT");
                //nudRaterCount.Value = out_node.GetInt("USER_COUNT");

                chkAlarmFlag.Checked = (out_node.GetChar("ALARM_FLAG") == 'Y' ? true : false);
                nudAlarmPeriod.Value = out_node.GetInt("ALARM_PERIOD");
                cdvAlarmCode.Text = out_node.GetString("ALARM_CODE");
                cdvAlarmCode.DescText = out_node.GetString("ALARM_CODE_NAME");


                // nudSampleCount_ValueChanged(nudSampleCount, EventArgs.Empty);

                //Rater List 
                FarPoint.Win.Spread.SheetView with_1 = spdRaterList.ActiveSheet;
                int i = 0;
                List<TRSNode> analysis_rater_list = out_node.GetList("ANALYSIS_RATER_LIST");
                foreach (TRSNode node in analysis_rater_list)
                {
                    with_1.RowCount = i + 1;
                    with_1.SetValue(i, MPCF.ToInt(RATER_LIST.CHECK), false);
                    with_1.SetValue(i, MPCF.ToInt(RATER_LIST.USER_ID), node.GetString("USER_ID"));
                    with_1.SetValue(i, MPCF.ToInt(RATER_LIST.USER_NAME), node.GetString("USER_NAME"));
                    i++;
                }


                FarPoint.Win.Spread.SheetView with_2 = spdItemList.ActiveSheet;
                i = 0;
                List<TRSNode> analysis_item_list = out_node.GetList("ANALYSIS_ITEM_LIST");
                foreach (TRSNode node in analysis_item_list)
                {
                    with_2.RowCount = i + 1;
                    with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.CHECK), false);
                    with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.ITEM_CODE), node.GetString("ITEM_CODE"));
                    with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.ITEM_NAME), node.GetString("ITEM_NAME"));
                    with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.LSL), node.GetDouble("LSL"));
                    with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.USL), node.GetDouble("USL"));
                    with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.UNIT_CODE), node.GetString("UNIT_CODE"));
                    with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.DECIMAL_PLACE), node.GetInt("DECIMAL_PLACE"));

                    if (out_node.GetChar("ANA_DIV") != '1')
                    {
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_01), MPCF.ToDbl(node.GetString("CHAR_VALUE_01")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_02), MPCF.ToDbl(node.GetString("CHAR_VALUE_02")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_03), MPCF.ToDbl(node.GetString("CHAR_VALUE_03")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_04), MPCF.ToDbl(node.GetString("CHAR_VALUE_04")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_05), MPCF.ToDbl(node.GetString("CHAR_VALUE_05")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_06), MPCF.ToDbl(node.GetString("CHAR_VALUE_06")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_07), MPCF.ToDbl(node.GetString("CHAR_VALUE_07")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_08), MPCF.ToDbl(node.GetString("CHAR_VALUE_08")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_09), MPCF.ToDbl(node.GetString("CHAR_VALUE_09")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_10), MPCF.ToDbl(node.GetString("CHAR_VALUE_10")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_11), MPCF.ToDbl(node.GetString("CHAR_VALUE_11")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_12), MPCF.ToDbl(node.GetString("CHAR_VALUE_12")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_13), MPCF.ToDbl(node.GetString("CHAR_VALUE_13")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_14), MPCF.ToDbl(node.GetString("CHAR_VALUE_14")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_15), MPCF.ToDbl(node.GetString("CHAR_VALUE_15")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_16), MPCF.ToDbl(node.GetString("CHAR_VALUE_16")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_17), MPCF.ToDbl(node.GetString("CHAR_VALUE_17")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_18), MPCF.ToDbl(node.GetString("CHAR_VALUE_18")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_19), MPCF.ToDbl(node.GetString("CHAR_VALUE_19")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_20), MPCF.ToDbl(node.GetString("CHAR_VALUE_20")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_21), MPCF.ToDbl(node.GetString("CHAR_VALUE_21")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_22), MPCF.ToDbl(node.GetString("CHAR_VALUE_22")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_23), MPCF.ToDbl(node.GetString("CHAR_VALUE_23")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_24), MPCF.ToDbl(node.GetString("CHAR_VALUE_24")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_25), MPCF.ToDbl(node.GetString("CHAR_VALUE_25")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_26), MPCF.ToDbl(node.GetString("CHAR_VALUE_26")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_27), MPCF.ToDbl(node.GetString("CHAR_VALUE_27")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_28), MPCF.ToDbl(node.GetString("CHAR_VALUE_28")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_29), MPCF.ToDbl(node.GetString("CHAR_VALUE_29")));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_30), MPCF.ToDbl(node.GetString("CHAR_VALUE_30")));
                    }
                    else
                    {
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_01), node.GetString("CHAR_VALUE_01"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_02), node.GetString("CHAR_VALUE_02"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_03), node.GetString("CHAR_VALUE_03"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_04), node.GetString("CHAR_VALUE_04"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_05), node.GetString("CHAR_VALUE_05"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_06), node.GetString("CHAR_VALUE_06"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_07), node.GetString("CHAR_VALUE_07"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_08), node.GetString("CHAR_VALUE_08"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_09), node.GetString("CHAR_VALUE_09"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_10), node.GetString("CHAR_VALUE_10"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_11), node.GetString("CHAR_VALUE_11"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_12), node.GetString("CHAR_VALUE_12"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_13), node.GetString("CHAR_VALUE_13"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_14), node.GetString("CHAR_VALUE_14"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_15), node.GetString("CHAR_VALUE_15"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_16), node.GetString("CHAR_VALUE_16"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_17), node.GetString("CHAR_VALUE_17"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_18), node.GetString("CHAR_VALUE_18"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_19), node.GetString("CHAR_VALUE_19"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_20), node.GetString("CHAR_VALUE_20"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_21), node.GetString("CHAR_VALUE_21"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_22), node.GetString("CHAR_VALUE_22"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_23), node.GetString("CHAR_VALUE_23"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_24), node.GetString("CHAR_VALUE_24"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_25), node.GetString("CHAR_VALUE_25"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_26), node.GetString("CHAR_VALUE_26"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_27), node.GetString("CHAR_VALUE_27"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_28), node.GetString("CHAR_VALUE_28"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_29), node.GetString("CHAR_VALUE_29"));
                        with_2.SetValue(i, MPCF.ToInt(ITEM_LIST.VALUE_30), node.GetString("CHAR_VALUE_30"));
                    }


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

        #endregion

        private void frmMMSAnalisisPlanPopup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');
                SetspdItemColumn(0);

                txtEquipCode.Text = EQUIP_ID;
                txtEquipName.Text = EQUIP_NAME;
                dtpPlanDate.Value = MPCF.ToDate(PLAN_DATE);

                if (ANA_ID != "")
                    ViewAnalysisPlanData();

                //pnlTranCenter.Enabled = ENABLE_FLAG;
                btnProcess.Enabled = ENABLE_FLAG;

                b_load_flag = true;
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                // TODO
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

                if (UpdateAnalysisPlanRegistration() == false) return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void chkRaterAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < spdRaterList.ActiveSheet.RowCount; i++)
                {
                    spdRaterList.ActiveSheet.SetValue(i, (int)RATER_LIST.CHECK, chkRaterAll.Checked);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkItemAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < spdItemList.ActiveSheet.RowCount; i++)
                {
                    spdItemList.ActiveSheet.SetValue(i, (int)ITEM_LIST.CHECK, chkItemAll.Checked);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnRaterDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = spdRaterList.ActiveSheet.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToBoolean(spdRaterList.ActiveSheet.GetValue(i, (int)RATER_LIST.CHECK)) == true)
                    {
                        if (MPCF.Trim(spdRaterList.ActiveSheet.GetTag(i, (int)RATER_LIST.CHECK)).ToString() == "I")
                        {
                            spdRaterList.ActiveSheet.Rows[i].Remove();
                        }
                        else
                        {
                            spdRaterList.ActiveSheet.SetValue(i, (int)RATER_LIST.CHECK, true);
                            spdRaterList.ActiveSheet.SetTag(i, (int)RATER_LIST.CHECK, "D");
                            spdRaterList.ActiveSheet.Rows[i].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnItemDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = spdItemList.ActiveSheet.RowCount - 1; i >= 0; i--)
                {
                    if (Convert.ToBoolean(spdItemList.ActiveSheet.GetValue(i, (int)ITEM_LIST.CHECK)) == true)
                    {
                        if (MPCF.Trim(spdItemList.ActiveSheet.GetTag(i, (int)ITEM_LIST.CHECK)).ToString() == "I")
                        {
                            spdItemList.ActiveSheet.Rows[i].Remove();
                        }
                        else
                        {
                            spdItemList.ActiveSheet.SetValue(i, (int)ITEM_LIST.CHECK, true);
                            spdItemList.ActiveSheet.SetTag(i, (int)ITEM_LIST.CHECK, "D");
                            spdItemList.ActiveSheet.Rows[i].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        private void btnItemAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int i = spdItemList.ActiveSheet.RowCount;
                spdItemList.ActiveSheet.RowCount++;
                spdItemList.ActiveSheet.SetValue(i, (int)ITEM_LIST.CHECK, true);
                spdItemList.ActiveSheet.SetTag(i, (int)ITEM_LIST.CHECK, "I");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnRaterAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int i_max_count = 0;
                int i_count = 0;
                int i = 0; // spdRaterList.ActiveSheet.RowCount;

                if (MPCF.Trim(cdvAnaMethod.Text) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(615)); //Please enter a Analysis Method.
                    return;
                }

                if (MPCF.Trim(cdvAnaMethod.Text) == "0" || MPCF.Trim(cdvAnaMethod.Text) == "1")
                {
                    i_max_count = 3;
                }
                else if (MPCF.Trim(cdvAnaMethod.Text) == "2" || MPCF.Trim(cdvAnaMethod.Text) == "3")
                {
                    i_max_count = 1;
                }

                for (i = 0; i < spdRaterList.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdRaterList.ActiveSheet.GetTag(i, (int)RATER_LIST.CHECK)) != "D")
                    {
                        i_count++;
                    }
                }

                if (i_count >= i_max_count)
                {
                    MPCF.ShowMsgBox(string.Format(MPCF.GetMessage(616), i_max_count.ToString())); //Only {0} people can register.
                    return;
                }
                                
                spdRaterList.ActiveSheet.RowCount++;
                spdRaterList.ActiveSheet.SetValue(i, (int)RATER_LIST.CHECK, true);
                spdRaterList.ActiveSheet.SetTag(i, (int)RATER_LIST.CHECK, "I");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void spdRaterList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                switch (e.Column)
                {
                    case (int)RATER_LIST.USER_BUTTON:
                        cdvRaterList.Init();
                        cdvRaterList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvRaterList.GetListView);
                        cdvRaterList.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                        cdvRaterList.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                       // cdvRaterList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        if (SECLIST.ViewSECUserList(cdvRaterList.GetListView) == false)
                        {
                            return;
                        }

                        if (cdvRaterList.ShowPopupList(e.Row, e.Column - 1) == false)
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

        private void cdvRaterList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            
            switch (e.Col)
            {
                case (int)RATER_LIST.USER_ID:
                    if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) == "") return;

                    for (int i = 0; i < spdRaterList.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdRaterList.ActiveSheet.GetValue(i, e.Col)).Equals(e.SelectedItem.SubItems[0].Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(617)); //The same inspector exist.
                            return;
                        }
                    }
                    spdRaterList.ActiveSheet.SetValue(e.Row, e.Col, e.SelectedItem.SubItems[0].Text);
                    spdRaterList.ActiveSheet.SetValue(e.Row, e.Col + 2, e.SelectedItem.SubItems[1].Text);
                    break;
            }
        }

        private void spdItemList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                switch (e.Column)
                {
                    case (int)ITEM_LIST.ITEM_BUTTON:

                        if (MPCF.Trim(cdvAnaMethod.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(615)); //Please enter a Analysis Method.
                            return;
                        }

                        cdvItemList.Init();
                        cdvItemList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvItemList.GetListView);
                        cdvItemList.Columns.Add("Item Code", 100, HorizontalAlignment.Left);
                        cdvItemList.Columns.Add("Item Name", 150, HorizontalAlignment.Left);
                        cdvItemList.Columns.Add("LSL", 100, HorizontalAlignment.Right);
                        cdvItemList.Columns.Add("USL", 100, HorizontalAlignment.Right);
                        cdvItemList.Columns.Add("Unit", 100, HorizontalAlignment.Center);
                        cdvItemList.Columns.Add("Decimal Place", 100, HorizontalAlignment.Right);
                       // cdvItemList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        if (HQCF.ViewEquipmentItemList(cdvItemList.GetListView, EQUIP_ID, MPCF.ToChar(cdvAnaMethod.Text)) == false)
                        {
                            return;
                        }
                        
                        if (cdvItemList.ShowPopupList(e.Row, e.Column - 1) == false)
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

        private void cdvItemList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {

            switch (e.Col)
            {
                case (int)ITEM_LIST.ITEM_CODE:

                    if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) == "") return;
                    for (int i = 0; i < spdItemList.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdItemList.ActiveSheet.GetValue(i, e.Col)).Equals(e.SelectedItem.SubItems[0].Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(618)); //The same inspection item.
                            return;
                        }
                    }
                    spdItemList.ActiveSheet.SetValue(e.Row, e.Col, e.SelectedItem.SubItems[0].Text);
                    spdItemList.ActiveSheet.SetValue(e.Row, (int)ITEM_LIST.ITEM_NAME, e.SelectedItem.SubItems[1].Text);
                    spdItemList.ActiveSheet.SetValue(e.Row, (int)ITEM_LIST.LSL, e.SelectedItem.SubItems[2].Text);
                    spdItemList.ActiveSheet.SetValue(e.Row, (int)ITEM_LIST.USL, e.SelectedItem.SubItems[3].Text);
                    spdItemList.ActiveSheet.SetValue(e.Row, (int)ITEM_LIST.UNIT_CODE, e.SelectedItem.SubItems[4].Text);
                    spdItemList.ActiveSheet.SetValue(e.Row, (int)ITEM_LIST.DECIMAL_PLACE, e.SelectedItem.SubItems[5].Text);
                    break;
            }
        }

        private void cdvSampleCode_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvSampleCode.Init();
                MPCF.InitListView(cdvSampleCode.GetListView);
                cdvSampleCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
                cdvSampleCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvSampleCode.SelectedSubItemIndex = 0;
                if (HQCF.ViewMMSSampleList(cdvSampleCode.GetListView) == true)
                {
                    cdvSampleCode.InsertEmptyRow(0, 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvJudgeCode_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvJudgeCode.Init();
                MPCF.InitListView(cdvJudgeCode.GetListView);
                cdvJudgeCode.Columns.Add("User ID", 150, HorizontalAlignment.Left);
                cdvJudgeCode.Columns.Add("User Name", 200, HorizontalAlignment.Left);
                cdvJudgeCode.SelectedSubItemIndex = 0;
                if (SECLIST.ViewSECUserList(cdvJudgeCode.GetListView) == true)
                {
                    cdvJudgeCode.InsertEmptyRow(0, 1);
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

        private void nudSampleCount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SetspdItemColumn((int)nudSampleCount.Value);
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
                //cdvAnaMethod.Columns.Add("Sample Count", 100, HorizontalAlignment.Right);
                //cdvAnaMethod.Columns.Add("Repeat Count", 100, HorizontalAlignment.Right);
                //cdvAnaMethod.Columns.Add("Analysis Type", 100, HorizontalAlignment.Left);
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

        private void cdvAnaMethod_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                char c_type = 'N';
                // Sample Count : [0]Variables = 10, [1]Attributes = 30, [2]Bias = 15, [3]Linearity = 5,
                // Repeat Count : [0]Variables = 3, [1]Attributes = 3, [2]Bias = 1, [3]Linearity = 10,

                if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) != "")
                {
                    if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) == "0")
                    {
                        nudSampleCount.Maximum = 10;
                        nudRepeatCount.Maximum = 3;
                    }
                    else if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) == "1")
                    {
                        nudSampleCount.Maximum = 30;
                        nudRepeatCount.Maximum = 3;
                        c_type = 'C';
                    }
                    else if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) == "2")
                    {
                        nudSampleCount.Maximum = 15;
                        nudRepeatCount.Maximum = 1;
                    }
                    else if (MPCF.Trim(e.SelectedItem.SubItems[0].Text) == "3")
                    {
                        nudSampleCount.Maximum = 5;
                        nudRepeatCount.Maximum = 10;
                    }
                    else
                    {
                        nudSampleCount.Maximum = 1;
                        nudRepeatCount.Maximum = 1;
                        MPCF.ShowMsgBox(MPCF.GetMessage(619)); //There is an error in the analysis method.
                    }
                }
                spdRaterList.ActiveSheet.RowCount = 0;
                spdItemList.ActiveSheet.RowCount = 0;
                SetSpdItemCelltype(c_type);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            finally
            {
                nudSampleCount_ValueChanged(nudSampleCount, EventArgs.Empty);
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
    }
}
