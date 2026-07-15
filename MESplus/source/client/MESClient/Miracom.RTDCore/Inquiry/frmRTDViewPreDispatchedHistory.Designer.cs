namespace Miracom.RTDCore
{
    partial class frmRTDViewPreDispatchedHistory
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtLot = new System.Windows.Forms.TextBox();
            this.lblLot = new System.Windows.Forms.Label();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Location = new System.Drawing.Point(3, 0);
            this.pnlViewTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlViewTop.Size = new System.Drawing.Size(736, 44);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtLot);
            this.grpOption.Controls.Add(this.lblLot);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Size = new System.Drawing.Size(736, 41);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdHistory);
            this.pnlViewMid.Location = new System.Drawing.Point(3, 44);
            this.pnlViewMid.Size = new System.Drawing.Size(736, 469);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer2.Name = "rowHeaderRenderer2";
            rowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer2.TextRotationAngle = 0D;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(464, 15);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 2;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(167, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // txtLot
            // 
            this.txtLot.Location = new System.Drawing.Point(120, 15);
            this.txtLot.MaxLength = 25;
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(200, 20);
            this.txtLot.TabIndex = 1;
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLot.Location = new System.Drawing.Point(15, 19);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(36, 13);
            this.lblLot.TabIndex = 0;
            this.lblLot.Text = "Lot ID";
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1, Row 0, Column 0, ";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdHistory.HorizontalScrollBar.TabIndex = 8;
            this.spdHistory.Location = new System.Drawing.Point(0, 0);
            this.spdHistory.Name = "spdHistory";
            namedStyle5.BackColor = System.Drawing.SystemColors.Control;
            namedStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle5.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle5.Renderer = columnHeaderRenderer2;
            namedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle6.BackColor = System.Drawing.SystemColors.Control;
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle6.Renderer = rowHeaderRenderer2;
            namedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle7.BackColor = System.Drawing.SystemColors.Control;
            namedStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle7.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle7.Renderer = cornerRenderer2;
            namedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle8.BackColor = System.Drawing.SystemColors.Window;
            namedStyle8.CellType = generalCellType2;
            namedStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle8.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle8.Renderer = generalCellType2;
            this.spdHistory.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.spdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(736, 469);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 0;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdHistory.VerticalScrollBar.TabIndex = 9;
            this.spdHistory.SetViewportLeftColumn(0, 0, 1);
            this.spdHistory.SetActiveViewport(0, 0, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 36;
            spdHistory_Sheet1.RowCount = 5;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Res Oper Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Res Oper ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Set Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Set Resource Group";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Set Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Dispatcher ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Rule ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Temp Batch ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Temp Batch Seq.";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Current Operation";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Reference Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Unselect Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Lot Reserve Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Lot Reserve Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Capable Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Adjust Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Priority Score";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Adjust Reason";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Trigger by";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Dispatch Reason";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Unselect Reason";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Capable Reason";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Pds Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Pds Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Pds Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Pds Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Pds Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Pds Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Pds Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Pds Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Pds Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Pds Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "User ID";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Res Oper Flag";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Res Oper ID";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Lot ID";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Set Oper";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Set Resource Group";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Set Resource";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Dispatcher ID";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Rule ID";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Temp Batch ID";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Temp Batch Seq.";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 107F;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Current Operation";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Reference Oper";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Unselect Flag";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Lot Reserve Flag";
            this.spdHistory_Sheet1.Columns.Get(14).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Lot Reserve Time";
            this.spdHistory_Sheet1.Columns.Get(15).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Capable Flag";
            this.spdHistory_Sheet1.Columns.Get(16).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Adjust Flag";
            this.spdHistory_Sheet1.Columns.Get(17).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Priority Score";
            this.spdHistory_Sheet1.Columns.Get(18).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(19).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Adjust Reason";
            this.spdHistory_Sheet1.Columns.Get(20).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Trigger by";
            this.spdHistory_Sheet1.Columns.Get(21).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Dispatch Reason";
            this.spdHistory_Sheet1.Columns.Get(22).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Unselect Reason";
            this.spdHistory_Sheet1.Columns.Get(23).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 104F;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Capable Reason";
            this.spdHistory_Sheet1.Columns.Get(24).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 113F;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Pds Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(25).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Pds Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(26).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Pds Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(27).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Pds Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(28).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Pds Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(29).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Pds Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(30).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Pds Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(31).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Pds Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(32).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(32).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Pds Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(33).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(33).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Pds Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(34).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(34).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "User ID";
            this.spdHistory_Sheet1.Columns.Get(35).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(35).Width = 100F;
            this.spdHistory_Sheet1.FrozenColumnCount = 1;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmRTDViewPreDispatchedHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRTDViewPreDispatchedHistory";
            this.Text = "View Pre-Dispatched History";
            this.Load += new System.EventHandler(this.frmRTDViewPreDispatchedHistory_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtLot;
        private System.Windows.Forms.Label lblLot;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
    }
}
