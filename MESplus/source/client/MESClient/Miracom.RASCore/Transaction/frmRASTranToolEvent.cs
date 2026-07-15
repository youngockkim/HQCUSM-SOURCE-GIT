
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
using System.Collections.Generic;

//#If _TOOL = True Then

namespace Miracom.RASCore
{
    public class frmRASTranToolEvent : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASTranToolEvent()
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

        
        



        private System.Windows.Forms.Panel pnlRes;
        private System.Windows.Forms.GroupBox grpEvent;
        private System.Windows.Forms.Label lblEventID;
        private System.Windows.Forms.GroupBox grpResource;
        private System.Windows.Forms.TextBox txtLastEvent;
        private System.Windows.Forms.Label lblLastEvent;
        private System.Windows.Forms.TextBox txtLastEventTime;
        private System.Windows.Forms.Label lblLastEventTime;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.Label lblComment;
        protected System.Windows.Forms.Panel pnlTranTime;
        protected System.Windows.Forms.TextBox txtTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranTime;
        protected System.Windows.Forms.CheckBox chkTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.Label lblToolType;
        private System.Windows.Forms.Label Label1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToolEventID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToolID;
        private System.Windows.Forms.TabControl tabToolEvent;
        private System.Windows.Forms.TabPage tpToolInfo;
        private System.Windows.Forms.TabPage tpCleanInfo;
        private System.Windows.Forms.Panel pnlMain;
        protected System.Windows.Forms.Label lblDefectComment;
        protected System.Windows.Forms.TextBox txtDefectComment;
        private System.Windows.Forms.TextBox txtChkUser2;
        private System.Windows.Forms.TextBox txtChkUser1;
        private System.Windows.Forms.Label lblChkUser2;
        private System.Windows.Forms.Label lblAttachFile1;
        private System.Windows.Forms.Button btnFileOpen1;
        private System.Windows.Forms.TextBox txtAttachFile1;
        private System.Windows.Forms.Label lblCauseSubRes;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubResID;
        private System.Windows.Forms.Label lblChkUser1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblCauseRes;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private System.Windows.Forms.Label lblCauseOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFlow;
        private System.Windows.Forms.Label lblCauseFlow;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDefectCode;
        private System.Windows.Forms.Label lblDefectCode;
        private System.Windows.Forms.TextBox txtCellZ;
        private System.Windows.Forms.TextBox txtCellY;
        private System.Windows.Forms.TextBox txtCellX;
        private System.Windows.Forms.Label lblCellZ;
        private System.Windows.Forms.Label lblCellY;
        private System.Windows.Forms.Label lblCellX;
        private System.Windows.Forms.TextBox txtLocZ;
        private System.Windows.Forms.TextBox txtLocY;
        private System.Windows.Forms.TextBox txtLocX;
        private System.Windows.Forms.Label lblLocZ;
        private System.Windows.Forms.Label lblLocY;
        private System.Windows.Forms.Label lblLocX;
        private System.Windows.Forms.Label lblCellInfo;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        private System.Windows.Forms.Panel pnlCleanInfo;
        private System.Windows.Forms.GroupBox grpDefectDetail;
        private System.Windows.Forms.RadioButton rdoData;
        private System.Windows.Forms.RadioButton rdoDefectCode;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.GroupBox grpDefectInfo;
        private System.Windows.Forms.Button btnDefectView;
        private System.Windows.Forms.Button btnCleanView;
        private System.Windows.Forms.GroupBox grpCleanInfo;
        private System.Windows.Forms.Panel pnlCleanSheet;
        private System.Windows.Forms.Button btnDefectMinus;
        private System.Windows.Forms.GroupBox grpComment;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Panel pnlDefectInfo;
        private System.Windows.Forms.ToolTip ttXY;
        private System.Windows.Forms.TextBox txtCellXCount;
        private System.Windows.Forms.TextBox txtCellYCount;
        private System.Windows.Forms.TextBox txtCellYSize;
        private System.Windows.Forms.TextBox txtCellXSize;
        private System.Windows.Forms.GroupBox grpDefectComment;
        private System.Windows.Forms.Panel pnlDefectMain;
        private System.Windows.Forms.Button btnPoint;
        private System.Windows.Forms.Button btnLens;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtDecimalPoint;
        private System.Windows.Forms.Label lblCell2;
        private System.Windows.Forms.Label lblLoc2;
        private System.Windows.Forms.Panel pnlDefect;
        private System.Windows.Forms.ComboBox cboPixelSize;
        private System.Windows.Forms.HScrollBar HeScroll;
        private System.Windows.Forms.VScrollBar VeScroll;
        private System.Windows.Forms.Panel pnlDefectBack;
        private System.Windows.Forms.Label lbldecode;
        private System.Windows.Forms.Panel pnlCleanMain;
        private System.Windows.Forms.Panel pnlCleaningBack;
        private System.Windows.Forms.Panel pnlCleaning;
        private System.Windows.Forms.VScrollBar VcScroll;
        private System.Windows.Forms.HScrollBar HcScroll;
        private System.Windows.Forms.Label lblCellMinus;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Label Label11;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Panel pnlDefectSheet;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDefectCodeClean;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label lblCell2Clean;
        private System.Windows.Forms.Label lbldecodeClean;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label lblLoc2Clean;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox grpPnlControl;
        private System.Windows.Forms.Button btnLocDrag;
        private System.Windows.Forms.Button btnHands;
        private System.Windows.Forms.Button btnDefectClick;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label Label6;
        protected FarPoint.Win.Spread.FpSpread spdCleanData;
        protected FarPoint.Win.Spread.SheetView spdCleanData_LotInfo;
        protected FarPoint.Win.Spread.FpSpread spdDefectData;
        protected FarPoint.Win.Spread.SheetView spdDefectData_LotInfo;
        private MESCore.Controls.udcToolStatus cdvToolEvent;
        private System.Windows.Forms.TabPage tpDefectInfo;
        
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASTranToolEvent));
            this.pnlRes = new System.Windows.Forms.Panel();
            this.grpResource = new System.Windows.Forms.GroupBox();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranDateTime = new System.Windows.Forms.TextBox();
            this.dtpTranTime = new System.Windows.Forms.DateTimePicker();
            this.chkTranDateTime = new System.Windows.Forms.CheckBox();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToolType = new System.Windows.Forms.Label();
            this.cdvToolID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEventID = new System.Windows.Forms.Label();
            this.grpEvent = new System.Windows.Forms.GroupBox();
            this.cdvToolEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtLastEventTime = new System.Windows.Forms.TextBox();
            this.lblLastEventTime = new System.Windows.Forms.Label();
            this.txtLastEvent = new System.Windows.Forms.TextBox();
            this.lblLastEvent = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.tabToolEvent = new System.Windows.Forms.TabControl();
            this.tpToolInfo = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.cdvToolEvent = new Miracom.MESCore.Controls.udcToolStatus();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.tpCleanInfo = new System.Windows.Forms.TabPage();
            this.pnlCleanMain = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblLoc2Clean = new System.Windows.Forms.Label();
            this.lblCell2Clean = new System.Windows.Forms.Label();
            this.lbldecodeClean = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.HcScroll = new System.Windows.Forms.HScrollBar();
            this.VcScroll = new System.Windows.Forms.VScrollBar();
            this.pnlCleaningBack = new System.Windows.Forms.Panel();
            this.pnlCleaning = new System.Windows.Forms.Panel();
            this.pnlCleanInfo = new System.Windows.Forms.Panel();
            this.pnlCleanSheet = new System.Windows.Forms.Panel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.spdCleanData = new FarPoint.Win.Spread.FpSpread();
            this.spdCleanData_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.grpCleanInfo = new System.Windows.Forms.GroupBox();
            this.cdvDefectCodeClean = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.btnCleanView = new System.Windows.Forms.Button();
            this.rdoData = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoDefectCode = new System.Windows.Forms.RadioButton();
            this.tpDefectInfo = new System.Windows.Forms.TabPage();
            this.pnlDefectMain = new System.Windows.Forms.Panel();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.pnlDefectBack = new System.Windows.Forms.Panel();
            this.pnlDefect = new System.Windows.Forms.Panel();
            this.HeScroll = new System.Windows.Forms.HScrollBar();
            this.VeScroll = new System.Windows.Forms.VScrollBar();
            this.lblLoc2 = new System.Windows.Forms.Label();
            this.lblCell2 = new System.Windows.Forms.Label();
            this.lbldecode = new System.Windows.Forms.Label();
            this.pnlDefectInfo = new System.Windows.Forms.Panel();
            this.pnlDefectSheet = new System.Windows.Forms.Panel();
            this.spdDefectData = new FarPoint.Win.Spread.FpSpread();
            this.spdDefectData_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.grpDefectInfo = new System.Windows.Forms.GroupBox();
            this.lblCellMinus = new System.Windows.Forms.Label();
            this.lblCellZ = new System.Windows.Forms.Label();
            this.lblCellY = new System.Windows.Forms.Label();
            this.lblCellX = new System.Windows.Forms.Label();
            this.lblCellInfo = new System.Windows.Forms.Label();
            this.btnDefectMinus = new System.Windows.Forms.Button();
            this.txtLocZ = new System.Windows.Forms.TextBox();
            this.txtLocY = new System.Windows.Forms.TextBox();
            this.txtLocX = new System.Windows.Forms.TextBox();
            this.lblLocZ = new System.Windows.Forms.Label();
            this.lblLocY = new System.Windows.Forms.Label();
            this.lblLocX = new System.Windows.Forms.Label();
            this.txtCellZ = new System.Windows.Forms.TextBox();
            this.txtCellY = new System.Windows.Forms.TextBox();
            this.txtCellX = new System.Windows.Forms.TextBox();
            this.cdvDefectCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDefectCode = new System.Windows.Forms.Label();
            this.btnDefectView = new System.Windows.Forms.Button();
            this.grpDefectDetail = new System.Windows.Forms.GroupBox();
            this.txtChkUser2 = new System.Windows.Forms.TextBox();
            this.txtChkUser1 = new System.Windows.Forms.TextBox();
            this.lblChkUser2 = new System.Windows.Forms.Label();
            this.lblAttachFile1 = new System.Windows.Forms.Label();
            this.btnFileOpen1 = new System.Windows.Forms.Button();
            this.txtAttachFile1 = new System.Windows.Forms.TextBox();
            this.lblCauseSubRes = new System.Windows.Forms.Label();
            this.cdvSubResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChkUser1 = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCauseRes = new System.Windows.Forms.Label();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCauseOper = new System.Windows.Forms.Label();
            this.cdvFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCauseFlow = new System.Windows.Forms.Label();
            this.grpDefectComment = new System.Windows.Forms.GroupBox();
            this.txtDefectComment = new System.Windows.Forms.TextBox();
            this.lblDefectComment = new System.Windows.Forms.Label();
            this.btnLocDrag = new System.Windows.Forms.Button();
            this.btnHands = new System.Windows.Forms.Button();
            this.btnLens = new System.Windows.Forms.Button();
            this.cboPixelSize = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtDecimalPoint = new System.Windows.Forms.TextBox();
            this.btnPoint = new System.Windows.Forms.Button();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ttXY = new System.Windows.Forms.ToolTip(this.components);
            this.btnDefectClick = new System.Windows.Forms.Button();
            this.txtCellXCount = new System.Windows.Forms.TextBox();
            this.txtCellYCount = new System.Windows.Forms.TextBox();
            this.txtCellYSize = new System.Windows.Forms.TextBox();
            this.txtCellXSize = new System.Windows.Forms.TextBox();
            this.grpPnlControl = new System.Windows.Forms.GroupBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlRes.SuspendLayout();
            this.grpResource.SuspendLayout();
            this.pnlTranTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolID)).BeginInit();
            this.grpEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolEventID)).BeginInit();
            this.tabToolEvent.SuspendLayout();
            this.tpToolInfo.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.tpCleanInfo.SuspendLayout();
            this.pnlCleanMain.SuspendLayout();
            this.pnlCleaningBack.SuspendLayout();
            this.pnlCleanInfo.SuspendLayout();
            this.pnlCleanSheet.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCleanData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCleanData_LotInfo)).BeginInit();
            this.grpCleanInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefectCodeClean)).BeginInit();
            this.tpDefectInfo.SuspendLayout();
            this.pnlDefectMain.SuspendLayout();
            this.pnlDefectBack.SuspendLayout();
            this.pnlDefectInfo.SuspendLayout();
            this.pnlDefectSheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData_LotInfo)).BeginInit();
            this.grpDefectInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefectCode)).BeginInit();
            this.grpDefectDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).BeginInit();
            this.grpDefectComment.SuspendLayout();
            this.grpPnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.grpPnlControl);
            this.pnlBottom.Controls.Add(this.txtCellXSize);
            this.pnlBottom.Controls.Add(this.txtCellYSize);
            this.pnlBottom.Controls.Add(this.txtCellYCount);
            this.pnlBottom.Controls.Add(this.txtCellXCount);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.txtCellXCount, 0);
            this.pnlBottom.Controls.SetChildIndex(this.txtCellYCount, 0);
            this.pnlBottom.Controls.SetChildIndex(this.txtCellYSize, 0);
            this.pnlBottom.Controls.SetChildIndex(this.txtCellXSize, 0);
            this.pnlBottom.Controls.SetChildIndex(this.grpPnlControl, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabToolEvent);
            this.pnlCenter.Controls.Add(this.pnlRes);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Tool Event";
            // 
            // pnlRes
            // 
            this.pnlRes.Controls.Add(this.grpResource);
            this.pnlRes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRes.Location = new System.Drawing.Point(0, 0);
            this.pnlRes.Name = "pnlRes";
            this.pnlRes.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRes.Size = new System.Drawing.Size(742, 64);
            this.pnlRes.TabIndex = 0;
            // 
            // grpResource
            // 
            this.grpResource.Controls.Add(this.pnlTranTime);
            this.grpResource.Controls.Add(this.cdvType);
            this.grpResource.Controls.Add(this.lblToolType);
            this.grpResource.Controls.Add(this.cdvToolID);
            this.grpResource.Controls.Add(this.lblEventID);
            this.grpResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResource.Location = new System.Drawing.Point(3, 0);
            this.grpResource.Name = "grpResource";
            this.grpResource.Size = new System.Drawing.Size(736, 64);
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
            this.pnlTranTime.Location = new System.Drawing.Point(427, 11);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 23);
            this.pnlTranTime.TabIndex = 13;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.Location = new System.Drawing.Point(139, 1);
            this.txtTranDateTime.MaxLength = 30;
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
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTranDateTime.Location = new System.Drawing.Point(1, 3);
            this.chkTranDateTime.Name = "chkTranDateTime";
            this.chkTranDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
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
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = -1;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(120, 14);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = true;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(200, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 1;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 200;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvType_SelectedItemChanged);
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // lblToolType
            // 
            this.lblToolType.AutoSize = true;
            this.lblToolType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolType.Location = new System.Drawing.Point(15, 17);
            this.lblToolType.Name = "lblToolType";
            this.lblToolType.Size = new System.Drawing.Size(64, 13);
            this.lblToolType.TabIndex = 0;
            this.lblToolType.Text = "Tool Type";
            // 
            // cdvToolID
            // 
            this.cdvToolID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvToolID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolID.BtnToolTipText = "";
            this.cdvToolID.DescText = "";
            this.cdvToolID.DisplaySubItemIndex = 1;
            this.cdvToolID.DisplayText = "";
            this.cdvToolID.Focusing = null;
            this.cdvToolID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolID.Index = 0;
            this.cdvToolID.IsViewBtnImage = false;
            this.cdvToolID.Location = new System.Drawing.Point(120, 38);
            this.cdvToolID.MaxLength = 30;
            this.cdvToolID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolID.Name = "cdvToolID";
            this.cdvToolID.ReadOnly = true;
            this.cdvToolID.SearchSubItemIndex = 0;
            this.cdvToolID.SelectedDescIndex = 0;
            this.cdvToolID.SelectedSubItemIndex = 0;
            this.cdvToolID.SelectionStart = 0;
            this.cdvToolID.Size = new System.Drawing.Size(604, 20);
            this.cdvToolID.SmallImageList = null;
            this.cdvToolID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolID.TabIndex = 1;
            this.cdvToolID.TextBoxToolTipText = "";
            this.cdvToolID.TextBoxWidth = 200;
            this.cdvToolID.VisibleButton = true;
            this.cdvToolID.VisibleColumnHeader = false;
            this.cdvToolID.VisibleDescription = true;
            this.cdvToolID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToolID_SelectedItemChanged);
            this.cdvToolID.ButtonPress += new System.EventHandler(this.cdvToolID_ButtonPress);
            // 
            // lblEventID
            // 
            this.lblEventID.AutoSize = true;
            this.lblEventID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEventID.Location = new System.Drawing.Point(15, 41);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(32, 13);
            this.lblEventID.TabIndex = 0;
            this.lblEventID.Text = "Tool";
            // 
            // grpEvent
            // 
            this.grpEvent.Controls.Add(this.cdvToolEventID);
            this.grpEvent.Controls.Add(this.Label1);
            this.grpEvent.Controls.Add(this.txtLastEventTime);
            this.grpEvent.Controls.Add(this.lblLastEventTime);
            this.grpEvent.Controls.Add(this.txtLastEvent);
            this.grpEvent.Controls.Add(this.lblLastEvent);
            this.grpEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpEvent.Location = new System.Drawing.Point(0, 0);
            this.grpEvent.Name = "grpEvent";
            this.grpEvent.Size = new System.Drawing.Size(734, 69);
            this.grpEvent.TabIndex = 1;
            this.grpEvent.TabStop = false;
            // 
            // cdvToolEventID
            // 
            this.cdvToolEventID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvToolEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolEventID.BtnToolTipText = "";
            this.cdvToolEventID.DescText = "";
            this.cdvToolEventID.DisplaySubItemIndex = 1;
            this.cdvToolEventID.DisplayText = "";
            this.cdvToolEventID.Focusing = null;
            this.cdvToolEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolEventID.Index = 0;
            this.cdvToolEventID.IsViewBtnImage = false;
            this.cdvToolEventID.Location = new System.Drawing.Point(120, 40);
            this.cdvToolEventID.MaxLength = 12;
            this.cdvToolEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolEventID.Name = "cdvToolEventID";
            this.cdvToolEventID.ReadOnly = true;
            this.cdvToolEventID.SearchSubItemIndex = 0;
            this.cdvToolEventID.SelectedDescIndex = 0;
            this.cdvToolEventID.SelectedSubItemIndex = 0;
            this.cdvToolEventID.SelectionStart = 0;
            this.cdvToolEventID.Size = new System.Drawing.Size(604, 20);
            this.cdvToolEventID.SmallImageList = null;
            this.cdvToolEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolEventID.TabIndex = 4;
            this.cdvToolEventID.TextBoxToolTipText = "";
            this.cdvToolEventID.TextBoxWidth = 200;
            this.cdvToolEventID.VisibleButton = true;
            this.cdvToolEventID.VisibleColumnHeader = false;
            this.cdvToolEventID.VisibleDescription = true;
            this.cdvToolEventID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToolEventID_SelectedItemChanged);
            this.cdvToolEventID.ButtonPress += new System.EventHandler(this.cdvToolEventID_ButtonPress);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(16, 44);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(69, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Tool Event";
            // 
            // txtLastEventTime
            // 
            this.txtLastEventTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastEventTime.Location = new System.Drawing.Point(567, 16);
            this.txtLastEventTime.MaxLength = 30;
            this.txtLastEventTime.Name = "txtLastEventTime";
            this.txtLastEventTime.ReadOnly = true;
            this.txtLastEventTime.Size = new System.Drawing.Size(157, 20);
            this.txtLastEventTime.TabIndex = 9;
            this.txtLastEventTime.TabStop = false;
            // 
            // lblLastEventTime
            // 
            this.lblLastEventTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastEventTime.AutoSize = true;
            this.lblLastEventTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEventTime.Location = new System.Drawing.Point(428, 19);
            this.lblLastEventTime.Name = "lblLastEventTime";
            this.lblLastEventTime.Size = new System.Drawing.Size(84, 13);
            this.lblLastEventTime.TabIndex = 8;
            this.lblLastEventTime.Text = "Last Event Time";
            // 
            // txtLastEvent
            // 
            this.txtLastEvent.Location = new System.Drawing.Point(120, 16);
            this.txtLastEvent.MaxLength = 12;
            this.txtLastEvent.Name = "txtLastEvent";
            this.txtLastEvent.ReadOnly = true;
            this.txtLastEvent.Size = new System.Drawing.Size(200, 20);
            this.txtLastEvent.TabIndex = 7;
            this.txtLastEvent.TabStop = false;
            // 
            // lblLastEvent
            // 
            this.lblLastEvent.AutoSize = true;
            this.lblLastEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEvent.Location = new System.Drawing.Point(16, 18);
            this.lblLastEvent.Name = "lblLastEvent";
            this.lblLastEvent.Size = new System.Drawing.Size(58, 13);
            this.lblLastEvent.TabIndex = 6;
            this.lblLastEvent.Text = "Last Event";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(12, 16);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // tabToolEvent
            // 
            this.tabToolEvent.Controls.Add(this.tpToolInfo);
            this.tabToolEvent.Controls.Add(this.tpCleanInfo);
            this.tabToolEvent.Controls.Add(this.tpDefectInfo);
            this.tabToolEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabToolEvent.Location = new System.Drawing.Point(0, 64);
            this.tabToolEvent.Name = "tabToolEvent";
            this.tabToolEvent.SelectedIndex = 0;
            this.tabToolEvent.Size = new System.Drawing.Size(742, 449);
            this.tabToolEvent.TabIndex = 2;
            this.tabToolEvent.SelectedIndexChanged += new System.EventHandler(this.tabToolEvent_SelectedIndexChanged);
            this.tabToolEvent.Click += new System.EventHandler(this.tabToolEvent_Click);
            // 
            // tpToolInfo
            // 
            this.tpToolInfo.Controls.Add(this.pnlMain);
            this.tpToolInfo.Controls.Add(this.grpEvent);
            this.tpToolInfo.Location = new System.Drawing.Point(4, 22);
            this.tpToolInfo.Name = "tpToolInfo";
            this.tpToolInfo.Size = new System.Drawing.Size(734, 423);
            this.tpToolInfo.TabIndex = 0;
            this.tpToolInfo.Text = "Tool Info";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grpMain);
            this.pnlMain.Controls.Add(this.grpComment);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 69);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(734, 354);
            this.pnlMain.TabIndex = 2;
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.cdvToolEvent);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(734, 314);
            this.grpMain.TabIndex = 17;
            this.grpMain.TabStop = false;
            // 
            // cdvToolEvent
            // 
            this.cdvToolEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdvToolEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvToolEvent.ListCond_ExtFactory = "";
            this.cdvToolEvent.ListCond_Step = '\0';
            this.cdvToolEvent.Location = new System.Drawing.Point(3, 16);
            this.cdvToolEvent.Name = "cdvToolEvent";
            this.cdvToolEvent.Size = new System.Drawing.Size(728, 295);
            this.cdvToolEvent.TabIndex = 0;
            this.cdvToolEvent.VisibleNextStatusColumn = true;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpComment.Location = new System.Drawing.Point(0, 314);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(734, 40);
            this.grpComment.TabIndex = 16;
            this.grpComment.TabStop = false;
            // 
            // tpCleanInfo
            // 
            this.tpCleanInfo.Controls.Add(this.pnlCleanMain);
            this.tpCleanInfo.Controls.Add(this.pnlCleanInfo);
            this.tpCleanInfo.Location = new System.Drawing.Point(4, 22);
            this.tpCleanInfo.Name = "tpCleanInfo";
            this.tpCleanInfo.Size = new System.Drawing.Size(734, 423);
            this.tpCleanInfo.TabIndex = 2;
            this.tpCleanInfo.Text = "Tool Defect Cleaning";
            // 
            // pnlCleanMain
            // 
            this.pnlCleanMain.Controls.Add(this.Label4);
            this.pnlCleanMain.Controls.Add(this.Label3);
            this.pnlCleanMain.Controls.Add(this.lblLoc2Clean);
            this.pnlCleanMain.Controls.Add(this.lblCell2Clean);
            this.pnlCleanMain.Controls.Add(this.lbldecodeClean);
            this.pnlCleanMain.Controls.Add(this.Label2);
            this.pnlCleanMain.Controls.Add(this.HcScroll);
            this.pnlCleanMain.Controls.Add(this.VcScroll);
            this.pnlCleanMain.Controls.Add(this.pnlCleaningBack);
            this.pnlCleanMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCleanMain.Location = new System.Drawing.Point(0, 0);
            this.pnlCleanMain.Name = "pnlCleanMain";
            this.pnlCleanMain.Size = new System.Drawing.Size(374, 423);
            this.pnlCleanMain.TabIndex = 1;
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label4.Location = new System.Drawing.Point(299, 383);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(56, 16);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "Loc X,Y";
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label3.Location = new System.Drawing.Point(231, 383);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(56, 16);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Cell X,Y";
            // 
            // lblLoc2Clean
            // 
            this.lblLoc2Clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLoc2Clean.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLoc2Clean.Location = new System.Drawing.Point(298, 403);
            this.lblLoc2Clean.Name = "lblLoc2Clean";
            this.lblLoc2Clean.Size = new System.Drawing.Size(70, 16);
            this.lblLoc2Clean.TabIndex = 5;
            // 
            // lblCell2Clean
            // 
            this.lblCell2Clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCell2Clean.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCell2Clean.Location = new System.Drawing.Point(231, 403);
            this.lblCell2Clean.Name = "lblCell2Clean";
            this.lblCell2Clean.Size = new System.Drawing.Size(60, 16);
            this.lblCell2Clean.TabIndex = 3;
            // 
            // lbldecodeClean
            // 
            this.lbldecodeClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbldecodeClean.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldecodeClean.Location = new System.Drawing.Point(163, 403);
            this.lbldecodeClean.Name = "lbldecodeClean";
            this.lbldecodeClean.Size = new System.Drawing.Size(60, 16);
            this.lbldecodeClean.TabIndex = 1;
            this.lbldecodeClean.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label2.Location = new System.Drawing.Point(162, 383);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(67, 16);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Defect Code";
            // 
            // HcScroll
            // 
            this.HcScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HcScroll.Location = new System.Drawing.Point(1, 352);
            this.HcScroll.Name = "HcScroll";
            this.HcScroll.Size = new System.Drawing.Size(351, 16);
            this.HcScroll.TabIndex = 22;
            this.HcScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HcScroll_Scroll);
            // 
            // VcScroll
            // 
            this.VcScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.VcScroll.Location = new System.Drawing.Point(352, 1);
            this.VcScroll.Name = "VcScroll";
            this.VcScroll.Size = new System.Drawing.Size(16, 347);
            this.VcScroll.TabIndex = 21;
            this.VcScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VcScroll_Scroll);
            // 
            // pnlCleaningBack
            // 
            this.pnlCleaningBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCleaningBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCleaningBack.Controls.Add(this.pnlCleaning);
            this.pnlCleaningBack.Location = new System.Drawing.Point(0, 0);
            this.pnlCleaningBack.Name = "pnlCleaningBack";
            this.pnlCleaningBack.Size = new System.Drawing.Size(350, 350);
            this.pnlCleaningBack.TabIndex = 19;
            // 
            // pnlCleaning
            // 
            this.pnlCleaning.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlCleaning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCleaning.Location = new System.Drawing.Point(0, 0);
            this.pnlCleaning.Name = "pnlCleaning";
            this.pnlCleaning.Size = new System.Drawing.Size(350, 350);
            this.pnlCleaning.TabIndex = 2;
            this.pnlCleaning.Click += new System.EventHandler(this.pnlCleaning_Click);
            this.pnlCleaning.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCleaning_MouseDown);
            this.pnlCleaning.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlCleaning_MouseMove);
            this.pnlCleaning.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlCleaning_MouseUp);
            this.pnlCleaning.Resize += new System.EventHandler(this.pnlCleaning_Resize);
            // 
            // pnlCleanInfo
            // 
            this.pnlCleanInfo.Controls.Add(this.pnlCleanSheet);
            this.pnlCleanInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCleanInfo.Location = new System.Drawing.Point(374, 0);
            this.pnlCleanInfo.Name = "pnlCleanInfo";
            this.pnlCleanInfo.Size = new System.Drawing.Size(360, 423);
            this.pnlCleanInfo.TabIndex = 0;
            // 
            // pnlCleanSheet
            // 
            this.pnlCleanSheet.Controls.Add(this.Panel1);
            this.pnlCleanSheet.Controls.Add(this.grpCleanInfo);
            this.pnlCleanSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCleanSheet.Location = new System.Drawing.Point(0, 0);
            this.pnlCleanSheet.Name = "pnlCleanSheet";
            this.pnlCleanSheet.Size = new System.Drawing.Size(360, 423);
            this.pnlCleanSheet.TabIndex = 24;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.spdCleanData);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 104);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(360, 319);
            this.Panel1.TabIndex = 24;
            // 
            // spdCleanData
            // 
            this.spdCleanData.AccessibleDescription = "";
            this.spdCleanData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCleanData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCleanData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCleanData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCleanData.HorizontalScrollBar.Name = "";
            this.spdCleanData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdCleanData.HorizontalScrollBar.TabIndex = 2;
            this.spdCleanData.Location = new System.Drawing.Point(0, 0);
            this.spdCleanData.MoveActiveOnFocus = false;
            this.spdCleanData.Name = "spdCleanData";
            this.spdCleanData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdCleanData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdCleanData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCleanData_LotInfo});
            this.spdCleanData.Size = new System.Drawing.Size(360, 319);
            this.spdCleanData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCleanData.TabIndex = 17;
            this.spdCleanData.TabStop = false;
            this.spdCleanData.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdCleanData.TextTipDelay = 200;
            this.spdCleanData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCleanData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCleanData.VerticalScrollBar.Name = "";
            this.spdCleanData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdCleanData.VerticalScrollBar.TabIndex = 3;
            this.spdCleanData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdCleanData_CellClick);
            this.spdCleanData.SetActiveViewport(0, -1, -1);
            // 
            // spdCleanData_LotInfo
            // 
            this.spdCleanData_LotInfo.Reset();
            spdCleanData_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCleanData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCleanData_LotInfo.ColumnCount = 9;
            spdCleanData_LotInfo.RowCount = 0;
            this.spdCleanData_LotInfo.ActiveColumnIndex = -1;
            this.spdCleanData_LotInfo.ActiveRowIndex = -1;
            this.spdCleanData_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCleanData_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCleanData_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCleanData_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            checkBoxCellType1.Caption = "Sel";
            this.spdCleanData_LotInfo.ColumnHeader.Cells.Get(0, 0).CellType = checkBoxCellType1;
            this.spdCleanData_LotInfo.ColumnHeader.Cells.Get(0, 1).Value = "Defect Code";
            this.spdCleanData_LotInfo.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 3;
            this.spdCleanData_LotInfo.ColumnHeader.Cells.Get(0, 2).Value = "Cell [X,Y,Z]";
            this.spdCleanData_LotInfo.ColumnHeader.Cells.Get(0, 5).ColumnSpan = 3;
            this.spdCleanData_LotInfo.ColumnHeader.Cells.Get(0, 5).Value = "Loc [X,Y,Z]";
            this.spdCleanData_LotInfo.ColumnHeader.Cells.Get(0, 6).Value = "Cell Info";
            this.spdCleanData_LotInfo.ColumnHeader.Cells.Get(0, 7).Value = "Loc Info";
            this.spdCleanData_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCleanData_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCleanData_LotInfo.Columns.Get(0).CellType = checkBoxCellType2;
            this.spdCleanData_LotInfo.Columns.Get(0).Width = 48F;
            this.spdCleanData_LotInfo.Columns.Get(1).BackColor = System.Drawing.Color.White;
            this.spdCleanData_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCleanData_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCleanData_LotInfo.Columns.Get(1).Label = "Defect Code";
            this.spdCleanData_LotInfo.Columns.Get(1).Locked = true;
            this.spdCleanData_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCleanData_LotInfo.Columns.Get(1).Width = 70F;
            this.spdCleanData_LotInfo.Columns.Get(2).Label = "Cell [X,Y,Z]";
            this.spdCleanData_LotInfo.Columns.Get(2).Locked = true;
            this.spdCleanData_LotInfo.Columns.Get(2).Width = 35F;
            this.spdCleanData_LotInfo.Columns.Get(3).Locked = true;
            this.spdCleanData_LotInfo.Columns.Get(3).Width = 35F;
            this.spdCleanData_LotInfo.Columns.Get(4).Locked = true;
            this.spdCleanData_LotInfo.Columns.Get(4).Width = 35F;
            this.spdCleanData_LotInfo.Columns.Get(5).Label = "Loc [X,Y,Z]";
            this.spdCleanData_LotInfo.Columns.Get(5).Locked = true;
            this.spdCleanData_LotInfo.Columns.Get(5).Width = 35F;
            this.spdCleanData_LotInfo.Columns.Get(6).Label = "Cell Info";
            this.spdCleanData_LotInfo.Columns.Get(6).Locked = true;
            this.spdCleanData_LotInfo.Columns.Get(6).Width = 35F;
            this.spdCleanData_LotInfo.Columns.Get(7).Label = "Loc Info";
            this.spdCleanData_LotInfo.Columns.Get(7).Locked = true;
            this.spdCleanData_LotInfo.Columns.Get(7).Width = 35F;
            this.spdCleanData_LotInfo.Columns.Get(8).CellType = textCellType1;
            this.spdCleanData_LotInfo.Columns.Get(8).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCleanData_LotInfo.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCleanData_LotInfo.Columns.Get(8).Locked = true;
            this.spdCleanData_LotInfo.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCleanData_LotInfo.Columns.Get(8).Width = 0F;
            this.spdCleanData_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCleanData_LotInfo.RowHeader.Columns.Default.Resizable = true;
            this.spdCleanData_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCleanData_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCleanData_LotInfo.RowHeader.Visible = false;
            this.spdCleanData_LotInfo.Rows.Default.Height = 17F;
            this.spdCleanData_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCleanData_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCleanData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpCleanInfo
            // 
            this.grpCleanInfo.Controls.Add(this.cdvDefectCodeClean);
            this.grpCleanInfo.Controls.Add(this.btnCleanView);
            this.grpCleanInfo.Controls.Add(this.rdoData);
            this.grpCleanInfo.Controls.Add(this.rdoAll);
            this.grpCleanInfo.Controls.Add(this.rdoDefectCode);
            this.grpCleanInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCleanInfo.Location = new System.Drawing.Point(0, 0);
            this.grpCleanInfo.Name = "grpCleanInfo";
            this.grpCleanInfo.Size = new System.Drawing.Size(360, 104);
            this.grpCleanInfo.TabIndex = 23;
            this.grpCleanInfo.TabStop = false;
            this.grpCleanInfo.Text = "Clean Cell / Loc Info";
            // 
            // cdvDefectCodeClean
            // 
            this.cdvDefectCodeClean.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDefectCodeClean.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDefectCodeClean.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDefectCodeClean.BtnToolTipText = "";
            this.cdvDefectCodeClean.DescText = "";
            this.cdvDefectCodeClean.DisplaySubItemIndex = -1;
            this.cdvDefectCodeClean.DisplayText = "";
            this.cdvDefectCodeClean.Focusing = null;
            this.cdvDefectCodeClean.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDefectCodeClean.Index = 0;
            this.cdvDefectCodeClean.IsViewBtnImage = false;
            this.cdvDefectCodeClean.Location = new System.Drawing.Point(156, 48);
            this.cdvDefectCodeClean.MaxLength = 10;
            this.cdvDefectCodeClean.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDefectCodeClean.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDefectCodeClean.Name = "cdvDefectCodeClean";
            this.cdvDefectCodeClean.ReadOnly = false;
            this.cdvDefectCodeClean.SearchSubItemIndex = 0;
            this.cdvDefectCodeClean.SelectedDescIndex = -1;
            this.cdvDefectCodeClean.SelectedSubItemIndex = -1;
            this.cdvDefectCodeClean.SelectionStart = 0;
            this.cdvDefectCodeClean.Size = new System.Drawing.Size(124, 20);
            this.cdvDefectCodeClean.SmallImageList = null;
            this.cdvDefectCodeClean.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDefectCodeClean.TabIndex = 2;
            this.cdvDefectCodeClean.TextBoxToolTipText = "";
            this.cdvDefectCodeClean.TextBoxWidth = 124;
            this.cdvDefectCodeClean.VisibleButton = true;
            this.cdvDefectCodeClean.VisibleColumnHeader = false;
            this.cdvDefectCodeClean.VisibleDescription = false;
            this.cdvDefectCodeClean.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvDefectCodeClean_SelectedItemChanged);
            this.cdvDefectCodeClean.ButtonPress += new System.EventHandler(this.cdvDefectCodeClean_ButtonPress);
            // 
            // btnCleanView
            // 
            this.btnCleanView.Location = new System.Drawing.Point(256, 76);
            this.btnCleanView.Name = "btnCleanView";
            this.btnCleanView.Size = new System.Drawing.Size(85, 22);
            this.btnCleanView.TabIndex = 4;
            this.btnCleanView.Text = "View";
            this.btnCleanView.Click += new System.EventHandler(this.btnCleanView_Click);
            // 
            // rdoData
            // 
            this.rdoData.Checked = true;
            this.rdoData.Location = new System.Drawing.Point(17, 74);
            this.rdoData.Name = "rdoData";
            this.rdoData.Size = new System.Drawing.Size(140, 20);
            this.rdoData.TabIndex = 3;
            this.rdoData.TabStop = true;
            this.rdoData.Text = "Clean Selected Data";
            this.rdoData.Click += new System.EventHandler(this.rdoData_Click);
            // 
            // rdoAll
            // 
            this.rdoAll.Location = new System.Drawing.Point(16, 24);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(124, 20);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.Text = "Clean All Defect";
            this.rdoAll.Click += new System.EventHandler(this.rdoAll_Click);
            // 
            // rdoDefectCode
            // 
            this.rdoDefectCode.Location = new System.Drawing.Point(16, 48);
            this.rdoDefectCode.Name = "rdoDefectCode";
            this.rdoDefectCode.Size = new System.Drawing.Size(152, 20);
            this.rdoDefectCode.TabIndex = 1;
            this.rdoDefectCode.Text = "Clean defect Code Data";
            this.rdoDefectCode.Click += new System.EventHandler(this.rdoDefectCode_Click);
            // 
            // tpDefectInfo
            // 
            this.tpDefectInfo.Controls.Add(this.pnlDefectMain);
            this.tpDefectInfo.Controls.Add(this.pnlDefectInfo);
            this.tpDefectInfo.Location = new System.Drawing.Point(4, 22);
            this.tpDefectInfo.Name = "tpDefectInfo";
            this.tpDefectInfo.Size = new System.Drawing.Size(734, 423);
            this.tpDefectInfo.TabIndex = 4;
            this.tpDefectInfo.Text = "Tool Defect Collection";
            // 
            // pnlDefectMain
            // 
            this.pnlDefectMain.Controls.Add(this.Label12);
            this.pnlDefectMain.Controls.Add(this.Label11);
            this.pnlDefectMain.Controls.Add(this.Label10);
            this.pnlDefectMain.Controls.Add(this.pnlDefectBack);
            this.pnlDefectMain.Controls.Add(this.HeScroll);
            this.pnlDefectMain.Controls.Add(this.VeScroll);
            this.pnlDefectMain.Controls.Add(this.lblLoc2);
            this.pnlDefectMain.Controls.Add(this.lblCell2);
            this.pnlDefectMain.Controls.Add(this.lbldecode);
            this.pnlDefectMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDefectMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDefectMain.Location = new System.Drawing.Point(0, 0);
            this.pnlDefectMain.Name = "pnlDefectMain";
            this.pnlDefectMain.Size = new System.Drawing.Size(374, 423);
            this.pnlDefectMain.TabIndex = 0;
            // 
            // Label12
            // 
            this.Label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label12.Location = new System.Drawing.Point(298, 383);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(56, 16);
            this.Label12.TabIndex = 4;
            this.Label12.Text = "Loc X,Y";
            // 
            // Label11
            // 
            this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label11.Location = new System.Drawing.Point(229, 383);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(56, 16);
            this.Label11.TabIndex = 2;
            this.Label11.Text = "Cell X,Y";
            // 
            // Label10
            // 
            this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label10.Location = new System.Drawing.Point(162, 383);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(67, 16);
            this.Label10.TabIndex = 0;
            this.Label10.Text = "Defect Code";
            // 
            // pnlDefectBack
            // 
            this.pnlDefectBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDefectBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDefectBack.Controls.Add(this.pnlDefect);
            this.pnlDefectBack.Location = new System.Drawing.Point(0, 0);
            this.pnlDefectBack.Name = "pnlDefectBack";
            this.pnlDefectBack.Size = new System.Drawing.Size(350, 350);
            this.pnlDefectBack.TabIndex = 0;
            // 
            // pnlDefect
            // 
            this.pnlDefect.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlDefect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDefect.Location = new System.Drawing.Point(0, 0);
            this.pnlDefect.Name = "pnlDefect";
            this.pnlDefect.Size = new System.Drawing.Size(350, 350);
            this.pnlDefect.TabIndex = 0;
            this.pnlDefect.Click += new System.EventHandler(this.pnlDefect_Click);
            this.pnlDefect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDefect_MouseDown);
            this.pnlDefect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDefect_MouseMove);
            this.pnlDefect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDefect_MouseUp);
            this.pnlDefect.Resize += new System.EventHandler(this.pnlDefect_Resize);
            // 
            // HeScroll
            // 
            this.HeScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HeScroll.Location = new System.Drawing.Point(1, 352);
            this.HeScroll.Name = "HeScroll";
            this.HeScroll.Size = new System.Drawing.Size(348, 16);
            this.HeScroll.TabIndex = 1;
            this.HeScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HeScroll_Scroll);
            // 
            // VeScroll
            // 
            this.VeScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.VeScroll.Location = new System.Drawing.Point(352, 1);
            this.VeScroll.Name = "VeScroll";
            this.VeScroll.Size = new System.Drawing.Size(16, 351);
            this.VeScroll.TabIndex = 0;
            this.VeScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VeScroll_Scroll);
            // 
            // lblLoc2
            // 
            this.lblLoc2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLoc2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLoc2.Location = new System.Drawing.Point(297, 403);
            this.lblLoc2.Name = "lblLoc2";
            this.lblLoc2.Size = new System.Drawing.Size(70, 16);
            this.lblLoc2.TabIndex = 5;
            // 
            // lblCell2
            // 
            this.lblCell2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCell2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCell2.Location = new System.Drawing.Point(231, 403);
            this.lblCell2.Name = "lblCell2";
            this.lblCell2.Size = new System.Drawing.Size(60, 16);
            this.lblCell2.TabIndex = 3;
            // 
            // lbldecode
            // 
            this.lbldecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbldecode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbldecode.Location = new System.Drawing.Point(166, 403);
            this.lbldecode.Name = "lbldecode";
            this.lbldecode.Size = new System.Drawing.Size(60, 16);
            this.lbldecode.TabIndex = 1;
            this.lbldecode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDefectInfo
            // 
            this.pnlDefectInfo.Controls.Add(this.pnlDefectSheet);
            this.pnlDefectInfo.Controls.Add(this.grpDefectInfo);
            this.pnlDefectInfo.Controls.Add(this.grpDefectDetail);
            this.pnlDefectInfo.Controls.Add(this.grpDefectComment);
            this.pnlDefectInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDefectInfo.Location = new System.Drawing.Point(374, 0);
            this.pnlDefectInfo.Name = "pnlDefectInfo";
            this.pnlDefectInfo.Size = new System.Drawing.Size(360, 423);
            this.pnlDefectInfo.TabIndex = 6;
            // 
            // pnlDefectSheet
            // 
            this.pnlDefectSheet.Controls.Add(this.spdDefectData);
            this.pnlDefectSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDefectSheet.Location = new System.Drawing.Point(0, 204);
            this.pnlDefectSheet.Name = "pnlDefectSheet";
            this.pnlDefectSheet.Size = new System.Drawing.Size(360, 183);
            this.pnlDefectSheet.TabIndex = 9;
            // 
            // spdDefectData
            // 
            this.spdDefectData.AccessibleDescription = "";
            this.spdDefectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDefectData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdDefectData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDefectData.HorizontalScrollBar.Name = "";
            this.spdDefectData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdDefectData.HorizontalScrollBar.TabIndex = 2;
            this.spdDefectData.Location = new System.Drawing.Point(0, 0);
            this.spdDefectData.MoveActiveOnFocus = false;
            this.spdDefectData.Name = "spdDefectData";
            this.spdDefectData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdDefectData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdDefectData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDefectData_LotInfo});
            this.spdDefectData.Size = new System.Drawing.Size(360, 183);
            this.spdDefectData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdDefectData.TabIndex = 1;
            this.spdDefectData.TabStop = false;
            this.spdDefectData.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdDefectData.TextTipDelay = 200;
            this.spdDefectData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDefectData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDefectData.VerticalScrollBar.Name = "";
            this.spdDefectData.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdDefectData.VerticalScrollBar.TabIndex = 3;
            this.spdDefectData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdDefectData_CellClick);
            this.spdDefectData.SetActiveViewport(0, -1, -1);
            // 
            // spdDefectData_LotInfo
            // 
            this.spdDefectData_LotInfo.Reset();
            spdDefectData_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDefectData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDefectData_LotInfo.ColumnCount = 10;
            spdDefectData_LotInfo.RowCount = 0;
            this.spdDefectData_LotInfo.ActiveColumnIndex = -1;
            this.spdDefectData_LotInfo.ActiveRowIndex = -1;
            this.spdDefectData_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDefectData_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            checkBoxCellType3.Caption = "Sel";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 0).CellType = checkBoxCellType3;
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 1).Value = "Defect Code";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 2).ColumnSpan = 3;
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 2).Value = "Cell [X,Y,Z]";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 5).ColumnSpan = 3;
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 5).Value = "Loc [X,Y,Z]";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 6).Value = "Loc X, Y, Z";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 7).Value = "Cell Info";
            this.spdDefectData_LotInfo.ColumnHeader.Cells.Get(0, 8).Value = "ControlName";
            this.spdDefectData_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDefectData_LotInfo.Columns.Get(0).CellType = checkBoxCellType4;
            this.spdDefectData_LotInfo.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDefectData_LotInfo.Columns.Get(0).Width = 50F;
            this.spdDefectData_LotInfo.Columns.Get(1).BackColor = System.Drawing.Color.White;
            this.spdDefectData_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefectData_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDefectData_LotInfo.Columns.Get(1).Label = "Defect Code";
            this.spdDefectData_LotInfo.Columns.Get(1).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefectData_LotInfo.Columns.Get(1).Width = 82F;
            this.spdDefectData_LotInfo.Columns.Get(2).Label = "Cell [X,Y,Z]";
            this.spdDefectData_LotInfo.Columns.Get(2).Width = 35F;
            this.spdDefectData_LotInfo.Columns.Get(3).Width = 35F;
            this.spdDefectData_LotInfo.Columns.Get(4).Width = 35F;
            this.spdDefectData_LotInfo.Columns.Get(5).Label = "Loc [X,Y,Z]";
            this.spdDefectData_LotInfo.Columns.Get(5).Width = 35F;
            this.spdDefectData_LotInfo.Columns.Get(6).Label = "Loc X, Y, Z";
            this.spdDefectData_LotInfo.Columns.Get(6).Width = 35F;
            this.spdDefectData_LotInfo.Columns.Get(7).Label = "Cell Info";
            this.spdDefectData_LotInfo.Columns.Get(7).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(7).Width = 35F;
            this.spdDefectData_LotInfo.Columns.Get(8).Label = "ControlName";
            this.spdDefectData_LotInfo.Columns.Get(8).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(8).Width = 0F;
            this.spdDefectData_LotInfo.Columns.Get(9).CellType = textCellType2;
            this.spdDefectData_LotInfo.Columns.Get(9).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefectData_LotInfo.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDefectData_LotInfo.Columns.Get(9).Locked = true;
            this.spdDefectData_LotInfo.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefectData_LotInfo.Columns.Get(9).Width = 0F;
            this.spdDefectData_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdDefectData_LotInfo.RowHeader.Columns.Default.Resizable = true;
            this.spdDefectData_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdDefectData_LotInfo.RowHeader.Visible = false;
            this.spdDefectData_LotInfo.Rows.Default.Height = 17F;
            this.spdDefectData_LotInfo.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdDefectData_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDefectData_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdDefectData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpDefectInfo
            // 
            this.grpDefectInfo.Controls.Add(this.lblCellMinus);
            this.grpDefectInfo.Controls.Add(this.lblCellZ);
            this.grpDefectInfo.Controls.Add(this.lblCellY);
            this.grpDefectInfo.Controls.Add(this.lblCellX);
            this.grpDefectInfo.Controls.Add(this.lblCellInfo);
            this.grpDefectInfo.Controls.Add(this.btnDefectMinus);
            this.grpDefectInfo.Controls.Add(this.txtLocZ);
            this.grpDefectInfo.Controls.Add(this.txtLocY);
            this.grpDefectInfo.Controls.Add(this.txtLocX);
            this.grpDefectInfo.Controls.Add(this.lblLocZ);
            this.grpDefectInfo.Controls.Add(this.lblLocY);
            this.grpDefectInfo.Controls.Add(this.lblLocX);
            this.grpDefectInfo.Controls.Add(this.txtCellZ);
            this.grpDefectInfo.Controls.Add(this.txtCellY);
            this.grpDefectInfo.Controls.Add(this.txtCellX);
            this.grpDefectInfo.Controls.Add(this.cdvDefectCode);
            this.grpDefectInfo.Controls.Add(this.lblDefectCode);
            this.grpDefectInfo.Controls.Add(this.btnDefectView);
            this.grpDefectInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDefectInfo.Location = new System.Drawing.Point(0, 112);
            this.grpDefectInfo.Name = "grpDefectInfo";
            this.grpDefectInfo.Size = new System.Drawing.Size(360, 92);
            this.grpDefectInfo.TabIndex = 1;
            this.grpDefectInfo.TabStop = false;
            this.grpDefectInfo.Text = "Defect Cell / Loc Info";
            // 
            // lblCellMinus
            // 
            this.lblCellMinus.AutoSize = true;
            this.lblCellMinus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellMinus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellMinus.Location = new System.Drawing.Point(319, 48);
            this.lblCellMinus.Name = "lblCellMinus";
            this.lblCellMinus.Size = new System.Drawing.Size(40, 13);
            this.lblCellMinus.TabIndex = 23;
            this.lblCellMinus.Text = "Sheet";
            // 
            // lblCellZ
            // 
            this.lblCellZ.AutoSize = true;
            this.lblCellZ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellZ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellZ.Location = new System.Drawing.Point(103, 19);
            this.lblCellZ.Name = "lblCellZ";
            this.lblCellZ.Size = new System.Drawing.Size(40, 13);
            this.lblCellZ.TabIndex = 2;
            this.lblCellZ.Text = "Cell Z";
            // 
            // lblCellY
            // 
            this.lblCellY.AutoSize = true;
            this.lblCellY.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellY.Location = new System.Drawing.Point(58, 19);
            this.lblCellY.Name = "lblCellY";
            this.lblCellY.Size = new System.Drawing.Size(40, 13);
            this.lblCellY.TabIndex = 1;
            this.lblCellY.Text = "Cell Y";
            // 
            // lblCellX
            // 
            this.lblCellX.AutoSize = true;
            this.lblCellX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellX.Location = new System.Drawing.Point(14, 19);
            this.lblCellX.Name = "lblCellX";
            this.lblCellX.Size = new System.Drawing.Size(40, 13);
            this.lblCellX.TabIndex = 0;
            this.lblCellX.Text = "Cell X";
            // 
            // lblCellInfo
            // 
            this.lblCellInfo.AutoSize = true;
            this.lblCellInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellInfo.Location = new System.Drawing.Point(148, 34);
            this.lblCellInfo.Name = "lblCellInfo";
            this.lblCellInfo.Size = new System.Drawing.Size(13, 20);
            this.lblCellInfo.TabIndex = 18;
            this.lblCellInfo.Text = "/";
            // 
            // btnDefectMinus
            // 
            this.btnDefectMinus.Location = new System.Drawing.Point(320, 64);
            this.btnDefectMinus.Name = "btnDefectMinus";
            this.btnDefectMinus.Size = new System.Drawing.Size(32, 20);
            this.btnDefectMinus.TabIndex = 22;
            this.btnDefectMinus.Text = "-";
            this.btnDefectMinus.Click += new System.EventHandler(this.btnDefectMinus_Click);
            // 
            // txtLocZ
            // 
            this.txtLocZ.Location = new System.Drawing.Point(252, 35);
            this.txtLocZ.MaxLength = 13;
            this.txtLocZ.Name = "txtLocZ";
            this.txtLocZ.Size = new System.Drawing.Size(40, 20);
            this.txtLocZ.TabIndex = 17;
            this.txtLocZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXYZ_KeyPress);
            // 
            // txtLocY
            // 
            this.txtLocY.Location = new System.Drawing.Point(208, 35);
            this.txtLocY.MaxLength = 13;
            this.txtLocY.Name = "txtLocY";
            this.txtLocY.Size = new System.Drawing.Size(40, 20);
            this.txtLocY.TabIndex = 16;
            this.txtLocY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXYZ_KeyPress);
            // 
            // txtLocX
            // 
            this.txtLocX.Location = new System.Drawing.Point(164, 35);
            this.txtLocX.MaxLength = 13;
            this.txtLocX.Name = "txtLocX";
            this.txtLocX.Size = new System.Drawing.Size(40, 20);
            this.txtLocX.TabIndex = 15;
            this.txtLocX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXYZ_KeyPress);
            // 
            // lblLocZ
            // 
            this.lblLocZ.AutoSize = true;
            this.lblLocZ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocZ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocZ.Location = new System.Drawing.Point(256, 19);
            this.lblLocZ.Name = "lblLocZ";
            this.lblLocZ.Size = new System.Drawing.Size(40, 13);
            this.lblLocZ.TabIndex = 14;
            this.lblLocZ.Text = "Loc Z";
            // 
            // lblLocY
            // 
            this.lblLocY.AutoSize = true;
            this.lblLocY.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocY.Location = new System.Drawing.Point(211, 19);
            this.lblLocY.Name = "lblLocY";
            this.lblLocY.Size = new System.Drawing.Size(40, 13);
            this.lblLocY.TabIndex = 13;
            this.lblLocY.Text = "Loc Y";
            // 
            // lblLocX
            // 
            this.lblLocX.AutoSize = true;
            this.lblLocX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocX.Location = new System.Drawing.Point(167, 19);
            this.lblLocX.Name = "lblLocX";
            this.lblLocX.Size = new System.Drawing.Size(40, 13);
            this.lblLocX.TabIndex = 12;
            this.lblLocX.Text = "Loc X";
            // 
            // txtCellZ
            // 
            this.txtCellZ.Location = new System.Drawing.Point(100, 35);
            this.txtCellZ.MaxLength = 10;
            this.txtCellZ.Name = "txtCellZ";
            this.txtCellZ.Size = new System.Drawing.Size(40, 20);
            this.txtCellZ.TabIndex = 5;
            this.txtCellZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXYZ_KeyPress);
            // 
            // txtCellY
            // 
            this.txtCellY.Location = new System.Drawing.Point(56, 35);
            this.txtCellY.MaxLength = 10;
            this.txtCellY.Name = "txtCellY";
            this.txtCellY.Size = new System.Drawing.Size(40, 20);
            this.txtCellY.TabIndex = 4;
            this.txtCellY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXYZ_KeyPress);
            // 
            // txtCellX
            // 
            this.txtCellX.Location = new System.Drawing.Point(12, 35);
            this.txtCellX.MaxLength = 10;
            this.txtCellX.Name = "txtCellX";
            this.txtCellX.Size = new System.Drawing.Size(40, 20);
            this.txtCellX.TabIndex = 3;
            this.txtCellX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtXYZ_KeyPress);
            // 
            // cdvDefectCode
            // 
            this.cdvDefectCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDefectCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDefectCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDefectCode.BtnToolTipText = "";
            this.cdvDefectCode.DescText = "";
            this.cdvDefectCode.DisplaySubItemIndex = -1;
            this.cdvDefectCode.DisplayText = "";
            this.cdvDefectCode.Focusing = null;
            this.cdvDefectCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDefectCode.Index = 0;
            this.cdvDefectCode.IsViewBtnImage = false;
            this.cdvDefectCode.Location = new System.Drawing.Point(80, 64);
            this.cdvDefectCode.MaxLength = 10;
            this.cdvDefectCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDefectCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDefectCode.Name = "cdvDefectCode";
            this.cdvDefectCode.ReadOnly = false;
            this.cdvDefectCode.SearchSubItemIndex = 0;
            this.cdvDefectCode.SelectedDescIndex = -1;
            this.cdvDefectCode.SelectedSubItemIndex = -1;
            this.cdvDefectCode.SelectionStart = 0;
            this.cdvDefectCode.Size = new System.Drawing.Size(85, 20);
            this.cdvDefectCode.SmallImageList = null;
            this.cdvDefectCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDefectCode.TabIndex = 20;
            this.cdvDefectCode.TextBoxToolTipText = "";
            this.cdvDefectCode.TextBoxWidth = 85;
            this.cdvDefectCode.VisibleButton = true;
            this.cdvDefectCode.VisibleColumnHeader = false;
            this.cdvDefectCode.VisibleDescription = false;
            this.cdvDefectCode.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvDefectCode_SelectedItemChanged);
            this.cdvDefectCode.ButtonPress += new System.EventHandler(this.cdvDefectCode_ButtonPress);
            // 
            // lblDefectCode
            // 
            this.lblDefectCode.AutoSize = true;
            this.lblDefectCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefectCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefectCode.Location = new System.Drawing.Point(12, 68);
            this.lblDefectCode.Name = "lblDefectCode";
            this.lblDefectCode.Size = new System.Drawing.Size(67, 13);
            this.lblDefectCode.TabIndex = 21;
            this.lblDefectCode.Text = "Defect Code";
            // 
            // btnDefectView
            // 
            this.btnDefectView.Location = new System.Drawing.Point(172, 64);
            this.btnDefectView.Name = "btnDefectView";
            this.btnDefectView.Size = new System.Drawing.Size(55, 22);
            this.btnDefectView.TabIndex = 23;
            this.btnDefectView.Text = "View";
            this.btnDefectView.Click += new System.EventHandler(this.btnDefectView_Click);
            // 
            // grpDefectDetail
            // 
            this.grpDefectDetail.Controls.Add(this.txtChkUser2);
            this.grpDefectDetail.Controls.Add(this.txtChkUser1);
            this.grpDefectDetail.Controls.Add(this.lblChkUser2);
            this.grpDefectDetail.Controls.Add(this.lblAttachFile1);
            this.grpDefectDetail.Controls.Add(this.btnFileOpen1);
            this.grpDefectDetail.Controls.Add(this.txtAttachFile1);
            this.grpDefectDetail.Controls.Add(this.lblCauseSubRes);
            this.grpDefectDetail.Controls.Add(this.cdvSubResID);
            this.grpDefectDetail.Controls.Add(this.lblChkUser1);
            this.grpDefectDetail.Controls.Add(this.cdvResID);
            this.grpDefectDetail.Controls.Add(this.lblCauseRes);
            this.grpDefectDetail.Controls.Add(this.cdvOper);
            this.grpDefectDetail.Controls.Add(this.lblCauseOper);
            this.grpDefectDetail.Controls.Add(this.cdvFlow);
            this.grpDefectDetail.Controls.Add(this.lblCauseFlow);
            this.grpDefectDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDefectDetail.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDefectDetail.Location = new System.Drawing.Point(0, 0);
            this.grpDefectDetail.Name = "grpDefectDetail";
            this.grpDefectDetail.Size = new System.Drawing.Size(360, 112);
            this.grpDefectDetail.TabIndex = 0;
            this.grpDefectDetail.TabStop = false;
            // 
            // txtChkUser2
            // 
            this.txtChkUser2.Location = new System.Drawing.Point(260, 61);
            this.txtChkUser2.MaxLength = 20;
            this.txtChkUser2.Name = "txtChkUser2";
            this.txtChkUser2.Size = new System.Drawing.Size(88, 20);
            this.txtChkUser2.TabIndex = 19;
            // 
            // txtChkUser1
            // 
            this.txtChkUser1.Location = new System.Drawing.Point(75, 61);
            this.txtChkUser1.MaxLength = 20;
            this.txtChkUser1.Name = "txtChkUser1";
            this.txtChkUser1.Size = new System.Drawing.Size(88, 20);
            this.txtChkUser1.TabIndex = 18;
            // 
            // lblChkUser2
            // 
            this.lblChkUser2.AutoSize = true;
            this.lblChkUser2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChkUser2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChkUser2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChkUser2.Location = new System.Drawing.Point(176, 63);
            this.lblChkUser2.Name = "lblChkUser2";
            this.lblChkUser2.Size = new System.Drawing.Size(72, 13);
            this.lblChkUser2.TabIndex = 17;
            this.lblChkUser2.Text = "Check User 2";
            // 
            // lblAttachFile1
            // 
            this.lblAttachFile1.AutoSize = true;
            this.lblAttachFile1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachFile1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttachFile1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttachFile1.Location = new System.Drawing.Point(7, 87);
            this.lblAttachFile1.Name = "lblAttachFile1";
            this.lblAttachFile1.Size = new System.Drawing.Size(66, 13);
            this.lblAttachFile1.TabIndex = 16;
            this.lblAttachFile1.Text = "Attach File 1";
            // 
            // btnFileOpen1
            // 
            this.btnFileOpen1.Location = new System.Drawing.Point(326, 85);
            this.btnFileOpen1.Name = "btnFileOpen1";
            this.btnFileOpen1.Size = new System.Drawing.Size(22, 20);
            this.btnFileOpen1.TabIndex = 15;
            this.btnFileOpen1.Text = "...";
            this.btnFileOpen1.Click += new System.EventHandler(this.btnFileOpen1_Click);
            // 
            // txtAttachFile1
            // 
            this.txtAttachFile1.BackColor = System.Drawing.SystemColors.Window;
            this.txtAttachFile1.Location = new System.Drawing.Point(75, 85);
            this.txtAttachFile1.MaxLength = 400;
            this.txtAttachFile1.Name = "txtAttachFile1";
            this.txtAttachFile1.Size = new System.Drawing.Size(250, 20);
            this.txtAttachFile1.TabIndex = 14;
            // 
            // lblCauseSubRes
            // 
            this.lblCauseSubRes.AutoSize = true;
            this.lblCauseSubRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseSubRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauseSubRes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCauseSubRes.Location = new System.Drawing.Point(176, 39);
            this.lblCauseSubRes.Name = "lblCauseSubRes";
            this.lblCauseSubRes.Size = new System.Drawing.Size(81, 13);
            this.lblCauseSubRes.TabIndex = 13;
            this.lblCauseSubRes.Text = "Cause Sub Res";
            // 
            // cdvSubResID
            // 
            this.cdvSubResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubResID.BtnToolTipText = "";
            this.cdvSubResID.DescText = "";
            this.cdvSubResID.DisplaySubItemIndex = -1;
            this.cdvSubResID.DisplayText = "";
            this.cdvSubResID.Focusing = null;
            this.cdvSubResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubResID.Index = 0;
            this.cdvSubResID.IsViewBtnImage = false;
            this.cdvSubResID.Location = new System.Drawing.Point(260, 37);
            this.cdvSubResID.MaxLength = 20;
            this.cdvSubResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubResID.Name = "cdvSubResID";
            this.cdvSubResID.ReadOnly = false;
            this.cdvSubResID.SearchSubItemIndex = 0;
            this.cdvSubResID.SelectedDescIndex = -1;
            this.cdvSubResID.SelectedSubItemIndex = -1;
            this.cdvSubResID.SelectionStart = 0;
            this.cdvSubResID.Size = new System.Drawing.Size(88, 20);
            this.cdvSubResID.SmallImageList = null;
            this.cdvSubResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubResID.TabIndex = 12;
            this.cdvSubResID.TextBoxToolTipText = "";
            this.cdvSubResID.TextBoxWidth = 88;
            this.cdvSubResID.VisibleButton = true;
            this.cdvSubResID.VisibleColumnHeader = false;
            this.cdvSubResID.VisibleDescription = false;
            this.cdvSubResID.ButtonPress += new System.EventHandler(this.cdvSubResID_ButtonPress);
            // 
            // lblChkUser1
            // 
            this.lblChkUser1.AutoSize = true;
            this.lblChkUser1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChkUser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChkUser1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChkUser1.Location = new System.Drawing.Point(7, 63);
            this.lblChkUser1.Name = "lblChkUser1";
            this.lblChkUser1.Size = new System.Drawing.Size(72, 13);
            this.lblChkUser1.TabIndex = 9;
            this.lblChkUser1.Text = "Check User 1";
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
            this.cdvResID.Location = new System.Drawing.Point(75, 37);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(88, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 8;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 88;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblCauseRes
            // 
            this.lblCauseRes.AutoSize = true;
            this.lblCauseRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauseRes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCauseRes.Location = new System.Drawing.Point(7, 39);
            this.lblCauseRes.Name = "lblCauseRes";
            this.lblCauseRes.Size = new System.Drawing.Size(59, 13);
            this.lblCauseRes.TabIndex = 7;
            this.lblCauseRes.Text = "Cause Res";
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
            this.cdvOper.Location = new System.Drawing.Point(260, 13);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(88, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 6;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 88;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            // 
            // lblCauseOper
            // 
            this.lblCauseOper.AutoSize = true;
            this.lblCauseOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauseOper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCauseOper.Location = new System.Drawing.Point(176, 15);
            this.lblCauseOper.Name = "lblCauseOper";
            this.lblCauseOper.Size = new System.Drawing.Size(63, 13);
            this.lblCauseOper.TabIndex = 5;
            this.lblCauseOper.Text = "Cause Oper";
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
            this.cdvFlow.Location = new System.Drawing.Point(75, 13);
            this.cdvFlow.MaxLength = 20;
            this.cdvFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.ReadOnly = false;
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = -1;
            this.cdvFlow.SelectionStart = 0;
            this.cdvFlow.Size = new System.Drawing.Size(88, 20);
            this.cdvFlow.SmallImageList = null;
            this.cdvFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFlow.TabIndex = 4;
            this.cdvFlow.TextBoxToolTipText = "";
            this.cdvFlow.TextBoxWidth = 88;
            this.cdvFlow.VisibleButton = true;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.ButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            // 
            // lblCauseFlow
            // 
            this.lblCauseFlow.AutoSize = true;
            this.lblCauseFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauseFlow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCauseFlow.Location = new System.Drawing.Point(7, 16);
            this.lblCauseFlow.Name = "lblCauseFlow";
            this.lblCauseFlow.Size = new System.Drawing.Size(62, 13);
            this.lblCauseFlow.TabIndex = 3;
            this.lblCauseFlow.Text = "Cause Flow";
            // 
            // grpDefectComment
            // 
            this.grpDefectComment.Controls.Add(this.txtDefectComment);
            this.grpDefectComment.Controls.Add(this.lblDefectComment);
            this.grpDefectComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpDefectComment.Location = new System.Drawing.Point(0, 387);
            this.grpDefectComment.Name = "grpDefectComment";
            this.grpDefectComment.Size = new System.Drawing.Size(360, 36);
            this.grpDefectComment.TabIndex = 2;
            this.grpDefectComment.TabStop = false;
            // 
            // txtDefectComment
            // 
            this.txtDefectComment.Location = new System.Drawing.Point(92, 10);
            this.txtDefectComment.MaxLength = 400;
            this.txtDefectComment.Name = "txtDefectComment";
            this.txtDefectComment.Size = new System.Drawing.Size(256, 20);
            this.txtDefectComment.TabIndex = 1;
            // 
            // lblDefectComment
            // 
            this.lblDefectComment.AutoSize = true;
            this.lblDefectComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefectComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectComment.Location = new System.Drawing.Point(7, 12);
            this.lblDefectComment.Name = "lblDefectComment";
            this.lblDefectComment.Size = new System.Drawing.Size(86, 13);
            this.lblDefectComment.TabIndex = 0;
            this.lblDefectComment.Text = "Defect Comment";
            this.lblDefectComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLocDrag
            // 
            this.btnLocDrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLocDrag.Image = ((System.Drawing.Image)(resources.GetObject("btnLocDrag.Image")));
            this.btnLocDrag.Location = new System.Drawing.Point(284, 11);
            this.btnLocDrag.Name = "btnLocDrag";
            this.btnLocDrag.Size = new System.Drawing.Size(24, 24);
            this.btnLocDrag.TabIndex = 0;
            this.btnLocDrag.Click += new System.EventHandler(this.btnLocDrag_Click);
            this.btnLocDrag.MouseEnter += new System.EventHandler(this.btnLocDrag_MouseEnter);
            // 
            // btnHands
            // 
            this.btnHands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHands.Image = ((System.Drawing.Image)(resources.GetObject("btnHands.Image")));
            this.btnHands.Location = new System.Drawing.Point(260, 11);
            this.btnHands.Name = "btnHands";
            this.btnHands.Size = new System.Drawing.Size(24, 24);
            this.btnHands.TabIndex = 24;
            this.btnHands.Click += new System.EventHandler(this.btnHands_Click);
            this.btnHands.MouseEnter += new System.EventHandler(this.btnHands_MouseEnter);
            // 
            // btnLens
            // 
            this.btnLens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLens.Image = ((System.Drawing.Image)(resources.GetObject("btnLens.Image")));
            this.btnLens.Location = new System.Drawing.Point(212, 11);
            this.btnLens.Name = "btnLens";
            this.btnLens.Size = new System.Drawing.Size(24, 24);
            this.btnLens.TabIndex = 11;
            this.btnLens.Click += new System.EventHandler(this.btnLens_Click);
            this.btnLens.MouseEnter += new System.EventHandler(this.btnLens_MouseEnter);
            // 
            // cboPixelSize
            // 
            this.cboPixelSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboPixelSize.Items.AddRange(new object[] {
            '1',
            "2",
            "3",
            "4",
            "5"});
            this.cboPixelSize.Location = new System.Drawing.Point(158, 12);
            this.cboPixelSize.Name = "cboPixelSize";
            this.cboPixelSize.Size = new System.Drawing.Size(36, 21);
            this.cboPixelSize.TabIndex = 20;
            this.cboPixelSize.Text = "1";
            this.cboPixelSize.SelectedIndexChanged += new System.EventHandler(this.cboPixelSize_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(332, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseEnter += new System.EventHandler(this.btnRefresh_MouseEnter);
            // 
            // txtDecimalPoint
            // 
            this.txtDecimalPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDecimalPoint.Location = new System.Drawing.Point(64, 12);
            this.txtDecimalPoint.MaxLength = 2;
            this.txtDecimalPoint.Name = "txtDecimalPoint";
            this.txtDecimalPoint.Size = new System.Drawing.Size(24, 20);
            this.txtDecimalPoint.TabIndex = 11;
            this.txtDecimalPoint.Text = "2";
            this.txtDecimalPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDecimalPoint_KeyPress);
            // 
            // btnPoint
            // 
            this.btnPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPoint.Image = ((System.Drawing.Image)(resources.GetObject("btnPoint.Image")));
            this.btnPoint.Location = new System.Drawing.Point(236, 11);
            this.btnPoint.Name = "btnPoint";
            this.btnPoint.Size = new System.Drawing.Size(24, 24);
            this.btnPoint.TabIndex = 12;
            this.btnPoint.Click += new System.EventHandler(this.btnPoint_Click);
            this.btnPoint.MouseEnter += new System.EventHandler(this.btnPoint_MouseEnter);
            // 
            // btnDefectClick
            // 
            this.btnDefectClick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDefectClick.Image = ((System.Drawing.Image)(resources.GetObject("btnDefectClick.Image")));
            this.btnDefectClick.Location = new System.Drawing.Point(308, 11);
            this.btnDefectClick.Name = "btnDefectClick";
            this.btnDefectClick.Size = new System.Drawing.Size(24, 24);
            this.btnDefectClick.TabIndex = 25;
            this.btnDefectClick.Click += new System.EventHandler(this.btnDefectClick_Click);
            this.btnDefectClick.MouseEnter += new System.EventHandler(this.btnDefectClick_MouseEnter);
            // 
            // txtCellXCount
            // 
            this.txtCellXCount.Location = new System.Drawing.Point(402, 12);
            this.txtCellXCount.Name = "txtCellXCount";
            this.txtCellXCount.Size = new System.Drawing.Size(28, 20);
            this.txtCellXCount.TabIndex = 7;
            this.txtCellXCount.Visible = false;
            // 
            // txtCellYCount
            // 
            this.txtCellYCount.Location = new System.Drawing.Point(434, 12);
            this.txtCellYCount.Name = "txtCellYCount";
            this.txtCellYCount.Size = new System.Drawing.Size(28, 20);
            this.txtCellYCount.TabIndex = 8;
            this.txtCellYCount.Visible = false;
            // 
            // txtCellYSize
            // 
            this.txtCellYSize.BackColor = System.Drawing.SystemColors.Window;
            this.txtCellYSize.Location = new System.Drawing.Point(498, 12);
            this.txtCellYSize.Name = "txtCellYSize";
            this.txtCellYSize.Size = new System.Drawing.Size(28, 20);
            this.txtCellYSize.TabIndex = 9;
            this.txtCellYSize.Visible = false;
            // 
            // txtCellXSize
            // 
            this.txtCellXSize.BackColor = System.Drawing.SystemColors.Window;
            this.txtCellXSize.Location = new System.Drawing.Point(468, 12);
            this.txtCellXSize.Name = "txtCellXSize";
            this.txtCellXSize.Size = new System.Drawing.Size(26, 20);
            this.txtCellXSize.TabIndex = 10;
            this.txtCellXSize.Visible = false;
            // 
            // grpPnlControl
            // 
            this.grpPnlControl.Controls.Add(this.Label6);
            this.grpPnlControl.Controls.Add(this.Label5);
            this.grpPnlControl.Controls.Add(this.btnDefectClick);
            this.grpPnlControl.Controls.Add(this.btnPoint);
            this.grpPnlControl.Controls.Add(this.txtDecimalPoint);
            this.grpPnlControl.Controls.Add(this.btnRefresh);
            this.grpPnlControl.Controls.Add(this.cboPixelSize);
            this.grpPnlControl.Controls.Add(this.btnLens);
            this.grpPnlControl.Controls.Add(this.btnLocDrag);
            this.grpPnlControl.Controls.Add(this.btnHands);
            this.grpPnlControl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPnlControl.Location = new System.Drawing.Point(2, -3);
            this.grpPnlControl.Name = "grpPnlControl";
            this.grpPnlControl.Size = new System.Drawing.Size(364, 40);
            this.grpPnlControl.TabIndex = 21;
            this.grpPnlControl.TabStop = false;
            this.grpPnlControl.Visible = false;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(98, 14);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(52, 13);
            this.Label6.TabIndex = 27;
            this.Label6.Text = "Pixel Size";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(8, 14);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(45, 13);
            this.Label5.TabIndex = 26;
            this.Label5.Text = "Decimal";
            // 
            // frmRASTranToolEvent
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASTranToolEvent";
            this.Text = "Tool Event";
            this.Activated += new System.EventHandler(this.frmRASTranToolEvent_Activated);
            this.Load += new System.EventHandler(this.frmRASTranToolEvent_Load);
            this.LostFocus += new System.EventHandler(this.frmRASTranToolEvent_LostFocus);
            this.Resize += new System.EventHandler(this.frmRASTranToolEvent_Resize);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlRes.ResumeLayout(false);
            this.grpResource.ResumeLayout(false);
            this.grpResource.PerformLayout();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolID)).EndInit();
            this.grpEvent.ResumeLayout(false);
            this.grpEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolEventID)).EndInit();
            this.tabToolEvent.ResumeLayout(false);
            this.tpToolInfo.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.grpMain.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.tpCleanInfo.ResumeLayout(false);
            this.pnlCleanMain.ResumeLayout(false);
            this.pnlCleaningBack.ResumeLayout(false);
            this.pnlCleanInfo.ResumeLayout(false);
            this.pnlCleanSheet.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCleanData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCleanData_LotInfo)).EndInit();
            this.grpCleanInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefectCodeClean)).EndInit();
            this.tpDefectInfo.ResumeLayout(false);
            this.pnlDefectMain.ResumeLayout(false);
            this.pnlDefectBack.ResumeLayout(false);
            this.pnlDefectInfo.ResumeLayout(false);
            this.pnlDefectSheet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDefectData_LotInfo)).EndInit();
            this.grpDefectInfo.ResumeLayout(false);
            this.grpDefectInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefectCode)).EndInit();
            this.grpDefectDetail.ResumeLayout(false);
            this.grpDefectDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFlow)).EndInit();
            this.grpDefectComment.ResumeLayout(false);
            this.grpDefectComment.PerformLayout();
            this.grpPnlControl.ResumeLayout(false);
            this.grpPnlControl.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const string ITEM_TOOL_GRP = "TOOL_GRP";
        private const string ITEM_TOOL_SET_ID = "TOOL_SET_ID";
        private const string ITEM_TOOL_SET_LOCATION = "TOOL_SET_LOCATION";
        private const string ITEM_TOOL_STATUS = "TOOL_STATUS";
        private const string ITEM_LOT_ID = "LOT_ID";
        private const string ITEM_SUBLOT_ID = "SUBLOT_ID";
        private const string ITEM_RES_ID = "RES_ID";
        private const string ITEM_SUBRES_ID = "SUBRES_ID";
        private const string ITEM_AREA_ID = "AREA_ID";
        private const string ITEM_SUB_AREA_ID = "SUB_AREA_ID";
        private const string ITEM_TOOL_LOCATION = "TOOL_LOCATION";
        private const string ITEM_VENDOR_ID = "VENDOR_ID";
        private const string ITEM_MAT_ID = "MAT_ID";
        private const string ITEM_MAT_VER = "MAT_VER";
        private const string ITEM_FLOW = "FLOW";
        private const string ITEM_OPER = "OPER";
        private const string ITEM_GRADE = "GRADE";
        
        private const string ITEM_TOOL_STS_ = "TOOL_STS_";
        
        private const string FLAG_YES = "YES";
        private const string FLAG_NO = "NO";
        private const string TAB_DEFECT = "DEFECT";
        private const string TAB_CLEAN = "CLEAN";
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private bool b_validate_flag;
        //private int TypeCnt;
        //private int toolTypeCnt;
        private string sTabSelect;
        private int iColData;

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

        private TRSNode tool_type_out;
        private TRSNode tool_event_out;
        private TRSNode tool_out;
        

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
                b_validate_flag = true;
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this, cdvType, null, null, null, null, false);
                }
                else
                {
                    MPCF.FieldClear(this, cdvType, cdvToolID, null, null, null, false);
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
            try
            {
                if (FuncName == "CELL_INFO" && b_validate_flag == true)
                {
                    if (MPCF.CheckNumeric(txtCellXCount.Text) == false || MPCF.ToInt(txtCellXCount.Text) < 1)
                    {
                        b_validate_flag = false;
                        MPCF.ShowMsgBox(MPCF.GetMessage(317));
                        return false;
                    }

                    if (MPCF.CheckNumeric(txtCellYCount.Text) == false || MPCF.ToInt(txtCellYCount.Text) < 1)
                    {
                        b_validate_flag = false;
                        MPCF.ShowMsgBox(MPCF.GetMessage(318));
                        return false;
                    }

                    if (MPCF.CheckNumeric(txtCellXSize.Text) == false || MPCF.ToInt(txtCellXSize.Text) < 1)
                    {
                        b_validate_flag = false;
                        MPCF.ShowMsgBox(MPCF.GetMessage(342));
                        return false;
                    }

                    if (MPCF.CheckNumeric(txtCellYSize.Text) == false || MPCF.ToInt(txtCellYSize.Text) < 1)
                    {
                        b_validate_flag = false;
                        MPCF.ShowMsgBox(MPCF.GetMessage(343));
                        return false;
                    }

                    b_validate_flag = true;
                }
                else
                {
                    if (MPCF.CheckValue(cdvType, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvToolID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvToolEventID, 1) == false)
                    {
                        return false;
                    }

                    if (sTabSelect == TAB_CLEAN)
                    {
                        if (rdoDefectCode.Checked == true)
                        {
                            if (MPCF.CheckValue(cdvDefectCodeClean, 1) == false)
                            {
                                tabToolEvent.SelectedTab = tpCleanInfo;
                                cdvDefectCodeClean.Focus();
                                return false;
                            }
                        }
                    }
                }
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        private void InitSheet()
        {
            cdvToolEvent.Init();
        }
        
        private void ControlInit()
        {
            spdDefectData.Sheets[0].ClearRange(0, 0, 100, 8, true);
            spdCleanData.ActiveSheet.ClearRange(0, 0, 100, 8, true);
            spdDefectData.Sheets[0].RowCount = 0;
            spdCleanData.ActiveSheet.RowCount = 0;
            
            pnlDefect.Visible = false;
            pnlCleaning.Visible = false;
            
            txtCellX.Text = "";
            txtCellY.Text = "";
            txtCellZ.Text = "";
            txtLocX.Text = "";
            txtLocY.Text = "";
            txtLocZ.Text = "";
            cdvDefectCode.Text = "";
            cdvDefectCodeClean.Text = "";
            
            cdvFlow.Text = "";
            cdvOper.Text = "";
            cdvResID.Text = "";
            cdvSubResID.Text = "";
            txtChkUser1.Text = "";
            txtChkUser2.Text = "";
            txtAttachFile1.Text = "";
            txtDefectComment.Text = "";
            txtComment.Text = "";

            b_validate_flag = true;
        }
        
        //private void View_SheetControl(int row, int length)
        //{
            
        //    FarPoint.Win.Spread.CellType.TextCellType txt = new FarPoint.Win.Spread.CellType.TextCellType();
        //    txt.MaxLength = length;
        //    spdData.ActiveSheet.Cells[row, 2].CellType = txt;
        //    spdData.ActiveSheet.Cells[row, 2].Value = "";
            
        //    FarPoint.Win.Spread.Cell sheetData;
        //    sheetData = spdData.ActiveSheet.Cells[row, 2];
        //    sheetData.ColumnSpan = 2;
        //    spdData.ActiveSheet.Cells[row, 0].Font = new Font("MS Sans Serif", 8, FontStyle.Regular);
        //}
        
        private bool CheckGCMTableValid(string toolCode)
        {
            bool returnValue;
            
            returnValue = false;
            
            switch (toolCode)
            {
                case ITEM_TOOL_GRP:
                    
                    returnValue = true;
                    break;
                case ITEM_TOOL_STATUS:
                    
                    returnValue = true;
                    break;
                case ITEM_AREA_ID:
                    
                    returnValue = true;
                    break;
                case ITEM_SUB_AREA_ID:
                    
                    returnValue = true;
                    break;
                case ITEM_GRADE:
                    
                    returnValue = true;
                    break;
                default:
                    foreach (TRSNode node in tool_type_out.GetList("DATA_LIST"))
                    {
                        if (node.GetString("FIELD") == toolCode && node.GetString("TABLE_NAME") != "")
                        {
                            returnValue = true;
                            break;
                        }
                    }
                    break;
            }
            
            return returnValue;
        }

        private bool CheckToolTypeItem(string chkItem)
        {
            bool returnValue;
            
            returnValue = false;
            
            if (chkItem.Length >= 10)
            {
                if (chkItem.Substring(0, 9) == ITEM_TOOL_STS_)
                {
                    returnValue = true;
                }
            }
            
            return returnValue;
        }
        
        //private void ColumnSpan(int j, string sSpanFlag)
        //{
            
            //spdData.ActiveSheet.Cells[j, 2].BackColor = System.Drawing.Color.White;
            //spdData.ActiveSheet.Cells[j, 2].Locked = false;
            //spdData.ActiveSheet.Cells[j, 3].Locked = false;
            
            //if (sSpanFlag == FLAG_YES)
            //{
            //    FarPoint.Win.Spread.Cell sheetData;
            //    sheetData = spdData.ActiveSheet.Cells[j, 2];
            //    sheetData.ColumnSpan = 1;
                
            //    FarPoint.Win.Spread.CellType.ButtonCellType sheetBtn = new FarPoint.Win.Spread.CellType.ButtonCellType();
            //    sheetBtn.Text = "...";
            //    spdData.ActiveSheet.Cells[j, 3].CellType = sheetBtn;
            //    spdData.ActiveSheet.Cells[j, 2].Locked = true;
            //}
            //else
            //{
            //    FarPoint.Win.Spread.Cell sheetData;
            //    sheetData = spdData.ActiveSheet.Cells[j, 2];
            //    sheetData.ColumnSpan = 2;
            //}
        //}

        private bool View_Tool_Defect_List()
        {
            try
            {
                //TransToolEvent
                TRSNode in_node = new TRSNode("RAS_VIEW_TOOL_DEFECT_LIST_IN");
                TRSNode out_node = new TRSNode("RAS_VIEW_TOOL_DEFECT_LIST_OUT");
                int i;

                MPCR.SetInMsg(in_node);
               
                if (cdvDefectCode.Text == "")
                {
                    in_node.ProcStep = '1';
                }
                else
                {
                    in_node.ProcStep = '4';
                }

                in_node.AddString("TOOL_TYPE", cdvType.Text);
                in_node.AddString("TOOL_ID", cdvToolID.Text);
                in_node.AddString("NEXT_DEFECT_CODE", cdvDefectCode.Text);
                in_node.AddChar("CLEAN_FLAG", 'N');
                in_node.AddChar("HIST_DEL_FLAG", 'N');

                if (MPCR.CallService("RAS", "RAS_View_Tool_Defect_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdDefectData.Sheets[0].RowCount = out_node.GetList("TDEF_LIST").Count;
                iColData = out_node.GetList("TDEF_LIST").Count;

                PntArr = new PointArray[iColData + 1];

                for (i = 0; i < iColData; i++)
                {
                    int iCellX;
                    int iCellY;
                    int iCellZ;
                    double iLocX;
                    double iLocY;
                    double iLocZ;
                    string sDefectCode;
                    iCellX = out_node.GetList("TDEF_LIST")[i].GetInt("CELL_X");
                    iCellY = out_node.GetList("TDEF_LIST")[i].GetInt("CELL_Y");
                    iCellZ = out_node.GetList("TDEF_LIST")[i].GetInt("CELL_Z");
                    iLocX = out_node.GetList("TDEF_LIST")[i].GetDouble("LOC_X");
                    iLocY = out_node.GetList("TDEF_LIST")[i].GetDouble("LOC_Y");
                    iLocZ = out_node.GetList("TDEF_LIST")[i].GetDouble("LOC_Z");
                    sDefectCode = out_node.GetList("TDEF_LIST")[i].GetString("DEFECT_CODE");

                    spdDefectData.Sheets[0].Cells[i, 0].Value = false;
                    spdDefectData.Sheets[0].Cells[i, 1].Value = sDefectCode;
                    spdDefectData.Sheets[0].Cells[i, 2].Value = MPCF.Trim(iCellX);
                    spdDefectData.Sheets[0].Cells[i, 3].Value = MPCF.Trim(iCellY);
                    spdDefectData.Sheets[0].Cells[i, 4].Value = MPCF.Trim(iCellZ);
                    spdDefectData.Sheets[0].Cells[i, 5].Value = MPCF.Trim(iLocX);
                    spdDefectData.Sheets[0].Cells[i, 6].Value = MPCF.Trim(iLocY);
                    spdDefectData.Sheets[0].Cells[i, 7].Value = MPCF.Trim(iLocZ);
                    spdDefectData.Sheets[0].Cells[i, 8].Value = "";
                    spdDefectData.Sheets[0].Rows[i].ForeColor = System.Drawing.Color.Red;
                    spdDefectData.Sheets[0].Rows[i].Locked = true;

                    //DefectSizeX = pnlDefect.Width
                    //DefectSizeY = pnlDefect.Height

                    PntArr[i].LocX = iLocX;
                    PntArr[i].LocY = iLocY;
                    PntArr[i].Color = Color.Red;
                    PntArr[i].CellX = iCellX;
                    PntArr[i].CellY = iCellY;
                    PntArr[i].defectCode = sDefectCode;

                }

                bRunning = true;
                DrawDefectMap();
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool View_Tool_Clean_List()
        {

            //TransToolEvent
            TRSNode in_node = new TRSNode("RAS_VIEW_TOOL_DEFECT_LIST_IN");
            TRSNode out_node = new TRSNode("RAS_VIEW_TOOL_DEFECT_LIST_OUT");
            int iCellX;
            int iCellY;
            int iCellZ;
            double iLocX;
            double iLocY;
            double iLocZ;
            int i;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("TOOL_TYPE", cdvType.Text);
            in_node.AddString("TOOL_ID", cdvToolID.Text);
            in_node.AddString("TOOL_EVENT_ID", cdvToolEventID.Text);
            in_node.AddString("NEXT_DEFECT_CODE", cdvDefectCodeClean.Text);
            in_node.AddChar("CLEAN_FLAG", 'N');
            in_node.AddChar("HIST_DEL_FLAG", 'N');

            if (MPCR.CallService("RAS", "RAS_View_Tool_Defect_List", in_node, ref out_node) == false)
            {
                return false;
            }

            spdCleanData.ActiveSheet.RowCount = out_node.GetList("TDEF_LIST").Count;

            PntArrClean = new PointArray[out_node.GetList("TDEF_LIST").Count + 1];

            for (i = 0; i < out_node.GetList("TDEF_LIST").Count; i++)
            {
                iCellX = out_node.GetList("TDEF_LIST")[i].GetInt("CELL_X");
                iCellY = out_node.GetList("TDEF_LIST")[i].GetInt("CELL_Y");
                iCellZ = out_node.GetList("TDEF_LIST")[i].GetInt("CELL_Z");
                iLocX = out_node.GetList("TDEF_LIST")[i].GetDouble("LOC_X");
                iLocY = out_node.GetList("TDEF_LIST")[i].GetDouble("LOC_Y");
                iLocZ = out_node.GetList("TDEF_LIST")[i].GetDouble("LOC_Z");

                spdCleanData.ActiveSheet.Cells[i, 1].Value = out_node.GetList("TDEF_LIST")[i].GetString("DEFECT_CODE");
                spdCleanData.ActiveSheet.Cells[i, 2].Value = MPCF.Trim(iCellX);
                spdCleanData.ActiveSheet.Cells[i, 3].Value = MPCF.Trim(iCellY);
                spdCleanData.ActiveSheet.Cells[i, 4].Value = MPCF.Trim(iCellZ);
                spdCleanData.ActiveSheet.Cells[i, 5].Value = MPCF.Trim(iLocX);
                spdCleanData.ActiveSheet.Cells[i, 6].Value = MPCF.Trim(iLocY);
                spdCleanData.ActiveSheet.Cells[i, 7].Value = MPCF.Trim(iLocZ);
                spdCleanData.ActiveSheet.Rows[i].ForeColor = System.Drawing.Color.Red;
                spdCleanData.ActiveSheet.Cells[i, 0].Value = false;

                //DefectSizeXClean = pnlCleaning.Width
                //DefectSizeYClean = pnlCleaning.Height

                PntArrClean[i].LocX = iLocX;
                PntArrClean[i].LocY = iLocY;
                PntArrClean[i].Color = Color.Red;
                PntArrClean[i].CellX = iCellX;
                PntArrClean[i].CellY = iCellY;
                PntArrClean[i].defectCode = out_node.GetList("TDEF_LIST")[i].GetString("DEFECT_CODE");
            }

            bRunningClean = true;
            DrawDefectMapClean();

            return true;

        }

        private bool View_Tool_Event_Info()
        {
            //get tool event
            TRSNode in_node = new TRSNode("VIEW_TOOL_EVENT_IN");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TOOL_TYPE", cdvType.Text);
            in_node.AddString("TOOL_EVENT_ID", MPCF.Trim(cdvToolEventID.Text));

            if (MPCR.CallService("RAS", "RAS_View_Tool_Event", in_node, ref tool_event_out) == false)
            {
                return false;
            }

            // fill current tool value into control
            cdvToolEventID.DescText = MPCF.Trim(tool_event_out.GetString("TOOL_EVENT_DESC"));

            if (tool_event_out.GetChar("COLLECT_DEFECT_FLAG") == 'Y')
            {
                this.tabToolEvent.Controls.Add(this.tpDefectInfo);
                sTabSelect = TAB_DEFECT;
                btnDefectView_Click(null, null);
            }

            if (tool_event_out.GetChar("CLEAN_DEFECT_FLAG") == 'Y')
            {
                this.tabToolEvent.Controls.Add(this.tpCleanInfo);
                sTabSelect = TAB_CLEAN;
                btnCleanView_Click(null, null);
            }

            cdvToolEvent.View_Tool_Event(tool_event_out);

            cdvToolEvent.View_Tool_Status_Forecast();

            return true;
        }

        private void DefectMinus()
        {
            int SelectCount;
            
            for (SelectCount = spdDefectData.Sheets[0].RowCount - 1; SelectCount >= 0; SelectCount--)
            {
                if (spdDefectData.Sheets[0].GetValue(SelectCount, 0) == null || 
                    Convert.ToBoolean(spdDefectData.Sheets[0].GetValue(SelectCount, 0)) == false)
                {
                    if (MPCF.Trim(spdDefectData.Sheets[0].Cells[SelectCount, 8].Value) == "D")
                    {
                        spdDefectData.Sheets[0].RemoveRows(SelectCount, 1);
                    }
                }
            }
            
            bRunning = true;
            
            PntArr = new PointArray[spdDefectData.Sheets[0].RowCount + 1];
            
            for (SelectCount = 0; SelectCount < spdDefectData.Sheets[0].RowCount; SelectCount++)
            {

                PntArr[SelectCount].LocX = MPCF.ToDbl(spdDefectData.Sheets[0].Cells[SelectCount, 5].Value);
                PntArr[SelectCount].LocY = MPCF.ToDbl(spdDefectData.Sheets[0].Cells[SelectCount, 6].Value);
                PntArr[SelectCount].CellX = MPCF.ToInt(spdDefectData.Sheets[0].Cells[SelectCount, 2].Value);
                PntArr[SelectCount].CellY = MPCF.ToInt(spdDefectData.Sheets[0].Cells[SelectCount, 3].Value);
                PntArr[SelectCount].defectCode = MPCF.Trim(spdDefectData.Sheets[0].Cells[SelectCount, 1].Value);
                if (SelectCount >= iColData)
                {
                    PntArr[SelectCount].Color = Color.Blue;
                }
                else
                {
                    PntArr[SelectCount].Color = Color.Red;
                }
                
            }
            
            bRunning = true;
            DrawDefectMap();
        }
        //
        // Tool_Event()
        //       - Create/Update/Delete General Code Table Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Tool_Event(char ProcStep)
        {
            int i;
            int k;

            TRSNode in_node = new TRSNode("TOOL_EVENT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_item;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("TOOL_TYPE", cdvType.Text);
                in_node.AddString("TOOL_ID", cdvToolID.Text);
                in_node.AddString("TOOL_EVENT_ID", cdvToolEventID.Text);
                in_node.AddString("TRAN_COMMENT", txtComment.Text);

                i = 0;
                if (sTabSelect == TAB_CLEAN)
                {
                    // update for checked item
                    for (k = 0; k < spdCleanData.ActiveSheet.RowCount; k++)
                    {
                        if (spdCleanData.ActiveSheet.GetValue(k, 0) != null &&
                            Convert.ToBoolean(spdCleanData.ActiveSheet.GetValue(k, 0)) == true)
                        {
                            i++;
                        }
                    }

                    if (rdoData.Checked == true)
                    {
                        in_node.AddChar("CLEAN_OPT", '1');

                        i = 0;
                        for (k = 0; k < spdCleanData.ActiveSheet.RowCount; k++)
                        {
                            if (spdCleanData.ActiveSheet.GetValue(k, 0) != null &&
                                Convert.ToBoolean(spdCleanData.ActiveSheet.GetValue(k, 0)) == true)
                            {
                                list_item = in_node.AddNode("DEFECT_LIST");
                                list_item.AddString("DEFECT_CODE", MPCF.Trim(spdCleanData.ActiveSheet.Cells[k, 1].Value));
                                list_item.AddDouble("DEFECT_QTY", 1);
                                list_item.AddString("DEFECT_COMMENT", txtDefectComment.Text);
                                list_item.AddInt("CELL_X", MPCF.ToInt(spdCleanData.ActiveSheet.Cells[k, 2].Value));
                                list_item.AddInt("CELL_Y", MPCF.ToInt(spdCleanData.ActiveSheet.Cells[k, 3].Value));
                                list_item.AddInt("CELL_Z", MPCF.ToInt(spdCleanData.ActiveSheet.Cells[k, 4].Value));
                                list_item.AddDouble("LOC_X", MPCF.ToDbl(spdCleanData.ActiveSheet.Cells[k, 5].Value));
                                list_item.AddDouble("LOC_Y", MPCF.ToDbl(spdCleanData.ActiveSheet.Cells[k, 6].Value));
                                list_item.AddDouble("LOC_Z", MPCF.ToDbl(spdCleanData.ActiveSheet.Cells[k, 7].Value));
                                i++;
                            }
                        }
                    }
                    else if (rdoDefectCode.Checked == true)
                    {
                        in_node.AddChar("CLEAN_OPT", '2');

                        list_item = in_node.AddNode("DEFECT_LIST");
                        list_item.AddString("DEFECT_CODE", MPCF.Trim(cdvDefectCodeClean.Text));
                        //in_node.AddString("DEFECT_QTY", 1);
                        //in_node.AddString("DEFECT_COMMENT", txtDefectComment.Text);
                        //in_node.AddString("CELL_X", spdCleanData.Sheets(0).Cells(j, 2).Value);
                        //in_node.AddString("CELL_Y", spdCleanData.Sheets(0).Cells(j, 3).Value);
                        //in_node.AddString("CELL_Z", spdCleanData.Sheets(0).Cells(j, 4).Value);
                        //in_node.AddString("LOC_X", spdCleanData.Sheets(0).Cells(j, 5).Value);
                        //in_node.AddString("LOC_Y", spdCleanData.Sheets(0).Cells(j, 6).Value);
                        //in_node.AddString("LOC_Z", spdCleanData.Sheets(0).Cells(j, 7).Value);

                    }
                    else if (rdoAll.Checked == true)
                    {
                        in_node.AddChar("CLEAN_OPT", '4');
                    }

                }
                else
                {
                    // If pnlDefect.Visible = True Then
                    DefectMinus();

                    for (k = iColData; k < spdDefectData.Sheets[0].RowCount; k++)
                    {
                        if (spdDefectData.Sheets[0].Cells[k, 0].Value != null &&
                            Convert.ToBoolean(spdDefectData.Sheets[0].Cells[k, 0].Value) == true)
                        {
                            list_item = in_node.AddNode("DEFECT_LIST");
                            list_item.AddString("CAUSE_FLOW", cdvFlow.Text);
                            list_item.AddString("CAUSE_OPER", cdvOper.Text);
                            list_item.AddString("CAUSE_RES_ID", cdvResID.Text);
                            list_item.AddString("CAUSE_SUBRES_ID", cdvSubResID.Text);
                            list_item.AddString("CHK_USER_ID1", txtChkUser1.Text, true);
                            list_item.AddString("CHK_USER_ID2", txtChkUser2.Text, true);
                            list_item.AddString("ATTACH_FILE_1", txtAttachFile1.Text);
                            list_item.AddString("DEFECT_CODE", MPCF.Trim(spdDefectData.Sheets[0].Cells[k, 1].Value));
                            list_item.AddDouble("DEFECT_QTY", 1);
                            list_item.AddString("DEFECT_COMMENT", txtDefectComment.Text);
                            list_item.AddInt("CELL_X", MPCF.ToInt(spdDefectData.Sheets[0].Cells[k, 2].Value));
                            list_item.AddInt("CELL_Y", MPCF.ToInt(spdDefectData.Sheets[0].Cells[k, 3].Value));
                            list_item.AddInt("CELL_Z", MPCF.ToInt(spdDefectData.Sheets[0].Cells[k, 4].Value));
                            list_item.AddDouble("LOC_X", MPCF.ToDbl(spdDefectData.Sheets[0].Cells[k, 5].Value));
                            list_item.AddDouble("LOC_Y", MPCF.ToDbl(spdDefectData.Sheets[0].Cells[k, 6].Value));
                            list_item.AddDouble("LOC_Z", MPCF.ToDbl(spdDefectData.Sheets[0].Cells[k, 7].Value));
                        }
                    }
                    //End If
                }

                if (cdvToolEvent.Set_Tool_InputValue(in_node) == false) return false;

                #region CheckSheet

                //int idx;
                //ListView itmX = new ListView();
                //MPCF.InitListView(itmX);
                //itmX.Columns.Add("Event", 50, HorizontalAlignment.Left);
                //itmX.Columns.Add("Type", 100, HorizontalAlignment.Left);
                //if(BASLIST.ViewGCMDataList(itmX, '1', MPGC.MP_SHEET_EVENT) == false)
                //    return false;

                //if ((idx = MPCF.FindListItemIndex(itmX, in_node.GetString("TOOL_EVENT_ID"), false)) >= 0)
                //{
                //    if (MPGO.UsePMSheet() == true)
                //    {
                //        bool b_is_sheet = false;

                //        if (MPCR.CheckSheetNameis("", ref b_is_sheet) == true)
                //        {
                //            if (b_is_sheet == true)
                //            {
                //                frmRASTranMakeCheckResult frmMakeCheck = new frmRASTranMakeCheckResult();

                //                frmMakeCheck.SetDataSheet("", itmX.Items[idx].SubItems[1].Text,
                //                                                 "", "", "", "", "",
                //                                                 "", "", "", "", "",
                //                                                 "", true, false, ref in_node);

                //                if (frmMakeCheck.ShowDialog(this) != DialogResult.OK) return false;
                //            }
                //        }
                //    }
                //}

                #endregion

                if (MPCR.CallService("RAS", "RAS_Tool_Event", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        
        #endregion
        
        #region "Defect Variable Definition"
        //Member Variable
        int m_DefectSizeX = 0;
        int m_DefectSizeY = 0;
        double m_DefectCellSizeX = 0;
        double m_DefectCellSizeY = 0;
        int m_CellCountX = 0;
        int m_CellCountY = 0;
        double m_CellSizeX = 0;
        double m_CellSizeY = 0;
        int m_DecimalPoint = 0;
        int m_PixelSize = 5;
        float m_ScaleRate = 1;
        double m_SelectedLocX = 0;
        double m_SelectedLocY = 0;
        int m_SelectedCellX = 0;
        int m_SelectedCellY = 0;
        float m_CurrentPixelSize = 0;
        
        //Local Variable
        //Dim bRunning As Boolean = True
        double dLocX = 0;
        double dLocY = 0;
        public bool bRunning = true;
        
        public struct PointArray
        {
            public double LocX;
            public double LocY;
            public System.Drawing.Color Color;
            public int CellX;
            public int CellY;
            public int Qty;
            public string defectCode;
        }

        public struct Rect
        {
            public double LocX;
            public double LocY;
            public System.Drawing.Color BorderColor;
            public System.Drawing.Color BackColor;
            public int Width;
            public int Height;
        }
        
        PointArray[] PntArr = new PointArray[1];
        
        Rect[] RectArr = new Rect[2];
        
        //Clean Member Variable
        int m_DefectSizeXClean = 0;
        int m_DefectSizeYClean = 0;
        double m_DefectCellSizeXClean = 0;
        double m_DefectCellSizeYClean = 0;
        int m_CellCountXClean = 0;
        int m_CellCountYClean = 0;
        double m_CellSizeXClean = 0;
        double m_CellSizeYClean = 0;
        int m_DecimalPointClean = 0;
        int m_PixelSizeClean = 5;
        float m_ScaleRateClean = 1;
        double m_SelectedLocXClean = 0;
        double m_SelectedLocYClean = 0;
        int m_SelectedCellXClean = 0;
        int m_SelectedCellYClean = 0;
        float m_CurrentPixelSizeClean = 0;
        
        //Clean Local Variable
        //Dim bRunningClean As Boolean = True
        double dLocXClean = 0;
        double dLocYClean = 0;
        public bool bRunningClean = true;

        public struct PointArrayClean
        {
            public double LocX;
            public double LocY;
            public System.Drawing.Color Color;
            public int CellX;
            public int CellY;
            public int Qty;
            public string defectCode;
        }
        
        public struct RectClean
        {
            public double LocX;
            public double LocY;
            public System.Drawing.Color BorderColor;
            public System.Drawing.Color BackColor;
            public int Width;
            public int Height;
        }
        
        PointArray[] PntArrClean = new PointArray[1];
        
        RectClean[] RectArrClean = new RectClean[2];
        
        #endregion
        
        #region "Property Definition"
        
        //<Browsable(False), _
        //DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        //Public Property DroppedDown() As Boolean
        //    Get
        //        Return m_bDroppedDown
        //    End Get
        //    Set(ByVal Value As Boolean)
        //        m_bDroppedDown = Value
        //    End Set
        //End Property
        
        public int DefectSizeX
        {
            get
            {
                return m_DefectSizeX;
            }
            set
            {
                m_DefectSizeX = value;
            }
        }
        
        public int DefectSizeY
        {
            get
            {
                return m_DefectSizeY;
            }
            set
            {
                m_DefectSizeY = value;
            }
        }
        
        public double DefectCellSizeX
        {
            get
            {
                return m_DefectCellSizeX;
            }
            set
            {
                m_DefectCellSizeX = value;
            }
        }
        
        public double DefectCellSizeY
        {
            get
            {
                return m_DefectCellSizeY;
            }
            set
            {
                m_DefectCellSizeY = value;
            }
        }
        
        public int CellCountX
        {
            get
            {
                return m_CellCountX;
            }
            set
            {
                m_CellCountX = value;
            }
        }
        
        public int CellCountY
        {
            get
            {
                return m_CellCountY;
            }
            set
            {
                m_CellCountY = value;
            }
        }
        
        public double CellSizeX
        {
            get
            {
                return m_CellSizeX;
            }
            set
            {
                m_CellSizeX = value;
            }
        }
        
        public double CellSizeY
        {
            get
            {
                return m_CellSizeY;
            }
            set
            {
                m_CellSizeY = value;
            }
        }
        
        public int DecimalPoint
        {
            get
            {
                return m_DecimalPoint;
            }
            set
            {
                if (value > 3)
                {
                    m_DecimalPoint = 3;
                }
                else if (value < 0)
                {
                    m_DecimalPoint = 0;
                }
                else
                {
                    m_DecimalPoint = value;
                }
            }
        }
        
        public int PixelSize
        {
            get
            {
                return m_PixelSize;
            }
            set
            {
                if (value > 0)
                {
                    m_PixelSize = value;
                }
            }
        }
        
        public float CurrentPixelSize
        {
            get
            {
                return m_CurrentPixelSize;
            }
            set
            {
                if (value > 0)
                {
                    m_CurrentPixelSize = value;
                }
            }
        }
        
        public float ScaleRate
        {
            get
            {
                return m_ScaleRate;
            }
            set
            {
                m_ScaleRate = value;
            }
        }
        
        public double SelectedLocX
        {
            get
            {
                return m_SelectedLocX;
            }
            set
            {
                m_SelectedLocX = value;
            }
        }
        
        public double SelectedLocY
        {
            get
            {
                return m_SelectedLocY;
            }
            set
            {
                m_SelectedLocY = value;
            }
        }
        
        public double SelectedCellX
        {
            get
            {
                return m_SelectedCellX;
            }
            set
            {
                m_SelectedCellX =  (int)value;
            }
        }
        
        public double SelectedCellY
        {
            get
            {
                return m_SelectedCellY;
            }
            set
            {
                m_SelectedCellY = (int)value;
            }
        }
        
        //===================
        //Clean
        //<Browsable(False), _
        //DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
        //Public Property DroppedDown() As Boolean
        //    Get
        //        Return m_bDroppedDown
        //    End Get
        //    Set(ByVal Value As Boolean)
        //        m_bDroppedDown = Value
        //    End Set
        //End Property
        
        public int DefectSizeXClean
        {
            get
            {
                return m_DefectSizeXClean;
            }
            set
            {
                m_DefectSizeXClean = value;
            }
        }
        
        public int DefectSizeYClean
        {
            get
            {
                return m_DefectSizeYClean;
            }
            set
            {
                m_DefectSizeYClean = value;
            }
        }
        
        public double DefectCellSizeXClean
        {
            get
            {
                return m_DefectCellSizeXClean;
            }
            set
            {
                m_DefectCellSizeXClean = value;
            }
        }
        
        public double DefectCellSizeYClean
        {
            get
            {
                return m_DefectCellSizeYClean;
            }
            set
            {
                m_DefectCellSizeYClean = value;
            }
        }
        
        public int CellCountXClean
        {
            get
            {
                return m_CellCountXClean;
            }
            set
            {
                m_CellCountXClean = value;
            }
        }
        
        public int CellCountYClean
        {
            get
            {
                return m_CellCountYClean;
            }
            set
            {
                m_CellCountYClean = value;
            }
        }
        
        public double CellSizeXClean
        {
            get
            {
                return m_CellSizeXClean;
            }
            set
            {
                m_CellSizeXClean = value;
            }
        }
        
        public double CellSizeYClean
        {
            get
            {
                return m_CellSizeYClean;
            }
            set
            {
                m_CellSizeYClean = value;
            }
        }
        
        public int DecimalPointClean
        {
            get
            {
                return m_DecimalPointClean;
            }
            set
            {
                if (value > 3)
                {
                    m_DecimalPointClean = 3;
                }
                else if (value < 0)
                {
                    m_DecimalPointClean = 0;
                }
                else
                {
                    m_DecimalPointClean = value;
                }
            }
        }
        
        public int PixelSizeClean
        {
            get
            {
                return m_PixelSizeClean;
            }
            set
            {
                if (value > 0)
                {
                    m_PixelSizeClean = value;
                }
            }
        }
        
        public float CurrentPixelSizeClean
        {
            get
            {
                return m_CurrentPixelSizeClean;
            }
            set
            {
                if (value > 0)
                {
                    m_CurrentPixelSizeClean = value;
                }
            }
        }
        
        public float ScaleRateClean
        {
            get
            {
                return m_ScaleRateClean;
            }
            set
            {
                m_ScaleRateClean = value;
            }
        }
        
        public double SelectedLocXClean
        {
            get
            {
                return m_SelectedLocXClean;
            }
            set
            {
                m_SelectedLocXClean = value;
            }
        }
        
        public double SelectedLocYClean
        {
            get
            {
                return m_SelectedLocYClean;
            }
            set
            {
                m_SelectedLocYClean = value;
            }
        }
        
        public double SelectedCellXClean
        {
            get
            {
                return m_SelectedCellXClean;
            }
            set
            {
                m_SelectedCellXClean = (int)value;
            }
        }
        
        public double SelectedCellYClean
        {
            get
            {
                return m_SelectedCellYClean;
            }
            set
            {
                m_SelectedCellYClean = (int)value;
            }
        }
        #endregion
        
        #region "Function Definition"
        
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            
            try
            {
                if (sTabSelect == TAB_CLEAN)
                {
                    if (bRunningClean == true)
                    {
                        DrawDefectMapClean();
                    }
                }
                else
                {
                    if (bRunning == true)
                    {
                        DrawDefectMap();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        
        public double ValuePosition(double dValue, int iDecimalCnt)
        {
            double dTargetValue = 0;
            
            dTargetValue = ((dValue *(Math.Pow(10, iDecimalCnt))) / 1) /(Math.Pow(10, iDecimalCnt));
            
            return dTargetValue;
            
        }
        
        public void ZoomIn(int iStep, float iZoom)
        {
            
            if (iStep == 1)
            {
                ScaleRate = ScaleRate + iZoom;
                pnlDefect.Width =  (int)(pnlDefect.Width * ScaleRate);
                pnlDefect.Height =  (int)(pnlDefect.Height * ScaleRate);
                CurrentPixelSize = (int)(CurrentPixelSize * ScaleRate);
            }
            else if (iStep == 2)
            {
                ScaleRate = 1;
                pnlDefect.Width = 350;
                pnlDefect.Height = 350;
                CurrentPixelSize = (MPCF.CheckNumeric(cboPixelSize.Text) == true) ? (MPCF.ToInt(cboPixelSize.Text)) : 5;
            }
            
            DrawDefectMap();
        }
        
        public void ZoomOut(int iStep, float iZoom)
        {
            
            if (iStep == 1)
            {
                if (ScaleRate - iZoom < 1)
                {
                    return;
                }
                else
                {
                    ScaleRate = ScaleRate - iZoom;
                }
                pnlDefect.Width =  (int)(pnlDefect.Width /(ScaleRate + 0.1));
                pnlDefect.Height =  (int)(pnlDefect.Height /(ScaleRate + 0.1));
                CurrentPixelSize =  (int)(CurrentPixelSize /(ScaleRate + 0.1));
            }
            else if (iStep == 2)
            {
                ScaleRate = 1;
                pnlDefect.Width = 350;
                pnlDefect.Height = 350;
                if (MPCF.CheckNumeric(cboPixelSize.Text) == true)
                {
                    CurrentPixelSize = MPCF.ToInt(cboPixelSize.Text);
                }
                else
                {
                    CurrentPixelSize = 5;
                }
                
            }
            
            DrawDefectMap();
        }
        
        public void DrawDefectMap()
        {
            Graphics Gr = null;
            Pen pn = null;
            int i;
            int iLocX;
            int iLocY;
            int iWidth;
            int iHeight;

            if (tabToolEvent.TabPages.Contains(tpDefectInfo) == false) return;

            if (CheckCondition("CELL_INFO") == false) return;

            CellCountX = MPCF.ToInt(txtCellXCount.Text);
            CellCountY = MPCF.ToInt(txtCellYCount.Text);
            CellSizeX = MPCF.ToDbl(txtCellXSize.Text);
            CellSizeY = MPCF.ToDbl(txtCellYSize.Text);
                
            if (MPCF.CheckNumeric(txtDecimalPoint.Text) == false)
            {
                txtDecimalPoint.Text = "2";
                DecimalPoint = 2;
            }
            else
            {
                DecimalPoint = MPCF.ToInt(txtDecimalPoint.Text);
            }
                
            if (cboPixelSize.Text == "")
            {
                PixelSize = 2;
            }
            else
            {
                PixelSize = MPCF.ToInt(cboPixelSize.Text);
            }
                
            if ((CurrentPixelSize) == 0)
            {
                CurrentPixelSize = PixelSize;
            }


            if (CellSizeX != 0 && CellCountX != 0)
                DefectCellSizeX = ValuePosition((DefectSizeX / CellCountX), DecimalPoint);
            if (CellSizeY != 0 && CellCountY != 0)
                DefectCellSizeY = ValuePosition((DefectSizeY / CellCountY), DecimalPoint);
            
            Gr = pnlDefect.CreateGraphics();
            Gr.Clear(Color.White);
            Gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            //Draw Rectangle
            if (RectArr[0].LocX > 0 && RectArr[0].LocY > 0)
            {
                iLocX = MPCF.ToInt(ValuePosition((DefectSizeX /(CellCountX * CellSizeX)) * RectArr[0].LocX, DecimalPoint));
                iLocY = MPCF.ToInt(ValuePosition((DefectSizeY /(CellCountY * CellSizeY)) * RectArr[0].LocY, DecimalPoint));
                iWidth = MPCF.ToInt(ValuePosition((DefectSizeX /(CellCountX * CellSizeX)) * RectArr[0].Width, DecimalPoint));
                iHeight = MPCF.ToInt(ValuePosition((DefectSizeY /(CellCountY * CellSizeY)) * RectArr[0].Height, DecimalPoint));
                
                pn = new Pen(RectArr[0].BorderColor, PixelSize * ScaleRate);
                Gr.FillRectangle(new SolidBrush(RectArr[0].BackColor), new Rectangle(iLocX, iLocY, iWidth, iHeight));
                Gr.DrawRectangle(pn, new Rectangle(iLocX, iLocY, iWidth, iHeight));
            }
            
            //Draw Line
            pn = new Pen(Color.LightGray, PixelSize * ScaleRate);
            for (i = 1; i < CellCountX; i++)
            {
                Gr.DrawLine(pn, System.Convert.ToSingle(DefectCellSizeX * i), 0, System.Convert.ToSingle(DefectCellSizeX * i), DefectSizeY);
            }
            
            for (i = 1; i < CellCountY; i++)
            {
                Gr.DrawLine(pn, 0, System.Convert.ToSingle(DefectCellSizeY * i), DefectSizeX, System.Convert.ToSingle(DefectCellSizeY * i));
            }
            
            for (i = 0; i < PntArr.Length; i++)
            {
                if (PntArr[i].LocX > 0 && PntArr[i].LocY > 0 && PntArr[i].Color.Name != "0")
                {
                    iLocX = (int)(ValuePosition((DefectSizeX / (CellCountX * CellSizeX)) * PntArr[i].LocX, DecimalPoint));
                    iLocY = (int)(ValuePosition((DefectSizeY / (CellCountY * CellSizeY)) * PntArr[i].LocY, DecimalPoint));
                    iLocX = (int)(iLocX - CurrentPixelSize / 2);
                    iLocY = (int)(iLocY - CurrentPixelSize / 2);
                    Gr.FillPie(new SolidBrush(PntArr[i].Color), new Rectangle(iLocX, iLocY, (int)CurrentPixelSize, (int)CurrentPixelSize), 0, 360);
                }
            }
            
            bRunning = false;
            
        }
        
        public void DrawPoint()
        {
            int iIndex;
            Color CellColor = Color.Blue;
            Graphics Gr;
            Pen pn;
            
            if (PntArr.Length == 1)
            {
                if (PntArr[0].LocX < 0 || PntArr[0].LocY < 0)
                {
                    iIndex = 0;
                }
                else
                {
                    Array.Resize<PointArray>(ref PntArr, PntArr.Length + 1);
                    iIndex = PntArr.Length - 1;
                }
            }
            else
            {
                Array.Resize<PointArray>(ref PntArr, PntArr.Length + 1);
                iIndex = PntArr.Length - 1;
            }

            if (MPCF.Trim(cdvDefectCode.Tag) != "")
            {
                string color = MPCF.Trim(cdvDefectCode.Tag);
                if (color.Contains(",") == true)
                {
                    List<int> rgb = new List<int>();

                    string[] temp = color.Split(',', ' ');
                    foreach (string c in temp)
                    {
                        if (MPCF.CheckNumeric(c) == true)
                            rgb.Add(MPCF.ToInt(c));
                    }

                    CellColor = new Color();
                    CellColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
                }
            }

            PntArr[iIndex].LocX = ValuePosition((CellSizeX * CellCountX / DefectSizeX) * SelectedLocX, DecimalPoint);
            PntArr[iIndex].LocY = ValuePosition((CellSizeY * CellCountY / DefectSizeY) * SelectedLocY, DecimalPoint);
            PntArr[iIndex].Color = CellColor;
            PntArr[iIndex].CellX = (int)SelectedCellX;
            PntArr[iIndex].CellY = (int)SelectedCellY;
            PntArr[iIndex].defectCode = cdvDefectCode.Text;
            
            pn = new Pen(Color.LightGray, PixelSize * ScaleRate);
            Gr = pnlDefect.CreateGraphics();
            Gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            if (CurrentPixelSize < PixelSize || CurrentPixelSize < System.Convert.ToSingle(cboPixelSize.Text))
            {
                CurrentPixelSize = System.Convert.ToSingle(cboPixelSize.Text);
            }

            Gr.FillPie(new SolidBrush(PntArr[iIndex].Color), new Rectangle(MPCF.ToInt(SelectedLocX - CurrentPixelSize / 2), MPCF.ToInt(SelectedLocY - CurrentPixelSize / 2), (int)CurrentPixelSize, (int)CurrentPixelSize), 0, 360);
            
            
            bRunning = true;
        }
        
        public void DrawRectangle(double dLocX, double dLocY, int iWidth, int iHeight)
        {
            int iIndex;
            Graphics Gr;
            Pen pn;
            int i;
            int iLocX;
            int iLocY;

            if (PntArr.Length == 1)
            {
                if (PntArr[0].LocX < 0 || PntArr[0].LocY < 0)
                {
                    iIndex = 0;
                }
                else
                {
                    Array.Resize<PointArray>(ref PntArr, PntArr.Length + 1);
                    iIndex = PntArr.Length - 1;
                }
            }
            else
            {
                Array.Resize<PointArray>(ref PntArr, PntArr.Length + 1);
                iIndex = PntArr.Length - 1;
            }
            
            RectArr[0].LocX = ValuePosition((CellSizeX * CellCountX / DefectSizeX) * dLocX, DecimalPoint);
            RectArr[0].LocY = ValuePosition((CellSizeY * CellCountY / DefectSizeY) * dLocY, DecimalPoint);
            RectArr[0].BorderColor = Color.WhiteSmoke;
            RectArr[0].BackColor = Color.Lavender;
            RectArr[0].Width = (int)ValuePosition((CellSizeX * CellCountX / DefectSizeX) * iWidth, DecimalPoint);
            RectArr[0].Height = (int)ValuePosition((CellSizeX * CellCountX / DefectSizeX) * iHeight, DecimalPoint);
            
            pn = new Pen(RectArr[0].BorderColor, PixelSize * ScaleRate);
            Gr = pnlDefect.CreateGraphics();
            Gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Gr.FillRectangle(new SolidBrush(RectArr[0].BackColor), new Rectangle((int)dLocX, (int)dLocY, iWidth, iHeight));
            Gr.DrawRectangle(pn, new Rectangle((int)dLocX, (int)dLocY, iWidth, iHeight));
            
            //Draw Line
            pn.Color = Color.LightGray;
            for (i = 1; i < CellCountX; i++)
            {
                Gr.DrawLine(pn, System.Convert.ToSingle(DefectCellSizeX * i), 0, System.Convert.ToSingle(DefectCellSizeX * i), DefectSizeY);
            }
            
            for (i = 1; i < CellCountY; i++)
            {
                Gr.DrawLine(pn, 0, System.Convert.ToSingle(DefectCellSizeY * i), DefectSizeX, System.Convert.ToSingle(DefectCellSizeY * i));
            }
            
            for (i = 0; i < PntArr.Length; i++)
            {
                if (PntArr[i].LocX >= RectArr[0].LocX && PntArr[i].LocX <= RectArr[0].LocX + RectArr[0].Width && PntArr[i].LocY >= RectArr[0].LocY && PntArr[i].LocY <= RectArr[0].LocY + RectArr[0].Height)
                {
                    iLocX = (int)(ValuePosition((DefectSizeX /(CellCountX * CellSizeX)) * PntArr[i].LocX, DecimalPoint));
                    iLocY = (int)(ValuePosition((DefectSizeY / (CellCountY * CellSizeY)) * PntArr[i].LocY, DecimalPoint));
                    iLocX = (int)(iLocX - PixelSize * ScaleRate);
                    iLocY = (int)(iLocY - PixelSize * ScaleRate);
                    Gr.FillPie(new SolidBrush(PntArr[i].Color), new Rectangle(iLocX, iLocY, (int)(PixelSize * ScaleRate * 2), (int)(PixelSize * ScaleRate * 2)), 0, 360);
                }
            }
            
            bRunning = true;
        }
        
        //===============
        //Clean
        public void ZoomInClean(int iStep, float iZoom)
        {
            
            if (iStep == 1)
            {
                ScaleRateClean = ScaleRateClean + iZoom;
                pnlCleaning.Width =  (int)(pnlCleaning.Width * ScaleRateClean);
                pnlCleaning.Height =  (int)(pnlCleaning.Height * ScaleRateClean);
                CurrentPixelSizeClean = (int)(CurrentPixelSizeClean * ScaleRateClean);
            }
            else if (iStep == 2)
            {
                ScaleRateClean = 1;
                pnlCleaning.Width = 350;
                pnlCleaning.Height = 350;
                CurrentPixelSizeClean = (MPCF.CheckNumeric(cboPixelSize.Text) == true) ? (MPCF.ToInt(cboPixelSize.Text)) : 5;
            }
            
            DrawDefectMapClean();
        }
        
        public void ZoomOutClean(int iStep, float iZoom)
        {
            
            if (iStep == 1)
            {
                if (ScaleRateClean - iZoom < 1)
                {
                    return;
                }
                else
                {
                    ScaleRateClean = ScaleRateClean - iZoom;
                }
                pnlCleaning.Width =  (int)(pnlCleaning.Width /(ScaleRateClean + 0.1));
                pnlCleaning.Height =  (int)(pnlCleaning.Height /(ScaleRateClean + 0.1));
                CurrentPixelSizeClean =  (int)(CurrentPixelSizeClean /(ScaleRateClean + 0.1));
            }
            else if (iStep == 2)
            {
                ScaleRateClean = 1;
                pnlCleaning.Width = 350;
                pnlCleaning.Height = 350;
                
                if (MPCF.CheckNumeric(cboPixelSize.Text) == true)
                {
                    CurrentPixelSizeClean = (float)MPCF.ToDbl(cboPixelSize.Text);
                }
                else
                {
                    CurrentPixelSizeClean = 5;
                }
                //CurrentPixelSizeClean = IIf(IsNumeric(cboPixelSize.Text) = True, CInt(cboPixelSize.Text), 5)
            }
            
            DrawDefectMapClean();
        }
        
        public void DrawDefectMapClean()
        {
            Graphics Gr = null;
            Pen pn = null;
            int i;
            int iLocX;
            int iLocY;
            int iWidth;
            int iHeight;

            if (tabToolEvent.TabPages.Contains(tpCleanInfo) == false) return;

            if (CheckCondition("CELL_INFO") == false) return;

            CellCountXClean = MPCF.ToInt(txtCellXCount.Text);
            CellCountYClean = MPCF.ToInt(txtCellYCount.Text);
            CellSizeXClean = MPCF.ToDbl(txtCellXSize.Text);
            CellSizeYClean = MPCF.ToDbl(txtCellYSize.Text);
                
            if (MPCF.CheckNumeric(txtDecimalPoint.Text) == false)
            {
                txtDecimalPoint.Text = "2";
                DecimalPointClean = 2;
            }
            else
            {
                DecimalPointClean = MPCF.ToInt(txtDecimalPoint.Text);
            }
                
            if (cboPixelSize.Text == "")
            {
                PixelSizeClean = 2;
            }
            else
            {
                PixelSizeClean = MPCF.ToInt(cboPixelSize.Text);
            }
                
            if ((CurrentPixelSizeClean) == 0)
            {
                CurrentPixelSizeClean = PixelSizeClean;
            }

            if (CellCountXClean != 0)
                DefectCellSizeXClean = ValuePosition((DefectSizeXClean / CellCountXClean), DecimalPointClean);

            if (CellCountYClean != 0)
                DefectCellSizeYClean = ValuePosition((DefectSizeYClean / CellCountYClean), DecimalPointClean);
            
            Gr = pnlCleaning.CreateGraphics();
            Gr.Clear(Color.White);
            Gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            //Draw Rectangle
            //if (! RectArrClean[0].LocX == null && ! RectArrClean[0].LocY == null)
            if (RectArrClean[0].LocX > 0 && RectArrClean[0].LocY > 0)
            {
                iLocX = (int)(ValuePosition((DefectSizeXClean /(CellCountXClean * CellSizeXClean)) * RectArrClean[0].LocX, DecimalPointClean));
                iLocY = (int)(ValuePosition((DefectSizeYClean / (CellCountYClean * CellSizeYClean)) * RectArrClean[0].LocY, DecimalPointClean));
                iWidth = (int)(ValuePosition((DefectSizeXClean / (CellCountXClean * CellSizeXClean)) * RectArrClean[0].Width, DecimalPointClean));
                iHeight = (int)(ValuePosition((DefectSizeYClean / (CellCountYClean * CellSizeYClean)) * RectArrClean[0].Height, DecimalPointClean));
                
                pn = new Pen(RectArr[0].BorderColor, PixelSizeClean * ScaleRateClean);
                Gr.FillRectangle(new SolidBrush(RectArrClean[0].BackColor), new Rectangle(iLocX, iLocY, iWidth, iHeight));
                Gr.DrawRectangle(pn, new Rectangle(iLocX, iLocY, iWidth, iHeight));
            }
            
            //Draw Line
            pn = new Pen(Color.LightGray, PixelSizeClean * ScaleRateClean);
            for (i = 1; i < CellCountXClean; i++)
            {
                Gr.DrawLine(pn, System.Convert.ToSingle(DefectCellSizeXClean * i), 0, System.Convert.ToSingle(DefectCellSizeXClean * i), DefectSizeYClean);
            }
            
            for (i = 1; i < CellCountYClean; i++)
            {
                Gr.DrawLine(pn, 0, System.Convert.ToSingle(DefectCellSizeYClean * i), DefectSizeXClean, System.Convert.ToSingle(DefectCellSizeYClean * i));
            }
            
            for (i = 0; i < PntArrClean.Length; i++)
            {
                if (PntArrClean[i].LocX > 0 && PntArrClean[i].LocY > 0 && PntArrClean[i].Color.Name != "0")
                {
                    iLocX = (int)(ValuePosition((DefectSizeXClean / (CellCountXClean * CellSizeXClean)) * PntArrClean[i].LocX, DecimalPointClean));
                    iLocY = (int)(ValuePosition((DefectSizeYClean / (CellCountYClean * CellSizeYClean)) * PntArrClean[i].LocY, DecimalPointClean));
                    iLocX = (int)(iLocX - CurrentPixelSizeClean / 2);
                    iLocY = (int)(iLocY - CurrentPixelSizeClean / 2);
                    Gr.FillPie(new SolidBrush(PntArrClean[i].Color), new Rectangle(iLocX, iLocY, (int)CurrentPixelSizeClean, (int)CurrentPixelSizeClean), 0, 360);
                }
            }
            
            bRunningClean = false;
            
        }
        
        public void DrawPointClean()
        {
            int iIndex;
            Graphics Gr;
            Pen pn;

            if (PntArrClean.Length == 1)
            {
                if (PntArrClean[0].LocX < 0 || PntArrClean[0].LocY < 0)
                {
                    iIndex = 0;
                }
                else
                {
                    Array.Resize<PointArray>(ref PntArrClean, PntArrClean.Length + 1);
                    iIndex = PntArrClean.Length - 1;
                }
            }
            else
            {
                Array.Resize<PointArray>(ref PntArrClean, PntArrClean.Length + 1);
                iIndex = PntArrClean.Length - 1;
            }
            
               PntArrClean[iIndex].LocX = ValuePosition((CellSizeXClean * CellCountXClean / DefectSizeXClean) * SelectedLocXClean, DecimalPointClean);
            PntArrClean[iIndex].LocY = ValuePosition((CellSizeYClean * CellCountYClean / DefectSizeYClean) * SelectedLocYClean, DecimalPointClean);
            PntArrClean[iIndex].Color = Color.Blue;
            PntArrClean[iIndex].CellX = (int)SelectedCellXClean;
            PntArrClean[iIndex].CellY = (int)SelectedCellYClean;
            PntArrClean[iIndex].defectCode = cdvDefectCode.Text;
            
            pn = new Pen(Color.LightGray, PixelSizeClean * ScaleRateClean);
            Gr = pnlDefect.CreateGraphics();
            Gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            if (CurrentPixelSizeClean < PixelSizeClean || CurrentPixelSizeClean < System.Convert.ToSingle(cboPixelSize.Text))
            {
                CurrentPixelSizeClean = System.Convert.ToSingle(cboPixelSize.Text);
            }

            Gr.FillPie(new SolidBrush(PntArrClean[iIndex].Color), new Rectangle(MPCF.ToInt(SelectedLocXClean - CurrentPixelSizeClean / 2), MPCF.ToInt(SelectedLocYClean - CurrentPixelSizeClean / 2), (int)CurrentPixelSizeClean, (int)CurrentPixelSizeClean), 0, 360);
            
            bRunningClean = true;
            
        }
        
        public void DrawRectangleClean(double dLocX, double dLocY, int iWidth, int iHeight)
        {
            int iIndex;
            Graphics Gr;
            Pen pn;
            int i;
            int iLocX;
            int iLocY;

            if (PntArrClean.Length == 1)
            {
                if (PntArrClean[0].LocX < 0 || PntArrClean[0].LocY < 0)
                {
                    iIndex = 0;
                }
                else
                {
                    Array.Resize<PointArray>(ref PntArrClean, PntArrClean.Length + 1);
                    iIndex = PntArrClean.Length - 1;
                }
            }
            else
            {
                Array.Resize<PointArray>(ref PntArrClean, PntArrClean.Length + 1);
                iIndex = PntArrClean.Length - 1;
            }
            
            RectArrClean[0].LocX = ValuePosition((CellSizeXClean * CellCountXClean / DefectSizeXClean) * dLocX, DecimalPointClean);
            RectArrClean[0].LocY = ValuePosition((CellSizeYClean * CellCountYClean / DefectSizeYClean) * dLocY, DecimalPointClean);
            RectArrClean[0].BorderColor = Color.WhiteSmoke;
            RectArrClean[0].BackColor = Color.Lavender;
            RectArrClean[0].Width = (int)ValuePosition((CellSizeXClean * CellCountXClean / DefectSizeXClean) * iWidth, DecimalPointClean);
            RectArrClean[0].Height = (int)ValuePosition((CellSizeXClean * CellCountXClean / DefectSizeXClean) * iHeight, DecimalPointClean);
            
            pn = new Pen(RectArrClean[0].BorderColor, PixelSizeClean * ScaleRateClean);
            Gr = pnlCleaning.CreateGraphics();
            Gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Gr.FillRectangle(new SolidBrush(RectArrClean[0].BackColor), new Rectangle((int)dLocX, (int)dLocY, iWidth, iHeight));
            Gr.DrawRectangle(pn, new Rectangle((int)dLocX, (int)dLocY, iWidth, iHeight));
            
            //Draw Line
            pn.Color = Color.LightGray;
            for (i = 1; i < CellCountXClean; i++)
            {
                Gr.DrawLine(pn, System.Convert.ToSingle(DefectCellSizeXClean * i), 0, System.Convert.ToSingle(DefectCellSizeXClean * i), DefectSizeYClean);
            }
            
            for (i = 1; i < CellCountY; i++)
            {
                Gr.DrawLine(pn, 0, System.Convert.ToSingle(DefectCellSizeYClean * i), DefectSizeXClean, System.Convert.ToSingle(DefectCellSizeYClean * i));
            }
            
            for (i = 0; i < PntArrClean.Length; i++)
            {
                if (PntArrClean[i].LocX >= RectArrClean[0].LocX && PntArrClean[i].LocX <= RectArrClean[0].LocX + RectArrClean[0].Width && PntArrClean[i].LocY >= RectArrClean[0].LocY && PntArrClean[i].LocY <= RectArrClean[0].LocY + RectArrClean[0].Height)
                {
                    iLocX = (int)(ValuePosition((DefectSizeXClean / (CellCountXClean * CellSizeXClean)) * PntArrClean[i].LocX, DecimalPointClean));
                    iLocY = (int)(ValuePosition((DefectSizeYClean / (CellCountYClean * CellSizeYClean)) * PntArrClean[i].LocY, DecimalPointClean));
                    iLocX = (int)(iLocX - PixelSizeClean * ScaleRateClean);
                    iLocY = (int)(iLocY - PixelSizeClean * ScaleRateClean);
                    Gr.FillPie(new SolidBrush(PntArrClean[i].Color), new Rectangle(iLocX, iLocY, (int)(PixelSizeClean * ScaleRateClean * 2), (int)(PixelSizeClean * ScaleRateClean * 2)), 0, 360);
                }
            }
            
            bRunningClean = true;
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvType;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASTranToolEvent_Load(object sender, System.EventArgs e)
        {
            
            pnlTranTime.Visible = MPGO.UseBackDate();
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
            this.tabToolEvent.Controls.Remove(this.tpCleanInfo);
            this.tabToolEvent.Controls.Remove(this.tpDefectInfo);
            
            DefectSizeX = pnlDefect.Width;
            DefectSizeY = pnlDefect.Height;
            PntArr[0].LocX = 0.0;
            PntArr[0].LocY = 0.0;
            
            DefectSizeXClean = pnlCleaning.Width;
            DefectSizeYClean = pnlCleaning.Height;
            PntArrClean[0].LocX = 0.0;
            PntArrClean[0].LocY = 0.0;
            
            txtDecimalPoint.Text = "2";
            cboPixelSize.Text = "2";
            
            cdvToolID.DisplaySubItemIndex = 0;
            cdvToolEventID.DisplaySubItemIndex = 0;

            tool_type_out = new TRSNode("Tool_Type_Out");
            tool_event_out = new TRSNode("Tool_Event_Out");
            tool_out = new TRSNode("Tool_Out");
            
        }
        
        private void frmRASTranToolEvent_Activated(object sender, System.EventArgs e)
        {
            try
            {
                
                //dtpTransTime = Now
                if (LoadFlag == false)
                {
                    ClearData('1');

                    LoadFlag = true;
                }

                if (sTabSelect == TAB_CLEAN)
                {
                    bRunningClean = true;
                    DrawDefectMapClean();
                }
                else if (sTabSelect == TAB_DEFECT)
                {
                    bRunning = true;
                    DrawDefectMap();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            txtTranDateTime.Visible = ! chkTranDateTime.Checked;
            
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
        }
        
        private void cdvType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvToolEvent.Init();

            ControlInit();
            
            this.tabToolEvent.Controls.Remove(this.tpCleanInfo);
            this.tabToolEvent.Controls.Remove(this.tpDefectInfo);
            
            cdvToolID.Text = "";
            txtLastEvent.Text = "";
            txtLastEventTime.Text = "";
            cdvToolEventID.Text = "";
            
            if (cdvType.Text != "")
            {

                TRSNode in_node = new TRSNode("VIEW_TOOL_TYPE_IN");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", MPCF.Trim(cdvType.Text));

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type", in_node, ref tool_type_out) == false)
                {
                    return;
                }

                //toolTypeCnt = 0;
                //for (i = 0; i < 30; i++)
                //{
                //    if (tool_type_out.GetList("DATA_LIST")[i].GetString("PROMPT") != "")
                //    {
                //        toolTypeCnt++;
                //    }
                //}

                //TypeCnt = toolTypeCnt;

                cdvToolEvent.View_Tool_Type(tool_type_out);

            }
            
        }
        
        private void cdvType_ButtonPress(object sender, System.EventArgs e)
        {
            
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Tool Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            RASLIST.ViewToolTypeList(cdvType.GetListView, '1', 'N', 'N', null);
            
        }
        
        private void cdvToolID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            ControlInit();
            
            this.tabToolEvent.Controls.Remove(this.tpCleanInfo);
            this.tabToolEvent.Controls.Remove(this.tpDefectInfo);
            
            cdvToolEventID.Text = "";
            cdvToolEvent.ListCond_ToolEventID = "";
            
            TRSNode in_node = new TRSNode("VIEW_TOOL_IN");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TOOL_TYPE", MPCF.Trim(cdvType.Text));
            in_node.AddString("TOOL_ID", MPCF.Trim(cdvToolID.Text));

            if (MPCR.CallService("RAS", "RAS_View_Tool", in_node, ref tool_out) == false)
            {
                return;
            }

            cdvToolID.DescText = MPCF.Trim(tool_out.GetString("TOOL_DESC"));
            txtLastEvent.Text = MPCF.Trim(tool_out.GetString("LAST_TOOL_EVENT_ID"));
            txtLastEventTime.Text = MPCF.MakeDateFormat(tool_out.GetString("LAST_TRAN_TIME"));
            txtCellXCount.Text = MPCF.Trim(tool_out.GetInt("CELL_COUNT_X"));
            txtCellYCount.Text = MPCF.Trim(tool_out.GetInt("CELL_COUNT_Y"));
            txtCellXSize.Text = MPCF.Trim(tool_out.GetInt("CELL_SIZE_X"));
            txtCellYSize.Text = MPCF.Trim(tool_out.GetInt("CELL_SIZE_Y"));

            // Set last value of tool
            cdvToolEvent.View_Tool(tool_out);
        }
        
        private void cdvToolID_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvType, 1) == false)
            {
                return;
            }
            
            cdvToolID.Init();
            MPCF.InitListView(cdvToolID.GetListView);
            cdvToolID.Columns.Add("Tool ID", 50, HorizontalAlignment.Left);
            cdvToolID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolID.SelectedSubItemIndex = 0;
            cdvToolID.DisplaySubItemIndex = 0;
            cdvToolID.SelectedDescIndex = 1;
            
            if (RASLIST.ViewToolList(cdvToolID.GetListView, '2', cdvType.Text, 'N', false, null) == false)
            {
                return;
            }
            
        }
        
        private void cdvToolEventID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            // need initial
            sTabSelect = "";
            
            ControlInit();
            
            this.tabToolEvent.Controls.Remove(this.tpCleanInfo);
            this.tabToolEvent.Controls.Remove(this.tpDefectInfo);

            View_Tool_Event_Info();
        }
        
        private void cdvToolEventID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvToolEventID.Init();
            MPCF.InitListView(cdvToolEventID.GetListView);

            if (MPCF.CheckValue(cdvType, 1) == false)
            {
                return;
            }
            if (MPCF.CheckValue(cdvToolID, 1) == false)
            {
                return;
            }
            
            cdvToolEventID.Columns.Add("Tool Event", 50, HorizontalAlignment.Left);
            cdvToolEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolEventID.SelectedSubItemIndex = 0;
            cdvToolEventID.DisplaySubItemIndex = 0;
            cdvToolEventID.SelectedDescIndex = 1;
            
            if (RASLIST.ViewToolEventRelationList(cdvToolEventID.GetListView, '3', cdvToolID.Text, cdvType.Text, "", 'N', 'N', null) == false)
            {
                return;
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            if (CheckCondition("Tool_Event") == true)
            {
                if (Tool_Event('1') == true)
                {
                    if (sTabSelect == TAB_CLEAN)
                    {
                        if (spdCleanData.ActiveSheet.RowCount != 0)
                        {
                            cdvDefectCodeClean.Text = "";
                            if (View_Tool_Clean_List() == false)
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (spdDefectData.Sheets[0].RowCount != 0)
                        {
                            cdvDefectCode.Text = "";
                            if (View_Tool_Defect_List() == false)
                            {
                                return;
                            }
                        }
                    }
                    
                    cdvToolID_SelectedItemChanged(null, null);
                    btnRefresh_Click(sender, e);
                    return;
                }
            }
            
            if (sTabSelect == TAB_CLEAN)
            {
                bRunningClean = true;
                DrawDefectMapClean();
            }
            else if (sTabSelect == TAB_DEFECT)
            {
                bRunning = true;
                DrawDefectMap();
            }
            
        }
        
        //Tool Defect Tab
        
        private void btnFileOpen1_Click(System.Object sender, System.EventArgs e)
        {
            
            OpenFileDialog1.Multiselect = false;
            //OpenFileDialog1.Filter = "JPEG (*.jpg, *.jpeg)|*.jpg;*.jpeg|GIF (*.gif)|*.gif|Bitmap (*.bmp)|*.bmp|TIFF (*.tif, *.tiff)|*.tif;*.tiff|PNG (*.png)|*.png|All files (*.*)|*.*;"
            OpenFileDialog1.Filter = "Text File(*.txt)|*.txt|Excel File (*.xls)|*.xls|Power Point File(*.ppt)|*.ppt|Word File (*.doc)|*.doc|Adobe File(*.pdf)|*.pdf|All files (*.*)|*.*;";
            
            if (OpenFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtAttachFile1.Text = OpenFileDialog1.FileNames[0];
            }
            
        }
        
        private void txtXYZ_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    if (e.KeyChar == (char)46)
                    {
                        string sTmp = ((TextBox)(sender)).Text;
                        if(sTmp.IndexOf(".") >= 0)
                        {
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        e.Handled = true;
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
            RASLIST.ViewResourceList(cdvResID.GetListView, false);
        }
        
        private void cdvSubResID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvSubResID.Init();
            MPCF.InitListView(cdvSubResID.GetListView);
            cdvSubResID.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvSubResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSubResID.SelectedSubItemIndex = 0;
            int temp_int = 0;

            RASLIST.ViewSubResourceList(cdvSubResID.GetListView, '1', cdvResID.Text, MPGV.gsFactory, "", "", false, null, ref temp_int);
        }
        
        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {
            cdvFlow.Init();
            MPCF.InitListView(cdvFlow.GetListView);
            cdvFlow.Columns.Add("Flow", 50, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvFlow.SelectedSubItemIndex = 0;
            WIPLIST.ViewFlowList(cdvFlow.GetListView, '1', "", 0, "", null, "");
        }
        
        private void cdvOper_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOper.Init();
            MPCF.InitListView(cdvOper.GetListView);
            cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOper.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvOper.GetListView, '2', "",0,  cdvFlow.Text, "", null, "");
        }
        
        private void cdvDefectCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvDefectCode.Init();
            MPCF.InitListView(cdvDefectCode.GetListView);
            cdvDefectCode.Columns.Add("Tool Defect Code", 150, HorizontalAlignment.Left);
            cdvDefectCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvDefectCode.Columns.Add("Color", 0, HorizontalAlignment.Left);
            cdvDefectCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvDefectCode.GetListView, '1', MPGC.MP_RAS_TOOL_DEFECT);
            cdvDefectCode.AddEmptyRow(1);
        }

        private void cdvDefectCode_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (cdvDefectCode.SelectedItem.SubItems.Count < 3) return;

                cdvDefectCode.Tag = cdvDefectCode.SelectedItem.SubItems[2].Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cboPixelSize_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (MPCF.CheckNumeric(cboPixelSize.Text) == true)
            {
                CurrentPixelSize = MPCF.ToInt(cboPixelSize.Text) * CurrentPixelSize / PixelSize;
                PixelSize = MPCF.ToInt(cboPixelSize.Text);
            }
        }
        
        private void spdDefectData_CellClick(System.Object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int i;
            
            if (e.ColumnHeader == true)
            {
                spdCleanData.ActiveSheet.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Cell;
                if (e.Column == 0)
                {
                    if (spdDefectData.Sheets[0].ColumnHeader.Cells[0, e.Column].Value != null &&
                        Convert.ToBoolean(spdDefectData.Sheets[0].ColumnHeader.Cells[0, e.Column].Value) == true)
                    {
                        spdDefectData.Sheets[0].ColumnHeader.Cells[0, e.Column].Value = false;
                        for (i = iColData; i < spdDefectData.Sheets[0].RowCount; i++)
                        {
                            spdDefectData.Sheets[0].Cells[i, 0].Value = false;
                        }
                    }
                    else
                    {
                        spdDefectData.Sheets[0].ColumnHeader.Cells[0, e.Column].Value = true;
                        for (i = iColData; i < spdDefectData.Sheets[0].RowCount; i++)
                        {
                            spdDefectData.Sheets[0].Cells[i, 0].Value = true;
                        }
                    }
                }
            }
            else
            {
                spdDefectData.Sheets[0].SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
                
                cdvDefectCode.Text = MPCF.Trim(spdDefectData.Sheets[0].Cells[e.Row, 1].Value);
                txtCellX.Text = MPCF.Trim(spdDefectData.Sheets[0].Cells[e.Row, 2].Value);
                txtCellY.Text = MPCF.Trim(spdDefectData.Sheets[0].Cells[e.Row, 3].Value);
                txtCellZ.Text = MPCF.Trim(spdDefectData.Sheets[0].Cells[e.Row, 4].Value);
                txtLocX.Text = MPCF.Trim(spdDefectData.Sheets[0].Cells[e.Row, 5].Value);
                txtLocY.Text = MPCF.Trim(spdDefectData.Sheets[0].Cells[e.Row, 6].Value);
                txtLocZ.Text = MPCF.Trim(spdDefectData.Sheets[0].Cells[e.Row, 7].Value);
            }
        }
        
        private void HeScroll_Scroll(System.Object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            pnlDefect.Left = 0 - pnlDefect.Width / 100 * HeScroll.Value;
            bRunning = true;
            DrawDefectMap();
        }
        
        private void VeScroll_Scroll(System.Object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            pnlDefect.Top = 0 - pnlDefect.Height / 100 * VeScroll.Value;
            bRunning = true;
            DrawDefectMap();
        }
        
        private void btnDefectView_Click(System.Object sender, System.EventArgs e)
        {
            
            pnlDefect.Visible = true;
            if (View_Tool_Defect_List() == false)
            {
                return;
            }
            btnRefresh_Click(sender, e);
        }
        
        private void btnDefectMinus_Click(System.Object sender, System.EventArgs e)
        {
            
            DefectMinus();
            
        }
        
        private void btnLens_Click(System.Object sender, System.EventArgs e)
        {
            if (sTabSelect == TAB_DEFECT)
            {
                bRunning = true;
                ZoomIn(1, 0.1F);
            }
            else
            {
                bRunningClean = true;
                ZoomInClean(1, 0.1F);
            }
        }
        
        private void btnPoint_Click(System.Object sender, System.EventArgs e)
        {
            if (sTabSelect == TAB_DEFECT)
            {
                bRunning = true;
                ZoomOut(1, 0.1F);
            }
            else
            {
                bRunningClean = true;
                ZoomOutClean(1, 0.1F);
            }
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            if (sTabSelect == TAB_DEFECT)
            {
                pnlDefect.Top = 0;
                pnlDefect.Left = 0;
                RectArr[0].LocX = 0.0;
                RectArr[0].LocY = 0.0;
                VeScroll.Value = 0;
                HeScroll.Value = 0;
                bRunning = true;
                ZoomOut(2, 1);
                DrawDefectMap();
            }
            else
            {
                pnlCleaning.Top = 0;
                pnlCleaning.Left = 0;
                RectArrClean[0].LocX = 0.0;
                RectArrClean[0].LocY = 0.0;
                VcScroll.Value = 0;
                HcScroll.Value = 0;
                bRunningClean = true;
                ZoomOutClean(2, 1);
                DrawDefectMapClean();
            }
        }
        
        private void btnHands_Click(System.Object sender, System.EventArgs e)
        {
            if (sTabSelect == TAB_CLEAN)
            {
                if (pnlCleaning.Cursor == Cursors.Hand)
                {
                    pnlCleaning.Cursor = Cursors.Default;
                }
                else
                {
                    pnlCleaning.Cursor = Cursors.Hand;
                }
            }
            else
            {
                if (pnlDefect.Cursor == Cursors.Hand)
                {
                    pnlDefect.Cursor = Cursors.Default;
                }
                else
                {
                    pnlDefect.Cursor = Cursors.Hand;
                }
            }
        }
        
        private void btnLocDrag_Click(System.Object sender, System.EventArgs e)
        {
            if (sTabSelect == TAB_CLEAN)
            {
                if (rdoData.Checked == true)
                {
                    pnlCleaning.Cursor = Cursors.Cross;
                }
            }
            else
            {
                pnlDefect.Cursor = Cursors.Cross;
            }
        }
        
        private void btnDefectClick_Click(System.Object sender, System.EventArgs e)
        {
            if (sTabSelect == TAB_CLEAN)
            {
                RectArrClean[0].LocX = 0.0;
                RectArrClean[0].LocY = 0.0;
                pnlCleaning.Cursor = Cursors.Default;
            }
            else
            {
                RectArr[0].LocX = 0.0;
                RectArr[0].LocY = 0.0;
                pnlDefect.Cursor = Cursors.Default;
            }
        }
        
        private void pnlDefect_Resize(System.Object sender, System.EventArgs e)
        {
            DefectSizeX = pnlDefect.Width;
            DefectSizeY = pnlDefect.Height;
        }
        
        private void pnlDefect_Click(System.Object sender, System.EventArgs e)
        {
        }
        
        private void pnlDefect_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlDefect.Cursor == Cursors.Default)
            {
                
                if (MPCF.CheckValue(cdvDefectCode, 1) == false)
                {
                    DrawDefectMap();
                    return;
                }
                
                SelectedLocX = e.X;
                SelectedLocY = e.Y;
                SelectedCellX = SelectedLocX / DefectCellSizeX;
                //2014.03.26 DefectCellSizeX°¡ 0ÀÏ°æ¿ì SelectedCellX°ªÀÌ -2147483648.0À¸·Î °è»êµÇ¾î °ªÀ» 0À¸·Î ÀüÈ¯Ã³¸®ÇÔ
                if (DefectCellSizeX == 0)
                {
                    SelectedCellX = 0;
                }
                SelectedCellY = SelectedLocY / DefectCellSizeY;
                //2014.03.26 DefectCellSizeY°¡ 0ÀÏ°æ¿ì SelectedCellY°ªÀÌ -2147483648.0À¸·Î °è»êµÇ¾î °ªÀ» 0À¸·Î ÀüÈ¯Ã³¸®ÇÔ
                if (DefectCellSizeY == 0)
                {
                    SelectedCellY = 0;
                }

                DrawPoint();

                txtCellX.Text = MPCF.Trim(SelectedCellX);
                txtCellY.Text = MPCF.Trim(SelectedCellY);
                txtCellZ.Text = "0";
                txtLocX.Text = MPCF.Trim(ValuePosition((CellSizeX * CellCountX / DefectSizeX) * e.X, DecimalPoint));
                txtLocY.Text = MPCF.Trim(ValuePosition((CellSizeY * CellCountY / DefectSizeY) * e.Y, DecimalPoint));
                txtLocZ.Text = "0";
                
                int i;
                
                i = spdDefectData.Sheets[0].RowCount;
                
                spdDefectData.Sheets[0].RowCount = i + 1;
                
                spdDefectData.Sheets[0].Cells[i, 0].Value = true;
                spdDefectData.Sheets[0].Cells[i, 1].Value = cdvDefectCode.Text;
                spdDefectData.Sheets[0].Cells[i, 2].Value = txtCellX.Text;
                spdDefectData.Sheets[0].Cells[i, 3].Value = txtCellY.Text;
                spdDefectData.Sheets[0].Cells[i, 4].Value = txtCellZ.Text;
                spdDefectData.Sheets[0].Cells[i, 5].Value = txtLocX.Text;
                spdDefectData.Sheets[0].Cells[i, 6].Value = txtLocY.Text;
                spdDefectData.Sheets[0].Cells[i, 7].Value = txtLocZ.Text;
                spdDefectData.Sheets[0].Cells[i, 8].Value = "D";
                spdDefectData.Sheets[0].Rows[i].ForeColor = System.Drawing.Color.Black;
                spdDefectData.Sheets[0].SetActiveCell(i, 0);
                
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlDefect.Cursor == Cursors.Hand)
            {
                dLocX = e.X;
                dLocY = e.Y;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlDefect.Cursor == Cursors.Cross)
            {
                dLocX = e.X;
                dLocY = e.Y;
            }
            
        }
        
        private void pnlDefect_MouseMove(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            double iLocX = 0.0;
            double iLocY = 0.0;
            int iWidth;
            int iHeight;
            int i;
            
            if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlDefect.Cursor == Cursors.Hand)
            {
                pnlDefect.Left = (int)(pnlDefect.Left + (e.X - dLocX));
                pnlDefect.Top = (int)(pnlDefect.Top + (e.Y - dLocY));
                bRunning = true;
                DrawDefectMap();
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlDefect.Cursor == Cursors.Cross)
            {
                
                bRunning = true;
                DrawDefectMap();
                
                iLocX = dLocX < e.X ? dLocX : e.X;
                iLocY = dLocY < e.Y ? dLocY : e.Y;
                iWidth = (int)(Math.Abs(dLocX - e.X));
                iHeight = (int)(Math.Abs(dLocY - e.Y));
                
                DrawRectangle(iLocX, iLocY, iWidth, iHeight);
                
            }
            else
            {
                iLocX = ValuePosition((CellSizeX * CellCountX / DefectSizeX) * e.X, DecimalPoint);
                iLocY = ValuePosition((CellSizeY * CellCountY / DefectSizeY) * e.Y, DecimalPoint);

                lblLoc2.Text = MPCF.Trim(iLocX) + "," + MPCF.Trim(iLocY);
                if (DefectCellSizeX > 0 && DefectCellSizeY > 0)
                {
                    lblCell2.Text = MPCF.Trim(e.X / DefectCellSizeX) + "," + MPCF.Trim(e.Y / DefectCellSizeY);
                }
            }
            
            lbldecode.Text = "";
            
            for (i = 0; i < PntArr.Length; i++)
            {
                if (PntArr[i].LocX == iLocX && PntArr[i].LocY == iLocY)
                {
                    lbldecode.Text = PntArr[i].defectCode;
                }
            }
            
        }
        
        private void pnlDefect_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlDefect.Cursor == Cursors.Cross)
            {
                if (RectArr[0].LocX > 0  || RectArr[0].LocY > 0)
                {
                    int i;
                    double minLocX;
                    double minLocY;
                    double maxLocX;
                    double maxLocY;
                    double tempLocX;
                    double tempLocY;
                    
                    minLocX = RectArr[0].LocX;
                    minLocY = RectArr[0].LocY;
                    maxLocX = RectArr[0].LocX + RectArr[0].Width;
                    maxLocY = RectArr[0].LocY + RectArr[0].Height;
                    
                    for (i = 0; i < spdDefectData.Sheets[0].RowCount; i++)
                    {
                        tempLocX = MPCF.ToDbl(spdDefectData.Sheets[0].Cells[i, 5].Value);
                        tempLocY = MPCF.ToDbl(spdDefectData.Sheets[0].Cells[i, 6].Value);

                        if (MPCF.Trim(spdDefectData.Sheets[0].Cells[i, 8].Value) == "D")
                        {
                            spdDefectData.Sheets[0].Cells[i, 0].Value = true;
                        }
                        
                        if (tempLocX >= minLocX && tempLocX <= maxLocX)
                        {
                            if (tempLocY >= minLocY && tempLocY <= maxLocY)
                            {
                                if (MPCF.Trim(spdDefectData.Sheets[0].Cells[i, 8].Value) == "D")
                                {
                                    spdDefectData.Sheets[0].Cells[i, 0].Value = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        
        //Tool Clean Tab
        
        private void cdvDefectCodeClean_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvDefectCodeClean.Init();
            MPCF.InitListView(cdvDefectCodeClean.GetListView);
            cdvDefectCodeClean.Columns.Add("Tool Defect Code", 150, HorizontalAlignment.Left);
            cdvDefectCodeClean.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvDefectCodeClean.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvDefectCodeClean.GetListView, '1', MPGC.MP_RAS_TOOL_DEFECT);
            cdvDefectCodeClean.AddEmptyRow(1);
        }
        
        private void btnCleanView_Click(System.Object sender, System.EventArgs e)
        {
            pnlCleaning.Visible = true;
            if (View_Tool_Clean_List() == false)
            {
                return;
            }
            //btnRefresh_Click(sender, e)
        }
        
        private void spdCleanData_CellClick(System.Object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            int i;
            
            if (e.ColumnHeader == true)
            {
                spdCleanData.ActiveSheet.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Cell;
                if (e.Column == 0)
                {
                    if (spdCleanData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Value != null &&
                        Convert.ToBoolean(spdCleanData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Value) == true)
                    {
                        spdCleanData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Value = false;
                        for (i = 0; i < spdCleanData.ActiveSheet.RowCount; i++)
                        {
                            spdCleanData.ActiveSheet.Cells[i, 0].Value = false;
                        }
                    }
                    else
                    {
                        spdCleanData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Value = true;
                        for (i = 0; i < spdCleanData.ActiveSheet.RowCount; i++)
                        {
                            spdCleanData.ActiveSheet.Cells[i, 0].Value = true;
                        }
                    }
                }
            }
            else
            {
                spdCleanData.ActiveSheet.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
                cdvDefectCodeClean.Text = MPCF.Trim(spdCleanData.ActiveSheet.Cells[e.Row, 1].Value);
            }
            
        }
        
        private void cdvDefectCodeClean_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (rdoDefectCode.Checked == true)
            {
                int i;
                
                for (i = 0; i < spdCleanData.ActiveSheet.RowCount; i++)
                {
                    if (cdvDefectCodeClean.Text == MPCF.Trim(spdCleanData.ActiveSheet.Cells[i, 1].Value))
                    {
                        spdCleanData.ActiveSheet.Cells[i, 0].Value = true;
                    }
                    else
                    {
                        spdCleanData.ActiveSheet.Cells[i, 0].Value = false;
                    }
                }
            }
            
        }
        
        private void pnlCleaning_Resize(System.Object sender, System.EventArgs e)
        {
            DefectSizeXClean = pnlCleaning.Width;
            DefectSizeYClean = pnlCleaning.Height;
        }
        
        private void pnlCleaning_Click(System.Object sender, System.EventArgs e)
        {
        }
        
        private void pnlCleaning_MouseMove(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            double iLocX = 0.0;
            double iLocY = 0.0;
            int iWidth;
            int iHeight;
            int i;
            
            if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlCleaning.Cursor == Cursors.Hand)
            {
                pnlCleaning.Left = (int)(pnlCleaning.Left + (e.X - dLocXClean));
                pnlCleaning.Top = (int)(pnlCleaning.Top + (e.Y - dLocYClean));
                bRunningClean = true;
                DrawDefectMapClean();
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlCleaning.Cursor == Cursors.Cross)
            {
                
                bRunningClean = true;
                DrawDefectMapClean();
                
                iLocX = dLocXClean < e.X ? dLocXClean : e.X;
                iLocY = dLocYClean < e.Y ? dLocYClean : e.Y;
                iWidth = (int)Math.Abs(dLocXClean - e.X);
                iHeight = (int)Math.Abs(dLocYClean - e.Y);
                
                DrawRectangleClean(iLocX, iLocY, iWidth, iHeight);
                
            }
            else
            {
                iLocX = ValuePosition((CellSizeXClean * CellCountX / DefectSizeXClean) * e.X, DecimalPointClean);
                iLocY = ValuePosition((CellSizeYClean * CellCountY / DefectSizeYClean) * e.Y, DecimalPointClean);

                lblLoc2Clean.Text = MPCF.Trim(iLocX) + "," + MPCF.Trim(iLocY);
                if (DefectCellSizeXClean > 0 && DefectCellSizeYClean > 0)
                {
                    lblCell2Clean.Text = MPCF.Trim(e.X / DefectCellSizeXClean) + "," + MPCF.Trim(e.Y / DefectCellSizeYClean);
                }
            }
            
            lbldecodeClean.Text = "";
            
            for (i = 0; i < PntArrClean.Length; i++)
            {
                if (PntArrClean[i].LocX == iLocX && PntArrClean[i].LocY == iLocY)
                {
                    lbldecodeClean.Text = PntArrClean[i].defectCode;
                }
            }
            
        }
        
        private void pnlCleaning_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlCleaning.Cursor == Cursors.Cross)
            {
                if (RectArrClean[0].LocX > 0 || RectArrClean[0].LocY > 0)
                {
                    
                    int i;
                    double minLocX;
                    double minLocY;
                    double maxLocX;
                    double maxLocY;
                    double tempLocX;
                    double tempLocY;
                    
                    minLocX = RectArrClean[0].LocX;
                    minLocY = RectArrClean[0].LocY;
                    maxLocX = RectArrClean[0].LocX + RectArrClean[0].Width;
                    maxLocY = RectArrClean[0].LocY + RectArrClean[0].Height;
                    
                    for (i = 0; i < spdCleanData.ActiveSheet.RowCount; i++)
                    {
                        tempLocX = MPCF.ToDbl(spdCleanData.ActiveSheet.Cells[i, 5].Value);
                        tempLocY = MPCF.ToDbl(spdCleanData.ActiveSheet.Cells[i, 6].Value);
                        
                        spdCleanData.ActiveSheet.Cells[i, 0].Value = false;
                        
                        if (tempLocX >= minLocX && tempLocX <= maxLocX)
                        {
                            if (tempLocY >= minLocY && tempLocY <= maxLocY)
                            {
                                spdCleanData.ActiveSheet.Cells[i, 0].Value = true;
                            }
                        }
                    }
                    
                }
            }
        }
        
        private void pnlCleaning_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
            if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlCleaning.Cursor == Cursors.Default)
            {
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlCleaning.Cursor == Cursors.Hand)
            {
                dLocXClean = e.X;
                dLocYClean = e.Y;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left && pnlCleaning.Cursor == Cursors.Cross)
            {
                dLocXClean = e.X;
                dLocYClean = e.Y;
            }
            
        }
        
        private void HcScroll_Scroll(System.Object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            pnlCleaning.Left = 0 - pnlCleaning.Width / 100 * HcScroll.Value;
            bRunningClean = true;
            DrawDefectMapClean();
        }
        
        private void VcScroll_Scroll(System.Object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            pnlCleaning.Top = 0 - pnlCleaning.Height / 100 * VcScroll.Value;
            bRunningClean = true;
            DrawDefectMapClean();
        }
        
        private void rdoAll_Click(object sender, System.EventArgs e)
        {
            int i;
            
            spdCleanData.ActiveSheet.ColumnHeader.Cells[0, 0].Value = true;
            for (i = 0; i < spdCleanData.ActiveSheet.RowCount; i++)
            {
                spdCleanData.ActiveSheet.Cells[i, 0].Value = true;
            }
            pnlCleaning.Cursor = Cursors.Default;
        }
        
        private void rdoDefectCode_Click(object sender, System.EventArgs e)
        {
            int i;
            
            for (i = 0; i < spdCleanData.ActiveSheet.RowCount; i++)
            {
                if (cdvDefectCodeClean.Text == MPCF.Trim(spdCleanData.ActiveSheet.Cells[i, 1].Value))
                {
                    spdCleanData.ActiveSheet.Cells[i, 0].Value = true;
                }
                else
                {
                    spdCleanData.ActiveSheet.Cells[i, 0].Value = false;
                }
            }
            pnlCleaning.Cursor = Cursors.Default;
        }
        
        private void rdoData_Click(object sender, System.EventArgs e)
        {
            int i;
            
            spdCleanData.ActiveSheet.ColumnHeader.Cells[0, 0].Value = false;
            for (i = 0; i < spdCleanData.ActiveSheet.RowCount; i++)
            {
                spdCleanData.ActiveSheet.Cells[i, 0].Value = false;
            }
            pnlCleaning.Cursor = Cursors.Cross;
        }
        
        private void tabToolEvent_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (tabToolEvent.TabPages[tabToolEvent.SelectedIndex].Name == tpToolInfo.Name)
            {
                grpPnlControl.Visible = false;
            }
            else
            {
                grpPnlControl.Visible = true;
                if (sTabSelect == TAB_CLEAN)
                {
                    btnDefectClick.Enabled = false;
                    bRunningClean = true;
                }
                else if (sTabSelect == TAB_DEFECT)
                {
                    MPCR.ChangeControlEnabled(this, btnDefectClick, true);
                    bRunning = true;
                }
                txtDecimalPoint.Text = "2";
                cboPixelSize.Text = "2";
            }
        }
        
        private void frmRASTranToolEvent_LostFocus(object sender, System.EventArgs e)
        {
            if (sTabSelect == TAB_CLEAN)
            {
                bRunningClean = true;
                DrawDefectMapClean();
            }
            else if (sTabSelect == TAB_DEFECT)
            {
                bRunning = true;
                DrawDefectMap();
            }
        }
        
        private void tabToolEvent_Click(object sender, System.EventArgs e)
        {
            if (sTabSelect == TAB_CLEAN)
            {
                bRunningClean = true;
                DrawDefectMapClean();
            }
            else if (sTabSelect == TAB_DEFECT)
            {
                bRunning = true;
                DrawDefectMap();
            }
        }
        
        private void btnLens_MouseEnter(object sender, System.EventArgs e)
        {
            ttXY.SetToolTip(btnLens, "Extension"); //?•ë?
        }
        
        private void btnPoint_MouseEnter(object sender, System.EventArgs e)
        {
            ttXY.SetToolTip(btnPoint, "Reduction"); //ì¶•ì†Œ
        }
        
        private void btnHands_MouseEnter(object sender, System.EventArgs e)
        {
            ttXY.SetToolTip(btnHands, "Move"); //ì¢Œí‘œ?´ë™
        }
        
        private void btnLocDrag_MouseEnter(object sender, System.EventArgs e)
        {
            ttXY.SetToolTip(btnLocDrag, "Drag"); //ì¢Œí‘œì§€??
        }
        
        private void btnDefectClick_MouseEnter(object sender, System.EventArgs e)
        {
            ttXY.SetToolTip(btnDefectClick, "PointClick"); //ì¢Œí‘œê°’ìƒ??
        }
        
        private void btnRefresh_MouseEnter(object sender, System.EventArgs e)
        {
            ttXY.SetToolTip(btnRefresh, "Refresh"); //?ˆë¡œê³ ì¹¨
        }
        
        private void txtDecimalPoint_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
        }
        
        private void frmRASTranToolEvent_Resize(object sender, System.EventArgs e)
        {
            if (sTabSelect == TAB_CLEAN)
            {
                bRunningClean = true;
                DrawDefectMapClean();
            }
            else if (sTabSelect == TAB_DEFECT)
            {
                bRunning = true;
                DrawDefectMap();
            }
        }
        
        
    }
    //#End If
}
