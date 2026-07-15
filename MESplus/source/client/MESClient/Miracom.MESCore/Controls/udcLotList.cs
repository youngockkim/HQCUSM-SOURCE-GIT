using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
using System.Collections;

namespace Miracom.MESCore.Controls
{
    public partial class udcLotList : UserControl
    {
        public udcLotList()
        {
            InitializeComponent();
        }

        #region " Event Definition "

        // delegate 이벤트선언
        public class ListRefreshEventArgs : EventArgs
        {
            private int mi_item;

            public int Item
            {
                get
                {
                   return this.mi_item;
                }
                set
                {
                    this.mi_item = value;
                }
            }
        }

        public delegate void ListRefreshEventHandler(object sender, ListRefreshEventArgs e);
        public event ListRefreshEventHandler ListRefreshEvent;

        public event FarPoint.Win.Spread.CellClickEventHandler CellClick
        {
            add
            {
                spdList.CellClick += value;
            }
            remove
            {
                spdList.CellClick -= value;
            }
        }

        public event FarPoint.Win.Spread.SelectionChangedEventHandler SelectionChanged
        {
            add
            {
                spdList.SelectionChanged += value;
            }
            remove
            {
                spdList.SelectionChanged -= value;
            }
        }

        #endregion

        #region " Variable Definition "

        public FarPoint.Win.Spread.FpSpread spdLotList
        {
            set { spdList = spdLotList; }
            get { return spdList; }
        }

        public string CurrentLotID
        {
            get
            {
                if (spdList.ActiveSheet.SelectionCount > 0)
                    return MPCF.Trim(spdList.ActiveSheet.Rows[spdList.ActiveSheet.ActiveRowIndex].Tag);
                else
                    return "";
            }
        }

        private string s_module_name;
        public string ModuleName
        {
            get
            {
                if (MPCF.Trim(s_module_name) == "") return "WIP";
                else return s_module_name;
            }
            set
            {
                s_module_name = value;
            }
        }

        private string s_service_name;
        public string ServiceName
        {
            get
            {
                if (MPCF.Trim(s_service_name) == "") return "WIP_View_Lot_List_Detail_By_SQL_Query";
                else return s_service_name;
            }
            set
            {
                s_service_name = value;
            }
        }

        private string s_parent_path;
        public string ParentPath
        {
            get
            {
                if (MPCF.Trim(s_parent_path) == "") return "LIST";
                else return s_parent_path;
            }
            set
            {
                s_parent_path = value;
            }
        }

        private bool b_got_favorites;

        private Hashtable ht_lot_icons;
        public Hashtable Icons
        {
            set { ht_lot_icons = value; }
            get { return ht_lot_icons; }
        }

        private ArrayList a_columns;
        private struct ST_COL_INFO
        {
            public string s_name;
            public string s_prompt;
            public string s_order;
            public string s_merge;
            public int i_order_seq;
        }
        private ArrayList a_sort_orders;
        private struct ST_SORT_ORDER
        {
            public int i_index;
            public bool b_asc_order;
            public int i_order_seq;
        }

        private string s_form_name;

        #endregion

        #region " Function Definition "

        public void SetInfo(string s_name)
        {
            s_form_name = s_name;
        }

        public void Init()
        {
            spdList.ActiveSheet.RowCount = 0;
            spdList.ActiveSheet.ColumnCount = 0;

            // Make Lot Icon from Image List
            MakeLotIcons();
            // Get Column Headeer from Registry
            GetColumnHeader();

            // Get Context Menu Items
            GetSubMenu();
        }

        private void GetColumnHeader()
        {
            int i;
            ST_COL_INFO st_col;
            string s_col_name;

            try
            {
                a_columns = new ArrayList();

                for (i = 1; i < 200; i++)
                {
                    if ((s_col_name = MPCF.GetRegSetting(Application.ProductName, s_form_name, "col_name_" + i.ToString(), "")) != "")
                    {
                        st_col = new ST_COL_INFO();
                        st_col.s_name = s_col_name;
                        st_col.s_order = MPCF.GetRegSetting(Application.ProductName, s_form_name, "col_order_" + i.ToString(), "N");
                        st_col.s_merge = MPCF.GetRegSetting(Application.ProductName, s_form_name, "col_merge_" + i.ToString(), "N");
                        st_col.i_order_seq = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, s_form_name, "col_order_seq_" + i.ToString(), "0"));

                        a_columns.Add(st_col);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void CompareColumnHeader(TRSNode out_node)
        {
            int i, k;
            ST_COL_INFO st_col;

            try
            {
                for (k = 0; k < a_columns.Count; k++)
                {
                    st_col = (ST_COL_INFO)a_columns[k];

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (out_node.GetList(0)[i].GetBoolean("CHECKED") == false)
                        {
                            if (st_col.s_name.Equals(out_node.GetList(0)[i].GetString("MEMBER_NAME")))
                            {
                                out_node.GetList(0)[i].AddBoolean("CHECKED", true);
                                st_col.s_prompt = out_node.GetList(0)[i].GetString("MEMBER_PRT");

                                a_columns[k] = st_col;
                                break;
                            }
                        }
                    }

                    if (i >= out_node.GetList(0).Count)
                    {
                        a_columns.RemoveAt(k);
                        k--;
                    }
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetBoolean("CHECKED") == false)
                    {
                        out_node.GetList(0)[i].AddBoolean("CHECKED", true);

                        st_col = new ST_COL_INFO();
                        st_col.s_name = out_node.GetList(0)[i].GetString("MEMBER_NAME");
                        st_col.s_prompt = out_node.GetList(0)[i].GetString("MEMBER_PRT");
                        st_col.s_order = "N";
                        st_col.s_merge = "N";

                        a_columns.Add(st_col);
                    }
                }

                for (i = 1; i < 200; i++)
                {
                    MPCF.DeleteRegSetting(Application.ProductName, s_form_name, "col_name_" + i.ToString());
                    MPCF.DeleteRegSetting(Application.ProductName, s_form_name, "col_order_" + i.ToString());
                    MPCF.DeleteRegSetting(Application.ProductName, s_form_name, "col_merge_" + i.ToString());
                    MPCF.DeleteRegSetting(Application.ProductName, s_form_name, "col_order_seq_" + i.ToString());
                }

                for (i = 1; i <= a_columns.Count; i++)
                {
                    st_col = (ST_COL_INFO)(a_columns[i - 1]);

                    MPCF.SaveRegSetting(Application.ProductName, s_form_name, "col_name_" + i.ToString(), st_col.s_name);
                    MPCF.SaveRegSetting(Application.ProductName, s_form_name, "col_order_" + i.ToString(), st_col.s_order);
                    MPCF.SaveRegSetting(Application.ProductName, s_form_name, "col_merge_" + i.ToString(), st_col.s_merge);
                    MPCF.SaveRegSetting(Application.ProductName, s_form_name, "col_order_seq_" + i.ToString(), st_col.i_order_seq);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void DisplayColumns()
        {
            int i, k;
            ST_COL_INFO st_col;
            ST_SORT_ORDER st_sort;
            ST_SORT_ORDER st_sort_a;
            ST_SORT_ORDER st_sort_b;

            try
            {
                a_sort_orders = new ArrayList();

                for (i = 0; i < a_columns.Count; i++)
                {
                    if (i + 1 > spdList.ActiveSheet.ColumnCount - 1)
                    {
                        break;
                    }

                    st_col = (ST_COL_INFO)a_columns[i];

                    if (st_col.s_prompt != null && st_col.s_prompt != "")
                    {
                        spdList.ActiveSheet.ColumnHeader.Cells[0, 1 + i].Value = st_col.s_prompt;
                    }
                    else
                    {
                        spdList.ActiveSheet.ColumnHeader.Cells[0, 1 + i].Value = st_col.s_name;
                    }
                    spdList.ActiveSheet.ColumnHeader.Cells[0, 1 + i].Tag = st_col.s_name;

                    if (st_col.s_merge == "Y")
                    {
                        spdList.ActiveSheet.Columns[1 + i].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
                    }

                    if (st_col.s_order == "A")
                    {
                        st_sort = new ST_SORT_ORDER();
                        st_sort.i_index = 1 + i;
                        st_sort.b_asc_order = true;
                        st_sort.i_order_seq = st_col.i_order_seq;

                        a_sort_orders.Add(st_sort);
                    }
                    else if (st_col.s_order == "D")
                    {
                        st_sort = new ST_SORT_ORDER();
                        st_sort.i_index = 1 + i;
                        st_sort.b_asc_order = false;
                        st_sort.i_order_seq = st_col.i_order_seq;

                        a_sort_orders.Add(st_sort);
                    }
                }

                for (i = 0; i < a_sort_orders.Count - 1; i++)
                {
                    st_sort_a = (ST_SORT_ORDER)a_sort_orders[i];

                    for (k = i + 1; k < a_sort_orders.Count; k++)
                    {
                        st_sort_b = (ST_SORT_ORDER)a_sort_orders[k];

                        if (st_sort_a.i_order_seq > st_sort_b.i_order_seq)
                        {
                            a_sort_orders[i] = st_sort_b;
                            a_sort_orders[k] = st_sort_a;

                            st_sort_a = (ST_SORT_ORDER)a_sort_orders[i];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private bool ViewServiceMemberList(string s_service_name, string s_parent_path)
        {
            TRSNode in_node = new TRSNode("VIEW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LIST_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '4';

                in_node.AddString("SERVICE_NAME", s_service_name);
                in_node.AddChar("DIRECTION", 'O');
                in_node.AddString("PARENT_MEMBER_PATH", s_parent_path);

                if (MPCR.CallService("SVM", "SVM_View_Service_Member_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList(0).Count > 0)
                {
                    spdList.ActiveSheet.ColumnCount = out_node.GetList(0).Count + 1;
                    spdList.ActiveSheet.ColumnHeader.Cells[0, 0].Value = "-";
                    spdList.ActiveSheet.Columns[0].Width = 20;

                    CompareColumnHeader(out_node);
                    DisplayColumns();
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public bool ViewFlexibleHeader(string s_service_name, string s_user_id, string s_dsp_id, string s_parent_path)
        {
            TRSNode in_node = new TRSNode("VIEW_FLEXIBLE_HEADER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FLEXIBLE_HEADER_LIST_OUT");

            try
            {
                spdList.ActiveSheet.RowCount = 0;
                spdList.ActiveSheet.ColumnCount = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '3';

                in_node.AddString("SERVICE_NAME", s_service_name);
                in_node.AddString("USER_ID", s_user_id, true);
                in_node.AddString("DSP_ID", s_dsp_id);
                in_node.AddString("PARENT_PATH", s_parent_path);

                if (MPCR.CallService("SEC", "SEC_View_Flexible_Header_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList(0).Count > 0)
                {
                    spdList.ActiveSheet.ColumnCount = out_node.GetList(0).Count + 1;
                    spdList.ActiveSheet.ColumnHeader.Cells[0, 0].Value = "-";
                    spdList.ActiveSheet.Columns[0].Width = 20;

                    CompareColumnHeader(out_node);
                    DisplayColumns();
                }
                else
                {
                    ViewServiceMemberList(s_service_name, s_parent_path);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        public bool GetSubMenu()
        {
            int i;
            ListView lisTmp;
            MenuItem mnuTmp;

            try
            {
                ctxMenu.MenuItems.Clear();
                lisTmp = new ListView();
                lisTmp.View = View.Details;

                lisTmp.Columns.Add(new ColumnHeader());
                lisTmp.Columns.Add(new ColumnHeader());
                SECLIST.ViewFavoritesList(lisTmp, '1', MPGV.gsProgramID, null, "");

                if (lisTmp.Items.Count < 1)
                {
                    b_got_favorites = false;
                    mnuTmp = new MenuItem("View Lot Status", new EventHandler(ctxMenu_Click));
                    mnuTmp.Tag = "WIP3001"; ctxMenu.MenuItems.Add(mnuTmp);
                    mnuTmp = new MenuItem("View Lot History", new EventHandler(ctxMenu_Click));
                    mnuTmp.Tag = "WIP3002"; ctxMenu.MenuItems.Add(mnuTmp);
                    ctxMenu.MenuItems.Add("-");
                    mnuTmp = new MenuItem("View Lot Trace", new EventHandler(ctxMenu_Click));
                    mnuTmp.Tag = "WIP3004"; ctxMenu.MenuItems.Add(mnuTmp);
                }
                else
                {
                    b_got_favorites = true;
                    for (i = 0; i < lisTmp.Items.Count; i++)
                    {
                        mnuTmp = new MenuItem(lisTmp.Items[i].SubItems[1].Text, new EventHandler(ctxMenu_Click));
                        mnuTmp.Tag = lisTmp.Items[i].Tag;
                        ctxMenu.MenuItems.Add(mnuTmp);
                    }
                }

                ctxMenu.MenuItems.Add("-");
                // Add display setup menu
                mnuTmp = new MenuItem("Display Setup", new EventHandler(ctxMenu_Click));
                mnuTmp.Tag = "DISPLAY_SETUP";
                ctxMenu.MenuItems.Add(mnuTmp);
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void MakeLotIcons()
        {
            FarPoint.Win.Spread.CellType.GeneralCellType lotCellIcon;

            ht_lot_icons = new Hashtable();

            lotCellIcon = new FarPoint.Win.Spread.CellType.GeneralCellType();
            lotCellIcon.BackgroundImage = new FarPoint.Win.Picture(MPGV.gIMdiForm.GetSmallIconList().Images[(int)SMALLICON_INDEX.IDX_LOT],
                                                                   FarPoint.Win.RenderStyle.Normal,
                                                                   Color.White,
                                                                   FarPoint.Win.HorizontalAlignment.Center,
                                                                   FarPoint.Win.VerticalAlignment.Center);
            ht_lot_icons.Add((int)SMALLICON_INDEX.IDX_LOT, lotCellIcon);

            lotCellIcon = new FarPoint.Win.Spread.CellType.GeneralCellType();
            lotCellIcon.BackgroundImage = new FarPoint.Win.Picture(MPGV.gIMdiForm.GetSmallIconList().Images[(int)SMALLICON_INDEX.IDX_LOT_HOLD],
                                                                   FarPoint.Win.RenderStyle.Normal,
                                                                   Color.White,
                                                                   FarPoint.Win.HorizontalAlignment.Center,
                                                                   FarPoint.Win.VerticalAlignment.Center);
            ht_lot_icons.Add((int)SMALLICON_INDEX.IDX_LOT_HOLD, lotCellIcon);

            lotCellIcon = new FarPoint.Win.Spread.CellType.GeneralCellType();
            lotCellIcon.BackgroundImage = new FarPoint.Win.Picture(MPGV.gIMdiForm.GetSmallIconList().Images[(int)SMALLICON_INDEX.IDX_LOT_START],
                                                                   FarPoint.Win.RenderStyle.Normal,
                                                                   Color.White,
                                                                   FarPoint.Win.HorizontalAlignment.Center,
                                                                   FarPoint.Win.VerticalAlignment.Center);
            ht_lot_icons.Add((int)SMALLICON_INDEX.IDX_LOT_START, lotCellIcon);

            lotCellIcon = new FarPoint.Win.Spread.CellType.GeneralCellType();
            lotCellIcon.BackgroundImage = new FarPoint.Win.Picture(MPGV.gIMdiForm.GetSmallIconList().Images[(int)SMALLICON_INDEX.IDX_LOT_REWORK],
                                                                   FarPoint.Win.RenderStyle.Normal,
                                                                   Color.White,
                                                                   FarPoint.Win.HorizontalAlignment.Center,
                                                                   FarPoint.Win.VerticalAlignment.Center);
            ht_lot_icons.Add((int)SMALLICON_INDEX.IDX_LOT_REWORK, lotCellIcon);

            lotCellIcon = new FarPoint.Win.Spread.CellType.GeneralCellType();
            lotCellIcon.BackgroundImage = new FarPoint.Win.Picture(MPGV.gIMdiForm.GetSmallIconList().Images[(int)SMALLICON_INDEX.IDX_LOT_ALTER],
                                                                   FarPoint.Win.RenderStyle.Normal,
                                                                   Color.White,
                                                                   FarPoint.Win.HorizontalAlignment.Center,
                                                                   FarPoint.Win.VerticalAlignment.Center);
            ht_lot_icons.Add((int)SMALLICON_INDEX.IDX_LOT_ALTER, lotCellIcon);

            lotCellIcon = new FarPoint.Win.Spread.CellType.GeneralCellType();
            lotCellIcon.BackgroundImage = new FarPoint.Win.Picture(MPGV.gIMdiForm.GetSmallIconList().Images[(int)SMALLICON_INDEX.IDX_LOT_RELEASE],
                                                                   FarPoint.Win.RenderStyle.Normal,
                                                                   Color.White,
                                                                   FarPoint.Win.HorizontalAlignment.Center,
                                                                   FarPoint.Win.VerticalAlignment.Center);
            ht_lot_icons.Add((int)SMALLICON_INDEX.IDX_LOT_RELEASE, lotCellIcon);

            lotCellIcon = new FarPoint.Win.Spread.CellType.GeneralCellType();
            lotCellIcon.BackgroundImage = new FarPoint.Win.Picture(MPGV.gIMdiForm.GetSmallIconList().Images[(int)SMALLICON_INDEX.IDX_REPAIR_LOT],
                                                                   FarPoint.Win.RenderStyle.Normal,
                                                                   Color.White,
                                                                   FarPoint.Win.HorizontalAlignment.Center,
                                                                   FarPoint.Win.VerticalAlignment.Center);
            ht_lot_icons.Add((int)SMALLICON_INDEX.IDX_REPAIR_LOT, lotCellIcon);

            lotCellIcon = new FarPoint.Win.Spread.CellType.GeneralCellType();
            lotCellIcon.BackgroundImage = new FarPoint.Win.Picture(MPGV.gIMdiForm.GetSmallIconList().Images[(int)SMALLICON_INDEX.IDX_SLOT_FULL],
                                                                   FarPoint.Win.RenderStyle.Normal,
                                                                   Color.White,
                                                                   FarPoint.Win.HorizontalAlignment.Center,
                                                                   FarPoint.Win.VerticalAlignment.Center);
            ht_lot_icons.Add((int)SMALLICON_INDEX.IDX_SLOT_FULL, lotCellIcon);
        }

        public void SortList()
        {
            int iRow, i;

            try
            {
                iRow = spdList.ActiveSheet.RowCount;
                spdList.ActiveSheet.RowCount++;
                for (i = 1; i < spdList.ActiveSheet.ColumnCount; i++)
                {
                    spdList.ActiveSheet.Cells[iRow, i].Value = spdList.ActiveSheet.ColumnHeader.Cells[0, i].Value;
                }
                for (i = 1; i < spdList.ActiveSheet.ColumnCount; i++)
                {
                    spdList.ActiveSheet.Columns[i].Width = spdList.ActiveSheet.GetPreferredColumnWidth(i);
                }
                spdList.ActiveSheet.Rows[iRow].Remove();

                if (a_sort_orders.Count > 0)
                {
                    ST_SORT_ORDER st_sort;
                    FarPoint.Win.Spread.SortInfo[] sorter = new FarPoint.Win.Spread.SortInfo[a_sort_orders.Count];

                    for (i = 0; i < a_sort_orders.Count; i++)
                    {
                        st_sort = (ST_SORT_ORDER)a_sort_orders[i];

                        sorter[i] = new FarPoint.Win.Spread.SortInfo(st_sort.i_index, st_sort.b_asc_order, System.Collections.Comparer.Default);
                    }

                    spdList.ActiveSheet.SortRows(0, spdList.ActiveSheet.RowCount, sorter);
                }

                spdList.ResumeLayout();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// View Lot List by Condition
        /// </summary>
        /// <returns></returns>
        public bool ViewLotList(char c_step, string s_res_id)
        {
            Hashtable lis_out = new Hashtable();

            return ViewLotList(c_step, "", 0, "", 0, "", "", "", s_res_id, "", "", "", "", ref lis_out);
        }
        public bool ViewLotList(char c_step, string s_mat_id, int i_mat_ver, string s_flow, int i_flow_seq_num, string s_oper, 
                                 string s_lot_id, string s_crr_id, string s_res_id,
                                 string s_attr_name, string s_attr_value, string s_lot_cmf_index, string s_lot_cmf_value, ref Hashtable lis_out)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");

            int i, i_row, i_col, i_img_index;
            string s_item_name;
            TRSNode member;
            //string s_value;

            int iTotLot;
            double dTotQty_1;
            double dTotQty_2;
            double dTotQty_3;
            FarPoint.Win.Spread.CellType.GeneralCellType lotCellIcon;

            try
            {
                MPCF.ClearList(spdList);
                MPGV.gaSelectLot_ID.Clear();
                MPGV.gsCurrentLot_ID = "";

                iTotLot = 0;
                dTotQty_1 = 0;
                dTotQty_2 = 0;
                dTotQty_3 = 0;

                if (spdList.ActiveSheet.ColumnCount < 1)
                {
                    ViewFlexibleHeader(this.ServiceName, MPGV.gsUserID, "", this.ParentPath);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("MAT_ID", s_mat_id);
                in_node.AddInt("MAT_VER", i_mat_ver);
                in_node.AddString("FLOW", s_flow);
                in_node.AddInt("FLOW_SEQ_NUM", i_flow_seq_num);
                in_node.AddString("OPER", s_oper);
                in_node.AddString("LOT_ID", s_lot_id);
                in_node.AddString("CRR_ID", s_crr_id);
                in_node.AddString("RES_ID", s_res_id);
                in_node.AddString("ATTR_NAME", s_attr_name);
                in_node.AddString("ATTR_VALUE", s_attr_value);
                in_node.AddString("LOT_CMF_1", s_lot_cmf_index);
                in_node.AddString("LOT_CMF_2", s_lot_cmf_value);

                do
                {
                    if (MPCR.CallService(this.ModuleName, this.ServiceName, in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        i_row = spdList.ActiveSheet.RowCount;
                        spdList.ActiveSheet.RowCount++;

                        spdList.ActiveSheet.Rows[i_row].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                        spdList.ActiveSheet.Rows[i_row].Locked = true;

                        i_img_index = (int)SMALLICON_INDEX.IDX_LOT;
                        if (out_node.GetList(0)[i].GetChar("HOLD_FLAG") == 'Y')
                        {
                            i_img_index = (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                        }
                        else if (out_node.GetList(0)[i].GetChar("START_FLAG") == 'Y')
                        {
                            i_img_index = (int)SMALLICON_INDEX.IDX_LOT_START;
                            spdList.ActiveSheet.Rows[i_row].BackColor = Color.LightCyan;
                        }
                        else if (out_node.GetList(0)[i].GetChar("RWK_FLAG") == 'Y')
                        {
                            i_img_index = (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                        }
                        else if (out_node.GetList(0)[i].GetChar("NSTD_FLAG") == 'Y')
                        {
                            i_img_index = (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                        }
                        else if (out_node.GetList(0)[i].GetString("LAST_TRAN_CODE") == MPGC.MP_TRAN_CODE_RELEASE)
                        {
                            i_img_index = (int)SMALLICON_INDEX.IDX_LOT_RELEASE;
                        }
                        else if (out_node.GetList(0)[i].GetChar("REP_FLAG") == 'Y')
                        {
                            i_img_index = (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                        }
                        else if (out_node.GetList(0)[i].GetChar("END_FLAG") == 'Y')
                        {
                            i_img_index = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                        }

                        lotCellIcon = (FarPoint.Win.Spread.CellType.GeneralCellType)Icons[i_img_index];
                        spdList.ActiveSheet.Cells[i_row, 0].CellType = lotCellIcon;

                        for (i_col = 1; i_col < spdList.ActiveSheet.ColumnCount; i_col++)
                        {
                            s_item_name = MPCF.Trim(spdList.ActiveSheet.ColumnHeader.Cells[0, i_col].Tag);

                            if (s_item_name.IndexOf("TIME") >= 0 || s_item_name.IndexOf("DATE") >= 0)
                            {
                                member = out_node.GetList(0)[i].GetMember(s_item_name);

                                s_attr_value = "";
                                if (member != null)
                                {
                                    s_attr_value = MPCF.MakeDateFormat(member.Value);
                                }
                            }
                            else if (s_item_name.IndexOf("QTY") >= 0)
                            {
                                member = out_node.GetList(0)[i].GetMember(s_item_name);

                                s_attr_value = "";
                                if (member != null)
                                {
                                    s_attr_value = MPCF.ToDbl(member.Value).ToString("########,##0.###");
                                }
                            }
                            else
                            {
                                member = out_node.GetList(0)[i].GetMember(s_item_name);

                                s_attr_value = "";
                                if (member != null)
                                {
                                    s_attr_value = member.Value;
                                }
                            }

                            spdList.ActiveSheet.Cells[i_row, i_col].Value = s_attr_value;
                        }

                        iTotLot++;
                        dTotQty_1 += out_node.GetList(0)[i].GetDouble("QTY_1");
                        dTotQty_2 += out_node.GetList(0)[i].GetDouble("QTY_2");
                        dTotQty_3 += out_node.GetList(0)[i].GetDouble("QTY_3");

                        spdList.ActiveSheet.Rows[i_row].Tag = out_node.GetList(0)[i].GetString("LOT_ID");
                        spdList.ActiveSheet.Cells[i_row, 0].Tag = out_node.GetList(0)[i].GetString("CRR_ID");
                    }
                    in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                } while (in_node.GetString("NEXT_LOT_ID") != "");

                lis_out.Add("TOT_LOT", iTotLot.ToString());
                lis_out.Add("TOT_LOT_QTY", dTotQty_1.ToString() + " / " + dTotQty_2.ToString() + " / " + dTotQty_3.ToString());

                // Display Setup에 의한 정렬
                SortList();

                if (s_lot_id != "")
                {
                    FocusLot(s_lot_id);
                }
                else if (s_crr_id != "")
                {
                    FocusLot(s_crr_id);
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Focus Lot
        /// </summary>
        /// <returns></returns>
        public bool FocusLot(string s_lot_id)
        {
            int i;

            for (i = 0; i < spdList.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdList.ActiveSheet.Rows[i].Tag).Equals(s_lot_id))
                {
                    MPGV.gsCurrentLot_ID = MPCF.Trim(spdList.ActiveSheet.Rows[i].Tag);

                    spdList.ActiveSheet.SetActiveCell(i, 0);
                    spdList.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Left);

                    spdList.ActiveSheet.ClearSelection();
                    spdList.ActiveSheet.AddSelection(i, 0, 1, 1);
                    spdList.Focus();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Focus Carrier Lot
        /// </summary>
        /// <returns></returns>
        public void FocusCarrierLot(string s_crr_id)
        {
            int i;

            for (i = 0; i < spdList.ActiveSheet.RowCount; i++)
            {
                if (MPCF.Trim(spdList.ActiveSheet.Cells[i, 0].Tag).Equals(s_crr_id))
                {
                    MPGV.gsCurrentLot_ID = MPCF.Trim(spdList.ActiveSheet.Rows[i].Tag);

                    spdList.ActiveSheet.SetActiveCell(i, 0);
                    spdList.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Center, FarPoint.Win.Spread.HorizontalPosition.Left);

                    spdList.ActiveSheet.ClearSelection();
                    spdList.ActiveSheet.AddSelection(i, 0, 1, 1);
                    spdList.Focus();
                    break;
                }
            }
        }

        public FarPoint.Win.Spread.FpSpread GetSpread()
        {
            return this.spdList;
        }

        #endregion

        private void udcLotList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ctxMenu.Show(spdList, new Point(e.X, e.Y));
            }
        }

        private void ctxMenu_Click(System.Object sender, System.EventArgs e)
        {
            if (((MenuItem)sender).Tag == null) return;

            if (MPCF.Trim(((MenuItem)sender).Tag) == "DISPLAY_SETUP")
            {
                frmSetupLotListDisplay f = new frmSetupLotListDisplay();
                f.SetLotListMainSheet(spdList.ActiveSheet, s_form_name);

                f.ShowDialog(this);

                spdList.ActiveSheet.RowCount = 0;
                spdList.ActiveSheet.ColumnCount = 0;

                a_columns.Clear();
                a_columns = null;

                a_sort_orders.Clear();
                a_sort_orders = null;

                GetColumnHeader();
                OnListRefreshEvent(null, null);
            }
            else
            {
                if (b_got_favorites == false)
                {
                    string s_func_name = MPCF.Trim(((MenuItem)sender).Tag);
                    MPGV.gIMdiForm.ActiveMenu(s_func_name);
                }
                else
                {
                    MenuInfoTag m_menu = (MenuInfoTag)(((MenuItem)sender).Tag);
                    MPGV.gIMdiForm.ActiveMenu(m_menu);
                }
            }
        }

        private void spdList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                if (spdList.ActiveSheet.SelectionCount == 0)
                {
                    Clipboard.SetDataObject("", true);
                }
                else
                {
                    Clipboard.SetDataObject(MPCF.Trim(spdList.ActiveSheet.Rows[spdList.ActiveSheet.ActiveRowIndex].Tag), true);
                }
            }
        }

        private void spdList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            int i, j;
            FarPoint.Win.Spread.Model.CellRange[] cl;

            MPGV.gaSelectLot_ID.Clear();
            MPGV.gsCurrentLot_ID = "";

            if (spdList.ActiveSheet.SelectionCount > 0)
            {
                cl = spdList.ActiveSheet.GetSelections();
                for (i = 0; i < cl.Length; i++)
                {
                    for (j = 0; j < cl[i].RowCount; j++)
                    {
                        MPGV.gaSelectLot_ID.Add(MPCF.Trim(spdList.ActiveSheet.Rows[cl[i].Row + j].Tag));
                    }
                }

                if (spdList.ActiveSheet.ActiveRowIndex >= 0)
                {
                    MPGV.gsCurrentLot_ID = MPCF.Trim(spdList.ActiveSheet.Rows[spdList.ActiveSheet.ActiveRowIndex].Tag);
                }
            }
        }

        protected void OnListRefreshEvent(object sender, ListRefreshEventArgs e)
        {
            if (ListRefreshEvent != null)
            {
                ListRefreshEvent(sender, e);
            }
        }
    }
}
