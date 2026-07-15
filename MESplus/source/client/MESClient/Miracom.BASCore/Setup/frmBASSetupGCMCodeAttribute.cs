//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupGCMCodeAttribute.cs
//   Description : Master Code Setup
//
//   MES Version : 5.2.0.0
//
//   Function List
//       - CheckCondition() : Check Create/Update/Delete condition
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-05-07 : Created by Aiden Koo
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//Imports

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.BASCore
{
    public partial class frmBASSetupGCMCodeAttribute : Miracom.MESCore.SetupForm02
    {
        public frmBASSetupGCMCodeAttribute()
        {
            InitializeComponent();
        }


        #region " Constant Definition "

        private const int MAX_VALUE_COUNT = 500;
        
        #endregion

        #region "VariableDefinition"

        private bool b_load_flag;

        #endregion

        #region " Function Definition "

        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String		: Create/Update/Delete 援щ텇??
        //
        private bool CheckCondition()
        {
            if (MPCF.CheckValue(cdvGCMTable, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvCode, 1) == false)
            {
                return false;
            }

            return true;

        }

        private bool UpdateCode(char ProcStep, bool bShowSuccessMessage)
        {

            TRSNode in_node = new TRSNode("UPDATE_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                if (chkCentralFactory.Checked == true)
                {
                    in_node.Factory = MPGV.gsCentralFactory;
                }
                in_node.AddString("TABLE_NAME", MPCF.Trim(cdvGCMTable.Text));

                node = in_node.AddNode("DATA_LIST");

                node.AddString("KEY_1", MPCF.Trim(cdvCode.Text));
                node.AddString("DATA_1", MPCF.Trim(txtDesc1.Text));
                node.AddString("DATA_2", MPCF.Trim(txtDesc2.Text));

                if (MPCR.CallService("BAS", "BAS_Update_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (bShowSuccessMessage == true)
                {
                    MPCR.ShowSuccessMsg(out_node);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        //
        // UpdateAttributeValue()
        //       - Change Attribute Value information
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool UpdateAttributeValue()
        {
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item = null;
            int i, iStart, iCount;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPCF.Trim(cdvGCMTable.Text));
            in_node.AddString("ATTR_KEY", MPCF.Trim(cdvCode.Text));

            iStart = 0;
            iCount = spdAttrValue.ActiveSheet.RowCount;

            try
            {
                do
                {
                    if (iCount > MAX_VALUE_COUNT)
                        iCount = MAX_VALUE_COUNT;

                    for (i = iStart; i < iCount + iStart; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i, 0].Value != null && (bool)spdAttrValue.ActiveSheet.Cells[i, 0].Value == true)
                        {
                            if (spdAttrValue.ActiveSheet.Cells[i, 6].Value != null && (bool)spdAttrValue.ActiveSheet.Cells[i, 6].Value == true)
                            {
                                list_item = in_node.AddNode("VALUE_LIST");

                                list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                list_item.AddChar("NULL_FLAG", 'Y');
                                list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));

                                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 7].Value) == "Y")
                                {
                                    //Array Type
                                    string s_attr_name = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value);
                                    while (i < spdAttrValue.ActiveSheet.RowCount)
                                    {
                                        if (s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value)) break;
                                        i++;
                                    }
                                    i--;
                                }
                            }
                            else
                            {
                                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 7].Value) == "Y")
                                {
                                    //Array Type 일경우  병합해서 전송함
                                    string s_attr_name = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value);
                                    string s_separator = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 8].Value);
                                    string s_attr_value = "";
                                    int i_last_active_hist_seq = MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag);
                                    int i_array_value_count = 0;

                                    while (i < spdAttrValue.ActiveSheet.RowCount)
                                    {
                                        if (s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value)) break;

                                        if (i_array_value_count < 1)
                                        {
                                            if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                            {
                                                s_attr_value = MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                            }
                                            else
                                            {
                                                s_attr_value = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value);
                                            }
                                        }
                                        else
                                        {
                                            if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 3].Value) == "" &&
                                                MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value) == "" &&
                                                (i + 1 == spdAttrValue.ActiveSheet.RowCount ||
                                                 s_attr_name != MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i + 1, 1].Value)))
                                            {
                                                ; // 위 조건일때 제외
                                            }
                                            else
                                            {
                                                if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                                {
                                                    s_attr_value = s_attr_value + s_separator + MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                                }
                                                else
                                                {
                                                    s_attr_value = s_attr_value + s_separator + MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value);
                                                }
                                            }
                                        }

                                        i++;
                                        i_array_value_count++;
                                    }
                                    i--;

                                    list_item = in_node.AddNode("VALUE_LIST");

                                    list_item.AddString("ATTR_NAME", s_attr_name);
                                    list_item.AddString("ATTR_VALUE", s_attr_value);
                                    list_item.AddInt("LAST_ACTIVE_HIST_SEQ", i_last_active_hist_seq);
                                }
                                else //기존 저장 로직 부분
                                {
                                    if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.TextCellType == true)
                                    { //Add by J.S. 2011.04.11 Ascii Type인 경우 어떠한 변환도 없이 처리 해야 한다.
                                        list_item = in_node.AddNode("VALUE_LIST");

                                        list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                        list_item.AddString("ATTR_VALUE", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 4].Value));
                                        list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));
                                    }
                                    else if (spdAttrValue.ActiveSheet.Cells[i, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                                    {
                                        list_item = in_node.AddNode("VALUE_LIST");

                                        list_item.AddString("ATTR_NAME", MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i, 1].Value));
                                        list_item.AddString("ATTR_VALUE", MPCF.Trim(MPCF.ToRegionNumber(spdAttrValue.ActiveSheet.Cells[i, 4].Value)));
                                        list_item.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdAttrValue.ActiveSheet.Cells[i, 1].Tag));
                                    }
                                }
                            }
                        }
                    }


                    if (MPCR.CallService("BAS", "BAS_Update_Attribute_Value", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    if (spdAttrValue.ActiveSheet.RowCount - (iCount + iStart) > 0)
                    {
                        iStart += iCount;
                        iCount = spdAttrValue.ActiveSheet.RowCount - iCount;
                    }
                    else
                    {
                        iStart = 0;
                        iCount = 0;
                    }

                } while (iStart != 0 || iCount != 0);

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool ViewTable()
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");
            TRSNode out_node = new TRSNode("VIEW_TABLE_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                if (chkCentralFactory.Checked == true)
                {
                    in_node.Factory = MPGV.gsCentralFactory;
                }
                in_node.AddString("TABLE_NAME", cdvGCMTable.Text);

                if (MPCR.CallService("BAS", "BAS_View_Table", in_node, ref out_node) == false)
                {
                    return false;
                }

                colCode.Text = out_node.GetString("KEY_1_PRT");
                lblCode.Text = out_node.GetString("KEY_1_PRT");

                lblCodeDesc1.Visible = false;
                txtDesc1.Visible = false;
                txtDesc1.Text = "";
                lblCodeDesc2.Visible = false;
                txtDesc2.Visible = false;
                txtDesc2.Text = "";

                if (MPCF.Trim(out_node.GetString("DATA_1_PRT")) != "")
                {
                    colDesc.Text = out_node.GetString("DATA_1_PRT");
                    lblCodeDesc1.Text = out_node.GetString("DATA_1_PRT");

                    lblCodeDesc1.Visible = true;
                    txtDesc1.Visible = true;
                }
                if (MPCF.Trim(out_node.GetString("DATA_2_PRT")) != "")
                {
                    lblCodeDesc2.Text = out_node.GetString("DATA_2_PRT");

                    lblCodeDesc2.Visible = true;
                    txtDesc2.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool ViewCode()
        {

            TRSNode in_node = new TRSNode("VIEW_DATA_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (chkCentralFactory.Checked == true)
            {
                in_node.Factory = MPGV.gsCentralFactory;
            }
            in_node.AddString("TABLE_NAME", cdvGCMTable.Text);
            in_node.AddString("KEY_1", cdvCode.Text);


            if (MPCR.CallService("BAS", "BAS_View_Data", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvCode.Tag = cdvCode.Text;

            if (txtDesc1.Visible == true)
            {
                txtDesc1.Text = out_node.GetString("DATA_1");
                txtDesc1.Tag = out_node.GetString("DATA_1");
            }

            if (txtDesc2.Visible == true)
            {
                txtDesc2.Text = out_node.GetString("DATA_2");
                txtDesc2.Tag = out_node.GetString("DATA_2");
            }

            txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
            txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
            txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

            return true;
        }

        private bool ViewAttributeValue()
        {
            int i, i_row = 0;
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("ATTR_OUT");
            List<TRSNode> value_list;

            MPCF.ClearList(spdAttrValue, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPCF.Trim(cdvGCMTable.Text));
            in_node.AddString("ATTR_KEY", MPCF.Trim(cdvCode.Text));
            in_node.AddInt("ATTR_FROM", 0);
            in_node.AddInt("ATTR_TO", int.MaxValue);


            try
            {
                do
                {
                    if (MPCR.CallService("BAS", "BAS_View_Attribute_Value_Brief", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    value_list = out_node.GetList("VALUE_LIST");
                    for (i = 0; i < value_list.Count; i++)
                    { 
                        /** Array Type 일 경우 Row 추가 부분 변경 **/
                        /** End of  2012-11-15   **/
                        if (value_list[i].GetChar("ARRAY_TYPE_FLAG") == 'Y')
                        {
                            string[] sa_attr_values = value_list[i].GetString("ATTR_VALUE").Split(value_list[i].GetChar("ARRAY_SEPARATOR"));
                            for (int i_cnt = 0; i_cnt < sa_attr_values.Length; i_cnt++)
                            {
                                /* ROW 추가 */
                                i_row = spdAttrValue.ActiveSheet.RowCount;
                                spdAttrValue.ActiveSheet.RowCount++;

                                /** 값 설정  **/
                                spdAttrValue.ActiveSheet.Cells[i_row, 1].Value = value_list[i].GetString("ATTR_NAME");
                                spdAttrValue.ActiveSheet.Cells[i_row, 2].Value = value_list[i].GetString("ATTR_DESC");
                                spdAttrValue.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetInt("LAST_ACTIVE_HIST_SEQ");
                                spdAttrValue.ActiveSheet.Cells[i_row, 4].Tag = value_list[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG");

                                spdAttrValue.ActiveSheet.Cells[i_row, 7].Value = value_list[i].GetChar("ARRAY_TYPE_FLAG");
                                spdAttrValue.ActiveSheet.Cells[i_row, 8].Value = value_list[i].GetChar("ARRAY_SEPARATOR");
                                spdAttrValue.ActiveSheet.Cells[i_row, 9].Value = value_list[i].GetChar("ATTR_FMT");
                                spdAttrValue.ActiveSheet.Cells[i_row, 10].Value = value_list[i].GetInt("ATTR_SIZE");
                                spdAttrValue.ActiveSheet.Cells[i_row, 11].Value = value_list[i].GetString("VALID_TBL");
                                spdAttrValue.ActiveSheet.Cells[i_row, 12].Value = value_list[i].GetChar("VALID_TBL_TYPE");
                                spdAttrValue.ActiveSheet.Cells[i_row, 13].Value = value_list[i].GetChar("ALLOW_BLANK");
                                
                                spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = sa_attr_values[i_cnt];
                                spdAttrValue.ActiveSheet.Cells[i_row, 4].Value = sa_attr_values[i_cnt];

                                if(i_cnt > 0)
                                {
                                    spdAttrValue.ActiveSheet.Cells[i_row, 6].Locked = true;
                                }

                                /* Cell 타입 지정 */
                                SetCellTypeByAttribute(value_list[i], spdAttrValue.ActiveSheet.Cells[i_row, 4]);

                                if (value_list[i].GetChar("NULL_FLAG") == 'Y')
                                {
                                    spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = "[Null]";
                                }
                            }
                            if (value_list[i].GetChar("NULL_FLAG") == 'Y' || (sa_attr_values.Length == 1 && sa_attr_values[0] == ""))
                            {
                                ;
                            }
                            else
                            {
                                AddArrayTypeRow(i_row, false);
                            }
                        }
                        else
                        {
                            /* ROW 추가 */
                            i_row = spdAttrValue.ActiveSheet.RowCount;
                            spdAttrValue.ActiveSheet.RowCount++;

                            /** 값 설정  **/
                            spdAttrValue.ActiveSheet.Cells[i_row, 1].Value = value_list[i].GetString("ATTR_NAME");
                            spdAttrValue.ActiveSheet.Cells[i_row, 2].Value = value_list[i].GetString("ATTR_DESC");
                            spdAttrValue.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetInt("LAST_ACTIVE_HIST_SEQ");
                            spdAttrValue.ActiveSheet.Cells[i_row, 4].Tag = value_list[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG");

                            spdAttrValue.ActiveSheet.Cells[i_row, 7].Value = value_list[i].GetChar("ARRAY_TYPE_FLAG");
                            spdAttrValue.ActiveSheet.Cells[i_row, 8].Value = value_list[i].GetChar("ARRAY_SEPARATOR");
                            spdAttrValue.ActiveSheet.Cells[i_row, 9].Value = value_list[i].GetChar("ATTR_FMT");
                            spdAttrValue.ActiveSheet.Cells[i_row, 10].Value = value_list[i].GetInt("ATTR_SIZE");
                            spdAttrValue.ActiveSheet.Cells[i_row, 11].Value = value_list[i].GetString("VALID_TBL");
                            spdAttrValue.ActiveSheet.Cells[i_row, 12].Value = value_list[i].GetChar("VALID_TBL_TYPE");
                            spdAttrValue.ActiveSheet.Cells[i_row, 13].Value = value_list[i].GetChar("ALLOW_BLANK");

                            /* Cell 타입 지정 */
                            SetCellTypeByAttribute(value_list[i], spdAttrValue.ActiveSheet.Cells[i_row, 4]);

                            if (value_list[i].GetChar("LONG_LENGTH_ATTR_VALUE_FLAG") == 'Y')
                            {
                                string value = value_list[i].GetString("ATTR_VALUE");
                                value_list[i].SetString("ATTR_VALUE", value += " ...");
                            }

                            if (value_list[i].GetChar("NULL_FLAG") == 'Y')
                            {
                                spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = "[Null]";
                            }
                            else
                            {
                                spdAttrValue.ActiveSheet.Cells[i_row, 3].Value = value_list[i].GetString("ATTR_VALUE");
                            }

                            spdAttrValue.ActiveSheet.Rows[i_row].Height = spdAttrValue.ActiveSheet.GetPreferredRowHeight(i_row);
                        }
                    }

                    in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                    in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

                } while (in_node.GetString("NEXT_ATTR_NAME") != "" || in_node.GetInt("NEXT_ATTR_SEQ") > 0);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }
        
        private void SetCellTypeByAttribute(TRSNode out_node, FarPoint.Win.Spread.Cell cell)
        {
            FarPoint.Win.Spread.CellType.TextCellType txtCell;
            FarPoint.Win.Spread.CellType.NumberCellType numCell;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;
            CultureInfo ci_local = CultureInfo.CurrentCulture;

            int i_row = cell.Row.Index;

            switch (out_node.GetChar("ATTR_FMT"))
            {
                case 'A':
                    txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                    txtCell.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Ascii;
                    txtCell.MaxLength = out_node.GetInt("ATTR_SIZE");
                    txtCell.WordWrap = true;

                    cell.CellType = txtCell;
                    break;
                case 'N':
                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numCell.DecimalPlaces = 0;
                    {
                        string s_max_value = "";
                        double d_max_value = 0;
                        for (int i = 0; i < out_node.GetInt("ATTR_SIZE"); i++)
                        {
                            s_max_value += "9";
                        }
                        d_max_value = MPCF.ToDbl(s_max_value);
                        numCell.MaximumValue = d_max_value;
                        numCell.MinimumValue = d_max_value * -1;
                    }
                    numCell.Separator = ci_local.NumberFormat.NumberGroupSeparator;

                    cell.CellType = numCell;
                    break;
                case 'F':
                    numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                    numCell.DecimalPlaces = 3;
                    {
                        string s_max_value = "";
                        double d_max_value = 0;
                        for (int i = 0; i < out_node.GetInt("ATTR_SIZE"); i++)
                        {
                            s_max_value += "9";
                        }
                        d_max_value = MPCF.ToDbl(s_max_value);
                        numCell.MaximumValue = d_max_value;
                        numCell.MinimumValue = d_max_value * -1;
                    }
                    numCell.Separator = ci_local.NumberFormat.NumberGroupSeparator;
                    numCell.DecimalSeparator = ci_local.NumberFormat.NumberDecimalSeparator;

                    cell.CellType = numCell;
                    break;
            }

            if (out_node.GetString("VALID_TBL") == "")
            {
                spdAttrValue.ActiveSheet.AddSpanCell(i_row, 4, 1, 2);
            }
            else
            {
                // Cell 타입 지정
                if (out_node.GetChar("VALID_TBL_TYPE") == 'A' || out_node.GetChar("VALID_TBL_TYPE") == 'Q')
                {
                    btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    btnCell.Text = "...";
                    spdAttrValue.ActiveSheet.Cells[i_row, 5].CellType = btnCell;
                    spdAttrValue.ActiveSheet.Cells[i_row, 5].Tag = out_node.GetString("VALID_TBL");
                }
                else
                {
                    spdAttrValue.ActiveSheet.AddSpanCell(i_row, 4, 1, 2);
                }

                if (out_node.GetChar("ALLOW_BLANK") == 'Y')
                    spdAttrValue.ActiveSheet.Cells[i_row, 3].Tag = 'Y';
            }
        }

        private void SetCellTypeByAttribute(FarPoint.Win.Spread.SheetView spdView, FarPoint.Win.Spread.Cell cell)
        {
            TRSNode a_node;
            int i_row = cell.Row.Index;

            a_node = new TRSNode("Cell Format");
            a_node.AddChar("ATTR_FMT", MPCF.ToChar(spdView.Cells[cell.Row.Index, 9].Value));
            a_node.AddInt("ATTR_SIZE", MPCF.ToInt(spdView.Cells[cell.Row.Index, 10].Value));
            a_node.AddString("VALID_TBL", MPCF.Trim(spdView.Cells[cell.Row.Index, 11].Value));
            a_node.AddChar("VALID_TBL_TYPE", MPCF.ToChar(spdView.Cells[cell.Row.Index, 12].Value));
            a_node.AddChar("ALLOW_BLANK", MPCF.ToChar(spdView.Cells[cell.Row.Index, 13].Value));

            SetCellTypeByAttribute(a_node, cell);
        }

        private void AddArrayTypeRow(int i_row, bool b_update_check)
        {
            bool b_insert_row;
            try
            {
                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i_row, 7].Value) != "Y") return;

                b_insert_row = false;
                if (i_row + 1 < spdAttrValue.ActiveSheet.RowCount)
                {
                    if (spdAttrValue.ActiveSheet.Cells[i_row, 1].Value != spdAttrValue.ActiveSheet.Cells[i_row + 1, 1].Value)
                    {
                        b_insert_row = true;
                        //신규 Row 추가
                        spdAttrValue.ActiveSheet.Rows.Add(i_row + 1, 1);
                    }
                }
                else if (i_row + 1 == spdAttrValue.ActiveSheet.RowCount)
                {
                    b_insert_row = true;
                    //신규 Row 추가
                    spdAttrValue.ActiveSheet.RowCount++;
                }

                if (b_insert_row == true)
                {
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 1].Value = spdAttrValue.ActiveSheet.Cells[i_row, 1].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 2].Value = spdAttrValue.ActiveSheet.Cells[i_row, 2].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 1].Tag = spdAttrValue.ActiveSheet.Cells[i_row, 1].Tag;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 4].Tag = spdAttrValue.ActiveSheet.Cells[i_row, 4].Tag;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 7].Value = spdAttrValue.ActiveSheet.Cells[i_row, 7].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 8].Value = spdAttrValue.ActiveSheet.Cells[i_row, 8].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 9].Value = spdAttrValue.ActiveSheet.Cells[i_row, 9].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 10].Value = spdAttrValue.ActiveSheet.Cells[i_row, 10].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 11].Value = spdAttrValue.ActiveSheet.Cells[i_row, 11].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 12].Value = spdAttrValue.ActiveSheet.Cells[i_row, 12].Value;
                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 13].Value = spdAttrValue.ActiveSheet.Cells[i_row, 13].Value;

                    spdAttrValue.ActiveSheet.Cells[i_row + 1, 6].Locked = true; // Null Flag

                    SetCellTypeByAttribute(spdAttrValue.ActiveSheet, spdAttrValue.ActiveSheet.Cells[i_row + 1, 4]);
                }

                if (b_update_check == true)
                {
                    //Row 삽입시 이전 이후 체크박스 체크 처리
                    for (int i = i_row; i >= 0; i--)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i, 1].Value != spdAttrValue.ActiveSheet.Cells[i_row, 1].Value) break;
                        spdAttrValue.ActiveSheet.Cells[i, 0].Value = true;
                    }

                    for (int i = i_row + 1; i < spdAttrValue.ActiveSheet.RowCount -1; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i +1, 1].Value != spdAttrValue.ActiveSheet.Cells[i_row, 1].Value) break;
                        spdAttrValue.ActiveSheet.Cells[i, 0].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.cdvCode;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }


        #endregion

        private void frmBASSetupGCMCodeAttribute_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.InitListView(lisCodeList);
                MPCF.FieldClear(this);

                spdAttrValue.ActiveSheet.Columns[7].Visible = false;
                spdAttrValue.ActiveSheet.Columns[8].Visible = false;
                spdAttrValue.ActiveSheet.Columns[9].Visible = false;
                spdAttrValue.ActiveSheet.Columns[10].Visible = false;
                spdAttrValue.ActiveSheet.Columns[11].Visible = false;
                spdAttrValue.ActiveSheet.Columns[12].Visible = false;
                spdAttrValue.ActiveSheet.Columns[13].Visible = false;

                b_load_flag = true;
            }
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisCodeList, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisCodeList, txtFind.Text, 0, true, false);
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                cdvCode.Tag = "";
                txtDesc1.Tag = "";
                txtDesc2.Tag = "";
                lblDataCount.Text = "";

                if (BASLIST.ViewGCMDataList(lisCodeList, '1', cdvGCMTable.Text, -1, null, (chkCentralFactory.Checked ? MPGV.gsCentralFactory : "")) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisCodeList.Items.Count);
                    if (lisCodeList.Items.Count > 0)
                    {
                        if (MPCF.Trim(cdvCode.Text) == "")
                        {
                            lisCodeList.Items[0].Selected = true;
                        }
                        else
                        {
                            MPCF.FindListItem(lisCodeList, cdvCode.Text, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Mater Code : " + cdvGCMTable.Text;
            MPCF.ExportToExcel(lisCodeList, this.Text, sCond, true, false, false, -1, -1);
        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            bool b_changed = false;

            if (CheckCondition() == false)
            {
                return;
            }

            if (cdvCode.Text != MPCF.Trim(cdvCode.Tag) || txtDesc1.Text != MPCF.Trim(txtDesc1.Tag) || txtDesc2.Text != MPCF.Trim(txtDesc2.Tag))
            {
                if (UpdateCode(MPGC.MP_STEP_UPDATE, false) == false)
                {
                    return;
                }
                b_changed = true;
            }

            int i;
            bool b_checked = false;

            for (i = 0; i < spdAttrValue.ActiveSheet.RowCount; i++)
            {
                if (spdAttrValue.ActiveSheet.Cells[i, 0].Value != null && Convert.ToBoolean(spdAttrValue.ActiveSheet.Cells[i, 0].Value) == true)
                {
                    b_checked = true;
                    break;
                }
            }
            if (b_checked == true)
            {
                if (UpdateAttributeValue() == false)
                {
                    return;
                }
                b_changed = true;
            }

            if (b_changed == true)
            {
                btnRefresh.PerformClick();
            }
        }

        private void cdvTableGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvTableGroup.Init();
            MPCF.InitListView(cdvTableGroup.GetListView);
            cdvTableGroup.Columns.Add("Table Group", 150, HorizontalAlignment.Left);
            cdvTableGroup.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTableGroup.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTableGroup.GetListView, '1', MPGC.MP_GCM_TABLE_GROUP, -1, null, (chkCentralFactory.Checked ? MPGV.gsCentralFactory : ""));
            cdvTableGroup.InsertEmptyRow(0, 1);
        }

        private void cdvTableGroup_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvTableGroup.Text) == "") return;

            cdvGCMTable.Text = "";
            MPCF.InitListView(lisCodeList);
            MPCF.FieldClear(pnlRight);
            MPCF.ClearList(spdAttrValue);
        }

        private void cdvGCMTable_ButtonPress(object sender, EventArgs e)
        {
            cdvGCMTable.Init();
            MPCF.InitListView(cdvGCMTable.GetListView);
            cdvGCMTable.Columns.Add("Table", 150, HorizontalAlignment.Left);
            cdvGCMTable.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvGCMTable.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMTableList(cdvGCMTable.GetListView, '1', ' ', cdvTableGroup.Text, -1, null, (chkCentralFactory.Checked ? MPGV.gsCentralFactory : ""), false, -1, -1, false, false, false);
            cdvGCMTable.InsertEmptyRow(0, 1);
        }

        private void cdvGCMTable_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvGCMTable.Text) == "") return;
            if (ViewTable() == false) return;

            cdvCode.Text = "";
            btnRefresh.PerformClick();
        }

        private void cdvTableData_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = MPCF.Trim(e.SelectedItem.Text);
            spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;
            AddArrayTypeRow(e.Row, true);
        }

        private void lisCodeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisCodeList.SelectedItems.Count != 0)
            {
                cdvCode.Text = lisCodeList.SelectedItems[0].Text;

                if (ViewCode() == false) return;
                if (ViewAttributeValue() == false) return;
            }
            
        }

        private void spdAttrValue_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                if (e.Column == 6)
                {
                    spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;

                    if (Convert.ToBoolean(spdAttrValue.ActiveSheet.Cells[e.Row, 6].Value) == true)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[e.Row, 4].CellType is FarPoint.Win.Spread.CellType.NumberCellType == true)
                        {
                            spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = "";
                            spdAttrValue.ActiveSheet.Cells[e.Row, 4].Locked = false;
                            spdAttrValue.ActiveSheet.Cells[e.Row, 5].Locked = false;
                        }
                        else
                        {
                            spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = "[Null]";
                            spdAttrValue.ActiveSheet.Cells[e.Row, 4].Locked = true;
                            spdAttrValue.ActiveSheet.Cells[e.Row, 5].Locked = true;
                        }
                    }
                    else
                    {
                        spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = "";
                        spdAttrValue.ActiveSheet.Cells[e.Row, 4].Locked = false;
                        spdAttrValue.ActiveSheet.Cells[e.Row, 5].Locked = false;
                    }

                    for (int i = e.Row + 1; i < spdAttrValue.ActiveSheet.RowCount; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i, 1].Value == spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value)
                        {
                            if (i < spdAttrValue.ActiveSheet.RowCount - 1 && spdAttrValue.ActiveSheet.Cells[i + 1, 1].Value == spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value)
                            {
                                spdAttrValue.ActiveSheet.Cells[i, 0].Value = true;
                            }
                            spdAttrValue.ActiveSheet.Cells[i, 4].Value = "";
                            spdAttrValue.ActiveSheet.Cells[i, 4].Locked = spdAttrValue.ActiveSheet.Cells[e.Row, 4].Locked;
                            spdAttrValue.ActiveSheet.Cells[i, 5].Locked = spdAttrValue.ActiveSheet.Cells[e.Row, 5].Locked;
                        }
                    }
                    return;
                }

                cdvTableData.Init();
                cdvTableData.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTableData.GetListView);
                cdvTableData.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTableData.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);

                BASLIST.ViewGCMDataList(cdvTableData.GetListView, '1', MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, e.Column].Tag));

                if (MPCF.ToChar(spdAttrValue.ActiveSheet.Cells[e.Row, 3].Tag) == 'Y')
                    cdvTableData.InsertEmptyRow(0, 1);

                if (cdvTableData.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdAttrValue_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 4)
            {
                spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;
                AddArrayTypeRow(e.Row, true);
            }
        }

        private void spdAttrValue_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            if (e.Column == 4)
            {
                if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 4].Tag) == "Y")
                {
                    frmBASTranAttributeDetail f = new frmBASTranAttributeDetail();
                    /* 2013.06.12. Aiden. AttributeType 과 Key 가 잘못 Assign 된 문제 해결 */
                    f.AttributeType = MPCF.Trim(cdvGCMTable.Text);
                    f.AttributeKey = MPCF.Trim(cdvCode.Text);
                    f.AttributeName = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value);
                    f.AttributeDesc = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 2].Value);
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = f.AttributeValue;
                        spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;
                        spdAttrValue.ActiveSheet.Rows[e.Row].Height = spdAttrValue.ActiveSheet.GetPreferredRowHeight(e.Row);
                    }

                    if (f.IsDisposed == false) f.Dispose();
                }
            }

            if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 7].Value) == "Y" &&
                e.Row != spdAttrValue.ActiveSheet.RowCount - 1 &&
                spdAttrValue.ActiveSheet.Cells[e.Row + 1, 1].Value == spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value)
            {
                MPCR.ChangeControlEnabled(this, btnDelRow, true);
            }
            else
            {
                MPCR.ChangeControlEnabled(this, btnDelRow, false);
            }
        }

        private void spdAttrValue_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Column != 4) return;

            if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 4].Tag) == "Y")
            {
                frmBASTranAttributeDetail f = new frmBASTranAttributeDetail();
                /* 2013.06.12. Aiden. AttributeType 과 Key 가 잘못 Assign 된 문제 해결 */
                f.AttributeType = MPCF.Trim(cdvGCMTable.Text);
                f.AttributeKey = MPCF.Trim(cdvCode.Text);
                f.AttributeName = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value);
                f.AttributeDesc = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 2].Value);
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = f.AttributeValue;
                    spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;
                    spdAttrValue.ActiveSheet.Rows[e.Row].Height = spdAttrValue.ActiveSheet.GetPreferredRowHeight(e.Row);
                }
                spdAttrValue.EditModePermanent = false;

                if (f.IsDisposed == false) f.Dispose();
            }
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            int i_row = spdAttrValue.ActiveSheet.ActiveRowIndex;

            for (int i = i_row; i >= 0; i--)
            {
                if (spdAttrValue.ActiveSheet.Cells[i, 1].Value != spdAttrValue.ActiveSheet.Cells[i_row, 1].Value) break;
                spdAttrValue.ActiveSheet.Cells[i, 0].Value = true;
            }

            for (int i = i_row + 1; i < spdAttrValue.ActiveSheet.RowCount; i++)
            {
                if (spdAttrValue.ActiveSheet.Cells[i, 1].Value != spdAttrValue.ActiveSheet.Cells[i_row, 1].Value) break;
                spdAttrValue.ActiveSheet.Cells[i, 0].Value = true;
            }

            spdAttrValue.ActiveSheet.Rows[i_row].Remove();

            if (MPCF.Trim(spdAttrValue.ActiveSheet.Cells[i_row, 7].Value) == "Y" &&
                i_row != spdAttrValue.ActiveSheet.RowCount - 1 &&
                spdAttrValue.ActiveSheet.Cells[i_row + 1, 1].Value == spdAttrValue.ActiveSheet.Cells[i_row, 1].Value)
            {
                MPCR.ChangeControlEnabled(this, btnDelRow, true);
            }
            else
            {
                MPCR.ChangeControlEnabled(this, btnDelRow, false);
            }
        }         


    }
}
