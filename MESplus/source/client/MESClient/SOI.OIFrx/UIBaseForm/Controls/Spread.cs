/*---------------------------------------------------------------------------------------------------
 
    PROG ID		: classSpread
    Creator		: MoSangHun(Miracom)
    Create Date	: 
    Description	: 
 
    History		: 2010.03.05 Sunghee Park.  재 생성하여 추가.
----------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Collections;
//==
using FarPoint.Win;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using System.Drawing;
using System.Windows.Forms;
using Miracom.CliFrx;

namespace SOI.OIFrx
{
    public class Spread : classSpread
    {
        #region Variables

        #region Enums
        /// <summary>
        /// Spread Column Attribute
        /// </summary>
        private enum ColTp : int
        {
            sLabel, iWidth, sKey, CelType, CelHalign, CelValign, CelMerge, bHide, bLock
        }

        /// <summary>
        /// Column 속성을 지정할 항목
        /// Column Header : LABEL, WIDTH
        /// Column : FIELD, TYPE, HALIGN, VALIGN, MERGE, HIDE, LOCK
        /// </summary>
        public enum ColumnProperty
        {
            LABEL,
            WIDTH,
            FIELD,
            TYPE,
            HALIGN,
            VALIGN,
            MERGE,
            HIDE,
            LOCK
        }

        /// <summary>
        /// Row 속성을 지정할 항목
        /// Row Header : LABEL, WIDTH, HEIGHT
        /// </summary>
        public enum RowProperty
        {
            LABEL,
            WIDTH,
            HEIGHT,
            HALIGN,
            VALIGN,
            MERGE,
            HIDE,
            LOCK
        }

        public enum SpreadCellType
        {
            CheckBoxCellType,
            TextCellType,
            NumberCellType,
            LongNumberCellType,
            DateTimeCellType,
            LongDateTimeCellType,
            ComboBoxCellType,
            HyperLinkCellType

            //BarCodeCellType,
            //ButtonCellType,
            //CheckBoxCellType,
            //ColorPickerCellType,
            //ComboBoxCellType,
            //EditBaseCellType,
            //HyperLinkCellType,
            //ImageCellType,
            //ListBoxCellType,
            //MultiColumnComboBoxCellType,
            //MultiOptionCellType,
            //ProgressCellType,
            //RichTextCellType,
            //SliderCellType,
            //CurrencyCellType,
            //DateTimeCellType,
            //LongDateTimeCellType,
            //EmptyCellType,
            //GeneralCellType,
            //MaskCellType,
            //NumberCellType,
            //LongNumberCellType,
            //PercentCellType,
            //RegularExpressionCellType,
            //TextCellType
        }

        public enum SpreadCellHAlign
        {
            Left,
            Center,
            Right
        }

        public enum SpreadCellVAlign
        {
            Top,
            Center,
            Bottom
        }

        public enum SpreadCellMerge
        {
            None,
            Always,
            Restricted
        }

        public enum SpreadPart
        {
            Row,
            Column,
            RowHeader,
            ColumnHeader,
            Sheet,
            spread,
            Cell
        }

        public enum WorkType
        {
            Row,
            Column
        }

        public enum AcceptRange
        {
            spread,
            classSpread
        }

        #endregion

        #region Using Variables

        private FarPoint.Win.Spread.FpSpread TargetSpd = new FpSpread();
        private FarPoint.Win.Spread.SheetView TargetSv = new SheetView();

        private int intCololumnHeaderRowCount = 1;
        private int intCololumnHeaderColumnCount = 1;
        private int intRowHeaderColoumnCount = 1;
        private int intRowHeaderRowCount = 1;

        private bool boolColumnHederAutoSpan = true;
        private bool boolRowHeaderAutoSpan = true;

        private string[] arrColumnProperty = (string.Join(",", Enum.GetNames(typeof(ColumnProperty)))).Split(',');
        private string[] arrRowProperty = (string.Join(",", Enum.GetNames(typeof(RowProperty)))).Split(',');
        private string[] arrSpreadCellType = (string.Join(",", Enum.GetNames(typeof(SpreadCellType)))).Split(',');
        private string[] arrSpreadCellHAlign = (string.Join(",", Enum.GetNames(typeof(SpreadCellHAlign)))).Split(',');
        private string[] arrSpreadCellVAlign = (string.Join(",", Enum.GetNames(typeof(SpreadCellVAlign)))).Split(',');

        //Column Setting Property Table
        private DataTable dtColumnSet = new DataTable();
        //Row Setting Property Table
        private DataTable dtRowSet = new DataTable();
        List<DataTable> lstDtRowSet = new List<DataTable>();
        List<int> lstWidth = new List<int>();

        string sLabel = string.Empty;
        int iWidth = 0;
        string sKey = string.Empty;
        DateTimePickerCellType DtPick = new DateTimePickerCellType();
        Spread.SpreadCellType CelType = Spread.SpreadCellType.TextCellType;
        Spread.SpreadCellHAlign CelHalign = Spread.SpreadCellHAlign.Center;
        Spread.SpreadCellVAlign CelValign = Spread.SpreadCellVAlign.Center;
        Spread.SpreadCellMerge CelMerge = Spread.SpreadCellMerge.None;
        bool bHide = false;
        bool bLock = true;

        //string sButtonText = "...";

        #endregion

        #endregion

        #region Get / Set

        //Working spread Set
        [Category("Setring Property")]
        [Description("설정을 적용할 spread")]
        new public FpSpread TargetSpread
        {
            get
            {
                TargetSpd = base.TargetSpread;
                return TargetSpd;
            }
            set
            {
                TargetSpd = value;
                base.TargetSpread = TargetSpd;
            }
        }

        //Working spread Sheet Set
        [Category("Setring Property")]
        [Description("설정을 적용할 Spread의 설정을 적용할 Sheet")]
        public SheetView TargetSheet
        {
            get
            {
                TargetSv = base.TargetSpread.ActiveSheet;
                return TargetSv;
            }
            set
            {
                TargetSv = value;
                base.TargetSpread.ActiveSheet = TargetSv;
            }
        }

        //ColumnHeader 의 RowCount
        [Category("Setring Property")]
        [Description("Column Header의 RowCount를 설정한다.")]
        [DefaultValue(1)]
        public int iColHRowCnt
        {
            get { return intCololumnHeaderRowCount; }
            set { intCololumnHeaderRowCount = value; }
        }

        //ColumnHeader 의 ColumnCount
        [Category("Setring Property")]
        [Description("Column Header의 ColumnCount를 설정한다.")]
        [DefaultValue(1)]
        public int iColHColCnt
        {
            get { return intCololumnHeaderColumnCount; }
            set { intCololumnHeaderColumnCount = value; }
        }

        //RowHeader 의 RowCount
        [Category("Setring Property")]
        [Description("RowHeader의 RowCount를 설정한다.")]
        [DefaultValue(1)]
        public int iRowHRowCnt
        {
            get { return intRowHeaderRowCount; }
            set { intRowHeaderRowCount = value; }
        }

        //RowHeader 의 ColumnCount
        [Category("Setring Property")]
        [Description("Row Header의 ColumnCount를 설정한다.")]
        [DefaultValue(1)]
        public int iRowHColCnt
        {
            get { return intRowHeaderColoumnCount; }
            set { intRowHeaderColoumnCount = value; }
        }

        [Category("Setring Property")]
        [Description("ColumnHeader의 Auto Span을 설정한다.")]
        [DefaultValue(true)]
        public bool bColumnHederAutoSpan
        {
            get { return boolColumnHederAutoSpan; }
            set { boolColumnHederAutoSpan = value; }
        }

        [Category("Setring Property")]
        [Description("RowHeader의 Auto Span을 설정한다.")]
        [DefaultValue(true)]
        public bool bRowHeaderAutoSpan
        {
            get { return boolRowHeaderAutoSpan; }
            set { boolRowHeaderAutoSpan = value; }
        }

        #endregion

        # region Function

        #region Internal Function

        /// <summary>
        /// 초기화
        /// </summary>
        new public void InitializeSpread()
        {
            //classSpared의 초기화
            base.InitializeSpread();

            TargetSpd = null;
            TargetSv = null;

            dtColumnSet = new DataTable();
            SetdtColSet();

            dtRowSet = new DataTable();
            SetdtRowSet();
            lstWidth = new List<int>();
        }

        #region Column Set

        /// <summary>
        /// ColumnHeader 와 Column 세팅값을 저장할 DataTable
        /// : LABEL, WIDTH, FIELD, TYPE, HALIGN, VALIGN, MERGE, HIDE, LOCK
        /// </summary>
        private void SetdtColSet()
        {
            dtColumnSet.TableName = "SetColumnProperty";

            dtColumnSet.Columns.Add(ColumnProperty.LABEL.ToString(), typeof(string));
            dtColumnSet.Columns.Add(ColumnProperty.WIDTH.ToString(), typeof(int));
            dtColumnSet.Columns.Add(ColumnProperty.FIELD.ToString(), typeof(string));
            dtColumnSet.Columns.Add(ColumnProperty.TYPE.ToString(), typeof(string));
            dtColumnSet.Columns.Add(ColumnProperty.HALIGN.ToString(), typeof(string));
            dtColumnSet.Columns.Add(ColumnProperty.VALIGN.ToString(), typeof(string));
            dtColumnSet.Columns.Add(ColumnProperty.MERGE.ToString(), typeof(string));
            dtColumnSet.Columns.Add(ColumnProperty.HIDE.ToString(), typeof(bool));
            dtColumnSet.Columns.Add(ColumnProperty.LOCK.ToString(), typeof(bool));
        }

        #region Column Add Method

        /// <summary>
        /// Column을 추가하며 속성을 설정한다 (모든 속성 설정)
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="witdh"></param>
        /// <param name="height"></param>
        /// <param name="DataField"></param>
        /// <param name="cellType"></param>
        /// <param name="halign"></param>
        /// <param name="valign"></param>
        /// <param name="merge"></param>
        /// <param name="hide"></param>
        /// <param name="Lock"></param>
        public void ColumnAdd(string Label, int Width
                                    , string DataField
                                    , SpreadCellType cellType
                                    , SpreadCellHAlign hAlign
                                    , SpreadCellVAlign vAlign
                                    , SpreadCellMerge Merge
                                    , bool Hide
                                    , bool Lock)
        {
            dtColumnSet.Rows.Add(Label, Width, DataField, cellType.ToString(), hAlign.ToString(), vAlign.ToString(), Merge.ToString(), Hide, Lock);
            lstWidth.Add(Width);
        }

        /// <summary>
        /// Column을 추가하며 속성을 설정한다 
        /// (string Label, int Witdh 설정)
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="witdh"></param>
        public void ColumnAdd(string Label, int Witdh)
        {
            ColumnAdd(Label, Witdh, string.Empty, SpreadCellType.TextCellType, SpreadCellHAlign.Left, SpreadCellVAlign.Center, SpreadCellMerge.None, false, false);
        }

        /// <summary>
        /// Column을 추가하며 속성을 설정한다 
        /// (string Label, int witdh, SpreadCellMerge merge 설정)
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="witdh"></param>
        /// <param name="merge"></param>
        public void ColumnAdd(string Label, int witdh
                                    , SpreadCellMerge merge)
        {
            ColumnAdd(Label, witdh, string.Empty, SpreadCellType.TextCellType, SpreadCellHAlign.Left, SpreadCellVAlign.Center, merge, false, false);
        }

        /// <summary>
        /// Column을 추가하며 속성을 설정한다 
        /// (string Label, int witdh, SpreadCellMerge merge, bool hide 설정)
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="witdh"></param>
        /// <param name="hide"></param>
        public void ColumnAdd(string Label, int witdh
                                    , SpreadCellMerge merge
                                    , bool hide)
        {
            ColumnAdd(Label, witdh, string.Empty, SpreadCellType.TextCellType, SpreadCellHAlign.Left, SpreadCellVAlign.Center, merge, hide, false);
        }

        /// <summary>
        /// Column을 추가하며 속성을 설정한다 
        /// (string Label, int witdh, string DataField, SpreadCellType cellType 설정)
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="witdh"></param>
        /// <param name="DataField"></param>
        /// <param name="cellType"></param>
        public void ColumnAdd(string Label, int witdh
                                    , string DataField
                                    , SpreadCellType cellType)
        {
            ColumnAdd(Label, witdh, DataField, cellType, SpreadCellHAlign.Left, SpreadCellVAlign.Center, SpreadCellMerge.None, false, false);
        }

        /// <summary>
        /// Column을 추가하며 속성을 설정한다 
        /// (string Label, int witdh, string DataField, SpreadCellType cellType, SpreadCellHAlign halign 설정)
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="witdh"></param>
        /// <param name="DataField"></param>
        /// <param name="cellType"></param>
        /// <param name="halign"></param>
        public void ColumnAdd(string Label, int witdh
                                    , string DataField
                                    , SpreadCellType cellType
                                    , SpreadCellHAlign halign)
        {
            ColumnAdd(Label, witdh, DataField, cellType, halign, SpreadCellVAlign.Center, SpreadCellMerge.None, false, false);
        }

        /// <summary>
        /// Column을 추가하며 속성을 설정한다 
        /// (string Label, int witdh, string DataField, SpreadCellType cellType, SpreadCellHAlign halign, SpreadCellMerge merge 설정)
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="witdh"></param>
        /// <param name="DataField"></param>
        /// <param name="cellType"></param>
        /// <param name="halign"></param>
        /// <param name="merge"></param>
        public void ColumnAdd(string Label, int witdh
                                    , string DataField
                                    , SpreadCellType cellType
                                    , SpreadCellHAlign halign
                                    , SpreadCellMerge merge)
        {
            ColumnAdd(Label, witdh, DataField, cellType, halign, SpreadCellVAlign.Center, merge, false, false);
        }

        /// <summary>
        /// Column을 추가하며 속성을 설정한다 
        /// (string Label, int witdh, string DataField, SpreadCellType cellType, SpreadCellHAlign halign, SpreadCellMerge merge, bool hide 설정)			
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="witdh"></param>
        /// <param name="DataField"></param>
        /// <param name="cellType"></param>
        /// <param name="halign"></param>
        /// <param name="hide"></param>
        public void ColumnAdd(string Label, int witdh
                                    , string DataField
                                    , SpreadCellType cellType
                                    , SpreadCellHAlign halign
                                    , SpreadCellMerge merge
                                    , bool hide)
        {
            ColumnAdd(Label, witdh, DataField, cellType, halign, SpreadCellVAlign.Center, merge, hide, false);
        }

        #endregion

        #endregion

        #region Row Set

        /// <summary>
        /// RowHeader 와 Row 세팅값을 저장할 DataTable
        /// : SEQ, LABEL, WIDTH, FIELD, TYPE, VALIGN, HIDE, LOCK
        /// </summary>
        private void SetdtRowSet()
        {
            dtRowSet.TableName = "SetRowProperty";

            dtRowSet.Columns.Add(RowProperty.LABEL.ToString(), typeof(string));
            dtRowSet.Columns.Add(RowProperty.HEIGHT.ToString(), typeof(int));
            dtRowSet.Columns.Add(RowProperty.HALIGN.ToString(), typeof(string));
            dtRowSet.Columns.Add(RowProperty.VALIGN.ToString(), typeof(string));
            dtRowSet.Columns.Add(RowProperty.MERGE.ToString(), typeof(string));
            dtRowSet.Columns.Add(RowProperty.HIDE.ToString(), typeof(bool));
            dtRowSet.Columns.Add(RowProperty.LOCK.ToString(), typeof(bool));
            dtRowSet.Columns.Add(RowProperty.WIDTH.ToString(), typeof(int));
        }

        #region Row Add Method

        /// <summary>
        /// Row를 추가하며 속성을 설정한다 (모든 속성 설정)
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="Witdh"></param>
        /// <param name="Height"></param>
        /// <param name="hAlign"></param>
        /// <param name="vAlign"></param>
        /// <param name="Merge"></param>
        /// <param name="Hide"></param>
        /// <param name="Lock"></param>
        public void RowAdd(string Label, int Height
                                    , SpreadCellHAlign hAlign
                                    , SpreadCellVAlign vAlign
                                    , SpreadCellMerge Merge
                                    , bool Hide
                                    , bool Lock)
        {
            dtRowSet.Rows.Add(Label, Height, hAlign.ToString(), vAlign.ToString(), Merge.ToString(), Hide, Lock);
        }


        /// <summary>
        /// Row를 추가하며 속성을 설정한다 
        /// (string Label, int Height 설정)
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="Height"></param>
        public void RowAdd(string Label, int Height)
        {
            RowAdd(Label, Height, SpreadCellHAlign.Center, SpreadCellVAlign.Center, SpreadCellMerge.None, false, false);
        }

        /// <summary>
        /// Row를 추가하며 속성을 설정한다 
        /// (string Label, int Height, SpreadCellVAlign valign 설정)
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="Height"></param>
        /// <param name="valign"></param>
        public void RowAdd(string Label, int Height
                                    , SpreadCellVAlign valign)
        {
            RowAdd(Label, Height, SpreadCellHAlign.Center, valign, SpreadCellMerge.None, false, false);
        }

        /// <summary>
        /// Row를 추가하며 속성을 설정한다 
        /// (string Label, int Height, bool hide 설정)
        /// </summary>
        /// <param name="Label"></param>
        /// <param name="Height"></param>
        /// <param name="hide"></param>
        public void RowAdd(string Label, int Height
                                    , bool hide)
        {
            RowAdd(Label, Height, SpreadCellHAlign.Center, SpreadCellVAlign.Center, SpreadCellMerge.None, hide, false);
        }

        public void RowHeaderColumnAdd(string Label, int Height
                    , SpreadCellHAlign hAlign
                    , SpreadCellVAlign vAlign
                    , SpreadCellMerge Merge
                    , bool Hide
                    , bool Lock
                    , int Width)
        {
            dtRowSet = new DataTable();
            SetdtRowSet();
            dtRowSet.Rows.Add(Label, Height, hAlign.ToString(), vAlign.ToString(), Merge.ToString(), Hide, Lock, Width);
            lstDtRowSet.Add(dtRowSet);
        }

        #endregion

        #endregion

        #region spread & Sheet Set

        public void SetSpSheetSort(FarPoint.Win.Spread.SortInfo[] sortInfo)
        {
            //기존 Sort 정보 적용하기
            SetSpSheetSort(TargetSpd, TargetSv, sortInfo);
        }

        public void SetSpSheetSort(FarPoint.Win.Spread.FpSpread spd, FarPoint.Win.Spread.SheetView sv, FarPoint.Win.Spread.SortInfo[] sortInfo)
        {
            //Working Target Setting
            if (spd != null) { TargetSpd = spd; }		//spd Setting
            if (sv != null) { TargetSv = sv; }		//spdsv Setting
            if (TargetSpd != null && TargetSv == null) { TargetSv = TargetSpd.ActiveSheet; }

            //실행조건
            if (TargetSpd == null) { return; }
            if (TargetSv == null) { return; }
            if (dtColumnSet.Rows.Count < 1) { return; }

            //기존 Sort 정보 적용하기
            if (sortInfo != null)
            {
                TargetSpd.ActiveSheet.SortRows(0, TargetSpd.ActiveSheet.RowCount, sortInfo);
            }
        }

        public void SetColumWidth()
        {
            for (int i = 0; i < lstWidth.Count; i++)
            {
                TargetSpd.ActiveSheet.Columns[i].Width = lstWidth[i];
            }
        }

        public void SetSpSheet()
        {
            SetSpSheetColumn(TargetSpd, TargetSv);
            SetSpSheetRow(TargetSpd, TargetSv);
            //SpreadCellPadding(TargetSpd);	

            SetColumWidth(); // 새로추가 seoio 2009.11.18
        }

        public void SetSpSheet(FarPoint.Win.Spread.FpSpread spd)
        {
            SetSpSheetColumn(spd, spd.ActiveSheet);
            SetSpSheetRow(spd, spd.ActiveSheet);
            //SpreadCellPadding(TargetSpd);		
        }

        public void SetSpSheet(FarPoint.Win.Spread.FpSpread spd, FarPoint.Win.Spread.SheetView sv)
        {
            SetSpSheetColumn(spd, sv);
            SetSpSheetRow(spd, sv);
            //SpreadCellPadding(TargetSpd);		
        }

        public void SetSpSheetColumn(FarPoint.Win.Spread.FpSpread spd, FarPoint.Win.Spread.SheetView sv)
        {
            //Working Target Setting
            if (spd != null) { TargetSpd = spd; }		//spd Setting
            if (sv != null) { TargetSv = sv; }		//spdsv Setting
            if (TargetSpd != null && TargetSv == null) { TargetSv = TargetSpd.ActiveSheet; }

            //실행조건
            if (TargetSpd == null) { return; }
            if (TargetSv == null) { return; }
            if (dtColumnSet.Rows.Count < 1) { return; }

            //ColumnHeader의 Row Count
            int iHeaderRowCnt = intCololumnHeaderRowCount;
            //Column Header Column Count
            int iHeaderColCnt = dtColumnSet.Rows.Count;
            //Column Header Count Setting
            TargetSpd.ActiveSheet.ColumnHeader.Rows.Count = iHeaderRowCnt;
            TargetSpd.ActiveSheet.ColumnHeader.Columns.Count = iHeaderColCnt;
            //The Protect property must be set to true if you want the cells to be locked from user input.
            TargetSpd.ActiveSheet.Protect = true;

            //ColumnHeader의 Row를 iHeaderRowCnt만큼 생성한다.
            for (int hRowCnt = 0; hRowCnt < iHeaderRowCnt; hRowCnt++)
            {
                for (int iCnt = 0; iCnt < dtColumnSet.Rows.Count; iCnt++)
                {
                    for (int jCnt = 0; jCnt < dtColumnSet.Columns.Count; jCnt++)
                    {
                        #region //LABEL
                        //Column Header 에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.LABEL.ToString())
                        {

                            if (dtColumnSet.Rows[iCnt][ColumnProperty.LABEL.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.ColumnHeader.Cells.Get(hRowCnt, iCnt).Value
                                            = dtColumnSet.Rows[iCnt][ColumnProperty.LABEL.ToString()];
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.ColumnHeader.Cells.Get(hRowCnt, iCnt).Value
                                            = "";
                            }

                        }
                        #endregion

                        #region //WIDTH
                        //Column Header 에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.WIDTH.ToString())
                        {
                            int idefwidth = 60;
                            int iwidth = 0;

                            if (Int32.TryParse(dtColumnSet.Rows[iCnt][ColumnProperty.WIDTH.ToString()].ToString(), out iwidth))
                            {
                                if (iwidth < 1) { iwidth = idefwidth; }

                                TargetSpd.ActiveSheet.ColumnHeader.Columns[iCnt].Width
                                    = iwidth;
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.ColumnHeader.Columns[iCnt].Width
                                    = idefwidth;
                            }
                        }
                        #endregion

                        #region //FIELD
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.FIELD.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].DataField
                                    = dtColumnSet.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString();
                            }
                        }
                        #endregion

                        #region //TYPE
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.TYPE.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].CellType
                                    = TakeCellType(dtColumnSet.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString());
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].CellType
                                    = TakeCellType(SpreadCellType.TextCellType.ToString());
                            }
                        }
                        #endregion

                        #region //HALIGN
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.HALIGN.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].HorizontalAlignment
                                        = TakeCellHAlign(dtColumnSet.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString());
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].HorizontalAlignment
                                    = CellHorizontalAlignment.Left;
                            }
                        }
                        #endregion

                        #region //VALIGN
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.VALIGN.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].VerticalAlignment
                                        = TakeCellVAlign(dtColumnSet.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString());
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].VerticalAlignment
                                    = CellVerticalAlignment.Center;
                            }
                        }
                        #endregion

                        #region //MERGE
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.MERGE.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].MergePolicy
                                        = TakeMergePolicy(dtColumnSet.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString());
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].MergePolicy
                                    = FarPoint.Win.Spread.Model.MergePolicy.None;
                            }
                        }
                        #endregion

                        #region //HIDE
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.HIDE.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.HIDE.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].Visible
                                        = !((bool)dtColumnSet.Rows[iCnt][ColumnProperty.HIDE.ToString()]);
                                //HIDE : Visible 이므로 속성값의 반대로 세팅
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].Visible
                                    = true;
                            }
                        }
                        #endregion

                        #region //LOCK
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.LOCK.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.LOCK.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].Locked
                                        = (bool)dtColumnSet.Rows[iCnt][ColumnProperty.LOCK.ToString()];
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Columns[iCnt].Locked
                                    = false;
                            }
                        }
                        #endregion
                    }
                }


                if (boolColumnHederAutoSpan)
                {
                    //Column Span
                    //Column Header 의 Row Count 가 1을 초과하면 Column을 Span 해준다.
                    //이 후에 Column Header의 Row를 Span해준다.
                    for (int iCnt = 0; iCnt < iHeaderColCnt; iCnt++)
                    {
                        TargetSpd.ActiveSheet.ColumnHeader.Cells[0, iCnt].RowSpan = hRowCnt + 1;
                    }
                }

            }
        }

        #region [  SetSpSheetRow 작업전 원본 ]

        /*
        public void SetSpSheetRow(FarPoint.Win.Spread.FpSpread spd, FarPoint.Win.Spread.SheetView sv)
        {
            //Working Target Setting
            if (spd != null) { TargetSpd = spd; }		//spd Setting
            if (sv != null) { TargetSv = sv; }		//spdsv Setting
            if (TargetSpd != null && TargetSv == null) { TargetSv = TargetSpd.ActiveSheet; }

            //실행조건
            if (TargetSpd == null) { return; }
            if (TargetSv == null) { return; }
            if (dtRowSet.Rows.Count < 1) { return; }

            //RowHeader의 Row Count
            int iHeaderRowCnt = dtRowSet.Rows.Count;
            //RowHeader Column Count
            int iHeaderColCnt = intRowHeaderColoumnCount;
            //RowHeader Count Setting
            TargetSpd.ActiveSheet.RowHeader.Rows.Count = iHeaderRowCnt;
            TargetSpd.ActiveSheet.RowHeader.Columns.Count = ((UseRowFixHeader == true) ? iHeaderColCnt : 1);   //RowHeader 사용여부에 따라 값세팅
            //The Protect property must be set to true if you want the cells to be locked from user input.
            TargetSpd.ActiveSheet.Protect = true;

            //RowHeader의 Column을 iHeaderColCnt만큼 생성한다
            for (int hColCnt = 0; hColCnt < iHeaderColCnt; hColCnt++)
            {
                for (int iCnt = 0; iCnt < dtRowSet.Rows.Count; iCnt++)
                {
                    for (int jCnt = 0; jCnt < dtRowSet.Columns.Count; jCnt++)
                    {
                        #region //LABEL
                        //RowHeader 에 적용
                        if (dtRowSet.Columns[jCnt].ColumnName == RowProperty.LABEL.ToString())
                        {
                            //RowHeader를 Header형태로 사용할지 아니면 Row에 Fix시켜서 사용할지 유무를 결정
                            //RowHeader를 Header형태로 사용
                            if (UseRowFixHeader)
                            {
                                if (dtRowSet.Rows[iCnt][RowProperty.LABEL.ToString()].ToString() != "")
                                {
                                    TargetSpd.ActiveSheet.RowHeader.Cells.Get(iCnt, hColCnt).Value
                                                = dtRowSet.Rows[iCnt][RowProperty.LABEL.ToString()];
                                }
                                else
                                {
                                    TargetSpd.ActiveSheet.RowHeader.Cells.Get(iCnt, hColCnt).Value
                                                = "";
                                }
                            }
                            //RowHeader를 Row에 Fix시켜서 사용
                            else
                            {
                                if (dtRowSet.Rows[iCnt][RowProperty.LABEL.ToString()].ToString() != "")
                                {
                                    TargetSpd.ActiveSheet.Cells.Get(iCnt, hColCnt).Value
                                                = dtRowSet.Rows[iCnt][RowProperty.LABEL.ToString()];
                                }
                                else
                                {
                                    TargetSpd.ActiveSheet.Cells.Get(iCnt, hColCnt).Value
                                                = "";
                                }
                            }

                        }
                        #endregion

                        #region //HEIGHT
                        //Row 에 적용
                        if (dtRowSet.Columns[jCnt].ColumnName == RowProperty.HEIGHT.ToString())
                        {
                            int idefheight = 20;
                            int iheight = 0;

                            if (Int32.TryParse(dtRowSet.Rows[iCnt][RowProperty.HEIGHT.ToString()].ToString(), out iheight))
                            {
                                if (iheight < 1) { iheight = idefheight; }

                                TargetSpd.ActiveSheet.Rows[iCnt].Height
                                    = iheight;
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Rows[iCnt].Height
                                    = idefheight;
                            }
                        }
                        #endregion

                        #region //HALIGN
                        //Row에 적용
                        if (dtRowSet.Columns[jCnt].ColumnName == RowProperty.HALIGN.ToString())
                        {
                            if (dtRowSet.Rows[iCnt][RowProperty.HALIGN.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Rows[iCnt].HorizontalAlignment
                                        = TakeCellHAlign(dtRowSet.Rows[iCnt][RowProperty.HALIGN.ToString()].ToString());
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Rows[iCnt].HorizontalAlignment
                                    = CellHorizontalAlignment.Center;
                            }
                        }
                        #endregion

                        #region //VALIGN
                        //Row에 적용
                        if (dtRowSet.Columns[jCnt].ColumnName == RowProperty.VALIGN.ToString())
                        {
                            if (dtRowSet.Rows[iCnt][RowProperty.VALIGN.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Rows[iCnt].VerticalAlignment
                                        = TakeCellVAlign(dtRowSet.Rows[iCnt][RowProperty.VALIGN.ToString()].ToString());
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Rows[iCnt].VerticalAlignment
                                    = CellVerticalAlignment.Center;
                            }
                        }
                        #endregion

                        #region //MERGE
                        //Row에 적용
                        if (dtRowSet.Columns[jCnt].ColumnName == RowProperty.MERGE.ToString())
                        {
                            if (dtRowSet.Rows[iCnt][RowProperty.MERGE.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Rows[iCnt].MergePolicy
                                        = TakeMergePolicy(dtRowSet.Rows[iCnt][RowProperty.MERGE.ToString()].ToString());
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Rows[iCnt].MergePolicy
                                    = FarPoint.Win.Spread.Model.MergePolicy.None;
                            }
                        }
                        #endregion

                        #region //HIDE
                        //Row에 적용
                        if (dtRowSet.Columns[jCnt].ColumnName == RowProperty.HIDE.ToString())
                        {
                            if (dtRowSet.Rows[iCnt][RowProperty.HIDE.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Rows[iCnt].Visible
                                        = !((bool)dtRowSet.Rows[iCnt][RowProperty.HIDE.ToString()]);
                                //HIDE : Visible 이므로 속성값의 반대로 세팅
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Rows[iCnt].Visible
                                    = true;
                            }
                        }
                        #endregion

                        #region //LOCK
                        //Row에 적용
                        if (dtRowSet.Columns[jCnt].ColumnName == RowProperty.LOCK.ToString())
                        {
                            if (dtRowSet.Rows[iCnt][RowProperty.LOCK.ToString()].ToString() != "")
                            {
                                TargetSpd.ActiveSheet.Rows[iCnt].Locked
                                        = (bool)dtRowSet.Rows[iCnt][RowProperty.LOCK.ToString()];
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Rows[iCnt].Locked
                                    = false;
                            }
                        }
                        #endregion

                        #region //WIDTH
                        //Row에 적용
                        if (dtRowSet.Columns[jCnt].ColumnName == RowProperty.WIDTH.ToString())
                        {
                            TargetSpd.ActiveSheet.RowHeader.Columns[hColCnt].Width = int.Parse( dtRowSet.Rows[iCnt][RowProperty.WIDTH.ToString()].ToString());
                        }
                        #endregion
                    }
                }


                if (boolRowHeaderAutoSpan)
                {
                    //Row Span
                    //Row Header 의 Column Count 가 1을 초과하면 Row를 Span 해준다.
                    //이 후에 Column Header의 Row를 Span해준다.
                    for (int iCnt = 0; iCnt < iHeaderRowCnt; iCnt++)
                    {
                        if (UseRowFixHeader)
                        {
                            TargetSpd.ActiveSheet.RowHeader.Cells[iCnt, 0].ColumnSpan = hColCnt + 1;
                        }
                        else
                        {
                            TargetSpd.ActiveSheet.Cells[iCnt, 0].ColumnSpan = hColCnt + 1;
                        }
                    }
                }

            }
        }
        */

        #endregion

        /// <summary>
        /// RowHeader / Row
        /// </summary>
        /// <param name="spd"></param>
        /// <param name="sv"></param>
        public void SetSpSheetRow(FarPoint.Win.Spread.FpSpread spd, FarPoint.Win.Spread.SheetView sv)
        {
            //Working Target Setting
            if (spd != null) { TargetSpd = spd; }		//spd Setting
            if (sv != null) { TargetSv = sv; }		//spdsv Setting
            if (TargetSpd != null && TargetSv == null) { TargetSv = TargetSpd.ActiveSheet; }

            //실행조건
            if (TargetSpd == null) { return; }
            if (TargetSv == null) { return; }
            if (dtRowSet.Rows.Count < 1) { return; }

            //RowHeader의 Row Count
            int iHeaderRowCnt = iRowHRowCnt;
            //RowHeader Column Count
            int iHeaderColCnt = lstDtRowSet.Count;
            //RowHeader Count Setting
            TargetSpd.ActiveSheet.RowHeader.Rows.Count = iHeaderRowCnt;
            TargetSpd.ActiveSheet.RowHeader.Columns.Count = ((UseRowFixHeader == true) ? iHeaderColCnt : 1);   //RowHeader 사용여부에 따라 값세팅
            //The Protect property must be set to true if you want the cells to be locked from user input.
            TargetSpd.ActiveSheet.Protect = true;


            for (int hRowCnt = 0; hRowCnt < iHeaderRowCnt; hRowCnt++)
            {
                for (int i = 0; i < lstDtRowSet.Count; i++)
                {
                    DataTable tblColumn = lstDtRowSet[i];
                    for (int iCnt = 0; iCnt < tblColumn.Rows.Count; iCnt++)
                    {
                        for (int jCnt = 0; jCnt < tblColumn.Columns.Count; jCnt++)
                        {
                            #region //LABEL
                            //RowHeader 에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.LABEL.ToString())
                            {
                                //RowHeader를 Header형태로 사용할지 아니면 Row에 Fix시켜서 사용할지 유무를 결정
                                //RowHeader를 Header형태로 사용
                                if (UseRowFixHeader)
                                {
                                    if (tblColumn.Rows[iCnt][RowProperty.LABEL.ToString()].ToString() != "")
                                    {
                                        TargetSpd.ActiveSheet.RowHeader.Cells.Get(iCnt, hRowCnt).Value
                                                    = tblColumn.Rows[iCnt][RowProperty.LABEL.ToString()];
                                    }
                                    else
                                    {
                                        TargetSpd.ActiveSheet.RowHeader.Cells.Get(iCnt, hRowCnt).Value
                                                    = "";
                                    }
                                }
                                //RowHeader를 Row에 Fix시켜서 사용
                                else
                                {
                                    if (tblColumn.Rows[iCnt][RowProperty.LABEL.ToString()].ToString() != "")
                                    {
                                        TargetSpd.ActiveSheet.Cells.Get(iCnt, hRowCnt).Value
                                                    = tblColumn.Rows[iCnt][RowProperty.LABEL.ToString()];
                                    }
                                    else
                                    {
                                        TargetSpd.ActiveSheet.Cells.Get(iCnt, hRowCnt).Value
                                                    = "";
                                    }
                                }

                            }
                            #endregion

                            #region //HEIGHT
                            //Row 에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.HEIGHT.ToString())
                            {
                                int idefheight = 20;
                                int iheight = 0;

                                if (Int32.TryParse(tblColumn.Rows[iCnt][RowProperty.HEIGHT.ToString()].ToString(), out iheight))
                                {
                                    if (iheight < 1) { iheight = idefheight; }

                                    TargetSpd.ActiveSheet.Rows[iCnt].Height
                                        = iheight;
                                }
                                else
                                {
                                    TargetSpd.ActiveSheet.Rows[iCnt].Height
                                        = idefheight;
                                }
                            }
                            #endregion

                            #region //HALIGN
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.HALIGN.ToString())
                            {
                                if (tblColumn.Rows[iCnt][RowProperty.HALIGN.ToString()].ToString() != "")
                                {
                                    TargetSpd.ActiveSheet.Rows[iCnt].HorizontalAlignment
                                            = TakeCellHAlign(tblColumn.Rows[iCnt][RowProperty.HALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    TargetSpd.ActiveSheet.Rows[iCnt].HorizontalAlignment
                                        = CellHorizontalAlignment.Center;
                                }
                            }
                            #endregion

                            #region //VALIGN
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.VALIGN.ToString())
                            {
                                if (tblColumn.Rows[iCnt][RowProperty.VALIGN.ToString()].ToString() != "")
                                {
                                    TargetSpd.ActiveSheet.Rows[iCnt].VerticalAlignment
                                            = TakeCellVAlign(tblColumn.Rows[iCnt][RowProperty.VALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    TargetSpd.ActiveSheet.Rows[iCnt].VerticalAlignment
                                        = CellVerticalAlignment.Center;
                                }
                            }
                            #endregion

                            #region //MERGE
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.MERGE.ToString())
                            {
                                if (tblColumn.Rows[iCnt][RowProperty.MERGE.ToString()].ToString() != "")
                                {
                                    TargetSpd.ActiveSheet.Rows[iCnt].MergePolicy
                                            = TakeMergePolicy(tblColumn.Rows[iCnt][RowProperty.MERGE.ToString()].ToString());
                                }
                                else
                                {
                                    TargetSpd.ActiveSheet.Rows[iCnt].MergePolicy
                                        = FarPoint.Win.Spread.Model.MergePolicy.None;
                                }
                            }
                            #endregion

                            #region //HIDE
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.HIDE.ToString())
                            {
                                if (tblColumn.Rows[iCnt][RowProperty.HIDE.ToString()].ToString() != "")
                                {
                                    TargetSpd.ActiveSheet.Rows[iCnt].Visible
                                            = !((bool)tblColumn.Rows[iCnt][RowProperty.HIDE.ToString()]);
                                    //HIDE : Visible 이므로 속성값의 반대로 세팅
                                }
                                else
                                {
                                    TargetSpd.ActiveSheet.Rows[iCnt].Visible
                                        = true;
                                }
                            }
                            #endregion

                            #region //LOCK
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.LOCK.ToString())
                            {
                                if (tblColumn.Rows[iCnt][RowProperty.LOCK.ToString()].ToString() != "")
                                {
                                    TargetSpd.ActiveSheet.Rows[iCnt].Locked
                                            = (bool)tblColumn.Rows[iCnt][RowProperty.LOCK.ToString()];
                                }
                                else
                                {
                                    TargetSpd.ActiveSheet.Rows[iCnt].Locked
                                        = false;
                                }
                            }
                            #endregion

                            #region //WIDTH
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.WIDTH.ToString())
                            {
                                TargetSpd.ActiveSheet.RowHeader.Columns[i].Width = int.Parse(tblColumn.Rows[iCnt][RowProperty.WIDTH.ToString()].ToString());
                            }
                            #endregion
                        }
                    }

                    if (boolRowHeaderAutoSpan)
                    {
                        //Row Span
                        //Row Header 의 Column Count 가 1을 초과하면 Row를 Span 해준다.
                        //이 후에 Column Header의 Row를 Span해준다.
                        for (int iCnt = 0; iCnt < iHeaderRowCnt; iCnt++)
                        {
                            if (UseRowFixHeader)
                            {
                                TargetSpd.ActiveSheet.RowHeader.Cells[iCnt, 0].ColumnSpan = hRowCnt + 1;
                            }
                            else
                            {
                                TargetSpd.ActiveSheet.Cells[iCnt, 0].ColumnSpan = hRowCnt + 1;
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Spread의 span 지정 (SpreadPart, WorkType, row, col, val)
        /// SpreadPart(적용부분), WorkType(적용방향), row(Row index), col(Column index), val(적용수)
        /// </summary>
        /// <param name="part">SpreadPart(적용부분)</param>
        /// <param name="type"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="val"></param>
        public void SpreadSpan(SpreadPart part, int row, int column, int rowCount, int columnCount, string Text)
        {
            string Caption = string.Empty;

            //실행조건
            if (TargetSpd == null) { return; }
            if (TargetSv == null) { return; }
            if (part == SpreadPart.spread || part == SpreadPart.Sheet) { return; }

            try
            {
                if (Text != "" || Text == null) { Caption = Text; }
                else
                {
                    if (part == SpreadPart.ColumnHeader || part == SpreadPart.RowHeader)
                    {
                        if (part == SpreadPart.ColumnHeader) { Caption = TargetSpd.ActiveSheet.ColumnHeader.Cells.Get(row, column).Text; }
                        else { Caption = TargetSpd.ActiveSheet.RowHeader.Cells.Get(row, column).Text; }
                    }
                    else
                    {
                        Caption = TargetSpd.ActiveSheet.Cells.Get(row, column).Text;
                    }
                }

                if (part == SpreadPart.ColumnHeader)
                {
                    TargetSpd.ActiveSheet.Models.ColumnHeaderSpan.Add(row, column, rowCount, columnCount);
                    TargetSpd.ActiveSheet.ColumnHeader.Cells[row, column].Text = Caption;
                }
                else if (part == SpreadPart.RowHeader)
                {
                    TargetSpd.ActiveSheet.Models.RowHeaderSpan.Add(row, column, rowCount, columnCount);
                    TargetSpd.ActiveSheet.RowHeader.Cells[row, column].Text = Caption;
                }
                else
                {
                    TargetSpd.ActiveSheet.Models.Span.Add(row, column, rowCount, columnCount);
                    TargetSpd.ActiveSheet.Cells[row, column].Text = Caption;
                }
            }
            catch { }
        }

        #endregion

        #region Internal Use Function

        public ICellType TakeCellType(string type)
        {
            ICellType _celltype = null;

            if (type.Trim().ToUpper() == SpreadCellType.CheckBoxCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.CheckBoxCellType checkboxcelltype = new FarPoint.Win.Spread.CellType.CheckBoxCellType();

                _celltype = checkboxcelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.TextCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.TextCellType defaulttype = new FarPoint.Win.Spread.CellType.TextCellType();

                _celltype = defaulttype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.NumberCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.NumberCellType numbercelltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                numbercelltype.DecimalPlaces = 0;
                numbercelltype.Separator = ",";
                numbercelltype.MaximumValue = 999999999999;
                numbercelltype.ShowSeparator = true;
                numbercelltype.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.Yes;

                _celltype = numbercelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.LongNumberCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.NumberCellType doublecelltype = new FarPoint.Win.Spread.CellType.NumberCellType();
                doublecelltype.DecimalPlaces = 2;
                doublecelltype.Separator = ",";
                doublecelltype.MaximumValue = 999999999999.99;
                doublecelltype.ShowSeparator = true;

                _celltype = doublecelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.DateTimeCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.DateTimeCellType datepartcelltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                datepartcelltype.DateSeparator = "/";
                datepartcelltype.DateTimeFormat = DateTimeFormat.UserDefined;
                datepartcelltype.UserDefinedFormat = "yyyy/MM/dd";
                datepartcelltype.SpinButton = false;

                _celltype = datepartcelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.LongDateTimeCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.DateTimeCellType datefullcelltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                datefullcelltype.DateSeparator = "/";
                datefullcelltype.DateTimeFormat = DateTimeFormat.UserDefined;
                datefullcelltype.UserDefinedFormat = "yyyy/MM/dd HH:mm:ss";
                datefullcelltype.SpinButton = false;

                _celltype = datefullcelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.ComboBoxCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.ComboBoxCellType comboboxcelltype = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                comboboxcelltype.Editable = false;

                _celltype = comboboxcelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.HyperLinkCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.HyperLinkCellType hyperlinkcelltype = new FarPoint.Win.Spread.CellType.HyperLinkCellType();

                _celltype = hyperlinkcelltype;
            }
            else
            {
                FarPoint.Win.Spread.CellType.TextCellType defaulttype = new FarPoint.Win.Spread.CellType.TextCellType();

                _celltype = defaulttype;
            }

            return _celltype;
        }

        private CellHorizontalAlignment TakeCellHAlign(string type)
        {
            CellHorizontalAlignment _cellHAlign = new CellHorizontalAlignment();

            if (type.Trim().ToUpper() == SpreadCellHAlign.Left.ToString().ToUpper())
            {
                _cellHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            }
            else if (type.Trim().ToUpper() == SpreadCellHAlign.Center.ToString().ToUpper())
            {
                _cellHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            }
            else if (type.Trim().ToUpper() == SpreadCellHAlign.Right.ToString().ToUpper())
            {
                _cellHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            }
            else
            {
                _cellHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            }

            return _cellHAlign;
        }

        private CellVerticalAlignment TakeCellVAlign(string type)
        {
            CellVerticalAlignment _cellVAlign = new CellVerticalAlignment();

            if (type.Trim().ToUpper() == SpreadCellVAlign.Top.ToString().ToUpper())
            {
                _cellVAlign = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            }
            else if (type.Trim().ToUpper() == SpreadCellVAlign.Center.ToString().ToUpper())
            {
                _cellVAlign = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }
            else if (type.Trim().ToUpper() == SpreadCellVAlign.Bottom.ToString().ToUpper())
            {
                _cellVAlign = FarPoint.Win.Spread.CellVerticalAlignment.Bottom;
            }
            else
            {
                _cellVAlign = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            }

            return _cellVAlign;
        }

        private FarPoint.Win.Spread.Model.MergePolicy TakeMergePolicy(string type)
        {
            FarPoint.Win.Spread.Model.MergePolicy _cellMergePolicy = new FarPoint.Win.Spread.Model.MergePolicy();

            if (type.Trim().ToUpper() == SpreadCellMerge.None.ToString().ToUpper())
            {
                _cellMergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            }
            else if (type.Trim().ToUpper() == SpreadCellMerge.Always.ToString().ToUpper())
            {
                _cellMergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            }
            else if (type.Trim().ToUpper() == SpreadCellMerge.Restricted.ToString().ToUpper())
            {
                _cellMergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            }
            else
            {
                _cellMergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
            }

            return _cellMergePolicy;
        }

        #endregion

        #endregion

        #region External Function
        #region spread Column Width Auto Fit

        /// <summary>
        /// Spread의 Column Width 값을 자동으로 조절한다.
        /// SpreadPart.ColumnHeader : ColumnHeader Caption의 크기에 맞춰서 자동조절
        /// SpreadPart.Column : Column Text의 크기에 맞춰서 자동조절
        /// 그외(값이 있거나 없거나) 위 두사항의 크기를 비교하여 큰값에 자동조절
        /// </summary>
        /// <param name="spd"></param>
        /// <param name="selwidth"></param>
        public void SpreadWidthResize(FpSpread spdData)
        {
            SpreadWidthResize(spdData, SpreadPart.spread);
        }

        /// <summary>
        /// Spread의 Column Width 값을 자동으로 조절한다.
        /// SpreadPart.ColumnHeader : ColumnHeader Caption의 크기에 맞춰서 자동조절
        /// SpreadPart.Column : Column Text의 크기에 맞춰서 자동조절
        /// 그외 위 두사항의 크기를 비교하여 큰값에 자동조절
        /// </summary>
        /// <param name="spd"></param>
        /// <param name="selwidth"></param>
        public void SpreadWidthResize(FpSpread spdData, SpreadPart selwidth)
        {
            Graphics gphi = spdData.CreateGraphics();
            Size textsize = new Size();
            Size comptextsize = new Size();
            float swidth = 0f;

            ////Cell padding value setting : 셀내 마진값 세팅
            //SpreadCellPadding(spd);

            for (int i = 0; i < spdData.ActiveSheet.ColumnCount; i++)
            {
                //SizeF textsizef = gphi.MeasureString(spd.spdData.ActiveSheet.ColumnHeader.Cells[0, i].Text, this.Font);

                textsize = TextRenderer.MeasureText(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Text, spdData.Font);
                for (int j = 0; j < spdData.ActiveSheet.ColumnHeader.RowCount; j++)
                {
                    comptextsize = TextRenderer.MeasureText(spdData.ActiveSheet.ColumnHeader.Cells[j, i].Text, spdData.Font);

                    if (comptextsize.Width > textsize.Width) { textsize = comptextsize; }
                }

                swidth = spdData.ActiveSheet.GetPreferredColumnWidth(i);

                if (selwidth == SpreadPart.ColumnHeader)
                {
                    spdData.ActiveSheet.ColumnHeader.Columns[i].Width = textsize.Width + 10;
                }
                else if (selwidth == SpreadPart.Column)
                {
                    spdData.ActiveSheet.Columns[i].Width = swidth + 10;
                }
                else
                {
                    if (textsize.Width >= swidth)
                    {
                        spdData.ActiveSheet.ColumnHeader.Columns[i].Width = textsize.Width + 10;
                        spdData.ActiveSheet.Columns[i].Width = textsize.Width + 10;
                    }
                    else
                    {
                        spdData.ActiveSheet.ColumnHeader.Columns[i].Width = swidth + 10;
                        spdData.ActiveSheet.Columns[i].Width = swidth + 10;
                    }
                }
            }
        }


        /// <summary>
        /// SpreadCellMargin
        /// spread Cell의 cell padding 값을 설정한다.
        /// </summary>
        /// <param name="spd"></param>
        public void SpreadCellPadding(FpSpread spd)
        {
            try
            {
                //특정한 경우 에러발생하여 주석처리 후에 해결예정...

                //for (int r = 0; r < spd.spdData.ActiveSheet.RowCount; r++)
                //{
                //    for (int c = 0; c < spd.spdData.ActiveSheet.ColumnCount; c++)
                //    {
                //        Color color = new Color();

                //        if (spd.spdData.ActiveSheet.Columns[c].BackColor.Name != "0" 
                //            && spd.spdData.ActiveSheet.Columns[c].BackColor.Name == spd.spdData.ActiveSheet.Cells[r, c].BackColor.Name)
                //        { color = spd.spdData.ActiveSheet.Columns[c].BackColor; }
                //        else if (spd.spdData.ActiveSheet.Rows[r].BackColor.Name != "0")// && spd.spdData.ActiveSheet.Rows[j].BackColor.Name == spd.spdData.ActiveSheet.Cells[j, i].BackColor.Name)
                //        { color = spd.spdData.ActiveSheet.Rows[r].BackColor; }
                //        else 
                //        { 
                //            //color = spd.spdData.ActiveSheet.Cells[r, c].BackColor;
                //            color = spd.spdData.ActiveSheet.AlternatingRows[(r % 2)].BackColor;
                //        }

                //        spd.spdData.ActiveSheet.Cells[r, c].Border = new SpreadBorderMargin(spd.spdData, color, r, c);
                //    }
                //}
            }
            catch (Exception)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        public Spread.SpreadCellType GetCellType(string strType)
        {
            Spread.SpreadCellType cellType = Spread.SpreadCellType.TextCellType;
            switch (strType)
            {
                case "TextCellType":
                    cellType = Spread.SpreadCellType.TextCellType;
                    break;
                case "NumberCellType":
                    cellType = Spread.SpreadCellType.NumberCellType;
                    break;
                case "LongNumberCellType":
                    cellType = Spread.SpreadCellType.LongNumberCellType;
                    break;
                case "LongDateTimeCellType":
                    cellType = Spread.SpreadCellType.LongDateTimeCellType;
                    break;
                case "HyperLinkCellType":
                    cellType = Spread.SpreadCellType.HyperLinkCellType;
                    break;
                case "DateTimeCellType":
                    cellType = Spread.SpreadCellType.DateTimeCellType;
                    break;
                case "ComboBoxCellType":
                    cellType = Spread.SpreadCellType.ComboBoxCellType;
                    break;
                case "CheckBoxCellType":
                    cellType = Spread.SpreadCellType.CheckBoxCellType;
                    break;
            }

            return cellType;
        }

        /// <summary>
        /// SetUserCellType
        /// </summary>
        /// <param name="ColumnIndex"></param>
        /// <param name="userCellType"></param>
        public void SetUserCellType(int ColumnIndex, FarPoint.Win.Spread.CellType.ICellType userCellType)
        {
            this.TargetSpd.ActiveSheet.Columns[ColumnIndex].CellType = userCellType;
            if (TargetSv != null) { this.TargetSv.Columns[ColumnIndex].CellType = userCellType; }
        }

        #endregion

        #region Set spread Property of Performance Display

        public void SpreadDisplaySet(FpSpread spdData
                                            , Boolean AutoGenerateColumns
                                            , Boolean AutoCalculation
                                            , Boolean AutoUpdateNotes
                                            , Boolean DataAutoCellTypes)
        {
            spdData.ActiveSheet.AutoGenerateColumns = AutoGenerateColumns;
            spdData.ActiveSheet.AutoCalculation = AutoCalculation;
            spdData.ActiveSheet.AutoUpdateNotes = AutoUpdateNotes;
            spdData.ActiveSheet.DataAutoCellTypes = DataAutoCellTypes;
        }

        #endregion

        #region Set spread DataSource

        public void SpreadDataSourceSet(FpSpread spdData, DataSet ds)
        {
            if (ds == null)
            {
                spdData.Sheets[0].DataSource = null;
                if (spdData.Sheets[0].Rows.Count > 0) spdData.Sheets[0].Rows.Count = 0;
                if (spdData.Sheets[0].Columns.Count > 0) spdData.Sheets[0].Columns.Count = 0;
            }
            else
            {
                if (spdData.Sheets[0].Rows.Count > 0) spdData.Sheets[0].Rows.Count = 0;
                if (spdData.Sheets[0].Columns.Count > 0) spdData.Sheets[0].Columns.Count = 0;
                spdData.SuspendLayout();
                spdData.Sheets[0].DataSource = ds;
                spdData.ResumeLayout();
            }
        }

        public void SpreadDataSourceSet(FpSpread spdData, DataTable dt)
        {

            if (spdData.Sheets[0].Rows.Count > 0) spdData.Sheets[0].Rows.Clear();
            if (spdData.Sheets[0].Columns.Count > 0) spdData.Sheets[0].Columns.Clear();

            try
            {
                spdData.SuspendLayout();
                spdData.Sheets[0].DataSource = dt;
                spdData.ResumeLayout();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        #endregion

        #endregion

        #endregion

        #region [Add Function]
        /// <summary>
        /// Cell Type 사용 안함.
        /// </summary>
        /// <param name="fpSpd"></param>
        /// <param name="oCol"></param>
        /// <returns></returns>
        public bool MakeSpreadCelType(FarPoint.Win.Spread.FpSpread fpSpd, object[,] oCol)
        {
            Spread sprMaker1 = new Spread();

            try
            {
                if (oCol != null)
                {
                    if (oCol.GetLongLength(0) > 0)
                    {
                        for (int iCol = 0; iCol < oCol.GetLongLength(0); iCol++)
                        {
                            sLabel = oCol[iCol, (int)ColTp.sLabel].ToString();
                            iWidth = Convert.ToInt32(oCol[iCol, (int)ColTp.iWidth].ToString());
                            sKey = oCol[iCol, (int)ColTp.sKey].ToString();
                            CelType = (Spread.SpreadCellType)oCol[iCol, (int)ColTp.CelType];
                            CelHalign = (Spread.SpreadCellHAlign)oCol[iCol, (int)ColTp.CelHalign];
                            CelValign = (Spread.SpreadCellVAlign)oCol[iCol, (int)ColTp.CelValign];
                            CelMerge = (Spread.SpreadCellMerge)oCol[iCol, (int)ColTp.CelMerge];
                            bHide = (bool)oCol[iCol, (int)ColTp.bHide];
                            bLock = (bool)oCol[iCol, (int)ColTp.bLock];
                            CellHorizontalAlignment _cellHAlign = new CellHorizontalAlignment();

                            fpSpd.ActiveSheet.Columns[iCol].Locked = bLock;
                            if (CelHalign == Spread.SpreadCellHAlign.Left)
                            {
                                _cellHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                            }
                            else if (CelHalign == Spread.SpreadCellHAlign.Center)
                            {
                                _cellHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                            }
                            else if (CelHalign == Spread.SpreadCellHAlign.Right)
                            {
                                _cellHAlign = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                            }

                            fpSpd.ActiveSheet.Columns[iCol].HorizontalAlignment = _cellHAlign;
                            fpSpd.ActiveSheet.Columns[iCol].Width = iWidth;
                            fpSpd.ActiveSheet.Columns[iCol].CellType = sprMaker1.TakeCellType(CelType.ToString());
                        }
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
        public void MakeSpreadColHeader(FarPoint.Win.Spread.FpSpread fpSpd, DataTable tblData, object[,] oCol)
        {
            MakeSpreadColHeader(fpSpd, tblData, oCol, 1);
        }
        public void MakeSpreadColHeader(FarPoint.Win.Spread.FpSpread fpSpd, DataTable tblData, object[,] oCol, int iColHRowCnt)
        {


            try
            {
                Spread sprMaker1 = new Spread();
                fpSpd.Tag = "Change Header";

                sprMaker1.SpreadDataSourceSet(fpSpd, tblData);
                sprMaker1.InitializeSpread();
                sprMaker1.TargetSpread = fpSpd;
                sprMaker1.TargetSheet = fpSpd.ActiveSheet;
                sprMaker1.iColHRowCnt = iColHRowCnt;

                if (oCol != null)
                {
                    if (oCol.GetLongLength(0) > 0)
                    {
                        for (int iCol = 0; iCol < oCol.GetLongLength(0); iCol++)
                        {
                            sLabel = oCol[iCol, (int)ColTp.sLabel].ToString();
                            iWidth = Convert.ToInt32(oCol[iCol, (int)ColTp.iWidth].ToString());
                            sKey = oCol[iCol, (int)ColTp.sKey].ToString();
                            CelType = (Spread.SpreadCellType)oCol[iCol, (int)ColTp.CelType];
                            CelHalign = (Spread.SpreadCellHAlign)oCol[iCol, (int)ColTp.CelHalign];
                            CelValign = (Spread.SpreadCellVAlign)oCol[iCol, (int)ColTp.CelValign];
                            CelMerge = (Spread.SpreadCellMerge)oCol[iCol, (int)ColTp.CelMerge];
                            bHide = (bool)oCol[iCol, (int)ColTp.bHide];
                            bLock = (bool)oCol[iCol, (int)ColTp.bLock];
                            sprMaker1.ColumnAdd(sLabel, iWidth, sKey, CelType, CelHalign, CelValign, CelMerge, bHide, bLock);
                        }
                    }
                }
                sprMaker1.bColumnHederAutoSpan = false;
                sprMaker1.SetSpSheet();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
        /// <summary>
        /// ForeGround Color Set
        /// </summary>
        /// <param name="ugb"></param>
        /// <param name="key"></param>
        /// <param name="mergedCellEvaluator"></param>
        public void SetForeColorColumn(FarPoint.Win.Spread.FpSpread fpSpd, int[] keys)
        {
            SetForeColorColumn(fpSpd, keys, Color.LightGreen);
        }
        public void SetForeColorColumn(FarPoint.Win.Spread.FpSpread fpSpd, int[] keys, Color cColor)
        {
            foreach (int key in keys)
            {
                fpSpd.ActiveSheet.Columns[key].ForeColor = cColor;
            }
        }
        public void SetForeColorRows(FarPoint.Win.Spread.FpSpread fpSpd, int[] keys)
        {
            SetForeColorRows(fpSpd, keys, Color.LightGreen);
        }
        public void SetForeColorRows(FarPoint.Win.Spread.FpSpread fpSpd, int[] keys, Color cColor)
        {
            foreach (int key in keys)
            {
                fpSpd.ActiveSheet.Rows[key].ForeColor = cColor;
            }
        }
        public void SetForeColorCells(FarPoint.Win.Spread.FpSpread fpSpd, int[] iRows, int[] iCols)
        {
            SetForeColorCells(fpSpd, iRows, iCols, Color.LightGreen);

        }
        public void SetForeColorCells(FarPoint.Win.Spread.FpSpread fpSpd, int[] iRows, int[] iCols, Color cColor)
        {
            foreach (int RowKey in iRows)
            {
                foreach (int ColKey in iCols)
                {
                    fpSpd.ActiveSheet.Cells[RowKey, ColKey].ForeColor = cColor;
                }
            }
        }
        public void SetForeColorCell(FarPoint.Win.Spread.FpSpread fpSpd, int iRowKey, int iColKey)
        {
            SetForeColorCell(fpSpd, iRowKey, iColKey, Color.LightGreen);

        }
        public void SetForeColorCell(FarPoint.Win.Spread.FpSpread fpSpd, int iRowKey, int iColKey, Color cColor)
        {
            fpSpd.ActiveSheet.Cells[iRowKey, iColKey].ForeColor = cColor;
        }

        /// <summary>
        /// BackGround Color Set
        /// </summary>
        /// <param name="ugb"></param>
        /// <param name="key"></param>
        /// <param name="mergedCellEvaluator"></param>
        public void SetBackColorColumn(FarPoint.Win.Spread.FpSpread fpSpd, int[] keys)
        {
            SetBackColorColumn(fpSpd, keys, Color.LightGreen);
        }
        public void SetBackColorColumn(FarPoint.Win.Spread.FpSpread fpSpd, int[] keys, Color cColor)
        {
            foreach (int key in keys)
            {
                fpSpd.ActiveSheet.Columns[key].BackColor = cColor;
            }
        }
        public void SetBackColorRows(FarPoint.Win.Spread.FpSpread fpSpd, int[] keys)
        {
            SetBackColorRows(fpSpd, keys, Color.LightGreen);
        }
        public void SetBackColorRows(FarPoint.Win.Spread.FpSpread fpSpd, int[] keys, Color cColor)
        {
            foreach (int key in keys)
            {
                fpSpd.ActiveSheet.Rows[key].BackColor = cColor;
            }
        }
        public void SetBackColorCells(FarPoint.Win.Spread.FpSpread fpSpd, int[] iRows, int[] iCols)
        {
            SetBackColorCells(fpSpd, iRows, iCols, Color.LightGreen);

        }
        public void SetBackColorCells(FarPoint.Win.Spread.FpSpread fpSpd, int[] iRows, int[] iCols, Color cColor)
        {
            foreach (int RowKey in iRows)
            {
                foreach (int ColKey in iCols)
                {
                    fpSpd.ActiveSheet.Cells[RowKey, ColKey].BackColor = cColor;
                }
            }
        }
        public void SetBackColorCell(FarPoint.Win.Spread.FpSpread fpSpd, int iRowKey, int iColKey)
        {
            SetBackColorCell(fpSpd, iRowKey, iColKey, Color.LightGreen);

        }
        public void SetBackColorCell(FarPoint.Win.Spread.FpSpread fpSpd, int iRowKey, int iColKey, Color cColor)
        {
            fpSpd.ActiveSheet.Cells[iRowKey, iColKey].BackColor = cColor;
        }
        /// <summary>
        /// Column Lock Set
        /// </summary>
        /// <param name="ugb"></param>
        /// <param name="key"></param>
        /// <param name="mergedCellEvaluator"></param>
        public void SetLockColumn(FarPoint.Win.Spread.FpSpread fpSpd, int[] keys, bool bValue)
        {
            foreach (int key in keys)
            {
                fpSpd.ActiveSheet.Columns[key].Locked = bValue;
            }
        }
        /// <summary>
        /// Column Lock Set
        /// </summary>
        /// <param name="ugb"></param>
        /// <param name="key"></param>
        /// <param name="mergedCellEvaluator"></param>
        public void SetHideColumn(FarPoint.Win.Spread.FpSpread fpSpd, int[] keys, bool bValue)
        {
            foreach (int key in keys)
            {
                fpSpd.ActiveSheet.Columns[key].Visible = bValue;
            }
        }
        /// <summary>
        /// Query 
        /// </summary>
        /// <param name="sSql"></param>
        /// <param name="lstCond"></param>
        /// <returns></returns>
        public string ViewSQL(string sSql, List<string> lstCond)
        {
            List<string> lstCond1 = null;
            return ViewSQL(sSql, lstCond, lstCond1);
        }
        public string ViewSQL(string sSql, List<string> lstCond, List<string> lstCond1)
        {
            return ViewSQL(sSql, lstCond, lstCond1, true);
        }
        /// <summary>
        /// Query
        /// </summary>
        /// <param name="sSqlStep"></param>
        /// <returns></returns>
        public string ViewSQL(string sSql, List<string> lstCond, List<string> lstCond1, bool bLog)
        {
            StringBuilder sbQry = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            int i_Length = 0;
            string s_DynamicQuery = string.Empty;
            string sQueryStatement = string.Empty;

            sb.Remove(0, sbQry.Length);
            sb.AppendLine(sSql);

            try
            {
                #region Agument Replace
                string[] straTemp = null;
                if (lstCond != null)
                {
                    foreach (string strKey in lstCond)
                    {
                        straTemp = strKey.Split('?');
                        sb = sb.Replace(straTemp[0], straTemp[1]);
                    }
                    //sQueryStatement = sb.ToString();
                }
                if (lstCond1 != null)
                {
                    foreach (string strKey in lstCond1)
                    {
                        i_Length = 0;

                        if (sb.ToString().IndexOf("?") < 0)
                        {
                            break;
                        }
                        i_Length = sb.ToString().IndexOf("?") + 1;
                        s_DynamicQuery = sb.ToString().Substring(0, sb.ToString().IndexOf("?"));
                        s_DynamicQuery += strKey;
                        s_DynamicQuery += sb.ToString().Substring(sb.ToString().IndexOf("?") + 1, sb.ToString().Length - i_Length);

                        sQueryStatement = s_DynamicQuery;

                        sb.Remove(0, sb.Length);
                        sb.AppendLine(s_DynamicQuery);
                    }
                    //sQueryStatement = s_DynamicQuery;
                }
                #endregion
                return sb.ToString();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return string.Empty;
            }
            finally
            {
                if (bLog)
                {
                    StringBuilder sbSqlLog = new StringBuilder();
                    sbSqlLog.AppendLine(sb.ToString());
                    sbSqlLog.AppendLine(";"); //쿼리 끝 지점
                    System.Diagnostics.Trace.WriteLine(sbSqlLog.ToString());
                    sQueryStatement = sbSqlLog.ToString();
                    MOGV.gsQueryStatementLong = MOGV.gsQueryStatementLong + GetSeparatorString() + sQueryStatement; // 다중 Query문 저장
                }

            }
        }
        public static string GetSeparatorString()
        {
            return GetSeparatorString(null);
        }
        public static string GetSeparatorString(string queryID)
        {
            string results = Environment.NewLine
                + "--[ " + DateTime.Now.ToString() + " ]---쿼리 시작---------------------------------------------------------------\r\n";

            if (!String.IsNullOrEmpty(queryID))
            {
                results += String.Format("/* {0} */\r\n", queryID);
                results += "----------------------------------------------------------------------------------------------------";
            }

            return results + Environment.NewLine;
        }

        /// <summary>
        /// SheetLocation
        /// </summary>
        /// <param name="sv"></param>
        /// <param name="rowIdx"></param>
        /// <param name="colIdx"></param>
        /// <returns></returns>
        public Rectangle SheetLocation(FarPoint.Win.Spread.FpSpread fpSpd, int rowIdx, int colIdx)
        {
            int margin = 2;
            Rectangle rect = fpSpd.GetCellRectangle(0, 0, rowIdx, colIdx);
            rect.X -= margin;
            rect.Y -= margin;
            rect.Width += margin * 2;
            rect.Height += margin * 2;
            rect.Y += fpSpd.Location.Y;

            return rect;
        }
        /// <summary>
        /// ViewData에서 호출되는 Tree 초기 Funtions
        /// </summary>
        /// <param name="iRows"></param>
        /// <param name="iCols"></param>
        public void SetSpreadTree(FarPoint.Win.Spread.FpSpread fpSpd, int iRows, int iCols, int iIndex)
        {
            try
            {
                ArrayList aCode = new ArrayList();
                #region < ColumnHeader Action >
                if (fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType.ToString() == "ButtonCellType")
                {
                    if (((FarPoint.Win.Spread.CellType.ButtonCellType)(fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType)).Text == "－")
                    {
                        for (int iRow = iRows + 1; iRow < fpSpd.ActiveSheet.RowCount; iRow++)
                        {
                            if (iRow >= 0)
                            {
                                if (fpSpd.ActiveSheet.Cells[iRows, iIndex].Text == fpSpd.ActiveSheet.Cells[iRow, iIndex].Text ||
                                    Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRows, iIndex].Value) < Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRow, iIndex].Value))
                                {
                                    break;
                                }
                                else
                                {
                                    aCode.Add(iRow);

                                    if (fpSpd.ActiveSheet.GetValue(iRow, iCols) == null)
                                    {
                                        if (fpSpd.ActiveSheet.Cells.Get(iRow, iCols).CellType.ToString() == "ButtonCellType")
                                        {
                                            FarPoint.Win.Spread.CellType.ButtonCellType btnType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
                                            btnType1.Text = "＋";
                                            fpSpd.ActiveSheet.Cells.Get(iRow, iCols).CellType = btnType1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        foreach (int nRow in aCode)
                        {
                            fpSpd.ActiveSheet.Rows[nRow].Visible = false;
                        }

                        FarPoint.Win.Spread.CellType.ButtonCellType btnType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        btnType.Text = "＋";
                        fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType = btnType;

                        aCode = null;
                    }
                    else if (((FarPoint.Win.Spread.CellType.ButtonCellType)(fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType)).Text == "＋")
                    {
                        for (int iRow = iRows + 1; iRow < fpSpd.ActiveSheet.RowCount; iRow++)
                        {
                            if (iRow >= 0)
                            {
                                if (fpSpd.ActiveSheet.Cells[iRows, iIndex].Text == fpSpd.ActiveSheet.Cells[iRow, iIndex].Text ||
                                    Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRows, iIndex].Text) < Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRow, iIndex].Text))
                                {
                                    break;
                                }
                                else
                                {
                                    aCode.Add(iRow);

                                    if (fpSpd.ActiveSheet.GetValue(iRow, iCols) == null)
                                    {
                                        if (fpSpd.ActiveSheet.Cells.Get(iRow, iCols).CellType.ToString() == "ButtonCellType")
                                        {
                                            FarPoint.Win.Spread.CellType.ButtonCellType btnType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
                                            btnType1.Text = "－";
                                            fpSpd.ActiveSheet.Cells.Get(iRow, iCols).CellType = btnType1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        foreach (int nRow in aCode)
                        {
                            fpSpd.ActiveSheet.Rows[nRow].Visible = true;
                        }

                        FarPoint.Win.Spread.CellType.ButtonCellType btnType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        btnType.Text = "－";
                        fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType = btnType;

                        aCode = null;
                    }
                }
                #endregion


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
        /// <summary>
        /// Set Collapse Tree
        /// </summary>
        /// <param name="iRows"></param>
        /// <param name="iCols"></param>
        public void SetCollapseTree(FarPoint.Win.Spread.FpSpread fpSpd, int iRows, int iCols, int iIndex)
        {
            try
            {
                ArrayList aCode = new ArrayList();
                #region < ColumnHeader Action >
                if (fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType.ToString() == "ButtonCellType")
                {
                    #region [ ((FarPoint.Win.Spread.CellType.ButtonCellType)(spdData.ActiveSheet.Cells.Get(iRows, iCols).CellType)).Text == "－" ]
                    for (int iRow = iRows + 1; iRow < fpSpd.ActiveSheet.RowCount; iRow++)
                    {
                        if (iRow >= 0)
                        {
                            if (fpSpd.ActiveSheet.Cells[iRows, iIndex].Text == fpSpd.ActiveSheet.Cells[iRow, iIndex].Text ||
                                Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRows, iIndex].Value) < Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRow, iIndex].Value))
                            {
                                break;
                            }
                            else
                            {
                                aCode.Add(iRow);

                                if (fpSpd.ActiveSheet.GetValue(iRow, iCols) == null)
                                {
                                    if (fpSpd.ActiveSheet.Cells.Get(iRow, iCols).CellType.ToString() == "ButtonCellType")
                                    {
                                        FarPoint.Win.Spread.CellType.ButtonCellType btnType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
                                        btnType1.Text = "＋";
                                        fpSpd.ActiveSheet.Cells.Get(iRow, iCols).CellType = btnType1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    foreach (int nRow in aCode)
                    {
                        fpSpd.ActiveSheet.Rows[nRow].Visible = false;
                    }

                    FarPoint.Win.Spread.CellType.ButtonCellType btnType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    btnType.Text = "＋";
                    fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType = btnType;

                    aCode = null;
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
        /// <summary>
        /// Set Expand Tree
        /// </summary>
        /// <param name="iRows"></param>
        /// <param name="iCols"></param>
        public void SetExpandTree(FarPoint.Win.Spread.FpSpread fpSpd, int iRows, int iCols, int iIndex, int iBtn)
        {
            try
            {
                Spread sprMaker1 = new Spread();
                ArrayList aCode = new ArrayList();
                #region < RowHeader Action >
                if (fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType.ToString() == "ButtonCellType")
                {
                    if (((FarPoint.Win.Spread.CellType.ButtonCellType)(fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType)).Text == "－")
                    {
                        for (int iRow = iRows + 1; iRow < fpSpd.ActiveSheet.RowCount; iRow++)
                        {
                            if (iRow >= 0)
                            {
                                if (fpSpd.ActiveSheet.Cells[iRows, iIndex].Text == fpSpd.ActiveSheet.Cells[iRow, iIndex].Text ||
                                    Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRows, iIndex].Value) < Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRow, iIndex].Value))
                                {
                                    break;
                                }
                                else
                                {
                                    aCode.Add(iRow);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        foreach (int nRow in aCode)
                        {
                            fpSpd.ActiveSheet.Rows[nRow].Visible = false;
                        }

                        FarPoint.Win.Spread.CellType.ButtonCellType btnType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        btnType.Text = "＋";
                        fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType = btnType;

                        aCode = null;
                    }
                    else if (((FarPoint.Win.Spread.CellType.ButtonCellType)(fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType)).Text == "＋")
                    {
                        for (int iRow = iRows + 1; iRow < fpSpd.ActiveSheet.RowCount; iRow++)
                        {
                            if (iRow >= 0)
                            {
                                if (fpSpd.ActiveSheet.Cells[iRows, iIndex].Text == fpSpd.ActiveSheet.Cells[iRow, iIndex].Text ||
                                    Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRows, iIndex].Value) < Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRow, iIndex].Value))
                                {
                                    break;
                                }
                                else
                                {
                                    aCode.Add(iRow);
                                    //
                                    if (fpSpd.ActiveSheet.GetValue(iRow, iCols) == null)
                                    {
                                        if (fpSpd.ActiveSheet.Cells.Get(iRow, iCols).CellType.ToString() == "ButtonCellType")
                                        {
                                            FarPoint.Win.Spread.CellType.ButtonCellType btnType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
                                            btnType1.Text = "－";
                                            fpSpd.ActiveSheet.Cells.Get(iRow, iCols).CellType = btnType1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        foreach (int nRow in aCode)
                        {
                            fpSpd.ActiveSheet.Rows[nRow].Visible = true;
                        }

                        FarPoint.Win.Spread.CellType.ButtonCellType btnType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        btnType.Text = "－";
                        fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType = btnType;

                        aCode = null;

                        if (iBtn > 0)
                        {
                            //Set Spread Tree Type Collapse
                            for (int iRow = iRows + 1; iRow < fpSpd.ActiveSheet.RowCount; iRow++)
                            {
                                if (fpSpd.ActiveSheet.Cells.Get(iRow, iBtn).CellType != null)
                                {
                                    sprMaker1.SetCollapseTree(fpSpd, iRow, iBtn, iIndex);
                                }
                            }
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        public void SetExpandTree1(FarPoint.Win.Spread.FpSpread fpSpd, int iRows, int iCols, int iIndex, int iBtn)
        {
            try
            {
                ArrayList aCode = new ArrayList();
                #region < ColumnHeader Action >
                if (fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType.ToString() == "ButtonCellType")
                {
                    #region [ ((FarPoint.Win.Spread.CellType.ButtonCellType)(spdData.ActiveSheet.Cells.Get(iRows, iCols).CellType)).Text == "＋" ]

                    #region < SHOP >
                    for (int iRow = iRows + 1; iRow < fpSpd.ActiveSheet.RowCount; iRow++)
                    {
                        if (iRow >= 0)
                        {
                            if (fpSpd.ActiveSheet.Cells[iRows, iIndex].Text == fpSpd.ActiveSheet.Cells[iRow, iIndex].Text ||
                                Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRows, iIndex].Value) < Convert.ToInt32(fpSpd.ActiveSheet.Cells[iRow, iIndex].Value))
                            {
                                break;
                            }
                            else
                            {
                                aCode.Add(iRow);

                                if (fpSpd.ActiveSheet.GetValue(iRow, iCols) == null)
                                {
                                    if (fpSpd.ActiveSheet.Cells.Get(iRow, iCols).CellType.ToString() == "ButtonCellType")
                                    {
                                        FarPoint.Win.Spread.CellType.ButtonCellType btnType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
                                        btnType1.Text = "－";
                                        fpSpd.ActiveSheet.Cells.Get(iRow, iCols).CellType = btnType1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    foreach (int nRow in aCode)
                    {
                        fpSpd.ActiveSheet.Rows[nRow].Visible = true;
                    }

                    FarPoint.Win.Spread.CellType.ButtonCellType btnType = new FarPoint.Win.Spread.CellType.ButtonCellType();
                    btnType.Text = "－";
                    fpSpd.ActiveSheet.Cells.Get(iRows, iCols).CellType = btnType;

                    aCode = null;

                    if (iBtn > 0)
                    {
                        //Set Spread Tree Type Collapse
                        for (int iRow = 0 + 2; iRow < fpSpd.ActiveSheet.RowCount; iRow++)
                        {
                            if (fpSpd.ActiveSheet.Cells.Get(iRow, iBtn).CellType != null)
                            {
                                SetCollapseTree(fpSpd, iRow, iBtn, iIndex);
                            }
                        }
                    }
                    #endregion
                    #endregion

                }
                #endregion
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Clipboard Copy&Paste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool fpSpd_Clipboard(object sender, FarPoint.Win.Spread.ClipboardPastingEventArgs e)
        {
            bool bChk = true;
            FarPoint.Win.Spread.FpSpread fpSpd = sender as FarPoint.Win.Spread.FpSpread;

            try
            {
                string data;
                string[] rows, cols = new string[] { };
                int rowNum, colNum;

                if (!Clipboard.ContainsData(DataFormats.Text)) return false;

                rowNum = fpSpd.ActiveSheet.ActiveRowIndex;
                colNum = fpSpd.ActiveSheet.ActiveColumnIndex;

                data = Clipboard.GetData(DataFormats.Text) as string;

                data = data.Replace("\r\n", Convert.ToChar(13).ToString());

                rows = data.Split(new Char[] { Convert.ToChar(13) });
                for (int rowLoop = 0; rowLoop < rows.Length - 1; rowLoop++)
                {
                    cols = rows[rowLoop].Split(new Char[] { Convert.ToChar(9) });
                    for (int colLoop = 0; colLoop < cols.Length; colLoop++)
                        if (!fpSpd.ActiveSheet.Columns[colNum + colLoop].Locked)
                            fpSpd.ActiveSheet.Cells[rowNum + rowLoop, colNum + colLoop].Value = cols[colLoop];
                }
            }
            catch
            {
            }

            return bChk;
        }

        #endregion
    }


    public class SpreadBorderMargin : IBorder
    {
        private FarPoint.Win.Spread.FpSpread spd;
        private Color color;
        private Inset inset;
        private int row;
        private int column;

        public SpreadBorderMargin(FarPoint.Win.Spread.FpSpread spd)
        {
            this.spd = spd;
            this.inset = new Inset(2, 0, 3, 0);
        }

        public SpreadBorderMargin(FarPoint.Win.Spread.FpSpread spd, Color color)
        {
            this.spd = spd;
            this.color = color;
            this.inset = new Inset(2, 0, 3, 0);
        }

        public SpreadBorderMargin(FarPoint.Win.Spread.FpSpread spd, Color color, int RowIndex, int ColumnIndex)
        {
            this.spd = spd;
            this.color = color;
            this.inset = new Inset(2, 0, 3, 0);
            this.row = RowIndex;
            this.column = ColumnIndex;
        }

        public Color Color { get { return color; } }

        public FpSpread TargetSpd { get { return spd; } }

        public Inset Inset { get { return inset; } }

        public virtual void Paint(Graphics g, int x, int y, int width, int height)
        {
            int leftThick = inset.Left;
            int TopThick = inset.Top;
            int RightThick = inset.Right;
            int BottomThick = inset.Bottom;

            if (color.Name == "0")
            {
                this.color = Color.WhiteSmoke;
            }
            Pen pen = new Pen(color);

            for (int i = 0; i <= leftThick && i < width; i++)
                g.DrawLine(pen, x + i, y, x + i, y + height - 2);		//Left
            //for (int i = 0; i <= TopThick && i < height; i++)
            //    g.DrawLine(pen, x, y + i, x + width - 2, y + i);	//Top
            for (int i = 0; i <= RightThick && i < width; i++)
                g.DrawLine(pen, x + width - 2 - i, y, x + width - 2 - i, y + height - 2);		//Right
            //for (int i = 0; i <= BottomThick && i < height; i++)
            //    g.DrawLine(pen, x, y + height - 2 - i, x + width - 2, y + height - 2 - i);	//Bottom

            pen.Dispose();

            //for (int i = 0; i <= leftThick && i < width; i++)
            //    g.DrawLine(pen, x + i, y, x + i, y + height - 2);		//Left
            //for (int i = 0; i <= TopThick && i < height; i++)
            //    g.DrawLine(pen, x, y + i, x + width - 2, y + i);	//Top
            //for (int i = 0; i <= RightThick && i < width; i++)
            //    g.DrawLine(pen, x + width - 2 - i, y, x + width - 2 - i, y + height - 2);		//Right
            //for (int i = 0; i <= BottomThick && i < height; i++)
            //    g.DrawLine(pen, x, y + height - 2 - i, x + width - 2, y + height - 2 - i);	//Bottom
        }
    }
    public class SpreadTypes
    {

        public enum ActionType
        {
            Add = 0,
            Edit
        }

        public interface ISkinSupport
        {
            void ApplySpreadSkin(SpreadSkin skin);
            void ApplySheetSkin(SheetSkin skin);
        }

        public struct ActivePosition
        {
            int x, y;

            public ActivePosition(int row, int column)
            {
                x = row;
                y = column;
            }

            public int Row
            {
                get { return x; }
                set { x = value; }
            }

            public int Column
            {
                get { return y; }
                set { y = value; }
            }


        }

        public enum GroupMode
        {
            Managed = 0,
            Custom
        }
    }

}
