
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWipViewSublotStatus.vb
//   Description : MES Cient Form View Sublot Status Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - InitCmfControl() : Initial Cmf Control
//       - SetCmfItem() : Set Cmf Item
//       - View_Sublot() :View Sublot Information
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-16 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;


namespace Miracom.WIPCore
{
    public class frmWIPViewSublotStatus : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewSublotStatus()
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
        


        //ì½”ë“œ ?¸ì§‘ê¸°ë? ?¬ìš©?˜ì—¬ ?˜ì •?˜ì? ë§ˆì‹­?œì˜¤.
        private System.Windows.Forms.Panel pnlLot;
        private System.Windows.Forms.Panel pnlLotStatus;
        private System.Windows.Forms.GroupBox grpLot;
        private System.Windows.Forms.TabControl tabLotStatus;
        private System.Windows.Forms.Label lblSublotID;
        private System.Windows.Forms.TextBox txtSublotID;
        private System.Windows.Forms.TabPage tbpGeneral1;
        private System.Windows.Forms.TabPage tbpCrtCmfField;
        private System.Windows.Forms.GroupBox grpGen1Mid;
        private System.Windows.Forms.CheckBox chkSampleWait;
        private System.Windows.Forms.CheckBox chkSample;
        private System.Windows.Forms.CheckBox chkInv;
        private System.Windows.Forms.CheckBox chkHold;
        private System.Windows.Forms.CheckBox chkLotDelete;
        private System.Windows.Forms.TextBox txtHoldCode;
        private System.Windows.Forms.TextBox txtOwnerCode;
        private System.Windows.Forms.TextBox txtCrtCode;
        private System.Windows.Forms.TextBox txtOperQty3;
        private System.Windows.Forms.TextBox txtCrtQty3;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.TextBox txtOperQty2;
        private System.Windows.Forms.TextBox txtCrtQty2;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtOperDesc;
        private System.Windows.Forms.TextBox txtDelReason;
        private System.Windows.Forms.TextBox txtSampleRes;
        private System.Windows.Forms.TextBox txtSublotStatus;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.Label lblDelReason;
        private System.Windows.Forms.Label lblOperQty;
        private System.Windows.Forms.Label lblSampleRes;
        private System.Windows.Forms.Label lblHoldCode;
        private System.Windows.Forms.Label lblOwnerCode;
        private System.Windows.Forms.Label lblCrtCode;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCreateQty;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblOper;
        private System.Windows.Forms.GroupBox grpCmf;
        private System.Windows.Forms.TextBox txtCmf7;
        private System.Windows.Forms.TextBox txtCmf5;
        private System.Windows.Forms.TextBox txtCmf10;
        private System.Windows.Forms.TextBox txtCmf9;
        private System.Windows.Forms.TextBox txtCmf8;
        private System.Windows.Forms.TextBox txtCmf6;
        private System.Windows.Forms.TextBox txtCmf4;
        private System.Windows.Forms.TextBox txtCmf3;
        private System.Windows.Forms.TextBox txtCmf2;
        private System.Windows.Forms.TextBox txtCmf1;
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
        private System.Windows.Forms.TextBox txtCmf17;
        private System.Windows.Forms.TextBox txtCmf15;
        private System.Windows.Forms.TextBox txtCmf20;
        private System.Windows.Forms.TextBox txtCmf19;
        private System.Windows.Forms.TextBox txtCmf18;
        private System.Windows.Forms.TextBox txtCmf16;
        private System.Windows.Forms.TextBox txtCmf14;
        private System.Windows.Forms.TextBox txtCmf13;
        private System.Windows.Forms.TextBox txtCmf12;
        private System.Windows.Forms.TextBox txtCmf11;
        private System.Windows.Forms.Label lblCMF20;
        private System.Windows.Forms.Label lblCMF19;
        private System.Windows.Forms.Label lblCMF18;
        private System.Windows.Forms.Label lblCMF17;
        private System.Windows.Forms.Label lblCMF16;
        private System.Windows.Forms.Label lblCMF15;
        private System.Windows.Forms.Label lblCMF14;
        private System.Windows.Forms.Label lblCMF13;
        private System.Windows.Forms.Label lblCMF12;
        private System.Windows.Forms.Label lblCMF11;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.GroupBox grpGen2Right;
        private System.Windows.Forms.TextBox txtRepairRetOper;
        private System.Windows.Forms.Label lblRepairRetOper;
        private System.Windows.Forms.TextBox txtReworkTime;
        private System.Windows.Forms.TextBox txtNstdTime;
        private System.Windows.Forms.TextBox txtNstdReturnOper;
        private System.Windows.Forms.TextBox txtNstdReturnFlow;
        private System.Windows.Forms.TextBox txtReworkEndOper;
        private System.Windows.Forms.TextBox txtReworkEndFlow;
        private System.Windows.Forms.TextBox txtReworkReturnOper;
        private System.Windows.Forms.TextBox txtReworkReturnFlow;
        private System.Windows.Forms.TextBox txtReworkCnt;
        private System.Windows.Forms.TextBox txtReworkCode;
        private System.Windows.Forms.Label lblRwkTime;
        private System.Windows.Forms.Label lblNstdTime;
        private System.Windows.Forms.Label lblNstdReturnOper;
        private System.Windows.Forms.Label lblNstdReturnFlow;
        private System.Windows.Forms.Label lblReworkEndOper;
        private System.Windows.Forms.Label lblReworkEndFlow;
        private System.Windows.Forms.Label lblReworkReturnOper;
        private System.Windows.Forms.Label lblReworkReturnFlow;
        private System.Windows.Forms.Label lblReworkCnt;
        private System.Windows.Forms.Label lblReworkCode;
        private System.Windows.Forms.TabPage tbpGeneral2;
        private System.Windows.Forms.TextBox txtLotDeleteTime;
        private System.Windows.Forms.Label lblLotDeleteTime;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private TextBox txtFactory;
        private Label lblFactory;
        private TabPage tbpAttribute;
        private Miracom.BASCore.udcAttributeStatus udcAttributeStatus;
        private Button btnHistory;
        private TextBox txtNstdReturnFlowSeq;
        private TextBox txtReworkEndFlowSeq;
        private TextBox txtReworkReturnFlowSeq;
        private TextBox txtHoldPrvGrpID;
        private TextBox txtStartQty3;
        private TextBox txtStartQty2;
        private Label lblStartQty;
        private Label lblHoldPrvGrpID;
        private TextBox txtCarrierID;
        private TextBox txtSlotNo;
        private Label lblCarrierID;
        private Label lblSlotNo;
        private CheckBox chkRepair;
        private CheckBox chkLocalReworkFlag;
        private CheckBox chkRework;
        private CheckBox chkNstd;
        private TextBox txtInvUnit;
        private Label lblInvUnit;
        private TextBox txtLotBase;
        private Label lblLotBase;
        private TextBox txtEndTime;
        private TextBox txtStartTime;
        private Label lblEndTime;
        private Label lblStartTime;
        private CheckBox chkEnd;
        private CheckBox chkStart;
        private CheckBox chkTransit;
        private TabPage tbpGeneral3;
        private GroupBox grpRes;
        private TextBox txtResvResID;
        private TextBox txtEndResID;
        private TextBox txtStartResId;
        private Label lblResvRes;
        private Label lblEndRes;
        private Label lblStartRes;
        private GroupBox grpGen3Mid;
        private TextBox txtComment;
        private TextBox txtLastActHistSeq;
        private TextBox txtLastHistSeq;
        private TextBox txtLastTrnTime;
        private TextBox txtLastTrnCode;
        private Label lblLastHistSeq;
        private Label lblLastActHistSeq;
        private Label lblComment;
        private Label lblLastTrnTime;
        private Label lblLastTrnCode;
        private GroupBox grpExtra;
        private TextBox txtLotHistSeq;
        private Label lblLotHistSeq;
        private TextBox txtLocation3;
        private Label lblLocation3;
        private TextBox txtLocation2;
        private Label lblLocation2;
        private TextBox txtLocation1;
        private Label lblLocation1;
        private TextBox txtStrRetOper;
        private TextBox txtStrRetFlow;
        private TextBox txtStrRetFlowSeq;
        private Label lblStrRetOper;
        private Label lblStrRetFlow;
        private TextBox txtCellGrade;
        private TextBox txtGradeCode;
        private TextBox txtGrade;
        private Label lblCellGrade;
        private Label lblGradeCode;
        private Label lblGrade;
        private TextBox txtCellJudge;
        private Label lblCellJudge;
        private TextBox txtReworkStopOper;
        private Label lblReworkStopOper;
        private TextBox txtReworkDepth;
        private TextBox txtReturnOption;
        private Label lblReturnOption;
        private TextBox txtSublotType;
        private Label lblSublotType;
        private System.Windows.Forms.CheckBox chkTracking;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlLotStatus = new System.Windows.Forms.Panel();
            this.tabLotStatus = new System.Windows.Forms.TabControl();
            this.tbpGeneral1 = new System.Windows.Forms.TabPage();
            this.grpGen1Mid = new System.Windows.Forms.GroupBox();
            this.txtSublotType = new System.Windows.Forms.TextBox();
            this.lblSublotType = new System.Windows.Forms.Label();
            this.txtLotHistSeq = new System.Windows.Forms.TextBox();
            this.lblLotHistSeq = new System.Windows.Forms.Label();
            this.chkTransit = new System.Windows.Forms.CheckBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.txtLotBase = new System.Windows.Forms.TextBox();
            this.lblLotBase = new System.Windows.Forms.Label();
            this.txtLotDeleteTime = new System.Windows.Forms.TextBox();
            this.lblLotDeleteTime = new System.Windows.Forms.Label();
            this.txtInvUnit = new System.Windows.Forms.TextBox();
            this.lblInvUnit = new System.Windows.Forms.Label();
            this.chkSampleWait = new System.Windows.Forms.CheckBox();
            this.chkSample = new System.Windows.Forms.CheckBox();
            this.chkTracking = new System.Windows.Forms.CheckBox();
            this.chkInv = new System.Windows.Forms.CheckBox();
            this.chkHold = new System.Windows.Forms.CheckBox();
            this.chkLotDelete = new System.Windows.Forms.CheckBox();
            this.txtHoldPrvGrpID = new System.Windows.Forms.TextBox();
            this.txtHoldCode = new System.Windows.Forms.TextBox();
            this.txtOwnerCode = new System.Windows.Forms.TextBox();
            this.txtCrtCode = new System.Windows.Forms.TextBox();
            this.txtStartQty3 = new System.Windows.Forms.TextBox();
            this.txtOperQty3 = new System.Windows.Forms.TextBox();
            this.txtCrtQty3 = new System.Windows.Forms.TextBox();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.txtStartQty2 = new System.Windows.Forms.TextBox();
            this.txtOperQty2 = new System.Windows.Forms.TextBox();
            this.txtCrtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtOperDesc = new System.Windows.Forms.TextBox();
            this.txtDelReason = new System.Windows.Forms.TextBox();
            this.txtSampleRes = new System.Windows.Forms.TextBox();
            this.txtCarrierID = new System.Windows.Forms.TextBox();
            this.txtSlotNo = new System.Windows.Forms.TextBox();
            this.txtSublotStatus = new System.Windows.Forms.TextBox();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.lblStartQty = new System.Windows.Forms.Label();
            this.lblDelReason = new System.Windows.Forms.Label();
            this.lblOperQty = new System.Windows.Forms.Label();
            this.lblHoldPrvGrpID = new System.Windows.Forms.Label();
            this.lblSampleRes = new System.Windows.Forms.Label();
            this.lblHoldCode = new System.Windows.Forms.Label();
            this.lblCarrierID = new System.Windows.Forms.Label();
            this.lblOwnerCode = new System.Windows.Forms.Label();
            this.lblSlotNo = new System.Windows.Forms.Label();
            this.lblCrtCode = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCreateQty = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblOper = new System.Windows.Forms.Label();
            this.tbpGeneral2 = new System.Windows.Forms.TabPage();
            this.grpRes = new System.Windows.Forms.GroupBox();
            this.txtStrRetOper = new System.Windows.Forms.TextBox();
            this.txtStrRetFlow = new System.Windows.Forms.TextBox();
            this.txtStrRetFlowSeq = new System.Windows.Forms.TextBox();
            this.lblStrRetOper = new System.Windows.Forms.Label();
            this.lblStrRetFlow = new System.Windows.Forms.Label();
            this.txtResvResID = new System.Windows.Forms.TextBox();
            this.txtEndResID = new System.Windows.Forms.TextBox();
            this.txtStartResId = new System.Windows.Forms.TextBox();
            this.lblResvRes = new System.Windows.Forms.Label();
            this.lblEndRes = new System.Windows.Forms.Label();
            this.lblStartRes = new System.Windows.Forms.Label();
            this.grpGen2Right = new System.Windows.Forms.GroupBox();
            this.txtReturnOption = new System.Windows.Forms.TextBox();
            this.lblReturnOption = new System.Windows.Forms.Label();
            this.txtReworkStopOper = new System.Windows.Forms.TextBox();
            this.lblReworkStopOper = new System.Windows.Forms.Label();
            this.txtReworkDepth = new System.Windows.Forms.TextBox();
            this.chkNstd = new System.Windows.Forms.CheckBox();
            this.chkRepair = new System.Windows.Forms.CheckBox();
            this.chkLocalReworkFlag = new System.Windows.Forms.CheckBox();
            this.chkRework = new System.Windows.Forms.CheckBox();
            this.txtRepairRetOper = new System.Windows.Forms.TextBox();
            this.lblRepairRetOper = new System.Windows.Forms.Label();
            this.txtReworkTime = new System.Windows.Forms.TextBox();
            this.txtNstdTime = new System.Windows.Forms.TextBox();
            this.txtNstdReturnOper = new System.Windows.Forms.TextBox();
            this.txtNstdReturnFlow = new System.Windows.Forms.TextBox();
            this.txtReworkEndOper = new System.Windows.Forms.TextBox();
            this.txtReworkEndFlow = new System.Windows.Forms.TextBox();
            this.txtReworkReturnOper = new System.Windows.Forms.TextBox();
            this.txtNstdReturnFlowSeq = new System.Windows.Forms.TextBox();
            this.txtReworkEndFlowSeq = new System.Windows.Forms.TextBox();
            this.txtReworkReturnFlowSeq = new System.Windows.Forms.TextBox();
            this.txtReworkReturnFlow = new System.Windows.Forms.TextBox();
            this.txtReworkCnt = new System.Windows.Forms.TextBox();
            this.txtReworkCode = new System.Windows.Forms.TextBox();
            this.lblRwkTime = new System.Windows.Forms.Label();
            this.lblNstdTime = new System.Windows.Forms.Label();
            this.lblNstdReturnOper = new System.Windows.Forms.Label();
            this.lblNstdReturnFlow = new System.Windows.Forms.Label();
            this.lblReworkEndOper = new System.Windows.Forms.Label();
            this.lblReworkEndFlow = new System.Windows.Forms.Label();
            this.lblReworkReturnOper = new System.Windows.Forms.Label();
            this.lblReworkReturnFlow = new System.Windows.Forms.Label();
            this.lblReworkCnt = new System.Windows.Forms.Label();
            this.lblReworkCode = new System.Windows.Forms.Label();
            this.tbpGeneral3 = new System.Windows.Forms.TabPage();
            this.grpExtra = new System.Windows.Forms.GroupBox();
            this.txtCellJudge = new System.Windows.Forms.TextBox();
            this.lblCellJudge = new System.Windows.Forms.Label();
            this.txtCellGrade = new System.Windows.Forms.TextBox();
            this.txtGradeCode = new System.Windows.Forms.TextBox();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.lblCellGrade = new System.Windows.Forms.Label();
            this.lblGradeCode = new System.Windows.Forms.Label();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtLocation3 = new System.Windows.Forms.TextBox();
            this.lblLocation3 = new System.Windows.Forms.Label();
            this.txtLocation2 = new System.Windows.Forms.TextBox();
            this.lblLocation2 = new System.Windows.Forms.Label();
            this.txtLocation1 = new System.Windows.Forms.TextBox();
            this.lblLocation1 = new System.Windows.Forms.Label();
            this.grpGen3Mid = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtLastActHistSeq = new System.Windows.Forms.TextBox();
            this.txtLastHistSeq = new System.Windows.Forms.TextBox();
            this.txtLastTrnTime = new System.Windows.Forms.TextBox();
            this.txtLastTrnCode = new System.Windows.Forms.TextBox();
            this.lblLastHistSeq = new System.Windows.Forms.Label();
            this.lblLastActHistSeq = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblLastTrnTime = new System.Windows.Forms.Label();
            this.lblLastTrnCode = new System.Windows.Forms.Label();
            this.tbpAttribute = new System.Windows.Forms.TabPage();
            this.udcAttributeStatus = new Miracom.BASCore.udcAttributeStatus();
            this.txtSublotID = new System.Windows.Forms.TextBox();
            this.tbpCrtCmfField = new System.Windows.Forms.TabPage();
            this.grpCmf = new System.Windows.Forms.GroupBox();
            this.txtCmf17 = new System.Windows.Forms.TextBox();
            this.txtCmf15 = new System.Windows.Forms.TextBox();
            this.txtCmf20 = new System.Windows.Forms.TextBox();
            this.txtCmf19 = new System.Windows.Forms.TextBox();
            this.txtCmf18 = new System.Windows.Forms.TextBox();
            this.txtCmf16 = new System.Windows.Forms.TextBox();
            this.txtCmf14 = new System.Windows.Forms.TextBox();
            this.txtCmf13 = new System.Windows.Forms.TextBox();
            this.txtCmf12 = new System.Windows.Forms.TextBox();
            this.txtCmf11 = new System.Windows.Forms.TextBox();
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
            this.txtCmf7 = new System.Windows.Forms.TextBox();
            this.txtCmf5 = new System.Windows.Forms.TextBox();
            this.txtCmf10 = new System.Windows.Forms.TextBox();
            this.txtCmf9 = new System.Windows.Forms.TextBox();
            this.txtCmf8 = new System.Windows.Forms.TextBox();
            this.txtCmf6 = new System.Windows.Forms.TextBox();
            this.txtCmf4 = new System.Windows.Forms.TextBox();
            this.txtCmf3 = new System.Windows.Forms.TextBox();
            this.txtCmf2 = new System.Windows.Forms.TextBox();
            this.txtCmf1 = new System.Windows.Forms.TextBox();
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
            this.pnlLot = new System.Windows.Forms.Panel();
            this.grpLot = new System.Windows.Forms.GroupBox();
            this.txtFactory = new System.Windows.Forms.TextBox();
            this.lblFactory = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.lblSublotID = new System.Windows.Forms.Label();
            this.btnHistory = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlLotStatus.SuspendLayout();
            this.tabLotStatus.SuspendLayout();
            this.tbpGeneral1.SuspendLayout();
            this.grpGen1Mid.SuspendLayout();
            this.tbpGeneral2.SuspendLayout();
            this.grpRes.SuspendLayout();
            this.grpGen2Right.SuspendLayout();
            this.tbpGeneral3.SuspendLayout();
            this.grpExtra.SuspendLayout();
            this.grpGen3Mid.SuspendLayout();
            this.tbpAttribute.SuspendLayout();
            this.tbpCrtCmfField.SuspendLayout();
            this.grpCmf.SuspendLayout();
            this.pnlLot.SuspendLayout();
            this.grpLot.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(465, 7);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 517);
            this.pnlBottom.Size = new System.Drawing.Size(742, 36);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnHistory, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlLotStatus);
            this.pnlCenter.Controls.Add(this.pnlLot);
            this.pnlCenter.Size = new System.Drawing.Size(742, 517);
            this.pnlCenter.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Lot Status";
            // 
            // pnlLotStatus
            // 
            this.pnlLotStatus.Controls.Add(this.tabLotStatus);
            this.pnlLotStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLotStatus.Location = new System.Drawing.Point(0, 70);
            this.pnlLotStatus.Name = "pnlLotStatus";
            this.pnlLotStatus.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.pnlLotStatus.Size = new System.Drawing.Size(742, 447);
            this.pnlLotStatus.TabIndex = 1;
            // 
            // tabLotStatus
            // 
            this.tabLotStatus.Controls.Add(this.tbpGeneral1);
            this.tabLotStatus.Controls.Add(this.tbpGeneral2);
            this.tabLotStatus.Controls.Add(this.tbpGeneral3);
            this.tabLotStatus.Controls.Add(this.tbpAttribute);
            this.tabLotStatus.Controls.Add(this.tbpCrtCmfField);
            this.tabLotStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLotStatus.ItemSize = new System.Drawing.Size(60, 18);
            this.tabLotStatus.Location = new System.Drawing.Point(3, 5);
            this.tabLotStatus.Name = "tabLotStatus";
            this.tabLotStatus.SelectedIndex = 0;
            this.tabLotStatus.Size = new System.Drawing.Size(736, 442);
            this.tabLotStatus.TabIndex = 0;
            // 
            // tbpGeneral1
            // 
            this.tbpGeneral1.Controls.Add(this.grpGen1Mid);
            this.tbpGeneral1.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral1.Name = "tbpGeneral1";
            this.tbpGeneral1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral1.Size = new System.Drawing.Size(728, 416);
            this.tbpGeneral1.TabIndex = 0;
            this.tbpGeneral1.Text = "General 1";
            // 
            // grpGen1Mid
            // 
            this.grpGen1Mid.Controls.Add(this.txtSublotType);
            this.grpGen1Mid.Controls.Add(this.lblSublotType);
            this.grpGen1Mid.Controls.Add(this.txtLotHistSeq);
            this.grpGen1Mid.Controls.Add(this.lblLotHistSeq);
            this.grpGen1Mid.Controls.Add(this.chkTransit);
            this.grpGen1Mid.Controls.Add(this.txtEndTime);
            this.grpGen1Mid.Controls.Add(this.txtStartTime);
            this.grpGen1Mid.Controls.Add(this.lblEndTime);
            this.grpGen1Mid.Controls.Add(this.lblStartTime);
            this.grpGen1Mid.Controls.Add(this.chkEnd);
            this.grpGen1Mid.Controls.Add(this.chkStart);
            this.grpGen1Mid.Controls.Add(this.cdvFlow);
            this.grpGen1Mid.Controls.Add(this.cdvMaterial);
            this.grpGen1Mid.Controls.Add(this.txtLotBase);
            this.grpGen1Mid.Controls.Add(this.lblLotBase);
            this.grpGen1Mid.Controls.Add(this.txtLotDeleteTime);
            this.grpGen1Mid.Controls.Add(this.lblLotDeleteTime);
            this.grpGen1Mid.Controls.Add(this.txtInvUnit);
            this.grpGen1Mid.Controls.Add(this.lblInvUnit);
            this.grpGen1Mid.Controls.Add(this.chkSampleWait);
            this.grpGen1Mid.Controls.Add(this.chkSample);
            this.grpGen1Mid.Controls.Add(this.chkTracking);
            this.grpGen1Mid.Controls.Add(this.chkInv);
            this.grpGen1Mid.Controls.Add(this.chkHold);
            this.grpGen1Mid.Controls.Add(this.chkLotDelete);
            this.grpGen1Mid.Controls.Add(this.txtHoldPrvGrpID);
            this.grpGen1Mid.Controls.Add(this.txtHoldCode);
            this.grpGen1Mid.Controls.Add(this.txtOwnerCode);
            this.grpGen1Mid.Controls.Add(this.txtCrtCode);
            this.grpGen1Mid.Controls.Add(this.txtStartQty3);
            this.grpGen1Mid.Controls.Add(this.txtOperQty3);
            this.grpGen1Mid.Controls.Add(this.txtCrtQty3);
            this.grpGen1Mid.Controls.Add(this.txtQty3);
            this.grpGen1Mid.Controls.Add(this.txtStartQty2);
            this.grpGen1Mid.Controls.Add(this.txtOperQty2);
            this.grpGen1Mid.Controls.Add(this.txtCrtQty2);
            this.grpGen1Mid.Controls.Add(this.txtQty2);
            this.grpGen1Mid.Controls.Add(this.txtOperDesc);
            this.grpGen1Mid.Controls.Add(this.txtDelReason);
            this.grpGen1Mid.Controls.Add(this.txtSampleRes);
            this.grpGen1Mid.Controls.Add(this.txtCarrierID);
            this.grpGen1Mid.Controls.Add(this.txtSlotNo);
            this.grpGen1Mid.Controls.Add(this.txtSublotStatus);
            this.grpGen1Mid.Controls.Add(this.txtOper);
            this.grpGen1Mid.Controls.Add(this.lblStartQty);
            this.grpGen1Mid.Controls.Add(this.lblDelReason);
            this.grpGen1Mid.Controls.Add(this.lblOperQty);
            this.grpGen1Mid.Controls.Add(this.lblHoldPrvGrpID);
            this.grpGen1Mid.Controls.Add(this.lblSampleRes);
            this.grpGen1Mid.Controls.Add(this.lblHoldCode);
            this.grpGen1Mid.Controls.Add(this.lblCarrierID);
            this.grpGen1Mid.Controls.Add(this.lblOwnerCode);
            this.grpGen1Mid.Controls.Add(this.lblSlotNo);
            this.grpGen1Mid.Controls.Add(this.lblCrtCode);
            this.grpGen1Mid.Controls.Add(this.lblStatus);
            this.grpGen1Mid.Controls.Add(this.lblCreateQty);
            this.grpGen1Mid.Controls.Add(this.lblQty);
            this.grpGen1Mid.Controls.Add(this.lblOper);
            this.grpGen1Mid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGen1Mid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGen1Mid.Location = new System.Drawing.Point(3, 0);
            this.grpGen1Mid.Name = "grpGen1Mid";
            this.grpGen1Mid.Size = new System.Drawing.Size(722, 413);
            this.grpGen1Mid.TabIndex = 0;
            this.grpGen1Mid.TabStop = false;
            // 
            // txtSublotType
            // 
            this.txtSublotType.Location = new System.Drawing.Point(552, 199);
            this.txtSublotType.MaxLength = 50;
            this.txtSublotType.Name = "txtSublotType";
            this.txtSublotType.ReadOnly = true;
            this.txtSublotType.Size = new System.Drawing.Size(162, 20);
            this.txtSublotType.TabIndex = 49;
            this.txtSublotType.TabStop = false;
            // 
            // lblSublotType
            // 
            this.lblSublotType.AutoSize = true;
            this.lblSublotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSublotType.Location = new System.Drawing.Point(432, 202);
            this.lblSublotType.Name = "lblSublotType";
            this.lblSublotType.Size = new System.Drawing.Size(71, 13);
            this.lblSublotType.TabIndex = 48;
            this.lblSublotType.Text = "Sub Lot Type";
            this.lblSublotType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotHistSeq
            // 
            this.txtLotHistSeq.Location = new System.Drawing.Point(552, 268);
            this.txtLotHistSeq.MaxLength = 25;
            this.txtLotHistSeq.Name = "txtLotHistSeq";
            this.txtLotHistSeq.ReadOnly = true;
            this.txtLotHistSeq.Size = new System.Drawing.Size(162, 20);
            this.txtLotHistSeq.TabIndex = 55;
            this.txtLotHistSeq.TabStop = false;
            // 
            // lblLotHistSeq
            // 
            this.lblLotHistSeq.AutoSize = true;
            this.lblLotHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotHistSeq.Location = new System.Drawing.Point(432, 271);
            this.lblLotHistSeq.Name = "lblLotHistSeq";
            this.lblLotHistSeq.Size = new System.Drawing.Size(65, 13);
            this.lblLotHistSeq.TabIndex = 54;
            this.lblLotHistSeq.Text = "Lot Hist Seq";
            this.lblLotHistSeq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkTransit
            // 
            this.chkTransit.AutoSize = true;
            this.chkTransit.Enabled = false;
            this.chkTransit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTransit.Location = new System.Drawing.Point(15, 386);
            this.chkTransit.Name = "chkTransit";
            this.chkTransit.Size = new System.Drawing.Size(87, 18);
            this.chkTransit.TabIndex = 39;
            this.chkTransit.TabStop = false;
            this.chkTransit.Text = "Transit Flag";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(130, 222);
            this.txtEndTime.MaxLength = 25;
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(162, 20);
            this.txtEndTime.TabIndex = 21;
            this.txtEndTime.TabStop = false;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(130, 199);
            this.txtStartTime.MaxLength = 25;
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(162, 20);
            this.txtStartTime.TabIndex = 18;
            this.txtStartTime.TabStop = false;
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndTime.Location = new System.Drawing.Point(15, 224);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(52, 13);
            this.lblEndTime.TabIndex = 20;
            this.lblEndTime.Text = "End Time";
            this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartTime.Location = new System.Drawing.Point(15, 201);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(55, 13);
            this.lblStartTime.TabIndex = 17;
            this.lblStartTime.Text = "Start Time";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkEnd
            // 
            this.chkEnd.AutoSize = true;
            this.chkEnd.Enabled = false;
            this.chkEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEnd.Location = new System.Drawing.Point(302, 225);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(74, 18);
            this.chkEnd.TabIndex = 22;
            this.chkEnd.TabStop = false;
            this.chkEnd.Text = "End Flag";
            // 
            // chkStart
            // 
            this.chkStart.AutoSize = true;
            this.chkStart.Enabled = false;
            this.chkStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStart.Location = new System.Drawing.Point(302, 202);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(77, 18);
            this.chkStart.TabIndex = 19;
            this.chkStart.TabStop = false;
            this.chkStart.Text = "Start Flag";
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = true;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 115;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(15, 38);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = true;
            this.cdvFlow.Size = new System.Drawing.Size(699, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = true;
            this.cdvFlow.VisibleFlowButton = false;
            this.cdvFlow.VisibleSequenceButton = false;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 214;
            this.cdvFlow.WidthSequence = 50;
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(15, 15);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = true;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(699, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = true;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = true;
            this.cdvMaterial.VisibleMaterialButton = false;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 115;
            this.cdvMaterial.WidthMaterialAndVersion = 214;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // txtLotBase
            // 
            this.txtLotBase.Location = new System.Drawing.Point(552, 245);
            this.txtLotBase.MaxLength = 25;
            this.txtLotBase.Name = "txtLotBase";
            this.txtLotBase.ReadOnly = true;
            this.txtLotBase.Size = new System.Drawing.Size(162, 20);
            this.txtLotBase.TabIndex = 53;
            this.txtLotBase.TabStop = false;
            // 
            // lblLotBase
            // 
            this.lblLotBase.AutoSize = true;
            this.lblLotBase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotBase.Location = new System.Drawing.Point(432, 248);
            this.lblLotBase.Name = "lblLotBase";
            this.lblLotBase.Size = new System.Drawing.Size(49, 13);
            this.lblLotBase.TabIndex = 52;
            this.lblLotBase.Text = "Lot Base";
            this.lblLotBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotDeleteTime
            // 
            this.txtLotDeleteTime.Location = new System.Drawing.Point(130, 291);
            this.txtLotDeleteTime.MaxLength = 25;
            this.txtLotDeleteTime.Name = "txtLotDeleteTime";
            this.txtLotDeleteTime.ReadOnly = true;
            this.txtLotDeleteTime.Size = new System.Drawing.Size(162, 20);
            this.txtLotDeleteTime.TabIndex = 29;
            this.txtLotDeleteTime.TabStop = false;
            // 
            // lblLotDeleteTime
            // 
            this.lblLotDeleteTime.AutoSize = true;
            this.lblLotDeleteTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotDeleteTime.Location = new System.Drawing.Point(15, 293);
            this.lblLotDeleteTime.Name = "lblLotDeleteTime";
            this.lblLotDeleteTime.Size = new System.Drawing.Size(82, 13);
            this.lblLotDeleteTime.TabIndex = 28;
            this.lblLotDeleteTime.Text = "Lot Delete Time";
            this.lblLotDeleteTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInvUnit
            // 
            this.txtInvUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvUnit.Location = new System.Drawing.Point(130, 314);
            this.txtInvUnit.MaxLength = 20;
            this.txtInvUnit.Name = "txtInvUnit";
            this.txtInvUnit.ReadOnly = true;
            this.txtInvUnit.Size = new System.Drawing.Size(162, 20);
            this.txtInvUnit.TabIndex = 32;
            this.txtInvUnit.TabStop = false;
            // 
            // lblInvUnit
            // 
            this.lblInvUnit.AutoSize = true;
            this.lblInvUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInvUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvUnit.Location = new System.Drawing.Point(15, 315);
            this.lblInvUnit.Name = "lblInvUnit";
            this.lblInvUnit.Size = new System.Drawing.Size(73, 13);
            this.lblInvUnit.TabIndex = 31;
            this.lblInvUnit.Text = "Inventory Unit";
            this.lblInvUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkSampleWait
            // 
            this.chkSampleWait.AutoSize = true;
            this.chkSampleWait.Enabled = false;
            this.chkSampleWait.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSampleWait.Location = new System.Drawing.Point(302, 363);
            this.chkSampleWait.Name = "chkSampleWait";
            this.chkSampleWait.Size = new System.Drawing.Size(115, 18);
            this.chkSampleWait.TabIndex = 38;
            this.chkSampleWait.TabStop = false;
            this.chkSampleWait.Text = "Sample Wait Flag";
            // 
            // chkSample
            // 
            this.chkSample.AutoSize = true;
            this.chkSample.Enabled = false;
            this.chkSample.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSample.Location = new System.Drawing.Point(302, 340);
            this.chkSample.Name = "chkSample";
            this.chkSample.Size = new System.Drawing.Size(90, 18);
            this.chkSample.TabIndex = 36;
            this.chkSample.TabStop = false;
            this.chkSample.Text = "Sample Flag";
            // 
            // chkTracking
            // 
            this.chkTracking.AutoSize = true;
            this.chkTracking.Enabled = false;
            this.chkTracking.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTracking.Location = new System.Drawing.Point(15, 363);
            this.chkTracking.Name = "chkTracking";
            this.chkTracking.Size = new System.Drawing.Size(97, 18);
            this.chkTracking.TabIndex = 37;
            this.chkTracking.TabStop = false;
            this.chkTracking.Text = "Tracking Flag";
            // 
            // chkInv
            // 
            this.chkInv.AutoSize = true;
            this.chkInv.Enabled = false;
            this.chkInv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkInv.Location = new System.Drawing.Point(302, 317);
            this.chkInv.Name = "chkInv";
            this.chkInv.Size = new System.Drawing.Size(99, 18);
            this.chkInv.TabIndex = 33;
            this.chkInv.TabStop = false;
            this.chkInv.Text = "Inventory Flag";
            // 
            // chkHold
            // 
            this.chkHold.AutoSize = true;
            this.chkHold.Enabled = false;
            this.chkHold.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkHold.Location = new System.Drawing.Point(302, 248);
            this.chkHold.Name = "chkHold";
            this.chkHold.Size = new System.Drawing.Size(77, 18);
            this.chkHold.TabIndex = 25;
            this.chkHold.TabStop = false;
            this.chkHold.Text = "Hold Flag";
            // 
            // chkLotDelete
            // 
            this.chkLotDelete.AutoSize = true;
            this.chkLotDelete.Enabled = false;
            this.chkLotDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkLotDelete.Location = new System.Drawing.Point(302, 294);
            this.chkLotDelete.Name = "chkLotDelete";
            this.chkLotDelete.Size = new System.Drawing.Size(104, 18);
            this.chkLotDelete.TabIndex = 30;
            this.chkLotDelete.TabStop = false;
            this.chkLotDelete.Text = "Lot Delete Flag";
            // 
            // txtHoldPrvGrpID
            // 
            this.txtHoldPrvGrpID.Location = new System.Drawing.Point(130, 268);
            this.txtHoldPrvGrpID.MaxLength = 10;
            this.txtHoldPrvGrpID.Name = "txtHoldPrvGrpID";
            this.txtHoldPrvGrpID.ReadOnly = true;
            this.txtHoldPrvGrpID.Size = new System.Drawing.Size(162, 20);
            this.txtHoldPrvGrpID.TabIndex = 27;
            this.txtHoldPrvGrpID.TabStop = false;
            // 
            // txtHoldCode
            // 
            this.txtHoldCode.Location = new System.Drawing.Point(130, 245);
            this.txtHoldCode.MaxLength = 10;
            this.txtHoldCode.Name = "txtHoldCode";
            this.txtHoldCode.ReadOnly = true;
            this.txtHoldCode.Size = new System.Drawing.Size(162, 20);
            this.txtHoldCode.TabIndex = 24;
            this.txtHoldCode.TabStop = false;
            // 
            // txtOwnerCode
            // 
            this.txtOwnerCode.Location = new System.Drawing.Point(552, 107);
            this.txtOwnerCode.MaxLength = 10;
            this.txtOwnerCode.Name = "txtOwnerCode";
            this.txtOwnerCode.ReadOnly = true;
            this.txtOwnerCode.Size = new System.Drawing.Size(162, 20);
            this.txtOwnerCode.TabIndex = 43;
            this.txtOwnerCode.TabStop = false;
            // 
            // txtCrtCode
            // 
            this.txtCrtCode.Location = new System.Drawing.Point(552, 84);
            this.txtCrtCode.MaxLength = 10;
            this.txtCrtCode.Name = "txtCrtCode";
            this.txtCrtCode.ReadOnly = true;
            this.txtCrtCode.Size = new System.Drawing.Size(162, 20);
            this.txtCrtCode.TabIndex = 41;
            this.txtCrtCode.TabStop = false;
            // 
            // txtStartQty3
            // 
            this.txtStartQty3.Location = new System.Drawing.Point(237, 153);
            this.txtStartQty3.MaxLength = 10;
            this.txtStartQty3.Name = "txtStartQty3";
            this.txtStartQty3.ReadOnly = true;
            this.txtStartQty3.Size = new System.Drawing.Size(105, 20);
            this.txtStartQty3.TabIndex = 16;
            this.txtStartQty3.TabStop = false;
            // 
            // txtOperQty3
            // 
            this.txtOperQty3.Location = new System.Drawing.Point(237, 130);
            this.txtOperQty3.MaxLength = 10;
            this.txtOperQty3.Name = "txtOperQty3";
            this.txtOperQty3.ReadOnly = true;
            this.txtOperQty3.Size = new System.Drawing.Size(105, 20);
            this.txtOperQty3.TabIndex = 13;
            this.txtOperQty3.TabStop = false;
            // 
            // txtCrtQty3
            // 
            this.txtCrtQty3.Location = new System.Drawing.Point(237, 107);
            this.txtCrtQty3.MaxLength = 10;
            this.txtCrtQty3.Name = "txtCrtQty3";
            this.txtCrtQty3.ReadOnly = true;
            this.txtCrtQty3.Size = new System.Drawing.Size(105, 20);
            this.txtCrtQty3.TabIndex = 10;
            this.txtCrtQty3.TabStop = false;
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(237, 84);
            this.txtQty3.MaxLength = 10;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.ReadOnly = true;
            this.txtQty3.Size = new System.Drawing.Size(105, 20);
            this.txtQty3.TabIndex = 7;
            this.txtQty3.TabStop = false;
            // 
            // txtStartQty2
            // 
            this.txtStartQty2.Location = new System.Drawing.Point(130, 153);
            this.txtStartQty2.MaxLength = 10;
            this.txtStartQty2.Name = "txtStartQty2";
            this.txtStartQty2.ReadOnly = true;
            this.txtStartQty2.Size = new System.Drawing.Size(105, 20);
            this.txtStartQty2.TabIndex = 15;
            this.txtStartQty2.TabStop = false;
            // 
            // txtOperQty2
            // 
            this.txtOperQty2.Location = new System.Drawing.Point(130, 130);
            this.txtOperQty2.MaxLength = 10;
            this.txtOperQty2.Name = "txtOperQty2";
            this.txtOperQty2.ReadOnly = true;
            this.txtOperQty2.Size = new System.Drawing.Size(105, 20);
            this.txtOperQty2.TabIndex = 12;
            this.txtOperQty2.TabStop = false;
            // 
            // txtCrtQty2
            // 
            this.txtCrtQty2.Location = new System.Drawing.Point(130, 107);
            this.txtCrtQty2.MaxLength = 10;
            this.txtCrtQty2.Name = "txtCrtQty2";
            this.txtCrtQty2.ReadOnly = true;
            this.txtCrtQty2.Size = new System.Drawing.Size(105, 20);
            this.txtCrtQty2.TabIndex = 9;
            this.txtCrtQty2.TabStop = false;
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(130, 84);
            this.txtQty2.MaxLength = 10;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.ReadOnly = true;
            this.txtQty2.Size = new System.Drawing.Size(105, 20);
            this.txtQty2.TabIndex = 6;
            this.txtQty2.TabStop = false;
            // 
            // txtOperDesc
            // 
            this.txtOperDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOperDesc.Location = new System.Drawing.Point(294, 61);
            this.txtOperDesc.MaxLength = 200;
            this.txtOperDesc.Name = "txtOperDesc";
            this.txtOperDesc.ReadOnly = true;
            this.txtOperDesc.Size = new System.Drawing.Size(420, 20);
            this.txtOperDesc.TabIndex = 4;
            this.txtOperDesc.TabStop = false;
            // 
            // txtDelReason
            // 
            this.txtDelReason.Location = new System.Drawing.Point(552, 291);
            this.txtDelReason.MaxLength = 12;
            this.txtDelReason.Name = "txtDelReason";
            this.txtDelReason.ReadOnly = true;
            this.txtDelReason.Size = new System.Drawing.Size(162, 20);
            this.txtDelReason.TabIndex = 57;
            this.txtDelReason.TabStop = false;
            // 
            // txtSampleRes
            // 
            this.txtSampleRes.Location = new System.Drawing.Point(130, 337);
            this.txtSampleRes.MaxLength = 10;
            this.txtSampleRes.Name = "txtSampleRes";
            this.txtSampleRes.ReadOnly = true;
            this.txtSampleRes.Size = new System.Drawing.Size(162, 20);
            this.txtSampleRes.TabIndex = 35;
            this.txtSampleRes.TabStop = false;
            // 
            // txtCarrierID
            // 
            this.txtCarrierID.Location = new System.Drawing.Point(552, 130);
            this.txtCarrierID.MaxLength = 10;
            this.txtCarrierID.Name = "txtCarrierID";
            this.txtCarrierID.ReadOnly = true;
            this.txtCarrierID.Size = new System.Drawing.Size(162, 20);
            this.txtCarrierID.TabIndex = 45;
            this.txtCarrierID.TabStop = false;
            // 
            // txtSlotNo
            // 
            this.txtSlotNo.Location = new System.Drawing.Point(552, 153);
            this.txtSlotNo.MaxLength = 10;
            this.txtSlotNo.Name = "txtSlotNo";
            this.txtSlotNo.ReadOnly = true;
            this.txtSlotNo.Size = new System.Drawing.Size(162, 20);
            this.txtSlotNo.TabIndex = 47;
            this.txtSlotNo.TabStop = false;
            // 
            // txtSublotStatus
            // 
            this.txtSublotStatus.Location = new System.Drawing.Point(552, 222);
            this.txtSublotStatus.MaxLength = 10;
            this.txtSublotStatus.Name = "txtSublotStatus";
            this.txtSublotStatus.ReadOnly = true;
            this.txtSublotStatus.Size = new System.Drawing.Size(162, 20);
            this.txtSublotStatus.TabIndex = 51;
            this.txtSublotStatus.TabStop = false;
            // 
            // txtOper
            // 
            this.txtOper.Location = new System.Drawing.Point(130, 61);
            this.txtOper.MaxLength = 10;
            this.txtOper.Name = "txtOper";
            this.txtOper.ReadOnly = true;
            this.txtOper.Size = new System.Drawing.Size(162, 20);
            this.txtOper.TabIndex = 3;
            this.txtOper.TabStop = false;
            // 
            // lblStartQty
            // 
            this.lblStartQty.AutoSize = true;
            this.lblStartQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartQty.Location = new System.Drawing.Point(15, 155);
            this.lblStartQty.Name = "lblStartQty";
            this.lblStartQty.Size = new System.Drawing.Size(68, 13);
            this.lblStartQty.TabIndex = 14;
            this.lblStartQty.Text = "Start Qty 2/3";
            this.lblStartQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDelReason
            // 
            this.lblDelReason.AutoSize = true;
            this.lblDelReason.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDelReason.Location = new System.Drawing.Point(432, 294);
            this.lblDelReason.Name = "lblDelReason";
            this.lblDelReason.Size = new System.Drawing.Size(78, 13);
            this.lblDelReason.TabIndex = 56;
            this.lblDelReason.Text = "Delete Reason";
            this.lblDelReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOperQty
            // 
            this.lblOperQty.AutoSize = true;
            this.lblOperQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperQty.Location = new System.Drawing.Point(15, 132);
            this.lblOperQty.Name = "lblOperQty";
            this.lblOperQty.Size = new System.Drawing.Size(81, 13);
            this.lblOperQty.TabIndex = 11;
            this.lblOperQty.Text = "Oper In Qty 2/3";
            this.lblOperQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHoldPrvGrpID
            // 
            this.lblHoldPrvGrpID.AutoSize = true;
            this.lblHoldPrvGrpID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldPrvGrpID.Location = new System.Drawing.Point(15, 271);
            this.lblHoldPrvGrpID.Name = "lblHoldPrvGrpID";
            this.lblHoldPrvGrpID.Size = new System.Drawing.Size(94, 13);
            this.lblHoldPrvGrpID.TabIndex = 26;
            this.lblHoldPrvGrpID.Text = "Hold Prv Group ID";
            // 
            // lblSampleRes
            // 
            this.lblSampleRes.AutoSize = true;
            this.lblSampleRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSampleRes.Location = new System.Drawing.Point(15, 339);
            this.lblSampleRes.Name = "lblSampleRes";
            this.lblSampleRes.Size = new System.Drawing.Size(75, 13);
            this.lblSampleRes.TabIndex = 34;
            this.lblSampleRes.Text = "Sample Result";
            this.lblSampleRes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHoldCode
            // 
            this.lblHoldCode.AutoSize = true;
            this.lblHoldCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldCode.Location = new System.Drawing.Point(15, 248);
            this.lblHoldCode.Name = "lblHoldCode";
            this.lblHoldCode.Size = new System.Drawing.Size(57, 13);
            this.lblHoldCode.TabIndex = 23;
            this.lblHoldCode.Text = "Hold Code";
            // 
            // lblCarrierID
            // 
            this.lblCarrierID.AutoSize = true;
            this.lblCarrierID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCarrierID.Location = new System.Drawing.Point(432, 133);
            this.lblCarrierID.Name = "lblCarrierID";
            this.lblCarrierID.Size = new System.Drawing.Size(51, 13);
            this.lblCarrierID.TabIndex = 44;
            this.lblCarrierID.Text = "Carrier ID";
            this.lblCarrierID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOwnerCode
            // 
            this.lblOwnerCode.AutoSize = true;
            this.lblOwnerCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOwnerCode.Location = new System.Drawing.Point(432, 110);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(66, 13);
            this.lblOwnerCode.TabIndex = 42;
            this.lblOwnerCode.Text = "Owner Code";
            // 
            // lblSlotNo
            // 
            this.lblSlotNo.AutoSize = true;
            this.lblSlotNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSlotNo.Location = new System.Drawing.Point(432, 156);
            this.lblSlotNo.Name = "lblSlotNo";
            this.lblSlotNo.Size = new System.Drawing.Size(42, 13);
            this.lblSlotNo.TabIndex = 46;
            this.lblSlotNo.Text = "Slot No";
            this.lblSlotNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCode
            // 
            this.lblCrtCode.AutoSize = true;
            this.lblCrtCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCode.Location = new System.Drawing.Point(432, 87);
            this.lblCrtCode.Name = "lblCrtCode";
            this.lblCrtCode.Size = new System.Drawing.Size(66, 13);
            this.lblCrtCode.TabIndex = 40;
            this.lblCrtCode.Text = "Create Code";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStatus.Location = new System.Drawing.Point(432, 225);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(77, 13);
            this.lblStatus.TabIndex = 50;
            this.lblStatus.Text = "Sub Lot Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateQty
            // 
            this.lblCreateQty.AutoSize = true;
            this.lblCreateQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateQty.Location = new System.Drawing.Point(15, 109);
            this.lblCreateQty.Name = "lblCreateQty";
            this.lblCreateQty.Size = new System.Drawing.Size(77, 13);
            this.lblCreateQty.TabIndex = 8;
            this.lblCreateQty.Text = "Create Qty 2/3";
            this.lblCreateQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty.Location = new System.Drawing.Point(15, 86);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(43, 13);
            this.lblQty.TabIndex = 5;
            this.lblQty.Text = "Qty 2/3";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Location = new System.Drawing.Point(15, 64);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 2;
            this.lblOper.Text = "Operation";
            this.lblOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpGeneral2
            // 
            this.tbpGeneral2.Controls.Add(this.grpRes);
            this.tbpGeneral2.Controls.Add(this.grpGen2Right);
            this.tbpGeneral2.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral2.Name = "tbpGeneral2";
            this.tbpGeneral2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral2.Size = new System.Drawing.Size(728, 416);
            this.tbpGeneral2.TabIndex = 2;
            this.tbpGeneral2.Text = "General 2";
            // 
            // grpRes
            // 
            this.grpRes.Controls.Add(this.txtStrRetOper);
            this.grpRes.Controls.Add(this.txtStrRetFlow);
            this.grpRes.Controls.Add(this.txtStrRetFlowSeq);
            this.grpRes.Controls.Add(this.lblStrRetOper);
            this.grpRes.Controls.Add(this.lblStrRetFlow);
            this.grpRes.Controls.Add(this.txtResvResID);
            this.grpRes.Controls.Add(this.txtEndResID);
            this.grpRes.Controls.Add(this.txtStartResId);
            this.grpRes.Controls.Add(this.lblResvRes);
            this.grpRes.Controls.Add(this.lblEndRes);
            this.grpRes.Controls.Add(this.lblStartRes);
            this.grpRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRes.Location = new System.Drawing.Point(3, 247);
            this.grpRes.Name = "grpRes";
            this.grpRes.Size = new System.Drawing.Size(722, 166);
            this.grpRes.TabIndex = 1;
            this.grpRes.TabStop = false;
            // 
            // txtStrRetOper
            // 
            this.txtStrRetOper.Location = new System.Drawing.Point(532, 43);
            this.txtStrRetOper.MaxLength = 10;
            this.txtStrRetOper.Name = "txtStrRetOper";
            this.txtStrRetOper.ReadOnly = true;
            this.txtStrRetOper.Size = new System.Drawing.Size(164, 20);
            this.txtStrRetOper.TabIndex = 10;
            this.txtStrRetOper.TabStop = false;
            // 
            // txtStrRetFlow
            // 
            this.txtStrRetFlow.Location = new System.Drawing.Point(532, 19);
            this.txtStrRetFlow.MaxLength = 20;
            this.txtStrRetFlow.Name = "txtStrRetFlow";
            this.txtStrRetFlow.ReadOnly = true;
            this.txtStrRetFlow.Size = new System.Drawing.Size(118, 20);
            this.txtStrRetFlow.TabIndex = 7;
            this.txtStrRetFlow.TabStop = false;
            // 
            // txtStrRetFlowSeq
            // 
            this.txtStrRetFlowSeq.Location = new System.Drawing.Point(656, 19);
            this.txtStrRetFlowSeq.MaxLength = 20;
            this.txtStrRetFlowSeq.Name = "txtStrRetFlowSeq";
            this.txtStrRetFlowSeq.ReadOnly = true;
            this.txtStrRetFlowSeq.Size = new System.Drawing.Size(40, 20);
            this.txtStrRetFlowSeq.TabIndex = 8;
            this.txtStrRetFlowSeq.TabStop = false;
            // 
            // lblStrRetOper
            // 
            this.lblStrRetOper.AutoSize = true;
            this.lblStrRetOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStrRetOper.Location = new System.Drawing.Point(388, 47);
            this.lblStrRetOper.Name = "lblStrRetOper";
            this.lblStrRetOper.Size = new System.Drawing.Size(93, 13);
            this.lblStrRetOper.TabIndex = 9;
            this.lblStrRetOper.Text = "Store Return Oper";
            // 
            // lblStrRetFlow
            // 
            this.lblStrRetFlow.AutoSize = true;
            this.lblStrRetFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStrRetFlow.Location = new System.Drawing.Point(388, 23);
            this.lblStrRetFlow.Name = "lblStrRetFlow";
            this.lblStrRetFlow.Size = new System.Drawing.Size(92, 13);
            this.lblStrRetFlow.TabIndex = 6;
            this.lblStrRetFlow.Text = "Store Return Flow";
            // 
            // txtResvResID
            // 
            this.txtResvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResvResID.Location = new System.Drawing.Point(158, 65);
            this.txtResvResID.MaxLength = 20;
            this.txtResvResID.Name = "txtResvResID";
            this.txtResvResID.ReadOnly = true;
            this.txtResvResID.Size = new System.Drawing.Size(162, 20);
            this.txtResvResID.TabIndex = 5;
            this.txtResvResID.TabStop = false;
            // 
            // txtEndResID
            // 
            this.txtEndResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndResID.Location = new System.Drawing.Point(158, 42);
            this.txtEndResID.MaxLength = 20;
            this.txtEndResID.Name = "txtEndResID";
            this.txtEndResID.ReadOnly = true;
            this.txtEndResID.Size = new System.Drawing.Size(162, 20);
            this.txtEndResID.TabIndex = 3;
            this.txtEndResID.TabStop = false;
            // 
            // txtStartResId
            // 
            this.txtStartResId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartResId.Location = new System.Drawing.Point(158, 19);
            this.txtStartResId.MaxLength = 20;
            this.txtStartResId.Name = "txtStartResId";
            this.txtStartResId.ReadOnly = true;
            this.txtStartResId.Size = new System.Drawing.Size(162, 20);
            this.txtStartResId.TabIndex = 1;
            this.txtStartResId.TabStop = false;
            // 
            // lblResvRes
            // 
            this.lblResvRes.AutoSize = true;
            this.lblResvRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResvRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResvRes.Location = new System.Drawing.Point(20, 67);
            this.lblResvRes.Name = "lblResvRes";
            this.lblResvRes.Size = new System.Drawing.Size(110, 13);
            this.lblResvRes.TabIndex = 4;
            this.lblResvRes.Text = "Reserve Resource ID";
            this.lblResvRes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndRes
            // 
            this.lblEndRes.AutoSize = true;
            this.lblEndRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndRes.Location = new System.Drawing.Point(20, 44);
            this.lblEndRes.Name = "lblEndRes";
            this.lblEndRes.Size = new System.Drawing.Size(89, 13);
            this.lblEndRes.TabIndex = 2;
            this.lblEndRes.Text = "End Resource ID";
            this.lblEndRes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStartRes
            // 
            this.lblStartRes.AutoSize = true;
            this.lblStartRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStartRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartRes.Location = new System.Drawing.Point(20, 21);
            this.lblStartRes.Name = "lblStartRes";
            this.lblStartRes.Size = new System.Drawing.Size(92, 13);
            this.lblStartRes.TabIndex = 0;
            this.lblStartRes.Text = "Start Resource ID";
            this.lblStartRes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpGen2Right
            // 
            this.grpGen2Right.Controls.Add(this.txtReturnOption);
            this.grpGen2Right.Controls.Add(this.lblReturnOption);
            this.grpGen2Right.Controls.Add(this.txtReworkStopOper);
            this.grpGen2Right.Controls.Add(this.lblReworkStopOper);
            this.grpGen2Right.Controls.Add(this.txtReworkDepth);
            this.grpGen2Right.Controls.Add(this.chkNstd);
            this.grpGen2Right.Controls.Add(this.chkRepair);
            this.grpGen2Right.Controls.Add(this.chkLocalReworkFlag);
            this.grpGen2Right.Controls.Add(this.chkRework);
            this.grpGen2Right.Controls.Add(this.txtRepairRetOper);
            this.grpGen2Right.Controls.Add(this.lblRepairRetOper);
            this.grpGen2Right.Controls.Add(this.txtReworkTime);
            this.grpGen2Right.Controls.Add(this.txtNstdTime);
            this.grpGen2Right.Controls.Add(this.txtNstdReturnOper);
            this.grpGen2Right.Controls.Add(this.txtNstdReturnFlow);
            this.grpGen2Right.Controls.Add(this.txtReworkEndOper);
            this.grpGen2Right.Controls.Add(this.txtReworkEndFlow);
            this.grpGen2Right.Controls.Add(this.txtReworkReturnOper);
            this.grpGen2Right.Controls.Add(this.txtNstdReturnFlowSeq);
            this.grpGen2Right.Controls.Add(this.txtReworkEndFlowSeq);
            this.grpGen2Right.Controls.Add(this.txtReworkReturnFlowSeq);
            this.grpGen2Right.Controls.Add(this.txtReworkReturnFlow);
            this.grpGen2Right.Controls.Add(this.txtReworkCnt);
            this.grpGen2Right.Controls.Add(this.txtReworkCode);
            this.grpGen2Right.Controls.Add(this.lblRwkTime);
            this.grpGen2Right.Controls.Add(this.lblNstdTime);
            this.grpGen2Right.Controls.Add(this.lblNstdReturnOper);
            this.grpGen2Right.Controls.Add(this.lblNstdReturnFlow);
            this.grpGen2Right.Controls.Add(this.lblReworkEndOper);
            this.grpGen2Right.Controls.Add(this.lblReworkEndFlow);
            this.grpGen2Right.Controls.Add(this.lblReworkReturnOper);
            this.grpGen2Right.Controls.Add(this.lblReworkReturnFlow);
            this.grpGen2Right.Controls.Add(this.lblReworkCnt);
            this.grpGen2Right.Controls.Add(this.lblReworkCode);
            this.grpGen2Right.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGen2Right.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGen2Right.Location = new System.Drawing.Point(3, 0);
            this.grpGen2Right.Name = "grpGen2Right";
            this.grpGen2Right.Size = new System.Drawing.Size(722, 247);
            this.grpGen2Right.TabIndex = 0;
            this.grpGen2Right.TabStop = false;
            this.grpGen2Right.Text = "Rework Information";
            // 
            // txtReturnOption
            // 
            this.txtReturnOption.Location = new System.Drawing.Point(158, 208);
            this.txtReturnOption.MaxLength = 50;
            this.txtReturnOption.Name = "txtReturnOption";
            this.txtReturnOption.ReadOnly = true;
            this.txtReturnOption.Size = new System.Drawing.Size(236, 20);
            this.txtReturnOption.TabIndex = 20;
            this.txtReturnOption.TabStop = false;
            // 
            // lblReturnOption
            // 
            this.lblReturnOption.AutoSize = true;
            this.lblReturnOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReturnOption.Location = new System.Drawing.Point(20, 211);
            this.lblReturnOption.Name = "lblReturnOption";
            this.lblReturnOption.Size = new System.Drawing.Size(73, 13);
            this.lblReturnOption.TabIndex = 19;
            this.lblReturnOption.Text = "Return Option";
            // 
            // txtReworkStopOper
            // 
            this.txtReworkStopOper.Location = new System.Drawing.Point(158, 64);
            this.txtReworkStopOper.MaxLength = 10;
            this.txtReworkStopOper.Name = "txtReworkStopOper";
            this.txtReworkStopOper.ReadOnly = true;
            this.txtReworkStopOper.Size = new System.Drawing.Size(162, 20);
            this.txtReworkStopOper.TabIndex = 6;
            this.txtReworkStopOper.TabStop = false;
            // 
            // lblReworkStopOper
            // 
            this.lblReworkStopOper.AutoSize = true;
            this.lblReworkStopOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkStopOper.Location = new System.Drawing.Point(20, 67);
            this.lblReworkStopOper.Name = "lblReworkStopOper";
            this.lblReworkStopOper.Size = new System.Drawing.Size(95, 13);
            this.lblReworkStopOper.TabIndex = 5;
            this.lblReworkStopOper.Text = "Rework Stop Oper";
            // 
            // txtReworkDepth
            // 
            this.txtReworkDepth.Location = new System.Drawing.Point(241, 40);
            this.txtReworkDepth.MaxLength = 25;
            this.txtReworkDepth.Name = "txtReworkDepth";
            this.txtReworkDepth.ReadOnly = true;
            this.txtReworkDepth.Size = new System.Drawing.Size(79, 20);
            this.txtReworkDepth.TabIndex = 4;
            this.txtReworkDepth.TabStop = false;
            // 
            // chkNstd
            // 
            this.chkNstd.AutoSize = true;
            this.chkNstd.Enabled = false;
            this.chkNstd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkNstd.Location = new System.Drawing.Point(569, 139);
            this.chkNstd.Name = "chkNstd";
            this.chkNstd.Size = new System.Drawing.Size(121, 18);
            this.chkNstd.TabIndex = 31;
            this.chkNstd.TabStop = false;
            this.chkNstd.Text = "Non Standard Flag";
            // 
            // chkRepair
            // 
            this.chkRepair.AutoSize = true;
            this.chkRepair.Enabled = false;
            this.chkRepair.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRepair.Location = new System.Drawing.Point(569, 162);
            this.chkRepair.Name = "chkRepair";
            this.chkRepair.Size = new System.Drawing.Size(86, 18);
            this.chkRepair.TabIndex = 33;
            this.chkRepair.TabStop = false;
            this.chkRepair.Text = "Repair Flag";
            // 
            // chkLocalReworkFlag
            // 
            this.chkLocalReworkFlag.AutoSize = true;
            this.chkLocalReworkFlag.Enabled = false;
            this.chkLocalReworkFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkLocalReworkFlag.Location = new System.Drawing.Point(391, 162);
            this.chkLocalReworkFlag.Name = "chkLocalReworkFlag";
            this.chkLocalReworkFlag.Size = new System.Drawing.Size(121, 18);
            this.chkLocalReworkFlag.TabIndex = 32;
            this.chkLocalReworkFlag.TabStop = false;
            this.chkLocalReworkFlag.Text = "Local Rework Flag";
            // 
            // chkRework
            // 
            this.chkRework.AutoSize = true;
            this.chkRework.Enabled = false;
            this.chkRework.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRework.Location = new System.Drawing.Point(391, 139);
            this.chkRework.Name = "chkRework";
            this.chkRework.Size = new System.Drawing.Size(92, 18);
            this.chkRework.TabIndex = 30;
            this.chkRework.TabStop = false;
            this.chkRework.Text = "Rework Flag";
            // 
            // txtRepairRetOper
            // 
            this.txtRepairRetOper.Location = new System.Drawing.Point(532, 88);
            this.txtRepairRetOper.MaxLength = 20;
            this.txtRepairRetOper.Name = "txtRepairRetOper";
            this.txtRepairRetOper.ReadOnly = true;
            this.txtRepairRetOper.Size = new System.Drawing.Size(164, 20);
            this.txtRepairRetOper.TabIndex = 29;
            this.txtRepairRetOper.TabStop = false;
            // 
            // lblRepairRetOper
            // 
            this.lblRepairRetOper.AutoSize = true;
            this.lblRepairRetOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRepairRetOper.Location = new System.Drawing.Point(388, 92);
            this.lblRepairRetOper.Name = "lblRepairRetOper";
            this.lblRepairRetOper.Size = new System.Drawing.Size(99, 13);
            this.lblRepairRetOper.TabIndex = 28;
            this.lblRepairRetOper.Text = "Repair Return Oper";
            // 
            // txtReworkTime
            // 
            this.txtReworkTime.Location = new System.Drawing.Point(158, 184);
            this.txtReworkTime.MaxLength = 10;
            this.txtReworkTime.Name = "txtReworkTime";
            this.txtReworkTime.ReadOnly = true;
            this.txtReworkTime.Size = new System.Drawing.Size(162, 20);
            this.txtReworkTime.TabIndex = 18;
            this.txtReworkTime.TabStop = false;
            // 
            // txtNstdTime
            // 
            this.txtNstdTime.Location = new System.Drawing.Point(532, 64);
            this.txtNstdTime.MaxLength = 20;
            this.txtNstdTime.Name = "txtNstdTime";
            this.txtNstdTime.ReadOnly = true;
            this.txtNstdTime.Size = new System.Drawing.Size(164, 20);
            this.txtNstdTime.TabIndex = 27;
            this.txtNstdTime.TabStop = false;
            // 
            // txtNstdReturnOper
            // 
            this.txtNstdReturnOper.Location = new System.Drawing.Point(532, 40);
            this.txtNstdReturnOper.MaxLength = 10;
            this.txtNstdReturnOper.Name = "txtNstdReturnOper";
            this.txtNstdReturnOper.ReadOnly = true;
            this.txtNstdReturnOper.Size = new System.Drawing.Size(164, 20);
            this.txtNstdReturnOper.TabIndex = 25;
            this.txtNstdReturnOper.TabStop = false;
            // 
            // txtNstdReturnFlow
            // 
            this.txtNstdReturnFlow.Location = new System.Drawing.Point(532, 16);
            this.txtNstdReturnFlow.MaxLength = 20;
            this.txtNstdReturnFlow.Name = "txtNstdReturnFlow";
            this.txtNstdReturnFlow.ReadOnly = true;
            this.txtNstdReturnFlow.Size = new System.Drawing.Size(118, 20);
            this.txtNstdReturnFlow.TabIndex = 22;
            this.txtNstdReturnFlow.TabStop = false;
            // 
            // txtReworkEndOper
            // 
            this.txtReworkEndOper.Location = new System.Drawing.Point(158, 160);
            this.txtReworkEndOper.MaxLength = 10;
            this.txtReworkEndOper.Name = "txtReworkEndOper";
            this.txtReworkEndOper.ReadOnly = true;
            this.txtReworkEndOper.Size = new System.Drawing.Size(162, 20);
            this.txtReworkEndOper.TabIndex = 16;
            this.txtReworkEndOper.TabStop = false;
            // 
            // txtReworkEndFlow
            // 
            this.txtReworkEndFlow.Location = new System.Drawing.Point(158, 136);
            this.txtReworkEndFlow.MaxLength = 20;
            this.txtReworkEndFlow.Name = "txtReworkEndFlow";
            this.txtReworkEndFlow.ReadOnly = true;
            this.txtReworkEndFlow.Size = new System.Drawing.Size(116, 20);
            this.txtReworkEndFlow.TabIndex = 13;
            this.txtReworkEndFlow.TabStop = false;
            // 
            // txtReworkReturnOper
            // 
            this.txtReworkReturnOper.Location = new System.Drawing.Point(158, 112);
            this.txtReworkReturnOper.MaxLength = 10;
            this.txtReworkReturnOper.Name = "txtReworkReturnOper";
            this.txtReworkReturnOper.ReadOnly = true;
            this.txtReworkReturnOper.Size = new System.Drawing.Size(162, 20);
            this.txtReworkReturnOper.TabIndex = 11;
            this.txtReworkReturnOper.TabStop = false;
            // 
            // txtNstdReturnFlowSeq
            // 
            this.txtNstdReturnFlowSeq.Location = new System.Drawing.Point(656, 16);
            this.txtNstdReturnFlowSeq.MaxLength = 20;
            this.txtNstdReturnFlowSeq.Name = "txtNstdReturnFlowSeq";
            this.txtNstdReturnFlowSeq.ReadOnly = true;
            this.txtNstdReturnFlowSeq.Size = new System.Drawing.Size(40, 20);
            this.txtNstdReturnFlowSeq.TabIndex = 23;
            this.txtNstdReturnFlowSeq.TabStop = false;
            // 
            // txtReworkEndFlowSeq
            // 
            this.txtReworkEndFlowSeq.Location = new System.Drawing.Point(280, 136);
            this.txtReworkEndFlowSeq.MaxLength = 20;
            this.txtReworkEndFlowSeq.Name = "txtReworkEndFlowSeq";
            this.txtReworkEndFlowSeq.ReadOnly = true;
            this.txtReworkEndFlowSeq.Size = new System.Drawing.Size(40, 20);
            this.txtReworkEndFlowSeq.TabIndex = 14;
            this.txtReworkEndFlowSeq.TabStop = false;
            // 
            // txtReworkReturnFlowSeq
            // 
            this.txtReworkReturnFlowSeq.Location = new System.Drawing.Point(280, 88);
            this.txtReworkReturnFlowSeq.MaxLength = 20;
            this.txtReworkReturnFlowSeq.Name = "txtReworkReturnFlowSeq";
            this.txtReworkReturnFlowSeq.ReadOnly = true;
            this.txtReworkReturnFlowSeq.Size = new System.Drawing.Size(40, 20);
            this.txtReworkReturnFlowSeq.TabIndex = 9;
            this.txtReworkReturnFlowSeq.TabStop = false;
            // 
            // txtReworkReturnFlow
            // 
            this.txtReworkReturnFlow.Location = new System.Drawing.Point(158, 88);
            this.txtReworkReturnFlow.MaxLength = 20;
            this.txtReworkReturnFlow.Name = "txtReworkReturnFlow";
            this.txtReworkReturnFlow.ReadOnly = true;
            this.txtReworkReturnFlow.Size = new System.Drawing.Size(116, 20);
            this.txtReworkReturnFlow.TabIndex = 8;
            this.txtReworkReturnFlow.TabStop = false;
            // 
            // txtReworkCnt
            // 
            this.txtReworkCnt.Location = new System.Drawing.Point(158, 40);
            this.txtReworkCnt.MaxLength = 25;
            this.txtReworkCnt.Name = "txtReworkCnt";
            this.txtReworkCnt.ReadOnly = true;
            this.txtReworkCnt.Size = new System.Drawing.Size(79, 20);
            this.txtReworkCnt.TabIndex = 3;
            this.txtReworkCnt.TabStop = false;
            // 
            // txtReworkCode
            // 
            this.txtReworkCode.Location = new System.Drawing.Point(158, 16);
            this.txtReworkCode.MaxLength = 10;
            this.txtReworkCode.Name = "txtReworkCode";
            this.txtReworkCode.ReadOnly = true;
            this.txtReworkCode.Size = new System.Drawing.Size(162, 20);
            this.txtReworkCode.TabIndex = 1;
            this.txtReworkCode.TabStop = false;
            // 
            // lblRwkTime
            // 
            this.lblRwkTime.AutoSize = true;
            this.lblRwkTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRwkTime.Location = new System.Drawing.Point(20, 186);
            this.lblRwkTime.Name = "lblRwkTime";
            this.lblRwkTime.Size = new System.Drawing.Size(70, 13);
            this.lblRwkTime.TabIndex = 17;
            this.lblRwkTime.Text = "Rework Time";
            // 
            // lblNstdTime
            // 
            this.lblNstdTime.AutoSize = true;
            this.lblNstdTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNstdTime.Location = new System.Drawing.Point(388, 68);
            this.lblNstdTime.Name = "lblNstdTime";
            this.lblNstdTime.Size = new System.Drawing.Size(63, 13);
            this.lblNstdTime.TabIndex = 26;
            this.lblNstdTime.Text = "NSTD Time";
            // 
            // lblNstdReturnOper
            // 
            this.lblNstdReturnOper.AutoSize = true;
            this.lblNstdReturnOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNstdReturnOper.Location = new System.Drawing.Point(388, 44);
            this.lblNstdReturnOper.Name = "lblNstdReturnOper";
            this.lblNstdReturnOper.Size = new System.Drawing.Size(98, 13);
            this.lblNstdReturnOper.TabIndex = 24;
            this.lblNstdReturnOper.Text = "NSTD Return Oper";
            // 
            // lblNstdReturnFlow
            // 
            this.lblNstdReturnFlow.AutoSize = true;
            this.lblNstdReturnFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNstdReturnFlow.Location = new System.Drawing.Point(388, 20);
            this.lblNstdReturnFlow.Name = "lblNstdReturnFlow";
            this.lblNstdReturnFlow.Size = new System.Drawing.Size(97, 13);
            this.lblNstdReturnFlow.TabIndex = 21;
            this.lblNstdReturnFlow.Text = "NSTD Return Flow";
            // 
            // lblReworkEndOper
            // 
            this.lblReworkEndOper.AutoSize = true;
            this.lblReworkEndOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkEndOper.Location = new System.Drawing.Point(20, 163);
            this.lblReworkEndOper.Name = "lblReworkEndOper";
            this.lblReworkEndOper.Size = new System.Drawing.Size(92, 13);
            this.lblReworkEndOper.TabIndex = 15;
            this.lblReworkEndOper.Text = "Rework End Oper";
            // 
            // lblReworkEndFlow
            // 
            this.lblReworkEndFlow.AutoSize = true;
            this.lblReworkEndFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkEndFlow.Location = new System.Drawing.Point(20, 139);
            this.lblReworkEndFlow.Name = "lblReworkEndFlow";
            this.lblReworkEndFlow.Size = new System.Drawing.Size(91, 13);
            this.lblReworkEndFlow.TabIndex = 12;
            this.lblReworkEndFlow.Text = "Rework End Flow";
            // 
            // lblReworkReturnOper
            // 
            this.lblReworkReturnOper.AutoSize = true;
            this.lblReworkReturnOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkReturnOper.Location = new System.Drawing.Point(20, 115);
            this.lblReworkReturnOper.Name = "lblReworkReturnOper";
            this.lblReworkReturnOper.Size = new System.Drawing.Size(105, 13);
            this.lblReworkReturnOper.TabIndex = 10;
            this.lblReworkReturnOper.Text = "Rework Return Oper";
            // 
            // lblReworkReturnFlow
            // 
            this.lblReworkReturnFlow.AutoSize = true;
            this.lblReworkReturnFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkReturnFlow.Location = new System.Drawing.Point(20, 91);
            this.lblReworkReturnFlow.Name = "lblReworkReturnFlow";
            this.lblReworkReturnFlow.Size = new System.Drawing.Size(104, 13);
            this.lblReworkReturnFlow.TabIndex = 7;
            this.lblReworkReturnFlow.Text = "Rework Return Flow";
            // 
            // lblReworkCnt
            // 
            this.lblReworkCnt.AutoSize = true;
            this.lblReworkCnt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkCnt.Location = new System.Drawing.Point(20, 43);
            this.lblReworkCnt.Name = "lblReworkCnt";
            this.lblReworkCnt.Size = new System.Drawing.Size(112, 13);
            this.lblReworkCnt.TabIndex = 2;
            this.lblReworkCnt.Text = "Rework Count/ Depth";
            // 
            // lblReworkCode
            // 
            this.lblReworkCode.AutoSize = true;
            this.lblReworkCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkCode.Location = new System.Drawing.Point(20, 19);
            this.lblReworkCode.Name = "lblReworkCode";
            this.lblReworkCode.Size = new System.Drawing.Size(72, 13);
            this.lblReworkCode.TabIndex = 0;
            this.lblReworkCode.Text = "Rework Code";
            // 
            // tbpGeneral3
            // 
            this.tbpGeneral3.Controls.Add(this.grpExtra);
            this.tbpGeneral3.Controls.Add(this.grpGen3Mid);
            this.tbpGeneral3.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral3.Name = "tbpGeneral3";
            this.tbpGeneral3.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral3.Size = new System.Drawing.Size(728, 416);
            this.tbpGeneral3.TabIndex = 5;
            this.tbpGeneral3.Text = "General 3";
            // 
            // grpExtra
            // 
            this.grpExtra.Controls.Add(this.txtCellJudge);
            this.grpExtra.Controls.Add(this.lblCellJudge);
            this.grpExtra.Controls.Add(this.txtCellGrade);
            this.grpExtra.Controls.Add(this.txtGradeCode);
            this.grpExtra.Controls.Add(this.txtGrade);
            this.grpExtra.Controls.Add(this.lblCellGrade);
            this.grpExtra.Controls.Add(this.lblGradeCode);
            this.grpExtra.Controls.Add(this.lblGrade);
            this.grpExtra.Controls.Add(this.txtLocation3);
            this.grpExtra.Controls.Add(this.lblLocation3);
            this.grpExtra.Controls.Add(this.txtLocation2);
            this.grpExtra.Controls.Add(this.lblLocation2);
            this.grpExtra.Controls.Add(this.txtLocation1);
            this.grpExtra.Controls.Add(this.lblLocation1);
            this.grpExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpExtra.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpExtra.Location = new System.Drawing.Point(3, 144);
            this.grpExtra.Name = "grpExtra";
            this.grpExtra.Size = new System.Drawing.Size(722, 269);
            this.grpExtra.TabIndex = 1;
            this.grpExtra.TabStop = false;
            // 
            // txtCellJudge
            // 
            this.txtCellJudge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCellJudge.Location = new System.Drawing.Point(164, 203);
            this.txtCellJudge.MaxLength = 200;
            this.txtCellJudge.Multiline = true;
            this.txtCellJudge.Name = "txtCellJudge";
            this.txtCellJudge.ReadOnly = true;
            this.txtCellJudge.Size = new System.Drawing.Size(540, 60);
            this.txtCellJudge.TabIndex = 13;
            this.txtCellJudge.TabStop = false;
            // 
            // lblCellJudge
            // 
            this.lblCellJudge.AutoSize = true;
            this.lblCellJudge.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellJudge.Location = new System.Drawing.Point(15, 203);
            this.lblCellJudge.Name = "lblCellJudge";
            this.lblCellJudge.Size = new System.Drawing.Size(56, 13);
            this.lblCellJudge.TabIndex = 12;
            this.lblCellJudge.Text = "Cell Judge";
            this.lblCellJudge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCellGrade
            // 
            this.txtCellGrade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCellGrade.Location = new System.Drawing.Point(164, 139);
            this.txtCellGrade.MaxLength = 200;
            this.txtCellGrade.Multiline = true;
            this.txtCellGrade.Name = "txtCellGrade";
            this.txtCellGrade.ReadOnly = true;
            this.txtCellGrade.Size = new System.Drawing.Size(540, 60);
            this.txtCellGrade.TabIndex = 11;
            this.txtCellGrade.TabStop = false;
            // 
            // txtGradeCode
            // 
            this.txtGradeCode.Location = new System.Drawing.Point(164, 115);
            this.txtGradeCode.MaxLength = 25;
            this.txtGradeCode.Name = "txtGradeCode";
            this.txtGradeCode.ReadOnly = true;
            this.txtGradeCode.Size = new System.Drawing.Size(162, 20);
            this.txtGradeCode.TabIndex = 9;
            this.txtGradeCode.TabStop = false;
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(164, 91);
            this.txtGrade.MaxLength = 25;
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.ReadOnly = true;
            this.txtGrade.Size = new System.Drawing.Size(162, 20);
            this.txtGrade.TabIndex = 7;
            this.txtGrade.TabStop = false;
            // 
            // lblCellGrade
            // 
            this.lblCellGrade.AutoSize = true;
            this.lblCellGrade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellGrade.Location = new System.Drawing.Point(15, 141);
            this.lblCellGrade.Name = "lblCellGrade";
            this.lblCellGrade.Size = new System.Drawing.Size(56, 13);
            this.lblCellGrade.TabIndex = 10;
            this.lblCellGrade.Text = "Cell Grade";
            this.lblCellGrade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGradeCode
            // 
            this.lblGradeCode.AutoSize = true;
            this.lblGradeCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGradeCode.Location = new System.Drawing.Point(15, 117);
            this.lblGradeCode.Name = "lblGradeCode";
            this.lblGradeCode.Size = new System.Drawing.Size(64, 13);
            this.lblGradeCode.TabIndex = 8;
            this.lblGradeCode.Text = "Grade Code";
            this.lblGradeCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrade.Location = new System.Drawing.Point(15, 93);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(36, 13);
            this.lblGrade.TabIndex = 6;
            this.lblGrade.Text = "Grade";
            this.lblGrade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLocation3
            // 
            this.txtLocation3.Location = new System.Drawing.Point(164, 67);
            this.txtLocation3.MaxLength = 20;
            this.txtLocation3.Name = "txtLocation3";
            this.txtLocation3.ReadOnly = true;
            this.txtLocation3.Size = new System.Drawing.Size(162, 20);
            this.txtLocation3.TabIndex = 5;
            this.txtLocation3.TabStop = false;
            // 
            // lblLocation3
            // 
            this.lblLocation3.AutoSize = true;
            this.lblLocation3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation3.Location = new System.Drawing.Point(15, 69);
            this.lblLocation3.Name = "lblLocation3";
            this.lblLocation3.Size = new System.Drawing.Size(94, 13);
            this.lblLocation3.TabIndex = 4;
            this.lblLocation3.Text = "SubLot Location 3";
            this.lblLocation3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLocation2
            // 
            this.txtLocation2.Location = new System.Drawing.Point(164, 43);
            this.txtLocation2.MaxLength = 20;
            this.txtLocation2.Name = "txtLocation2";
            this.txtLocation2.ReadOnly = true;
            this.txtLocation2.Size = new System.Drawing.Size(162, 20);
            this.txtLocation2.TabIndex = 3;
            this.txtLocation2.TabStop = false;
            // 
            // lblLocation2
            // 
            this.lblLocation2.AutoSize = true;
            this.lblLocation2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation2.Location = new System.Drawing.Point(15, 45);
            this.lblLocation2.Name = "lblLocation2";
            this.lblLocation2.Size = new System.Drawing.Size(94, 13);
            this.lblLocation2.TabIndex = 2;
            this.lblLocation2.Text = "SubLot Location 2";
            this.lblLocation2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLocation1
            // 
            this.txtLocation1.Location = new System.Drawing.Point(164, 19);
            this.txtLocation1.MaxLength = 20;
            this.txtLocation1.Name = "txtLocation1";
            this.txtLocation1.ReadOnly = true;
            this.txtLocation1.Size = new System.Drawing.Size(162, 20);
            this.txtLocation1.TabIndex = 1;
            this.txtLocation1.TabStop = false;
            // 
            // lblLocation1
            // 
            this.lblLocation1.AutoSize = true;
            this.lblLocation1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation1.Location = new System.Drawing.Point(15, 21);
            this.lblLocation1.Name = "lblLocation1";
            this.lblLocation1.Size = new System.Drawing.Size(94, 13);
            this.lblLocation1.TabIndex = 0;
            this.lblLocation1.Text = "SubLot Location 1";
            this.lblLocation1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpGen3Mid
            // 
            this.grpGen3Mid.Controls.Add(this.txtComment);
            this.grpGen3Mid.Controls.Add(this.txtLastActHistSeq);
            this.grpGen3Mid.Controls.Add(this.txtLastHistSeq);
            this.grpGen3Mid.Controls.Add(this.txtLastTrnTime);
            this.grpGen3Mid.Controls.Add(this.txtLastTrnCode);
            this.grpGen3Mid.Controls.Add(this.lblLastHistSeq);
            this.grpGen3Mid.Controls.Add(this.lblLastActHistSeq);
            this.grpGen3Mid.Controls.Add(this.lblComment);
            this.grpGen3Mid.Controls.Add(this.lblLastTrnTime);
            this.grpGen3Mid.Controls.Add(this.lblLastTrnCode);
            this.grpGen3Mid.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGen3Mid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGen3Mid.Location = new System.Drawing.Point(3, 3);
            this.grpGen3Mid.Name = "grpGen3Mid";
            this.grpGen3Mid.Size = new System.Drawing.Size(722, 141);
            this.grpGen3Mid.TabIndex = 0;
            this.grpGen3Mid.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(164, 64);
            this.txtComment.MaxLength = 400;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.Size = new System.Drawing.Size(540, 69);
            this.txtComment.TabIndex = 9;
            this.txtComment.TabStop = false;
            // 
            // txtLastActHistSeq
            // 
            this.txtLastActHistSeq.Location = new System.Drawing.Point(538, 40);
            this.txtLastActHistSeq.MaxLength = 25;
            this.txtLastActHistSeq.Name = "txtLastActHistSeq";
            this.txtLastActHistSeq.ReadOnly = true;
            this.txtLastActHistSeq.Size = new System.Drawing.Size(166, 20);
            this.txtLastActHistSeq.TabIndex = 7;
            this.txtLastActHistSeq.TabStop = false;
            // 
            // txtLastHistSeq
            // 
            this.txtLastHistSeq.Location = new System.Drawing.Point(538, 16);
            this.txtLastHistSeq.MaxLength = 25;
            this.txtLastHistSeq.Name = "txtLastHistSeq";
            this.txtLastHistSeq.ReadOnly = true;
            this.txtLastHistSeq.Size = new System.Drawing.Size(166, 20);
            this.txtLastHistSeq.TabIndex = 5;
            this.txtLastHistSeq.TabStop = false;
            // 
            // txtLastTrnTime
            // 
            this.txtLastTrnTime.Location = new System.Drawing.Point(164, 40);
            this.txtLastTrnTime.MaxLength = 25;
            this.txtLastTrnTime.Name = "txtLastTrnTime";
            this.txtLastTrnTime.ReadOnly = true;
            this.txtLastTrnTime.Size = new System.Drawing.Size(162, 20);
            this.txtLastTrnTime.TabIndex = 3;
            this.txtLastTrnTime.TabStop = false;
            // 
            // txtLastTrnCode
            // 
            this.txtLastTrnCode.Location = new System.Drawing.Point(164, 16);
            this.txtLastTrnCode.MaxLength = 12;
            this.txtLastTrnCode.Name = "txtLastTrnCode";
            this.txtLastTrnCode.ReadOnly = true;
            this.txtLastTrnCode.Size = new System.Drawing.Size(162, 20);
            this.txtLastTrnCode.TabIndex = 1;
            this.txtLastTrnCode.TabStop = false;
            // 
            // lblLastHistSeq
            // 
            this.lblLastHistSeq.AutoSize = true;
            this.lblLastHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastHistSeq.Location = new System.Drawing.Point(392, 19);
            this.lblLastHistSeq.Name = "lblLastHistSeq";
            this.lblLastHistSeq.Size = new System.Drawing.Size(70, 13);
            this.lblLastHistSeq.TabIndex = 4;
            this.lblLastHistSeq.Text = "Last Hist Seq";
            // 
            // lblLastActHistSeq
            // 
            this.lblLastActHistSeq.AutoSize = true;
            this.lblLastActHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastActHistSeq.Location = new System.Drawing.Point(392, 43);
            this.lblLastActHistSeq.Name = "lblLastActHistSeq";
            this.lblLastActHistSeq.Size = new System.Drawing.Size(103, 13);
            this.lblLastActHistSeq.TabIndex = 6;
            this.lblLastActHistSeq.Text = "Last Active Hist Seq";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Location = new System.Drawing.Point(15, 67);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(74, 13);
            this.lblComment.TabIndex = 8;
            this.lblComment.Text = "Last Comment";
            // 
            // lblLastTrnTime
            // 
            this.lblLastTrnTime.AutoSize = true;
            this.lblLastTrnTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastTrnTime.Location = new System.Drawing.Point(15, 43);
            this.lblLastTrnTime.Name = "lblLastTrnTime";
            this.lblLastTrnTime.Size = new System.Drawing.Size(112, 13);
            this.lblLastTrnTime.TabIndex = 2;
            this.lblLastTrnTime.Text = "Last Transaction Time";
            // 
            // lblLastTrnCode
            // 
            this.lblLastTrnCode.AutoSize = true;
            this.lblLastTrnCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastTrnCode.Location = new System.Drawing.Point(15, 19);
            this.lblLastTrnCode.Name = "lblLastTrnCode";
            this.lblLastTrnCode.Size = new System.Drawing.Size(114, 13);
            this.lblLastTrnCode.TabIndex = 0;
            this.lblLastTrnCode.Text = "Last Transaction Code";
            // 
            // tbpAttribute
            // 
            this.tbpAttribute.Controls.Add(this.udcAttributeStatus);
            this.tbpAttribute.Location = new System.Drawing.Point(4, 22);
            this.tbpAttribute.Name = "tbpAttribute";
            this.tbpAttribute.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAttribute.Size = new System.Drawing.Size(728, 416);
            this.tbpAttribute.TabIndex = 4;
            this.tbpAttribute.Text = "Attribute";
            // 
            // udcAttributeStatus
            // 
            this.udcAttributeStatus.AttributeKey = this.txtSublotID.Text;
            this.udcAttributeStatus.AttributeLayout = Miracom.BASCore.udcAttributeStatus.udcAttributeStatusLayout.VIEW;
            this.udcAttributeStatus.AttributeName = "";
            this.udcAttributeStatus.AttributeType = "SUBLOT";
            this.udcAttributeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcAttributeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcAttributeStatus.FromSequence = 0;
            this.udcAttributeStatus.Location = new System.Drawing.Point(3, 3);
            this.udcAttributeStatus.Name = "udcAttributeStatus";
            this.udcAttributeStatus.Size = new System.Drawing.Size(722, 410);
            this.udcAttributeStatus.TabIndex = 0;
            this.udcAttributeStatus.ToSequence = 2147483647;
            // 
            // txtSublotID
            // 
            this.txtSublotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSublotID.Location = new System.Drawing.Point(120, 16);
            this.txtSublotID.MaxLength = 30;
            this.txtSublotID.Name = "txtSublotID";
            this.txtSublotID.Size = new System.Drawing.Size(200, 20);
            this.txtSublotID.TabIndex = 1;
            // 
            // tbpCrtCmfField
            // 
            this.tbpCrtCmfField.Controls.Add(this.grpCmf);
            this.tbpCrtCmfField.Location = new System.Drawing.Point(4, 22);
            this.tbpCrtCmfField.Name = "tbpCrtCmfField";
            this.tbpCrtCmfField.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCrtCmfField.Size = new System.Drawing.Size(728, 416);
            this.tbpCrtCmfField.TabIndex = 3;
            this.tbpCrtCmfField.Text = "Create Customized Field";
            // 
            // grpCmf
            // 
            this.grpCmf.Controls.Add(this.txtCmf17);
            this.grpCmf.Controls.Add(this.txtCmf15);
            this.grpCmf.Controls.Add(this.txtCmf20);
            this.grpCmf.Controls.Add(this.txtCmf19);
            this.grpCmf.Controls.Add(this.txtCmf18);
            this.grpCmf.Controls.Add(this.txtCmf16);
            this.grpCmf.Controls.Add(this.txtCmf14);
            this.grpCmf.Controls.Add(this.txtCmf13);
            this.grpCmf.Controls.Add(this.txtCmf12);
            this.grpCmf.Controls.Add(this.txtCmf11);
            this.grpCmf.Controls.Add(this.lblCMF20);
            this.grpCmf.Controls.Add(this.lblCMF19);
            this.grpCmf.Controls.Add(this.lblCMF18);
            this.grpCmf.Controls.Add(this.lblCMF17);
            this.grpCmf.Controls.Add(this.lblCMF16);
            this.grpCmf.Controls.Add(this.lblCMF15);
            this.grpCmf.Controls.Add(this.lblCMF14);
            this.grpCmf.Controls.Add(this.lblCMF13);
            this.grpCmf.Controls.Add(this.lblCMF12);
            this.grpCmf.Controls.Add(this.lblCMF11);
            this.grpCmf.Controls.Add(this.txtCmf7);
            this.grpCmf.Controls.Add(this.txtCmf5);
            this.grpCmf.Controls.Add(this.txtCmf10);
            this.grpCmf.Controls.Add(this.txtCmf9);
            this.grpCmf.Controls.Add(this.txtCmf8);
            this.grpCmf.Controls.Add(this.txtCmf6);
            this.grpCmf.Controls.Add(this.txtCmf4);
            this.grpCmf.Controls.Add(this.txtCmf3);
            this.grpCmf.Controls.Add(this.txtCmf2);
            this.grpCmf.Controls.Add(this.txtCmf1);
            this.grpCmf.Controls.Add(this.lblCMF10);
            this.grpCmf.Controls.Add(this.lblCMF9);
            this.grpCmf.Controls.Add(this.lblCMF8);
            this.grpCmf.Controls.Add(this.lblCMF7);
            this.grpCmf.Controls.Add(this.lblCMF6);
            this.grpCmf.Controls.Add(this.lblCMF5);
            this.grpCmf.Controls.Add(this.lblCMF4);
            this.grpCmf.Controls.Add(this.lblCMF3);
            this.grpCmf.Controls.Add(this.lblCMF2);
            this.grpCmf.Controls.Add(this.lblCMF1);
            this.grpCmf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCmf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCmf.Location = new System.Drawing.Point(3, 0);
            this.grpCmf.Name = "grpCmf";
            this.grpCmf.Size = new System.Drawing.Size(722, 413);
            this.grpCmf.TabIndex = 0;
            this.grpCmf.TabStop = false;
            // 
            // txtCmf17
            // 
            this.txtCmf17.Location = new System.Drawing.Point(519, 160);
            this.txtCmf17.MaxLength = 30;
            this.txtCmf17.Name = "txtCmf17";
            this.txtCmf17.ReadOnly = true;
            this.txtCmf17.Size = new System.Drawing.Size(180, 20);
            this.txtCmf17.TabIndex = 33;
            this.txtCmf17.TabStop = false;
            // 
            // txtCmf15
            // 
            this.txtCmf15.Location = new System.Drawing.Point(519, 112);
            this.txtCmf15.MaxLength = 30;
            this.txtCmf15.Name = "txtCmf15";
            this.txtCmf15.ReadOnly = true;
            this.txtCmf15.Size = new System.Drawing.Size(180, 20);
            this.txtCmf15.TabIndex = 29;
            this.txtCmf15.TabStop = false;
            // 
            // txtCmf20
            // 
            this.txtCmf20.Location = new System.Drawing.Point(519, 232);
            this.txtCmf20.MaxLength = 30;
            this.txtCmf20.Name = "txtCmf20";
            this.txtCmf20.ReadOnly = true;
            this.txtCmf20.Size = new System.Drawing.Size(180, 20);
            this.txtCmf20.TabIndex = 39;
            this.txtCmf20.TabStop = false;
            // 
            // txtCmf19
            // 
            this.txtCmf19.Location = new System.Drawing.Point(519, 208);
            this.txtCmf19.MaxLength = 30;
            this.txtCmf19.Name = "txtCmf19";
            this.txtCmf19.ReadOnly = true;
            this.txtCmf19.Size = new System.Drawing.Size(180, 20);
            this.txtCmf19.TabIndex = 37;
            this.txtCmf19.TabStop = false;
            // 
            // txtCmf18
            // 
            this.txtCmf18.Location = new System.Drawing.Point(519, 184);
            this.txtCmf18.MaxLength = 30;
            this.txtCmf18.Name = "txtCmf18";
            this.txtCmf18.ReadOnly = true;
            this.txtCmf18.Size = new System.Drawing.Size(180, 20);
            this.txtCmf18.TabIndex = 35;
            this.txtCmf18.TabStop = false;
            // 
            // txtCmf16
            // 
            this.txtCmf16.Location = new System.Drawing.Point(519, 136);
            this.txtCmf16.MaxLength = 30;
            this.txtCmf16.Name = "txtCmf16";
            this.txtCmf16.ReadOnly = true;
            this.txtCmf16.Size = new System.Drawing.Size(180, 20);
            this.txtCmf16.TabIndex = 31;
            this.txtCmf16.TabStop = false;
            // 
            // txtCmf14
            // 
            this.txtCmf14.Location = new System.Drawing.Point(519, 88);
            this.txtCmf14.MaxLength = 30;
            this.txtCmf14.Name = "txtCmf14";
            this.txtCmf14.ReadOnly = true;
            this.txtCmf14.Size = new System.Drawing.Size(180, 20);
            this.txtCmf14.TabIndex = 27;
            this.txtCmf14.TabStop = false;
            // 
            // txtCmf13
            // 
            this.txtCmf13.Location = new System.Drawing.Point(519, 64);
            this.txtCmf13.MaxLength = 30;
            this.txtCmf13.Name = "txtCmf13";
            this.txtCmf13.ReadOnly = true;
            this.txtCmf13.Size = new System.Drawing.Size(180, 20);
            this.txtCmf13.TabIndex = 25;
            this.txtCmf13.TabStop = false;
            // 
            // txtCmf12
            // 
            this.txtCmf12.Location = new System.Drawing.Point(519, 40);
            this.txtCmf12.MaxLength = 30;
            this.txtCmf12.Name = "txtCmf12";
            this.txtCmf12.ReadOnly = true;
            this.txtCmf12.Size = new System.Drawing.Size(180, 20);
            this.txtCmf12.TabIndex = 23;
            this.txtCmf12.TabStop = false;
            // 
            // txtCmf11
            // 
            this.txtCmf11.Location = new System.Drawing.Point(519, 16);
            this.txtCmf11.MaxLength = 30;
            this.txtCmf11.Name = "txtCmf11";
            this.txtCmf11.ReadOnly = true;
            this.txtCmf11.Size = new System.Drawing.Size(180, 20);
            this.txtCmf11.TabIndex = 21;
            this.txtCmf11.TabStop = false;
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF20.Location = new System.Drawing.Point(372, 235);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(140, 14);
            this.lblCMF20.TabIndex = 38;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF19.Location = new System.Drawing.Point(372, 211);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(140, 14);
            this.lblCMF19.TabIndex = 36;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF18.Location = new System.Drawing.Point(372, 187);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(140, 14);
            this.lblCMF18.TabIndex = 34;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF17.Location = new System.Drawing.Point(372, 163);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(140, 14);
            this.lblCMF17.TabIndex = 32;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF16.Location = new System.Drawing.Point(372, 139);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(140, 14);
            this.lblCMF16.TabIndex = 30;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF15.Location = new System.Drawing.Point(372, 115);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(140, 14);
            this.lblCMF15.TabIndex = 28;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF14.Location = new System.Drawing.Point(372, 91);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(140, 14);
            this.lblCMF14.TabIndex = 26;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF13.Location = new System.Drawing.Point(372, 67);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(140, 14);
            this.lblCMF13.TabIndex = 24;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF12.Location = new System.Drawing.Point(372, 43);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(140, 14);
            this.lblCMF12.TabIndex = 22;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF11.Location = new System.Drawing.Point(372, 20);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(140, 14);
            this.lblCMF11.TabIndex = 20;
            // 
            // txtCmf7
            // 
            this.txtCmf7.Location = new System.Drawing.Point(169, 160);
            this.txtCmf7.MaxLength = 30;
            this.txtCmf7.Name = "txtCmf7";
            this.txtCmf7.ReadOnly = true;
            this.txtCmf7.Size = new System.Drawing.Size(180, 20);
            this.txtCmf7.TabIndex = 13;
            this.txtCmf7.TabStop = false;
            // 
            // txtCmf5
            // 
            this.txtCmf5.Location = new System.Drawing.Point(169, 112);
            this.txtCmf5.MaxLength = 30;
            this.txtCmf5.Name = "txtCmf5";
            this.txtCmf5.ReadOnly = true;
            this.txtCmf5.Size = new System.Drawing.Size(180, 20);
            this.txtCmf5.TabIndex = 9;
            this.txtCmf5.TabStop = false;
            // 
            // txtCmf10
            // 
            this.txtCmf10.Location = new System.Drawing.Point(169, 232);
            this.txtCmf10.MaxLength = 30;
            this.txtCmf10.Name = "txtCmf10";
            this.txtCmf10.ReadOnly = true;
            this.txtCmf10.Size = new System.Drawing.Size(180, 20);
            this.txtCmf10.TabIndex = 19;
            this.txtCmf10.TabStop = false;
            // 
            // txtCmf9
            // 
            this.txtCmf9.Location = new System.Drawing.Point(169, 208);
            this.txtCmf9.MaxLength = 30;
            this.txtCmf9.Name = "txtCmf9";
            this.txtCmf9.ReadOnly = true;
            this.txtCmf9.Size = new System.Drawing.Size(180, 20);
            this.txtCmf9.TabIndex = 17;
            this.txtCmf9.TabStop = false;
            // 
            // txtCmf8
            // 
            this.txtCmf8.Location = new System.Drawing.Point(169, 184);
            this.txtCmf8.MaxLength = 30;
            this.txtCmf8.Name = "txtCmf8";
            this.txtCmf8.ReadOnly = true;
            this.txtCmf8.Size = new System.Drawing.Size(180, 20);
            this.txtCmf8.TabIndex = 15;
            this.txtCmf8.TabStop = false;
            // 
            // txtCmf6
            // 
            this.txtCmf6.Location = new System.Drawing.Point(169, 136);
            this.txtCmf6.MaxLength = 30;
            this.txtCmf6.Name = "txtCmf6";
            this.txtCmf6.ReadOnly = true;
            this.txtCmf6.Size = new System.Drawing.Size(180, 20);
            this.txtCmf6.TabIndex = 11;
            this.txtCmf6.TabStop = false;
            // 
            // txtCmf4
            // 
            this.txtCmf4.Location = new System.Drawing.Point(169, 88);
            this.txtCmf4.MaxLength = 30;
            this.txtCmf4.Name = "txtCmf4";
            this.txtCmf4.ReadOnly = true;
            this.txtCmf4.Size = new System.Drawing.Size(180, 20);
            this.txtCmf4.TabIndex = 7;
            this.txtCmf4.TabStop = false;
            // 
            // txtCmf3
            // 
            this.txtCmf3.Location = new System.Drawing.Point(169, 64);
            this.txtCmf3.MaxLength = 30;
            this.txtCmf3.Name = "txtCmf3";
            this.txtCmf3.ReadOnly = true;
            this.txtCmf3.Size = new System.Drawing.Size(180, 20);
            this.txtCmf3.TabIndex = 5;
            this.txtCmf3.TabStop = false;
            // 
            // txtCmf2
            // 
            this.txtCmf2.Location = new System.Drawing.Point(169, 40);
            this.txtCmf2.MaxLength = 30;
            this.txtCmf2.Name = "txtCmf2";
            this.txtCmf2.ReadOnly = true;
            this.txtCmf2.Size = new System.Drawing.Size(180, 20);
            this.txtCmf2.TabIndex = 3;
            this.txtCmf2.TabStop = false;
            // 
            // txtCmf1
            // 
            this.txtCmf1.Location = new System.Drawing.Point(169, 16);
            this.txtCmf1.MaxLength = 30;
            this.txtCmf1.Name = "txtCmf1";
            this.txtCmf1.ReadOnly = true;
            this.txtCmf1.Size = new System.Drawing.Size(180, 20);
            this.txtCmf1.TabIndex = 1;
            this.txtCmf1.TabStop = false;
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF10.Location = new System.Drawing.Point(23, 235);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCMF10.TabIndex = 18;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF9.Location = new System.Drawing.Point(23, 211);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCMF9.TabIndex = 16;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF8.Location = new System.Drawing.Point(23, 187);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCMF8.TabIndex = 14;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF7.Location = new System.Drawing.Point(23, 163);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCMF7.TabIndex = 12;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF6.Location = new System.Drawing.Point(23, 139);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCMF6.TabIndex = 10;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF5.Location = new System.Drawing.Point(23, 115);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCMF5.TabIndex = 8;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF4.Location = new System.Drawing.Point(23, 91);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCMF4.TabIndex = 6;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF3.Location = new System.Drawing.Point(23, 67);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCMF3.TabIndex = 4;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF2.Location = new System.Drawing.Point(23, 43);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCMF2.TabIndex = 2;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF1.Location = new System.Drawing.Point(23, 19);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCMF1.TabIndex = 0;
            // 
            // pnlLot
            // 
            this.pnlLot.Controls.Add(this.grpLot);
            this.pnlLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLot.Location = new System.Drawing.Point(0, 0);
            this.pnlLot.Name = "pnlLot";
            this.pnlLot.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlLot.Size = new System.Drawing.Size(742, 70);
            this.pnlLot.TabIndex = 0;
            // 
            // grpLot
            // 
            this.grpLot.Controls.Add(this.txtFactory);
            this.grpLot.Controls.Add(this.lblFactory);
            this.grpLot.Controls.Add(this.txtLotID);
            this.grpLot.Controls.Add(this.txtSublotID);
            this.grpLot.Controls.Add(this.lblLotID);
            this.grpLot.Controls.Add(this.lblSublotID);
            this.grpLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLot.Location = new System.Drawing.Point(3, 0);
            this.grpLot.Name = "grpLot";
            this.grpLot.Size = new System.Drawing.Size(736, 70);
            this.grpLot.TabIndex = 0;
            this.grpLot.TabStop = false;
            // 
            // txtFactory
            // 
            this.txtFactory.Location = new System.Drawing.Point(523, 40);
            this.txtFactory.MaxLength = 10;
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.ReadOnly = true;
            this.txtFactory.Size = new System.Drawing.Size(200, 20);
            this.txtFactory.TabIndex = 5;
            // 
            // lblFactory
            // 
            this.lblFactory.AutoSize = true;
            this.lblFactory.Location = new System.Drawing.Point(418, 43);
            this.lblFactory.Name = "lblFactory";
            this.lblFactory.Size = new System.Drawing.Size(42, 13);
            this.lblFactory.TabIndex = 4;
            this.lblFactory.Text = "Factory";
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(120, 40);
            this.txtLotID.MaxLength = 50;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.ReadOnly = true;
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 3;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Location = new System.Drawing.Point(15, 43);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 2;
            this.lblLotID.Text = "Lot ID";
            // 
            // lblSublotID
            // 
            this.lblSublotID.AutoSize = true;
            this.lblSublotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSublotID.Location = new System.Drawing.Point(15, 19);
            this.lblSublotID.Name = "lblSublotID";
            this.lblSublotID.Size = new System.Drawing.Size(68, 13);
            this.lblSublotID.TabIndex = 0;
            this.lblSublotID.Text = "Sub Lot ID";
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(557, 7);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(88, 26);
            this.btnHistory.TabIndex = 1;
            this.btnHistory.Text = "History";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // frmWIPViewSublotStatus
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewSublotStatus";
            this.Text = "View Sublot Status";
            this.Activated += new System.EventHandler(this.frmWIPViewSubLotStatus_Activated);
            this.Load += new System.EventHandler(this.frmWIPViewSubLotStatus_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlLotStatus.ResumeLayout(false);
            this.tabLotStatus.ResumeLayout(false);
            this.tbpGeneral1.ResumeLayout(false);
            this.grpGen1Mid.ResumeLayout(false);
            this.grpGen1Mid.PerformLayout();
            this.tbpGeneral2.ResumeLayout(false);
            this.grpRes.ResumeLayout(false);
            this.grpRes.PerformLayout();
            this.grpGen2Right.ResumeLayout(false);
            this.grpGen2Right.PerformLayout();
            this.tbpGeneral3.ResumeLayout(false);
            this.grpExtra.ResumeLayout(false);
            this.grpExtra.PerformLayout();
            this.grpGen3Mid.ResumeLayout(false);
            this.grpGen3Mid.PerformLayout();
            this.tbpAttribute.ResumeLayout(false);
            this.tbpCrtCmfField.ResumeLayout(false);
            this.grpCmf.ResumeLayout(false);
            this.grpCmf.PerformLayout();
            this.pnlLot.ResumeLayout(false);
            this.grpLot.ResumeLayout(false);
            this.grpLot.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        // InitCmfControl()
        //       - Initial Cmf Control
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void InitCmfControl()
        {
            ArrayList controls;
            int i;
            
            controls = MPCF.GetIndexedControl("lblCMF", grpCmf);
            for (i = 0; i <= controls.Count - 1; i++)
            {
                ((Label) controls[i]).Visible = false;
                ((Label) controls[i]).Text = "";
            }
            
            controls = MPCF.GetIndexedControl("txtCMF", grpCmf);
            for (i = 0; i <= controls.Count - 1; i++)
            {
                ((TextBox) controls[i]).Visible = false;
                ((TextBox) controls[i]).Text = "";
            }
        }
        
        // SetCmfItem()
        //       - Set Cmf Item
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void SetCmfItem()
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ArrayList lblList;
            ArrayList txtList;
            Label lblTemp;
            TextBox txtTemp;
            int i;

            InitCmfControl();

            if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_SUBLOT, ref out_node, "", true) == false)
            {
                return;
            }

            lblList = MPCF.GetIndexedControl("lblCmf", grpCmf);
            txtList = MPCF.GetIndexedControl("txtCmf", grpCmf);

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                lblTemp = (Label) lblList[i];
                txtTemp = (TextBox) txtList[i];

                lblTemp.Text = out_node.GetList(0)[i].GetString("PROMPT");
                if (lblTemp.Text != "")
                {
                    lblTemp.Visible = true;
                    txtTemp.Visible = true;
                }
            }

        }
        
        // View_Sublot()
        //       - View Sublot Information
        // Return Value
        //       - Boolean : True / False
        // Arguments
        //        -
        //
        private bool View_Sublot(char c_step, string sSubLot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_SUBLOT_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("SUBLOT_ID", MPCF.Trim(sSubLot_id));

            if (MPCR.CallService("WIP", "WIP_View_Sublot", in_node, ref out_node) == false)
            {
                return false;
            }

            txtLotID.Text = out_node.GetString("LOT_ID");
            txtFactory.Text = out_node.GetString("FACTORY");
            cdvMaterial.Text = out_node.GetString("MAT_ID");
            cdvMaterial.Version = out_node.GetInt("MAT_VER");
            cdvMaterial.DescText = out_node.GetString("MAT_DESC");
            cdvFlow.Text = out_node.GetString("FLOW");
            cdvFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
            cdvFlow.DescText = out_node.GetString("FLOW_DESC");
            txtOper.Text = out_node.GetString("OPER");
            txtOperDesc.Text = out_node.GetString("OPER_DESC");

            txtQty2.Text = MPCF.Format("########,##0.###", out_node.GetDouble("QTY_2"));
            txtQty3.Text = MPCF.Format("########,##0.###", out_node.GetDouble("QTY_3"));

            txtOwnerCode.Text = out_node.GetString("OWNER_CODE");
            txtCrtCode.Text = out_node.GetString("CREATE_CODE");
            txtSublotStatus.Text = out_node.GetString("SUBLOT_STATUS");
            chkHold.Checked = out_node.GetChar("HOLD_FLAG") == 'Y' ? true : false;
            txtHoldCode.Text = out_node.GetString("HOLD_CODE");

            ListView lvItem = new ListView();       // SubLot Type Items

            MPCF.InitListView(lvItem);
            lvItem.Columns.Add("SubLotType", 50, HorizontalAlignment.Left);
            lvItem.Columns.Add("Desc", 100, HorizontalAlignment.Left);

            BASLIST.ViewGCMDataList(lvItem, '1', MPGC.MP_WIP_SUBLOT_TYPE);
            txtSublotType.Text = "";

            for (int index = 0; index < lvItem.Items.Count; index++)
            {
                if (out_node.GetChar("SUBLOT_TYPE") == MPCF.ToChar(lvItem.Items[index].SubItems[0].Text))
                {
                    txtSublotType.Text = MPCF.Trim(lvItem.Items[index].SubItems[1].Text);
                }
            }

            txtOperQty2.Text = MPCF.Format("########,##0.###", out_node.GetDouble("OPER_IN_QTY_2"));
            txtOperQty3.Text = MPCF.Format("########,##0.###", out_node.GetDouble("OPER_IN_QTY_3"));

            txtCrtQty2.Text = MPCF.Format("########,##0.###", out_node.GetDouble("CREATE_QTY_2"));
            txtCrtQty3.Text = MPCF.Format("########,##0.###", out_node.GetDouble("CREATE_QTY_3"));

            chkInv.Checked = out_node.GetChar("INV_FLAG") == 'Y' ? true : false;
            chkTransit.Checked = out_node.GetChar("TRANSIT_FLAG") == 'Y' ? true : false;
            chkTracking.Checked = out_node.GetChar("UNIT_EXIST_FLAG") == 'Y' ? true : false;

            chkRework.Checked = out_node.GetChar("RWK_FLAG") == 'Y' ? true : false;
            txtReworkCode.Text = out_node.GetString("RWK_CODE");
            txtReworkCnt.Text = out_node.GetInt("RWK_COUNT").ToString();
            txtReworkDepth.Text = out_node.GetInt("RWK_DEPTH").ToString();
            txtReworkStopOper.Text = out_node.GetString("RWK_STOP_OPER");
            txtReworkReturnFlow.Text = out_node.GetString("RWK_RET_FLOW");
            txtReworkReturnOper.Text = out_node.GetString("RWK_RET_OPER");
            txtReworkEndFlow.Text = out_node.GetString("RWK_END_FLOW");
            txtReworkEndOper.Text = out_node.GetString("RWK_END_OPER");
            switch (out_node.GetChar("RWK_RET_CLEAR_FLAG"))
            {
                case 'Y':
                    txtReturnOption.Text = "Clear Rework";
                    break;
                case 'A':
                    txtReturnOption.Text = "Clear Rework and Move to Next Operation";
                    break;
                case 'B':
                    txtReturnOption.Text = "Keep Rework and Move to Next Operation";
                    break;
                default:
                    if (chkRework.Checked == true)
                    {
                        txtReturnOption.Text = "Keep Rework";
                    }
                    else
                    {
                        txtReturnOption.Text = "";
                    }
                    break;
            }
            txtReworkTime.Text = MPCF.MakeDateFormat(out_node.GetString("RWK_TIME"));
            chkLocalReworkFlag.Checked = out_node.GetChar("LOCAL_REWORK_FLAG") == 'Y' ? true : false;

            chkNstd.Checked = out_node.GetChar("NSTD_FLAG") == 'Y' ? true : false;
            txtNstdReturnFlow.Text = out_node.GetString("NSTD_RET_FLOW");
            txtNstdReturnOper.Text = out_node.GetString("NSTD_RET_OPER");
            txtNstdTime.Text = MPCF.MakeDateFormat(out_node.GetString("NSTD_TIME"));

            chkStart.Checked = out_node.GetChar("START_FLAG") == 'Y' ? true : false;
            txtStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("START_TIME"));
            txtStartResId.Text = out_node.GetString("START_RES_ID");
            chkEnd.Checked = out_node.GetChar("END_FLAG") == 'Y' ? true : false;
            txtEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("END_TIME"));
            txtEndResID.Text = out_node.GetString("END_RES_ID");

            chkSample.Checked = out_node.GetChar("SAMPLE_FLAG") == 'Y' ? true : false;
            chkSampleWait.Checked = out_node.GetChar("SAMPLE_WAIT_FLAG") == 'Y' ? true : false;
            switch (out_node.GetChar("SAMPLE_RESULT"))
            {
                case 'Y':

                    txtSampleRes.Text = "Good";
                    break;
                case 'N':

                    txtSampleRes.Text = "No Good";
                    break;
                default:

                    txtSampleRes.Text = "";
                    break;
            }

            txtResvResID.Text = out_node.GetString("RESERVE_RES_ID");
            txtCmf1.Text = out_node.GetString("SUBLOT_CMF_1");
            txtCmf2.Text = out_node.GetString("SUBLOT_CMF_2");
            txtCmf3.Text = out_node.GetString("SUBLOT_CMF_3");
            txtCmf4.Text = out_node.GetString("SUBLOT_CMF_4");
            txtCmf5.Text = out_node.GetString("SUBLOT_CMF_5");
            txtCmf6.Text = out_node.GetString("SUBLOT_CMF_6");
            txtCmf7.Text = out_node.GetString("SUBLOT_CMF_7");
            txtCmf8.Text = out_node.GetString("SUBLOT_CMF_8");
            txtCmf9.Text = out_node.GetString("SUBLOT_CMF_9");
            txtCmf10.Text = out_node.GetString("SUBLOT_CMF_10");
            txtCmf11.Text = out_node.GetString("SUBLOT_CMF_11");
            txtCmf12.Text = out_node.GetString("SUBLOT_CMF_12");
            txtCmf13.Text = out_node.GetString("SUBLOT_CMF_13");
            txtCmf14.Text = out_node.GetString("SUBLOT_CMF_14");
            txtCmf15.Text = out_node.GetString("SUBLOT_CMF_15");
            txtCmf16.Text = out_node.GetString("SUBLOT_CMF_16");
            txtCmf17.Text = out_node.GetString("SUBLOT_CMF_17");
            txtCmf18.Text = out_node.GetString("SUBLOT_CMF_18");
            txtCmf19.Text = out_node.GetString("SUBLOT_CMF_19");
            txtCmf20.Text = out_node.GetString("SUBLOT_CMF_20");

            chkLotDelete.Checked = out_node.GetChar("SUBLOT_DEL_FLAG") == 'Y' ? true : false;
            txtDelReason.Text = out_node.GetString("SUBLOT_DEL_CODE");
            txtLotDeleteTime.Text = MPCF.MakeDateFormat(out_node.GetString("SUBLOT_DEL_TIME"));

            txtLastTrnCode.Text = out_node.GetString("LAST_TRAN_CODE");
            txtLastTrnTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
            txtComment.Text = out_node.GetString("LAST_COMMENT");
            txtLastActHistSeq.Text = MPCF.Format("########,##0", out_node.GetInt("LAST_ACTIVE_HIST_SEQ"));
            txtLastHistSeq.Text = MPCF.Format("########,##0", out_node.GetInt("LAST_HIST_SEQ"));

            chkRepair.Checked = out_node.GetChar("REP_FLAG") == 'Y' ? true : false;
            txtRepairRetOper.Text = out_node.GetString("REP_RET_OPER");

            txtCarrierID.Text = out_node.GetString("CRR_ID");
            txtSlotNo.Text = out_node.GetInt("SLOT_NO").ToString();
            txtInvUnit.Text = out_node.GetString("INV_UNIT");
            txtHoldPrvGrpID.Text = out_node.GetString("HOLD_PRV_GRP_ID");
            txtStartQty2.Text = MPCF.Format("########,##0.###", out_node.GetDouble("START_QTY_2"));
            txtStartQty3.Text = MPCF.Format("########,##0.###", out_node.GetDouble("START_QTY_3"));

            txtGrade.Text = out_node.GetChar("GRADE").ToString();
            txtGradeCode.Text = out_node.GetString("GRADE_CODE");
            txtCellGrade.Text = out_node.GetString("CELL_GRADE");

            //Add by J.S. 2009.02.18 for Add CELL_JUDGE
            txtCellJudge.Text = out_node.GetString("CELL_JUDGE");

            txtLotBase.Text = out_node.GetChar("LOT_BASE").ToString();

            txtNstdReturnFlowSeq.Text = MPCF.Format("########,##0", out_node.GetInt("NSTD_RET_FLOW_SEQ_NUM"));
            txtReworkEndFlowSeq.Text = MPCF.Format("########,##0", out_node.GetInt("RWK_END_FLOW_SEQ_NUM"));
            txtReworkReturnFlowSeq.Text = MPCF.Format("########,##0", out_node.GetInt("RWK_RET_FLOW_SEQ_NUM"));

            txtLocation1.Text = out_node.GetString("SUBLOT_LOCATION_1");
            txtLocation2.Text = out_node.GetString("SUBLOT_LOCATION_2");
            txtLocation3.Text = out_node.GetString("SUBLOT_LOCATION_3");

            txtStrRetFlow.Text = out_node.GetString("STR_RET_FLOW");
            txtStrRetFlowSeq.Text = out_node.GetString("STR_RET_FLOW_SEQ_NUM");
            txtStrRetOper.Text = out_node.GetString("STR_RET_OPER");

            udcAttributeStatus.AttributeKey = txtSublotID.Text;
            udcAttributeStatus.View();

            return true;


        }
        
        public void ActiveFormNow()
        {
            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtSublotID.Text = MPGV.gsCurrentLot_ID;
                btnProcess_Click(btnProcess, null);
            }
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtSublotID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPViewSubLotStatus_Load(object sender, System.EventArgs e)
        {
            cdvMaterial.BackColor = SystemColors.Control;
            cdvFlow.BackColor = SystemColors.Control;
        }
        
        private void frmWIPViewSubLotStatus_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                SetCmfItem();
                txtSublotID.Focus();
                
                ActiveFormNow();
                
                b_load_flag = true;
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            if (txtSublotID.Text != "")
            {
                if (View_Sublot('2', txtSublotID.Text) == false)
                {
                    return;
                }
                this.Text = MPCF.FindLanguage("Sub Lot Status", 0) + " (" + txtSublotID.Text + ")";
                this.lblFormTitle.Text = this.Text;
            }
            
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (txtSublotID.Text != "")
            {
                if (View_Sublot('2', txtSublotID.Text) == false)
                {
                    return;
                }

                MPGV.gsCurrentLot_ID = txtSublotID.Text;

                try
                {
                    Form f = MPCF.GetChildForm(MPGV.gfrmMDI, "frmWIPViewSubLotHistory");
                    if (f != null)
                    {
                        f.BringToFront();
                        f.Show();
                    }
                    else
                    {
                        f = new frmWIPViewSubLotHistory();
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
        }
        
    }
    
}
