namespace Miracom.QCMCore
{
    partial class frmQCMViewQCBatchList
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.grpBatList = new System.Windows.Forms.GroupBox();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvInspType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInspType = new System.Windows.Forms.Label();
            this.cdvInspSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblIQCInspSet = new System.Windows.Forms.Label();
            this.cdvInspMethod = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInspMethod = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            this.grpBatList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspMethod)).BeginInit();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 90);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvInspMethod);
            this.grpOption.Controls.Add(this.lblInspMethod);
            this.grpOption.Controls.Add(this.cdvInspSetID);
            this.grpOption.Controls.Add(this.lblIQCInspSet);
            this.grpOption.Controls.Add(this.cdvMatID);
            this.grpOption.Controls.Add(this.cdvInspType);
            this.grpOption.Controls.Add(this.lblInspType);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Size = new System.Drawing.Size(742, 90);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.grpBatList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 90);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 423);
            this.pnlViewMid.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(422, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(308, 20);
            this.pnlPeriod.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(107, 0);
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
            this.dtpTo.Location = new System.Drawing.Point(218, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(200, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // grpBatList
            // 
            this.grpBatList.Controls.Add(this.spdList);
            this.grpBatList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBatList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBatList.Location = new System.Drawing.Point(3, 3);
            this.grpBatList.Name = "grpBatList";
            this.grpBatList.Size = new System.Drawing.Size(736, 417);
            this.grpBatList.TabIndex = 0;
            this.grpBatList.TabStop = false;
            this.grpBatList.Text = "Batch List";
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.SystemColors.Control;
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 2;
            this.spdList.Location = new System.Drawing.Point(3, 16);
            this.spdList.Name = "spdList";
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.SelectionBlockOptions = ((FarPoint.Win.Spread.SelectionBlockOptions)((FarPoint.Win.Spread.SelectionBlockOptions.Cells | FarPoint.Win.Spread.SelectionBlockOptions.Rows)));
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(730, 398);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
            this.spdList.TabStop = false;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 3;
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 42;
            spdList_Sheet1.RowCount = 3;
            this.spdList_Sheet1.AlternatingRows.Get(0).BackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Batch Id";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Batch Del Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Mat ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat Ver";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Mat Desc";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Order ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Res ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Insp Set ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Insp Set Version";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Insp Type";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Insp Method";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Total Inspection";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Skip Result Recording";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Auto Final";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Item count";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Qty";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Insp Step";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Batch Status";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "PO";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "PO Item";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Vendor";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Customer";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Final Decision";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Bat Cmf 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Bat Cmf 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Bat Cmf 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Bat Cmf 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Bat Cmf 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Bat Cmf 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Bat Cmf 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Bat Cmf 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Bat Cmf 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Bat Cmf 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Last Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Item Result Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Insp Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Last Tran Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Create Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Create User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Update Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Update User ID";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdList_Sheet1.Columns.Get(0).Label = "Batch Id";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 80F;
            this.spdList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Label = "Batch Del Flag";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 80F;
            this.spdList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(2).Label = "Mat ID";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 80F;
            this.spdList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(3).Label = "Mat Ver";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 82F;
            this.spdList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(4).Label = "Mat Desc";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(5).Label = "Order ID";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).Width = 91F;
            this.spdList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(6).Label = "Res ID";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).Width = 80F;
            this.spdList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Label = "Total Inspection";
            this.spdList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Label = "Skip Result Recording";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 72F;
            this.spdList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Label = "Auto Final";
            this.spdList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(14).Label = "Item count";
            this.spdList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(15).Label = "Qty";
            this.spdList_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(33).Label = "Last Hist Seq";
            this.spdList_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(34).Label = "Item Result Seq";
            this.spdList_Sheet1.Columns.Get(34).Width = 101F;
            this.spdList_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(35).Label = "Insp Seq";
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvMatID
            // 
            this.cdvMatID.AddEmptyRowToLast = false;
            this.cdvMatID.AddEmptyRowToTop = false;
            this.cdvMatID.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMatID.DisplaySubItemIndex = 0;
            this.cdvMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelText = "Material";
            this.cdvMatID.ListCond_ExtFactory = "";
            this.cdvMatID.ListCond_StepMaterial = '1';
            this.cdvMatID.ListCond_StepVersion = '1';
            this.cdvMatID.Location = new System.Drawing.Point(422, 39);
            this.cdvMatID.MaterialEnabled = true;
            this.cdvMatID.MaterialReadOnly = false;
            this.cdvMatID.Name = "cdvMatID";
            this.cdvMatID.SearchSubItemIndex = 0;
            this.cdvMatID.SelectedDescIndex = -1;
            this.cdvMatID.SelectedSubItemIndex = 0;
            this.cdvMatID.Size = new System.Drawing.Size(308, 20);
            this.cdvMatID.TabIndex = 7;
            this.cdvMatID.VersionEnabled = true;
            this.cdvMatID.VersionReadOnly = false;
            this.cdvMatID.VisibleColumnHeader = false;
            this.cdvMatID.VisibleDescription = false;
            this.cdvMatID.VisibleMaterialButton = true;
            this.cdvMatID.VisibleVersionButton = true;
            this.cdvMatID.WidthButton = 20;
            this.cdvMatID.WidthLabel = 108;
            this.cdvMatID.WidthMaterialAndVersion = 200;
            this.cdvMatID.WidthVersion = 50;
            this.cdvMatID.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_MaterialSelectedItemChanged);
            this.cdvMatID.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_VersionSelectedItemChanged);
            // 
            // cdvInspType
            // 
            this.cdvInspType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInspType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInspType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInspType.BtnToolTipText = "";
            this.cdvInspType.DescText = "";
            this.cdvInspType.DisplaySubItemIndex = -1;
            this.cdvInspType.DisplayText = "";
            this.cdvInspType.Focusing = null;
            this.cdvInspType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInspType.Index = 0;
            this.cdvInspType.IsViewBtnImage = false;
            this.cdvInspType.Location = new System.Drawing.Point(117, 13);
            this.cdvInspType.MaxLength = 10;
            this.cdvInspType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspType.Name = "cdvInspType";
            this.cdvInspType.ReadOnly = false;
            this.cdvInspType.SearchSubItemIndex = 0;
            this.cdvInspType.SelectedDescIndex = -1;
            this.cdvInspType.SelectedSubItemIndex = -1;
            this.cdvInspType.SelectionStart = 0;
            this.cdvInspType.Size = new System.Drawing.Size(200, 20);
            this.cdvInspType.SmallImageList = null;
            this.cdvInspType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspType.TabIndex = 1;
            this.cdvInspType.TextBoxToolTipText = "";
            this.cdvInspType.TextBoxWidth = 200;
            this.cdvInspType.VisibleButton = true;
            this.cdvInspType.VisibleColumnHeader = false;
            this.cdvInspType.VisibleDescription = false;
            this.cdvInspType.ButtonPress += new System.EventHandler(this.cdvInspType_ButtonPress);
            // 
            // lblInspType
            // 
            this.lblInspType.AutoSize = true;
            this.lblInspType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspType.Location = new System.Drawing.Point(12, 16);
            this.lblInspType.Name = "lblInspType";
            this.lblInspType.Size = new System.Drawing.Size(57, 13);
            this.lblInspType.TabIndex = 0;
            this.lblInspType.Text = "Insp. Type";
            this.lblInspType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvInspSetID
            // 
            this.cdvInspSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInspSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInspSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInspSetID.BtnToolTipText = "";
            this.cdvInspSetID.DescText = "";
            this.cdvInspSetID.DisplaySubItemIndex = -1;
            this.cdvInspSetID.DisplayText = "";
            this.cdvInspSetID.Focusing = null;
            this.cdvInspSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInspSetID.Index = 0;
            this.cdvInspSetID.IsViewBtnImage = false;
            this.cdvInspSetID.Location = new System.Drawing.Point(117, 64);
            this.cdvInspSetID.MaxLength = 25;
            this.cdvInspSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspSetID.Name = "cdvInspSetID";
            this.cdvInspSetID.ReadOnly = false;
            this.cdvInspSetID.SearchSubItemIndex = 0;
            this.cdvInspSetID.SelectedDescIndex = -1;
            this.cdvInspSetID.SelectedSubItemIndex = -1;
            this.cdvInspSetID.SelectionStart = 0;
            this.cdvInspSetID.Size = new System.Drawing.Size(200, 20);
            this.cdvInspSetID.SmallImageList = null;
            this.cdvInspSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspSetID.TabIndex = 5;
            this.cdvInspSetID.TextBoxToolTipText = "";
            this.cdvInspSetID.TextBoxWidth = 200;
            this.cdvInspSetID.VisibleButton = true;
            this.cdvInspSetID.VisibleColumnHeader = false;
            this.cdvInspSetID.VisibleDescription = false;
            this.cdvInspSetID.ButtonPress += new System.EventHandler(this.cdvIQCInspSetID_ButtonPress);
            // 
            // lblIQCInspSet
            // 
            this.lblIQCInspSet.AutoSize = true;
            this.lblIQCInspSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblIQCInspSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIQCInspSet.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblIQCInspSet.Location = new System.Drawing.Point(10, 68);
            this.lblIQCInspSet.Name = "lblIQCInspSet";
            this.lblIQCInspSet.Size = new System.Drawing.Size(63, 13);
            this.lblIQCInspSet.TabIndex = 4;
            this.lblIQCInspSet.Text = "Insp. Set ID";
            // 
            // cdvInspMethod
            // 
            this.cdvInspMethod.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInspMethod.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInspMethod.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInspMethod.BtnToolTipText = "";
            this.cdvInspMethod.DescText = "";
            this.cdvInspMethod.DisplaySubItemIndex = -1;
            this.cdvInspMethod.DisplayText = "";
            this.cdvInspMethod.Focusing = null;
            this.cdvInspMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInspMethod.Index = 0;
            this.cdvInspMethod.IsViewBtnImage = false;
            this.cdvInspMethod.Location = new System.Drawing.Point(117, 39);
            this.cdvInspMethod.MaxLength = 10;
            this.cdvInspMethod.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspMethod.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspMethod.Name = "cdvInspMethod";
            this.cdvInspMethod.ReadOnly = false;
            this.cdvInspMethod.SearchSubItemIndex = 0;
            this.cdvInspMethod.SelectedDescIndex = -1;
            this.cdvInspMethod.SelectedSubItemIndex = -1;
            this.cdvInspMethod.SelectionStart = 0;
            this.cdvInspMethod.Size = new System.Drawing.Size(200, 20);
            this.cdvInspMethod.SmallImageList = null;
            this.cdvInspMethod.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspMethod.TabIndex = 3;
            this.cdvInspMethod.TextBoxToolTipText = "";
            this.cdvInspMethod.TextBoxWidth = 200;
            this.cdvInspMethod.VisibleButton = true;
            this.cdvInspMethod.VisibleColumnHeader = false;
            this.cdvInspMethod.VisibleDescription = false;
            this.cdvInspMethod.ButtonPress += new System.EventHandler(this.cdvInspMethod_ButtonPress);
            // 
            // lblInspMethod
            // 
            this.lblInspMethod.AutoSize = true;
            this.lblInspMethod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspMethod.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInspMethod.Location = new System.Drawing.Point(9, 42);
            this.lblInspMethod.Name = "lblInspMethod";
            this.lblInspMethod.Size = new System.Drawing.Size(95, 13);
            this.lblInspMethod.TabIndex = 2;
            this.lblInspMethod.Text = "Inspection Method";
            // 
            // frmQCMViewQCBatchList
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmQCMViewQCBatchList";
            this.Tag = "QCM3004";
            this.Text = "View QC Batch List";
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.grpBatList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspMethod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.GroupBox grpBatList;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private Miracom.MESCore.Controls.udcMaterial cdvMatID;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspType;
        protected System.Windows.Forms.Label lblInspType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspSetID;
        private System.Windows.Forms.Label lblIQCInspSet;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspMethod;
        private System.Windows.Forms.Label lblInspMethod;
    }
}
