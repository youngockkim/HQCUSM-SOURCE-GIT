namespace Miracom.RASCore
{
    partial class frmRASTranCarrierChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASTranCarrierChange));
            this.pnlCarrierMap = new System.Windows.Forms.Panel();
            this.pnlMapTarget = new System.Windows.Forms.Panel();
            this.lisTarget = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSlot2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSublot2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFromSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMapTargetTop = new System.Windows.Forms.Label();
            this.pnlMapCenter = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.pnlMapSource = new System.Windows.Forms.Panel();
            this.lisSource = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSlot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubLot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colToSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMapSourceTop = new System.Windows.Forms.Label();
            this.grpExchange = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnXF = new System.Windows.Forms.Button();
            this.btnXC = new System.Windows.Forms.Button();
            this.btnSF = new System.Windows.Forms.Button();
            this.btnST = new System.Windows.Forms.Button();
            this.pnlCarrier = new System.Windows.Forms.Panel();
            this.pnlTarget = new System.Windows.Forms.Panel();
            this.grpTarget = new System.Windows.Forms.GroupBox();
            this.cdvTargetType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvTargetGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTargetGroup = new System.Windows.Forms.Label();
            this.btnAttach = new System.Windows.Forms.Button();
            this.lblNPSublot = new System.Windows.Forms.Label();
            this.cdvNPSublot = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTarget = new System.Windows.Forms.Label();
            this.cdvTargetCarrier = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlSource = new System.Windows.Forms.Panel();
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.cdvSourceType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvSourceGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSourceGroup = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.cdvSourceCarrier = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlCrrList = new System.Windows.Forms.Panel();
            this.lisCrrList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCarrier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlCrrTotal = new System.Windows.Forms.Panel();
            this.txtCrrQty = new System.Windows.Forms.TextBox();
            this.txtCrrCount = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlLot = new System.Windows.Forms.Panel();
            this.lblSrcLotId = new System.Windows.Forms.Label();
            this.txtSrcLotID = new System.Windows.Forms.TextBox();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlCarrierMap.SuspendLayout();
            this.pnlMapTarget.SuspendLayout();
            this.pnlMapCenter.SuspendLayout();
            this.pnlMapSource.SuspendLayout();
            this.grpExchange.SuspendLayout();
            this.pnlCarrier.SuspendLayout();
            this.pnlTarget.SuspendLayout();
            this.grpTarget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvNPSublot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetCarrier)).BeginInit();
            this.pnlSource.SuspendLayout();
            this.grpSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceCarrier)).BeginInit();
            this.pnlCrrList.SuspendLayout();
            this.pnlCrrTotal.SuspendLayout();
            this.pnlLot.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(760, 7);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(851, 7);
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.grpExchange);
            this.pnlBottom.Location = new System.Drawing.Point(0, 562);
            this.pnlBottom.Size = new System.Drawing.Size(944, 40);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.grpExchange, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.txtSrcLotID);
            this.pnlCenter.Controls.Add(this.pnlCarrierMap);
            this.pnlCenter.Controls.Add(this.pnlCarrier);
            this.pnlCenter.Controls.Add(this.pnlCrrList);
            this.pnlCenter.Size = new System.Drawing.Size(944, 562);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // pnlCarrierMap
            // 
            this.pnlCarrierMap.Controls.Add(this.pnlMapTarget);
            this.pnlCarrierMap.Controls.Add(this.pnlMapCenter);
            this.pnlCarrierMap.Controls.Add(this.pnlMapSource);
            this.pnlCarrierMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCarrierMap.Location = new System.Drawing.Point(206, 94);
            this.pnlCarrierMap.Name = "pnlCarrierMap";
            this.pnlCarrierMap.Size = new System.Drawing.Size(738, 468);
            this.pnlCarrierMap.TabIndex = 2;
            this.pnlCarrierMap.Resize += new System.EventHandler(this.pnlCarrierMap_Resize);
            // 
            // pnlMapTarget
            // 
            this.pnlMapTarget.Controls.Add(this.lisTarget);
            this.pnlMapTarget.Controls.Add(this.lblMapTargetTop);
            this.pnlMapTarget.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMapTarget.Location = new System.Drawing.Point(404, 0);
            this.pnlMapTarget.Name = "pnlMapTarget";
            this.pnlMapTarget.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlMapTarget.Size = new System.Drawing.Size(334, 468);
            this.pnlMapTarget.TabIndex = 1;
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
            this.lisTarget.Location = new System.Drawing.Point(0, 14);
            this.lisTarget.Name = "lisTarget";
            this.lisTarget.Size = new System.Drawing.Size(331, 454);
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
            // lblMapTargetTop
            // 
            this.lblMapTargetTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMapTargetTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMapTargetTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapTargetTop.Location = new System.Drawing.Point(0, 0);
            this.lblMapTargetTop.Name = "lblMapTargetTop";
            this.lblMapTargetTop.Size = new System.Drawing.Size(331, 14);
            this.lblMapTargetTop.TabIndex = 0;
            this.lblMapTargetTop.Text = "Target Carrier Map";
            this.lblMapTargetTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMapCenter
            // 
            this.pnlMapCenter.Controls.Add(this.btnUp);
            this.pnlMapCenter.Controls.Add(this.btnDown);
            this.pnlMapCenter.Controls.Add(this.btnInsert);
            this.pnlMapCenter.Controls.Add(this.btnReject);
            this.pnlMapCenter.Location = new System.Drawing.Point(338, 24);
            this.pnlMapCenter.Name = "pnlMapCenter";
            this.pnlMapCenter.Size = new System.Drawing.Size(60, 401);
            this.pnlMapCenter.TabIndex = 1;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(34, 351);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 2;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(34, 375);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 3;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
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
            this.pnlMapSource.Controls.Add(this.lblMapSourceTop);
            this.pnlMapSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMapSource.Location = new System.Drawing.Point(0, 0);
            this.pnlMapSource.Name = "pnlMapSource";
            this.pnlMapSource.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlMapSource.Size = new System.Drawing.Size(332, 468);
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
            this.lisSource.Location = new System.Drawing.Point(3, 14);
            this.lisSource.Name = "lisSource";
            this.lisSource.Size = new System.Drawing.Size(329, 454);
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
            // lblMapSourceTop
            // 
            this.lblMapSourceTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMapSourceTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMapSourceTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapSourceTop.Location = new System.Drawing.Point(3, 0);
            this.lblMapSourceTop.Name = "lblMapSourceTop";
            this.lblMapSourceTop.Size = new System.Drawing.Size(329, 14);
            this.lblMapSourceTop.TabIndex = 0;
            this.lblMapSourceTop.Text = "Source Carrier Map";
            this.lblMapSourceTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.grpExchange.Size = new System.Drawing.Size(751, 37);
            this.grpExchange.TabIndex = 0;
            this.grpExchange.TabStop = false;
            this.grpExchange.Text = "Exchange Option";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(367, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(65, 24);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReverse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReverse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReverse.Location = new System.Drawing.Point(438, 10);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(65, 24);
            this.btnReverse.TabIndex = 1;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnXF
            // 
            this.btnXF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnXF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXF.Location = new System.Drawing.Point(695, 10);
            this.btnXF.Name = "btnXF";
            this.btnXF.Size = new System.Drawing.Size(50, 24);
            this.btnXF.TabIndex = 5;
            this.btnXF.Text = "XF";
            this.btnXF.Click += new System.EventHandler(this.btnXF_Click);
            // 
            // btnXC
            // 
            this.btnXC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnXC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXC.Location = new System.Drawing.Point(639, 10);
            this.btnXC.Name = "btnXC";
            this.btnXC.Size = new System.Drawing.Size(50, 24);
            this.btnXC.TabIndex = 4;
            this.btnXC.Text = "XC";
            this.btnXC.Click += new System.EventHandler(this.btnXC_Click);
            // 
            // btnSF
            // 
            this.btnSF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSF.Location = new System.Drawing.Point(583, 10);
            this.btnSF.Name = "btnSF";
            this.btnSF.Size = new System.Drawing.Size(50, 24);
            this.btnSF.TabIndex = 3;
            this.btnSF.Text = "SF";
            this.btnSF.Click += new System.EventHandler(this.btnSF_Click);
            // 
            // btnST
            // 
            this.btnST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnST.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnST.Location = new System.Drawing.Point(527, 10);
            this.btnST.Name = "btnST";
            this.btnST.Size = new System.Drawing.Size(50, 24);
            this.btnST.TabIndex = 2;
            this.btnST.Text = "ST";
            this.btnST.Click += new System.EventHandler(this.btnST_Click);
            // 
            // pnlCarrier
            // 
            this.pnlCarrier.Controls.Add(this.pnlTarget);
            this.pnlCarrier.Controls.Add(this.pnlSource);
            this.pnlCarrier.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCarrier.Location = new System.Drawing.Point(206, 0);
            this.pnlCarrier.Name = "pnlCarrier";
            this.pnlCarrier.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pnlCarrier.Size = new System.Drawing.Size(738, 94);
            this.pnlCarrier.TabIndex = 0;
            // 
            // pnlTarget
            // 
            this.pnlTarget.Controls.Add(this.grpTarget);
            this.pnlTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTarget.Location = new System.Drawing.Point(372, 0);
            this.pnlTarget.Name = "pnlTarget";
            this.pnlTarget.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlTarget.Size = new System.Drawing.Size(366, 90);
            this.pnlTarget.TabIndex = 2;
            // 
            // grpTarget
            // 
            this.grpTarget.Controls.Add(this.cdvTargetType);
            this.grpTarget.Controls.Add(this.cdvTargetGroup);
            this.grpTarget.Controls.Add(this.lblTargetGroup);
            this.grpTarget.Controls.Add(this.btnAttach);
            this.grpTarget.Controls.Add(this.lblNPSublot);
            this.grpTarget.Controls.Add(this.cdvNPSublot);
            this.grpTarget.Controls.Add(this.lblTarget);
            this.grpTarget.Controls.Add(this.cdvTargetCarrier);
            this.grpTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTarget.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTarget.Location = new System.Drawing.Point(0, 0);
            this.grpTarget.Name = "grpTarget";
            this.grpTarget.Size = new System.Drawing.Size(363, 90);
            this.grpTarget.TabIndex = 0;
            this.grpTarget.TabStop = false;
            this.grpTarget.Text = "Target Carrier Information";
            // 
            // cdvTargetType
            // 
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
            this.cdvTargetType.Location = new System.Drawing.Point(243, 39);
            this.cdvTargetType.MaxLength = 20;
            this.cdvTargetType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTargetType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTargetType.Name = "cdvTargetType";
            this.cdvTargetType.ReadOnly = true;
            this.cdvTargetType.SearchSubItemIndex = 0;
            this.cdvTargetType.SelectedDescIndex = -1;
            this.cdvTargetType.SelectedSubItemIndex = -1;
            this.cdvTargetType.SelectionStart = 0;
            this.cdvTargetType.Size = new System.Drawing.Size(114, 20);
            this.cdvTargetType.SmallImageList = null;
            this.cdvTargetType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTargetType.TabIndex = 5;
            this.cdvTargetType.TextBoxToolTipText = "";
            this.cdvTargetType.TextBoxWidth = 114;
            this.cdvTargetType.VisibleButton = true;
            this.cdvTargetType.VisibleColumnHeader = false;
            this.cdvTargetType.VisibleDescription = false;
            this.cdvTargetType.ButtonPress += new System.EventHandler(this.cdvTargetType_ButtonPress);
            // 
            // cdvTargetGroup
            // 
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
            this.cdvTargetGroup.Location = new System.Drawing.Point(126, 39);
            this.cdvTargetGroup.MaxLength = 20;
            this.cdvTargetGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTargetGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTargetGroup.Name = "cdvTargetGroup";
            this.cdvTargetGroup.ReadOnly = true;
            this.cdvTargetGroup.SearchSubItemIndex = 0;
            this.cdvTargetGroup.SelectedDescIndex = -1;
            this.cdvTargetGroup.SelectedSubItemIndex = -1;
            this.cdvTargetGroup.SelectionStart = 0;
            this.cdvTargetGroup.Size = new System.Drawing.Size(114, 20);
            this.cdvTargetGroup.SmallImageList = null;
            this.cdvTargetGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTargetGroup.TabIndex = 4;
            this.cdvTargetGroup.TextBoxToolTipText = "";
            this.cdvTargetGroup.TextBoxWidth = 114;
            this.cdvTargetGroup.VisibleButton = true;
            this.cdvTargetGroup.VisibleColumnHeader = false;
            this.cdvTargetGroup.VisibleDescription = false;
            this.cdvTargetGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvTargetGroup_SelectedItemChanged);
            this.cdvTargetGroup.ButtonPress += new System.EventHandler(this.cdvTargetGroup_ButtonPress);
            // 
            // lblTargetGroup
            // 
            this.lblTargetGroup.AutoSize = true;
            this.lblTargetGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTargetGroup.Location = new System.Drawing.Point(9, 43);
            this.lblTargetGroup.Name = "lblTargetGroup";
            this.lblTargetGroup.Size = new System.Drawing.Size(101, 13);
            this.lblTargetGroup.TabIndex = 3;
            this.lblTargetGroup.Text = "Carrier Group/ Type";
            // 
            // btnAttach
            // 
            this.btnAttach.Image = ((System.Drawing.Image)(resources.GetObject("btnAttach.Image")));
            this.btnAttach.Location = new System.Drawing.Point(308, 15);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(49, 20);
            this.btnAttach.TabIndex = 2;
            this.btnAttach.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNPSublot
            // 
            this.lblNPSublot.AutoSize = true;
            this.lblNPSublot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNPSublot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNPSublot.Location = new System.Drawing.Point(9, 18);
            this.lblNPSublot.Name = "lblNPSublot";
            this.lblNPSublot.Size = new System.Drawing.Size(73, 13);
            this.lblNPSublot.TabIndex = 0;
            this.lblNPSublot.Text = "NP SubLot ID";
            // 
            // cdvNPSublot
            // 
            this.cdvNPSublot.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvNPSublot.BorderHotColor = System.Drawing.Color.Black;
            this.cdvNPSublot.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvNPSublot.BtnToolTipText = "";
            this.cdvNPSublot.DescText = "";
            this.cdvNPSublot.DisplaySubItemIndex = -1;
            this.cdvNPSublot.DisplayText = "";
            this.cdvNPSublot.Focusing = null;
            this.cdvNPSublot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvNPSublot.Index = 0;
            this.cdvNPSublot.IsViewBtnImage = false;
            this.cdvNPSublot.Location = new System.Drawing.Point(126, 15);
            this.cdvNPSublot.MaxLength = 20;
            this.cdvNPSublot.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvNPSublot.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvNPSublot.Name = "cdvNPSublot";
            this.cdvNPSublot.ReadOnly = true;
            this.cdvNPSublot.SearchSubItemIndex = 0;
            this.cdvNPSublot.SelectedDescIndex = -1;
            this.cdvNPSublot.SelectedSubItemIndex = -1;
            this.cdvNPSublot.SelectionStart = 0;
            this.cdvNPSublot.Size = new System.Drawing.Size(177, 20);
            this.cdvNPSublot.SmallImageList = null;
            this.cdvNPSublot.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvNPSublot.TabIndex = 1;
            this.cdvNPSublot.TextBoxToolTipText = "";
            this.cdvNPSublot.TextBoxWidth = 177;
            this.cdvNPSublot.VisibleButton = true;
            this.cdvNPSublot.VisibleColumnHeader = false;
            this.cdvNPSublot.VisibleDescription = false;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(9, 67);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(61, 13);
            this.lblTarget.TabIndex = 6;
            this.lblTarget.Text = "Carrier ID";
            // 
            // cdvTargetCarrier
            // 
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
            this.cdvTargetCarrier.Location = new System.Drawing.Point(126, 63);
            this.cdvTargetCarrier.MaxLength = 20;
            this.cdvTargetCarrier.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTargetCarrier.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTargetCarrier.Name = "cdvTargetCarrier";
            this.cdvTargetCarrier.ReadOnly = false;
            this.cdvTargetCarrier.SearchSubItemIndex = 0;
            this.cdvTargetCarrier.SelectedDescIndex = -1;
            this.cdvTargetCarrier.SelectedSubItemIndex = -1;
            this.cdvTargetCarrier.SelectionStart = 0;
            this.cdvTargetCarrier.Size = new System.Drawing.Size(231, 20);
            this.cdvTargetCarrier.SmallImageList = null;
            this.cdvTargetCarrier.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTargetCarrier.TabIndex = 7;
            this.cdvTargetCarrier.TextBoxToolTipText = "";
            this.cdvTargetCarrier.TextBoxWidth = 231;
            this.cdvTargetCarrier.VisibleButton = true;
            this.cdvTargetCarrier.VisibleColumnHeader = false;
            this.cdvTargetCarrier.VisibleDescription = false;
            this.cdvTargetCarrier.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvTargetCarrier_SelectedItemChanged);
            this.cdvTargetCarrier.ButtonPress += new System.EventHandler(this.cdvTargetCarrier_ButtonPress);
            this.cdvTargetCarrier.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvTargetCarrier_TextBoxKeyPress);
            // 
            // pnlSource
            // 
            this.pnlSource.Controls.Add(this.grpSource);
            this.pnlSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSource.Location = new System.Drawing.Point(0, 0);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.Padding = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.pnlSource.Size = new System.Drawing.Size(372, 90);
            this.pnlSource.TabIndex = 1;
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.txtLotID);
            this.grpSource.Controls.Add(this.lblLotID);
            this.grpSource.Controls.Add(this.cdvSourceType);
            this.grpSource.Controls.Add(this.cdvSourceGroup);
            this.grpSource.Controls.Add(this.lblSourceGroup);
            this.grpSource.Controls.Add(this.lblSource);
            this.grpSource.Controls.Add(this.cdvSourceCarrier);
            this.grpSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSource.Location = new System.Drawing.Point(3, 0);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(363, 90);
            this.grpSource.TabIndex = 0;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source Carrier Information";
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(126, 15);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(231, 20);
            this.txtLotID.TabIndex = 1;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotID.Location = new System.Drawing.Point(9, 18);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // cdvSourceType
            // 
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
            this.cdvSourceType.Location = new System.Drawing.Point(243, 39);
            this.cdvSourceType.MaxLength = 20;
            this.cdvSourceType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSourceType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSourceType.Name = "cdvSourceType";
            this.cdvSourceType.ReadOnly = true;
            this.cdvSourceType.SearchSubItemIndex = 0;
            this.cdvSourceType.SelectedDescIndex = -1;
            this.cdvSourceType.SelectedSubItemIndex = -1;
            this.cdvSourceType.SelectionStart = 0;
            this.cdvSourceType.Size = new System.Drawing.Size(114, 20);
            this.cdvSourceType.SmallImageList = null;
            this.cdvSourceType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSourceType.TabIndex = 4;
            this.cdvSourceType.TextBoxToolTipText = "";
            this.cdvSourceType.TextBoxWidth = 114;
            this.cdvSourceType.VisibleButton = true;
            this.cdvSourceType.VisibleColumnHeader = false;
            this.cdvSourceType.VisibleDescription = false;
            this.cdvSourceType.ButtonPress += new System.EventHandler(this.cdvSourceType_ButtonPress);
            // 
            // cdvSourceGroup
            // 
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
            this.cdvSourceGroup.Location = new System.Drawing.Point(126, 39);
            this.cdvSourceGroup.MaxLength = 20;
            this.cdvSourceGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSourceGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSourceGroup.Name = "cdvSourceGroup";
            this.cdvSourceGroup.ReadOnly = true;
            this.cdvSourceGroup.SearchSubItemIndex = 0;
            this.cdvSourceGroup.SelectedDescIndex = -1;
            this.cdvSourceGroup.SelectedSubItemIndex = -1;
            this.cdvSourceGroup.SelectionStart = 0;
            this.cdvSourceGroup.Size = new System.Drawing.Size(114, 20);
            this.cdvSourceGroup.SmallImageList = null;
            this.cdvSourceGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSourceGroup.TabIndex = 3;
            this.cdvSourceGroup.TextBoxToolTipText = "";
            this.cdvSourceGroup.TextBoxWidth = 114;
            this.cdvSourceGroup.VisibleButton = true;
            this.cdvSourceGroup.VisibleColumnHeader = false;
            this.cdvSourceGroup.VisibleDescription = false;
            this.cdvSourceGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSourceGroup_SelectedItemChanged);
            this.cdvSourceGroup.ButtonPress += new System.EventHandler(this.cdvSourceGroup_ButtonPress);
            // 
            // lblSourceGroup
            // 
            this.lblSourceGroup.AutoSize = true;
            this.lblSourceGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSourceGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSourceGroup.Location = new System.Drawing.Point(9, 43);
            this.lblSourceGroup.Name = "lblSourceGroup";
            this.lblSourceGroup.Size = new System.Drawing.Size(101, 13);
            this.lblSourceGroup.TabIndex = 2;
            this.lblSourceGroup.Text = "Carrier Group/ Type";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(9, 67);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(61, 13);
            this.lblSource.TabIndex = 5;
            this.lblSource.Text = "Carrier ID";
            // 
            // cdvSourceCarrier
            // 
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
            this.cdvSourceCarrier.Location = new System.Drawing.Point(126, 63);
            this.cdvSourceCarrier.MaxLength = 20;
            this.cdvSourceCarrier.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSourceCarrier.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSourceCarrier.Name = "cdvSourceCarrier";
            this.cdvSourceCarrier.ReadOnly = false;
            this.cdvSourceCarrier.SearchSubItemIndex = 0;
            this.cdvSourceCarrier.SelectedDescIndex = -1;
            this.cdvSourceCarrier.SelectedSubItemIndex = -1;
            this.cdvSourceCarrier.SelectionStart = 0;
            this.cdvSourceCarrier.Size = new System.Drawing.Size(231, 20);
            this.cdvSourceCarrier.SmallImageList = null;
            this.cdvSourceCarrier.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSourceCarrier.TabIndex = 6;
            this.cdvSourceCarrier.TextBoxToolTipText = "";
            this.cdvSourceCarrier.TextBoxWidth = 231;
            this.cdvSourceCarrier.VisibleButton = true;
            this.cdvSourceCarrier.VisibleColumnHeader = false;
            this.cdvSourceCarrier.VisibleDescription = false;
            this.cdvSourceCarrier.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSourceCarrier_SelectedItemChanged);
            this.cdvSourceCarrier.ButtonPress += new System.EventHandler(this.cdvSourceCarrier_ButtonPress);
            this.cdvSourceCarrier.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvSourceCarrier_TextBoxKeyPress);
            // 
            // pnlCrrList
            // 
            this.pnlCrrList.Controls.Add(this.lisCrrList);
            this.pnlCrrList.Controls.Add(this.pnlCrrTotal);
            this.pnlCrrList.Controls.Add(this.pnlLot);
            this.pnlCrrList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCrrList.Location = new System.Drawing.Point(0, 0);
            this.pnlCrrList.Name = "pnlCrrList";
            this.pnlCrrList.Size = new System.Drawing.Size(206, 562);
            this.pnlCrrList.TabIndex = 0;
            // 
            // lisCrrList
            // 
            this.lisCrrList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colCarrier,
            this.colQty});
            this.lisCrrList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCrrList.EnableSort = true;
            this.lisCrrList.EnableSortIcon = true;
            this.lisCrrList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCrrList.FullRowSelect = true;
            this.lisCrrList.Location = new System.Drawing.Point(0, 30);
            this.lisCrrList.Name = "lisCrrList";
            this.lisCrrList.Size = new System.Drawing.Size(206, 508);
            this.lisCrrList.TabIndex = 1;
            this.lisCrrList.UseCompatibleStateImageBehavior = false;
            this.lisCrrList.View = System.Windows.Forms.View.Details;
            this.lisCrrList.SelectedIndexChanged += new System.EventHandler(this.lisCrrList_SelectedIndexChanged);
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 40;
            // 
            // colCarrier
            // 
            this.colCarrier.Text = "Carrier";
            this.colCarrier.Width = 80;
            // 
            // colQty
            // 
            this.colQty.Text = "Qty";
            this.colQty.Width = 50;
            // 
            // pnlCrrTotal
            // 
            this.pnlCrrTotal.Controls.Add(this.txtCrrQty);
            this.pnlCrrTotal.Controls.Add(this.txtCrrCount);
            this.pnlCrrTotal.Controls.Add(this.lblTotal);
            this.pnlCrrTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCrrTotal.Location = new System.Drawing.Point(0, 538);
            this.pnlCrrTotal.Name = "pnlCrrTotal";
            this.pnlCrrTotal.Size = new System.Drawing.Size(206, 24);
            this.pnlCrrTotal.TabIndex = 2;
            // 
            // txtCrrQty
            // 
            this.txtCrrQty.Location = new System.Drawing.Point(130, 4);
            this.txtCrrQty.MaxLength = 25;
            this.txtCrrQty.Name = "txtCrrQty";
            this.txtCrrQty.ReadOnly = true;
            this.txtCrrQty.Size = new System.Drawing.Size(70, 20);
            this.txtCrrQty.TabIndex = 3;
            this.txtCrrQty.TabStop = false;
            // 
            // txtCrrCount
            // 
            this.txtCrrCount.Location = new System.Drawing.Point(74, 4);
            this.txtCrrCount.MaxLength = 25;
            this.txtCrrCount.Name = "txtCrrCount";
            this.txtCrrCount.ReadOnly = true;
            this.txtCrrCount.Size = new System.Drawing.Size(50, 20);
            this.txtCrrCount.TabIndex = 2;
            this.txtCrrCount.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTotal.Location = new System.Drawing.Point(8, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total";
            // 
            // pnlLot
            // 
            this.pnlLot.Controls.Add(this.lblSrcLotId);
            this.pnlLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLot.Location = new System.Drawing.Point(0, 0);
            this.pnlLot.Name = "pnlLot";
            this.pnlLot.Size = new System.Drawing.Size(206, 30);
            this.pnlLot.TabIndex = 0;
            // 
            // lblSrcLotId
            // 
            this.lblSrcLotId.AutoSize = true;
            this.lblSrcLotId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSrcLotId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrcLotId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSrcLotId.Location = new System.Drawing.Point(8, 9);
            this.lblSrcLotId.Name = "lblSrcLotId";
            this.lblSrcLotId.Size = new System.Drawing.Size(36, 13);
            this.lblSrcLotId.TabIndex = 0;
            this.lblSrcLotId.Text = "Lot ID";
            // 
            // txtSrcLotID
            // 
            this.txtSrcLotID.Location = new System.Drawing.Point(60, 5);
            this.txtSrcLotID.MaxLength = 25;
            this.txtSrcLotID.Name = "txtSrcLotID";
            this.txtSrcLotID.Size = new System.Drawing.Size(140, 20);
            this.txtSrcLotID.TabIndex = 0;
            this.txtSrcLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSrcLotID_KeyPress);
            // 
            // frmRASTranCarrierChange
            // 
            this.ClientSize = new System.Drawing.Size(944, 602);
            this.Name = "frmRASTranCarrierChange";
            this.Text = "Carrier Change";
            this.Activated += new System.EventHandler(this.frmRASTranCarrierChange_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlCenter.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlCarrierMap.ResumeLayout(false);
            this.pnlMapTarget.ResumeLayout(false);
            this.pnlMapCenter.ResumeLayout(false);
            this.pnlMapSource.ResumeLayout(false);
            this.grpExchange.ResumeLayout(false);
            this.pnlCarrier.ResumeLayout(false);
            this.pnlTarget.ResumeLayout(false);
            this.grpTarget.ResumeLayout(false);
            this.grpTarget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvNPSublot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetCarrier)).EndInit();
            this.pnlSource.ResumeLayout(false);
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSourceCarrier)).EndInit();
            this.pnlCrrList.ResumeLayout(false);
            this.pnlCrrTotal.ResumeLayout(false);
            this.pnlCrrTotal.PerformLayout();
            this.pnlLot.ResumeLayout(false);
            this.pnlLot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCarrierMap;
        private System.Windows.Forms.Panel pnlMapSource;
        private Miracom.UI.Controls.MCListView.MCListView lisSource;
        private System.Windows.Forms.ColumnHeader colSlot1;
        private System.Windows.Forms.ColumnHeader colSubLot1;
        private System.Windows.Forms.ColumnHeader colLot1;
        private System.Windows.Forms.Panel pnlMapCenter;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Panel pnlMapTarget;
        private Miracom.UI.Controls.MCListView.MCListView lisTarget;
        private System.Windows.Forms.ColumnHeader colSlot2;
        private System.Windows.Forms.ColumnHeader colSublot2;
        private System.Windows.Forms.ColumnHeader colLot2;
        private System.Windows.Forms.Label lblMapTargetTop;
        private System.Windows.Forms.Label lblMapSourceTop;
        private System.Windows.Forms.GroupBox grpExchange;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnXF;
        private System.Windows.Forms.Button btnXC;
        private System.Windows.Forms.Button btnSF;
        private System.Windows.Forms.Button btnST;
        private System.Windows.Forms.Panel pnlCarrier;
        private System.Windows.Forms.Panel pnlTarget;
        private System.Windows.Forms.GroupBox grpTarget;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Label lblNPSublot;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvNPSublot;
        private System.Windows.Forms.Label lblTarget;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTargetCarrier;
        private System.Windows.Forms.Panel pnlSource;
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.Label lblSource;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSourceCarrier;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSourceType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSourceGroup;
        private System.Windows.Forms.Label lblSourceGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTargetType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTargetGroup;
        private System.Windows.Forms.Label lblTargetGroup;
        private System.Windows.Forms.ColumnHeader colFromSlot;
        private System.Windows.Forms.ColumnHeader colToSlot;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.TextBox txtSrcLotID;
        private System.Windows.Forms.Panel pnlCrrList;
        private Miracom.UI.Controls.MCListView.MCListView lisCrrList;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colCarrier;
        private System.Windows.Forms.ColumnHeader colQty;
        private System.Windows.Forms.Panel pnlLot;
        private System.Windows.Forms.Label lblSrcLotId;
        private System.Windows.Forms.Panel pnlCrrTotal;
        private System.Windows.Forms.TextBox txtCrrQty;
        private System.Windows.Forms.TextBox txtCrrCount;
        private System.Windows.Forms.Label lblTotal;
    }
}
