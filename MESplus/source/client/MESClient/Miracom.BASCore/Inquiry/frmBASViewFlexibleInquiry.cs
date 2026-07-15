using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.UI.Controls;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

using Miracom.TRSCore;
using System.Collections;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASViewFlexibleInquiry.cs
//   Description : 
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2011-02-19 : Created by dyoh
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.BASCore
{
    public partial class frmBASViewFlexibleInquiry : ViewForm01
    {
        public frmBASViewFlexibleInquiry()
        {
            InitializeComponent();
        }

        #region " Variable Definition"

        private bool b_load_flag;
		/* 2013.06.12. Aiden. 불필요한 Code 제거 및 기능 개선 */
        private int i_which_spread;

        #endregion

        #region " Function Definition"

        // CheckCondition()
        //       - check View condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool CheckCondition()
        {
            try
            {
                if (MPCF.CheckValue(cdvInquiryID, 1) == false)
                {
                    return false;
                }

                int i;

                if (spdInquiryCondition1.ActiveSheet.RowCount > 0)
                {
                    for (i = 0; i < spdInquiryCondition1.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdInquiryCondition1.ActiveSheet.Cells[i, 1].Value) == "" && (spdInquiryCondition1.ActiveSheet.Cells[i, 0].Font != null && spdInquiryCondition1.ActiveSheet.Cells[i, 0].Font.Bold == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            spdInquiryCondition1.ActiveSheet.SetActiveCell(i, 1);
                            spdInquiryCondition1.Select();
                            return false;
                        }
                    }
                }
                if (spdInquiryCondition2.ActiveSheet.RowCount > 0)
                {
                    for (i = 0; i < spdInquiryCondition2.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdInquiryCondition2.ActiveSheet.Cells[i, 1].Value) == "" && (spdInquiryCondition2.ActiveSheet.Cells[i, 0].Font != null && spdInquiryCondition2.ActiveSheet.Cells[i, 0].Font.Bold == true))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            spdInquiryCondition2.ActiveSheet.SetActiveCell(i, 1);
                            spdInquiryCondition2.Select();
                            return false;
                        }
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

        // Get_InquiryID_List()
        //       - Get InquiryID List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool GetInquiryIDList(ListView listView)
        {
            try
            {
                TRSNode in_node = new TRSNode("INQUIRY_ID_LIST_IN");
                TRSNode out_node = new TRSNode("INQUIRY_ID_LIST_OUT");
                ListViewItem viewItem;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.AddString("INQUIRY_GROUP", MPCF.Trim(cdvInquiryGrp.Text));

                if (MPCR.CallService("BAS", "BAS_View_Flexible_Condition_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (int i = 0; i < out_node.GetList(0).Count; i++)
                {
                    viewItem = listView.Items.Add(new ListViewItem(out_node.GetList(0)[i].GetString("INQUIRY_ID"), (int)SMALLICON_INDEX.IDX_MODULE));
                    viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("INQUIRY_DESC1"));
                    viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("INQUIRY_TITLE"));
                    viewItem.SubItems.Add(out_node.GetList(0)[i].GetString("SQL_ID_1"));
                }
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewInquiryCondition()
        {
            TRSNode in_node = new TRSNode("VIEW_INQUIRY_CONDITION_IN");
            TRSNode out_node = new TRSNode("VIEW_INQUIRY_CONDITION_OUT");

            FarPoint.Win.Spread.CellType.NumberCellType numCell;
            FarPoint.Win.Spread.CellType.TextCellType txtCell;
            FarPoint.Win.Spread.CellType.ButtonCellType btnCell;
            FarPoint.Win.Spread.CellType.DateTimeCellType dateCell;
            int i_row;
            int i;
            int i_cond_count_1;
            int i_cond_count_2;

            try
            {
                MPCF.ClearList(spdInquiryCondition1);
                MPCF.ClearList(spdInquiryCondition2);
                i_cond_count_1 = i_cond_count_2 = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INQUIRY_ID", cdvInquiryID.Text);
                in_node.AddString("SQL_ID_1", cdvInquiryID.SelectedItem.SubItems[3].Text);

                if (MPCR.CallService("BAS", "BAS_View_Flexible_Condition_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                string s_member_name;
                FarPoint.Win.Spread.SheetView sv;

                for (i = 0; i < 20; i++)
                {
                    if ((i >= 0 && i < 5) || (i >= 10 && i < 15))
                    {
                        sv = spdInquiryCondition1.ActiveSheet;
                    }
                    else
                    {
                        sv = spdInquiryCondition2.ActiveSheet;
                    }

                    i_row = sv.RowCount;
                    sv.RowCount++;
                    sv.RowHeader.Cells[i_row, 0].Value = i + 1;

                    s_member_name = "PRT_" + (i + 1).ToString();
                    if (out_node.GetString(s_member_name) == "")
                    {
                        sv.Rows[i_row].Visible = false;
                    }
                    else
                    {
                        if ((i >= 0 && i < 5) || (i >= 10 && i < 15))
                        {
                            i_cond_count_1++;
                        }
                        else
                        {
                            i_cond_count_2++;
                        }

                        sv.Cells[i_row, 0].Value = out_node.GetString(s_member_name);

                        s_member_name = "REQ_" + (i + 1).ToString();
                        if (out_node.GetChar(s_member_name) == 'Y')
                        {
                            sv.Cells[i_row, 0].Font = new Font(spdInquiryCondition1.Font, FontStyle.Bold);
                        }

                        s_member_name = "FMT_" + (i + 1).ToString();
                        if (out_node.GetChar(s_member_name) == 'A')
                        {
                            txtCell = new FarPoint.Win.Spread.CellType.TextCellType();
                            s_member_name = "SIZE_" + (i + 1).ToString();
                            txtCell.MaxLength = out_node.GetInt(s_member_name);

                            sv.Cells[i_row, 1].CellType = txtCell;
                        }
                        else if (out_node.GetChar(s_member_name) == 'N' || out_node.GetChar(s_member_name) == 'F')
                        {
                            numCell = new FarPoint.Win.Spread.CellType.NumberCellType();
                            numCell.ShowSeparator = true;
                            numCell.DecimalPlaces = 0;
                            if (out_node.GetChar(s_member_name) == 'F')
                            {
                                numCell.DecimalPlaces = 3;
                            }

                            sv.Cells[i_row, 1].CellType = numCell;
                        }

                        string s_table_name;

                        s_member_name = "TBL_" + (i + 1).ToString();
                        s_table_name = out_node.GetString(s_member_name);
                        if (s_table_name == "$FROM_DATE" || s_table_name == "$TO_DATE")
                        {
                            dateCell = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                            dateCell.DropDownButton = true;
                            sv.Cells[i_row, 1].ColumnSpan = 2;
                            sv.Cells[i_row, 1].CellType = dateCell;
                            sv.Cells[i_row, 1].Tag = s_table_name;

                            if (s_table_name == "$FROM_DATE")
                            {
                                sv.Cells[i_row, 1].Value = DateTime.Today.AddDays(-7);
                            }
                            else
                            {
                                sv.Cells[i_row, 1].Value = DateTime.Today;
                            }
                        }
                        else if (s_table_name != "")
                        {
                            btnCell = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            btnCell.Text = "...";

                            sv.Cells[i_row, 2].CellType = btnCell;
                            sv.Cells[i_row, 2].Tag = s_table_name;
                        }
                        else
                        {
                            sv.Cells[i_row, 1].ColumnSpan = 2;
                        }
                    }
                }


                if (i_cond_count_1 < 1 && i_cond_count_2 < 1)
                {
                    pnlGenTop.Visible = false;
                }
                else if (i_cond_count_2 < 1)
                {
                    pnlInquiryCondition2.Visible = false;
                    pnlPrvGrpMidMid.Visible = false;
                    pnlInquiryCondition1.Dock = DockStyle.Fill;
                }


                if (i_cond_count_2 > i_cond_count_1)
                {
                    i_cond_count_1 = i_cond_count_2;
                }

                if (i_cond_count_1 > 0)
                {
                    pnlGenTop.Height = 25 + i_cond_count_1 * 20;
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // View_Data_List()
        //       - View All General Code Data list which is included in one General Code Table
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewDataList(string[] sArgu)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            int i;
            ArrayList a_list;

            try
            {
                MPCF.ClearList(spdInqQueryResult);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL_ID_1", cdvInquiryID.SelectedItem.SubItems[3].Text);

                if (sArgu != null)
                {
                    for (i = 0; i < sArgu.Length; i++)
                    {
                        TRSNode node = in_node.AddNode("ARGU_LIST");
                        node.AddString("ARGUMENT", sArgu[i]);
                    }
                }

                a_list = new ArrayList();

                do
                {
                    out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                    if (MPCR.CallService("BAS", "BAS_View_Query_Result_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    Cursor.Current = Cursors.WaitCursor;
                    if (out_node.GetList("SQL_OUT").Count > 0)
                    {
                        a_list.Add(out_node);
                    }

                    if (numLoopCount.Value > 0)
                    {
                        if (a_list.Count >= numLoopCount.Value)
                        {
                            break;
                        }
                    }

                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                } while (in_node.GetInt("NEXT_ROW") > 0);

                foreach (object obj in a_list)
                {
                    out_node = (TRSNode)obj;
                    MPCR.FillDataView(spdInqQueryResult, out_node.GetList("SQL_OUT")[0], false, 0, false);
                }

                if (spdInqQueryResult.ActiveSheet.ColumnCount > 0)
                {
                    spdInqQueryResult.ActiveSheet.Columns[0, spdInqQueryResult.ActiveSheet.ColumnCount - 1].AllowAutoSort = true;
                    spdInqQueryResult.ActiveSheet.Columns[0, spdInqQueryResult.ActiveSheet.ColumnCount - 1].AllowAutoFilter = true;
                }

                if (spdInqQueryResult.ActiveSheet.RowCount < 1000 && spdInqQueryResult.ActiveSheet.ColumnCount < 50)
                {
                    MPCF.FitColumnHeader(spdInqQueryResult);
                }

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                Cursor.Current = Cursors.Default;
                return false;
            }
        }

        private bool ViewDataListWithSplit(string[] sArgu)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            int i;
            ArrayList a_list;
            DataTable dt;

            try
            {
                MPCF.ClearList(spdInqQueryResult);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL_ID_1", cdvInquiryID.SelectedItem.SubItems[3].Text);

                if (sArgu != null)
                {
                    for (i = 0; i < sArgu.Length; i++)
                    {
                        TRSNode node = in_node.AddNode("ARGU_LIST");
                        node.AddString("ARGUMENT", sArgu[i]);
                    }
                }

                a_list = new ArrayList();

                do
                {
                    out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                    if (MPCR.CallService("BAS", "BAS_View_Query_Result_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    Cursor.Current = Cursors.WaitCursor;
                    if (out_node.GetList("SQL_OUT").Count > 0)
                    {
                        a_list.Add(out_node);
                    }

                    if (numLoopCount.Value > 0)
                    {
                        if (a_list.Count >= numLoopCount.Value)
                        {
                            break;
                        }
                    }

                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                } while (in_node.GetInt("NEXT_ROW") > 0);


                dt = new DataTable();

                foreach (object obj in a_list)
                {
                    out_node = (TRSNode)obj;
                    MPCR.FillDataViewWithDT(spdInqQueryResult, out_node.GetList("SQL_OUT")[0], false, 0, false, ref dt);
                }

                spdInqQueryResult.DataSource = dt;
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    spdInqQueryResult.ActiveSheet.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    if (dt.Columns[i].DataType.Equals(Type.GetType("System.Double")) == true)
                    {
                        if (MPCF.Trim(spdInqQueryResult.ActiveSheet.Columns[i].Tag) != "Double")
                        {
                            try
                            {
                                ((FarPoint.Win.Spread.CellType.NumberCellType)(spdInqQueryResult.ActiveSheet.Columns[i].CellType)).DecimalPlaces =
                                    out_node.GetList("SQL_OUT")[0].GetList("COLUMNS")[i].GetInt("SCALE");
                                spdInqQueryResult.ActiveSheet.Columns[i].Tag = "Double";
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine(ex.Message);
                            }
                        }
                    }
                }

                if (spdInqQueryResult.ActiveSheet.ColumnCount > 0)
                {
                    spdInqQueryResult.ActiveSheet.Columns[0, spdInqQueryResult.ActiveSheet.ColumnCount - 1].AllowAutoSort = true;
                    spdInqQueryResult.ActiveSheet.Columns[0, spdInqQueryResult.ActiveSheet.ColumnCount - 1].AllowAutoFilter = true;
                }

                if (spdInqQueryResult.ActiveSheet.RowCount < 1000 && spdInqQueryResult.ActiveSheet.ColumnCount < 50)
                {
                    MPCF.FitColumnHeader(spdInqQueryResult);
                }

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                Cursor.Current = Cursors.Default;
                return false;
            }
        }

        private bool AutoCalWidthInqCondition1()
        {
            int i_gap;

            try
            {
                i_gap = grpInquiryCondition.Width / 2 - 358;
                if ((150 + i_gap) > 0)
                {
                    spdInquiryCondition1.ActiveSheet.Columns[1].Width = 150 + i_gap;
                    spdInquiryCondition2.ActiveSheet.Columns[1].Width = 150 + i_gap - 6;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message + " : AutoCalWidth_InqCondition1()");
                return false;
            }
        }

        private bool GetQueryArgument()
        {
            FarPoint.Win.Spread.SheetView sv;
            int i;
            int i_row;
            int i_row_1;
            int i_row_2;
            string[] sArgu;

            sArgu = new string[20];

            for (i = 0; i < 20; i++)
            {
                sArgu[i] = "";
            }

            i_row = i_row_1 = i_row_2 = -1;
            for (i = 0; i < 20; i++)
            {
                if ((i >= 0 && i < 5) || (i >= 10 && i < 15))
                {
                    sv = spdInquiryCondition1.ActiveSheet;
                    i_row_1++;
                    i_row = i_row_1;
                }
                else
                {
                    sv = spdInquiryCondition2.ActiveSheet;
                    i_row_2++;
                    i_row = i_row_2;
                }

                if (MPCF.Trim(sv.Cells[i_row, 0].Value) != "")
                {
                    if (MPCF.Trim(sv.Cells[i_row, 1].Tag) == "$FROM_DATE")
                    {
                        sArgu[i] = MPCF.FromDate(sv.Cells[i_row, 1].Value);
                    }
                    else if (MPCF.Trim(sv.Cells[i_row, 1].Tag) == "$TO_DATE")
                    {
                        sArgu[i] = MPCF.ToDate(sv.Cells[i_row, 1].Value);
                    }
                    else
                    {
                        sArgu[i] = MPCF.Trim(sv.Cells[i_row, 1].Value);
                    }
                }
            }

            if (cdvInquiryID.SelectedItem.SubItems[3].Text[0] == '@')
            {
                ViewDataListWithSplit(sArgu);
            }
            else
            {
                ViewDataList(sArgu);
            }

            return true;
        }

        private void ClearData()
        {
            pnlGenTop.Visible = true;
            pnlInquiryCondition2.Visible = true;
            pnlPrvGrpMidMid.Visible = true;
            pnlInquiryCondition1.Dock = DockStyle.Left;

            MPCF.ClearList(spdInquiryCondition1);
            MPCF.ClearList(spdInquiryCondition2);
            MPCF.ClearList(spdInqQueryResult);
        }

        #endregion

        private void frmBASViewFlexibleInquiry_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.FieldClear(this);

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvInquiryGrp_ButtonPress(object sender, EventArgs e)
        {
            string s_table_name = "INQUIRY_GROUP";

            cdvInquiryGrp.Init();
            MPCF.InitListView(cdvInquiryGrp.GetListView);
            cdvInquiryGrp.Columns.Add("Inquiry Group", 20, HorizontalAlignment.Left);
            cdvInquiryGrp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvInquiryGrp.GetListView, '1', s_table_name);
            cdvInquiryGrp.InsertEmptyRow(0, 1);
        }

        private void cdvInquiryGrp_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.FieldClear(cdvInquiryID);
            ClearData();
        }

        private void cdvInquiryID_ButtonPress(object sender, EventArgs e)
        {
            cdvInquiryID.Init();
            MPCF.InitListView(cdvInquiryID.GetListView);
            cdvInquiryID.Columns.Add("Inquiry ID", 50, HorizontalAlignment.Left);
            cdvInquiryID.SelectedSubItemIndex = 0;

            GetInquiryIDList(cdvInquiryID.GetListView);
        }

        private void cdvInquiryID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvInquiryID.DescText = cdvInquiryID.SelectedItem.SubItems[1].Text;
            this.Text = cdvInquiryID.SelectedItem.SubItems[2].Text;

            ClearData();

            ViewInquiryCondition();
        }

        private void grpInquiryCondition_Resize(object sender, EventArgs e)
        {
            MPCF.FieldAdjust(grpInquiryCondition, pnlInquiryCondition1, pnlInquiryCondition2, pnlPrvGrpMidMid, 15);
        }

        private void cdvTableList_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            //Modify by J.S. 2011.10.13 가야할 spread가 2개라서 구분 필요
            if (i_which_spread == 0)
            {
                spdInquiryCondition1.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;
            }
            else
            {
                spdInquiryCondition2.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.Text;
            }
        }

        private void spdInquiryCondition1_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string s_table_name = MPCF.Trim(spdInquiryCondition1.ActiveSheet.Cells[e.Row, 2].Tag);

            //Modify by J.S. 2011.10.13 가야할 spread가 2개라서 구분 필요
            i_which_spread = 0;

            cdvTableList.Init();
            cdvTableList.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvTableList.GetListView);

            //Special 항목 추가
            if (s_table_name == "$MATERIAL")
            {
                cdvTableList.Columns.Add("Material", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Version", 40, HorizontalAlignment.Center);
                cdvTableList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                WIPLIST.ViewMaterialList(cdvTableList.GetListView, '1');
            }
            else if (s_table_name == "$FLOW")
            {
                cdvTableList.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                WIPLIST.ViewFlowList(cdvTableList.GetListView, '1', "", 0, "", null, "");
            }
            else if (s_table_name == "$OPERATION")
            {
                cdvTableList.Columns.Add("Operarion", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                WIPLIST.ViewOperationList(cdvTableList.GetListView, '1', "", 0, "", "", null, "");
            }
            else if (s_table_name == "$RESOURCE")
            {
                cdvTableList.Columns.Add("Resource", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                RASLIST.ViewResourceList(cdvTableList.GetListView, false);
            }
            else if (s_table_name != "")
            {
                cdvTableList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
                cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', s_table_name);
            }
            if (cdvTableList.Items.Count > 0)
            {
                cdvTableList.ShowPopupList(e.Row, e.Column);
            }
        }

        private void spdInquiryCondition1_EditModeOff(object sender, EventArgs e)
        {
            try
            {
                int i_row = spdInquiryCondition1.ActiveSheet.ActiveRowIndex;
                int i_col = spdInquiryCondition1.ActiveSheet.ActiveColumnIndex;
                int i;

                for (i = i_row + 1; i < spdInquiryCondition1.ActiveSheet.RowCount; i++)
                {
                    if (spdInquiryCondition1.ActiveSheet.Cells[i, i_col].Locked == false)
                    {
                        spdInquiryCondition1.ActiveSheet.SetActiveCell(i, i_col);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdInquiryCondition2_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string s_table_name = MPCF.Trim(spdInquiryCondition2.ActiveSheet.Cells[e.Row, 2].Tag);

            //Modify by J.S. 2011.10.13 가야할 spread가 2개라서 구분 필요
            i_which_spread = 1;

            cdvTableList.Init();
            cdvTableList.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvTableList.GetListView);

            //Special 항목 추가
            if (s_table_name == "$MATERIAL")
            {
                cdvTableList.Columns.Add("Material", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Version", 40, HorizontalAlignment.Center);
                cdvTableList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                WIPLIST.ViewMaterialList(cdvTableList.GetListView, '1');
            }
            else if (s_table_name == "$FLOW")
            {
                cdvTableList.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                WIPLIST.ViewFlowList(cdvTableList.GetListView, '1', "", 0, "", null, "");
            }
            else if (s_table_name == "$OPERATION")
            {
                cdvTableList.Columns.Add("Operarion", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                WIPLIST.ViewOperationList(cdvTableList.GetListView, '1', "", 0, "", "", null, "");
            }
            else if (s_table_name == "$RESOURCE")
            {
                cdvTableList.Columns.Add("Resource", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                RASLIST.ViewResourceList(cdvTableList.GetListView, false);
            }
            else if (s_table_name != "")
            {
                cdvTableList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
                cdvTableList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', s_table_name);
            }

            if (cdvTableList.Items.Count > 0)
            {
                cdvTableList.ShowPopupList(e.Row, e.Column);
            }
        }

        private void spdInquiryCondition2_EditModeOff(object sender, EventArgs e)
        {
            try
            {
                int i_row = spdInquiryCondition2.ActiveSheet.ActiveRowIndex;
                int i_col = spdInquiryCondition2.ActiveSheet.ActiveColumnIndex;
                int i;

                for (i = i_row + 1; i < spdInquiryCondition2.ActiveSheet.RowCount; i++)
                {
                    if (spdInquiryCondition2.ActiveSheet.Cells[i, i_col].Locked == false)
                    {
                        spdInquiryCondition2.ActiveSheet.SetActiveCell(i, i_col);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition() == false) return;

                if (GetQueryArgument() == false) return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (sfdExcel.ShowDialog(this) == DialogResult.Cancel) return;

                spdInqQueryResult.ActiveSheet.Protect = false;
                spdInqQueryResult.SaveExcel(sfdExcel.FileName, FarPoint.Excel.ExcelSaveFlags.SaveBothCustomRowAndColumnHeaders);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void pnlBottom_DoubleClick(object sender, EventArgs e)
        {
            pnlLoopCount.Visible = true;
        }


    }
}
