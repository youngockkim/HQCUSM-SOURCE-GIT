

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranCombineLotExt.vb
//   Description : Combine Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - View_Operation() : View Operation Information
//       - Combine_Lot() : Combine Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-05-11 : Created by CM Koo
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
using Miracom.UI;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public class frmWIPTranCombineLotExt : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranCombineLotExt()
        {
            
            
            InitializeComponent();
            
            
            this.spdTargetLotInfo.Tag = "Change Cell";
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
        private System.Windows.Forms.TabPage tbpSublotInfo;
        private System.Windows.Forms.GroupBox grpSublotInfo;
        private System.Windows.Forms.Panel pnlSplitSublot;
        private System.Windows.Forms.Button btnCombine;
        private System.Windows.Forms.Button btnUnCombine;
        private System.Windows.Forms.Panel pnlSubChild;
        private System.Windows.Forms.GroupBox grpChildSubLot;
        private System.Windows.Forms.Panel pnlSubChildMid;
        private System.Windows.Forms.Panel pnlSubChildTop;
        private System.Windows.Forms.TextBox txtMoveQty3;
        private System.Windows.Forms.TextBox txtMoveQty2;
        private System.Windows.Forms.TextBox txtMoveQty1;
        private System.Windows.Forms.Label lblMoveQty;
        private System.Windows.Forms.Panel pnlSubMother;
        private System.Windows.Forms.GroupBox grpMotherSubLot;
        private System.Windows.Forms.Panel pnlSubMotherMid;
        private System.Windows.Forms.Panel pnlSubMotherTop;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
        private System.Windows.Forms.Label lblMotherQty;
        private System.Windows.Forms.ColumnHeader colChildSlot;
        private System.Windows.Forms.ColumnHeader colChildSubLot;
        private System.Windows.Forms.ColumnHeader colSlot;
        private System.Windows.Forms.ColumnHeader colSubLot;
        private Miracom.UI.Controls.MCListView.MCListView lisTarget;
        private Miracom.UI.Controls.MCListView.MCListView lisSource;
        private System.Windows.Forms.ColumnHeader colLotID;
        private GroupBox grpTargetLotInfo;
        private Panel pnlTagetLotInfoMain;
        private GroupBox grpTranInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvIntoCrrID;
        private Label lblIntoCrrID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrID;
        private Label lblCrrID;
        protected TextBox txtTargetLotDesc;
        protected TextBox txtTargetLotID;
        protected Label lblTargetLotID;
        private FarPoint.Win.Spread.FpSpread spdTargetLotInfo;
        private FarPoint.Win.Spread.SheetView spdTargetLotInfo_LotInfo;
        private CheckBox chkNoAutoTermLot;
        private ColumnHeader colGrade;
        private ColumnHeader colToSlot;
        private ColumnHeader colFromGrade;
        private ColumnHeader colFromSlot;
        private GroupBox grpMoveQty;
        private Label lblQty3;
        private TextBox txtMQty3;
        private TextBox txtMQty2;
        private Label lblQty2;
        private TextBox txtMQty1;
        private Label lblQty1;
        private System.Windows.Forms.ColumnHeader colChildLotID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder2 = new FarPoint.Win.CompoundBorder(bevelBorder3, bevelBorder4);
            FarPoint.Win.BevelBorder bevelBorder5 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder6 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder3 = new FarPoint.Win.CompoundBorder(bevelBorder5, bevelBorder6);
            this.tbpSublotInfo = new System.Windows.Forms.TabPage();
            this.grpSublotInfo = new System.Windows.Forms.GroupBox();
            this.pnlSplitSublot = new System.Windows.Forms.Panel();
            this.btnCombine = new System.Windows.Forms.Button();
            this.btnUnCombine = new System.Windows.Forms.Button();
            this.pnlSubChild = new System.Windows.Forms.Panel();
            this.grpChildSubLot = new System.Windows.Forms.GroupBox();
            this.pnlSubChildMid = new System.Windows.Forms.Panel();
            this.lisTarget = new Miracom.UI.Controls.MCListView.MCListView();
            this.colChildSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChildSubLot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChildLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFromGrade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFromSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSubChildTop = new System.Windows.Forms.Panel();
            this.txtMoveQty3 = new System.Windows.Forms.TextBox();
            this.txtMoveQty2 = new System.Windows.Forms.TextBox();
            this.txtMoveQty1 = new System.Windows.Forms.TextBox();
            this.lblMoveQty = new System.Windows.Forms.Label();
            this.pnlSubMother = new System.Windows.Forms.Panel();
            this.grpMotherSubLot = new System.Windows.Forms.GroupBox();
            this.pnlSubMotherMid = new System.Windows.Forms.Panel();
            this.lisSource = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubLot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGrade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colToSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSubMotherTop = new System.Windows.Forms.Panel();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.lblMotherQty = new System.Windows.Forms.Label();
            this.grpTranInfo = new System.Windows.Forms.GroupBox();
            this.chkNoAutoTermLot = new System.Windows.Forms.CheckBox();
            this.cdvIntoCrrID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblIntoCrrID = new System.Windows.Forms.Label();
            this.cdvCrrID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.txtTargetLotDesc = new System.Windows.Forms.TextBox();
            this.txtTargetLotID = new System.Windows.Forms.TextBox();
            this.lblTargetLotID = new System.Windows.Forms.Label();
            this.grpTargetLotInfo = new System.Windows.Forms.GroupBox();
            this.pnlTagetLotInfoMain = new System.Windows.Forms.Panel();
            this.spdTargetLotInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdTargetLotInfo_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.grpMoveQty = new System.Windows.Forms.GroupBox();
            this.lblQty3 = new System.Windows.Forms.Label();
            this.txtMQty3 = new System.Windows.Forms.TextBox();
            this.txtMQty2 = new System.Windows.Forms.TextBox();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.txtMQty1 = new System.Windows.Forms.TextBox();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.pnlTranInfo.SuspendLayout();
            this.pnlGeneralTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).BeginInit();
            this.grpLotInfo.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTran.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.grpCMF.SuspendLayout();
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
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tbpSublotInfo.SuspendLayout();
            this.grpSublotInfo.SuspendLayout();
            this.pnlSplitSublot.SuspendLayout();
            this.pnlSubChild.SuspendLayout();
            this.grpChildSubLot.SuspendLayout();
            this.pnlSubChildMid.SuspendLayout();
            this.pnlSubChildTop.SuspendLayout();
            this.pnlSubMother.SuspendLayout();
            this.grpMotherSubLot.SuspendLayout();
            this.pnlSubMotherMid.SuspendLayout();
            this.pnlSubMotherTop.SuspendLayout();
            this.grpTranInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvIntoCrrID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).BeginInit();
            this.grpTargetLotInfo.SuspendLayout();
            this.pnlTagetLotInfoMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdTargetLotInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdTargetLotInfo_LotInfo)).BeginInit();
            this.grpMoveQty.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpTargetLotInfo);
            this.pnlTranInfo.Controls.Add(this.grpMoveQty);
            this.pnlTranInfo.Controls.Add(this.grpTranInfo);
            this.pnlTranInfo.Size = new System.Drawing.Size(722, 234);
            this.pnlTranInfo.TabIndex = 1;
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // pnlTran
            // 
            this.pnlTran.Size = new System.Drawing.Size(722, 375);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 378);
            this.pnlComment.Size = new System.Drawing.Size(722, 44);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // grpComment
            // 
            this.grpComment.Size = new System.Drawing.Size(722, 44);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(113, 16);
            this.txtComment.Size = new System.Drawing.Size(597, 20);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(15, 19);
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.MaxLength = 30;
            this.txtTranDateTime.TabStop = true;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.TabStop = false;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 1);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.TabStop = false;
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpSublotInfo);
            this.tabTran.Controls.SetChildIndex(this.tbpSublotInfo, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpGeneral, 0);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Combine Extension";
            // 
            // tbpSublotInfo
            // 
            this.tbpSublotInfo.Controls.Add(this.grpSublotInfo);
            this.tbpSublotInfo.Location = new System.Drawing.Point(4, 22);
            this.tbpSublotInfo.Name = "tbpSublotInfo";
            this.tbpSublotInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSublotInfo.Size = new System.Drawing.Size(728, 422);
            this.tbpSublotInfo.TabIndex = 2;
            this.tbpSublotInfo.Text = "Sub Lot Information";
            // 
            // grpSublotInfo
            // 
            this.grpSublotInfo.Controls.Add(this.pnlSplitSublot);
            this.grpSublotInfo.Controls.Add(this.pnlSubChild);
            this.grpSublotInfo.Controls.Add(this.pnlSubMother);
            this.grpSublotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSublotInfo.Enabled = false;
            this.grpSublotInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSublotInfo.Location = new System.Drawing.Point(3, 3);
            this.grpSublotInfo.Name = "grpSublotInfo";
            this.grpSublotInfo.Size = new System.Drawing.Size(722, 416);
            this.grpSublotInfo.TabIndex = 2;
            this.grpSublotInfo.TabStop = false;
            this.grpSublotInfo.Resize += new System.EventHandler(this.grpSublotInfo_Resize);
            // 
            // pnlSplitSublot
            // 
            this.pnlSplitSublot.Controls.Add(this.btnCombine);
            this.pnlSplitSublot.Controls.Add(this.btnUnCombine);
            this.pnlSplitSublot.Location = new System.Drawing.Point(338, 93);
            this.pnlSplitSublot.Name = "pnlSplitSublot";
            this.pnlSplitSublot.Size = new System.Drawing.Size(46, 230);
            this.pnlSplitSublot.TabIndex = 1;
            // 
            // btnCombine
            // 
            this.btnCombine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCombine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCombine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCombine.Location = new System.Drawing.Point(11, 89);
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(24, 24);
            this.btnCombine.TabIndex = 0;
            this.btnCombine.Text = ">";
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // btnUnCombine
            // 
            this.btnUnCombine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUnCombine.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUnCombine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnCombine.Location = new System.Drawing.Point(11, 118);
            this.btnUnCombine.Name = "btnUnCombine";
            this.btnUnCombine.Size = new System.Drawing.Size(24, 24);
            this.btnUnCombine.TabIndex = 1;
            this.btnUnCombine.Text = "<";
            this.btnUnCombine.Click += new System.EventHandler(this.btnUnCombine_Click);
            // 
            // pnlSubChild
            // 
            this.pnlSubChild.Controls.Add(this.grpChildSubLot);
            this.pnlSubChild.Location = new System.Drawing.Point(390, 20);
            this.pnlSubChild.Name = "pnlSubChild";
            this.pnlSubChild.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubChild.Size = new System.Drawing.Size(328, 388);
            this.pnlSubChild.TabIndex = 2;
            // 
            // grpChildSubLot
            // 
            this.grpChildSubLot.Controls.Add(this.pnlSubChildMid);
            this.grpChildSubLot.Controls.Add(this.pnlSubChildTop);
            this.grpChildSubLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChildSubLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChildSubLot.Location = new System.Drawing.Point(3, 3);
            this.grpChildSubLot.Name = "grpChildSubLot";
            this.grpChildSubLot.Size = new System.Drawing.Size(322, 382);
            this.grpChildSubLot.TabIndex = 0;
            this.grpChildSubLot.TabStop = false;
            this.grpChildSubLot.Text = "Target Lot";
            // 
            // pnlSubChildMid
            // 
            this.pnlSubChildMid.Controls.Add(this.lisTarget);
            this.pnlSubChildMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubChildMid.Location = new System.Drawing.Point(3, 46);
            this.pnlSubChildMid.Name = "pnlSubChildMid";
            this.pnlSubChildMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubChildMid.Size = new System.Drawing.Size(316, 333);
            this.pnlSubChildMid.TabIndex = 1;
            // 
            // lisTarget
            // 
            this.lisTarget.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChildSlot,
            this.colChildSubLot,
            this.colChildLotID,
            this.colFromGrade,
            this.colFromSlot});
            this.lisTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisTarget.EnableSort = true;
            this.lisTarget.EnableSortIcon = true;
            this.lisTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisTarget.FullRowSelect = true;
            this.lisTarget.Location = new System.Drawing.Point(3, 3);
            this.lisTarget.Name = "lisTarget";
            this.lisTarget.Size = new System.Drawing.Size(310, 327);
            this.lisTarget.TabIndex = 0;
            this.lisTarget.UseCompatibleStateImageBehavior = false;
            this.lisTarget.View = System.Windows.Forms.View.Details;
            // 
            // colChildSlot
            // 
            this.colChildSlot.Text = "Slot No";
            this.colChildSlot.Width = 47;
            // 
            // colChildSubLot
            // 
            this.colChildSubLot.Text = "Sub Lot ID";
            this.colChildSubLot.Width = 90;
            // 
            // colChildLotID
            // 
            this.colChildLotID.Text = "Lot ID";
            this.colChildLotID.Width = 90;
            // 
            // colFromGrade
            // 
            this.colFromGrade.Text = "G";
            this.colFromGrade.Width = 23;
            // 
            // colFromSlot
            // 
            this.colFromSlot.Text = "From Slot";
            // 
            // pnlSubChildTop
            // 
            this.pnlSubChildTop.Controls.Add(this.txtMoveQty3);
            this.pnlSubChildTop.Controls.Add(this.txtMoveQty2);
            this.pnlSubChildTop.Controls.Add(this.txtMoveQty1);
            this.pnlSubChildTop.Controls.Add(this.lblMoveQty);
            this.pnlSubChildTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubChildTop.Location = new System.Drawing.Point(3, 16);
            this.pnlSubChildTop.Name = "pnlSubChildTop";
            this.pnlSubChildTop.Size = new System.Drawing.Size(316, 30);
            this.pnlSubChildTop.TabIndex = 0;
            // 
            // txtMoveQty3
            // 
            this.txtMoveQty3.Location = new System.Drawing.Point(242, 2);
            this.txtMoveQty3.MaxLength = 11;
            this.txtMoveQty3.Name = "txtMoveQty3";
            this.txtMoveQty3.ReadOnly = true;
            this.txtMoveQty3.Size = new System.Drawing.Size(68, 20);
            this.txtMoveQty3.TabIndex = 3;
            this.txtMoveQty3.TabStop = false;
            // 
            // txtMoveQty2
            // 
            this.txtMoveQty2.Location = new System.Drawing.Point(172, 2);
            this.txtMoveQty2.MaxLength = 11;
            this.txtMoveQty2.Name = "txtMoveQty2";
            this.txtMoveQty2.ReadOnly = true;
            this.txtMoveQty2.Size = new System.Drawing.Size(68, 20);
            this.txtMoveQty2.TabIndex = 2;
            this.txtMoveQty2.TabStop = false;
            // 
            // txtMoveQty1
            // 
            this.txtMoveQty1.Location = new System.Drawing.Point(102, 2);
            this.txtMoveQty1.MaxLength = 11;
            this.txtMoveQty1.Name = "txtMoveQty1";
            this.txtMoveQty1.ReadOnly = true;
            this.txtMoveQty1.Size = new System.Drawing.Size(68, 20);
            this.txtMoveQty1.TabIndex = 1;
            this.txtMoveQty1.TabStop = false;
            // 
            // lblMoveQty
            // 
            this.lblMoveQty.AutoSize = true;
            this.lblMoveQty.Location = new System.Drawing.Point(6, 4);
            this.lblMoveQty.Name = "lblMoveQty";
            this.lblMoveQty.Size = new System.Drawing.Size(84, 13);
            this.lblMoveQty.TabIndex = 0;
            this.lblMoveQty.Text = "Move Qty 1/2/3";
            // 
            // pnlSubMother
            // 
            this.pnlSubMother.Controls.Add(this.grpMotherSubLot);
            this.pnlSubMother.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSubMother.Location = new System.Drawing.Point(3, 16);
            this.pnlSubMother.Name = "pnlSubMother";
            this.pnlSubMother.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubMother.Size = new System.Drawing.Size(327, 397);
            this.pnlSubMother.TabIndex = 0;
            // 
            // grpMotherSubLot
            // 
            this.grpMotherSubLot.Controls.Add(this.pnlSubMotherMid);
            this.grpMotherSubLot.Controls.Add(this.pnlSubMotherTop);
            this.grpMotherSubLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMotherSubLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMotherSubLot.Location = new System.Drawing.Point(3, 3);
            this.grpMotherSubLot.Name = "grpMotherSubLot";
            this.grpMotherSubLot.Size = new System.Drawing.Size(321, 391);
            this.grpMotherSubLot.TabIndex = 0;
            this.grpMotherSubLot.TabStop = false;
            this.grpMotherSubLot.Text = "Source Lot";
            // 
            // pnlSubMotherMid
            // 
            this.pnlSubMotherMid.Controls.Add(this.lisSource);
            this.pnlSubMotherMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubMotherMid.Location = new System.Drawing.Point(3, 46);
            this.pnlSubMotherMid.Name = "pnlSubMotherMid";
            this.pnlSubMotherMid.Padding = new System.Windows.Forms.Padding(3);
            this.pnlSubMotherMid.Size = new System.Drawing.Size(315, 342);
            this.pnlSubMotherMid.TabIndex = 1;
            // 
            // lisSource
            // 
            this.lisSource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSlot,
            this.colSubLot,
            this.colLotID,
            this.colGrade,
            this.colToSlot});
            this.lisSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSource.EnableSort = true;
            this.lisSource.EnableSortIcon = true;
            this.lisSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSource.FullRowSelect = true;
            this.lisSource.Location = new System.Drawing.Point(3, 3);
            this.lisSource.Name = "lisSource";
            this.lisSource.Size = new System.Drawing.Size(309, 336);
            this.lisSource.TabIndex = 0;
            this.lisSource.UseCompatibleStateImageBehavior = false;
            this.lisSource.View = System.Windows.Forms.View.Details;
            // 
            // colSlot
            // 
            this.colSlot.Text = "Slot No";
            this.colSlot.Width = 47;
            // 
            // colSubLot
            // 
            this.colSubLot.Text = "Sub Lot ID";
            this.colSubLot.Width = 90;
            // 
            // colLotID
            // 
            this.colLotID.Text = "Lot ID";
            this.colLotID.Width = 90;
            // 
            // colGrade
            // 
            this.colGrade.Text = "G";
            this.colGrade.Width = 23;
            // 
            // colToSlot
            // 
            this.colToSlot.Text = "To Slot No";
            // 
            // pnlSubMotherTop
            // 
            this.pnlSubMotherTop.Controls.Add(this.txtQty3);
            this.pnlSubMotherTop.Controls.Add(this.txtQty2);
            this.pnlSubMotherTop.Controls.Add(this.txtQty1);
            this.pnlSubMotherTop.Controls.Add(this.lblMotherQty);
            this.pnlSubMotherTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubMotherTop.Location = new System.Drawing.Point(3, 16);
            this.pnlSubMotherTop.Name = "pnlSubMotherTop";
            this.pnlSubMotherTop.Size = new System.Drawing.Size(315, 30);
            this.pnlSubMotherTop.TabIndex = 0;
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(240, 2);
            this.txtQty3.MaxLength = 11;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.ReadOnly = true;
            this.txtQty3.Size = new System.Drawing.Size(68, 20);
            this.txtQty3.TabIndex = 3;
            this.txtQty3.TabStop = false;
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(170, 2);
            this.txtQty2.MaxLength = 11;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.ReadOnly = true;
            this.txtQty2.Size = new System.Drawing.Size(68, 20);
            this.txtQty2.TabIndex = 2;
            this.txtQty2.TabStop = false;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(100, 2);
            this.txtQty1.MaxLength = 11;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.ReadOnly = true;
            this.txtQty1.Size = new System.Drawing.Size(68, 20);
            this.txtQty1.TabIndex = 1;
            this.txtQty1.TabStop = false;
            // 
            // lblMotherQty
            // 
            this.lblMotherQty.AutoSize = true;
            this.lblMotherQty.Location = new System.Drawing.Point(6, 4);
            this.lblMotherQty.Name = "lblMotherQty";
            this.lblMotherQty.Size = new System.Drawing.Size(54, 13);
            this.lblMotherQty.TabIndex = 0;
            this.lblMotherQty.Text = "Qty 1/2/3";
            // 
            // grpTranInfo
            // 
            this.grpTranInfo.Controls.Add(this.chkNoAutoTermLot);
            this.grpTranInfo.Controls.Add(this.cdvIntoCrrID);
            this.grpTranInfo.Controls.Add(this.lblIntoCrrID);
            this.grpTranInfo.Controls.Add(this.cdvCrrID);
            this.grpTranInfo.Controls.Add(this.lblCrrID);
            this.grpTranInfo.Controls.Add(this.txtTargetLotDesc);
            this.grpTranInfo.Controls.Add(this.txtTargetLotID);
            this.grpTranInfo.Controls.Add(this.lblTargetLotID);
            this.grpTranInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTranInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTranInfo.Location = new System.Drawing.Point(0, 0);
            this.grpTranInfo.Name = "grpTranInfo";
            this.grpTranInfo.Size = new System.Drawing.Size(722, 86);
            this.grpTranInfo.TabIndex = 0;
            this.grpTranInfo.TabStop = false;
            // 
            // chkNoAutoTermLot
            // 
            this.chkNoAutoTermLot.AutoSize = true;
            this.chkNoAutoTermLot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNoAutoTermLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkNoAutoTermLot.Location = new System.Drawing.Point(12, 63);
            this.chkNoAutoTermLot.Name = "chkNoAutoTermLot";
            this.chkNoAutoTermLot.Size = new System.Drawing.Size(201, 18);
            this.chkNoAutoTermLot.TabIndex = 7;
            this.chkNoAutoTermLot.Text = "No Automatic Terminate Source Lot";
            // 
            // cdvIntoCrrID
            // 
            this.cdvIntoCrrID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvIntoCrrID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvIntoCrrID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvIntoCrrID.BtnToolTipText = "";
            this.cdvIntoCrrID.DescText = "";
            this.cdvIntoCrrID.DisplaySubItemIndex = -1;
            this.cdvIntoCrrID.DisplayText = "";
            this.cdvIntoCrrID.Focusing = null;
            this.cdvIntoCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvIntoCrrID.Index = 0;
            this.cdvIntoCrrID.IsViewBtnImage = false;
            this.cdvIntoCrrID.Location = new System.Drawing.Point(510, 40);
            this.cdvIntoCrrID.MaxLength = 20;
            this.cdvIntoCrrID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvIntoCrrID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvIntoCrrID.Name = "cdvIntoCrrID";
            this.cdvIntoCrrID.ReadOnly = false;
            this.cdvIntoCrrID.SearchSubItemIndex = 0;
            this.cdvIntoCrrID.SelectedDescIndex = -1;
            this.cdvIntoCrrID.SelectedSubItemIndex = -1;
            this.cdvIntoCrrID.SelectionStart = 0;
            this.cdvIntoCrrID.Size = new System.Drawing.Size(200, 20);
            this.cdvIntoCrrID.SmallImageList = null;
            this.cdvIntoCrrID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvIntoCrrID.TabIndex = 6;
            this.cdvIntoCrrID.TextBoxToolTipText = "";
            this.cdvIntoCrrID.TextBoxWidth = 200;
            this.cdvIntoCrrID.Visible = false;
            this.cdvIntoCrrID.VisibleButton = true;
            this.cdvIntoCrrID.VisibleColumnHeader = false;
            this.cdvIntoCrrID.VisibleDescription = false;
            // 
            // lblIntoCrrID
            // 
            this.lblIntoCrrID.AutoSize = true;
            this.lblIntoCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblIntoCrrID.Location = new System.Drawing.Point(404, 43);
            this.lblIntoCrrID.Name = "lblIntoCrrID";
            this.lblIntoCrrID.Size = new System.Drawing.Size(85, 13);
            this.lblIntoCrrID.TabIndex = 5;
            this.lblIntoCrrID.Text = "Target Carrier ID";
            this.lblIntoCrrID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblIntoCrrID.Visible = false;
            // 
            // cdvCrrID
            // 
            this.cdvCrrID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrID.BtnToolTipText = "";
            this.cdvCrrID.DescText = "";
            this.cdvCrrID.DisplaySubItemIndex = -1;
            this.cdvCrrID.DisplayText = "";
            this.cdvCrrID.Focusing = null;
            this.cdvCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrID.Index = 0;
            this.cdvCrrID.IsViewBtnImage = false;
            this.cdvCrrID.Location = new System.Drawing.Point(118, 40);
            this.cdvCrrID.MaxLength = 20;
            this.cdvCrrID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.Name = "cdvCrrID";
            this.cdvCrrID.ReadOnly = false;
            this.cdvCrrID.SearchSubItemIndex = 0;
            this.cdvCrrID.SelectedDescIndex = -1;
            this.cdvCrrID.SelectedSubItemIndex = -1;
            this.cdvCrrID.SelectionStart = 0;
            this.cdvCrrID.Size = new System.Drawing.Size(200, 20);
            this.cdvCrrID.SmallImageList = null;
            this.cdvCrrID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrID.TabIndex = 4;
            this.cdvCrrID.TextBoxToolTipText = "";
            this.cdvCrrID.TextBoxWidth = 200;
            this.cdvCrrID.Visible = false;
            this.cdvCrrID.VisibleButton = true;
            this.cdvCrrID.VisibleColumnHeader = false;
            this.cdvCrrID.VisibleDescription = false;
            // 
            // lblCrrID
            // 
            this.lblCrrID.AutoSize = true;
            this.lblCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrID.Location = new System.Drawing.Point(12, 43);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(88, 13);
            this.lblCrrID.TabIndex = 3;
            this.lblCrrID.Text = "Source Carrier ID";
            this.lblCrrID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblCrrID.Visible = false;
            // 
            // txtTargetLotDesc
            // 
            this.txtTargetLotDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetLotDesc.Location = new System.Drawing.Point(320, 15);
            this.txtTargetLotDesc.MaxLength = 200;
            this.txtTargetLotDesc.Name = "txtTargetLotDesc";
            this.txtTargetLotDesc.ReadOnly = true;
            this.txtTargetLotDesc.Size = new System.Drawing.Size(390, 20);
            this.txtTargetLotDesc.TabIndex = 2;
            this.txtTargetLotDesc.TabStop = false;
            // 
            // txtTargetLotID
            // 
            this.txtTargetLotID.Location = new System.Drawing.Point(118, 15);
            this.txtTargetLotID.MaxLength = 25;
            this.txtTargetLotID.Name = "txtTargetLotID";
            this.txtTargetLotID.Size = new System.Drawing.Size(200, 20);
            this.txtTargetLotID.TabIndex = 1;
            this.txtTargetLotID.TextChanged += new System.EventHandler(this.txtTargetLotID_TextChanged);
            this.txtTargetLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTargetLotID_KeyPress);
            // 
            // lblTargetLotID
            // 
            this.lblTargetLotID.AutoSize = true;
            this.lblTargetLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetLotID.Location = new System.Drawing.Point(12, 18);
            this.lblTargetLotID.Name = "lblTargetLotID";
            this.lblTargetLotID.Size = new System.Drawing.Size(83, 13);
            this.lblTargetLotID.TabIndex = 0;
            this.lblTargetLotID.Text = "Target Lot ID";
            this.lblTargetLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpTargetLotInfo
            // 
            this.grpTargetLotInfo.Controls.Add(this.pnlTagetLotInfoMain);
            this.grpTargetLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTargetLotInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTargetLotInfo.Location = new System.Drawing.Point(0, 86);
            this.grpTargetLotInfo.Name = "grpTargetLotInfo";
            this.grpTargetLotInfo.Size = new System.Drawing.Size(722, 109);
            this.grpTargetLotInfo.TabIndex = 1;
            this.grpTargetLotInfo.TabStop = false;
            this.grpTargetLotInfo.Text = "Target Lot Infomation";
            // 
            // pnlTagetLotInfoMain
            // 
            this.pnlTagetLotInfoMain.Controls.Add(this.spdTargetLotInfo);
            this.pnlTagetLotInfoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTagetLotInfoMain.Location = new System.Drawing.Point(3, 16);
            this.pnlTagetLotInfoMain.Name = "pnlTagetLotInfoMain";
            this.pnlTagetLotInfoMain.Size = new System.Drawing.Size(716, 90);
            this.pnlTagetLotInfoMain.TabIndex = 0;
            // 
            // spdTargetLotInfo
            // 
            this.spdTargetLotInfo.AccessibleDescription = "spdTargetLotInfo, LotInfo, Row 0, Column 0, ";
            this.spdTargetLotInfo.BackColor = System.Drawing.SystemColors.Control;
            this.spdTargetLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdTargetLotInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdTargetLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdTargetLotInfo.HorizontalScrollBar.Name = "";
            this.spdTargetLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdTargetLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdTargetLotInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdTargetLotInfo.Location = new System.Drawing.Point(0, 0);
            this.spdTargetLotInfo.MoveActiveOnFocus = false;
            this.spdTargetLotInfo.Name = "spdTargetLotInfo";
            this.spdTargetLotInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdTargetLotInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdTargetLotInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdTargetLotInfo_LotInfo});
            this.spdTargetLotInfo.Size = new System.Drawing.Size(716, 90);
            this.spdTargetLotInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdTargetLotInfo.TabIndex = 0;
            this.spdTargetLotInfo.TabStop = false;
            this.spdTargetLotInfo.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdTargetLotInfo.TextTipAppearance = tipAppearance1;
            this.spdTargetLotInfo.TextTipDelay = 200;
            this.spdTargetLotInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdTargetLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdTargetLotInfo.VerticalScrollBar.Name = "";
            this.spdTargetLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdTargetLotInfo.VerticalScrollBar.TabIndex = 3;
            this.spdTargetLotInfo.Resize += new System.EventHandler(this.spdTargetLotInfo_Resize);
            // 
            // spdTargetLotInfo_LotInfo
            // 
            this.spdTargetLotInfo_LotInfo.Reset();
            spdTargetLotInfo_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdTargetLotInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdTargetLotInfo_LotInfo.ColumnCount = 6;
            spdTargetLotInfo_LotInfo.RowCount = 19;
            this.spdTargetLotInfo_LotInfo.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdTargetLotInfo_LotInfo.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(0, 0).Value = "Lot ID";
            this.spdTargetLotInfo_LotInfo.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(0, 2).Value = "Material";
            this.spdTargetLotInfo_LotInfo.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(0, 4).Value = "Flow";
            this.spdTargetLotInfo_LotInfo.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(1, 0).Value = "Operation";
            this.spdTargetLotInfo_LotInfo.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(1, 2).Value = "Qty 1/2/3";
            this.spdTargetLotInfo_LotInfo.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(1, 4).Value = "Lot Type";
            this.spdTargetLotInfo_LotInfo.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(2, 0).Value = "Create Code";
            this.spdTargetLotInfo_LotInfo.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(2, 2).Value = "Owner Code";
            this.spdTargetLotInfo_LotInfo.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(2, 4).Value = "Due Date";
            this.spdTargetLotInfo_LotInfo.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(3, 0).Value = "Lot Status";
            this.spdTargetLotInfo_LotInfo.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(3, 2).Value = "Lot Priority";
            this.spdTargetLotInfo_LotInfo.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(3, 4).Value = "Hold Flag/Code";
            this.spdTargetLotInfo_LotInfo.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(4, 0).Value = "Start Flag";
            this.spdTargetLotInfo_LotInfo.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(4, 2).Value = "End Flag";
            this.spdTargetLotInfo_LotInfo.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(4, 4).Value = "Rework Flag/Code";
            this.spdTargetLotInfo_LotInfo.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(5, 0).Value = "Transit Flag";
            this.spdTargetLotInfo_LotInfo.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(5, 2).Value = "Inventory Flag";
            this.spdTargetLotInfo_LotInfo.Cells.Get(5, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(5, 4).Value = "Non Standard Flag";
            this.spdTargetLotInfo_LotInfo.Cells.Get(6, 0).Value = "Last Tran Code";
            this.spdTargetLotInfo_LotInfo.Cells.Get(6, 2).Value = "Last Tran Time";
            this.spdTargetLotInfo_LotInfo.Cells.Get(6, 4).Value = "Last Hist Seq";
            this.spdTargetLotInfo_LotInfo.Cells.Get(7, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(7, 0).Value = "Ship Code";
            this.spdTargetLotInfo_LotInfo.Cells.Get(7, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(7, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(7, 2).Value = "Ship Time";
            this.spdTargetLotInfo_LotInfo.Cells.Get(7, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(7, 4).Value = "Sample Flag";
            this.spdTargetLotInfo_LotInfo.Cells.Get(8, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(8, 0).Value = "Oper In Qty 1/2/3";
            this.spdTargetLotInfo_LotInfo.Cells.Get(8, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(8, 2).Value = "Create Qty 1/2/3";
            this.spdTargetLotInfo_LotInfo.Cells.Get(8, 4).Value = "Start Time";
            this.spdTargetLotInfo_LotInfo.Cells.Get(9, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(9, 0).Value = "Start Res ID";
            this.spdTargetLotInfo_LotInfo.Cells.Get(9, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(9, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(9, 2).Value = "End Time";
            this.spdTargetLotInfo_LotInfo.Cells.Get(9, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(9, 4).Value = "End Res ID";
            this.spdTargetLotInfo_LotInfo.Cells.Get(10, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(10, 0).Value = "Rework Ret Flow";
            this.spdTargetLotInfo_LotInfo.Cells.Get(10, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(10, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(10, 2).Value = "Rework Ret Oper";
            this.spdTargetLotInfo_LotInfo.Cells.Get(10, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(10, 4).Value = "Rework Count";
            this.spdTargetLotInfo_LotInfo.Cells.Get(11, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(11, 0).Value = "Rework End Flow";
            this.spdTargetLotInfo_LotInfo.Cells.Get(11, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(11, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(11, 2).Value = "Rework End Oper";
            this.spdTargetLotInfo_LotInfo.Cells.Get(11, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(11, 4).Value = "Rework Time";
            this.spdTargetLotInfo_LotInfo.Cells.Get(12, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(12, 0).Value = "NSTD Ret Flow";
            this.spdTargetLotInfo_LotInfo.Cells.Get(12, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(12, 2).Value = "NSTD Ret Oper";
            this.spdTargetLotInfo_LotInfo.Cells.Get(12, 4).Value = "NSTD Time";
            this.spdTargetLotInfo_LotInfo.Cells.Get(13, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(13, 0).Value = "Order ID";
            this.spdTargetLotInfo_LotInfo.Cells.Get(13, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(13, 2).Value = "Lot Location";
            this.spdTargetLotInfo_LotInfo.Cells.Get(13, 4).Value = "Batch ID";
            this.spdTargetLotInfo_LotInfo.Cells.Get(14, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(14, 0).Value = "Create Time";
            this.spdTargetLotInfo_LotInfo.Cells.Get(14, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(14, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(14, 2).Value = "Factory In Time";
            this.spdTargetLotInfo_LotInfo.Cells.Get(14, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(14, 4).Value = "Flow In Time";
            this.spdTargetLotInfo_LotInfo.Cells.Get(15, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(15, 0).Value = "Oper In Time";
            this.spdTargetLotInfo_LotInfo.Cells.Get(15, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(15, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(15, 2).Value = "From To Lot ID";
            this.spdTargetLotInfo_LotInfo.Cells.Get(15, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(15, 4).Value = "Reserve Res ID";
            this.spdTargetLotInfo_LotInfo.Cells.Get(16, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(16, 0).Value = "BOM Set ID";
            this.spdTargetLotInfo_LotInfo.Cells.Get(16, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(16, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(16, 2).Value = "BOM Set Version";
            this.spdTargetLotInfo_LotInfo.Cells.Get(16, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(16, 4).Value = "BOM Act Hist Seq";
            this.spdTargetLotInfo_LotInfo.Cells.Get(17, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(17, 0).Value = "Lot Del Flag";
            this.spdTargetLotInfo_LotInfo.Cells.Get(17, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(17, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(17, 2).Value = "Lot Del Time";
            this.spdTargetLotInfo_LotInfo.Cells.Get(17, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(17, 4).Value = "Lot Del Code";
            this.spdTargetLotInfo_LotInfo.Cells.Get(18, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(18, 0).Value = "Start Qty 1/2/3";
            this.spdTargetLotInfo_LotInfo.Cells.Get(18, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(18, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(18, 2).Value = "Carrier ID";
            this.spdTargetLotInfo_LotInfo.Cells.Get(18, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(18, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Cells.Get(18, 4).Value = "Last Active Hist Seq";
            this.spdTargetLotInfo_LotInfo.Cells.Get(18, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTargetLotInfo_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdTargetLotInfo_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTargetLotInfo_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdTargetLotInfo_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTargetLotInfo_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdTargetLotInfo_LotInfo.ColumnHeader.Visible = false;
            this.spdTargetLotInfo_LotInfo.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdTargetLotInfo_LotInfo.Columns.Get(0).Border = compoundBorder1;
            this.spdTargetLotInfo_LotInfo.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdTargetLotInfo_LotInfo.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Columns.Get(0).Locked = true;
            this.spdTargetLotInfo_LotInfo.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTargetLotInfo_LotInfo.Columns.Get(0).Width = 105F;
            this.spdTargetLotInfo_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdTargetLotInfo_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Columns.Get(1).Locked = false;
            this.spdTargetLotInfo_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTargetLotInfo_LotInfo.Columns.Get(1).Width = 126F;
            this.spdTargetLotInfo_LotInfo.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdTargetLotInfo_LotInfo.Columns.Get(2).Border = compoundBorder2;
            this.spdTargetLotInfo_LotInfo.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdTargetLotInfo_LotInfo.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Columns.Get(2).Locked = true;
            this.spdTargetLotInfo_LotInfo.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTargetLotInfo_LotInfo.Columns.Get(2).Width = 105F;
            this.spdTargetLotInfo_LotInfo.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.spdTargetLotInfo_LotInfo.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Columns.Get(3).Locked = false;
            this.spdTargetLotInfo_LotInfo.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTargetLotInfo_LotInfo.Columns.Get(3).Width = 126F;
            this.spdTargetLotInfo_LotInfo.Columns.Get(4).BackColor = System.Drawing.SystemColors.Control;
            this.spdTargetLotInfo_LotInfo.Columns.Get(4).Border = compoundBorder3;
            this.spdTargetLotInfo_LotInfo.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Columns.Get(4).Locked = true;
            this.spdTargetLotInfo_LotInfo.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTargetLotInfo_LotInfo.Columns.Get(4).Width = 105F;
            this.spdTargetLotInfo_LotInfo.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTargetLotInfo_LotInfo.Columns.Get(5).Locked = false;
            this.spdTargetLotInfo_LotInfo.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTargetLotInfo_LotInfo.Columns.Get(5).Width = 126F;
            this.spdTargetLotInfo_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdTargetLotInfo_LotInfo.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdTargetLotInfo_LotInfo.RowHeader.Columns.Default.Resizable = false;
            this.spdTargetLotInfo_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTargetLotInfo_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdTargetLotInfo_LotInfo.RowHeader.Visible = false;
            this.spdTargetLotInfo_LotInfo.Rows.Get(0).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(1).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(2).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(3).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(4).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(5).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(6).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(7).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(8).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(9).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(10).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(11).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(12).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(13).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(14).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(15).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(16).Height = 17F;
            this.spdTargetLotInfo_LotInfo.Rows.Get(17).Height = 17F;
            this.spdTargetLotInfo_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTargetLotInfo_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            // 
            // grpMoveQty
            // 
            this.grpMoveQty.Controls.Add(this.lblQty3);
            this.grpMoveQty.Controls.Add(this.txtMQty3);
            this.grpMoveQty.Controls.Add(this.txtMQty2);
            this.grpMoveQty.Controls.Add(this.lblQty2);
            this.grpMoveQty.Controls.Add(this.txtMQty1);
            this.grpMoveQty.Controls.Add(this.lblQty1);
            this.grpMoveQty.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpMoveQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMoveQty.Location = new System.Drawing.Point(0, 195);
            this.grpMoveQty.Name = "grpMoveQty";
            this.grpMoveQty.Size = new System.Drawing.Size(722, 39);
            this.grpMoveQty.TabIndex = 2;
            this.grpMoveQty.TabStop = false;
            // 
            // lblQty3
            // 
            this.lblQty3.AutoSize = true;
            this.lblQty3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblQty3.Location = new System.Drawing.Point(490, 17);
            this.lblQty3.Name = "lblQty3";
            this.lblQty3.Size = new System.Drawing.Size(62, 13);
            this.lblQty3.TabIndex = 4;
            this.lblQty3.Text = "Move Qty 3";
            this.lblQty3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMQty3
            // 
            this.txtMQty3.Location = new System.Drawing.Point(591, 13);
            this.txtMQty3.MaxLength = 11;
            this.txtMQty3.Name = "txtMQty3";
            this.txtMQty3.ReadOnly = true;
            this.txtMQty3.Size = new System.Drawing.Size(96, 20);
            this.txtMQty3.TabIndex = 5;
            this.txtMQty3.TabStop = false;
            // 
            // txtMQty2
            // 
            this.txtMQty2.Location = new System.Drawing.Point(352, 13);
            this.txtMQty2.MaxLength = 11;
            this.txtMQty2.Name = "txtMQty2";
            this.txtMQty2.ReadOnly = true;
            this.txtMQty2.Size = new System.Drawing.Size(97, 20);
            this.txtMQty2.TabIndex = 3;
            this.txtMQty2.TabStop = false;
            // 
            // lblQty2
            // 
            this.lblQty2.AutoSize = true;
            this.lblQty2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblQty2.Location = new System.Drawing.Point(251, 17);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(62, 13);
            this.lblQty2.TabIndex = 2;
            this.lblQty2.Text = "Move Qty 2";
            this.lblQty2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMQty1
            // 
            this.txtMQty1.Location = new System.Drawing.Point(113, 13);
            this.txtMQty1.MaxLength = 11;
            this.txtMQty1.Name = "txtMQty1";
            this.txtMQty1.ReadOnly = true;
            this.txtMQty1.Size = new System.Drawing.Size(97, 20);
            this.txtMQty1.TabIndex = 1;
            this.txtMQty1.TabStop = false;
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblQty1.Location = new System.Drawing.Point(12, 17);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(62, 13);
            this.lblQty1.TabIndex = 0;
            this.lblQty1.Text = "Move Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmWIPTranCombineLotExt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranCombineLotExt";
            this.Text = "Combine Extension";
            this.Activated += new System.EventHandler(this.frmWIPTranCombineLot_Activated);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlGeneralTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotInfo)).EndInit();
            this.grpLotInfo.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTran.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.grpCMF.ResumeLayout(false);
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
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tbpSublotInfo.ResumeLayout(false);
            this.grpSublotInfo.ResumeLayout(false);
            this.pnlSplitSublot.ResumeLayout(false);
            this.pnlSubChild.ResumeLayout(false);
            this.grpChildSubLot.ResumeLayout(false);
            this.pnlSubChildMid.ResumeLayout(false);
            this.pnlSubChildTop.ResumeLayout(false);
            this.pnlSubChildTop.PerformLayout();
            this.pnlSubMother.ResumeLayout(false);
            this.grpMotherSubLot.ResumeLayout(false);
            this.pnlSubMotherMid.ResumeLayout(false);
            this.pnlSubMotherTop.ResumeLayout(false);
            this.pnlSubMotherTop.PerformLayout();
            this.grpTranInfo.ResumeLayout(false);
            this.grpTranInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvIntoCrrID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).EndInit();
            this.grpTargetLotInfo.ResumeLayout(false);
            this.pnlTagetLotInfoMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdTargetLotInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdTargetLotInfo_LotInfo)).EndInit();
            this.grpMoveQty.ResumeLayout(false);
            this.grpMoveQty.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private TRSNode TLOT = new TRSNode("");
        
        #endregion
        
        #region " Function Definition "

        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            string s_src_crr_id;
            string s_tar_lot_id;
            string s_tar_crr_id;

            s_src_crr_id = MPCF.Trim(cdvCrrID.Text);
            s_tar_lot_id = MPCF.Trim(txtTargetLotID.Text);
            s_tar_crr_id = MPCF.Trim(cdvIntoCrrID.Text);

            MPCF.FieldClear(this);
            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotID.Text = LOT.GetString("LOT_ID");
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            if (MPGO.ProcessZeroQtyLot() == true)
                chkNoAutoTermLot.Checked = true;

#if _CRR
            cdvCrrID.Init();
            MPCF.InitListView(cdvCrrID.GetListView);
            cdvCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrID.SelectedSubItemIndex = 0;
            if (RASLIST.ViewCarrierList(cdvCrrID.GetListView, txtLotID.Text) == false)
            {
                txtLotID.Focus();
                return false;
            }
#endif

            if (cdvCrrID.Items.Count < 1)
            {
                if (WIPLIST.ViewSublotList(lisSource, '1', txtLotID.Text, null) == false)
                {
                    txtLotID.Focus();
                    return false;
                }
            }
            else if (cdvCrrID.Items.Count == 1)
            {
                cdvCrrID.Text = cdvCrrID.Items[0].Text;
                cdvCrrID_SelectedItemChanged(null, null);
            }
            else
            {
                if (s_src_crr_id != "")
                {
                    if (MPCF.FindListItemIndex(cdvCrrID.GetListView, s_src_crr_id, false) < 0)
                    {
                        lisSource.Items.Clear();
                    }
                    else
                    {
                        cdvCrrID.Text = s_src_crr_id;
                        cdvCrrID_SelectedItemChanged(null, null);
                    }
                }
                else
                {
                    lisSource.Items.Clear();
                }
            }

            txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
            txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
            txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");

            lisTarget.Items.Clear();
            txtTargetLotID_TextChanged(null, null);

            if (s_tar_lot_id != "")
            {
                ViewTargetLotInfo(s_tar_lot_id, s_tar_crr_id);
            }

            return true;
        }
        
        // ViewTargetLotInfo()
        //       -   View Target Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        private bool ViewTargetLotInfo(string s_lot_id)
        {
            return ViewTargetLotInfo(s_lot_id, cdvIntoCrrID.Text);
        }

        private bool ViewTargetLotInfo(string s_lot_id, string s_tar_crr_id)
        {
            //Get Target Lot and carrier information
            if (MPCR.SetLotInfoSpread(spdTargetLotInfo, s_lot_id, ref TLOT) == false)
            {
                txtTargetLotID.Focus();
                return false;
            }
            txtTargetLotID.Text = TLOT.GetString("LOT_ID");
            txtTargetLotDesc.Text = TLOT.GetString("LOT_DESC");

            txtMoveQty1.Text = "0";
            txtMoveQty2.Text = "0";
            txtMoveQty3.Text = "0";

            if (View_Operation() == false)
            {
                return false;
            }

            if (TLOT.GetDouble("QTY_1") > 0 || TLOT.GetDouble("QTY_2") > 0 || TLOT.GetDouble("QTY_3") > 0)
            {
#if _CRR
                cdvIntoCrrID.Init();
                MPCF.InitListView(cdvIntoCrrID.GetListView);
                cdvIntoCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
                cdvIntoCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvIntoCrrID.SelectedSubItemIndex = 0;
                if (RASLIST.ViewCarrierList(cdvIntoCrrID.GetListView, txtTargetLotID.Text) == false)
                {
                    return false;
                }
#endif

                if (cdvIntoCrrID.Items.Count < 1)
                {
                    cdvIntoCrrID.Text = "";
                    if (WIPLIST.ViewSublotList(lisTarget, '1', txtTargetLotID.Text, null) == false)
                    {
                        return false;
                    }
                }
                else if (cdvIntoCrrID.Items.Count == 1)
                {
                    cdvIntoCrrID.Text = cdvIntoCrrID.Items[0].Text;
                    cdvIntoCrrID_SelectedItemChanged(null, null);
                }
                else
                {
                    if (s_tar_crr_id != "")
                    {
                        if (MPCF.FindListItemIndex(cdvIntoCrrID.GetListView, s_tar_crr_id, false) < 0)
                        {
                            cdvIntoCrrID.Text = "";
                            lisTarget.Items.Clear();
                        }
                        else
                        {
                            cdvIntoCrrID.Text = s_tar_crr_id;
                            cdvIntoCrrID_SelectedItemChanged(null, null);
                        }
                    }
                    else
                    {
                        cdvIntoCrrID.Text = "";
                        lisTarget.Items.Clear();
                    }
                }
            }
            else
            {
#if _CRR
                cdvIntoCrrID.Text = "";
                cdvIntoCrrID.Init();
                MPCF.InitListView(cdvIntoCrrID.GetListView);
                cdvIntoCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
                cdvIntoCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvIntoCrrID.SelectedSubItemIndex = 0;
                if (RASLIST.ViewCarrierList(cdvIntoCrrID.GetListView, '1', ' ', TLOT.GetString("MAT_ID"), TLOT.GetInt("MAT_VER"), TLOT.GetString("FLOW"), TLOT.GetString("OPER"), TLOT.GetString("START_RES_ID"), TLOT.GetString("PORT_ID")) == false)
                {
                    return false;
                }
#endif
                if (WIPLIST.ViewSublotList(lisTarget, '1', txtTargetLotID.Text, null) == false)
                {
                    return false;
                }
            }

            return true;
        }

  //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        private void ClearData()
        {
            try
            {
                //Initialize
                ClearLotSpread();
                MPCF.FieldClear(this);
                MPCR.ClearLotSpread(spdTargetLotInfo);
                
                MPCF.InitListView(lisSource);
                MPCF.InitListView(lisTarget);
                
                txtQty1.Text = "0";
                txtQty2.Text = "0";
                txtQty3.Text = "0";
                
                txtMoveQty1.Text = "0";
                txtMoveQty2.Text = "0";
                txtMoveQty3.Text = "0";
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
            
            switch (MPCF.Trim(FuncName))
            {
                case "COMBINE_LOT":

                    if (MPCF.CheckValue(txtLotID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                        txtLotID.Focus();
                        return false;
                    }
                    //if (MPCF.Trim(LOT.GetString("FLOW")) == "")
                    //{
                    //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                    //    txtLotID.Focus();
                    //    return false;
                    //}
                    if (MPCF.Trim(LOT.GetString("OPER")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(txtTargetLotID, 1) == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        txtTargetLotID.Focus();
                        return false;
                    }
                    if (MPCF.Trim(txtLotID.Text) == MPCF.Trim(txtTargetLotID.Text))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(306));
                        tabTran.SelectedTab = tbpGeneral;
                        txtTargetLotID.Focus();
                        return false;
                    }
                    //MoveQty Validation
                    if (MPCF.Trim(txtMQty1.Text) != "")
                    {
                        if (MPCF.CheckValue(txtMQty1, 1) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtMQty1.Focus();
                            return false;
                        }
                    }
                    if (MPCF.Trim(txtMQty2.Text) != "")
                    {
                        if (MPCF.CheckValue(txtMQty2, 1) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtMQty2.Focus();
                            return false;
                        }
                    }
                    if (MPCF.Trim(txtMQty3.Text) != "")
                    {
                        if (MPCF.CheckValue(txtMQty3, 1) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtMQty3.Focus();
                            return false;
                        }
                    }
                    if (txtMQty1.Text != "" && txtMQty1.Text != "0")
                    {
                        if (LOT.GetDouble("QTY_1") < MPCF.ToDbl(txtMQty1.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(136));
                            tabTran.SelectedTab = tbpGeneral;
                            txtMQty1.Text = "0";
                            txtMQty1.Focus();
                            return false;
                        }
                    }
                    if (txtMQty2.Text != "" && txtMQty2.Text != "0")
                    {
                        if (LOT.GetDouble("QTY_2") < MPCF.ToDbl(txtMQty2.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(136));
                            tabTran.SelectedTab = tbpGeneral;
                            txtMQty2.Text = "0";
                            txtMQty2.Focus();
                            return false;
                        }
                    }
                    if (txtMQty3.Text != "" && txtMQty3.Text != "0")
                    {
                        if (LOT.GetDouble("QTY_3") < MPCF.ToDbl(txtMQty3.Text))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(136));
                            tabTran.SelectedTab = tbpGeneral;
                            txtMQty3.Text = "0";
                            txtMQty3.Focus();
                            return false;
                        }
                    }
                    
                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
            }
            
            return true;
            
        }
        
        //
        // View_Operation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Operation()
        {

            TRSNode in_node = new TRSNode("View_Operation_In");
            TRSNode out_node = new TRSNode("View_Operation_Out");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", TLOT.GetString("OPER"));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            if (LOT.GetInt("SUBLOT_COUNT") < 1 && TLOT.GetInt("SUBLOT_COUNT") < 1)
            {
                if (out_node.GetString("UNIT_1") != "")
                {
                    txtMQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
                    txtMQty1.ReadOnly = false;
                }
                else
                {
                    txtMQty1.ReadOnly = true;
                }
                if (out_node.GetString("UNIT_2") != "")
                {
                    txtMQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
                    txtMQty2.ReadOnly = false;
                }
                else
                {
                    txtMQty2.ReadOnly = true;
                }
                if (out_node.GetString("UNIT_3") != "")
                {
                    txtMQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
                    txtMQty3.ReadOnly = false;
                }
                else
                {
                    txtMQty3.ReadOnly = true;
                }
            }
            else
            {
                txtMQty1.Text = "0";
                txtMQty2.Text = "0";
                txtMQty3.Text = "0";

                txtMQty1.ReadOnly = true;
                txtMQty2.ReadOnly = true;
                txtMQty3.ReadOnly = true;
            }


            if (out_node.GetString("UNIT_2") != "")
            {
                txtMoveQty2.Tag = out_node.GetString("UNIT_2");
                txtMoveQty2.ReadOnly = false;
            }
            else
            {
                txtMoveQty2.ReadOnly = true;
            }
            if (out_node.GetString("UNIT_3") != "")
            {
                txtMoveQty3.Tag = out_node.GetString("UNIT_3");
                txtMoveQty3.ReadOnly = false;
            }
            else
            {
                txtMoveQty3.ReadOnly = true;
            }

            return true;

        }

        //
        // Combine_Lot()
        //       - Combine Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Combine_Lot_Ext(char ProcStep)
        {

            TRSNode in_node = new TRSNode("Combine_Lot_Ext_In");
            TRSNode out_node = new TRSNode("Cmn_Out");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddString("CRR_ID", MPCF.Trim(cdvCrrID.Text));

                in_node.AddString("LOT_TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("LOT_TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("LOT_TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("LOT_TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("LOT_TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("LOT_TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("LOT_TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("LOT_TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("LOT_TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("LOT_TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));

                in_node.AddString("INTO_LOT_ID", MPCF.Trim(txtTargetLotID.Text));

                SetCombineSublot(ref in_node);

                if (txtMoveQty1.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_1", MPCF.ToDbl(txtMoveQty1.Text));
                }
                if (txtMoveQty2.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_2", MPCF.ToDbl(txtMoveQty2.Text));
                }
                if (txtMoveQty3.Text != "")
                {
                    in_node.AddDouble("MOVE_QTY_3", MPCF.ToDbl(txtMoveQty3.Text));
                }
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddChar("NO_AUTOMATIC_TERMINATE_LOT", chkNoAutoTermLot.Checked == true ? 'Y' : ' ');

                if (MPCR.CallService("WIP", "WIP_Combine_Lot_Ext", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        
        private void SetCombineSublot(ref TRSNode cb_in)
        {
            int i;
            int iCnt;
            TRSNode list_item;
            
            iCnt = MPCF.ToInt(txtMoveQty1.Text);
            if (iCnt < 1)
            {
                return;
            }
            
            for (i = 0; i <= lisSource.Items.Count - 1; i++)
            {
                if (lisSource.Items[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_EMPTY && lisSource.Items[i].SubItems[1].Text != "")
                {
                    list_item = cb_in.AddNode("SUBLOT");

                    list_item.AddInt("INTO_SLOT_NO", MPCF.ToInt(lisSource.Items[i].SubItems[4].Text));
                    list_item.AddString("SUBLOT_ID", lisSource.Items[i].SubItems[1].Text);
                    list_item.AddInt("SLOT_NO", MPCF.ToInt(lisSource.Items[i].Text));
                }
            }
            
        }
        
        #endregion
        
        private void frmWIPTranCombineLot_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    this.tabTran.TabPages.Remove(this.tbpCMF);
                    this.tabTran.Controls.Add(this.tbpCMF);

                    #if _CRR
                    lblCrrID.Visible = true;
                    cdvCrrID.Visible = true;
                    lblIntoCrrID.Visible = true;
                    cdvIntoCrrID.Visible = true;
                    #else
                    pnlTranInfo.Height = 44;
                    #endif
                    
                    ClearData();
                    SetCMFItem(MPGC.MP_CMF_TRN_COMBINE);
                    
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLotID.Text = MPGV.gsCurrentLot_ID;
                        ViewLotInfo(txtLotID.Text);
                    }
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdTargetLotInfo_Resize(object sender, System.EventArgs e)
        {
            
            int iDiffSize;
            
            try
            {
                iDiffSize = (spdTargetLotInfo.Size.Width - 722) / 3;
                
                if (iDiffSize >= 0)
                {
                    spdTargetLotInfo.Sheets[0].Columns[1].Width = 126 + iDiffSize;
                    spdTargetLotInfo.Sheets[0].Columns[3].Width = 126 + iDiffSize;
                    spdTargetLotInfo.Sheets[0].Columns[5].Width = 126 + iDiffSize;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtTargetLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)13)
            {
                ViewTargetLotInfo(txtTargetLotID.Text);
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("COMBINE_LOT") == false) return;

                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_COMBINE, LOT.GetString("LOT_ID"), "", "", 'B') == false) return;
                if (Combine_Lot_Ext('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_COMBINE, LOT.GetString("LOT_ID"), "", "", 'A') == false) return;

                if ((LOT.GetDouble("QTY_1") - MPCF.ToDbl(txtMoveQty1.Text)) < 0.0005)
                {
                    string s_tar_lot_id = txtTargetLotID.Text;
                    string s_tar_crr_id = cdvIntoCrrID.Text;

                    ClearData();
                    ViewTargetLotInfo(s_tar_lot_id, s_tar_crr_id);
                }
                else
                {
                    ViewLotInfo(txtLotID.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void grpSublotInfo_Resize(object sender, System.EventArgs e)
        {
            
            MPCF.FieldAdjust(grpSublotInfo, pnlSubMother, pnlSubChild, pnlSplitSublot, 40);
            
        }
        
        private void btnCombine_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int Index;
            
            try
            {
                
                if (lisSource.Items.Count < 1)
                {
                    return;
                }
                if (lisTarget.Items.Count < 1)
                {
                    return;
                }
                
                if (lisSource.SelectedItems.Count < 1)
                {
                    return;
                }
                if (lisTarget.SelectedItems.Count < 1)
                {
                    return;
                }
                
                Index = lisTarget.SelectedItems[0].Index;
                for (i = 0; i <= lisSource.SelectedItems.Count - 1; i++)
                {
                    if (lisSource.SelectedItems[i].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_FULL && lisSource.SelectedItems[i].SubItems[2].Text == MPCF.Trim(txtLotID.Text))
                    {
                        if (lisTarget.Items[Index].ImageIndex == (int)SMALLICON_INDEX.IDX_SLOT_EMPTY)
                        {
                            break;
                        }
                        else
                        {
                            if (MPCF.ToDbl(txtQty1.Text) < 0.0005)
                            {
                                break;
                            }

                            txtMoveQty1.Text = Convert.ToString(MPCF.ToDbl(txtMoveQty1.Text) + 1);
                            txtQty1.Text = Convert.ToString(MPCF.ToDbl(txtQty1.Text) - 1);
                            if (MPCF.ToDbl(txtQty2.Text) > 0.0005)
                            {
                                txtMoveQty2.Text = Convert.ToString(MPCF.ToDbl(txtMoveQty2.Text) + MPCF.ToDbl(lisSource.SelectedItems[i].Tag));
                                txtQty2.Text = Convert.ToString(MPCF.ToDbl(txtQty2.Text) - MPCF.ToDbl(lisSource.SelectedItems[i].Tag));
                            }
                            
                            lisTarget.Items[Index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_COMBINE;
                            if (lisTarget.Items[Index].SubItems[4].Text == "")
                            {
                                lisTarget.Items[Index].SubItems[4].Text = lisSource.SelectedItems[i].Text;
                            }
                            else
                            {
                                lisTarget.Items[Index].SubItems[4].Text = lisTarget.Items[Index].SubItems[4].Text + ";" + lisSource.SelectedItems[i].Text;
                            }
                            
                            lisTarget.Items[Index].Selected = true;
                            lisTarget.Items[Index].EnsureVisible();
                            lisSource.SelectedItems[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_EMPTY;
                            lisSource.SelectedItems[i].SubItems[4].Text = Convert.ToString(Index + 1);
                            Index++;
                            if (Index <= lisTarget.Items.Count)
                            {
                                //    lisTarget.ListItems(Index).Selected = True
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

                txtMQty1.Text = txtMoveQty1.Text;
                txtMQty2.Text = txtMoveQty2.Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnUnCombine_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            int index;
            int iTempStart;
            int iTempEnd;
            
            try
            {
                
                if (lisSource.Items.Count < 1)
                {
                    return;
                }
                if (lisTarget.Items.Count < 1)
                {
                    return;
                }
                
                if (lisTarget.SelectedItems.Count < 1)
                {
                    return;
                }
                
                if (lisTarget.SelectedItems[0].ImageIndex != (int)SMALLICON_INDEX.IDX_SLOT_COMBINE)
                {
                    return;
                }
                
                if (MPCF.CheckNumeric(txtQty1.Text) == false)
                {
                    txtQty1.Text = "0";
                }
                if (MPCF.CheckNumeric(txtMoveQty1.Text) == false)
                {
                    txtMoveQty1.Text = "0";
                }
                
                for (i = 0; i <= lisTarget.SelectedItems.Count - 1; i++)
                {
                    if (lisTarget.SelectedItems[i].ImageIndex != (int)SMALLICON_INDEX.IDX_SLOT_COMBINE)
                    {
                        break;
                    }
                    
                    iTempStart = 0;
                    
                    while (iTempStart <= lisTarget.SelectedItems[i].SubItems[4].Text.Length)
                    {
                        iTempEnd = lisTarget.SelectedItems[i].SubItems[4].Text.IndexOf(";", iTempStart);
                        if (iTempEnd < 0)
                        {
                            iTempEnd = iTempStart + 1;
                        }
                        index = (int)(MPCF.ToDbl(MPCF.Mid(lisTarget.SelectedItems[i].SubItems[4].Text, iTempStart, iTempEnd - iTempStart)) - 1);
                        
                        txtMoveQty1.Text = Convert.ToString(MPCF.ToDbl(txtMoveQty1.Text) - 1);
                        txtQty1.Text = Convert.ToString((MPCF.ToDbl(txtQty1.Text) + 1));
                        if (MPCF.ToDbl(txtQty2.Text) > 0.0005)
                        {
                            txtMoveQty2.Text = Convert.ToString(MPCF.ToDbl(txtMoveQty2.Text) - MPCF.ToDbl(lisSource.Items[index].Tag));
                            txtQty2.Text = Convert.ToString(MPCF.ToDbl(txtQty2.Text) + MPCF.ToDbl(lisSource.Items[index].Tag));
                        }

                        lisSource.Items[index].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                        lisSource.Items[index].SubItems[4].Text = "";
                        iTempStart = iTempEnd + 1;
                    }
                    
                    lisTarget.SelectedItems[i].ImageIndex = (int)SMALLICON_INDEX.IDX_SLOT_FULL;
                    lisTarget.SelectedItems[i].SubItems[4].Text = "";
                }

                txtMQty1.Text = txtMoveQty1.Text;
                txtMQty2.Text = txtMoveQty2.Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void txtTargetLotID_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (txtTargetLotID.Text == "")
            {
                grpSublotInfo.Enabled = false;
            }
            else
            {
                grpSublotInfo.Enabled = true;
            }
        }
        

        private void cdvCrrID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Text != "")
            {
                RASLIST.ViewCarrierSublotList(lisSource, '1', cdvCrrID.Text, true);
                txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
                txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
                txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
                
                if (cdvIntoCrrID.Items.Count > 0)
                {
                    if (cdvIntoCrrID.Text == "")
                    {
                        lisTarget.Items.Clear();
                    }
                    else
                    {
                        RASLIST.ViewCarrierSublotList(lisTarget, '1', cdvIntoCrrID.Text, true);
                    }
                }
                else
                {
                    if (txtTargetLotID.Text != "")
                    {
                        if (WIPLIST.ViewSublotList(lisTarget, '1', txtTargetLotID.Text, null) == false)
                        {
                            return;
                        }
                    }
                }
                txtMoveQty1.Text = "0";
                txtMoveQty2.Text = "0";
                txtMoveQty3.Text = "0";
                
            }
#endif
        }
        
        private void cdvCrrID_TextBoxTextChanged(System.Object sender, System.EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Text == "")
            {
                if (cdvCrrID.Items.Count > 0)
                {
                    lisSource.Items.Clear();
                }
                else
                {
                    if (WIPLIST.ViewSublotList(lisSource, '1', txtLotID.Text, null) == false)
                    {
                        return;
                    }
                }
                txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
                txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
                txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
                
                if (cdvIntoCrrID.Items.Count > 0)
                {
                    if (cdvIntoCrrID.Text == "")
                    {
                        lisTarget.Items.Clear();
                    }
                    else
                    {
                        RASLIST.ViewCarrierSublotList(lisTarget, '1', cdvIntoCrrID.Text, true);
                    }
                }
                else
                {
                    if (txtTargetLotID.Text != "")
                    {
                        if (WIPLIST.ViewSublotList(lisTarget, '1', txtTargetLotID.Text, null) == false)
                        {
                            return;
                        }
                    }
                }
                txtMoveQty1.Text = "0";
                txtMoveQty2.Text = "0";
                txtMoveQty3.Text = "0";
            }
#endif
        }
        
        private void cdvIntoCrrID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
#if _CRR
            if (cdvCrrID.Items.Count > 0)
            {
                if (cdvCrrID.Text == "")
                {
                    lisSource.Items.Clear();
                }
                else
                {
                    RASLIST.ViewCarrierSublotList(lisSource, '1', cdvCrrID.Text, true);
                }
            }
            else
            {
                if (WIPLIST.ViewSublotList(lisSource, '1', txtLotID.Text, null) == false)
                {
                    return;
                }
            }
            txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
            txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
            txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
            
            if (cdvIntoCrrID.Text == "")
            {
                lisTarget.Items.Clear();
            }
            else
            {
                RASLIST.ViewCarrierSublotList(lisTarget, '1', cdvIntoCrrID.Text, true);
            }
            txtMoveQty1.Text = "0";
            txtMoveQty2.Text = "0";
            txtMoveQty3.Text = "0";
#endif
        }
        
        private void cdvIntoCrrID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
#if _CRR
            if (cdvIntoCrrID.Text == "")
            {
                if (cdvCrrID.Items.Count > 0)
                {
                    if (cdvCrrID.Text == "")
                    {
                        lisSource.Items.Clear();
                    }
                    else
                    {
                        RASLIST.ViewCarrierSublotList(lisSource, '1', cdvCrrID.Text, true);
                    }
                }
                else
                {
                    if (WIPLIST.ViewSublotList(lisSource, '1', txtLotID.Text, null) == false)
                    {
                        return;
                    }
                }
                txtQty1.Text = LOT.GetDouble("QTY_1").ToString("####,##0.###");
                txtQty2.Text = LOT.GetDouble("QTY_2").ToString("####,##0.###");
                txtQty3.Text = LOT.GetDouble("QTY_3").ToString("####,##0.###");
                
                if (cdvIntoCrrID.Items.Count > 0)
                {
                    lisTarget.Items.Clear();
                }
                else
                {
                    if (WIPLIST.ViewSublotList(lisTarget, '1', txtTargetLotID.Text, null) == false)
                    {
                        return;
                    }
                }
                txtMoveQty1.Text = "0";
                txtMoveQty2.Text = "0";
                txtMoveQty3.Text = "0";
                
            }
#endif
        }
    }    
}
