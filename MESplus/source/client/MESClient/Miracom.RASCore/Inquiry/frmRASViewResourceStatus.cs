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
//   File Name   : frmRASViewResourceStatus.vb
//   Description : View Resource Status Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  View_Resource()          : View Resource information
//       -  View_Factory_ResStatus() : View Factory Resource Status Prompt
//       -  SetGroupCmfItem()        : Set Group / Cmf Property to control
//       -  InitControl()            : Initial Group/Cmf Control
//       -  SetCmfItem()             : Set Cmf Property to control
//       -  SetGRPItem()             : Set Group  Property to control
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-22 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASViewResourceStatus : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewResourceStatus()
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




        private System.Windows.Forms.Panel pnlGrp;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.TabControl tabResStatus;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpResGrp;
        private System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.TabPage tbpResSts;
        private System.Windows.Forms.TabPage tbpLotList;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TextBox txtMaxProcCount;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.TextBox txtProcRule;
        private System.Windows.Forms.TextBox txtResType;
        private System.Windows.Forms.TextBox txtAreaId;
        private System.Windows.Forms.TextBox txtProcMode;
        private System.Windows.Forms.TextBox txtSubAreaID;
        private System.Windows.Forms.Label lblMaxProcCount;
        private System.Windows.Forms.Label lblProcRule;
        private System.Windows.Forms.Label lblResType;
        private System.Windows.Forms.Label lblProcMode;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblSubAreaID;
        private System.Windows.Forms.Label lblAreaID;
        private System.Windows.Forms.CheckBox chkSecChkFlag;
        private System.Windows.Forms.CheckBox chkUnitBaseStFlag;
        private System.Windows.Forms.CheckBox chkPMSchEnableFlag;
        private System.Windows.Forms.CheckBox chkResDelFlag;
        private System.Windows.Forms.Label lblDelUserID;
        private System.Windows.Forms.TextBox txtDelTime;
        private System.Windows.Forms.Label lblDelTime;
        private System.Windows.Forms.TextBox txtDelUser;
        private System.Windows.Forms.TextBox txtUpDownFlag;
        private System.Windows.Forms.Label lblUpDownFlag;
        private System.Windows.Forms.TextBox txtPriStatus;
        private System.Windows.Forms.Label lblPriSts;
        private System.Windows.Forms.TextBox txtProcCount;
        private System.Windows.Forms.TextBox txtLastEnd;
        private System.Windows.Forms.Label lblLastHistSeq;
        private System.Windows.Forms.Label lblActiveHistSeq;
        private System.Windows.Forms.Label lblLastEventTime;
        private System.Windows.Forms.Label lblLastEvent;
        private System.Windows.Forms.TextBox txtLastHistSeq;
        private System.Windows.Forms.TextBox txtLastEventTime;
        private System.Windows.Forms.TextBox txtLastActHistSeq;
        private System.Windows.Forms.TextBox txtLastEvent;
        private System.Windows.Forms.TextBox txtLastStart;
        private System.Windows.Forms.Label lblLastEnd;
        private System.Windows.Forms.Label lblLastStart;
        private System.Windows.Forms.Label lblProcCount;
        private System.Windows.Forms.TextBox txtGrp10;
        private System.Windows.Forms.TextBox txtGrp9;
        private System.Windows.Forms.TextBox txtGrp8;
        private System.Windows.Forms.TextBox txtGrp7;
        private System.Windows.Forms.TextBox txtGrp6;
        private System.Windows.Forms.TextBox txtGrp5;
        private System.Windows.Forms.TextBox txtGrp4;
        private System.Windows.Forms.TextBox txtGrp3;
        private System.Windows.Forms.TextBox txtGrp2;
        private System.Windows.Forms.TextBox txtGrp1;
        private System.Windows.Forms.GroupBox grpCMF;
        private System.Windows.Forms.Label lblCMF10;
        private System.Windows.Forms.Label lblCMF9;
        private System.Windows.Forms.Label lblCMF8;
        private System.Windows.Forms.Label lblCMF7;
        private System.Windows.Forms.Label lblCMF6;
        private System.Windows.Forms.Label lblCMF5;
        private System.Windows.Forms.Label lblCMF4;
        private System.Windows.Forms.Label lblCMF3;
        private System.Windows.Forms.Label lblCMF2;
        private System.Windows.Forms.Label lblCMF1;
        private System.Windows.Forms.TextBox txtCMF7;
        private System.Windows.Forms.TextBox txtCMF6;
        private System.Windows.Forms.TextBox txtCMF5;
        private System.Windows.Forms.TextBox txtCMF4;
        private System.Windows.Forms.TextBox txtCMF3;
        private System.Windows.Forms.TextBox txtCMF2;
        private System.Windows.Forms.TextBox txtCMF1;
        private System.Windows.Forms.TextBox txtCMF10;
        private System.Windows.Forms.TextBox txtCMF9;
        private System.Windows.Forms.TextBox txtCMF8;
        private System.Windows.Forms.GroupBox grpResStatus;
        private System.Windows.Forms.TextBox txtSts10;
        private System.Windows.Forms.TextBox txtSts8;
        private System.Windows.Forms.TextBox txtSts7;
        private System.Windows.Forms.TextBox txtSts6;
        private System.Windows.Forms.TextBox txtSts5;
        private System.Windows.Forms.TextBox txtSts4;
        private System.Windows.Forms.TextBox txtSts3;
        private System.Windows.Forms.TextBox txtSts2;
        private System.Windows.Forms.TextBox txtSts1;
        private System.Windows.Forms.GroupBox grpLotList;
        private FarPoint.Win.Spread.FpSpread spdLot;
        private FarPoint.Win.Spread.SheetView spdLot_Sheet1;
        private System.Windows.Forms.TextBox txtSts9;
        private System.Windows.Forms.GroupBox grpGrp;
        private System.Windows.Forms.Label lblGrp10;
        private System.Windows.Forms.Label lblGrp9;
        private System.Windows.Forms.Label lblGrp8;
        private System.Windows.Forms.Label lblGrp7;
        private System.Windows.Forms.Label lblGrp6;
        private System.Windows.Forms.Label lblGrp5;
        private System.Windows.Forms.Label lblGrp4;
        private System.Windows.Forms.Label lblGrp3;
        private System.Windows.Forms.Label lblGrp2;
        private System.Windows.Forms.Label lblGrp1;
        private System.Windows.Forms.Label lblSts10;
        private System.Windows.Forms.Label lblSts9;
        private System.Windows.Forms.Label lblSts8;
        private System.Windows.Forms.Label lblSts7;
        private System.Windows.Forms.Label lblSts6;
        private System.Windows.Forms.Label lblSts5;
        private System.Windows.Forms.Label lblSts4;
        private System.Windows.Forms.Label lblSts3;
        private System.Windows.Forms.Label lblSts2;
        private System.Windows.Forms.Label lblSts1;
        private System.Windows.Forms.GroupBox grpRes;
        private System.Windows.Forms.CheckBox chkUseFacPrtFlag;
        private System.Windows.Forms.ContextMenu ctxCopyMenu;
        private System.Windows.Forms.MenuItem ctxCopy;
        private System.Windows.Forms.TextBox txtCtrlMode;
        private TextBox txtCMF20;
        private TextBox txtCMF19;
        private TextBox txtCMF18;
        private TextBox txtCMF17;
        private TextBox txtCMF16;
        private TextBox txtCMF15;
        private TextBox txtCMF14;
        private TextBox txtCMF13;
        private TextBox txtCMF12;
        private TextBox txtCMF11;
        private Label lblCMF20;
        private Label lblCMF19;
        private Label lblCMF18;
        private Label lblCMF17;
        private Label lblCMF16;
        private Label lblCMF15;
        private Label lblCMF14;
        private Label lblCMF13;
        private Label lblCMF12;
        private Label lblCMF11;
        private TabPage tbpAttribute;
        private Miracom.BASCore.udcAttributeStatus udcAttributeStatus;
        private Button btnHistory;
        private CheckBox chkRegisterAlarm;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResType;
        private Label lblResourceGroup;
        private Label lblResourceType;
        private Label lblResource;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private TextBox txtDesc;
        private Label lblDesc;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Label lblOperation;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private System.Windows.Forms.Label lblCtrlMode;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlGrp = new System.Windows.Forms.Panel();
            this.cdvResGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResourceGroup = new System.Windows.Forms.Label();
            this.lblResourceType = new System.Windows.Forms.Label();
            this.lblResource = new System.Windows.Forms.Label();
            this.grpRes = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.lblOperation = new System.Windows.Forms.Label();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabResStatus = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.chkRegisterAlarm = new System.Windows.Forms.CheckBox();
            this.txtProcCount = new System.Windows.Forms.TextBox();
            this.txtLastEnd = new System.Windows.Forms.TextBox();
            this.lblLastHistSeq = new System.Windows.Forms.Label();
            this.lblActiveHistSeq = new System.Windows.Forms.Label();
            this.lblLastEventTime = new System.Windows.Forms.Label();
            this.lblLastEvent = new System.Windows.Forms.Label();
            this.txtLastHistSeq = new System.Windows.Forms.TextBox();
            this.txtLastEventTime = new System.Windows.Forms.TextBox();
            this.txtLastActHistSeq = new System.Windows.Forms.TextBox();
            this.txtLastEvent = new System.Windows.Forms.TextBox();
            this.txtLastStart = new System.Windows.Forms.TextBox();
            this.lblLastEnd = new System.Windows.Forms.Label();
            this.lblLastStart = new System.Windows.Forms.Label();
            this.lblProcCount = new System.Windows.Forms.Label();
            this.txtPriStatus = new System.Windows.Forms.TextBox();
            this.lblPriSts = new System.Windows.Forms.Label();
            this.txtUpDownFlag = new System.Windows.Forms.TextBox();
            this.lblUpDownFlag = new System.Windows.Forms.Label();
            this.txtDelTime = new System.Windows.Forms.TextBox();
            this.lblDelTime = new System.Windows.Forms.Label();
            this.txtDelUser = new System.Windows.Forms.TextBox();
            this.lblDelUserID = new System.Windows.Forms.Label();
            this.chkResDelFlag = new System.Windows.Forms.CheckBox();
            this.chkSecChkFlag = new System.Windows.Forms.CheckBox();
            this.chkUnitBaseStFlag = new System.Windows.Forms.CheckBox();
            this.chkPMSchEnableFlag = new System.Windows.Forms.CheckBox();
            this.txtSubAreaID = new System.Windows.Forms.TextBox();
            this.txtAreaId = new System.Windows.Forms.TextBox();
            this.txtProcMode = new System.Windows.Forms.TextBox();
            this.txtResType = new System.Windows.Forms.TextBox();
            this.txtProcRule = new System.Windows.Forms.TextBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtMaxProcCount = new System.Windows.Forms.TextBox();
            this.txtCtrlMode = new System.Windows.Forms.TextBox();
            this.lblProcMode = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblSubAreaID = new System.Windows.Forms.Label();
            this.lblAreaID = new System.Windows.Forms.Label();
            this.lblMaxProcCount = new System.Windows.Forms.Label();
            this.lblProcRule = new System.Windows.Forms.Label();
            this.lblCtrlMode = new System.Windows.Forms.Label();
            this.lblResType = new System.Windows.Forms.Label();
            this.tbpLotList = new System.Windows.Forms.TabPage();
            this.grpLotList = new System.Windows.Forms.GroupBox();
            this.spdLot = new FarPoint.Win.Spread.FpSpread();
            this.ctxCopyMenu = new System.Windows.Forms.ContextMenu();
            this.ctxCopy = new System.Windows.Forms.MenuItem();
            this.spdLot_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpResSts = new System.Windows.Forms.TabPage();
            this.grpResStatus = new System.Windows.Forms.GroupBox();
            this.chkUseFacPrtFlag = new System.Windows.Forms.CheckBox();
            this.txtSts10 = new System.Windows.Forms.TextBox();
            this.txtSts9 = new System.Windows.Forms.TextBox();
            this.txtSts8 = new System.Windows.Forms.TextBox();
            this.txtSts7 = new System.Windows.Forms.TextBox();
            this.txtSts6 = new System.Windows.Forms.TextBox();
            this.txtSts5 = new System.Windows.Forms.TextBox();
            this.txtSts4 = new System.Windows.Forms.TextBox();
            this.txtSts3 = new System.Windows.Forms.TextBox();
            this.txtSts2 = new System.Windows.Forms.TextBox();
            this.txtSts1 = new System.Windows.Forms.TextBox();
            this.lblSts10 = new System.Windows.Forms.Label();
            this.lblSts9 = new System.Windows.Forms.Label();
            this.lblSts8 = new System.Windows.Forms.Label();
            this.lblSts7 = new System.Windows.Forms.Label();
            this.lblSts6 = new System.Windows.Forms.Label();
            this.lblSts5 = new System.Windows.Forms.Label();
            this.lblSts4 = new System.Windows.Forms.Label();
            this.lblSts3 = new System.Windows.Forms.Label();
            this.lblSts2 = new System.Windows.Forms.Label();
            this.lblSts1 = new System.Windows.Forms.Label();
            this.tbpResGrp = new System.Windows.Forms.TabPage();
            this.grpGrp = new System.Windows.Forms.GroupBox();
            this.txtGrp10 = new System.Windows.Forms.TextBox();
            this.txtGrp9 = new System.Windows.Forms.TextBox();
            this.txtGrp8 = new System.Windows.Forms.TextBox();
            this.txtGrp7 = new System.Windows.Forms.TextBox();
            this.txtGrp6 = new System.Windows.Forms.TextBox();
            this.txtGrp5 = new System.Windows.Forms.TextBox();
            this.txtGrp4 = new System.Windows.Forms.TextBox();
            this.txtGrp3 = new System.Windows.Forms.TextBox();
            this.txtGrp2 = new System.Windows.Forms.TextBox();
            this.txtGrp1 = new System.Windows.Forms.TextBox();
            this.lblGrp10 = new System.Windows.Forms.Label();
            this.lblGrp9 = new System.Windows.Forms.Label();
            this.lblGrp8 = new System.Windows.Forms.Label();
            this.lblGrp7 = new System.Windows.Forms.Label();
            this.lblGrp6 = new System.Windows.Forms.Label();
            this.lblGrp5 = new System.Windows.Forms.Label();
            this.lblGrp4 = new System.Windows.Forms.Label();
            this.lblGrp3 = new System.Windows.Forms.Label();
            this.lblGrp2 = new System.Windows.Forms.Label();
            this.lblGrp1 = new System.Windows.Forms.Label();
            this.tbpAttribute = new System.Windows.Forms.TabPage();
            this.udcAttributeStatus = new Miracom.BASCore.udcAttributeStatus();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.txtCMF20 = new System.Windows.Forms.TextBox();
            this.txtCMF19 = new System.Windows.Forms.TextBox();
            this.txtCMF18 = new System.Windows.Forms.TextBox();
            this.txtCMF17 = new System.Windows.Forms.TextBox();
            this.txtCMF16 = new System.Windows.Forms.TextBox();
            this.txtCMF15 = new System.Windows.Forms.TextBox();
            this.txtCMF14 = new System.Windows.Forms.TextBox();
            this.txtCMF13 = new System.Windows.Forms.TextBox();
            this.txtCMF12 = new System.Windows.Forms.TextBox();
            this.txtCMF11 = new System.Windows.Forms.TextBox();
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
            this.txtCMF10 = new System.Windows.Forms.TextBox();
            this.txtCMF9 = new System.Windows.Forms.TextBox();
            this.txtCMF8 = new System.Windows.Forms.TextBox();
            this.txtCMF7 = new System.Windows.Forms.TextBox();
            this.txtCMF6 = new System.Windows.Forms.TextBox();
            this.txtCMF5 = new System.Windows.Forms.TextBox();
            this.txtCMF4 = new System.Windows.Forms.TextBox();
            this.txtCMF3 = new System.Windows.Forms.TextBox();
            this.txtCMF2 = new System.Windows.Forms.TextBox();
            this.txtCMF1 = new System.Windows.Forms.TextBox();
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
            this.btnHistory = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).BeginInit();
            this.grpRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlTab.SuspendLayout();
            this.tabResStatus.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.tbpLotList.SuspendLayout();
            this.grpLotList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLot_Sheet1)).BeginInit();
            this.tbpResSts.SuspendLayout();
            this.grpResStatus.SuspendLayout();
            this.tbpResGrp.SuspendLayout();
            this.grpGrp.SuspendLayout();
            this.tbpAttribute.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(461, 7);
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnHistory);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 2;
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnHistory, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 553);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Resource Status";
            // 
            // pnlGrp
            // 
            this.pnlGrp.Controls.Add(this.cdvResGrp);
            this.pnlGrp.Controls.Add(this.cdvResType);
            this.pnlGrp.Controls.Add(this.lblResourceGroup);
            this.pnlGrp.Controls.Add(this.lblResourceType);
            this.pnlGrp.Controls.Add(this.lblResource);
            this.pnlGrp.Controls.Add(this.grpRes);
            this.pnlGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrp.Location = new System.Drawing.Point(0, 0);
            this.pnlGrp.Name = "pnlGrp";
            this.pnlGrp.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlGrp.Size = new System.Drawing.Size(742, 116);
            this.pnlGrp.TabIndex = 0;
            // 
            // cdvResGrp
            // 
            this.cdvResGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp.BtnToolTipText = "";
            this.cdvResGrp.DescText = "";
            this.cdvResGrp.DisplaySubItemIndex = -1;
            this.cdvResGrp.DisplayText = "";
            this.cdvResGrp.Focusing = null;
            this.cdvResGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp.Index = 0;
            this.cdvResGrp.IsViewBtnImage = false;
            this.cdvResGrp.Location = new System.Drawing.Point(121, 37);
            this.cdvResGrp.MaxLength = 20;
            this.cdvResGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp.Name = "cdvResGrp";
            this.cdvResGrp.ReadOnly = false;
            this.cdvResGrp.SearchSubItemIndex = 0;
            this.cdvResGrp.SelectedDescIndex = -1;
            this.cdvResGrp.SelectedSubItemIndex = -1;
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
            this.cdvResType.DescText = "";
            this.cdvResType.DisplaySubItemIndex = -1;
            this.cdvResType.DisplayText = "";
            this.cdvResType.Focusing = null;
            this.cdvResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResType.Index = 0;
            this.cdvResType.IsViewBtnImage = false;
            this.cdvResType.Location = new System.Drawing.Point(121, 13);
            this.cdvResType.MaxLength = 20;
            this.cdvResType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResType.Name = "cdvResType";
            this.cdvResType.ReadOnly = false;
            this.cdvResType.SearchSubItemIndex = 0;
            this.cdvResType.SelectedDescIndex = -1;
            this.cdvResType.SelectedSubItemIndex = -1;
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
            this.lblResourceGroup.Location = new System.Drawing.Point(16, 40);
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
            this.lblResourceType.Location = new System.Drawing.Point(16, 16);
            this.lblResourceType.Name = "lblResourceType";
            this.lblResourceType.Size = new System.Drawing.Size(80, 13);
            this.lblResourceType.TabIndex = 0;
            this.lblResourceType.Text = "Resource Type";
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResource.Location = new System.Drawing.Point(16, 64);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(78, 13);
            this.lblResource.TabIndex = 4;
            this.lblResource.Text = "Resource ID";
            // 
            // grpRes
            // 
            this.grpRes.Controls.Add(this.cdvMaterial);
            this.grpRes.Controls.Add(this.lblOperation);
            this.grpRes.Controls.Add(this.cdvOperation);
            this.grpRes.Controls.Add(this.cdvFlow);
            this.grpRes.Controls.Add(this.cdvResID);
            this.grpRes.Controls.Add(this.txtDesc);
            this.grpRes.Controls.Add(this.lblDesc);
            this.grpRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRes.Location = new System.Drawing.Point(3, 0);
            this.grpRes.Name = "grpRes";
            this.grpRes.Size = new System.Drawing.Size(736, 116);
            this.grpRes.TabIndex = 0;
            this.grpRes.TabStop = false;
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
            this.cdvMaterial.Location = new System.Drawing.Point(409, 13);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(320, 20);
            this.cdvMaterial.TabIndex = 3;
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
            this.lblOperation.Location = new System.Drawing.Point(409, 64);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(53, 13);
            this.lblOperation.TabIndex = 5;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvOperation
            // 
            this.cdvOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOperation.BtnToolTipText = "";
            this.cdvOperation.DescText = "";
            this.cdvOperation.DisplaySubItemIndex = -1;
            this.cdvOperation.DisplayText = "";
            this.cdvOperation.Focusing = null;
            this.cdvOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.Index = 0;
            this.cdvOperation.IsViewBtnImage = false;
            this.cdvOperation.Location = new System.Drawing.Point(529, 61);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(200, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 6;
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
            this.cdvFlow.Location = new System.Drawing.Point(409, 37);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(320, 20);
            this.cdvFlow.TabIndex = 4;
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
            this.cdvResID.Location = new System.Drawing.Point(118, 61);
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
            this.cdvResID.TabIndex = 0;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResID_TextBoxKeyPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(118, 85);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(611, 20);
            this.txtDesc.TabIndex = 2;
            this.txtDesc.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(13, 88);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 1;
            this.lblDesc.Text = "Description";
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabResStatus);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 116);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlTab.Size = new System.Drawing.Size(742, 397);
            this.pnlTab.TabIndex = 1;
            // 
            // tabResStatus
            // 
            this.tabResStatus.Controls.Add(this.tbpGeneral);
            this.tabResStatus.Controls.Add(this.tbpLotList);
            this.tabResStatus.Controls.Add(this.tbpResSts);
            this.tabResStatus.Controls.Add(this.tbpResGrp);
            this.tabResStatus.Controls.Add(this.tbpAttribute);
            this.tabResStatus.Controls.Add(this.tbpCMF);
            this.tabResStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResStatus.ItemSize = new System.Drawing.Size(60, 18);
            this.tabResStatus.Location = new System.Drawing.Point(3, 5);
            this.tabResStatus.Name = "tabResStatus";
            this.tabResStatus.SelectedIndex = 0;
            this.tabResStatus.Size = new System.Drawing.Size(736, 389);
            this.tabResStatus.TabIndex = 0;
            this.tabResStatus.TabStop = false;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(728, 363);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.chkRegisterAlarm);
            this.grpGeneral.Controls.Add(this.txtProcCount);
            this.grpGeneral.Controls.Add(this.txtLastEnd);
            this.grpGeneral.Controls.Add(this.lblLastHistSeq);
            this.grpGeneral.Controls.Add(this.lblActiveHistSeq);
            this.grpGeneral.Controls.Add(this.lblLastEventTime);
            this.grpGeneral.Controls.Add(this.lblLastEvent);
            this.grpGeneral.Controls.Add(this.txtLastHistSeq);
            this.grpGeneral.Controls.Add(this.txtLastEventTime);
            this.grpGeneral.Controls.Add(this.txtLastActHistSeq);
            this.grpGeneral.Controls.Add(this.txtLastEvent);
            this.grpGeneral.Controls.Add(this.txtLastStart);
            this.grpGeneral.Controls.Add(this.lblLastEnd);
            this.grpGeneral.Controls.Add(this.lblLastStart);
            this.grpGeneral.Controls.Add(this.lblProcCount);
            this.grpGeneral.Controls.Add(this.txtPriStatus);
            this.grpGeneral.Controls.Add(this.lblPriSts);
            this.grpGeneral.Controls.Add(this.txtUpDownFlag);
            this.grpGeneral.Controls.Add(this.lblUpDownFlag);
            this.grpGeneral.Controls.Add(this.txtDelTime);
            this.grpGeneral.Controls.Add(this.lblDelTime);
            this.grpGeneral.Controls.Add(this.txtDelUser);
            this.grpGeneral.Controls.Add(this.lblDelUserID);
            this.grpGeneral.Controls.Add(this.chkResDelFlag);
            this.grpGeneral.Controls.Add(this.chkSecChkFlag);
            this.grpGeneral.Controls.Add(this.chkUnitBaseStFlag);
            this.grpGeneral.Controls.Add(this.chkPMSchEnableFlag);
            this.grpGeneral.Controls.Add(this.txtSubAreaID);
            this.grpGeneral.Controls.Add(this.txtAreaId);
            this.grpGeneral.Controls.Add(this.txtProcMode);
            this.grpGeneral.Controls.Add(this.txtResType);
            this.grpGeneral.Controls.Add(this.txtProcRule);
            this.grpGeneral.Controls.Add(this.lblUpdateTime);
            this.grpGeneral.Controls.Add(this.lblUpdateUser);
            this.grpGeneral.Controls.Add(this.lblCreateTime);
            this.grpGeneral.Controls.Add(this.lblCreateUser);
            this.grpGeneral.Controls.Add(this.txtUpdateTime);
            this.grpGeneral.Controls.Add(this.txtCreateTime);
            this.grpGeneral.Controls.Add(this.txtUpdateUser);
            this.grpGeneral.Controls.Add(this.txtCreateUser);
            this.grpGeneral.Controls.Add(this.txtLocation);
            this.grpGeneral.Controls.Add(this.txtMaxProcCount);
            this.grpGeneral.Controls.Add(this.txtCtrlMode);
            this.grpGeneral.Controls.Add(this.lblProcMode);
            this.grpGeneral.Controls.Add(this.lblLocation);
            this.grpGeneral.Controls.Add(this.lblSubAreaID);
            this.grpGeneral.Controls.Add(this.lblAreaID);
            this.grpGeneral.Controls.Add(this.lblMaxProcCount);
            this.grpGeneral.Controls.Add(this.lblProcRule);
            this.grpGeneral.Controls.Add(this.lblCtrlMode);
            this.grpGeneral.Controls.Add(this.lblResType);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(722, 360);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // chkRegisterAlarm
            // 
            this.chkRegisterAlarm.AutoSize = true;
            this.chkRegisterAlarm.Enabled = false;
            this.chkRegisterAlarm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRegisterAlarm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkRegisterAlarm.Location = new System.Drawing.Point(548, 115);
            this.chkRegisterAlarm.Name = "chkRegisterAlarm";
            this.chkRegisterAlarm.Size = new System.Drawing.Size(164, 18);
            this.chkRegisterAlarm.TabIndex = 50;
            this.chkRegisterAlarm.Text = "Register Alarm automatically";
            // 
            // txtProcCount
            // 
            this.txtProcCount.Location = new System.Drawing.Point(120, 64);
            this.txtProcCount.MaxLength = 3;
            this.txtProcCount.Name = "txtProcCount";
            this.txtProcCount.ReadOnly = true;
            this.txtProcCount.Size = new System.Drawing.Size(152, 20);
            this.txtProcCount.TabIndex = 5;
            this.txtProcCount.TabStop = false;
            // 
            // txtLastEnd
            // 
            this.txtLastEnd.Location = new System.Drawing.Point(388, 40);
            this.txtLastEnd.MaxLength = 30;
            this.txtLastEnd.Name = "txtLastEnd";
            this.txtLastEnd.ReadOnly = true;
            this.txtLastEnd.Size = new System.Drawing.Size(152, 20);
            this.txtLastEnd.TabIndex = 25;
            this.txtLastEnd.TabStop = false;
            // 
            // lblLastHistSeq
            // 
            this.lblLastHistSeq.AutoSize = true;
            this.lblLastHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastHistSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastHistSeq.Location = new System.Drawing.Point(280, 139);
            this.lblLastHistSeq.Name = "lblLastHistSeq";
            this.lblLastHistSeq.Size = new System.Drawing.Size(70, 13);
            this.lblLastHistSeq.TabIndex = 32;
            this.lblLastHistSeq.Text = "Last Hist Seq";
            // 
            // lblActiveHistSeq
            // 
            this.lblActiveHistSeq.AutoSize = true;
            this.lblActiveHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActiveHistSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblActiveHistSeq.Location = new System.Drawing.Point(280, 115);
            this.lblActiveHistSeq.Name = "lblActiveHistSeq";
            this.lblActiveHistSeq.Size = new System.Drawing.Size(89, 13);
            this.lblActiveHistSeq.TabIndex = 30;
            this.lblActiveHistSeq.Text = "Last Act Hist Seq";
            // 
            // lblLastEventTime
            // 
            this.lblLastEventTime.AutoSize = true;
            this.lblLastEventTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEventTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastEventTime.Location = new System.Drawing.Point(280, 91);
            this.lblLastEventTime.Name = "lblLastEventTime";
            this.lblLastEventTime.Size = new System.Drawing.Size(84, 13);
            this.lblLastEventTime.TabIndex = 28;
            this.lblLastEventTime.Text = "Last Event Time";
            // 
            // lblLastEvent
            // 
            this.lblLastEvent.AutoSize = true;
            this.lblLastEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEvent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastEvent.Location = new System.Drawing.Point(280, 67);
            this.lblLastEvent.Name = "lblLastEvent";
            this.lblLastEvent.Size = new System.Drawing.Size(58, 13);
            this.lblLastEvent.TabIndex = 26;
            this.lblLastEvent.Text = "Last Event";
            // 
            // txtLastHistSeq
            // 
            this.txtLastHistSeq.Location = new System.Drawing.Point(388, 136);
            this.txtLastHistSeq.MaxLength = 10;
            this.txtLastHistSeq.Name = "txtLastHistSeq";
            this.txtLastHistSeq.ReadOnly = true;
            this.txtLastHistSeq.Size = new System.Drawing.Size(152, 20);
            this.txtLastHistSeq.TabIndex = 33;
            this.txtLastHistSeq.TabStop = false;
            // 
            // txtLastEventTime
            // 
            this.txtLastEventTime.Location = new System.Drawing.Point(388, 88);
            this.txtLastEventTime.MaxLength = 30;
            this.txtLastEventTime.Name = "txtLastEventTime";
            this.txtLastEventTime.ReadOnly = true;
            this.txtLastEventTime.Size = new System.Drawing.Size(152, 20);
            this.txtLastEventTime.TabIndex = 29;
            this.txtLastEventTime.TabStop = false;
            // 
            // txtLastActHistSeq
            // 
            this.txtLastActHistSeq.Location = new System.Drawing.Point(388, 112);
            this.txtLastActHistSeq.MaxLength = 10;
            this.txtLastActHistSeq.Name = "txtLastActHistSeq";
            this.txtLastActHistSeq.ReadOnly = true;
            this.txtLastActHistSeq.Size = new System.Drawing.Size(152, 20);
            this.txtLastActHistSeq.TabIndex = 31;
            this.txtLastActHistSeq.TabStop = false;
            // 
            // txtLastEvent
            // 
            this.txtLastEvent.Location = new System.Drawing.Point(388, 64);
            this.txtLastEvent.MaxLength = 12;
            this.txtLastEvent.Name = "txtLastEvent";
            this.txtLastEvent.ReadOnly = true;
            this.txtLastEvent.Size = new System.Drawing.Size(152, 20);
            this.txtLastEvent.TabIndex = 27;
            this.txtLastEvent.TabStop = false;
            // 
            // txtLastStart
            // 
            this.txtLastStart.Location = new System.Drawing.Point(388, 16);
            this.txtLastStart.MaxLength = 30;
            this.txtLastStart.Name = "txtLastStart";
            this.txtLastStart.ReadOnly = true;
            this.txtLastStart.Size = new System.Drawing.Size(152, 20);
            this.txtLastStart.TabIndex = 23;
            this.txtLastStart.TabStop = false;
            // 
            // lblLastEnd
            // 
            this.lblLastEnd.AutoSize = true;
            this.lblLastEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastEnd.Location = new System.Drawing.Point(280, 43);
            this.lblLastEnd.Name = "lblLastEnd";
            this.lblLastEnd.Size = new System.Drawing.Size(75, 13);
            this.lblLastEnd.TabIndex = 24;
            this.lblLastEnd.Text = "Last End Time";
            // 
            // lblLastStart
            // 
            this.lblLastStart.AutoSize = true;
            this.lblLastStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastStart.Location = new System.Drawing.Point(280, 19);
            this.lblLastStart.Name = "lblLastStart";
            this.lblLastStart.Size = new System.Drawing.Size(78, 13);
            this.lblLastStart.TabIndex = 22;
            this.lblLastStart.Text = "Last Start Time";
            // 
            // lblProcCount
            // 
            this.lblProcCount.AutoSize = true;
            this.lblProcCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcCount.Location = new System.Drawing.Point(12, 67);
            this.lblProcCount.Name = "lblProcCount";
            this.lblProcCount.Size = new System.Drawing.Size(60, 13);
            this.lblProcCount.TabIndex = 4;
            this.lblProcCount.Text = "Proc Count";
            // 
            // txtPriStatus
            // 
            this.txtPriStatus.Location = new System.Drawing.Point(120, 16);
            this.txtPriStatus.MaxLength = 30;
            this.txtPriStatus.Name = "txtPriStatus";
            this.txtPriStatus.ReadOnly = true;
            this.txtPriStatus.Size = new System.Drawing.Size(152, 20);
            this.txtPriStatus.TabIndex = 1;
            this.txtPriStatus.TabStop = false;
            // 
            // lblPriSts
            // 
            this.lblPriSts.AutoSize = true;
            this.lblPriSts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPriSts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPriSts.Location = new System.Drawing.Point(12, 19);
            this.lblPriSts.Name = "lblPriSts";
            this.lblPriSts.Size = new System.Drawing.Size(86, 13);
            this.lblPriSts.TabIndex = 0;
            this.lblPriSts.Text = "Resource Status";
            // 
            // txtUpDownFlag
            // 
            this.txtUpDownFlag.Location = new System.Drawing.Point(120, 40);
            this.txtUpDownFlag.MaxLength = 2;
            this.txtUpDownFlag.Name = "txtUpDownFlag";
            this.txtUpDownFlag.ReadOnly = true;
            this.txtUpDownFlag.Size = new System.Drawing.Size(152, 20);
            this.txtUpDownFlag.TabIndex = 3;
            this.txtUpDownFlag.TabStop = false;
            // 
            // lblUpDownFlag
            // 
            this.lblUpDownFlag.AutoSize = true;
            this.lblUpDownFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpDownFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpDownFlag.Location = new System.Drawing.Point(12, 43);
            this.lblUpDownFlag.Name = "lblUpDownFlag";
            this.lblUpDownFlag.Size = new System.Drawing.Size(75, 13);
            this.lblUpDownFlag.TabIndex = 2;
            this.lblUpDownFlag.Text = "Up Down Flag";
            // 
            // txtDelTime
            // 
            this.txtDelTime.Location = new System.Drawing.Point(388, 184);
            this.txtDelTime.Name = "txtDelTime";
            this.txtDelTime.ReadOnly = true;
            this.txtDelTime.Size = new System.Drawing.Size(152, 20);
            this.txtDelTime.TabIndex = 37;
            this.txtDelTime.TabStop = false;
            // 
            // lblDelTime
            // 
            this.lblDelTime.AutoSize = true;
            this.lblDelTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDelTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDelTime.Location = new System.Drawing.Point(280, 187);
            this.lblDelTime.Name = "lblDelTime";
            this.lblDelTime.Size = new System.Drawing.Size(86, 13);
            this.lblDelTime.TabIndex = 36;
            this.lblDelTime.Text = "Res Delete Time";
            // 
            // txtDelUser
            // 
            this.txtDelUser.Location = new System.Drawing.Point(388, 160);
            this.txtDelUser.MaxLength = 20;
            this.txtDelUser.Name = "txtDelUser";
            this.txtDelUser.ReadOnly = true;
            this.txtDelUser.Size = new System.Drawing.Size(152, 20);
            this.txtDelUser.TabIndex = 35;
            this.txtDelUser.TabStop = false;
            // 
            // lblDelUserID
            // 
            this.lblDelUserID.AutoSize = true;
            this.lblDelUserID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDelUserID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDelUserID.Location = new System.Drawing.Point(280, 163);
            this.lblDelUserID.Name = "lblDelUserID";
            this.lblDelUserID.Size = new System.Drawing.Size(85, 13);
            this.lblDelUserID.TabIndex = 34;
            this.lblDelUserID.Text = "Res Delete User";
            // 
            // chkResDelFlag
            // 
            this.chkResDelFlag.AutoSize = true;
            this.chkResDelFlag.Enabled = false;
            this.chkResDelFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkResDelFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkResDelFlag.Location = new System.Drawing.Point(548, 19);
            this.chkResDelFlag.Name = "chkResDelFlag";
            this.chkResDelFlag.Size = new System.Drawing.Size(135, 18);
            this.chkResDelFlag.TabIndex = 46;
            this.chkResDelFlag.TabStop = false;
            this.chkResDelFlag.Text = "Resource Delete Flag";
            // 
            // chkSecChkFlag
            // 
            this.chkSecChkFlag.AutoSize = true;
            this.chkSecChkFlag.Enabled = false;
            this.chkSecChkFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSecChkFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSecChkFlag.Location = new System.Drawing.Point(548, 91);
            this.chkSecChkFlag.Name = "chkSecChkFlag";
            this.chkSecChkFlag.Size = new System.Drawing.Size(127, 18);
            this.chkSecChkFlag.TabIndex = 49;
            this.chkSecChkFlag.TabStop = false;
            this.chkSecChkFlag.Text = "Security Check Flag";
            // 
            // chkUnitBaseStFlag
            // 
            this.chkUnitBaseStFlag.AutoSize = true;
            this.chkUnitBaseStFlag.Enabled = false;
            this.chkUnitBaseStFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUnitBaseStFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUnitBaseStFlag.Location = new System.Drawing.Point(548, 67);
            this.chkUnitBaseStFlag.Name = "chkUnitBaseStFlag";
            this.chkUnitBaseStFlag.Size = new System.Drawing.Size(147, 18);
            this.chkUnitBaseStFlag.TabIndex = 48;
            this.chkUnitBaseStFlag.TabStop = false;
            this.chkUnitBaseStFlag.Text = "Unit Base Standard Flag";
            // 
            // chkPMSchEnableFlag
            // 
            this.chkPMSchEnableFlag.AutoSize = true;
            this.chkPMSchEnableFlag.Enabled = false;
            this.chkPMSchEnableFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkPMSchEnableFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPMSchEnableFlag.Location = new System.Drawing.Point(548, 43);
            this.chkPMSchEnableFlag.Name = "chkPMSchEnableFlag";
            this.chkPMSchEnableFlag.Size = new System.Drawing.Size(155, 18);
            this.chkPMSchEnableFlag.TabIndex = 47;
            this.chkPMSchEnableFlag.TabStop = false;
            this.chkPMSchEnableFlag.Text = "PM Schedule Enable Flag";
            // 
            // txtSubAreaID
            // 
            this.txtSubAreaID.Location = new System.Drawing.Point(120, 208);
            this.txtSubAreaID.MaxLength = 20;
            this.txtSubAreaID.Name = "txtSubAreaID";
            this.txtSubAreaID.ReadOnly = true;
            this.txtSubAreaID.Size = new System.Drawing.Size(152, 20);
            this.txtSubAreaID.TabIndex = 17;
            this.txtSubAreaID.TabStop = false;
            // 
            // txtAreaId
            // 
            this.txtAreaId.Location = new System.Drawing.Point(120, 184);
            this.txtAreaId.MaxLength = 20;
            this.txtAreaId.Name = "txtAreaId";
            this.txtAreaId.ReadOnly = true;
            this.txtAreaId.Size = new System.Drawing.Size(152, 20);
            this.txtAreaId.TabIndex = 15;
            this.txtAreaId.TabStop = false;
            // 
            // txtProcMode
            // 
            this.txtProcMode.Location = new System.Drawing.Point(120, 256);
            this.txtProcMode.MaxLength = 10;
            this.txtProcMode.Name = "txtProcMode";
            this.txtProcMode.ReadOnly = true;
            this.txtProcMode.Size = new System.Drawing.Size(152, 20);
            this.txtProcMode.TabIndex = 21;
            this.txtProcMode.TabStop = false;
            // 
            // txtResType
            // 
            this.txtResType.Location = new System.Drawing.Point(120, 88);
            this.txtResType.MaxLength = 20;
            this.txtResType.Name = "txtResType";
            this.txtResType.ReadOnly = true;
            this.txtResType.Size = new System.Drawing.Size(152, 20);
            this.txtResType.TabIndex = 7;
            this.txtResType.TabStop = false;
            // 
            // txtProcRule
            // 
            this.txtProcRule.Location = new System.Drawing.Point(120, 136);
            this.txtProcRule.MaxLength = 6;
            this.txtProcRule.Name = "txtProcRule";
            this.txtProcRule.ReadOnly = true;
            this.txtProcRule.Size = new System.Drawing.Size(152, 20);
            this.txtProcRule.TabIndex = 11;
            this.txtProcRule.TabStop = false;
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(280, 283);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 44;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(280, 259);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 42;
            this.lblUpdateUser.Text = "Update User";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(280, 235);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 40;
            this.lblCreateTime.Text = "Create Time";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(280, 211);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 38;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(388, 280);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(152, 20);
            this.txtUpdateTime.TabIndex = 45;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(388, 232);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(152, 20);
            this.txtCreateTime.TabIndex = 41;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(388, 256);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(152, 20);
            this.txtUpdateUser.TabIndex = 43;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(388, 208);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(152, 20);
            this.txtCreateUser.TabIndex = 39;
            this.txtCreateUser.TabStop = false;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(120, 232);
            this.txtLocation.MaxLength = 20;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(152, 20);
            this.txtLocation.TabIndex = 19;
            this.txtLocation.TabStop = false;
            // 
            // txtMaxProcCount
            // 
            this.txtMaxProcCount.Location = new System.Drawing.Point(120, 160);
            this.txtMaxProcCount.MaxLength = 3;
            this.txtMaxProcCount.Name = "txtMaxProcCount";
            this.txtMaxProcCount.ReadOnly = true;
            this.txtMaxProcCount.Size = new System.Drawing.Size(152, 20);
            this.txtMaxProcCount.TabIndex = 13;
            this.txtMaxProcCount.TabStop = false;
            // 
            // txtCtrlMode
            // 
            this.txtCtrlMode.Location = new System.Drawing.Point(120, 112);
            this.txtCtrlMode.MaxLength = 12;
            this.txtCtrlMode.Name = "txtCtrlMode";
            this.txtCtrlMode.ReadOnly = true;
            this.txtCtrlMode.Size = new System.Drawing.Size(152, 20);
            this.txtCtrlMode.TabIndex = 9;
            this.txtCtrlMode.TabStop = false;
            // 
            // lblProcMode
            // 
            this.lblProcMode.AutoSize = true;
            this.lblProcMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcMode.Location = new System.Drawing.Point(12, 259);
            this.lblProcMode.Name = "lblProcMode";
            this.lblProcMode.Size = new System.Drawing.Size(75, 13);
            this.lblProcMode.TabIndex = 20;
            this.lblProcMode.Text = "Process Mode";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation.Location = new System.Drawing.Point(12, 235);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 18;
            this.lblLocation.Text = "Location";
            // 
            // lblSubAreaID
            // 
            this.lblSubAreaID.AutoSize = true;
            this.lblSubAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubAreaID.Location = new System.Drawing.Point(12, 211);
            this.lblSubAreaID.Name = "lblSubAreaID";
            this.lblSubAreaID.Size = new System.Drawing.Size(65, 13);
            this.lblSubAreaID.TabIndex = 16;
            this.lblSubAreaID.Text = "Sub Area ID";
            // 
            // lblAreaID
            // 
            this.lblAreaID.AutoSize = true;
            this.lblAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAreaID.Location = new System.Drawing.Point(12, 187);
            this.lblAreaID.Name = "lblAreaID";
            this.lblAreaID.Size = new System.Drawing.Size(43, 13);
            this.lblAreaID.TabIndex = 14;
            this.lblAreaID.Text = "Area ID";
            // 
            // lblMaxProcCount
            // 
            this.lblMaxProcCount.AutoSize = true;
            this.lblMaxProcCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxProcCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxProcCount.Location = new System.Drawing.Point(12, 163);
            this.lblMaxProcCount.Name = "lblMaxProcCount";
            this.lblMaxProcCount.Size = new System.Drawing.Size(83, 13);
            this.lblMaxProcCount.TabIndex = 12;
            this.lblMaxProcCount.Text = "Max Proc Count";
            // 
            // lblProcRule
            // 
            this.lblProcRule.AutoSize = true;
            this.lblProcRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcRule.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcRule.Location = new System.Drawing.Point(12, 139);
            this.lblProcRule.Name = "lblProcRule";
            this.lblProcRule.Size = new System.Drawing.Size(70, 13);
            this.lblProcRule.TabIndex = 10;
            this.lblProcRule.Text = "Process Rule";
            // 
            // lblCtrlMode
            // 
            this.lblCtrlMode.AutoSize = true;
            this.lblCtrlMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCtrlMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCtrlMode.Location = new System.Drawing.Point(12, 115);
            this.lblCtrlMode.Name = "lblCtrlMode";
            this.lblCtrlMode.Size = new System.Drawing.Size(70, 13);
            this.lblCtrlMode.TabIndex = 8;
            this.lblCtrlMode.Text = "Control Mode";
            // 
            // lblResType
            // 
            this.lblResType.AutoSize = true;
            this.lblResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResType.Location = new System.Drawing.Point(12, 91);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(80, 13);
            this.lblResType.TabIndex = 6;
            this.lblResType.Text = "Resource Type";
            // 
            // tbpLotList
            // 
            this.tbpLotList.Controls.Add(this.grpLotList);
            this.tbpLotList.Location = new System.Drawing.Point(4, 22);
            this.tbpLotList.Name = "tbpLotList";
            this.tbpLotList.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpLotList.Size = new System.Drawing.Size(728, 363);
            this.tbpLotList.TabIndex = 4;
            this.tbpLotList.Text = "Lot List";
            // 
            // grpLotList
            // 
            this.grpLotList.Controls.Add(this.spdLot);
            this.grpLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotList.Location = new System.Drawing.Point(3, 0);
            this.grpLotList.Name = "grpLotList";
            this.grpLotList.Size = new System.Drawing.Size(722, 360);
            this.grpLotList.TabIndex = 0;
            this.grpLotList.TabStop = false;
            // 
            // spdLot
            // 
            this.spdLot.AccessibleDescription = "spdLot, Sheet1";
            this.spdLot.BackColor = System.Drawing.SystemColors.Control;
            this.spdLot.ContextMenu = this.ctxCopyMenu;
            this.spdLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLot.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLot.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLot.HorizontalScrollBar.Name = "";
            this.spdLot.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLot.HorizontalScrollBar.TabIndex = 2;
            this.spdLot.Location = new System.Drawing.Point(3, 16);
            this.spdLot.Name = "spdLot";
            this.spdLot.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdLot.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdLot.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLot_Sheet1});
            this.spdLot.Size = new System.Drawing.Size(716, 341);
            this.spdLot.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLot.TabIndex = 0;
            this.spdLot.TabStop = false;
            this.spdLot.TextTipDelay = 200;
            this.spdLot.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdLot.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLot.VerticalScrollBar.Name = "";
            this.spdLot.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLot.VerticalScrollBar.TabIndex = 3;
            this.spdLot.SetActiveViewport(0, -1, -1);
            // 
            // ctxCopyMenu
            // 
            this.ctxCopyMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ctxCopy});
            // 
            // ctxCopy
            // 
            this.ctxCopy.Index = 0;
            this.ctxCopy.Text = "Copy";
            this.ctxCopy.Click += new System.EventHandler(this.ctxCopy_Click);
            // 
            // spdLot_Sheet1
            // 
            this.spdLot_Sheet1.Reset();
            spdLot_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLot_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLot_Sheet1.ColumnCount = 15;
            spdLot_Sheet1.RowCount = 0;
            this.spdLot_Sheet1.ActiveColumnIndex = -1;
            this.spdLot_Sheet1.ActiveRowIndex = -1;
            this.spdLot_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLot_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLot_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLot_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Lot ID";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot Status";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Mat ID";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat Ver";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Flow";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Flow Seq Num";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Oper";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Qty1";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Qty2";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Qty3";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Lot Type";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Lot Priority";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Create Code";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Owner Code";
            this.spdLot_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Hold Code";
            this.spdLot_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLot_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLot_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdLot_Sheet1.Columns.Get(0).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(0).Label = "Lot ID";
            this.spdLot_Sheet1.Columns.Get(0).Locked = true;
            this.spdLot_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(0).Width = 100F;
            this.spdLot_Sheet1.Columns.Get(1).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(1).Label = "Lot Status";
            this.spdLot_Sheet1.Columns.Get(1).Locked = true;
            this.spdLot_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(1).Width = 73F;
            this.spdLot_Sheet1.Columns.Get(2).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(2).Label = "Mat ID";
            this.spdLot_Sheet1.Columns.Get(2).Locked = true;
            this.spdLot_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(2).Width = 115F;
            this.spdLot_Sheet1.Columns.Get(3).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(3).Label = "Mat Ver";
            this.spdLot_Sheet1.Columns.Get(3).Locked = true;
            this.spdLot_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(3).Width = 70F;
            this.spdLot_Sheet1.Columns.Get(4).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(4).Label = "Flow";
            this.spdLot_Sheet1.Columns.Get(4).Locked = true;
            this.spdLot_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(4).Width = 112F;
            this.spdLot_Sheet1.Columns.Get(5).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(5).Label = "Flow Seq Num";
            this.spdLot_Sheet1.Columns.Get(5).Locked = true;
            this.spdLot_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(5).Width = 100F;
            this.spdLot_Sheet1.Columns.Get(6).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(6).Label = "Oper";
            this.spdLot_Sheet1.Columns.Get(6).Locked = true;
            this.spdLot_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(6).Width = 77F;
            this.spdLot_Sheet1.Columns.Get(7).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLot_Sheet1.Columns.Get(7).Label = "Qty1";
            this.spdLot_Sheet1.Columns.Get(7).Locked = true;
            this.spdLot_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(8).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLot_Sheet1.Columns.Get(8).Label = "Qty2";
            this.spdLot_Sheet1.Columns.Get(8).Locked = true;
            this.spdLot_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(9).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLot_Sheet1.Columns.Get(9).Label = "Qty3";
            this.spdLot_Sheet1.Columns.Get(9).Locked = true;
            this.spdLot_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(10).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(10).Label = "Lot Type";
            this.spdLot_Sheet1.Columns.Get(10).Locked = true;
            this.spdLot_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(10).Width = 57F;
            this.spdLot_Sheet1.Columns.Get(11).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdLot_Sheet1.Columns.Get(11).Label = "Lot Priority";
            this.spdLot_Sheet1.Columns.Get(11).Locked = true;
            this.spdLot_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(11).Width = 61F;
            this.spdLot_Sheet1.Columns.Get(12).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(12).Label = "Create Code";
            this.spdLot_Sheet1.Columns.Get(12).Locked = true;
            this.spdLot_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(12).Width = 90F;
            this.spdLot_Sheet1.Columns.Get(13).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(13).Label = "Owner Code";
            this.spdLot_Sheet1.Columns.Get(13).Locked = true;
            this.spdLot_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(13).Width = 90F;
            this.spdLot_Sheet1.Columns.Get(14).AllowAutoSort = true;
            this.spdLot_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdLot_Sheet1.Columns.Get(14).Label = "Hold Code";
            this.spdLot_Sheet1.Columns.Get(14).Locked = true;
            this.spdLot_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdLot_Sheet1.Columns.Get(14).Width = 90F;
            this.spdLot_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdLot_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLot_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLot_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLot_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLot_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdLot_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpResSts
            // 
            this.tbpResSts.Controls.Add(this.grpResStatus);
            this.tbpResSts.Location = new System.Drawing.Point(4, 22);
            this.tbpResSts.Name = "tbpResSts";
            this.tbpResSts.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpResSts.Size = new System.Drawing.Size(728, 363);
            this.tbpResSts.TabIndex = 3;
            this.tbpResSts.Text = "Resource Status";
            // 
            // grpResStatus
            // 
            this.grpResStatus.Controls.Add(this.chkUseFacPrtFlag);
            this.grpResStatus.Controls.Add(this.txtSts10);
            this.grpResStatus.Controls.Add(this.txtSts9);
            this.grpResStatus.Controls.Add(this.txtSts8);
            this.grpResStatus.Controls.Add(this.txtSts7);
            this.grpResStatus.Controls.Add(this.txtSts6);
            this.grpResStatus.Controls.Add(this.txtSts5);
            this.grpResStatus.Controls.Add(this.txtSts4);
            this.grpResStatus.Controls.Add(this.txtSts3);
            this.grpResStatus.Controls.Add(this.txtSts2);
            this.grpResStatus.Controls.Add(this.txtSts1);
            this.grpResStatus.Controls.Add(this.lblSts10);
            this.grpResStatus.Controls.Add(this.lblSts9);
            this.grpResStatus.Controls.Add(this.lblSts8);
            this.grpResStatus.Controls.Add(this.lblSts7);
            this.grpResStatus.Controls.Add(this.lblSts6);
            this.grpResStatus.Controls.Add(this.lblSts5);
            this.grpResStatus.Controls.Add(this.lblSts4);
            this.grpResStatus.Controls.Add(this.lblSts3);
            this.grpResStatus.Controls.Add(this.lblSts2);
            this.grpResStatus.Controls.Add(this.lblSts1);
            this.grpResStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResStatus.Location = new System.Drawing.Point(3, 0);
            this.grpResStatus.Name = "grpResStatus";
            this.grpResStatus.Size = new System.Drawing.Size(722, 360);
            this.grpResStatus.TabIndex = 0;
            this.grpResStatus.TabStop = false;
            // 
            // chkUseFacPrtFlag
            // 
            this.chkUseFacPrtFlag.AutoSize = true;
            this.chkUseFacPrtFlag.Enabled = false;
            this.chkUseFacPrtFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUseFacPrtFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUseFacPrtFlag.Location = new System.Drawing.Point(15, 19);
            this.chkUseFacPrtFlag.Name = "chkUseFacPrtFlag";
            this.chkUseFacPrtFlag.Size = new System.Drawing.Size(148, 18);
            this.chkUseFacPrtFlag.TabIndex = 0;
            this.chkUseFacPrtFlag.TabStop = false;
            this.chkUseFacPrtFlag.Text = "Use Factory Prompt Flag";
            // 
            // txtSts10
            // 
            this.txtSts10.Location = new System.Drawing.Point(172, 256);
            this.txtSts10.MaxLength = 30;
            this.txtSts10.Name = "txtSts10";
            this.txtSts10.ReadOnly = true;
            this.txtSts10.Size = new System.Drawing.Size(200, 20);
            this.txtSts10.TabIndex = 20;
            this.txtSts10.TabStop = false;
            // 
            // txtSts9
            // 
            this.txtSts9.Location = new System.Drawing.Point(172, 232);
            this.txtSts9.MaxLength = 30;
            this.txtSts9.Name = "txtSts9";
            this.txtSts9.ReadOnly = true;
            this.txtSts9.Size = new System.Drawing.Size(200, 20);
            this.txtSts9.TabIndex = 18;
            this.txtSts9.TabStop = false;
            // 
            // txtSts8
            // 
            this.txtSts8.Location = new System.Drawing.Point(172, 208);
            this.txtSts8.MaxLength = 30;
            this.txtSts8.Name = "txtSts8";
            this.txtSts8.ReadOnly = true;
            this.txtSts8.Size = new System.Drawing.Size(200, 20);
            this.txtSts8.TabIndex = 16;
            this.txtSts8.TabStop = false;
            // 
            // txtSts7
            // 
            this.txtSts7.Location = new System.Drawing.Point(172, 184);
            this.txtSts7.MaxLength = 30;
            this.txtSts7.Name = "txtSts7";
            this.txtSts7.ReadOnly = true;
            this.txtSts7.Size = new System.Drawing.Size(200, 20);
            this.txtSts7.TabIndex = 14;
            this.txtSts7.TabStop = false;
            // 
            // txtSts6
            // 
            this.txtSts6.Location = new System.Drawing.Point(172, 160);
            this.txtSts6.MaxLength = 30;
            this.txtSts6.Name = "txtSts6";
            this.txtSts6.ReadOnly = true;
            this.txtSts6.Size = new System.Drawing.Size(200, 20);
            this.txtSts6.TabIndex = 12;
            this.txtSts6.TabStop = false;
            // 
            // txtSts5
            // 
            this.txtSts5.Location = new System.Drawing.Point(172, 136);
            this.txtSts5.MaxLength = 30;
            this.txtSts5.Name = "txtSts5";
            this.txtSts5.ReadOnly = true;
            this.txtSts5.Size = new System.Drawing.Size(200, 20);
            this.txtSts5.TabIndex = 10;
            this.txtSts5.TabStop = false;
            // 
            // txtSts4
            // 
            this.txtSts4.Location = new System.Drawing.Point(172, 112);
            this.txtSts4.MaxLength = 30;
            this.txtSts4.Name = "txtSts4";
            this.txtSts4.ReadOnly = true;
            this.txtSts4.Size = new System.Drawing.Size(200, 20);
            this.txtSts4.TabIndex = 8;
            this.txtSts4.TabStop = false;
            // 
            // txtSts3
            // 
            this.txtSts3.Location = new System.Drawing.Point(172, 88);
            this.txtSts3.MaxLength = 30;
            this.txtSts3.Name = "txtSts3";
            this.txtSts3.ReadOnly = true;
            this.txtSts3.Size = new System.Drawing.Size(200, 20);
            this.txtSts3.TabIndex = 6;
            this.txtSts3.TabStop = false;
            // 
            // txtSts2
            // 
            this.txtSts2.Location = new System.Drawing.Point(172, 64);
            this.txtSts2.MaxLength = 30;
            this.txtSts2.Name = "txtSts2";
            this.txtSts2.ReadOnly = true;
            this.txtSts2.Size = new System.Drawing.Size(200, 20);
            this.txtSts2.TabIndex = 4;
            this.txtSts2.TabStop = false;
            // 
            // txtSts1
            // 
            this.txtSts1.Location = new System.Drawing.Point(172, 40);
            this.txtSts1.MaxLength = 30;
            this.txtSts1.Name = "txtSts1";
            this.txtSts1.ReadOnly = true;
            this.txtSts1.Size = new System.Drawing.Size(200, 20);
            this.txtSts1.TabIndex = 2;
            this.txtSts1.TabStop = false;
            // 
            // lblSts10
            // 
            this.lblSts10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSts10.Location = new System.Drawing.Point(16, 259);
            this.lblSts10.Name = "lblSts10";
            this.lblSts10.Size = new System.Drawing.Size(150, 14);
            this.lblSts10.TabIndex = 19;
            // 
            // lblSts9
            // 
            this.lblSts9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSts9.Location = new System.Drawing.Point(16, 235);
            this.lblSts9.Name = "lblSts9";
            this.lblSts9.Size = new System.Drawing.Size(150, 14);
            this.lblSts9.TabIndex = 17;
            // 
            // lblSts8
            // 
            this.lblSts8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSts8.Location = new System.Drawing.Point(16, 211);
            this.lblSts8.Name = "lblSts8";
            this.lblSts8.Size = new System.Drawing.Size(150, 14);
            this.lblSts8.TabIndex = 15;
            // 
            // lblSts7
            // 
            this.lblSts7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSts7.Location = new System.Drawing.Point(16, 187);
            this.lblSts7.Name = "lblSts7";
            this.lblSts7.Size = new System.Drawing.Size(150, 14);
            this.lblSts7.TabIndex = 13;
            // 
            // lblSts6
            // 
            this.lblSts6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSts6.Location = new System.Drawing.Point(16, 163);
            this.lblSts6.Name = "lblSts6";
            this.lblSts6.Size = new System.Drawing.Size(150, 14);
            this.lblSts6.TabIndex = 11;
            // 
            // lblSts5
            // 
            this.lblSts5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSts5.Location = new System.Drawing.Point(16, 139);
            this.lblSts5.Name = "lblSts5";
            this.lblSts5.Size = new System.Drawing.Size(150, 14);
            this.lblSts5.TabIndex = 9;
            // 
            // lblSts4
            // 
            this.lblSts4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSts4.Location = new System.Drawing.Point(16, 115);
            this.lblSts4.Name = "lblSts4";
            this.lblSts4.Size = new System.Drawing.Size(150, 14);
            this.lblSts4.TabIndex = 7;
            // 
            // lblSts3
            // 
            this.lblSts3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSts3.Location = new System.Drawing.Point(16, 91);
            this.lblSts3.Name = "lblSts3";
            this.lblSts3.Size = new System.Drawing.Size(150, 14);
            this.lblSts3.TabIndex = 5;
            // 
            // lblSts2
            // 
            this.lblSts2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSts2.Location = new System.Drawing.Point(16, 67);
            this.lblSts2.Name = "lblSts2";
            this.lblSts2.Size = new System.Drawing.Size(150, 14);
            this.lblSts2.TabIndex = 3;
            // 
            // lblSts1
            // 
            this.lblSts1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSts1.Location = new System.Drawing.Point(15, 43);
            this.lblSts1.Name = "lblSts1";
            this.lblSts1.Size = new System.Drawing.Size(150, 14);
            this.lblSts1.TabIndex = 1;
            // 
            // tbpResGrp
            // 
            this.tbpResGrp.Controls.Add(this.grpGrp);
            this.tbpResGrp.Location = new System.Drawing.Point(4, 22);
            this.tbpResGrp.Name = "tbpResGrp";
            this.tbpResGrp.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpResGrp.Size = new System.Drawing.Size(728, 363);
            this.tbpResGrp.TabIndex = 1;
            this.tbpResGrp.Text = "Resource Group";
            // 
            // grpGrp
            // 
            this.grpGrp.Controls.Add(this.txtGrp10);
            this.grpGrp.Controls.Add(this.txtGrp9);
            this.grpGrp.Controls.Add(this.txtGrp8);
            this.grpGrp.Controls.Add(this.txtGrp7);
            this.grpGrp.Controls.Add(this.txtGrp6);
            this.grpGrp.Controls.Add(this.txtGrp5);
            this.grpGrp.Controls.Add(this.txtGrp4);
            this.grpGrp.Controls.Add(this.txtGrp3);
            this.grpGrp.Controls.Add(this.txtGrp2);
            this.grpGrp.Controls.Add(this.txtGrp1);
            this.grpGrp.Controls.Add(this.lblGrp10);
            this.grpGrp.Controls.Add(this.lblGrp9);
            this.grpGrp.Controls.Add(this.lblGrp8);
            this.grpGrp.Controls.Add(this.lblGrp7);
            this.grpGrp.Controls.Add(this.lblGrp6);
            this.grpGrp.Controls.Add(this.lblGrp5);
            this.grpGrp.Controls.Add(this.lblGrp4);
            this.grpGrp.Controls.Add(this.lblGrp3);
            this.grpGrp.Controls.Add(this.lblGrp2);
            this.grpGrp.Controls.Add(this.lblGrp1);
            this.grpGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGrp.Location = new System.Drawing.Point(3, 0);
            this.grpGrp.Name = "grpGrp";
            this.grpGrp.Size = new System.Drawing.Size(722, 360);
            this.grpGrp.TabIndex = 0;
            this.grpGrp.TabStop = false;
            // 
            // txtGrp10
            // 
            this.txtGrp10.Location = new System.Drawing.Point(172, 232);
            this.txtGrp10.MaxLength = 30;
            this.txtGrp10.Name = "txtGrp10";
            this.txtGrp10.ReadOnly = true;
            this.txtGrp10.Size = new System.Drawing.Size(200, 20);
            this.txtGrp10.TabIndex = 19;
            this.txtGrp10.TabStop = false;
            // 
            // txtGrp9
            // 
            this.txtGrp9.Location = new System.Drawing.Point(172, 208);
            this.txtGrp9.MaxLength = 30;
            this.txtGrp9.Name = "txtGrp9";
            this.txtGrp9.ReadOnly = true;
            this.txtGrp9.Size = new System.Drawing.Size(200, 20);
            this.txtGrp9.TabIndex = 17;
            this.txtGrp9.TabStop = false;
            // 
            // txtGrp8
            // 
            this.txtGrp8.Location = new System.Drawing.Point(172, 184);
            this.txtGrp8.MaxLength = 30;
            this.txtGrp8.Name = "txtGrp8";
            this.txtGrp8.ReadOnly = true;
            this.txtGrp8.Size = new System.Drawing.Size(200, 20);
            this.txtGrp8.TabIndex = 15;
            this.txtGrp8.TabStop = false;
            // 
            // txtGrp7
            // 
            this.txtGrp7.Location = new System.Drawing.Point(172, 160);
            this.txtGrp7.MaxLength = 30;
            this.txtGrp7.Name = "txtGrp7";
            this.txtGrp7.ReadOnly = true;
            this.txtGrp7.Size = new System.Drawing.Size(200, 20);
            this.txtGrp7.TabIndex = 13;
            this.txtGrp7.TabStop = false;
            // 
            // txtGrp6
            // 
            this.txtGrp6.Location = new System.Drawing.Point(172, 136);
            this.txtGrp6.MaxLength = 30;
            this.txtGrp6.Name = "txtGrp6";
            this.txtGrp6.ReadOnly = true;
            this.txtGrp6.Size = new System.Drawing.Size(200, 20);
            this.txtGrp6.TabIndex = 11;
            this.txtGrp6.TabStop = false;
            // 
            // txtGrp5
            // 
            this.txtGrp5.Location = new System.Drawing.Point(172, 112);
            this.txtGrp5.MaxLength = 30;
            this.txtGrp5.Name = "txtGrp5";
            this.txtGrp5.ReadOnly = true;
            this.txtGrp5.Size = new System.Drawing.Size(200, 20);
            this.txtGrp5.TabIndex = 9;
            this.txtGrp5.TabStop = false;
            // 
            // txtGrp4
            // 
            this.txtGrp4.Location = new System.Drawing.Point(172, 88);
            this.txtGrp4.MaxLength = 30;
            this.txtGrp4.Name = "txtGrp4";
            this.txtGrp4.ReadOnly = true;
            this.txtGrp4.Size = new System.Drawing.Size(200, 20);
            this.txtGrp4.TabIndex = 7;
            this.txtGrp4.TabStop = false;
            // 
            // txtGrp3
            // 
            this.txtGrp3.Location = new System.Drawing.Point(172, 64);
            this.txtGrp3.MaxLength = 30;
            this.txtGrp3.Name = "txtGrp3";
            this.txtGrp3.ReadOnly = true;
            this.txtGrp3.Size = new System.Drawing.Size(200, 20);
            this.txtGrp3.TabIndex = 5;
            this.txtGrp3.TabStop = false;
            // 
            // txtGrp2
            // 
            this.txtGrp2.Location = new System.Drawing.Point(172, 40);
            this.txtGrp2.MaxLength = 30;
            this.txtGrp2.Name = "txtGrp2";
            this.txtGrp2.ReadOnly = true;
            this.txtGrp2.Size = new System.Drawing.Size(200, 20);
            this.txtGrp2.TabIndex = 3;
            this.txtGrp2.TabStop = false;
            // 
            // txtGrp1
            // 
            this.txtGrp1.Location = new System.Drawing.Point(172, 16);
            this.txtGrp1.MaxLength = 30;
            this.txtGrp1.Name = "txtGrp1";
            this.txtGrp1.ReadOnly = true;
            this.txtGrp1.Size = new System.Drawing.Size(200, 20);
            this.txtGrp1.TabIndex = 1;
            this.txtGrp1.TabStop = false;
            // 
            // lblGrp10
            // 
            this.lblGrp10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp10.Location = new System.Drawing.Point(15, 235);
            this.lblGrp10.Name = "lblGrp10";
            this.lblGrp10.Size = new System.Drawing.Size(150, 14);
            this.lblGrp10.TabIndex = 18;
            // 
            // lblGrp9
            // 
            this.lblGrp9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp9.Location = new System.Drawing.Point(15, 211);
            this.lblGrp9.Name = "lblGrp9";
            this.lblGrp9.Size = new System.Drawing.Size(150, 14);
            this.lblGrp9.TabIndex = 16;
            // 
            // lblGrp8
            // 
            this.lblGrp8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp8.Location = new System.Drawing.Point(15, 187);
            this.lblGrp8.Name = "lblGrp8";
            this.lblGrp8.Size = new System.Drawing.Size(150, 14);
            this.lblGrp8.TabIndex = 14;
            // 
            // lblGrp7
            // 
            this.lblGrp7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp7.Location = new System.Drawing.Point(15, 163);
            this.lblGrp7.Name = "lblGrp7";
            this.lblGrp7.Size = new System.Drawing.Size(150, 14);
            this.lblGrp7.TabIndex = 12;
            // 
            // lblGrp6
            // 
            this.lblGrp6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp6.Location = new System.Drawing.Point(15, 139);
            this.lblGrp6.Name = "lblGrp6";
            this.lblGrp6.Size = new System.Drawing.Size(150, 14);
            this.lblGrp6.TabIndex = 10;
            // 
            // lblGrp5
            // 
            this.lblGrp5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp5.Location = new System.Drawing.Point(15, 115);
            this.lblGrp5.Name = "lblGrp5";
            this.lblGrp5.Size = new System.Drawing.Size(150, 14);
            this.lblGrp5.TabIndex = 8;
            // 
            // lblGrp4
            // 
            this.lblGrp4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp4.Location = new System.Drawing.Point(15, 91);
            this.lblGrp4.Name = "lblGrp4";
            this.lblGrp4.Size = new System.Drawing.Size(150, 14);
            this.lblGrp4.TabIndex = 6;
            // 
            // lblGrp3
            // 
            this.lblGrp3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp3.Location = new System.Drawing.Point(15, 67);
            this.lblGrp3.Name = "lblGrp3";
            this.lblGrp3.Size = new System.Drawing.Size(150, 14);
            this.lblGrp3.TabIndex = 4;
            // 
            // lblGrp2
            // 
            this.lblGrp2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp2.Location = new System.Drawing.Point(15, 43);
            this.lblGrp2.Name = "lblGrp2";
            this.lblGrp2.Size = new System.Drawing.Size(150, 14);
            this.lblGrp2.TabIndex = 2;
            // 
            // lblGrp1
            // 
            this.lblGrp1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrp1.Location = new System.Drawing.Point(15, 19);
            this.lblGrp1.Name = "lblGrp1";
            this.lblGrp1.Size = new System.Drawing.Size(150, 14);
            this.lblGrp1.TabIndex = 0;
            // 
            // tbpAttribute
            // 
            this.tbpAttribute.Controls.Add(this.udcAttributeStatus);
            this.tbpAttribute.Location = new System.Drawing.Point(4, 22);
            this.tbpAttribute.Name = "tbpAttribute";
            this.tbpAttribute.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAttribute.Size = new System.Drawing.Size(728, 363);
            this.tbpAttribute.TabIndex = 5;
            this.tbpAttribute.Text = "Attribute";
            // 
            // udcAttributeStatus
            // 
            this.udcAttributeStatus.AttributeKey = "";
            this.udcAttributeStatus.AttributeLayout = Miracom.BASCore.udcAttributeStatus.udcAttributeStatusLayout.VIEW;
            this.udcAttributeStatus.AttributeName = "";
            this.udcAttributeStatus.AttributeType = "RESOURCE";
            this.udcAttributeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcAttributeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcAttributeStatus.FromSequence = 0;
            this.udcAttributeStatus.Location = new System.Drawing.Point(3, 3);
            this.udcAttributeStatus.Name = "udcAttributeStatus";
            this.udcAttributeStatus.Size = new System.Drawing.Size(722, 357);
            this.udcAttributeStatus.TabIndex = 1;
            this.udcAttributeStatus.ToSequence = 2147483647;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCMF.Size = new System.Drawing.Size(728, 363);
            this.tbpCMF.TabIndex = 2;
            this.tbpCMF.Text = "Customized Field";
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.txtCMF20);
            this.grpCMF.Controls.Add(this.txtCMF19);
            this.grpCMF.Controls.Add(this.txtCMF18);
            this.grpCMF.Controls.Add(this.txtCMF17);
            this.grpCMF.Controls.Add(this.txtCMF16);
            this.grpCMF.Controls.Add(this.txtCMF15);
            this.grpCMF.Controls.Add(this.txtCMF14);
            this.grpCMF.Controls.Add(this.txtCMF13);
            this.grpCMF.Controls.Add(this.txtCMF12);
            this.grpCMF.Controls.Add(this.txtCMF11);
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
            this.grpCMF.Controls.Add(this.txtCMF10);
            this.grpCMF.Controls.Add(this.txtCMF9);
            this.grpCMF.Controls.Add(this.txtCMF8);
            this.grpCMF.Controls.Add(this.txtCMF7);
            this.grpCMF.Controls.Add(this.txtCMF6);
            this.grpCMF.Controls.Add(this.txtCMF5);
            this.grpCMF.Controls.Add(this.txtCMF4);
            this.grpCMF.Controls.Add(this.txtCMF3);
            this.grpCMF.Controls.Add(this.txtCMF2);
            this.grpCMF.Controls.Add(this.txtCMF1);
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
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.Location = new System.Drawing.Point(3, 0);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(722, 360);
            this.grpCMF.TabIndex = 0;
            this.grpCMF.TabStop = false;
            // 
            // txtCMF20
            // 
            this.txtCMF20.Location = new System.Drawing.Point(516, 232);
            this.txtCMF20.MaxLength = 30;
            this.txtCMF20.Name = "txtCMF20";
            this.txtCMF20.ReadOnly = true;
            this.txtCMF20.Size = new System.Drawing.Size(200, 20);
            this.txtCMF20.TabIndex = 39;
            this.txtCMF20.TabStop = false;
            // 
            // txtCMF19
            // 
            this.txtCMF19.Location = new System.Drawing.Point(516, 208);
            this.txtCMF19.MaxLength = 30;
            this.txtCMF19.Name = "txtCMF19";
            this.txtCMF19.ReadOnly = true;
            this.txtCMF19.Size = new System.Drawing.Size(200, 20);
            this.txtCMF19.TabIndex = 37;
            this.txtCMF19.TabStop = false;
            // 
            // txtCMF18
            // 
            this.txtCMF18.Location = new System.Drawing.Point(516, 184);
            this.txtCMF18.MaxLength = 30;
            this.txtCMF18.Name = "txtCMF18";
            this.txtCMF18.ReadOnly = true;
            this.txtCMF18.Size = new System.Drawing.Size(200, 20);
            this.txtCMF18.TabIndex = 35;
            this.txtCMF18.TabStop = false;
            // 
            // txtCMF17
            // 
            this.txtCMF17.Location = new System.Drawing.Point(516, 160);
            this.txtCMF17.MaxLength = 30;
            this.txtCMF17.Name = "txtCMF17";
            this.txtCMF17.ReadOnly = true;
            this.txtCMF17.Size = new System.Drawing.Size(200, 20);
            this.txtCMF17.TabIndex = 33;
            this.txtCMF17.TabStop = false;
            // 
            // txtCMF16
            // 
            this.txtCMF16.Location = new System.Drawing.Point(516, 136);
            this.txtCMF16.MaxLength = 30;
            this.txtCMF16.Name = "txtCMF16";
            this.txtCMF16.ReadOnly = true;
            this.txtCMF16.Size = new System.Drawing.Size(200, 20);
            this.txtCMF16.TabIndex = 31;
            this.txtCMF16.TabStop = false;
            // 
            // txtCMF15
            // 
            this.txtCMF15.Location = new System.Drawing.Point(516, 112);
            this.txtCMF15.MaxLength = 30;
            this.txtCMF15.Name = "txtCMF15";
            this.txtCMF15.ReadOnly = true;
            this.txtCMF15.Size = new System.Drawing.Size(200, 20);
            this.txtCMF15.TabIndex = 29;
            this.txtCMF15.TabStop = false;
            // 
            // txtCMF14
            // 
            this.txtCMF14.Location = new System.Drawing.Point(516, 88);
            this.txtCMF14.MaxLength = 30;
            this.txtCMF14.Name = "txtCMF14";
            this.txtCMF14.ReadOnly = true;
            this.txtCMF14.Size = new System.Drawing.Size(200, 20);
            this.txtCMF14.TabIndex = 27;
            this.txtCMF14.TabStop = false;
            // 
            // txtCMF13
            // 
            this.txtCMF13.Location = new System.Drawing.Point(516, 64);
            this.txtCMF13.MaxLength = 30;
            this.txtCMF13.Name = "txtCMF13";
            this.txtCMF13.ReadOnly = true;
            this.txtCMF13.Size = new System.Drawing.Size(200, 20);
            this.txtCMF13.TabIndex = 25;
            this.txtCMF13.TabStop = false;
            // 
            // txtCMF12
            // 
            this.txtCMF12.Location = new System.Drawing.Point(516, 40);
            this.txtCMF12.MaxLength = 30;
            this.txtCMF12.Name = "txtCMF12";
            this.txtCMF12.ReadOnly = true;
            this.txtCMF12.Size = new System.Drawing.Size(200, 20);
            this.txtCMF12.TabIndex = 23;
            this.txtCMF12.TabStop = false;
            // 
            // txtCMF11
            // 
            this.txtCMF11.Location = new System.Drawing.Point(516, 16);
            this.txtCMF11.MaxLength = 30;
            this.txtCMF11.Name = "txtCMF11";
            this.txtCMF11.ReadOnly = true;
            this.txtCMF11.Size = new System.Drawing.Size(200, 20);
            this.txtCMF11.TabIndex = 21;
            this.txtCMF11.TabStop = false;
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.Location = new System.Drawing.Point(370, 235);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(140, 14);
            this.lblCMF20.TabIndex = 38;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.Location = new System.Drawing.Point(370, 211);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(140, 14);
            this.lblCMF19.TabIndex = 36;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.Location = new System.Drawing.Point(370, 187);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(140, 14);
            this.lblCMF18.TabIndex = 34;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.Location = new System.Drawing.Point(370, 163);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(140, 14);
            this.lblCMF17.TabIndex = 32;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.Location = new System.Drawing.Point(370, 139);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(140, 14);
            this.lblCMF16.TabIndex = 30;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.Location = new System.Drawing.Point(370, 115);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(140, 14);
            this.lblCMF15.TabIndex = 28;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.Location = new System.Drawing.Point(370, 91);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(140, 14);
            this.lblCMF14.TabIndex = 26;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.Location = new System.Drawing.Point(370, 67);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(140, 14);
            this.lblCMF13.TabIndex = 24;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.Location = new System.Drawing.Point(370, 43);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(140, 14);
            this.lblCMF12.TabIndex = 22;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.Location = new System.Drawing.Point(369, 19);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(140, 14);
            this.lblCMF11.TabIndex = 20;
            // 
            // txtCMF10
            // 
            this.txtCMF10.Location = new System.Drawing.Point(153, 232);
            this.txtCMF10.MaxLength = 30;
            this.txtCMF10.Name = "txtCMF10";
            this.txtCMF10.ReadOnly = true;
            this.txtCMF10.Size = new System.Drawing.Size(200, 20);
            this.txtCMF10.TabIndex = 19;
            this.txtCMF10.TabStop = false;
            // 
            // txtCMF9
            // 
            this.txtCMF9.Location = new System.Drawing.Point(153, 208);
            this.txtCMF9.MaxLength = 30;
            this.txtCMF9.Name = "txtCMF9";
            this.txtCMF9.ReadOnly = true;
            this.txtCMF9.Size = new System.Drawing.Size(200, 20);
            this.txtCMF9.TabIndex = 17;
            this.txtCMF9.TabStop = false;
            // 
            // txtCMF8
            // 
            this.txtCMF8.Location = new System.Drawing.Point(153, 184);
            this.txtCMF8.MaxLength = 30;
            this.txtCMF8.Name = "txtCMF8";
            this.txtCMF8.ReadOnly = true;
            this.txtCMF8.Size = new System.Drawing.Size(200, 20);
            this.txtCMF8.TabIndex = 15;
            this.txtCMF8.TabStop = false;
            // 
            // txtCMF7
            // 
            this.txtCMF7.Location = new System.Drawing.Point(153, 160);
            this.txtCMF7.MaxLength = 30;
            this.txtCMF7.Name = "txtCMF7";
            this.txtCMF7.ReadOnly = true;
            this.txtCMF7.Size = new System.Drawing.Size(200, 20);
            this.txtCMF7.TabIndex = 13;
            this.txtCMF7.TabStop = false;
            // 
            // txtCMF6
            // 
            this.txtCMF6.Location = new System.Drawing.Point(153, 136);
            this.txtCMF6.MaxLength = 30;
            this.txtCMF6.Name = "txtCMF6";
            this.txtCMF6.ReadOnly = true;
            this.txtCMF6.Size = new System.Drawing.Size(200, 20);
            this.txtCMF6.TabIndex = 11;
            this.txtCMF6.TabStop = false;
            // 
            // txtCMF5
            // 
            this.txtCMF5.Location = new System.Drawing.Point(153, 112);
            this.txtCMF5.MaxLength = 30;
            this.txtCMF5.Name = "txtCMF5";
            this.txtCMF5.ReadOnly = true;
            this.txtCMF5.Size = new System.Drawing.Size(200, 20);
            this.txtCMF5.TabIndex = 9;
            this.txtCMF5.TabStop = false;
            // 
            // txtCMF4
            // 
            this.txtCMF4.Location = new System.Drawing.Point(153, 88);
            this.txtCMF4.MaxLength = 30;
            this.txtCMF4.Name = "txtCMF4";
            this.txtCMF4.ReadOnly = true;
            this.txtCMF4.Size = new System.Drawing.Size(200, 20);
            this.txtCMF4.TabIndex = 7;
            this.txtCMF4.TabStop = false;
            // 
            // txtCMF3
            // 
            this.txtCMF3.Location = new System.Drawing.Point(153, 64);
            this.txtCMF3.MaxLength = 30;
            this.txtCMF3.Name = "txtCMF3";
            this.txtCMF3.ReadOnly = true;
            this.txtCMF3.Size = new System.Drawing.Size(200, 20);
            this.txtCMF3.TabIndex = 5;
            this.txtCMF3.TabStop = false;
            // 
            // txtCMF2
            // 
            this.txtCMF2.Location = new System.Drawing.Point(153, 40);
            this.txtCMF2.MaxLength = 30;
            this.txtCMF2.Name = "txtCMF2";
            this.txtCMF2.ReadOnly = true;
            this.txtCMF2.Size = new System.Drawing.Size(200, 20);
            this.txtCMF2.TabIndex = 3;
            this.txtCMF2.TabStop = false;
            // 
            // txtCMF1
            // 
            this.txtCMF1.Location = new System.Drawing.Point(153, 16);
            this.txtCMF1.MaxLength = 30;
            this.txtCMF1.Name = "txtCMF1";
            this.txtCMF1.ReadOnly = true;
            this.txtCMF1.Size = new System.Drawing.Size(200, 20);
            this.txtCMF1.TabIndex = 1;
            this.txtCMF1.TabStop = false;
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(7, 235);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCMF10.TabIndex = 18;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(7, 211);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCMF9.TabIndex = 16;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(7, 187);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCMF8.TabIndex = 14;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(7, 163);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCMF7.TabIndex = 12;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(7, 139);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCMF6.TabIndex = 10;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(7, 115);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCMF5.TabIndex = 8;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(7, 91);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCMF4.TabIndex = 6;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(7, 67);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCMF3.TabIndex = 4;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(7, 43);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCMF2.TabIndex = 2;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(6, 19);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCMF1.TabIndex = 0;
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(555, 7);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(88, 26);
            this.btnHistory.TabIndex = 1;
            this.btnHistory.Text = "History";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // frmRASViewResourceStatus
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.pnlGrp);
            this.Name = "frmRASViewResourceStatus";
            this.Text = "View Resource Status";
            this.Activated += new System.EventHandler(this.frmRASViewResourceStatus_Activated);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlGrp, 0);
            this.Controls.SetChildIndex(this.pnlTab, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrp.ResumeLayout(false);
            this.pnlGrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).EndInit();
            this.grpRes.ResumeLayout(false);
            this.grpRes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlTab.ResumeLayout(false);
            this.tabResStatus.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.tbpLotList.ResumeLayout(false);
            this.grpLotList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLot_Sheet1)).EndInit();
            this.tbpResSts.ResumeLayout(false);
            this.grpResStatus.ResumeLayout(false);
            this.grpResStatus.PerformLayout();
            this.tbpResGrp.ResumeLayout(false);
            this.grpGrp.ResumeLayout(false);
            this.grpGrp.PerformLayout();
            this.tbpAttribute.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            this.grpCMF.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        private bool b_load_flag;
        #endregion
        
        #region " Event Definition "
        
        private void frmRASViewResourceStatus_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                spdLot.Sheets[0].SetColumnAllowAutoSort(0, 13, true);
                cdvResID.Focus();
                InitControl("lblSts", "txtSts", grpResStatus);
                InitControl("lblGrp", "txtGrp", grpGrp);
                InitControl("lblCMF", "txtCMF", grpCMF);

                ActiveFormNow();

                if (MPCF.Trim(cdvResID.Text) != "")
                    View_Resource();
                b_load_flag = true;
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (View_Resource() == false)
            {
                return;
            }
            if (RASLIST.ViewResLotList(spdLot, '1', cdvResID.Text, null, "") == false)
            {
                return;
            }
        }
        
        private void cdvResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (View_Resource() == false)
            {
                return;
            }
            if (RASLIST.ViewResLotList(spdLot, '1', cdvResID.Text, null, "") == false)
            {
                return;
            }
        }
        
        private void cdvResID_ButtonPress(System.Object sender, System.EventArgs e)
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
        
        private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            InitControl("lblSts", "txtSts", grpResStatus);
            InitControl("lblGrp", "txtGrp", grpGrp);
            InitControl("lblCMF", "txtCMF", grpCMF);
        }

        private void cdvResID_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            MPCF.FieldClear(this, cdvResID, false);
        } 

        private void ctxCopy_Click(System.Object sender, System.EventArgs e)
        {
            spdLot_Sheet1.ClipboardCopy();
        }
        
        #endregion
        
        #region " Function Definition "
        // View_Resource()
        //       -  View Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool View_Resource()
        {
            TRSNode in_node = new TRSNode("View_Resource_In");
            TRSNode out_node = new TRSNode("View_Resource_Out");
              
            
            try
            {
                MPCF.FieldClear(this.tbpGeneral);
                MPCF.FieldClear(this.tbpAttribute);
                MPCF.FieldClear(this.tbpCMF);
                MPCF.FieldClear(this.tbpLotList);
                MPCF.FieldClear(this.tbpResGrp);
                MPCF.FieldClear(this.tbpResSts);

                InitControl("lblSts", "txtSts", grpResStatus);
                InitControl("lblGrp", "txtGrp", grpGrp);
                InitControl("lblCMF", "txtCMF", grpCMF);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", cdvResID.Text);

                if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }
                SetGroupCmfItem();

                txtDesc.Text = out_node.GetString("RES_DESC");
                txtResType.Text = out_node.GetString("RES_TYPE");
                switch (out_node.GetChar("PROC_RULE"))
                {
                    case MPGC.MP_RAS_PROC_RULE_C_SERIAL:
                        txtProcRule.Text = MPGC.MP_RAS_PROC_RULE_SERIAL;
                        break;
                    case MPGC.MP_RAS_PROC_RULE_C_BATCH:
                        txtProcRule.Text = MPGC.MP_RAS_PROC_RULE_BATCH;
                        break;
                    default:
                        txtProcRule.Text = MPGC.MP_RAS_PROC_RULE_NORMAL;
                        break;
                }
                txtMaxProcCount.Text = MPCF.Trim(out_node.GetInt("MAX_PROC_COUNT"));
                txtProcMode.Text = MPCF.Trim(out_node.GetString("RES_PROC_MODE"));
                if (out_node.GetString("RES_CTRL_MODE").Equals(MPGC.MP_RAS_CTRL_MODE_S_ONLINELOCAL))
                {
                    txtCtrlMode.Text = MPGC.MP_RAS_CTRL_MODE_ONLINELOCAL;
                }
                else if (out_node.GetString("RES_CTRL_MODE").Equals(MPGC.MP_RAS_CTRL_MODE_S_ONLINEREMOTE))
                {
                    txtCtrlMode.Text = MPGC.MP_RAS_CTRL_MODE_ONLINEREMOTE;
                }
                else if (out_node.GetString("RES_CTRL_MODE").Equals(MPGC.MP_RAS_CTRL_MODE_S_OFFLINE))
                {
                    txtCtrlMode.Text = MPGC.MP_RAS_CTRL_MODE_OFFLINE;
                }
                
                txtAreaId.Text = MPCF.Trim(out_node.GetString("AREA_ID"));
                txtSubAreaID.Text = MPCF.Trim(out_node.GetString("SUB_AREA_ID"));
                txtLocation.Text = MPCF.Trim(out_node.GetString("RES_LOCATION"));
                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                txtDelUser.Text = MPCF.Trim(out_node.GetString("DELETE_USER_ID"));
                txtDelTime.Text = MPCF.MakeDateFormat(out_node.GetString("DELETE_TIME"));
                if (MPCF.Trim(out_node.GetChar("RES_UP_DOWN_FLAG")) == "U")
                {
                    txtUpDownFlag.Text = "UP";
                }
                else if (MPCF.Trim(out_node.GetChar("RES_UP_DOWN_FLAG")) == "D")
                {
                    txtUpDownFlag.Text = "DOWN";
                }
                txtPriStatus.Text = MPCF.Trim(out_node.GetString("RES_PRI_STS"));
                txtProcCount.Text = MPCF.Trim(out_node.GetInt("PROC_COUNT"));
                txtLastStart.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_START_TIME"));
                txtLastEnd.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_END_TIME"));
                txtLastEvent.Text = MPCF.Trim(out_node.GetString("LAST_EVENT_ID"));
                txtLastEventTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_EVENT_TIME"));
                txtLastHistSeq.Text = MPCF.Trim(out_node.GetInt("LAST_HIST_SEQ"));
                txtLastActHistSeq.Text = MPCF.Trim(out_node.GetInt("LAST_ACTIVE_HIST_SEQ"));
                if (MPCF.Trim(out_node.GetChar("DELETE_FLAG")) == "Y")
                {
                    chkResDelFlag.Checked = true;
                }
                else
                {
                    chkResDelFlag.Checked = false;
                }
                if (MPCF.Trim(out_node.GetChar("PM_SCH_ENABLE_FLAG")) == "Y")
                {
                    chkPMSchEnableFlag.Checked = true;
                }
                else
                {
                    chkPMSchEnableFlag.Checked = false;
                }
                
                if (MPCF.Trim(out_node.GetChar("UNIT_BASE_ST_FLAG")) == "Y")
                {
                    chkUnitBaseStFlag.Checked = true;
                }
                else
                {
                    chkUnitBaseStFlag.Checked = false;
                }
                
                if (MPCF.Trim(out_node.GetChar("SEC_CHK_FLAG")) == "Y")
                {
                    chkSecChkFlag.Checked = true;
                }
                else
                {
                    chkSecChkFlag.Checked = false;
                }
                if (MPCF.Trim(out_node.GetChar("AUTO_GATHER_ALARM")) == "Y")
                {
                    chkRegisterAlarm.Checked = true;
                }
                else
                {
                    chkRegisterAlarm.Checked = false;
                }
                if (MPCF.Trim(out_node.GetChar("USE_FAC_PRT_FLAG")) == "Y")
                {
                    chkUseFacPrtFlag.Checked = true;
                }
                else
                {
                    chkUseFacPrtFlag.Checked = false;
                }
                
                
                
                txtGrp1.Text = MPCF.Trim(out_node.GetString("RES_GRP_1"));
                txtGrp2.Text = MPCF.Trim(out_node.GetString("RES_GRP_2"));
                txtGrp3.Text = MPCF.Trim(out_node.GetString("RES_GRP_3"));
                txtGrp4.Text = MPCF.Trim(out_node.GetString("RES_GRP_4"));
                txtGrp5.Text = MPCF.Trim(out_node.GetString("RES_GRP_5"));
                txtGrp6.Text = MPCF.Trim(out_node.GetString("RES_GRP_6"));
                txtGrp7.Text = MPCF.Trim(out_node.GetString("RES_GRP_7"));
                txtGrp8.Text = MPCF.Trim(out_node.GetString("RES_GRP_8"));
                txtGrp9.Text = MPCF.Trim(out_node.GetString("RES_GRP_9"));
                txtGrp10.Text = MPCF.Trim(out_node.GetString("RES_GRP_10"));
                
                txtCMF1.Text = MPCF.Trim(out_node.GetString("RES_CMF_1"));
                txtCMF2.Text = MPCF.Trim(out_node.GetString("RES_CMF_2"));
                txtCMF3.Text = MPCF.Trim(out_node.GetString("RES_CMF_3"));
                txtCMF4.Text = MPCF.Trim(out_node.GetString("RES_CMF_4"));
                txtCMF5.Text = MPCF.Trim(out_node.GetString("RES_CMF_5"));
                txtCMF6.Text = MPCF.Trim(out_node.GetString("RES_CMF_6"));
                txtCMF7.Text = MPCF.Trim(out_node.GetString("RES_CMF_7"));
                txtCMF8.Text = MPCF.Trim(out_node.GetString("RES_CMF_8"));
                txtCMF9.Text = MPCF.Trim(out_node.GetString("RES_CMF_9"));
                txtCMF10.Text = MPCF.Trim(out_node.GetString("RES_CMF_10"));
                txtCMF11.Text = MPCF.Trim(out_node.GetString("RES_CMF_11"));
                txtCMF12.Text = MPCF.Trim(out_node.GetString("RES_CMF_12"));
                txtCMF13.Text = MPCF.Trim(out_node.GetString("RES_CMF_13"));
                txtCMF14.Text = MPCF.Trim(out_node.GetString("RES_CMF_14"));
                txtCMF15.Text = MPCF.Trim(out_node.GetString("RES_CMF_15"));
                txtCMF16.Text = MPCF.Trim(out_node.GetString("RES_CMF_16"));
                txtCMF17.Text = MPCF.Trim(out_node.GetString("RES_CMF_17"));
                txtCMF18.Text = MPCF.Trim(out_node.GetString("RES_CMF_18"));
                txtCMF19.Text = MPCF.Trim(out_node.GetString("RES_CMF_19"));
                txtCMF20.Text = MPCF.Trim(out_node.GetString("RES_CMF_20"));
                


                if (out_node.GetChar("USE_FAC_PRT_FLAG") != 'Y')
                {
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_1")) != "")
                    {
                        lblSts1.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_1"));
                        lblSts1.Visible = true;
                        txtSts1.Visible = true;
                    }
                    else
                    {
                        lblSts1.Visible = false;
                        txtSts1.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_2")) != "")
                    {
                        lblSts2.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_2"));
                        lblSts2.Visible = true;
                        txtSts2.Visible = true;
                    }
                    else
                    {
                        lblSts2.Visible = false;
                        txtSts2.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_3")) != "")
                    {
                        lblSts3.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_3"));
                        lblSts3.Visible = true;
                        txtSts3.Visible = true;
                    }
                    else
                    {
                        lblSts3.Visible = false;
                        txtSts3.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_4")) != "")
                    {
                        lblSts4.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_4"));
                        lblSts4.Visible = true;
                        txtSts4.Visible = true;
                    }
                    else
                    {
                        lblSts4.Visible = false;
                        txtSts4.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_5")) != "")
                    {
                        lblSts5.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_5"));
                        lblSts5.Visible = true;
                        txtSts5.Visible = true;
                    }
                    else
                    {
                        lblSts5.Visible = false;
                        txtSts5.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_6")) != "")
                    {
                        lblSts6.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_6"));
                        lblSts6.Visible = true;
                        txtSts6.Visible = true;
                    }
                    else
                    {
                        lblSts6.Visible = false;
                        txtSts6.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_7")) != "")
                    {
                        lblSts7.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_7"));
                        lblSts7.Visible = true;
                        txtSts7.Visible = true;
                    }
                    else
                    {
                        lblSts7.Visible = false;
                        txtSts7.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_8")) != "")
                    {
                        lblSts8.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_8"));
                        lblSts8.Visible = true;
                        txtSts8.Visible = true;
                    }
                    else
                    {
                        lblSts8.Visible = false;
                        txtSts8.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_9")) != "")
                    {
                        lblSts9.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_9"));
                        lblSts9.Visible = true;
                        txtSts9.Visible = true;
                    }
                    else
                    {
                        lblSts9.Visible = false;
                        txtSts9.Visible = false;
                    }
                    if (MPCF.Trim(out_node.GetString("RES_STS_PRT_10")) != "")
                    {
                        lblSts10.Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_10"));
                        lblSts10.Visible = true;
                        txtSts10.Visible = true;
                    }
                    else
                    {
                        lblSts10.Visible = false;
                        txtSts10.Visible = false;
                    }
                }
                else
                {
                    View_Factory_ResStatus();
                }
                
                txtSts1.Text = MPCF.Trim(out_node.GetString("RES_STS_1"));
                txtSts2.Text = MPCF.Trim(out_node.GetString("RES_STS_2"));
                txtSts3.Text = MPCF.Trim(out_node.GetString("RES_STS_3"));
                txtSts4.Text = MPCF.Trim(out_node.GetString("RES_STS_4"));
                txtSts5.Text = MPCF.Trim(out_node.GetString("RES_STS_5"));
                txtSts6.Text = MPCF.Trim(out_node.GetString("RES_STS_6"));
                txtSts7.Text = MPCF.Trim(out_node.GetString("RES_STS_7"));
                txtSts8.Text = MPCF.Trim(out_node.GetString("RES_STS_8"));
                txtSts9.Text = MPCF.Trim(out_node.GetString("RES_STS_9"));
                txtSts10.Text = MPCF.Trim(out_node.GetString("RES_STS_10"));

                udcAttributeStatus.AttributeKey = cdvResID.Text;
                udcAttributeStatus.View();
                
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
                    lblSts1.Text = MPCF.Trim(out_node.GetString("RES_STS_1"));
                    lblSts1.Visible = true;
                    txtSts1.Visible = true;
                }
                else
                {
                    lblSts1.Visible = false;
                    txtSts1.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_2")) != "")
                {
                    lblSts2.Text = MPCF.Trim(out_node.GetString("RES_STS_2"));
                    lblSts2.Visible = true;
                    txtSts2.Visible = true;
                }
                else
                {
                    lblSts2.Visible = false;
                    txtSts2.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_3")) != "")
                {
                    lblSts3.Text = MPCF.Trim(out_node.GetString("RES_STS_3"));
                    lblSts3.Visible = true;
                    txtSts3.Visible = true;
                }
                else
                {
                    lblSts3.Visible = false;
                    txtSts3.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_4")) != "")
                {
                    lblSts4.Text = MPCF.Trim(out_node.GetString("RES_STS_4"));
                    lblSts4.Visible = true;
                    txtSts4.Visible = true;
                }
                else
                {
                    lblSts4.Visible = false;
                    txtSts4.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_5")) != "")
                {
                    lblSts5.Text = MPCF.Trim(out_node.GetString("RES_STS_5"));
                    lblSts5.Visible = true;
                    txtSts5.Visible = true;
                }
                else
                {
                    lblSts5.Visible = false;
                    txtSts5.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_6")) != "")
                {
                    lblSts6.Text = MPCF.Trim(out_node.GetString("RES_STS_6"));
                    lblSts6.Visible = true;
                    txtSts6.Visible = true;
                }
                else
                {
                    lblSts6.Visible = false;
                    txtSts6.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_7")) != "")
                {
                    lblSts7.Text = MPCF.Trim(out_node.GetString("RES_STS_7"));
                    lblSts7.Visible = true;
                    txtSts7.Visible = true;
                }
                else
                {
                    lblSts7.Visible = false;
                    txtSts7.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_8")) != "")
                {
                    lblSts8.Text = MPCF.Trim(out_node.GetString("RES_STS_8"));
                    lblSts8.Visible = true;
                    txtSts8.Visible = true;
                }
                else
                {
                    lblSts8.Visible = false;
                    txtSts8.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_9")) != "")
                {
                    lblSts9.Text = MPCF.Trim(out_node.GetString("RES_STS_9"));
                    lblSts9.Visible = true;
                    txtSts9.Visible = true;
                }
                else
                {
                    lblSts9.Visible = false;
                    txtSts9.Visible = false;
                }
                if (MPCF.Trim(out_node.GetString("RES_STS_10")) != "")
                {
                    lblSts10.Text = MPCF.Trim(out_node.GetString("RES_STS_10"));
                    lblSts10.Visible = true;
                    txtSts10.Visible = true;
                }
                else
                {
                    lblSts10.Visible = false;
                    txtSts10.Visible = false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        // SetGroupCmfItem()
        //       - Set Group / Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];
            
            sGrpTableName[0] = MPGC.MP_GCM_RES_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_RES_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_RES_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_RES_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_RES_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_RES_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_RES_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_RES_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_RES_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_RES_GRP_10;
            
            SetGRPItem(sGrpTableName);
            SetCmfItem();
            
        }
        
        // InitControl()
        //       - initial Group/Cmf Control
        // Return Value
        //       -
        // Arguments
        //       - ByVal sLabelName As String            : Label Control Prefix Name
        //        - ByVal sTextboxName As String            : Textbox Control Prefix Name
        //        - ByVal parentControl As Control        : ParentControl
        private void InitControl(string sLabelName, string sTextboxName, Control parentControl)
        {
            ArrayList controls;
            int i;
            
            try
            {
                controls = MPCF.GetIndexedControl(sLabelName, parentControl);
                for (i = 0; i <= controls.Count - 1; i++)
                {
                    ((Label) controls[i]).Visible = false;
                    ((Label) controls[i]).Text = "";
                }
                
                controls = MPCF.GetIndexedControl(sTextboxName, parentControl);
                for (i = 0; i <= controls.Count - 1; i++)
                {
                    ((TextBox) controls[i]).Visible = false;
                    ((TextBox) controls[i]).Text = "";
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        // SetCmfItem()
        //       - Set Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        private void SetCmfItem()
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ArrayList lblList;
            ArrayList txtList;
            Label lblTemp;
            TextBox txtTemp;
            int i;

            try
            {

                InitControl("lblCMF", "txtCMF", grpCMF);

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_RESOURCE, ref  out_node, "", true) == false)
                {
                    return;
                }

                lblList = MPCF.GetIndexedControl("lblCmf", grpCMF);
                txtList = MPCF.GetIndexedControl("txtCmf", grpCMF);

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    lblTemp = (Label) lblList[i];
                    txtTemp = (TextBox) txtList[i];

                    lblTemp.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT"));
                    if (lblTemp.Text != "")
                    {
                        lblTemp.Visible = true;
                        txtTemp.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        // SetGRPItem()
        //       - Set Group  Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        private void SetGRPItem(string[] sGrpTableName)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ArrayList lblList;
            ArrayList txtList;
            Label lblTemp;
            TextBox txtTemp;
            int i;

            try
            {
                InitControl("lblGrp", "txtGrp", grpGrp);

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_RESOURCE, ref  out_node, "", true) == false)
                {
                    return;
                }

                lblList = MPCF.GetIndexedControl("lblGrp", grpGrp);
                txtList = MPCF.GetIndexedControl("txtGrp", grpGrp);

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    lblTemp = (Label) lblList[i];
                    txtTemp = (TextBox) txtList[i];

                    lblTemp.Text = MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT"));
                    //lblTemp.Font = New System.Drawing.Font(lblTemp.Font, System.Drawing.FontStyle.Bold)
                    if (lblTemp.Text != "")
                    {
                        lblTemp.Visible = true;

                        txtTemp.Tag = "A" + sGrpTableName[i];
                        txtTemp.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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

        public void SetResourceId(string sResId)
        {
            cdvResID.Text = sResId;

            if (b_load_flag == true)
                btnProcess.PerformClick();
        }

        #endregion

        private void btnHistory_Click(object sender, EventArgs e)
        {

            if (cdvResID.Text == "")
                return;

            MPGV.gsCurrentRes_ID = cdvResID.Text;

            try
            {
                Form f = MPCF.GetChildForm(MPGV.gfrmMDI, "frmRASViewResourceHistory");
                if (f != null)
                {
                    f.BringToFront();
                    f.Show();
                }
                else
                {
                    f = new frmRASViewResourceHistory();
                    f.MdiParent = MPGV.gfrmMDI;
                    f.BringToFront();
                    f.Show();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvResType_ButtonPress(object sender, EventArgs e)
        {
            MPCF.FieldClear(this);

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
