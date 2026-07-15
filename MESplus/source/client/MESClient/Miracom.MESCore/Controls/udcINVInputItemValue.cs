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

    public partial class udcINVInputItemValue : UserControl
    {
        public udcINVInputItemValue()
        {
            InitializeComponent();
            Init();
        }

#region " Variable Definition "

        private INPUT_VALUE_POINT m_cond_point_type;
        private INPUT_VALUE_TYPE m_cond_value_type;

        //Added by Tommy Lee 2011.02.24 -2100(슬라이싱) 공정 End 시 Tool Event RES_ID를 초기화를 위해 적용
        private bool b_init_tool_res_id;

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


#endregion

#region "Control Events"

        private void pnlInputItem_Resize(object sender, EventArgs e)
        {
            int i_sheet_width = spdItemInput.Width - 25 - 22;
            int i_row_header_width = (int)spdItemInput.ActiveSheet.RowHeader.Columns[0].Width;
            int i_col_width;

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

            i_col_width = (int)(i_sheet_width - (i_row_header_width + spdItemInput.ActiveSheet.Columns[0].Width)) / 2;

            spdItemInput.ActiveSheet.Columns[1].Width = i_col_width + 30;
            spdItemInput.ActiveSheet.Columns[2].Width = i_col_width - 30;
        }

        private void spdInputItem_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string s_table_name = MPCF.Trim(spdItemInput.ActiveSheet.Cells[e.Row, 3].Tag);

            if (s_table_name != "")
            {
                cdvTableList.Init();
                cdvTableList.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTableList.GetListView);
                cdvTableList.Columns.Add("Table Name", 20, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Table Desc", 5, HorizontalAlignment.Left);
                cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                if (BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', s_table_name) == false)
                {
                    return;
                }

                cdvTableList.ShowPopupList(e.Row, e.Column);
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
        }

        private void cdvTableList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdItemInput.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;
        }

#endregion

        public void Init()
        {
            MPCF.ClearList(spdItemInput);
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
            char c_val_fmt;
            int i_val_size;
            string s_val_table_name;
            string s_val_value;
            //string s_apply_inch;

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
                in_node.ProcStep = '2';
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

            // Added by phillip 2010.04.01 Material의 Inch 정보
            ///s_apply_inch = View_Material_Inch(s_mat_id, i_mat_ver);

            switch (point_type)
            {
                case INPUT_VALUE_POINT.START: in_node.AddChar("POINT_TYPE", 'S'); break;
                case INPUT_VALUE_POINT.END: in_node.AddChar("POINT_TYPE", 'E'); break;
                case INPUT_VALUE_POINT.ADHOC: in_node.AddChar("POINT_TYPE", 'A'); break;
            }

            do
            {
                if (MPCR.CallService("PTS", "PTS_View_Operation_Input_Value_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                value_list = out_node.GetList("VALUE_LIST");

                for (i = 0; i < value_list.Count; i++)
                {
                    if (MPCF.Trim(value_list[i].GetString("APPLY_INCH")) != "" && 
                        MPCF.Trim(value_list[i].GetString("APPLY_INCH")) != "AL")
                    {
                        //if (s_apply_inch != MPCF.Trim(value_list[i].GetString("APPLY_INCH")))
                        //{
                        //    continue;
                        //}
                    }

                    //if attribute
                    if (m_cond_value_type == INPUT_VALUE_TYPE.ATTRIBUTE)
                    {
                        i_row = spdItemInput.ActiveSheet.RowCount;
                        spdItemInput.ActiveSheet.RowCount++;

                        spdItemInput.ActiveSheet.Cells[i_row, 0].Value = value_list[i].GetString("LOT_ID");

                        spdItemInput.ActiveSheet.Cells[i_row, 1].Value = value_list[i].GetString("DATA_3"); //Attribute Name Desc, Display Text

                        spdItemInput.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetString("DATA_1"); //Attribute Type
                        spdItemInput.ActiveSheet.Cells[i_row, 2].Tag = value_list[i].GetString("DATA_2"); //Attirbute Name

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

                        spdItemInput.ActiveSheet.Cells[i_row, 4].Value = value_list[i].GetChar("VALUE_TYPE"); // A : Attribute, C : Table-Column
                        spdItemInput.ActiveSheet.Cells[i_row, 5].Value = value_list[i].GetChar("DISPLAY_TYPE"); // V : View, I : Internal Input, U : User Input
                        spdItemInput.ActiveSheet.Cells[i_row, 8].Value = value_list[i].GetString("INPUT_VALUE_TYPE");

                        if (value_list[i].GetChar("DISPLAY_TYPE") == 'V')
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 2].BackColor = Color.WhiteSmoke;
                            spdItemInput.ActiveSheet.Cells[i_row, 2].Locked = true;
                        }
                        else if (value_list[i].GetChar("DISPLAY_TYPE") == 'I')
                        {
                            spdItemInput.ActiveSheet.Rows[i_row].Visible = false;
                        }

                        c_val_fmt = 'A';
                        i_val_size = 0;
                        s_val_table_name = "";
                        s_val_value = "";

                        if (value_list[i].GetChar("VALUE_TYPE") == 'A')
                        {
                            //// c_val_fmt값을 아스키 값으로.. - Test by J.K Park 2011.02.18
                            //if(value_list[i].GetString("DATA_5") == "")
                            //{
                            //    c_val_fmt = value_list[i].GetChar("ATTR_FMT");
                            //}
                            c_val_fmt = value_list[i].GetChar("ATTR_FMT");
                            i_val_size = value_list[i].GetInt("ATTR_SIZE");
                            s_val_table_name = value_list[i].GetString("VALID_TBL");
                            s_val_value = value_list[i].GetString("ATTR_VALUE");
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



                        // 사용회차를 사용할 경우 ColumnSpan 제외 - Modify by J.K Park 2011.02.09
                        if (s_val_table_name == "" && MPCF.Trim(value_list[i].GetString("DATA_5")) == "")
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 2].ColumnSpan = 2;
                            
                        }
                        else if(s_val_table_name != "")
                        {
                            btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            btnCell.Text = "...";
                            spdItemInput.ActiveSheet.Cells[i_row, 3].CellType = btnCell;
                            spdItemInput.ActiveSheet.Cells[i_row, 3].Tag = s_val_table_name;
                            // add by J.K Park - 2011.03.07    버튼선택값 외 입력을 막는다.
                            spdItemInput.ActiveSheet.Cells[i_row, 2].Locked = true;
                        }
                        else if (MPCF.Trim(value_list[i].GetString("DATA_5")) != "")
                        {
                            s_val_table_name = value_list[i].GetString("DATA_5");
                            btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            btnCell.Text = "...";
                            spdItemInput.ActiveSheet.Cells[i_row, 3].CellType = btnCell;
                            spdItemInput.ActiveSheet.Cells[i_row, 3].Tag = s_val_table_name;
                            // add by J.K Park - 2011.03.07    버튼선택값 외 입력을 막는다.
                            spdItemInput.ActiveSheet.Cells[i_row, 2].Locked = true;
                        }

                        spdItemInput.ActiveSheet.Cells[i_row, 2].CellType = cellType;


                        if (value_list[i].GetChar("DISPLAY_TYPE") == 'V')
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 2].Value = s_val_value;
                        }

                        if (value_list[i].GetChar("DISPLAY_TYPE") == 'I' || value_list[i].GetChar("DISPLAY_TYPE") == 'U')
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 7].Value = 'T';
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
                                    if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[k, 0].Value).Equals(value_list[i].GetString("DATA_1") + " 공통") &&
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

                            spdItemInput.ActiveSheet.Cells[i_row, 0].Value = value_list[i].GetString("DATA_1") + " 공통";
                            spdItemInput.ActiveSheet.Cells[i_row, 0].Tag = "COMMON";
                        }

                        spdItemInput.ActiveSheet.Cells[i_row, 1].Value = value_list[i].GetString("DATA_2"); //Tool Status

                        spdItemInput.ActiveSheet.Cells[i_row, 1].Tag = value_list[i].GetString("DATA_1"); //Tool Type
                        spdItemInput.ActiveSheet.Cells[i_row, 2].Tag = value_list[i].GetInt("STS_SEQ"); //Tool Status Sequence
                        spdItemInput.ActiveSheet.Cells[i_row, 6].Value = value_list[i].GetString("DATA_3"); //Tool Event

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

                        spdItemInput.ActiveSheet.Cells[i_row, 4].Value = value_list[i].GetChar("VALUE_TYPE"); // T : Tool
                        spdItemInput.ActiveSheet.Cells[i_row, 5].Value = value_list[i].GetChar("DISPLAY_TYPE"); // V : View, I : Internal Input, U : User Input
                        spdItemInput.ActiveSheet.Cells[i_row, 8].Value = value_list[i].GetString("INPUT_VALUE_TYPE");

                        if (value_list[i].GetChar("DISPLAY_TYPE") == 'V')
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 2].BackColor = Color.WhiteSmoke;
                            spdItemInput.ActiveSheet.Cells[i_row, 2].Locked = true;
                        }
                        else if (value_list[i].GetChar("DISPLAY_TYPE") == 'I')
                        {
                            spdItemInput.ActiveSheet.Rows[i_row].Visible = false;
                        }

                        c_val_fmt = 'A';
                        i_val_size = 0;
                        s_val_table_name = "";
                        s_val_value = "";

                        //// c_val_fmt값을 아스키 값으로.. - Test by J.K Park 2011.02.18
                        //if (value_list[i].GetString("DATA_5") == "")
                        //{
                        //    c_val_fmt = value_list[i].GetChar("STS_FMT");
                        //}
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

                        // 사용회차를 사용할 경우 ColumnSpan 제외 - Modify by J.K Park 2011.02.09
                        if (MPCF.Trim(value_list[i].GetString("DATA_5")) == "")
                        {
                           spdItemInput.ActiveSheet.Cells[i_row, 2].ColumnSpan = 2;
                        }
                        else if (MPCF.Trim(value_list[i].GetString("DATA_5")) != "")
                        {
                            s_val_table_name = value_list[i].GetString("DATA_5");
                            btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            btnCell.Text = "...";
                            spdItemInput.ActiveSheet.Cells[i_row, 3].CellType = btnCell;
                            spdItemInput.ActiveSheet.Cells[i_row, 3].Tag = s_val_table_name;
                            // add by J.K Park - 2011.03.07    버튼선택값 외 입력을 막는다.
                            spdItemInput.ActiveSheet.Cells[i_row, 2].Locked = true;
                        }

                        spdItemInput.ActiveSheet.Cells[i_row, 2].CellType = cellType;


                        if (value_list[i].GetChar("DISPLAY_TYPE") == 'V')
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 2].Value = s_val_value;
                        }

                        // add by J.K Park - 2011.03.21   'G' 또한 Tag 값을 입력 받을수 있게 수정
                        if (value_list[i].GetChar("DISPLAY_TYPE") == 'I' || value_list[i].GetChar("DISPLAY_TYPE") == 'U' || value_list[i].GetChar("DISPLAY_TYPE") == 'G')
                        {
                            spdItemInput.ActiveSheet.Cells[i_row, 7].Value = 'T';
                        }
                    }//end if tool
                }//end for

                in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
            } while (in_node.GetInt("NEXT_SEQ") > 0);

            SetUseCount(1);
            SetCurrentTime();

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
            string s_item_value;
            string s_tool_type;
            string s_tool_type_cur;
            string s_tool_event;
            string s_tool_event_cur;

            TRSNode item_in;
            TRSNode item_value;

            TRSNode tool_in = null;
            TRSNode tool_out = null;
            TRSNode tool_event_in = null;
            TRSNode tool_event_out = null;
            List<TRSNode> event_change_list;
            string s_change_item;


            if (CheckItemInputValue() == false) return false;

            s_attr_type = s_attr_type_cur = "";
            s_tool_type = s_tool_type_cur = "";
            s_tool_event = s_tool_event_cur = "";
            s_tool_id = s_tool_id_cur = "";
            item_in = null;

            while (true)
            {
                i_save_count = 0;
                for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
                {
                    c_saved_flag = MPCF.ToChar(spdItemInput.ActiveSheet.Cells[i, 7].Value);    // Y : Saved, T : Target
                    if (c_saved_flag != 'T') continue;

                    if (m_cond_value_type == INPUT_VALUE_TYPE.ATTRIBUTE)
                    {
                        s_key_id = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Value);
                        s_attr_type = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag);
                        s_item_name = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 2].Tag);
                        s_item_value = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 2].Value);

                        if (s_attr_type_cur == "")
                        {
                            s_attr_type_cur = s_attr_type;

                            item_in = in_node.AddNode("INPUT_ATTRIBUTE");

                            MPCR.SetInMsg(item_in);
                            item_in.ProcStep = '1';

                            item_in.AddString("ATTR_TYPE", s_attr_type);
                            item_in.AddString("ATTR_KEY", s_key_id);
                        }

                        if (s_attr_type_cur == s_attr_type)
                        {
                            item_value = item_in.AddNode("VALUE_LIST");
                            item_value.AddString("ATTR_NAME", s_item_name);
                            item_value.AddString("ATTR_VALUE", s_item_value);

                            spdItemInput.ActiveSheet.Cells[i, 7].Value = 'Y';
                            i_save_count++;
                        }
                    }
                    else if (m_cond_value_type == INPUT_VALUE_TYPE.TOOL)
                    {
                        if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Tag) == "COMMON" && s_tool_id_cur == "")
                        {
                            spdItemInput.ActiveSheet.Cells[i, 7].Value = 'Y';
                            continue;
                        }

                        s_tool_id = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Value);          // Tool ID
                        s_tool_type = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 1].Tag);          // Tool Type
                        i_sts_seq = MPCF.ToInt(spdItemInput.ActiveSheet.Cells[i, 2].Tag);           // Tool Status Sequence
                        s_item_value = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 2].Value);       // Tool Status Value
                        s_tool_event = MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 6].Value);       // Tool Event

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
                            
                            //Added by Tommy Lee 2011.02.24 -2100(슬라이싱) 공정 End 시 Tool Event RES_ID를 초기화를 위해 적용
                            item_in.AddString("RES_ID", b_init_tool_res_id == false ? in_node.GetString("RES_ID") : "");
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

                        if (s_tool_event_cur == s_tool_event && s_tool_type_cur == s_tool_type &&
                            (s_tool_id_cur == s_tool_id || MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Tag) == "COMMON"))
                        {
                            item_in.GetList(0)[i_sts_seq - 1].SetString("TOOL_STS", s_item_value);
                            

                            if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 0].Tag) != "COMMON")
                            {
                                spdItemInput.ActiveSheet.Cells[i, 7].Value = 'Y';
                            }
                            i_save_count++;
                        }
                        
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
                c_saved_flag = MPCF.ToChar(spdItemInput.ActiveSheet.Cells[i, 7].Value);    // Y : Saved, T : Target

                if (c_saved_flag == 'Y')
                {
                    spdItemInput.ActiveSheet.Cells[i, 7].Value = 'T';
                }
            }

            return true;
        }


        public void SetLotQty(double d_lot_qty)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 8].Value) == "LQ")
                {
                    spdItemInput.ActiveSheet.Cells[i, 2].Value = d_lot_qty;
                }
            }
        }

        public void SetLotCount(int i_lot_count)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 8].Value) == "LC")
                {
                    spdItemInput.ActiveSheet.Cells[i, 2].Value = i_lot_count;
                }
            }
        }

        public void SetUseCount(int i_use_count)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 8].Value) == "UC")
                {
                    spdItemInput.ActiveSheet.Cells[i, 2].Value = i_use_count;
                }
            }
        }

        public void SetUseResource(string s_res_id)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 8].Value) == "UR")
                {
                    spdItemInput.ActiveSheet.Cells[i, 2].Value = s_res_id;
                }
            }
        }

        public void SetUseTool(string s_tool_id)
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 8].Value) == "UT")
                {
                    spdItemInput.ActiveSheet.Cells[i, 2].Value = s_tool_id;
                }
            }
        }

        public void SetCurrentTime()
        {
            int i;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 8].Value) == "CT")
                {
                    spdItemInput.ActiveSheet.Cells[i, 2].Value = DateTime.Now.ToString("yyyyMMddHHmmss");
                }
            }
        }

        private bool CheckItemInputValue()
        {
            int i;
            char c_saved_flag;
            bool b_required_field;

            for (i = 0; i < spdItemInput.ActiveSheet.RowCount; i++)
            {
                b_required_field = false;
                if (spdItemInput.ActiveSheet.Cells[i, 1].Font != null && spdItemInput.ActiveSheet.Cells[i, 1].Font.Bold == true)
                    b_required_field = true;

                c_saved_flag = MPCF.ToChar(spdItemInput.ActiveSheet.Cells[i, 7].Value);    // Y : Saved, T : Target

                if (c_saved_flag == 'T')
                {
                    if (b_required_field == true)
                    {
                        if (MPCF.Trim(spdItemInput.ActiveSheet.Cells[i, 2].Value) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            spdItemInput.ActiveSheet.SetActiveCell(i, 2);
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        //// Added by Phillip 2009.04.01 해당 Material의 Inch 정보
        //private string View_Material_Inch(string sMatID, int iMatVer)
        //{
        //    TRSNode in_node = new TRSNode("View_Material_In");
        //    TRSNode out_node = new TRSNode("View_Material_Out");

        //    MPCR.SetInMsg(in_node);
        //    in_node.ProcStep = '1';
        //    in_node.AddString("MAT_ID", sMatID);
        //    in_node.AddInt("MAT_VER", iMatVer);

        //    if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
        //    {
        //        return " ";
        //    }

        //    return MPCF.Trim(out_node.GetDouble("DIMENSION_HR").ToString("00"));
        //}

        public bool SetToolEventInitResID
        {
            get
            {
                return b_init_tool_res_id;
            }
            set
            {
                b_init_tool_res_id = value;
            }
        }
        
    }
}
