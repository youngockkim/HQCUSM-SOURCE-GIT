using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinGrid;
using System.Data;
using SOI.OIFrx.SOIControls;
using Infragistics.Win.UltraWinToolbars;
using System.Windows.Forms;
using Infragistics.Win;
using System.Drawing;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIGrid : UltraGrid
    {
        #region Property

        private UltraGridCell ugcClickedCell;

        private DataTable dt_grid;

        private NoFocusRect noFocusRect = new NoFocusRect();

        private SOIContextMenu textBoxContextMenu;

        private bool _useOITheme = true;
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

        public SOIGrid()
        {
            InitializeComponent();
        }

        public SOIGrid(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Event Handler

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            // 디자인 모드에서만 적용
            if (DesignMode == true)
            {
                SetOITheme();
            }

            base.OnPaint(pe);
        }

        private void textBoxContextMenu_BeforeToolDropdown(object sender, BeforeToolDropdownEventArgs e)
        {
            UIElement lastElement = this.DisplayLayout.UIElement.LastElementEntered;
            if (lastElement != null)
            {
                UltraGridCell cell = lastElement.GetContext(typeof(UltraGridCell)) as UltraGridCell;

                if (cell != null)
                {
                    if (cell.Row != null)
                    {
                        textBoxContextMenu.Tools["copyCell"].SharedProps.Enabled = true;
                        textBoxContextMenu.Tools["copyRow"].SharedProps.Enabled = true;
                        ugcClickedCell = cell;
                        return;
                    }
                }
            }

            textBoxContextMenu.Tools["copyCell"].SharedProps.Enabled = false;            
            textBoxContextMenu.Tools["copyRow"].SharedProps.Enabled = false;

            if (ugcClickedCell != null)
            {
                ugcClickedCell.Dispose();
            }
        }

        private void textBoxContextMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            if (e.Tool.Key == "copyCell")
            {
                if (ugcClickedCell != null)
                {
                    if (ugcClickedCell.Value != null)
                    {
                        if (string.IsNullOrEmpty(ugcClickedCell.Value.ToString()) == false)
                        {
                            Clipboard.SetText(ugcClickedCell.Value.ToString());
                        }
                    }
                }                
            }
            else if (e.Tool.Key == "copyRow")
            {
                if (ugcClickedCell != null)
                {
                    ugcClickedCell.Row.Selected = true;
                    this.PerformAction(UltraGridAction.Copy);
                }
            }
        }

        private void SOIGrid_ClickCell(object sender, ClickCellEventArgs e)
        {
            try
            {
                // Check Box Check
                if (this.Selected.Rows.Count > 0)
                {
                    if (this.GetDataSource() != null
                        && this.GetDataSource().Columns.Count > 0
                        && this.GetDataSource().Columns[0].DataType == typeof(bool))
                    {
                        this.Selected.Rows[0].Cells[0].Value = !((bool)(this.Selected.Rows[0].Cells[0].Value));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, SOI.CliFrx.MSG_LEVEL.ERROR, false);
            }
        }

        private void SOIGrid_BeforeSortChange(object sender, BeforeSortChangeEventArgs e)
        {
            try
            {
                if (dt_grid != null
                    && dt_grid.Rows.Count > 0)
                {
                    if (e.SortedColumns.Count > 0)
                    {
                        if(dt_grid.Columns.Count > 0)
                        {
                            if (dt_grid.Columns[e.SortedColumns[0].Key] != null)
                            {
                                if (e.SortedColumns[0].SortIndicator == SortIndicator.Ascending)
                                {
                                    dt_grid.DefaultView.Sort = e.SortedColumns[0].Key + " asc";
                                    dt_grid = dt_grid.DefaultView.ToTable(dt_grid.TableName);
                                    this.DataSource = dt_grid;
                                    this.DataBind();
                                }
                                else if (e.SortedColumns[0].SortIndicator == SortIndicator.Descending)
                                {
                                    dt_grid.DefaultView.Sort = e.SortedColumns[0].Key + " desc";
                                    dt_grid = dt_grid.DefaultView.ToTable(dt_grid.TableName);
                                    this.DataSource = dt_grid;
                                    this.DataBind();
                                }
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
                // 속성
                this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                this.DisplayLayout.GroupByBox.Hidden = true; // GroupBox 감추기
                this.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect; // ReadOnly and Row Select
                //this.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.ExternalSortSingle; // Sort 사용하지 않는 경우
                //this.DisplayLayout.Override.SelectTypeRow = SelectType.Single; // Only One Selection
                this.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False; // Active Row Appearance Disable
                this.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy;
                this.DrawFilter = noFocusRect;

                // 색상
                this.DisplayLayout.Appearance.BackColor = MPGV.gTheme.GridBackground;
                this.DisplayLayout.Appearance.BorderColor = MPGV.gTheme.GridBorder;                                   
                this.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
                this.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
                this.DisplayLayout.Override.CellAppearance.BackColor = MPGV.gTheme.GridBackground;
                this.DisplayLayout.Override.CellAppearance.BorderColor = MPGV.gTheme.GridCellBorder;
                this.DisplayLayout.Override.CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.DisplayLayout.Override.CellAppearance.ForeColor = MPGV.gTheme.GridCellForeground;
                this.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;                
                this.DisplayLayout.Override.HeaderAppearance.BackColor = MPGV.gTheme.GridColumnHeaderBackground;
                this.DisplayLayout.Override.HeaderAppearance.BackColor2 = MPGV.gTheme.GridColumnHeaderBackground;
                this.DisplayLayout.Override.HeaderAppearance.BorderColor = MPGV.gTheme.GridBorder;
                this.DisplayLayout.Override.HeaderAppearance.BorderColor2 = MPGV.gTheme.GridBorder;
                this.DisplayLayout.Override.HeaderAppearance.ForeColor = MPGV.gTheme.GridColumnHeaderForeground;
                this.DisplayLayout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;                
                this.DisplayLayout.Override.RowAppearance.BorderColor = MPGV.gTheme.GridCellBorder;
                this.DisplayLayout.DefaultSelectedBackColor = MPGV.gTheme.GridRowSelectedBackground;
                this.DisplayLayout.DefaultSelectedForeColor = MPGV.gTheme.GridCellForeground;
                this.DisplayLayout.Override.HotTrackRowCellAppearance.BackColor = MPGV.gTheme.ListBoxRowMouseOverBackground;
                this.DisplayLayout.ScrollBarLook.ThumbAppearance.BackColor = MPGV.gTheme.ListBoxScrollThumbBackground;
            }
        }

        /// <summary>
        /// Data Table을 초기화 합니다.
        /// </summary>
        public void InitDataSource()
        {
            string sTableKey = "GridTable";

            // Data Source Init
            if (dt_grid == null)
            {
                if (string.IsNullOrEmpty(DisplayLayout.Bands[0].Key) == false)
                {
                    sTableKey = DisplayLayout.Bands[0].Key;
                }

                dt_grid = new DataTable(sTableKey);

                if (this.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    int i = 0;
                    foreach (UltraGridColumn ugc in this.DisplayLayout.Bands[0].Columns)
                    {
                        DataColumn dc = new DataColumn();
                        if (string.IsNullOrEmpty(ugc.Key) == false)
                        {
                            dc.ColumnName = ugc.Key;
                        }
                        else if(string.IsNullOrEmpty(ugc.Header.Caption) == false)
                        {
                            dc.ColumnName = "COL_" + i.ToString();
                        }
                        dc.DataType = ugc.DataType;
                        dt_grid.Columns.Add(dc);
                        i++;
                    }
                }

                this.DataSource = dt_grid;
                this.SetDataBinding(dt_grid, null, true);
                //this.DataBind();
            }

            // Escape Key Remove
            for (int i = this.KeyActionMappings.Count - 1; i > 0; i--)
            {
                if (this.KeyActionMappings[i].KeyCode == System.Windows.Forms.Keys.Escape)
                {
                    this.KeyActionMappings.Remove(i);
                }
            }
        }

        /// <summary>
        /// Data Table을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataSource()
        {
            if (dt_grid == null)
            {
                InitDataSource();

                return dt_grid;
            }

            return dt_grid;
        }

        /// <summary>
        /// Data Table을 다시 설정 합니다.
        /// </summary>
        /// <param name="newTable"></param>
        /// <returns></returns>
        public DataTable SetDataSource(DataTable newTable)
        {
            if (newTable == null)
            {
                return dt_grid;
            }
            else
            {
                dt_grid = newTable;

                this.DataSource = dt_grid;
                this.DataBind();

                return dt_grid;
            }
        }

        /// <summary>
        /// Data Table을 다시 할당합니다.
        /// </summary>
        public void ClearDataSource()
        {
            if (dt_grid != null)
            {
                dt_grid.Dispose();
                dt_grid = null;
            }

            InitDataSource();

            this.DataSource = dt_grid;
            this.DataBind();
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

        /// <summary>
        /// Key와 Header를 가진 신규 컬럼을 추가합니다.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public UltraGridColumn AddColumn(string key, string header)
        {
            try
            {
                // Data Table Bind
                if (dt_grid == null)
                {
                    InitDataSource();
                }

                // Display Column Add
                UltraGridColumn ugc = this.DisplayLayout.Bands[0].Columns.Add(key, MPCF.FindLanguage(header));
                ugc.DataType = typeof(string);

                // Data Table Add
                DataColumn dc = new DataColumn();
                dc.ColumnName = ugc.Key;
                dc.DataType = typeof(string);
                dt_grid.Columns.Add(dc);

                this.DataBind();

                return ugc;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
                return null;
            }
        }

        #endregion
    }
}
