namespace SOI.OIFrx
{
    partial class udcSpread
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
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpTranMiddle = new System.Windows.Forms.GroupBox();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.SortcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sortAsscendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortDescendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSearchText = new System.Windows.Forms.ToolStripTextBox();
            this.ExcelExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.grpTranMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SortcontextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpTranMiddle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 480);
            this.panel1.TabIndex = 0;
            // 
            // grpTranMiddle
            // 
            this.grpTranMiddle.Controls.Add(this.spdData);
            this.grpTranMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTranMiddle.Location = new System.Drawing.Point(0, 0);
            this.grpTranMiddle.Name = "grpTranMiddle";
            this.grpTranMiddle.Size = new System.Drawing.Size(673, 480);
            this.grpTranMiddle.TabIndex = 4;
            this.grpTranMiddle.TabStop = false;
            this.grpTranMiddle.Text = "View Receive History";
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.EditModePermanent = true;
            this.spdData.EditModeReplace = true;
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
            this.spdData.Size = new System.Drawing.Size(667, 460);
            this.spdData.TabIndex = 7;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
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
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // SortcontextMenuStrip
            // 
            this.SortcontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortAsscendingToolStripMenuItem,
            this.sortDescendingToolStripMenuItem,
            this.ZomInToolStripMenuItem,
            this.SearchTextToolStripMenuItem,
            this.ExcelExportToolStripMenuItem,
            this.toolStripSeparator5,
            this.ViewQueryToolStripMenuItem,
            this.SetColumnsToolStripMenuItem});
            this.SortcontextMenuStrip.Name = "SortcontextMenuStrip";
            this.SortcontextMenuStrip.Size = new System.Drawing.Size(164, 164);
            // 
            // sortAsscendingToolStripMenuItem
            // 
            this.sortAsscendingToolStripMenuItem.Image = global::SOI.OIFrx.Properties.Resources._076dataasc;
            this.sortAsscendingToolStripMenuItem.Name = "sortAsscendingToolStripMenuItem";
            this.sortAsscendingToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.sortAsscendingToolStripMenuItem.Text = "Sort Asscending";
            // 
            // sortDescendingToolStripMenuItem
            // 
            this.sortDescendingToolStripMenuItem.Image = global::SOI.OIFrx.Properties.Resources._077datadesc;
            this.sortDescendingToolStripMenuItem.Name = "sortDescendingToolStripMenuItem";
            this.sortDescendingToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.sortDescendingToolStripMenuItem.Text = "Sort Descending";
            // 
            // ZomInToolStripMenuItem
            // 
            this.ZomInToolStripMenuItem.Image = global::SOI.OIFrx.Properties.Resources.m_search;
            this.ZomInToolStripMenuItem.Name = "ZomInToolStripMenuItem";
            this.ZomInToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.ZomInToolStripMenuItem.Text = "Zoom In/Out";
            // 
            // SearchTextToolStripMenuItem
            // 
            this.SearchTextToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSearchText});
            this.SearchTextToolStripMenuItem.Image = global::SOI.OIFrx.Properties.Resources.toblog;
            this.SearchTextToolStripMenuItem.Name = "SearchTextToolStripMenuItem";
            this.SearchTextToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.SearchTextToolStripMenuItem.Text = "Search Text";
            // 
            // tsSearchText
            // 
            this.tsSearchText.Name = "tsSearchText";
            this.tsSearchText.Size = new System.Drawing.Size(100, 23);
            // 
            // ExcelExportToolStripMenuItem
            // 
            this.ExcelExportToolStripMenuItem.Image = global::SOI.OIFrx.Properties.Resources._084excel;
            this.ExcelExportToolStripMenuItem.Name = "ExcelExportToolStripMenuItem";
            this.ExcelExportToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.ExcelExportToolStripMenuItem.Text = "Excel Export";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(160, 6);
            // 
            // ViewQueryToolStripMenuItem
            // 
            this.ViewQueryToolStripMenuItem.Image = global::SOI.OIFrx.Properties.Resources.docking02;
            this.ViewQueryToolStripMenuItem.Name = "ViewQueryToolStripMenuItem";
            this.ViewQueryToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.ViewQueryToolStripMenuItem.Text = "View Query";
            // 
            // SetColumnsToolStripMenuItem
            // 
            this.SetColumnsToolStripMenuItem.Image = global::SOI.OIFrx.Properties.Resources._312coldel;
            this.SetColumnsToolStripMenuItem.Name = "SetColumnsToolStripMenuItem";
            this.SetColumnsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.SetColumnsToolStripMenuItem.Text = "Set Columns";
            // 
            // udcSpread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "udcSpread";
            this.Size = new System.Drawing.Size(673, 480);
            this.Load += new System.EventHandler(this.udcSpread_Load);
            this.panel1.ResumeLayout(false);
            this.grpTranMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.SortcontextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem sortAsscendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortDescendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tsSearchText;
        private System.Windows.Forms.ToolStripMenuItem ExcelExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem ViewQueryToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.GroupBox grpTranMiddle;
        public FarPoint.Win.Spread.FpSpread spdData;
        protected FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.ToolStripMenuItem SetColumnsToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip SortcontextMenuStrip;
    }
}
