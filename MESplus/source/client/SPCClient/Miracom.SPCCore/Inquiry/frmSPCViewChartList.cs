
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
//   System      : MES
//   File Name   : frmSPCViewChartList.vb
//   Description : MES Cient Form View Lot List Main
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
//       - 2004-07-10 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.SPCCore
{
    public class frmSPCViewChartList : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCViewChartList()
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
        



        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.ContextMenu ctxMenu;
        internal System.Windows.Forms.Panel pnlTop;
        internal System.Windows.Forms.Panel pnlMid;
        internal System.Windows.Forms.ColumnHeader colSeq;
        internal System.Windows.Forms.GroupBox grpInfo;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCharID;
        internal System.Windows.Forms.Label lblChar;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        internal System.Windows.Forms.Label lblResID;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        internal System.Windows.Forms.Label lblOper;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        internal System.Windows.Forms.Label lblFlow;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboLotorRes;
        internal System.Windows.Forms.Label lblLotRes;
        internal System.Windows.Forms.Button btnView;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboGraphType;
        internal System.Windows.Forms.Label lblGraphType;
        internal Miracom.UI.Controls.MCListView.MCListView lisChart;
        internal System.Windows.Forms.ColumnHeader colChartID;
        internal System.Windows.Forms.ColumnHeader colDesc;
        internal System.Windows.Forms.ColumnHeader colMatID;
        internal System.Windows.Forms.ColumnHeader colFlow;
        internal System.Windows.Forms.ColumnHeader colOper;
        internal System.Windows.Forms.ColumnHeader colLotorRes;
        internal System.Windows.Forms.ColumnHeader colResID;
        internal System.Windows.Forms.ColumnHeader colColSet;
        internal System.Windows.Forms.ColumnHeader colChar;
        internal System.Windows.Forms.ColumnHeader colUnitUse;
        internal System.Windows.Forms.ColumnHeader colUnitCount;
        internal System.Windows.Forms.ColumnHeader colSampleSize;
        internal System.Windows.Forms.ColumnHeader colConst1;
        internal System.Windows.Forms.ColumnHeader colConst2;
        internal System.Windows.Forms.ColumnHeader colConst3;
        internal System.Windows.Forms.ColumnHeader colConst4;
        internal System.Windows.Forms.ColumnHeader colPrecision;
        internal System.Windows.Forms.ColumnHeader colSpecCheck;
        internal System.Windows.Forms.ColumnHeader colSpecOutCount;
        internal System.Windows.Forms.ColumnHeader colGroup1;
        internal System.Windows.Forms.ColumnHeader colGroup2;
        internal System.Windows.Forms.ColumnHeader colGroup3;
        internal System.Windows.Forms.ColumnHeader colGroup4;
        internal System.Windows.Forms.ColumnHeader colGroup5;
        internal System.Windows.Forms.ColumnHeader colGroup6;
        internal System.Windows.Forms.ColumnHeader colGroup7;
        internal System.Windows.Forms.ColumnHeader colGroup8;
        internal System.Windows.Forms.ColumnHeader colGroup9;
        internal System.Windows.Forms.ColumnHeader colGroup10;
        internal System.Windows.Forms.ColumnHeader colCmf1;
        internal System.Windows.Forms.ColumnHeader colCmf2;
        internal System.Windows.Forms.ColumnHeader colCmf3;
        internal System.Windows.Forms.ColumnHeader colCmf4;
        internal System.Windows.Forms.ColumnHeader colCmf5;
        internal System.Windows.Forms.ColumnHeader colCmf6;
        internal System.Windows.Forms.ColumnHeader colCmf7;
        internal System.Windows.Forms.ColumnHeader colCmf8;
        internal System.Windows.Forms.ColumnHeader colCmf9;
        internal System.Windows.Forms.ColumnHeader colCmf10;
        internal System.Windows.Forms.ColumnHeader colComment;
        internal System.Windows.Forms.ColumnHeader colCreateUser;
        internal System.Windows.Forms.ColumnHeader colUpdateUser;
        internal System.Windows.Forms.ColumnHeader colUpdateTime;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrompt;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup;
        internal System.Windows.Forms.Label lblPrt1;
        internal System.Windows.Forms.Label lblGrp1;
        internal System.Windows.Forms.ColumnHeader colCreateTime;
        internal System.Windows.Forms.ColumnHeader colGraph;
        internal System.Windows.Forms.ColumnHeader colEngineer;
        internal System.Windows.Forms.ColumnHeader colSyncEDC;
        internal System.Windows.Forms.Label lblUnitUse;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboUseUnit;
        internal System.Windows.Forms.Button btnCopyImage;
        internal System.Windows.Forms.Button btnSelect;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartSetID;
        internal Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private ColumnHeader colMatVer;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubResource;
        internal Label lblSubRes;
        private ColumnHeader colSubResID;
        internal System.Windows.Forms.Label lblChartSetID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCViewChartList));
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCopyImage = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctxMenu = new System.Windows.Forms.ContextMenu();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblSubRes = new System.Windows.Forms.Label();
            this.lblChartSetID = new System.Windows.Forms.Label();
            this.lblUnitUse = new System.Windows.Forms.Label();
            this.cboUseUnit = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPrt1 = new System.Windows.Forms.Label();
            this.lblGrp1 = new System.Windows.Forms.Label();
            this.cboGraphType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblGraphType = new System.Windows.Forms.Label();
            this.lblLotRes = new System.Windows.Forms.Label();
            this.cboLotorRes = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblChar = new System.Windows.Forms.Label();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblOper = new System.Windows.Forms.Label();
            this.lblFlow = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.lisChart = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChartID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGraph = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotorRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubResID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colColSet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSyncEDC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnitUse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnitCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSampleSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConst1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConst2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConst3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConst4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrecision = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSpecCheck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSpecOutCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroup1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroup2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroup3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroup4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroup5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroup6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroup7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroup8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroup9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroup10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCmf10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEngineer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdvSubResource = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChartSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvPrompt = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCharID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLotorRes)).BeginInit();
            this.pnlMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrompt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSelect);
            this.pnlBottom.Controls.Add(this.btnCopyImage);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelect.Location = new System.Drawing.Point(554, 8);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(88, 26);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCopyImage.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyImage.Image")));
            this.btnCopyImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCopyImage.Location = new System.Drawing.Point(38, 9);
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(24, 24);
            this.btnCopyImage.TabIndex = 4;
            this.btnCopyImage.Click += new System.EventHandler(this.btnCopyImage_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(460, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(12, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(648, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpInfo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
            this.pnlTop.Size = new System.Drawing.Size(742, 170);
            this.pnlTop.TabIndex = 0;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.cdvSubResource);
            this.grpInfo.Controls.Add(this.lblSubRes);
            this.grpInfo.Controls.Add(this.cdvMaterial);
            this.grpInfo.Controls.Add(this.cdvChartSetID);
            this.grpInfo.Controls.Add(this.lblChartSetID);
            this.grpInfo.Controls.Add(this.lblUnitUse);
            this.grpInfo.Controls.Add(this.cboUseUnit);
            this.grpInfo.Controls.Add(this.cdvPrompt);
            this.grpInfo.Controls.Add(this.cdvGroup);
            this.grpInfo.Controls.Add(this.lblPrt1);
            this.grpInfo.Controls.Add(this.lblGrp1);
            this.grpInfo.Controls.Add(this.cboGraphType);
            this.grpInfo.Controls.Add(this.lblGraphType);
            this.grpInfo.Controls.Add(this.lblLotRes);
            this.grpInfo.Controls.Add(this.cboLotorRes);
            this.grpInfo.Controls.Add(this.cdvCharID);
            this.grpInfo.Controls.Add(this.lblChar);
            this.grpInfo.Controls.Add(this.cdvResID);
            this.grpInfo.Controls.Add(this.lblResID);
            this.grpInfo.Controls.Add(this.cdvOper);
            this.grpInfo.Controls.Add(this.lblOper);
            this.grpInfo.Controls.Add(this.cdvFlow);
            this.grpInfo.Controls.Add(this.lblFlow);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInfo.Location = new System.Drawing.Point(2, 2);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(738, 166);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            // 
            // lblSubRes
            // 
            this.lblSubRes.AutoSize = true;
            this.lblSubRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubRes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubRes.Location = new System.Drawing.Point(322, 92);
            this.lblSubRes.Name = "lblSubRes";
            this.lblSubRes.Size = new System.Drawing.Size(75, 13);
            this.lblSubRes.TabIndex = 13;
            this.lblSubRes.Text = "Sub Resource";
            // 
            // lblChartSetID
            // 
            this.lblChartSetID.AutoSize = true;
            this.lblChartSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartSetID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartSetID.Location = new System.Drawing.Point(8, 116);
            this.lblChartSetID.Name = "lblChartSetID";
            this.lblChartSetID.Size = new System.Drawing.Size(65, 13);
            this.lblChartSetID.TabIndex = 15;
            this.lblChartSetID.Text = "Chart Set ID";
            // 
            // lblUnitUse
            // 
            this.lblUnitUse.AutoSize = true;
            this.lblUnitUse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnitUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitUse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUnitUse.Location = new System.Drawing.Point(322, 19);
            this.lblUnitUse.Name = "lblUnitUse";
            this.lblUnitUse.Size = new System.Drawing.Size(48, 13);
            this.lblUnitUse.TabIndex = 2;
            this.lblUnitUse.Text = "Use Unit";
            // 
            // cboUseUnit
            // 
            this.cboUseUnit.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DisplayText = "";
            valueListItem2.DataValue = "ValueListItem0";
            valueListItem2.DisplayText = "Y";
            valueListItem3.DataValue = "ValueListItem1";
            valueListItem3.DisplayText = "N";
            this.cboUseUnit.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cboUseUnit.Location = new System.Drawing.Point(427, 17);
            this.cboUseUnit.Name = "cboUseUnit";
            this.cboUseUnit.Size = new System.Drawing.Size(112, 19);
            this.cboUseUnit.TabIndex = 3;
            this.cboUseUnit.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblPrt1
            // 
            this.lblPrt1.AutoSize = true;
            this.lblPrt1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrt1.Location = new System.Drawing.Point(8, 139);
            this.lblPrt1.Name = "lblPrt1";
            this.lblPrt1.Size = new System.Drawing.Size(72, 13);
            this.lblPrt1.TabIndex = 19;
            this.lblPrt1.Text = "Group Prompt";
            // 
            // lblGrp1
            // 
            this.lblGrp1.AutoSize = true;
            this.lblGrp1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrp1.Location = new System.Drawing.Point(322, 139);
            this.lblGrp1.Name = "lblGrp1";
            this.lblGrp1.Size = new System.Drawing.Size(36, 13);
            this.lblGrp1.TabIndex = 21;
            this.lblGrp1.Text = "Group";
            // 
            // cboGraphType
            // 
            this.cboGraphType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboGraphType.Location = new System.Drawing.Point(427, 112);
            this.cboGraphType.MaxMRUItems = 10;
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.Size = new System.Drawing.Size(112, 19);
            this.cboGraphType.TabIndex = 18;
            this.cboGraphType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblGraphType
            // 
            this.lblGraphType.AutoSize = true;
            this.lblGraphType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGraphType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGraphType.Location = new System.Drawing.Point(322, 116);
            this.lblGraphType.Name = "lblGraphType";
            this.lblGraphType.Size = new System.Drawing.Size(63, 13);
            this.lblGraphType.TabIndex = 17;
            this.lblGraphType.Text = "Graph Type";
            // 
            // lblLotRes
            // 
            this.lblLotRes.AutoSize = true;
            this.lblLotRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotRes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotRes.Location = new System.Drawing.Point(8, 19);
            this.lblLotRes.Name = "lblLotRes";
            this.lblLotRes.Size = new System.Drawing.Size(83, 13);
            this.lblLotRes.TabIndex = 0;
            this.lblLotRes.Text = "Lot or Resource";
            // 
            // cboLotorRes
            // 
            this.cboLotorRes.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem4.DisplayText = "";
            valueListItem5.DataValue = "ValueListItem0";
            valueListItem5.DisplayText = "Lot";
            valueListItem6.DataValue = "ValueListItem1";
            valueListItem6.DisplayText = "Resource";
            this.cboLotorRes.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5,
            valueListItem6});
            this.cboLotorRes.Location = new System.Drawing.Point(110, 17);
            this.cboLotorRes.Name = "cboLotorRes";
            this.cboLotorRes.Size = new System.Drawing.Size(112, 19);
            this.cboLotorRes.TabIndex = 1;
            this.cboLotorRes.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblChar
            // 
            this.lblChar.AutoSize = true;
            this.lblChar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChar.Location = new System.Drawing.Point(8, 92);
            this.lblChar.Name = "lblChar";
            this.lblChar.Size = new System.Drawing.Size(67, 13);
            this.lblChar.TabIndex = 11;
            this.lblChar.Text = "Character ID";
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResID.Location = new System.Drawing.Point(322, 67);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(53, 13);
            this.lblResID.TabIndex = 9;
            this.lblResID.Text = "Resource";
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOper.Location = new System.Drawing.Point(8, 67);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 7;
            this.lblOper.Text = "Operation";
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFlow.Location = new System.Drawing.Point(322, 44);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(29, 13);
            this.lblFlow.TabIndex = 5;
            this.lblFlow.Text = "Flow";
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.lisChart);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(0, 170);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pnlMid.Size = new System.Drawing.Size(742, 336);
            this.pnlMid.TabIndex = 1;
            // 
            // lisChart
            // 
            this.lisChart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colChartID,
            this.colDesc,
            this.colGraph,
            this.colLotorRes,
            this.colMatID,
            this.colMatVer,
            this.colFlow,
            this.colOper,
            this.colResID,
            this.colSubResID,
            this.colColSet,
            this.colSyncEDC,
            this.colChar,
            this.colUnitUse,
            this.colUnitCount,
            this.colSampleSize,
            this.colConst1,
            this.colConst2,
            this.colConst3,
            this.colConst4,
            this.colPrecision,
            this.colSpecCheck,
            this.colSpecOutCount,
            this.colGroup1,
            this.colGroup2,
            this.colGroup3,
            this.colGroup4,
            this.colGroup5,
            this.colGroup6,
            this.colGroup7,
            this.colGroup8,
            this.colGroup9,
            this.colGroup10,
            this.colCmf1,
            this.colCmf2,
            this.colCmf3,
            this.colCmf4,
            this.colCmf5,
            this.colCmf6,
            this.colCmf7,
            this.colCmf8,
            this.colCmf9,
            this.colCmf10,
            this.colEngineer,
            this.colComment,
            this.colCreateUser,
            this.colCreateTime,
            this.colUpdateUser,
            this.colUpdateTime});
            this.lisChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisChart.EnableSort = true;
            this.lisChart.EnableSortIcon = true;
            this.lisChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisChart.FullRowSelect = true;
            this.lisChart.Location = new System.Drawing.Point(2, 0);
            this.lisChart.MultiSelect = false;
            this.lisChart.Name = "lisChart";
            this.lisChart.Size = new System.Drawing.Size(738, 336);
            this.lisChart.TabIndex = 0;
            this.lisChart.UseCompatibleStateImageBehavior = false;
            this.lisChart.View = System.Windows.Forms.View.Details;
            this.lisChart.Click += new System.EventHandler(this.lisChart_Click);
            this.lisChart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lisChart_KeyDown);
            this.lisChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lisChart_MouseDown);
            this.lisChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lisChart_MouseUp);
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            this.colSeq.Width = 40;
            // 
            // colChartID
            // 
            this.colChartID.Text = "Chart ID";
            this.colChartID.Width = 100;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 120;
            // 
            // colGraph
            // 
            this.colGraph.Text = "Graph Type";
            this.colGraph.Width = 75;
            // 
            // colLotorRes
            // 
            this.colLotorRes.Text = "L/R";
            this.colLotorRes.Width = 35;
            // 
            // colMatID
            // 
            this.colMatID.Text = "Material";
            this.colMatID.Width = 100;
            // 
            // colMatVer
            // 
            this.colMatVer.Text = "Mat Ver";
            this.colMatVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colMatVer.Width = 55;
            // 
            // colFlow
            // 
            this.colFlow.Text = "Flow";
            this.colFlow.Width = 80;
            // 
            // colOper
            // 
            this.colOper.Text = "Operation";
            this.colOper.Width = 70;
            // 
            // colResID
            // 
            this.colResID.Text = "Res ID";
            this.colResID.Width = 90;
            // 
            // colSubResID
            // 
            this.colSubResID.Text = "Sub Resource";
            this.colSubResID.Width = 80;
            // 
            // colColSet
            // 
            this.colColSet.Text = "Collection Set";
            this.colColSet.Width = 70;
            // 
            // colSyncEDC
            // 
            this.colSyncEDC.Text = "Sync EDC";
            this.colSyncEDC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSyncEDC.Width = 70;
            // 
            // colChar
            // 
            this.colChar.Text = "Character";
            this.colChar.Width = 80;
            // 
            // colUnitUse
            // 
            this.colUnitUse.Text = "Use Unit";
            this.colUnitUse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colUnitUse.Width = 80;
            // 
            // colUnitCount
            // 
            this.colUnitCount.Text = "Unit Count";
            this.colUnitCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colUnitCount.Width = 80;
            // 
            // colSampleSize
            // 
            this.colSampleSize.Text = "Sample Size";
            this.colSampleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colSampleSize.Width = 80;
            // 
            // colConst1
            // 
            this.colConst1.Text = "Constant 1";
            this.colConst1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colConst1.Width = 100;
            // 
            // colConst2
            // 
            this.colConst2.Text = "Constant 2";
            this.colConst2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colConst2.Width = 100;
            // 
            // colConst3
            // 
            this.colConst3.Text = "Constant 3";
            this.colConst3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colConst3.Width = 100;
            // 
            // colConst4
            // 
            this.colConst4.Text = "Constant 4";
            this.colConst4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colConst4.Width = 100;
            // 
            // colPrecision
            // 
            this.colPrecision.Text = "Precision";
            this.colPrecision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colPrecision.Width = 80;
            // 
            // colSpecCheck
            // 
            this.colSpecCheck.Text = "Spec Check Type";
            this.colSpecCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSpecCheck.Width = 120;
            // 
            // colSpecOutCount
            // 
            this.colSpecOutCount.Text = "Spec Out Count";
            this.colSpecOutCount.Width = 100;
            // 
            // colGroup1
            // 
            this.colGroup1.Text = "Group 1";
            this.colGroup1.Width = 100;
            // 
            // colGroup2
            // 
            this.colGroup2.Text = "Group 2";
            this.colGroup2.Width = 100;
            // 
            // colGroup3
            // 
            this.colGroup3.Text = "Group 3";
            this.colGroup3.Width = 100;
            // 
            // colGroup4
            // 
            this.colGroup4.Text = "Group 4";
            this.colGroup4.Width = 100;
            // 
            // colGroup5
            // 
            this.colGroup5.Text = "Group 5";
            this.colGroup5.Width = 100;
            // 
            // colGroup6
            // 
            this.colGroup6.Text = "Group 6";
            this.colGroup6.Width = 100;
            // 
            // colGroup7
            // 
            this.colGroup7.Text = "Group 7";
            this.colGroup7.Width = 100;
            // 
            // colGroup8
            // 
            this.colGroup8.Text = "Group 8";
            this.colGroup8.Width = 100;
            // 
            // colGroup9
            // 
            this.colGroup9.Text = "Group 9";
            this.colGroup9.Width = 100;
            // 
            // colGroup10
            // 
            this.colGroup10.Text = "Group 10";
            this.colGroup10.Width = 100;
            // 
            // colCmf1
            // 
            this.colCmf1.Text = "Cmf 1";
            this.colCmf1.Width = 100;
            // 
            // colCmf2
            // 
            this.colCmf2.Text = "Cmf 2";
            this.colCmf2.Width = 100;
            // 
            // colCmf3
            // 
            this.colCmf3.Text = "Cmf 3";
            this.colCmf3.Width = 100;
            // 
            // colCmf4
            // 
            this.colCmf4.Text = "Cmf 4";
            this.colCmf4.Width = 100;
            // 
            // colCmf5
            // 
            this.colCmf5.Text = "Cmf 5";
            this.colCmf5.Width = 100;
            // 
            // colCmf6
            // 
            this.colCmf6.Text = "Cmf 6";
            this.colCmf6.Width = 100;
            // 
            // colCmf7
            // 
            this.colCmf7.Text = "Cmf 7";
            this.colCmf7.Width = 100;
            // 
            // colCmf8
            // 
            this.colCmf8.Text = "Cmf 8";
            this.colCmf8.Width = 100;
            // 
            // colCmf9
            // 
            this.colCmf9.Text = "Cmf 9";
            this.colCmf9.Width = 100;
            // 
            // colCmf10
            // 
            this.colCmf10.Text = "Cmf 10";
            this.colCmf10.Width = 100;
            // 
            // colEngineer
            // 
            this.colEngineer.Text = "Engineer";
            this.colEngineer.Width = 80;
            // 
            // colComment
            // 
            this.colComment.Text = "Comment";
            this.colComment.Width = 120;
            // 
            // colCreateUser
            // 
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 120;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Text = "Create Time";
            this.colCreateTime.Width = 120;
            // 
            // colUpdateUser
            // 
            this.colUpdateUser.Text = "Update User";
            this.colUpdateUser.Width = 100;
            // 
            // colUpdateTime
            // 
            this.colUpdateTime.Text = "Update Time";
            this.colUpdateTime.Width = 100;
            // 
            // cdvSubResource
            // 
            this.cdvSubResource.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubResource.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubResource.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubResource.BtnToolTipText = "";
            this.cdvSubResource.DescText = "";
            this.cdvSubResource.DisplaySubItemIndex = -1;
            this.cdvSubResource.DisplayText = "";
            this.cdvSubResource.Focusing = null;
            this.cdvSubResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubResource.Index = 0;
            this.cdvSubResource.IsViewBtnImage = false;
            this.cdvSubResource.Location = new System.Drawing.Point(427, 88);
            this.cdvSubResource.MaxLength = 20;
            this.cdvSubResource.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubResource.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubResource.Name = "cdvSubResource";
            this.cdvSubResource.ReadOnly = false;
            this.cdvSubResource.SearchSubItemIndex = 0;
            this.cdvSubResource.SelectedDescIndex = -1;
            this.cdvSubResource.SelectedSubItemIndex = -1;
            this.cdvSubResource.SelectionStart = 0;
            this.cdvSubResource.Size = new System.Drawing.Size(200, 20);
            this.cdvSubResource.SmallImageList = null;
            this.cdvSubResource.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubResource.TabIndex = 14;
            this.cdvSubResource.TextBoxToolTipText = "";
            this.cdvSubResource.TextBoxWidth = 200;
            this.cdvSubResource.VisibleButton = true;
            this.cdvSubResource.VisibleColumnHeader = false;
            this.cdvSubResource.VisibleDescription = false;
            this.cdvSubResource.ButtonPress += new System.EventHandler(this.cdvSubResource_ButtonPress);
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
            this.cdvChartSetID.Location = new System.Drawing.Point(110, 112);
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
            this.cdvChartSetID.TabIndex = 16;
            this.cdvChartSetID.TextBoxToolTipText = "";
            this.cdvChartSetID.TextBoxWidth = 200;
            this.cdvChartSetID.VisibleButton = true;
            this.cdvChartSetID.VisibleColumnHeader = false;
            this.cdvChartSetID.VisibleDescription = false;
            this.cdvChartSetID.ButtonPress += new System.EventHandler(this.cdvChartSetID_ButtonPress);
            // 
            // cdvPrompt
            // 
            this.cdvPrompt.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPrompt.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPrompt.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPrompt.BtnToolTipText = "";
            this.cdvPrompt.DescText = "";
            this.cdvPrompt.DisplaySubItemIndex = -1;
            this.cdvPrompt.DisplayText = "";
            this.cdvPrompt.Focusing = null;
            this.cdvPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPrompt.Index = 0;
            this.cdvPrompt.IsViewBtnImage = false;
            this.cdvPrompt.Location = new System.Drawing.Point(110, 136);
            this.cdvPrompt.MaxLength = 20;
            this.cdvPrompt.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrompt.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrompt.Name = "cdvPrompt";
            this.cdvPrompt.ReadOnly = true;
            this.cdvPrompt.SearchSubItemIndex = 0;
            this.cdvPrompt.SelectedDescIndex = -1;
            this.cdvPrompt.SelectedSubItemIndex = -1;
            this.cdvPrompt.SelectionStart = 0;
            this.cdvPrompt.Size = new System.Drawing.Size(200, 20);
            this.cdvPrompt.SmallImageList = null;
            this.cdvPrompt.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrompt.TabIndex = 20;
            this.cdvPrompt.TextBoxToolTipText = "";
            this.cdvPrompt.TextBoxWidth = 200;
            this.cdvPrompt.VisibleButton = true;
            this.cdvPrompt.VisibleColumnHeader = false;
            this.cdvPrompt.VisibleDescription = false;
            this.cdvPrompt.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvPrompt_SelectedItemChanged);
            this.cdvPrompt.ButtonPress += new System.EventHandler(this.cdvPrompt_ButtonPress);
            // 
            // cdvGroup
            // 
            this.cdvGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup.BtnToolTipText = "";
            this.cdvGroup.DescText = "";
            this.cdvGroup.DisplaySubItemIndex = -1;
            this.cdvGroup.DisplayText = "";
            this.cdvGroup.Focusing = null;
            this.cdvGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup.Index = 0;
            this.cdvGroup.IsViewBtnImage = false;
            this.cdvGroup.Location = new System.Drawing.Point(427, 136);
            this.cdvGroup.MaxLength = 20;
            this.cdvGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.Name = "cdvGroup";
            this.cdvGroup.ReadOnly = false;
            this.cdvGroup.SearchSubItemIndex = 0;
            this.cdvGroup.SelectedDescIndex = -1;
            this.cdvGroup.SelectedSubItemIndex = -1;
            this.cdvGroup.SelectionStart = 0;
            this.cdvGroup.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup.SmallImageList = null;
            this.cdvGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup.TabIndex = 22;
            this.cdvGroup.TextBoxToolTipText = "";
            this.cdvGroup.TextBoxWidth = 200;
            this.cdvGroup.VisibleButton = true;
            this.cdvGroup.VisibleColumnHeader = false;
            this.cdvGroup.VisibleDescription = false;
            this.cdvGroup.ButtonPress += new System.EventHandler(this.cdvGroup_ButtonPress);
            // 
            // cdvCharID
            // 
            this.cdvCharID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCharID.BtnToolTipText = "";
            this.cdvCharID.DescText = "";
            this.cdvCharID.DisplaySubItemIndex = -1;
            this.cdvCharID.DisplayText = "";
            this.cdvCharID.Focusing = null;
            this.cdvCharID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCharID.Index = 0;
            this.cdvCharID.IsViewBtnImage = false;
            this.cdvCharID.Location = new System.Drawing.Point(110, 88);
            this.cdvCharID.MaxLength = 25;
            this.cdvCharID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCharID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCharID.Name = "cdvCharID";
            this.cdvCharID.ReadOnly = false;
            this.cdvCharID.SearchSubItemIndex = 0;
            this.cdvCharID.SelectedDescIndex = -1;
            this.cdvCharID.SelectedSubItemIndex = -1;
            this.cdvCharID.SelectionStart = 0;
            this.cdvCharID.Size = new System.Drawing.Size(200, 20);
            this.cdvCharID.SmallImageList = null;
            this.cdvCharID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCharID.TabIndex = 12;
            this.cdvCharID.TextBoxToolTipText = "";
            this.cdvCharID.TextBoxWidth = 200;
            this.cdvCharID.VisibleButton = true;
            this.cdvCharID.VisibleColumnHeader = false;
            this.cdvCharID.VisibleDescription = false;
            this.cdvCharID.ButtonPress += new System.EventHandler(this.cdvCharID_ButtonPress);
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
            this.cdvResID.Location = new System.Drawing.Point(427, 64);
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
            this.cdvResID.TabIndex = 10;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
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
            this.cdvOper.Location = new System.Drawing.Point(110, 64);
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
            this.cdvOper.TabIndex = 8;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 200;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            this.cdvOper.TextBoxTextChanged += new System.EventHandler(this.cdvOper_TextBoxTextChanged);
            // 
            // cdvFlow
            // 
            this.cdvFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFlow.BtnToolTipText = "";
            this.cdvFlow.DescText = "";
            this.cdvFlow.DisplaySubItemIndex = -1;
            this.cdvFlow.DisplayText = "";
            this.cdvFlow.Focusing = null;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.Index = 0;
            this.cdvFlow.IsViewBtnImage = false;
            this.cdvFlow.Location = new System.Drawing.Point(427, 40);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(200, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 6;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 200;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            this.cdvFlow.TextBoxTextChanged += new System.EventHandler(this.cdvFlow_TextBoxTextChanged);
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = true;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(8, 40);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(302, 20);
            this.cdvMaterial.TabIndex = 4;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 102;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_MaterialSelectedItemChanged);
            this.cdvMaterial.MaterialTextChanged += new System.EventHandler(this.cdvMaterial_MaterialTextBoxTextChanged);
            this.cdvMaterial.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_VersionSelectedItemChanged);
            this.cdvMaterial.VersionChanged += new System.EventHandler(this.cdvMaterial_VersionTextBoxTextChanged);
            // 
            // frmSPCViewChartList
            // 
            this.AcceptButton = this.btnView;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCViewChartList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "View Chart List";
            this.Activated += new System.EventHandler(this.frmSPCViewChartList_Activated);
            this.Closed += new System.EventHandler(this.frmSPCViewChartList_Closed);
            this.Load += new System.EventHandler(this.frmSPCViewChartList_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmSPCViewChartList_KeyUp);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUseUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLotorRes)).EndInit();
            this.pnlMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrompt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        private string[] sGroupTableName = new string[10];
        private bool b_load_flag = false;
        private ArrayList aMenuList = null;
        #endregion
        
        #region " Function Definition "
        
        // SetTableName()
        //       - Set Operation Group Table Name
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void SetTableName()
        {
            
            try
            {
                sGroupTableName[0] = MPGC.MP_GCM_CHT_GRP_1;
                sGroupTableName[1] = MPGC.MP_GCM_CHT_GRP_2;
                sGroupTableName[2] = MPGC.MP_GCM_CHT_GRP_3;
                sGroupTableName[3] = MPGC.MP_GCM_CHT_GRP_4;
                sGroupTableName[4] = MPGC.MP_GCM_CHT_GRP_5;
                sGroupTableName[5] = MPGC.MP_GCM_CHT_GRP_6;
                sGroupTableName[6] = MPGC.MP_GCM_CHT_GRP_7;
                sGroupTableName[7] = MPGC.MP_GCM_CHT_GRP_8;
                sGroupTableName[8] = MPGC.MP_GCM_CHT_GRP_9;
                sGroupTableName[9] = MPGC.MP_GCM_CHT_GRP_10;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.SetTableName()\n" + ex.Message);
            }
            
        }
        
        // SetOperGroupPrompt()
        //       - Set Group Property to control
        // Return Value
        //       -
        // Arguments
        //        - ByVal cdvList As Miracom.UI.Controls.MCCodeView.MCCodeView
        //
        private bool SetGroupPrompt(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ListViewItem itmx = null;
            int i;

            try
            {
                cdvPrompt.Init();
                MPCF.InitListView(cdvPrompt.GetListView);
                cdvPrompt.Columns.Add("Group", 100, HorizontalAlignment.Left);
                cdvPrompt.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvPrompt.SelectedSubItemIndex = 1;
                cdvPrompt.DisplaySubItemIndex = 0;
                cdvPrompt.ReadOnly = true;

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_CHART, ref out_node, "", true) == false)
                {
                    return false;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        itmx = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")), (int)SMALLICON_INDEX.IDX_CODE_DATA);

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")) == "")
                        {
                            itmx.SubItems.Add(sGroupTableName[i]);
                        }
                        else
                        {
                            itmx.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")));
                        }
                        cdvPrompt.Items.Add(itmx);
                    }
                }
                cdvPrompt.AddEmptyRow(1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.SetOperGroupPrompt()\n" + ex.Message);
                return false;
            }

            return true;
        }
        
        // CheckAvailableFunction()
        //       - Check Available Function
        // Return Value
        //       - Boolean : True of False
        // Arguments
        //       - ByVal FuncName As String
        //
        private bool ViewAvailableFunction()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Function_List_In");
                TRSNode out_node;
                int i;
                ArrayList a_list = new ArrayList();
                aMenuList = new ArrayList();
                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("PROGRAM_ID", MPGV.gsProgramID);
                in_node.AddString("SEC_GRP_ID", MPGV.gsUserGroup);
                in_node.AddString("NEXT_FUNC_NAME", "");

                
                do
                {
                    out_node = new TRSNode("View_Function_List_Out");
                    if (MPCR.CallService("SEC", "SEC_View_Function_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    a_list.Add(out_node);
                    
                    in_node.SetString("NEXT_FUNC_NAME", out_node.GetString("NEXT_FUNC_NAME"));

                } while (in_node.GetString("NEXT_FUNC_NAME") != "");
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        aMenuList.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("FUNC_NAME")));
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.ViewAvailableFunction()\n" + ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        // GetSubMenu()
        //       - initial CodeView Control
        // Return Value
        //       -
        // Arguments
        //        -
        private void GetSubMenu()
        {
            bool bSetupFlag = false;
            bool bTranFlag = false;
            bool bInquiryFlag = false;
            bool bAnalysisFlag = false;
            MenuItem mnuTmp;
            
            try
            {
                if (ViewAvailableFunction() == false)
                {
                    return;
                }
                
                ctxMenu.MenuItems.Clear();
                if (aMenuList.IndexOf("SPC1002") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("Chart Setup", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC1002"; ctxMenu.MenuItems.Add(mnuTmp);
                    bSetupFlag = true;
                }
                if (aMenuList.IndexOf("SPC1003") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("Spec Management", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC1003"; ctxMenu.MenuItems.Add(mnuTmp);
                    bSetupFlag = true;
                }
                if (aMenuList.IndexOf("SPC1008") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("EDC Data Prompt Setup", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC1008"; ctxMenu.MenuItems.Add(mnuTmp);
                    bSetupFlag = true;
                }
                
                if (bSetupFlag == true)
                {
                    ctxMenu.MenuItems.Add("-");
                }
                
                if (aMenuList.IndexOf("SPC5001") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("Change EDC Data", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC5001"; ctxMenu.MenuItems.Add(mnuTmp);
                    bTranFlag = true;
                }
                if (aMenuList.IndexOf("SPC2003") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("Clear SPC Alarm", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC2003"; ctxMenu.MenuItems.Add(mnuTmp);
                    bTranFlag = true;
                }
                if (bTranFlag == true)
                {
                    ctxMenu.MenuItems.Add("-");
                }
                
                if (aMenuList.IndexOf("SPC3001") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("Realtime Monitoring Control Chart", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC3001"; ctxMenu.MenuItems.Add(mnuTmp);
                    bAnalysisFlag = true;
                }
                if (aMenuList.IndexOf("SPC3003") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("Control Chart", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC3003"; ctxMenu.MenuItems.Add(mnuTmp);
                    bAnalysisFlag = true;
                }
                if (aMenuList.IndexOf("SPC3004") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("Capability Analysis", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC3004"; ctxMenu.MenuItems.Add(mnuTmp);
                    bAnalysisFlag = true;
                }
                if (bAnalysisFlag == true)
                {
                    ctxMenu.MenuItems.Add("-");
                }
                
                if (aMenuList.IndexOf("SPC4001") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("View EDC Data", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC4001"; ctxMenu.MenuItems.Add(mnuTmp);
                    bInquiryFlag = true;
                }
                if (aMenuList.IndexOf("SPC4002") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("View Spec History", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC4002"; ctxMenu.MenuItems.Add(mnuTmp);
                    bInquiryFlag = true;
                }
                if (aMenuList.IndexOf("SPC4003") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("View OOC History", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC4003"; ctxMenu.MenuItems.Add(mnuTmp);
                    bInquiryFlag = true;
                }
                if (aMenuList.IndexOf("SPC4004") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("View Process Capability", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC4004"; ctxMenu.MenuItems.Add(mnuTmp);
                    bInquiryFlag = true;
                }
                if (aMenuList.IndexOf("SPC4005") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("View SPC Alarm History", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC4005"; ctxMenu.MenuItems.Add(mnuTmp);
                    bInquiryFlag = true;
                }
                if (aMenuList.IndexOf("SPC4008") >= 0)
                {
                    mnuTmp = new MenuItem(MPCF.FindLanguage("View Excluded EDC History", 2), new EventHandler(subMenu_Click));
                    mnuTmp.Tag = "SPC4008"; ctxMenu.MenuItems.Add(mnuTmp);
                    bInquiryFlag = true;
                }
                
                if (bInquiryFlag == false)
                {
                    if (ctxMenu.MenuItems[ctxMenu.MenuItems.Count - 1].Text == "-")
                    {
                        ctxMenu.MenuItems.RemoveAt(ctxMenu.MenuItems.Count - 1);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.GetSubMenu()\n" + ex.Message);
            }
            
        }
        
        // SetForm()
        //       -
        // Return Value
        //       -
        // Arguments
        //        -
        public void SetForm(int iWidth, int iHeight)
        {
            
            try
            {
                if (this.Width + 4 > iWidth)
                {
                    this.Left = 0;
                    this.Width = iWidth - 4;
                }
                if (this.Height + 4 > iHeight)
                {
                    this.Top = 0;
                    this.Height = iHeight - 4;
                }
                if (b_load_flag == false)
                {
                    this.Top = 0;
                    this.Left = 0;
                    this.Width = iWidth - 4;
                    this.Height = iHeight - 4;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.SetForm()\n" + ex.Message);
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvMaterial;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.GetFisrtFocusItem()\n" + ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmSPCViewChartList_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
            try
            {
                if (!(this.ActiveControl == null))
                {
                    if (this.ActiveControl is TextBox)
                    {
                        if (e.KeyValue != 13 && e.KeyValue != 8 || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                        {
                            if (MPCF.CheckMaxLength(this.ActiveControl, 0) == false)
                            {
                                e.Handled = true;
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.frmSPCViewChartList_Load()\n" + ex.Message);
            }
            
        }
        
        private void subMenu_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                string s_func_name;

                if (((MenuItem)sender).Tag == null) return;
                if (MPCF.Trim(((MenuItem)sender).Tag) == "") return;

                s_func_name = MPCF.Trim(((MenuItem)sender).Tag);
                MPGV.gIMdiForm.ActiveMenu(s_func_name);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.subMenu_Click()\n" + ex.Message);
            }
            
        }
        
        private void lisChart_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    if (lisChart.SelectedItems.Count > 0)
                    {
                        ctxMenu.Show(lisChart, new Point(e.X, e.Y));
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.frmSPCViewChartList_Load()\n" + ex.Message);
            }
            
        }
        
        private void lisChart_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            try
            {
                MPGV.gsChartID = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.frmSPCViewChartList_Load()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCViewChartList_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                if (this.Modal == false)
                {
                    MPCR.CheckSecurityFormControl(this);
                }
                
                MPCF.ToClientLanguage(this);
                MPCF.InitListView(lisChart);
                MPCF.SetTextboxStyle(this.Controls);
                modSPCFunctions.SetGraphList(cboGraphType);
                cboGraphType.Items.Add("");
                cboGraphType.SelectedIndex = 9;
                cboUseUnit.SelectedIndex = 0;
                
                SetTableName();
                GetSubMenu();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.frmSPCViewChartList_Load()\n" + ex.Message);
            }
            
        }
        
        
        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvFlow.Init();
                MPCF.InitListView(cdvFlow.GetListView);
                cdvFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvFlow.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvFlow.SelectedSubItemIndex = 0;
                if (MPCF.Trim(cdvMaterial.Text) == "")
                {
                    if (WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "",0, "", null, "") == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (WIPLIST.ViewFlowList(cdvFlow.GetListView, '2', cdvMaterial.Text, cdvMaterial.Version, "", null, "") == false)
                    {
                        return;
                    }
                }
                
                cdvFlow.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvFlow_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvOper_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvOper.Init();
                MPCF.InitListView(cdvOper.GetListView);
                cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvOper.SelectedSubItemIndex = 0;
                if (cdvMaterial.Text != "" && cdvFlow.Text != "")
                {
                    if (WIPLIST.ViewOperationList(cdvOper.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "") == false)
                    {
                        return;
                    }
                }
                else if (cdvMaterial.Text == "" && cdvFlow.Text != "")
                {
                    if (WIPLIST.ViewOperationList(cdvOper.GetListView, '2', "", 0,cdvFlow.Text, "", null, "") == false)
                    {
                        return;
                    }
                }
                else if (cdvMaterial.Text != "" && cdvFlow.Text == "")
                {
                    if (WIPLIST.ViewOperationList(cdvOper.GetListView, '3', cdvMaterial.Text, cdvMaterial.Version, "", "", null, "") == false)
                    {
                        return;
                    }
                }
                else if (cdvMaterial.Text == "" && cdvFlow.Text == "")
                {
                    if (WIPLIST.ViewOperationList(cdvOper.GetListView, '1', "", 0,"", "", null, "") == false)
                    {
                        return;
                    }
                }
                cdvOper.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvOper_ButtonPress()\n" + ex.Message);
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
                if (cdvOper.Text == "")
                {
                    if (RASLIST.ViewResourceList(cdvResID.GetListView, false) == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (RASLIST.ViewResourceList(cdvResID.GetListView, MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, MPCF.Trim(cdvFlow.Text), MPCF.Trim(cdvOper.Text), false) == false)
                    {
                        return;
                    }
                }
                cdvResID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvResID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvCharID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvCharID.Init();
                MPCF.InitListView(cdvCharID.GetListView);
                cdvCharID.Columns.Add("CharID", 50, HorizontalAlignment.Left);
                cdvCharID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCharID.SelectedSubItemIndex = 0;
                if (EDCLIST.ViewEDCCharacterList(cdvCharID.GetListView, '2', 'E') == false)
                {
                    return;
                }
                cdvCharID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvCharID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        
        private void cdvOper_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                cdvResID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvOper_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        
        private void cdvOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvResID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvOper_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvFlow_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                cdvOper.Text = "";
                cdvResID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvFlow_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvFlow_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvOper.Text = "";
                cdvResID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvFlow_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvPrompt_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                SetGroupPrompt((Miracom.UI.Controls.MCCodeView.MCCodeView)sender);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvPrompt_ButtonPress()\n" + ex.Message);
            }
        }
        
        private void cdvGroup_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                if (cdvPrompt.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvPrompt.Focus();
                    cdvGroup.IsPopup = false;
                    return;
                }
                
                cdvGroup.Init();
                MPCF.InitListView(cdvGroup.GetListView);
                cdvGroup.Columns.Add("Group", 50, HorizontalAlignment.Left);
                cdvGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvGroup.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvGroup.GetListView, '1', cdvPrompt.Text) == false)
                {
                    return;
                }
                cdvGroup.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvGroup_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void lisChart_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
            try
            {
                if (e.Control == true && e.KeyValue == 'C')
                {
                    ListView lisList;
                    lisList = (ListView) sender;
                    if (lisList.SelectedItems.Count == 0)
                    {
                        Clipboard.SetDataObject("", true);
                    }
                    else
                    {
                        Clipboard.SetDataObject(lisList.SelectedItems[0].SubItems[1].Text, true);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.lisChart_KeyDown()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (this.Modal == true)
                {
                    //this.Dispose(false);
                }
                else
                {
                    this.Dispose();
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                char sLotRes;
                string sGraphType;
                char sUnitUse;
                  
                if (cboLotorRes.SelectedIndex == 1)
                {
                    sLotRes = 'L';
                }
                else if (cboLotorRes.SelectedIndex == 2)
                {
                    sLotRes = 'R';
                }
                else
                {
                    sLotRes = ' ';
                }
                sGraphType = Enum.GetName(typeof(eGraphType), cboGraphType.SelectedIndex);
                if (cboUseUnit.SelectedIndex == 2)
                {
                    sUnitUse = 'N';
                }
                else if (cboUseUnit.SelectedIndex == 1)
                {
                    sUnitUse = 'Y';
                }
                else
                {
                    sUnitUse = ' ';
                }
                
            
                SPCLIST.ViewChartListDetail(lisChart, '1', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOper.Text, cdvResID.Text, cdvSubResource.Text,
                    cdvCharID.Text, sLotRes, sGraphType, sUnitUse, ' ', cdvGroup.Text, cdvPrompt.Text, cdvChartSetID.Text, "", ' ', -1, -1, null, "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                btnView.PerformClick();
                GetSubMenu();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCViewChartList_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.frmSPCViewChartList_Activated()\n" + ex.Message);
            }
            
        }
        
        private void lisChart_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisChart.SelectedItems.Count > 0)
                {
                    MPGV.gsChartID = "";
                    MPGV.gsChartID = lisChart.FocusedItem.SubItems[1].Text;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.lisChart_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCViewChartList_Closed(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gsChartID = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.frmSPCViewChartList_Closed()\n" + ex.Message);
            }
            
        }
        
        private void cboValueType_SelectionChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvCharID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cboValueType_SelectionChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnCopyImage_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisChart.SelectedItems.Count == 0)
                {
                    Clipboard.SetDataObject("", true);
                }
                else
                {
                    Clipboard.SetDataObject(lisChart.SelectedItems[0].SubItems[1].Text, true);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.lisChart_KeyDown()\n" + ex.Message);
            }
            
        }
        
        private void btnSelect_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisChart.SelectedItems.Count > 0)
                {
                    MPGV.gsChartID = "";
                    MPGV.gsChartID = lisChart.FocusedItem.SubItems[1].Text;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.lisChart_KeyDown()\n" + ex.Message);
            }
            
        }
        
        private void cdvPrompt_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvGroup.DisplayText = "";
            cdvGroup.Text = "";
        }
        
        private void cdvChartSetID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvChartSetID.Init();
                MPCF.InitListView(cdvChartSetID.GetListView);
                cdvChartSetID.Columns.Add("ChartSet", 50, HorizontalAlignment.Left);
                cdvChartSetID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartSetID.SelectedSubItemIndex = 0;
                if (SPCLIST.ViewChartSetList(cdvChartSetID.GetListView, '1', "", 0, "", "", ' ', "", -1, -1, "") == false)
                {
                    return;
                }
                cdvChartSetID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvChartSetID_ButtonPress()\n" + ex.Message);
            }
            
        }

        private void cdvMaterial_MaterialSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                cdvFlow.Text = "";
                cdvOper.Text = "";
                cdvResID.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvMaterial_MaterialSelectedItemChanged()\n" + ex.Message);
            }
        }

        private void cdvMaterial_MaterialTextBoxTextChanged(object sender, EventArgs e)
        {
            try
            {
                cdvFlow.Text = "";
                cdvOper.Text = "";
                cdvResID.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvMaterial_MaterialTextBoxTextChanged()\n" + ex.Message);
            }
        }

        private void cdvMaterial_VersionSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                cdvFlow.Text = "";
                cdvOper.Text = "";
                cdvResID.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvMaterial_VersionSelectedItemChanged()\n" + ex.Message);
            }
        }

        private void cdvMaterial_VersionTextBoxTextChanged(object sender, EventArgs e)
        {
            try
            {
                cdvFlow.Text = "";
                cdvOper.Text = "";
                cdvResID.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewChartList.cdvMaterial_VersionTextBoxTextChanged()\n" + ex.Message);
            }
        }

        private void cdvSubResource_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvResID.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvResID.Focus();
                return;
            }
            cdvSubResource.Init();
            MPCF.InitListView(cdvSubResource.GetListView);
            cdvSubResource.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvSubResource.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSubResource.SelectedSubItemIndex = 0;

            RASLIST.ViewSubResourceList(cdvSubResource.GetListView, '5', cdvResID.Text);
        }

        private void cdvResID_TextBoxTextChanged(object sender, EventArgs e)
        {
            cdvSubResource.Text = "";
        }

          }
    //#End If
    
}
