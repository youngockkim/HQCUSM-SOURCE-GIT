namespace Miracom.QCMCore
{
    public partial class frmQCMViewQCBatchStatus
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType10 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.tabTran = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlGeneralMiddle = new System.Windows.Forms.Panel();
            this.pnlTranInfo = new System.Windows.Forms.Panel();
            this.pnlInspItem = new System.Windows.Forms.Panel();
            this.grpInspItem = new System.Windows.Forms.GroupBox();
            this.spdInspItem = new FarPoint.Win.Spread.FpSpread();
            this.spdInspItem_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpDefect = new System.Windows.Forms.GroupBox();
            this.pnlDefect = new System.Windows.Forms.Panel();
            this.spdDefect = new FarPoint.Win.Spread.FpSpread();
            this.spdDefect_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlDefectInspItem = new System.Windows.Forms.Panel();
            this.btnHideDefect = new System.Windows.Forms.Button();
            this.txtDefectInspItem = new System.Windows.Forms.TextBox();
            this.pnlGeneralTop = new System.Windows.Forms.Panel();
            this.grpBatInfo = new System.Windows.Forms.GroupBox();
            this.pnlBatchInfoMain = new System.Windows.Forms.Panel();
            this.ctrlBatchInfo = new Miracom.QCMCore.udcQCMBatchInfo();
            this.tbpItem = new System.Windows.Forms.TabPage();
            this.lisItem = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSelectedInspItem = new System.Windows.Forms.Panel();
            this.grpSelectedInspItem = new System.Windows.Forms.GroupBox();
            this.cdvInspItem = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtDefectQty = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtTestQty = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtItemCount = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.pnlCMF = new System.Windows.Forms.Panel();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.txtBatchID = new System.Windows.Forms.TextBox();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlGeneralMiddle.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.pnlInspItem.SuspendLayout();
            this.grpInspItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem_Sheet1)).BeginInit();
            this.grpDefect.SuspendLayout();
            this.pnlDefect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect_Sheet1)).BeginInit();
            this.pnlDefectInspItem.SuspendLayout();
            this.pnlGeneralTop.SuspendLayout();
            this.grpBatInfo.SuspendLayout();
            this.pnlBatchInfoMain.SuspendLayout();
            this.tbpItem.SuspendLayout();
            this.pnlSelectedInspItem.SuspendLayout();
            this.grpSelectedInspItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspItem)).BeginInit();
            this.tbpCMF.SuspendLayout();
            this.pnlCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Enabled = false;
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Visible = false;
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtBatchID);
            this.grpOption.Controls.Add(this.lblBatchID);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.tabTran);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(3);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchID.Location = new System.Drawing.Point(19, 31);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(57, 13);
            this.lblBatchID.TabIndex = 0;
            this.lblBatchID.Text = "Batch ID";
            this.lblBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpGeneral);
            this.tabTran.Controls.Add(this.tbpItem);
            this.tabTran.Controls.Add(this.tbpCMF);
            this.tabTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTran.ItemSize = new System.Drawing.Size(60, 18);
            this.tabTran.Location = new System.Drawing.Point(3, 3);
            this.tabTran.Name = "tabTran";
            this.tabTran.SelectedIndex = 0;
            this.tabTran.Size = new System.Drawing.Size(736, 436);
            this.tabTran.TabIndex = 1;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlGeneralMiddle);
            this.tbpGeneral.Controls.Add(this.pnlGeneralTop);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(728, 410);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlGeneralMiddle
            // 
            this.pnlGeneralMiddle.Controls.Add(this.pnlTranInfo);
            this.pnlGeneralMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneralMiddle.Location = new System.Drawing.Point(0, 146);
            this.pnlGeneralMiddle.Name = "pnlGeneralMiddle";
            this.pnlGeneralMiddle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlGeneralMiddle.Size = new System.Drawing.Size(728, 264);
            this.pnlGeneralMiddle.TabIndex = 0;
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.pnlInspItem);
            this.pnlTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTranInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlTranInfo.Name = "pnlTranInfo";
            this.pnlTranInfo.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 261);
            this.pnlTranInfo.TabIndex = 1;
            // 
            // pnlInspItem
            // 
            this.pnlInspItem.Controls.Add(this.grpInspItem);
            this.pnlInspItem.Controls.Add(this.grpDefect);
            this.pnlInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlInspItem.Location = new System.Drawing.Point(3, 0);
            this.pnlInspItem.Name = "pnlInspItem";
            this.pnlInspItem.Size = new System.Drawing.Size(722, 261);
            this.pnlInspItem.TabIndex = 7;
            // 
            // grpInspItem
            // 
            this.grpInspItem.Controls.Add(this.spdInspItem);
            this.grpInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInspItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInspItem.Location = new System.Drawing.Point(0, 0);
            this.grpInspItem.Name = "grpInspItem";
            this.grpInspItem.Size = new System.Drawing.Size(722, 261);
            this.grpInspItem.TabIndex = 8;
            this.grpInspItem.TabStop = false;
            this.grpInspItem.Text = "Inspection Item";
            // 
            // spdInspItem
            // 
            this.spdInspItem.AccessibleDescription = "spdInspItem";
            this.spdInspItem.BackColor = System.Drawing.SystemColors.Control;
            this.spdInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdInspItem.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdInspItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInspItem.HorizontalScrollBar.Name = "";
            this.spdInspItem.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdInspItem.HorizontalScrollBar.TabIndex = 2;
            this.spdInspItem.Location = new System.Drawing.Point(3, 16);
            this.spdInspItem.Name = "spdInspItem";
            this.spdInspItem.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdInspItem.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdInspItem.SelectionBlockOptions = ((FarPoint.Win.Spread.SelectionBlockOptions)((FarPoint.Win.Spread.SelectionBlockOptions.Cells | FarPoint.Win.Spread.SelectionBlockOptions.Rows)));
            this.spdInspItem.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdInspItem_Sheet1});
            this.spdInspItem.Size = new System.Drawing.Size(716, 242);
            this.spdInspItem.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdInspItem.TabIndex = 5;
            this.spdInspItem.TabStop = false;
            this.spdInspItem.TextTipDelay = 200;
            this.spdInspItem.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdInspItem.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInspItem.VerticalScrollBar.Name = "";
            this.spdInspItem.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdInspItem.VerticalScrollBar.TabIndex = 3;
            this.spdInspItem.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdInspItem_CellClick);
            this.spdInspItem.SetViewportLeftColumn(0, 0, 3);
            this.spdInspItem.SetActiveViewport(0, 0, -1);
            // 
            // spdInspItem_Sheet1
            // 
            this.spdInspItem_Sheet1.Reset();
            spdInspItem_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdInspItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdInspItem_Sheet1.ColumnCount = 20;
            spdInspItem_Sheet1.RowCount = 3;
            this.spdInspItem_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdInspItem_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Insp. Item";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Inspection Method";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Sampling Proc.";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Samp. Proc. Type";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Samp. Proc. Rate";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Fix Samp Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Samp. Proc. Unit";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Determine Value";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Determine Unit";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Check Determine Flag";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Samp. Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Test Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Defect Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Defect Code";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Result";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Comment";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Tran Time";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "User";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Defect Group";
            this.spdInspItem_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdInspItem_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdInspItem_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(0).Label = "Insp. Item";
            this.spdInspItem_Sheet1.Columns.Get(0).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(0).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(1).Label = "Description";
            this.spdInspItem_Sheet1.Columns.Get(1).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(1).Width = 100F;
            this.spdInspItem_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(2).Label = "Inspection Method";
            this.spdInspItem_Sheet1.Columns.Get(2).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(2).Width = 121F;
            this.spdInspItem_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(3).Label = "Sampling Proc.";
            this.spdInspItem_Sheet1.Columns.Get(3).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(3).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(3).Width = 130F;
            this.spdInspItem_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(4).Label = "Samp. Proc. Type";
            this.spdInspItem_Sheet1.Columns.Get(4).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(4).Width = 97F;
            this.spdInspItem_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(5).Label = "Samp. Proc. Rate";
            this.spdInspItem_Sheet1.Columns.Get(5).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(5).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(5).Width = 97F;
            this.spdInspItem_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(6).CellType = numberCellType7;
            this.spdInspItem_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(6).Label = "Fix Samp Qty";
            this.spdInspItem_Sheet1.Columns.Get(6).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(6).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(6).Width = 107F;
            this.spdInspItem_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(7).Label = "Samp. Proc. Unit";
            this.spdInspItem_Sheet1.Columns.Get(7).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(7).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(7).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(8).Label = "Determine Value";
            this.spdInspItem_Sheet1.Columns.Get(8).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(8).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(8).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(9).Label = "Determine Unit";
            this.spdInspItem_Sheet1.Columns.Get(9).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(9).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(9).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(10).Label = "Check Determine Flag";
            this.spdInspItem_Sheet1.Columns.Get(10).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(10).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(10).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(11).CellType = numberCellType8;
            this.spdInspItem_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(11).Label = "Samp. Qty";
            this.spdInspItem_Sheet1.Columns.Get(11).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(11).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(12).BackColor = System.Drawing.Color.WhiteSmoke;
            numberCellType9.MinimumValue = 0D;
            this.spdInspItem_Sheet1.Columns.Get(12).CellType = numberCellType9;
            this.spdInspItem_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(12).Label = "Test Qty";
            this.spdInspItem_Sheet1.Columns.Get(12).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(12).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.WhiteSmoke;
            numberCellType10.MinimumValue = 0D;
            this.spdInspItem_Sheet1.Columns.Get(13).CellType = numberCellType10;
            this.spdInspItem_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(13).Label = "Defect Qty";
            this.spdInspItem_Sheet1.Columns.Get(13).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(13).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(14).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(14).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(14).Label = "Defect Code";
            this.spdInspItem_Sheet1.Columns.Get(14).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(14).Width = 82F;
            this.spdInspItem_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(15).Label = "Result";
            this.spdInspItem_Sheet1.Columns.Get(15).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(16).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(16).Label = "Comment";
            this.spdInspItem_Sheet1.Columns.Get(16).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(16).Width = 213F;
            this.spdInspItem_Sheet1.Columns.Get(17).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(17).Label = "Tran Time";
            this.spdInspItem_Sheet1.Columns.Get(17).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(17).Width = 131F;
            this.spdInspItem_Sheet1.Columns.Get(18).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(18).Label = "User";
            this.spdInspItem_Sheet1.Columns.Get(18).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(18).Width = 122F;
            this.spdInspItem_Sheet1.Columns.Get(19).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(19).Label = "Defect Group";
            this.spdInspItem_Sheet1.Columns.Get(19).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(19).Resizable = false;
            this.spdInspItem_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(19).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(19).Width = 80F;
            this.spdInspItem_Sheet1.FrozenColumnCount = 3;
            this.spdInspItem_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdInspItem_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdInspItem_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdInspItem_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdInspItem_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdInspItem_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdInspItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpDefect
            // 
            this.grpDefect.Controls.Add(this.pnlDefect);
            this.grpDefect.Controls.Add(this.pnlDefectInspItem);
            this.grpDefect.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpDefect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDefect.Location = new System.Drawing.Point(722, 0);
            this.grpDefect.Name = "grpDefect";
            this.grpDefect.Size = new System.Drawing.Size(0, 261);
            this.grpDefect.TabIndex = 7;
            this.grpDefect.TabStop = false;
            this.grpDefect.Text = "Defect";
            this.grpDefect.Visible = false;
            // 
            // pnlDefect
            // 
            this.pnlDefect.Controls.Add(this.spdDefect);
            this.pnlDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDefect.Location = new System.Drawing.Point(3, 60);
            this.pnlDefect.Name = "pnlDefect";
            this.pnlDefect.Padding = new System.Windows.Forms.Padding(3);
            this.pnlDefect.Size = new System.Drawing.Size(0, 198);
            this.pnlDefect.TabIndex = 1;
            // 
            // spdDefect
            // 
            this.spdDefect.AccessibleDescription = "spdDefect";
            this.spdDefect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefect.Location = new System.Drawing.Point(3, 3);
            this.spdDefect.Name = "spdDefect";
            this.spdDefect.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdDefect.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdDefect.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDefect_Sheet1});
            this.spdDefect.Size = new System.Drawing.Size(0, 192);
            this.spdDefect.TabIndex = 7;
            this.spdDefect.TabStop = false;
            this.spdDefect.SetViewportLeftColumn(0, 0, 3);
            this.spdDefect.SetActiveViewport(0, 0, -1);
            // 
            // spdDefect_Sheet1
            // 
            this.spdDefect_Sheet1.Reset();
            spdDefect_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDefect_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDefect_Sheet1.ColumnCount = 2;
            spdDefect_Sheet1.RowCount = 10;
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Defect Code";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Qty";
            this.spdDefect_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdDefect_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdDefect_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefect_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDefect_Sheet1.Columns.Get(0).Label = "Defect Code";
            this.spdDefect_Sheet1.Columns.Get(0).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(0).Width = 100F;
            this.spdDefect_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            numberCellType6.DecimalPlaces = 0;
            numberCellType6.MinimumValue = 0D;
            this.spdDefect_Sheet1.Columns.Get(1).CellType = numberCellType6;
            this.spdDefect_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDefect_Sheet1.Columns.Get(1).Label = "Qty";
            this.spdDefect_Sheet1.Columns.Get(1).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(1).Width = 50F;
            this.spdDefect_Sheet1.FrozenColumnCount = 3;
            this.spdDefect_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdDefect_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdDefect_Sheet1.Rows.Get(0).Height = 18F;
            this.spdDefect_Sheet1.Rows.Get(1).Height = 18F;
            this.spdDefect_Sheet1.Rows.Get(2).Height = 18F;
            this.spdDefect_Sheet1.Rows.Get(3).Height = 18F;
            this.spdDefect_Sheet1.Rows.Get(4).Height = 18F;
            this.spdDefect_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdDefect_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlDefectInspItem
            // 
            this.pnlDefectInspItem.Controls.Add(this.btnHideDefect);
            this.pnlDefectInspItem.Controls.Add(this.txtDefectInspItem);
            this.pnlDefectInspItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDefectInspItem.Location = new System.Drawing.Point(3, 16);
            this.pnlDefectInspItem.Name = "pnlDefectInspItem";
            this.pnlDefectInspItem.Size = new System.Drawing.Size(0, 44);
            this.pnlDefectInspItem.TabIndex = 0;
            // 
            // btnHideDefect
            // 
            this.btnHideDefect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHideDefect.Location = new System.Drawing.Point(16, 10);
            this.btnHideDefect.Name = "btnHideDefect";
            this.btnHideDefect.Size = new System.Drawing.Size(22, 24);
            this.btnHideDefect.TabIndex = 32;
            this.btnHideDefect.Text = "<<";
            this.btnHideDefect.Click += new System.EventHandler(this.btnHideDefect_Click);
            // 
            // txtDefectInspItem
            // 
            this.txtDefectInspItem.Location = new System.Drawing.Point(76, 12);
            this.txtDefectInspItem.MaxLength = 25;
            this.txtDefectInspItem.Name = "txtDefectInspItem";
            this.txtDefectInspItem.ReadOnly = true;
            this.txtDefectInspItem.Size = new System.Drawing.Size(157, 20);
            this.txtDefectInspItem.TabIndex = 2;
            this.txtDefectInspItem.TabStop = false;
            // 
            // pnlGeneralTop
            // 
            this.pnlGeneralTop.Controls.Add(this.grpBatInfo);
            this.pnlGeneralTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGeneralTop.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneralTop.Name = "pnlGeneralTop";
            this.pnlGeneralTop.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlGeneralTop.Size = new System.Drawing.Size(728, 146);
            this.pnlGeneralTop.TabIndex = 0;
            // 
            // grpBatInfo
            // 
            this.grpBatInfo.Controls.Add(this.pnlBatchInfoMain);
            this.grpBatInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBatInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBatInfo.Location = new System.Drawing.Point(3, 3);
            this.grpBatInfo.Name = "grpBatInfo";
            this.grpBatInfo.Size = new System.Drawing.Size(722, 143);
            this.grpBatInfo.TabIndex = 0;
            this.grpBatInfo.TabStop = false;
            this.grpBatInfo.Text = "Batch Information";
            // 
            // pnlBatchInfoMain
            // 
            this.pnlBatchInfoMain.Controls.Add(this.ctrlBatchInfo);
            this.pnlBatchInfoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBatchInfoMain.Location = new System.Drawing.Point(3, 16);
            this.pnlBatchInfoMain.Name = "pnlBatchInfoMain";
            this.pnlBatchInfoMain.Padding = new System.Windows.Forms.Padding(1);
            this.pnlBatchInfoMain.Size = new System.Drawing.Size(716, 124);
            this.pnlBatchInfoMain.TabIndex = 0;
            // 
            // ctrlBatchInfo
            // 
            this.ctrlBatchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlBatchInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlBatchInfo.Location = new System.Drawing.Point(1, 1);
            this.ctrlBatchInfo.Name = "ctrlBatchInfo";
            this.ctrlBatchInfo.Size = new System.Drawing.Size(714, 122);
            this.ctrlBatchInfo.TabIndex = 0;
            // 
            // tbpItem
            // 
            this.tbpItem.Controls.Add(this.lisItem);
            this.tbpItem.Controls.Add(this.pnlSelectedInspItem);
            this.tbpItem.Location = new System.Drawing.Point(4, 22);
            this.tbpItem.Name = "tbpItem";
            this.tbpItem.Padding = new System.Windows.Forms.Padding(3);
            this.tbpItem.Size = new System.Drawing.Size(728, 410);
            this.tbpItem.TabIndex = 2;
            this.tbpItem.Text = "Item Information";
            this.tbpItem.Visible = false;
            // 
            // lisItem
            // 
            this.lisItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8,
            this.ColumnHeader12,
            this.ColumnHeader11,
            this.ColumnHeader1,
            this.ColumnHeader13,
            this.ColumnHeader14,
            this.ColumnHeader15});
            this.lisItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisItem.EnableSort = true;
            this.lisItem.EnableSortIcon = true;
            this.lisItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisItem.FullRowSelect = true;
            this.lisItem.GridLines = true;
            this.lisItem.Location = new System.Drawing.Point(3, 78);
            this.lisItem.Name = "lisItem";
            this.lisItem.Size = new System.Drawing.Size(722, 329);
            this.lisItem.TabIndex = 3;
            this.lisItem.UseCompatibleStateImageBehavior = false;
            this.lisItem.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Seq.";
            this.ColumnHeader6.Width = 40;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Item Serial ID";
            this.ColumnHeader7.Width = 150;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Qty";
            this.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Result";
            this.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Defect Code";
            this.ColumnHeader11.Width = 79;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Comment";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Status";
            this.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.Text = "Tran Time";
            this.ColumnHeader14.Width = 120;
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "User";
            // 
            // pnlSelectedInspItem
            // 
            this.pnlSelectedInspItem.Controls.Add(this.grpSelectedInspItem);
            this.pnlSelectedInspItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectedInspItem.Location = new System.Drawing.Point(3, 3);
            this.pnlSelectedInspItem.Name = "pnlSelectedInspItem";
            this.pnlSelectedInspItem.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlSelectedInspItem.Size = new System.Drawing.Size(722, 75);
            this.pnlSelectedInspItem.TabIndex = 0;
            // 
            // grpSelectedInspItem
            // 
            this.grpSelectedInspItem.Controls.Add(this.cdvInspItem);
            this.grpSelectedInspItem.Controls.Add(this.Label3);
            this.grpSelectedInspItem.Controls.Add(this.txtDefectQty);
            this.grpSelectedInspItem.Controls.Add(this.Label4);
            this.grpSelectedInspItem.Controls.Add(this.txtTestQty);
            this.grpSelectedInspItem.Controls.Add(this.Label5);
            this.grpSelectedInspItem.Controls.Add(this.txtItemCount);
            this.grpSelectedInspItem.Controls.Add(this.Label2);
            this.grpSelectedInspItem.Controls.Add(this.txtResult);
            this.grpSelectedInspItem.Controls.Add(this.Label1);
            this.grpSelectedInspItem.Controls.Add(this.Label8);
            this.grpSelectedInspItem.Controls.Add(this.txtSeq);
            this.grpSelectedInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSelectedInspItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSelectedInspItem.Location = new System.Drawing.Point(0, 0);
            this.grpSelectedInspItem.Name = "grpSelectedInspItem";
            this.grpSelectedInspItem.Size = new System.Drawing.Size(722, 72);
            this.grpSelectedInspItem.TabIndex = 0;
            this.grpSelectedInspItem.TabStop = false;
            this.grpSelectedInspItem.Text = "Selected Insp. Item";
            // 
            // cdvInspItem
            // 
            this.cdvInspItem.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInspItem.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInspItem.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInspItem.BtnToolTipText = "";
            this.cdvInspItem.DescText = "";
            this.cdvInspItem.DisplaySubItemIndex = -1;
            this.cdvInspItem.DisplayText = "";
            this.cdvInspItem.Focusing = null;
            this.cdvInspItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInspItem.Index = 0;
            this.cdvInspItem.IsViewBtnImage = false;
            this.cdvInspItem.Location = new System.Drawing.Point(120, 19);
            this.cdvInspItem.MaxLength = 30;
            this.cdvInspItem.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspItem.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspItem.Name = "cdvInspItem";
            this.cdvInspItem.ReadOnly = false;
            this.cdvInspItem.SearchSubItemIndex = 0;
            this.cdvInspItem.SelectedDescIndex = -1;
            this.cdvInspItem.SelectedSubItemIndex = -1;
            this.cdvInspItem.SelectionStart = 0;
            this.cdvInspItem.Size = new System.Drawing.Size(100, 20);
            this.cdvInspItem.SmallImageList = null;
            this.cdvInspItem.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspItem.TabIndex = 44;
            this.cdvInspItem.TextBoxToolTipText = "";
            this.cdvInspItem.TextBoxWidth = 100;
            this.cdvInspItem.VisibleButton = true;
            this.cdvInspItem.VisibleColumnHeader = false;
            this.cdvInspItem.VisibleDescription = false;
            this.cdvInspItem.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvInspItem_SelectedItemChanged);
            this.cdvInspItem.ButtonPress += new System.EventHandler(this.cdvInspItem_ButtonPress);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Location = new System.Drawing.Point(510, 47);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(58, 13);
            this.Label3.TabIndex = 53;
            this.Label3.Text = "Defect Qty";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDefectQty
            // 
            this.txtDefectQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefectQty.Location = new System.Drawing.Point(614, 44);
            this.txtDefectQty.MaxLength = 11;
            this.txtDefectQty.Name = "txtDefectQty";
            this.txtDefectQty.ReadOnly = true;
            this.txtDefectQty.Size = new System.Drawing.Size(100, 20);
            this.txtDefectQty.TabIndex = 54;
            this.txtDefectQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.Location = new System.Drawing.Point(268, 47);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(47, 13);
            this.Label4.TabIndex = 51;
            this.Label4.Text = "Test Qty";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTestQty
            // 
            this.txtTestQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestQty.Location = new System.Drawing.Point(372, 44);
            this.txtTestQty.MaxLength = 11;
            this.txtTestQty.Name = "txtTestQty";
            this.txtTestQty.ReadOnly = true;
            this.txtTestQty.Size = new System.Drawing.Size(104, 20);
            this.txtTestQty.TabIndex = 52;
            this.txtTestQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label5.Location = new System.Drawing.Point(16, 47);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(58, 13);
            this.Label5.TabIndex = 49;
            this.Label5.Text = "Item Count";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItemCount
            // 
            this.txtItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCount.Location = new System.Drawing.Point(120, 44);
            this.txtItemCount.MaxLength = 30;
            this.txtItemCount.Name = "txtItemCount";
            this.txtItemCount.ReadOnly = true;
            this.txtItemCount.Size = new System.Drawing.Size(100, 20);
            this.txtItemCount.TabIndex = 50;
            this.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.Location = new System.Drawing.Point(510, 22);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(37, 13);
            this.Label2.TabIndex = 47;
            this.Label2.Text = "Result";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(614, 19);
            this.txtResult.MaxLength = 30;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(100, 20);
            this.txtResult.TabIndex = 48;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Location = new System.Drawing.Point(16, 22);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 13);
            this.Label1.TabIndex = 43;
            this.Label1.Text = "Insp. Item";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label8.Location = new System.Drawing.Point(268, 22);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(29, 13);
            this.Label8.TabIndex = 45;
            this.Label8.Text = "Seq.";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSeq
            // 
            this.txtSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeq.Location = new System.Drawing.Point(372, 19);
            this.txtSeq.MaxLength = 6;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.ReadOnly = true;
            this.txtSeq.Size = new System.Drawing.Size(104, 20);
            this.txtSeq.TabIndex = 46;
            this.txtSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.pnlCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Size = new System.Drawing.Size(728, 410);
            this.tbpCMF.TabIndex = 1;
            this.tbpCMF.Text = "Customized Field";
            this.tbpCMF.Visible = false;
            // 
            // pnlCMF
            // 
            this.pnlCMF.Controls.Add(this.grpCMF);
            this.pnlCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCMF.Location = new System.Drawing.Point(0, 0);
            this.pnlCMF.Name = "pnlCMF";
            this.pnlCMF.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCMF.Size = new System.Drawing.Size(728, 410);
            this.pnlCMF.TabIndex = 0;
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF5);
            this.grpCMF.Controls.Add(this.cdvCMF4);
            this.grpCMF.Controls.Add(this.cdvCMF3);
            this.grpCMF.Controls.Add(this.cdvCMF2);
            this.grpCMF.Controls.Add(this.cdvCMF10);
            this.grpCMF.Controls.Add(this.cdvCMF1);
            this.grpCMF.Controls.Add(this.lblCMF10);
            this.grpCMF.Controls.Add(this.lblCMF9);
            this.grpCMF.Controls.Add(this.lblCMF8);
            this.grpCMF.Controls.Add(this.lblCMF7);
            this.grpCMF.Controls.Add(this.lblCMF6);
            this.grpCMF.Controls.Add(this.lblCMF5);
            this.grpCMF.Controls.Add(this.lblCMF4);
            this.grpCMF.Controls.Add(this.lblCMF3);
            this.grpCMF.Controls.Add(this.lblCMF2);
            this.grpCMF.Controls.Add(this.lblCMF1);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.Location = new System.Drawing.Point(3, 3);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(722, 404);
            this.grpCMF.TabIndex = 0;
            this.grpCMF.TabStop = false;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 0;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(170, 208);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 180;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF8.BtnToolTipText = "";
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 0;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(170, 184);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 180;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF7.BtnToolTipText = "";
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 0;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(170, 160);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 180;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF6.BtnToolTipText = "";
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 0;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(170, 136);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 180;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 0;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(170, 112);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 180;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 0;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(170, 88);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 180;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF3.BtnToolTipText = "";
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 0;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(170, 64);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 180;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF2.BtnToolTipText = "";
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 0;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(170, 40);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 180;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 0;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(170, 232);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 180;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF1.BtnToolTipText = "";
            this.cdvCMF1.DescText = "";
            this.cdvCMF1.DisplaySubItemIndex = -1;
            this.cdvCMF1.DisplayText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(170, 16);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 180;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(24, 236);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCMF10.TabIndex = 18;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(24, 212);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCMF9.TabIndex = 16;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(24, 188);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCMF8.TabIndex = 14;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(24, 164);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCMF7.TabIndex = 12;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(24, 140);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCMF6.TabIndex = 10;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(24, 116);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCMF5.TabIndex = 8;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(24, 92);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCMF4.TabIndex = 6;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(24, 68);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCMF3.TabIndex = 4;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(24, 44);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCMF2.TabIndex = 2;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(24, 20);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCMF1.TabIndex = 0;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBatchID
            // 
            this.txtBatchID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBatchID.Location = new System.Drawing.Point(110, 29);
            this.txtBatchID.MaxLength = 30;
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.Size = new System.Drawing.Size(200, 20);
            this.txtBatchID.TabIndex = 1;
            // 
            // frmQCMViewQCBatchStatus
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmQCMViewQCBatchStatus";
            this.Tag = "QCM3001";
            this.Text = "View QC Batch Status";
            this.Activated += new System.EventHandler(this.frmQCMViewQCBatchStatus_Activated);
            this.Load += new System.EventHandler(this.frmQCMViewQCBatchStatus_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlGeneralMiddle.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlInspItem.ResumeLayout(false);
            this.grpInspItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem_Sheet1)).EndInit();
            this.grpDefect.ResumeLayout(false);
            this.pnlDefect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefect_Sheet1)).EndInit();
            this.pnlDefectInspItem.ResumeLayout(false);
            this.pnlDefectInspItem.PerformLayout();
            this.pnlGeneralTop.ResumeLayout(false);
            this.grpBatInfo.ResumeLayout(false);
            this.pnlBatchInfoMain.ResumeLayout(false);
            this.tbpItem.ResumeLayout(false);
            this.pnlSelectedInspItem.ResumeLayout(false);
            this.grpSelectedInspItem.ResumeLayout(false);
            this.grpSelectedInspItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspItem)).EndInit();
            this.tbpCMF.ResumeLayout(false);
            this.pnlCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblBatchID;
        protected System.Windows.Forms.TabControl tabTran;
        protected System.Windows.Forms.TabPage tbpGeneral;
        protected System.Windows.Forms.Panel pnlGeneralMiddle;
        protected System.Windows.Forms.Panel pnlTranInfo;
        private System.Windows.Forms.Panel pnlInspItem;
        private System.Windows.Forms.GroupBox grpInspItem;
        private FarPoint.Win.Spread.FpSpread spdInspItem;
        private FarPoint.Win.Spread.SheetView spdInspItem_Sheet1;
        private System.Windows.Forms.GroupBox grpDefect;
        private System.Windows.Forms.Panel pnlDefect;
        private FarPoint.Win.Spread.FpSpread spdDefect;
        private FarPoint.Win.Spread.SheetView spdDefect_Sheet1;
        private System.Windows.Forms.Panel pnlDefectInspItem;
        private System.Windows.Forms.Button btnHideDefect;
        protected System.Windows.Forms.TextBox txtDefectInspItem;
        private System.Windows.Forms.Panel pnlGeneralTop;
        private System.Windows.Forms.GroupBox grpBatInfo;
        private System.Windows.Forms.Panel pnlBatchInfoMain;
        private udcQCMBatchInfo ctrlBatchInfo;
        private System.Windows.Forms.TabPage tbpItem;
        private Miracom.UI.Controls.MCListView.MCListView lisItem;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader ColumnHeader8;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.ColumnHeader ColumnHeader14;
        private System.Windows.Forms.ColumnHeader ColumnHeader15;
        private System.Windows.Forms.Panel pnlSelectedInspItem;
        private System.Windows.Forms.GroupBox grpSelectedInspItem;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspItem;
        protected System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txtDefectQty;
        protected System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtTestQty;
        protected System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtItemCount;
        protected System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtResult;
        protected System.Windows.Forms.Label Label1;
        protected System.Windows.Forms.Label Label8;
        private System.Windows.Forms.TextBox txtSeq;
        protected System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.Panel pnlCMF;
        protected System.Windows.Forms.GroupBox grpCMF;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        protected System.Windows.Forms.Label lblCMF10;
        protected System.Windows.Forms.Label lblCMF9;
        protected System.Windows.Forms.Label lblCMF8;
        protected System.Windows.Forms.Label lblCMF7;
        protected System.Windows.Forms.Label lblCMF6;
        protected System.Windows.Forms.Label lblCMF5;
        protected System.Windows.Forms.Label lblCMF4;
        protected System.Windows.Forms.Label lblCMF3;
        protected System.Windows.Forms.Label lblCMF2;
        protected System.Windows.Forms.Label lblCMF1;
        protected System.Windows.Forms.TextBox txtBatchID;
    }
}
