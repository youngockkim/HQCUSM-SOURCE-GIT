using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
//using Miracom.MESCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using FarPoint.Win.Spread;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Base Form
    // SOIBaseForm03 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel, Print Option
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmCUSTranLotInspectionChange : SOIBaseForm03
    {
        #region Constructor

        public frmCUSTranLotInspectionChange()
        {
            InitializeComponent();
        }

        #endregion

        #region Property

        // (Required)
        private bool bIsShown = false;

        #endregion

        #region Constant Definition
        
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

        private const int MAX_DATA_COUNT = 1000;
        private const string LOT_EXTENSION_TABLE = "LOT_EXTENSION";
        #endregion

        #region Variable Definition

        private frmPrintOptionPopup frmOption;
        private struct Format
        {
            public string Col_Fmt;
            public int Col_Size;
        };

        private Format[] FormatTbl = new Format[41];
        private float[] d_prev_col_size = null;
         
        #endregion
        
        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm03_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm03_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintOption_Click(object sender, EventArgs e)
        {
            // Print Option Popup 생성
            if (frmOption == null)
            {
                frmOption = new frmPrintOptionPopup();
            }

            // Print Option Popup 초기화
            frmOption.Owner = this;
            frmOption.printOption = this.printOption;

            // Show Dialog
            if (frmOption.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.printOption = frmOption.printOption;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (spdList.Sheets[0].Rows.Count > 0)
            {
                // UPDATE MWIPELTSTS TABLE
                UpdateTable();
                MPCF.ClearList(spdList);
                txtLotId.Text = string.Empty;                
                MPCF.SetFocus(txtLotId);
                txtLotId.SelectAll();
            }
        }

        #endregion

        #region Function

        private bool UpdateTable()
        {
            TRSNode in_node = new TRSNode("UPDATE_DATA_IN");
            TRSNode out_node = new TRSNode("UPDATE_DATA_OUT");

            // 파라미터 값 넘겨주기 #################################################################

            MPCF.SetInMsg(in_node);
            in_node.AddString("LOT_ID", MPCF.Trim(spdList.ActiveSheet.Cells[0, DATA_3_COL].Value));
            in_node.AddInt("HIST_SEQ", MPCF.Trim(spdList.ActiveSheet.Cells[1, DATA_3_COL].Value));
            in_node.AddString("FQC_TIME", MPCF.Trim(spdList.ActiveSheet.Cells[2, DATA_3_COL].Value));
            in_node.AddString("GRADE", MPCF.Trim(spdList.ActiveSheet.Cells[3, DATA_3_COL].Value));
            in_node.AddString("POWER", MPCF.Trim(spdList.ActiveSheet.Cells[4, DATA_3_COL].Value));
            in_node.AddString("LOC_ID", MPCF.Trim(spdList.ActiveSheet.Cells[5, DATA_3_COL].Value));
            in_node.AddString("LINE_ID", MPCF.Trim(spdList.ActiveSheet.Cells[6, DATA_3_COL].Value));
            in_node.AddString("EFF", MPCF.Trim(spdList.ActiveSheet.Cells[7, DATA_3_COL].Value));
            in_node.AddString("RSH", MPCF.Trim(spdList.ActiveSheet.Cells[8, DATA_3_COL].Value));
            in_node.AddString("RS", MPCF.Trim(spdList.ActiveSheet.Cells[9, DATA_3_COL].Value));
            in_node.AddString("FF", MPCF.Trim(spdList.ActiveSheet.Cells[10, DATA_3_COL].Value));
            in_node.AddString("ISC", MPCF.Trim(spdList.ActiveSheet.Cells[11, DATA_3_COL].Value));
            in_node.AddString("VOC", MPCF.Trim(spdList.ActiveSheet.Cells[12, DATA_3_COL].Value));
            in_node.AddString("IMPP", MPCF.Trim(spdList.ActiveSheet.Cells[13, DATA_3_COL].Value));
            in_node.AddString("VMPP", MPCF.Trim(spdList.ActiveSheet.Cells[14, DATA_3_COL].Value));
            in_node.AddString("PMPP", MPCF.Trim(spdList.ActiveSheet.Cells[15, DATA_3_COL].Value));
            in_node.AddString("TEMP", MPCF.Trim(spdList.ActiveSheet.Cells[16, DATA_3_COL].Value));
            in_node.AddString("TREF", MPCF.Trim(spdList.ActiveSheet.Cells[17, DATA_3_COL].Value));
            in_node.AddString("SURFTEMP", MPCF.Trim(spdList.ActiveSheet.Cells[18, DATA_3_COL].Value));
            in_node.AddString("SUN", MPCF.Trim(spdList.ActiveSheet.Cells[19, DATA_3_COL].Value));
            in_node.AddString("OSC", MPCF.Trim(spdList.ActiveSheet.Cells[20, DATA_3_COL].Value));
            in_node.AddString("ESC", MPCF.Trim(spdList.ActiveSheet.Cells[21, DATA_3_COL].Value));
            in_node.AddString("EL", MPCF.Trim(spdList.ActiveSheet.Cells[22, DATA_3_COL].Value));
            in_node.AddString("FLASHER_CODE", MPCF.Trim(spdList.ActiveSheet.Cells[23, DATA_3_COL].Value));
            in_node.AddString("CURING_TIME", MPCF.Trim(spdList.ActiveSheet.Cells[24, DATA_3_COL].Value));
            in_node.AddString("ARTICLE_NO", MPCF.Trim(spdList.ActiveSheet.Cells[25, DATA_3_COL].Value));
            in_node.AddString("ARTICLE_EXT_NO", MPCF.Trim(spdList.ActiveSheet.Cells[26, DATA_3_COL].Value));
            in_node.AddString("COLOR_CLASS", MPCF.Trim(spdList.ActiveSheet.Cells[27, DATA_3_COL].Value));
            in_node.AddString("PALLET_ID", MPCF.Trim(spdList.ActiveSheet.Cells[28, DATA_3_COL].Value));
            in_node.AddString("PAK_GROUP", MPCF.Trim(spdList.ActiveSheet.Cells[29, DATA_3_COL].Value));
            in_node.AddString("PAK_MOD_TYPE", MPCF.Trim(spdList.ActiveSheet.Cells[30, DATA_3_COL].Value));
            in_node.AddString("EL_IMAGE_PATH", MPCF.Trim(spdList.ActiveSheet.Cells[31, DATA_3_COL].Value));

            // ##########################################################################################
            
            if (MPCF.CallService("CWIP", "CWIP_Update_Inspection_List", in_node, ref out_node) == false)
            {
                return false;
            }
            
            MPCF.ShowSuccessMessage(out_node, false);
            return true;
        }

        private bool ViewDataList()
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            TRSNode in_node1 = new TRSNode("VIEW_ELT_TABLE_IN");
            TRSNode out_node1 = new TRSNode("VIEW_ELT_TABLE_OUT");

            DataTable dt = null;
            ArrayList a_list = new ArrayList();

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.Factory = MPGV.gsCentralFactory;
                in_node.AddString("TABLE_NAME", LOT_EXTENSION_TABLE);

                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCF.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                in_node1.AddString("LOT_ID", txtLotId.Text);

                if (MPCF.CallService("CWIP", "CWIP_View_Inspection_List", in_node1, ref out_node1) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    dt = FillDataTable(dt, out_node, out_node1);
                }

                spdList.DataSource = dt;
                MakeColumnHeader();

                spdList.ActiveSheet.Rows[0].Locked = true;
                spdList.ActiveSheet.Rows[1].Locked = true;
                spdList.ActiveSheet.Rows[0].BackColor = Color.DarkOrange;
                spdList.ActiveSheet.Rows[1].BackColor = Color.DarkOrange;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }

        private DataTable FillDataTable(DataTable dt, TRSNode out_node, TRSNode out_node1)
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

            for (r = 0; r < (out_node.GetList(0).Count)-1; r++)
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
                switch (r)
                {
                    case 0:
                        dr[22] = out_node1.GetString("LOT_ID");
                        dr[24] = out_node1.GetString("LOT_ID");
                        break;
                    case 1:
                        dr[22] = out_node1.GetInt("HIST_SEQ");
                        dr[24] = out_node1.GetInt("HIST_SEQ");
                        break;
                    case 2:
                        dr[22] = out_node1.GetString("FQC_TIME");
                        dr[24] = out_node1.GetString("FQC_TIME");
                        break;
                    case 3:
                        dr[22] = out_node1.GetString("GRADE");
                        dr[24] = out_node1.GetString("GRADE");
                        break;
                    case 4:
                        dr[22] = out_node1.GetString("POWER");
                        dr[24] = out_node1.GetString("POWER");
                        break;
                    case 5:
                        dr[22] = out_node1.GetString("LOC_ID");
                        dr[24] = out_node1.GetString("LOC_ID");
                        break;
                    case 6:
                        dr[22] = out_node1.GetString("LINE_ID");
                        dr[24] = out_node1.GetString("LINE_ID");
                        break;
                    case 7:
                        dr[22] = out_node1.GetString("EFF");
                        dr[24] = out_node1.GetString("EFF");
                        break;
                    case 8:
                        dr[22] = out_node1.GetString("RSH");
                        dr[24] = out_node1.GetString("RSH");
                        break;
                    case 9:
                        dr[22] = out_node1.GetString("RS");
                        dr[24] = out_node1.GetString("RS");
                        break;
                    case 10:
                        dr[22] = out_node1.GetString("FF");
                        dr[24] = out_node1.GetString("FF");
                        break;
                    case 11:
                        dr[22] = out_node1.GetString("ISC");
                        dr[24] = out_node1.GetString("ISC");
                        break;
                    case 12:
                        dr[22] = out_node1.GetString("VOC");
                        dr[24] = out_node1.GetString("VOC");
                        break;
                    case 13:
                        dr[22] = out_node1.GetString("IMPP");
                        dr[24] = out_node1.GetString("IMPP");
                        break;
                    case 14:
                        dr[22] = out_node1.GetString("VMPP");
                        dr[24] = out_node1.GetString("VMPP");
                        break;
                    case 15:
                        dr[22] = out_node1.GetString("PMPP");
                        dr[24] = out_node1.GetString("PMPP");
                        break;
                    case 16:
                        dr[22] = out_node1.GetString("TEMP");
                        dr[24] = out_node1.GetString("TEMP");
                        break;
                    case 17:
                        dr[22] = out_node1.GetString("TREF");
                        dr[24] = out_node1.GetString("TREF");
                        break;
                    case 18:
                        dr[22] = out_node1.GetString("SURFTEMP");
                        dr[24] = out_node1.GetString("SURFTEMP");
                        break;
                    case 19:
                        dr[22] = out_node1.GetString("SUN");
                        dr[24] = out_node1.GetString("SUN");
                        break;
                    case 20:
                        dr[22] = out_node1.GetString("OSC");
                        dr[24] = out_node1.GetString("OSC");
                        break;
                    case 21:
                        dr[22] = out_node1.GetString("ESC");
                        dr[24] = out_node1.GetString("ESC");
                        break;
                    case 22:
                        dr[22] = out_node1.GetString("EL");
                        dr[24] = out_node1.GetString("EL");
                        break;
                    case 23:
                        dr[22] = out_node1.GetString("FLASHER_CODE");
                        dr[24] = out_node1.GetString("FLASHER_CODE");
                        break;
                    case 24:
                        dr[22] = out_node1.GetString("CURING_TIME");
                        dr[24] = out_node1.GetString("CURING_TIME");
                        break;
                    case 25:
                        dr[22] = out_node1.GetString("ARTICLE_NO");
                        dr[24] = out_node1.GetString("ARTICLE_NO");
                        break;
                    case 26:
                        dr[22] = out_node1.GetString("ARTICLE_EXT_NO");
                        dr[24] = out_node1.GetString("ARTICLE_EXT_NO");
                        break;
                    case 27:
                        dr[22] = out_node1.GetString("COLOR_CLASS");
                        dr[24] = out_node1.GetString("COLOR_CLASS");
                        break;
                    case 28:
                        dr[22] = out_node1.GetString("PALLET_ID");
                        dr[24] = out_node1.GetString("PALLET_ID");
                        break;
                    case 29:
                        dr[22] = out_node1.GetString("PAK_GROUP");
                        dr[24] = out_node1.GetString("PAK_GROUP");
                        break;
                    case 30:
                        dr[22] = out_node1.GetString("PAK_MOD_TYPE");
                        dr[24] = out_node1.GetString("PAK_MOD_TYPE");
                        break;
                    case 31:
                        dr[22] = out_node1.GetString("EL_IMAGE_PATH");
                        dr[24] = out_node1.GetString("EL_IMAGE_PATH");
                        break;
                }                
                dr[23] = "";                
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
            //FarPoint.Win.Spread.CellType.ComboBoxCellType combobox_type;
            int i;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.Factory = MPGV.gsCentralFactory;
                in_node.AddString("TABLE_NAME", LOT_EXTENSION_TABLE);

                if (MPCF.CallService("BAS", "BAS_View_Table", in_node, ref out_node) == false)
                {
                    return false;
                }
                                
                if (spdList.ActiveSheet.Columns.Count > 0)
                {
                    spdList.ActiveSheet.Columns.Add(0, 1);
                }
                else
                {
                    spdList.ActiveSheet.ColumnCount = 41;
                }

                for (i = 1; i <= 40; i++)
                {
                    spdList.ActiveSheet.ColumnHeader.Columns[i].Width = 0;
                    spdList.ActiveSheet.ColumnHeader.Columns[i].Resizable = false;
                    spdList.ActiveSheet.ColumnHeader.Cells[0, i].Value = "";

                    FormatTbl[i].Col_Fmt = "";
                    FormatTbl[i].Col_Size = 0;
                }

                spdList.ActiveSheet.ColumnHeader.Cells[0, 0].Value = "Selection.";
                spdList.ActiveSheet.Columns.Get(0).CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                spdList.ActiveSheet.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                spdList.ActiveSheet.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdList.ActiveSheet.Columns[CHECK_COL].Locked = true;
                spdList.ActiveSheet.Columns.Get(0).Width = 30;

                //Column Name : KEY_1_COL
                text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                text_type.MaxLength = 3;
                spdList.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].CellType = text_type;
                spdList.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].Value = "No.";
                spdList.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdList.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Width = 150;
                spdList.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Visible = true;
                spdList.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Resizable = true;
                spdList.ActiveSheet.Columns[KEY_1_COL].Locked = true;
                spdList.ActiveSheet.Columns[KEY_1_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdList.ActiveSheet.Columns[KEY_1_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.Columns[KEY_1_COL].CellType = text_type;
                FormatTbl[KEY_1_COL].Col_Fmt = out_node.GetChar("KEY_1_FMT").ToString();
                FormatTbl[KEY_1_COL].Col_Size = out_node.GetInt("KEY_1_SIZE");
                spdList.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].Tag = "KEY";

                //Column Name : KEY_2_COL
                text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                text_type.MaxLength = 50;
                text_type.CharacterCasing = CharacterCasing.Upper;
                spdList.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].CellType = text_type;
                spdList.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].Value = "Item Name.";
                spdList.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdList.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Width = 200;
                spdList.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Visible = true;
                spdList.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Resizable = true;
                spdList.ActiveSheet.Columns[KEY_2_COL].Locked = true;
                spdList.ActiveSheet.Columns[KEY_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdList.ActiveSheet.Columns[KEY_2_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.Columns[KEY_2_COL].CellType = text_type;
                FormatTbl[KEY_2_COL].Col_Fmt = out_node.GetChar("KEY_2_FMT").ToString();
                FormatTbl[KEY_2_COL].Col_Size = out_node.GetInt("KEY_2_SIZE");
                spdList.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].Tag = "KEY";
                spdList.ActiveSheet.Columns.Get(0).Width = 100;

                //Column Description : DATA_1_COL
                text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                text_type.MaxLength = 1000;
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].CellType = text_type;
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Value = "Item Description.";
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Width = 400;
                spdList.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Visible = true;
                spdList.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Resizable = true;
                spdList.ActiveSheet.Columns[DATA_1_COL].Locked = true;
                spdList.ActiveSheet.Columns[DATA_1_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                spdList.ActiveSheet.Columns[DATA_1_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.Columns[DATA_1_COL].CellType = text_type;
                FormatTbl[DATA_1_COL].Col_Fmt = out_node.GetChar("DATA_1_FMT").ToString();
                FormatTbl[DATA_1_COL].Col_Size = out_node.GetInt("DATA_1_SIZE");
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Tag = "DATA";
                spdList.ActiveSheet.Columns.Get(0).Width = 150;

                //Data Size : DATA_2_COL
                text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                text_type.MaxLength = 1000;
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].CellType = text_type;
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].Value = "Current Value";
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Width = 150;
                spdList.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Visible = true;
                spdList.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Resizable = true;
                spdList.ActiveSheet.Columns[DATA_2_COL].Locked = true;
                spdList.ActiveSheet.Columns[DATA_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdList.ActiveSheet.Columns[DATA_2_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.Columns[DATA_2_COL].CellType = text_type;
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Tag = "DATA";

                //Data Size : DATA_3_COL
                text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                text_type.MaxLength = 1000;
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].CellType = text_type;
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].Value = "Change Value";
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Width = 150;
                spdList.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Visible = true;
                spdList.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Resizable = true;
                spdList.ActiveSheet.Columns[DATA_3_COL].Locked = false;
                spdList.ActiveSheet.Columns[DATA_3_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                spdList.ActiveSheet.Columns[DATA_3_COL].VerticalAlignment = CellVerticalAlignment.Center;
                spdList.ActiveSheet.Columns[DATA_3_COL].CellType = text_type;
                spdList.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Tag = "DATA";
                
                spdList.ActiveSheet.ColumnHeader.Rows[0].Height = spdList.ActiveSheet.ColumnHeader.Rows[0].GetPreferredHeight();
                spdList.ActiveSheet.SetColumnAllowAutoSort(1, 40, true);
                spdList.ActiveSheet.SetColumnAllowFilter(1, 40, true);

                spdList.ActiveSheet.RowCount++;
                spdList.ActiveSheet.Rows[spdList.ActiveSheet.RowCount - 1].Tag = "NEW";

                for (i = 1; i <= 40; i++)
                {
                    if (MPCF.Trim(spdList.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == "KEY")
                    {   
                        spdList.ActiveSheet.Cells[spdList.ActiveSheet.RowCount - 1, i].Locked = false;
                    }                    

                    if (d_prev_col_size != null && d_prev_col_size[i - 1] > 0)
                    {
                        spdList.ActiveSheet.Columns[i].Width = d_prev_col_size[i - 1];
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

        #endregion

        private void txtLotId_KeyDown(object sender, KeyEventArgs e)
        {
            // 엔터를 입력하면 처리되는 로직이 들어간다.
            try
            {
                if (e.KeyValue == 13)
                {
                    ViewDataList();                   
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            
        }
    }
}
