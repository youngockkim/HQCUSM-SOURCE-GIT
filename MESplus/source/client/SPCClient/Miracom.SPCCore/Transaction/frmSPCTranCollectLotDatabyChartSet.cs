
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;
using Miracom.TRSCore;  
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCTranCollectLotDatabyChartSet.vb
//   Description : Collect EDC Data by Character
//
//   SPC Version : 1.0.0
//
//   Function List
//       - CheckCondition : Check the conditions before transaction
//       - View_Lot : View Lot Information
//       - SetChartControl : Set Chart Control
//       - SetCollectData : Set Collection Information
//       - EnableInput : Set Enable Property
//
//   Detail Description
//       -
//
//   History
//       - 2005-05-09 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCTranCollectLotDatabyChartSet : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranCollectLotDatabyChartSet()
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
        



        protected System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnRawData;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlCenter;
        internal System.Windows.Forms.GroupBox grpLot;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvProcResID;
        internal System.Windows.Forms.Label lblProcResID;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvProcOper;
        internal System.Windows.Forms.Label lblProcOper;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        internal System.Windows.Forms.Label lblResID;
        internal System.Windows.Forms.Label lblOper;
        protected System.Windows.Forms.GroupBox grpLotID;
        protected System.Windows.Forms.Panel pnlTranTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtTranTime;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtTranTime;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccTranDate;
        protected Infragistics.Win.UltraWinEditors.UltraCheckEditor chkTranDateTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDesc;
        protected System.Windows.Forms.Label lblLotDesc;
        protected System.Windows.Forms.Label lblLotID;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartSetID;
        internal System.Windows.Forms.Label lblChartSetID;
        internal System.Windows.Forms.GroupBox grpChartSet;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtLot;
        internal System.Windows.Forms.Panel pnlChartSet;
        internal System.Windows.Forms.Button btnGraph;
        internal System.Windows.Forms.Button btnHistogram;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvUserID;
        internal System.Windows.Forms.Label lblUserID;
        protected Infragistics.Win.UltraWinEditors.UltraCheckEditor chkSelectMFO;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranCollectLotDatabyChartSet));
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.btnRawData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlChartSet = new System.Windows.Forms.Panel();
            this.grpChartSet = new System.Windows.Forms.GroupBox();
            this.cdvUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUserID = new System.Windows.Forms.Label();
            this.cdvChartSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartSetID = new System.Windows.Forms.Label();
            this.grpLot = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.chkSelectMFO = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cdvProcResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcResID = new System.Windows.Forms.Label();
            this.cdvProcOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcOper = new System.Windows.Forms.Label();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblOper = new System.Windows.Forms.Label();
            this.grpLotID = new System.Windows.Forms.GroupBox();
            this.txtLot = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.udtTranTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccTranDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.chkTranDateTime = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtDesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblLotDesc = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.grpChartSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).BeginInit();
            this.grpLot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectMFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.grpLotID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLot)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTranTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTranTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTranDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTranDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnHistogram);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnGraph);
            this.pnlBottom.Controls.Add(this.btnRawData);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 596);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.pnlBottom.Size = new System.Drawing.Size(792, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnHistogram
            // 
            this.btnHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistogram.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHistogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistogram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHistogram.Location = new System.Drawing.Point(424, 8);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(88, 26);
            this.btnHistogram.TabIndex = 1;
            this.btnHistogram.Text = "Histogram";
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(330, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 26);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraph.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraph.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGraph.Location = new System.Drawing.Point(516, 8);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(88, 26);
            this.btnGraph.TabIndex = 2;
            this.btnGraph.Text = "Control Chart";
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // btnRawData
            // 
            this.btnRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRawData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRawData.Location = new System.Drawing.Point(608, 8);
            this.btnRawData.Name = "btnRawData";
            this.btnRawData.Size = new System.Drawing.Size(88, 26);
            this.btnRawData.TabIndex = 3;
            this.btnRawData.Text = "Raw Data";
            this.btnRawData.Click += new System.EventHandler(this.btnRawData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(700, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlChartSet);
            this.pnlCenter.Controls.Add(this.grpChartSet);
            this.pnlCenter.Controls.Add(this.grpLot);
            this.pnlCenter.Controls.Add(this.grpLotID);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(792, 596);
            this.pnlCenter.TabIndex = 0;
            // 
            // pnlChartSet
            // 
            this.pnlChartSet.AutoScroll = true;
            this.pnlChartSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartSet.Location = new System.Drawing.Point(3, 240);
            this.pnlChartSet.Name = "pnlChartSet";
            this.pnlChartSet.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlChartSet.Size = new System.Drawing.Size(786, 356);
            this.pnlChartSet.TabIndex = 3;
            // 
            // grpChartSet
            // 
            this.grpChartSet.Controls.Add(this.cdvUserID);
            this.grpChartSet.Controls.Add(this.lblUserID);
            this.grpChartSet.Controls.Add(this.cdvChartSetID);
            this.grpChartSet.Controls.Add(this.lblChartSetID);
            this.grpChartSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChartSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartSet.Location = new System.Drawing.Point(3, 192);
            this.grpChartSet.Name = "grpChartSet";
            this.grpChartSet.Size = new System.Drawing.Size(786, 48);
            this.grpChartSet.TabIndex = 2;
            this.grpChartSet.TabStop = false;
            // 
            // cdvUserID
            // 
            this.cdvUserID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUserID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUserID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUserID.BtnToolTipText = "";
            this.cdvUserID.DescText = "";
            this.cdvUserID.DisplaySubItemIndex = -1;
            this.cdvUserID.DisplayText = "";
            this.cdvUserID.Focusing = null;
            this.cdvUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUserID.Index = 0;
            this.cdvUserID.IsViewBtnImage = false;
            this.cdvUserID.Location = new System.Drawing.Point(574, 16);
            this.cdvUserID.MaxLength = 20;
            this.cdvUserID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.Name = "cdvUserID";
            this.cdvUserID.ReadOnly = false;
            this.cdvUserID.SearchSubItemIndex = 0;
            this.cdvUserID.SelectedDescIndex = -1;
            this.cdvUserID.SelectedSubItemIndex = -1;
            this.cdvUserID.SelectionStart = 0;
            this.cdvUserID.Size = new System.Drawing.Size(200, 20);
            this.cdvUserID.SmallImageList = null;
            this.cdvUserID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUserID.TabIndex = 3;
            this.cdvUserID.TextBoxToolTipText = "";
            this.cdvUserID.TextBoxWidth = 200;
            this.cdvUserID.VisibleButton = true;
            this.cdvUserID.VisibleColumnHeader = false;
            this.cdvUserID.VisibleDescription = false;
            this.cdvUserID.ButtonPress += new System.EventHandler(this.cdvUserID_ButtonPress);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(464, 19);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(50, 13);
            this.lblUserID.TabIndex = 2;
            this.lblUserID.Text = "User ID";
            this.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvChartSetID
            // 
            this.cdvChartSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChartSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChartSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChartSetID.BtnToolTipText = "";
            this.cdvChartSetID.DescText = "";
            this.cdvChartSetID.DisplaySubItemIndex = -1;
            this.cdvChartSetID.DisplayText = "";
            this.cdvChartSetID.Focusing = null;
            this.cdvChartSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChartSetID.Index = 0;
            this.cdvChartSetID.IsViewBtnImage = false;
            this.cdvChartSetID.Location = new System.Drawing.Point(124, 16);
            this.cdvChartSetID.MaxLength = 30;
            this.cdvChartSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.Name = "cdvChartSetID";
            this.cdvChartSetID.ReadOnly = false;
            this.cdvChartSetID.SearchSubItemIndex = 0;
            this.cdvChartSetID.SelectedDescIndex = -1;
            this.cdvChartSetID.SelectedSubItemIndex = -1;
            this.cdvChartSetID.SelectionStart = 0;
            this.cdvChartSetID.Size = new System.Drawing.Size(200, 20);
            this.cdvChartSetID.SmallImageList = null;
            this.cdvChartSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartSetID.TabIndex = 1;
            this.cdvChartSetID.TextBoxToolTipText = "";
            this.cdvChartSetID.TextBoxWidth = 200;
            this.cdvChartSetID.VisibleButton = true;
            this.cdvChartSetID.VisibleColumnHeader = false;
            this.cdvChartSetID.VisibleDescription = false;
            this.cdvChartSetID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartSetID_SelectedItemChanged);
            this.cdvChartSetID.ButtonPress += new System.EventHandler(this.cdvChartSetID_ButtonPress);
            this.cdvChartSetID.TextBoxTextChanged += new System.EventHandler(this.cdvChartSetID_TextBoxTextChanged);
            // 
            // lblChartSetID
            // 
            this.lblChartSetID.AutoSize = true;
            this.lblChartSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartSetID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartSetID.Location = new System.Drawing.Point(15, 19);
            this.lblChartSetID.Name = "lblChartSetID";
            this.lblChartSetID.Size = new System.Drawing.Size(77, 13);
            this.lblChartSetID.TabIndex = 0;
            this.lblChartSetID.Text = "Chart Set ID";
            // 
            // grpLot
            // 
            this.grpLot.Controls.Add(this.cdvFlow);
            this.grpLot.Controls.Add(this.cdvMaterial);
            this.grpLot.Controls.Add(this.chkSelectMFO);
            this.grpLot.Controls.Add(this.cdvProcResID);
            this.grpLot.Controls.Add(this.lblProcResID);
            this.grpLot.Controls.Add(this.cdvProcOper);
            this.grpLot.Controls.Add(this.lblProcOper);
            this.grpLot.Controls.Add(this.cdvOper);
            this.grpLot.Controls.Add(this.cdvResID);
            this.grpLot.Controls.Add(this.lblResID);
            this.grpLot.Controls.Add(this.lblOper);
            this.grpLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLot.Location = new System.Drawing.Point(3, 73);
            this.grpLot.Name = "grpLot";
            this.grpLot.Size = new System.Drawing.Size(786, 119);
            this.grpLot.TabIndex = 1;
            this.grpLot.TabStop = false;
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 113;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = ' ';
            this.cdvFlow.Location = new System.Drawing.Point(461, 40);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(312, 20);
            this.cdvFlow.TabIndex = 2;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 199;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_FlowSelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_FlowButtonPress);
            this.cdvFlow.FlowTextChanged += new System.EventHandler(this.cdvFlow_FlowTextChanged);
            this.cdvFlow.SeqButtonPress += new System.EventHandler(this.cdvFlow_SeqButtonPress);
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.DisplaySubItemIndex = -1;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(14, 40);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = true;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = -1;
            this.cdvMaterial.Size = new System.Drawing.Size(310, 20);
            this.cdvMaterial.TabIndex = 1;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = true;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = false;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 110;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // chkSelectMFO
            // 
            this.chkSelectMFO.AutoSize = true;
            this.chkSelectMFO.Location = new System.Drawing.Point(15, 18);
            this.chkSelectMFO.Name = "chkSelectMFO";
            this.chkSelectMFO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSelectMFO.Size = new System.Drawing.Size(100, 17);
            this.chkSelectMFO.TabIndex = 0;
            this.chkSelectMFO.Text = "Select Lot MFO";
            this.chkSelectMFO.CheckedChanged += new System.EventHandler(this.chkSelectMFO_CheckedChanged);
            // 
            // cdvProcResID
            // 
            this.cdvProcResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcResID.BtnToolTipText = "";
            this.cdvProcResID.DescText = "";
            this.cdvProcResID.DisplaySubItemIndex = -1;
            this.cdvProcResID.DisplayText = "";
            this.cdvProcResID.Focusing = null;
            this.cdvProcResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcResID.Index = 0;
            this.cdvProcResID.IsViewBtnImage = false;
            this.cdvProcResID.Location = new System.Drawing.Point(574, 88);
            this.cdvProcResID.MaxLength = 20;
            this.cdvProcResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvProcResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvProcResID.Name = "cdvProcResID";
            this.cdvProcResID.ReadOnly = false;
            this.cdvProcResID.SearchSubItemIndex = 0;
            this.cdvProcResID.SelectedDescIndex = -1;
            this.cdvProcResID.SelectedSubItemIndex = -1;
            this.cdvProcResID.SelectionStart = 0;
            this.cdvProcResID.Size = new System.Drawing.Size(200, 20);
            this.cdvProcResID.SmallImageList = null;
            this.cdvProcResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcResID.TabIndex = 10;
            this.cdvProcResID.TextBoxToolTipText = "";
            this.cdvProcResID.TextBoxWidth = 200;
            this.cdvProcResID.VisibleButton = true;
            this.cdvProcResID.VisibleColumnHeader = false;
            this.cdvProcResID.VisibleDescription = false;
            this.cdvProcResID.ButtonPress += new System.EventHandler(this.cdvProcResID_ButtonPress);
            // 
            // lblProcResID
            // 
            this.lblProcResID.AutoSize = true;
            this.lblProcResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcResID.Location = new System.Drawing.Point(464, 92);
            this.lblProcResID.Name = "lblProcResID";
            this.lblProcResID.Size = new System.Drawing.Size(108, 13);
            this.lblProcResID.TabIndex = 9;
            this.lblProcResID.Text = "Process Resource ID";
            this.lblProcResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvProcOper
            // 
            this.cdvProcOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcOper.BtnToolTipText = "";
            this.cdvProcOper.DescText = "";
            this.cdvProcOper.DisplaySubItemIndex = -1;
            this.cdvProcOper.DisplayText = "";
            this.cdvProcOper.Focusing = null;
            this.cdvProcOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcOper.Index = 0;
            this.cdvProcOper.IsViewBtnImage = false;
            this.cdvProcOper.Location = new System.Drawing.Point(574, 64);
            this.cdvProcOper.MaxLength = 10;
            this.cdvProcOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvProcOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvProcOper.Name = "cdvProcOper";
            this.cdvProcOper.ReadOnly = false;
            this.cdvProcOper.SearchSubItemIndex = 0;
            this.cdvProcOper.SelectedDescIndex = -1;
            this.cdvProcOper.SelectedSubItemIndex = -1;
            this.cdvProcOper.SelectionStart = 0;
            this.cdvProcOper.Size = new System.Drawing.Size(200, 20);
            this.cdvProcOper.SmallImageList = null;
            this.cdvProcOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcOper.TabIndex = 6;
            this.cdvProcOper.TextBoxToolTipText = "";
            this.cdvProcOper.TextBoxWidth = 200;
            this.cdvProcOper.VisibleButton = true;
            this.cdvProcOper.VisibleColumnHeader = false;
            this.cdvProcOper.VisibleDescription = false;
            this.cdvProcOper.ButtonPress += new System.EventHandler(this.cdvProcOper_ButtonPress);
            // 
            // lblProcOper
            // 
            this.lblProcOper.AutoSize = true;
            this.lblProcOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcOper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcOper.Location = new System.Drawing.Point(464, 68);
            this.lblProcOper.Name = "lblProcOper";
            this.lblProcOper.Size = new System.Drawing.Size(94, 13);
            this.lblProcOper.TabIndex = 5;
            this.lblProcOper.Text = "Process Operation";
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
            this.cdvOper.Location = new System.Drawing.Point(124, 64);
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
            this.cdvOper.TabIndex = 4;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 200;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            this.cdvOper.TextBoxTextChanged += new System.EventHandler(this.cdvOper_TextBoxTextChanged);
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
            this.cdvResID.Location = new System.Drawing.Point(124, 88);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 8;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
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
            this.lblResID.Location = new System.Drawing.Point(15, 92);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 7;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Location = new System.Drawing.Point(15, 68);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 3;
            this.lblOper.Text = "Operation";
            // 
            // grpLotID
            // 
            this.grpLotID.Controls.Add(this.txtLot);
            this.grpLotID.Controls.Add(this.pnlTranTime);
            this.grpLotID.Controls.Add(this.txtDesc);
            this.grpLotID.Controls.Add(this.lblLotDesc);
            this.grpLotID.Controls.Add(this.lblLotID);
            this.grpLotID.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotID.Location = new System.Drawing.Point(3, 0);
            this.grpLotID.Name = "grpLotID";
            this.grpLotID.Size = new System.Drawing.Size(786, 73);
            this.grpLotID.TabIndex = 0;
            this.grpLotID.TabStop = false;
            // 
            // txtLot
            // 
            this.txtLot.Location = new System.Drawing.Point(124, 16);
            this.txtLot.MaxLength = 25;
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(200, 20);
            this.txtLot.TabIndex = 1;
            this.txtLot.TextChanged += new System.EventHandler(this.txtLot_TextChanged);
            this.txtLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLot_KeyPress);
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranTime.Controls.Add(this.txtTranTime);
            this.pnlTranTime.Controls.Add(this.udtTranTime);
            this.pnlTranTime.Controls.Add(this.uccTranDate);
            this.pnlTranTime.Controls.Add(this.chkTranDateTime);
            this.pnlTranTime.Location = new System.Drawing.Point(478, 15);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 23);
            this.pnlTranTime.TabIndex = 1;
            // 
            // txtTranTime
            // 
            this.txtTranTime.Location = new System.Drawing.Point(128, 1);
            this.txtTranTime.MaxLength = 30;
            this.txtTranTime.Name = "txtTranTime";
            this.txtTranTime.ReadOnly = true;
            this.txtTranTime.Size = new System.Drawing.Size(168, 20);
            this.txtTranTime.TabIndex = 2;
            // 
            // udtTranTime
            // 
            this.udtTranTime.DateTime = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            this.udtTranTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtTranTime.FormatString = "";
            this.udtTranTime.Location = new System.Drawing.Point(220, 1);
            this.udtTranTime.MaskInput = "hh:mm:ss";
            this.udtTranTime.Name = "udtTranTime";
            this.udtTranTime.Size = new System.Drawing.Size(72, 21);
            this.udtTranTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtTranTime.SpinWrap = true;
            this.udtTranTime.TabIndex = 2;
            this.udtTranTime.Value = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            // 
            // uccTranDate
            // 
            this.uccTranDate.DateButtons.Add(dateButton1);
            this.uccTranDate.Location = new System.Drawing.Point(128, 1);
            this.uccTranDate.Name = "uccTranDate";
            this.uccTranDate.NonAutoSizeHeight = 21;
            this.uccTranDate.Size = new System.Drawing.Size(88, 21);
            this.uccTranDate.TabIndex = 3;
            this.uccTranDate.Value = new System.DateTime(2005, 5, 9, 0, 0, 0, 0);
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(3, 3);
            this.chkTranDateTime.Name = "chkTranDateTime";
            this.chkTranDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTranDateTime.Size = new System.Drawing.Size(109, 17);
            this.chkTranDateTime.TabIndex = 1;
            this.chkTranDateTime.Text = "Transaction Time";
            this.chkTranDateTime.CheckedChanged += new System.EventHandler(this.chkTranDateTime_CheckedChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(124, 41);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(650, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotDesc.Location = new System.Drawing.Point(15, 44);
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
            // frmSPCTranCollectLotDatabyChartSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 636);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 670);
            this.Name = "frmSPCTranCollectLotDatabyChartSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Collect Lot Data by Chart Set (Type 2)";
            this.Activated += new System.EventHandler(this.frmSPCTranCollectLotDatabyChartSet_Activated);
            this.Load += new System.EventHandler(this.frmSPCTranCollectLotDatabyChartSet_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.grpChartSet.ResumeLayout(false);
            this.grpChartSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).EndInit();
            this.grpLot.ResumeLayout(false);
            this.grpLot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectMFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.grpLotID.ResumeLayout(false);
            this.grpLotID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLot)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTranTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTranTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTranDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTranDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition"
        private const int UNIT_COL = 1;
        private const int NOMINAL_COL = 2;
        private const int PROCSIGMA_COL = 3;
        private const int VALUE_1_COL = 4;
        private const int WEIGHT_COL = 1004;
        private const int AVERAGE_COL = 1005;
        private const int SIGMA_COL = 1006;
        private const int RANGE_COL = 1007;
        private const int MAX_COL = 1008;
        private const int MIN_COL = 1009;
        #endregion
        
        #region " Variable Definition"
        private bool b_load_flag = false;
        //Private giGroupIndex As Integer = -1
        //Private giLotIndex As Integer = -1
        #endregion
        
        #region " Function Implementations"
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef ctrlChartInfo As udcChartInfo
        //
        private bool CheckCondition(udcChartInfo ctrlChartInfo)
        {
            
            try
            {
                if (txtLot.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtLot.Focus();
                    return false;
                }
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMaterial.MaterialFocus();
                    return false;
                }
                if (cdvFlow.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvFlow.Focus();
                    return false;
                }
                if (cdvOper.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvOper.Focus();
                    return false;
                }
                if (ctrlChartInfo.ChartID == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108) + "CHART_ID");
                    return false;
                }
                if (MPCF.CheckValue(cdvUserID, 1) == false)
                {
                    return false;
                }
                
                if (ctrlChartInfo.CheckCondition() == false)
                {
                    return false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Lot()
        //       - View Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Lot()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Lot_In");
                TRSNode out_node = new TRSNode("View_Lot_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLot.Text);

                if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDesc.Text = out_node.GetString("LOT_DESC");
                cdvMaterial.Text = out_node.GetString("MAT_ID");
                cdvMaterial.Version = out_node.GetInt("MAT_VER");
                cdvFlow.Text = out_node.GetString("FLOW");
                cdvFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
                cdvOper.Text = out_node.GetString("OPER");
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.View_Lot()\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetChartControl()
        //       - Set Chart Control
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SetChartControl()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Attach_Chart_Set_List_In");
                TRSNode out_node;
                int i;

                ArrayList a_list = new ArrayList();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("CHART_SET_ID", MPCF.Trim(cdvChartSetID.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
                in_node.AddString("NEXT_CHART_ID", "");
                
                do
                {
                    out_node = new TRSNode("View_Attach_Chart_Set_List_Out");
                    if (MPCR.CallService("SPC", "SPC_View_Attach_Chart_Set_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));

                } while (in_node.GetString("NEXT_CHART_ID") != "");
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        Panel pnlChart = new Panel();
                        udcChartInfo ctrlChartInfo = new udcChartInfo();
                        ctrlChartInfo.ChartID = out_node.GetList(0)[i].GetString("CHART_ID");
                        ctrlChartInfo.Dock = DockStyle.Fill;
                        pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                        pnlChart.Controls.Add(ctrlChartInfo);
                        pnlChart.Dock = DockStyle.Top;
                        pnlChart.Height = 256;
                        pnlChartSet.Controls.Add(pnlChart);
                        ctrlChartInfo.ViewChartInfo(false);
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.SetChartControl()\n" + ex.Message);
                return false;
            }
            
        }
        
        // Collect_EDC_Data_by_ChartSet()
        //       - Collect EDC Data
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String
        //
        private bool Collect_EDC_Data_by_ChartSet(char c_step)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("Collect_ChartSet_Data_In");
                TRSNode out_node = new TRSNode("Collect_ChartSet_Data_Out");
                
                int i;
                int j;
                int k;
                int m;
                //object iValueCount;
                //object iChartCount;
                int iValueCount;
                int iChartCount;
                Control ctrlPanel;
                Control ctrludcChartInfo;
                udcChartInfo ctrlChartInfo;
                TRSNode list, unit_item;
                TRSNode oos_array;

                MPCR.SetInMsg(in_node);
                in_node.UserID = MPCF.Trim(cdvUserID.Text);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddChar("SUB_STEP", c_step);
                
                in_node.AddChar("LOT_RES_FLAG", 'L');
                in_node.AddString("LOT_ID", MPCF.Trim(txtLot.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddInt("FLOW_SEQ_NUM", cdvFlow.Sequence);
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
                in_node.AddString("PROC_OPER", MPCF.Trim(cdvProcOper.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("PROC_RES_ID", MPCF.Trim(cdvProcResID.Text));
                in_node.AddChar("SELECT_MFO_FLAG", (chkSelectMFO.Checked ? 'Y' : ' '));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("TRAN_TIME", ((DateTime)uccTranDate.Value).ToString("yyyyMMdd") + ((DateTime)udtTranTime.Value).ToString("HHmmss"));
                }
                
                iChartCount = 0;
                foreach (Control tempLoopVar_ctrlPanel in pnlChartSet.Controls)
                {
                    ctrlPanel = tempLoopVar_ctrlPanel;
                    if (ctrlPanel is Panel)
                    {
                        foreach (Control tempLoopVar_ctrludcChartInfo in ctrlPanel.Controls)
                        {
                            ctrludcChartInfo = tempLoopVar_ctrludcChartInfo;
                            if (ctrludcChartInfo is udcChartInfo)
                            {
                                iChartCount += ((udcChartInfo) ctrludcChartInfo).GetSpreadData.Sheets[0].RowCount;
                            }
                        }
                    }
                }
                i = 0;
                foreach (Control tempLoopVar_ctrlPanel in pnlChartSet.Controls)
                {
                    ctrlPanel = tempLoopVar_ctrlPanel;
                    if (ctrlPanel is Panel)
                    {
                        foreach (Control tempLoopVar_ctrludcChartInfo in ctrlPanel.Controls)
                        {
                            ctrludcChartInfo = tempLoopVar_ctrludcChartInfo;
                            if (ctrludcChartInfo is udcChartInfo)
                            {
                                list = in_node.AddNode("CHART_LIST");
                                                                
                                list.AddString("CHART_ID", ((udcChartInfo) ctrludcChartInfo).ChartID);
                                list.AddInt("UNIT_COUNT",((udcChartInfo) ctrludcChartInfo).UnitCount);
                                list.AddInt("SAMPLE_SIZE", ((udcChartInfo) ctrludcChartInfo).SampleSize);
                                list.AddString("GRAPH_TYPE",MPCF.Trim(Enum.GetName(typeof(eGraphType), ((udcChartInfo) ctrludcChartInfo).GraphTypeIndex)));
                                list.AddChar("UNIT_USE_FLAG", ((udcChartInfo) ctrludcChartInfo).UseUnit);
                                list.AddString("EDC_COMMENT", ((udcChartInfo) ctrludcChartInfo).Comment);
                                FarPoint.Win.Spread.SheetView with_1 = ((udcChartInfo) ctrludcChartInfo).GetSpreadData.Sheets[0];
                                for (m = 0; m <= (with_1.RowCount - 1); m++)
                                {
                                    unit_item = list.AddNode("UNIT_LIST");
                                    iValueCount = 0;
                                    for (j = VALUE_1_COL; j <= (with_1.ColumnCount - 7); j++)
                                    {
                                        if (MPCF.Trim(with_1.GetValue(m, j)) != "" && with_1.Columns[j].Visible == true)
                                        {
                                            iValueCount++;
                                        }
                                    }
                                    if (with_1.Columns[NOMINAL_COL].Visible == true)
                                    {
                                        unit_item.AddString("NOMINAL", MPCF.Trim(with_1.GetValue(0, NOMINAL_COL)));
                                    }
                                    if (with_1.Columns[PROCSIGMA_COL].Visible == true)
                                    {
                                        unit_item.AddString("PROCESS_SIGMA", MPCF.Trim(with_1.GetValue(0, PROCSIGMA_COL)));
                                    }
                                    unit_item.AddString("UNIT_ID", MPCF.Trim(with_1.GetValue(m, UNIT_COL)));
                                    unit_item.AddInt("VALUE_COUNT", iValueCount);
                                    unit_item.AddInt("UNIT_SEQ", m + 1);
                                                                        
                                    for (k = 0; k <= iValueCount - 1; k++)
                                    {
                                        if (with_1.Columns[k + VALUE_1_COL].Visible == true)
                                        {
                                            TRSNode value_item = unit_item.AddNode("VALUE_LIST");
                                            value_item.AddString("VALUE", MPCF.Trim(with_1.GetValue(m, k + VALUE_1_COL)));
                                        }
                                    }
                                    i++;
                                }
                                
                            }
                        }
                    }
                }

                if (MessageCaster.CallService("SPC", "SPC_Collect_ChartSet_Data", in_node, ref out_node) == false)
                {
                    MPCF.ShowMsgBox(MPMH.StatusMessage);
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    MPCR.CheckContinueProc(out_node);
                    return false;
                }

                i = 0;
                while (i < out_node.GetList(0).Count)
                {
                    TRSNode chart_item_in = in_node.GetList("CHART_LIST")[i];
                    TRSNode chart_item_out = out_node.GetList("CHART_LIST")[i];
                    ctrlChartInfo = GetChartInfoControl(chart_item_out.GetString("CHART_ID"));
                    if (ctrlChartInfo == null)
                    {
                        return false;
                    }
                    FarPoint.Win.Spread.SheetView with_2 = ctrlChartInfo.GetSpreadData.Sheets[0];
                    
                    if (ctrlChartInfo.UseUnit == 'Y')
                    {
                        for (j = 0; j < chart_item_out.GetList("UNIT_LIST").Count; j++)
                        {
                            with_2.Cells[chart_item_in.GetList(0)[j].GetInt("UNIT_SEQ") - 1, WEIGHT_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("WEIGHT_VALUE"), MPCF.ToInt(ctrlChartInfo.Precision));
                            with_2.Cells[chart_item_in.GetList(0)[j].GetInt("UNIT_SEQ") - 1, AVERAGE_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("AVERAGE"), MPCF.ToInt(ctrlChartInfo.Precision));
                            with_2.Cells[chart_item_in.GetList(0)[j].GetInt("UNIT_SEQ") - 1, SIGMA_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("STDDEV"), MPCF.ToInt(ctrlChartInfo.Precision));
                            with_2.Cells[chart_item_in.GetList(0)[j].GetInt("UNIT_SEQ") - 1, RANGE_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("RANGE"), MPCF.ToInt(ctrlChartInfo.Precision));
                            with_2.Cells[chart_item_in.GetList(0)[j].GetInt("UNIT_SEQ") - 1, MAX_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("MAX_VALUE"), MPCF.ToInt(ctrlChartInfo.Precision));
                            with_2.Cells[chart_item_in.GetList(0)[j].GetInt("UNIT_SEQ") - 1, MIN_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("MIN_VALUE"), MPCF.ToInt(ctrlChartInfo.Precision));
                            if (chart_item_out.GetList(0)[ j].GetChar("R_CHECK_RESULT") == ' ' && chart_item_out.GetList(0)[j].GetChar("X_CHECK_RESULT") == ' ')
                            {
                                with_2.Cells[chart_item_in.GetList(0)[j].GetInt("UNIT_SEQ") - 1, 0].Value = "OK";
                            }
                            else
                            {
                                with_2.Cells[chart_item_in.GetList(0)[j].GetInt("UNIT_SEQ") - 1, 0].Value = "FAIL";
                            }
                            
                            if (chart_item_out.GetList(0)[j].GetChar("X_CHECK_RESULT") == 'A')
                            {
                                oos_array = chart_item_out.GetList("OOS_LIST")[j].GetArray("OOS_CHECK_RESULT");
                                if (ctrlChartInfo.ChartGraphType == eGraphType.XBARR.ToString() || ctrlChartInfo.ChartGraphType == eGraphType.XBARS.ToString() || ctrlChartInfo.ChartGraphType == eGraphType.XRS.ToString())
                                {
                                    for (k = 0; k <= ctrlChartInfo.SampleSize - 1; k++)
                                    {
                                        if (oos_array.GetChar(k.ToString()) == 'Y')
                                        {
                                            with_2.Cells[chart_item_in.GetList(0)[j].GetInt("UNIT_SEQ") - 1, VALUE_1_COL + k].BackColor = Color.Red;
                                        }
                                    }
                                }
                                else if (ctrlChartInfo.ChartGraphType == eGraphType.P.ToString() || 
                                         ctrlChartInfo.ChartGraphType == eGraphType.U.ToString())
                                {
                                    if (oos_array.GetChar("0") == 'Y')
                                    {
                                        with_2.Cells[0, AVERAGE_COL].BackColor = Color.Red;
                                    }
                                }
                                else if (ctrlChartInfo.ChartGraphType == eGraphType.ZBARS.ToString() || 
                                         ctrlChartInfo.ChartGraphType == eGraphType.DELTAS.ToString())
                                {
                                    with_2.Cells[0, WEIGHT_COL].BackColor = Color.Red;
                                }
                                else
                                {
                                    if (oos_array.GetChar("0") == 'Y')
                                    {
                                        with_2.Cells[0, VALUE_1_COL].BackColor = Color.Red;
                                    }
                                }
                            }
                            else if (chart_item_out.GetList(0)[j].GetChar("X_CHECK_RESULT") == 'B' && ctrlChartInfo.SpecCheckType == "V")
                            {
                                oos_array = chart_item_out.GetList("OOS_LIST")[j].GetArray("OOS_CHECK_RESULT");
                                if (ctrlChartInfo.ChartGraphType == eGraphType.XBARR.ToString() || 
                                    ctrlChartInfo.ChartGraphType == eGraphType.XBARS.ToString() || 
                                    ctrlChartInfo.ChartGraphType == eGraphType.XRS.ToString())
                                {
                                    for (k = 0; k <= ctrlChartInfo.SampleSize - 1; k++)
                                    {
                                        if (oos_array.GetChar(k.ToString()) == 'Y')
                                        {
                                            with_2.Cells[in_node.GetList(0)[i + j].GetInt("UNIT_SEQ") - 1, VALUE_1_COL + k].BackColor = Color.Yellow;
                                        }
                                    }
                                }
                                
                            }
                        }
                    }
                    else
                    {
                        with_2.Cells[0, WEIGHT_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[0].GetString("WEIGHT_VALUE"), MPCF.ToInt(ctrlChartInfo.Precision));
                        with_2.Cells[0, WEIGHT_COL].RowSpan = with_2.RowCount;
                        with_2.Cells[0, AVERAGE_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[0].GetString("AVERAGE"), MPCF.ToInt(ctrlChartInfo.Precision));
                        with_2.Cells[0, AVERAGE_COL].RowSpan = with_2.RowCount;
                        with_2.Cells[0, SIGMA_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[0].GetString("STDDEV"), MPCF.ToInt(ctrlChartInfo.Precision));
                        with_2.Cells[0, SIGMA_COL].RowSpan = with_2.RowCount;
                        with_2.Cells[0, RANGE_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[0].GetString("RANGE"), MPCF.ToInt(ctrlChartInfo.Precision));
                        with_2.Cells[0, RANGE_COL].RowSpan = with_2.RowCount;
                        with_2.Cells[0, MAX_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[0].GetString("MAX_VALUE"), MPCF.ToInt(ctrlChartInfo.Precision));
                        with_2.Cells[0, MAX_COL].RowSpan = with_2.RowCount;
                        with_2.Cells[0, MIN_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[0].GetString("MIN_VALUE"), MPCF.ToInt(ctrlChartInfo.Precision));
                        with_2.Cells[0, MIN_COL].RowSpan = with_2.RowCount;
                        if (out_node.StatusValue == MPGC.MP_SUCCESS_STATUS)
                        {
                            with_2.Cells[0, 0].Value = "OK";
                        }
                        else
                        {
                            with_2.Cells[0, 0].Value = "FAIL";
                        }
                        with_2.Cells[0, 0].RowSpan = with_2.RowCount;
                        if (chart_item_out.GetList(0)[0].GetChar("X_CHECK_RESULT") == 'A')
                        {
                            
                            if (ctrlChartInfo.ChartGraphType == eGraphType.ZBARS.ToString() || ctrlChartInfo.ChartGraphType == eGraphType.DELTAS.ToString())
                            {
                                with_2.Cells[0, WEIGHT_COL].BackColor = Color.Red;
                            }
                            else
                            {
                                for (j = 0; j <= with_2.RowCount - 1; j++)
                                {
                                    oos_array = chart_item_out.GetList("OOS_LIST")[j].GetArray("OOS_CHECK_RESULT");
                                    for (k = 0; k <= ctrlChartInfo.SampleSize - 1; k++)
                                    {
                                        if (oos_array.GetChar(k.ToString()) == 'Y')
                                        {
                                            with_2.Cells[j, VALUE_1_COL + k].BackColor = Color.Red;
                                        }
                                    }
                                }
                            }
                        }
                        else if (chart_item_out.GetList(0)[0].GetChar("X_CHECK_RESULT") == 'B' && ctrlChartInfo.SpecCheckType == "V")
                        {
                            for (j = 0; j <= with_2.RowCount - 1; j++)
                            {
                                oos_array = chart_item_out.GetList("OOS_LIST")[j].GetArray("OOS_CHECK_RESULT");
                                for (k = 0; k <= ctrlChartInfo.SampleSize - 1; k++)
                                {
                                    if (oos_array.GetChar(k.ToString()) == 'Y')
                                    {
                                        with_2.Cells[j, VALUE_1_COL + k].BackColor = Color.Yellow;
                                    }
                                }
                            }
                        }
                    }
                    i++;
                }
                
                if (c_step == MPGC.MP_STEP_TRAN && out_node.StatusValue == MPGC.MP_TRBL_STATUS)
                {
                    Result_Management(out_node);
                }
                else if (c_step == MPGC.MP_STEP_TRAN && out_node.StatusValue== MPGC.MP_SUCCESS_STATUS)
                {
                    MPCR.ShowSuccessMsg(out_node);
                    btnOK.Enabled = false;
                    SetLockSpread(true);
                }
               
                
                return true;
                
            }
                catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.CollectEDCData()\n" + ex.Message);
                return false;
            }
            
        }
        
        // GetChartInfoControl()
        //       - Get udcChartInfo Control
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sChartID As String
        //
        private udcChartInfo GetChartInfoControl(string sChartID)
        {
            
            try
            {
                Control ctrlPanel;
                Control ctrludcChartInfo;
                
                foreach (Control tempLoopVar_ctrlPanel in pnlChartSet.Controls)
                {
                    ctrlPanel = tempLoopVar_ctrlPanel;
                    if (ctrlPanel is Panel)
                    {
                        foreach (Control tempLoopVar_ctrludcChartInfo in ctrlPanel.Controls)
                        {
                            ctrludcChartInfo = tempLoopVar_ctrludcChartInfo;
                            if (ctrludcChartInfo is udcChartInfo)
                            {
                                if (((udcChartInfo)ctrludcChartInfo).ChartID == MPCF.Trim(sChartID))
                                {
                                    return ((udcChartInfo) ctrludcChartInfo);
                                }
                            }
                        }
                    }
                }
                
                return null;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.GetChartInfoControl()\n" + ex.Message);
                return null;
            }
            
        }
        
        // Result_Management()
        //       - Manage result of data collection
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal Collect_EDC_Data_Out As SPC_Collect_EDC_Data_Out_Tag
        //
        private void Result_Management(TRSNode out_node)
        {
            
            try
            {
                if (out_node.StatusValue == MPGC.MP_TRBL_STATUS)
                {
                    frmSPCSubCollectData f = new frmSPCSubCollectData();
                    frmSPCTranOOCHistory f1 = new frmSPCTranOOCHistory();
                    f.spdResult.Sheets[0].Columns[1].Visible = true;

                    View_Result(f.spdResult, out_node, "1");
                    f.ShowDialog(this);
                    
                    //Pending
                    if (f.DialogResult == System.Windows.Forms.DialogResult.Ignore)
                    {
                        //Data Commit
                        //OOC History Insert
                        if (Collect_EDC_Data_by_ChartSet(modSPCConstants.MP_STEP_PEND) == false)
                        {
                            return;
                        }
                        btnOK.Enabled = false;
                        SetLockSpread(true);
                        MPCR.ShowSuccessMsg(out_node);
                        
                        //Continue
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        //f.Dispose()
                        if (Collect_EDC_Data_by_ChartSet(modSPCConstants.MP_STEP_CONT) == false)
                        {
                            return;
                        }
                        f1.spdResult.Sheets[0].Columns[1].Visible = true;
                        View_Result(f1.spdResult, out_node, "2");
                        f1.pnlTop.Visible = false;
                        f1.pnlResult.Height = 214;
                        f1.ShowDialog(this);
                        btnOK.Enabled = false;
                        SetLockSpread(true);
                        
                        //Data Change
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        f.Dispose();
                        
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        f.Dispose();
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.Result_Management()\n" + ex.Message);
                
            }
            
        }
        
        // View_Result()
        //       - View Result of Data Collection
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef spdResult As FpSpread - ê²°ê³¼ ?œì‹œ ?¤í”„?ˆë“œ
        //       - ByVal Result_Out As SPC_Collect_EDC_Data_Out_Tag : Data Collection Out ?œê·¸
        //       - ByVal c_step As String
        //
        public void View_Result(FarPoint.Win.Spread.FpSpread spdResult, TRSNode out_node, string c_step)
        {
            
            try
            {
                int i;
                int j;
                udcChartInfo ctrlChartInfo;
                MPCF.ClearList(spdResult, true);
                j = 0;
                while (j < out_node.GetList(0).Count)
                {
                    TRSNode chart_item = out_node.GetList("CHART_LIST")[j];
                    ctrlChartInfo = GetChartInfoControl(chart_item.GetString("CHART_ID"));
                    if (ctrlChartInfo == null)
                    {
                        return;
                    }
                    FarPoint.Win.Spread.SheetView with_1 = spdResult.Sheets[0];
                    if (ctrlChartInfo.UseUnit != 'Y')
                    {
                        if (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT") != ' ' && chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT") != ' ')
                        {
                            with_1.RowCount += 2;
                            with_1.Cells[with_1.RowCount - 2, 0].Value = 1;
                            with_1.Cells[with_1.RowCount - 1, 0].Value = 1;
                            with_1.Cells[with_1.RowCount - 2, 0].RowSpan = 2;
                            with_1.Cells[with_1.RowCount - 2, 1].Value = ctrlChartInfo.ChartID;
                            with_1.Cells[with_1.RowCount - 1, 1].Value = ctrlChartInfo.ChartID;
                            with_1.Cells[with_1.RowCount - 2, 2].Value = ctrlChartInfo.GetSpreadData.Sheets[0].Cells[0, 1].Value;
                            with_1.Cells[with_1.RowCount - 2, 2].RowSpan = 2;
                            with_1.Cells[with_1.RowCount - 2, 3].Value = "X";
                            with_1.Cells[with_1.RowCount - 1, 3].Value = "R";
                            with_1.Cells[with_1.RowCount - 2, 4].Value = chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT");
                            with_1.Cells[with_1.RowCount - 1, 4].Value = chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT");
                            with_1.Cells[with_1.RowCount - 2, 5].Value = MPCF.SetRuleDescription(chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT"), out_node, 'X');
                            with_1.Cells[with_1.RowCount - 1, 5].Value = MPCF.SetRuleDescription(chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT"), out_node, 'R');
                            if (c_step == "2")
                            {
                                with_1.Cells[0, 6].RowSpan = 2;
                                with_1.Cells[with_1.RowCount - 2, 7].Value = chart_item.GetInt("HIST_SEQ");
                                with_1.Cells[with_1.RowCount - 1, 7].Value = chart_item.GetInt("HIST_SEQ");
                                with_1.Cells[with_1.RowCount - 2, 8].Value = chart_item.GetString("TRAN_TIME");
                                with_1.Cells[with_1.RowCount - 1, 8].Value = chart_item.GetString("TRAN_TIME");
                            }
                        }
                        else if (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ' && chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT") == ' ')
                        {
                        }
                        else
                        {
                            with_1.RowCount++;
                            with_1.Cells[with_1.RowCount - 1, 0].Value = 1;
                            with_1.Cells[with_1.RowCount - 1, 1].Value = ctrlChartInfo.ChartID;
                            with_1.Cells[with_1.RowCount - 1, 2].Value = ctrlChartInfo.GetSpreadData.Sheets[0].Cells[0, 1].Value;
                            with_1.Cells[with_1.RowCount - 1, 3].Value = (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ') ? "X" : "R";
                            with_1.Cells[with_1.RowCount - 1, 4].Value = (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ') ? (chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT")) : (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT"));
                            with_1.Cells[with_1.RowCount - 1, 5].Value = (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ') ? (MPCF.SetRuleDescription(chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT"), out_node, 'X')) : (MPCF.SetRuleDescription(chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT"), out_node, 'R'));
                            if (c_step == "2")
                            {
                                with_1.Cells[with_1.RowCount - 1, 7].Value = chart_item.GetInt("HIST_SEQ");
                                with_1.Cells[with_1.RowCount - 1, 8].Value = chart_item.GetString("TRAN_TIME");
                            }
                        }
                        j++;
                    }
                    else
                    {
                        for (i = 0; i <= chart_item.GetList("UNIT_LIST").Count - 1; i++)
                        {
                            if (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT") != ' ' && chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT") != ' ')
                            {
                                with_1.RowCount += 2;
                                with_1.Cells[with_1.RowCount - 2, 0].Value = i + 1;
                                with_1.Cells[with_1.RowCount - 1, 0].Value = i + 1;
                                with_1.Cells[with_1.RowCount - 2, 0].RowSpan = 2;
                                with_1.Cells[with_1.RowCount - 2, 1].Value = ctrlChartInfo.ChartID;
                                with_1.Cells[with_1.RowCount - 1, 1].Value = ctrlChartInfo.ChartID;
                                with_1.Cells[with_1.RowCount - 2, 2].Value = ctrlChartInfo.GetSpreadData.Sheets[0].Cells[i, 1].Value;
                                with_1.Cells[with_1.RowCount - 2, 2].RowSpan = 2;
                                with_1.Cells[with_1.RowCount - 2, 3].Value = "X";
                                with_1.Cells[with_1.RowCount - 1, 3].Value = "R";
                                with_1.Cells[with_1.RowCount - 2, 4].Value = chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT");
                                with_1.Cells[with_1.RowCount - 1, 4].Value = chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT");
                                with_1.Cells[with_1.RowCount - 2, 5].Value = MPCF.SetRuleDescription(chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT"), out_node, 'X');
                                with_1.Cells[with_1.RowCount - 1, 5].Value = MPCF.SetRuleDescription(chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT"), out_node, 'R');
                                if (c_step == "2")
                                {
                                    with_1.Cells[with_1.RowCount - 2, 6].RowSpan = 2;
                                    with_1.Cells[with_1.RowCount - 2, 7].Value = chart_item.GetInt("HIST_SEQ");
                                    with_1.Cells[with_1.RowCount - 1, 7].Value = chart_item.GetInt("HIST_SEQ");
                                    with_1.Cells[with_1.RowCount - 2, 8].Value = chart_item.GetString("TRAN_TIME");
                                    with_1.Cells[with_1.RowCount - 1, 8].Value = chart_item.GetString("TRAN_TIME");
                                }
                            }
                            else if (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ' && chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT") == ' ')
                            {
                            }
                            else
                            {
                                with_1.RowCount++;
                                with_1.Cells[with_1.RowCount - 1, 0].Value = i + 1;
                                with_1.Cells[with_1.RowCount - 1, 1].Value = ctrlChartInfo.ChartID;
                                with_1.Cells[with_1.RowCount - 1, 2].Value = ctrlChartInfo.GetSpreadData.Sheets[0].Cells[i, 1].Value;
                                with_1.Cells[with_1.RowCount - 1, 3].Value = (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ') ? "X" : "R";
                                with_1.Cells[with_1.RowCount - 1, 4].Value = (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ') ? (chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT")) : (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT"));
                                with_1.Cells[with_1.RowCount - 1, 5].Value = (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ') ? (MPCF.SetRuleDescription(chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT"), out_node, 'X')) : (MPCF.SetRuleDescription(chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT"), out_node, 'R'));
                                if (c_step == "2")
                                {
                                    with_1.Cells[with_1.RowCount - 1, 7].Value = chart_item.GetInt("HIST_SEQ");
                                    with_1.Cells[with_1.RowCount - 1, 8].Value = chart_item.GetString("TRAN_TIME");
                                }
                            }
                        }
                        j++;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.View_Result()\n" + ex.Message);
            }
            
        }
        
        // SetLockSpread()
        //       - Set spread's lock property
        // Return Value
        //       -
        // Arguments
        //       - ByVal bLockFlag As Boolean : lock flag
        //
        public void SetLockSpread(bool bLockFlag)
        {
            
            try
            {
                int i;
                Control ctrlPanel;
                Control ctrludcChartInfo;
                
                foreach (Control tempLoopVar_ctrlPanel in pnlChartSet.Controls)
                {
                    ctrlPanel = tempLoopVar_ctrlPanel;
                    if (ctrlPanel is Panel)
                    {
                        foreach (Control tempLoopVar_ctrludcChartInfo in ctrlPanel.Controls)
                        {
                            ctrludcChartInfo = tempLoopVar_ctrludcChartInfo;
                            if (ctrludcChartInfo is udcChartInfo)
                            {
                                for (i = 1; i <= ((udcChartInfo) ctrludcChartInfo).GetSpreadData.Sheets[0].ColumnCount - 7; i++)
                                {
                                    ((udcChartInfo) ctrludcChartInfo).GetSpreadData.Sheets[0].Columns[i].Locked = bLockFlag;
                                }
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.SetLockSpread()\n" + ex.Message);
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtLot;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void cdvProcOper_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvProcOper.Init();
                MPCF.InitListView(cdvProcOper.GetListView);
                cdvProcOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvProcOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvProcOper.SelectedSubItemIndex = 0;
                if (WIPLIST.ViewOperationList(cdvProcOper.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "") == false)
                {
                    return;
                }
                cdvProcOper.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvProcOper_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvResID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvResID.Init();
                MPCF.InitListView(cdvResID.GetListView);
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;
                if (RASLIST.ViewResourceList(cdvResID.GetListView, MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, MPCF.Trim(cdvFlow.Text), MPCF.Trim(cdvOper.Text), false) == false)
                {
                    return;
                }
                cdvResID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvResID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvProcResID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvProcResID.Init();
                MPCF.InitListView(cdvProcResID.GetListView);
                cdvProcResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvProcResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvProcResID.SelectedSubItemIndex = 0;
                if (RASLIST.ViewResourceList(cdvProcResID.GetListView, MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, MPCF.Trim(cdvFlow.Text), MPCF.Trim(cdvOper.Text), false) == false)
                {
                    return;
                }
                cdvProcResID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvProcResID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                txtTranTime.Visible = ! chkTranDateTime.Checked;
                uccTranDate.Enabled = chkTranDateTime.Checked;
                udtTranTime.Enabled = chkTranDateTime.Checked;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.chkTranDateTime_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCTranCollectLotDatabyChartSet_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLot.Text = MPGV.gsCurrentLot_ID;
                        if (View_Lot() == false)
                        {
                            return;
                        }
                    }
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.frmSPCTranCollectLotDatabyChartSet_Activated()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCTranCollectLotDatabyChartSet_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                
                MPCF.SetTextboxStyle(this.Controls);
                uccTranDate.Value = DateTime.Now;
                udtTranTime.Value = DateTime.Now;
                pnlTranTime.Visible = MPGO.UseBackDate();

                cdvMaterial.BackColor = SystemColors.Control;

                cdvFlow.VisibleFlowButton = false;
                cdvFlow.FlowReadOnly = true;
                cdvFlow.VisibleSequenceButton = false;
                cdvFlow.SequenceReadOnly = true;
                cdvFlow.BackColor = SystemColors.Control;
                
                cdvOper.VisibleButton = false;
                cdvOper.ReadOnly = true;
                cdvOper.BackColor = SystemColors.Control;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.frmSPCTranCollectLotDatabyChartSet_Load()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154));
                    cdvMaterial.MaterialFocus();
                    return;
                }
                cdvChartSetID.Init();
                MPCF.InitListView(cdvChartSetID.GetListView);
                cdvChartSetID.Columns.Add("ChartSetID", 50, HorizontalAlignment.Left);
                cdvChartSetID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartSetID.SelectedSubItemIndex = 0;

                if (SPCLIST.ViewChartSetList(cdvChartSetID.GetListView, '2', MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, MPCF.Trim(cdvOper.Text), MPCF.Trim(cdvResID.Text), 'L', cdvFlow.Text, -1, -1, "") == false)
                {
                    return;
                }
                
                cdvChartSetID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvChartSetID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                cdvUserID.Text = "";
                this.SuspendLayout();
                pnlChartSet.Controls.Clear();
                SetChartControl();
                this.ResumeLayout(false);
                cdvChartSetID.Focus();
                btnOK.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvChartSetID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void txtLot_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                char sChartFlag = ' ';
                string sChartSetID = string.Empty;
                char sOvrFlag= ' ';

                if (e.KeyChar == (char)13)
                {
                    if (txtLot.Text != "")
                    {
                        pnlChartSet.Controls.Clear();
                        MPCF.FieldClear(this.pnlCenter, txtLot, null, null, null, null, false);
                        if (View_Lot() == false)
                        {
                            return;
                        }
                        if (MPCR.ViewMFOChart('2', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOper.Text, ref sChartFlag, ref sChartSetID, ref sOvrFlag, true) == false)
                        {
                            return;
                        }
                        if (sChartFlag == 'S' && sChartSetID != "")
                        {
                            if (sOvrFlag == 'Y')
                            {
                                cdvChartSetID.BackColor = System.Drawing.Color.White;
                                cdvChartSetID.ReadOnly = false;
                                cdvChartSetID.VisibleButton = true;
                                cdvChartSetID.Text = sChartSetID;
                            }
                            else
                            {
                                cdvChartSetID.BackColor = SystemColors.Control;
                                cdvChartSetID.ReadOnly = true;
                                cdvChartSetID.VisibleButton = false;
                                cdvChartSetID.Text = sChartSetID;
                            }
                            cdvChartSetID_SelectedItemChanged(sender, null);
                        }
                        else
                        {
                            cdvChartSetID.BackColor = System.Drawing.Color.White;
                            cdvChartSetID.ReadOnly = false;
                            cdvChartSetID.VisibleButton = true;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.txtLot_KeyPress()\n" + ex.Message);
            }
            
        }
        
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                Control ctl;
                Control ctl2;
                
                foreach (Control tempLoopVar_ctl in pnlChartSet.Controls)
                {
                    ctl = tempLoopVar_ctl;
                    if (ctl is Panel)
                    {
                        foreach (Control tempLoopVar_ctl2 in ctl.Controls)
                        {
                            ctl2 = tempLoopVar_ctl2;
                            if (ctl2 is udcChartInfo)
                            {
                                if (CheckCondition((udcChartInfo) ctl2) == false)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
                foreach (Control tempLoopVar_ctl in pnlChartSet.Controls)
                {
                    ctl = tempLoopVar_ctl;
                    if (ctl is Panel)
                    {
                        foreach (Control tempLoopVar_ctl2 in ctl.Controls)
                        {
                            ctl2 = tempLoopVar_ctl2;
                            if (ctl2 is udcChartInfo)
                            {
                                ((udcChartInfo) ctl2).ClearBackColor();
                            }
                        }
                    }
                }
                if (Collect_EDC_Data_by_ChartSet(MPGC.MP_STEP_TRAN) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.btnOK_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtLot_TextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlCenter, txtLot, null, null, null, null, false);
                pnlChartSet.Controls.Clear();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.txtLot_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnGraph_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (pnlChartSet.Controls.Count == 0)
                {
                    return;
                }
                
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCTranControlChart");
                    if (form == null)
                    {
                        form = new frmSPCTranControlChart();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
                    }
                    else
                    {
                        form.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }

                ((frmSPCTranControlChart) form).uccStart.Value = DateTime.Now;
                ((frmSPCTranControlChart) form).udtStart.Value = "000000";
                ((frmSPCTranControlChart) form).uccEnd.Value = DateTime.Now;
                ((frmSPCTranControlChart) form).udtEnd.Value = "235959";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.btnGraph_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnRawData_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (pnlChartSet.Controls.Count == 0)
                {
                    return;
                }
                
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCViewEDCData");
                    if (form == null)
                    {
                        form = new frmSPCViewEDCData();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
                    }
                    else
                    {
                        form.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }

                ((frmSPCViewEDCData) form).uccStart.Value = DateTime.Now;
                ((frmSPCViewEDCData) form).udtStart.Value = "000000";
                ((frmSPCViewEDCData) form).uccEnd.Value = DateTime.Now;
                ((frmSPCViewEDCData) form).udtEnd.Value = "235959";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.btnRawData_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnHistogram_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (pnlChartSet.Controls.Count == 0)
                {
                    return;
                }
                
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCTranCapability");
                    if (form == null)
                    {
                        form = new frmSPCTranCapability();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
                    }
                    else
                    {
                        form.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }

                ((frmSPCTranCapability) form).uccStart.Value = DateTime.Now;
                ((frmSPCTranCapability) form).udtStart.Value = "000000";
                ((frmSPCTranCapability) form).uccEnd.Value = DateTime.Now;
                ((frmSPCTranCapability) form).udtEnd.Value = "235959";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.btnHistogram_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvUserID.Text = "";
                pnlChartSet.Controls.Clear();
                cdvChartSetID.Focus();
                btnOK.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvChartSetID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                Control ctl;
                Control ctl2;
                
                foreach (Control tempLoopVar_ctl in pnlChartSet.Controls)
                {
                    ctl = tempLoopVar_ctl;
                    if (ctl is Panel)
                    {
                        foreach (Control tempLoopVar_ctl2 in ctl.Controls)
                        {
                            ctl2 = tempLoopVar_ctl2;
                            if (ctl2 is udcChartInfo)
                            {
                                ((udcChartInfo) ctl2).ViewChartInfo(false);
                                SetLockSpread(false);
                            }
                        }
                    }
                }
                btnOK.Enabled = true;
                cdvUserID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvUserID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvUserID.Init();
                MPCF.InitListView(cdvUserID.GetListView);
                cdvUserID.Columns.Add("UserID", 50, HorizontalAlignment.Left);
                cdvUserID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvUserID.SelectedSubItemIndex = 0;
                SECLIST.ViewSECUserList(cdvUserID.GetListView, '1', -1, null, "", "");
                cdvUserID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvUserID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void chkSelectMFO_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (chkSelectMFO.Checked == true)
                {
                    cdvFlow.VisibleFlowButton = true;
                    cdvFlow.FlowReadOnly = false;
                    cdvFlow.VisibleSequenceButton = true;
                    cdvFlow.SequenceReadOnly = false;
                    cdvFlow.BackColor = Color.White;
                    cdvOper.VisibleButton = true;
                    cdvOper.ReadOnly = false;
                    cdvOper.BackColor = Color.White;
                }
                else
                {
                    cdvFlow.Text = "";
                    cdvOper.Text = "";
                    cdvFlow.VisibleFlowButton = false;
                    cdvFlow.FlowReadOnly = true;
                    cdvFlow.VisibleSequenceButton = false;
                    cdvFlow.SequenceReadOnly = true;
                    cdvFlow.BackColor = SystemColors.Control;
                    cdvOper.VisibleButton = false;
                    cdvOper.ReadOnly = true;
                    cdvOper.BackColor = SystemColors.Control;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.chkSelectMFO_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
                
        private void cdvOper_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMaterial.MaterialFocus();
                    return;
                }
                if (cdvFlow.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvFlow.Focus();
                    return;
                }
                cdvOper.Init();
                MPCF.InitListView(cdvOper.GetListView);
                cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvOper.SelectedSubItemIndex = 0;
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "") == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvOper_ButtonPress()\n" + ex.Message);
            }
            
        }
        
                
        private void cdvOper_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                char sChartFlag = ' ';
                string sChartSetID = string.Empty;
                char sOvrFlag= ' ';

                pnlChartSet.Controls.Clear();
                cdvResID.Text = "";
                cdvChartSetID.Text = "";
                cdvChartSetID.Init();
                if (MPCF.Trim(cdvOper.Text) != "")
                {
                    if (MPCR.ViewMFOChart('2', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOper.Text, ref sChartFlag, ref sChartSetID, ref sOvrFlag, true) == false)
                    {
                        return;
                    }
                    if (sChartFlag == 'S' && sChartSetID != "")
                    {
                        if (sOvrFlag == 'Y')
                        {
                            cdvChartSetID.BackColor = System.Drawing.Color.White;
                            cdvChartSetID.ReadOnly = false;
                            cdvChartSetID.VisibleButton = true;
                            cdvChartSetID.Text = sChartSetID;
                        }
                        else
                        {
                            cdvChartSetID.BackColor = SystemColors.Control;
                            cdvChartSetID.ReadOnly = true;
                            cdvChartSetID.VisibleButton = false;
                            cdvChartSetID.Text = sChartSetID;
                        }
                        cdvChartSetID_SelectedItemChanged(sender, null);
                    }
                    else
                    {
                        cdvChartSetID.BackColor = System.Drawing.Color.White;
                        cdvChartSetID.ReadOnly = false;
                        cdvChartSetID.VisibleButton = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvOper_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
    
        
        private void cdvOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            try
            {
                pnlChartSet.Controls.Clear();
                cdvResID.Text = "";
                cdvChartSetID.Text = "";
                cdvChartSetID.Init();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvOper_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        #endregion

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            try
            {
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMaterial.MaterialFocus();
                    return;
                }
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvFlow_FlowButtonPress()\n" + ex.Message);
            }
        }

        private void cdvFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                pnlChartSet.Controls.Clear();
                cdvOper.Text = "";
                cdvOper.Init();
                cdvResID.Text = "";
                cdvChartSetID.Text = "";
                cdvChartSetID.Init();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvFlow_FlowSelectedItemChanged()\n" + ex.Message);
            }
        }

        private void cdvFlow_FlowTextChanged(object sender, EventArgs e)
        {
            try
            {
                pnlChartSet.Controls.Clear();
                cdvOper.Text = "";
                cdvOper.Init();
                cdvResID.Text = "";
                cdvChartSetID.Text = "";
                cdvChartSetID.Init();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.cdvFlow_FlowTextChanged()\n" + ex.Message);
            }
        }

        private void cdvFlow_SeqButtonPress(object sender, EventArgs e)
        {
            try
            {
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMaterial.MaterialFocus();
                    return;
                }
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvFlow_FlowButtonPress()\n" + ex.Message);
            }
        }
        
    }
    
    
    //#End If
    
}
