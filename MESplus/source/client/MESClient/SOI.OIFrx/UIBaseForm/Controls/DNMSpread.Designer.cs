namespace SOI.OIFrx
{
    partial class DNMSpread
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
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.SortcontextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExcelExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SortcontextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "";
            this.spdData.BackColor = System.Drawing.Color.Transparent;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 0);
            this.spdData.Name = "spdData";
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(150, 150);
            this.spdData.TabIndex = 0;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdData_CellClick);
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
            this.spdData_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic;
            this.spdData_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // SortcontextMenuStrip
            // 
            this.SortcontextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExcelExportToolStripMenuItem,
            this.customizeColumnsToolStripMenuItem});
            this.SortcontextMenuStrip.Name = "SortcontextMenuStrip";
            this.SortcontextMenuStrip.Size = new System.Drawing.Size(166, 48);
            // 
            // ExcelExportToolStripMenuItem
            // 
            this.ExcelExportToolStripMenuItem.Name = "ExcelExportToolStripMenuItem";
            this.ExcelExportToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.ExcelExportToolStripMenuItem.Text = "Excel Export";
            this.ExcelExportToolStripMenuItem.Click += new System.EventHandler(this.ExcelExportToolStripMenuItem_Click);
            // 
            // customizeColumnsToolStripMenuItem
            // 
            this.customizeColumnsToolStripMenuItem.Name = "customizeColumnsToolStripMenuItem";
            this.customizeColumnsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.customizeColumnsToolStripMenuItem.Text = "Hidden Columns";
            this.customizeColumnsToolStripMenuItem.Click += new System.EventHandler(this.customizeColumnsToolStripMenuItem_Click);
            // 
            // DNMSpread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spdData);
            this.Name = "DNMSpread";
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.SortcontextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        public System.Windows.Forms.ContextMenuStrip SortcontextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExcelExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeColumnsToolStripMenuItem;
    }
}
