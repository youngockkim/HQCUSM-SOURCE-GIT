
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
//   File Name   : frmRTDSetupDispatcherSimulation.vb
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
    public class frmRTDSetupDispatcherSimulation : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRTDSetupDispatcherSimulation()
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
        



        private Miracom.UI.Controls.MCListView.MCListView lisDispatcher;
        private System.Windows.Forms.ColumnHeader colDspID;
        private System.Windows.Forms.ColumnHeader colDspDesc;
        private System.Windows.Forms.GroupBox grpDsp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblDsp;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtDspID;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.Panel pnlGroupFill;
        private System.Windows.Forms.TabPage tbpAttachOper;
        private System.Windows.Forms.TabControl tabGeneral;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox grpResorOper;
        private System.Windows.Forms.RadioButton rbnResource;
        private System.Windows.Forms.RadioButton rbnOper;
        private System.Windows.Forms.GroupBox grpCreateInfo;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.GroupBox grpPrivilege;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrvGrp;
        private System.Windows.Forms.Label lblPrvGrp;
        private System.Windows.Forms.TabPage tbpAttachRes;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Button btnDetach;
        private Miracom.UI.Controls.MCListView.MCListView lisAttachRes;
        private System.Windows.Forms.ColumnHeader colAttachRes;
        private Miracom.UI.Controls.MCListView.MCListView lisResource;
        private System.Windows.Forms.ColumnHeader colRes;
        private System.Windows.Forms.ColumnHeader colResDesc;
        private Miracom.UI.Controls.MCListView.MCListView lisOper;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Panel pnlMid;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private Miracom.UI.Controls.MCListView.MCListView lisAttachOper;
        private System.Windows.Forms.ColumnHeader colAttachOper;
        private System.Windows.Forms.ColumnHeader colOperdesc;
        private System.Windows.Forms.Panel pnlResMid;
        private System.Windows.Forms.TextBox txtMaxCount;
        protected Button btnOperExcel;
        protected Button btnResExcel;
        private System.Windows.Forms.Label lblMaxCount;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRTDSetupDispatcherSimulation));
            this.lisDispatcher = new Miracom.UI.Controls.MCListView.MCListView();
            this.colDspID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDspDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.txtMaxCount = new System.Windows.Forms.TextBox();
            this.lblMaxCount = new System.Windows.Forms.Label();
            this.cdvPrvGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPrvGrp = new System.Windows.Forms.Label();
            this.grpCreateInfo = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.grpResorOper = new System.Windows.Forms.GroupBox();
            this.rbnOper = new System.Windows.Forms.RadioButton();
            this.rbnResource = new System.Windows.Forms.RadioButton();
            this.tbpAttachOper = new System.Windows.Forms.TabPage();
            this.lisOper = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlMid = new System.Windows.Forms.Panel();
            this.btnOperExcel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lisAttachOper = new Miracom.UI.Controls.MCListView.MCListView();
            this.colAttachOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperdesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpAttachRes = new System.Windows.Forms.TabPage();
            this.lisResource = new Miracom.UI.Controls.MCListView.MCListView();
            this.colRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlResMid = new System.Windows.Forms.Panel();
            this.btnResExcel = new System.Windows.Forms.Button();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnDetach = new System.Windows.Forms.Button();
            this.lisAttachRes = new Miracom.UI.Controls.MCListView.MCListView();
            this.colAttachRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.grpPrivilege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrvGrp)).BeginInit();
            this.grpCreateInfo.SuspendLayout();
            this.grpResorOper.SuspendLayout();
            this.tbpAttachOper.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.tbpAttachRes.SuspendLayout();
            this.pnlResMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 3;
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
            this.btnCreate.Location = new System.Drawing.Point(558, 7);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(558, 7);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Dispatcher Setup";
            // 
            // lisDispatcher
            // 
            this.lisDispatcher.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDspID,
            this.colDspDesc});
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
            // colDspID
            // 
            this.colDspID.Text = "Dispatcher ID";
            this.colDspID.Width = 120;
            // 
            // colDspDesc
            // 
            this.colDspDesc.Text = "Description";
            this.colDspDesc.Width = 300;
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
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(368, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // txtDspID
            // 
            this.txtDspID.Location = new System.Drawing.Point(120, 16);
            this.txtDspID.MaxLength = 20;
            this.txtDspID.Name = "txtDspID";
            this.txtDspID.ReadOnly = true;
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
            this.tabGeneral.Controls.Add(this.tbpAttachOper);
            this.tabGeneral.Controls.Add(this.tbpAttachRes);
            this.tabGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneral.ItemSize = new System.Drawing.Size(60, 18);
            this.tabGeneral.Location = new System.Drawing.Point(0, 5);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.SelectedIndex = 0;
            this.tabGeneral.Size = new System.Drawing.Size(500, 431);
            this.tabGeneral.TabIndex = 1;
            this.tabGeneral.SelectedIndexChanged += new System.EventHandler(this.tabGeneral_SelectedIndexChanged);
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
            this.pnlGroupFill.Controls.Add(this.grpResorOper);
            this.pnlGroupFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGroupFill.Location = new System.Drawing.Point(0, 0);
            this.pnlGroupFill.Name = "pnlGroupFill";
            this.pnlGroupFill.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlGroupFill.Size = new System.Drawing.Size(492, 405);
            this.pnlGroupFill.TabIndex = 0;
            // 
            // grpPrivilege
            // 
            this.grpPrivilege.Controls.Add(this.txtMaxCount);
            this.grpPrivilege.Controls.Add(this.lblMaxCount);
            this.grpPrivilege.Controls.Add(this.cdvPrvGrp);
            this.grpPrivilege.Controls.Add(this.lblPrvGrp);
            this.grpPrivilege.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPrivilege.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPrivilege.Location = new System.Drawing.Point(3, 64);
            this.grpPrivilege.Name = "grpPrivilege";
            this.grpPrivilege.Size = new System.Drawing.Size(486, 268);
            this.grpPrivilege.TabIndex = 1;
            this.grpPrivilege.TabStop = false;
            // 
            // txtMaxCount
            // 
            this.txtMaxCount.Location = new System.Drawing.Point(120, 41);
            this.txtMaxCount.MaxLength = 4;
            this.txtMaxCount.Name = "txtMaxCount";
            this.txtMaxCount.Size = new System.Drawing.Size(68, 20);
            this.txtMaxCount.TabIndex = 3;
            this.txtMaxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxCount_KeyPress);
            // 
            // lblMaxCount
            // 
            this.lblMaxCount.AutoSize = true;
            this.lblMaxCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxCount.Location = new System.Drawing.Point(15, 44);
            this.lblMaxCount.Name = "lblMaxCount";
            this.lblMaxCount.Size = new System.Drawing.Size(58, 13);
            this.lblMaxCount.TabIndex = 2;
            this.lblMaxCount.Text = "Max Count";
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
            this.cdvPrvGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPrvGrp.Index = 0;
            this.cdvPrvGrp.IsViewBtnImage = false;
            this.cdvPrvGrp.Location = new System.Drawing.Point(120, 16);
            this.cdvPrvGrp.MaxLength = 20;
            this.cdvPrvGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrvGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrvGrp.Name = "cdvPrvGrp";
            this.cdvPrvGrp.ReadOnly = false;
            this.cdvPrvGrp.SearchSubItemIndex = 0;
            this.cdvPrvGrp.SelectedDescIndex = -1;
            this.cdvPrvGrp.SelectedSubItemIndex = -1;
            this.cdvPrvGrp.SelectionStart = 0;
            this.cdvPrvGrp.Size = new System.Drawing.Size(210, 20);
            this.cdvPrvGrp.SmallImageList = null;
            this.cdvPrvGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrvGrp.TabIndex = 1;
            this.cdvPrvGrp.TextBoxToolTipText = "";
            this.cdvPrvGrp.TextBoxWidth = 210;
            this.cdvPrvGrp.VisibleButton = true;
            this.cdvPrvGrp.VisibleColumnHeader = false;
            this.cdvPrvGrp.VisibleDescription = false;
            this.cdvPrvGrp.ButtonPress += new System.EventHandler(this.cdvPrvGrp_ButtonPress);
            // 
            // lblPrvGrp
            // 
            this.lblPrvGrp.AutoSize = true;
            this.lblPrvGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrvGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrvGrp.Location = new System.Drawing.Point(15, 19);
            this.lblPrvGrp.Name = "lblPrvGrp";
            this.lblPrvGrp.Size = new System.Drawing.Size(79, 13);
            this.lblPrvGrp.TabIndex = 0;
            this.lblPrvGrp.Text = "Privilege Group";
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
            // grpResorOper
            // 
            this.grpResorOper.Controls.Add(this.rbnOper);
            this.grpResorOper.Controls.Add(this.rbnResource);
            this.grpResorOper.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResorOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResorOper.Location = new System.Drawing.Point(3, 5);
            this.grpResorOper.Name = "grpResorOper";
            this.grpResorOper.Size = new System.Drawing.Size(486, 59);
            this.grpResorOper.TabIndex = 0;
            this.grpResorOper.TabStop = false;
            this.grpResorOper.Text = "Resource or Operation";
            // 
            // rbnOper
            // 
            this.rbnOper.AutoSize = true;
            this.rbnOper.Location = new System.Drawing.Point(296, 24);
            this.rbnOper.Name = "rbnOper";
            this.rbnOper.Size = new System.Drawing.Size(71, 17);
            this.rbnOper.TabIndex = 1;
            this.rbnOper.Text = "Operation";
            // 
            // rbnResource
            // 
            this.rbnResource.AutoSize = true;
            this.rbnResource.Location = new System.Drawing.Point(76, 24);
            this.rbnResource.Name = "rbnResource";
            this.rbnResource.Size = new System.Drawing.Size(71, 17);
            this.rbnResource.TabIndex = 0;
            this.rbnResource.Text = "Resource";
            // 
            // tbpAttachOper
            // 
            this.tbpAttachOper.Controls.Add(this.lisOper);
            this.tbpAttachOper.Controls.Add(this.pnlMid);
            this.tbpAttachOper.Controls.Add(this.lisAttachOper);
            this.tbpAttachOper.Location = new System.Drawing.Point(4, 22);
            this.tbpAttachOper.Name = "tbpAttachOper";
            this.tbpAttachOper.Padding = new System.Windows.Forms.Padding(5);
            this.tbpAttachOper.Size = new System.Drawing.Size(492, 405);
            this.tbpAttachOper.TabIndex = 2;
            this.tbpAttachOper.Text = "Attach Operation";
            this.tbpAttachOper.Visible = false;
            this.tbpAttachOper.Resize += new System.EventHandler(this.tbpAttachOper_Resize);
            // 
            // lisOper
            // 
            this.lisOper.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisOper.Dock = System.Windows.Forms.DockStyle.Right;
            this.lisOper.EnableSort = true;
            this.lisOper.EnableSortIcon = true;
            this.lisOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisOper.FullRowSelect = true;
            this.lisOper.HideSelection = false;
            this.lisOper.Location = new System.Drawing.Point(280, 5);
            this.lisOper.Name = "lisOper";
            this.lisOper.Size = new System.Drawing.Size(207, 395);
            this.lisOper.TabIndex = 2;
            this.lisOper.UseCompatibleStateImageBehavior = false;
            this.lisOper.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Operation";
            this.ColumnHeader1.Width = 90;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 200;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.btnOperExcel);
            this.pnlMid.Controls.Add(this.btnAdd);
            this.pnlMid.Controls.Add(this.btnDel);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMid.Location = new System.Drawing.Point(212, 5);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Size = new System.Drawing.Size(70, 395);
            this.pnlMid.TabIndex = 1;
            // 
            // btnOperExcel
            // 
            this.btnOperExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOperExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOperExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnOperExcel.Image")));
            this.btnOperExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOperExcel.Location = new System.Drawing.Point(3, 368);
            this.btnOperExcel.Name = "btnOperExcel";
            this.btnOperExcel.Size = new System.Drawing.Size(24, 24);
            this.btnOperExcel.TabIndex = 6;
            this.btnOperExcel.Click += new System.EventHandler(this.btnOperExcel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(23, 171);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(23, 200);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = ">";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lisAttachOper
            // 
            this.lisAttachOper.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAttachOper,
            this.colOperdesc});
            this.lisAttachOper.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisAttachOper.EnableSort = true;
            this.lisAttachOper.EnableSortIcon = true;
            this.lisAttachOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachOper.FullRowSelect = true;
            this.lisAttachOper.HideSelection = false;
            this.lisAttachOper.Location = new System.Drawing.Point(5, 5);
            this.lisAttachOper.Name = "lisAttachOper";
            this.lisAttachOper.Size = new System.Drawing.Size(207, 395);
            this.lisAttachOper.TabIndex = 0;
            this.lisAttachOper.UseCompatibleStateImageBehavior = false;
            this.lisAttachOper.View = System.Windows.Forms.View.Details;
            // 
            // colAttachOper
            // 
            this.colAttachOper.Text = "Attached Operation";
            this.colAttachOper.Width = 110;
            // 
            // colOperdesc
            // 
            this.colOperdesc.Text = "Description";
            this.colOperdesc.Width = 200;
            // 
            // tbpAttachRes
            // 
            this.tbpAttachRes.Controls.Add(this.lisResource);
            this.tbpAttachRes.Controls.Add(this.pnlResMid);
            this.tbpAttachRes.Controls.Add(this.lisAttachRes);
            this.tbpAttachRes.Location = new System.Drawing.Point(4, 22);
            this.tbpAttachRes.Name = "tbpAttachRes";
            this.tbpAttachRes.Padding = new System.Windows.Forms.Padding(5);
            this.tbpAttachRes.Size = new System.Drawing.Size(492, 405);
            this.tbpAttachRes.TabIndex = 4;
            this.tbpAttachRes.Text = "Attach Resource";
            this.tbpAttachRes.Resize += new System.EventHandler(this.tbpAttachRes_Resize);
            // 
            // lisResource
            // 
            this.lisResource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRes,
            this.colResDesc});
            this.lisResource.Dock = System.Windows.Forms.DockStyle.Right;
            this.lisResource.EnableSort = true;
            this.lisResource.EnableSortIcon = true;
            this.lisResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResource.FullRowSelect = true;
            this.lisResource.HideSelection = false;
            this.lisResource.Location = new System.Drawing.Point(280, 5);
            this.lisResource.Name = "lisResource";
            this.lisResource.Size = new System.Drawing.Size(207, 395);
            this.lisResource.TabIndex = 2;
            this.lisResource.UseCompatibleStateImageBehavior = false;
            this.lisResource.View = System.Windows.Forms.View.Details;
            // 
            // colRes
            // 
            this.colRes.Text = "Resource";
            this.colRes.Width = 90;
            // 
            // colResDesc
            // 
            this.colResDesc.Text = "Description";
            this.colResDesc.Width = 200;
            // 
            // pnlResMid
            // 
            this.pnlResMid.Controls.Add(this.btnResExcel);
            this.pnlResMid.Controls.Add(this.btnAttach);
            this.pnlResMid.Controls.Add(this.btnDetach);
            this.pnlResMid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlResMid.Location = new System.Drawing.Point(212, 5);
            this.pnlResMid.Name = "pnlResMid";
            this.pnlResMid.Size = new System.Drawing.Size(69, 395);
            this.pnlResMid.TabIndex = 1;
            // 
            // btnResExcel
            // 
            this.btnResExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnResExcel.Image")));
            this.btnResExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResExcel.Location = new System.Drawing.Point(3, 368);
            this.btnResExcel.Name = "btnResExcel";
            this.btnResExcel.Size = new System.Drawing.Size(24, 24);
            this.btnResExcel.TabIndex = 7;
            this.btnResExcel.Click += new System.EventHandler(this.btnResExcel_Click);
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(22, 171);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 0;
            this.btnAttach.Text = "<";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetach.Location = new System.Drawing.Point(22, 200);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 1;
            this.btnDetach.Text = ">";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // lisAttachRes
            // 
            this.lisAttachRes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAttachRes,
            this.colDesc});
            this.lisAttachRes.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisAttachRes.EnableSort = true;
            this.lisAttachRes.EnableSortIcon = true;
            this.lisAttachRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachRes.FullRowSelect = true;
            this.lisAttachRes.HideSelection = false;
            this.lisAttachRes.Location = new System.Drawing.Point(5, 5);
            this.lisAttachRes.Name = "lisAttachRes";
            this.lisAttachRes.Size = new System.Drawing.Size(207, 395);
            this.lisAttachRes.TabIndex = 0;
            this.lisAttachRes.UseCompatibleStateImageBehavior = false;
            this.lisAttachRes.View = System.Windows.Forms.View.Details;
            // 
            // colAttachRes
            // 
            this.colAttachRes.Text = "Attached Resource";
            this.colAttachRes.Width = 110;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 200;
            // 
            // frmRTDSetupDispatcherSimulation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRTDSetupDispatcherSimulation";
            this.Text = "Dispatcher Simulation Setup";
            this.Activated += new System.EventHandler(this.frmRTDSetupDispatcherSimulation_Activated);
            this.Load += new System.EventHandler(this.frmRTDSetupDispatcherSimulation_Load);
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
            this.grpPrivilege.ResumeLayout(false);
            this.grpPrivilege.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrvGrp)).EndInit();
            this.grpCreateInfo.ResumeLayout(false);
            this.grpCreateInfo.PerformLayout();
            this.grpResorOper.ResumeLayout(false);
            this.grpResorOper.PerformLayout();
            this.tbpAttachOper.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.tbpAttachRes.ResumeLayout(false);
            this.pnlResMid.ResumeLayout(false);
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
            
            switch (c_step)
            {
                case "U":
                    
                    if (MPCF.CheckNumeric(txtMaxCount.Text) == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        txtMaxCount.Focus();
                        return false;
                    }
                    if (MPCF.ToDbl(txtMaxCount.Text) > 9999)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(189));
                        txtMaxCount.Focus();
                        return false;
                    }
                    break;
                case "ATTACH_RES":
                    
                    if (lisDispatcher.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisDispatcher.Items.Count > 0)
                        {
                            lisDispatcher.Items[0].Selected = true;
                            lisDispatcher.Focus();
                        }
                        return false;
                    }
                    if (lisResource.SelectedItems.Count <= 0)
                    {
                        if (lisResource.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisResource.Items[0].Selected = true;
                            lisResource.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_RES":
                    
                    if (lisDispatcher.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisDispatcher.Items.Count > 0)
                        {
                            lisDispatcher.Items[0].Selected = true;
                            lisDispatcher.Focus();
                        }
                        return false;
                    }
                    if (lisAttachRes.SelectedItems.Count <= 0)
                    {
                        if (lisAttachRes.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisAttachRes.Items[0].Selected = true;
                            lisAttachRes.Focus();
                        }
                        return false;
                    }
                    break;
                case "ATTACH_OPER":
                    
                    if (lisDispatcher.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisDispatcher.Items.Count > 0)
                        {
                            lisDispatcher.Items[0].Selected = true;
                            lisDispatcher.Focus();
                        }
                        return false;
                    }
                    if (lisOper.SelectedItems.Count <= 0)
                    {
                        if (lisOper.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisOper.Items[0].Selected = true;
                            lisOper.Focus();
                        }
                        return false;
                    }
                    break;
                case "DETACH_OPER":
                    
                    if (lisDispatcher.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisDispatcher.Items.Count > 0)
                        {
                            lisDispatcher.Items[0].Selected = true;
                            lisDispatcher.Focus();
                        }
                        return false;
                    }
                    if (lisAttachOper.SelectedItems.Count <= 0)
                    {
                        if (lisAttachOper.Items.Count > 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            lisAttachOper.Items[0].Selected = true;
                            lisAttachOper.Focus();
                        }
                        return false;
                    }
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

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddChar("SIMULATION_FLAG", 'Y');

                in_node.AddString("DSP_ID", MPCF.Trim(txtDspID.Text));
                in_node.AddString("DSP_DESC", MPCF.Trim(txtDesc.Text));

                in_node.AddChar("RES_OR_OPER", rbnResource.Checked == true ? 'R' : 'O');

                in_node.AddString("PRV_GRP_ID", MPCF.Trim(cdvPrvGrp.Text));
                in_node.AddInt("MAX_COUNT", MPCF.ToInt(txtMaxCount.Text));

                if (MPCR.CallService("RTD", "RTD_Update_Dispatcher", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisDispatcher, MPCF.Trim(txtDspID.Text), false) == true)
                        {
                            lisDispatcher.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
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
        private bool View_Dispatcher()
        {
            TRSNode in_node = new TRSNode("VIEW_DISPATCHER_IN");
            TRSNode out_node = new TRSNode("VIEW_DISPATCHER_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("DSP_ID", lisDispatcher.SelectedItems[0].Text);

                if (MPCR.CallService("RTD", "RTD_View_Dispatcher", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDesc.Text = MPCF.Trim(out_node.GetString("DSP_DESC"));

                if (MPCF.Trim(out_node.GetChar("RES_OR_OPER")) == "R")
                {
                    rbnResource.Checked = true;
                }
                else
                {
                    rbnOper.Checked = true;
                }

                cdvPrvGrp.Text = MPCF.Trim(out_node.GetString("PRV_GRP_ID"));
                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                txtMaxCount.Text = MPCF.Trim(out_node.GetInt("MAX_COUNT"));

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // Update_Dispatcher_Resource()
        //       - Create/Update/Delete Dispatcher Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_Dispatcher_Resource(char c_step, string sDspID, string sResID)
        {
            TRSNode in_node = new TRSNode("UPDATE_DSPRES_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("DSP_ID", MPCF.Trim(sDspID));
                in_node.AddString("RES_ID", MPCF.Trim(sResID));


                if (MPCR.CallService("RTD", "RTD_Update_Dispatcher_Res", in_node, ref out_node) == false)
                {
                    return false;
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
        // Update_Dispatcher_Operation()
        //       - Create/Update/Delete Dispatcher Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_Dispatcher_Operation(char c_step, string sDspID, string sOper)
        {
            TRSNode in_node = new TRSNode("UPDATE_DSPOPER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("DSP_ID", MPCF.Trim(sDspID));
                in_node.AddString("OPER", MPCF.Trim(sOper));


                if (MPCR.CallService("RTD", "RTD_Update_Dispatcher_Oper", in_node, ref out_node) == false)
                {
                    return false;
                }

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
        
        private void frmRTDSetupDispatcherSimulation_Activated(object sender, System.EventArgs e)
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
                    #if _RAS
                    if (RASLIST.ViewResourceList(lisResource, false) == false)
                    {
                        return;
                    }
                    #endif
                    if (WIPLIST.ViewOperationList(lisOper, '1') == false)
                    {
                        return;
                    }
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void frmRTDSetupDispatcherSimulation_Load(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this);
                MPCF.InitListView(lisDispatcher);
                MPCF.InitListView(lisAttachRes);
                MPCF.InitListView(lisResource);
                MPCF.InitListView(lisAttachOper);
                MPCF.InitListView(lisOper);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvPrvGrp_ButtonPress(object sender, System.EventArgs e)
        {
            cdvPrvGrp.Init();
            MPCF.InitListView(cdvPrvGrp.GetListView);
            cdvPrvGrp.Columns.Add(MPCF.FindLanguage("Privilege Group", 0), 50, HorizontalAlignment.Left);
            cdvPrvGrp.Columns.Add(MPCF.FindLanguage("Desc", 0), 100, HorizontalAlignment.Left);
            cdvPrvGrp.SelectedSubItemIndex = 0;
            if (SECLIST.ViewPrvGroupList(cdvPrvGrp.GetListView, '1', null, "") == false)
            {
                return;
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
                    txtDspID.Text = lisDispatcher.SelectedItems[0].Text;
                    if (View_Dispatcher()== false)
                    {
                        return;
                    }
                    RTDLIST.ViewDspResList(lisAttachRes, '1', lisDispatcher.SelectedItems[0].Text, null, "");
                    RTDLIST.ViewDspOperList(lisAttachOper, '1', lisDispatcher.SelectedItems[0].Text, null, "");
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
        
        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                string sDsp;
                string sRes;
                ListViewItem itmX;
                string[] sSelect = null;
                int i;
                int j;
                int iIdx = 0;
                
                sSelect = new string[lisResource.SelectedItems.Count];
                SelectClear(lisAttachRes);
                if (CheckCondition("ATTACH_RES") == false)
                {
                    return;
                }
                for (i = 0; i <= lisResource.SelectedItems.Count - 1; i++)
                {
                    sRes = lisResource.SelectedItems[i].Text;
                    sDsp = lisDispatcher.SelectedItems[0].Text;
                    if (MPCF.FindListItem(lisAttachRes, sRes, false) == false)
                    {
                        if (Update_Dispatcher_Resource(MPGC.MP_STEP_CREATE, sDsp, sRes) == true)
                        {
                            sSelect[i] = sRes;
                            itmX = lisAttachRes.Items.Add(sRes, (int)SMALLICON_INDEX.IDX_RESOURCE);
                            itmX.SubItems.Add(lisResource.SelectedItems[i].SubItems[1].Text);
                            iIdx = lisResource.SelectedItems[i].Index;
                        }
                        else
                        {
                            for (j = 0; j <= sSelect.Length - 1; j++)
                            {
                                MPCF.FindListItem(lisAttachRes, sSelect[j], false);
                            }
                            SelectClear(lisResource);
                            return;
                        }
                    }
                    else
                    {
                        sSelect[i] = sRes;
                        iIdx = lisResource.SelectedItems[i].Index;
                    }
                }
                if (RTDLIST.ViewDspResList(lisAttachRes, '1', lisDispatcher.SelectedItems[0].Text, null, "") == false)
                {
                    return;
                }
                SelectClear(lisResource);
                if (sSelect.Length == 1)
                {
                    if (iIdx < lisResource.Items.Count - 1)
                    {
                        lisResource.Items[iIdx + 1].Selected = true;
                    }
                }
                for (i = 0; i <= sSelect.Length - 1; i++)
                {
                    MPCF.FindListItem(lisAttachRes, sSelect[i], false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnDetach_Click(object sender, System.EventArgs e)
        {
            try
            {
                string sRes;
                string sDsp;
                int iIdx = 0;
                int i;
                int iCount;
                
                if (CheckCondition("DETACH_RES") == false)
                {
                    return;
                }
                iCount = lisAttachRes.SelectedItems.Count;
                SelectClear(lisResource);
                for (i = lisAttachRes.SelectedItems.Count - 1; i >= 0; i--)
                {
                    sRes = lisAttachRes.SelectedItems[i].Text;
                    sDsp = lisDispatcher.SelectedItems[0].Text;
                    
                    if (Update_Dispatcher_Resource(MPGC.MP_STEP_DELETE, sDsp, sRes) == true)
                    {
                        iIdx = lisAttachRes.SelectedItems[i].Index;
                        lisAttachRes.Items.RemoveAt(iIdx);
                        MPCF.FindListItem(lisResource, sRes, false);
                    }
                }
                if (iCount == 1)
                {
                    if (iIdx < lisAttachRes.Items.Count)
                    {
                        lisAttachRes.Items[iIdx].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                string sDsp;
                string sOper;
                ListViewItem itmX;
                string[] sSelect = null;
                int i;
                int j;
                int iIdx = 0;
                
                sSelect = new string[lisOper.SelectedItems.Count];
                SelectClear(lisAttachOper);
                if (CheckCondition("ATTACH_OPER") == false)
                {
                    return;
                }
                for (i = 0; i <= lisOper.SelectedItems.Count - 1; i++)
                {
                    sOper = lisOper.SelectedItems[i].Text;
                    sDsp = lisDispatcher.SelectedItems[0].Text;
                    if (MPCF.FindListItem(lisAttachOper, sOper, false) == false)
                    {
                        if (Update_Dispatcher_Operation(MPGC.MP_STEP_CREATE, sDsp, sOper) == true)
                        {
                            sSelect[i] = sOper;
                            itmX = lisAttachOper.Items.Add(sOper, (int)SMALLICON_INDEX.IDX_OPER);
                            itmX.SubItems.Add(lisOper.SelectedItems[i].SubItems[1].Text);
                            iIdx = lisOper.SelectedItems[i].Index;
                        }
                        else
                        {
                            for (j = 0; j <= sSelect.Length - 1; j++)
                            {
                                MPCF.FindListItem(lisAttachOper, sSelect[j], false);
                            }
                            SelectClear(lisOper);
                            return;
                        }
                    }
                    else
                    {
                        sSelect[i] = sOper;
                        iIdx = lisOper.SelectedItems[i].Index;
                    }
                }
                if (RTDLIST.ViewDspOperList(lisAttachOper, '1', lisDispatcher.SelectedItems[0].Text, null, "") == false)
                {
                    return;
                }
                SelectClear(lisOper);
                if (sSelect.Length == 1)
                {
                    if (iIdx < lisOper.Items.Count - 1)
                    {
                        lisOper.Items[iIdx + 1].Selected = true;
                    }
                }
                for (i = 0; i <= sSelect.Length - 1; i++)
                {
                    MPCF.FindListItem(lisAttachOper, sSelect[i], false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnDel_Click(object sender, System.EventArgs e)
        {
            try
            {
                string sOper;
                string sDsp;
                int iIdx = 0;
                int i;
                int iCount;
                
                if (CheckCondition("DETACH_OPER") == false)
                {
                    return;
                }
                iCount = lisAttachOper.SelectedItems.Count;
                SelectClear(lisOper);
                for (i = lisAttachOper.SelectedItems.Count - 1; i >= 0; i--)
                {
                    sOper = lisAttachOper.SelectedItems[i].Text;
                    sDsp = lisDispatcher.SelectedItems[0].Text;
                    
                    if (Update_Dispatcher_Operation(MPGC.MP_STEP_DELETE, sDsp, sOper) == true)
                    {
                        iIdx = lisAttachOper.SelectedItems[i].Index;
                        lisAttachOper.Items.RemoveAt(iIdx);
                        MPCF.FindListItem(lisOper, sOper, false);
                    }
                }
                if (iCount == 1)
                {
                    if (iIdx < lisAttachOper.Items.Count)
                    {
                        lisAttachOper.Items[iIdx].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void tbpAttachRes_Resize(object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(tbpAttachRes, lisAttachRes, lisResource, pnlResMid, 40);
        }
        
        private void tbpAttachOper_Resize(object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(tbpAttachOper, lisAttachOper, lisOper, pnlMid, 40);
        }
        
        private void tabGeneral_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                btnCreate.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void txtMaxCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        e.Handled = true;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnOperExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                sCond = "Dispatcher ID : " + lisDispatcher.SelectedItems[0].Text;

                MPCF.ExportToExcel(lisAttachOper, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnResExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                sCond = "Dispatcher ID : " + lisDispatcher.SelectedItems[0].Text;

                MPCF.ExportToExcel(lisAttachRes, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
    }
    //#End If
}
