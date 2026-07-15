
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;

using Miracom.TRSCore;
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmORDTranAttachLotToOrder.vb
//   Description : Transaction Attach Lot To Order
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-19 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _ORD = True Then

namespace Miracom.ORDCore
{
    public class frmORDTranAttachLotToOrder : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmORDTranAttachLotToOrder()
        {
            
            
            InitializeComponent();
            
            
            spdLotInfo.Tag = "Change Cell";
            
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
        



        private System.Windows.Forms.TabControl tabAttachStep;
        private System.Windows.Forms.TabPage tbpOrder;
        private System.Windows.Forms.TabPage tbpLot;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Panel pnlLot;
        private System.Windows.Forms.GroupBox grpOrder;
        private System.Windows.Forms.GroupBox grpLot;
        private System.Windows.Forms.Panel pnlOrderTop;
        private System.Windows.Forms.Panel pnlLotTop;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label lblOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOrder;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private System.Windows.Forms.Panel pnlOrderBottom;
        private System.Windows.Forms.Panel pnlLotBottom;
        private System.Windows.Forms.Label lblOrderQty;
        private System.Windows.Forms.Label lblOrderInQty;
        private System.Windows.Forms.TextBox txtOrderQty;
        private System.Windows.Forms.TextBox txtOrderInQty;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.TextBox txtTotalCount;
        private System.Windows.Forms.Panel pnlLotID;
        private System.Windows.Forms.Panel pnlAttachOrder;
        private System.Windows.Forms.Panel pnlLotInfo;
        protected System.Windows.Forms.GroupBox grpLotID;
        protected System.Windows.Forms.TextBox txtLotDesc;
        protected System.Windows.Forms.Label lblLotDesc;
        protected System.Windows.Forms.TextBox txtLotID;
        protected System.Windows.Forms.Label lblLotID;
        protected System.Windows.Forms.GroupBox grpLotInfo;
        protected System.Windows.Forms.Panel pnlLotInfoMain;
        private System.Windows.Forms.GroupBox grpOrderInfo;
        private System.Windows.Forms.TextBox txtPlanEndTime;
        private System.Windows.Forms.Label lblPlanEndTime;
        private System.Windows.Forms.TextBox txtPlanStartTime;
        private System.Windows.Forms.Label lblPlanStartTime;
        private System.Windows.Forms.TextBox txtPlanDueTime;
        private System.Windows.Forms.Label lblPlanDueTime;
        private System.Windows.Forms.Label lblOrderQty1;
        private System.Windows.Forms.TextBox txtCustomerMatID;
        private System.Windows.Forms.Label lblCustomerMatID;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblWorkDate;
        private System.Windows.Forms.Label lblBOMSetVersion;
        private System.Windows.Forms.Label lblBOMSetID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Label lblOutQty1;
        private System.Windows.Forms.Label lblInQty1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOrder2;
        private System.Windows.Forms.Label lblOrder2;
        private System.Windows.Forms.TextBox txtResource;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtWorkDate;
        private System.Windows.Forms.TextBox txtBomSetVersion;
        private System.Windows.Forms.TextBox txtBomSetID;
        private System.Windows.Forms.TextBox txtOutQty2;
        private System.Windows.Forms.TextBox txtOrderInQty2;
        private System.Windows.Forms.TextBox txtOrderQty2;
        private System.Windows.Forms.Panel pnlOrderMid;
        private Miracom.UI.Controls.MCListView.MCListView lisAttachLot;
        private System.Windows.Forms.ColumnHeader colLotID1;
        private System.Windows.Forms.ColumnHeader colOper1;
        private System.Windows.Forms.ColumnHeader colQty1;
        private System.Windows.Forms.ColumnHeader colDesc1;
        private System.Windows.Forms.Panel pnlLotMid;
        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private System.Windows.Forms.ColumnHeader colLotId2;
        private System.Windows.Forms.ColumnHeader colQty2;
        private System.Windows.Forms.ColumnHeader colDesc2;
        private System.Windows.Forms.Panel pnlAttachMid;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Button btnDetach;
        private FarPoint.Win.Spread.FpSpread spdLotInfo;
        private FarPoint.Win.Spread.SheetView spdLotInfo_Sheet1;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private TextBox txtMatVer;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder2 = new FarPoint.Win.CompoundBorder(bevelBorder3, bevelBorder4);
            FarPoint.Win.BevelBorder bevelBorder5 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder6 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder3 = new FarPoint.Win.CompoundBorder(bevelBorder5, bevelBorder6);
            this.tabAttachStep = new System.Windows.Forms.TabControl();
            this.tbpOrder = new System.Windows.Forms.TabPage();
            this.pnlAttachMid = new System.Windows.Forms.Panel();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnDetach = new System.Windows.Forms.Button();
            this.pnlLot = new System.Windows.Forms.Panel();
            this.grpLot = new System.Windows.Forms.GroupBox();
            this.pnlLotMid = new System.Windows.Forms.Panel();
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colLotId2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlLotBottom = new System.Windows.Forms.Panel();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.txtTotalCount = new System.Windows.Forms.TextBox();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.pnlLotTop = new System.Windows.Forms.Panel();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOper = new System.Windows.Forms.Label();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.grpOrder = new System.Windows.Forms.GroupBox();
            this.pnlOrderMid = new System.Windows.Forms.Panel();
            this.lisAttachLot = new Miracom.UI.Controls.MCListView.MCListView();
            this.colLotID1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOper1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlOrderBottom = new System.Windows.Forms.Panel();
            this.txtOrderInQty = new System.Windows.Forms.TextBox();
            this.txtOrderQty = new System.Windows.Forms.TextBox();
            this.lblOrderInQty = new System.Windows.Forms.Label();
            this.lblOrderQty = new System.Windows.Forms.Label();
            this.pnlOrderTop = new System.Windows.Forms.Panel();
            this.cdvOrder = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOrder = new System.Windows.Forms.Label();
            this.tbpLot = new System.Windows.Forms.TabPage();
            this.pnlLotInfo = new System.Windows.Forms.Panel();
            this.grpLotInfo = new System.Windows.Forms.GroupBox();
            this.pnlLotInfoMain = new System.Windows.Forms.Panel();
            this.spdLotInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdLotInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlAttachOrder = new System.Windows.Forms.Panel();
            this.grpOrderInfo = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.txtMatVer = new System.Windows.Forms.TextBox();
            this.txtBomSetID = new System.Windows.Forms.TextBox();
            this.txtBomSetVersion = new System.Windows.Forms.TextBox();
            this.txtWorkDate = new System.Windows.Forms.TextBox();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtResource = new System.Windows.Forms.TextBox();
            this.txtOutQty2 = new System.Windows.Forms.TextBox();
            this.lblOutQty1 = new System.Windows.Forms.Label();
            this.txtOrderInQty2 = new System.Windows.Forms.TextBox();
            this.lblInQty1 = new System.Windows.Forms.Label();
            this.txtPlanEndTime = new System.Windows.Forms.TextBox();
            this.lblPlanEndTime = new System.Windows.Forms.Label();
            this.txtPlanStartTime = new System.Windows.Forms.TextBox();
            this.lblPlanStartTime = new System.Windows.Forms.Label();
            this.txtPlanDueTime = new System.Windows.Forms.TextBox();
            this.lblPlanDueTime = new System.Windows.Forms.Label();
            this.txtOrderQty2 = new System.Windows.Forms.TextBox();
            this.lblOrderQty1 = new System.Windows.Forms.Label();
            this.txtCustomerMatID = new System.Windows.Forms.TextBox();
            this.lblCustomerMatID = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.lblBOMSetVersion = new System.Windows.Forms.Label();
            this.lblBOMSetID = new System.Windows.Forms.Label();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.cdvOrder2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOrder2 = new System.Windows.Forms.Label();
            this.pnlLotID = new System.Windows.Forms.Panel();
            this.grpLotID = new System.Windows.Forms.GroupBox();
            this.txtLotDesc = new System.Windows.Forms.TextBox();
            this.lblLotDesc = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabAttachStep.SuspendLayout();
            this.tbpOrder.SuspendLayout();
            this.pnlAttachMid.SuspendLayout();
            this.pnlLot.SuspendLayout();
            this.grpLot.SuspendLayout();
            this.pnlLotMid.SuspendLayout();
            this.pnlLotBottom.SuspendLayout();
            this.pnlLotTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            this.pnlOrder.SuspendLayout();
            this.grpOrder.SuspendLayout();
            this.pnlOrderMid.SuspendLayout();
            this.pnlOrderBottom.SuspendLayout();
            this.pnlOrderTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrder)).BeginInit();
            this.tbpLot.SuspendLayout();
            this.pnlLotInfo.SuspendLayout();
            this.grpLotInfo.SuspendLayout();
            this.pnlLotInfoMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo_Sheet1)).BeginInit();
            this.pnlAttachOrder.SuspendLayout();
            this.grpOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrder2)).BeginInit();
            this.pnlLotID.SuspendLayout();
            this.grpLotID.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabAttachStep);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Attach Lot To Order";
            // 
            // tabAttachStep
            // 
            this.tabAttachStep.Controls.Add(this.tbpOrder);
            this.tabAttachStep.Controls.Add(this.tbpLot);
            this.tabAttachStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAttachStep.Location = new System.Drawing.Point(0, 3);
            this.tabAttachStep.Name = "tabAttachStep";
            this.tabAttachStep.SelectedIndex = 0;
            this.tabAttachStep.Size = new System.Drawing.Size(742, 503);
            this.tabAttachStep.TabIndex = 0;
            this.tabAttachStep.SelectedIndexChanged += new System.EventHandler(this.tabAttachStep_SelectedIndexChanged);
            // 
            // tbpOrder
            // 
            this.tbpOrder.Controls.Add(this.pnlAttachMid);
            this.tbpOrder.Controls.Add(this.pnlLot);
            this.tbpOrder.Controls.Add(this.pnlOrder);
            this.tbpOrder.Location = new System.Drawing.Point(4, 22);
            this.tbpOrder.Name = "tbpOrder";
            this.tbpOrder.Size = new System.Drawing.Size(734, 477);
            this.tbpOrder.TabIndex = 0;
            this.tbpOrder.Text = "Order";
            this.tbpOrder.Resize += new System.EventHandler(this.tbpOrder_Resize);
            // 
            // pnlAttachMid
            // 
            this.pnlAttachMid.Controls.Add(this.btnAttach);
            this.pnlAttachMid.Controls.Add(this.btnDetach);
            this.pnlAttachMid.Location = new System.Drawing.Point(340, 58);
            this.pnlAttachMid.Name = "pnlAttachMid";
            this.pnlAttachMid.Size = new System.Drawing.Size(44, 88);
            this.pnlAttachMid.TabIndex = 1;
            // 
            // btnAttach
            // 
            this.btnAttach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAttach.Location = new System.Drawing.Point(10, 18);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(24, 24);
            this.btnAttach.TabIndex = 4;
            this.btnAttach.Text = "<";
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnDetach
            // 
            this.btnDetach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetach.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDetach.Location = new System.Drawing.Point(10, 47);
            this.btnDetach.Name = "btnDetach";
            this.btnDetach.Size = new System.Drawing.Size(24, 24);
            this.btnDetach.TabIndex = 5;
            this.btnDetach.Text = ">";
            this.btnDetach.Click += new System.EventHandler(this.btnDetach_Click);
            // 
            // pnlLot
            // 
            this.pnlLot.Controls.Add(this.grpLot);
            this.pnlLot.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLot.Location = new System.Drawing.Point(402, 0);
            this.pnlLot.Name = "pnlLot";
            this.pnlLot.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlLot.Size = new System.Drawing.Size(332, 477);
            this.pnlLot.TabIndex = 2;
            // 
            // grpLot
            // 
            this.grpLot.Controls.Add(this.pnlLotMid);
            this.grpLot.Controls.Add(this.pnlLotBottom);
            this.grpLot.Controls.Add(this.pnlLotTop);
            this.grpLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLot.Location = new System.Drawing.Point(0, 3);
            this.grpLot.Name = "grpLot";
            this.grpLot.Size = new System.Drawing.Size(332, 474);
            this.grpLot.TabIndex = 0;
            this.grpLot.TabStop = false;
            this.grpLot.Text = "Lot";
            // 
            // pnlLotMid
            // 
            this.pnlLotMid.Controls.Add(this.lisLotList);
            this.pnlLotMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotMid.Location = new System.Drawing.Point(3, 46);
            this.pnlLotMid.Name = "pnlLotMid";
            this.pnlLotMid.Size = new System.Drawing.Size(326, 367);
            this.pnlLotMid.TabIndex = 1;
            // 
            // lisLotList
            // 
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLotId2,
            this.colQty2,
            this.colDesc2});
            this.lisLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotList.EnableSort = true;
            this.lisLotList.EnableSortIcon = true;
            this.lisLotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLotList.FullRowSelect = true;
            this.lisLotList.Location = new System.Drawing.Point(0, 0);
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(326, 367);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            // 
            // colLotId2
            // 
            this.colLotId2.Text = "Lot ID";
            this.colLotId2.Width = 100;
            // 
            // colQty2
            // 
            this.colQty2.Text = "Qty";
            // 
            // colDesc2
            // 
            this.colDesc2.Text = "Desc";
            this.colDesc2.Width = 200;
            // 
            // pnlLotBottom
            // 
            this.pnlLotBottom.Controls.Add(this.txtTotalQty);
            this.pnlLotBottom.Controls.Add(this.lblTotalQty);
            this.pnlLotBottom.Controls.Add(this.txtTotalCount);
            this.pnlLotBottom.Controls.Add(this.lblTotalCount);
            this.pnlLotBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLotBottom.Location = new System.Drawing.Point(3, 413);
            this.pnlLotBottom.Name = "pnlLotBottom";
            this.pnlLotBottom.Size = new System.Drawing.Size(326, 58);
            this.pnlLotBottom.TabIndex = 2;
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(120, 32);
            this.txtTotalQty.MaxLength = 11;
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(200, 20);
            this.txtTotalQty.TabIndex = 3;
            this.txtTotalQty.TabStop = false;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Location = new System.Drawing.Point(15, 35);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(50, 13);
            this.lblTotalQty.TabIndex = 2;
            this.lblTotalQty.Text = "Total Qty";
            // 
            // txtTotalCount
            // 
            this.txtTotalCount.Location = new System.Drawing.Point(120, 8);
            this.txtTotalCount.MaxLength = 11;
            this.txtTotalCount.Name = "txtTotalCount";
            this.txtTotalCount.ReadOnly = true;
            this.txtTotalCount.Size = new System.Drawing.Size(200, 20);
            this.txtTotalCount.TabIndex = 1;
            this.txtTotalCount.TabStop = false;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(15, 11);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(62, 13);
            this.lblTotalCount.TabIndex = 0;
            this.lblTotalCount.Text = "Total Count";
            // 
            // pnlLotTop
            // 
            this.pnlLotTop.Controls.Add(this.cdvOper);
            this.pnlLotTop.Controls.Add(this.lblOper);
            this.pnlLotTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLotTop.Location = new System.Drawing.Point(3, 16);
            this.pnlLotTop.Name = "pnlLotTop";
            this.pnlLotTop.Size = new System.Drawing.Size(326, 30);
            this.pnlLotTop.TabIndex = 0;
            // 
            // cdvOper
            // 
            this.cdvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOper.BtnToolTipText = "";
            this.cdvOper.DescText = "";
            this.cdvOper.DisplaySubItemIndex = -1;
            this.cdvOper.DisplayText = "";
            this.cdvOper.Focusing = null;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.Index = 0;
            this.cdvOper.IsViewBtnImage = false;
            this.cdvOper.Location = new System.Drawing.Point(120, 0);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(200, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 1;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 200;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            this.cdvOper.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvOper_TextBoxKeyPress);
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.Location = new System.Drawing.Point(15, 3);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(30, 13);
            this.lblOper.TabIndex = 0;
            this.lblOper.Text = "Oper";
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.grpOrder);
            this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOrder.Location = new System.Drawing.Point(0, 0);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlOrder.Size = new System.Drawing.Size(334, 477);
            this.pnlOrder.TabIndex = 0;
            // 
            // grpOrder
            // 
            this.grpOrder.Controls.Add(this.pnlOrderMid);
            this.grpOrder.Controls.Add(this.pnlOrderBottom);
            this.grpOrder.Controls.Add(this.pnlOrderTop);
            this.grpOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOrder.Location = new System.Drawing.Point(0, 3);
            this.grpOrder.Name = "grpOrder";
            this.grpOrder.Size = new System.Drawing.Size(334, 474);
            this.grpOrder.TabIndex = 0;
            this.grpOrder.TabStop = false;
            this.grpOrder.Text = "Order";
            // 
            // pnlOrderMid
            // 
            this.pnlOrderMid.Controls.Add(this.lisAttachLot);
            this.pnlOrderMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOrderMid.Location = new System.Drawing.Point(3, 46);
            this.pnlOrderMid.Name = "pnlOrderMid";
            this.pnlOrderMid.Size = new System.Drawing.Size(328, 367);
            this.pnlOrderMid.TabIndex = 1;
            // 
            // lisAttachLot
            // 
            this.lisAttachLot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLotID1,
            this.colOper1,
            this.colQty1,
            this.colDesc1});
            this.lisAttachLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttachLot.EnableSort = true;
            this.lisAttachLot.EnableSortIcon = true;
            this.lisAttachLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachLot.FullRowSelect = true;
            this.lisAttachLot.Location = new System.Drawing.Point(0, 0);
            this.lisAttachLot.Name = "lisAttachLot";
            this.lisAttachLot.Size = new System.Drawing.Size(328, 367);
            this.lisAttachLot.TabIndex = 0;
            this.lisAttachLot.UseCompatibleStateImageBehavior = false;
            this.lisAttachLot.View = System.Windows.Forms.View.Details;
            this.lisAttachLot.SelectedIndexChanged += new System.EventHandler(this.lisAttachLot_SelectedIndexChanged);
            // 
            // colLotID1
            // 
            this.colLotID1.Text = "Lot ID";
            this.colLotID1.Width = 100;
            // 
            // colOper1
            // 
            this.colOper1.Text = "Oper";
            // 
            // colQty1
            // 
            this.colQty1.Text = "Qty";
            // 
            // colDesc1
            // 
            this.colDesc1.Text = "Desc";
            this.colDesc1.Width = 200;
            // 
            // pnlOrderBottom
            // 
            this.pnlOrderBottom.Controls.Add(this.txtOrderInQty);
            this.pnlOrderBottom.Controls.Add(this.txtOrderQty);
            this.pnlOrderBottom.Controls.Add(this.lblOrderInQty);
            this.pnlOrderBottom.Controls.Add(this.lblOrderQty);
            this.pnlOrderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOrderBottom.Location = new System.Drawing.Point(3, 413);
            this.pnlOrderBottom.Name = "pnlOrderBottom";
            this.pnlOrderBottom.Size = new System.Drawing.Size(328, 58);
            this.pnlOrderBottom.TabIndex = 2;
            // 
            // txtOrderInQty
            // 
            this.txtOrderInQty.Location = new System.Drawing.Point(120, 32);
            this.txtOrderInQty.MaxLength = 11;
            this.txtOrderInQty.Name = "txtOrderInQty";
            this.txtOrderInQty.ReadOnly = true;
            this.txtOrderInQty.Size = new System.Drawing.Size(200, 20);
            this.txtOrderInQty.TabIndex = 3;
            this.txtOrderInQty.TabStop = false;
            // 
            // txtOrderQty
            // 
            this.txtOrderQty.Location = new System.Drawing.Point(120, 8);
            this.txtOrderQty.MaxLength = 11;
            this.txtOrderQty.Name = "txtOrderQty";
            this.txtOrderQty.ReadOnly = true;
            this.txtOrderQty.Size = new System.Drawing.Size(200, 20);
            this.txtOrderQty.TabIndex = 1;
            this.txtOrderQty.TabStop = false;
            // 
            // lblOrderInQty
            // 
            this.lblOrderInQty.AutoSize = true;
            this.lblOrderInQty.Location = new System.Drawing.Point(5, 35);
            this.lblOrderInQty.Name = "lblOrderInQty";
            this.lblOrderInQty.Size = new System.Drawing.Size(64, 13);
            this.lblOrderInQty.TabIndex = 2;
            this.lblOrderInQty.Text = "Order In Qty";
            // 
            // lblOrderQty
            // 
            this.lblOrderQty.AutoSize = true;
            this.lblOrderQty.Location = new System.Drawing.Point(5, 11);
            this.lblOrderQty.Name = "lblOrderQty";
            this.lblOrderQty.Size = new System.Drawing.Size(52, 13);
            this.lblOrderQty.TabIndex = 0;
            this.lblOrderQty.Text = "Order Qty";
            // 
            // pnlOrderTop
            // 
            this.pnlOrderTop.Controls.Add(this.cdvOrder);
            this.pnlOrderTop.Controls.Add(this.lblOrder);
            this.pnlOrderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrderTop.Location = new System.Drawing.Point(3, 16);
            this.pnlOrderTop.Name = "pnlOrderTop";
            this.pnlOrderTop.Size = new System.Drawing.Size(328, 30);
            this.pnlOrderTop.TabIndex = 0;
            // 
            // cdvOrder
            // 
            this.cdvOrder.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOrder.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOrder.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOrder.BtnToolTipText = "";
            this.cdvOrder.DescText = "";
            this.cdvOrder.DisplaySubItemIndex = -1;
            this.cdvOrder.DisplayText = "";
            this.cdvOrder.Focusing = null;
            this.cdvOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOrder.Index = 0;
            this.cdvOrder.IsViewBtnImage = false;
            this.cdvOrder.Location = new System.Drawing.Point(120, 0);
            this.cdvOrder.MaxLength = 25;
            this.cdvOrder.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOrder.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOrder.Name = "cdvOrder";
            this.cdvOrder.ReadOnly = false;
            this.cdvOrder.SearchSubItemIndex = 0;
            this.cdvOrder.SelectedDescIndex = -1;
            this.cdvOrder.SelectedSubItemIndex = -1;
            this.cdvOrder.SelectionStart = 0;
            this.cdvOrder.Size = new System.Drawing.Size(200, 20);
            this.cdvOrder.SmallImageList = null;
            this.cdvOrder.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOrder.TabIndex = 1;
            this.cdvOrder.TextBoxToolTipText = "";
            this.cdvOrder.TextBoxWidth = 200;
            this.cdvOrder.VisibleButton = true;
            this.cdvOrder.VisibleColumnHeader = false;
            this.cdvOrder.VisibleDescription = false;
            this.cdvOrder.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOrder_SelectedItemChanged);
            this.cdvOrder.ButtonPress += new System.EventHandler(this.cdvOrder_ButtonPress);
            this.cdvOrder.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvOrder_TextBoxKeyPress);
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.Location = new System.Drawing.Point(15, 3);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(38, 13);
            this.lblOrder.TabIndex = 0;
            this.lblOrder.Text = "Order";
            // 
            // tbpLot
            // 
            this.tbpLot.Controls.Add(this.pnlLotInfo);
            this.tbpLot.Controls.Add(this.pnlAttachOrder);
            this.tbpLot.Controls.Add(this.pnlLotID);
            this.tbpLot.Location = new System.Drawing.Point(4, 22);
            this.tbpLot.Name = "tbpLot";
            this.tbpLot.Size = new System.Drawing.Size(734, 477);
            this.tbpLot.TabIndex = 1;
            this.tbpLot.Text = "Lot";
            // 
            // pnlLotInfo
            // 
            this.pnlLotInfo.Controls.Add(this.grpLotInfo);
            this.pnlLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotInfo.Location = new System.Drawing.Point(0, 72);
            this.pnlLotInfo.Name = "pnlLotInfo";
            this.pnlLotInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlLotInfo.Size = new System.Drawing.Size(734, 191);
            this.pnlLotInfo.TabIndex = 1;
            // 
            // grpLotInfo
            // 
            this.grpLotInfo.Controls.Add(this.pnlLotInfoMain);
            this.grpLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotInfo.Location = new System.Drawing.Point(0, 0);
            this.grpLotInfo.Name = "grpLotInfo";
            this.grpLotInfo.Size = new System.Drawing.Size(734, 188);
            this.grpLotInfo.TabIndex = 0;
            this.grpLotInfo.TabStop = false;
            this.grpLotInfo.Text = "Lot Information";
            // 
            // pnlLotInfoMain
            // 
            this.pnlLotInfoMain.Controls.Add(this.spdLotInfo);
            this.pnlLotInfoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotInfoMain.Location = new System.Drawing.Point(3, 16);
            this.pnlLotInfoMain.Name = "pnlLotInfoMain";
            this.pnlLotInfoMain.Padding = new System.Windows.Forms.Padding(1);
            this.pnlLotInfoMain.Size = new System.Drawing.Size(728, 169);
            this.pnlLotInfoMain.TabIndex = 0;
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.AccessibleDescription = "spdLotInfo, LotInfo, Row 0, Column 0, ";
            this.spdLotInfo.BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLotInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdLotInfo.Location = new System.Drawing.Point(1, 1);
            this.spdLotInfo.MoveActiveOnFocus = false;
            this.spdLotInfo.Name = "spdLotInfo";
            this.spdLotInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdLotInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdLotInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLotInfo_Sheet1});
            this.spdLotInfo.Size = new System.Drawing.Size(726, 167);
            this.spdLotInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLotInfo.TabIndex = 1;
            this.spdLotInfo.TabStop = false;
            this.spdLotInfo.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdLotInfo.TextTipAppearance = tipAppearance1;
            this.spdLotInfo.TextTipDelay = 200;
            this.spdLotInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // spdLotInfo_Sheet1
            // 
            this.spdLotInfo_Sheet1.Reset();
            spdLotInfo_Sheet1.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLotInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLotInfo_Sheet1.ColumnCount = 6;
            spdLotInfo_Sheet1.RowCount = 19;
            this.spdLotInfo_Sheet1.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdLotInfo_Sheet1.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(0, 0).Value = "Lot ID";
            this.spdLotInfo_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(0, 2).Value = "Material";
            this.spdLotInfo_Sheet1.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(0, 4).Value = "Flow";
            this.spdLotInfo_Sheet1.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(1, 0).Value = "Operation";
            this.spdLotInfo_Sheet1.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(1, 2).Value = "Qty 1/2/3";
            this.spdLotInfo_Sheet1.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(1, 4).Value = "Lot Type";
            this.spdLotInfo_Sheet1.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(2, 0).Value = "Create Code";
            this.spdLotInfo_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(2, 2).Value = "Owner Code";
            this.spdLotInfo_Sheet1.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(2, 4).Value = "Due Date";
            this.spdLotInfo_Sheet1.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(3, 0).Value = "Lot Status";
            this.spdLotInfo_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(3, 2).Value = "Lot Priority";
            this.spdLotInfo_Sheet1.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(3, 4).Value = "Hold Flag/Code";
            this.spdLotInfo_Sheet1.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(4, 0).Value = "Start Flag";
            this.spdLotInfo_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(4, 2).Value = "End Flag";
            this.spdLotInfo_Sheet1.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(4, 4).Value = "Rework Flag/Code";
            this.spdLotInfo_Sheet1.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(5, 0).Value = "Transit Flag";
            this.spdLotInfo_Sheet1.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(5, 2).Value = "Inventory Flag";
            this.spdLotInfo_Sheet1.Cells.Get(5, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(5, 4).Value = "Non Standard Flag";
            this.spdLotInfo_Sheet1.Cells.Get(6, 0).Value = "Last Tran Code";
            this.spdLotInfo_Sheet1.Cells.Get(6, 2).Value = "Last Tran Time";
            this.spdLotInfo_Sheet1.Cells.Get(6, 4).Value = "Last Hist Seq";
            this.spdLotInfo_Sheet1.Cells.Get(7, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(7, 0).Value = "Ship Code";
            this.spdLotInfo_Sheet1.Cells.Get(7, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(7, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(7, 2).Value = "Ship Time";
            this.spdLotInfo_Sheet1.Cells.Get(7, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(7, 4).Value = "Sample Flag";
            this.spdLotInfo_Sheet1.Cells.Get(8, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(8, 0).Value = "Oper In Qty 1/2/3";
            this.spdLotInfo_Sheet1.Cells.Get(8, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(8, 2).Value = "Create Qty 1/2/3";
            this.spdLotInfo_Sheet1.Cells.Get(8, 4).Value = "Start Time";
            this.spdLotInfo_Sheet1.Cells.Get(9, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(9, 0).Value = "Start Res ID";
            this.spdLotInfo_Sheet1.Cells.Get(9, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(9, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(9, 2).Value = "End Time";
            this.spdLotInfo_Sheet1.Cells.Get(9, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(9, 4).Value = "End Res ID";
            this.spdLotInfo_Sheet1.Cells.Get(10, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(10, 0).Value = "Rework Ret Flow";
            this.spdLotInfo_Sheet1.Cells.Get(10, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(10, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(10, 2).Value = "Rework Ret Oper";
            this.spdLotInfo_Sheet1.Cells.Get(10, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(10, 4).Value = "Rework Count";
            this.spdLotInfo_Sheet1.Cells.Get(11, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(11, 0).Value = "Rework End Flow";
            this.spdLotInfo_Sheet1.Cells.Get(11, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(11, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(11, 2).Value = "Rework End Oper";
            this.spdLotInfo_Sheet1.Cells.Get(11, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(11, 4).Value = "Rework Time";
            this.spdLotInfo_Sheet1.Cells.Get(12, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(12, 0).Value = "NSTD Ret Flow";
            this.spdLotInfo_Sheet1.Cells.Get(12, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(12, 2).Value = "NSTD Ret Oper";
            this.spdLotInfo_Sheet1.Cells.Get(12, 4).Value = "NSTD Time";
            this.spdLotInfo_Sheet1.Cells.Get(13, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(13, 0).Value = "Order ID";
            this.spdLotInfo_Sheet1.Cells.Get(13, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(13, 2).Value = "Lot Location";
            this.spdLotInfo_Sheet1.Cells.Get(13, 4).Value = "Batch ID";
            this.spdLotInfo_Sheet1.Cells.Get(14, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(14, 0).Value = "Create Time";
            this.spdLotInfo_Sheet1.Cells.Get(14, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(14, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(14, 2).Value = "Factory In Time";
            this.spdLotInfo_Sheet1.Cells.Get(14, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(14, 4).Value = "Flow In Time";
            this.spdLotInfo_Sheet1.Cells.Get(15, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(15, 0).Value = "Oper In Time";
            this.spdLotInfo_Sheet1.Cells.Get(15, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(15, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(15, 2).Value = "From To Lot ID";
            this.spdLotInfo_Sheet1.Cells.Get(15, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(15, 4).Value = "Reserve Res ID";
            this.spdLotInfo_Sheet1.Cells.Get(16, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(16, 0).Value = "BOM Set ID";
            this.spdLotInfo_Sheet1.Cells.Get(16, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(16, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(16, 2).Value = "BOM Set Version";
            this.spdLotInfo_Sheet1.Cells.Get(16, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(16, 4).Value = "BOM Act Hist Seq";
            this.spdLotInfo_Sheet1.Cells.Get(17, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(17, 0).Value = "Lot Del Flag";
            this.spdLotInfo_Sheet1.Cells.Get(17, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(17, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(17, 2).Value = "Lot Del Time";
            this.spdLotInfo_Sheet1.Cells.Get(17, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(17, 4).Value = "Lot Del Code";
            this.spdLotInfo_Sheet1.Cells.Get(18, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(18, 0).Value = "Start Qty 1/2/3";
            this.spdLotInfo_Sheet1.Cells.Get(18, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(18, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(18, 2).Value = "Carrier ID";
            this.spdLotInfo_Sheet1.Cells.Get(18, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(18, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Cells.Get(18, 4).Value = "Last Active Hist Seq";
            this.spdLotInfo_Sheet1.Cells.Get(18, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotInfo_Sheet1.ColumnHeader.Visible = false;
            this.spdLotInfo_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo_Sheet1.Columns.Get(0).Border = compoundBorder1;
            this.spdLotInfo_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdLotInfo_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(0).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(0).Width = 105F;
            this.spdLotInfo_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdLotInfo_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(1).Locked = false;
            this.spdLotInfo_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(1).Width = 126F;
            this.spdLotInfo_Sheet1.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo_Sheet1.Columns.Get(2).Border = compoundBorder2;
            this.spdLotInfo_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdLotInfo_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(2).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(2).Width = 105F;
            this.spdLotInfo_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdLotInfo_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(3).Locked = false;
            this.spdLotInfo_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(3).Width = 126F;
            this.spdLotInfo_Sheet1.Columns.Get(4).BackColor = System.Drawing.SystemColors.Control;
            this.spdLotInfo_Sheet1.Columns.Get(4).Border = compoundBorder3;
            this.spdLotInfo_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(4).Locked = true;
            this.spdLotInfo_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(4).Width = 105F;
            this.spdLotInfo_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdLotInfo_Sheet1.Columns.Get(5).Locked = false;
            this.spdLotInfo_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLotInfo_Sheet1.Columns.Get(5).Width = 126F;
            this.spdLotInfo_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdLotInfo_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdLotInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLotInfo_Sheet1.RowHeader.Visible = false;
            this.spdLotInfo_Sheet1.Rows.Get(0).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(1).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(2).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(3).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(4).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(5).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(6).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(7).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(8).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(9).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(10).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(11).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(12).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(13).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(14).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(15).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(16).Height = 17F;
            this.spdLotInfo_Sheet1.Rows.Get(17).Height = 17F;
            this.spdLotInfo_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotInfo_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            // 
            // pnlAttachOrder
            // 
            this.pnlAttachOrder.Controls.Add(this.grpOrderInfo);
            this.pnlAttachOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAttachOrder.Location = new System.Drawing.Point(0, 263);
            this.pnlAttachOrder.Name = "pnlAttachOrder";
            this.pnlAttachOrder.Size = new System.Drawing.Size(734, 214);
            this.pnlAttachOrder.TabIndex = 2;
            // 
            // grpOrderInfo
            // 
            this.grpOrderInfo.Controls.Add(this.cdvFlow);
            this.grpOrderInfo.Controls.Add(this.txtMatVer);
            this.grpOrderInfo.Controls.Add(this.txtBomSetID);
            this.grpOrderInfo.Controls.Add(this.txtBomSetVersion);
            this.grpOrderInfo.Controls.Add(this.txtWorkDate);
            this.grpOrderInfo.Controls.Add(this.txtMaterial);
            this.grpOrderInfo.Controls.Add(this.txtResource);
            this.grpOrderInfo.Controls.Add(this.txtOutQty2);
            this.grpOrderInfo.Controls.Add(this.lblOutQty1);
            this.grpOrderInfo.Controls.Add(this.txtOrderInQty2);
            this.grpOrderInfo.Controls.Add(this.lblInQty1);
            this.grpOrderInfo.Controls.Add(this.txtPlanEndTime);
            this.grpOrderInfo.Controls.Add(this.lblPlanEndTime);
            this.grpOrderInfo.Controls.Add(this.txtPlanStartTime);
            this.grpOrderInfo.Controls.Add(this.lblPlanStartTime);
            this.grpOrderInfo.Controls.Add(this.txtPlanDueTime);
            this.grpOrderInfo.Controls.Add(this.lblPlanDueTime);
            this.grpOrderInfo.Controls.Add(this.txtOrderQty2);
            this.grpOrderInfo.Controls.Add(this.lblOrderQty1);
            this.grpOrderInfo.Controls.Add(this.txtCustomerMatID);
            this.grpOrderInfo.Controls.Add(this.lblCustomerMatID);
            this.grpOrderInfo.Controls.Add(this.txtCustomerID);
            this.grpOrderInfo.Controls.Add(this.lblCustomer);
            this.grpOrderInfo.Controls.Add(this.lblWorkDate);
            this.grpOrderInfo.Controls.Add(this.lblBOMSetVersion);
            this.grpOrderInfo.Controls.Add(this.lblBOMSetID);
            this.grpOrderInfo.Controls.Add(this.lblResID);
            this.grpOrderInfo.Controls.Add(this.lblMaterial);
            this.grpOrderInfo.Controls.Add(this.cdvOrder2);
            this.grpOrderInfo.Controls.Add(this.lblOrder2);
            this.grpOrderInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOrderInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOrderInfo.Location = new System.Drawing.Point(0, 0);
            this.grpOrderInfo.Name = "grpOrderInfo";
            this.grpOrderInfo.Size = new System.Drawing.Size(734, 214);
            this.grpOrderInfo.TabIndex = 0;
            this.grpOrderInfo.TabStop = false;
            this.grpOrderInfo.Text = "Order Information";
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = true;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 108;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(12, 90);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = true;
            this.cdvFlow.Size = new System.Drawing.Size(308, 20);
            this.cdvFlow.TabIndex = 63;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = false;
            this.cdvFlow.VisibleSequenceButton = false;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 200;
            this.cdvFlow.WidthSequence = 50;
            // 
            // txtMatVer
            // 
            this.txtMatVer.Location = new System.Drawing.Point(272, 66);
            this.txtMatVer.MaxLength = 30;
            this.txtMatVer.Name = "txtMatVer";
            this.txtMatVer.ReadOnly = true;
            this.txtMatVer.Size = new System.Drawing.Size(48, 20);
            this.txtMatVer.TabIndex = 30;
            this.txtMatVer.TabStop = false;
            // 
            // txtBomSetID
            // 
            this.txtBomSetID.Location = new System.Drawing.Point(458, 42);
            this.txtBomSetID.MaxLength = 25;
            this.txtBomSetID.Name = "txtBomSetID";
            this.txtBomSetID.ReadOnly = true;
            this.txtBomSetID.Size = new System.Drawing.Size(200, 20);
            this.txtBomSetID.TabIndex = 17;
            this.txtBomSetID.TabStop = false;
            // 
            // txtBomSetVersion
            // 
            this.txtBomSetVersion.Location = new System.Drawing.Point(458, 66);
            this.txtBomSetVersion.MaxLength = 3;
            this.txtBomSetVersion.Name = "txtBomSetVersion";
            this.txtBomSetVersion.ReadOnly = true;
            this.txtBomSetVersion.Size = new System.Drawing.Size(200, 20);
            this.txtBomSetVersion.TabIndex = 19;
            this.txtBomSetVersion.TabStop = false;
            // 
            // txtWorkDate
            // 
            this.txtWorkDate.Location = new System.Drawing.Point(120, 42);
            this.txtWorkDate.MaxLength = 30;
            this.txtWorkDate.Name = "txtWorkDate";
            this.txtWorkDate.ReadOnly = true;
            this.txtWorkDate.Size = new System.Drawing.Size(200, 20);
            this.txtWorkDate.TabIndex = 3;
            this.txtWorkDate.TabStop = false;
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(120, 66);
            this.txtMaterial.MaxLength = 30;
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.ReadOnly = true;
            this.txtMaterial.Size = new System.Drawing.Size(150, 20);
            this.txtMaterial.TabIndex = 5;
            this.txtMaterial.TabStop = false;
            // 
            // txtResource
            // 
            this.txtResource.Location = new System.Drawing.Point(120, 114);
            this.txtResource.MaxLength = 20;
            this.txtResource.Name = "txtResource";
            this.txtResource.ReadOnly = true;
            this.txtResource.Size = new System.Drawing.Size(200, 20);
            this.txtResource.TabIndex = 9;
            this.txtResource.TabStop = false;
            // 
            // txtOutQty2
            // 
            this.txtOutQty2.Location = new System.Drawing.Point(458, 186);
            this.txtOutQty2.MaxLength = 11;
            this.txtOutQty2.Name = "txtOutQty2";
            this.txtOutQty2.ReadOnly = true;
            this.txtOutQty2.Size = new System.Drawing.Size(200, 20);
            this.txtOutQty2.TabIndex = 29;
            this.txtOutQty2.TabStop = false;
            // 
            // lblOutQty1
            // 
            this.lblOutQty1.AutoSize = true;
            this.lblOutQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOutQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutQty1.Location = new System.Drawing.Point(352, 188);
            this.lblOutQty1.Name = "lblOutQty1";
            this.lblOutQty1.Size = new System.Drawing.Size(72, 13);
            this.lblOutQty1.TabIndex = 28;
            this.lblOutQty1.Text = "Order Out Qty";
            this.lblOutQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderInQty2
            // 
            this.txtOrderInQty2.Location = new System.Drawing.Point(120, 186);
            this.txtOrderInQty2.MaxLength = 11;
            this.txtOrderInQty2.Name = "txtOrderInQty2";
            this.txtOrderInQty2.ReadOnly = true;
            this.txtOrderInQty2.Size = new System.Drawing.Size(200, 20);
            this.txtOrderInQty2.TabIndex = 15;
            this.txtOrderInQty2.TabStop = false;
            // 
            // lblInQty1
            // 
            this.lblInQty1.AutoSize = true;
            this.lblInQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInQty1.Location = new System.Drawing.Point(12, 188);
            this.lblInQty1.Name = "lblInQty1";
            this.lblInQty1.Size = new System.Drawing.Size(64, 13);
            this.lblInQty1.TabIndex = 14;
            this.lblInQty1.Text = "Order In Qty";
            this.lblInQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPlanEndTime
            // 
            this.txtPlanEndTime.Location = new System.Drawing.Point(458, 138);
            this.txtPlanEndTime.MaxLength = 30;
            this.txtPlanEndTime.Name = "txtPlanEndTime";
            this.txtPlanEndTime.ReadOnly = true;
            this.txtPlanEndTime.Size = new System.Drawing.Size(200, 20);
            this.txtPlanEndTime.TabIndex = 25;
            this.txtPlanEndTime.TabStop = false;
            // 
            // lblPlanEndTime
            // 
            this.lblPlanEndTime.AutoSize = true;
            this.lblPlanEndTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPlanEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanEndTime.Location = new System.Drawing.Point(352, 140);
            this.lblPlanEndTime.Name = "lblPlanEndTime";
            this.lblPlanEndTime.Size = new System.Drawing.Size(76, 13);
            this.lblPlanEndTime.TabIndex = 24;
            this.lblPlanEndTime.Text = "Plan End Time";
            this.lblPlanEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPlanStartTime
            // 
            this.txtPlanStartTime.Location = new System.Drawing.Point(458, 114);
            this.txtPlanStartTime.MaxLength = 30;
            this.txtPlanStartTime.Name = "txtPlanStartTime";
            this.txtPlanStartTime.ReadOnly = true;
            this.txtPlanStartTime.Size = new System.Drawing.Size(200, 20);
            this.txtPlanStartTime.TabIndex = 23;
            this.txtPlanStartTime.TabStop = false;
            // 
            // lblPlanStartTime
            // 
            this.lblPlanStartTime.AutoSize = true;
            this.lblPlanStartTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPlanStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanStartTime.Location = new System.Drawing.Point(352, 116);
            this.lblPlanStartTime.Name = "lblPlanStartTime";
            this.lblPlanStartTime.Size = new System.Drawing.Size(79, 13);
            this.lblPlanStartTime.TabIndex = 22;
            this.lblPlanStartTime.Text = "Plan Start Time";
            this.lblPlanStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPlanDueTime
            // 
            this.txtPlanDueTime.Location = new System.Drawing.Point(458, 90);
            this.txtPlanDueTime.MaxLength = 30;
            this.txtPlanDueTime.Name = "txtPlanDueTime";
            this.txtPlanDueTime.ReadOnly = true;
            this.txtPlanDueTime.Size = new System.Drawing.Size(200, 20);
            this.txtPlanDueTime.TabIndex = 21;
            this.txtPlanDueTime.TabStop = false;
            // 
            // lblPlanDueTime
            // 
            this.lblPlanDueTime.AutoSize = true;
            this.lblPlanDueTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPlanDueTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanDueTime.Location = new System.Drawing.Point(352, 92);
            this.lblPlanDueTime.Name = "lblPlanDueTime";
            this.lblPlanDueTime.Size = new System.Drawing.Size(77, 13);
            this.lblPlanDueTime.TabIndex = 20;
            this.lblPlanDueTime.Text = "Plan Due Time";
            this.lblPlanDueTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOrderQty2
            // 
            this.txtOrderQty2.Location = new System.Drawing.Point(120, 138);
            this.txtOrderQty2.MaxLength = 11;
            this.txtOrderQty2.Name = "txtOrderQty2";
            this.txtOrderQty2.ReadOnly = true;
            this.txtOrderQty2.Size = new System.Drawing.Size(200, 20);
            this.txtOrderQty2.TabIndex = 11;
            this.txtOrderQty2.TabStop = false;
            // 
            // lblOrderQty1
            // 
            this.lblOrderQty1.AutoSize = true;
            this.lblOrderQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderQty1.Location = new System.Drawing.Point(12, 140);
            this.lblOrderQty1.Name = "lblOrderQty1";
            this.lblOrderQty1.Size = new System.Drawing.Size(52, 13);
            this.lblOrderQty1.TabIndex = 10;
            this.lblOrderQty1.Text = "Order Qty";
            this.lblOrderQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomerMatID
            // 
            this.txtCustomerMatID.Location = new System.Drawing.Point(458, 162);
            this.txtCustomerMatID.MaxLength = 30;
            this.txtCustomerMatID.Name = "txtCustomerMatID";
            this.txtCustomerMatID.ReadOnly = true;
            this.txtCustomerMatID.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerMatID.TabIndex = 27;
            this.txtCustomerMatID.TabStop = false;
            // 
            // lblCustomerMatID
            // 
            this.lblCustomerMatID.AutoSize = true;
            this.lblCustomerMatID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCustomerMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerMatID.Location = new System.Drawing.Point(352, 164);
            this.lblCustomerMatID.Name = "lblCustomerMatID";
            this.lblCustomerMatID.Size = new System.Drawing.Size(86, 13);
            this.lblCustomerMatID.TabIndex = 26;
            this.lblCustomerMatID.Text = "Customer Mat ID";
            this.lblCustomerMatID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(120, 162);
            this.txtCustomerID.MaxLength = 20;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.Size = new System.Drawing.Size(200, 20);
            this.txtCustomerID.TabIndex = 13;
            this.txtCustomerID.TabStop = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(12, 164);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(65, 13);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer ID";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.AutoSize = true;
            this.lblWorkDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblWorkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkDate.Location = new System.Drawing.Point(12, 44);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(59, 13);
            this.lblWorkDate.TabIndex = 2;
            this.lblWorkDate.Text = "Work Date";
            this.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBOMSetVersion
            // 
            this.lblBOMSetVersion.AutoSize = true;
            this.lblBOMSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSetVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOMSetVersion.Location = new System.Drawing.Point(352, 68);
            this.lblBOMSetVersion.Name = "lblBOMSetVersion";
            this.lblBOMSetVersion.Size = new System.Drawing.Size(88, 13);
            this.lblBOMSetVersion.TabIndex = 18;
            this.lblBOMSetVersion.Text = "BOM Set Version";
            this.lblBOMSetVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBOMSetID
            // 
            this.lblBOMSetID.AutoSize = true;
            this.lblBOMSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOMSetID.Location = new System.Drawing.Point(352, 44);
            this.lblBOMSetID.Name = "lblBOMSetID";
            this.lblBOMSetID.Size = new System.Drawing.Size(64, 13);
            this.lblBOMSetID.TabIndex = 16;
            this.lblBOMSetID.Text = "BOM Set ID";
            this.lblBOMSetID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(12, 116);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(53, 13);
            this.lblResID.TabIndex = 8;
            this.lblResID.Text = "Resource";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterial.Location = new System.Drawing.Point(12, 68);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(44, 13);
            this.lblMaterial.TabIndex = 4;
            this.lblMaterial.Text = "Material";
            this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvOrder2
            // 
            this.cdvOrder2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOrder2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOrder2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOrder2.BtnToolTipText = "";
            this.cdvOrder2.DescText = "";
            this.cdvOrder2.DisplaySubItemIndex = -1;
            this.cdvOrder2.DisplayText = "";
            this.cdvOrder2.Focusing = null;
            this.cdvOrder2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOrder2.Index = 0;
            this.cdvOrder2.IsViewBtnImage = false;
            this.cdvOrder2.Location = new System.Drawing.Point(120, 16);
            this.cdvOrder2.MaxLength = 25;
            this.cdvOrder2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOrder2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOrder2.Name = "cdvOrder2";
            this.cdvOrder2.ReadOnly = false;
            this.cdvOrder2.SearchSubItemIndex = 0;
            this.cdvOrder2.SelectedDescIndex = -1;
            this.cdvOrder2.SelectedSubItemIndex = -1;
            this.cdvOrder2.SelectionStart = 0;
            this.cdvOrder2.Size = new System.Drawing.Size(538, 20);
            this.cdvOrder2.SmallImageList = null;
            this.cdvOrder2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOrder2.TabIndex = 1;
            this.cdvOrder2.TextBoxToolTipText = "";
            this.cdvOrder2.TextBoxWidth = 200;
            this.cdvOrder2.VisibleButton = true;
            this.cdvOrder2.VisibleColumnHeader = false;
            this.cdvOrder2.VisibleDescription = true;
            this.cdvOrder2.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOrder2_SelectedItemChanged);
            this.cdvOrder2.ButtonPress += new System.EventHandler(this.cdvOrder2_ButtonPress);
            this.cdvOrder2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvOrder2_TextBoxKeyPress);
            // 
            // lblOrder2
            // 
            this.lblOrder2.AutoSize = true;
            this.lblOrder2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder2.Location = new System.Drawing.Point(12, 20);
            this.lblOrder2.Name = "lblOrder2";
            this.lblOrder2.Size = new System.Drawing.Size(38, 13);
            this.lblOrder2.TabIndex = 0;
            this.lblOrder2.Text = "Order";
            // 
            // pnlLotID
            // 
            this.pnlLotID.Controls.Add(this.grpLotID);
            this.pnlLotID.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLotID.Location = new System.Drawing.Point(0, 0);
            this.pnlLotID.Name = "pnlLotID";
            this.pnlLotID.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlLotID.Size = new System.Drawing.Size(734, 72);
            this.pnlLotID.TabIndex = 0;
            // 
            // grpLotID
            // 
            this.grpLotID.Controls.Add(this.txtLotDesc);
            this.grpLotID.Controls.Add(this.lblLotDesc);
            this.grpLotID.Controls.Add(this.txtLotID);
            this.grpLotID.Controls.Add(this.lblLotID);
            this.grpLotID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotID.Location = new System.Drawing.Point(0, 0);
            this.grpLotID.Name = "grpLotID";
            this.grpLotID.Size = new System.Drawing.Size(734, 69);
            this.grpLotID.TabIndex = 1;
            this.grpLotID.TabStop = false;
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotDesc.Location = new System.Drawing.Point(120, 40);
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.Name = "txtLotDesc";
            this.txtLotDesc.ReadOnly = true;
            this.txtLotDesc.Size = new System.Drawing.Size(602, 20);
            this.txtLotDesc.TabIndex = 5;
            this.txtLotDesc.TabStop = false;
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotDesc.Location = new System.Drawing.Point(15, 43);
            this.lblLotDesc.Name = "lblLotDesc";
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            this.lblLotDesc.TabIndex = 4;
            this.lblLotDesc.Text = "Description";
            this.lblLotDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(45, 15);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmORDTranAttachLotToOrder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmORDTranAttachLotToOrder";
            this.Text = "Attach Lot To Order";
            this.Activated += new System.EventHandler(this.frmORDTranAttachLotToOrder_Activated);
            this.Load += new System.EventHandler(this.frmORDTranAttachLotToOrder_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabAttachStep.ResumeLayout(false);
            this.tbpOrder.ResumeLayout(false);
            this.pnlAttachMid.ResumeLayout(false);
            this.pnlLot.ResumeLayout(false);
            this.grpLot.ResumeLayout(false);
            this.pnlLotMid.ResumeLayout(false);
            this.pnlLotBottom.ResumeLayout(false);
            this.pnlLotBottom.PerformLayout();
            this.pnlLotTop.ResumeLayout(false);
            this.pnlLotTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            this.grpOrder.ResumeLayout(false);
            this.pnlOrderMid.ResumeLayout(false);
            this.pnlOrderBottom.ResumeLayout(false);
            this.pnlOrderBottom.PerformLayout();
            this.pnlOrderTop.ResumeLayout(false);
            this.pnlOrderTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrder)).EndInit();
            this.tbpLot.ResumeLayout(false);
            this.pnlLotInfo.ResumeLayout(false);
            this.grpLotInfo.ResumeLayout(false);
            this.pnlLotInfoMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo_Sheet1)).EndInit();
            this.pnlAttachOrder.ResumeLayout(false);
            this.grpOrderInfo.ResumeLayout(false);
            this.grpOrderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrder2)).EndInit();
            this.pnlLotID.ResumeLayout(false);
            this.grpLotID.ResumeLayout(false);
            this.grpLotID.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        TRSNode out_Lot_node = new TRSNode("LOT");

        
        #endregion
        
        #region " Function Definition "
        
        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition()
        {
            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvOrder2, 1) == false)
            {
                return false;
            }

            if (out_Lot_node.GetString("MAT_ID") != txtMaterial.Text)
            {
                MPCF.ShowMsgBox("Lot과 Order의 Material이 일치하지 않습니다.");
                return false;
            }
            if (out_Lot_node.GetString("FLOW") != cdvFlow.Text)
            {
                MPCF.ShowMsgBox("Lot과 Order의 Flow가 일치하지 않습니다.");
                return false;
            }
            
            return true;
            
        }
        
        // View_Order()
        //       - View Order
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        private bool View_Order(string sOrderID)
        {
            TRSNode in_node = new TRSNode("View_Order_In");
            TRSNode out_node = new TRSNode("View_Order_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ORDER_ID",MPCF.Trim(sOrderID));

            if (MPCR.CallService("ORD", "ORD_View_Order", in_node, ref out_node) == false)
            {
                return false;
            }
                        
            cdvOrder.Text = out_node.GetString("ORDER_ID");
            cdvOrder2.Text = out_node.GetString("ORDER_ID");
            cdvOrder2.DescText = out_node.GetString("ORDER_DESC");
            txtWorkDate.Text = MPCF.MakeDateFormat(out_node.GetString("WORK_DATE"), DATE_TIME_FORMAT.DATE);
            txtMaterial.Text = out_node.GetString("MAT_ID");
            txtMatVer.Text = MPCF.Trim(out_node.GetInt("MAT_VER"));
            cdvFlow.Text = out_node.GetString("FLOW");
            cdvFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
            txtResource.Text = out_node.GetString("RES_ID");
            txtPlanDueTime.Text =  MPCF.MakeDateFormat(out_node.GetString("PLAN_DUE_TIME"));
            txtPlanStartTime.Text =  MPCF.MakeDateFormat(out_node.GetString("PLAN_START_TIME"));
            txtPlanEndTime.Text =  MPCF.MakeDateFormat(out_node.GetString("PLAN_END_TIME"));
            txtOrderQty2.Text = MPCF.Format("#######,##0.###", out_node.GetDouble("ORD_QTY"));
            txtBomSetID.Text = out_node.GetString("BOM_SET_ID");
            txtBomSetVersion.Text = MPCF.Trim(out_node.GetInt("BOM_SET_VERSION"));
            txtCustomerID.Text = out_node.GetString("CUSTOMER_ID");
            txtCustomerMatID.Text = out_node.GetString("CUSTOMER_MAT_ID");
            txtOrderInQty2.Text = MPCF.Format("#######,##0.###", out_node.GetDouble("ORD_IN_QTY"));
            txtOutQty2.Text = MPCF.Format("#######,##0.###", out_node.GetDouble("ORD_OUT_QTY"));

            txtOrderQty.Text = MPCF.Format("#######,##0.###", out_node.GetDouble("ORD_QTY"));
            txtOrderInQty.Text = MPCF.Format("#######,##0.###", out_node.GetDouble("ORD_IN_QTY"));

            
            ViewAttachLotList(sOrderID);
            
            return true;
        }
        
        private bool ViewAttachLotList(string sOrderId)
        {
            
            int i;
            ListViewItem itmX;
            
            TRSNode in_node = new TRSNode("View_Lot_List_In");
            TRSNode out_node = new TRSNode("View_Lot_List_Out");

            MPCF.ClearList(lisAttachLot, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ORDER_ID", MPCF.Trim(sOrderId));
            in_node.AddString("NEXT_LOT_ID", "");
            
            do
            {
                if (MPCR.CallService("ORD", "ORD_View_Attach_Lot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                    itmX.SubItems.Add(MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_DESC")));

                    if (out_node.GetList(0)[i].GetChar("HOLD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                    }
                    else if (out_node.GetList(0)[i].GetChar("START_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_START;
                    }
                    else if (out_node.GetList(0)[i].GetChar("RWK_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                    }
                    else if (out_node.GetList(0)[i].GetChar("NSTD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                    }
                    else if (out_node.GetList(0)[i].GetChar("REP_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                    }
                    else
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT;
                    }
                    
                    lisAttachLot.Items.Add(itmX);
                    
                }
                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));

            } while (in_node.GetString("NEXT_LOT_ID") != "");
            
            lisAttachLot.ListViewItemSorter = new AttachedLotComparer();
            lisAttachLot.Sorting = SortOrder.Ascending;
            lisAttachLot.Sort();
            
            return true;
            
        }
        
        private bool ViewLotList(string sMat_Id, string sMat_Ver, string sFlow, string sOper)
        {
            
            int i;
            ListViewItem itmX;
            int iLotCount;
            double dLotQty;
            
            TRSNode in_node = new TRSNode("View_Lot_List_In");
            TRSNode out_node = new TRSNode("View_Lot_List_Out");

            MPCF.ClearList(lisLotList, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", MPCF.Trim(sMat_Id));
            in_node.AddInt("MAT_VER", MPCF.ToInt(sMat_Ver));
            in_node.AddString("FLOW", MPCF.Trim(sFlow));
            in_node.AddString("OPER", MPCF.Trim(sOper));
            in_node.AddString("NEXT_LOT_ID", "");
            
            iLotCount = 0;
            dLotQty = 0;
            
            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                    itmX.SubItems.Add(MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_DESC")));

                    if (out_node.GetList(0)[i].GetChar("HOLD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_HOLD;
                    }
                    else if (out_node.GetList(0)[i].GetChar("START_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_START;
                    }
                    else if (out_node.GetList(0)[i].GetChar("RWK_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_REWORK;
                    }
                    else if (out_node.GetList(0)[i].GetChar("NSTD_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT_ALTER;
                    }
                    else if (out_node.GetList(0)[i].GetChar("REP_FLAG") == 'Y')
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_REPAIR_LOT;
                    }
                    else
                    {
                        itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_LOT;
                    }

                    lisLotList.Items.Add(itmX);
                    
                    iLotCount++;
                    dLotQty += out_node.GetList(0)[i].GetDouble("QTY_1");
                }
                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));

            } while (in_node.GetString("NEXT_LOT_ID") != "");

            txtTotalCount.Text = MPCF.Trim(iLotCount);
            txtTotalQty.Text = MPCF.Format("#######,##0.###", dLotQty);
            
            return true;
            
        }
        
        // Update_Attach_Order_Lot()
        //       -   Update Attach Order Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : MP_STEP_CREATE/UPDATE/DELETE
        private bool Update_Attach_Order_Lot(char ProcStep, string sLotId, string sOrderId)
        {
            TRSNode in_node = new TRSNode("Update_Attach_Order_Lot_In");
            TRSNode out_node = new TRSNode("Cmn_Out");


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("LOT_ID", MPCF.Trim(sLotId));
            in_node.AddString("ORDER_ID", MPCF.Trim(sOrderId));

            if (MPCR.CallService("ORD", "ORD_Update_Attach_Order_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);
            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.tabAttachStep;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmORDTranAttachLotToOrder_Load(object sender, System.EventArgs e)
        {
            tbpOrder_Resize(sender, e);
            cdvFlow.BackColor = SystemColors.Control;
        }
        
        private void frmORDTranAttachLotToOrder_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                tbpOrder_Resize(null, null);
                
                MPCF.FieldClear(this);
                MPCF.InitListView(lisAttachLot);
                MPCF.InitListView(lisLotList);
                
                tabAttachStep.SelectedTab = tbpOrder;
                btnProcess.Enabled = false;

                b_load_flag = true;
            }
            
        }
        
        private void spdLotInfo_Resize(object sender, System.EventArgs e)
        {
            
            int iDiffSize;
            
            try
            {
                iDiffSize = (spdLotInfo.Size.Width - 726) / 3;
                
                if (iDiffSize >= 0)
                {
                    spdLotInfo.Sheets[0].Columns[1].Width = 130 + iDiffSize;
                    spdLotInfo.Sheets[0].Columns[3].Width = 130 + iDiffSize;
                    spdLotInfo.Sheets[0].Columns[5].Width = 130 + iDiffSize;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void tbpOrder_Resize(object sender, System.EventArgs e)
        {
            MPCF.FieldAdjust(tbpOrder, pnlOrder, pnlLot, pnlAttachMid, 40);
        }
        
        private void tabAttachStep_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (tabAttachStep.SelectedTab == tbpOrder)
            {
                btnProcess.Enabled = false;
            }
            else if (tabAttachStep.SelectedTab == tbpLot)
            {
                MPCR.ChangeControlEnabled(this, btnProcess, true);
            }
        }
        
        private void cdvOrder_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvOrder.Text != "")
            {
                View_Order(cdvOrder.Text);
            }
        }
        
        private void cdvOrder_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && cdvOrder.Text != "")
            {
                View_Order(cdvOrder.Text);
            }
        }
        
        private void cdvOper_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvOrder, 1) == false)
            {
                return;
            }
            
            cdvOper.Init();
            MPCF.InitListView(cdvOper.GetListView);
            cdvOper.Columns.Add("Operation", 150, HorizontalAlignment.Left);
            cdvOper.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvOper.SelectedSubItemIndex = 0;
            
            if (cdvFlow.Text == "")
            {
                WIPLIST.ViewOperationList(cdvOper.GetListView, '3', txtMaterial.Text,MPCF.ToInt(txtMatVer.Text), "", "", null, "");
            }
            else
            {
                WIPLIST.ViewOperationList(cdvOper.GetListView, '4', txtMaterial.Text, MPCF.ToInt(txtMatVer.Text), cdvFlow.Text, "", null, "");
            }
        }
        
        private void cdvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvOper.Text != "")
            {
                ViewLotList(txtMaterial.Text, txtMatVer.Text, cdvFlow.Text, cdvOper.Text);
            }
        }
        
        private void cdvOper_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && cdvOper.Text != "")
            {
                ViewLotList(txtMaterial.Text, txtMatVer.Text, cdvFlow.Text, cdvOper.Text);
            }
        }
        
        private void cdvOrder2_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvOrder2.Text != "")
            {
                View_Order(cdvOrder2.Text);
            }
        }
        
        private void cdvOrder2_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && cdvOrder2.Text != "")
            {
                View_Order(cdvOrder2.Text);
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            if (CheckCondition() == false)
            {
                return;
            }
            if (Update_Attach_Order_Lot(MPGC.MP_STEP_UPDATE, txtLotID.Text, cdvOrder2.Text) == false)
            {
                return;
            }
            
            MPCF.FieldClear(this.tbpLot, txtLotID, cdvOrder2);
            if (MPCR.SetLotInfoSpread(spdLotInfo, txtLotID.Text, ref out_Lot_node) == false)
            {
                txtLotID.Focus();
                return;
            }

            txtLotDesc.Text = out_Lot_node.GetString("LOT_DESC");
            View_Order(cdvOrder2.Text);
            
        }
        
        private void btnAttach_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            ListViewItem itmX;
            
            string sLotID;
            string sLotDesc;
            double dQty;
            
            if (lisLotList.SelectedItems.Count <= 0)
            {
                return;
            }
            
            for (i = 0; i <= lisLotList.SelectedItems.Count - 1; i++)
            {
                sLotID = lisLotList.SelectedItems[i].Text;
                if (MPCF.FindListItemIndex(lisAttachLot, sLotID, 0, false) < 0)
                {
                    dQty = MPCF.ToDbl(lisLotList.SelectedItems[i].SubItems[1].Text);
                    sLotDesc = lisLotList.SelectedItems[i].SubItems[2].Text;
                    
                    if (MPCF.ToDbl(txtOrderQty.Text) < MPCF.ToDbl(txtOrderInQty.Text) + dQty)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(172));
                        return;
                    }
                    
                    if (Update_Attach_Order_Lot(MPGC.MP_STEP_UPDATE, sLotID, cdvOrder.Text) == false)
                    {
                        return;
                    }
                    
                    itmX = new ListViewItem(sLotID, lisLotList.SelectedItems[i].ImageIndex);
                    itmX.SubItems.Add(cdvOper.Text);
                    itmX.SubItems.Add(MPCF.Format("#######,##0.###", dQty));
                    itmX.SubItems.Add(sLotDesc);
                    lisAttachLot.Items.Add(itmX);

                    txtOrderInQty.Text = MPCF.Format("#######,##0.###", MPCF.ToDbl(txtOrderInQty.Text) + dQty);
                    txtOrderInQty2.Text = txtOrderInQty.Text;
                    
                    lisLotList.SelectedItems[i].ForeColor = Color.Magenta;
                    
                }
            }
            
            lisAttachLot.ListViewItemSorter = new AttachedLotComparer();
            lisAttachLot.Sorting = SortOrder.Ascending;
            lisAttachLot.Sort();
            
        }
        
        private void btnDetach_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int iFindIdx;
            
            string sLotID;
            double dQty;
            
            if (lisAttachLot.SelectedItems.Count <= 0)
            {
                return;
            }
            
            i = 0;
            while (i < lisAttachLot.Items.Count)
            {
                if (lisAttachLot.Items[i].Selected == true)
                {
                    sLotID = lisAttachLot.Items[i].SubItems[0].Text;
                    dQty = MPCF.ToDbl(lisAttachLot.Items[i].SubItems[2].Text);
                    
                    if (Update_Attach_Order_Lot(MPGC.MP_STEP_DELETE, sLotID, cdvOrder.Text) == false)
                    {
                        return;
                    }
                    
                    lisAttachLot.Items.RemoveAt(i);
                    txtOrderInQty.Text = MPCF.Format("#######,##0.###", MPCF.ToDbl(txtOrderInQty.Text) - dQty);
                    txtOrderInQty2.Text = txtOrderInQty.Text;

                    iFindIdx = MPCF.FindListItemIndex(lisLotList, sLotID, false);
                    if (iFindIdx > - 1)
                    {
                        lisLotList.Items[iFindIdx].ForeColor = Color.Black;
                    }
                    
                }
                else
                {
                    i++;
                }
            }
            
            if (lisAttachLot.Items.Count > 0)
            {
                lisAttachLot.Items[lisAttachLot.Items.Count - 1].Selected = true;
            }
            
        }
        
        
        private void cdvOrder_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOrder.Init();
            MPCF.InitListView(cdvOrder.GetListView);
            cdvOrder.Columns.Add("Order", 150, HorizontalAlignment.Left);
            cdvOrder.Columns.Add("Mat ID", 200, HorizontalAlignment.Left);
            cdvOrder.Columns.Add("Mat Ver", 200, HorizontalAlignment.Left);
            cdvOrder.Columns.Add("Order Qty", 200, HorizontalAlignment.Left);
            cdvOrder.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvOrder.SelectedSubItemIndex = 0;
            ORDLIST.ViewOrderList(cdvOrder.GetListView, '1', "", null, "");
        }
        
        private void cdvOrder2_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOrder2.Init();
            MPCF.InitListView(cdvOrder2.GetListView);
            cdvOrder2.Columns.Add("Order", 150, HorizontalAlignment.Left);
            cdvOrder2.Columns.Add("Mat ID", 200, HorizontalAlignment.Left);
            cdvOrder2.Columns.Add("Mat Ver", 200, HorizontalAlignment.Left);
            cdvOrder2.Columns.Add("Order Qty", 200, HorizontalAlignment.Left);
            cdvOrder2.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvOrder2.SelectedSubItemIndex = 0;
            cdvOrder2.SelectedDescIndex = 4;
            ORDLIST.ViewOrderList(cdvOrder2.GetListView, '1', "", null, "");
        }
        
        private void lisAttachLot_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (MPCR.SetLotInfoSpread(spdLotInfo, txtLotID.Text, ref out_Lot_node) == false)
                {
                    txtLotID.Focus();
                    return;
                }
            }
        }
        
    }
    
    public class AttachedLotComparer : IComparer
    {
        
        
        public int Compare(object x, object y)
        {
            return string.Compare(((ListViewItem) x).SubItems[1].Text + ((ListViewItem) x).SubItems[0].Text, ((ListViewItem) y).SubItems[1].Text + ((ListViewItem) y).SubItems[0].Text);
        }
        
    }
    //#End If
}
