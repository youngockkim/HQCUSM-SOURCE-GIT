namespace Miracom.BASCore
{
    partial class frmCheckListTranMain
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
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.ComplexBorder complexBorder2 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.cdvChecklistType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChecklistType = new System.Windows.Forms.Label();
            this.cdvChecklistID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChecklistID = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grpKeyValue = new System.Windows.Forms.GroupBox();
            this.spdKeyPrompt = new FarPoint.Win.Spread.FpSpread();
            this.spdKeyPrompt_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlAnswer = new System.Windows.Forms.Panel();
            this.grpQueryAnswer = new System.Windows.Forms.GroupBox();
            this.spdQueryAnswer = new FarPoint.Win.Spread.FpSpread();
            this.spdQueryAnswer_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnProcess = new System.Windows.Forms.Button();
            this.chkCompleteFlag = new System.Windows.Forms.CheckBox();
            this.pnlCheckListInfo = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grpCheckListHistory = new System.Windows.Forms.GroupBox();
            this.lisCheckHistory = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompleteFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompleteUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompleteTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKeyPrompt1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKeyPrompt2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKeyPrompt3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKeyPrompt4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKeyPrompt5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKeyPrompt6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKeyPrompt7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKeyPrompt8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKeyPrompt9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKeyPrompt10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chkIncludeDelHistory = new System.Windows.Forms.CheckBox();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.cdvAnswerList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.txtBaseItemId = new System.Windows.Forms.TextBox();
            this.lblBaseItemId = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChecklistType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChecklistID)).BeginInit();
            this.grpKeyValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdKeyPrompt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdKeyPrompt_Sheet1)).BeginInit();
            this.pnlAnswer.SuspendLayout();
            this.grpQueryAnswer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdQueryAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdQueryAnswer_Sheet1)).BeginInit();
            this.pnlCheckListInfo.SuspendLayout();
            this.grpCheckListHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAnswerList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(367, 7);
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 89);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtBaseItemId);
            this.grpOption.Controls.Add(this.lblBaseItemId);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.chkIncludeDelHistory);
            this.grpOption.Controls.Add(this.txtDesc);
            this.grpOption.Controls.Add(this.lblDescription);
            this.grpOption.Controls.Add(this.cdvChecklistID);
            this.grpOption.Controls.Add(this.lblChecklistID);
            this.grpOption.Controls.Add(this.cdvChecklistType);
            this.grpOption.Controls.Add(this.lblChecklistType);
            this.grpOption.Size = new System.Drawing.Size(742, 89);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.pnlAnswer);
            this.pnlViewMid.Controls.Add(this.splitter2);
            this.pnlViewMid.Controls.Add(this.pnlCheckListInfo);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 89);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 424);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnProcess);
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.chkCompleteFlag);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkCompleteFlag, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // cdvChecklistType
            // 
            this.cdvChecklistType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChecklistType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChecklistType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChecklistType.BtnToolTipText = "";
            this.cdvChecklistType.DescText = "";
            this.cdvChecklistType.DisplaySubItemIndex = -1;
            this.cdvChecklistType.DisplayText = "";
            this.cdvChecklistType.Focusing = null;
            this.cdvChecklistType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChecklistType.Index = 0;
            this.cdvChecklistType.IsViewBtnImage = false;
            this.cdvChecklistType.Location = new System.Drawing.Point(133, 12);
            this.cdvChecklistType.MaxLength = 20;
            this.cdvChecklistType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChecklistType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChecklistType.Name = "cdvChecklistType";
            this.cdvChecklistType.ReadOnly = false;
            this.cdvChecklistType.SearchSubItemIndex = 0;
            this.cdvChecklistType.SelectedDescIndex = -1;
            this.cdvChecklistType.SelectedSubItemIndex = -1;
            this.cdvChecklistType.SelectionStart = 0;
            this.cdvChecklistType.Size = new System.Drawing.Size(200, 20);
            this.cdvChecklistType.SmallImageList = null;
            this.cdvChecklistType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChecklistType.TabIndex = 6;
            this.cdvChecklistType.TextBoxToolTipText = "";
            this.cdvChecklistType.TextBoxWidth = 200;
            this.cdvChecklistType.VisibleButton = true;
            this.cdvChecklistType.VisibleColumnHeader = false;
            this.cdvChecklistType.VisibleDescription = false;
            this.cdvChecklistType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChecklistType_SelectedItemChanged);
            this.cdvChecklistType.ButtonPress += new System.EventHandler(this.cdvChecklistType_ButtonPress);
            this.cdvChecklistType.TextBoxTextChanged += new System.EventHandler(this.cdvChecklistType_TextBoxTextChanged);
            // 
            // lblChecklistType
            // 
            this.lblChecklistType.AutoSize = true;
            this.lblChecklistType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChecklistType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblChecklistType.Location = new System.Drawing.Point(22, 16);
            this.lblChecklistType.Name = "lblChecklistType";
            this.lblChecklistType.Size = new System.Drawing.Size(91, 13);
            this.lblChecklistType.TabIndex = 5;
            this.lblChecklistType.Text = "Checklist Type";
            this.lblChecklistType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvChecklistID
            // 
            this.cdvChecklistID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChecklistID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChecklistID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChecklistID.BtnToolTipText = "";
            this.cdvChecklistID.DescText = "";
            this.cdvChecklistID.DisplaySubItemIndex = -1;
            this.cdvChecklistID.DisplayText = "";
            this.cdvChecklistID.Focusing = null;
            this.cdvChecklistID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChecklistID.Index = 0;
            this.cdvChecklistID.IsViewBtnImage = false;
            this.cdvChecklistID.Location = new System.Drawing.Point(133, 38);
            this.cdvChecklistID.MaxLength = 20;
            this.cdvChecklistID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChecklistID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChecklistID.Name = "cdvChecklistID";
            this.cdvChecklistID.ReadOnly = false;
            this.cdvChecklistID.SearchSubItemIndex = 0;
            this.cdvChecklistID.SelectedDescIndex = -1;
            this.cdvChecklistID.SelectedSubItemIndex = -1;
            this.cdvChecklistID.SelectionStart = 0;
            this.cdvChecklistID.Size = new System.Drawing.Size(200, 20);
            this.cdvChecklistID.SmallImageList = null;
            this.cdvChecklistID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChecklistID.TabIndex = 8;
            this.cdvChecklistID.TextBoxToolTipText = "";
            this.cdvChecklistID.TextBoxWidth = 200;
            this.cdvChecklistID.VisibleButton = true;
            this.cdvChecklistID.VisibleColumnHeader = false;
            this.cdvChecklistID.VisibleDescription = false;
            this.cdvChecklistID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChecklistID_SelectedItemChanged);
            this.cdvChecklistID.ButtonPress += new System.EventHandler(this.cdvChecklistID_ButtonPress);
            // 
            // lblChecklistID
            // 
            this.lblChecklistID.AutoSize = true;
            this.lblChecklistID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChecklistID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblChecklistID.Location = new System.Drawing.Point(22, 42);
            this.lblChecklistID.Name = "lblChecklistID";
            this.lblChecklistID.Size = new System.Drawing.Size(76, 13);
            this.lblChecklistID.TabIndex = 7;
            this.lblChecklistID.Text = "Checklist ID";
            this.lblChecklistID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(133, 64);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(300, 20);
            this.txtDesc.TabIndex = 14;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(22, 68);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 13;
            this.lblDescription.Text = "Description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpKeyValue
            // 
            this.grpKeyValue.Controls.Add(this.spdKeyPrompt);
            this.grpKeyValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpKeyValue.Location = new System.Drawing.Point(0, 114);
            this.grpKeyValue.Name = "grpKeyValue";
            this.grpKeyValue.Size = new System.Drawing.Size(742, 147);
            this.grpKeyValue.TabIndex = 0;
            this.grpKeyValue.TabStop = false;
            this.grpKeyValue.Text = "Key Value";
            // 
            // spdKeyPrompt
            // 
            this.spdKeyPrompt.AccessibleDescription = "spdKeyPrompt, Sheet1, Row 0, Column 0, ";
            this.spdKeyPrompt.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.AlwaysPrimaryButton;
            this.spdKeyPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdKeyPrompt.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdKeyPrompt.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdKeyPrompt.HorizontalScrollBar.Name = "";
            this.spdKeyPrompt.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdKeyPrompt.HorizontalScrollBar.TabIndex = 34;
            this.spdKeyPrompt.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdKeyPrompt.Location = new System.Drawing.Point(3, 16);
            this.spdKeyPrompt.Name = "spdKeyPrompt";
            this.spdKeyPrompt.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdKeyPrompt.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdKeyPrompt.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdKeyPrompt_Sheet1});
            this.spdKeyPrompt.Size = new System.Drawing.Size(736, 128);
            this.spdKeyPrompt.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdKeyPrompt.TabIndex = 1;
            this.spdKeyPrompt.TabStop = false;
            this.spdKeyPrompt.TextTipDelay = 200;
            this.spdKeyPrompt.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdKeyPrompt.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdKeyPrompt.VerticalScrollBar.Name = "";
            this.spdKeyPrompt.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdKeyPrompt.VerticalScrollBar.TabIndex = 35;
            this.spdKeyPrompt.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdKeyPrompt.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdKeyPrompt_ButtonClicked);
            // 
            // spdKeyPrompt_Sheet1
            // 
            this.spdKeyPrompt_Sheet1.Reset();
            spdKeyPrompt_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdKeyPrompt_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdKeyPrompt_Sheet1.ColumnCount = 9;
            spdKeyPrompt_Sheet1.RowCount = 5;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 4).RowSpan = 5;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(1, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(2, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(3, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Cells.Get(4, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdKeyPrompt_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdKeyPrompt_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdKeyPrompt_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Prompt";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Table or Item";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 4).BackColor = System.Drawing.Color.White;
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = " ";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Seq";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Prompt";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 2;
            this.spdKeyPrompt_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Table or Item";
            this.spdKeyPrompt_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdKeyPrompt_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdKeyPrompt_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdKeyPrompt_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdKeyPrompt_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdKeyPrompt_Sheet1.Columns.Get(0).Locked = true;
            this.spdKeyPrompt_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(0).Width = 30F;
            this.spdKeyPrompt_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdKeyPrompt_Sheet1.Columns.Get(1).Border = complexBorder1;
            this.spdKeyPrompt_Sheet1.Columns.Get(1).CellType = textCellType4;
            this.spdKeyPrompt_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdKeyPrompt_Sheet1.Columns.Get(1).Label = "Prompt";
            this.spdKeyPrompt_Sheet1.Columns.Get(1).Locked = true;
            this.spdKeyPrompt_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(1).Width = 130F;
            this.spdKeyPrompt_Sheet1.Columns.Get(2).CellType = textCellType5;
            this.spdKeyPrompt_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdKeyPrompt_Sheet1.Columns.Get(2).Label = "Table or Item";
            this.spdKeyPrompt_Sheet1.Columns.Get(2).Locked = true;
            this.spdKeyPrompt_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(2).Width = 120F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdKeyPrompt_Sheet1.Columns.Get(3).CellType = buttonCellType1;
            this.spdKeyPrompt_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(3).Width = 20F;
            this.spdKeyPrompt_Sheet1.Columns.Get(4).Label = " ";
            this.spdKeyPrompt_Sheet1.Columns.Get(4).Locked = true;
            this.spdKeyPrompt_Sheet1.Columns.Get(4).Width = 20F;
            this.spdKeyPrompt_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdKeyPrompt_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(5).Label = "Seq";
            this.spdKeyPrompt_Sheet1.Columns.Get(5).Locked = true;
            this.spdKeyPrompt_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(5).Width = 30F;
            this.spdKeyPrompt_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdKeyPrompt_Sheet1.Columns.Get(6).Border = complexBorder2;
            this.spdKeyPrompt_Sheet1.Columns.Get(6).CellType = textCellType6;
            this.spdKeyPrompt_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdKeyPrompt_Sheet1.Columns.Get(6).Label = "Prompt";
            this.spdKeyPrompt_Sheet1.Columns.Get(6).Locked = true;
            this.spdKeyPrompt_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(6).Width = 130F;
            this.spdKeyPrompt_Sheet1.Columns.Get(7).CellType = textCellType7;
            this.spdKeyPrompt_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdKeyPrompt_Sheet1.Columns.Get(7).Label = "Table or Item";
            this.spdKeyPrompt_Sheet1.Columns.Get(7).Locked = true;
            this.spdKeyPrompt_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(7).Width = 120F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdKeyPrompt_Sheet1.Columns.Get(8).CellType = buttonCellType2;
            this.spdKeyPrompt_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdKeyPrompt_Sheet1.Columns.Get(8).Width = 20F;
            this.spdKeyPrompt_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdKeyPrompt_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdKeyPrompt_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdKeyPrompt_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdKeyPrompt_Sheet1.RowHeader.Visible = false;
            this.spdKeyPrompt_Sheet1.Rows.Get(0).Height = 18F;
            this.spdKeyPrompt_Sheet1.Rows.Get(1).Height = 18F;
            this.spdKeyPrompt_Sheet1.Rows.Get(2).Height = 18F;
            this.spdKeyPrompt_Sheet1.Rows.Get(3).Height = 18F;
            this.spdKeyPrompt_Sheet1.Rows.Get(4).Height = 18F;
            this.spdKeyPrompt_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdKeyPrompt_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdKeyPrompt_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlAnswer
            // 
            this.pnlAnswer.Controls.Add(this.grpQueryAnswer);
            this.pnlAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAnswer.Location = new System.Drawing.Point(0, 264);
            this.pnlAnswer.Name = "pnlAnswer";
            this.pnlAnswer.Size = new System.Drawing.Size(742, 160);
            this.pnlAnswer.TabIndex = 1;
            // 
            // grpQueryAnswer
            // 
            this.grpQueryAnswer.Controls.Add(this.spdQueryAnswer);
            this.grpQueryAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpQueryAnswer.Location = new System.Drawing.Point(0, 0);
            this.grpQueryAnswer.Name = "grpQueryAnswer";
            this.grpQueryAnswer.Size = new System.Drawing.Size(742, 160);
            this.grpQueryAnswer.TabIndex = 0;
            this.grpQueryAnswer.TabStop = false;
            this.grpQueryAnswer.Text = "Answer";
            // 
            // spdQueryAnswer
            // 
            this.spdQueryAnswer.AccessibleDescription = "spdQueryAnswer, Sheet1, Row 0, Column 0, ";
            this.spdQueryAnswer.BackColor = System.Drawing.SystemColors.Control;
            this.spdQueryAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdQueryAnswer.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdQueryAnswer.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdQueryAnswer.HorizontalScrollBar.Name = "";
            this.spdQueryAnswer.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdQueryAnswer.HorizontalScrollBar.TabIndex = 20;
            this.spdQueryAnswer.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdQueryAnswer.Location = new System.Drawing.Point(3, 16);
            this.spdQueryAnswer.Name = "spdQueryAnswer";
            this.spdQueryAnswer.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdQueryAnswer.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdQueryAnswer.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdQueryAnswer_Sheet1});
            this.spdQueryAnswer.Size = new System.Drawing.Size(736, 141);
            this.spdQueryAnswer.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdQueryAnswer.TabIndex = 1;
            this.spdQueryAnswer.TextTipDelay = 200;
            this.spdQueryAnswer.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdQueryAnswer.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdQueryAnswer.VerticalScrollBar.Name = "";
            this.spdQueryAnswer.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdQueryAnswer.VerticalScrollBar.TabIndex = 21;
            this.spdQueryAnswer.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdQueryAnswer.EditModeOff += new System.EventHandler(this.spdQueryAnswer_EditModeOff);
            this.spdQueryAnswer.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdQueryAnswer_ButtonClicked);
            // 
            // spdQueryAnswer_Sheet1
            // 
            this.spdQueryAnswer_Sheet1.Reset();
            spdQueryAnswer_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdQueryAnswer_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdQueryAnswer_Sheet1.ColumnCount = 6;
            spdQueryAnswer_Sheet1.RowCount = 1;
            this.spdQueryAnswer_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQueryAnswer_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdQueryAnswer_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQueryAnswer_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = " ";
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Seq";
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 2).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "ID";
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 3).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Query";
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 2;
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 4).Locked = false;
            this.spdQueryAnswer_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Answer";
            this.spdQueryAnswer_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQueryAnswer_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdQueryAnswer_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdQueryAnswer_Sheet1.Columns.Get(0).Label = " ";
            this.spdQueryAnswer_Sheet1.Columns.Get(0).Locked = true;
            this.spdQueryAnswer_Sheet1.Columns.Get(0).Width = 20F;
            this.spdQueryAnswer_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdQueryAnswer_Sheet1.Columns.Get(1).Label = "Seq";
            this.spdQueryAnswer_Sheet1.Columns.Get(1).Locked = true;
            this.spdQueryAnswer_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType1.MaxLength = 100;
            textCellType1.WordWrap = true;
            this.spdQueryAnswer_Sheet1.Columns.Get(2).CellType = textCellType1;
            this.spdQueryAnswer_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdQueryAnswer_Sheet1.Columns.Get(2).Label = "ID";
            this.spdQueryAnswer_Sheet1.Columns.Get(2).Locked = true;
            this.spdQueryAnswer_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdQueryAnswer_Sheet1.Columns.Get(2).Width = 68F;
            this.spdQueryAnswer_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            textCellType2.MaxLength = 110;
            textCellType2.WordWrap = true;
            this.spdQueryAnswer_Sheet1.Columns.Get(3).CellType = textCellType2;
            this.spdQueryAnswer_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdQueryAnswer_Sheet1.Columns.Get(3).Label = "Query";
            this.spdQueryAnswer_Sheet1.Columns.Get(3).Locked = true;
            this.spdQueryAnswer_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdQueryAnswer_Sheet1.Columns.Get(3).Width = 405F;
            textCellType3.MaxLength = 200;
            this.spdQueryAnswer_Sheet1.Columns.Get(4).CellType = textCellType3;
            this.spdQueryAnswer_Sheet1.Columns.Get(4).Label = "Answer";
            this.spdQueryAnswer_Sheet1.Columns.Get(4).Locked = false;
            this.spdQueryAnswer_Sheet1.Columns.Get(4).Width = 150F;
            this.spdQueryAnswer_Sheet1.Columns.Get(5).Resizable = false;
            this.spdQueryAnswer_Sheet1.Columns.Get(5).Width = 20F;
            this.spdQueryAnswer_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdQueryAnswer_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdQueryAnswer_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQueryAnswer_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdQueryAnswer_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQueryAnswer_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdQueryAnswer_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnProcess.Location = new System.Drawing.Point(461, 7);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(88, 26);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // chkCompleteFlag
            // 
            this.chkCompleteFlag.AutoSize = true;
            this.chkCompleteFlag.Location = new System.Drawing.Point(70, 12);
            this.chkCompleteFlag.Name = "chkCompleteFlag";
            this.chkCompleteFlag.Size = new System.Drawing.Size(93, 17);
            this.chkCompleteFlag.TabIndex = 4;
            this.chkCompleteFlag.Text = "Complete Flag";
            this.chkCompleteFlag.UseVisualStyleBackColor = true;
            // 
            // pnlCheckListInfo
            // 
            this.pnlCheckListInfo.Controls.Add(this.grpKeyValue);
            this.pnlCheckListInfo.Controls.Add(this.splitter1);
            this.pnlCheckListInfo.Controls.Add(this.grpCheckListHistory);
            this.pnlCheckListInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCheckListInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlCheckListInfo.Name = "pnlCheckListInfo";
            this.pnlCheckListInfo.Size = new System.Drawing.Size(742, 261);
            this.pnlCheckListInfo.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 111);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(742, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // grpCheckListHistory
            // 
            this.grpCheckListHistory.Controls.Add(this.lisCheckHistory);
            this.grpCheckListHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCheckListHistory.Location = new System.Drawing.Point(0, 0);
            this.grpCheckListHistory.Name = "grpCheckListHistory";
            this.grpCheckListHistory.Size = new System.Drawing.Size(742, 111);
            this.grpCheckListHistory.TabIndex = 0;
            this.grpCheckListHistory.TabStop = false;
            this.grpCheckListHistory.Text = "History of CheckList";
            // 
            // lisCheckHistory
            // 
            this.lisCheckHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colTranTime,
            this.colTranUser,
            this.colCompleteFlag,
            this.colCompleteUser,
            this.colCompleteTime,
            this.colKeyPrompt1,
            this.colKeyPrompt2,
            this.colKeyPrompt3,
            this.colKeyPrompt4,
            this.colKeyPrompt5,
            this.colKeyPrompt6,
            this.colKeyPrompt7,
            this.colKeyPrompt8,
            this.colKeyPrompt9,
            this.colKeyPrompt10});
            this.lisCheckHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCheckHistory.EnableSort = true;
            this.lisCheckHistory.EnableSortIcon = true;
            this.lisCheckHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCheckHistory.FullRowSelect = true;
            this.lisCheckHistory.HideSelection = false;
            this.lisCheckHistory.Location = new System.Drawing.Point(3, 16);
            this.lisCheckHistory.MultiSelect = false;
            this.lisCheckHistory.Name = "lisCheckHistory";
            this.lisCheckHistory.Size = new System.Drawing.Size(736, 92);
            this.lisCheckHistory.TabIndex = 1;
            this.lisCheckHistory.UseCompatibleStateImageBehavior = false;
            this.lisCheckHistory.View = System.Windows.Forms.View.Details;
            this.lisCheckHistory.SelectedIndexChanged += new System.EventHandler(this.lisCheckHistory_SelectedIndexChanged);
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 40;
            // 
            // colTranTime
            // 
            this.colTranTime.Text = "TranTime";
            this.colTranTime.Width = 140;
            // 
            // colTranUser
            // 
            this.colTranUser.Text = "TranUser";
            this.colTranUser.Width = 100;
            // 
            // colCompleteFlag
            // 
            this.colCompleteFlag.Text = "Complete Flag";
            // 
            // colCompleteUser
            // 
            this.colCompleteUser.Text = "Complete User";
            this.colCompleteUser.Width = 100;
            // 
            // colCompleteTime
            // 
            this.colCompleteTime.Text = "Complete Time";
            this.colCompleteTime.Width = 140;
            // 
            // colKeyPrompt1
            // 
            this.colKeyPrompt1.Text = "Key 1";
            this.colKeyPrompt1.Width = 80;
            // 
            // colKeyPrompt2
            // 
            this.colKeyPrompt2.Text = "Key 2";
            // 
            // colKeyPrompt3
            // 
            this.colKeyPrompt3.Text = "Key 3";
            // 
            // colKeyPrompt4
            // 
            this.colKeyPrompt4.Text = "Key 4";
            // 
            // colKeyPrompt5
            // 
            this.colKeyPrompt5.Text = "Key 5";
            // 
            // colKeyPrompt6
            // 
            this.colKeyPrompt6.Text = "Key 6";
            // 
            // colKeyPrompt7
            // 
            this.colKeyPrompt7.Text = "Key 7";
            // 
            // colKeyPrompt8
            // 
            this.colKeyPrompt8.Text = "Key 8";
            // 
            // colKeyPrompt9
            // 
            this.colKeyPrompt9.Text = "Key 9";
            // 
            // colKeyPrompt10
            // 
            this.colKeyPrompt10.Text = "Key 10";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 261);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(742, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvTableList.Location = new System.Drawing.Point(180, 17);
            this.cdvTableList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Name = "cdvTableList";
            this.cdvTableList.Size = new System.Drawing.Size(20, 20);
            this.cdvTableList.SmallImageList = null;
            this.cdvTableList.TabIndex = 0;
            this.cdvTableList.TabStop = false;
            this.cdvTableList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableList.Visible = false;
            this.cdvTableList.VisibleColumnHeader = false;
            this.cdvTableList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableList_SelectedItemChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(555, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 26);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkIncludeDelHistory
            // 
            this.chkIncludeDelHistory.AutoSize = true;
            this.chkIncludeDelHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDelHistory.Location = new System.Drawing.Point(594, 65);
            this.chkIncludeDelHistory.Name = "chkIncludeDelHistory";
            this.chkIncludeDelHistory.Size = new System.Drawing.Size(136, 18);
            this.chkIncludeDelHistory.TabIndex = 16;
            this.chkIncludeDelHistory.Text = "Include Delete History";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(473, 12);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 17;
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
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // cdvAnswerList
            // 
            this.cdvAnswerList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvAnswerList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAnswerList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAnswerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvAnswerList.Location = new System.Drawing.Point(180, 17);
            this.cdvAnswerList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAnswerList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAnswerList.Name = "cdvTableList";
            this.cdvAnswerList.Size = new System.Drawing.Size(20, 20);
            this.cdvAnswerList.SmallImageList = null;
            this.cdvAnswerList.TabIndex = 0;
            this.cdvAnswerList.TabStop = false;
            this.cdvAnswerList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvAnswerList.Visible = false;
            this.cdvAnswerList.VisibleColumnHeader = false;
            this.cdvAnswerList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvAnswerList_SelectedItemChanged);
            // 
            // txtBaseItemId
            // 
            this.txtBaseItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBaseItemId.Location = new System.Drawing.Point(530, 38);
            this.txtBaseItemId.MaxLength = 200;
            this.txtBaseItemId.Name = "txtBaseItemId";
            this.txtBaseItemId.Size = new System.Drawing.Size(200, 20);
            this.txtBaseItemId.TabIndex = 25;
            this.txtBaseItemId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaseItemId_KeyPress);
            // 
            // lblBaseItemId
            // 
            this.lblBaseItemId.AutoSize = true;
            this.lblBaseItemId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBaseItemId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseItemId.Location = new System.Drawing.Point(473, 42);
            this.lblBaseItemId.Name = "lblBaseItemId";
            this.lblBaseItemId.Size = new System.Drawing.Size(34, 13);
            this.lblBaseItemId.TabIndex = 24;
            this.lblBaseItemId.Text = "Lot Id";
            this.lblBaseItemId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCheckListTranMain
            // 
            this.AcceptButton = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmCheckListTranMain";
            this.Text = "Checklist";
            this.Activated += new System.EventHandler(this.frmCheckListTranMain_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChecklistType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChecklistID)).EndInit();
            this.grpKeyValue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdKeyPrompt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdKeyPrompt_Sheet1)).EndInit();
            this.pnlAnswer.ResumeLayout(false);
            this.grpQueryAnswer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdQueryAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdQueryAnswer_Sheet1)).EndInit();
            this.pnlCheckListInfo.ResumeLayout(false);
            this.grpCheckListHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAnswerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlAnswer;
        protected System.Windows.Forms.GroupBox grpQueryAnswer;
        protected System.Windows.Forms.CheckBox chkCompleteFlag;
        protected System.Windows.Forms.Button btnProcess;
        protected FarPoint.Win.Spread.FpSpread spdQueryAnswer;
        protected FarPoint.Win.Spread.SheetView spdQueryAnswer_Sheet1;
        protected System.Windows.Forms.Panel pnlCheckListInfo;
        protected System.Windows.Forms.GroupBox grpCheckListHistory;
        protected UI.Controls.MCCodeView.MCCodeView cdvChecklistID;
        protected System.Windows.Forms.Label lblChecklistID;
        protected UI.Controls.MCCodeView.MCCodeView cdvChecklistType;
        protected System.Windows.Forms.Label lblChecklistType;
        protected System.Windows.Forms.TextBox txtDesc;
        protected System.Windows.Forms.Label lblDescription;
        protected UI.Controls.MCListView.MCListView lisCheckHistory;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colTranTime;
        private System.Windows.Forms.ColumnHeader colTranUser;
        private System.Windows.Forms.ColumnHeader colCompleteFlag;
        private System.Windows.Forms.ColumnHeader colCompleteUser;
        private System.Windows.Forms.ColumnHeader colCompleteTime;
        private System.Windows.Forms.ColumnHeader colKeyPrompt1;
        protected System.Windows.Forms.Splitter splitter1;
        protected System.Windows.Forms.Splitter splitter2;
        protected System.Windows.Forms.GroupBox grpKeyValue;
        private FarPoint.Win.Spread.SheetView spdKeyPrompt_Sheet1;
        protected FarPoint.Win.Spread.FpSpread spdKeyPrompt;
        private UI.Controls.MCCodeView.MCSPCodeView cdvTableList;
        protected System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader colKeyPrompt2;
        private System.Windows.Forms.ColumnHeader colKeyPrompt3;
        private System.Windows.Forms.ColumnHeader colKeyPrompt4;
        private System.Windows.Forms.ColumnHeader colKeyPrompt5;
        private System.Windows.Forms.ColumnHeader colKeyPrompt6;
        private System.Windows.Forms.ColumnHeader colKeyPrompt7;
        private System.Windows.Forms.ColumnHeader colKeyPrompt8;
        private System.Windows.Forms.ColumnHeader colKeyPrompt9;
        private System.Windows.Forms.ColumnHeader colKeyPrompt10;
        protected System.Windows.Forms.CheckBox chkIncludeDelHistory;
        protected System.Windows.Forms.Panel pnlPeriod;
        protected System.Windows.Forms.DateTimePicker dtpFrom;
        protected System.Windows.Forms.Label lblPeriod;
        protected System.Windows.Forms.DateTimePicker dtpTo;
        protected System.Windows.Forms.Label lblTo;
        private UI.Controls.MCCodeView.MCSPCodeView cdvAnswerList;
        protected System.Windows.Forms.TextBox txtBaseItemId;
        protected System.Windows.Forms.Label lblBaseItemId;
    }
}