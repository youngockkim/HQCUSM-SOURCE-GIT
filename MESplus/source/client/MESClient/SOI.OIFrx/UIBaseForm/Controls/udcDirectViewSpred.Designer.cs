namespace SOI.OIFrx
{
    partial class udcDirectViewSpred
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.SortcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExcelExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.grpTranMiddle = new System.Windows.Forms.GroupBox();
            this.lblViewID = new System.Windows.Forms.Label();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.SortcontextMenuStrip.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.grpTranMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // SortcontextMenuStrip
            // 
            this.SortcontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExcelExportToolStripMenuItem,
            this.viewSqlToolStripMenuItem});
            this.SortcontextMenuStrip.Name = "SortcontextMenuStrip";
            this.SortcontextMenuStrip.Size = new System.Drawing.Size(140, 48);
            // 
            // ExcelExportToolStripMenuItem
            // 
            this.ExcelExportToolStripMenuItem.Name = "ExcelExportToolStripMenuItem";
            this.ExcelExportToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.ExcelExportToolStripMenuItem.Text = "Excel Export";
            this.ExcelExportToolStripMenuItem.Click += new System.EventHandler(this.ExcelExportToolStripMenuItem_Click);
            // 
            // viewSqlToolStripMenuItem
            // 
            this.viewSqlToolStripMenuItem.Name = "viewSqlToolStripMenuItem";
            this.viewSqlToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.viewSqlToolStripMenuItem.Text = "View Sql";
            this.viewSqlToolStripMenuItem.Click += new System.EventHandler(this.viewSqlToolStripMenuItem_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grpTranMiddle);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(502, 386);
            this.pnlCenter.TabIndex = 6;
            // 
            // grpTranMiddle
            // 
            this.grpTranMiddle.Controls.Add(this.lblViewID);
            this.grpTranMiddle.Controls.Add(this.spdData);
            this.grpTranMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTranMiddle.Location = new System.Drawing.Point(0, 0);
            this.grpTranMiddle.Name = "grpTranMiddle";
            this.grpTranMiddle.Size = new System.Drawing.Size(502, 386);
            this.grpTranMiddle.TabIndex = 4;
            this.grpTranMiddle.TabStop = false;
            // 
            // lblViewID
            // 
            this.lblViewID.AutoSize = true;
            this.lblViewID.Location = new System.Drawing.Point(16, 28);
            this.lblViewID.Name = "lblViewID";
            this.lblViewID.Size = new System.Drawing.Size(0, 12);
            this.lblViewID.TabIndex = 8;
            this.lblViewID.Visible = false;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.EditModePermanent = true;
            this.spdData.EditModeReplace = true;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 166;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(3, 17);
            this.spdData.Name = "spdData";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.SystemColors.Control;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = cornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle4.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle4.Renderer = generalCellType1;
            this.spdData.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(496, 366);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 7;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 167;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdData_CellClick);
            this.spdData.TopChange += new FarPoint.Win.Spread.TopChangeEventHandler(this.spdData_TopChange);
            this.spdData.LeftChange += new FarPoint.Win.Spread.LeftChangeEventHandler(this.spdData_LeftChange);
            this.spdData.ScrollTipFetch += new FarPoint.Win.Spread.ScrollTipFetchEventHandler(this.spdData_ScrollTipFetch);
            this.spdData.DoubleClick += new System.EventHandler(this.spdData_DoubleClick);
            this.spdData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.spdData_KeyPress);
            this.spdData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spdData_MouseMove);
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 0;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.Lavender;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 25F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.Rows.Default.Height = 25F;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // udcDirectViewSpred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCenter);
            this.Name = "udcDirectViewSpred";
            this.Size = new System.Drawing.Size(502, 386);
            this.Load += new System.EventHandler(this.udcDirectViewSpred_Load);
            this.SortcontextMenuStrip.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.grpTranMiddle.ResumeLayout(false);
            this.grpTranMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ContextMenuStrip SortcontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExcelExportToolStripMenuItem;
        public System.Windows.Forms.Panel pnlCenter;
        public System.Windows.Forms.GroupBox grpTranMiddle;
        public FarPoint.Win.Spread.FpSpread spdData;
        protected FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.Label lblViewID;
        private System.Windows.Forms.ToolStripMenuItem viewSqlToolStripMenuItem;
    }
}
