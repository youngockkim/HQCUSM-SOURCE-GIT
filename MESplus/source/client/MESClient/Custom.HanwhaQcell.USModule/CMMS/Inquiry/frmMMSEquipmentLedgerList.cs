//-----------------------------------------------------------------------------
//
//   System      : MESClient
//   File Name   : frmMMSEquipmentLedgerList.cs
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
    public partial class frmMMSEquipmentLedgerList : BaseForm04
    {
        public frmMMSEquipmentLedgerList()
        {
            InitializeComponent();
            InitializeYearData();
        }


        #region " Constant Definition "
        private enum LIST : int
        {
            EQUIP_ID = 0,
            EQUIP_NAME,
            INST_PLACE,
            CLASS_IDEN,
            MSA_FLAG,
            SPC_FLAG,
            CALI_FLAG,
            CHECK_FLAG,
            NONE_FLAG,
            STANDARD_FLAG,
            CALI_CYCLE,
            CALI_DIV,
            RST_CALI_DATE,
            RST_CALI_RESULT,
            PLN_CLAI_DATE,
            PLN_EXEC_DATE,
            PLN_EXEC_RESULT,
            MSA_CYCLE,
            RST_VARI_DATE,
            RST_VARI_VALUE,
            RST_LINE_DATE,
            RST_LINE_VALUE,
            RST_BIAS_DATE,
            RST_BIAS_VALUE,
            PLN_VARI_PLAN,
            PLN_VARI_DATE,
            PLN_VARI_VALUE,
            PLN_LINE_PLAN,
            PLN_LINE_DATE,
            PLN_LINE_VALUE,
            PLN_BIAS_PLAN,
            PLN_BIAS_DATE,
            PLN_BIAS_VALUE
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
            return this.cboYear;
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
        // InitializeYearData()
        //       - Initalize cboYear()
        // Return Value
        //       -
        // Arguments
        //       - char c_case ("1", "2")
        //
        private void InitializeYearData()
        {
            try
            {
                cboYear.Items.Clear();

                int i_year = 2022;
                for (int i = i_year; i < DateTime.Now.AddYears(3).Year; i++)
                {
                    cboYear.Items.Add(i.ToString());
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
            if (MPCF.CheckValue(cboYear, 1) == false)
            {
                return false;
            }

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

        private void initSheetHeader()
        {
            try
            {
                string s_prev_year = DateTime.Now.AddYears(-1).Year.ToString(); ;
                string s_curr_year = DateTime.Now.Year.ToString(); ;
                string s_year = MPCF.GetMessage(601);
                FarPoint.Win.Spread.SheetView with_1 = spdEquipLedgerList.ActiveSheet;
                if (MPCF.Trim(s_year) == "") s_year = "Result of {0}";
                with_1.ColumnHeader.Cells.Get(1, (int)LIST.RST_CALI_DATE).Value = string.Format(s_year, s_prev_year);  //"Result of " + s_prev_year;
                with_1.ColumnHeader.Cells.Get(1, (int)LIST.PLN_CLAI_DATE).Value = string.Format(s_year, s_curr_year);  //"Result of " + s_curr_year;
                with_1.ColumnHeader.Cells.Get(1, (int)LIST.RST_VARI_DATE).Value = string.Format(s_year, s_prev_year);  //"Result of " + s_prev_year;
                with_1.ColumnHeader.Cells.Get(1, (int)LIST.PLN_VARI_PLAN).Value = string.Format(s_year, s_curr_year);  //"Result of " + s_curr_year;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        //
        // ViewEquipmentLedgerList()
        //       - View Equipment_Ledger List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewEquipmentLedgerList()
        {
            TRSNode in_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LEDGER_LIST_IN");
            List<TRSNode> out_list = new List<TRSNode>();

            string s_prev_year;
            string s_curr_year;
            string s_year = MPCF.GetMessage(601);
            try
            {
                MPCF.ClearList(grbMain);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                s_curr_year = cboYear.Text;
                s_prev_year = (MPCF.ToInt(cboYear.Text) - 1).ToString();

                in_node.AddString("PLAN_YEAR", s_curr_year);
                in_node.AddString("PREV_YEAR", s_prev_year);
                in_node.AddString("EQUIP_ID", cdvEquipCode.Text);
                in_node.AddString("EQUIP_TYPE", cdvEquipType.Text);
                in_node.AddString("MGT_DEPT_CODE", cdvMgtDept.Text);
                in_node.AddString("EQUIP_PLACE_CODE", cdvInstPalce.Text);
                in_node.AddString("USE_DIV", "0");
                if (chkIdentiClass.Checked == true)
                { 
                    in_node.AddChar("MSA_FLAG", chkMSA.Checked == true ? 'Y':' ');
                    in_node.AddChar("SPC_FLAG", chkSPC.Checked == true ? 'Y':' ');
                    in_node.AddChar("CALI_FLAG", chkCalibration.Checked == true ? 'Y':' ');
                    in_node.AddChar("CHECK_FLAG", chkCheck.Checked == true ? 'Y':' ');
                    in_node.AddChar("NONE_FLAG", chkIdleEquip.Checked == true ? 'Y':' ');
                    in_node.AddChar("STANDARD_FLAG", chkStandardEquip.Checked == true ? 'Y':' ');                    
                }
                do
                {
                    TRSNode out_node = new TRSNode("CMMS_VIEW_EQUIPMENT_LEDGER_LIST_OUT");

                    if (MPCR.CallService("CMMS", "CMMS_View_Equipment_Ledger_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    out_list.Add(out_node);

                    in_node.SetString("NEXT_EQUIP_ID", out_node.GetString("NEXT_EQUIP_ID"));

                } while (in_node.GetString("NEXT_EQUIP_ID") != "");

                FarPoint.Win.Spread.SheetView with_1 = spdEquipLedgerList.ActiveSheet;
                int i = 0;

                if (MPCF.Trim(s_year) == "") s_year = "Result of {0}";
                with_1.ColumnHeader.Cells.Get(1, (int)LIST.RST_CALI_DATE).Value = string.Format(s_year, s_prev_year);  //"Result of " + s_prev_year;
                with_1.ColumnHeader.Cells.Get(1, (int)LIST.PLN_CLAI_DATE).Value = string.Format(s_year, s_curr_year);  //"Result of " + s_curr_year;
                with_1.ColumnHeader.Cells.Get(1, (int)LIST.RST_VARI_DATE).Value = string.Format(s_year, s_prev_year);  //"Result of " + s_prev_year;
                with_1.ColumnHeader.Cells.Get(1, (int)LIST.PLN_VARI_PLAN).Value = string.Format(s_year, s_curr_year);  //"Result of " + s_curr_year;

                foreach(TRSNode out_node in out_list)
                {
                    List<TRSNode> equipment_ledger_list = out_node.GetList("EQUIPMENT_LEDGER_LIST");
                    foreach (TRSNode node in equipment_ledger_list)
                    {
                        with_1.RowCount = i + 1;
                        with_1.SetValue(i, MPCF.ToInt(LIST.EQUIP_ID), node.GetString("EQUIP_ID"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.EQUIP_NAME), node.GetString("EQUIP_NAME"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.INST_PLACE), node.GetString("EQUIP_PLACE_CODE"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.CLASS_IDEN), node.GetString("CLASS_IDEN"));
                        with_1.SetValue(i, MPCF.ToInt(LIST.MSA_FLAG), node.GetChar("MSA_FLAG")== 'Y' ? true : false);
                        with_1.SetValue(i, MPCF.ToInt(LIST.SPC_FLAG), node.GetChar("SPC_FLAG")== 'Y' ? true : false);
                        with_1.SetValue(i, MPCF.ToInt(LIST.CALI_FLAG), node.GetChar("CALI_FLAG")== 'Y' ? true : false);
                        with_1.SetValue(i, MPCF.ToInt(LIST.CHECK_FLAG), node.GetChar("CHECK_FLAG")== 'Y' ? true : false);
                        with_1.SetValue(i, MPCF.ToInt(LIST.NONE_FLAG), node.GetChar("NONE_FLAG")== 'Y' ? true : false);
                        with_1.SetValue(i, MPCF.ToInt(LIST.STANDARD_FLAG), node.GetChar("STANDARD_FLAG")== 'Y' ? true : false);
                        with_1.SetValue(i, MPCF.ToInt(LIST.CALI_CYCLE), node.GetInt("CALI_CYCLE"));

                        if (node.GetChar("CALI_DIV") == '0')
                        {
                            with_1.SetValue(i, MPCF.ToInt(LIST.CALI_DIV), "Inside");
                        }
                        else if (node.GetChar("CALI_DIV") == '1')
                        {
                            with_1.SetValue(i, MPCF.ToInt(LIST.CALI_DIV), "Outside");
                        }
                        else
                        {
                            with_1.SetValue(i, MPCF.ToInt(LIST.CALI_DIV), " ");
                        }


                        
                        with_1.SetValue(i, MPCF.ToInt(LIST.MSA_CYCLE), node.GetInt("MSA_CYCLE").ToString());

                        string s_rst_plan_date = "";
                        string s_rst_cali_date = "";
                        string s_rst_cali_result = "";
                        string s_pln_plan_date = "";
                        string s_pln_cali_date = "";
                        string s_pln_cali_result = "";

                        List<TRSNode> calibration_list = node.GetList("CALI_JOIN_LIST");
                        foreach (TRSNode cali_node in calibration_list)
                        {
                            if (MPCF.Trim(cali_node.GetString("RST_PLAN_DATE")) != "")
                            {
                                if (s_rst_plan_date == "")
                                    s_rst_plan_date = MPCF.MakeDateFormat(cali_node.GetString("RST_PLAN_DATE"), DATE_TIME_FORMAT.DATE);
                                else
                                    s_rst_plan_date += Environment.NewLine + MPCF.MakeDateFormat(cali_node.GetString("RST_PLAN_DATE"), DATE_TIME_FORMAT.DATE);                               
                            }
                            if (MPCF.Trim(cali_node.GetString("RST_CALI_DATE")) != "")
                            {
                                if (s_rst_cali_date == "")
                                    s_rst_cali_date = MPCF.MakeDateFormat(cali_node.GetString("RST_CALI_DATE"), DATE_TIME_FORMAT.DATE);
                                else
                                    s_rst_cali_date += Environment.NewLine + MPCF.MakeDateFormat(cali_node.GetString("RST_CALI_DATE"), DATE_TIME_FORMAT.DATE);
                            }
                            if (MPCF.Trim(cali_node.GetString("RST_CALI_RESULT")) != "")
                            {
                                if (s_rst_cali_result == "")
                                    s_rst_cali_result = MPCF.Trim(cali_node.GetString("RST_CALI_RESULT"));
                                else
                                    s_rst_cali_result += Environment.NewLine + MPCF.Trim(cali_node.GetString("RST_CALI_RESULT"));
                            }

                            if (MPCF.Trim(cali_node.GetString("PLAN_DATE")) != "")
                            {
                                if (s_pln_plan_date == "")
                                    s_pln_plan_date = MPCF.MakeDateFormat(cali_node.GetString("PLAN_DATE"), DATE_TIME_FORMAT.DATE);
                                else
                                    s_pln_plan_date += Environment.NewLine + MPCF.MakeDateFormat(cali_node.GetString("PLAN_DATE"), DATE_TIME_FORMAT.DATE);
                            }
                            if (MPCF.Trim(cali_node.GetString("CALI_DATE")) != "")
                            {
                                if (s_pln_cali_date == "")
                                    s_pln_cali_date = MPCF.MakeDateFormat(cali_node.GetString("CALI_DATE"), DATE_TIME_FORMAT.DATE);
                                else
                                    s_pln_cali_date += Environment.NewLine + MPCF.MakeDateFormat(cali_node.GetString("CALI_DATE"), DATE_TIME_FORMAT.DATE);
                            }
                            if (MPCF.Trim(cali_node.GetString("CALI_RESULT")) != "")
                            {
                                if (s_pln_cali_result == "")
                                    s_pln_cali_result = MPCF.Trim(cali_node.GetString("CALI_RESULT"));
                                else
                                    s_pln_cali_result += Environment.NewLine + MPCF.Trim(cali_node.GetString("CALI_RESULT"));
                            }

                        }

                        with_1.SetValue(i, MPCF.ToInt(LIST.RST_CALI_DATE), s_rst_cali_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.RST_CALI_RESULT), s_rst_cali_result);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_CLAI_DATE), s_pln_plan_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_EXEC_DATE), s_pln_cali_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_EXEC_RESULT), s_pln_cali_result);

                        string s_rst_vari_date = "";
                        string s_rst_vari_values = "";
                        string s_rst_line_date = "";
                        string s_rst_line_values = "";
                        string s_rst_bias_date = "";
                        string s_rst_bias_values = "";
                        string s_ana_vari_plan_date = "";
                        string s_ana_vari_date = "";
                        string s_ana_vari_values = "";
                        string s_ana_line_plan_date = "";
                        string s_ana_line_date = "";
                        string s_ana_line_values = "";
                        string s_ana_bias_plan_date = "";
                        string s_ana_bias_date = "";
                        string s_ana_bias_values = "";

                        List<TRSNode> analysis_list = node.GetList("ANA_JOIN_LIST");
                        foreach (TRSNode ana_node in analysis_list)
                        {
                            if (MPCF.Trim(ana_node.GetString("RST_VARI_DATE")) != "")
                            {
                                if (s_rst_vari_date == "")
                                    s_rst_vari_date = MPCF.Trim(ana_node.GetString("RST_VARI_DATE"));
                                else
                                    s_rst_vari_date += Environment.NewLine + MPCF.Trim(ana_node.GetString("RST_VARI_DATE"));
                            }
                            if (MPCF.Trim(ana_node.GetString("RST_VARI_VALUES")) != "")
                            {
                                if (s_rst_vari_values == "")
                                    s_rst_vari_values = MPCF.Trim(ana_node.GetString("RST_VARI_VALUES"));
                                else
                                    s_rst_vari_values += Environment.NewLine + MPCF.Trim(ana_node.GetString("RST_VARI_VALUES"));
                            }
                            if (MPCF.Trim(ana_node.GetString("RST_LINE_DATE")) != "")
                            {
                                if (s_rst_line_date == "")
                                    s_rst_line_date = MPCF.Trim(ana_node.GetString("RST_LINE_DATE"));
                                else
                                    s_rst_line_date += Environment.NewLine + MPCF.Trim(ana_node.GetString("RST_LINE_DATE"));
                            }
                            if (MPCF.Trim(ana_node.GetString("RST_LINE_VALUES")) != "")
                            {
                                if (s_rst_line_values == "")
                                    s_rst_line_values = MPCF.Trim(ana_node.GetString("RST_LINE_VALUES"));
                                else
                                    s_rst_line_values += Environment.NewLine + MPCF.Trim(ana_node.GetString("RST_LINE_VALUES"));
                            }
                            if (MPCF.Trim(ana_node.GetString("RST_BIAS_DATE")) != "")
                            {
                                if (s_rst_bias_date == "")
                                    s_rst_bias_date = MPCF.Trim(ana_node.GetString("RST_BIAS_DATE"));
                                else
                                    s_rst_bias_date += Environment.NewLine + MPCF.Trim(ana_node.GetString("RST_BIAS_DATE"));
                            }
                            if (MPCF.Trim(ana_node.GetString("RST_BIAS_VALUES")) != "")
                            {
                                if (s_rst_bias_values == "")
                                    s_rst_bias_values = MPCF.Trim(ana_node.GetString("RST_BIAS_VALUES"));
                                else
                                    s_rst_bias_values += Environment.NewLine + MPCF.Trim(ana_node.GetString("RST_BIAS_VALUES"));
                            }
                            if (MPCF.Trim(ana_node.GetString("ANA_VARI_PLAN_DATE")) != "")
                            {
                                if (s_ana_vari_plan_date == "")
                                    s_ana_vari_plan_date = MPCF.Trim(ana_node.GetString("ANA_VARI_PLAN_DATE"));
                                else
                                    s_ana_vari_plan_date += Environment.NewLine + MPCF.Trim(ana_node.GetString("ANA_VARI_PLAN_DATE"));
                            }
                            if (MPCF.Trim(ana_node.GetString("ANA_VARI_DATE")) != "")
                            {
                                if (s_ana_vari_date == "")
                                    s_ana_vari_date = MPCF.Trim(ana_node.GetString("ANA_VARI_DATE"));
                                else
                                    s_ana_vari_date += Environment.NewLine + MPCF.Trim(ana_node.GetString("ANA_VARI_DATE"));
                            }
                            if (MPCF.Trim(ana_node.GetString("ANA_VARI_VALUES")) != "")
                            {
                                if (s_ana_vari_values == "")
                                    s_ana_vari_values = MPCF.Trim(ana_node.GetString("ANA_VARI_VALUES"));
                                else
                                    s_ana_vari_values += Environment.NewLine + MPCF.Trim(ana_node.GetString("ANA_VARI_VALUES"));
                            }
                            if (MPCF.Trim(ana_node.GetString("ANA_LINE_PLAN_DATE")) != "")
                            {
                                if (s_ana_line_plan_date == "")
                                    s_ana_line_plan_date = MPCF.Trim(ana_node.GetString("ANA_LINE_PLAN_DATE"));
                                else
                                    s_ana_line_plan_date += Environment.NewLine + MPCF.Trim(ana_node.GetString("ANA_LINE_PLAN_DATE"));
                            }
                            if (MPCF.Trim(ana_node.GetString("ANA_LINE_DATE")) != "")
                            {
                                if (s_ana_line_date == "")
                                    s_ana_line_date = MPCF.Trim(ana_node.GetString("ANA_LINE_DATE"));
                                else
                                    s_ana_line_date += Environment.NewLine + MPCF.Trim(ana_node.GetString("ANA_LINE_DATE"));
                            }
                            if (MPCF.Trim(ana_node.GetString("ANA_LINE_VALUES")) != "")
                            {
                                if (s_ana_line_values == "")
                                    s_ana_line_values = MPCF.Trim(ana_node.GetString("ANA_LINE_VALUES"));
                                else
                                    s_ana_line_values += Environment.NewLine + MPCF.Trim(ana_node.GetString("ANA_LINE_VALUES"));
                            }

                            if (MPCF.Trim(ana_node.GetString("ANA_BIAS_PLAN_DATE")) != "")
                            {
                                if (s_ana_bias_plan_date == "")
                                    s_ana_bias_plan_date = MPCF.Trim(ana_node.GetString("ANA_BIAS_PLAN_DATE"));
                                else
                                    s_ana_bias_plan_date += Environment.NewLine + MPCF.Trim(ana_node.GetString("ANA_BIAS_PLAN_DATE"));
                            }
                            if (MPCF.Trim(ana_node.GetString("ANA_BIAS_DATE")) != "")
                            {
                                if (s_ana_bias_date == "")
                                    s_ana_bias_date = MPCF.Trim(ana_node.GetString("ANA_BIAS_DATE"));
                                else
                                    s_ana_bias_date += Environment.NewLine + MPCF.Trim(ana_node.GetString("ANA_BIAS_DATE"));
                            }
                            if (MPCF.Trim(ana_node.GetString("ANA_BIAS_VALUES")) != "")
                            {
                                if (s_ana_bias_values == "")
                                    s_ana_bias_values = MPCF.Trim(ana_node.GetString("ANA_BIAS_VALUES"));
                                else
                                    s_ana_bias_values += Environment.NewLine + MPCF.Trim(ana_node.GetString("ANA_BIAS_VALUES"));
                            }
                        }
                        with_1.SetValue(i, MPCF.ToInt(LIST.RST_VARI_DATE), s_rst_vari_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.RST_VARI_VALUE), s_rst_vari_values);
                        with_1.SetValue(i, MPCF.ToInt(LIST.RST_LINE_DATE), s_rst_line_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.RST_LINE_VALUE), s_rst_line_values);
                        with_1.SetValue(i, MPCF.ToInt(LIST.RST_BIAS_DATE), s_rst_bias_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.RST_BIAS_VALUE), s_rst_bias_values);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_VARI_PLAN), s_ana_vari_plan_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_VARI_DATE), s_ana_vari_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_VARI_VALUE), s_ana_vari_values);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_LINE_PLAN), s_ana_line_plan_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_LINE_DATE), s_ana_line_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_LINE_VALUE), s_ana_line_values);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_BIAS_PLAN), s_ana_bias_plan_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_BIAS_DATE), s_ana_bias_date);
                        with_1.SetValue(i, MPCF.ToInt(LIST.PLN_BIAS_VALUE), s_ana_bias_values);

                        with_1.Rows[i].Height = with_1.Rows[i].GetPreferredHeight();


                        i++;
                    }
                }

                //with_1.Rows[0].Height

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        #endregion

        private void frmMMSEquipmentLedgerList_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);

                this.spdEquipLedgerList.ActiveSheet.RowCount = 0;
                spdEquipLedgerList.ActiveSheet.FrozenColumnCount = (int)LIST.MSA_FLAG;

                cboYear.Text = DateTime.Now.Year.ToString();

                initSheetHeader();
                // TODO
                b_load_flag = true;
            }
        }

        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == false) return;

            if (ViewEquipmentLedgerList() == false) return;
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            sCond = "Key ID : " + MPCF.Trim(cboYear.Text) + "\r";
            //sCond = sCond + "Date : TEST MPCF.MakeDateFormat(MPCF.ToDate(dtpTo))";
            //  MPCF.ExportToExcel(spdEquipLedgerList, this.Text, sCond);

            HQCE.ExportSpreadSheetToExcel(spdEquipLedgerList.ActiveSheet, this.Text, sCond, true, true, true);
        }

        private void chkIdentiClass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIdentiClass.Checked == false)
            {
                this.chkMSA.Checked = false;
                this.chkSPC.Checked = false;
                this.chkIdleEquip.Checked = false;
                this.chkCalibration.Checked = false;
                this.chkCheck.Checked = false;
                this.chkStandardEquip.Checked = false;
            }

            grbIdentiClass.Enabled = chkIdentiClass.Checked;

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

        private void cdvInstPalce_ButtonPress(object sender, EventArgs e)
        {
            cdvInstPalce.Init();
            MPCF.InitListView(cdvInstPalce.GetListView);
            cdvInstPalce.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvInstPalce.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvInstPalce.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvInstPalce.GetListView, '1', MPGC.MP_GCM_MMS_PLACE_CODE) == true)
            {
                cdvInstPalce.InsertEmptyRow(0, 1);
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
