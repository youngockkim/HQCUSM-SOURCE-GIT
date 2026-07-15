using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FarPoint.Win.Spread;
using SOI.OIFrx.SOIControls;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;
using System.Windows.Forms;
using System.Data;
using FarPoint.Win.Spread.CellType;
using Miracom.CliFrx;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOISpread : FpSpread
    {
        #region Constant

        public enum ColTp : int
        {
            sLabel, iWidth, sKey, CelType, CelHalign, CelValign, CelMerge, bHide, bLock
        }

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
            HyperLinkCellType,
            ButtonCellType,
            ButtonCellTextType,
            ProgressCellType,
            MaskCellType,
            RichTextCellType,
            CustDateTimeCellType
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

        #endregion

        #region Variable

        bool IsUseRowFixHeader = true;

        private int intCololumnHeaderRowCount = 1;
        private int intCololumnHeaderColumnCount = 1;
        private int intRowHeaderColoumnCount = 1;
        private int intRowHeaderRowCount = 1;

        private bool boolColumnHederAutoSpan = true;
        private bool boolRowHeaderAutoSpan = true;

        private DataTable dtColumnSet = new DataTable();
        private DataTable dtRowSet = new DataTable();
        List<DataTable> lstDtRowSet = new List<DataTable>();
        List<int> lstWidth = new List<int>();

        string sLabel = string.Empty;
        int iWidth = 0;
        string sKey = string.Empty;
        SpreadCellType CelType = SpreadCellType.TextCellType;
        SpreadCellHAlign CelHalign = SpreadCellHAlign.Center;
        SpreadCellVAlign CelValign = SpreadCellVAlign.Center;
        SpreadCellMerge CelMerge = SpreadCellMerge.None;
        bool bHide = false;
        bool bLock = true;
        DataTable dtBlank = new DataTable();
        DataTable dtData = new DataTable();

        FarPoint.Win.Spread.CellType.TextCellType type_text = new FarPoint.Win.Spread.CellType.TextCellType();
        FarPoint.Win.Spread.CellType.ButtonCellType type_button_plus = new FarPoint.Win.Spread.CellType.ButtonCellType();
        FarPoint.Win.Spread.CellType.ButtonCellType type_button_minus = new FarPoint.Win.Spread.CellType.ButtonCellType();
        FarPoint.Win.Spread.CellType.ButtonCellType type_button = new ButtonCellType();
        FarPoint.Win.Spread.CellType.ComboBoxCellType type_combo = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
        FarPoint.Win.Spread.CellType.MaskCellType type_mask = new FarPoint.Win.Spread.CellType.MaskCellType();
        FarPoint.Win.Spread.CellType.NumberCellType type_number = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.CheckBoxCellType type_check = new CheckBoxCellType();
        FarPoint.Win.Spread.CellType.DateTimeCellType type_date = new FarPoint.Win.Spread.CellType.DateTimeCellType();
        public FarPoint.Win.Spread.CellType.TextCellType GetTypeText() { return type_text; }
        public FarPoint.Win.Spread.CellType.NumberCellType GetTypeNumber() { return type_number; }
        public FarPoint.Win.Spread.CellType.ComboBoxCellType GetTypeCombo() { return type_combo; }
        public FarPoint.Win.Spread.CellType.CheckBoxCellType GetTypeCheck() { return type_check; }
        public FarPoint.Win.Spread.CellType.ButtonCellType GetTypeButton() { return type_button; }
        public FarPoint.Win.Spread.CellType.DateTimeCellType GetTypeDate() { return type_date; }

        #endregion

        #region Property

        private SOIContextMenu textBoxContextMenu;

        private bool _useOITheme = true; // 최초 컨트롤 Add시 Default로 테마 적용
        public bool _UseOITheme
        {
            get
            {
                return _useOITheme;
            }
            set
            {
                _useOITheme = value;
                SetOITheme();
            }
        }

        private bool _useAutoHeight = true;
        public bool _UseAutoHeight
        {
            get
            {
                return _useAutoHeight;
            }
            set
            {
                _useAutoHeight = value;
                SetColumnHeaderHeight(SOIColumnHeight);
                SetCellHeight(SOICellHeight);
            }
        }

        private int soiColumnHeight = 30;
        public int SOIColumnHeight
        {
            get
            {
                return soiColumnHeight;
            }
            set
            {
                soiColumnHeight = value;
                if (_UseAutoHeight == true)
                {
                    SetColumnHeaderHeight(soiColumnHeight);
                }
            }
        }

        private int soiCellHeight = 25;
        public int SOICellHeight
        {
            get
            {
                return soiCellHeight;
            }
            set
            {
                soiCellHeight = value;
                if (_UseAutoHeight == true)
                {
                    SetCellHeight(soiCellHeight);
                }
            }
        }

        private bool useSOIContextMenu = true;
        public bool UseSOIContextMenu
        {
            get
            {
                return useSOIContextMenu;
            }
            set
            {
                useSOIContextMenu = value;
                SetContextMenu(useSOIContextMenu);
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

        /// <summary>
        /// Row Header를 Header형태로 사용할지 아니면 Row에 Fix시켜서 사용할지 유무를 결정
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool UseRowFixHeader
        {
            get { return IsUseRowFixHeader; }
            set { IsUseRowFixHeader = value; }
        }

        #endregion

        #region Constructor

        public SOISpread()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        //protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        //{
        //    // 디자인 모드에서만 적용
        //    if (DesignMode == true)
        //    {
        //        SetOITheme();
        //    }

        //    base.OnPaint(pe);
        //}

        private void SOISpread_RowChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            try
            {
                if (this._UseAutoHeight == true)
                {
                    if (this.Sheets.Count > 0)
                    {
                        if (this.Sheets[0].Rows.Count > 0)
                        {
                            this.Sheets[0].Rows[e.Row].Height = 25;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        private void textBoxContextMenu_BeforeToolDropdown(object sender, BeforeToolDropdownEventArgs e)
        {
            if (this.Sheets.Count > 0
                && this.Sheets[0].ActiveCell != null)
            {
                textBoxContextMenu.Tools["copyCell"].SharedProps.Enabled = true;
                textBoxContextMenu.Tools["copyRow"].SharedProps.Enabled = true;
            }
            else
            {
                textBoxContextMenu.Tools["copyCell"].SharedProps.Enabled = false;
                textBoxContextMenu.Tools["copyRow"].SharedProps.Enabled = false;
            }
        }

        private void textBoxContextMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            if (e.Tool.Key == "copyCell")
            {
                if (this.Sheets.Count > 0
                    && this.Sheets[0].ActiveCell != null)
                {
                    if (this.Sheets[0].ActiveCell.Value != null)
                    {
                        string sText = " ";
                        if (string.IsNullOrEmpty(this.Sheets[0].ActiveCell.Value.ToString()) == false)
                        {
                            sText = this.Sheets[0].ActiveCell.Value.ToString();
                        }

                        Clipboard.SetText(sText);
                    }
                }

                //if (ugcClickedCell != null)
                //{
                //    if (ugcClickedCell.Value != null)
                //    {
                //        if (string.IsNullOrEmpty(ugcClickedCell.Value.ToString()) == false)
                //        {
                //            Clipboard.SetText(ugcClickedCell.Value.ToString());
                //        }
                //    }
                //}
            }
            else if (e.Tool.Key == "copyRow")
            {
                if (this.Sheets.Count > 0
                    && this.Sheets[0].ActiveRow != null)
                {
                    if (this.Sheets[0].ActiveRow != null)
                    {
                        Clipboard.Clear();
                        string sText = string.Empty;
                        for (int i = 0; i < this.Sheets[0].Columns.Count; i++)
                        {
                            if (i == 0)
                            {
                                if (this.Sheets[0].Cells[this.Sheets[0].ActiveRowIndex, i].Value == null)
                                {
                                    sText = " ";
                                }
                                else
                                {
                                    sText = this.Sheets[0].Cells[this.Sheets[0].ActiveRowIndex, i].Value.ToString();
                                }
                            }
                            else
                            {
                                if (this.Sheets[0].Cells[this.Sheets[0].ActiveRowIndex, i].Value == null)
                                {
                                    sText = sText + "\t";
                                }
                                else
                                {
                                    sText = sText + "\t" + this.Sheets[0].Cells[this.Sheets[0].ActiveRowIndex, i].Value.ToString();
                                }
                            }
                        }

                        Clipboard.SetText(sText);
                    }
                }
            }
            else if (e.Tool.Key == "excelExport")
            {
                if (MPCF.ExportToExcel(this, "", "") == false)
                {
                    return;
                }
            }
        }

        #endregion

        #region Function

        public void InitializeSpread()
        {
            dtColumnSet = new DataTable();
            SetdtColSet();

            dtRowSet = new DataTable();
            SetdtRowSet();
            lstWidth = new List<int>();
        }

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public void SetOITheme()
        {
            if (_UseOITheme == true)
            {
                //// Skin
                //if (this.Skin == FarPoint.Win.Spread.DefaultSpreadSkins.Default)
                //{
                //    this.Skin.InterfaceRenderer
                //    FarPoint.Win.Spread.SpreadSkin newSkin = new FarPoint.Win.Spread.SpreadSkin();
                //    newSkin.ColumnFooterDefaultStyle = this.Skin.ColumnFooterDefaultStyle;
                //    newSkin.ColumnHeaderDefaultStyle = this.Skin.ColumnHeaderDefaultStyle;
                //    newSkin.CornerDefaultStyle = this.Skin.CornerDefaultStyle;
                //    newSkin.DefaultStyle = this.Skin.DefaultStyle;
                //    newSkin.FocusRenderer = new FarPoint.Win.Spread.SolidFocusIndicatorRenderer(MPGV.gTheme.SpreadColumnHeaderBackground, 1);
                //    FarPoint.Win.Spread.EnhancedInterfaceRenderer enhancedInterfaceRenderer1 = new FarPoint.Win.Spread.EnhancedInterfaceRenderer();
                //    enhancedInterfaceRenderer1.ScrollBoxBackgroundColor = MPGV.gTheme.SpreadBackground;
                //    newSkin.InterfaceRenderer = enhancedInterfaceRenderer1;
                //    newSkin.ScrollBarRenderer = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
                //    newSkin.Name = "SOISpreadSkin";
                //    this.Skin = newSkin;
                //}

                // 공통 속성
                this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                // 공통 색상
                this.BackColor = MOGV.gTheme.SpreadBackground;
                if (this.Sheets.Count > 0)
                {
                    //this.Sheets[0].ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;                    
                    this.Sheets[0].GrayAreaBackColor = MOGV.gTheme.SpreadBackground;

                    this.Sheets[0].ColumnHeader.DefaultStyle.BackColor = MOGV.gTheme.SpreadColumnHeaderBackground;
                    this.Sheets[0].ColumnHeader.DefaultStyle.ForeColor = MOGV.gTheme.SpreadColumnHeaderForeground;
                    this.Sheets[0].ColumnHeader.DefaultStyle.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold);
                    this.Sheets[0].ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);
                    this.Sheets[0].ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);

                    //this.Sheets[0].ColumnHeader.Rows[0].Height = 30;

                    this.Sheets[0].RowHeader.DefaultStyle.BackColor = MOGV.gTheme.SpreadColumnHeaderBackground;
                    this.Sheets[0].RowHeader.DefaultStyle.ForeColor = MOGV.gTheme.SpreadColumnHeaderForeground;
                    this.Sheets[0].RowHeader.DefaultStyle.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold);
                    this.Sheets[0].RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);
                    this.Sheets[0].RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);

                    //if (this.Sheets[0].Rows.Count > 0)
                    //{
                    //    this.Sheets[0].RowHeader.Rows[0].Height = 25;
                    //}

                    this.Sheets[0].SheetCorner.DefaultStyle.BackColor = MOGV.gTheme.SpreadColumnHeaderBackground;
                    this.Sheets[0].SheetCorner.DefaultStyle.ForeColor = MOGV.gTheme.SpreadColumnHeaderForeground;
                    this.Sheets[0].SheetCorner.DefaultStyle.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold);
                    this.Sheets[0].SheetCorner.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);
                    this.Sheets[0].SheetCorner.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);

                    this.Sheets[0].DefaultStyle.BackColor = MOGV.gTheme.SpreadBackground;
                    this.Sheets[0].DefaultStyle.ForeColor = MOGV.gTheme.SpreadCellForeground;
                    this.Sheets[0].DefaultStyle.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold);
                    this.Sheets[0].HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);
                    this.Sheets[0].VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, MOGV.gTheme.SpreadCellBorder, 1);

                    this.Sheets[0].SelectionBackColor = MOGV.gTheme.SpreadRowSelectedBackground;

                    this.Sheets[0].RowChanged += new SheetViewEventHandler(SOISpread_RowChanged);
                }
                if (this.HorizontalScrollBar != null
                    && this.HorizontalScrollBar.Renderer != null
                    && this.HorizontalScrollBar.Renderer is EnhancedScrollBarRenderer)
                {
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ArrowColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ArrowHoveredColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ArrowSelectedColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonBackgroundColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonBorderColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonHoveredBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonHoveredBorderColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonSelectedBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonSelectedBorderColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).TrackBarBackgroundColor = MOGV.gTheme.ControlCommonScrollBarBackground;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).TrackBarSelectedBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                }
                if (this.VerticalScrollBar != null
                    && this.VerticalScrollBar.Renderer != null
                    && this.VerticalScrollBar.Renderer is EnhancedScrollBarRenderer)
                {
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ArrowColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ArrowHoveredColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ArrowSelectedColor = MOGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonBackgroundColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonBorderColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonHoveredBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonHoveredBorderColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonSelectedBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonSelectedBorderColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).TrackBarBackgroundColor = MOGV.gTheme.ControlCommonScrollBarBackground;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).TrackBarSelectedBackgroundColor = MOGV.gTheme.ControlCommonScrollBarSelectedColor;
                }
                if (this.Skin != null
                    && this.Skin.InterfaceRenderer != null
                    && this.Skin.InterfaceRenderer is EnhancedInterfaceRenderer)
                {
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).ScrollBoxBackgroundColor = MOGV.gTheme.SpreadBackground;
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).SplitBoxBackgroundColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).SplitBoxBorderColor = MOGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).SplitBarBackgroundColor = MOGV.gTheme.SpreadCellBorder;
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).SplitBarDarkColor = MOGV.gTheme.SpreadCellBorder;
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).SplitBarLightColor = MOGV.gTheme.SpreadCellBorder;
                }
            }
        }

        /// <summary>
        /// Column Header의 Height를 조절합니다.
        /// 기본적으로 30의 크기를 사용합니다.
        /// </summary>
        /// <param name="height"></param>
        public void SetColumnHeaderHeight(int height)
        {
            try
            {
                if (this.Sheets.Count > 0)
                {
                    if (this.Sheets[0].ColumnHeader.Rows.Count > 0)
                    {
                        if (height > 0)
                        {
                            this.Sheets[0].ColumnHeader.Rows[0].Height = height;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Cell의 Height를 조절합니다.
        /// 기본적으로 25의 크기를 사용합니다.
        /// </summary>
        /// <param name="height"></param> 
        public void SetCellHeight(int height)
        {
            try
            {
                if (this.Sheets.Count > 0)
                {
                    if (this.Sheets[0].RowHeader.Rows.Count > 0)
                    {
                        foreach (FarPoint.Win.Spread.Row row in this.Sheets[0].RowHeader.Rows)
                        {
                            if (height > 0)
                            {
                                row.Height = height;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Context Menu를 설정합니다.
        /// </summary>
        /// <param name="enable"></param>
        public void SetContextMenu(bool bUse)
        {
            // 사용하는 경우
            if (bUse == true)
            {
                // Context Menu 초기화
                if (textBoxContextMenu == null)
                {
                    textBoxContextMenu = new SOIContextMenu();

                    // Tool Button 할당
                    textBoxContextMenu.SetTools(this);

                    // Context Meu 할당
                    textBoxContextMenu.SetContextMenuUltra(this, MOGC.CONTROL_CONTEXT_MENU_KEY);

                    // Event Handler 등록
                    textBoxContextMenu.BeforeToolDropdown += new BeforeToolDropdownEventHandler(textBoxContextMenu_BeforeToolDropdown);
                    textBoxContextMenu.ToolClick += new ToolClickEventHandler(textBoxContextMenu_ToolClick);
                }
            }
            // 사용하지 않는 경우
            else
            {
                textBoxContextMenu.Dispose();
            }
        }

        #region Make Spread Header
        public void MakeSpreadColHeader(ref SOISpread spd, DataTable tblData, object[,] oCol)
        {
            MakeSpreadColHeader(ref spd, tblData, oCol, 1);
        }
        public void MakeSpreadColHeader(ref SOISpread spd, DataTable tblData, object[,] oCol, int iColHRowCnt)
        {
            MakeSpreadColHeader(ref spd, tblData, oCol, iColHRowCnt, true);
        }
        public void MakeSpreadColHeader(ref SOISpread spd, DataTable tblData, object[,] oCol, int iColHRowCnt, bool bColumnHeaderSpan)
        {
            try
            {
                spd.Tag = "Change Header";

                spd.InitializeSpread();
                spd.SpreadDataSourceSet(ref spd, tblData);
                //sprMaker1.InitializeSpread();
                spd.iColHRowCnt = iColHRowCnt;

                if (oCol != null)
                {
                    if (oCol.GetLongLength(0) > 0)
                    {
                        for (int iCol = 0; iCol < oCol.GetLongLength(0); iCol++)
                        {
                            sLabel = oCol[iCol, (int)ColTp.sLabel].ToString();
                            iWidth = Convert.ToInt32(oCol[iCol, (int)ColTp.iWidth].ToString());
                            sKey = oCol[iCol, (int)ColTp.sKey].ToString();
                            CelType = (SpreadCellType)oCol[iCol, (int)ColTp.CelType];
                            CelHalign = (SpreadCellHAlign)oCol[iCol, (int)ColTp.CelHalign];
                            CelValign = (SpreadCellVAlign)oCol[iCol, (int)ColTp.CelValign];
                            CelMerge = (SpreadCellMerge)oCol[iCol, (int)ColTp.CelMerge];
                            bHide = (bool)oCol[iCol, (int)ColTp.bHide];
                            bLock = (bool)oCol[iCol, (int)ColTp.bLock];
                            spd.ColumnAdd(sLabel, iWidth, sKey, CelType, CelHalign, CelValign, CelMerge, bHide, bLock);
                        }
                    }
                }
                spd.bColumnHederAutoSpan = bColumnHeaderSpan; //false;
                spd.SetSpSheet(ref spd);
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return;
            }
        }


        ///// <summary>
        ///// 스프레드 칼럼 정의 및 데이터 표시
        ///// </summary>
        ///// <param name="fpSpd"></param>
        ///// <param name="tblData"></param>
        ///// <param name="oCol"></param>
        ///// <returns></returns>
        //public bool MakeSpreadColHeader(ref SOISpread spd, DataTable tblData, object[,] oCol, int i_row)
        //{
        //    DataTable dtColumn = new DataTable();
        //    int iColumnHeaderRow = i_row;

        //    try
        //    {
        //        fpSpd.Sheets[0].DataSource = tblData;
        //        fpSpd.Sheets[0].RowCount = 0;
        //        fpSpd.Sheets[0].ColumnHeader.Columns.Count = -1;
        //        fpSpd.Sheets[0].ColumnHeader.Rows[0].Height = 40;
        //        dtData = new DataTable();

        //        dtColumn.TableName = "SetColumnProperty";
        //        dtColumn.Columns.Add(ColumnProperty.LABEL.ToString(), typeof(string));
        //        dtColumn.Columns.Add(ColumnProperty.WIDTH.ToString(), typeof(int));
        //        dtColumn.Columns.Add(ColumnProperty.FIELD.ToString(), typeof(string));
        //        dtColumn.Columns.Add(ColumnProperty.TYPE.ToString(), typeof(string));
        //        dtColumn.Columns.Add(ColumnProperty.HALIGN.ToString(), typeof(string));
        //        dtColumn.Columns.Add(ColumnProperty.VALIGN.ToString(), typeof(string));
        //        dtColumn.Columns.Add(ColumnProperty.MERGE.ToString(), typeof(string));
        //        dtColumn.Columns.Add(ColumnProperty.HIDE.ToString(), typeof(bool));
        //        dtColumn.Columns.Add(ColumnProperty.LOCK.ToString(), typeof(bool));

        //        if (oCol != null)
        //        {
        //            if (oCol.GetLongLength(0) > 0)
        //            {
        //                for (int iCol = 0; iCol < oCol.GetLongLength(0); iCol++)
        //                {
        //                    sLabel = oCol[iCol, (int)ColTp.sLabel].ToString();
        //                    iWidth = Convert.ToInt32(oCol[iCol, (int)ColTp.iWidth].ToString());
        //                    sKey = oCol[iCol, (int)ColTp.sKey].ToString();
        //                    CelType = (SOISpread.SpreadCellType)oCol[iCol, (int)ColTp.CelType];
        //                    CelHalign = (SOISpread.SpreadCellHAlign)oCol[iCol, (int)ColTp.CelHalign];
        //                    CelValign = (SOISpread.SpreadCellVAlign)oCol[iCol, (int)ColTp.CelValign];
        //                    CelMerge = (SOISpread.SpreadCellMerge)oCol[iCol, (int)ColTp.CelMerge];
        //                    bHide = (bool)oCol[iCol, (int)ColTp.bHide];
        //                    bLock = (bool)oCol[iCol, (int)ColTp.bLock];
        //                    dtColumn.Rows.Add(sLabel, iWidth, sKey, CelType, CelHalign, CelValign, CelMerge, bHide, bLock);

        //                    dtData.Columns.Add(sKey);
        //                }
        //            }
        //        }

        //        fpSpd.Sheets[0].ColumnHeader.Rows.Count = iColumnHeaderRow;
        //        fpSpd.Sheets[0].ColumnHeader.Columns.Count = dtColumn.Rows.Count;
        //        fpSpd.Sheets[0].Protect = true;

        //        //ColumnHeader의 Row를 iHeaderRowCnt만큼 생성한다.
        //        for (int hRowCnt = 0; hRowCnt < iColumnHeaderRow; hRowCnt++)
        //        {
        //            for (int iCnt = 0; iCnt < dtColumn.Rows.Count; iCnt++)
        //            {
        //                for (int jCnt = 0; jCnt < dtColumn.Columns.Count; jCnt++)
        //                {
        //                    #region //LABEL
        //                    //Column Header 에 적용
        //                    if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.LABEL.ToString())
        //                    {

        //                        if (dtColumn.Rows[iCnt][ColumnProperty.LABEL.ToString()].ToString() != "")
        //                        {
        //                            fpSpd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = dtColumn.Rows[iCnt][ColumnProperty.LABEL.ToString()];
        //                        }
        //                        else
        //                        {
        //                            fpSpd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = "";
        //                        }

        //                    }
        //                    #endregion

        //                    #region //WIDTH
        //                    //Column Header 에 적용
        //                    if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.WIDTH.ToString())
        //                    {
        //                        int idefwidth = 60;
        //                        int iwidth = 0;

        //                        if (Int32.TryParse(dtColumn.Rows[iCnt][ColumnProperty.WIDTH.ToString()].ToString(), out iwidth))
        //                        {
        //                            if (iwidth < 1) { iwidth = idefwidth; }
        //                            fpSpd.Sheets[0].ColumnHeader.Columns[iCnt].Width = iwidth;
        //                        }
        //                        else
        //                        {
        //                            fpSpd.Sheets[0].ColumnHeader.Columns[iCnt].Width = idefwidth;
        //                        }
        //                    }
        //                    #endregion

        //                    #region //FIELD
        //                    //Column에 적용
        //                    if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.FIELD.ToString())
        //                    {
        //                        if (dtColumn.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString() != "")
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].DataField = dtColumn.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString();
        //                        }
        //                    }
        //                    #endregion

        //                    #region //TYPE
        //                    //Column에 적용
        //                    if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.TYPE.ToString())
        //                    {
        //                        if (dtColumn.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString() != "")
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].CellType = TakeCellType(dtColumn.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString());
        //                        }
        //                        else
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].CellType = TakeCellType(SpreadCellType.TextCellType.ToString());
        //                        }
        //                    }
        //                    #endregion

        //                    #region //HALIGN
        //                    //Column에 적용
        //                    if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.HALIGN.ToString())
        //                    {
        //                        if (dtColumn.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString() != "")
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].HorizontalAlignment = TakeCellHAlign(dtColumn.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString());
        //                        }
        //                        else
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].HorizontalAlignment = CellHorizontalAlignment.Left;
        //                        }
        //                    }
        //                    #endregion

        //                    #region //VALIGN
        //                    //Column에 적용
        //                    if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.VALIGN.ToString())
        //                    {
        //                        if (dtColumn.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString() != "")
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].VerticalAlignment = TakeCellVAlign(dtColumn.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString());
        //                        }
        //                        else
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].VerticalAlignment = CellVerticalAlignment.Center;
        //                        }
        //                    }
        //                    #endregion

        //                    #region //MERGE
        //                    //Column에 적용
        //                    if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.MERGE.ToString())
        //                    {
        //                        if (dtColumn.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString() != "")
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].MergePolicy = TakeMergePolicy(dtColumn.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString());
        //                        }
        //                        else
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
        //                        }
        //                    }
        //                    #endregion

        //                    #region //HIDE
        //                    //Column에 적용
        //                    if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.HIDE.ToString())
        //                    {
        //                        if (dtColumn.Rows[iCnt][ColumnProperty.HIDE.ToString()].ToString() != "")
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].Visible = !((bool)dtColumn.Rows[iCnt][ColumnProperty.HIDE.ToString()]);
        //                            //HIDE : Visible 이므로 속성값의 반대로 세팅
        //                        }
        //                        else
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].Visible = true;
        //                        }
        //                    }
        //                    #endregion

        //                    #region //LOCK
        //                    //Column에 적용
        //                    if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.LOCK.ToString())
        //                    {
        //                        if (dtColumn.Rows[iCnt][ColumnProperty.LOCK.ToString()].ToString() != "")
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].Locked = (bool)dtColumn.Rows[iCnt][ColumnProperty.LOCK.ToString()];
        //                        }
        //                        else
        //                        {
        //                            fpSpd.Sheets[0].Columns[iCnt].Locked = false;
        //                        }
        //                    }
        //                    #endregion
        //                }
        //            }
        //        }

        //        fpSpd.Sheets[0].DataSource = dtData;

        //        fpSpd.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
        //        fpSpd.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
        //        //fpSpd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spdData_MouseMove);
        //        //fpSpd.ScrollTipFetch += new ScrollTipFetchEventHandler(this.spdData_ScrollTipFetch);
        //        //fpSpd.TopChange += new FarPoint.Win.Spread.TopChangeEventHandler(this.spdData_TopChange);
        //        //fpSpd.LeftChange += new FarPoint.Win.Spread.LeftChangeEventHandler(this.spdData_LeftChange);

        //        //MPCF.ConvertMessage(this.Controls);

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //        return false;
        //    }
        //}

        /// <summary>
        /// 스프레드 칼럼 정의 및 데이터 표시
        /// </summary>
        /// <param name="fpSpd"></param>
        /// <param name="tblData"></param>
        /// <param name="oCol"></param>
        /// <returns></returns>
        public bool MakeSpreadColHeader(ref SOISpread fpSpd, DataTable tblData, List<object[]> oCol, int i_row)
        {
            DataTable dtColumn = new DataTable();
            int iColumnHeaderRow = i_row;

            try
            {
                fpSpd.Sheets[0].DataSource = tblData;
                fpSpd.Sheets[0].RowCount = 0;
                fpSpd.Sheets[0].ColumnHeader.Columns.Count = -1;
                fpSpd.Sheets[0].ColumnHeader.Rows[0].Height = 30;
                dtData = new DataTable();

                dtColumn.TableName = "SetColumnProperty";
                dtColumn.Columns.Add(ColumnProperty.LABEL.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.WIDTH.ToString(), typeof(int));
                dtColumn.Columns.Add(ColumnProperty.FIELD.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.TYPE.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.HALIGN.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.VALIGN.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.MERGE.ToString(), typeof(string));
                dtColumn.Columns.Add(ColumnProperty.HIDE.ToString(), typeof(bool));
                dtColumn.Columns.Add(ColumnProperty.LOCK.ToString(), typeof(bool));

                if (oCol != null)
                {
                    if (oCol.Count > 0)
                    {
                        for (int iCol = 0; iCol < oCol.Count; iCol++)
                        {
                            sLabel = MPOF.Trim(oCol[iCol].GetValue((int)ColTp.sLabel));
                            iWidth = Convert.ToInt32(MPOF.Trim(oCol[iCol].GetValue((int)ColTp.iWidth)));
                            sKey = MPOF.Trim(oCol[iCol].GetValue((int)ColTp.sKey));
                            CelType = (SOISpread.SpreadCellType)oCol[iCol].GetValue((int)ColTp.CelType);
                            CelHalign = (SOISpread.SpreadCellHAlign)oCol[iCol].GetValue((int)ColTp.CelHalign);
                            CelValign = (SOISpread.SpreadCellVAlign)oCol[iCol].GetValue((int)ColTp.CelValign);
                            CelMerge = (SOISpread.SpreadCellMerge)oCol[iCol].GetValue((int)ColTp.CelMerge);
                            bHide = (bool)oCol[iCol].GetValue((int)ColTp.bHide);
                            bLock = (bool)oCol[iCol].GetValue((int)ColTp.bLock);
                            dtColumn.Rows.Add(sLabel, iWidth, sKey, CelType, CelHalign, CelValign, CelMerge, bHide, bLock);

                            dtData.Columns.Add(sKey);
                        }
                    }
                }

                fpSpd.Sheets[0].ColumnHeader.Rows.Count = iColumnHeaderRow;
                fpSpd.Sheets[0].ColumnHeader.Columns.Count = dtColumn.Rows.Count;
                fpSpd.Sheets[0].Protect = true;

                //ColumnHeader의 Row를 iHeaderRowCnt만큼 생성한다.
                for (int hRowCnt = 0; hRowCnt < iColumnHeaderRow; hRowCnt++)
                {
                    for (int iCnt = 0; iCnt < dtColumn.Rows.Count; iCnt++)
                    {
                        for (int jCnt = 0; jCnt < dtColumn.Columns.Count; jCnt++)
                        {
                            #region //LABEL
                            //Column Header 에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.LABEL.ToString())
                            {

                                if (dtColumn.Rows[iCnt][ColumnProperty.LABEL.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = dtColumn.Rows[iCnt][ColumnProperty.LABEL.ToString()];
                                }
                                else
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = "";
                                }

                            }
                            #endregion

                            #region //WIDTH
                            //Column Header 에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.WIDTH.ToString())
                            {
                                int idefwidth = 60;
                                int iwidth = 0;

                                if (Int32.TryParse(dtColumn.Rows[iCnt][ColumnProperty.WIDTH.ToString()].ToString(), out iwidth))
                                {
                                    if (iwidth < 1) { iwidth = idefwidth; }
                                    fpSpd.Sheets[0].ColumnHeader.Columns[iCnt].Width = iwidth;
                                }
                                else
                                {
                                    fpSpd.Sheets[0].ColumnHeader.Columns[iCnt].Width = idefwidth;
                                }
                            }
                            #endregion

                            #region //FIELD
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.FIELD.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].DataField = dtColumn.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString();
                                }
                            }
                            #endregion

                            #region //TYPE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.TYPE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].CellType = TakeCellType(dtColumn.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].CellType = TakeCellType(SpreadCellType.TextCellType.ToString());
                                }
                            }
                            #endregion

                            #region //HALIGN
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.HALIGN.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].HorizontalAlignment = TakeCellHAlign(dtColumn.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].HorizontalAlignment = CellHorizontalAlignment.Left;
                                }
                            }
                            #endregion

                            #region //VALIGN
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.VALIGN.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].VerticalAlignment = TakeCellVAlign(dtColumn.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].VerticalAlignment = CellVerticalAlignment.Center;
                                }
                            }
                            #endregion

                            #region //MERGE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.MERGE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].MergePolicy = TakeMergePolicy(dtColumn.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString());
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
                                }
                            }
                            #endregion

                            #region //HIDE
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.HIDE.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.HIDE.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Visible = !((bool)dtColumn.Rows[iCnt][ColumnProperty.HIDE.ToString()]);
                                    //HIDE : Visible 이므로 속성값의 반대로 세팅
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Visible = true;
                                }
                            }
                            #endregion

                            #region //LOCK
                            //Column에 적용
                            if (dtColumn.Columns[jCnt].ColumnName == ColumnProperty.LOCK.ToString())
                            {
                                if (dtColumn.Rows[iCnt][ColumnProperty.LOCK.ToString()].ToString() != "")
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Locked = (bool)dtColumn.Rows[iCnt][ColumnProperty.LOCK.ToString()];
                                }
                                else
                                {
                                    fpSpd.Sheets[0].Columns[iCnt].Locked = false;
                                }
                            }
                            #endregion
                        }
                    }
                }

                fpSpd.Sheets[0].DataSource = dtData;

                fpSpd.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
                fpSpd.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
                //fpSpd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spdData_MouseMove);
                //fpSpd.ScrollTipFetch += new ScrollTipFetchEventHandler(this.spdData_ScrollTipFetch);

                //MPCF.ConvertMessage(this.Controls);

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        #endregion

        #region Set Spread DataSource

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

        public void SpreadDataSourceSet(ref SOISpread spd, DataSet ds)
        {
            if (ds == null)
            {
                spd.Sheets[0].DataSource = null;
                if (spd.Sheets[0].Rows.Count > 0) spd.Sheets[0].Rows.Count = 0;
                if (spd.Sheets[0].Columns.Count > 0) spd.Sheets[0].Columns.Count = 0;
            }
            else
            {
                if (spd.Sheets[0].Rows.Count > 0) spd.Sheets[0].Rows.Count = 0;
                if (spd.Sheets[0].Columns.Count > 0) spd.Sheets[0].Columns.Count = 0;
                spd.SuspendLayout();
                spd.Sheets[0].DataSource = ds;
                spd.ResumeLayout();
            }
        }

        public void SpreadDataSourceSet(ref SOISpread spd, DataTable dt)
        {

            if (spd.Sheets[0].Rows.Count > 0) spd.Sheets[0].Rows.Clear();
            if (spd.Sheets[0].Columns.Count > 0) spd.Sheets[0].Columns.Clear();

            try
            {
                spd.SuspendLayout();
                spd.Sheets[0].DataSource = dt;
                spd.ResumeLayout();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        #endregion

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
        public void ColumnAdd(string Label, int Width, string DataField, SpreadCellType cellType, SpreadCellHAlign hAlign, SpreadCellVAlign vAlign, SpreadCellMerge Merge, bool Hide, bool Lock)
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

        #region Spread & Sheet Set

        public void SetColumWidth(ref SOISpread spd)
        {
            for (int i = 0; i < lstWidth.Count; i++)
            {
                spd.Sheets[0].Columns[i].Width = lstWidth[i];
            }
        }

        public void SetSpSheet(ref SOISpread spd)
        {
            SetSpSheetColumn(ref spd);
            SetSpSheetRow(ref spd);
            //SpreadCellPadding(TargetSpd);	

            SetColumWidth(ref spd); // 새로추가 seoio 2009.11.18
        }

        public void SetSpSheetColumn(ref SOISpread spd)
        {
            //Working Target Setting
            if (spd == null) return;
            if (spd.Sheets[0] == null) return;
            if (dtColumnSet.Rows.Count < 1) { return; }

            //ColumnHeader의 Row Count
            int iHeaderRowCnt = intCololumnHeaderRowCount;
            //Column Header Column Count
            int iHeaderColCnt = dtColumnSet.Rows.Count;
            //Column Header Count Setting
            spd.Sheets[0].ColumnHeader.Rows.Count = iHeaderRowCnt;
            spd.Sheets[0].ColumnHeader.Columns.Count = iHeaderColCnt;
            //The Protect property must be set to true if you want the cells to be locked from user input.
            spd.Sheets[0].Protect = true;

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
                                spd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = dtColumnSet.Rows[iCnt][ColumnProperty.LABEL.ToString()];
                            }
                            else
                            {
                                spd.Sheets[0].ColumnHeader.Cells.Get(hRowCnt, iCnt).Value = "";
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
                                spd.Sheets[0].ColumnHeader.Columns[iCnt].Width = iwidth;
                            }
                            else
                            {
                                spd.Sheets[0].ColumnHeader.Columns[iCnt].Width = idefwidth;
                            }
                        }
                        #endregion

                        #region //FIELD
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.FIELD.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString() != "")
                            {
                                spd.Sheets[0].Columns[iCnt].DataField = dtColumnSet.Rows[iCnt][ColumnProperty.FIELD.ToString()].ToString();
                            }
                        }
                        #endregion

                        #region //TYPE
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.TYPE.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString() != "")
                            {
                                spd.Sheets[0].Columns[iCnt].CellType = TakeCellType(dtColumnSet.Rows[iCnt][ColumnProperty.TYPE.ToString()].ToString());
                            }
                            else
                            {
                                spd.Sheets[0].Columns[iCnt].CellType = TakeCellType(SpreadCellType.TextCellType.ToString());
                            }
                        }
                        #endregion

                        #region //HALIGN
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.HALIGN.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString() != "")
                            {
                                spd.Sheets[0].Columns[iCnt].HorizontalAlignment = TakeCellHAlign(dtColumnSet.Rows[iCnt][ColumnProperty.HALIGN.ToString()].ToString());
                            }
                            else
                            {
                                spd.Sheets[0].Columns[iCnt].HorizontalAlignment = CellHorizontalAlignment.Left;
                            }
                        }
                        #endregion

                        #region //VALIGN
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.VALIGN.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString() != "")
                            {
                                spd.Sheets[0].Columns[iCnt].VerticalAlignment = TakeCellVAlign(dtColumnSet.Rows[iCnt][ColumnProperty.VALIGN.ToString()].ToString());
                            }
                            else
                            {
                                spd.Sheets[0].Columns[iCnt].VerticalAlignment = CellVerticalAlignment.Center;
                            }
                        }
                        #endregion

                        #region //MERGE
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.MERGE.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString() != "")
                            {
                                spd.Sheets[0].Columns[iCnt].MergePolicy = TakeMergePolicy(dtColumnSet.Rows[iCnt][ColumnProperty.MERGE.ToString()].ToString());
                            }
                            else
                            {
                                spd.Sheets[0].Columns[iCnt].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
                            }
                        }
                        #endregion

                        #region //HIDE
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.HIDE.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.HIDE.ToString()].ToString() != "")
                            {
                                spd.Sheets[0].Columns[iCnt].Visible = !((bool)dtColumnSet.Rows[iCnt][ColumnProperty.HIDE.ToString()]);
                                //HIDE : Visible 이므로 속성값의 반대로 세팅
                            }
                            else
                            {
                                spd.Sheets[0].Columns[iCnt].Visible = true;
                            }
                        }
                        #endregion

                        #region //LOCK
                        //Column에 적용
                        if (dtColumnSet.Columns[jCnt].ColumnName == ColumnProperty.LOCK.ToString())
                        {
                            if (dtColumnSet.Rows[iCnt][ColumnProperty.LOCK.ToString()].ToString() != "")
                            {
                                spd.Sheets[0].Columns[iCnt].Locked = (bool)dtColumnSet.Rows[iCnt][ColumnProperty.LOCK.ToString()];
                            }
                            else
                            {
                                spd.Sheets[0].Columns[iCnt].Locked = false;
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
                        spd.Sheets[0].ColumnHeader.Cells[0, iCnt].RowSpan = hRowCnt + 1;
                    }
                }
            }
        }

        public void SetSpSheetRow(ref SOISpread spd)
        {
            if (spd == null) { return; }
            if (spd.Sheets[0] == null) { return; }
            if (dtRowSet.Rows.Count < 1) { return; }

            //RowHeader의 Row Count
            int iHeaderRowCnt = iRowHRowCnt;
            //RowHeader Column Count
            int iHeaderColCnt = lstDtRowSet.Count;
            //RowHeader Count Setting
            spd.Sheets[0].RowHeader.Rows.Count = iHeaderRowCnt;
            spd.Sheets[0].RowHeader.Columns.Count = ((UseRowFixHeader == true) ? iHeaderColCnt : 1);   //RowHeader 사용여부에 따라 값세팅
            //The Protect property must be set to true if you want the cells to be locked from user input.
            spd.Sheets[0].Protect = true;


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
                                        spd.Sheets[0].RowHeader.Cells.Get(iCnt, hRowCnt).Value = tblColumn.Rows[iCnt][RowProperty.LABEL.ToString()];
                                    }
                                    else
                                    {
                                        spd.Sheets[0].RowHeader.Cells.Get(iCnt, hRowCnt).Value = "";
                                    }
                                }
                                //RowHeader를 Row에 Fix시켜서 사용
                                else
                                {
                                    if (tblColumn.Rows[iCnt][RowProperty.LABEL.ToString()].ToString() != "")
                                    {
                                        spd.Sheets[0].Cells.Get(iCnt, hRowCnt).Value = tblColumn.Rows[iCnt][RowProperty.LABEL.ToString()];
                                    }
                                    else
                                    {
                                        spd.Sheets[0].Cells.Get(iCnt, hRowCnt).Value = "";
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
                                    spd.Sheets[0].Rows[iCnt].Height = iheight;
                                }
                                else
                                {
                                    spd.Sheets[0].Rows[iCnt].Height = idefheight;
                                }
                            }
                            #endregion

                            #region //HALIGN
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.HALIGN.ToString())
                            {
                                if (tblColumn.Rows[iCnt][RowProperty.HALIGN.ToString()].ToString() != "")
                                {
                                    spd.Sheets[0].Rows[iCnt].HorizontalAlignment = TakeCellHAlign(tblColumn.Rows[iCnt][RowProperty.HALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    spd.Sheets[0].Rows[iCnt].HorizontalAlignment = CellHorizontalAlignment.Center;
                                }
                            }
                            #endregion

                            #region //VALIGN
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.VALIGN.ToString())
                            {
                                if (tblColumn.Rows[iCnt][RowProperty.VALIGN.ToString()].ToString() != "")
                                {
                                    spd.Sheets[0].Rows[iCnt].VerticalAlignment
                                            = TakeCellVAlign(tblColumn.Rows[iCnt][RowProperty.VALIGN.ToString()].ToString());
                                }
                                else
                                {
                                    spd.Sheets[0].Rows[iCnt].VerticalAlignment = CellVerticalAlignment.Center;
                                }
                            }
                            #endregion

                            #region //MERGE
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.MERGE.ToString())
                            {
                                if (tblColumn.Rows[iCnt][RowProperty.MERGE.ToString()].ToString() != "")
                                {
                                    spd.Sheets[0].Rows[iCnt].MergePolicy = TakeMergePolicy(tblColumn.Rows[iCnt][RowProperty.MERGE.ToString()].ToString());
                                }
                                else
                                {
                                    spd.Sheets[0].Rows[iCnt].MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.None;
                                }
                            }
                            #endregion

                            #region //HIDE
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.HIDE.ToString())
                            {
                                if (tblColumn.Rows[iCnt][RowProperty.HIDE.ToString()].ToString() != "")
                                {
                                    spd.Sheets[0].Rows[iCnt].Visible = !((bool)tblColumn.Rows[iCnt][RowProperty.HIDE.ToString()]);
                                    //HIDE : Visible 이므로 속성값의 반대로 세팅
                                }
                                else
                                {
                                    spd.Sheets[0].Rows[iCnt].Visible = true;
                                }
                            }
                            #endregion

                            #region //LOCK
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.LOCK.ToString())
                            {
                                if (tblColumn.Rows[iCnt][RowProperty.LOCK.ToString()].ToString() != "")
                                {
                                    spd.Sheets[0].Rows[iCnt].Locked = (bool)tblColumn.Rows[iCnt][RowProperty.LOCK.ToString()];
                                }
                                else
                                {
                                    spd.Sheets[0].Rows[iCnt].Locked = false;
                                }
                            }
                            #endregion

                            #region //WIDTH
                            //Row에 적용
                            if (tblColumn.Columns[jCnt].ColumnName == RowProperty.WIDTH.ToString())
                            {
                                spd.Sheets[0].RowHeader.Columns[i].Width = int.Parse(tblColumn.Rows[iCnt][RowProperty.WIDTH.ToString()].ToString());
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
                                spd.Sheets[0].RowHeader.Cells[iCnt, 0].ColumnSpan = hRowCnt + 1;
                            }
                            else
                            {
                                spd.Sheets[0].Cells[iCnt, 0].ColumnSpan = hRowCnt + 1;
                            }
                        }
                    }
                }
            }

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
                doublecelltype.DecimalPlaces = 5;
                doublecelltype.Separator = ",";
                doublecelltype.MaximumValue = 999999999999.99999;
                doublecelltype.ShowSeparator = true;
                doublecelltype.DecimalSeparator = ".";
                doublecelltype.FixedPoint = false;

                _celltype = doublecelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.DateTimeCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.DateTimeCellType datepartcelltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                datepartcelltype.DateSeparator = "/";
                datepartcelltype.DateTimeFormat = DateTimeFormat.UserDefined;
                datepartcelltype.UserDefinedFormat = "yyyy/MM/dd";
                datepartcelltype.SpinButton = true;

                _celltype = datepartcelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.LongDateTimeCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.DateTimeCellType datefullcelltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                datefullcelltype.DateSeparator = "/";
                datefullcelltype.DateTimeFormat = DateTimeFormat.UserDefined;
                datefullcelltype.UserDefinedFormat = "yyyy/MM/dd HH:mm:ss";
                datefullcelltype.SpinButton = true;

                _celltype = datefullcelltype;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.CustDateTimeCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.DateTimeCellType datefullcelltype = new FarPoint.Win.Spread.CellType.DateTimeCellType();
                datefullcelltype.DateSeparator = "/";
                datefullcelltype.DateTimeFormat = DateTimeFormat.UserDefined;
                datefullcelltype.UserDefinedFormat = "yyyy/MM/dd HH:mm";
                datefullcelltype.SpinButton = true;

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
            else if (type.Trim().ToUpper() == SpreadCellType.ButtonCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType = new FarPoint.Win.Spread.CellType.ButtonCellType();

                _celltype = buttonCellType;
                buttonCellType.Text = "...";
            }
            else if (type.Trim().ToUpper() == SpreadCellType.ButtonCellTextType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.ButtonCellType buttonCellTextType = new FarPoint.Win.Spread.CellType.ButtonCellType();

                _celltype = buttonCellTextType;
                buttonCellTextType.Text = "작업문서 시작";
            }
            else if (type.Trim().ToUpper() == SpreadCellType.ProgressCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.ProgressCellType progressCellType = new FarPoint.Win.Spread.CellType.ProgressCellType();

                _celltype = progressCellType;
            }
            else if (type.Trim().ToUpper() == SpreadCellType.RichTextCellType.ToString().ToUpper())
            {
                FarPoint.Win.Spread.CellType.TextCellType richtextCellType = new FarPoint.Win.Spread.CellType.TextCellType();

                richtextCellType.WordWrap = true;
                _celltype = richtextCellType;
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
    }
}
