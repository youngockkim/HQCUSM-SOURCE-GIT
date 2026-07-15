namespace Miracom.QCMCore
{
    partial class frmQCMViewInspectionHistory
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
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQCMViewInspectionHistory));
            this.txtBatchID = new System.Windows.Forms.TextBox();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.pnlBatchHistory = new System.Windows.Forms.Panel();
            this.grpBatchHistory = new System.Windows.Forms.GroupBox();
            this.spdBatchHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdBatchHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grpItemHistory = new System.Windows.Forms.GroupBox();
            this.spdItemHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdItemHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExcel1 = new System.Windows.Forms.Button();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBatchHistory.SuspendLayout();
            this.grpBatchHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdBatchHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdBatchHistory_Sheet1)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            this.grpItemHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdItemHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdItemHistory_Sheet1)).BeginInit();
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
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 42);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.txtBatchID);
            this.grpOption.Controls.Add(this.lblBatchID);
            this.grpOption.Size = new System.Drawing.Size(742, 42);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.grpItemHistory);
            this.pnlViewMid.Controls.Add(this.splitter1);
            this.pnlViewMid.Controls.Add(this.pnlBatchHistory);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 42);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 471);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel1);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel1, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // txtBatchID
            // 
            this.txtBatchID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBatchID.Location = new System.Drawing.Point(120, 15);
            this.txtBatchID.MaxLength = 30;
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.Size = new System.Drawing.Size(200, 20);
            this.txtBatchID.TabIndex = 1;
            this.txtBatchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchID_KeyPress);
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchID.Location = new System.Drawing.Point(15, 19);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(57, 13);
            this.lblBatchID.TabIndex = 0;
            this.lblBatchID.Text = "Batch ID";
            this.lblBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBatchHistory
            // 
            this.pnlBatchHistory.Controls.Add(this.grpBatchHistory);
            this.pnlBatchHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBatchHistory.Location = new System.Drawing.Point(0, 0);
            this.pnlBatchHistory.Name = "pnlBatchHistory";
            this.pnlBatchHistory.Size = new System.Drawing.Size(742, 185);
            this.pnlBatchHistory.TabIndex = 0;
            // 
            // grpBatchHistory
            // 
            this.grpBatchHistory.Controls.Add(this.spdBatchHistory);
            this.grpBatchHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBatchHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBatchHistory.Location = new System.Drawing.Point(0, 0);
            this.grpBatchHistory.Name = "grpBatchHistory";
            this.grpBatchHistory.Size = new System.Drawing.Size(742, 185);
            this.grpBatchHistory.TabIndex = 0;
            this.grpBatchHistory.TabStop = false;
            this.grpBatchHistory.Text = "Batch History";
            // 
            // spdBatchHistory
            // 
            this.spdBatchHistory.AccessibleDescription = "spdBatchHistory, Sheet1, Row 0, Column 0, ";
            this.spdBatchHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdBatchHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdBatchHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdBatchHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdBatchHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdBatchHistory.HorizontalScrollBar.Name = "";
            this.spdBatchHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdBatchHistory.HorizontalScrollBar.TabIndex = 2;
            this.spdBatchHistory.Location = new System.Drawing.Point(3, 16);
            this.spdBatchHistory.Name = "spdBatchHistory";
            this.spdBatchHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdBatchHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdBatchHistory.SelectionBlockOptions = ((FarPoint.Win.Spread.SelectionBlockOptions)((FarPoint.Win.Spread.SelectionBlockOptions.Cells | FarPoint.Win.Spread.SelectionBlockOptions.Rows)));
            this.spdBatchHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdBatchHistory_Sheet1});
            this.spdBatchHistory.Size = new System.Drawing.Size(736, 166);
            this.spdBatchHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdBatchHistory.TabIndex = 0;
            this.spdBatchHistory.TabStop = false;
            this.spdBatchHistory.TextTipDelay = 200;
            this.spdBatchHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdBatchHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdBatchHistory.VerticalScrollBar.Name = "";
            this.spdBatchHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdBatchHistory.VerticalScrollBar.TabIndex = 3;
            this.spdBatchHistory.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdBatchHistory_CellClick);
            // 
            // spdBatchHistory_Sheet1
            // 
            this.spdBatchHistory_Sheet1.Reset();
            spdBatchHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdBatchHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdBatchHistory_Sheet1.ColumnCount = 23;
            spdBatchHistory_Sheet1.RowCount = 3;
            this.spdBatchHistory_Sheet1.AlternatingRows.Get(0).BackColor = System.Drawing.Color.White;
            this.spdBatchHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdBatchHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBatchHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdBatchHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBatchHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Hist Seq";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Insp Set ID";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Insp Set Version";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Insp Item";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Insp Method";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Sample Qty";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Test Qty";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Defect Qty";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Result ";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Insp Seq";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "ISP Cmf 1";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "ISP Cmf 2";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "ISPCmf 3";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "ISP Cmf 4";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "ISP Cmf 5";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "ISP Cmf 6";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "ISP Cmf 7";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "ISP Cmf 8";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "ISP Cmf 9";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "ISP Cmf 10";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Comment";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Tran User Id";
            this.spdBatchHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Tran Time";
            this.spdBatchHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBatchHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdBatchHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdBatchHistory_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdBatchHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdBatchHistory_Sheet1.Columns.Get(0).Label = "Hist Seq";
            this.spdBatchHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdBatchHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBatchHistory_Sheet1.Columns.Get(0).Width = 80F;
            this.spdBatchHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdBatchHistory_Sheet1.Columns.Get(1).Label = "Insp Set ID";
            this.spdBatchHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdBatchHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBatchHistory_Sheet1.Columns.Get(1).Width = 80F;
            this.spdBatchHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdBatchHistory_Sheet1.Columns.Get(2).Label = "Insp Set Version";
            this.spdBatchHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdBatchHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBatchHistory_Sheet1.Columns.Get(2).Width = 80F;
            this.spdBatchHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdBatchHistory_Sheet1.Columns.Get(4).Label = "Insp Method";
            this.spdBatchHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdBatchHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBatchHistory_Sheet1.Columns.Get(4).Width = 80F;
            this.spdBatchHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdBatchHistory_Sheet1.Columns.Get(5).Label = "Sample Qty";
            this.spdBatchHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdBatchHistory_Sheet1.Columns.Get(6).Label = "Test Qty";
            this.spdBatchHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdBatchHistory_Sheet1.Columns.Get(7).Label = "Defect Qty";
            this.spdBatchHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdBatchHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBatchHistory_Sheet1.Columns.Get(7).Width = 82F;
            this.spdBatchHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdBatchHistory_Sheet1.Columns.Get(8).Label = "Result ";
            this.spdBatchHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdBatchHistory_Sheet1.Columns.Get(9).Label = "Insp Seq";
            this.spdBatchHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdBatchHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdBatchHistory_Sheet1.Columns.Get(9).Width = 72F;
            this.spdBatchHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdBatchHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdBatchHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBatchHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdBatchHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdBatchHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdBatchHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdBatchHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdBatchHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Enabled = false;
            this.pnlPeriod.Location = new System.Drawing.Point(473, 15);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 2;
            this.pnlPeriod.Visible = false;
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
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 185);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(742, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // grpItemHistory
            // 
            this.grpItemHistory.Controls.Add(this.spdItemHistory);
            this.grpItemHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItemHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpItemHistory.Location = new System.Drawing.Point(0, 188);
            this.grpItemHistory.Name = "grpItemHistory";
            this.grpItemHistory.Size = new System.Drawing.Size(742, 283);
            this.grpItemHistory.TabIndex = 0;
            this.grpItemHistory.TabStop = false;
            this.grpItemHistory.Text = "Item History";
            // 
            // spdItemHistory
            // 
            this.spdItemHistory.AccessibleDescription = "spdItemHistory, Sheet1, Row 0, Column 0, ";
            this.spdItemHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdItemHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdItemHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdItemHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdItemHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdItemHistory.HorizontalScrollBar.Name = "";
            this.spdItemHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdItemHistory.HorizontalScrollBar.TabIndex = 2;
            this.spdItemHistory.Location = new System.Drawing.Point(3, 16);
            this.spdItemHistory.Name = "spdItemHistory";
            this.spdItemHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdItemHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdItemHistory.SelectionBlockOptions = ((FarPoint.Win.Spread.SelectionBlockOptions)((FarPoint.Win.Spread.SelectionBlockOptions.Cells | FarPoint.Win.Spread.SelectionBlockOptions.Rows)));
            this.spdItemHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdItemHistory_Sheet1});
            this.spdItemHistory.Size = new System.Drawing.Size(736, 264);
            this.spdItemHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdItemHistory.TabIndex = 0;
            this.spdItemHistory.TabStop = false;
            this.spdItemHistory.TextTipDelay = 200;
            this.spdItemHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdItemHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdItemHistory.VerticalScrollBar.Name = "";
            this.spdItemHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdItemHistory.VerticalScrollBar.TabIndex = 3;
            // 
            // spdItemHistory_Sheet1
            // 
            this.spdItemHistory_Sheet1.Reset();
            spdItemHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdItemHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdItemHistory_Sheet1.ColumnCount = 20;
            spdItemHistory_Sheet1.RowCount = 3;
            this.spdItemHistory_Sheet1.AlternatingRows.Get(0).BackColor = System.Drawing.Color.White;
            this.spdItemHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdItemHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdItemHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Item ID";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Sample Qty";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Test Qty";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Defect Qty";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Insp Seq";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Result";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Defect Code";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "ISP Cmf 1";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "ISP Cmf 2";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "ISP Cmf 3";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "ISP Cmf 4";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "ISP Cmf 5";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "ISP Cmf 6";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "ISP Cmf 7";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "ISP Cmf 8";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "ISP Cmf 9";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "ISP Cmf 10";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Comment";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Tran User Id";
            this.spdItemHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Tran Time";
            this.spdItemHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdItemHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdItemHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdItemHistory_Sheet1.Columns.Get(0).Label = "Item ID";
            this.spdItemHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdItemHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemHistory_Sheet1.Columns.Get(0).Width = 80F;
            this.spdItemHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdItemHistory_Sheet1.Columns.Get(1).Label = "Sample Qty";
            this.spdItemHistory_Sheet1.Columns.Get(1).Visible = false;
            this.spdItemHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdItemHistory_Sheet1.Columns.Get(2).Label = "Test Qty";
            this.spdItemHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdItemHistory_Sheet1.Columns.Get(3).Label = "Defect Qty";
            this.spdItemHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdItemHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemHistory_Sheet1.Columns.Get(3).Width = 82F;
            this.spdItemHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdItemHistory_Sheet1.Columns.Get(4).Label = "Insp Seq";
            this.spdItemHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdItemHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdItemHistory_Sheet1.Columns.Get(4).Width = 72F;
            this.spdItemHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdItemHistory_Sheet1.Columns.Get(5).Label = "Result";
            this.spdItemHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdItemHistory_Sheet1.Columns.Get(6).Label = "Defect Code";
            this.spdItemHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdItemHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdItemHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdItemHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdItemHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdItemHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdItemHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdItemHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnExcel1
            // 
            this.btnExcel1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel1.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel1.Image")));
            this.btnExcel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel1.Location = new System.Drawing.Point(42, 8);
            this.btnExcel1.Name = "btnExcel1";
            this.btnExcel1.Size = new System.Drawing.Size(24, 24);
            this.btnExcel1.TabIndex = 3;
            this.btnExcel1.Click += new System.EventHandler(this.btnExcel1_Click);
            // 
            // frmQCMViewInspectionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmQCMViewInspectionHistory";
            this.Tag = "QCM3003";
            this.Text = "View Inspection History";
            this.Activated += new System.EventHandler(this.frmQCMViewInspectionHistory_Activated);
            this.Load += new System.EventHandler(this.frmQCMViewInspectionHistory_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBatchHistory.ResumeLayout(false);
            this.grpBatchHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdBatchHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdBatchHistory_Sheet1)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.grpItemHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdItemHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdItemHistory_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TextBox txtBatchID;
        protected System.Windows.Forms.Label lblBatchID;
        private System.Windows.Forms.Panel pnlBatchHistory;
        private System.Windows.Forms.GroupBox grpBatchHistory;
        private FarPoint.Win.Spread.FpSpread spdBatchHistory;
        private FarPoint.Win.Spread.SheetView spdBatchHistory_Sheet1;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.GroupBox grpItemHistory;
        private FarPoint.Win.Spread.FpSpread spdItemHistory;
        private FarPoint.Win.Spread.SheetView spdItemHistory_Sheet1;
        private System.Windows.Forms.Splitter splitter1;
        public System.Windows.Forms.Button btnExcel1;
    }
}
