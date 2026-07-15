namespace Miracom.OUISample
{
    partial class frmWorkStartNEnd
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
            this.splMiddle = new System.Windows.Forms.Splitter();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cdvRes = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResource = new System.Windows.Forms.Label();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.pnlLotCount = new System.Windows.Forms.Panel();
            this.lblLotQty = new System.Windows.Forms.Label();
            this.lblLotCount = new System.Windows.Forms.Label();
            this.udcLotList = new Miracom.MESCore.Controls.udcLotList();
            this.pnlTransaction = new System.Windows.Forms.Panel();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnSplitLot = new System.Windows.Forms.Button();
            this.btnHoldLot = new System.Windows.Forms.Button();
            this.btnEndLot = new System.Windows.Forms.Button();
            this.btnStartLot = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.grpLotStatus = new System.Windows.Forms.GroupBox();
            this.udcLotInfor = new Miracom.MESCore.Controls.udcFlexibleScreen();
            this.splRight = new System.Windows.Forms.Splitter();
            this.pnlInValue = new System.Windows.Forms.Panel();
            this.grpInputValue = new System.Windows.Forms.GroupBox();
            this.lblInValue01 = new System.Windows.Forms.Label();
            this.lblInValue05 = new System.Windows.Forms.Label();
            this.cdvInValue05 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInValue04 = new System.Windows.Forms.Label();
            this.cdvInValue04 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInValue03 = new System.Windows.Forms.Label();
            this.cdvInValue03 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInValue02 = new System.Windows.Forms.Label();
            this.cdvInValue02 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvInValue01 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            this.pnlLotCount.SuspendLayout();
            this.pnlTransaction.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.grpLotStatus.SuspendLayout();
            this.pnlInValue.SuspendLayout();
            this.grpInputValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue01)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlStatus);
            this.pnlBottom.Controls.Add(this.pnlTransaction);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 312);
            this.pnlBottom.Size = new System.Drawing.Size(784, 250);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.udcLotList);
            this.pnlCenter.Controls.Add(this.pnlLotCount);
            this.pnlCenter.Controls.Add(this.pnlFilter);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCenter.Size = new System.Drawing.Size(784, 307);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "BaseForm03";
            // 
            // splMiddle
            // 
            this.splMiddle.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.splMiddle.Location = new System.Drawing.Point(0, 307);
            this.splMiddle.Name = "splMiddle";
            this.splMiddle.Size = new System.Drawing.Size(784, 5);
            this.splMiddle.TabIndex = 0;
            this.splMiddle.TabStop = false;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFilter.Controls.Add(this.grpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(6);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(784, 56);
            this.pnlFilter.TabIndex = 0;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnRefresh);
            this.grpFilter.Controls.Add(this.cdvRes);
            this.grpFilter.Controls.Add(this.lblResource);
            this.grpFilter.Controls.Add(this.cdvOper);
            this.grpFilter.Controls.Add(this.lblOperation);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.ForeColor = System.Drawing.Color.MediumBlue;
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(784, 56);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnRefresh.Image = global::Miracom.OUISample.Properties.Resources._7_4_1_Reload;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(678, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 36);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cdvRes
            // 
            this.cdvRes.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRes.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRes.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRes.BtnToolTipText = "";
            this.cdvRes.ButtonWidth = 31;
            this.cdvRes.DescText = "";
            this.cdvRes.DisplaySubItemIndex = -1;
            this.cdvRes.DisplayText = "";
            this.cdvRes.Focusing = null;
            this.cdvRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRes.Index = 0;
            this.cdvRes.IsViewBtnImage = false;
            this.cdvRes.Location = new System.Drawing.Point(430, 16);
            this.cdvRes.MaxLength = 20;
            this.cdvRes.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRes.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRes.Name = "cdvRes";
            this.cdvRes.ReadOnly = false;
            this.cdvRes.SameWidthHeightOfButton = true;
            this.cdvRes.SearchSubItemIndex = 0;
            this.cdvRes.SelectedDescIndex = -1;
            this.cdvRes.SelectedSubItemIndex = -1;
            this.cdvRes.SelectionStart = 0;
            this.cdvRes.Size = new System.Drawing.Size(170, 31);
            this.cdvRes.SmallImageList = null;
            this.cdvRes.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRes.TabIndex = 3;
            this.cdvRes.TextBoxToolTipText = "";
            this.cdvRes.TextBoxWidth = 170;
            this.cdvRes.VisibleButton = true;
            this.cdvRes.VisibleColumnHeader = false;
            this.cdvRes.VisibleDescription = false;
            this.cdvRes.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRes_SelectedItemChanged);
            this.cdvRes.ButtonPress += new System.EventHandler(this.cdvRes_ButtonPress);
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResource.Location = new System.Drawing.Point(331, 20);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(92, 24);
            this.lblResource.TabIndex = 2;
            this.lblResource.Text = "Resource";
            // 
            // cdvOper
            // 
            this.cdvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOper.BtnToolTipText = "";
            this.cdvOper.ButtonWidth = 31;
            this.cdvOper.DescText = "";
            this.cdvOper.DisplaySubItemIndex = -1;
            this.cdvOper.DisplayText = "";
            this.cdvOper.Focusing = null;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.Index = 0;
            this.cdvOper.IsViewBtnImage = false;
            this.cdvOper.Location = new System.Drawing.Point(120, 16);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SameWidthHeightOfButton = true;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(170, 31);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 1;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 170;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOperation.Location = new System.Drawing.Point(12, 20);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(102, 24);
            this.lblOperation.TabIndex = 0;
            this.lblOperation.Text = "Operation";
            // 
            // pnlLotCount
            // 
            this.pnlLotCount.Controls.Add(this.lblLotQty);
            this.pnlLotCount.Controls.Add(this.lblLotCount);
            this.pnlLotCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLotCount.Location = new System.Drawing.Point(0, 285);
            this.pnlLotCount.Name = "pnlLotCount";
            this.pnlLotCount.Size = new System.Drawing.Size(784, 22);
            this.pnlLotCount.TabIndex = 2;
            // 
            // lblLotQty
            // 
            this.lblLotQty.AutoSize = true;
            this.lblLotQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotQty.Location = new System.Drawing.Point(347, 3);
            this.lblLotQty.Name = "lblLotQty";
            this.lblLotQty.Size = new System.Drawing.Size(77, 16);
            this.lblLotQty.TabIndex = 1;
            this.lblLotQty.Text = "Lot Quantity";
            // 
            // lblLotCount
            // 
            this.lblLotCount.AutoSize = true;
            this.lblLotCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotCount.Location = new System.Drawing.Point(12, 3);
            this.lblLotCount.Name = "lblLotCount";
            this.lblLotCount.Size = new System.Drawing.Size(63, 16);
            this.lblLotCount.TabIndex = 0;
            this.lblLotCount.Text = "Lot Count";
            // 
            // udcLotList
            // 
            this.udcLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcLotList.Icons = null;
            this.udcLotList.Location = new System.Drawing.Point(0, 56);
            this.udcLotList.Margin = new System.Windows.Forms.Padding(11);
            this.udcLotList.ModuleName = "WIP";
            this.udcLotList.Name = "udcLotList";
            this.udcLotList.ParentPath = "LIST";
            this.udcLotList.ServiceName = "WIP_View_Lot_List_Detail_By_SQL_Query";
            this.udcLotList.Size = new System.Drawing.Size(784, 229);
            this.udcLotList.TabIndex = 1;
            this.udcLotList.TabStop = false;
            this.udcLotList.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.udcLotList_SelectionChanged);
            // 
            // pnlTransaction
            // 
            this.pnlTransaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTransaction.Controls.Add(this.btnProcess);
            this.pnlTransaction.Controls.Add(this.btnSplitLot);
            this.pnlTransaction.Controls.Add(this.btnHoldLot);
            this.pnlTransaction.Controls.Add(this.btnEndLot);
            this.pnlTransaction.Controls.Add(this.btnStartLot);
            this.pnlTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTransaction.Location = new System.Drawing.Point(0, 0);
            this.pnlTransaction.Name = "pnlTransaction";
            this.pnlTransaction.Size = new System.Drawing.Size(784, 50);
            this.pnlTransaction.TabIndex = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnProcess.Image = global::Miracom.OUISample.Properties.Resources._2_8_3_ApprovalandReleaseRecipeVersion;
            this.btnProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcess.Location = new System.Drawing.Point(657, 4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(120, 40);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnSplitLot
            // 
            this.btnSplitLot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSplitLot.Image = global::Miracom.OUISample.Properties.Resources._15_Split_Lot;
            this.btnSplitLot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSplitLot.Location = new System.Drawing.Point(307, 4);
            this.btnSplitLot.Name = "btnSplitLot";
            this.btnSplitLot.Size = new System.Drawing.Size(91, 40);
            this.btnSplitLot.TabIndex = 3;
            this.btnSplitLot.Text = "Split";
            this.btnSplitLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSplitLot.UseVisualStyleBackColor = true;
            this.btnSplitLot.Click += new System.EventHandler(this.btnSplitLot_Click);
            // 
            // btnHoldLot
            // 
            this.btnHoldLot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHoldLot.Image = global::Miracom.OUISample.Properties.Resources._19_Hold_Lot;
            this.btnHoldLot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoldLot.Location = new System.Drawing.Point(210, 4);
            this.btnHoldLot.Name = "btnHoldLot";
            this.btnHoldLot.Size = new System.Drawing.Size(91, 40);
            this.btnHoldLot.TabIndex = 2;
            this.btnHoldLot.Text = "Hold";
            this.btnHoldLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHoldLot.UseVisualStyleBackColor = true;
            this.btnHoldLot.Click += new System.EventHandler(this.btnHoldLot_Click);
            // 
            // btnEndLot
            // 
            this.btnEndLot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEndLot.Image = global::Miracom.OUISample.Properties.Resources._11_End_Lot;
            this.btnEndLot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEndLot.Location = new System.Drawing.Point(113, 4);
            this.btnEndLot.Name = "btnEndLot";
            this.btnEndLot.Size = new System.Drawing.Size(91, 40);
            this.btnEndLot.TabIndex = 1;
            this.btnEndLot.Text = "End";
            this.btnEndLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEndLot.UseVisualStyleBackColor = true;
            this.btnEndLot.Click += new System.EventHandler(this.btnEndLot_Click);
            // 
            // btnStartLot
            // 
            this.btnStartLot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStartLot.Image = global::Miracom.OUISample.Properties.Resources._9_Start_Lot;
            this.btnStartLot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartLot.Location = new System.Drawing.Point(16, 4);
            this.btnStartLot.Name = "btnStartLot";
            this.btnStartLot.Size = new System.Drawing.Size(91, 40);
            this.btnStartLot.TabIndex = 0;
            this.btnStartLot.Text = "Start";
            this.btnStartLot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartLot.UseVisualStyleBackColor = true;
            this.btnStartLot.Click += new System.EventHandler(this.btnStartLot_Click);
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.grpLotStatus);
            this.pnlStatus.Controls.Add(this.splRight);
            this.pnlStatus.Controls.Add(this.pnlInValue);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatus.Location = new System.Drawing.Point(0, 50);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(784, 200);
            this.pnlStatus.TabIndex = 0;
            // 
            // grpLotStatus
            // 
            this.grpLotStatus.Controls.Add(this.udcLotInfor);
            this.grpLotStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLotStatus.ForeColor = System.Drawing.Color.MediumBlue;
            this.grpLotStatus.Location = new System.Drawing.Point(0, 0);
            this.grpLotStatus.Name = "grpLotStatus";
            this.grpLotStatus.Size = new System.Drawing.Size(529, 200);
            this.grpLotStatus.TabIndex = 0;
            this.grpLotStatus.TabStop = false;
            this.grpLotStatus.Text = "Lot Status";
            // 
            // udcLotInfor
            // 
            this.udcLotInfor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcLotInfor.Location = new System.Drawing.Point(3, 18);
            this.udcLotInfor.Margin = new System.Windows.Forms.Padding(4);
            this.udcLotInfor.Name = "udcLotInfor";
            this.udcLotInfor.ScreenAutoStretch = false;
            this.udcLotInfor.ScreenID = null;
            this.udcLotInfor.ScreenLock = false;
            this.udcLotInfor.ScreenLockBackColor = System.Drawing.Color.Empty;
            this.udcLotInfor.Size = new System.Drawing.Size(523, 179);
            this.udcLotInfor.TabIndex = 0;
            // 
            // splRight
            // 
            this.splRight.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splRight.Location = new System.Drawing.Point(529, 0);
            this.splRight.Name = "splRight";
            this.splRight.Size = new System.Drawing.Size(5, 200);
            this.splRight.TabIndex = 1;
            this.splRight.TabStop = false;
            // 
            // pnlInValue
            // 
            this.pnlInValue.Controls.Add(this.grpInputValue);
            this.pnlInValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlInValue.Location = new System.Drawing.Point(534, 0);
            this.pnlInValue.Name = "pnlInValue";
            this.pnlInValue.Size = new System.Drawing.Size(250, 200);
            this.pnlInValue.TabIndex = 0;
            // 
            // grpInputValue
            // 
            this.grpInputValue.Controls.Add(this.lblInValue01);
            this.grpInputValue.Controls.Add(this.lblInValue05);
            this.grpInputValue.Controls.Add(this.cdvInValue05);
            this.grpInputValue.Controls.Add(this.lblInValue04);
            this.grpInputValue.Controls.Add(this.cdvInValue04);
            this.grpInputValue.Controls.Add(this.lblInValue03);
            this.grpInputValue.Controls.Add(this.cdvInValue03);
            this.grpInputValue.Controls.Add(this.lblInValue02);
            this.grpInputValue.Controls.Add(this.cdvInValue02);
            this.grpInputValue.Controls.Add(this.cdvInValue01);
            this.grpInputValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInputValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInputValue.ForeColor = System.Drawing.Color.MediumBlue;
            this.grpInputValue.Location = new System.Drawing.Point(0, 0);
            this.grpInputValue.Name = "grpInputValue";
            this.grpInputValue.Size = new System.Drawing.Size(250, 200);
            this.grpInputValue.TabIndex = 0;
            this.grpInputValue.TabStop = false;
            this.grpInputValue.Text = "Input Value";
            // 
            // lblInValue01
            // 
            this.lblInValue01.AutoSize = true;
            this.lblInValue01.BackColor = System.Drawing.SystemColors.Window;
            this.lblInValue01.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInValue01.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblInValue01.Location = new System.Drawing.Point(10, 21);
            this.lblInValue01.Name = "lblInValue01";
            this.lblInValue01.Size = new System.Drawing.Size(130, 24);
            this.lblInValue01.TabIndex = 0;
            this.lblInValue01.Text = "Input Value 01";
            this.lblInValue01.Click += new System.EventHandler(this.lblInValue_Click);
            // 
            // lblInValue05
            // 
            this.lblInValue05.AutoSize = true;
            this.lblInValue05.BackColor = System.Drawing.SystemColors.Window;
            this.lblInValue05.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInValue05.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblInValue05.Location = new System.Drawing.Point(10, 165);
            this.lblInValue05.Name = "lblInValue05";
            this.lblInValue05.Size = new System.Drawing.Size(130, 24);
            this.lblInValue05.TabIndex = 8;
            this.lblInValue05.Text = "Input Value 05";
            this.lblInValue05.Click += new System.EventHandler(this.lblInValue_Click);
            // 
            // cdvInValue05
            // 
            this.cdvInValue05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvInValue05.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue05.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue05.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInValue05.BtnToolTipText = "";
            this.cdvInValue05.ButtonWidth = 31;
            this.cdvInValue05.DescText = "";
            this.cdvInValue05.DisplaySubItemIndex = -1;
            this.cdvInValue05.DisplayText = "";
            this.cdvInValue05.Focusing = null;
            this.cdvInValue05.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInValue05.Index = 0;
            this.cdvInValue05.IsViewBtnImage = false;
            this.cdvInValue05.Location = new System.Drawing.Point(6, 162);
            this.cdvInValue05.MaxLength = 32767;
            this.cdvInValue05.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue05.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue05.Name = "cdvInValue05";
            this.cdvInValue05.ReadOnly = false;
            this.cdvInValue05.SameWidthHeightOfButton = true;
            this.cdvInValue05.SearchSubItemIndex = 0;
            this.cdvInValue05.SelectedDescIndex = -1;
            this.cdvInValue05.SelectedSubItemIndex = -1;
            this.cdvInValue05.SelectionStart = 0;
            this.cdvInValue05.Size = new System.Drawing.Size(238, 31);
            this.cdvInValue05.SmallImageList = null;
            this.cdvInValue05.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInValue05.TabIndex = 9;
            this.cdvInValue05.TextBoxToolTipText = "";
            this.cdvInValue05.TextBoxWidth = 238;
            this.cdvInValue05.VisibleButton = true;
            this.cdvInValue05.VisibleColumnHeader = false;
            this.cdvInValue05.VisibleDescription = false;
            this.cdvInValue05.TextBoxTextChanged += new System.EventHandler(this.cdvInValue_TextBoxTextChanged);
            this.cdvInValue05.Enter += new System.EventHandler(this.cdvInValue_Enter);
            this.cdvInValue05.Leave += new System.EventHandler(this.cdvInValue_Leave);
            // 
            // lblInValue04
            // 
            this.lblInValue04.AutoSize = true;
            this.lblInValue04.BackColor = System.Drawing.SystemColors.Window;
            this.lblInValue04.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInValue04.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblInValue04.Location = new System.Drawing.Point(10, 129);
            this.lblInValue04.Name = "lblInValue04";
            this.lblInValue04.Size = new System.Drawing.Size(130, 24);
            this.lblInValue04.TabIndex = 6;
            this.lblInValue04.Text = "Input Value 04";
            this.lblInValue04.Click += new System.EventHandler(this.lblInValue_Click);
            // 
            // cdvInValue04
            // 
            this.cdvInValue04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvInValue04.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue04.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue04.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInValue04.BtnToolTipText = "";
            this.cdvInValue04.ButtonWidth = 31;
            this.cdvInValue04.DescText = "";
            this.cdvInValue04.DisplaySubItemIndex = -1;
            this.cdvInValue04.DisplayText = "";
            this.cdvInValue04.Focusing = null;
            this.cdvInValue04.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInValue04.Index = 0;
            this.cdvInValue04.IsViewBtnImage = false;
            this.cdvInValue04.Location = new System.Drawing.Point(6, 126);
            this.cdvInValue04.MaxLength = 32767;
            this.cdvInValue04.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue04.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue04.Name = "cdvInValue04";
            this.cdvInValue04.ReadOnly = false;
            this.cdvInValue04.SameWidthHeightOfButton = true;
            this.cdvInValue04.SearchSubItemIndex = 0;
            this.cdvInValue04.SelectedDescIndex = -1;
            this.cdvInValue04.SelectedSubItemIndex = -1;
            this.cdvInValue04.SelectionStart = 0;
            this.cdvInValue04.Size = new System.Drawing.Size(238, 31);
            this.cdvInValue04.SmallImageList = null;
            this.cdvInValue04.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInValue04.TabIndex = 7;
            this.cdvInValue04.TextBoxToolTipText = "";
            this.cdvInValue04.TextBoxWidth = 238;
            this.cdvInValue04.VisibleButton = true;
            this.cdvInValue04.VisibleColumnHeader = false;
            this.cdvInValue04.VisibleDescription = false;
            this.cdvInValue04.TextBoxTextChanged += new System.EventHandler(this.cdvInValue_TextBoxTextChanged);
            this.cdvInValue04.Enter += new System.EventHandler(this.cdvInValue_Enter);
            this.cdvInValue04.Leave += new System.EventHandler(this.cdvInValue_Leave);
            // 
            // lblInValue03
            // 
            this.lblInValue03.AutoSize = true;
            this.lblInValue03.BackColor = System.Drawing.SystemColors.Window;
            this.lblInValue03.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInValue03.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblInValue03.Location = new System.Drawing.Point(10, 93);
            this.lblInValue03.Name = "lblInValue03";
            this.lblInValue03.Size = new System.Drawing.Size(130, 24);
            this.lblInValue03.TabIndex = 4;
            this.lblInValue03.Text = "Input Value 03";
            this.lblInValue03.Click += new System.EventHandler(this.lblInValue_Click);
            // 
            // cdvInValue03
            // 
            this.cdvInValue03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvInValue03.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue03.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue03.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInValue03.BtnToolTipText = "";
            this.cdvInValue03.ButtonWidth = 31;
            this.cdvInValue03.DescText = "";
            this.cdvInValue03.DisplaySubItemIndex = -1;
            this.cdvInValue03.DisplayText = "";
            this.cdvInValue03.Focusing = null;
            this.cdvInValue03.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInValue03.Index = 0;
            this.cdvInValue03.IsViewBtnImage = false;
            this.cdvInValue03.Location = new System.Drawing.Point(6, 90);
            this.cdvInValue03.MaxLength = 32767;
            this.cdvInValue03.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue03.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue03.Name = "cdvInValue03";
            this.cdvInValue03.ReadOnly = false;
            this.cdvInValue03.SameWidthHeightOfButton = true;
            this.cdvInValue03.SearchSubItemIndex = 0;
            this.cdvInValue03.SelectedDescIndex = -1;
            this.cdvInValue03.SelectedSubItemIndex = -1;
            this.cdvInValue03.SelectionStart = 0;
            this.cdvInValue03.Size = new System.Drawing.Size(238, 31);
            this.cdvInValue03.SmallImageList = null;
            this.cdvInValue03.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInValue03.TabIndex = 5;
            this.cdvInValue03.TextBoxToolTipText = "";
            this.cdvInValue03.TextBoxWidth = 238;
            this.cdvInValue03.VisibleButton = true;
            this.cdvInValue03.VisibleColumnHeader = false;
            this.cdvInValue03.VisibleDescription = false;
            this.cdvInValue03.TextBoxTextChanged += new System.EventHandler(this.cdvInValue_TextBoxTextChanged);
            this.cdvInValue03.Enter += new System.EventHandler(this.cdvInValue_Enter);
            this.cdvInValue03.Leave += new System.EventHandler(this.cdvInValue_Leave);
            // 
            // lblInValue02
            // 
            this.lblInValue02.AutoSize = true;
            this.lblInValue02.BackColor = System.Drawing.SystemColors.Window;
            this.lblInValue02.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInValue02.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblInValue02.Location = new System.Drawing.Point(10, 57);
            this.lblInValue02.Name = "lblInValue02";
            this.lblInValue02.Size = new System.Drawing.Size(130, 24);
            this.lblInValue02.TabIndex = 2;
            this.lblInValue02.Text = "Input Value 02";
            this.lblInValue02.Click += new System.EventHandler(this.lblInValue_Click);
            // 
            // cdvInValue02
            // 
            this.cdvInValue02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvInValue02.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue02.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue02.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInValue02.BtnToolTipText = "";
            this.cdvInValue02.ButtonWidth = 31;
            this.cdvInValue02.DescText = "";
            this.cdvInValue02.DisplaySubItemIndex = -1;
            this.cdvInValue02.DisplayText = "";
            this.cdvInValue02.Focusing = null;
            this.cdvInValue02.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInValue02.Index = 0;
            this.cdvInValue02.IsViewBtnImage = false;
            this.cdvInValue02.Location = new System.Drawing.Point(6, 54);
            this.cdvInValue02.MaxLength = 32767;
            this.cdvInValue02.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue02.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue02.Name = "cdvInValue02";
            this.cdvInValue02.ReadOnly = false;
            this.cdvInValue02.SameWidthHeightOfButton = true;
            this.cdvInValue02.SearchSubItemIndex = 0;
            this.cdvInValue02.SelectedDescIndex = -1;
            this.cdvInValue02.SelectedSubItemIndex = -1;
            this.cdvInValue02.SelectionStart = 0;
            this.cdvInValue02.Size = new System.Drawing.Size(238, 31);
            this.cdvInValue02.SmallImageList = null;
            this.cdvInValue02.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInValue02.TabIndex = 3;
            this.cdvInValue02.TextBoxToolTipText = "";
            this.cdvInValue02.TextBoxWidth = 238;
            this.cdvInValue02.VisibleButton = true;
            this.cdvInValue02.VisibleColumnHeader = false;
            this.cdvInValue02.VisibleDescription = false;
            this.cdvInValue02.TextBoxTextChanged += new System.EventHandler(this.cdvInValue_TextBoxTextChanged);
            this.cdvInValue02.Enter += new System.EventHandler(this.cdvInValue_Enter);
            this.cdvInValue02.Leave += new System.EventHandler(this.cdvInValue_Leave);
            // 
            // cdvInValue01
            // 
            this.cdvInValue01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvInValue01.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue01.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue01.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInValue01.BtnToolTipText = "";
            this.cdvInValue01.ButtonWidth = 31;
            this.cdvInValue01.DescText = "";
            this.cdvInValue01.DisplaySubItemIndex = -1;
            this.cdvInValue01.DisplayText = "";
            this.cdvInValue01.Focusing = null;
            this.cdvInValue01.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInValue01.Index = 0;
            this.cdvInValue01.IsViewBtnImage = false;
            this.cdvInValue01.Location = new System.Drawing.Point(6, 18);
            this.cdvInValue01.MaxLength = 32767;
            this.cdvInValue01.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInValue01.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInValue01.Name = "cdvInValue01";
            this.cdvInValue01.ReadOnly = false;
            this.cdvInValue01.SameWidthHeightOfButton = true;
            this.cdvInValue01.SearchSubItemIndex = 0;
            this.cdvInValue01.SelectedDescIndex = -1;
            this.cdvInValue01.SelectedSubItemIndex = -1;
            this.cdvInValue01.SelectionStart = 0;
            this.cdvInValue01.Size = new System.Drawing.Size(238, 31);
            this.cdvInValue01.SmallImageList = null;
            this.cdvInValue01.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInValue01.TabIndex = 1;
            this.cdvInValue01.TextBoxToolTipText = "";
            this.cdvInValue01.TextBoxWidth = 238;
            this.cdvInValue01.VisibleButton = true;
            this.cdvInValue01.VisibleColumnHeader = false;
            this.cdvInValue01.VisibleDescription = false;
            this.cdvInValue01.TextBoxTextChanged += new System.EventHandler(this.cdvInValue_TextBoxTextChanged);
            this.cdvInValue01.Enter += new System.EventHandler(this.cdvInValue_Enter);
            this.cdvInValue01.Leave += new System.EventHandler(this.cdvInValue_Leave);
            // 
            // frmWorkStartNEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.splMiddle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmWorkStartNEnd";
            this.Text = "Oper based Start and End Lot";
            this.Load += new System.EventHandler(this.frmWorkStartNEnd_Load);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.splMiddle, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            this.pnlLotCount.ResumeLayout(false);
            this.pnlLotCount.PerformLayout();
            this.pnlTransaction.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.grpLotStatus.ResumeLayout(false);
            this.pnlInValue.ResumeLayout(false);
            this.grpInputValue.ResumeLayout(false);
            this.grpInputValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInValue01)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splMiddle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Button btnRefresh;
        private UI.Controls.MCCodeView.MCCodeView cdvRes;
        private System.Windows.Forms.Label lblResource;
        private UI.Controls.MCCodeView.MCCodeView cdvOper;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.Panel pnlLotCount;
        private System.Windows.Forms.Label lblLotQty;
        private System.Windows.Forms.Label lblLotCount;
        private MESCore.Controls.udcLotList udcLotList;
        private System.Windows.Forms.Panel pnlTransaction;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnSplitLot;
        private System.Windows.Forms.Button btnHoldLot;
        private System.Windows.Forms.Button btnEndLot;
        private System.Windows.Forms.Button btnStartLot;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.GroupBox grpLotStatus;
        private MESCore.Controls.udcFlexibleScreen udcLotInfor;
        private System.Windows.Forms.Splitter splRight;
        private System.Windows.Forms.Panel pnlInValue;
        private System.Windows.Forms.GroupBox grpInputValue;
        private System.Windows.Forms.Label lblInValue01;
        private System.Windows.Forms.Label lblInValue05;
        private UI.Controls.MCCodeView.MCCodeView cdvInValue05;
        private System.Windows.Forms.Label lblInValue04;
        private UI.Controls.MCCodeView.MCCodeView cdvInValue04;
        private System.Windows.Forms.Label lblInValue03;
        private UI.Controls.MCCodeView.MCCodeView cdvInValue03;
        private System.Windows.Forms.Label lblInValue02;
        private UI.Controls.MCCodeView.MCCodeView cdvInValue02;
        private UI.Controls.MCCodeView.MCCodeView cdvInValue01;


    }
}