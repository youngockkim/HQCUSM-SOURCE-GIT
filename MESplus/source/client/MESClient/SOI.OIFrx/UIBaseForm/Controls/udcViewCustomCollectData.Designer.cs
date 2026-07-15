namespace SOI.OIFrx
{
    partial class udcViewCustomCollectData
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.EditModeReplace = true;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 28;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 0);
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
            this.spdData.Size = new System.Drawing.Size(722, 197);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 2;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 29;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData.SetViewportLeftColumn(0, 0, 1);
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 22;
            spdData_Sheet1.ColumnHeader.RowCount = 2;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Character";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Character Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Opt Input";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Value Type";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Value Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Default Unit Over Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 3;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "스펙 값";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "\r\n";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "샘플 수";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = " Unit Table";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = " Value Table";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Char Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Unit ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Value Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "EDC Hist";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Unit Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Unit Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 19).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Col Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 20).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "결과";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 0).Value = " ";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 1).Value = " ";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 2).Value = " ";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 7).Value = "하한 값";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 8).Value = "기준 값";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 9).Value = "상한 값";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 21).Value = "1";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType1.MaxLength = 25;
            textCellType1.ReadOnly = true;
            this.spdData_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(0).Label = " ";
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 100F;
            this.spdData_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType2.MaxLength = 50;
            textCellType2.ReadOnly = true;
            this.spdData_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.spdData_Sheet1.Columns.Get(1).Label = " ";
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 120F;
            this.spdData_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType3.ReadOnly = true;
            this.spdData_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(2).Label = " ";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 100F;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Visible = false;
            this.spdData_Sheet1.Columns.Get(3).Width = 35F;
            this.spdData_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType4.MaxLength = 1;
            textCellType4.ReadOnly = true;
            this.spdData_Sheet1.Columns.Get(4).CellType = textCellType4;
            this.spdData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Visible = false;
            this.spdData_Sheet1.Columns.Get(4).Width = 40F;
            this.spdData_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Visible = false;
            this.spdData_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Visible = false;
            this.spdData_Sheet1.Columns.Get(6).Width = 70F;
            this.spdData_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(7).Label = "하한 값";
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Label = "기준 값";
            this.spdData_Sheet1.Columns.Get(8).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Width = 100F;
            this.spdData_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(9).Label = "상한 값";
            this.spdData_Sheet1.Columns.Get(9).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(10).Locked = false;
            this.spdData_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Locked = true;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Visible = false;
            this.spdData_Sheet1.Columns.Get(11).Width = 100F;
            this.spdData_Sheet1.Columns.Get(12).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Locked = true;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Visible = false;
            this.spdData_Sheet1.Columns.Get(12).Width = 100F;
            this.spdData_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType5.ReadOnly = true;
            this.spdData_Sheet1.Columns.Get(13).CellType = textCellType5;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Locked = true;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Visible = false;
            this.spdData_Sheet1.Columns.Get(13).Width = 30F;
            this.spdData_Sheet1.Columns.Get(14).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType6.MaxLength = 50;
            this.spdData_Sheet1.Columns.Get(14).CellType = textCellType6;
            this.spdData_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.Columns.Get(14).Locked = true;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Visible = false;
            this.spdData_Sheet1.Columns.Get(14).Width = 100F;
            this.spdData_Sheet1.Columns.Get(15).Visible = false;
            this.spdData_Sheet1.Columns.Get(16).Visible = false;
            this.spdData_Sheet1.Columns.Get(17).Visible = false;
            this.spdData_Sheet1.Columns.Get(18).Visible = false;
            this.spdData_Sheet1.Columns.Get(19).Visible = false;
            this.spdData_Sheet1.Columns.Get(20).Locked = true;
            this.spdData_Sheet1.Columns.Get(21).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType7.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(21).CellType = textCellType7;
            this.spdData_Sheet1.Columns.Get(21).Label = "1";
            this.spdData_Sheet1.Columns.Get(21).Locked = true;
            this.spdData_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType8.MaxLength = 25;
            this.spdData_Sheet1.DefaultStyle.CellType = textCellType8;
            this.spdData_Sheet1.DefaultStyle.Locked = false;
            this.spdData_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdData_Sheet1.DefaultStyle.Renderer = textCellType8;
            this.spdData_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.FrozenColumnCount = 1;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.Rows.Default.Height = 18F;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // udcViewCustomCollectData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spdData);
            this.Name = "udcViewCustomCollectData";
            this.Size = new System.Drawing.Size(722, 197);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
    }
}
