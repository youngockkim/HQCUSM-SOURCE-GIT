//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSVariablesAnalysisPopup.cs
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

namespace Custom.HanwhaQcell.USModule
{
    public partial class frmMMSVariablesAnalysisPopup : TranForm01
    {
        public frmMMSVariablesAnalysisPopup()
        {
            InitializeComponent();

            btnProcess.Location = new Point(798, 7);
            btnClose.Location = new Point(894, 7);
        }


        #region " Constant Definition "
        private string m_ana_id;
        private string m_equip_id;
        private string m_item_code;

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
            return this.groupBox1;
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
            //if (MPCF.CheckValue(txtKeyField, 1) == false)
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
        // CMMSUpdateMeasuringResultRegistration()
        //       - Update Measuring_Result_Registration
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool UpdateMeasuringResultRegistration()
        {
            TRSNode in_node = new TRSNode("CMMS_UPDATE_MEASURING_RESULT_REGISTRATION_IN");
            TRSNode out_node = new TRSNode("CMMS_UPDATE_MEASURING_RESULT_REGISTRATION_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';

                in_node.AddString("ANA_ID", ANA_ID);
                in_node.AddString("EQUIP_ID", EQUIP_ID);
                in_node.AddString("ITEM_CODE", ITEM_CODE);
                in_node.AddChar("ANA_RESULT", (rdoOK.Checked == true ? 'P' : 'F'));
                in_node.AddString("ANA_DESC", txtAnaDesc.Text);
                in_node.AddString("ANA_STATUS", "2");
                
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
        // CMMSViewMeasuringResultRegistration()
        //       - View Measuring_Result_Registration
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewMeasuringResultRegistration()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_MEASURING_RESULT_REGISTRATION_IN");
            TRSNode out_node = new TRSNode("CMMS_VIEW_MEASURING_RESULT_REGISTRATION_OUT");
            rdoNG.Checked = true;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("ANA_ID", ANA_ID);
                in_node.AddString("EQUIP_ID", EQUIP_ID);
                in_node.AddString("ITEM_CODE", ITEM_CODE);

                if (MPCR.CallService("CMMS", "CMMS_View_Measuring_Result_Registration", in_node, ref out_node) == false)
                {
                    return false;
                }

                FarPoint.Win.Spread.SheetView with_1 = spdReport.ActiveSheet;

                
                FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
                FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
                numberCellType1.DecimalPlaces = out_node.GetInt("DECIMAL_PLACE");
                numberCellType2.DecimalPlaces = 4;

                with_1.SetValue(4, 11, out_node.GetInt("REPEAT_COUNT").ToString());                
                with_1.SetValue(5, 11, out_node.GetInt("USER_COUNT"));
                with_1.SetValue(6, 11, out_node.GetInt("SAMPLE_COUNT"));
                with_1.Cells[4, 11, 6, 11].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

                with_1.SetValue(5, 14, out_node.GetDouble("USL"));
                with_1.SetValue(6, 14, out_node.GetDouble("LSL"));
                with_1.Cells[5, 14, 6, 14].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                with_1.Cells[5, 14, 6, 14].CellType = numberCellType1;

                with_1.SetValue(4, 4, out_node.GetString("EQUIP_ID"));
                with_1.SetValue(4, 6, out_node.GetString("EQUIP_NAME"));
                with_1.SetValue(5, 4, out_node.GetString("ITEM_CODE"));
                with_1.SetValue(5, 6, out_node.GetString("ITEM_NAME"));
                with_1.SetValue(6, 4, MPCF.MakeDateFormat(out_node.GetString("ANA_DATE"), DATE_TIME_FORMAT.DATE));

                if (out_node.GetChar("ANA_RESULT") == 'P')
                {
                    rdoOK.Checked = true;
                }
                txtAnaDesc.Text = out_node.GetString("ANA_DESC");



                List<TRSNode> analysis_rater_list = out_node.GetList("ANALYSIS_RATER_LIST");
                foreach (TRSNode node in analysis_rater_list)
                {
                    if (node.GetInt("USER_SEQ") == 1)
                    {
                        with_1.SetValue(8, 3, node.GetString("USER_NAME"));
                    }
                    else if (node.GetInt("USER_SEQ") == 2)
                    {
                        with_1.SetValue(8, 7, node.GetString("USER_NAME"));
                    }
                    else if (node.GetInt("USER_SEQ") == 3)
                    {
                        with_1.SetValue(8, 11, node.GetString("USER_NAME"));
                    }
                }
                
                //기 입력된 Data 바인딩
                int i,j,k;
                int iBaseCol = -2;
                int iBaseRow = 9;
                int iRow, iCol;
                string sRow;
                string sCol;

                List<TRSNode> analysis_result_value_list = out_node.GetList("ANALYSIS_RESULT_VALUE_LIST");
                foreach (TRSNode node in analysis_result_value_list)
                {
                    i = node.GetInt("USER_SEQ");
                    j = node.GetInt("REPEAT_SEQ");
                    k = node.GetInt("SAMPLE_SEQ");

                    iRow = iBaseRow + k;
                    iCol = iBaseCol + ((i * 4) + j);
                    with_1.SetValue(iRow, iCol, node.GetDouble("VALUE"));                    
                }

                for (i = 10; i < 20; i++)
                {
                    sRow = (i+1).ToString();
                    if (with_1.GetValue(i, 3) != null)
                    {
                        with_1.Cells[i, 6].Formula = "MAX(D" + sRow + ":F" + sRow + ")-MIN(D" + sRow + ":F" + sRow + ")";
                    }

                    if (with_1.GetValue(i, 7) != null)
                    {
                        with_1.Cells[i, 10].Formula = "MAX(H" + sRow + ":J" + sRow + ")-MIN(H" + sRow + ":J" + sRow + ")";
                    }

                    if (with_1.GetValue(i, 11) != null)
                    {
                        with_1.Cells[i, 14].Formula = "MAX(L" + sRow + ":N" + sRow + ")-MIN(L" + sRow + ":N" + sRow + ")";
                    }
                }

                with_1.Cells[10, 3, 20, 14].CellType = numberCellType1;

                for (i = 3; i < 15; i++)
                {
                    sCol = Convert.ToChar(65 + i).ToString();
                    if (with_1.GetValue(10, i) != null)
                    {
                        with_1.Cells[20, i].Formula = "SUM(" + sCol + "11:" + sCol + "20)";

                        switch (i)
                        {
                            case 4:
                                with_1.Cells[21, i].Formula = "SUM(D11:F20)";
                                with_1.Cells[22, i].Formula = "AVERAGE(D11:F20)";
                                with_1.Cells[21, i].CellType = numberCellType1;
                                with_1.Cells[22, i].CellType = numberCellType2;
                                break;
                            case 8:
                                if (with_1.GetValue(10, 7) != null)
                                {
                                    with_1.Cells[21, i].Formula = "SUM(H11:J20)";
                                    with_1.Cells[22, i].Formula = "AVERAGE(H11:J20)";
                                    with_1.Cells[21, i].CellType = numberCellType1;
                                    with_1.Cells[22, i].CellType = numberCellType2;
                                }
                                break;
                            case 12:
                                if (with_1.GetValue(10, 11) != null)
                                {
                                    with_1.Cells[21, i].Formula = "SUM(L11:N20)";
                                    with_1.Cells[22, i].Formula = "AVERAGE(L11:N20)";
                                    with_1.Cells[21, i].CellType = numberCellType1;
                                    with_1.Cells[22, i].CellType = numberCellType2;
                                }
                                break;

                            case 6:
                                with_1.Cells[21, i].Formula = "AVERAGE(G11:G20)";
                                with_1.Cells[21, i].CellType = numberCellType2;
                                break;

                            case 10:
                                if (with_1.GetValue(10, 7) != null)
                                {
                                    with_1.Cells[21, i].Formula = "AVERAGE(K11:K20)";
                                    with_1.Cells[21, i].CellType = numberCellType2;
                                }
                                break;
                            case 14:
                                if (with_1.GetValue(10, 7) != null)
                                {
                                    with_1.Cells[21, i].Formula = "AVERAGE(O11:O20)";
                                    with_1.Cells[21, i].CellType = numberCellType2;
                                }
                                break;
                        }
                    }
                }

                with_1.SetValue(24, 3, with_1.GetValue(21, 6));
                with_1.SetValue(25, 3, with_1.GetValue(21, 10));
                with_1.SetValue(26, 3, with_1.GetValue(21, 14));
                with_1.Cells[27, 3].Formula = "SUM(D25:D27)";
                with_1.Cells[28, 3].Formula = "AVERAGE(D25:D27)";
                with_1.Cells[24, 3, 28, 3].CellType = numberCellType2;

                with_1.Cells[24, 14].Formula = "MAX(E23,I23,M23)";
                with_1.Cells[25, 14].Formula = "MIN(E23,I23,M23)";
                with_1.Cells[26, 14].Formula = "O25-O26";
                with_1.Cells[24, 14, 26, 14].CellType = numberCellType2;

                with_1.SetValue(28, 14, out_node.GetDouble("RP"));
                with_1.Cells[28, 14].CellType = numberCellType2;

                

                double d_d4 = 1.000;
                List<TRSNode> base_const_value_list = out_node.GetList("MMS_CONST_VALUE_LIST");
                foreach (TRSNode node in base_const_value_list)
                {
                    if (node.GetString("KEY_1") == "D4")
                    {
                        if (MPCF.ToInt(node.GetString("KEY_2")) > 1 && MPCF.ToInt(node.GetString("KEY_2")) < 4)
                        {
                            iRow = 23 + MPCF.ToInt(node.GetString("KEY_2"));
                            with_1.SetValue(iRow, 6, node.GetString("DATA_1"));
                        }

                        if (out_node.GetInt("REPEAT_COUNT") == MPCF.ToInt(node.GetString("KEY_2")))
                        {
                            d_d4 = MPCF.ToDbl(node.GetString("DATA_1"));
                        }
                    }
                    else if (node.GetString("KEY_1") == "K1")
                    {
                        if (MPCF.ToInt(node.GetString("KEY_2")) > 1 && MPCF.ToInt(node.GetString("KEY_2")) < 4)
                        {
                            iRow = 34 + MPCF.ToInt(node.GetString("KEY_2"));
                            with_1.SetValue(iRow, 6, node.GetString("DATA_1"));
                        }
                    }
                    else if (node.GetString("KEY_1") == "K2")
                    {
                        if (MPCF.ToInt(node.GetString("KEY_2")) > 1 && MPCF.ToInt(node.GetString("KEY_2")) < 4)
                        {
                            iRow = 40 + MPCF.ToInt(node.GetString("KEY_2"));
                            with_1.SetValue(iRow, 6, node.GetString("DATA_1"));
                        }
                    }
                    else if (node.GetString("KEY_1") == "K3")
                    {
                        if (MPCF.ToInt(node.GetString("KEY_2")) > 1 && MPCF.ToInt(node.GetString("KEY_2")) < 11)
                        {
                            iRow = 48 + MPCF.ToInt(node.GetString("KEY_2"));
                            with_1.SetValue(iRow, 6, node.GetString("DATA_1"));
                        }
                    }
                }

                with_1.SetValue(27, 8, Math.Round(MPCF.ToDbl(with_1.GetValue(28, 3)), 3).ToString() + " x " + d_d4.ToString() + " =");
                with_1.SetValue(27, 10, MPCF.ToDbl(with_1.GetValue(28, 3)) * d_d4);
                with_1.Cells[27, 10].CellType = numberCellType2;

                //EV
                with_1.SetValue(36, 3, out_node.GetDouble("EV"));
                with_1.SetValue(41, 3, out_node.GetDouble("AV"));
                with_1.SetValue(47, 3, out_node.GetDouble("RR"));
                with_1.SetValue(52, 3, out_node.GetDouble("PV"));
                with_1.SetValue(57, 3, out_node.GetDouble("TV"));
                with_1.SetValue(49, 10, out_node.GetDouble("CP"));

                with_1.SetValue(36, 9, 100 * (out_node.GetDouble("EV") / out_node.GetDouble("TV")));
                with_1.SetValue(41, 9, 100 * (out_node.GetDouble("AV") / out_node.GetDouble("TV")));
                with_1.SetValue(47, 9, 100 * (out_node.GetDouble("RR") / out_node.GetDouble("TV")));
                with_1.SetValue(58, 9, out_node.GetString("CMF_1"));

                with_1.Cells[36, 3].CellType = numberCellType2;
                with_1.Cells[41, 3].CellType = numberCellType2;
                with_1.Cells[47, 3].CellType = numberCellType2;
                with_1.Cells[52, 3].CellType = numberCellType2;
                with_1.Cells[57, 3].CellType = numberCellType2;
                with_1.Cells[49, 10].CellType = numberCellType2;
                with_1.Cells[36, 9].CellType = numberCellType2;
                with_1.Cells[41, 9].CellType = numberCellType2;
                with_1.Cells[47, 9].CellType = numberCellType2;
                //with_1.Cells[58, 9].CellType = numberCellType2;

                double d_tol = out_node.GetDouble("TOL");
                if (d_tol != 0)
                {
                    with_1.SetValue(31, 14, d_tol);
                    with_1.SetValue(36, 13, 100 * (out_node.GetDouble("EV") / d_tol));
                    with_1.SetValue(41, 13, 100 * (out_node.GetDouble("AV") / d_tol));
                    with_1.SetValue(47, 13, 100 * (out_node.GetDouble("RR") / d_tol));
                    with_1.Cells[36, 13].CellType = numberCellType2;
                    with_1.Cells[41, 13].CellType = numberCellType2;
                    with_1.Cells[47, 13].CellType = numberCellType2;
                    with_1.Cells[31, 14].CellType = numberCellType2;

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

        private void frmMMSVariablesAnalysisPopup_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData('1');

                ViewMeasuringResultRegistration();
                // TODO
                b_load_flag = true;
            }
        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("TRAN1") == false) return;

                if (UpdateMeasuringResultRegistration() == false) return;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string s_file_name = "";
                sfdExcel = new SaveFileDialog();
                sfdExcel.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                if (sfdExcel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    s_file_name = sfdExcel.FileName;
                    spdReport.SaveExcel(s_file_name);

                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = s_file_name;
                    proc.Start();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }






    }
}
