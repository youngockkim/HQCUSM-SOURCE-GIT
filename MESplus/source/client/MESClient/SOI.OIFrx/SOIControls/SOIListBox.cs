using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinGrid;
using System.Data;
using SOI.OIFrx.SOIControls;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIListBox : UltraGrid
    {
        #region Property

        private DataTable dt_grid;
        private NoFocusRect noFocusRect = new NoFocusRect();

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

        private bool _useConvertLanguage = false; // Convert를 강제로 하지 않는 경우 사용
        public bool _UseConvertLanguage
        {
            get
            {
                return _useConvertLanguage;
            }
            set
            {
                _useConvertLanguage = value;
            }
        }

        private SOIListBoxStyle _useStyle = SOIListBoxStyle.DefaultStyle;
        public SOIListBoxStyle _UseStyle
        {
            get
            {
                return _useStyle;
            }
            set
            {
                _useStyle = value;
                SetOITheme();
            }
        }

        #endregion

        #region Constructor

        public SOIListBox()
        {
            InitializeComponent();
        }

        public SOIListBox(IContainer container)
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

        protected void SOIListBox_ClickCell(object sender, ClickCellEventArgs e)
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
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
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
                // 공통 속성
                this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                this.DisplayLayout.GroupByBox.Hidden = true; // GroupBox 감추기
                //this.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect; // ReadOnly and Row Select
                this.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.ExternalSortSingle; // Sort 사용하지 않는 경우
                this.DisplayLayout.Override.SelectTypeRow = SelectType.Single; // Only One Selection
                this.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False; // Active Row Appearance Disable
                this.DrawFilter = noFocusRect;

                // 공통 색상
                this.DisplayLayout.Appearance.BackColor = MOGV.gTheme.ListBoxBackground;
                this.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
                this.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
                this.DisplayLayout.Override.CellAppearance.BackColor = MOGV.gTheme.ListBoxRowBackground;
                this.DisplayLayout.Override.CellAppearance.BorderColor = MOGV.gTheme.ListBoxRowBackground;
                this.DisplayLayout.Override.CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.DisplayLayout.Override.CellAppearance.ForeColor = MOGV.gTheme.ListBoxRowForeground;
                this.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
                this.DisplayLayout.Override.RowAppearance.BorderColor = MOGV.gTheme.ListBoxRowBackground;
                //this.DisplayLayout.DefaultSelectedBackColor = MPGV.gTheme.ListBoxRowBackground;
                this.DisplayLayout.DefaultSelectedBackColor = MOGV.gTheme.ListBoxRowSelectedBackground;
                this.DisplayLayout.Override.HotTrackRowCellAppearance.BackColor = MOGV.gTheme.ListBoxRowMouseOverBackground;
                this.DisplayLayout.ScrollBarLook.ThumbAppearance.BackColor = MOGV.gTheme.ListBoxScrollThumbBackground;

                // Menu Style인 경우
                if (_UseStyle == SOIListBoxStyle.DefaultStyle)
                {
                    this.DisplayLayout.Appearance.BorderColor = MOGV.gTheme.ListBoxBorder;
                }
                else if (_UseStyle == SOIListBoxStyle.MenuStyle)
                {
                    this.DisplayLayout.Appearance.BorderColor = MOGV.gTheme.ListBoxBorderForMenu;
                }
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
                        else if (string.IsNullOrEmpty(ugc.Header.Caption) == false)
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
        /// Text Column에 Row Data를 추가합니다.
        /// </summary>
        /// <param name="rowData"></param>
        /// <returns></returns>
        public bool AddRowText(string rowText)
        {
            return MPOF.SetSOIListBoxAddRow(this, 0, false, rowText);
        }

        /// <summary>
        /// CheckBox Column과 Text Column에 Row Data를 추가합니다.
        /// </summary>
        /// <param name="rowCheck"></param>
        /// <param name="rowText"></param>
        /// <returns></returns>
        public bool AddRowCheckAndText(bool rowCheck, string rowText)
        {
            return MPOF.SetSOIListBoxAddRow(this, 0, rowCheck, rowText);
        }

        /// <summary>
        /// Sequence Column과 Text Column에 Row Data를 추가합니다.
        /// Sequence 값이 입력되지 않은 경우 이전 값의 다음 값으로 설정합니다.
        /// </summary>
        /// <param name="rowText"></param>
        /// <returns></returns>
        public bool AddRowSeqAndText(string rowText)
        {
            try
            {
                int rowSeq = 0;

                // 1) Data Source 추출
                DataTable dt = this.GetDataSource();
                
                // 2) row가 없는 경우 0
                // 3) row가 있는 경우 이전 값 검색
                if(dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].DataType == typeof(int)
                        && dt.Rows[dt.Rows.Count - 1][0] != null)
                    {
                        rowSeq = ((int)dt.Rows[dt.Rows.Count - 1][0]) + 1;
                    }
                }

                return MPOF.SetSOIListBoxAddRow(this, rowSeq, false, rowText);
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Sequence Column과 Text column에 Row Data를 추가합니다.
        /// </summary>
        /// <param name="rowSeq"></param>
        /// <param name="rowText"></param>
        /// <returns></returns>
        public bool AddRowSeqAndText(int rowSeq, string rowText)
        {
            return MPOF.SetSOIListBoxAddRow(this, rowSeq, false, rowText);
        }

        #endregion
    }
}
