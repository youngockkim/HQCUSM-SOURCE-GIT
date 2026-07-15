
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranReleaseLot.vb
//   Description : Release Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - View_Lot_Info() : View Lot Information
//       - Release_Lot() : Release Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-18 : Created by CM Koo
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
    public class frmWIPTranReleaseLotByForce : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranReleaseLotByForce()
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
        private System.Windows.Forms.Label lblHoldCode;
        private System.Windows.Forms.GroupBox grpTranInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvReleaseCode;
        private System.Windows.Forms.Label lblReleaseCode;
        private UI.Controls.MCCodeView.MCCodeView cdvBinReleaseCode;
        private Label lblBinReleaseCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvHoldCode;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.lblHoldCode = new System.Windows.Forms.Label();
            this.grpTranInfo = new System.Windows.Forms.GroupBox();
            this.cdvHoldCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvReleaseCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblReleaseCode = new System.Windows.Forms.Label();
            this.cdvBinReleaseCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblBinReleaseCode = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReleaseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBinReleaseCode)).BeginInit();
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
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
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
            this.pnlComment.TabIndex = 2;
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
            this.txtTranDateTime.TabStop = true;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.TabStop = false;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
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
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Release Lot";
            // 
            // lblHoldCode
            // 
            this.lblHoldCode.AutoSize = true;
            this.lblHoldCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHoldCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoldCode.Location = new System.Drawing.Point(12, 19);
            this.lblHoldCode.Name = "lblHoldCode";
            this.lblHoldCode.Size = new System.Drawing.Size(57, 13);
            this.lblHoldCode.TabIndex = 0;
            this.lblHoldCode.Text = "Hold Code";
            // 
            // grpTranInfo
            // 
            this.grpTranInfo.Controls.Add(this.cdvBinReleaseCode);
            this.grpTranInfo.Controls.Add(this.lblBinReleaseCode);
            this.grpTranInfo.Controls.Add(this.cdvHoldCode);
            this.grpTranInfo.Controls.Add(this.cdvReleaseCode);
            this.grpTranInfo.Controls.Add(this.lblReleaseCode);
            this.grpTranInfo.Controls.Add(this.lblHoldCode);
            this.grpTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTranInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTranInfo.Location = new System.Drawing.Point(0, 0);
            this.grpTranInfo.Name = "grpTranInfo";
            this.grpTranInfo.Size = new System.Drawing.Size(722, 235);
            this.grpTranInfo.TabIndex = 0;
            this.grpTranInfo.TabStop = false;
            // 
            // cdvHoldCode
            // 
            this.cdvHoldCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvHoldCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvHoldCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvHoldCode.BtnToolTipText = "";
            this.cdvHoldCode.DescText = "";
            this.cdvHoldCode.DisplaySubItemIndex = -1;
            this.cdvHoldCode.DisplayText = "";
            this.cdvHoldCode.Focusing = null;
            this.cdvHoldCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvHoldCode.Index = 0;
            this.cdvHoldCode.IsViewBtnImage = false;
            this.cdvHoldCode.Location = new System.Drawing.Point(118, 16);
            this.cdvHoldCode.MaxLength = 10;
            this.cdvHoldCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvHoldCode.Name = "cdvHoldCode";
            this.cdvHoldCode.ReadOnly = false;
            this.cdvHoldCode.SearchSubItemIndex = 0;
            this.cdvHoldCode.SelectedDescIndex = -1;
            this.cdvHoldCode.SelectedSubItemIndex = -1;
            this.cdvHoldCode.SelectionStart = 0;
            this.cdvHoldCode.Size = new System.Drawing.Size(200, 20);
            this.cdvHoldCode.SmallImageList = null;
            this.cdvHoldCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvHoldCode.TabIndex = 1;
            this.cdvHoldCode.TextBoxToolTipText = "";
            this.cdvHoldCode.TextBoxWidth = 200;
            this.cdvHoldCode.VisibleButton = true;
            this.cdvHoldCode.VisibleColumnHeader = false;
            this.cdvHoldCode.VisibleDescription = false;
            this.cdvHoldCode.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvHoldCode_SelectedItemChanged);
            this.cdvHoldCode.TextBoxTextChanged += new System.EventHandler(this.cdvHoldCode_TextBoxTextChanged);
            // 
            // cdvReleaseCode
            // 
            this.cdvReleaseCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvReleaseCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvReleaseCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvReleaseCode.BtnToolTipText = "";
            this.cdvReleaseCode.DescText = "";
            this.cdvReleaseCode.DisplaySubItemIndex = -1;
            this.cdvReleaseCode.DisplayText = "";
            this.cdvReleaseCode.Focusing = null;
            this.cdvReleaseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvReleaseCode.Index = 0;
            this.cdvReleaseCode.IsViewBtnImage = false;
            this.cdvReleaseCode.Location = new System.Drawing.Point(118, 40);
            this.cdvReleaseCode.MaxLength = 10;
            this.cdvReleaseCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvReleaseCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvReleaseCode.Name = "cdvReleaseCode";
            this.cdvReleaseCode.ReadOnly = false;
            this.cdvReleaseCode.SearchSubItemIndex = 0;
            this.cdvReleaseCode.SelectedDescIndex = -1;
            this.cdvReleaseCode.SelectedSubItemIndex = -1;
            this.cdvReleaseCode.SelectionStart = 0;
            this.cdvReleaseCode.Size = new System.Drawing.Size(200, 20);
            this.cdvReleaseCode.SmallImageList = null;
            this.cdvReleaseCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvReleaseCode.TabIndex = 3;
            this.cdvReleaseCode.TextBoxToolTipText = "";
            this.cdvReleaseCode.TextBoxWidth = 200;
            this.cdvReleaseCode.VisibleButton = true;
            this.cdvReleaseCode.VisibleColumnHeader = false;
            this.cdvReleaseCode.VisibleDescription = false;
            this.cdvReleaseCode.ButtonPress += new System.EventHandler(this.cdvReleaseCode_ButtonPress);
            // 
            // lblReleaseCode
            // 
            this.lblReleaseCode.AutoSize = true;
            this.lblReleaseCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReleaseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleaseCode.Location = new System.Drawing.Point(12, 43);
            this.lblReleaseCode.Name = "lblReleaseCode";
            this.lblReleaseCode.Size = new System.Drawing.Size(86, 13);
            this.lblReleaseCode.TabIndex = 2;
            this.lblReleaseCode.Text = "Release Code";
            // 
            // cdvBinReleaseCode
            // 
            this.cdvBinReleaseCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBinReleaseCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBinReleaseCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvBinReleaseCode.BtnToolTipText = "";
            this.cdvBinReleaseCode.DescText = "";
            this.cdvBinReleaseCode.DisplaySubItemIndex = -1;
            this.cdvBinReleaseCode.DisplayText = "";
            this.cdvBinReleaseCode.Focusing = null;
            this.cdvBinReleaseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvBinReleaseCode.Index = 0;
            this.cdvBinReleaseCode.IsViewBtnImage = false;
            this.cdvBinReleaseCode.Location = new System.Drawing.Point(118, 80);
            this.cdvBinReleaseCode.MaxLength = 10;
            this.cdvBinReleaseCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvBinReleaseCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvBinReleaseCode.Name = "cdvBinReleaseCode";
            this.cdvBinReleaseCode.ReadOnly = true;
            this.cdvBinReleaseCode.SearchSubItemIndex = 0;
            this.cdvBinReleaseCode.SelectedDescIndex = -1;
            this.cdvBinReleaseCode.SelectedSubItemIndex = -1;
            this.cdvBinReleaseCode.SelectionStart = 0;
            this.cdvBinReleaseCode.Size = new System.Drawing.Size(200, 20);
            this.cdvBinReleaseCode.SmallImageList = null;
            this.cdvBinReleaseCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvBinReleaseCode.TabIndex = 5;
            this.cdvBinReleaseCode.TextBoxToolTipText = "";
            this.cdvBinReleaseCode.TextBoxWidth = 200;
            this.cdvBinReleaseCode.Visible = false;
            this.cdvBinReleaseCode.VisibleButton = true;
            this.cdvBinReleaseCode.VisibleColumnHeader = false;
            this.cdvBinReleaseCode.VisibleDescription = false;
            this.cdvBinReleaseCode.ButtonPress += new System.EventHandler(this.cdvBinReleaseCode_ButtonPress);
            // 
            // lblBinReleaseCode
            // 
            this.lblBinReleaseCode.AutoSize = true;
            this.lblBinReleaseCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBinReleaseCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBinReleaseCode.Location = new System.Drawing.Point(12, 84);
            this.lblBinReleaseCode.Name = "lblBinReleaseCode";
            this.lblBinReleaseCode.Size = new System.Drawing.Size(95, 13);
            this.lblBinReleaseCode.TabIndex = 4;
            this.lblBinReleaseCode.Text = "BIN Release Code";
            this.lblBinReleaseCode.Visible = false;
            // 
            // frmWIPTranReleaseLotByForce
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranReleaseLotByForce";
            this.Text = "Release By Force";
            this.Activated += new System.EventHandler(this.frmWIPTranReleaseLotByForce_Activated);
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvHoldCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReleaseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBinReleaseCode)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
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

            if (View_Lot_Hold_Code_List() == false)
            {
                txtLotID.Focus();
                return false;
            }

            return true;
        }

        // ClearData()
        //       -   Clear Form Control Data
        // Return Value
        //       -
        // Arguments
        //       -
        private void ClearData(int iStep)
        {
            
            ClearLotSpread();
            
            switch (iStep)
            {
                case 0:

                    MPCF.FieldClear(this);
                    break;
            }
        }
        
        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition()
        {

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return false;
            }
            // Not necessary. MESServer check hold password again.
            //if (MPCF.ToUpper(LOT.hold_password) != MPCF.ToUpper(txtHoldPassword.Text))
            //{
            //    MPCF.ShowMsgBox(MPCF.GetMessage(123));
            //    tabTran.SelectedTab = tbpGeneral;
            //    txtHoldPassword.Focus();
            //    return false;
            //}
            if (MPCF.CheckValue(cdvReleaseCode, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvReleaseCode.Focus();
                return false;
            }
            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }
            
            return true;
        }
        
        // Release_Lot()
        //       -   Hold Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool View_Lot_Hold_Code_List()
        {
            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("LOT_HOLD_CODE_LIST_IN");
            TRSNode out_node = new TRSNode("LOT_HOLD_CODE_LIST_OUT");

            try
            {
                cdvHoldCode.Text = "";
                cdvHoldCode.Init();
                MPCF.InitListView(cdvHoldCode.GetListView);
                cdvHoldCode.Columns.Add("Hold Code", 150, HorizontalAlignment.Left);
                cdvHoldCode.Columns.Add("Tran Time", 200, HorizontalAlignment.Left);
                cdvHoldCode.SelectedSubItemIndex = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

                if (MPCR.CallService("WIP", "WIP_View_Lot_Hold_Code_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    itmX = new ListViewItem(out_node.GetList(0)[i].GetString("HOLD_CODE"), (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME")));
                    cdvHoldCode.GetListView.Items.Add(itmX);
                }


                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }


        // Release_Lot()
        //       -   Hold Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Release_Lot()
        {
            TRSNode in_node = new TRSNode("RELEASE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("HOLD_CODE", MPCF.Trim(cdvHoldCode.Text));
                in_node.AddString("RELEASE_CODE", MPCF.Trim(cdvReleaseCode.Text));
                in_node.AddString("BIN_LOT_RELEASE_CODE", MPCF.Trim(cdvBinReleaseCode.Text));

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

                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("WIP", "WIP_Release_Lot_By_Force", in_node, ref out_node) == false)
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

        private bool CheckBinHoldLot()
        {
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("ATTR_OUT");
            string s_bin_hold_code;

            lblBinReleaseCode.Visible = false;
            cdvBinReleaseCode.Visible = false;
            cdvBinReleaseCode.Text = "";

            if (MPGO.UseBinManagement() == false)
            {
                return true;
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_LOT);
            in_node.AddString("ATTR_KEY", txtLotID.Text);
            in_node.AddString("ATTR_NAME", MPGC.MP_SYS_ATTR_BIN_HOLD_CODE);
            if (MPCR.CallService("BAS", "BAS_View_Attribute_Value", in_node, ref out_node) == false)
            {
                return false;
            }

            if (out_node.GetList("VALUE_LIST").Count > 0)
            {
                s_bin_hold_code = out_node.GetList("VALUE_LIST")[0].GetString("ATTR_VALUE");
                if (s_bin_hold_code == MPCF.Trim(cdvHoldCode.Text))
                {
                    lblBinReleaseCode.Visible = true;
                    cdvBinReleaseCode.Visible = true;
                }
            }

            return true;
        }
        
        
        #endregion
        
        private void frmWIPTranReleaseLotByForce_Activated(object sender, EventArgs e)
        {
            if (b_load_flag == false)
            {
                ClearData(0);
                SetCMFItem(MPGC.MP_CMF_TRN_RELEASE);
                
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewLotInfo(txtLotID.Text);
                }
                
                b_load_flag = true;
            }
            
        }

        private void txtLotID_TextChanged(object sender, System.EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                ClearData(0);
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition() == false) return;

            if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_RELEASE, LOT.GetString("LOT_ID"), "", "", 'B') == false) return;
            if (Release_Lot() == false) return;
            if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_RELEASE, LOT.GetString("LOT_ID"), "", "", 'A') == false) return;

            ViewLotInfo(txtLotID.Text);
        }
        
        private void cdvReleaseCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvReleaseCode.Init();
            MPCF.InitListView(cdvReleaseCode.GetListView);
            cdvReleaseCode.Columns.Add("Release Code", 150, HorizontalAlignment.Left);
            cdvReleaseCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvReleaseCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvReleaseCode.GetListView, '1', MPGC.MP_WIP_RELEASE_CODE);
        }

        private void cdvBinReleaseCode_ButtonPress(object sender, EventArgs e)
        {
            cdvBinReleaseCode.Init();
            MPCF.InitListView(cdvBinReleaseCode.GetListView);
            cdvBinReleaseCode.Columns.Add("Release Code", 150, HorizontalAlignment.Left);
            cdvBinReleaseCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvBinReleaseCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvBinReleaseCode.GetListView, '1', MPGC.MP_WIP_BIN_RELEASE_CODE, -1, null, MPGV.gsCentralFactory);
            cdvBinReleaseCode.InsertEmptyRow(0, 1);
        }

        private void cdvHoldCode_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvHoldCode.Text) == "") return;
            if (CheckBinHoldLot() == false) return;
        }

        private void cdvHoldCode_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (MPCF.Trim(cdvHoldCode.Text) == "")
            {
                lblBinReleaseCode.Visible = false;
                cdvBinReleaseCode.Visible = false;
                cdvBinReleaseCode.Text = "";
            }
        }
        
    }
    
}
