//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmOption.vb
//   Description : MES Cient Option
//
//   MES Version : 5.3.5.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-10 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

#region " using Definition "

using Miracom.MsgHandler;
using System.Data;
using Miracom.CliFrx;
using System.Collections;

using System.Diagnostics;
using System;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.TRSCore;

#endregion

namespace SOI.OIFrx
{
    public class frmOption : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmOption()
        {
            InitializeComponent();
        }

        public frmOption(bool bRestart)
        {
            InitializeComponent();
            b_restart_flag = bRestart;
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
        protected System.Windows.Forms.Button btnOK;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.TabControl tabOption;
        private System.Windows.Forms.TabPage tbpConn;
        private Miracom.UI.Controls.MCListView.MCListView lisOptionList;
        private System.Windows.Forms.GroupBox grpOption;
        protected System.Windows.Forms.Button btnDel;
        protected System.Windows.Forms.Button btnAdd;
        protected System.Windows.Forms.TextBox txtServerAddress;
        protected System.Windows.Forms.TextBox txtSiteID;
        protected System.Windows.Forms.Label lblSiteID;
        protected System.Windows.Forms.Label lblServerAddr;
        protected System.Windows.Forms.GroupBox grpSystem;
        protected System.Windows.Forms.ComboBox cboLanguage;
        protected System.Windows.Forms.Label lblLanguage;
        protected System.Windows.Forms.Label lblSec;
        protected System.Windows.Forms.TextBox txtTimeOut;
        protected System.Windows.Forms.Label lblTimeOut;
        protected System.Windows.Forms.Label lblMin;
        protected System.Windows.Forms.TextBox txtLogoutTime;
        protected System.Windows.Forms.Label lblLogoutTime;
        private System.Windows.Forms.TabPage tbpUI;
        protected System.Windows.Forms.Panel pnlMainLeft;
        protected System.Windows.Forms.GroupBox grpAutoRefresh;
        protected System.Windows.Forms.Label lblAutoRefreshSec;
        protected System.Windows.Forms.TextBox txtAutoRefreshTime;
        protected System.Windows.Forms.Label lblAutoRefreshTime;
        protected System.Windows.Forms.RadioButton rbnAutoRefreshNo;
        protected System.Windows.Forms.RadioButton rbnAutoRefreshYes;
        protected System.Windows.Forms.GroupBox grpUseGrid;
        protected System.Windows.Forms.RadioButton rbnUseGridNo;
        protected System.Windows.Forms.RadioButton rbnUseGridYes;
        protected System.Windows.Forms.Panel pnlMainRight;
        protected System.Windows.Forms.GroupBox grpListRefresh;
        protected System.Windows.Forms.RadioButton rbnRefreshNo;
        protected System.Windows.Forms.RadioButton rbnRefreshYes;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colSite;
        private System.Windows.Forms.ColumnHeader colServerAdd;
        private System.Windows.Forms.GroupBox grpSuccess;
        private System.Windows.Forms.RadioButton rbnSuccessNo;
        protected TextBox txtRvNetwork;
        protected Label lblRvNetwork;
        protected TextBox txtRvService;
        protected Label lblRvService;
        protected Label lblMin2;
        protected Label lblVerChkTime;
        protected TextBox txtVerChkTime;
        protected GroupBox grpReload;
        protected RadioButton rbnReloadNo;
        protected RadioButton rbnReloadYes;
        protected Panel pnlStationMode;
        protected ComboBox cboStationMode;
        protected Label lblStationMode;
        private ColumnHeader colStationMode;
        private Label lblMsgHandlerType;
        private System.Windows.Forms.GroupBox grpLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbnTuneNo;
        private System.Windows.Forms.RadioButton rbnTuneYes;
        private System.Windows.Forms.CheckBox chkTuneWorkGuide;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResId;
        private GroupBox grpSound;
        private RadioButton rbnSoundNo;
        private RadioButton rbnSoundYes;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvMatType;
        private Label label2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResource;
        private Label label3;
        private System.Windows.Forms.RadioButton rbnSuccessYes;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabOption = new System.Windows.Forms.TabControl();
            this.tbpConn = new System.Windows.Forms.TabPage();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.lblMsgHandlerType = new System.Windows.Forms.Label();
            this.pnlStationMode = new System.Windows.Forms.Panel();
            this.cboStationMode = new System.Windows.Forms.ComboBox();
            this.lblStationMode = new System.Windows.Forms.Label();
            this.txtRvNetwork = new System.Windows.Forms.TextBox();
            this.lblRvNetwork = new System.Windows.Forms.Label();
            this.txtRvService = new System.Windows.Forms.TextBox();
            this.lblRvService = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.txtSiteID = new System.Windows.Forms.TextBox();
            this.lblSiteID = new System.Windows.Forms.Label();
            this.lblServerAddr = new System.Windows.Forms.Label();
            this.lisOptionList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSite = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServerAdd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStationMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpSystem = new System.Windows.Forms.GroupBox();
            this.txtVerChkTime = new System.Windows.Forms.TextBox();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.txtTimeOut = new System.Windows.Forms.TextBox();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.lblMin2 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtLogoutTime = new System.Windows.Forms.TextBox();
            this.lblVerChkTime = new System.Windows.Forms.Label();
            this.lblLogoutTime = new System.Windows.Forms.Label();
            this.tbpUI = new System.Windows.Forms.TabPage();
            this.pnlMainLeft = new System.Windows.Forms.Panel();
            this.grpLine = new System.Windows.Forms.GroupBox();
            this.cdvResource = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label3 = new System.Windows.Forms.Label();
            this.cdvMatType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label2 = new System.Windows.Forms.Label();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLine = new System.Windows.Forms.Label();
            this.grpReload = new System.Windows.Forms.GroupBox();
            this.rbnReloadNo = new System.Windows.Forms.RadioButton();
            this.rbnReloadYes = new System.Windows.Forms.RadioButton();
            this.grpAutoRefresh = new System.Windows.Forms.GroupBox();
            this.lblAutoRefreshSec = new System.Windows.Forms.Label();
            this.txtAutoRefreshTime = new System.Windows.Forms.TextBox();
            this.lblAutoRefreshTime = new System.Windows.Forms.Label();
            this.rbnAutoRefreshNo = new System.Windows.Forms.RadioButton();
            this.rbnAutoRefreshYes = new System.Windows.Forms.RadioButton();
            this.grpUseGrid = new System.Windows.Forms.GroupBox();
            this.rbnUseGridNo = new System.Windows.Forms.RadioButton();
            this.rbnUseGridYes = new System.Windows.Forms.RadioButton();
            this.pnlMainRight = new System.Windows.Forms.Panel();
            this.grpSound = new System.Windows.Forms.GroupBox();
            this.rbnSoundNo = new System.Windows.Forms.RadioButton();
            this.rbnSoundYes = new System.Windows.Forms.RadioButton();
            this.cdvResId = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnTuneNo = new System.Windows.Forms.RadioButton();
            this.rbnTuneYes = new System.Windows.Forms.RadioButton();
            this.chkTuneWorkGuide = new System.Windows.Forms.CheckBox();
            this.grpSuccess = new System.Windows.Forms.GroupBox();
            this.rbnSuccessNo = new System.Windows.Forms.RadioButton();
            this.rbnSuccessYes = new System.Windows.Forms.RadioButton();
            this.grpListRefresh = new System.Windows.Forms.GroupBox();
            this.rbnRefreshNo = new System.Windows.Forms.RadioButton();
            this.rbnRefreshYes = new System.Windows.Forms.RadioButton();
            this.pnlBottom.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabOption.SuspendLayout();
            this.tbpConn.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlStationMode.SuspendLayout();
            this.grpSystem.SuspendLayout();
            this.tbpUI.SuspendLayout();
            this.pnlMainLeft.SuspendLayout();
            this.grpLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            this.grpReload.SuspendLayout();
            this.grpAutoRefresh.SuspendLayout();
            this.grpUseGrid.SuspendLayout();
            this.pnlMainRight.SuspendLayout();
            this.grpSound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResId)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpSuccess.SuspendLayout();
            this.grpListRefresh.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 308);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(3);
            this.pnlBottom.Size = new System.Drawing.Size(514, 36);
            this.pnlBottom.TabIndex = 3;
            this.pnlBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MsgHandlerType_MouseDown);
            this.pnlBottom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MsgHandlerType_MouseUp);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(435, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(353, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabOption);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 0);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlTab.Size = new System.Drawing.Size(514, 308);
            this.pnlTab.TabIndex = 0;
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.tbpConn);
            this.tabOption.Controls.Add(this.tbpUI);
            this.tabOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOption.ItemSize = new System.Drawing.Size(60, 18);
            this.tabOption.Location = new System.Drawing.Point(3, 3);
            this.tabOption.Name = "tabOption";
            this.tabOption.SelectedIndex = 0;
            this.tabOption.Size = new System.Drawing.Size(508, 305);
            this.tabOption.TabIndex = 0;
            this.tabOption.SelectedIndexChanged += new System.EventHandler(this.tabOption_SelectedIndexChanged);
            // 
            // tbpConn
            // 
            this.tbpConn.Controls.Add(this.grpOption);
            this.tbpConn.Controls.Add(this.lisOptionList);
            this.tbpConn.Controls.Add(this.grpSystem);
            this.tbpConn.Location = new System.Drawing.Point(4, 22);
            this.tbpConn.Name = "tbpConn";
            this.tbpConn.Padding = new System.Windows.Forms.Padding(3);
            this.tbpConn.Size = new System.Drawing.Size(500, 279);
            this.tbpConn.TabIndex = 0;
            this.tbpConn.Text = "Connection";
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.lblMsgHandlerType);
            this.grpOption.Controls.Add(this.pnlStationMode);
            this.grpOption.Controls.Add(this.txtRvNetwork);
            this.grpOption.Controls.Add(this.lblRvNetwork);
            this.grpOption.Controls.Add(this.txtRvService);
            this.grpOption.Controls.Add(this.lblRvService);
            this.grpOption.Controls.Add(this.btnDel);
            this.grpOption.Controls.Add(this.btnAdd);
            this.grpOption.Controls.Add(this.txtServerAddress);
            this.grpOption.Controls.Add(this.txtSiteID);
            this.grpOption.Controls.Add(this.lblSiteID);
            this.grpOption.Controls.Add(this.lblServerAddr);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(258, 3);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(239, 205);
            this.grpOption.TabIndex = 1;
            this.grpOption.TabStop = false;
            // 
            // lblMsgHandlerType
            // 
            this.lblMsgHandlerType.AutoSize = true;
            this.lblMsgHandlerType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMsgHandlerType.Location = new System.Drawing.Point(53, 158);
            this.lblMsgHandlerType.Name = "lblMsgHandlerType";
            this.lblMsgHandlerType.Size = new System.Drawing.Size(152, 13);
            this.lblMsgHandlerType.TabIndex = 11;
            this.lblMsgHandlerType.Text = "Message Handler Type : H101";
            this.lblMsgHandlerType.Visible = false;
            // 
            // pnlStationMode
            // 
            this.pnlStationMode.Controls.Add(this.cboStationMode);
            this.pnlStationMode.Controls.Add(this.lblStationMode);
            this.pnlStationMode.Location = new System.Drawing.Point(6, 106);
            this.pnlStationMode.Name = "pnlStationMode";
            this.pnlStationMode.Size = new System.Drawing.Size(225, 23);
            this.pnlStationMode.TabIndex = 8;
            this.pnlStationMode.Visible = false;
            // 
            // cboStationMode
            // 
            this.cboStationMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStationMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboStationMode.Items.AddRange(new object[] {
            "Inner Station",
            "INTER Station"});
            this.cboStationMode.Location = new System.Drawing.Point(84, 1);
            this.cboStationMode.Name = "cboStationMode";
            this.cboStationMode.Size = new System.Drawing.Size(141, 21);
            this.cboStationMode.TabIndex = 1;
            // 
            // lblStationMode
            // 
            this.lblStationMode.AutoSize = true;
            this.lblStationMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStationMode.Location = new System.Drawing.Point(1, 5);
            this.lblStationMode.Name = "lblStationMode";
            this.lblStationMode.Size = new System.Drawing.Size(70, 13);
            this.lblStationMode.TabIndex = 0;
            this.lblStationMode.Text = "Station Mode";
            // 
            // txtRvNetwork
            // 
            this.txtRvNetwork.Location = new System.Drawing.Point(89, 88);
            this.txtRvNetwork.Name = "txtRvNetwork";
            this.txtRvNetwork.Size = new System.Drawing.Size(142, 20);
            this.txtRvNetwork.TabIndex = 7;
            this.txtRvNetwork.Visible = false;
            // 
            // lblRvNetwork
            // 
            this.lblRvNetwork.AutoSize = true;
            this.lblRvNetwork.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRvNetwork.Location = new System.Drawing.Point(6, 90);
            this.lblRvNetwork.Name = "lblRvNetwork";
            this.lblRvNetwork.Size = new System.Drawing.Size(47, 13);
            this.lblRvNetwork.TabIndex = 6;
            this.lblRvNetwork.Text = "Network";
            this.lblRvNetwork.Visible = false;
            // 
            // txtRvService
            // 
            this.txtRvService.Location = new System.Drawing.Point(89, 64);
            this.txtRvService.Name = "txtRvService";
            this.txtRvService.Size = new System.Drawing.Size(142, 20);
            this.txtRvService.TabIndex = 5;
            this.txtRvService.Visible = false;
            // 
            // lblRvService
            // 
            this.lblRvService.AutoSize = true;
            this.lblRvService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRvService.Location = new System.Drawing.Point(6, 66);
            this.lblRvService.Name = "lblRvService";
            this.lblRvService.Size = new System.Drawing.Size(43, 13);
            this.lblRvService.TabIndex = 4;
            this.lblRvService.Text = "Service";
            this.lblRvService.Visible = false;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(6, 174);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 23);
            this.btnDel.TabIndex = 10;
            this.btnDel.Text = "-";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(6, 146);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "+";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Location = new System.Drawing.Point(89, 40);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(142, 20);
            this.txtServerAddress.TabIndex = 3;
            // 
            // txtSiteID
            // 
            this.txtSiteID.Location = new System.Drawing.Point(89, 16);
            this.txtSiteID.MaxLength = 4;
            this.txtSiteID.Name = "txtSiteID";
            this.txtSiteID.Size = new System.Drawing.Size(60, 20);
            this.txtSiteID.TabIndex = 1;
            // 
            // lblSiteID
            // 
            this.lblSiteID.AutoSize = true;
            this.lblSiteID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSiteID.Location = new System.Drawing.Point(6, 20);
            this.lblSiteID.Name = "lblSiteID";
            this.lblSiteID.Size = new System.Drawing.Size(39, 13);
            this.lblSiteID.TabIndex = 0;
            this.lblSiteID.Text = "Site ID";
            // 
            // lblServerAddr
            // 
            this.lblServerAddr.AutoSize = true;
            this.lblServerAddr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblServerAddr.Location = new System.Drawing.Point(6, 42);
            this.lblServerAddr.Name = "lblServerAddr";
            this.lblServerAddr.Size = new System.Drawing.Size(79, 13);
            this.lblServerAddr.TabIndex = 2;
            this.lblServerAddr.Text = "Server Address";
            // 
            // lisOptionList
            // 
            this.lisOptionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colSite,
            this.colServerAdd,
            this.colStationMode});
            this.lisOptionList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisOptionList.EnableSort = true;
            this.lisOptionList.EnableSortIcon = true;
            this.lisOptionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisOptionList.FullRowSelect = true;
            this.lisOptionList.Location = new System.Drawing.Point(3, 3);
            this.lisOptionList.MultiSelect = false;
            this.lisOptionList.Name = "lisOptionList";
            this.lisOptionList.Size = new System.Drawing.Size(255, 205);
            this.lisOptionList.TabIndex = 0;
            this.lisOptionList.UseCompatibleStateImageBehavior = false;
            this.lisOptionList.View = System.Windows.Forms.View.Details;
            this.lisOptionList.SelectedIndexChanged += new System.EventHandler(this.lisOptionList_SelectedIndexChanged);
            // 
            // colNo
            // 
            this.colNo.Text = "Seq";
            this.colNo.Width = 40;
            // 
            // colSite
            // 
            this.colSite.Text = "Site ID";
            this.colSite.Width = 70;
            // 
            // colServerAdd
            // 
            this.colServerAdd.Text = "Server Address";
            this.colServerAdd.Width = 120;
            // 
            // colStationMode
            // 
            this.colStationMode.Text = "StationMode";
            this.colStationMode.Width = 40;
            // 
            // grpSystem
            // 
            this.grpSystem.Controls.Add(this.txtVerChkTime);
            this.grpSystem.Controls.Add(this.cboLanguage);
            this.grpSystem.Controls.Add(this.lblLanguage);
            this.grpSystem.Controls.Add(this.lblSec);
            this.grpSystem.Controls.Add(this.txtTimeOut);
            this.grpSystem.Controls.Add(this.lblTimeOut);
            this.grpSystem.Controls.Add(this.lblMin2);
            this.grpSystem.Controls.Add(this.lblMin);
            this.grpSystem.Controls.Add(this.txtLogoutTime);
            this.grpSystem.Controls.Add(this.lblVerChkTime);
            this.grpSystem.Controls.Add(this.lblLogoutTime);
            this.grpSystem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpSystem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSystem.Location = new System.Drawing.Point(3, 208);
            this.grpSystem.Name = "grpSystem";
            this.grpSystem.Size = new System.Drawing.Size(494, 68);
            this.grpSystem.TabIndex = 2;
            this.grpSystem.TabStop = false;
            // 
            // txtVerChkTime
            // 
            this.txtVerChkTime.Location = new System.Drawing.Point(362, 40);
            this.txtVerChkTime.Name = "txtVerChkTime";
            this.txtVerChkTime.Size = new System.Drawing.Size(104, 20);
            this.txtVerChkTime.TabIndex = 9;
            this.txtVerChkTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVerChkTime_KeyPress);
            // 
            // cboLanguage
            // 
            this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanguage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboLanguage.Items.AddRange(new object[] {
            "English",
            "2nd Language",
            "3rd Language"});
            this.cboLanguage.Location = new System.Drawing.Point(362, 16);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(104, 21);
            this.cboLanguage.TabIndex = 4;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLanguage.Location = new System.Drawing.Point(258, 18);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(55, 13);
            this.lblLanguage.TabIndex = 3;
            this.lblLanguage.Text = "Language";
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSec.Location = new System.Drawing.Point(219, 20);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(26, 13);
            this.lblSec.TabIndex = 2;
            this.lblSec.Text = "Sec";
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Location = new System.Drawing.Point(109, 16);
            this.txtTimeOut.MaxLength = 3;
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(104, 20);
            this.txtTimeOut.TabIndex = 1;
            this.txtTimeOut.GotFocus += new System.EventHandler(this.txtTimeOut_GotFocus);
            this.txtTimeOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeOut_KeyPress);
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTimeOut.Location = new System.Drawing.Point(3, 20);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(50, 13);
            this.lblTimeOut.TabIndex = 0;
            this.lblTimeOut.Text = "Time Out";
            // 
            // lblMin2
            // 
            this.lblMin2.AutoSize = true;
            this.lblMin2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMin2.Location = new System.Drawing.Point(470, 44);
            this.lblMin2.Name = "lblMin2";
            this.lblMin2.Size = new System.Drawing.Size(24, 13);
            this.lblMin2.TabIndex = 10;
            this.lblMin2.Text = "Min";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMin.Location = new System.Drawing.Point(219, 44);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(24, 13);
            this.lblMin.TabIndex = 7;
            this.lblMin.Text = "Min";
            // 
            // txtLogoutTime
            // 
            this.txtLogoutTime.Location = new System.Drawing.Point(109, 40);
            this.txtLogoutTime.MaxLength = 3;
            this.txtLogoutTime.Name = "txtLogoutTime";
            this.txtLogoutTime.Size = new System.Drawing.Size(104, 20);
            this.txtLogoutTime.TabIndex = 6;
            this.txtLogoutTime.GotFocus += new System.EventHandler(this.txtLogoutTime_GotFocus);
            this.txtLogoutTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimeOut_KeyPress);
            // 
            // lblVerChkTime
            // 
            this.lblVerChkTime.AutoSize = true;
            this.lblVerChkTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVerChkTime.Location = new System.Drawing.Point(258, 44);
            this.lblVerChkTime.Name = "lblVerChkTime";
            this.lblVerChkTime.Size = new System.Drawing.Size(102, 13);
            this.lblVerChkTime.TabIndex = 8;
            this.lblVerChkTime.Text = "Version Check Time";
            // 
            // lblLogoutTime
            // 
            this.lblLogoutTime.AutoSize = true;
            this.lblLogoutTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLogoutTime.Location = new System.Drawing.Point(3, 42);
            this.lblLogoutTime.Name = "lblLogoutTime";
            this.lblLogoutTime.Size = new System.Drawing.Size(91, 13);
            this.lblLogoutTime.TabIndex = 5;
            this.lblLogoutTime.Text = "Auto Logout Time";
            // 
            // tbpUI
            // 
            this.tbpUI.Controls.Add(this.pnlMainLeft);
            this.tbpUI.Controls.Add(this.pnlMainRight);
            this.tbpUI.Location = new System.Drawing.Point(4, 22);
            this.tbpUI.Name = "tbpUI";
            this.tbpUI.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpUI.Size = new System.Drawing.Size(500, 279);
            this.tbpUI.TabIndex = 1;
            this.tbpUI.Text = "UI Option";
            this.tbpUI.Visible = false;
            // 
            // pnlMainLeft
            // 
            this.pnlMainLeft.Controls.Add(this.grpLine);
            this.pnlMainLeft.Controls.Add(this.grpReload);
            this.pnlMainLeft.Controls.Add(this.grpAutoRefresh);
            this.pnlMainLeft.Controls.Add(this.grpUseGrid);
            this.pnlMainLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMainLeft.Location = new System.Drawing.Point(3, 0);
            this.pnlMainLeft.Name = "pnlMainLeft";
            this.pnlMainLeft.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.pnlMainLeft.Size = new System.Drawing.Size(254, 276);
            this.pnlMainLeft.TabIndex = 0;
            // 
            // grpLine
            // 
            this.grpLine.Controls.Add(this.cdvResource);
            this.grpLine.Controls.Add(this.label3);
            this.grpLine.Controls.Add(this.cdvMatType);
            this.grpLine.Controls.Add(this.label2);
            this.grpLine.Controls.Add(this.cdvOper);
            this.grpLine.Controls.Add(this.lblLine);
            this.grpLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLine.Location = new System.Drawing.Point(0, 172);
            this.grpLine.Name = "grpLine";
            this.grpLine.Size = new System.Drawing.Size(252, 117);
            this.grpLine.TabIndex = 7;
            this.grpLine.TabStop = false;
            this.grpLine.Text = "Shop, Line and Operation";
            // 
            // cdvResource
            // 
            this.cdvResource.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResource.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResource.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResource.BtnToolTipText = "";
            this.cdvResource.ButtonWidth = 20;
            this.cdvResource.DescText = "";
            this.cdvResource.DisplaySubItemIndex = -1;
            this.cdvResource.DisplayText = "";
            this.cdvResource.Focusing = null;
            this.cdvResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResource.Index = 0;
            this.cdvResource.IsViewBtnImage = false;
            this.cdvResource.Location = new System.Drawing.Point(90, 72);
            this.cdvResource.MaxLength = 20;
            this.cdvResource.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResource.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResource.MultiSelect = false;
            this.cdvResource.Name = "cdvResource";
            this.cdvResource.ReadOnly = true;
            this.cdvResource.SameWidthHeightOfButton = false;
            this.cdvResource.SearchSubItemIndex = 0;
            this.cdvResource.SelectedDescIndex = -1;
            this.cdvResource.SelectedDescToQueryText = "";
            this.cdvResource.SelectedSubItemIndex = -1;
            this.cdvResource.SelectedValueToQueryText = "";
            this.cdvResource.SelectionStart = 0;
            this.cdvResource.Size = new System.Drawing.Size(132, 20);
            this.cdvResource.SmallImageList = null;
            this.cdvResource.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResource.TabIndex = 18;
            this.cdvResource.TextBoxToolTipText = "";
            this.cdvResource.TextBoxWidth = 132;
            this.cdvResource.VisibleButton = true;
            this.cdvResource.VisibleColumnHeader = false;
            this.cdvResource.VisibleDescription = false;
            this.cdvResource.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResource_SelectedItemChanged);
            this.cdvResource.ButtonPress += new System.EventHandler(this.cdvResource_ButtonPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Res Id";
            // 
            // cdvMatType
            // 
            this.cdvMatType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMatType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMatType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMatType.BtnToolTipText = "";
            this.cdvMatType.ButtonWidth = 20;
            this.cdvMatType.DescText = "";
            this.cdvMatType.DisplaySubItemIndex = -1;
            this.cdvMatType.DisplayText = "";
            this.cdvMatType.Focusing = null;
            this.cdvMatType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatType.Index = 0;
            this.cdvMatType.IsViewBtnImage = false;
            this.cdvMatType.Location = new System.Drawing.Point(90, 18);
            this.cdvMatType.MaxLength = 20;
            this.cdvMatType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMatType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMatType.MultiSelect = false;
            this.cdvMatType.Name = "cdvMatType";
            this.cdvMatType.ReadOnly = true;
            this.cdvMatType.SameWidthHeightOfButton = false;
            this.cdvMatType.SearchSubItemIndex = 0;
            this.cdvMatType.SelectedDescIndex = -1;
            this.cdvMatType.SelectedDescToQueryText = "";
            this.cdvMatType.SelectedSubItemIndex = -1;
            this.cdvMatType.SelectedValueToQueryText = "";
            this.cdvMatType.SelectionStart = 0;
            this.cdvMatType.Size = new System.Drawing.Size(132, 20);
            this.cdvMatType.SmallImageList = null;
            this.cdvMatType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMatType.TabIndex = 16;
            this.cdvMatType.TextBoxToolTipText = "";
            this.cdvMatType.TextBoxWidth = 132;
            this.cdvMatType.VisibleButton = true;
            this.cdvMatType.VisibleColumnHeader = false;
            this.cdvMatType.VisibleDescription = false;
            this.cdvMatType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatType_SelectedItemChanged);
            this.cdvMatType.ButtonPress += new System.EventHandler(this.cdvMatType_ButtonPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mat Type";
            // 
            // cdvOper
            // 
            this.cdvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOper.BtnToolTipText = "";
            this.cdvOper.ButtonWidth = 20;
            this.cdvOper.DescText = "";
            this.cdvOper.DisplaySubItemIndex = -1;
            this.cdvOper.DisplayText = "";
            this.cdvOper.Focusing = null;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.Index = 0;
            this.cdvOper.IsViewBtnImage = false;
            this.cdvOper.Location = new System.Drawing.Point(90, 44);
            this.cdvOper.MaxLength = 20;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MultiSelect = false;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = true;
            this.cdvOper.SameWidthHeightOfButton = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedDescToQueryText = "";
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectedValueToQueryText = "";
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(132, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 13;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 132;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.Location = new System.Drawing.Point(27, 48);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(30, 13);
            this.lblLine.TabIndex = 7;
            this.lblLine.Text = "Oper";
            // 
            // grpReload
            // 
            this.grpReload.Controls.Add(this.rbnReloadNo);
            this.grpReload.Controls.Add(this.rbnReloadYes);
            this.grpReload.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpReload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReload.Location = new System.Drawing.Point(0, 130);
            this.grpReload.Name = "grpReload";
            this.grpReload.Size = new System.Drawing.Size(252, 42);
            this.grpReload.TabIndex = 2;
            this.grpReload.TabStop = false;
            this.grpReload.Text = "Reload last use screens";
            // 
            // rbnReloadNo
            // 
            this.rbnReloadNo.AutoSize = true;
            this.rbnReloadNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnReloadNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnReloadNo.Location = new System.Drawing.Point(144, 19);
            this.rbnReloadNo.Name = "rbnReloadNo";
            this.rbnReloadNo.Size = new System.Drawing.Size(45, 18);
            this.rbnReloadNo.TabIndex = 1;
            this.rbnReloadNo.Text = "No";
            // 
            // rbnReloadYes
            // 
            this.rbnReloadYes.AutoSize = true;
            this.rbnReloadYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnReloadYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnReloadYes.Location = new System.Drawing.Point(30, 19);
            this.rbnReloadYes.Name = "rbnReloadYes";
            this.rbnReloadYes.Size = new System.Drawing.Size(49, 18);
            this.rbnReloadYes.TabIndex = 0;
            this.rbnReloadYes.Text = "Yes";
            // 
            // grpAutoRefresh
            // 
            this.grpAutoRefresh.Controls.Add(this.lblAutoRefreshSec);
            this.grpAutoRefresh.Controls.Add(this.txtAutoRefreshTime);
            this.grpAutoRefresh.Controls.Add(this.lblAutoRefreshTime);
            this.grpAutoRefresh.Controls.Add(this.rbnAutoRefreshNo);
            this.grpAutoRefresh.Controls.Add(this.rbnAutoRefreshYes);
            this.grpAutoRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAutoRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAutoRefresh.Location = new System.Drawing.Point(0, 56);
            this.grpAutoRefresh.Name = "grpAutoRefresh";
            this.grpAutoRefresh.Size = new System.Drawing.Size(252, 74);
            this.grpAutoRefresh.TabIndex = 1;
            this.grpAutoRefresh.TabStop = false;
            this.grpAutoRefresh.Text = "Auto Refresh";
            // 
            // lblAutoRefreshSec
            // 
            this.lblAutoRefreshSec.AutoSize = true;
            this.lblAutoRefreshSec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoRefreshSec.Location = new System.Drawing.Point(206, 45);
            this.lblAutoRefreshSec.Name = "lblAutoRefreshSec";
            this.lblAutoRefreshSec.Size = new System.Drawing.Size(26, 13);
            this.lblAutoRefreshSec.TabIndex = 4;
            this.lblAutoRefreshSec.Text = "Sec";
            // 
            // txtAutoRefreshTime
            // 
            this.txtAutoRefreshTime.Location = new System.Drawing.Point(124, 41);
            this.txtAutoRefreshTime.MaxLength = 3;
            this.txtAutoRefreshTime.Name = "txtAutoRefreshTime";
            this.txtAutoRefreshTime.Size = new System.Drawing.Size(76, 20);
            this.txtAutoRefreshTime.TabIndex = 3;
            this.txtAutoRefreshTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutoRefreshTime_KeyPress);
            // 
            // lblAutoRefreshTime
            // 
            this.lblAutoRefreshTime.AutoSize = true;
            this.lblAutoRefreshTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoRefreshTime.Location = new System.Drawing.Point(12, 45);
            this.lblAutoRefreshTime.Name = "lblAutoRefreshTime";
            this.lblAutoRefreshTime.Size = new System.Drawing.Size(95, 13);
            this.lblAutoRefreshTime.TabIndex = 2;
            this.lblAutoRefreshTime.Text = "Auto Refresh Time";
            // 
            // rbnAutoRefreshNo
            // 
            this.rbnAutoRefreshNo.AutoSize = true;
            this.rbnAutoRefreshNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnAutoRefreshNo.Location = new System.Drawing.Point(144, 19);
            this.rbnAutoRefreshNo.Name = "rbnAutoRefreshNo";
            this.rbnAutoRefreshNo.Size = new System.Drawing.Size(45, 18);
            this.rbnAutoRefreshNo.TabIndex = 1;
            this.rbnAutoRefreshNo.Text = "No";
            this.rbnAutoRefreshNo.Click += new System.EventHandler(this.rbnAutoRefreshNo_Click);
            // 
            // rbnAutoRefreshYes
            // 
            this.rbnAutoRefreshYes.AutoSize = true;
            this.rbnAutoRefreshYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnAutoRefreshYes.Location = new System.Drawing.Point(30, 19);
            this.rbnAutoRefreshYes.Name = "rbnAutoRefreshYes";
            this.rbnAutoRefreshYes.Size = new System.Drawing.Size(49, 18);
            this.rbnAutoRefreshYes.TabIndex = 0;
            this.rbnAutoRefreshYes.Text = "Yes";
            this.rbnAutoRefreshYes.Click += new System.EventHandler(this.rbnAutoRefreshYes_Click);
            // 
            // grpUseGrid
            // 
            this.grpUseGrid.Controls.Add(this.rbnUseGridNo);
            this.grpUseGrid.Controls.Add(this.rbnUseGridYes);
            this.grpUseGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpUseGrid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUseGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUseGrid.Location = new System.Drawing.Point(0, 0);
            this.grpUseGrid.Name = "grpUseGrid";
            this.grpUseGrid.Size = new System.Drawing.Size(252, 56);
            this.grpUseGrid.TabIndex = 0;
            this.grpUseGrid.TabStop = false;
            this.grpUseGrid.Text = "Use Grid";
            // 
            // rbnUseGridNo
            // 
            this.rbnUseGridNo.AutoSize = true;
            this.rbnUseGridNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnUseGridNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnUseGridNo.Location = new System.Drawing.Point(144, 19);
            this.rbnUseGridNo.Name = "rbnUseGridNo";
            this.rbnUseGridNo.Size = new System.Drawing.Size(45, 18);
            this.rbnUseGridNo.TabIndex = 1;
            this.rbnUseGridNo.Text = "No";
            // 
            // rbnUseGridYes
            // 
            this.rbnUseGridYes.AutoSize = true;
            this.rbnUseGridYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnUseGridYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnUseGridYes.Location = new System.Drawing.Point(30, 19);
            this.rbnUseGridYes.Name = "rbnUseGridYes";
            this.rbnUseGridYes.Size = new System.Drawing.Size(49, 18);
            this.rbnUseGridYes.TabIndex = 0;
            this.rbnUseGridYes.Text = "Yes";
            // 
            // pnlMainRight
            // 
            this.pnlMainRight.Controls.Add(this.grpSound);
            this.pnlMainRight.Controls.Add(this.groupBox1);
            this.pnlMainRight.Controls.Add(this.grpSuccess);
            this.pnlMainRight.Controls.Add(this.grpListRefresh);
            this.pnlMainRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMainRight.Location = new System.Drawing.Point(257, 0);
            this.pnlMainRight.Name = "pnlMainRight";
            this.pnlMainRight.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.pnlMainRight.Size = new System.Drawing.Size(240, 276);
            this.pnlMainRight.TabIndex = 1;
            // 
            // grpSound
            // 
            this.grpSound.Controls.Add(this.rbnSoundNo);
            this.grpSound.Controls.Add(this.rbnSoundYes);
            this.grpSound.Controls.Add(this.cdvResId);
            this.grpSound.Controls.Add(this.label1);
            this.grpSound.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSound.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSound.Location = new System.Drawing.Point(2, 195);
            this.grpSound.Name = "grpSound";
            this.grpSound.Size = new System.Drawing.Size(238, 78);
            this.grpSound.TabIndex = 7;
            this.grpSound.TabStop = false;
            this.grpSound.Text = "Play Sound Signal";
            // 
            // rbnSoundNo
            // 
            this.rbnSoundNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnSoundNo.Location = new System.Drawing.Point(144, 19);
            this.rbnSoundNo.Name = "rbnSoundNo";
            this.rbnSoundNo.Size = new System.Drawing.Size(76, 17);
            this.rbnSoundNo.TabIndex = 1;
            this.rbnSoundNo.Text = "No";
            // 
            // rbnSoundYes
            // 
            this.rbnSoundYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnSoundYes.Location = new System.Drawing.Point(32, 19);
            this.rbnSoundYes.Name = "rbnSoundYes";
            this.rbnSoundYes.Size = new System.Drawing.Size(76, 17);
            this.rbnSoundYes.TabIndex = 0;
            this.rbnSoundYes.Text = "Yes";
            // 
            // cdvResId
            // 
            this.cdvResId.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResId.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResId.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResId.BtnToolTipText = "";
            this.cdvResId.ButtonWidth = 20;
            this.cdvResId.DescText = "";
            this.cdvResId.DisplaySubItemIndex = -1;
            this.cdvResId.DisplayText = "";
            this.cdvResId.Focusing = null;
            this.cdvResId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResId.Index = 0;
            this.cdvResId.IsViewBtnImage = false;
            this.cdvResId.Location = new System.Drawing.Point(87, 52);
            this.cdvResId.MaxLength = 20;
            this.cdvResId.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResId.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResId.MultiSelect = false;
            this.cdvResId.Name = "cdvResId";
            this.cdvResId.ReadOnly = true;
            this.cdvResId.SameWidthHeightOfButton = false;
            this.cdvResId.SearchSubItemIndex = 0;
            this.cdvResId.SelectedDescIndex = -1;
            this.cdvResId.SelectedDescToQueryText = "";
            this.cdvResId.SelectedSubItemIndex = -1;
            this.cdvResId.SelectedValueToQueryText = "";
            this.cdvResId.SelectionStart = 0;
            this.cdvResId.Size = new System.Drawing.Size(132, 20);
            this.cdvResId.SmallImageList = null;
            this.cdvResId.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResId.TabIndex = 14;
            this.cdvResId.TextBoxToolTipText = "";
            this.cdvResId.TextBoxWidth = 132;
            this.cdvResId.Visible = false;
            this.cdvResId.VisibleButton = true;
            this.cdvResId.VisibleColumnHeader = false;
            this.cdvResId.VisibleDescription = false;
            this.cdvResId.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResId_SelectedItemChanged);
            this.cdvResId.ButtonPress += new System.EventHandler(this.cdvResId_ButtonPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Resource";
            this.label1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnTuneNo);
            this.groupBox1.Controls.Add(this.rbnTuneYes);
            this.groupBox1.Controls.Add(this.chkTuneWorkGuide);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(2, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 66);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tune";
            // 
            // rbnTuneNo
            // 
            this.rbnTuneNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnTuneNo.Location = new System.Drawing.Point(144, 19);
            this.rbnTuneNo.Name = "rbnTuneNo";
            this.rbnTuneNo.Size = new System.Drawing.Size(76, 17);
            this.rbnTuneNo.TabIndex = 1;
            this.rbnTuneNo.Text = "No";
            // 
            // rbnTuneYes
            // 
            this.rbnTuneYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnTuneYes.Location = new System.Drawing.Point(32, 19);
            this.rbnTuneYes.Name = "rbnTuneYes";
            this.rbnTuneYes.Size = new System.Drawing.Size(76, 17);
            this.rbnTuneYes.TabIndex = 0;
            this.rbnTuneYes.Text = "Yes";
            // 
            // chkTuneWorkGuide
            // 
            this.chkTuneWorkGuide.AutoSize = true;
            this.chkTuneWorkGuide.Location = new System.Drawing.Point(32, 40);
            this.chkTuneWorkGuide.Name = "chkTuneWorkGuide";
            this.chkTuneWorkGuide.Size = new System.Drawing.Size(111, 17);
            this.chkTuneWorkGuide.TabIndex = 11;
            this.chkTuneWorkGuide.Text = "Tune Work Guide";
            this.chkTuneWorkGuide.UseVisualStyleBackColor = true;
            // 
            // grpSuccess
            // 
            this.grpSuccess.Controls.Add(this.rbnSuccessNo);
            this.grpSuccess.Controls.Add(this.rbnSuccessYes);
            this.grpSuccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSuccess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSuccess.Location = new System.Drawing.Point(2, 56);
            this.grpSuccess.Name = "grpSuccess";
            this.grpSuccess.Size = new System.Drawing.Size(238, 73);
            this.grpSuccess.TabIndex = 2;
            this.grpSuccess.TabStop = false;
            this.grpSuccess.Text = "Show Success Message";
            // 
            // rbnSuccessNo
            // 
            this.rbnSuccessNo.AutoSize = true;
            this.rbnSuccessNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnSuccessNo.Location = new System.Drawing.Point(144, 19);
            this.rbnSuccessNo.Name = "rbnSuccessNo";
            this.rbnSuccessNo.Size = new System.Drawing.Size(45, 18);
            this.rbnSuccessNo.TabIndex = 1;
            this.rbnSuccessNo.Text = "No";
            // 
            // rbnSuccessYes
            // 
            this.rbnSuccessYes.AutoSize = true;
            this.rbnSuccessYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnSuccessYes.Location = new System.Drawing.Point(32, 19);
            this.rbnSuccessYes.Name = "rbnSuccessYes";
            this.rbnSuccessYes.Size = new System.Drawing.Size(49, 18);
            this.rbnSuccessYes.TabIndex = 0;
            this.rbnSuccessYes.Text = "Yes";
            // 
            // grpListRefresh
            // 
            this.grpListRefresh.Controls.Add(this.rbnRefreshNo);
            this.grpListRefresh.Controls.Add(this.rbnRefreshYes);
            this.grpListRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpListRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpListRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpListRefresh.Location = new System.Drawing.Point(2, 0);
            this.grpListRefresh.Name = "grpListRefresh";
            this.grpListRefresh.Size = new System.Drawing.Size(238, 56);
            this.grpListRefresh.TabIndex = 0;
            this.grpListRefresh.TabStop = false;
            this.grpListRefresh.Text = "List Refresh";
            // 
            // rbnRefreshNo
            // 
            this.rbnRefreshNo.AutoSize = true;
            this.rbnRefreshNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnRefreshNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnRefreshNo.Location = new System.Drawing.Point(144, 19);
            this.rbnRefreshNo.Name = "rbnRefreshNo";
            this.rbnRefreshNo.Size = new System.Drawing.Size(45, 18);
            this.rbnRefreshNo.TabIndex = 1;
            this.rbnRefreshNo.Text = "No";
            // 
            // rbnRefreshYes
            // 
            this.rbnRefreshYes.AutoSize = true;
            this.rbnRefreshYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnRefreshYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnRefreshYes.Location = new System.Drawing.Point(32, 20);
            this.rbnRefreshYes.Name = "rbnRefreshYes";
            this.rbnRefreshYes.Size = new System.Drawing.Size(49, 18);
            this.rbnRefreshYes.TabIndex = 0;
            this.rbnRefreshYes.Text = "Yes";
            // 
            // frmOption
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(514, 344);
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Activated += new System.EventHandler(this.frmOption_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmOption_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmOption_KeyUp);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.tabOption.ResumeLayout(false);
            this.tbpConn.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlStationMode.ResumeLayout(false);
            this.pnlStationMode.PerformLayout();
            this.grpSystem.ResumeLayout(false);
            this.grpSystem.PerformLayout();
            this.tbpUI.ResumeLayout(false);
            this.pnlMainLeft.ResumeLayout(false);
            this.grpLine.ResumeLayout(false);
            this.grpLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            this.grpReload.ResumeLayout(false);
            this.grpReload.PerformLayout();
            this.grpAutoRefresh.ResumeLayout(false);
            this.grpAutoRefresh.PerformLayout();
            this.grpUseGrid.ResumeLayout(false);
            this.grpUseGrid.PerformLayout();
            this.pnlMainRight.ResumeLayout(false);
            this.grpSound.ResumeLayout(false);
            this.grpSound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResId)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSuccess.ResumeLayout(false);
            this.grpSuccess.PerformLayout();
            this.grpListRefresh.ResumeLayout(false);
            this.grpListRefresh.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        protected bool b_restart_flag;
        
        #endregion
        
        #region " Function Definition "
        
        #endregion

        private void frmOption_Activated(object sender, System.EventArgs e)
        {

            if (b_load_flag == false)
            {

                int i;
                string sSiteID;
                string sServerAdd;
                ListViewItem itmx;

                if (MPIF.gInit.getMiddleware == "TIBRV")
                {
                    pnlStationMode.Visible = false;
                    lblRvService.Visible = true;
                    lblRvNetwork.Visible = true;
                    txtRvService.Visible = true;
                    txtRvNetwork.Visible = true;

                    lisOptionList.Columns.RemoveAt(3);

                    ColumnHeader ch;

                    ch = new ColumnHeader();
                    ch.Text = "Service";
                    lisOptionList.Columns.Add(ch);
                    ch = new ColumnHeader();
                    ch.Text = "Network";
                    lisOptionList.Columns.Add(ch);
                }
                else if (MPIF.gInit.getMiddleware == "H101")
                {
                    pnlStationMode.Visible = true;
                    pnlStationMode.Location = new System.Drawing.Point(6, 64);
                }
                

                MPCF.InitListView(lisOptionList);

                //Get Client Options
                if (b_restart_flag == false)
                {
                    if (MPIF.gInit.GetClientOptions() == false)
                    {
                        this.Close();
                    }

                    // Add by hans (2017-01-11)
                    if (MPOF.GetCusClientOptions() == false)
                    {
                        this.Close();
                    }
                    /*******************************************/
                }

                for (i = 0; i < 20; i++)
                {
                    if (MPCF.Trim(MPCF.GetRegSetting(Application.ProductName, "Option", "SiteID" + i.ToString(), "")) != "")
                    {
                        sSiteID = MPCF.GetRegSetting(Application.ProductName, "Option", "SiteID" + i.ToString(), "");
                        sServerAdd = MPCF.GetRegSetting(Application.ProductName, "Option", "RemoteAddress" + i.ToString(), "");

                        itmx = new ListViewItem(((int)(lisOptionList.Items.Count + 1)).ToString());
                        itmx.SubItems.Add(sSiteID);
                        itmx.SubItems.Add(sServerAdd);

                        if (MPIF.gInit.getMiddleware == "TIBRV")
                        {
                            itmx.SubItems.Add(MPCF.GetRegSetting(Application.ProductName, "Option", "RvService" + i.ToString(), ""));
                            itmx.SubItems.Add(MPCF.GetRegSetting(Application.ProductName, "Option", "RvNetwork" + i.ToString(), ""));
                        }
                        else if (MPIF.gInit.getMiddleware == "H101")
                        {
                            itmx.SubItems.Add(MPCF.GetRegSetting(Application.ProductName, "Option", "StationMode" + i.ToString(), ""));
                        }

                        lisOptionList.Items.Add(itmx);
                    }
                }

                if (MPGV.gsSiteID != null)
                {
                    txtSiteID.Text = MPGV.gsSiteID;
                }
                else
                {
                    if (lisOptionList.Items.Count > 0)
                    {
                        txtSiteID.Text = lisOptionList.Items[0].SubItems[1].Text;
                    }
                }
                if (MPGV.gsRemoteAddress != null)
                {
                    txtServerAddress.Text = MPGV.gsRemoteAddress;
                }
                else
                {
                    if (lisOptionList.Items.Count > 0)
                    {
                        txtServerAddress.Text = lisOptionList.Items[0].SubItems[2].Text;
                    }
                }
                if (MPIF.gInit.getMiddleware == "TIBRV")
                {
                    if (MPGV.gsRvService != null)
                    {
                        txtRvService.Text = MPGV.gsRvService;
                    }
                    else
                    {
                        if (lisOptionList.Items.Count > 0)
                        {
                            txtRvService.Text = lisOptionList.Items[0].SubItems[3].Text;
                        }
                    }
                    if (MPGV.gsRvNetwork != null)
                    {
                        txtRvNetwork.Text = MPGV.gsRvNetwork;
                    }
                    else
                    {
                        if (lisOptionList.Items.Count > 0)
                        {
                            txtRvNetwork.Text = lisOptionList.Items[0].SubItems[4].Text;
                        }
                    }
                }
                else if (MPIF.gInit.getMiddleware == "H101")
                {
                    cboStationMode.SelectedIndex = 0;
                    if (MPGV.gsStationMode != null)
                    {
                        if (MPGV.gsStationMode == "INTER")
                        {
                            cboStationMode.SelectedIndex = 1;
                        }
                    }
                    else
                    {
                        if (lisOptionList.Items.Count > 0)
                        {
                            if (lisOptionList.Items[0].SubItems[3].Text == "INTER")
                            {
                                cboStationMode.SelectedIndex = 1;
                            }
                        }
                    }
                }

                if (MPGV.giVersionCheckTime == 0)
                {
                    txtVerChkTime.Text = "";
                }
                else
                {
                    txtVerChkTime.Text = MPGV.giVersionCheckTime.ToString();
                }

                txtTimeOut.Text = MPGV.giTimeOut.ToString();
                if (MPGV.giLogOutTime == 0)
                {
                    txtLogoutTime.Text = "";
                }
                else
                {
                    txtLogoutTime.Text = MPGV.giLogOutTime.ToString();
                }

                cboLanguage.SelectedIndex = MPCF.ToInt(MPGV.gcLanguage) - 1;

                if (MPGV.gbGridFlag == true)
                {
                    rbnUseGridYes.Checked = true;
                }
                else
                {
                    rbnUseGridNo.Checked = true;
                }

                if (MPGV.gbListAutoRefresh == true)
                {
                    rbnRefreshYes.Checked = true;
                }
                else
                {
                    rbnRefreshNo.Checked = true;
                }

                if (MPGV.gbShowMsgFlag == true)
                {
                    rbnSuccessYes.Checked = true;
                }
                else
                {
                    rbnSuccessNo.Checked = true;
                }

                // 2017.03.09 jhlee Play Sound Signal 추가
                if (MOGV.gbPlaySoundFlag == true)
                {
                    rbnSoundYes.Checked = true;
                }
                else
                {
                    rbnSoundNo.Checked = true;
                }

                // 20170111-ADD BY HANS

                if (MOGV.gbTunePublish == true)
                    rbnTuneYes.Checked = true;
                else
                    rbnTuneNo.Checked = true;
                cdvMatType.Text = MOGV.gsMatType;
                cdvOper.Text = MOGV.gsOper;
                cdvResId.Text = MOGV.gsResId;
                cdvResource.Text = MOGV.gsResource;
                chkTuneWorkGuide.Checked = MOGV.gbTuneWorkGuide;
                /***************************************/

                if (MPGV.gbAutoRefresh == true)
                {
                    rbnAutoRefreshYes.Checked = true;
                    txtAutoRefreshTime.ReadOnly = false;
                    txtAutoRefreshTime.Text = MPGV.giAutoRefreshTime.ToString();
                }
                else
                {
                    rbnAutoRefreshNo.Checked = true;
                    txtAutoRefreshTime.ReadOnly = true;
                    txtAutoRefreshTime.Text = "";
                }

                if (MPCF.GetRegSetting(Application.ProductName, "Option", "ReloadScreens", "1") == "1")
                {
                    rbnReloadYes.Checked = true;
                }
                else
                {
                    rbnReloadNo.Checked = true;
                }

                MPCF.ToClientLanguage(this); 
                
                b_load_flag = true;
            }

        }

        private void frmOption_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is TextBox)
                {
                    if (e.KeyValue != 13 && e.KeyValue != 8 || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                    {
                        if (MPCF.CheckMaxLength(this.ActiveControl, 0) == false)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }

        }

        private void frmOption_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is TextBox || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    if (e.KeyChar == (char)58)
                    {
                        e.Handled = true;
                    }
                }
            }

        }

        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            
            int i;
            int j;

            if (MPCF.CheckValue(txtSiteID, 1) == false)
            {
                return;
            }
            if (MPCF.CheckValue(txtServerAddress, 1) == false)
            {
                return;
            }
            
            btnAdd.PerformClick();
            
            if (b_restart_flag == true)
            {
                if (MPGV.gsSiteID != txtSiteID.Text ||
                    MPGV.gsRemoteAddress != txtServerAddress.Text ||
                    (MPGV.gsRvService != null && MPGV.gsRvService != txtRvService.Text) ||
                    (MPGV.gsRvNetwork != null && MPGV.gsRvNetwork != txtRvNetwork.Text) ||
                    (MPGV.gsStationMode != null && cboStationMode.Text.StartsWith(MPGV.gsStationMode) == false) ||
                    MPGV.gcLanguage != MPCF.ToChar(cboLanguage.SelectedIndex + 1) ||
                    MOGV.gsLine != cdvOper.Text ||
                    MOGV.gsResId != cdvResId.Text ||
                    MOGV.gbTunePublish != rbnTuneYes.Checked)
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(3), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    b_restart_flag = false;
                }
            }
            
            MPCF.SaveRegSetting(Application.ProductName, "Option", "SiteID", txtSiteID.Text);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "RemoteAddress", txtServerAddress.Text);

            MPGV.gsSiteID = txtSiteID.Text;
            MPGV.gsRemoteAddress = txtServerAddress.Text;

            if (MPIF.gInit.getMiddleware == "TIBRV")
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "RvService", txtRvService.Text);
                MPCF.SaveRegSetting(Application.ProductName, "Option", "RvNetwork", txtRvNetwork.Text);

                MPGV.gsRvService = txtRvService.Text;
                MPGV.gsRvNetwork = txtRvNetwork.Text;
            }
            else if (MPIF.gInit.getMiddleware == "H101")
            {
                if (cboStationMode.SelectedIndex == 1)
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "StationMode", "INTER");
                    MPGV.gsStationMode = "INTER";
                }
                else
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "StationMode", "Inner");
                    MPGV.gsStationMode = "Inner";
                }
            }

            
            if (txtTimeOut.Text == "")
            {
                txtTimeOut.Text = "20";
            }
            else if (MPCF.CheckNumeric(txtTimeOut.Text) == false)
            {
                txtTimeOut.Text = "20";
            }
            
            if (MPCF.CheckNumeric(txtTimeOut.Text))
            {
                if (MPCF.ToInt(txtTimeOut.Text) == 0 || MPCF.ToInt(txtTimeOut.Text) < 10 || MPCF.ToInt(txtTimeOut.Text) > 300)
                {
                    txtTimeOut.Text = "20";
                }
                MPGV.giTimeOut = MPCF.ToInt(txtTimeOut.Text);
                MPIF.gInit.setTTL(MPGV.giTimeOut);
                MPCF.SaveRegSetting(Application.ProductName, "Option", "TimeOut", MPGV.giTimeOut.ToString());
            }
            
            // Version Check Time Added by ICBAE
            if (txtVerChkTime.Text == "")
            {
                MPGV.giVersionCheckTime = 0;
            }
            else if (MPCF.CheckNumeric(txtVerChkTime.Text))
            {
                MPGV.giVersionCheckTime = MPCF.ToInt(txtVerChkTime.Text);
            }

            MPCF.SaveRegSetting(Application.ProductName, "Option", "VersionCheckTime", MPGV.giVersionCheckTime.ToString());
            // End Added by ICBAE for Version Check Time


            if (txtLogoutTime.Text == "")
            {
                MPGV.giLogOutTime = 0;
            }
            else if (MPCF.ToInt(txtLogoutTime.Text) == 0)
            {
                MPGV.giLogOutTime = 0;
            }
            else if (MPCF.ToInt(txtLogoutTime.Text) <= 5 && MPCF.ToInt(txtLogoutTime.Text) != 0)
            {
                MPGV.giLogOutTime = 5;
            }
            else if (MPCF.ToInt(txtLogoutTime.Text) > 5)
            {
                MPGV.giLogOutTime = MPCF.ToInt(txtLogoutTime.Text);
            }
            MPCF.SaveRegSetting(Application.ProductName, "Option", "LogOutTime", MPGV.giLogOutTime.ToString());

            MPGV.gcLanguage = MPCF.ToChar(cboLanguage.SelectedIndex + 1); 
            MPCF.SaveRegSetting(Application.ProductName, "Option", "Language", MPGV.gcLanguage.ToString()); 
            
            if (rbnUseGridYes.Checked == true)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "Grid", "1");
                MPGV.gbGridFlag = true;
            }
            else
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "Grid", "2");
                MPGV.gbGridFlag = false;
            }
            
            if (rbnRefreshYes.Checked == true)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "ListRefresh", "1");
                MPGV.gbListAutoRefresh = true;
            }
            else
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "ListRefresh", "0");
                MPGV.gbListAutoRefresh = false;
            }
            
            if (rbnAutoRefreshYes.Checked == true)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "AutoRefresh", "1");
                if (MPCF.ToInt(MPCF.ToDbl(txtAutoRefreshTime.Text)) < 30 || MPCF.CheckNumeric(txtAutoRefreshTime.Text) == false)
                {
                    txtAutoRefreshTime.Text = "300";
                }
                MPCF.SaveRegSetting(Application.ProductName, "Option", "AutoRefreshTime", txtAutoRefreshTime.Text);
                MPGV.gbAutoRefresh = true;
                MPGV.giAutoRefreshTime = MPCF.ToInt(txtAutoRefreshTime.Text);
            }
            else
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "AutoRefresh", "2");
                MPCF.SaveRegSetting(Application.ProductName, "Option", "AutoRefreshTime", "0");
                MPGV.gbAutoRefresh = false;
                MPGV.giAutoRefreshTime = 0;
            }
            
            if (rbnSuccessYes.Checked == true)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "Message", "1");
                MPGV.gbShowMsgFlag = true;
            }
            else
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "Message", "2");
                MPGV.gbShowMsgFlag = false;
            }

            if (rbnReloadYes.Checked == true)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "ReloadScreens", "1");
            }
            else
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "ReloadScreens", "2");
            }

            // 2017.03.09 jhlee play sound signal 추가 
            if (rbnSoundYes.Checked == true)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "Sound", "1");
                MOGV.gbPlaySoundFlag = true;
            }
            else
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "Sound", "2");
                MOGV.gbPlaySoundFlag = false;
            }

            //ADD BY HANS(2017-01-11)
            if (rbnTuneYes.Checked == true)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "TuneFlag", "1");
                MOGV.gbTunePublish = true;
            }
            else
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "TuneFlag", "2");
                MOGV.gbTunePublish = false;
            }

            if (chkTuneWorkGuide.Checked == true)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "TuneWorkGuideFlag", "1");
                MOGV.gbTuneWorkGuide = true;
            }
            else
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "TuneWorkGuideFlag", "2");
                MOGV.gbTuneWorkGuide = false;
            }

            //2018-06-05 LAKE JANG 추가
            MPCF.SaveRegSetting(Application.ProductName, "Option", "MatType", cdvMatType.Text);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "Oper", cdvOper.Text);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "Resource", cdvResource.Text);

            MPCF.SaveRegSetting(Application.ProductName, "Option", "Line", cdvOper.Text);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "Line_Desc", MOGV.gsLineDesc);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "Area", cdvMatType.Text);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "Area_Desc", MOGV.gsAreaDesc);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "ResId", cdvResId.Text);
            //MPCF.SaveRegSetting(Application.ProductName, "Option", "Oper", cdvResource.Text);
            MPCF.SaveRegSetting(Application.ProductName, "Option", "TuneId", MOGV.gsTuneId);

            MOGV.gsOper = cdvResource.Text;
            MOGV.gsLine = cdvOper.Text;
            MOGV.gsResId = cdvResId.Text;
            MOGV.gsArea = cdvMatType.Text;
            /*********************************************************************************************/

            for (i = 0; i < lisOptionList.Items.Count; i++)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "SiteID" + i.ToString(), lisOptionList.Items[i].SubItems[1].Text);
                MPCF.SaveRegSetting(Application.ProductName, "Option", "RemoteAddress" + i.ToString(), lisOptionList.Items[i].SubItems[2].Text);

                if (MPIF.gInit.getMiddleware == "TIBRV")
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "RvService" + i.ToString(), lisOptionList.Items[i].SubItems[3].Text);
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "RvNetwork" + i.ToString(), lisOptionList.Items[i].SubItems[4].Text);
                }
                else
                {
                    MPCF.DeleteRegSetting(Application.ProductName, "Option", "RvService" + i.ToString());
                    MPCF.DeleteRegSetting(Application.ProductName, "Option", "RvNetwork" + i.ToString());
                }
            }
            
            for (j = i; j < 20; j++)
            {
                MPCF.SaveRegSetting(Application.ProductName, "Option", "SiteID" + j.ToString(), " ");
                MPCF.SaveRegSetting(Application.ProductName, "Option", "RemoteAddress" + j.ToString(), " ");

                if (MPIF.gInit.getMiddleware == "TIBRV")
                {
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "RvService" + j.ToString(), " ");
                    MPCF.SaveRegSetting(Application.ProductName, "Option", "RvNetwork" + j.ToString(), " ");
                }
                else
                {
                    MPCF.DeleteRegSetting(Application.ProductName, "Option", "RvService" + i.ToString());
                    MPCF.DeleteRegSetting(Application.ProductName, "Option", "RvNetwork" + i.ToString());
                }
            }
            
            this.Close();
            
            if (b_restart_flag == true)
            {
                if (MPGV.gfrmMDI != null)
                {
                    MPGV.gbLogoutFlag = true;
                    MPGV.gfrmMDI.Close();
                    this.Close();
                    Application.Exit();
                    Process.Start(Application.ExecutablePath);
                    MPGV.gbLogoutFlag = false;
                }
            }

            MPOF.LoadResourceFile();
            
        }
        
        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            
            this.Close();
            
        }
        
        private void txtLogoutTime_GotFocus(System.Object sender, System.EventArgs e)
        {
            
            MPCF.SelectText(txtLogoutTime, true);
            
        }
        
        private void txtTimeOut_GotFocus(System.Object sender, System.EventArgs e)
        {
            
            MPCF.SelectText(txtTimeOut, true);
            
        }
        
        private void rbnAutoRefreshYes_Click(System.Object sender, System.EventArgs e)
        {
            
            txtAutoRefreshTime.ReadOnly = false;
            txtAutoRefreshTime.Text = "300";
            
        }
        
        private void rbnAutoRefreshNo_Click(System.Object sender, System.EventArgs e)
        {
            
            txtAutoRefreshTime.ReadOnly = true;
            txtAutoRefreshTime.Text = "";
            
        }

        private void txtTimeOut_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13 || e.KeyChar == (char)8)
                {
                    return;
                }
                else if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void txtAutoRefreshTime_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13 || e.KeyChar == (char)8)
                {
                    return;
                }
                else if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ListViewItem itm;
                int i;
                
                if (txtSiteID.Text == "" || txtServerAddress.Text == "")
                {
                    return;
                }
                
                for (i = 0; i < lisOptionList.Items.Count; i++)
                {
                    if (lisOptionList.Items[i].SubItems[1].Text == txtSiteID.Text)
                    {
                        if (lisOptionList.Items[i].SubItems[2].Text == txtServerAddress.Text)
                        {
                            if (MPIF.gInit.getMiddleware == "TIBRV")
                            {
                                if (lisOptionList.Items[i].SubItems[3].Text == txtRvService.Text)
                                {
                                    if (lisOptionList.Items[i].SubItems[4].Text == txtRvNetwork.Text)
                                    {
                                        lisOptionList.Items[i].Remove();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                lisOptionList.Items[i].Remove();
                                break;
                            }
                        }
                    }
                }
                
                if (lisOptionList.Items.Count == 20)
                {
                    lisOptionList.Items[19].Remove();
                }
                
                itm = new ListViewItem("1");
                itm.SubItems.Add(txtSiteID.Text);
                itm.SubItems.Add(txtServerAddress.Text);

                if (MPIF.gInit.getMiddleware == "TIBRV")
                {
                    itm.SubItems.Add(txtRvService.Text);
                    itm.SubItems.Add(txtRvNetwork.Text);
                }

                lisOptionList.Items.Insert(0, itm);
                itm.Selected = true;
                
                for (i = 0; i < lisOptionList.Items.Count; i++)
                {
                    lisOptionList.Items[i].Text = ((int)(i + 1)).ToString();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                int i;
                int i_sel;

                if (lisOptionList.SelectedItems.Count < 1)
                {
                    return;
                }
                i_sel = lisOptionList.SelectedItems[0].Index;
                lisOptionList.SelectedItems[0].Remove();

                MPCF.FieldClear(grpOption);
                for (i = 0; i < lisOptionList.Items.Count; i++)
                {
                    lisOptionList.Items[i].Text = ((int)(i + 1)).ToString();
                }

                if (i_sel < lisOptionList.Items.Count)
                {
                    lisOptionList.Items[i_sel].Selected = true;
                }
                else
                {
                    i_sel = lisOptionList.Items.Count - 1;
                    if (i_sel >= 0)
                    {
                        lisOptionList.Items[i_sel].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void lisOptionList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (lisOptionList.SelectedItems.Count == 0)
                {
                    return;
                }
                txtSiteID.Text = lisOptionList.SelectedItems[0].SubItems[1].Text;
                txtServerAddress.Text = lisOptionList.SelectedItems[0].SubItems[2].Text;

                if (MPIF.gInit.getMiddleware == "TIBRV")
                {
                    txtRvService.Text = lisOptionList.SelectedItems[0].SubItems[3].Text;
                    txtRvNetwork.Text = lisOptionList.SelectedItems[0].SubItems[4].Text;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtVerChkTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13 || e.KeyChar == (char)8)
                {
                    return;
                }
                else if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void MsgHandlerType_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.Clicks == 2)
            {
                lblMsgHandlerType.Text = "Message Handler Type : " + MPIF.gInit.getMiddleware;
                lblMsgHandlerType.Visible = true;
            }
        }

        private void MsgHandlerType_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (lblMsgHandlerType.Visible == true)
                lblMsgHandlerType.Visible = false;
        }

        private void cdvMatType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvMatType.Init();
                MPCF.InitListView(cdvMatType.GetListView);
                cdvMatType.Columns.Add("SHOP_CODE", 100, System.Windows.Forms.HorizontalAlignment.Left);
                cdvMatType.Columns.Add("SHOP_DESC", 100, System.Windows.Forms.HorizontalAlignment.Left);
                cdvMatType.SelectedSubItemIndex = 0;
                MPOF.MFillData(cdvMatType.GetListView, "CMN_View_GCM_Data_2", new string[] {"MATERIAL_GRP_1"});
                cdvMatType.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        private void cdvMatType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                MOGV.gsMatType = cdvMatType.SelectedItem.SubItems[0].Text;
                MOGV.gsMatTypeDesc = cdvMatType.SelectedItem.SubItems[1].Text;
                MPGV.gsMatType = cdvMatType.SelectedItem.SubItems[0].Text;
                MPGV.gsMatTypeDesc = cdvMatType.SelectedItem.SubItems[1].Text;
                MOGV.gsTuneId = "";
                cdvOper.Text = "";
                cdvResId.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        // 20120802 -clearlim-Button Press Line
        private void cdvOper_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvOper.Init();
                MPCF.InitListView(cdvOper.GetListView);
                cdvOper.Columns.Add("LINE_ID", 150, HorizontalAlignment.Left);
                cdvOper.Columns.Add("LINE_DESC", 200, HorizontalAlignment.Left);
                cdvOper.SelectedSubItemIndex = 0;
                MPOF.MFillData(cdvOper.GetListView, "BAS_View_Oper_List_1", new string[] { MPCF.Trim(cdvMatType.Text) }); // DB 에러 수정 by IKPARK
                cdvOper.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        // 20120802 -clearlim-Selected Line Item Changed
        private void cdvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                MOGV.gsOper = cdvOper.SelectedItem.SubItems[0].Text;
                MOGV.gsOperDesc = cdvOper.SelectedItem.SubItems[1].Text;
                MOGV.gsTuneId = "";
                cdvResId.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }


        private void cdvResId_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvResId.Init();
                MPCF.InitListView(cdvResId.GetListView);
                cdvResId.Columns.Add("RES_ID", 150, HorizontalAlignment.Left);
                cdvResId.Columns.Add("RES_DESC", 200, HorizontalAlignment.Left);
                cdvResId.SelectedSubItemIndex = 0;
                MPOF.MFillData(cdvResId.GetListView, "BAS_View_Res_List", new string[] {MOGV.gsArea, MOGV.gsLine }); // DB 에러 수정 by IKPARK
                cdvResId.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvResId_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                //MOGV.gsResId = cdvResId.SelectedItem.SubItems[0].Text;
                //MOGV.gsTuneId = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void tabOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tabOption.SelectedTab == this.tbpUI)
                {
                    if (MPIF.gInit.InitMsgHandler() == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(104));
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        return;
                    }
                }
                else
                {
                    MPIF.gInit.TermMsgHandler();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        //private void cdvOper_ButtonPress(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(MPCF.Trim(cdvOper.Text)) == true)
        //        {
        //            MPCF.ShowMsgBox(MPCF.GetMessage(517));
        //            cdvOper.Focus();
        //            return;
        //        }

        //        cdvResource.Init();
        //        MPCF.InitListView(cdvResource.GetListView);
        //        cdvResource.Columns.Add("OPER", 100, HorizontalAlignment.Left);
        //        cdvResource.Columns.Add("OPER_DESC", 200, HorizontalAlignment.Left);
        //        cdvResource.SelectedSubItemIndex = 0;

        //        string sLineCode = MPCF.Trim(cdvOper.Text);

        //        MPOF.MFillData(cdvResource.GetListView, "BAS_View_Res_List", new string[] {sLineCode });
        //        cdvResource.InsertEmptyRow(0, 1);
        //    }
        //    catch (Exception ex)
        //    {
        //        MPCF.ShowMsgBox(ex.Message);
        //    }
        //}


        // 2018/06/05 LAKE JANG 추가
        private void cdvResource_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                MOGV.gsResource = cdvResource.SelectedItem.SubItems[0].Text;
                MOGV.gsTuneId = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvResource_ButtonPress(object sender, EventArgs e)
        {
            try
            { 
                cdvResource.Init();
                MPCF.InitListView(cdvResource.GetListView);
                cdvResource.Columns.Add("RES_ID", 150, HorizontalAlignment.Left);
                cdvResource.Columns.Add("RES_DESC", 200, HorizontalAlignment.Left);
                cdvResource.SelectedSubItemIndex = 0;
                MPOF.MFillData(cdvResource.GetListView, "BAS_View_Res_List", new string[] { MOGV.gsMatType, MOGV.gsOper });
                cdvResource.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }    
}
