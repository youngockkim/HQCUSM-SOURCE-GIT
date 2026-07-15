namespace SOI.OIFrx.SOIControls
{
    partial class SOICollectInspData
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
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            this.spdData = new SOI.OIFrx.SOIControls.SOISpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // spdData
            // 
            this.spdData._UseAutoHeight = false;
            this.spdData._UseOITheme = false;
            this.spdData.AccessibleDescription = "spdLpaList, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            enhancedScrollBarRenderer1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ArrowHoveredColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ArrowSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer1.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer1.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer1.ButtonHoveredBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonHoveredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.ButtonSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer1.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            enhancedScrollBarRenderer1.TrackBarSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.spdData.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 76;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 0);
            this.spdData.Margin = new System.Windows.Forms.Padding(0);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(903, 398);
            this.spdData.SOICellHeight = 25;
            this.spdData.SOIColumnHeight = 30;
            this.spdData.TabIndex = 5;
            this.spdData.TabStop = false;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.UseRowFixHeader = true;
            this.spdData.UseSOIContextMenu = true;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            enhancedScrollBarRenderer2.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ArrowHoveredColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ArrowSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            enhancedScrollBarRenderer2.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer2.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            enhancedScrollBarRenderer2.ButtonHoveredBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonHoveredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.ButtonSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            enhancedScrollBarRenderer2.TrackBarBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            enhancedScrollBarRenderer2.TrackBarSelectedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.spdData.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 77;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 25;
            spdData_Sheet1.ColumnHeader.RowCount = 2;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "ColumnFooterEnhanced";
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerEnhanced";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Shop Code";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Shop Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Res ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Res Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Char ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Char Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Char Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "OPT Input";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Value Type";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Value Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Default Unit Over Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).ColumnSpan = 3;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Sample Qty";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Unit Table";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Value Table";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Char Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Unit ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 19).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Value Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 20).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "EDC Hist";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 21).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Unit Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 22).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Unit Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 23).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Col Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 24).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Insp Result";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 11).Value = "Lower Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 12).Value = "Target Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 13).Value = "Upper Spec";
            this.spdData_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.Black;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "ColumnHeaderEnhanced";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdData_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 45F;
            this.spdData_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 100F;
            this.spdData_Sheet1.Columns.Get(1).Width = 100F;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 100F;
            this.spdData_Sheet1.Columns.Get(3).Width = 100F;
            this.spdData_Sheet1.Columns.Get(4).Width = 100F;
            this.spdData_Sheet1.Columns.Get(5).Width = 150F;
            this.spdData_Sheet1.Columns.Get(6).Width = 200F;
            this.spdData_Sheet1.Columns.Get(8).Width = 100F;
            this.spdData_Sheet1.Columns.Get(10).Width = 100F;
            this.spdData_Sheet1.Columns.Get(11).Label = "Lower Spec";
            this.spdData_Sheet1.Columns.Get(11).Width = 100F;
            this.spdData_Sheet1.Columns.Get(12).Label = "Target Value";
            this.spdData_Sheet1.Columns.Get(12).Width = 120F;
            this.spdData_Sheet1.Columns.Get(13).Label = "Upper Spec";
            this.spdData_Sheet1.Columns.Get(13).Width = 100F;
            this.spdData_Sheet1.Columns.Get(24).Width = 100F;
            this.spdData_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdData_Sheet1.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdData_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spdData_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdData_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdData_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdData_Sheet1.PrintInfo.ShowColor = true;
            this.spdData_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdData_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdData_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderEnhanced";
            this.spdData_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdData_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdData_Sheet1.RowHeader.Visible = false;
            this.spdData_Sheet1.Rows.Default.Height = 45F;
            this.spdData_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors;
            this.spdData_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdData_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdData_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdData_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerEnhanced";
            this.spdData_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData_Sheet1.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdData_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // SOICollectInspData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spdData);
            this.Name = "SOICollectInspData";
            this.Size = new System.Drawing.Size(903, 398);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SOISpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
    }
}
