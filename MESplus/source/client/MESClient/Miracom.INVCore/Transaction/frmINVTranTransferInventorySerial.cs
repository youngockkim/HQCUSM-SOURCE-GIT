
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
    public class frmINVTranTransferInventorySerial : Miracom.MESCore.TranForm09
    {
        
        #region " Windows Form auto generated code "
        
        public frmINVTranTransferInventorySerial()
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
        protected System.Windows.Forms.Label lblTransferQty1;
        private System.Windows.Forms.TabPage tbpSerial;
        private FarPoint.Win.Spread.FpSpread spdData;
        private Miracom.MESCore.Controls.udcMaterial cdvToMatID;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Picture picture1 = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlToInventory = new System.Windows.Forms.Panel();
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
            this.lblTransferUnit1 = new System.Windows.Forms.Label();
            this.txtTransferQty1 = new System.Windows.Forms.TextBox();
            this.lblTransferQty1 = new System.Windows.Forms.Label();
            this.tbpSerial = new System.Windows.Forms.TabPage();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
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
            this.tbpSerial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // cdvInvOper
            // 
            this.cdvInvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvMatID
            // 
            this.cdvMatID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.ButtonPress += new System.EventHandler(this.cdvMatID_ButtonPress);
            this.cdvMatID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_SelectedItemChanged);
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpSerial);
            this.tabTran.Controls.SetChildIndex(this.tbpCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpSerial, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpGeneral, 0);
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
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
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
            this.grpToInventory.Controls.Add(this.cdvToMatID);
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
            // cdvToMatID
            // 
            this.cdvToMatID.AddEmptyRowToLast = false;
            this.cdvToMatID.AddEmptyRowToTop = false;
            this.cdvToMatID.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvToMatID.DisplaySubItemIndex = 0;
            this.cdvToMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMatID.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvToMatID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToMatID.LabelText = "To Material";
            this.cdvToMatID.ListCond_ExtFactory = "";
            this.cdvToMatID.ListCond_StepMaterial = '1';
            this.cdvToMatID.ListCond_StepVersion = '1';
            this.cdvToMatID.Location = new System.Drawing.Point(11, 13);
            this.cdvToMatID.MaterialEnabled = true;
            this.cdvToMatID.MaterialReadOnly = false;
            this.cdvToMatID.Name = "cdvToMatID";
            this.cdvToMatID.SearchSubItemIndex = 0;
            this.cdvToMatID.SelectedDescIndex = -1;
            this.cdvToMatID.SelectedSubItemIndex = 0;
            this.cdvToMatID.Size = new System.Drawing.Size(309, 20);
            this.cdvToMatID.TabIndex = 4;
            this.cdvToMatID.VersionEnabled = true;
            this.cdvToMatID.VersionReadOnly = false;
            this.cdvToMatID.VisibleColumnHeader = false;
            this.cdvToMatID.VisibleDescription = false;
            this.cdvToMatID.VisibleMaterialButton = true;
            this.cdvToMatID.VisibleVersionButton = true;
            this.cdvToMatID.WidthButton = 20;
            this.cdvToMatID.WidthLabel = 109;
            this.cdvToMatID.WidthMaterialAndVersion = 200;
            this.cdvToMatID.WidthVersion = 50;
            this.cdvToMatID.MaterialTextChanged += new System.EventHandler(this.cdvToMatID_MaterialTextBoxTextChanged);
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
            this.cdvToInvOper.TabIndex = 3;
            this.cdvToInvOper.TextBoxToolTipText = "";
            this.cdvToInvOper.TextBoxWidth = 200;
            this.cdvToInvOper.VisibleButton = true;
            this.cdvToInvOper.VisibleColumnHeader = false;
            this.cdvToInvOper.VisibleDescription = false;
            this.cdvToInvOper.TextBoxTextChanged += new System.EventHandler(this.cdvToInvOper_TextBoxTextChanged);
            this.cdvToInvOper.ButtonPress += new System.EventHandler(this.cdvToInvOper_ButtonPress);
            this.cdvToInvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToInvOper_SelectedItemChanged);
            // 
            // lblToInvOper
            // 
            this.lblToInvOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvOper.Location = new System.Drawing.Point(11, 43);
            this.lblToInvOper.Name = "lblToInvOper";
            this.lblToInvOper.Size = new System.Drawing.Size(100, 14);
            this.lblToInvOper.TabIndex = 2;
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
            this.lblToInvLastHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvLastHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvLastHistSeq.Location = new System.Drawing.Point(350, 67);
            this.lblToInvLastHistSeq.Name = "lblToInvLastHistSeq";
            this.lblToInvLastHistSeq.Size = new System.Drawing.Size(104, 14);
            this.lblToInvLastHistSeq.TabIndex = 9;
            this.lblToInvLastHistSeq.Text = "Last Hist Seq";
            this.lblToInvLastHistSeq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToInvLastTranTime
            // 
            this.txtToInvLastTranTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToInvLastTranTime.Location = new System.Drawing.Point(458, 40);
            this.txtToInvLastTranTime.MaxLength = 19;
            this.txtToInvLastTranTime.Name = "txtToInvLastTranTime";
            this.txtToInvLastTranTime.ReadOnly = true;
            this.txtToInvLastTranTime.Size = new System.Drawing.Size(150, 20);
            this.txtToInvLastTranTime.TabIndex = 8;
            this.txtToInvLastTranTime.TabStop = false;
            // 
            // lblToInvLastTranTime
            // 
            this.lblToInvLastTranTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvLastTranTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvLastTranTime.Location = new System.Drawing.Point(350, 43);
            this.lblToInvLastTranTime.Name = "lblToInvLastTranTime";
            this.lblToInvLastTranTime.Size = new System.Drawing.Size(104, 14);
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
            this.lblToInvLastTranCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvLastTranCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvLastTranCode.Location = new System.Drawing.Point(350, 19);
            this.lblToInvLastTranCode.Name = "lblToInvLastTranCode";
            this.lblToInvLastTranCode.Size = new System.Drawing.Size(104, 14);
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
            this.lblToInvAllocQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvAllocQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvAllocQty.Location = new System.Drawing.Point(15, 43);
            this.lblToInvAllocQty.Name = "lblToInvAllocQty";
            this.lblToInvAllocQty.Size = new System.Drawing.Size(100, 14);
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
            this.lblToInvQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToInvQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToInvQty1.Location = new System.Drawing.Point(15, 19);
            this.lblToInvQty1.Name = "lblToInvQty1";
            this.lblToInvQty1.Size = new System.Drawing.Size(100, 14);
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
            this.lblTransferQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTransferQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransferQty1.Location = new System.Drawing.Point(15, 19);
            this.lblTransferQty1.Name = "lblTransferQty1";
            this.lblTransferQty1.Size = new System.Drawing.Size(100, 14);
            this.lblTransferQty1.TabIndex = 0;
            this.lblTransferQty1.Text = "Transfer Qty";
            this.lblTransferQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpSerial
            // 
            this.tbpSerial.Controls.Add(this.spdData);
            this.tbpSerial.Location = new System.Drawing.Point(4, 22);
            this.tbpSerial.Name = "tbpSerial";
            this.tbpSerial.Size = new System.Drawing.Size(728, 415);
            this.tbpSerial.TabIndex = 2;
            this.tbpSerial.Text = "Serial No.";
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "";
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.Location = new System.Drawing.Point(0, 0);
            this.spdData.Name = "spdData";
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(728, 415);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 8;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            this.spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdData_Sheet1.ColumnCount = 7;
            this.spdData_Sheet1.RowCount = 2;
            this.spdData_Sheet1.RowHeader.ColumnCount = 0;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Hist Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Serial Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Serial No.";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Material Unit";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Material Qty";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Material Type";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            picture1.AlignHorz = FarPoint.Win.HorizontalAlignment.Center;
            picture1.AlignVert = FarPoint.Win.VerticalAlignment.Center;
            picture1.TransparencyColor = System.Drawing.Color.Empty;
            picture1.TransparencyTolerance = 0;
            checkBoxCellType1.BackgroundImage = picture1;
            this.spdData_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 37F;
            this.spdData_Sheet1.Columns.Get(2).Label = "Serial Seq";
            this.spdData_Sheet1.Columns.Get(2).Width = 65F;
            textCellType1.MaxLength = 25;
            this.spdData_Sheet1.Columns.Get(3).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(3).Label = "Serial No.";
            this.spdData_Sheet1.Columns.Get(3).Width = 229F;
            textCellType2.MaxLength = 10;
            this.spdData_Sheet1.Columns.Get(4).CellType = textCellType2;
            this.spdData_Sheet1.Columns.Get(4).Label = "Material Unit";
            this.spdData_Sheet1.Columns.Get(4).Width = 117F;
            numberCellType1.DecimalPlaces = 0;
            numberCellType1.LeadingZero = FarPoint.Win.Spread.CellType.LeadingZero.Yes;
            numberCellType1.MaximumValue = 9999999;
            numberCellType1.MinimumValue = 0;
            this.spdData_Sheet1.Columns.Get(5).CellType = numberCellType1;
            this.spdData_Sheet1.Columns.Get(5).Label = "Material Qty";
            this.spdData_Sheet1.Columns.Get(5).Width = 86F;
            textCellType3.MaxLength = 1;
            this.spdData_Sheet1.Columns.Get(6).CellType = textCellType3;
            this.spdData_Sheet1.Columns.Get(6).Label = "Material Type";
            this.spdData_Sheet1.Columns.Get(6).Width = 96F;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.RowHeader.Visible = false;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmINVTranTransferInventorySerial
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmINVTranTransferInventorySerial";
            this.Text = "Transfer Inventory";
            this.Activated += new System.EventHandler(this.frmINVTranTransferInventorySerial_Activated);
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
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlToInventory.ResumeLayout(false);
            this.grpToInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvToInvOper)).EndInit();
            this.pnlToInventoryInfo.ResumeLayout(false);
            this.grpToInventoryInfo.ResumeLayout(false);
            this.grpToInventoryInfo.PerformLayout();
            this.grpTransInfo.ResumeLayout(false);
            this.grpTransInfo.PerformLayout();
            this.tbpSerial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
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
                        
                        MPCF.FieldClear(this, cdvMatID, cdvInvOper, cdvToMatID, cdvToInvOper, null, false);
                        if (View_Inventory_Info_Serial('1', cdvMatID.Text, MPCF.ToInt(cdvMatVersion.Text), cdvInvOper.Text) == false)
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

                        if (View_Inventory_Info_Serial('2', cdvToMatID.Text, cdvToMatID.Version, cdvToInvOper.Text) == false)
                        {
                            cdvToMatID.Focus();
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
                    if (MPCF.CheckValue(cdvToMatID, 1, false, false, "", "", "") == false)
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
                    if (cdvMatID.Text == MPCF.Trim(cdvToMatID.Text) && cdvInvOper.Text == MPCF.Trim(cdvToInvOper.Text))
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
        private bool View_Inventory_Info_Serial(char c_step, string sMatID, int iMatVer, string sOper)
        {
            TRSNode in_node = new TRSNode("View_Inventory_Info_In");
            TRSNode out_node = new TRSNode("View_Inventory_Info_Out");
            int i;
            FarPoint.Win.Spread.SheetView sheetX;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("OPER", sOper);

                if (MPCR.CallService("INV", "INV_View_Inventory_Info_Serial", in_node, ref out_node) == false)
                {
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

                    MPCF.ClearList(spdData);
                    sheetX = spdData.Sheets[0];
                   
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        sheetX.RowCount++;
                        sheetX.Cells[i, 1].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                        sheetX.Cells[i, 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("SERIAL_SEQ"));
                        sheetX.Cells[i, 3].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("SERIAL_ID"));
                        sheetX.Cells[i, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_UNIT"));
                        sheetX.Cells[i, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetDouble("MAT_QTY"));
                        sheetX.Cells[i, 6].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE"));
                    }
                }
                else if (c_step == '2')
                {
                    txtQty1.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("QTY_1"));
                    txtAllocQty.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("ALLOC_QTY"));
                    txtLastTranCode.Text = out_node.GetString("LAST_TRAN_CODE");
                    txtLastTranTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
                    txtLastHistSeq.Text = MPCF.Trim(out_node.GetInt("LAST_HIST_SEQ"));
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
                    cdvToMatID.Text = cdvMatID.Text;
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
                    lblTransferUnit1.Text = out_node.GetString("UNIT1");
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
            
            int i = 0;
            TRSNode in_node = new TRSNode("Transfer_Inventory_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode serial_list;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_HIST_SEQ", MPCF.ToInt(MPCF.ToDbl(txtLastHistSeq.Text)));
                in_node.AddInt("TO_HIST_SEQ", MPCF.ToInt(txtToInvLastHistSeq.Text));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("MAT_VER", MPCF.ToInt(cdvMatVersion.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvInvOper.Text));
                in_node.AddString("TO_MAT_ID", MPCF.Trim(cdvToMatID.Text));
                in_node.AddInt("TO_MAT_VER", MPCF.ToInt(cdvToMatID.Text));
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

                for (i = 0; i < spdData.Sheets[0].RowCount; i++)
                {
                    if (spdData.Sheets[0].GetValue(i, 0) != null && Convert.ToBoolean(spdData.Sheets[0].GetValue(i, 0)) == true)
                    {
                        serial_list = in_node.AddNode("SERIAL_LIST");

                        serial_list.AddInt("HIST_SEQ", MPCF.ToInt(spdData.Sheets[0].GetValue(i, 1)));
                        serial_list.AddInt("SERIAL_SEQ", MPCF.ToInt(spdData.Sheets[0].GetValue(i, 2)));
                        serial_list.AddString("SERIAL_ID", MPCF.Trim(spdData.Sheets[0].GetValue(i, 3)));
                        serial_list.AddString("MAT_UNIT", MPCF.Trim(spdData.Sheets[0].GetValue(i, 4)));
                        serial_list.AddDouble("MAT_QTY", MPCF.ToDbl(spdData.Sheets[0].GetValue(i, 5)));
                        serial_list.AddChar("SERIAL_TYPE", MPCF.ToChar(spdData.Sheets[0].GetValue(i, 6)));
                    }
                }
                
                if (MPCR.CallService("INV", "INV_Transfer_Inventory_Serial", in_node, ref out_node) == false)
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
        
        private void frmINVTranTransferInventorySerial_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    this.tabTran.TabPages.Remove(this.tbpCMF);
                    this.tabTran.Controls.Add(this.tbpCMF);

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
            if (cdvToMatID.Text != "" && cdvToInvOper.Text != "")
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
                if (cdvToMatID.Text == "")
                {
                    return;
                }
                if (View_Inventory_Info_Serial('2', cdvToMatID.Text, cdvToMatID.Version, cdvToInvOper.Text) == false)
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
        
        //private void cdvToMatID_MaterialButtonPress(object sender, System.EventArgs e)
        //{
        //    cdvToMatID.Init();
        //    MPCF.InitListView(cdvToMatID.MaterialGetListView);
        //    cdvToMatID.MaterialColumns.Add("Material", 100, HorizontalAlignment.Left);
        //    cdvToMatID.MaterialColumns.Add("Desc", 100, HorizontalAlignment.Left);
        //    cdvToMatID.SelectedSubItemIndex = 0;

        //    WIPLIST.ViewMaterialList(cdvToMatID.MaterialGetListView, '1');
            
        //}
        
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
