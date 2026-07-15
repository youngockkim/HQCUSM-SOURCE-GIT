//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSAttributesAnalysisPopup.cs
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
    public partial class frmMMSAttributesAnalysisPopup : TranForm01
    {
        public frmMMSAttributesAnalysisPopup()
        {
            InitializeComponent();
            btnProcess.Location = new Point(1170, 7);
            btnClose.Location = new Point(1270, 7);

            setInitSheetText();
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

        private void setInitSheetText()
        {
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdReport.ActiveSheet;
                //Cells Text Setup
                with_1.SetValue(7, 2, "Measuring person" + Environment.NewLine + "(inspector)");
                with_1.SetValue(7, 4, "Good" + Environment.NewLine + "Correct");
                with_1.SetValue(7, 5, "Bad" + Environment.NewLine + "Correct");
                with_1.SetValue(7, 6, "Number" + Environment.NewLine + "Correct");
                with_1.SetValue(7, 7, "Number" + Environment.NewLine + "False");
                with_1.SetValue(7, 8, "Number" + Environment.NewLine + "Miss");
                with_1.SetValue(7, 9, "Number" + Environment.NewLine + "Total");
                with_1.SetValue(7, 10, "Effectiveness" + Environment.NewLine + "(E)");
                with_1.SetValue(7, 11, "FR");
                with_1.SetValue(7, 12, "FA");
                with_1.SetValue(7, 13, "Measuring person");
                with_1.SetValue(7, 14, "Effectiveness" + Environment.NewLine + "(E)");
                with_1.SetValue(7, 15, "FR");
                with_1.SetValue(7, 16, "FA");
                with_1.SetValue(7, 17, "Corrective Action");
                with_1.SetValue(7, 18, "Criteria");
                with_1.SetValue(7, 19, "Effectiveness" + Environment.NewLine + "(E)");
                with_1.SetValue(7, 20, "FR");
                with_1.SetValue(7, 21, "FA");

                with_1.SetValue(12, 14, "≥ 90%");
                with_1.SetValue(12, 15, "≤ 5%");
                with_1.SetValue(12, 16, "≤ 0%");

                with_1.SetValue(8, 19, "≥ 90%");
                with_1.SetValue(8, 20, "≤ 5%");
                with_1.SetValue(8, 21, "≤ 0%");

                with_1.SetValue(9, 19, "≥ 80%");
                with_1.SetValue(9, 20, "≤ 10%");
                with_1.SetValue(9, 21, "≤ 5%");

                with_1.SetValue(10, 19, "< 80%");
                with_1.SetValue(10, 20, "> 10%");
                with_1.SetValue(10, 21, "> 5%");

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
                in_node.ProcStep = '2'; //Attributes는 Step을 '2'로 조회

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
                FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
                FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
                numberCellType1.DecimalPlaces = out_node.GetInt("DECIMAL_PLACE");
                numberCellType2.DecimalPlaces = 2;
                numberCellType3.DecimalPlaces = 3;
                numberCellType4.DecimalPlaces = 4;

                List<TRSNode> attributes_value_list = out_node.GetList("MMS_ATTRIBUTES_VALUE_LIST");
                int iRow;
                string sRow = "";
                foreach (TRSNode node in attributes_value_list)
                {
                    iRow = node.GetInt("USER_SEQ") + 7;
                    sRow = (iRow + 1).ToString();
                    with_1.SetValue(iRow, 3, node.GetString("USER_NAME"));
                    with_1.SetValue(iRow, 13, node.GetString("USER_NAME"));
                    with_1.SetValue(iRow, 4, node.GetInt("GOOD_CORRECT"));
                    with_1.SetValue(iRow, 5, node.GetInt("BAD_CORRECT"));
                    with_1.Cells[iRow, 6].Formula = "SUM(E" + sRow + ":F" + sRow + ")";
                    with_1.SetValue(iRow, 7, node.GetInt("NUMBER_FLASE"));
                    with_1.SetValue(iRow, 8, node.GetInt("NUMBER_MISS"));
                    with_1.Cells[iRow, 9].Formula = "SUM(H" + sRow + ":I" + sRow + ")";
                }

                with_1.Cells[12, 4].Formula = "SUM(E9:E11)";
                with_1.Cells[12, 5].Formula = "SUM(F9:F11)";
                with_1.Cells[12, 6].Formula = "SUM(G9:G11)";
                with_1.Cells[12, 7].Formula = "SUM(H9:H11)";
                with_1.Cells[12, 8].Formula = "SUM(I9:I11)";
                with_1.Cells[12, 9].Formula = "SUM(J9:J11)";
                with_1.Cells[12, 10].Formula = "IF(J13=0,0,G13/J13)";
                with_1.Cells[12, 11].Formula = "H13/(H13+E13)";
                with_1.Cells[12, 12].Formula = "I13/(I13+G13)";

                with_1.Cells[8, 10].Formula = "IF(J9=0,0,G9/J9)";
                with_1.Cells[8, 11].Formula = "H9/(H9+E9)";
                with_1.Cells[8, 12].Formula = "I9/(I9+G9)";

                with_1.Cells[9, 10].Formula = "IF(J10=0,0,G10/J10)";
                with_1.Cells[9, 11].Formula = "H10/(H10+E10)";
                with_1.Cells[9, 12].Formula = "I10/(I10+G10)";

                with_1.Cells[10, 10].Formula = "IF(J11=0,0,G11/J11)";
                with_1.Cells[10, 11].Formula = "H11/(H11+E11)";
                with_1.Cells[10, 12].Formula = "I11/(I11+G11)";

                with_1.Cells[8, 10, 12, 12].CellType = numberCellType4;


             //   with_1.Cells[12, 11].Formula = "IF(K8>=0.9,"Acceptable", IF(K8>=0.8,"Marginal","Unacceptable"))";


                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #endregion

        private void frmMMSAttributesAnalysisPopup_Activated(object sender, System.EventArgs e)
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
