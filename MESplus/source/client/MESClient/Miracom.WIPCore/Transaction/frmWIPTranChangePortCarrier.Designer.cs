namespace Miracom.WIPCore
{
    partial class frmWIPTranChangePortCarrier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPTranChangePortCarrier));
            this.pnlChangePortStatus = new System.Windows.Forms.Panel();
            this.grpPort = new System.Windows.Forms.GroupBox();
            this.cdvTrsState = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkUseTargetCarrier = new System.Windows.Forms.CheckBox();
            this.lblPortCarrier = new System.Windows.Forms.Label();
            this.cdvPortCarrier = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvPortID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPort = new System.Windows.Forms.Label();
            this.cdvSubResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubResID = new System.Windows.Forms.Label();
            this.lblResID = new System.Windows.Forms.Label();
            this.txtResID = new System.Windows.Forms.TextBox();
            this.txtLotDesc = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.pnlChangeCarrier = new System.Windows.Forms.Panel();
            this.pnlCarrierMap = new System.Windows.Forms.Panel();
            this.grpChangeCarrier = new System.Windows.Forms.GroupBox();
            this.pnlMapTarget = new System.Windows.Forms.Panel();
            this.lisTarget = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSlot2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSublot2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFromSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTargetCarrier = new System.Windows.Forms.Panel();
            this.cdvTargetType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvTargetGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTargetGroup = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.cdvTargetCarrier = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlMapCenter = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.pnlMapSource = new System.Windows.Forms.Panel();
            this.lisSource = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSlot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubLot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colToSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSourceCarrier = new System.Windows.Forms.Panel();
            this.cdvSourceType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvSourceGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSourceGroup = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.cdvSourceCarrier = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.grpExchange = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnXF = new System.Windows.Forms.Button();
            this.btnXC = new System.Windows.Forms.Button();
            this.btnSF = new System.Windows.Forms.Button();
            this.btnST = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlChangePortStatus.SuspendLayout();
            this.grpPort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTrsState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPortCarrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPortID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResID)).BeginInit();
            this.pnlChangeCarrier.SuspendLayout();
            this.pnlCarrierMap.SuspendLayout();
            this.grpChangeCarrier.SuspendLayout();
            this.pnlMapTarget.SuspendLayout();
            this.pnlTargetCarrier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetCarrier)).BeginInit();
            this.pnlMapCenter.SuspendLayout();
            this.pnlMapSource.SuspendLayout();
            this.pnlSourceCarrier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceCarrier)).BeginInit();
            this.grpExchange.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(565, 7);
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(656, 7);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.grpExchange);
            this.pnlBottom.Location = new System.Drawing.Point(0, 610);
            this.pnlBottom.Size = new System.Drawing.Size(744, 40);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.grpExchange, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlChangeCarrier);
            this.pnlCenter.Controls.Add(this.pnlChangePortStatus);
            this.pnlCenter.Size = new System.Drawing.Size(744, 610);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // pnlChangePortStatus
            // 
            this.pnlChangePortStatus.Controls.Add(this.grpPort);
            this.pnlChangePortStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChangePortStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlChangePortStatus.Name = "pnlChangePortStatus";
            this.pnlChangePortStatus.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlChangePortStatus.Size = new System.Drawing.Size(744, 92);
            this.pnlChangePortStatus.TabIndex = 0;
            // 
            // grpPort
            // 
            this.grpPort.Controls.Add(this.cdvTrsState);
            this.grpPort.Controls.Add(this.chkUseTargetCarrier);
            this.grpPort.Controls.Add(this.lblPortCarrier);
            this.grpPort.Controls.Add(this.cdvPortCarrier);
            this.grpPort.Controls.Add(this.cdvPortID);
            this.grpPort.Controls.Add(this.lblPort);
            this.grpPort.Controls.Add(this.cdvSubResID);
            this.grpPort.Controls.Add(this.lblSubResID);
            this.grpPort.Controls.Add(this.lblResID);
            this.grpPort.Controls.Add(this.txtResID);
            this.grpPort.Controls.Add(this.txtLotDesc);
            this.grpPort.Controls.Add(this.lblLotID);
            this.grpPort.Controls.Add(this.txtLotID);
            this.grpPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPort.Location = new System.Drawing.Point(0, 0);
            this.grpPort.Name = "grpPort";
            this.grpPort.Size = new System.Drawing.Size(744, 89);
            this.grpPort.TabIndex = 0;
            this.grpPort.TabStop = false;
            this.grpPort.Text = "Port Information";
            // 
            // cdvTrsState
            // 
            this.cdvTrsState.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTrsState.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTrsState.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTrsState.BtnToolTipText = "";
            this.cdvTrsState.DescText = "";
            this.cdvTrsState.DisplaySubItemIndex = -1;
            this.cdvTrsState.DisplayText = "";
            this.cdvTrsState.Focusing = null;
            this.cdvTrsState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTrsState.Index = 0;
            this.cdvTrsState.IsViewBtnImage = false;
            this.cdvTrsState.Location = new System.Drawing.Point(213, 63);
            this.cdvTrsState.MaxLength = 10;
            this.cdvTrsState.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTrsState.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTrsState.Name = "cdvTrsState";
            this.cdvTrsState.ReadOnly = true;
            this.cdvTrsState.SearchSubItemIndex = 0;
            this.cdvTrsState.SelectedDescIndex = -1;
            this.cdvTrsState.SelectedSubItemIndex = -1;
            this.cdvTrsState.SelectionStart = 0;
            this.cdvTrsState.Size = new System.Drawing.Size(110, 20);
            this.cdvTrsState.SmallImageList = null;
            this.cdvTrsState.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTrsState.TabIndex = 9;
            this.cdvTrsState.TextBoxToolTipText = "";
            this.cdvTrsState.TextBoxWidth = 110;
            this.cdvTrsState.VisibleButton = false;
            this.cdvTrsState.VisibleColumnHeader = false;
            this.cdvTrsState.VisibleDescription = false;
            this.cdvTrsState.ButtonPress += new System.EventHandler(this.cdvTrsState_ButtonPress);
            // 
            // chkUseTargetCarrier
            // 
            this.chkUseTargetCarrier.AutoSize = true;
            this.chkUseTargetCarrier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUseTargetCarrier.Location = new System.Drawing.Point(329, 64);
            this.chkUseTargetCarrier.Name = "chkUseTargetCarrier";
            this.chkUseTargetCarrier.Size = new System.Drawing.Size(134, 17);
            this.chkUseTargetCarrier.TabIndex = 10;
            this.chkUseTargetCarrier.Text = "Use Target Carrier";
            this.chkUseTargetCarrier.CheckedChanged += new System.EventHandler(this.chkUseTargetCarrier_CheckedChanged);
            // 
            // lblPortCarrier
            // 
            this.lblPortCarrier.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPortCarrier.AutoSize = true;
            this.lblPortCarrier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPortCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortCarrier.Location = new System.Drawing.Point(475, 67);
            this.lblPortCarrier.Name = "lblPortCarrier";
            this.lblPortCarrier.Size = new System.Drawing.Size(88, 13);
            this.lblPortCarrier.TabIndex = 11;
            this.lblPortCarrier.Text = "Port Carrier ID";
            // 
            // cdvPortCarrier
            // 
            this.cdvPortCarrier.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPortCarrier.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPortCarrier.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPortCarrier.BtnToolTipText = "";
            this.cdvPortCarrier.DescText = "";
            this.cdvPortCarrier.DisplaySubItemIndex = -1;
            this.cdvPortCarrier.DisplayText = "";
            this.cdvPortCarrier.Focusing = null;
            this.cdvPortCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPortCarrier.Index = 0;
            this.cdvPortCarrier.IsViewBtnImage = false;
            this.cdvPortCarrier.Location = new System.Drawing.Point(564, 63);
            this.cdvPortCarrier.MaxLength = 20;
            this.cdvPortCarrier.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPortCarrier.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPortCarrier.Name = "cdvPortCarrier";
            this.cdvPortCarrier.ReadOnly = false;
            this.cdvPortCarrier.SearchSubItemIndex = 0;
            this.cdvPortCarrier.SelectedDescIndex = -1;
            this.cdvPortCarrier.SelectedSubItemIndex = -1;
            this.cdvPortCarrier.SelectionStart = 0;
            this.cdvPortCarrier.Size = new System.Drawing.Size(171, 20);
            this.cdvPortCarrier.SmallImageList = null;
            this.cdvPortCarrier.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPortCarrier.TabIndex = 12;
            this.cdvPortCarrier.TextBoxToolTipText = "";
            this.cdvPortCarrier.TextBoxWidth = 171;
            this.cdvPortCarrier.VisibleButton = true;
            this.cdvPortCarrier.VisibleColumnHeader = false;
            this.cdvPortCarrier.VisibleDescription = false;
            this.cdvPortCarrier.ButtonPress += new System.EventHandler(this.cdvPortCarrier_ButtonPress);
            this.cdvPortCarrier.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvPortCarrier_TextBoxKeyPress);
            // 
            // cdvPortID
            // 
            this.cdvPortID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPortID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPortID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPortID.BtnToolTipText = "";
            this.cdvPortID.DescText = "";
            this.cdvPortID.DisplaySubItemIndex = -1;
            this.cdvPortID.DisplayText = "";
            this.cdvPortID.Focusing = null;
            this.cdvPortID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPortID.Index = 0;
            this.cdvPortID.IsViewBtnImage = false;
            this.cdvPortID.Location = new System.Drawing.Point(96, 63);
            this.cdvPortID.MaxLength = 10;
            this.cdvPortID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPortID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPortID.Name = "cdvPortID";
            this.cdvPortID.ReadOnly = false;
            this.cdvPortID.SearchSubItemIndex = 0;
            this.cdvPortID.SelectedDescIndex = -1;
            this.cdvPortID.SelectedSubItemIndex = -1;
            this.cdvPortID.SelectionStart = 0;
            this.cdvPortID.Size = new System.Drawing.Size(115, 20);
            this.cdvPortID.SmallImageList = null;
            this.cdvPortID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPortID.TabIndex = 8;
            this.cdvPortID.TextBoxToolTipText = "";
            this.cdvPortID.TextBoxWidth = 115;
            this.cdvPortID.VisibleButton = true;
            this.cdvPortID.VisibleColumnHeader = false;
            this.cdvPortID.VisibleDescription = false;
            this.cdvPortID.ButtonPress += new System.EventHandler(this.cdvPortID_ButtonPress);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(15, 67);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(47, 13);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "Port ID";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvSubResID
            // 
            this.cdvSubResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubResID.BtnToolTipText = "";
            this.cdvSubResID.DescText = "";
            this.cdvSubResID.DisplaySubItemIndex = -1;
            this.cdvSubResID.DisplayText = "";
            this.cdvSubResID.Focusing = null;
            this.cdvSubResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubResID.Index = 0;
            this.cdvSubResID.IsViewBtnImage = false;
            this.cdvSubResID.Location = new System.Drawing.Point(564, 38);
            this.cdvSubResID.MaxLength = 20;
            this.cdvSubResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubResID.Name = "cdvSubResID";
            this.cdvSubResID.ReadOnly = false;
            this.cdvSubResID.SearchSubItemIndex = 0;
            this.cdvSubResID.SelectedDescIndex = -1;
            this.cdvSubResID.SelectedSubItemIndex = -1;
            this.cdvSubResID.SelectionStart = 0;
            this.cdvSubResID.Size = new System.Drawing.Size(171, 20);
            this.cdvSubResID.SmallImageList = null;
            this.cdvSubResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubResID.TabIndex = 6;
            this.cdvSubResID.TextBoxToolTipText = "";
            this.cdvSubResID.TextBoxWidth = 171;
            this.cdvSubResID.VisibleButton = true;
            this.cdvSubResID.VisibleColumnHeader = false;
            this.cdvSubResID.VisibleDescription = false;
            this.cdvSubResID.ButtonPress += new System.EventHandler(this.cdvSubResID_ButtonPress);
            // 
            // lblSubResID
            // 
            this.lblSubResID.AutoSize = true;
            this.lblSubResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubResID.Location = new System.Drawing.Point(475, 42);
            this.lblSubResID.Name = "lblSubResID";
            this.lblSubResID.Size = new System.Drawing.Size(89, 13);
            this.lblSubResID.TabIndex = 5;
            this.lblSubResID.Text = "Sub Resource ID";
            this.lblSubResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Location = new System.Drawing.Point(15, 42);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 3;
            this.lblResID.Text = "Resource ID";
            // 
            // txtResID
            // 
            this.txtResID.BackColor = System.Drawing.SystemColors.Control;
            this.txtResID.Location = new System.Drawing.Point(96, 38);
            this.txtResID.MaxLength = 20;
            this.txtResID.Name = "txtResID";
            this.txtResID.ReadOnly = true;
            this.txtResID.Size = new System.Drawing.Size(227, 20);
            this.txtResID.TabIndex = 4;
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotDesc.BackColor = System.Drawing.SystemColors.Control;
            this.txtLotDesc.Location = new System.Drawing.Point(329, 13);
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.Name = "txtLotDesc";
            this.txtLotDesc.ReadOnly = true;
            this.txtLotDesc.Size = new System.Drawing.Size(406, 20);
            this.txtLotDesc.TabIndex = 2;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Location = new System.Drawing.Point(15, 17);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // txtLotID
            // 
            this.txtLotID.BackColor = System.Drawing.SystemColors.Control;
            this.txtLotID.Location = new System.Drawing.Point(96, 13);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.ReadOnly = true;
            this.txtLotID.Size = new System.Drawing.Size(227, 20);
            this.txtLotID.TabIndex = 1;
            // 
            // pnlChangeCarrier
            // 
            this.pnlChangeCarrier.Controls.Add(this.pnlCarrierMap);
            this.pnlChangeCarrier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChangeCarrier.Location = new System.Drawing.Point(0, 92);
            this.pnlChangeCarrier.Name = "pnlChangeCarrier";
            this.pnlChangeCarrier.Size = new System.Drawing.Size(744, 518);
            this.pnlChangeCarrier.TabIndex = 1;
            // 
            // pnlCarrierMap
            // 
            this.pnlCarrierMap.Controls.Add(this.grpChangeCarrier);
            this.pnlCarrierMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCarrierMap.Location = new System.Drawing.Point(0, 0);
            this.pnlCarrierMap.Name = "pnlCarrierMap";
            this.pnlCarrierMap.Size = new System.Drawing.Size(744, 518);
            this.pnlCarrierMap.TabIndex = 1;
            this.pnlCarrierMap.Resize += new System.EventHandler(this.pnlCarrierMap_Resize);
            // 
            // grpChangeCarrier
            // 
            this.grpChangeCarrier.Controls.Add(this.pnlMapTarget);
            this.grpChangeCarrier.Controls.Add(this.pnlMapCenter);
            this.grpChangeCarrier.Controls.Add(this.pnlMapSource);
            this.grpChangeCarrier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChangeCarrier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChangeCarrier.Location = new System.Drawing.Point(0, 0);
            this.grpChangeCarrier.Name = "grpChangeCarrier";
            this.grpChangeCarrier.Size = new System.Drawing.Size(744, 518);
            this.grpChangeCarrier.TabIndex = 0;
            this.grpChangeCarrier.TabStop = false;
            this.grpChangeCarrier.Text = "Change Carrier Information";
            // 
            // pnlMapTarget
            // 
            this.pnlMapTarget.Controls.Add(this.lisTarget);
            this.pnlMapTarget.Controls.Add(this.pnlTargetCarrier);
            this.pnlMapTarget.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMapTarget.Location = new System.Drawing.Point(422, 16);
            this.pnlMapTarget.Name = "pnlMapTarget";
            this.pnlMapTarget.Size = new System.Drawing.Size(319, 499);
            this.pnlMapTarget.TabIndex = 2;
            // 
            // lisTarget
            // 
            this.lisTarget.AllowDrop = true;
            this.lisTarget.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSlot2,
            this.colSublot2,
            this.colLot2,
            this.colFromSlot});
            this.lisTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisTarget.EnableSort = true;
            this.lisTarget.EnableSortIcon = true;
            this.lisTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisTarget.FullRowSelect = true;
            this.lisTarget.Location = new System.Drawing.Point(0, 50);
            this.lisTarget.Name = "lisTarget";
            this.lisTarget.Size = new System.Drawing.Size(319, 449);
            this.lisTarget.TabIndex = 1;
            this.lisTarget.UseCompatibleStateImageBehavior = false;
            this.lisTarget.View = System.Windows.Forms.View.Details;
            // 
            // colSlot2
            // 
            this.colSlot2.Text = "Slot No";
            this.colSlot2.Width = 47;
            // 
            // colSublot2
            // 
            this.colSublot2.Text = "SubLot ID";
            this.colSublot2.Width = 110;
            // 
            // colLot2
            // 
            this.colLot2.Text = "Lot ID";
            this.colLot2.Width = 100;
            // 
            // colFromSlot
            // 
            this.colFromSlot.Text = "From Slot";
            // 
            // pnlTargetCarrier
            // 
            this.pnlTargetCarrier.Controls.Add(this.cdvTargetType);
            this.pnlTargetCarrier.Controls.Add(this.cdvTargetGroup);
            this.pnlTargetCarrier.Controls.Add(this.lblTargetGroup);
            this.pnlTargetCarrier.Controls.Add(this.lblTarget);
            this.pnlTargetCarrier.Controls.Add(this.cdvTargetCarrier);
            this.pnlTargetCarrier.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTargetCarrier.Location = new System.Drawing.Point(0, 0);
            this.pnlTargetCarrier.Name = "pnlTargetCarrier";
            this.pnlTargetCarrier.Size = new System.Drawing.Size(319, 50);
            this.pnlTargetCarrier.TabIndex = 0;
            // 
            // cdvTargetType
            // 
            this.cdvTargetType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdvTargetType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTargetType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTargetType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTargetType.BtnToolTipText = "";
            this.cdvTargetType.DescText = "";
            this.cdvTargetType.DisplaySubItemIndex = -1;
            this.cdvTargetType.DisplayText = "";
            this.cdvTargetType.Focusing = null;
            this.cdvTargetType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTargetType.Index = 0;
            this.cdvTargetType.IsViewBtnImage = false;
            this.cdvTargetType.Location = new System.Drawing.Point(215, 0);
            this.cdvTargetType.MaxLength = 20;
            this.cdvTargetType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTargetType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTargetType.Name = "cdvTargetType";
            this.cdvTargetType.ReadOnly = true;
            this.cdvTargetType.SearchSubItemIndex = 0;
            this.cdvTargetType.SelectedDescIndex = -1;
            this.cdvTargetType.SelectedSubItemIndex = -1;
            this.cdvTargetType.SelectionStart = 0;
            this.cdvTargetType.Size = new System.Drawing.Size(95, 20);
            this.cdvTargetType.SmallImageList = null;
            this.cdvTargetType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTargetType.TabIndex = 2;
            this.cdvTargetType.TextBoxToolTipText = "";
            this.cdvTargetType.TextBoxWidth = 95;
            this.cdvTargetType.VisibleButton = false;
            this.cdvTargetType.VisibleColumnHeader = false;
            this.cdvTargetType.VisibleDescription = false;
            // 
            // cdvTargetGroup
            // 
            this.cdvTargetGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdvTargetGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTargetGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTargetGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTargetGroup.BtnToolTipText = "";
            this.cdvTargetGroup.DescText = "";
            this.cdvTargetGroup.DisplaySubItemIndex = -1;
            this.cdvTargetGroup.DisplayText = "";
            this.cdvTargetGroup.Focusing = null;
            this.cdvTargetGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTargetGroup.Index = 0;
            this.cdvTargetGroup.IsViewBtnImage = false;
            this.cdvTargetGroup.Location = new System.Drawing.Point(118, 0);
            this.cdvTargetGroup.MaxLength = 20;
            this.cdvTargetGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTargetGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTargetGroup.Name = "cdvTargetGroup";
            this.cdvTargetGroup.ReadOnly = true;
            this.cdvTargetGroup.SearchSubItemIndex = 0;
            this.cdvTargetGroup.SelectedDescIndex = -1;
            this.cdvTargetGroup.SelectedSubItemIndex = -1;
            this.cdvTargetGroup.SelectionStart = 0;
            this.cdvTargetGroup.Size = new System.Drawing.Size(95, 20);
            this.cdvTargetGroup.SmallImageList = null;
            this.cdvTargetGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTargetGroup.TabIndex = 1;
            this.cdvTargetGroup.TextBoxToolTipText = "";
            this.cdvTargetGroup.TextBoxWidth = 95;
            this.cdvTargetGroup.VisibleButton = true;
            this.cdvTargetGroup.VisibleColumnHeader = false;
            this.cdvTargetGroup.VisibleDescription = false;
            this.cdvTargetGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvTargetGroup_SelectedItemChanged);
            this.cdvTargetGroup.ButtonPress += new System.EventHandler(this.cdvTargetGroup_ButtonPress);
            // 
            // lblTargetGroup
            // 
            this.lblTargetGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTargetGroup.AutoSize = true;
            this.lblTargetGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTargetGroup.Location = new System.Drawing.Point(9, 4);
            this.lblTargetGroup.Name = "lblTargetGroup";
            this.lblTargetGroup.Size = new System.Drawing.Size(101, 13);
            this.lblTargetGroup.TabIndex = 0;
            this.lblTargetGroup.Text = "Carrier Group/ Type";
            // 
            // lblTarget
            // 
            this.lblTarget.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTarget.AutoSize = true;
            this.lblTarget.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(9, 28);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(85, 13);
            this.lblTarget.TabIndex = 3;
            this.lblTarget.Text = "Target Carrier ID";
            // 
            // cdvTargetCarrier
            // 
            this.cdvTargetCarrier.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdvTargetCarrier.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTargetCarrier.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTargetCarrier.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTargetCarrier.BtnToolTipText = "";
            this.cdvTargetCarrier.DescText = "";
            this.cdvTargetCarrier.DisplaySubItemIndex = -1;
            this.cdvTargetCarrier.DisplayText = "";
            this.cdvTargetCarrier.Focusing = null;
            this.cdvTargetCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTargetCarrier.Index = 0;
            this.cdvTargetCarrier.IsViewBtnImage = false;
            this.cdvTargetCarrier.Location = new System.Drawing.Point(118, 24);
            this.cdvTargetCarrier.MaxLength = 20;
            this.cdvTargetCarrier.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTargetCarrier.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTargetCarrier.Name = "cdvTargetCarrier";
            this.cdvTargetCarrier.ReadOnly = false;
            this.cdvTargetCarrier.SearchSubItemIndex = 0;
            this.cdvTargetCarrier.SelectedDescIndex = -1;
            this.cdvTargetCarrier.SelectedSubItemIndex = -1;
            this.cdvTargetCarrier.SelectionStart = 0;
            this.cdvTargetCarrier.Size = new System.Drawing.Size(192, 20);
            this.cdvTargetCarrier.SmallImageList = null;
            this.cdvTargetCarrier.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTargetCarrier.TabIndex = 4;
            this.cdvTargetCarrier.TextBoxToolTipText = "";
            this.cdvTargetCarrier.TextBoxWidth = 192;
            this.cdvTargetCarrier.VisibleButton = true;
            this.cdvTargetCarrier.VisibleColumnHeader = false;
            this.cdvTargetCarrier.VisibleDescription = false;
            this.cdvTargetCarrier.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvTargetCarrier_SelectedItemChanged);
            this.cdvTargetCarrier.ButtonPress += new System.EventHandler(this.cdvTargetCarrier_ButtonPress);
            this.cdvTargetCarrier.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvTargetCarrier_TextBoxKeyPress);
            this.cdvTargetCarrier.TextBoxTextChanged += new System.EventHandler(this.cdvTargetCarrier_TextBoxTextChanged);
            // 
            // pnlMapCenter
            // 
            this.pnlMapCenter.Controls.Add(this.btnDown);
            this.pnlMapCenter.Controls.Add(this.btnUp);
            this.pnlMapCenter.Controls.Add(this.btnInsert);
            this.pnlMapCenter.Controls.Add(this.btnReject);
            this.pnlMapCenter.Location = new System.Drawing.Point(341, 66);
            this.pnlMapCenter.Name = "pnlMapCenter";
            this.pnlMapCenter.Size = new System.Drawing.Size(60, 401);
            this.pnlMapCenter.TabIndex = 1;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(33, 374);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 18;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(33, 347);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 17;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(18, 174);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(24, 24);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = ">";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.Location = new System.Drawing.Point(18, 204);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(24, 24);
            this.btnReject.TabIndex = 1;
            this.btnReject.Text = "<";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // pnlMapSource
            // 
            this.pnlMapSource.Controls.Add(this.lisSource);
            this.pnlMapSource.Controls.Add(this.pnlSourceCarrier);
            this.pnlMapSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMapSource.Location = new System.Drawing.Point(3, 16);
            this.pnlMapSource.Name = "pnlMapSource";
            this.pnlMapSource.Size = new System.Drawing.Size(318, 499);
            this.pnlMapSource.TabIndex = 0;
            // 
            // lisSource
            // 
            this.lisSource.AllowDrop = true;
            this.lisSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSlot1,
            this.colSubLot1,
            this.colLot1,
            this.colToSlot});
            this.lisSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSource.EnableSort = true;
            this.lisSource.EnableSortIcon = true;
            this.lisSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSource.FullRowSelect = true;
            this.lisSource.Location = new System.Drawing.Point(0, 50);
            this.lisSource.Name = "lisSource";
            this.lisSource.Size = new System.Drawing.Size(318, 449);
            this.lisSource.TabIndex = 1;
            this.lisSource.UseCompatibleStateImageBehavior = false;
            this.lisSource.View = System.Windows.Forms.View.Details;
            // 
            // colSlot1
            // 
            this.colSlot1.Text = "Slot No";
            this.colSlot1.Width = 47;
            // 
            // colSubLot1
            // 
            this.colSubLot1.Text = "SubLot ID";
            this.colSubLot1.Width = 110;
            // 
            // colLot1
            // 
            this.colLot1.Text = "Lot ID";
            this.colLot1.Width = 100;
            // 
            // colToSlot
            // 
            this.colToSlot.Text = "To Slot";
            // 
            // pnlSourceCarrier
            // 
            this.pnlSourceCarrier.Controls.Add(this.cdvSourceType);
            this.pnlSourceCarrier.Controls.Add(this.cdvSourceGroup);
            this.pnlSourceCarrier.Controls.Add(this.lblSourceGroup);
            this.pnlSourceCarrier.Controls.Add(this.lblSource);
            this.pnlSourceCarrier.Controls.Add(this.cdvSourceCarrier);
            this.pnlSourceCarrier.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSourceCarrier.Location = new System.Drawing.Point(0, 0);
            this.pnlSourceCarrier.Name = "pnlSourceCarrier";
            this.pnlSourceCarrier.Size = new System.Drawing.Size(318, 50);
            this.pnlSourceCarrier.TabIndex = 0;
            // 
            // cdvSourceType
            // 
            this.cdvSourceType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdvSourceType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSourceType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSourceType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSourceType.BtnToolTipText = "";
            this.cdvSourceType.DescText = "";
            this.cdvSourceType.DisplaySubItemIndex = -1;
            this.cdvSourceType.DisplayText = "";
            this.cdvSourceType.Focusing = null;
            this.cdvSourceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSourceType.Index = 0;
            this.cdvSourceType.IsViewBtnImage = false;
            this.cdvSourceType.Location = new System.Drawing.Point(215, 0);
            this.cdvSourceType.MaxLength = 20;
            this.cdvSourceType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSourceType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSourceType.Name = "cdvSourceType";
            this.cdvSourceType.ReadOnly = true;
            this.cdvSourceType.SearchSubItemIndex = 0;
            this.cdvSourceType.SelectedDescIndex = -1;
            this.cdvSourceType.SelectedSubItemIndex = -1;
            this.cdvSourceType.SelectionStart = 0;
            this.cdvSourceType.Size = new System.Drawing.Size(95, 20);
            this.cdvSourceType.SmallImageList = null;
            this.cdvSourceType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSourceType.TabIndex = 2;
            this.cdvSourceType.TextBoxToolTipText = "";
            this.cdvSourceType.TextBoxWidth = 95;
            this.cdvSourceType.VisibleButton = false;
            this.cdvSourceType.VisibleColumnHeader = false;
            this.cdvSourceType.VisibleDescription = false;
            // 
            // cdvSourceGroup
            // 
            this.cdvSourceGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdvSourceGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSourceGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSourceGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSourceGroup.BtnToolTipText = "";
            this.cdvSourceGroup.DescText = "";
            this.cdvSourceGroup.DisplaySubItemIndex = -1;
            this.cdvSourceGroup.DisplayText = "";
            this.cdvSourceGroup.Focusing = null;
            this.cdvSourceGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSourceGroup.Index = 0;
            this.cdvSourceGroup.IsViewBtnImage = false;
            this.cdvSourceGroup.Location = new System.Drawing.Point(118, 0);
            this.cdvSourceGroup.MaxLength = 20;
            this.cdvSourceGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSourceGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSourceGroup.Name = "cdvSourceGroup";
            this.cdvSourceGroup.ReadOnly = true;
            this.cdvSourceGroup.SearchSubItemIndex = 0;
            this.cdvSourceGroup.SelectedDescIndex = -1;
            this.cdvSourceGroup.SelectedSubItemIndex = -1;
            this.cdvSourceGroup.SelectionStart = 0;
            this.cdvSourceGroup.Size = new System.Drawing.Size(95, 20);
            this.cdvSourceGroup.SmallImageList = null;
            this.cdvSourceGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSourceGroup.TabIndex = 1;
            this.cdvSourceGroup.TextBoxToolTipText = "";
            this.cdvSourceGroup.TextBoxWidth = 95;
            this.cdvSourceGroup.VisibleButton = false;
            this.cdvSourceGroup.VisibleColumnHeader = false;
            this.cdvSourceGroup.VisibleDescription = false;
            // 
            // lblSourceGroup
            // 
            this.lblSourceGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSourceGroup.AutoSize = true;
            this.lblSourceGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSourceGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSourceGroup.Location = new System.Drawing.Point(9, 4);
            this.lblSourceGroup.Name = "lblSourceGroup";
            this.lblSourceGroup.Size = new System.Drawing.Size(101, 13);
            this.lblSourceGroup.TabIndex = 0;
            this.lblSourceGroup.Text = "Carrier Group/ Type";
            // 
            // lblSource
            // 
            this.lblSource.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSource.AutoSize = true;
            this.lblSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(9, 28);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(88, 13);
            this.lblSource.TabIndex = 3;
            this.lblSource.Text = "Current Carrier ID";
            // 
            // cdvSourceCarrier
            // 
            this.cdvSourceCarrier.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cdvSourceCarrier.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSourceCarrier.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSourceCarrier.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSourceCarrier.BtnToolTipText = "";
            this.cdvSourceCarrier.DescText = "";
            this.cdvSourceCarrier.DisplaySubItemIndex = -1;
            this.cdvSourceCarrier.DisplayText = "";
            this.cdvSourceCarrier.Focusing = null;
            this.cdvSourceCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSourceCarrier.Index = 0;
            this.cdvSourceCarrier.IsViewBtnImage = false;
            this.cdvSourceCarrier.Location = new System.Drawing.Point(118, 24);
            this.cdvSourceCarrier.MaxLength = 20;
            this.cdvSourceCarrier.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSourceCarrier.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSourceCarrier.Name = "cdvSourceCarrier";
            this.cdvSourceCarrier.ReadOnly = false;
            this.cdvSourceCarrier.SearchSubItemIndex = 0;
            this.cdvSourceCarrier.SelectedDescIndex = -1;
            this.cdvSourceCarrier.SelectedSubItemIndex = -1;
            this.cdvSourceCarrier.SelectionStart = 0;
            this.cdvSourceCarrier.Size = new System.Drawing.Size(192, 20);
            this.cdvSourceCarrier.SmallImageList = null;
            this.cdvSourceCarrier.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSourceCarrier.TabIndex = 4;
            this.cdvSourceCarrier.TextBoxToolTipText = "";
            this.cdvSourceCarrier.TextBoxWidth = 192;
            this.cdvSourceCarrier.VisibleButton = true;
            this.cdvSourceCarrier.VisibleColumnHeader = false;
            this.cdvSourceCarrier.VisibleDescription = false;
            this.cdvSourceCarrier.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSourceCarrier_SelectedItemChanged);
            this.cdvSourceCarrier.ButtonPress += new System.EventHandler(this.cdvSourceCarrier_ButtonPress);
            this.cdvSourceCarrier.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvSourceCarrier_TextBoxKeyPress);
            this.cdvSourceCarrier.TextBoxTextChanged += new System.EventHandler(this.cdvSourceCarrier_TextBoxTextChanged);
            // 
            // grpExchange
            // 
            this.grpExchange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExchange.Controls.Add(this.btnReset);
            this.grpExchange.Controls.Add(this.btnReverse);
            this.grpExchange.Controls.Add(this.btnXF);
            this.grpExchange.Controls.Add(this.btnXC);
            this.grpExchange.Controls.Add(this.btnSF);
            this.grpExchange.Controls.Add(this.btnST);
            this.grpExchange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpExchange.Location = new System.Drawing.Point(3, 1);
            this.grpExchange.Name = "grpExchange";
            this.grpExchange.Size = new System.Drawing.Size(551, 37);
            this.grpExchange.TabIndex = 2;
            this.grpExchange.TabStop = false;
            this.grpExchange.Text = "Carrier Exchange Option";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(166, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(65, 24);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReverse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReverse.Location = new System.Drawing.Point(237, 10);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(65, 24);
            this.btnReverse.TabIndex = 1;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnXF
            // 
            this.btnXF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnXF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXF.Location = new System.Drawing.Point(494, 10);
            this.btnXF.Name = "btnXF";
            this.btnXF.Size = new System.Drawing.Size(50, 24);
            this.btnXF.TabIndex = 5;
            this.btnXF.Text = "XF";
            this.btnXF.Click += new System.EventHandler(this.btnXF_Click);
            // 
            // btnXC
            // 
            this.btnXC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnXC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXC.Location = new System.Drawing.Point(438, 10);
            this.btnXC.Name = "btnXC";
            this.btnXC.Size = new System.Drawing.Size(50, 24);
            this.btnXC.TabIndex = 4;
            this.btnXC.Text = "XC";
            this.btnXC.Click += new System.EventHandler(this.btnXC_Click);
            // 
            // btnSF
            // 
            this.btnSF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSF.BackColor = System.Drawing.SystemColors.Control;
            this.btnSF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSF.Location = new System.Drawing.Point(382, 10);
            this.btnSF.Name = "btnSF";
            this.btnSF.Size = new System.Drawing.Size(50, 24);
            this.btnSF.TabIndex = 3;
            this.btnSF.Text = "SF";
            this.btnSF.UseVisualStyleBackColor = false;
            this.btnSF.Click += new System.EventHandler(this.btnSF_Click);
            // 
            // btnST
            // 
            this.btnST.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnST.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnST.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnST.Location = new System.Drawing.Point(326, 10);
            this.btnST.Name = "btnST";
            this.btnST.Size = new System.Drawing.Size(50, 24);
            this.btnST.TabIndex = 2;
            this.btnST.Text = "ST";
            this.btnST.Click += new System.EventHandler(this.btnST_Click);
            // 
            // frmWIPTranChangePortCarrier
            // 
            this.ClientSize = new System.Drawing.Size(744, 650);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "frmWIPTranChangePortCarrier";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Port Status and Carrier";
            this.Activated += new System.EventHandler(this.frmWIPTranChangePortCarrier_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlChangePortStatus.ResumeLayout(false);
            this.grpPort.ResumeLayout(false);
            this.grpPort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTrsState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPortCarrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPortID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResID)).EndInit();
            this.pnlChangeCarrier.ResumeLayout(false);
            this.pnlCarrierMap.ResumeLayout(false);
            this.grpChangeCarrier.ResumeLayout(false);
            this.pnlMapTarget.ResumeLayout(false);
            this.pnlTargetCarrier.ResumeLayout(false);
            this.pnlTargetCarrier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetCarrier)).EndInit();
            this.pnlMapCenter.ResumeLayout(false);
            this.pnlMapSource.ResumeLayout(false);
            this.pnlSourceCarrier.ResumeLayout(false);
            this.pnlSourceCarrier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceCarrier)).EndInit();
            this.grpExchange.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChangeCarrier;
        private System.Windows.Forms.Panel pnlChangePortStatus;
        private System.Windows.Forms.Panel pnlCarrierMap;
        private System.Windows.Forms.GroupBox grpExchange;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnXF;
        private System.Windows.Forms.Button btnXC;
        private System.Windows.Forms.Button btnSF;
        private System.Windows.Forms.Button btnST;
        private System.Windows.Forms.GroupBox grpChangeCarrier;
        private System.Windows.Forms.GroupBox grpPort;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPortID;
        private System.Windows.Forms.Label lblPort;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubResID;
        private System.Windows.Forms.Label lblSubResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.TextBox txtResID;
        private System.Windows.Forms.TextBox txtLotDesc;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Panel pnlMapTarget;
        private Miracom.UI.Controls.MCListView.MCListView lisTarget;
        private System.Windows.Forms.ColumnHeader colSlot2;
        private System.Windows.Forms.ColumnHeader colSublot2;
        private System.Windows.Forms.ColumnHeader colLot2;
        private System.Windows.Forms.ColumnHeader colFromSlot;
        private System.Windows.Forms.Panel pnlTargetCarrier;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTargetType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTargetGroup;
        private System.Windows.Forms.Label lblTargetGroup;
        private System.Windows.Forms.Label lblTarget;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTargetCarrier;
        private System.Windows.Forms.Panel pnlMapCenter;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Panel pnlMapSource;
        private Miracom.UI.Controls.MCListView.MCListView lisSource;
        private System.Windows.Forms.ColumnHeader colSlot1;
        private System.Windows.Forms.ColumnHeader colSubLot1;
        private System.Windows.Forms.ColumnHeader colLot1;
        private System.Windows.Forms.ColumnHeader colToSlot;
        private System.Windows.Forms.Panel pnlSourceCarrier;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSourceType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSourceGroup;
        private System.Windows.Forms.Label lblSourceGroup;
        private System.Windows.Forms.Label lblSource;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSourceCarrier;
        private System.Windows.Forms.Label lblPortCarrier;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPortCarrier;
        private System.Windows.Forms.CheckBox chkUseTargetCarrier;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTrsState;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
    }
}
