using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.MESCore;

namespace Miracom.WEMCore.Setup
{
    public partial class udcStepActionToolEvent : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionToolEvent()
        {
            InitializeComponent();
            initControl();
        }

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

        private int COL_STATUS_NAME = 0;
        private int COL_INPUT_VALUE = 1;
        private int COL_INPUT_BUTTON = 2;

        #endregion

        #region "Functions"

        public override void initControl()
        {
            base.initControl();

            spdData.ActiveSheet.Cells[0, COL_STATUS_NAME].Tag = ITEM_TOOL_GRP;
            spdData.ActiveSheet.Cells[1, COL_STATUS_NAME].Tag = ITEM_TOOL_SET_ID;
            spdData.ActiveSheet.Cells[2, COL_STATUS_NAME].Tag = ITEM_TOOL_SET_LOCATION;
            spdData.ActiveSheet.Cells[3, COL_STATUS_NAME].Tag = ITEM_TOOL_STATUS;
            spdData.ActiveSheet.Cells[4, COL_STATUS_NAME].Tag = ITEM_LOT_ID;
            spdData.ActiveSheet.Cells[5, COL_STATUS_NAME].Tag = ITEM_SUBLOT_ID;
            spdData.ActiveSheet.Cells[6, COL_STATUS_NAME].Tag = ITEM_RES_ID;
            spdData.ActiveSheet.Cells[7, COL_STATUS_NAME].Tag = ITEM_SUBRES_ID;
            spdData.ActiveSheet.Cells[8, COL_STATUS_NAME].Tag = ITEM_AREA_ID;
            spdData.ActiveSheet.Cells[9, COL_STATUS_NAME].Tag = ITEM_SUB_AREA_ID;
            spdData.ActiveSheet.Cells[10, COL_STATUS_NAME].Tag = ITEM_TOOL_LOCATION;
            spdData.ActiveSheet.Cells[11, COL_STATUS_NAME].Tag = ITEM_VENDOR_ID;
            spdData.ActiveSheet.Cells[12, COL_STATUS_NAME].Tag = ITEM_MAT_ID;
            spdData.ActiveSheet.Cells[13, COL_STATUS_NAME].Tag = ITEM_MAT_VER;
            spdData.ActiveSheet.Cells[14, COL_STATUS_NAME].Tag = ITEM_FLOW;
            spdData.ActiveSheet.Cells[15, COL_STATUS_NAME].Tag = ITEM_OPER;
            spdData.ActiveSheet.Cells[16, COL_STATUS_NAME].Tag = ITEM_GRADE;
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            cdvToolType.Text = node.GetString("DATA_1");
            cdvToolEventID.Text = node.GetString("DATA_2");
            cdvToolID.Text = node.GetString("DATA_3");

            if (ViewToolType(cdvToolType.Text) == false) return;
            if (ViewToolEvent(cdvToolEventID.Text) == false) return;

            int i, k;
            string s_data_name;
            string s_sts_field_name;
            string s_data_value;

            for (i = 0;  i < spdData.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdData.ActiveSheet.Rows[i].Tag) == "U")
                {
                    for (k = 4; k <= 30; k++)
                    {
                        s_data_name = "DATA_" + k.ToString();
                        s_sts_field_name = MPCF.Trim(spdData.ActiveSheet.Cells[i, COL_STATUS_NAME].Tag);
                        s_data_value = node.GetString(s_data_name);

                        if (s_data_value.StartsWith(s_sts_field_name) == true)
                        {
                            spdData.ActiveSheet.Cells[i, COL_INPUT_VALUE].Value = s_data_value.Substring(s_sts_field_name.Length + 1);
                            break;
                        }
                    }
                }
            }
        }

        public override bool checkCondition()
        {
            if (MPCF.CheckValue(cdvToolType, 1) == false) return false;
            if (MPCF.CheckValue(cdvToolEventID, 1) == false) return false;

            return true;
        }

        public override void getAction(TRSNode node)
        {
            node.AddString("TRAN_CODE", "TOOL EVENT");

            node.AddString("DATA_1", cdvToolType.Text);
            node.AddString("DATA_2", cdvToolEventID.Text);
            node.AddString("DATA_3", cdvToolID.Text);

            int i, i_data_seq;
            string s_data_name;
            string s_sts_field_name;
            string s_data_value;

            i_data_seq = 4;
            for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdData.ActiveSheet.Rows[i].Tag) == "U")
                {
                    s_data_name = "DATA_" + i_data_seq.ToString();
                    s_sts_field_name = MPCF.Trim(spdData.ActiveSheet.Cells[i, COL_STATUS_NAME].Tag);
                    s_data_value = MPCF.Trim(spdData.ActiveSheet.Cells[i, COL_INPUT_VALUE].Value);

                    node.AddString(s_data_name, s_sts_field_name + ":" + s_data_value);
                    i_data_seq++;
                }
            }
        }

        private void InitBasicField()
        {
            int i;

            for (i = 0; i < 17; i++)
            {
                spdData.ActiveSheet.Cells[i, COL_INPUT_VALUE].ColumnSpan = 2;
            }
        }

        private bool ViewToolType(string s_tool_type)
        {
            TRSNode in_node = new TRSNode("VIEW_TOOL_TYPE_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_TYPE_OUT");
            int i, i_row;
            List<TRSNode> data_list;

            spdData.ActiveSheet.RowCount = 17;
            InitBasicField();

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", s_tool_type);

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type", in_node, ref out_node) == false)
                {
                    return false;
                }

                data_list = out_node.GetList("DATA_LIST");
                for (i = 0; i < data_list.Count; i++)
                {
                    if (data_list[i].GetString("PROMPT") == "") continue;

                    i_row = spdData.ActiveSheet.RowCount;
                    spdData.ActiveSheet.RowCount++;

                    spdData.ActiveSheet.Cells[i_row, COL_STATUS_NAME].Value = data_list[i].GetString("PROMPT");
                    spdData.ActiveSheet.Cells[i_row, COL_STATUS_NAME].Tag = data_list[i].GetString("FIELD");

                    if (data_list[i].GetString("TABLE_NAME") == "")
                    {
                        spdData.ActiveSheet.Cells[i_row, COL_INPUT_VALUE].ColumnSpan = 2;
                    }
                    else
                    {
                        FarPoint.Win.Spread.CellType.ButtonCellType btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        btnCell.Text = "...";
                        spdData.ActiveSheet.Cells[i_row, COL_INPUT_BUTTON].CellType = btnCell;
                        spdData.ActiveSheet.Cells[i_row, COL_INPUT_BUTTON].Tag = data_list[i].GetString("TABLE_NAME");
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

        private bool ViewToolEvent(string s_tool_event)
        {
            TRSNode in_node = new TRSNode("VIEW_TOOL_EVENT_IN");
            TRSNode out_node = new TRSNode("VIEW_TOOL_EVENT_OUT");
            int i, i_row;
            List<TRSNode> chg_list;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", cdvToolType.Text);
                in_node.AddString("TOOL_EVENT_ID", s_tool_event);

                if (MPCR.CallService("RAS", "RAS_View_Tool_Event", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdData.ActiveSheet.ClearRange(0, COL_INPUT_VALUE, spdData.ActiveSheet.RowCount, 1, true);
                spdData.ActiveSheet.Cells[0, COL_INPUT_VALUE, spdData.ActiveSheet.RowCount - 1, COL_INPUT_BUTTON].Locked = true;
                spdData.ActiveSheet.Cells[0, COL_INPUT_VALUE, spdData.ActiveSheet.RowCount - 1, COL_INPUT_BUTTON].BackColor = System.Drawing.SystemColors.Control;
                spdData.ActiveSheet.Rows[0, spdData.ActiveSheet.RowCount - 1].Tag = null;

                chg_list = out_node.GetList("CHG_LIST");
                for (i = 0; i < chg_list.Count; i++)
                {
                    if (chg_list[i].GetString("CHG_ITEM") == "") continue;

                    for (i_row = 0; i_row < spdData.ActiveSheet.RowCount; i_row++)
                    {
                        if (chg_list[i].GetString("CHG_ITEM") == MPCF.Trim(spdData.ActiveSheet.Cells[i_row, COL_STATUS_NAME].Tag))
                        {
                            if (chg_list[i].GetString("CHG_VALUE") != "")
                            {
                                spdData.ActiveSheet.Cells[i_row, COL_INPUT_VALUE].Value = chg_list[i].GetString("CHG_VALUE");
                            }
                            else if (chg_list[i].GetString("CHG_FIELD") != "")
                            {
                                spdData.ActiveSheet.Cells[i_row, COL_INPUT_VALUE].Value = "@" + chg_list[i].GetString("CHG_FIELD");
                            }
                            else
                            {
                                spdData.ActiveSheet.Cells[i_row, COL_INPUT_VALUE, i_row, COL_INPUT_BUTTON].Locked = false;
                                spdData.ActiveSheet.Cells[i_row, COL_INPUT_VALUE, i_row, COL_INPUT_BUTTON].BackColor = System.Drawing.SystemColors.Window;
                                spdData.ActiveSheet.Rows[i_row].Tag = 'U';
                            }

                            break;
                        }
                    }//end for
                }//end for

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        private void cdvToolType_ButtonPress(object sender, EventArgs e)
        {
            cdvToolType.Init();
            MPCF.InitListView(cdvToolType.GetListView);
            cdvToolType.Columns.Add("Tool Type", 50, HorizontalAlignment.Left);
            cdvToolType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolType.SelectedSubItemIndex = 0;
            cdvToolType.SelectedDescIndex = 1;
            RASLIST.ViewToolTypeList(cdvToolType.GetListView, '1', 'N', 'N', null);
        }

        private void cdvToolType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvToolType.Text == "") return;

            cdvToolEventID.Text = "";
            cdvToolID.Text = "";
            if (ViewToolType(cdvToolType.Text) == false) return;
        }

        private void cdvToolEventID_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvToolType, 1) == false) return;
                
            cdvToolEventID.Init();
            MPCF.InitListView(cdvToolEventID.GetListView);
            cdvToolEventID.Columns.Add("Tool Event", 50, HorizontalAlignment.Left);
            cdvToolEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolEventID.SelectedSubItemIndex = 0;
            cdvToolEventID.SelectedDescIndex = 1;
            RASLIST.ViewToolEventList(cdvToolEventID.GetListView, '1', cdvToolType.Text, 'N', null);
        }

        private void cdvToolEventID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvToolEventID.Text == "") return;

            if (ViewToolEvent(cdvToolEventID.Text) == false) return;
        }

        private void cdvToolID_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvToolType, 1) == false) return;

            cdvToolID.Init();
            MPCF.InitListView(cdvToolID.GetListView);
            cdvToolID.Columns.Add("Tool ID", 50, HorizontalAlignment.Left);
            cdvToolID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolID.SelectedSubItemIndex = 0;
            RASLIST.ViewToolList(cdvToolID.GetListView, '2', cdvToolType.Text, 'N', true, null);
        }

        private void spdData_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string s_table_name = MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, e.Column].Tag);

            if (s_table_name == "") return;

            cdvData.Init();
            cdvData.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvData.GetListView);
            cdvData.Columns.Add("Data", 50, HorizontalAlignment.Left);
            cdvData.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            BASLIST.ViewGCMDataList(cdvData.GetListView, '1', s_table_name);
            if (cdvData.Items.Count > 0)
            {
                cdvData.InsertEmptyRow(0, 1);
                cdvData.ShowPopUp(e.Row, e.Column);
            }
        }

        private void cdvData_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdData.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;
        }


    }
}
