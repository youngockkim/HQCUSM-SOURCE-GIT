//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASViewSheetResult.cs
//   Description : MES Cient Form View Sheet Result
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-02-29 : Created by James Kwon
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
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
namespace Miracom.RASCore
{
    public partial class frmRASViewCheckResult : Miracom.MESCore.SetupForm02
    {
        #region " Constant Definition "

        private const int MAX_VALUE_COUNT = 500;

        #endregion

        #region "VariableDefinition"

        private bool b_load_flag;

        private FarPoint.Win.Spread.CellType.GeneralCellType plusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType minusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType emptyCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType checkCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();

        private FarPoint.Win.Spread.CellType.GeneralCellType increaseCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType decreaseCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();

        private enum CELL_STATUS
        {
            PLUS = 1,
            MINUS = 2,
            EMPTY = 3,
            CHECK = 4
        }

        #endregion

        #region " Function Definition "


        // UnderLine()
        //       - Add Under Line Border in spdSheetData
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void UnderLine()
        {
            spdSheetData.Sheets[0].Rows[spdSheetData.Sheets[0].RowCount - 1].Height = 16;

            spdSheetData.Sheets[0].Cells[spdSheetData.Sheets[0].RowCount - 1, 0, spdSheetData.Sheets[0].RowCount - 1, spdSheetData.Sheets[0].ColumnCount - 1].Border = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
        }

        // ViewSheet()
        //       - View PM Sheet
        // Return Value
        //       - boolean : True / False
        private bool ViewSheetResult(char p_step)
        {
            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("View_Sheet_Result_List_In");
            TRSNode out_node;
           
            try
            {
                MPCF.ClearList(spdSheetData, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = p_step;
                in_node.AddString("SHEET_NAME", lisSheetName.SelectedItems[0].Text);
                in_node.AddString("DATA_TYPE", cdvGrpDataType.Text);
                in_node.AddInt("NEXT_NUM", 0);
                in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));

                do
                {
                    out_node = new TRSNode("View_Sheet_Result_List_Out");

                    if (MPCR.CallService("RAS", "RAS_View_Sheet_Result_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_NAME")), (int)SMALLICON_INDEX.IDX_MESSAGE);
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("DATA_TYPE")));

                        if(lisSheetData.Columns.Count >= 3)
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_KEY_1")));

                        if (lisSheetData.Columns.Count >= 4)
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_KEY_2")));

                        if (lisSheetData.Columns.Count >= 5)
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_KEY_3")));

                        if (lisSheetData.Columns.Count >= 6)
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_KEY_4")));

                        if (lisSheetData.Columns.Count >= 7)
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_KEY_5")));

                        if (lisSheetData.Columns.Count >= 8)
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_KEY_6")));

                        if (lisSheetData.Columns.Count >= 9)
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_KEY_7")));

                        if (lisSheetData.Columns.Count >= 10)
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_KEY_8")));

                        if (lisSheetData.Columns.Count >= 11)
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_KEY_9")));

                        if (lisSheetData.Columns.Count >= 12)
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("SHEET_KEY_10")));

                        lisSheetData.Items.Add(itmX);                        
                    }

                    in_node.SetInt("NEXT_NUM", out_node.GetInt("NEXT_NUM"));

            } while (in_node.GetInt("NEXT_NUM") > 0);

                return true;
            }
            catch(Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        // ViewSheet()
        //       - View PM Sheet
        // Return Value
        //       - boolean : True / False
        private bool ViewSheetResultData(char p_step)
        {
            int i, j, i_row;

            TRSNode in_node = new TRSNode("View_Sheet_Result_Data_List_In");
            TRSNode out_node = new TRSNode("View_Sheet_Result_Data_List_Out");
            
            try
            {
                MPCF.ClearList(spdSheetData, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = p_step;
                in_node.AddString("SHEET_NAME", lisSheetData.SelectedItems[0].Text);
                in_node.AddString("DATA_TYPE", lisSheetData.SelectedItems[0].SubItems[1].Text);


                if (lisSheetData.Columns.Count >= 3)
                    in_node.AddString("SHEET_KEY_1", lisSheetData.SelectedItems[0].SubItems[2].Text);
                
                if (lisSheetData.Columns.Count >= 4)
                    in_node.AddString("SHEET_KEY_2", lisSheetData.SelectedItems[0].SubItems[3].Text);
                
                if (lisSheetData.Columns.Count >= 5)
                    in_node.AddString("SHEET_KEY_3", lisSheetData.SelectedItems[0].SubItems[4].Text);

                if (lisSheetData.Columns.Count >= 6)
                    in_node.AddString("SHEET_KEY_4", lisSheetData.SelectedItems[0].SubItems[5].Text);

                if (lisSheetData.Columns.Count >= 7)
                    in_node.AddString("SHEET_KEY_5", lisSheetData.SelectedItems[0].SubItems[6].Text);

                if (lisSheetData.Columns.Count >= 8)
                    in_node.AddString("SHEET_KEY_6", lisSheetData.SelectedItems[0].SubItems[7].Text);

                if (lisSheetData.Columns.Count >= 9)
                    in_node.AddString("SHEET_KEY_7", lisSheetData.SelectedItems[0].SubItems[8].Text);

                if (lisSheetData.Columns.Count >= 10)
                    in_node.AddString("SHEET_KEY_8", lisSheetData.SelectedItems[0].SubItems[9].Text);

                if (lisSheetData.Columns.Count >= 11)
                    in_node.AddString("SHEET_KEY_9", lisSheetData.SelectedItems[0].SubItems[10].Text);

                if (lisSheetData.Columns.Count >= 12)
                    in_node.AddString("SHEET_KEY_10", lisSheetData.SelectedItems[0].SubItems[11].Text);

                in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));


                do
                {
                    out_node = new TRSNode("View_Sheet_Result_Data_List_Out");

                    if (MPCR.CallService("RAS", "RAS_View_Sheet_Result_Data_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        i_row = spdSheetData.Sheets[0].RowCount;
                        spdSheetData.Sheets[0].RowCount++;

                        spdSheetData.Sheets[0].Cells[i_row, 0].CellType = minusCellType;
                        spdSheetData.Sheets[0].Cells[i_row, 0].Tag = CELL_STATUS.MINUS;

                        spdSheetData.Sheets[0].Cells[i_row, 1].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));

                        for (j = 0; j < out_node.GetList(0)[i].GetList(0).Count; j++)
                        {
                            if (out_node.GetList(0)[i].GetList(0)[j].GetChar("COMPLETE_FLAG") == 'Y')
                                spdSheetData.Sheets[0].Rows[i_row].Font = new Font(spdSheetData.Font.Name, spdSheetData.Font.Size, FontStyle.Bold);
                            spdSheetData.Sheets[0].Cells[i_row, 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetList(0)[j].GetInt("DATA_SEQ"));
                            spdSheetData.Sheets[0].Cells[i_row, 3].Value = MPCF.Trim(out_node.GetList(0)[i].GetList(0)[j].GetString("SHEET_DATA")).Replace("\r\n", " ");
                            spdSheetData.Sheets[0].Cells[i_row, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetList(0)[j].GetString("RESULT_VALUE"));
                            spdSheetData.Sheets[0].Cells[i_row, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetList(0)[j].GetString("SHEET_COMMENT"));

                            i_row = spdSheetData.Sheets[0].RowCount;
                            if (j < out_node.GetList(0).Count - 1)
                                spdSheetData.Sheets[0].RowCount++;
                        }

                        UnderLine();
                    }
                    in_node.SetString("TO_TIME", out_node.GetString("TO_TIME"));

            } while (in_node.GetString("TO_TIME") != "" );
                 
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        //
        // View_Sheet_Key()
        //       - View Sheet Group
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal Sheet_Type As String
        //
        private bool View_Sheet_Key(string Data_Type)
        {
            int i;

            lisSheetData.Columns.Clear();
            lisSheetData.Items.Clear();

            lisSheetData.Columns.Add("Sheet Name");
            lisSheetData.Columns.Add("Data Type");

            if (MPCF.Trim(Data_Type) == "")
            {
                return true;
            }

            try
            {
                TRSNode in_node = new TRSNode("View_Sheet_Type_Def_In");
                TRSNode out_node = new TRSNode("View_Sheet_Type_Def_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SHEET_TYPE", Data_Type);
                in_node.AddChar("TYPE_FLAG", 'D');

                if (MPCR.CallService("RAS", "RAS_View_Sheet_Type_Def", in_node, ref out_node) == false)
                {
                    return false;
                }
               

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION")) != "")
                        lisSheetData.Columns.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CAT_CAPTION")));
                }

                for (i = 0; i < lisSheetData.Columns.Count; i++)
                {
                    lisSheetData.Columns[i].Width = (int)(lisSheetData.Columns[i].Text.Length * 12);
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmRASViewSheetResult.View_Sheet_Key()\n" + ex.Message);
                return false;
            }
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cdvGrpDataType;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        public frmRASViewCheckResult()
        {
            InitializeComponent();
        }

        private void frmRASViewSheetResult_Load(object sender, EventArgs e)
        {
            DateTime curDate = new DateTime();

            MPCF.InitListView(lisSheetName);
            MPCF.InitListView(lisSheetData);

            plusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[(int)CELL_STATUS.PLUS - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            minusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[(int)CELL_STATUS.MINUS - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);

            curDate = DateTime.Today;

            dtpTo.Value = curDate;
            dtpFrom.Value = curDate.AddDays(-7);
        }

        private void frmRASViewSheetResult_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                b_load_flag = true;
            }
        }

        private void cdvGrpDataType_ButtonPress(object sender, EventArgs e)
        {
            cdvGrpDataType.Init();
            MPCF.InitListView(cdvGrpDataType.GetListView);
            cdvGrpDataType.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvGrpDataType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvGrpDataType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvGrpDataType.GetListView, '1', MPGC.MP_SHEET_DATA_TYPE);
        }

        private void cdvGrpDataType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            MPCF.FieldClear(this.pnlRight);

            View_Sheet_Key(MPCF.Trim(cdvGrpDataType.Text));

            btnRefresh.PerformClick();
        }

        private void lisSheetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisSheetName.SelectedItems.Count <= 0)
                return;

            if (MPCF.Trim(cdvGrpDataType.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvGrpDataType.Focus();
                return;
            }

            if (View_Sheet_Key(cdvGrpDataType.Text) == false)
                return;

            if (ViewSheetResult('1') == false)
                return;
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            int i;

            FarPoint.Win.Spread.SheetView with_1 = spdSheetData.Sheets[0];
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, 0].Tag) == "")
                {
                    with_1.Rows[i].Visible = false;
                }
                else
                {
                    if (MPCF.ToInt(with_1.Cells[i, 0].Tag) == (int)CELL_STATUS.MINUS)
                    {
                        with_1.Cells[i, 0].CellType = plusCellType;
                        with_1.Cells[i, 0].Tag = CELL_STATUS.PLUS;
                    }
                }
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            int i;

            FarPoint.Win.Spread.SheetView with_1 = spdSheetData.Sheets[0];
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, 0].Tag) == "")
                {
                    with_1.Rows[i].Visible = true;
                }
                else
                {
                    if (MPCF.ToInt(with_1.Cells[i, 0].Tag) == (int)CELL_STATUS.PLUS)
                    {
                        with_1.Cells[i, 0].CellType = minusCellType;
                        with_1.Cells[i, 0].Tag = CELL_STATUS.MINUS;
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                if (RASLIST.ViewSheetList(lisSheetName, '2', cdvGrpDataType.Text) == false)
                {
                    return;
                }

                lblDataCount.Text = lisSheetName.Items.Count.ToString();
                if (lisSheetName.Items.Count > 0)
                {
                    lisSheetName.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisSheetData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lisSheetData.SelectedItems.Count <= 0)
                return;

            if (ViewSheetResultData('1') == false)
                return;
        }

        private void spdSheetData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int i;

            if (spdSheetData.Sheets[0].RowCount < 1)
            {
                return;
            }
            if (e.Column != 0)
            {
                return;
            }
            if (e.Row < 0)
            {
                return;
            }
            if (e.ColumnHeader == true)
            {
                return;
            }
            if (e.RowHeader == true)
            {
                return;
            }

            FarPoint.Win.Spread.SheetView with_1 = spdSheetData.Sheets[0];
            if (MPCF.Trim(with_1.Cells[e.Row, 0].Tag) == "")
            {
                return;
            }

            for (i = e.Row + 1; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, 0].Tag) != "")
                {
                    break;
                }

                if (MPCF.ToInt(with_1.Cells[e.Row, 0].Tag) == (int)CELL_STATUS.MINUS)
                {
                    with_1.Rows[i].Visible = false;
                }
                else
                {
                    with_1.Rows[i].Visible = true;
                }
            }

            if (MPCF.ToInt(with_1.Cells[e.Row, 0].Tag) == (int)CELL_STATUS.MINUS)
            {
                with_1.Cells[e.Row, 0].CellType = plusCellType;
                with_1.Cells[e.Row, 0].Tag = CELL_STATUS.PLUS;
            }
            else if (MPCF.ToInt(with_1.Cells[e.Row, 0].Tag) == (int)CELL_STATUS.PLUS)
            {
                with_1.Cells[e.Row, 0].CellType = minusCellType;
                with_1.Cells[e.Row, 0].Tag = CELL_STATUS.MINUS;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lisSheetData.Items.Count == 0)
                    return;

                string sCond;

                sCond = "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
                sCond += "\r\n" + "Sheet Name : " + lisSheetData.SelectedItems[0].Text;
                sCond += "\r\n" + "Data Type : " + lisSheetData.SelectedItems[0].SubItems[1].Text;

                if (lisSheetData.Columns.Count >= 3)
                    sCond += "\r\n" + lisSheetData.Columns[2].Text + ":" + lisSheetData.SelectedItems[0].SubItems[2].Text;
                if (lisSheetData.Columns.Count >= 4)
                    sCond += "\r\n" + lisSheetData.Columns[3].Text + ":" + lisSheetData.SelectedItems[0].SubItems[3].Text;
                if (lisSheetData.Columns.Count >= 5)
                    sCond += "\r\n" + lisSheetData.Columns[4].Text + ":" + lisSheetData.SelectedItems[0].SubItems[4].Text;
                if (lisSheetData.Columns.Count >= 6)
                    sCond += "\r\n" + lisSheetData.Columns[5].Text + ":" + lisSheetData.SelectedItems[0].SubItems[5].Text;
                if (lisSheetData.Columns.Count >= 7)
                    sCond += "\r\n" + lisSheetData.Columns[6].Text + ":" + lisSheetData.SelectedItems[0].SubItems[6].Text;
                if (lisSheetData.Columns.Count >= 8)
                    sCond += "\r\n" + lisSheetData.Columns[7].Text + ":" + lisSheetData.SelectedItems[0].SubItems[7].Text;
                if (lisSheetData.Columns.Count >= 9)
                    sCond += "\r\n" + lisSheetData.Columns[8].Text + ":" + lisSheetData.SelectedItems[0].SubItems[8].Text;
                if (lisSheetData.Columns.Count >= 10)
                    sCond += "\r\n" + lisSheetData.Columns[9].Text + ":" + lisSheetData.SelectedItems[0].SubItems[9].Text;
                if (lisSheetData.Columns.Count >= 11)
                    sCond += "\r\n" + lisSheetData.Columns[10].Text + ":" + lisSheetData.SelectedItems[0].SubItems[10].Text;
                if (lisSheetData.Columns.Count >= 12)
                    sCond += "\r\n" + lisSheetData.Columns[11].Text + ":" + lisSheetData.SelectedItems[0].SubItems[11].Text;

                if (MPCF.ExportToExcel(spdSheetData, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }

                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdSheetData.Sheets[0].RowCount < 1)
                {
                    return;
                }
                if (spdSheetData.Sheets[0].ActiveCell.Column.Index < 1)
                {
                    return;
                }
                if (spdSheetData.Sheets[0].ActiveCell.Row.Index < 0)
                {
                    return;
                }

                if (MPCF.Trim(spdSheetData.Sheets[0].Cells[spdSheetData.Sheets[0].ActiveCell.Row.Index, 1].Text) == "")
                {
                    return;
                }

                string key_1 = null;
                string key_2 = null;
                string key_3 = null;
                string key_4 = null;
                string key_5 = null;
                string key_6 = null;
                string key_7 = null;
                string key_8 = null;
                string key_9 = null;
                string key_10 = null;

                if (lisSheetData.Columns.Count >= 3)
                    key_1 = lisSheetData.SelectedItems[0].SubItems[2].Text;
                if (lisSheetData.Columns.Count >= 4)
                    key_2 = lisSheetData.SelectedItems[0].SubItems[3].Text;
                if (lisSheetData.Columns.Count >= 5)
                    key_3 = lisSheetData.SelectedItems[0].SubItems[4].Text;
                if (lisSheetData.Columns.Count >= 6)
                    key_4 = lisSheetData.SelectedItems[0].SubItems[5].Text;
                if (lisSheetData.Columns.Count >= 7)
                    key_5 = lisSheetData.SelectedItems[0].SubItems[6].Text;
                if (lisSheetData.Columns.Count >= 8)
                    key_6 = lisSheetData.SelectedItems[0].SubItems[7].Text;
                if (lisSheetData.Columns.Count >= 9)
                    key_7 = lisSheetData.SelectedItems[0].SubItems[8].Text;
                if (lisSheetData.Columns.Count >= 10)
                    key_8 = lisSheetData.SelectedItems[0].SubItems[9].Text;
                if (lisSheetData.Columns.Count >= 11)
                    key_9 = lisSheetData.SelectedItems[0].SubItems[10].Text;
                if (lisSheetData.Columns.Count >= 12)
                    key_10 = lisSheetData.SelectedItems[0].SubItems[11].Text;

                frmRASTranMakeCheckResult frmMakeCheck = null;

                try
                {
                    frmMakeCheck = (frmRASTranMakeCheckResult)MPCF.GetChildForm(MPGV.gfrmMDI, "frmRASTranMakeCheckList");
                    if (frmMakeCheck == null)
                    {
                        frmMakeCheck = new frmRASTranMakeCheckResult();
                        frmMakeCheck.MdiParent = MPGV.gfrmMDI;
                    }

                    frmMakeCheck.SetDataSheet(lisSheetData.SelectedItems[0].Text, lisSheetData.SelectedItems[0].SubItems[1].Text,
                                                     key_1, key_2, key_3, key_4, key_5,
                                                     key_6, key_7, key_8, key_9, key_10,
                                                     MPCF.Trim(spdSheetData.Sheets[0].Cells[spdSheetData.Sheets[0].ActiveCell.Row.Index, 1].Text), true, true);

                    frmMakeCheck.BringToFront();
                    frmMakeCheck.Show();
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
    }
}

