
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranLocalRepairLot.vb
//   Description : Local Repair Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - GetFlowList : Get Flow List
//       - GetOperationList() : Get Operation List
//       - GetResIDList() : Get ResourceID List
//       - Local_Repair_Lot() : Repair Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-04-06 : Created by HS Kim
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
    public class frmWIPTranLocalRepairLot : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranLocalRepairLot()
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
        



        private System.Windows.Forms.GroupBox grpLocalRepair;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseFlow;
        private System.Windows.Forms.Label lblCauseFlow;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseRes;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseOper;
        private System.Windows.Forms.Label lblCauseRes;
        private System.Windows.Forms.Label lblCauseOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRepairCode;
        private System.Windows.Forms.Label lblRepairCode;
        private System.Windows.Forms.TextBox txtChkUser2;
        private System.Windows.Forms.TextBox txtChkUser1;
        private System.Windows.Forms.Label lblUser1;
        private System.Windows.Forms.Label lblUser2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvActionCode;
        private System.Windows.Forms.Label lblActionCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResultCode;
        private System.Windows.Forms.Label lblResultCode;
        private TabPage tbpEndCMF;
        private GroupBox grpEndCMF;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF10;
        protected Label lblEndCMF20;
        protected Label lblEndCMF19;
        protected Label lblEndCMF18;
        protected Label lblEndCMF17;
        protected Label lblEndCMF16;
        protected Label lblEndCMF15;
        protected Label lblEndCMF14;
        protected Label lblEndCMF13;
        protected Label lblEndCMF12;
        protected Label lblEndCMF11;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF19;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF18;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF17;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF16;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF15;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF14;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF13;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF12;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF20;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF11;
        protected Label lblEndCMF10;
        protected Label lblEndCMF9;
        protected Label lblEndCMF8;
        protected Label lblEndCMF7;
        protected Label lblEndCMF6;
        protected Label lblEndCMF5;
        protected Label lblEndCMF4;
        protected Label lblEndCMF3;
        protected Label lblEndCMF2;
        protected Label lblEndCMF1;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvEndCMF1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.grpLocalRepair = new System.Windows.Forms.GroupBox();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvActionCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblActionCode = new System.Windows.Forms.Label();
            this.cdvResultCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResultCode = new System.Windows.Forms.Label();
            this.cdvCauseFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCauseFlow = new System.Windows.Forms.Label();
            this.cdvCauseRes = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCauseOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCauseRes = new System.Windows.Forms.Label();
            this.lblCauseOper = new System.Windows.Forms.Label();
            this.cdvRepairCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRepairCode = new System.Windows.Forms.Label();
            this.txtChkUser2 = new System.Windows.Forms.TextBox();
            this.txtChkUser1 = new System.Windows.Forms.TextBox();
            this.lblUser1 = new System.Windows.Forms.Label();
            this.lblUser2 = new System.Windows.Forms.Label();
            this.tbpEndCMF = new System.Windows.Forms.TabPage();
            this.grpEndCMF = new System.Windows.Forms.GroupBox();
            this.lblEndCMF20 = new System.Windows.Forms.Label();
            this.lblEndCMF19 = new System.Windows.Forms.Label();
            this.lblEndCMF18 = new System.Windows.Forms.Label();
            this.lblEndCMF17 = new System.Windows.Forms.Label();
            this.lblEndCMF16 = new System.Windows.Forms.Label();
            this.lblEndCMF15 = new System.Windows.Forms.Label();
            this.lblEndCMF14 = new System.Windows.Forms.Label();
            this.lblEndCMF13 = new System.Windows.Forms.Label();
            this.lblEndCMF12 = new System.Windows.Forms.Label();
            this.lblEndCMF11 = new System.Windows.Forms.Label();
            this.cdvEndCMF19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEndCMF10 = new System.Windows.Forms.Label();
            this.lblEndCMF9 = new System.Windows.Forms.Label();
            this.lblEndCMF8 = new System.Windows.Forms.Label();
            this.lblEndCMF7 = new System.Windows.Forms.Label();
            this.lblEndCMF6 = new System.Windows.Forms.Label();
            this.lblEndCMF5 = new System.Windows.Forms.Label();
            this.lblEndCMF4 = new System.Windows.Forms.Label();
            this.lblEndCMF3 = new System.Windows.Forms.Label();
            this.lblEndCMF2 = new System.Windows.Forms.Label();
            this.lblEndCMF1 = new System.Windows.Forms.Label();
            this.cdvEndCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvEndCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
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
            this.grpLocalRepair.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResultCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRepairCode)).BeginInit();
            this.tbpEndCMF.SuspendLayout();
            this.grpEndCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpLocalRepair);
            this.pnlTranInfo.Size = new System.Drawing.Size(722, 235);
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 415);
            // 
            // pnlTran
            // 
            this.pnlTran.Size = new System.Drawing.Size(722, 376);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 379);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
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
            this.tabTran.Controls.Add(this.tbpEndCMF);
            this.tabTran.Size = new System.Drawing.Size(736, 441);
            this.tabTran.Controls.SetChildIndex(this.tbpEndCMF, 0);
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
            // pnlTranCenter
            // 
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 444);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Local Repair Lot";
            // 
            // grpLocalRepair
            // 
            this.grpLocalRepair.Controls.Add(this.cdvResID);
            this.grpLocalRepair.Controls.Add(this.lblResID);
            this.grpLocalRepair.Controls.Add(this.cdvActionCode);
            this.grpLocalRepair.Controls.Add(this.lblActionCode);
            this.grpLocalRepair.Controls.Add(this.cdvResultCode);
            this.grpLocalRepair.Controls.Add(this.lblResultCode);
            this.grpLocalRepair.Controls.Add(this.cdvCauseFlow);
            this.grpLocalRepair.Controls.Add(this.lblCauseFlow);
            this.grpLocalRepair.Controls.Add(this.cdvCauseRes);
            this.grpLocalRepair.Controls.Add(this.cdvCauseOper);
            this.grpLocalRepair.Controls.Add(this.lblCauseRes);
            this.grpLocalRepair.Controls.Add(this.lblCauseOper);
            this.grpLocalRepair.Controls.Add(this.cdvRepairCode);
            this.grpLocalRepair.Controls.Add(this.lblRepairCode);
            this.grpLocalRepair.Controls.Add(this.txtChkUser2);
            this.grpLocalRepair.Controls.Add(this.txtChkUser1);
            this.grpLocalRepair.Controls.Add(this.lblUser1);
            this.grpLocalRepair.Controls.Add(this.lblUser2);
            this.grpLocalRepair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLocalRepair.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLocalRepair.Location = new System.Drawing.Point(0, 0);
            this.grpLocalRepair.Name = "grpLocalRepair";
            this.grpLocalRepair.Size = new System.Drawing.Size(722, 235);
            this.grpLocalRepair.TabIndex = 2;
            this.grpLocalRepair.TabStop = false;
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
            this.cdvResID.Location = new System.Drawing.Point(118, 88);
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
            this.cdvResID.TabIndex = 7;
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
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(12, 91);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 6;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvActionCode
            // 
            this.cdvActionCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActionCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActionCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActionCode.BtnToolTipText = "";
            this.cdvActionCode.DescText = "";
            this.cdvActionCode.DisplaySubItemIndex = -1;
            this.cdvActionCode.DisplayText = "";
            this.cdvActionCode.Focusing = null;
            this.cdvActionCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActionCode.Index = 0;
            this.cdvActionCode.IsViewBtnImage = false;
            this.cdvActionCode.Location = new System.Drawing.Point(118, 64);
            this.cdvActionCode.MaxLength = 10;
            this.cdvActionCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActionCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActionCode.Name = "cdvActionCode";
            this.cdvActionCode.ReadOnly = false;
            this.cdvActionCode.SearchSubItemIndex = 0;
            this.cdvActionCode.SelectedDescIndex = -1;
            this.cdvActionCode.SelectedSubItemIndex = -1;
            this.cdvActionCode.SelectionStart = 0;
            this.cdvActionCode.Size = new System.Drawing.Size(200, 20);
            this.cdvActionCode.SmallImageList = null;
            this.cdvActionCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActionCode.TabIndex = 5;
            this.cdvActionCode.TextBoxToolTipText = "";
            this.cdvActionCode.TextBoxWidth = 200;
            this.cdvActionCode.VisibleButton = true;
            this.cdvActionCode.VisibleColumnHeader = false;
            this.cdvActionCode.VisibleDescription = false;
            this.cdvActionCode.ButtonPress += new System.EventHandler(this.cdvActionCode_ButtonPress);
            // 
            // lblActionCode
            // 
            this.lblActionCode.AutoSize = true;
            this.lblActionCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActionCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionCode.Location = new System.Drawing.Point(12, 67);
            this.lblActionCode.Name = "lblActionCode";
            this.lblActionCode.Size = new System.Drawing.Size(76, 13);
            this.lblActionCode.TabIndex = 4;
            this.lblActionCode.Text = "Action Code";
            this.lblActionCode.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvResultCode
            // 
            this.cdvResultCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResultCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResultCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResultCode.BtnToolTipText = "";
            this.cdvResultCode.DescText = "";
            this.cdvResultCode.DisplaySubItemIndex = -1;
            this.cdvResultCode.DisplayText = "";
            this.cdvResultCode.Focusing = null;
            this.cdvResultCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResultCode.Index = 0;
            this.cdvResultCode.IsViewBtnImage = false;
            this.cdvResultCode.Location = new System.Drawing.Point(118, 40);
            this.cdvResultCode.MaxLength = 10;
            this.cdvResultCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResultCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResultCode.Name = "cdvResultCode";
            this.cdvResultCode.ReadOnly = false;
            this.cdvResultCode.SearchSubItemIndex = 0;
            this.cdvResultCode.SelectedDescIndex = -1;
            this.cdvResultCode.SelectedSubItemIndex = -1;
            this.cdvResultCode.SelectionStart = 0;
            this.cdvResultCode.Size = new System.Drawing.Size(200, 20);
            this.cdvResultCode.SmallImageList = null;
            this.cdvResultCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResultCode.TabIndex = 3;
            this.cdvResultCode.TextBoxToolTipText = "";
            this.cdvResultCode.TextBoxWidth = 200;
            this.cdvResultCode.VisibleButton = true;
            this.cdvResultCode.VisibleColumnHeader = false;
            this.cdvResultCode.VisibleDescription = false;
            this.cdvResultCode.ButtonPress += new System.EventHandler(this.cdvResultCode_ButtonPress);
            // 
            // lblResultCode
            // 
            this.lblResultCode.AutoSize = true;
            this.lblResultCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResultCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultCode.Location = new System.Drawing.Point(12, 43);
            this.lblResultCode.Name = "lblResultCode";
            this.lblResultCode.Size = new System.Drawing.Size(76, 13);
            this.lblResultCode.TabIndex = 2;
            this.lblResultCode.Text = "Result Code";
            this.lblResultCode.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvCauseFlow
            // 
            this.cdvCauseFlow.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseFlow.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseFlow.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseFlow.BtnToolTipText = "";
            this.cdvCauseFlow.DescText = "";
            this.cdvCauseFlow.DisplaySubItemIndex = -1;
            this.cdvCauseFlow.DisplayText = "";
            this.cdvCauseFlow.Focusing = null;
            this.cdvCauseFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseFlow.Index = 0;
            this.cdvCauseFlow.IsViewBtnImage = false;
            this.cdvCauseFlow.Location = new System.Drawing.Point(458, 16);
            this.cdvCauseFlow.MaxLength = 20;
            this.cdvCauseFlow.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseFlow.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseFlow.Name = "cdvCauseFlow";
            this.cdvCauseFlow.ReadOnly = false;
            this.cdvCauseFlow.SearchSubItemIndex = 0;
            this.cdvCauseFlow.SelectedDescIndex = -1;
            this.cdvCauseFlow.SelectedSubItemIndex = -1;
            this.cdvCauseFlow.SelectionStart = 0;
            this.cdvCauseFlow.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseFlow.SmallImageList = null;
            this.cdvCauseFlow.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseFlow.TabIndex = 9;
            this.cdvCauseFlow.TextBoxToolTipText = "";
            this.cdvCauseFlow.TextBoxWidth = 200;
            this.cdvCauseFlow.VisibleButton = true;
            this.cdvCauseFlow.VisibleColumnHeader = false;
            this.cdvCauseFlow.VisibleDescription = false;
            this.cdvCauseFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCauseFlow_SelectedItemChanged);
            this.cdvCauseFlow.ButtonPress += new System.EventHandler(this.cdvCauseFlow_ButtonPress);
            // 
            // lblCauseFlow
            // 
            this.lblCauseFlow.AutoSize = true;
            this.lblCauseFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseFlow.Location = new System.Drawing.Point(352, 19);
            this.lblCauseFlow.Name = "lblCauseFlow";
            this.lblCauseFlow.Size = new System.Drawing.Size(62, 13);
            this.lblCauseFlow.TabIndex = 8;
            this.lblCauseFlow.Text = "Cause Flow";
            this.lblCauseFlow.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvCauseRes
            // 
            this.cdvCauseRes.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseRes.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseRes.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseRes.BtnToolTipText = "";
            this.cdvCauseRes.DescText = "";
            this.cdvCauseRes.DisplaySubItemIndex = -1;
            this.cdvCauseRes.DisplayText = "";
            this.cdvCauseRes.Focusing = null;
            this.cdvCauseRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseRes.Index = 0;
            this.cdvCauseRes.IsViewBtnImage = false;
            this.cdvCauseRes.Location = new System.Drawing.Point(458, 64);
            this.cdvCauseRes.MaxLength = 20;
            this.cdvCauseRes.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseRes.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseRes.Name = "cdvCauseRes";
            this.cdvCauseRes.ReadOnly = false;
            this.cdvCauseRes.SearchSubItemIndex = 0;
            this.cdvCauseRes.SelectedDescIndex = -1;
            this.cdvCauseRes.SelectedSubItemIndex = -1;
            this.cdvCauseRes.SelectionStart = 0;
            this.cdvCauseRes.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseRes.SmallImageList = null;
            this.cdvCauseRes.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseRes.TabIndex = 13;
            this.cdvCauseRes.TextBoxToolTipText = "";
            this.cdvCauseRes.TextBoxWidth = 200;
            this.cdvCauseRes.VisibleButton = true;
            this.cdvCauseRes.VisibleColumnHeader = false;
            this.cdvCauseRes.VisibleDescription = false;
            this.cdvCauseRes.ButtonPress += new System.EventHandler(this.cdvCauseRes_ButtonPress);
            // 
            // cdvCauseOper
            // 
            this.cdvCauseOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCauseOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCauseOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCauseOper.BtnToolTipText = "";
            this.cdvCauseOper.DescText = "";
            this.cdvCauseOper.DisplaySubItemIndex = -1;
            this.cdvCauseOper.DisplayText = "";
            this.cdvCauseOper.Focusing = null;
            this.cdvCauseOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCauseOper.Index = 0;
            this.cdvCauseOper.IsViewBtnImage = false;
            this.cdvCauseOper.Location = new System.Drawing.Point(458, 40);
            this.cdvCauseOper.MaxLength = 10;
            this.cdvCauseOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCauseOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCauseOper.Name = "cdvCauseOper";
            this.cdvCauseOper.ReadOnly = false;
            this.cdvCauseOper.SearchSubItemIndex = 0;
            this.cdvCauseOper.SelectedDescIndex = -1;
            this.cdvCauseOper.SelectedSubItemIndex = -1;
            this.cdvCauseOper.SelectionStart = 0;
            this.cdvCauseOper.Size = new System.Drawing.Size(200, 20);
            this.cdvCauseOper.SmallImageList = null;
            this.cdvCauseOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCauseOper.TabIndex = 11;
            this.cdvCauseOper.TextBoxToolTipText = "";
            this.cdvCauseOper.TextBoxWidth = 200;
            this.cdvCauseOper.VisibleButton = true;
            this.cdvCauseOper.VisibleColumnHeader = false;
            this.cdvCauseOper.VisibleDescription = false;
            this.cdvCauseOper.ButtonPress += new System.EventHandler(this.cdvCauseOper_ButtonPress);
            // 
            // lblCauseRes
            // 
            this.lblCauseRes.AutoSize = true;
            this.lblCauseRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseRes.Location = new System.Drawing.Point(352, 67);
            this.lblCauseRes.Name = "lblCauseRes";
            this.lblCauseRes.Size = new System.Drawing.Size(86, 13);
            this.lblCauseRes.TabIndex = 12;
            this.lblCauseRes.Text = "Cause Resource";
            this.lblCauseRes.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblCauseOper
            // 
            this.lblCauseOper.AutoSize = true;
            this.lblCauseOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseOper.Location = new System.Drawing.Point(352, 43);
            this.lblCauseOper.Name = "lblCauseOper";
            this.lblCauseOper.Size = new System.Drawing.Size(86, 13);
            this.lblCauseOper.TabIndex = 10;
            this.lblCauseOper.Text = "Cause Operation";
            this.lblCauseOper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvRepairCode
            // 
            this.cdvRepairCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRepairCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRepairCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRepairCode.BtnToolTipText = "";
            this.cdvRepairCode.DescText = "";
            this.cdvRepairCode.DisplaySubItemIndex = -1;
            this.cdvRepairCode.DisplayText = "";
            this.cdvRepairCode.Focusing = null;
            this.cdvRepairCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRepairCode.Index = 0;
            this.cdvRepairCode.IsViewBtnImage = false;
            this.cdvRepairCode.Location = new System.Drawing.Point(118, 16);
            this.cdvRepairCode.MaxLength = 10;
            this.cdvRepairCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRepairCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRepairCode.Name = "cdvRepairCode";
            this.cdvRepairCode.ReadOnly = false;
            this.cdvRepairCode.SearchSubItemIndex = 0;
            this.cdvRepairCode.SelectedDescIndex = -1;
            this.cdvRepairCode.SelectedSubItemIndex = -1;
            this.cdvRepairCode.SelectionStart = 0;
            this.cdvRepairCode.Size = new System.Drawing.Size(200, 20);
            this.cdvRepairCode.SmallImageList = null;
            this.cdvRepairCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRepairCode.TabIndex = 1;
            this.cdvRepairCode.TextBoxToolTipText = "";
            this.cdvRepairCode.TextBoxWidth = 200;
            this.cdvRepairCode.VisibleButton = true;
            this.cdvRepairCode.VisibleColumnHeader = false;
            this.cdvRepairCode.VisibleDescription = false;
            this.cdvRepairCode.ButtonPress += new System.EventHandler(this.cdvRepairCode_ButtonPress);
            // 
            // lblRepairCode
            // 
            this.lblRepairCode.AutoSize = true;
            this.lblRepairCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRepairCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepairCode.Location = new System.Drawing.Point(12, 19);
            this.lblRepairCode.Name = "lblRepairCode";
            this.lblRepairCode.Size = new System.Drawing.Size(77, 13);
            this.lblRepairCode.TabIndex = 0;
            this.lblRepairCode.Text = "Repair Code";
            this.lblRepairCode.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtChkUser2
            // 
            this.txtChkUser2.Location = new System.Drawing.Point(458, 112);
            this.txtChkUser2.MaxLength = 20;
            this.txtChkUser2.Name = "txtChkUser2";
            this.txtChkUser2.Size = new System.Drawing.Size(200, 20);
            this.txtChkUser2.TabIndex = 17;
            // 
            // txtChkUser1
            // 
            this.txtChkUser1.Location = new System.Drawing.Point(458, 88);
            this.txtChkUser1.MaxLength = 20;
            this.txtChkUser1.Name = "txtChkUser1";
            this.txtChkUser1.Size = new System.Drawing.Size(200, 20);
            this.txtChkUser1.TabIndex = 15;
            // 
            // lblUser1
            // 
            this.lblUser1.AutoSize = true;
            this.lblUser1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser1.Location = new System.Drawing.Point(352, 91);
            this.lblUser1.Name = "lblUser1";
            this.lblUser1.Size = new System.Drawing.Size(86, 13);
            this.lblUser1.TabIndex = 14;
            this.lblUser1.Text = "Check User ID 1";
            this.lblUser1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblUser2
            // 
            this.lblUser2.AutoSize = true;
            this.lblUser2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser2.Location = new System.Drawing.Point(352, 115);
            this.lblUser2.Name = "lblUser2";
            this.lblUser2.Size = new System.Drawing.Size(86, 13);
            this.lblUser2.TabIndex = 16;
            this.lblUser2.Text = "Check User ID 2";
            this.lblUser2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbpEndCMF
            // 
            this.tbpEndCMF.Controls.Add(this.grpEndCMF);
            this.tbpEndCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpEndCMF.Name = "tbpEndCMF";
            this.tbpEndCMF.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tbpEndCMF.Size = new System.Drawing.Size(728, 422);
            this.tbpEndCMF.TabIndex = 2;
            this.tbpEndCMF.Text = "End Customized Field";
            // 
            // grpEndCMF
            // 
            this.grpEndCMF.Controls.Add(this.lblEndCMF20);
            this.grpEndCMF.Controls.Add(this.lblEndCMF19);
            this.grpEndCMF.Controls.Add(this.lblEndCMF18);
            this.grpEndCMF.Controls.Add(this.lblEndCMF17);
            this.grpEndCMF.Controls.Add(this.lblEndCMF16);
            this.grpEndCMF.Controls.Add(this.lblEndCMF15);
            this.grpEndCMF.Controls.Add(this.lblEndCMF14);
            this.grpEndCMF.Controls.Add(this.lblEndCMF13);
            this.grpEndCMF.Controls.Add(this.lblEndCMF12);
            this.grpEndCMF.Controls.Add(this.lblEndCMF11);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF19);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF18);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF17);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF16);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF15);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF14);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF13);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF12);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF20);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF11);
            this.grpEndCMF.Controls.Add(this.lblEndCMF10);
            this.grpEndCMF.Controls.Add(this.lblEndCMF9);
            this.grpEndCMF.Controls.Add(this.lblEndCMF8);
            this.grpEndCMF.Controls.Add(this.lblEndCMF7);
            this.grpEndCMF.Controls.Add(this.lblEndCMF6);
            this.grpEndCMF.Controls.Add(this.lblEndCMF5);
            this.grpEndCMF.Controls.Add(this.lblEndCMF4);
            this.grpEndCMF.Controls.Add(this.lblEndCMF3);
            this.grpEndCMF.Controls.Add(this.lblEndCMF2);
            this.grpEndCMF.Controls.Add(this.lblEndCMF1);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF9);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF8);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF7);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF6);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF5);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF4);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF3);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF2);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF10);
            this.grpEndCMF.Controls.Add(this.cdvEndCMF1);
            this.grpEndCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEndCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpEndCMF.Location = new System.Drawing.Point(3, 3);
            this.grpEndCMF.Name = "grpEndCMF";
            this.grpEndCMF.Size = new System.Drawing.Size(722, 419);
            this.grpEndCMF.TabIndex = 50;
            this.grpEndCMF.TabStop = false;
            // 
            // lblEndCMF20
            // 
            this.lblEndCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF20.Location = new System.Drawing.Point(381, 232);
            this.lblEndCMF20.Name = "lblEndCMF20";
            this.lblEndCMF20.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF20.TabIndex = 38;
            this.lblEndCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF19
            // 
            this.lblEndCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF19.Location = new System.Drawing.Point(381, 208);
            this.lblEndCMF19.Name = "lblEndCMF19";
            this.lblEndCMF19.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF19.TabIndex = 36;
            this.lblEndCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF18
            // 
            this.lblEndCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF18.Location = new System.Drawing.Point(381, 184);
            this.lblEndCMF18.Name = "lblEndCMF18";
            this.lblEndCMF18.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF18.TabIndex = 34;
            this.lblEndCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF17
            // 
            this.lblEndCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF17.Location = new System.Drawing.Point(381, 160);
            this.lblEndCMF17.Name = "lblEndCMF17";
            this.lblEndCMF17.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF17.TabIndex = 32;
            this.lblEndCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF16
            // 
            this.lblEndCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF16.Location = new System.Drawing.Point(381, 136);
            this.lblEndCMF16.Name = "lblEndCMF16";
            this.lblEndCMF16.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF16.TabIndex = 30;
            this.lblEndCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF15
            // 
            this.lblEndCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF15.Location = new System.Drawing.Point(381, 112);
            this.lblEndCMF15.Name = "lblEndCMF15";
            this.lblEndCMF15.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF15.TabIndex = 28;
            this.lblEndCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF14
            // 
            this.lblEndCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF14.Location = new System.Drawing.Point(381, 88);
            this.lblEndCMF14.Name = "lblEndCMF14";
            this.lblEndCMF14.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF14.TabIndex = 26;
            this.lblEndCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF13
            // 
            this.lblEndCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF13.Location = new System.Drawing.Point(381, 64);
            this.lblEndCMF13.Name = "lblEndCMF13";
            this.lblEndCMF13.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF13.TabIndex = 24;
            this.lblEndCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF12
            // 
            this.lblEndCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF12.Location = new System.Drawing.Point(381, 40);
            this.lblEndCMF12.Name = "lblEndCMF12";
            this.lblEndCMF12.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF12.TabIndex = 22;
            this.lblEndCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF11
            // 
            this.lblEndCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF11.Location = new System.Drawing.Point(381, 16);
            this.lblEndCMF11.Name = "lblEndCMF11";
            this.lblEndCMF11.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF11.TabIndex = 20;
            this.lblEndCMF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvEndCMF19
            // 
            this.cdvEndCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF19.BtnToolTipText = "";
            this.cdvEndCMF19.DescText = "";
            this.cdvEndCMF19.DisplaySubItemIndex = -1;
            this.cdvEndCMF19.DisplayText = "";
            this.cdvEndCMF19.Focusing = null;
            this.cdvEndCMF19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF19.Index = 0;
            this.cdvEndCMF19.IsViewBtnImage = false;
            this.cdvEndCMF19.Location = new System.Drawing.Point(536, 205);
            this.cdvEndCMF19.MaxLength = 30;
            this.cdvEndCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF19.Name = "cdvEndCMF19";
            this.cdvEndCMF19.ReadOnly = false;
            this.cdvEndCMF19.SearchSubItemIndex = 0;
            this.cdvEndCMF19.SelectedDescIndex = -1;
            this.cdvEndCMF19.SelectedSubItemIndex = -1;
            this.cdvEndCMF19.SelectionStart = 0;
            this.cdvEndCMF19.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF19.SmallImageList = null;
            this.cdvEndCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF19.TabIndex = 37;
            this.cdvEndCMF19.TextBoxToolTipText = "";
            this.cdvEndCMF19.TextBoxWidth = 180;
            this.cdvEndCMF19.VisibleButton = true;
            this.cdvEndCMF19.VisibleColumnHeader = false;
            this.cdvEndCMF19.VisibleDescription = false;
            // 
            // cdvEndCMF18
            // 
            this.cdvEndCMF18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF18.BtnToolTipText = "";
            this.cdvEndCMF18.DescText = "";
            this.cdvEndCMF18.DisplaySubItemIndex = -1;
            this.cdvEndCMF18.DisplayText = "";
            this.cdvEndCMF18.Focusing = null;
            this.cdvEndCMF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF18.Index = 0;
            this.cdvEndCMF18.IsViewBtnImage = false;
            this.cdvEndCMF18.Location = new System.Drawing.Point(536, 181);
            this.cdvEndCMF18.MaxLength = 30;
            this.cdvEndCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF18.Name = "cdvEndCMF18";
            this.cdvEndCMF18.ReadOnly = false;
            this.cdvEndCMF18.SearchSubItemIndex = 0;
            this.cdvEndCMF18.SelectedDescIndex = -1;
            this.cdvEndCMF18.SelectedSubItemIndex = -1;
            this.cdvEndCMF18.SelectionStart = 0;
            this.cdvEndCMF18.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF18.SmallImageList = null;
            this.cdvEndCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF18.TabIndex = 35;
            this.cdvEndCMF18.TextBoxToolTipText = "";
            this.cdvEndCMF18.TextBoxWidth = 180;
            this.cdvEndCMF18.VisibleButton = true;
            this.cdvEndCMF18.VisibleColumnHeader = false;
            this.cdvEndCMF18.VisibleDescription = false;
            // 
            // cdvEndCMF17
            // 
            this.cdvEndCMF17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF17.BtnToolTipText = "";
            this.cdvEndCMF17.DescText = "";
            this.cdvEndCMF17.DisplaySubItemIndex = -1;
            this.cdvEndCMF17.DisplayText = "";
            this.cdvEndCMF17.Focusing = null;
            this.cdvEndCMF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF17.Index = 0;
            this.cdvEndCMF17.IsViewBtnImage = false;
            this.cdvEndCMF17.Location = new System.Drawing.Point(536, 157);
            this.cdvEndCMF17.MaxLength = 30;
            this.cdvEndCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF17.Name = "cdvEndCMF17";
            this.cdvEndCMF17.ReadOnly = false;
            this.cdvEndCMF17.SearchSubItemIndex = 0;
            this.cdvEndCMF17.SelectedDescIndex = -1;
            this.cdvEndCMF17.SelectedSubItemIndex = -1;
            this.cdvEndCMF17.SelectionStart = 0;
            this.cdvEndCMF17.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF17.SmallImageList = null;
            this.cdvEndCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF17.TabIndex = 33;
            this.cdvEndCMF17.TextBoxToolTipText = "";
            this.cdvEndCMF17.TextBoxWidth = 180;
            this.cdvEndCMF17.VisibleButton = true;
            this.cdvEndCMF17.VisibleColumnHeader = false;
            this.cdvEndCMF17.VisibleDescription = false;
            // 
            // cdvEndCMF16
            // 
            this.cdvEndCMF16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF16.BtnToolTipText = "";
            this.cdvEndCMF16.DescText = "";
            this.cdvEndCMF16.DisplaySubItemIndex = -1;
            this.cdvEndCMF16.DisplayText = "";
            this.cdvEndCMF16.Focusing = null;
            this.cdvEndCMF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF16.Index = 0;
            this.cdvEndCMF16.IsViewBtnImage = false;
            this.cdvEndCMF16.Location = new System.Drawing.Point(536, 133);
            this.cdvEndCMF16.MaxLength = 30;
            this.cdvEndCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF16.Name = "cdvEndCMF16";
            this.cdvEndCMF16.ReadOnly = false;
            this.cdvEndCMF16.SearchSubItemIndex = 0;
            this.cdvEndCMF16.SelectedDescIndex = -1;
            this.cdvEndCMF16.SelectedSubItemIndex = -1;
            this.cdvEndCMF16.SelectionStart = 0;
            this.cdvEndCMF16.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF16.SmallImageList = null;
            this.cdvEndCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF16.TabIndex = 31;
            this.cdvEndCMF16.TextBoxToolTipText = "";
            this.cdvEndCMF16.TextBoxWidth = 180;
            this.cdvEndCMF16.VisibleButton = true;
            this.cdvEndCMF16.VisibleColumnHeader = false;
            this.cdvEndCMF16.VisibleDescription = false;
            // 
            // cdvEndCMF15
            // 
            this.cdvEndCMF15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF15.BtnToolTipText = "";
            this.cdvEndCMF15.DescText = "";
            this.cdvEndCMF15.DisplaySubItemIndex = -1;
            this.cdvEndCMF15.DisplayText = "";
            this.cdvEndCMF15.Focusing = null;
            this.cdvEndCMF15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF15.Index = 0;
            this.cdvEndCMF15.IsViewBtnImage = false;
            this.cdvEndCMF15.Location = new System.Drawing.Point(536, 109);
            this.cdvEndCMF15.MaxLength = 30;
            this.cdvEndCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF15.Name = "cdvEndCMF15";
            this.cdvEndCMF15.ReadOnly = false;
            this.cdvEndCMF15.SearchSubItemIndex = 0;
            this.cdvEndCMF15.SelectedDescIndex = -1;
            this.cdvEndCMF15.SelectedSubItemIndex = -1;
            this.cdvEndCMF15.SelectionStart = 0;
            this.cdvEndCMF15.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF15.SmallImageList = null;
            this.cdvEndCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF15.TabIndex = 29;
            this.cdvEndCMF15.TextBoxToolTipText = "";
            this.cdvEndCMF15.TextBoxWidth = 180;
            this.cdvEndCMF15.VisibleButton = true;
            this.cdvEndCMF15.VisibleColumnHeader = false;
            this.cdvEndCMF15.VisibleDescription = false;
            // 
            // cdvEndCMF14
            // 
            this.cdvEndCMF14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF14.BtnToolTipText = "";
            this.cdvEndCMF14.DescText = "";
            this.cdvEndCMF14.DisplaySubItemIndex = -1;
            this.cdvEndCMF14.DisplayText = "";
            this.cdvEndCMF14.Focusing = null;
            this.cdvEndCMF14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF14.Index = 0;
            this.cdvEndCMF14.IsViewBtnImage = false;
            this.cdvEndCMF14.Location = new System.Drawing.Point(536, 85);
            this.cdvEndCMF14.MaxLength = 30;
            this.cdvEndCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF14.Name = "cdvEndCMF14";
            this.cdvEndCMF14.ReadOnly = false;
            this.cdvEndCMF14.SearchSubItemIndex = 0;
            this.cdvEndCMF14.SelectedDescIndex = -1;
            this.cdvEndCMF14.SelectedSubItemIndex = -1;
            this.cdvEndCMF14.SelectionStart = 0;
            this.cdvEndCMF14.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF14.SmallImageList = null;
            this.cdvEndCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF14.TabIndex = 27;
            this.cdvEndCMF14.TextBoxToolTipText = "";
            this.cdvEndCMF14.TextBoxWidth = 180;
            this.cdvEndCMF14.VisibleButton = true;
            this.cdvEndCMF14.VisibleColumnHeader = false;
            this.cdvEndCMF14.VisibleDescription = false;
            // 
            // cdvEndCMF13
            // 
            this.cdvEndCMF13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF13.BtnToolTipText = "";
            this.cdvEndCMF13.DescText = "";
            this.cdvEndCMF13.DisplaySubItemIndex = -1;
            this.cdvEndCMF13.DisplayText = "";
            this.cdvEndCMF13.Focusing = null;
            this.cdvEndCMF13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF13.Index = 0;
            this.cdvEndCMF13.IsViewBtnImage = false;
            this.cdvEndCMF13.Location = new System.Drawing.Point(536, 61);
            this.cdvEndCMF13.MaxLength = 30;
            this.cdvEndCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF13.Name = "cdvEndCMF13";
            this.cdvEndCMF13.ReadOnly = false;
            this.cdvEndCMF13.SearchSubItemIndex = 0;
            this.cdvEndCMF13.SelectedDescIndex = -1;
            this.cdvEndCMF13.SelectedSubItemIndex = -1;
            this.cdvEndCMF13.SelectionStart = 0;
            this.cdvEndCMF13.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF13.SmallImageList = null;
            this.cdvEndCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF13.TabIndex = 25;
            this.cdvEndCMF13.TextBoxToolTipText = "";
            this.cdvEndCMF13.TextBoxWidth = 180;
            this.cdvEndCMF13.VisibleButton = true;
            this.cdvEndCMF13.VisibleColumnHeader = false;
            this.cdvEndCMF13.VisibleDescription = false;
            // 
            // cdvEndCMF12
            // 
            this.cdvEndCMF12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF12.BtnToolTipText = "";
            this.cdvEndCMF12.DescText = "";
            this.cdvEndCMF12.DisplaySubItemIndex = -1;
            this.cdvEndCMF12.DisplayText = "";
            this.cdvEndCMF12.Focusing = null;
            this.cdvEndCMF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF12.Index = 0;
            this.cdvEndCMF12.IsViewBtnImage = false;
            this.cdvEndCMF12.Location = new System.Drawing.Point(536, 37);
            this.cdvEndCMF12.MaxLength = 30;
            this.cdvEndCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF12.Name = "cdvEndCMF12";
            this.cdvEndCMF12.ReadOnly = false;
            this.cdvEndCMF12.SearchSubItemIndex = 0;
            this.cdvEndCMF12.SelectedDescIndex = -1;
            this.cdvEndCMF12.SelectedSubItemIndex = -1;
            this.cdvEndCMF12.SelectionStart = 0;
            this.cdvEndCMF12.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF12.SmallImageList = null;
            this.cdvEndCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF12.TabIndex = 23;
            this.cdvEndCMF12.TextBoxToolTipText = "";
            this.cdvEndCMF12.TextBoxWidth = 180;
            this.cdvEndCMF12.VisibleButton = true;
            this.cdvEndCMF12.VisibleColumnHeader = false;
            this.cdvEndCMF12.VisibleDescription = false;
            // 
            // cdvEndCMF20
            // 
            this.cdvEndCMF20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF20.BtnToolTipText = "";
            this.cdvEndCMF20.DescText = "";
            this.cdvEndCMF20.DisplaySubItemIndex = -1;
            this.cdvEndCMF20.DisplayText = "";
            this.cdvEndCMF20.Focusing = null;
            this.cdvEndCMF20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF20.Index = 0;
            this.cdvEndCMF20.IsViewBtnImage = false;
            this.cdvEndCMF20.Location = new System.Drawing.Point(536, 229);
            this.cdvEndCMF20.MaxLength = 30;
            this.cdvEndCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF20.Name = "cdvEndCMF20";
            this.cdvEndCMF20.ReadOnly = false;
            this.cdvEndCMF20.SearchSubItemIndex = 0;
            this.cdvEndCMF20.SelectedDescIndex = -1;
            this.cdvEndCMF20.SelectedSubItemIndex = -1;
            this.cdvEndCMF20.SelectionStart = 0;
            this.cdvEndCMF20.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF20.SmallImageList = null;
            this.cdvEndCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF20.TabIndex = 39;
            this.cdvEndCMF20.TextBoxToolTipText = "";
            this.cdvEndCMF20.TextBoxWidth = 180;
            this.cdvEndCMF20.VisibleButton = true;
            this.cdvEndCMF20.VisibleColumnHeader = false;
            this.cdvEndCMF20.VisibleDescription = false;
            // 
            // cdvEndCMF11
            // 
            this.cdvEndCMF11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF11.BtnToolTipText = "";
            this.cdvEndCMF11.DescText = "";
            this.cdvEndCMF11.DisplaySubItemIndex = -1;
            this.cdvEndCMF11.DisplayText = "";
            this.cdvEndCMF11.Focusing = null;
            this.cdvEndCMF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF11.Index = 0;
            this.cdvEndCMF11.IsViewBtnImage = false;
            this.cdvEndCMF11.Location = new System.Drawing.Point(536, 13);
            this.cdvEndCMF11.MaxLength = 30;
            this.cdvEndCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF11.Name = "cdvEndCMF11";
            this.cdvEndCMF11.ReadOnly = false;
            this.cdvEndCMF11.SearchSubItemIndex = 0;
            this.cdvEndCMF11.SelectedDescIndex = -1;
            this.cdvEndCMF11.SelectedSubItemIndex = -1;
            this.cdvEndCMF11.SelectionStart = 0;
            this.cdvEndCMF11.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF11.SmallImageList = null;
            this.cdvEndCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF11.TabIndex = 21;
            this.cdvEndCMF11.TextBoxToolTipText = "";
            this.cdvEndCMF11.TextBoxWidth = 180;
            this.cdvEndCMF11.VisibleButton = true;
            this.cdvEndCMF11.VisibleColumnHeader = false;
            this.cdvEndCMF11.VisibleDescription = false;
            // 
            // lblEndCMF10
            // 
            this.lblEndCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF10.Location = new System.Drawing.Point(8, 232);
            this.lblEndCMF10.Name = "lblEndCMF10";
            this.lblEndCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF10.TabIndex = 18;
            this.lblEndCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF9
            // 
            this.lblEndCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF9.Location = new System.Drawing.Point(8, 208);
            this.lblEndCMF9.Name = "lblEndCMF9";
            this.lblEndCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF9.TabIndex = 16;
            this.lblEndCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF8
            // 
            this.lblEndCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF8.Location = new System.Drawing.Point(8, 184);
            this.lblEndCMF8.Name = "lblEndCMF8";
            this.lblEndCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF8.TabIndex = 14;
            this.lblEndCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF7
            // 
            this.lblEndCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF7.Location = new System.Drawing.Point(8, 160);
            this.lblEndCMF7.Name = "lblEndCMF7";
            this.lblEndCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF7.TabIndex = 12;
            this.lblEndCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF6
            // 
            this.lblEndCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF6.Location = new System.Drawing.Point(8, 136);
            this.lblEndCMF6.Name = "lblEndCMF6";
            this.lblEndCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF6.TabIndex = 10;
            this.lblEndCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF5
            // 
            this.lblEndCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF5.Location = new System.Drawing.Point(8, 112);
            this.lblEndCMF5.Name = "lblEndCMF5";
            this.lblEndCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF5.TabIndex = 8;
            this.lblEndCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF4
            // 
            this.lblEndCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF4.Location = new System.Drawing.Point(8, 88);
            this.lblEndCMF4.Name = "lblEndCMF4";
            this.lblEndCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF4.TabIndex = 6;
            this.lblEndCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF3
            // 
            this.lblEndCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF3.Location = new System.Drawing.Point(8, 64);
            this.lblEndCMF3.Name = "lblEndCMF3";
            this.lblEndCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF3.TabIndex = 4;
            this.lblEndCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF2
            // 
            this.lblEndCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF2.Location = new System.Drawing.Point(8, 40);
            this.lblEndCMF2.Name = "lblEndCMF2";
            this.lblEndCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF2.TabIndex = 2;
            this.lblEndCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEndCMF1
            // 
            this.lblEndCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEndCMF1.Location = new System.Drawing.Point(8, 16);
            this.lblEndCMF1.Name = "lblEndCMF1";
            this.lblEndCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblEndCMF1.TabIndex = 0;
            this.lblEndCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvEndCMF9
            // 
            this.cdvEndCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF9.BtnToolTipText = "";
            this.cdvEndCMF9.DescText = "";
            this.cdvEndCMF9.DisplaySubItemIndex = -1;
            this.cdvEndCMF9.DisplayText = "";
            this.cdvEndCMF9.Focusing = null;
            this.cdvEndCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF9.Index = 0;
            this.cdvEndCMF9.IsViewBtnImage = false;
            this.cdvEndCMF9.Location = new System.Drawing.Point(163, 205);
            this.cdvEndCMF9.MaxLength = 30;
            this.cdvEndCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF9.Name = "cdvEndCMF9";
            this.cdvEndCMF9.ReadOnly = false;
            this.cdvEndCMF9.SearchSubItemIndex = 0;
            this.cdvEndCMF9.SelectedDescIndex = -1;
            this.cdvEndCMF9.SelectedSubItemIndex = -1;
            this.cdvEndCMF9.SelectionStart = 0;
            this.cdvEndCMF9.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF9.SmallImageList = null;
            this.cdvEndCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF9.TabIndex = 17;
            this.cdvEndCMF9.TextBoxToolTipText = "";
            this.cdvEndCMF9.TextBoxWidth = 180;
            this.cdvEndCMF9.VisibleButton = true;
            this.cdvEndCMF9.VisibleColumnHeader = false;
            this.cdvEndCMF9.VisibleDescription = false;
            // 
            // cdvEndCMF8
            // 
            this.cdvEndCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF8.BtnToolTipText = "";
            this.cdvEndCMF8.DescText = "";
            this.cdvEndCMF8.DisplaySubItemIndex = -1;
            this.cdvEndCMF8.DisplayText = "";
            this.cdvEndCMF8.Focusing = null;
            this.cdvEndCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF8.Index = 0;
            this.cdvEndCMF8.IsViewBtnImage = false;
            this.cdvEndCMF8.Location = new System.Drawing.Point(163, 181);
            this.cdvEndCMF8.MaxLength = 30;
            this.cdvEndCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF8.Name = "cdvEndCMF8";
            this.cdvEndCMF8.ReadOnly = false;
            this.cdvEndCMF8.SearchSubItemIndex = 0;
            this.cdvEndCMF8.SelectedDescIndex = -1;
            this.cdvEndCMF8.SelectedSubItemIndex = -1;
            this.cdvEndCMF8.SelectionStart = 0;
            this.cdvEndCMF8.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF8.SmallImageList = null;
            this.cdvEndCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF8.TabIndex = 15;
            this.cdvEndCMF8.TextBoxToolTipText = "";
            this.cdvEndCMF8.TextBoxWidth = 180;
            this.cdvEndCMF8.VisibleButton = true;
            this.cdvEndCMF8.VisibleColumnHeader = false;
            this.cdvEndCMF8.VisibleDescription = false;
            // 
            // cdvEndCMF7
            // 
            this.cdvEndCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF7.BtnToolTipText = "";
            this.cdvEndCMF7.DescText = "";
            this.cdvEndCMF7.DisplaySubItemIndex = -1;
            this.cdvEndCMF7.DisplayText = "";
            this.cdvEndCMF7.Focusing = null;
            this.cdvEndCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF7.Index = 0;
            this.cdvEndCMF7.IsViewBtnImage = false;
            this.cdvEndCMF7.Location = new System.Drawing.Point(163, 157);
            this.cdvEndCMF7.MaxLength = 30;
            this.cdvEndCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF7.Name = "cdvEndCMF7";
            this.cdvEndCMF7.ReadOnly = false;
            this.cdvEndCMF7.SearchSubItemIndex = 0;
            this.cdvEndCMF7.SelectedDescIndex = -1;
            this.cdvEndCMF7.SelectedSubItemIndex = -1;
            this.cdvEndCMF7.SelectionStart = 0;
            this.cdvEndCMF7.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF7.SmallImageList = null;
            this.cdvEndCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF7.TabIndex = 13;
            this.cdvEndCMF7.TextBoxToolTipText = "";
            this.cdvEndCMF7.TextBoxWidth = 180;
            this.cdvEndCMF7.VisibleButton = true;
            this.cdvEndCMF7.VisibleColumnHeader = false;
            this.cdvEndCMF7.VisibleDescription = false;
            // 
            // cdvEndCMF6
            // 
            this.cdvEndCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF6.BtnToolTipText = "";
            this.cdvEndCMF6.DescText = "";
            this.cdvEndCMF6.DisplaySubItemIndex = -1;
            this.cdvEndCMF6.DisplayText = "";
            this.cdvEndCMF6.Focusing = null;
            this.cdvEndCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF6.Index = 0;
            this.cdvEndCMF6.IsViewBtnImage = false;
            this.cdvEndCMF6.Location = new System.Drawing.Point(163, 133);
            this.cdvEndCMF6.MaxLength = 30;
            this.cdvEndCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF6.Name = "cdvEndCMF6";
            this.cdvEndCMF6.ReadOnly = false;
            this.cdvEndCMF6.SearchSubItemIndex = 0;
            this.cdvEndCMF6.SelectedDescIndex = -1;
            this.cdvEndCMF6.SelectedSubItemIndex = -1;
            this.cdvEndCMF6.SelectionStart = 0;
            this.cdvEndCMF6.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF6.SmallImageList = null;
            this.cdvEndCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF6.TabIndex = 11;
            this.cdvEndCMF6.TextBoxToolTipText = "";
            this.cdvEndCMF6.TextBoxWidth = 180;
            this.cdvEndCMF6.VisibleButton = true;
            this.cdvEndCMF6.VisibleColumnHeader = false;
            this.cdvEndCMF6.VisibleDescription = false;
            // 
            // cdvEndCMF5
            // 
            this.cdvEndCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF5.BtnToolTipText = "";
            this.cdvEndCMF5.DescText = "";
            this.cdvEndCMF5.DisplaySubItemIndex = -1;
            this.cdvEndCMF5.DisplayText = "";
            this.cdvEndCMF5.Focusing = null;
            this.cdvEndCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF5.Index = 0;
            this.cdvEndCMF5.IsViewBtnImage = false;
            this.cdvEndCMF5.Location = new System.Drawing.Point(163, 109);
            this.cdvEndCMF5.MaxLength = 30;
            this.cdvEndCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF5.Name = "cdvEndCMF5";
            this.cdvEndCMF5.ReadOnly = false;
            this.cdvEndCMF5.SearchSubItemIndex = 0;
            this.cdvEndCMF5.SelectedDescIndex = -1;
            this.cdvEndCMF5.SelectedSubItemIndex = -1;
            this.cdvEndCMF5.SelectionStart = 0;
            this.cdvEndCMF5.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF5.SmallImageList = null;
            this.cdvEndCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF5.TabIndex = 9;
            this.cdvEndCMF5.TextBoxToolTipText = "";
            this.cdvEndCMF5.TextBoxWidth = 180;
            this.cdvEndCMF5.VisibleButton = true;
            this.cdvEndCMF5.VisibleColumnHeader = false;
            this.cdvEndCMF5.VisibleDescription = false;
            // 
            // cdvEndCMF4
            // 
            this.cdvEndCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF4.BtnToolTipText = "";
            this.cdvEndCMF4.DescText = "";
            this.cdvEndCMF4.DisplaySubItemIndex = -1;
            this.cdvEndCMF4.DisplayText = "";
            this.cdvEndCMF4.Focusing = null;
            this.cdvEndCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF4.Index = 0;
            this.cdvEndCMF4.IsViewBtnImage = false;
            this.cdvEndCMF4.Location = new System.Drawing.Point(163, 85);
            this.cdvEndCMF4.MaxLength = 30;
            this.cdvEndCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF4.Name = "cdvEndCMF4";
            this.cdvEndCMF4.ReadOnly = false;
            this.cdvEndCMF4.SearchSubItemIndex = 0;
            this.cdvEndCMF4.SelectedDescIndex = -1;
            this.cdvEndCMF4.SelectedSubItemIndex = -1;
            this.cdvEndCMF4.SelectionStart = 0;
            this.cdvEndCMF4.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF4.SmallImageList = null;
            this.cdvEndCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF4.TabIndex = 7;
            this.cdvEndCMF4.TextBoxToolTipText = "";
            this.cdvEndCMF4.TextBoxWidth = 180;
            this.cdvEndCMF4.VisibleButton = true;
            this.cdvEndCMF4.VisibleColumnHeader = false;
            this.cdvEndCMF4.VisibleDescription = false;
            // 
            // cdvEndCMF3
            // 
            this.cdvEndCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF3.BtnToolTipText = "";
            this.cdvEndCMF3.DescText = "";
            this.cdvEndCMF3.DisplaySubItemIndex = -1;
            this.cdvEndCMF3.DisplayText = "";
            this.cdvEndCMF3.Focusing = null;
            this.cdvEndCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF3.Index = 0;
            this.cdvEndCMF3.IsViewBtnImage = false;
            this.cdvEndCMF3.Location = new System.Drawing.Point(163, 61);
            this.cdvEndCMF3.MaxLength = 30;
            this.cdvEndCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF3.Name = "cdvEndCMF3";
            this.cdvEndCMF3.ReadOnly = false;
            this.cdvEndCMF3.SearchSubItemIndex = 0;
            this.cdvEndCMF3.SelectedDescIndex = -1;
            this.cdvEndCMF3.SelectedSubItemIndex = -1;
            this.cdvEndCMF3.SelectionStart = 0;
            this.cdvEndCMF3.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF3.SmallImageList = null;
            this.cdvEndCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF3.TabIndex = 5;
            this.cdvEndCMF3.TextBoxToolTipText = "";
            this.cdvEndCMF3.TextBoxWidth = 180;
            this.cdvEndCMF3.VisibleButton = true;
            this.cdvEndCMF3.VisibleColumnHeader = false;
            this.cdvEndCMF3.VisibleDescription = false;
            // 
            // cdvEndCMF2
            // 
            this.cdvEndCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF2.BtnToolTipText = "";
            this.cdvEndCMF2.DescText = "";
            this.cdvEndCMF2.DisplaySubItemIndex = -1;
            this.cdvEndCMF2.DisplayText = "";
            this.cdvEndCMF2.Focusing = null;
            this.cdvEndCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF2.Index = 0;
            this.cdvEndCMF2.IsViewBtnImage = false;
            this.cdvEndCMF2.Location = new System.Drawing.Point(163, 37);
            this.cdvEndCMF2.MaxLength = 30;
            this.cdvEndCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF2.Name = "cdvEndCMF2";
            this.cdvEndCMF2.ReadOnly = false;
            this.cdvEndCMF2.SearchSubItemIndex = 0;
            this.cdvEndCMF2.SelectedDescIndex = -1;
            this.cdvEndCMF2.SelectedSubItemIndex = -1;
            this.cdvEndCMF2.SelectionStart = 0;
            this.cdvEndCMF2.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF2.SmallImageList = null;
            this.cdvEndCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF2.TabIndex = 3;
            this.cdvEndCMF2.TextBoxToolTipText = "";
            this.cdvEndCMF2.TextBoxWidth = 180;
            this.cdvEndCMF2.VisibleButton = true;
            this.cdvEndCMF2.VisibleColumnHeader = false;
            this.cdvEndCMF2.VisibleDescription = false;
            // 
            // cdvEndCMF10
            // 
            this.cdvEndCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF10.BtnToolTipText = "";
            this.cdvEndCMF10.DescText = "";
            this.cdvEndCMF10.DisplaySubItemIndex = -1;
            this.cdvEndCMF10.DisplayText = "";
            this.cdvEndCMF10.Focusing = null;
            this.cdvEndCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF10.Index = 0;
            this.cdvEndCMF10.IsViewBtnImage = false;
            this.cdvEndCMF10.Location = new System.Drawing.Point(163, 229);
            this.cdvEndCMF10.MaxLength = 30;
            this.cdvEndCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF10.Name = "cdvEndCMF10";
            this.cdvEndCMF10.ReadOnly = false;
            this.cdvEndCMF10.SearchSubItemIndex = 0;
            this.cdvEndCMF10.SelectedDescIndex = -1;
            this.cdvEndCMF10.SelectedSubItemIndex = -1;
            this.cdvEndCMF10.SelectionStart = 0;
            this.cdvEndCMF10.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF10.SmallImageList = null;
            this.cdvEndCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF10.TabIndex = 19;
            this.cdvEndCMF10.TextBoxToolTipText = "";
            this.cdvEndCMF10.TextBoxWidth = 180;
            this.cdvEndCMF10.VisibleButton = true;
            this.cdvEndCMF10.VisibleColumnHeader = false;
            this.cdvEndCMF10.VisibleDescription = false;
            // 
            // cdvEndCMF1
            // 
            this.cdvEndCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEndCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEndCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEndCMF1.BtnToolTipText = "";
            this.cdvEndCMF1.DescText = "";
            this.cdvEndCMF1.DisplaySubItemIndex = -1;
            this.cdvEndCMF1.DisplayText = "";
            this.cdvEndCMF1.Focusing = null;
            this.cdvEndCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEndCMF1.Index = 0;
            this.cdvEndCMF1.IsViewBtnImage = false;
            this.cdvEndCMF1.Location = new System.Drawing.Point(163, 13);
            this.cdvEndCMF1.MaxLength = 30;
            this.cdvEndCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEndCMF1.Name = "cdvEndCMF1";
            this.cdvEndCMF1.ReadOnly = false;
            this.cdvEndCMF1.SearchSubItemIndex = 0;
            this.cdvEndCMF1.SelectedDescIndex = -1;
            this.cdvEndCMF1.SelectedSubItemIndex = -1;
            this.cdvEndCMF1.SelectionStart = 0;
            this.cdvEndCMF1.Size = new System.Drawing.Size(180, 20);
            this.cdvEndCMF1.SmallImageList = null;
            this.cdvEndCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEndCMF1.TabIndex = 1;
            this.cdvEndCMF1.TextBoxToolTipText = "";
            this.cdvEndCMF1.TextBoxWidth = 180;
            this.cdvEndCMF1.VisibleButton = true;
            this.cdvEndCMF1.VisibleColumnHeader = false;
            this.cdvEndCMF1.VisibleDescription = false;
            // 
            // frmWIPTranLocalRepairLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranLocalRepairLot";
            this.Text = "Local Repair Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranLocalRepairLot_Activated);
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
            this.grpLocalRepair.ResumeLayout(false);
            this.grpLocalRepair.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResultCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRepairCode)).EndInit();
            this.tbpEndCMF.ResumeLayout(false);
            this.grpEndCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEndCMF1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag = false;
        
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
            MPCF.FieldClear(this, txtLotID);
            if (base.ViewLotInfo(txtLotID.Text) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            cdvResID_ButtonPress(null, null);

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
        private void ClearData(string ProcStep)
        {
            
            try
            {
                switch (ProcStep)
                {
                    case "1":
                        
                        //Initialize
                        MPCF.FieldClear(this);
                        ClearLotSpread();
                        break;
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

            switch (MPCF.Trim(FuncName))
            {
                case "Local_Repair_Lot":

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
                    if (MPCF.Trim(LOT.GetString("FLOW")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (MPCF.Trim(LOT.GetString("OPER")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (cdvRepairCode.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvRepairCode.Focus();
                        return false;
                    }
                    if (cdvResultCode.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvResultCode.Focus();
                        return false;
                    }
                    if (cdvActionCode.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvActionCode.Focus();
                        return false;
                    }
                    if (cdvResID.Items.Count > 0)
                    {
                        if (cdvResID.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            tabTran.SelectedTab = tbpGeneral;
                            cdvResID.Focus();
                            return false;
                        }
                    }
                    
                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    
                    //if (MPCR.CheckGRPCMFValue("lblEndCMF", "cdvEndCMF", grpCMF) == false)
                    //{
                    //    tabTran.SelectedTab = tbpCMF;
                    //    return false;
                    //}
                    break;
                    
            }
            
            return true;
            
        }
        //
        // GetFlowList()
        //       - Get Flow List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal cdvList As MCCodeView.MCCodeView : Flow List
        //
        private bool GetFlowList(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList)
        {
            
            try
            {
                cdvList.Init();
                MPCF.InitListView(cdvList.GetListView);
                cdvList.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                cdvList.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvList.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewFlowList(cdvList.GetListView, '1', "",0, "", null, "") == false)
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
        
        //
        // GetOperationList()
        //       - Get Operation List by Flow
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow
        //
        private bool GetOperationList(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList, string sFlow)
        {
            
            try
            {
                cdvList.Init();
                MPCF.InitListView(cdvList.GetListView);
                cdvList.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvList.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvList.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewOperationList(cdvList.GetListView, '2', "", 0,sFlow, "", null, "") == false)
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
        
        //'
        // Local_Repair_Lot()
        //       - Repair Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Local_Repair_Lot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("LOCAL_REPAIR_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

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
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("CAUSE_FLOW", MPCF.Trim(cdvCauseFlow.Text));
                in_node.AddString("CAUSE_OPER", MPCF.Trim(cdvCauseOper.Text));
                in_node.AddString("CAUSE_RES_ID", MPCF.Trim(cdvCauseRes.Text));
                in_node.AddString("REPAIR_CODE_1", MPCF.Trim(cdvRepairCode.Text));
                in_node.AddString("RESULT_CODE_1", MPCF.Trim(cdvResultCode.Text));
                in_node.AddString("ACTION_CODE_1", MPCF.Trim(cdvActionCode.Text));
                in_node.AddDouble("QTY_1", LOT.GetDouble("QTY_1"));
                in_node.AddDouble("QTY_2", LOT.GetDouble("QTY_2"));
                in_node.AddDouble("QTY_3", LOT.GetDouble("QTY_3"));
                in_node.AddString("CHECK_USER_1", MPCF.Trim(txtChkUser1.Text), true);
                in_node.AddString("CHECK_USER_2", MPCF.Trim(txtChkUser2.Text), true);

                in_node.AddString("TRAN_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("TRAN_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("TRAN_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("TRAN_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("TRAN_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("TRAN_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("TRAN_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("TRAN_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("TRAN_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("TRAN_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("TRAN_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("TRAN_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("TRAN_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("TRAN_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("TRAN_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("TRAN_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("TRAN_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("TRAN_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("TRAN_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("TRAN_CMF_20", MPCF.Trim(cdvCMF20.Text));
                in_node.AddString("REP_END_TRAN_CMF_1", MPCF.Trim(cdvEndCMF1.Text));
                in_node.AddString("REP_END_TRAN_CMF_2", MPCF.Trim(cdvEndCMF2.Text));
                in_node.AddString("REP_END_TRAN_CMF_3", MPCF.Trim(cdvEndCMF3.Text));
                in_node.AddString("REP_END_TRAN_CMF_4", MPCF.Trim(cdvEndCMF4.Text));
                in_node.AddString("REP_END_TRAN_CMF_5", MPCF.Trim(cdvEndCMF5.Text));
                in_node.AddString("REP_END_TRAN_CMF_6", MPCF.Trim(cdvEndCMF6.Text));
                in_node.AddString("REP_END_TRAN_CMF_7", MPCF.Trim(cdvEndCMF7.Text));
                in_node.AddString("REP_END_TRAN_CMF_8", MPCF.Trim(cdvEndCMF8.Text));
                in_node.AddString("REP_END_TRAN_CMF_9", MPCF.Trim(cdvEndCMF9.Text));
                in_node.AddString("REP_END_TRAN_CMF_10", MPCF.Trim(cdvEndCMF10.Text));
                in_node.AddString("REP_END_TRAN_CMF_11", MPCF.Trim(cdvEndCMF11.Text));
                in_node.AddString("REP_END_TRAN_CMF_12", MPCF.Trim(cdvEndCMF12.Text));
                in_node.AddString("REP_END_TRAN_CMF_13", MPCF.Trim(cdvEndCMF13.Text));
                in_node.AddString("REP_END_TRAN_CMF_14", MPCF.Trim(cdvEndCMF14.Text));
                in_node.AddString("REP_END_TRAN_CMF_15", MPCF.Trim(cdvEndCMF15.Text));
                in_node.AddString("REP_END_TRAN_CMF_16", MPCF.Trim(cdvEndCMF16.Text));
                in_node.AddString("REP_END_TRAN_CMF_17", MPCF.Trim(cdvEndCMF17.Text));
                in_node.AddString("REP_END_TRAN_CMF_18", MPCF.Trim(cdvEndCMF18.Text));
                in_node.AddString("REP_END_TRAN_CMF_19", MPCF.Trim(cdvEndCMF19.Text));
                in_node.AddString("REP_END_TRAN_CMF_20", MPCF.Trim(cdvEndCMF20.Text));


                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddString("LOCAL_REPAIR_COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("WIP", "WIP_Local_Repair_Lot", in_node, ref out_node) == false)
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

        
        #endregion
        
        private void frmWIPTranLocalRepairLot_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    
                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_REPAIR);
                    MPCR.SetCMFItem(MPGC.MP_CMF_TRN_REPAIR_END, "lblEndCMF", "cdvEndCMF", grpEndCMF);
                    
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
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Local_Repair_Lot") == false) return;
                
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_LOCAL_REPAIR, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'B') == false) return;
                if (Local_Repair_Lot('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_LOCAL_REPAIR, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'A') == false) return;

                ViewLotInfo(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvCauseFlow_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtLotID.Focus();
                return;
            }
            if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                return;
            }
            
            if (GetFlowList(cdvCauseFlow) == false)
            {
                return;
            }
            
        }
        
        private void cdvCauseFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvCauseOper.Text = "";
            
        }
        
        private void cdvCauseOper_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtLotID.Focus();
                return;
            }
            if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                return;
            }
            if (cdvCauseFlow.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvCauseFlow.Focus();
                return;
            }
            
            if (GetOperationList(cdvCauseOper, cdvCauseFlow.Text) == false)
            {
                return;
            }
            
        }
        
        private void cdvCauseRes_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtLotID.Focus();
                return;
            }
            if (cdvCauseOper.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvCauseOper.Focus();
                return;
            }

            cdvCauseRes.Init();
            MPCF.InitListView(cdvCauseRes.GetListView);
            cdvCauseRes.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvCauseRes.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCauseRes.SelectedSubItemIndex = 0;
#if _RAS
            if (RASLIST.ViewResourceList(cdvCauseRes.GetListView, "%", 0, cdvCauseFlow.Text, cdvCauseOper.Text, false) == false)
            {
                return;
            }
#endif
            
        }

        private void cdvEndCMF_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvEndCMF_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }
        
        private void cdvRepairCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvRepairCode.Init();
            MPCF.InitListView(cdvRepairCode.GetListView);
            cdvRepairCode.Columns.Add("Repair Code", 150, HorizontalAlignment.Left);
            cdvRepairCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvRepairCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvRepairCode.GetListView, '1', MPGC.MP_WIP_REPAIR_CODE);
        }
        
        private void cdvResultCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResultCode.Init();
            MPCF.InitListView(cdvResultCode.GetListView);
            cdvResultCode.Columns.Add("Result Code", 150, HorizontalAlignment.Left);
            cdvResultCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvResultCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvResultCode.GetListView, '1', MPGC.MP_WIP_RESULT_CODE);
        }
        
        private void cdvActionCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvActionCode.Init();
            MPCF.InitListView(cdvActionCode.GetListView);
            cdvActionCode.Columns.Add("Action Code", 150, HorizontalAlignment.Left);
            cdvActionCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvActionCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvActionCode.GetListView, '1', MPGC.MP_WIP_ACTION_CODE);
        }

        private void cdvResID_ButtonPress(object sender, EventArgs e)
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;

            if (LOT.GetDouble("QTY_1") > 0 || LOT.GetDouble("QTY_2") > 0 || LOT.GetDouble("QTY_3") > 0)
            {
#if _RAS
                if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false)
                {
                    return;
                }
#endif
            }

        }
    }
    
}
