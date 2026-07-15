
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
//   File Name   : frmRASTranCarrierEvent.vb
//   Description : Carrier Event Form
//
//   MES Version : 4.1.0.0
//
//   Function List

//       - Carrier_Event()         : Transaction(Event)
//       - View_Carrier()          : View Carrier Information
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-07-01 : Created by GI Kim
//       - 2008-01-22 : Modified by W.Y.Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.RASCore
{
    public class frmRASTranCleanCarrier : Miracom.MESCore.SetupForm02
    {
#if _CRR
        #region " Windows Form auto generated code "
        
        public frmRASTranCleanCarrier()
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
        private Miracom.UI.Controls.MCListView.MCListView lisCarrier;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup;
        private GroupBox grpCarrier;
        private Label lblCrrDesc;
        private Label lblCrrID;
        private TextBox txtCrrDesc;
        private TextBox txtCrrID;
        private GroupBox grpStatus;
        private TabControl tabCarrierStatus;
        private TabPage tbpGeneral1;
        private GroupBox grpGeneral1;
        private CheckBox chkEmptyFlag;
        private CheckBox chkMoveFlag;
        private CheckBox chkFinishCleanFlag;
        private TextBox txtMaterial;
        private Label lblMaterial;
        private TextBox txtCarrierStatus;
        private Label lblCarrierStatus;
        private TextBox txtCarrierGroup;
        private Label lblCarrierGroup;
        private TextBox txtLotID;
        private Label lblLotID;
        private Label lblUpdateTime;
        private Label lblCreateTime;
        private TextBox txtLocation;
        private Label lblLocation;
        private Label lblCrrType3;
        private Label lblCrrType2;
        private Label lblUsageLimit;
        private Label lblSize;
        private Label lblUpdateUser;
        private Label lblCreateUser;
        private TextBox txtUpdateTime;
        private TextBox txtCreateTime;
        private TextBox txtUpdateUser;
        private TextBox txtCreateUser;
        private Label lblSubResID;
        private Label lblResID;
        private Label lblCrrType1;
        private Label lblCleanLimit;
        private Label lblPortID;
        private TextBox txtCrrType1;
        private TextBox txtCrrType2;
        private TextBox txtCrrType3;
        private TextBox txtSize;
        private TextBox txtUsageLimit;
        private TextBox txtCleanLimit;
        private TextBox txtResourceID;
        private TextBox txtSubResourceID;
        private TextBox txtPort;
        private TextBox txtUsageCount;
        private Label lblUsageCount;
        private Label lblCleanCount;
        private TextBox txtCleanCount;
        private TextBox txtCleanTime;
        private Label Label3;
        private TextBox txtQty2;
        private Label lblQty2;
        private TextBox txtQty1;
        private Label lblQty1;
        private TextBox txtQty3;
        private Label lblQty3;
        private TabPage tbpGeneral2;
        private GroupBox grpGeneral2;
        private TextBox txtOldLocation3;
        private TextBox txtLocation3;
        private TextBox txtLastHistSeq;
        private TextBox txtElapseUsageTime;
        private Label lblOldLocation3;
        private Label lblLocation3;
        private Label lblLastHistSeq;
        private Label lblElapseUsageTime;
        private TextBox txtOldSubResourceID;
        private TextBox txtOldResourceID;
        private Label lblSubResourceID;
        private TextBox txtOldPortID;
        private Label lblOldResourceID;
        private Label lblOldPortID;
        private TextBox txtPlanTerminateTime;
        private TextBox txtOldLocation1;
        private Label lblPlanTerminateTime;
        private TextBox txtOldLocation2;
        private TextBox txtLocation1;
        private TextBox txtLocation2;
        private Label lblOldLocation1;
        private TextBox txtUseSubAreaID;
        private Label lblLocation1;
        private TextBox txtOldLocation5;
        private TextBox txtLotHistSeq;
        private TextBox txtLocation5;
        private Label lblUseSubAreaID;
        private Label lblOldLocation2;
        private TextBox txtLastTranTime;
        private Label lblLocation2;
        private TextBox txtUsageLimitTime;
        private Label lblOldLocation5;
        private Label lblLotHistSeq;
        private Label lblLocation5;
        private TextBox txtUseResourceID;
        private Label lblLstTranTime;
        private TextBox txtOldLocation4;
        private Label lblUsageLimitTime;
        private TextBox txtLocation4;
        private Label lblUseResourceID;
        private TextBox txtLastTranCode;
        private Label lblOldLocation4;
        private TextBox txtTableSlot;
        private Label lblLocation4;
        private TextBox txtUseAreaID;
        private Label lblLastTranCode;
        private Label lblTableSlot;
        private Label lblUseAreaID;
        private TextBox txtStockInTime;
        private Label lblStockInTime;
        private TabPage tbpAttribute;
        private Miracom.BASCore.udcAttributeStatus udcAttributeStatus;
        private TabPage tbpLotList;
        private GroupBox grpLotList;
        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private ColumnHeader colLotID;
        private ColumnHeader colQty1;
        private ColumnHeader colAQty1;
        private ColumnHeader colNQty1;
        private ColumnHeader colQty2;
        private ColumnHeader colAQty2;
        private ColumnHeader colNQty2;
        private ColumnHeader colQty3;
        private ColumnHeader colAQty3;
        private ColumnHeader colNQty3;
        private TabPage tbpSlotMap;
        private GroupBox grpSlotMap;
        private Miracom.UI.Controls.MCListView.MCListView lisSlotMap;
        private ColumnHeader colSlot1;
        private ColumnHeader colSubLot1;
        private ColumnHeader colLot1;
        private ColumnHeader colGrade;
        private TabPage tbpCrtCmfField;
        private GroupBox grpCmf;
        private TextBox txtCmf17;
        private TextBox txtCmf15;
        private TextBox txtCmf20;
        private TextBox txtCmf19;
        private TextBox txtCmf18;
        private TextBox txtCmf16;
        private TextBox txtCmf14;
        private TextBox txtCmf13;
        private TextBox txtCmf12;
        private TextBox txtCmf11;
        private Label lblCMF20;
        private Label lblCMF19;
        private Label lblCMF18;
        private Label lblCMF17;
        private Label lblCMF16;
        private Label lblCMF15;
        private Label lblCMF14;
        private Label lblCMF13;
        private Label lblCMF12;
        private Label lblCMF11;
        private TextBox txtCmf7;
        private TextBox txtCmf5;
        private TextBox txtCmf10;
        private TextBox txtCmf9;
        private TextBox txtCmf8;
        private TextBox txtCmf6;
        private TextBox txtCmf4;
        private TextBox txtCmf3;
        private TextBox txtCmf2;
        private TextBox txtCmf1;
        private Label lblCMF10;
        private Label lblCMF9;
        private Label lblCMF8;
        private Label lblCMF7;
        private Label lblCMF6;
        private Label lblCMF5;
        private Label lblCMF4;
        private Label lblCMF3;
        private Label lblCMF2;
        private Label lblCMF1;
        private CheckBox chkNeedClean;
        private Label lblGroup;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisCarrier = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdvGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup = new System.Windows.Forms.Label();
            this.grpCarrier = new System.Windows.Forms.GroupBox();
            this.lblCrrDesc = new System.Windows.Forms.Label();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.txtCrrDesc = new System.Windows.Forms.TextBox();
            this.txtCrrID = new System.Windows.Forms.TextBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.tabCarrierStatus = new System.Windows.Forms.TabControl();
            this.tbpGeneral1 = new System.Windows.Forms.TabPage();
            this.grpGeneral1 = new System.Windows.Forms.GroupBox();
            this.chkNeedClean = new System.Windows.Forms.CheckBox();
            this.chkEmptyFlag = new System.Windows.Forms.CheckBox();
            this.chkMoveFlag = new System.Windows.Forms.CheckBox();
            this.chkFinishCleanFlag = new System.Windows.Forms.CheckBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.txtCarrierStatus = new System.Windows.Forms.TextBox();
            this.lblCarrierStatus = new System.Windows.Forms.Label();
            this.txtCarrierGroup = new System.Windows.Forms.TextBox();
            this.lblCarrierGroup = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblCrrType3 = new System.Windows.Forms.Label();
            this.lblCrrType2 = new System.Windows.Forms.Label();
            this.lblUsageLimit = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblSubResID = new System.Windows.Forms.Label();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblCrrType1 = new System.Windows.Forms.Label();
            this.lblCleanLimit = new System.Windows.Forms.Label();
            this.lblPortID = new System.Windows.Forms.Label();
            this.txtCrrType1 = new System.Windows.Forms.TextBox();
            this.txtCrrType2 = new System.Windows.Forms.TextBox();
            this.txtCrrType3 = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtUsageLimit = new System.Windows.Forms.TextBox();
            this.txtCleanLimit = new System.Windows.Forms.TextBox();
            this.txtResourceID = new System.Windows.Forms.TextBox();
            this.txtSubResourceID = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtUsageCount = new System.Windows.Forms.TextBox();
            this.lblUsageCount = new System.Windows.Forms.Label();
            this.lblCleanCount = new System.Windows.Forms.Label();
            this.txtCleanCount = new System.Windows.Forms.TextBox();
            this.txtCleanTime = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.lblQty3 = new System.Windows.Forms.Label();
            this.tbpGeneral2 = new System.Windows.Forms.TabPage();
            this.grpGeneral2 = new System.Windows.Forms.GroupBox();
            this.txtOldLocation3 = new System.Windows.Forms.TextBox();
            this.txtLocation3 = new System.Windows.Forms.TextBox();
            this.txtLastHistSeq = new System.Windows.Forms.TextBox();
            this.txtElapseUsageTime = new System.Windows.Forms.TextBox();
            this.lblOldLocation3 = new System.Windows.Forms.Label();
            this.lblLocation3 = new System.Windows.Forms.Label();
            this.lblLastHistSeq = new System.Windows.Forms.Label();
            this.lblElapseUsageTime = new System.Windows.Forms.Label();
            this.txtOldSubResourceID = new System.Windows.Forms.TextBox();
            this.txtOldResourceID = new System.Windows.Forms.TextBox();
            this.lblSubResourceID = new System.Windows.Forms.Label();
            this.txtOldPortID = new System.Windows.Forms.TextBox();
            this.lblOldResourceID = new System.Windows.Forms.Label();
            this.lblOldPortID = new System.Windows.Forms.Label();
            this.txtPlanTerminateTime = new System.Windows.Forms.TextBox();
            this.txtOldLocation1 = new System.Windows.Forms.TextBox();
            this.lblPlanTerminateTime = new System.Windows.Forms.Label();
            this.txtOldLocation2 = new System.Windows.Forms.TextBox();
            this.txtLocation1 = new System.Windows.Forms.TextBox();
            this.txtLocation2 = new System.Windows.Forms.TextBox();
            this.lblOldLocation1 = new System.Windows.Forms.Label();
            this.txtUseSubAreaID = new System.Windows.Forms.TextBox();
            this.lblLocation1 = new System.Windows.Forms.Label();
            this.txtOldLocation5 = new System.Windows.Forms.TextBox();
            this.txtLotHistSeq = new System.Windows.Forms.TextBox();
            this.txtLocation5 = new System.Windows.Forms.TextBox();
            this.lblUseSubAreaID = new System.Windows.Forms.Label();
            this.lblOldLocation2 = new System.Windows.Forms.Label();
            this.txtLastTranTime = new System.Windows.Forms.TextBox();
            this.lblLocation2 = new System.Windows.Forms.Label();
            this.txtUsageLimitTime = new System.Windows.Forms.TextBox();
            this.lblOldLocation5 = new System.Windows.Forms.Label();
            this.lblLotHistSeq = new System.Windows.Forms.Label();
            this.lblLocation5 = new System.Windows.Forms.Label();
            this.txtUseResourceID = new System.Windows.Forms.TextBox();
            this.lblLstTranTime = new System.Windows.Forms.Label();
            this.txtOldLocation4 = new System.Windows.Forms.TextBox();
            this.lblUsageLimitTime = new System.Windows.Forms.Label();
            this.txtLocation4 = new System.Windows.Forms.TextBox();
            this.lblUseResourceID = new System.Windows.Forms.Label();
            this.txtLastTranCode = new System.Windows.Forms.TextBox();
            this.lblOldLocation4 = new System.Windows.Forms.Label();
            this.txtTableSlot = new System.Windows.Forms.TextBox();
            this.lblLocation4 = new System.Windows.Forms.Label();
            this.txtUseAreaID = new System.Windows.Forms.TextBox();
            this.lblLastTranCode = new System.Windows.Forms.Label();
            this.lblTableSlot = new System.Windows.Forms.Label();
            this.lblUseAreaID = new System.Windows.Forms.Label();
            this.txtStockInTime = new System.Windows.Forms.TextBox();
            this.lblStockInTime = new System.Windows.Forms.Label();
            this.tbpAttribute = new System.Windows.Forms.TabPage();
            this.udcAttributeStatus = new Miracom.BASCore.udcAttributeStatus();
            this.tbpLotList = new System.Windows.Forms.TabPage();
            this.grpLotList = new System.Windows.Forms.GroupBox();
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpSlotMap = new System.Windows.Forms.TabPage();
            this.grpSlotMap = new System.Windows.Forms.GroupBox();
            this.lisSlotMap = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSlot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubLot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLot1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGrade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpCrtCmfField = new System.Windows.Forms.TabPage();
            this.grpCmf = new System.Windows.Forms.GroupBox();
            this.txtCmf17 = new System.Windows.Forms.TextBox();
            this.txtCmf15 = new System.Windows.Forms.TextBox();
            this.txtCmf20 = new System.Windows.Forms.TextBox();
            this.txtCmf19 = new System.Windows.Forms.TextBox();
            this.txtCmf18 = new System.Windows.Forms.TextBox();
            this.txtCmf16 = new System.Windows.Forms.TextBox();
            this.txtCmf14 = new System.Windows.Forms.TextBox();
            this.txtCmf13 = new System.Windows.Forms.TextBox();
            this.txtCmf12 = new System.Windows.Forms.TextBox();
            this.txtCmf11 = new System.Windows.Forms.TextBox();
            this.lblCMF20 = new System.Windows.Forms.Label();
            this.lblCMF19 = new System.Windows.Forms.Label();
            this.lblCMF18 = new System.Windows.Forms.Label();
            this.lblCMF17 = new System.Windows.Forms.Label();
            this.lblCMF16 = new System.Windows.Forms.Label();
            this.lblCMF15 = new System.Windows.Forms.Label();
            this.lblCMF14 = new System.Windows.Forms.Label();
            this.lblCMF13 = new System.Windows.Forms.Label();
            this.lblCMF12 = new System.Windows.Forms.Label();
            this.lblCMF11 = new System.Windows.Forms.Label();
            this.txtCmf7 = new System.Windows.Forms.TextBox();
            this.txtCmf5 = new System.Windows.Forms.TextBox();
            this.txtCmf10 = new System.Windows.Forms.TextBox();
            this.txtCmf9 = new System.Windows.Forms.TextBox();
            this.txtCmf8 = new System.Windows.Forms.TextBox();
            this.txtCmf6 = new System.Windows.Forms.TextBox();
            this.txtCmf4 = new System.Windows.Forms.TextBox();
            this.txtCmf3 = new System.Windows.Forms.TextBox();
            this.txtCmf2 = new System.Windows.Forms.TextBox();
            this.txtCmf1 = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).BeginInit();
            this.grpCarrier.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.tabCarrierStatus.SuspendLayout();
            this.tbpGeneral1.SuspendLayout();
            this.grpGeneral1.SuspendLayout();
            this.tbpGeneral2.SuspendLayout();
            this.grpGeneral2.SuspendLayout();
            this.tbpAttribute.SuspendLayout();
            this.tbpLotList.SuspendLayout();
            this.grpLotList.SuspendLayout();
            this.tbpSlotMap.SuspendLayout();
            this.grpSlotMap.SuspendLayout();
            this.tbpCrtCmfField.SuspendLayout();
            this.grpCmf.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.grpStatus);
            this.pnlRight.Controls.Add(this.grpCarrier);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Size = new System.Drawing.Size(232, 64);
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.cdvGroup);
            this.grpFilter.Controls.Add(this.lblGroup);
            this.grpFilter.Size = new System.Drawing.Size(232, 62);
            this.grpFilter.Controls.SetChildIndex(this.rbnFilter, 0);
            this.grpFilter.Controls.SetChildIndex(this.rbnNoFilter, 0);
            this.grpFilter.Controls.SetChildIndex(this.btnFilterView, 0);
            this.grpFilter.Controls.SetChildIndex(this.txtFilter, 0);
            this.grpFilter.Controls.SetChildIndex(this.lblGroup, 0);
            this.grpFilter.Controls.SetChildIndex(this.cdvGroup, 0);
            // 
            // btnFilterView
            // 
            this.btnFilterView.Location = new System.Drawing.Point(184, 37);
            this.btnFilterView.Size = new System.Drawing.Size(41, 20);
            this.btnFilterView.TabIndex = 5;
            this.btnFilterView.Click += new System.EventHandler(this.btnFilterView_Click);
            // 
            // rbnNoFilter
            // 
            this.rbnNoFilter.AutoSize = true;
            this.rbnNoFilter.Location = new System.Drawing.Point(131, 40);
            this.rbnNoFilter.Size = new System.Drawing.Size(36, 17);
            this.rbnNoFilter.TabIndex = 4;
            // 
            // rbnFilter
            // 
            this.rbnFilter.Location = new System.Drawing.Point(8, 40);
            this.rbnFilter.TabIndex = 2;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisCarrier);
            this.pnlLeft.Location = new System.Drawing.Point(0, 64);
            this.pnlLeft.Size = new System.Drawing.Size(232, 442);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(26, 37);
            this.txtFilter.MaxLength = 20;
            this.txtFilter.TabIndex = 3;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(368, 8);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(464, 8);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(556, 8);
            this.btnUpdate.Text = "Clean";
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
            this.lblFormTitle.Text = "BaseForm02";
            // 
            // lisCarrier
            // 
            this.lisCarrier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisCarrier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCarrier.EnableSort = true;
            this.lisCarrier.EnableSortIcon = true;
            this.lisCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCarrier.FullRowSelect = true;
            this.lisCarrier.Location = new System.Drawing.Point(0, 0);
            this.lisCarrier.MultiSelect = false;
            this.lisCarrier.Name = "lisCarrier";
            this.lisCarrier.Size = new System.Drawing.Size(232, 442);
            this.lisCarrier.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lisCarrier.TabIndex = 0;
            this.lisCarrier.UseCompatibleStateImageBehavior = false;
            this.lisCarrier.View = System.Windows.Forms.View.Details;
            this.lisCarrier.SelectedIndexChanged += new System.EventHandler(this.lisCarrier_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Carrier";
            this.ColumnHeader1.Width = 80;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 140;
            // 
            // cdvGroup
            // 
            this.cdvGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup.BtnToolTipText = "";
            this.cdvGroup.ButtonWidth = 20;
            this.cdvGroup.DescText = "";
            this.cdvGroup.DisplaySubItemIndex = -1;
            this.cdvGroup.DisplayText = "";
            this.cdvGroup.Focusing = null;
            this.cdvGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup.Index = 0;
            this.cdvGroup.IsViewBtnImage = false;
            this.cdvGroup.Location = new System.Drawing.Point(93, 12);
            this.cdvGroup.MaxLength = 20;
            this.cdvGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MultiSelect = false;
            this.cdvGroup.Name = "cdvGroup";
            this.cdvGroup.ReadOnly = true;
            this.cdvGroup.SameWidthHeightOfButton = false;
            this.cdvGroup.SearchSubItemIndex = 0;
            this.cdvGroup.SelectedDescIndex = -1;
            this.cdvGroup.SelectedDescToQueryText = "";
            this.cdvGroup.SelectedSubItemIndex = -1;
            this.cdvGroup.SelectedValueToQueryText = "";
            this.cdvGroup.SelectionStart = 0;
            this.cdvGroup.Size = new System.Drawing.Size(132, 20);
            this.cdvGroup.SmallImageList = null;
            this.cdvGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup.TabIndex = 1;
            this.cdvGroup.TextBoxToolTipText = "";
            this.cdvGroup.TextBoxWidth = 132;
            this.cdvGroup.VisibleButton = true;
            this.cdvGroup.VisibleColumnHeader = false;
            this.cdvGroup.VisibleDescription = false;
            this.cdvGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGroup_SelectedItemChanged);
            this.cdvGroup.ButtonPress += new System.EventHandler(this.cdvGroup_ButtonPress);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup.Location = new System.Drawing.Point(7, 15);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(69, 13);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "Carrier Group";
            // 
            // grpCarrier
            // 
            this.grpCarrier.Controls.Add(this.lblCrrDesc);
            this.grpCarrier.Controls.Add(this.lblCrrID);
            this.grpCarrier.Controls.Add(this.txtCrrDesc);
            this.grpCarrier.Controls.Add(this.txtCrrID);
            this.grpCarrier.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCarrier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCarrier.Location = new System.Drawing.Point(0, 0);
            this.grpCarrier.Name = "grpCarrier";
            this.grpCarrier.Size = new System.Drawing.Size(506, 72);
            this.grpCarrier.TabIndex = 0;
            this.grpCarrier.TabStop = false;
            // 
            // lblCrrDesc
            // 
            this.lblCrrDesc.AutoSize = true;
            this.lblCrrDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrDesc.Location = new System.Drawing.Point(20, 43);
            this.lblCrrDesc.Name = "lblCrrDesc";
            this.lblCrrDesc.Size = new System.Drawing.Size(60, 13);
            this.lblCrrDesc.TabIndex = 2;
            this.lblCrrDesc.Text = "Description";
            // 
            // lblCrrID
            // 
            this.lblCrrID.AutoSize = true;
            this.lblCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrID.Location = new System.Drawing.Point(20, 20);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(51, 13);
            this.lblCrrID.TabIndex = 0;
            this.lblCrrID.Text = "Carrier ID";
            // 
            // txtCrrDesc
            // 
            this.txtCrrDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrrDesc.Location = new System.Drawing.Point(129, 40);
            this.txtCrrDesc.MaxLength = 200;
            this.txtCrrDesc.Name = "txtCrrDesc";
            this.txtCrrDesc.ReadOnly = true;
            this.txtCrrDesc.Size = new System.Drawing.Size(359, 20);
            this.txtCrrDesc.TabIndex = 3;
            this.txtCrrDesc.TabStop = false;
            // 
            // txtCrrID
            // 
            this.txtCrrID.Location = new System.Drawing.Point(129, 16);
            this.txtCrrID.MaxLength = 20;
            this.txtCrrID.Name = "txtCrrID";
            this.txtCrrID.Size = new System.Drawing.Size(116, 20);
            this.txtCrrID.TabIndex = 1;
            this.txtCrrID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCrrID_KeyPress);
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.tabCarrierStatus);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStatus.Location = new System.Drawing.Point(0, 72);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(506, 434);
            this.grpStatus.TabIndex = 1;
            this.grpStatus.TabStop = false;
            // 
            // tabCarrierStatus
            // 
            this.tabCarrierStatus.Controls.Add(this.tbpGeneral1);
            this.tabCarrierStatus.Controls.Add(this.tbpGeneral2);
            this.tabCarrierStatus.Controls.Add(this.tbpAttribute);
            this.tabCarrierStatus.Controls.Add(this.tbpLotList);
            this.tabCarrierStatus.Controls.Add(this.tbpSlotMap);
            this.tabCarrierStatus.Controls.Add(this.tbpCrtCmfField);
            this.tabCarrierStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCarrierStatus.Location = new System.Drawing.Point(3, 16);
            this.tabCarrierStatus.Name = "tabCarrierStatus";
            this.tabCarrierStatus.SelectedIndex = 0;
            this.tabCarrierStatus.Size = new System.Drawing.Size(500, 415);
            this.tabCarrierStatus.TabIndex = 0;
            // 
            // tbpGeneral1
            // 
            this.tbpGeneral1.BackColor = System.Drawing.SystemColors.Control;
            this.tbpGeneral1.Controls.Add(this.grpGeneral1);
            this.tbpGeneral1.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral1.Name = "tbpGeneral1";
            this.tbpGeneral1.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral1.Size = new System.Drawing.Size(492, 389);
            this.tbpGeneral1.TabIndex = 0;
            this.tbpGeneral1.Text = "General 1";
            // 
            // grpGeneral1
            // 
            this.grpGeneral1.Controls.Add(this.chkNeedClean);
            this.grpGeneral1.Controls.Add(this.chkEmptyFlag);
            this.grpGeneral1.Controls.Add(this.chkMoveFlag);
            this.grpGeneral1.Controls.Add(this.chkFinishCleanFlag);
            this.grpGeneral1.Controls.Add(this.txtMaterial);
            this.grpGeneral1.Controls.Add(this.lblMaterial);
            this.grpGeneral1.Controls.Add(this.txtCarrierStatus);
            this.grpGeneral1.Controls.Add(this.lblCarrierStatus);
            this.grpGeneral1.Controls.Add(this.txtCarrierGroup);
            this.grpGeneral1.Controls.Add(this.lblCarrierGroup);
            this.grpGeneral1.Controls.Add(this.txtLotID);
            this.grpGeneral1.Controls.Add(this.lblLotID);
            this.grpGeneral1.Controls.Add(this.lblUpdateTime);
            this.grpGeneral1.Controls.Add(this.lblCreateTime);
            this.grpGeneral1.Controls.Add(this.txtLocation);
            this.grpGeneral1.Controls.Add(this.lblLocation);
            this.grpGeneral1.Controls.Add(this.lblCrrType3);
            this.grpGeneral1.Controls.Add(this.lblCrrType2);
            this.grpGeneral1.Controls.Add(this.lblUsageLimit);
            this.grpGeneral1.Controls.Add(this.lblSize);
            this.grpGeneral1.Controls.Add(this.lblUpdateUser);
            this.grpGeneral1.Controls.Add(this.lblCreateUser);
            this.grpGeneral1.Controls.Add(this.txtUpdateTime);
            this.grpGeneral1.Controls.Add(this.txtCreateTime);
            this.grpGeneral1.Controls.Add(this.txtUpdateUser);
            this.grpGeneral1.Controls.Add(this.txtCreateUser);
            this.grpGeneral1.Controls.Add(this.lblSubResID);
            this.grpGeneral1.Controls.Add(this.lblResID);
            this.grpGeneral1.Controls.Add(this.lblCrrType1);
            this.grpGeneral1.Controls.Add(this.lblCleanLimit);
            this.grpGeneral1.Controls.Add(this.lblPortID);
            this.grpGeneral1.Controls.Add(this.txtCrrType1);
            this.grpGeneral1.Controls.Add(this.txtCrrType2);
            this.grpGeneral1.Controls.Add(this.txtCrrType3);
            this.grpGeneral1.Controls.Add(this.txtSize);
            this.grpGeneral1.Controls.Add(this.txtUsageLimit);
            this.grpGeneral1.Controls.Add(this.txtCleanLimit);
            this.grpGeneral1.Controls.Add(this.txtResourceID);
            this.grpGeneral1.Controls.Add(this.txtSubResourceID);
            this.grpGeneral1.Controls.Add(this.txtPort);
            this.grpGeneral1.Controls.Add(this.txtUsageCount);
            this.grpGeneral1.Controls.Add(this.lblUsageCount);
            this.grpGeneral1.Controls.Add(this.lblCleanCount);
            this.grpGeneral1.Controls.Add(this.txtCleanCount);
            this.grpGeneral1.Controls.Add(this.txtCleanTime);
            this.grpGeneral1.Controls.Add(this.Label3);
            this.grpGeneral1.Controls.Add(this.txtQty2);
            this.grpGeneral1.Controls.Add(this.lblQty2);
            this.grpGeneral1.Controls.Add(this.txtQty1);
            this.grpGeneral1.Controls.Add(this.lblQty1);
            this.grpGeneral1.Controls.Add(this.txtQty3);
            this.grpGeneral1.Controls.Add(this.lblQty3);
            this.grpGeneral1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral1.Location = new System.Drawing.Point(3, 3);
            this.grpGeneral1.Name = "grpGeneral1";
            this.grpGeneral1.Size = new System.Drawing.Size(486, 383);
            this.grpGeneral1.TabIndex = 0;
            this.grpGeneral1.TabStop = false;
            // 
            // chkNeedClean
            // 
            this.chkNeedClean.AutoSize = true;
            this.chkNeedClean.Enabled = false;
            this.chkNeedClean.Location = new System.Drawing.Point(257, 352);
            this.chkNeedClean.Name = "chkNeedClean";
            this.chkNeedClean.Size = new System.Drawing.Size(105, 17);
            this.chkNeedClean.TabIndex = 51;
            this.chkNeedClean.Text = "Need Clean Flag";
            // 
            // chkEmptyFlag
            // 
            this.chkEmptyFlag.AutoSize = true;
            this.chkEmptyFlag.Enabled = false;
            this.chkEmptyFlag.Location = new System.Drawing.Point(257, 285);
            this.chkEmptyFlag.Name = "chkEmptyFlag";
            this.chkEmptyFlag.Size = new System.Drawing.Size(78, 17);
            this.chkEmptyFlag.TabIndex = 48;
            this.chkEmptyFlag.Text = "Empty Flag";
            // 
            // chkMoveFlag
            // 
            this.chkMoveFlag.AutoSize = true;
            this.chkMoveFlag.Enabled = false;
            this.chkMoveFlag.Location = new System.Drawing.Point(257, 308);
            this.chkMoveFlag.Name = "chkMoveFlag";
            this.chkMoveFlag.Size = new System.Drawing.Size(76, 17);
            this.chkMoveFlag.TabIndex = 49;
            this.chkMoveFlag.Text = "Move Flag";
            // 
            // chkFinishCleanFlag
            // 
            this.chkFinishCleanFlag.AutoSize = true;
            this.chkFinishCleanFlag.Enabled = false;
            this.chkFinishCleanFlag.Location = new System.Drawing.Point(257, 330);
            this.chkFinishCleanFlag.Name = "chkFinishCleanFlag";
            this.chkFinishCleanFlag.Size = new System.Drawing.Size(106, 17);
            this.chkFinishCleanFlag.TabIndex = 50;
            this.chkFinishCleanFlag.Text = "Finish Clean Flag";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(119, 91);
            this.txtMaterial.MaxLength = 10;
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(116, 20);
            this.txtMaterial.TabIndex = 7;
            this.txtMaterial.TabStop = false;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaterial.Location = new System.Drawing.Point(10, 94);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(44, 13);
            this.lblMaterial.TabIndex = 6;
            this.lblMaterial.Text = "Material";
            // 
            // txtCarrierStatus
            // 
            this.txtCarrierStatus.Location = new System.Drawing.Point(362, 91);
            this.txtCarrierStatus.MaxLength = 10;
            this.txtCarrierStatus.Name = "txtCarrierStatus";
            this.txtCarrierStatus.ReadOnly = true;
            this.txtCarrierStatus.Size = new System.Drawing.Size(116, 20);
            this.txtCarrierStatus.TabIndex = 35;
            this.txtCarrierStatus.TabStop = false;
            // 
            // lblCarrierStatus
            // 
            this.lblCarrierStatus.AutoSize = true;
            this.lblCarrierStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCarrierStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCarrierStatus.Location = new System.Drawing.Point(254, 95);
            this.lblCarrierStatus.Name = "lblCarrierStatus";
            this.lblCarrierStatus.Size = new System.Drawing.Size(70, 13);
            this.lblCarrierStatus.TabIndex = 34;
            this.lblCarrierStatus.Text = "Carrier Status";
            // 
            // txtCarrierGroup
            // 
            this.txtCarrierGroup.Location = new System.Drawing.Point(362, 66);
            this.txtCarrierGroup.MaxLength = 20;
            this.txtCarrierGroup.Name = "txtCarrierGroup";
            this.txtCarrierGroup.ReadOnly = true;
            this.txtCarrierGroup.Size = new System.Drawing.Size(116, 20);
            this.txtCarrierGroup.TabIndex = 33;
            this.txtCarrierGroup.TabStop = false;
            // 
            // lblCarrierGroup
            // 
            this.lblCarrierGroup.AutoSize = true;
            this.lblCarrierGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCarrierGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCarrierGroup.Location = new System.Drawing.Point(254, 70);
            this.lblCarrierGroup.Name = "lblCarrierGroup";
            this.lblCarrierGroup.Size = new System.Drawing.Size(69, 13);
            this.lblCarrierGroup.TabIndex = 32;
            this.lblCarrierGroup.Text = "Carrier Group";
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(362, 114);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.ReadOnly = true;
            this.txtLotID.Size = new System.Drawing.Size(116, 20);
            this.txtLotID.TabIndex = 37;
            this.txtLotID.TabStop = false;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotID.Location = new System.Drawing.Point(254, 118);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 36;
            this.lblLotID.Text = "Lot ID";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(10, 335);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 26;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(10, 287);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 22;
            this.lblCreateTime.Text = "Create Time";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(362, 210);
            this.txtLocation.MaxLength = 20;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(116, 20);
            this.txtLocation.TabIndex = 45;
            this.txtLocation.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation.Location = new System.Drawing.Point(254, 214);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 44;
            this.lblLocation.Text = "Location";
            // 
            // lblCrrType3
            // 
            this.lblCrrType3.AutoSize = true;
            this.lblCrrType3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrType3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrType3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrType3.Location = new System.Drawing.Point(10, 71);
            this.lblCrrType3.Name = "lblCrrType3";
            this.lblCrrType3.Size = new System.Drawing.Size(70, 13);
            this.lblCrrType3.TabIndex = 4;
            this.lblCrrType3.Text = "Carrier Type3";
            // 
            // lblCrrType2
            // 
            this.lblCrrType2.AutoSize = true;
            this.lblCrrType2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrType2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrType2.Location = new System.Drawing.Point(10, 47);
            this.lblCrrType2.Name = "lblCrrType2";
            this.lblCrrType2.Size = new System.Drawing.Size(70, 13);
            this.lblCrrType2.TabIndex = 2;
            this.lblCrrType2.Text = "Carrier Type2";
            // 
            // lblUsageLimit
            // 
            this.lblUsageLimit.AutoSize = true;
            this.lblUsageLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUsageLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUsageLimit.Location = new System.Drawing.Point(10, 143);
            this.lblUsageLimit.Name = "lblUsageLimit";
            this.lblUsageLimit.Size = new System.Drawing.Size(62, 13);
            this.lblUsageLimit.TabIndex = 10;
            this.lblUsageLimit.Text = "Usage Limit";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSize.Location = new System.Drawing.Point(10, 119);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 13);
            this.lblSize.TabIndex = 8;
            this.lblSize.Text = "Size";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(10, 311);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 24;
            this.lblUpdateUser.Text = "Update User";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(10, 263);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 20;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(119, 331);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(116, 20);
            this.txtUpdateTime.TabIndex = 27;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(119, 283);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(116, 20);
            this.txtCreateTime.TabIndex = 23;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(119, 307);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(116, 20);
            this.txtUpdateUser.TabIndex = 25;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(119, 259);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(116, 20);
            this.txtCreateUser.TabIndex = 21;
            this.txtCreateUser.TabStop = false;
            // 
            // lblSubResID
            // 
            this.lblSubResID.AutoSize = true;
            this.lblSubResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubResID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubResID.Location = new System.Drawing.Point(253, 47);
            this.lblSubResID.Name = "lblSubResID";
            this.lblSubResID.Size = new System.Drawing.Size(89, 13);
            this.lblSubResID.TabIndex = 30;
            this.lblSubResID.Text = "Sub Resource ID";
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResID.Location = new System.Drawing.Point(253, 23);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 28;
            this.lblResID.Text = "Resource ID";
            // 
            // lblCrrType1
            // 
            this.lblCrrType1.AutoSize = true;
            this.lblCrrType1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrType1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrType1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrType1.Location = new System.Drawing.Point(10, 23);
            this.lblCrrType1.Name = "lblCrrType1";
            this.lblCrrType1.Size = new System.Drawing.Size(70, 13);
            this.lblCrrType1.TabIndex = 0;
            this.lblCrrType1.Text = "Carrier Type1";
            // 
            // lblCleanLimit
            // 
            this.lblCleanLimit.AutoSize = true;
            this.lblCleanLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCleanLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCleanLimit.Location = new System.Drawing.Point(10, 191);
            this.lblCleanLimit.Name = "lblCleanLimit";
            this.lblCleanLimit.Size = new System.Drawing.Size(58, 13);
            this.lblCleanLimit.TabIndex = 14;
            this.lblCleanLimit.Text = "Clean Limit";
            // 
            // lblPortID
            // 
            this.lblPortID.AutoSize = true;
            this.lblPortID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPortID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPortID.Location = new System.Drawing.Point(254, 238);
            this.lblPortID.Name = "lblPortID";
            this.lblPortID.Size = new System.Drawing.Size(40, 13);
            this.lblPortID.TabIndex = 46;
            this.lblPortID.Text = "Port ID";
            // 
            // txtCrrType1
            // 
            this.txtCrrType1.Location = new System.Drawing.Point(119, 19);
            this.txtCrrType1.MaxLength = 10;
            this.txtCrrType1.Name = "txtCrrType1";
            this.txtCrrType1.ReadOnly = true;
            this.txtCrrType1.Size = new System.Drawing.Size(116, 20);
            this.txtCrrType1.TabIndex = 1;
            this.txtCrrType1.TabStop = false;
            // 
            // txtCrrType2
            // 
            this.txtCrrType2.Location = new System.Drawing.Point(119, 43);
            this.txtCrrType2.MaxLength = 10;
            this.txtCrrType2.Name = "txtCrrType2";
            this.txtCrrType2.ReadOnly = true;
            this.txtCrrType2.Size = new System.Drawing.Size(116, 20);
            this.txtCrrType2.TabIndex = 3;
            this.txtCrrType2.TabStop = false;
            // 
            // txtCrrType3
            // 
            this.txtCrrType3.Location = new System.Drawing.Point(119, 67);
            this.txtCrrType3.MaxLength = 10;
            this.txtCrrType3.Name = "txtCrrType3";
            this.txtCrrType3.ReadOnly = true;
            this.txtCrrType3.Size = new System.Drawing.Size(116, 20);
            this.txtCrrType3.TabIndex = 5;
            this.txtCrrType3.TabStop = false;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(119, 115);
            this.txtSize.MaxLength = 6;
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(116, 20);
            this.txtSize.TabIndex = 9;
            this.txtSize.TabStop = false;
            // 
            // txtUsageLimit
            // 
            this.txtUsageLimit.Location = new System.Drawing.Point(119, 139);
            this.txtUsageLimit.MaxLength = 6;
            this.txtUsageLimit.Name = "txtUsageLimit";
            this.txtUsageLimit.ReadOnly = true;
            this.txtUsageLimit.Size = new System.Drawing.Size(116, 20);
            this.txtUsageLimit.TabIndex = 11;
            this.txtUsageLimit.TabStop = false;
            // 
            // txtCleanLimit
            // 
            this.txtCleanLimit.Location = new System.Drawing.Point(119, 187);
            this.txtCleanLimit.MaxLength = 6;
            this.txtCleanLimit.Name = "txtCleanLimit";
            this.txtCleanLimit.ReadOnly = true;
            this.txtCleanLimit.Size = new System.Drawing.Size(116, 20);
            this.txtCleanLimit.TabIndex = 15;
            this.txtCleanLimit.TabStop = false;
            // 
            // txtResourceID
            // 
            this.txtResourceID.Location = new System.Drawing.Point(362, 19);
            this.txtResourceID.MaxLength = 20;
            this.txtResourceID.Name = "txtResourceID";
            this.txtResourceID.ReadOnly = true;
            this.txtResourceID.Size = new System.Drawing.Size(116, 20);
            this.txtResourceID.TabIndex = 29;
            this.txtResourceID.TabStop = false;
            // 
            // txtSubResourceID
            // 
            this.txtSubResourceID.Location = new System.Drawing.Point(362, 43);
            this.txtSubResourceID.MaxLength = 20;
            this.txtSubResourceID.Name = "txtSubResourceID";
            this.txtSubResourceID.ReadOnly = true;
            this.txtSubResourceID.Size = new System.Drawing.Size(116, 20);
            this.txtSubResourceID.TabIndex = 31;
            this.txtSubResourceID.TabStop = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(362, 234);
            this.txtPort.MaxLength = 10;
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(116, 20);
            this.txtPort.TabIndex = 47;
            this.txtPort.TabStop = false;
            // 
            // txtUsageCount
            // 
            this.txtUsageCount.Location = new System.Drawing.Point(119, 163);
            this.txtUsageCount.MaxLength = 6;
            this.txtUsageCount.Name = "txtUsageCount";
            this.txtUsageCount.ReadOnly = true;
            this.txtUsageCount.Size = new System.Drawing.Size(116, 20);
            this.txtUsageCount.TabIndex = 13;
            this.txtUsageCount.TabStop = false;
            // 
            // lblUsageCount
            // 
            this.lblUsageCount.AutoSize = true;
            this.lblUsageCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUsageCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUsageCount.Location = new System.Drawing.Point(10, 167);
            this.lblUsageCount.Name = "lblUsageCount";
            this.lblUsageCount.Size = new System.Drawing.Size(69, 13);
            this.lblUsageCount.TabIndex = 12;
            this.lblUsageCount.Text = "Usage Count";
            // 
            // lblCleanCount
            // 
            this.lblCleanCount.AutoSize = true;
            this.lblCleanCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCleanCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCleanCount.Location = new System.Drawing.Point(10, 215);
            this.lblCleanCount.Name = "lblCleanCount";
            this.lblCleanCount.Size = new System.Drawing.Size(65, 13);
            this.lblCleanCount.TabIndex = 16;
            this.lblCleanCount.Text = "Clean Count";
            // 
            // txtCleanCount
            // 
            this.txtCleanCount.Location = new System.Drawing.Point(119, 211);
            this.txtCleanCount.MaxLength = 6;
            this.txtCleanCount.Name = "txtCleanCount";
            this.txtCleanCount.ReadOnly = true;
            this.txtCleanCount.Size = new System.Drawing.Size(116, 20);
            this.txtCleanCount.TabIndex = 17;
            this.txtCleanCount.TabStop = false;
            // 
            // txtCleanTime
            // 
            this.txtCleanTime.Location = new System.Drawing.Point(119, 235);
            this.txtCleanTime.MaxLength = 30;
            this.txtCleanTime.Name = "txtCleanTime";
            this.txtCleanTime.ReadOnly = true;
            this.txtCleanTime.Size = new System.Drawing.Size(116, 20);
            this.txtCleanTime.TabIndex = 19;
            this.txtCleanTime.TabStop = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(10, 239);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(60, 13);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "Clean Time";
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(362, 162);
            this.txtQty2.MaxLength = 13;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.ReadOnly = true;
            this.txtQty2.Size = new System.Drawing.Size(116, 20);
            this.txtQty2.TabIndex = 41;
            this.txtQty2.TabStop = false;
            // 
            // lblQty2
            // 
            this.lblQty2.AutoSize = true;
            this.lblQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQty2.Location = new System.Drawing.Point(254, 166);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(29, 13);
            this.lblQty2.TabIndex = 40;
            this.lblQty2.Text = "Qty2";
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(362, 138);
            this.txtQty1.MaxLength = 13;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.ReadOnly = true;
            this.txtQty1.Size = new System.Drawing.Size(116, 20);
            this.txtQty1.TabIndex = 39;
            this.txtQty1.TabStop = false;
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQty1.Location = new System.Drawing.Point(254, 142);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(29, 13);
            this.lblQty1.TabIndex = 38;
            this.lblQty1.Text = "Qty1";
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(362, 186);
            this.txtQty3.MaxLength = 13;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.ReadOnly = true;
            this.txtQty3.Size = new System.Drawing.Size(116, 20);
            this.txtQty3.TabIndex = 43;
            this.txtQty3.TabStop = false;
            // 
            // lblQty3
            // 
            this.lblQty3.AutoSize = true;
            this.lblQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQty3.Location = new System.Drawing.Point(254, 190);
            this.lblQty3.Name = "lblQty3";
            this.lblQty3.Size = new System.Drawing.Size(29, 13);
            this.lblQty3.TabIndex = 42;
            this.lblQty3.Text = "Qty3";
            // 
            // tbpGeneral2
            // 
            this.tbpGeneral2.BackColor = System.Drawing.SystemColors.Control;
            this.tbpGeneral2.Controls.Add(this.grpGeneral2);
            this.tbpGeneral2.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral2.Name = "tbpGeneral2";
            this.tbpGeneral2.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral2.Size = new System.Drawing.Size(492, 388);
            this.tbpGeneral2.TabIndex = 1;
            this.tbpGeneral2.Text = "General 2";
            // 
            // grpGeneral2
            // 
            this.grpGeneral2.AutoSize = true;
            this.grpGeneral2.Controls.Add(this.txtOldLocation3);
            this.grpGeneral2.Controls.Add(this.txtLocation3);
            this.grpGeneral2.Controls.Add(this.txtLastHistSeq);
            this.grpGeneral2.Controls.Add(this.txtElapseUsageTime);
            this.grpGeneral2.Controls.Add(this.lblOldLocation3);
            this.grpGeneral2.Controls.Add(this.lblLocation3);
            this.grpGeneral2.Controls.Add(this.lblLastHistSeq);
            this.grpGeneral2.Controls.Add(this.lblElapseUsageTime);
            this.grpGeneral2.Controls.Add(this.txtOldSubResourceID);
            this.grpGeneral2.Controls.Add(this.txtOldResourceID);
            this.grpGeneral2.Controls.Add(this.lblSubResourceID);
            this.grpGeneral2.Controls.Add(this.txtOldPortID);
            this.grpGeneral2.Controls.Add(this.lblOldResourceID);
            this.grpGeneral2.Controls.Add(this.lblOldPortID);
            this.grpGeneral2.Controls.Add(this.txtPlanTerminateTime);
            this.grpGeneral2.Controls.Add(this.txtOldLocation1);
            this.grpGeneral2.Controls.Add(this.lblPlanTerminateTime);
            this.grpGeneral2.Controls.Add(this.txtOldLocation2);
            this.grpGeneral2.Controls.Add(this.txtLocation1);
            this.grpGeneral2.Controls.Add(this.txtLocation2);
            this.grpGeneral2.Controls.Add(this.lblOldLocation1);
            this.grpGeneral2.Controls.Add(this.txtUseSubAreaID);
            this.grpGeneral2.Controls.Add(this.lblLocation1);
            this.grpGeneral2.Controls.Add(this.txtOldLocation5);
            this.grpGeneral2.Controls.Add(this.txtLotHistSeq);
            this.grpGeneral2.Controls.Add(this.txtLocation5);
            this.grpGeneral2.Controls.Add(this.lblUseSubAreaID);
            this.grpGeneral2.Controls.Add(this.lblOldLocation2);
            this.grpGeneral2.Controls.Add(this.txtLastTranTime);
            this.grpGeneral2.Controls.Add(this.lblLocation2);
            this.grpGeneral2.Controls.Add(this.txtUsageLimitTime);
            this.grpGeneral2.Controls.Add(this.lblOldLocation5);
            this.grpGeneral2.Controls.Add(this.lblLotHistSeq);
            this.grpGeneral2.Controls.Add(this.lblLocation5);
            this.grpGeneral2.Controls.Add(this.txtUseResourceID);
            this.grpGeneral2.Controls.Add(this.lblLstTranTime);
            this.grpGeneral2.Controls.Add(this.txtOldLocation4);
            this.grpGeneral2.Controls.Add(this.lblUsageLimitTime);
            this.grpGeneral2.Controls.Add(this.txtLocation4);
            this.grpGeneral2.Controls.Add(this.lblUseResourceID);
            this.grpGeneral2.Controls.Add(this.txtLastTranCode);
            this.grpGeneral2.Controls.Add(this.lblOldLocation4);
            this.grpGeneral2.Controls.Add(this.txtTableSlot);
            this.grpGeneral2.Controls.Add(this.lblLocation4);
            this.grpGeneral2.Controls.Add(this.txtUseAreaID);
            this.grpGeneral2.Controls.Add(this.lblLastTranCode);
            this.grpGeneral2.Controls.Add(this.lblTableSlot);
            this.grpGeneral2.Controls.Add(this.lblUseAreaID);
            this.grpGeneral2.Controls.Add(this.txtStockInTime);
            this.grpGeneral2.Controls.Add(this.lblStockInTime);
            this.grpGeneral2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral2.Location = new System.Drawing.Point(3, 3);
            this.grpGeneral2.Name = "grpGeneral2";
            this.grpGeneral2.Size = new System.Drawing.Size(486, 382);
            this.grpGeneral2.TabIndex = 0;
            this.grpGeneral2.TabStop = false;
            // 
            // txtOldLocation3
            // 
            this.txtOldLocation3.Location = new System.Drawing.Point(362, 187);
            this.txtOldLocation3.MaxLength = 20;
            this.txtOldLocation3.Name = "txtOldLocation3";
            this.txtOldLocation3.ReadOnly = true;
            this.txtOldLocation3.Size = new System.Drawing.Size(116, 20);
            this.txtOldLocation3.TabIndex = 180;
            this.txtOldLocation3.TabStop = false;
            // 
            // txtLocation3
            // 
            this.txtLocation3.Location = new System.Drawing.Point(362, 67);
            this.txtLocation3.MaxLength = 20;
            this.txtLocation3.Name = "txtLocation3";
            this.txtLocation3.ReadOnly = true;
            this.txtLocation3.Size = new System.Drawing.Size(116, 20);
            this.txtLocation3.TabIndex = 170;
            this.txtLocation3.TabStop = false;
            // 
            // txtLastHistSeq
            // 
            this.txtLastHistSeq.Location = new System.Drawing.Point(119, 211);
            this.txtLastHistSeq.MaxLength = 10;
            this.txtLastHistSeq.Name = "txtLastHistSeq";
            this.txtLastHistSeq.ReadOnly = true;
            this.txtLastHistSeq.Size = new System.Drawing.Size(116, 20);
            this.txtLastHistSeq.TabIndex = 158;
            this.txtLastHistSeq.TabStop = false;
            // 
            // txtElapseUsageTime
            // 
            this.txtElapseUsageTime.Location = new System.Drawing.Point(119, 91);
            this.txtElapseUsageTime.MaxLength = 30;
            this.txtElapseUsageTime.Name = "txtElapseUsageTime";
            this.txtElapseUsageTime.ReadOnly = true;
            this.txtElapseUsageTime.Size = new System.Drawing.Size(116, 20);
            this.txtElapseUsageTime.TabIndex = 148;
            this.txtElapseUsageTime.TabStop = false;
            // 
            // lblOldLocation3
            // 
            this.lblOldLocation3.AutoSize = true;
            this.lblOldLocation3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOldLocation3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOldLocation3.Location = new System.Drawing.Point(254, 191);
            this.lblOldLocation3.Name = "lblOldLocation3";
            this.lblOldLocation3.Size = new System.Drawing.Size(76, 13);
            this.lblOldLocation3.TabIndex = 179;
            this.lblOldLocation3.Text = "Old Location 3";
            // 
            // lblLocation3
            // 
            this.lblLocation3.AutoSize = true;
            this.lblLocation3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation3.Location = new System.Drawing.Point(254, 71);
            this.lblLocation3.Name = "lblLocation3";
            this.lblLocation3.Size = new System.Drawing.Size(57, 13);
            this.lblLocation3.TabIndex = 169;
            this.lblLocation3.Text = "Location 3";
            // 
            // lblLastHistSeq
            // 
            this.lblLastHistSeq.AutoSize = true;
            this.lblLastHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastHistSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastHistSeq.Location = new System.Drawing.Point(10, 215);
            this.lblLastHistSeq.Name = "lblLastHistSeq";
            this.lblLastHistSeq.Size = new System.Drawing.Size(70, 13);
            this.lblLastHistSeq.TabIndex = 157;
            this.lblLastHistSeq.Text = "Last Hist Seq";
            // 
            // lblElapseUsageTime
            // 
            this.lblElapseUsageTime.AutoSize = true;
            this.lblElapseUsageTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblElapseUsageTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblElapseUsageTime.Location = new System.Drawing.Point(10, 95);
            this.lblElapseUsageTime.Name = "lblElapseUsageTime";
            this.lblElapseUsageTime.Size = new System.Drawing.Size(99, 13);
            this.lblElapseUsageTime.TabIndex = 147;
            this.lblElapseUsageTime.Text = "Elapse Usage Time";
            // 
            // txtOldSubResourceID
            // 
            this.txtOldSubResourceID.Location = new System.Drawing.Point(362, 306);
            this.txtOldSubResourceID.MaxLength = 10;
            this.txtOldSubResourceID.Name = "txtOldSubResourceID";
            this.txtOldSubResourceID.ReadOnly = true;
            this.txtOldSubResourceID.Size = new System.Drawing.Size(116, 20);
            this.txtOldSubResourceID.TabIndex = 190;
            this.txtOldSubResourceID.TabStop = false;
            // 
            // txtOldResourceID
            // 
            this.txtOldResourceID.Location = new System.Drawing.Point(362, 282);
            this.txtOldResourceID.MaxLength = 20;
            this.txtOldResourceID.Name = "txtOldResourceID";
            this.txtOldResourceID.ReadOnly = true;
            this.txtOldResourceID.Size = new System.Drawing.Size(116, 20);
            this.txtOldResourceID.TabIndex = 188;
            this.txtOldResourceID.TabStop = false;
            // 
            // lblSubResourceID
            // 
            this.lblSubResourceID.AutoSize = true;
            this.lblSubResourceID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubResourceID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubResourceID.Location = new System.Drawing.Point(254, 310);
            this.lblSubResourceID.Name = "lblSubResourceID";
            this.lblSubResourceID.Size = new System.Drawing.Size(108, 13);
            this.lblSubResourceID.TabIndex = 189;
            this.lblSubResourceID.Text = "Old Sub Resource ID";
            // 
            // txtOldPortID
            // 
            this.txtOldPortID.Location = new System.Drawing.Point(362, 258);
            this.txtOldPortID.MaxLength = 20;
            this.txtOldPortID.Name = "txtOldPortID";
            this.txtOldPortID.ReadOnly = true;
            this.txtOldPortID.Size = new System.Drawing.Size(116, 20);
            this.txtOldPortID.TabIndex = 186;
            this.txtOldPortID.TabStop = false;
            // 
            // lblOldResourceID
            // 
            this.lblOldResourceID.AutoSize = true;
            this.lblOldResourceID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOldResourceID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOldResourceID.Location = new System.Drawing.Point(254, 286);
            this.lblOldResourceID.Name = "lblOldResourceID";
            this.lblOldResourceID.Size = new System.Drawing.Size(86, 13);
            this.lblOldResourceID.TabIndex = 187;
            this.lblOldResourceID.Text = "Old Resource ID";
            // 
            // lblOldPortID
            // 
            this.lblOldPortID.AutoSize = true;
            this.lblOldPortID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOldPortID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOldPortID.Location = new System.Drawing.Point(254, 262);
            this.lblOldPortID.Name = "lblOldPortID";
            this.lblOldPortID.Size = new System.Drawing.Size(59, 13);
            this.lblOldPortID.TabIndex = 185;
            this.lblOldPortID.Text = "Old Port ID";
            // 
            // txtPlanTerminateTime
            // 
            this.txtPlanTerminateTime.Location = new System.Drawing.Point(119, 283);
            this.txtPlanTerminateTime.MaxLength = 14;
            this.txtPlanTerminateTime.Name = "txtPlanTerminateTime";
            this.txtPlanTerminateTime.ReadOnly = true;
            this.txtPlanTerminateTime.Size = new System.Drawing.Size(116, 20);
            this.txtPlanTerminateTime.TabIndex = 164;
            this.txtPlanTerminateTime.TabStop = false;
            // 
            // txtOldLocation1
            // 
            this.txtOldLocation1.Location = new System.Drawing.Point(362, 139);
            this.txtOldLocation1.MaxLength = 20;
            this.txtOldLocation1.Name = "txtOldLocation1";
            this.txtOldLocation1.ReadOnly = true;
            this.txtOldLocation1.Size = new System.Drawing.Size(116, 20);
            this.txtOldLocation1.TabIndex = 176;
            this.txtOldLocation1.TabStop = false;
            // 
            // lblPlanTerminateTime
            // 
            this.lblPlanTerminateTime.AutoSize = true;
            this.lblPlanTerminateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPlanTerminateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPlanTerminateTime.Location = new System.Drawing.Point(10, 287);
            this.lblPlanTerminateTime.Name = "lblPlanTerminateTime";
            this.lblPlanTerminateTime.Size = new System.Drawing.Size(100, 13);
            this.lblPlanTerminateTime.TabIndex = 163;
            this.lblPlanTerminateTime.Text = "Plan Terminate time";
            // 
            // txtOldLocation2
            // 
            this.txtOldLocation2.Location = new System.Drawing.Point(362, 163);
            this.txtOldLocation2.MaxLength = 20;
            this.txtOldLocation2.Name = "txtOldLocation2";
            this.txtOldLocation2.ReadOnly = true;
            this.txtOldLocation2.Size = new System.Drawing.Size(116, 20);
            this.txtOldLocation2.TabIndex = 178;
            this.txtOldLocation2.TabStop = false;
            // 
            // txtLocation1
            // 
            this.txtLocation1.Location = new System.Drawing.Point(362, 19);
            this.txtLocation1.MaxLength = 20;
            this.txtLocation1.Name = "txtLocation1";
            this.txtLocation1.ReadOnly = true;
            this.txtLocation1.Size = new System.Drawing.Size(116, 20);
            this.txtLocation1.TabIndex = 166;
            this.txtLocation1.TabStop = false;
            // 
            // txtLocation2
            // 
            this.txtLocation2.Location = new System.Drawing.Point(362, 43);
            this.txtLocation2.MaxLength = 20;
            this.txtLocation2.Name = "txtLocation2";
            this.txtLocation2.ReadOnly = true;
            this.txtLocation2.Size = new System.Drawing.Size(116, 20);
            this.txtLocation2.TabIndex = 168;
            this.txtLocation2.TabStop = false;
            // 
            // lblOldLocation1
            // 
            this.lblOldLocation1.AutoSize = true;
            this.lblOldLocation1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOldLocation1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOldLocation1.Location = new System.Drawing.Point(254, 143);
            this.lblOldLocation1.Name = "lblOldLocation1";
            this.lblOldLocation1.Size = new System.Drawing.Size(76, 13);
            this.lblOldLocation1.TabIndex = 175;
            this.lblOldLocation1.Text = "Old Location 1";
            // 
            // txtUseSubAreaID
            // 
            this.txtUseSubAreaID.Location = new System.Drawing.Point(119, 163);
            this.txtUseSubAreaID.MaxLength = 10;
            this.txtUseSubAreaID.Name = "txtUseSubAreaID";
            this.txtUseSubAreaID.ReadOnly = true;
            this.txtUseSubAreaID.Size = new System.Drawing.Size(116, 20);
            this.txtUseSubAreaID.TabIndex = 154;
            this.txtUseSubAreaID.TabStop = false;
            // 
            // lblLocation1
            // 
            this.lblLocation1.AutoSize = true;
            this.lblLocation1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation1.Location = new System.Drawing.Point(254, 22);
            this.lblLocation1.Name = "lblLocation1";
            this.lblLocation1.Size = new System.Drawing.Size(57, 13);
            this.lblLocation1.TabIndex = 165;
            this.lblLocation1.Text = "Location 1";
            // 
            // txtOldLocation5
            // 
            this.txtOldLocation5.Location = new System.Drawing.Point(362, 235);
            this.txtOldLocation5.MaxLength = 20;
            this.txtOldLocation5.Name = "txtOldLocation5";
            this.txtOldLocation5.ReadOnly = true;
            this.txtOldLocation5.Size = new System.Drawing.Size(116, 20);
            this.txtOldLocation5.TabIndex = 184;
            this.txtOldLocation5.TabStop = false;
            // 
            // txtLotHistSeq
            // 
            this.txtLotHistSeq.Location = new System.Drawing.Point(119, 187);
            this.txtLotHistSeq.MaxLength = 10;
            this.txtLotHistSeq.Name = "txtLotHistSeq";
            this.txtLotHistSeq.ReadOnly = true;
            this.txtLotHistSeq.Size = new System.Drawing.Size(116, 20);
            this.txtLotHistSeq.TabIndex = 156;
            this.txtLotHistSeq.TabStop = false;
            // 
            // txtLocation5
            // 
            this.txtLocation5.Location = new System.Drawing.Point(362, 115);
            this.txtLocation5.MaxLength = 20;
            this.txtLocation5.Name = "txtLocation5";
            this.txtLocation5.ReadOnly = true;
            this.txtLocation5.Size = new System.Drawing.Size(116, 20);
            this.txtLocation5.TabIndex = 174;
            this.txtLocation5.TabStop = false;
            // 
            // lblUseSubAreaID
            // 
            this.lblUseSubAreaID.AutoSize = true;
            this.lblUseSubAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUseSubAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUseSubAreaID.Location = new System.Drawing.Point(10, 167);
            this.lblUseSubAreaID.Name = "lblUseSubAreaID";
            this.lblUseSubAreaID.Size = new System.Drawing.Size(87, 13);
            this.lblUseSubAreaID.TabIndex = 153;
            this.lblUseSubAreaID.Text = "Use Sub Area ID";
            // 
            // lblOldLocation2
            // 
            this.lblOldLocation2.AutoSize = true;
            this.lblOldLocation2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOldLocation2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOldLocation2.Location = new System.Drawing.Point(254, 167);
            this.lblOldLocation2.Name = "lblOldLocation2";
            this.lblOldLocation2.Size = new System.Drawing.Size(76, 13);
            this.lblOldLocation2.TabIndex = 177;
            this.lblOldLocation2.Text = "Old Location 2";
            // 
            // txtLastTranTime
            // 
            this.txtLastTranTime.Location = new System.Drawing.Point(119, 259);
            this.txtLastTranTime.MaxLength = 30;
            this.txtLastTranTime.Name = "txtLastTranTime";
            this.txtLastTranTime.ReadOnly = true;
            this.txtLastTranTime.Size = new System.Drawing.Size(116, 20);
            this.txtLastTranTime.TabIndex = 162;
            this.txtLastTranTime.TabStop = false;
            // 
            // lblLocation2
            // 
            this.lblLocation2.AutoSize = true;
            this.lblLocation2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation2.Location = new System.Drawing.Point(254, 47);
            this.lblLocation2.Name = "lblLocation2";
            this.lblLocation2.Size = new System.Drawing.Size(57, 13);
            this.lblLocation2.TabIndex = 167;
            this.lblLocation2.Text = "Location 2";
            // 
            // txtUsageLimitTime
            // 
            this.txtUsageLimitTime.Location = new System.Drawing.Point(119, 67);
            this.txtUsageLimitTime.MaxLength = 30;
            this.txtUsageLimitTime.Name = "txtUsageLimitTime";
            this.txtUsageLimitTime.ReadOnly = true;
            this.txtUsageLimitTime.Size = new System.Drawing.Size(116, 20);
            this.txtUsageLimitTime.TabIndex = 146;
            this.txtUsageLimitTime.TabStop = false;
            // 
            // lblOldLocation5
            // 
            this.lblOldLocation5.AutoSize = true;
            this.lblOldLocation5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOldLocation5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOldLocation5.Location = new System.Drawing.Point(254, 239);
            this.lblOldLocation5.Name = "lblOldLocation5";
            this.lblOldLocation5.Size = new System.Drawing.Size(76, 13);
            this.lblOldLocation5.TabIndex = 183;
            this.lblOldLocation5.Text = "Old Location 5";
            // 
            // lblLotHistSeq
            // 
            this.lblLotHistSeq.AutoSize = true;
            this.lblLotHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotHistSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotHistSeq.Location = new System.Drawing.Point(10, 191);
            this.lblLotHistSeq.Name = "lblLotHistSeq";
            this.lblLotHistSeq.Size = new System.Drawing.Size(65, 13);
            this.lblLotHistSeq.TabIndex = 155;
            this.lblLotHistSeq.Text = "Lot Hist Seq";
            // 
            // lblLocation5
            // 
            this.lblLocation5.AutoSize = true;
            this.lblLocation5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation5.Location = new System.Drawing.Point(254, 119);
            this.lblLocation5.Name = "lblLocation5";
            this.lblLocation5.Size = new System.Drawing.Size(57, 13);
            this.lblLocation5.TabIndex = 173;
            this.lblLocation5.Text = "Location 5";
            // 
            // txtUseResourceID
            // 
            this.txtUseResourceID.Location = new System.Drawing.Point(119, 139);
            this.txtUseResourceID.MaxLength = 20;
            this.txtUseResourceID.Name = "txtUseResourceID";
            this.txtUseResourceID.ReadOnly = true;
            this.txtUseResourceID.Size = new System.Drawing.Size(116, 20);
            this.txtUseResourceID.TabIndex = 152;
            this.txtUseResourceID.TabStop = false;
            // 
            // lblLstTranTime
            // 
            this.lblLstTranTime.AutoSize = true;
            this.lblLstTranTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLstTranTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLstTranTime.Location = new System.Drawing.Point(10, 263);
            this.lblLstTranTime.Name = "lblLstTranTime";
            this.lblLstTranTime.Size = new System.Drawing.Size(78, 13);
            this.lblLstTranTime.TabIndex = 161;
            this.lblLstTranTime.Text = "Last Tran Time";
            // 
            // txtOldLocation4
            // 
            this.txtOldLocation4.Location = new System.Drawing.Point(362, 211);
            this.txtOldLocation4.MaxLength = 20;
            this.txtOldLocation4.Name = "txtOldLocation4";
            this.txtOldLocation4.ReadOnly = true;
            this.txtOldLocation4.Size = new System.Drawing.Size(116, 20);
            this.txtOldLocation4.TabIndex = 182;
            this.txtOldLocation4.TabStop = false;
            // 
            // lblUsageLimitTime
            // 
            this.lblUsageLimitTime.AutoSize = true;
            this.lblUsageLimitTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUsageLimitTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUsageLimitTime.Location = new System.Drawing.Point(10, 71);
            this.lblUsageLimitTime.Name = "lblUsageLimitTime";
            this.lblUsageLimitTime.Size = new System.Drawing.Size(88, 13);
            this.lblUsageLimitTime.TabIndex = 145;
            this.lblUsageLimitTime.Text = "Usage Limit Time";
            // 
            // txtLocation4
            // 
            this.txtLocation4.Location = new System.Drawing.Point(362, 91);
            this.txtLocation4.MaxLength = 20;
            this.txtLocation4.Name = "txtLocation4";
            this.txtLocation4.ReadOnly = true;
            this.txtLocation4.Size = new System.Drawing.Size(116, 20);
            this.txtLocation4.TabIndex = 172;
            this.txtLocation4.TabStop = false;
            // 
            // lblUseResourceID
            // 
            this.lblUseResourceID.AutoSize = true;
            this.lblUseResourceID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUseResourceID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUseResourceID.Location = new System.Drawing.Point(10, 143);
            this.lblUseResourceID.Name = "lblUseResourceID";
            this.lblUseResourceID.Size = new System.Drawing.Size(89, 13);
            this.lblUseResourceID.TabIndex = 151;
            this.lblUseResourceID.Text = "Use Resource ID";
            // 
            // txtLastTranCode
            // 
            this.txtLastTranCode.Location = new System.Drawing.Point(119, 235);
            this.txtLastTranCode.MaxLength = 12;
            this.txtLastTranCode.Name = "txtLastTranCode";
            this.txtLastTranCode.ReadOnly = true;
            this.txtLastTranCode.Size = new System.Drawing.Size(116, 20);
            this.txtLastTranCode.TabIndex = 160;
            this.txtLastTranCode.TabStop = false;
            // 
            // lblOldLocation4
            // 
            this.lblOldLocation4.AutoSize = true;
            this.lblOldLocation4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOldLocation4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOldLocation4.Location = new System.Drawing.Point(254, 214);
            this.lblOldLocation4.Name = "lblOldLocation4";
            this.lblOldLocation4.Size = new System.Drawing.Size(76, 13);
            this.lblOldLocation4.TabIndex = 181;
            this.lblOldLocation4.Text = "Old Location 4";
            // 
            // txtTableSlot
            // 
            this.txtTableSlot.Location = new System.Drawing.Point(119, 43);
            this.txtTableSlot.MaxLength = 100;
            this.txtTableSlot.Name = "txtTableSlot";
            this.txtTableSlot.ReadOnly = true;
            this.txtTableSlot.Size = new System.Drawing.Size(116, 20);
            this.txtTableSlot.TabIndex = 144;
            this.txtTableSlot.TabStop = false;
            // 
            // lblLocation4
            // 
            this.lblLocation4.AutoSize = true;
            this.lblLocation4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation4.Location = new System.Drawing.Point(254, 94);
            this.lblLocation4.Name = "lblLocation4";
            this.lblLocation4.Size = new System.Drawing.Size(57, 13);
            this.lblLocation4.TabIndex = 171;
            this.lblLocation4.Text = "Location 4";
            // 
            // txtUseAreaID
            // 
            this.txtUseAreaID.Location = new System.Drawing.Point(119, 115);
            this.txtUseAreaID.MaxLength = 20;
            this.txtUseAreaID.Name = "txtUseAreaID";
            this.txtUseAreaID.ReadOnly = true;
            this.txtUseAreaID.Size = new System.Drawing.Size(116, 20);
            this.txtUseAreaID.TabIndex = 150;
            this.txtUseAreaID.TabStop = false;
            // 
            // lblLastTranCode
            // 
            this.lblLastTranCode.AutoSize = true;
            this.lblLastTranCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastTranCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastTranCode.Location = new System.Drawing.Point(10, 238);
            this.lblLastTranCode.Name = "lblLastTranCode";
            this.lblLastTranCode.Size = new System.Drawing.Size(80, 13);
            this.lblLastTranCode.TabIndex = 159;
            this.lblLastTranCode.Text = "Last Tran Code";
            // 
            // lblTableSlot
            // 
            this.lblTableSlot.AutoSize = true;
            this.lblTableSlot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTableSlot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTableSlot.Location = new System.Drawing.Point(10, 47);
            this.lblTableSlot.Name = "lblTableSlot";
            this.lblTableSlot.Size = new System.Drawing.Size(55, 13);
            this.lblTableSlot.TabIndex = 143;
            this.lblTableSlot.Text = "Table Slot";
            // 
            // lblUseAreaID
            // 
            this.lblUseAreaID.AutoSize = true;
            this.lblUseAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUseAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUseAreaID.Location = new System.Drawing.Point(10, 118);
            this.lblUseAreaID.Name = "lblUseAreaID";
            this.lblUseAreaID.Size = new System.Drawing.Size(65, 13);
            this.lblUseAreaID.TabIndex = 149;
            this.lblUseAreaID.Text = "Use Area ID";
            // 
            // txtStockInTime
            // 
            this.txtStockInTime.Location = new System.Drawing.Point(119, 19);
            this.txtStockInTime.MaxLength = 30;
            this.txtStockInTime.Name = "txtStockInTime";
            this.txtStockInTime.ReadOnly = true;
            this.txtStockInTime.Size = new System.Drawing.Size(116, 20);
            this.txtStockInTime.TabIndex = 142;
            this.txtStockInTime.TabStop = false;
            // 
            // lblStockInTime
            // 
            this.lblStockInTime.AutoSize = true;
            this.lblStockInTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStockInTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStockInTime.Location = new System.Drawing.Point(10, 22);
            this.lblStockInTime.Name = "lblStockInTime";
            this.lblStockInTime.Size = new System.Drawing.Size(72, 13);
            this.lblStockInTime.TabIndex = 141;
            this.lblStockInTime.Text = "Stock in Time";
            // 
            // tbpAttribute
            // 
            this.tbpAttribute.BackColor = System.Drawing.SystemColors.Control;
            this.tbpAttribute.Controls.Add(this.udcAttributeStatus);
            this.tbpAttribute.Location = new System.Drawing.Point(4, 22);
            this.tbpAttribute.Name = "tbpAttribute";
            this.tbpAttribute.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAttribute.Size = new System.Drawing.Size(492, 389);
            this.tbpAttribute.TabIndex = 3;
            this.tbpAttribute.Text = "Attribute";
            // 
            // udcAttributeStatus
            // 
            this.udcAttributeStatus.AttributeFactory = "";
            this.udcAttributeStatus.AttributeKey = "";
            this.udcAttributeStatus.AttributeLayout = Miracom.BASCore.udcAttributeStatus.udcAttributeStatusLayout.VIEW;
            this.udcAttributeStatus.AttributeName = "";
            this.udcAttributeStatus.AttributeType = "CARRIER";
            this.udcAttributeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcAttributeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcAttributeStatus.FromSequence = 0;
            this.udcAttributeStatus.Location = new System.Drawing.Point(3, 3);
            this.udcAttributeStatus.Name = "udcAttributeStatus";
            this.udcAttributeStatus.Size = new System.Drawing.Size(486, 383);
            this.udcAttributeStatus.TabIndex = 1;
            this.udcAttributeStatus.ToSequence = 2147483647;
            // 
            // tbpLotList
            // 
            this.tbpLotList.BackColor = System.Drawing.SystemColors.Control;
            this.tbpLotList.Controls.Add(this.grpLotList);
            this.tbpLotList.Location = new System.Drawing.Point(4, 22);
            this.tbpLotList.Name = "tbpLotList";
            this.tbpLotList.Padding = new System.Windows.Forms.Padding(3);
            this.tbpLotList.Size = new System.Drawing.Size(492, 388);
            this.tbpLotList.TabIndex = 4;
            this.tbpLotList.Text = "Lot List";
            // 
            // grpLotList
            // 
            this.grpLotList.Controls.Add(this.lisLotList);
            this.grpLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotList.Location = new System.Drawing.Point(3, 3);
            this.grpLotList.Name = "grpLotList";
            this.grpLotList.Size = new System.Drawing.Size(486, 382);
            this.grpLotList.TabIndex = 0;
            this.grpLotList.TabStop = false;
            // 
            // lisLotList
            // 
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLotID,
            this.colQty1,
            this.colAQty1,
            this.colNQty1,
            this.colQty2,
            this.colAQty2,
            this.colNQty2,
            this.colQty3,
            this.colAQty3,
            this.colNQty3});
            this.lisLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotList.EnableSort = true;
            this.lisLotList.EnableSortIcon = true;
            this.lisLotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLotList.FullRowSelect = true;
            this.lisLotList.Location = new System.Drawing.Point(3, 16);
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(480, 363);
            this.lisLotList.TabIndex = 1;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 100;
            // 
            // colQty1
            // 
            this.colQty1.Text = "Qty 1";
            this.colQty1.Width = 55;
            // 
            // colAQty1
            // 
            this.colAQty1.Text = "Att Qty 1";
            this.colAQty1.Width = 55;
            // 
            // colNQty1
            // 
            this.colNQty1.Text = "N-Att Qty 1";
            this.colNQty1.Width = 55;
            // 
            // colQty2
            // 
            this.colQty2.Text = "Qty 2";
            this.colQty2.Width = 55;
            // 
            // colAQty2
            // 
            this.colAQty2.Text = "Att Qty 2";
            this.colAQty2.Width = 55;
            // 
            // colNQty2
            // 
            this.colNQty2.Text = "N-Att Qty 2";
            this.colNQty2.Width = 55;
            // 
            // colQty3
            // 
            this.colQty3.Text = "Qty 3";
            this.colQty3.Width = 55;
            // 
            // colAQty3
            // 
            this.colAQty3.Text = "Att Qty 3";
            this.colAQty3.Width = 55;
            // 
            // colNQty3
            // 
            this.colNQty3.Text = "N-Att Qty 3";
            this.colNQty3.Width = 55;
            // 
            // tbpSlotMap
            // 
            this.tbpSlotMap.BackColor = System.Drawing.SystemColors.Control;
            this.tbpSlotMap.Controls.Add(this.grpSlotMap);
            this.tbpSlotMap.Location = new System.Drawing.Point(4, 22);
            this.tbpSlotMap.Name = "tbpSlotMap";
            this.tbpSlotMap.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSlotMap.Size = new System.Drawing.Size(492, 388);
            this.tbpSlotMap.TabIndex = 5;
            this.tbpSlotMap.Text = "Slot Map";
            // 
            // grpSlotMap
            // 
            this.grpSlotMap.Controls.Add(this.lisSlotMap);
            this.grpSlotMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSlotMap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSlotMap.Location = new System.Drawing.Point(3, 3);
            this.grpSlotMap.Name = "grpSlotMap";
            this.grpSlotMap.Size = new System.Drawing.Size(486, 382);
            this.grpSlotMap.TabIndex = 3;
            this.grpSlotMap.TabStop = false;
            // 
            // lisSlotMap
            // 
            this.lisSlotMap.AllowDrop = true;
            this.lisSlotMap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSlot1,
            this.colSubLot1,
            this.colLot1,
            this.colGrade});
            this.lisSlotMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSlotMap.EnableSort = true;
            this.lisSlotMap.EnableSortIcon = true;
            this.lisSlotMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSlotMap.FullRowSelect = true;
            this.lisSlotMap.Location = new System.Drawing.Point(3, 16);
            this.lisSlotMap.Name = "lisSlotMap";
            this.lisSlotMap.Size = new System.Drawing.Size(480, 363);
            this.lisSlotMap.TabIndex = 2;
            this.lisSlotMap.UseCompatibleStateImageBehavior = false;
            this.lisSlotMap.View = System.Windows.Forms.View.Details;
            // 
            // colSlot1
            // 
            this.colSlot1.Text = "Slot No";
            // 
            // colSubLot1
            // 
            this.colSubLot1.Text = "SubLot ID";
            this.colSubLot1.Width = 120;
            // 
            // colLot1
            // 
            this.colLot1.Text = "Lot ID";
            this.colLot1.Width = 100;
            // 
            // colGrade
            // 
            this.colGrade.Text = "Grade";
            // 
            // tbpCrtCmfField
            // 
            this.tbpCrtCmfField.BackColor = System.Drawing.SystemColors.Control;
            this.tbpCrtCmfField.Controls.Add(this.grpCmf);
            this.tbpCrtCmfField.Location = new System.Drawing.Point(4, 22);
            this.tbpCrtCmfField.Name = "tbpCrtCmfField";
            this.tbpCrtCmfField.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCrtCmfField.Size = new System.Drawing.Size(492, 388);
            this.tbpCrtCmfField.TabIndex = 2;
            this.tbpCrtCmfField.Text = "Customized Field";
            // 
            // grpCmf
            // 
            this.grpCmf.Controls.Add(this.txtCmf17);
            this.grpCmf.Controls.Add(this.txtCmf15);
            this.grpCmf.Controls.Add(this.txtCmf20);
            this.grpCmf.Controls.Add(this.txtCmf19);
            this.grpCmf.Controls.Add(this.txtCmf18);
            this.grpCmf.Controls.Add(this.txtCmf16);
            this.grpCmf.Controls.Add(this.txtCmf14);
            this.grpCmf.Controls.Add(this.txtCmf13);
            this.grpCmf.Controls.Add(this.txtCmf12);
            this.grpCmf.Controls.Add(this.txtCmf11);
            this.grpCmf.Controls.Add(this.lblCMF20);
            this.grpCmf.Controls.Add(this.lblCMF19);
            this.grpCmf.Controls.Add(this.lblCMF18);
            this.grpCmf.Controls.Add(this.lblCMF17);
            this.grpCmf.Controls.Add(this.lblCMF16);
            this.grpCmf.Controls.Add(this.lblCMF15);
            this.grpCmf.Controls.Add(this.lblCMF14);
            this.grpCmf.Controls.Add(this.lblCMF13);
            this.grpCmf.Controls.Add(this.lblCMF12);
            this.grpCmf.Controls.Add(this.lblCMF11);
            this.grpCmf.Controls.Add(this.txtCmf7);
            this.grpCmf.Controls.Add(this.txtCmf5);
            this.grpCmf.Controls.Add(this.txtCmf10);
            this.grpCmf.Controls.Add(this.txtCmf9);
            this.grpCmf.Controls.Add(this.txtCmf8);
            this.grpCmf.Controls.Add(this.txtCmf6);
            this.grpCmf.Controls.Add(this.txtCmf4);
            this.grpCmf.Controls.Add(this.txtCmf3);
            this.grpCmf.Controls.Add(this.txtCmf2);
            this.grpCmf.Controls.Add(this.txtCmf1);
            this.grpCmf.Controls.Add(this.lblCMF10);
            this.grpCmf.Controls.Add(this.lblCMF9);
            this.grpCmf.Controls.Add(this.lblCMF8);
            this.grpCmf.Controls.Add(this.lblCMF7);
            this.grpCmf.Controls.Add(this.lblCMF6);
            this.grpCmf.Controls.Add(this.lblCMF5);
            this.grpCmf.Controls.Add(this.lblCMF4);
            this.grpCmf.Controls.Add(this.lblCMF3);
            this.grpCmf.Controls.Add(this.lblCMF2);
            this.grpCmf.Controls.Add(this.lblCMF1);
            this.grpCmf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCmf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCmf.Location = new System.Drawing.Point(3, 3);
            this.grpCmf.Name = "grpCmf";
            this.grpCmf.Size = new System.Drawing.Size(486, 382);
            this.grpCmf.TabIndex = 0;
            this.grpCmf.TabStop = false;
            // 
            // txtCmf17
            // 
            this.txtCmf17.Location = new System.Drawing.Point(350, 165);
            this.txtCmf17.MaxLength = 30;
            this.txtCmf17.Name = "txtCmf17";
            this.txtCmf17.ReadOnly = true;
            this.txtCmf17.Size = new System.Drawing.Size(130, 20);
            this.txtCmf17.TabIndex = 93;
            this.txtCmf17.TabStop = false;
            // 
            // txtCmf15
            // 
            this.txtCmf15.Location = new System.Drawing.Point(350, 117);
            this.txtCmf15.MaxLength = 30;
            this.txtCmf15.Name = "txtCmf15";
            this.txtCmf15.ReadOnly = true;
            this.txtCmf15.Size = new System.Drawing.Size(130, 20);
            this.txtCmf15.TabIndex = 89;
            this.txtCmf15.TabStop = false;
            // 
            // txtCmf20
            // 
            this.txtCmf20.Location = new System.Drawing.Point(350, 237);
            this.txtCmf20.MaxLength = 30;
            this.txtCmf20.Name = "txtCmf20";
            this.txtCmf20.ReadOnly = true;
            this.txtCmf20.Size = new System.Drawing.Size(130, 20);
            this.txtCmf20.TabIndex = 99;
            this.txtCmf20.TabStop = false;
            // 
            // txtCmf19
            // 
            this.txtCmf19.Location = new System.Drawing.Point(350, 213);
            this.txtCmf19.MaxLength = 30;
            this.txtCmf19.Name = "txtCmf19";
            this.txtCmf19.ReadOnly = true;
            this.txtCmf19.Size = new System.Drawing.Size(130, 20);
            this.txtCmf19.TabIndex = 97;
            this.txtCmf19.TabStop = false;
            // 
            // txtCmf18
            // 
            this.txtCmf18.Location = new System.Drawing.Point(350, 189);
            this.txtCmf18.MaxLength = 30;
            this.txtCmf18.Name = "txtCmf18";
            this.txtCmf18.ReadOnly = true;
            this.txtCmf18.Size = new System.Drawing.Size(130, 20);
            this.txtCmf18.TabIndex = 95;
            this.txtCmf18.TabStop = false;
            // 
            // txtCmf16
            // 
            this.txtCmf16.Location = new System.Drawing.Point(350, 141);
            this.txtCmf16.MaxLength = 30;
            this.txtCmf16.Name = "txtCmf16";
            this.txtCmf16.ReadOnly = true;
            this.txtCmf16.Size = new System.Drawing.Size(130, 20);
            this.txtCmf16.TabIndex = 91;
            this.txtCmf16.TabStop = false;
            // 
            // txtCmf14
            // 
            this.txtCmf14.Location = new System.Drawing.Point(350, 93);
            this.txtCmf14.MaxLength = 30;
            this.txtCmf14.Name = "txtCmf14";
            this.txtCmf14.ReadOnly = true;
            this.txtCmf14.Size = new System.Drawing.Size(130, 20);
            this.txtCmf14.TabIndex = 87;
            this.txtCmf14.TabStop = false;
            // 
            // txtCmf13
            // 
            this.txtCmf13.Location = new System.Drawing.Point(350, 69);
            this.txtCmf13.MaxLength = 30;
            this.txtCmf13.Name = "txtCmf13";
            this.txtCmf13.ReadOnly = true;
            this.txtCmf13.Size = new System.Drawing.Size(130, 20);
            this.txtCmf13.TabIndex = 85;
            this.txtCmf13.TabStop = false;
            // 
            // txtCmf12
            // 
            this.txtCmf12.Location = new System.Drawing.Point(350, 45);
            this.txtCmf12.MaxLength = 30;
            this.txtCmf12.Name = "txtCmf12";
            this.txtCmf12.ReadOnly = true;
            this.txtCmf12.Size = new System.Drawing.Size(130, 20);
            this.txtCmf12.TabIndex = 83;
            this.txtCmf12.TabStop = false;
            // 
            // txtCmf11
            // 
            this.txtCmf11.Location = new System.Drawing.Point(350, 21);
            this.txtCmf11.MaxLength = 30;
            this.txtCmf11.Name = "txtCmf11";
            this.txtCmf11.ReadOnly = true;
            this.txtCmf11.Size = new System.Drawing.Size(130, 20);
            this.txtCmf11.TabIndex = 81;
            this.txtCmf11.TabStop = false;
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF20.Location = new System.Drawing.Point(254, 238);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(90, 14);
            this.lblCMF20.TabIndex = 98;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF19.Location = new System.Drawing.Point(254, 214);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(90, 14);
            this.lblCMF19.TabIndex = 96;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF18.Location = new System.Drawing.Point(254, 190);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(90, 14);
            this.lblCMF18.TabIndex = 94;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF17.Location = new System.Drawing.Point(254, 166);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(90, 14);
            this.lblCMF17.TabIndex = 92;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF16.Location = new System.Drawing.Point(254, 142);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(90, 14);
            this.lblCMF16.TabIndex = 90;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF15.Location = new System.Drawing.Point(254, 118);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(90, 14);
            this.lblCMF15.TabIndex = 88;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF14.Location = new System.Drawing.Point(254, 94);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(90, 14);
            this.lblCMF14.TabIndex = 86;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF13.Location = new System.Drawing.Point(254, 70);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(90, 14);
            this.lblCMF13.TabIndex = 84;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF12.Location = new System.Drawing.Point(254, 46);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(90, 14);
            this.lblCMF12.TabIndex = 82;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF11.Location = new System.Drawing.Point(254, 23);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(90, 14);
            this.lblCMF11.TabIndex = 80;
            // 
            // txtCmf7
            // 
            this.txtCmf7.Location = new System.Drawing.Point(108, 166);
            this.txtCmf7.MaxLength = 30;
            this.txtCmf7.Name = "txtCmf7";
            this.txtCmf7.ReadOnly = true;
            this.txtCmf7.Size = new System.Drawing.Size(130, 20);
            this.txtCmf7.TabIndex = 73;
            this.txtCmf7.TabStop = false;
            // 
            // txtCmf5
            // 
            this.txtCmf5.Location = new System.Drawing.Point(108, 118);
            this.txtCmf5.MaxLength = 30;
            this.txtCmf5.Name = "txtCmf5";
            this.txtCmf5.ReadOnly = true;
            this.txtCmf5.Size = new System.Drawing.Size(130, 20);
            this.txtCmf5.TabIndex = 69;
            this.txtCmf5.TabStop = false;
            // 
            // txtCmf10
            // 
            this.txtCmf10.Location = new System.Drawing.Point(108, 238);
            this.txtCmf10.MaxLength = 30;
            this.txtCmf10.Name = "txtCmf10";
            this.txtCmf10.ReadOnly = true;
            this.txtCmf10.Size = new System.Drawing.Size(130, 20);
            this.txtCmf10.TabIndex = 79;
            this.txtCmf10.TabStop = false;
            // 
            // txtCmf9
            // 
            this.txtCmf9.Location = new System.Drawing.Point(108, 214);
            this.txtCmf9.MaxLength = 30;
            this.txtCmf9.Name = "txtCmf9";
            this.txtCmf9.ReadOnly = true;
            this.txtCmf9.Size = new System.Drawing.Size(130, 20);
            this.txtCmf9.TabIndex = 77;
            this.txtCmf9.TabStop = false;
            // 
            // txtCmf8
            // 
            this.txtCmf8.Location = new System.Drawing.Point(108, 190);
            this.txtCmf8.MaxLength = 30;
            this.txtCmf8.Name = "txtCmf8";
            this.txtCmf8.ReadOnly = true;
            this.txtCmf8.Size = new System.Drawing.Size(130, 20);
            this.txtCmf8.TabIndex = 75;
            this.txtCmf8.TabStop = false;
            // 
            // txtCmf6
            // 
            this.txtCmf6.Location = new System.Drawing.Point(108, 142);
            this.txtCmf6.MaxLength = 30;
            this.txtCmf6.Name = "txtCmf6";
            this.txtCmf6.ReadOnly = true;
            this.txtCmf6.Size = new System.Drawing.Size(130, 20);
            this.txtCmf6.TabIndex = 71;
            this.txtCmf6.TabStop = false;
            // 
            // txtCmf4
            // 
            this.txtCmf4.Location = new System.Drawing.Point(108, 94);
            this.txtCmf4.MaxLength = 30;
            this.txtCmf4.Name = "txtCmf4";
            this.txtCmf4.ReadOnly = true;
            this.txtCmf4.Size = new System.Drawing.Size(130, 20);
            this.txtCmf4.TabIndex = 67;
            this.txtCmf4.TabStop = false;
            // 
            // txtCmf3
            // 
            this.txtCmf3.Location = new System.Drawing.Point(108, 70);
            this.txtCmf3.MaxLength = 30;
            this.txtCmf3.Name = "txtCmf3";
            this.txtCmf3.ReadOnly = true;
            this.txtCmf3.Size = new System.Drawing.Size(130, 20);
            this.txtCmf3.TabIndex = 65;
            this.txtCmf3.TabStop = false;
            // 
            // txtCmf2
            // 
            this.txtCmf2.Location = new System.Drawing.Point(108, 46);
            this.txtCmf2.MaxLength = 30;
            this.txtCmf2.Name = "txtCmf2";
            this.txtCmf2.ReadOnly = true;
            this.txtCmf2.Size = new System.Drawing.Size(130, 20);
            this.txtCmf2.TabIndex = 63;
            this.txtCmf2.TabStop = false;
            // 
            // txtCmf1
            // 
            this.txtCmf1.Location = new System.Drawing.Point(108, 21);
            this.txtCmf1.MaxLength = 30;
            this.txtCmf1.Name = "txtCmf1";
            this.txtCmf1.ReadOnly = true;
            this.txtCmf1.Size = new System.Drawing.Size(130, 20);
            this.txtCmf1.TabIndex = 61;
            this.txtCmf1.TabStop = false;
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF10.Location = new System.Drawing.Point(12, 240);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(90, 14);
            this.lblCMF10.TabIndex = 78;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF9.Location = new System.Drawing.Point(12, 216);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(90, 14);
            this.lblCMF9.TabIndex = 76;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF8.Location = new System.Drawing.Point(12, 192);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(90, 14);
            this.lblCMF8.TabIndex = 74;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF7.Location = new System.Drawing.Point(12, 168);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(90, 14);
            this.lblCMF7.TabIndex = 72;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF6.Location = new System.Drawing.Point(12, 144);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(90, 14);
            this.lblCMF6.TabIndex = 70;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF5.Location = new System.Drawing.Point(12, 120);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(90, 14);
            this.lblCMF5.TabIndex = 68;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF4.Location = new System.Drawing.Point(12, 96);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(90, 14);
            this.lblCMF4.TabIndex = 66;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF3.Location = new System.Drawing.Point(12, 72);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(90, 14);
            this.lblCMF3.TabIndex = 64;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF2.Location = new System.Drawing.Point(12, 48);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(90, 14);
            this.lblCMF2.TabIndex = 62;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF1.Location = new System.Drawing.Point(12, 25);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(90, 14);
            this.lblCMF1.TabIndex = 60;
            // 
            // frmRASTranCleanCarrier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASTranCleanCarrier";
            this.Text = "Clean Carrier";
            this.VisibleFilterBox = true;
            this.Activated += new System.EventHandler(this.frmRASTranCleanCarrier_Activated);
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).EndInit();
            this.grpCarrier.ResumeLayout(false);
            this.grpCarrier.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.tabCarrierStatus.ResumeLayout(false);
            this.tbpGeneral1.ResumeLayout(false);
            this.grpGeneral1.ResumeLayout(false);
            this.grpGeneral1.PerformLayout();
            this.tbpGeneral2.ResumeLayout(false);
            this.tbpGeneral2.PerformLayout();
            this.grpGeneral2.ResumeLayout(false);
            this.grpGeneral2.PerformLayout();
            this.tbpAttribute.ResumeLayout(false);
            this.tbpLotList.ResumeLayout(false);
            this.grpLotList.ResumeLayout(false);
            this.tbpSlotMap.ResumeLayout(false);
            this.grpSlotMap.ResumeLayout(false);
            this.tbpCrtCmfField.ResumeLayout(false);
            this.grpCmf.ResumeLayout(false);
            this.grpCmf.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
                    
        #region " Variable definition "
        //start #Temp
        private const string MP_CRR_CLEAN = "CLEAN";
        //End #Temp
        bool b_load_flag;
        #endregion

        #region " Function definition"

        // InitCmfControl()
        //       - Initial Cmf Control
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void InitCmfControl()
        {
            ArrayList controls;
            int i;

            controls = MPCF.GetIndexedControl("lblCMF", grpCmf);
            for (i = 0; i <= controls.Count - 1; i++)
            {
                ((Label)controls[i]).Visible = false;
                ((Label)controls[i]).Text = "";
            }

            controls = MPCF.GetIndexedControl("txtCMF", grpCmf);
            for (i = 0; i <= controls.Count - 1; i++)
            {
                ((TextBox)controls[i]).Visible = false;
                ((TextBox)controls[i]).Text = "";
            }
        }

        // SetCmfItem()
        //       - Set Cmf Item
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void SetCmfItem()
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ArrayList lblList;
            ArrayList txtList;
            Label lblTemp;
            TextBox txtTemp;
            int i;

            InitCmfControl();

            if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_CARRIER, ref out_node, "", true) == false)
            {
                return;
            }

            lblList = MPCF.GetIndexedControl("lblCmf", grpCmf);
            txtList = MPCF.GetIndexedControl("txtCmf", grpCmf);

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                lblTemp = (Label)lblList[i];
                txtTemp = (TextBox)txtList[i];

                lblTemp.Text = out_node.GetList(0)[i].GetString("PROMPT");
                if (lblTemp.Text != "")
                {
                    lblTemp.Visible = true;
                    txtTemp.Visible = true;
                }
            }
        }


        //
        // View_Carrier()
        //       -  View Carrier
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCarrier(string sCrr)
        {

            TRSNode in_node = new TRSNode("VIEW_CARRIER_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_OUT");

            try
            {
                MPCF.FieldClear(this.pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_ID", MPCF.Trim(sCrr));

                if (MPCR.CallService("RAS", "RAS_View_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }

                udcAttributeStatus.AttributeKey = MPCF.Trim(out_node.GetString("CRR_ID"));

                txtCrrID.Text = MPCF.Trim(out_node.GetString("CRR_ID"));
                txtCrrDesc.Text = MPCF.Trim(out_node.GetString("CRR_DESC"));
                txtCrrType1.Text = MPCF.Trim(out_node.GetString("CRR_TYPE1"));
                txtCrrType2.Text = MPCF.Trim(out_node.GetString("CRR_TYPE2"));
                txtCrrType3.Text = MPCF.Trim(out_node.GetString("CRR_TYPE3"));
                txtMaterial.Text = MPCF.Trim(out_node.GetString("CRR_MATERIAL"));
                txtSize.Text = MPCF.Trim(out_node.GetInt("CRR_SIZE"));
                txtUsageLimit.Text = MPCF.Trim(out_node.GetInt("USAGE_LIMIT_COUNT"));
                txtUsageCount.Text = MPCF.Trim(out_node.GetInt("USAGE_COUNT"));
                txtCleanLimit.Text = MPCF.Trim(out_node.GetInt("CLEAN_LIMIT_COUNT"));
                txtCleanCount.Text = MPCF.Trim(out_node.GetInt("CLEAN_COUNT"));
                txtCleanTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_CLEAN_TIME"));
                txtResourceID.Text = MPCF.Trim(out_node.GetString("RES_ID"));
                txtSubResourceID.Text = MPCF.Trim(out_node.GetString("SUBRES_ID"));
                txtPort.Text = MPCF.Trim(out_node.GetString("PORT_ID"));
                txtLotID.Text = MPCF.Trim(out_node.GetString("LOT_ID"));
                txtQty1.Text = MPCF.Trim(out_node.GetDouble("QTY_1"));
                txtQty2.Text = MPCF.Trim(out_node.GetDouble("QTY_2"));
                txtQty3.Text = MPCF.Trim(out_node.GetDouble("QTY_3"));
                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                chkNeedClean.Checked = out_node.GetChar("NEED_CLEAN_FLAG") == 'Y' ? true : false;
                chkFinishCleanFlag.Checked = out_node.GetChar("FINISH_CLEAN_FLAG") == 'Y' ? true : false;
                chkMoveFlag.Checked = out_node.GetChar("MOVE_FLAG") == 'Y' ? true : false;
                chkEmptyFlag.Checked = out_node.GetChar("EMPTY_FLAG") == 'Y' ? true : false;

                txtCarrierGroup.Text = MPCF.Trim(out_node.GetString("CRR_GROUP"));
                txtCarrierStatus.Text = MPCF.Trim(out_node.GetString("CRR_STATUS"));
                txtStockInTime.Text = MPCF.MakeDateFormat(out_node.GetString("STOCK_IN_TIME"));
                txtTableSlot.Text = MPCF.Trim(out_node.GetString("TBL_SLOT"));
                txtUsageLimitTime.Text = out_node.GetInt("USAGE_LIMIT_TIME").ToString();

                txtUseAreaID.Text = MPCF.Trim(out_node.GetString("USE_AREA_ID"));
                txtUseResourceID.Text = MPCF.Trim(out_node.GetString("USE_RES_ID"));
                txtUseSubAreaID.Text = MPCF.Trim(out_node.GetString("USE_SUB_AREA_ID"));
                txtElapseUsageTime.Text = out_node.GetDouble("ELAPSE_USAGE_TIME").ToString();

                txtLotHistSeq.Text = MPCF.Trim(out_node.GetInt("LOT_HIST_SEQ"));
                txtLastHistSeq.Text = MPCF.Trim(out_node.GetInt("LAST_HIST_SEQ"));
                txtLastTranCode.Text = MPCF.Trim(out_node.GetString("LAST_TRAN_CODE"));
                txtLastTranTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
                txtPlanTerminateTime.Text = MPCF.MakeDateFormat(out_node.GetString("PLAN_TERMINATE_TIME"));

                txtLocation1.Text = MPCF.Trim(out_node.GetString("LOCATION_1"));
                txtLocation2.Text = MPCF.Trim(out_node.GetString("LOCATION_2"));
                txtLocation3.Text = MPCF.Trim(out_node.GetString("LOCATION_3"));
                txtLocation4.Text = MPCF.Trim(out_node.GetString("LOCATION_4"));
                txtLocation5.Text = MPCF.Trim(out_node.GetString("LOCATION_5"));

                txtOldLocation1.Text = MPCF.Trim(out_node.GetString("OLD_LOCATION_1"));
                txtOldLocation2.Text = MPCF.Trim(out_node.GetString("OLD_LOCATION_2"));
                txtOldLocation3.Text = MPCF.Trim(out_node.GetString("OLD_LOCATION_3"));
                txtOldLocation4.Text = MPCF.Trim(out_node.GetString("OLD_LOCATION_4"));
                txtOldLocation5.Text = MPCF.Trim(out_node.GetString("OLD_LOCATION_5"));

                txtOldPortID.Text = MPCF.Trim(out_node.GetString("OLD_PORT_ID"));
                txtOldResourceID.Text = MPCF.Trim(out_node.GetString("OLD_RES_ID"));
                txtOldSubResourceID.Text = MPCF.Trim(out_node.GetString("OLD_SUBRES_ID"));

                txtCmf1.Text = MPCF.Trim(out_node.GetString("CRR_CMF_1"));
                txtCmf2.Text = MPCF.Trim(out_node.GetString("CRR_CMF_2"));
                txtCmf3.Text = MPCF.Trim(out_node.GetString("CRR_CMF_3"));
                txtCmf4.Text = MPCF.Trim(out_node.GetString("CRR_CMF_4"));
                txtCmf5.Text = MPCF.Trim(out_node.GetString("CRR_CMF_5"));
                txtCmf6.Text = MPCF.Trim(out_node.GetString("CRR_CMF_6"));
                txtCmf7.Text = MPCF.Trim(out_node.GetString("CRR_CMF_7"));
                txtCmf8.Text = MPCF.Trim(out_node.GetString("CRR_CMF_8"));
                txtCmf9.Text = MPCF.Trim(out_node.GetString("CRR_CMF_9"));
                txtCmf10.Text = MPCF.Trim(out_node.GetString("CRR_CMF_10"));
                txtCmf11.Text = MPCF.Trim(out_node.GetString("CRR_CMF_11"));
                txtCmf12.Text = MPCF.Trim(out_node.GetString("CRR_CMF_12"));
                txtCmf13.Text = MPCF.Trim(out_node.GetString("CRR_CMF_13"));
                txtCmf14.Text = MPCF.Trim(out_node.GetString("CRR_CMF_14"));
                txtCmf15.Text = MPCF.Trim(out_node.GetString("CRR_CMF_15"));
                txtCmf16.Text = MPCF.Trim(out_node.GetString("CRR_CMF_16"));
                txtCmf17.Text = MPCF.Trim(out_node.GetString("CRR_CMF_17"));
                txtCmf18.Text = MPCF.Trim(out_node.GetString("CRR_CMF_18"));
                txtCmf19.Text = MPCF.Trim(out_node.GetString("CRR_CMF_19"));
                txtCmf20.Text = MPCF.Trim(out_node.GetString("CRR_CMF_20"));

                // Attribute 
                udcAttributeStatus.AttributeKey = txtCrrID.Text;
                udcAttributeStatus.View();


                // Lot List
                ViewCarrierLotList(lisLotList, '1', txtCrrID.Text, "", "");

                // Add For V42
                // Slot Map List
                RASLIST.ViewCarrierSublotList(lisSlotMap, '1', txtCrrID.Text, true);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        // ViewCarrierLotList()
        //       - View Carrier - Lot Relation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal control As Control                    : Listê°€ ?¤ì–´ê°?control
        //        - ByVal c_step As String                        : ?•ìž¥ Process Step
        //        - Optional ByVal sExt_Factory As String = "": ?„ìž¬ Factoryê°€ ?„ë‹Œê²½ìš°??Factory
        //
        private bool ViewCarrierLotList(Control control, char c_step, string sCrr, string sLot, string sExtFactory)
        {

            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_CARRIER_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_CARRIER_LOT_LIST_OUT");

            try
            {
                if (control is ListView)
                {
                    MPCF.InitListView((ListView)control);
                }
                if (control is TreeView)
                {
                    MPCF.ClearList(control, true);
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
               
                if (sExtFactory != "")
                {
                    in_node.Factory = MPCF.Trim(sExtFactory);
                }

                in_node.AddString("CRR_ID", sCrr);
                in_node.AddString("LOT_ID", sLot);

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Carrier_Lot_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (control is ListView)
                        {
                            itmX = ((ListView)control).Items.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")), (int)SMALLICON_INDEX.IDX_LOT);
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_LOT_QTY_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_1") - out_node.GetList(0)[i].GetDouble("CRR_LOT_TOT_QTY_1")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_2")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_LOT_QTY_2")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_2") - out_node.GetList(0)[i].GetDouble("CRR_LOT_TOT_QTY_2")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_3")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("CRR_LOT_QTY_3")));
                            itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetDouble("LOT_QTY_3") - out_node.GetList(0)[i].GetDouble("CRR_LOT_TOT_QTY_3")));
                        }
                    }

                    in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                    in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                } while (out_node.GetString("NEXT_LOT_ID") != "" || out_node.GetInt("NEXT_CRR_SEQ") > 0);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        private bool CleanCarrier()
        {

            TRSNode in_node = new TRSNode("CLEAN_CARRIER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("CRR_ID", MPCF.Trim(txtCrrID.Text));
                in_node.AddInt("CLEAN_COUNT", 1);

                if (MPCR.CallService("RAS", "RAS_Clean_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;

        }


        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.cdvGroup;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmRASTranCleanCarrier_Activated(object sender, System.EventArgs e)
        {

            if (b_load_flag == false)
            {
                MPCF.FieldClear(this, rbnFilter);
                MPCF.InitListView(lisCarrier);
                SetCmfItem();

                b_load_flag = true;
            }
        }

        private void btnFilterView_Click(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            string SelectedItem;

            try
            {
                SelectedItem = MPCF.Trim(txtCrrID.Text);
                MPCF.FieldClear(this.pnlRight);
                lisCarrier.Items.Clear();
                lblDataCount.Text = "";

                if (rbnFilter.Checked == true)
                {
                    if (MPGO.RequireCarrierFilter() == true)
                    {
                        if (MPCF.Trim(txtFilter.Text) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(258));
                            txtFilter.Focus();
                            return;
                        }
                    }
                }
                if (RASLIST.ViewCarrierList(lisCarrier, '1', cdvGroup.Text, "", txtFilter.Text) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisCarrier.Items.Count);
                }

                if (lisCarrier.Items.Count > 0 && SelectedItem != "")
                {
                    MPCF.FindListItem(lisCarrier, SelectedItem, false);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisCarrier, this.Text, "");
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisCarrier, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisCarrier, txtFind.Text, 0, true, false);
        }

        private void cdvGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (rbnNoFilter.Checked == false && MPCF.Trim(txtFilter.Text) == "")
            {
                rbnNoFilter.Checked = true;
            }
            btnRefresh.PerformClick();
        }

        private void cdvGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvGroup.Init();
            MPCF.InitListView(cdvGroup.GetListView);
            cdvGroup.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvGroup.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierGroupList(cdvGroup.GetListView);
            cdvGroup.InsertEmptyRow(0, 1);
        }

        private void lisCarrier_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this.pnlRight);
            if (lisCarrier.SelectedItems.Count > 0)
            {

                ViewCarrier(lisCarrier.SelectedItems[0].Text);
            }
        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (MPCF.CheckValue(txtCrrID, 1) == false)
                {
                    return;
                }

                if (CleanCarrier() == false)
                {
                    return;
                }
    
                ViewCarrier(txtCrrID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void txtCrrID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (tabCarrierStatus.SelectedTab == tbpAttribute)
            {
                udcAttributeStatus.ClearValue();
            }

            if (e.KeyChar == (char)13)
            {
                if (txtCrrID.Text != "")
                {
                    ViewCarrier(txtCrrID.Text);
                }
            }
        }
  
#endif

    }
    
}
