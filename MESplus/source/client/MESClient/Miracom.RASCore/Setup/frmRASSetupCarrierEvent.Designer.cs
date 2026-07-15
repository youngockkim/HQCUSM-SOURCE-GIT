namespace Miracom.RASCore
{
    partial class frmRASSetupCarrierEvent
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
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType4 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType5 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            this.lisCrrEvent = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlEventTop = new System.Windows.Forms.Panel();
            this.grpResource = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.chkSystemFlag = new System.Windows.Forms.CheckBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtCrrEventID = new System.Windows.Forms.TextBox();
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.spdCheckItem = new FarPoint.Win.Spread.FpSpread();
            this.spdCheckItem_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splCheckChange = new System.Windows.Forms.Splitter();
            this.spdChangeItem = new FarPoint.Win.Spread.FpSpread();
            this.spdChangeItem_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlEventTop.SuspendLayout();
            this.grpResource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCheckItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCheckItem_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChangeItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChangeItem_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.spdChangeItem);
            this.pnlRight.Controls.Add(this.splCheckChange);
            this.pnlRight.Controls.Add(this.spdCheckItem);
            this.pnlRight.Controls.Add(this.pnlEventTop);
            this.pnlRight.TabIndex = 2;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisCrrEvent);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 3;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
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
            // 
            // lisCrrEvent
            // 
            this.lisCrrEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisCrrEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCrrEvent.EnableSort = true;
            this.lisCrrEvent.EnableSortIcon = true;
            this.lisCrrEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCrrEvent.FullRowSelect = true;
            this.lisCrrEvent.Location = new System.Drawing.Point(3, 3);
            this.lisCrrEvent.MultiSelect = false;
            this.lisCrrEvent.Name = "lisCrrEvent";
            this.lisCrrEvent.Size = new System.Drawing.Size(229, 503);
            this.lisCrrEvent.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lisCrrEvent.TabIndex = 0;
            this.lisCrrEvent.UseCompatibleStateImageBehavior = false;
            this.lisCrrEvent.View = System.Windows.Forms.View.Details;
            this.lisCrrEvent.SelectedIndexChanged += new System.EventHandler(this.lisCrrEvent_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Carrier Event";
            this.ColumnHeader1.Width = 80;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 150;
            // 
            // pnlEventTop
            // 
            this.pnlEventTop.Controls.Add(this.grpResource);
            this.pnlEventTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEventTop.Location = new System.Drawing.Point(0, 0);
            this.pnlEventTop.Name = "pnlEventTop";
            this.pnlEventTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlEventTop.Size = new System.Drawing.Size(506, 74);
            this.pnlEventTop.TabIndex = 0;
            // 
            // grpResource
            // 
            this.grpResource.Controls.Add(this.lblDesc);
            this.grpResource.Controls.Add(this.chkSystemFlag);
            this.grpResource.Controls.Add(this.lblEvent);
            this.grpResource.Controls.Add(this.txtDesc);
            this.grpResource.Controls.Add(this.txtCrrEventID);
            this.grpResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResource.Location = new System.Drawing.Point(3, 0);
            this.grpResource.Name = "grpResource";
            this.grpResource.Size = new System.Drawing.Size(500, 71);
            this.grpResource.TabIndex = 3;
            this.grpResource.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(16, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "Description";
            // 
            // chkSystemFlag
            // 
            this.chkSystemFlag.AutoSize = true;
            this.chkSystemFlag.Enabled = false;
            this.chkSystemFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSystemFlag.Location = new System.Drawing.Point(374, 16);
            this.chkSystemFlag.Name = "chkSystemFlag";
            this.chkSystemFlag.Size = new System.Drawing.Size(101, 17);
            this.chkSystemFlag.TabIndex = 2;
            this.chkSystemFlag.Text = "System Flag";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(15, 19);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(81, 13);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Carrier Event";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(142, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(348, 20);
            this.txtDesc.TabIndex = 4;
            // 
            // txtCrrEventID
            // 
            this.txtCrrEventID.Location = new System.Drawing.Point(142, 16);
            this.txtCrrEventID.MaxLength = 12;
            this.txtCrrEventID.Name = "txtCrrEventID";
            this.txtCrrEventID.Size = new System.Drawing.Size(200, 20);
            this.txtCrrEventID.TabIndex = 1;
            this.txtCrrEventID.TextChanged += new System.EventHandler(this.txtCrrEventID_TextChanged);
            // 
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvTableList.Location = new System.Drawing.Point(372, 17);
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
            // spdCheckItem
            // 
            this.spdCheckItem.AccessibleDescription = "spdCheckItem, Sheet1, Row 0, Column 0, ";
            this.spdCheckItem.BackColor = System.Drawing.SystemColors.Control;
            this.spdCheckItem.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdCheckItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.spdCheckItem.EditModePermanent = true;
            this.spdCheckItem.EditModeReplace = true;
            this.spdCheckItem.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCheckItem.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCheckItem.HorizontalScrollBar.Name = "";
            this.spdCheckItem.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdCheckItem.HorizontalScrollBar.TabIndex = 4;
            this.spdCheckItem.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCheckItem.Location = new System.Drawing.Point(0, 74);
            this.spdCheckItem.Name = "spdCheckItem";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer1;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer1;
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
            this.spdCheckItem.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdCheckItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdCheckItem.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCheckItem.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCheckItem.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCheckItem_Sheet1});
            this.spdCheckItem.Size = new System.Drawing.Size(506, 215);
            this.spdCheckItem.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCheckItem.TabIndex = 5;
            this.spdCheckItem.TabStop = false;
            this.spdCheckItem.TextTipDelay = 200;
            this.spdCheckItem.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCheckItem.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCheckItem.VerticalScrollBar.Name = "";
            this.spdCheckItem.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdCheckItem.VerticalScrollBar.TabIndex = 5;
            this.spdCheckItem.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdCheckItem_CellClick);
            this.spdCheckItem.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCheckItem_ButtonClicked);
            this.spdCheckItem.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCheckItem_ComboCloseUp);
            this.spdCheckItem.ComboDropDown += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCheckItem_ComboDropDown);
            this.spdCheckItem.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCheckItem_EditChange);
            // 
            // spdCheckItem_Sheet1
            // 
            this.spdCheckItem_Sheet1.Reset();
            spdCheckItem_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCheckItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCheckItem_Sheet1.ColumnCount = 5;
            spdCheckItem_Sheet1.RowCount = 30;
            this.spdCheckItem_Sheet1.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(1, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(2, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(3, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(4, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(5, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(6, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(7, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(8, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(9, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(10, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(11, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(12, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(13, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(14, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(15, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(16, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(17, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(18, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(19, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(20, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(20, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(21, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(21, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(22, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(22, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(23, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(23, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(24, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(24, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(25, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(25, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(26, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(26, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(27, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(27, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(28, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(28, 3).Locked = true;
            this.spdCheckItem_Sheet1.Cells.Get(29, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.Cells.Get(29, 3).Locked = true;
            this.spdCheckItem_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCheckItem_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCheckItem_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCheckItem_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Check Item";
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Check Flag";
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Check Value";
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Check Field";
            this.spdCheckItem_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCheckItem_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCheckItem_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            comboBoxCellType4.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdCheckItem_Sheet1.Columns.Get(0).CellType = comboBoxCellType4;
            this.spdCheckItem_Sheet1.Columns.Get(0).Label = "Check Item";
            this.spdCheckItem_Sheet1.Columns.Get(0).Width = 130F;
            comboBoxCellType5.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType5.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.Index;
            comboBoxCellType5.Items = new string[] {
        "",
        "= (Equal)",
        "! (Not Equal)",
        "N (Not Check)",
        "> (Greater than)",
        "< (Less than)",
        ">= (Greater than or equal)",
        "<= (Less than or equal)"};
            this.spdCheckItem_Sheet1.Columns.Get(1).CellType = comboBoxCellType5;
            this.spdCheckItem_Sheet1.Columns.Get(1).Label = "Check Flag";
            this.spdCheckItem_Sheet1.Columns.Get(1).Locked = false;
            this.spdCheckItem_Sheet1.Columns.Get(1).Width = 85F;
            this.spdCheckItem_Sheet1.Columns.Get(2).CellType = textCellType3;
            this.spdCheckItem_Sheet1.Columns.Get(2).Label = "Check Value";
            this.spdCheckItem_Sheet1.Columns.Get(2).Locked = false;
            this.spdCheckItem_Sheet1.Columns.Get(2).Width = 88F;
            this.spdCheckItem_Sheet1.Columns.Get(3).CellType = textCellType4;
            this.spdCheckItem_Sheet1.Columns.Get(3).Locked = false;
            this.spdCheckItem_Sheet1.Columns.Get(3).Width = 22F;
            this.spdCheckItem_Sheet1.Columns.Get(4).Label = "Check Field";
            this.spdCheckItem_Sheet1.Columns.Get(4).Locked = false;
            this.spdCheckItem_Sheet1.Columns.Get(4).Width = 130F;
            this.spdCheckItem_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(20, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(20, 0).Value = "21";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(21, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(21, 0).Value = "22";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(22, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(22, 0).Value = "23";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(23, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(23, 0).Value = "24";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(24, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(24, 0).Value = "25";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(25, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(25, 0).Value = "26";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(26, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(26, 0).Value = "27";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(27, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(27, 0).Value = "28";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(28, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(28, 0).Value = "29";
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(29, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCheckItem_Sheet1.RowHeader.Cells.Get(29, 0).Value = "30";
            this.spdCheckItem_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCheckItem_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.spdCheckItem_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCheckItem_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCheckItem_Sheet1.Rows.Get(0).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(1).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(2).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(3).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(4).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(5).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(6).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(7).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(8).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(9).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(10).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(11).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(12).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(13).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(14).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(15).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(16).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(17).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(18).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(19).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(20).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(21).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(22).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(23).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(24).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(25).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(26).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(27).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(28).Height = 18F;
            this.spdCheckItem_Sheet1.Rows.Get(29).Height = 18F;
            this.spdCheckItem_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCheckItem_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCheckItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splCheckChange
            // 
            this.splCheckChange.Dock = System.Windows.Forms.DockStyle.Top;
            this.splCheckChange.Location = new System.Drawing.Point(0, 289);
            this.splCheckChange.Name = "splCheckChange";
            this.splCheckChange.Size = new System.Drawing.Size(506, 3);
            this.splCheckChange.TabIndex = 6;
            this.splCheckChange.TabStop = false;
            // 
            // spdChangeItem
            // 
            this.spdChangeItem.AccessibleDescription = "spdChangeItem, Sheet1, Row 0, Column 0, ";
            this.spdChangeItem.BackColor = System.Drawing.SystemColors.Control;
            this.spdChangeItem.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdChangeItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdChangeItem.EditModePermanent = true;
            this.spdChangeItem.EditModeReplace = true;
            this.spdChangeItem.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdChangeItem.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdChangeItem.HorizontalScrollBar.Name = "";
            this.spdChangeItem.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdChangeItem.HorizontalScrollBar.TabIndex = 2;
            this.spdChangeItem.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdChangeItem.Location = new System.Drawing.Point(0, 292);
            this.spdChangeItem.Name = "spdChangeItem";
            this.spdChangeItem.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdChangeItem.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdChangeItem.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdChangeItem_Sheet1});
            this.spdChangeItem.Size = new System.Drawing.Size(506, 214);
            this.spdChangeItem.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdChangeItem.TabIndex = 7;
            this.spdChangeItem.TabStop = false;
            this.spdChangeItem.TextTipDelay = 200;
            this.spdChangeItem.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdChangeItem.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdChangeItem.VerticalScrollBar.Name = "";
            this.spdChangeItem.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdChangeItem.VerticalScrollBar.TabIndex = 3;
            this.spdChangeItem.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdChangeItem_CellClick);
            this.spdChangeItem.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdChangeItem_ButtonClicked);
            this.spdChangeItem.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdChangeItem_ComboCloseUp);
            this.spdChangeItem.ComboDropDown += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdChangeItem_ComboDropDown);
            this.spdChangeItem.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdChangeItem_EditChange);
            // 
            // spdChangeItem_Sheet1
            // 
            this.spdChangeItem_Sheet1.Reset();
            spdChangeItem_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdChangeItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdChangeItem_Sheet1.ColumnCount = 5;
            spdChangeItem_Sheet1.RowCount = 30;
            this.spdChangeItem_Sheet1.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(1, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(2, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(3, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(4, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(5, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(6, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(7, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(8, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(9, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(10, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(11, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(12, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(13, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(14, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(15, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(16, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(17, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(18, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(19, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(20, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(20, 3).Locked = true;
            this.spdChangeItem_Sheet1.Cells.Get(21, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(21, 3).Locked = true;
            this.spdChangeItem_Sheet1.Cells.Get(22, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(22, 3).Locked = true;
            this.spdChangeItem_Sheet1.Cells.Get(23, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(23, 3).Locked = true;
            this.spdChangeItem_Sheet1.Cells.Get(24, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(24, 3).Locked = true;
            this.spdChangeItem_Sheet1.Cells.Get(25, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(25, 3).Locked = true;
            this.spdChangeItem_Sheet1.Cells.Get(26, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(26, 3).Locked = true;
            this.spdChangeItem_Sheet1.Cells.Get(27, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(27, 3).Locked = true;
            this.spdChangeItem_Sheet1.Cells.Get(28, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(28, 3).Locked = true;
            this.spdChangeItem_Sheet1.Cells.Get(29, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.Cells.Get(29, 3).Locked = true;
            this.spdChangeItem_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChangeItem_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdChangeItem_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChangeItem_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Change Item";
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Change Flag";
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Change Value";
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Require";
            this.spdChangeItem_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChangeItem_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdChangeItem_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdChangeItem_Sheet1.Columns.Get(0).CellType = comboBoxCellType1;
            this.spdChangeItem_Sheet1.Columns.Get(0).Label = "Change Item";
            this.spdChangeItem_Sheet1.Columns.Get(0).Width = 130F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.Index;
            comboBoxCellType2.Items = new string[] {
        "",
        "Y (Change)",
        "N (Not Change)",
        "+ (Increase)",
        "- (Decrease)",
        "T (Time)"};
            this.spdChangeItem_Sheet1.Columns.Get(1).CellType = comboBoxCellType2;
            this.spdChangeItem_Sheet1.Columns.Get(1).Label = "Change Flag";
            this.spdChangeItem_Sheet1.Columns.Get(1).Locked = true;
            this.spdChangeItem_Sheet1.Columns.Get(1).Width = 85F;
            this.spdChangeItem_Sheet1.Columns.Get(2).CellType = textCellType1;
            this.spdChangeItem_Sheet1.Columns.Get(2).Label = "Change Value";
            this.spdChangeItem_Sheet1.Columns.Get(2).Locked = true;
            this.spdChangeItem_Sheet1.Columns.Get(2).Width = 88F;
            this.spdChangeItem_Sheet1.Columns.Get(3).CellType = textCellType2;
            this.spdChangeItem_Sheet1.Columns.Get(3).Locked = true;
            this.spdChangeItem_Sheet1.Columns.Get(3).Width = 22F;
            comboBoxCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType3.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.Index;
            comboBoxCellType3.Items = new string[] {
        "",
        "Y"};
            this.spdChangeItem_Sheet1.Columns.Get(4).CellType = comboBoxCellType3;
            this.spdChangeItem_Sheet1.Columns.Get(4).Label = "Require";
            this.spdChangeItem_Sheet1.Columns.Get(4).Locked = true;
            this.spdChangeItem_Sheet1.Columns.Get(4).Width = 130F;
            this.spdChangeItem_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(20, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(20, 0).Value = "21";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(21, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(21, 0).Value = "22";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(22, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(22, 0).Value = "23";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(23, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(23, 0).Value = "24";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(24, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(24, 0).Value = "25";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(25, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(25, 0).Value = "26";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(26, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(26, 0).Value = "27";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(27, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(27, 0).Value = "28";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(28, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(28, 0).Value = "29";
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(29, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChangeItem_Sheet1.RowHeader.Cells.Get(29, 0).Value = "30";
            this.spdChangeItem_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdChangeItem_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.spdChangeItem_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChangeItem_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdChangeItem_Sheet1.Rows.Get(0).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(1).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(2).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(3).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(4).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(5).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(6).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(7).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(8).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(9).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(10).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(11).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(12).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(13).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(14).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(15).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(16).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(17).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(18).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(19).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(20).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(21).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(22).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(23).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(24).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(25).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(26).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(27).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(28).Height = 18F;
            this.spdChangeItem_Sheet1.Rows.Get(29).Height = 18F;
            this.spdChangeItem_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChangeItem_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdChangeItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmRASSetupCarrierEvent
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASSetupCarrierEvent";
            this.Text = "Carrier Event Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupCarrierEvent_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupCarrierEvent_Load);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlEventTop.ResumeLayout(false);
            this.grpResource.ResumeLayout(false);
            this.grpResource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCheckItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCheckItem_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChangeItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChangeItem_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Miracom.UI.Controls.MCListView.MCListView lisCrrEvent;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Panel pnlEventTop;
        private System.Windows.Forms.GroupBox grpResource;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.CheckBox chkSystemFlag;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtCrrEventID;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTableList;
        private FarPoint.Win.Spread.FpSpread spdChangeItem;
        private FarPoint.Win.Spread.SheetView spdChangeItem_Sheet1;
        private System.Windows.Forms.Splitter splCheckChange;
        private FarPoint.Win.Spread.FpSpread spdCheckItem;
        private FarPoint.Win.Spread.SheetView spdCheckItem_Sheet1;
    }
}
