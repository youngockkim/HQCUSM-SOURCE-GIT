
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
//   File Name   : frmSPCTranCollectLotDatabyCharacter.vb
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
    public class frmSPCTranCollectLotDatabyCharacter : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranCollectLotDatabyCharacter()
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
        internal System.Windows.Forms.Button btnGraph;
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
        internal System.Windows.Forms.TabControl tabChart;
        internal System.Windows.Forms.Button btnHistogram;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvUserID;
        internal System.Windows.Forms.Label lblUserID;
        protected Infragistics.Win.UltraWinEditors.UltraCheckEditor chkSelectMFO;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranCollectLotDatabyCharacter));
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.btnRawData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.tabChart = new System.Windows.Forms.TabControl();
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
            this.btnHistogram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHistogram.Location = new System.Drawing.Point(423, 8);
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
            this.pnlCenter.Controls.Add(this.tabChart);
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
            // tabChart
            // 
            this.tabChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChart.Location = new System.Drawing.Point(3, 240);
            this.tabChart.Name = "tabChart";
            this.tabChart.SelectedIndex = 0;
            this.tabChart.Size = new System.Drawing.Size(786, 356);
            this.tabChart.TabIndex = 3;
            this.tabChart.SelectedIndexChanged += new System.EventHandler(this.tabChart_SelectedIndexChanged);
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
            this.lblUserID.Location = new System.Drawing.Point(462, 19);
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
            this.cdvFlow.AutoSize = true;
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
            this.cdvMaterial.Location = new System.Drawing.Point(15, 40);
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
            this.cdvMaterial.WidthLabel = 109;
            this.cdvMaterial.WidthMaterialAndVersion = 201;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // chkSelectMFO
            // 
            this.chkSelectMFO.Location = new System.Drawing.Point(15, 18);
            this.chkSelectMFO.Name = "chkSelectMFO";
            this.chkSelectMFO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSelectMFO.Size = new System.Drawing.Size(121, 17);
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
            this.lblProcResID.Location = new System.Drawing.Point(462, 92);
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
            this.lblProcOper.Location = new System.Drawing.Point(462, 68);
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
            this.txtTranTime.TabIndex = 1;
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
            this.chkTranDateTime.Size = new System.Drawing.Size(121, 17);
            this.chkTranDateTime.TabIndex = 0;
            this.chkTranDateTime.Text = "Transaction Time";
            this.chkTranDateTime.CheckedChanged += new System.EventHandler(this.chkTranDateTime_CheckedChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(124, 41);
            this.txtDesc.MaxLength = 200;
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
            // frmSPCTranCollectLotDatabyCharacter
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 636);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 670);
            this.Name = "frmSPCTranCollectLotDatabyCharacter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Collect EDC Data by Chart Set";
            this.Activated += new System.EventHandler(this.frmSPCTranCollectLotDatabyCharacter_Activated);
            this.Closed += new System.EventHandler(this.frmSPCTranCollectLotDatabyCharacter_Closed);
            this.Load += new System.EventHandler(this.frmSPCTranCollectLotDatabyCharacter_Load);
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
        
        #endregion
        
        #region " Variable Definition"
        private bool b_load_flag = false;
        private ArrayList DisabledFormControls = new ArrayList();

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
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.CheckCondition()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.View_Lot()\n" + ex.Message);
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
                Control ctrl;
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
                        TabPage tbpPage = new TabPage();
                        udcChartInfo ctrlChartInfo = new udcChartInfo();
                        ctrlChartInfo.ChartID = out_node.GetList(0)[i].GetString("CHART_ID");
                        ctrlChartInfo.Dock = DockStyle.Fill;
                        tbpPage.Text = ctrlChartInfo.ChartID;
                        tbpPage.Controls.Add(ctrlChartInfo);
                        tabChart.Controls.Add(tbpPage);
                        ctrlChartInfo.ViewChartInfo(true);
                        if (ctrlChartInfo.ViewChart == "Y")
                        {
                            ctrlChartInfo.InitChart();
                            ctrlChartInfo.ViewControlChart(true);
                        }
                    }
                }
                    
                if (tabChart.TabPages.Count > 0)
                {
                    foreach (Control tempLoopVar_ctrl in tabChart.SelectedTab.Controls)
                    {
                        ctrl = tempLoopVar_ctrl;
                        if (ctrl is udcChartInfo)
                        {
                            if (((udcChartInfo)ctrl).ValueType == "A")
                            {
                                btnHistogram.Enabled = false;
                                btnGraph.Enabled = false;
                            }
                            else
                            {
                                MPCR.ChangeControlEnabled(this, btnHistogram, true);
                                MPCR.ChangeControlEnabled(this, btnGraph, true);
                            }

                        }
                    }
                }

                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.SetChartControl()\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetCollectData()
        //       - Set Collection Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ctrlChartInfo As udcChartInfo
        //
        private void SetCollectData(udcChartInfo ctrlChartInfo)
        {
            try
            {
                ctrlChartInfo.ChartID = tabChart.SelectedTab.Text;
                ctrlChartInfo.LotResFlag = 'L';
                ctrlChartInfo.LotID = MPCF.Trim(txtLot.Text);
                ctrlChartInfo.MatID = MPCF.Trim(cdvMaterial.Text);
                ctrlChartInfo.MatVer = cdvMaterial.Version;
                ctrlChartInfo.Flow = MPCF.Trim(cdvFlow.Text);
                ctrlChartInfo.FlowSeq = cdvFlow.Sequence;
                ctrlChartInfo.Oper = MPCF.Trim(cdvOper.Text);
                ctrlChartInfo.ProcOper = MPCF.Trim(cdvProcOper.Text);
                ctrlChartInfo.ResID = ctrlChartInfo.ctrlChartData.Resource;
                ctrlChartInfo.ProcResID = MPCF.Trim(cdvProcResID.Text);
                ctrlChartInfo.CharID = ctrlChartInfo.ctrlChartData.Character;
                ctrlChartInfo.TranTime = ((DateTime)uccTranDate.Value).ToString("yyyyMMdd") + ((DateTime)udtTranTime.Value).ToString("HHmmss");
                ctrlChartInfo.UserID = MPCF.Trim(cdvUserID.Text);
                ctrlChartInfo.SelectMFOFlag = chkSelectMFO.Checked ? 'Y' : ' ';
                
                if (chkTranDateTime.Checked == true)
                {
                    ctrlChartInfo.IsBackTime = true;
                }
                else
                {
                    ctrlChartInfo.IsBackTime = false;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.SetCollectData()\n" + ex.Message);
            }
            
        }
        
        // EnableInput()
        //       - Set Enable Property
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void EnableInput()
        {
            
            try
            {
                Control ctrl;
                if (tabChart.Controls.Count == 0)
                {
                    return;
                }
                if (MPCF.Trim(tabChart.SelectedTab.Tag) == "Y")
                {
                    btnOK.Enabled = false;
                }
                else
                {
                    MPCR.ChangeControlEnabled(this, btnOK, true);
                }
                foreach (Control tempLoopVar_ctrl in tabChart.SelectedTab.Controls)
                {
                    ctrl = tempLoopVar_ctrl;
                    if (ctrl is udcChartInfo)
                    {
                        if (((udcChartInfo) ctrl).ValueType == "A")
                        {
                            btnHistogram.Enabled = false;
                            btnGraph.Enabled = false;
                        }
                        else
                        {
                            MPCR.ChangeControlEnabled(this, btnHistogram, true);
                            MPCR.ChangeControlEnabled(this, btnGraph, true);
                        }
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.EnableInput()\n" + ex.Message);
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
        
        private void frmSPCTranCollectLotDatabyCharacter_Load(object sender, System.EventArgs e)
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.frmSPCTranCollectLotDatabyCharacter_Load()\n" + ex.Message);
            }

        }

        private void frmSPCTranCollectLotDatabyCharacter_Activated(object sender, System.EventArgs e)
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.frmSPCTranCollectLotDatabyCharacter_Activated()\n" + ex.Message);
            }

        }

        private void frmSPCTranCollectLotDatabyCharacter_Closed(object sender, System.EventArgs e)
        {

            try
            {
                Control ctl;
                Control ctl1;
                foreach (Control tempLoopVar_ctl in tabChart.Controls)
                {
                    ctl = tempLoopVar_ctl;
                    if (ctl is TabPage)
                    {
                        foreach (Control tempLoopVar_ctl1 in ctl.Controls)
                        {
                            ctl1 = tempLoopVar_ctl1;
                            if (ctl1 is udcChartInfo)
                            {
                                ((udcChartInfo)ctl1).ViewControlChart(false);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.frmSPCTranCollectLotDatabyCharacter_Closed()\n" + ex.Message);
            }

        }

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
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.cdvProcOper_ButtonPress()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.cdvResID_ButtonPress()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.cdvProcResID_ButtonPress()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.chkTranDateTime_CheckedChanged()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.cdvChartSetID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                Control ctl;
                Control ctl1;
                foreach (Control tempLoopVar_ctl in tabChart.Controls)
                {
                    ctl = tempLoopVar_ctl;
                    if (ctl is TabPage)
                    {
                        foreach (Control tempLoopVar_ctl1 in ctl.Controls)
                        {
                            ctl1 = tempLoopVar_ctl1;
                            if (ctl1 is udcChartInfo)
                            {
                                ((udcChartInfo) ctl1).ViewControlChart(false);
                            }
                        }
                    }
                }
                
                cdvUserID.Text = "";
                this.SuspendLayout();
                tabChart.Controls.Clear();
                SetChartControl();
                this.ResumeLayout(false);
                cdvChartSetID.Focus();
                MPCR.ChangeControlEnabled(this, btnOK, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.cdvChartSetID_SelectedItemChanged()\n" + ex.Message);
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
                        tabChart.Controls.Clear();
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.txtLot_KeyPress()\n" + ex.Message);
            }
            
        }
        
        private void btnOK_Click(object sender, System.EventArgs e)
        {
           
            try
            {
                Control ctl;
                foreach (Control tempLoopVar_ctl in tabChart.SelectedTab.Controls)
                {
                    ctl = tempLoopVar_ctl;
                    if (ctl is udcChartInfo)
                    {
                        if (CheckCondition((udcChartInfo) ctl) == false)
                        {
                            return;
                        }
                        SetCollectData((udcChartInfo) ctl);
                        if (((udcChartInfo) ctl).CollectEDCData(MPGC.MP_STEP_TRAN) == false)
                        {
                            return;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.btnOK_Click()\n" + ex.Message);
            }
            
        }
                
        private void tabChart_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                EnableInput();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.tabChart_SelectedIndexChanged()\n" + ex.Message);
            }
            
        }
        
        private void txtLot_TextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlCenter, txtLot, null, null, null, null, false);
                tabChart.Controls.Clear();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.txtLot_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnGraph_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (tabChart.Controls.Count == 0)
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
                ((frmSPCTranControlChart) form).cdvChartID.Text = tabChart.SelectedTab.Text;
                if (((frmSPCTranControlChart) form).cdvChartID.Text != "")
                {
                    ((frmSPCTranControlChart) form).ChartIDSelected();
                    ((frmSPCTranControlChart) form).btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.btnGraph_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnRawData_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (tabChart.Controls.Count == 0)
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
                ((frmSPCViewEDCData) form).cdvChartID.Text = tabChart.SelectedTab.Text;
                if (((frmSPCViewEDCData) form).cdvChartID.Text != "")
                {
                    ((frmSPCViewEDCData) form).Set_Data();
                    ((frmSPCViewEDCData) form).btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.btnRawData_Click()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnHistogram_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (tabChart.Controls.Count == 0)
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
                ((frmSPCTranCapability) form).cdvChartID.Text = tabChart.SelectedTab.Text;
                if (((frmSPCTranCapability) form).cdvChartID.Text != "")
                {
                    ((frmSPCTranCapability) form).ChartIDSelected();
                    ((frmSPCTranCapability) form).btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.btnHistogram_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                Control ctl;
                Control ctl1;
                foreach (Control tempLoopVar_ctl in tabChart.Controls)
                {
                    ctl = tempLoopVar_ctl;
                    if (ctl is TabPage)
                    {
                        foreach (Control tempLoopVar_ctl1 in ctl.Controls)
                        {
                            ctl1 = tempLoopVar_ctl1;
                            if (ctl1 is udcChartInfo)
                            {
                                ((udcChartInfo) ctl1).ViewControlChart(false);
                            }
                        }
                    }
                }
                
                cdvUserID.Text = "";
                tabChart.Controls.Clear();
                cdvChartSetID.Focus();
                MPCR.ChangeControlEnabled(this, btnOK, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.cdvChartSetID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                Control ctl;
                Control ctl1;

                if (MPCF.Trim(cdvChartSetID.Text) == "")
                {
                    return;
                }
                foreach (Control tempLoopVar_ctl in tabChart.Controls)
                {
                    ctl = tempLoopVar_ctl;
                    if (ctl is TabPage)
                    {
                        foreach (Control tempLoopVar_ctl1 in ctl.Controls)
                        {
                            ctl1 = tempLoopVar_ctl1;
                            if (ctl1 is udcChartInfo)
                            {
                                ((udcChartInfo) ctl1).ViewControlChart(false);
                            }
                        }
                    }
                }
                
                cdvUserID.Text = "";
                this.SuspendLayout();
                tabChart.Controls.Clear();
                SetChartControl();
                this.ResumeLayout(false);
                cdvChartSetID.Focus();
                MPCR.ChangeControlEnabled(this, btnOK, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyCharacter.btnRefresh_Click()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvUserID_ButtonPress()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.chkSelectMFO_CheckedChanged()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvOper_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvOper_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                char sChartFlag = ' ';
                string sChartSetID = string.Empty;
                char sOvrFlag= ' ';

                tabChart.Controls.Clear();
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvOper_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            try
            {
                tabChart.Controls.Clear();
                cdvResID.Text = "";
                cdvChartSetID.Text = "";
                cdvChartSetID.Init();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvOper_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvFlow_FlowButtonPress()\n" + ex.Message);
            }
        }

        private void cdvFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                tabChart.Controls.Clear();
                cdvOper.Text = "";
                cdvOper.Init();
                cdvResID.Text = "";
                cdvChartSetID.Text = "";
                cdvChartSetID.Init();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvFlow_FlowSelectedItemChanged()\n" + ex.Message);
            }
        }

        private void cdvFlow_FlowTextChanged(object sender, EventArgs e)
        {
            try
            {
                tabChart.Controls.Clear();
                cdvOper.Text = "";
                cdvOper.Init();
                cdvResID.Text = "";
                cdvChartSetID.Text = "";
                cdvChartSetID.Init();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvFlow_TextBoxTextChanged()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvFlow_SeqButtonPress()\n" + ex.Message);
            }
        }
        
    }
    
    
    //#End If
    
}
