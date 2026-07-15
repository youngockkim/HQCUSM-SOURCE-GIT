
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
//   File Name   : frmORDSetupProductionOrder.vb
//   Description : Production Order Setup
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//       - CheckCondition()     : Check the conditions before transaction
//       - View_Order()         : View Order Information
//       - Update_Order()       : Create/Update/Delete Order Information
//       - GetMaterialList()    : Get Material List
//       - GetFlowList()        : Get Flow List
//       - GetCreateCodeList()  : Get Create Code List
//       - GetOwnerCodeList()   : Get Owner Code List
//       - GetLotTypeList()     : Get Lot Type List
//       - Refresh_Orderlist()  : Refresh Order List
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
    public class frmORDSetupProductionOrder : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmORDSetupProductionOrder()
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
        



        private System.Windows.Forms.Panel pnlDate;
        private Miracom.UI.Controls.MCListView.MCListView lisOrder;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.GroupBox grpOrder;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.TabControl tabGeneral;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.TabPage tbpCreate;
        private System.Windows.Forms.TabPage tbpStatus;
        private System.Windows.Forms.GroupBox grpCMF;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
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
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.CheckBox chkDueDate;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.Label lblCreateCode;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOwnerCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCode;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblOwnerCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLotType;
        private System.Windows.Forms.Label lblQty1;
        private System.Windows.Forms.Label lblLotType;
        private System.Windows.Forms.GroupBox grpCreate;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.ComboBox cboOrderStatus;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.CheckBox chkIncludeDeleteFlag;
        private System.Windows.Forms.Panel pnlOrderStatus;
        private System.Windows.Forms.Panel pnlGen;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblPlanEndTime;
        private System.Windows.Forms.Label lblPlanStartTime;
        private System.Windows.Forms.Label lblPlanDueTime;
        private System.Windows.Forms.Label lblOrderQty1;
        private System.Windows.Forms.TextBox txtCustomerMatID;
        private System.Windows.Forms.Label lblCustomerMatID;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblWorkDate;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.Label lblBOMSetVersion;
        private System.Windows.Forms.Label lblBOMSetID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.GroupBox grpUpdateInfo;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.GroupBox grpOrderStatus;
        private System.Windows.Forms.TextBox txtRwkQty1;
        private System.Windows.Forms.Label lblRwkQty1;
        private System.Windows.Forms.TextBox txtLossQty1;
        private System.Windows.Forms.Label lblLossQty1;
        private System.Windows.Forms.TextBox txtOutQty1;
        private System.Windows.Forms.Label lblOutQty1;
        private System.Windows.Forms.TextBox txtOrderInQty1;
        private System.Windows.Forms.Label lblInQty1;
        protected System.Windows.Forms.TextBox txtOrderEndTime;
        protected System.Windows.Forms.Label lblOrderEndTime;
        protected System.Windows.Forms.TextBox txtOrderStartTime;
        protected System.Windows.Forms.Label lblOrderStartTime;
        protected System.Windows.Forms.TextBox txtOrderShipFlag;
        protected System.Windows.Forms.Label lblOrderShipFlag;
        protected System.Windows.Forms.TextBox txtOrderStatus;
        protected System.Windows.Forms.Label lblOrderStatus;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvBOMSetID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvBOMSetVersion;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtOrderQty1;
        private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit txtPlanDueTime;
        private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit txtPlanEndTime;
        private Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit txtPlanStartTime;
        private ColumnHeader ColumnHeader3;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private Label lblOrderDesc;
        private TextBox txtOrderDesc;
        private ColumnHeader columnHeader5;
        private Infragistics.Win.UltraWinEditors.UltraNumericEditor txtQty1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlDate = new System.Windows.Forms.Panel();
            this.chkIncludeDeleteFlag = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lisOrder = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpOrder = new System.Windows.Forms.GroupBox();
            this.lblOrderDesc = new System.Windows.Forms.Label();
            this.txtOrderDesc = new System.Windows.Forms.TextBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.tabGeneral = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpUpdateInfo = new System.Windows.Forms.GroupBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.pnlGen = new System.Windows.Forms.Panel();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.txtOrderQty1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.cdvBOMSetVersion = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvBOMSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPlanEndTime = new System.Windows.Forms.Label();
            this.lblPlanStartTime = new System.Windows.Forms.Label();
            this.lblPlanDueTime = new System.Windows.Forms.Label();
            this.lblOrderQty1 = new System.Windows.Forms.Label();
            this.txtCustomerMatID = new System.Windows.Forms.TextBox();
            this.lblCustomerMatID = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lblBOMSetVersion = new System.Windows.Forms.Label();
            this.lblBOMSetID = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.txtPlanEndTime = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.txtPlanStartTime = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.txtPlanDueTime = new Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit();
            this.tbpCreate = new System.Windows.Forms.TabPage();
            this.grpCreate = new System.Windows.Forms.GroupBox();
            this.txtQty1 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.chkDueDate = new System.Windows.Forms.CheckBox();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.lblCreateCode = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.cdvOwnerCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblOwnerCode = new System.Windows.Forms.Label();
            this.cdvLotType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.lblLotType = new System.Windows.Forms.Label();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
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
            this.tbpStatus = new System.Windows.Forms.TabPage();
            this.pnlOrderStatus = new System.Windows.Forms.Panel();
            this.grpOrderStatus = new System.Windows.Forms.GroupBox();
            this.txtRwkQty1 = new System.Windows.Forms.TextBox();
            this.lblRwkQty1 = new System.Windows.Forms.Label();
            this.txtLossQty1 = new System.Windows.Forms.TextBox();
            this.lblLossQty1 = new System.Windows.Forms.Label();
            this.txtOutQty1 = new System.Windows.Forms.TextBox();
            this.lblOutQty1 = new System.Windows.Forms.Label();
            this.txtOrderInQty1 = new System.Windows.Forms.TextBox();
            this.lblInQty1 = new System.Windows.Forms.Label();
            this.txtOrderEndTime = new System.Windows.Forms.TextBox();
            this.lblOrderEndTime = new System.Windows.Forms.Label();
            this.txtOrderStartTime = new System.Windows.Forms.TextBox();
            this.lblOrderStartTime = new System.Windows.Forms.Label();
            this.txtOrderShipFlag = new System.Windows.Forms.TextBox();
            this.lblOrderShipFlag = new System.Windows.Forms.Label();
            this.txtOrderStatus = new System.Windows.Forms.TextBox();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.cboOrderStatus = new System.Windows.Forms.ComboBox();
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
            this.pnlGen.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderQty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBOMSetVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBOMSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.tbpCreate.SuspendLayout();
            this.grpCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).BeginInit();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            this.tbpStatus.SuspendLayout();
            this.pnlOrderStatus.SuspendLayout();
            this.grpOrderStatus.SuspendLayout();
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
            this.pnlLeft.Controls.Add(this.lisOrder);
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
            this.lblFormTitle.Text = "Order Setup";
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.chkIncludeDeleteFlag);
            this.pnlDate.Controls.Add(this.lblDate);
            this.pnlDate.Controls.Add(this.dtpDate);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDate.Location = new System.Drawing.Point(3, 0);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(229, 56);
            this.pnlDate.TabIndex = 0;
            // 
            // chkIncludeDeleteFlag
            // 
            this.chkIncludeDeleteFlag.AutoSize = true;
            this.chkIncludeDeleteFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDeleteFlag.Location = new System.Drawing.Point(16, 34);
            this.chkIncludeDeleteFlag.Name = "chkIncludeDeleteFlag";
            this.chkIncludeDeleteFlag.Size = new System.Drawing.Size(136, 18);
            this.chkIncludeDeleteFlag.TabIndex = 2;
            this.chkIncludeDeleteFlag.Text = "Include Deleted Order";
            this.chkIncludeDeleteFlag.CheckedChanged += new System.EventHandler(this.chkIncludeDeleteFlag_CheckedChanged);
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
            this.dtpDate.Location = new System.Drawing.Point(112, 9);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(90, 20);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.CloseUp += new System.EventHandler(this.dtpDate_CloseUp);
            // 
            // lisOrder
            // 
            this.lisOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.columnHeader5});
            this.lisOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisOrder.EnableSort = true;
            this.lisOrder.EnableSortIcon = true;
            this.lisOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisOrder.FullRowSelect = true;
            this.lisOrder.Location = new System.Drawing.Point(3, 56);
            this.lisOrder.MultiSelect = false;
            this.lisOrder.Name = "lisOrder";
            this.lisOrder.Size = new System.Drawing.Size(229, 454);
            this.lisOrder.TabIndex = 1;
            this.lisOrder.UseCompatibleStateImageBehavior = false;
            this.lisOrder.View = System.Windows.Forms.View.Details;
            this.lisOrder.SelectedIndexChanged += new System.EventHandler(this.lisOrder_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Order ID";
            this.ColumnHeader1.Width = 80;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Mat ID";
            this.ColumnHeader2.Width = 100;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Mat Ver";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Qty";
            this.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Description";
            this.columnHeader5.Width = 100;
            // 
            // grpOrder
            // 
            this.grpOrder.Controls.Add(this.lblOrderDesc);
            this.grpOrder.Controls.Add(this.txtOrderDesc);
            this.grpOrder.Controls.Add(this.lblOrder);
            this.grpOrder.Controls.Add(this.txtOrder);
            this.grpOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOrder.Location = new System.Drawing.Point(3, 0);
            this.grpOrder.Name = "grpOrder";
            this.grpOrder.Size = new System.Drawing.Size(500, 68);
            this.grpOrder.TabIndex = 0;
            this.grpOrder.TabStop = false;
            // 
            // lblOrderDesc
            // 
            this.lblOrderDesc.AutoSize = true;
            this.lblOrderDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDesc.Location = new System.Drawing.Point(15, 43);
            this.lblOrderDesc.Name = "lblOrderDesc";
            this.lblOrderDesc.Size = new System.Drawing.Size(60, 13);
            this.lblOrderDesc.TabIndex = 2;
            this.lblOrderDesc.Text = "Description";
            this.lblOrderDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderDesc
            // 
            this.txtOrderDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderDesc.Location = new System.Drawing.Point(111, 40);
            this.txtOrderDesc.MaxLength = 200;
            this.txtOrderDesc.Name = "txtOrderDesc";
            this.txtOrderDesc.Size = new System.Drawing.Size(377, 20);
            this.txtOrderDesc.TabIndex = 3;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.Location = new System.Drawing.Point(15, 19);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(55, 13);
            this.lblOrder.TabIndex = 0;
            this.lblOrder.Text = "Order ID";
            this.lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(111, 16);
            this.txtOrder.MaxLength = 25;
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(133, 20);
            this.txtOrder.TabIndex = 1;
            this.txtOrder.TextChanged += new System.EventHandler(this.txtOrder_TextChanged);
            this.txtOrder.LostFocus += new System.EventHandler(this.txtOrder_LostFocus);
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.tabGeneral);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(3, 68);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlGeneral.Size = new System.Drawing.Size(500, 442);
            this.pnlGeneral.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tbpGeneral);
            this.tabGeneral.Controls.Add(this.tbpCreate);
            this.tabGeneral.Controls.Add(this.tbpCMF);
            this.tabGeneral.Controls.Add(this.tbpStatus);
            this.tabGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneral.ItemSize = new System.Drawing.Size(60, 18);
            this.tabGeneral.Location = new System.Drawing.Point(0, 5);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.SelectedIndex = 0;
            this.tabGeneral.Size = new System.Drawing.Size(500, 437);
            this.tabGeneral.TabIndex = 1;
            this.tabGeneral.TabStop = false;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpUpdateInfo);
            this.tbpGeneral.Controls.Add(this.pnlGen);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 411);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
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
            this.grpUpdateInfo.Location = new System.Drawing.Point(3, 193);
            this.grpUpdateInfo.Name = "grpUpdateInfo";
            this.grpUpdateInfo.Size = new System.Drawing.Size(486, 215);
            this.grpUpdateInfo.TabIndex = 1;
            this.grpUpdateInfo.TabStop = false;
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(244, 43);
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
            this.lblUpdateUser.Location = new System.Drawing.Point(244, 19);
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
            this.lblCreateTime.Location = new System.Drawing.Point(15, 43);
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
            this.lblCreateUser.Location = new System.Drawing.Point(15, 19);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 0;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(348, 40);
            this.txtUpdateTime.MaxLength = 20;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(133, 20);
            this.txtUpdateTime.TabIndex = 7;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(104, 40);
            this.txtCreateTime.MaxLength = 20;
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
            // pnlGen
            // 
            this.pnlGen.Controls.Add(this.grpGeneral);
            this.pnlGen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGen.Location = new System.Drawing.Point(3, 5);
            this.pnlGen.Name = "pnlGen";
            this.pnlGen.Size = new System.Drawing.Size(486, 188);
            this.pnlGen.TabIndex = 0;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.cdvFlow);
            this.grpGeneral.Controls.Add(this.cdvMaterial);
            this.grpGeneral.Controls.Add(this.txtOrderQty1);
            this.grpGeneral.Controls.Add(this.cdvBOMSetVersion);
            this.grpGeneral.Controls.Add(this.cdvBOMSetID);
            this.grpGeneral.Controls.Add(this.lblPlanEndTime);
            this.grpGeneral.Controls.Add(this.lblPlanStartTime);
            this.grpGeneral.Controls.Add(this.lblPlanDueTime);
            this.grpGeneral.Controls.Add(this.lblOrderQty1);
            this.grpGeneral.Controls.Add(this.txtCustomerMatID);
            this.grpGeneral.Controls.Add(this.lblCustomerMatID);
            this.grpGeneral.Controls.Add(this.txtCustomerID);
            this.grpGeneral.Controls.Add(this.lblCustomer);
            this.grpGeneral.Controls.Add(this.lblWorkDate);
            this.grpGeneral.Controls.Add(this.dtpWorkDate);
            this.grpGeneral.Controls.Add(this.lblBOMSetVersion);
            this.grpGeneral.Controls.Add(this.lblBOMSetID);
            this.grpGeneral.Controls.Add(this.cdvResID);
            this.grpGeneral.Controls.Add(this.lblResID);
            this.grpGeneral.Controls.Add(this.txtPlanEndTime);
            this.grpGeneral.Controls.Add(this.txtPlanStartTime);
            this.grpGeneral.Controls.Add(this.txtPlanDueTime);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(0, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(486, 188);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
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
            this.cdvFlow.LabelWidth = 89;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(15, 63);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(222, 20);
            this.cdvFlow.TabIndex = 3;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 133;
            this.cdvFlow.WidthSequence = 45;
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
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
            this.cdvMaterial.Location = new System.Drawing.Point(15, 39);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(222, 20);
            this.cdvMaterial.TabIndex = 2;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 89;
            this.cdvMaterial.WidthMaterialAndVersion = 133;
            this.cdvMaterial.WidthVersion = 45;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_VersionSelectedItemChanged);
            this.cdvMaterial.MaterialTextChanged += new System.EventHandler(this.cdvMaterial_MaterialTextBoxTextChanged);
            // 
            // txtOrderQty1
            // 
            this.txtOrderQty1.Location = new System.Drawing.Point(104, 112);
            this.txtOrderQty1.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtOrderQty1.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtOrderQty1.MaskInput = "nnnnnnn.nnn";
            this.txtOrderQty1.Name = "txtOrderQty1";
            this.txtOrderQty1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtOrderQty1.PromptChar = ' ';
            this.txtOrderQty1.Size = new System.Drawing.Size(133, 20);
            this.txtOrderQty1.TabIndex = 7;
            // 
            // cdvBOMSetVersion
            // 
            this.cdvBOMSetVersion.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBOMSetVersion.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBOMSetVersion.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvBOMSetVersion.BtnToolTipText = "";
            this.cdvBOMSetVersion.DescText = "";
            this.cdvBOMSetVersion.DisplaySubItemIndex = -1;
            this.cdvBOMSetVersion.DisplayText = "";
            this.cdvBOMSetVersion.Focusing = null;
            this.cdvBOMSetVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvBOMSetVersion.Index = 0;
            this.cdvBOMSetVersion.IsViewBtnImage = false;
            this.cdvBOMSetVersion.Location = new System.Drawing.Point(348, 40);
            this.cdvBOMSetVersion.MaxLength = 3;
            this.cdvBOMSetVersion.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvBOMSetVersion.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvBOMSetVersion.Name = "cdvBOMSetVersion";
            this.cdvBOMSetVersion.ReadOnly = false;
            this.cdvBOMSetVersion.SearchSubItemIndex = 0;
            this.cdvBOMSetVersion.SelectedDescIndex = -1;
            this.cdvBOMSetVersion.SelectedSubItemIndex = -1;
            this.cdvBOMSetVersion.SelectionStart = 0;
            this.cdvBOMSetVersion.Size = new System.Drawing.Size(133, 20);
            this.cdvBOMSetVersion.SmallImageList = null;
            this.cdvBOMSetVersion.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvBOMSetVersion.TabIndex = 13;
            this.cdvBOMSetVersion.TextBoxToolTipText = "";
            this.cdvBOMSetVersion.TextBoxWidth = 133;
            this.cdvBOMSetVersion.VisibleButton = true;
            this.cdvBOMSetVersion.VisibleColumnHeader = false;
            this.cdvBOMSetVersion.VisibleDescription = false;
            this.cdvBOMSetVersion.ButtonPress += new System.EventHandler(this.cdvBOMSetVersion_ButtonPress);
            // 
            // cdvBOMSetID
            // 
            this.cdvBOMSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBOMSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBOMSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvBOMSetID.BtnToolTipText = "";
            this.cdvBOMSetID.DescText = "";
            this.cdvBOMSetID.DisplaySubItemIndex = -1;
            this.cdvBOMSetID.DisplayText = "";
            this.cdvBOMSetID.Focusing = null;
            this.cdvBOMSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvBOMSetID.Index = 0;
            this.cdvBOMSetID.IsViewBtnImage = false;
            this.cdvBOMSetID.Location = new System.Drawing.Point(348, 16);
            this.cdvBOMSetID.MaxLength = 25;
            this.cdvBOMSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvBOMSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvBOMSetID.Name = "cdvBOMSetID";
            this.cdvBOMSetID.ReadOnly = false;
            this.cdvBOMSetID.SearchSubItemIndex = 0;
            this.cdvBOMSetID.SelectedDescIndex = -1;
            this.cdvBOMSetID.SelectedSubItemIndex = -1;
            this.cdvBOMSetID.SelectionStart = 0;
            this.cdvBOMSetID.Size = new System.Drawing.Size(133, 20);
            this.cdvBOMSetID.SmallImageList = null;
            this.cdvBOMSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvBOMSetID.TabIndex = 11;
            this.cdvBOMSetID.TextBoxToolTipText = "";
            this.cdvBOMSetID.TextBoxWidth = 133;
            this.cdvBOMSetID.VisibleButton = true;
            this.cdvBOMSetID.VisibleColumnHeader = false;
            this.cdvBOMSetID.VisibleDescription = false;
            this.cdvBOMSetID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvBOMSetID_SelectedItemChanged);
            this.cdvBOMSetID.ButtonPress += new System.EventHandler(this.cdvBOMSetID_ButtonPress);
            this.cdvBOMSetID.TextBoxTextChanged += new System.EventHandler(this.cdvBOMSetID_TextBoxTextChanged);
            // 
            // lblPlanEndTime
            // 
            this.lblPlanEndTime.AutoSize = true;
            this.lblPlanEndTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPlanEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanEndTime.Location = new System.Drawing.Point(244, 115);
            this.lblPlanEndTime.Name = "lblPlanEndTime";
            this.lblPlanEndTime.Size = new System.Drawing.Size(76, 13);
            this.lblPlanEndTime.TabIndex = 18;
            this.lblPlanEndTime.Text = "Plan End Time";
            this.lblPlanEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlanStartTime
            // 
            this.lblPlanStartTime.AutoSize = true;
            this.lblPlanStartTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPlanStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanStartTime.Location = new System.Drawing.Point(244, 91);
            this.lblPlanStartTime.Name = "lblPlanStartTime";
            this.lblPlanStartTime.Size = new System.Drawing.Size(79, 13);
            this.lblPlanStartTime.TabIndex = 16;
            this.lblPlanStartTime.Text = "Plan Start Time";
            this.lblPlanStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlanDueTime
            // 
            this.lblPlanDueTime.AutoSize = true;
            this.lblPlanDueTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPlanDueTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanDueTime.Location = new System.Drawing.Point(244, 67);
            this.lblPlanDueTime.Name = "lblPlanDueTime";
            this.lblPlanDueTime.Size = new System.Drawing.Size(77, 13);
            this.lblPlanDueTime.TabIndex = 14;
            this.lblPlanDueTime.Text = "Plan Due Time";
            this.lblPlanDueTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderQty1
            // 
            this.lblOrderQty1.AutoSize = true;
            this.lblOrderQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderQty1.Location = new System.Drawing.Point(15, 115);
            this.lblOrderQty1.Name = "lblOrderQty1";
            this.lblOrderQty1.Size = new System.Drawing.Size(61, 13);
            this.lblOrderQty1.TabIndex = 6;
            this.lblOrderQty1.Text = "Order Qty";
            this.lblOrderQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomerMatID
            // 
            this.txtCustomerMatID.Location = new System.Drawing.Point(348, 136);
            this.txtCustomerMatID.MaxLength = 30;
            this.txtCustomerMatID.Name = "txtCustomerMatID";
            this.txtCustomerMatID.Size = new System.Drawing.Size(133, 20);
            this.txtCustomerMatID.TabIndex = 21;
            // 
            // lblCustomerMatID
            // 
            this.lblCustomerMatID.AutoSize = true;
            this.lblCustomerMatID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCustomerMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerMatID.Location = new System.Drawing.Point(244, 139);
            this.lblCustomerMatID.Name = "lblCustomerMatID";
            this.lblCustomerMatID.Size = new System.Drawing.Size(86, 13);
            this.lblCustomerMatID.TabIndex = 20;
            this.lblCustomerMatID.Text = "Customer Mat ID";
            this.lblCustomerMatID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(104, 136);
            this.txtCustomerID.MaxLength = 20;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(133, 20);
            this.txtCustomerID.TabIndex = 9;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(15, 139);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(65, 13);
            this.lblCustomer.TabIndex = 8;
            this.lblCustomer.Text = "Customer ID";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dtpWorkDate.Location = new System.Drawing.Point(104, 16);
            this.dtpWorkDate.Name = "dtpWorkDate";
            this.dtpWorkDate.Size = new System.Drawing.Size(133, 20);
            this.dtpWorkDate.TabIndex = 1;
            // 
            // lblBOMSetVersion
            // 
            this.lblBOMSetVersion.AutoSize = true;
            this.lblBOMSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSetVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOMSetVersion.Location = new System.Drawing.Point(244, 43);
            this.lblBOMSetVersion.Name = "lblBOMSetVersion";
            this.lblBOMSetVersion.Size = new System.Drawing.Size(88, 13);
            this.lblBOMSetVersion.TabIndex = 12;
            this.lblBOMSetVersion.Text = "BOM Set Version";
            this.lblBOMSetVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBOMSetID
            // 
            this.lblBOMSetID.AutoSize = true;
            this.lblBOMSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOMSetID.Location = new System.Drawing.Point(244, 19);
            this.lblBOMSetID.Name = "lblBOMSetID";
            this.lblBOMSetID.Size = new System.Drawing.Size(64, 13);
            this.lblBOMSetID.TabIndex = 10;
            this.lblBOMSetID.Text = "BOM Set ID";
            this.lblBOMSetID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvResID.Location = new System.Drawing.Point(104, 88);
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
            this.cdvResID.TabIndex = 5;
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
            this.lblResID.Location = new System.Drawing.Point(15, 91);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(53, 13);
            this.lblResID.TabIndex = 4;
            this.lblResID.Text = "Resource";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPlanEndTime
            // 
            this.txtPlanEndTime.ClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPlanEndTime.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPlanEndTime.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPlanEndTime.InputMask = "yyyy/mm/dd hh:mm:ss";
            this.txtPlanEndTime.Location = new System.Drawing.Point(348, 112);
            this.txtPlanEndTime.Name = "txtPlanEndTime";
            this.txtPlanEndTime.Size = new System.Drawing.Size(133, 20);
            this.txtPlanEndTime.TabIndex = 19;
            // 
            // txtPlanStartTime
            // 
            this.txtPlanStartTime.ClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPlanStartTime.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPlanStartTime.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPlanStartTime.InputMask = "yyyy/mm/dd hh:mm:ss";
            this.txtPlanStartTime.Location = new System.Drawing.Point(348, 88);
            this.txtPlanStartTime.Name = "txtPlanStartTime";
            this.txtPlanStartTime.Size = new System.Drawing.Size(133, 20);
            this.txtPlanStartTime.TabIndex = 17;
            // 
            // txtPlanDueTime
            // 
            this.txtPlanDueTime.ClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPlanDueTime.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtPlanDueTime.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.txtPlanDueTime.InputMask = "yyyy/mm/dd hh:mm:ss";
            this.txtPlanDueTime.Location = new System.Drawing.Point(348, 64);
            this.txtPlanDueTime.Name = "txtPlanDueTime";
            this.txtPlanDueTime.Size = new System.Drawing.Size(133, 20);
            this.txtPlanDueTime.TabIndex = 15;
            // 
            // tbpCreate
            // 
            this.tbpCreate.Controls.Add(this.grpCreate);
            this.tbpCreate.Location = new System.Drawing.Point(4, 22);
            this.tbpCreate.Name = "tbpCreate";
            this.tbpCreate.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCreate.Size = new System.Drawing.Size(492, 411);
            this.tbpCreate.TabIndex = 2;
            this.tbpCreate.Text = "Create Info";
            // 
            // grpCreate
            // 
            this.grpCreate.Controls.Add(this.txtQty1);
            this.grpCreate.Controls.Add(this.txtDueDate);
            this.grpCreate.Controls.Add(this.chkDueDate);
            this.grpCreate.Controls.Add(this.cboPriority);
            this.grpCreate.Controls.Add(this.lblCreateCode);
            this.grpCreate.Controls.Add(this.dtpDueDate);
            this.grpCreate.Controls.Add(this.cdvOwnerCode);
            this.grpCreate.Controls.Add(this.cdvCreateCode);
            this.grpCreate.Controls.Add(this.lblPriority);
            this.grpCreate.Controls.Add(this.lblOwnerCode);
            this.grpCreate.Controls.Add(this.cdvLotType);
            this.grpCreate.Controls.Add(this.lblQty1);
            this.grpCreate.Controls.Add(this.lblLotType);
            this.grpCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreate.Location = new System.Drawing.Point(3, 0);
            this.grpCreate.Name = "grpCreate";
            this.grpCreate.Size = new System.Drawing.Size(486, 408);
            this.grpCreate.TabIndex = 0;
            this.grpCreate.TabStop = false;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(100, 16);
            this.txtQty1.MaskClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtQty1.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.txtQty1.MaskInput = "nnnnnnn.nnn";
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtQty1.PromptChar = ' ';
            this.txtQty1.Size = new System.Drawing.Size(133, 20);
            this.txtQty1.TabIndex = 1;
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(100, 64);
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
            this.chkDueDate.Location = new System.Drawing.Point(12, 66);
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
            this.cboPriority.Location = new System.Drawing.Point(344, 64);
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
            this.lblCreateCode.Location = new System.Drawing.Point(245, 19);
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
            this.dtpDueDate.Location = new System.Drawing.Point(100, 64);
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
            this.cdvOwnerCode.Location = new System.Drawing.Point(344, 40);
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
            this.cdvCreateCode.Location = new System.Drawing.Point(344, 16);
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
            this.lblPriority.Location = new System.Drawing.Point(245, 67);
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
            this.lblOwnerCode.Location = new System.Drawing.Point(245, 43);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(76, 13);
            this.lblOwnerCode.TabIndex = 9;
            this.lblOwnerCode.Text = "Owner Code";
            this.lblOwnerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvLotType.Location = new System.Drawing.Point(100, 40);
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
            this.lblLotType.Location = new System.Drawing.Point(12, 43);
            this.lblLotType.Name = "lblLotType";
            this.lblLotType.Size = new System.Drawing.Size(57, 13);
            this.lblLotType.TabIndex = 2;
            this.lblLotType.Text = "Lot Type";
            this.lblLotType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpCMF.Size = new System.Drawing.Size(492, 411);
            this.tbpCMF.TabIndex = 1;
            this.tbpCMF.Text = "Customized Field";
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.cdvCMF10);
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF5);
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
            this.grpCMF.Location = new System.Drawing.Point(3, 5);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(486, 403);
            this.grpCMF.TabIndex = 0;
            this.grpCMF.TabStop = false;
            this.grpCMF.Text = "Customized Field (1~10)";
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 0;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(172, 232);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
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
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 0;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(172, 208);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
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
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 0;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(172, 184);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
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
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 0;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(172, 160);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
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
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 0;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(172, 136);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
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
            // cdvCMF5
            // 
            this.cdvCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 0;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(172, 112);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
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
            // cdvCMF4
            // 
            this.cdvCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 0;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(172, 88);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
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
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 0;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(172, 64);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
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
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 0;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(172, 40);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
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
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
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
            this.lblCMF10.Location = new System.Drawing.Point(15, 235);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(150, 14);
            this.lblCMF10.TabIndex = 18;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(15, 211);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(150, 14);
            this.lblCMF9.TabIndex = 16;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(15, 187);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(150, 14);
            this.lblCMF8.TabIndex = 14;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(15, 163);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(150, 14);
            this.lblCMF7.TabIndex = 12;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(15, 139);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(150, 14);
            this.lblCMF6.TabIndex = 10;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(15, 115);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(150, 14);
            this.lblCMF5.TabIndex = 8;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(15, 91);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(150, 14);
            this.lblCMF4.TabIndex = 6;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(15, 67);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(150, 14);
            this.lblCMF3.TabIndex = 4;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(15, 43);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(150, 14);
            this.lblCMF2.TabIndex = 2;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(15, 19);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(150, 14);
            this.lblCMF1.TabIndex = 0;
            // 
            // tbpStatus
            // 
            this.tbpStatus.Controls.Add(this.pnlOrderStatus);
            this.tbpStatus.Location = new System.Drawing.Point(4, 22);
            this.tbpStatus.Name = "tbpStatus";
            this.tbpStatus.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpStatus.Size = new System.Drawing.Size(492, 411);
            this.tbpStatus.TabIndex = 3;
            this.tbpStatus.Text = "Order Status";
            // 
            // pnlOrderStatus
            // 
            this.pnlOrderStatus.Controls.Add(this.grpOrderStatus);
            this.pnlOrderStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrderStatus.Location = new System.Drawing.Point(3, 0);
            this.pnlOrderStatus.Name = "pnlOrderStatus";
            this.pnlOrderStatus.Size = new System.Drawing.Size(486, 408);
            this.pnlOrderStatus.TabIndex = 0;
            // 
            // grpOrderStatus
            // 
            this.grpOrderStatus.Controls.Add(this.txtRwkQty1);
            this.grpOrderStatus.Controls.Add(this.lblRwkQty1);
            this.grpOrderStatus.Controls.Add(this.txtLossQty1);
            this.grpOrderStatus.Controls.Add(this.lblLossQty1);
            this.grpOrderStatus.Controls.Add(this.txtOutQty1);
            this.grpOrderStatus.Controls.Add(this.lblOutQty1);
            this.grpOrderStatus.Controls.Add(this.txtOrderInQty1);
            this.grpOrderStatus.Controls.Add(this.lblInQty1);
            this.grpOrderStatus.Controls.Add(this.txtOrderEndTime);
            this.grpOrderStatus.Controls.Add(this.lblOrderEndTime);
            this.grpOrderStatus.Controls.Add(this.txtOrderStartTime);
            this.grpOrderStatus.Controls.Add(this.lblOrderStartTime);
            this.grpOrderStatus.Controls.Add(this.txtOrderShipFlag);
            this.grpOrderStatus.Controls.Add(this.lblOrderShipFlag);
            this.grpOrderStatus.Controls.Add(this.txtOrderStatus);
            this.grpOrderStatus.Controls.Add(this.lblOrderStatus);
            this.grpOrderStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOrderStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOrderStatus.Location = new System.Drawing.Point(0, 0);
            this.grpOrderStatus.Name = "grpOrderStatus";
            this.grpOrderStatus.Size = new System.Drawing.Size(486, 408);
            this.grpOrderStatus.TabIndex = 0;
            this.grpOrderStatus.TabStop = false;
            // 
            // txtRwkQty1
            // 
            this.txtRwkQty1.Location = new System.Drawing.Point(238, 184);
            this.txtRwkQty1.MaxLength = 11;
            this.txtRwkQty1.Name = "txtRwkQty1";
            this.txtRwkQty1.ReadOnly = true;
            this.txtRwkQty1.Size = new System.Drawing.Size(133, 20);
            this.txtRwkQty1.TabIndex = 15;
            this.txtRwkQty1.TabStop = false;
            this.txtRwkQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRwkQty1
            // 
            this.lblRwkQty1.AutoSize = true;
            this.lblRwkQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRwkQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRwkQty1.Location = new System.Drawing.Point(116, 187);
            this.lblRwkQty1.Name = "lblRwkQty1";
            this.lblRwkQty1.Size = new System.Drawing.Size(77, 13);
            this.lblRwkQty1.TabIndex = 14;
            this.lblRwkQty1.Text = "Order Rwk Qty";
            this.lblRwkQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLossQty1
            // 
            this.txtLossQty1.Location = new System.Drawing.Point(238, 136);
            this.txtLossQty1.MaxLength = 11;
            this.txtLossQty1.Name = "txtLossQty1";
            this.txtLossQty1.ReadOnly = true;
            this.txtLossQty1.Size = new System.Drawing.Size(133, 20);
            this.txtLossQty1.TabIndex = 11;
            this.txtLossQty1.TabStop = false;
            this.txtLossQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLossQty1
            // 
            this.lblLossQty1.AutoSize = true;
            this.lblLossQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLossQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLossQty1.Location = new System.Drawing.Point(116, 139);
            this.lblLossQty1.Name = "lblLossQty1";
            this.lblLossQty1.Size = new System.Drawing.Size(77, 13);
            this.lblLossQty1.TabIndex = 10;
            this.lblLossQty1.Text = "Order Loss Qty";
            this.lblLossQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOutQty1
            // 
            this.txtOutQty1.Location = new System.Drawing.Point(238, 160);
            this.txtOutQty1.MaxLength = 11;
            this.txtOutQty1.Name = "txtOutQty1";
            this.txtOutQty1.ReadOnly = true;
            this.txtOutQty1.Size = new System.Drawing.Size(133, 20);
            this.txtOutQty1.TabIndex = 13;
            this.txtOutQty1.TabStop = false;
            this.txtOutQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblOutQty1
            // 
            this.lblOutQty1.AutoSize = true;
            this.lblOutQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutQty1.Location = new System.Drawing.Point(116, 163);
            this.lblOutQty1.Name = "lblOutQty1";
            this.lblOutQty1.Size = new System.Drawing.Size(72, 13);
            this.lblOutQty1.TabIndex = 12;
            this.lblOutQty1.Text = "Order Out Qty";
            this.lblOutQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderInQty1
            // 
            this.txtOrderInQty1.Location = new System.Drawing.Point(238, 112);
            this.txtOrderInQty1.MaxLength = 11;
            this.txtOrderInQty1.Name = "txtOrderInQty1";
            this.txtOrderInQty1.ReadOnly = true;
            this.txtOrderInQty1.Size = new System.Drawing.Size(133, 20);
            this.txtOrderInQty1.TabIndex = 9;
            this.txtOrderInQty1.TabStop = false;
            this.txtOrderInQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInQty1
            // 
            this.lblInQty1.AutoSize = true;
            this.lblInQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInQty1.Location = new System.Drawing.Point(116, 115);
            this.lblInQty1.Name = "lblInQty1";
            this.lblInQty1.Size = new System.Drawing.Size(64, 13);
            this.lblInQty1.TabIndex = 8;
            this.lblInQty1.Text = "Order In Qty";
            this.lblInQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderEndTime
            // 
            this.txtOrderEndTime.Location = new System.Drawing.Point(238, 88);
            this.txtOrderEndTime.MaxLength = 30;
            this.txtOrderEndTime.Name = "txtOrderEndTime";
            this.txtOrderEndTime.ReadOnly = true;
            this.txtOrderEndTime.Size = new System.Drawing.Size(133, 20);
            this.txtOrderEndTime.TabIndex = 7;
            this.txtOrderEndTime.TabStop = false;
            // 
            // lblOrderEndTime
            // 
            this.lblOrderEndTime.AutoSize = true;
            this.lblOrderEndTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderEndTime.Location = new System.Drawing.Point(116, 91);
            this.lblOrderEndTime.Name = "lblOrderEndTime";
            this.lblOrderEndTime.Size = new System.Drawing.Size(81, 13);
            this.lblOrderEndTime.TabIndex = 6;
            this.lblOrderEndTime.Text = "Order End Time";
            this.lblOrderEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderStartTime
            // 
            this.txtOrderStartTime.Location = new System.Drawing.Point(238, 64);
            this.txtOrderStartTime.MaxLength = 30;
            this.txtOrderStartTime.Name = "txtOrderStartTime";
            this.txtOrderStartTime.ReadOnly = true;
            this.txtOrderStartTime.Size = new System.Drawing.Size(133, 20);
            this.txtOrderStartTime.TabIndex = 5;
            this.txtOrderStartTime.TabStop = false;
            // 
            // lblOrderStartTime
            // 
            this.lblOrderStartTime.AutoSize = true;
            this.lblOrderStartTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderStartTime.Location = new System.Drawing.Point(116, 67);
            this.lblOrderStartTime.Name = "lblOrderStartTime";
            this.lblOrderStartTime.Size = new System.Drawing.Size(84, 13);
            this.lblOrderStartTime.TabIndex = 4;
            this.lblOrderStartTime.Text = "Order Start Time";
            this.lblOrderStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderShipFlag
            // 
            this.txtOrderShipFlag.Location = new System.Drawing.Point(238, 40);
            this.txtOrderShipFlag.MaxLength = 1;
            this.txtOrderShipFlag.Name = "txtOrderShipFlag";
            this.txtOrderShipFlag.ReadOnly = true;
            this.txtOrderShipFlag.Size = new System.Drawing.Size(133, 20);
            this.txtOrderShipFlag.TabIndex = 3;
            this.txtOrderShipFlag.TabStop = false;
            // 
            // lblOrderShipFlag
            // 
            this.lblOrderShipFlag.AutoSize = true;
            this.lblOrderShipFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderShipFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderShipFlag.Location = new System.Drawing.Point(116, 43);
            this.lblOrderShipFlag.Name = "lblOrderShipFlag";
            this.lblOrderShipFlag.Size = new System.Drawing.Size(80, 13);
            this.lblOrderShipFlag.TabIndex = 2;
            this.lblOrderShipFlag.Text = "Order Ship Flag";
            this.lblOrderShipFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderStatus
            // 
            this.txtOrderStatus.Location = new System.Drawing.Point(238, 16);
            this.txtOrderStatus.MaxLength = 1;
            this.txtOrderStatus.Name = "txtOrderStatus";
            this.txtOrderStatus.ReadOnly = true;
            this.txtOrderStatus.Size = new System.Drawing.Size(133, 20);
            this.txtOrderStatus.TabIndex = 1;
            this.txtOrderStatus.TabStop = false;
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderStatus.Location = new System.Drawing.Point(116, 19);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(89, 13);
            this.lblOrderStatus.TabIndex = 0;
            this.lblOrderStatus.Text = "Order Status Flag";
            this.lblOrderStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboOrderStatus
            // 
            this.cboOrderStatus.Location = new System.Drawing.Point(134, 29);
            this.cboOrderStatus.Name = "cboOrderStatus";
            this.cboOrderStatus.Size = new System.Drawing.Size(145, 20);
            this.cboOrderStatus.TabIndex = 60;
            // 
            // frmORDSetupProductionOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmORDSetupProductionOrder";
            this.Text = "Production Order Setup";
            this.Activated += new System.EventHandler(this.frmORDSetupProductionOrder_Activated);
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
            this.grpOrder.PerformLayout();
            this.pnlGeneral.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpUpdateInfo.ResumeLayout(false);
            this.grpUpdateInfo.PerformLayout();
            this.pnlGen.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrderQty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBOMSetVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBOMSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.tbpCreate.ResumeLayout(false);
            this.grpCreate.ResumeLayout(false);
            this.grpCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).EndInit();
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            this.tbpStatus.ResumeLayout(false);
            this.pnlOrderStatus.ResumeLayout(false);
            this.grpOrderStatus.ResumeLayout(false);
            this.grpOrderStatus.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        private bool b_load_flag = false;
        
        #region " Function Definition "
        //
        // View_Order()
        //       - View Order
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool View_Order()
        {

            TRSNode in_node = new TRSNode("VIEW_ORDER_IN");
            TRSNode out_node = new TRSNode("VIEW_ORDER_OUT");

            MPCF.FieldClear(this.pnlRight);
            dtpWorkDate.Value = DateTime.Now;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ORDER_ID", MPCF.Trim(lisOrder.SelectedItems[0].Text));

            if (MPCR.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
            {
                return false;
            }

            txtOrder.Text = MPCF.Trim(out_node.GetString("ORDER_ID"));
            txtOrderDesc.Text = MPCF.Trim(out_node.GetString("ORDER_DESC"));
            dtpWorkDate.Value = MPCF.ToDate(out_node.GetString("WORK_DATE") + "000000");
            cdvMaterial.Text = MPCF.Trim(out_node.GetString("MAT_ID"));
            cdvMaterial.Version = out_node.GetInt("MAT_VER");
            cdvFlow.Text = MPCF.Trim(out_node.GetString("FLOW"));
            cdvFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
            cdvResID.Text = MPCF.Trim(out_node.GetString("RES_ID"));
            txtPlanDueTime.Text = MPCF.Trim(out_node.GetString("PLAN_DUE_TIME"));
            txtPlanStartTime.Text = MPCF.Trim(out_node.GetString("PLAN_START_TIME"));
            txtPlanEndTime.Text = MPCF.Trim(out_node.GetString("PLAN_END_TIME"));

            txtOrderQty1.Text = MPCF.Format("##,##0.###", out_node.GetDouble("ORD_QTY"));
            cdvBOMSetID.Text = MPCF.Trim(out_node.GetString("BOM_SET_ID"));

            txtCustomerID.Text = MPCF.Trim(out_node.GetString("CUSTOMER_ID"));
            txtCustomerMatID.Text = MPCF.Trim(out_node.GetString("CUSTOMER_MAT_ID"));
            txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
            txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
            txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
            cdvBOMSetVersion.Text = MPCF.Trim(out_node.GetInt("BOM_SET_VERSION"));
            cdvCMF1.Text = MPCF.Trim(out_node.GetString("ORD_CMF_1"));
            cdvCMF2.Text = MPCF.Trim(out_node.GetString("ORD_CMF_2"));
            cdvCMF3.Text = MPCF.Trim(out_node.GetString("ORD_CMF_3"));
            cdvCMF4.Text = MPCF.Trim(out_node.GetString("ORD_CMF_4"));
            cdvCMF5.Text = MPCF.Trim(out_node.GetString("ORD_CMF_5"));
            cdvCMF6.Text = MPCF.Trim(out_node.GetString("ORD_CMF_6"));
            cdvCMF7.Text = MPCF.Trim(out_node.GetString("ORD_CMF_7"));
            cdvCMF8.Text = MPCF.Trim(out_node.GetString("ORD_CMF_8"));
            cdvCMF9.Text = MPCF.Trim(out_node.GetString("ORD_CMF_9"));
            cdvCMF10.Text = MPCF.Trim(out_node.GetString("ORD_CMF_10"));
            //Modify by J.S. 2011.05.04 QTY가 되어야 함.
            txtQty1.Text = MPCF.Format("##,##0.###", out_node.GetDouble("QTY"));
            cdvCreateCode.Text = MPCF.Trim(out_node.GetString("CREATE_CODE"));
            cdvOwnerCode.Text = MPCF.Trim(out_node.GetString("OWNER_CODE"));
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
            if (MPCF.Trim(out_node.GetChar("ORDER_STATUS_FLAG")) == "O")
            {
                txtOrderStatus.Text = "Open";
            }
            else if (MPCF.Trim(out_node.GetChar("ORDER_STATUS_FLAG")) == "C")
            {
                txtOrderStatus.Text = "Close";
            }
            else if (MPCF.Trim(out_node.GetChar("ORDER_STATUS_FLAG")) == "D")
            {
                txtOrderStatus.Text = "Delete";
            }
            else if (MPCF.Trim(out_node.GetChar("ORDER_STATUS_FLAG")) == "F")
            {
                txtOrderStatus.Text = "Finish";
            }
            txtOrderShipFlag.Text = MPCF.Trim(out_node.GetChar("ORDER_SHIP_FLAG"));
            txtOrderStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("ORDER_START_TIME"));
            txtOrderEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("ORDER_END_TIME"));
            txtOrderInQty1.Text = MPCF.Format("##,##0.###", out_node.GetDouble("ORD_IN_QTY"));

            txtOutQty1.Text = MPCF.Format("##,##0.###", out_node.GetDouble("ORD_OUT_QTY"));
            txtLossQty1.Text = MPCF.Format("##,##0.###", out_node.GetDouble("ORD_LOSS_QTY"));
            txtRwkQty1.Text = MPCF.Format("##,##0.###", out_node.GetDouble("ORD_RWK_QTY"));

            return true;
        }

#if _BOM
        private bool GetBomSetVersion()
        {
            TRSNode in_node = new TRSNode("FIND_BOM_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("FIND_BOM_SET_VERSION_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';                
                in_node.AddString("BOM_SET_ID", MPCF.Trim(cdvBOMSetID.Text));

                if (MPCR.CallService("BOM", "BOM_Find_Bom_Set_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                cdvBOMSetVersion.Text = MPCF.Trim(out_node.GetInt("BOM_SET_VERSION"));


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }
#endif

        // Update_Order()
        //       - Create/Update/Delete Order
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal c_step As String : ProcStep
        private bool Update_Order(char c_step)
        {

            TRSNode in_node = new TRSNode("UPDATE_ORDER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            ListViewItem itm;
            int idx;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("ORDER_ID", MPCF.Trim(txtOrder.Text));
                in_node.AddString("ORDER_DESC", MPCF.Trim(txtOrderDesc.Text));
                in_node.AddString("WORK_DATE", MPCF.ToStandardTime(dtpWorkDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddInt("FLOW_SEQ_NUM", cdvFlow.Sequence);
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("PLAN_DUE_TIME", MPCF.Trim(txtPlanDueTime.Text));
                in_node.AddString("PLAN_START_TIME", MPCF.Trim(txtPlanStartTime.Text));
                in_node.AddString("PLAN_END_TIME", MPCF.Trim(txtPlanEndTime.Text));
                in_node.AddString("BOM_SET_ID", MPCF.Trim(cdvBOMSetID.Text));
                in_node.AddInt("BOM_SET_VERSION", MPCF.ToInt(cdvBOMSetVersion.Text));
                in_node.AddString("CUSTOMER_ID", MPCF.Trim(txtCustomerID.Text));
                in_node.AddString("CUSTOMER_MAT_ID", MPCF.Trim(txtCustomerMatID.Text));
                in_node.AddDouble("ORD_QTY", MPCF.ToDbl(txtOrderQty1.Text));
                in_node.AddDouble("QTY", MPCF.ToDbl(txtQty1.Text));
                in_node.AddString("CREATE_CODE", MPCF.Trim(cdvCreateCode.Text));
                in_node.AddString("OWNER_CODE", MPCF.Trim(cdvOwnerCode.Text));
                in_node.AddChar("LOT_TYPE", MPCF.ToChar(MPCF.Trim(cdvLotType.Text)));

                in_node.AddChar("LOT_PRIORITY", MPCF.ToChar(MPCF.Trim(cboPriority.Text)));

                if (chkDueDate.Checked == true)
                {
                    in_node.AddString("ORG_DUE_TIME", MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
                }

                in_node.AddString("ORD_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("ORD_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("ORD_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("ORD_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("ORD_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("ORD_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("ORD_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("ORD_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("ORD_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("ORD_CMF_10", MPCF.Trim(cdvCMF10.Text));

                if (MPCR.CallService("ORD", "ORD_Update_Order", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisOrder.Items.Add(txtOrder.Text, (int)SMALLICON_INDEX.IDX_ORDER);
                        itm.SubItems.Add(cdvMaterial.Text);
                        itm.SubItems.Add(txtOrderQty1.Text);
                        itm.SubItems.Add(txtOrderDesc.Text);
                        itm.Selected = true;
                        lisOrder.Sorting = SortOrder.Ascending;
                        lisOrder.Sort();
                        itm.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisOrder, MPCF.Trim(txtOrder.Text), false) == true)
                        {
                            lisOrder.SelectedItems[0].SubItems[1].Text = MPCF.Trim(cdvMaterial.Text);
                            lisOrder.SelectedItems[0].SubItems[2].Text = txtOrderQty1.Text;
                            lisOrder.SelectedItems[0].SubItems[3].Text = txtOrderDesc.Text;
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        if (chkIncludeDeleteFlag.Checked == true)
                        {
                            if (MPCF.FindListItem(lisOrder, MPCF.Trim(txtOrder.Text), false) == true)
                            {
                                lisOrder.SelectedItems[0].ForeColor = Color.Magenta;
                            }
                        }
                        else
                        {
                            idx = MPCF.FindListItemIndex(lisOrder, MPCF.Trim(txtOrder.Text), false);
                            if (idx != -1)
                            {
                                lisOrder.Items[idx].Remove();
                            }
                        }

                    }
                    lblDataCount.Text = MPCF.Trim(lisOrder.Items.Count);
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

            return true;

        }

        
        //
        // Refresh_OrderList()
        //       - Refresh Order List
        // Return Value
        //       -
        // Arguments
        //        -
        private void Refresh_Orderlist()
        {
            if (chkIncludeDeleteFlag.Checked == true)
            {
                if (ORDLIST.ViewOrderList(lisOrder, '2', MPCF.ToStandardTime(dtpDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), null, "") == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisOrder.Items.Count);
                }
            }
            else if (chkIncludeDeleteFlag.Checked == false)
            {
                if (ORDLIST.ViewOrderList(lisOrder, '1', MPCF.ToStandardTime(dtpDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), null, "") == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisOrder.Items.Count);
                }
            }
        }
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool CheckCondition(string FuncName)
        {

            if (MPCF.CheckValue(txtOrder, 1, false, false, "", "" ,"") == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":

                    if (cdvMaterial.CheckValue() == false)
                    {
                        return false;
                    }
                    if (cdvFlow.CheckValue() == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtOrderQty1, 1) == false)
                    {
                        return false;
                    }
                    //If cdvResID.Items.Count > 0 Then
                    //    If CheckValue(cdvResID, 1) = False Then
                    //        tabGeneral.SelectedTab = tbpGeneral
                    //        cdvResID.Focus()
                    //        Return False
                    //    End If
                    //End If
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
                    if (MPCF.CheckValue(cdvLotType, 1, false, false, "", "" ,"") == false)
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
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        return false;
                    }
                    break;
                case "UPDATE":
                    
                    if (txtOrderStatus.Text == "Delete")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(173));
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
                    if (MPCF.CheckValue(txtOrderQty1, 1) == false)
                    {
                        return false;
                    }
                    //If CheckValue(cdvResID, "1") = False Then Return False
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
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        return false;
                    }
                    break;
                case "DELETE":
                    
                    if (txtOrderStatus.Text == "Delete")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(173));
                        return false;
                    }
                    break;
                    
            }
            
            return true;
            
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
        
        private void frmORDSetupProductionOrder_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.InitListView(lisOrder);
                chkIncludeDeleteFlag.Checked = true;
                MPCR.SetCMFItem(MPGC.MP_CMF_ORDER, "lblCMF", "cdvCMF", grpCMF);
                
                Refresh_Orderlist();
                if (lisOrder.Items.Count > 0)
                {
                    lisOrder.Items[0].Selected = true;
                    lblDataCount.Text = MPCF.Trim(lisOrder.Items.Count);
                }
                
                b_load_flag = true;
            }
        }
        
        private void lisOrder_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this.pnlRight);
            if (lisOrder.SelectedItems.Count > 0)
            {
                txtOrder.Text = lisOrder.SelectedItems[0].Text;
                View_Order();
            }
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("CREATE") == true)
            {
                if (Update_Order(MPGC.MP_STEP_CREATE) == true)
                {
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        Refresh_Orderlist();
                        MPCF.FindListItem(lisOrder, txtOrder.Text, false);
                    }
                }
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisOrder, this.Text, "");
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            Refresh_Orderlist();
            if (lisOrder.Items.Count > 0)
            {
                lisOrder.Items[0].Selected = true;
            }
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("UPDATE") == true)
            {
                if (Update_Order(MPGC.MP_STEP_UPDATE) == true)
                {
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        Refresh_Orderlist();
                        MPCF.FindListItem(lisOrder, txtOrder.Text, false);
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
            
            if (lisOrder.SelectedItems.Count > 0)
            {
                iIdx = lisOrder.SelectedItems[0].Index;
            }
            if (CheckCondition("DELETE") == true)
            {
                if (Update_Order(MPGC.MP_STEP_DELETE) == true)
                {
                    MPCF.FieldClear(this.pnlRight);
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        Refresh_Orderlist();
                        if (iIdx < lisOrder.Items.Count)
                        {
                            lisOrder.Items[iIdx].Selected = true;
                        }
                    }
                }
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
        
        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
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
        private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }
        
        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }
        
        private void dtpDate_CloseUp(object sender, System.EventArgs e)
        {
            Refresh_Orderlist();
            MPCF.FieldClear(this.pnlRight);
            if (lisOrder.Items.Count > 0)
            {
                lisOrder.Items[0].Selected = true;
            }
        }
        
        private void txtOrder_TextChanged(object sender, System.EventArgs e)
        {
            chkDueDate.Checked = false;
        }
        
        private void chkIncludeDeleteFlag_CheckedChanged(object sender, System.EventArgs e)
        {
            Refresh_Orderlist();
            MPCF.FieldClear(this.pnlRight);
            if (lisOrder.Items.Count > 0)
            {
                lisOrder.Items[0].Selected = true;
            }
        }
        
        private void cdvMaterial_VersionSelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvFlow.Text = "";
            if (View_Material() == false)
            {
                return;
            }
        }
        private void cdvMaterial_MaterialTextBoxTextChanged(object sender, System.EventArgs e)
        {
            cdvFlow.Text = "";
        }
        
        private void cdvBOMSetID_ButtonPress(object sender, System.EventArgs e)
        {
            #if _BOM
            cdvBOMSetID.Init();
            MPCF.InitListView(cdvBOMSetID.GetListView);
            cdvBOMSetID.Columns.Add("Set ID", 50, HorizontalAlignment.Left);
            cdvBOMSetID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvBOMSetID.SelectedSubItemIndex = 0;

            BOMLIST.ViewBOMSetList(cdvBOMSetID.GetListView, '3', null, "", -1, -1, 'O', false);
            #endif
        }
        
        private void cdvBOMSetID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvBOMSetVersion.Text = "";
            #if _BOM
            GetBomSetVersion();
            #endif
        }
        
        private void cdvBOMSetID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            cdvBOMSetVersion.Text = "";
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisOrder, txtFind.Text, true, false);
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisOrder, txtFind.Text, 0, true, false);
        }
        
        private void txtOrder_LostFocus(object sender, System.EventArgs e)
        {
            if (lisOrder.SelectedItems.Count > 0)
            {
                if (txtOrder.Text != "")
                {
                    if (MPCF.Trim(lisOrder.SelectedItems[0].Text) != txtOrder.Text)
                    {
                        MPCF.FieldClear(grpUpdateInfo);
                        MPCF.FieldClear(grpOrderStatus);
                    }
                }
            }
            else if (txtOrder.Text != "")
            {
                MPCF.FieldClear(grpUpdateInfo);
                MPCF.FieldClear(grpOrderStatus);
            }
            
        }
        
        private void cdvBOMSetVersion_ButtonPress(object sender, System.EventArgs e)
        {
            #if _BOM
            if (cdvBOMSetID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvBOMSetID.Focus();
            }
            else
            {
                BOMLIST.ViewBOMSetVersionList(cdvBOMSetVersion.GetListView, '1', cdvBOMSetID.Text, -1, null, "");
            }
            #endif
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
        
      
        
    }
    //#End If
}
