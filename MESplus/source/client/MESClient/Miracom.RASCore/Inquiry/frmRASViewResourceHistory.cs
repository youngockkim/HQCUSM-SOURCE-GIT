
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
//   File Name   : frmRASViewResourceHistory.vb
//   Description : View Resource History Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-21 : Created by Daniel Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------



namespace Miracom.RASCore
{
    public class frmRASViewResourceHistory : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewResourceHistory()
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

        private System.ComponentModel.IContainer components;

        
        



        public System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.GroupBox grpOption;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Label lblEvent;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEventID;
        private System.Windows.Forms.ContextMenu ctxHistoryMain;
        private System.Windows.Forms.Panel pnlMainHeader;
        private System.Windows.Forms.Panel pnlMainBody;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.CheckBox chkIncludeDelHistory;
        private System.Windows.Forms.TabControl tabHistory;
        private System.Windows.Forms.TabPage tbpView1;
        private System.Windows.Forms.TabPage tbpView2;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdHistoryBrief;
        private FarPoint.Win.Spread.SheetView spdHistoryBrief_Sheet1;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnCollapse;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResType;
        private Label lblResourceGroup;
        private Label lblResourceType;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Label lblOperation;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private System.Windows.Forms.ImageList imlSPIcons;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASViewResourceHistory));
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlMainHeader = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.lblOperation = new System.Windows.Forms.Label();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvResGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResourceGroup = new System.Windows.Forms.Label();
            this.lblResourceType = new System.Windows.Forms.Label();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.chkIncludeDelHistory = new System.Windows.Forms.CheckBox();
            this.cdvEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEvent = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlMainBody = new System.Windows.Forms.Panel();
            this.tabHistory = new System.Windows.Forms.TabControl();
            this.tbpView1 = new System.Windows.Forms.TabPage();
            this.spdHistoryBrief = new FarPoint.Win.Spread.FpSpread();
            this.spdHistoryBrief_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpView2 = new System.Windows.Forms.TabPage();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.ctxHistoryMain = new System.Windows.Forms.ContextMenu();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.imlSPIcons = new System.Windows.Forms.ImageList(this.components);
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMainHeader.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlMainBody.SuspendLayout();
            this.tabHistory.SuspendLayout();
            this.tbpView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistoryBrief)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistoryBrief_Sheet1)).BeginInit();
            this.tbpView2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExpand);
            this.pnlBottom.Controls.Add(this.btnCollapse);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 2;
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCollapse, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExpand, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 553);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Resource History";
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(16, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlMainHeader
            // 
            this.pnlMainHeader.Controls.Add(this.grpOption);
            this.pnlMainHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlMainHeader.Name = "pnlMainHeader";
            this.pnlMainHeader.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlMainHeader.Size = new System.Drawing.Size(742, 137);
            this.pnlMainHeader.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.lblOperation);
            this.grpOption.Controls.Add(this.cdvOperation);
            this.grpOption.Controls.Add(this.cdvFlow);
            this.grpOption.Controls.Add(this.cdvResGrp);
            this.grpOption.Controls.Add(this.cdvResType);
            this.grpOption.Controls.Add(this.lblResourceGroup);
            this.grpOption.Controls.Add(this.lblResourceType);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.chkIncludeDelHistory);
            this.grpOption.Controls.Add(this.cdvEventID);
            this.grpOption.Controls.Add(this.lblEvent);
            this.grpOption.Controls.Add(this.cdvResID);
            this.grpOption.Controls.Add(this.lblResID);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 137);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = true;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(407, 38);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(320, 20);
            this.cdvMaterial.TabIndex = 9;
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
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_MaterialSelectedItemChanged);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(407, 89);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(53, 13);
            this.lblOperation.TabIndex = 11;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvOperation
            // 
            this.cdvOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOperation.BtnToolTipText = "";
            this.cdvOperation.ButtonWidth = 20;
            this.cdvOperation.DescText = "";
            this.cdvOperation.DisplaySubItemIndex = -1;
            this.cdvOperation.DisplayText = "";
            this.cdvOperation.Focusing = null;
            this.cdvOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.Index = 0;
            this.cdvOperation.IsViewBtnImage = false;
            this.cdvOperation.Location = new System.Drawing.Point(527, 86);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MultiSelect = false;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SameWidthHeightOfButton = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedDescToQueryText = "";
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectedValueToQueryText = "";
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(200, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 12;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 200;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = true;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 120;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(407, 62);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(320, 20);
            this.cdvFlow.TabIndex = 10;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 200;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_FlowSelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_FlowButtonPress);
            // 
            // cdvResGrp
            // 
            this.cdvResGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp.BtnToolTipText = "";
            this.cdvResGrp.ButtonWidth = 20;
            this.cdvResGrp.DescText = "";
            this.cdvResGrp.DisplaySubItemIndex = -1;
            this.cdvResGrp.DisplayText = "";
            this.cdvResGrp.Focusing = null;
            this.cdvResGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp.Index = 0;
            this.cdvResGrp.IsViewBtnImage = false;
            this.cdvResGrp.Location = new System.Drawing.Point(115, 38);
            this.cdvResGrp.MaxLength = 20;
            this.cdvResGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp.MultiSelect = false;
            this.cdvResGrp.Name = "cdvResGrp";
            this.cdvResGrp.ReadOnly = false;
            this.cdvResGrp.SameWidthHeightOfButton = false;
            this.cdvResGrp.SearchSubItemIndex = 0;
            this.cdvResGrp.SelectedDescIndex = -1;
            this.cdvResGrp.SelectedDescToQueryText = "";
            this.cdvResGrp.SelectedSubItemIndex = -1;
            this.cdvResGrp.SelectedValueToQueryText = "";
            this.cdvResGrp.SelectionStart = 0;
            this.cdvResGrp.Size = new System.Drawing.Size(200, 20);
            this.cdvResGrp.SmallImageList = null;
            this.cdvResGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp.TabIndex = 3;
            this.cdvResGrp.TextBoxToolTipText = "";
            this.cdvResGrp.TextBoxWidth = 200;
            this.cdvResGrp.VisibleButton = true;
            this.cdvResGrp.VisibleColumnHeader = false;
            this.cdvResGrp.VisibleDescription = false;
            this.cdvResGrp.ButtonPress += new System.EventHandler(this.cdvResGrp_ButtonPress);
            // 
            // cdvResType
            // 
            this.cdvResType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResType.BtnToolTipText = "";
            this.cdvResType.ButtonWidth = 20;
            this.cdvResType.DescText = "";
            this.cdvResType.DisplaySubItemIndex = -1;
            this.cdvResType.DisplayText = "";
            this.cdvResType.Focusing = null;
            this.cdvResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResType.Index = 0;
            this.cdvResType.IsViewBtnImage = false;
            this.cdvResType.Location = new System.Drawing.Point(115, 14);
            this.cdvResType.MaxLength = 20;
            this.cdvResType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResType.MultiSelect = false;
            this.cdvResType.Name = "cdvResType";
            this.cdvResType.ReadOnly = false;
            this.cdvResType.SameWidthHeightOfButton = false;
            this.cdvResType.SearchSubItemIndex = 0;
            this.cdvResType.SelectedDescIndex = -1;
            this.cdvResType.SelectedDescToQueryText = "";
            this.cdvResType.SelectedSubItemIndex = -1;
            this.cdvResType.SelectedValueToQueryText = "";
            this.cdvResType.SelectionStart = 0;
            this.cdvResType.Size = new System.Drawing.Size(200, 20);
            this.cdvResType.SmallImageList = null;
            this.cdvResType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResType.TabIndex = 1;
            this.cdvResType.TextBoxToolTipText = "";
            this.cdvResType.TextBoxWidth = 200;
            this.cdvResType.VisibleButton = true;
            this.cdvResType.VisibleColumnHeader = false;
            this.cdvResType.VisibleDescription = false;
            this.cdvResType.ButtonPress += new System.EventHandler(this.cdvResType_ButtonPress);
            // 
            // lblResourceGroup
            // 
            this.lblResourceGroup.AutoSize = true;
            this.lblResourceGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResourceGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResourceGroup.Location = new System.Drawing.Point(10, 41);
            this.lblResourceGroup.Name = "lblResourceGroup";
            this.lblResourceGroup.Size = new System.Drawing.Size(85, 13);
            this.lblResourceGroup.TabIndex = 2;
            this.lblResourceGroup.Text = "Resource Group";
            // 
            // lblResourceType
            // 
            this.lblResourceType.AutoSize = true;
            this.lblResourceType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResourceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResourceType.Location = new System.Drawing.Point(10, 17);
            this.lblResourceType.Name = "lblResourceType";
            this.lblResourceType.Size = new System.Drawing.Size(80, 13);
            this.lblResourceType.TabIndex = 0;
            this.lblResourceType.Text = "Resource Type";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(407, 14);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(320, 20);
            this.pnlPeriod.TabIndex = 8;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(120, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(89, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(230, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(212, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // chkIncludeDelHistory
            // 
            this.chkIncludeDelHistory.AutoSize = true;
            this.chkIncludeDelHistory.Location = new System.Drawing.Point(407, 112);
            this.chkIncludeDelHistory.Name = "chkIncludeDelHistory";
            this.chkIncludeDelHistory.Size = new System.Drawing.Size(130, 17);
            this.chkIncludeDelHistory.TabIndex = 13;
            this.chkIncludeDelHistory.Text = "Include Delete History";
            this.chkIncludeDelHistory.CheckedChanged += new System.EventHandler(this.chkIncludeDelHistory_CheckedChanged);
            // 
            // cdvEventID
            // 
            this.cdvEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEventID.BtnToolTipText = "";
            this.cdvEventID.ButtonWidth = 20;
            this.cdvEventID.DescText = "";
            this.cdvEventID.DisplaySubItemIndex = -1;
            this.cdvEventID.DisplayText = "";
            this.cdvEventID.Focusing = null;
            this.cdvEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEventID.Index = 0;
            this.cdvEventID.IsViewBtnImage = false;
            this.cdvEventID.Location = new System.Drawing.Point(115, 86);
            this.cdvEventID.MaxLength = 12;
            this.cdvEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MultiSelect = false;
            this.cdvEventID.Name = "cdvEventID";
            this.cdvEventID.ReadOnly = false;
            this.cdvEventID.SameWidthHeightOfButton = false;
            this.cdvEventID.SearchSubItemIndex = 0;
            this.cdvEventID.SelectedDescIndex = -1;
            this.cdvEventID.SelectedDescToQueryText = "";
            this.cdvEventID.SelectedSubItemIndex = -1;
            this.cdvEventID.SelectedValueToQueryText = "";
            this.cdvEventID.SelectionStart = 0;
            this.cdvEventID.Size = new System.Drawing.Size(200, 20);
            this.cdvEventID.SmallImageList = null;
            this.cdvEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEventID.TabIndex = 7;
            this.cdvEventID.TextBoxToolTipText = "";
            this.cdvEventID.TextBoxWidth = 200;
            this.cdvEventID.VisibleButton = true;
            this.cdvEventID.VisibleColumnHeader = false;
            this.cdvEventID.VisibleDescription = false;
            this.cdvEventID.ButtonPress += new System.EventHandler(this.cdvEventID_ButtonPress);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(10, 89);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(49, 13);
            this.lblEvent.TabIndex = 6;
            this.lblEvent.Text = "Event ID";
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.ButtonWidth = 20;
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(115, 62);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MultiSelect = false;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SameWidthHeightOfButton = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedDescToQueryText = "";
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectedValueToQueryText = "";
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 5;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(10, 65);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 4;
            this.lblResID.Text = "Resource ID";
            // 
            // pnlMainBody
            // 
            this.pnlMainBody.Controls.Add(this.tabHistory);
            this.pnlMainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainBody.Location = new System.Drawing.Point(0, 137);
            this.pnlMainBody.Name = "pnlMainBody";
            this.pnlMainBody.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlMainBody.Size = new System.Drawing.Size(742, 376);
            this.pnlMainBody.TabIndex = 1;
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.tbpView1);
            this.tabHistory.Controls.Add(this.tbpView2);
            this.tabHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHistory.Location = new System.Drawing.Point(3, 5);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.SelectedIndex = 0;
            this.tabHistory.Size = new System.Drawing.Size(736, 368);
            this.tabHistory.TabIndex = 0;
            this.tabHistory.TabStop = false;
            // 
            // tbpView1
            // 
            this.tbpView1.Controls.Add(this.spdHistoryBrief);
            this.tbpView1.Location = new System.Drawing.Point(4, 22);
            this.tbpView1.Name = "tbpView1";
            this.tbpView1.Size = new System.Drawing.Size(728, 342);
            this.tbpView1.TabIndex = 0;
            this.tbpView1.Text = "View 1";
            // 
            // spdHistoryBrief
            // 
            this.spdHistoryBrief.AccessibleDescription = "";
            this.spdHistoryBrief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistoryBrief.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdHistoryBrief.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistoryBrief.HorizontalScrollBar.Name = "";
            this.spdHistoryBrief.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdHistoryBrief.HorizontalScrollBar.TabIndex = 2;
            this.spdHistoryBrief.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdHistoryBrief.Location = new System.Drawing.Point(0, 0);
            this.spdHistoryBrief.Name = "spdHistoryBrief";
            this.spdHistoryBrief.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistoryBrief.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistoryBrief.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistoryBrief_Sheet1});
            this.spdHistoryBrief.Size = new System.Drawing.Size(728, 342);
            this.spdHistoryBrief.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistoryBrief.TabIndex = 0;
            this.spdHistoryBrief.TabStop = false;
            this.spdHistoryBrief.TextTipDelay = 200;
            this.spdHistoryBrief.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistoryBrief.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistoryBrief.VerticalScrollBar.Name = "";
            this.spdHistoryBrief.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdHistoryBrief.VerticalScrollBar.TabIndex = 3;
            this.spdHistoryBrief.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdHistoryBrief_CellClick);
            this.spdHistoryBrief.SetViewportLeftColumn(0, 0, 3);
            this.spdHistoryBrief.SetActiveViewport(0, 0, -1);
            // 
            // spdHistoryBrief_Sheet1
            // 
            this.spdHistoryBrief_Sheet1.Reset();
            spdHistoryBrief_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistoryBrief_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistoryBrief_Sheet1.ColumnCount = 8;
            spdHistoryBrief_Sheet1.RowCount = 5;
            spdHistoryBrief_Sheet1.RowHeader.ColumnCount = 0;
            this.spdHistoryBrief_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.White;
            this.spdHistoryBrief_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistoryBrief_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistoryBrief_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistoryBrief_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "_";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Seq";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Time";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Event ID";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Up/Down";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Primary Status";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Last Down Time";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Tran User ID";
            this.spdHistoryBrief_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistoryBrief_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistoryBrief_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.Gainsboro;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistoryBrief_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).Label = "_";
            this.spdHistoryBrief_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(0).Width = 23F;
            this.spdHistoryBrief_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(1).Label = "Seq";
            this.spdHistoryBrief_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(1).Width = 42F;
            this.spdHistoryBrief_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistoryBrief_Sheet1.Columns.Get(2).Label = "Tran Time";
            this.spdHistoryBrief_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(2).Width = 135F;
            this.spdHistoryBrief_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistoryBrief_Sheet1.Columns.Get(3).Label = "Event ID";
            this.spdHistoryBrief_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(3).Width = 100F;
            this.spdHistoryBrief_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistoryBrief_Sheet1.Columns.Get(4).Label = "Up/Down";
            this.spdHistoryBrief_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(4).Width = 70F;
            this.spdHistoryBrief_Sheet1.Columns.Get(5).Label = "Primary Status";
            this.spdHistoryBrief_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(5).Width = 110F;
            this.spdHistoryBrief_Sheet1.Columns.Get(6).Label = "Last Down Time";
            this.spdHistoryBrief_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(6).Width = 130F;
            this.spdHistoryBrief_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistoryBrief_Sheet1.Columns.Get(7).Label = "Tran User ID";
            this.spdHistoryBrief_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistoryBrief_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistoryBrief_Sheet1.Columns.Get(7).Width = 100F;
            this.spdHistoryBrief_Sheet1.FrozenColumnCount = 3;
            this.spdHistoryBrief_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistoryBrief_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdHistoryBrief_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdHistoryBrief_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistoryBrief_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistoryBrief_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistoryBrief_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistoryBrief_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdHistoryBrief_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpView2
            // 
            this.tbpView2.Controls.Add(this.spdHistory);
            this.tbpView2.Location = new System.Drawing.Point(4, 22);
            this.tbpView2.Name = "tbpView2";
            this.tbpView2.Size = new System.Drawing.Size(728, 342);
            this.tbpView2.TabIndex = 1;
            this.tbpView2.Text = "View 2";
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1, Row 0, Column 0, ";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.ContextMenu = this.ctxHistoryMain;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdHistory.HorizontalScrollBar.TabIndex = 4;
            this.spdHistory.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHistory.Location = new System.Drawing.Point(0, 0);
            this.spdHistory.Name = "spdHistory";
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(728, 342);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 1;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdHistory.VerticalScrollBar.TabIndex = 5;
            this.spdHistory.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 43;
            spdHistory_Sheet1.RowCount = 5;
            spdHistory_Sheet1.RowHeader.ColumnCount = 0;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 1).Locked = true;
            this.spdHistory_Sheet1.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 1).Locked = true;
            this.spdHistory_Sheet1.Cells.Get(1, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 1).Locked = true;
            this.spdHistory_Sheet1.Cells.Get(2, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 1).Locked = true;
            this.spdHistory_Sheet1.Cells.Get(3, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 1).Locked = true;
            this.spdHistory_Sheet1.Cells.Get(4, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Numbers;
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Event";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Up Down";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Primary Status";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "New Status 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "New Status 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "New Status 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "New Status 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "New Status 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "New Status 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "New Status 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "New Status 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "New Status 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "New Status 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Tran Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Tran Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Tran Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Tran Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Tran Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Tran Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Tran Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Tran Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Tran Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Tran Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Tran Cmf 11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Tran Cmf 12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Tran Cmf 13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Tran Cmf 14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Tran Cmf 15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Tran Cmf 16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Tran Cmf 17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Tran Cmf 18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Tran Cmf 19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Tran Cmf 20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Process Mode";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Control Mode";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "User Name";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Hist Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Hist Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Hist Delete User Name";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Hist Delete Comment";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 50F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Event";
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 88F;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Up Down";
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Primary Status";
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 105F;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "New Status 1";
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "New Status 2";
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "New Status 3";
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "New Status 4";
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "New Status 5";
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "New Status 6";
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "New Status 7";
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "New Status 8";
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "New Status 9";
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "New Status 10";
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Tran Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Tran Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Tran Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Tran Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Tran Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(19).Locked = false;
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Tran Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Tran Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Tran Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Tran Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Tran Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Tran Cmf 11";
            this.spdHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Tran Cmf 12";
            this.spdHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Tran Cmf 13";
            this.spdHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Tran Cmf 14";
            this.spdHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Tran Cmf 15";
            this.spdHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Tran Cmf 16";
            this.spdHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Tran Cmf 17";
            this.spdHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Tran Cmf 18";
            this.spdHistory_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(32).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Tran Cmf 19";
            this.spdHistory_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(33).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Tran Cmf 20";
            this.spdHistory_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(34).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "Process Mode";
            this.spdHistory_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(35).Width = 118F;
            this.spdHistory_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(36).Label = "Control Mode";
            this.spdHistory_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(36).Width = 118F;
            this.spdHistory_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(37).Label = "User Name";
            this.spdHistory_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(37).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(38).Label = "Comment";
            this.spdHistory_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(38).Width = 200F;
            this.spdHistory_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(39).Label = "Hist Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(39).Width = 105F;
            this.spdHistory_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(40).Label = "Hist Delete Time";
            this.spdHistory_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(40).Width = 107F;
            this.spdHistory_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(41).Label = "Hist Delete User Name";
            this.spdHistory_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(41).Width = 139F;
            this.spdHistory_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(42).Label = "Hist Delete Comment";
            this.spdHistory_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(42).Width = 144F;
            this.spdHistory_Sheet1.DefaultStyle.Locked = false;
            this.spdHistory_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdHistory_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.Rows.Default.Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnExpand
            // 
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExpand.Image = ((System.Drawing.Image)(resources.GetObject("btnExpand.Image")));
            this.btnExpand.Location = new System.Drawing.Point(82, 8);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(24, 24);
            this.btnExpand.TabIndex = 4;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapse.Image")));
            this.btnCollapse.Location = new System.Drawing.Point(50, 8);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(24, 24);
            this.btnCollapse.TabIndex = 3;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // imlSPIcons
            // 
            this.imlSPIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSPIcons.ImageStream")));
            this.imlSPIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSPIcons.Images.SetKeyName(0, "");
            this.imlSPIcons.Images.SetKeyName(1, "");
            this.imlSPIcons.Images.SetKeyName(2, "");
            this.imlSPIcons.Images.SetKeyName(3, "");
            // 
            // frmRASViewResourceHistory
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlMainBody);
            this.Controls.Add(this.pnlMainHeader);
            this.Name = "frmRASViewResourceHistory";
            this.Text = "View Resource History";
            this.Activated += new System.EventHandler(this.frmRASViewResourceHistory_Activated);
            this.Load += new System.EventHandler(this.frmRASViewResourceHistory_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlMainHeader, 0);
            this.Controls.SetChildIndex(this.pnlMainBody, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMainHeader.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlMainBody.ResumeLayout(false);
            this.tabHistory.ResumeLayout(false);
            this.tbpView1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdHistoryBrief)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistoryBrief_Sheet1)).EndInit();
            this.tbpView2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int COL_ICON = 0;
        private const int COL_HIST_SEQ = 1;
        private const int COL_TRAN_TIME = 2;
        private const int COL_EVENT = 3;
        private const int COL_UP_DOWN = 4;
        private const int COL_PRI_STS = 5;
        private const int COL_LAST_DOWN_TIME = 6;
        private const int COL_TRAN_USER = 7;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        private FarPoint.Win.Spread.CellType.GeneralCellType plusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType minusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType emptyCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType checkCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        
        private enum CELL_STATUS
        {
            PLUS = 1,
            MINUS = 2,
            EMPTY = 3,
            CHECK = 4
        }
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(char ProcStep)
        {
            
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this.tbpView1);
                    MPCF.FieldClear(this.tbpView2);
                    MPCF.ClearList(spdHistoryBrief, true);
                    
                    MPCF.FitColumnHeader(spdHistory);
                    MPCF.ClearList(spdHistory, true);
                    
                    int i;
                    for (i = 5; i <= 14; i++)
                    {
                        spdHistory.Sheets[0].Columns[i].Visible = false;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, i].Text = "";
                    }
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

            if (MPCF.CheckValue(cdvResID, 1) == false)
            {
                return false;
            }
            
            return true;
            
        }
        
        private bool View_Resource()
        {
            TRSNode in_node = new TRSNode("View_Resource_In");
            TRSNode out_node = new TRSNode("View_Resource_Out");
              
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", cdvResID.Text);

                if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("USE_FAC_PRT_FLAG") != 'Y')
                {
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_1")) != "")
                    {
                        spdHistory.Sheets[0].Columns[5].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, 5].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_1"));
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_2")) != "")
                    {
                        spdHistory.Sheets[0].Columns[6].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, 6].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_2"));
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_3")) != "")
                    {
                        spdHistory.Sheets[0].Columns[7].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, 7].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_3"));
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_4")) != "")
                    {
                        spdHistory.Sheets[0].Columns[8].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, 8].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_4"));
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_5")) != "")
                    {
                        spdHistory.Sheets[0].Columns[9].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, 9].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_5"));
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_6")) != "")
                    {
                        spdHistory.Sheets[0].Columns[10].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, 10].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_6"));
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_7")) != "")
                    {
                        spdHistory.Sheets[0].Columns[11].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, 11].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_7"));
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_8")) != "")
                    {
                        spdHistory.Sheets[0].Columns[12].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, 12].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_8"));
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_9")) != "")
                    {
                        spdHistory.Sheets[0].Columns[13].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, 13].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_9"));
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_10")) != "")
                    {
                        spdHistory.Sheets[0].Columns[14].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, 14].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_10"));
                    }
                    
                }
                else
                {
                    View_Factory_ResStatus();
                }
                
                MPCF.FitColumnHeader(spdHistory);
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        
        // View_Factory_ResStatus()
        //       -  View Factory Resource Status Prompt
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool View_Factory_ResStatus()
        {
            TRSNode in_node = new TRSNode("View_Factory_In");
            TRSNode out_node = new TRSNode("View_Factory_Out");
              
             try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPCR.CallService("WIP", "WIP_View_Factory", in_node, ref out_node) == false)
                {
                    return false;
                }

                
                if (MPCF.Trim(out_node.GetString("RES_STS_1")) != "")
                {
                    spdHistory.Sheets[0].Columns[5].Visible = true;
                    spdHistory.Sheets[0].ColumnHeader.Cells[0, 5].Text = MPCF.Trim(out_node.GetString("RES_STS_1"));
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_2")) != "")
                {
                    spdHistory.Sheets[0].Columns[6].Visible = true;
                    spdHistory.Sheets[0].ColumnHeader.Cells[0, 6].Text = MPCF.Trim(out_node.GetString("RES_STS_2"));
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_3")) != "")
                {
                    spdHistory.Sheets[0].Columns[7].Visible = true;
                    spdHistory.Sheets[0].ColumnHeader.Cells[0, 7].Text = MPCF.Trim(out_node.GetString("RES_STS_3"));
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_4")) != "")
                {
                    spdHistory.Sheets[0].Columns[8].Visible = true;
                    spdHistory.Sheets[0].ColumnHeader.Cells[0, 8].Text = MPCF.Trim(out_node.GetString("RES_STS_4"));
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_5")) != "")
                {
                    spdHistory.Sheets[0].Columns[9].Visible = true;
                    spdHistory.Sheets[0].ColumnHeader.Cells[0, 9].Text = MPCF.Trim(out_node.GetString("RES_STS_5"));
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_6")) != "")
                {
                    spdHistory.Sheets[0].Columns[10].Visible = true;
                    spdHistory.Sheets[0].ColumnHeader.Cells[0, 10].Text = MPCF.Trim(out_node.GetString("RES_STS_6"));
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_7")) != "")
                {
                    spdHistory.Sheets[0].Columns[11].Visible = true;
                    spdHistory.Sheets[0].ColumnHeader.Cells[0, 11].Text = MPCF.Trim(out_node.GetString("RES_STS_7"));
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_8")) != "")
                {
                    spdHistory.Sheets[0].Columns[12].Visible = true;
                    spdHistory.Sheets[0].ColumnHeader.Cells[0, 12].Text = MPCF.Trim(out_node.GetString("RES_STS_8"));
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_9")) != "")
                {
                    spdHistory.Sheets[0].Columns[13].Visible = true;
                    spdHistory.Sheets[0].ColumnHeader.Cells[0, 13].Text = MPCF.Trim(out_node.GetString("RES_STS_9"));
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_10")) != "")
                {
                    spdHistory.Sheets[0].Columns[14].Visible = true;
                    spdHistory.Sheets[0].ColumnHeader.Cells[0, 14].Text = MPCF.Trim(out_node.GetString("RES_STS_10"));
                }
                
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        // ViewResourceHistory()
        //       - View Resource History Detail
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        - ByVal c_step As String                        : ?•ìž¥ Process Step
        //        - ByVal sResID As String                    : Res id
        //        - Optional ByVal sFromTime As String = ""   : ?œìž‘ ?œê°„
        //        - Optional ByVal sToTime As String = ""     : ë§ˆì?ë§??œê°„
        //        - Optional ByVal sIncludeDelHistory As String = ""  : Delete Historyê¹Œì? ?¬í•¨??ê²ƒì¸ì§€?
        //
        private bool ViewResourceHistory(string sResID, string sIncludeDeleteHistory, string sEventID, string sFromTime, string sToTime)
        {
            
            int i;
            int iRow;
            string sDetail;

            TRSNode in_node = new TRSNode("View_Resource_History_In");
            TRSNode out_node;
            
          
            try
            {
                
                MPCF.ClearList(spdHistoryBrief, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(sResID));
                in_node.AddString("EVENT_ID", MPCF.Trim(sEventID));
                in_node.AddString("FROM_TIME", MPCF.Trim(sFromTime));
                in_node.AddString("TO_TIME", MPCF.Trim(sToTime));
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                in_node.AddChar("INCLUDE_DEL_HIST", MPCF.ToChar(MPCF.Trim(sIncludeDeleteHistory)));
                
                do
                {
                    out_node = new TRSNode("View_Resource_History_Out");

                    if (MPCR.CallService("RAS", "RAS_View_Resource_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                   
                    
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        FarPoint.Win.Spread.SheetView with_1 = spdHistoryBrief.Sheets[0];
                        
                        iRow = with_1.RowCount;
                        with_1.RowCount++;
                        
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG")) == "Y")
                        {
                            with_1.Cells[iRow, COL_TRAN_TIME, iRow, with_1.ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else
                        {
                            with_1.Cells[iRow, COL_TRAN_TIME, iRow, with_1.ColumnCount - 1].ForeColor = Color.Black;
                        }
                        
                        with_1.Cells[iRow, COL_HIST_SEQ, iRow, with_1.ColumnCount - 1].Font = new Font(spdHistoryBrief.Font.Name, spdHistoryBrief.Font.Size, FontStyle.Bold);
                        
                        with_1.Cells[iRow, COL_ICON].CellType = minusCellType;
                        with_1.Cells[iRow, COL_ICON].Tag = CELL_STATUS.MINUS;

                        with_1.Cells[iRow, COL_HIST_SEQ].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                        with_1.Cells[iRow, COL_TRAN_TIME].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        with_1.Cells[iRow, COL_EVENT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID"));
                        with_1.Cells[iRow, COL_UP_DOWN].Value = (MPCF.Trim(out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG")) == "U") ? "UP" : "DOWN";
                        with_1.Cells[iRow, COL_PRI_STS].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_PRI_STS"));
                        with_1.Cells[iRow, COL_LAST_DOWN_TIME].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("LAST_DOWN_TIME")));
                        with_1.Cells[iRow, COL_TRAN_USER].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));

                        
                        sDetail = "Pri Status : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_PRI_STS")) + " -> " + MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_PRI_STS"));
                        
                        AddRow(sDetail);
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_1")) != MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_1")))
                        {
                            sDetail = "Status 1 : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_1")) + " -> " + MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_1"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_2")) != MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_2")))
                        {
                            sDetail = "Status 2 : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_2")) + " -> " + MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_2"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_3")) != MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_3")))
                        {
                            sDetail = "Status 3 : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_3")) + " -> " + MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_3"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_4")) != MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_4")))
                        {
                            sDetail = "Status 4 : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_4")) + " -> " + MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_4"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_5")) != MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_5")))
                        {
                            sDetail = "Status 5 : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_5")) + " -> " + MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_5"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_6")) != MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_6")))
                        {
                            sDetail = "Status 6 : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_6")) + " -> " + MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_6"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_7")) != MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_7")))
                        {
                            sDetail = "Status 7 : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_7")) + " -> " + MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_7"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_8")) != MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_8")))
                        {
                            sDetail = "Status 8 : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_8")) + " -> " + MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_8"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_9")) != MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_9")))
                        {
                            sDetail = "Status 9 : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_9")) + " -> " + MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_9"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_10")) != MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_10")))
                        {
                            sDetail = "Status 10 : " + MPCF.Trim(out_node.GetList(0)[i].GetString("OLD_STS_10")) + " -> " + MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_10"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("LOT_EXIST_FLAG")) == "Y")
                        {
                            sDetail = "Lot Exist : Yes";
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")) != "")
                        {
                            sDetail = "Lot ID : " + MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID")) != "")
                        {
                            sDetail = "CRR ID : " + MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID"));
                            
                            AddRow(sDetail);
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID")) != "")
                        {
                            sDetail = "Collection Set ID : " + MPCF.Trim(out_node.GetList(0)[i].GetString("COL_SET_ID")) + "     Collection Set Version : " + MPCF.Trim(out_node.GetList(0)[i].GetInt("COL_SET_VERSION"));
                            
                            AddRow(sDetail);
                        }
                        
                        PrintCmf(out_node.GetList(0)[i]);
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_COMMENT")) != "")
                        {
                            AddRow(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_COMMENT")));
                        }
                        
                        UnderLine();
                    }
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                   
                  } while (in_node.GetInt("NEXT_HIST_SEQ") > 0 );
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
        }
        
        // AddRow()
        //       - Add one Row in spdHistoryBrief
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void AddRow(string sDetail)
        {
            int iRow;
            
            FarPoint.Win.Spread.SheetView with_1 = spdHistoryBrief.Sheets[0];
            iRow = with_1.RowCount;
            
            with_1.RowCount++;
            with_1.AddSpanCell(iRow, COL_TRAN_TIME, 1, 8);
            with_1.Cells[iRow, COL_TRAN_TIME].Value = sDetail;
            with_1.Cells[iRow, COL_TRAN_TIME].Font = new Font(spdHistoryBrief.Font.Name, 8);
            with_1.Cells[iRow, COL_TRAN_TIME].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            with_1.Cells[iRow, COL_TRAN_TIME].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            with_1.Rows[iRow].Height = 13;
            
        }
        
        // UnderLine()
        //       - Add Under Line Border in spdHistoryBrief
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void UnderLine()
        {
            
            spdHistoryBrief.Sheets[0].Rows[spdHistoryBrief.Sheets[0].RowCount - 1].Height = 16;
            
            spdHistoryBrief.Sheets[0].Cells[spdHistoryBrief.Sheets[0].RowCount - 1, COL_ICON, spdHistoryBrief.Sheets[0].RowCount - 1, spdHistoryBrief.Sheets[0].ColumnCount - 1].Border = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None), new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.ThinLine));
        }
        
        // PrintCmf()
        //       - Print Cmf
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void PrintCmf(TRSNode out_node)
        {
            string sDetail;

            if (out_node.GetString("TRAN_CMF_1") != "")
            {
                sDetail = "Cmf 1 : " + out_node.GetString("TRAN_CMF_1");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_2") != "")
            {
                sDetail = "Cmf 2 : " + out_node.GetString("TRAN_CMF_2");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_3") != "")
            {
                sDetail = "Cmf 3 : " + out_node.GetString("TRAN_CMF_3");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_4") != "")
            {
                sDetail = "Cmf 4 : " + out_node.GetString("TRAN_CMF_4");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_5") != "")
            {
                sDetail = "Cmf 5 : " + out_node.GetString("TRAN_CMF_5");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_6") != "")
            {
                sDetail = "Cmf 6 : " + out_node.GetString("TRAN_CMF_6");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_7") != "")
            {
                sDetail = "Cmf 7 : " + out_node.GetString("TRAN_CMF_7");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_8") != "")
            {
                sDetail = "Cmf 8 : " + out_node.GetString("TRAN_CMF_8");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_9") != "")
            {
                sDetail = "Cmf 9 : " + out_node.GetString("TRAN_CMF_9");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_10") != "")
            {
                sDetail = "Cmf 10 : " + out_node.GetString("TRAN_CMF_10");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_11") != "")
            {
                sDetail = "Cmf 11 : " + out_node.GetString("TRAN_CMF_11");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_12") != "")
            {
                sDetail = "Cmf 12 : " + out_node.GetString("TRAN_CMF_12");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_13") != "")
            {
                sDetail = "Cmf 13 : " + out_node.GetString("TRAN_CMF_13");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_14") != "")
            {
                sDetail = "Cmf 14 : " + out_node.GetString("TRAN_CMF_14");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_15") != "")
            {
                sDetail = "Cmf 15 : " + out_node.GetString("TRAN_CMF_15");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_16") != "")
            {
                sDetail = "Cmf 16 : " + out_node.GetString("TRAN_CMF_16");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_17") != "")
            {
                sDetail = "Cmf 17 : " + out_node.GetString("TRAN_CMF_17");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_18") != "")
            {
                sDetail = "Cmf 18 : " + out_node.GetString("TRAN_CMF_18");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_19") != "")
            {
                sDetail = "Cmf 19 : " + out_node.GetString("TRAN_CMF_19");
                AddRow(sDetail);
            }
            if (out_node.GetString("TRAN_CMF_20") != "")
            {
                sDetail = "Cmf 20 : " + out_node.GetString("TRAN_CMF_20");
                AddRow(sDetail);
            }

            
        }
        
        public void ActiveFormNow()
        {
            if (MPCF.Trim(MPGV.gsCurrentRes_ID) != "")
            {
                cdvResID.Text = MPGV.gsCurrentRes_ID;
                btnProcess_Click(btnProcess, null);
            }
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvResID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            string sFromTime;
            string sToTime;
            char sIncludeDelHist;

            if (MPCF.CheckValue(cdvResID, 1) == false)
            {
                return;
            }
            
            sFromTime = MPCF.FromDate(dtpFrom);
            sToTime = MPCF.ToDate(dtpTo);
            sIncludeDelHist = chkIncludeDelHistory.Checked == true ? 'Y' : ' ';
            
            if (ViewResourceHistory(cdvResID.Text, sIncludeDelHist.ToString(), cdvEventID.Text, sFromTime, sToTime) == false)
            {
                return;
            }
            if (View_Resource() == false)
            {
                return;
            }
            if (RASLIST.ViewResourceHistory(spdHistory, '1', cdvResID.Text, sIncludeDelHist, cdvEventID.Text, sFromTime, sToTime, null, false) == false)
            {
                return;
            }
            MPCF.FitColumnHeader(spdHistory);
            
        }
        
        private void frmRASViewResourceHistory_Load(System.Object sender, System.EventArgs e)
        {
            
            plusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.PLUS) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            minusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.MINUS) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            emptyCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.EMPTY) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            checkCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.CHECK) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Right, FarPoint.Win.VerticalAlignment.Center);
            
        }
        
        private void frmRASViewResourceHistory_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                ClearData('1');
                
                dtpFrom.Value = DateTime.Today.AddDays(-3);
                dtpTo.Value = DateTime.Today;

                ActiveFormNow();
                
                b_load_flag = true;

                if (MPCF.Trim(MPGV.gsCurrentRes_ID) != "")
                {
                    cdvResID.Text = MPGV.gsCurrentRes_ID;
                    cdvResID_SelectedItemChanged(null, null);
                    MPGV.gsCurrentRes_ID = "";
                }
            }
        }
        
        private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            ClearData('1');
            cdvEventID.Items.Clear();       
        }
        
        private void cdvResID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            ClearData('1');
            btnProcess.Text = MPCF.FindLanguage("View", 1);            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Resource ID : " + MPCF.Trim(cdvResID.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) +" ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            
            if (tabHistory.SelectedTab == tbpView1)
            {
                MPCF.ExportToExcel(spdHistoryBrief, this.Text, sCond);
            }
            else
            {
                MPCF.ExportToExcel(spdHistory, this.Text, sCond);
            }
        }
        
        private void ctxCopy_Click(System.Object sender, System.EventArgs e)
        {
            spdHistory_Sheet1.ClipboardCopy();
        }
        
        private void chkIncludeDelHistory_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            btnProcess.Text = MPCF.FindLanguage("View", 1);            
            btnProcess_Click(sender, e);
        }
        
        private void cdvEventID_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvResID, 1) == false)
            {
                return;
            }
            cdvEventID.Init();
            MPCF.InitListView(cdvEventID.GetListView);
            cdvEventID.Columns.Add("EventID", 50, HorizontalAlignment.Left);
            cdvEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvEventID.SelectedSubItemIndex = 0;
            RASLIST.ViewResEventList(cdvEventID.GetListView, '1', cdvResID.Text, null, "");
        }
        
        
        private void spdHistoryBrief_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int i;
            
            if (e.Column != COL_ICON)
            {
                return;
            }
            if (e.Row < 0)
            {
                return;
            }
            if (e.ColumnHeader == true)
            {
                return;
            }
            if (e.RowHeader == true)
            {
                return;
            }
            
            FarPoint.Win.Spread.SheetView with_1 = spdHistoryBrief.Sheets[0];
            if (MPCF.Trim(with_1.Cells[e.Row, COL_ICON].Tag) == "")
            {
                return;
            }
            
            for (i = e.Row + 1; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, COL_ICON].Tag) != "")
                {
                    break;
                }
                
                if (MPCF.ToInt(with_1.Cells[e.Row, COL_ICON].Tag) == (int)CELL_STATUS.MINUS)
                {
                    with_1.Rows[i].Visible = false;
                }
                else
                {
                    with_1.Rows[i].Visible = true;
                }
            }
            
            if (MPCF.ToInt(with_1.Cells[e.Row, COL_ICON].Tag) == (int)CELL_STATUS.MINUS)
            {
                with_1.Cells[e.Row, COL_ICON].CellType = plusCellType;
                with_1.Cells[e.Row, COL_ICON].Tag = CELL_STATUS.PLUS;
            }
            else if (MPCF.ToInt(with_1.Cells[e.Row, COL_ICON].Tag) == (int)CELL_STATUS.PLUS)
            {
                with_1.Cells[e.Row, COL_ICON].CellType = minusCellType;
                with_1.Cells[e.Row, COL_ICON].Tag = CELL_STATUS.MINUS;
            }
            
        }
        
        private void btnCollapse_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            
            FarPoint.Win.Spread.SheetView with_1 = spdHistoryBrief.Sheets[0];
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, COL_ICON].Tag) == "")
                {
                    with_1.Rows[i].Visible = false;
                }
                else
                {
                    if (MPCF.ToInt(with_1.Cells[i, COL_ICON].Tag) == (int)CELL_STATUS.MINUS)
                    {
                        with_1.Cells[i, COL_ICON].CellType = plusCellType;
                        with_1.Cells[i, COL_ICON].Tag = CELL_STATUS.PLUS;
                    }
                }
            }
            
        }
        
        private void btnExpand_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            
            FarPoint.Win.Spread.SheetView with_1 = spdHistoryBrief.Sheets[0];
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, COL_ICON].Tag) == "")
                {
                    with_1.Rows[i].Visible = true;
                }
                else
                {
                    if (MPCF.ToInt(with_1.Cells[i, COL_ICON].Tag) == (int)CELL_STATUS.PLUS)
                    {
                        with_1.Cells[i, COL_ICON].CellType = minusCellType;
                        with_1.Cells[i, COL_ICON].Tag = CELL_STATUS.MINUS;
                    }
                }
            }
            
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            cdvResID.DisplaySubItemIndex = 0;

            RASLIST.ViewResourceList(cdvResID.GetListView, '1', MPCF.Trim(cdvResGrp.Text), MPCF.Trim(cdvResType.Text), "", "", MPCF.Trim(cdvMaterial.Text),
                cdvMaterial.Version, MPCF.Trim(cdvFlow.Text), MPCF.Trim(cdvOperation.Text), ' ', "", true, null, "");
        }

        private void cdvResType_ButtonPress(object sender, EventArgs e)
        {
            MPCF.FieldClear(this.grpOption);

            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;

            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_RAS_RES_TYPE);
            if (cdvTemp.AddEmptyRow(1) == false)
            {
                return;
            }
        }

        private void cdvResGrp_ButtonPress(object sender, EventArgs e)
        {
            cdvResGrp.Init();

            MPCF.FieldClear(this, cdvResType, cdvMaterial, cdvFlow, cdvOperation, null, false);

            MPCF.InitListView(cdvResGrp.GetListView);
            cdvResGrp.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvResGrp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResGrp.SelectedSubItemIndex = 0;

            if (cdvResType.Text == "")
            {
                if (RASLIST.ViewResourceGroupList(cdvResGrp.GetListView, '1') == false) return;
            }
            else
            {
                if (RASLIST.ViewResourceGroupList(cdvResGrp.GetListView, '4', "", cdvResType.Text) == false) return;
            }
            cdvResGrp.AddEmptyRow(1);
        }

        private void cdvMaterial_MaterialSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvFlow.Text = "";
            cdvOperation.Text = "";
        }

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvMaterial.Text) == "")
            {
                cdvFlow.ListCond_Step = '1';
                cdvFlow.ListCond_MatID = "";
                cdvFlow.ListCond_MatVersion = 0;
            }
            else
            {
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;
            }
        }

        private void cdvFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvOperation.Text = "";
        }

        private void cdvOperation_ButtonPress(object sender, EventArgs e)
        {
            cdvOperation.Init();
            MPCF.InitListView(cdvOperation.GetListView);
            cdvOperation.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOperation.SelectedSubItemIndex = 0;

            if (MPCF.Trim(cdvFlow.Text) == "")
            {
                WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0, "", "", null, "");
                cdvOperation.AddEmptyRow(1);
            }
            else
            {
                WIPLIST.ViewOperationList(cdvOperation.GetListView, '2', "", 0, MPCF.Trim(cdvFlow.Text), "", null, "");
                cdvOperation.AddEmptyRow(1);
            }
        }
    }

}
