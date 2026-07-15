//
//   Function List
//       - CheckCondition() : Check Update condition
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2011-06-05 : Created by Aiden Koo
//
//
//   Copyright(C) 1998-2011 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//Imports

using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Windows.Forms;
using Miracom.UI.Controls;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

using Miracom.TRSCore;
using System.Globalization;

namespace Miracom.BASCore
{
    public partial class frmBASTranAttributeByPrivilege : TranForm01
    {
        public frmBASTranAttributeByPrivilege()
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

        // ViewAttributeValue()
        //       - View Attribute Value
        // Return Value
        //       - boolean : True / False
        private bool ViewAttributeValue()
        {
            int i, i_row = 0; 
            CultureInfo ci_local = CultureInfo.CurrentCulture;
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("ATTR_OUT");
            List<TRSNode> value_list;

            MPCF.ClearList(spdAttrValue, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPCF.Trim(cdvAttrType.Text));
            in_node.AddString("ATTR_KEY", MPCF.Trim(cdvAttrKey.Text));
            in_node.AddInt("ATTR_FROM", (int)nudFromAttrSeq.Value);
            in_node.AddInt("ATTR_TO", (int)nudToAttrSeq.Value);

            in_node.AddChar("SEC_CHK_FLAG", chkOnlyPrvAttribute.Checked == true ? 'Y' : ' ');
            in_node.AddChar("ONLY_FOR_USER_FLAG", 'Y');

            in_node.AddString("NEXT_ATTR_NAME", "");
            in_node.AddInt("NEXT_ATTR_SEQ", 0);

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
                                //spdAttrValue.ActiveSheet.Cells[i_row, 4].Value = sa_attr_values[i_cnt];

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
            in_node.AddString("ATTR_TYPE", MPCF.Trim(cdvAttrType.Text));
            in_node.AddString("ATTR_KEY", MPCF.Trim(cdvAttrKey.Text));

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

        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String        : Create/Update/Delete 구분??
        //
        private bool CheckCondition(char ProcStep)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvAttrKey, 1) == false)
            {
                return false;
            }

            switch (ProcStep)
            {
                case 'V':

                    break;
                case MPGC.MP_STEP_UPDATE:
                    bool bCheck = false;
                    bool bNullCheck = false;
                    int i, iRows = spdAttrValue.ActiveSheet.RowCount;
                    for (i = 0; i < iRows; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i, 0].Value != null)
                        {
                            bCheck = true;
                        }
                        if (Convert.ToBoolean(spdAttrValue.ActiveSheet.Cells[i, 6].Value) == true)
                        {
                            bNullCheck = true;
                            break;
                        }
                    }

                    if (!bCheck) return false;
                    if (bNullCheck)
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(64), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                            return false;
                    }
                    break;
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

                    for (int i = i_row + 1; i < spdAttrValue.ActiveSheet.RowCount - 1; i++)
                    {
                        if (spdAttrValue.ActiveSheet.Cells[i + 1, 1].Value != spdAttrValue.ActiveSheet.Cells[i_row, 1].Value) break;
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
                return this.cdvAttrType;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmBASTranAttributeByPrivilege_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdAttrValue, true);
                MPCF.FieldClear(this, chkOnlyPrvAttribute);
                nudToAttrSeq.Value = 10000;

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

        private void cdvAttrType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvAttrType.Init();
            MPCF.InitListView(cdvAttrType.GetListView);
            cdvAttrType.Columns.Add("Type", 150, HorizontalAlignment.Left);
            cdvAttrType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAttrType.GetListView, '1', MPGC.MP_ATTR_TYPE_TABLE);
        }

        private void cdvAttrType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvAttrKey.Text = "";
            cdvAttrKey.VisibleButton = true;

            switch (cdvAttrType.Text)
            {
                case MPGC.MP_ATTR_TYPE_FACTORY:

                    break;
                case MPGC.MP_ATTR_TYPE_MATERIAL:

                    break;
                case MPGC.MP_ATTR_TYPE_FLOW:

                    break;
                case MPGC.MP_ATTR_TYPE_OPER:

                    break;
                case MPGC.MP_ATTR_TYPE_BOM:

                    break;
                case MPGC.MP_ATTR_TYPE_RESOURCE:

                    break;
                case MPGC.MP_ATTR_TYPE_CARRIER:

                    break;
                default:

                    cdvAttrKey.VisibleButton = false;
                    break;
            }

        }

        private void cdvAttrKey_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false)
            {
                return;
            }

            cdvAttrKey.Init();
            MPCF.InitListView(cdvAttrKey.GetListView);
            cdvAttrKey.Columns.Add("Key", 150, HorizontalAlignment.Left);
            cdvAttrKey.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrKey.SelectedSubItemIndex = 0;

            switch (cdvAttrType.Text)
            {
                case MPGC.MP_ATTR_TYPE_FACTORY:

                    WIPLIST.ViewFactoryList(cdvAttrKey.GetListView, '1', null);
                    break;
                case MPGC.MP_ATTR_TYPE_MATERIAL:

                    cdvAttrKey.Columns.Add("Desc", 200, HorizontalAlignment.Left);

                    WIPLIST.ViewMaterialList(cdvAttrKey.GetListView, '1');
                    break;
                case MPGC.MP_ATTR_TYPE_FLOW:

                    WIPLIST.ViewFlowList(cdvAttrKey.GetListView, '1', "", 0, "", null, "");
                    break;
                case MPGC.MP_ATTR_TYPE_OPER:

                    WIPLIST.ViewOperationList(cdvAttrKey.GetListView, '1', "", 0, "", "", null, "");
                    break;
                case MPGC.MP_ATTR_TYPE_BOM:

#if _BOM
                    BOMLIST.ViewBOMSetList(cdvAttrKey.GetListView, '1', null, "", -1, -1, ' ', true);
#endif
                    break;
                case MPGC.MP_ATTR_TYPE_RESOURCE:

                    RASLIST.ViewResourceList(cdvAttrKey.GetListView, false);
                    break;
                case MPGC.MP_ATTR_TYPE_CARRIER:

                    if (MPGO.RequireCarrierFilter() == true)
                    {
                        if (MPCF.Trim(cdvAttrKey.Text) == "")
                        {
                            cdvAttrKey.IsPopup = false;
                            MPCF.ShowMsgBox(MPCF.GetMessage(258));
                            cdvAttrKey.Focus();
                            return;
                        }
                    }
                    RASLIST.ViewCarrierList(cdvAttrKey.GetListView, '1', "", "", cdvAttrKey.Text);
                    break;
            }

        }

        private void cdvAttrKey_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvAttrType.Text == MPGC.MP_ATTR_TYPE_MATERIAL)
                if (e != null)
                    cdvAttrKey.Text = e.SelectedItem.SubItems[0].Text + " : " + e.SelectedItem.SubItems[1].Text;

            btnView.PerformClick();
        }

        private void cdvAttrKey_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (MPCF.Trim(cdvAttrKey.Text) != "")
            {
                if (e.KeyChar == (char)13)
                {
                    btnView.PerformClick();
                }
            }
        }

        private void cdvTableData_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdAttrValue.ActiveSheet.Cells[e.Row, 4].Value = MPCF.Trim(e.SelectedItem.Text);
            spdAttrValue.ActiveSheet.Cells[e.Row, 0].Value = true;
            AddArrayTypeRow(e.Row, true);
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition('V') == false)
                return;
            
            ViewAttributeValue();
            MPCR.ChangeControlEnabled(this, btnDelRow, false);
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false) return;
            if (UpdateAttributeValue() == false) return;

            btnView.PerformClick();
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

                if (BASLIST.ViewGCMDataList(cdvTableData.GetListView, '1', MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, e.Column].Tag)) == false)
                {
                    return;
                }

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
                    f.AttributeKey = cdvAttrKey.Text;
                    f.AttributeType = cdvAttrType.Text;
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
                f.AttributeKey = cdvAttrKey.Text;
                f.AttributeType = cdvAttrType.Text;
                f.AttributeName = MPCF.Trim(spdAttrValue.ActiveSheet.Cells[e.Row, 1].Value);
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
