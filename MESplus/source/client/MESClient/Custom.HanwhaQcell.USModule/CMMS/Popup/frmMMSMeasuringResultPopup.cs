//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSMeasuringResultPopup.cs
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
    public partial class frmMMSMeasuringResultPopup : TranForm01
    {
        public frmMMSMeasuringResultPopup()
        {
            InitializeComponent();
            spdMeasuringResultList.ActiveSheet.RowCount = 0;
            spdMeasuringResultList.ActiveSheet.ColumnCount = 0;
        }


        #region " Constant Definition "
        private string m_ana_id;
        private string m_equip_id;
        private string m_equip_name;
        private string m_item_code;
        private char m_ana_div;
        private string m_ana_status;
        private int i_base_value_count;

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


        public string ANA_STATUS
        {
            get
            {
                if (m_ana_status == null)
                {
                    m_ana_status = "";
                }
                return m_ana_status;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_ana_status = "";
                }
                m_ana_status = value;
            }
        }

        public char ANA_DIV
        {
            get
            {
                //if (m_ana_div == null)
                //{
                //    m_ana_div = ' ';
                //}
                return m_ana_div;
            }
            set
            {
                //if (value == null)
                //{
                //    m_ana_div = ' ';
                //}
                m_ana_div = value;
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

        public string ITEM_CODE
        {
            get
            {
                if (m_item_code == null)
                {
                    m_item_code = "";
                }
                return m_item_code;
            }
            set
            {
                if (value == null || value == "")
                {
                    m_item_code = "";
                }
                m_item_code = value;
            }
        }

        public int BASE_VALUE_COUNT
        {
            get
            {
                return i_base_value_count;
            }
            set
            {
                i_base_value_count = value;
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
            
            switch (FuncName)
            {
                   
                case "TRAN1":

                    if (dtpMeasurementDate.Value > DateTime.Now)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(634));
                        return false;
                    }
                    break;
                case "TRAN2":
                    // TODO
                    break;
            }

            return true;            
        }

        /// <summary>
        /// get Const Code Value
        /// </summary>
        /// <returns></returns>
        private bool getVariablesConstValue(string s_code_1, int s_key_1, string s_code_2, int s_key_2, string s_code_3
                                 , int s_key_3, string s_code_4, int s_key_4, string s_code_5, int s_key_5
                                 , ref double s_value_1, ref double s_value_2, ref double s_value_3, ref double s_value_4, ref double s_value_5)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            List<TRSNode> Rows;

            string sQuery = string.Empty;
            s_value_1 = 1.0d;
            s_value_2 = 1.0d;
            s_value_3 = 1.0d;
            s_value_4 = 1.0d;
            s_value_5 = 1.0d;
            try
            {

                sQuery = "SELECT KEY_1, KEY_2, DATA_1 FROM MGCMTBLDAT WHERE FACTORY = '" + MPGV.gsFactory + "' ";
                sQuery = sQuery + "AND TABLE_NAME = 'MMS_CONST_CODE' ";

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("SQL", sQuery);

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                Rows = out_node.GetList("ROWS");
                foreach (TRSNode Row in Rows)
                {
                    if (s_code_1 == MPCF.Trim(Row.GetList("COLS")[0].GetString("DATA")) && s_key_1 == MPCF.ToInt(Row.GetList("COLS")[1].GetString("DATA")))
                    {
                        s_value_1 = MPCF.ToDbl(Row.GetList("COLS")[2].GetString("DATA"));
                    }
                    if (s_code_2 == MPCF.Trim(Row.GetList("COLS")[0].GetString("DATA")) && s_key_2 == MPCF.ToInt(Row.GetList("COLS")[1].GetString("DATA")))
                    {
                        s_value_2 = MPCF.ToDbl(Row.GetList("COLS")[2].GetString("DATA"));
                    }
                    if (s_code_3 == MPCF.Trim(Row.GetList("COLS")[0].GetString("DATA")) && s_key_3 == MPCF.ToInt(Row.GetList("COLS")[1].GetString("DATA")))
                    {
                        s_value_3 = MPCF.ToDbl(Row.GetList("COLS")[2].GetString("DATA"));
                    }
                    if (s_code_4 == MPCF.Trim(Row.GetList("COLS")[0].GetString("DATA")) && s_key_4 == MPCF.ToInt(Row.GetList("COLS")[1].GetString("DATA")))
                    {
                        s_value_4 = MPCF.ToDbl(Row.GetList("COLS")[2].GetString("DATA"));
                    }
                    if (s_code_5 == MPCF.Trim(Row.GetList("COLS")[0].GetString("DATA")) && s_key_5 == MPCF.ToInt(Row.GetList("COLS")[1].GetString("DATA")))
                    {
                        s_value_5 = MPCF.ToDbl(Row.GetList("COLS")[2].GetString("DATA"));
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

        /// <summary>
        /// get Const Code ValueBias
        /// </summary>
        /// <returns></returns>
        private bool getBiasConstValue(string s_code_1, int s_key_1, string s_code_2, int s_key_2, ref double s_value_1, ref double s_value_2)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            List<TRSNode> Rows;

            string sQuery = string.Empty;
            s_value_1 = 1.0d;
            s_value_2 = 1.0d;
            try
            {

                sQuery = "SELECT KEY_1, KEY_2, DATA_1 FROM MGCMTBLDAT WHERE FACTORY = '" + MPGV.gsFactory + "' ";
                sQuery = sQuery + "AND TABLE_NAME = 'MMS_CONST_CODE' ";

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("SQL", sQuery);

                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                Rows = out_node.GetList("ROWS");
                foreach (TRSNode Row in Rows)
                {
                    if (s_code_1 == MPCF.Trim(Row.GetList("COLS")[0].GetString("DATA")) && s_key_1 == MPCF.ToInt(Row.GetList("COLS")[1].GetString("DATA")))
                    {
                        s_value_1 = MPCF.ToDbl(Row.GetList("COLS")[2].GetString("DATA"));
                    }
                    if (s_code_2 == MPCF.Trim(Row.GetList("COLS")[0].GetString("DATA")) && s_key_2 == MPCF.ToInt(Row.GetList("COLS")[1].GetString("DATA")))
                    {
                        s_value_2 = MPCF.ToDbl(Row.GetList("COLS")[2].GetString("DATA"));
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

            int i_sample_count;
            int i_repeat_count;
            int i_rater_count;
            int i_decimal_palce;
            int i = 0;
            int j = 0;
            int k = 0;
            string s_number_of_times = "";
            string s_number = MPCF.GetMessage(602);
            string s_base_value = "Base" + Environment.NewLine + "Value";
            if (MPGV.gcLanguage == '2') s_base_value = "기준값";

            try
            {

                MPCF.FieldClear(pnlCenter);
                txtEquipCode.Text = EQUIP_ID;
                txtEquipName.Text = EQUIP_NAME;
                spdMeasuringResultList.ActiveSheet.RowCount = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("ANA_ID", ANA_ID);
                in_node.AddString("ITEM_CODE", ITEM_CODE);

                TRSNode out_node = new TRSNode("CMMS_VIEW_ANA_PLAN_DATA_OUT");

                if (MPCR.CallService("CMMS", "CMMS_View_Analysis_Plan", in_node, ref out_node) == false)
                {
                    return false;
                }

                this.Text = "Measuring Result Registration [" + MPCF.Trim(out_node.GetString("ANA_DIV_DESC")) + "]";
                ANA_DIV = out_node.GetChar("ANA_DIV");
                ANA_STATUS = MPCF.Trim(out_node.GetString("ANA_STATUS"));

                if (ANA_DIV == '0')
                {
                    BASE_VALUE_COUNT = 0;
                }
                else
                {
                    BASE_VALUE_COUNT = 1;
                }

                if (ANA_DIV == '1')
                {
                    pnlMinMax.Visible = false;
                    pnlInputType.Visible = true;
                    rdoNumberType.Checked = true;
                }
                else
                {
                    pnlMinMax.Visible = true;
                    pnlInputType.Visible = false;
                }

                cdvSampleCode.Text = MPCF.Trim(out_node.GetString("SAMPLE_CODE"));
                cdvSampleCode.DescText = MPCF.Trim(out_node.GetString("SAMPLE_NAME"));
                txtPlanDate.Text = MPCF.MakeDateFormat(out_node.GetString("PLAN_DATE"), DATE_TIME_FORMAT.DATE);

                i_sample_count = out_node.GetInt("SAMPLE_COUNT");
                i_repeat_count = out_node.GetInt("REPEAT_COUNT");
                i_rater_count = out_node.GetInt("USER_COUNT");
                i_decimal_palce = out_node.GetInt("DECIMAL_PLACE");

                txtSampleCount.Text = i_sample_count.ToString();
                txtRepeatCount.Text = i_repeat_count.ToString();
                txtUserCount.Text = i_rater_count.ToString();

                txtLSL.Text = out_node.GetDouble("LSL").ToString();
                txtUSL.Text = out_node.GetDouble("USL").ToString();

                cdvItemCode.Text = MPCF.Trim(out_node.GetString("ITEM_CODE"));
                cdvItemCode.DescText = MPCF.Trim(out_node.GetString("ITEM_NAME"));

                //Rater List 
                FarPoint.Win.Spread.SheetView with_1 = spdMeasuringResultList.ActiveSheet;

                with_1.RowCount = i_sample_count;
                with_1.ColumnCount = (i_repeat_count * i_rater_count) + BASE_VALUE_COUNT;

                if (BASE_VALUE_COUNT > 0)
                {
                    with_1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
                    with_1.ColumnHeader.Cells.Get(0, 0).Text = s_base_value; // "Base" + Environment.NewLine + "Value";
                }
                
                List<TRSNode> analysis_rater_list = out_node.GetList("ANALYSIS_RATER_LIST");
                foreach (TRSNode node in analysis_rater_list)
                {
                    k = BASE_VALUE_COUNT + (i * i_repeat_count);
                    for (j = 0; j < i_repeat_count; j++)
                    {
                        with_1.ColumnHeader.Cells.Get(0, (k + j)).Value = node.GetString("USER_ID");
                        with_1.ColumnHeader.Cells.Get(0, (k + j)).Text = node.GetString("USER_NAME");
                        with_1.ColumnHeader.Cells.Get(0, (k + j)).Tag = node.GetInt("USER_SEQ");
                        if (j == 0)
                        {
                            if (i_repeat_count > 1)
                            {
                                with_1.ColumnHeader.Cells.Get(0, (k + j)).ColumnSpan = i_repeat_count;
                            }
                        }


                        if (MPGV.gcLanguage == '2')
                        {
                            s_number_of_times = (j + 1).ToString() + s_number;
                        }
                        else 
                        {
                            if ((j + 1) == 1) 
                                s_number_of_times = "1st";
                            else if ((j + 1) == 2)
                                s_number_of_times = "2nd";
                            else if ((j + 1) == 3)
                                s_number_of_times = "3rd";
                            else
                                s_number_of_times = (j + 1).ToString() + "th";
                        }
                        with_1.ColumnHeader.Cells.Get(1, (k + j)).Value = s_number_of_times; // (j + 1).ToString() + s_number_of_times;
                        with_1.ColumnHeader.Cells.Get(1, (k + j)).Tag = (j + 1).ToString();
                    }
                    i++;
                }

                //Item 기준 값 바인딩.
                i = 0;
                List<TRSNode> analysis_item_value_list = out_node.GetList("ANALYSIS_ITEM_VALUE_LIST");
                foreach (TRSNode node in analysis_item_value_list)
                {
                    i = node.GetInt("VAL_SEQ");
                    with_1.SetValue((i - 1), 0, node.GetDouble("VALUE"));
                }
                
                //Cell Type 설정 
                FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
                if (ANA_DIV == '1')
                {
                    numberCellType1.DecimalPlaces = 0; //소수접은 제로
                }
                else
                {
                    numberCellType1.DecimalPlaces = i_decimal_palce;
                }
                
                if (BASE_VALUE_COUNT > 0)
                {                    
                    with_1.Columns[0].Locked = true;
                    with_1.Columns[0].Width = 70;
                }

                for (i = BASE_VALUE_COUNT; i < with_1.ColumnCount; i++)
                {
                    with_1.Columns[i].Width = 65;
                    with_1.Columns[i].Locked = false;
                    with_1.Columns[i].CellType = numberCellType1;
                }

                //기 입력된 Data 바인딩
                i = 0;
                int iCol;
                List<TRSNode> analysis_result_value_list = out_node.GetList("ANALYSIS_RESULT_VALUE_LIST");
                foreach (TRSNode node in analysis_result_value_list)
                {
                    i = node.GetInt("USER_SEQ") - 1;
                    j = node.GetInt("REPEAT_SEQ") - 1;
                    k = node.GetInt("SAMPLE_SEQ");

                    iCol = ((i * i_repeat_count) + (j + BASE_VALUE_COUNT));

                    with_1.SetValue((k - 1), iCol, node.GetDouble("VALUE"));
                }


                if (ANA_DIV == '1')
                {
                    with_1.Cells[0, 0, with_1.RowCount - 1, with_1.ColumnCount - 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            finally
            {
                if (ANA_STATUS == "0")
                {
                    btnProcess.Enabled = true;
                }
                else
                {
                    btnProcess.Enabled = false;
                }
            }
        }

        private void SetSpdItemCelltype(char c_type)
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdMeasuringResultList.ActiveSheet;

                int iMinCol = with_1.ColumnCount - 1;
                int iMaxCol = with_1.ColumnCount - 1;
                int i;
                if (c_type == 'C')
                {
                    string[] c_item = new string[2];

                    c_item[0] = "OK";
                    c_item[1] = "NG";
                    FarPoint.Win.Spread.CellType.ComboBoxCellType cell_type = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    cell_type.Items = c_item;

                    for (i = 0; i < with_1.RowCount; i++)
                    {
                        if (with_1.GetValue(i, 0).ToString() == "1")
                        {
                            with_1.SetValue(i, 0, "OK");
                        }
                        else
                        {
                            with_1.SetValue(i, 0, "NG");
                        }
                    }

                    for (i = 1; i < (iMaxCol + 1); i++)
                    {
                        with_1.Columns[i].CellType = cell_type;
                    }
                }
                else
                {
                    FarPoint.Win.Spread.CellType.NumberCellType cell_type = new FarPoint.Win.Spread.CellType.NumberCellType();
                    cell_type.DecimalPlaces = 0;
                    for (i = 0; i < with_1.RowCount; i++)
                    {
                        if (with_1.GetValue(i, 0).ToString() == "OK")
                        {
                            with_1.SetValue(i, 0, 1);
                        }
                        else
                        {
                            with_1.SetValue(i, 0, 0);
                        }
                    }

                    for (i = 1; i < (iMaxCol + 1); i++)
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
        // SaveVariables()
        //       - SaveVariables(ANA_DIV = '0')
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SaveVariables()
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_MEASURING_RESULT_REGISTRATION_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_MEASURING_RESULT_REGISTRATION_OUT");
            TRSNode list_item;

            double d_const_tol = 1.0d;
            double d_const_d4 = 1.0d;
            double d_const_k1 = 1.0d;
            double d_const_k2 = 1.0d;
            double d_const_k3 = 1.0d;
            int i, j;
            try
            {

                FarPoint.Win.Spread.SheetView with_1 = spdMeasuringResultList.ActiveSheet;

                int i_user_count = MPCF.ToInt(txtUserCount.Text);
                int i_repeat_count = MPCF.ToInt(txtRepeatCount.Text);
                int i_sample_count = MPCF.ToInt(txtSampleCount.Text);


                getVariablesConstValue("D4", i_repeat_count, "K1", i_repeat_count, "K2", i_user_count, "K3", i_sample_count, "TOL", 0, ref d_const_d4, ref d_const_k1, ref d_const_k2, ref d_const_k3, ref d_const_tol);


                int i_total_count = i_user_count * i_repeat_count * i_sample_count;
                int i_user_sample_count = i_user_count * i_sample_count;
                int i_user_repeat_count = i_user_count * i_repeat_count;
                int i_repeat_sample_count = i_repeat_count * i_sample_count;

                int i_check_count = 0;

                double d_total_sum_data = 0.0d;
                double d_data_min = double.MaxValue;
                double d_data_max = double.MinValue;
                double d_avg_diff_sum = 0.0d;

                double d_user_avg_min = double.MaxValue;
                double d_user_avg_max = double.MinValue;
                double d_sample_avg_min = double.MaxValue;
                double d_sample_avg_max = double.MinValue;

                double[] d_user_sum_data = new double[i_user_count];
                double[] d_user_avg_data = new double[i_user_count];
                double[] d_sample_avg_data = new double[i_sample_count];
                double[,] d_user_repeat_sample = new double[i_user_count,i_repeat_sample_count];
                double[, ,] d_user_sample_range = new double[i_user_count, i_sample_count, 3];

                for (i = 0; i < i_user_count; i++)
                {
                    for (j = 0; j < i_sample_count; j++)
                    {
                        d_user_sample_range[i, j, 0] = double.MaxValue;
                        d_user_sample_range[i, j, 1] = double.MinValue;
                        d_user_sample_range[i, j, 2] = 0.0d;
                        d_sample_avg_data[j] = 0.0d;
                    }
                    d_user_sum_data[i] = 0.0d;
                    d_user_avg_data[i] = 0.0d;
                }

                for (i = BASE_VALUE_COUNT; i < with_1.ColumnCount; i++)
                {
                    for (j = 0; j < with_1.RowCount; j++)
                    {
                        if (with_1.GetValue(j, i) == null)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(623)); //Measurement has an empty value.
                            return false;
                        }
                        if (MPCF.Trim(with_1.GetValue(j, i)) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(623)); //Measurement has an empty value.
                            return false;
                        }
                        i_check_count++;

                        double d_value = MPCF.ToDbl(with_1.GetValue(j, i));

                        d_total_sum_data += d_value;

                        d_data_min = Math.Min(d_data_min, d_value);
                        d_data_max = Math.Max(d_data_max, d_value);


                        int i_user_seq = MPCF.ToInt(with_1.ColumnHeader.Cells.Get(0, i).Tag) - 1;
                        int i_repeat_seq = MPCF.ToInt(with_1.ColumnHeader.Cells.Get(1, i).Tag) - 1;
                        int i_sample_seq = MPCF.ToInt(j);

                        d_user_sum_data[i_user_seq] += d_value;
                        d_sample_avg_data[i_sample_seq] += d_value;

                        d_user_sample_range[i_user_seq, i_sample_seq, 0] = Math.Min(d_user_sample_range[i_user_seq, i_sample_seq, 0], d_value);
                        d_user_sample_range[i_user_seq, i_sample_seq, 1] = Math.Max(d_user_sample_range[i_user_seq, i_sample_seq, 1], d_value);
                        d_user_repeat_sample[i_user_seq, (i_repeat_seq * i_sample_count) + i_sample_seq] = d_value;
                    }
                }

                if (i_total_count != i_check_count)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(624)); //The number of measurement lists does not match.
                    return false;
                }

                // avg diff
                for (i = 0; i < i_user_count; i++)
                {
                    for (j = 0; j < i_sample_count; j++)
                    {
                        d_user_sample_range[i, j, 2] = Math.Abs(d_user_sample_range[i, j, 1] - d_user_sample_range[i, j, 0]);
                        d_avg_diff_sum += d_user_sample_range[i, j, 2];
                    }
                    d_user_avg_data[i] = d_user_sum_data[i] / i_repeat_sample_count;
                    d_user_avg_min = Math.Min(d_user_avg_min, d_user_avg_data[i]);
                    d_user_avg_max = Math.Max(d_user_avg_max, d_user_avg_data[i]);
                }

                // RP
                for (i = 0; i < i_sample_count; i++)
                {
                    d_sample_avg_data[i] /= i_user_repeat_count;
                    d_sample_avg_min = Math.Min(d_sample_avg_min, d_sample_avg_data[i]);
                    d_sample_avg_max = Math.Max(d_sample_avg_max, d_sample_avg_data[i]);
                }

                // CP - stdevp
                double[] d_sum_diff_user = new double[i_user_count];
                double[] d_stdevp = new double[i_user_count];
                double d_stde_all = 0.0d;
                double d_sum_diff = 0.0d;

                for (i = 0; i < i_user_count; i++)
                {
                    d_sum_diff_user[i] = 0.0d;
                    for (j = 0; j < (i_repeat_count * i_sample_count); j++)
                    {
                        double d_diff = d_user_repeat_sample[i, j] - d_user_avg_data[i];
                        d_sum_diff_user[i] += Math.Pow(d_diff, 2);
                    }
                    d_stdevp[i] = Math.Sqrt(d_sum_diff_user[i] / i_repeat_sample_count);
                    d_sum_diff += d_sum_diff_user[i];
                }
                d_stde_all = Math.Sqrt(d_sum_diff / i_total_count);


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ANA_ID", ANA_ID);
                in_node.AddString("ITEM_CODE", cdvItemCode.Text);
                in_node.AddString("ANA_DATE", this.dtpMeasurementDate.Value.ToString("yyyyMMdd"));
                //전체 측정값의 합
                in_node.AddDouble("SUM", d_total_sum_data);
                //전체 측정값중 MAX-MIN
                in_node.AddDouble("RANGE", Math.Abs(d_data_max - d_data_min));
                //전체 평균값 측청합 / 측정 갯수
                double d_average = (d_total_sum_data / i_total_count);
                in_node.AddDouble("AVERAGE", d_average);
                //측정자별 평균값의 MAX-MIN
                double d_avg_diff = Math.Abs(d_user_avg_max - d_user_avg_min);
                in_node.AddDouble("AVG_DIFF", d_avg_diff);
                //측정 횟수별 범의(MAX-MIN)값의 평균
                in_node.AddDouble("RANGE_AVG", (d_avg_diff_sum / i_user_sample_count));
                // 샘플차수별 평균값의 MAX - MIN
                in_node.AddDouble("RP", Math.Abs(d_sample_avg_max - d_sample_avg_min));

                //ABS(USL-LSL)/TOL
                double d_tol = 0;
                if (MPCF.Trim(txtLSL.Text) != "" && MPCF.Trim(txtUSL.Text) != "")
                {
                    d_tol = MPCF.ToDbl(txtLSL.Text) - MPCF.ToDbl(txtUSL.Text) == 0 ? 0 : Math.Abs(MPCF.ToDbl(txtLSL.Text) - MPCF.ToDbl(txtUSL.Text)) / d_const_tol;
                }
                in_node.AddDouble("TOL", d_tol);

                //RANGE_AVG * K1
                double d_ev = (d_avg_diff_sum / i_user_sample_count) * d_const_k1;
                in_node.AddDouble("EV", d_ev);

                // ((AVG_DIFF * K2)^2  - (EV)^2 / (SAMPLE_COUNT*REPEAT_COUNT))^0.5
                // 〖〖(¯𝑋_𝐷𝑖𝑓𝑓  × 𝐾_2)〗^2  −(〖𝐸𝑉〗^2/(𝑛𝑟) )〗^0.5
                double d_av = Math.Pow(Math.Abs(Math.Pow((d_avg_diff * d_const_k2), 2) - (Math.Pow(d_ev, 2)/i_repeat_sample_count)), 0.5);
                in_node.AddDouble("AV", d_av);

                // ((EV)^2 + (AV)^2)^0.5
                double d_rr = (Math.Pow(Math.Pow(d_ev, 2) + Math.Pow(d_av,2), 0.5));
                in_node.AddDouble("RR", d_rr);

                // RP * K3
                double d_pv = Math.Abs(d_sample_avg_max - d_sample_avg_min) * d_const_k3;
                in_node.AddDouble("PV", d_pv);

                //// ((RR)^2 + (PV)^2)^0.5
                double d_tv = Math.Pow(Math.Pow(d_rr,2) + Math.Pow(d_pv,2),0.5);
                in_node.AddDouble("TV", d_tv);

                double d_cpP = 6 * Math.Pow((Math.Pow(d_stdevp[0], 2) + Math.Pow(d_stde_all,2)),0.5);
                double d_cpA = MPCF.ToDbl(txtUSL.Text);
                double d_cpB = MPCF.ToDbl(txtLSL.Text);
                double d_cp = 0.0d;

                if (MPCF.Trim(txtUSL.Text) == "" && MPCF.Trim(txtLSL.Text) != "")
                {
                    d_cpA = d_average;
                    d_cpB = MPCF.ToDbl(txtLSL.Text);
                }
                else if (MPCF.Trim(txtUSL.Text) != "" && MPCF.Trim(txtLSL.Text) == "")
                {
                    d_cpA = d_average;
                    d_cpB = MPCF.ToDbl(txtUSL.Text);
                }

                if (d_cpP == double.NaN || d_cpA == double.NaN || d_cpB == double.NaN || d_cpA == 0 || d_cpB == 0)
                {
                    d_cp = 0;
                }
                else
                {
                    d_cp = Math.Abs(d_cpA - d_cpB) / d_cpP;
                }
                in_node.AddDouble("CP", d_cp);


                // anaValue
                double d_ana_value = 0;
                if (MPCF.Trim(txtUSL.Text) != "" && MPCF.Trim(txtLSL.Text) != "")
                {
                    d_ana_value = d_tol == 0 ? 0 : ((d_rr / d_tol) * 100);
                }
                else
                {
                    d_ana_value = d_tv == 0 ? 0 : ((d_rr / d_tv) * 100);
                }
                //d_ana_value = d_tv == 0 ? 0 : ((d_rr / d_tv) * 100);
                in_node.AddDouble("ANA_VALUE", d_ana_value);

                //auto judgement
                char c_ana_result = 'F';
                double d_nbc = (d_rr == 0 ? 0 : 1.41 * (d_pv / d_rr));
                in_node.AddString("CMF_1", Math.Round(d_nbc, 4).ToString());
                string s_ana_desc = "Registration of measurement result(VARIABLES) - auto judgement, %GRR:" + d_ana_value.ToString() + ", nbc:" + d_nbc.ToString();

                if (d_ana_value != 0 && d_nbc != 0)
                {
                    if (d_ana_value < 10 && d_nbc >= 5)
                    {
                        c_ana_result = 'P';
                    }
                    else if (d_ana_value > 10 && d_nbc >= 5)
                    {
                        c_ana_result = 'P';
                    }
                }
                in_node.AddChar("ANA_RESULT", c_ana_result);
                in_node.AddString("ANA_DESC", s_ana_desc);


                ////Item 목록 저장 
                if (SetItemValues(in_node) == false)
                    return false;


                //CONST Value 저장              
                list_item = in_node.AddNode("MEASURING_CMMSANACON_LIST");
                list_item.AddString("CONST_CODE", "TOL");
                list_item.AddDouble("CONST_VALUE", d_const_tol);

                list_item = in_node.AddNode("MEASURING_CMMSANACON_LIST");
                list_item.AddString("CONST_CODE", "D4");
                list_item.AddDouble("CONST_VALUE", d_const_d4);

                list_item = in_node.AddNode("MEASURING_CMMSANACON_LIST");
                list_item.AddString("CONST_CODE", "K1");
                list_item.AddDouble("CONST_VALUE", d_const_k1);

                list_item = in_node.AddNode("MEASURING_CMMSANACON_LIST");
                list_item.AddString("CONST_CODE", "K2");
                list_item.AddDouble("CONST_VALUE", d_const_k2);

                list_item = in_node.AddNode("MEASURING_CMMSANACON_LIST");
                list_item.AddString("CONST_CODE", "K3");
                list_item.AddDouble("CONST_VALUE", d_const_k3);


                if (MPCR.CallService("CMMS", "CMMS_Update_Measuring_Result_Registration", in_node, ref out_node) == false)
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
        // SaveAttributes()
        //       - SaveAttributes (ANA_DIV = '1')
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SaveAttributes()
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_MEASURING_RESULT_REGISTRATION_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_MEASURING_RESULT_REGISTRATION_OUT");
            int i, j;

            try 
            {
                FarPoint.Win.Spread.SheetView with_1 = spdMeasuringResultList.ActiveSheet;
                int i_user_count = MPCF.ToInt(txtUserCount.Text);
                int i_repeat_count = MPCF.ToInt(txtRepeatCount.Text);
                int i_sample_count = MPCF.ToInt(txtSampleCount.Text);

                int i_total_count = i_user_count * i_repeat_count * i_sample_count;
                int i_check_count = 0;

                for (i = BASE_VALUE_COUNT; i < with_1.ColumnCount; i++)
                {
                    for (j = 0; j < with_1.RowCount; j++)
                    {
                        if (with_1.GetValue(j, i) == null)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(623));
                            return false;
                        }
                        if (MPCF.Trim(with_1.GetValue(j, i).ToString()) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(623));
                            return false;
                        }

                        if (rdoNumberType.Checked == true)
                        {
                            if (MPCF.Trim(with_1.GetValue(j, i)).ToString() != "0" && MPCF.Trim(with_1.GetValue(j, i)).ToString() != "1")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(625)); //Only 0 or 1 can be entered.
                                return false;
                            }
                        }
                        else
                        {
                            if (MPCF.Trim(with_1.GetValue(j, i)).ToString() != "OK" && MPCF.Trim(with_1.GetValue(j, i)).ToString() != "NG")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(626)); //Only OK or NG can be entered.
                                return false;
                            }
                        }

                        i_check_count++;
                    }
                }

                if (i_total_count != i_check_count)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(624));
                    return false;
                }
                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ANA_ID", ANA_ID);
                in_node.AddString("ITEM_CODE", cdvItemCode.Text);
                in_node.AddString("ANA_DATE", this.dtpMeasurementDate.Value.ToString("yyyyMMdd"));


                if (SetItemValues(in_node) == false)
                    return false;

                if (MPCR.CallService("CMMS", "CMMS_Update_Measuring_Result_Registration", in_node, ref out_node) == false)
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
        // SaveBias()
        //       - SaveBias(ANA_DIV = '2')
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SaveBias()
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_MEASURING_RESULT_REGISTRATION_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_MEASURING_RESULT_REGISTRATION_OUT");
            TRSNode list_item;
            int i, j;

            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdMeasuringResultList.ActiveSheet;

                double d_const_a = 1.0d;
                double d_const_tv = 1.0d;


                //Bias 는 측정자와 측정 횟수 1 

                //int i_user_count = 1; //Bias 측정자는 1인 (계획등록 시 제어 필요)
                int i_repeat_count = MPCF.ToInt(txtRepeatCount.Text);
                int i_sample_count = MPCF.ToInt(txtSampleCount.Text);
                int i_check_data_count = 0;
                int i_check_value_count = 0;

                double d_total_sum_data = 0.0d;
                double d_total_sum_value = 0.0d;
                double d_averge_data = 0.0d;
                double d_averge_value = 0.0d;
                double d_averge_bias = 0.0d;
                double d_deviation = 0.0d;
                double d_variance = 0.0d;
                double d_bias_r_stdev = 0.0d;
                double d_t_statistic = 0.0d;
                double[] d_sample_data = new double[i_sample_count];

                getBiasConstValue("A", 0, "TV", 0, ref d_const_a, ref d_const_tv);

               // int i_total_count = i_user_count * i_repeat_count * i_sample_count;
 
                //기준 값 Check 
                for (i = 0; i < with_1.RowCount; i++)
                {
                    if (with_1.GetValue(i, 0) == null)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(627)); //The base value is empty.
                        return false;
                    }
                    if (MPCF.Trim(with_1.GetValue(i, 0)) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(627));
                        return false;
                    }
                    i_check_value_count++;
                    double d_value = MPCF.ToDbl(with_1.GetValue(i, 0));
                    d_total_sum_value += d_value;
                }

                if (i_sample_count != i_check_value_count)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(624));
                    return false;
                }

                for (i = BASE_VALUE_COUNT; i < with_1.ColumnCount; i++)
                {
                    for (j = 0; j < with_1.RowCount; j++)
                    {
                        if (with_1.GetValue(j, i) == null)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(623));
                            return false;
                        }
                        if (MPCF.Trim(with_1.GetValue(j, i)) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(623));
                            return false;
                        }
                        i_check_data_count++;

                        double d_value = MPCF.ToDbl(with_1.GetValue(j, i));
                        d_total_sum_data += d_value;

                        d_sample_data[j] = d_value;
                    }
                }

                if (i_sample_count != i_check_data_count)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(624));
                    return false;
                }

                d_averge_value = d_total_sum_value / i_sample_count;

                d_averge_data = d_total_sum_data / i_sample_count;

                d_averge_bias = d_averge_data - d_averge_value;


                for (i = 0; i < i_sample_count; i++)
                {
                    d_deviation = d_sample_data[i] - d_averge_data;
                    d_variance += Math.Pow(d_deviation, 2);
                }
                
                // 반복에 따른 표준편차 (𝜎 repeatability) : (BIAS_R_STDEV) = SQRT((Xi - X-bar)^2의 평균) / (SAMPLE_COUNT -1))
                // degree of freedom : (i_sample_count-1)
                d_bias_r_stdev = (i_sample_count - 1 == 0 ? 0 : Math.Sqrt(d_variance / (i_sample_count - 1)));

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ANA_ID", ANA_ID);
                in_node.AddString("ITEM_CODE", cdvItemCode.Text);
                in_node.AddString("ANA_DATE", this.dtpMeasurementDate.Value.ToString("yyyyMMdd"));

                // 측정값 전체 합
                in_node.AddDouble("SUM", d_total_sum_data);
                // 전체 측정값의 평균
                in_node.AddDouble("AVERAGE", (d_total_sum_data / i_sample_count));

                in_node.AddDouble("BIAS_R_STDEV", d_bias_r_stdev);

                // Precess Variation, TV (TV) = (USL - LSL) / 6
                double d_tv = double.NaN;
                double d_bias_ev = double.NaN;
                if (MPCF.Trim(txtUSL.Text) != "" && MPCF.Trim(txtLSL.Text) != "")
                {
                    d_tv = (MPCF.ToDbl(txtUSL.Text) - MPCF.ToDbl(txtLSL.Text)) / 6;
                    if (d_tv != 0)
                    {
                        // Acceptability %EV (EV) = (BIAS_R_STDEV / TV) * 100
                        d_bias_ev = (d_bias_r_stdev / d_tv) * 100;
                    }
                }
                in_node.AddDouble("TV", d_tv);
                in_node.AddDouble("BIAS_EV", d_bias_ev);

                // √n (STDEV_N) = SQRT(SAMPLE_COUNT)
                double d_stdev_n = Math.Sqrt(i_sample_count);
                // T 계산 용 표준편차(𝜎b) : (BIAS_T_STDEV) = BIAS_R_STDEV / STDEV_N
                double d_bias_t_stdev = d_bias_r_stdev / d_stdev_n;
                in_node.AddDouble("BIAS_T_STDEV", d_bias_t_stdev);
                // Bias 평균 (BIAS_AVG) = AVERAGE - VAL_AVG
                in_node.AddDouble("BIAS_AVG", d_averge_bias);
                // t statistic (T_STATISTIC) = BIAS_T_STDEV / BIAS_AVG (X) -> BIAS_AVG / BIAS_T_STDEV (O)  
                if (d_bias_t_stdev != 0)
                {
                    d_t_statistic = d_averge_bias / d_bias_t_stdev;
                }
                in_node.AddDouble("ANA_VALUE", d_t_statistic);

                // auto judgement
                // Bias
                double d_bias_probability = double.NaN;
                if (d_variance != 0)
                {
                    d_bias_probability = (d_averge_bias / d_variance) * 100;
                }
                // (tv, 1- α/2)
                double d_ci2 = 2.145;
                // σb(tv, 1- α/2)
                double d_confidenc_interval_95 = d_bias_t_stdev * d_ci2;
                // (tv,1-a/2) = 2.145
                char c_ana_result = 'F';
                string s_ana_desc = "Registration of measurement result(BIAS) - auto judgement, %Bias:" + d_bias_probability.ToString() + "%, %EV:" + d_bias_ev.ToString();
                s_ana_desc += "%, t statistic:" + d_t_statistic.ToString() + ", LSL:" + (d_averge_bias - d_confidenc_interval_95).ToString();
                s_ana_desc += ", USL:" + (d_averge_bias + d_confidenc_interval_95).ToString();
                                   
                if (d_bias_ev != double.NaN && d_t_statistic != double.NaN && d_averge_bias != double.NaN && d_confidenc_interval_95 != double.NaN 
                   && d_bias_ev < 30 && d_t_statistic < 2.145 && ((d_averge_bias - d_confidenc_interval_95) <= 0 && (d_averge_bias + d_confidenc_interval_95) >= 0))
                {
                    c_ana_result = 'P';
                }

                in_node.AddChar("ANA_RESULT", c_ana_result);
                in_node.AddString("ANA_DESC", s_ana_desc);


                if (SetItemValues(in_node) == false)
                    return false;


                //CONST Value 저장              
                list_item = in_node.AddNode("MEASURING_CMMSANACON_LIST");
                list_item.AddString("CONST_CODE", "A");
                list_item.AddDouble("CONST_VALUE", d_const_a);

                list_item = in_node.AddNode("MEASURING_CMMSANACON_LIST");
                list_item.AddString("CONST_CODE", "TV");
                list_item.AddDouble("CONST_VALUE", d_const_tv);
                
                if (MPCR.CallService("CMMS", "CMMS_Update_Measuring_Result_Registration", in_node, ref out_node) == false)
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
        // SaveLinearity()
        //       - SaveLinearity(ANA_DIV = '3')
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SaveLinearity()
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_MEASURING_RESULT_REGISTRATION_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_MEASURING_RESULT_REGISTRATION_OUT");
            int i, j;

            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdMeasuringResultList.ActiveSheet;


                //Linearity 는 측정자 1 

                int i_user_count = 1; //Linearity 측정자는 1인 (계획등록 시 제어 필요)
                int i_repeat_count = MPCF.ToInt(txtRepeatCount.Text);
                int i_sample_count = MPCF.ToInt(txtSampleCount.Text);
                int i_total_count = i_user_count * i_repeat_count * i_sample_count;

                int i_check_data_count = 0;
                int i_check_value_count = 0;

                double d_total_sum_data = 0.0d;
                double d_total_sum_value = 0.0d;
                double d_averge_data = 0.0d;
                double d_averge_value = 0.0d;

                double[] d_sum_sample_data = new double[i_sample_count];
                double[] d_sample_value = new double[i_sample_count];
                double[] d_average_sample_data = new double[i_sample_count];
                double[] d_sum_accuracy = new double[i_sample_count];
                 
                for(i =0; i< i_sample_count; i++)
                {
                    d_sum_sample_data[i] = 0.0d;
                    d_sample_value[i] = 0.0d;
                    d_average_sample_data[i] = 0.0d;
                    d_sum_accuracy[i] = 0.0d;
                }



                //기준 값 Check 
                for (i = 0; i < with_1.RowCount; i++)
                {
                    if (with_1.GetValue(i, 0) == null)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(627));
                        return false;
                    }
                    if (MPCF.Trim(with_1.GetValue(i, 0)) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(627));
                        return false;
                    }
                    i_check_value_count++;
                    double d_value = MPCF.ToDbl(with_1.GetValue(i, 0));
                    d_total_sum_value += d_value;
                    d_sample_value[i] = d_value;
                }

                if (i_sample_count != i_check_value_count)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(628)); //The number of base value lists does not match.
                    return false;
                }


                for (i = 0; i< with_1.RowCount; i++)
                {
                    for (j = BASE_VALUE_COUNT; j < with_1.ColumnCount; j++)
                    {
                        if (with_1.GetValue(i, j) == null)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(623));
                            return false;
                        }
                        if (MPCF.Trim(with_1.GetValue(i, j)) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(623));
                            return false;
                        }
                        i_check_data_count++;

                        double d_value = MPCF.ToDbl(with_1.GetValue(i, j));
                        d_total_sum_data += d_value;

                        d_sum_sample_data[i] += d_value;
                    }
                }

                if (i_total_count != i_check_data_count)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(624));
                    return false;
                }

                d_averge_value = d_total_sum_value / i_sample_count;
                d_averge_data = d_total_sum_data / (i_sample_count + i_repeat_count);                

                // sumAccuracy, 정확성(Y) : ABS(기준값 - 측정평균)
                double d_sum_xy = 0.0d;
                double d_sum_x = 0.0d;
                double d_sum_y = 0.0d;
                double d_sum_pow_2x = 0.0d;
                
                for (i = 0; i < i_sample_count; i++)
                {
                    d_average_sample_data[i] = d_sum_sample_data[i] / i_repeat_count;
                    d_sum_accuracy[i] = Math.Abs(d_sample_value[i] - d_average_sample_data[i]);
                    d_sum_xy += d_sample_value[i] * d_sum_accuracy[i];
                    d_sum_x += d_sample_value[i];
                    d_sum_y += d_sum_accuracy[i];
                    d_sum_pow_2x += Math.Pow(d_sample_value[i], 2);
                }
                
                // n이 반복 횟수 인지 샘플 수인지 확인 필요 
                // 직선의 기울기(a) = (∑𝑋𝑌− (∑𝑋 * ∑𝑌) / 𝑛) / (∑𝑋^2 −((∑𝑋)^2)/𝑛)
                double d_slope_p = d_sum_pow_2x - (Math.Pow(d_sum_x, 2) / i_sample_count);
                double d_slope = (d_slope_p == double.NaN || d_slope_p == 0 ? double.NaN : (d_sum_xy - (d_sum_x * d_sum_y) / i_sample_count) / d_slope_p);

                // %선형성   = 직선의 기울기 (a) x 100(%)
                double d_linear_probability = (d_slope == double.NaN ? double.NaN : d_slope * 100);

                char c_ana_result = 'F';
                string s_ana_desc = "Registration of measurement result(LINEARITY) - auto judgement, linearProbability:" + d_linear_probability.ToString() + "%";
                if (d_linear_probability != double.NaN && d_linear_probability <= 5)
                {
                    c_ana_result = 'P';
                }

                //별도 저장.
                double d_cmf_1 = Math.Pow(d_sum_x, 2);
                double d_cmf_2 = (Math.Pow(d_sum_x, 2) / i_sample_count);
                double d_cmf_3 = (d_sum_x * d_sum_y);
                double d_cmf_4 = d_sum_pow_2x;
                double d_cmf_5 = d_sum_xy;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ANA_ID", ANA_ID);
                in_node.AddString("ITEM_CODE", cdvItemCode.Text);
                in_node.AddString("ANA_DATE", this.dtpMeasurementDate.Value.ToString("yyyyMMdd"));

                // 측정값 전체 합
                in_node.AddDouble("SUM", d_total_sum_data);
                // 전체 측정값의 평균
                in_node.AddDouble("AVERAGE", (d_total_sum_data / i_total_count));

                in_node.AddDouble("ANA_VALUE", d_linear_probability);

                in_node.AddChar("ANA_RESULT", c_ana_result);
                in_node.AddString("ANA_DESC", s_ana_desc);

                in_node.AddString("CMF_1", Math.Round(d_cmf_1, 3));
                in_node.AddString("CMF_2", Math.Round(d_cmf_2, 3));
                in_node.AddString("CMF_3", Math.Round(d_cmf_3, 3));
                in_node.AddString("CMF_4", Math.Round(d_cmf_4, 3));
                in_node.AddString("CMF_5", Math.Round(d_cmf_5, 3));

                if (SetItemValues(in_node) == false)
                    return false;

                if (MPCR.CallService("CMMS", "CMMS_Update_Measuring_Result_Registration", in_node, ref out_node) == false)
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
        // SetItemValues()
        //       - SetItemValues
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SetItemValues(TRSNode in_node)
        {
            TRSNode list_item;
            int i, j;
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = this.spdMeasuringResultList.ActiveSheet;
                if (with_1.RowCount == 0) return true;

                //Item 목록 저장 
                if (ANA_ID == "1" && rdoCharType.Checked == true) // ANA_ID = 'Attributes' & Char Type 이면 
                {
                    for (j = BASE_VALUE_COUNT; j < with_1.ColumnCount; j++)
                    {
                        for (i = 0; i < with_1.RowCount; i++)
                        {
                            list_item = in_node.AddNode("MEASURING_DATA_LIST");
                            list_item.AddInt("USER_SEQ", MPCF.ToInt(with_1.ColumnHeader.Cells.Get(0, j).Tag));
                            list_item.AddInt("REPEAT_SEQ", MPCF.ToInt(with_1.ColumnHeader.Cells.Get(1, j).Tag));
                            list_item.AddInt("SAMPLE_SEQ", (i + 1));
                            list_item.AddDouble("VALUE",  (MPCF.Trim(with_1.GetValue(i, j).ToString()) == "OK" ? 1 : 0));
                            list_item.AddString("CHAR_VALUE", MPCF.Trim(with_1.GetValue(i, j)));
                        }
                    }
                }
                else
                {
                    for (j = BASE_VALUE_COUNT; j < with_1.ColumnCount; j++)
                    {
                        for (i = 0; i < with_1.RowCount; i++)
                        {
                            list_item = in_node.AddNode("MEASURING_DATA_LIST");
                            list_item.AddInt("USER_SEQ", MPCF.ToInt(with_1.ColumnHeader.Cells.Get(0, j).Tag));
                            list_item.AddInt("REPEAT_SEQ", MPCF.ToInt(with_1.ColumnHeader.Cells.Get(1, j).Tag));
                            list_item.AddInt("SAMPLE_SEQ", (i + 1));
                            list_item.AddDouble("VALUE", MPCF.ToDbl(with_1.GetValue(i, j)));
                            list_item.AddString("CHAR_VALUE", MPCF.Trim(with_1.GetValue(i, j)));
                        }
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

        private void frmMMSMeasuringResultPopup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');
                
                
                ViewAnalysisPlanData();

                // TODO
                b_load_flag = true;
            }
        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("TRAN1") == false) return;

                if (ANA_DIV == '0')
                {
                    if (SaveVariables() == false) return;
                }
                else if (ANA_DIV == '1')
                {
                    if (SaveAttributes() == false) return;
                }
                else if (ANA_DIV == '2')
                {
                    if (SaveBias() == false) return;
                }
                else if (ANA_DIV == '3')
                {
                    if (SaveLinearity() == false) return;
                }
                else
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(619)); //There is an error in the analysis method.
                    return;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDownloadExcel_Click(object sender, EventArgs e)
        {            
            //int i_last_row = spdMeasuringResultList.ActiveSheet.RowCount - 1;
            //int i_last_col = spdMeasuringResultList.ActiveSheet.ColumnCount - 1;
            //FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
            //FarPoint.Win.ComplexBorder complexBorderNone = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            //FarPoint.Excel.ExcelWarningList wList = new FarPoint.Excel.ExcelWarningList();
            try
            {
                HQCE.ExportSpreadSheetToExcel(spdMeasuringResultList.ActiveSheet, "", "", false, true, false);

                //string s_file_name = "";
                //System.Windows.Forms.SaveFileDialog sfdExcel = new SaveFileDialog();
                //sfdExcel.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                //if (sfdExcel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    spdMeasuringResultList.ActiveSheet.ColumnHeader.Cells[0, 0, 1, i_last_col].Border = complexBorder1;
                //    spdMeasuringResultList.ActiveSheet.Cells[0, 0, i_last_row, i_last_col].Border = complexBorder1;
                //    spdMeasuringResultList.ActiveSheet.ColumnHeader.Cells[0, 0, 1, i_last_col].BackColor = Color.Silver;

                //    s_file_name = sfdExcel.FileName;
                //    spdMeasuringResultList.SaveExcel(s_file_name, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly, wList);

                //    spdMeasuringResultList.ActiveSheet.ColumnHeader.Cells[0, 0, 1, i_last_col].Border = complexBorderNone;
                //    spdMeasuringResultList.ActiveSheet.Cells[0, 0, i_last_row, i_last_col].Border = complexBorderNone;
                //    spdMeasuringResultList.ActiveSheet.ColumnHeader.Cells[0, 0, 1, i_last_col].BackColor = Color.Empty;

                //    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                //    proc.StartInfo.FileName = s_file_name;
                //    proc.Start();
                //}
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void rdoNumberType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoNumberType.Checked == false)
                {
                    SetSpdItemCelltype('C');
                }
                else
                {
                    SetSpdItemCelltype('N');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnUploadExcel_Click(object sender, EventArgs e)
        {            
            try
            {
                System.Windows.Forms.OpenFileDialog ofdExcel = new OpenFileDialog();
                ofdExcel.Filter = "Excel files (*.xlsx;*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";
                if (ofdExcel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int i_header_row_count = spdMeasuringResultList.ActiveSheet.ColumnHeader.RowCount;
                    HQCE.ExcelToSpreadSheet(spdMeasuringResultList.ActiveSheet, ofdExcel.FileName, i_header_row_count, BASE_VALUE_COUNT);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
}
