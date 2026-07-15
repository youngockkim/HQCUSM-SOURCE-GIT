
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupLotExtensionTable.cs
//   Description : Lot Extension Definition
//
//   MES Version : 5.2.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition() : Check the conditions before transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2012-04-21 : Created by Kelly
//
//
//   Copyright(C) 1998-2012 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Text;

using FarPoint.Win.Spread;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPSetupLotExtensionTable : Miracom.MESCore.SetupForm01
    {
        public frmWIPSetupLotExtensionTable()
        {
            InitializeComponent();
        }
 
        #region " Constant Definition "

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        private const int CHECK_COL = 0;
        private const int KEY_1_COL = 1;
        private const int KEY_1_BTN = 2;
        private const int KEY_2_COL = 3;
        private const int KEY_2_BTN = 4;
        private const int KEY_3_COL = 5;
        private const int KEY_3_BTN = 6;
        private const int KEY_4_COL = 7;
        private const int KEY_4_BTN = 8;
        private const int KEY_5_COL = 9;
        private const int KEY_5_BTN = 10;
        private const int KEY_6_COL = 11;
        private const int KEY_6_BTN = 12;
        private const int KEY_7_COL = 13;
        private const int KEY_7_BTN = 14;
        private const int KEY_8_COL = 15;
        private const int KEY_8_BTN = 16;
        private const int KEY_9_COL = 17;
        private const int KEY_9_BTN = 18;
        private const int KEY_10_COL = 19;
        private const int KEY_10_BTN = 20;
        private const int DATA_1_COL = 21;
        private const int DATA_1_BTN = 22;
        private const int DATA_2_COL = 23;
        private const int DATA_2_BTN = 24;
        private const int DATA_3_COL = 25;
        private const int DATA_3_BTN = 26;
        private const int DATA_4_COL = 27;
        private const int DATA_4_BTN = 28;
        private const int DATA_5_COL = 29;
        private const int DATA_5_BTN = 30;
        private const int DATA_6_COL = 31;
        private const int DATA_6_BTN = 32;
        private const int DATA_7_COL = 33;
        private const int DATA_7_BTN = 34;
        private const int DATA_8_COL = 35;
        private const int DATA_8_BTN = 36;
        private const int DATA_9_COL = 37;
        private const int DATA_9_BTN = 38;
        private const int DATA_10_COL = 39;
        private const int DATA_10_BTN = 40;
        /*** End of Modification (2012.04.04) ***/

        private const int MAX_DATA_COUNT = 1000;
        private const string LOT_EXTENSION_TABLE = "LOT_EXTENSION";
        #endregion
        
        #region " Variable Definition "

        private struct Format
        {
            public string Col_Fmt;
            public int Col_Size;
        };

        private Format[] FormatTbl = new Format[41];
        private bool b_load_flag;
        private int i_last_filtered_column;
        private string s_last_filtered_string;
        private float[] d_prev_col_size = null;
         
        #endregion
        
        #region " Function Definition "

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            int i = 0;
            int k = 0;
            int i_chk_count = 0;

            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Update_Data_List":

                        for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                        {
                            if (spdData.ActiveSheet.Cells[i, CHECK_COL].Value != null && Convert.ToBoolean(spdData.ActiveSheet.Cells[i, CHECK_COL].Value) == true)
                            {
                                i_chk_count++;

                                if (MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_1_COL].Value) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdData.ActiveSheet.SetActiveCell(i, KEY_1_COL);
                                    spdData.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                                    spdData.Focus();
                                    return false;
                                }

                                // Seq는 3이상이어야한다
                                if (MPCF.ToInt(spdData.ActiveSheet.Cells[i, KEY_1_COL].Value) < 3)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(359));
                                    spdData.ActiveSheet.SetActiveCell(i, KEY_1_COL);
                                    spdData.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                                    spdData.Focus();
                                    return false;
                                }

                                for (k = 0; k < spdData.ActiveSheet.RowCount; k++)
                                {
                                    if (i == k || MPCF.Trim(spdData.ActiveSheet.Cells[k, KEY_1_COL].Value) == "")
                                    {
                                        continue;
                                    }

                                    if (MPCF.ToInt(spdData.ActiveSheet.Cells[i, KEY_1_COL].Value) == MPCF.ToInt(spdData.ActiveSheet.Cells[k, KEY_1_COL].Value))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(111) + "\n" + MPCF.FindLanguage("Conflict SEQ = [", CAPTION_TYPE.LABEL) + (k + 1) + "]");
                                        spdData.ActiveSheet.SetActiveCell(i, KEY_1_COL);
                                        spdData.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                                        spdData.Focus();
                                        return false;
                                    }
                                    if (MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_2_COL].Value) == MPCF.Trim(spdData.ActiveSheet.Cells[k, KEY_2_COL].Value))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(111) + "\n" + MPCF.FindLanguage("Conflict SEQ = [", CAPTION_TYPE.LABEL) + (k + 1) + "]");
                                        spdData.ActiveSheet.SetActiveCell(i, KEY_2_COL);
                                        spdData.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                                        spdData.Focus();
                                        return false;
                                    }
                                }
                            }
                        }

                        if (i_chk_count < 1)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(133));
                            spdData.Focus();
                            return false;
                        }
                        else if (i_chk_count > MAX_DATA_COUNT)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(134));
                            spdData.Focus();
                            return false;
                        }

                        switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                        {
                            case MPGC.MP_STEP_UPDATE:

                                break;

                            case MPGC.MP_STEP_DELETE:

                                break;
                        }
                        break;
                    case "VIEW_TABLE":

                        break;

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
        // ClearData()
        //       - Clear control
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private void ClearData(char ProcStep)
        {
            switch (ProcStep)
            {
                case '1':
                    d_prev_col_size = null;
                    MPCF.ClearList(spdData);
                    spdData.ActiveSheet.ColumnCount = 0;
                    txtQuery.Text = "";
                    break;

                case '2':
                    if (d_prev_col_size == null)
                    {
                        d_prev_col_size = new float[40];
                        for (int i = 0; i < 40; i++)
                        {
                            d_prev_col_size[i] = spdData.ActiveSheet.ColumnHeader.Columns[i + 1].Width;
                        }
                    }

                    MPCF.ClearList(spdData);
                    spdData.ActiveSheet.ColumnCount = 0;
                    break;

                default:

                    break;
            }
        }

        private bool ViewDataList()
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            DataTable dt = null;
            ArrayList a_list = new ArrayList();

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.Factory = MPGV.gsCentralFactory;
                in_node.AddString("TABLE_NAME", LOT_EXTENSION_TABLE);

                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    dt = FillDataTable(dt, out_node);
                }
                spdData.DataSource = dt;
                MakeColumnHeader();

                spdData.ActiveSheet.Rows[0].Locked = true;
                spdData.ActiveSheet.Rows[1].Locked = true;
                spdData.ActiveSheet.Rows[0].BackColor = Color.LightGray;
                spdData.ActiveSheet.Rows[1].BackColor = Color.LightGray;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }

        private DataTable FillDataTable(DataTable dt, TRSNode out_node)
        {
            int c;
            int r;
            DataColumn dc;
            DataRow dr;

            if (dt == null)
            {
                if (out_node.GetList(0).Count < 1) return null;

                dt = new DataTable("DataTable");

                for (c = 0; c < 40; c++)
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dc.DefaultValue = "";

                    dt.Columns.Add(dc);
                }
            }

            for (r = 0; r < out_node.GetList(0).Count; r++)
            {
                dr = dt.NewRow();

                dr[0] = out_node.GetList(0)[r].GetString("KEY_1");
                dr[1] = "";
                dr[2] = out_node.GetList(0)[r].GetString("KEY_2");
                dr[3] = "";
                dr[4] = out_node.GetList(0)[r].GetString("KEY_3");
                dr[5] = "";
                dr[6] = out_node.GetList(0)[r].GetString("KEY_4");
                dr[7] = "";
                dr[8] = out_node.GetList(0)[r].GetString("KEY_5");
                dr[9] = "";
                dr[10] = out_node.GetList(0)[r].GetString("KEY_6");
                dr[11] = "";
                dr[12] = out_node.GetList(0)[r].GetString("KEY_7");
                dr[13] = "";
                dr[14] = out_node.GetList(0)[r].GetString("KEY_8");
                dr[15] = "";
                dr[16] = out_node.GetList(0)[r].GetString("KEY_9");
                dr[17] = "";
                dr[18] = out_node.GetList(0)[r].GetString("KEY_10");
                dr[19] = "";
                dr[20] = out_node.GetList(0)[r].GetString("DATA_1");
                dr[21] = "";
                dr[22] = out_node.GetList(0)[r].GetString("DATA_2");
                dr[23] = "";
                dr[24] = out_node.GetList(0)[r].GetString("DATA_3");
                dr[25] = "";
                dr[26] = out_node.GetList(0)[r].GetString("DATA_4");
                dr[27] = "";
                dr[28] = out_node.GetList(0)[r].GetString("DATA_5");
                dr[29] = "";
                dr[30] = out_node.GetList(0)[r].GetString("DATA_6");
                dr[31] = "";
                dr[32] = out_node.GetList(0)[r].GetString("DATA_7");
                dr[33] = "";
                dr[34] = out_node.GetList(0)[r].GetString("DATA_8");
                dr[35] = "";
                dr[36] = out_node.GetList(0)[r].GetString("DATA_9");
                dr[37] = "";
                dr[38] = out_node.GetList(0)[r].GetString("DATA_10");
                dr[39] = "";

                dt.Rows.Add(dr);
            }

            return dt;
        }

        private bool MakeColumnHeader()
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");
            TRSNode out_node = new TRSNode("VIEW_TABLE_OUT");

            FarPoint.Win.Spread.CellType.TextCellType text_type;
            FarPoint.Win.Spread.CellType.ComboBoxCellType combobox_type;
            int i;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.Factory = MPGV.gsCentralFactory;
                in_node.AddString("TABLE_NAME", LOT_EXTENSION_TABLE);

                if (MPCR.CallService("BAS", "BAS_View_Table", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (spdData.ActiveSheet.Columns.Count > 0)
                {
                    spdData.ActiveSheet.Columns.Add(0, 1);
                }
                else
                {
                    spdData.ActiveSheet.ColumnCount = 41;
                }

                for (i = 1; i <= 40; i++)
                {
                    spdData.ActiveSheet.ColumnHeader.Columns[i].Width = 0;
                    spdData.ActiveSheet.ColumnHeader.Columns[i].Resizable = false;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, i].Value = "";

                    FormatTbl[i].Col_Fmt = "";
                    FormatTbl[i].Col_Size = 0;
                }

                spdData.ActiveSheet.ColumnHeader.Cells[0, 0].Value = "Sel";
                spdData.ActiveSheet.Columns.Get(0).CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                spdData.ActiveSheet.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                spdData.ActiveSheet.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdData.ActiveSheet.Columns.Get(0).Width = 25;

                //Column Name : KEY_1_COL
                text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                text_type.MaxLength = 3;
                spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].CellType = text_type;
                spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].Value = " " + out_node.GetString("KEY_1_PRT") + " ";
                spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Width = 120;
                spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Visible = true;
                spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Resizable = true;
                spdData.ActiveSheet.Columns[KEY_1_COL].Locked = true;
                spdData.ActiveSheet.Columns[KEY_1_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                spdData.ActiveSheet.Columns[KEY_1_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdData.ActiveSheet.Columns[KEY_1_COL].CellType = text_type;
                FormatTbl[KEY_1_COL].Col_Fmt = out_node.GetChar("KEY_1_FMT").ToString();
                FormatTbl[KEY_1_COL].Col_Size = out_node.GetInt("KEY_1_SIZE");
                spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].Tag = "KEY";

                //Column Name : KEY_2_COL
                text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                text_type.MaxLength = 50;
                text_type.CharacterCasing = CharacterCasing.Upper;
                spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].CellType = text_type;
                spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].Value = " " + out_node.GetString("KEY_2_PRT") + " ";
                spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Width = 150;
                spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Visible = true;
                spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Resizable = true;
                spdData.ActiveSheet.Columns[KEY_2_COL].Locked = true;
                spdData.ActiveSheet.Columns[KEY_2_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                spdData.ActiveSheet.Columns[KEY_2_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdData.ActiveSheet.Columns[KEY_2_COL].CellType = text_type;
                FormatTbl[KEY_2_COL].Col_Fmt = out_node.GetChar("KEY_2_FMT").ToString();
                FormatTbl[KEY_2_COL].Col_Size = out_node.GetInt("KEY_2_SIZE");
                spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].Tag = "KEY";

                //Column Description : DATA_1_COL
                text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                text_type.MaxLength = 1000;
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].CellType = text_type;
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Value = " " + out_node.GetString("DATA_1_PRT") + " ";
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Width = 200;
                spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Visible = true;
                spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Resizable = true;
                spdData.ActiveSheet.Columns[DATA_1_COL].Locked = false;
                spdData.ActiveSheet.Columns[DATA_1_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                spdData.ActiveSheet.Columns[DATA_1_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdData.ActiveSheet.Columns[DATA_1_COL].CellType = text_type;
                FormatTbl[DATA_1_COL].Col_Fmt = out_node.GetChar("DATA_1_FMT").ToString();
                FormatTbl[DATA_1_COL].Col_Size = out_node.GetInt("DATA_1_SIZE");
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Tag = "DATA";

                //Data Type : DATA_2_COL
                text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                combobox_type = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                text_type.MaxLength = 1000;
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].CellType = text_type;
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].Value = " " + out_node.GetString("DATA_2_PRT") + " ";
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Width = 100;
                spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Visible = true;
                spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Resizable = true;
                spdData.ActiveSheet.Columns[DATA_2_COL].Locked = false;
                spdData.ActiveSheet.Columns[DATA_2_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                spdData.ActiveSheet.Columns[DATA_2_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdData.ActiveSheet.Columns[DATA_2_COL].CellType = combobox_type;
                combobox_type.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
                combobox_type.Items = new string[] { "CHAR", "VARCHAR2", "NUMBER" };
                FormatTbl[DATA_2_COL].Col_Fmt = out_node.GetChar("DATA_2_FMT").ToString();
                FormatTbl[DATA_2_COL].Col_Size = out_node.GetInt("DATA_2_SIZE");
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Tag = "DATA";

                //Data Size : DATA_3_COL
                text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                text_type.MaxLength = 1000;
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].CellType = text_type;
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].Value = "SIZE";
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Width = 50;
                spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Visible = true;
                spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Resizable = true;
                spdData.ActiveSheet.Columns[DATA_3_COL].Locked = false;
                spdData.ActiveSheet.Columns[DATA_3_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdData.ActiveSheet.Columns[DATA_3_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdData.ActiveSheet.Columns[DATA_3_COL].CellType = text_type;
                FormatTbl[DATA_3_COL].Col_Fmt = out_node.GetChar("DATA_3_FMT").ToString();
                FormatTbl[DATA_3_COL].Col_Size = out_node.GetInt("DATA_3_SIZE");
                spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Tag = "DATA";

                spdData.ActiveSheet.ColumnHeader.Rows[0].Height = spdData.ActiveSheet.ColumnHeader.Rows[0].GetPreferredHeight();
                spdData.ActiveSheet.SetColumnAllowAutoSort(1, 40, true);
                spdData.ActiveSheet.SetColumnAllowFilter(1, 40, true);

                spdData.ActiveSheet.RowCount++;
                spdData.ActiveSheet.Rows[spdData.ActiveSheet.RowCount - 1].Tag = "NEW";

                for (i = 1; i <= 40; i++)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == "KEY")
                    {
                        spdData.ActiveSheet.Columns[i].BackColor = System.Drawing.Color.Lavender;
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                    }
                    else if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == "DATA")
                    {
                        spdData.ActiveSheet.Columns[i].BackColor = System.Drawing.Color.White;
                    }

                    if (d_prev_col_size != null && d_prev_col_size[i - 1] > 0)
                    {
                        spdData.ActiveSheet.Columns[i].Width = d_prev_col_size[i - 1];
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool UpdateDataList(char ProcStep)
        {
            int i = 0;
            TRSNode in_node = new TRSNode("UPDATE_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.Factory = MPGV.gsCentralFactory;
                in_node.AddString("TABLE_NAME", LOT_EXTENSION_TABLE);

                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (spdData.ActiveSheet.Cells[i, 0].Value == null) continue;
                    if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == false) continue;

                    node = in_node.AddNode("DATA_LIST");

                    node.AddString("KEY_1", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_1_COL].Value));
                    node.AddString("KEY_2", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_2_COL].Value));
                    node.AddString("DATA_1", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_1_COL].Value));
                    node.AddString("DATA_2", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_2_COL].Value));
                    node.AddString("DATA_3", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_3_COL].Value));
                }

                if (MPCR.CallService("BAS", "BAS_Update_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        private bool RunQuery()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            TRSNode sql_node;

            string[] s_sqls = null;
            string s_sql;

            try
            {
                if (MPCF.Trim(txtQuery.Text) == "") return false;

                s_sqls = txtQuery.Text.Split(new Char[] { '\r', '\n' });
                if (s_sqls.Length < 1) return false;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.Factory = MPGV.gsCentralFactory;

                for (int i = 0; i < s_sqls.Length; i++)
                {
                    s_sql = MPCF.Trim(s_sqls[i]);
                    if (s_sql != "" && s_sql.Substring(0, 1) != "/")
                    {
                        if (s_sql.EndsWith(";") == true)
                        {
                            s_sql = s_sql.Substring(0, s_sql.Length - 1);
                        }

                        sql_node = in_node.AddNode("QUERY");
                        sql_node.AddString("SQL", "$_" + s_sql);
                    }
                }
                if (in_node.GetList("QUERY").Count < 1) return false;

                if (MPCR.CallService("BAS", "BAS_SQL_Multi_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool UpdateExtensionColumn()
        {
            int i_active_row = 0;

            try
            {
                if (CheckCondition("Update_Data_List", '1') == false) return false;

                if (GenAddScript() == false) return false;
                if (chkOnlyDefinition.Checked == false)
                {
                    if (RunQuery() == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(363));
                        return false;
                    }
                }
                if (UpdateDataList(MPGC.MP_STEP_UPDATE) == false) return false;

                i_active_row = spdData.ActiveSheet.ActiveRowIndex;

                ClearData('2');
                ViewDataList();

                //Modify by J.S. 2012.02.14 refresh
                spdData.ActiveSheet.ActiveColumnIndex = 0;
                spdData.ActiveSheet.ActiveRowIndex = i_active_row;
                spdData.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool RemoveExtensionColumn()
        {
            try
            {
                if (CheckCondition("Update_Data_List", '2') == false) return false;

                if (GenDropScript() == false) return false;
                if (chkOnlyDefinition.Checked == false)
                {
                    if (RunQuery() == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(363));
                        return false;
                    }
                }
                if (UpdateDataList(MPGC.MP_STEP_DELETE) == false) return false;

                ClearData('2');
                ViewDataList();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool GenAddScript()
        {
            int iRow = 0;
            StringBuilder sb_script;

            try
            {
                while (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, 1].Value) != "")
                {
                    iRow++;
                }

                txtQuery.Text = "";
                if (iRow < 1) return false;

                sb_script = new StringBuilder();
                sb_script.Append("/* Alter Lot Extension Status */\r\n");

                for (int i = 0; i < iRow; i++)
                {
                    if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == true)
                    {
                        if (MPCF.Trim(spdData.ActiveSheet.Rows[i].Tag) == "NEW")
                        {
                            sb_script.Append("ALTER TABLE MWIPELTSTS ADD " + MPCF.Trim(spdData.ActiveSheet.Cells[i, 3].Value));
                        }
                        else
                        {
                            sb_script.Append("ALTER TABLE MWIPELTSTS MODIFY " + MPCF.Trim(spdData.ActiveSheet.Cells[i, 3].Value));
                        }

                        sb_script.Append(" " + MPCF.Trim(spdData.ActiveSheet.Cells[i, 23].Value) + "(" + MPCF.Trim(spdData.ActiveSheet.Cells[i, 25].Value));

                        if (MPCF.Trim(spdData.ActiveSheet.Rows[i].Tag) == "NEW")
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.Cells[i, 23].Value) == "NUMBER")
                            {
                                sb_script.Append(") DEFAULT(0) NOT NULL;\r\n");
                            }
                            else
                            {
                                sb_script.Append(") DEFAULT(' ') NOT NULL;\r\n");
                            }
                        }
                        else
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.Cells[i, 23].Value) == "NUMBER")
                            {
                                sb_script.Append(") DEFAULT(0);\r\n");
                            }
                            else
                            {
                                sb_script.Append(") DEFAULT(' ');\r\n");
                            }
                        }
                    }
                }

                sb_script.Append("\r\n");
                sb_script.Append("/* Alter Lot Extension History */\r\n");

                for (int i = 0; i < iRow; i++)
                {
                    if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == true)
                    {
                        if (MPCF.Trim(spdData.ActiveSheet.Rows[i].Tag) == "NEW")
                        {
                            sb_script.Append("ALTER TABLE MWIPELTHIS ADD " + MPCF.Trim(spdData.ActiveSheet.Cells[i, 3].Value));
                        }
                        else
                        {
                            sb_script.Append("ALTER TABLE MWIPELTHIS MODIFY " + MPCF.Trim(spdData.ActiveSheet.Cells[i, 3].Value));
                        }

                        sb_script.Append(" " + MPCF.Trim(spdData.ActiveSheet.Cells[i, 23].Value) + "(" + MPCF.Trim(spdData.ActiveSheet.Cells[i, 25].Value));
                        if (MPCF.Trim(spdData.ActiveSheet.Rows[i].Tag) == "NEW")
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.Cells[i, 23].Value) == "NUMBER")
                            {
                                sb_script.Append(") DEFAULT(0) NOT NULL;\r\n");
                            }
                            else
                            {
                                sb_script.Append(") DEFAULT(' ') NOT NULL;\r\n");
                            }
                        }
                        else
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.Cells[i, 23].Value) == "NUMBER")
                            {
                                sb_script.Append(") DEFAULT(0);\r\n");
                            }
                            else
                            {
                                sb_script.Append(") DEFAULT(' ');\r\n");
                            }
                        }
                    }
                }

                sb_script.Append("\r\n");
                sb_script.Append("/* Add Comment */\r\n");

                for (int i = 0; i < iRow; i++)
                {
                    if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == true)
                    {
                        sb_script.Append("COMMENT ON COLUMN MWIPELTSTS." + spdData.ActiveSheet.Cells[i, 3].Value);
                        sb_script.Append(" IS \'" + spdData.ActiveSheet.Cells[i, 21].Value + "\';\r\n");
                        sb_script.Append("COMMENT ON COLUMN MWIPELTHIS." + spdData.ActiveSheet.Cells[i, 3].Value);
                        sb_script.Append(" IS \'" + spdData.ActiveSheet.Cells[i, 21].Value + "\';\r\n");
                    }
                }

                sb_script.Append("\r\n");
                sb_script.Append("/* Alter Lot Extension Temp History */\r\n");

                for (int i = 0; i < iRow; i++)
                {
                    if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == true)
                    {
                        if (MPCF.Trim(spdData.ActiveSheet.Rows[i].Tag) == "NEW")
                        {
                            sb_script.Append("ALTER TABLE MTMPELTHIS ADD " + MPCF.Trim(spdData.ActiveSheet.Cells[i, 3].Value));
                        }
                        else
                        {
                            sb_script.Append("ALTER TABLE MTMPELTHIS MODIFY " + MPCF.Trim(spdData.ActiveSheet.Cells[i, 3].Value));
                        }

                        sb_script.Append(" " + MPCF.Trim(spdData.ActiveSheet.Cells[i, 23].Value) + "(" + MPCF.Trim(spdData.ActiveSheet.Cells[i, 25].Value));
                        if (MPCF.Trim(spdData.ActiveSheet.Rows[i].Tag) == "NEW")
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.Cells[i, 23].Value) == "NUMBER")
                            {
                                sb_script.Append(") DEFAULT(0) NOT NULL;\r\n");
                            }
                            else
                            {
                                sb_script.Append(") DEFAULT(' ') NOT NULL;\r\n");
                            }
                        }
                        else
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.Cells[i, 23].Value) == "NUMBER")
                            {
                                sb_script.Append(") DEFAULT(0);\r\n");
                            }
                            else
                            {
                                sb_script.Append(") DEFAULT(' ');\r\n");
                            }
                        }
                    }
                }

                sb_script.Append("\r\n");
                sb_script.Append("/* Add Comment */\r\n");

                for (int i = 0; i < iRow; i++)
                {
                    if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == true)
                    {
                        sb_script.Append("COMMENT ON COLUMN MTMPELTHIS." + spdData.ActiveSheet.Cells[i, 3].Value);
                        sb_script.Append(" IS \'" + spdData.ActiveSheet.Cells[i, 21].Value + "\';\r\n");
                    }
                }

                txtQuery.Text = sb_script.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool GenDropScript()
        {
            int iRow = 0;
            StringBuilder sb_script;

            try
            {
                while (MPCF.Trim(spdData.ActiveSheet.Cells[iRow, 1].Value) != "")
                {
                    iRow++;
                }

                txtQuery.Text = "";
                if (iRow < 1) return false;

                sb_script = new StringBuilder();
                sb_script.Append("/* Alter Lot Extension Status */\r\n");

                for (int i = 0; i < iRow; i++)
                {
                    if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == true)
                    {
                        sb_script.Append("ALTER TABLE MWIPELTSTS DROP COLUMN " + spdData.ActiveSheet.Cells[i, 3].Value + ";\r\n");
                    }
                }

                sb_script.Append("\r\n");
                sb_script.Append("/* Alter Lot Extension History */\r\n");

                for (int i = 0; i < iRow; i++)
                {
                    if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == true)
                    {
                        sb_script.Append("ALTER TABLE MWIPELTHIS DROP COLUMN " + spdData.ActiveSheet.Cells[i, 3].Value + ";\r\n");
                    }
                }

                sb_script.Append("\r\n");
                sb_script.Append("/* Alter Lot Extension Temp History */\r\n");

                for (int i = 0; i < iRow; i++)
                {
                    if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == true)
                    {
                        sb_script.Append("ALTER TABLE MTMPELTHIS DROP COLUMN " + spdData.ActiveSheet.Cells[i, 3].Value + ";\r\n");
                    }
                }

                txtQuery.Text = sb_script.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        #endregion

        private void frmWIPSetupLotExtension_Activated(object sender, EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    i_last_filtered_column = -1;
                    s_last_filtered_string = null;

                    ClearData('1');
                    ViewDataList();

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_EditModeOff(object sender, EventArgs e)
        {
            string sValue;
            int i_col;
            int i_row;

            try
            {
                i_col = spdData.ActiveSheet.ActiveColumnIndex;
                i_row = spdData.ActiveSheet.ActiveRowIndex;

                if (i_col < 1) return;

                spdData.ActiveSheet.SetValue(i_row, 0, true);

                sValue = MPCF.Trim(spdData.ActiveSheet.Cells[i_row, i_col].Value);

                if (MPCF.ByteLen(sValue) > FormatTbl[i_col].Col_Size)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(153));
                    spdData.ActiveSheet.SetValue(i_row, i_col, "");
                    spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                    return;
                }

                switch (FormatTbl[i_col].Col_Fmt)
                {
                    case "F":

                        if (MPCF.CheckNumeric(sValue) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(139));
                            spdData.ActiveSheet.SetValue(i_row, i_col, "");
                            spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                            return;
                        }
                        break;

                    case "N":

                        if (MPCF.CheckNumeric(sValue) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(139));
                            spdData.ActiveSheet.SetValue(i_row, i_col, "");
                            spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                            return;
                        }
                        if (sValue.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) >= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(140));
                            spdData.ActiveSheet.SetValue(i_row, i_col, "");
                            spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                            return;
                        }
                        break;
                }

                //Add 1 Row
                if (i_row == spdData.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.Cells[i_row, KEY_2_COL].Value) != "")
                    {
                        spdData.ActiveSheet.RowCount++;
                        spdData.ActiveSheet.Rows[spdData.ActiveSheet.RowCount - 1].Tag = "NEW";

                        for (int i = 1; i <= 20; i++)
                        {
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_AutoFilteredColumn(object sender, AutoFilteredColumnEventArgs e)
        {
            int i;

            if (e.Column != i_last_filtered_column || e.FilterString != s_last_filtered_string)
            {
                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (spdData.ActiveSheet.RowFilter.IsRowFilteredOut(i) == true)
                    {
                        spdData.ActiveSheet.SetValue(i, 0, false);
                    }
                }

                i_last_filtered_column = e.Column;
                s_last_filtered_string = e.FilterString;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearData('1');
            ViewDataList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateExtensionColumn() == false) return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes) return;

            if (RemoveExtensionColumn() == false) return;
        }

        private void btnGenAdd_Click(object sender, EventArgs e)
        {
            if (GenAddScript() == false) return;
        }

        private void btnGenDrop_Click(object sender, EventArgs e)
        {
            if (GenDropScript() == false) return;
        }

    
    }
    
}
