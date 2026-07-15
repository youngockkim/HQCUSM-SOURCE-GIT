
using Miracom.MsgHandler;
using System.Data;
using Miracom.CliFrx;
using System.Collections;

using System.Diagnostics;
using System;
using System.Windows.Forms;



namespace Miracom.MESCore
{
    public class frmLotListbyDispatcher : System.Windows.Forms.Form
    {
        
        #if _RTD
        
        #region " Windows Form auto generated code "
        
        public frmLotListbyDispatcher()
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
        



        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblFormTitle;
        protected System.Windows.Forms.Panel pnlBottom;
        protected System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlDsp;
        private System.Windows.Forms.GroupBox grpDsp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblDsp;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtDspID;
        private System.Windows.Forms.Panel pnlLot;
        private System.Windows.Forms.Panel pnlResource;
        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private System.Windows.Forms.ColumnHeader colLotID;
        private System.Windows.Forms.ColumnHeader colMaterial;
        private System.Windows.Forms.ColumnHeader colFlow;
        private System.Windows.Forms.ColumnHeader colOperation;
        private System.Windows.Forms.ColumnHeader colQty1;
        private System.Windows.Forms.ColumnHeader colQty2;
        private System.Windows.Forms.ColumnHeader colQty3;
        private System.Windows.Forms.ColumnHeader colLotType;
        private System.Windows.Forms.ColumnHeader colOwnerCode;
        private System.Windows.Forms.ColumnHeader colCreateCode;
        private System.Windows.Forms.ColumnHeader colPriority;
        private System.Windows.Forms.ColumnHeader colLotStatus;
        private System.Windows.Forms.ColumnHeader colOrgDueTime;
        private System.Windows.Forms.ColumnHeader colSchDueTime;
        private System.Windows.Forms.ColumnHeader colOperInTime;
        private Miracom.UI.Controls.MCListView.MCListView lisResourceList;
        private System.Windows.Forms.ColumnHeader colRes;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colUpDown;
        private System.Windows.Forms.ColumnHeader colPriSts;
        private System.Windows.Forms.ColumnHeader colLastEvent;
        private System.Windows.Forms.ColumnHeader colLastEventTime;
        private System.Windows.Forms.ColumnHeader colLastStartTime;
        private System.Windows.Forms.ColumnHeader colLastEndTime;
        private System.Windows.Forms.ColumnHeader colArea;
        private System.Windows.Forms.ColumnHeader colSubArea;
        private System.Windows.Forms.Splitter splMid;
        protected System.Windows.Forms.Button btnEnd;
        protected System.Windows.Forms.Button btnMove;
        protected System.Windows.Forms.Button btnSkip;
        protected System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ColumnHeader colLotScoreText;
        private ColumnHeader colMatVer;
        private ColumnHeader colFlowSeqNum;
        private Timer tmrTimer;
        private CheckBox chkAutoRefresh;
        private ColumnHeader colUnSelect;
        private Panel pnlLotBottom;
        private Label lblTotLotQty;
        private Label lblTotalLot2;
        private Label lblTotLotCnt;
        private Label lblTotalLot1;
        private Panel pnlResBottom;
        private Label lblTotResCnt;
        private Label lblTotRes;
        private NumericUpDown numRefreshSec;
        private Label lblSec;
        private Button btnLotExcel;
        private Button btnLotRefresh;
        private Button btnResExcel;
        private Button btnResRefresh;
        private ColumnHeader colUnselected;
        private ColumnHeader colRuleID;
        private ColumnHeader colDspReason;
        private ColumnHeader colResRule;
        private ColumnHeader colResDspReason;
        private ColumnHeader colCapable;
        private ColumnHeader colUnselectReason;
        private ColumnHeader colCapableReason;
        private ColumnHeader colCmf1;
        private ColumnHeader colCmf2;
        private ColumnHeader colCmf3;
        private ColumnHeader colCmf4;
        private ColumnHeader colCmf5;
        private ColumnHeader colCmf6;
        private ColumnHeader colCmf7;
        private ColumnHeader colCmf8;
        private ColumnHeader colCmf9;
        private ColumnHeader colCmf10;
        private ColumnHeader colCapable1;
        private ColumnHeader colUnselectReason1;
        private ColumnHeader colCapableReason1;
        private ColumnHeader colxCmf1;
        private ColumnHeader colxCmf2;
        private ColumnHeader colxCmf3;
        private ColumnHeader colxCmf4;
        private ColumnHeader colxCmf5;
        private ColumnHeader colxCmf6;
        private ColumnHeader colxCmf7;
        private ColumnHeader colxCmf8;
        private ColumnHeader colxCmf9;
        private ColumnHeader colxCmf10;
        private ColumnHeader colLastTranTime;
        private ColumnHeader colResvRes;
        private System.Windows.Forms.ColumnHeader colResScoreText;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLotListbyDispatcher));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblSec = new System.Windows.Forms.Label();
            this.numRefreshSec = new System.Windows.Forms.NumericUpDown();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlDsp = new System.Windows.Forms.Panel();
            this.grpDsp = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblDsp = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtDspID = new System.Windows.Forms.TextBox();
            this.pnlLot = new System.Windows.Forms.Panel();
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowSeqNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOwnerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResvRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastTranTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrgDueTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSchDueTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperInTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotScoreText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnSelect = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCapable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRuleID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDspReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnselectReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCapableReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.pnlLotBottom = new System.Windows.Forms.Panel();
            this.btnLotExcel = new System.Windows.Forms.Button();
            this.btnLotRefresh = new System.Windows.Forms.Button();
            this.lblTotLotQty = new System.Windows.Forms.Label();
            this.lblTotalLot2 = new System.Windows.Forms.Label();
            this.lblTotLotCnt = new System.Windows.Forms.Label();
            this.lblTotalLot1 = new System.Windows.Forms.Label();
            this.splMid = new System.Windows.Forms.Splitter();
            this.pnlResource = new System.Windows.Forms.Panel();
            this.lisResourceList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colRes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpDown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPriSts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEvent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEventTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResScoreText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnselected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCapable1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResRule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResDspReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnselectReason1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCapableReason1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxCmf1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxCmf2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxCmf3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxCmf4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxCmf5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxCmf6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxCmf7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxCmf8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxCmf9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colxCmf10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlResBottom = new System.Windows.Forms.Panel();
            this.btnResExcel = new System.Windows.Forms.Button();
            this.btnResRefresh = new System.Windows.Forms.Button();
            this.lblTotResCnt = new System.Windows.Forms.Label();
            this.lblTotRes = new System.Windows.Forms.Label();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshSec)).BeginInit();
            this.pnlDsp.SuspendLayout();
            this.grpDsp.SuspendLayout();
            this.pnlLot.SuspendLayout();
            this.pnlLotBottom.SuspendLayout();
            this.pnlResource.SuspendLayout();
            this.pnlResBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblFormTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
            this.pnlTop.Size = new System.Drawing.Size(742, 22);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.Visible = false;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFormTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFormTitle.Location = new System.Drawing.Point(2, 2);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(738, 18);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "View Dispatcher Simulation Result";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFormTitle.DoubleClick += new System.EventHandler(this.lblFormTitle_DoubleClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblSec);
            this.pnlBottom.Controls.Add(this.numRefreshSec);
            this.pnlBottom.Controls.Add(this.chkAutoRefresh);
            this.pnlBottom.Controls.Add(this.btnStart);
            this.pnlBottom.Controls.Add(this.btnSkip);
            this.pnlBottom.Controls.Add(this.btnMove);
            this.pnlBottom.Controls.Add(this.btnEnd);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 5;
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Location = new System.Drawing.Point(198, 14);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(26, 13);
            this.lblSec.TabIndex = 2;
            this.lblSec.Text = "Sec";
            // 
            // numRefreshSec
            // 
            this.numRefreshSec.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRefreshSec.Location = new System.Drawing.Point(120, 10);
            this.numRefreshSec.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numRefreshSec.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRefreshSec.Name = "numRefreshSec";
            this.numRefreshSec.Size = new System.Drawing.Size(78, 20);
            this.numRefreshSec.TabIndex = 1;
            this.numRefreshSec.ThousandsSeparator = true;
            this.numRefreshSec.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRefreshSec.ValueChanged += new System.EventHandler(this.numRefreshSec_ValueChanged);
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAutoRefresh.Location = new System.Drawing.Point(19, 11);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(95, 18);
            this.chkAutoRefresh.TabIndex = 0;
            this.chkAutoRefresh.Text = "Auto Refresh";
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStart.Location = new System.Drawing.Point(284, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(88, 26);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkip.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSkip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSkip.Location = new System.Drawing.Point(557, 7);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(88, 26);
            this.btnSkip.TabIndex = 6;
            this.btnSkip.Text = "Skip";
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMove.Location = new System.Drawing.Point(466, 7);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(88, 26);
            this.btnMove.TabIndex = 5;
            this.btnMove.Text = "Move";
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEnd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnd.Location = new System.Drawing.Point(375, 7);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(88, 26);
            this.btnEnd.TabIndex = 4;
            this.btnEnd.Text = "End";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(648, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlDsp
            // 
            this.pnlDsp.Controls.Add(this.grpDsp);
            this.pnlDsp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDsp.Location = new System.Drawing.Point(0, 22);
            this.pnlDsp.Name = "pnlDsp";
            this.pnlDsp.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlDsp.Size = new System.Drawing.Size(742, 68);
            this.pnlDsp.TabIndex = 1;
            // 
            // grpDsp
            // 
            this.grpDsp.Controls.Add(this.lblDesc);
            this.grpDsp.Controls.Add(this.lblDsp);
            this.grpDsp.Controls.Add(this.txtDesc);
            this.grpDsp.Controls.Add(this.txtDspID);
            this.grpDsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDsp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDsp.Location = new System.Drawing.Point(3, 0);
            this.grpDsp.Name = "grpDsp";
            this.grpDsp.Size = new System.Drawing.Size(736, 68);
            this.grpDsp.TabIndex = 0;
            this.grpDsp.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 42);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 14);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDsp
            // 
            this.lblDsp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDsp.Location = new System.Drawing.Point(15, 19);
            this.lblDsp.Name = "lblDsp";
            this.lblDsp.Size = new System.Drawing.Size(100, 14);
            this.lblDsp.TabIndex = 0;
            this.lblDsp.Text = "Dispatcher ID";
            this.lblDsp.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(604, 20);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TabStop = false;
            // 
            // txtDspID
            // 
            this.txtDspID.Location = new System.Drawing.Point(120, 16);
            this.txtDspID.MaxLength = 20;
            this.txtDspID.Name = "txtDspID";
            this.txtDspID.ReadOnly = true;
            this.txtDspID.Size = new System.Drawing.Size(200, 20);
            this.txtDspID.TabIndex = 1;
            this.txtDspID.TabStop = false;
            // 
            // pnlLot
            // 
            this.pnlLot.Controls.Add(this.lisLotList);
            this.pnlLot.Controls.Add(this.pnlLotBottom);
            this.pnlLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLot.Location = new System.Drawing.Point(0, 90);
            this.pnlLot.Name = "pnlLot";
            this.pnlLot.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlLot.Size = new System.Drawing.Size(742, 200);
            this.pnlLot.TabIndex = 2;
            // 
            // lisLotList
            // 
            this.lisLotList.AllowColumnReorder = true;
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLotID,
            this.colMaterial,
            this.colMatVer,
            this.colFlow,
            this.colFlowSeqNum,
            this.colOperation,
            this.colQty1,
            this.colQty2,
            this.colQty3,
            this.colLotType,
            this.colOwnerCode,
            this.colCreateCode,
            this.colPriority,
            this.colLotStatus,
            this.colResvRes,
            this.colLastTranTime,
            this.colOrgDueTime,
            this.colSchDueTime,
            this.colOperInTime,
            this.colLotScoreText,
            this.colUnSelect,
            this.colCapable,
            this.colRuleID,
            this.colDspReason,
            this.colUnselectReason,
            this.colCapableReason,
            this.colCmf1,
            this.colCmf2,
            this.colCmf3,
            this.colCmf4,
            this.colCmf5,
            this.colCmf6,
            this.colCmf7,
            this.colCmf8,
            this.colCmf9,
            this.colCmf10});
            this.lisLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotList.EnableSort = true;
            this.lisLotList.EnableSortIcon = true;
            this.lisLotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLotList.FullRowSelect = true;
            this.lisLotList.Location = new System.Drawing.Point(3, 3);
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(736, 175);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            this.lisLotList.SelectedIndexChanged += new System.EventHandler(this.lisLotList_SelectedIndexChanged);
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 120;
            // 
            // colMaterial
            // 
            this.colMaterial.Text = "Material";
            this.colMaterial.Width = 100;
            // 
            // colMatVer
            // 
            this.colMatVer.Text = "Mat Ver";
            // 
            // colFlow
            // 
            this.colFlow.Text = "Flow";
            this.colFlow.Width = 90;
            // 
            // colFlowSeqNum
            // 
            this.colFlowSeqNum.Text = "Flow Seq Num";
            this.colFlowSeqNum.Width = 90;
            // 
            // colOperation
            // 
            this.colOperation.Text = "Operation";
            this.colOperation.Width = 80;
            // 
            // colQty1
            // 
            this.colQty1.Text = "Qty 1";
            this.colQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colQty2
            // 
            this.colQty2.Text = "Qty 2";
            this.colQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colQty3
            // 
            this.colQty3.Text = "Qty3";
            this.colQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colLotType
            // 
            this.colLotType.Text = "Lot Type";
            this.colLotType.Width = 70;
            // 
            // colOwnerCode
            // 
            this.colOwnerCode.Text = "Owner Code";
            this.colOwnerCode.Width = 90;
            // 
            // colCreateCode
            // 
            this.colCreateCode.Text = "Create Code";
            this.colCreateCode.Width = 90;
            // 
            // colPriority
            // 
            this.colPriority.Text = "Priority";
            // 
            // colLotStatus
            // 
            this.colLotStatus.Text = "Lot Status";
            this.colLotStatus.Width = 80;
            // 
            // colResvRes
            // 
            this.colResvRes.Text = "Reserve Resource";
            this.colResvRes.Width = 80;
            // 
            // colLastTranTime
            // 
            this.colLastTranTime.Text = "Last Tran Time";
            this.colLastTranTime.Width = 120;
            // 
            // colOrgDueTime
            // 
            this.colOrgDueTime.Text = "Original Due Time";
            this.colOrgDueTime.Width = 120;
            // 
            // colSchDueTime
            // 
            this.colSchDueTime.Text = "Scheduled Due Time";
            this.colSchDueTime.Width = 145;
            // 
            // colOperInTime
            // 
            this.colOperInTime.Text = "Oper In Time";
            this.colOperInTime.Width = 120;
            // 
            // colLotScoreText
            // 
            this.colLotScoreText.Text = "ScoreText";
            this.colLotScoreText.Width = 150;
            // 
            // colUnSelect
            // 
            this.colUnSelect.Text = "Unselected Flag";
            this.colUnSelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colUnSelect.Width = 70;
            // 
            // colCapable
            // 
            this.colCapable.Text = "Capable Flag";
            this.colCapable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colRuleID
            // 
            this.colRuleID.Text = "Rule ID";
            this.colRuleID.Width = 80;
            // 
            // colDspReason
            // 
            this.colDspReason.Text = "Dispatch Reason";
            this.colDspReason.Width = 80;
            // 
            // colUnselectReason
            // 
            this.colUnselectReason.Text = "Unselect Reason";
            // 
            // colCapableReason
            // 
            this.colCapableReason.Text = "Capable Reason";
            // 
            // colCmf1
            // 
            this.colCmf1.Text = "Pds Cmf 1";
            // 
            // colCmf2
            // 
            this.colCmf2.Text = "Pds Cmf 2";
            // 
            // colCmf3
            // 
            this.colCmf3.Text = "Pds Cmf 3";
            // 
            // colCmf4
            // 
            this.colCmf4.Text = "Pds Cmf 4";
            // 
            // colCmf5
            // 
            this.colCmf5.Text = "Pds Cmf 5";
            // 
            // colCmf6
            // 
            this.colCmf6.Text = "Pds Cmf 6";
            // 
            // colCmf7
            // 
            this.colCmf7.Text = "Pds Cmf 7";
            // 
            // colCmf8
            // 
            this.colCmf8.Text = "Pds Cmf 8";
            // 
            // colCmf9
            // 
            this.colCmf9.Text = "Pds Cmf 9";
            // 
            // colCmf10
            // 
            this.colCmf10.Text = "Pds Cmf 10";
            // 
            // pnlLotBottom
            // 
            this.pnlLotBottom.Controls.Add(this.btnLotExcel);
            this.pnlLotBottom.Controls.Add(this.btnLotRefresh);
            this.pnlLotBottom.Controls.Add(this.lblTotLotQty);
            this.pnlLotBottom.Controls.Add(this.lblTotalLot2);
            this.pnlLotBottom.Controls.Add(this.lblTotLotCnt);
            this.pnlLotBottom.Controls.Add(this.lblTotalLot1);
            this.pnlLotBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLotBottom.Location = new System.Drawing.Point(3, 178);
            this.pnlLotBottom.Name = "pnlLotBottom";
            this.pnlLotBottom.Size = new System.Drawing.Size(736, 22);
            this.pnlLotBottom.TabIndex = 1;
            // 
            // btnLotExcel
            // 
            this.btnLotExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLotExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnLotExcel.Image")));
            this.btnLotExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLotExcel.Location = new System.Drawing.Point(32, 3);
            this.btnLotExcel.Name = "btnLotExcel";
            this.btnLotExcel.Size = new System.Drawing.Size(19, 19);
            this.btnLotExcel.TabIndex = 10;
            this.btnLotExcel.Click += new System.EventHandler(this.btnLotExcel_Click);
            // 
            // btnLotRefresh
            // 
            this.btnLotRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLotRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnLotRefresh.Image")));
            this.btnLotRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLotRefresh.Location = new System.Drawing.Point(7, 3);
            this.btnLotRefresh.Name = "btnLotRefresh";
            this.btnLotRefresh.Size = new System.Drawing.Size(19, 19);
            this.btnLotRefresh.TabIndex = 9;
            this.btnLotRefresh.Click += new System.EventHandler(this.btnLotRefresh_Click);
            // 
            // lblTotLotQty
            // 
            this.lblTotLotQty.AutoSize = true;
            this.lblTotLotQty.Location = new System.Drawing.Point(360, 6);
            this.lblTotLotQty.Name = "lblTotLotQty";
            this.lblTotLotQty.Size = new System.Drawing.Size(13, 13);
            this.lblTotLotQty.TabIndex = 3;
            this.lblTotLotQty.Text = "0";
            // 
            // lblTotalLot2
            // 
            this.lblTotalLot2.AutoSize = true;
            this.lblTotalLot2.Location = new System.Drawing.Point(267, 6);
            this.lblTotalLot2.Name = "lblTotalLot2";
            this.lblTotalLot2.Size = new System.Drawing.Size(87, 13);
            this.lblTotalLot2.TabIndex = 2;
            this.lblTotalLot2.Text = "Total Qty 1/2/3 :";
            // 
            // lblTotLotCnt
            // 
            this.lblTotLotCnt.AutoSize = true;
            this.lblTotLotCnt.Location = new System.Drawing.Point(172, 6);
            this.lblTotLotCnt.Name = "lblTotLotCnt";
            this.lblTotLotCnt.Size = new System.Drawing.Size(13, 13);
            this.lblTotLotCnt.TabIndex = 1;
            this.lblTotLotCnt.Text = "0";
            // 
            // lblTotalLot1
            // 
            this.lblTotalLot1.AutoSize = true;
            this.lblTotalLot1.Location = new System.Drawing.Point(80, 6);
            this.lblTotalLot1.Name = "lblTotalLot1";
            this.lblTotalLot1.Size = new System.Drawing.Size(86, 13);
            this.lblTotalLot1.TabIndex = 0;
            this.lblTotalLot1.Text = "Total Lot Count :";
            // 
            // splMid
            // 
            this.splMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.splMid.Location = new System.Drawing.Point(0, 290);
            this.splMid.Name = "splMid";
            this.splMid.Size = new System.Drawing.Size(742, 3);
            this.splMid.TabIndex = 3;
            this.splMid.TabStop = false;
            // 
            // pnlResource
            // 
            this.pnlResource.Controls.Add(this.lisResourceList);
            this.pnlResource.Controls.Add(this.pnlResBottom);
            this.pnlResource.Location = new System.Drawing.Point(0, 295);
            this.pnlResource.Name = "pnlResource";
            this.pnlResource.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlResource.Size = new System.Drawing.Size(742, 211);
            this.pnlResource.TabIndex = 4;
            // 
            // lisResourceList
            // 
            this.lisResourceList.AllowColumnReorder = true;
            this.lisResourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRes,
            this.colDesc,
            this.colType,
            this.colUpDown,
            this.colPriSts,
            this.colArea,
            this.colSubArea,
            this.colLastEvent,
            this.colLastEventTime,
            this.colLastStartTime,
            this.colLastEndTime,
            this.colResScoreText,
            this.colUnselected,
            this.colCapable1,
            this.colResRule,
            this.colResDspReason,
            this.colUnselectReason1,
            this.colCapableReason1,
            this.colxCmf1,
            this.colxCmf2,
            this.colxCmf3,
            this.colxCmf4,
            this.colxCmf5,
            this.colxCmf6,
            this.colxCmf7,
            this.colxCmf8,
            this.colxCmf9,
            this.colxCmf10});
            this.lisResourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResourceList.EnableSort = true;
            this.lisResourceList.EnableSortIcon = true;
            this.lisResourceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResourceList.FullRowSelect = true;
            this.lisResourceList.Location = new System.Drawing.Point(3, 3);
            this.lisResourceList.Name = "lisResourceList";
            this.lisResourceList.Size = new System.Drawing.Size(736, 186);
            this.lisResourceList.TabIndex = 0;
            this.lisResourceList.UseCompatibleStateImageBehavior = false;
            this.lisResourceList.View = System.Windows.Forms.View.Details;
            this.lisResourceList.SelectedIndexChanged += new System.EventHandler(this.lisResourceList_SelectedIndexChanged);
            // 
            // colRes
            // 
            this.colRes.Text = "Resource ID";
            this.colRes.Width = 100;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Res Desc";
            this.colDesc.Width = 130;
            // 
            // colType
            // 
            this.colType.Text = "Res Type";
            this.colType.Width = 90;
            // 
            // colUpDown
            // 
            this.colUpDown.Text = "Up/Down";
            this.colUpDown.Width = 70;
            // 
            // colPriSts
            // 
            this.colPriSts.Text = "Primary Status";
            this.colPriSts.Width = 120;
            // 
            // colArea
            // 
            this.colArea.Text = "Area ID";
            this.colArea.Width = 120;
            // 
            // colSubArea
            // 
            this.colSubArea.Text = "Sub Area ID";
            this.colSubArea.Width = 120;
            // 
            // colLastEvent
            // 
            this.colLastEvent.Text = "Last Event";
            this.colLastEvent.Width = 100;
            // 
            // colLastEventTime
            // 
            this.colLastEventTime.Text = "Last Event Time";
            this.colLastEventTime.Width = 120;
            // 
            // colLastStartTime
            // 
            this.colLastStartTime.Text = "Last Start Time";
            this.colLastStartTime.Width = 120;
            // 
            // colLastEndTime
            // 
            this.colLastEndTime.Text = "Last End Time";
            this.colLastEndTime.Width = 120;
            // 
            // colResScoreText
            // 
            this.colResScoreText.Text = "ScoreText";
            this.colResScoreText.Width = 150;
            // 
            // colUnselected
            // 
            this.colUnselected.Text = "Unselected";
            this.colUnselected.Width = 70;
            // 
            // colCapable1
            // 
            this.colCapable1.Text = "Capable Flag";
            this.colCapable1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colResRule
            // 
            this.colResRule.Text = "Rule ID";
            this.colResRule.Width = 80;
            // 
            // colResDspReason
            // 
            this.colResDspReason.Text = "Dispatch Reason";
            this.colResDspReason.Width = 100;
            // 
            // colUnselectReason1
            // 
            this.colUnselectReason1.Text = "Unselect Reason";
            // 
            // colCapableReason1
            // 
            this.colCapableReason1.Text = "CapableReason";
            // 
            // colxCmf1
            // 
            this.colxCmf1.Text = "Pds Cmf 1";
            // 
            // colxCmf2
            // 
            this.colxCmf2.Text = "Pds Cmf 2";
            // 
            // colxCmf3
            // 
            this.colxCmf3.Text = "Pds Cmf 3";
            // 
            // colxCmf4
            // 
            this.colxCmf4.Text = "Pds Cmf 4";
            // 
            // colxCmf5
            // 
            this.colxCmf5.Text = "Pds Cmf 5";
            // 
            // colxCmf6
            // 
            this.colxCmf6.Text = "Pds Cmf 6";
            // 
            // colxCmf7
            // 
            this.colxCmf7.Text = "Pds Cmf 7";
            // 
            // colxCmf8
            // 
            this.colxCmf8.Text = "Pds Cmf 8";
            // 
            // colxCmf9
            // 
            this.colxCmf9.Text = "Pds Cmf 9";
            // 
            // colxCmf10
            // 
            this.colxCmf10.Text = "Pds Cmf 10";
            // 
            // pnlResBottom
            // 
            this.pnlResBottom.Controls.Add(this.btnResExcel);
            this.pnlResBottom.Controls.Add(this.btnResRefresh);
            this.pnlResBottom.Controls.Add(this.lblTotResCnt);
            this.pnlResBottom.Controls.Add(this.lblTotRes);
            this.pnlResBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResBottom.Location = new System.Drawing.Point(3, 189);
            this.pnlResBottom.Name = "pnlResBottom";
            this.pnlResBottom.Size = new System.Drawing.Size(736, 22);
            this.pnlResBottom.TabIndex = 1;
            // 
            // btnResExcel
            // 
            this.btnResExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnResExcel.Image")));
            this.btnResExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResExcel.Location = new System.Drawing.Point(32, 3);
            this.btnResExcel.Name = "btnResExcel";
            this.btnResExcel.Size = new System.Drawing.Size(19, 19);
            this.btnResExcel.TabIndex = 10;
            this.btnResExcel.Click += new System.EventHandler(this.btnResExcel_Click);
            // 
            // btnResRefresh
            // 
            this.btnResRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnResRefresh.Image")));
            this.btnResRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResRefresh.Location = new System.Drawing.Point(7, 3);
            this.btnResRefresh.Name = "btnResRefresh";
            this.btnResRefresh.Size = new System.Drawing.Size(19, 19);
            this.btnResRefresh.TabIndex = 9;
            this.btnResRefresh.Click += new System.EventHandler(this.btnResRefresh_Click);
            // 
            // lblTotResCnt
            // 
            this.lblTotResCnt.AutoSize = true;
            this.lblTotResCnt.Location = new System.Drawing.Point(202, 6);
            this.lblTotResCnt.Name = "lblTotResCnt";
            this.lblTotResCnt.Size = new System.Drawing.Size(13, 13);
            this.lblTotResCnt.TabIndex = 1;
            this.lblTotResCnt.Text = "0";
            // 
            // lblTotRes
            // 
            this.lblTotRes.AutoSize = true;
            this.lblTotRes.Location = new System.Drawing.Point(80, 6);
            this.lblTotRes.Name = "lblTotRes";
            this.lblTotRes.Size = new System.Drawing.Size(117, 13);
            this.lblTotRes.TabIndex = 0;
            this.lblTotRes.Text = "Total Resource Count :";
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 60000;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // frmLotListbyDispatcher
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlResource);
            this.Controls.Add(this.splMid);
            this.Controls.Add(this.pnlLot);
            this.Controls.Add(this.pnlDsp);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmLotListbyDispatcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "View Dispatcher Simulation Result";
            this.Activated += new System.EventHandler(this.frmLotListbyDispatcher_Activated);
            this.Load += new System.EventHandler(this.frmLotListbyDispatcher_Load);
            this.Resize += new System.EventHandler(this.frmLotListbyDispatcher_Resize);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshSec)).EndInit();
            this.pnlDsp.ResumeLayout(false);
            this.grpDsp.ResumeLayout(false);
            this.grpDsp.PerformLayout();
            this.pnlLot.ResumeLayout(false);
            this.pnlLotBottom.ResumeLayout(false);
            this.pnlLotBottom.PerformLayout();
            this.pnlResource.ResumeLayout(false);
            this.pnlResBottom.ResumeLayout(false);
            this.pnlResBottom.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag = false;
        private string sRuleType = "";
        
        #endregion
        
        #region "Function Definition"
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(char c_step)
        {
            
            
            switch (c_step)
            {
                case '1':
                    
                    if (lisLotList.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisLotList.Items.Count > 0)
                        {
                            lisLotList.Items[0].Selected = true;
                            lisLotList.Focus();
                        }
                        return false;
                    }
                    if (lisResourceList.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisResourceList.Items.Count > 0)
                        {
                            lisResourceList.Items[0].Selected = true;
                            lisResourceList.Focus();
                        }
                        return false;
                    }
                    break;
                case '2':
                    
                    if (lisLotList.SelectedItems.Count <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(109));
                        if (lisLotList.Items.Count > 0)
                        {
                            lisLotList.Items[0].Selected = true;
                            lisLotList.Focus();
                        }
                        return false;
                    }
                    break;
            }
            
            return true;
            
        }

        private void CalTotalLotCount()
        {
            int i;
            double d_qty_1;
            double d_qty_2;
            double d_qty_3;

            lblTotLotCnt.Text = lisLotList.Items.Count.ToString();

            d_qty_1 = 0;
            d_qty_2 = 0;
            d_qty_3 = 0;

            for (i = 0; i < lisLotList.Items.Count; i++)
            {
                d_qty_1 += MPCF.ToDbl(lisLotList.Items[i].SubItems[6].Text);
                d_qty_2 += MPCF.ToDbl(lisLotList.Items[i].SubItems[7].Text);
                d_qty_3 += MPCF.ToDbl(lisLotList.Items[i].SubItems[8].Text);
            }

            lblTotLotQty.Text = d_qty_1.ToString("######,##0.###") + " / " + d_qty_2.ToString("######,##0.###") + " / " + d_qty_3.ToString("######,##0.###");
        }

        private void CalTotalResCount()
        {
            lblTotResCnt.Text = lisResourceList.Items.Count.ToString();
        }
        
        // SetOperation()
        //       - Setting Operation at "frmMIDMain"
        // Return Value
        //       -
        // Arguments
        //        -
        public void SetDispatcher(string sDsp, string sDesc, string sType, int iWidth, int iHeight)
        {
            MPCF.ClearList(lisResourceList, true);
            MPCF.ClearList(lisLotList, true);
            sRuleType = sType;
            
            txtDspID.Text = sDsp;
            txtDesc.Text = sDesc;

            lblTotLotCnt.Text = "0";
            lblTotLotQty.Text = "0";
            lblTotResCnt.Text = "0";
            
            if (sType == "R")
            {
                pnlResource.Dock = DockStyle.Top;
                splMid.Dock = DockStyle.Top;
                pnlLot.Dock = DockStyle.Fill;
                this.Controls.Add(this.pnlLot);
                this.Controls.Add(this.splMid);
                this.Controls.Add(this.pnlResource);
                this.Controls.Add(this.pnlDsp);
                this.Controls.Add(this.pnlBottom);
                this.Controls.Add(this.pnlTop);
                lisResourceList.MultiSelect = false;
                lisLotList.MultiSelect = true;
            }
            else
            {
                pnlLot.Dock = DockStyle.Top;
                splMid.Dock = DockStyle.Top;
                pnlResource.Dock = DockStyle.Fill;
                this.Controls.Add(this.pnlResource);
                this.Controls.Add(this.splMid);
                this.Controls.Add(this.pnlLot);
                this.Controls.Add(this.pnlDsp);
                this.Controls.Add(this.pnlBottom);
                this.Controls.Add(this.pnlTop);
                lisResourceList.MultiSelect = true;
                lisLotList.MultiSelect = false;
            }
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
            
            if (b_load_flag == true)
            {
                if (sRuleType == "O")
                {
                    RTDLIST.ViewDspLotSimulation(lisLotList, '1', txtDspID.Text, "");
                    CalTotalLotCount();
                }
                else
                {
                    RTDLIST.ViewDspResSimulation(lisResourceList, '1', txtDspID.Text, "", 0, "", "");
                    CalTotalResCount();
                }
            }
            else
            {
                this.Top = 0;
                this.Left = 0;
                this.Width = iWidth - 4;
                this.Height = iHeight - 4;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                if (sRuleType == "R")
                {
                    return this.lisResourceList;
                }
                else
                {
                    return this.lisLotList;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void lblFormTitle_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
        
        private void frmLotListbyDispatcher_Resize(object sender, System.EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                if (this.MdiParent == null)
                {
                    pnlTop.Visible = false;
                }
                else
                {
                    pnlTop.Visible = true;
                }
            }
            else
            {
                pnlTop.Visible = false;
            }
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            this.Dispose();
            
        }
        
        private void frmLotListbyDispatcher_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                if (sRuleType == "O")
                {
                    MPCF.InitListView(lisResourceList);
                    RTDLIST.ViewDspLotSimulation(lisLotList, '1', txtDspID.Text, "");
                    CalTotalLotCount();
                }
                else
                {
                    MPCF.InitListView(lisLotList);
                    RTDLIST.ViewDspResSimulation(lisResourceList, '1', txtDspID.Text, "", 0, "", "");
                    CalTotalResCount();
                }
                b_load_flag = true;
            }
        }
        
        private void lisResourceList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (lisResourceList.Items.Count < 1) return;
                if (lisResourceList.SelectedItems.Count < 1) return;

                if (lisResourceList.SelectedItems[0].SubItems[12].Text == "Y")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(268));
                    return;
                }
                
                if (sRuleType == "R")
                {
                    RTDLIST.ViewDspLotSimulation(lisLotList, '2', txtDspID.Text, lisResourceList.SelectedItems[0].Text);
                    CalTotalLotCount();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void lisLotList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {

                if (lisLotList.Items.Count < 1) return;
                if (lisLotList.SelectedItems.Count < 1) return;

                if (lisLotList.SelectedItems[0].SubItems[20].Text == "Y")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(268));
                    return;
                }
                if (sRuleType == "O")
                {
                    lisResourceList.Items.Clear();                    

                    RTDLIST.ViewDspResSimulation(lisResourceList, 
                                                 '2', 
                                                 txtDspID.Text, 
                                                 lisLotList.SelectedItems[0].SubItems[1].Text,
                                                 MPCF.ToInt(lisLotList.SelectedItems[0].SubItems[2].Text),
                                                 lisLotList.SelectedItems[0].SubItems[3].Text,
                                                 lisLotList.SelectedItems[0].SubItems[5].Text);
                    CalTotalResCount();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnStart_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sLotID = string.Empty;
                string sResourceID = string.Empty;
                
                if (CheckCondition('1') == false)
                {
                    return;
                }
                if (lisLotList.SelectedItems.Count > 0)
                {
                    sLotID = lisLotList.SelectedItems[0].Text;
                }
                if (lisResourceList.SelectedItems.Count > 0)
                {
                    sResourceID = lisResourceList.SelectedItems[0].Text;
                }
                if (MPGV.gIMdiForm.ViewWIPTranStartLot(true, sLotID, sResourceID) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnSkip_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sLotID = string.Empty;
                
                if (CheckCondition('2') == false)
                {
                    return;
                }
                if (lisLotList.SelectedItems.Count > 0)
                {
                    sLotID = lisLotList.SelectedItems[0].Text;
                }
                if (MPGV.gIMdiForm.ViewWIPTranSkipLot(true, sLotID) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnEnd_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sLotID = string.Empty;
                string sResourceID = string.Empty;
                
                if (CheckCondition('1') == false)
                {
                    return;
                }
                if (lisLotList.SelectedItems.Count > 0)
                {
                    sLotID = lisLotList.SelectedItems[0].Text;
                }
                if (lisResourceList.SelectedItems.Count > 0)
                {
                    sResourceID = lisResourceList.SelectedItems[0].Text;
                }
                if (MPGV.gIMdiForm.ViewWIPTranEndLot(true, sLotID, sResourceID) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnMove_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sLotID = string.Empty;
                
                if (CheckCondition('2') == false)
                {
                    return;
                }
                if (lisLotList.SelectedItems.Count > 0)
                {
                    sLotID = lisLotList.SelectedItems[0].Text;
                }
                if (MPGV.gIMdiForm.ViewWIPTranMoveLot(true, sLotID) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmLotListbyDispatcher_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.lblFormTitle.Text = this.Text;
                
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                if (MPGV.giAutoRefreshTime > 0)
                {
                    numRefreshSec.Value = MPGV.giAutoRefreshTime;
                }
                else
                {
                    numRefreshSec.Value = 60;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void tmrTimer_Tick(object sender, System.EventArgs e)
        {
            if (sRuleType == "O")
            {
                MPCF.InitListView(lisResourceList);
                lblTotResCnt.Text = "0";
                RTDLIST.ViewDspLotSimulation(lisLotList, '1', txtDspID.Text, "");
                CalTotalLotCount();
            }
            else
            {
                MPCF.InitListView(lisLotList);
                lblTotLotCnt.Text = "0";
                lblTotLotQty.Text = "0";
                RTDLIST.ViewDspResSimulation(lisResourceList, '1', txtDspID.Text, "", 0, "", "");
                CalTotalResCount();
            }
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked == true)
            {
                tmrTimer.Interval = ((int)(numRefreshSec.Value)) * 1000;
                tmrTimer.Start();
            }
            else
            {
                tmrTimer.Stop();
            }
        }

        private void numRefreshSec_ValueChanged(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked == true)
            {
                tmrTimer.Interval = ((int)(numRefreshSec.Value)) * 1000;
                tmrTimer.Start();
            }
        }

        private void btnLotRefresh_Click(object sender, EventArgs e)
        {
            if (sRuleType == "O")
            {
                MPCF.InitListView(lisResourceList);
                lblTotResCnt.Text = "0";
                RTDLIST.ViewDspLotSimulation(lisLotList, '1', txtDspID.Text, "");
                CalTotalLotCount();
            }
            else
            {
                MPCF.InitListView(lisLotList);

                if (lisResourceList.Items.Count < 1) return;
                if (lisResourceList.SelectedItems.Count < 1) return;

                RTDLIST.ViewDspLotSimulation(lisLotList, '2', txtDspID.Text, lisResourceList.SelectedItems[0].Text);
                CalTotalLotCount();
            }
        }

        private void btnResRefresh_Click(object sender, EventArgs e)
        {
            if (sRuleType == "R")
            {
                MPCF.InitListView(lisLotList);
                lblTotLotCnt.Text = "0";
                lblTotLotQty.Text = "0";
                RTDLIST.ViewDspResSimulation(lisResourceList, '1', txtDspID.Text, "", 0, "", "");
                CalTotalResCount();
            }
            else
            {
                MPCF.InitListView(lisResourceList);

                if (lisLotList.Items.Count < 1) return;
                if (lisLotList.SelectedItems.Count < 1) return;
                
                RTDLIST.ViewDspResSimulation(lisResourceList,
                                             '2',
                                             txtDspID.Text,
                                             lisLotList.SelectedItems[0].SubItems[1].Text,
                                             MPCF.ToInt(lisLotList.SelectedItems[0].SubItems[2].Text),
                                             lisLotList.SelectedItems[0].SubItems[3].Text,
                                             lisLotList.SelectedItems[0].SubItems[5].Text);
                CalTotalResCount();
            }
        }

        private void btnLotExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "";
            sCond = "Dispatcher ID : " + txtDspID.Text;

            if (MPCF.ExportToExcel(lisLotList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }

        private void btnResExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "";
            sCond = "Dispatcher ID : " + txtDspID.Text;

            if (MPCF.ExportToExcel(lisResourceList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }
        
        #endif        
    }    
}
