
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Text;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;


//#If _RTD = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRTDSetupDispatcherRelation.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Dispatcher: View Dispatcher Definition
//       - Update_Dispatcher: Create/Update/Delete Dispatcher definition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-07-15 : Created by H.K. Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.RTDCore
{
    public class frmRTDSetupDispatcherRelation : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRTDSetupDispatcherRelation()
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
        private System.Windows.Forms.GroupBox grpDsp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblDsp;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.Panel pnlGroupFill;
        private System.Windows.Forms.TabControl tabGeneral;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox grpRuleType;
        private System.Windows.Forms.GroupBox grpCreateInfo;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.GroupBox grpPrivilege;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLotType;
        private System.Windows.Forms.Label lblLotType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResourceType;
        private Label lblResourceType;
        private Panel pnlResCond;
        private Panel pnlResCondMid;
        private TreeView tvResList;
        private ListView lisResList;
        private ColumnHeader colFactory;
        private Panel pnlResCondTop;
        private GroupBox grpResSelLevel;
        private RadioButton rbtOper;
        private RadioButton rbtResource;
        private RadioButton rbtResGroup;
        private RadioButton rbtFactory;
        private CheckBox chkOnlySettingData;
        private UI.Controls.MCCodeView.MCCodeView cdvPortType;
        private Label lblPort;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDispatcherID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpDsp = new System.Windows.Forms.GroupBox();
            this.cdvDispatcherID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblDsp = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabGeneral = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlGroupFill = new System.Windows.Forms.Panel();
            this.grpPrivilege = new System.Windows.Forms.GroupBox();
            this.grpCreateInfo = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.grpRuleType = new System.Windows.Forms.GroupBox();
            this.cdvPortType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPort = new System.Windows.Forms.Label();
            this.cdvResourceType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResourceType = new System.Windows.Forms.Label();
            this.cdvLotType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLotType = new System.Windows.Forms.Label();
            this.pnlResCond = new System.Windows.Forms.Panel();
            this.pnlResCondMid = new System.Windows.Forms.Panel();
            this.tvResList = new System.Windows.Forms.TreeView();
            this.lisResList = new System.Windows.Forms.ListView();
            this.colFactory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlResCondTop = new System.Windows.Forms.Panel();
            this.grpResSelLevel = new System.Windows.Forms.GroupBox();
            this.rbtOper = new System.Windows.Forms.RadioButton();
            this.rbtResource = new System.Windows.Forms.RadioButton();
            this.rbtResGroup = new System.Windows.Forms.RadioButton();
            this.rbtFactory = new System.Windows.Forms.RadioButton();
            this.chkOnlySettingData = new System.Windows.Forms.CheckBox();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpDsp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDispatcherID)).BeginInit();
            this.pnlTab.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlGroupFill.SuspendLayout();
            this.grpCreateInfo.SuspendLayout();
            this.grpRuleType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPortType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResourceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).BeginInit();
            this.pnlResCond.SuspendLayout();
            this.pnlResCondMid.SuspendLayout();
            this.pnlResCondTop.SuspendLayout();
            this.grpResSelLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
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
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTab);
            this.pnlRight.Controls.Add(this.grpDsp);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlResCond);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Dispatcher Setup";
            // 
            // grpDsp
            // 
            this.grpDsp.Controls.Add(this.cdvDispatcherID);
            this.grpDsp.Controls.Add(this.lblDesc);
            this.grpDsp.Controls.Add(this.lblDsp);
            this.grpDsp.Controls.Add(this.txtDesc);
            this.grpDsp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDsp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDsp.Location = new System.Drawing.Point(3, 0);
            this.grpDsp.Name = "grpDsp";
            this.grpDsp.Size = new System.Drawing.Size(500, 70);
            this.grpDsp.TabIndex = 0;
            this.grpDsp.TabStop = false;
            // 
            // cdvDispatcherID
            // 
            this.cdvDispatcherID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDispatcherID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDispatcherID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDispatcherID.BtnToolTipText = "";
            this.cdvDispatcherID.ButtonWidth = 20;
            this.cdvDispatcherID.DescText = "";
            this.cdvDispatcherID.DisplaySubItemIndex = -1;
            this.cdvDispatcherID.DisplayText = "";
            this.cdvDispatcherID.Focusing = null;
            this.cdvDispatcherID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDispatcherID.Index = 0;
            this.cdvDispatcherID.IsViewBtnImage = false;
            this.cdvDispatcherID.Location = new System.Drawing.Point(120, 16);
            this.cdvDispatcherID.MaxLength = 20;
            this.cdvDispatcherID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDispatcherID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDispatcherID.MultiSelect = false;
            this.cdvDispatcherID.Name = "cdvDispatcherID";
            this.cdvDispatcherID.ReadOnly = false;
            this.cdvDispatcherID.SameWidthHeightOfButton = false;
            this.cdvDispatcherID.SearchSubItemIndex = 0;
            this.cdvDispatcherID.SelectedDescIndex = -1;
            this.cdvDispatcherID.SelectedDescToQueryText = "";
            this.cdvDispatcherID.SelectedSubItemIndex = -1;
            this.cdvDispatcherID.SelectedValueToQueryText = "";
            this.cdvDispatcherID.SelectionStart = 0;
            this.cdvDispatcherID.Size = new System.Drawing.Size(200, 20);
            this.cdvDispatcherID.SmallImageList = null;
            this.cdvDispatcherID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDispatcherID.TabIndex = 1;
            this.cdvDispatcherID.TextBoxToolTipText = "";
            this.cdvDispatcherID.TextBoxWidth = 200;
            this.cdvDispatcherID.VisibleButton = true;
            this.cdvDispatcherID.VisibleColumnHeader = false;
            this.cdvDispatcherID.VisibleDescription = false;
            this.cdvDispatcherID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvDispatcherID_SelectedItemChanged);
            this.cdvDispatcherID.ButtonPress += new System.EventHandler(this.cdvDispatcherID_ButtonPress);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 42);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDsp
            // 
            this.lblDsp.AutoSize = true;
            this.lblDsp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDsp.Location = new System.Drawing.Point(15, 19);
            this.lblDsp.Name = "lblDsp";
            this.lblDsp.Size = new System.Drawing.Size(85, 13);
            this.lblDsp.TabIndex = 0;
            this.lblDsp.Text = "Dispatcher ID";
            this.lblDsp.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(368, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabGeneral);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(3, 70);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTab.Size = new System.Drawing.Size(500, 443);
            this.pnlTab.TabIndex = 2;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tbpGeneral);
            this.tabGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneral.ItemSize = new System.Drawing.Size(60, 18);
            this.tabGeneral.Location = new System.Drawing.Point(0, 5);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.SelectedIndex = 0;
            this.tabGeneral.Size = new System.Drawing.Size(500, 438);
            this.tabGeneral.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlGroupFill);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(492, 412);
            this.tbpGeneral.TabIndex = 3;
            this.tbpGeneral.Text = "General";
            // 
            // pnlGroupFill
            // 
            this.pnlGroupFill.Controls.Add(this.grpPrivilege);
            this.pnlGroupFill.Controls.Add(this.grpCreateInfo);
            this.pnlGroupFill.Controls.Add(this.grpRuleType);
            this.pnlGroupFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGroupFill.Location = new System.Drawing.Point(0, 0);
            this.pnlGroupFill.Name = "pnlGroupFill";
            this.pnlGroupFill.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlGroupFill.Size = new System.Drawing.Size(492, 412);
            this.pnlGroupFill.TabIndex = 0;
            // 
            // grpPrivilege
            // 
            this.grpPrivilege.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrivilege.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPrivilege.Location = new System.Drawing.Point(3, 112);
            this.grpPrivilege.Name = "grpPrivilege";
            this.grpPrivilege.Size = new System.Drawing.Size(486, 227);
            this.grpPrivilege.TabIndex = 1;
            this.grpPrivilege.TabStop = false;
            // 
            // grpCreateInfo
            // 
            this.grpCreateInfo.Controls.Add(this.txtUpdateTime);
            this.grpCreateInfo.Controls.Add(this.txtCreateTime);
            this.grpCreateInfo.Controls.Add(this.txtUpdateUser);
            this.grpCreateInfo.Controls.Add(this.lblUpdate);
            this.grpCreateInfo.Controls.Add(this.txtCreateUser);
            this.grpCreateInfo.Controls.Add(this.lblCreate);
            this.grpCreateInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCreateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreateInfo.Location = new System.Drawing.Point(3, 339);
            this.grpCreateInfo.Name = "grpCreateInfo";
            this.grpCreateInfo.Size = new System.Drawing.Size(486, 70);
            this.grpCreateInfo.TabIndex = 2;
            this.grpCreateInfo.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(306, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(306, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(126, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(10, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(126, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(10, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpRuleType
            // 
            this.grpRuleType.Controls.Add(this.cdvPortType);
            this.grpRuleType.Controls.Add(this.lblPort);
            this.grpRuleType.Controls.Add(this.cdvResourceType);
            this.grpRuleType.Controls.Add(this.lblResourceType);
            this.grpRuleType.Controls.Add(this.cdvLotType);
            this.grpRuleType.Controls.Add(this.lblLotType);
            this.grpRuleType.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpRuleType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRuleType.Location = new System.Drawing.Point(3, 5);
            this.grpRuleType.Name = "grpRuleType";
            this.grpRuleType.Size = new System.Drawing.Size(486, 107);
            this.grpRuleType.TabIndex = 0;
            this.grpRuleType.TabStop = false;
            this.grpRuleType.Text = "Rule Types";
            // 
            // cdvPortType
            // 
            this.cdvPortType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPortType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPortType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPortType.BtnToolTipText = "";
            this.cdvPortType.ButtonWidth = 20;
            this.cdvPortType.DescText = "";
            this.cdvPortType.DisplaySubItemIndex = -1;
            this.cdvPortType.DisplayText = "";
            this.cdvPortType.Focusing = null;
            this.cdvPortType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPortType.Index = 0;
            this.cdvPortType.IsViewBtnImage = false;
            this.cdvPortType.Location = new System.Drawing.Point(120, 68);
            this.cdvPortType.MaxLength = 20;
            this.cdvPortType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPortType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPortType.MultiSelect = false;
            this.cdvPortType.Name = "cdvPortType";
            this.cdvPortType.ReadOnly = true;
            this.cdvPortType.SameWidthHeightOfButton = false;
            this.cdvPortType.SearchSubItemIndex = 0;
            this.cdvPortType.SelectedDescIndex = -1;
            this.cdvPortType.SelectedDescToQueryText = "";
            this.cdvPortType.SelectedSubItemIndex = -1;
            this.cdvPortType.SelectedValueToQueryText = "";
            this.cdvPortType.SelectionStart = 0;
            this.cdvPortType.Size = new System.Drawing.Size(200, 20);
            this.cdvPortType.SmallImageList = null;
            this.cdvPortType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPortType.TabIndex = 5;
            this.cdvPortType.TextBoxToolTipText = "";
            this.cdvPortType.TextBoxWidth = 200;
            this.cdvPortType.VisibleButton = false;
            this.cdvPortType.VisibleColumnHeader = false;
            this.cdvPortType.VisibleDescription = false;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(15, 71);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "Port";
            // 
            // cdvResourceType
            // 
            this.cdvResourceType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResourceType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResourceType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResourceType.BtnToolTipText = "";
            this.cdvResourceType.ButtonWidth = 20;
            this.cdvResourceType.DescText = "";
            this.cdvResourceType.DisplaySubItemIndex = -1;
            this.cdvResourceType.DisplayText = "";
            this.cdvResourceType.Focusing = null;
            this.cdvResourceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResourceType.Index = 0;
            this.cdvResourceType.IsViewBtnImage = false;
            this.cdvResourceType.Location = new System.Drawing.Point(120, 43);
            this.cdvResourceType.MaxLength = 20;
            this.cdvResourceType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResourceType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResourceType.MultiSelect = false;
            this.cdvResourceType.Name = "cdvResourceType";
            this.cdvResourceType.ReadOnly = true;
            this.cdvResourceType.SameWidthHeightOfButton = false;
            this.cdvResourceType.SearchSubItemIndex = 0;
            this.cdvResourceType.SelectedDescIndex = -1;
            this.cdvResourceType.SelectedDescToQueryText = "";
            this.cdvResourceType.SelectedSubItemIndex = -1;
            this.cdvResourceType.SelectedValueToQueryText = "";
            this.cdvResourceType.SelectionStart = 0;
            this.cdvResourceType.Size = new System.Drawing.Size(200, 20);
            this.cdvResourceType.SmallImageList = null;
            this.cdvResourceType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResourceType.TabIndex = 3;
            this.cdvResourceType.TextBoxToolTipText = "";
            this.cdvResourceType.TextBoxWidth = 200;
            this.cdvResourceType.VisibleButton = false;
            this.cdvResourceType.VisibleColumnHeader = false;
            this.cdvResourceType.VisibleDescription = false;
            // 
            // lblResourceType
            // 
            this.lblResourceType.AutoSize = true;
            this.lblResourceType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResourceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResourceType.Location = new System.Drawing.Point(15, 46);
            this.lblResourceType.Name = "lblResourceType";
            this.lblResourceType.Size = new System.Drawing.Size(53, 13);
            this.lblResourceType.TabIndex = 2;
            this.lblResourceType.Text = "Resource";
            // 
            // cdvLotType
            // 
            this.cdvLotType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLotType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLotType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLotType.BtnToolTipText = "";
            this.cdvLotType.ButtonWidth = 20;
            this.cdvLotType.DescText = "";
            this.cdvLotType.DisplaySubItemIndex = -1;
            this.cdvLotType.DisplayText = "";
            this.cdvLotType.Focusing = null;
            this.cdvLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLotType.Index = 0;
            this.cdvLotType.IsViewBtnImage = false;
            this.cdvLotType.Location = new System.Drawing.Point(120, 19);
            this.cdvLotType.MaxLength = 20;
            this.cdvLotType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.MultiSelect = false;
            this.cdvLotType.Name = "cdvLotType";
            this.cdvLotType.ReadOnly = true;
            this.cdvLotType.SameWidthHeightOfButton = false;
            this.cdvLotType.SearchSubItemIndex = 0;
            this.cdvLotType.SelectedDescIndex = -1;
            this.cdvLotType.SelectedDescToQueryText = "";
            this.cdvLotType.SelectedSubItemIndex = -1;
            this.cdvLotType.SelectedValueToQueryText = "";
            this.cdvLotType.SelectionStart = 0;
            this.cdvLotType.Size = new System.Drawing.Size(200, 20);
            this.cdvLotType.SmallImageList = null;
            this.cdvLotType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLotType.TabIndex = 1;
            this.cdvLotType.TextBoxToolTipText = "";
            this.cdvLotType.TextBoxWidth = 200;
            this.cdvLotType.VisibleButton = false;
            this.cdvLotType.VisibleColumnHeader = false;
            this.cdvLotType.VisibleDescription = false;
            // 
            // lblLotType
            // 
            this.lblLotType.AutoSize = true;
            this.lblLotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotType.Location = new System.Drawing.Point(15, 22);
            this.lblLotType.Name = "lblLotType";
            this.lblLotType.Size = new System.Drawing.Size(22, 13);
            this.lblLotType.TabIndex = 0;
            this.lblLotType.Text = "Lot";
            // 
            // pnlResCond
            // 
            this.pnlResCond.Controls.Add(this.pnlResCondMid);
            this.pnlResCond.Controls.Add(this.pnlResCondTop);
            this.pnlResCond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResCond.Location = new System.Drawing.Point(3, 3);
            this.pnlResCond.Name = "pnlResCond";
            this.pnlResCond.Size = new System.Drawing.Size(229, 508);
            this.pnlResCond.TabIndex = 2;
            // 
            // pnlResCondMid
            // 
            this.pnlResCondMid.Controls.Add(this.tvResList);
            this.pnlResCondMid.Controls.Add(this.lisResList);
            this.pnlResCondMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResCondMid.Location = new System.Drawing.Point(0, 131);
            this.pnlResCondMid.Name = "pnlResCondMid";
            this.pnlResCondMid.Size = new System.Drawing.Size(229, 377);
            this.pnlResCondMid.TabIndex = 1;
            // 
            // tvResList
            // 
            this.tvResList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvResList.Location = new System.Drawing.Point(0, 0);
            this.tvResList.Name = "tvResList";
            this.tvResList.Size = new System.Drawing.Size(229, 377);
            this.tvResList.TabIndex = 0;
            this.tvResList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvResList_AfterSelect);
            this.tvResList.Click += new System.EventHandler(this.tvResList_Click);
            // 
            // lisResList
            // 
            this.lisResList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFactory});
            this.lisResList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResList.Location = new System.Drawing.Point(0, 0);
            this.lisResList.MultiSelect = false;
            this.lisResList.Name = "lisResList";
            this.lisResList.Size = new System.Drawing.Size(229, 377);
            this.lisResList.TabIndex = 1;
            this.lisResList.UseCompatibleStateImageBehavior = false;
            this.lisResList.View = System.Windows.Forms.View.Details;
            this.lisResList.SelectedIndexChanged += new System.EventHandler(this.lisResList_SelectedIndexChanged);
            // 
            // colFactory
            // 
            this.colFactory.Text = "Factory";
            this.colFactory.Width = 150;
            // 
            // pnlResCondTop
            // 
            this.pnlResCondTop.Controls.Add(this.grpResSelLevel);
            this.pnlResCondTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResCondTop.Location = new System.Drawing.Point(0, 0);
            this.pnlResCondTop.Name = "pnlResCondTop";
            this.pnlResCondTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlResCondTop.Size = new System.Drawing.Size(229, 131);
            this.pnlResCondTop.TabIndex = 0;
            // 
            // grpResSelLevel
            // 
            this.grpResSelLevel.Controls.Add(this.rbtOper);
            this.grpResSelLevel.Controls.Add(this.rbtResource);
            this.grpResSelLevel.Controls.Add(this.rbtResGroup);
            this.grpResSelLevel.Controls.Add(this.rbtFactory);
            this.grpResSelLevel.Controls.Add(this.chkOnlySettingData);
            this.grpResSelLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResSelLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResSelLevel.Location = new System.Drawing.Point(0, 0);
            this.grpResSelLevel.Name = "grpResSelLevel";
            this.grpResSelLevel.Size = new System.Drawing.Size(229, 128);
            this.grpResSelLevel.TabIndex = 0;
            this.grpResSelLevel.TabStop = false;
            this.grpResSelLevel.Text = "Level Select";
            // 
            // rbtOper
            // 
            this.rbtOper.AutoSize = true;
            this.rbtOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtOper.Location = new System.Drawing.Point(15, 39);
            this.rbtOper.Name = "rbtOper";
            this.rbtOper.Size = new System.Drawing.Size(77, 18);
            this.rbtOper.TabIndex = 1;
            this.rbtOper.Text = "Operation";
            this.rbtOper.CheckedChanged += new System.EventHandler(this.rbtResSelLevel_CheckedChanged);
            // 
            // rbtResource
            // 
            this.rbtResource.AutoSize = true;
            this.rbtResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtResource.Location = new System.Drawing.Point(15, 83);
            this.rbtResource.Name = "rbtResource";
            this.rbtResource.Size = new System.Drawing.Size(77, 18);
            this.rbtResource.TabIndex = 3;
            this.rbtResource.Text = "Resource";
            this.rbtResource.CheckedChanged += new System.EventHandler(this.rbtResSelLevel_CheckedChanged);
            // 
            // rbtResGroup
            // 
            this.rbtResGroup.AutoSize = true;
            this.rbtResGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtResGroup.Location = new System.Drawing.Point(15, 61);
            this.rbtResGroup.Name = "rbtResGroup";
            this.rbtResGroup.Size = new System.Drawing.Size(112, 18);
            this.rbtResGroup.TabIndex = 2;
            this.rbtResGroup.Text = "Resource Group ";
            this.rbtResGroup.CheckedChanged += new System.EventHandler(this.rbtResSelLevel_CheckedChanged);
            // 
            // rbtFactory
            // 
            this.rbtFactory.AutoSize = true;
            this.rbtFactory.Checked = true;
            this.rbtFactory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbtFactory.Location = new System.Drawing.Point(15, 17);
            this.rbtFactory.Name = "rbtFactory";
            this.rbtFactory.Size = new System.Drawing.Size(66, 18);
            this.rbtFactory.TabIndex = 0;
            this.rbtFactory.TabStop = true;
            this.rbtFactory.Text = "Factory";
            this.rbtFactory.CheckedChanged += new System.EventHandler(this.rbtResSelLevel_CheckedChanged);
            // 
            // chkOnlySettingData
            // 
            this.chkOnlySettingData.AutoSize = true;
            this.chkOnlySettingData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOnlySettingData.Location = new System.Drawing.Point(15, 105);
            this.chkOnlySettingData.Name = "chkOnlySettingData";
            this.chkOnlySettingData.Size = new System.Drawing.Size(115, 18);
            this.chkOnlySettingData.TabIndex = 4;
            this.chkOnlySettingData.Text = "Only Setting Data";
            this.chkOnlySettingData.CheckedChanged += new System.EventHandler(this.chkOnlySettingData_CheckedChanged);
            // 
            // frmRTDSetupDispatcherRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRTDSetupDispatcherRelation";
            this.Text = "Dispatcher Relation Setup";
            this.Activated += new System.EventHandler(this.frmRTDSetupDispatcherRelation_Activated);
            this.Load += new System.EventHandler(this.frmRTDSetupDispatcherRelation_Load);
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
            this.grpDsp.ResumeLayout(false);
            this.grpDsp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDispatcherID)).EndInit();
            this.pnlTab.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlGroupFill.ResumeLayout(false);
            this.grpCreateInfo.ResumeLayout(false);
            this.grpCreateInfo.PerformLayout();
            this.grpRuleType.ResumeLayout(false);
            this.grpRuleType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPortType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResourceType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).EndInit();
            this.pnlResCond.ResumeLayout(false);
            this.pnlResCondMid.ResumeLayout(false);
            this.pnlResCondTop.ResumeLayout(false);
            this.grpResSelLevel.ResumeLayout(false);
            this.grpResSelLevel.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Variable Definition"
        bool b_load_flag = false;
        private char lm_res_relation_level;
        private string lm_res_group;
        private string lm_res_id;
        private string lm_oper;
        #endregion
        
        #region "Function Definition"
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string c_step)
        {
            if (tvResList.SelectedNode == null)
            {
                //Add by J.S. 2009.03.18 only setting data가 설정 되어 있을 때 에러 나는 부분 해소
                if (lisResList.SelectedItems.Count <= 0)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                    tvResList.Focus();
                    return false;
                }
            }


            if (MPCF.CheckValue(cdvDispatcherID, 1) == false)
            {
                return false;
            }           
                        
            switch (c_step)
            {
                case "I":
                                        
                    break;
                case "U":
                    
                    break;
                case "D":

                    break;                    
                
            }
            
            return true;
            
        }

        private void InitResourceTree()
        {
            MPCF.InitTreeView(tvResList);

            if (rbtFactory.Checked == true)
            {
                TreeNode node;
                node = tvResList.Nodes.Add(MPGV.gsFactory);
                node.ImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.SelectedImageIndex = (int)SMALLICON_INDEX.IDX_FACTORY;
                node.Expand();
            }
            else if (rbtResGroup.Checked == true)
            {
                if (RASLIST.ViewResourceGroupList(tvResList, '1') == false) return;
            }
            else if (rbtResource.Checked == true)
            {
                if (RASLIST.ViewResourceList(tvResList, false) == false) return;
            }
            else if (rbtOper.Checked == true)
            {
                if (WIPLIST.ViewOperationList(tvResList, '1') == false) return;
            }
        }


        //
        // ViewResourceSettingData()
        //       - Get setting data list
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - 
        //
        private bool ViewResourceSettingData()
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");
            StringBuilder sb;
            char c_relation_level;

            MPCF.InitListView(lisResList);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            c_relation_level = ' ';

            sb = new StringBuilder();


            if (rbtFactory.Checked == true)
            {
                lisResList.Columns[0].Text = "Factory";
                c_relation_level = 'F';
                sb.Append("SELECT FACTORY FROM MRTDRESOPR ");
                sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                sb.Append("AND RELATION_LEVEL IN ('" + c_relation_level.ToString() + "' ) ");
                sb.Append("GROUP BY FACTORY ");
                sb.Append("ORDER BY FACTORY");
            }
            else if (rbtResGroup.Checked == true)
            {
                lisResList.Columns[0].Text = "Resource Group";
                c_relation_level = 'G';
                sb.Append("SELECT RESG_ID FROM MRTDRESOPR ");
                sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                sb.Append("AND RELATION_LEVEL IN ('" + c_relation_level.ToString() + "' ) ");
                sb.Append("GROUP BY RESG_ID ");
                sb.Append("ORDER BY RESG_ID");
            }
            else if (rbtResource.Checked == true)
            {
                lisResList.Columns[0].Text = "Resource";
                c_relation_level = 'R';
                sb.Append("SELECT RES_ID FROM MRTDRESOPR ");
                sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                sb.Append("AND RELATION_LEVEL IN ('" + c_relation_level.ToString() + "' ) ");
                sb.Append("GROUP BY RES_ID ");
                sb.Append("ORDER BY RES_ID");
            }
            else if (rbtOper.Checked == true)
            {
                lisResList.Columns[0].Text = "Operation";
                c_relation_level = 'O';
                sb.Append("SELECT OPER FROM MRTDRESOPR ");
                sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' ");
                sb.Append("AND RELATION_LEVEL IN ('" + c_relation_level.ToString() + "' ) ");
                sb.Append("GROUP BY OPER ");
                sb.Append("ORDER BY OPER");
            }

            
           

            in_node.AddString("SQL", sb.ToString());

            do
            {
                if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.FillDataView(lisResList, out_node, false, (int)SMALLICON_INDEX.IDX_MODULE, false);

                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
            } while (out_node.GetInt("NEXT_ROW") > 0);

            return true;
        }


        //
        // ViewDispatchRelationList
        //       - View Dispatch Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewDispatcherRelation(char c_relation_level, string s_oper, string s_res_grp, string s_res_id)
        {
            TRSNode in_node = new TRSNode("VIEW_DISPATCH_RELATION_IN");
            TRSNode out_node = new TRSNode("VIEW_DISPATCH_RELATION_OUT");

            MPCF.FieldClear(grpDsp);
            MPCF.FieldClear(grpRuleType);
            MPCF.FieldClear(grpCreateInfo);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddChar("RELATION_LEVEL", c_relation_level);
            in_node.AddString("OPER", s_oper);
            in_node.AddString("RESG_ID", s_res_grp);
            in_node.AddString("RES_ID", s_res_id);

            if (MPCR.CallService("RTD", "RTD_View_Dispatch_Relation", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("DSP_ID") != "")
            {
                cdvDispatcherID.Text = out_node.GetString("DSP_ID");
                /* Added By YJJung 160712 Create Time, User, Update Time, User was not included - Bug fix */
                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                /* Added End */
                if (View_Dispatcher(MPCF.Trim(cdvDispatcherID.Text)) == false)
                {
                    return false;
                }
            }

            return true;

        }

        //
        // View_Dispatcher()
        //       - View Dispatcher Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Dispatcher(string sDispatcherID)
        {
            TRSNode in_node = new TRSNode("VIEW_DISPATCHER_IN");
            TRSNode out_node = new TRSNode("VIEW_DISPATCHER_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("DSP_ID", sDispatcherID);

                if (MPCR.CallService("RTD", "RTD_View_Dispatcher", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvDispatcherID.Text = MPCF.Trim(out_node.GetString("DSP_ID"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("DSP_DESC"));
                cdvLotType.Text = MPCF.Trim(out_node.GetString("LOT_RULE"));
                cdvResourceType.Text = MPCF.Trim(out_node.GetString("RESOURCE_RULE"));
                cdvPortType.Text = MPCF.Trim(out_node.GetString("PORT_RULE"));
                /* Deleted By YJJung 160712 Create Time, User, Update Time, User was not included - Bug fix */
                //txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                //txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                //txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                //txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                /* Delete End */
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // UpdateDispatchRelation()
        //       - Create/Update/Delete Dispatch Message
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool UpdateDispatchRelation(char ProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_DISPATCH_RELATION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddChar("RELATION_LEVEL", lm_res_relation_level);
                in_node.AddString("RESG_ID", lm_res_group);
                in_node.AddString("RES_ID", lm_res_id);
                in_node.AddString("OPER", lm_oper);

                in_node.AddString("DSP_ID", cdvDispatcherID.Text);

                if (MPCR.CallService("RTD", "RTD_Update_Dispatch_Relation", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }


        // SelectClear()
        //       - Clear Selected Items
        // Return Value
        //       -
        // Arguments
        //       - ByVal list As ListView : ListView
        //
        private object SelectClear(ListView list)
        {
            int i;
            for (i = 0; i <= list.Items.Count - 1; i++)
            {
                list.Items[i].Selected = false;
            }
            return null;
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvDispatcherID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRTDSetupDispatcherRelation_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    
                    lblDataCount.Text = "";
                    rbtFactory.Checked = true;
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void frmRTDSetupDispatcherRelation_Load(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this);
                cdvLotType.BackColor = System.Drawing.SystemColors.Control;
                cdvResourceType.BackColor = System.Drawing.SystemColors.Control;
                cdvPortType.BackColor = System.Drawing.SystemColors.Control;
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
                chkOnlySettingData_CheckedChanged(null, null);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
       
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("I") == false)
            {
                return;
            }
            UpdateDispatchRelation(MPGC.MP_STEP_CREATE);
            /* Added By YJJung 160712 Initialization is added */
            ViewDispatcherRelation(lm_res_relation_level, lm_oper, lm_res_group, lm_res_id);
        }
    
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("U") == false)
            {
                return;
            }
            UpdateDispatchRelation(MPGC.MP_STEP_UPDATE);
            /* Added By YJJung 160712 Initialization is added */
            ViewDispatcherRelation(lm_res_relation_level, lm_oper, lm_res_group, lm_res_id);
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            if (CheckCondition("D") == false)
            {
                return;
            }
            if (UpdateDispatchRelation(MPGC.MP_STEP_DELETE) == true)
            {
                MPCF.FieldClear(this.pnlRight);

                //Add by J.S. 2009.03.19 chkOnlySetting 설정후 삭제시 refresh함.
                if (chkOnlySettingData.Checked == true)
                    try
                    {
                        chkOnlySettingData_CheckedChanged(null, null);
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
                {
                }
            }
        }

 
        private void tvResList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string s_res_group = "";
            string s_res_id = "";
            string s_oper = "";
            char c_relation_level = ' ';

            if (e.Action == TreeViewAction.Collapse || e.Action == TreeViewAction.Expand || e.Action == TreeViewAction.Unknown) return;

            switch (e.Node.Level)
            {
                case 0:
                    if (rbtFactory.Checked == true)
                    {
                        c_relation_level = 'F';
                    }
                    else if (rbtResGroup.Checked == true)
                    {
                        c_relation_level = 'G';

                        s_res_group = MPCF.Trim(e.Node.Text);
                        s_res_group = MPCF.SubtractString(s_res_group, ":", false, false);
                                               
                    }
                    else if (rbtResource.Checked == true)
                    {
                        c_relation_level = 'R';
                        s_res_id = MPCF.Trim(e.Node.Text);
                        s_res_id = MPCF.SubtractString(s_res_id, ":", false, false);
                    }
                    else if (rbtOper.Checked == true)
                    {
                        c_relation_level = 'O';
                        s_oper = MPCF.Trim(e.Node.Text);
                        s_oper = MPCF.SubtractString(s_oper, ":", false, false);
                    }
                    break;

                
            }

            lm_res_relation_level = c_relation_level;
            lm_res_group = s_res_group;
            lm_res_id = s_res_id;
            lm_oper = s_oper;

            ViewDispatcherRelation(c_relation_level, s_oper, s_res_group, s_res_id);
        }

        private void tvResList_Click(object sender, EventArgs e)
        {
            tvResList.SelectedNode = null;
        }

        private void rbtResSelLevel_CheckedChanged(object sender, EventArgs e)
        {
            MPCF.FieldClear(pnlRight);

            if (((RadioButton)sender).Checked == true)
                chkOnlySettingData_CheckedChanged(null, null);
        }

        private void chkOnlySettingData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnlySettingData.Checked == true)
            {
                lisResList.Visible = true;
                tvResList.Visible = false;

                ViewResourceSettingData();
            }
            else
            {
                lisResList.Visible = false;
                tvResList.Visible = true;

                InitResourceTree();
            }
        }

        private void lisResList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s_res_group = "";
            string s_res_id = "";
            string s_oper = "";
            char c_relation_level = ' ';

            if (lisResList.SelectedItems.Count < 1) return;

            if (rbtFactory.Checked == true)
            {
                c_relation_level = 'F';
            }
            else if (rbtResGroup.Checked == true)
            {
                c_relation_level = 'G';

                s_res_group = MPCF.Trim(lisResList.SelectedItems[0].Text);
            }
            else if (rbtResource.Checked == true)
            {
                c_relation_level = 'R';

                s_res_id = MPCF.Trim(lisResList.SelectedItems[0].Text);
            }
            else if (rbtOper.Checked == true)
            {
                c_relation_level = 'O';

                s_oper = MPCF.Trim(lisResList.SelectedItems[0].Text);
            }

            lm_res_relation_level = c_relation_level;
            lm_res_group = s_res_group;
            lm_res_id = s_res_id;
            lm_oper = s_oper;

            ViewDispatcherRelation(c_relation_level, s_oper, s_res_group, s_res_id);
        }

        private void cdvDispatcherID_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvDispatcherID.Init();
                MPCF.InitListView(cdvDispatcherID.GetListView);
                cdvDispatcherID.Columns.Add("DispatchID", 100, HorizontalAlignment.Left);
                cdvDispatcherID.Columns.Add("Description", 150, HorizontalAlignment.Left);
                cdvDispatcherID.SelectedSubItemIndex = 0;
                if (RTDLIST.ViewDispatcherList(cdvDispatcherID.GetListView, '1', null, "") == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvDispatcherID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (MPCF.Trim(cdvDispatcherID.Text) != "")
                {
                    if (View_Dispatcher(MPCF.Trim(cdvDispatcherID.Text)) == false)
                    {
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        
    }
    //#End If
}
