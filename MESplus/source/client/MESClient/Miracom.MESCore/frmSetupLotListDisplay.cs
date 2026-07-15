using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;

namespace Miracom.MESCore
{
    public partial class frmSetupLotListDisplay : Form
    {
        public frmSetupLotListDisplay()
        {
            InitializeComponent();
        }

        #region " Variable Definition "

        private bool b_load_flag;
        private FarPoint.Win.Spread.SheetView shtListMain;
        private string sDisplayName;

        private struct ST_COL_INFO
        {
            public string s_name;
            public string s_order;
            public string s_merge;
            public int i_order_seq;
        }

        #endregion

        #region " Function Definition "

        public void SetLotListMainSheet(FarPoint.Win.Spread.SheetView sht_list_main, string s_display_name)
        {
            this.shtListMain = sht_list_main;
            sDisplayName = s_display_name;
        }

        private void DiplayColumns()
        {
            int i;
            ST_COL_INFO st_col;

            spdList.ActiveSheet.RowCount = 6;
            spdList.ActiveSheet.ColumnCount = 0;
            spdList.ActiveSheet.ColumnCount = shtListMain.ColumnCount - 1;

            for (i = 1; i < shtListMain.ColumnCount; i++)
            {
                spdList.ActiveSheet.ColumnHeader.Cells[0, i - 1].Value = shtListMain.ColumnHeader.Cells[0, i].Value;
                spdList.ActiveSheet.ColumnHeader.Cells[0, i - 1].Tag = shtListMain.ColumnHeader.Cells[0, i].Tag;
                spdList.ActiveSheet.Columns[i - 1].Width = shtListMain.Columns[i].Width;

                if (shtListMain.RowCount > 2)
                {
                    spdList.ActiveSheet.Cells[2, i - 1].Value = shtListMain.Cells[2, i].Value;
                }
                if (shtListMain.RowCount > 1)
                {
                    spdList.ActiveSheet.Cells[1, i - 1].Value = shtListMain.Cells[1, i].Value;
                }
                if (shtListMain.RowCount > 0)
                {
                    spdList.ActiveSheet.Cells[0, i - 1].Value = shtListMain.Cells[0, i].Value;
                }

                st_col = new ST_COL_INFO();
                st_col.s_name = MPCF.Trim(shtListMain.ColumnHeader.Cells[0, i].Tag);
                st_col.s_order = "N";
                st_col.s_merge = "N";

                if (MPCF.GetRegSetting(Application.ProductName, sDisplayName, "col_name_" + i.ToString(), "") != "")
                {
                    st_col.s_order = MPCF.GetRegSetting(Application.ProductName, sDisplayName, "col_order_" + i.ToString(), "N");
                    st_col.s_merge = MPCF.GetRegSetting(Application.ProductName, sDisplayName, "col_merge_" + i.ToString(), "N");
                    st_col.i_order_seq = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, sDisplayName, "col_order_seq_" + i.ToString(), "0"));

                    if (st_col.s_merge.Equals("Y"))
                    {
                        spdList.ActiveSheet.Cells[3, i - 1].Value = true;
                    }

                    if (st_col.s_order.Equals("A"))
                    {
                        spdList.ActiveSheet.Cells[4, i - 1].Value = "Ascending";
                        spdList.ActiveSheet.Cells[5, i - 1].Value = st_col.i_order_seq;
                        spdList.ActiveSheet.Cells[5, i - 1].Locked = false;
                    }
                    else if (st_col.s_order.Equals("D"))
                    {
                        spdList.ActiveSheet.Cells[4, i - 1].Value = "Descending";
                        spdList.ActiveSheet.Cells[5, i - 1].Value = st_col.i_order_seq;
                        spdList.ActiveSheet.Cells[5, i - 1].Locked = false;
                    }
                }

                spdList.ActiveSheet.Columns[i - 1].Tag = st_col;
            }
        }

        #endregion " Function Definition "

        private void frmSetupLotListDisplay_Load(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }
        }

        private void frmSetupLotListDisplay_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                DiplayColumns();

                b_load_flag = true;
            }
        }

        private void spdList_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            ST_COL_INFO st_col;

            st_col = (ST_COL_INFO)(spdList.ActiveSheet.Columns[e.Column].Tag);

            if (e.Row == 4)
            {
                if (MPCF.Trim(spdList.ActiveSheet.Cells[4, e.Column].Value) == "")
                {
                    st_col.s_order = "N";
                    spdList.ActiveSheet.Cells[5, e.Column].Value = null;
                    spdList.ActiveSheet.Cells[5, e.Column].Locked = true;
                }
                else if (MPCF.Trim(spdList.ActiveSheet.Cells[4, e.Column].Value).Equals("Ascending"))
                {
                    st_col.s_order = "A";
                    spdList.ActiveSheet.Cells[5, e.Column].Locked = false;
                }
                else if (MPCF.Trim(spdList.ActiveSheet.Cells[4, e.Column].Value).Equals("Descending"))
                {
                    st_col.s_order = "D";
                    spdList.ActiveSheet.Cells[5, e.Column].Locked = false;
                }

                spdList.ActiveSheet.Columns[e.Column].Tag = st_col;
            }
        }

        private void spdList_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            ST_COL_INFO st_col;

            st_col = (ST_COL_INFO)(spdList.ActiveSheet.Columns[e.Column].Tag);

            if (e.Row == 3)
            {
                if (spdList.ActiveSheet.Cells[3, e.Column].Value != null && (bool)spdList.ActiveSheet.Cells[3, e.Column].Value == true)
                {
                    st_col.s_merge = "Y";
                }
                else
                {
                    st_col.s_merge = "N";
                }

                spdList.ActiveSheet.Columns[e.Column].Tag = st_col;
            }
        }

        private void spdList_EditModeOff(object sender, EventArgs e)
        {
            ST_COL_INFO st_col;
            int i;
            int i_col = spdList.ActiveSheet.ActiveColumnIndex;
            int i_row = spdList.ActiveSheet.ActiveRowIndex;

            if (i_row == 5)
            {
                if (MPCF.ToInt(spdList.ActiveSheet.Cells[5, i_col].Value) > 0)
                {
                    st_col = (ST_COL_INFO)(spdList.ActiveSheet.Columns[i_col].Tag);

                    if (st_col.s_order == "")
                    {
                        spdList.ActiveSheet.Cells[5, i_col].Value = null;
                        return;
                    }

                    st_col.i_order_seq = MPCF.ToInt(spdList.ActiveSheet.Cells[5, i_col].Value);

                    for (i = 0; i < spdList.ActiveSheet.ColumnCount; i++)
                    {
                        if (i == i_col)
                        {
                            continue;
                        }

                        if (st_col.i_order_seq == MPCF.ToInt(spdList.ActiveSheet.Cells[5, i].Value))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(345));
                            spdList.ActiveSheet.Cells[5, i_col].Value = null;

                            spdList.ActiveSheet.SetActiveCell(5, i_col);
                            spdList.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center);
                            spdList.Focus();
                            return;
                        }
                    }

                    spdList.ActiveSheet.Columns[i_col].Tag = st_col;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int i;

            for (i = 1; i < 200; i++)
            {
                MPCF.DeleteRegSetting(Application.ProductName, sDisplayName, "col_name_" + i.ToString());
                MPCF.DeleteRegSetting(Application.ProductName, sDisplayName, "col_order_" + i.ToString());
                MPCF.DeleteRegSetting(Application.ProductName, sDisplayName, "col_merge_" + i.ToString());
                MPCF.DeleteRegSetting(Application.ProductName, sDisplayName, "col_order_seq_" + i.ToString());
            }

            btnClose.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int i;
            ST_COL_INFO st_col;

            for (i = 1; i <= spdList.ActiveSheet.ColumnCount; i++)
            {
                st_col = (ST_COL_INFO)(spdList.ActiveSheet.Columns[i - 1].Tag);

                if (st_col.s_order == "A" || st_col.s_order == "D")
                {
                    if (st_col.i_order_seq < 1)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(346));
                        spdList.ActiveSheet.SetActiveCell(5, i - 1);
                        spdList.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Center);
                        spdList.Focus();
                        return;
                    }
                }
            }

            for (i = 1; i < 200; i++)
            {
                MPCF.DeleteRegSetting(Application.ProductName, sDisplayName, "col_name_" + i.ToString());
                MPCF.DeleteRegSetting(Application.ProductName, sDisplayName, "col_order_" + i.ToString());
                MPCF.DeleteRegSetting(Application.ProductName, sDisplayName, "col_merge_" + i.ToString());
                MPCF.DeleteRegSetting(Application.ProductName, sDisplayName, "col_order_seq_" + i.ToString());
            }

            for (i = 1; i <= spdList.ActiveSheet.ColumnCount; i++)
            {
                st_col = (ST_COL_INFO)(spdList.ActiveSheet.Columns[i -1].Tag);

                MPCF.SaveRegSetting(Application.ProductName, sDisplayName, "col_name_" + i.ToString(), st_col.s_name);
                MPCF.SaveRegSetting(Application.ProductName, sDisplayName, "col_order_" + i.ToString(), st_col.s_order);
                MPCF.SaveRegSetting(Application.ProductName, sDisplayName, "col_merge_" + i.ToString(), st_col.s_merge);
                MPCF.SaveRegSetting(Application.ProductName, sDisplayName, "col_order_seq_" + i.ToString(), st_col.i_order_seq);
            }

            btnClose.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}