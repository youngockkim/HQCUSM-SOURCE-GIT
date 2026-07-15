
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
//   File Name   : frmINVTranTransferInventory.vb
//   Description : Inventory Transfer Inventory Transaction
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
    public class frmINVTranTransferInventory : Miracom.MESCore.TranForm09
    {
        
        #region " Windows Form auto generated code "
        
        public frmINVTranTransferInventory()
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
        



        protected System.Windows.Forms.Label lblToInvOper;
        protected System.Windows.Forms.Panel pnlToInventory;
        protected System.Windows.Forms.GroupBox grpToInventory;
        protected System.Windows.Forms.Panel pnlToInventoryInfo;
        protected System.Windows.Forms.GroupBox grpToInventoryInfo;
        private System.Windows.Forms.GroupBox grpTransInfo;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvToInvOper;
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
        protected System.Windows.Forms.Label lblTransferUnit1;
        protected System.Windows.Forms.TextBox txtTransferQty1;
        private Miracom.MESCore.Controls.udcMaterial cdvToMaterial;
        protected System.Windows.Forms.Label lblTransferQty1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlToInventory = new System.Windows.Forms.Panel();
            this.grpToInventory = new System.Windows.Forms.GroupBox();
            this.cdvToMaterial = new Miracom.MESCore.Controls.udcMaterial();
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
            this.lblTransferUnit1 = new System.Windows.Forms.Label();
            this.txtTransferQty1 = new System.Windows.Forms.TextBox();
            this.lblTransferQty1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatID)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.pnlInventoryInfo.SuspendLayout();
            this.grpInventoryInfo.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatVersion)).BeginInit();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlToInventory.SuspendLayout();
            this.grpToInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToInvOper)).BeginInit();
            this.pnlToInventoryInfo.SuspendLayout();
            this.grpToInventoryInfo.SuspendLayout();
            this.grpTransInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cdvInvOper
            // 
            this.cdvInvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvInvOper_SelectedItemChanged);
            this.cdvInvOper.ButtonPress += new System.EventHandler(this.cdvInvOper_ButtonPress);
            // 
            // cdvMatID
            // 
            this.cdvMatID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_SelectedItemChanged);
            this.cdvMatID.ButtonPress += new System.EventHandler(this.cdvMatID_ButtonPress);
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.MaxLength = 30;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // lblInvOper
            // 
            this.lblInvOper.AutoSize = true;
            this.lblInvOper.Size = new System.Drawing.Size(91, 13);
            // 
            // lblMatID
            // 
            this.lblMatID.AutoSize = true;
            this.lblMatID.Size = new System.Drawing.Size(52, 13);
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpTransInfo);
            this.pnlTranInfo.Controls.Add(this.pnlToInventoryInfo);
            this.pnlTranInfo.Controls.Add(this.pnlToInventory);
            this.pnlTranInfo.Controls.SetChildIndex(this.pnlInventoryInfo, 0);
            this.pnlTranInfo.Controls.SetChildIndex(this.pnlToInventory, 0);
            this.pnlTranInfo.Controls.SetChildIndex(this.pnlToInventoryInfo, 0);
            this.pnlTranInfo.Controls.SetChildIndex(this.grpTransInfo, 0);
            // 
            // lblLastHistSeq
            // 
            this.lblLastHistSeq.AutoSize = true;
            this.lblLastHistSeq.Size = new System.Drawing.Size(70, 13);
            // 
            // txtLastTranTime
            // 
            this.txtLastTranTime.MaxLength = 30;
            // 
            // lblLastTranTime
            // 
            this.lblLastTranTime.AutoSize = true;
            this.lblLastTranTime.Size = new System.Drawing.Size(78, 13);
            // 
            // lblLastTranCode
            // 
            this.lblLastTranCode.AutoSize = true;
            this.lblLastTranCode.Size = new System.Drawing.Size(80, 13);
            // 
            // lblAllocQty
            // 
            this.lblAllocQty.AutoSize = true;
            this.lblAllocQty.Size = new System.Drawing.Size(49, 13);
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.Size = new System.Drawing.Size(23, 13);
            // 
            // pnlComment
            // 
            this.pnlComment.TabIndex = 0;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
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
            // cdvMatVersion
            // 
            this.cdvMatVersion.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMatVersion.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMatVersion.ButtonPress += new System.EventHandler(this.cdvMatVersion_ButtonPress);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Transfer Inventory";
            // 
            // pnlToInventory
            // 
            this.pnlToInventory.Controls.Add(this.grpToInventory);
            this.pnlToInventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToInventory.Location = new System.Drawing.Point(3, 96);
            this.pnlToInventory.Name = "pnlToInventory";
            this.pnlToInventory.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlToInventory.Size = new System.Drawing.Size(722, 76);
            this.pnlToInventory.TabIndex = 1;
            // 
            // grpToInventory
            // 
            this.grpToInventory.Controls.Add(this.cdvToMaterial);
            this.grpToInventory.Controls.Add(this.cdvToInvOper);
            this.grpToInventory.Controls.Add(this.lblToInvOper);
            this.grpToInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpToInventory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpToInventory.Location = new System.Drawing.Point(0, 5);
            this.grpToInventory.Name = "grpToInventory";
            this.grpToInventory.Size = new System.Drawing.Size(722, 71);
            this.grpToInventory.TabIndex = 0;
            this.grpToInventory.TabStop = false;
            this.grpToInventory.Text = "To Inventory";
            // 
            // cdvToMaterial
            // 
            this.cdvToMaterial.AddEmptyRowToLast = false;
            this.cdvToMaterial.AddEmptyRowToTop = false;
            this.cdvToMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvToMaterial.DisplaySubItemIndex = 0;
            this.cdvToMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvToMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMaterial.LabelText = "To Material";
            this.cdvToMaterial.ListCond_ExtFactory = "";
            this.cdvToMaterial.ListCond_StepMaterial = '1';
            this.cdvToMaterial.ListCond_StepVersion = '1';
            this.cdvToMaterial.Location = new System.Drawing.Point(12, 13);
            this.cdvToMaterial.MaterialEnabled = true;
            this.cdvToMaterial.MaterialReadOnly = false;
            this.cdvToMaterial.Name = "cdvToMaterial";
            this.cdvToMaterial.SearchSubItemIndex = 0;
            this.cdvToMaterial.SelectedDescIndex = -1;
            this.cdvToMaterial.SelectedSubItemIndex = 0;
            this.cdvToMaterial.Size = new System.Drawing.Size(308, 20);
            this.cdvToMaterial.TabIndex = 0;
            this.cdvToMaterial.VersionEnabled = true;
            this.cdvToMaterial.VersionReadOnly = false;
            this.cdvToMaterial.VisibleColumnHeader = false;
            this.cdvToMaterial.VisibleDescription = false;
            this.cdvToMaterial.VisibleMaterialButton = true;
            this.cdvToMaterial.VisibleVersionButton = true;
            this.cdvToMaterial.WidthButton = 20;
            this.cdvToMaterial.WidthLabel = 108;
            this.cdvToMaterial.WidthMaterialAndVersion = 200;
            this.cdvToMaterial.WidthVersion = 50;
            this.cdvToMaterial.MaterialTextChanged += new System.EventHandler(this.cdvToMatID_MaterialTextBoxTextChanged);
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
            this.cdvToInvOper.TextBoxTextChanged += new System.EventHandler(this.cdvToInvOper_TextBoxTextChanged);
            // 
            // lblToInvOper
            // 
            this.lblToInvOper.AutoSize = true;
            this.lblToInvOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvOper.Location = new System.Drawing.Point(12, 43);
            this.lblToInvOper.Name = "lblToInvOper";
            this.lblToInvOper.Size = new System.Drawing.Size(78, 13);
            this.lblToInvOper.TabIndex = 1;
            this.lblToInvOper.Text = "To INV Oper";
            this.lblToInvOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlToInventoryInfo
            // 
            this.pnlToInventoryInfo.Controls.Add(this.grpToInventoryInfo);
            this.pnlToInventoryInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToInventoryInfo.Location = new System.Drawing.Point(3, 172);
            this.pnlToInventoryInfo.Name = "pnlToInventoryInfo";
            this.pnlToInventoryInfo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlToInventoryInfo.Size = new System.Drawing.Size(722, 100);
            this.pnlToInventoryInfo.TabIndex = 2;
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
            this.grpTransInfo.Controls.Add(this.lblTransferUnit1);
            this.grpTransInfo.Controls.Add(this.txtTransferQty1);
            this.grpTransInfo.Controls.Add(this.lblTransferQty1);
            this.grpTransInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTransInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTransInfo.Location = new System.Drawing.Point(3, 272);
            this.grpTransInfo.Name = "grpTransInfo";
            this.grpTransInfo.Size = new System.Drawing.Size(722, 103);
            this.grpTransInfo.TabIndex = 3;
            this.grpTransInfo.TabStop = false;
            // 
            // lblTransferUnit1
            // 
            this.lblTransferUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTransferUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferUnit1.Location = new System.Drawing.Point(226, 19);
            this.lblTransferUnit1.Name = "lblTransferUnit1";
            this.lblTransferUnit1.Size = new System.Drawing.Size(100, 14);
            this.lblTransferUnit1.TabIndex = 2;
            this.lblTransferUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTransferQty1
            // 
            this.txtTransferQty1.Location = new System.Drawing.Point(120, 16);
            this.txtTransferQty1.MaxLength = 11;
            this.txtTransferQty1.Name = "txtTransferQty1";
            this.txtTransferQty1.ReadOnly = true;
            this.txtTransferQty1.Size = new System.Drawing.Size(100, 20);
            this.txtTransferQty1.TabIndex = 1;
            this.txtTransferQty1.TabStop = false;
            this.txtTransferQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTransferQty1
            // 
            this.lblTransferQty1.AutoSize = true;
            this.lblTransferQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTransferQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferQty1.Location = new System.Drawing.Point(15, 19);
            this.lblTransferQty1.Name = "lblTransferQty1";
            this.lblTransferQty1.Size = new System.Drawing.Size(77, 13);
            this.lblTransferQty1.TabIndex = 0;
            this.lblTransferQty1.Text = "Transfer Qty";
            this.lblTransferQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmINVTranTransferInventory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmINVTranTransferInventory";
            this.Text = "Tran Transfer Store";
            this.Activated += new System.EventHandler(this.frmINVTranTransferInventory_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.cdvInvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatID)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlInventoryInfo.ResumeLayout(false);
            this.grpInventoryInfo.ResumeLayout(false);
            this.grpInventoryInfo.PerformLayout();
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatVersion)).EndInit();
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlToInventory.ResumeLayout(false);
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
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        private void ClearData(char ProcStep)
        {
            
            try
            {
                switch (ProcStep)
                {
                    case '1':
                        
                        MPCF.FieldClear(this);
                        break;
                    case '2':
                        
                        MPCF.FieldClear(this, cdvMatID, cdvInvOper, cdvToMaterial, cdvToInvOper, cdvMatVersion , false);
                        if (View_Inventory_Info('1', cdvMatID.Text, MPCF.ToInt(cdvMatVersion.Text), cdvInvOper.Text) == false)
                        {
                            if (cdvMatID.Text == "")
                            {
                                cdvMatID.Focus();
                            }
                            else if (cdvInvOper.Text == "")
                            {
                                cdvInvOper.Focus();
                            }
                        }
                        break;
                    case '3':

                        if (View_Inventory_Info('2', cdvToMaterial.Text, MPCF.ToInt(cdvToMaterial.ListCond_StepVersion), cdvToInvOper.Text) == false)
                        {
                            cdvToMaterial.Focus();
                        }
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
                case "TRANSFER_Inventory":

                    if (MPCF.CheckValue(cdvMatID, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvInvOper, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if ( cdvToMaterial.CheckValue() /*MPCF.CheckValue(cdvToMaterial, 1, false, false, "", "", "")*/ == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvToInvOper, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (txtTransferQty1.ReadOnly == false)
                    {
                        if (txtTransferQty1.Text == "" || txtTransferQty1.Text == "0")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtTransferQty1.Focus();
                            return false;
                        }
                        if (txtTransferQty1.Text != "" && txtTransferQty1.Text != "0")
                        {
                            if (MPCF.ToDbl(txtTransferQty1.Text) > MPCF.ToDbl(txtQty1.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(169));
                                tabTran.SelectedTab = tbpGeneral;
                                txtTransferQty1.Text = "0";
                                txtTransferQty1.Focus();
                                return false;
                            }
                        }
                    }
                    if (cdvMatID.Text == MPCF.Trim(cdvToMaterial.Text) && cdvInvOper.Text == MPCF.Trim(cdvToInvOper.Text))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(170));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvToInvOper.Focus();
                        return false;
                    }
                    
                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
            }
            
            return true;
            
        }
        
        // View_Inventory_Info()
        //       - Get Inventory Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Inventory_Info(char c_step, string sMatID, int iMatVer, string sOper)
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
                    if (c_step == '2' && out_node.MsgCode == "INV-0002")
                    {
                        return true;
                    }

                    MPCR.CheckContinueProc(out_node);
                    return false;
                }

                if (c_step == '1')
                {
                    txtQty1.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("QTY_1"));
                    txtAllocQty.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("ALLOC_QTY"));
                    txtLastTranCode.Text = out_node.GetString("LAST_TRAN_CODE");
                    txtLastTranTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
                    txtLastHistSeq.Text = MPCF.Trim(out_node.GetInt("LAST_HIST_SEQ"));
                    txtTransferQty1.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("QTY_1"));
                }
                else if (c_step == '2')
                {
                    txtToInvQty1.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("QTY_1"));
                    txtToInvAllocQty.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("ALLOC_QTY"));
                    txtToInvLastTranCode.Text = out_node.GetString("LAST_TRAN_CODE");
                    txtToInvLastTranTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
                    txtToInvLastHistSeq.Text = MPCF.Trim(out_node.GetInt("LAST_HIST_SEQ"));
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
        // View_Material_Info()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sMatID As String : Material
        //
        private bool View_Material_Info(char c_step, string sMatID, int iMatVer)
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
                        
            if (c_step == '1')
            {
                if (out_node.GetString("UNIT1") != "")
                {
                    txtTransferQty1.ReadOnly = false;
                    lblUnit1.Text = out_node.GetString("UNIT1");
                    lblTransferUnit1.Text = out_node.GetString("UNIT1");

                    cdvToMaterial.Text = cdvMatID.Text;
                    cdvToMaterial.Version = MPCF.ToInt(cdvMatVersion.Text);
                }
                else
                {
                    txtTransferQty1.ReadOnly = true;
                    lblUnit1.Text = "";
                    lblTransferUnit1.Text = "";
                }
            }
            else if (c_step == '2')
            {
                if (out_node.GetString("UNIT1") != "")
                {
                    lblUnit1.Text = out_node.GetString("UNIT1");
                }
                else
                {
                    lblToInvUnit1.Text = "";
                }
            }
            
            return true;
            
        }
        
        //
        // Transfer_Inventory()
        //       - Inventory Transfer Inventory
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Transfer_Inventory(char ProcStep)
        {
            TRSNode in_node = new TRSNode("Transfer_Inventory_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_HIST_SEQ", MPCF.ToInt(MPCF.ToDbl(txtLastHistSeq.Text)));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("MAT_VER", MPCF.ToInt(cdvMatVersion.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvInvOper.Text));
                in_node.AddString("TO_MAT_ID", MPCF.Trim(cdvToMaterial.Text));
                in_node.AddInt("TO_MAT_VER", MPCF.ToInt(cdvToMaterial.ListCond_StepVersion));
                in_node.AddString("TO_OPER", MPCF.Trim(cdvToInvOper.Text));

                in_node.AddDouble("TRANSFER_QTY_1", MPCF.ToDbl(txtTransferQty1.Text));

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

                in_node.AddString("TRAN_COMMENT", MPCF.Trim(txtComment.Text));
                
                if (MPCR.CallService("INV", "INV_Transfer_Inventory", in_node, ref out_node) == false)
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
        
        private void frmINVTranTransferInventory_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    ClearData('1');
                    SetCMFItem(MPGC.MP_CMF_TRN_TRANS_INV);
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvMatID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            if (cdvMatID.Text == "")
            {
                return;
            }
            cdvMatVersion.Text = e.SelectedItem.SubItems[1].Text;
            if (View_Material_Info('1', cdvMatID.Text, MPCF.ToInt(cdvMatVersion.Text)) == false)
            {
                return;
            }
            if (cdvInvOper.Text == "")
            {
                return;
            }
            ClearData('2');
            
        }
        
        private void cdvInvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvInvOper.Text == "")
            {
                return;
            }
            if (cdvMatID.Text == "")
            {
                return;
            }
            ClearData('2');
            
        }
        
        private void cdvToMatID_MaterialTextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            //If Trim(cdvToMatID.Text) = "" Then Exit Sub
            //If View_Material_Info("2", Trim(cdvToMatID.Text)) = False Then Exit Sub
            cdvToInvOper.Text = "";
            MPCF.FieldClear(this.grpToInventoryInfo);
            MPCF.FieldClear(this.grpTransInfo);
            
        }
        
        private void cdvToInvOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            //If Trim(cdvToInvOper.Text) = "" Then Exit Sub
            //If Trim(cdvToMatID.Text) = "" Then Exit Sub
            //If View_Inventory_Info("2", Trim(cdvToMatID.Text), Trim(cdvToInvOper.Text)) = False Then Exit Sub
            MPCF.FieldClear(this.grpToInventoryInfo);
            MPCF.FieldClear(this.grpTransInfo);
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("TRANSFER_Inventory") == false) return;
                if (Transfer_Inventory('1') == false) return;

                ClearData('2');
                ClearData('3');
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            ClearData('2');
            if (cdvToMaterial.Text != "" && cdvToInvOper.Text != "")
            {
                ClearData('3');
            }
            
        }
        
        private void cdvToInvOper_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (cdvToInvOper.Text == "")
                {
                    return;
                }
                if (cdvToMaterial.Text == "")
                {
                    return;
                }
                if (View_Inventory_Info('2', cdvToMaterial.Text, cdvToMaterial.Version, cdvToInvOper.Text) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvMatID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvMatID.Init();
            MPCF.InitListView(cdvMatID.GetListView);
            cdvMatID.Columns.Add("Material", 100, HorizontalAlignment.Left);
            cdvMatID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvMatID.SelectedSubItemIndex = 0;

            WIPLIST.ViewMaterialList(cdvMatID.GetListView, '1');
        }
        
        private void cdvInvOper_ButtonPress(object sender, System.EventArgs e)
        {
            cdvInvOper.Init();
            MPCF.InitListView(cdvInvOper.GetListView);
            cdvInvOper.Columns.Add("Oper", 100, HorizontalAlignment.Left);
            cdvInvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvInvOper.SelectedSubItemIndex = 0;
            
            WIPLIST.ViewOperationList(cdvInvOper.GetListView, '6', "", 0,"", "", null, "");
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

        private void cdvMatVersion_ButtonPress(object sender, EventArgs e)
        {
            WIPLIST.ViewMaterialVersionList(cdvMatVersion.GetListView, '1', cdvMatID.Text, "", ' ', ' ', null, "");
        }
    }
    //#End If
}
