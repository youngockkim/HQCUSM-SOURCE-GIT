
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranRepairEndLot.vb
//   Description : Repair End Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       -  initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - GetOperationList() : Get Operation List
//       - GetRetFlowList() : Get Return Flow List
//       - Repair_End_Lot() : Repair Lot transaction
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
    public class frmWIPTranRepairEndLot : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranRepairEndLot()
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
        



        private System.Windows.Forms.GroupBox gpbRepairEnd;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvActionCode;
        private System.Windows.Forms.Label lblActionCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResultCode;
        private System.Windows.Forms.Label lblResultCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToOperation;
        private System.Windows.Forms.Label lblToOper;
        private System.Windows.Forms.Label lblQty23;
        private System.Windows.Forms.TextBox txtNewQty3;
        private System.Windows.Forms.TextBox txtNewQty2;
        private System.Windows.Forms.TextBox txtNewQty1;
        private System.Windows.Forms.Label lblQty1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.gpbRepairEnd = new System.Windows.Forms.GroupBox();
            this.lblQty23 = new System.Windows.Forms.Label();
            this.txtNewQty3 = new System.Windows.Forms.TextBox();
            this.txtNewQty2 = new System.Windows.Forms.TextBox();
            this.txtNewQty1 = new System.Windows.Forms.TextBox();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.cdvToOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToOper = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvActionCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblActionCode = new System.Windows.Forms.Label();
            this.cdvResultCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResultCode = new System.Windows.Forms.Label();
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
            this.gpbRepairEnd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResultCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.gpbRepairEnd);
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
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
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
            this.lblFormTitle.Text = "Repair End Lot";
            // 
            // gpbRepairEnd
            // 
            this.gpbRepairEnd.Controls.Add(this.lblQty23);
            this.gpbRepairEnd.Controls.Add(this.txtNewQty3);
            this.gpbRepairEnd.Controls.Add(this.txtNewQty2);
            this.gpbRepairEnd.Controls.Add(this.txtNewQty1);
            this.gpbRepairEnd.Controls.Add(this.lblQty1);
            this.gpbRepairEnd.Controls.Add(this.cdvToOperation);
            this.gpbRepairEnd.Controls.Add(this.lblToOper);
            this.gpbRepairEnd.Controls.Add(this.cdvResID);
            this.gpbRepairEnd.Controls.Add(this.lblResID);
            this.gpbRepairEnd.Controls.Add(this.cdvActionCode);
            this.gpbRepairEnd.Controls.Add(this.lblActionCode);
            this.gpbRepairEnd.Controls.Add(this.cdvResultCode);
            this.gpbRepairEnd.Controls.Add(this.lblResultCode);
            this.gpbRepairEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbRepairEnd.Location = new System.Drawing.Point(0, 0);
            this.gpbRepairEnd.Name = "gpbRepairEnd";
            this.gpbRepairEnd.Size = new System.Drawing.Size(722, 235);
            this.gpbRepairEnd.TabIndex = 0;
            this.gpbRepairEnd.TabStop = false;
            // 
            // lblQty23
            // 
            this.lblQty23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty23.Location = new System.Drawing.Point(404, 44);
            this.lblQty23.Name = "lblQty23";
            this.lblQty23.Size = new System.Drawing.Size(48, 13);
            this.lblQty23.TabIndex = 9;
            this.lblQty23.Text = "/ 2/ 3";
            this.lblQty23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNewQty3
            // 
            this.txtNewQty3.Location = new System.Drawing.Point(592, 40);
            this.txtNewQty3.MaxLength = 11;
            this.txtNewQty3.Name = "txtNewQty3";
            this.txtNewQty3.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty3.TabIndex = 12;
            this.txtNewQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewQty2
            // 
            this.txtNewQty2.Location = new System.Drawing.Point(525, 40);
            this.txtNewQty2.MaxLength = 11;
            this.txtNewQty2.Name = "txtNewQty2";
            this.txtNewQty2.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty2.TabIndex = 11;
            this.txtNewQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewQty1
            // 
            this.txtNewQty1.Location = new System.Drawing.Point(458, 40);
            this.txtNewQty1.MaxLength = 11;
            this.txtNewQty1.Name = "txtNewQty1";
            this.txtNewQty1.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty1.TabIndex = 10;
            this.txtNewQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty1.Location = new System.Drawing.Point(352, 44);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(57, 13);
            this.lblQty1.TabIndex = 8;
            this.lblQty1.Text = "New Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvToOperation.Location = new System.Drawing.Point(458, 16);
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
            this.cdvToOperation.TabIndex = 7;
            this.cdvToOperation.TextBoxToolTipText = "";
            this.cdvToOperation.TextBoxWidth = 200;
            this.cdvToOperation.VisibleButton = true;
            this.cdvToOperation.VisibleColumnHeader = false;
            this.cdvToOperation.VisibleDescription = false;
            this.cdvToOperation.ButtonPress += new System.EventHandler(this.cdvToOperation_ButtonPress);
            // 
            // lblToOper
            // 
            this.lblToOper.AutoSize = true;
            this.lblToOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToOper.Location = new System.Drawing.Point(352, 19);
            this.lblToOper.Name = "lblToOper";
            this.lblToOper.Size = new System.Drawing.Size(69, 13);
            this.lblToOper.TabIndex = 6;
            this.lblToOper.Text = "To Operation";
            this.lblToOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvResID.Location = new System.Drawing.Point(118, 64);
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
            this.cdvResID.TabIndex = 5;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(12, 66);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 4;
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
            this.cdvActionCode.Location = new System.Drawing.Point(118, 40);
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
            this.cdvActionCode.TabIndex = 3;
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
            this.lblActionCode.Location = new System.Drawing.Point(12, 43);
            this.lblActionCode.Name = "lblActionCode";
            this.lblActionCode.Size = new System.Drawing.Size(76, 13);
            this.lblActionCode.TabIndex = 2;
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
            this.cdvResultCode.Location = new System.Drawing.Point(118, 16);
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
            this.cdvResultCode.TabIndex = 1;
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
            this.lblResultCode.Location = new System.Drawing.Point(12, 19);
            this.lblResultCode.Name = "lblResultCode";
            this.lblResultCode.Size = new System.Drawing.Size(76, 13);
            this.lblResultCode.TabIndex = 0;
            this.lblResultCode.Text = "Result Code";
            this.lblResultCode.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // frmWIPTranRepairEndLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranRepairEndLot";
            this.Text = "Repair End Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranRepairEndLot_Activated);
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
            this.gpbRepairEnd.ResumeLayout(false);
            this.gpbRepairEnd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResultCode)).EndInit();
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
            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            cdvToOperation.Text = LOT.GetString("REP_RET_OPER");
            GetResourceIDList();

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
                case "Repair_End_Lot":

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
                    if (cdvResultCode.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvResultCode.Focus();
                        return false;
                    }
                    if (cdvActionCode.Text != "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvActionCode.Focus();
                        return false;
                    }
                    if (cdvResID.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvResID.Focus();
                        return false;
                    }
                    if (cdvToOperation.Text == "")
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
        // GetRetOperationList()
        //       - Get Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetRetOperationList(string sFlow)
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
        
        //
        // GetResourceIDList()
        //       - Get ResourceID List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool GetResourceIDList()
        {
            
            try
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
                        return false;
                    }
#endif
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
        // Repair_End_Lot()
        //       - Repair Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Repair_End_Lot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("REPAIR_END_LOT_IN");
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
                in_node.AddString("TO_FLOW", "");
                in_node.AddString("TO_OPER", MPCF.Trim(cdvToOperation.Text));
                in_node.AddString("RESULT_CODE_1", MPCF.Trim(cdvResultCode.Text));
                in_node.AddString("ACTION_CODE_1", MPCF.Trim(cdvActionCode.Text));

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
                in_node.AddString("REPAIR_END_COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("WIP", "WIP_Repair_End_Lot", in_node, ref out_node) == false)
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
        
        private void frmWIPTranRepairEndLot_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    
                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_REPAIR_END);
                    
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
                if (CheckCondition("REPAIR_END_LOT") == false) return;
                
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_REPAIR_END, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'B') == false) return;
                if (Repair_End_Lot('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_REPAIR_END, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'A') == false) return;

                ClearData("2");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvToOperation_ButtonPress(System.Object sender, System.EventArgs e)
        {
            string sTmpFlow;
            sTmpFlow = LOT.GetString("FLOW");
            
            if (sTmpFlow == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108) + " - FLOW Empty.");
                return;
            }
            
            if (GetRetOperationList(sTmpFlow) == false)
            {
                return;
            }
            
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
    }
    
}
