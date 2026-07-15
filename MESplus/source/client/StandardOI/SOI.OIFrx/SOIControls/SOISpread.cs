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

namespace SOI.OIFrx.SOIControls
{
    public partial class SOISpread : FpSpread
    {
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
                if(_UseAutoHeight == true)
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
                if(_UseAutoHeight == true)
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
                MPCF.ShowMessage(ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
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
        }

        #endregion

        #region Function

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
                this.BackColor = MPGV.gTheme.SpreadBackground;                
                if(this.Sheets.Count > 0)
                {
                    //this.Sheets[0].ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;                    
                    this.Sheets[0].GrayAreaBackColor = MPGV.gTheme.SpreadBackground;

                    this.Sheets[0].ColumnHeader.DefaultStyle.BackColor = MPGV.gTheme.SpreadColumnHeaderBackground;
                    this.Sheets[0].ColumnHeader.DefaultStyle.ForeColor = MPGV.gTheme.SpreadColumnHeaderForeground;
                    this.Sheets[0].ColumnHeader.DefaultStyle.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold);
                    this.Sheets[0].ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, 1);
                    this.Sheets[0].ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, 1);

                    //this.Sheets[0].ColumnHeader.Rows[0].Height = 30;

                    this.Sheets[0].RowHeader.DefaultStyle.BackColor = MPGV.gTheme.SpreadColumnHeaderBackground;
                    this.Sheets[0].RowHeader.DefaultStyle.ForeColor = MPGV.gTheme.SpreadColumnHeaderForeground;
                    this.Sheets[0].RowHeader.DefaultStyle.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold);
                    this.Sheets[0].RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, 1);
                    this.Sheets[0].RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, 1);

                    //if (this.Sheets[0].Rows.Count > 0)
                    //{
                    //    this.Sheets[0].RowHeader.Rows[0].Height = 25;
                    //}

                    this.Sheets[0].SheetCorner.DefaultStyle.BackColor = MPGV.gTheme.SpreadColumnHeaderBackground;
                    this.Sheets[0].SheetCorner.DefaultStyle.ForeColor = MPGV.gTheme.SpreadColumnHeaderForeground;
                    this.Sheets[0].SheetCorner.DefaultStyle.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold);
                    this.Sheets[0].SheetCorner.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, 1);
                    this.Sheets[0].SheetCorner.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, 1);

                    this.Sheets[0].DefaultStyle.BackColor = MPGV.gTheme.SpreadBackground;
                    this.Sheets[0].DefaultStyle.ForeColor = MPGV.gTheme.SpreadCellForeground;
                    this.Sheets[0].DefaultStyle.Font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, System.Drawing.FontStyle.Bold);
                    this.Sheets[0].HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, 1);
                    this.Sheets[0].VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, MPGV.gTheme.SpreadCellBorder, 1);

                    this.Sheets[0].SelectionBackColor = MPGV.gTheme.SpreadRowSelectedBackground;

                    this.Sheets[0].RowChanged += new SheetViewEventHandler(SOISpread_RowChanged);
                }
                if(this.HorizontalScrollBar != null
                    && this.HorizontalScrollBar.Renderer != null
                    && this.HorizontalScrollBar.Renderer is EnhancedScrollBarRenderer)
                {
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ArrowColor = MPGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ArrowHoveredColor = MPGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ArrowSelectedColor = MPGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonBackgroundColor = MPGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonBorderColor = MPGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonHoveredBackgroundColor = MPGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonHoveredBorderColor = MPGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonSelectedBackgroundColor = MPGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).ButtonSelectedBorderColor = MPGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).TrackBarBackgroundColor = MPGV.gTheme.ControlCommonScrollBarBackground;
                    ((EnhancedScrollBarRenderer)this.HorizontalScrollBar.Renderer).TrackBarSelectedBackgroundColor = MPGV.gTheme.ControlCommonScrollBarSelectedColor;
                }                
                if (this.VerticalScrollBar != null
                    && this.VerticalScrollBar.Renderer != null
                    && this.VerticalScrollBar.Renderer is EnhancedScrollBarRenderer)
                {
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ArrowColor = MPGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ArrowHoveredColor = MPGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ArrowSelectedColor = MPGV.gTheme.ControlCommonScrollBarArrowColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonBackgroundColor = MPGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonBorderColor = MPGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonHoveredBackgroundColor = MPGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonHoveredBorderColor = MPGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonSelectedBackgroundColor = MPGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).ButtonSelectedBorderColor = MPGV.gTheme.ControlCommonScrollBarSelectedColor;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).TrackBarBackgroundColor = MPGV.gTheme.ControlCommonScrollBarBackground;
                    ((EnhancedScrollBarRenderer)this.VerticalScrollBar.Renderer).TrackBarSelectedBackgroundColor = MPGV.gTheme.ControlCommonScrollBarSelectedColor;
                }
                if (this.Skin != null
                    && this.Skin.InterfaceRenderer != null
                    && this.Skin.InterfaceRenderer is EnhancedInterfaceRenderer)
                {
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).ScrollBoxBackgroundColor = MPGV.gTheme.SpreadBackground;
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).SplitBoxBackgroundColor = MPGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).SplitBoxBorderColor = MPGV.gTheme.ControlCommonScrollBarForeground;
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).SplitBarBackgroundColor = MPGV.gTheme.SpreadCellBorder;
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).SplitBarDarkColor = MPGV.gTheme.SpreadCellBorder;
                    ((EnhancedInterfaceRenderer)this.Skin.InterfaceRenderer).SplitBarLightColor = MPGV.gTheme.SpreadCellBorder;
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
                MPCF.ShowMessage(ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
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
                MPCF.ShowMessage(ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
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
                    textBoxContextMenu.SetContextMenuUltra(this, MPGC.CONTROL_CONTEXT_MENU_KEY);

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

        #endregion
    }
}
