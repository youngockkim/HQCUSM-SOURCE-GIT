
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.H101Core;
using Miracom.Stat;
using Miracom.MESCore;
using Miracom.UI.Controls;

//#If _SPC = True Then


namespace Miracom.SPCCore
{
    public class frmSPCTranEvent : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranEvent()
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
        



        internal System.Windows.Forms.Panel pnlRes;
        internal System.Windows.Forms.GroupBox grpEvent;
        internal System.Windows.Forms.TextBox txtEventDesc;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvEventID;
        internal System.Windows.Forms.Label lblEventID;
        internal System.Windows.Forms.GroupBox grpResource;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        internal System.Windows.Forms.Label lblDesc;
        internal System.Windows.Forms.Label lblResource;
        internal System.Windows.Forms.TextBox txtDesc;
        internal System.Windows.Forms.Panel pnlMain;
        internal System.Windows.Forms.TabControl tabResource;
        internal System.Windows.Forms.TabPage tbpResStatus;
        internal System.Windows.Forms.TabPage tbpGeneral;
        internal System.Windows.Forms.GroupBox grpGeneral;
        internal System.Windows.Forms.TextBox txtProcMode;
        internal System.Windows.Forms.TextBox txtAreaID;
        internal System.Windows.Forms.TextBox txtSubAreaID;
        internal System.Windows.Forms.TextBox txtProcessRule;
        internal System.Windows.Forms.TextBox txtResourceType;
        internal System.Windows.Forms.Label lblProcMode;
        internal System.Windows.Forms.Label lblUpdateTime;
        internal System.Windows.Forms.Label lblUpdateUser;
        internal System.Windows.Forms.TextBox txtUpdateTime;
        internal System.Windows.Forms.TextBox txtUpdateUser;
        internal System.Windows.Forms.TextBox txtMaxProcCount;
        internal System.Windows.Forms.Label lblMaxProcCount;
        internal System.Windows.Forms.Label lblProcRule;
        internal System.Windows.Forms.TextBox txtLocation;
        internal System.Windows.Forms.Label lblLocation;
        internal System.Windows.Forms.Label lblSubAreaID;
        internal System.Windows.Forms.Label lblAreaID;
        internal System.Windows.Forms.Label lblResType;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        internal System.Windows.Forms.Label lblCMF10;
        internal System.Windows.Forms.Label lblCMF9;
        internal System.Windows.Forms.Label lblCMF8;
        internal System.Windows.Forms.Label lblCMF7;
        internal System.Windows.Forms.Label lblCMF6;
        internal System.Windows.Forms.Label lblCMF5;
        internal System.Windows.Forms.Label lblCMF4;
        internal System.Windows.Forms.Label lblCMF3;
        internal System.Windows.Forms.Label lblCMF2;
        internal System.Windows.Forms.Label lblCMF1;
        internal System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.Label lblCMF;
        internal System.Windows.Forms.TextBox txtLastEvent;
        internal System.Windows.Forms.Label lblLastEvent;
        internal System.Windows.Forms.TextBox txtLastEventTime;
        internal System.Windows.Forms.Label lblLastEventTime;
        protected System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.Label lblComment;
        protected System.Windows.Forms.Panel pnlTranTime;
        protected System.Windows.Forms.TextBox txtTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranTime;
        protected System.Windows.Forms.CheckBox chkTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranDate;
        internal System.Windows.Forms.TextBox txtCtrlMode;
        internal System.Windows.Forms.Label lblCtrlMode;
        internal System.Windows.Forms.GroupBox grpCurrentStatus;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus10;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus9;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus8;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus7;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus6;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus5;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus4;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus3;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus2;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChangeStatus1;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrimaryChange;
        internal System.Windows.Forms.TextBox txtChangeUpDown;
        internal System.Windows.Forms.TextBox txtPrimaryCurrent;
        internal System.Windows.Forms.TextBox txtCurrentStatus10;
        internal System.Windows.Forms.TextBox txtCurrentStatus9;
        internal System.Windows.Forms.TextBox txtCurrentStatus8;
        internal System.Windows.Forms.TextBox txtCurrentStatus7;
        internal System.Windows.Forms.TextBox txtCurrentStatus6;
        internal System.Windows.Forms.TextBox txtCurrentStatus5;
        internal System.Windows.Forms.TextBox txtCurrentStatus4;
        internal System.Windows.Forms.TextBox txtCurrentStatus3;
        internal System.Windows.Forms.TextBox txtCurrentStatus2;
        internal System.Windows.Forms.TextBox txtCurrentStatus1;
        internal System.Windows.Forms.TextBox txtCurrentUpDown;
        internal System.Windows.Forms.Label lblPrimaryStatus;
        internal System.Windows.Forms.Label lblCurrentStatus10;
        internal System.Windows.Forms.Label lblCurrentStatus9;
        internal System.Windows.Forms.Label lblCurrentStatus8;
        internal System.Windows.Forms.Label lblCurrentStatus7;
        internal System.Windows.Forms.Label lblCurrentStatus6;
        internal System.Windows.Forms.Label lblCurrentStatus5;
        internal System.Windows.Forms.Label lblCurrentStatus4;
        internal System.Windows.Forms.Label lblCurrentStatus3;
        internal System.Windows.Forms.Label lblCurrentStatus2;
        internal System.Windows.Forms.Label lblCurrentStatus1;
        internal System.Windows.Forms.Label lblUpDown;
        internal System.Windows.Forms.GroupBox grpChart;
        internal System.Windows.Forms.Label lblGraphType;
        internal System.Windows.Forms.Label lblChartID;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboGraphType;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtChartID;
        internal System.Windows.Forms.TabPage tbpSPCResData;
        internal System.Windows.Forms.Panel pnlChartSet;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlRes = new System.Windows.Forms.Panel();
            this.grpEvent = new System.Windows.Forms.GroupBox();
            this.txtEventDesc = new System.Windows.Forms.TextBox();
            this.cdvEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEventID = new System.Windows.Forms.Label();
            this.grpResource = new System.Windows.Forms.GroupBox();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranDateTime = new System.Windows.Forms.TextBox();
            this.dtpTranTime = new System.Windows.Forms.DateTimePicker();
            this.chkTranDateTime = new System.Windows.Forms.CheckBox();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.txtLastEventTime = new System.Windows.Forms.TextBox();
            this.lblLastEventTime = new System.Windows.Forms.Label();
            this.txtLastEvent = new System.Windows.Forms.TextBox();
            this.lblLastEvent = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblResource = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tabResource = new System.Windows.Forms.TabControl();
            this.tbpResStatus = new System.Windows.Forms.TabPage();
            this.grpCurrentStatus = new System.Windows.Forms.GroupBox();
            this.cdvChangeStatus10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvChangeStatus1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvPrimaryChange = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtChangeUpDown = new System.Windows.Forms.TextBox();
            this.txtPrimaryCurrent = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus10 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus9 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus8 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus7 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus6 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus5 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus4 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus3 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus2 = new System.Windows.Forms.TextBox();
            this.txtCurrentStatus1 = new System.Windows.Forms.TextBox();
            this.txtCurrentUpDown = new System.Windows.Forms.TextBox();
            this.lblPrimaryStatus = new System.Windows.Forms.Label();
            this.lblCurrentStatus10 = new System.Windows.Forms.Label();
            this.lblCurrentStatus9 = new System.Windows.Forms.Label();
            this.lblCurrentStatus8 = new System.Windows.Forms.Label();
            this.lblCurrentStatus7 = new System.Windows.Forms.Label();
            this.lblCurrentStatus6 = new System.Windows.Forms.Label();
            this.lblCurrentStatus5 = new System.Windows.Forms.Label();
            this.lblCurrentStatus4 = new System.Windows.Forms.Label();
            this.lblCurrentStatus3 = new System.Windows.Forms.Label();
            this.lblCurrentStatus2 = new System.Windows.Forms.Label();
            this.lblCurrentStatus1 = new System.Windows.Forms.Label();
            this.lblUpDown = new System.Windows.Forms.Label();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
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
            this.txtProcMode = new System.Windows.Forms.TextBox();
            this.txtAreaID = new System.Windows.Forms.TextBox();
            this.txtSubAreaID = new System.Windows.Forms.TextBox();
            this.txtProcessRule = new System.Windows.Forms.TextBox();
            this.txtResourceType = new System.Windows.Forms.TextBox();
            this.lblProcMode = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtMaxProcCount = new System.Windows.Forms.TextBox();
            this.lblMaxProcCount = new System.Windows.Forms.Label();
            this.lblProcRule = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblSubAreaID = new System.Windows.Forms.Label();
            this.lblAreaID = new System.Windows.Forms.Label();
            this.txtCtrlMode = new System.Windows.Forms.TextBox();
            this.lblCtrlMode = new System.Windows.Forms.Label();
            this.lblResType = new System.Windows.Forms.Label();
            this.lblCMF = new System.Windows.Forms.Label();
            this.tbpSPCResData = new System.Windows.Forms.TabPage();
            this.pnlChartSet = new System.Windows.Forms.Panel();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.txtChartID = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblGraphType = new System.Windows.Forms.Label();
            this.lblChartID = new System.Windows.Forms.Label();
            this.cboGraphType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlRes.SuspendLayout();
            this.grpEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).BeginInit();
            this.grpResource.SuspendLayout();
            this.pnlTranTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tabResource.SuspendLayout();
            this.tbpResStatus.SuspendLayout();
            this.grpCurrentStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrimaryChange)).BeginInit();
            this.grpComment.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            this.tbpSPCResData.SuspendLayout();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMain);
            this.pnlCenter.Controls.Add(this.pnlRes);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Event";
            // 
            // pnlRes
            // 
            this.pnlRes.Controls.Add(this.grpEvent);
            this.pnlRes.Controls.Add(this.grpResource);
            this.pnlRes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRes.Location = new System.Drawing.Point(0, 0);
            this.pnlRes.Name = "pnlRes";
            this.pnlRes.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRes.Size = new System.Drawing.Size(742, 140);
            this.pnlRes.TabIndex = 0;
            // 
            // grpEvent
            // 
            this.grpEvent.Controls.Add(this.txtEventDesc);
            this.grpEvent.Controls.Add(this.cdvEventID);
            this.grpEvent.Controls.Add(this.lblEventID);
            this.grpEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpEvent.Location = new System.Drawing.Point(3, 95);
            this.grpEvent.Name = "grpEvent";
            this.grpEvent.Size = new System.Drawing.Size(736, 45);
            this.grpEvent.TabIndex = 1;
            this.grpEvent.TabStop = false;
            // 
            // txtEventDesc
            // 
            this.txtEventDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventDesc.Location = new System.Drawing.Point(328, 14);
            this.txtEventDesc.Name = "txtEventDesc";
            this.txtEventDesc.ReadOnly = true;
            this.txtEventDesc.Size = new System.Drawing.Size(396, 20);
            this.txtEventDesc.TabIndex = 2;
            this.txtEventDesc.TabStop = false;
            // 
            // cdvEventID
            // 
            this.cdvEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEventID.BtnToolTipText = "";
            this.cdvEventID.DescText = "";
            this.cdvEventID.DisplaySubItemIndex = -1;
            this.cdvEventID.DisplayText = "";
            this.cdvEventID.Focusing = null;
            this.cdvEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEventID.Index = 0;
            this.cdvEventID.IsViewBtnImage = false;
            this.cdvEventID.Location = new System.Drawing.Point(120, 14);
            this.cdvEventID.MaxLength = 12;
            this.cdvEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.Name = "cdvEventID";
            this.cdvEventID.ReadOnly = false;
            this.cdvEventID.SearchSubItemIndex = 0;
            this.cdvEventID.SelectedDescIndex = -1;
            this.cdvEventID.SelectedSubItemIndex = -1;
            this.cdvEventID.SelectionStart = 0;
            this.cdvEventID.Size = new System.Drawing.Size(200, 20);
            this.cdvEventID.SmallImageList = null;
            this.cdvEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEventID.TabIndex = 1;
            this.cdvEventID.TextBoxToolTipText = "";
            this.cdvEventID.TextBoxWidth = 200;
            this.cdvEventID.VisibleButton = true;
            this.cdvEventID.VisibleColumnHeader = false;
            this.cdvEventID.VisibleDescription = false;
            this.cdvEventID.TextBoxTextChanged += new System.EventHandler(this.cdvEventID_TextBoxTextChanged);
            this.cdvEventID.ButtonPress += new System.EventHandler(this.cdvEventID_ButtonPress);
            this.cdvEventID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvEventID_SelectedItemChanged);
            // 
            // lblEventID
            // 
            this.lblEventID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEventID.Location = new System.Drawing.Point(15, 17);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(55, 14);
            this.lblEventID.TabIndex = 0;
            this.lblEventID.Text = "Event ID";
            // 
            // grpResource
            // 
            this.grpResource.Controls.Add(this.pnlTranTime);
            this.grpResource.Controls.Add(this.txtLastEventTime);
            this.grpResource.Controls.Add(this.lblLastEventTime);
            this.grpResource.Controls.Add(this.txtLastEvent);
            this.grpResource.Controls.Add(this.lblLastEvent);
            this.grpResource.Controls.Add(this.cdvResID);
            this.grpResource.Controls.Add(this.lblDesc);
            this.grpResource.Controls.Add(this.lblResource);
            this.grpResource.Controls.Add(this.txtDesc);
            this.grpResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResource.Location = new System.Drawing.Point(3, 0);
            this.grpResource.Name = "grpResource";
            this.grpResource.Size = new System.Drawing.Size(736, 95);
            this.grpResource.TabIndex = 0;
            this.grpResource.TabStop = false;
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranTime.Controls.Add(this.txtTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranTime);
            this.pnlTranTime.Controls.Add(this.chkTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranDate);
            this.pnlTranTime.Location = new System.Drawing.Point(428, 13);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 23);
            this.pnlTranTime.TabIndex = 2;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.Location = new System.Drawing.Point(139, 1);
            this.txtTranDateTime.Name = "txtTranDateTime";
            this.txtTranDateTime.ReadOnly = true;
            this.txtTranDateTime.Size = new System.Drawing.Size(157, 20);
            this.txtTranDateTime.TabIndex = 12;
            this.txtTranDateTime.TabStop = false;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTranTime.Checked = false;
            this.dtpTranTime.CustomFormat = "HH:mm:ss";
            this.dtpTranTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTranTime.Location = new System.Drawing.Point(225, 1);
            this.dtpTranTime.Name = "dtpTranTime";
            this.dtpTranTime.ShowUpDown = true;
            this.dtpTranTime.Size = new System.Drawing.Size(71, 20);
            this.dtpTranTime.TabIndex = 11;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTranDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTranDateTime.Location = new System.Drawing.Point(3, 3);
            this.chkTranDateTime.Name = "chkTranDateTime";
            this.chkTranDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTranDateTime.Size = new System.Drawing.Size(124, 17);
            this.chkTranDateTime.TabIndex = 10;
            this.chkTranDateTime.Text = "Transaction Time";
            this.chkTranDateTime.CheckedChanged += new System.EventHandler(this.chkTranDateTime_CheckedChanged);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTranDate.Checked = false;
            this.dtpTranDate.CustomFormat = "";
            this.dtpTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTranDate.Location = new System.Drawing.Point(139, 1);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(86, 20);
            this.dtpTranDate.TabIndex = 9;
            // 
            // txtLastEventTime
            // 
            this.txtLastEventTime.Location = new System.Drawing.Point(567, 64);
            this.txtLastEventTime.Name = "txtLastEventTime";
            this.txtLastEventTime.ReadOnly = true;
            this.txtLastEventTime.Size = new System.Drawing.Size(157, 20);
            this.txtLastEventTime.TabIndex = 8;
            this.txtLastEventTime.TabStop = false;
            // 
            // lblLastEventTime
            // 
            this.lblLastEventTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEventTime.Location = new System.Drawing.Point(432, 66);
            this.lblLastEventTime.Name = "lblLastEventTime";
            this.lblLastEventTime.Size = new System.Drawing.Size(124, 15);
            this.lblLastEventTime.TabIndex = 7;
            this.lblLastEventTime.Text = "Last Event Time";
            // 
            // txtLastEvent
            // 
            this.txtLastEvent.Location = new System.Drawing.Point(120, 64);
            this.txtLastEvent.Name = "txtLastEvent";
            this.txtLastEvent.ReadOnly = true;
            this.txtLastEvent.Size = new System.Drawing.Size(200, 20);
            this.txtLastEvent.TabIndex = 6;
            this.txtLastEvent.TabStop = false;
            // 
            // lblLastEvent
            // 
            this.lblLastEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEvent.Location = new System.Drawing.Point(15, 67);
            this.lblLastEvent.Name = "lblLastEvent";
            this.lblLastEvent.Size = new System.Drawing.Size(100, 14);
            this.lblLastEvent.TabIndex = 5;
            this.lblLastEvent.Text = "Last Event";
            // 
            // cdvResID
            // 
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(120, 16);
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
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResID_KeyPress);
            // 
            // lblDesc
            // 
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 14);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "Description";
            // 
            // lblResource
            // 
            this.lblResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResource.Location = new System.Drawing.Point(15, 19);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(100, 14);
            this.lblResource.TabIndex = 0;
            this.lblResource.Text = "Resource ID";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(604, 20);
            this.txtDesc.TabIndex = 4;
            this.txtDesc.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabResource);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 140);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlMain.Size = new System.Drawing.Size(742, 373);
            this.pnlMain.TabIndex = 1;
            // 
            // tabResource
            // 
            this.tabResource.Controls.Add(this.tbpResStatus);
            this.tabResource.Controls.Add(this.tbpGeneral);
            this.tabResource.Controls.Add(this.tbpSPCResData);
            this.tabResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResource.ItemSize = new System.Drawing.Size(60, 18);
            this.tabResource.Location = new System.Drawing.Point(3, 5);
            this.tabResource.Name = "tabResource";
            this.tabResource.SelectedIndex = 0;
            this.tabResource.Size = new System.Drawing.Size(736, 365);
            this.tabResource.TabIndex = 0;
            // 
            // tbpResStatus
            // 
            this.tbpResStatus.Controls.Add(this.grpCurrentStatus);
            this.tbpResStatus.Controls.Add(this.grpComment);
            this.tbpResStatus.Location = new System.Drawing.Point(4, 22);
            this.tbpResStatus.Name = "tbpResStatus";
            this.tbpResStatus.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpResStatus.Size = new System.Drawing.Size(728, 339);
            this.tbpResStatus.TabIndex = 5;
            this.tbpResStatus.Text = "Resource Status";
            // 
            // grpCurrentStatus
            // 
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus10);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus9);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus8);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus7);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus6);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus5);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus4);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus3);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus2);
            this.grpCurrentStatus.Controls.Add(this.cdvChangeStatus1);
            this.grpCurrentStatus.Controls.Add(this.cdvPrimaryChange);
            this.grpCurrentStatus.Controls.Add(this.txtChangeUpDown);
            this.grpCurrentStatus.Controls.Add(this.txtPrimaryCurrent);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus10);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus9);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus8);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus7);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus6);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus5);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus4);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus3);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus2);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentStatus1);
            this.grpCurrentStatus.Controls.Add(this.txtCurrentUpDown);
            this.grpCurrentStatus.Controls.Add(this.lblPrimaryStatus);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus10);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus9);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus8);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus7);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus6);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus5);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus4);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus3);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus2);
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus1);
            this.grpCurrentStatus.Controls.Add(this.lblUpDown);
            this.grpCurrentStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCurrentStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCurrentStatus.Location = new System.Drawing.Point(3, 0);
            this.grpCurrentStatus.Name = "grpCurrentStatus";
            this.grpCurrentStatus.Size = new System.Drawing.Size(722, 290);
            this.grpCurrentStatus.TabIndex = 0;
            this.grpCurrentStatus.TabStop = false;
            // 
            // cdvChangeStatus10
            // 
            this.cdvChangeStatus10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus10.BtnToolTipText = "";
            this.cdvChangeStatus10.DescText = "";
            this.cdvChangeStatus10.DisplaySubItemIndex = -1;
            this.cdvChangeStatus10.DisplayText = "";
            this.cdvChangeStatus10.Focusing = null;
            this.cdvChangeStatus10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus10.Index = 0;
            this.cdvChangeStatus10.IsViewBtnImage = false;
            this.cdvChangeStatus10.Location = new System.Drawing.Point(384, 256);
            this.cdvChangeStatus10.MaxLength = 32767;
            this.cdvChangeStatus10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus10.Name = "cdvChangeStatus10";
            this.cdvChangeStatus10.ReadOnly = false;
            this.cdvChangeStatus10.SearchSubItemIndex = 0;
            this.cdvChangeStatus10.SelectedDescIndex = -1;
            this.cdvChangeStatus10.SelectedSubItemIndex = -1;
            this.cdvChangeStatus10.SelectionStart = 0;
            this.cdvChangeStatus10.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus10.SmallImageList = null;
            this.cdvChangeStatus10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus10.TabIndex = 35;
            this.cdvChangeStatus10.TextBoxToolTipText = "";
            this.cdvChangeStatus10.TextBoxWidth = 176;
            this.cdvChangeStatus10.VisibleButton = true;
            this.cdvChangeStatus10.VisibleColumnHeader = false;
            this.cdvChangeStatus10.VisibleDescription = false;
            this.cdvChangeStatus10.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus9
            // 
            this.cdvChangeStatus9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus9.BtnToolTipText = "";
            this.cdvChangeStatus9.DescText = "";
            this.cdvChangeStatus9.DisplaySubItemIndex = -1;
            this.cdvChangeStatus9.DisplayText = "";
            this.cdvChangeStatus9.Focusing = null;
            this.cdvChangeStatus9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus9.Index = 0;
            this.cdvChangeStatus9.IsViewBtnImage = false;
            this.cdvChangeStatus9.Location = new System.Drawing.Point(384, 234);
            this.cdvChangeStatus9.MaxLength = 32767;
            this.cdvChangeStatus9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus9.Name = "cdvChangeStatus9";
            this.cdvChangeStatus9.ReadOnly = false;
            this.cdvChangeStatus9.SearchSubItemIndex = 0;
            this.cdvChangeStatus9.SelectedDescIndex = -1;
            this.cdvChangeStatus9.SelectedSubItemIndex = -1;
            this.cdvChangeStatus9.SelectionStart = 0;
            this.cdvChangeStatus9.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus9.SmallImageList = null;
            this.cdvChangeStatus9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus9.TabIndex = 32;
            this.cdvChangeStatus9.TextBoxToolTipText = "";
            this.cdvChangeStatus9.TextBoxWidth = 176;
            this.cdvChangeStatus9.VisibleButton = true;
            this.cdvChangeStatus9.VisibleColumnHeader = false;
            this.cdvChangeStatus9.VisibleDescription = false;
            this.cdvChangeStatus9.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus8
            // 
            this.cdvChangeStatus8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus8.BtnToolTipText = "";
            this.cdvChangeStatus8.DescText = "";
            this.cdvChangeStatus8.DisplaySubItemIndex = -1;
            this.cdvChangeStatus8.DisplayText = "";
            this.cdvChangeStatus8.Focusing = null;
            this.cdvChangeStatus8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus8.Index = 0;
            this.cdvChangeStatus8.IsViewBtnImage = false;
            this.cdvChangeStatus8.Location = new System.Drawing.Point(384, 212);
            this.cdvChangeStatus8.MaxLength = 32767;
            this.cdvChangeStatus8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus8.Name = "cdvChangeStatus8";
            this.cdvChangeStatus8.ReadOnly = false;
            this.cdvChangeStatus8.SearchSubItemIndex = 0;
            this.cdvChangeStatus8.SelectedDescIndex = -1;
            this.cdvChangeStatus8.SelectedSubItemIndex = -1;
            this.cdvChangeStatus8.SelectionStart = 0;
            this.cdvChangeStatus8.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus8.SmallImageList = null;
            this.cdvChangeStatus8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus8.TabIndex = 29;
            this.cdvChangeStatus8.TextBoxToolTipText = "";
            this.cdvChangeStatus8.TextBoxWidth = 176;
            this.cdvChangeStatus8.VisibleButton = true;
            this.cdvChangeStatus8.VisibleColumnHeader = false;
            this.cdvChangeStatus8.VisibleDescription = false;
            this.cdvChangeStatus8.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus7
            // 
            this.cdvChangeStatus7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus7.BtnToolTipText = "";
            this.cdvChangeStatus7.DescText = "";
            this.cdvChangeStatus7.DisplaySubItemIndex = -1;
            this.cdvChangeStatus7.DisplayText = "";
            this.cdvChangeStatus7.Focusing = null;
            this.cdvChangeStatus7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus7.Index = 0;
            this.cdvChangeStatus7.IsViewBtnImage = false;
            this.cdvChangeStatus7.Location = new System.Drawing.Point(384, 190);
            this.cdvChangeStatus7.MaxLength = 32767;
            this.cdvChangeStatus7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus7.Name = "cdvChangeStatus7";
            this.cdvChangeStatus7.ReadOnly = false;
            this.cdvChangeStatus7.SearchSubItemIndex = 0;
            this.cdvChangeStatus7.SelectedDescIndex = -1;
            this.cdvChangeStatus7.SelectedSubItemIndex = -1;
            this.cdvChangeStatus7.SelectionStart = 0;
            this.cdvChangeStatus7.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus7.SmallImageList = null;
            this.cdvChangeStatus7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus7.TabIndex = 26;
            this.cdvChangeStatus7.TextBoxToolTipText = "";
            this.cdvChangeStatus7.TextBoxWidth = 176;
            this.cdvChangeStatus7.VisibleButton = true;
            this.cdvChangeStatus7.VisibleColumnHeader = false;
            this.cdvChangeStatus7.VisibleDescription = false;
            this.cdvChangeStatus7.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus6
            // 
            this.cdvChangeStatus6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus6.BtnToolTipText = "";
            this.cdvChangeStatus6.DescText = "";
            this.cdvChangeStatus6.DisplaySubItemIndex = -1;
            this.cdvChangeStatus6.DisplayText = "";
            this.cdvChangeStatus6.Focusing = null;
            this.cdvChangeStatus6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus6.Index = 0;
            this.cdvChangeStatus6.IsViewBtnImage = false;
            this.cdvChangeStatus6.Location = new System.Drawing.Point(384, 168);
            this.cdvChangeStatus6.MaxLength = 32767;
            this.cdvChangeStatus6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus6.Name = "cdvChangeStatus6";
            this.cdvChangeStatus6.ReadOnly = false;
            this.cdvChangeStatus6.SearchSubItemIndex = 0;
            this.cdvChangeStatus6.SelectedDescIndex = -1;
            this.cdvChangeStatus6.SelectedSubItemIndex = -1;
            this.cdvChangeStatus6.SelectionStart = 0;
            this.cdvChangeStatus6.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus6.SmallImageList = null;
            this.cdvChangeStatus6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus6.TabIndex = 23;
            this.cdvChangeStatus6.TextBoxToolTipText = "";
            this.cdvChangeStatus6.TextBoxWidth = 176;
            this.cdvChangeStatus6.VisibleButton = true;
            this.cdvChangeStatus6.VisibleColumnHeader = false;
            this.cdvChangeStatus6.VisibleDescription = false;
            this.cdvChangeStatus6.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus5
            // 
            this.cdvChangeStatus5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus5.BtnToolTipText = "";
            this.cdvChangeStatus5.DescText = "";
            this.cdvChangeStatus5.DisplaySubItemIndex = -1;
            this.cdvChangeStatus5.DisplayText = "";
            this.cdvChangeStatus5.Focusing = null;
            this.cdvChangeStatus5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus5.Index = 0;
            this.cdvChangeStatus5.IsViewBtnImage = false;
            this.cdvChangeStatus5.Location = new System.Drawing.Point(384, 146);
            this.cdvChangeStatus5.MaxLength = 32767;
            this.cdvChangeStatus5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus5.Name = "cdvChangeStatus5";
            this.cdvChangeStatus5.ReadOnly = false;
            this.cdvChangeStatus5.SearchSubItemIndex = 0;
            this.cdvChangeStatus5.SelectedDescIndex = -1;
            this.cdvChangeStatus5.SelectedSubItemIndex = -1;
            this.cdvChangeStatus5.SelectionStart = 0;
            this.cdvChangeStatus5.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus5.SmallImageList = null;
            this.cdvChangeStatus5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus5.TabIndex = 20;
            this.cdvChangeStatus5.TextBoxToolTipText = "";
            this.cdvChangeStatus5.TextBoxWidth = 176;
            this.cdvChangeStatus5.VisibleButton = true;
            this.cdvChangeStatus5.VisibleColumnHeader = false;
            this.cdvChangeStatus5.VisibleDescription = false;
            this.cdvChangeStatus5.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus4
            // 
            this.cdvChangeStatus4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus4.BtnToolTipText = "";
            this.cdvChangeStatus4.DescText = "";
            this.cdvChangeStatus4.DisplaySubItemIndex = -1;
            this.cdvChangeStatus4.DisplayText = "";
            this.cdvChangeStatus4.Focusing = null;
            this.cdvChangeStatus4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus4.Index = 0;
            this.cdvChangeStatus4.IsViewBtnImage = false;
            this.cdvChangeStatus4.Location = new System.Drawing.Point(384, 124);
            this.cdvChangeStatus4.MaxLength = 32767;
            this.cdvChangeStatus4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus4.Name = "cdvChangeStatus4";
            this.cdvChangeStatus4.ReadOnly = false;
            this.cdvChangeStatus4.SearchSubItemIndex = 0;
            this.cdvChangeStatus4.SelectedDescIndex = -1;
            this.cdvChangeStatus4.SelectedSubItemIndex = -1;
            this.cdvChangeStatus4.SelectionStart = 0;
            this.cdvChangeStatus4.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus4.SmallImageList = null;
            this.cdvChangeStatus4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus4.TabIndex = 17;
            this.cdvChangeStatus4.TextBoxToolTipText = "";
            this.cdvChangeStatus4.TextBoxWidth = 176;
            this.cdvChangeStatus4.VisibleButton = true;
            this.cdvChangeStatus4.VisibleColumnHeader = false;
            this.cdvChangeStatus4.VisibleDescription = false;
            this.cdvChangeStatus4.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus3
            // 
            this.cdvChangeStatus3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus3.BtnToolTipText = "";
            this.cdvChangeStatus3.DescText = "";
            this.cdvChangeStatus3.DisplaySubItemIndex = -1;
            this.cdvChangeStatus3.DisplayText = "";
            this.cdvChangeStatus3.Focusing = null;
            this.cdvChangeStatus3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus3.Index = 0;
            this.cdvChangeStatus3.IsViewBtnImage = false;
            this.cdvChangeStatus3.Location = new System.Drawing.Point(384, 102);
            this.cdvChangeStatus3.MaxLength = 32767;
            this.cdvChangeStatus3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus3.Name = "cdvChangeStatus3";
            this.cdvChangeStatus3.ReadOnly = false;
            this.cdvChangeStatus3.SearchSubItemIndex = 0;
            this.cdvChangeStatus3.SelectedDescIndex = -1;
            this.cdvChangeStatus3.SelectedSubItemIndex = -1;
            this.cdvChangeStatus3.SelectionStart = 0;
            this.cdvChangeStatus3.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus3.SmallImageList = null;
            this.cdvChangeStatus3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus3.TabIndex = 14;
            this.cdvChangeStatus3.TextBoxToolTipText = "";
            this.cdvChangeStatus3.TextBoxWidth = 176;
            this.cdvChangeStatus3.VisibleButton = true;
            this.cdvChangeStatus3.VisibleColumnHeader = false;
            this.cdvChangeStatus3.VisibleDescription = false;
            this.cdvChangeStatus3.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus2
            // 
            this.cdvChangeStatus2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus2.BtnToolTipText = "";
            this.cdvChangeStatus2.DescText = "";
            this.cdvChangeStatus2.DisplaySubItemIndex = -1;
            this.cdvChangeStatus2.DisplayText = "";
            this.cdvChangeStatus2.Focusing = null;
            this.cdvChangeStatus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus2.Index = 0;
            this.cdvChangeStatus2.IsViewBtnImage = false;
            this.cdvChangeStatus2.Location = new System.Drawing.Point(384, 80);
            this.cdvChangeStatus2.MaxLength = 32767;
            this.cdvChangeStatus2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus2.Name = "cdvChangeStatus2";
            this.cdvChangeStatus2.ReadOnly = false;
            this.cdvChangeStatus2.SearchSubItemIndex = 0;
            this.cdvChangeStatus2.SelectedDescIndex = -1;
            this.cdvChangeStatus2.SelectedSubItemIndex = -1;
            this.cdvChangeStatus2.SelectionStart = 0;
            this.cdvChangeStatus2.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus2.SmallImageList = null;
            this.cdvChangeStatus2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus2.TabIndex = 11;
            this.cdvChangeStatus2.TextBoxToolTipText = "";
            this.cdvChangeStatus2.TextBoxWidth = 176;
            this.cdvChangeStatus2.VisibleButton = true;
            this.cdvChangeStatus2.VisibleColumnHeader = false;
            this.cdvChangeStatus2.VisibleDescription = false;
            this.cdvChangeStatus2.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvChangeStatus1
            // 
            this.cdvChangeStatus1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChangeStatus1.BtnToolTipText = "";
            this.cdvChangeStatus1.DescText = "";
            this.cdvChangeStatus1.DisplaySubItemIndex = -1;
            this.cdvChangeStatus1.DisplayText = "";
            this.cdvChangeStatus1.Focusing = null;
            this.cdvChangeStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChangeStatus1.Index = 0;
            this.cdvChangeStatus1.IsViewBtnImage = false;
            this.cdvChangeStatus1.Location = new System.Drawing.Point(384, 58);
            this.cdvChangeStatus1.MaxLength = 32767;
            this.cdvChangeStatus1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChangeStatus1.Name = "cdvChangeStatus1";
            this.cdvChangeStatus1.ReadOnly = false;
            this.cdvChangeStatus1.SearchSubItemIndex = 0;
            this.cdvChangeStatus1.SelectedDescIndex = -1;
            this.cdvChangeStatus1.SelectedSubItemIndex = -1;
            this.cdvChangeStatus1.SelectionStart = 0;
            this.cdvChangeStatus1.Size = new System.Drawing.Size(176, 20);
            this.cdvChangeStatus1.SmallImageList = null;
            this.cdvChangeStatus1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChangeStatus1.TabIndex = 8;
            this.cdvChangeStatus1.TextBoxToolTipText = "";
            this.cdvChangeStatus1.TextBoxWidth = 176;
            this.cdvChangeStatus1.VisibleButton = true;
            this.cdvChangeStatus1.VisibleColumnHeader = false;
            this.cdvChangeStatus1.VisibleDescription = false;
            this.cdvChangeStatus1.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // cdvPrimaryChange
            // 
            this.cdvPrimaryChange.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPrimaryChange.BtnToolTipText = "";
            this.cdvPrimaryChange.DescText = "";
            this.cdvPrimaryChange.DisplaySubItemIndex = -1;
            this.cdvPrimaryChange.DisplayText = "";
            this.cdvPrimaryChange.Focusing = null;
            this.cdvPrimaryChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPrimaryChange.Index = 0;
            this.cdvPrimaryChange.IsViewBtnImage = false;
            this.cdvPrimaryChange.Location = new System.Drawing.Point(384, 36);
            this.cdvPrimaryChange.MaxLength = 32767;
            this.cdvPrimaryChange.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrimaryChange.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrimaryChange.Name = "cdvPrimaryChange";
            this.cdvPrimaryChange.ReadOnly = false;
            this.cdvPrimaryChange.SearchSubItemIndex = 0;
            this.cdvPrimaryChange.SelectedDescIndex = -1;
            this.cdvPrimaryChange.SelectedSubItemIndex = -1;
            this.cdvPrimaryChange.SelectionStart = 0;
            this.cdvPrimaryChange.Size = new System.Drawing.Size(176, 20);
            this.cdvPrimaryChange.SmallImageList = null;
            this.cdvPrimaryChange.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrimaryChange.TabIndex = 5;
            this.cdvPrimaryChange.TextBoxToolTipText = "";
            this.cdvPrimaryChange.TextBoxWidth = 176;
            this.cdvPrimaryChange.VisibleButton = true;
            this.cdvPrimaryChange.VisibleColumnHeader = false;
            this.cdvPrimaryChange.VisibleDescription = false;
            this.cdvPrimaryChange.ButtonPress += new System.EventHandler(this.cdvPrimaryChange_ButtonPress);
            // 
            // txtChangeUpDown
            // 
            this.txtChangeUpDown.Location = new System.Drawing.Point(384, 14);
            this.txtChangeUpDown.Name = "txtChangeUpDown";
            this.txtChangeUpDown.ReadOnly = true;
            this.txtChangeUpDown.Size = new System.Drawing.Size(176, 20);
            this.txtChangeUpDown.TabIndex = 2;
            this.txtChangeUpDown.TabStop = false;
            // 
            // txtPrimaryCurrent
            // 
            this.txtPrimaryCurrent.Location = new System.Drawing.Point(168, 36);
            this.txtPrimaryCurrent.MaxLength = 30;
            this.txtPrimaryCurrent.Name = "txtPrimaryCurrent";
            this.txtPrimaryCurrent.ReadOnly = true;
            this.txtPrimaryCurrent.Size = new System.Drawing.Size(176, 20);
            this.txtPrimaryCurrent.TabIndex = 4;
            this.txtPrimaryCurrent.TabStop = false;
            // 
            // txtCurrentStatus10
            // 
            this.txtCurrentStatus10.Location = new System.Drawing.Point(168, 256);
            this.txtCurrentStatus10.MaxLength = 30;
            this.txtCurrentStatus10.Name = "txtCurrentStatus10";
            this.txtCurrentStatus10.ReadOnly = true;
            this.txtCurrentStatus10.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus10.TabIndex = 34;
            this.txtCurrentStatus10.TabStop = false;
            // 
            // txtCurrentStatus9
            // 
            this.txtCurrentStatus9.Location = new System.Drawing.Point(168, 234);
            this.txtCurrentStatus9.MaxLength = 30;
            this.txtCurrentStatus9.Name = "txtCurrentStatus9";
            this.txtCurrentStatus9.ReadOnly = true;
            this.txtCurrentStatus9.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus9.TabIndex = 31;
            this.txtCurrentStatus9.TabStop = false;
            // 
            // txtCurrentStatus8
            // 
            this.txtCurrentStatus8.Location = new System.Drawing.Point(168, 212);
            this.txtCurrentStatus8.MaxLength = 30;
            this.txtCurrentStatus8.Name = "txtCurrentStatus8";
            this.txtCurrentStatus8.ReadOnly = true;
            this.txtCurrentStatus8.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus8.TabIndex = 28;
            this.txtCurrentStatus8.TabStop = false;
            // 
            // txtCurrentStatus7
            // 
            this.txtCurrentStatus7.Location = new System.Drawing.Point(168, 190);
            this.txtCurrentStatus7.MaxLength = 30;
            this.txtCurrentStatus7.Name = "txtCurrentStatus7";
            this.txtCurrentStatus7.ReadOnly = true;
            this.txtCurrentStatus7.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus7.TabIndex = 25;
            this.txtCurrentStatus7.TabStop = false;
            // 
            // txtCurrentStatus6
            // 
            this.txtCurrentStatus6.Location = new System.Drawing.Point(168, 168);
            this.txtCurrentStatus6.MaxLength = 30;
            this.txtCurrentStatus6.Name = "txtCurrentStatus6";
            this.txtCurrentStatus6.ReadOnly = true;
            this.txtCurrentStatus6.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus6.TabIndex = 22;
            this.txtCurrentStatus6.TabStop = false;
            // 
            // txtCurrentStatus5
            // 
            this.txtCurrentStatus5.Location = new System.Drawing.Point(168, 146);
            this.txtCurrentStatus5.MaxLength = 30;
            this.txtCurrentStatus5.Name = "txtCurrentStatus5";
            this.txtCurrentStatus5.ReadOnly = true;
            this.txtCurrentStatus5.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus5.TabIndex = 19;
            this.txtCurrentStatus5.TabStop = false;
            // 
            // txtCurrentStatus4
            // 
            this.txtCurrentStatus4.Location = new System.Drawing.Point(168, 124);
            this.txtCurrentStatus4.MaxLength = 30;
            this.txtCurrentStatus4.Name = "txtCurrentStatus4";
            this.txtCurrentStatus4.ReadOnly = true;
            this.txtCurrentStatus4.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus4.TabIndex = 16;
            this.txtCurrentStatus4.TabStop = false;
            // 
            // txtCurrentStatus3
            // 
            this.txtCurrentStatus3.Location = new System.Drawing.Point(168, 102);
            this.txtCurrentStatus3.MaxLength = 30;
            this.txtCurrentStatus3.Name = "txtCurrentStatus3";
            this.txtCurrentStatus3.ReadOnly = true;
            this.txtCurrentStatus3.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus3.TabIndex = 13;
            this.txtCurrentStatus3.TabStop = false;
            // 
            // txtCurrentStatus2
            // 
            this.txtCurrentStatus2.Location = new System.Drawing.Point(168, 80);
            this.txtCurrentStatus2.MaxLength = 30;
            this.txtCurrentStatus2.Name = "txtCurrentStatus2";
            this.txtCurrentStatus2.ReadOnly = true;
            this.txtCurrentStatus2.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus2.TabIndex = 10;
            this.txtCurrentStatus2.TabStop = false;
            // 
            // txtCurrentStatus1
            // 
            this.txtCurrentStatus1.Location = new System.Drawing.Point(168, 58);
            this.txtCurrentStatus1.MaxLength = 30;
            this.txtCurrentStatus1.Name = "txtCurrentStatus1";
            this.txtCurrentStatus1.ReadOnly = true;
            this.txtCurrentStatus1.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentStatus1.TabIndex = 7;
            this.txtCurrentStatus1.TabStop = false;
            // 
            // txtCurrentUpDown
            // 
            this.txtCurrentUpDown.Location = new System.Drawing.Point(168, 14);
            this.txtCurrentUpDown.Name = "txtCurrentUpDown";
            this.txtCurrentUpDown.ReadOnly = true;
            this.txtCurrentUpDown.Size = new System.Drawing.Size(176, 20);
            this.txtCurrentUpDown.TabIndex = 1;
            this.txtCurrentUpDown.TabStop = false;
            // 
            // lblPrimaryStatus
            // 
            this.lblPrimaryStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrimaryStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrimaryStatus.Location = new System.Drawing.Point(16, 39);
            this.lblPrimaryStatus.Name = "lblPrimaryStatus";
            this.lblPrimaryStatus.Size = new System.Drawing.Size(140, 14);
            this.lblPrimaryStatus.TabIndex = 3;
            this.lblPrimaryStatus.Text = "Primary Status";
            // 
            // lblCurrentStatus10
            // 
            this.lblCurrentStatus10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus10.Location = new System.Drawing.Point(16, 259);
            this.lblCurrentStatus10.Name = "lblCurrentStatus10";
            this.lblCurrentStatus10.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus10.TabIndex = 33;
            // 
            // lblCurrentStatus9
            // 
            this.lblCurrentStatus9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus9.Location = new System.Drawing.Point(16, 237);
            this.lblCurrentStatus9.Name = "lblCurrentStatus9";
            this.lblCurrentStatus9.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus9.TabIndex = 30;
            // 
            // lblCurrentStatus8
            // 
            this.lblCurrentStatus8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus8.Location = new System.Drawing.Point(16, 215);
            this.lblCurrentStatus8.Name = "lblCurrentStatus8";
            this.lblCurrentStatus8.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus8.TabIndex = 27;
            // 
            // lblCurrentStatus7
            // 
            this.lblCurrentStatus7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus7.Location = new System.Drawing.Point(16, 193);
            this.lblCurrentStatus7.Name = "lblCurrentStatus7";
            this.lblCurrentStatus7.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus7.TabIndex = 24;
            // 
            // lblCurrentStatus6
            // 
            this.lblCurrentStatus6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus6.Location = new System.Drawing.Point(16, 171);
            this.lblCurrentStatus6.Name = "lblCurrentStatus6";
            this.lblCurrentStatus6.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus6.TabIndex = 21;
            // 
            // lblCurrentStatus5
            // 
            this.lblCurrentStatus5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus5.Location = new System.Drawing.Point(16, 149);
            this.lblCurrentStatus5.Name = "lblCurrentStatus5";
            this.lblCurrentStatus5.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus5.TabIndex = 18;
            // 
            // lblCurrentStatus4
            // 
            this.lblCurrentStatus4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus4.Location = new System.Drawing.Point(16, 127);
            this.lblCurrentStatus4.Name = "lblCurrentStatus4";
            this.lblCurrentStatus4.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus4.TabIndex = 15;
            // 
            // lblCurrentStatus3
            // 
            this.lblCurrentStatus3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus3.Location = new System.Drawing.Point(16, 105);
            this.lblCurrentStatus3.Name = "lblCurrentStatus3";
            this.lblCurrentStatus3.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus3.TabIndex = 12;
            // 
            // lblCurrentStatus2
            // 
            this.lblCurrentStatus2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus2.Location = new System.Drawing.Point(16, 83);
            this.lblCurrentStatus2.Name = "lblCurrentStatus2";
            this.lblCurrentStatus2.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus2.TabIndex = 9;
            // 
            // lblCurrentStatus1
            // 
            this.lblCurrentStatus1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentStatus1.Location = new System.Drawing.Point(16, 61);
            this.lblCurrentStatus1.Name = "lblCurrentStatus1";
            this.lblCurrentStatus1.Size = new System.Drawing.Size(140, 14);
            this.lblCurrentStatus1.TabIndex = 6;
            // 
            // lblUpDown
            // 
            this.lblUpDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpDown.Location = new System.Drawing.Point(16, 17);
            this.lblUpDown.Name = "lblUpDown";
            this.lblUpDown.Size = new System.Drawing.Size(140, 14);
            this.lblUpDown.TabIndex = 0;
            this.lblUpDown.Text = "Up/Down Flag";
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Location = new System.Drawing.Point(3, 290);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(722, 46);
            this.grpComment.TabIndex = 1;
            this.grpComment.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(120, 13);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(590, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 15);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(100, 14);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(728, 339);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "Customized Field";
            this.tbpGeneral.Visible = false;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.lblStatus);
            this.grpGeneral.Controls.Add(this.cdvCMF10);
            this.grpGeneral.Controls.Add(this.cdvCMF9);
            this.grpGeneral.Controls.Add(this.cdvCMF8);
            this.grpGeneral.Controls.Add(this.cdvCMF7);
            this.grpGeneral.Controls.Add(this.cdvCMF6);
            this.grpGeneral.Controls.Add(this.cdvCMF5);
            this.grpGeneral.Controls.Add(this.cdvCMF4);
            this.grpGeneral.Controls.Add(this.cdvCMF3);
            this.grpGeneral.Controls.Add(this.cdvCMF2);
            this.grpGeneral.Controls.Add(this.cdvCMF1);
            this.grpGeneral.Controls.Add(this.lblCMF10);
            this.grpGeneral.Controls.Add(this.lblCMF9);
            this.grpGeneral.Controls.Add(this.lblCMF8);
            this.grpGeneral.Controls.Add(this.lblCMF7);
            this.grpGeneral.Controls.Add(this.lblCMF6);
            this.grpGeneral.Controls.Add(this.lblCMF5);
            this.grpGeneral.Controls.Add(this.lblCMF4);
            this.grpGeneral.Controls.Add(this.lblCMF3);
            this.grpGeneral.Controls.Add(this.lblCMF2);
            this.grpGeneral.Controls.Add(this.lblCMF1);
            this.grpGeneral.Controls.Add(this.txtProcMode);
            this.grpGeneral.Controls.Add(this.txtAreaID);
            this.grpGeneral.Controls.Add(this.txtSubAreaID);
            this.grpGeneral.Controls.Add(this.txtProcessRule);
            this.grpGeneral.Controls.Add(this.txtResourceType);
            this.grpGeneral.Controls.Add(this.lblProcMode);
            this.grpGeneral.Controls.Add(this.lblUpdateTime);
            this.grpGeneral.Controls.Add(this.lblUpdateUser);
            this.grpGeneral.Controls.Add(this.txtUpdateTime);
            this.grpGeneral.Controls.Add(this.txtUpdateUser);
            this.grpGeneral.Controls.Add(this.txtMaxProcCount);
            this.grpGeneral.Controls.Add(this.lblMaxProcCount);
            this.grpGeneral.Controls.Add(this.lblProcRule);
            this.grpGeneral.Controls.Add(this.txtLocation);
            this.grpGeneral.Controls.Add(this.lblLocation);
            this.grpGeneral.Controls.Add(this.lblSubAreaID);
            this.grpGeneral.Controls.Add(this.lblAreaID);
            this.grpGeneral.Controls.Add(this.txtCtrlMode);
            this.grpGeneral.Controls.Add(this.lblCtrlMode);
            this.grpGeneral.Controls.Add(this.lblResType);
            this.grpGeneral.Controls.Add(this.lblCMF);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(722, 336);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus.Location = new System.Drawing.Point(20, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Resource Information";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 0;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(520, 256);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 41;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 180;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 0;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(520, 232);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 39;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 180;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            this.cdvCMF9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF8.BtnToolTipText = "";
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 0;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(520, 208);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 37;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 180;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            this.cdvCMF8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF7.BtnToolTipText = "";
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 0;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(520, 184);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 35;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 180;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            this.cdvCMF7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF6.BtnToolTipText = "";
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 0;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(520, 160);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 33;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 180;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 0;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(520, 136);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 31;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 180;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 0;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(520, 112);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 29;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 180;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            this.cdvCMF4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF3.BtnToolTipText = "";
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 0;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(520, 88);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 27;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 180;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            this.cdvCMF3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF2.BtnToolTipText = "";
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 0;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(520, 64);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 25;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 180;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF1.BtnToolTipText = "";
            this.cdvCMF1.DescText = "";
            this.cdvCMF1.DisplaySubItemIndex = -1;
            this.cdvCMF1.DisplayText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(520, 40);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 23;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 180;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(372, 259);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCMF10.TabIndex = 40;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(372, 235);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCMF9.TabIndex = 38;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(372, 211);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCMF8.TabIndex = 36;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(372, 187);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCMF7.TabIndex = 34;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(372, 163);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCMF6.TabIndex = 32;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(372, 139);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCMF5.TabIndex = 30;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(372, 115);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCMF4.TabIndex = 28;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(372, 91);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCMF3.TabIndex = 26;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(372, 67);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCMF2.TabIndex = 24;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(372, 43);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCMF1.TabIndex = 22;
            // 
            // txtProcMode
            // 
            this.txtProcMode.Location = new System.Drawing.Point(160, 208);
            this.txtProcMode.Name = "txtProcMode";
            this.txtProcMode.ReadOnly = true;
            this.txtProcMode.Size = new System.Drawing.Size(180, 20);
            this.txtProcMode.TabIndex = 16;
            this.txtProcMode.TabStop = false;
            // 
            // txtAreaID
            // 
            this.txtAreaID.Location = new System.Drawing.Point(160, 136);
            this.txtAreaID.Name = "txtAreaID";
            this.txtAreaID.ReadOnly = true;
            this.txtAreaID.Size = new System.Drawing.Size(180, 20);
            this.txtAreaID.TabIndex = 10;
            this.txtAreaID.TabStop = false;
            // 
            // txtSubAreaID
            // 
            this.txtSubAreaID.Location = new System.Drawing.Point(160, 160);
            this.txtSubAreaID.Name = "txtSubAreaID";
            this.txtSubAreaID.ReadOnly = true;
            this.txtSubAreaID.Size = new System.Drawing.Size(180, 20);
            this.txtSubAreaID.TabIndex = 12;
            this.txtSubAreaID.TabStop = false;
            // 
            // txtProcessRule
            // 
            this.txtProcessRule.Location = new System.Drawing.Point(160, 88);
            this.txtProcessRule.Name = "txtProcessRule";
            this.txtProcessRule.ReadOnly = true;
            this.txtProcessRule.Size = new System.Drawing.Size(180, 20);
            this.txtProcessRule.TabIndex = 6;
            this.txtProcessRule.TabStop = false;
            // 
            // txtResourceType
            // 
            this.txtResourceType.Location = new System.Drawing.Point(160, 40);
            this.txtResourceType.Name = "txtResourceType";
            this.txtResourceType.ReadOnly = true;
            this.txtResourceType.Size = new System.Drawing.Size(180, 20);
            this.txtResourceType.TabIndex = 2;
            this.txtResourceType.TabStop = false;
            // 
            // lblProcMode
            // 
            this.lblProcMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcMode.Location = new System.Drawing.Point(20, 211);
            this.lblProcMode.Name = "lblProcMode";
            this.lblProcMode.Size = new System.Drawing.Size(100, 14);
            this.lblProcMode.TabIndex = 15;
            this.lblProcMode.Text = "Proc Mode";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(20, 259);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(100, 14);
            this.lblUpdateTime.TabIndex = 19;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(20, 235);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(100, 14);
            this.lblUpdateUser.TabIndex = 17;
            this.lblUpdateUser.Text = "Update User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(160, 256);
            this.txtUpdateTime.MaxLength = 20;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(180, 20);
            this.txtUpdateTime.TabIndex = 20;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(160, 232);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(180, 20);
            this.txtUpdateUser.TabIndex = 18;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtMaxProcCount
            // 
            this.txtMaxProcCount.Location = new System.Drawing.Point(160, 112);
            this.txtMaxProcCount.Name = "txtMaxProcCount";
            this.txtMaxProcCount.ReadOnly = true;
            this.txtMaxProcCount.Size = new System.Drawing.Size(180, 20);
            this.txtMaxProcCount.TabIndex = 8;
            this.txtMaxProcCount.TabStop = false;
            // 
            // lblMaxProcCount
            // 
            this.lblMaxProcCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxProcCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxProcCount.Location = new System.Drawing.Point(20, 115);
            this.lblMaxProcCount.Name = "lblMaxProcCount";
            this.lblMaxProcCount.Size = new System.Drawing.Size(100, 14);
            this.lblMaxProcCount.TabIndex = 7;
            this.lblMaxProcCount.Text = "Max Proc Count";
            // 
            // lblProcRule
            // 
            this.lblProcRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcRule.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcRule.Location = new System.Drawing.Point(20, 91);
            this.lblProcRule.Name = "lblProcRule";
            this.lblProcRule.Size = new System.Drawing.Size(100, 14);
            this.lblProcRule.TabIndex = 5;
            this.lblProcRule.Text = "Process Rule";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(160, 184);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(180, 20);
            this.txtLocation.TabIndex = 14;
            this.txtLocation.TabStop = false;
            // 
            // lblLocation
            // 
            this.lblLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation.Location = new System.Drawing.Point(20, 187);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 14);
            this.lblLocation.TabIndex = 13;
            this.lblLocation.Text = "Location";
            // 
            // lblSubAreaID
            // 
            this.lblSubAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubAreaID.Location = new System.Drawing.Point(20, 163);
            this.lblSubAreaID.Name = "lblSubAreaID";
            this.lblSubAreaID.Size = new System.Drawing.Size(100, 14);
            this.lblSubAreaID.TabIndex = 11;
            this.lblSubAreaID.Text = "Sub Area ID";
            // 
            // lblAreaID
            // 
            this.lblAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAreaID.Location = new System.Drawing.Point(20, 139);
            this.lblAreaID.Name = "lblAreaID";
            this.lblAreaID.Size = new System.Drawing.Size(100, 14);
            this.lblAreaID.TabIndex = 9;
            this.lblAreaID.Text = "Area ID";
            // 
            // txtCtrlMode
            // 
            this.txtCtrlMode.Location = new System.Drawing.Point(160, 64);
            this.txtCtrlMode.Name = "txtCtrlMode";
            this.txtCtrlMode.ReadOnly = true;
            this.txtCtrlMode.Size = new System.Drawing.Size(180, 20);
            this.txtCtrlMode.TabIndex = 4;
            this.txtCtrlMode.TabStop = false;
            // 
            // lblCtrlMode
            // 
            this.lblCtrlMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCtrlMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCtrlMode.Location = new System.Drawing.Point(20, 67);
            this.lblCtrlMode.Name = "lblCtrlMode";
            this.lblCtrlMode.Size = new System.Drawing.Size(100, 14);
            this.lblCtrlMode.TabIndex = 3;
            this.lblCtrlMode.Text = "Control Mode";
            // 
            // lblResType
            // 
            this.lblResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResType.Location = new System.Drawing.Point(20, 43);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(100, 14);
            this.lblResType.TabIndex = 1;
            this.lblResType.Text = "Resource Type";
            // 
            // lblCMF
            // 
            this.lblCMF.AutoSize = true;
            this.lblCMF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF.Location = new System.Drawing.Point(368, 16);
            this.lblCMF.Name = "lblCMF";
            this.lblCMF.Size = new System.Drawing.Size(31, 15);
            this.lblCMF.TabIndex = 21;
            this.lblCMF.Text = "CMF";
            this.lblCMF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbpSPCResData
            // 
            this.tbpSPCResData.Controls.Add(this.pnlChartSet);
            this.tbpSPCResData.Controls.Add(this.grpChart);
            this.tbpSPCResData.Location = new System.Drawing.Point(4, 22);
            this.tbpSPCResData.Name = "tbpSPCResData";
            this.tbpSPCResData.Size = new System.Drawing.Size(728, 339);
            this.tbpSPCResData.TabIndex = 7;
            this.tbpSPCResData.Text = "Collect Resource Data";
            // 
            // pnlChartSet
            // 
            this.pnlChartSet.AutoScroll = true;
            this.pnlChartSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartSet.Location = new System.Drawing.Point(0, 48);
            this.pnlChartSet.Name = "pnlChartSet";
            this.pnlChartSet.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlChartSet.Size = new System.Drawing.Size(728, 291);
            this.pnlChartSet.TabIndex = 5;
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.txtChartID);
            this.grpChart.Controls.Add(this.lblGraphType);
            this.grpChart.Controls.Add(this.lblChartID);
            this.grpChart.Controls.Add(this.cboGraphType);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(0, 0);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(728, 48);
            this.grpChart.TabIndex = 3;
            this.grpChart.TabStop = false;
            // 
            // txtChartID
            // 
            this.txtChartID.Location = new System.Drawing.Point(124, 16);
            this.txtChartID.Name = "txtChartID";
            this.txtChartID.ReadOnly = true;
            this.txtChartID.Size = new System.Drawing.Size(200, 21);
            this.txtChartID.TabIndex = 7;
            this.txtChartID.TabStop = false;
            // 
            // lblGraphType
            // 
            this.lblGraphType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGraphType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGraphType.Location = new System.Drawing.Point(411, 19);
            this.lblGraphType.Name = "lblGraphType";
            this.lblGraphType.Size = new System.Drawing.Size(104, 14);
            this.lblGraphType.TabIndex = 2;
            this.lblGraphType.Text = "Graph Type";
            // 
            // lblChartID
            // 
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(15, 19);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(104, 14);
            this.lblChartID.TabIndex = 0;
            this.lblChartID.Text = "Chart ID";
            // 
            // cboGraphType
            // 
            this.cboGraphType.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.cboGraphType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboGraphType.Location = new System.Drawing.Point(520, 17);
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.ReadOnly = true;
            this.cboGraphType.Size = new System.Drawing.Size(200, 19);
            this.cboGraphType.TabIndex = 1;
            this.cboGraphType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // frmSPCTranEvent
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmSPCTranEvent";
            this.Text = "Event";
            this.Activated += new System.EventHandler(this.frmSPCTranEvent_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSPCTranEvent_KeyPress);
            this.Load += new System.EventHandler(this.frmSPCTranEvent_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlRes.ResumeLayout(false);
            this.grpEvent.ResumeLayout(false);
            this.grpEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).EndInit();
            this.grpResource.ResumeLayout(false);
            this.grpResource.PerformLayout();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tabResource.ResumeLayout(false);
            this.tbpResStatus.ResumeLayout(false);
            this.grpCurrentStatus.ResumeLayout(false);
            this.grpCurrentStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChangeStatus1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrimaryChange)).EndInit();
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.tbpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            this.tbpSPCResData.ResumeLayout(false);
            this.grpChart.ResumeLayout(false);
            this.grpChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const char CHANGE = 'Y';
        private const char NOTCHANGE = 'N';
        private const char INCREASE = '+';
        private const char DECREASE = '-';
        private const char OVERRIDE = 'O';
        private const char TIME = 'T';
        
        private const int UNIT_COL = 1;
        private const int NOMINAL_COL = 2;
        private const int PROCSIGMA_COL = 3;
        private const int VALUE_1_COL = 4;
        private const int WEIGHT_COL = 104;
        private const int AVERAGE_COL = 105;
        private const int SIGMA_COL = 106;
        private const int RANGE_COL = 107;
        private const int MAX_COL = 108;
        private const int MIN_COL = 109;
        
        #endregion
        
        #region " Variable Definition "
        private bool b_load_flag;
        
        public bool LoadFlag
        {
            get
            {
                return b_load_flag;
            }
            set
            {
                b_load_flag = value;
            }
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
        private void ClearData(string ProcStep)
        {
            
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this, cdvResID, null, null, null, null, false);
                }
                else
                {
                    MPCF.FieldClear(this, cdvResID, cdvEventID, null, null, null, false);
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
            Control ctl;
            Control ctl2;
            
            if (MPCF.CheckValue(cdvResID, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvEventID, 1) == false)
            {
                return false;
            }
            if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpGeneral) == false)
            {
                return false;
            }
            
            switch (MPCF.Trim(FuncName))
            {
                
            case "Collect_Res_Data":


                if (MPCF.Trim(txtChartID.Text) != "")
                {
                    
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
                                    if (((udcChartInfo) ctl2).CheckCondition() == false)
                                    {
                                        tabResource.SelectedTab = tbpSPCResData;
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
                break;
                
        }
        
        return true;
        
    }
    
    private bool GetResourceIDList()
    {
        
        try
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;

            if (RASLIST.ViewResourceList(cdvResID.GetListView, false) == false)
            {
                return false;
            }
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return false;
        }
        
        return true;
        
    }
    
    private bool GetEventIDList()
    {
        
        try
        {
            cdvEventID.Init();
            MPCF.InitListView(cdvEventID.GetListView);
            cdvEventID.Columns.Add("EventID", 50, HorizontalAlignment.Left);
            cdvEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvEventID.SelectedSubItemIndex = 0;
            
            if (RASLIST.ViewEventList(cdvEventID.GetListView, '1', "", null, "") == false)
            {
                return false;
            }
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return false;
        }
        
        return true;
        
    }
    
    private bool Resource_Event(char c_step)
    {
        
        RAS_Resource_Event_In_Tag Resource_Event_In = new RAS_Resource_Event_In_Tag();
        RAS_Resource_Event_Out_Tag Resource_Event_Out = new RAS_Resource_Event_Out_Tag();
        
        int i;
        int j;
        int k;
        int m;
        int iValueCount;
        int iChartCount;
        Control ctrlPanel;
        Control ctrludcChartInfo;
        udcChartInfo ctrlChartInfo;
        try
        {
            Resource_Event_In._C.h_passport = MPGV.gsPassport;
            Resource_Event_In._C.h_language = MPGV.gcLanguage;
            Resource_Event_In._C.h_factory = MPGV.gsFactory;
            Resource_Event_In._C.h_user_id = MPGV.gsUserID;
            Resource_Event_In._C.h_password = MPGV.gsPassword;
            Resource_Event_In._C.h_proc_step = '1';
            Resource_Event_In._C.h_sub_step = c_step;
            
            if (chkTranDateTime.Checked == true)
            {
                Resource_Event_In._C.back_time_flag = 'Y';
                Resource_Event_In._C.back_time = dtpTranDate.Value.ToString("yyyyMMddHHmmss");
            }
            Resource_Event_In._C.res_id = cdvResID.Text;
            Resource_Event_In._C.event_id = cdvEventID.Text;
            Resource_Event_In._C.chg_pri_sts = cdvPrimaryChange.Text;
            Resource_Event_In._C.chg_sts_1 = cdvChangeStatus1.Text;
            Resource_Event_In._C.chg_sts_2 = cdvChangeStatus2.Text;
            Resource_Event_In._C.chg_sts_3 = cdvChangeStatus3.Text;
            Resource_Event_In._C.chg_sts_4 = cdvChangeStatus4.Text;
            Resource_Event_In._C.chg_sts_5 = cdvChangeStatus5.Text;
            Resource_Event_In._C.chg_sts_6 = cdvChangeStatus6.Text;
            Resource_Event_In._C.chg_sts_7 = cdvChangeStatus7.Text;
            Resource_Event_In._C.chg_sts_8 = cdvChangeStatus8.Text;
            Resource_Event_In._C.chg_sts_9 = cdvChangeStatus9.Text;
            Resource_Event_In._C.chg_sts_10 = cdvChangeStatus10.Text;
            
            Resource_Event_In._C.tran_cmf_1 = cdvCMF1.Text;
            Resource_Event_In._C.tran_cmf_2 = cdvCMF2.Text;
            Resource_Event_In._C.tran_cmf_3 = cdvCMF3.Text;
            Resource_Event_In._C.tran_cmf_4 = cdvCMF4.Text;
            Resource_Event_In._C.tran_cmf_5 = cdvCMF5.Text;
            Resource_Event_In._C.tran_cmf_6 = cdvCMF6.Text;
            Resource_Event_In._C.tran_cmf_7 = cdvCMF7.Text;
            Resource_Event_In._C.tran_cmf_8 = cdvCMF8.Text;
            Resource_Event_In._C.tran_cmf_9 = cdvCMF9.Text;
            Resource_Event_In._C.tran_cmf_10 = cdvCMF10.Text;
            
            Resource_Event_In._C.tran_comment = txtComment.Text;
            Resource_Event_In._C.confirm_char_seq = 0;
            Resource_Event_In._C.confirm_unit_seq = 0;
            Resource_Event_In._C.confirm_value_seq = 0;
            
            Resource_Event_In._C.char_count = 0;
            Resource_Event_In._C._size_char_list = 0;
            
            Resource_Event_In._C.spc_count = 0;
            Resource_Event_In._C._size_chart_list = 0;
            
            Resource_Event_In._C.lot_res_flag = 'R';
            
            if (pnlChartSet.Tag != null)
            {
                if (MPCF.Trim(pnlChartSet.Tag) == "C")
                {
                    Resource_Event_In._C.chart_flag = 'C';
                }
                else if (MPCF.Trim(pnlChartSet.Tag) == "S")
                {
                    Resource_Event_In._C.chart_flag = 'S';
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
                Resource_Event_In._C.chart_list = new RAS_RESOURCE_EVENT_IN_TAG_chart_list[iChartCount - 1 + 1];
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
                                Resource_Event_In._C.chart_list[i] = new RAS_RESOURCE_EVENT_IN_TAG_chart_list();

                                Resource_Event_In._C.chart_list[i].chart_id = ((udcChartInfo) ctrludcChartInfo).ChartID;
                                Resource_Event_In._C.chart_list[i].unit_count = ((udcChartInfo) ctrludcChartInfo).UnitCount;
                                Resource_Event_In._C.chart_list[i].sample_size = ((udcChartInfo) ctrludcChartInfo).SampleSize;
                                Resource_Event_In._C.chart_list[i].graph_type = MPCF.Trim(Enum.GetName(typeof(eGraphType), ((udcChartInfo) ctrludcChartInfo).GraphTypeIndex));
                                Resource_Event_In._C.chart_list[i].unit_use_flag = ((udcChartInfo) ctrludcChartInfo).UseUnit;
                                Resource_Event_In._C.chart_list[i].edc_comment = ((udcChartInfo) ctrludcChartInfo).Comment;
                                FarPoint.Win.Spread.SheetView with_1 = ((udcChartInfo) ctrludcChartInfo).GetSpreadData.Sheets[0];
                                for (m = 0; m <= (with_1.RowCount - 1); m++)
                                {
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
                                        Resource_Event_In._C.chart_list[i].nominal = MPCF.Trim(with_1.GetValue(0, NOMINAL_COL));
                                    }
                                    if (with_1.Columns[PROCSIGMA_COL].Visible == true)
                                    {
                                        Resource_Event_In._C.chart_list[i].process_sigma = MPCF.Trim(with_1.GetValue(0, PROCSIGMA_COL));
                                    }
                                    Resource_Event_In._C.chart_list[i].unit_id = MPCF.Trim(with_1.GetValue(m, UNIT_COL));
                                    Resource_Event_In._C.chart_list[i].value_count = iValueCount;
                                    Resource_Event_In._C.chart_list[i].unit_seq = m + 1;
                                    Resource_Event_In._C.chart_list[i]._size_value_list = 100;
                                    Resource_Event_In._C.chart_list[i].value_list = new RAS_RESOURCE_EVENT_IN_TAG_chart_list_value_list[100];
                                    for (k = 0; k < 100; k++ )
                                    {
                                        Resource_Event_In._C.chart_list[i].value_list[k] = new RAS_RESOURCE_EVENT_IN_TAG_chart_list_value_list();
                                    }

                                    for (k = 0; k <= iValueCount - 1; k++)
                                    {
                                        if (with_1.Columns[k + VALUE_1_COL].Visible == true)
                                        {
                                            Resource_Event_In._C.chart_list[i].value_list[k].value = MPCF.Trim(with_1.GetValue(m, k + VALUE_1_COL));
                                        }
                                    }
                                    i++;
                                }
                                
                            }
                        }
                    }
                }
                Resource_Event_In._C.spc_count = i;
                Resource_Event_In._C._size_chart_list = i;
            }
            
            if (RASCaster.RAS_Resource_Event(Resource_Event_In, ref Resource_Event_Out) == false)
            {
                MPCF.ShowMsgBox(h101stub.StatusMessage);
                return false;
            }
            if (Resource_Event_Out._C.h_status_value == MPGC.MP_FAIL_STATUS)
            {
                MPCF.ShowMsgBox(MPCF.MakeErrorMsg(Resource_Event_Out._C.h_msg_code, Resource_Event_Out._C.h_msg, Resource_Event_Out._C.h_db_err_msg, Resource_Event_Out._C.h_field_msg));
                return false;
            }
            i = 0;
            while (i < Resource_Event_Out._C.spc_count)
            {
                ctrlChartInfo = GetChartInfoControl(Resource_Event_Out._C.chart_list[i].chart_id);
                if (ctrlChartInfo == null)
                {
                    return false;
                }
                FarPoint.Win.Spread.SheetView with_2 = ctrlChartInfo.GetSpreadData.Sheets[0];
                if (ctrlChartInfo.UseUnit == 'Y')
                {
                    for (j = 0; j <= ctrlChartInfo.UnitCount - 1; j++)
                    {
                        with_2.Cells[Resource_Event_In._C.chart_list[i + j].unit_seq - 1, WEIGHT_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i + j].weight_value, ctrlChartInfo.Precision);
                        with_2.Cells[Resource_Event_In._C.chart_list[i + j].unit_seq - 1, AVERAGE_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i + j].average, ctrlChartInfo.Precision);
                        with_2.Cells[Resource_Event_In._C.chart_list[i + j].unit_seq - 1, SIGMA_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i + j].stddev, ctrlChartInfo.Precision);
                        with_2.Cells[Resource_Event_In._C.chart_list[i + j].unit_seq - 1, RANGE_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i + j].range, ctrlChartInfo.Precision);
                        with_2.Cells[Resource_Event_In._C.chart_list[i + j].unit_seq - 1, MAX_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i + j].max_value, ctrlChartInfo.Precision);
                        with_2.Cells[Resource_Event_In._C.chart_list[i + j].unit_seq - 1, MIN_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i + j].min_value, ctrlChartInfo.Precision);
                        if (Resource_Event_Out._C.chart_list[i + j].r_check_result == ' ' && Resource_Event_Out._C.chart_list[i + j].x_check_result == ' ')
                        {
                            with_2.Cells[Resource_Event_In._C.chart_list[i + j].unit_seq - 1, 0].Value = "OK";
                        }
                        else
                        {
                            with_2.Cells[Resource_Event_In._C.chart_list[i + j].unit_seq - 1, 0].Value = "FAIL";
                        }
                        if (Resource_Event_Out._C.chart_list[i + j].x_check_result == 'A')
                        {
                            if (ctrlChartInfo.ChartGraphType == eGraphType.XBARR.ToString() || 
                                ctrlChartInfo.ChartGraphType == eGraphType.XBARS.ToString() || 
                                ctrlChartInfo.ChartGraphType == eGraphType.XRS.ToString())
                            {
                                for (k = 0; k <= ctrlChartInfo.SampleSize - 1; k++)
                                {
                                    if (MPCF.Mid(Resource_Event_Out._C.oos_list[i + j].oos_check_result, k , 1) == "Y")
                                    {
                                        with_2.Cells[Resource_Event_In._C.chart_list[i + j].unit_seq - 1, VALUE_1_COL + k].BackColor = Color.Red;
                                    }
                                }
                            }
                            else if (ctrlChartInfo.ChartGraphType == eGraphType.P.ToString() || 
                                     ctrlChartInfo.ChartGraphType == eGraphType.U.ToString())
                            {
                                if (MPCF.Mid(Resource_Event_Out._C.oos_list[0].oos_check_result, 0, 1) == "Y")
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
                                if (MPCF.Mid(Resource_Event_Out._C.oos_list[0].oos_check_result, 0, 1) == "Y")
                                {
                                    with_2.Cells[0, VALUE_1_COL].BackColor = Color.Red;
                                }
                            }
                        }
                        else if (Resource_Event_Out._C.chart_list[i + j].x_check_result == 'B' && ctrlChartInfo.SpecCheckType == "V")
                        {
                            if (ctrlChartInfo.ChartGraphType == eGraphType.XBARR.ToString() || 
                                ctrlChartInfo.ChartGraphType == eGraphType.XBARS.ToString() || 
                                ctrlChartInfo.ChartGraphType == eGraphType.XRS.ToString())
                            {
                                for (k = 0; k <= ctrlChartInfo.SampleSize - 1; k++)
                                {
                                    if (MPCF.Mid(Resource_Event_Out._C.oos_list[i + j].oos_check_result, k , 1) == "Y")
                                    {
                                        with_2.Cells[Resource_Event_In._C.chart_list[i + j].unit_seq - 1, VALUE_1_COL + k].BackColor = Color.Yellow;
                                    }
                                }
                            }
                            
                        }
                    }
                }
                else
                {
                    with_2.Cells[0, WEIGHT_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i].weight_value, ctrlChartInfo.Precision);
                    with_2.Cells[0, WEIGHT_COL].RowSpan = with_2.RowCount;
                    with_2.Cells[0, AVERAGE_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i].average, ctrlChartInfo.Precision);
                    with_2.Cells[0, AVERAGE_COL].RowSpan = with_2.RowCount;
                    with_2.Cells[0, SIGMA_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i].stddev, ctrlChartInfo.Precision);
                    with_2.Cells[0, SIGMA_COL].RowSpan = with_2.RowCount;
                    with_2.Cells[0, RANGE_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i].range, ctrlChartInfo.Precision);
                    with_2.Cells[0, RANGE_COL].RowSpan = with_2.RowCount;
                    with_2.Cells[0, MAX_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i].max_value, ctrlChartInfo.Precision);
                    with_2.Cells[0, MAX_COL].RowSpan = with_2.RowCount;
                    with_2.Cells[0, MIN_COL].Value = MPCF.SetPrecision(Resource_Event_Out._C.chart_list[i].min_value, ctrlChartInfo.Precision);
                    with_2.Cells[0, MIN_COL].RowSpan = with_2.RowCount;
                    if (Resource_Event_Out._C.h_status_value == MPGC.MP_SUCCESS_STATUS)
                    {
                        with_2.Cells[0, 0].Value = "OK";
                    }
                    else
                    {
                        with_2.Cells[0, 0].Value = "FAIL";
                    }
                    with_2.Cells[0, 0].RowSpan = with_2.RowCount;
                    if (Resource_Event_Out._C.chart_list[0].x_check_result == 'A')
                    {
                        if (ctrlChartInfo.ChartGraphType == eGraphType.ZBARS.ToString() || 
                            ctrlChartInfo.ChartGraphType == eGraphType.DELTAS.ToString())
                        {
                            with_2.Cells[0, WEIGHT_COL].BackColor = Color.Red;
                        }
                        else
                        {
                            for (j = 0; j <= with_2.RowCount - 1; j++)
                            {
                                for (k = 0; k <= ctrlChartInfo.SampleSize - 1; k++)
                                {
                                    if (MPCF.Mid(Resource_Event_Out._C.oos_list[j].oos_check_result, k , 1) == "Y")
                                    {
                                        with_2.Cells[j, VALUE_1_COL + k].BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    else if (Resource_Event_Out._C.chart_list[0].x_check_result == 'B' && ctrlChartInfo.SpecCheckType == "V")
                    {
                        for (j = 0; j <= with_2.RowCount - 1; j++)
                        {
                            for (k = 0; k <= ctrlChartInfo.SampleSize - 1; k++)
                            {
                                if (MPCF.Mid(Resource_Event_Out._C.oos_list[j].oos_check_result, k , 1) == "Y")
                                {
                                    with_2.Cells[j, VALUE_1_COL + k].BackColor = Color.Yellow;
                                }
                            }
                        }
                    }
                }
                i += ctrlChartInfo.UnitCount;
            }
            
            if (c_step == MPGC.MP_STEP_TRAN && Resource_Event_Out._C.h_status_value == MPGC.MP_TRBL_STATUS)
            {
                if (Result_Management(Resource_Event_Out) == false)
                {
                    return false;
                }
            }
            else if (c_step == MPGC.MP_STEP_TRAN && Resource_Event_Out._C.h_status_value == MPGC.MP_SUCCESS_STATUS)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(52));
            }
            
            if (Resource_Event_Out._C.h_msg_code != "")
            {
                MPCF.ShowMsgBox(MPCF.MakeErrorMsg(Resource_Event_Out._C.h_msg_code, Resource_Event_Out._C.h_msg, Resource_Event_Out._C.h_db_err_msg, Resource_Event_Out._C.h_field_msg));
            }
            
            return true;
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
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
    private bool Result_Management(RAS_Resource_Event_Out_Tag Resource_Event_Out)
    {
        
        try
        {
            if (Resource_Event_Out._C.h_status_value == MPGC.MP_TRBL_STATUS)
            {
                frmSPCSubCollectData f = new frmSPCSubCollectData();
                frmSPCTranOOCHistory f1 = new frmSPCTranOOCHistory();
                if (MPCF.Trim(pnlChartSet.Tag) == "C")
                {
                    f.spdResult.Sheets[0].Columns[1].Visible = false;
                }
                else if (MPCF.Trim(pnlChartSet.Tag) == "S")
                {
                    f.spdResult.Sheets[0].Columns[1].Visible = true;
                }
                
                
                View_Result(f.spdResult, Resource_Event_Out, "1");
                f.ShowDialog(this);
                
                //Pending
                if (f.DialogResult == System.Windows.Forms.DialogResult.Ignore)
                {
                    //Data Commit
                    //OOC History Insert
                    if (Resource_Event(modSPCConstants.MP_STEP_PEND) == false)
                    {
                        return false;
                    }
                    
                    //Continue
                }
                else if (f.DialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    //f.Dispose()
                    if (Resource_Event(modSPCConstants.MP_STEP_CONT) == false)
                    {
                        return false;
                    }

                    if (MPCF.Trim(pnlChartSet.Tag) == "C")
                    {
                        f1 = new frmSPCTranOOCHistory(Resource_Event_Out._C.chart_list[0].hist_seq, Resource_Event_Out._C.chart_list[0].tran_time, - 1);
                        View_Result(f1.spdResult, Resource_Event_Out, "2");
                        f1.txtChart.Text = Resource_Event_Out._C.chart_list[0].chart_id;
                        f1.spdResult.Sheets[0].Columns[1].Visible = false;
                    }
                    else if (MPCF.Trim(pnlChartSet.Tag) == "S")
                    {
                        f1 = new frmSPCTranOOCHistory();
                        View_Result(f1.spdResult, Resource_Event_Out, "2");
                        f1.spdResult.Sheets[0].Columns[1].Visible = true;
                        f1.pnlTop.Visible = false;
                        f1.pnlResult.Height = 214;
                    }
                    f1.ShowDialog(this);
                    
                    //Data Change
                }
                else if (f.DialogResult == System.Windows.Forms.DialogResult.No)
                {
                    f.Dispose();
                    return false;
                }
                else if (f.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    f.Dispose();
                    return false;
                }
            }
            
            return true;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.Result_Management()\n" + ex.Message);
            return false;
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
    public void View_Result(FarPoint.Win.Spread.FpSpread spdResult, RAS_Resource_Event_Out_Tag Result_Out, string c_step)
    {
        
        try
        {
            int i;
            int j;
            udcChartInfo ctrlChartInfo;
            MPCF.ClearList(spdResult, true);
            j = 0;
            while (j < Result_Out._C.spc_count)
            {
                ctrlChartInfo = GetChartInfoControl(Result_Out._C.chart_list[j].chart_id);
                if (ctrlChartInfo == null)
                {
                    return;
                }
                FarPoint.Win.Spread.SheetView with_1 = spdResult.Sheets[0];
                if (ctrlChartInfo.UseUnit != 'Y')
                {
                    if (Result_Out._C.chart_list[j].r_check_result != ' ' && Result_Out._C.chart_list[j].x_check_result != ' ')
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
                        with_1.Cells[with_1.RowCount - 2, 4].Value = Result_Out._C.chart_list[j].x_check_result;
                        with_1.Cells[with_1.RowCount - 1, 4].Value = Result_Out._C.chart_list[j].r_check_result;
                        with_1.Cells[with_1.RowCount - 2, 5].Value = MPCF.SetRuleDescription(Result_Out._C.chart_list[j].x_check_result);
                        with_1.Cells[with_1.RowCount - 1, 5].Value = MPCF.SetRuleDescription(Result_Out._C.chart_list[j].r_check_result);
                        if (c_step == "2")
                        {
                            with_1.Cells[0, 6].RowSpan = 2;
                            with_1.Cells[with_1.RowCount - 2, 7].Value = Result_Out._C.chart_list[j].hist_seq;
                            with_1.Cells[with_1.RowCount - 1, 7].Value = Result_Out._C.chart_list[j].hist_seq;
                            with_1.Cells[with_1.RowCount - 2, 8].Value = Result_Out._C.chart_list[j].tran_time;
                            with_1.Cells[with_1.RowCount - 1, 8].Value = Result_Out._C.chart_list[j].tran_time;
                        }
                    }
                    else if (Result_Out._C.chart_list[j].r_check_result == ' ' && Result_Out._C.chart_list[j].x_check_result == ' ')
                    {
                    }
                    else
                    {
                        with_1.RowCount++;
                        with_1.Cells[with_1.RowCount - 1, 0].Value = 1;
                        with_1.Cells[with_1.RowCount - 1, 1].Value = ctrlChartInfo.ChartID;
                        with_1.Cells[with_1.RowCount - 1, 2].Value = ctrlChartInfo.GetSpreadData.Sheets[0].Cells[0, 1].Value;
                        with_1.Cells[with_1.RowCount - 1, 3].Value = (Result_Out._C.chart_list[j].r_check_result == ' ') ? "X" : "R";
                        with_1.Cells[with_1.RowCount - 1, 4].Value = (Result_Out._C.chart_list[j].r_check_result == ' ') ? (Result_Out._C.chart_list[0].x_check_result) : (Result_Out._C.chart_list[j].r_check_result);
                        with_1.Cells[with_1.RowCount - 1, 5].Value = (Result_Out._C.chart_list[j].r_check_result == ' ') ? (MPCF.SetRuleDescription(Result_Out._C.chart_list[j].x_check_result)) : (MPCF.SetRuleDescription(Result_Out._C.chart_list[j].r_check_result));
                        if (c_step == "2")
                        {
                            with_1.Cells[with_1.RowCount - 1, 7].Value = Result_Out._C.chart_list[j].hist_seq;
                            with_1.Cells[with_1.RowCount - 1, 8].Value = Result_Out._C.chart_list[j].tran_time;
                        }
                    }
                    j++;
                }
                else
                {
                    for (i = 0; i <= ctrlChartInfo.UnitCount - 1; i++)
                    {
                        if (Result_Out._C.chart_list[i + j].r_check_result != ' ' && Result_Out._C.chart_list[i + j].x_check_result != ' ')
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
                            with_1.Cells[with_1.RowCount - 2, 4].Value = Result_Out._C.chart_list[i + j].x_check_result;
                            with_1.Cells[with_1.RowCount - 1, 4].Value = Result_Out._C.chart_list[i + j].r_check_result;
                            with_1.Cells[with_1.RowCount - 2, 5].Value = MPCF.SetRuleDescription(Result_Out._C.chart_list[i + j].x_check_result);
                            with_1.Cells[with_1.RowCount - 1, 5].Value = MPCF.SetRuleDescription(Result_Out._C.chart_list[i + j].r_check_result);
                            if (c_step == "2")
                            {
                                with_1.Cells[with_1.RowCount - 2, 6].RowSpan = 2;
                                with_1.Cells[with_1.RowCount - 2, 7].Value = Result_Out._C.chart_list[i + j].hist_seq;
                                with_1.Cells[with_1.RowCount - 1, 7].Value = Result_Out._C.chart_list[i + j].hist_seq;
                                with_1.Cells[with_1.RowCount - 2, 8].Value = Result_Out._C.chart_list[i + j].tran_time;
                                with_1.Cells[with_1.RowCount - 1, 8].Value = Result_Out._C.chart_list[i + j].tran_time;
                            }
                        }
                        else if (Result_Out._C.chart_list[i + j].r_check_result == ' ' && Result_Out._C.chart_list[i + j].x_check_result == ' ')
                        {
                        }
                        else
                        {
                            with_1.RowCount++;
                            with_1.Cells[with_1.RowCount - 1, 0].Value = i + 1;
                            with_1.Cells[with_1.RowCount - 1, 1].Value = ctrlChartInfo.ChartID;
                            with_1.Cells[with_1.RowCount - 1, 2].Value = ctrlChartInfo.GetSpreadData.Sheets[0].Cells[i, 1].Value;
                            with_1.Cells[with_1.RowCount - 1, 3].Value = (Result_Out._C.chart_list[i + j].r_check_result == ' ') ? "X" : "R";
                            with_1.Cells[with_1.RowCount - 1, 4].Value = (Result_Out._C.chart_list[i + j].r_check_result == ' ') ? (Result_Out._C.chart_list[i + j].x_check_result) : (Result_Out._C.chart_list[i + j].r_check_result);
                            with_1.Cells[with_1.RowCount - 1, 5].Value = (Result_Out._C.chart_list[i + j].r_check_result == ' ') ? (MPCF.SetRuleDescription(Result_Out._C.chart_list[i + j].x_check_result)) : (MPCF.SetRuleDescription(Result_Out._C.chart_list[i + j].r_check_result));
                            if (c_step == "2")
                            {
                                with_1.Cells[with_1.RowCount - 1, 7].Value = Result_Out._C.chart_list[i + j].hist_seq;
                                with_1.Cells[with_1.RowCount - 1, 8].Value = Result_Out._C.chart_list[i + j].tran_time;
                            }
                        }
                    }
                    j += ctrlChartInfo.UnitCount;
                }
            }
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox("frmSPCTranCollectLotDatabyChartSet.View_Result()\n" + ex.Message);
        }
        
    }
    
    private bool View_Resource()
    {
        RAS_View_Resource_In_Tag View_Resource_In = new RAS_View_Resource_In_Tag();
        RAS_View_Resource_Out_Tag View_Resource_Out = new RAS_View_Resource_Out_Tag();
        try
        {
            //FieldClear(Me, cdvResID, cdvEventID, txtEventDesc, txtChangeUpDown)
            
            View_Resource_In.h_passport = MPGV.gsPassport;
            View_Resource_In.h_language = MPGV.gcLanguage;
            View_Resource_In.h_factory = MPGV.gsFactory;
            View_Resource_In.h_user_id = MPGV.gsUserID;
            View_Resource_In.h_password = MPGV.gsPassword;
            View_Resource_In.h_proc_step = '1';
            View_Resource_In.res_id = cdvResID.Text;
            
            if (RASCaster.RAS_View_Resource(View_Resource_In, ref View_Resource_Out) == false)
            {
                MPCF.ShowMsgBox(h101stub.StatusMessage);
                return false;
            }
            if (View_Resource_Out.h_status_value != MPGC.MP_SUCCESS_STATUS)
            {
                MPCF.ShowMsgBox(MPCF.MakeErrorMsg(View_Resource_Out.h_msg_code, View_Resource_Out.h_msg, View_Resource_Out.h_db_err_msg, View_Resource_Out.h_field_msg));
                return false;
            }
            
            txtDesc.Text = MPCF.Trim(View_Resource_Out.res_desc);
            txtResourceType.Text = MPCF.Trim(View_Resource_Out.res_type);
            if (MPCF.Trim(View_Resource_Out.res_up_down_flag) == "U")
            {
                txtCurrentUpDown.Text = "UP";
            }
            else if (MPCF.Trim(View_Resource_Out.res_up_down_flag) == "D")
            {
                txtCurrentUpDown.Text = "DOWN";
            }
            
            txtLastEvent.Text = MPCF.Trim(View_Resource_Out.last_event);
            txtLastEventTime.Text = MPCF.MakeDateFormat(View_Resource_Out.last_event_time);
            
            txtCurrentStatus1.Text = MPCF.Trim(View_Resource_Out.res_sts_1);
            txtCurrentStatus2.Text = MPCF.Trim(View_Resource_Out.res_sts_2);
            txtCurrentStatus3.Text = MPCF.Trim(View_Resource_Out.res_sts_3);
            txtCurrentStatus4.Text = MPCF.Trim(View_Resource_Out.res_sts_4);
            txtCurrentStatus5.Text = MPCF.Trim(View_Resource_Out.res_sts_5);
            txtCurrentStatus6.Text = MPCF.Trim(View_Resource_Out.res_sts_6);
            txtCurrentStatus7.Text = MPCF.Trim(View_Resource_Out.res_sts_7);
            txtCurrentStatus8.Text = MPCF.Trim(View_Resource_Out.res_sts_8);
            txtCurrentStatus9.Text = MPCF.Trim(View_Resource_Out.res_sts_9);
            txtCurrentStatus10.Text = MPCF.Trim(View_Resource_Out.res_sts_10);
            txtPrimaryCurrent.Text = MPCF.Trim(View_Resource_Out.res_pri_sts);
            
            if ( MPCF.Trim(View_Resource_Out.use_fac_prt_flag) != "Y")
            {
                if (MPCF.Trim(View_Resource_Out.res_sts_prt_1) != "")
                {
                    lblCurrentStatus1.Text = MPCF.Trim(View_Resource_Out.res_sts_prt_1);
                    lblCurrentStatus1.Visible = true;
                    txtCurrentStatus1.Visible = true;
                }
                else
                {
                    lblCurrentStatus1.Visible = false;
                    txtCurrentStatus1.Visible = false;
                    cdvChangeStatus1.Visible = false;
                }
                if (MPCF.Trim(View_Resource_Out.res_sts_prt_2) != "")
                {
                    lblCurrentStatus2.Text = MPCF.Trim(View_Resource_Out.res_sts_prt_2);
                    lblCurrentStatus2.Visible = true;
                    txtCurrentStatus2.Visible = true;
                }
                else
                {
                    lblCurrentStatus2.Visible = false;
                    txtCurrentStatus2.Visible = false;
                    cdvChangeStatus2.Visible = false;
                }
                if (MPCF.Trim(View_Resource_Out.res_sts_prt_3) != "")
                {
                    lblCurrentStatus3.Text = MPCF.Trim(View_Resource_Out.res_sts_prt_3);
                    lblCurrentStatus3.Visible = true;
                    txtCurrentStatus3.Visible = true;
                }
                else
                {
                    lblCurrentStatus3.Visible = false;
                    txtCurrentStatus3.Visible = false;
                    cdvChangeStatus3.Visible = false;
                }
                if (MPCF.Trim(View_Resource_Out.res_sts_prt_4) != "")
                {
                    lblCurrentStatus4.Text = MPCF.Trim(View_Resource_Out.res_sts_prt_4);
                    lblCurrentStatus4.Visible = true;
                    txtCurrentStatus4.Visible = true;
                }
                else
                {
                    lblCurrentStatus4.Visible = false;
                    txtCurrentStatus4.Visible = false;
                    cdvChangeStatus4.Visible = false;
                }
                if (MPCF.Trim(View_Resource_Out.res_sts_prt_5) != "")
                {
                    lblCurrentStatus5.Text = MPCF.Trim(View_Resource_Out.res_sts_prt_5);
                    lblCurrentStatus5.Visible = true;
                    txtCurrentStatus5.Visible = true;
                }
                else
                {
                    lblCurrentStatus5.Visible = false;
                    txtCurrentStatus5.Visible = false;
                    cdvChangeStatus5.Visible = false;
                }
                if (MPCF.Trim(View_Resource_Out.res_sts_prt_6) != "")
                {
                    lblCurrentStatus6.Text = MPCF.Trim(View_Resource_Out.res_sts_prt_6);
                    lblCurrentStatus6.Visible = true;
                    txtCurrentStatus6.Visible = true;
                }
                else
                {
                    lblCurrentStatus6.Visible = false;
                    txtCurrentStatus6.Visible = false;
                    cdvChangeStatus6.Visible = false;
                }
                if (MPCF.Trim(View_Resource_Out.res_sts_prt_7) != "")
                {
                    lblCurrentStatus7.Text = MPCF.Trim(View_Resource_Out.res_sts_prt_7);
                    lblCurrentStatus7.Visible = true;
                    txtCurrentStatus7.Visible = true;
                }
                else
                {
                    lblCurrentStatus7.Visible = false;
                    txtCurrentStatus7.Visible = false;
                    cdvChangeStatus7.Visible = false;
                }
                if (MPCF.Trim(View_Resource_Out.res_sts_prt_8) != "")
                {
                    lblCurrentStatus8.Text = MPCF.Trim(View_Resource_Out.res_sts_prt_8);
                    lblCurrentStatus8.Visible = true;
                    txtCurrentStatus8.Visible = true;
                }
                else
                {
                    lblCurrentStatus8.Visible = false;
                    txtCurrentStatus8.Visible = false;
                    cdvChangeStatus8.Visible = false;
                }
                if (MPCF.Trim(View_Resource_Out.res_sts_prt_9) != "")
                {
                    lblCurrentStatus9.Text = MPCF.Trim(View_Resource_Out.res_sts_prt_9);
                    lblCurrentStatus9.Visible = true;
                    txtCurrentStatus9.Visible = true;
                }
                else
                {
                    lblCurrentStatus9.Visible = false;
                    txtCurrentStatus9.Visible = false;
                    cdvChangeStatus9.Visible = false;
                }
                if (MPCF.Trim(View_Resource_Out.res_sts_prt_10) != "")
                {
                    lblCurrentStatus10.Text = MPCF.Trim(View_Resource_Out.res_sts_prt_10);
                    lblCurrentStatus10.Visible = true;
                    txtCurrentStatus10.Visible = true;
                }
                else
                {
                    lblCurrentStatus10.Visible = false;
                    txtCurrentStatus10.Visible = false;
                    cdvChangeStatus10.Visible = false;
                }
            }
            else
            {
                View_Factory_ResStatus();
            }
            
            txtAreaID.Text = MPCF.Trim(View_Resource_Out.area_id);
            txtSubAreaID.Text = MPCF.Trim(View_Resource_Out.sub_area_id);
            txtLocation.Text = MPCF.Trim(View_Resource_Out.res_location);
            if (MPCF.Trim(View_Resource_Out.proc_rule) == "")
            {
                txtProcessRule.Text = "NORMAL";
            }
            else if (MPCF.Trim(View_Resource_Out.proc_rule) == "S")
            {
                txtProcessRule.Text = "SERIAL";
            }
            else if (MPCF.Trim(View_Resource_Out.proc_rule) == "B")
            {
                txtProcessRule.Text = "BATCH";
            }
            txtMaxProcCount.Text = MPCF.Trim(View_Resource_Out.max_proc_count);
            txtProcMode.Text = MPCF.Trim(View_Resource_Out.res_proc_mode);
            if (View_Resource_Out.res_ctrl_mode.Substring(0, 2) == "OL")
            {
                txtCtrlMode.Text = "ONLINE LOCAL";
            }
            else if (View_Resource_Out.res_ctrl_mode.Substring(0, 2) == "OR")
            {
                txtCtrlMode.Text = "ONLINE REMOTE";
            }
            else if (View_Resource_Out.res_ctrl_mode.Substring(0, 2) == "OF")
            {
                txtCtrlMode.Text = "OFFLINE";
            }
            txtUpdateUser.Text = MPCF.Trim(View_Resource_Out.update_user_id);
            txtUpdateTime.Text = MPCF.MakeDateFormat(View_Resource_Out.update_time);
            
            return true;
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return false;
        }
    }
    
    private bool View_Event(char ProcStep)
    {
        
        
        RAS_View_Event_In_Tag View_Event_In = new RAS_View_Event_In_Tag();
        RAS_View_Event_Out_Tag View_Event_Out = new RAS_View_Event_Out_Tag();
        DateTime ThisMoment = new DateTime();
        View_Event_In.h_proc_step = ProcStep;
        View_Event_In.h_factory = MPGV.gsFactory;
        View_Event_In.h_language = MPGV.gcLanguage;
        View_Event_In.h_factory = MPGV.gsFactory;
        View_Event_In.h_user_id = MPGV.gsUserID;
        View_Event_In.event_id = cdvEventID.Text;
        
        if (RASCaster.RAS_View_Event(View_Event_In, ref View_Event_Out) == false)
        {
            MPCF.ShowMsgBox(h101stub.StatusMessage);
            return false;
        }
        
        if (View_Event_Out.h_status_value != MPGC.MP_SUCCESS_STATUS)
        {
            MPCF.ShowMsgBox(MPCF.MakeErrorMsg(View_Event_Out.h_msg_code, View_Event_Out.h_msg, View_Event_Out.h_db_err_msg, View_Event_Out.h_field_msg));
            return false;
        }
        if (MPCF.Trim(View_Event_Out.chart_flag) == "C")
        {
            lblChartID.Text = MPCF.FindLanguage("Chart ID", 0);
            txtChartID.Text = MPCF.Trim(View_Event_Out.chart_id);
            lblGraphType.Visible = true;
            cboGraphType.Visible = true;
            SetChartControl('C');
        }
        else if (MPCF.Trim(View_Event_Out.chart_flag) == "S")
        {
            lblChartID.Text = MPCF.FindLanguage("Chart Set ID", 0);
            txtChartID.Text = MPCF.Trim(View_Event_Out.chart_id);
            lblGraphType.Visible = false;
            cboGraphType.Visible = false;
            SetChartControl('S');
        }
        
        txtChangeUpDown.Visible = true;
        if (View_Event_Out.chg_up_down_flag == CHANGE)
        {
            if (MPCF.Trim(View_Event_Out.chg_up_down) == "U")
            {
                txtChangeUpDown.Text = "UP";
            }
            else if (MPCF.Trim(View_Event_Out.chg_up_down) == "D")
            {
                txtChangeUpDown.Text = "DOWN";
            }
        }
        else
        {
            txtChangeUpDown.Text = txtCurrentUpDown.Text;
        }
        if (View_Event_Out.chg_pri_sts_flag == OVERRIDE)
        {
            if (MPCF.Trim(View_Event_Out.tbl_pri_sts) != "")
            {
                cdvPrimaryChange.VisibleButton = true;
                cdvPrimaryChange.Tag = View_Event_Out.tbl_pri_sts;
            }
            else
            {
                cdvPrimaryChange.VisibleButton = false;
            }
            cdvPrimaryChange.Visible = true;
            cdvPrimaryChange.Text = View_Event_Out.chg_pri_sts;
            cdvPrimaryChange.ReadOnly = false;
            cdvPrimaryChange.BackColor = SystemColors.Window;
        }
        else
        {
            cdvPrimaryChange.Visible = true;
            cdvPrimaryChange.VisibleButton = false;
            cdvPrimaryChange.ReadOnly = true;
            cdvPrimaryChange.BackColor = SystemColors.Control;
            if (View_Event_Out.chg_pri_sts_flag == CHANGE)
            {
                cdvPrimaryChange.Text = View_Event_Out.chg_pri_sts;
            }
            else if (View_Event_Out.chg_pri_sts_flag == INCREASE)
            {
                cdvPrimaryChange.Text = Convert.ToString(MPCF.ToDbl(txtPrimaryCurrent.Text) + MPCF.ToDbl(View_Event_Out.chg_pri_sts));
            }
            else if (View_Event_Out.chg_pri_sts_flag == DECREASE)
            {
                cdvPrimaryChange.Text = Convert.ToString(MPCF.ToDbl(txtPrimaryCurrent.Text) - MPCF.ToDbl(View_Event_Out.chg_pri_sts));
            }
            else if (View_Event_Out.chg_pri_sts_flag == NOTCHANGE)
            {
                cdvPrimaryChange.Text = txtPrimaryCurrent.Text;
            }
            else if (View_Event_Out.chg_pri_sts_flag == TIME)
            {
                cdvPrimaryChange.Text = ThisMoment.Date.ToString();
            }
        }
        if (lblCurrentStatus1.Visible == true)
        {
            if (View_Event_Out.chg_flag_1 == OVERRIDE)
            {
                if (MPCF.Trim(View_Event_Out.tbl_1) != "")
                {
                    cdvChangeStatus1.VisibleButton = true;
                    cdvChangeStatus1.Tag = View_Event_Out.tbl_1;
                }
                else
                {
                    cdvChangeStatus1.VisibleButton = false;
                }
                cdvChangeStatus1.Visible = true;
                cdvChangeStatus1.Text = View_Event_Out.chg_sts_1;
                cdvChangeStatus1.ReadOnly = false;
                cdvChangeStatus1.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus1.Visible = true;
                cdvChangeStatus1.VisibleButton = false;
                cdvChangeStatus1.ReadOnly = true;
                cdvChangeStatus1.BackColor = SystemColors.Control;
                if (View_Event_Out.chg_flag_1 == CHANGE)
                {
                    cdvChangeStatus1.Text = View_Event_Out.chg_sts_1;
                }
                else if (View_Event_Out.chg_flag_1 == INCREASE)
                {
                    cdvChangeStatus1.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus1.Text) + MPCF.ToDbl(View_Event_Out.chg_sts_1));
                }
                else if (View_Event_Out.chg_flag_1 == DECREASE)
                {
                    cdvChangeStatus1.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus1.Text) - MPCF.ToDbl(View_Event_Out.chg_sts_1));
                }
                else if (View_Event_Out.chg_flag_1 == NOTCHANGE)
                {
                    cdvChangeStatus1.Text = txtCurrentStatus1.Text;
                }
                else if (View_Event_Out.chg_flag_1 == TIME)
                {
                    cdvChangeStatus1.Text = ThisMoment.Date.ToString();
                }
            }
        }
        if (lblCurrentStatus2.Visible == true)
        {
            if (View_Event_Out.chg_flag_2 == OVERRIDE)
            {
                if (MPCF.Trim(View_Event_Out.tbl_2) != "")
                {
                    cdvChangeStatus2.VisibleButton = true;
                    cdvChangeStatus2.Tag = View_Event_Out.tbl_2;
                }
                else
                {
                    cdvChangeStatus2.VisibleButton = false;
                }
                cdvChangeStatus2.Visible = true;
                cdvChangeStatus2.Text = View_Event_Out.chg_sts_2;
                cdvChangeStatus2.ReadOnly = false;
                cdvChangeStatus2.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus2.Visible = true;
                cdvChangeStatus2.VisibleButton = false;
                cdvChangeStatus2.ReadOnly = true;
                cdvChangeStatus2.BackColor = SystemColors.Control;
                if (View_Event_Out.chg_flag_2 == CHANGE)
                {
                    cdvChangeStatus2.Text = View_Event_Out.chg_sts_2;
                }
                else if (View_Event_Out.chg_flag_2 == INCREASE)
                {
                    cdvChangeStatus2.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus2.Text) + MPCF.ToDbl(View_Event_Out.chg_sts_2));
                }
                else if (View_Event_Out.chg_flag_2 == DECREASE)
                {
                    cdvChangeStatus2.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus2.Text) - MPCF.ToDbl(View_Event_Out.chg_sts_2));
                }
                else if (View_Event_Out.chg_flag_2 == NOTCHANGE)
                {
                    cdvChangeStatus2.Text = txtCurrentStatus2.Text;
                }
                else if (View_Event_Out.chg_flag_2 == TIME)
                {
                    cdvChangeStatus2.Text = ThisMoment.Date.ToString();
                }
            }
        }
        if (lblCurrentStatus3.Visible == true)
        {
            if (View_Event_Out.chg_flag_3 == OVERRIDE)
            {
                if (MPCF.Trim(View_Event_Out.tbl_3) != "")
                {
                    cdvChangeStatus3.VisibleButton = true;
                    cdvChangeStatus3.Tag = View_Event_Out.tbl_3;
                }
                else
                {
                    cdvChangeStatus3.VisibleButton = false;
                }
                cdvChangeStatus3.Visible = true;
                cdvChangeStatus3.Text = View_Event_Out.chg_sts_3;
                cdvChangeStatus3.ReadOnly = false;
                cdvChangeStatus3.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus3.Visible = true;
                cdvChangeStatus3.VisibleButton = false;
                cdvChangeStatus3.ReadOnly = true;
                cdvChangeStatus3.BackColor = SystemColors.Control;
                if (View_Event_Out.chg_flag_3 == CHANGE)
                {
                    cdvChangeStatus3.Text = View_Event_Out.chg_sts_3;
                }
                else if (View_Event_Out.chg_flag_3 == INCREASE)
                {
                    cdvChangeStatus3.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus3.Text) + MPCF.ToDbl(View_Event_Out.chg_sts_3));
                }
                else if (View_Event_Out.chg_flag_3 == DECREASE)
                {
                    cdvChangeStatus3.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus3.Text) - MPCF.ToDbl(View_Event_Out.chg_sts_3));
                }
                else if (View_Event_Out.chg_flag_3 == NOTCHANGE)
                {
                    cdvChangeStatus3.Text = txtCurrentStatus3.Text;
                }
                else if (View_Event_Out.chg_flag_3 == TIME)
                {
                    cdvChangeStatus3.Text = ThisMoment.Date.ToString();
                }
            }
        }
        if (lblCurrentStatus4.Visible == true)
        {
            if (View_Event_Out.chg_flag_4 == OVERRIDE)
            {
                if (MPCF.Trim(View_Event_Out.tbl_4) != "")
                {
                    cdvChangeStatus4.VisibleButton = true;
                    cdvChangeStatus4.Tag = View_Event_Out.tbl_4;
                }
                else
                {
                    cdvChangeStatus4.VisibleButton = false;
                }
                cdvChangeStatus4.Visible = true;
                cdvChangeStatus4.Text = View_Event_Out.chg_sts_4;
                cdvChangeStatus4.ReadOnly = false;
                cdvChangeStatus4.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus4.Visible = true;
                cdvChangeStatus4.VisibleButton = false;
                cdvChangeStatus4.ReadOnly = true;
                cdvChangeStatus4.BackColor = SystemColors.Control;
                if (View_Event_Out.chg_flag_4 == CHANGE)
                {
                    cdvChangeStatus4.Text = View_Event_Out.chg_sts_4;
                }
                else if (View_Event_Out.chg_flag_4 == INCREASE)
                {
                    cdvChangeStatus4.Text = Convert.ToString(Convert.ToString(MPCF.ToDbl(txtCurrentStatus4.Text) + MPCF.ToDbl(View_Event_Out.chg_sts_4)));
                }
                else if (View_Event_Out.chg_flag_4 == DECREASE)
                {
                    cdvChangeStatus4.Text = Convert.ToString(Convert.ToString(MPCF.ToDbl(txtCurrentStatus4.Text) - MPCF.ToDbl(View_Event_Out.chg_sts_4)));
                }
                else if (View_Event_Out.chg_flag_4 == NOTCHANGE)
                {
                    cdvChangeStatus4.Text = txtCurrentStatus4.Text;
                }
                else if (View_Event_Out.chg_flag_4 == TIME)
                {
                    cdvChangeStatus4.Text = ThisMoment.Date.ToString();
                }
            }
        }
        if (lblCurrentStatus5.Visible == true)
        {
            if (View_Event_Out.chg_flag_5 == OVERRIDE)
            {
                if (MPCF.Trim(View_Event_Out.tbl_5) != "")
                {
                    cdvChangeStatus5.VisibleButton = true;
                    cdvChangeStatus5.Tag = View_Event_Out.tbl_5;
                }
                else
                {
                    cdvChangeStatus5.VisibleButton = false;
                }
                cdvChangeStatus5.Visible = true;
                cdvChangeStatus5.Text = View_Event_Out.chg_sts_5;
                cdvChangeStatus5.ReadOnly = false;
                cdvChangeStatus5.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus5.Visible = true;
                cdvChangeStatus5.VisibleButton = false;
                cdvChangeStatus5.ReadOnly = true;
                cdvChangeStatus5.BackColor = SystemColors.Control;
                if (View_Event_Out.chg_flag_5 == CHANGE)
                {
                    cdvChangeStatus5.Text = View_Event_Out.chg_sts_5;
                }
                else if (View_Event_Out.chg_flag_5 == INCREASE)
                {
                    cdvChangeStatus5.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus5.Text) + MPCF.ToDbl(View_Event_Out.chg_sts_5));
                }
                else if (View_Event_Out.chg_flag_5 == DECREASE)
                {
                    cdvChangeStatus5.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus5.Text) - MPCF.ToDbl(View_Event_Out.chg_sts_5));
                }
                else if (View_Event_Out.chg_flag_5 == NOTCHANGE)
                {
                    cdvChangeStatus5.Text = txtCurrentStatus5.Text;
                }
                else if (View_Event_Out.chg_flag_5 == TIME)
                {
                    cdvChangeStatus5.Text = ThisMoment.Date.ToString();
                }
            }
        }
        if (lblCurrentStatus6.Visible == true)
        {
            if (View_Event_Out.chg_flag_6 == OVERRIDE)
            {
                if (MPCF.Trim(View_Event_Out.tbl_6) != "")
                {
                    cdvChangeStatus6.VisibleButton = true;
                    cdvChangeStatus6.Tag = View_Event_Out.tbl_6;
                }
                else
                {
                    cdvChangeStatus6.VisibleButton = false;
                }
                cdvChangeStatus6.Visible = true;
                cdvChangeStatus6.Text = View_Event_Out.chg_sts_6;
                cdvChangeStatus6.ReadOnly = false;
                cdvChangeStatus6.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus6.Visible = true;
                cdvChangeStatus6.VisibleButton = false;
                cdvChangeStatus6.ReadOnly = true;
                cdvChangeStatus6.BackColor = SystemColors.Control;
                if (View_Event_Out.chg_flag_6 == CHANGE)
                {
                    cdvChangeStatus6.Text = View_Event_Out.chg_sts_6;
                }
                else if (View_Event_Out.chg_flag_6 == INCREASE)
                {
                    cdvChangeStatus6.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus6.Text) + MPCF.ToDbl(View_Event_Out.chg_sts_6));
                }
                else if (View_Event_Out.chg_flag_6 == DECREASE)
                {
                    cdvChangeStatus6.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus6.Text) - MPCF.ToDbl(View_Event_Out.chg_sts_6));
                }
                else if (View_Event_Out.chg_flag_6 == NOTCHANGE)
                {
                    cdvChangeStatus6.Text = txtCurrentStatus6.Text;
                }
                else if (View_Event_Out.chg_flag_6 == TIME)
                {
                    cdvChangeStatus6.Text = ThisMoment.Date.ToString();
                }
            }
        }
        if (lblCurrentStatus7.Visible == true)
        {
            if (View_Event_Out.chg_flag_7 == OVERRIDE)
            {
                if (MPCF.Trim(View_Event_Out.tbl_7) != "")
                {
                    cdvChangeStatus7.VisibleButton = true;
                    cdvChangeStatus7.Tag = View_Event_Out.tbl_7;
                }
                else
                {
                    cdvChangeStatus7.VisibleButton = false;
                }
                cdvChangeStatus7.Visible = true;
                cdvChangeStatus7.Text = View_Event_Out.chg_sts_7;
                cdvChangeStatus7.ReadOnly = false;
                cdvChangeStatus7.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus7.Visible = true;
                cdvChangeStatus7.VisibleButton = false;
                cdvChangeStatus7.ReadOnly = true;
                cdvChangeStatus7.BackColor = SystemColors.Control;
                if (View_Event_Out.chg_flag_7 == CHANGE)
                {
                    cdvChangeStatus7.Text = View_Event_Out.chg_sts_7;
                }
                else if (View_Event_Out.chg_flag_7 == INCREASE)
                {
                    cdvChangeStatus7.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus7.Text) + MPCF.ToDbl(View_Event_Out.chg_sts_7));
                }
                else if (View_Event_Out.chg_flag_7 == DECREASE)
                {
                    cdvChangeStatus7.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus7.Text) - MPCF.ToDbl(View_Event_Out.chg_sts_7));
                }
                else if (View_Event_Out.chg_flag_7 == NOTCHANGE)
                {
                    cdvChangeStatus7.Text = txtCurrentStatus7.Text;
                }
                else if (View_Event_Out.chg_flag_7 == TIME)
                {
                    cdvChangeStatus7.Text = ThisMoment.Date.ToString();
                }
            }
        }
        if (lblCurrentStatus8.Visible == true)
        {
            if (View_Event_Out.chg_flag_8 == OVERRIDE)
            {
                if (MPCF.Trim(View_Event_Out.tbl_8) != "")
                {
                    cdvChangeStatus8.VisibleButton = true;
                    cdvChangeStatus8.Tag = View_Event_Out.tbl_8;
                }
                else
                {
                    cdvChangeStatus8.VisibleButton = false;
                }
                cdvChangeStatus8.Visible = true;
                cdvChangeStatus8.Text = View_Event_Out.chg_sts_8;
                cdvChangeStatus8.ReadOnly = false;
                cdvChangeStatus8.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus8.Visible = true;
                cdvChangeStatus8.VisibleButton = false;
                cdvChangeStatus8.ReadOnly = true;
                cdvChangeStatus8.BackColor = SystemColors.Control;
                if (View_Event_Out.chg_flag_8 == CHANGE)
                {
                    cdvChangeStatus8.Text = View_Event_Out.chg_sts_8;
                }
                else if (View_Event_Out.chg_flag_8 == INCREASE)
                {
                    cdvChangeStatus8.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus8.Text) + MPCF.ToDbl(View_Event_Out.chg_sts_8));
                }
                else if (View_Event_Out.chg_flag_8 == DECREASE)
                {
                    cdvChangeStatus8.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus8.Text) - MPCF.ToDbl(View_Event_Out.chg_sts_8));
                }
                else if (View_Event_Out.chg_flag_8 == NOTCHANGE)
                {
                    cdvChangeStatus8.Text = txtCurrentStatus8.Text;
                }
                else if (View_Event_Out.chg_flag_8 == TIME)
                {
                    cdvChangeStatus8.Text = ThisMoment.Date.ToString();
                }
            }
        }
        if (lblCurrentStatus9.Visible == true)
        {
            if (View_Event_Out.chg_flag_9 == OVERRIDE)
            {
                if (MPCF.Trim(View_Event_Out.tbl_9) != "")
                {
                    cdvChangeStatus9.VisibleButton = true;
                    cdvChangeStatus9.Tag = View_Event_Out.tbl_9;
                }
                else
                {
                    cdvChangeStatus9.VisibleButton = false;
                }
                cdvChangeStatus9.Visible = true;
                cdvChangeStatus9.Text = View_Event_Out.chg_sts_9;
                cdvChangeStatus9.ReadOnly = false;
                cdvChangeStatus9.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus9.Visible = true;
                cdvChangeStatus9.VisibleButton = false;
                cdvChangeStatus9.ReadOnly = true;
                cdvChangeStatus9.BackColor = SystemColors.Control;
                if (View_Event_Out.chg_flag_9 == CHANGE)
                {
                    cdvChangeStatus9.Text = View_Event_Out.chg_sts_9;
                }
                else if (View_Event_Out.chg_flag_9 == INCREASE)
                {
                    cdvChangeStatus9.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus9.Text) + MPCF.ToDbl(View_Event_Out.chg_sts_9));
                }
                else if (View_Event_Out.chg_flag_9 == DECREASE)
                {
                    cdvChangeStatus9.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus9.Text) - MPCF.ToDbl(View_Event_Out.chg_sts_9));
                }
                else if (View_Event_Out.chg_flag_9 == NOTCHANGE)
                {
                    cdvChangeStatus9.Text = txtCurrentStatus9.Text;
                }
                else if (View_Event_Out.chg_flag_9 == TIME)
                {
                    cdvChangeStatus9.Text = ThisMoment.Date.ToString();
                }
            }
        }
        if (lblCurrentStatus10.Visible == true)
        {
            if (View_Event_Out.chg_flag_10 == OVERRIDE)
            {
                if (MPCF.Trim(View_Event_Out.tbl_10) != "")
                {
                    cdvChangeStatus10.VisibleButton = true;
                    cdvChangeStatus10.Tag = View_Event_Out.tbl_10;
                }
                else
                {
                    cdvChangeStatus10.VisibleButton = false;
                }
                cdvChangeStatus10.Visible = true;
                cdvChangeStatus10.Text = View_Event_Out.chg_sts_10;
                cdvChangeStatus10.ReadOnly = false;
                cdvChangeStatus10.BackColor = SystemColors.Window;
            }
            else
            {
                cdvChangeStatus10.Visible = true;
                cdvChangeStatus10.VisibleButton = false;
                cdvChangeStatus10.ReadOnly = true;
                cdvChangeStatus10.BackColor = SystemColors.Control;
                if (View_Event_Out.chg_flag_10 == CHANGE)
                {
                    cdvChangeStatus10.Text = View_Event_Out.chg_sts_10;
                }
                else if (View_Event_Out.chg_flag_10 == INCREASE)
                {
                    cdvChangeStatus10.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus10.Text) + MPCF.ToDbl(View_Event_Out.chg_sts_10));
                }
                else if (View_Event_Out.chg_flag_10 == DECREASE)
                {
                    cdvChangeStatus10.Text = Convert.ToString(MPCF.ToDbl(txtCurrentStatus10.Text) - MPCF.ToDbl(View_Event_Out.chg_sts_10));
                }
                else if (View_Event_Out.chg_flag_10 == NOTCHANGE)
                {
                    cdvChangeStatus10.Text = txtCurrentStatus10.Text;
                }
                else if (View_Event_Out.chg_flag_10 == TIME)
                {
                    cdvChangeStatus10.Text = ThisMoment.Date.ToString();
                }
            }
        }
        
        return true;
        
    }
    
    // View_Factory_ResStatus()
    //       -  View Factory Resource Status Prompt
    // Return Value
    //       - Boolean : True or False
    // Arguments
    //       -
    private bool View_Factory_ResStatus()
    {
        WIP_View_Factory_In_Tag View_Factory_In = new WIP_View_Factory_In_Tag();
        WIP_View_Factory_Out_Tag View_Factory_Out = new WIP_View_Factory_Out_Tag();
        
        try
        {
            View_Factory_In.h_proc_step = '1';
            View_Factory_In.h_passport = MPGV.gsPassport;
            View_Factory_In.h_language = MPGV.gcLanguage;
            View_Factory_In.h_user_id = MPGV.gsUserID;
            View_Factory_In.h_password = MPGV.gsPassword;
            View_Factory_In.h_factory = MPGV.gsFactory;
            
            if (WIPCaster.WIP_View_Factory(View_Factory_In, ref View_Factory_Out) == false)
            {
                MPCF.ShowMsgBox(h101stub.StatusMessage);
                return false;
            }
            if (View_Factory_Out.h_status_value != MPGC.MP_SUCCESS_STATUS)
            {
                MPCF.ShowMsgBox(MPCF.MakeErrorMsg(View_Factory_Out.h_msg_code, View_Factory_Out.h_msg, View_Factory_Out.h_db_err_msg, View_Factory_Out.h_field_msg));
                return false;
            }
            
            if (MPCF.Trim(View_Factory_Out.res_sts_1) != "")
            {
                lblCurrentStatus1.Text = MPCF.Trim(View_Factory_Out.res_sts_1);
                lblCurrentStatus1.Visible = true;
                txtCurrentStatus1.Visible = true;
            }
            else
            {
                lblCurrentStatus1.Visible = false;
                txtCurrentStatus1.Visible = false;
                cdvChangeStatus1.Visible = false;
            }
            if (MPCF.Trim(View_Factory_Out.res_sts_2) != "")
            {
                lblCurrentStatus2.Text = MPCF.Trim(View_Factory_Out.res_sts_2);
                lblCurrentStatus2.Visible = true;
                txtCurrentStatus2.Visible = true;
            }
            else
            {
                lblCurrentStatus2.Visible = false;
                txtCurrentStatus2.Visible = false;
                cdvChangeStatus2.Visible = false;
            }
            if (MPCF.Trim(View_Factory_Out.res_sts_3) != "")
            {
                lblCurrentStatus3.Text = MPCF.Trim(View_Factory_Out.res_sts_3);
                lblCurrentStatus3.Visible = true;
                txtCurrentStatus3.Visible = true;
            }
            else
            {
                lblCurrentStatus3.Visible = false;
                txtCurrentStatus3.Visible = false;
                cdvChangeStatus3.Visible = false;
            }
            if (MPCF.Trim(View_Factory_Out.res_sts_4) != "")
            {
                lblCurrentStatus4.Text = MPCF.Trim(View_Factory_Out.res_sts_4);
                lblCurrentStatus4.Visible = true;
                txtCurrentStatus4.Visible = true;
            }
            else
            {
                lblCurrentStatus4.Visible = false;
                txtCurrentStatus4.Visible = false;
                cdvChangeStatus4.Visible = false;
            }
            if (MPCF.Trim(View_Factory_Out.res_sts_5) != "")
            {
                lblCurrentStatus5.Text = MPCF.Trim(View_Factory_Out.res_sts_5);
                lblCurrentStatus5.Visible = true;
                txtCurrentStatus5.Visible = true;
            }
            else
            {
                lblCurrentStatus5.Visible = false;
                txtCurrentStatus5.Visible = false;
                cdvChangeStatus5.Visible = false;
            }
            if (MPCF.Trim(View_Factory_Out.res_sts_6) != "")
            {
                lblCurrentStatus6.Text = MPCF.Trim(View_Factory_Out.res_sts_6);
                lblCurrentStatus6.Visible = true;
                txtCurrentStatus6.Visible = true;
            }
            else
            {
                lblCurrentStatus6.Visible = false;
                txtCurrentStatus6.Visible = false;
                cdvChangeStatus6.Visible = false;
            }
            if (MPCF.Trim(View_Factory_Out.res_sts_7) != "")
            {
                lblCurrentStatus7.Text = MPCF.Trim(View_Factory_Out.res_sts_7);
                lblCurrentStatus7.Visible = true;
                txtCurrentStatus7.Visible = true;
            }
            else
            {
                lblCurrentStatus7.Visible = false;
                txtCurrentStatus7.Visible = false;
                cdvChangeStatus7.Visible = false;
            }
            if (MPCF.Trim(View_Factory_Out.res_sts_8) != "")
            {
                lblCurrentStatus8.Text = MPCF.Trim(View_Factory_Out.res_sts_8);
                lblCurrentStatus8.Visible = true;
                txtCurrentStatus8.Visible = true;
            }
            else
            {
                lblCurrentStatus8.Visible = false;
                txtCurrentStatus8.Visible = false;
                cdvChangeStatus8.Visible = false;
            }
            if (MPCF.Trim(View_Factory_Out.res_sts_9) != "")
            {
                lblCurrentStatus9.Text = MPCF.Trim(View_Factory_Out.res_sts_9);
                lblCurrentStatus9.Visible = true;
                txtCurrentStatus9.Visible = true;
            }
            else
            {
                lblCurrentStatus9.Visible = false;
                txtCurrentStatus9.Visible = false;
                cdvChangeStatus9.Visible = false;
            }
            if (MPCF.Trim(View_Factory_Out.res_sts_10) != "")
            {
                lblCurrentStatus10.Text = MPCF.Trim(View_Factory_Out.res_sts_10);
                lblCurrentStatus10.Visible = true;
                txtCurrentStatus10.Visible = true;
            }
            else
            {
                lblCurrentStatus10.Visible = false;
                txtCurrentStatus10.Visible = false;
                cdvChangeStatus10.Visible = false;
            }
            
            return true;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return false;
        }
        
    }
    private void ChangeStatusClear()
    {
        txtChangeUpDown.Text = "";
        cdvPrimaryChange.Text = "";
        cdvChangeStatus1.Text = "";
        cdvChangeStatus2.Text = "";
        cdvChangeStatus3.Text = "";
        cdvChangeStatus4.Text = "";
        cdvChangeStatus5.Text = "";
        cdvChangeStatus6.Text = "";
        cdvChangeStatus7.Text = "";
        cdvChangeStatus8.Text = "";
        cdvChangeStatus9.Text = "";
        cdvChangeStatus10.Text = "";
    }
    private void ChangeFieldVisible()
    {
        txtChangeUpDown.Visible = false;
        cdvPrimaryChange.Visible = false;
        cdvChangeStatus1.Visible = false;
        cdvChangeStatus2.Visible = false;
        cdvChangeStatus3.Visible = false;
        cdvChangeStatus4.Visible = false;
        cdvChangeStatus5.Visible = false;
        cdvChangeStatus6.Visible = false;
        cdvChangeStatus7.Visible = false;
        cdvChangeStatus8.Visible = false;
        cdvChangeStatus9.Visible = false;
        cdvChangeStatus10.Visible = false;
    }
    
    // SetChartControl()
    //       - Set Chart Control
    // Return Value
    //       - Boolean : True or False
    // Arguments
    //       -
    //
    private bool SetChartControl(char sChartFlag)
    {
        
        try
        {
            pnlChartSet.Controls.Clear();
            pnlChartSet.Tag = "";
            if (sChartFlag == 'C')
            {
                udcChartInfo ctrlChartInfo = new udcChartInfo();
                Panel pnlChart = new Panel();
                ctrlChartInfo.Dock = DockStyle.Fill;
                pnlChart.Controls.Add(ctrlChartInfo);
                pnlChart.Dock = DockStyle.Fill;
                pnlChartSet.Controls.Add(pnlChart);
                ctrlChartInfo.ChartID = MPCF.Trim(txtChartID.Text);
                ctrlChartInfo.ViewChartInfo(true);
                if (ctrlChartInfo.ViewChart == "Y")
                {
                    ctrlChartInfo.InitChart();
                    ctrlChartInfo.ViewControlChart(true);
                }
                pnlChartSet.Tag = "C";
                cboGraphType.SelectedIndex = ctrlChartInfo.GraphTypeIndex;
            }
            else if (sChartFlag == 'S')
            {
                
                SPC_View_Attach_Chart_Set_List_In_Tag View_Attach_Chart_Set_List_In = new SPC_View_Attach_Chart_Set_List_In_Tag();
                SPC_View_Attach_Chart_Set_List_Out_Tag View_Attach_Chart_Set_List_Out = new SPC_View_Attach_Chart_Set_List_Out_Tag();
                int i;
                
                View_Attach_Chart_Set_List_In.h_proc_step = '1';
                View_Attach_Chart_Set_List_In.h_passport = MPGV.gsPassport;
                View_Attach_Chart_Set_List_In.h_language = MPGV.gcLanguage;
                View_Attach_Chart_Set_List_In.h_factory = MPGV.gsFactory;
                View_Attach_Chart_Set_List_In.h_user_id = MPGV.gsUserID;
                View_Attach_Chart_Set_List_In.h_password = MPGV.gsPassword;
                View_Attach_Chart_Set_List_In.chart_set_id = MPCF.Trim(txtChartID.Text);
                View_Attach_Chart_Set_List_In.next_chart_id = "";
                
                do
                {
                    if (SPCCaster.SPC_View_Attach_Chart_Set_List(View_Attach_Chart_Set_List_In, ref View_Attach_Chart_Set_List_Out) == false)
                    {
                        MPCF.ShowMsgBox(h101stub.StatusMessage);
                        return false;
                    }
                    if (View_Attach_Chart_Set_List_Out.h_status_value != MPGC.MP_SUCCESS_STATUS)
                    {
                        MPCF.ShowMsgBox(MPCF.MakeErrorMsg(View_Attach_Chart_Set_List_Out.h_msg_code, View_Attach_Chart_Set_List_Out.h_msg, View_Attach_Chart_Set_List_Out.h_db_err_msg, View_Attach_Chart_Set_List_Out.h_field_msg));
                        return false;
                    }
                    
                    for (i = 0; i <= View_Attach_Chart_Set_List_Out.count - 1; i++)
                    {
                        Label lblChartID = new Label();
                        Panel pnlChart = new Panel();
                        udcChartInfo ctrlChartInfo = new udcChartInfo();
                        lblChartID.Text = View_Attach_Chart_Set_List_Out.chart_list[i].chart_id;
                        lblChartID.TextAlign = ContentAlignment.MiddleLeft;
                        lblChartID.Height = 13;
                        lblChartID.Dock = DockStyle.Top;
                        ctrlChartInfo.ChartID = View_Attach_Chart_Set_List_Out.chart_list[i].chart_id;
                        ctrlChartInfo.Dock = DockStyle.Fill;
                        pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                        pnlChart.Controls.Add(ctrlChartInfo);
                        pnlChart.Controls.Add(lblChartID);
                        pnlChart.Dock = DockStyle.Top;
                        pnlChart.Height = 256;
                        pnlChartSet.Controls.Add(pnlChart);
                        ctrlChartInfo.ViewChartInfo(false);
                    }
                    View_Attach_Chart_Set_List_In.next_chart_id = View_Attach_Chart_Set_List_Out.next_chart_id;
                    
                } while (string.IsNullOrEmpty(View_Attach_Chart_Set_List_In.next_chart_id) == false);
                
                pnlChartSet.Tag = "S";
            }
            
            return true;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox("frmSPCTranCollectResDatabyChartSet.SetChartControl()\n" + ex.Message);
            return false;
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
    
    private void cdvResID_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        
        if (e.KeyChar == (char)13)
        {
            //Call View Resource Function
            View_Resource();
        }
        
    }
    
    private void frmSPCTranEvent_Load(object sender, System.EventArgs e)
    {
        try
        {
            MPGV.gIBaseFormEvent.Form_Load(this, e);
            
            pnlTranTime.Visible = MPGO.IsUseBackDate();
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            modSPCFunctions.SetGraphList(cboGraphType);
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
        }
        
    }
    
    private void frmSPCTranEvent_Activated(object sender, System.EventArgs e)
    {
        try
        {
            //dtpTransTime = Now
            if (LoadFlag == false)
            {
                MPCF.FieldVisible(grpCurrentStatus, false, lblUpDown, lblPrimaryStatus, txtCurrentUpDown, txtPrimaryCurrent, null);
                MPCR.SetCMFItem(MPGC.MP_CMF_TRN_EVENT, "lblCMF", "cdvCMF", grpGeneral);
                ClearData("1");
                if (GetResourceIDList() == false)
                {
                    return;
                }
                
                if (MPCF.Trim(MPGV.gsCurrentRes_ID) != "")
                {
                    cdvResID.Text = MPGV.gsCurrentRes_ID;
                    View_Resource();
                }
                
                LoadFlag = true;
            }
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
        }
        
    }
    
    private void frmSPCTranEvent_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            //Call View Resource Function
            View_Resource();
            RASLIST.ViewResEventList(cdvEventID, '1', cdvResID.Text, null, "");
        }
        
        if (pnlChartSet.Controls.Count == 0)
        {
            return;
        }
        
    }
    
    private void btnProcess_Click(System.Object sender, System.EventArgs e)
    {
        //Call Resource Event Function
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
                        ((udcChartInfo) ctl2).ClearBackColor();
                    }
                }
            }
        }
        if (CheckCondition("Collect_Res_Data") == true)
        {
            if (Resource_Event(MPGC.MP_STEP_TRAN) == true)
            {
                View_Resource();
                View_Event('1');
            }
        }
    }
    
    private void cdvEventID_ButtonPress(object sender, System.EventArgs e)
    {
        cdvEventID.Init();
        MPCF.InitListView(cdvEventID.GetListView);
        cdvEventID.Columns.Add("Event", 50, HorizontalAlignment.Left);
        cdvEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
        cdvEventID.SelectedSubItemIndex = 0;
        RASLIST.ViewResEventList(cdvEventID.GetListView, '1', cdvResID.Text, null, "");
    }
    
    private void cdvResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        pnlChartSet.Controls.Clear();
        pnlChartSet.Tag = null;
        ClearData("1");
        ChangeFieldVisible();
        cdvEventID.Init();
        View_Resource();
    }
    
    private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
    {
        ClearData("1");
        cdvEventID.Init();
    }
    
    private void cdvEventID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        txtChartID.Text = "";
        pnlChartSet.Controls.Clear();
        pnlChartSet.Tag = null;
        ChangeStatusClear();
        txtEventDesc.Text = cdvEventID.SelectedItem.SubItems[1].Text;
        View_Event('1');
    }
    
    private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
    {
        MPCR.ProcGRPCMFButtonPress(sender);
    }
    
    private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        MPCR.CheckCMFKeyPress(sender, e);
    }
    
    private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        
        txtTranDateTime.Visible = ! chkTranDateTime.Checked;
        
        dtpTranDate.Enabled = chkTranDateTime.Checked;
        dtpTranTime.Enabled = chkTranDateTime.Checked;
        
    }
    
    private void cdvPrimaryChange_ButtonPress(System.Object sender, System.EventArgs e)
    {
        Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
        
        cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
        
        cdvTemp.Init();
        MPCF.InitListView(cdvTemp.GetListView);
        cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
        cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
        cdvTemp.SelectedSubItemIndex = 0;
        BASLIST.ViewGCMDataList(cdvTemp.GetListView, '2', MPCF.Trim(cdvTemp.Tag));
        
    }
    
    private void cdvEventID_TextBoxTextChanged(object sender, System.EventArgs e)
    {
        txtChartID.Text = "";
        pnlChartSet.Controls.Clear();
        pnlChartSet.Tag = null;
        ChangeStatusClear();
    }
}


//#End If

}
