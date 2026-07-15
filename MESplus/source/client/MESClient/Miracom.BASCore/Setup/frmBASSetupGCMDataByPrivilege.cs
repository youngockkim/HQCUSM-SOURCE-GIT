using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using System.Globalization;
using System.Text;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;

namespace Miracom.BASCore
{
    public partial class frmBASSetupGCMDataByPrivilege : SetupForm02
    {
        public frmBASSetupGCMDataByPrivilege()
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

        private const string COLUMN_DATA = "DATA";
        private const string COLUMN_KEY = "KEY";
        /*** End of Modification (2012.04.04) ***/

        private const int MAX_DATA_COUNT = 1000;

        private const string GCM_TBL_DAT = "MGCMTBLDAT";
        private const string GCM_TBL_LAG = "MGCMLAGDAT";

        #endregion 

        #region " Variable Definition "

        private struct Format
        {
            public string Col_Fmt;
            public int Col_Size;
        };

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        private Format[] FormatTbl = new Format[41];

        private bool b_load_flag;
        private int i_last_filtered_column;
        private string s_last_filtered_string;

        private float[] d_prev_col_size = new float[40];

        private int i_last_selected_idx;
        private int i_last_selected_desc_idx;
        /*** End of Modification (2012.04.04) ***/
        private bool b_reload_data_flag;
        private TRSNode TABLE;
        
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
            int j = 0;
            int iChkCnt = 0;

            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Update_Data_List":


                        for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                        {
                            if (spdData.ActiveSheet.Cells[i, CHECK_COL].Value != null)
                            {
                                if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, CHECK_COL].Value) == true)
                                {

                                    iChkCnt++;

                                    if (MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_1_COL].Value) == "")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                        spdData.ActiveSheet.SetActiveCell(i, KEY_1_COL);
                                        spdData.Select();
                                        return false;
                                    }

                                    for (j = i + 1; j < spdData.ActiveSheet.RowCount; j++)
                                    {
                                        if (spdData.ActiveSheet.Cells[j, CHECK_COL].Value != null)
                                        {
                                            if (Convert.ToBoolean(spdData.ActiveSheet.Cells[j, CHECK_COL].Value) == true)
                                            {
                                                if (spdData.ActiveSheet.Cells[i, KEY_1_COL].Value == spdData.ActiveSheet.Cells[j, KEY_1_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_2_COL].Value == spdData.ActiveSheet.Cells[j, KEY_2_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_3_COL].Value == spdData.ActiveSheet.Cells[j, KEY_3_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_4_COL].Value == spdData.ActiveSheet.Cells[j, KEY_4_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_5_COL].Value == spdData.ActiveSheet.Cells[j, KEY_5_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_6_COL].Value == spdData.ActiveSheet.Cells[j, KEY_6_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_7_COL].Value == spdData.ActiveSheet.Cells[j, KEY_7_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_8_COL].Value == spdData.ActiveSheet.Cells[j, KEY_8_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_9_COL].Value == spdData.ActiveSheet.Cells[j, KEY_9_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_10_COL].Value == spdData.ActiveSheet.Cells[j, KEY_10_COL].Value)
                                                {
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(111));
                                                    spdData.ActiveSheet.SetActiveCell(i, KEY_1_COL);
                                                    spdData.Select();
                                                    return false;
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }

                        if (iChkCnt == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(133));
                            spdData.Select();
                            return false;
                        }
                        else if (iChkCnt > MAX_DATA_COUNT)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(134));
                            spdData.Select();
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
        // Make_Column_Header()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool MakeColumnHeader()
        {
            FarPoint.Win.Spread.CellType.TextCellType text_type;
            /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
            FarPoint.Win.Spread.CellType.ButtonCellType button_type;
            /*** End of Add (2012.04.04) ***/
            int i;

            try
            {
                if (TABLE.GetString("TABLE_PASSWORD") == "")
                {
                    txtPwd.Enabled = false;
                }
                else
                {
                    txtPwd.Enabled = true;
                }

                /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
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
                    //spdData.ActiveSheet.ColumnHeader.Columns[i].Visible = false;
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
                spdData.ActiveSheet.Columns.Get(0).Width = 30;


                if (TABLE.GetString("KEY_1_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 100;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].Value = " " + TABLE.GetString("KEY_1_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Visible = true;

                    spdData.ActiveSheet.Columns[KEY_1_COL].Locked = true;
                    spdData.ActiveSheet.Columns[KEY_1_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[KEY_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[KEY_1_COL].CellType = text_type;

                    FormatTbl[KEY_1_COL].Col_Fmt = TABLE.GetChar("KEY_1_FMT").ToString();
                    FormatTbl[KEY_1_COL].Col_Size = TABLE.GetInt("KEY_1_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].Tag = COLUMN_KEY;
                    if (TABLE.GetString("KEY_1_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[KEY_1_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[KEY_1_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_1_TBL"), TABLE.GetString("KEY_1_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].ColumnSpan = 2;
                        spdData.ActiveSheet.Columns[KEY_1_BTN].Locked = true;
                    }
                }

                if (TABLE.GetString("KEY_2_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 100;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].Value = " " + TABLE.GetString("KEY_2_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Visible = true;

                    spdData.ActiveSheet.Columns[KEY_2_COL].Locked = true;
                    spdData.ActiveSheet.Columns[KEY_2_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[KEY_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[KEY_2_COL].CellType = text_type;

                    FormatTbl[KEY_2_COL].Col_Fmt = TABLE.GetChar("KEY_2_FMT").ToString();
                    FormatTbl[KEY_2_COL].Col_Size = TABLE.GetInt("KEY_2_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].Tag = COLUMN_KEY;
                    if (TABLE.GetString("KEY_2_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[KEY_2_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[KEY_2_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_2_TBL"), TABLE.GetString("KEY_2_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].ColumnSpan = 2;
                        spdData.ActiveSheet.Columns[KEY_2_BTN].Locked = true;
                    }
                }

                if (TABLE.GetChar("TABLE_TYPE") == 'E' || TABLE.GetChar("TABLE_TYPE") == 'L')
                {
                    if (TABLE.GetString("KEY_3_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].Value = " " + TABLE.GetString("KEY_3_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_3_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_3_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_3_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_3_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_3_COL].CellType = text_type;

                        FormatTbl[KEY_3_COL].Col_Fmt = TABLE.GetChar("KEY_3_FMT").ToString();
                        FormatTbl[KEY_3_COL].Col_Size = TABLE.GetInt("KEY_3_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_3_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_3_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_3_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_3_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_3_TBL"), TABLE.GetString("KEY_3_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_3_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_4_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].Value = " " + TABLE.GetString("KEY_4_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_4_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_4_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_4_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_4_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_4_COL].CellType = text_type;

                        /* 2013.06.12. Aiden. KEY_4_FMT 를 String => Char 로 변경 */
                        FormatTbl[KEY_4_COL].Col_Fmt = TABLE.GetChar("KEY_4_FMT").ToString();
                        FormatTbl[KEY_4_COL].Col_Size = TABLE.GetInt("KEY_4_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_4_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_4_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_4_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_4_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_4_TBL"), TABLE.GetString("KEY_4_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_4_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_5_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].Value = " " + TABLE.GetString("KEY_5_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_5_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_5_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_5_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_5_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_5_COL].CellType = text_type;

                        FormatTbl[KEY_5_COL].Col_Fmt = TABLE.GetChar("KEY_5_FMT").ToString();
                        FormatTbl[KEY_5_COL].Col_Size = TABLE.GetInt("KEY_5_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_5_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_5_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_5_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_5_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_5_TBL"), TABLE.GetString("KEY_5_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_5_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_6_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].Value = " " + TABLE.GetString("KEY_6_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_6_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_6_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_6_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_6_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_6_COL].CellType = text_type;

                        FormatTbl[KEY_6_COL].Col_Fmt = TABLE.GetChar("KEY_6_FMT").ToString();
                        FormatTbl[KEY_6_COL].Col_Size = TABLE.GetInt("KEY_6_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_6_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_6_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_6_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_6_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_6_TBL"), TABLE.GetString("KEY_6_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_6_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_7_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].Value = " " + TABLE.GetString("KEY_7_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_7_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_7_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_7_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_7_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_7_COL].CellType = text_type;

                        FormatTbl[KEY_7_COL].Col_Fmt = TABLE.GetChar("KEY_7_FMT").ToString();
                        FormatTbl[KEY_7_COL].Col_Size = TABLE.GetInt("KEY_7_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_7_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_7_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_7_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_7_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_7_TBL"), TABLE.GetString("KEY_7_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_7_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_8_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].Value = " " + TABLE.GetString("KEY_8_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_8_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_8_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_8_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_8_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_8_COL].CellType = text_type;

                        FormatTbl[KEY_8_COL].Col_Fmt = TABLE.GetChar("KEY_8_FMT").ToString();
                        FormatTbl[KEY_8_COL].Col_Size = TABLE.GetInt("KEY_8_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_8_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_8_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_8_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_8_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_8_TBL"), TABLE.GetString("KEY_8_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_8_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_9_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].Value = " " + TABLE.GetString("KEY_9_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_9_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_9_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_9_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_9_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_9_COL].CellType = text_type;

                        FormatTbl[KEY_9_COL].Col_Fmt = TABLE.GetChar("KEY_9_FMT").ToString();
                        FormatTbl[KEY_9_COL].Col_Size = TABLE.GetInt("KEY_9_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_9_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_9_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_9_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_9_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_9_TBL"), TABLE.GetString("KEY_9_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_9_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_10_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].Value = " " + TABLE.GetString("KEY_10_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_10_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_10_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_10_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_10_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_10_COL].CellType = text_type;

                        FormatTbl[KEY_10_COL].Col_Fmt = TABLE.GetChar("KEY_10_FMT").ToString();
                        FormatTbl[KEY_10_COL].Col_Size = TABLE.GetInt("KEY_10_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_10_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_10_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_10_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_10_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_10_TBL"), TABLE.GetString("KEY_10_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_10_BTN].Locked = true;
                        }
                    }
                }

                if (TABLE.GetString("DATA_1_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Value = " " + TABLE.GetString("DATA_1_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_1_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_1_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_1_COL].CellType = text_type;

                    FormatTbl[DATA_1_COL].Col_Fmt = TABLE.GetChar("DATA_1_FMT").ToString();
                    FormatTbl[DATA_1_COL].Col_Size = TABLE.GetInt("DATA_1_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_1_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_1_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_1_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_1_TBL"), TABLE.GetString("DATA_1_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_2_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].Value = " " + TABLE.GetString("DATA_2_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_2_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_2_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_2_COL].CellType = text_type;

                    FormatTbl[DATA_2_COL].Col_Fmt = TABLE.GetChar("DATA_2_FMT").ToString();
                    FormatTbl[DATA_2_COL].Col_Size = TABLE.GetInt("DATA_2_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_2_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_2_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_2_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_2_TBL"), TABLE.GetString("DATA_2_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_3_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].Value = " " + TABLE.GetString("DATA_3_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_3_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_3_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_3_COL].CellType = text_type;

                    FormatTbl[DATA_3_COL].Col_Fmt = TABLE.GetChar("DATA_3_FMT").ToString();
                    FormatTbl[DATA_3_COL].Col_Size = TABLE.GetInt("DATA_3_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_3_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_3_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_3_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_3_TBL"), TABLE.GetString("DATA_3_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_4_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].Value = " " + TABLE.GetString("DATA_4_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_4_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_4_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_4_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_4_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_4_COL].CellType = text_type;

                    FormatTbl[DATA_4_COL].Col_Fmt = TABLE.GetChar("DATA_4_FMT").ToString();
                    FormatTbl[DATA_4_COL].Col_Size = TABLE.GetInt("DATA_4_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_4_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_4_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_4_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_4_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_4_TBL"), TABLE.GetString("DATA_4_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_5_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].Value = " " + TABLE.GetString("DATA_5_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_5_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_5_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_5_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_5_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_5_COL].CellType = text_type;

                    FormatTbl[DATA_5_COL].Col_Fmt = TABLE.GetChar("DATA_5_FMT").ToString();
                    FormatTbl[DATA_5_COL].Col_Size = TABLE.GetInt("DATA_5_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_5_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_5_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_5_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_5_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_5_TBL"), TABLE.GetString("DATA_5_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_6_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].Value = " " + TABLE.GetString("DATA_6_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_6_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_6_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_6_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_6_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_6_COL].CellType = text_type;

                    FormatTbl[DATA_6_COL].Col_Fmt = TABLE.GetChar("DATA_6_FMT").ToString();
                    FormatTbl[DATA_6_COL].Col_Size = TABLE.GetInt("DATA_6_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_6_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_6_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_6_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_6_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_6_TBL"), TABLE.GetString("DATA_6_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_7_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].Value = " " + TABLE.GetString("DATA_7_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_7_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_7_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_7_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_7_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_7_COL].CellType = text_type;

                    FormatTbl[DATA_7_COL].Col_Fmt = TABLE.GetChar("DATA_7_FMT").ToString();
                    FormatTbl[DATA_7_COL].Col_Size = TABLE.GetInt("DATA_7_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_7_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_7_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_7_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_7_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_7_TBL"), TABLE.GetString("DATA_7_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_8_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].Value = " " + TABLE.GetString("DATA_8_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_8_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_8_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_8_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_8_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_8_COL].CellType = text_type;

                    FormatTbl[DATA_8_COL].Col_Fmt = TABLE.GetChar("DATA_8_FMT").ToString();
                    FormatTbl[DATA_8_COL].Col_Size = TABLE.GetInt("DATA_8_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_8_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_8_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_8_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_8_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_8_TBL"), TABLE.GetString("DATA_8_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_9_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].Value = " " + TABLE.GetString("DATA_9_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_9_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_9_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_9_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_9_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_9_COL].CellType = text_type;

                    FormatTbl[DATA_9_COL].Col_Fmt = TABLE.GetChar("DATA_9_FMT").ToString();
                    FormatTbl[DATA_9_COL].Col_Size = TABLE.GetInt("DATA_9_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_9_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_9_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_9_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_9_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_9_TBL"), TABLE.GetString("DATA_9_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_10_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].Value = " " + TABLE.GetString("DATA_10_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_10_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_10_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_10_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_10_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_10_COL].CellType = text_type;

                    FormatTbl[DATA_10_COL].Col_Fmt = TABLE.GetChar("DATA_10_FMT").ToString();
                    FormatTbl[DATA_10_COL].Col_Size = TABLE.GetInt("DATA_10_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_10_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_10_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_10_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_10_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_10_TBL"), TABLE.GetString("DATA_10_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].ColumnSpan = 2;
                    }
                }

                if (AutoCalWidth() == false)
                {
                    return false;
                }

                spdData.ActiveSheet.ColumnHeader.Rows[0].Height = spdData.ActiveSheet.ColumnHeader.Rows[0].GetPreferredHeight();
                spdData.ActiveSheet.SetColumnAllowAutoSort(1, 40, true);
                spdData.ActiveSheet.SetColumnAllowFilter(1, 40, true);

                spdData.ActiveSheet.RowCount++;
                for (i = 1; i <= 40; i++)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_DATA)
                    {
                        spdData.ActiveSheet.Columns[i].BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        spdData.ActiveSheet.Columns[i].BackColor = System.Drawing.Color.Lavender;
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                    }
                }
                /*** End of Modification (2012.04.04) ***/

                btnSelect.Text = MPCF.FindLanguage("Select All Rows", 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        private void SetColumnSQL(int i_col, string s_col_prt)
        {
            spdQuery.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = " " + s_col_prt + " ";
            spdQuery.ActiveSheet.Columns[i_col].Width = 180;
            spdQuery.ActiveSheet.Columns[i_col].Resizable = true;
        }

        private bool MakeColumnHeaderSQL()
        {
            int i;

            try
            {
                if (spdQuery.ActiveSheet.RowCount < 1)
                {
                    return true;
                }

                for (i = 0; i < 20; i++)
                {
                    spdQuery.ActiveSheet.ColumnHeader.Cells[0, i].Value = "";
                    spdQuery.ActiveSheet.ColumnHeader.Cells[0, i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdQuery.ActiveSheet.ColumnHeader.Cells[0, i].VerticalAlignment = CellVerticalAlignment.Center;

                    spdQuery.ActiveSheet.Columns[i].Width = 0;
                    spdQuery.ActiveSheet.Columns[i].Locked = true;
                    spdQuery.ActiveSheet.Columns[i].Resizable = false;
                    spdQuery.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdQuery.ActiveSheet.Columns[i].VerticalAlignment = CellVerticalAlignment.Center;
                }

                if (TABLE.GetString("KEY_1_PRT") != "")
                    SetColumnSQL(0, TABLE.GetString("KEY_1_PRT"));
                if (TABLE.GetString("KEY_2_PRT") != "")
                    SetColumnSQL(1, TABLE.GetString("KEY_2_PRT"));
                if (TABLE.GetString("KEY_3_PRT") != "")
                    SetColumnSQL(2, TABLE.GetString("KEY_3_PRT"));
                if (TABLE.GetString("KEY_4_PRT") != "")
                    SetColumnSQL(3, TABLE.GetString("KEY_4_PRT"));
                if (TABLE.GetString("KEY_5_PRT") != "")
                    SetColumnSQL(4, TABLE.GetString("KEY_5_PRT"));
                if (TABLE.GetString("KEY_6_PRT") != "")
                    SetColumnSQL(5, TABLE.GetString("KEY_6_PRT"));
                if (TABLE.GetString("KEY_7_PRT") != "")
                    SetColumnSQL(6, TABLE.GetString("KEY_7_PRT"));
                if (TABLE.GetString("KEY_8_PRT") != "")
                    SetColumnSQL(7, TABLE.GetString("KEY_8_PRT"));
                if (TABLE.GetString("KEY_9_PRT") != "")
                    SetColumnSQL(8, TABLE.GetString("KEY_9_PRT"));
                if (TABLE.GetString("KEY_10_PRT") != "")
                    SetColumnSQL(9, TABLE.GetString("KEY_10_PRT"));

                if (TABLE.GetString("DATA_1_PRT") != "")
                    SetColumnSQL(10, TABLE.GetString("DATA_1_PRT"));
                if (TABLE.GetString("DATA_2_PRT") != "")
                    SetColumnSQL(11, TABLE.GetString("DATA_2_PRT"));
                if (TABLE.GetString("DATA_3_PRT") != "")
                    SetColumnSQL(12, TABLE.GetString("DATA_3_PRT"));
                if (TABLE.GetString("DATA_4_PRT") != "")
                    SetColumnSQL(13, TABLE.GetString("DATA_4_PRT"));
                if (TABLE.GetString("DATA_5_PRT") != "")
                    SetColumnSQL(14, TABLE.GetString("DATA_5_PRT"));
                if (TABLE.GetString("DATA_6_PRT") != "")
                    SetColumnSQL(15, TABLE.GetString("DATA_6_PRT"));
                if (TABLE.GetString("DATA_7_PRT") != "")
                    SetColumnSQL(16, TABLE.GetString("DATA_7_PRT"));
                if (TABLE.GetString("DATA_8_PRT") != "")
                    SetColumnSQL(17, TABLE.GetString("DATA_8_PRT"));
                if (TABLE.GetString("DATA_9_PRT") != "")
                    SetColumnSQL(18, TABLE.GetString("DATA_9_PRT"));
                if (TABLE.GetString("DATA_10_PRT") != "")
                    SetColumnSQL(19, TABLE.GetString("DATA_10_PRT"));

                MPCF.FitColumnHeader(spdQuery, true);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // AutoCalWidth()
        //       - Auto Calculation Spread Column Width
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool AutoCalWidth()
        {
            int i = 0;
            int iSpreadWidth = 0;
            int iColumnWidth = 0;
            int iColumnCount = 0;

            float iColumnHeaderWidth = 0;
            float iRowHeaderWidth = 0;

            /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
            if (b_reload_data_flag == true)
            {
                for (i = 0; i < 40; i++)
                {
                    spdData.ActiveSheet.ColumnHeader.Columns[i + 1].Width = d_prev_col_size[i];
                    spdData.ActiveSheet.ColumnHeader.Columns[i + 1].Resizable = true;
                }
            }
            else
            {
                if (spdData.ActiveSheet.ColumnHeader.Columns.Count > 0)
                iColumnHeaderWidth = spdData.ActiveSheet.ColumnHeader.Columns[0].Width;

                if (spdData.ActiveSheet.RowHeader.Columns.Count > 0)
                    iRowHeaderWidth = spdData.ActiveSheet.RowHeader.Columns[0].Width;

                iSpreadWidth = (int)(spdData.Width - iColumnHeaderWidth - iRowHeaderWidth - 25);

                if (iSpreadWidth <= 0)
                {
                    return false;
                }
                for (i = 1; i < spdData.ActiveSheet.ColumnCount; i++)
                {
                    if (spdData.ActiveSheet.ColumnHeader.Columns[i].Width > 0)
                    {
                        iColumnCount++;
                    }
                }

                if (iColumnCount > 0)
                    iColumnWidth = iSpreadWidth / iColumnCount;
                else
                    iColumnCount = iSpreadWidth;

                if (iColumnWidth < 120)
                {
                    iColumnWidth = 120;
                }
                for (i = 1; i < spdData.ActiveSheet.ColumnCount; i++)
                {
                    if (spdData.ActiveSheet.ColumnHeader.Columns[i].Width > 0)
                    {
                        if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_KEY ||
                            MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_DATA)
                        {
                            spdData.ActiveSheet.ColumnHeader.Columns[i].Width = iColumnWidth;
                            spdData.ActiveSheet.ColumnHeader.Columns[i].Resizable = true;
                        }
                    }
                }
            }
            /*** End of Modification (2012.04.04) ***/
   
            return true;

        }

        private DataTable FillDataTable(DataTable dt, TRSNode out_node)
        {
            int c;
            int r;
            DataColumn dc;
            DataRow dr;
            List<TRSNode> data_list;

            /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
            data_list = out_node.GetList("DATA_LIST");
            if (dt == null)
            {
                if (data_list.Count < 1) return null;
                dt = new DataTable("DataTable");
                for (c = 0; c < 40; c++)
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dc.DefaultValue = "";

                    dt.Columns.Add(dc);
                }
            }

            for (r = 0; r < data_list.Count; r++)
            {
                dr = dt.NewRow();

                dr[0] = data_list[r].GetString("KEY_1");
                dr[1] = "";
                dr[2] = data_list[r].GetString("KEY_2");
                dr[3] = "";
                dr[4] = data_list[r].GetString("KEY_3");
                dr[5] = "";
                dr[6] = data_list[r].GetString("KEY_4");
                dr[7] = "";
                dr[8] = data_list[r].GetString("KEY_5");
                dr[9] = "";
                dr[10] = data_list[r].GetString("KEY_6");
                dr[11] = "";
                dr[12] = data_list[r].GetString("KEY_7");
                dr[13] = "";
                dr[14] = data_list[r].GetString("KEY_8");
                dr[15] = "";
                dr[16] = data_list[r].GetString("KEY_9");
                dr[17] = "";
                dr[18] = data_list[r].GetString("KEY_10");
                dr[19] = "";

                dr[20] = data_list[r].GetString("DATA_1");
                dr[21] = "";
                dr[22] = data_list[r].GetString("DATA_2");
                dr[23] = "";
                dr[24] = data_list[r].GetString("DATA_3");
                dr[25] = "";
                dr[26] = data_list[r].GetString("DATA_4");
                dr[27] = "";
                dr[28] = data_list[r].GetString("DATA_5");
                dr[29] = "";
                dr[30] = data_list[r].GetString("DATA_6");
                dr[31] = "";
                dr[32] = data_list[r].GetString("DATA_7");
                dr[33] = "";
                dr[34] = data_list[r].GetString("DATA_8");
                dr[35] = "";
                dr[36] = data_list[r].GetString("DATA_9");
                dr[37] = "";
                dr[38] = data_list[r].GetString("DATA_10");
                dr[39] = "";

                dt.Rows.Add(dr);
            }
            /*** End of Modification (2012.04.04) ***/

            return dt;
        }

        private DataTable FillDataTableSQL(DataTable dt, TRSNode out_node)
        {
            int c;
            int r;
            DataColumn dc;
            DataRow dr;
            List<TRSNode> data_list;

            data_list = out_node.GetList("DATA_LIST");
            if (dt == null)
            {
                if (data_list.Count < 1) return null;
                dt = new DataTable("DataTable");
                for (c = 0; c < 20; c++)
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dc.DefaultValue = "";

                    dt.Columns.Add(dc);
                }
            }

            for (r = 0; r < data_list.Count; r++)
            {
                dr = dt.NewRow();

                dr[0] = data_list[r].GetString("KEY_1");
                dr[1] = data_list[r].GetString("KEY_2");
                dr[2] = data_list[r].GetString("KEY_3");
                dr[3] = data_list[r].GetString("KEY_4");
                dr[4] = data_list[r].GetString("KEY_5");
                dr[5] = data_list[r].GetString("KEY_6");
                dr[6] = data_list[r].GetString("KEY_7");
                dr[7] = data_list[r].GetString("KEY_8");
                dr[8] = data_list[r].GetString("KEY_9");
                dr[9] = data_list[r].GetString("KEY_10");

                dr[10] = data_list[r].GetString("DATA_1");
                dr[11] = data_list[r].GetString("DATA_2");
                dr[12] = data_list[r].GetString("DATA_3");
                dr[13] = data_list[r].GetString("DATA_4");
                dr[14] = data_list[r].GetString("DATA_5");
                dr[15] = data_list[r].GetString("DATA_6");
                dr[16] = data_list[r].GetString("DATA_7");
                dr[17] = data_list[r].GetString("DATA_8");
                dr[18] = data_list[r].GetString("DATA_9");
                dr[19] = data_list[r].GetString("DATA_10");

                dt.Rows.Add(dr);
            }

            return dt;
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

            DataTable dt = null;
            ArrayList a_list = new ArrayList();
            FarPoint.Win.Spread.FpSpread spd;
            int i;

            try
            {
                if (b_reload_data_flag == true)
                {
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    for (i = 0; i < 40; i++)
                    {
                        d_prev_col_size[i] = spdData.ActiveSheet.ColumnHeader.Columns[i + 1].Width;
                    }
                    /*** End of Modification (2012.04.04) ***/
                }

                if (pnlSql.Visible == true)
                {
                    spd = spdQuery;
                }
                else
                {
                    spd = spdData;
                }

                MPCF.ClearList(spd);
                spd.SuspendLayout();
                spd.ActiveSheet.ColumnCount = 0;
                spd.ResumeLayout();

                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", lisTable.SelectedItems[0].Text);

                /* 2013.06.12. Aiden. 10000 개 이상의 Data 가 존재하는 경우 Filter 를 통해 Data List 를 가져오도록 변경 */
                if (MPCF.Trim(txtFilterKey1.Text) != "")
                {
                    in_node.AddString("KEY_1", MPCF.Trim(txtFilterKey1.Text) + "%");
                }
                if (MPCF.Trim(txtFilterKey2.Text) != "")
                {
                    in_node.AddString("KEY_2", MPCF.Trim(txtFilterKey2.Text) + "%");
                }

                if (sArgu != null)
                {
                    for (i = 0; i < sArgu.Length; i++)
                    {
                        TRSNode node = in_node.AddNode("ARGU_LIST");
                        node.AddString("ARGUMENT", sArgu[i]);
                    }
                }

                spd.SuspendLayout();

                do
                {
                    out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                    if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                    in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                    in_node.SetString("NEXT_KEY_3", out_node.GetString("NEXT_KEY_3"));
                    in_node.SetString("NEXT_KEY_4", out_node.GetString("NEXT_KEY_4"));
                    in_node.SetString("NEXT_KEY_5", out_node.GetString("NEXT_KEY_5"));
                    in_node.SetString("NEXT_KEY_6", out_node.GetString("NEXT_KEY_6"));
                    in_node.SetString("NEXT_KEY_7", out_node.GetString("NEXT_KEY_7"));
                    in_node.SetString("NEXT_KEY_8", out_node.GetString("NEXT_KEY_8"));
                    in_node.SetString("NEXT_KEY_9", out_node.GetString("NEXT_KEY_9"));
                    in_node.SetString("NEXT_KEY_10", out_node.GetString("NEXT_KEY_10"));
                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));


                } while (in_node.GetString("NEXT_KEY_1") != "" ||
                         in_node.GetString("NEXT_KEY_2") != "" ||
                         in_node.GetString("NEXT_KEY_3") != "" ||
                         in_node.GetString("NEXT_KEY_4") != "" ||
                         in_node.GetString("NEXT_KEY_5") != "" ||
                         in_node.GetString("NEXT_KEY_6") != "" ||
                         in_node.GetString("NEXT_KEY_7") != "" ||
                         in_node.GetString("NEXT_KEY_8") != "" ||
                         in_node.GetString("NEXT_KEY_9") != "" ||
                         in_node.GetString("NEXT_KEY_10") != "" ||
                         in_node.GetInt("NEXT_ROW") > 0);

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    if (pnlSql.Visible == true)
                    {
                        dt = FillDataTableSQL(dt, out_node);
                    }
                    else
                    {
                        dt = FillDataTable(dt, out_node);
                    }
                }

                spd.DataSource = dt;
                if (pnlSql.Visible == true)
                {
                    MakeColumnHeaderSQL();
                }
                else
                {
                    MakeColumnHeader();
                }
                spd.ResumeLayout();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        //
        // Update_Data_List()
        //       - Create/Update/Delete General Code Data List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
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
                in_node.AddString("TABLE_NAME", lisTable.SelectedItems[0].Text);
                in_node.AddString("TABLE_PASSWORD", MPCF.Trim(txtPwd.Text).ToUpper(), true);

                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (spdData.ActiveSheet.Cells[i, 0].Value == null) continue;
                    if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == false) continue;

                    node = in_node.AddNode("DATA_LIST");

                    node.AddString("KEY_1", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_1_COL].Value));
                    node.AddString("KEY_2", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_2_COL].Value));
                    node.AddString("KEY_3", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_3_COL].Value));
                    node.AddString("KEY_4", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_4_COL].Value));
                    node.AddString("KEY_5", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_5_COL].Value));
                    node.AddString("KEY_6", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_6_COL].Value));
                    node.AddString("KEY_7", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_7_COL].Value));
                    node.AddString("KEY_8", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_8_COL].Value));
                    node.AddString("KEY_9", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_9_COL].Value));
                    node.AddString("KEY_10", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_10_COL].Value));

                    node.AddString("DATA_1", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_1_COL].Value));
                    node.AddString("DATA_2", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_2_COL].Value));
                    node.AddString("DATA_3", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_3_COL].Value));
                    node.AddString("DATA_4", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_4_COL].Value));
                    node.AddString("DATA_5", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_5_COL].Value));
                    node.AddString("DATA_6", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_6_COL].Value));
                    node.AddString("DATA_7", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_7_COL].Value));
                    node.AddString("DATA_8", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_8_COL].Value));
                    node.AddString("DATA_9", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_9_COL].Value));
                    node.AddString("DATA_10", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_10_COL].Value));
                }

                if (MPCR.CallService("BAS", "BAS_Update_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        private bool ViewTable()
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");

            try
            {
                if (TABLE == null)
                {
                    TABLE = new TRSNode("VIEW_TABLE_OUT");
                }

                TABLE.Init();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", lisTable.SelectedItems[0].Text);

                if (MPCR.CallService("BAS", "BAS_View_Table", in_node, ref TABLE) == false)
                {
                    return false;
                }

                if (TABLE.GetChar("USE_SQL_FLAG") == 'Y')
                {
                    MPCF.ClearList(spdQuery);

                    pnlDataListFill.Visible = false;
                    pnlDataListBottom.Visible = false;
                    pnlRight.Controls.Add(pnlSql);
                    pnlSql.Dock = DockStyle.Fill;
                    pnlSql.Visible = true;

                    txtQuery.Text = TABLE.GetString("SQL_1") + TABLE.GetString("SQL_2") + TABLE.GetString("SQL_3")
                                    + TABLE.GetString("SQL_4") + TABLE.GetString("SQL_5");
                    ChangeSyntaxColor();
                }
                else
                {
                    pnlDataListFill.Visible = true;
                    pnlDataListBottom.Visible = true;
                    pnlSql.Visible = false;

                    /* 2013.06.12. Aiden. 10000 개 이상의 Data 가 존재하는 경우 Filter 를 통해 Data List 를 가져오도록 변경 */
                    if (IsBigDataList(TABLE.GetString("TABLE_NAME"), TABLE.GetChar("TABLE_TYPE")) == true)
                    {
                        pnlDataFilter.Visible = true;
                        btnView.Visible = true;

                        lblKey1.Visible = false;
                        txtFilterKey1.Visible = false;
                        lblKey2.Visible = false;
                        txtFilterKey2.Visible = false;

                        if (TABLE.GetString("KEY_1_PRT") != "")
                        {
                            lblKey1.Text = TABLE.GetString("KEY_1_PRT");
                            lblKey1.Visible = true;
                            txtFilterKey1.Visible = true;
                        }
                        if (TABLE.GetString("KEY_2_PRT") != "")
                        {
                            lblKey2.Text = TABLE.GetString("KEY_2_PRT");
                            lblKey2.Visible = true;
                            txtFilterKey2.Visible = true;
                        }

                        MPCF.ClearList(spdData);
                        MakeColumnHeader();
                    }
                    else
                    {
                        pnlDataFilter.Visible = false;
                        btnView.Visible = false;

                        txtFilterKey1.Text = "";
                        txtFilterKey2.Text = "";

                        ViewDataList(null);
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

        private bool GetQueryArgument()
        {
            int i, i_count, j;
            string[] sWord = null;
            string[] sArgu = null;
            bool b_exist_flag = false;
            frmBASSubSetupTable form = new frmBASSubSetupTable();

            sWord = txtQuery.Text.Split(new Char[] { ' ', '\n', '\r' });
            i_count = 0;
            for (i = 0; i < sWord.Length; i++)
            {
                if (sWord[i].IndexOf("$") >= 0)
                {
                    if (MPCF.Trim(sWord[i]).ToUpper().Contains("$FACTORY") == false)
                    {
                        i_count++;
                    }
                }
            }
            if (i_count > 0)
            {
                sArgu = new string[i_count];
            }

            i_count = 0;
            for (i = 0; i < sWord.Length; i++)
            {
                if (sWord[i].IndexOf("$") >= 0)
                {
                    b_exist_flag = false;
                    if (MPCF.Trim(sWord[i]).ToUpper().Contains("$FACTORY") == false)
                    {
                        for (j = 0; j < sArgu.Length; j++)
                        {
                            if (sArgu[j] == sWord[i])
                            {
                                b_exist_flag = true;
                            }
                        }
                        if (b_exist_flag == false)
                        {
                            sArgu[i_count] = sWord[i];
                            i_count++;
                        }
                    }
                }
            }
            if (i_count > 0)
            {
                form.ViewQueryArgument(sArgu, i_count);
                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    if (form.IsDisposed == false) form.Dispose();
                    return false;
                }
                sArgu = new string[i_count];
                for (i = 0; i < sArgu.Length; i++)
                {
                    //Modify by J.S. 2008.12.24 '는 서버에서 붙임.
                    sArgu[i] = form.ArgValue[i, 1];
                }
            }

            ViewDataList(sArgu);
            return true;
        }

        private bool IsSQLSyntax(string sQuery)
        {
            for (int i = 0; i < MPGV.SqlSyntax.Length; i++)
            {
                if (MPCF.Trim(MPGV.SqlSyntax[i]) == MPCF.Trim(sQuery))
                {
                    return true;
                }
            }
            return false;
        }

        private void ChangeSyntaxColor()
        {
            int iStart;
            int iLen = 0;
            iStart = 0;
            if (MPCF.Trim(txtQuery.Text) == "")
            {
                return;
            }
            txtQuery.SelectionStart = 0;
            txtQuery.SelectionLength = txtQuery.Text.Length;
            txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;

            while (iLen < txtQuery.Text.Length)
            {
                if (txtQuery.Text[iLen] == ' ')
                {
                    if (IsSQLSyntax(MPCF.ToUpper(txtQuery.Text.Substring(iStart, iLen - iStart))) == true ||
                        txtQuery.Text.Substring(iStart, iLen - iStart).IndexOf("$") > 0)
                    {
                        txtQuery.SelectionStart = iStart;
                        txtQuery.SelectionLength = iLen - iStart;
                        txtQuery.SelectionColor = System.Drawing.Color.Blue;
                        txtQuery.SelectionStart = iLen;
                        txtQuery.SelectionLength = 0;
                        txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;
                    }
                    iStart = iLen;
                }

                iLen++;
            }
        }

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        //
        // Check_GCM_Table()
        //       - Check GCM Table
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - string sTableName      : GCM Table Name
        //       - out string sQuery      : SQL Query (out)
        //       - out string dTable      : Script Export Table(2012.05.15 modify by leejy)
        //
        private bool CheckGCMTable(string sTableName, out string sQuery)
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");
            TRSNode out_node = new TRSNode("VIEW_TABLE_OUT");

            sQuery = String.Empty;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", sTableName);
                in_node.AddChar("INCLUDE_CENTRAL_TABLE_FLAG", 'Y');

                if (MPCR.CallService("BAS", "BAS_View_Table", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("USE_SQL_FLAG") == 'Y')
                {
                    sQuery = out_node.GetString("SQL_1") + out_node.GetString("SQL_2") + out_node.GetString("SQL_3")
                             + out_node.GetString("SQL_4") + out_node.GetString("SQL_5");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // GetQueryArgument()
        //       - Get Query Argument (by query)
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool GetQueryArgument(string sQuery, out string[] sArgu)
        {
            int i, j, i_count;
            string[] sWord = null;
            bool b_exist_flag = false;

            sArgu = null;

            if (MPCF.Trim(sQuery) != "")
            {
                frmBASSubSetupTable form = new frmBASSubSetupTable();

                sWord = sQuery.Split(new Char[] { ' ', '\n', '\r' });
                i_count = 0;
                for (i = 0; i < sWord.Length; i++)
                {
                    if (sWord[i].IndexOf("$") >= 0)
                    {
                        if (MPCF.Trim(sWord[i]).ToUpper().Contains("$FACTORY") == false)
                        {
                            i_count++;
                        }
                    }
                }
                if (i_count > 0)
                {
                    sArgu = new string[i_count];
                }

                i_count = 0;
                for (i = 0; i < sWord.Length; i++)
                {
                    if (sWord[i].IndexOf("$") >= 0)
                    {
                        b_exist_flag = false;
                        if (MPCF.Trim(sWord[i]).ToUpper().Contains("$FACTORY") == false)
                        {
                            for (j = 0; j < sArgu.Length; j++)
                            {
                                if (sArgu[j] == sWord[i])
                                {
                                    b_exist_flag = true;
                                }
                            }
                            if (b_exist_flag == false)
                            {
                                sArgu[i_count] = sWord[i];
                                i_count++;
                            }
                        }
                    }
                }
                if (i_count > 0)
                {
                    form.ViewQueryArgument(sArgu, i_count);
                    if (form.ShowDialog(this) != DialogResult.OK)
                    {
                        if (form.IsDisposed == false) form.Dispose();
                        return false;
                    }
                    sArgu = new string[i_count];
                    for (i = 0; i < sArgu.Length; i++)
                    {
                        sArgu[i] = form.ArgValue[i, 1];
                    }
                }
            }

            return true;
        }

        //
        // ViewGCMDataListExt()
        //       - View General Code Data list Extension (ListView Add "KEY_2" Column, use in this screen only)
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool ViewGCMDataListExt(ListView lisList, string table_name, string[] Argu)
        {
            ListViewItem itmX;
            int i;
            int j;
            string s_col_name;
            ArrayList a_list;
            List<TRSNode> data_list;

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            MPCF.InitListView(lisList);

            if (lisList is Miracom.UI.Controls.MCCodeView.MCCodeDropList)
            {
                ((Miracom.UI.Controls.MCCodeView.MCCodeDropList)lisList).GCMTableName = table_name;
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("TABLE_NAME", table_name);
            in_node.AddString("NEXT_KEY_1", "");
            in_node.AddString("NEXT_KEY_2", "");

            if (Argu != null)
            {
                for (i = 0; i < Argu.Length; i++)
                {
                    TRSNode node = in_node.AddNode("ARGU_LIST");
                    node.AddString("ARGUMENT", Argu[i]);
                }
            }

            do
            {
                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));

            } while (in_node.GetString("NEXT_KEY_1") != "" || in_node.GetString("NEXT_KEY_2") != "" || in_node.GetInt("NEXT_ROW") > 0);

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                data_list = out_node.GetList("DATA_LIST");
                for (i = 0; i < data_list.Count; i++)
                {
                    s_col_name = lisList.Columns[0].Text;

                    itmX = new ListViewItem();
                    itmX.Text = data_list[i].GetString(s_col_name);
                    itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_CODE_DATA;
                    for (j = 1; j < lisList.Columns.Count; j++)
                    {
                        s_col_name = lisList.Columns[j].Text;
                        itmX.SubItems.Add(data_list[i].GetString(s_col_name));
                    }
                    lisList.Items.Add(itmX);
                }
            }

            return true;
        }
        /*** End of Add (2012.04.04) ***/

        /* 2013.06.12. Aiden. 10000 개 이상의 Data 가 존재하는 경우 Filter 를 통해 Data List 를 가져오도록 변경 */
        private bool IsBigDataList(string s_table_name, char c_table_type)
        {
            StringBuilder sb = new StringBuilder();
            int i_count;

            sb.Append("SELECT COUNT(*) AS DCOUNT FROM ");

            if (c_table_type == 'L')
            {
                sb.Append("MGCMLAGDAT ");
            }
            else
            {
                sb.Append("MGCMTBLDAT ");
            }

            sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND TABLE_NAME = '" + s_table_name + "'");

            i_count = MPCR.GetDataCountBySQL(sb.ToString());
            if (i_count > 10000)
            {
                return true;
            }

            return false;
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.lisTable;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmBASSetupGCMDataByPrivilege_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.InitListView(lisTable);

                    btnRefresh.PerformClick();

                    i_last_filtered_column = -1;
                    s_last_filtered_string = null;
                    b_reload_data_flag = false;

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            string sTableName = "";

            try
            {
                if (lisTable.SelectedItems.Count > 0)
                {
                    sTableName = lisTable.SelectedItems[0].Text;
                }

                lblDataCount.Text = "";
                if (BASLIST.ViewGCMTableList(lisTable, '1', ' ', MPCF.Trim(cdvGroup.Text), chkOnlyPrvTable.Checked, true, false) == false)
                {
                    return;
                }
                               
                MPCF.FitColumnHeader(lisTable);
                lblDataCount.Text = lisTable.Items.Count.ToString();

                if (lisTable.Items.Count > 0)
                {
                    if (sTableName == "")
                    {
                        lisTable.Items[0].Selected = true;
                    }
                    else
                    {
                        MPCF.FindListItem(lisTable, sTableName, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisTable, this.Text, "");
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisTable, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisTable, txtFind.Text, 0, true, false);
        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            int ActiveRow = 0;

            try
            {
                if (CheckCondition("Update_Data_List", '1') == true)
                {
                    ActiveRow = spdData.Sheets[0].ActiveRowIndex;

                    if (UpdateDataList(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    b_reload_data_flag = true;
                    ViewDataList(null);

                    //Modify by J.S. 2012.02.14 refresh후 이전 편집위치로 이동
                    spdData.Sheets[0].ActiveColumnIndex = 0;
                    spdData.Sheets[0].ActiveRowIndex = ActiveRow;
                    spdData.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (CheckCondition("Update_Data_List", '2') == true)
                {
                    if (UpdateDataList(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    b_reload_data_flag = true;
                    ViewDataList(null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisTable_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (lisTable.SelectedItems.Count > 0)
                {
                    b_reload_data_flag = false;
                    ViewTable();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            try
            {
                if (lisTable.SelectedItems.Count == 0)
                {
                    return;
                }
                if (spdData.ActiveSheet.Columns[KEY_1_COL].Visible == false)
                {
                    return;
                }
                if (e.Row == spdData.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, KEY_1_COL].Value) != "")
                    {
                        spdData.ActiveSheet.RowCount++;
                        int i = 0;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        for (i = 1; i <= 20; i++)
                        {
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                        }
                        /*** End of Modification (2012.04.04) ***/
                    }
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
                if (spdData.ActiveSheet.Columns[KEY_1_COL].Visible == false)
                {
                    return;
                }

                if (i_row == spdData.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.Cells[i_row, KEY_1_COL].Value) != "")
                    {
                        spdData.ActiveSheet.RowCount++;
                        int i = 0;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        for (i = 1; i <= 20; i++)
                        {
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                        }
                        /*** End of Modification (2012.04.04) ***/
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

        private void btnSelect_Click(System.Object sender, System.EventArgs e)
        {
            int i = 0;

            try
            {
                if (btnSelect.Text == MPCF.FindLanguage("Select All Rows", 1))
                {
                    for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdData.ActiveSheet.Cells[i, 1].Value) != "")
                        {
                            if (spdData.ActiveSheet.RowFilter.IsRowFilteredOut(i) == true)
                            {
                                spdData.ActiveSheet.SetValue(i, 0, false);
                            }
                            else
                            {
                                spdData.ActiveSheet.SetValue(i, 0, true);
                            }
                        }
                    }
                    btnSelect.Text = MPCF.FindLanguage("Deselect All Rows", 1);
                }
                else if (btnSelect.Text == MPCF.FindLanguage("Deselect All Rows", 1))
                {
                    for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                    {
                        spdData.ActiveSheet.SetValue(i, 0, false);
                    }
                    btnSelect.Text = MPCF.FindLanguage("Select All Rows", 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvGroup_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView code_view = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            code_view.Init();
            MPCF.InitListView(code_view.GetListView);
            code_view.Columns.Add("Type", 50, HorizontalAlignment.Left);
            code_view.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            code_view.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(code_view.GetListView, '1', MPGC.MP_GCM_TABLE_GROUP);
        }

        private void cdvGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void btnSQLTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(txtQuery.Text) == "")
                {
                    return;
                }
                if (txtQuery.Text.IndexOf("$") > 0)
                {
                    if (GetQueryArgument() == false)
                    {
                        return;
                    }
                }
                else
                {
                    ViewDataList(null);
                }


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnTblExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                sCond = "Table Name : " + lisTable.SelectedItems[0].Text;

                // Updated By 140319 YJJUNG For Query-Type GCM Export
                if (pnlSql.Visible == false)
                {
                    MPCF.ExportToExcel(spdData, this.Text, sCond);
                }
                else
                {
                    MPCF.ExportToExcel(spdQuery, this.Text, sCond);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkOnlyPrvTable_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        private void spdData_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            ListView lisTmp = new ListView();
            string[] sTmp = null;
            string[] sArgu = null;
            string sQuery = "";
            i_last_selected_idx = 0;
            i_last_selected_desc_idx = -1;

            try
            {
                if (e.Column == KEY_1_BTN || e.Column == KEY_2_BTN || e.Column == KEY_3_BTN || e.Column == KEY_4_BTN || e.Column == KEY_5_BTN ||
                    e.Column == KEY_6_BTN || e.Column == KEY_7_BTN || e.Column == KEY_8_BTN || e.Column == KEY_9_BTN || e.Column == KEY_10_BTN ||
                    e.Column == DATA_1_BTN || e.Column == DATA_2_BTN || e.Column == DATA_3_BTN || e.Column == DATA_4_BTN || e.Column == DATA_5_BTN ||
                    e.Column == DATA_6_BTN || e.Column == DATA_7_BTN || e.Column == DATA_8_BTN || e.Column == DATA_9_BTN || e.Column == DATA_10_BTN)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag) == "") return;

                    sTmp = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).Split(':');
                    lisTmp.Columns.Add("COLUMN");
                    lisTmp.Columns.Add("PROMPT");

                    cdvDataList.Init();
                    cdvDataList.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvDataList.GetListView);

                    if (CheckGCMTable(sTmp[0], out sQuery))
                    {
                        if (sTmp.Length == 3)
                        {
                            int iPos = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).LastIndexOf(":");
                            spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).Remove(iPos) + ":" + sQuery;
                        }
                        else
                        {
                            if (MPCF.Trim(sQuery) != "")
                                spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag += ":" + sQuery;
                        }
                        sTmp = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).Split(':');
                    }
                    if (sTmp.Length == 3)
                    {
                        if (GetQueryArgument(sQuery, out sArgu) == false)
                        {
                            return;
                        }

                        BASLIST.ViewGCMTablePromptList(lisTmp, sTmp[0], true, true);
                        for (int i = 0; i < lisTmp.Items.Count; i++)
                        {
                            if (lisTmp.Items[i].Text == sTmp[1])
                                i_last_selected_idx = i;

                            if (lisTmp.Items[i].Text == "DATA_1")
                                i_last_selected_desc_idx = i;

                            cdvDataList.Columns.Add(lisTmp.Items[i].Text, 50, HorizontalAlignment.Left);
                        }
                    }
                    else
                    {
                        BASLIST.ViewGCMTablePromptList(lisTmp, sTmp[0], true, true);
                        for (int i = 0; i < lisTmp.Items.Count; i++)
                        {
                            if (lisTmp.Items[i].Text == sTmp[1])
                                i_last_selected_idx = i;

                            if (lisTmp.Items[i].Text == "DATA_1")
                                i_last_selected_desc_idx = i;

                            cdvDataList.Columns.Add(lisTmp.Items[i].Text, 50, HorizontalAlignment.Left);
                        }
                    }
                    ViewGCMDataListExt(cdvDataList.GetListView, sTmp[0], sArgu);
                    if (cdvDataList.Items.Count > 0)
                    {
                        cdvDataList.InsertEmptyRow(0, 1);
                        if (cdvDataList.ShowPopupList(e.Row, e.Column) == false)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvDataList_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, e.Col - 1].Value) != e.SelectedItem.SubItems[i_last_selected_idx].Text)
                {
                    spdData.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[i_last_selected_idx].Text;
                    if (e.SelectedItem.SubItems.Count > 1)
                    {
                        int iDescCol = -1;
                        for (int i = e.Col; i < spdData.ActiveSheet.ColumnCount; i++)
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_DATA &&
                                spdData.ActiveSheet.Columns[i].Visible == true &&
                                i < spdData.ActiveSheet.ColumnCount - 1)
                            {
                                // 2 column has same reference GCM table, fill description
                                string[] sTmp1 = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Col].Tag).Split(':');
                                string[] sTmp2 = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i + 1].Tag).Split(':');

                                if (sTmp1[0] == sTmp2[0] && sTmp1[1] != sTmp2[1] && i_last_selected_desc_idx >= 0)
                                {
                                    iDescCol = i;
                                    spdData.ActiveSheet.Cells[e.Row, iDescCol].Value = e.SelectedItem.SubItems[i_last_selected_desc_idx].Text;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        /*** End of Modification (2012.04.04) ***/

        /* 2013.06.12. Aiden. 10000 개 이상의 Data 가 존재하는 경우 Filter 를 통해 Data List 를 가져오도록 변경 */
        private void btnView_Click(object sender, EventArgs e)
        {
            if (MPCF.Trim(txtFilterKey1.Text) == "" && MPCF.Trim(txtFilterKey2.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtFilterKey1.Focus();
                return;
            }

            ViewDataList(null);
        }


        private void fpSpread_ClipboardPasting(object sender, FarPoint.Win.Spread.ClipboardPastingEventArgs e)
        {
            try
            {
                e.Handled = true;

                string clipboardText;
                string[] clipboardRows, clipboardCols = new string[] { };
                int iActiveRowIndex, iActiveColumnIndex;
                int iClipboardRowLength = 0;
                int iValueCol = 0;
                int iMaxValueCol = 0;
                bool bFoundValueCol;

                if (!Clipboard.ContainsData(DataFormats.Text)) return;

                iActiveRowIndex = spdData.ActiveSheet.ActiveRowIndex;
                iActiveColumnIndex = spdData.ActiveSheet.ActiveColumnIndex;

                clipboardText = Clipboard.GetText(TextDataFormat.UnicodeText) as string;
                clipboardText = clipboardText.Replace("\r\n", Convert.ToChar(13).ToString());
                clipboardRows = clipboardText.Split(new Char[] { Convert.ToChar(13) });

                if (clipboardRows.Length > 1)
                    iClipboardRowLength = clipboardRows.Length - 1;
                else
                    iClipboardRowLength = clipboardRows.Length;

                for (int i_row = 0; i_row < iClipboardRowLength; i_row++)
                {
                    if (spdData.ActiveSheet.RowCount - 1 < i_row + iActiveRowIndex)
                    {
                        spdData.ActiveSheet.RowCount++;
                        for (int i = 1; i <= 20; i++)
                        {
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                        }
                    }

                    clipboardCols = clipboardRows[i_row].Split(new Char[] { Convert.ToChar(9) });
                    iValueCol = iActiveColumnIndex;

                    for (int i_col = 0; i_col < clipboardCols.Length; i_col++)
                    {
                        spdData.ActiveSheet.Cells[iActiveRowIndex + i_row, iValueCol].Value = clipboardCols[i_col];

                        if (iValueCol > iMaxValueCol) iMaxValueCol = iValueCol;
                        if (i_col + 1 >= clipboardCols.Length) break;

                        bFoundValueCol = false;
                        for (int i = iValueCol + 1; i < spdData.ActiveSheet.ColumnCount; i++)
                        {
                            if (spdData.ActiveSheet.ColumnHeader.Columns[i].Width > 0.0005)
                            {
                                switch (i)
                                {
                                    case KEY_1_COL:
                                    case KEY_2_COL:
                                    case KEY_3_COL:
                                    case KEY_4_COL:
                                    case KEY_5_COL:
                                    case KEY_6_COL:
                                    case KEY_7_COL:
                                    case KEY_8_COL:
                                    case KEY_9_COL:
                                    case KEY_10_COL:
                                    case DATA_1_COL:
                                    case DATA_2_COL:
                                    case DATA_3_COL:
                                    case DATA_4_COL:
                                    case DATA_5_COL:
                                    case DATA_6_COL:
                                    case DATA_7_COL:
                                    case DATA_8_COL:
                                    case DATA_9_COL:
                                    case DATA_10_COL:
                                        iValueCol = i;
                                        bFoundValueCol = true;
                                        break;
                                }
                            }

                            if (bFoundValueCol == true) break;
                        }

                        if (bFoundValueCol == false) break;
                    }

                    spdData.ActiveSheet.Cells[iActiveRowIndex + i_row, 0].Value = 1;            // Check Box Check
                    spdData.ActiveSheet.SetActiveCell(iActiveRowIndex + i_row, iActiveColumnIndex);
                } //end for

                spdData.ActiveSheet.SetActiveCell(iActiveRowIndex, iActiveColumnIndex);

                spdData.ActiveSheet.ClearSelection();
                spdData.ActiveSheet.AddSelection(iActiveRowIndex, iActiveColumnIndex, iClipboardRowLength, iMaxValueCol - iActiveColumnIndex + 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private bool mb_from_spread_clipboard;
        private void spdData_ClipboardChanging(object sender, EventArgs e)
        {
            mb_from_spread_clipboard = true;
        }

        private void spdData_ClipboardChanged(object sender, EventArgs e)
        {
            if (mb_from_spread_clipboard == false) return;

            mb_from_spread_clipboard = false;

            Clipboard.Clear();
            if (spdData.ActiveSheet.SelectionCount < 1) return;

            int i;
            int i_row;
            int i_col;
            FarPoint.Win.Spread.Model.CellRange[] cr;
            StringBuilder sb = new StringBuilder();
            string s_data;

            cr = spdData.ActiveSheet.GetSelections();

            for (i = 0; i < cr.Length; i++)
            {
                for (i_row = cr[i].Row; i_row < cr[i].Row + cr[i].RowCount; i_row++)
                {
                    s_data = "";

                    for (i_col = cr[i].Column; i_col < cr[i].Column + cr[i].ColumnCount; i_col++)
                    {
                        if (spdData.ActiveSheet.ColumnHeader.Columns[i_col].Width > 0.0005)
                        {
                            switch (i_col)
                            {
                                case KEY_1_COL:
                                case KEY_2_COL:
                                case KEY_3_COL:
                                case KEY_4_COL:
                                case KEY_5_COL:
                                case KEY_6_COL:
                                case KEY_7_COL:
                                case KEY_8_COL:
                                case KEY_9_COL:
                                case KEY_10_COL:
                                case DATA_1_COL:
                                case DATA_2_COL:
                                case DATA_3_COL:
                                case DATA_4_COL:
                                case DATA_5_COL:
                                case DATA_6_COL:
                                case DATA_7_COL:
                                case DATA_8_COL:
                                case DATA_9_COL:
                                case DATA_10_COL:
                                    if (i_col > cr[i].Column) s_data += "\t";
                                    s_data += MPCF.Trim(spdData.ActiveSheet.Cells[i_row, i_col].Value);
                                    break;
                            }
                        }
                    }

                    s_data += "\r\n";
                    sb.Append(s_data);
                }
            }

            Clipboard.SetDataObject(sb.ToString());
        }
        
        private void txtFilterKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnView.PerformClick();
            }
        }



    }
}
