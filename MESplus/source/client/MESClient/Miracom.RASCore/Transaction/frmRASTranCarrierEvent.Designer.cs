namespace Miracom.RASCore
{
    partial class frmRASTranCarrierEvent
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
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvCrrGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrGroup = new System.Windows.Forms.Label();
            this.cdvCrrType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrType = new System.Windows.Forms.Label();
            this.cdvCrrID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.pnlEvent = new System.Windows.Forms.Panel();
            this.grpEvent = new System.Windows.Forms.GroupBox();
            this.cdvCrrEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEvent = new System.Windows.Forms.Label();
            this.txtLastEventTime = new System.Windows.Forms.TextBox();
            this.lblLastEventTime = new System.Windows.Forms.Label();
            this.txtLastEvent = new System.Windows.Forms.TextBox();
            this.lblLastEvent = new System.Windows.Forms.Label();
            this.pnlEventInfo = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.cdvTableData = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).BeginInit();
            this.pnlEvent.SuspendLayout();
            this.grpEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrEventID)).BeginInit();
            this.pnlEventInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.grpComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlEventInfo);
            this.pnlCenter.Controls.Add(this.grpComment);
            this.pnlCenter.Controls.Add(this.pnlEvent);
            this.pnlCenter.Controls.Add(this.grpOption);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvCrrGroup);
            this.grpOption.Controls.Add(this.lblCrrGroup);
            this.grpOption.Controls.Add(this.cdvCrrType);
            this.grpOption.Controls.Add(this.lblCrrType);
            this.grpOption.Controls.Add(this.cdvCrrID);
            this.grpOption.Controls.Add(this.lblCrrID);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 72);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // cdvCrrGroup
            // 
            this.cdvCrrGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrGroup.BtnToolTipText = "";
            this.cdvCrrGroup.DescText = "";
            this.cdvCrrGroup.DisplaySubItemIndex = -1;
            this.cdvCrrGroup.DisplayText = "";
            this.cdvCrrGroup.Focusing = null;
            this.cdvCrrGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrGroup.Index = 0;
            this.cdvCrrGroup.IsViewBtnImage = false;
            this.cdvCrrGroup.Location = new System.Drawing.Point(120, 15);
            this.cdvCrrGroup.MaxLength = 20;
            this.cdvCrrGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.Name = "cdvCrrGroup";
            this.cdvCrrGroup.ReadOnly = true;
            this.cdvCrrGroup.SearchSubItemIndex = 0;
            this.cdvCrrGroup.SelectedDescIndex = -1;
            this.cdvCrrGroup.SelectedSubItemIndex = -1;
            this.cdvCrrGroup.SelectionStart = 0;
            this.cdvCrrGroup.Size = new System.Drawing.Size(200, 20);
            this.cdvCrrGroup.SmallImageList = null;
            this.cdvCrrGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrGroup.TabIndex = 1;
            this.cdvCrrGroup.TextBoxToolTipText = "";
            this.cdvCrrGroup.TextBoxWidth = 200;
            this.cdvCrrGroup.VisibleButton = true;
            this.cdvCrrGroup.VisibleColumnHeader = false;
            this.cdvCrrGroup.VisibleDescription = false;
            this.cdvCrrGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCrrGroup_SelectedItemChanged);
            this.cdvCrrGroup.ButtonPress += new System.EventHandler(this.cdvCrrGroup_ButtonPress);
            // 
            // lblCrrGroup
            // 
            this.lblCrrGroup.AutoSize = true;
            this.lblCrrGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrGroup.Location = new System.Drawing.Point(15, 18);
            this.lblCrrGroup.Name = "lblCrrGroup";
            this.lblCrrGroup.Size = new System.Drawing.Size(69, 13);
            this.lblCrrGroup.TabIndex = 0;
            this.lblCrrGroup.Text = "Carrier Group";
            // 
            // cdvCrrType
            // 
            this.cdvCrrType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrType.BtnToolTipText = "";
            this.cdvCrrType.DescText = "";
            this.cdvCrrType.DisplaySubItemIndex = -1;
            this.cdvCrrType.DisplayText = "";
            this.cdvCrrType.Focusing = null;
            this.cdvCrrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrType.Index = 0;
            this.cdvCrrType.IsViewBtnImage = false;
            this.cdvCrrType.Location = new System.Drawing.Point(516, 15);
            this.cdvCrrType.MaxLength = 10;
            this.cdvCrrType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType.Name = "cdvCrrType";
            this.cdvCrrType.ReadOnly = false;
            this.cdvCrrType.SearchSubItemIndex = 0;
            this.cdvCrrType.SelectedDescIndex = -1;
            this.cdvCrrType.SelectedSubItemIndex = -1;
            this.cdvCrrType.SelectionStart = 0;
            this.cdvCrrType.Size = new System.Drawing.Size(200, 20);
            this.cdvCrrType.SmallImageList = null;
            this.cdvCrrType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrType.TabIndex = 5;
            this.cdvCrrType.TextBoxToolTipText = "";
            this.cdvCrrType.TextBoxWidth = 200;
            this.cdvCrrType.VisibleButton = true;
            this.cdvCrrType.VisibleColumnHeader = false;
            this.cdvCrrType.VisibleDescription = false;
            this.cdvCrrType.ButtonPress += new System.EventHandler(this.cdvCrrType_ButtonPress);
            // 
            // lblCrrType
            // 
            this.lblCrrType.AutoSize = true;
            this.lblCrrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrType.Location = new System.Drawing.Point(411, 18);
            this.lblCrrType.Name = "lblCrrType";
            this.lblCrrType.Size = new System.Drawing.Size(64, 13);
            this.lblCrrType.TabIndex = 4;
            this.lblCrrType.Text = "Carrier Type";
            // 
            // cdvCrrID
            // 
            this.cdvCrrID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrID.BtnToolTipText = "";
            this.cdvCrrID.DescText = "";
            this.cdvCrrID.DisplaySubItemIndex = -1;
            this.cdvCrrID.DisplayText = "";
            this.cdvCrrID.Focusing = null;
            this.cdvCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrID.Index = 0;
            this.cdvCrrID.IsViewBtnImage = false;
            this.cdvCrrID.Location = new System.Drawing.Point(120, 42);
            this.cdvCrrID.MaxLength = 20;
            this.cdvCrrID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.Name = "cdvCrrID";
            this.cdvCrrID.ReadOnly = false;
            this.cdvCrrID.SearchSubItemIndex = 0;
            this.cdvCrrID.SelectedDescIndex = -1;
            this.cdvCrrID.SelectedSubItemIndex = -1;
            this.cdvCrrID.SelectionStart = 0;
            this.cdvCrrID.Size = new System.Drawing.Size(200, 20);
            this.cdvCrrID.SmallImageList = null;
            this.cdvCrrID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrID.TabIndex = 3;
            this.cdvCrrID.TextBoxToolTipText = "";
            this.cdvCrrID.TextBoxWidth = 200;
            this.cdvCrrID.VisibleButton = true;
            this.cdvCrrID.VisibleColumnHeader = false;
            this.cdvCrrID.VisibleDescription = false;
            this.cdvCrrID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCrrID_SelectedItemChanged);
            this.cdvCrrID.ButtonPress += new System.EventHandler(this.cdvCrrID_ButtonPress);
            this.cdvCrrID.TextBoxTextChanged += new System.EventHandler(this.cdvCrrID_TextBoxTextChanged);
            // 
            // lblCrrID
            // 
            this.lblCrrID.AutoSize = true;
            this.lblCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrID.Location = new System.Drawing.Point(15, 45);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(61, 13);
            this.lblCrrID.TabIndex = 2;
            this.lblCrrID.Text = "Carrier ID";
            // 
            // pnlEvent
            // 
            this.pnlEvent.Controls.Add(this.grpEvent);
            this.pnlEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEvent.Location = new System.Drawing.Point(3, 72);
            this.pnlEvent.Name = "pnlEvent";
            this.pnlEvent.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlEvent.Size = new System.Drawing.Size(736, 72);
            this.pnlEvent.TabIndex = 1;
            // 
            // grpEvent
            // 
            this.grpEvent.Controls.Add(this.cdvCrrEventID);
            this.grpEvent.Controls.Add(this.lblEvent);
            this.grpEvent.Controls.Add(this.txtLastEventTime);
            this.grpEvent.Controls.Add(this.lblLastEventTime);
            this.grpEvent.Controls.Add(this.txtLastEvent);
            this.grpEvent.Controls.Add(this.lblLastEvent);
            this.grpEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpEvent.Location = new System.Drawing.Point(0, 0);
            this.grpEvent.Name = "grpEvent";
            this.grpEvent.Size = new System.Drawing.Size(736, 69);
            this.grpEvent.TabIndex = 0;
            this.grpEvent.TabStop = false;
            // 
            // cdvCrrEventID
            // 
            this.cdvCrrEventID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCrrEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrEventID.BtnToolTipText = "";
            this.cdvCrrEventID.DescText = "";
            this.cdvCrrEventID.DisplaySubItemIndex = 1;
            this.cdvCrrEventID.DisplayText = "";
            this.cdvCrrEventID.Focusing = null;
            this.cdvCrrEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrEventID.Index = 0;
            this.cdvCrrEventID.IsViewBtnImage = false;
            this.cdvCrrEventID.Location = new System.Drawing.Point(120, 40);
            this.cdvCrrEventID.MaxLength = 12;
            this.cdvCrrEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrEventID.Name = "cdvCrrEventID";
            this.cdvCrrEventID.ReadOnly = true;
            this.cdvCrrEventID.SearchSubItemIndex = 0;
            this.cdvCrrEventID.SelectedDescIndex = 0;
            this.cdvCrrEventID.SelectedSubItemIndex = 0;
            this.cdvCrrEventID.SelectionStart = 0;
            this.cdvCrrEventID.Size = new System.Drawing.Size(606, 20);
            this.cdvCrrEventID.SmallImageList = null;
            this.cdvCrrEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrEventID.TabIndex = 5;
            this.cdvCrrEventID.TextBoxToolTipText = "";
            this.cdvCrrEventID.TextBoxWidth = 200;
            this.cdvCrrEventID.VisibleButton = true;
            this.cdvCrrEventID.VisibleColumnHeader = false;
            this.cdvCrrEventID.VisibleDescription = true;
            this.cdvCrrEventID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCrrEventID_SelectedItemChanged);
            this.cdvCrrEventID.ButtonPress += new System.EventHandler(this.cdvCrrEventID_ButtonPress);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEvent.Location = new System.Drawing.Point(16, 44);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(81, 13);
            this.lblEvent.TabIndex = 4;
            this.lblEvent.Text = "Carrier Event";
            // 
            // txtLastEventTime
            // 
            this.txtLastEventTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastEventTime.Location = new System.Drawing.Point(516, 16);
            this.txtLastEventTime.MaxLength = 30;
            this.txtLastEventTime.Name = "txtLastEventTime";
            this.txtLastEventTime.ReadOnly = true;
            this.txtLastEventTime.Size = new System.Drawing.Size(200, 20);
            this.txtLastEventTime.TabIndex = 3;
            this.txtLastEventTime.TabStop = false;
            // 
            // lblLastEventTime
            // 
            this.lblLastEventTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastEventTime.AutoSize = true;
            this.lblLastEventTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEventTime.Location = new System.Drawing.Point(411, 19);
            this.lblLastEventTime.Name = "lblLastEventTime";
            this.lblLastEventTime.Size = new System.Drawing.Size(84, 13);
            this.lblLastEventTime.TabIndex = 2;
            this.lblLastEventTime.Text = "Last Event Time";
            // 
            // txtLastEvent
            // 
            this.txtLastEvent.Location = new System.Drawing.Point(120, 16);
            this.txtLastEvent.MaxLength = 12;
            this.txtLastEvent.Name = "txtLastEvent";
            this.txtLastEvent.ReadOnly = true;
            this.txtLastEvent.Size = new System.Drawing.Size(200, 20);
            this.txtLastEvent.TabIndex = 1;
            this.txtLastEvent.TabStop = false;
            // 
            // lblLastEvent
            // 
            this.lblLastEvent.AutoSize = true;
            this.lblLastEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEvent.Location = new System.Drawing.Point(16, 18);
            this.lblLastEvent.Name = "lblLastEvent";
            this.lblLastEvent.Size = new System.Drawing.Size(58, 13);
            this.lblLastEvent.TabIndex = 0;
            this.lblLastEvent.Text = "Last Event";
            // 
            // pnlEventInfo
            // 
            this.pnlEventInfo.Controls.Add(this.spdData);
            this.pnlEventInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEventInfo.Location = new System.Drawing.Point(3, 144);
            this.pnlEventInfo.Name = "pnlEventInfo";
            this.pnlEventInfo.Size = new System.Drawing.Size(736, 322);
            this.pnlEventInfo.TabIndex = 2;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, LotInfo";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdData.Location = new System.Drawing.Point(0, 0);
            this.spdData.MoveActiveOnFocus = false;
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(736, 322);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            this.spdData.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdData_ButtonClicked);
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 4;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Carrier Articles";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Current Carrier Status";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Carrier Status Forecast";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdData_Sheet1.Columns.Get(0).Border = compoundBorder1;
            this.spdData_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(0).Label = "Carrier Articles";
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 180F;
            this.spdData_Sheet1.Columns.Get(1).Label = "Current Carrier Status";
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 150F;
            this.spdData_Sheet1.Columns.Get(2).Label = "Carrier Status Forecast";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 150F;
            this.spdData_Sheet1.Columns.Get(3).Width = 25F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.RowHeader.Visible = false;
            this.spdData_Sheet1.Rows.Default.Height = 17F;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpComment.Location = new System.Drawing.Point(3, 466);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(736, 40);
            this.grpComment.TabIndex = 3;
            this.grpComment.TabStop = false;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(12, 16);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(120, 13);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(592, 20);
            this.txtComment.TabIndex = 1;
            // 
            // cdvTableData
            // 
            this.cdvTableData.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableData.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableData.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableData.Location = new System.Drawing.Point(189, 17);
            this.cdvTableData.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableData.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableData.Name = "cdvTableData";
            this.cdvTableData.Size = new System.Drawing.Size(20, 20);
            this.cdvTableData.SmallImageList = null;
            this.cdvTableData.TabIndex = 0;
            this.cdvTableData.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableData.VisibleColumnHeader = false;
            this.cdvTableData.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableData_SelectedItemChanged);
            // 
            // frmRASTranCarrierEvent
            // 
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASTranCarrierEvent";
            this.Text = "Carrier Event";
            this.Load += new System.EventHandler(this.frmRASTranCarrierEvent_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).EndInit();
            this.pnlEvent.ResumeLayout(false);
            this.grpEvent.ResumeLayout(false);
            this.grpEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrEventID)).EndInit();
            this.pnlEventInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOption;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrGroup;
        private System.Windows.Forms.Label lblCrrGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrType;
        private System.Windows.Forms.Label lblCrrType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrID;
        private System.Windows.Forms.Label lblCrrID;
        private System.Windows.Forms.Panel pnlEvent;
        private System.Windows.Forms.Panel pnlEventInfo;
        private System.Windows.Forms.GroupBox grpEvent;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrEventID;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.TextBox txtLastEventTime;
        private System.Windows.Forms.Label lblLastEventTime;
        private System.Windows.Forms.TextBox txtLastEvent;
        private System.Windows.Forms.Label lblLastEvent;
        protected FarPoint.Win.Spread.FpSpread spdData;
        protected FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.Label lblComment;
        protected System.Windows.Forms.TextBox txtComment;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTableData;
    }
}
