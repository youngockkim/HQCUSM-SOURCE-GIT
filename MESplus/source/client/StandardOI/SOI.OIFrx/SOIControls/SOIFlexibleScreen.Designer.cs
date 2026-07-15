namespace SOI.OIFrx.SOIControls
{
    partial class SOIFlexibleScreen
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
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SOIFlexibleScreen));
            this.spdSpread = new FarPoint.Win.Spread.FpSpread();
            this.spdSpread_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // spdSpread
            // 
            this.spdSpread.AccessibleDescription = "spdSpread, Sheet1, Row 0, Column 0, ";
            this.spdSpread.BackColor = System.Drawing.SystemColors.Control;
            this.spdSpread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdSpread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdSpread.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdSpread.Location = new System.Drawing.Point(0, 0);
            this.spdSpread.Margin = new System.Windows.Forms.Padding(0);
            this.spdSpread.Name = "spdSpread";
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
            this.spdSpread.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdSpread.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdSpread_Sheet1});
            this.spdSpread.Size = new System.Drawing.Size(500, 400);
            this.spdSpread.TabIndex = 1;
            this.spdSpread.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdSpread.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdSpread_CellDoubleClick);
            this.spdSpread.Resize += new System.EventHandler(this.spdSpread_Resize);
            this.spdSpread.SetActiveViewport(0, -1, -1);
            // 
            // spdSpread_Sheet1
            // 
            this.spdSpread_Sheet1.Reset();
            spdSpread_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdSpread_Sheet1.ColumnCount = 0;
            spdSpread_Sheet1.RowCount = 0;
            this.spdSpread_Sheet1.ActiveColumnIndex = -1;
            this.spdSpread_Sheet1.ActiveRowIndex = -1;
            this.spdSpread_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
            this.spdSpread_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdSpread_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdSpread_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.spdSpread_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdSpread_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdSpread_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdSpread_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdSpread_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdSpread_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.spdSpread_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdSpread_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdSpread_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdSpread_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdSpread_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdSpread_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.spdSpread_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdSpread_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSpread_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdSpread_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdSpread_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.White;
            this.spdSpread_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.Black;
            this.spdSpread_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdSpread_Sheet1.PrintInfo.SmartPrintRules = ((FarPoint.Win.Spread.SmartPrintRulesCollection)(resources.GetObject("resource.SmartPrintRules")));
            this.spdSpread_Sheet1.PrintInfo.UseMax = false;
            this.spdSpread_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdSpread_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdSpread_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdSpread_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.spdSpread_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdSpread_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdSpread_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdSpread_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdSpread_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdSpread_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.spdSpread_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdSpread_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdSpread_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdSpread_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ofdFile
            // 
            this.ofdFile.FileName = "openFileDialog1";
            // 
            // SOIFlexibleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spdSpread);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SOIFlexibleScreen";
            this.Size = new System.Drawing.Size(500, 400);
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdSpread_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FarPoint.Win.Spread.SheetView spdSpread_Sheet1;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private FarPoint.Win.Spread.FpSpread spdSpread;
    }
}
