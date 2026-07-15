using System;
using System.Collections;
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
    public partial class udcStepActionChangeStatusValue : Miracom.WEMCore.Setup.udcStepActionBase
    {
        public udcStepActionChangeStatusValue()
        {
            InitializeComponent();
            initControl();
        }

        #region "Variables"

        private Hashtable mh_status_tables;
        private ListView ml_ref_statuses;

        #endregion

        #region "Functions"

        public override void initControl()
        {
            base.initControl();
        }

        public override void setAction(TRSNode node)
        {
            if (node == null) return;

            setChangeValue(0, node.GetString("DATA_1"));
            setChangeValue(1, node.GetString("DATA_2"));
            setChangeValue(2, node.GetString("DATA_3"));
            setChangeValue(3, node.GetString("DATA_4"));
            setChangeValue(4, node.GetString("DATA_5"));
            setChangeValue(5, node.GetString("DATA_6"));
            setChangeValue(6, node.GetString("DATA_7"));
            setChangeValue(7, node.GetString("DATA_8"));
            setChangeValue(8, node.GetString("DATA_9"));
            setChangeValue(9, node.GetString("DATA_10"));
            setChangeValue(10, node.GetString("DATA_11"));
            setChangeValue(11, node.GetString("DATA_12"));
            setChangeValue(12, node.GetString("DATA_13"));
            setChangeValue(13, node.GetString("DATA_14"));
            setChangeValue(14, node.GetString("DATA_15"));
            setChangeValue(15, node.GetString("DATA_16"));
            setChangeValue(16, node.GetString("DATA_17"));
            setChangeValue(17, node.GetString("DATA_18"));
            setChangeValue(18, node.GetString("DATA_19"));
            setChangeValue(19, node.GetString("DATA_20"));
            setChangeValue(20, node.GetString("DATA_21"));
            setChangeValue(21, node.GetString("DATA_22"));
            setChangeValue(22, node.GetString("DATA_23"));
            setChangeValue(23, node.GetString("DATA_24"));
            setChangeValue(24, node.GetString("DATA_25"));
            setChangeValue(25, node.GetString("DATA_26"));
            setChangeValue(26, node.GetString("DATA_27"));
            setChangeValue(27, node.GetString("DATA_28"));
            setChangeValue(28, node.GetString("DATA_29"));
            setChangeValue(29, node.GetString("DATA_30"));
        }

        public override bool checkCondition()
        {
            int i;

            for (i = 0; i < 30; i++)
            {
                if (MPCF.Trim(spdStatus.ActiveSheet.Cells[i, 0].Value) != "")
                {
                    if (MPCF.Trim(spdStatus.ActiveSheet.Cells[i, 1].Value) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        spdStatus.ActiveSheet.SetActiveCell(i, 1);
                        spdStatus.Select();
                        spdStatus.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        public override void getAction(TRSNode node)
        {
            int i;
            int i_data_count;
            string s_data_name;
            string s_value;

            node.AddString("TRAN_CODE", "CHANGE STATUS");

            i_data_count = 0;
            for (i = 0; i < 30; i++)
            {
                s_value = getChangeValue(i);
                if (s_value != "")
                {
                    i_data_count++;
                    s_data_name = "DATA_" + i_data_count.ToString();
                    node.AddString(s_data_name, s_value);
                }
            }
        }

        public void setWorkProcType(string s_work_proc_type)
        {
            ViewTypeStatusList(s_work_proc_type);
        }

        private string getChangeFlag(string s_value)
        {
            string s_ret;
            s_ret = "";

            switch (s_value)
            {
                case "Y": s_ret = "Y (Change)"; break;
                case "+": s_ret = "+ (Increase)"; break;
                case "-": s_ret = "- (Decrease)"; break;
                case "T": s_ret = "T (Time)"; break;
                case "R": s_ret = "R (Reset)"; break;
            }

            return s_ret;
        }

        private void setChangeValue(int i_row, string s_data)
        {
            string[] s_value;
            if (s_data != "")
            {
                s_value = s_data.Split(';');
                if (s_value.Length > 4)
                {
                    spdStatus.ActiveSheet.Cells[i_row, 0].Value = s_value[0];
                    spdStatus.ActiveSheet.Cells[i_row, 0].Tag = s_value[0];

                    spdStatus.ActiveSheet.Cells[i_row, 1].Value = getChangeFlag(s_value[1]);
                    spdStatus.ActiveSheet.Cells[i_row, 2].Value = s_value[2];
                    spdStatus.ActiveSheet.Cells[i_row, 2].Tag = s_value[3];

                    if (mh_status_tables.Contains(s_value[0]) == true)
                    {
                        spdStatus.ActiveSheet.Cells[i_row, 3].Tag = mh_status_tables[s_value[0]];
                    }
                }
            }
        }

        private string getChangeValue(int i_row)
        {
            string s_data = "";

            if(MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 0].Value) != "")
            {
                s_data = MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 0].Value);
                s_data += ";";
                s_data += MPCF.ToChar(spdStatus.ActiveSheet.Cells[i_row, 1].Value);
                s_data += ";";
                s_data += MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 2].Value);
                s_data += ";";
                s_data += MPCF.Trim(spdStatus.ActiveSheet.Cells[i_row, 2].Tag);
                s_data += ";";
            }

            return s_data;
        }

        private bool ViewTypeStatusList(string s_work_proc_type)
        {
            TRSNode in_node = new TRSNode("VIEW_WORK_PROC_TYPE_IN");
            TRSNode out_node = new TRSNode("VIEW_WORK_PROC_TYPE_OUT");
            List<TRSNode> lis_status_list;
            int i;
            int i_user_define_count;
            string[] s_change_items;
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
            ListViewItem itm;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("WORK_PROC_TYPE", s_work_proc_type);

            if (MPCR.CallService("WEM", "WEM_View_Work_Process_Type", in_node, ref out_node) == false)
            {
                return false;
            }

            lis_status_list = out_node.GetList("STATUS_LIST");

            if (ml_ref_statuses == null)
            {
                ml_ref_statuses = new ListView();
                ml_ref_statuses.Columns.Add("Status", 100, HorizontalAlignment.Left);
                ml_ref_statuses.Columns.Add("Description", 100, HorizontalAlignment.Left);
            }
            ml_ref_statuses.Items.Clear();

            for (i = 0; i < lis_status_list.Count; i++)
            {
                if (lis_status_list[i].GetChar("STATUS_TYPE") == 'I' || lis_status_list[i].GetChar("STATUS_TYPE") == 'F') continue;

                itm = new ListViewItem(lis_status_list[i].GetString("STATUS"));
                itm.SubItems.Add(lis_status_list[i].GetString("STATUS_DESC"));

                ml_ref_statuses.Items.Add(itm);
            }

            i_user_define_count = 0;
            for (i = 0; i < lis_status_list.Count; i++)
            {
                if (lis_status_list[i].GetChar("STATUS_TYPE") != 'U') continue;
                i_user_define_count++;
            }

            if (i_user_define_count < 1) return true;

            s_change_items = new string[i_user_define_count + 1];
            s_change_items[0] = "";
            i_user_define_count = 1;

            if(mh_status_tables == null)
            {
                mh_status_tables = new Hashtable();
            }
            mh_status_tables.Clear();

            for (i = 0; i < lis_status_list.Count; i++)
            {
                if (lis_status_list[i].GetChar("STATUS_TYPE") != 'U') continue;

                s_change_items[i_user_define_count++] = lis_status_list[i].GetString("STATUS");
                if(lis_status_list[i].GetString("DATA_1") != "")
                {
                    mh_status_tables.Add(lis_status_list[i].GetString("STATUS"), lis_status_list[i].GetString("DATA_1"));
                }
            }

            cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            cboCellType.Items = s_change_items;
            spdStatus.ActiveSheet.Columns[0].CellType = cboCellType;

            return true;
        }

        #endregion

        private void spdStatus_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 0)
            {
                string s_status_name = MPCF.Trim(spdStatus.ActiveSheet.Cells[e.Row, 0].Value);
                if (s_status_name == "")
                {
                    spdStatus.ActiveSheet.Cells[e.Row, 3].Tag = null;

                    spdStatus.ActiveSheet.Cells[e.Row, 1].Value = null;
                    spdStatus.ActiveSheet.Cells[e.Row, 2].Value = null;
                    spdStatus.ActiveSheet.Cells[e.Row, 2].Tag = null;

                    spdStatus.ActiveSheet.Cells[e.Row, 0].Tag = s_status_name;
                }
                else if (MPCF.Trim(spdStatus.ActiveSheet.Cells[e.Row, 0].Tag) != s_status_name)
                {
                    spdStatus.ActiveSheet.Cells[e.Row, 1].Value = null;
                    spdStatus.ActiveSheet.Cells[e.Row, 2].Value = null;
                    spdStatus.ActiveSheet.Cells[e.Row, 2].Tag = null;
                    spdStatus.ActiveSheet.Cells[e.Row, 0].Tag = s_status_name;

                    if (mh_status_tables.Contains(s_status_name) == true)
                    {
                        spdStatus.ActiveSheet.Cells[e.Row, 3].Tag = mh_status_tables[s_status_name];
                    }
                    else
                    {
                        spdStatus.ActiveSheet.Cells[e.Row, 3].Tag = null;
                    }
                }
            }
            else if (e.Column == 1)
            {
                if (MPCF.Trim(spdStatus.ActiveSheet.Cells[e.Row, 0].Value) == "")
                {
                    spdStatus.ActiveSheet.Cells[e.Row, 1].Value = null;
                }
            }
        }

        private void spdStatus_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string s_table_name = MPCF.Trim(spdStatus.ActiveSheet.Cells[e.Row, 3].Tag);
            
            cdvData.Init();
            cdvData.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvData.GetListView);
            cdvData.Columns.Add("Code", 100, HorizontalAlignment.Left);
            cdvData.Columns.Add("Description", 100, HorizontalAlignment.Left);

            if (s_table_name != "")
            {
                BASLIST.ViewGCMDataList(cdvData.GetListView, '1', s_table_name);
            }

            if (ml_ref_statuses != null && ml_ref_statuses.Items.Count > 0)
            {
                int i;
                ListViewItem itm;

                for (i = 0; i < ml_ref_statuses.Items.Count; i++)
                {
                    itm = new ListViewItem(ml_ref_statuses.Items[i].Text, (int)SMALLICON_INDEX.IDX_SUB_LOT);
                    itm.SubItems.Add(ml_ref_statuses.Items[i].SubItems[1].Text);

                    cdvData.Items.Add(itm);
                }
            }

            if (cdvData.ShowPopupList(e.Row, e.Column) == false) return;
        }

        private void cdvData_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdStatus.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;
            spdStatus.ActiveSheet.Cells[e.Row, e.Col - 1].Tag = null;

            if (MPCF.Trim(spdStatus.ActiveSheet.Cells[e.Row, e.Col].Tag) == "")
            {
                spdStatus.ActiveSheet.Cells[e.Row, e.Col - 1].Tag = "S";
            }
        }

    }
}
