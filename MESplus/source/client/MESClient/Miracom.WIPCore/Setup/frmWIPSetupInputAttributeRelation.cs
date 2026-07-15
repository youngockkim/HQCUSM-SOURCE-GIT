//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupInputAttributeRelation.cs
//   Description : Setup Input Attribute value Relation
//
//   MES Version : 5.0.2
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - View_Lot_Info() : View Cassette Lot List Information
//       - DisplayLossLotList() : Loss Lot List Display
//       - View_Operation() : View Operation Information
//       - ViewGCMLossCodeList() : View Operation Loss Code List

//       
//
//   Detail Description
//       -
//
//   History
//       - 2010-03-10: Created by Aiden
//
//
//   Copyright(C) 1998-2011 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupInputAttributeRelation : Miracom.MESCore.SetupForm02
    {
        public frmWIPSetupInputAttributeRelation()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        public enum Columns
        {
            Type = 0,
            DataType = 1,
            ValueName = 2,
            DisplayText = 3,
            PointType = 4,          //Start,End,ADHOC
            DisplayType = 5,    //View,Internal,CustomInput
            InputType = 6,
            InputValueType = 7,
            Cmf = 8
        }

        public enum ColumnsTool
        {
            Type = 0,
            ToolType = 1,
            ToolStatus = 2,
            ToolEvent = 3,
            PointType = 4,
            DisplayType = 5,
            InputType = 6,
            InputValueType = 7,
            Cmf = 8
        }

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private string s_selected_tool_type;
        private Dictionary<string, char> h_point_type;

        #endregion

        public frmWIPSetupInputAttributeRelation frmClone;

        private ArrayList arrCMFValue = new ArrayList();

        public ArrayList arrInputOperCMF
        {
            get
            {
                return arrCMFValue;
            }
            set
            {
                arrCMFValue = value;
            }
        }

        #region " Function Definition "

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {
            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":

                    break;

                case "UPDATE":

                    break;

                case "DELETE":

                    break;

            }
            return true;
        }

        // SetLotCmfPrompt()
        //       - Function Description
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SetLotCmfPrompt(FarPoint.Win.Spread.FpSpread spdObj, int iCmfStartIndex)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            int i;

            try
            {
                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_INPUT_OPER_VALUE, ref out_node, "", true) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetString("PROMPT") != "")
                    {
                        spdObj.ActiveSheet.ColumnHeader.Cells[0, i + iCmfStartIndex].Value = out_node.GetList(0)[i].GetString("PROMPT");
                    }
                    else
                    {
                        spdObj.ActiveSheet.ColumnHeader.Columns[i + iCmfStartIndex].Width = 0;
                        spdObj.ActiveSheet.ColumnHeader.Columns[i + iCmfStartIndex].Visible = false;
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
        // ViewOperInputValueList()
        //       - Get Operation Input Value
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewOperInputValueList()
        {
            TRSNode in_node = new TRSNode("VIEW_OPER_INPUT_VALUE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_OPER_INPUT_VALUE_LIST_OUT");
            List<TRSNode> value_list;
            int i;
            int i_row;
            int i_col;
            int i_argb;
            string s_value_type;
            string s_display_type;
            string s_point_type;
            string s_input_type;
            FarPoint.Win.Spread.SheetView sheet;

            MPCF.FieldClear(grpValueType);
            MPCF.FieldClear(grpToolValue);
            MPCF.ClearList(spdData);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
            in_node.AddString("MAT_ID", udcMFO.MatID);
            in_node.AddInt("MAT_VER", udcMFO.MatVersion);
            in_node.AddString("FLOW", udcMFO.Flow);
            in_node.AddString("OPER", udcMFO.Oper);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Operation_Input_Value_List", in_node, ref out_node) == false)
                {
                    return false;
                }                

                value_list = out_node.GetList("VALUE_LIST");
                for (i = 0; i < value_list.Count; i++)
                {
                    s_value_type = "";
                    s_display_type = "";
                    s_point_type = "";
                    s_input_type = "";

                    switch (value_list[i].GetChar("VALUE_TYPE"))
                    {
                        case 'A':
                            s_value_type = "Attribute";
                            break;
                        case 'C':
                            s_value_type = "Table-Column";
                            break;
                        case 'X':
                            s_value_type = "Lot-Extension";
                            break;
                        case 'T':
                            s_value_type = "Tool";
                            break;
                    }
                    switch (value_list[i].GetChar("DISPLAY_TYPE"))
                    {
                        case 'V':
                            s_display_type = "View";
                            break;
                        case 'I':
                            s_display_type = "Internal Input";
                            break;
                        case 'U':
                            s_display_type = "User Input";
                            break;
                        case 'Q':
                            s_display_type = "Input Lot QTY";
                            break;
                    }

                    foreach (KeyValuePair<string, char> kv in h_point_type)
                    {
                        if (kv.Value == value_list[i].GetChar("POINT_TYPE"))
                        {
                            s_point_type = kv.Key;
                            break;
                        }
                    }
                    
                    switch (value_list[i].GetChar("INPUT_TYPE"))
                    {
                        case 'I':
                            s_input_type = "Individual";
                            break;
                        case 'A':
                            s_input_type = "At a Time";
                            break;
                    }

                    sheet = spdData.ActiveSheet;
                    i_row = sheet.RowCount;
                    sheet.RowCount++;

                    //
                    sheet.Cells[i_row, (int)Columns.Type].Value = s_value_type;
                    sheet.Cells[i_row, (int)Columns.DataType].Value = value_list[i].GetString("DATA_1"); //Attribute Type, Table Name, Tool Type
                    sheet.Cells[i_row, (int)Columns.ValueName].Value = value_list[i].GetString("DATA_2"); //Attirbute Name, Column Name, Tool Status
                    sheet.Cells[i_row, (int)Columns.DisplayText].Value = value_list[i].GetString("DATA_3"); //Attribute Name Desc, Display Text, Tool Event

                    sheet.Cells[i_row, (int)Columns.DisplayText].Tag = value_list[i].GetString("DATA_4"); //Where, Tool Event Desc

                    //RequireFlag Column (DisplayText, Tool Status)
                    if (value_list[i].GetChar("REQUIRE_FLAG") == 'Y')
                    {
                        if (s_value_type.Equals("Tool"))
                        {
                            sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].Font = new Font(spdData.Font.Name, spdData.Font.Size, FontStyle.Bold);
                        }
                        else
                        {
                            sheet.Cells[i_row, (int)Columns.DisplayText].Font = new Font(spdData.Font.Name, spdData.Font.Size, FontStyle.Bold);
                            sheet.Cells[i_row, (int)Columns.DisplayText].Font = new Font(spdData.Font.Name, spdData.Font.Size, FontStyle.Bold);
                        }
                    }
                    //RGB Color
                    i_argb = value_list[i].GetInt("BACK_COLOR");
                    if (s_value_type.Equals("Tool"))
                    {
                        sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].BackColor = Color.FromArgb(i_argb);
                        if (sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].BackColor.GetBrightness() < 0.5)
                        {
                            sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        sheet.Cells[i_row, (int)Columns.DisplayText].BackColor = Color.FromArgb(i_argb);
                        if (sheet.Cells[i_row, (int)Columns.DisplayText].BackColor.GetBrightness() < 0.5)
                        {
                            sheet.Cells[i_row, (int)Columns.DisplayText].ForeColor = Color.White;
                        }
                    }
                    sheet.Cells[i_row, (int)Columns.PointType].Value = s_point_type;
                    sheet.Cells[i_row, (int)Columns.DisplayType].Value = s_display_type;
                    sheet.Cells[i_row, (int)Columns.InputType].Value = s_input_type;

                    //Input Value Type
                    i_col = (int)Columns.InputValueType;
                    switch (value_list[i].GetString("INPUT_VALUE_TYPE"))
                    {
                        case "LQ":
                            sheet.Cells[i_row, i_col].Value = "Lot Quantity";
                            sheet.Cells[i_row, i_col].Tag = "LQ";
                            break;
                        case "LC":
                            sheet.Cells[i_row, i_col].Value = "Lot Count";
                            sheet.Cells[i_row, i_col].Tag = "LC";
                            break;
                        case "UC":
                            sheet.Cells[i_row, i_col].Value = "Usage Count";
                            sheet.Cells[i_row, i_col].Tag = "UC";
                            break;
                        case "UR":
                            sheet.Cells[i_row, i_col].Value = "Use Equipment";
                            sheet.Cells[i_row, i_col].Tag = "UR";
                            break;
                        case "CT":
                            sheet.Cells[i_row, i_col].Value = "Current Time";
                            sheet.Cells[i_row, i_col].Tag = "CT";
                            break;
                        case "CV":
                            sheet.Cells[i_row, i_col].Value = "Custom Value";
                            sheet.Cells[i_row, i_col].Tag = "CV";
                            break;
                    }

                    //Set Cmf
                    i_col = (int)Columns.Cmf;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_1");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_2");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_3");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_4");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_5");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_6");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_7");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_8");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_9");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_10");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_11");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_12");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_13");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_14");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_15");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_16");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_17");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_18");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_19");
                    i_col++;
                    sheet.Cells[i_row, i_col].Value = value_list[i].GetString("CMF_20");
                }

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while (in_node.GetInt("NEXT_SEQ") > 0);

            return true;
        }

        private bool ViewTableList(ListView listView)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            //Modify by J.S. 2012.02.07 recyclebin에 있는 항목 제거
            in_node.AddString("SQL", "SELECT TNAME FROM TAB WHERE TNAME NOT IN (SELECT OBJECT_NAME FROM RECYCLEBIN) ORDER BY TNAME");
            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(listView, out_node);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (out_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        //To List all Column names from the table
        private bool ViewTableColumnList(ListView listView, string tableName)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("SQL", "SELECT COLUMN_NAME AS COLUMN_NAME " +
                                     "       FROM USER_TAB_COLUMNS " +
                                     "       WHERE TABLE_NAME = '" + tableName + "' " +
                                     "       ORDER BY COLUMN_NAME");
            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(listView, out_node);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (out_node.GetInt("NEXT_ROW") > 0);

            return true;
        }

        private void ChangeSQLSyntaxColor()
        {
            int i_start = 0;
            int i_len = 0;

            if (MPCF.Trim(txtWhere.Text) == "")
            {
                return;
            }

            if (txtWhere.Text[txtWhere.Text.Length - 1] != ' ')
            {
                txtWhere.Text += " ";
            }

            txtWhere.SelectionStart = 0;
            txtWhere.SelectionLength = txtWhere.Text.Length;
            txtWhere.SelectionColor = System.Drawing.SystemColors.ControlText;

            while (i_len < txtWhere.Text.Length)
            {
                if (txtWhere.Text[i_len] == ' ' || i_len == txtWhere.Text.Length - 1)
                {
                    if (MPCF.IsSQLSyntax(MPCF.ToUpper(txtWhere.Text.Substring(i_start, i_len - i_start))) == true ||
                        txtWhere.Text.Substring(i_start, i_len - i_start).IndexOf("$") > 0)
                    {
                        txtWhere.SelectionStart = i_start;
                        txtWhere.SelectionLength = i_len - i_start;
                        txtWhere.SelectionColor = System.Drawing.Color.Blue;
                        txtWhere.SelectionStart = i_len;
                        txtWhere.SelectionLength = 0;
                        txtWhere.SelectionColor = System.Drawing.SystemColors.ControlText;
                    }

                    i_start = i_len;
                }

                i_len++;
            }
        }

        private void SetInNode(TRSNode in_node, FarPoint.Win.Spread.FpSpread spread)
        {
            int i, i_col;
            TRSNode value_item;

            string s_value_type;
            string s_display_type;
            string s_point_type;
            string s_input_type;
            string s_input_value_type;

            for (i = 0; i < spread.ActiveSheet.RowCount; i++)
            {
                s_value_type = MPCF.Trim(spread.ActiveSheet.Cells[i, (int)Columns.Type].Value);
                s_point_type = MPCF.Trim(spread.ActiveSheet.Cells[i, (int)Columns.PointType].Value);
                s_display_type = MPCF.Trim(spread.ActiveSheet.Cells[i, (int)Columns.DisplayType].Value);
                s_input_type = MPCF.Trim(spread.ActiveSheet.Cells[i, (int)Columns.InputType].Value);
                s_input_value_type = MPCF.Trim(spread.ActiveSheet.Cells[i, (int)Columns.InputValueType].Tag);

                switch (s_value_type)
                {
                    case "Attribute":
                        s_value_type = "A";
                        break;
                    case "Table-Column":
                        s_value_type = "C";
                        break;
                    case "Lot-Extension":
                        s_value_type = "X";
                        break;
                    case "Tool":
                        s_value_type = "T";
                        break;
                }
                switch (s_display_type)
                {
                    case "View":
                        s_display_type = "V";
                        break;
                    case "Input":
                        s_display_type = "I";
                        break;
                    case "User Input":
                        s_display_type = "U";
                        break;
                    case "Input Lot QTY":
                        s_display_type = "Q";
                        break;
                }

                s_point_type = h_point_type[s_point_type].ToString();

                switch (s_input_type)
                {
                    case "Individual":
                        s_input_type = "I";
                        break;
                    case "At a Time":
                        s_input_type = "A";
                        break;
                }

                value_item = in_node.AddNode("VALUE_LIST");

                value_item.AddChar("VALUE_TYPE", MPCF.ToChar(s_value_type));
                value_item.AddChar("DISPLAY_TYPE", MPCF.ToChar(s_display_type));
                value_item.AddChar("POINT_TYPE", MPCF.ToChar(s_point_type));
                value_item.AddChar("INPUT_TYPE", MPCF.ToChar(s_input_type));
                value_item.AddString("INPUT_VALUE_TYPE", s_input_value_type);

                /* Tool */
                if (s_value_type.Equals("T"))
                {
                    value_item.AddChar("REQUIRE_FLAG", (spread.ActiveSheet.Cells[i, (int)ColumnsTool.ToolStatus].Font != null && spread.ActiveSheet.Cells[i, (int)ColumnsTool.ToolStatus].Font.Bold == true ? 'Y' : ' '));
                    value_item.AddInt("BACK_COLOR", spread.ActiveSheet.Cells[i, (int)ColumnsTool.ToolStatus].BackColor.ToArgb());
                    value_item.AddString("DATA_1", MPCF.Trim(spread.ActiveSheet.Cells[i, (int)ColumnsTool.ToolType].Value));        //Tool Type
                    value_item.AddString("DATA_2", MPCF.Trim(spread.ActiveSheet.Cells[i, (int)ColumnsTool.ToolStatus].Value));      //Tool Status
                    value_item.AddString("DATA_3", MPCF.Trim(spread.ActiveSheet.Cells[i, (int)ColumnsTool.ToolEvent].Value));       //Tool Event

                }
                /* Attribute, Table-Column, Lot Extension */
                else
                {
                    value_item.AddChar("REQUIRE_FLAG", (spread.ActiveSheet.Cells[i, (int)Columns.DisplayText].Font != null && spread.ActiveSheet.Cells[i, (int)Columns.DisplayText].Font.Bold == true ? 'Y' : ' '));
                    value_item.AddInt("BACK_COLOR", spread.ActiveSheet.Cells[i, (int)Columns.DisplayText].BackColor.ToArgb());
                    value_item.AddString("DATA_1", MPCF.Trim(spread.ActiveSheet.Cells[i, (int)Columns.DataType].Value));        //Attribute Type, Table Name
                    value_item.AddString("DATA_2", MPCF.Trim(spread.ActiveSheet.Cells[i, (int)Columns.ValueName].Value));      //Attirbute Name, Column Name

                    // Attribute 는 Name Desc 를 Attribute 정의값으로 참조하므로 따로 저장하지 않음.
                    if (s_value_type.Equals("A") == false)
                    {
                        value_item.AddString("DATA_3", MPCF.Trim(spread.ActiveSheet.Cells[i, (int)Columns.DisplayText].Value)); //Display Text
                    }
                    if (s_value_type.Equals("C"))
                    {
                        value_item.AddString("DATA_4", MPCF.Trim(spread.ActiveSheet.Cells[i, 3].Tag)); //Where
                    }
                }


                i_col = (int)Columns.Cmf;
                value_item.AddString("CMF_1", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_2", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_3", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_4", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_5", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_6", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_7", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_8", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_9", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_10", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_11", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_12", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_13", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_14", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_15", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_16", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_17", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_18", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF_19", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
                value_item.AddString("CMF20", MPCF.Trim(spread.ActiveSheet.Cells[i, i_col].Value)); i_col++;
            }
        }

        private bool ViewToolType(ListView listview)
        {

            TRSNode in_node = new TRSNode("View_Tool_Type_In");
            TRSNode out_node = new TRSNode("View_Tool_Type_Out");
            ListViewItem itmx;
            int i;
            string s_prompt;

            try
            {
                MPCF.InitListView(listview);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", cdvToolType.Text);

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < 30; i++)
                {
                    s_prompt = out_node.GetList(0)[i].GetString("PROMPT");
                    if (MPCF.Trim(s_prompt) != "")
                    {
                        itmx = new ListViewItem(s_prompt, (int)SMALLICON_INDEX.IDX_CODE_DATA);
                        listview.Items.Add(itmx);
                    }
                }

                //if (listview.Items.Count > 0)
                //{
                //    listview.Items.Add("--------------------");
                //}
                //listview.Items.Add("TOOL_GRP", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("TOOL_SET_ID", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("TOOL_SET_LOCATION", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("TOOL_STATUS", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("LOT_ID", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("SUBLOT_ID", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("RES_ID", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("SUBRES_ID", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("AREA_ID", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("SUB_AREA_ID", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("TOOL_LOCATION", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("VENDOR_ID", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("MAT_ID", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("MAT_VER", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("FLOW", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("OPER", (int)SMALLICON_INDEX.IDX_TOOL);
                //listview.Items.Add("GRADE", (int)SMALLICON_INDEX.IDX_TOOL);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsExistInput()
        {
            int i;
            FarPoint.Win.Spread.SheetView sheet;
            sheet = spdData.ActiveSheet;

            //Attribute
            if (tabValue.SelectedTab == tbpAttribute)
            {
                for (i = 0; i < sheet.RowCount; i++)
                {
                    if (cdvAttrType.Text.Equals(MPCF.Trim(sheet.Cells[i, (int)Columns.DataType].Value)) &&
                       cdvAttrName.Text.Equals(MPCF.Trim(sheet.Cells[i, (int)Columns.ValueName].Value)))
                    {
                        if (rbtStart.Checked == true && MPCF.Trim(sheet.Cells[i, (int)Columns.PointType].Value).Equals("Start")) return false;
                        if (rbtAdHoc.Checked == true && MPCF.Trim(sheet.Cells[i, (int)Columns.PointType].Value).Equals("AdHoc")) return false;
                        if (rbtEnd.Checked == true && MPCF.Trim(sheet.Cells[i, (int)Columns.PointType].Value).Equals("End")) return false;
                    }
                }
            }
            //Table Column
            else if (tabValue.SelectedTab == tbpTableColumn || tabValue.SelectedTab == tbpLotEx)
            {
                for (i = 0; i < sheet.RowCount; i++)
                {
                    if (cdvTable.Text.Equals(MPCF.Trim(sheet.Cells[i, (int)Columns.DataType].Value)) &&
                       cdvColumn.Text.Equals(MPCF.Trim(sheet.Cells[i, (int)Columns.ValueName].Value)) &&
                       txtDisplayText.Text.Equals(MPCF.Trim(sheet.Cells[i, (int)Columns.DisplayText].Value)))
                    {
                        if (rbtStart.Checked == true && MPCF.Trim(sheet.Cells[i, (int)Columns.PointType].Value).Equals("Start")) return false;
                        if (rbtAdHoc.Checked == true && MPCF.Trim(sheet.Cells[i, (int)Columns.PointType].Value).Equals("AdHoc")) return false;
                        if (rbtEnd.Checked == true && MPCF.Trim(sheet.Cells[i, (int)Columns.PointType].Value).Equals("End")) return false;
                    }
                }
            }
            //Tool
            else if (tabValue.SelectedTab == tbpTool)
            {
                for (i = 0; i < sheet.RowCount; i++)
                {
                    if (cdvToolType.Text.Equals(MPCF.Trim(sheet.Cells[i, (int)ColumnsTool.ToolType].Value)) &&
                        cdvToolStatus.Text.Equals(MPCF.Trim(sheet.Cells[i, (int)ColumnsTool.ToolStatus].Value)))
                    {
                        if (rbtStart.Checked == true && MPCF.Trim(sheet.Cells[i, (int)ColumnsTool.PointType].Value).Equals("Start")) return false;
                        if (rbtAdHoc.Checked == true && MPCF.Trim(sheet.Cells[i, (int)ColumnsTool.PointType].Value).Equals("AdHoc")) return false;
                        if (rbtEnd.Checked == true && MPCF.Trim(sheet.Cells[i, (int)ColumnsTool.PointType].Value).Equals("End")) return false;
                    }
                }
            }

            return true;
        }       

        private bool ApplyInputValue(char c_add_or_modify, int i_sel_row)
        {
            int i_row, i_idx;
            string s_value_type;
            string s_display_type;
            string s_point_type;
            string s_input_type;
            string s_input_value_type;
            FarPoint.Win.Spread.SheetView sheet = spdData_Sheet1;
            Font font = null;

            s_value_type = "";
            s_display_type = "";
            s_point_type = "";
            s_input_type = "";
            s_input_value_type = "";

            //1. Validation
            if (c_add_or_modify == 'A')
            {
                if (IsExistInput() == false) return false;
            }

            //Validation
            if (rbtInput.Checked == true)
            {
                if (MPCF.CheckValue(cboInputValueType, 1) == false) return false;
            }
            if (cboInputValueType.Text != "")
            {
                s_input_value_type = cboInputValueType.Text;
            }

            //Validation
            if (tabValue.SelectedTab == tbpAttribute)
            {
                if (MPCF.CheckValue(cdvAttrType, 1) == false) return false;
                if (MPCF.CheckValue(cdvAttrName, 1) == false) return false;

                if (rbtInput.Checked == true)
                {
                    if (MPCF.CheckValue(cboInputValueType, 1) == false) return false;
                }
            }
            else if (tabValue.SelectedTab == tbpTableColumn || tabValue.SelectedTab == tbpLotEx)
            {
                if (tabValue.SelectedTab == tbpTableColumn && MPCF.CheckValue(cdvTable, 1) == false) return false;
                if (MPCF.CheckValue(cdvColumn, 1) == false) return false;
                if (MPCF.CheckValue(txtDisplayText, 1) == false) return false;

                if (rbtInput.Checked == true)
                {
                    if (MPCF.CheckValue(cboInputValueType, 1) == false) return false;
                }
            }
            else if (tabValue.SelectedTab == tbpTool)
            {
                if (MPCF.CheckValue(cdvToolType, 1) == false) return false;
                if (MPCF.CheckValue(cdvToolStatus, 1) == false) return false;

                if (rbtView.Checked == true)
                {
                    cdvToolEvent.Text = "";
                }
                else
                {
                    if (MPCF.CheckValue(cdvToolEvent, 1) == false) return false;
                }
            }

            //2. Get Data
            if (c_add_or_modify == 'A')
            {
                i_row = sheet.RowCount;
                sheet.RowCount++;
            }
            else
            {
                i_row = i_sel_row;
            }

            if (tabValue.SelectedTab == tbpAttribute) s_value_type = "Attribute";
            else if (tabValue.SelectedTab == tbpTableColumn) s_value_type = "Table-Column";
            else if (tabValue.SelectedTab == tbpLotEx) s_value_type = "Lot-Extension";
            else if (tabValue.SelectedTab == tbpTool) s_value_type = "Tool";

            //Point
            if (rbtStart.Checked == true) s_point_type = "Start";
            else if (rbtAdHoc.Checked == true) s_point_type = "AdHoc";
            else if (rbtEnd.Checked == true) s_point_type = "End";
            else s_point_type = cboPointType.Text;

            //DisplayType
            if (rbtView.Checked == true) s_display_type = "View";
            else if (rbtInput.Checked == true) s_display_type = "Internal Input";
            else if (rbtViewInput.Checked == true) s_display_type = "User Input";

            //InputType
            if (rbtIndividual.Checked == true) s_input_type = "Individual";
            else if (rbtAtatime.Checked == true) s_input_type = "At a Time";

            //InputValueType
            if (cboInputValueType.Text != "")
            {
                s_input_value_type = cboInputValueType.Text;
            }
            if (chkRequire.Checked == true)
            {
                font = new Font(spdData.Font.Name, spdData.Font.Size, FontStyle.Bold);
            }
            else
            {
                font = new Font(spdData.Font.Name, spdData.Font.Size, FontStyle.Regular);
            }

            //3. Set Data
            sheet.Cells[i_row, (int)Columns.Type].Value = s_value_type;

            if (tabValue.SelectedTab == tbpAttribute)
            {
                sheet.Cells[i_row, (int)Columns.DataType].Value = cdvAttrType.Text;
                sheet.Cells[i_row, (int)Columns.ValueName].Value = cdvAttrName.Text;
                sheet.Cells[i_row, (int)Columns.DisplayText].Value = cdvAttrName.DescText;

                sheet.Cells[i_row, (int)Columns.DisplayText].BackColor = txtBackColor.BackColor;
                sheet.Cells[i_row, (int)Columns.DisplayText].ForeColor = txtBackColor.ForeColor;
                sheet.Cells[i_row, (int)Columns.DisplayText].Font = font;
            }
            else if(tabValue.SelectedTab == tbpTableColumn || tabValue.SelectedTab == tbpLotEx)
            {
                sheet.Cells[i_row, (int)Columns.DataType].Value = cdvTable.Text;
                sheet.Cells[i_row, (int)Columns.ValueName].Value = cdvColumn.Text;
                sheet.Cells[i_row, (int)Columns.DisplayText].Value = txtDisplayText.Text;
                sheet.Cells[i_row, (int)Columns.DisplayText].Tag = txtWhere.Text;

                sheet.Cells[i_row, (int)Columns.DisplayText].BackColor = txtBackColor.BackColor;
                sheet.Cells[i_row, (int)Columns.DisplayText].ForeColor = txtBackColor.ForeColor;
                sheet.Cells[i_row, (int)Columns.DisplayText].Font = font;

            }
            else if (tabValue.SelectedTab == tbpTool)
            {
                sheet.Cells[i_row, (int)ColumnsTool.ToolType].Value = cdvToolType.Text;
                sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].Value = cdvToolStatus.Text;
                sheet.Cells[i_row, (int)ColumnsTool.ToolEvent].Value = cdvToolEvent.Text;

                sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].BackColor = txtBackColor.BackColor;
                sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].ForeColor = txtBackColor.ForeColor;
                sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].Font = font;
            }

            sheet.Cells[i_row, (int)Columns.PointType].Value = s_point_type;
            sheet.Cells[i_row, (int)Columns.DisplayType].Value = s_display_type;
            sheet.Cells[i_row, (int)Columns.InputType].Value = s_input_type;
            if (s_input_value_type != "")
            {
                sheet.Cells[i_row, (int)Columns.InputValueType].Tag = MPCF.SubtractString(s_input_value_type, ":", false, false);
                sheet.Cells[i_row, (int)Columns.InputValueType].Value = MPCF.SubtractString(s_input_value_type, ":", true, false);
            }
            else
            {
                sheet.Cells[i_row, (int)Columns.InputValueType].Tag = null;
                sheet.Cells[i_row, (int)Columns.InputValueType].Value = null;
            }

            //CMF
            for (i_idx = 0; i_idx < arrInputOperCMF.Count; i_idx++)
            {
                sheet.Cells[i_row, i_idx + (int)Columns.Cmf].Value = arrInputOperCMF[i_idx].ToString();
            }

            return true;
        }

        private void SetupInputOperationCMF(FarPoint.Win.Spread.FpSpread spdObj, int iCmfStartIndex)
        {
            frmWIPSetupInputOperationCMF f;

            try
            {
                f = new frmWIPSetupInputOperationCMF();
                f.setOwner(this);

                if (spdObj.ActiveSheet.RowCount > 0)
                {
                    f.cdvCMF1.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex].Value);
                    f.cdvCMF2.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 1].Value);
                    f.cdvCMF3.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 2].Value);
                    f.cdvCMF4.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 3].Value);
                    f.cdvCMF5.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 4].Value);
                    f.cdvCMF6.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 5].Value);
                    f.cdvCMF7.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 6].Value);
                    f.cdvCMF8.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 7].Value);
                    f.cdvCMF9.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 8].Value);
                    f.cdvCMF10.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 9].Value);
                    f.cdvCMF11.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 10].Value);
                    f.cdvCMF12.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 11].Value);
                    f.cdvCMF13.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 12].Value);
                    f.cdvCMF14.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 13].Value);
                    f.cdvCMF15.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 14].Value);
                    f.cdvCMF16.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 15].Value);
                    f.cdvCMF17.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 16].Value);
                    f.cdvCMF18.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 17].Value);
                    f.cdvCMF19.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 18].Value);
                    f.cdvCMF20.Text = MPCF.Trim(spdObj.ActiveSheet.Cells[spdObj.ActiveSheet.ActiveRowIndex, iCmfStartIndex + 19].Value);
                }
                
                if (f.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                }

                if (f.IsDisposed == false) f.Dispose();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void GetInputValue(int i_row)
        {
            FarPoint.Win.Spread.SheetView sheet;

            string s_value_type;
            string s_display_type;
            string s_point_type;
            string s_input_type;
            bool b_require = false;

            sheet = spdData.ActiveSheet;

            s_value_type = MPCF.Trim(sheet.Cells[i_row, (int)Columns.Type].Value);
            s_point_type = MPCF.Trim(sheet.Cells[i_row, (int)Columns.PointType].Value);
            s_display_type = MPCF.Trim(sheet.Cells[i_row, (int)Columns.DisplayType].Value);
            s_input_type = MPCF.Trim(sheet.Cells[i_row, (int)Columns.InputType].Value);

            switch (s_value_type)
            {
                case "Attribute":
                    tabValue.SelectedTab = tbpAttribute;
                    break;
                case "Table-Column":
                    tabValue.SelectedTab = tbpTableColumn;
                    break;
                case "Lot-Extension":
                    tabValue.SelectedTab = tbpLotEx;
                    break;
                case "Tool":
                    tabValue.SelectedTab = tbpTool;
                    break;
            }

            if (tabValue.SelectedTab == tbpAttribute)
            {
                cdvAttrType.Text = MPCF.Trim(sheet.Cells[i_row, (int)Columns.DataType].Value);
                cdvAttrName.Text = MPCF.Trim(sheet.Cells[i_row, (int)Columns.ValueName].Value);
                cdvAttrName.DescText = MPCF.Trim(sheet.Cells[i_row, (int)Columns.DisplayText].Value);

                if (sheet.Cells[i_row, (int)Columns.DisplayText].Font != null && sheet.Cells[i_row, (int)Columns.DisplayText].Font.Bold == true)
                {
                    b_require = true;
                }
                txtBackColor.BackColor = sheet.Cells[i_row, (int)Columns.DisplayText].BackColor;
                txtBackColor.ForeColor = sheet.Cells[i_row, (int)Columns.DisplayText].ForeColor;
            }
            else if(tabValue.SelectedTab == tbpTableColumn || tabValue.SelectedTab == tbpLotEx)
            {
                cdvTable.Text = MPCF.Trim(sheet.Cells[i_row, (int)Columns.DataType].Value);
                cdvColumn.Text = MPCF.Trim(sheet.Cells[i_row, (int)Columns.ValueName].Value);
                txtDisplayText.Text = MPCF.Trim(sheet.Cells[i_row, (int)Columns.DisplayText].Value);
                txtWhere.Text = MPCF.Trim(sheet.Cells[i_row, (int)Columns.DisplayText].Tag);

                if (sheet.Cells[i_row, (int)Columns.DisplayText].Font != null && sheet.Cells[i_row, (int)Columns.DisplayText].Font.Bold == true)
                {
                    b_require = true;
                }
                txtBackColor.BackColor = sheet.Cells[i_row, (int)Columns.DisplayText].BackColor;
                txtBackColor.ForeColor = sheet.Cells[i_row, (int)Columns.DisplayText].ForeColor;
            }
            else if (tabValue.SelectedTab == tbpTool)
            {
                cdvToolType.Text = MPCF.Trim(sheet.Cells[i_row, (int)ColumnsTool.ToolType].Value);
                cdvToolType_SelectedItemChanged(null, null);
                s_selected_tool_type = cdvToolType.Text;

                cdvToolStatus.Text = MPCF.Trim(sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].Value);
                cdvToolEvent.Text = MPCF.Trim(sheet.Cells[i_row, (int)ColumnsTool.ToolEvent].Value);
                cdvToolEvent.DescText = MPCF.Trim(sheet.Cells[i_row, (int)ColumnsTool.ToolEvent].Tag);

                if (sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].Font != null && sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].Font.Bold == true)
                {
                    b_require = true;
                }
                txtBackColor.BackColor = sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].BackColor;
                txtBackColor.ForeColor = sheet.Cells[i_row, (int)ColumnsTool.ToolStatus].ForeColor;
            }

            cboInputValueType.Text = "";
            if (MPCF.Trim(sheet.Cells[i_row, (int)Columns.InputValueType].Value) != "")
            {
                cboInputValueType.Text = MPCF.Trim(sheet.Cells[i_row, (int)Columns.InputValueType].Tag) + " : " + MPCF.Trim(sheet.Cells[i_row, (int)Columns.InputValueType].Value);
            }

            switch (s_display_type)
            {
                case "View":
                    rbtView.Checked = true;
                    break;
                case "Internal Input":
                    rbtInput.Checked = true;
                    break;
                case "User Input":
                    rbtViewInput.Checked = true;
                    break;
            }
            switch (s_display_type)
            {
                case "View":
                    rbtView.Checked = true;
                    break;
                case "Internal Input":
                    rbtInput.Checked = true;
                    break;
                case "User Input":
                    rbtViewInput.Checked = true;
                    break;
            }
            if (tabValue.SelectedTab == tbpLotEx)
            {
                cboPointType.Text = s_point_type;
            }
            else
            {
                switch (s_point_type)
                {
                    case "Start":
                        rbtStart.Checked = true;
                        break;
                    case "AdHoc":
                        rbtAdHoc.Checked = true;
                        break;
                    case "End":
                        rbtEnd.Checked = true;
                        break;
                }
            }
            switch (s_input_type)
            {
                case "Individual":
                    rbtIndividual.Checked = true;
                    break;
                case "At a Time":
                    rbtAtatime.Checked = true;
                    break;
            }
            
            chkRequire.Checked = b_require;
        }

        //
        // UpdateFutureAction()
        //       - Update Future Action
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool UpdateOperInputValueList(char c_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_OPER_INPUT_VALUE_LIST_IN");
            TRSNode out_node = new TRSNode("UPDATE_OPER_INPUT_VALUE_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddChar("REL_LEVEL", udcMFO.SelectLevelChar);
            in_node.AddString("MAT_ID", udcMFO.MatID);
            in_node.AddInt("MAT_VER", udcMFO.MatVersion);
            in_node.AddString("FLOW", udcMFO.Flow);
            in_node.AddString("OPER", udcMFO.Oper);


            if (c_step == MPGC.MP_STEP_CREATE || c_step == MPGC.MP_STEP_UPDATE)
            {
                SetInNode(in_node, spdData);
            }

            if (MPCR.CallService("WIP", "WIP_Update_Operation_Input_Value_List", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);
            return true;

        }

        //
        // ViewSettingDataList()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewSettingDataList()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;

            MPCF.InitListView(udcMFO.GetListView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            sb = new StringBuilder();

            switch (udcMFO.SelectLevel)
            {
                case Miracom.MESCore.Controls.MFOSelectLevel.MFO:
                    sb.Append("SELECT DISTINCT MAT_ID, MAT_VER, FLOW, OPER FROM MWIPOPRINV ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '1' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, FLOW, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.MO:
                    sb.Append("SELECT DISTINCT MAT_ID, MAT_VER, OPER FROM MWIPOPRINV ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '4' ");
                    sb.Append("AND MAT_ID <> ' ' AND MAT_VER > 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY MAT_ID, MAT_VER, OPER ");
                    sb.Append("ORDER BY MAT_ID ASC, MAT_VER DESC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.FO:
                    sb.Append("SELECT DISTINCT FLOW, OPER FROM MWIPOPRINV ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '2' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW <> ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY FLOW, OPER ");
                    sb.Append("ORDER BY FLOW ASC, OPER ASC");
                    break;

                case Miracom.MESCore.Controls.MFOSelectLevel.O:
                    sb.Append("SELECT DISTINCT OPER FROM MWIPOPRINV ");
                    sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND REL_LEVEL = '3' ");
                    sb.Append("AND MAT_ID = ' ' AND MAT_VER = 0 AND FLOW = ' ' AND OPER <> ' ' ");
                    sb.Append("GROUP BY OPER ");
                    sb.Append("ORDER BY OPER ASC");
                    break;

            }

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(udcMFO.GetListView, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (in_node.GetInt("NEXT_ROW") > 0);

            lblDataCount.Text = udcMFO.GetListView.Items.Count.ToString();

            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.udcMFO;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        private void SetPointType()
        {
            h_point_type = new Dictionary<string, char>();
            h_point_type.Add("AdHoc", 'A');
            h_point_type.Add("Create", 'C');
            h_point_type.Add("Start", 'S');
            h_point_type.Add("End", 'E');
            h_point_type.Add("Ship", 'I');
            h_point_type.Add("Receive", 'V');
            h_point_type.Add("Hold", 'H');
            h_point_type.Add("Release", 'R');
            h_point_type.Add("Split", 'P');
            h_point_type.Add("Merge", 'M');
            h_point_type.Add("Combine", 'B');
            h_point_type.Add("Loss", 'L');
            h_point_type.Add("Move", 'O');
            h_point_type.Add("Rework", 'W');
            h_point_type.Add("Skip", 'K');
            h_point_type.Add("Lot EDC", 'D');
        }

        private void VisiblePointType(bool b_is_lotex)
        {
            cboPointType.Visible = b_is_lotex;
            rbtAdHoc.Visible = !b_is_lotex;
            rbtStart.Visible = !b_is_lotex;
            rbtEnd.Visible = !b_is_lotex;
        }

        #endregion

        private void frmWIPSetupInputAttributeRelation_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdData);

                SetLotCmfPrompt(spdData, (int)Columns.Cmf);

                tabValue_SelectedIndexChanged(null, null);

                SetPointType();
                b_load_flag = true;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(udcMFO.GetListView, this.Text, "");
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            udcMFO.RefreshSelectedList();
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            udcMFO.GetNext(txtFind.Text);
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && MPCF.Trim(txtFind.Text) != "")
            {
                btnNext_Click(null, null);
            }
        }

        private void udcMFO_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.SelectedNode.GetNodeCount(false));
        }

        private void udcMFO_AfterGetTree(object sender, EventArgs e)
        {
            lblDataCount.Text = MPCF.Trim(udcMFO.GetTreeView.GetNodeCount(false));
        }

        private void udcMFO_GetOnlySetData(object sender, EventArgs e)
        {
            ViewSettingDataList();
        }

        // 선택 Level의 말단 노드가 선택되었을 때
        private void udcMFO_LevelItemSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            ViewOperInputValueList();
        }

        private void udcMFO_SetDataSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewOperInputValueList();
        }

        private void cdvAttrType_ButtonPress(object sender, EventArgs e)
        {
            cdvAttrType.Init();
            MPCF.InitListView(cdvAttrType.GetListView);
            cdvAttrType.Columns.Add("Type", 150, HorizontalAlignment.Left);
            cdvAttrType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAttrType.GetListView, '1', MPGC.MP_ATTR_TYPE_TABLE);
        }

        private void cdvAttrType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvAttrType.Text) != "")
            {
                cdvAttrName.Text = "";
            }
        }

        private void cdvAttrName_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false) return;

            cdvAttrName.Init();
            MPCF.InitListView(cdvAttrName.GetListView);
            cdvAttrName.Columns.Add("Attribute Seq", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Name", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Attribute Desc", 200, HorizontalAlignment.Left);
            cdvAttrName.SelectedSubItemIndex = 1;
            cdvAttrName.SelectedDescIndex = 2;

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("LIST_IN");
            TRSNode out_node = new TRSNode("LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", cdvAttrType.Text);

            try
            {
                do
                {
                    if (MPCR.CallService("BAS", "BAS_View_Attribute_Name_List", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetInt("ATTR_SEQ").ToString(), (int)SMALLICON_INDEX.IDX_KEY);
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("ATTR_NAME")));
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("ATTR_DESC")));
                        cdvAttrName.Items.Add(itmX);
                    }

                    in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                    in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

                } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvTable_ButtonPress(object sender, EventArgs e)
        {
            cdvTable.Init();
            MPCF.InitListView(cdvTable.GetListView);
            cdvTable.Columns.Add("Table", 150, HorizontalAlignment.Left);
            cdvTable.SelectedSubItemIndex = 0;

            if (tabValue.SelectedTab == tbpLotEx)
                BASLIST.ViewGCMTableList(cdvTable.GetListView, '1');
            else
                ViewTableList(cdvTable.GetListView);
        }

        private void cdvTable_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvTable.Text) != "" && tabValue.SelectedTab != tbpLotEx)
            {
                cdvColumn.Text = "";
                txtDisplayText.Text = "";
                txtWhere.Text = "";
            }
        }

        private void cdvColumn_ButtonPress(object sender, EventArgs e)
        {
            cdvColumn.Init();
            MPCF.InitListView(cdvColumn.GetListView);
            cdvColumn.Columns.Add("Column", 150, HorizontalAlignment.Left);
            cdvColumn.SelectedSubItemIndex = 0;

            if (tabValue.SelectedTab == tbpTableColumn)
                ViewTableColumnList(cdvColumn.GetListView, cdvTable.Text);
            else
                ViewTableColumnList(cdvColumn.GetListView, "MWIPELTSTS");
        }

        private void cdvColumn_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvColumn.Text) != "")
            {
                txtDisplayText.Text = "";
                txtWhere.Text = "";
            }
        }

        private void txtWhere_Leave(object sender, EventArgs e)
        {
            ChangeSQLSyntaxColor();
        }

        private void txtBackColor_Click(object sender, EventArgs e)
        {
            if (cdgBackColor.ShowDialog(this) == DialogResult.Cancel) return;

            txtBackColor.BackColor = cdgBackColor.Color;
            if (txtBackColor.BackColor.GetBrightness() < 0.5)
            {
                txtBackColor.ForeColor = Color.White;
            }
            else
            {
                txtBackColor.ForeColor = Color.Black;
            }
        }

        //private void txtBackColor_Click(object sender, EventArgs e)
        //{
        //    if (cdgBackColor.ShowDialog(this) == DialogResult.Cancel) return;

        //    txtBackColor.BackColor = cdgBackColor.Color;
        //    if (txtBackColor.BackColor.GetBrightness() < 0.5)
        //    {
        //        txtBackColor.ForeColor = Color.White;
        //    }
        //    else
        //    {
        //        txtBackColor.ForeColor = Color.Black;
        //    }
        //}

        private void cdvToolType_ButtonPress(object sender, EventArgs e)
        {
            s_selected_tool_type = "";

            cdvToolType.Init();
            MPCF.InitListView(cdvToolType.GetListView);
            cdvToolType.Columns.Add("Tool Type", 50, HorizontalAlignment.Left);
            cdvToolType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolType.SelectedSubItemIndex = 0;

            RASLIST.ViewToolTypeList(cdvToolType.GetListView, '2', 'N', 'N', udcMFO.SelectLevelChar, udcMFO.MatID, udcMFO.MatVersion, udcMFO.Flow, udcMFO.Oper, null);
        }

        private void cdvToolType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvToolType.Text) != "" && MPCF.Trim(cdvToolType.Text) != s_selected_tool_type)
            {
                cdvToolStatus.Text = "";
                cdvToolEvent.Text = "";

                cdvToolStatus.Init();
                MPCF.InitListView(cdvToolStatus.GetListView);
                cdvToolStatus.Columns.Add("Tool Status", 50, HorizontalAlignment.Left);
                cdvToolStatus.SelectedSubItemIndex = 0;

                ViewToolType(cdvToolStatus.GetListView);
            }
        }

        private void cdvToolEvent_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvToolType, 1) == false) return;

            cdvToolEvent.Init();
            MPCF.InitListView(cdvToolEvent.GetListView);
            cdvToolEvent.Columns.Add("Tool Event", 50, HorizontalAlignment.Left);
            cdvToolEvent.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolEvent.SelectedSubItemIndex = 0;
            cdvToolEvent.SelectedDescIndex = 1;
            RASLIST.ViewToolEventList(cdvToolEvent.GetListView, '1', MPCF.Trim(cdvToolType.Text), 'N', null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ApplyInputValue('A', -1);
            arrInputOperCMF.Clear();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (spdData.ActiveSheet.SelectionCount < 1) return;
            ApplyInputValue('M', spdData.ActiveSheet.ActiveRowIndex);
            arrInputOperCMF.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.Model.CellRange[] cr;
            int i;

            if (spdData.ActiveSheet.SelectionCount < 1) return;

            cr = spdData.ActiveSheet.GetSelections();

            for (i = cr.Length - 1; i >= 0; i--)
            {
                spdData.ActiveSheet.Rows[cr[i].Row].Remove();
            }
        }

        private void spdData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == true) return;
            if (e.RowHeader == true) return;

            GetInputValue(e.Row);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int i;
            FarPoint.Win.Spread.Model.CellRange[] cr;
            FarPoint.Win.Spread.SheetView sheet;

            sheet = spdData.ActiveSheet;

            if (sheet.SelectionCount < 1) return;

            cr = sheet.GetSelections();

            for (i = 0; i < cr.Length; i++)
            {
                if (cr[i].Row > 0)
                {
                    sheet.MoveRow(cr[i].Row, cr[i].Row - 1, true);
                }
            }

            for (i = 0; i < cr.Length; i++)
            {
                if (cr[i].Row > 0)
                {
                    sheet.AddSelection(cr[i].Row - 1, 0, 1, 1);
                    sheet.RemoveSelection(cr[i].Row, 0, 1, 1);
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int i;
            FarPoint.Win.Spread.Model.CellRange[] cr;
            FarPoint.Win.Spread.SheetView sheet;

            sheet = spdData.ActiveSheet; 

            if (sheet.SelectionCount < 1) return;

            cr = sheet.GetSelections();

            for (i = cr.Length - 1; i >= 0; i--)
            {
                if (cr[i].Row < sheet.RowCount - 1)
                {
                    sheet.MoveRow(cr[i].Row, cr[i].Row + 1, true);
                }
            }

            for (i = cr.Length - 1; i >= 0; i--)
            {
                if (cr[i].Row < sheet.RowCount - 1)
                {
                    sheet.AddSelection(cr[i].Row + 1, 0, 1, 1);
                    sheet.RemoveSelection(cr[i].Row, 0, 1, 1);
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckCondition("CREATE") == true)
            {
                UpdateOperInputValueList(MPGC.MP_STEP_CREATE);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckCondition("UPDATE") == true)
            {
                UpdateOperInputValueList(MPGC.MP_STEP_UPDATE);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckCondition("DELETE") == true)
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;

                if (UpdateOperInputValueList(MPGC.MP_STEP_DELETE) == false) return;

                ViewOperInputValueList();
            }
        }

        private void rbtView_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtView.Checked == true)
            {
                cboInputValueType.Text = "";
                cboInputValueType.Enabled = false;

                cdvToolEvent.Text = "";
                cdvToolEvent.Enabled = false;
            }
            else
            {
                cboInputValueType.Enabled = true;
                cdvToolEvent.Enabled = true;
            }
        }

        private void btnSetCmf_Click(object sender, EventArgs e)
        {
            SetupInputOperationCMF(spdData, (int)Columns.Cmf);
        }

        private void tabValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabValue.SelectedTab == tbpAttribute)
            {
                cdvTable.Text = "";

                rbtInput.Enabled = true;
                rbtViewInput.Enabled = true;

                VisiblePointType(false);
            }
            else if (tabValue.SelectedTab == tbpTableColumn)
            {
                lblTableName.Visible = true;
                cdvTable.Enabled = true;
                cdvTable.Visible = true;
                cdvTable.Text = "";

                cdvColumn.Text = "";
                lblWhere.Visible = true;
                txtWhere.Visible = true;
                txtWhere.Text = "";
                lblWhereComment.Visible = true;

                rbtView.Checked = true;
                rbtInput.Checked = false;
                rbtViewInput.Checked = false;
                rbtInput.Enabled = false;
                rbtViewInput.Enabled = false;

                VisiblePointType(false);

                grpTableValue.Parent = tbpTableColumn;
            }
            else if(tabValue.SelectedTab == tbpLotEx)
            {
                lblTableName.Visible = false;
                cdvTable.Enabled = false;
                cdvTable.Visible = false;
                cdvTable.Text = "";

                cdvColumn.Text = "";
                lblWhere.Visible = false;
                txtWhere.Visible = false;
                txtWhere.Text = "";
                lblWhereComment.Visible = false;

                rbtView.Checked = true;
                rbtInput.Checked = false;
                rbtViewInput.Checked = false;
                rbtInput.Enabled = true;
                rbtViewInput.Enabled = true;

                VisiblePointType(true);

                rbtAdHoc.Checked = false;
                rbtStart.Checked = false;
                rbtEnd.Checked = false;

                grpTableValue.Parent = tbpLotEx;
            }
            else if (tabValue.SelectedTab == tbpTool)
            {
                cdvTable.Text = "";

                rbtInput.Enabled = true;
                rbtViewInput.Enabled = true;

                VisiblePointType(false);
            }

            if (tabValue.SelectedTab == tbpTool)
            {
                spdData_Sheet1.Columns[(int)ColumnsTool.Type].Label = MPCF.FindLanguage("Type", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)ColumnsTool.ToolType].Label = MPCF.FindLanguage("Tool Type", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)ColumnsTool.ToolStatus].Label = MPCF.FindLanguage("Tool Status", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)ColumnsTool.ToolEvent].Label = MPCF.FindLanguage("Tool Event", CAPTION_TYPE.LABEL);

                //입력포인트, 출력종류, 입력종류, 툴 상태
                spdData_Sheet1.Columns[(int)ColumnsTool.PointType].Label = MPCF.FindLanguage("Point Type", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)ColumnsTool.DisplayType].Label = MPCF.FindLanguage("Display Type", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)ColumnsTool.InputType].Label = MPCF.FindLanguage("Input Type", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)ColumnsTool.InputValueType].Label = MPCF.FindLanguage("Value Type", CAPTION_TYPE.LABEL);
            }
            else
            {
                //입력포인트, 출력종류, 입력종류, ""
                //점수,알람표시,입력,값의 형태....
                spdData_Sheet1.Columns[(int)Columns.Type].Label = MPCF.FindLanguage("Type", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)Columns.DataType].Label = MPCF.FindLanguage("Data Type", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)Columns.ValueName].Label = MPCF.FindLanguage("Value Name", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)Columns.DisplayText].Label = MPCF.FindLanguage("Display Text", CAPTION_TYPE.LABEL);

                spdData_Sheet1.Columns[(int)Columns.PointType].Label = MPCF.FindLanguage("Point Type", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)Columns.DisplayType].Label = MPCF.FindLanguage("Display Type", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)Columns.InputType].Label = MPCF.FindLanguage("Input Type", CAPTION_TYPE.LABEL);
                spdData_Sheet1.Columns[(int)ColumnsTool.InputValueType].Label = MPCF.FindLanguage("Value Type", CAPTION_TYPE.LABEL);
            }
        }              
    }
}
