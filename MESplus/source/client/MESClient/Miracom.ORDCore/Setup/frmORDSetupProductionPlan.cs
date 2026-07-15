
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
//   File Name   : frmORDSetupProductionPlan.vb
//   Description : Production Plan Setup
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition()        : Check the conditions before transaction
//       - View_Plan()             : View Plan Information
//       - Update_Plan()           : Create/Update/Delete Plan Information
//       - GetCreateCodeList()     : Get Create Code List
//       - GetOwnerCodeList()      : Get Owner Code List
//       - GetLotTypeList()        : Get Lot Type List
//       - Refresh_MaterialList()  : Refresh Order List
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
    public class frmORDSetupProductionPlan : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmORDSetupProductionPlan()
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
        private System.Windows.Forms.GroupBox grpOrder;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.TabControl tabGeneral;
        private Miracom.UI.Controls.MCListView.MCListView lisMaterial;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlPlan;
        private System.Windows.Forms.GroupBox grpGen;
        private System.Windows.Forms.Label lblWorkDate;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.TextBox txtPlanQty1;
        private System.Windows.Forms.Label lblPlanQty1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.GroupBox grpCreate;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.CheckBox chkDueDate;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.Label lblCreateCode;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOwnerCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCode;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblOwnerCode;
        private System.Windows.Forms.TextBox txtQty1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLotType;
        private System.Windows.Forms.Label lblQty1;
        private System.Windows.Forms.Label lblLotType;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpCreate;
        private System.Windows.Forms.Panel pnlPlanStatus;
        private System.Windows.Forms.GroupBox grpPlanStatus;
        private System.Windows.Forms.TextBox txtCreateLotCount;
        private System.Windows.Forms.Label lblCreateLotCount;
        private System.Windows.Forms.TextBox txtCreateQty1;
        private System.Windows.Forms.Label lblCreateQty1;
        private System.Windows.Forms.GroupBox grpUpdateInfo;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.TextBox txtCreateUser;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private ColumnHeader ColumnHeader2;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisMaterial = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlDate = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.grpOrder = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.tabGeneral = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpUpdateInfo = new System.Windows.Forms.GroupBox();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.pnlPlanStatus = new System.Windows.Forms.Panel();
            this.grpPlanStatus = new System.Windows.Forms.GroupBox();
            this.txtCreateLotCount = new System.Windows.Forms.TextBox();
            this.lblCreateLotCount = new System.Windows.Forms.Label();
            this.txtCreateQty1 = new System.Windows.Forms.TextBox();
            this.lblCreateQty1 = new System.Windows.Forms.Label();
            this.pnlPlan = new System.Windows.Forms.Panel();
            this.grpGen = new System.Windows.Forms.GroupBox();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.txtPlanQty1 = new System.Windows.Forms.TextBox();
            this.lblPlanQty1 = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.tbpCreate = new System.Windows.Forms.TabPage();
            this.grpCreate = new System.Windows.Forms.GroupBox();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.chkDueDate = new System.Windows.Forms.CheckBox();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.lblCreateCode = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.cdvOwnerCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblOwnerCode = new System.Windows.Forms.Label();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.cdvLotType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.lblLotType = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.grpOrder.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpUpdateInfo.SuspendLayout();
            this.pnlPlanStatus.SuspendLayout();
            this.grpPlanStatus.SuspendLayout();
            this.pnlPlan.SuspendLayout();
            this.grpGen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.tbpCreate.SuspendLayout();
            this.grpCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).BeginInit();
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
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlGeneral);
            this.pnlRight.Controls.Add(this.grpOrder);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisMaterial);
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
            this.lblFormTitle.Text = "Production Plan Setup";
            // 
            // lisMaterial
            // 
            this.lisMaterial.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3});
            this.lisMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMaterial.EnableSort = true;
            this.lisMaterial.EnableSortIcon = true;
            this.lisMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMaterial.FullRowSelect = true;
            this.lisMaterial.Location = new System.Drawing.Point(3, 36);
            this.lisMaterial.MultiSelect = false;
            this.lisMaterial.Name = "lisMaterial";
            this.lisMaterial.Size = new System.Drawing.Size(229, 474);
            this.lisMaterial.TabIndex = 1;
            this.lisMaterial.UseCompatibleStateImageBehavior = false;
            this.lisMaterial.View = System.Windows.Forms.View.Details;
            this.lisMaterial.SelectedIndexChanged += new System.EventHandler(this.lisMaterial_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Mat ID";
            this.ColumnHeader1.Width = 130;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Mat Ver";
            this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Qty";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.lblDate);
            this.pnlDate.Controls.Add(this.dtpDate);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDate.Location = new System.Drawing.Point(3, 0);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(229, 36);
            this.pnlDate.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
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
            this.dtpDate.Location = new System.Drawing.Point(112, 9);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(90, 20);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.CloseUp += new System.EventHandler(this.dtpDate_CloseUp);
            // 
            // grpOrder
            // 
            this.grpOrder.Controls.Add(this.cdvMaterial);
            this.grpOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOrder.Location = new System.Drawing.Point(3, 0);
            this.grpOrder.Name = "grpOrder";
            this.grpOrder.Size = new System.Drawing.Size(500, 47);
            this.grpOrder.TabIndex = 0;
            this.grpOrder.TabStop = false;
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
            this.cdvMaterial.Location = new System.Drawing.Point(16, 16);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(320, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 120;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialTextChanged += new System.EventHandler(this.cdvMaterial_MaterialTextChanged);
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.tabGeneral);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(3, 47);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlGeneral.Size = new System.Drawing.Size(500, 463);
            this.pnlGeneral.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tbpGeneral);
            this.tabGeneral.Controls.Add(this.tbpCreate);
            this.tabGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneral.ItemSize = new System.Drawing.Size(60, 18);
            this.tabGeneral.Location = new System.Drawing.Point(0, 5);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.SelectedIndex = 0;
            this.tabGeneral.Size = new System.Drawing.Size(500, 458);
            this.tabGeneral.TabIndex = 1;
            this.tabGeneral.TabStop = false;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpUpdateInfo);
            this.tbpGeneral.Controls.Add(this.pnlPlanStatus);
            this.tbpGeneral.Controls.Add(this.pnlPlan);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 432);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpUpdateInfo
            // 
            this.grpUpdateInfo.Controls.Add(this.lblUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.lblCreateUser);
            this.grpUpdateInfo.Controls.Add(this.txtUpdateTime);
            this.grpUpdateInfo.Controls.Add(this.txtCreateTime);
            this.grpUpdateInfo.Controls.Add(this.txtUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.txtCreateUser);
            this.grpUpdateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUpdateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUpdateInfo.Location = new System.Drawing.Point(3, 176);
            this.grpUpdateInfo.Name = "grpUpdateInfo";
            this.grpUpdateInfo.Size = new System.Drawing.Size(486, 253);
            this.grpUpdateInfo.TabIndex = 2;
            this.grpUpdateInfo.TabStop = false;
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(15, 43);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(95, 13);
            this.lblUpdateUser.TabIndex = 3;
            this.lblUpdateUser.Text = "Update User/Time";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(15, 19);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(91, 13);
            this.lblCreateUser.TabIndex = 0;
            this.lblCreateUser.Text = "Create User/Time";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(272, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(133, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(272, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(133, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(132, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(133, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(132, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(133, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // pnlPlanStatus
            // 
            this.pnlPlanStatus.Controls.Add(this.grpPlanStatus);
            this.pnlPlanStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPlanStatus.Location = new System.Drawing.Point(3, 100);
            this.pnlPlanStatus.Name = "pnlPlanStatus";
            this.pnlPlanStatus.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlPlanStatus.Size = new System.Drawing.Size(486, 76);
            this.pnlPlanStatus.TabIndex = 1;
            // 
            // grpPlanStatus
            // 
            this.grpPlanStatus.Controls.Add(this.txtCreateLotCount);
            this.grpPlanStatus.Controls.Add(this.lblCreateLotCount);
            this.grpPlanStatus.Controls.Add(this.txtCreateQty1);
            this.grpPlanStatus.Controls.Add(this.lblCreateQty1);
            this.grpPlanStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlanStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPlanStatus.Location = new System.Drawing.Point(0, 5);
            this.grpPlanStatus.Name = "grpPlanStatus";
            this.grpPlanStatus.Size = new System.Drawing.Size(486, 71);
            this.grpPlanStatus.TabIndex = 1;
            this.grpPlanStatus.TabStop = false;
            this.grpPlanStatus.Text = "Plan Status";
            // 
            // txtCreateLotCount
            // 
            this.txtCreateLotCount.Location = new System.Drawing.Point(132, 16);
            this.txtCreateLotCount.MaxLength = 10;
            this.txtCreateLotCount.Name = "txtCreateLotCount";
            this.txtCreateLotCount.ReadOnly = true;
            this.txtCreateLotCount.Size = new System.Drawing.Size(133, 20);
            this.txtCreateLotCount.TabIndex = 1;
            this.txtCreateLotCount.TabStop = false;
            this.txtCreateLotCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCreateLotCount
            // 
            this.lblCreateLotCount.AutoSize = true;
            this.lblCreateLotCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateLotCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateLotCount.Location = new System.Drawing.Point(15, 19);
            this.lblCreateLotCount.Name = "lblCreateLotCount";
            this.lblCreateLotCount.Size = new System.Drawing.Size(87, 13);
            this.lblCreateLotCount.TabIndex = 0;
            this.lblCreateLotCount.Text = "Create Lot Count";
            this.lblCreateLotCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateQty1
            // 
            this.txtCreateQty1.Location = new System.Drawing.Point(132, 40);
            this.txtCreateQty1.MaxLength = 10;
            this.txtCreateQty1.Name = "txtCreateQty1";
            this.txtCreateQty1.ReadOnly = true;
            this.txtCreateQty1.Size = new System.Drawing.Size(133, 20);
            this.txtCreateQty1.TabIndex = 3;
            this.txtCreateQty1.TabStop = false;
            this.txtCreateQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCreateQty1
            // 
            this.lblCreateQty1.AutoSize = true;
            this.lblCreateQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateQty1.Location = new System.Drawing.Point(15, 43);
            this.lblCreateQty1.Name = "lblCreateQty1";
            this.lblCreateQty1.Size = new System.Drawing.Size(57, 13);
            this.lblCreateQty1.TabIndex = 2;
            this.lblCreateQty1.Text = "Create Qty";
            this.lblCreateQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlPlan
            // 
            this.pnlPlan.Controls.Add(this.grpGen);
            this.pnlPlan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPlan.Location = new System.Drawing.Point(3, 0);
            this.pnlPlan.Name = "pnlPlan";
            this.pnlPlan.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlPlan.Size = new System.Drawing.Size(486, 100);
            this.pnlPlan.TabIndex = 0;
            // 
            // grpGen
            // 
            this.grpGen.Controls.Add(this.lblWorkDate);
            this.grpGen.Controls.Add(this.dtpWorkDate);
            this.grpGen.Controls.Add(this.txtPlanQty1);
            this.grpGen.Controls.Add(this.lblPlanQty1);
            this.grpGen.Controls.Add(this.cdvResID);
            this.grpGen.Controls.Add(this.lblResID);
            this.grpGen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGen.Location = new System.Drawing.Point(0, 5);
            this.grpGen.Name = "grpGen";
            this.grpGen.Size = new System.Drawing.Size(486, 95);
            this.grpGen.TabIndex = 0;
            this.grpGen.TabStop = false;
            this.grpGen.Text = "General";
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.AutoSize = true;
            this.lblWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkDate.Location = new System.Drawing.Point(15, 19);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(68, 13);
            this.lblWorkDate.TabIndex = 0;
            this.lblWorkDate.Text = "Work Date";
            this.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpWorkDate
            // 
            this.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWorkDate.Location = new System.Drawing.Point(132, 16);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(133, 20);
            this.dtpWorkDate.TabIndex = 1;
            // 
            // txtPlanQty1
            // 
            this.txtPlanQty1.Location = new System.Drawing.Point(132, 64);
            this.txtPlanQty1.MaxLength = 11;
            this.txtPlanQty1.Name = "txtPlanQty1";
            this.txtPlanQty1.Size = new System.Drawing.Size(133, 20);
            this.txtPlanQty1.TabIndex = 5;
            this.txtPlanQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPlanQty1
            // 
            this.lblPlanQty1.AutoSize = true;
            this.lblPlanQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPlanQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanQty1.Location = new System.Drawing.Point(15, 67);
            this.lblPlanQty1.Name = "lblPlanQty1";
            this.lblPlanQty1.Size = new System.Drawing.Size(55, 13);
            this.lblPlanQty1.TabIndex = 4;
            this.lblPlanQty1.Text = "Plan Qty";
            this.lblPlanQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvResID.Location = new System.Drawing.Point(132, 40);
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
            this.cdvResID.TabIndex = 3;
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
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 43);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(61, 13);
            this.lblResID.TabIndex = 2;
            this.lblResID.Text = "Resource";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCreate
            // 
            this.tbpCreate.Controls.Add(this.grpCreate);
            this.tbpCreate.Location = new System.Drawing.Point(4, 22);
            this.tbpCreate.Name = "tbpCreate";
            this.tbpCreate.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCreate.Size = new System.Drawing.Size(492, 432);
            this.tbpCreate.TabIndex = 1;
            this.tbpCreate.Text = "Create Info";
            // 
            // grpCreate
            // 
            this.grpCreate.Controls.Add(this.txtDueDate);
            this.grpCreate.Controls.Add(this.chkDueDate);
            this.grpCreate.Controls.Add(this.cboPriority);
            this.grpCreate.Controls.Add(this.lblCreateCode);
            this.grpCreate.Controls.Add(this.dtpDueDate);
            this.grpCreate.Controls.Add(this.cdvOwnerCode);
            this.grpCreate.Controls.Add(this.cdvCreateCode);
            this.grpCreate.Controls.Add(this.lblPriority);
            this.grpCreate.Controls.Add(this.lblOwnerCode);
            this.grpCreate.Controls.Add(this.txtQty1);
            this.grpCreate.Controls.Add(this.cdvLotType);
            this.grpCreate.Controls.Add(this.lblQty1);
            this.grpCreate.Controls.Add(this.lblLotType);
            this.grpCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreate.Location = new System.Drawing.Point(3, 0);
            this.grpCreate.Name = "grpCreate";
            this.grpCreate.Size = new System.Drawing.Size(486, 429);
            this.grpCreate.TabIndex = 0;
            this.grpCreate.TabStop = false;
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(107, 64);
            this.txtDueDate.MaxLength = 30;
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(133, 20);
            this.txtDueDate.TabIndex = 5;
            this.txtDueDate.TabStop = false;
            // 
            // chkDueDate
            // 
            this.chkDueDate.AutoSize = true;
            this.chkDueDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDueDate.Location = new System.Drawing.Point(11, 66);
            this.chkDueDate.Name = "chkDueDate";
            this.chkDueDate.Size = new System.Drawing.Size(86, 18);
            this.chkDueDate.TabIndex = 4;
            this.chkDueDate.Text = "Due Date";
            this.chkDueDate.CheckedChanged += new System.EventHandler(this.chkDueDate_CheckedChanged);
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
            this.cboPriority.Location = new System.Drawing.Point(346, 64);
            this.cboPriority.MaxDropDownItems = 9;
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(133, 21);
            this.cboPriority.TabIndex = 12;
            // 
            // lblCreateCode
            // 
            this.lblCreateCode.AutoSize = true;
            this.lblCreateCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCode.Location = new System.Drawing.Point(251, 19);
            this.lblCreateCode.Name = "lblCreateCode";
            this.lblCreateCode.Size = new System.Drawing.Size(77, 13);
            this.lblCreateCode.TabIndex = 7;
            this.lblCreateCode.Text = "Create Code";
            this.lblCreateCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "";
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(107, 64);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(133, 20);
            this.dtpDueDate.TabIndex = 6;
            this.dtpDueDate.Value = new System.DateTime(2004, 7, 14, 21, 23, 45, 111);
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
            this.cdvOwnerCode.Location = new System.Drawing.Point(346, 40);
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
            this.cdvOwnerCode.TabIndex = 10;
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
            this.cdvCreateCode.Location = new System.Drawing.Point(346, 16);
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
            this.cdvCreateCode.TabIndex = 8;
            this.cdvCreateCode.TextBoxToolTipText = "";
            this.cdvCreateCode.TextBoxWidth = 133;
            this.cdvCreateCode.VisibleButton = true;
            this.cdvCreateCode.VisibleColumnHeader = false;
            this.cdvCreateCode.VisibleDescription = false;
            this.cdvCreateCode.ButtonPress += new System.EventHandler(this.cdvCreateCode_ButtonPress);
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(251, 67);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(46, 13);
            this.lblPriority.TabIndex = 11;
            this.lblPriority.Text = "Priority";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOwnerCode
            // 
            this.lblOwnerCode.AutoSize = true;
            this.lblOwnerCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerCode.Location = new System.Drawing.Point(251, 43);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(76, 13);
            this.lblOwnerCode.TabIndex = 9;
            this.lblOwnerCode.Text = "Owner Code";
            this.lblOwnerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(107, 16);
            this.txtQty1.MaxLength = 11;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.Size = new System.Drawing.Size(133, 20);
            this.txtQty1.TabIndex = 1;
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
            this.cdvLotType.Location = new System.Drawing.Point(107, 40);
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
            this.cdvLotType.TabIndex = 3;
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
            this.lblQty1.Location = new System.Drawing.Point(12, 19);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(26, 13);
            this.lblQty1.TabIndex = 0;
            this.lblQty1.Text = "Qty";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLotType
            // 
            this.lblLotType.AutoSize = true;
            this.lblLotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotType.Location = new System.Drawing.Point(11, 43);
            this.lblLotType.Name = "lblLotType";
            this.lblLotType.Size = new System.Drawing.Size(57, 13);
            this.lblLotType.TabIndex = 2;
            this.lblLotType.Text = "Lot Type";
            this.lblLotType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmORDSetupProductionPlan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmORDSetupProductionPlan";
            this.Text = "Production Plan Setup";
            this.Activated += new System.EventHandler(this.frmORDSetupProductionPlan_Activated);
            this.Load += new System.EventHandler(this.frmORDSetupProductionPlan_Load);
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
            this.grpOrder.ResumeLayout(false);
            this.pnlGeneral.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpUpdateInfo.ResumeLayout(false);
            this.grpUpdateInfo.PerformLayout();
            this.pnlPlanStatus.ResumeLayout(false);
            this.grpPlanStatus.ResumeLayout(false);
            this.grpPlanStatus.PerformLayout();
            this.pnlPlan.ResumeLayout(false);
            this.grpGen.ResumeLayout(false);
            this.grpGen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.tbpCreate.ResumeLayout(false);
            this.grpCreate.ResumeLayout(false);
            this.grpCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).EndInit();
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

            if (cdvMaterial.CheckValue() == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":

                    if (MPCF.CheckValue(txtPlanQty1, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtQty1, 1) == false)
                    {
                        tabGeneral.SelectedTab = tbpCreate;
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCreateCode, 1) == false)
                    {
                        tabGeneral.SelectedTab = tbpCreate;
                        return false;
                    }
                    if (MPCF.CheckValue(cdvOwnerCode, 1) == false)
                    {
                        tabGeneral.SelectedTab = tbpCreate;
                        return false;
                    }
                    if (MPCF.CheckValue(cdvLotType, 1) == false)
                    {
                        tabGeneral.SelectedTab = tbpCreate;
                        return false;
                    }
                    if (MPCF.CheckValue(cboPriority, 1) == false)
                    {
                        tabGeneral.SelectedTab = tbpCreate;
                        return false;
                    }
                    if (chkDueDate.Checked == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabGeneral.SelectedTab = tbpCreate;
                        chkDueDate.Focus();
                        return false;
                    }
                    break;
                case "UPDATE":

                    if (MPCF.CheckValue(txtPlanQty1, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvResID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtQty1, 1) == false)
                    {
                        tabGeneral.SelectedTab = tbpCreate;
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCreateCode, 1) == false)
                    {
                        tabGeneral.SelectedTab = tbpCreate;
                        return false;
                    }
                    if (MPCF.CheckValue(cdvOwnerCode, 1) == false)
                    {
                        tabGeneral.SelectedTab = tbpCreate;
                        return false;
                    }
                    if (MPCF.CheckValue(cdvLotType, 1) == false)
                    {
                        tabGeneral.SelectedTab = tbpCreate;
                        return false;
                    }
                    if (MPCF.CheckValue(cboPriority, 1) == false)
                    {
                        tabGeneral.SelectedTab = tbpCreate;
                        return false;
                    }
                    if (chkDueDate.Checked == false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabGeneral.SelectedTab = tbpCreate;
                        chkDueDate.Focus();
                        return false;
                    }
                    break;
            }

            return true;

        }

        //
        // View_Plan()
        //       - View Production Plan
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool View_Plan()
        {
            TRSNode in_node = new TRSNode("View_Plan_In");
            TRSNode out_node = new TRSNode("View_Plan_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", MPCF.Trim(lisMaterial.SelectedItems[0].Text));
            in_node.AddInt("MAT_VER", MPCF.ToInt(lisMaterial.SelectedItems[0].SubItems[1].Text));
            in_node.AddString("WORK_DATE", MPCF.ToStandardTime(dtpDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));


            if (MPCR.CallService("ORD", "ORD_View_Plan", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvMaterial.Text = out_node.GetString("MAT_ID");
            cdvMaterial.Version = out_node.GetInt("MAT_VER");
            dtpWorkDate.Value = MPCF.ToDate(out_node.GetString("WORK_DATE") + "000000");
            cdvResID.Text = out_node.GetString("RES_ID");
            txtPlanQty1.Text = MPCF.Format("##,##0.###", out_node.GetDouble("PLAN_QTY"));
            txtCreateLotCount.Text = MPCF.Trim(out_node.GetInt("CREATE_LOT_COUNT"));

            txtCreateQty1.Text = MPCF.Format("##,##0.###", out_node.GetDouble("CREATE_LOT_QTY"));
            txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
            txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
            txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
            txtQty1.Text = MPCF.Format("##,##0.###", out_node.GetDouble("QTY"));
            cdvCreateCode.Text = out_node.GetString("CREATE_CODE");
            cdvOwnerCode.Text = out_node.GetString("OWNER_CODE");
            cdvLotType.Text = MPCF.Trim(out_node.GetChar("LOT_TYPE"));
            cboPriority.Text = MPCF.Trim(out_node.GetChar("LOT_PRIORITY"));

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

            return true;
        }

        // Update_Plan()
        //       - Create/Update/Delete Production Plan
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal c_step As String : ProcStep
        private bool Update_Plan(char c_step)
        {
            TRSNode in_node = new TRSNode("Update_Plan_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            ListViewItem itm;
            int idx;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("WORK_DATE", MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddDouble("PLAN_QTY", MPCF.ToDbl(txtPlanQty1.Text));
                in_node.AddDouble("QTY", MPCF.ToDbl(txtQty1.Text));
                in_node.AddString("CREATE_CODE", MPCF.Trim(cdvCreateCode.Text));
                in_node.AddString("OWNER_CODE", MPCF.Trim(cdvOwnerCode.Text));
                in_node.AddChar("LOT_TYPE", MPCF.ToChar(MPCF.Trim(cdvLotType.Text)));

                in_node.AddChar("LOT_PRIORITY", MPCF.ToChar(MPCF.Trim(cboPriority.Text)));


                if (chkDueDate.Checked == true)
                {
                    in_node.AddString("ORG_DUE_TIME", MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                }

                if (MPCR.CallService("ORD", "ORD_Update_Plan", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisMaterial.Items.Add(cdvMaterial.Text, (int)SMALLICON_INDEX.IDX_MATERIAL);
                        itm.SubItems.Add(cdvMaterial.Version.ToString());
                        itm.SubItems.Add(txtQty1.Text);
                        itm.Selected = true;
                        lisMaterial.Sorting = SortOrder.Ascending;
                        lisMaterial.Sort();
                        itm.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisMaterial, MPCF.Trim(cdvMaterial.Text), false) == true)
                        {
                            lisMaterial.SelectedItems[0].SubItems[2].Text = txtQty1.Text;
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisMaterial, MPCF.Trim(cdvMaterial.Text), false);
                        if (idx != -1)
                        {
                            lisMaterial.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisMaterial.Items.Count);
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
        // Refresh_MaterialList()
        //       - Refresh Material List
        // Return Value
        //       -
        // Arguments
        //        -
        private void Refresh_MaterialList()
        {
            if (ORDLIST.ViewPlanList(lisMaterial, '1', MPCF.ToStandardTime(dtpDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), null, "") == true)
            {
                lblDataCount.Text = MPCF.Trim(lisMaterial.Items.Count);
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

        
        private void frmORDSetupProductionPlan_Load(object sender, System.EventArgs e)
        {
        }
        
        private void frmORDSetupProductionPlan_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.InitListView(lisMaterial);
                if (ORDLIST.ViewPlanList(lisMaterial, '1', MPCF.ToStandardTime(dtpDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), null, "") == true)
                {
                    if (lisMaterial.Items.Count > 0)
                    {
                        lisMaterial.Items[0].Selected = true;
                        lblDataCount.Text = MPCF.Trim(lisMaterial.Items.Count);
                    }
                }
                
                b_load_flag = true;
            }
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisMaterial, this.Text, "");
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            Refresh_MaterialList();
            if (lisMaterial.Items.Count > 0)
            {
                lisMaterial.Items[0].Selected = true;
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
        private void chkDueDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            if (chkDueDate.Checked == true)
            {
                dtpDueDate.Value = System.DateTime.Now;
            }
            txtDueDate.Visible = ! chkDueDate.Checked;
            
        }
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("CREATE") == true)
            {
                if (Update_Plan(MPGC.MP_STEP_CREATE) == true)
                {
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        Refresh_MaterialList();
                        MPCF.FindListItem(lisMaterial, cdvMaterial.Text, false);
                    }
                }
            }
            
        }
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("UPDATE") == true)
            {
                if (Update_Plan(MPGC.MP_STEP_UPDATE) == true)
                {
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        Refresh_MaterialList();
                        MPCF.FindListItem(lisMaterial, cdvMaterial.Text, false);
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
            if (lisMaterial.SelectedItems.Count > 0)
            {
                iIdx = lisMaterial.SelectedItems[0].Index;
            }
            if (CheckCondition("DELETE") == true)
            {
                if (Update_Plan(MPGC.MP_STEP_DELETE) == true)
                {
                    MPCF.FieldClear(this.pnlRight);
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        Refresh_MaterialList();
                        if (iIdx < lisMaterial.Items.Count)
                        {
                            lisMaterial.Items[iIdx].Selected = true;
                        }
                    }
                }
            }
        }
        
        private void lisMaterial_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this.pnlRight);
            if (lisMaterial.SelectedItems.Count > 0)
            {
                cdvMaterial.Text = lisMaterial.SelectedItems[0].Text;
                View_Plan();
            }
        }
        
        private void dtpDate_CloseUp(object sender, System.EventArgs e)
        {
            Refresh_MaterialList();
            MPCF.FieldClear(this.pnlRight);
            if (lisMaterial.Items.Count > 0)
            {
                lisMaterial.Items[0].Selected = true;
            }
        }
        
        private void cdvMaterial_MaterialTextChanged(System.Object sender, System.EventArgs e)
        {
            chkDueDate.Checked = false;
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisMaterial, txtFind.Text, true, false);
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisMaterial, txtFind.Text, 0, true, false);
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
    }
    //#End If
}
