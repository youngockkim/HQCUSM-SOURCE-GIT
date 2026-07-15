//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSBiasAnalysisPopup.cs
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
    public partial class frmMMSBiasAnalysisPopup : TranForm01
    {
        public frmMMSBiasAnalysisPopup()
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
                FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
                numberCellType1.DecimalPlaces = out_node.GetInt("DECIMAL_PLACE");
                numberCellType2.DecimalPlaces = 2;
                numberCellType4.DecimalPlaces = 4;
                numberCellType6.DecimalPlaces = 6;

                int i_sample_count = out_node.GetInt("SAMPLE_COUNT");
                //with_1.SetValue(4, 3, out_node.GetString("EQUIP_ID"));
                with_1.SetValue(4, 3, out_node.GetString("EQUIP_NAME"));
                //with_1.SetValue(5, 4, out_node.GetString("ITEM_CODE"));
                with_1.SetValue(4, 8, out_node.GetString("ITEM_NAME"));
                with_1.SetValue(4, 10, MPCF.MakeDateFormat(out_node.GetString("ANA_DATE"), DATE_TIME_FORMAT.DATE));
                
                with_1.SetValue(26, 3, i_sample_count);
                with_1.SetValue(27, 3, i_sample_count - 1);

                with_1.SetValue(26, 7, out_node.GetDouble("USL"));
                with_1.SetValue(27, 7, out_node.GetDouble("LSL"));


                with_1.SetValue(26, 10, 0.05); //a
                with_1.SetValue(27, 10, 2.145);//tv

                //with_1.SetValue(32, 11, out_node.GetDouble("ANA_VALUE"));

                List<TRSNode> base_value_list = out_node.GetList("ANALYSIS_BASE_VALUE_LIST");
                int iBaseRow = 7;
                int iRow;
                int iBaseCol = 3;
                foreach (TRSNode node in base_value_list)
                {
                    iRow = iBaseRow + node.GetInt("VAL_SEQ");
                    with_1.SetValue(iRow, iBaseCol, node.GetDouble("VALUE"));
                }
                with_1.Cells[8, iBaseCol, 22, iBaseCol].CellType = numberCellType1;

                ////입력된 Data 바인딩
                int i, k;
                string sRow;
                iBaseCol = 7;
                List<TRSNode> analysis_result_value_list = out_node.GetList("ANALYSIS_RESULT_VALUE_LIST");
                foreach (TRSNode node in analysis_result_value_list)
                {
                    k = node.GetInt("SAMPLE_SEQ"); 
                    iRow = iBaseRow + k;
                    with_1.SetValue(iRow, iBaseCol, node.GetDouble("VALUE"));
                }
                with_1.Cells[8, iBaseCol, 22, iBaseCol].CellType = numberCellType1;

                //Average
                with_1.Cells[23, 3].Formula = "AVERAGE(D9:D23)";
                with_1.Cells[23, 7].Formula = "AVERAGE(H9:H23)";
                with_1.Cells[23, 8].Formula = "AVERAGE(I9:I23)";
                with_1.Cells[23, 10].Formula = "SUM(K9:K23)";

                with_1.Cells[23, 3].CellType = numberCellType4;
                with_1.Cells[23, 7].CellType = numberCellType4;
                with_1.Cells[23, 8].CellType = numberCellType4;
                with_1.Cells[23, 10].CellType = numberCellType4;

                iBaseCol = 8;
                iBaseRow = 8;
                for (i = 0; i < i_sample_count; i++)
                {                    
                    iRow = iBaseRow + i;
                    sRow = (iRow + 1).ToString();
                    with_1.Cells[iRow, iBaseCol].Formula = "(H" + sRow +"-D" + sRow +")";
                    with_1.Cells[iRow, iBaseCol + 1].Formula = "H" + sRow + "-H24";
                    with_1.Cells[iRow, iBaseCol + 2].Formula = "J" + sRow + "^2";
                }
                with_1.Cells[8, 8, 22, 10].CellType = numberCellType4;
                
                List<TRSNode> base_const_value_list = out_node.GetList("MMS_CONST_VALUE_LIST");
                foreach (TRSNode node in base_const_value_list)
                {
                    if (node.GetString("KEY_1") == "A")
                    {
                        with_1.SetValue(26, 10, MPCF.ToDbl(node.GetString("DATA_1")));
                    }
                    else if (node.GetString("KEY_1") == "TV")
                    {
                        with_1.SetValue(27, 10, MPCF.ToDbl(node.GetString("DATA_1")));
                    }                    
                }
                
                with_1.Cells[29, 9].Formula = "(H27-H28)/6";
                with_1.Cells[30, 9].Formula = "SQRT(D27)";
                with_1.Cells[30, 3].Formula = "SQRT(K24/D28)";

                with_1.Cells[29, 9].CellType = numberCellType6;
                with_1.Cells[30, 9].CellType = numberCellType6;
                with_1.Cells[30, 3].CellType = numberCellType6;

                with_1.Cells[33, 3].Formula = "D31/J31";
                with_1.Cells[33, 8].Formula = "(D31/J30)*100";
                //with_1.Cells[33, 9].Formula = "IF(I34<10,'Acceptable',IF(I34>30,'Un Acceptable','Partially Acceptable'))";

                with_1.Cells[37, 9].Formula = "I24/D34";
                with_1.Cells[45, 3].Formula = "D34*K28";
                with_1.Cells[45, 9].Formula = "I24-D46";
                with_1.Cells[46, 9].Formula = "I24+D46";

                with_1.Cells[29, 9].CellType = numberCellType6;
                with_1.Cells[30, 9].CellType = numberCellType6;
                with_1.Cells[30, 3].CellType = numberCellType6;                
                with_1.Cells[29, 9].CellType = numberCellType6;
                with_1.Cells[30, 9].CellType = numberCellType6;
                with_1.Cells[30, 3].CellType = numberCellType6;                
                with_1.Cells[33, 3].CellType = numberCellType6;
                with_1.Cells[33, 8].CellType = numberCellType6;
                with_1.Cells[37, 9].CellType = numberCellType6;
                with_1.Cells[45, 3].CellType = numberCellType6;
                with_1.Cells[45, 9].CellType = numberCellType6;
                with_1.Cells[46, 9].CellType = numberCellType6;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #endregion

        private void frmMMSBiasAnalysisPopup_Activated(object sender, System.EventArgs e)
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
