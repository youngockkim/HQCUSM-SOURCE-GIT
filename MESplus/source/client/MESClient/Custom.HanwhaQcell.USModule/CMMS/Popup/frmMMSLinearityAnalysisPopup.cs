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
    public partial class frmMMSLinearityAnalysisPopup : TranForm01
    {
        public frmMMSLinearityAnalysisPopup()
        {
            InitializeComponent();
            btnProcess.Location = new Point(716, 7);
            btnClose.Location = new Point(810, 7);
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

                if (out_node.GetChar("ANA_RESULT") == 'P')
                {
                    rdoOK.Checked = true;
                }
                txtAnaDesc.Text = out_node.GetString("ANA_DESC");

                FarPoint.Win.Spread.SheetView with_1 = spdReport.ActiveSheet;


                FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
                FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
                FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
                numberCellType1.DecimalPlaces = out_node.GetInt("DECIMAL_PLACE");
                numberCellType2.DecimalPlaces = 2;
                numberCellType4.DecimalPlaces = 4;

                int i_sample_count = out_node.GetInt("SAMPLE_COUNT");
                int i_repeat_count = out_node.GetInt("REPEAT_COUNT");
                with_1.SetValue(5, 15, i_sample_count);
                with_1.SetValue(6, 15, i_repeat_count);
                with_1.SetValue(26, 11, i_sample_count);
                with_1.SetValue(28, 11, i_sample_count);
                //with_1.Cells[4, 11, 6, 11].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

                with_1.SetValue(4, 4, out_node.GetString("EQUIP_ID"));
                with_1.SetValue(4, 6, out_node.GetString("EQUIP_NAME"));
                with_1.SetValue(5, 4, out_node.GetString("ITEM_CODE"));
                with_1.SetValue(5, 6, out_node.GetString("ITEM_NAME"));
                with_1.SetValue(6, 4, MPCF.MakeDateFormat(out_node.GetString("ANA_DATE"), DATE_TIME_FORMAT.DATE));

                with_1.SetValue(32, 11, out_node.GetDouble("ANA_VALUE"));

                List<TRSNode> base_value_list = out_node.GetList("ANALYSIS_BASE_VALUE_LIST");
                int iBaseCol = 4;
                int iCol;
                foreach (TRSNode node in base_value_list)
                {
                    iCol = iBaseCol + (node.GetInt("VAL_SEQ") * 2);
                    with_1.SetValue(9, iCol, node.GetDouble("VALUE"));
                }

                //입력된 Data 바인딩
                int i, j, k;
                iBaseCol = 4;
                int iBaseRow = 9;
                int iRow;                
                string sCol;

                List<TRSNode> analysis_result_value_list = out_node.GetList("ANALYSIS_RESULT_VALUE_LIST");
                foreach (TRSNode node in analysis_result_value_list)
                {
                    i = node.GetInt("USER_SEQ");
                    j = node.GetInt("REPEAT_SEQ");
                    k = node.GetInt("SAMPLE_SEQ");

                    iRow = iBaseRow + j;
                    iCol = iBaseCol + (2 * k);
                    with_1.SetValue(iRow, iCol, node.GetDouble("VALUE"));
                }
                with_1.Cells[10, 6, 19, 14].CellType = numberCellType1;

                string sStartCol = "";
                string sEndCol = "";
                for (i = 6; i < 16; i += 2)
                {
                    sCol = i.ToString();                    
                    if (with_1.GetValue(10, i) != null)
                    {
                        // D = 68 
                        sStartCol = Convert.ToChar(65 + i).ToString();
                        sEndCol = Convert.ToChar(62 + (i + 1)).ToString();
                        with_1.Cells[20, i].Formula = "AVERAGE(" + sStartCol + "11:" + sStartCol + "20)";
                        with_1.Cells[21, i].Formula = "ABS(" + sStartCol + "10-" + sStartCol + "21)";
                        with_1.Cells[22, i].Formula = "MAX(" + sStartCol + "11:" + sStartCol + "20) - MIN(" + sStartCol + "11:" + sStartCol + "20)";
                        with_1.Cells[20, i, 22, i].CellType = numberCellType2;
                    }
                }

                with_1.Cells[25, 11].Formula = "(SUM(G10:P10))*SUM(G22:P22)";
                with_1.Cells[26, 10].Formula = "SUM(G10*G22,I10*I22,K10*K22,M10*M22,O10*O22)";
                with_1.Cells[27, 10].Formula = "SUM(G10^2,I10^2,K10^2,M10^2,O10^2)";
                with_1.Cells[27, 11].Formula = "SUM(G10:P10)^2";
                with_1.Cells[26, 13].Formula = "(SUM(G10*G22,I10*I22,K10*K22,M10*M22,O10*O22) - ((SUM(G10:P10))*SUM(G22:P22) / P6)) / (SUM(G10^2,I10^2,K10^2,M10^2,O10^2) - (SUM(G10:P10)^2/ P6))";

                with_1.Cells[25, 11].CellType = numberCellType2;
                with_1.Cells[26, 10].CellType = numberCellType2;
                with_1.Cells[27, 10].CellType = numberCellType2;
                with_1.Cells[27, 11].CellType = numberCellType2;                
                with_1.Cells[26, 13].CellType = numberCellType4;
                with_1.Cells[32, 11].CellType = numberCellType2;

                

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #endregion

        private void frmMMSLinearityAnalysisPopup_Activated(object sender, System.EventArgs e)
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
