
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranReworkLot.vb
//   Description : Rework Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetFlowList() : Get Flow List
//       - GetOperationList() : Get Operation List
//       - View_Operation() : View Operation Information
//       - GetReworkCodeList() : Get ResourceID List
//       - GetReworkOperList() : Get Rework Oper List
//       - ViewReworkFlowList() : View Rework Flow List
//       - ViewReworkOperList() : View Rework Flow List
//       - ViewReturnFlowOper() : View Rework Flow List
//       - Rework_Lot() : Rework Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-23 : Created by WKIM
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
    public class frmWIPTranReworkLot : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranReworkLot()
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
        



        private System.Windows.Forms.GroupBox grpRework;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseRes;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseFlow;
        private System.Windows.Forms.Label lblCauseRes;
        private System.Windows.Forms.Label lblCauseOper;
        private System.Windows.Forms.Label lblCauseFlow;
        private System.Windows.Forms.TextBox txtChkUser2;
        private System.Windows.Forms.TextBox txtChkUser1;
        private System.Windows.Forms.Label lblUser1;
        private System.Windows.Forms.Label lblUser2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvReworkCode;
        private System.Windows.Forms.Label lblReworkCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvReworkOper;
        private System.Windows.Forms.Label lblReworkOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvReturnOper;
        private System.Windows.Forms.Label lblRetOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Label lblQty23;
        private System.Windows.Forms.TextBox txtNewQty3;
        private System.Windows.Forms.TextBox txtNewQty2;
        private System.Windows.Forms.TextBox txtNewQty1;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvReturnFlow;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvReworkFlow;
        private Label lblReturnOption;
        private ComboBox cboReturnOption;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvReworkStopOper;
        private Label lblReworkStopOper;
        private System.Windows.Forms.Label lblQty1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.grpRework = new System.Windows.Forms.GroupBox();
            this.cdvReworkStopOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblReworkStopOper = new System.Windows.Forms.Label();
            this.lblReturnOption = new System.Windows.Forms.Label();
            this.cboReturnOption = new System.Windows.Forms.ComboBox();
            this.cdvReworkFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvReturnFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.lblQty23 = new System.Windows.Forms.Label();
            this.txtNewQty3 = new System.Windows.Forms.TextBox();
            this.txtNewQty2 = new System.Windows.Forms.TextBox();
            this.txtNewQty1 = new System.Windows.Forms.TextBox();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvReturnOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRetOper = new System.Windows.Forms.Label();
            this.cdvReworkOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblReworkOper = new System.Windows.Forms.Label();
            this.cdvCauseRes = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCauseOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCauseFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCauseRes = new System.Windows.Forms.Label();
            this.lblCauseOper = new System.Windows.Forms.Label();
            this.lblCauseFlow = new System.Windows.Forms.Label();
            this.cdvReworkCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblReworkCode = new System.Windows.Forms.Label();
            this.txtChkUser2 = new System.Windows.Forms.TextBox();
            this.txtChkUser1 = new System.Windows.Forms.TextBox();
            this.lblUser1 = new System.Windows.Forms.Label();
            this.lblUser2 = new System.Windows.Forms.Label();
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
            this.grpRework.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReworkStopOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReturnOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReworkOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReworkCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpRework);
            this.pnlTranInfo.Size = new System.Drawing.Size(722, 235);
            this.pnlTranInfo.TabIndex = 1;
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
            // pnlTranTime
            // 
            this.pnlTranTime.TabIndex = 2;
            // 
            // txtTranDateTime
            // 
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
            this.tabTran.Size = new System.Drawing.Size(736, 441);
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
            this.lblLotDesc.TabIndex = 3;
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 3;
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 444);
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
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
            this.lblFormTitle.Text = "Rework Lot";
            // 
            // grpRework
            // 
            this.grpRework.Controls.Add(this.cdvReworkStopOper);
            this.grpRework.Controls.Add(this.lblReworkStopOper);
            this.grpRework.Controls.Add(this.lblReturnOption);
            this.grpRework.Controls.Add(this.cboReturnOption);
            this.grpRework.Controls.Add(this.cdvReworkFlow);
            this.grpRework.Controls.Add(this.cdvReturnFlow);
            this.grpRework.Controls.Add(this.lblQty23);
            this.grpRework.Controls.Add(this.txtNewQty3);
            this.grpRework.Controls.Add(this.txtNewQty2);
            this.grpRework.Controls.Add(this.txtNewQty1);
            this.grpRework.Controls.Add(this.lblQty1);
            this.grpRework.Controls.Add(this.cdvResID);
            this.grpRework.Controls.Add(this.lblResID);
            this.grpRework.Controls.Add(this.cdvReturnOper);
            this.grpRework.Controls.Add(this.lblRetOper);
            this.grpRework.Controls.Add(this.cdvReworkOper);
            this.grpRework.Controls.Add(this.lblReworkOper);
            this.grpRework.Controls.Add(this.cdvCauseRes);
            this.grpRework.Controls.Add(this.cdvCauseOper);
            this.grpRework.Controls.Add(this.cdvCauseFlow);
            this.grpRework.Controls.Add(this.lblCauseRes);
            this.grpRework.Controls.Add(this.lblCauseOper);
            this.grpRework.Controls.Add(this.lblCauseFlow);
            this.grpRework.Controls.Add(this.cdvReworkCode);
            this.grpRework.Controls.Add(this.lblReworkCode);
            this.grpRework.Controls.Add(this.txtChkUser2);
            this.grpRework.Controls.Add(this.txtChkUser1);
            this.grpRework.Controls.Add(this.lblUser1);
            this.grpRework.Controls.Add(this.lblUser2);
            this.grpRework.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRework.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRework.Location = new System.Drawing.Point(0, 0);
            this.grpRework.Name = "grpRework";
            this.grpRework.Size = new System.Drawing.Size(722, 235);
            this.grpRework.TabIndex = 0;
            this.grpRework.TabStop = false;
            // 
            // cdvReworkStopOper
            // 
            this.cdvReworkStopOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvReworkStopOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvReworkStopOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvReworkStopOper.BtnToolTipText = "";
            this.cdvReworkStopOper.DescText = "";
            this.cdvReworkStopOper.DisplaySubItemIndex = -1;
            this.cdvReworkStopOper.DisplayText = "";
            this.cdvReworkStopOper.Focusing = null;
            this.cdvReworkStopOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkStopOper.Index = 0;
            this.cdvReworkStopOper.IsViewBtnImage = false;
            this.cdvReworkStopOper.Location = new System.Drawing.Point(118, 88);
            this.cdvReworkStopOper.MaxLength = 10;
            this.cdvReworkStopOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvReworkStopOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvReworkStopOper.Name = "cdvReworkStopOper";
            this.cdvReworkStopOper.ReadOnly = false;
            this.cdvReworkStopOper.SearchSubItemIndex = 0;
            this.cdvReworkStopOper.SelectedDescIndex = -1;
            this.cdvReworkStopOper.SelectedSubItemIndex = -1;
            this.cdvReworkStopOper.SelectionStart = 0;
            this.cdvReworkStopOper.Size = new System.Drawing.Size(200, 20);
            this.cdvReworkStopOper.SmallImageList = null;
            this.cdvReworkStopOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvReworkStopOper.TabIndex = 6;
            this.cdvReworkStopOper.TextBoxToolTipText = "";
            this.cdvReworkStopOper.TextBoxWidth = 200;
            this.cdvReworkStopOper.VisibleButton = true;
            this.cdvReworkStopOper.VisibleColumnHeader = false;
            this.cdvReworkStopOper.VisibleDescription = false;
            this.cdvReworkStopOper.ButtonPress += new System.EventHandler(this.cdvReworkStopOper_ButtonPress);
            // 
            // lblReworkStopOper
            // 
            this.lblReworkStopOper.AutoSize = true;
            this.lblReworkStopOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkStopOper.Location = new System.Drawing.Point(12, 91);
            this.lblReworkStopOper.Name = "lblReworkStopOper";
            this.lblReworkStopOper.Size = new System.Drawing.Size(95, 13);
            this.lblReworkStopOper.TabIndex = 5;
            this.lblReworkStopOper.Text = "Rework Stop Oper";
            this.lblReworkStopOper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblReturnOption
            // 
            this.lblReturnOption.AutoSize = true;
            this.lblReturnOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReturnOption.Location = new System.Drawing.Point(352, 140);
            this.lblReturnOption.Name = "lblReturnOption";
            this.lblReturnOption.Size = new System.Drawing.Size(73, 13);
            this.lblReturnOption.TabIndex = 27;
            this.lblReturnOption.Text = "Return Option";
            // 
            // cboReturnOption
            // 
            this.cboReturnOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReturnOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboReturnOption.FormattingEnabled = true;
            this.cboReturnOption.Items.AddRange(new object[] {
            "Keep Rework",
            "Clear Rework",
            "Clear Rework and Move to Next Operation",
            "Keep Rework and Move to Next Operation"});
            this.cboReturnOption.Location = new System.Drawing.Point(458, 136);
            this.cboReturnOption.Name = "cboReturnOption";
            this.cboReturnOption.Size = new System.Drawing.Size(259, 21);
            this.cboReturnOption.TabIndex = 28;
            // 
            // cdvReworkFlow
            // 
            this.cdvReworkFlow.AddEmptyRowToLast = false;
            this.cdvReworkFlow.AddEmptyRowToTop = false;
            this.cdvReworkFlow.DisplaySubItemIndex = 0;
            this.cdvReworkFlow.FlowReadOnly = false;
            this.cdvReworkFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkFlow.LabelText = "Rework Flow";
            this.cdvReworkFlow.LabelWidth = 106;
            this.cdvReworkFlow.ListCond_ExtFactory = "";
            this.cdvReworkFlow.ListCond_Step = '2';
            this.cdvReworkFlow.Location = new System.Drawing.Point(12, 40);
            this.cdvReworkFlow.Name = "cdvReworkFlow";
            this.cdvReworkFlow.SearchSubItemIndex = 0;
            this.cdvReworkFlow.SelectedDescIndex = -1;
            this.cdvReworkFlow.SelectedSubItemIndex = 0;
            this.cdvReworkFlow.SequenceReadOnly = false;
            this.cdvReworkFlow.Size = new System.Drawing.Size(306, 20);
            this.cdvReworkFlow.TabIndex = 2;
            this.cdvReworkFlow.VisibleColumnHeader = false;
            this.cdvReworkFlow.VisibleDescription = false;
            this.cdvReworkFlow.VisibleFlowButton = true;
            this.cdvReworkFlow.VisibleSequenceButton = true;
            this.cdvReworkFlow.WidthButton = 20;
            this.cdvReworkFlow.WidthFlowAndSequence = 200;
            this.cdvReworkFlow.WidthSequence = 50;
            this.cdvReworkFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvReworkFlow_SelectedItemChanged);
            this.cdvReworkFlow.FlowButtonPress += new System.EventHandler(this.cdvReworkFlow_ButtonPress);
            // 
            // cdvReturnFlow
            // 
            this.cdvReturnFlow.AddEmptyRowToLast = false;
            this.cdvReturnFlow.AddEmptyRowToTop = false;
            this.cdvReturnFlow.DisplaySubItemIndex = 0;
            this.cdvReturnFlow.FlowReadOnly = false;
            this.cdvReturnFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnFlow.LabelText = "Return Flow";
            this.cdvReturnFlow.LabelWidth = 106;
            this.cdvReturnFlow.ListCond_ExtFactory = "";
            this.cdvReturnFlow.ListCond_Step = '2';
            this.cdvReturnFlow.Location = new System.Drawing.Point(12, 112);
            this.cdvReturnFlow.Name = "cdvReturnFlow";
            this.cdvReturnFlow.SearchSubItemIndex = 0;
            this.cdvReturnFlow.SelectedDescIndex = -1;
            this.cdvReturnFlow.SelectedSubItemIndex = 0;
            this.cdvReturnFlow.SequenceReadOnly = false;
            this.cdvReturnFlow.Size = new System.Drawing.Size(306, 20);
            this.cdvReturnFlow.TabIndex = 7;
            this.cdvReturnFlow.VisibleColumnHeader = false;
            this.cdvReturnFlow.VisibleDescription = false;
            this.cdvReturnFlow.VisibleFlowButton = true;
            this.cdvReturnFlow.VisibleSequenceButton = true;
            this.cdvReturnFlow.WidthButton = 20;
            this.cdvReturnFlow.WidthFlowAndSequence = 200;
            this.cdvReturnFlow.WidthSequence = 50;
            this.cdvReturnFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvReturnFlow_SelectedItemChanged);
            this.cdvReturnFlow.FlowButtonPress += new System.EventHandler(this.cdvReturnFlow_FlowButtonPress);
            this.cdvReturnFlow.SeqButtonPress += new System.EventHandler(this.cdvReturnFlow_SeqButtonPress);
            // 
            // lblQty23
            // 
            this.lblQty23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty23.Location = new System.Drawing.Point(64, 188);
            this.lblQty23.Name = "lblQty23";
            this.lblQty23.Size = new System.Drawing.Size(48, 13);
            this.lblQty23.TabIndex = 13;
            this.lblQty23.Text = "/ 2/ 3";
            this.lblQty23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNewQty3
            // 
            this.txtNewQty3.Location = new System.Drawing.Point(252, 184);
            this.txtNewQty3.MaxLength = 11;
            this.txtNewQty3.Name = "txtNewQty3";
            this.txtNewQty3.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty3.TabIndex = 16;
            this.txtNewQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewQty2
            // 
            this.txtNewQty2.Location = new System.Drawing.Point(185, 184);
            this.txtNewQty2.MaxLength = 11;
            this.txtNewQty2.Name = "txtNewQty2";
            this.txtNewQty2.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty2.TabIndex = 15;
            this.txtNewQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewQty1
            // 
            this.txtNewQty1.Location = new System.Drawing.Point(118, 184);
            this.txtNewQty1.MaxLength = 11;
            this.txtNewQty1.Name = "txtNewQty1";
            this.txtNewQty1.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty1.TabIndex = 14;
            this.txtNewQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty1.Location = new System.Drawing.Point(12, 188);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(57, 13);
            this.lblQty1.TabIndex = 12;
            this.lblQty1.Text = "New Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvResID.Location = new System.Drawing.Point(118, 160);
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
            this.cdvResID.TabIndex = 11;
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
            this.lblResID.Location = new System.Drawing.Point(12, 163);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 10;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvReturnOper
            // 
            this.cdvReturnOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvReturnOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvReturnOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvReturnOper.BtnToolTipText = "";
            this.cdvReturnOper.DescText = "";
            this.cdvReturnOper.DisplaySubItemIndex = -1;
            this.cdvReturnOper.DisplayText = "";
            this.cdvReturnOper.Focusing = null;
            this.cdvReturnOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReturnOper.Index = 0;
            this.cdvReturnOper.IsViewBtnImage = false;
            this.cdvReturnOper.Location = new System.Drawing.Point(118, 136);
            this.cdvReturnOper.MaxLength = 10;
            this.cdvReturnOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvReturnOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvReturnOper.Name = "cdvReturnOper";
            this.cdvReturnOper.ReadOnly = false;
            this.cdvReturnOper.SearchSubItemIndex = 0;
            this.cdvReturnOper.SelectedDescIndex = -1;
            this.cdvReturnOper.SelectedSubItemIndex = -1;
            this.cdvReturnOper.SelectionStart = 0;
            this.cdvReturnOper.Size = new System.Drawing.Size(200, 20);
            this.cdvReturnOper.SmallImageList = null;
            this.cdvReturnOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvReturnOper.TabIndex = 9;
            this.cdvReturnOper.TextBoxToolTipText = "";
            this.cdvReturnOper.TextBoxWidth = 200;
            this.cdvReturnOper.VisibleButton = true;
            this.cdvReturnOper.VisibleColumnHeader = false;
            this.cdvReturnOper.VisibleDescription = false;
            this.cdvReturnOper.ButtonPress += new System.EventHandler(this.cdvReturnOper_ButtonPress);
            // 
            // lblRetOper
            // 
            this.lblRetOper.AutoSize = true;
            this.lblRetOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRetOper.Location = new System.Drawing.Point(12, 139);
            this.lblRetOper.Name = "lblRetOper";
            this.lblRetOper.Size = new System.Drawing.Size(65, 13);
            this.lblRetOper.TabIndex = 8;
            this.lblRetOper.Text = "Return Oper";
            this.lblRetOper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvReworkOper
            // 
            this.cdvReworkOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvReworkOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvReworkOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvReworkOper.BtnToolTipText = "";
            this.cdvReworkOper.DescText = "";
            this.cdvReworkOper.DisplaySubItemIndex = -1;
            this.cdvReworkOper.DisplayText = "";
            this.cdvReworkOper.Focusing = null;
            this.cdvReworkOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkOper.Index = 0;
            this.cdvReworkOper.IsViewBtnImage = false;
            this.cdvReworkOper.Location = new System.Drawing.Point(118, 64);
            this.cdvReworkOper.MaxLength = 10;
            this.cdvReworkOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvReworkOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvReworkOper.Name = "cdvReworkOper";
            this.cdvReworkOper.ReadOnly = false;
            this.cdvReworkOper.SearchSubItemIndex = 0;
            this.cdvReworkOper.SelectedDescIndex = -1;
            this.cdvReworkOper.SelectedSubItemIndex = -1;
            this.cdvReworkOper.SelectionStart = 0;
            this.cdvReworkOper.Size = new System.Drawing.Size(200, 20);
            this.cdvReworkOper.SmallImageList = null;
            this.cdvReworkOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvReworkOper.TabIndex = 4;
            this.cdvReworkOper.TextBoxToolTipText = "";
            this.cdvReworkOper.TextBoxWidth = 200;
            this.cdvReworkOper.VisibleButton = true;
            this.cdvReworkOper.VisibleColumnHeader = false;
            this.cdvReworkOper.VisibleDescription = false;
            this.cdvReworkOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvReworkOper_SelectedItemChanged);
            this.cdvReworkOper.ButtonPress += new System.EventHandler(this.cdvReworkOper_ButtonPress);
            // 
            // lblReworkOper
            // 
            this.lblReworkOper.AutoSize = true;
            this.lblReworkOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReworkOper.Location = new System.Drawing.Point(12, 67);
            this.lblReworkOper.Name = "lblReworkOper";
            this.lblReworkOper.Size = new System.Drawing.Size(81, 13);
            this.lblReworkOper.TabIndex = 3;
            this.lblReworkOper.Text = "Rework Oper";
            this.lblReworkOper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.cdvCauseRes.TabIndex = 22;
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
            this.cdvCauseOper.TabIndex = 20;
            this.cdvCauseOper.TextBoxToolTipText = "";
            this.cdvCauseOper.TextBoxWidth = 200;
            this.cdvCauseOper.VisibleButton = true;
            this.cdvCauseOper.VisibleColumnHeader = false;
            this.cdvCauseOper.VisibleDescription = false;
            this.cdvCauseOper.ButtonPress += new System.EventHandler(this.cdvCauseOper_ButtonPress);
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
            this.cdvCauseFlow.TabIndex = 18;
            this.cdvCauseFlow.TextBoxToolTipText = "";
            this.cdvCauseFlow.TextBoxWidth = 200;
            this.cdvCauseFlow.VisibleButton = true;
            this.cdvCauseFlow.VisibleColumnHeader = false;
            this.cdvCauseFlow.VisibleDescription = false;
            this.cdvCauseFlow.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCauseFlow_SelectedItemChanged);
            this.cdvCauseFlow.ButtonPress += new System.EventHandler(this.cdvCauseFlow_ButtonPress);
            // 
            // lblCauseRes
            // 
            this.lblCauseRes.AutoSize = true;
            this.lblCauseRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseRes.Location = new System.Drawing.Point(352, 67);
            this.lblCauseRes.Name = "lblCauseRes";
            this.lblCauseRes.Size = new System.Drawing.Size(86, 13);
            this.lblCauseRes.TabIndex = 21;
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
            this.lblCauseOper.TabIndex = 19;
            this.lblCauseOper.Text = "Cause Operation";
            this.lblCauseOper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblCauseFlow
            // 
            this.lblCauseFlow.AutoSize = true;
            this.lblCauseFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCauseFlow.Location = new System.Drawing.Point(352, 19);
            this.lblCauseFlow.Name = "lblCauseFlow";
            this.lblCauseFlow.Size = new System.Drawing.Size(62, 13);
            this.lblCauseFlow.TabIndex = 17;
            this.lblCauseFlow.Text = "Cause Flow";
            this.lblCauseFlow.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvReworkCode
            // 
            this.cdvReworkCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvReworkCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvReworkCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvReworkCode.BtnToolTipText = "";
            this.cdvReworkCode.DescText = "";
            this.cdvReworkCode.DisplaySubItemIndex = -1;
            this.cdvReworkCode.DisplayText = "";
            this.cdvReworkCode.Focusing = null;
            this.cdvReworkCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReworkCode.Index = 0;
            this.cdvReworkCode.IsViewBtnImage = false;
            this.cdvReworkCode.Location = new System.Drawing.Point(118, 16);
            this.cdvReworkCode.MaxLength = 10;
            this.cdvReworkCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvReworkCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvReworkCode.Name = "cdvReworkCode";
            this.cdvReworkCode.ReadOnly = true;
            this.cdvReworkCode.SearchSubItemIndex = 0;
            this.cdvReworkCode.SelectedDescIndex = -1;
            this.cdvReworkCode.SelectedSubItemIndex = -1;
            this.cdvReworkCode.SelectionStart = 0;
            this.cdvReworkCode.Size = new System.Drawing.Size(200, 20);
            this.cdvReworkCode.SmallImageList = null;
            this.cdvReworkCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvReworkCode.TabIndex = 1;
            this.cdvReworkCode.TextBoxToolTipText = "";
            this.cdvReworkCode.TextBoxWidth = 200;
            this.cdvReworkCode.VisibleButton = true;
            this.cdvReworkCode.VisibleColumnHeader = false;
            this.cdvReworkCode.VisibleDescription = false;
            this.cdvReworkCode.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvReworkCode_SelectedItemChanged);
            // 
            // lblReworkCode
            // 
            this.lblReworkCode.AutoSize = true;
            this.lblReworkCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReworkCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReworkCode.Location = new System.Drawing.Point(12, 19);
            this.lblReworkCode.Name = "lblReworkCode";
            this.lblReworkCode.Size = new System.Drawing.Size(83, 13);
            this.lblReworkCode.TabIndex = 0;
            this.lblReworkCode.Text = "Rework Code";
            this.lblReworkCode.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtChkUser2
            // 
            this.txtChkUser2.Location = new System.Drawing.Point(458, 112);
            this.txtChkUser2.MaxLength = 20;
            this.txtChkUser2.Name = "txtChkUser2";
            this.txtChkUser2.Size = new System.Drawing.Size(200, 20);
            this.txtChkUser2.TabIndex = 26;
            // 
            // txtChkUser1
            // 
            this.txtChkUser1.Location = new System.Drawing.Point(458, 88);
            this.txtChkUser1.MaxLength = 20;
            this.txtChkUser1.Name = "txtChkUser1";
            this.txtChkUser1.Size = new System.Drawing.Size(200, 20);
            this.txtChkUser1.TabIndex = 24;
            // 
            // lblUser1
            // 
            this.lblUser1.AutoSize = true;
            this.lblUser1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser1.Location = new System.Drawing.Point(352, 91);
            this.lblUser1.Name = "lblUser1";
            this.lblUser1.Size = new System.Drawing.Size(86, 13);
            this.lblUser1.TabIndex = 23;
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
            this.lblUser2.TabIndex = 25;
            this.lblUser2.Text = "Check User ID 2";
            this.lblUser2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // frmWIPTranReworkLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranReworkLot";
            this.Text = "Rework Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranReworkLot_Activated);
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
            this.grpRework.ResumeLayout(false);
            this.grpRework.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReworkStopOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReturnOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReworkOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReworkCode)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag = false;
        private string s_rework_table = "";
        
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
            cdvResID.Items.Clear();

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");
            cdvResID.Text = LOT.GetString("START_RES_ID");

            if (View_Operation(LOT.GetString("OPER")) == false) return false;
            if (GetReworkCodeList(s_rework_table) == false) return false;

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
                    case "2":

                        MPCF.FieldClear(this, txtLotID);
                        if (base.ViewLotInfo(txtLotID.Text) == false)
                        {
                            txtLotID.Focus();
                            return;
                        }
                        txtLotDesc.Text = LOT.GetString("LOT_DESC");
                        txtLotID.Focus();
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
                case "REWORK_LOT":

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
                    if (MPCF.Trim(LOT.GetString("OPER")) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                        txtLotID.Focus();
                        return false;
                    }
                    if (MPCF.CheckValue(cdvReworkCode, 1) == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        return false;
                    }
                    if (MPCF.CheckValue(cdvReworkOper, 1) == false)
                    {
                        tabTran.SelectedTab = tbpGeneral;
                        return false;
                    }
                    if (cdvReturnFlow.Text != "" && cdvReturnOper.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvReturnOper.Focus();
                        return false;
                    }
                    
                    if (txtNewQty1.Text != "")
                    {
                        if (MPCF.CheckValue(txtNewQty1, 2) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtNewQty1.Focus();
                            return false;
                        }
                    }
                    if (txtNewQty2.Text != "")
                    {
                        if (MPCF.CheckValue(txtNewQty2, 2) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtNewQty2.Focus();
                            return false;
                        }
                    }
                    if (txtNewQty3.Text != "")
                    {
                        if (MPCF.CheckValue(txtNewQty3, 2) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtNewQty3.Focus();
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

                char c_step = (sFlow == "") ? '1' : '2';
                if (WIPLIST.ViewOperationList(cdvList.GetListView, c_step, "", 0, sFlow, "", null, "") == false)
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
        // GetReworkCodeList()
        //       - Get ResourceID List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool GetReworkCodeList(string sTableName)
        {
            
            try
            {
                cdvReworkCode.Init();
                MPCF.InitListView(cdvReworkCode.GetListView);
                cdvReworkCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvReworkCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvReworkCode.SelectedSubItemIndex = 0;
                
                if (sTableName == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(195));
                    return false;
                }

                if (BASLIST.ViewGCMDataList(cdvReworkCode.GetListView, '1', sTableName) == false)
                {
                    return false;
                }
                cdvReworkCode.InsertEmptyRow(0, 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
                
        //
        // GetReworkOperList()
        //       - Get Rework Oper List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool GetReworkOperList()
        {
            
            try
            {
                cdvReworkOper.Init();
                MPCF.InitListView(cdvReworkOper.GetListView);
                cdvReworkOper.Columns.Add("Oper", 50, HorizontalAlignment.Left);
                cdvReworkOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvReworkOper.SelectedSubItemIndex = 0;
                
                if (ViewReworkOperList() == false)
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
        // View_Operation()
        //       -  View Operation Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Operation(string sOper)
        {

            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", sOper);

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            s_rework_table = out_node.GetString("REWORK_TBL");

            return true;

        }


        //
        // GetFlowList()
        //       - Get Flow List by Material
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

                if (WIPLIST.ViewFlowList(cdvList.GetListView, '1', "", 0, "", null, "") == false)
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
        // ViewReworkFlowOperByCode()
        //       -  View Rework Flow, Oper By Rework Code
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String : Process Step
        //       - ByVal Form_control As Control : Control
        //       - ByVal sOptLevel As String : Option Level
        //       - ByVal sMaterial As String : Material
        //       - ByVal sFlow As String : Flow
        //       - ByVal sOper As String : Operation
        //
        public bool ViewReworkFlowOperByCode(string sMaterial, int iMatVer, string sFlow, string sOper, string sCode)
        {

            TRSNode in_node = new TRSNode("VIEW_REWORK_FLOW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REWORK_FLOW_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '4';

            in_node.AddString("MAT_ID", MPCF.Trim(sMaterial));
            in_node.AddInt("MAT_VER", iMatVer);
            in_node.AddString("FLOW", MPCF.Trim(sFlow));
            in_node.AddString("OPER", MPCF.Trim(sOper));
            in_node.AddString("RWK_CODE", MPCF.Trim(sCode));

            if (MPCR.CallService("WIP", "WIP_View_Rework_Flow_List", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList(0).Count > 0)
            {
                if (MPCF.Trim(out_node.GetList(0)[0].GetString("RWK_FLOW")) == "")
                {
                    cdvReworkFlow.Text = LOT.GetString("FLOW");
                    cdvReworkFlow.Sequence = LOT.GetInt("FLOW_SEQ_NUM");
                }
                else
                {
                    cdvReworkFlow.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RWK_FLOW"));

                    if (out_node.GetList(0)[0].GetInt("RWK_FLOW_SEQ_NUM") < 1)
                    {
                        if (cdvReworkFlow.Text == LOT.GetString("FLOW"))
                        {
                            cdvReworkFlow.Sequence = LOT.GetInt("FLOW_SEQ_NUM");
                        }
                    }
                    else
                    {
                        cdvReworkFlow.Sequence = out_node.GetList(0)[0].GetInt("RWK_FLOW_SEQ_NUM");
                    }
                }

                cdvReworkOper.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RWK_OPER"));
                cdvReworkStopOper.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RWK_STOP_OPER"));

                if (MPCF.Trim(out_node.GetList(0)[0].GetString("RET_FLOW")) == "")
                {
                    cdvReturnFlow.Text = LOT.GetString("FLOW");
                    cdvReturnFlow.Sequence = LOT.GetInt("FLOW_SEQ_NUM");
                }
                else
                {
                    cdvReturnFlow.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_FLOW"));

                    if (out_node.GetList(0)[0].GetInt("RET_FLOW_SEQ_NUM") < 1)
                    {
                        if (cdvReturnFlow.Text == LOT.GetString("FLOW"))
                        {
                            cdvReturnFlow.Sequence = LOT.GetInt("FLOW_SEQ_NUM");
                        }
                    }
                    else
                    {
                        cdvReturnFlow.Sequence = out_node.GetList(0)[0].GetInt("RET_FLOW_SEQ_NUM");
                    }
                }

                if (MPCF.Trim(out_node.GetList(0)[0].GetString("RET_OPER")) != "")
                {
                    cdvReturnOper.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_OPER"));
                }

                switch (out_node.GetList(0)[0].GetChar("RET_CLEAR_FLAG"))
                {
                    case 'Y': // Clear Rework
                        cboReturnOption.SelectedIndex = 1;
                        break;
                    case 'A': // Clear Rework and Move to Next Oper
                        cboReturnOption.SelectedIndex = 2;
                        break;
                    case 'B': // Keep Rework and Move to Next Oper
                        cboReturnOption.SelectedIndex = 3;
                        break;
                    default: // keep Rework
                        cboReturnOption.SelectedIndex = 0;
                        break;
                }
            }

            return true;

        }
        //
        // ViewReworkFlowList()
        //       -  View Rework Flow List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public bool ViewReworkFlowList()
        {
            ListViewItem itmX;
            int i;

            TRSNode in_node = new TRSNode("VIEW_REWORK_FLOW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REWORK_FLOW_LIST_OUT");

            MPCF.ClearList(cdvReworkFlow.FlowGetListView, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';

            in_node.AddChar("OPT_LEVEL", '1');
            in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
            in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
            in_node.AddString("FLOW", LOT.GetString("FLOW"));
            in_node.AddString("OPER", LOT.GetString("OPER"));
            in_node.AddString("RWK_CODE", MPCF.Trim(cdvReworkCode.Text));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Rework_Flow_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("RWK_FLOW"), (int)SMALLICON_INDEX.IDX_FLOW);

                    if (out_node.GetList(0)[i].GetString("RWK_FLOW") == "")
                    {
                        itmX.SubItems.Add("");
                    }
                    else
                    {
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetInt("RWK_FLOW_SEQ_NUM").ToString());
                    }

                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_FLOW_DESC"));
                    cdvReworkFlow.FlowItems.Add(itmX);
                }

                in_node.SetString("NEXT_FLOW", out_node.GetString("NEXT_FLOW"));

            } while (in_node.GetString("NEXT_FLOW") != "");

            return true;

        }

        //
        // ViewReworkOperList()
        //       -  View Rework Flow List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public bool ViewReworkOperList()
        {

            ListViewItem itmX;
            int i;

            TRSNode in_node = new TRSNode("VIEW_REWORK_OPER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REWORK_OPER_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';

            in_node.AddChar("OPT_LEVEL", '1');
            in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
            in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
            in_node.AddString("FLOW", LOT.GetString("FLOW"));
            in_node.AddString("OPER", LOT.GetString("OPER"));
            in_node.AddString("RWK_CODE", MPCF.Trim(cdvReworkCode.Text));
            in_node.AddString("RWK_FLOW", MPCF.Trim(cdvReworkFlow.Text));
            in_node.AddInt("RWK_FLOW_SEQ_NUM", cdvReworkFlow.Sequence);

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Rework_Oper_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("RWK_OPER"), (int)SMALLICON_INDEX.IDX_OPER);
                    itmX.SubItems.Add(out_node.GetList(0)[i].GetString("RWK_OPER_DESC"));
                    this.cdvReworkOper.Items.Add(itmX);
                }

                in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));

            } while (in_node.GetString("NEXT_OPER") != "");

            return true;

        }

        //
        // ViewReturnFlowOper()
        //       -  View Rework Flow List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        public bool ViewReturnFlowOper()
        {

            TRSNode in_node = new TRSNode("VIEW_REWORK_FLOW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REWORK_FLOW_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '3';

            in_node.AddChar("OPT_LEVEL", '1');
            in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
            in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
            in_node.AddString("FLOW", LOT.GetString("FLOW"));
            in_node.AddString("OPER", LOT.GetString("OPER"));
            in_node.AddString("RWK_CODE", MPCF.Trim(cdvReworkCode.Text));
            in_node.AddString("RWK_FLOW", MPCF.Trim(cdvReworkFlow.Text));
            in_node.AddInt("RWK_FLOW_SEQ_NUM", cdvReworkFlow.Sequence);
            in_node.AddString("RWK_OPER", MPCF.Trim(cdvReworkOper.Text));

            if (MPCR.CallService("WIP", "WIP_View_Rework_Flow_List", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList(0).Count > 0)
            {
                cdvReturnFlow.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_FLOW"));

                if (out_node.GetList(0)[0].GetInt("RET_FLOW_SEQ_NUM") < 1)
                {
                    if (cdvReturnFlow.Text == LOT.GetString("FLOW"))
                    {
                        cdvReturnFlow.Sequence = LOT.GetInt("FLOW_SEQ_NUM");
                    }
                }
                else
                {
                    cdvReturnFlow.Sequence = out_node.GetList(0)[0].GetInt("RET_FLOW_SEQ_NUM");
                }

                cdvReturnOper.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_OPER"));
            }

            return true;

        }

        //
        // Rework_Lot()
        //       - Rework Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Rework_Lot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("REWORK_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            bool b_proc_alarm_action;

            try
            {
                MPCR.SetInMsg(in_node);

                /***** Start Check Input Port and Change Carrier *****/
                if (LOT.GetDouble("QTY_1") > 0 || LOT.GetDouble("QTY_2") > 0 || LOT.GetDouble("QTY_3") > 0)
                {
                    if (CheckResourcePortAndCarrierChange(ref in_node) == false) return false;
                    if (in_node.GetList("CHANGE_PORT_STATUS").Count > 0)
                    {
                        in_node.AddString("SUBRES_ID", in_node.GetList("CHANGE_PORT_STATUS")[0].GetString("SUBRES_ID"));
                        in_node.AddString("PORT_ID", in_node.GetList("CHANGE_PORT_STATUS")[0].GetString("PORT_ID"));
                    }
                }
                /***** End Check Input Port and Change Carrier *****/


                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                if (MPCR.CheckTranAlarmRelation(this,
                                                MPGC.MP_ALM_TRAN_REWORK,
                                                LOT.GetString("MAT_ID"),
                                                LOT.GetInt("MAT_VER"),
                                                LOT.GetString("FLOW"),
                                                LOT.GetString("OPER"),
                                                LOT.GetString("LOT_ID"),
                                                "END_LOT",
                                                MPCF.Trim(cdvResID.Text),
                                                ref b_proc_alarm_action) == false)
                {
                    return false;
                }

                if (b_proc_alarm_action == true)
                    in_node.AddChar("PROC_ALARM_FLAG", 'Y');
                /***** End Check Transaction Confirm Message *****/


                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("RWK_CODE", MPCF.Trim(cdvReworkCode.Text));
                in_node.AddString("TO_FLOW", MPCF.Trim(cdvReworkFlow.Text));
                in_node.AddInt("TO_FLOW_SEQ_NUM", cdvReworkFlow.Sequence);
                in_node.AddString("TO_OPER", MPCF.Trim(cdvReworkOper.Text));
                in_node.AddString("STOP_OPER", MPCF.Trim(cdvReworkStopOper.Text));
                in_node.AddString("RET_FLOW", MPCF.Trim(cdvReturnFlow.Text));
                in_node.AddInt("RET_FLOW_SEQ_NUM", cdvReturnFlow.Sequence);
                in_node.AddString("RET_OPER", MPCF.Trim(cdvReturnOper.Text));
                in_node.AddString("CAUSE_FLOW", MPCF.Trim(cdvCauseFlow.Text));
                in_node.AddString("CAUSE_OPER", MPCF.Trim(cdvCauseOper.Text));
                in_node.AddString("CAUSE_RES_ID", MPCF.Trim(cdvCauseRes.Text));

                switch (cboReturnOption.SelectedIndex)
                {
                    case 0: // Keep Rework
                        in_node.AddChar("RWK_RET_CLEAR_FLAG", ' ');
                        break;
                    case 1: // Clear Rework
                        in_node.AddChar("RWK_RET_CLEAR_FLAG", 'Y');
                        break;
                    case 2: // Clear Rework and Move to Next Oper
                        in_node.AddChar("RWK_RET_CLEAR_FLAG", 'A');
                        break;
                    case 3: // Keep Rework and Move to Next Oper
                        in_node.AddChar("RWK_RET_CLEAR_FLAG", 'B');
                        break;
                }

                in_node.AddString("CHECK_USER_1", MPCF.Trim(txtChkUser1.Text), true);
                in_node.AddString("CHECK_USER_2", MPCF.Trim(txtChkUser2.Text), true);

                in_node.AddDouble("QTY_1", (txtNewQty1.Text == "") ? - 1 : (MPCF.ToDbl(txtNewQty1.Text)));
                in_node.AddDouble("QTY_2", (txtNewQty2.Text == "") ? - 1 : (MPCF.ToDbl(txtNewQty2.Text)));
                in_node.AddDouble("QTY_3", (txtNewQty3.Text == "") ? - 1 : (MPCF.ToDbl(txtNewQty3.Text)));

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

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("WIP", "WIP_Rework_Lot", in_node, ref out_node) == false)
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

        private bool CheckResourcePortAndCarrierChange(ref TRSNode in_node)
        {
            bool b_have_port;
            bool b_change_carrier;
            frmWIPTranChangePortCarrier frmChangePortCarrier;
            TRSNode port_in = null;
            TRSNode crr_in = null;

            b_have_port = false;
            b_change_carrier = false;
            if (MPGO.ChangePortStateWithLotTran() == true && MPCF.Trim(cdvResID.Text) != "")
            {
                if (MPCR.CheckResourceHavePort(cdvResID.Text, ref b_have_port) == false)
                {
                    return false;
                }
            }
            if (MPCR.CheckCarrierChangeOption(LOT.GetString("MAT_ID"),
                                           LOT.GetInt("MAT_VER"),
                                           LOT.GetString("FLOW"),
                                           LOT.GetString("OPER"),
                                           'E',
                                           ref b_change_carrier) == false)
            {
                return false;
            }

            if (b_have_port == false && b_change_carrier == false) return true;

            frmChangePortCarrier = new frmWIPTranChangePortCarrier();

            if (b_have_port == true && b_change_carrier == true)
            {
                frmChangePortCarrier.SetLayout(ChangePortCarrierLayout.PORT_and_CARRIER);
                port_in = in_node.AddNode("CHANGE_PORT_STATUS");
                crr_in = in_node.AddNode("CHANGE_CARRIER");
            }
            else if (b_have_port == true && b_change_carrier == false)
            {
                frmChangePortCarrier.SetLayout(ChangePortCarrierLayout.PORT);
                port_in = in_node.AddNode("CHANGE_PORT_STATUS");
            }
            else if (b_have_port == false && b_change_carrier == true)
            {
                frmChangePortCarrier.SetLayout(ChangePortCarrierLayout.CARRIER);
                crr_in = in_node.AddNode("CHANGE_CARRIER");
            }

            {
                string s_started_port_id = "";

                if (LOT.GetChar("START_FLAG") == 'Y' && LOT.GetString("START_RES_ID").Equals(cdvResID.Text))
                {
                    s_started_port_id = LOT.GetString("PORT_ID");
                }

                frmChangePortCarrier.SetInformation(LOT.GetString("LOT_ID"),
                                                    LOT.GetString("LOT_DESC"),
                                                    LOT.GetString("MAT_ID"),
                                                    LOT.GetInt("MAT_VER"),
                                                    LOT.GetString("FLOW"),
                                                    LOT.GetString("OPER"),
                                                    cdvResID.Text,
                                                    'E',
                                                    s_started_port_id,
                                                    ref port_in,
                                                    ref crr_in);
            }

            if (frmChangePortCarrier.ShowDialog(this) != DialogResult.OK) return false;

            if (frmChangePortCarrier.IsDisposed == false)
                frmChangePortCarrier.Dispose();

            return true;
        }
        
        #endregion
        
        private void frmWIPTranReworkLot_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_REWORK);
                    
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
                if (CheckCondition("REWORK_LOT") == false) return;
                
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_REWORK, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'B') == false) return;
                if (Rework_Lot('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_REWORK, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'A') == false) return;

                ClearData("2");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvReworkFlow_ButtonPress(object sender, System.EventArgs e)
        {

            if (MPCF.CheckValue(txtLotID, 1) == false) return;
            
            if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                return;
            }
            //if (MPCF.Trim(LOT.GetString("FLOW")) == "")
            //{
            //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Flow]");
            //    return;
            //}
            //if (MPCF.Trim(LOT.GetString("OPER")) == "")
            //{
            //    MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
            //    return;
            //}

            cdvReworkFlow.ListCond_MatID = LOT.GetString("MAT_ID");
            cdvReworkFlow.ListCond_MatVersion = LOT.GetInt("MAT_VER");
            cdvReworkFlow.RefuseEventExec = true;

            if (ViewReworkFlowList() == false)
            {
                return;
            }
        }
        
        private void cdvReworkFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvReworkOper.Text = "";
            cdvReworkStopOper.Text = "";
            cdvReturnFlow.Text = "";
            cdvReturnOper.Text = "";
        }
        
        private void cdvReworkOper_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvReworkOper.IsPopup = false;
                txtLotID.Focus();
                return;
            }
            if (MPCF.Trim(LOT.GetString("MAT_ID")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Material]");
                cdvReworkOper.IsPopup = false;
                return;
            }

            if (MPCF.Trim(cdvReworkFlow.Text) == "")
                GetOperationList(cdvReworkOper, "");
            else
                GetReworkOperList();
        }

        private void cdvReworkStopOper_ButtonPress(object sender, EventArgs e)
        {
            cdvReworkStopOper.Init();
            MPCF.InitListView(cdvReworkStopOper.GetListView);
            cdvReworkStopOper.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvReworkStopOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvReworkStopOper.SelectedSubItemIndex = 0;

            if (MPCF.Trim(cdvReworkFlow.Text) == "")
            {
                WIPLIST.ViewOperationList(cdvReworkStopOper.GetListView, '2', LOT.GetString("FLOW"));
            }
            else
            {
                WIPLIST.ViewOperationList(cdvReworkStopOper.GetListView, '2', cdvReworkFlow.Text);
            }
            cdvReworkStopOper.InsertEmptyRow(0, 1);
        }

        private void cdvReturnFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtLotID, 1) == false) return;

            cdvReturnFlow.ListCond_Step = '1';
            cdvReturnFlow.ListCond_MatID = "";
            cdvReturnFlow.ListCond_MatVersion = 0;
        }
        
        private void cdvReturnFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvReturnOper.Text = "";
            if (MPCF.Trim(cdvReturnFlow.Text) != "")
            {
                cdvReturnFlow.ListCond_Step = '2';
            }
            
        }

        private void cdvReturnFlow_SeqButtonPress(object sender, EventArgs e)
        {
            cdvReturnFlow.ListCond_MatID = LOT.GetString("MAT_ID");
            cdvReturnFlow.ListCond_MatVersion = LOT.GetInt("MAT_VER");
        }
        
        private void cdvReturnOper_ButtonPress(object sender, System.EventArgs e)
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
            
            if (GetOperationList(cdvReturnOper, cdvReturnFlow.Text) == false)
            {
                return;
            }
            
        }
        
        private void cdvCauseFlow_ButtonPress(object sender, System.EventArgs e)
        {

            if (MPCF.CheckValue(txtLotID, 1) == false) return;
            
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

            if (MPCF.CheckValue(txtLotID, 1) == false) return;
            if (MPCF.CheckValue(cdvCauseFlow, 1) == false) return;
            
            if (GetOperationList(cdvCauseOper, cdvCauseFlow.Text) == false)
            {
                return;
            }
            
        }
        
        private void cdvCauseRes_ButtonPress(object sender, System.EventArgs e)
        {

            if (MPCF.CheckValue(txtLotID, 1) == false) return;
            if (MPCF.CheckValue(cdvCauseOper, 1) == false) return;

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
        
        private void cdvReworkOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvReturnFlow.Text = "";
            cdvReturnOper.Text = "";
            
            if (ViewReturnFlowOper() == false)
            {
                return;
            }
            
        }
        
        private void cdvReworkCode_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvReworkFlow.Text = "";
            cdvReworkOper.Text = "";
            cdvReworkStopOper.Text = "";
            cdvReturnFlow.Text = "";
            cdvReturnOper.Text = "";

            if (ViewReworkFlowOperByCode(LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), cdvReworkCode.Text) == false)
            {
                return;
            }

            cdvReworkFlow.ListCond_MatID = LOT.GetString("MAT_ID");
            cdvReworkFlow.ListCond_MatVersion = LOT.GetInt("MAT_VER");
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
