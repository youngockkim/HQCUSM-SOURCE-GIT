
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranMoveLot.vb
//   Description : Move Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetToFlowList() : Get Flow List
//       - GetToOperationList() : Get Operation List
//       - GetRetFlowList() : Get Flow List
//       - GetRetOperationList() : Get Operation List
//       - GetResourceIDList() :Get ResourceID List
//       - Move_Lot() : Move Lot transaction
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
    public class frmWIPTranMoveLot : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranMoveLot()
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
        



        private System.Windows.Forms.GroupBox grpTranInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToOperation;
        private System.Windows.Forms.Label lblToOperation;
        private Miracom.UI.Controls.MCListView.MCListView lisProcOperList;
        private System.Windows.Forms.ColumnHeader colOper;
        private System.Windows.Forms.Label lblQty23;
        private System.Windows.Forms.TextBox txtNewQty3;
        private System.Windows.Forms.TextBox txtNewQty2;
        private System.Windows.Forms.TextBox txtNewQty1;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvToFlow;
        private System.Windows.Forms.Label lblQty1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.grpTranInfo = new System.Windows.Forms.GroupBox();
            this.cdvToFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.lblQty23 = new System.Windows.Forms.Label();
            this.txtNewQty3 = new System.Windows.Forms.TextBox();
            this.txtNewQty2 = new System.Windows.Forms.TextBox();
            this.txtNewQty1 = new System.Windows.Forms.TextBox();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.lisProcOperList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdvToOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToOperation = new System.Windows.Forms.Label();
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
            this.grpTranInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOperation)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpTranInfo);
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
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "TranForm01";
            // 
            // grpTranInfo
            // 
            this.grpTranInfo.Controls.Add(this.cdvToFlow);
            this.grpTranInfo.Controls.Add(this.lblQty23);
            this.grpTranInfo.Controls.Add(this.txtNewQty3);
            this.grpTranInfo.Controls.Add(this.txtNewQty2);
            this.grpTranInfo.Controls.Add(this.txtNewQty1);
            this.grpTranInfo.Controls.Add(this.lblQty1);
            this.grpTranInfo.Controls.Add(this.lisProcOperList);
            this.grpTranInfo.Controls.Add(this.cdvToOperation);
            this.grpTranInfo.Controls.Add(this.lblToOperation);
            this.grpTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTranInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTranInfo.Location = new System.Drawing.Point(0, 0);
            this.grpTranInfo.Name = "grpTranInfo";
            this.grpTranInfo.Size = new System.Drawing.Size(722, 235);
            this.grpTranInfo.TabIndex = 0;
            this.grpTranInfo.TabStop = false;
            // 
            // cdvToFlow
            // 
            this.cdvToFlow.AddEmptyRowToLast = false;
            this.cdvToFlow.AddEmptyRowToTop = false;
            this.cdvToFlow.DisplaySubItemIndex = 0;
            this.cdvToFlow.FlowReadOnly = false;
            this.cdvToFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFlow.LabelText = "To Flow";
            this.cdvToFlow.LabelWidth = 106;
            this.cdvToFlow.ListCond_ExtFactory = "";
            this.cdvToFlow.ListCond_Step = '1';
            this.cdvToFlow.Location = new System.Drawing.Point(12, 13);
            this.cdvToFlow.Name = "cdvToFlow";
            this.cdvToFlow.SearchSubItemIndex = 0;
            this.cdvToFlow.SelectedDescIndex = -1;
            this.cdvToFlow.SelectedSubItemIndex = 0;
            this.cdvToFlow.SequenceReadOnly = false;
            this.cdvToFlow.Size = new System.Drawing.Size(306, 20);
            this.cdvToFlow.TabIndex = 0;
            this.cdvToFlow.VisibleColumnHeader = false;
            this.cdvToFlow.VisibleDescription = false;
            this.cdvToFlow.VisibleFlowButton = true;
            this.cdvToFlow.VisibleSequenceButton = true;
            this.cdvToFlow.WidthButton = 20;
            this.cdvToFlow.WidthFlowAndSequence = 200;
            this.cdvToFlow.WidthSequence = 50;
            this.cdvToFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToFlow_SelectedItemChanged);
            this.cdvToFlow.FlowButtonPress += new System.EventHandler(this.cdvToFlow_FlowButtonPress);
            // 
            // lblQty23
            // 
            this.lblQty23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty23.Location = new System.Drawing.Point(64, 70);
            this.lblQty23.Name = "lblQty23";
            this.lblQty23.Size = new System.Drawing.Size(48, 13);
            this.lblQty23.TabIndex = 4;
            this.lblQty23.Text = "/ 2/ 3";
            this.lblQty23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNewQty3
            // 
            this.txtNewQty3.Location = new System.Drawing.Point(252, 66);
            this.txtNewQty3.MaxLength = 11;
            this.txtNewQty3.Name = "txtNewQty3";
            this.txtNewQty3.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty3.TabIndex = 7;
            this.txtNewQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewQty2
            // 
            this.txtNewQty2.Location = new System.Drawing.Point(185, 66);
            this.txtNewQty2.MaxLength = 11;
            this.txtNewQty2.Name = "txtNewQty2";
            this.txtNewQty2.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty2.TabIndex = 6;
            this.txtNewQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewQty1
            // 
            this.txtNewQty1.Location = new System.Drawing.Point(118, 66);
            this.txtNewQty1.MaxLength = 11;
            this.txtNewQty1.Name = "txtNewQty1";
            this.txtNewQty1.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty1.TabIndex = 5;
            this.txtNewQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewQty1.TextChanged += new System.EventHandler(this.txtNewQty1_TextChanged);
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty1.Location = new System.Drawing.Point(12, 70);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(57, 13);
            this.lblQty1.TabIndex = 3;
            this.lblQty1.Text = "New Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisProcOperList
            // 
            this.lisProcOperList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOper});
            this.lisProcOperList.EnableSort = true;
            this.lisProcOperList.EnableSortIcon = true;
            this.lisProcOperList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisProcOperList.FullRowSelect = true;
            this.lisProcOperList.Location = new System.Drawing.Point(470, 16);
            this.lisProcOperList.Name = "lisProcOperList";
            this.lisProcOperList.Size = new System.Drawing.Size(120, 76);
            this.lisProcOperList.TabIndex = 8;
            this.lisProcOperList.TabStop = false;
            this.lisProcOperList.UseCompatibleStateImageBehavior = false;
            this.lisProcOperList.View = System.Windows.Forms.View.Details;
            this.lisProcOperList.Visible = false;
            // 
            // colOper
            // 
            this.colOper.Text = "Processed Operation";
            this.colOper.Width = 100;
            // 
            // cdvToOperation
            // 
            this.cdvToOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToOperation.BtnToolTipText = "";
            this.cdvToOperation.DescText = "";
            this.cdvToOperation.DisplaySubItemIndex = -1;
            this.cdvToOperation.DisplayText = "";
            this.cdvToOperation.Focusing = null;
            this.cdvToOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToOperation.Index = 0;
            this.cdvToOperation.IsViewBtnImage = false;
            this.cdvToOperation.Location = new System.Drawing.Point(118, 40);
            this.cdvToOperation.MaxLength = 10;
            this.cdvToOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToOperation.Name = "cdvToOperation";
            this.cdvToOperation.ReadOnly = false;
            this.cdvToOperation.SearchSubItemIndex = 0;
            this.cdvToOperation.SelectedDescIndex = -1;
            this.cdvToOperation.SelectedSubItemIndex = -1;
            this.cdvToOperation.SelectionStart = 0;
            this.cdvToOperation.Size = new System.Drawing.Size(200, 20);
            this.cdvToOperation.SmallImageList = null;
            this.cdvToOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToOperation.TabIndex = 2;
            this.cdvToOperation.TextBoxToolTipText = "";
            this.cdvToOperation.TextBoxWidth = 200;
            this.cdvToOperation.VisibleButton = true;
            this.cdvToOperation.VisibleColumnHeader = false;
            this.cdvToOperation.VisibleDescription = false;
            this.cdvToOperation.ButtonPress += new System.EventHandler(this.cdvToOperation_ButtonPress);
            // 
            // lblToOperation
            // 
            this.lblToOperation.AutoSize = true;
            this.lblToOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToOperation.Location = new System.Drawing.Point(12, 43);
            this.lblToOperation.Name = "lblToOperation";
            this.lblToOperation.Size = new System.Drawing.Size(69, 13);
            this.lblToOperation.TabIndex = 1;
            this.lblToOperation.Text = "To Operation";
            this.lblToOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmWIPTranMoveLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranMoveLot";
            this.Text = "Move Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranMoveLot_Activated);
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
            this.grpTranInfo.ResumeLayout(false);
            this.grpTranInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOperation)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        public bool bDispatcherFlag = false;
        public string sLotID = "";
        
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
            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            ViewProcOperList();
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
                case "MOVE_LOT":

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
                    //if (cdvToFlow.Text == "" && cdvToOperation.Text != "")
                    //{
                    //    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    //    tabTran.SelectedTab = tbpGeneral;
                    //    cdvToFlow.Focus();
                    //    return false;
                    //}
                    if (cdvToFlow.Text != "" && cdvToOperation.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvToOperation.Focus();
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
        // GetToOperationList()
        //       - Get Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetToOperationList(string sFlow)
        {
            
            try
            {
                cdvToOperation.Init();
                MPCF.InitListView(cdvToOperation.GetListView);
                cdvToOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvToOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvToOperation.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewOperationList(cdvToOperation.GetListView, '2', "", 0,sFlow, "", null, "") == false)
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
        
        private void ViewProcOperList()
        {
            
            WIPLIST.ViewProcessedOperationList(lisProcOperList, '1', txtLotID.Text, null);
            if (lisProcOperList.Items.Count > 0)
            {
                lisProcOperList.Visible = true;
            }
            else
            {
                lisProcOperList.Visible = false;
            }
        }
        
        //
        // Move_Lot()
        //       - Move Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Move_Lot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("MOVE_LOT_IN");
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
                in_node.AddDouble("QTY_1", (txtNewQty1.Text == "") ? -1 : (MPCF.ToDbl(txtNewQty1.Text)));
                in_node.AddDouble("QTY_2", (txtNewQty2.Text == "") ? -1 : (MPCF.ToDbl(txtNewQty2.Text)));
                in_node.AddDouble("QTY_3", (txtNewQty3.Text == "") ? -1 : (MPCF.ToDbl(txtNewQty3.Text)));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                in_node.AddString("TO_FLOW", MPCF.Trim(cdvToFlow.Text));
                in_node.AddInt("TO_FLOW_SEQ_NUM", cdvToFlow.Sequence);
                in_node.AddString("TO_OPER", MPCF.Trim(cdvToOperation.Text));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

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

                if (MPCR.CallService("WIP", "WIP_Move_Lot", in_node, ref out_node) == false)
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
        
        private void frmWIPTranMoveLot_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    SetCMFItem(MPGC.MP_CMF_TRN_MOVE);
                    
                    if (bDispatcherFlag == true)
                    {
                        if (sLotID != "")
                        {
                            txtLotID.Text = sLotID;
                            ViewLotInfo(txtLotID.Text);
                        }
                    }
                    else
                    {
                        ClearData("1");
                        
                        if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                        {
                            txtLotID.Text = MPGV.gsCurrentLot_ID;
                            ViewLotInfo(txtLotID.Text);
                        }
                    }
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvToFlow_FlowButtonPress(object sender, EventArgs e)
        {
            cdvToFlow.ListCond_Step = '1';
            cdvToFlow.ListCond_MatID = "";
            cdvToFlow.ListCond_MatVersion = 0;
        }
        
        private void cdvToFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvToOperation.Text = "";
            if (MPCF.Trim(cdvToFlow.Text) != "")
            {
                cdvToFlow.ListCond_Step = '2';
                cdvToFlow.ListCond_MatID = LOT.GetString("MAT_ID");
                cdvToFlow.ListCond_MatVersion = LOT.GetInt("MAT_VER");
            }
            
        }
        
        private void cdvToOperation_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvToFlow.Text.Trim() == "" && LOT.GetString("FLOW").Trim() == "")
            {
                cdvToOperation.Init();
                cdvToOperation.Text = "";
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvToFlow.Focus();
                return;
            }

            if (cdvToFlow.Text.Trim() != "")
            {
                if (GetToOperationList(cdvToFlow.Text) == false)
                {
                    return;
                }
            }
            else
            {
                if (GetToOperationList(LOT.GetString("FLOW")) == false)
                {
                    return;
                }
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("MOVE_LOT") == false) return;
                
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_MOVE, LOT.GetString("LOT_ID"), "", "", 'B') == false) return;
                if (Move_Lot('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_MOVE, LOT.GetString("LOT_ID"), "", "", 'A') == false) return;

                ViewLotInfo(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtNewQty1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
