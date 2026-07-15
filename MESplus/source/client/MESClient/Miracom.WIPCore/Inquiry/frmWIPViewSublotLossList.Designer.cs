namespace Miracom.WIPCore
{
    partial class frmWIPViewSublotLossList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.txtSublotID = new System.Windows.Forms.TextBox();
            this.lblSublotID = new System.Windows.Forms.Label();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.chkInculdeDelHist = new System.Windows.Forms.CheckBox();
            this.lblLossCode = new System.Windows.Forms.Label();
            this.lblOper = new System.Windows.Forms.Label();
            this.cdvLossCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGrade = new System.Windows.Forms.Label();
            this.cdvGrade = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lblQtyFlag = new System.Windows.Forms.Label();
            this.cboQtyFlag = new System.Windows.Forms.ComboBox();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLossCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 90);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cboQtyFlag);
            this.grpOption.Controls.Add(this.lblQtyFlag);
            this.grpOption.Controls.Add(this.lblGrade);
            this.grpOption.Controls.Add(this.cdvGrade);
            this.grpOption.Controls.Add(this.lblLossCode);
            this.grpOption.Controls.Add(this.lblOper);
            this.grpOption.Controls.Add(this.cdvLossCode);
            this.grpOption.Controls.Add(this.cdvOperation);
            this.grpOption.Controls.Add(this.chkInculdeDelHist);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.txtSublotID);
            this.grpOption.Controls.Add(this.lblSublotID);
            this.grpOption.Size = new System.Drawing.Size(742, 90);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 90);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 423);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // txtSublotID
            // 
            this.txtSublotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSublotID.Location = new System.Drawing.Point(115, 12);
            this.txtSublotID.MaxLength = 30;
            this.txtSublotID.Name = "txtSublotID";
            this.txtSublotID.Size = new System.Drawing.Size(200, 20);
            this.txtSublotID.TabIndex = 1;
            // 
            // lblSublotID
            // 
            this.lblSublotID.AutoSize = true;
            this.lblSublotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSublotID.Location = new System.Drawing.Point(10, 15);
            this.lblSublotID.Name = "lblSublotID";
            this.lblSublotID.Size = new System.Drawing.Size(68, 13);
            this.lblSublotID.TabIndex = 0;
            this.lblSublotID.Text = "Sub Lot ID";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(462, 12);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(274, 20);
            this.pnlPeriod.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(73, 0);
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
            this.dtpTo.Location = new System.Drawing.Point(184, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Location = new System.Drawing.Point(166, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // chkInculdeDelHist
            // 
            this.chkInculdeDelHist.AutoSize = true;
            this.chkInculdeDelHist.Location = new System.Drawing.Point(463, 64);
            this.chkInculdeDelHist.Name = "chkInculdeDelHist";
            this.chkInculdeDelHist.Size = new System.Drawing.Size(136, 17);
            this.chkInculdeDelHist.TabIndex = 9;
            this.chkInculdeDelHist.Text = "Include Deleted History";
            // 
            // lblLossCode
            // 
            this.lblLossCode.AutoSize = true;
            this.lblLossCode.Location = new System.Drawing.Point(10, 64);
            this.lblLossCode.Name = "lblLossCode";
            this.lblLossCode.Size = new System.Drawing.Size(57, 13);
            this.lblLossCode.TabIndex = 4;
            this.lblLossCode.Text = "Loss Code";
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.Location = new System.Drawing.Point(10, 39);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 2;
            this.lblOper.Text = "Operation";
            // 
            // cdvLossCode
            // 
            this.cdvLossCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLossCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLossCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLossCode.BtnToolTipText = "";
            this.cdvLossCode.ButtonWidth = 20;
            this.cdvLossCode.DescText = "";
            this.cdvLossCode.DisplaySubItemIndex = -1;
            this.cdvLossCode.DisplayText = "";
            this.cdvLossCode.Focusing = null;
            this.cdvLossCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLossCode.Index = 0;
            this.cdvLossCode.IsViewBtnImage = false;
            this.cdvLossCode.Location = new System.Drawing.Point(115, 62);
            this.cdvLossCode.MaxLength = 10;
            this.cdvLossCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLossCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLossCode.MultiSelect = false;
            this.cdvLossCode.Name = "cdvLossCode";
            this.cdvLossCode.ReadOnly = false;
            this.cdvLossCode.SameWidthHeightOfButton = false;
            this.cdvLossCode.SearchSubItemIndex = 0;
            this.cdvLossCode.SelectedDescIndex = -1;
            this.cdvLossCode.SelectedDescToQueryText = "";
            this.cdvLossCode.SelectedSubItemIndex = -1;
            this.cdvLossCode.SelectedValueToQueryText = "";
            this.cdvLossCode.SelectionStart = 0;
            this.cdvLossCode.Size = new System.Drawing.Size(200, 20);
            this.cdvLossCode.SmallImageList = null;
            this.cdvLossCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLossCode.TabIndex = 5;
            this.cdvLossCode.TextBoxToolTipText = "";
            this.cdvLossCode.TextBoxWidth = 200;
            this.cdvLossCode.VisibleButton = true;
            this.cdvLossCode.VisibleColumnHeader = false;
            this.cdvLossCode.VisibleDescription = false;
            this.cdvLossCode.ButtonPress += new System.EventHandler(this.cdvLossCode_ButtonPress);
            // 
            // cdvOperation
            // 
            this.cdvOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOperation.BtnToolTipText = "";
            this.cdvOperation.ButtonWidth = 20;
            this.cdvOperation.DescText = "";
            this.cdvOperation.DisplaySubItemIndex = -1;
            this.cdvOperation.DisplayText = "";
            this.cdvOperation.Focusing = null;
            this.cdvOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.Index = 0;
            this.cdvOperation.IsViewBtnImage = false;
            this.cdvOperation.Location = new System.Drawing.Point(115, 37);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MultiSelect = false;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SameWidthHeightOfButton = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedDescToQueryText = "";
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectedValueToQueryText = "";
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(200, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 3;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 200;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOperation_SelectedItemChanged);
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Location = new System.Drawing.Point(460, 41);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(36, 13);
            this.lblGrade.TabIndex = 7;
            this.lblGrade.Text = "Grade";
            // 
            // cdvGrade
            // 
            this.cdvGrade.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGrade.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGrade.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGrade.BtnToolTipText = "";
            this.cdvGrade.ButtonWidth = 20;
            this.cdvGrade.DescText = "";
            this.cdvGrade.DisplaySubItemIndex = -1;
            this.cdvGrade.DisplayText = "";
            this.cdvGrade.Focusing = null;
            this.cdvGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGrade.Index = 0;
            this.cdvGrade.IsViewBtnImage = false;
            this.cdvGrade.Location = new System.Drawing.Point(535, 37);
            this.cdvGrade.MaxLength = 1;
            this.cdvGrade.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGrade.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGrade.MultiSelect = false;
            this.cdvGrade.Name = "cdvGrade";
            this.cdvGrade.ReadOnly = false;
            this.cdvGrade.SameWidthHeightOfButton = false;
            this.cdvGrade.SearchSubItemIndex = 0;
            this.cdvGrade.SelectedDescIndex = -1;
            this.cdvGrade.SelectedDescToQueryText = "";
            this.cdvGrade.SelectedSubItemIndex = -1;
            this.cdvGrade.SelectedValueToQueryText = "";
            this.cdvGrade.SelectionStart = 0;
            this.cdvGrade.Size = new System.Drawing.Size(65, 20);
            this.cdvGrade.SmallImageList = null;
            this.cdvGrade.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGrade.TabIndex = 8;
            this.cdvGrade.TextBoxToolTipText = "";
            this.cdvGrade.TextBoxWidth = 65;
            this.cdvGrade.VisibleButton = true;
            this.cdvGrade.VisibleColumnHeader = false;
            this.cdvGrade.VisibleDescription = false;
            this.cdvGrade.ButtonPress += new System.EventHandler(this.cdvGrade_ButtonPress);
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.SystemColors.Control;
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 4;
            this.spdList.Location = new System.Drawing.Point(0, 0);
            this.spdList.Name = "spdList";
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 423);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
            this.spdList.TabStop = false;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdList.TextTipAppearance = tipAppearance1;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 5;
            this.spdList.SetViewportLeftColumn(0, 0, 1);
            this.spdList.SetActiveViewport(0, 0, -1);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 17;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Grade";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Loss Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Loss Qty";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Qty Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Material";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Mat Ver";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Res ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Cause Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Cause Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Cause Res ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Tran User ID";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Label = "Hist Seq";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(1).Label = "Lot ID";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(2).Label = "Tran Time";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Label = "Grade";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(4).Label = "Loss Code";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdList_Sheet1.Columns.Get(5).Label = "Loss Qty";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Label = "Qty Flag";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(7).Label = "Material";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Label = "Mat Ver";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(9).Label = "Flow";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Label = "Flow Seq";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(11).Label = "Oper";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(12).Label = "Res ID";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(13).Label = "Cause Flow";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(14).Label = "Cause Oper";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(15).Label = "Cause Res ID";
            this.spdList_Sheet1.Columns.Get(15).Locked = true;
            this.spdList_Sheet1.Columns.Get(15).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.Columns.Get(16).Label = "Tran User ID";
            this.spdList_Sheet1.Columns.Get(16).Locked = true;
            this.spdList_Sheet1.Columns.Get(16).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.FrozenColumnCount = 1;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lblQtyFlag
            // 
            this.lblQtyFlag.AutoSize = true;
            this.lblQtyFlag.Location = new System.Drawing.Point(610, 41);
            this.lblQtyFlag.Name = "lblQtyFlag";
            this.lblQtyFlag.Size = new System.Drawing.Size(46, 13);
            this.lblQtyFlag.TabIndex = 10;
            this.lblQtyFlag.Text = "Qty Flag";
            // 
            // cboQtyFlag
            // 
            this.cboQtyFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQtyFlag.FormattingEnabled = true;
            this.cboQtyFlag.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3"});
            this.cboQtyFlag.Location = new System.Drawing.Point(676, 37);
            this.cboQtyFlag.Name = "cboQtyFlag";
            this.cboQtyFlag.Size = new System.Drawing.Size(60, 21);
            this.cboQtyFlag.TabIndex = 14;
            // 
            // frmWIPViewSublotLossList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewSublotLossList";
            this.Text = "View Sublot Loss List";
            this.Activated += new System.EventHandler(this.frmWIPViewSublotLossList_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLossCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSublotID;
        private System.Windows.Forms.Label lblSublotID;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.CheckBox chkInculdeDelHist;
        private System.Windows.Forms.Label lblGrade;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGrade;
        private System.Windows.Forms.Label lblLossCode;
        private System.Windows.Forms.Label lblOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLossCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private System.Windows.Forms.Label lblQtyFlag;
        private System.Windows.Forms.ComboBox cboQtyFlag;
    }
}
