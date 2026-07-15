namespace Miracom.WEMCore
{
    partial class frmWEMViewWorkProcessEventList
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
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.lblProcID = new System.Windows.Forms.Label();
            this.cdvProcID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcType = new System.Windows.Forms.Label();
            this.cdvProcType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.chkTranTime = new System.Windows.Forms.CheckBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblStepID = new System.Windows.Forms.Label();
            this.cdvStepID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcStatus = new System.Windows.Forms.Label();
            this.cboEventStatus = new System.Windows.Forms.ComboBox();
            this.lblAssignedUser = new System.Windows.Forms.Label();
            this.cdvAssignedUser = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLastApprovalUser = new System.Windows.Forms.Label();
            this.cdvLastApprovalUser = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.spdEventList = new FarPoint.Win.Spread.FpSpread();
            this.spdEventList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcType)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvStepID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAssignedUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLastApprovalUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEventList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEventList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 112);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.lblLastApprovalUser);
            this.grpOption.Controls.Add(this.cdvLastApprovalUser);
            this.grpOption.Controls.Add(this.lblAssignedUser);
            this.grpOption.Controls.Add(this.cdvAssignedUser);
            this.grpOption.Controls.Add(this.cboEventStatus);
            this.grpOption.Controls.Add(this.lblProcStatus);
            this.grpOption.Controls.Add(this.lblStepID);
            this.grpOption.Controls.Add(this.cdvStepID);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.lblProcID);
            this.grpOption.Controls.Add(this.cdvProcID);
            this.grpOption.Controls.Add(this.lblProcType);
            this.grpOption.Controls.Add(this.cdvProcType);
            this.grpOption.Size = new System.Drawing.Size(742, 112);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdEventList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 112);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 401);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "ViewForm01";
            // 
            // lblProcID
            // 
            this.lblProcID.AutoSize = true;
            this.lblProcID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcID.Location = new System.Drawing.Point(9, 41);
            this.lblProcID.Name = "lblProcID";
            this.lblProcID.Size = new System.Drawing.Size(59, 13);
            this.lblProcID.TabIndex = 2;
            this.lblProcID.Text = "Process ID";
            // 
            // cdvProcID
            // 
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
            this.cdvProcID.Location = new System.Drawing.Point(143, 37);
            this.cdvProcID.MaxLength = 30;
            this.cdvProcID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcID.Name = "cdvProcID";
            this.cdvProcID.ReadOnly = false;
            this.cdvProcID.SearchSubItemIndex = 0;
            this.cdvProcID.SelectedDescIndex = -1;
            this.cdvProcID.SelectedSubItemIndex = -1;
            this.cdvProcID.SelectionStart = 0;
            this.cdvProcID.Size = new System.Drawing.Size(150, 20);
            this.cdvProcID.SmallImageList = null;
            this.cdvProcID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcID.TabIndex = 3;
            this.cdvProcID.TextBoxToolTipText = "";
            this.cdvProcID.TextBoxWidth = 150;
            this.cdvProcID.VisibleButton = true;
            this.cdvProcID.VisibleColumnHeader = false;
            this.cdvProcID.VisibleDescription = false;
            this.cdvProcID.ButtonPress += new System.EventHandler(this.cdvProcID_ButtonPress);
            // 
            // lblProcType
            // 
            this.lblProcType.AutoSize = true;
            this.lblProcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcType.Location = new System.Drawing.Point(9, 17);
            this.lblProcType.Name = "lblProcType";
            this.lblProcType.Size = new System.Drawing.Size(101, 13);
            this.lblProcType.TabIndex = 0;
            this.lblProcType.Text = "Work Process Type";
            // 
            // cdvProcType
            // 
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
            this.cdvProcType.Location = new System.Drawing.Point(143, 13);
            this.cdvProcType.MaxLength = 30;
            this.cdvProcType.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcType.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcType.Name = "cdvProcType";
            this.cdvProcType.ReadOnly = false;
            this.cdvProcType.SearchSubItemIndex = 0;
            this.cdvProcType.SelectedDescIndex = -1;
            this.cdvProcType.SelectedSubItemIndex = -1;
            this.cdvProcType.SelectionStart = 0;
            this.cdvProcType.Size = new System.Drawing.Size(150, 20);
            this.cdvProcType.SmallImageList = null;
            this.cdvProcType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcType.TabIndex = 1;
            this.cdvProcType.TextBoxToolTipText = "";
            this.cdvProcType.TextBoxWidth = 150;
            this.cdvProcType.VisibleButton = true;
            this.cdvProcType.VisibleColumnHeader = false;
            this.cdvProcType.VisibleDescription = false;
            this.cdvProcType.ButtonPress += new System.EventHandler(this.cdvProcType_ButtonPress);
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.chkTranTime);
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(427, 13);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(310, 20);
            this.pnlPeriod.TabIndex = 8;
            // 
            // chkTranTime
            // 
            this.chkTranTime.AutoSize = true;
            this.chkTranTime.Location = new System.Drawing.Point(3, 2);
            this.chkTranTime.Name = "chkTranTime";
            this.chkTranTime.Size = new System.Drawing.Size(97, 17);
            this.chkTranTime.TabIndex = 0;
            this.chkTranTime.Text = "Last Tran Time";
            this.chkTranTime.UseVisualStyleBackColor = true;
            this.chkTranTime.CheckedChanged += new System.EventHandler(this.chkTranTime_CheckedChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(109, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(220, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Location = new System.Drawing.Point(202, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // lblStepID
            // 
            this.lblStepID.AutoSize = true;
            this.lblStepID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepID.Location = new System.Drawing.Point(9, 65);
            this.lblStepID.Name = "lblStepID";
            this.lblStepID.Size = new System.Drawing.Size(43, 13);
            this.lblStepID.TabIndex = 4;
            this.lblStepID.Text = "Step ID";
            // 
            // cdvStepID
            // 
            this.cdvStepID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvStepID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvStepID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvStepID.BtnToolTipText = "";
            this.cdvStepID.DescText = "";
            this.cdvStepID.DisplaySubItemIndex = -1;
            this.cdvStepID.DisplayText = "";
            this.cdvStepID.Focusing = null;
            this.cdvStepID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvStepID.Index = 0;
            this.cdvStepID.IsViewBtnImage = false;
            this.cdvStepID.Location = new System.Drawing.Point(143, 61);
            this.cdvStepID.MaxLength = 30;
            this.cdvStepID.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvStepID.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvStepID.Name = "cdvStepID";
            this.cdvStepID.ReadOnly = false;
            this.cdvStepID.SearchSubItemIndex = 0;
            this.cdvStepID.SelectedDescIndex = -1;
            this.cdvStepID.SelectedSubItemIndex = -1;
            this.cdvStepID.SelectionStart = 0;
            this.cdvStepID.Size = new System.Drawing.Size(150, 20);
            this.cdvStepID.SmallImageList = null;
            this.cdvStepID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvStepID.TabIndex = 5;
            this.cdvStepID.TextBoxToolTipText = "";
            this.cdvStepID.TextBoxWidth = 150;
            this.cdvStepID.VisibleButton = true;
            this.cdvStepID.VisibleColumnHeader = false;
            this.cdvStepID.VisibleDescription = false;
            this.cdvStepID.ButtonPress += new System.EventHandler(this.cdvStepID_ButtonPress);
            // 
            // lblProcStatus
            // 
            this.lblProcStatus.AutoSize = true;
            this.lblProcStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcStatus.Location = new System.Drawing.Point(9, 89);
            this.lblProcStatus.Name = "lblProcStatus";
            this.lblProcStatus.Size = new System.Drawing.Size(78, 13);
            this.lblProcStatus.TabIndex = 6;
            this.lblProcStatus.Text = "Process Status";
            // 
            // cboEventStatus
            // 
            this.cboEventStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEventStatus.FormattingEnabled = true;
            this.cboEventStatus.Items.AddRange(new object[] {
            "",
            "C : Create",
            "P : Process",
            "L : Close",
            "A : Arbitrary Decision"});
            this.cboEventStatus.Location = new System.Drawing.Point(143, 85);
            this.cboEventStatus.Name = "cboEventStatus";
            this.cboEventStatus.Size = new System.Drawing.Size(150, 21);
            this.cboEventStatus.TabIndex = 7;
            // 
            // lblAssignedUser
            // 
            this.lblAssignedUser.AutoSize = true;
            this.lblAssignedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignedUser.Location = new System.Drawing.Point(427, 41);
            this.lblAssignedUser.Name = "lblAssignedUser";
            this.lblAssignedUser.Size = new System.Drawing.Size(89, 13);
            this.lblAssignedUser.TabIndex = 9;
            this.lblAssignedUser.Text = "Assigned User ID";
            // 
            // cdvAssignedUser
            // 
            this.cdvAssignedUser.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAssignedUser.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAssignedUser.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAssignedUser.BtnToolTipText = "";
            this.cdvAssignedUser.DescText = "";
            this.cdvAssignedUser.DisplaySubItemIndex = -1;
            this.cdvAssignedUser.DisplayText = "";
            this.cdvAssignedUser.Focusing = null;
            this.cdvAssignedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAssignedUser.Index = 0;
            this.cdvAssignedUser.IsViewBtnImage = false;
            this.cdvAssignedUser.Location = new System.Drawing.Point(587, 37);
            this.cdvAssignedUser.MaxLength = 20;
            this.cdvAssignedUser.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAssignedUser.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAssignedUser.Name = "cdvAssignedUser";
            this.cdvAssignedUser.ReadOnly = false;
            this.cdvAssignedUser.SearchSubItemIndex = 0;
            this.cdvAssignedUser.SelectedDescIndex = -1;
            this.cdvAssignedUser.SelectedSubItemIndex = -1;
            this.cdvAssignedUser.SelectionStart = 0;
            this.cdvAssignedUser.Size = new System.Drawing.Size(150, 20);
            this.cdvAssignedUser.SmallImageList = null;
            this.cdvAssignedUser.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAssignedUser.TabIndex = 10;
            this.cdvAssignedUser.TextBoxToolTipText = "";
            this.cdvAssignedUser.TextBoxWidth = 150;
            this.cdvAssignedUser.VisibleButton = true;
            this.cdvAssignedUser.VisibleColumnHeader = false;
            this.cdvAssignedUser.VisibleDescription = false;
            this.cdvAssignedUser.ButtonPress += new System.EventHandler(this.cdvAssignedUser_ButtonPress);
            // 
            // lblLastApprovalUser
            // 
            this.lblLastApprovalUser.AutoSize = true;
            this.lblLastApprovalUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastApprovalUser.Location = new System.Drawing.Point(427, 65);
            this.lblLastApprovalUser.Name = "lblLastApprovalUser";
            this.lblLastApprovalUser.Size = new System.Drawing.Size(111, 13);
            this.lblLastApprovalUser.TabIndex = 11;
            this.lblLastApprovalUser.Text = "Last Approval User ID";
            // 
            // cdvLastApprovalUser
            // 
            this.cdvLastApprovalUser.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLastApprovalUser.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLastApprovalUser.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLastApprovalUser.BtnToolTipText = "";
            this.cdvLastApprovalUser.DescText = "";
            this.cdvLastApprovalUser.DisplaySubItemIndex = -1;
            this.cdvLastApprovalUser.DisplayText = "";
            this.cdvLastApprovalUser.Focusing = null;
            this.cdvLastApprovalUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLastApprovalUser.Index = 0;
            this.cdvLastApprovalUser.IsViewBtnImage = false;
            this.cdvLastApprovalUser.Location = new System.Drawing.Point(587, 61);
            this.cdvLastApprovalUser.MaxLength = 20;
            this.cdvLastApprovalUser.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLastApprovalUser.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLastApprovalUser.Name = "cdvLastApprovalUser";
            this.cdvLastApprovalUser.ReadOnly = false;
            this.cdvLastApprovalUser.SearchSubItemIndex = 0;
            this.cdvLastApprovalUser.SelectedDescIndex = -1;
            this.cdvLastApprovalUser.SelectedSubItemIndex = -1;
            this.cdvLastApprovalUser.SelectionStart = 0;
            this.cdvLastApprovalUser.Size = new System.Drawing.Size(150, 20);
            this.cdvLastApprovalUser.SmallImageList = null;
            this.cdvLastApprovalUser.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLastApprovalUser.TabIndex = 12;
            this.cdvLastApprovalUser.TextBoxToolTipText = "";
            this.cdvLastApprovalUser.TextBoxWidth = 150;
            this.cdvLastApprovalUser.VisibleButton = true;
            this.cdvLastApprovalUser.VisibleColumnHeader = false;
            this.cdvLastApprovalUser.VisibleDescription = false;
            this.cdvLastApprovalUser.ButtonPress += new System.EventHandler(this.cdvLastApprovalUser_ButtonPress);
            // 
            // spdEventList
            // 
            this.spdEventList.AccessibleDescription = "spdEventList, Sheet1, Row 0, Column 0, ";
            this.spdEventList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdEventList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdEventList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdEventList.HorizontalScrollBar.Name = "";
            this.spdEventList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdEventList.HorizontalScrollBar.TabIndex = 10;
            this.spdEventList.Location = new System.Drawing.Point(0, 0);
            this.spdEventList.Name = "spdEventList";
            this.spdEventList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdEventList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdEventList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdEventList_Sheet1});
            this.spdEventList.Size = new System.Drawing.Size(742, 401);
            this.spdEventList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdEventList.TabIndex = 0;
            this.spdEventList.TextTipDelay = 200;
            this.spdEventList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdEventList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdEventList.VerticalScrollBar.Name = "";
            this.spdEventList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdEventList.VerticalScrollBar.TabIndex = 11;
            this.spdEventList.SetViewportLeftColumn(0, 0, 2);
            this.spdEventList.SetActiveViewport(0, 0, -1);
            // 
            // spdEventList_Sheet1
            // 
            this.spdEventList_Sheet1.Reset();
            spdEventList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdEventList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdEventList_Sheet1.ColumnCount = 16;
            spdEventList_Sheet1.RowCount = 3;
            this.spdEventList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdEventList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEventList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdEventList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEventList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Proc Event ID";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Step ID";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Proc ID";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Work Proc Type";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Proc Status";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Last Step ID";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Last Step Approver";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Last Step Finish Time";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Last Tran User ID";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Last Tran Time";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Report User ID";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Report Time";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Reserved Approver Type";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Reserved Approver";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Proc Event Desc";
            this.spdEventList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Tran Comment";
            this.spdEventList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEventList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdEventList_Sheet1.Columns.Get(0).Label = "Proc Event ID";
            this.spdEventList_Sheet1.Columns.Get(0).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(0).Width = 120F;
            this.spdEventList_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(1).Label = "Step ID";
            this.spdEventList_Sheet1.Columns.Get(1).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(2).Label = "Proc ID";
            this.spdEventList_Sheet1.Columns.Get(2).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(2).Width = 100F;
            this.spdEventList_Sheet1.Columns.Get(3).Label = "Work Proc Type";
            this.spdEventList_Sheet1.Columns.Get(3).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(3).Width = 100F;
            this.spdEventList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(4).Label = "Proc Status";
            this.spdEventList_Sheet1.Columns.Get(4).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(4).Width = 100F;
            this.spdEventList_Sheet1.Columns.Get(5).Label = "Last Step ID";
            this.spdEventList_Sheet1.Columns.Get(5).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(5).Width = 100F;
            this.spdEventList_Sheet1.Columns.Get(6).Label = "Last Step Approver";
            this.spdEventList_Sheet1.Columns.Get(6).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(6).Width = 100F;
            this.spdEventList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(7).Label = "Last Step Finish Time";
            this.spdEventList_Sheet1.Columns.Get(7).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(7).Width = 118F;
            this.spdEventList_Sheet1.Columns.Get(8).Label = "Last Tran User ID";
            this.spdEventList_Sheet1.Columns.Get(8).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(8).Width = 100F;
            this.spdEventList_Sheet1.Columns.Get(9).Label = "Last Tran Time";
            this.spdEventList_Sheet1.Columns.Get(9).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(9).Width = 100F;
            this.spdEventList_Sheet1.Columns.Get(10).Label = "Report User ID";
            this.spdEventList_Sheet1.Columns.Get(10).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(10).Width = 100F;
            this.spdEventList_Sheet1.Columns.Get(11).Label = "Report Time";
            this.spdEventList_Sheet1.Columns.Get(11).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(11).Width = 80F;
            this.spdEventList_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(12).Label = "Reserved Approver Type";
            this.spdEventList_Sheet1.Columns.Get(12).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(12).Width = 130F;
            this.spdEventList_Sheet1.Columns.Get(13).Label = "Reserved Approver";
            this.spdEventList_Sheet1.Columns.Get(13).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(13).Width = 100F;
            this.spdEventList_Sheet1.Columns.Get(14).Label = "Proc Event Desc";
            this.spdEventList_Sheet1.Columns.Get(14).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(14).Width = 100F;
            this.spdEventList_Sheet1.Columns.Get(15).Label = "Tran Comment";
            this.spdEventList_Sheet1.Columns.Get(15).Locked = true;
            this.spdEventList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEventList_Sheet1.Columns.Get(15).Width = 100F;
            this.spdEventList_Sheet1.FrozenColumnCount = 2;
            this.spdEventList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdEventList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdEventList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdEventList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEventList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdEventList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEventList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdEventList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWEMViewWorkProcessEventList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWEMViewWorkProcessEventList";
            this.Text = "View Work Process Event List";
            this.Activated += new System.EventHandler(this.frmWEMViewWorkProcessEventList_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcType)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvStepID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAssignedUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLastApprovalUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEventList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEventList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProcID;
        private UI.Controls.MCCodeView.MCCodeView cdvProcID;
        private System.Windows.Forms.Label lblProcType;
        private UI.Controls.MCCodeView.MCCodeView cdvProcType;
        private System.Windows.Forms.Label lblLastApprovalUser;
        private UI.Controls.MCCodeView.MCCodeView cdvLastApprovalUser;
        private System.Windows.Forms.Label lblAssignedUser;
        private UI.Controls.MCCodeView.MCCodeView cdvAssignedUser;
        private System.Windows.Forms.ComboBox cboEventStatus;
        private System.Windows.Forms.Label lblProcStatus;
        private System.Windows.Forms.Label lblStepID;
        private UI.Controls.MCCodeView.MCCodeView cdvStepID;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.CheckBox chkTranTime;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private FarPoint.Win.Spread.FpSpread spdEventList;
        private FarPoint.Win.Spread.SheetView spdEventList_Sheet1;
    }
}