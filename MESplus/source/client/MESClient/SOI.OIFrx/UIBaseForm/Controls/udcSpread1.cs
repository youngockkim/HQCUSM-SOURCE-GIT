using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Miracom.CliFrx;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.UI;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win.Spread.Model;
using FarPoint.Win;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace SOI.OIFrx
{
    public partial class udcSpread1 : UserControl
    {
        public udcSpread1()
        {
            InitializeComponent();

            EventHandler();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        udcSpread1 m_upContext = null;
        DataTable m_dtSpreadData = new DataTable();
        object[,] m_ObjColumns = null;
        int time;
        ViewSetColumns SetCols = new ViewSetColumns();

        public udcSpread1 upContext
        {
            get { return m_upContext; }
            set { m_upContext = value; }
        }

        public DataTable dtSpreadData
        {
            get { return m_dtSpreadData; }
            set { m_dtSpreadData = value; }
        }
        public int iCol { get; set; }
        public int iRow { get; set; }
        private string m_gbTitle { get; set; }
        public object[,] ObjColumns
        {
            get { return m_ObjColumns; }
            set { m_ObjColumns = value; }
        }
        public int[] iArryVisibleCols { get; set; }
        public string[] sArrySearchCols { get; set; }
        bool m_SortAsscendingEnabled = true;
        bool m_SortDescendingEnabled = true;
        bool m_ZoomInOutEnabled = true;
        bool m_SearchMenuEnabled = true;
        bool m_SearchTextEnabled = true;
        bool m_ExcelExportEnabled = true;
        bool m_ViewQueryEnabled = true;
        bool m_SetColumnsEnabled = true;

        private string sLabel = string.Empty;
        FarPoint.Win.Spread.CellType.TextCellType type_text = new FarPoint.Win.Spread.CellType.TextCellType();
        FarPoint.Win.Spread.CellType.ButtonCellType type_button_plus = new FarPoint.Win.Spread.CellType.ButtonCellType();
        FarPoint.Win.Spread.CellType.ButtonCellType type_button_minus = new FarPoint.Win.Spread.CellType.ButtonCellType();
        FarPoint.Win.Spread.CellType.ButtonCellType type_button = new ButtonCellType();
        FarPoint.Win.Spread.CellType.ComboBoxCellType type_combo = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
        FarPoint.Win.Spread.CellType.MaskCellType type_mask = new FarPoint.Win.Spread.CellType.MaskCellType();
        FarPoint.Win.Spread.CellType.NumberCellType type_number = new FarPoint.Win.Spread.CellType.NumberCellType();
        FarPoint.Win.Spread.CellType.CheckBoxCellType type_check = new CheckBoxCellType();
        DateTimePickerCellType type_date = new DateTimePickerCellType();
        DataTable dtBlank = new DataTable();
        DataTable dtData = new DataTable();

        public FarPoint.Win.Spread.CellType.TextCellType GetTypeText() { return type_text; }
        public FarPoint.Win.Spread.CellType.NumberCellType GetTypeNumber() { return type_number; }
        public FarPoint.Win.Spread.CellType.ComboBoxCellType GetTypeCombo() { return type_combo; }
        public FarPoint.Win.Spread.CellType.CheckBoxCellType GetTypeCheck() { return type_check; }
        public DateTimePickerCellType GetTypeDate() { return type_date; }
        public FarPoint.Win.Spread.CellType.ButtonCellType GetTypeButton() { return type_button; }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("GroupBox Title")
       , Description("GroupBox의 Title을 설정")]
        public string gbTitle
        {
            get { return m_gbTitle; }
            set { m_gbTitle = value; this.Invalidate(); }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("Sort Asscending")
       , Description("Context 오름차순 사용여부를 설정")]
        public bool tsSortAsscendingEnabled
        {
            get { return m_SortAsscendingEnabled; }
            set { sortAsscendingToolStripMenuItem.Enabled = value; this.Invalidate(); }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("Sort Descending")
       , Description("Context 내림차순 사용여부를 설정")]
        public bool tsSortDescendingEnabled
        {
            get { return m_SortDescendingEnabled; }
            set { sortDescendingToolStripMenuItem.Enabled = value; this.Invalidate(); }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("Zoom In/Out")
       , Description("Context Spread 확대/축소 사용여부를 설정")]
        public bool tsZoomInOutEnabled
        {
            get { return m_ZoomInOutEnabled; }
            set { ZomInToolStripMenuItem.Enabled = value; this.Invalidate(); }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("Search Menu")
       , Description("Context 텍스트 검색 메뉴 사용여부를 설정")]
        public bool tsSearchMenuEnabled
        {
            get { return m_SearchMenuEnabled; }
            set { SearchTextToolStripMenuItem.Enabled = value; this.Invalidate(); }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("Search Text")
       , Description("Context 텍스트 검색 사용여부를 설정")]
        public bool tsSearchTextEnabled
        {
            get { return m_SearchTextEnabled; }
            set { tsSearchText.Enabled = value; this.Invalidate(); }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("Excel Export")
       , Description("Context 엑셀 다운로드 사용여부를 설정")]
        public bool tsExcelExportEnabled
        {
            get { return m_ExcelExportEnabled; }
            set { ExcelExportToolStripMenuItem.Enabled = value; this.Invalidate(); }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("View Query")
       , Description("Context 쿼리문 조회 사용여부를 설정")]
        public bool tsViewQueryEnabled
        {
            get { return m_ViewQueryEnabled; }
            set { ViewQueryToolStripMenuItem.Enabled = value; this.Invalidate(); }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
       , DefaultValue("")
       , Category("Set Columns")
       , Description("Context 칼럼 숨김 사용여부를 설정")]
        public bool tsSetColumnsEnabled
        {
            get { return m_SetColumnsEnabled; }
            set { SetColumnsToolStripMenuItem.Enabled = value; this.Invalidate(); }
        }

        /// <summary>
        /// Control Event Handler
        /// </summary>
        private void EventHandler()
        {
            #region [ Control Event ]
            timer1.Tick += new EventHandler(timer1_Tick);
            //ContextMenu Event
            sortAsscendingToolStripMenuItem.Click += new EventHandler(sortAsscendingToolStripMenuItem_Click);
            sortDescendingToolStripMenuItem.Click += new EventHandler(sortDescendingToolStripMenuItem_Click);
            ExcelExportToolStripMenuItem.Click += new EventHandler(ExcelExportToolStripMenuItem_Click);
            ZomInToolStripMenuItem.Click += new System.EventHandler(ZomInToolStripMenuItem_Click);
            tsSearchText.TextChanged += new EventHandler(tsSearchText_TextChanged);
            ViewQueryToolStripMenuItem.Click += new EventHandler(ViewQueryToolStripMenuItem_Click);
            SetColumnsToolStripMenuItem.Click += new EventHandler(SetColumnsToolStripMenuItem_Click);
            #endregion

            #region [ Spread Event ]
            this.spdData.MouseMove += new MouseEventHandler(spdData1_MouseMove);
            this.spdData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdData_CellClick);
            this.spdData.ScrollTipFetch += new ScrollTipFetchEventHandler(this.spdData_ScrollTipFetch);
            this.spdData.TopChange += new FarPoint.Win.Spread.TopChangeEventHandler(this.spdData_TopChange);
            this.spdData.LeftChange += new FarPoint.Win.Spread.LeftChangeEventHandler(this.spdData_LeftChange);
            #endregion

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void udcSpread1_Load(object sender, EventArgs e)
        {
            this.pnlTranMiddle.Tag = m_gbTitle;
            ApplyTema(false, true, OperationMode.Normal);
            //sortAsscendingToolStripMenuItem.Enabled = m_SortAsscendingEnabled;
            //sortDescendingToolStripMenuItem.Enabled = m_SortDescendingEnabled;
            //ZomInToolStripMenuItem.Enabled = m_ZoomInOutEnabled;
            //tsSearchText.Enabled = m_SearchTextEnabled;
            //ExcelExportToolStripMenuItem.Enabled = m_ExcelExportEnabled;
            //ViewQueryToolStripMenuItem.Enabled = m_ViewQueryEnabled;
            //SetColumnsToolStripMenuItem.Enabled = m_SetColumnsEnabled;
        }
        /// <summary>
        /// RealTime Caption Change
        /// </summary>
        /// <returns></returns>
        private bool CaptionChange()
        {
            try
            {
                MPCF.ConvertMessage(this.Controls);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer1_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                timer1.Stop();
                if (SpreadMergeData())
                {
                    //TO DO
                }
            }
            time += timer1.Interval;
        }
        /// <summary>
        /// Search DataTable spdData
        /// </summary>
        /// <param name="dtTemp"></param>
        /// <param name="dtMerge"></param>
        private bool SpreadMergeData()
        {
            m_dtSpreadData.PrimaryKey = new DataColumn[] { m_dtSpreadData.Columns["RNUM"] };
            DataTable tblTemp = m_dtSpreadData.Clone();
            DataRow[] rows = null;
            StringBuilder sbQry = new StringBuilder();
            string sValue = this.tsSearchText.Text.Trim();

            try
            {
                sbQry.Remove(0, sbQry.Length);

                //foreach (DataColumn dc in m_dtSpreadData.Columns)
                //{
                //    if (dc.Table.Columns.IndexOf(dc) == 0)
                //    {
                //        if (!dc.DataType.Name.Equals("Double"))
                //        {
                //            sbQry.AppendLine(string.Concat(dc.ColumnName.ToString(), " LIKE '%", sValue, "%' "));
                //        }
                //        else
                //        {
                //            sbQry.AppendLine("1=1 ");
                //        }
                //    }
                //    else
                //    {
                //        if (!dc.DataType.Name.Equals("Double"))
                //        {
                //            sbQry.AppendLine(string.Concat("OR ", dc.ColumnName.ToString(), " LIKE '%", sValue, "%' "));
                //        }
                //    }
                //}
                int iKey = 0;
                foreach (string key in sArrySearchCols)
                {
                    if (iKey == 0)
                    {
                        sbQry.AppendLine(string.Concat(key, " LIKE '%", sValue, "%' "));
                        iKey++;
                    }
                    else
                    {
                        sbQry.AppendLine(string.Concat("OR ", key, " LIKE '%", sValue, "%' "));
                    }
                }

                rows = m_dtSpreadData.Select(sbQry.ToString(), "RNUM");
                if (rows != null && rows.Length > 0)
                {
                    foreach (DataRow dr in rows)
                    {
                        tblTemp.ImportRow(dr);
                    }
                    tblTemp.AcceptChanges();
                    MakeSpreadColHeader(m_upContext, tblTemp, m_ObjColumns);
                }
                else
                {
                    MakeSpreadColHeader(m_upContext, m_dtSpreadData, m_ObjColumns);
                }
                spdData.Refresh();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            finally
            {
            }
            return true;
        }
        /// <summary>
        /// Make Spread ColumnHeader
        /// </summary>
        /// <param name="fpSpd"></param>
        private void MakeSpreadColHeader(udcSpread1 ucSpd, DataTable tblData, object[,] oCol)
        {
            UCSpread1 sprMaker1 = new UCSpread1();

            try
            {
                sprMaker1.MakeSpreadColHeader(ucSpd, tblData, oCol);

                if (ucSpd.spdData.Name.ToString().Equals("spdData"))
                {
                    sprMaker1.SetHideColumn(ucSpd, iArryVisibleCols, false);
                }
                CaptionChange();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        /// <summary>
        /// Spread 초기화
        /// </summary>
        /// <param name="bRowHeader">Row Header를 보여줄지 여부</param>
        /// <param name="bSort">Column Sort 여부</param>
        /// <param name="operMode">Operation Mode 설정</param>
        private void ApplyTema(bool bRowHeader, bool bSort, FarPoint.Win.Spread.OperationMode operMode)
        {
            FarPoint.Win.Spread.SheetSkin spSkin;

            try
            {
                FarPoint.Win.Spread.DefaultSpreadSkins.GetAt(1).Apply(this.spdData);
                spSkin = new FarPoint.Win.Spread.SheetSkin("InitSkin",
                                           System.Drawing.Color.FromArgb(32, 32, 32),
                                           System.Drawing.Color.FromArgb(32, 32, 32),
                                           System.Drawing.Color.FromArgb(255, 255, 255),
                                           System.Drawing.Color.FromArgb(108, 108, 108),
                                           FarPoint.Win.Spread.GridLines.Both,
                                           System.Drawing.Color.FromArgb(9, 19, 26),
                                           System.Drawing.Color.FromArgb(255, 255, 255),
                                           System.Drawing.Color.FromArgb(32, 32, 32),
                                           System.Drawing.Color.FromArgb(32, 32, 32),
                                           System.Drawing.Color.FromArgb(32, 32, 32),
                                           System.Drawing.Color.FromArgb(32, 32, 32),
                                           true,
                                           true,
                                           false,
                                           true,
                                           bRowHeader);

                this.spdData.BorderStyle = BorderStyle.FixedSingle;
                this.spdData.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);  //System.Drawing.SystemColors.Control; // System.Drawing.Color.Silver;
                this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
                this.spdData.MoveActiveOnFocus = true;

                this.spdData.ColumnSplitBoxAlignment = FarPoint.Win.Spread.SplitBoxAlignment.Leading;
                this.spdData.ColumnSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.AsNeeded;

                this.spdData.RowSplitBoxPolicy = FarPoint.Win.Spread.SplitBoxPolicy.Never;

                this.spdData.SetCursor(FarPoint.Win.Spread.CursorType.Normal, System.Windows.Forms.Cursors.Arrow);
                this.spdData.BorderStyle = BorderStyle.FixedSingle;
                this.spdData.VerticalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                this.spdData.HorizontalScrollBarPolicy = ScrollBarPolicy.AsNeeded;
                this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;

                for (int i = 0; i < this.spdData.Sheets.Count; i++)
                {
                    //"Verdana", "Tahoma", "Times New Roman", "돋움"
                    Font myFonts = new Font("Arial", 8F, FontStyle.Regular);

                    spSkin.Apply(this.spdData.Sheets[i]);

                    this.spdData.Sheets[i].RowCount = 0;
                    this.spdData.Sheets[i].ColumnCount = 0;
                    this.spdData.Sheets[i].OperationMode = operMode;
                    this.spdData.Sheets[i].Columns[-1].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    this.spdData.Sheets[i].ColumnHeader.DefaultStyle.Font = new Font("Arial", 8.15F, System.Drawing.FontStyle.Regular);  // new Font("Tahoma", 8F, FontStyle.Bold);
                    
                    this.spdData.Sheets[i].DefaultStyle.Font = myFonts;
                    this.spdData.Sheets[i].DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;

                    // Auto sort setting.
                    this.spdData.Sheets[i].SetColumnAllowAutoSort(0, this.spdData.Sheets[i].ColumnCount, bSort);
                    this.spdData.Sheets[i].ColumnHeader.AutoSortIndex = 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region [ Context Event ]
        /// <summary>
        /// Sort Descending
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void sortDescendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_upContext.spdData.ActiveSheet.AutoSortColumn(iCol, false, true);
        }
        /// <summary>
        /// Sort Asscending
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void sortAsscendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_upContext.spdData.ActiveSheet.AutoSortColumn(iCol, true, true);
        }
        /// <summary>
        /// Context Menu Excel Export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ExcelExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                sCond = "";

                if (MPCF.ExportToExcel(m_upContext.spdData, m_upContext.gbTitle.ToString(), sCond, true, false, true, -1, -1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
        /// <summary>
        /// Search Text Start Time Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tsSearchText_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
            time = 0;
        }
        /// <summary>
        /// ZoomIn/Out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Control[] ctlA = new Control[1];
                Control[] ctlB = new Control[1];
                Control[] ctlC = new Control[1];

                ctlA = this.TopLevelControl.Controls.Find("pnlTranCenter", true);
                if (m_upContext.spdData.Name.ToString() == "spdData")
                {
                    ctlC = this.TopLevelControl.Controls.Find("grpTranMiddle", true);
                }
                ctlB = this.TopLevelControl.Controls.Find("pnlTmp1", true);

                if (((Panel)ctlB[0]).Controls.Count == 0)
                {//Zoom in
                    ((Panel)ctlA[0]).SendToBack();
                    ((Panel)ctlB[0]).Controls.Clear();
                    ((Panel)ctlB[0]).Dock = DockStyle.Fill;
                    ((Panel)ctlB[0]).Visible = true;
                    ((Panel)ctlB[0]).BringToFront();
                    ((Panel)ctlB[0]).Controls.Add(m_upContext.spdData);
                    //b_MaxSize = true;
                }
                else
                {//Zoom Out
                    ((Panel)ctlA[0]).BringToFront();
                    ((Panel)ctlA[0]).Dock = DockStyle.Fill;
                    ((Panel)ctlA[0]).Visible = true;
                    ((Panel)ctlB[0]).SendToBack();
                    ((Panel)ctlB[0]).Controls.Remove(m_upContext.spdData);
                    ((GroupBox)ctlC[0]).Controls.Add(m_upContext.spdData);
                    //b_MaxSize = false;
                }
            }
            catch { }
        }
        /// <summary>
        /// Context Menu View Query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ViewQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ViewControl sc = new ViewControl("View Query");
                sc.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }
        /// <summary>
        /// Set Columns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                SetCols = new ViewSetColumns();
                SetCols.sForms = this.Text;
                SetCols.sSpdName = m_upContext.spdData.Name.ToString();
                SetCols.oCols = m_ObjColumns;
                SetCols.iArrayHide = iArryVisibleCols;

                SetCols.Show();
                SetCols.Disposed += new EventHandler(SetSetColumns_Disposed);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }

        }
        /// <summary>
        /// SetColumns Disposed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSetColumns_Disposed(object sender, EventArgs e)
        {
            iArryVisibleCols = SetCols.iArrayHide;
            for (int iKey = 0; iKey < m_upContext.spdData.ActiveSheet.Columns.Count; iKey++)
            {
                m_upContext.spdData.ActiveSheet.Columns[iKey].Visible = false;
            }
            foreach (int key in iArryVisibleCols)
            {
                m_upContext.spdData.ActiveSheet.Columns[key].Visible = true;
            }
        }
        #endregion

        #region [ Spread Event ]
        /// <summary>
        /// Spread MouseMove
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdData1_MouseMove(object sender, MouseEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread fpSpd = (FarPoint.Win.Spread.FpSpread)sender;
            FarPoint.Win.Spread.Model.CellRange cRange = fpSpd.GetCellFromPixel(0, 0, e.X, e.Y);

            if (cRange.Row > -1)
            {
                if (cRange.Column > -1)
                {
                    if (fpSpd.ActiveSheet.Columns[cRange.Column].Locked)
                    {
                        fpSpd.EditModePermanent = false;
                    }
                    else
                    {
                        fpSpd.EditModePermanent = true;
                        fpSpd.SetCursor(FarPoint.Win.Spread.CursorType.Normal, Cursors.Hand);
                    }
                }
            }

        }
        /// <summary>
        /// spdData Cell Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            List<string> lstInfo = new List<string>();
            List<string> lstkey = new List<string>();
            Spread sprMaker = new Spread();
            FarPoint.Win.Spread.FpSpread spread = sender as FarPoint.Win.Spread.FpSpread;
            DataTable dt = null;
            dt = new DataTable();
            List<string> lstAddKeys = new List<string>();

            try
            {
                string sLot = string.Empty;
                string sMatId = string.Empty;
                string sLine = string.Empty;
                string sDate_Type = string.Empty;
                string sStart_Date = string.Empty;
                string sEnd_Date = string.Empty;

                FarPoint.Win.Spread.FpSpread fpSpd = sender as FarPoint.Win.Spread.FpSpread;
                ArrayList aCode = new ArrayList();
                int iCols = e.Column;
                lstInfo.Clear();

                if (e.ColumnHeader)
                {
                    if (((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.Columns[e.Column].CellType is FarPoint.Win.Spread.CellType.CheckBoxCellType)
                    {
                        if (((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].CellType is FarPoint.Win.Spread.CellType.CheckBoxCellType)
                        {
                            if (e.ColumnHeader)
                            {
                                ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Locked = false;
                                if (((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value.Equals("") ||
                                    ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value.Equals(" ") ||
                                    ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value.Equals(false))
                                    ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value = true;
                                else
                                    ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value = !Convert.ToBoolean(((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value);

                                for (int i = 0; i < ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.RowCount; i++)
                                    ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.Cells[i, e.Column].Value = ((FarPoint.Win.Spread.FpSpread)sender).ActiveSheet.ColumnHeader.Cells[e.Row, e.Column].Value;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
            finally
            {
            }
        }
        /// <summary>
        /// ScrollTipFetch Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spdData_ScrollTipFetch(object sender, FarPoint.Win.Spread.ScrollTipFetchEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread fpSpd = (FarPoint.Win.Spread.FpSpread)sender;
            fpSpd.ActiveSheet.SetActiveCell(e.Row, e.Column);
        }

        private void spdData_TopChange(object sender, FarPoint.Win.Spread.TopChangeEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread fpSpd = (FarPoint.Win.Spread.FpSpread)sender;
            int iActCol = fpSpd.ActiveSheet.ActiveColumnIndex;
            fpSpd.ActiveSheet.SetActiveCell(e.NewTop, iActCol);
        }


        private void spdData_LeftChange(object sender, FarPoint.Win.Spread.LeftChangeEventArgs e)
        {
            FarPoint.Win.Spread.FpSpread fpSpd = (FarPoint.Win.Spread.FpSpread)sender;
            int iActRow = fpSpd.ActiveSheet.ActiveRowIndex;
            fpSpd.ActiveSheet.SetActiveCell(iActRow, e.NewLeft);
        }
        #endregion
    }
}
