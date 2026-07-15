namespace Miracom.WEMCore
{
    partial class frmWEMTranWorkProcessEvent
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
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWEMTranWorkProcessEvent));
            this.pnlProcEventID = new System.Windows.Forms.Panel();
            this.grpNextStepApprover = new System.Windows.Forms.GroupBox();
            this.cdvNextUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.rbnPrvGroup = new System.Windows.Forms.RadioButton();
            this.rbnSecGroup = new System.Windows.Forms.RadioButton();
            this.rbnUser = new System.Windows.Forms.RadioButton();
            this.pnlNewEvent = new System.Windows.Forms.Panel();
            this.btnGenEventID = new System.Windows.Forms.Button();
            this.txtEventDesc = new System.Windows.Forms.TextBox();
            this.lblEventDesc = new System.Windows.Forms.Label();
            this.txtEventID = new System.Windows.Forms.TextBox();
            this.chkNew = new System.Windows.Forms.CheckBox();
            this.lisEvent = new Miracom.UI.Controls.MCListView.MCListView();
            this.colEvenID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEventDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStepID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProcID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProcType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblProcEventID = new System.Windows.Forms.Label();
            this.lblProcID = new System.Windows.Forms.Label();
            this.cdvProcID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcType = new System.Windows.Forms.Label();
            this.cdvProcType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlProcStatus = new System.Windows.Forms.Panel();
            this.spdProgress = new FarPoint.Win.Spread.FpSpread();
            this.spdProgress_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splProcEventID = new System.Windows.Forms.Splitter();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.udcScreen = new Miracom.MESCore.Controls.udcFlexibleScreen();
            this.btnToPDF = new System.Windows.Forms.Button();
            this.chkApproval = new System.Windows.Forms.CheckBox();
            this.chkArbitrary = new System.Windows.Forms.CheckBox();
            this.cdvNextStep = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblNextStep = new System.Windows.Forms.Label();
            this.chkSkip = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.sfdPDF = new System.Windows.Forms.SaveFileDialog();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlProcEventID.SuspendLayout();
            this.grpNextStepApprover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvNextUserID)).BeginInit();
            this.pnlNewEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcType)).BeginInit();
            this.pnlProcStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdProgress_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvNextStep)).BeginInit();
            this.pnlComment.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 7;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 8;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.chkSkip);
            this.pnlBottom.Controls.Add(this.lblNextStep);
            this.pnlBottom.Controls.Add(this.cdvNextStep);
            this.pnlBottom.Controls.Add(this.chkArbitrary);
            this.pnlBottom.Controls.Add(this.chkApproval);
            this.pnlBottom.Controls.Add(this.btnToPDF);
            this.pnlBottom.Controls.SetChildIndex(this.btnToPDF, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkApproval, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkArbitrary, 0);
            this.pnlBottom.Controls.SetChildIndex(this.cdvNextStep, 0);
            this.pnlBottom.Controls.SetChildIndex(this.lblNextStep, 0);
            this.pnlBottom.Controls.SetChildIndex(this.chkSkip, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.udcScreen);
            this.pnlCenter.Controls.Add(this.pnlComment);
            this.pnlCenter.Controls.Add(this.btnExpand);
            this.pnlCenter.Controls.Add(this.btnCollapse);
            this.pnlCenter.Controls.Add(this.splProcEventID);
            this.pnlCenter.Controls.Add(this.pnlProcEventID);
            this.pnlCenter.Controls.Add(this.pnlProcStatus);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // pnlProcEventID
            // 
            this.pnlProcEventID.Controls.Add(this.grpNextStepApprover);
            this.pnlProcEventID.Controls.Add(this.pnlNewEvent);
            this.pnlProcEventID.Controls.Add(this.chkNew);
            this.pnlProcEventID.Controls.Add(this.lisEvent);
            this.pnlProcEventID.Controls.Add(this.lblProcEventID);
            this.pnlProcEventID.Controls.Add(this.lblProcID);
            this.pnlProcEventID.Controls.Add(this.cdvProcID);
            this.pnlProcEventID.Controls.Add(this.lblProcType);
            this.pnlProcEventID.Controls.Add(this.cdvProcType);
            this.pnlProcEventID.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProcEventID.Location = new System.Drawing.Point(0, 35);
            this.pnlProcEventID.Name = "pnlProcEventID";
            this.pnlProcEventID.Size = new System.Drawing.Size(200, 471);
            this.pnlProcEventID.TabIndex = 0;
            // 
            // grpNextStepApprover
            // 
            this.grpNextStepApprover.Controls.Add(this.cdvNextUserID);
            this.grpNextStepApprover.Controls.Add(this.rbnPrvGroup);
            this.grpNextStepApprover.Controls.Add(this.rbnSecGroup);
            this.grpNextStepApprover.Controls.Add(this.rbnUser);
            this.grpNextStepApprover.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpNextStepApprover.Location = new System.Drawing.Point(0, 355);
            this.grpNextStepApprover.Name = "grpNextStepApprover";
            this.grpNextStepApprover.Size = new System.Drawing.Size(200, 116);
            this.grpNextStepApprover.TabIndex = 7;
            this.grpNextStepApprover.TabStop = false;
            this.grpNextStepApprover.Text = "Next Step Approver";
            // 
            // cdvNextUserID
            // 
            this.cdvNextUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvNextUserID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvNextUserID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvNextUserID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvNextUserID.BtnToolTipText = "";
            this.cdvNextUserID.DescText = "";
            this.cdvNextUserID.DisplaySubItemIndex = -1;
            this.cdvNextUserID.DisplayText = "";
            this.cdvNextUserID.Focusing = null;
            this.cdvNextUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvNextUserID.Index = 0;
            this.cdvNextUserID.IsViewBtnImage = false;
            this.cdvNextUserID.Location = new System.Drawing.Point(28, 88);
            this.cdvNextUserID.MaxLength = 30;
            this.cdvNextUserID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvNextUserID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvNextUserID.Name = "cdvNextUserID";
            this.cdvNextUserID.ReadOnly = true;
            this.cdvNextUserID.SearchSubItemIndex = 0;
            this.cdvNextUserID.SelectedDescIndex = -1;
            this.cdvNextUserID.SelectedSubItemIndex = -1;
            this.cdvNextUserID.SelectionStart = 0;
            this.cdvNextUserID.Size = new System.Drawing.Size(170, 20);
            this.cdvNextUserID.SmallImageList = null;
            this.cdvNextUserID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvNextUserID.TabIndex = 3;
            this.cdvNextUserID.TextBoxToolTipText = "";
            this.cdvNextUserID.TextBoxWidth = 170;
            this.cdvNextUserID.VisibleButton = true;
            this.cdvNextUserID.VisibleColumnHeader = false;
            this.cdvNextUserID.VisibleDescription = false;
            // 
            // rbnPrvGroup
            // 
            this.rbnPrvGroup.AutoSize = true;
            this.rbnPrvGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnPrvGroup.Location = new System.Drawing.Point(75, 65);
            this.rbnPrvGroup.Name = "rbnPrvGroup";
            this.rbnPrvGroup.Size = new System.Drawing.Size(103, 18);
            this.rbnPrvGroup.TabIndex = 2;
            this.rbnPrvGroup.TabStop = true;
            this.rbnPrvGroup.Text = "Privilege Group";
            this.rbnPrvGroup.CheckedChanged += new System.EventHandler(this.rbnNextUser_CheckedChanged);
            // 
            // rbnSecGroup
            // 
            this.rbnSecGroup.AutoSize = true;
            this.rbnSecGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnSecGroup.Location = new System.Drawing.Point(75, 42);
            this.rbnSecGroup.Name = "rbnSecGroup";
            this.rbnSecGroup.Size = new System.Drawing.Size(101, 18);
            this.rbnSecGroup.TabIndex = 1;
            this.rbnSecGroup.TabStop = true;
            this.rbnSecGroup.Text = "Security Group";
            this.rbnSecGroup.CheckedChanged += new System.EventHandler(this.rbnNextUser_CheckedChanged);
            // 
            // rbnUser
            // 
            this.rbnUser.AutoSize = true;
            this.rbnUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnUser.Location = new System.Drawing.Point(75, 19);
            this.rbnUser.Name = "rbnUser";
            this.rbnUser.Size = new System.Drawing.Size(53, 18);
            this.rbnUser.TabIndex = 0;
            this.rbnUser.TabStop = true;
            this.rbnUser.Text = "User";
            this.rbnUser.CheckedChanged += new System.EventHandler(this.rbnNextUser_CheckedChanged);
            // 
            // pnlNewEvent
            // 
            this.pnlNewEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNewEvent.Controls.Add(this.btnGenEventID);
            this.pnlNewEvent.Controls.Add(this.txtEventDesc);
            this.pnlNewEvent.Controls.Add(this.lblEventDesc);
            this.pnlNewEvent.Controls.Add(this.txtEventID);
            this.pnlNewEvent.Location = new System.Drawing.Point(34, 107);
            this.pnlNewEvent.Name = "pnlNewEvent";
            this.pnlNewEvent.Size = new System.Drawing.Size(187, 242);
            this.pnlNewEvent.TabIndex = 12;
            // 
            // btnGenEventID
            // 
            this.btnGenEventID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGenEventID.Location = new System.Drawing.Point(147, 0);
            this.btnGenEventID.Name = "btnGenEventID";
            this.btnGenEventID.Size = new System.Drawing.Size(40, 20);
            this.btnGenEventID.TabIndex = 5;
            this.btnGenEventID.Text = "Gen";
            this.btnGenEventID.UseVisualStyleBackColor = true;
            this.btnGenEventID.Click += new System.EventHandler(this.btnGenEventID_Click);
            // 
            // txtEventDesc
            // 
            this.txtEventDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventDesc.Location = new System.Drawing.Point(1, 40);
            this.txtEventDesc.MaxLength = 200;
            this.txtEventDesc.Multiline = true;
            this.txtEventDesc.Name = "txtEventDesc";
            this.txtEventDesc.Size = new System.Drawing.Size(186, 109);
            this.txtEventDesc.TabIndex = 2;
            // 
            // lblEventDesc
            // 
            this.lblEventDesc.AutoSize = true;
            this.lblEventDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventDesc.Location = new System.Drawing.Point(-1, 24);
            this.lblEventDesc.Name = "lblEventDesc";
            this.lblEventDesc.Size = new System.Drawing.Size(60, 13);
            this.lblEventDesc.TabIndex = 1;
            this.lblEventDesc.Text = "Description";
            // 
            // txtEventID
            // 
            this.txtEventID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventID.Location = new System.Drawing.Point(1, 0);
            this.txtEventID.MaxLength = 30;
            this.txtEventID.Name = "txtEventID";
            this.txtEventID.Size = new System.Drawing.Size(142, 20);
            this.txtEventID.TabIndex = 0;
            // 
            // chkNew
            // 
            this.chkNew.AutoSize = true;
            this.chkNew.Location = new System.Drawing.Point(117, 87);
            this.chkNew.Name = "chkNew";
            this.chkNew.Size = new System.Drawing.Size(48, 17);
            this.chkNew.TabIndex = 5;
            this.chkNew.Text = "New";
            this.chkNew.UseVisualStyleBackColor = true;
            this.chkNew.CheckedChanged += new System.EventHandler(this.chkNew_CheckedChanged);
            // 
            // lisEvent
            // 
            this.lisEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lisEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEvenID,
            this.colEventDesc,
            this.colStepID,
            this.colProcID,
            this.colProcType});
            this.lisEvent.EnableSort = true;
            this.lisEvent.EnableSortIcon = true;
            this.lisEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisEvent.FullRowSelect = true;
            this.lisEvent.Location = new System.Drawing.Point(7, 107);
            this.lisEvent.Name = "lisEvent";
            this.lisEvent.Size = new System.Drawing.Size(187, 242);
            this.lisEvent.TabIndex = 6;
            this.lisEvent.UseCompatibleStateImageBehavior = false;
            this.lisEvent.View = System.Windows.Forms.View.Details;
            this.lisEvent.SelectedIndexChanged += new System.EventHandler(this.lisEvent_SelectedIndexChanged);
            // 
            // colEvenID
            // 
            this.colEvenID.Text = "Event ID";
            this.colEvenID.Width = 80;
            // 
            // colEventDesc
            // 
            this.colEventDesc.Text = "Description";
            this.colEventDesc.Width = 150;
            // 
            // colStepID
            // 
            this.colStepID.Text = "Step ID";
            // 
            // colProcID
            // 
            this.colProcID.Text = "Process ID";
            // 
            // colProcType
            // 
            this.colProcType.Text = "Work Proc Type";
            // 
            // lblProcEventID
            // 
            this.lblProcEventID.AutoSize = true;
            this.lblProcEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcEventID.Location = new System.Drawing.Point(5, 89);
            this.lblProcEventID.Name = "lblProcEventID";
            this.lblProcEventID.Size = new System.Drawing.Size(106, 13);
            this.lblProcEventID.TabIndex = 4;
            this.lblProcEventID.Text = "Process Event ID";
            // 
            // lblProcID
            // 
            this.lblProcID.AutoSize = true;
            this.lblProcID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcID.Location = new System.Drawing.Point(5, 46);
            this.lblProcID.Name = "lblProcID";
            this.lblProcID.Size = new System.Drawing.Size(59, 13);
            this.lblProcID.TabIndex = 2;
            this.lblProcID.Text = "Process ID";
            // 
            // cdvProcID
            // 
            this.cdvProcID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvProcID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcID.BtnToolTipText = "";
            this.cdvProcID.DescText = "";
            this.cdvProcID.DisplaySubItemIndex = -1;
            this.cdvProcID.DisplayText = "";
            this.cdvProcID.Focusing = null;
            this.cdvProcID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcID.Index = 0;
            this.cdvProcID.IsViewBtnImage = false;
            this.cdvProcID.Location = new System.Drawing.Point(7, 64);
            this.cdvProcID.MaxLength = 30;
            this.cdvProcID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcID.Name = "cdvProcID";
            this.cdvProcID.ReadOnly = true;
            this.cdvProcID.SearchSubItemIndex = 0;
            this.cdvProcID.SelectedDescIndex = -1;
            this.cdvProcID.SelectedSubItemIndex = -1;
            this.cdvProcID.SelectionStart = 0;
            this.cdvProcID.Size = new System.Drawing.Size(187, 20);
            this.cdvProcID.SmallImageList = null;
            this.cdvProcID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcID.TabIndex = 3;
            this.cdvProcID.TextBoxToolTipText = "";
            this.cdvProcID.TextBoxWidth = 187;
            this.cdvProcID.VisibleButton = true;
            this.cdvProcID.VisibleColumnHeader = false;
            this.cdvProcID.VisibleDescription = false;
            this.cdvProcID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvProcID_SelectedItemChanged);
            this.cdvProcID.ButtonPress += new System.EventHandler(this.cdvProcID_ButtonPress);
            // 
            // lblProcType
            // 
            this.lblProcType.AutoSize = true;
            this.lblProcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcType.Location = new System.Drawing.Point(5, 5);
            this.lblProcType.Name = "lblProcType";
            this.lblProcType.Size = new System.Drawing.Size(101, 13);
            this.lblProcType.TabIndex = 0;
            this.lblProcType.Text = "Work Process Type";
            // 
            // cdvProcType
            // 
            this.cdvProcType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvProcType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcType.BtnToolTipText = "";
            this.cdvProcType.DescText = "";
            this.cdvProcType.DisplaySubItemIndex = -1;
            this.cdvProcType.DisplayText = "";
            this.cdvProcType.Focusing = null;
            this.cdvProcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcType.Index = 0;
            this.cdvProcType.IsViewBtnImage = false;
            this.cdvProcType.Location = new System.Drawing.Point(7, 23);
            this.cdvProcType.MaxLength = 30;
            this.cdvProcType.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcType.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcType.Name = "cdvProcType";
            this.cdvProcType.ReadOnly = true;
            this.cdvProcType.SearchSubItemIndex = 0;
            this.cdvProcType.SelectedDescIndex = -1;
            this.cdvProcType.SelectedSubItemIndex = -1;
            this.cdvProcType.SelectionStart = 0;
            this.cdvProcType.Size = new System.Drawing.Size(187, 20);
            this.cdvProcType.SmallImageList = null;
            this.cdvProcType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcType.TabIndex = 1;
            this.cdvProcType.TextBoxToolTipText = "";
            this.cdvProcType.TextBoxWidth = 187;
            this.cdvProcType.VisibleButton = true;
            this.cdvProcType.VisibleColumnHeader = false;
            this.cdvProcType.VisibleDescription = false;
            this.cdvProcType.ButtonPress += new System.EventHandler(this.cdvProcType_ButtonPress);
            // 
            // pnlProcStatus
            // 
            this.pnlProcStatus.Controls.Add(this.spdProgress);
            this.pnlProcStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProcStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlProcStatus.Name = "pnlProcStatus";
            this.pnlProcStatus.Size = new System.Drawing.Size(742, 35);
            this.pnlProcStatus.TabIndex = 1;
            // 
            // spdProgress
            // 
            this.spdProgress.AccessibleDescription = "spdProgress, Sheet1, Row 0, Column 0, ";
            this.spdProgress.BackColor = System.Drawing.SystemColors.Control;
            this.spdProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spdProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdProgress.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdProgress.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdProgress.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdProgress.HorizontalScrollBar.Name = "";
            this.spdProgress.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdProgress.HorizontalScrollBar.TabIndex = 16;
            this.spdProgress.HorizontalScrollBarHeight = 13;
            this.spdProgress.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdProgress.Location = new System.Drawing.Point(0, 0);
            this.spdProgress.Name = "spdProgress";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
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
            this.spdProgress.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdProgress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdProgress.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdProgress.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdProgress.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Cells;
            this.spdProgress.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdProgress_Sheet1});
            this.spdProgress.Size = new System.Drawing.Size(742, 35);
            this.spdProgress.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdProgress.TabIndex = 0;
            this.spdProgress.TabStop = false;
            this.spdProgress.TextTipDelay = 200;
            this.spdProgress.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdProgress.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdProgress.VerticalScrollBar.Name = "";
            this.spdProgress.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdProgress.VerticalScrollBar.TabIndex = 17;
            this.spdProgress.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdProgress.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdProgress_CellDoubleClick);
            // 
            // spdProgress_Sheet1
            // 
            this.spdProgress_Sheet1.Reset();
            spdProgress_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdProgress_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdProgress_Sheet1.ColumnCount = 100;
            spdProgress_Sheet1.ColumnHeader.RowCount = 0;
            spdProgress_Sheet1.RowCount = 1;
            spdProgress_Sheet1.RowHeader.ColumnCount = 0;
            this.spdProgress_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdProgress_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdProgress_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdProgress_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdProgress_Sheet1.DefaultStyle.Locked = true;
            this.spdProgress_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdProgress_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdProgress_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdProgress_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdProgress_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdProgress_Sheet1.Rows.Get(0).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.spdProgress_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdProgress_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdProgress_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdProgress_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splProcEventID
            // 
            this.splProcEventID.Location = new System.Drawing.Point(200, 35);
            this.splProcEventID.Name = "splProcEventID";
            this.splProcEventID.Size = new System.Drawing.Size(9, 471);
            this.splProcEventID.TabIndex = 1;
            this.splProcEventID.TabStop = false;
            this.splProcEventID.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splProcEventID_SplitterMoved);
            // 
            // btnCollapse
            // 
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(200, 245);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(9, 24);
            this.btnCollapse.TabIndex = 2;
            this.btnCollapse.UseVisualStyleBackColor = true;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(200, 272);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(9, 24);
            this.btnExpand.TabIndex = 3;
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // udcScreen
            // 
            this.udcScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcScreen.Location = new System.Drawing.Point(209, 35);
            this.udcScreen.Name = "udcScreen";
            this.udcScreen.ScreenAutoStretch = false;
            this.udcScreen.ScreenID = null;
            this.udcScreen.ScreenLock = false;
            this.udcScreen.ScreenLockBackColor = System.Drawing.Color.Empty;
            this.udcScreen.Size = new System.Drawing.Size(533, 447);
            this.udcScreen.TabIndex = 4;
            // 
            // btnToPDF
            // 
            this.btnToPDF.Location = new System.Drawing.Point(32, 7);
            this.btnToPDF.Name = "btnToPDF";
            this.btnToPDF.Size = new System.Drawing.Size(68, 26);
            this.btnToPDF.TabIndex = 1;
            this.btnToPDF.Text = "To PDF";
            this.btnToPDF.UseVisualStyleBackColor = true;
            this.btnToPDF.Click += new System.EventHandler(this.btnToPDF_Click);
            // 
            // chkApproval
            // 
            this.chkApproval.AutoSize = true;
            this.chkApproval.Location = new System.Drawing.Point(230, 12);
            this.chkApproval.Name = "chkApproval";
            this.chkApproval.Size = new System.Drawing.Size(68, 17);
            this.chkApproval.TabIndex = 3;
            this.chkApproval.Text = "Approval";
            this.chkApproval.UseVisualStyleBackColor = true;
            this.chkApproval.CheckedChanged += new System.EventHandler(this.chkApproval_CheckedChanged);
            // 
            // chkArbitrary
            // 
            this.chkArbitrary.AutoSize = true;
            this.chkArbitrary.Enabled = false;
            this.chkArbitrary.Location = new System.Drawing.Point(106, 12);
            this.chkArbitrary.Name = "chkArbitrary";
            this.chkArbitrary.Size = new System.Drawing.Size(108, 17);
            this.chkArbitrary.TabIndex = 2;
            this.chkArbitrary.Text = "Arbitrary Decision";
            this.chkArbitrary.UseVisualStyleBackColor = true;
            // 
            // cdvNextStep
            // 
            this.cdvNextStep.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvNextStep.BorderHotColor = System.Drawing.Color.Black;
            this.cdvNextStep.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvNextStep.BtnToolTipText = "";
            this.cdvNextStep.DescText = "";
            this.cdvNextStep.DisplaySubItemIndex = -1;
            this.cdvNextStep.DisplayText = "";
            this.cdvNextStep.Focusing = null;
            this.cdvNextStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvNextStep.Index = 0;
            this.cdvNextStep.IsViewBtnImage = false;
            this.cdvNextStep.Location = new System.Drawing.Point(435, 10);
            this.cdvNextStep.MaxLength = 30;
            this.cdvNextStep.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvNextStep.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvNextStep.Name = "cdvNextStep";
            this.cdvNextStep.ReadOnly = true;
            this.cdvNextStep.SearchSubItemIndex = 0;
            this.cdvNextStep.SelectedDescIndex = -1;
            this.cdvNextStep.SelectedSubItemIndex = -1;
            this.cdvNextStep.SelectionStart = 0;
            this.cdvNextStep.Size = new System.Drawing.Size(120, 20);
            this.cdvNextStep.SmallImageList = null;
            this.cdvNextStep.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvNextStep.TabIndex = 6;
            this.cdvNextStep.TextBoxToolTipText = "";
            this.cdvNextStep.TextBoxWidth = 120;
            this.cdvNextStep.VisibleButton = true;
            this.cdvNextStep.VisibleColumnHeader = false;
            this.cdvNextStep.VisibleDescription = false;
            // 
            // lblNextStep
            // 
            this.lblNextStep.AutoSize = true;
            this.lblNextStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextStep.Location = new System.Drawing.Point(375, 14);
            this.lblNextStep.Name = "lblNextStep";
            this.lblNextStep.Size = new System.Drawing.Size(54, 13);
            this.lblNextStep.TabIndex = 5;
            this.lblNextStep.Text = "Next Step";
            // 
            // chkSkip
            // 
            this.chkSkip.AutoSize = true;
            this.chkSkip.Location = new System.Drawing.Point(314, 12);
            this.chkSkip.Name = "chkSkip";
            this.chkSkip.Size = new System.Drawing.Size(47, 17);
            this.chkSkip.TabIndex = 4;
            this.chkSkip.Text = "Skip";
            this.chkSkip.UseVisualStyleBackColor = true;
            this.chkSkip.CheckedChanged += new System.EventHandler(this.chkSkip_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(5, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(21, 26);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.txtComment);
            this.pnlComment.Controls.Add(this.lblComment);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComment.Location = new System.Drawing.Point(209, 482);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Size = new System.Drawing.Size(533, 24);
            this.pnlComment.TabIndex = 5;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(70, 2);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(460, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(6, 5);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            // 
            // frmWEMTranWorkProcessEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWEMTranWorkProcessEvent";
            this.Text = "Process Event";
            this.Activated += new System.EventHandler(this.frmWEMSetupProcessAction_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlProcEventID.ResumeLayout(false);
            this.pnlProcEventID.PerformLayout();
            this.grpNextStepApprover.ResumeLayout(false);
            this.grpNextStepApprover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvNextUserID)).EndInit();
            this.pnlNewEvent.ResumeLayout(false);
            this.pnlNewEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcType)).EndInit();
            this.pnlProcStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdProgress_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvNextStep)).EndInit();
            this.pnlComment.ResumeLayout(false);
            this.pnlComment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProcEventID;
        private System.Windows.Forms.Panel pnlProcStatus;
        private System.Windows.Forms.Splitter splProcEventID;
        private FarPoint.Win.Spread.FpSpread spdProgress;
        private FarPoint.Win.Spread.SheetView spdProgress_Sheet1;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnCollapse;
        private System.Windows.Forms.Panel pnlNewEvent;
        private System.Windows.Forms.TextBox txtEventDesc;
        private System.Windows.Forms.Label lblEventDesc;
        private System.Windows.Forms.TextBox txtEventID;
        private System.Windows.Forms.CheckBox chkNew;
        private UI.Controls.MCListView.MCListView lisEvent;
        private System.Windows.Forms.ColumnHeader colEvenID;
        private System.Windows.Forms.ColumnHeader colEventDesc;
        private System.Windows.Forms.Label lblProcEventID;
        private System.Windows.Forms.Label lblProcID;
        private UI.Controls.MCCodeView.MCCodeView cdvProcID;
        private System.Windows.Forms.Label lblProcType;
        private UI.Controls.MCCodeView.MCCodeView cdvProcType;
        private System.Windows.Forms.GroupBox grpNextStepApprover;
        private UI.Controls.MCCodeView.MCCodeView cdvNextUserID;
        private System.Windows.Forms.RadioButton rbnPrvGroup;
        private System.Windows.Forms.RadioButton rbnSecGroup;
        private System.Windows.Forms.RadioButton rbnUser;
        private System.Windows.Forms.Button btnToPDF;
        private MESCore.Controls.udcFlexibleScreen udcScreen;
        private System.Windows.Forms.Button btnGenEventID;
        private System.Windows.Forms.CheckBox chkArbitrary;
        private System.Windows.Forms.CheckBox chkApproval;
        private System.Windows.Forms.CheckBox chkSkip;
        private System.Windows.Forms.Label lblNextStep;
        private UI.Controls.MCCodeView.MCCodeView cdvNextStep;
        private System.Windows.Forms.ColumnHeader colProcType;
        private System.Windows.Forms.ColumnHeader colProcID;
        private System.Windows.Forms.ColumnHeader colStepID;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.SaveFileDialog sfdPDF;
    }
}