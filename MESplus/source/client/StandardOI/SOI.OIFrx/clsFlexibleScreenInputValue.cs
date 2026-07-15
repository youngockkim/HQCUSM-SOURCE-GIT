using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Miracom.TRSCore;

namespace SOI.OIFrx
{
    public enum FSCREEN_CELL_TYPE
    {
        GENERAL = 0,
        TEXT,
        NUMBER,
        FLOAT,
        COMBOBOX,
        DATETIME,
        DATE,
        TIME,
        IMAGE,
        HYPERLINK,
        BUTTON,
        CHECKBOX,
        MULTIOPTION,
        MASK,
        MTEXT,
        VIEW_ONLY
    }

    public class clsFlexibleScreenInputValue
    {
        private struct COMBO_ITEM_TAG
        {
            public string key;
            public string desc;
        }

        private class clsInputCell
        {
            public string member_name;
            public FSCREEN_CELL_TYPE cell_type;
            public List<COMBO_ITEM_TAG> items;
            public int value_size;
            public Color back_color;
            public bool required_flag;
            public char input_flag;
            public bool multi_line_flag;
            public string checkbox_desc;
            public bool display_desc_flag;

            public object input_value;
            public string input_file_name;
        }

        private List<clsInputCell> ml_cells;

        private clsInputCell GetCell(string s_member_name)
        {
            if (MPCF.Trim(s_member_name) == "")
            {
                MPCF.ShowMsgBox("No Member Named for input value on flexible screen.");
                return null;
            }

            if (ml_cells == null)
            {
                MPCF.ShowMsgBox("Empty cell information.");
                return null;
            }

            for (int i = 0; i < ml_cells.Count; i++)
            {
                if (s_member_name == ml_cells[i].member_name)
                {
                    return ml_cells[i];
                }
            }

            MPCF.ShowMsgBox("No have Member in Cell List.");
            return null;
        }

        public int Count
        {
            get
            {
                if (ml_cells == null)
                {
                    return 0;
                }

                return ml_cells.Count;
            }
        }

        public void AddCell(string s_member_name, FSCREEN_CELL_TYPE cell_type, char input_flag)
        {
            AddCell(s_member_name, cell_type, 0, Color.Empty, false, input_flag, null, null);
        }

        public void AddCell(string s_member_name, FSCREEN_CELL_TYPE cell_type, char input_flag, bool required_flag)
        {
            AddCell(s_member_name, cell_type, 0, Color.Empty, required_flag, input_flag, null, null);
        }

        public void AddCell(string s_member_name, FSCREEN_CELL_TYPE cell_type, int i_size, char input_flag)
        {
            AddCell(s_member_name, cell_type, i_size, Color.Empty, false, input_flag, null, null);
        }

        public void AddCell(string s_member_name, FSCREEN_CELL_TYPE cell_type, int i_size, char input_flag, bool required_flag)
        {
            AddCell(s_member_name, cell_type, i_size, Color.Empty, required_flag, input_flag, null, null);
        }

        public void AddCell(string s_member_name, FSCREEN_CELL_TYPE cell_type, Color bg, char input_flag)
        {
            AddCell(s_member_name, cell_type, 0, bg, false, input_flag, null, null);
        }

        public void AddCell(string s_member_name, FSCREEN_CELL_TYPE cell_type, Color bg, char input_flag, bool required_flag)
        {
            AddCell(s_member_name, cell_type, 0, bg, required_flag, input_flag, null, null);
        }

        public void AddCell(string s_member_name, FSCREEN_CELL_TYPE cell_type, int i_size, Color bg, char input_flag)
        {
            AddCell(s_member_name, cell_type, i_size, bg, false, input_flag, null, null);
        }

        public void AddCell(string s_member_name, FSCREEN_CELL_TYPE cell_type, int i_size, Color bg, char input_flag, bool required_flag)
        {
            AddCell(s_member_name, cell_type, i_size, bg, required_flag, input_flag, null, null);
        }

        public void AddCell(string s_member_name, FSCREEN_CELL_TYPE cell_type, object input_value)
        {
            AddCell(s_member_name, cell_type, 0, Color.Empty, false, 'I', input_value, null);
        }

        public void AddCell(string s_member_name, FSCREEN_CELL_TYPE cell_type, object input_value, string input_file_name)
        {
            AddCell(s_member_name, cell_type, 0, Color.Empty, false, 'I', input_value, input_file_name);
        }

        private void AddCell(string s_member_name, FSCREEN_CELL_TYPE cell_type, int i_size, Color bg, bool required_flag, char input_flag, object input_value, string input_file_name)
        {
            clsInputCell cell;

            if (MPCF.Trim(s_member_name) == "")
            {
                MPCF.ShowMsgBox("No Member Named for input value on flexible screen.");
                return;
            }

            if (ml_cells == null)
            {
                ml_cells = new List<clsInputCell>();
            }

            cell = new clsInputCell();
            cell.member_name = s_member_name;
            cell.cell_type = cell_type;
            cell.value_size = i_size;
            cell.back_color = bg;
            cell.required_flag = required_flag;
            cell.input_flag = input_flag;

            cell.input_value = input_value;
            cell.input_file_name = input_file_name;

            ml_cells.Add(cell);
        }

        public void SetComboItem(string s_member_name, string s_key, string s_desc)
        {
            clsInputCell cell;
            COMBO_ITEM_TAG item;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return;
            }

            if (cell.items == null)
            {
                cell.items = new List<COMBO_ITEM_TAG>();
            }

            item = new COMBO_ITEM_TAG();
            item.key = s_key;
            item.desc = s_desc;
            cell.items.Add(item);
        }

        public void SetInputValue(string s_member_name, object input_value)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return;
            }

            cell.input_value = input_value;
        }

        public void SetInputFileName(string s_member_name, string input_file_name)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return;
            }

            cell.input_file_name = input_file_name;
        }

        public void SetMultiLineFlag(string s_member_name, bool multi_line_flag)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return;
            }

            cell.multi_line_flag = multi_line_flag;
        }

        public void SetDisplayDescFlag(string s_member_name, bool display_desc_flag)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return;
            }

            cell.display_desc_flag = display_desc_flag;
        }

        public void SetCheckBoxDesc(string s_member_name, string checkbox_desc)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return;
            }

            cell.checkbox_desc = checkbox_desc;
        }

        public string GetName(int index)
        {
            if (ml_cells == null)
            {
                MPCF.ShowMsgBox("Empty cell information.");
                return null;
            }

            if (index > ml_cells.Count - 1)
            {
                MPCF.ShowMsgBox("Out of range for the cells list.");
                return null;
            }

            return ml_cells[index].member_name;
        }

        public int GetValueSize(string s_member_name)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return 0;
            }

            return cell.value_size;
        }

        public Color GetBackColor(string s_member_name)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return Color.Empty;
            }

            return cell.back_color;
        }

        public FSCREEN_CELL_TYPE GetCellType(string s_member_name)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return FSCREEN_CELL_TYPE.GENERAL;
            }

            return cell.cell_type;
        }

        public bool GetRequiredFlag(string s_member_name)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return false;
            }

            return cell.required_flag;
        }

        public char GetInputFlag(string s_member_name)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return ' ';
            }

            return cell.input_flag;
        }

        public bool GetMultiLineFlag(string s_member_name)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return false;
            }

            return cell.multi_line_flag;
        }

        public bool GetDisplayDescFlag(string s_member_name)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return false;
            }

            return cell.display_desc_flag;
        }

        public string GetCheckBoxDesc(string s_member_name)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return "";
            }

            return cell.checkbox_desc;
        }

        public string[] GetComboItems(string s_member_name)
        {
            clsInputCell cell;
            string[] items;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return null;
            }

            if (cell.items == null)
            {
                return new string[0];
            }

            items = new string[cell.items.Count];

            for (int i = 0; i < cell.items.Count; i++)
            {
                if (MPCF.Trim(cell.items[i].desc) == "")
                {
                    items[i] = cell.items[i].key;
                }
                else
                {
                    items[i] = cell.items[i].key + " : " + cell.items[i].desc;
                }
            }

            return items;
        }

        public object GetInputValue(string s_member_name)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return null;
            }

            return cell.input_value;
        }

        public string GetInputFileName(string s_member_name)
        {
            clsInputCell cell;

            if ((cell = GetCell(s_member_name)) == null)
            {
                return null;
            }

            return cell.input_file_name;
        }

        public void SetInputValueToTRSNode(TRSNode node)
        {
            int i;
            int i_bin_data_count;

            if (ml_cells == null || ml_cells.Count < 1)
            {
                return;
            }

            i_bin_data_count = 1;
            for (i = 0; i < ml_cells.Count; i++)
            {
                switch (ml_cells[i].cell_type)
                {
                    case FSCREEN_CELL_TYPE.TEXT:
                    case FSCREEN_CELL_TYPE.NUMBER:
                    case FSCREEN_CELL_TYPE.FLOAT:
                        if (ml_cells[i].input_value != null && MPCF.Trim(ml_cells[i].input_value) != "")
                        {
                            node.AddString(ml_cells[i].member_name, ml_cells[i].input_value);
                        }
                        break;
                    case FSCREEN_CELL_TYPE.COMBOBOX:
                        if (ml_cells[i].input_value != null && MPCF.Trim(ml_cells[i].input_value) != "")
                        {
                            string[] s_temp = ml_cells[i].input_value.ToString().Split(':');
                            node.AddString(ml_cells[i].member_name, MPCF.Trim(s_temp[0]));
                        }
                        break;
                    case FSCREEN_CELL_TYPE.DATETIME:
                        if (ml_cells[i].input_value != null && MPCF.Trim(ml_cells[i].input_value) != "")
                        {
                            node.AddString(ml_cells[i].member_name, ml_cells[i].input_value);
                        }
                        break;
                    case FSCREEN_CELL_TYPE.DATE:
                        if (ml_cells[i].input_value != null && MPCF.Trim(ml_cells[i].input_value) != "")
                        {
                            node.AddString(ml_cells[i].member_name, ml_cells[i].input_value);
                        }
                        break;
                    case FSCREEN_CELL_TYPE.TIME:
                        if (ml_cells[i].input_value != null && MPCF.Trim(ml_cells[i].input_value) != "")
                        {
                            node.AddString(ml_cells[i].member_name, ml_cells[i].input_value);
                        }
                        break;
                    case FSCREEN_CELL_TYPE.CHECKBOX:
                        if (ml_cells[i].input_value != null)
                        {
                            string s_check = Convert.ToBoolean(ml_cells[i].input_value) == true ? "Y" : "";
                            node.AddString(ml_cells[i].member_name, s_check);
                        }
                        break;
                    case FSCREEN_CELL_TYPE.IMAGE:
                    case FSCREEN_CELL_TYPE.HYPERLINK:
                        if (ml_cells[i].input_value != null && i_bin_data_count <= 10)
                        {
                            string s_temp;
                            byte[] byte_buffer;

                            s_temp = i_bin_data_count.ToString("00") + ":" + ml_cells[i].input_file_name;
                            node.AddString(ml_cells[i].member_name, s_temp);

                            s_temp = MPGC.MP_BIN_DATA_1.Substring(0, MPGC.MP_BIN_DATA_1.Length - 1);
                            s_temp += i_bin_data_count.ToString();
                            i_bin_data_count++;

                            byte_buffer = (byte[])ml_cells[i].input_value;
                            node.AddBlob(s_temp, byte_buffer);
                        }
                        break;
                }
            }
        }
    }
}
