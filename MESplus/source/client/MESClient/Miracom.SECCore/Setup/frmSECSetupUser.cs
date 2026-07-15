
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmSECSetupUser.vb
//   Description : MES Cient Form User Setup Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//       - ClearData() : Initalize form fields
//       - View_User() : View User Definition
//       - Update_User() : reate/Update/Delete user
//       - SetGroupCmfItem() : Set Group / Cmf Property to control
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-24 : Created by W.Y. Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.SECCore
{
    public class frmSECSetupUser : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmSECSetupUser()
        {
            
            
            InitializeComponent();
            
            
            
        }
        
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        
        private System.ComponentModel.Container components = null;
        



        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.Panel pnlUserList;
        private Miracom.UI.Controls.MCListView.MCListView lisUser;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.TextBox txtUserDesc;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Panel pnlTap;
        private System.Windows.Forms.TabControl tabUser;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.Panel pnlRelate;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.CheckBox chkChangePassFlag;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSecGrpId;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhoneOther;
        private System.Windows.Forms.TextBox txtPhoneHome;
        private System.Windows.Forms.TextBox txtPhoneMobile;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPhoneBirthday;
        private System.Windows.Forms.Label lblRetireDate;
        private System.Windows.Forms.Label lblEnterDate;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblPhoneEmail;
        private System.Windows.Forms.Label lblPhoneOther;
        private System.Windows.Forms.Label lblPhoneHome;
        private System.Windows.Forms.Label lblPhoneMobile;
        private System.Windows.Forms.Label lblPhoneOffice;
        private System.Windows.Forms.Label lblSecGrpId;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TabPage tbpGroup;
        private System.Windows.Forms.GroupBox grpGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup1;
        private System.Windows.Forms.Label lblGroup10;
        private System.Windows.Forms.Label lblGroup9;
        private System.Windows.Forms.Label lblGroup8;
        private System.Windows.Forms.Label lblGroup7;
        private System.Windows.Forms.Label lblGroup6;
        private System.Windows.Forms.Label lblGroup5;
        private System.Windows.Forms.Label lblGroup4;
        private System.Windows.Forms.Label lblGroup3;
        private System.Windows.Forms.Label lblGroup2;
        private System.Windows.Forms.Label lblGroup1;
        private System.Windows.Forms.TabPage tabCMF;
        private System.Windows.Forms.GroupBox grpCMF;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        private System.Windows.Forms.Label lblCMF10;
        private System.Windows.Forms.Label lblCMF9;
        private System.Windows.Forms.Label lblCMF8;
        private System.Windows.Forms.Label lblCMF7;
        private System.Windows.Forms.Label lblCMF6;
        private System.Windows.Forms.Label lblCMF5;
        private System.Windows.Forms.Label lblCMF4;
        private System.Windows.Forms.Label lblCMF3;
        private System.Windows.Forms.Label lblCMF2;
        private System.Windows.Forms.Label lblCMF1;
        private System.Windows.Forms.RadioButton rbnFemale;
        private System.Windows.Forms.RadioButton rbnMale;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtBirthDay;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtEnterDate;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtRetireDate;
        private System.Windows.Forms.TextBox txtPhoneOffice;
        private System.Windows.Forms.GroupBox grpInfoExt;
        private System.Windows.Forms.CheckBox chkClearLoginFailCount;
        private System.Windows.Forms.CheckBox chkClearOldPassword;
        private System.Windows.Forms.CheckBox chkChangePasswrdNextLogin;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtPasswordChangePeriod;
        private System.Windows.Forms.Label Label1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtExpireDate;
        private System.Windows.Forms.Label lblExpireDate;
        private System.Windows.Forms.GroupBox grpDateTime;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private RadioButton rbnGroup;
        private System.Windows.Forms.Label lblCreate;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlUserList = new System.Windows.Forms.Panel();
            this.lisUser = new Miracom.UI.Controls.MCListView.MCListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlUser = new System.Windows.Forms.Panel();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.txtUserDesc = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.pnlTap = new System.Windows.Forms.Panel();
            this.tabUser = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlRelate = new System.Windows.Forms.Panel();
            this.grpDateTime = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.grpInfoExt = new System.Windows.Forms.GroupBox();
            this.chkClearLoginFailCount = new System.Windows.Forms.CheckBox();
            this.chkClearOldPassword = new System.Windows.Forms.CheckBox();
            this.chkChangePasswrdNextLogin = new System.Windows.Forms.CheckBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtPasswordChangePeriod = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.udtExpireDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.lblExpireDate = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.rbnGroup = new System.Windows.Forms.RadioButton();
            this.udtRetireDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udtEnterDate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udtBirthDay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.rbnFemale = new System.Windows.Forms.RadioButton();
            this.rbnMale = new System.Windows.Forms.RadioButton();
            this.chkChangePassFlag = new System.Windows.Forms.CheckBox();
            this.cdvSecGrpId = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhoneOther = new System.Windows.Forms.TextBox();
            this.txtPhoneHome = new System.Windows.Forms.TextBox();
            this.txtPhoneMobile = new System.Windows.Forms.TextBox();
            this.txtPhoneOffice = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPhoneBirthday = new System.Windows.Forms.Label();
            this.lblRetireDate = new System.Windows.Forms.Label();
            this.lblEnterDate = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblPhoneEmail = new System.Windows.Forms.Label();
            this.lblPhoneOther = new System.Windows.Forms.Label();
            this.lblPhoneHome = new System.Windows.Forms.Label();
            this.lblPhoneMobile = new System.Windows.Forms.Label();
            this.lblPhoneOffice = new System.Windows.Forms.Label();
            this.lblSecGrpId = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbpGroup = new System.Windows.Forms.TabPage();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup10 = new System.Windows.Forms.Label();
            this.lblGroup9 = new System.Windows.Forms.Label();
            this.lblGroup8 = new System.Windows.Forms.Label();
            this.lblGroup7 = new System.Windows.Forms.Label();
            this.lblGroup6 = new System.Windows.Forms.Label();
            this.lblGroup5 = new System.Windows.Forms.Label();
            this.lblGroup4 = new System.Windows.Forms.Label();
            this.lblGroup3 = new System.Windows.Forms.Label();
            this.lblGroup2 = new System.Windows.Forms.Label();
            this.lblGroup1 = new System.Windows.Forms.Label();
            this.tabCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlUserList.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.grpUser.SuspendLayout();
            this.pnlTap.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlRelate.SuspendLayout();
            this.grpDateTime.SuspendLayout();
            this.grpInfoExt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtExpireDate)).BeginInit();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtRetireDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtEnterDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtBirthDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSecGrpId)).BeginInit();
            this.tbpGroup.SuspendLayout();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).BeginInit();
            this.tabCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // lblDataCount
            // 
            this.lblDataCount.TabIndex = 0;
            // 
            // lblDataCountBase
            // 
            this.lblDataCountBase.TabIndex = 3;
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
            // splMain
            // 
            this.splMain.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTap);
            this.pnlRight.Controls.Add(this.pnlUser);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlRight.TabIndex = 2;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlUserList);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
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
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "User Setup";
            // 
            // pnlUserList
            // 
            this.pnlUserList.Controls.Add(this.lisUser);
            this.pnlUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserList.Location = new System.Drawing.Point(3, 3);
            this.pnlUserList.Name = "pnlUserList";
            this.pnlUserList.Size = new System.Drawing.Size(229, 500);
            this.pnlUserList.TabIndex = 0;
            // 
            // lisUser
            // 
            this.lisUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDescription});
            this.lisUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisUser.EnableSort = true;
            this.lisUser.EnableSortIcon = true;
            this.lisUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisUser.FullRowSelect = true;
            this.lisUser.Location = new System.Drawing.Point(0, 0);
            this.lisUser.MultiSelect = false;
            this.lisUser.Name = "lisUser";
            this.lisUser.Size = new System.Drawing.Size(229, 500);
            this.lisUser.TabIndex = 0;
            this.lisUser.UseCompatibleStateImageBehavior = false;
            this.lisUser.View = System.Windows.Forms.View.Details;
            this.lisUser.SelectedIndexChanged += new System.EventHandler(this.lisUser_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "User ID";
            this.colName.Width = 100;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 200;
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.grpUser);
            this.pnlUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUser.Location = new System.Drawing.Point(3, 0);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(500, 71);
            this.pnlUser.TabIndex = 1;
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.txtUserDesc);
            this.grpUser.Controls.Add(this.txtUserId);
            this.grpUser.Controls.Add(this.lblDesc);
            this.grpUser.Controls.Add(this.lblUserId);
            this.grpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUser.Location = new System.Drawing.Point(0, 0);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(500, 71);
            this.grpUser.TabIndex = 0;
            this.grpUser.TabStop = false;
            // 
            // txtUserDesc
            // 
            this.txtUserDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserDesc.Location = new System.Drawing.Point(127, 40);
            this.txtUserDesc.MaxLength = 200;
            this.txtUserDesc.Name = "txtUserDesc";
            this.txtUserDesc.Size = new System.Drawing.Size(358, 20);
            this.txtUserDesc.TabIndex = 3;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(127, 16);
            this.txtUserId.MaxLength = 20;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtUserId.Size = new System.Drawing.Size(193, 20);
            this.txtUserId.TabIndex = 1;
            this.txtUserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserId_KeyPress);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.Location = new System.Drawing.Point(15, 19);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(50, 13);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "User ID";
            // 
            // pnlTap
            // 
            this.pnlTap.Controls.Add(this.tabUser);
            this.pnlTap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTap.Location = new System.Drawing.Point(3, 71);
            this.pnlTap.Name = "pnlTap";
            this.pnlTap.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTap.Size = new System.Drawing.Size(500, 432);
            this.pnlTap.TabIndex = 2;
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.tbpGeneral);
            this.tabUser.Controls.Add(this.tbpGroup);
            this.tabUser.Controls.Add(this.tabCMF);
            this.tabUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUser.ItemSize = new System.Drawing.Size(60, 18);
            this.tabUser.Location = new System.Drawing.Point(0, 5);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedIndex = 0;
            this.tabUser.Size = new System.Drawing.Size(500, 427);
            this.tabUser.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlRelate);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(492, 401);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlRelate
            // 
            this.pnlRelate.Controls.Add(this.grpDateTime);
            this.pnlRelate.Controls.Add(this.grpInfoExt);
            this.pnlRelate.Controls.Add(this.grpInfo);
            this.pnlRelate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRelate.Location = new System.Drawing.Point(0, 0);
            this.pnlRelate.Name = "pnlRelate";
            this.pnlRelate.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRelate.Size = new System.Drawing.Size(492, 401);
            this.pnlRelate.TabIndex = 0;
            // 
            // grpDateTime
            // 
            this.grpDateTime.Controls.Add(this.txtUpdateTime);
            this.grpDateTime.Controls.Add(this.txtCreateTime);
            this.grpDateTime.Controls.Add(this.txtUpdateUser);
            this.grpDateTime.Controls.Add(this.lblUpdate);
            this.grpDateTime.Controls.Add(this.txtCreateUser);
            this.grpDateTime.Controls.Add(this.lblCreate);
            this.grpDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDateTime.Location = new System.Drawing.Point(3, 337);
            this.grpDateTime.Name = "grpDateTime";
            this.grpDateTime.Size = new System.Drawing.Size(486, 64);
            this.grpDateTime.TabIndex = 2;
            this.grpDateTime.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(286, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(162, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(286, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(162, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(162, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(15, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(120, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(162, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(15, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpInfoExt
            // 
            this.grpInfoExt.Controls.Add(this.chkClearLoginFailCount);
            this.grpInfoExt.Controls.Add(this.chkClearOldPassword);
            this.grpInfoExt.Controls.Add(this.chkChangePasswrdNextLogin);
            this.grpInfoExt.Controls.Add(this.Label2);
            this.grpInfoExt.Controls.Add(this.txtPasswordChangePeriod);
            this.grpInfoExt.Controls.Add(this.Label1);
            this.grpInfoExt.Controls.Add(this.udtExpireDate);
            this.grpInfoExt.Controls.Add(this.lblExpireDate);
            this.grpInfoExt.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfoExt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInfoExt.Location = new System.Drawing.Point(3, 231);
            this.grpInfoExt.Name = "grpInfoExt";
            this.grpInfoExt.Size = new System.Drawing.Size(486, 106);
            this.grpInfoExt.TabIndex = 1;
            this.grpInfoExt.TabStop = false;
            // 
            // chkClearLoginFailCount
            // 
            this.chkClearLoginFailCount.AutoSize = true;
            this.chkClearLoginFailCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkClearLoginFailCount.Location = new System.Drawing.Point(280, 70);
            this.chkClearLoginFailCount.Name = "chkClearLoginFailCount";
            this.chkClearLoginFailCount.Size = new System.Drawing.Size(135, 18);
            this.chkClearLoginFailCount.TabIndex = 7;
            this.chkClearLoginFailCount.Text = "Clear Login Fail Count";
            // 
            // chkClearOldPassword
            // 
            this.chkClearOldPassword.AutoSize = true;
            this.chkClearOldPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkClearOldPassword.Location = new System.Drawing.Point(280, 45);
            this.chkClearOldPassword.Name = "chkClearOldPassword";
            this.chkClearOldPassword.Size = new System.Drawing.Size(124, 18);
            this.chkClearOldPassword.TabIndex = 6;
            this.chkClearOldPassword.Text = "Clear Old Password";
            // 
            // chkChangePasswrdNextLogin
            // 
            this.chkChangePasswrdNextLogin.AutoSize = true;
            this.chkChangePasswrdNextLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkChangePasswrdNextLogin.Location = new System.Drawing.Point(16, 80);
            this.chkChangePasswrdNextLogin.Name = "chkChangePasswrdNextLogin";
            this.chkChangePasswrdNextLogin.Size = new System.Drawing.Size(211, 18);
            this.chkChangePasswrdNextLogin.TabIndex = 5;
            this.chkChangePasswrdNextLogin.Text = "Must Change Password At Next Login";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.Location = new System.Drawing.Point(225, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(29, 13);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "days";
            // 
            // txtPasswordChangePeriod
            // 
            this.txtPasswordChangePeriod.Location = new System.Drawing.Point(120, 42);
            this.txtPasswordChangePeriod.MaxLength = 6;
            this.txtPasswordChangePeriod.Name = "txtPasswordChangePeriod";
            this.txtPasswordChangePeriod.Size = new System.Drawing.Size(98, 20);
            this.txtPasswordChangePeriod.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Location = new System.Drawing.Point(16, 45);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 26);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Password Change Period";
            // 
            // udtExpireDate
            // 
            this.udtExpireDate.DateTime = new System.DateTime(2007, 10, 8, 0, 0, 0, 0);
            this.udtExpireDate.FormatString = "";
            this.udtExpireDate.Location = new System.Drawing.Point(120, 16);
            this.udtExpireDate.Name = "udtExpireDate";
            this.udtExpireDate.Size = new System.Drawing.Size(150, 21);
            this.udtExpireDate.TabIndex = 1;
            this.udtExpireDate.Value = new System.DateTime(2007, 10, 8, 0, 0, 0, 0);
            // 
            // lblExpireDate
            // 
            this.lblExpireDate.AutoSize = true;
            this.lblExpireDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExpireDate.Location = new System.Drawing.Point(16, 20);
            this.lblExpireDate.Name = "lblExpireDate";
            this.lblExpireDate.Size = new System.Drawing.Size(62, 13);
            this.lblExpireDate.TabIndex = 0;
            this.lblExpireDate.Text = "Expire Date";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.rbnGroup);
            this.grpInfo.Controls.Add(this.udtRetireDate);
            this.grpInfo.Controls.Add(this.udtEnterDate);
            this.grpInfo.Controls.Add(this.udtBirthDay);
            this.grpInfo.Controls.Add(this.rbnFemale);
            this.grpInfo.Controls.Add(this.rbnMale);
            this.grpInfo.Controls.Add(this.chkChangePassFlag);
            this.grpInfo.Controls.Add(this.cdvSecGrpId);
            this.grpInfo.Controls.Add(this.txtEmail);
            this.grpInfo.Controls.Add(this.txtPhoneOther);
            this.grpInfo.Controls.Add(this.txtPhoneHome);
            this.grpInfo.Controls.Add(this.txtPhoneMobile);
            this.grpInfo.Controls.Add(this.txtPhoneOffice);
            this.grpInfo.Controls.Add(this.txtPassword);
            this.grpInfo.Controls.Add(this.lblPhoneBirthday);
            this.grpInfo.Controls.Add(this.lblRetireDate);
            this.grpInfo.Controls.Add(this.lblEnterDate);
            this.grpInfo.Controls.Add(this.lblSex);
            this.grpInfo.Controls.Add(this.lblPhoneEmail);
            this.grpInfo.Controls.Add(this.lblPhoneOther);
            this.grpInfo.Controls.Add(this.lblPhoneHome);
            this.grpInfo.Controls.Add(this.lblPhoneMobile);
            this.grpInfo.Controls.Add(this.lblPhoneOffice);
            this.grpInfo.Controls.Add(this.lblSecGrpId);
            this.grpInfo.Controls.Add(this.lblPassword);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInfo.Location = new System.Drawing.Point(3, 0);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(486, 231);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            // 
            // rbnGroup
            // 
            this.rbnGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnGroup.Location = new System.Drawing.Point(280, 88);
            this.rbnGroup.Name = "rbnGroup";
            this.rbnGroup.Size = new System.Drawing.Size(60, 18);
            this.rbnGroup.TabIndex = 10;
            this.rbnGroup.Text = "Group";
            // 
            // udtRetireDate
            // 
            this.udtRetireDate.DateTime = new System.DateTime(2007, 10, 8, 0, 0, 0, 0);
            this.udtRetireDate.FormatString = "";
            this.udtRetireDate.Location = new System.Drawing.Point(352, 158);
            this.udtRetireDate.Name = "udtRetireDate";
            this.udtRetireDate.Size = new System.Drawing.Size(126, 21);
            this.udtRetireDate.TabIndex = 24;
            this.udtRetireDate.Value = new System.DateTime(2007, 10, 8, 0, 0, 0, 0);
            // 
            // udtEnterDate
            // 
            this.udtEnterDate.DateTime = new System.DateTime(2007, 10, 8, 0, 0, 0, 0);
            this.udtEnterDate.FormatString = "";
            this.udtEnterDate.Location = new System.Drawing.Point(352, 134);
            this.udtEnterDate.Name = "udtEnterDate";
            this.udtEnterDate.Size = new System.Drawing.Size(126, 21);
            this.udtEnterDate.TabIndex = 22;
            this.udtEnterDate.Value = new System.DateTime(2007, 10, 8, 0, 0, 0, 0);
            // 
            // udtBirthDay
            // 
            this.udtBirthDay.DateTime = new System.DateTime(2007, 10, 8, 0, 0, 0, 0);
            this.udtBirthDay.FormatString = "";
            this.udtBirthDay.Location = new System.Drawing.Point(352, 108);
            this.udtBirthDay.MaskInput = "";
            this.udtBirthDay.Name = "udtBirthDay";
            this.udtBirthDay.Size = new System.Drawing.Size(126, 21);
            this.udtBirthDay.TabIndex = 20;
            this.udtBirthDay.Value = new System.DateTime(2007, 10, 8, 0, 0, 0, 0);
            // 
            // rbnFemale
            // 
            this.rbnFemale.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnFemale.Location = new System.Drawing.Point(198, 88);
            this.rbnFemale.Name = "rbnFemale";
            this.rbnFemale.Size = new System.Drawing.Size(65, 18);
            this.rbnFemale.TabIndex = 9;
            this.rbnFemale.Text = "Female";
            // 
            // rbnMale
            // 
            this.rbnMale.Checked = true;
            this.rbnMale.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnMale.Location = new System.Drawing.Point(122, 88);
            this.rbnMale.Name = "rbnMale";
            this.rbnMale.Size = new System.Drawing.Size(54, 18);
            this.rbnMale.TabIndex = 8;
            this.rbnMale.TabStop = true;
            this.rbnMale.Text = "Male";
            // 
            // chkChangePassFlag
            // 
            this.chkChangePassFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkChangePassFlag.Location = new System.Drawing.Point(288, 19);
            this.chkChangePassFlag.Name = "chkChangePassFlag";
            this.chkChangePassFlag.Size = new System.Drawing.Size(165, 14);
            this.chkChangePassFlag.TabIndex = 2;
            this.chkChangePassFlag.Text = "Change Password Flag";
            // 
            // cdvSecGrpId
            // 
            this.cdvSecGrpId.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSecGrpId.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSecGrpId.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSecGrpId.BtnToolTipText = "";
            this.cdvSecGrpId.ButtonWidth = 20;
            this.cdvSecGrpId.DescText = "";
            this.cdvSecGrpId.DisplaySubItemIndex = -1;
            this.cdvSecGrpId.DisplayText = "";
            this.cdvSecGrpId.Focusing = null;
            this.cdvSecGrpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSecGrpId.Index = 0;
            this.cdvSecGrpId.IsViewBtnImage = false;
            this.cdvSecGrpId.Location = new System.Drawing.Point(120, 40);
            this.cdvSecGrpId.MaxLength = 20;
            this.cdvSecGrpId.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSecGrpId.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSecGrpId.MultiSelect = false;
            this.cdvSecGrpId.Name = "cdvSecGrpId";
            this.cdvSecGrpId.ReadOnly = false;
            this.cdvSecGrpId.SameWidthHeightOfButton = false;
            this.cdvSecGrpId.SearchSubItemIndex = 0;
            this.cdvSecGrpId.SelectedDescIndex = -1;
            this.cdvSecGrpId.SelectedDescToQueryText = "";
            this.cdvSecGrpId.SelectedSubItemIndex = -1;
            this.cdvSecGrpId.SelectedValueToQueryText = "";
            this.cdvSecGrpId.SelectionStart = 0;
            this.cdvSecGrpId.Size = new System.Drawing.Size(150, 20);
            this.cdvSecGrpId.SmallImageList = null;
            this.cdvSecGrpId.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSecGrpId.TabIndex = 4;
            this.cdvSecGrpId.TextBoxToolTipText = "";
            this.cdvSecGrpId.TextBoxWidth = 150;
            this.cdvSecGrpId.VisibleButton = true;
            this.cdvSecGrpId.VisibleColumnHeader = false;
            this.cdvSecGrpId.VisibleDescription = false;
            this.cdvSecGrpId.ButtonPress += new System.EventHandler(this.cdvSecGrpId_ButtonPress);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 64);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(358, 20);
            this.txtEmail.TabIndex = 6;
            // 
            // txtPhoneOther
            // 
            this.txtPhoneOther.Location = new System.Drawing.Point(120, 182);
            this.txtPhoneOther.MaxLength = 20;
            this.txtPhoneOther.Name = "txtPhoneOther";
            this.txtPhoneOther.Size = new System.Drawing.Size(150, 20);
            this.txtPhoneOther.TabIndex = 18;
            this.txtPhoneOther.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtPhoneHome
            // 
            this.txtPhoneHome.Location = new System.Drawing.Point(120, 134);
            this.txtPhoneHome.MaxLength = 20;
            this.txtPhoneHome.Name = "txtPhoneHome";
            this.txtPhoneHome.Size = new System.Drawing.Size(150, 20);
            this.txtPhoneHome.TabIndex = 14;
            this.txtPhoneHome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtPhoneMobile
            // 
            this.txtPhoneMobile.Location = new System.Drawing.Point(120, 158);
            this.txtPhoneMobile.MaxLength = 20;
            this.txtPhoneMobile.Name = "txtPhoneMobile";
            this.txtPhoneMobile.Size = new System.Drawing.Size(150, 20);
            this.txtPhoneMobile.TabIndex = 16;
            this.txtPhoneMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtPhoneOffice
            // 
            this.txtPhoneOffice.Location = new System.Drawing.Point(120, 110);
            this.txtPhoneOffice.MaxLength = 20;
            this.txtPhoneOffice.Name = "txtPhoneOffice";
            this.txtPhoneOffice.Size = new System.Drawing.Size(150, 20);
            this.txtPhoneOffice.TabIndex = 12;
            this.txtPhoneOffice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Location = new System.Drawing.Point(120, 16);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(150, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // lblPhoneBirthday
            // 
            this.lblPhoneBirthday.AutoSize = true;
            this.lblPhoneBirthday.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPhoneBirthday.Location = new System.Drawing.Point(280, 111);
            this.lblPhoneBirthday.Name = "lblPhoneBirthday";
            this.lblPhoneBirthday.Size = new System.Drawing.Size(45, 13);
            this.lblPhoneBirthday.TabIndex = 19;
            this.lblPhoneBirthday.Text = "Birthday";
            // 
            // lblRetireDate
            // 
            this.lblRetireDate.AutoSize = true;
            this.lblRetireDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRetireDate.Location = new System.Drawing.Point(280, 161);
            this.lblRetireDate.Name = "lblRetireDate";
            this.lblRetireDate.Size = new System.Drawing.Size(61, 13);
            this.lblRetireDate.TabIndex = 23;
            this.lblRetireDate.Text = "Retire Date";
            // 
            // lblEnterDate
            // 
            this.lblEnterDate.AutoSize = true;
            this.lblEnterDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEnterDate.Location = new System.Drawing.Point(280, 137);
            this.lblEnterDate.Name = "lblEnterDate";
            this.lblEnterDate.Size = new System.Drawing.Size(58, 13);
            this.lblEnterDate.TabIndex = 21;
            this.lblEnterDate.Text = "Enter Date";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSex.Location = new System.Drawing.Point(15, 90);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(28, 13);
            this.lblSex.TabIndex = 7;
            this.lblSex.Text = "Sex";
            // 
            // lblPhoneEmail
            // 
            this.lblPhoneEmail.AutoSize = true;
            this.lblPhoneEmail.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPhoneEmail.Location = new System.Drawing.Point(15, 66);
            this.lblPhoneEmail.Name = "lblPhoneEmail";
            this.lblPhoneEmail.Size = new System.Drawing.Size(32, 13);
            this.lblPhoneEmail.TabIndex = 5;
            this.lblPhoneEmail.Text = "Email";
            // 
            // lblPhoneOther
            // 
            this.lblPhoneOther.AutoSize = true;
            this.lblPhoneOther.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPhoneOther.Location = new System.Drawing.Point(15, 185);
            this.lblPhoneOther.Name = "lblPhoneOther";
            this.lblPhoneOther.Size = new System.Drawing.Size(67, 13);
            this.lblPhoneOther.TabIndex = 17;
            this.lblPhoneOther.Text = "Phone Other";
            // 
            // lblPhoneHome
            // 
            this.lblPhoneHome.AutoSize = true;
            this.lblPhoneHome.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPhoneHome.Location = new System.Drawing.Point(15, 137);
            this.lblPhoneHome.Name = "lblPhoneHome";
            this.lblPhoneHome.Size = new System.Drawing.Size(69, 13);
            this.lblPhoneHome.TabIndex = 13;
            this.lblPhoneHome.Text = "Phone Home";
            // 
            // lblPhoneMobile
            // 
            this.lblPhoneMobile.AutoSize = true;
            this.lblPhoneMobile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPhoneMobile.Location = new System.Drawing.Point(15, 161);
            this.lblPhoneMobile.Name = "lblPhoneMobile";
            this.lblPhoneMobile.Size = new System.Drawing.Size(72, 13);
            this.lblPhoneMobile.TabIndex = 15;
            this.lblPhoneMobile.Text = "Phone Mobile";
            // 
            // lblPhoneOffice
            // 
            this.lblPhoneOffice.AutoSize = true;
            this.lblPhoneOffice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPhoneOffice.Location = new System.Drawing.Point(15, 113);
            this.lblPhoneOffice.Name = "lblPhoneOffice";
            this.lblPhoneOffice.Size = new System.Drawing.Size(69, 13);
            this.lblPhoneOffice.TabIndex = 11;
            this.lblPhoneOffice.Text = "Phone Office";
            // 
            // lblSecGrpId
            // 
            this.lblSecGrpId.AutoSize = true;
            this.lblSecGrpId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSecGrpId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecGrpId.Location = new System.Drawing.Point(15, 43);
            this.lblSecGrpId.Name = "lblSecGrpId";
            this.lblSecGrpId.Size = new System.Drawing.Size(91, 13);
            this.lblSecGrpId.TabIndex = 3;
            this.lblSecGrpId.Text = "Security Group";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(15, 19);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password";
            // 
            // tbpGroup
            // 
            this.tbpGroup.Controls.Add(this.grpGroup);
            this.tbpGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpGroup.Name = "tbpGroup";
            this.tbpGroup.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpGroup.Size = new System.Drawing.Size(492, 401);
            this.tbpGroup.TabIndex = 1;
            this.tbpGroup.Text = "Group Setup";
            this.tbpGroup.Visible = false;
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.cdvGroup10);
            this.grpGroup.Controls.Add(this.cdvGroup9);
            this.grpGroup.Controls.Add(this.cdvGroup8);
            this.grpGroup.Controls.Add(this.cdvGroup7);
            this.grpGroup.Controls.Add(this.cdvGroup6);
            this.grpGroup.Controls.Add(this.cdvGroup5);
            this.grpGroup.Controls.Add(this.cdvGroup4);
            this.grpGroup.Controls.Add(this.cdvGroup3);
            this.grpGroup.Controls.Add(this.cdvGroup2);
            this.grpGroup.Controls.Add(this.cdvGroup1);
            this.grpGroup.Controls.Add(this.lblGroup10);
            this.grpGroup.Controls.Add(this.lblGroup9);
            this.grpGroup.Controls.Add(this.lblGroup8);
            this.grpGroup.Controls.Add(this.lblGroup7);
            this.grpGroup.Controls.Add(this.lblGroup6);
            this.grpGroup.Controls.Add(this.lblGroup5);
            this.grpGroup.Controls.Add(this.lblGroup4);
            this.grpGroup.Controls.Add(this.lblGroup3);
            this.grpGroup.Controls.Add(this.lblGroup2);
            this.grpGroup.Controls.Add(this.lblGroup1);
            this.grpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpGroup.Location = new System.Drawing.Point(3, 5);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(486, 393);
            this.grpGroup.TabIndex = 0;
            this.grpGroup.TabStop = false;
            this.grpGroup.Text = "User Group (1~10)";
            // 
            // cdvGroup10
            // 
            this.cdvGroup10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup10.BtnToolTipText = "";
            this.cdvGroup10.ButtonWidth = 20;
            this.cdvGroup10.DescText = "";
            this.cdvGroup10.DisplaySubItemIndex = -1;
            this.cdvGroup10.DisplayText = "";
            this.cdvGroup10.Focusing = null;
            this.cdvGroup10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup10.Index = 9;
            this.cdvGroup10.IsViewBtnImage = false;
            this.cdvGroup10.Location = new System.Drawing.Point(172, 232);
            this.cdvGroup10.MaxLength = 30;
            this.cdvGroup10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.MultiSelect = false;
            this.cdvGroup10.Name = "cdvGroup10";
            this.cdvGroup10.ReadOnly = false;
            this.cdvGroup10.SameWidthHeightOfButton = false;
            this.cdvGroup10.SearchSubItemIndex = 0;
            this.cdvGroup10.SelectedDescIndex = -1;
            this.cdvGroup10.SelectedDescToQueryText = "";
            this.cdvGroup10.SelectedSubItemIndex = -1;
            this.cdvGroup10.SelectedValueToQueryText = "";
            this.cdvGroup10.SelectionStart = 0;
            this.cdvGroup10.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup10.SmallImageList = null;
            this.cdvGroup10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup10.TabIndex = 19;
            this.cdvGroup10.TextBoxToolTipText = "";
            this.cdvGroup10.TextBoxWidth = 200;
            this.cdvGroup10.VisibleButton = true;
            this.cdvGroup10.VisibleColumnHeader = false;
            this.cdvGroup10.VisibleDescription = false;
            this.cdvGroup10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup9
            // 
            this.cdvGroup9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup9.BtnToolTipText = "";
            this.cdvGroup9.ButtonWidth = 20;
            this.cdvGroup9.DescText = "";
            this.cdvGroup9.DisplaySubItemIndex = -1;
            this.cdvGroup9.DisplayText = "";
            this.cdvGroup9.Focusing = null;
            this.cdvGroup9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup9.Index = 8;
            this.cdvGroup9.IsViewBtnImage = false;
            this.cdvGroup9.Location = new System.Drawing.Point(172, 208);
            this.cdvGroup9.MaxLength = 30;
            this.cdvGroup9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.MultiSelect = false;
            this.cdvGroup9.Name = "cdvGroup9";
            this.cdvGroup9.ReadOnly = false;
            this.cdvGroup9.SameWidthHeightOfButton = false;
            this.cdvGroup9.SearchSubItemIndex = 0;
            this.cdvGroup9.SelectedDescIndex = -1;
            this.cdvGroup9.SelectedDescToQueryText = "";
            this.cdvGroup9.SelectedSubItemIndex = -1;
            this.cdvGroup9.SelectedValueToQueryText = "";
            this.cdvGroup9.SelectionStart = 0;
            this.cdvGroup9.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup9.SmallImageList = null;
            this.cdvGroup9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup9.TabIndex = 17;
            this.cdvGroup9.TextBoxToolTipText = "";
            this.cdvGroup9.TextBoxWidth = 200;
            this.cdvGroup9.VisibleButton = true;
            this.cdvGroup9.VisibleColumnHeader = false;
            this.cdvGroup9.VisibleDescription = false;
            this.cdvGroup9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup8
            // 
            this.cdvGroup8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup8.BtnToolTipText = "";
            this.cdvGroup8.ButtonWidth = 20;
            this.cdvGroup8.DescText = "";
            this.cdvGroup8.DisplaySubItemIndex = -1;
            this.cdvGroup8.DisplayText = "";
            this.cdvGroup8.Focusing = null;
            this.cdvGroup8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup8.Index = 7;
            this.cdvGroup8.IsViewBtnImage = false;
            this.cdvGroup8.Location = new System.Drawing.Point(172, 184);
            this.cdvGroup8.MaxLength = 30;
            this.cdvGroup8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.MultiSelect = false;
            this.cdvGroup8.Name = "cdvGroup8";
            this.cdvGroup8.ReadOnly = false;
            this.cdvGroup8.SameWidthHeightOfButton = false;
            this.cdvGroup8.SearchSubItemIndex = 0;
            this.cdvGroup8.SelectedDescIndex = -1;
            this.cdvGroup8.SelectedDescToQueryText = "";
            this.cdvGroup8.SelectedSubItemIndex = -1;
            this.cdvGroup8.SelectedValueToQueryText = "";
            this.cdvGroup8.SelectionStart = 0;
            this.cdvGroup8.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup8.SmallImageList = null;
            this.cdvGroup8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup8.TabIndex = 15;
            this.cdvGroup8.TextBoxToolTipText = "";
            this.cdvGroup8.TextBoxWidth = 200;
            this.cdvGroup8.VisibleButton = true;
            this.cdvGroup8.VisibleColumnHeader = false;
            this.cdvGroup8.VisibleDescription = false;
            this.cdvGroup8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup7
            // 
            this.cdvGroup7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup7.BtnToolTipText = "";
            this.cdvGroup7.ButtonWidth = 20;
            this.cdvGroup7.DescText = "";
            this.cdvGroup7.DisplaySubItemIndex = -1;
            this.cdvGroup7.DisplayText = "";
            this.cdvGroup7.Focusing = null;
            this.cdvGroup7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup7.Index = 6;
            this.cdvGroup7.IsViewBtnImage = false;
            this.cdvGroup7.Location = new System.Drawing.Point(172, 160);
            this.cdvGroup7.MaxLength = 30;
            this.cdvGroup7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.MultiSelect = false;
            this.cdvGroup7.Name = "cdvGroup7";
            this.cdvGroup7.ReadOnly = false;
            this.cdvGroup7.SameWidthHeightOfButton = false;
            this.cdvGroup7.SearchSubItemIndex = 0;
            this.cdvGroup7.SelectedDescIndex = -1;
            this.cdvGroup7.SelectedDescToQueryText = "";
            this.cdvGroup7.SelectedSubItemIndex = -1;
            this.cdvGroup7.SelectedValueToQueryText = "";
            this.cdvGroup7.SelectionStart = 0;
            this.cdvGroup7.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup7.SmallImageList = null;
            this.cdvGroup7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup7.TabIndex = 13;
            this.cdvGroup7.TextBoxToolTipText = "";
            this.cdvGroup7.TextBoxWidth = 200;
            this.cdvGroup7.VisibleButton = true;
            this.cdvGroup7.VisibleColumnHeader = false;
            this.cdvGroup7.VisibleDescription = false;
            this.cdvGroup7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup6
            // 
            this.cdvGroup6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup6.BtnToolTipText = "";
            this.cdvGroup6.ButtonWidth = 20;
            this.cdvGroup6.DescText = "";
            this.cdvGroup6.DisplaySubItemIndex = -1;
            this.cdvGroup6.DisplayText = "";
            this.cdvGroup6.Focusing = null;
            this.cdvGroup6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup6.Index = 5;
            this.cdvGroup6.IsViewBtnImage = false;
            this.cdvGroup6.Location = new System.Drawing.Point(172, 136);
            this.cdvGroup6.MaxLength = 30;
            this.cdvGroup6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.MultiSelect = false;
            this.cdvGroup6.Name = "cdvGroup6";
            this.cdvGroup6.ReadOnly = false;
            this.cdvGroup6.SameWidthHeightOfButton = false;
            this.cdvGroup6.SearchSubItemIndex = 0;
            this.cdvGroup6.SelectedDescIndex = -1;
            this.cdvGroup6.SelectedDescToQueryText = "";
            this.cdvGroup6.SelectedSubItemIndex = -1;
            this.cdvGroup6.SelectedValueToQueryText = "";
            this.cdvGroup6.SelectionStart = 0;
            this.cdvGroup6.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup6.SmallImageList = null;
            this.cdvGroup6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup6.TabIndex = 11;
            this.cdvGroup6.TextBoxToolTipText = "";
            this.cdvGroup6.TextBoxWidth = 200;
            this.cdvGroup6.VisibleButton = true;
            this.cdvGroup6.VisibleColumnHeader = false;
            this.cdvGroup6.VisibleDescription = false;
            this.cdvGroup6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup5
            // 
            this.cdvGroup5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup5.BtnToolTipText = "";
            this.cdvGroup5.ButtonWidth = 20;
            this.cdvGroup5.DescText = "";
            this.cdvGroup5.DisplaySubItemIndex = -1;
            this.cdvGroup5.DisplayText = "";
            this.cdvGroup5.Focusing = null;
            this.cdvGroup5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup5.Index = 4;
            this.cdvGroup5.IsViewBtnImage = false;
            this.cdvGroup5.Location = new System.Drawing.Point(172, 112);
            this.cdvGroup5.MaxLength = 30;
            this.cdvGroup5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.MultiSelect = false;
            this.cdvGroup5.Name = "cdvGroup5";
            this.cdvGroup5.ReadOnly = false;
            this.cdvGroup5.SameWidthHeightOfButton = false;
            this.cdvGroup5.SearchSubItemIndex = 0;
            this.cdvGroup5.SelectedDescIndex = -1;
            this.cdvGroup5.SelectedDescToQueryText = "";
            this.cdvGroup5.SelectedSubItemIndex = -1;
            this.cdvGroup5.SelectedValueToQueryText = "";
            this.cdvGroup5.SelectionStart = 0;
            this.cdvGroup5.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup5.SmallImageList = null;
            this.cdvGroup5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup5.TabIndex = 9;
            this.cdvGroup5.TextBoxToolTipText = "";
            this.cdvGroup5.TextBoxWidth = 200;
            this.cdvGroup5.VisibleButton = true;
            this.cdvGroup5.VisibleColumnHeader = false;
            this.cdvGroup5.VisibleDescription = false;
            this.cdvGroup5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup4
            // 
            this.cdvGroup4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup4.BtnToolTipText = "";
            this.cdvGroup4.ButtonWidth = 20;
            this.cdvGroup4.DescText = "";
            this.cdvGroup4.DisplaySubItemIndex = -1;
            this.cdvGroup4.DisplayText = "";
            this.cdvGroup4.Focusing = null;
            this.cdvGroup4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup4.Index = 3;
            this.cdvGroup4.IsViewBtnImage = false;
            this.cdvGroup4.Location = new System.Drawing.Point(172, 88);
            this.cdvGroup4.MaxLength = 30;
            this.cdvGroup4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.MultiSelect = false;
            this.cdvGroup4.Name = "cdvGroup4";
            this.cdvGroup4.ReadOnly = false;
            this.cdvGroup4.SameWidthHeightOfButton = false;
            this.cdvGroup4.SearchSubItemIndex = 0;
            this.cdvGroup4.SelectedDescIndex = -1;
            this.cdvGroup4.SelectedDescToQueryText = "";
            this.cdvGroup4.SelectedSubItemIndex = -1;
            this.cdvGroup4.SelectedValueToQueryText = "";
            this.cdvGroup4.SelectionStart = 0;
            this.cdvGroup4.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup4.SmallImageList = null;
            this.cdvGroup4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup4.TabIndex = 7;
            this.cdvGroup4.TextBoxToolTipText = "";
            this.cdvGroup4.TextBoxWidth = 200;
            this.cdvGroup4.VisibleButton = true;
            this.cdvGroup4.VisibleColumnHeader = false;
            this.cdvGroup4.VisibleDescription = false;
            this.cdvGroup4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup3
            // 
            this.cdvGroup3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup3.BtnToolTipText = "";
            this.cdvGroup3.ButtonWidth = 20;
            this.cdvGroup3.DescText = "";
            this.cdvGroup3.DisplaySubItemIndex = -1;
            this.cdvGroup3.DisplayText = "";
            this.cdvGroup3.Focusing = null;
            this.cdvGroup3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup3.Index = 2;
            this.cdvGroup3.IsViewBtnImage = false;
            this.cdvGroup3.Location = new System.Drawing.Point(172, 64);
            this.cdvGroup3.MaxLength = 30;
            this.cdvGroup3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.MultiSelect = false;
            this.cdvGroup3.Name = "cdvGroup3";
            this.cdvGroup3.ReadOnly = false;
            this.cdvGroup3.SameWidthHeightOfButton = false;
            this.cdvGroup3.SearchSubItemIndex = 0;
            this.cdvGroup3.SelectedDescIndex = -1;
            this.cdvGroup3.SelectedDescToQueryText = "";
            this.cdvGroup3.SelectedSubItemIndex = -1;
            this.cdvGroup3.SelectedValueToQueryText = "";
            this.cdvGroup3.SelectionStart = 0;
            this.cdvGroup3.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup3.SmallImageList = null;
            this.cdvGroup3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup3.TabIndex = 5;
            this.cdvGroup3.TextBoxToolTipText = "";
            this.cdvGroup3.TextBoxWidth = 200;
            this.cdvGroup3.VisibleButton = true;
            this.cdvGroup3.VisibleColumnHeader = false;
            this.cdvGroup3.VisibleDescription = false;
            this.cdvGroup3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup2
            // 
            this.cdvGroup2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup2.BtnToolTipText = "";
            this.cdvGroup2.ButtonWidth = 20;
            this.cdvGroup2.DescText = "";
            this.cdvGroup2.DisplaySubItemIndex = -1;
            this.cdvGroup2.DisplayText = "";
            this.cdvGroup2.Focusing = null;
            this.cdvGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup2.Index = 1;
            this.cdvGroup2.IsViewBtnImage = false;
            this.cdvGroup2.Location = new System.Drawing.Point(172, 40);
            this.cdvGroup2.MaxLength = 30;
            this.cdvGroup2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.MultiSelect = false;
            this.cdvGroup2.Name = "cdvGroup2";
            this.cdvGroup2.ReadOnly = false;
            this.cdvGroup2.SameWidthHeightOfButton = false;
            this.cdvGroup2.SearchSubItemIndex = 0;
            this.cdvGroup2.SelectedDescIndex = -1;
            this.cdvGroup2.SelectedDescToQueryText = "";
            this.cdvGroup2.SelectedSubItemIndex = -1;
            this.cdvGroup2.SelectedValueToQueryText = "";
            this.cdvGroup2.SelectionStart = 0;
            this.cdvGroup2.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup2.SmallImageList = null;
            this.cdvGroup2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup2.TabIndex = 3;
            this.cdvGroup2.TextBoxToolTipText = "";
            this.cdvGroup2.TextBoxWidth = 200;
            this.cdvGroup2.VisibleButton = true;
            this.cdvGroup2.VisibleColumnHeader = false;
            this.cdvGroup2.VisibleDescription = false;
            this.cdvGroup2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup1
            // 
            this.cdvGroup1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup1.BtnToolTipText = "";
            this.cdvGroup1.ButtonWidth = 20;
            this.cdvGroup1.DescText = "";
            this.cdvGroup1.DisplaySubItemIndex = -1;
            this.cdvGroup1.DisplayText = "";
            this.cdvGroup1.Focusing = null;
            this.cdvGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup1.Index = 0;
            this.cdvGroup1.IsViewBtnImage = false;
            this.cdvGroup1.Location = new System.Drawing.Point(172, 16);
            this.cdvGroup1.MaxLength = 30;
            this.cdvGroup1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MultiSelect = false;
            this.cdvGroup1.Name = "cdvGroup1";
            this.cdvGroup1.ReadOnly = false;
            this.cdvGroup1.SameWidthHeightOfButton = false;
            this.cdvGroup1.SearchSubItemIndex = 0;
            this.cdvGroup1.SelectedDescIndex = -1;
            this.cdvGroup1.SelectedDescToQueryText = "";
            this.cdvGroup1.SelectedSubItemIndex = -1;
            this.cdvGroup1.SelectedValueToQueryText = "";
            this.cdvGroup1.SelectionStart = 0;
            this.cdvGroup1.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup1.SmallImageList = null;
            this.cdvGroup1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup1.TabIndex = 1;
            this.cdvGroup1.TextBoxToolTipText = "";
            this.cdvGroup1.TextBoxWidth = 200;
            this.cdvGroup1.VisibleButton = true;
            this.cdvGroup1.VisibleColumnHeader = false;
            this.cdvGroup1.VisibleDescription = false;
            this.cdvGroup1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // lblGroup10
            // 
            this.lblGroup10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup10.Location = new System.Drawing.Point(15, 235);
            this.lblGroup10.Name = "lblGroup10";
            this.lblGroup10.Size = new System.Drawing.Size(150, 14);
            this.lblGroup10.TabIndex = 18;
            // 
            // lblGroup9
            // 
            this.lblGroup9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup9.Location = new System.Drawing.Point(15, 211);
            this.lblGroup9.Name = "lblGroup9";
            this.lblGroup9.Size = new System.Drawing.Size(150, 14);
            this.lblGroup9.TabIndex = 16;
            // 
            // lblGroup8
            // 
            this.lblGroup8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup8.Location = new System.Drawing.Point(15, 187);
            this.lblGroup8.Name = "lblGroup8";
            this.lblGroup8.Size = new System.Drawing.Size(150, 14);
            this.lblGroup8.TabIndex = 14;
            // 
            // lblGroup7
            // 
            this.lblGroup7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup7.Location = new System.Drawing.Point(15, 163);
            this.lblGroup7.Name = "lblGroup7";
            this.lblGroup7.Size = new System.Drawing.Size(150, 14);
            this.lblGroup7.TabIndex = 12;
            // 
            // lblGroup6
            // 
            this.lblGroup6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup6.Location = new System.Drawing.Point(15, 139);
            this.lblGroup6.Name = "lblGroup6";
            this.lblGroup6.Size = new System.Drawing.Size(150, 14);
            this.lblGroup6.TabIndex = 10;
            // 
            // lblGroup5
            // 
            this.lblGroup5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup5.Location = new System.Drawing.Point(15, 115);
            this.lblGroup5.Name = "lblGroup5";
            this.lblGroup5.Size = new System.Drawing.Size(150, 14);
            this.lblGroup5.TabIndex = 8;
            // 
            // lblGroup4
            // 
            this.lblGroup4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup4.Location = new System.Drawing.Point(15, 91);
            this.lblGroup4.Name = "lblGroup4";
            this.lblGroup4.Size = new System.Drawing.Size(150, 14);
            this.lblGroup4.TabIndex = 6;
            // 
            // lblGroup3
            // 
            this.lblGroup3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup3.Location = new System.Drawing.Point(15, 67);
            this.lblGroup3.Name = "lblGroup3";
            this.lblGroup3.Size = new System.Drawing.Size(150, 14);
            this.lblGroup3.TabIndex = 4;
            // 
            // lblGroup2
            // 
            this.lblGroup2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup2.Location = new System.Drawing.Point(15, 43);
            this.lblGroup2.Name = "lblGroup2";
            this.lblGroup2.Size = new System.Drawing.Size(150, 14);
            this.lblGroup2.TabIndex = 2;
            // 
            // lblGroup1
            // 
            this.lblGroup1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup1.Location = new System.Drawing.Point(15, 19);
            this.lblGroup1.Name = "lblGroup1";
            this.lblGroup1.Size = new System.Drawing.Size(150, 14);
            this.lblGroup1.TabIndex = 0;
            // 
            // tabCMF
            // 
            this.tabCMF.Controls.Add(this.grpCMF);
            this.tabCMF.Location = new System.Drawing.Point(4, 22);
            this.tabCMF.Name = "tabCMF";
            this.tabCMF.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tabCMF.Size = new System.Drawing.Size(492, 401);
            this.tabCMF.TabIndex = 2;
            this.tabCMF.Text = "Customized Field";
            this.tabCMF.Visible = false;
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.cdvCMF5);
            this.grpCMF.Controls.Add(this.cdvCMF10);
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF4);
            this.grpCMF.Controls.Add(this.cdvCMF3);
            this.grpCMF.Controls.Add(this.cdvCMF2);
            this.grpCMF.Controls.Add(this.cdvCMF1);
            this.grpCMF.Controls.Add(this.lblCMF10);
            this.grpCMF.Controls.Add(this.lblCMF9);
            this.grpCMF.Controls.Add(this.lblCMF8);
            this.grpCMF.Controls.Add(this.lblCMF7);
            this.grpCMF.Controls.Add(this.lblCMF6);
            this.grpCMF.Controls.Add(this.lblCMF5);
            this.grpCMF.Controls.Add(this.lblCMF4);
            this.grpCMF.Controls.Add(this.lblCMF3);
            this.grpCMF.Controls.Add(this.lblCMF2);
            this.grpCMF.Controls.Add(this.lblCMF1);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpCMF.Location = new System.Drawing.Point(3, 5);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(486, 393);
            this.grpCMF.TabIndex = 0;
            this.grpCMF.TabStop = false;
            this.grpCMF.Text = "Customized Field (1~10)";
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.ButtonWidth = 20;
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 4;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(172, 112);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MultiSelect = false;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SameWidthHeightOfButton = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedDescToQueryText = "";
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectedValueToQueryText = "";
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 200;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.ButtonWidth = 20;
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 9;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(172, 232);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MultiSelect = false;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SameWidthHeightOfButton = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedDescToQueryText = "";
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectedValueToQueryText = "";
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 200;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.ButtonWidth = 20;
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 8;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(172, 208);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MultiSelect = false;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SameWidthHeightOfButton = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedDescToQueryText = "";
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectedValueToQueryText = "";
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 200;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            this.cdvCMF9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF8.BtnToolTipText = "";
            this.cdvCMF8.ButtonWidth = 20;
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 7;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(172, 184);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MultiSelect = false;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SameWidthHeightOfButton = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedDescToQueryText = "";
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectedValueToQueryText = "";
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 200;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            this.cdvCMF8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF7.BtnToolTipText = "";
            this.cdvCMF7.ButtonWidth = 20;
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 6;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(172, 160);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MultiSelect = false;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SameWidthHeightOfButton = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedDescToQueryText = "";
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectedValueToQueryText = "";
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 200;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            this.cdvCMF7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF6.BtnToolTipText = "";
            this.cdvCMF6.ButtonWidth = 20;
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 5;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(172, 136);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MultiSelect = false;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SameWidthHeightOfButton = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedDescToQueryText = "";
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectedValueToQueryText = "";
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 200;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.ButtonWidth = 20;
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 3;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(172, 88);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MultiSelect = false;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SameWidthHeightOfButton = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedDescToQueryText = "";
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectedValueToQueryText = "";
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 200;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            this.cdvCMF4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF3.BtnToolTipText = "";
            this.cdvCMF3.ButtonWidth = 20;
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 2;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(172, 64);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MultiSelect = false;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SameWidthHeightOfButton = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedDescToQueryText = "";
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectedValueToQueryText = "";
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 200;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            this.cdvCMF3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF2.BtnToolTipText = "";
            this.cdvCMF2.ButtonWidth = 20;
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 1;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(172, 40);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MultiSelect = false;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SameWidthHeightOfButton = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedDescToQueryText = "";
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectedValueToQueryText = "";
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 200;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF1.BtnToolTipText = "";
            this.cdvCMF1.ButtonWidth = 20;
            this.cdvCMF1.DescText = "";
            this.cdvCMF1.DisplaySubItemIndex = -1;
            this.cdvCMF1.DisplayText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(172, 16);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MultiSelect = false;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SameWidthHeightOfButton = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedDescToQueryText = "";
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectedValueToQueryText = "";
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 200;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF10.Location = new System.Drawing.Point(15, 235);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(150, 14);
            this.lblCMF10.TabIndex = 18;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF9.Location = new System.Drawing.Point(15, 211);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(150, 14);
            this.lblCMF9.TabIndex = 16;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF8.Location = new System.Drawing.Point(15, 187);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(150, 14);
            this.lblCMF8.TabIndex = 14;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF7.Location = new System.Drawing.Point(15, 163);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(150, 14);
            this.lblCMF7.TabIndex = 12;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF6.Location = new System.Drawing.Point(15, 139);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(150, 14);
            this.lblCMF6.TabIndex = 10;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF5.Location = new System.Drawing.Point(15, 115);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(150, 14);
            this.lblCMF5.TabIndex = 8;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF4.Location = new System.Drawing.Point(15, 91);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(150, 14);
            this.lblCMF4.TabIndex = 6;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF3.Location = new System.Drawing.Point(15, 67);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(150, 14);
            this.lblCMF3.TabIndex = 4;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF2.Location = new System.Drawing.Point(15, 43);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(150, 14);
            this.lblCMF2.TabIndex = 2;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF1.Location = new System.Drawing.Point(15, 19);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(150, 14);
            this.lblCMF1.TabIndex = 0;
            // 
            // frmSECSetupUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmSECSetupUser";
            this.Text = "User Setup";
            this.Activated += new System.EventHandler(this.frmSECSetupUser_Activated);
            this.Load += new System.EventHandler(this.frmSECSetupUser_Load);
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
            this.pnlUserList.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.grpUser.ResumeLayout(false);
            this.grpUser.PerformLayout();
            this.pnlTap.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlRelate.ResumeLayout(false);
            this.grpDateTime.ResumeLayout(false);
            this.grpDateTime.PerformLayout();
            this.grpInfoExt.ResumeLayout(false);
            this.grpInfoExt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtExpireDate)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtRetireDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtEnterDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtBirthDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSecGrpId)).EndInit();
            this.tbpGroup.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).EndInit();
            this.tabCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        
        bool LoadFlag;
        
        #endregion
        
        #region " Function Definition"
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            
            try
            {
                switch (FuncName)
                {
                    case "Update_User":
                        
                        if (txtUserId.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtUserId.Select();
                            return false;
                        }
                        switch (ProcStep)
                        {
                            case MPGC.MP_STEP_CREATE:

                                if (MPCF.CheckValue(cdvSecGrpId, 1) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtPasswordChangePeriod, 3) == false)
                                {
                                    return false;
                                }
                                
                                //Group Validation Check
                                if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                                {
                                    return false;
                                }
                                //CMF Validation Check
                                if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                                {
                                    return false;
                                }
                                break;
                                
                                
                                
                                
                            case MPGC.MP_STEP_UPDATE:


                                if (MPCF.CheckValue(cdvSecGrpId, 1) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtPasswordChangePeriod, 3) == false)
                                {
                                    return false;
                                }
                                
                                //Group Validation Check
                                if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                                {
                                    return false;
                                }
                                //CMF Validation Check
                                if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                                {
                                    return false;
                                }
                                break;
                                
                                
                                
                            case MPGC.MP_STEP_DELETE:
                                
                                return true;
                                
                        }
                        break;
                    case "View_user":
                        
                        return true;
                        
                }
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        
        private void ClearData(string ProcStep)
        {
            
            try
            {
                
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this.pnlRight);
                }
                else if (ProcStep == "2")
                {
                    MPCF.ClearList(lisUser, true);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        
        //
        // View_User()
        //       - View User Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_User()
        {
            TRSNode in_node = new TRSNode("VIEW_USER_IN");
            TRSNode out_node = new TRSNode("VIEW_USER_OUT");
            
            try
            {
                ClearData("1");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("USER_ID", lisUser.SelectedItems[0].Text, true);

                if (MPCR.CallService("SEC", "SEC_View_User", in_node, ref out_node) == false)
                {
                    return false;
                }

                //General
                txtUserId.Text = MPCF.Trim(out_node.GetString("USER_ID"));
                txtUserDesc.Text = MPCF.Trim(out_node.GetString("USER_DESC"));
                txtPassword.Text = MPCF.Trim(out_node.GetString("PASSWORD"));
                chkChangePassFlag.Checked = (out_node.GetChar("CHG_PASS_FLAG") == 'Y') ? true : false;
                //Group Setup
                cdvGroup1.Text = MPCF.Trim(out_node.GetString("USER_GRP_1"));
                cdvGroup2.Text = MPCF.Trim(out_node.GetString("USER_GRP_2"));
                cdvGroup3.Text = MPCF.Trim(out_node.GetString("USER_GRP_3"));
                cdvGroup4.Text = MPCF.Trim(out_node.GetString("USER_GRP_4"));
                cdvGroup5.Text = MPCF.Trim(out_node.GetString("USER_GRP_5"));
                cdvGroup6.Text = MPCF.Trim(out_node.GetString("USER_GRP_6"));
                cdvGroup7.Text = MPCF.Trim(out_node.GetString("USER_GRP_7"));
                cdvGroup8.Text = MPCF.Trim(out_node.GetString("USER_GRP_8"));
                cdvGroup9.Text = MPCF.Trim(out_node.GetString("USER_GRP_9"));
                cdvGroup10.Text = MPCF.Trim(out_node.GetString("USER_GRP_10"));
                //Customized Field
                cdvCMF1.Text = MPCF.Trim(out_node.GetString("USER_CMF_1"));
                cdvCMF2.Text = MPCF.Trim(out_node.GetString("USER_CMF_2"));
                cdvCMF3.Text = MPCF.Trim(out_node.GetString("USER_CMF_3"));
                cdvCMF4.Text = MPCF.Trim(out_node.GetString("USER_CMF_4"));
                cdvCMF5.Text = MPCF.Trim(out_node.GetString("USER_CMF_5"));
                cdvCMF6.Text = MPCF.Trim(out_node.GetString("USER_CMF_6"));
                cdvCMF7.Text = MPCF.Trim(out_node.GetString("USER_CMF_7"));
                cdvCMF8.Text = MPCF.Trim(out_node.GetString("USER_CMF_8"));
                cdvCMF9.Text = MPCF.Trim(out_node.GetString("USER_CMF_9"));
                cdvCMF10.Text = MPCF.Trim(out_node.GetString("USER_CMF_10"));

                cdvSecGrpId.Text = MPCF.Trim(out_node.GetString("SEC_GRP_ID"));
                txtPhoneOffice.Text = MPCF.Trim(out_node.GetString("PHONE_OFFICE"));
                txtPhoneMobile.Text = MPCF.Trim(out_node.GetString("PHONE_MOBILE"));
                txtPhoneHome.Text = MPCF.Trim(out_node.GetString("PHONE_HOME"));
                txtPhoneOther.Text = MPCF.Trim(out_node.GetString("PHONE_OTHER"));
                if (out_node.GetString("ENTER_DATE") != "")
                {
                    udtEnterDate.Value = MPCF.ToDate(out_node.GetString("ENTER_DATE"));
                }
                else
                {
                    udtEnterDate.Text = "";
                }
                if (out_node.GetString("RETIRE_DATE") != "")
                {
                    udtRetireDate.Value = MPCF.ToDate(out_node.GetString("RETIRE_DATE"));
                }
                else
                {
                    udtRetireDate.Text = "";
                }
                if (out_node.GetString("BIRTHDAY") != "")
                {
                    udtBirthDay.Value = MPCF.ToDate(out_node.GetString("BIRTHDAY"));
                }
                else
                {
                    udtBirthDay.Text = "";
                }
                txtEmail.Text = MPCF.Trim(out_node.GetString("EMAIL_ID"));
                if (out_node.GetChar("SEX_FLAG") == 'M')
                {
                    rbnMale.Checked = true;
                }
                else if (out_node.GetChar("SEX_FLAG") == 'F')
                {
                    rbnFemale.Checked = true;
                }
                else if (out_node.GetChar("SEX_FLAG") == 'G')
                {
                    rbnGroup.Checked = true;
                }

                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));                
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //
        // View_User_Ext()
        //       - View User Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_User_Ext()
        {
            TRSNode in_node = new TRSNode("VIEW_USER_EXT_IN");
            TRSNode out_node = new TRSNode("VIEW_USER_EXT_OUT");
            
            try
            {
                ClearData("1");
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("USER_ID", lisUser.SelectedItems[0].Text, true);

                if (MPCR.CallService("SEC", "SEC_View_User_Ext", in_node, ref out_node) == false)
                {
                    return false;
                }

                //General
                txtUserId.Text = MPCF.Trim(out_node.GetString("USER_ID"));
                txtUserDesc.Text = MPCF.Trim(out_node.GetString("USER_DESC"));
                txtPassword.Text = MPCF.Trim(out_node.GetString("USER_PASSWORD"));
                chkChangePassFlag.Checked = (out_node.GetChar("CHG_PASS_FLAG") == 'Y') ? true : false;
                //Group Setup
                cdvGroup1.Text = MPCF.Trim(out_node.GetString("USER_GRP_1"));
                cdvGroup2.Text = MPCF.Trim(out_node.GetString("USER_GRP_2"));
                cdvGroup3.Text = MPCF.Trim(out_node.GetString("USER_GRP_3"));
                cdvGroup4.Text = MPCF.Trim(out_node.GetString("USER_GRP_4"));
                cdvGroup5.Text = MPCF.Trim(out_node.GetString("USER_GRP_5"));
                cdvGroup6.Text = MPCF.Trim(out_node.GetString("USER_GRP_6"));
                cdvGroup7.Text = MPCF.Trim(out_node.GetString("USER_GRP_7"));
                cdvGroup8.Text = MPCF.Trim(out_node.GetString("USER_GRP_8"));
                cdvGroup9.Text = MPCF.Trim(out_node.GetString("USER_GRP_9"));
                cdvGroup10.Text = MPCF.Trim(out_node.GetString("USER_GRP_10"));
                //Customized Field
                cdvCMF1.Text = MPCF.Trim(out_node.GetString("USER_CMF_1"));
                cdvCMF2.Text = MPCF.Trim(out_node.GetString("USER_CMF_2"));
                cdvCMF3.Text = MPCF.Trim(out_node.GetString("USER_CMF_3"));
                cdvCMF4.Text = MPCF.Trim(out_node.GetString("USER_CMF_4"));
                cdvCMF5.Text = MPCF.Trim(out_node.GetString("USER_CMF_5"));
                cdvCMF6.Text = MPCF.Trim(out_node.GetString("USER_CMF_6"));
                cdvCMF7.Text = MPCF.Trim(out_node.GetString("USER_CMF_7"));
                cdvCMF8.Text = MPCF.Trim(out_node.GetString("USER_CMF_8"));
                cdvCMF9.Text = MPCF.Trim(out_node.GetString("USER_CMF_9"));
                cdvCMF10.Text = MPCF.Trim(out_node.GetString("USER_CMF_10"));

                cdvSecGrpId.Text = MPCF.Trim(out_node.GetString("SEC_GRP_ID"));
                txtPhoneOffice.Text = MPCF.Trim(out_node.GetString("PHONE_OFFICE"));
                txtPhoneMobile.Text = MPCF.Trim(out_node.GetString("PHONE_MOBILE"));
                txtPhoneHome.Text = MPCF.Trim(out_node.GetString("PHONE_HOME"));
                txtPhoneOther.Text = MPCF.Trim(out_node.GetString("PHONE_OTHER"));
                if (out_node.GetString("ENTER_DATE") != "")
                {
                    udtEnterDate.Value = MPCF.ToDate(out_node.GetString("ENTER_DATE"));
                }
                else
                {
                    udtEnterDate.Text = "";
                }
                if (out_node.GetString("RETIRE_DATE") != "")
                {
                    udtRetireDate.Value = MPCF.ToDate(out_node.GetString("RETIRE_DATE"));
                }
                else
                {
                    udtRetireDate.Text = "";
                }
                if (out_node.GetString("BIRTHDAY") != "")
                {
                    udtBirthDay.Value = MPCF.ToDate(out_node.GetString("BIRTHDAY"));
                }
                else
                {
                    udtBirthDay.Text = "";
                }
                txtEmail.Text = MPCF.Trim(out_node.GetString("EMAIL_ID"));

                if (out_node.GetChar("SEX_FLAG") == 'M')
                {
                    rbnMale.Checked = true;
                }
                else if (out_node.GetChar("SEX_FLAG") == 'F')
                {
                    rbnFemale.Checked = true;
                }
                else if (out_node.GetChar("SEX_FLAG") == 'G')
                {
                    rbnGroup.Checked = true;
                }

                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                
                if (MPCF.Trim(out_node.GetString("EXPIRE_DATE")) != "")
                {
                    DateTime dtime = MPCF.ToDate(out_node.GetString("EXPIRE_DATE"));
                    if(dtime > new DateTime(9998, 12, 31))
                    {
                        dtime = new DateTime(9998, 12, 31);
                    }

                    udtExpireDate.Value = dtime;
                }
                else
                {
                    udtExpireDate.Value = new DateTime(9998, 12, 31);
                }
                
                txtPasswordChangePeriod.Text = out_node.GetInt("PASSWORD_CHANGE_PERIOD").ToString();
                chkChangePasswrdNextLogin.Checked = (out_node.GetChar("CHANGE_PASSWORD_FLAG") == 'Y') ? true : false;
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //
        // Update_User()
        //       - Create/Update/Delete user
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Update_User(char ProcStep)
        {
            
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_USER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("USER_ID", MPCF.Trim(txtUserId.Text), true);
                in_node.AddString("USER_DESC", MPCF.Trim(txtUserDesc.Text));
                in_node.AddString("USER_PASSWORD", MPCF.Trim(txtPassword.Text).ToUpper(), true);
                in_node.AddChar("CHG_PASS_FLAG", (chkChangePassFlag.Checked == true ? 'Y' : ' '));

                in_node.AddString("USER_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("USER_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("USER_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("USER_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("USER_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("USER_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("USER_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("USER_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("USER_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("USER_GRP_10", MPCF.Trim(cdvGroup10.Text));

                in_node.AddString("USER_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("USER_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("USER_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("USER_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("USER_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("USER_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("USER_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("USER_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("USER_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("USER_CMF_10", MPCF.Trim(cdvCMF10.Text));

                in_node.AddString("SEC_GRP_ID", MPCF.Trim(cdvSecGrpId.Text));
                in_node.AddString("PHONE_OFFICE", MPCF.Trim(txtPhoneOffice.Text));
                in_node.AddString("PHONE_MOBILE", MPCF.Trim(txtPhoneMobile.Text));
                in_node.AddString("PHONE_HOME", MPCF.Trim(txtPhoneHome.Text));
                in_node.AddString("PHONE_OTHER", MPCF.Trim(txtPhoneOther.Text));
                
                if (!(udtEnterDate.Value == null))
                {
                    in_node.AddString("ENTER_DATE", MPCF.ToStandardTime(udtEnterDate.DateTime, MPGC.MP_CONVERT_DATE_FORMAT));
                }
                if (!(udtRetireDate.Value == null))
                {
                    in_node.AddString("RETIRE_DATE", MPCF.ToStandardTime(udtRetireDate.DateTime, MPGC.MP_CONVERT_DATE_FORMAT));
                }
                if (!(udtBirthDay.Value == null))
                {
                    in_node.AddString("BIRTHDAY", MPCF.ToStandardTime(udtBirthDay.DateTime, MPGC.MP_CONVERT_DATE_FORMAT));
                }
                
                in_node.AddString("EMAIL_ID", MPCF.Trim(txtEmail.Text));

                if (rbnMale.Checked == true)
                {
                    in_node.AddChar("SEX_FLAG", 'M');
                }
                else if (rbnFemale.Checked == true)
                {
                    in_node.AddChar("SEX_FLAG", 'F');
                }
                else if (rbnGroup.Checked == true)
                {
                    in_node.AddChar("SEX_FLAG", 'G');
                }

                if (MPCR.CallService("SEC", "SEC_Update_User", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisUser.Items.Add(txtUserId.Text, (int)SMALLICON_INDEX.IDX_USER);
                        itm.SubItems.Add(txtUserDesc.Text);
                        itm.Selected = true;
                        lisUser.Sorting = SortOrder.Ascending;
                        lisUser.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisUser, MPCF.Trim(txtUserId.Text), false) == true)
                        {
                            lisUser.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtUserDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisUser, MPCF.Trim(txtUserId.Text), false);
                        if (idx != - 1)
                        {
                            lisUser.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisUser.Items.Count.ToString();
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        //
        // Update_User_Ext()
        //       - Create/Update/Delete user
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Update_User_Ext(char ProcStep)
        {
            
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_USER_EXT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("USER_ID", MPCF.Trim(txtUserId.Text), true);
                in_node.AddString("USER_DESC", MPCF.Trim(txtUserDesc.Text));
                in_node.AddString("USER_PASSWORD", MPCF.Trim(txtPassword.Text).ToUpper(), true);
                in_node.AddChar("CHG_PASS_FLAG", (chkChangePassFlag.Checked == true ? 'Y' : ' '));

                in_node.AddString("USER_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("USER_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("USER_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("USER_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("USER_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("USER_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("USER_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("USER_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("USER_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("USER_GRP_10", MPCF.Trim(cdvGroup10.Text));

                in_node.AddString("USER_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("USER_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("USER_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("USER_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("USER_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("USER_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("USER_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("USER_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("USER_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("USER_CMF_10", MPCF.Trim(cdvCMF10.Text));

                in_node.AddString("SEC_GRP_ID", MPCF.Trim(cdvSecGrpId.Text));
                in_node.AddString("PHONE_OFFICE", MPCF.Trim(txtPhoneOffice.Text));
                in_node.AddString("PHONE_MOBILE", MPCF.Trim(txtPhoneMobile.Text));
                in_node.AddString("PHONE_HOME", MPCF.Trim(txtPhoneHome.Text));
                in_node.AddString("PHONE_OTHER", MPCF.Trim(txtPhoneOther.Text));
                
                if (!(udtEnterDate.Value == null))
                {
                    in_node.AddString("ENTER_DATE", MPCF.ToStandardTime(udtEnterDate.DateTime, MPGC.MP_CONVERT_DATE_FORMAT));
                }
                if (!(udtRetireDate.Value == null))
                {
                    in_node.AddString("RETIRE_DATE", MPCF.ToStandardTime(udtRetireDate.DateTime, MPGC.MP_CONVERT_DATE_FORMAT));
                }
                if (!(udtBirthDay.Value == null))
                {
                    in_node.AddString("BIRTHDAY", MPCF.ToStandardTime(udtBirthDay.DateTime, MPGC.MP_CONVERT_DATE_FORMAT));
                }
                
                in_node.AddString("EMAIL_ID", MPCF.Trim(txtEmail.Text));

                if (rbnMale.Checked == true)
                {
                    in_node.AddChar("SEX_FLAG", 'M');
                }
                else if (rbnFemale.Checked == true)
                {
                    in_node.AddChar("SEX_FLAG", 'F');
                }
                else if (rbnGroup.Checked == true)
                {
                    in_node.AddChar("SEX_FLAG", 'G');
                }
                
                if (udtExpireDate.Value == null)
                {
                    in_node.AddString("EXPIRE_DATE", "99981231");
                }
                else
                {
                    in_node.AddString("EXPIRE_DATE", MPCF.ToStandardTime(udtExpireDate.DateTime, MPGC.MP_CONVERT_DATE_FORMAT));
                }
                
                in_node.AddInt("PASSWORD_CHANGE_PERIOD", MPCF.ToInt(txtPasswordChangePeriod.Text));

                in_node.AddChar("CHANGE_PASSWORD_FLAG", chkChangePasswrdNextLogin.Checked == true ? 'Y' : ' ');
                
                if (chkClearOldPassword.Checked == true)
                {
                    //ê³µë°±??ê²½ìš°ë§??¬ë¦¬???œë‹¤.
                    in_node.AddString("OLD_PASSWORD_1", "", true);
                    in_node.AddString("OLD_PASSWORD_2", "", true);
                    in_node.AddString("OLD_PASSWORD_3", "", true);
                    in_node.AddString("OLD_PASSWORD_4", "", true);
                    in_node.AddString("OLD_PASSWORD_5", "", true);
                }
                else
                {
                    in_node.AddString("OLD_PASSWORD_1", "not clear", true);
                    in_node.AddString("OLD_PASSWORD_2", "not clear", true);
                    in_node.AddString("OLD_PASSWORD_3", "not clear", true);
                    in_node.AddString("OLD_PASSWORD_4", "not clear", true);
                    in_node.AddString("OLD_PASSWORD_5", "not clear", true);
                }
                
                if (chkClearLoginFailCount.Checked == true)
                {
                    in_node.AddInt("PASSWORD_FAIL_COUNT", 0);
                }
                else
                {
                    //?„ìƒ? ì?
                    in_node.AddInt("PASSWORD_FAIL_COUNT", 1);
                }

                if (MPCR.CallService("SEC", "SEC_Update_User_Ext", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisUser.Items.Add(txtUserId.Text, (int)SMALLICON_INDEX.IDX_USER);
                        itm.SubItems.Add(txtUserDesc.Text);
                        itm.Selected = true;
                        lisUser.Sorting = SortOrder.Ascending;
                        lisUser.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisUser, MPCF.Trim(txtUserId.Text), false) == true)
                        {
                            lisUser.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtUserDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisUser, MPCF.Trim(txtUserId.Text), false);
                        if (idx != - 1)
                        {
                            lisUser.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisUser.Items.Count.ToString();
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        // SetGroupCmfItem()
        //       - Set Group / Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];
            
            sGrpTableName[0] = MPGC.MP_GCM_USER_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_USER_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_USER_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_USER_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_USER_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_USER_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_USER_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_USER_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_USER_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_USER_GRP_10;
            
            MPCR.SetGRPItem(MPGC.MP_GRP_USER, "lblGroup", "cdvGroup", grpGroup, sGrpTableName);
            MPCR.SetCMFItem(MPGC.MP_CMF_USER, "lblCmf", "cdvCmf", grpCMF);
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisUser;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmSECSetupUser_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(lisUser);
                MPCF.FieldVisible(grpGroup, false);
                MPCF.FieldVisible(grpCMF, false);
                
                #if _PROJECT
                this.grpInfoExt.Visible = false;
                #endif
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmSECSetupUser_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (LoadFlag == false)
                {
                    lblDataCount.Text = "";
                    
                    //Group and CMF Initialize
                    SetGroupCmfItem();
                    
                    if (SECLIST.ViewSECUserList(lisUser, '1', -1, null, "", "") == true)
                    {
                        lblDataCount.Text = lisUser.Items.Count.ToString();
                        if (lisUser.Items.Count > 0)
                        {
                            lisUser.Items[0].Selected = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                    
                    if (MPGV.gbUseSmallLetter == true)
                    {
                        txtUserId.CharacterCasing = CharacterCasing.Normal;
                    }
                    else
                    {
                        txtUserId.CharacterCasing = CharacterCasing.Upper;
                    }
                    
                    LoadFlag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (SECLIST.ViewSECUserList(lisUser, '1', -1, null, "", "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisUser.Items.Count.ToString();
                if (lisUser.Items.Count > 0)
                {
                    MPCF.FindListItem(lisUser, txtUserId.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_User", MPGC.MP_STEP_CREATE) == true)
                {
                    //Add By J.S 2006/4/5  for ASC
                    if (Update_User_Ext(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                
                if (CheckCondition("Update_User", MPGC.MP_STEP_UPDATE) == true)
                {
                    //Add By J.S 2006/4/5  for ASC
                    if (Update_User_Ext(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                
                if (CheckCondition("Update_User", MPGC.MP_STEP_DELETE) == true)
                {
                    //Add By J.S 2006/4/5  for ASC
                    if (Update_User_Ext(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    MPCF.FieldClear(this.pnlRight);
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisUser_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlRight);
                
                if (lisUser.SelectedItems.Count > 0)
                {
                    txtUserId.Text = lisUser.SelectedItems[0].Text;
                    // View_User()
                    //Add By J.S 2006/4/5  for ASC
                    View_User_Ext();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ExportToExcel(lisUser, this.Text, "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvGrpCmf_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCR.ProcGRPCMFButtonPress(sender);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                MPCR.CheckCMFKeyPress(sender, e);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemNextPartial(lisUser, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemPartial(lisUser, txtFind.Text, 0, true, false);
            
        }
        
        private void txtPhone_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (char.IsNumber(e.KeyChar) == false && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvSecGrpId_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                //Initialize Security Group ID List
                cdvSecGrpId.Init();
                MPCF.InitListView(cdvSecGrpId.GetListView);
                cdvSecGrpId.Columns.Add("Group Id", 50, HorizontalAlignment.Left);
                cdvSecGrpId.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvSecGrpId.SelectedSubItemIndex = 0;
                SECLIST.ViewSecGroupList(cdvSecGrpId.GetListView, '1', null, "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        
        private void txtUserId_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (txtPassword.Text == "_NOTCHANGE_PASSWORD_")
                {
                    txtPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void txtPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (txtPassword.Text == "_NOTCHANGE_PASSWORD_")
                {
                    txtPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
    }
    
}
