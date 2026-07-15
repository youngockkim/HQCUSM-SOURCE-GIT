using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Miracom.UI;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.MESCore.Controls
{
    public partial class udcToolStatus : UserControl
    {
        #region " Constant "

        private const string ITEM_TOOL_GRP = "TOOL_GRP";
        private const string ITEM_TOOL_SET_ID = "TOOL_SET_ID";
        private const string ITEM_TOOL_SET_LOCATION = "TOOL_SET_LOCATION";
        private const string ITEM_TOOL_STATUS = "TOOL_STATUS";
        private const string ITEM_LOT_ID = "LOT_ID";
        private const string ITEM_SUBLOT_ID = "SUBLOT_ID";
        private const string ITEM_RES_ID = "RES_ID";
        private const string ITEM_SUBRES_ID = "SUBRES_ID";
        private const string ITEM_AREA_ID = "AREA_ID";
        private const string ITEM_SUB_AREA_ID = "SUB_AREA_ID";
        private const string ITEM_TOOL_LOCATION = "TOOL_LOCATION";
        private const string ITEM_VENDOR_ID = "VENDOR_ID";
        private const string ITEM_MAT_ID = "MAT_ID";
        private const string ITEM_MAT_VER = "MAT_VER";
        private const string ITEM_FLOW = "FLOW";
        private const string ITEM_OPER = "OPER";
        private const string ITEM_GRADE = "GRADE";

        private const string ITEM_TOOL_STS_ = "TOOL_STS_";


        private const char FLAG_INCREASE = '+';
        private const char FLAG_DECREASE = '-';
        private const char FLAG_MULTIPLY = '*';
        private const char FLAG_DIVISION = '/';
        private const char FLAG_MOD = 'M';
        private const char FLAG_POW = 'P';
        private const char FLAG_TIME = 'T';
        private const char FLAG_RESET = 'R';
        private const char FLAG_CHANGE = 'Y';
        private const char FLAG_NOT_CHANGE = 'N';

        public int COL_STATUS_NAME = 0;
        public int COL_CURRENT_VALUE = 1;
        public int COL_INPUT_VALUE = 2;
        public int COL_INPUT_BUTTON = 3;
        public int COL_NEXT_VALUE = 4;

        #endregion

        #region " Variable "

        private char m_cond_c_step;
        //private string m_cond_s_filter;
        private string m_cond_s_ext_factory;
        private string m_cond_s_tool_type;
        private string m_cond_s_tool_id;
        private string m_cond_s_tool_event;

        private bool m_cond_b_visible_next_column = false;  //Don't Change Value


        #endregion

        #region " Properties "

        public char ListCond_Step
        {
            get
            {
                return m_cond_c_step;
            }
            set
            {
                m_cond_c_step = value;
            }
        }
        public string ListCond_ExtFactory
        {
            get
            {
                if (m_cond_s_ext_factory == null) m_cond_s_ext_factory = "";
                return m_cond_s_ext_factory;
            }
            set
            {
                m_cond_s_ext_factory = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_ToolType
        {
            get
            {
                if (m_cond_s_tool_type == null) m_cond_s_tool_type = "";
                return m_cond_s_tool_type;
            }
            set
            {
                m_cond_s_tool_type = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_ToolID
        {
            get
            {
                if (m_cond_s_tool_id == null) m_cond_s_tool_id = "";
                return m_cond_s_tool_id;
            }
            set
            {
                m_cond_s_tool_id = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_ToolEventID
        {
            get
            {
                if (m_cond_s_tool_event == null) m_cond_s_tool_event = "";
                return m_cond_s_tool_event;
            }
            set
            {
                m_cond_s_tool_event = value;
            }
        }
        [Description("View or Hide Last(4th) Column(='Tool Status Forecast')")]
        public bool VisibleNextStatusColumn
        {
            get
            {
                return m_cond_b_visible_next_column;
            }
            set
            {
                m_cond_b_visible_next_column = value;
                if (m_cond_b_visible_next_column == true) spdToolStatus_Sheet1.Columns[COL_INPUT_VALUE].Label = "Input Value";
                else spdToolStatus_Sheet1.Columns[COL_INPUT_VALUE].Label = "Tool Status Forecast";
                spdToolStatus_Sheet1.Columns[COL_NEXT_VALUE].Visible = m_cond_b_visible_next_column;
            }
        }

        #endregion

        public udcToolStatus()
        {
            InitializeComponent();
        }

        #region " Function "

        public void Init()
        {
            spdToolStatus_Sheet1.DefaultStyle.Locked = true;
            spdToolStatus_Sheet1.RowCount = 17;

            spdToolStatus_Sheet1.ClearRange(0, 0, 17, spdToolStatus_Sheet1.ColumnCount, false);
            for (int i = 0; i < 17; i++)
            {
                spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].ColumnSpan = 2;
            }

            spdToolStatus.ActiveSheet.Cells[0, 0].Value = "Tool Group";
            spdToolStatus.ActiveSheet.Cells[1, 0].Value = "Tool Set ID";
            spdToolStatus.ActiveSheet.Cells[2, 0].Value = "Tool Set Location";
            spdToolStatus.ActiveSheet.Cells[3, 0].Value = "Tool Status";
            spdToolStatus.ActiveSheet.Cells[4, 0].Value = "Lot ID";
            spdToolStatus.ActiveSheet.Cells[5, 0].Value = "Sub Lot ID";
            spdToolStatus.ActiveSheet.Cells[6, 0].Value = "Resource";
            spdToolStatus.ActiveSheet.Cells[7, 0].Value = "Sub Resource";
            spdToolStatus.ActiveSheet.Cells[8, 0].Value = "Area ID";
            spdToolStatus.ActiveSheet.Cells[9, 0].Value = "Sub Area ID";
            spdToolStatus.ActiveSheet.Cells[10, 0].Value = "Tool Location";
            spdToolStatus.ActiveSheet.Cells[11, 0].Value = "Vendor";
            spdToolStatus.ActiveSheet.Cells[12, 0].Value = "Material";
            spdToolStatus.ActiveSheet.Cells[13, 0].Value = "Material Ver";
            spdToolStatus.ActiveSheet.Cells[14, 0].Value = "Flow";
            spdToolStatus.ActiveSheet.Cells[15, 0].Value = "Operation";
            spdToolStatus.ActiveSheet.Cells[16, 0].Value = "Grade";

            /* Set Column Name */
            spdToolStatus.ActiveSheet.Cells[0, 0].Tag = ITEM_TOOL_GRP;
            spdToolStatus.ActiveSheet.Cells[1, 0].Tag = ITEM_TOOL_SET_ID;
            spdToolStatus.ActiveSheet.Cells[2, 0].Tag = ITEM_TOOL_SET_LOCATION;
            spdToolStatus.ActiveSheet.Cells[3, 0].Tag = ITEM_TOOL_STATUS;
            spdToolStatus.ActiveSheet.Cells[4, 0].Tag = ITEM_LOT_ID;
            spdToolStatus.ActiveSheet.Cells[5, 0].Tag = ITEM_SUBLOT_ID;
            spdToolStatus.ActiveSheet.Cells[6, 0].Tag = ITEM_RES_ID;
            spdToolStatus.ActiveSheet.Cells[7, 0].Tag = ITEM_SUBRES_ID;
            spdToolStatus.ActiveSheet.Cells[8, 0].Tag = ITEM_AREA_ID;
            spdToolStatus.ActiveSheet.Cells[9, 0].Tag = ITEM_SUB_AREA_ID;
            spdToolStatus.ActiveSheet.Cells[10, 0].Tag = ITEM_TOOL_LOCATION;
            spdToolStatus.ActiveSheet.Cells[11, 0].Tag = ITEM_VENDOR_ID;
            spdToolStatus.ActiveSheet.Cells[12, 0].Tag = ITEM_MAT_ID;
            spdToolStatus.ActiveSheet.Cells[13, 0].Tag = ITEM_MAT_VER;
            spdToolStatus.ActiveSheet.Cells[14, 0].Tag = ITEM_FLOW;
            spdToolStatus.ActiveSheet.Cells[15, 0].Tag = ITEM_OPER;
            spdToolStatus.ActiveSheet.Cells[16, 0].Tag = ITEM_GRADE;

            /* Set GCM Table Name */
            spdToolStatus.ActiveSheet.Cells[0, COL_INPUT_BUTTON].Tag = MPGC.MP_RAS_TOOL_GRP;
            spdToolStatus.ActiveSheet.Cells[1, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[2, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[3, COL_INPUT_BUTTON].Tag = MPGC.MP_RAS_TOOL_STATUS;
            spdToolStatus.ActiveSheet.Cells[4, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[5, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[6, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[7, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[8, COL_INPUT_BUTTON].Tag = MPGC.MP_RAS_AREA_CODE;
            spdToolStatus.ActiveSheet.Cells[9, COL_INPUT_BUTTON].Tag = MPGC.MP_RAS_SUBAREA_CODE;
            spdToolStatus.ActiveSheet.Cells[10, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[11, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[12, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[13, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[14, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[15, COL_INPUT_BUTTON].Tag = "";
            spdToolStatus.ActiveSheet.Cells[16, COL_INPUT_BUTTON].Tag = MPGC.MP_RAS_TOOL_GRADE;

        }

        public void Clear()
        {
            Clear("", "", "");
        }

        public void Clear(string tool_type, string tool_id, string tool_event)
        {
            m_cond_s_tool_event = tool_event;
            m_cond_s_tool_id = tool_id;
            m_cond_s_tool_type = tool_type;

            spdToolStatus_Sheet1.ClearRange(0, COL_NEXT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);

            if (m_cond_s_tool_event == "")
            {
                ResetFontCell();
                
                //ClearEventInfo
                spdToolStatus_Sheet1.ClearRange(0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);
                for (int i = 0; i < spdToolStatus_Sheet1.RowCount; i++)
                {
                    spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].ColumnSpan = 2;
                    spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].BackColor = Color.White;
                    spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Locked = true;
                }
            }
            if (m_cond_s_tool_id == "")
            {
                //ClearTool
                spdToolStatus_Sheet1.ClearRange(0, COL_CURRENT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);
                spdToolStatus_Sheet1.ClearRange(0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);
            }
            if (m_cond_s_tool_type == "")
            {
                if(spdToolStatus_Sheet1.RowCount > 17) spdToolStatus_Sheet1.RowCount = 17;
            }

        }

        public void ResetFontCell()
        {
            int i = 0;

            Font NormalFont = new Font(spdToolStatus.Font, FontStyle.Regular);
            for (i = 0; i < spdToolStatus_Sheet1.RowCount; i++)
            {
                spdToolStatus_Sheet1.Cells[i, COL_STATUS_NAME].Font = NormalFont;
            }
        }

        public Font BoldFont
        {
            get
            {
                Font BoldFont = new Font(spdToolStatus.Font, FontStyle.Bold);
                return BoldFont;
            }
        }

        public void View_Tool_Type(TRSNode tool_type_out)
        {
            TRSNode node;
            int i, i_row;

            m_cond_s_tool_type = tool_type_out.GetString("TOOL_TYPE");

            #region " Clear Sheet Cell "

            spdToolStatus_Sheet1.RowCount = 17;

            spdToolStatus_Sheet1.ClearRange(0, COL_CURRENT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);
            spdToolStatus_Sheet1.ClearRange(0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);
            spdToolStatus_Sheet1.ClearRange(0, COL_NEXT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);

            spdToolStatus_Sheet1.Cells[0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount - 1, COL_INPUT_VALUE].Locked = true;
            spdToolStatus_Sheet1.Cells[0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount - 1, COL_INPUT_VALUE].BackColor = Color.White;

            ResetFontCell();
            for (i = 0; i < spdToolStatus_Sheet1.RowCount; i++)
            {
                spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].ColumnSpan = 2;
            }

            #endregion

            try
            {
                FarPoint.Win.Spread.CellType.NumberCellType CellNumber = null;
                FarPoint.Win.Spread.CellType.TextCellType CellText = null;

                for (i = 0; i < tool_type_out.GetList("DATA_LIST").Count; i++)
                {
                    node = tool_type_out.GetList("DATA_LIST")[i];
                    node.SetInt("SEQ", i + 1);

                    if (node.GetString("PROMPT") == "") continue;

                    i_row = spdToolStatus_Sheet1.RowCount;
                    spdToolStatus_Sheet1.RowCount++;

                    /* Init Cell */
                    spdToolStatus_Sheet1.Rows[i_row].Tag = node;
                    spdToolStatus_Sheet1.Cells[i_row, COL_STATUS_NAME].Value = node.GetString("PROMPT");
                    spdToolStatus_Sheet1.Cells[i_row, COL_STATUS_NAME].Tag = node.GetString("FIELD");

                    spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].ColumnSpan = 2;
                    spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].Locked = true;
                    spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].BackColor = Color.White;

                    spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_BUTTON].Tag = node.GetString("TABLE_NAME");

                    spdToolStatus_Sheet1.Cells[i_row, COL_NEXT_VALUE].Locked = true;
                    spdToolStatus_Sheet1.Cells[i_row, COL_NEXT_VALUE].BackColor = SystemColors.Control;

                    /* Cell Type */
                    if (node.GetChar("FORMAT") == 'N')
                    {
                        CellNumber = new FarPoint.Win.Spread.CellType.NumberCellType();
                        CellNumber.DecimalPlaces = 0;
                        if (node.GetInt("SIZE") > 0 && node.GetInt("SIZE") <= 30)
                        {
                            CellNumber.MaximumValue = MPCF.ToInt(string.Empty.PadRight(node.GetInt("SIZE"), '9'));
                        }
                        spdToolStatus_Sheet1.Cells[i_row, COL_CURRENT_VALUE].CellType = CellNumber;
                    }
                    else if (node.GetChar("FORMAT") == 'F')
                    {
                        string[] size = MPCF.Trim(node.GetInt("SIZE")).Split('.');
                        if (size != null && size.Length >= 2)
                        {
                            CellNumber = new FarPoint.Win.Spread.CellType.NumberCellType();
                            CellNumber.DecimalPlaces = MPCF.ToInt(size[1]);
                            spdToolStatus_Sheet1.Cells[i_row, COL_CURRENT_VALUE].CellType = CellNumber;
                        }
                        else
                        {
                            CellText = new FarPoint.Win.Spread.CellType.TextCellType();
                            spdToolStatus_Sheet1.Cells[i_row, COL_CURRENT_VALUE].CellType = CellText;
                            spdToolStatus_Sheet1.Cells[i_row, COL_CURRENT_VALUE].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                        }
                    }
                    else if (node.GetChar("FORMAT") == 'A')
                    {
                        CellText = new FarPoint.Win.Spread.CellType.TextCellType();
                        if (node.GetInt("SIZE") > 0 && node.GetInt("SIZE") <= 30)
                        {
                            CellText.MaxLength = node.GetInt("SIZE");
                        }
                        else
                        {
                            CellText.MaxLength = 30;
                        }
                        spdToolStatus_Sheet1.Cells[i_row, COL_CURRENT_VALUE].CellType = CellText;
                    }

                    spdToolStatus_Sheet1.Cells[i_row, COL_NEXT_VALUE].CellType = spdToolStatus_Sheet1.Cells[i_row, COL_CURRENT_VALUE].CellType;
                    spdToolStatus_Sheet1.Cells[i_row, COL_NEXT_VALUE].HorizontalAlignment = spdToolStatus_Sheet1.Cells[i_row, COL_CURRENT_VALUE].HorizontalAlignment;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public void View_Tool_Type(string tool_type)
        {
            TRSNode in_node = new TRSNode("VIEW_TOOL_TYPE_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_TYPE_OUT");

            m_cond_s_tool_type = tool_type;

            spdToolStatus_Sheet1.RowCount = 17;

            ResetFontCell();

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", tool_type);

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type", in_node, ref out_node) == false)
                {
                    return;
                }

                View_Tool_Type(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public void View_Tool(string tool_id)
        {
            TRSNode in_node = new TRSNode("VIEW_TOOL_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_OUT");

            m_cond_s_tool_id = tool_id;

            spdToolStatus_Sheet1.ClearRange(0, COL_CURRENT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);
            spdToolStatus_Sheet1.ClearRange(0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);
            spdToolStatus_Sheet1.ClearRange(0, COL_NEXT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);

            if (m_cond_s_tool_event == "") ResetFontCell();

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", m_cond_s_tool_type);
                in_node.AddString("TOOL_ID", tool_id);

                if (MPCR.CallService("RAS", "RAS_View_Tool", in_node, ref out_node) == false)
                {
                    return;
                }

                View_Tool(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public void View_Tool(TRSNode tool_out)
        {
            TRSNode node;
            int i, i_row;
            string status_name;

            m_cond_s_tool_id = tool_out.GetString("TOOL_ID");

            #region " Clear Sheet Cell "

            spdToolStatus_Sheet1.ClearRange(0, COL_CURRENT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);
            spdToolStatus_Sheet1.ClearRange(0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);
            spdToolStatus_Sheet1.ClearRange(0, COL_NEXT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);

            spdToolStatus_Sheet1.Cells[0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount - 1, COL_INPUT_VALUE].Locked = true;
            spdToolStatus_Sheet1.Cells[0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount - 1, COL_INPUT_VALUE].BackColor = System.Drawing.SystemColors.Control;

            ResetFontCell();
            for (i = 0; i < spdToolStatus_Sheet1.RowCount; i++)
            {
                spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].ColumnSpan = 2;
            }

            #endregion
            
            if(m_cond_s_tool_event == "") ResetFontCell();

            try
            {
                //Fixed Status Value
                for (i = 0; i < 17; i++)
                {
                    status_name = MPCF.Trim(spdToolStatus_Sheet1.Cells[i, COL_STATUS_NAME].Tag);
                    if (tool_out.GetMember(status_name) != null)
                    {
                        spdToolStatus_Sheet1.Cells[i, COL_CURRENT_VALUE].Value = tool_out.GetMember(status_name).Value;
                    }
                }
                //ToolStatus(Prompt)
                for (i = 0; i < tool_out.GetList("STS_LIST").Count; i++)
                {
                    for (i_row = 17; i_row < spdToolStatus_Sheet1.RowCount; i_row++)
                    {
                        node = (TRSNode)spdToolStatus_Sheet1.Rows[i_row].Tag;
                        if ((i + 1) == node.GetInt("SEQ"))
                        {
                            spdToolStatus_Sheet1.Cells[i_row, COL_CURRENT_VALUE].Value = tool_out.GetList("STS_LIST")[i].GetString("TOOL_STS");
                            break;
                        }
                    }
                }

                if (ListCond_ToolType != "" && ListCond_ToolEventID != "")
                {
                    View_Tool_Status_Forecast();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public void View_Tool_Event(string tool_event)
        {
            TRSNode in_node = new TRSNode("VIEW_TOOL_TYPE_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_TYPE_OUT");
            int i;

            m_cond_s_tool_event = tool_event;

            spdToolStatus_Sheet1.ClearRange(0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);
            spdToolStatus_Sheet1.ClearRange(0, COL_NEXT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);

            spdToolStatus_Sheet1.Cells[0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount - 1, COL_INPUT_VALUE].Locked = true;
            spdToolStatus_Sheet1.Cells[0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount - 1, COL_INPUT_VALUE].BackColor = System.Drawing.SystemColors.Control;
            
            ResetFontCell();
            for (i = 0; i < spdToolStatus_Sheet1.RowCount; i++)
            {
                spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].ColumnSpan = 2;
            }

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", m_cond_s_tool_type);
                in_node.AddString("TOOL_EVENT_ID", tool_event);

                if (MPCR.CallService("RAS", "RAS_View_Tool_Event", in_node, ref out_node) == false)
                {
                    return;
                }

                View_Tool_Event(out_node);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        public void View_Tool_Event(TRSNode tool_event_out)
        {
            TRSNode tool_event_info, temp_node;
            int i, i_row;

            FarPoint.Win.Spread.CellType.ButtonCellType CellButton = null;
            FarPoint.Win.Spread.CellType.NumberCellType CellNumber = null;
            FarPoint.Win.Spread.CellType.TextCellType CellText = null;

            m_cond_s_tool_event = tool_event_out.GetString("TOOL_EVENT_ID");

            #region " Clear Sheet Cell "

            spdToolStatus_Sheet1.ClearRange(0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);
            spdToolStatus_Sheet1.ClearRange(0, COL_NEXT_VALUE, spdToolStatus_Sheet1.RowCount, 1, true);

            spdToolStatus_Sheet1.Cells[0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount - 1, COL_INPUT_VALUE].Locked = true;
            spdToolStatus_Sheet1.Cells[0, COL_INPUT_VALUE, spdToolStatus_Sheet1.RowCount - 1, COL_INPUT_VALUE].BackColor = System.Drawing.SystemColors.Control;

            ResetFontCell();
            for (i = 0; i < spdToolStatus_Sheet1.RowCount; i++)
            {
                spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].ColumnSpan = 2;
            }

            #endregion

            try
            {
                for (int n = 0; n < spdToolStatus_Sheet1.RowCount; n++)
                {
                    tool_event_info = null;
                    temp_node = null;
                    i_row = -1;

                    spdToolStatus_Sheet1.Cells[n, COL_INPUT_VALUE].CellType = spdToolStatus_Sheet1.Cells[n, COL_CURRENT_VALUE].CellType;
                    for (i = 0; i < tool_event_out.GetList("CHG_LIST").Count; i++)
                    {
                        tool_event_info = tool_event_out.GetList("CHG_LIST")[i];
                        if (tool_event_info.GetString("CHG_ITEM") == MPCF.Trim(spdToolStatus_Sheet1.Cells[n, COL_STATUS_NAME].Tag))
                        {
                            i_row = n;
                            break;
                        }
                    }
                    if (i_row == -1) tool_event_info = null;

                    if (spdToolStatus_Sheet1.Rows[n].Tag == null)
                    {
                        spdToolStatus_Sheet1.Rows[n].Tag = tool_event_info;
                    }
                    else
                    {
                        temp_node = (TRSNode)spdToolStatus_Sheet1.Rows[n].Tag;
                        if (tool_event_info == null)
                        {
                            temp_node.SetString("CHG_ITEM", "");
                            temp_node.SetChar("CHG_FLAG", ' ');
                            temp_node.SetString("CHG_VALUE", "");
                            temp_node.SetString("CHG_FIELD", "");
                            temp_node.SetChar("CHG_OPT", ' ');
                        }
                        else
                        {
                            temp_node.SetString("CHG_ITEM", tool_event_info.GetString("CHG_ITEM"));
                            temp_node.SetChar("CHG_FLAG", tool_event_info.GetChar("CHG_FLAG"));
                            temp_node.SetString("CHG_VALUE", tool_event_info.GetString("CHG_VALUE"));
                            temp_node.SetString("CHG_FIELD", tool_event_info.GetString("CHG_FIELD"));
                            temp_node.SetChar("CHG_OPT", tool_event_info.GetChar("CHG_OPT"));
                        }
                    }

                    if (spdToolStatus_Sheet1.Rows[i_row].Tag == null) continue;

                    tool_event_info = (TRSNode)spdToolStatus_Sheet1.Rows[i_row].Tag;

                    switch (tool_event_info.GetChar("CHG_FLAG"))
                    {
                        case FLAG_NOT_CHANGE:
                            break;
                        case FLAG_RESET:
                            break;
                        case FLAG_TIME:
                            break;
                        default:

                            if (tool_event_info.GetString("CHG_VALUE") == "" && tool_event_info.GetString("CHG_FIELD") == "")
                            {
                                #region " User Input Cell "

                                spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].Locked = false;
                                spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].BackColor = Color.White;

                                //정수만 가능
                                if (tool_event_info.GetChar("CHG_FLAG") == FLAG_INCREASE ||
                                    tool_event_info.GetChar("CHG_FLAG") == FLAG_DECREASE ||
                                    tool_event_info.GetChar("CHG_FLAG") == FLAG_MULTIPLY ||
                                    tool_event_info.GetChar("CHG_FLAG") == FLAG_DIVISION ||
                                    tool_event_info.GetChar("CHG_FLAG") == FLAG_MOD ||
                                    tool_event_info.GetChar("CHG_FLAG") == FLAG_POW)
                                {
                                    CellNumber = new FarPoint.Win.Spread.CellType.NumberCellType();
                                    CellNumber.DecimalPlaces = 0;
                                    spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].CellType = CellNumber;
                                }
                                else if (tool_event_info.GetChar("CHG_FLAG") == FLAG_TIME)
                                {
                                }
                                else if (tool_event_info.GetChar("CHG_FLAG") == FLAG_CHANGE)
                                {
                                    if (tool_event_info.GetChar("FORMAT") == 'N')
                                    {
                                        CellNumber = new FarPoint.Win.Spread.CellType.NumberCellType();
                                        CellNumber.DecimalPlaces = 0;
                                        if (tool_event_info.GetInt("SIZE") > 0 && tool_event_info.GetInt("SIZE") <= 30)
                                        {
                                            CellNumber.MaximumValue = MPCF.ToInt(string.Empty.PadRight(tool_event_info.GetInt("SIZE"), '9'));
                                        }
                                        spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].CellType = CellNumber;
                                    }
                                    else if (tool_event_info.GetChar("FORMAT") == 'F')
                                    {
                                        string[] size = MPCF.Trim(tool_event_info.GetInt("SIZE")).Split('.');
                                        if (size != null && size.Length >= 2)
                                        {
                                            CellNumber = new FarPoint.Win.Spread.CellType.NumberCellType();
                                            CellNumber.DecimalPlaces = MPCF.ToInt(size[1]);
                                            spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].CellType = CellNumber;
                                        }
                                        else
                                        {
                                            CellText = new FarPoint.Win.Spread.CellType.TextCellType();
                                            spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].CellType = CellText;
                                            spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                                        }
                                    }
                                    else if (tool_event_info.GetChar("FORMAT") == 'A')
                                    {
                                        CellText = new FarPoint.Win.Spread.CellType.TextCellType();
                                        if (tool_event_info.GetInt("SIZE") > 0 && tool_event_info.GetInt("SIZE") <= 30)
                                        {
                                            CellText.MaxLength = tool_event_info.GetInt("SIZE");
                                        }
                                        else
                                        {
                                            CellText.MaxLength = 30;
                                        }
                                        spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].CellType = CellText;
                                    }
                                }

                                #endregion

                                if (MPCF.Trim(spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_BUTTON].Tag) != "")
                                {
                                    #region " Set GCM Table CodeView Button "
                                    //Devide Cell
                                    spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].ColumnSpan = 1;
                                    spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].Locked = true;

                                    //Button Cell
                                    CellButton = new FarPoint.Win.Spread.CellType.ButtonCellType();
                                    CellButton.Text = "...";
                                    spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_BUTTON].CellType = CellButton;
                                    spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_BUTTON].Locked = false;

                                    #endregion
                                }
                            }
                            break;
                    }

                    #region " Option Flag "
                    if (tool_event_info.GetChar("CHG_OPT") == 'Y')
                    {
                        spdToolStatus_Sheet1.Cells[i_row, COL_STATUS_NAME].Font = BoldFont;
                    }

                    #endregion
                }

                for (i = 0; i < tool_event_out.GetList("CHG_LIST").Count; i++)
                {

                } //End of CHG_LIST
                //

                if (ListCond_ToolType != "" && ListCond_ToolID != "")
                {
                    View_Tool_Status_Forecast();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// View Tool Status && ForeCast
        /// </summary>
        public void View_Tool_Status_Forecast()
        {
            int i = 0;
            TRSNode tool_event_info;

            for (i = 0; i < spdToolStatus_Sheet1.RowCount; i++)
            {
                /*NoAction*/
                if (spdToolStatus_Sheet1.Rows[i].Tag == null)
                {
                    spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag = spdToolStatus_Sheet1.Cells[i, COL_CURRENT_VALUE].Value;
                    spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value = spdToolStatus_Sheet1.Cells[i, COL_CURRENT_VALUE].Value;
                    spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = spdToolStatus_Sheet1.Cells[i, COL_CURRENT_VALUE].Value;
                    continue;
                }

                /*Get ToolEvent Detail Info*/
                tool_event_info = (TRSNode)spdToolStatus_Sheet1.Rows[i].Tag;

                switch (tool_event_info.GetChar("CHG_FLAG"))
                {
                    /* Empty */
                    case ' ':
                        spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag = spdToolStatus_Sheet1.Cells[i, COL_CURRENT_VALUE].Value;
                        //spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value = spdToolStatus_Sheet1.Cells[i, COL_CURRENT_VALUE].Value;
                        break;
                    /* No Action */
                    case FLAG_NOT_CHANGE:
                        spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag = spdToolStatus_Sheet1.Cells[i, COL_CURRENT_VALUE].Value;
                        //spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value = spdToolStatus_Sheet1.Cells[i, COL_CURRENT_VALUE].Value;
                        break;
                    /* Reset */
                    case FLAG_RESET:
                        // Reset인 경우, Setup에서 정한 값이 있으면 그 값으로 나와야함.
                        if (tool_event_info.GetString("CHG_VALUE") != null)
                        {
                            spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag = tool_event_info.GetString("CHG_VALUE");
                            //spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value = tool_event_info.GetString("CHG_VALUE");
                        }
                        else
                        {
                            if (tool_event_info.GetChar("FORMAT") == 'N' || tool_event_info.GetChar("FORMAT") == 'F')
                            {
                                spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag = 0;
                                //spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value = 0;
                            }
                            else
                            {
                                spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag = "";
                                //spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value = "";
                            }
                        }
                        break;
                    /* Time */
                    case FLAG_TIME:
                        //spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value
                        //    = MPCF.ToStandardTime(System.DateTime.Now, MPGC.MP_CONVERT_DATETIME_FORMAT).Substring(0, tool_event_info.GetInt("SIZE"));

                        int i_value_size = tool_event_info.GetInt("SIZE");
                        i_value_size = i_value_size > 14 ? 14 : i_value_size;

                        spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag
                            = MPCF.ToStandardTime(System.DateTime.Now, MPGC.MP_CONVERT_DATETIME_FORMAT).Substring(0, i_value_size);
                        break;
                    default:
                        if (tool_event_info.GetString("CHG_VALUE") != "")
                        {
                            spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag = tool_event_info.GetString("CHG_VALUE");
                        }
                        else if (tool_event_info.GetString("CHG_FIELD") != "")
                        {
                            #region Get Current Field Value
                            for (int n = 0; n < spdToolStatus_Sheet1.RowCount; n++)
                            {
                                if (MPCF.Trim(spdToolStatus_Sheet1.Cells[n, COL_STATUS_NAME].Tag) == tool_event_info.GetString("CHG_FIELD"))
                                {
                                    spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag = spdToolStatus_Sheet1.Cells[n, COL_CURRENT_VALUE].Value;
                                    break;
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].ResetValue();
                        }

                        break;
                }
                View_Next_Status_Forecast(i);
            }
        }

        /// <summary>
        /// Calculate Next Status Value for Forecast
        /// </summary>
        /// <param name="iRow">RowIndex to Calculate Next Status Value</param>
        private void View_Next_Status_Forecast(int iRow)
        {
            int i = iRow;
            double dCurrent, dValue;
            TRSNode tool_event_info;

            spdToolStatus_Sheet1.Cells[iRow, COL_NEXT_VALUE].CellType = spdToolStatus_Sheet1.Cells[i, COL_CURRENT_VALUE].CellType;
            if (spdToolStatus_Sheet1.Rows[i].Tag == null)
            {
                spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = spdToolStatus_Sheet1.Cells[i, COL_CURRENT_VALUE].Value;
                return;
            }

            tool_event_info = (TRSNode)spdToolStatus_Sheet1.Rows[i].Tag;

            dCurrent = 0;
            dValue = 0;
            if (tool_event_info.GetChar("CHG_FLAG") == FLAG_INCREASE ||
                tool_event_info.GetChar("CHG_FLAG") == FLAG_DECREASE ||
                tool_event_info.GetChar("CHG_FLAG") == FLAG_MULTIPLY ||
                tool_event_info.GetChar("CHG_FLAG") == FLAG_DIVISION ||
                tool_event_info.GetChar("CHG_FLAG") == FLAG_MOD ||
                tool_event_info.GetChar("CHG_FLAG") == FLAG_POW)
            {
                dCurrent = MPCF.ToDbl(spdToolStatus_Sheet1.Cells[i, COL_CURRENT_VALUE].Value);
                dValue = MPCF.ToDbl(spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag);
            }

            switch (tool_event_info.GetChar("CHG_FLAG"))
            {
                case FLAG_INCREASE:
                    spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = dCurrent + dValue;
                    break;
                case FLAG_DECREASE:
                    spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = dCurrent - dValue;
                    break;
                case FLAG_MULTIPLY:
                    spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = dCurrent * dValue;
                    break;
                case FLAG_DIVISION:
                    if (dValue > 0)
                    {
                        spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = dCurrent / dValue;
                    }
                    else
                    {
                        spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = 0;
                    }
                    break;
                case FLAG_MOD:
                    if (dValue > 0)
                    {
                        spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = dCurrent % dValue;
                    }
                    else
                    {
                        spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = 0;
                    }
                    break;
                case FLAG_POW:
                    if (dValue > 0)
                    {
                        spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = Math.Pow(dCurrent, dValue);
                    }
                    else
                    {
                        spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = 0;
                    }
                    break;
                default:
                    spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value = spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag;
                    break;
            }
            /* InputColumn, NextColumn 이 구분되어 보인다면 InputValueCell엔 InputValue 값을 보여준다*/
            if (VisibleNextStatusColumn)
            {
                spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value = spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag;
            }
            else
            {
                /* InputColumn, NextColumn 이 구분되어 있지않다면 각 케이스별로 구분한다*/

                /* User Input */
                if (tool_event_info.GetString("CHG_FIELD") == "" && tool_event_info.GetString("CHG_VALUE") == "")
                {
                    /* Keyboard Text input */
                    if (MPCF.Trim(spdToolStatus_Sheet1.Cells[i, COL_INPUT_BUTTON].Tag) == "")
                    {
                        spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value = spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag;
                    }
                    /* GCM input */
                    else
                    {
                        spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value = spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Tag;
                    }
                }
                /* System Input Value */
                else
                {
                    spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value = spdToolStatus_Sheet1.Cells[i, COL_NEXT_VALUE].Value;
                }
            }
        }
        private void View_Next_Status_Forecast()
        {
            int i = 0;

            for (i = 0; i < spdToolStatus_Sheet1.RowCount; i++)
            {
                View_Next_Status_Forecast(i);
            }
        }

        public bool Set_Tool_InputValue(TRSNode in_node)
        {
            int i;

            TRSNode item_value;
            TRSNode node;

            char chg_flag = ' ';
            string chg_item = "";

            if (CheckCondition("Event") == false) return false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if(in_node.GetString("TOOL_ID") == "") in_node.AddString("TOOL_ID", ListCond_ToolID);
            if (in_node.GetString("TOOL_TYPE") == "") in_node.AddString("TOOL_TYPE", ListCond_ToolType);
            if (in_node.GetString("TOOL_EVENT_ID") == "") in_node.AddString("TOOL_EVENT_ID", ListCond_ToolEventID);

            string status_name = null;

            for (i = 0; i < 17; i++)
            {
                status_name = MPCF.Trim(spdToolStatus_Sheet1.Cells[i, COL_STATUS_NAME].Tag);
                switch(status_name)
                {
                    case ITEM_MAT_VER:
                        in_node.AddInt(status_name, MPCF.ToInt(spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value));
                        break;
                    case ITEM_GRADE:
                        in_node.AddChar(status_name, MPCF.ToChar(spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value));
                        break;
                    default:
                        in_node.AddString(status_name, MPCF.Trim(spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value));
                        break;
                }
            }

            int i_row = 0;
            for (i = 0; i < 30; i++)
            {
                item_value = in_node.AddNode("STS_LIST");
                chg_flag = ' ';
                chg_item = "";

                for (i_row = 17; i_row < spdToolStatus_Sheet1.RowCount; i_row++)
                {
                    if (spdToolStatus_Sheet1.Rows[i_row].Tag != null)
                    {
                        node = (TRSNode)spdToolStatus_Sheet1.Rows[i_row].Tag;
                        if (node.GetInt("SEQ") == (i + 1))
                        {
                            chg_flag = node.GetChar("CHG_FLAG");
                            chg_item = node.GetString("CHG_ITEM");
                            break;
                        }
                    }
                }

                if (chg_flag != ' ' && chg_item != "")
                {
                    item_value.AddString("TOOL_STS", MPCF.Trim(spdToolStatus_Sheet1.Cells[i_row, COL_INPUT_VALUE].Value));
                }
                else
                {
                    item_value.AddString("TOOL_STS", "");
                }
            }

            return true;
        }

        private bool CheckCondition(string FuncName)
        {
            TRSNode node;
            int i;
            switch (FuncName)
            {
                case "Event":
                    for (i = 0; i < spdToolStatus_Sheet1.RowCount; i++)
                    {
                        if (spdToolStatus_Sheet1.Rows[i].Tag == null)
                        {
                            continue;
                        }

                        node = (TRSNode)spdToolStatus_Sheet1.Rows[i].Tag;

                        if (node.GetChar("CHG_OPT") == 'Y' && MPCF.Trim(spdToolStatus_Sheet1.Cells[i, COL_INPUT_VALUE].Value) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(335));
                            spdToolStatus_Sheet1.SetActiveCell(i, COL_INPUT_VALUE);
                            return false;
                        }
                    }



                    break;
                default:
                    break;
            }

            return true;
        }

        #endregion

        private void spdToolStatus_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == COL_INPUT_BUTTON)
            {
                string s_table_name = MPCF.Trim(spdToolStatus_Sheet1.Cells[e.Row, COL_INPUT_BUTTON].Tag);

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
        }

        private void cdvTableList_SelectedItemChanged(object sender, MCSSCodeViewSelChanged_EventArgs e)
        {
            spdToolStatus_Sheet1.Cells[e.Row, COL_INPUT_VALUE].Tag = e.SelectedItem.Text;
            View_Next_Status_Forecast(e.Row);
        }

        private void spdToolStatus_EditModeOff(object sender, EventArgs e)
        {
            int iRow = spdToolStatus_Sheet1.ActiveRowIndex;
            spdToolStatus_Sheet1.Cells[iRow, COL_INPUT_VALUE].Tag = spdToolStatus_Sheet1.Cells[iRow, COL_INPUT_VALUE].Value;
            View_Next_Status_Forecast(iRow);
        }
    }
}
