
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
//   File Name   : frmRASSetupCarrier.vb
//   Description : Carrier Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData : Intialize Form Field
//       - CheckCondition : Check the conditions before transaction
//       - Update_Carrier : Create/Update/Delete Carrier
//       - View_Carrier_List :View Carrier list
//       - View_Carrier : View Carrier Information
//
//   Detail Description
//       - Update_Carrier
//         ProcStep="C" - Create New Carrier
//         ProcStep="U" - Update Carrier
//         ProcStep="D" - Delete Carrier
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-06-22 : Created by GI Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _CRR = True Then

namespace Miracom.RASCore
{
    public class frmRASSetupCarrier : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupCarrier()
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
        



        private System.Windows.Forms.GroupBox grpCarrier;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblCarrier;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.TabControl tabCarrier;
        private System.Windows.Forms.TextBox txtCarrierID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrType3;
        private System.Windows.Forms.Label lblCrrType3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrType2;
        private System.Windows.Forms.Label lblCrrType2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrType1;
        private System.Windows.Forms.Label lblCrrType1;
        private System.Windows.Forms.Label lblUsageLimit;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Label lblPlanTermTime;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResourceID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubAreaID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAreaID;
        private System.Windows.Forms.Label lblSubAreaID;
        private System.Windows.Forms.Label lblAreaID;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private Miracom.UI.Controls.MCListView.MCListView lisCarrier;
        private System.Windows.Forms.ColumnHeader colCarrier;
        private GroupBox grpCMF;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        protected Label lblCMF10;
        protected Label lblCMF9;
        protected Label lblCMF8;
        protected Label lblCMF7;
        protected Label lblCMF6;
        protected Label lblCMF5;
        protected Label lblCMF4;
        protected Label lblCMF3;
        protected Label lblCMF2;
        protected Label lblCMF1;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF19;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF18;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF17;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF16;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF15;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF14;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF13;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF12;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF20;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF11;
        protected Label lblCMF20;
        protected Label lblCMF19;
        protected Label lblCMF18;
        protected Label lblCMF17;
        protected Label lblCMF16;
        protected Label lblCMF15;
        protected Label lblCMF14;
        protected Label lblCMF13;
        protected Label lblCMF12;
        protected Label lblCMF11;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrGroup;
        private Label lblCarrierGroup;
        private Label lblLastClean;
        private TextBox txtLastCleanTime;
        private Label lblCleanLimit;
        private Label lblUsageLimitTime;
        private TextBox txtElapse;
        private DateTimePicker dtpPlanTermTime;
        private DateTimePicker dtpPlanTermDate;
        private Label lblStatus;
        private TextBox txtStatus;
        private NumericUpDown numCleanLimitCount;
        private NumericUpDown numUsageLimitTime;
        private NumericUpDown numUsageLimitCount;
        private NumericUpDown numCarrierSize;
        private TextBox txtCleanCount;
        private TextBox txtUsageCount;
        private CheckBox chkPlanTerminate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup;
        private Label lblGroup;
        private UI.Controls.MCCodeView.MCCodeView cdvUsageLimitAlarm;
        private Label lblUsageLimitAlarm;
        private Label lblCleanLimitAlarm;
        private UI.Controls.MCCodeView.MCCodeView cdvCleanLimitAlarm;
        private System.Windows.Forms.ColumnHeader colCarrierDesc;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpCarrier = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblCarrier = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtCarrierID = new System.Windows.Forms.TextBox();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.lblCleanLimitAlarm = new System.Windows.Forms.Label();
            this.cdvCleanLimitAlarm = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUsageLimitAlarm = new System.Windows.Forms.Label();
            this.cdvUsageLimitAlarm = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkPlanTerminate = new System.Windows.Forms.CheckBox();
            this.txtCleanCount = new System.Windows.Forms.TextBox();
            this.txtUsageCount = new System.Windows.Forms.TextBox();
            this.numCleanLimitCount = new System.Windows.Forms.NumericUpDown();
            this.numUsageLimitTime = new System.Windows.Forms.NumericUpDown();
            this.numUsageLimitCount = new System.Windows.Forms.NumericUpDown();
            this.numCarrierSize = new System.Windows.Forms.NumericUpDown();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.dtpPlanTermTime = new System.Windows.Forms.DateTimePicker();
            this.dtpPlanTermDate = new System.Windows.Forms.DateTimePicker();
            this.txtElapse = new System.Windows.Forms.TextBox();
            this.lblUsageLimitTime = new System.Windows.Forms.Label();
            this.lblLastClean = new System.Windows.Forms.Label();
            this.txtLastCleanTime = new System.Windows.Forms.TextBox();
            this.lblCleanLimit = new System.Windows.Forms.Label();
            this.cdvCrrGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCarrierGroup = new System.Windows.Forms.Label();
            this.cdvSubAreaID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAreaID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubAreaID = new System.Windows.Forms.Label();
            this.lblAreaID = new System.Windows.Forms.Label();
            this.cdvCrrType3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrType3 = new System.Windows.Forms.Label();
            this.cdvCrrType2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrType2 = new System.Windows.Forms.Label();
            this.lblUsageLimit = new System.Windows.Forms.Label();
            this.cdvCrrType1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.cdvResourceID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblCrrType1 = new System.Windows.Forms.Label();
            this.lblPlanTermTime = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvCMF19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
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
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
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
            this.tabCarrier = new System.Windows.Forms.TabControl();
            this.lisCarrier = new Miracom.UI.Controls.MCListView.MCListView();
            this.colCarrier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCarrierDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdvGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpCarrier.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCleanLimitAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUsageLimitAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCleanLimitCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimitTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimitCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCarrierSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResourceID)).BeginInit();
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
            this.tabCarrier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 5;
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
            this.splMain.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tabCarrier);
            this.pnlRight.Controls.Add(this.grpCarrier);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            this.pnlRight.TabIndex = 2;
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
            this.pnlLeft.Size = new System.Drawing.Size(232, 449);
            this.pnlLeft.TabIndex = 1;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(26, 37);
            this.txtFilter.TabIndex = 3;
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
            this.pnlBottom.TabIndex = 3;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "BaseForm02";
            // 
            // grpCarrier
            // 
            this.grpCarrier.Controls.Add(this.lblDesc);
            this.grpCarrier.Controls.Add(this.lblCarrier);
            this.grpCarrier.Controls.Add(this.txtDesc);
            this.grpCarrier.Controls.Add(this.txtCarrierID);
            this.grpCarrier.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCarrier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCarrier.Location = new System.Drawing.Point(0, 0);
            this.grpCarrier.Name = "grpCarrier";
            this.grpCarrier.Size = new System.Drawing.Size(506, 70);
            this.grpCarrier.TabIndex = 3;
            this.grpCarrier.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // lblCarrier
            // 
            this.lblCarrier.AutoSize = true;
            this.lblCarrier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrier.Location = new System.Drawing.Point(15, 19);
            this.lblCarrier.Name = "lblCarrier";
            this.lblCarrier.Size = new System.Drawing.Size(61, 13);
            this.lblCarrier.TabIndex = 0;
            this.lblCarrier.Text = "Carrier ID";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(163, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(327, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // txtCarrierID
            // 
            this.txtCarrierID.Location = new System.Drawing.Point(163, 16);
            this.txtCarrierID.MaxLength = 20;
            this.txtCarrierID.Name = "txtCarrierID";
            this.txtCarrierID.Size = new System.Drawing.Size(133, 20);
            this.txtCarrierID.TabIndex = 1;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(498, 417);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.lblCleanLimitAlarm);
            this.grpGeneral.Controls.Add(this.cdvCleanLimitAlarm);
            this.grpGeneral.Controls.Add(this.lblUsageLimitAlarm);
            this.grpGeneral.Controls.Add(this.cdvUsageLimitAlarm);
            this.grpGeneral.Controls.Add(this.chkPlanTerminate);
            this.grpGeneral.Controls.Add(this.txtCleanCount);
            this.grpGeneral.Controls.Add(this.txtUsageCount);
            this.grpGeneral.Controls.Add(this.numCleanLimitCount);
            this.grpGeneral.Controls.Add(this.numUsageLimitTime);
            this.grpGeneral.Controls.Add(this.numUsageLimitCount);
            this.grpGeneral.Controls.Add(this.numCarrierSize);
            this.grpGeneral.Controls.Add(this.lblStatus);
            this.grpGeneral.Controls.Add(this.txtStatus);
            this.grpGeneral.Controls.Add(this.dtpPlanTermTime);
            this.grpGeneral.Controls.Add(this.dtpPlanTermDate);
            this.grpGeneral.Controls.Add(this.txtElapse);
            this.grpGeneral.Controls.Add(this.lblUsageLimitTime);
            this.grpGeneral.Controls.Add(this.lblLastClean);
            this.grpGeneral.Controls.Add(this.txtLastCleanTime);
            this.grpGeneral.Controls.Add(this.lblCleanLimit);
            this.grpGeneral.Controls.Add(this.cdvCrrGroup);
            this.grpGeneral.Controls.Add(this.lblCarrierGroup);
            this.grpGeneral.Controls.Add(this.cdvSubAreaID);
            this.grpGeneral.Controls.Add(this.cdvAreaID);
            this.grpGeneral.Controls.Add(this.lblSubAreaID);
            this.grpGeneral.Controls.Add(this.lblAreaID);
            this.grpGeneral.Controls.Add(this.cdvCrrType3);
            this.grpGeneral.Controls.Add(this.lblCrrType3);
            this.grpGeneral.Controls.Add(this.cdvCrrType2);
            this.grpGeneral.Controls.Add(this.lblCrrType2);
            this.grpGeneral.Controls.Add(this.lblUsageLimit);
            this.grpGeneral.Controls.Add(this.cdvCrrType1);
            this.grpGeneral.Controls.Add(this.lblSize);
            this.grpGeneral.Controls.Add(this.lblUpdateUser);
            this.grpGeneral.Controls.Add(this.lblCreateUser);
            this.grpGeneral.Controls.Add(this.txtUpdateTime);
            this.grpGeneral.Controls.Add(this.txtCreateTime);
            this.grpGeneral.Controls.Add(this.txtUpdateUser);
            this.grpGeneral.Controls.Add(this.txtCreateUser);
            this.grpGeneral.Controls.Add(this.cdvResourceID);
            this.grpGeneral.Controls.Add(this.lblResID);
            this.grpGeneral.Controls.Add(this.lblCrrType1);
            this.grpGeneral.Controls.Add(this.lblPlanTermTime);
            this.grpGeneral.Controls.Add(this.lblLocation);
            this.grpGeneral.Controls.Add(this.txtLocation);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(492, 414);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // lblCleanLimitAlarm
            // 
            this.lblCleanLimitAlarm.AutoSize = true;
            this.lblCleanLimitAlarm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCleanLimitAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCleanLimitAlarm.Location = new System.Drawing.Point(11, 306);
            this.lblCleanLimitAlarm.Name = "lblCleanLimitAlarm";
            this.lblCleanLimitAlarm.Size = new System.Drawing.Size(87, 13);
            this.lblCleanLimitAlarm.TabIndex = 44;
            this.lblCleanLimitAlarm.Text = "Clean Limit Alarm";
            // 
            // cdvCleanLimitAlarm
            // 
            this.cdvCleanLimitAlarm.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCleanLimitAlarm.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCleanLimitAlarm.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCleanLimitAlarm.BtnToolTipText = "";
            this.cdvCleanLimitAlarm.DescText = "";
            this.cdvCleanLimitAlarm.DisplaySubItemIndex = 0;
            this.cdvCleanLimitAlarm.DisplayText = "";
            this.cdvCleanLimitAlarm.Focusing = null;
            this.cdvCleanLimitAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCleanLimitAlarm.Index = 0;
            this.cdvCleanLimitAlarm.IsViewBtnImage = false;
            this.cdvCleanLimitAlarm.Location = new System.Drawing.Point(156, 302);
            this.cdvCleanLimitAlarm.MaxLength = 32767;
            this.cdvCleanLimitAlarm.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCleanLimitAlarm.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCleanLimitAlarm.Name = "cdvCleanLimitAlarm";
            this.cdvCleanLimitAlarm.ReadOnly = false;
            this.cdvCleanLimitAlarm.SearchSubItemIndex = 0;
            this.cdvCleanLimitAlarm.SelectedDescIndex = 1;
            this.cdvCleanLimitAlarm.SelectedSubItemIndex = 0;
            this.cdvCleanLimitAlarm.SelectionStart = 0;
            this.cdvCleanLimitAlarm.Size = new System.Drawing.Size(277, 20);
            this.cdvCleanLimitAlarm.SmallImageList = null;
            this.cdvCleanLimitAlarm.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCleanLimitAlarm.TabIndex = 43;
            this.cdvCleanLimitAlarm.TextBoxToolTipText = "";
            this.cdvCleanLimitAlarm.TextBoxWidth = 133;
            this.cdvCleanLimitAlarm.VisibleButton = true;
            this.cdvCleanLimitAlarm.VisibleColumnHeader = false;
            this.cdvCleanLimitAlarm.VisibleDescription = true;
            this.cdvCleanLimitAlarm.ButtonPress += new System.EventHandler(this.cdvCleanLimitAlarm_ButtonPress);
            // 
            // lblUsageLimitAlarm
            // 
            this.lblUsageLimitAlarm.AutoSize = true;
            this.lblUsageLimitAlarm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUsageLimitAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsageLimitAlarm.Location = new System.Drawing.Point(11, 258);
            this.lblUsageLimitAlarm.Name = "lblUsageLimitAlarm";
            this.lblUsageLimitAlarm.Size = new System.Drawing.Size(91, 13);
            this.lblUsageLimitAlarm.TabIndex = 42;
            this.lblUsageLimitAlarm.Text = "Usage Limit Alarm";
            // 
            // cdvUsageLimitAlarm
            // 
            this.cdvUsageLimitAlarm.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUsageLimitAlarm.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUsageLimitAlarm.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUsageLimitAlarm.BtnToolTipText = "";
            this.cdvUsageLimitAlarm.DescText = "";
            this.cdvUsageLimitAlarm.DisplaySubItemIndex = 0;
            this.cdvUsageLimitAlarm.DisplayText = "";
            this.cdvUsageLimitAlarm.Focusing = null;
            this.cdvUsageLimitAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUsageLimitAlarm.Index = 0;
            this.cdvUsageLimitAlarm.IsViewBtnImage = false;
            this.cdvUsageLimitAlarm.Location = new System.Drawing.Point(156, 254);
            this.cdvUsageLimitAlarm.MaxLength = 32767;
            this.cdvUsageLimitAlarm.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUsageLimitAlarm.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUsageLimitAlarm.Name = "cdvUsageLimitAlarm";
            this.cdvUsageLimitAlarm.ReadOnly = false;
            this.cdvUsageLimitAlarm.SearchSubItemIndex = 0;
            this.cdvUsageLimitAlarm.SelectedDescIndex = 1;
            this.cdvUsageLimitAlarm.SelectedSubItemIndex = 0;
            this.cdvUsageLimitAlarm.SelectionStart = 0;
            this.cdvUsageLimitAlarm.Size = new System.Drawing.Size(277, 20);
            this.cdvUsageLimitAlarm.SmallImageList = null;
            this.cdvUsageLimitAlarm.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUsageLimitAlarm.TabIndex = 41;
            this.cdvUsageLimitAlarm.TextBoxToolTipText = "";
            this.cdvUsageLimitAlarm.TextBoxWidth = 133;
            this.cdvUsageLimitAlarm.VisibleButton = true;
            this.cdvUsageLimitAlarm.VisibleColumnHeader = false;
            this.cdvUsageLimitAlarm.VisibleDescription = true;
            this.cdvUsageLimitAlarm.ButtonPress += new System.EventHandler(this.cdvUsageLimitAlarm_ButtonPress);
            // 
            // chkPlanTerminate
            // 
            this.chkPlanTerminate.AutoSize = true;
            this.chkPlanTerminate.Location = new System.Drawing.Point(156, 329);
            this.chkPlanTerminate.Name = "chkPlanTerminate";
            this.chkPlanTerminate.Size = new System.Drawing.Size(15, 14);
            this.chkPlanTerminate.TabIndex = 32;
            this.chkPlanTerminate.CheckedChanged += new System.EventHandler(this.chkPlanTerminate_CheckedChanged);
            // 
            // txtCleanCount
            // 
            this.txtCleanCount.Location = new System.Drawing.Point(156, 278);
            this.txtCleanCount.MaxLength = 6;
            this.txtCleanCount.Name = "txtCleanCount";
            this.txtCleanCount.ReadOnly = true;
            this.txtCleanCount.Size = new System.Drawing.Size(67, 20);
            this.txtCleanCount.TabIndex = 27;
            // 
            // txtUsageCount
            // 
            this.txtUsageCount.Location = new System.Drawing.Point(156, 230);
            this.txtUsageCount.MaxLength = 6;
            this.txtUsageCount.Name = "txtUsageCount";
            this.txtUsageCount.ReadOnly = true;
            this.txtUsageCount.Size = new System.Drawing.Size(67, 20);
            this.txtUsageCount.TabIndex = 24;
            // 
            // numCleanLimitCount
            // 
            this.numCleanLimitCount.Location = new System.Drawing.Point(229, 278);
            this.numCleanLimitCount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numCleanLimitCount.Name = "numCleanLimitCount";
            this.numCleanLimitCount.Size = new System.Drawing.Size(60, 20);
            this.numCleanLimitCount.TabIndex = 28;
            this.numCleanLimitCount.ThousandsSeparator = true;
            // 
            // numUsageLimitTime
            // 
            this.numUsageLimitTime.Location = new System.Drawing.Point(300, 206);
            this.numUsageLimitTime.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUsageLimitTime.Name = "numUsageLimitTime";
            this.numUsageLimitTime.Size = new System.Drawing.Size(60, 20);
            this.numUsageLimitTime.TabIndex = 21;
            this.numUsageLimitTime.ThousandsSeparator = true;
            // 
            // numUsageLimitCount
            // 
            this.numUsageLimitCount.Location = new System.Drawing.Point(229, 230);
            this.numUsageLimitCount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUsageLimitCount.Name = "numUsageLimitCount";
            this.numUsageLimitCount.Size = new System.Drawing.Size(60, 20);
            this.numUsageLimitCount.TabIndex = 25;
            this.numUsageLimitCount.ThousandsSeparator = true;
            // 
            // numCarrierSize
            // 
            this.numCarrierSize.Location = new System.Drawing.Point(156, 206);
            this.numCarrierSize.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numCarrierSize.Name = "numCarrierSize";
            this.numCarrierSize.Size = new System.Drawing.Size(133, 20);
            this.numCarrierSize.TabIndex = 19;
            this.numCarrierSize.ThousandsSeparator = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Location = new System.Drawing.Point(305, 141);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 13);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Carrier Status";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(300, 158);
            this.txtStatus.MaxLength = 10;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(133, 20);
            this.txtStatus.TabIndex = 15;
            // 
            // dtpPlanTermTime
            // 
            this.dtpPlanTermTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpPlanTermTime.Location = new System.Drawing.Point(300, 326);
            this.dtpPlanTermTime.Name = "dtpPlanTermTime";
            this.dtpPlanTermTime.ShowUpDown = true;
            this.dtpPlanTermTime.Size = new System.Drawing.Size(133, 20);
            this.dtpPlanTermTime.TabIndex = 34;
            this.dtpPlanTermTime.Visible = false;
            // 
            // dtpPlanTermDate
            // 
            this.dtpPlanTermDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPlanTermDate.Location = new System.Drawing.Point(177, 326);
            this.dtpPlanTermDate.Name = "dtpPlanTermDate";
            this.dtpPlanTermDate.Size = new System.Drawing.Size(112, 20);
            this.dtpPlanTermDate.TabIndex = 33;
            this.dtpPlanTermDate.Visible = false;
            // 
            // txtElapse
            // 
            this.txtElapse.Location = new System.Drawing.Point(366, 206);
            this.txtElapse.MaxLength = 20;
            this.txtElapse.Name = "txtElapse";
            this.txtElapse.ReadOnly = true;
            this.txtElapse.Size = new System.Drawing.Size(67, 20);
            this.txtElapse.TabIndex = 22;
            // 
            // lblUsageLimitTime
            // 
            this.lblUsageLimitTime.AutoSize = true;
            this.lblUsageLimitTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUsageLimitTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsageLimitTime.Location = new System.Drawing.Point(305, 190);
            this.lblUsageLimitTime.Name = "lblUsageLimitTime";
            this.lblUsageLimitTime.Size = new System.Drawing.Size(128, 13);
            this.lblUsageLimitTime.TabIndex = 20;
            this.lblUsageLimitTime.Text = "Usage Limit Time/ Elapse";
            // 
            // lblLastClean
            // 
            this.lblLastClean.AutoSize = true;
            this.lblLastClean.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastClean.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastClean.Location = new System.Drawing.Point(305, 237);
            this.lblLastClean.Name = "lblLastClean";
            this.lblLastClean.Size = new System.Drawing.Size(83, 13);
            this.lblLastClean.TabIndex = 29;
            this.lblLastClean.Text = "Last Clean Time";
            // 
            // txtLastCleanTime
            // 
            this.txtLastCleanTime.Location = new System.Drawing.Point(300, 278);
            this.txtLastCleanTime.MaxLength = 30;
            this.txtLastCleanTime.Name = "txtLastCleanTime";
            this.txtLastCleanTime.ReadOnly = true;
            this.txtLastCleanTime.Size = new System.Drawing.Size(133, 20);
            this.txtLastCleanTime.TabIndex = 30;
            // 
            // lblCleanLimit
            // 
            this.lblCleanLimit.AutoSize = true;
            this.lblCleanLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCleanLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCleanLimit.Location = new System.Drawing.Point(11, 281);
            this.lblCleanLimit.Name = "lblCleanLimit";
            this.lblCleanLimit.Size = new System.Drawing.Size(131, 13);
            this.lblCleanLimit.TabIndex = 26;
            this.lblCleanLimit.Text = "Current Clean/ Limit Count";
            // 
            // cdvCrrGroup
            // 
            this.cdvCrrGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrGroup.BtnToolTipText = "";
            this.cdvCrrGroup.DescText = "";
            this.cdvCrrGroup.DisplaySubItemIndex = -1;
            this.cdvCrrGroup.DisplayText = "";
            this.cdvCrrGroup.Focusing = null;
            this.cdvCrrGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrGroup.Index = 0;
            this.cdvCrrGroup.IsViewBtnImage = false;
            this.cdvCrrGroup.Location = new System.Drawing.Point(156, 14);
            this.cdvCrrGroup.MaxLength = 20;
            this.cdvCrrGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.Name = "cdvCrrGroup";
            this.cdvCrrGroup.ReadOnly = false;
            this.cdvCrrGroup.SearchSubItemIndex = 0;
            this.cdvCrrGroup.SelectedDescIndex = -1;
            this.cdvCrrGroup.SelectedSubItemIndex = -1;
            this.cdvCrrGroup.SelectionStart = 0;
            this.cdvCrrGroup.Size = new System.Drawing.Size(133, 20);
            this.cdvCrrGroup.SmallImageList = null;
            this.cdvCrrGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrGroup.TabIndex = 1;
            this.cdvCrrGroup.TextBoxToolTipText = "";
            this.cdvCrrGroup.TextBoxWidth = 133;
            this.cdvCrrGroup.VisibleButton = true;
            this.cdvCrrGroup.VisibleColumnHeader = false;
            this.cdvCrrGroup.VisibleDescription = false;
            this.cdvCrrGroup.ButtonPress += new System.EventHandler(this.cdvCrrGroup_ButtonPress);
            // 
            // lblCarrierGroup
            // 
            this.lblCarrierGroup.AutoSize = true;
            this.lblCarrierGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCarrierGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrierGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCarrierGroup.Location = new System.Drawing.Point(11, 16);
            this.lblCarrierGroup.Name = "lblCarrierGroup";
            this.lblCarrierGroup.Size = new System.Drawing.Size(82, 13);
            this.lblCarrierGroup.TabIndex = 0;
            this.lblCarrierGroup.Text = "Carrier Group";
            // 
            // cdvSubAreaID
            // 
            this.cdvSubAreaID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubAreaID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubAreaID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubAreaID.BtnToolTipText = "";
            this.cdvSubAreaID.DescText = "";
            this.cdvSubAreaID.DisplaySubItemIndex = -1;
            this.cdvSubAreaID.DisplayText = "";
            this.cdvSubAreaID.Focusing = null;
            this.cdvSubAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubAreaID.Index = 0;
            this.cdvSubAreaID.IsViewBtnImage = false;
            this.cdvSubAreaID.Location = new System.Drawing.Point(156, 134);
            this.cdvSubAreaID.MaxLength = 20;
            this.cdvSubAreaID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaID.Name = "cdvSubAreaID";
            this.cdvSubAreaID.ReadOnly = false;
            this.cdvSubAreaID.SearchSubItemIndex = 0;
            this.cdvSubAreaID.SelectedDescIndex = -1;
            this.cdvSubAreaID.SelectedSubItemIndex = -1;
            this.cdvSubAreaID.SelectionStart = 0;
            this.cdvSubAreaID.Size = new System.Drawing.Size(133, 20);
            this.cdvSubAreaID.SmallImageList = null;
            this.cdvSubAreaID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubAreaID.TabIndex = 11;
            this.cdvSubAreaID.TextBoxToolTipText = "";
            this.cdvSubAreaID.TextBoxWidth = 133;
            this.cdvSubAreaID.VisibleButton = true;
            this.cdvSubAreaID.VisibleColumnHeader = false;
            this.cdvSubAreaID.VisibleDescription = false;
            this.cdvSubAreaID.ButtonPress += new System.EventHandler(this.cdvSubAreaID_ButtonPress);
            // 
            // cdvAreaID
            // 
            this.cdvAreaID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAreaID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAreaID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAreaID.BtnToolTipText = "";
            this.cdvAreaID.DescText = "";
            this.cdvAreaID.DisplaySubItemIndex = -1;
            this.cdvAreaID.DisplayText = "";
            this.cdvAreaID.Focusing = null;
            this.cdvAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAreaID.Index = 0;
            this.cdvAreaID.IsViewBtnImage = false;
            this.cdvAreaID.Location = new System.Drawing.Point(156, 110);
            this.cdvAreaID.MaxLength = 20;
            this.cdvAreaID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.Name = "cdvAreaID";
            this.cdvAreaID.ReadOnly = false;
            this.cdvAreaID.SearchSubItemIndex = 0;
            this.cdvAreaID.SelectedDescIndex = -1;
            this.cdvAreaID.SelectedSubItemIndex = -1;
            this.cdvAreaID.SelectionStart = 0;
            this.cdvAreaID.Size = new System.Drawing.Size(133, 20);
            this.cdvAreaID.SmallImageList = null;
            this.cdvAreaID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAreaID.TabIndex = 9;
            this.cdvAreaID.TextBoxToolTipText = "";
            this.cdvAreaID.TextBoxWidth = 133;
            this.cdvAreaID.VisibleButton = true;
            this.cdvAreaID.VisibleColumnHeader = false;
            this.cdvAreaID.VisibleDescription = false;
            this.cdvAreaID.ButtonPress += new System.EventHandler(this.cdvAreaID_ButtonPress);
            // 
            // lblSubAreaID
            // 
            this.lblSubAreaID.AutoSize = true;
            this.lblSubAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubAreaID.Location = new System.Drawing.Point(11, 137);
            this.lblSubAreaID.Name = "lblSubAreaID";
            this.lblSubAreaID.Size = new System.Drawing.Size(65, 13);
            this.lblSubAreaID.TabIndex = 10;
            this.lblSubAreaID.Text = "Sub Area ID";
            // 
            // lblAreaID
            // 
            this.lblAreaID.AutoSize = true;
            this.lblAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAreaID.Location = new System.Drawing.Point(11, 113);
            this.lblAreaID.Name = "lblAreaID";
            this.lblAreaID.Size = new System.Drawing.Size(43, 13);
            this.lblAreaID.TabIndex = 8;
            this.lblAreaID.Text = "Area ID";
            // 
            // cdvCrrType3
            // 
            this.cdvCrrType3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrType3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrType3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrType3.BtnToolTipText = "";
            this.cdvCrrType3.DescText = "";
            this.cdvCrrType3.DisplaySubItemIndex = -1;
            this.cdvCrrType3.DisplayText = "";
            this.cdvCrrType3.Focusing = null;
            this.cdvCrrType3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrType3.Index = 0;
            this.cdvCrrType3.IsViewBtnImage = false;
            this.cdvCrrType3.Location = new System.Drawing.Point(156, 86);
            this.cdvCrrType3.MaxLength = 20;
            this.cdvCrrType3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType3.Name = "cdvCrrType3";
            this.cdvCrrType3.ReadOnly = false;
            this.cdvCrrType3.SearchSubItemIndex = 0;
            this.cdvCrrType3.SelectedDescIndex = -1;
            this.cdvCrrType3.SelectedSubItemIndex = -1;
            this.cdvCrrType3.SelectionStart = 0;
            this.cdvCrrType3.Size = new System.Drawing.Size(133, 20);
            this.cdvCrrType3.SmallImageList = null;
            this.cdvCrrType3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrType3.TabIndex = 7;
            this.cdvCrrType3.TextBoxToolTipText = "";
            this.cdvCrrType3.TextBoxWidth = 133;
            this.cdvCrrType3.VisibleButton = true;
            this.cdvCrrType3.VisibleColumnHeader = false;
            this.cdvCrrType3.VisibleDescription = false;
            this.cdvCrrType3.ButtonPress += new System.EventHandler(this.cdvCrrType3_ButtonPress);
            // 
            // lblCrrType3
            // 
            this.lblCrrType3.AutoSize = true;
            this.lblCrrType3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrType3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrType3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrType3.Location = new System.Drawing.Point(11, 89);
            this.lblCrrType3.Name = "lblCrrType3";
            this.lblCrrType3.Size = new System.Drawing.Size(70, 13);
            this.lblCrrType3.TabIndex = 6;
            this.lblCrrType3.Text = "Carrier Type3";
            // 
            // cdvCrrType2
            // 
            this.cdvCrrType2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrType2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrType2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrType2.BtnToolTipText = "";
            this.cdvCrrType2.DescText = "";
            this.cdvCrrType2.DisplaySubItemIndex = -1;
            this.cdvCrrType2.DisplayText = "";
            this.cdvCrrType2.Focusing = null;
            this.cdvCrrType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrType2.Index = 0;
            this.cdvCrrType2.IsViewBtnImage = false;
            this.cdvCrrType2.Location = new System.Drawing.Point(156, 62);
            this.cdvCrrType2.MaxLength = 20;
            this.cdvCrrType2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType2.Name = "cdvCrrType2";
            this.cdvCrrType2.ReadOnly = false;
            this.cdvCrrType2.SearchSubItemIndex = 0;
            this.cdvCrrType2.SelectedDescIndex = -1;
            this.cdvCrrType2.SelectedSubItemIndex = -1;
            this.cdvCrrType2.SelectionStart = 0;
            this.cdvCrrType2.Size = new System.Drawing.Size(133, 20);
            this.cdvCrrType2.SmallImageList = null;
            this.cdvCrrType2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrType2.TabIndex = 5;
            this.cdvCrrType2.TextBoxToolTipText = "";
            this.cdvCrrType2.TextBoxWidth = 133;
            this.cdvCrrType2.VisibleButton = true;
            this.cdvCrrType2.VisibleColumnHeader = false;
            this.cdvCrrType2.VisibleDescription = false;
            this.cdvCrrType2.ButtonPress += new System.EventHandler(this.cdvCrrType2_ButtonPress);
            // 
            // lblCrrType2
            // 
            this.lblCrrType2.AutoSize = true;
            this.lblCrrType2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrType2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrType2.Location = new System.Drawing.Point(11, 65);
            this.lblCrrType2.Name = "lblCrrType2";
            this.lblCrrType2.Size = new System.Drawing.Size(70, 13);
            this.lblCrrType2.TabIndex = 4;
            this.lblCrrType2.Text = "Carrier Type2";
            // 
            // lblUsageLimit
            // 
            this.lblUsageLimit.AutoSize = true;
            this.lblUsageLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUsageLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUsageLimit.Location = new System.Drawing.Point(11, 233);
            this.lblUsageLimit.Name = "lblUsageLimit";
            this.lblUsageLimit.Size = new System.Drawing.Size(135, 13);
            this.lblUsageLimit.TabIndex = 23;
            this.lblUsageLimit.Text = "Current Usage/ Limit Count";
            // 
            // cdvCrrType1
            // 
            this.cdvCrrType1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrType1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrType1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrType1.BtnToolTipText = "";
            this.cdvCrrType1.DescText = "";
            this.cdvCrrType1.DisplaySubItemIndex = -1;
            this.cdvCrrType1.DisplayText = "";
            this.cdvCrrType1.Focusing = null;
            this.cdvCrrType1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrType1.Index = 0;
            this.cdvCrrType1.IsViewBtnImage = false;
            this.cdvCrrType1.Location = new System.Drawing.Point(156, 38);
            this.cdvCrrType1.MaxLength = 20;
            this.cdvCrrType1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType1.Name = "cdvCrrType1";
            this.cdvCrrType1.ReadOnly = false;
            this.cdvCrrType1.SearchSubItemIndex = 0;
            this.cdvCrrType1.SelectedDescIndex = -1;
            this.cdvCrrType1.SelectedSubItemIndex = -1;
            this.cdvCrrType1.SelectionStart = 0;
            this.cdvCrrType1.Size = new System.Drawing.Size(133, 20);
            this.cdvCrrType1.SmallImageList = null;
            this.cdvCrrType1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrType1.TabIndex = 3;
            this.cdvCrrType1.TextBoxToolTipText = "";
            this.cdvCrrType1.TextBoxWidth = 133;
            this.cdvCrrType1.VisibleButton = true;
            this.cdvCrrType1.VisibleColumnHeader = false;
            this.cdvCrrType1.VisibleDescription = false;
            this.cdvCrrType1.ButtonPress += new System.EventHandler(this.cdvCrrType1_ButtonPress);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSize.Location = new System.Drawing.Point(11, 209);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 13);
            this.lblSize.TabIndex = 18;
            this.lblSize.Text = "Size";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(11, 389);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(95, 13);
            this.lblUpdateUser.TabIndex = 38;
            this.lblUpdateUser.Text = "Update User/Time";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(11, 365);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(91, 13);
            this.lblCreateUser.TabIndex = 35;
            this.lblCreateUser.Text = "Create User/Time";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUpdateTime.Location = new System.Drawing.Point(300, 386);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(133, 20);
            this.txtUpdateTime.TabIndex = 40;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCreateTime.Location = new System.Drawing.Point(300, 362);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(133, 20);
            this.txtCreateTime.TabIndex = 37;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUpdateUser.Location = new System.Drawing.Point(156, 386);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(133, 20);
            this.txtUpdateUser.TabIndex = 39;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCreateUser.Location = new System.Drawing.Point(156, 362);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(133, 20);
            this.txtCreateUser.TabIndex = 36;
            this.txtCreateUser.TabStop = false;
            // 
            // cdvResourceID
            // 
            this.cdvResourceID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResourceID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResourceID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResourceID.BtnToolTipText = "";
            this.cdvResourceID.DescText = "";
            this.cdvResourceID.DisplaySubItemIndex = -1;
            this.cdvResourceID.DisplayText = "";
            this.cdvResourceID.Focusing = null;
            this.cdvResourceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResourceID.Index = 0;
            this.cdvResourceID.IsViewBtnImage = false;
            this.cdvResourceID.Location = new System.Drawing.Point(156, 158);
            this.cdvResourceID.MaxLength = 20;
            this.cdvResourceID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResourceID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResourceID.Name = "cdvResourceID";
            this.cdvResourceID.ReadOnly = false;
            this.cdvResourceID.SearchSubItemIndex = 0;
            this.cdvResourceID.SelectedDescIndex = -1;
            this.cdvResourceID.SelectedSubItemIndex = -1;
            this.cdvResourceID.SelectionStart = 0;
            this.cdvResourceID.Size = new System.Drawing.Size(133, 20);
            this.cdvResourceID.SmallImageList = null;
            this.cdvResourceID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResourceID.TabIndex = 13;
            this.cdvResourceID.TextBoxToolTipText = "";
            this.cdvResourceID.TextBoxWidth = 133;
            this.cdvResourceID.VisibleButton = true;
            this.cdvResourceID.VisibleColumnHeader = false;
            this.cdvResourceID.VisibleDescription = false;
            this.cdvResourceID.ButtonPress += new System.EventHandler(this.cdvResourceID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResID.Location = new System.Drawing.Point(11, 161);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 12;
            this.lblResID.Text = "Resource ID";
            // 
            // lblCrrType1
            // 
            this.lblCrrType1.AutoSize = true;
            this.lblCrrType1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrType1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrType1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrType1.Location = new System.Drawing.Point(11, 40);
            this.lblCrrType1.Name = "lblCrrType1";
            this.lblCrrType1.Size = new System.Drawing.Size(83, 13);
            this.lblCrrType1.TabIndex = 2;
            this.lblCrrType1.Text = "Carrier Type1";
            // 
            // lblPlanTermTime
            // 
            this.lblPlanTermTime.AutoSize = true;
            this.lblPlanTermTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPlanTermTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPlanTermTime.Location = new System.Drawing.Point(11, 329);
            this.lblPlanTermTime.Name = "lblPlanTermTime";
            this.lblPlanTermTime.Size = new System.Drawing.Size(104, 13);
            this.lblPlanTermTime.TabIndex = 31;
            this.lblPlanTermTime.Text = "Plan Terminate Time";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation.Location = new System.Drawing.Point(11, 185);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 16;
            this.lblLocation.Text = "Location";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(156, 182);
            this.txtLocation.MaxLength = 20;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(133, 20);
            this.txtLocation.TabIndex = 17;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCMF);
            this.tbpCMF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCMF.Size = new System.Drawing.Size(498, 417);
            this.tbpCMF.TabIndex = 2;
            this.tbpCMF.Text = "Customized Field";
            this.tbpCMF.Visible = false;
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.cdvCMF19);
            this.grpCMF.Controls.Add(this.cdvCMF18);
            this.grpCMF.Controls.Add(this.cdvCMF17);
            this.grpCMF.Controls.Add(this.cdvCMF16);
            this.grpCMF.Controls.Add(this.cdvCMF15);
            this.grpCMF.Controls.Add(this.cdvCMF14);
            this.grpCMF.Controls.Add(this.cdvCMF13);
            this.grpCMF.Controls.Add(this.cdvCMF12);
            this.grpCMF.Controls.Add(this.cdvCMF20);
            this.grpCMF.Controls.Add(this.cdvCMF11);
            this.grpCMF.Controls.Add(this.lblCMF20);
            this.grpCMF.Controls.Add(this.lblCMF19);
            this.grpCMF.Controls.Add(this.lblCMF18);
            this.grpCMF.Controls.Add(this.lblCMF17);
            this.grpCMF.Controls.Add(this.lblCMF16);
            this.grpCMF.Controls.Add(this.lblCMF15);
            this.grpCMF.Controls.Add(this.lblCMF14);
            this.grpCMF.Controls.Add(this.lblCMF13);
            this.grpCMF.Controls.Add(this.lblCMF12);
            this.grpCMF.Controls.Add(this.lblCMF11);
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF5);
            this.grpCMF.Controls.Add(this.cdvCMF4);
            this.grpCMF.Controls.Add(this.cdvCMF3);
            this.grpCMF.Controls.Add(this.cdvCMF2);
            this.grpCMF.Controls.Add(this.cdvCMF10);
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
            this.grpCMF.Location = new System.Drawing.Point(3, 0);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(492, 414);
            this.grpCMF.TabIndex = 0;
            this.grpCMF.TabStop = false;
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF19.BtnToolTipText = "";
            this.cdvCMF19.DescText = "";
            this.cdvCMF19.DisplaySubItemIndex = -1;
            this.cdvCMF19.DisplayText = "";
            this.cdvCMF19.Focusing = null;
            this.cdvCMF19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF19.Index = 0;
            this.cdvCMF19.IsViewBtnImage = false;
            this.cdvCMF19.Location = new System.Drawing.Point(351, 210);
            this.cdvCMF19.MaxLength = 30;
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.Name = "cdvCMF19";
            this.cdvCMF19.ReadOnly = false;
            this.cdvCMF19.SearchSubItemIndex = 0;
            this.cdvCMF19.SelectedDescIndex = -1;
            this.cdvCMF19.SelectedSubItemIndex = -1;
            this.cdvCMF19.SelectionStart = 0;
            this.cdvCMF19.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF19.SmallImageList = null;
            this.cdvCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF19.TabIndex = 97;
            this.cdvCMF19.TextBoxToolTipText = "";
            this.cdvCMF19.TextBoxWidth = 130;
            this.cdvCMF19.VisibleButton = true;
            this.cdvCMF19.VisibleColumnHeader = false;
            this.cdvCMF19.VisibleDescription = false;
            this.cdvCMF19.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF18.BtnToolTipText = "";
            this.cdvCMF18.DescText = "";
            this.cdvCMF18.DisplaySubItemIndex = -1;
            this.cdvCMF18.DisplayText = "";
            this.cdvCMF18.Focusing = null;
            this.cdvCMF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF18.Index = 0;
            this.cdvCMF18.IsViewBtnImage = false;
            this.cdvCMF18.Location = new System.Drawing.Point(351, 186);
            this.cdvCMF18.MaxLength = 30;
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.Name = "cdvCMF18";
            this.cdvCMF18.ReadOnly = false;
            this.cdvCMF18.SearchSubItemIndex = 0;
            this.cdvCMF18.SelectedDescIndex = -1;
            this.cdvCMF18.SelectedSubItemIndex = -1;
            this.cdvCMF18.SelectionStart = 0;
            this.cdvCMF18.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF18.SmallImageList = null;
            this.cdvCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF18.TabIndex = 95;
            this.cdvCMF18.TextBoxToolTipText = "";
            this.cdvCMF18.TextBoxWidth = 130;
            this.cdvCMF18.VisibleButton = true;
            this.cdvCMF18.VisibleColumnHeader = false;
            this.cdvCMF18.VisibleDescription = false;
            this.cdvCMF18.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF17.BtnToolTipText = "";
            this.cdvCMF17.DescText = "";
            this.cdvCMF17.DisplaySubItemIndex = -1;
            this.cdvCMF17.DisplayText = "";
            this.cdvCMF17.Focusing = null;
            this.cdvCMF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF17.Index = 0;
            this.cdvCMF17.IsViewBtnImage = false;
            this.cdvCMF17.Location = new System.Drawing.Point(351, 162);
            this.cdvCMF17.MaxLength = 30;
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.Name = "cdvCMF17";
            this.cdvCMF17.ReadOnly = false;
            this.cdvCMF17.SearchSubItemIndex = 0;
            this.cdvCMF17.SelectedDescIndex = -1;
            this.cdvCMF17.SelectedSubItemIndex = -1;
            this.cdvCMF17.SelectionStart = 0;
            this.cdvCMF17.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF17.SmallImageList = null;
            this.cdvCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF17.TabIndex = 93;
            this.cdvCMF17.TextBoxToolTipText = "";
            this.cdvCMF17.TextBoxWidth = 130;
            this.cdvCMF17.VisibleButton = true;
            this.cdvCMF17.VisibleColumnHeader = false;
            this.cdvCMF17.VisibleDescription = false;
            this.cdvCMF17.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF16.BtnToolTipText = "";
            this.cdvCMF16.DescText = "";
            this.cdvCMF16.DisplaySubItemIndex = -1;
            this.cdvCMF16.DisplayText = "";
            this.cdvCMF16.Focusing = null;
            this.cdvCMF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF16.Index = 0;
            this.cdvCMF16.IsViewBtnImage = false;
            this.cdvCMF16.Location = new System.Drawing.Point(351, 138);
            this.cdvCMF16.MaxLength = 30;
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.Name = "cdvCMF16";
            this.cdvCMF16.ReadOnly = false;
            this.cdvCMF16.SearchSubItemIndex = 0;
            this.cdvCMF16.SelectedDescIndex = -1;
            this.cdvCMF16.SelectedSubItemIndex = -1;
            this.cdvCMF16.SelectionStart = 0;
            this.cdvCMF16.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF16.SmallImageList = null;
            this.cdvCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF16.TabIndex = 91;
            this.cdvCMF16.TextBoxToolTipText = "";
            this.cdvCMF16.TextBoxWidth = 130;
            this.cdvCMF16.VisibleButton = true;
            this.cdvCMF16.VisibleColumnHeader = false;
            this.cdvCMF16.VisibleDescription = false;
            this.cdvCMF16.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF15.BtnToolTipText = "";
            this.cdvCMF15.DescText = "";
            this.cdvCMF15.DisplaySubItemIndex = -1;
            this.cdvCMF15.DisplayText = "";
            this.cdvCMF15.Focusing = null;
            this.cdvCMF15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF15.Index = 0;
            this.cdvCMF15.IsViewBtnImage = false;
            this.cdvCMF15.Location = new System.Drawing.Point(351, 114);
            this.cdvCMF15.MaxLength = 30;
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.Name = "cdvCMF15";
            this.cdvCMF15.ReadOnly = false;
            this.cdvCMF15.SearchSubItemIndex = 0;
            this.cdvCMF15.SelectedDescIndex = -1;
            this.cdvCMF15.SelectedSubItemIndex = -1;
            this.cdvCMF15.SelectionStart = 0;
            this.cdvCMF15.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF15.SmallImageList = null;
            this.cdvCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF15.TabIndex = 89;
            this.cdvCMF15.TextBoxToolTipText = "";
            this.cdvCMF15.TextBoxWidth = 130;
            this.cdvCMF15.VisibleButton = true;
            this.cdvCMF15.VisibleColumnHeader = false;
            this.cdvCMF15.VisibleDescription = false;
            this.cdvCMF15.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF14.BtnToolTipText = "";
            this.cdvCMF14.DescText = "";
            this.cdvCMF14.DisplaySubItemIndex = -1;
            this.cdvCMF14.DisplayText = "";
            this.cdvCMF14.Focusing = null;
            this.cdvCMF14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF14.Index = 0;
            this.cdvCMF14.IsViewBtnImage = false;
            this.cdvCMF14.Location = new System.Drawing.Point(351, 90);
            this.cdvCMF14.MaxLength = 30;
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.Name = "cdvCMF14";
            this.cdvCMF14.ReadOnly = false;
            this.cdvCMF14.SearchSubItemIndex = 0;
            this.cdvCMF14.SelectedDescIndex = -1;
            this.cdvCMF14.SelectedSubItemIndex = -1;
            this.cdvCMF14.SelectionStart = 0;
            this.cdvCMF14.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF14.SmallImageList = null;
            this.cdvCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF14.TabIndex = 87;
            this.cdvCMF14.TextBoxToolTipText = "";
            this.cdvCMF14.TextBoxWidth = 130;
            this.cdvCMF14.VisibleButton = true;
            this.cdvCMF14.VisibleColumnHeader = false;
            this.cdvCMF14.VisibleDescription = false;
            this.cdvCMF14.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF13.BtnToolTipText = "";
            this.cdvCMF13.DescText = "";
            this.cdvCMF13.DisplaySubItemIndex = -1;
            this.cdvCMF13.DisplayText = "";
            this.cdvCMF13.Focusing = null;
            this.cdvCMF13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF13.Index = 0;
            this.cdvCMF13.IsViewBtnImage = false;
            this.cdvCMF13.Location = new System.Drawing.Point(351, 66);
            this.cdvCMF13.MaxLength = 30;
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.Name = "cdvCMF13";
            this.cdvCMF13.ReadOnly = false;
            this.cdvCMF13.SearchSubItemIndex = 0;
            this.cdvCMF13.SelectedDescIndex = -1;
            this.cdvCMF13.SelectedSubItemIndex = -1;
            this.cdvCMF13.SelectionStart = 0;
            this.cdvCMF13.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF13.SmallImageList = null;
            this.cdvCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF13.TabIndex = 85;
            this.cdvCMF13.TextBoxToolTipText = "";
            this.cdvCMF13.TextBoxWidth = 130;
            this.cdvCMF13.VisibleButton = true;
            this.cdvCMF13.VisibleColumnHeader = false;
            this.cdvCMF13.VisibleDescription = false;
            this.cdvCMF13.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF12.BtnToolTipText = "";
            this.cdvCMF12.DescText = "";
            this.cdvCMF12.DisplaySubItemIndex = -1;
            this.cdvCMF12.DisplayText = "";
            this.cdvCMF12.Focusing = null;
            this.cdvCMF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF12.Index = 0;
            this.cdvCMF12.IsViewBtnImage = false;
            this.cdvCMF12.Location = new System.Drawing.Point(351, 42);
            this.cdvCMF12.MaxLength = 30;
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.Name = "cdvCMF12";
            this.cdvCMF12.ReadOnly = false;
            this.cdvCMF12.SearchSubItemIndex = 0;
            this.cdvCMF12.SelectedDescIndex = -1;
            this.cdvCMF12.SelectedSubItemIndex = -1;
            this.cdvCMF12.SelectionStart = 0;
            this.cdvCMF12.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF12.SmallImageList = null;
            this.cdvCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF12.TabIndex = 83;
            this.cdvCMF12.TextBoxToolTipText = "";
            this.cdvCMF12.TextBoxWidth = 130;
            this.cdvCMF12.VisibleButton = true;
            this.cdvCMF12.VisibleColumnHeader = false;
            this.cdvCMF12.VisibleDescription = false;
            this.cdvCMF12.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF20.BtnToolTipText = "";
            this.cdvCMF20.DescText = "";
            this.cdvCMF20.DisplaySubItemIndex = -1;
            this.cdvCMF20.DisplayText = "";
            this.cdvCMF20.Focusing = null;
            this.cdvCMF20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF20.Index = 0;
            this.cdvCMF20.IsViewBtnImage = false;
            this.cdvCMF20.Location = new System.Drawing.Point(351, 234);
            this.cdvCMF20.MaxLength = 30;
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.Name = "cdvCMF20";
            this.cdvCMF20.ReadOnly = false;
            this.cdvCMF20.SearchSubItemIndex = 0;
            this.cdvCMF20.SelectedDescIndex = -1;
            this.cdvCMF20.SelectedSubItemIndex = -1;
            this.cdvCMF20.SelectionStart = 0;
            this.cdvCMF20.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF20.SmallImageList = null;
            this.cdvCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF20.TabIndex = 99;
            this.cdvCMF20.TextBoxToolTipText = "";
            this.cdvCMF20.TextBoxWidth = 130;
            this.cdvCMF20.VisibleButton = true;
            this.cdvCMF20.VisibleColumnHeader = false;
            this.cdvCMF20.VisibleDescription = false;
            this.cdvCMF20.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF11.BtnToolTipText = "";
            this.cdvCMF11.DescText = "";
            this.cdvCMF11.DisplaySubItemIndex = -1;
            this.cdvCMF11.DisplayText = "";
            this.cdvCMF11.Focusing = null;
            this.cdvCMF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF11.Index = 0;
            this.cdvCMF11.IsViewBtnImage = false;
            this.cdvCMF11.Location = new System.Drawing.Point(351, 18);
            this.cdvCMF11.MaxLength = 30;
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.Name = "cdvCMF11";
            this.cdvCMF11.ReadOnly = false;
            this.cdvCMF11.SearchSubItemIndex = 0;
            this.cdvCMF11.SelectedDescIndex = -1;
            this.cdvCMF11.SelectedSubItemIndex = -1;
            this.cdvCMF11.SelectionStart = 0;
            this.cdvCMF11.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF11.SmallImageList = null;
            this.cdvCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF11.TabIndex = 81;
            this.cdvCMF11.TextBoxToolTipText = "";
            this.cdvCMF11.TextBoxWidth = 130;
            this.cdvCMF11.VisibleButton = true;
            this.cdvCMF11.VisibleColumnHeader = false;
            this.cdvCMF11.VisibleDescription = false;
            this.cdvCMF11.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.Location = new System.Drawing.Point(255, 238);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(90, 14);
            this.lblCMF20.TabIndex = 98;
            this.lblCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.Location = new System.Drawing.Point(255, 214);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(90, 14);
            this.lblCMF19.TabIndex = 96;
            this.lblCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.Location = new System.Drawing.Point(255, 190);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(90, 14);
            this.lblCMF18.TabIndex = 94;
            this.lblCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.Location = new System.Drawing.Point(255, 166);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(90, 14);
            this.lblCMF17.TabIndex = 92;
            this.lblCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.Location = new System.Drawing.Point(255, 142);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(90, 14);
            this.lblCMF16.TabIndex = 90;
            this.lblCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.Location = new System.Drawing.Point(255, 118);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(90, 14);
            this.lblCMF15.TabIndex = 88;
            this.lblCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.Location = new System.Drawing.Point(255, 94);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(90, 14);
            this.lblCMF14.TabIndex = 86;
            this.lblCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.Location = new System.Drawing.Point(255, 70);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(90, 14);
            this.lblCMF13.TabIndex = 84;
            this.lblCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.Location = new System.Drawing.Point(255, 46);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(90, 14);
            this.lblCMF12.TabIndex = 82;
            this.lblCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.Location = new System.Drawing.Point(255, 22);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(90, 14);
            this.lblCMF11.TabIndex = 80;
            this.lblCMF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvCMF9.Location = new System.Drawing.Point(108, 210);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 77;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 130;
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
            this.cdvCMF8.Location = new System.Drawing.Point(108, 186);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 75;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 130;
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
            this.cdvCMF7.Location = new System.Drawing.Point(108, 162);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 73;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 130;
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
            this.cdvCMF6.Location = new System.Drawing.Point(108, 138);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 71;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 130;
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
            this.cdvCMF5.Location = new System.Drawing.Point(108, 114);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 69;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 130;
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
            this.cdvCMF4.Location = new System.Drawing.Point(108, 90);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 67;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 130;
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
            this.cdvCMF3.Location = new System.Drawing.Point(108, 66);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 65;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 130;
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
            this.cdvCMF2.Location = new System.Drawing.Point(108, 42);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 63;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 130;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF10.Location = new System.Drawing.Point(108, 234);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 79;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 130;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF1.Location = new System.Drawing.Point(108, 18);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 61;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 130;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(12, 238);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(90, 14);
            this.lblCMF10.TabIndex = 78;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(12, 214);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(90, 14);
            this.lblCMF9.TabIndex = 76;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(12, 190);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(90, 14);
            this.lblCMF8.TabIndex = 74;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(12, 166);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(90, 14);
            this.lblCMF7.TabIndex = 72;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(12, 142);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(90, 14);
            this.lblCMF6.TabIndex = 70;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(12, 118);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(90, 14);
            this.lblCMF5.TabIndex = 68;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(12, 94);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(90, 14);
            this.lblCMF4.TabIndex = 66;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(12, 70);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(90, 14);
            this.lblCMF3.TabIndex = 64;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(12, 46);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(90, 14);
            this.lblCMF2.TabIndex = 62;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(12, 22);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(90, 14);
            this.lblCMF1.TabIndex = 60;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabCarrier
            // 
            this.tabCarrier.Controls.Add(this.tbpGeneral);
            this.tabCarrier.Controls.Add(this.tbpCMF);
            this.tabCarrier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCarrier.ItemSize = new System.Drawing.Size(60, 18);
            this.tabCarrier.Location = new System.Drawing.Point(0, 70);
            this.tabCarrier.Multiline = true;
            this.tabCarrier.Name = "tabCarrier";
            this.tabCarrier.SelectedIndex = 0;
            this.tabCarrier.Size = new System.Drawing.Size(506, 443);
            this.tabCarrier.TabIndex = 4;
            this.tabCarrier.TabStop = false;
            // 
            // lisCarrier
            // 
            this.lisCarrier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCarrier,
            this.colCarrierDesc});
            this.lisCarrier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCarrier.EnableSort = true;
            this.lisCarrier.EnableSortIcon = true;
            this.lisCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCarrier.FullRowSelect = true;
            this.lisCarrier.Location = new System.Drawing.Point(0, 0);
            this.lisCarrier.MultiSelect = false;
            this.lisCarrier.Name = "lisCarrier";
            this.lisCarrier.Size = new System.Drawing.Size(232, 449);
            this.lisCarrier.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lisCarrier.TabIndex = 0;
            this.lisCarrier.UseCompatibleStateImageBehavior = false;
            this.lisCarrier.View = System.Windows.Forms.View.Details;
            this.lisCarrier.SelectedIndexChanged += new System.EventHandler(this.lisCarrier_SelectedIndexChanged);
            // 
            // colCarrier
            // 
            this.colCarrier.Text = "Carrier";
            this.colCarrier.Width = 80;
            // 
            // colCarrierDesc
            // 
            this.colCarrierDesc.Text = "Description";
            this.colCarrierDesc.Width = 150;
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
            this.cdvGroup.Location = new System.Drawing.Point(93, 12);
            this.cdvGroup.MaxLength = 20;
            this.cdvGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.Name = "cdvGroup";
            this.cdvGroup.ReadOnly = true;
            this.cdvGroup.SearchSubItemIndex = 0;
            this.cdvGroup.SelectedDescIndex = -1;
            this.cdvGroup.SelectedSubItemIndex = -1;
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
            // frmRASSetupCarrier
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASSetupCarrier";
            this.Text = "Carrier Setup";
            this.VisibleFilterBox = true;
            this.Activated += new System.EventHandler(this.frmRASSetupCarrier_Activated);
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
            this.grpCarrier.ResumeLayout(false);
            this.grpCarrier.PerformLayout();
            this.tbpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCleanLimitAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUsageLimitAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCleanLimitCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimitTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUsageLimitCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCarrierSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResourceID)).EndInit();
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
            this.tabCarrier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable definition "
        bool b_load_flag;
        #endregion
        
        #region " Function definition"
        
        private bool CheckCondition(string FuncName)
        {

            if (MPCF.CheckValue(txtCarrierID, 1) == false) return false;
            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":

                    if (MPCF.CheckValue(cdvCrrGroup, 1) == false) return false;
                    if (MPCF.CheckValue(cdvCrrType1, 1) == false) return false;

                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        tabCarrier.SelectedTab = tbpCMF;
                        return false;
                    }

                    break;
                case "DELETE":
                    
                    break;
                    
            }
            return true;
        }
        
        private bool CreateCarrier()
        {
            TRSNode in_node = new TRSNode("Create_Carrier_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            ListViewItem item;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("CRR_ID", MPCF.Trim(txtCarrierID.Text));
                in_node.AddString("CRR_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddString("CRR_GROUP", MPCF.Trim(cdvCrrGroup.Text));
                in_node.AddString("CRR_TYPE1", MPCF.Trim(cdvCrrType1.Text));
                in_node.AddString("CRR_TYPE2", MPCF.Trim(cdvCrrType2.Text));
                in_node.AddString("CRR_TYPE3", MPCF.Trim(cdvCrrType3.Text));
                in_node.AddString("USE_AREA_ID", MPCF.Trim(cdvAreaID.Text));
                in_node.AddString("USE_SUB_AREA_ID", MPCF.Trim(cdvSubAreaID.Text));
                in_node.AddString("USE_RES_ID", MPCF.Trim(cdvResourceID.Text));
                in_node.AddInt("CRR_SIZE", (int)numCarrierSize.Value);
                in_node.AddInt("USAGE_LIMIT_COUNT", (int)numUsageLimitCount.Value);
                in_node.AddInt("USAGE_LIMIT_TIME", (int)numUsageLimitTime.Value);
                in_node.AddString("USAGE_LIMIT_ALARM", MPCF.Trim(cdvUsageLimitAlarm.Text));
                in_node.AddInt("CLEAN_LIMIT_COUNT", (int)numCleanLimitCount.Value);
                in_node.AddString("CLEAN_LIMIT_ALARM", MPCF.Trim(cdvCleanLimitAlarm.Text));
                in_node.AddString("LOCATION_1", MPCF.Trim(txtLocation.Text));

                if(chkPlanTerminate.Checked == true)
                    in_node.AddString("PLAN_TERMINATE_TIME", MPCF.ToStandardTime(dtpPlanTermDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpPlanTermTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));

                in_node.AddString("CRR_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("CRR_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("CRR_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("CRR_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("CRR_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("CRR_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("CRR_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("CRR_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("CRR_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("CRR_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("CRR_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("CRR_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("CRR_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("CRR_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("CRR_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("CRR_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("CRR_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("CRR_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("CRR_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("CRR_CMF_20", MPCF.Trim(cdvCMF20.Text));

                if (MPCR.CallService("RAS", "RAS_Create_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    item = lisCarrier.Items.Add(txtCarrierID.Text, (int)SMALLICON_INDEX.IDX_CARRIER);
                    item.SubItems.Add(txtDesc.Text);
                    item.Selected = true;
                    lisCarrier.Sorting = SortOrder.Ascending;
                    lisCarrier.Sort();
                    item.EnsureVisible();
                    lblDataCount.Text = MPCF.Trim(lisCarrier.Items.Count);
                }
                MPCR.ShowSuccessMsg(out_node);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return true;
            
        }
        
        private bool UpdateCarrier()
        {
            TRSNode in_node = new TRSNode("Update_Carrier_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
          
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;

                in_node.AddString("CRR_ID", MPCF.Trim(txtCarrierID.Text));
                in_node.AddString("CRR_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddString("CRR_GROUP", MPCF.Trim(cdvCrrGroup.Text));
                in_node.AddString("CRR_TYPE1", MPCF.Trim(cdvCrrType1.Text));
                in_node.AddString("CRR_TYPE2", MPCF.Trim(cdvCrrType2.Text));
                in_node.AddString("CRR_TYPE3", MPCF.Trim(cdvCrrType3.Text));
                in_node.AddString("USE_AREA_ID", MPCF.Trim(cdvAreaID.Text));
                in_node.AddString("USE_SUB_AREA_ID", MPCF.Trim(cdvSubAreaID.Text));
                in_node.AddString("USE_RES_ID", MPCF.Trim(cdvResourceID.Text));
                in_node.AddInt("CRR_SIZE", (int)numCarrierSize.Value);
                in_node.AddInt("USAGE_LIMIT_COUNT", (int)numUsageLimitCount.Value);
                in_node.AddInt("USAGE_LIMIT_TIME", (int)numUsageLimitTime.Value);
                in_node.AddString("USAGE_LIMIT_ALARM", MPCF.Trim(cdvUsageLimitAlarm.Text));
                in_node.AddInt("CLEAN_LIMIT_COUNT", (int)numCleanLimitCount.Value);
                in_node.AddString("CLEAN_LIMIT_ALARM", MPCF.Trim(cdvCleanLimitAlarm.Text));
                in_node.AddString("LOCATION_1", MPCF.Trim(txtLocation.Text));

                if (chkPlanTerminate.Checked == true)
                    in_node.AddString("PLAN_TERMINATE_TIME", MPCF.ToStandardTime(dtpPlanTermDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpPlanTermTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));

                in_node.AddString("CRR_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("CRR_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("CRR_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("CRR_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("CRR_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("CRR_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("CRR_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("CRR_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("CRR_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("CRR_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("CRR_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("CRR_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("CRR_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("CRR_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("CRR_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("CRR_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("CRR_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("CRR_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("CRR_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("CRR_CMF_20", MPCF.Trim(cdvCMF20.Text));

                if (MPCR.CallService("RAS", "RAS_Update_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (MPCF.FindListItem(lisCarrier, MPCF.Trim(txtCarrierID.Text), false) == true)
                    {
                        lisCarrier.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                    }
                    lblDataCount.Text = MPCF.Trim(lisCarrier.Items.Count);
                }
                MPCR.ShowSuccessMsg(out_node);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return true;
            
        }
        
        private bool TerminateCarrier()
        {
            TRSNode in_node = new TRSNode("Terminate_Carrier_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            int idx;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_ID", MPCF.Trim(txtCarrierID.Text));

                if (MPCR.CallService("RAS", "RAS_Terminate_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }
                                
                if (MPGV.gbListAutoRefresh == false)
                {
                    idx = MPCF.FindListItemIndex(lisCarrier, MPCF.Trim(txtCarrierID.Text), false);
                    if (idx > - 1)
                    {
                        lisCarrier.Items[idx].Remove();
                    }
                    lblDataCount.Text = MPCF.Trim(lisCarrier.Items.Count);
                }
                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return true;
            
        }
        // View_Carrier()
        //       -  View Carrier
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewCarrier()
        {
            TRSNode in_node = new TRSNode("View_Carrier_In");
            TRSNode out_node = new TRSNode("View_Carrier_Out");
            
            try
            {
                MPCF.FieldClear(this.pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CRR_ID", MPCF.Trim(lisCarrier.SelectedItems[0].Text));

                if (MPCR.CallService("RAS", "RAS_View_Carrier", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtCarrierID.Text = out_node.GetString("CRR_ID");
                txtDesc.Text = out_node.GetString("CRR_DESC");
                cdvCrrGroup.Text = out_node.GetString("CRR_GROUP");
                txtStatus.Text = out_node.GetString("CRR_STATUS");
                cdvCrrType1.Text = out_node.GetString("CRR_TYPE1");
                cdvCrrType2.Text = out_node.GetString("CRR_TYPE2");
                cdvCrrType3.Text = out_node.GetString("CRR_TYPE3");
                cdvAreaID.Text = out_node.GetString("USE_AREA_ID");
                cdvSubAreaID.Text = out_node.GetString("USE_SUB_AREA_ID");
                cdvResourceID.Text = out_node.GetString("USE_RES_ID");
                numCarrierSize.Value = out_node.GetInt("CRR_SIZE");
                numUsageLimitCount.Value = out_node.GetInt("USAGE_LIMIT_COUNT");
                numUsageLimitTime.Value = out_node.GetInt("USAGE_LIMIT_TIME");
                cdvUsageLimitAlarm.Text = out_node.GetString("USAGE_LIMIT_ALARM");
                cdvUsageLimitAlarm.DescText = out_node.GetString("USAGE_LIMIT_ALARM_DESC");
                txtUsageCount.Text = out_node.GetInt("USAGE_COUNT").ToString();
                numCleanLimitCount.Value = out_node.GetInt("CLEAN_LIMIT_COUNT");
                txtCleanCount.Text = out_node.GetInt("CLEAN_COUNT").ToString();
                cdvCleanLimitAlarm.Text = out_node.GetString("CLEAN_LIMIT_ALARM");
                cdvCleanLimitAlarm.DescText = out_node.GetString("CLEAN_LIMIT_ALARM_DESC");
                txtLastCleanTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_CLEAN_TIME"));
                txtElapse.Text = out_node.GetDouble("ELAPSE_USAGE_TIME").ToString("####,##0.#");

                txtLocation.Text = out_node.GetString("LOCATION_1");

                chkPlanTerminate.Checked = false;
                if (out_node.GetString("PLAN_TERMINATE_TIME") != "")
                {
                    chkPlanTerminate.Checked = true;
                    dtpPlanTermDate.Value = MPCF.ToDate(out_node.GetString("PLAN_TERMINATE_TIME"));
                    dtpPlanTermTime.Value = MPCF.ToDate(out_node.GetString("PLAN_TERMINATE_TIME"));
                }

                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                cdvCMF1.Text = out_node.GetString("CRR_CMF_1");
                cdvCMF2.Text = out_node.GetString("CRR_CMF_2");
                cdvCMF3.Text = out_node.GetString("CRR_CMF_3");
                cdvCMF4.Text = out_node.GetString("CRR_CMF_4");
                cdvCMF5.Text = out_node.GetString("CRR_CMF_5");
                cdvCMF6.Text = out_node.GetString("CRR_CMF_6");
                cdvCMF7.Text = out_node.GetString("CRR_CMF_7");
                cdvCMF8.Text = out_node.GetString("CRR_CMF_8");
                cdvCMF9.Text = out_node.GetString("CRR_CMF_9");
                cdvCMF10.Text = out_node.GetString("CRR_CMF_10");
                cdvCMF11.Text = out_node.GetString("CRR_CMF_11");
                cdvCMF12.Text = out_node.GetString("CRR_CMF_12");
                cdvCMF13.Text = out_node.GetString("CRR_CMF_13");
                cdvCMF14.Text = out_node.GetString("CRR_CMF_14");
                cdvCMF15.Text = out_node.GetString("CRR_CMF_15");
                cdvCMF16.Text = out_node.GetString("CRR_CMF_16");
                cdvCMF17.Text = out_node.GetString("CRR_CMF_17");
                cdvCMF18.Text = out_node.GetString("CRR_CMF_18");
                cdvCMF19.Text = out_node.GetString("CRR_CMF_19");
                cdvCMF20.Text = out_node.GetString("CRR_CMF_20");
            
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtCarrierID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASSetupCarrier_Activated(object sender, System.EventArgs e)
        {
            
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this, rbnFilter);
                MPCF.FieldVisible(tbpCMF, false);
                MPCF.InitListView(lisCarrier);

                dtpPlanTermDate.Value = DateTime.Now;
                dtpPlanTermTime.Value = MPCF.ToDate(MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATE_FORMAT) + MPGV.gShiftInfor.sShift1StartTime);
                
                MPCR.SetCMFItem(MPGC.MP_CMF_CARRIER, "lblCmf", "cdvCmf", grpCMF);

                //btnRefresh.PerformClick();
                
                b_load_flag = true;
                
            }
            
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("CREATE") == true)
                {
                    if (CreateCarrier() == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (rbnNoFilter.Checked == true)
                        {
                            if (MPGO.RequireCarrierFilter() == true)
                            {
                                txtFilter.Text = txtCarrierID.Text;
                            }
                        }
                        
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("CREATE") == true)
                {
                    if (UpdateCarrier() == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("DELETE") == true)
                {
                    if (TerminateCarrier() == true)
                    {
                        MPCF.FieldClear(this.pnlRight);
                        if (MPGV.gbListAutoRefresh == true)
                        {
                            btnRefresh.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void btnFilterView_Click(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                //Add by J.S. 2008.12.23 필트를 제대로 처리하게 수정
                string s_filter;

                lblDataCount.Text = "";
                MPCF.FieldClear(pnlRight, txtCarrierID);

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

                    s_filter = MPCF.RTrim(txtFilter.Text);
                }
                else
                {
                    s_filter = "";
                }

                if (RASLIST.ViewCarrierList(lisCarrier, '1', cdvGroup.Text, "", s_filter) == true)
                {
                    MPCF.FitColumnHeader(lisCarrier);
                    lblDataCount.Text = MPCF.Trim(lisCarrier.Items.Count);
                }

                if (lisCarrier.Items.Count > 0)
                {
                    if (s_filter != "")
                    {
                        MPCF.FindListItem(lisCarrier, s_filter, false);
                    }
                    else if(MPCF.RTrim(txtCarrierID.Text) != "")
                    {
                        MPCF.FindListItem(lisCarrier, MPCF.RTrim(txtCarrierID.Text), false);
                    }
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
        
        private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            MPCR.ProcGRPCMFButtonPress(sender);
            
        }
        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            MPCR.CheckCMFKeyPress(sender, e);
            
        }
        
        private void cdvCrrType1_ButtonPress(object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
            
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            //MP_RAS_CRR_TYPE
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
            if (cdvTemp.AddEmptyRow(1) == false)
            {
                return;
            }
            
        }
        private void cdvCrrType2_ButtonPress(object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
            
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            //MP_RAS_CRR_TYPE
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_RAS_CRR_TYPE2);
            if (cdvTemp.AddEmptyRow(1) == false)
            {
                return;
            }
            
        }
        private void cdvCrrType3_ButtonPress(object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
            
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            //MP_RAS_CRR_TYPE
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_RAS_CRR_TYPE3);
            if (cdvTemp.AddEmptyRow(1) == false)
            {
                return;
            }
            
        }
        private void cdvAreaID_ButtonPress(object sender, System.EventArgs e)
        {
            
            cdvAreaID.Init();
            MPCF.InitListView(cdvAreaID.GetListView);
            cdvAreaID.Columns.Add("AreaID", 50, HorizontalAlignment.Left);
            cdvAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAreaID.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvAreaID.GetListView, '1', MPGC.MP_RAS_AREA_CODE) == false)
            {
                return;
            }
            
        }
        
        private void cdvSubAreaID_ButtonPress(object sender, System.EventArgs e)
        {
            //Modify by J.S. 2008.12.23 만약 area가 먼저 선택된경우 종속된 subarea만 보이게 한다.
            if (MPCF.RTrim(cdvAreaID.Text) == "")
            {
                cdvSubAreaID.Init();
                MPCF.InitListView(cdvSubAreaID.GetListView);
                cdvSubAreaID.Columns.Add("SubAreaID", 50, HorizontalAlignment.Left);
                cdvSubAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvSubAreaID.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvSubAreaID.GetListView, '1', MPGC.MP_RAS_SUBAREA_CODE) == false)
                {
                    return;
                }
            }
            else
            {
                cdvSubAreaID.Init();
                MPCF.InitListView(cdvSubAreaID.GetListView);
                cdvSubAreaID.Columns.Add("SubAreaID", 50, HorizontalAlignment.Left);
                cdvSubAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvSubAreaID.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList_AREA(cdvSubAreaID.GetListView, '1', MPGC.MP_RAS_SUBAREA_CODE, -1, null, "", false, -1, -1,null, cdvAreaID.Text) == false)
                {
                    return;
                }
            }

        }
        private void cdvResourceID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResourceID.Init();
            MPCF.InitListView(cdvResourceID.GetListView);
            cdvResourceID.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvResourceID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResourceID.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResourceID.GetListView, false);
            if (cdvResourceID.AddEmptyRow(1) == false)
            {
                return;
            }
            
        }

        private void lisCarrier_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FieldClear(this.pnlRight);
            if (lisCarrier.SelectedItems.Count > 0)
            {
                txtCarrierID.Text = lisCarrier.SelectedItems[0].Text;
                if (MPGV.gbListAutoRefresh == true)
                {
                    if (rbnNoFilter.Checked == true)
                    {
                        if (MPGO.RequireCarrierFilter() == true)
                        {
                            txtFilter.Text = txtCarrierID.Text;
                        }
                    }
                }

                ViewCarrier();
            }
            
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

        private void cdvCrrGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvCrrGroup.Init();
            MPCF.InitListView(cdvCrrGroup.GetListView);
            cdvCrrGroup.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvCrrGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrGroup.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierGroupList(cdvCrrGroup.GetListView);
        }

        private void chkPlanTerminate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlanTerminate.Checked == true)
            {
                dtpPlanTermDate.Value = DateTime.Now;
                dtpPlanTermTime.Value = MPCF.ToDate(MPCF.ToStandardTime(DateTime.Now, MPGC.MP_CONVERT_DATE_FORMAT) + MPGV.gShiftInfor.sShift1StartTime);

                dtpPlanTermDate.Visible = true;
                dtpPlanTermTime.Visible = true;
            }
            else
            {
                dtpPlanTermDate.Visible = false;
                dtpPlanTermTime.Visible = false;
            }
        }

        private void cdvUsageLimitAlarm_ButtonPress(object sender, EventArgs e)
        {
            cdvUsageLimitAlarm.Init();
            MPCF.InitListView(cdvUsageLimitAlarm.GetListView);
            cdvUsageLimitAlarm.Columns.Add("Alarm ID", 50, HorizontalAlignment.Left);
            cdvUsageLimitAlarm.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            ALMLIST.ViewAlarmMsgList(cdvUsageLimitAlarm.GetListView, '1', 'N');
            cdvUsageLimitAlarm.InsertEmptyRow(0, 1);
        }

        private void cdvCleanLimitAlarm_ButtonPress(object sender, EventArgs e)
        {
            cdvCleanLimitAlarm.Init();
            MPCF.InitListView(cdvCleanLimitAlarm.GetListView);
            cdvCleanLimitAlarm.Columns.Add("Alarm ID", 50, HorizontalAlignment.Left);
            cdvCleanLimitAlarm.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            ALMLIST.ViewAlarmMsgList(cdvCleanLimitAlarm.GetListView, '1', 'N');
            cdvCleanLimitAlarm.InsertEmptyRow(0, 1);
        }
    }
    
    //#End If '_CRR
    
}
