using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.BASCore.Controls
{
    public partial class udcChecklistKeyPrompt : UserControl
    {
        private enum Columns : int
        {
            PROMPT = 0,
            REQUIRE,
            FORMAT,
            TABLE,
            TABLE_ITEM,
            TABLE_BTN
        }

        private string[] sFormatArray = { "Ascii", "Number", "Float" };
        private string[] sRequireArray = { "", "Y", "N" };

        private int iKeyValueMaxRow = 10;

        private bool b_prompt_lock = false;
        private bool b_require_lock = false;
        private bool b_format_lock = false;
        private bool b_tableitem_lock = false;

        public bool LockColumn_Prompt
        {
            set { b_prompt_lock = value; }
            get { return b_prompt_lock; }
        }
        public bool LockColumn_Require
        {
            set
            {
                b_require_lock = value;
                if (b_require_lock == true)
                {
                    spdKeyPrompt_Sheet1.Columns[(int)Columns.REQUIRE].ResetCellType();
                }
                else
                {
                    FarPoint.Win.Spread.CellType.ComboBoxCellType comboCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    comboCell.Items = sRequireArray;
                    spdKeyPrompt_Sheet1.Columns[(int)Columns.REQUIRE].CellType = comboCell;
                }
            }
            get { return b_require_lock; }
        }
        public bool LockColumn_Format
        {

            set
            {
                b_format_lock = value;
                if (b_format_lock == true)
                {
                    spdKeyPrompt_Sheet1.Columns[(int)Columns.FORMAT].ResetCellType();
                }
                else
                {
                    FarPoint.Win.Spread.CellType.ComboBoxCellType comboCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    comboCell.Items = sFormatArray;
                    spdKeyPrompt_Sheet1.Columns[(int)Columns.FORMAT].CellType = comboCell;
                }
            }
            get { return b_format_lock; }
        }
        public bool LockColumn_TableItem
        {
            set
            {
                int i, n;
                b_tableitem_lock = value;
                if (b_tableitem_lock)
                {
                    n = 2;
                }
                else
                {
                    n = 1;
                }
                for (i = 0; i < spdKeyPrompt_Sheet1.RowCount; i++)
                {
                    spdKeyPrompt_Sheet1.Cells[i, (int)Columns.TABLE_ITEM].ColumnSpan = n;
                }
            }
            get { return b_tableitem_lock; }
        }

        public udcChecklistKeyPrompt()
        {
            InitializeComponent();
        }

        private bool ViewKeyTableList()
        {
            int i;
            ListView temp;
            ListViewItem itemX;
            string SQL;

            cdvTableList.Init();
            MPCF.InitListView(cdvTableList.GetListView);
            cdvTableList.Columns.Add("Table Type", 50, HorizontalAlignment.Left);
            cdvTableList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
            cdvTableList.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
            cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();

            //GCM
            temp = new ListView();
            temp.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
            temp.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
            BASLIST.ViewGCMTableList(temp, '1');
            for (i = 0; i < temp.Items.Count; i++)
            {
                itemX = new ListViewItem("GCM", (int)SMALLICON_INDEX.IDX_CODE_TABLE);
                itemX.Tag = "$GCM";
                itemX.SubItems.Add(temp.Items[i].SubItems[0].Text);
                itemX.SubItems.Add(temp.Items[i].SubItems[1].Text);

                cdvTableList.GetListView.Items.Add(itemX);
            }

            //RAS, LOT History
            MPCF.InitListView(temp);
            temp.Columns.Clear();
            temp.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
            temp.Columns.Add("Column Name", 50, HorizontalAlignment.Left);
            temp.Columns.Add("Column Desc", 50, HorizontalAlignment.Left);
            SQL = "SELECT CASE TAB.TABLE_NAME " +
                "            WHEN 'MWIPLOTHIS' THEN 'LOT' " +
                "            WHEN 'MRASRESHIS' THEN 'RAS' " +
                "            ELSE ' ' " +
                "         END " +
                "            TABLE_NAME, TAB.COLUMN_NAME, COL.COMMENTS " +
                "    FROM USER_TAB_COLUMNS TAB, USER_COL_COMMENTS COL " +
                "   WHERE     TAB.TABLE_NAME IN ('MWIPLOTHIS', 'MRASRESHIS') " +
                "         AND TAB.TABLE_NAME = COL.TABLE_NAME " +
                "         AND TAB.COLUMN_NAME = COL.COLUMN_NAME " +
                "ORDER BY TAB.TABLE_NAME DESC, TAB.COLUMN_ID ASC ";

            if (BASLIST.ViewQueryList(temp, '1', SQL, 0, null) == true)
            {
                for (i = 0; i < temp.Items.Count; i++)
                {
                    itemX = new ListViewItem("", -1);
                    if (temp.Items[i].SubItems[0].Text == "RAS")
                    {
                        itemX.Text = "Resource History";
                        itemX.Tag = "$RES_HISTORY";
                        itemX.ImageIndex = (int)SMALLICON_INDEX.IDX_RESOURCE;
                    }
                    else if (temp.Items[i].SubItems[0].Text == "LOT")
                    {
                        itemX.Text = "Lot History";
                        itemX.Tag = "$LOT_HISTORY";
                        itemX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT;
                    }

                    itemX.SubItems.Add(temp.Items[i].SubItems[1].Text);
                    itemX.SubItems.Add(temp.Items[i].SubItems[2].Text);

                    cdvTableList.GetListView.Items.Add(itemX);
                }
            }

            MPCF.InitListView(temp);
            temp.Columns.Clear();
            temp.Columns.Add("Attr Seq", 30, HorizontalAlignment.Left);
            temp.Columns.Add("Attr Name", 50, HorizontalAlignment.Left);
            temp.Columns.Add("Attr Type", 50, HorizontalAlignment.Left);
            temp.Columns.Add("Attr Desc", 50, HorizontalAlignment.Left);
            if (BASLIST.ViewAttributeNameList(temp, '1', "LOT") == true)
            {
                for (i = 0; i < temp.Items.Count; i++)
                {
                    itemX = new ListViewItem("Lot Attribute", (int)SMALLICON_INDEX.IDX_LOT);
                    itemX.Tag = "$LOT_ATTR";

                    itemX.SubItems.Add(temp.Items[i].SubItems[1].Text);
                    itemX.SubItems.Add(temp.Items[i].SubItems[3].Text);

                    cdvTableList.GetListView.Items.Add(itemX);
                }
            }
            //RES Attribute
            MPCF.InitListView(temp);
            temp.Columns.Clear();
            temp.Columns.Add("Attr Seq", 50, HorizontalAlignment.Left);
            temp.Columns.Add("Attr Name", 50, HorizontalAlignment.Left);
            temp.Columns.Add("Attr Desc", 50, HorizontalAlignment.Left);
            if (BASLIST.ViewAttributeNameList(temp, '1', "RES") == true)
            {
                for (i = 0; i < temp.Items.Count; i++)
                {
                    itemX = new ListViewItem("Res Attribute", (int)SMALLICON_INDEX.IDX_RESOURCE);
                    itemX.Tag = "$RES_ATTR";

                    itemX.SubItems.Add(temp.Items[i].SubItems[1].Text);
                    itemX.SubItems.Add(temp.Items[i].SubItems[2].Text);

                    cdvTableList.GetListView.Items.Add(itemX);
                }
            }

            cdvTableList.InsertEmptyRow(0, 1);

            return true;
        }

        public void Clear()
        {
            spdKeyPrompt_Sheet1.ClearRange(0, 0, spdKeyPrompt_Sheet1.RowCount, spdKeyPrompt_Sheet1.Columns.Count, true);
            //spdKeyPrompt_Sheet1.RowCount = 0;
            //spdKeyPrompt_Sheet1.RowCount = 10;
        }

        public void FillKeyPromptSetup(ref TRSNode in_node)
        {
            int i;
            string sNaming;

            for (i = 0; i < iKeyValueMaxRow; i++)
            {
                if (string.IsNullOrEmpty(spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.PROMPT].Text) == true)
                {
                    continue;
                }

                if (MPCF.Trim(spdKeyPrompt_Sheet1.GetText(i, (int)Columns.REQUIRE)) == "")
                {
                    spdKeyPrompt_Sheet1.Cells[i, (int)Columns.REQUIRE].Value = "N";
                }

                sNaming = "KEY_" + (i + 1) + "_PMT";
                in_node.SetString(sNaming, MPCF.Trim(spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.PROMPT].Text));

                sNaming = "KEY_" + (i + 1) + "_REQ";
                in_node.SetChar(sNaming, Convert.ToChar(MPCF.Trim(spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.REQUIRE].Text).Substring(0, 1)));

                sNaming = "KEY_" + (i + 1) + "_FMT";
                in_node.SetChar(sNaming, Convert.ToChar(MPCF.Trim(spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.FORMAT].Text).Substring(0, 1)));

                sNaming = "KEY_" + (i + 1) + "_TBL";
                in_node.SetString(sNaming, MPCF.Trim(spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.TABLE].Tag));

                sNaming = "KEY_" + (i + 1) + "_ITEM";
                in_node.SetString(sNaming, MPCF.Trim(spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.TABLE_ITEM].Text));
            }
        }

        public void DisplayKeyPromptSetup(ref TRSNode out_node)
        {
            int i;
            string sNaming;

            spdKeyPrompt_Sheet1.Columns[(int)Columns.PROMPT].Locked = b_prompt_lock;
            spdKeyPrompt_Sheet1.Columns[(int)Columns.REQUIRE].Locked = b_require_lock;
            spdKeyPrompt_Sheet1.Columns[(int)Columns.FORMAT].Locked = b_format_lock;

            for (i = 0; i < iKeyValueMaxRow; i++)
            {
                /* Cell Value */
                sNaming = string.Format("KEY_{0}_PMT", i + 1);
                spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.PROMPT].Text = MPCF.Trim(out_node.GetString(sNaming));

                sNaming = string.Format("KEY_{0}_REQ", i + 1);
                spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.REQUIRE].Text = MPCF.Trim(out_node.GetChar(sNaming));

                sNaming = string.Format("KEY_{0}_FMT", i + 1);
                spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.FORMAT].Tag = MPCF.Trim(out_node.GetChar(sNaming));
                foreach (string FormatName in sFormatArray)
                {
                    if (FormatName.Substring(0, 1).Equals(MPCF.Trim(out_node.GetChar(sNaming))) == true)
                    {
                        spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.FORMAT].Text = FormatName;
                    }
                }
                sNaming = string.Format("KEY_{0}_TBL", i + 1);
                spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.TABLE].Tag = MPCF.Trim(out_node.GetString(sNaming));
                switch (MPCF.Trim(out_node.GetString(sNaming)))
                {
                    case "$LOT_HISTORY": spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.TABLE].Text = "Lot History"; break;
                    case "$RES_HISTORY": spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.TABLE].Text = "Resource History"; break;
                    case "$LOT_ATTR": spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.TABLE].Text = "Lot Attribute"; break;
                    case "$RES_ATTR": spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.TABLE].Text = "Resource Attribute"; break;
                    case "$GCM": spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.TABLE].Text = "GCM"; break;
                    default: spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.TABLE].Text = MPCF.Trim(out_node.GetString(sNaming)); break;
                }

                sNaming = string.Format("KEY_{0}_ITEM", i + 1);
                spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.TABLE_ITEM].Tag = MPCF.Trim(out_node.GetString(sNaming));
                spdKeyPrompt.ActiveSheet.Cells[i, (int)Columns.TABLE_ITEM].Text = MPCF.Trim(out_node.GetString(sNaming));
            }
        }

        private void spdKeyPrompt_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                ViewKeyTableList();

                if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvTableList_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                spdKeyPrompt.ActiveSheet.Cells[e.Row, (int)Columns.TABLE].Text = e.SelectedItem.SubItems[0].Text;
                spdKeyPrompt.ActiveSheet.Cells[e.Row, (int)Columns.TABLE].Tag = e.SelectedItem.Tag;
                spdKeyPrompt.ActiveSheet.Cells[e.Row, (int)Columns.TABLE_ITEM].Text = e.SelectedItem.SubItems[1].Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdKeyPrompt_EditModeOff(object sender, EventArgs e)
        {
            int iRow;
            iRow = spdKeyPrompt_Sheet1.ActiveRowIndex;

            if (spdKeyPrompt_Sheet1.Cells[iRow, (int)Columns.PROMPT].Text == "")
            {
                spdKeyPrompt_Sheet1.ClearRange(iRow, 0, 1, spdKeyPrompt_Sheet1.Columns.Count, true);
            }
        }
    }
}
