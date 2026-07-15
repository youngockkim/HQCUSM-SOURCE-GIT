
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

//#If _RTD = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRTDSetupDispatcher.vb
//   Description :
//
//   MES Version : 4.2.0.0
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
//       - 2005-07-15 : Created by LAVERWON
//
//
//   Copyright(C) 1998-2008 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.RTDCore
{
    public class frmRTDSetupDispatcher : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRTDSetupDispatcher()
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
        private System.Windows.Forms.TextBox txtDspID;
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
        private Miracom.UI.Controls.MCListView.MCListView lisDispatcher;
        private ColumnHeader colDispatcherID;
        private ColumnHeader colDispatcherDesc;
        private UI.Controls.MCCodeView.MCCodeView cdvPortType;
        private Label lblPort;
        private Label lblResourceType;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpDsp = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblDsp = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtDspID = new System.Windows.Forms.TextBox();
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
            this.lisDispatcher = new Miracom.UI.Controls.MCListView.MCListView();
            this.colDispatcherID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDispatcherDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpDsp.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlGroupFill.SuspendLayout();
            this.grpCreateInfo.SuspendLayout();
            this.grpRuleType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPortType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResourceType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).BeginInit();
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
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTab);
            this.pnlRight.Controls.Add(this.grpDsp);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisDispatcher);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 2);
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
            this.lblFormTitle.Text = "Dispatcher Setup";
            // 
            // grpDsp
            // 
            this.grpDsp.Controls.Add(this.lblDesc);
            this.grpDsp.Controls.Add(this.lblDsp);
            this.grpDsp.Controls.Add(this.txtDesc);
            this.grpDsp.Controls.Add(this.txtDspID);
            this.grpDsp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDsp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDsp.Location = new System.Drawing.Point(3, 0);
            this.grpDsp.Name = "grpDsp";
            this.grpDsp.Size = new System.Drawing.Size(500, 70);
            this.grpDsp.TabIndex = 0;
            this.grpDsp.TabStop = false;
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
            this.txtDesc.Size = new System.Drawing.Size(368, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // txtDspID
            // 
            this.txtDspID.Location = new System.Drawing.Point(120, 16);
            this.txtDspID.MaxLength = 20;
            this.txtDspID.Name = "txtDspID";
            this.txtDspID.Size = new System.Drawing.Size(200, 20);
            this.txtDspID.TabIndex = 1;
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabGeneral);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(3, 70);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTab.Size = new System.Drawing.Size(500, 436);
            this.pnlTab.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tbpGeneral);
            this.tabGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneral.ItemSize = new System.Drawing.Size(60, 18);
            this.tabGeneral.Location = new System.Drawing.Point(0, 5);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.SelectedIndex = 0;
            this.tabGeneral.Size = new System.Drawing.Size(500, 431);
            this.tabGeneral.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlGroupFill);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(492, 405);
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
            this.pnlGroupFill.Size = new System.Drawing.Size(492, 405);
            this.pnlGroupFill.TabIndex = 0;
            // 
            // grpPrivilege
            // 
            this.grpPrivilege.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrivilege.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPrivilege.Location = new System.Drawing.Point(3, 107);
            this.grpPrivilege.Name = "grpPrivilege";
            this.grpPrivilege.Size = new System.Drawing.Size(486, 225);
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
            this.grpCreateInfo.Location = new System.Drawing.Point(3, 332);
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
            this.grpRuleType.Size = new System.Drawing.Size(486, 102);
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
            this.cdvPortType.Location = new System.Drawing.Point(120, 67);
            this.cdvPortType.MaxLength = 20;
            this.cdvPortType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPortType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPortType.MultiSelect = false;
            this.cdvPortType.Name = "cdvPortType";
            this.cdvPortType.ReadOnly = false;
            this.cdvPortType.SameWidthHeightOfButton = false;
            this.cdvPortType.SearchSubItemIndex = 0;
            this.cdvPortType.SelectedDescIndex = -1;
            this.cdvPortType.SelectedDescToQueryText = "";
            this.cdvPortType.SelectedSubItemIndex = -1;
            this.cdvPortType.SelectedValueToQueryText = "";
            this.cdvPortType.SelectionStart = 0;
            this.cdvPortType.Size = new System.Drawing.Size(210, 20);
            this.cdvPortType.SmallImageList = null;
            this.cdvPortType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPortType.TabIndex = 5;
            this.cdvPortType.TextBoxToolTipText = "";
            this.cdvPortType.TextBoxWidth = 210;
            this.cdvPortType.VisibleButton = true;
            this.cdvPortType.VisibleColumnHeader = false;
            this.cdvPortType.VisibleDescription = false;
            this.cdvPortType.ButtonPress += new System.EventHandler(this.cdvPortType_ButtonPress);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(15, 71);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(30, 13);
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
            this.cdvResourceType.ReadOnly = false;
            this.cdvResourceType.SameWidthHeightOfButton = false;
            this.cdvResourceType.SearchSubItemIndex = 0;
            this.cdvResourceType.SelectedDescIndex = -1;
            this.cdvResourceType.SelectedDescToQueryText = "";
            this.cdvResourceType.SelectedSubItemIndex = -1;
            this.cdvResourceType.SelectedValueToQueryText = "";
            this.cdvResourceType.SelectionStart = 0;
            this.cdvResourceType.Size = new System.Drawing.Size(210, 20);
            this.cdvResourceType.SmallImageList = null;
            this.cdvResourceType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResourceType.TabIndex = 3;
            this.cdvResourceType.TextBoxToolTipText = "";
            this.cdvResourceType.TextBoxWidth = 210;
            this.cdvResourceType.VisibleButton = true;
            this.cdvResourceType.VisibleColumnHeader = false;
            this.cdvResourceType.VisibleDescription = false;
            this.cdvResourceType.ButtonPress += new System.EventHandler(this.cdvResourceType_ButtonPress);
            // 
            // lblResourceType
            // 
            this.lblResourceType.AutoSize = true;
            this.lblResourceType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResourceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResourceType.Location = new System.Drawing.Point(15, 46);
            this.lblResourceType.Name = "lblResourceType";
            this.lblResourceType.Size = new System.Drawing.Size(61, 13);
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
            this.cdvLotType.ReadOnly = false;
            this.cdvLotType.SameWidthHeightOfButton = false;
            this.cdvLotType.SearchSubItemIndex = 0;
            this.cdvLotType.SelectedDescIndex = -1;
            this.cdvLotType.SelectedDescToQueryText = "";
            this.cdvLotType.SelectedSubItemIndex = -1;
            this.cdvLotType.SelectedValueToQueryText = "";
            this.cdvLotType.SelectionStart = 0;
            this.cdvLotType.Size = new System.Drawing.Size(210, 20);
            this.cdvLotType.SmallImageList = null;
            this.cdvLotType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLotType.TabIndex = 1;
            this.cdvLotType.TextBoxToolTipText = "";
            this.cdvLotType.TextBoxWidth = 210;
            this.cdvLotType.VisibleButton = true;
            this.cdvLotType.VisibleColumnHeader = false;
            this.cdvLotType.VisibleDescription = false;
            this.cdvLotType.ButtonPress += new System.EventHandler(this.cdvLotType_ButtonPress);
            // 
            // lblLotType
            // 
            this.lblLotType.AutoSize = true;
            this.lblLotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotType.Location = new System.Drawing.Point(15, 22);
            this.lblLotType.Name = "lblLotType";
            this.lblLotType.Size = new System.Drawing.Size(25, 13);
            this.lblLotType.TabIndex = 0;
            this.lblLotType.Text = "Lot";
            // 
            // lisDispatcher
            // 
            this.lisDispatcher.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDispatcherID,
            this.colDispatcherDesc});
            this.lisDispatcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisDispatcher.EnableSort = true;
            this.lisDispatcher.EnableSortIcon = true;
            this.lisDispatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisDispatcher.FullRowSelect = true;
            this.lisDispatcher.HideSelection = false;
            this.lisDispatcher.Location = new System.Drawing.Point(3, 3);
            this.lisDispatcher.MultiSelect = false;
            this.lisDispatcher.Name = "lisDispatcher";
            this.lisDispatcher.Size = new System.Drawing.Size(229, 501);
            this.lisDispatcher.TabIndex = 0;
            this.lisDispatcher.UseCompatibleStateImageBehavior = false;
            this.lisDispatcher.View = System.Windows.Forms.View.Details;
            this.lisDispatcher.SelectedIndexChanged += new System.EventHandler(this.lisDispatcher_SelectedIndexChanged);
            // 
            // colDispatcherID
            // 
            this.colDispatcherID.Text = "Dispatcher ID";
            this.colDispatcherID.Width = 100;
            // 
            // colDispatcherDesc
            // 
            this.colDispatcherDesc.Text = "Description";
            this.colDispatcherDesc.Width = 300;
            // 
            // frmRTDSetupDispatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRTDSetupDispatcher";
            this.Text = "Dispatcher Setup";
            this.Activated += new System.EventHandler(this.frmRTDSetupDispatcher_Activated);
            this.Load += new System.EventHandler(this.frmRTDSetupDispatcher_Load);
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
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Variable Definition"
        bool b_load_flag = false;
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

            if (MPCF.CheckValue(txtDspID, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvLotType, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvResourceType, 1) == false)
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
        //
        // Update_Dispatcher()
        //       - Create/Update/Delete Dispatcher Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_Dispatcher(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_DISPATCHER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            int idx;
            ListViewItem itm;

            try
            {
                MPCR.SetInMsg(in_node);
                 in_node.ProcStep = c_step;

                in_node.AddString("DSP_ID", MPCF.Trim(txtDspID.Text));
                in_node.AddString("DSP_DESC", MPCF.Trim(txtDesc.Text));

                in_node.AddString("LOT_RULE", MPCF.Trim(cdvLotType.Text));
                in_node.AddString("RESOURCE_RULE", MPCF.Trim(cdvResourceType.Text));
                in_node.AddString("PORT_RULE", MPCF.Trim(cdvPortType.Text));

                if (MPCR.CallService("RTD", "RTD_Update_Dispatcher", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisDispatcher.Items.Add(MPCF.Trim(txtDspID.Text), (int)SMALLICON_INDEX.IDX_DISPATCHER);
                        itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                        itm.Selected = true;
                        lisDispatcher.Sorting = SortOrder.Ascending;
                        lisDispatcher.Sort();
                        itm.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisDispatcher, MPCF.Trim(txtDspID.Text), false) == true)
                        {
                            lisDispatcher.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisDispatcher, MPCF.Trim(txtDspID.Text), false);
                        if (idx != -1)
                        {
                            lisDispatcher.Items[idx].Remove();
                        }
                    }
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

                txtDspID.Text = MPCF.Trim(out_node.GetString("DSP_ID"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("DSP_DESC"));
                cdvLotType.Text = MPCF.Trim(out_node.GetString("LOT_RULE"));
                cdvResourceType.Text = MPCF.Trim(out_node.GetString("RESOURCE_RULE"));
                cdvPortType.Text = MPCF.Trim(out_node.GetString("PORT_RULE"));

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
                return this.lisDispatcher;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("I") == false)
            {
                return;
            }
            if (Update_Dispatcher(MPGC.MP_STEP_CREATE) == true)
            {
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                    MPCF.FindListItem(lisDispatcher, txtDspID.Text, false);
                }
                
            }
        }
        
        private void frmRTDSetupDispatcher_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    
                    lblDataCount.Text = "";
                    if (RTDLIST.ViewDispatcherList(lisDispatcher, '1', null, "") == true)
                    {
                        lblDataCount.Text = lisDispatcher.Items.Count.ToString();
                    }
                    else
                    {
                        return;
                    }
                    if (lisDispatcher.Items.Count > 0)
                    {
                        lisDispatcher.Items[0].Selected = true;
                    }
                                        
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void frmRTDSetupDispatcher_Load(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this);
                MPCF.InitListView(lisDispatcher);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.ExportToExcel(lisDispatcher, this.Text, "");
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (RTDLIST.ViewDispatcherList(lisDispatcher, '1', null, "") == true)
                {
                    lblDataCount.Text = lisDispatcher.Items.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemNextPartial(lisDispatcher, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisDispatcher, txtFind.Text, 0, true, false);
            
        }
        
        private void lisDispatcher_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this.pnlRight);
                if (lisDispatcher.SelectedItems.Count > 0)
                {
                    if (View_Dispatcher(lisDispatcher.SelectedItems[0].Text) == false)
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
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("U") == false)
            {
                return;
            }
            if (Update_Dispatcher(MPGC.MP_STEP_UPDATE) == true)
            {
               if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                    MPCF.FindListItem(lisDispatcher, txtDspID.Text, false);
                }
                
            }
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
            if (Update_Dispatcher(MPGC.MP_STEP_DELETE) == true)
            {
                MPCF.FieldClear(this.pnlRight);
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
            }
        }    
        
        private void cdvLotType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvLotType.Init();
                MPCF.InitListView(cdvLotType.GetListView);
                cdvLotType.Columns.Add("RuleID", 100, HorizontalAlignment.Left);
                cdvLotType.Columns.Add("Description", 150, HorizontalAlignment.Left);
                cdvLotType.SelectedSubItemIndex = 0;
                if (RTDLIST.ViewRuleList(cdvLotType.GetListView, '1', null, "", 'L') == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvResourceType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvResourceType.Init();
                MPCF.InitListView(cdvResourceType.GetListView);
                cdvResourceType.Columns.Add("RuleID", 100, HorizontalAlignment.Left);
                cdvResourceType.Columns.Add("Description", 150, HorizontalAlignment.Left);
                cdvResourceType.SelectedSubItemIndex = 0;
                if (RTDLIST.ViewRuleList(cdvResourceType.GetListView, '1', null, "", 'R') == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvPortType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvPortType.Init();
                MPCF.InitListView(cdvPortType.GetListView);
                cdvPortType.Columns.Add("RuleID", 100, HorizontalAlignment.Left);
                cdvPortType.Columns.Add("Description", 150, HorizontalAlignment.Left);
                cdvPortType.SelectedSubItemIndex = 0;
                if (RTDLIST.ViewRuleList(cdvPortType.GetListView, '1', null, "", 'P') == false)
                {
                    return;
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
