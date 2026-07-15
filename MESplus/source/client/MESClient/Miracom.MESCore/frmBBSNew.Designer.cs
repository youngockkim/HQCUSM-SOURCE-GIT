namespace Miracom.MESCore
{
    partial class frmBBSNew
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.grpAttachFile = new System.Windows.Forms.GroupBox();
            this.lisFile = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panTop = new System.Windows.Forms.Panel();
            this.grpInfo3 = new System.Windows.Forms.GroupBox();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.cdvResGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.lblFlow = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.cdvMaterial = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvSecGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResGrp = new System.Windows.Forms.Label();
            this.lblSecGrp = new System.Windows.Forms.Label();
            this.cdvPrvGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUser = new System.Windows.Forms.Label();
            this.cdvSubAreaID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPrvGrp = new System.Windows.Forms.Label();
            this.cdvAreaID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubArea = new System.Windows.Forms.Label();
            this.lblAreaID = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.grpInfo4 = new System.Windows.Forms.GroupBox();
            this.rbnModeless = new System.Windows.Forms.RadioButton();
            this.txtAutoCloseTime = new System.Windows.Forms.TextBox();
            this.chkAutoCloseTime = new System.Windows.Forms.CheckBox();
            this.rbnModal = new System.Windows.Forms.RadioButton();
            this.lblSec = new System.Windows.Forms.Label();
            this.grpInfo2 = new System.Windows.Forms.GroupBox();
            this.cboPopupCycle = new System.Windows.Forms.ComboBox();
            this.cboApplyShift = new System.Windows.Forms.ComboBox();
            this.chkSysMsg = new System.Windows.Forms.CheckBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPopupCycle = new System.Windows.Forms.Label();
            this.lblApplyShift = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cdvFactory = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFactory = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panMid = new System.Windows.Forms.Panel();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.pnlBottom.SuspendLayout();
            this.grpAttachFile.SuspendLayout();
            this.panTop.SuspendLayout();
            this.grpInfo3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSecGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrvGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).BeginInit();
            this.grpInfo4.SuspendLayout();
            this.grpInfo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFactory)).BeginInit();
            this.grpInfo.SuspendLayout();
            this.panMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.grpAttachFile);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 436);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(3);
            this.pnlBottom.Size = new System.Drawing.Size(807, 118);
            this.pnlBottom.TabIndex = 2;
            // 
            // grpAttachFile
            // 
            this.grpAttachFile.Controls.Add(this.lisFile);
            this.grpAttachFile.Controls.Add(this.btnClear);
            this.grpAttachFile.Controls.Add(this.btnAttach);
            this.grpAttachFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpAttachFile.Location = new System.Drawing.Point(3, 3);
            this.grpAttachFile.Name = "grpAttachFile";
            this.grpAttachFile.Size = new System.Drawing.Size(371, 112);
            this.grpAttachFile.TabIndex = 0;
            this.grpAttachFile.TabStop = false;
            this.grpAttachFile.Text = "Attach File";
            // 
            // lisFile
            // 
            this.lisFile.AllowColumnReorder = true;
            this.lisFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lisFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisFile.EnableSort = true;
            this.lisFile.EnableSortIcon = true;
            this.lisFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lisFile.FullRowSelect = true;
            this.lisFile.Location = new System.Drawing.Point(3, 16);
            this.lisFile.MultiSelect = false;
            this.lisFile.Name = "lisFile";
            this.lisFile.Size = new System.Drawing.Size(284, 93);
            this.lisFile.TabIndex = 0;
            this.lisFile.UseCompatibleStateImageBehavior = false;
            this.lisFile.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Seq";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Name";
            this.columnHeader2.Width = 500;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Save File Name";
            this.columnHeader3.Width = 0;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClear.Location = new System.Drawing.Point(290, 77);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 28);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAttach.Location = new System.Drawing.Point(290, 47);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(75, 28);
            this.btnAttach.TabIndex = 1;
            this.btnAttach.Text = "Attach";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(647, 84);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(726, 84);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.grpInfo3);
            this.panTop.Controls.Add(this.grpInfo4);
            this.panTop.Controls.Add(this.grpInfo2);
            this.panTop.Controls.Add(this.grpInfo);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Padding = new System.Windows.Forms.Padding(3);
            this.panTop.Size = new System.Drawing.Size(807, 302);
            this.panTop.TabIndex = 0;
            // 
            // grpInfo3
            // 
            this.grpInfo3.Controls.Add(this.pnl2);
            this.grpInfo3.Controls.Add(this.pnl1);
            this.grpInfo3.Controls.Add(this.cdvResGrp);
            this.grpInfo3.Controls.Add(this.cdvOperation);
            this.grpInfo3.Controls.Add(this.cdvFlow);
            this.grpInfo3.Controls.Add(this.lblOperation);
            this.grpInfo3.Controls.Add(this.lblFlow);
            this.grpInfo3.Controls.Add(this.lblLotID);
            this.grpInfo3.Controls.Add(this.txtLotID);
            this.grpInfo3.Controls.Add(this.cdvMaterial);
            this.grpInfo3.Controls.Add(this.lblResID);
            this.grpInfo3.Controls.Add(this.cdvSecGrp);
            this.grpInfo3.Controls.Add(this.cdvResID);
            this.grpInfo3.Controls.Add(this.cdvUserID);
            this.grpInfo3.Controls.Add(this.lblResGrp);
            this.grpInfo3.Controls.Add(this.lblSecGrp);
            this.grpInfo3.Controls.Add(this.cdvPrvGrp);
            this.grpInfo3.Controls.Add(this.lblUser);
            this.grpInfo3.Controls.Add(this.cdvSubAreaID);
            this.grpInfo3.Controls.Add(this.lblPrvGrp);
            this.grpInfo3.Controls.Add(this.cdvAreaID);
            this.grpInfo3.Controls.Add(this.lblSubArea);
            this.grpInfo3.Controls.Add(this.lblAreaID);
            this.grpInfo3.Controls.Add(this.lblMaterial);
            this.grpInfo3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo3.Location = new System.Drawing.Point(3, 111);
            this.grpInfo3.Name = "grpInfo3";
            this.grpInfo3.Size = new System.Drawing.Size(801, 146);
            this.grpInfo3.TabIndex = 2;
            this.grpInfo3.TabStop = false;
            // 
            // pnl2
            // 
            this.pnl2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnl2.Location = new System.Drawing.Point(5, 91);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(700, 1);
            this.pnl2.TabIndex = 18;
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnl1.Location = new System.Drawing.Point(5, 38);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(700, 1);
            this.pnl1.TabIndex = 7;
            // 
            // cdvResGrp
            // 
            this.cdvResGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp.BtnToolTipText = "";
            this.cdvResGrp.DescText = "";
            this.cdvResGrp.DisplaySubItemIndex = -1;
            this.cdvResGrp.DisplayText = "";
            this.cdvResGrp.Focusing = null;
            this.cdvResGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvResGrp.Index = 0;
            this.cdvResGrp.IsViewBtnImage = false;
            this.cdvResGrp.Location = new System.Drawing.Point(97, 120);
            this.cdvResGrp.MaxLength = 20;
            this.cdvResGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp.Name = "cdvResGrp";
            this.cdvResGrp.ReadOnly = false;
            this.cdvResGrp.SearchSubItemIndex = 0;
            this.cdvResGrp.SelectedDescIndex = -1;
            this.cdvResGrp.SelectedSubItemIndex = -1;
            this.cdvResGrp.SelectionStart = 0;
            this.cdvResGrp.Size = new System.Drawing.Size(105, 20);
            this.cdvResGrp.SmallImageList = null;
            this.cdvResGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp.TabIndex = 27;
            this.cdvResGrp.TextBoxToolTipText = "";
            this.cdvResGrp.TextBoxWidth = 105;
            this.cdvResGrp.VisibleButton = true;
            this.cdvResGrp.VisibleColumnHeader = false;
            this.cdvResGrp.VisibleDescription = false;
            this.cdvResGrp.ButtonPress += new System.EventHandler(this.cdvResGrp_ButtonPress);
            // 
            // cdvOperation
            // 
            this.cdvOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOperation.BtnToolTipText = "";
            this.cdvOperation.DescText = "";
            this.cdvOperation.DisplaySubItemIndex = -1;
            this.cdvOperation.DisplayText = "";
            this.cdvOperation.Focusing = null;
            this.cdvOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.Index = 0;
            this.cdvOperation.IsViewBtnImage = false;
            this.cdvOperation.Location = new System.Drawing.Point(551, 44);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(105, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 14;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 105;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // cdvFlow
            // 
            this.cdvFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFlow.BtnToolTipText = "";
            this.cdvFlow.DescText = "";
            this.cdvFlow.DisplaySubItemIndex = 1;
            this.cdvFlow.DisplayText = "";
            this.cdvFlow.Focusing = null;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.Index = 0;
            this.cdvFlow.IsViewBtnImage = false;
            this.cdvFlow.Location = new System.Drawing.Point(330, 43);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(105, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 12;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 105;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(464, 45);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(53, 13);
            this.lblOperation.TabIndex = 13;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblFlow.Location = new System.Drawing.Point(230, 45);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(29, 13);
            this.lblFlow.TabIndex = 11;
            this.lblFlow.Text = "Flow";
            this.lblFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(10, 71);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 15;
            this.lblLotID.Text = "Lot ID";
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtLotID.Location = new System.Drawing.Point(97, 67);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(105, 20);
            this.txtLotID.TabIndex = 16;
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMaterial.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMaterial.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMaterial.BtnToolTipText = "";
            this.cdvMaterial.DescText = "";
            this.cdvMaterial.DisplaySubItemIndex = -1;
            this.cdvMaterial.DisplayText = "";
            this.cdvMaterial.Focusing = null;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvMaterial.Index = 0;
            this.cdvMaterial.IsViewBtnImage = false;
            this.cdvMaterial.Location = new System.Drawing.Point(97, 43);
            this.cdvMaterial.MaxLength = 1;
            this.cdvMaterial.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.ReadOnly = true;
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = -1;
            this.cdvMaterial.SelectionStart = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(105, 20);
            this.cdvMaterial.SmallImageList = null;
            this.cdvMaterial.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMaterial.TabIndex = 10;
            this.cdvMaterial.TextBoxToolTipText = "";
            this.cdvMaterial.TextBoxWidth = 105;
            this.cdvMaterial.VisibleButton = true;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.ButtonPress += new System.EventHandler(this.cdvMaterial_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblResID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblResID.Location = new System.Drawing.Point(10, 100);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 20;
            this.lblResID.Text = "Resource ID";
            // 
            // cdvSecGrp
            // 
            this.cdvSecGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSecGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSecGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSecGrp.BtnToolTipText = "";
            this.cdvSecGrp.DescText = "";
            this.cdvSecGrp.DisplaySubItemIndex = -1;
            this.cdvSecGrp.DisplayText = "";
            this.cdvSecGrp.Focusing = null;
            this.cdvSecGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvSecGrp.Index = 0;
            this.cdvSecGrp.IsViewBtnImage = false;
            this.cdvSecGrp.Location = new System.Drawing.Point(330, 14);
            this.cdvSecGrp.MaxLength = 20;
            this.cdvSecGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSecGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSecGrp.Name = "cdvSecGrp";
            this.cdvSecGrp.ReadOnly = false;
            this.cdvSecGrp.SearchSubItemIndex = 0;
            this.cdvSecGrp.SelectedDescIndex = -1;
            this.cdvSecGrp.SelectedSubItemIndex = -1;
            this.cdvSecGrp.SelectionStart = 0;
            this.cdvSecGrp.Size = new System.Drawing.Size(105, 20);
            this.cdvSecGrp.SmallImageList = null;
            this.cdvSecGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSecGrp.TabIndex = 3;
            this.cdvSecGrp.TextBoxToolTipText = "";
            this.cdvSecGrp.TextBoxWidth = 105;
            this.cdvSecGrp.VisibleButton = true;
            this.cdvSecGrp.VisibleColumnHeader = false;
            this.cdvSecGrp.VisibleDescription = false;
            this.cdvSecGrp.ButtonPress += new System.EventHandler(this.cdvSecGrp_ButtonPress);
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(97, 96);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(105, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 21;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 105;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // cdvUserID
            // 
            this.cdvUserID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUserID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUserID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUserID.BtnToolTipText = "";
            this.cdvUserID.DescText = "";
            this.cdvUserID.DisplaySubItemIndex = -1;
            this.cdvUserID.DisplayText = "";
            this.cdvUserID.Focusing = null;
            this.cdvUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvUserID.Index = 0;
            this.cdvUserID.IsViewBtnImage = false;
            this.cdvUserID.Location = new System.Drawing.Point(97, 14);
            this.cdvUserID.MaxLength = 20;
            this.cdvUserID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.Name = "cdvUserID";
            this.cdvUserID.ReadOnly = false;
            this.cdvUserID.SearchSubItemIndex = 0;
            this.cdvUserID.SelectedDescIndex = -1;
            this.cdvUserID.SelectedSubItemIndex = -1;
            this.cdvUserID.SelectionStart = 0;
            this.cdvUserID.Size = new System.Drawing.Size(105, 20);
            this.cdvUserID.SmallImageList = null;
            this.cdvUserID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUserID.TabIndex = 1;
            this.cdvUserID.TextBoxToolTipText = "";
            this.cdvUserID.TextBoxWidth = 105;
            this.cdvUserID.VisibleButton = true;
            this.cdvUserID.VisibleColumnHeader = false;
            this.cdvUserID.VisibleDescription = false;
            this.cdvUserID.ButtonPress += new System.EventHandler(this.cdvUserID_ButtonPress);
            // 
            // lblResGrp
            // 
            this.lblResGrp.AutoSize = true;
            this.lblResGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblResGrp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblResGrp.Location = new System.Drawing.Point(10, 123);
            this.lblResGrp.Name = "lblResGrp";
            this.lblResGrp.Size = new System.Drawing.Size(85, 13);
            this.lblResGrp.TabIndex = 26;
            this.lblResGrp.Text = "Resource Group";
            // 
            // lblSecGrp
            // 
            this.lblSecGrp.AutoSize = true;
            this.lblSecGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSecGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSecGrp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSecGrp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSecGrp.Location = new System.Drawing.Point(230, 17);
            this.lblSecGrp.Name = "lblSecGrp";
            this.lblSecGrp.Size = new System.Drawing.Size(58, 13);
            this.lblSecGrp.TabIndex = 2;
            this.lblSecGrp.Text = "Sec Group";
            this.lblSecGrp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvPrvGrp
            // 
            this.cdvPrvGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPrvGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPrvGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPrvGrp.BtnToolTipText = "";
            this.cdvPrvGrp.DescText = "";
            this.cdvPrvGrp.DisplaySubItemIndex = -1;
            this.cdvPrvGrp.DisplayText = "";
            this.cdvPrvGrp.Focusing = null;
            this.cdvPrvGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvPrvGrp.Index = 0;
            this.cdvPrvGrp.IsViewBtnImage = false;
            this.cdvPrvGrp.Location = new System.Drawing.Point(551, 14);
            this.cdvPrvGrp.MaxLength = 10;
            this.cdvPrvGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrvGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrvGrp.Name = "cdvPrvGrp";
            this.cdvPrvGrp.ReadOnly = false;
            this.cdvPrvGrp.SearchSubItemIndex = 0;
            this.cdvPrvGrp.SelectedDescIndex = -1;
            this.cdvPrvGrp.SelectedSubItemIndex = -1;
            this.cdvPrvGrp.SelectionStart = 0;
            this.cdvPrvGrp.Size = new System.Drawing.Size(105, 20);
            this.cdvPrvGrp.SmallImageList = null;
            this.cdvPrvGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrvGrp.TabIndex = 5;
            this.cdvPrvGrp.TextBoxToolTipText = "";
            this.cdvPrvGrp.TextBoxWidth = 105;
            this.cdvPrvGrp.VisibleButton = true;
            this.cdvPrvGrp.VisibleColumnHeader = false;
            this.cdvPrvGrp.VisibleDescription = false;
            this.cdvPrvGrp.ButtonPress += new System.EventHandler(this.cdvPrvGrp_ButtonPress);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblUser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUser.Location = new System.Drawing.Point(10, 18);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvSubAreaID
            // 
            this.cdvSubAreaID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubAreaID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubAreaID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubAreaID.BtnToolTipText = "";
            this.cdvSubAreaID.DescText = "";
            this.cdvSubAreaID.DisplaySubItemIndex = -1;
            this.cdvSubAreaID.DisplayText = "";
            this.cdvSubAreaID.Focusing = null;
            this.cdvSubAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvSubAreaID.Index = 0;
            this.cdvSubAreaID.IsViewBtnImage = false;
            this.cdvSubAreaID.Location = new System.Drawing.Point(551, 96);
            this.cdvSubAreaID.MaxLength = 20;
            this.cdvSubAreaID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaID.Name = "cdvSubAreaID";
            this.cdvSubAreaID.ReadOnly = false;
            this.cdvSubAreaID.SearchSubItemIndex = 0;
            this.cdvSubAreaID.SelectedDescIndex = -1;
            this.cdvSubAreaID.SelectedSubItemIndex = -1;
            this.cdvSubAreaID.SelectionStart = 0;
            this.cdvSubAreaID.Size = new System.Drawing.Size(105, 20);
            this.cdvSubAreaID.SmallImageList = null;
            this.cdvSubAreaID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubAreaID.TabIndex = 25;
            this.cdvSubAreaID.TextBoxToolTipText = "";
            this.cdvSubAreaID.TextBoxWidth = 105;
            this.cdvSubAreaID.VisibleButton = true;
            this.cdvSubAreaID.VisibleColumnHeader = false;
            this.cdvSubAreaID.VisibleDescription = false;
            this.cdvSubAreaID.ButtonPress += new System.EventHandler(this.cdvSubAreaID_ButtonPress);
            // 
            // lblPrvGrp
            // 
            this.lblPrvGrp.AutoSize = true;
            this.lblPrvGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrvGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPrvGrp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPrvGrp.Location = new System.Drawing.Point(464, 17);
            this.lblPrvGrp.Name = "lblPrvGrp";
            this.lblPrvGrp.Size = new System.Drawing.Size(79, 13);
            this.lblPrvGrp.TabIndex = 4;
            this.lblPrvGrp.Text = "Privilege Group";
            this.lblPrvGrp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvAreaID
            // 
            this.cdvAreaID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAreaID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAreaID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAreaID.BtnToolTipText = "";
            this.cdvAreaID.DescText = "";
            this.cdvAreaID.DisplaySubItemIndex = -1;
            this.cdvAreaID.DisplayText = "";
            this.cdvAreaID.Focusing = null;
            this.cdvAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvAreaID.Index = 0;
            this.cdvAreaID.IsViewBtnImage = false;
            this.cdvAreaID.Location = new System.Drawing.Point(330, 96);
            this.cdvAreaID.MaxLength = 20;
            this.cdvAreaID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.Name = "cdvAreaID";
            this.cdvAreaID.ReadOnly = false;
            this.cdvAreaID.SearchSubItemIndex = 0;
            this.cdvAreaID.SelectedDescIndex = -1;
            this.cdvAreaID.SelectedSubItemIndex = -1;
            this.cdvAreaID.SelectionStart = 0;
            this.cdvAreaID.Size = new System.Drawing.Size(105, 20);
            this.cdvAreaID.SmallImageList = null;
            this.cdvAreaID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAreaID.TabIndex = 23;
            this.cdvAreaID.TextBoxToolTipText = "";
            this.cdvAreaID.TextBoxWidth = 105;
            this.cdvAreaID.VisibleButton = true;
            this.cdvAreaID.VisibleColumnHeader = false;
            this.cdvAreaID.VisibleDescription = false;
            this.cdvAreaID.ButtonPress += new System.EventHandler(this.cdvAreaID_ButtonPress);
            // 
            // lblSubArea
            // 
            this.lblSubArea.AutoSize = true;
            this.lblSubArea.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSubArea.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubArea.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSubArea.Location = new System.Drawing.Point(464, 99);
            this.lblSubArea.Name = "lblSubArea";
            this.lblSubArea.Size = new System.Drawing.Size(48, 13);
            this.lblSubArea.TabIndex = 24;
            this.lblSubArea.Text = "SubArea";
            // 
            // lblAreaID
            // 
            this.lblAreaID.AutoSize = true;
            this.lblAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAreaID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAreaID.Location = new System.Drawing.Point(230, 99);
            this.lblAreaID.Name = "lblAreaID";
            this.lblAreaID.Size = new System.Drawing.Size(29, 13);
            this.lblAreaID.TabIndex = 22;
            this.lblAreaID.Text = "Area";
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblMaterial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaterial.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMaterial.Location = new System.Drawing.Point(10, 47);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(44, 13);
            this.lblMaterial.TabIndex = 9;
            this.lblMaterial.Text = "Material";
            // 
            // grpInfo4
            // 
            this.grpInfo4.Controls.Add(this.rbnModeless);
            this.grpInfo4.Controls.Add(this.txtAutoCloseTime);
            this.grpInfo4.Controls.Add(this.chkAutoCloseTime);
            this.grpInfo4.Controls.Add(this.rbnModal);
            this.grpInfo4.Controls.Add(this.lblSec);
            this.grpInfo4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpInfo4.Location = new System.Drawing.Point(3, 257);
            this.grpInfo4.Name = "grpInfo4";
            this.grpInfo4.Size = new System.Drawing.Size(801, 42);
            this.grpInfo4.TabIndex = 3;
            this.grpInfo4.TabStop = false;
            // 
            // rbnModeless
            // 
            this.rbnModeless.AutoSize = true;
            this.rbnModeless.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnModeless.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbnModeless.Location = new System.Drawing.Point(67, 16);
            this.rbnModeless.Name = "rbnModeless";
            this.rbnModeless.Size = new System.Drawing.Size(76, 18);
            this.rbnModeless.TabIndex = 1;
            this.rbnModeless.TabStop = true;
            this.rbnModeless.Text = "Modeless";
            this.rbnModeless.UseVisualStyleBackColor = true;
            // 
            // txtAutoCloseTime
            // 
            this.txtAutoCloseTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtAutoCloseTime.Location = new System.Drawing.Point(264, 15);
            this.txtAutoCloseTime.MaxLength = 3;
            this.txtAutoCloseTime.Name = "txtAutoCloseTime";
            this.txtAutoCloseTime.Size = new System.Drawing.Size(47, 20);
            this.txtAutoCloseTime.TabIndex = 3;
            // 
            // chkAutoCloseTime
            // 
            this.chkAutoCloseTime.AutoSize = true;
            this.chkAutoCloseTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAutoCloseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkAutoCloseTime.Location = new System.Drawing.Point(153, 16);
            this.chkAutoCloseTime.Name = "chkAutoCloseTime";
            this.chkAutoCloseTime.Size = new System.Drawing.Size(109, 18);
            this.chkAutoCloseTime.TabIndex = 2;
            this.chkAutoCloseTime.Text = "Auto Close Time";
            this.chkAutoCloseTime.CheckedChanged += new System.EventHandler(this.chkAutoCloseTime_CheckedChanged);
            // 
            // rbnModal
            // 
            this.rbnModal.AutoSize = true;
            this.rbnModal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnModal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rbnModal.Location = new System.Drawing.Point(6, 16);
            this.rbnModal.Name = "rbnModal";
            this.rbnModal.Size = new System.Drawing.Size(60, 18);
            this.rbnModal.TabIndex = 0;
            this.rbnModal.TabStop = true;
            this.rbnModal.Text = "Modal";
            this.rbnModal.UseVisualStyleBackColor = true;
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSec.Location = new System.Drawing.Point(317, 19);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(26, 13);
            this.lblSec.TabIndex = 4;
            this.lblSec.Text = "Sec";
            // 
            // grpInfo2
            // 
            this.grpInfo2.Controls.Add(this.cboPopupCycle);
            this.grpInfo2.Controls.Add(this.cboApplyShift);
            this.grpInfo2.Controls.Add(this.chkSysMsg);
            this.grpInfo2.Controls.Add(this.lblType);
            this.grpInfo2.Controls.Add(this.cdvType);
            this.grpInfo2.Controls.Add(this.lblPopupCycle);
            this.grpInfo2.Controls.Add(this.lblApplyShift);
            this.grpInfo2.Controls.Add(this.cboPriority);
            this.grpInfo2.Controls.Add(this.chkEnd);
            this.grpInfo2.Controls.Add(this.lblPriority);
            this.grpInfo2.Controls.Add(this.chkStart);
            this.grpInfo2.Controls.Add(this.dtpStartDate);
            this.grpInfo2.Controls.Add(this.dtpEndTime);
            this.grpInfo2.Controls.Add(this.dtpStartTime);
            this.grpInfo2.Controls.Add(this.dtpEndDate);
            this.grpInfo2.Controls.Add(this.cdvFactory);
            this.grpInfo2.Controls.Add(this.lblFactory);
            this.grpInfo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo2.Location = new System.Drawing.Point(3, 45);
            this.grpInfo2.Name = "grpInfo2";
            this.grpInfo2.Size = new System.Drawing.Size(801, 66);
            this.grpInfo2.TabIndex = 1;
            this.grpInfo2.TabStop = false;
            // 
            // cboPopupCycle
            // 
            this.cboPopupCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPopupCycle.Items.AddRange(new object[] {
            "Every Time",
            "Once and Done"});
            this.cboPopupCycle.Location = new System.Drawing.Point(330, 14);
            this.cboPopupCycle.MaxDropDownItems = 9;
            this.cboPopupCycle.Name = "cboPopupCycle";
            this.cboPopupCycle.Size = new System.Drawing.Size(105, 21);
            this.cboPopupCycle.TabIndex = 3;
            // 
            // cboApplyShift
            // 
            this.cboApplyShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApplyShift.Items.AddRange(new object[] {
            "No matter shift",
            "1",
            "2",
            "3",
            "4"});
            this.cboApplyShift.Location = new System.Drawing.Point(330, 38);
            this.cboApplyShift.MaxDropDownItems = 9;
            this.cboApplyShift.Name = "cboApplyShift";
            this.cboApplyShift.Size = new System.Drawing.Size(105, 21);
            this.cboApplyShift.TabIndex = 11;
            // 
            // chkSysMsg
            // 
            this.chkSysMsg.AutoSize = true;
            this.chkSysMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSysMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkSysMsg.Location = new System.Drawing.Point(463, 15);
            this.chkSysMsg.Name = "chkSysMsg";
            this.chkSysMsg.Size = new System.Drawing.Size(112, 18);
            this.chkSysMsg.TabIndex = 4;
            this.chkSysMsg.Text = "System Message";
            this.chkSysMsg.CheckedChanged += new System.EventHandler(this.chkSysMsg_CheckedChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(10, 18);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type";
            // 
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = -1;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(97, 14);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = false;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(105, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 1;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 105;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // lblPopupCycle
            // 
            this.lblPopupCycle.AutoSize = true;
            this.lblPopupCycle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPopupCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPopupCycle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPopupCycle.Location = new System.Drawing.Point(230, 18);
            this.lblPopupCycle.Name = "lblPopupCycle";
            this.lblPopupCycle.Size = new System.Drawing.Size(78, 13);
            this.lblPopupCycle.TabIndex = 2;
            this.lblPopupCycle.Text = "Popup Cycle";
            // 
            // lblApplyShift
            // 
            this.lblApplyShift.AutoSize = true;
            this.lblApplyShift.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblApplyShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblApplyShift.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblApplyShift.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblApplyShift.Location = new System.Drawing.Point(230, 42);
            this.lblApplyShift.Name = "lblApplyShift";
            this.lblApplyShift.Size = new System.Drawing.Size(68, 13);
            this.lblApplyShift.TabIndex = 10;
            this.lblApplyShift.Text = "Apply Shift";
            this.lblApplyShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPriority
            // 
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriority.Items.AddRange(new object[] {
            "Notice",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboPriority.Location = new System.Drawing.Point(97, 38);
            this.cboPriority.MaxDropDownItems = 9;
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(105, 21);
            this.cboPriority.TabIndex = 9;
            // 
            // chkEnd
            // 
            this.chkEnd.AutoSize = true;
            this.chkEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkEnd.Location = new System.Drawing.Point(619, 41);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(15, 14);
            this.chkEnd.TabIndex = 14;
            this.chkEnd.CheckedChanged += new System.EventHandler(this.chkEnd_CheckedChanged);
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(10, 42);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(46, 13);
            this.lblPriority.TabIndex = 8;
            this.lblPriority.Text = "Priority";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkStart
            // 
            this.chkStart.AutoSize = true;
            this.chkStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkStart.Location = new System.Drawing.Point(619, 17);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(15, 14);
            this.chkStart.TabIndex = 5;
            this.chkStart.CheckedChanged += new System.EventHandler(this.chkStart_CheckedChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(635, 14);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(78, 20);
            this.dtpStartDate.TabIndex = 6;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(714, 38);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(78, 20);
            this.dtpEndTime.TabIndex = 16;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(714, 14);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(78, 20);
            this.dtpStartTime.TabIndex = 7;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(635, 38);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(78, 20);
            this.dtpEndDate.TabIndex = 15;
            // 
            // cdvFactory
            // 
            this.cdvFactory.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFactory.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFactory.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFactory.BtnToolTipText = "";
            this.cdvFactory.DescText = "";
            this.cdvFactory.DisplaySubItemIndex = -1;
            this.cdvFactory.DisplayText = "";
            this.cdvFactory.Focusing = null;
            this.cdvFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvFactory.Index = 0;
            this.cdvFactory.IsViewBtnImage = false;
            this.cdvFactory.Location = new System.Drawing.Point(512, 38);
            this.cdvFactory.MaxLength = 10;
            this.cdvFactory.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFactory.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFactory.Name = "cdvFactory";
            this.cdvFactory.ReadOnly = false;
            this.cdvFactory.SearchSubItemIndex = 0;
            this.cdvFactory.SelectedDescIndex = -1;
            this.cdvFactory.SelectedSubItemIndex = -1;
            this.cdvFactory.SelectionStart = 0;
            this.cdvFactory.Size = new System.Drawing.Size(86, 20);
            this.cdvFactory.SmallImageList = null;
            this.cdvFactory.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFactory.TabIndex = 13;
            this.cdvFactory.TextBoxToolTipText = "";
            this.cdvFactory.TextBoxWidth = 86;
            this.cdvFactory.VisibleButton = true;
            this.cdvFactory.VisibleColumnHeader = false;
            this.cdvFactory.VisibleDescription = false;
            this.cdvFactory.ButtonPress += new System.EventHandler(this.cdvFactory_ButtonPress);
            // 
            // lblFactory
            // 
            this.lblFactory.AutoSize = true;
            this.lblFactory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblFactory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFactory.Location = new System.Drawing.Point(464, 42);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(42, 13);
            this.lblFactory.TabIndex = 12;
            this.lblFactory.Text = "Factory";
            this.lblFactory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtTitle);
            this.grpInfo.Controls.Add(this.lblTitle);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.Location = new System.Drawing.Point(3, 3);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(801, 42);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtTitle.Location = new System.Drawing.Point(97, 15);
            this.txtTitle.MaxLength = 200;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(695, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(10, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(32, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // panMid
            // 
            this.panMid.Controls.Add(this.txtMsg);
            this.panMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMid.Location = new System.Drawing.Point(0, 302);
            this.panMid.Name = "panMid";
            this.panMid.Size = new System.Drawing.Size(807, 134);
            this.panMid.TabIndex = 1;
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Location = new System.Drawing.Point(0, 0);
            this.txtMsg.MaxLength = 65000;
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(807, 134);
            this.txtMsg.TabIndex = 0;
            // 
            // frmBBSNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 554);
            this.Controls.Add(this.panMid);
            this.Controls.Add(this.panTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(823, 592);
            this.Name = "frmBBSNew";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create/Update Message";
            this.Activated += new System.EventHandler(this.frmBBSNew_Activated);
            this.Load += new System.EventHandler(this.frmBBSNew_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmBBSNew_KeyUp);
            this.pnlBottom.ResumeLayout(false);
            this.grpAttachFile.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            this.grpInfo3.ResumeLayout(false);
            this.grpInfo3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSecGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrvGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).EndInit();
            this.grpInfo4.ResumeLayout(false);
            this.grpInfo4.PerformLayout();
            this.grpInfo2.ResumeLayout(false);
            this.grpInfo2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFactory)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.panMid.ResumeLayout(false);
            this.panMid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Panel panMid;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.GroupBox grpAttachFile;
        private UI.Controls.MCListView.MCListView lisFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.GroupBox grpInfo3;
        private UI.Controls.MCCodeView.MCCodeView cdvResGrp;
        private UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.TextBox txtLotID;
        private UI.Controls.MCCodeView.MCCodeView cdvMaterial;
        private System.Windows.Forms.Label lblResID;
        private UI.Controls.MCCodeView.MCCodeView cdvSecGrp;
        private UI.Controls.MCCodeView.MCCodeView cdvResID;
        private UI.Controls.MCCodeView.MCCodeView cdvUserID;
        private System.Windows.Forms.Label lblResGrp;
        private System.Windows.Forms.Label lblSecGrp;
        private UI.Controls.MCCodeView.MCCodeView cdvPrvGrp;
        private System.Windows.Forms.Label lblUser;
        private UI.Controls.MCCodeView.MCCodeView cdvFactory;
        private UI.Controls.MCCodeView.MCCodeView cdvSubAreaID;
        private System.Windows.Forms.Label lblPrvGrp;
        private UI.Controls.MCCodeView.MCCodeView cdvAreaID;
        private System.Windows.Forms.Label lblFactory;
        private System.Windows.Forms.Label lblSubArea;
        private System.Windows.Forms.Label lblAreaID;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.GroupBox grpInfo4;
        private System.Windows.Forms.RadioButton rbnModeless;
        private System.Windows.Forms.TextBox txtAutoCloseTime;
        private System.Windows.Forms.CheckBox chkAutoCloseTime;
        private System.Windows.Forms.RadioButton rbnModal;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.GroupBox grpInfo2;
        private System.Windows.Forms.ComboBox cboPopupCycle;
        private System.Windows.Forms.ComboBox cboApplyShift;
        private System.Windows.Forms.Label lblType;
        private UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.Label lblPopupCycle;
        private System.Windows.Forms.Label lblApplyShift;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.CheckBox chkEnd;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.CheckBox chkSysMsg;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Panel pnl1;
    }
}