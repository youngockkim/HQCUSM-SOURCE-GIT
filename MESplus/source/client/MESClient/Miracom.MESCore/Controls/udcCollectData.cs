using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
using FarPoint.Win.Spread;
using Miracom.MsgHandler;

namespace Miracom.MESCore.Controls
{
    public partial class udcCollectData : UserControl
    {
        public udcCollectData()
        {
            InitializeComponent();

            cls_derived_char_list = new clsDerivedCharList();
            Init();
        }


        #region " Constant Definition "

        private const int CHAR_COL = 0;
        private const int CHAR_DESC_COL = 1;
        private const int SPEC_COL = 2;
        private const int OPT_INPUT_COL = 3;
        private const int VALUE_TYPE_COL = 4;
        private const int VALUE_COUNT_COL = 5;
        private const int DEF_UNIT_OVR_FLAG_COL = 6;
        private const int DEF_VALUE_COL = 7;
        private const int UNIT_TBL_COL = 8;
        private const int VALUE_TBL_COL = 9;
        private const int UNIT_SEQ_COL = 10;
        private const int UNIT_COL = 11;

        private const int VALUE_START_COL = 12;
        private const int DEFAULT_COL_COUNT = 12;

        private const int OUT_SEQ = 0;
        private const int OUT_CHAR = 1;
        private const int OUT_UNIT_ID = 2;
        private const int OUT_RULE_TYPE = 3;
        private const int OUT_RULE_DESC = 4;

        private const int MAX_DATA_COUNT = 5000;

        #endregion

        #region "Property Definition"

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ColSetID
        {
            get
            {
                return ms_col_set_id;
            }
            set
            {
                ms_col_set_id = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ColSetVersion
        {
            get
            {
                return mi_col_set_ver;
            }
            set
            {
                mi_col_set_ver = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LotID
        {
            get
            {
                return ms_lot_id;
            }
            set
            {
                ms_lot_id = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MatID
        {
            get
            {
                return ms_mat_id;
            }
            set
            {
                ms_mat_id = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MatVersion
        {
            get
            {
                return mi_mat_ver;
            }
            set
            {
                mi_mat_ver = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Flow
        {
            get
            {
                return ms_flow;
            }
            set
            {
                ms_flow = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Operation
        {
            get
            {
                return ms_oper;
            }
            set
            {
                ms_oper = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResID
        {
            get
            {
                return ms_res_id;
            }
            set
            {
                ms_res_id = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResEventID
        {
            get
            {
                return ms_event_id;
            }
            set
            {
                ms_event_id = value;
            }
        }

        public CollectionType CollectionType
        {
            get
            {
                return m_collection_type;
            }
            set
            {
                m_collection_type = value;
            }
        }

        #endregion

        #region " Variable Definition "

        private clsDerivedCharList cls_derived_char_list;
        private CollectionType m_collection_type;

        private string ms_col_set_id;
        private int mi_col_set_ver;
        private string ms_lot_id;
        private string ms_mat_id;
        private int mi_mat_ver;
        private string ms_flow;
        private string ms_oper;
        private string ms_res_id;
        private string ms_event_id;

        #endregion

        #region " Function Definition "

        public void Init()
        {
            ClearCollectDataControl();

            m_collection_type = CollectionType.Lot;
            ms_col_set_id = "";
            mi_col_set_ver = 0;
            ms_lot_id = "";
            ms_mat_id = "";
            mi_mat_ver = 0;
            ms_flow = "";
            ms_oper = "";
            ms_res_id = "";
            ms_event_id = "";
        }

        public void ClearCollectDataControl()
        {
            MPCF.ClearList(spdData, true);
        }

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public bool CheckCondition()
        {
            int i = 0;
            int j = 0;

            try
            {
                if (spdData.ActiveSheet.RowCount == 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(107));
                    spdData.Select();
                    return false;
                }
                else if (spdData.ActiveSheet.RowCount > MAX_DATA_COUNT)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(134));
                    spdData.Select();
                    return false;
                }

                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, CHAR_COL)) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        spdData.ActiveSheet.SetActiveCell(i, CHAR_COL);
                        spdData.Select();
                        return false;
                    }

                    // unit_id check
                    if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, OPT_INPUT_COL)) != "Y")
                    {
                        for (j = UNIT_COL; j <= UNIT_COL + MPCF.ToInt(spdData.ActiveSheet.GetValue(i, VALUE_COUNT_COL)); j++)
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.GetTag(i, j)) != "NULL")
                            {
                                if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, j)) == "" && spdData.ActiveSheet.Cells[i, j].Locked == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdData.ActiveSheet.SetActiveCell(i, j);
                                    spdData.Select();
                                    return false;
                                }
                            }
                        }
                    }
                    if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, VALUE_TYPE_COL)) == "N")
                    {
                        for (j = VALUE_START_COL; j < VALUE_START_COL + MPCF.ToInt(spdData.ActiveSheet.GetValue(i, VALUE_COUNT_COL)); j++)
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, j)) != "")
                            {
                                if (MPCF.CheckNumeric(spdData.ActiveSheet.GetValue(i, j)) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    spdData.ActiveSheet.SetActiveCell(i, j);
                                    spdData.Select();
                                    return false;
                                }
                            }
                        }
                    }
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
        // FillCollectionData()
        //       - Fill Collection Data to in_node
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - TRSNode in_node : In Node
        //
        public bool FillCollectionData(TRSNode in_node)
        {
            int i;
            int j;
            int i_value_count;

            TRSNode char_item, unit_item, value_item;

            CultureInfo ci_inter = new CultureInfo("en-US");

            try
            {
                char_item = in_node.AddNode("CHAR_LIST");
                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (MPCF.ToInt(spdData.ActiveSheet.GetValue(i, UNIT_SEQ_COL)) == 1)
                    {
                        if (i != 0)
                        {
                            char_item = in_node.AddNode("CHAR_LIST");
                        }
                        char_item.AddString("CHAR_ID", MPCF.Trim(spdData.ActiveSheet.GetValue(i, CHAR_COL)));
                    }
                    unit_item = char_item.AddNode("UNIT_LIST");
                    unit_item.AddString("UNIT_ID", MPCF.Trim(spdData.ActiveSheet.GetValue(i, UNIT_COL)));
                    unit_item.AddInt("UNIT_SEQ_NUM", MPCF.ToInt(spdData.ActiveSheet.GetValue(i, UNIT_SEQ_COL)));

                    i_value_count = MPCF.ToInt(spdData.ActiveSheet.GetValue(i, VALUE_COUNT_COL));
                    for (j = 0; j < i_value_count; j++)
                    {
                        value_item = unit_item.AddNode("VALUE_LIST");

                        if (MPCF.Trim(spdData.ActiveSheet.GetValue(i, VALUE_TYPE_COL)) == "N" &&
                            MPCF.CheckNumeric(spdData.ActiveSheet.GetValue(i, j + VALUE_START_COL)) == true)
                        {
                            value_item.AddString("VALUE", MPCF.ToDbl(spdData.ActiveSheet.GetValue(i, j + VALUE_START_COL)).ToString(ci_inter.NumberFormat));
                        }
                        else
                        {
                            value_item.AddString("VALUE", MPCF.Trim(spdData.ActiveSheet.GetValue(i, j + VALUE_START_COL)));
                        }
                    }
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
        // FillCollectData()
        //       - Fill Collection Data to in_node
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - TRSNode in_node : In Node
        //
        public bool DrawCollectionCharacter()
        {
            try
            {
                ClearCollectDataControl();
                mi_col_set_ver = 0;

                if (MPCF.Trim(ms_col_set_id) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108) + "\r\nCol_Set_ID");
                    return false;
                }

                if (MPCR.FindColSetVersion('1', 
                                           ms_col_set_id, 
                                           ref mi_col_set_ver, 
                                           ms_lot_id, ms_mat_id, 
                                           mi_mat_ver, 
                                           ms_flow, 
                                           ms_oper, 
                                           ms_res_id, 
                                           ms_event_id,
                                           (m_collection_type == CollectionType.Lot ? 'L' : 'R'), 
                                           spdData, 
                                           false, 
                                           'Y', 
                                           cls_derived_char_list) == false)
                {
                    return false;
                }

                {
                    int i, k;
                    bool b_escape;

                    b_escape = false;
                    for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                    {
                        for (k = UNIT_COL; k < spdData.ActiveSheet.ColumnCount; k++)
                        {
                            if (spdData.ActiveSheet.Cells[i, k].Locked == false)
                            {
                                spdData.ActiveSheet.SetActiveCell(i, k);
                                spdData.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Left);
                                spdData.Focus();
                                b_escape = true;
                                break;
                            }
                        }

                        if (b_escape == true) break;
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

        public void DrawSpecOutMask(TRSNode out_node)
        {
            int i;
            int m;
            int k;
            int i_value_count;
            int i_row;
            Color spec_out_back_color;
            
            TRSNode spec_out_mask_ary;
            List<TRSNode> char_list, unit_list;

            i_row = 0;
            char_list = out_node.GetList("CHAR_LIST");

            for (i = 0; i < char_list.Count; i++)
            {
                unit_list = char_list[i].GetList("UNIT_LIST");
                for (k = 0; k < unit_list.Count; k++)
                {
                    spec_out_mask_ary = unit_list[k].GetArray("SPEC_OUT_MASK");
                    i_value_count = spec_out_mask_ary.MemberCount;

                    for (m = 0; m < i_value_count; m++)
                    {
                        spec_out_back_color = Color.White;

                        if (spec_out_mask_ary.GetChar(m.ToString()) == '1' ||
                            spec_out_mask_ary.GetChar(m.ToString()) == '4' ||
                            spec_out_mask_ary.GetChar(m.ToString()) == '5')
                        {
                            spec_out_back_color = Color.Red;
                        }
                        else if (spec_out_mask_ary.GetChar(m.ToString()) == '2' ||
                                 spec_out_mask_ary.GetChar(m.ToString()) == '3')
                        {
                            spec_out_back_color = Color.Yellow;
                        }
                        else if (MPCF.Trim(spdData.ActiveSheet.Rows[i_row].Tag) == "AUTO")
                        {
                            spec_out_back_color = Color.Cyan;
                        }

                        spdData.ActiveSheet.Cells[i_row, VALUE_START_COL + m].BackColor = spec_out_back_color;
                    }
                    i_row++;
                }
            }
        }

        public int ConfirmSpecOutData(TRSNode out_node, bool b_check_data_case)
        {
            if (out_node.StatusValue == MPGC.MP_TRBL_STATUS)
            {
                return ResultManagement(out_node);
            }
            else if (out_node.StatusValue == MPGC.MP_SUCCESS_STATUS)
            {
                if (b_check_data_case == false)
                {
                    MPCR.ShowSuccessMsg(out_node);

                    if (DrawCollectionCharacter() == false)
                    {
                        return 0;
                    }
                }
            }

            return 1;
        }

        // ResultManagement()
        //       - Manage result of data collection
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal Collect_EDC_Data_Out As SPC_Collect_EDC_Data_Out_Tag
        //
        private int ResultManagement(TRSNode out_node)
        {
            try
            {
                if (out_node.StatusValue == MPGC.MP_TRBL_STATUS)
                {
                    frmConfirmCollectData f = new frmConfirmCollectData();
                    ViewResult(f.spdResult, out_node);
                    f.ShowDialog(this);

                    //Pending
                    if (f.DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        //Data Commit
                        //OOC History Insert

                        return 2;
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        f.Dispose();
                        spdData.Select();
                        return 0;
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        f.Dispose();
                        spdData.Select();
                        return 0;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return 0;
            }

            return 1;
        }

        // ViewResult()
        //       - View Result of Data Collection
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef spdResult As FpSpread - 
        //       - ByVal Result_Out._C As SPC_Collect_EDC_Data_Out_Tag : Data Collection Out Tag
        //       - ByVal c_step As String
        //
        private void ViewResult(FarPoint.Win.Spread.FpSpread spdResult, TRSNode out_node)
        {
            int i, k;
            List<TRSNode> char_list, unit_list;

            try
            {
                MPCF.ClearList(spdResult, true);

                char_list = out_node.GetList("CHAR_LIST");
                for (i = 0; i < char_list.Count; i++)
                {
                    unit_list = char_list[i].GetList("UNIT_LIST");
                    for (k = 0; k < unit_list.Count; k++)
                    {
                        if (unit_list[k].GetChar("SPEC_OUT_TYPE") == ' ')
                        {
                            ;
                        }
                        else
                        {
                            spdResult.Sheets[0].RowCount++;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_SEQ].Value = k + 1;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_CHAR].Value = char_list[i].GetString("CHAR_ID");
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_UNIT_ID].Value = unit_list[k].GetString("UNIT_ID");

                            if (unit_list[k].GetChar("SPEC_OUT_TYPE") == 'W')
                            {
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_TYPE].Value = "OOW";
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_DESC].Value = MPCF.SetRuleDescription('W', out_node);
                            }
                            else if (unit_list[k].GetChar("SPEC_OUT_TYPE") == 'S')
                            {
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_TYPE].Value = "OOS";
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, OUT_RULE_DESC].Value = MPCF.SetRuleDescription('S', out_node);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        private void spdData_EditModeOff(object sender, System.EventArgs e)
        {
            try
            {
                int iColumn;
                int iRow;
                int i_column_count;

                if (spdData.ActiveSheet.RowCount < 1)
                {
                    return;
                }

                iColumn = spdData.ActiveSheet.ActiveColumnIndex;
                iRow = spdData.ActiveSheet.ActiveRowIndex;

                {
                    System.Collections.ArrayList a_values = new System.Collections.ArrayList();
                    string s_char_id;
                    int i_unit_seq;
                    int i_value_count;
                    int i;

                    s_char_id = MPCF.Trim(spdData.ActiveSheet.Cells[iRow, CHAR_COL].Value);
                    i_unit_seq = MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, UNIT_SEQ_COL].Value);
                    i_value_count = MPCF.ToInt(spdData.ActiveSheet.Cells[iRow, VALUE_COUNT_COL].Value);

                    /* 2013.06.12. Aiden. 실제 Value Count 만큼을 계산하도록 변경 */
                    if (spdData.ActiveSheet.ColumnCount - VALUE_START_COL > i_value_count)
                        i_column_count = spdData.ActiveSheet.ColumnCount - VALUE_START_COL;
                    else
                        i_column_count = i_value_count;

                    for (i = 0; i < i_column_count; i++)
                    {
                        a_values.Add(spdData.ActiveSheet.Cells[iRow, VALUE_START_COL + i].Value);
                    }

                    cls_derived_char_list.SetValue(s_char_id, i_unit_seq, a_values, true);
                    MPCR.RecalculateDerivedParam(spdData, cls_derived_char_list, CHAR_COL, VALUE_START_COL, VALUE_COUNT_COL);
                }

                spdData.ActiveSheet.Cells[iRow, iColumn].Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                if (iColumn < spdData.ActiveSheet.ColumnCount - 1 && spdData.ActiveSheet.Cells[iRow, iColumn + 1].Locked == false)
                {
                    spdData.ActiveSheet.SetActiveCell(iRow, iColumn + 1);
                }
                else
                {
                    if (iRow + 1 == spdData.ActiveSheet.RowCount)
                    {
                        return;
                    }
                    if (spdData.ActiveSheet.Cells[iRow + 1, UNIT_COL].Locked == false)
                    {
                        spdData.ActiveSheet.SetActiveCell(iRow + 1, UNIT_COL);
                    }
                    else
                    {
                        int i;
                        for (i = iRow + 1; i < spdData.ActiveSheet.RowCount; i++)
                        {
                            if (spdData.ActiveSheet.Cells[i, VALUE_START_COL].Locked == false)
                            {
                                spdData.ActiveSheet.SetActiveCell(i, VALUE_START_COL);
                                break;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (spdData.ActiveSheet.RowCount < 1)
                {
                    return;
                }

                if (spdData.ActiveSheet.Cells[spdData.ActiveSheet.ActiveRowIndex, VALUE_TYPE_COL].Text == "N")
                {
                    if (spdData.ActiveSheet.ActiveColumnIndex == UNIT_COL)
                    {
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }





    }// End of udcCollectData


    public enum CollectionType
    {
        Lot = 0,
        Resource = 1
    }

}
