using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;
using Miracom.UI.Controls.MCCodeView;
using SOI.OIFrx;
using System.Collections;
using System.Reflection;
using FarPoint.Win.Spread;

namespace SOI.OIFrx
{
    public partial class SPCPopupCondition1 : SOI.OIFrx.SPCBaseForm.SPCBaseForm01
    {
        public SPCPopupCondition1()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        public enum COL_LINE : int
        {
            COL_LINE_CODE = 0,
            COL_LINE_DESC,
            COL_CAR_TYPE,
            COL_CAR_TYPE_DESC,
            COL_MAT_ID,
            COL_MAT_DESC,
            COL_COMMENT
        }

        public enum COL_SHOP : int
        {
            COL_SHOP_CODE = 0,
            COL_SHOP_DESC,
            COL_RES_ID,
            COL_RES_DESC,
            COL_CHAR_ID,
            COL_CHAR_DESC
        }

        public const int TYPE_1 = 1;
        public const int TYPE_2 = 2;
        public const int TYPE_3 = 3;

        private const string CONDITION_VIEW = "VIEW";
        private const string CONDITION_SELECT = "SELECT";

        private const string CLEAR_ALL = "ALL";
        private const string CLEAR_VIEW = "VIEW";

        #endregion

        #region " Variable Definition "

        FpSpread fpContext = new FpSpread();
        DataTable dtLineBlank = new DataTable();
        DataTable dtShopBlank = new DataTable();
        Hashtable htLineSelected = new Hashtable();
        Hashtable htShopSelected = new Hashtable();
        private DataTable _dtSpreadData = new DataTable(); // Spread에 바인딩 할 Raw Data
        SpreadTypes.ActivePosition activePosition = new SpreadTypes.ActivePosition(0, 0);
        //COLUMNS 숨김 여부
        int[] iArryVisibleCols = new int[] { };
        //Set Color
        int[] iArryColorCols1 = new int[] { };
        //검색 DATA COLUMNS(DATA TYPE = STRING에 한해야 함.)
        string[] sArrySearchCols = new string[] { };
        List<string> lstAddKeys1 = new List<string>();

        public int TYPE { get; set; }
        public int[] COL_VISIBLE { get; set; }
        public int[] COL_COLOR { get; set; }

        public string SELECT_LINE_CODE { get; set; }
        public string SELECT_LINE_DESC { get; set; }
        public string SELECT_SHOP_CODE { get; set; }
        public string SELECT_SHOP_DESC { get; set; }
        public string SELECT_CAR_TYPE { get; set; }
        public string SELECT_CAR_TYPE_DESC { get; set; }
        public string SELECT_MAT_ID { get; set; }
        public string SELECT_MAT_DESC { get; set; }
        public string SELECT_RES_ID { get; set; }
        public string SELECT_RES_DESC { get; set; }
        public string SELECT_CHAR_ID { get; set; }
        public string SELECT_CHAR_DESC { get; set; }
        public string SELECT_UPPER_SPEC_LIMIT { get; set; }
        public string SELECT_UPPER_WARN_LIMIT { get; set; }
        public string SELECT_TARGET_VALUE { get; set; }
        public string SELECT_LOWER_WARN_LIMIT { get; set; }
        public string SELECT_LOWER_SPEC_LIMIT { get; set; }

        #endregion

        #region " Function Definition "

        /// <summary>
        /// 이벤트 핸들러 생성
        /// </summary>
        private void EventHandler()
        {
            try
            {
                #region " Spread Event "
                this.udcLine.spdData.CellClick += new CellClickEventHandler(udcLine_CellClick);
                this.udcShop.spdData.CellClick += new CellClickEventHandler(udcShop_CellClick);
                #endregion

                #region " Button Event "
                this.btnView.Click += new System.EventHandler(btnView_Click);
                this.btnSelect.Click += new System.EventHandler(btnSelect_Click);
                this.btnClose.Click += new System.EventHandler(btnClose_Click);
                #endregion

                #region " CodeView Event "
                this.cdvLineCode.ButtonPress += new System.EventHandler(this.cdvLineCode_ButtonPress);
                this.cdvShopCode.ButtonPress += new System.EventHandler(this.cdvShopCode_ButtonPress);
                #endregion
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /// <summary>
        /// 초기화 함수
        /// </summary>
        /// <param name="s_step"></param>
        /// <returns></returns>
        private bool FunctionClear(string s_step)
        {
            try
            {
                switch (s_step)
                {
                    case CLEAR_ALL:
                        cdvLineCode.Init();
                        cdvShopCode.Init();
                        MakeSpreadColHeader(udcLine, dtLineBlank, ObjColumns(udcLine));
                        MakeSpreadCelType(udcLine, ObjColumns(udcLine));
                        MakeSpreadColHeader(udcShop, dtShopBlank, ObjColumns(udcShop));
                        MakeSpreadCelType(udcShop, ObjColumns(udcShop));
                        break;

                    case CLEAR_VIEW:
                        cdvShopCode.Init();
                        MakeSpreadColHeader(udcLine, dtLineBlank, ObjColumns(udcLine));
                        MakeSpreadCelType(udcLine, ObjColumns(udcLine));
                        MakeSpreadColHeader(udcShop, dtShopBlank, ObjColumns(udcShop));
                        MakeSpreadCelType(udcShop, ObjColumns(udcShop));
                        break;

                    default:
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

        /// <summary>
        /// 벨리데이션 함수
        /// </summary>
        /// <param name="s_step"></param>
        /// <returns></returns>
        private bool FunctionCondition(string s_step)
        {
            try
            {
                switch (s_step)
                {
                    case CONDITION_VIEW:
                        if (string.IsNullOrEmpty(MPCF.Trim(cdvLineCode.Text)) == true)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(518));
                            return false;
                        }

                        break;

                    default:
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

        /// <summary>
        /// 칼럼 정의
        /// </summary>
        /// <param name="fpSpd">스프레드</param>
        /// <returns></returns>
        private object[,] ObjColumns(udcSpread fpSpd)
        {
            object[,] ObjCol = null;

            try
            {
                switch (fpSpd.Name.ToString())
                {
                    #region "udcLine"
                    case "udcLine":
                        if (TYPE == TYPE_1)
                            ObjCol = new object[,] {
                                {"Line Code"    , 100, "LINE_CODE", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Line Desc"    , 100, "LINE_DESC", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Car Type"     , 50,  "CAR_TYPE", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Car Type Desc", 100, "CAR_TYPE_DESC", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Mat ID"       , 120, "MAT_ID", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Mat Desc"     , 200, "MAT_DESC", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Comment"      , 200, "LINE_COMMENT", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                               };
                        else if (TYPE == TYPE_2)
                            ObjCol = new object[,] {
                                {"Line Code"    , 100, "LINE_CODE", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Line Desc"    , 100, "LINE_DESC", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Car Type"     , 50,  "CAR_TYPE", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Car Type Desc", 100, "CAR_TYPE_DESC", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Comment"      , 200, "LINE_COMMENT", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                               };
                        else if (TYPE == TYPE_3)
                            ObjCol = new object[,] {
                                {"Line Code"    , 100, "LINE_CODE", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Line Desc"    , 100, "LINE_DESC", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                                {"Comment"      , 200, "LINE_COMMENT", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                               };
                        break;

                    #endregion

                    #region "udcShop"
                    case "udcShop":
                        ObjCol = new object[,] {
                            {"Shop Code", 100, "SHOP_CODE", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                            {"Shop Desc", 100, "SHOP_DESC", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                            {"Res ID"   , 100, "RES_ID", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                            {"Res Desc" , 100, "RES_DESC", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                            {"Char ID"  , 100, "CHAR_ID", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Right, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                            {"Char Desc", 100, "CHAR_DESC", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Center, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                            {"Comment"  , 200, "SHOP_COMMENT", udcFarpoint.SpreadCellType.TextCellType, udcFarpoint.SpreadCellHAlign.Left, udcFarpoint.SpreadCellVAlign.Center, udcFarpoint.SpreadCellMerge.None, false, true},
                            };
                        break;
                        
                    #endregion
                    default:
                        break;
                }
                return ObjCol;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return ObjCol;
            }
        }

        /// <summary>
        /// Cell Type
        /// </summary>
        /// <param name="fpSpd"></param>
        /// <param name="oCol"></param>
        /// <returns></returns>
        private bool MakeSpreadCelType(udcSpread ucSpd, object[,] oCol)
        {
            UCSpread sprMaker1 = new UCSpread();

            try
            {
                if (oCol != null)
                {
                    if (oCol.GetLongLength(0) > 0)
                    {
                        ucSpd.Tag = "Change Header";
                        sprMaker1.TargetSpread = ucSpd.spdData;
                        sprMaker1.TargetSheet = ucSpd.spdData.ActiveSheet;
                        sprMaker1.MakeSpreadCelType(ucSpd, oCol);
                        ucSpd.spdData.Sheets[0].ColumnHeader.Rows[0].Height = 40;
                        //ucSpd.spdData.ActiveSheet.ColumnHeader.Cells[0, 0].CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

                        //Span
                        //sprMaker1.SpreadSpan(UCSpread.SpreadPart.ColumnHeader, 0, (int)Cols1.PLANT, 2, 2, "Plant");

                        for (int i = 0; i < ucSpd.spdData.Sheets[0].Columns.Count; i++)
                            ucSpd.spdData.Sheets[0].Columns[i].Locked = true;

                        ucSpd.spdData.Sheets[0].SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
                        ucSpd.spdData.Sheets[0].SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;

                        MPCF.ConvertMessage(this.Controls);
                        sprMaker1.SpreadWidthResize(ucSpd, UCSpread.SpreadPart.Spread);

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

        /// <summary>
        /// Make Spread ColumnHeader
        /// </summary>
        /// <param name="fpSpd"></param>
        private void MakeSpreadColHeader(udcSpread ucSpd, DataTable tblData, object[,] oCol)
        {
            UCSpread sprMaker1 = new UCSpread();

            try
            {
                sprMaker1.bColumnHederAutoSpan = false;
                sprMaker1.MakeSpreadColHeader(ucSpd, tblData, oCol, 1);
                sprMaker1.SetHideColumn(ucSpd, iArryVisibleCols, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 작업장 목록
        /// </summary>
        /// <param name="s_line_code"></param>
        /// <returns></returns>
        private bool ViewLineList(string s_line_code)
        {
            DataTable dtTalbe = new DataTable();
            TPDR.DirectViewCond[] Condition = new TPDR.DirectViewCond[2];
            string s_query_id = string.Empty;

            try
            {
                Condition[0].sCondtion_ID = "FACTORY";
                Condition[0].sCondition_Value = MPGV.gsFactory;
                Condition[1].sCondtion_ID = "SHOP_CODE";
                Condition[1].sCondition_Value = s_line_code;

                if (TYPE == TYPE_1)
                    s_query_id = "ISPC0000-01";
                else if (TYPE == TYPE_2)
                    s_query_id = "ISPC0000-02";
                else if (TYPE == TYPE_3)
                    s_query_id = "ISPC0000-03";

                if (TPDR.GetDataOne(string.Empty, ref dtTalbe, s_query_id, Condition, false, false) == false)
                {
                    if (dtTalbe != null) { dtTalbe.Dispose(); }

                    if (dtTalbe.Rows.Count == 0)
                    {
                        dtTalbe.Dispose();
                        MPCF.ShowMsgBox(MPCF.GetMessage(244));
                    }
                    return false;
                }

                MakeSpreadColHeader(udcLine, dtTalbe, ObjColumns(udcLine));
                MakeSpreadCelType(udcLine, ObjColumns(udcLine));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 라인 목록
        /// </summary>
        /// <param name="s_shop_code"></param>
        /// <returns></returns>
        private bool ViewShopList(string s_shop_code,string s_mat_id)
        {
            DataTable dtTalbe = new DataTable();
            TPDR.DirectViewCond[] Condition = new TPDR.DirectViewCond[3];

            try
            {
                Condition[0].sCondtion_ID = "FACTORY";
                Condition[0].sCondition_Value = MPGV.gsFactory;
                Condition[1].sCondtion_ID = "LINE_CODE";
                Condition[1].sCondition_Value = s_shop_code;
                Condition[2].sCondtion_ID = "MAT_ID";
                Condition[2].sCondition_Value = s_mat_id;

                if (TPDR.GetDataOne(string.Empty, ref dtTalbe, "ISPC0000-04", Condition, false, false) == false)
                {
                    if (dtTalbe != null) { dtTalbe.Dispose(); }

                    if (dtTalbe.Rows.Count == 0)
                    {
                        dtTalbe.Dispose();
                        MPCF.ShowMsgBox(MPCF.GetMessage(244));
                    }
                    return false;
                }

                MakeSpreadColHeader(udcShop, dtTalbe, ObjColumns(udcShop));
                MakeSpreadCelType(udcShop, ObjColumns(udcShop));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                EventHandler();
                if (FunctionClear(CLEAR_ALL) == false) return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void udcLine_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            UCSpread sprMaker = new UCSpread();

            try
            {
                FarPoint.Win.Spread.FpSpread fpSpd = sender as FarPoint.Win.Spread.FpSpread;

                if (!e.ColumnHeader)
                {
                    if (e.Column >= 0)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            //HASH TABLE
                            htLineSelected = sprMaker.GetRowHashTable(udcLine.spdData, e.Row, null);

                            string s_line_code = MPCF.Trim(udcLine.spdData.ActiveSheet.GetValue(udcLine.iRow, (int)COL_LINE.COL_LINE_CODE));
                            string s_mat_id = MPCF.Trim(udcLine.spdData.ActiveSheet.GetValue(udcLine.iRow, (int)COL_LINE.COL_MAT_ID));

                            if (ViewShopList(s_line_code, s_mat_id) == false) return;                            
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            //ContextmenuStrip
                            udcLine.upContext = udcLine;
                            udcLine.dtSpreadData = _dtSpreadData;
                            udcLine.iRow = e.Row;
                            udcLine.iCol = e.Column;
                            udcLine.iArryVisibleCols = iArryVisibleCols;
                            udcLine.ObjColumns = ObjColumns(udcLine);
                            udcLine.sArrySearchCols = sArrySearchCols;
                            udcLine.tsSearchMenuEnabled = false;
                            udcLine.tsSearchTextEnabled = false;
                            this.ContextMenuStrip = udcLine.SortcontextMenuStrip;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void udcShop_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            UCSpread sprMaker = new UCSpread();

            try
            {
                FarPoint.Win.Spread.FpSpread fpSpd = sender as FarPoint.Win.Spread.FpSpread;

                if (!e.ColumnHeader)
                {
                    if (e.Column >= 0)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            //HASH TABLE
                            htShopSelected = sprMaker.GetRowHashTable(udcShop.spdData, e.Row, null);
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            //ContextmenuStrip
                            udcShop.upContext = udcShop;
                            udcShop.dtSpreadData = _dtSpreadData;
                            udcShop.iRow = e.Row;
                            udcShop.iCol = e.Column;
                            udcShop.iArryVisibleCols = iArryVisibleCols;
                            udcShop.ObjColumns = ObjColumns(udcShop);
                            udcShop.sArrySearchCols = sArrySearchCols;
                            udcShop.tsSearchMenuEnabled = false;
                            udcShop.tsSearchTextEnabled = false;
                            this.ContextMenuStrip = udcShop.SortcontextMenuStrip;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvLineCode_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvLineCode.Init();
                cdvLineCode.Columns.Add("SHOP_CODE", 100, HorizontalAlignment.Center);
                cdvLineCode.Columns.Add("SHOP_DESC", 100, HorizontalAlignment.Center);
                cdvLineCode.SelectedSubItemIndex = 0;

                MPOF.MFillData(cdvLineCode.GetListView, "ICOM0000-08", new string[] { "", "", "", "" });
                cdvLineCode.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvShopCode_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvShopCode.Init();
                cdvShopCode.Columns.Add("SHOP_CODE", 100, HorizontalAlignment.Center);
                cdvShopCode.Columns.Add("SHOP_DESC", 100, HorizontalAlignment.Center);
                cdvShopCode.SelectedSubItemIndex = 0;

                string s_shop_code = MPCF.Trim(cdvLineCode.Text);

                MPOF.MFillData(cdvShopCode.GetListView, "ICOM0000-01", new string[] { "", s_shop_code });
                cdvShopCode.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (FunctionCondition(CONDITION_VIEW) == false) return;

            string s_line_code = MPCF.Trim(cdvLineCode.Text);

            if (ViewLineList(s_line_code) == false) return;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (FunctionCondition(CONDITION_SELECT) == false) return;

            SELECT_SHOP_CODE = MPCF.Trim(htLineSelected["LINE_CODE"]);
            SELECT_SHOP_DESC = MPCF.Trim(htLineSelected["LINE_DESC"]);
            SELECT_CAR_TYPE = MPCF.Trim(htLineSelected["CAR_TYPE"]);
            SELECT_CAR_TYPE_DESC = MPCF.Trim(htLineSelected["CAR_TYPE_DESC"]);
            SELECT_MAT_ID = MPCF.Trim(htLineSelected["MAT_ID"]);
            SELECT_MAT_DESC = MPCF.Trim(htLineSelected["MAT_DESC"]);
            SELECT_LINE_CODE = MPCF.Trim(htShopSelected["SHOP_CODE"]);
            SELECT_LINE_DESC = MPCF.Trim(htShopSelected["SHOP_DESC"]);
            SELECT_RES_ID = MPCF.Trim(htShopSelected["RES_ID"]);
            SELECT_RES_DESC = MPCF.Trim(htShopSelected["RES_DESC"]);
            SELECT_CHAR_ID = MPCF.Trim(htShopSelected["CHAR_ID"]);
            SELECT_CHAR_DESC = MPCF.Trim(htShopSelected["CHAR_DESC"]);
            SELECT_UPPER_SPEC_LIMIT = MPCF.Trim(htShopSelected["UPPER_SPEC_LIMIT"]);
            SELECT_UPPER_WARN_LIMIT = MPCF.Trim(htShopSelected["UPPER_WARN_LIMIT"]);
            SELECT_TARGET_VALUE = MPCF.Trim(htShopSelected["TARGET_VALUE"]);
            SELECT_LOWER_WARN_LIMIT = MPCF.Trim(htShopSelected["LOWER_WARN_LIMIT"]);
            SELECT_LOWER_SPEC_LIMIT = MPCF.Trim(htShopSelected["LOWER_SPEC_LIMIT"]);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
