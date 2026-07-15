
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
//   File Name   : frmORDSetupPlannedLot.vb
//   Description : Planned Lot Setup
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition()     : Check the conditions before transaction
//       - View_PlannedLot()    : View Planned Lot
//       - Update_PlannedLot()  : Create/Update/Delete Planned Lot
//       - GetMaterialList()    : Get Material List
//       - GetFlowList()        : Get Flow List
//       - GetOperationList()   : Get Operation List
//       - GetCreateCodeList()  : Get Create Code List
//       - GetOwnerCodeList()   : Get Owner Code List
//       - GetLotTypeList()     : Get Lot Type List
//       - View_Material()      : View Material Information
//       - View_Flow()          : View Flow Definition
//       - Refresh_Lotlist()    : Refresh Lot List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-15 : Created by H.K.KIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _ORD = True Then

namespace Miracom.ORDCore
{
    public class frmORDSetupPlannedLot : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmORDSetupPlannedLot()
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
        



        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.GroupBox grpLot;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.TabControl tabGeneral;
        private Miracom.UI.Controls.MCListView.MCListView lisLot;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        protected System.Windows.Forms.TextBox txtLotDesc;
        protected System.Windows.Forms.Label lblLotDesc;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlCreateInfo;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.CheckBox chkDueDate;
        private System.Windows.Forms.Label lblQty3;
        private System.Windows.Forms.Label lblQty2;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLotType;
        private System.Windows.Forms.Label lblQty1;
        private System.Windows.Forms.Label lblLotType;
        private System.Windows.Forms.Label lblCreateCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOwnerCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCode;
        private System.Windows.Forms.Label lblOwnerCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.Label lblWorkDate;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.Panel pnlCreateStatus;
        private System.Windows.Forms.GroupBox grpCreateStatus;
        private System.Windows.Forms.TextBox txtLotCreateTime;
        private System.Windows.Forms.Label lblLotCreateTime;
        private System.Windows.Forms.CheckBox chkLotCreateFlag;
        private System.Windows.Forms.GroupBox grpUpdateInfo;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.TextBox txtCreateUser;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOrderID;
        private System.Windows.Forms.Label lblOrderID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.CheckBox chkIncludeCreateFlag;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private System.Windows.Forms.TabPage tbpCreate;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisLot = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlDate = new System.Windows.Forms.Panel();
            this.chkIncludeCreateFlag = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.grpLot = new System.Windows.Forms.GroupBox();
            this.txtLotDesc = new System.Windows.Forms.TextBox();
            this.lblLotDesc = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.tabGeneral = new System.Windows.Forms.TabControl();
            this.tbpCreate = new System.Windows.Forms.TabPage();
            this.grpUpdateInfo = new System.Windows.Forms.GroupBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.pnlCreateStatus = new System.Windows.Forms.Panel();
            this.grpCreateStatus = new System.Windows.Forms.GroupBox();
            this.txtLotCreateTime = new System.Windows.Forms.TextBox();
            this.lblLotCreateTime = new System.Windows.Forms.Label();
            this.chkLotCreateFlag = new System.Windows.Forms.CheckBox();
            this.pnlCreateInfo = new System.Windows.Forms.Panel();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvOrderID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.chkDueDate = new System.Windows.Forms.CheckBox();
            this.lblQty3 = new System.Windows.Forms.Label();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblPriority = new System.Windows.Forms.Label();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.cdvLotType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.lblLotType = new System.Windows.Forms.Label();
            this.lblCreateCode = new System.Windows.Forms.Label();
            this.cdvOwnerCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOwnerCode = new System.Windows.Forms.Label();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.grpLot.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tbpCreate.SuspendLayout();
            this.grpUpdateInfo.SuspendLayout();
            this.pnlCreateStatus.SuspendLayout();
            this.grpCreateStatus.SuspendLayout();
            this.pnlCreateInfo.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
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
            this.txtFind.TextChanged += new System.EventHandler(this.txtLotID_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlGeneral);
            this.pnlRight.Controls.Add(this.grpLot);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisLot);
            this.pnlLeft.Controls.Add(this.pnlDate);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
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
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Planned Lot Setup";
            // 
            // lisLot
            // 
            this.lisLot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLot.EnableSort = true;
            this.lisLot.EnableSortIcon = true;
            this.lisLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLot.FullRowSelect = true;
            this.lisLot.Location = new System.Drawing.Point(3, 56);
            this.lisLot.MultiSelect = false;
            this.lisLot.Name = "lisLot";
            this.lisLot.Size = new System.Drawing.Size(229, 454);
            this.lisLot.TabIndex = 1;
            this.lisLot.UseCompatibleStateImageBehavior = false;
            this.lisLot.View = System.Windows.Forms.View.Details;
            this.lisLot.SelectedIndexChanged += new System.EventHandler(this.lisLot_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Lot ID";
            this.ColumnHeader1.Width = 140;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Qty";
            this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.chkIncludeCreateFlag);
            this.pnlDate.Controls.Add(this.lblDate);
            this.pnlDate.Controls.Add(this.dtpDate);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDate.Location = new System.Drawing.Point(3, 0);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(229, 56);
            this.pnlDate.TabIndex = 0;
            // 
            // chkIncludeCreateFlag
            // 
            this.chkIncludeCreateFlag.AutoSize = true;
            this.chkIncludeCreateFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeCreateFlag.Location = new System.Drawing.Point(16, 34);
            this.chkIncludeCreateFlag.Name = "chkIncludeCreateFlag";
            this.chkIncludeCreateFlag.Size = new System.Drawing.Size(125, 18);
            this.chkIncludeCreateFlag.TabIndex = 2;
            this.chkIncludeCreateFlag.Text = "Include Created Lot";
            this.chkIncludeCreateFlag.CheckedChanged += new System.EventHandler(this.chkIncludeDeleteFlag_CheckedChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(16, 12);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(59, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Work Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(112, 8);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(90, 20);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.CloseUp += new System.EventHandler(this.dtpDate_CloseUp);
            // 
            // grpLot
            // 
            this.grpLot.Controls.Add(this.txtLotDesc);
            this.grpLot.Controls.Add(this.lblLotDesc);
            this.grpLot.Controls.Add(this.lblLotID);
            this.grpLot.Controls.Add(this.txtLotID);
            this.grpLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLot.Location = new System.Drawing.Point(3, 0);
            this.grpLot.Name = "grpLot";
            this.grpLot.Size = new System.Drawing.Size(500, 71);
            this.grpLot.TabIndex = 0;
            this.grpLot.TabStop = false;
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotDesc.Location = new System.Drawing.Point(120, 40);
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.Name = "txtLotDesc";
            this.txtLotDesc.Size = new System.Drawing.Size(376, 20);
            this.txtLotDesc.TabIndex = 3;
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotDesc.Location = new System.Drawing.Point(15, 43);
            this.lblLotDesc.Name = "lblLotDesc";
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            this.lblLotDesc.TabIndex = 2;
            this.lblLotDesc.Text = "Description";
            this.lblLotDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            this.txtLotID.TextChanged += new System.EventHandler(this.txtLotID_TextChanged);
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.tabGeneral);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(3, 71);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlGeneral.Size = new System.Drawing.Size(500, 439);
            this.pnlGeneral.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tbpCreate);
            this.tabGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneral.ItemSize = new System.Drawing.Size(60, 18);
            this.tabGeneral.Location = new System.Drawing.Point(0, 5);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.SelectedIndex = 0;
            this.tabGeneral.Size = new System.Drawing.Size(500, 434);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.TabStop = false;
            // 
            // tbpCreate
            // 
            this.tbpCreate.Controls.Add(this.grpUpdateInfo);
            this.tbpCreate.Controls.Add(this.pnlCreateStatus);
            this.tbpCreate.Controls.Add(this.pnlCreateInfo);
            this.tbpCreate.Location = new System.Drawing.Point(4, 22);
            this.tbpCreate.Name = "tbpCreate";
            this.tbpCreate.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpCreate.Size = new System.Drawing.Size(492, 408);
            this.tbpCreate.TabIndex = 0;
            this.tbpCreate.Text = "Create Info";
            // 
            // grpUpdateInfo
            // 
            this.grpUpdateInfo.Controls.Add(this.lblUpdateTime);
            this.grpUpdateInfo.Controls.Add(this.lblUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.lblCreateTime);
            this.grpUpdateInfo.Controls.Add(this.lblCreateUser);
            this.grpUpdateInfo.Controls.Add(this.txtUpdateTime);
            this.grpUpdateInfo.Controls.Add(this.txtCreateTime);
            this.grpUpdateInfo.Controls.Add(this.txtUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.txtCreateUser);
            this.grpUpdateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUpdateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUpdateInfo.Location = new System.Drawing.Point(3, 252);
            this.grpUpdateInfo.Name = "grpUpdateInfo";
            this.grpUpdateInfo.Size = new System.Drawing.Size(486, 153);
            this.grpUpdateInfo.TabIndex = 2;
            this.grpUpdateInfo.TabStop = false;
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(253, 43);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 6;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(253, 19);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 2;
            this.lblUpdateUser.Text = "Update User";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(12, 43);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 4;
            this.lblCreateTime.Text = "Create Time";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(12, 19);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 0;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(348, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(133, 20);
            this.txtUpdateTime.TabIndex = 7;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(104, 40);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(133, 20);
            this.txtCreateTime.TabIndex = 5;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(348, 16);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(133, 20);
            this.txtUpdateUser.TabIndex = 3;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(104, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(133, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // pnlCreateStatus
            // 
            this.pnlCreateStatus.Controls.Add(this.grpCreateStatus);
            this.pnlCreateStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCreateStatus.Location = new System.Drawing.Point(3, 200);
            this.pnlCreateStatus.Name = "pnlCreateStatus";
            this.pnlCreateStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlCreateStatus.Size = new System.Drawing.Size(486, 52);
            this.pnlCreateStatus.TabIndex = 1;
            // 
            // grpCreateStatus
            // 
            this.grpCreateStatus.Controls.Add(this.txtLotCreateTime);
            this.grpCreateStatus.Controls.Add(this.lblLotCreateTime);
            this.grpCreateStatus.Controls.Add(this.chkLotCreateFlag);
            this.grpCreateStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCreateStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreateStatus.Location = new System.Drawing.Point(0, 5);
            this.grpCreateStatus.Name = "grpCreateStatus";
            this.grpCreateStatus.Size = new System.Drawing.Size(486, 47);
            this.grpCreateStatus.TabIndex = 1;
            this.grpCreateStatus.TabStop = false;
            this.grpCreateStatus.Text = "Create Status";
            // 
            // txtLotCreateTime
            // 
            this.txtLotCreateTime.Location = new System.Drawing.Point(348, 16);
            this.txtLotCreateTime.MaxLength = 30;
            this.txtLotCreateTime.Name = "txtLotCreateTime";
            this.txtLotCreateTime.ReadOnly = true;
            this.txtLotCreateTime.Size = new System.Drawing.Size(133, 20);
            this.txtLotCreateTime.TabIndex = 2;
            this.txtLotCreateTime.TabStop = false;
            // 
            // lblLotCreateTime
            // 
            this.lblLotCreateTime.AutoSize = true;
            this.lblLotCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotCreateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotCreateTime.Location = new System.Drawing.Point(252, 19);
            this.lblLotCreateTime.Name = "lblLotCreateTime";
            this.lblLotCreateTime.Size = new System.Drawing.Size(82, 13);
            this.lblLotCreateTime.TabIndex = 1;
            this.lblLotCreateTime.Text = "Lot Create Time";
            this.lblLotCreateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkLotCreateFlag
            // 
            this.chkLotCreateFlag.AutoSize = true;
            this.chkLotCreateFlag.Enabled = false;
            this.chkLotCreateFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkLotCreateFlag.Location = new System.Drawing.Point(15, 19);
            this.chkLotCreateFlag.Name = "chkLotCreateFlag";
            this.chkLotCreateFlag.Size = new System.Drawing.Size(104, 18);
            this.chkLotCreateFlag.TabIndex = 0;
            this.chkLotCreateFlag.Text = "Lot Create Flag";
            // 
            // pnlCreateInfo
            // 
            this.pnlCreateInfo.Controls.Add(this.grpGeneral);
            this.pnlCreateInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCreateInfo.Location = new System.Drawing.Point(3, 5);
            this.pnlCreateInfo.Name = "pnlCreateInfo";
            this.pnlCreateInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlCreateInfo.Size = new System.Drawing.Size(486, 195);
            this.pnlCreateInfo.TabIndex = 0;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.cdvFlow);
            this.grpGeneral.Controls.Add(this.cdvMaterial);
            this.grpGeneral.Controls.Add(this.cdvOrderID);
            this.grpGeneral.Controls.Add(this.lblOrderID);
            this.grpGeneral.Controls.Add(this.cdvResID);
            this.grpGeneral.Controls.Add(this.lblResID);
            this.grpGeneral.Controls.Add(this.txtDueDate);
            this.grpGeneral.Controls.Add(this.chkDueDate);
            this.grpGeneral.Controls.Add(this.lblQty3);
            this.grpGeneral.Controls.Add(this.lblQty2);
            this.grpGeneral.Controls.Add(this.cboPriority);
            this.grpGeneral.Controls.Add(this.dtpDueDate);
            this.grpGeneral.Controls.Add(this.lblPriority);
            this.grpGeneral.Controls.Add(this.txtQty3);
            this.grpGeneral.Controls.Add(this.txtQty2);
            this.grpGeneral.Controls.Add(this.txtQty1);
            this.grpGeneral.Controls.Add(this.cdvLotType);
            this.grpGeneral.Controls.Add(this.lblQty1);
            this.grpGeneral.Controls.Add(this.lblLotType);
            this.grpGeneral.Controls.Add(this.lblCreateCode);
            this.grpGeneral.Controls.Add(this.cdvOwnerCode);
            this.grpGeneral.Controls.Add(this.cdvCreateCode);
            this.grpGeneral.Controls.Add(this.lblOwnerCode);
            this.grpGeneral.Controls.Add(this.cdvOperation);
            this.grpGeneral.Controls.Add(this.lblOperation);
            this.grpGeneral.Controls.Add(this.lblWorkDate);
            this.grpGeneral.Controls.Add(this.dtpWorkDate);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(0, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(486, 190);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "Create Lot Information";
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 92;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(12, 63);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(225, 20);
            this.cdvFlow.TabIndex = 3;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 133;
            this.cdvFlow.WidthSequence = 45;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            this.cdvFlow.FlowTextChanged += new System.EventHandler(this.cdvFlow_TextBoxTextChanged);
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(12, 40);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(225, 20);
            this.cdvMaterial.TabIndex = 2;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 92;
            this.cdvMaterial.WidthMaterialAndVersion = 133;
            this.cdvMaterial.WidthVersion = 45;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            this.cdvMaterial.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            // 
            // cdvOrderID
            // 
            this.cdvOrderID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOrderID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOrderID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOrderID.BtnToolTipText = "";
            this.cdvOrderID.DescText = "";
            this.cdvOrderID.DisplaySubItemIndex = -1;
            this.cdvOrderID.DisplayText = "";
            this.cdvOrderID.Focusing = null;
            this.cdvOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOrderID.Index = 0;
            this.cdvOrderID.IsViewBtnImage = false;
            this.cdvOrderID.Location = new System.Drawing.Point(347, 136);
            this.cdvOrderID.MaxLength = 25;
            this.cdvOrderID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOrderID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOrderID.Name = "cdvOrderID";
            this.cdvOrderID.ReadOnly = false;
            this.cdvOrderID.SearchSubItemIndex = 0;
            this.cdvOrderID.SelectedDescIndex = -1;
            this.cdvOrderID.SelectedSubItemIndex = -1;
            this.cdvOrderID.SelectionStart = 0;
            this.cdvOrderID.Size = new System.Drawing.Size(133, 20);
            this.cdvOrderID.SmallImageList = null;
            this.cdvOrderID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOrderID.TabIndex = 23;
            this.cdvOrderID.TextBoxToolTipText = "";
            this.cdvOrderID.TextBoxWidth = 133;
            this.cdvOrderID.VisibleButton = true;
            this.cdvOrderID.VisibleColumnHeader = false;
            this.cdvOrderID.VisibleDescription = false;
            this.cdvOrderID.ButtonPress += new System.EventHandler(this.cdvOrderID_ButtonPress);
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.Location = new System.Drawing.Point(252, 139);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(47, 13);
            this.lblOrderID.TabIndex = 22;
            this.lblOrderID.Text = "Order ID";
            this.lblOrderID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(347, 160);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(133, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 25;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 133;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(252, 163);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(53, 13);
            this.lblResID.TabIndex = 24;
            this.lblResID.Text = "Resource";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(347, 112);
            this.txtDueDate.MaxLength = 30;
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(133, 20);
            this.txtDueDate.TabIndex = 21;
            this.txtDueDate.TabStop = false;
            // 
            // chkDueDate
            // 
            this.chkDueDate.AutoSize = true;
            this.chkDueDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDueDate.Location = new System.Drawing.Point(252, 114);
            this.chkDueDate.Name = "chkDueDate";
            this.chkDueDate.Size = new System.Drawing.Size(86, 18);
            this.chkDueDate.TabIndex = 20;
            this.chkDueDate.Text = "Due Date";
            this.chkDueDate.CheckedChanged += new System.EventHandler(this.chkDueDate_CheckedChanged);
            // 
            // lblQty3
            // 
            this.lblQty3.AutoSize = true;
            this.lblQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty3.Location = new System.Drawing.Point(12, 163);
            this.lblQty3.Name = "lblQty3";
            this.lblQty3.Size = new System.Drawing.Size(32, 13);
            this.lblQty3.TabIndex = 10;
            this.lblQty3.Text = "Qty 3";
            this.lblQty3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty2
            // 
            this.lblQty2.AutoSize = true;
            this.lblQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty2.Location = new System.Drawing.Point(12, 139);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(32, 13);
            this.lblQty2.TabIndex = 8;
            this.lblQty2.Text = "Qty 2";
            this.lblQty2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPriority
            // 
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriority.ItemHeight = 13;
            this.cboPriority.Items.AddRange(new object[] {
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1"});
            this.cboPriority.Location = new System.Drawing.Point(347, 88);
            this.cboPriority.MaxDropDownItems = 9;
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(133, 21);
            this.cboPriority.TabIndex = 19;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "";
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(347, 112);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(133, 20);
            this.dtpDueDate.TabIndex = 24;
            this.dtpDueDate.Value = new System.DateTime(2004, 7, 14, 21, 23, 45, 111);
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(252, 91);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(46, 13);
            this.lblPriority.TabIndex = 18;
            this.lblPriority.Text = "Priority";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(104, 160);
            this.txtQty3.MaxLength = 11;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.Size = new System.Drawing.Size(133, 20);
            this.txtQty3.TabIndex = 11;
            this.txtQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(104, 136);
            this.txtQty2.MaxLength = 11;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.Size = new System.Drawing.Size(133, 20);
            this.txtQty2.TabIndex = 9;
            this.txtQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(104, 112);
            this.txtQty1.MaxLength = 11;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.Size = new System.Drawing.Size(133, 20);
            this.txtQty1.TabIndex = 7;
            this.txtQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cdvLotType
            // 
            this.cdvLotType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLotType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLotType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLotType.BtnToolTipText = "";
            this.cdvLotType.DescText = "";
            this.cdvLotType.DisplaySubItemIndex = -1;
            this.cdvLotType.DisplayText = "";
            this.cdvLotType.Focusing = null;
            this.cdvLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLotType.Index = 0;
            this.cdvLotType.IsViewBtnImage = false;
            this.cdvLotType.Location = new System.Drawing.Point(347, 64);
            this.cdvLotType.MaxLength = 1;
            this.cdvLotType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.Name = "cdvLotType";
            this.cdvLotType.ReadOnly = false;
            this.cdvLotType.SearchSubItemIndex = 0;
            this.cdvLotType.SelectedDescIndex = -1;
            this.cdvLotType.SelectedSubItemIndex = -1;
            this.cdvLotType.SelectionStart = 0;
            this.cdvLotType.Size = new System.Drawing.Size(133, 20);
            this.cdvLotType.SmallImageList = null;
            this.cdvLotType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLotType.TabIndex = 17;
            this.cdvLotType.TextBoxToolTipText = "";
            this.cdvLotType.TextBoxWidth = 133;
            this.cdvLotType.VisibleButton = true;
            this.cdvLotType.VisibleColumnHeader = false;
            this.cdvLotType.VisibleDescription = false;
            this.cdvLotType.ButtonPress += new System.EventHandler(this.cdvLotType_ButtonPress);
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty1.Location = new System.Drawing.Point(12, 115);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(37, 13);
            this.lblQty1.TabIndex = 6;
            this.lblQty1.Text = "Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLotType
            // 
            this.lblLotType.AutoSize = true;
            this.lblLotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotType.Location = new System.Drawing.Point(252, 67);
            this.lblLotType.Name = "lblLotType";
            this.lblLotType.Size = new System.Drawing.Size(57, 13);
            this.lblLotType.TabIndex = 16;
            this.lblLotType.Text = "Lot Type";
            this.lblLotType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCode
            // 
            this.lblCreateCode.AutoSize = true;
            this.lblCreateCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCode.Location = new System.Drawing.Point(253, 19);
            this.lblCreateCode.Name = "lblCreateCode";
            this.lblCreateCode.Size = new System.Drawing.Size(77, 13);
            this.lblCreateCode.TabIndex = 12;
            this.lblCreateCode.Text = "Create Code";
            this.lblCreateCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvOwnerCode
            // 
            this.cdvOwnerCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOwnerCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOwnerCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOwnerCode.BtnToolTipText = "";
            this.cdvOwnerCode.DescText = "";
            this.cdvOwnerCode.DisplaySubItemIndex = -1;
            this.cdvOwnerCode.DisplayText = "";
            this.cdvOwnerCode.Focusing = null;
            this.cdvOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOwnerCode.Index = 0;
            this.cdvOwnerCode.IsViewBtnImage = false;
            this.cdvOwnerCode.Location = new System.Drawing.Point(347, 40);
            this.cdvOwnerCode.MaxLength = 10;
            this.cdvOwnerCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOwnerCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOwnerCode.Name = "cdvOwnerCode";
            this.cdvOwnerCode.ReadOnly = false;
            this.cdvOwnerCode.SearchSubItemIndex = 0;
            this.cdvOwnerCode.SelectedDescIndex = -1;
            this.cdvOwnerCode.SelectedSubItemIndex = -1;
            this.cdvOwnerCode.SelectionStart = 0;
            this.cdvOwnerCode.Size = new System.Drawing.Size(133, 20);
            this.cdvOwnerCode.SmallImageList = null;
            this.cdvOwnerCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOwnerCode.TabIndex = 15;
            this.cdvOwnerCode.TextBoxToolTipText = "";
            this.cdvOwnerCode.TextBoxWidth = 133;
            this.cdvOwnerCode.VisibleButton = true;
            this.cdvOwnerCode.VisibleColumnHeader = false;
            this.cdvOwnerCode.VisibleDescription = false;
            this.cdvOwnerCode.ButtonPress += new System.EventHandler(this.cdvOwnerCode_ButtonPress);
            // 
            // cdvCreateCode
            // 
            this.cdvCreateCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCode.BtnToolTipText = "";
            this.cdvCreateCode.DescText = "";
            this.cdvCreateCode.DisplaySubItemIndex = -1;
            this.cdvCreateCode.DisplayText = "";
            this.cdvCreateCode.Focusing = null;
            this.cdvCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCode.Index = 0;
            this.cdvCreateCode.IsViewBtnImage = false;
            this.cdvCreateCode.Location = new System.Drawing.Point(348, 16);
            this.cdvCreateCode.MaxLength = 10;
            this.cdvCreateCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCode.Name = "cdvCreateCode";
            this.cdvCreateCode.ReadOnly = false;
            this.cdvCreateCode.SearchSubItemIndex = 0;
            this.cdvCreateCode.SelectedDescIndex = -1;
            this.cdvCreateCode.SelectedSubItemIndex = -1;
            this.cdvCreateCode.SelectionStart = 0;
            this.cdvCreateCode.Size = new System.Drawing.Size(133, 20);
            this.cdvCreateCode.SmallImageList = null;
            this.cdvCreateCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCode.TabIndex = 13;
            this.cdvCreateCode.TextBoxToolTipText = "";
            this.cdvCreateCode.TextBoxWidth = 133;
            this.cdvCreateCode.VisibleButton = true;
            this.cdvCreateCode.VisibleColumnHeader = false;
            this.cdvCreateCode.VisibleDescription = false;
            this.cdvCreateCode.ButtonPress += new System.EventHandler(this.cdvCreateCode_ButtonPress);
            // 
            // lblOwnerCode
            // 
            this.lblOwnerCode.AutoSize = true;
            this.lblOwnerCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerCode.Location = new System.Drawing.Point(252, 43);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(76, 13);
            this.lblOwnerCode.TabIndex = 14;
            this.lblOwnerCode.Text = "Owner Code";
            this.lblOwnerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvOperation.Location = new System.Drawing.Point(104, 88);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(133, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 5;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 133;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(12, 91);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(62, 13);
            this.lblOperation.TabIndex = 4;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.AutoSize = true;
            this.lblWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkDate.Location = new System.Drawing.Point(12, 19);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(68, 13);
            this.lblWorkDate.TabIndex = 0;
            this.lblWorkDate.Text = "Work Date";
            this.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorkDate.Location = new System.Drawing.Point(104, 16);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(133, 20);
            this.dtpWorkDate.TabIndex = 1;
            // 
            // frmORDSetupPlannedLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmORDSetupPlannedLot";
            this.Text = "Planned Lot Setup";
            this.Activated += new System.EventHandler(this.frmORDSetupPlannedLot_Activated);
            this.Load += new System.EventHandler(this.frmORDSetupPlannedLot_Load);
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
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.grpLot.ResumeLayout(false);
            this.grpLot.PerformLayout();
            this.pnlGeneral.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tbpCreate.ResumeLayout(false);
            this.grpUpdateInfo.ResumeLayout(false);
            this.grpUpdateInfo.PerformLayout();
            this.pnlCreateStatus.ResumeLayout(false);
            this.grpCreateStatus.ResumeLayout(false);
            this.grpCreateStatus.PerformLayout();
            this.pnlCreateInfo.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        private bool b_load_flag = false;
        
        #region " Function Definition "
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool CheckCondition(string FuncName)
        {

            if (MPCF.CheckValue(txtLotID, 1, false, false, "", "", "") == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":

                    if (MPCF.CheckValue(txtQty1, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (cdvMaterial.CheckValue() == false)
                    {
                        return false;
                    }
                    if (cdvFlow.CheckValue() == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvOperation, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtQty1, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCreateCode, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvOwnerCode, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvLotType, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cboPriority, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (chkDueDate.Checked == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        chkDueDate.Focus();
                        return false;
                    }
                    break;
                case "UPDATE":

                    if (MPCF.CheckValue(txtQty1, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (cdvMaterial.CheckValue() == false)
                    {
                        return false;
                    }
                    if (cdvFlow.CheckValue() == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvOperation, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtQty1, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCreateCode, 1,false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvOwnerCode, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvLotType, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cboPriority, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (chkDueDate.Checked == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        chkDueDate.Focus();
                        return false;
                    }
                    break;
            }

            return true;

        }

        //
        // View_PlannedLot()
        //       - View Planned Lot
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool View_PlannedLot()
        {

            TRSNode in_node = new TRSNode("VIEW_PLANNEDLOT_IN");
            TRSNode out_node = new TRSNode("VIEW_PLANNEDLOT_OUT");

            MPCF.FieldClear(this.pnlRight);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(lisLot.SelectedItems[0].Text));
            in_node.AddString("WORK_DATE", MPCF.ToStandardTime(dtpDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
            
            if (MPCR.CallService("ORD", "ORD_View_PlannedLot", in_node, ref out_node) == false)
            {
                return false;
            }
            txtLotID.Text = out_node.GetString("LOT_ID");
            txtLotDesc.Text = out_node.GetString("LOT_DESC");
            cdvMaterial.Text = out_node.GetString("MAT_ID");
            cdvMaterial.Version = out_node.GetInt("MAT_VER");
            cdvFlow.Text = out_node.GetString("FLOW");
            cdvFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
            cdvOperation.Text = out_node.GetString("OPER");
            dtpWorkDate.Value =  MPCF.ToDate(out_node.GetString("WORK_DATE") + "000000");
            cdvOrderID.Text = out_node.GetString("ORDER_ID");
            cdvResID.Text = out_node.GetString("RES_ID");
            txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
            txtCreateTime.Text =  MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
            txtUpdateTime.Text =  MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
            //Modify by J.S. 2012.06.28 qty필드 잘못 사용함
            txtQty1.Text =  MPCF.Format("##,##0.###", out_node.GetDouble("QTY_1"));
            txtQty2.Text = MPCF.Format("##,##0.###", out_node.GetDouble("QTY_2"));
            txtQty3.Text = MPCF.Format("##,##0.###", out_node.GetDouble("QTY_3"));
            cdvCreateCode.Text = out_node.GetString("CREATE_CODE");
            cdvOwnerCode.Text = out_node.GetString("OWNER_CODE");
            cdvLotType.Text = MPCF.Trim( out_node.GetChar("LOT_TYPE"));
            cboPriority.Text = MPCF.Trim( out_node.GetChar("LOT_PRIORITY"));

            if (MPCF.Trim(out_node.GetString("ORG_DUE_TIME")) != "")
            {
                chkDueDate.Checked = true;
                txtDueDate.Visible = false;
                dtpDueDate.Value = MPCF.ToDate(out_node.GetString("ORG_DUE_TIME") + "000000");
            }
            else
            {
                chkDueDate.Checked = false;
                txtDueDate.Visible = true;
            }
            chkLotCreateFlag.Checked = (out_node.GetChar("LOT_CREATE_FLAG") == 'Y') ? true : false;
            txtLotCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("LOT_CREATE_TIME"));

            if (MPCF.Trim(out_node.GetString("LOT_CREATE_TIME")) == "Y")
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);
            }
            return true;

        }

        //
        // Update_PlannedLot()
        //       - Create/Update/Delete Planned Lot
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal c_step As String : ProcStep
        private bool Update_PlannedLot(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_PLANNEDLOT_IN");
            TRSNode out_node = new TRSNode("Cmn_Out");

            ListViewItem itm;
            int idx;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("LOT_DESC", MPCF.Trim(txtLotDesc.Text));
                in_node.AddString("WORK_DATE", MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddInt("FLOW_SEQ_NUM", cdvFlow.Sequence);
                in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
                in_node.AddString("ORDER_ID", MPCF.Trim(cdvOrderID.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddDouble("QTY_1", MPCF.ToDbl(txtQty1.Text));
                in_node.AddDouble("QTY_2", MPCF.ToDbl(txtQty2.Text));
                in_node.AddDouble("QTY_3", MPCF.ToDbl(txtQty3.Text));
                in_node.AddString("CREATE_CODE", MPCF.Trim(cdvCreateCode.Text));
                in_node.AddString("OWNER_CODE", MPCF.Trim(cdvOwnerCode.Text));
                in_node.AddChar("LOT_TYPE", MPCF.ToChar(MPCF.Trim(cdvLotType.Text)));
                in_node.AddChar("LOT_PRIORITY", MPCF.ToChar(MPCF.Trim(cboPriority.Text)));

                if (chkDueDate.Checked == true)
                {
                    in_node.AddString("ORG_DUE_TIME", MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                }

                if (MPCR.CallService("ORD", "ORD_Update_PlannedLot", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisLot.Items.Add(txtLotID.Text, (int)SMALLICON_INDEX.IDX_LOT);
                        itm.SubItems.Add(txtQty1.Text);
                        itm.Selected = true;
                        lisLot.Sorting = SortOrder.Ascending;
                        lisLot.Sort();
                        itm.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisLot, MPCF.Trim(txtLotID.Text), false) == true)
                        {
                            lisLot.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtQty1.Text);
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisLot, MPCF.Trim(txtLotID.Text), false);
                        if (idx != - 1)
                        {
                            lisLot.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisLot.Items.Count);
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
        // GetOperationList()
        //       - Get Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetOperationList(string sFlow)
        {

            try
            {
                cdvOperation.Init();
                MPCF.InitListView(cdvOperation.GetListView);
                cdvOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvOperation.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewOperationList(cdvOperation.GetListView, '2', "",0,  sFlow, "", null, "") == false)
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }
        //
        // View_Material()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Material()
        {

            TRSNode in_node = new TRSNode("VIEW_MATERIAL_IN");
            TRSNode out_node = new TRSNode("VIEW_MATERIAL_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);

            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvFlow.Text = MPCF.Trim(out_node.GetString("FIRST_FLOW"));
            cdvFlow.Sequence = out_node.GetInt("FIRST_FLOW_SEQ_NUM");
            cdvOperation.Text = MPCF.Trim(out_node.GetString("FIRST_OPER"));

            return true;

        }
        //
        // View_Flow()
        //       - View Flow Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Flow()
        {

            TRSNode in_node = new TRSNode("VIEW_FLOW_IN");
            TRSNode out_node = new TRSNode("VIEW_FLOW_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvOperation.Text = MPCF.Trim(out_node.GetString("FIRST_OPER"));

            return true;

        }
        //
        // Refresh_Lotlist()
        //       - Refresh Lot List
        // Return Value
        //       -
        // Arguments
        //        -
        private void Refresh_Lotlist()
        {
            if (chkIncludeCreateFlag.Checked == true)
            {
                if (ORDLIST.ViewPlannedLotList(lisLot, '2', MPCF.ToStandardTime(dtpDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), null, "") == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisLot.Items.Count);
                }
            }
            else if (chkIncludeCreateFlag.Checked == false)
            {
                if (ORDLIST.ViewPlannedLotList(lisLot, '1', MPCF.ToStandardTime(dtpDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), null, "") == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisLot.Items.Count);
                }
            }
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.dtpDate;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        
        private void frmORDSetupPlannedLot_Load(object sender, System.EventArgs e)
        {
        }
        
        private void frmORDSetupPlannedLot_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.InitListView(lisLot);
                if (ORDLIST.ViewPlannedLotList(lisLot, '1', MPCF.ToStandardTime(dtpDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), null, "") == true)
                {
                    if (lisLot.Items.Count > 0)
                    {
                        lisLot.Items[0].Selected = true;
                        lblDataCount.Text = MPCF.Trim(lisLot.Items.Count);
                    }
                }

                b_load_flag = true;
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisLot, this.Text, "");
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            Refresh_Lotlist();
            if (lisLot.Items.Count > 0)
            {
                lisLot.Items[0].Selected = true;
            }
        }
        
        private void cdvResID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            #if _RAS
            RASLIST.ViewResourceList(cdvResID.GetListView, false);
            #endif
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("CREATE") == true)
            {
                if (Update_PlannedLot(MPGC.MP_STEP_CREATE) == true)
                {
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        Refresh_Lotlist();
                        MPCF.FindListItem(lisLot, txtLotID.Text, false);
                    }
                }
            }
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("UPDATE") == true)
            {
                if (Update_PlannedLot(MPGC.MP_STEP_UPDATE) == true)
                {
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        Refresh_Lotlist();
                        MPCF.FindListItem(lisLot, txtLotID.Text, false);
                    }
                }
            }
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            int iIdx = 0;
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            if (lisLot.SelectedItems.Count > 0)
            {
                iIdx = lisLot.SelectedItems[0].Index;
            }
            if (CheckCondition("DELETE") == true)
            {
                if (Update_PlannedLot(MPGC.MP_STEP_DELETE) == true)
                {
                    MPCF.FieldClear(this.pnlRight);
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        Refresh_Lotlist();
                        if (iIdx < lisLot.Items.Count)
                        {
                            lisLot.Items[iIdx].Selected = true;
                        }
                    }
                }
            }
        }
        
        private void cdvFlow_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            if (cdvMaterial.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvMaterial.Focus();
                return;
            }
            cdvFlow.ListCond_Step = '2';
            cdvFlow.ListCond_MatID = cdvMaterial.Text;
            cdvFlow.ListCond_MatVersion = cdvMaterial.Version;    
            
        }
        
        private void cdvOperation_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            if (cdvMaterial.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvMaterial.Focus();
                return;
            }
            if (cdvFlow.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvFlow.Focus();
                return;
            }
            
            if (GetOperationList(cdvFlow.Text) == false)
            {
                return;
            }
            
        }
        
        private void dtpDate_CloseUp(object sender, System.EventArgs e)
        {
            Refresh_Lotlist();
            MPCF.FieldClear(this.pnlRight);
            if (lisLot.Items.Count > 0)
            {
                lisLot.Items[0].Selected = true;
            }
        }
        
        private void lisLot_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this.pnlRight);
            if (lisLot.SelectedItems.Count > 0)
            {
                txtLotID.Text = lisLot.SelectedItems[0].Text;
                View_PlannedLot();
            }
        }
        
        private void chkIncludeDeleteFlag_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            Refresh_Lotlist();
            MPCF.FieldClear(this.pnlRight);
            if (lisLot.Items.Count > 0)
            {
                lisLot.Items[0].Selected = true;
            }
        }
        
        private void txtLotID_TextChanged(System.Object sender, System.EventArgs e)
        {
            //chkDueDate.Checked = False
        }
        
        private void chkDueDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkDueDate.Checked == true)
            {
                dtpDueDate.Value = System.DateTime.Now;
            }
            txtDueDate.Visible = ! chkDueDate.Checked;
        }

        private void cdvMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvFlow.Text = "";
            cdvOperation.Text = "";
            
            if (View_Material() == false)
            {
                return;
            }
            
        }
        
        private void cdvFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (View_Flow() == false)
            {
                return;
            }
            
        }
        
        private void cdvFlow_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            cdvOperation.Text = "";
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisLot, txtFind.Text, true, false);
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisLot, txtFind.Text, 0, true, false);
        }
        
        private void cdvCreateCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCreateCode.Init();
            MPCF.InitListView(cdvCreateCode.GetListView);
            cdvCreateCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvCreateCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCreateCode.SelectedSubItemIndex = 0;
            
            BASLIST.ViewGCMDataList(cdvCreateCode.GetListView, '1', MPGC.MP_WIP_CREATE_CODE);
        }
        
        private void cdvOwnerCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOwnerCode.Init();
            MPCF.InitListView(cdvOwnerCode.GetListView);
            cdvOwnerCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvOwnerCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOwnerCode.SelectedSubItemIndex = 0;
            
            BASLIST.ViewGCMDataList(cdvOwnerCode.GetListView, '1', MPGC.MP_WIP_OWNER_CODE);
        }
        
        private void cdvLotType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvLotType.Init();
            MPCF.InitListView(cdvLotType.GetListView);
            cdvLotType.Columns.Add("LotType", 50, HorizontalAlignment.Left);
            cdvLotType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvLotType.SelectedSubItemIndex = 0;
            
            BASLIST.ViewGCMDataList(cdvLotType.GetListView, '1', MPGC.MP_WIP_LOT_TYPE);
        }
        
        //private void cdvMaterial_MaterialButtonPress(object sender, System.EventArgs e)
        //{
        //    cdvMaterial.Init();
        //    MPCF.InitListView(cdvMaterial.MaterialGetListView);
        //    cdvMaterial.MaterialColumns.Add("Material", 50, HorizontalAlignment.Left);
        //    cdvMaterial.MaterialColumns.Add("Desc", 100, HorizontalAlignment.Left);
        //    cdvMaterial.SelectedSubItemIndex = 0;

        //    WIPLIST.ViewMaterialList(cdvMaterial.MaterialGetListView, '1');
        //}
        
        private void cdvOrderID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOrderID.Init();
            MPCF.InitListView(cdvOrderID.GetListView);
            cdvOrderID.Columns.Add("Order", 150, HorizontalAlignment.Left);
            cdvOrderID.Columns.Add("Mat ID", 200, HorizontalAlignment.Left);
            cdvOrderID.Columns.Add("Mat Ver", 200, HorizontalAlignment.Left);
            cdvOrderID.Columns.Add("Order Qty", 200, HorizontalAlignment.Left);
            cdvOrderID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvOrderID.SelectedSubItemIndex = 0;
            ORDLIST.ViewOrderList(cdvOrderID.GetListView, '1', "", null, "");
        }
        
    }
    //#End If
}
