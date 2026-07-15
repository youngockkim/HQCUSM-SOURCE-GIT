
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
//   File Name   : frmINVTranConvToInv.vb
//   Description : Convert Lot To Inventory Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - In_Store() : Inventory In Store transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-12 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _INV = True Then

namespace Miracom.INVCore
{
    public class frmINVTranConvToInv : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmINVTranConvToInv()
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
        



        protected System.Windows.Forms.GroupBox grpToInventory;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvToInvOper;
        protected System.Windows.Forms.Label lblToInvOper;
        protected System.Windows.Forms.Panel pnlToInventoryInfo;
        protected System.Windows.Forms.GroupBox grpToInventoryInfo;
        protected System.Windows.Forms.Label lblToInvUnit1;
        protected System.Windows.Forms.TextBox txtToInvLastHistSeq;
        protected System.Windows.Forms.Label lblToInvLastHistSeq;
        protected System.Windows.Forms.TextBox txtToInvLastTranTime;
        protected System.Windows.Forms.Label lblToInvLastTranTime;
        protected System.Windows.Forms.TextBox txtToInvLastTranCode;
        protected System.Windows.Forms.Label lblToInvLastTranCode;
        protected System.Windows.Forms.TextBox txtToInvAllocQty;
        protected System.Windows.Forms.Label lblToInvAllocQty;
        protected System.Windows.Forms.TextBox txtToInvQty1;
        protected System.Windows.Forms.Label lblToInvQty1;
        private System.Windows.Forms.GroupBox grpTransInfo;
        protected System.Windows.Forms.Label lblConvertUnit1;
        protected System.Windows.Forms.TextBox txtConvertQty1;
        private Miracom.MESCore.Controls.udcMaterial cdvToMatID;
        protected System.Windows.Forms.Label lblConvertQty1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.grpToInventory = new System.Windows.Forms.GroupBox();
            this.cdvToMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvToInvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToInvOper = new System.Windows.Forms.Label();
            this.pnlToInventoryInfo = new System.Windows.Forms.Panel();
            this.grpToInventoryInfo = new System.Windows.Forms.GroupBox();
            this.lblToInvUnit1 = new System.Windows.Forms.Label();
            this.txtToInvLastHistSeq = new System.Windows.Forms.TextBox();
            this.lblToInvLastHistSeq = new System.Windows.Forms.Label();
            this.txtToInvLastTranTime = new System.Windows.Forms.TextBox();
            this.lblToInvLastTranTime = new System.Windows.Forms.Label();
            this.txtToInvLastTranCode = new System.Windows.Forms.TextBox();
            this.lblToInvLastTranCode = new System.Windows.Forms.Label();
            this.txtToInvAllocQty = new System.Windows.Forms.TextBox();
            this.lblToInvAllocQty = new System.Windows.Forms.Label();
            this.txtToInvQty1 = new System.Windows.Forms.TextBox();
            this.lblToInvQty1 = new System.Windows.Forms.Label();
            this.grpTransInfo = new System.Windows.Forms.GroupBox();
            this.lblConvertUnit1 = new System.Windows.Forms.Label();
            this.txtConvertQty1 = new System.Windows.Forms.TextBox();
            this.lblConvertQty1 = new System.Windows.Forms.Label();
            this.pnlTranInfo.SuspendLayout();
            this.pnlGeneralTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).BeginInit();
            this.grpLotInfo.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTran.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpToInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToInvOper)).BeginInit();
            this.pnlToInventoryInfo.SuspendLayout();
            this.grpToInventoryInfo.SuspendLayout();
            this.grpTransInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpTransInfo);
            this.pnlTranInfo.Controls.Add(this.pnlToInventoryInfo);
            this.pnlTranInfo.Controls.Add(this.grpToInventory);
            this.pnlTranInfo.Size = new System.Drawing.Size(722, 235);
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 415);
            // 
            // pnlTran
            // 
            this.pnlTran.Size = new System.Drawing.Size(722, 376);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 379);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // grpCMF
            // 
            this.grpCMF.Size = new System.Drawing.Size(722, 412);
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.MaxLength = 30;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.TabStop = false;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.TabStop = false;
            // 
            // tabTran
            // 
            this.tabTran.Size = new System.Drawing.Size(736, 441);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 444);
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Convert Lot To Inventory";
            // 
            // grpToInventory
            // 
            this.grpToInventory.Controls.Add(this.cdvToMatID);
            this.grpToInventory.Controls.Add(this.cdvToInvOper);
            this.grpToInventory.Controls.Add(this.lblToInvOper);
            this.grpToInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpToInventory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpToInventory.Location = new System.Drawing.Point(0, 0);
            this.grpToInventory.Name = "grpToInventory";
            this.grpToInventory.Size = new System.Drawing.Size(722, 71);
            this.grpToInventory.TabIndex = 0;
            this.grpToInventory.TabStop = false;
            this.grpToInventory.Text = "To Inventory";
            // 
            // cdvToMatID
            // 
            this.cdvToMatID.AddEmptyRowToLast = false;
            this.cdvToMatID.AddEmptyRowToTop = false;
            this.cdvToMatID.AutoSize = true;
            this.cdvToMatID.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvToMatID.DisplaySubItemIndex = 0;
            this.cdvToMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMatID.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvToMatID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMatID.LabelText = "To Material";
            this.cdvToMatID.ListCond_ExtFactory = "";
            this.cdvToMatID.ListCond_StepMaterial = '1';
            this.cdvToMatID.ListCond_StepVersion = '1';
            this.cdvToMatID.Location = new System.Drawing.Point(15, 13);
            this.cdvToMatID.MaterialEnabled = true;
            this.cdvToMatID.MaterialReadOnly = false;
            this.cdvToMatID.Name = "cdvToMatID";
            this.cdvToMatID.SearchSubItemIndex = 0;
            this.cdvToMatID.SelectedDescIndex = -1;
            this.cdvToMatID.SelectedSubItemIndex = 0;
            this.cdvToMatID.Size = new System.Drawing.Size(305, 20);
            this.cdvToMatID.TabIndex = 0;
            this.cdvToMatID.VersionEnabled = true;
            this.cdvToMatID.VersionReadOnly = false;
            this.cdvToMatID.VisibleColumnHeader = false;
            this.cdvToMatID.VisibleDescription = false;
            this.cdvToMatID.VisibleMaterialButton = true;
            this.cdvToMatID.VisibleVersionButton = true;
            this.cdvToMatID.WidthButton = 20;
            this.cdvToMatID.WidthLabel = 105;
            this.cdvToMatID.WidthMaterialAndVersion = 200;
            this.cdvToMatID.WidthVersion = 50;
            this.cdvToMatID.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToMatID_SelectedItemChanged);
            this.cdvToMatID.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToMatID_SelectedItemChanged);
            // 
            // cdvToInvOper
            // 
            this.cdvToInvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToInvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToInvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToInvOper.BtnToolTipText = "";
            this.cdvToInvOper.DescText = "";
            this.cdvToInvOper.DisplaySubItemIndex = -1;
            this.cdvToInvOper.DisplayText = "";
            this.cdvToInvOper.Focusing = null;
            this.cdvToInvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToInvOper.Index = 0;
            this.cdvToInvOper.IsViewBtnImage = false;
            this.cdvToInvOper.Location = new System.Drawing.Point(120, 40);
            this.cdvToInvOper.MaxLength = 10;
            this.cdvToInvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToInvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToInvOper.Name = "cdvToInvOper";
            this.cdvToInvOper.ReadOnly = false;
            this.cdvToInvOper.SearchSubItemIndex = 0;
            this.cdvToInvOper.SelectedDescIndex = -1;
            this.cdvToInvOper.SelectedSubItemIndex = -1;
            this.cdvToInvOper.SelectionStart = 0;
            this.cdvToInvOper.Size = new System.Drawing.Size(200, 20);
            this.cdvToInvOper.SmallImageList = null;
            this.cdvToInvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToInvOper.TabIndex = 2;
            this.cdvToInvOper.TextBoxToolTipText = "";
            this.cdvToInvOper.TextBoxWidth = 200;
            this.cdvToInvOper.VisibleButton = true;
            this.cdvToInvOper.VisibleColumnHeader = false;
            this.cdvToInvOper.VisibleDescription = false;
            this.cdvToInvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToInvOper_SelectedItemChanged);
            this.cdvToInvOper.ButtonPress += new System.EventHandler(this.cdvToInvOper_ButtonPress);
            // 
            // lblToInvOper
            // 
            this.lblToInvOper.AutoSize = true;
            this.lblToInvOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvOper.Location = new System.Drawing.Point(15, 43);
            this.lblToInvOper.Name = "lblToInvOper";
            this.lblToInvOper.Size = new System.Drawing.Size(75, 13);
            this.lblToInvOper.TabIndex = 1;
            this.lblToInvOper.Text = "To Inv Oper";
            this.lblToInvOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlToInventoryInfo
            // 
            this.pnlToInventoryInfo.Controls.Add(this.grpToInventoryInfo);
            this.pnlToInventoryInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToInventoryInfo.Location = new System.Drawing.Point(0, 71);
            this.pnlToInventoryInfo.Name = "pnlToInventoryInfo";
            this.pnlToInventoryInfo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlToInventoryInfo.Size = new System.Drawing.Size(722, 100);
            this.pnlToInventoryInfo.TabIndex = 1;
            // 
            // grpToInventoryInfo
            // 
            this.grpToInventoryInfo.Controls.Add(this.lblToInvUnit1);
            this.grpToInventoryInfo.Controls.Add(this.txtToInvLastHistSeq);
            this.grpToInventoryInfo.Controls.Add(this.lblToInvLastHistSeq);
            this.grpToInventoryInfo.Controls.Add(this.txtToInvLastTranTime);
            this.grpToInventoryInfo.Controls.Add(this.lblToInvLastTranTime);
            this.grpToInventoryInfo.Controls.Add(this.txtToInvLastTranCode);
            this.grpToInventoryInfo.Controls.Add(this.lblToInvLastTranCode);
            this.grpToInventoryInfo.Controls.Add(this.txtToInvAllocQty);
            this.grpToInventoryInfo.Controls.Add(this.lblToInvAllocQty);
            this.grpToInventoryInfo.Controls.Add(this.txtToInvQty1);
            this.grpToInventoryInfo.Controls.Add(this.lblToInvQty1);
            this.grpToInventoryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpToInventoryInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpToInventoryInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpToInventoryInfo.Location = new System.Drawing.Point(0, 3);
            this.grpToInventoryInfo.Name = "grpToInventoryInfo";
            this.grpToInventoryInfo.Size = new System.Drawing.Size(722, 97);
            this.grpToInventoryInfo.TabIndex = 0;
            this.grpToInventoryInfo.TabStop = false;
            this.grpToInventoryInfo.Text = "To Inventory Information";
            // 
            // lblToInvUnit1
            // 
            this.lblToInvUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvUnit1.Location = new System.Drawing.Point(226, 19);
            this.lblToInvUnit1.Name = "lblToInvUnit1";
            this.lblToInvUnit1.Size = new System.Drawing.Size(100, 14);
            this.lblToInvUnit1.TabIndex = 2;
            this.lblToInvUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToInvLastHistSeq
            // 
            this.txtToInvLastHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToInvLastHistSeq.Location = new System.Drawing.Point(458, 64);
            this.txtToInvLastHistSeq.MaxLength = 10;
            this.txtToInvLastHistSeq.Name = "txtToInvLastHistSeq";
            this.txtToInvLastHistSeq.ReadOnly = true;
            this.txtToInvLastHistSeq.Size = new System.Drawing.Size(150, 20);
            this.txtToInvLastHistSeq.TabIndex = 10;
            this.txtToInvLastHistSeq.TabStop = false;
            // 
            // lblToInvLastHistSeq
            // 
            this.lblToInvLastHistSeq.AutoSize = true;
            this.lblToInvLastHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvLastHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvLastHistSeq.Location = new System.Drawing.Point(350, 67);
            this.lblToInvLastHistSeq.Name = "lblToInvLastHistSeq";
            this.lblToInvLastHistSeq.Size = new System.Drawing.Size(70, 13);
            this.lblToInvLastHistSeq.TabIndex = 9;
            this.lblToInvLastHistSeq.Text = "Last Hist Seq";
            this.lblToInvLastHistSeq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToInvLastTranTime
            // 
            this.txtToInvLastTranTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToInvLastTranTime.Location = new System.Drawing.Point(458, 40);
            this.txtToInvLastTranTime.MaxLength = 30;
            this.txtToInvLastTranTime.Name = "txtToInvLastTranTime";
            this.txtToInvLastTranTime.ReadOnly = true;
            this.txtToInvLastTranTime.Size = new System.Drawing.Size(150, 20);
            this.txtToInvLastTranTime.TabIndex = 8;
            this.txtToInvLastTranTime.TabStop = false;
            // 
            // lblToInvLastTranTime
            // 
            this.lblToInvLastTranTime.AutoSize = true;
            this.lblToInvLastTranTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvLastTranTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvLastTranTime.Location = new System.Drawing.Point(350, 43);
            this.lblToInvLastTranTime.Name = "lblToInvLastTranTime";
            this.lblToInvLastTranTime.Size = new System.Drawing.Size(78, 13);
            this.lblToInvLastTranTime.TabIndex = 7;
            this.lblToInvLastTranTime.Text = "Last Tran Time";
            this.lblToInvLastTranTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToInvLastTranCode
            // 
            this.txtToInvLastTranCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToInvLastTranCode.Location = new System.Drawing.Point(458, 16);
            this.txtToInvLastTranCode.MaxLength = 12;
            this.txtToInvLastTranCode.Name = "txtToInvLastTranCode";
            this.txtToInvLastTranCode.ReadOnly = true;
            this.txtToInvLastTranCode.Size = new System.Drawing.Size(150, 20);
            this.txtToInvLastTranCode.TabIndex = 6;
            this.txtToInvLastTranCode.TabStop = false;
            // 
            // lblToInvLastTranCode
            // 
            this.lblToInvLastTranCode.AutoSize = true;
            this.lblToInvLastTranCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvLastTranCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvLastTranCode.Location = new System.Drawing.Point(350, 19);
            this.lblToInvLastTranCode.Name = "lblToInvLastTranCode";
            this.lblToInvLastTranCode.Size = new System.Drawing.Size(80, 13);
            this.lblToInvLastTranCode.TabIndex = 5;
            this.lblToInvLastTranCode.Text = "Last Tran Code";
            this.lblToInvLastTranCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToInvAllocQty
            // 
            this.txtToInvAllocQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToInvAllocQty.Location = new System.Drawing.Point(120, 40);
            this.txtToInvAllocQty.MaxLength = 11;
            this.txtToInvAllocQty.Name = "txtToInvAllocQty";
            this.txtToInvAllocQty.ReadOnly = true;
            this.txtToInvAllocQty.Size = new System.Drawing.Size(100, 20);
            this.txtToInvAllocQty.TabIndex = 4;
            this.txtToInvAllocQty.TabStop = false;
            this.txtToInvAllocQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblToInvAllocQty
            // 
            this.lblToInvAllocQty.AutoSize = true;
            this.lblToInvAllocQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvAllocQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvAllocQty.Location = new System.Drawing.Point(15, 43);
            this.lblToInvAllocQty.Name = "lblToInvAllocQty";
            this.lblToInvAllocQty.Size = new System.Drawing.Size(49, 13);
            this.lblToInvAllocQty.TabIndex = 3;
            this.lblToInvAllocQty.Text = "Alloc Qty";
            this.lblToInvAllocQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToInvQty1
            // 
            this.txtToInvQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToInvQty1.Location = new System.Drawing.Point(120, 16);
            this.txtToInvQty1.MaxLength = 11;
            this.txtToInvQty1.Name = "txtToInvQty1";
            this.txtToInvQty1.ReadOnly = true;
            this.txtToInvQty1.Size = new System.Drawing.Size(100, 20);
            this.txtToInvQty1.TabIndex = 1;
            this.txtToInvQty1.TabStop = false;
            this.txtToInvQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblToInvQty1
            // 
            this.lblToInvQty1.AutoSize = true;
            this.lblToInvQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvQty1.Location = new System.Drawing.Point(15, 19);
            this.lblToInvQty1.Name = "lblToInvQty1";
            this.lblToInvQty1.Size = new System.Drawing.Size(23, 13);
            this.lblToInvQty1.TabIndex = 0;
            this.lblToInvQty1.Text = "Qty";
            this.lblToInvQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpTransInfo
            // 
            this.grpTransInfo.Controls.Add(this.lblConvertUnit1);
            this.grpTransInfo.Controls.Add(this.txtConvertQty1);
            this.grpTransInfo.Controls.Add(this.lblConvertQty1);
            this.grpTransInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTransInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTransInfo.Location = new System.Drawing.Point(0, 171);
            this.grpTransInfo.Name = "grpTransInfo";
            this.grpTransInfo.Size = new System.Drawing.Size(722, 64);
            this.grpTransInfo.TabIndex = 2;
            this.grpTransInfo.TabStop = false;
            // 
            // lblConvertUnit1
            // 
            this.lblConvertUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblConvertUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvertUnit1.Location = new System.Drawing.Point(226, 19);
            this.lblConvertUnit1.Name = "lblConvertUnit1";
            this.lblConvertUnit1.Size = new System.Drawing.Size(100, 14);
            this.lblConvertUnit1.TabIndex = 2;
            this.lblConvertUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtConvertQty1
            // 
            this.txtConvertQty1.Location = new System.Drawing.Point(120, 16);
            this.txtConvertQty1.MaxLength = 11;
            this.txtConvertQty1.Name = "txtConvertQty1";
            this.txtConvertQty1.ReadOnly = true;
            this.txtConvertQty1.Size = new System.Drawing.Size(100, 20);
            this.txtConvertQty1.TabIndex = 1;
            this.txtConvertQty1.TabStop = false;
            this.txtConvertQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblConvertQty1
            // 
            this.lblConvertQty1.AutoSize = true;
            this.lblConvertQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblConvertQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvertQty1.Location = new System.Drawing.Point(15, 19);
            this.lblConvertQty1.Name = "lblConvertQty1";
            this.lblConvertQty1.Size = new System.Drawing.Size(74, 13);
            this.lblConvertQty1.TabIndex = 0;
            this.lblConvertQty1.Text = "Convert Qty";
            this.lblConvertQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmINVTranConvToInv
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmINVTranConvToInv";
            this.Text = "Tran Convert Lot To Inventory Type";
            this.Activated += new System.EventHandler(this.frmINVTranConvToInv_Activated);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlGeneralTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).EndInit();
            this.grpLotInfo.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTran.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpToInventory.ResumeLayout(false);
            this.grpToInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToInvOper)).EndInit();
            this.pnlToInventoryInfo.ResumeLayout(false);
            this.grpToInventoryInfo.ResumeLayout(false);
            this.grpToInventoryInfo.PerformLayout();
            this.grpTransInfo.ResumeLayout(false);
            this.grpTransInfo.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            InitConvertQty();
            MPCF.FieldClear(this, txtLotID);

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            if (View_Operation() == false)
            {
                txtLotID.Focus();
                return false;
            }

            return true;
        }
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3", "4")
        //
        private void ClearData(char ProcStep)
        {
            
            try
            {
                switch (ProcStep)
                {
                    case '1':
                        
                        //Initialize
                        MPCF.FieldClear(this);
                        InitConvertQty();
                        ClearLotSpread();
                        break;

                    case '3':
                        
                        //Conv To Inv ?±ê³µ??Lot Info Reload
                        MPCF.FieldClear(this, txtLotID, txtLotDesc, cdvToMatID, cdvToInvOper);
                        ClearLotSpread();
                        if (base.ViewLotInfo(txtLotID.Text) == false)
                        {
                            txtLotID.Focus();
                            return;
                        }
                        txtLotDesc.Text = LOT.GetString("LOT_DESC");

                        if (View_Operation() == false)
                        {
                            return;
                        }
                        if (cdvToMatID.Text != "" && cdvToInvOper.Text != "")
                        {
                            if (View_Inventory_Info(cdvToMatID.Text, cdvToMatID.Version, cdvToInvOper.Text) == false)
                            {
                                return;
                            }
                        }
                        break;
                    case '4':
                        
                        //Refresh
                        InitConvertQty();
                        ClearLotSpread();
                        if (base.ViewLotInfo(txtLotID.Text) == false)
                        {
                            txtLotID.Focus();
                            return;
                        }
                        txtLotDesc.Text = LOT.GetString("LOT_DESC");

                        if (View_Operation() == false)
                        {
                            return;
                        }
                        if (cdvToMatID.Text != "" && cdvToInvOper.Text != "")
                        {
                            if (View_Inventory_Info(cdvToMatID.Text, cdvToMatID.Version, cdvToInvOper.Text) == false)
                            {
                                return;
                            }
                        }
                        break;
                    case '5':

                        MPCF.FieldClear(grpToInventoryInfo);
                        if (cdvToMatID.Text != "" && cdvToInvOper.Text != "")
                        {
                            if (View_Inventory_Info(cdvToMatID.Text, cdvToMatID.Version, cdvToInvOper.Text) == false)
                            {
                                return;
                            }
                        }
                        break;
                    case '6':
                        
                        //Initialize
                        MPCF.FieldClear(this, txtLotID);
                        InitConvertQty();
                        ClearLotSpread();
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "CONV_TO_INV":

                    if (MPCF.CheckValue(txtLotID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (MPCF.Trim(LOT.GetString("FLOW")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (MPCF.Trim(LOT.GetString("OPER")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvToMatID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvToInvOper, 1) == false)
                    {
                        return false;
                    }
                    
                    //ConvertQty Validation
                    if (txtConvertQty1.Text == "" || txtConvertQty1.Text == "0")
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        txtConvertQty1.Focus();
                        return false;
                    }
                    if (MPCF.ToDbl(txtConvertQty1.Text) > LOT.GetDouble("QTY_1"))
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        MPCF.ShowMsgBox(MPCF.GetMessage(171));
                        txtConvertQty1.Text = "0";
                        txtConvertQty1.Focus();
                        return false;
                    }
                    //CMF Validation
                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
            }
            
            return true;
            
        }
        
        //
        // InitConvertQty()
        //       - Initialize ConvertQty1, ConvertQty2, ConvertQty3
        //
        private void InitConvertQty()
        {
            
            lblConvertUnit1.Text = "";
            
        }
        
        //
        // View_Operation()
        //       -  View Operation Information of Mother Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Operation()
        {
            TRSNode in_node = new TRSNode("View_Operation_In");
            TRSNode out_node = new TRSNode("View_Operation_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", LOT.GetString("OPER"));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("UNIT_1") != "")
            {
                txtConvertQty1.ReadOnly = false;
                lblConvertUnit1.Text = out_node.GetString("UNIT_1"); 
                txtConvertQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
            }
            else
            {
                txtConvertQty1.ReadOnly = true;
                lblConvertUnit1.Text = "";
            }
            
            return true;            
        }
        
        //
        // View_Inventory_Info()
        //       - Get Inventory Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Inventory_Info(string sMatID, int iMatVer, string sOper)
        {
            TRSNode in_node = new TRSNode("View_Inventory_Info_In");
            TRSNode out_node = new TRSNode("View_Inventory_Info_Out");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("OPER", sOper);

                if (MPCR.CallService("INV", "INV_View_Inventory_Info", in_node, ref out_node, true) == false)
                {
                    if (out_node.MsgCode == "INV-0002")
                    {
                        return true;
                    }

                    MPCR.CheckContinueProc(out_node);
                    return false;
                }

                txtToInvQty1.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("QTY_1"));
                txtToInvAllocQty.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("ALLOC_QTY"));
                txtToInvLastTranCode.Text = MPCF.Trim(out_node.GetString("LAST_TRAN_CODE"));
                txtToInvLastTranTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
                txtToInvLastHistSeq.Text = MPCF.Trim(out_node.GetInt("LAST_HIST_SEQ"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        //
        // View_Material_Info()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sMatID As String : Material
        //
        private bool View_Material_Info(string sMatID, int iMatVer)
        {
            TRSNode in_node = new TRSNode("View_Material_In");
            TRSNode out_node = new TRSNode("View_Material_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);

            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetString("UNIT1") != "")
            {
                lblToInvUnit1.Text = MPCF.Trim(out_node.GetString("UNIT1"));
            }
            else
            {
                lblToInvUnit1.Text = "";
            }
            
            return true;
            
        }
        
        //
        // Conv_To_Inv()
        //       - Convert Lot To Inventory
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Conv_To_Inv(char ProcStep)
        {
            TRSNode in_node = new TRSNode("CONV_TO_INV_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
                        
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddInt("INV_HIS_SEQ", MPCF.ToInt(MPCF.ToDbl(this.txtToInvLastHistSeq.Text)));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("TO_MAT_ID", MPCF.Trim(cdvToMatID.Text));
                in_node.AddInt("TO_MAT_VER", MPCF.ToInt(cdvToMatID.Version));
                in_node.AddString("TO_OPER", MPCF.Trim(cdvToInvOper.Text));

                in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                
                if (txtConvertQty1.Text != "")
                {
                    in_node.AddDouble("CONVERT_QTY_1", MPCF.ToDbl(txtConvertQty1.Text));
                }
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("TRAN_COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("INV", "INV_Conv_To_Inv", in_node, ref out_node) == false)
                {
                    return false;
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
        
        #endregion
        
        private void frmINVTranConvToInv_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    ClearData('1');
                    SetCMFItem(MPGC.MP_CMF_TRN_CONV_TO_INV);
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        ViewLotInfo(txtLotID.Text);
                    }
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("CONV_TO_INV") == false) return;
                if (Conv_To_Inv('1') == false) return;

                if ((LOT.GetDouble("QTY_1") - MPCF.ToDbl(txtConvertQty1.Text)) < 0.0005)
                {
                    ClearData('6');
                }
                else
                {
                    ClearData('3');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            ClearData('4');
        }

        private void cdvToMatID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvToMatID.Text == "")
            {
                return;
            }
            if (View_Material_Info(cdvToMatID.Text, cdvToMatID.Version) == false)
            {
                return;
            }
            if (cdvToInvOper.Text == "")
            {
                return;
            }
            ClearData('5');
            
        }
        
        private void cdvToInvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvToInvOper.Text == "")
            {
                return;
            }
            if (cdvToMatID.Text == "")
            {
                return;
            }
            ClearData('5');
            
        }
        
        private void cdvToInvOper_ButtonPress(object sender, System.EventArgs e)
        {
            cdvToInvOper.Init();
            MPCF.InitListView(cdvToInvOper.GetListView);
            cdvToInvOper.Columns.Add("Oper", 100, HorizontalAlignment.Left);
            cdvToInvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToInvOper.SelectedSubItemIndex = 0;
            
            WIPLIST.ViewOperationList(cdvToInvOper.GetListView, '6', "", 0,"", "", null, "");
        }
    }
    //#End If
}
