namespace BOI.WIPCus.Controls
{
    partial class BOILotInfo
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
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer1 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.EnhancedScrollBarRenderer enhancedScrollBarRenderer2 = new FarPoint.Win.Spread.EnhancedScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.soiGroupBox1 = new SOI.OIFrx.SOIControls.SOIGroupBox(this.components);
            this.soiTableLayoutPanel1 = new SOI.OIFrx.SOIControls.SOITableLayoutPanel(this.components);
            this.spdLotInfo = new BOI.OIFrx.BOIControls.BOISpread();
            this.spdLotInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).BeginInit();
            this.soiGroupBox1.SuspendLayout();
            this.soiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // soiGroupBox1
            // 
            this.soiGroupBox1._UseOITheme = true;
            this.soiGroupBox1._UseStyle = SOI.OIFrx.SOIGroupBoxStyle.DefaultStyle;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            appearance23.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.soiGroupBox1.Appearance = appearance23;
            this.soiGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            appearance24.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.soiGroupBox1.ContentAreaAppearance = appearance24;
            this.soiGroupBox1.Controls.Add(this.soiTableLayoutPanel1);
            this.soiGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiGroupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance22.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            appearance22.FontData.BoldAsString = "True";
            appearance22.FontData.SizeInPoints = 14F;
            appearance22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            appearance22.TextHAlignAsString = "Right";
            this.soiGroupBox1.HeaderAppearance = appearance22;
            this.soiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.soiGroupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.soiGroupBox1.Name = "soiGroupBox1";
            this.soiGroupBox1.Size = new System.Drawing.Size(800, 145);
            this.soiGroupBox1.TabIndex = 2;
            this.soiGroupBox1.Text = "Lot Information";
            this.soiGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005;
            // 
            // soiTableLayoutPanel1
            // 
            this.soiTableLayoutPanel1._UseOITheme = true;
            this.soiTableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.soiTableLayoutPanel1.ColumnCount = 1;
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.soiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.soiTableLayoutPanel1.Controls.Add(this.spdLotInfo, 0, 0);
            this.soiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soiTableLayoutPanel1.Location = new System.Drawing.Point(1, 32);
            this.soiTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.soiTableLayoutPanel1.Name = "soiTableLayoutPanel1";
            this.soiTableLayoutPanel1.RowCount = 1;
            this.soiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.soiTableLayoutPanel1.Size = new System.Drawing.Size(798, 112);
            this.soiTableLayoutPanel1.TabIndex = 0;
            // 
            // spdLotInfo
            // 
            this.spdLotInfo._UseAutoHeight = false;
            this.spdLotInfo._UseOITheme = true;
            this.spdLotInfo.AccessibleDescription = "spdMatLot, Sheet1, Row 0, Column 0, ";
            this.spdLotInfo.AllowUserZoom = false;
            this.spdLotInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdLotInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLotInfo.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
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
            this.spdLotInfo.HorizontalScrollBar.Renderer = enhancedScrollBarRenderer1;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 162;
            this.spdLotInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdLotInfo.Location = new System.Drawing.Point(0, 0);
            this.spdLotInfo.Margin = new System.Windows.Forms.Padding(0);
            this.spdLotInfo.Name = "spdLotInfo";
            this.spdLotInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdLotInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdLotInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLotInfo_Sheet1});
            this.spdLotInfo.Size = new System.Drawing.Size(798, 112);
            this.spdLotInfo.SOICellHeight = 50;
            this.spdLotInfo.SOIColumnHeight = 30;
            this.spdLotInfo.TabIndex = 9;
            this.spdLotInfo.TabStop = false;
            this.spdLotInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLotInfo.UseEnterKeyForMove = true;
            this.spdLotInfo.UseKeyPad = true;
            this.spdLotInfo.UseSOIContextMenu = true;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
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
            this.spdLotInfo.VerticalScrollBar.Renderer = enhancedScrollBarRenderer2;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 163;
            this.spdLotInfo.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdLotInfo.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // spdLotInfo_Sheet1
            // 
            this.spdLotInfo_Sheet1.Reset();
            spdLotInfo_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLotInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLotInfo_Sheet1.ColumnCount = 12;
            spdLotInfo_Sheet1.RowCount = 1;
            spdLotInfo_Sheet1.RowHeader.ColumnCount = 0;
            this.spdLotInfo_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic1;
            this.spdLotInfo_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.ForeColor = System.Drawing.Color.White;
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotInfo_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.ForeColor = System.Drawing.Color.White;
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Factory";
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Order ID";
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Order Qty";
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Lot ID";
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Lot Qty";
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Mat ID";
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Line ID";
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Flow";
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Oper";
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Res ID";
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Inspection Flag";
            this.spdLotInfo_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Mat Bom Type";
            this.spdLotInfo_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotInfo_Sheet1.ColumnHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotInfo_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotInfo_Sheet1.ColumnHeader.Rows.Get(0).Height = 50F;
            this.spdLotInfo_Sheet1.ColumnHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotInfo_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdLotInfo_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(0).Label = "Factory";
            this.spdLotInfo_Sheet1.Columns.Get(0).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(0).Width = 100F;
            this.spdLotInfo_Sheet1.Columns.Get(1).CellType = textCellType2;
            this.spdLotInfo_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(1).Label = "Order ID";
            this.spdLotInfo_Sheet1.Columns.Get(1).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(1).Width = 100F;
            numberCellType1.ShowSeparator = true;
            this.spdLotInfo_Sheet1.Columns.Get(2).CellType = numberCellType1;
            this.spdLotInfo_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotInfo_Sheet1.Columns.Get(2).Label = "Order Qty";
            this.spdLotInfo_Sheet1.Columns.Get(2).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(2).Width = 100F;
            this.spdLotInfo_Sheet1.Columns.Get(3).CellType = textCellType3;
            this.spdLotInfo_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(3).Label = "Lot ID";
            this.spdLotInfo_Sheet1.Columns.Get(3).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(3).Width = 100F;
            numberCellType2.ShowSeparator = true;
            this.spdLotInfo_Sheet1.Columns.Get(4).CellType = numberCellType2;
            this.spdLotInfo_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLotInfo_Sheet1.Columns.Get(4).Label = "Lot Qty";
            this.spdLotInfo_Sheet1.Columns.Get(4).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(4).Width = 100F;
            this.spdLotInfo_Sheet1.Columns.Get(5).CellType = textCellType4;
            this.spdLotInfo_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(5).Label = "Mat ID";
            this.spdLotInfo_Sheet1.Columns.Get(5).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(5).Width = 100F;
            this.spdLotInfo_Sheet1.Columns.Get(6).CellType = textCellType5;
            this.spdLotInfo_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(6).Label = "Line ID";
            this.spdLotInfo_Sheet1.Columns.Get(6).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(6).Width = 100F;
            this.spdLotInfo_Sheet1.Columns.Get(7).CellType = textCellType6;
            this.spdLotInfo_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(7).Label = "Flow";
            this.spdLotInfo_Sheet1.Columns.Get(7).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(7).Width = 100F;
            this.spdLotInfo_Sheet1.Columns.Get(8).CellType = textCellType7;
            this.spdLotInfo_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(8).Label = "Oper";
            this.spdLotInfo_Sheet1.Columns.Get(8).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(8).Width = 100F;
            this.spdLotInfo_Sheet1.Columns.Get(9).CellType = textCellType8;
            this.spdLotInfo_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(9).Label = "Res ID";
            this.spdLotInfo_Sheet1.Columns.Get(9).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(9).Width = 100F;
            this.spdLotInfo_Sheet1.Columns.Get(10).CellType = textCellType9;
            this.spdLotInfo_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(10).Label = "Inspection Flag";
            this.spdLotInfo_Sheet1.Columns.Get(10).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(10).Width = 100F;
            this.spdLotInfo_Sheet1.Columns.Get(11).CellType = textCellType10;
            this.spdLotInfo_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(11).Label = "Mat Bom Type";
            this.spdLotInfo_Sheet1.Columns.Get(11).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(11).Width = 100F;
            this.spdLotInfo_Sheet1.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdLotInfo_Sheet1.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdLotInfo_Sheet1.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spdLotInfo_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdLotInfo_Sheet1.GrayAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.spdLotInfo_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotInfo_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdLotInfo_Sheet1.PrintInfo.ShowColor = true;
            this.spdLotInfo_Sheet1.PrintInfo.UseSmartPrint = true;
            this.spdLotInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLotInfo_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotInfo_Sheet1.RowHeader.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotInfo_Sheet1.RowHeader.Rows.Default.Resizable = true;
            this.spdLotInfo_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotInfo_Sheet1.RowHeader.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotInfo_Sheet1.RowHeader.Visible = false;
            this.spdLotInfo_Sheet1.Rows.Default.Height = 50F;
            this.spdLotInfo_Sheet1.Rows.Default.Resizable = true;
            this.spdLotInfo_Sheet1.SelectionStyle = FarPoint.Win.Spread.SelectionStyles.SelectionColors;
            this.spdLotInfo_Sheet1.SheetCornerHorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotInfo_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(114)))));
            this.spdLotInfo_Sheet1.SheetCornerStyle.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.spdLotInfo_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spdLotInfo_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdLotInfo_Sheet1.SheetCornerStyle.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdLotInfo_Sheet1.SheetCornerVerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotInfo_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152))))), 1);
            this.spdLotInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // BOILotInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.soiGroupBox1);
            this.Name = "BOILotInfo";
            this.Size = new System.Drawing.Size(800, 145);
            this.Load += new System.EventHandler(this.BOILotInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.soiGroupBox1)).EndInit();
            this.soiGroupBox1.ResumeLayout(false);
            this.soiTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SOI.OIFrx.SOIControls.SOIGroupBox soiGroupBox1;
        private SOI.OIFrx.SOIControls.SOITableLayoutPanel soiTableLayoutPanel1;
        private FarPoint.Win.Spread.SheetView spdLotInfo_Sheet1;
        internal OIFrx.BOIControls.BOISpread spdLotInfo;
    }
}
