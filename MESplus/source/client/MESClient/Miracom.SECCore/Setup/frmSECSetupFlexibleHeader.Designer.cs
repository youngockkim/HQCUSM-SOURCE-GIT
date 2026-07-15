namespace Miracom.SECCore
{
    partial class frmSECSetupFlexibleHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSECSetupFlexibleHeader));
            this.grpService = new System.Windows.Forms.GroupBox();
            this.cdvModule = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMod = new System.Windows.Forms.Label();
            this.cdvDspID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDspID = new System.Windows.Forms.Label();
            this.cdvUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUser = new System.Windows.Forms.Label();
            this.cdvService = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblService = new System.Windows.Forms.Label();
            this.grpAttachFunc = new System.Windows.Forms.GroupBox();
            this.pnlFuncLeft = new System.Windows.Forms.Panel();
            this.pnlFuncLeftMid = new System.Windows.Forms.Panel();
            this.tvAttachMember = new Miracom.UI.Controls.MCTreeView.MCTreeView();
            this.lblAttachMember = new System.Windows.Forms.Label();
            this.pnlFuncRight = new System.Windows.Forms.Panel();
            this.pnlFuncRightMid = new System.Windows.Forms.Panel();
            this.tvMember = new Miracom.UI.Controls.MCTreeView.MCTreeView();
            this.lblMemberList = new System.Windows.Forms.Label();
            this.pnlAttachFuncMid = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAttachExpand = new System.Windows.Forms.Button();
            this.btnAttachCollapse = new System.Windows.Forms.Button();
            this.btnMemberExpand = new System.Windows.Forms.Button();
            this.btnMemberCollapse = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDspID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvService)).BeginInit();
            this.grpAttachFunc.SuspendLayout();
            this.pnlFuncLeft.SuspendLayout();
            this.pnlFuncLeftMid.SuspendLayout();
            this.pnlFuncRight.SuspendLayout();
            this.pnlFuncRightMid.SuspendLayout();
            this.pnlAttachFuncMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(462, 7);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "View";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(556, 7);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnMemberExpand);
            this.pnlBottom.Controls.Add(this.btnMemberCollapse);
            this.pnlBottom.Controls.Add(this.btnAttachExpand);
            this.pnlBottom.Controls.Add(this.btnAttachCollapse);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnAttachCollapse, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnAttachExpand, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnMemberCollapse, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnMemberExpand, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grpAttachFunc);
            this.pnlCenter.Controls.Add(this.grpService);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm01";
            // 
            // grpService
            // 
            this.grpService.Controls.Add(this.cdvModule);
            this.grpService.Controls.Add(this.lblMod);
            this.grpService.Controls.Add(this.cdvDspID);
            this.grpService.Controls.Add(this.lblDspID);
            this.grpService.Controls.Add(this.cdvUserID);
            this.grpService.Controls.Add(this.lblUser);
            this.grpService.Controls.Add(this.cdvService);
            this.grpService.Controls.Add(this.lblService);
            this.grpService.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpService.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpService.Location = new System.Drawing.Point(3, 0);
            this.grpService.Name = "grpService";
            this.grpService.Size = new System.Drawing.Size(736, 77);
            this.grpService.TabIndex = 1;
            this.grpService.TabStop = false;
            // 
            // cdvModule
            // 
            this.cdvModule.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvModule.BorderHotColor = System.Drawing.Color.Black;
            this.cdvModule.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvModule.BtnToolTipText = "";
            this.cdvModule.ButtonWidth = 20;
            this.cdvModule.DescText = "";
            this.cdvModule.DisplaySubItemIndex = -1;
            this.cdvModule.DisplayText = "";
            this.cdvModule.Focusing = null;
            this.cdvModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvModule.Index = 0;
            this.cdvModule.IsViewBtnImage = false;
            this.cdvModule.Location = new System.Drawing.Point(130, 20);
            this.cdvModule.MaxLength = 20;
            this.cdvModule.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvModule.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvModule.MultiSelect = false;
            this.cdvModule.Name = "cdvModule";
            this.cdvModule.ReadOnly = false;
            this.cdvModule.SameWidthHeightOfButton = false;
            this.cdvModule.SearchSubItemIndex = 0;
            this.cdvModule.SelectedDescIndex = -1;
            this.cdvModule.SelectedDescToQueryText = "";
            this.cdvModule.SelectedSubItemIndex = -1;
            this.cdvModule.SelectedValueToQueryText = "";
            this.cdvModule.SelectionStart = 0;
            this.cdvModule.Size = new System.Drawing.Size(211, 20);
            this.cdvModule.SmallImageList = null;
            this.cdvModule.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvModule.TabIndex = 1;
            this.cdvModule.TextBoxToolTipText = "";
            this.cdvModule.TextBoxWidth = 211;
            this.cdvModule.VisibleButton = true;
            this.cdvModule.VisibleColumnHeader = false;
            this.cdvModule.VisibleDescription = false;
            this.cdvModule.ButtonPress += new System.EventHandler(this.cdvModule_ButtonPress);
            // 
            // lblMod
            // 
            this.lblMod.AutoSize = true;
            this.lblMod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMod.Location = new System.Drawing.Point(15, 23);
            this.lblMod.Name = "lblMod";
            this.lblMod.Size = new System.Drawing.Size(73, 13);
            this.lblMod.TabIndex = 0;
            this.lblMod.Text = "Module Name";
            this.lblMod.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvDspID
            // 
            this.cdvDspID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDspID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDspID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDspID.BtnToolTipText = "";
            this.cdvDspID.ButtonWidth = 20;
            this.cdvDspID.DescText = "";
            this.cdvDspID.DisplaySubItemIndex = -1;
            this.cdvDspID.DisplayText = "";
            this.cdvDspID.Focusing = null;
            this.cdvDspID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDspID.Index = 0;
            this.cdvDspID.IsViewBtnImage = false;
            this.cdvDspID.Location = new System.Drawing.Point(507, 45);
            this.cdvDspID.MaxLength = 20;
            this.cdvDspID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDspID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDspID.MultiSelect = false;
            this.cdvDspID.Name = "cdvDspID";
            this.cdvDspID.ReadOnly = false;
            this.cdvDspID.SameWidthHeightOfButton = false;
            this.cdvDspID.SearchSubItemIndex = 0;
            this.cdvDspID.SelectedDescIndex = -1;
            this.cdvDspID.SelectedDescToQueryText = "";
            this.cdvDspID.SelectedSubItemIndex = -1;
            this.cdvDspID.SelectedValueToQueryText = "";
            this.cdvDspID.SelectionStart = 0;
            this.cdvDspID.Size = new System.Drawing.Size(211, 20);
            this.cdvDspID.SmallImageList = null;
            this.cdvDspID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDspID.TabIndex = 7;
            this.cdvDspID.TextBoxToolTipText = "";
            this.cdvDspID.TextBoxWidth = 211;
            this.cdvDspID.VisibleButton = true;
            this.cdvDspID.VisibleColumnHeader = false;
            this.cdvDspID.VisibleDescription = false;
            this.cdvDspID.ButtonPress += new System.EventHandler(this.cdvDspID_ButtonPress);
            this.cdvDspID.TextBoxTextChanged += new System.EventHandler(this.cdvDspID_TextBoxTextChanged);
            // 
            // lblDspID
            // 
            this.lblDspID.AutoSize = true;
            this.lblDspID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDspID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDspID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDspID.Location = new System.Drawing.Point(402, 48);
            this.lblDspID.Name = "lblDspID";
            this.lblDspID.Size = new System.Drawing.Size(72, 13);
            this.lblDspID.TabIndex = 6;
            this.lblDspID.Text = "Dispatcher ID";
            this.lblDspID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvUserID
            // 
            this.cdvUserID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUserID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUserID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUserID.BtnToolTipText = "";
            this.cdvUserID.ButtonWidth = 20;
            this.cdvUserID.DescText = "";
            this.cdvUserID.DisplaySubItemIndex = -1;
            this.cdvUserID.DisplayText = "";
            this.cdvUserID.Focusing = null;
            this.cdvUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUserID.Index = 0;
            this.cdvUserID.IsViewBtnImage = false;
            this.cdvUserID.Location = new System.Drawing.Point(507, 20);
            this.cdvUserID.MaxLength = 20;
            this.cdvUserID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.MultiSelect = false;
            this.cdvUserID.Name = "cdvUserID";
            this.cdvUserID.ReadOnly = false;
            this.cdvUserID.SameWidthHeightOfButton = false;
            this.cdvUserID.SearchSubItemIndex = 0;
            this.cdvUserID.SelectedDescIndex = -1;
            this.cdvUserID.SelectedDescToQueryText = "";
            this.cdvUserID.SelectedSubItemIndex = -1;
            this.cdvUserID.SelectedValueToQueryText = "";
            this.cdvUserID.SelectionStart = 0;
            this.cdvUserID.Size = new System.Drawing.Size(211, 20);
            this.cdvUserID.SmallImageList = null;
            this.cdvUserID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUserID.TabIndex = 5;
            this.cdvUserID.TextBoxToolTipText = "";
            this.cdvUserID.TextBoxWidth = 211;
            this.cdvUserID.VisibleButton = true;
            this.cdvUserID.VisibleColumnHeader = false;
            this.cdvUserID.VisibleDescription = false;
            this.cdvUserID.ButtonPress += new System.EventHandler(this.cdvUserID_ButtonPress);
            this.cdvUserID.TextBoxTextChanged += new System.EventHandler(this.cdvUserID_TextBoxTextChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUser.Location = new System.Drawing.Point(402, 23);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(43, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User ID";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvService
            // 
            this.cdvService.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvService.BorderHotColor = System.Drawing.Color.Black;
            this.cdvService.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvService.BtnToolTipText = "";
            this.cdvService.ButtonWidth = 20;
            this.cdvService.DescText = "";
            this.cdvService.DisplaySubItemIndex = -1;
            this.cdvService.DisplayText = "";
            this.cdvService.Focusing = null;
            this.cdvService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvService.Index = 0;
            this.cdvService.IsViewBtnImage = false;
            this.cdvService.Location = new System.Drawing.Point(130, 45);
            this.cdvService.MaxLength = 100;
            this.cdvService.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvService.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvService.MultiSelect = false;
            this.cdvService.Name = "cdvService";
            this.cdvService.ReadOnly = false;
            this.cdvService.SameWidthHeightOfButton = false;
            this.cdvService.SearchSubItemIndex = 0;
            this.cdvService.SelectedDescIndex = -1;
            this.cdvService.SelectedDescToQueryText = "";
            this.cdvService.SelectedSubItemIndex = -1;
            this.cdvService.SelectedValueToQueryText = "";
            this.cdvService.SelectionStart = 0;
            this.cdvService.Size = new System.Drawing.Size(211, 20);
            this.cdvService.SmallImageList = null;
            this.cdvService.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvService.TabIndex = 3;
            this.cdvService.TextBoxToolTipText = "";
            this.cdvService.TextBoxWidth = 211;
            this.cdvService.VisibleButton = true;
            this.cdvService.VisibleColumnHeader = false;
            this.cdvService.VisibleDescription = false;
            this.cdvService.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvService_SelectedItemChanged);
            this.cdvService.ButtonPress += new System.EventHandler(this.cdvService_ButtonPress);
            this.cdvService.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvService_TextBoxKeyPress);
            this.cdvService.TextBoxTextChanged += new System.EventHandler(this.cdvService_TextBoxTextChanged);
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblService.Location = new System.Drawing.Point(15, 48);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(86, 13);
            this.lblService.TabIndex = 2;
            this.lblService.Text = "Service Name";
            this.lblService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpAttachFunc
            // 
            this.grpAttachFunc.Controls.Add(this.pnlFuncLeft);
            this.grpAttachFunc.Controls.Add(this.pnlFuncRight);
            this.grpAttachFunc.Controls.Add(this.pnlAttachFuncMid);
            this.grpAttachFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAttachFunc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAttachFunc.Location = new System.Drawing.Point(3, 77);
            this.grpAttachFunc.Name = "grpAttachFunc";
            this.grpAttachFunc.Size = new System.Drawing.Size(736, 429);
            this.grpAttachFunc.TabIndex = 2;
            this.grpAttachFunc.TabStop = false;
            this.grpAttachFunc.Resize += new System.EventHandler(this.grpAttachFunc_Resize);
            // 
            // pnlFuncLeft
            // 
            this.pnlFuncLeft.Controls.Add(this.pnlFuncLeftMid);
            this.pnlFuncLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFuncLeft.Location = new System.Drawing.Point(3, 16);
            this.pnlFuncLeft.Name = "pnlFuncLeft";
            this.pnlFuncLeft.Size = new System.Drawing.Size(290, 410);
            this.pnlFuncLeft.TabIndex = 0;
            // 
            // pnlFuncLeftMid
            // 
            this.pnlFuncLeftMid.Controls.Add(this.tvAttachMember);
            this.pnlFuncLeftMid.Controls.Add(this.lblAttachMember);
            this.pnlFuncLeftMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFuncLeftMid.Location = new System.Drawing.Point(0, 0);
            this.pnlFuncLeftMid.Name = "pnlFuncLeftMid";
            this.pnlFuncLeftMid.Size = new System.Drawing.Size(290, 410);
            this.pnlFuncLeftMid.TabIndex = 1;
            // 
            // tvAttachMember
            // 
            this.tvAttachMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAttachMember.Location = new System.Drawing.Point(0, 14);
            this.tvAttachMember.Name = "tvAttachMember";
            this.tvAttachMember.SelectedNodes = ((System.Collections.ArrayList)(resources.GetObject("tvAttachMember.SelectedNodes")));
            this.tvAttachMember.ShowNodeToolTips = true;
            this.tvAttachMember.ShowRootLines = false;
            this.tvAttachMember.Size = new System.Drawing.Size(290, 396);
            this.tvAttachMember.TabIndex = 12;
            // 
            // lblAttachMember
            // 
            this.lblAttachMember.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAttachMember.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttachMember.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblAttachMember.Location = new System.Drawing.Point(0, 0);
            this.lblAttachMember.Name = "lblAttachMember";
            this.lblAttachMember.Size = new System.Drawing.Size(290, 14);
            this.lblAttachMember.TabIndex = 8;
            this.lblAttachMember.Text = "Attached Header Member List";
            this.lblAttachMember.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFuncRight
            // 
            this.pnlFuncRight.Controls.Add(this.pnlFuncRightMid);
            this.pnlFuncRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFuncRight.Location = new System.Drawing.Point(438, 16);
            this.pnlFuncRight.Name = "pnlFuncRight";
            this.pnlFuncRight.Size = new System.Drawing.Size(295, 410);
            this.pnlFuncRight.TabIndex = 1;
            // 
            // pnlFuncRightMid
            // 
            this.pnlFuncRightMid.Controls.Add(this.tvMember);
            this.pnlFuncRightMid.Controls.Add(this.lblMemberList);
            this.pnlFuncRightMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFuncRightMid.Location = new System.Drawing.Point(0, 0);
            this.pnlFuncRightMid.Name = "pnlFuncRightMid";
            this.pnlFuncRightMid.Size = new System.Drawing.Size(295, 410);
            this.pnlFuncRightMid.TabIndex = 1;
            // 
            // tvMember
            // 
            this.tvMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMember.Location = new System.Drawing.Point(0, 14);
            this.tvMember.Name = "tvMember";
            this.tvMember.SelectedNodes = ((System.Collections.ArrayList)(resources.GetObject("tvMember.SelectedNodes")));
            this.tvMember.ShowNodeToolTips = true;
            this.tvMember.ShowRootLines = false;
            this.tvMember.Size = new System.Drawing.Size(295, 396);
            this.tvMember.TabIndex = 12;
            // 
            // lblMemberList
            // 
            this.lblMemberList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMemberList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMemberList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMemberList.Location = new System.Drawing.Point(0, 0);
            this.lblMemberList.Name = "lblMemberList";
            this.lblMemberList.Size = new System.Drawing.Size(295, 14);
            this.lblMemberList.TabIndex = 7;
            this.lblMemberList.Text = "Service Member List";
            this.lblMemberList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAttachFuncMid
            // 
            this.pnlAttachFuncMid.Controls.Add(this.btnDown);
            this.pnlAttachFuncMid.Controls.Add(this.btnUp);
            this.pnlAttachFuncMid.Controls.Add(this.btnDel);
            this.pnlAttachFuncMid.Controls.Add(this.btnAdd);
            this.pnlAttachFuncMid.Location = new System.Drawing.Point(330, 20);
            this.pnlAttachFuncMid.Name = "pnlAttachFuncMid";
            this.pnlAttachFuncMid.Size = new System.Drawing.Size(47, 236);
            this.pnlAttachFuncMid.TabIndex = 0;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(3, 209);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 5;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(3, 185);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 4;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Location = new System.Drawing.Point(11, 109);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = ">";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(11, 80);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAttachExpand
            // 
            this.btnAttachExpand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAttachExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnAttachExpand.Image")));
            this.btnAttachExpand.Location = new System.Drawing.Point(38, 8);
            this.btnAttachExpand.Name = "btnAttachExpand";
            this.btnAttachExpand.Size = new System.Drawing.Size(24, 24);
            this.btnAttachExpand.TabIndex = 7;
            this.btnAttachExpand.Click += new System.EventHandler(this.btnAttachExpand_Click);
            // 
            // btnAttachCollapse
            // 
            this.btnAttachCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAttachCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnAttachCollapse.Image")));
            this.btnAttachCollapse.Location = new System.Drawing.Point(6, 8);
            this.btnAttachCollapse.Name = "btnAttachCollapse";
            this.btnAttachCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnAttachCollapse.TabIndex = 6;
            this.btnAttachCollapse.Click += new System.EventHandler(this.btnAttachCollapse_Click);
            // 
            // btnMemberExpand
            // 
            this.btnMemberExpand.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMemberExpand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMemberExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnMemberExpand.Image")));
            this.btnMemberExpand.Location = new System.Drawing.Point(473, 8);
            this.btnMemberExpand.Name = "btnMemberExpand";
            this.btnMemberExpand.Size = new System.Drawing.Size(24, 24);
            this.btnMemberExpand.TabIndex = 5;
            this.btnMemberExpand.Click += new System.EventHandler(this.btnMemberExpand_Click);
            // 
            // btnMemberCollapse
            // 
            this.btnMemberCollapse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMemberCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMemberCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnMemberCollapse.Image")));
            this.btnMemberCollapse.Location = new System.Drawing.Point(441, 8);
            this.btnMemberCollapse.Name = "btnMemberCollapse";
            this.btnMemberCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnMemberCollapse.TabIndex = 4;
            this.btnMemberCollapse.Click += new System.EventHandler(this.btnMemberCollapse_Click);
            // 
            // frmSECSetupFlexibleHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmSECSetupFlexibleHeader";
            this.Text = "Flexible Header Setup";
            this.Load += new System.EventHandler(this.frmSECSetupFlexibleHeader_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpService.ResumeLayout(false);
            this.grpService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDspID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvService)).EndInit();
            this.grpAttachFunc.ResumeLayout(false);
            this.pnlFuncLeft.ResumeLayout(false);
            this.pnlFuncLeftMid.ResumeLayout(false);
            this.pnlFuncRight.ResumeLayout(false);
            this.pnlFuncRightMid.ResumeLayout(false);
            this.pnlAttachFuncMid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpService;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUserID;
        private System.Windows.Forms.Label lblUser;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvService;
        private System.Windows.Forms.Label lblService;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDspID;
        private System.Windows.Forms.Label lblDspID;
        private System.Windows.Forms.GroupBox grpAttachFunc;
        private System.Windows.Forms.Panel pnlFuncLeft;
        private System.Windows.Forms.Panel pnlFuncLeftMid;
        private System.Windows.Forms.Panel pnlFuncRight;
        private System.Windows.Forms.Panel pnlFuncRightMid;
        private System.Windows.Forms.Panel pnlAttachFuncMid;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvModule;
        private System.Windows.Forms.Label lblMod;
        private System.Windows.Forms.Label lblAttachMember;
        private System.Windows.Forms.Label lblMemberList;
        private Miracom.UI.Controls.MCTreeView.MCTreeView tvAttachMember;
        private Miracom.UI.Controls.MCTreeView.MCTreeView tvMember;
        private System.Windows.Forms.Button btnMemberExpand;
        private System.Windows.Forms.Button btnMemberCollapse;
        private System.Windows.Forms.Button btnAttachExpand;
        private System.Windows.Forms.Button btnAttachCollapse;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
    }
}
