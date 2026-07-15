
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranRepairLot.vb
//   Description : Repair Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetCauseOperationList() : Get Operation List
//       - GetRepairOper : Get Repair Oper List
//       - ViewRepairOperList() : View Operation List
//       - ViewReturnOper() : View Return Oper List
//       - Repair_Lot() : Repair Lot transaction
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
    public class frmWIPTranRepairLot : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranRepairLot()
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
        



        private System.Windows.Forms.GroupBox grpRepair;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvReturnOper;
        private System.Windows.Forms.Label lblRetOper;
        private System.Windows.Forms.Label lblRepairOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseRes;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseOper;
        private System.Windows.Forms.Label lblCauseRes;
        private System.Windows.Forms.Label lblCauseOper;
        private System.Windows.Forms.Label lblRepairCode;
        private System.Windows.Forms.TextBox txtChkUser2;
        private System.Windows.Forms.TextBox txtChkUser1;
        private System.Windows.Forms.Label lblUser1;
        private System.Windows.Forms.Label lblUser2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRepairOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRepairCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCauseFlow;
        private System.Windows.Forms.Label lblCauseFlow;
        private System.Windows.Forms.Label lblQty23;
        private System.Windows.Forms.TextBox txtNewQty3;
        private System.Windows.Forms.TextBox txtNewQty2;
        private System.Windows.Forms.TextBox txtNewQty1;
        private System.Windows.Forms.Label lblQty1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.grpRepair = new System.Windows.Forms.GroupBox();
            this.lblQty23 = new System.Windows.Forms.Label();
            this.txtNewQty3 = new System.Windows.Forms.TextBox();
            this.txtNewQty2 = new System.Windows.Forms.TextBox();
            this.txtNewQty1 = new System.Windows.Forms.TextBox();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.cdvCauseFlow = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCauseFlow = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvReturnOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRetOper = new System.Windows.Forms.Label();
            this.cdvRepairOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRepairOper = new System.Windows.Forms.Label();
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
            this.grpRepair.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReturnOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRepairOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRepairCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpRepair);
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
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Tag = "WIP2023";
            this.lblFormTitle.Text = "Repair Lot";
            // 
            // grpRepair
            // 
            this.grpRepair.Controls.Add(this.lblQty23);
            this.grpRepair.Controls.Add(this.txtNewQty3);
            this.grpRepair.Controls.Add(this.txtNewQty2);
            this.grpRepair.Controls.Add(this.txtNewQty1);
            this.grpRepair.Controls.Add(this.lblQty1);
            this.grpRepair.Controls.Add(this.cdvCauseFlow);
            this.grpRepair.Controls.Add(this.lblCauseFlow);
            this.grpRepair.Controls.Add(this.cdvResID);
            this.grpRepair.Controls.Add(this.lblResID);
            this.grpRepair.Controls.Add(this.cdvReturnOper);
            this.grpRepair.Controls.Add(this.lblRetOper);
            this.grpRepair.Controls.Add(this.cdvRepairOper);
            this.grpRepair.Controls.Add(this.lblRepairOper);
            this.grpRepair.Controls.Add(this.cdvCauseRes);
            this.grpRepair.Controls.Add(this.cdvCauseOper);
            this.grpRepair.Controls.Add(this.lblCauseRes);
            this.grpRepair.Controls.Add(this.lblCauseOper);
            this.grpRepair.Controls.Add(this.cdvRepairCode);
            this.grpRepair.Controls.Add(this.lblRepairCode);
            this.grpRepair.Controls.Add(this.txtChkUser2);
            this.grpRepair.Controls.Add(this.txtChkUser1);
            this.grpRepair.Controls.Add(this.lblUser1);
            this.grpRepair.Controls.Add(this.lblUser2);
            this.grpRepair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRepair.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRepair.Location = new System.Drawing.Point(0, 0);
            this.grpRepair.Name = "grpRepair";
            this.grpRepair.Size = new System.Drawing.Size(722, 242);
            this.grpRepair.TabIndex = 0;
            this.grpRepair.TabStop = false;
            // 
            // lblQty23
            // 
            this.lblQty23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty23.Location = new System.Drawing.Point(64, 116);
            this.lblQty23.Name = "lblQty23";
            this.lblQty23.Size = new System.Drawing.Size(48, 13);
            this.lblQty23.TabIndex = 9;
            this.lblQty23.Text = "/ 2/ 3";
            this.lblQty23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNewQty3
            // 
            this.txtNewQty3.Location = new System.Drawing.Point(252, 112);
            this.txtNewQty3.MaxLength = 11;
            this.txtNewQty3.Name = "txtNewQty3";
            this.txtNewQty3.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty3.TabIndex = 12;
            this.txtNewQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewQty2
            // 
            this.txtNewQty2.Location = new System.Drawing.Point(185, 112);
            this.txtNewQty2.MaxLength = 11;
            this.txtNewQty2.Name = "txtNewQty2";
            this.txtNewQty2.Size = new System.Drawing.Size(66, 20);
            this.txtNewQty2.TabIndex = 11;
            this.txtNewQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewQty1
            // 
            this.txtNewQty1.Location = new System.Drawing.Point(118, 112);
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
            this.lblQty1.Location = new System.Drawing.Point(12, 116);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(57, 13);
            this.lblQty1.TabIndex = 8;
            this.lblQty1.Text = "New Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvCauseFlow.TabIndex = 14;
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
            this.lblCauseFlow.TabIndex = 13;
            this.lblCauseFlow.Text = "Cause Flow";
            this.lblCauseFlow.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.lblResID.Location = new System.Drawing.Point(12, 91);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 6;
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
            this.cdvReturnOper.Location = new System.Drawing.Point(118, 64);
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
            this.cdvReturnOper.TabIndex = 5;
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
            this.lblRetOper.Location = new System.Drawing.Point(12, 67);
            this.lblRetOper.Name = "lblRetOper";
            this.lblRetOper.Size = new System.Drawing.Size(65, 13);
            this.lblRetOper.TabIndex = 4;
            this.lblRetOper.Text = "Return Oper";
            this.lblRetOper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvRepairOper
            // 
            this.cdvRepairOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRepairOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRepairOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRepairOper.BtnToolTipText = "";
            this.cdvRepairOper.DescText = "";
            this.cdvRepairOper.DisplaySubItemIndex = -1;
            this.cdvRepairOper.DisplayText = "";
            this.cdvRepairOper.Focusing = null;
            this.cdvRepairOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRepairOper.Index = 0;
            this.cdvRepairOper.IsViewBtnImage = false;
            this.cdvRepairOper.Location = new System.Drawing.Point(118, 40);
            this.cdvRepairOper.MaxLength = 10;
            this.cdvRepairOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRepairOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRepairOper.Name = "cdvRepairOper";
            this.cdvRepairOper.ReadOnly = false;
            this.cdvRepairOper.SearchSubItemIndex = 0;
            this.cdvRepairOper.SelectedDescIndex = -1;
            this.cdvRepairOper.SelectedSubItemIndex = -1;
            this.cdvRepairOper.SelectionStart = 0;
            this.cdvRepairOper.Size = new System.Drawing.Size(200, 20);
            this.cdvRepairOper.SmallImageList = null;
            this.cdvRepairOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRepairOper.TabIndex = 3;
            this.cdvRepairOper.TextBoxToolTipText = "";
            this.cdvRepairOper.TextBoxWidth = 200;
            this.cdvRepairOper.VisibleButton = true;
            this.cdvRepairOper.VisibleColumnHeader = false;
            this.cdvRepairOper.VisibleDescription = false;
            this.cdvRepairOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRepairOper_SelectedItemChanged);
            this.cdvRepairOper.ButtonPress += new System.EventHandler(this.cdvRepairOper_ButtonPress);
            // 
            // lblRepairOper
            // 
            this.lblRepairOper.AutoSize = true;
            this.lblRepairOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRepairOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepairOper.Location = new System.Drawing.Point(12, 43);
            this.lblRepairOper.Name = "lblRepairOper";
            this.lblRepairOper.Size = new System.Drawing.Size(75, 13);
            this.lblRepairOper.TabIndex = 2;
            this.lblRepairOper.Text = "Repair Oper";
            this.lblRepairOper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.cdvCauseRes.TabIndex = 18;
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
            this.cdvCauseOper.TabIndex = 16;
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
            this.lblCauseRes.TabIndex = 17;
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
            this.lblCauseOper.TabIndex = 15;
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
            this.txtChkUser2.TabIndex = 22;
            // 
            // txtChkUser1
            // 
            this.txtChkUser1.Location = new System.Drawing.Point(458, 88);
            this.txtChkUser1.MaxLength = 20;
            this.txtChkUser1.Name = "txtChkUser1";
            this.txtChkUser1.Size = new System.Drawing.Size(200, 20);
            this.txtChkUser1.TabIndex = 20;
            // 
            // lblUser1
            // 
            this.lblUser1.AutoSize = true;
            this.lblUser1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser1.Location = new System.Drawing.Point(352, 91);
            this.lblUser1.Name = "lblUser1";
            this.lblUser1.Size = new System.Drawing.Size(86, 13);
            this.lblUser1.TabIndex = 19;
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
            this.lblUser2.TabIndex = 21;
            this.lblUser2.Text = "Check User ID 2";
            this.lblUser2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // frmWIPTranRepairLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranRepairLot";
            this.Text = "Repair Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranRepairLot_Activated);
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
            this.grpRepair.ResumeLayout(false);
            this.grpRepair.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvReturnOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRepairOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCauseOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRepairCode)).EndInit();
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
            cdvResID.Items.Clear();

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            cdvResID.Text = LOT.GetString("START_RES_ID");

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
                case "REPAIR_LOT":

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
                    if (cdvRepairOper.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvRepairOper.Focus();
                        return false;
                    }
                    if (cdvRepairCode.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvRepairCode.Focus();
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
        // GetCauseOperationList()
        //       - Get Operation List by Flow
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow
        //
        private bool GetCauseOperationList(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList, string sFlow)
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
        
        //
        // GetRepairOperList()
        //       - Get Repair Oper List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool GetRepairOperList()
        {
            
            try
            {
                cdvRepairOper.Init();
                MPCF.InitListView(cdvRepairOper.GetListView);
                cdvRepairOper.Columns.Add("Oper", 50, HorizontalAlignment.Left);
                cdvRepairOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvRepairOper.SelectedSubItemIndex = 0;
                
                if (ViewRepairOperList('1', cdvRepairOper.GetListView, LOT.GetString("OPER")) == false)
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
        // ViewRepairOperList()
        //       -  View Repair Oper List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String : Process Step
        //       - ByVal Form_control As Control : Control
        //       - ByVal sOper As String : Operation
        //
        public bool ViewRepairOperList(char c_step, Control Form_control, string sOper)
        {

            ListViewItem itmX;
            int i;

            TRSNode in_node = new TRSNode("VIEW_REPAIR_OPER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REPAIR_OPER_LIST_OUT");

            MPCF.InitListView((ListView)Form_control);
            MPCF.ClearList(Form_control, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddString("OPER", MPCF.Trim(sOper));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Repair_Oper_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (Form_control is ListView)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("REP_OPER"), (int)SMALLICON_INDEX.IDX_FLOW);
                        itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("REP_OPER_DESC")));
                        ((ListView) Form_control).Items.Add(itmX);
                    }
                }

                in_node.SetString("NEXT_REP_OPER", out_node.GetString("NEXT_REP_OPER"));

            } while (in_node.GetString("NEXT_REP_OPER") != "");

            return true;

        }

        //
        // ViewReturnOper()
        //       -  View Return Oper List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String : Process Step
        //       - ByVal sOper As String : Operation
        //       - ByVal sRepOper As String : Repair Operation
        //
        public bool ViewReturnOper(char c_step, string sOper, string sRepOper)
        {

            TRSNode in_node = new TRSNode("VIEW_REPAIR_OPER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_REPAIR_OPER_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddString("OPER", MPCF.Trim(sOper));
            in_node.AddString("NEXT_REP_OPER", MPCF.Trim(sRepOper));

            if (MPCR.CallService("WIP", "WIP_View_Repair_Oper_List", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvReturnOper.Text = MPCF.Trim(out_node.GetList(0)[0].GetString("RET_OPER"));

            return true;

        }

        //
        // Repair_Lot()
        //       - Repair Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Repair_Lot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("REPAIR_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

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

                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", LOT.GetInt("LAST_ACTIVE_HIST_SEQ"));
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("REPAIR_CODE_1", MPCF.Trim(cdvRepairCode.Text));
                in_node.AddString("TO_OPER", MPCF.Trim(cdvRepairOper.Text));
                in_node.AddString("RET_OPER", MPCF.Trim(cdvReturnOper.Text));

                in_node.AddDouble("QTY_1", (txtNewQty1.Text == "") ? - 1 : (MPCF.ToDbl(txtNewQty1.Text)));
                in_node.AddDouble("QTY_2", (txtNewQty2.Text == "") ? - 1 : (MPCF.ToDbl(txtNewQty2.Text)));
                in_node.AddDouble("QTY_3", (txtNewQty3.Text == "") ? - 1 : (MPCF.ToDbl(txtNewQty3.Text)));

                in_node.AddString("CAUSE_FLOW", MPCF.Trim(cdvCauseFlow.Text));
                in_node.AddString("CAUSE_OPER", MPCF.Trim(cdvCauseOper.Text));
                in_node.AddString("CAUSE_RES_ID", MPCF.Trim(cdvCauseRes.Text));
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

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("WIP", "WIP_Repair_Lot", in_node, ref out_node) == false)
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
            if (LOT.GetDouble("QTY_1") > 0 || LOT.GetDouble("QTY_2") > 0 || LOT.GetDouble("QTY_3") > 0)
            {
                if (MPCR.CheckCarrierChangeOption(LOT.GetString("MAT_ID"),
                                               LOT.GetInt("MAT_VER"),
                                               LOT.GetString("FLOW"),
                                               LOT.GetString("OPER"),
                                               'E',
                                               ref b_change_carrier) == false)
                {
                    return false;
                }
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
        
        private void frmWIPTranRepairLot_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_REPAIR);
                    
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
                if (CheckCondition("REPAIR_LOT") == false) return;
                
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_REPAIR, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'B') == false) return;
                if (Repair_Lot('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_REPAIR, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "", 'A') == false) return;

                ClearData("2");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvRepairOper_ButtonPress(object sender, System.EventArgs e)
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
            if (MPCF.Trim(LOT.GetString("OPER")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                return;
            }
            
            if (GetRepairOperList() == false)
            {
                return;
            }
            
        }
        
        private void cdvRepairOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (ViewReturnOper('2', LOT.GetString("OPER"), cdvRepairOper.Text) == false)
            {
                return;
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
            
            if (GetCauseOperationList(cdvCauseOper, cdvCauseFlow.Text) == false)
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
        
        private void cdvReturnOper_ButtonPress(object sender, System.EventArgs e)
        {
            
            cdvReturnOper.Init();
            MPCF.InitListView(cdvReturnOper.GetListView);
            cdvReturnOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvReturnOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvReturnOper.SelectedSubItemIndex = 0;
            
            WIPLIST.ViewOperationList(cdvReturnOper.GetListView, '1', "", 0,"", "", null, "");
            
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
