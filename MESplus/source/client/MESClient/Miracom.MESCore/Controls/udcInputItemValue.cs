using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.UI;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.MESCore.Controls
{
    public enum INPUT_VALUE_POINT
    {
        START = 0,
        END,
        ADHOC
    }

    public enum INPUT_VALUE_TYPE
    {
        ATTRIBUTE = 0,
        TOOL
    }

    public partial class udcInputItemValue : UserControl
    {
        public udcInputItemValue()
        {
            InitializeComponent();
            Init();
        }

        private INPUT_VALUE_POINT m_cond_point_type;
        private INPUT_VALUE_TYPE m_cond_value_type;
        private bool m_control_active_flag;

        #region "Constants"

        private const string NULL_STRING = "[Null]";
        private const string DEL_STRING = "D";

        private enum SpdColum
        {
            ID,                     //
            PROMPT,
            CURRENT,
            NEW_VALUE,
            TABLE_BTN,
            VALUE_TYPE,             // A : Attribute, C : Table-Column
            DISPLAY_TYPE,           // V : View, I : Internal Input, U : User Input
            EVENT,                  // Tool Event
            SAVE_FLAG,              // T : Target, Y : Saved
            INPUT_VALUE_TYPE,
            DELETE,                 //ArrayType Attribute. TAG=AraryIndex
            NULL                    //ArrayType Null. TAG=ArraySeperator
        }

        #endregion

        #region "Variables"



        #endregion

        #region "Properties"

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public INPUT_VALUE_POINT ListCond_PointType
        {
            get
            {
                return m_cond_point_type;
            }
            set
            {
                m_cond_point_type = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public INPUT_VALUE_TYPE InputValueType
        {
            get
            {
                return m_cond_value_type;
            }
            set
            {
                m_cond_value_type = value;
            }
        }

        public FarPoint.Win.Spread.SheetView ItemInputSheet
        {
            get
            {
                return spdItemInput.ActiveSheet;
            }
        }

        public Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTableListItem
        {
            get
            {
                return cdvTableList;
            }
        }

        public bool ActiveFlag
        {
            get
            {
                return m_control_active_flag;
            }
            set
            {
                m_control_active_flag = value;
            }
        }

        #endregion

        #region "Control Events"

        private System.EventHandler ItemButtonPressEvent;
        public event System.EventHandler ItemButtonPress
        {
            add
            {
                ItemButtonPressEvent = (System.EventHandler)System.Delegate.Combine(ItemButtonPressEvent, value);
            }
            remove
            {
                ItemButtonPressEvent = (System.EventHandler)System.Delegate.Remove(ItemButtonPressEvent, value);
            }
        }

        private void pnlInputItem_Resize(object sender, EventArgs e)
        {
            int i_sheet_width;
            int i_row_header_width;
            int i_col_width;

            if (pnlInputItem.Width < 200)
            {
                pnlInputItem.Width = 200;
                return;
            }

            i_sheet_width = spdItemInput.Width - 25 - 22;

            if (m_cond_value_type == INPUT_VALUE_TYPE.ATTRIBUTE)
            {
                spdItemInput.ActiveSheet.Columns[0].Width = 0;
                spdItemInput.ActiveSheet.Columns[0].Visible = false;
            }
            else
            {
                spdItemInput.ActiveSheet.Columns[0].Width = 80;
                spdItemInput.ActiveSheet.Columns[0].Visible = true;
            }

            i_row_header_width = (int)spdItemInput.ActiveSheet.RowHeader.Columns[0].Width;
            i_col_width = (int)(i_sheet_width - (i_row_header_width + spdItemInput.ActiveSheet.Columns[0].Width)) / 3;

            spdItemInput.ActiveSheet.Columns[1].Width = i_col_width + 20;
            if (i_col_width - 30 < 1)
                i_col_width = 31;
            
            spdItemInput.ActiveSheet.Columns[2].Width = i_col_width - 30;
            spdItemInput.ActiveSheet.Columns[3].Width = i_col_width - 30;
        }

        private void spdInputItem_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (ItemButtonPressEvent != null)
            {
                ItemButtonPressEvent(this, e);
                return;
            }

            if (e.Column == (int)SpdColum.TABLE_BTN)
            {
                string s_table_name = MPCF.Trim(spdItemInput.ActiveSheet.Cells[e.Row, 4].Tag);

                if (s_table_name != "")
                {
                    cdvTableList.Init();
                    cdvTableList.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvTableList.GetListView);
                    cdvTableList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                    cdvTableList.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
                    cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                    if (BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', s_table_name) == false)
                    {
                        return;
                    }

                    cdvTableList.ShowPopupList(e.Row, e.Column);
                }
            }
            else if (e.Column == (int)SpdColum.DELETE)
            {
                if (MPCF.ToInt(spdItemInput.ActiveSheet.Cells[e.Row, (int)SpdColum.DELETE].Tag) > 0)
                {
                    spdItemInput.ActiveSheet.Rows.Remove(e.Row, 1);
                }
                else
                {
                    spdItemInput.ActiveSheet.Cells[e.Row, (int)SpdColum.NEW_VALUE].Value = "";
                }
            }
            else if (e.Column == (int)SpdColum.NULL)
            {
                //Attribute의 Value Type이 Array 타입이 아닐때 Null Checkbox가 나타나지 않는 부분을 수정
                //if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[e.Row, (int)SpdColum.DELETE].Tag) != "" &&
                //    MPCF.ToInt(spdItemInput.ActiveSheet.Cells[e.Row, (int)SpdColum.DELETE].Tag) == 0)
                //{
                    int last_row;

                    if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[e.Row, (int)SpdColum.NULL].Value) == "True")
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(53), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                        {
                            spdItemInput.ActiveSheet.Cells[e.Row, (int)SpdColum.NULL].Value = false;
                            return;
                        }

                        spdItemInput.ActiveSheet.Cells[e.Row, (int)SpdColum.NEW_VALUE].Value = NULL_STRING;
                        last_row = GetLastRow(e.Row);
                        if (e.Row < last_row)
                        {
                            spdItemInput_Sheet1.RemoveRows(e.Row + 1, last_row - e.Row);
                        }
                    }
                    else
                    {
                        AddEmptyRow(e.Row);
                    }

                    //for (int i = e.Row + 1; i < last_row; i++)
                    //{
                    //    if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, (int)SpdColum.NEW_VALUE].Tag) == MPCF.Trim(spdItemInput.ActiveSheet.Cells[e.Row, (int)SpdColum.NEW_VALUE].Tag))
                    //    {
                    //        spdItemInput.ActiveSheet.Cells[i, (int)SpdColum.NEW_VALUE].Value = NULL_STRING;
                    //        spdItemInput.ActiveSheet.Cells[i, (int)SpdColum.NULL].Value = spdItemInput.ActiveSheet.Cells[e.Row, (int)SpdColum.NULL].Value;
                    //    }
                    //}
                //Attribute의 Value Type이 Array 타입이 아닐때 Null Checkbox가 나타나지 않는 부분을 수정
                //}
            }
        }

        private void spdItemInput_EditModeOff(object sender, EventArgs e)
        {
            int i_row = spdItemInput.ActiveSheet.ActiveRowIndex;
            int i_col = spdItemInput.ActiveSheet.ActiveColumnIndex;
            int i;

            for (i = i_row + 1; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (spdItemInput.ActiveSheet.Cells[i, i_col].Locked == false)
                {
                    spdItemInput.ActiveSheet.SetActiveCell(i, i_col);
                    break;
                }
            }

            //ArrayType Attribuet => Add Empty Row
            if (i_col == (int)SpdColum.NEW_VALUE)
            {
                AddEmptyRow(i_row);
            }
        }

        private void cdvTableList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdItemInput.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;

            AddEmptyRow(e.Row);
        }

        #endregion

        public void Init()
        {
            MPCF.ClearList(spdItemInput);
            MPCF.ConvertMessage(this.Controls);
            spdItemInput.ActiveSheet.Columns[(int)SpdColum.TABLE_BTN].Resizable = false;
            spdItemInput.ActiveSheet.Columns[(int)SpdColum.DELETE].Resizable = false;
            spdItemInput.ActiveSheet.Columns[(int)SpdColum.NULL].Resizable = false;

            spdItemInput.ActiveSheet.Columns[(int)SpdColum.DELETE].Visible = false;
            spdItemInput.ActiveSheet.Columns[(int)SpdColum.DELETE].Locked = true;
            spdItemInput.ActiveSheet.Columns[(int)SpdColum.NULL].Visible = false;
            spdItemInput.ActiveSheet.Columns[(int)SpdColum.NULL].Locked = true;
            //FarPoint.Win.Spread.CellType.EmptyCellType celltype = new FarPoint.Win.Spread.CellType.EmptyCellType();
            //spdItemInput.ActiveSheet.Columns[(int)SpdColum.DELETE].CellType = celltype
        }

        public bool ViewOperInputValueList(ArrayList a_objects, string s_mat_id, int i_mat_ver, string s_flow, string s_oper, INPUT_VALUE_POINT point_type, bool b_tool_continuous_input)
        {
            TRSNode in_node = new TRSNode("VIEW_OPER_INPUT_VALUE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_OPER_INPUT_VALUE_LIST_OUT");
            TRSNode tool_item;
            List<TRSNode> value_list;
            int i;
            int i_row;
            int i_argb;

            FarPoint.Win.Spread.CellType.NumberCellType numCell;
            FarPoint.Win.Spread.CellType.TextCellType txtCell;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;
            FarPoint.Win.Spread.CellType.BaseCellType cellType;
            FarPoint.Win.Spread.CellType.CheckBoxCellType chkCell;
            char c_val_fmt;
            int i_val_size;
            string s_val_table_name;
            string s_val_value;

            bool view_del_button = false;
            bool view_check_null = false;

            if (m_cond_value_type == INPUT_VALUE_TYPE.TOOL && b_tool_continuous_input == true)
            {

                for (i_row = 0; i_row < spdItemInput.ActiveSheet.RowCount; i_row++)
                {
                    if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i_row, 0].Tag) != "COMMON")
                    {
                        for (i = 0; i < a_objects.Count; i++)
                        {
                            if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i_row, 0].Value).Equals(MPCF.Trim(a_objects[i])))
                            {
                                a_objects.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MPCF.ClearList(spdItemInput);
            }

            if (a_objects == null) return false;
            if (a_objects.Count < 1) return false;

            MPCR.SetInMsg(in_node);

            if (m_cond_value_type == INPUT_VALUE_TYPE.ATTRIBUTE)
            {
                in_node.ProcStep = '4';
                in_node.AddString("LOT_ID", MPCF.Trim(a_objects[0]));
            }
            else if (m_cond_value_type == INPUT_VALUE_TYPE.TOOL)
            {
                in_node.ProcStep = '3';

                for (i = 0; i < a_objects.Count; i++)
                {
                    tool_item = in_node.AddNode("TOOL_LIST");
                    tool_item.AddString("TOOL_ID", MPCF.Trim(a_objects[i]));
                }
            }

            in_node.AddString("MAT_ID", s_mat_id);
            in_node.AddInt("MAT_VER", i_mat_ver);
            in_node.AddString("FLOW", s_flow);
            in_node.AddString("OPER", s_oper);

            switch (point_type)
            {
                case INPUT_VALUE_POINT.START: in_node.AddChar("POINT_TYPE", 'S'); break;
                case INPUT_VALUE_POINT.END: in_node.AddChar("POINT_TYPE", 'E'); break;
                case INPUT_VALUE_POINT.ADHOC: in_node.AddChar("POINT_TYPE", 'A'); break;
            }

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Operation_Input_Value_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                value_list = out_node.GetList("VALUE_LIST");

                for (i = 0; i < value_list.Count; i++)
                {
                    if (m_cond_value_type == INPUT_VALUE_TYPE.ATTRIBUTE)
                    {
                        //Array구분자로 값배열을 생성
                        string[] sa_attr_values = null;
                        
                        if (value_list[i].GetChar("NULL_FLAG") == 'Y')
                        {
                            sa_attr_values = new string[] { NULL_STRING };
                        }
                        else
                        {
                            sa_attr_values = value_list[i].GetString("ATTR_VALUE").Split(value_list[i].GetChar("ARRAY_SEPARATOR"));
                            //Array타입의 속성이 아니거나 또는 Null일 경우 배열 생성
                            if (sa_attr_values == null || sa_attr_values.Length == 0)
                            {
                                sa_attr_values = new string[] { value_list[i].GetString("ATTR_VALUE") };
                            }
                        }
                        int arr_cnt = sa_attr_values.Length;

                        for (int i_cnt = 0; i_cnt < sa_attr_values.Length; i_cnt++)
                        {
                            i_row = spdItemInput.ActiveSheet.RowCount;
                            spdItemInput.ActiveSheet.RowCount++;

                            spdItemInput.ActiveSheet.Cells[i_row, 0].Value = value_list[i].GetString("LOT_ID");
                            spdItemInput.ActiveSheet.Cells[i_row, 1].Value = value_list[i].GetString("DATA_3"); //Attribute Name Desc, Display Text
                            spdItemInput.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetString("DATA_1"); //Attribute Type
                            spdItemInput.ActiveSheet.Cells[i_row, 3].Tag = value_list[i].GetString("DATA_2"); //Attirbute Name

                            if (value_list[i].GetChar("REQUIRE_FLAG") == 'Y')
                            {
                                spdItemInput.ActiveSheet.Cells[i_row, 1].Font = new Font(spdItemInput.Font.Name, spdItemInput.Font.Size, FontStyle.Bold);
                            }
                            i_argb = value_list[i].GetInt("BACK_COLOR");
                            spdItemInput.ActiveSheet.Cells[i_row, 1].BackColor = Color.FromArgb(i_argb);
                            if (spdItemInput.ActiveSheet.Cells[i_row, 1].BackColor.GetBrightness() < 0.5)
                            {
                                spdItemInput.ActiveSheet.Cells[i_row, 1].ForeColor = Color.White;
                            }

                            spdItemInput.ActiveSheet.Cells[i_row, 5].Value = value_list[i].GetChar("VALUE_TYPE"); // A : Attribute, C : Table-Column
                            spdItemInput.ActiveSheet.Cells[i_row, 6].Value = value_list[i].GetChar("DISPLAY_TYPE"); // V : View, I : Internal Input, U : User Input
                            spdItemInput.ActiveSheet.Cells[i_row, 9].Value = value_list[i].GetString("INPUT_VALUE_TYPE");

                            if (value_list[i].GetChar("DISPLAY_TYPE") == 'V')
                            {
                                spdItemInput.ActiveSheet.Cells[i_row, 3].BackColor = Color.WhiteSmoke;
                                spdItemInput.ActiveSheet.Cells[i_row, 3].Locked = true;
                            }
                            else if (value_list[i].GetChar("DISPLAY_TYPE") == 'I')
                            {
                                spdItemInput.ActiveSheet.Rows[i_row].Visible = false;
                            }

                            c_val_fmt = 'A';
                            i_val_size = 0;
                            s_val_table_name = "";
                            s_val_value = "";

                            // A : Attribute, C : Table-Column
                            if (value_list[i].GetChar("VALUE_TYPE") == 'A')
                            {
                                c_val_fmt = value_list[i].GetChar("ATTR_FMT");
                                i_val_size = value_list[i].GetInt("ATTR_SIZE");
                                s_val_value = sa_attr_values[i_cnt];

                                if (value_list[i].GetChar("DISPLAY_TYPE") != 'V')
                                {
                                    s_val_table_name = value_list[i].GetString("VALID_TBL");
                                }
                            }
                            else if (value_list[i].GetChar("VALUE_TYPE") == 'C')
                            {
                                s_val_value = value_list[i].GetString("COLUMN_VALUE");
                                i_val_size = 4000;
                            }

                            cellType = null;
                            if (c_val_fmt == 'A')
                            {
                                txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                                txtCell.MaxLength = i_val_size;

                                cellType = txtCell;
                            }
                            else if (c_val_fmt == 'N' || c_val_fmt == 'F')
                            {
                                numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                                numCell.ShowSeparator = true;
                                numCell.DecimalPlaces = 0;
                                if (c_val_fmt == 'F')
                                {
                                    numCell.DecimalPlaces = 3;
                                }

                                cellType = numCell;
                            }

                            if (s_val_table_name == "")
                            {
                                spdItemInput.ActiveSheet.Cells[i_row, 3].ColumnSpan = 2;
                            }
                            else
                            {
                                btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                                btnCell.Text = "...";
                                spdItemInput.ActiveSheet.Cells[i_row, 4].CellType = btnCell;
                                spdItemInput.ActiveSheet.Cells[i_row, 4].Tag = s_val_table_name;
                            }

                            spdItemInput.ActiveSheet.Cells[i_row, 3].CellType = cellType;
                            spdItemInput.ActiveSheet.Cells[i_row, 2].Value = s_val_value;

                            if (value_list[i].GetChar("DISPLAY_TYPE") == 'V')
                            {
                                spdItemInput.ActiveSheet.Cells[i_row, 2].ColumnSpan = spdItemInput.ActiveSheet.Columns.Count - 2;
                            }

                            if (value_list[i].GetChar("DISPLAY_TYPE") == 'I' || value_list[i].GetChar("DISPLAY_TYPE") == 'U')
                            {
                                spdItemInput.ActiveSheet.Cells[i_row, 8].Value = 'T';
                                //Default Value
                                spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.NEW_VALUE].Value = spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.CURRENT].Value;
                            }

                            //ArrayType Attribute Only
                            if (value_list[i].GetChar("ARRAY_TYPE_FLAG") == 'Y')
                            {
                                spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.DELETE].Tag = i_cnt;
                                spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.NULL].Tag = value_list[i].GetChar("ARRAY_SEPARATOR");

                                if (value_list[i].GetChar("DISPLAY_TYPE") == 'U')
                                {
                                    view_del_button = true;

                                    //DeleteRow Button
                                    btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                                    btnCell.Text = DEL_STRING;
                                    spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.DELETE].CellType = btnCell;
                                    spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.DELETE].Locked = false;
                                    //Attribute의 Value Type이 Array 타입이 아닐때 Null Checkbox가 나타나지 않는 부분을 수정
                                }
                            }

                            //Attribute의 Value Type이 Array 타입이 아닐때 Null Checkbox가 나타나지 않는 부분을 수정
                            view_check_null = true;
                            //Check Null
                            chkCell = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                            spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.NULL].CellType = chkCell;
                            if (i_cnt == 0)
                            {
                                spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.NULL].Locked = false;
                            }
                            if (value_list[i].GetChar("NULL_FLAG") == 'Y')
                            {
                                spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.NULL].Value = true;
                            }
                        }

                        //ArrayType Attribute
                        if (value_list[i].GetChar("ARRAY_TYPE_FLAG") == 'Y')
                        {
                            if (value_list[i].GetChar("DISPLAY_TYPE") == 'U' && value_list[i].GetChar("NULL_FLAG") != 'Y')
                            {
                                if (value_list[i].GetString("ATTR_VALUE") != "")
                                {
                                    AddEmptyRow(spdItemInput.ActiveSheet.RowCount - 1);
                                    arr_cnt++;
                                }
                            }

                            //"Attribute Name Column" => RowMerge
                            if (arr_cnt > 1)
                            {
                                spdItemInput.ActiveSheet.Cells[spdItemInput.ActiveSheet.RowCount - arr_cnt, 1].RowSpan = arr_cnt;
                            }
                        }

                    }//end if attribute
                    else if (m_cond_value_type == INPUT_VALUE_TYPE.TOOL)
                    {
                        i_row = 0;

                        if (value_list[i].GetChar("INPUT_TYPE") == 'I')
                        {
                            int k;

                            for (k = 0; k < spdItemInput.ActiveSheet.RowCount; k++)
                            {
                                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[k, 0].Tag) == "COMMON")
                                {
                                    if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[k, 1].Tag).Equals(value_list[i].GetString("DATA_1")))
                                    {
                                        spdItemInput.ActiveSheet.Rows.Add(k, 1);
                                        i_row = k;
                                        break;
                                    }
                                }
                            }

                            if (k >= spdItemInput.ActiveSheet.RowCount)
                            {
                                i_row = spdItemInput.ActiveSheet.RowCount;
                                spdItemInput.ActiveSheet.RowCount++;
                            }

                            spdItemInput.ActiveSheet.Cells[i_row, 0].Value = value_list[i].GetString("TOOL_ID");
                        }
                        else if (value_list[i].GetChar("INPUT_TYPE") == 'A')
                        {
                            int k;

                            for (k = 0; k < spdItemInput.ActiveSheet.RowCount; k++)
                            {
                                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[k, 0].Tag) == "COMMON")
                                {
                                    if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[k, 0].Value).Equals(value_list[i].GetString("DATA_1") + " COMMON") &&
                                        MPCF.Trim(spdItemInput.ActiveSheet.Cells[k, 1].Value).Equals(value_list[i].GetString("DATA_2")))
                                    {
                                        break;
                                    }
                                }
                            }

                            if (k < spdItemInput.ActiveSheet.RowCount)
                            {
                                continue;
                            }

                            i_row = spdItemInput.ActiveSheet.RowCount;
                            spdItemInput.ActiveSheet.RowCount++;

                            spdItemInput.ActiveSheet.Cells[i_row, 0].Value = value_list[i].GetString("DATA_1") + " COMMON";
                            spdItemInput.ActiveSheet.Cells[i_row, 0].Tag = "COMMON";
                        }

                        spdItemInput.ActiveSheet.Cells[i_row, 1].Value = value_list[i].GetString("DATA_2"); //Tool Status

                        spdItemInput.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetString("DATA_1"); //Tool Type
                        spdItemInput.ActiveSheet.Cells[i_row, 3].Tag = value_list[i].GetInt("STS_SEQ"); //Tool Status Sequence
                        spdItemInput.ActiveSheet.Cells[i_row, 7].Value = value_list[i].GetString("DATA_3"); //Tool Event

                        if (value_list[i].GetChar("REQUIRE_FLAG") == 'Y')
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 1].Font = new Font(spdItemInput.Font.Name, spdItemInput.Font.Size, FontStyle.Bold);
                        }
                        i_argb = value_list[i].GetInt("BACK_COLOR");
                        spdItemInput.ActiveSheet.Cells[i_row, 1].BackColor = Color.FromArgb(i_argb);
                        if (spdItemInput.ActiveSheet.Cells[i_row, 1].BackColor.GetBrightness() < 0.5)
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 1].ForeColor = Color.White;
                        }

                        spdItemInput.ActiveSheet.Cells[i_row, 5].Value = value_list[i].GetChar("VALUE_TYPE"); // T : Tool
                        spdItemInput.ActiveSheet.Cells[i_row, 6].Value = value_list[i].GetChar("DISPLAY_TYPE"); // V : View, I : Internal Input, U : User Input
                        spdItemInput.ActiveSheet.Cells[i_row, 9].Value = value_list[i].GetString("INPUT_VALUE_TYPE");

                        if (value_list[i].GetChar("DISPLAY_TYPE") == 'V')
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 3].BackColor = Color.WhiteSmoke;
                            spdItemInput.ActiveSheet.Cells[i_row, 3].Locked = true;
                        }
                        else if (value_list[i].GetChar("DISPLAY_TYPE") == 'I')
                        {
                            spdItemInput.ActiveSheet.Rows[i_row].Visible = false;
                        }

                        c_val_fmt = 'A';
                        i_val_size = 0;
                        s_val_table_name = "";
                        s_val_value = "";

                        c_val_fmt = value_list[i].GetChar("STS_FMT");
                        i_val_size = value_list[i].GetInt("STS_SIZE");
                        s_val_table_name = value_list[i].GetString("STS_TBL");
                        s_val_value = value_list[i].GetString("STS_VALUE");

                        cellType = null;
                        if (c_val_fmt == 'A')
                        {
                            txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                            txtCell.MaxLength = i_val_size;

                            cellType = txtCell;
                        }
                        else if (c_val_fmt == 'N' || c_val_fmt == 'F')
                        {
                            numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                            numCell.ShowSeparator = true;
                            numCell.DecimalPlaces = 0;
                            if (c_val_fmt == 'F')
                            {
                                numCell.DecimalPlaces = 3;
                            }

                            cellType = numCell;
                        }

                        if (s_val_table_name == "")
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 3].ColumnSpan = 2;
                        }
                        else
                        {
                            btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            btnCell.Text = "...";
                            spdItemInput.ActiveSheet.Cells[i_row, 4].CellType = btnCell;
                            spdItemInput.ActiveSheet.Cells[i_row, 4].Tag = s_val_table_name;
                        }

                        spdItemInput.ActiveSheet.Cells[i_row, 3].CellType = cellType;
                        spdItemInput.ActiveSheet.Cells[i_row, 2].Value = s_val_value;

                        if (value_list[i].GetChar("DISPLAY_TYPE") == 'V')
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 2].ColumnSpan = spdItemInput.ActiveSheet.Columns.Count - 2;
                        }

                        if (value_list[i].GetChar("DISPLAY_TYPE") == 'I' || value_list[i].GetChar("DISPLAY_TYPE") == 'U')
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 8].Value = 'T';
                        }
                    }//end if tool
                }//end for

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while (in_node.GetInt("NEXT_SEQ") > 0);

            SetUseCount(1);
            SetCurrentTime();

            if (view_del_button == true) spdItemInput.ActiveSheet.Columns[(int)SpdColum.DELETE].Visible = true;
            else spdItemInput.ActiveSheet.Columns[(int)SpdColum.DELETE].Visible = false;

            if (view_check_null == true) spdItemInput.ActiveSheet.Columns[(int)SpdColum.NULL].Visible = true;
            else spdItemInput.ActiveSheet.Columns[(int)SpdColum.NULL].Visible = false;

            return true;
        }

        public bool SetItemInputValue(TRSNode in_node)
        {
            int i;
            int k;
            int m;
            int i_save_count;
            int i_sts_seq;
            char c_saved_flag;
            string s_key_id;
            string s_tool_id;
            string s_tool_id_cur;
            string s_attr_type;
            string s_attr_type_cur;
            string s_item_name;
            string s_item_name_cur;
            string s_item_value;
            string s_tool_type;
            string s_tool_type_cur;
            string s_tool_event;
            string s_tool_event_cur;

            bool b_array_type = false;

            TRSNode item_in;
            TRSNode item_value;

            TRSNode tool_in = null;
            TRSNode tool_out = null;
            TRSNode tool_event_in = null;
            TRSNode tool_event_out = null;
            List<TRSNode> event_change_list;
            string s_change_item;

            s_key_id = "";
            s_attr_type = s_attr_type_cur = "";
            s_item_name = s_item_name_cur = "";
            s_tool_type = s_tool_type_cur = "";
            s_tool_event = s_tool_event_cur = "";
            s_tool_id = s_tool_id_cur = "";
            item_in = null;

            while (true)
            {
                i_save_count = 0;
                for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
                {
                    c_saved_flag = MPCF.ToChar(spdItemInput.ActiveSheet.Cells[i, 8].Value);    // Y : Saved, T : Target
                    if (c_saved_flag != 'T') continue;

                    if (m_cond_value_type == INPUT_VALUE_TYPE.ATTRIBUTE)
                    {
                        s_attr_type = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag);
                        s_item_name = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Tag);
                        //ArrayType Attribute
                        if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, (int)SpdColum.DELETE].Tag) == "")
                        {
                            b_array_type = false;
                        }
                        else
                        {
                            b_array_type = true;
                        }

                        if(b_array_type == true)
                        {
                            if (s_attr_type == s_attr_type_cur && s_item_name == s_item_name_cur)
                            {
                                continue;
                            }
                            s_item_value = GetArrayString(i);
                        }
                        else
                        {
                            s_item_value = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value);
                        }

                        if (s_attr_type_cur == "")
                        {
                            s_attr_type_cur = s_attr_type;

                            item_in = in_node.AddNode("INPUT_ATTRIBUTE");

                            MPCR.SetInMsg(item_in);
                            item_in.ProcStep = '1';

                            item_in.AddString("ATTR_TYPE", s_attr_type);
                            switch (s_attr_type)
                            {
                                case MPGC.MP_ATTR_TYPE_LOT:
                                    s_key_id = in_node.GetString("LOT_ID");
                                    break;
                                case MPGC.MP_ATTR_TYPE_RESOURCE:
                                    s_key_id = in_node.GetString("RES_ID");
                                    break;
                            }
                            item_in.AddString("ATTR_KEY", s_key_id);
                        }

                        if (s_attr_type_cur == s_attr_type)
                        {
                            item_value = item_in.AddNode("VALUE_LIST");
                            item_value.AddString("ATTR_NAME", s_item_name);
                            s_item_name_cur = s_item_name;
                            if (b_array_type == true && s_item_value == NULL_STRING)
                            {
                                item_value.AddChar("NULL_FLAG", 'Y');
                            }
                            else
                            {
                                item_value.AddString("ATTR_VALUE", s_item_value);
                            }

                            spdItemInput.ActiveSheet.Cells[i, 8].Value = 'Y';
                            i_save_count++;
                        }
                    }
                    else if (m_cond_value_type == INPUT_VALUE_TYPE.TOOL)
                    {
                        if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Tag) == "COMMON" && s_tool_id_cur == "")
                        {
                            spdItemInput.ActiveSheet.Cells[i, 8].Value = 'Y';
                            continue;
                        }

                        s_tool_id = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Value);          // Tool ID
                        s_tool_type = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag);          // Tool Type
                        i_sts_seq = MPCF.ToInt(spdItemInput.ActiveSheet.Cells[i, 3].Tag);           // Tool Status Sequence
                        s_item_value = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value);       // Tool Status Value
                        s_tool_event = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 7].Value);       // Tool Event

                        if (s_tool_event_cur == "")
                        {
                            s_tool_event_cur = s_tool_event;
                            s_tool_id_cur = s_tool_id;
                            s_tool_type_cur = s_tool_type;

                            tool_event_in = new TRSNode("View_Tool_Event_In");
                            tool_event_out = new TRSNode("View_Tool_Event_Out");

                            MPCR.SetInMsg(tool_event_in);
                            tool_event_in.ProcStep = '1';
                            tool_event_in.AddString("TOOL_TYPE", s_tool_type);
                            tool_event_in.AddString("TOOL_EVENT_ID", s_tool_event);

                            if (MPCR.CallService("RAS", "RAS_View_Tool_Event", tool_event_in, ref tool_event_out) == false)
                            {
                                return false;
                            }

                            event_change_list = tool_event_out.GetList("CHG_LIST");

                            tool_in = new TRSNode("View_Tool_In");
                            tool_out = new TRSNode("View_Tool_Out");

                            MPCR.SetInMsg(tool_in);
                            tool_in.ProcStep = '1';
                            tool_in.AddString("TOOL_TYPE", s_tool_type);
                            tool_in.AddString("TOOL_ID", s_tool_id);

                            if (MPCR.CallService("RAS", "RAS_View_Tool", tool_in, ref tool_out) == false)
                            {
                                return false;
                            }

                            item_in = in_node.AddNode("TOOL_EVENT");

                            MPCR.SetInMsg(item_in);
                            item_in.ProcStep = '1';

                            item_in.AddString("TOOL_ID", s_tool_id);
                            item_in.AddString("TOOL_TYPE", s_tool_type);
                            item_in.AddString("TOOL_EVENT_ID", s_tool_event);

                            item_in.AddString("LOT_ID", in_node.GetString("LOT_ID"));
                            item_in.AddString("SUBLOT_ID", in_node.GetString("SUBLOT_ID"));
                            item_in.AddString("RES_ID", in_node.GetString("RES_ID"));
                            item_in.AddString("SUBRES_ID", in_node.GetString("SUBRES_ID"));
                            item_in.AddString("MAT_ID", in_node.GetString("MAT_ID"));
                            item_in.AddInt("MAT_VER", in_node.GetInt("MAT_VER"));
                            item_in.AddString("FLOW", in_node.GetString("FLOW"));
                            item_in.AddString("OPER", in_node.GetString("OPER"));

                            item_in.AddString("TOOL_GRP", tool_out.GetString("TOOL_GRP"));
                            item_in.AddString("TOOL_SET_ID", tool_out.GetString("TOOL_SET_ID"));
                            item_in.AddString("TOOL_SET_LOCATION", tool_out.GetString("TOOL_SET_LOCATION"));
                            item_in.AddString("TOOL_STATUS", tool_out.GetString("TOOL_STATUS"));
                            item_in.AddString("AREA_ID", tool_out.GetString("AREA_ID"));
                            item_in.AddString("SUB_AREA_ID", tool_out.GetString("SUB_AREA_ID"));
                            item_in.AddString("TOOL_LOCATION", tool_out.GetString("TOOL_LOCATION"));
                            item_in.AddString("VENDOR_ID", tool_out.GetString("VENDOR_ID"));
                            item_in.AddChar("GRADE", tool_out.GetChar("GRADE"));

                            for (k = 0; k < 30; k++)
                            {
                                item_value = item_in.AddNode("STS_LIST");

                                for (m = 0; m < event_change_list.Count; m++)
                                {
                                    s_change_item = event_change_list[m].GetString("CHG_ITEM");
                                    if (s_change_item.StartsWith("TOOL_STS") == true &&
                                        MPCF.ToInt(s_change_item.Substring(9)) - 1 == k)
                                    {
                                        break;
                                    }
                                }

                                if (m >= event_change_list.Count)
                                {
                                    item_value.AddString("TOOL_STS", tool_out.GetList(0)[k].GetString("TOOL_STS"));
                                }
                                else
                                {
                                    item_value.AddString("TOOL_STS", "");
                                }
                            }
                        }

                        if (i_sts_seq < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(312) + "\n" + MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Value));
                            return false;
                        }
                        else
                        {
                            if (s_tool_event_cur == s_tool_event && s_tool_type_cur == s_tool_type &&
                                (s_tool_id_cur == s_tool_id || MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Tag) == "COMMON"))
                            {
                                item_in.GetList(0)[i_sts_seq - 1].SetString("TOOL_STS", s_item_value);
    
                                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Tag) != "COMMON")
                                {
                                    spdItemInput.ActiveSheet.Cells[i, 8].Value = 'Y';
                                }
                                i_save_count++;
                            }
                        }//end if
                    }//end if
                }//end for

                s_attr_type_cur = "";
                s_tool_event_cur = "";
                s_tool_id_cur = "";
                s_tool_type_cur = "";

                if (i_save_count < 1)
                {
                    break;
                }
            }

            /* 입력 완료된 Row 에 대해 다시 입력설정을 초기화 한다. 그렇지 않으면 서버 실행중 에러가 발생한 경우 다시 입력할 수 없다. */
            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                c_saved_flag = MPCF.ToChar(spdItemInput.ActiveSheet.Cells[i, 8].Value);    // Y : Saved, T : Target

                if (c_saved_flag == 'Y')
                {
                    spdItemInput.ActiveSheet.Cells[i, 8].Value = 'T';
                }
            }

            return true;
        }

        public void SetLotQty(double d_lot_qty)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 9].Value) == "LQ")
                {
                    spdItemInput.ActiveSheet.Cells[i, 3].Value = d_lot_qty;
                }
            }
        }

        public void SetLotCount(int i_lot_count)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 9].Value) == "LC")
                {
                    spdItemInput.ActiveSheet.Cells[i, 3].Value = i_lot_count;
                }
            }
        }

        public void SetUseCount(int i_use_count)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 9].Value) == "UC")
                {
                    spdItemInput.ActiveSheet.Cells[i, 3].Value = i_use_count;
                }
            }
        }

        public void SetUseResource(string s_res_id)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 9].Value) == "UR")
                {
                    spdItemInput.ActiveSheet.Cells[i, 3].Value = s_res_id;
                }
            }
        }

        public void SetMultiUseResource(string s_res_id, string s_tool_id)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Value) == s_tool_id &&
                    MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 9].Value) == "UR")
                    
                {
                    spdItemInput.ActiveSheet.Cells[i, 3].Value = s_res_id;
                }
            }
        }

        public void SetMultiUseCount(int i_use_count, string s_tool_id)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Value) == s_tool_id &&
                    MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 9].Value) == "UC")
                {
                    spdItemInput.ActiveSheet.Cells[i, 3].Value = i_use_count;
                }
            }
        }

        public void SetCurrentTime()
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 9].Value) == "CT")
                {
                    spdItemInput.ActiveSheet.Cells[i, 3].Value = MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATETIME_FORMAT);
                }
            }
        }

        public void SetCustomValue(string s_key_1, string s_key_2, string s_value)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 9].Value) == "CV")
                {
                    if (m_cond_value_type == INPUT_VALUE_TYPE.ATTRIBUTE)
                    {
                        if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Tag) == s_key_1)         // attribute name
                        {
                            spdItemInput.ActiveSheet.Cells[i, 3].Value = s_value;
                        }
                    }
                    else if (m_cond_value_type == INPUT_VALUE_TYPE.TOOL)
                    {
                        if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Value) == s_key_1        // tool id
                            && MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Value) == s_key_2)    // tool status
                        {
                            spdItemInput.ActiveSheet.Cells[i, 3].Value = s_value;
                        }
                    }
                }
            }
        }

        public bool CheckItemInputValue()
        {
            int i;
            char c_saved_flag;
            bool b_required_field;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                b_required_field = false;
                if (spdItemInput.ActiveSheet.Cells[i, 1].Font != null && spdItemInput.ActiveSheet.Cells[i, 1].Font.Bold == true)
                    b_required_field = true;

                c_saved_flag = MPCF.ToChar(spdItemInput.ActiveSheet.Cells[i, 8].Value);    // Y : Saved, T : Target

                if (c_saved_flag == 'T')
                {
                    if (b_required_field == true)
                    {
                        if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Value) == "")
                        {
                            string s_msg;

                            s_msg = MPCF.GetMessage(108) + "\n";
                            if (m_cond_value_type == INPUT_VALUE_TYPE.ATTRIBUTE)
                            {
                                s_msg += "ATTRIBUTE ";
                            }
                            else if (m_cond_value_type == INPUT_VALUE_TYPE.TOOL)
                            {
                                s_msg += "TOOL ";
                            }
                            s_msg += "[" + spdItemInput.ActiveSheet.Cells[i, 1].Value.ToString() + "]";

                            MPCF.ShowMsgBox(s_msg);
                            spdItemInput.ActiveSheet.SetActiveCell(i, 3);
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool AddEmptyRow(int i_row)
        {
            if (m_cond_value_type == INPUT_VALUE_TYPE.ATTRIBUTE &&
                MPCF.Trim(spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.DELETE].Tag) != "" &&
                MPCF.Trim(spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.NULL].Value) != "True")
            {
                int first_row, last_row, new_row;

                //GetFirstRow
                first_row = GetFirstRow(MPCF.Trim(spdItemInput.ActiveSheet.Cells[i_row, 1].Tag), MPCF.Trim(spdItemInput.ActiveSheet.Cells[i_row, 3].Tag));
                //GetLastRow
                last_row = GetLastRow(i_row);

                if (i_row == last_row)
                {
                    FarPoint.Win.Spread.CellType.ButtonCellType btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    btnCell.Text = DEL_STRING;
                    spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.DELETE].CellType = btnCell;
                    spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.DELETE].Locked = false;

                    new_row = last_row + 1;
                    spdItemInput.ActiveSheet.Rows.Add(new_row, 1);
                    spdItemInput.ActiveSheet.CopyRange(last_row, 0, new_row, 0, 1, spdItemInput.ActiveSheet.ColumnCount, false);

                    spdItemInput.ActiveSheet.Cells[first_row, (int)SpdColum.PROMPT].RowSpan++;

                    spdItemInput.ActiveSheet.Cells[new_row, (int)SpdColum.CURRENT].Value = "";
                    spdItemInput.ActiveSheet.Cells[new_row, (int)SpdColum.NEW_VALUE].Value = "";

                    spdItemInput.ActiveSheet.Cells[new_row, (int)SpdColum.DELETE].CellType = null;
                    spdItemInput.ActiveSheet.Cells[new_row, (int)SpdColum.DELETE].Tag = MPCF.ToInt(spdItemInput.ActiveSheet.Cells[last_row, (int)SpdColum.DELETE].Tag) + 1;
                    spdItemInput.ActiveSheet.Cells[new_row, (int)SpdColum.DELETE].Locked = true;

                    spdItemInput.ActiveSheet.Cells[new_row, (int)SpdColum.DELETE].CellType = null;
                    spdItemInput.ActiveSheet.Cells[new_row, (int)SpdColum.NULL].Locked = true;

                    spdItemInput.ActiveSheet.SetActiveCell(new_row, (int)SpdColum.NEW_VALUE);

                    return true;
                }
            }

            return false;
        }

        public string GetArrayString(int i_row)
        {
            int i, first_row, last_row;
            string[] s_values = null;
            string seperator = "";

            //GetFirstRow
            first_row = GetFirstRow(MPCF.Trim(spdItemInput.ActiveSheet.Cells[i_row, 1].Tag), MPCF.Trim(spdItemInput.ActiveSheet.Cells[i_row, 3].Tag));
            //GetLastRow
            last_row = GetLastRow(i_row);
            //GetSeperator
            seperator = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i_row, (int)SpdColum.NULL].Tag);

            if (first_row != last_row && MPCF.Trim(spdItemInput.ActiveSheet.Cells[last_row, (int)SpdColum.NEW_VALUE].Value) == "")
            {
                last_row--;
            }

            s_values = new string[last_row - first_row + 1];

            for (i = 0; i < s_values.Length; i++)
            {
                s_values[i] = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i + first_row, (int)SpdColum.NEW_VALUE].Value);
            }

            return string.Join(seperator, s_values);
        }

        private int GetFirstRow(string attribute_type, string attribute_name)
        {
            int i;

            //GetFirstRow
            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                //Compare Attribute
                if (attribute_type == MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag) &&
                    attribute_name == MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Tag))
                {
                    return i;
                }
            }

            return -1;
        }

        private int GetLastRow(int start_index)
        {
            string attribute_type, attribute_name;
            int i, last_row;
            last_row = -1;

            attribute_type = MPCF.Trim(spdItemInput.ActiveSheet.Cells[start_index, 1].Tag);
            attribute_name = MPCF.Trim(spdItemInput.ActiveSheet.Cells[start_index, 3].Tag);

            //GetFirstRow
            for (i = start_index; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                //Compare AttributeName
                if (attribute_type == MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag) &&
                    attribute_name == MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 3].Tag))
                {
                    last_row = i;
                }
                else
                {
                    break;
                }
            }

            return last_row;
        }

    }
}

