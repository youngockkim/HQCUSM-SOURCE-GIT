
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranCreateLot.vb
//   Description : Create Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetCreateCodeList() : Get Create Code List
//       - GetOwnerCodeList() : Get Owner Code List
//       - GetLotTypeList() : Get Lot Type List
//       - GetMaterialList() : Get Material List
//       - GetFlowList() : Get Flow List
//       - GetOperationList() : Get Operation List
//       - View_Material() : View Material Information
//       - View_Operation() : View Operation Information
//       - View_Lot() : View Lot Information
//       - Create_Lot() : Create Lot transaction
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
    public class frmWIPTranCreateLot : Miracom.MESCore.TranForm05
    {

        #region " Windows Form auto generated code "

        public frmWIPTranCreateLot()
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

        //Ï∞∏Í≥†: ?§Ïùå ?ÑÎ°ú?úÏ???Windows Form ?îÏûê?¥ÎÑà???ÑÏöî?©Îãà??
        //Windows Form ?îÏûê?¥ÎÑàÎ•??¨Ïö©?òÏó¨ ?òÏ†ï?????àÏäµ?àÎã§.
        //ÏΩîÎìú ?∏ÏßëÍ∏∞Î? ?¨Ïö©?òÏó¨ ?òÏ†ï?òÏ? ÎßàÏã≠?úÏò§.
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblCreateCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOwnerCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCode;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblOwnerCode;
        private System.Windows.Forms.TextBox txtQty3;
        private System.Windows.Forms.TextBox txtQty2;
        private System.Windows.Forms.TextBox txtQty1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLotType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private System.Windows.Forms.Label lblQty1;
        private System.Windows.Forms.Label lblLotType;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.ComboBox cboPriority;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblQty2;
        private System.Windows.Forms.Label lblQty3;
        private System.Windows.Forms.CheckBox chkDueDate;
        private System.Windows.Forms.Label lblUnit3;
        private System.Windows.Forms.Label lblUnit2;
        private System.Windows.Forms.Label lblUnit1;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.TabPage tbpCreateCmf;
        private System.Windows.Forms.GroupBox grpCrtCmf;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf19;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf18;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf17;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf16;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf15;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf14;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf13;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf12;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf20;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf11;
        protected System.Windows.Forms.Label lblCrtCmf20;
        protected System.Windows.Forms.Label lblCrtCmf19;
        protected System.Windows.Forms.Label lblCrtCmf18;
        protected System.Windows.Forms.Label lblCrtCmf17;
        protected System.Windows.Forms.Label lblCrtCmf16;
        protected System.Windows.Forms.Label lblCrtCmf15;
        protected System.Windows.Forms.Label lblCrtCmf14;
        protected System.Windows.Forms.Label lblCrtCmf13;
        protected System.Windows.Forms.Label lblCrtCmf12;
        protected System.Windows.Forms.Label lblCrtCmf11;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtCmf1;
        protected System.Windows.Forms.Label lblCrtCmf10;
        protected System.Windows.Forms.Label lblCrtCmf9;
        protected System.Windows.Forms.Label lblCrtCmf8;
        protected System.Windows.Forms.Label lblCrtCmf7;
        protected System.Windows.Forms.Label lblCrtCmf6;
        protected System.Windows.Forms.Label lblCrtCmf5;
        protected System.Windows.Forms.Label lblCrtCmf4;
        protected System.Windows.Forms.Label lblCrtCmf3;
        protected System.Windows.Forms.Label lblCrtCmf2;
        protected System.Windows.Forms.Label lblCrtCmf1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCarrier;
        private System.Windows.Forms.Label lblCarrier;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Button btnGenerate;
        protected System.Windows.Forms.Button btnCalculation;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.btnCalculation = new System.Windows.Forms.Button();
            this.cdvCarrier = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCarrier = new System.Windows.Forms.Label();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.lblUnit3 = new System.Windows.Forms.Label();
            this.lblUnit2 = new System.Windows.Forms.Label();
            this.lblUnit1 = new System.Windows.Forms.Label();
            this.chkDueDate = new System.Windows.Forms.CheckBox();
            this.lblQty3 = new System.Windows.Forms.Label();
            this.lblQty2 = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.lblCreateCode = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.cdvOwnerCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblOwnerCode = new System.Windows.Forms.Label();
            this.txtQty3 = new System.Windows.Forms.TextBox();
            this.txtQty2 = new System.Windows.Forms.TextBox();
            this.txtQty1 = new System.Windows.Forms.TextBox();
            this.cdvLotType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.lblLotType = new System.Windows.Forms.Label();
            this.lblOperation = new System.Windows.Forms.Label();
            this.tbpCreateCmf = new System.Windows.Forms.TabPage();
            this.grpCrtCmf = new System.Windows.Forms.GroupBox();
            this.cdvCrtCmf19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrtCmf20 = new System.Windows.Forms.Label();
            this.lblCrtCmf19 = new System.Windows.Forms.Label();
            this.lblCrtCmf18 = new System.Windows.Forms.Label();
            this.lblCrtCmf17 = new System.Windows.Forms.Label();
            this.lblCrtCmf16 = new System.Windows.Forms.Label();
            this.lblCrtCmf15 = new System.Windows.Forms.Label();
            this.lblCrtCmf14 = new System.Windows.Forms.Label();
            this.lblCrtCmf13 = new System.Windows.Forms.Label();
            this.lblCrtCmf12 = new System.Windows.Forms.Label();
            this.lblCrtCmf11 = new System.Windows.Forms.Label();
            this.cdvCrtCmf9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtCmf1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrtCmf10 = new System.Windows.Forms.Label();
            this.lblCrtCmf9 = new System.Windows.Forms.Label();
            this.lblCrtCmf8 = new System.Windows.Forms.Label();
            this.lblCrtCmf7 = new System.Windows.Forms.Label();
            this.lblCrtCmf6 = new System.Windows.Forms.Label();
            this.lblCrtCmf5 = new System.Windows.Forms.Label();
            this.lblCrtCmf4 = new System.Windows.Forms.Label();
            this.lblCrtCmf3 = new System.Windows.Forms.Label();
            this.lblCrtCmf2 = new System.Windows.Forms.Label();
            this.lblCrtCmf1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
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
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCarrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            this.tbpCreateCmf.SuspendLayout();
            this.grpCrtCmf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 422);
            // 
            // pnlTran
            // 
            this.pnlTran.Controls.Add(this.grpGeneral);
            this.pnlTran.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlTran.Size = new System.Drawing.Size(722, 383);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 386);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // lblComment
            // 
            this.lblComment.Location = new System.Drawing.Point(15, 15);
            // 
            // grpCMF
            // 
            this.grpCMF.Size = new System.Drawing.Size(722, 419);
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
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 1);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpCreateCmf);
            this.tabTran.Size = new System.Drawing.Size(736, 448);
            this.tabTran.Controls.SetChildIndex(this.tbpCreateCmf, 0);
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
            this.txtLotDesc.ReadOnly = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Visible = false;
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 451);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.btnGenerate);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotID, 0);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotID, 0);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.pnlTranTime, 0);
            this.grpTranTop.Controls.SetChildIndex(this.btnGenerate, 0);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Create Lot";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.cdvFlow);
            this.grpGeneral.Controls.Add(this.cdvMaterial);
            this.grpGeneral.Controls.Add(this.btnCalculation);
            this.grpGeneral.Controls.Add(this.cdvCarrier);
            this.grpGeneral.Controls.Add(this.lblCarrier);
            this.grpGeneral.Controls.Add(this.txtDueDate);
            this.grpGeneral.Controls.Add(this.lblUnit3);
            this.grpGeneral.Controls.Add(this.lblUnit2);
            this.grpGeneral.Controls.Add(this.lblUnit1);
            this.grpGeneral.Controls.Add(this.chkDueDate);
            this.grpGeneral.Controls.Add(this.lblQty3);
            this.grpGeneral.Controls.Add(this.lblQty2);
            this.grpGeneral.Controls.Add(this.cboPriority);
            this.grpGeneral.Controls.Add(this.lblCreateCode);
            this.grpGeneral.Controls.Add(this.dtpDueDate);
            this.grpGeneral.Controls.Add(this.cdvOwnerCode);
            this.grpGeneral.Controls.Add(this.cdvCreateCode);
            this.grpGeneral.Controls.Add(this.lblPriority);
            this.grpGeneral.Controls.Add(this.lblOwnerCode);
            this.grpGeneral.Controls.Add(this.txtQty3);
            this.grpGeneral.Controls.Add(this.txtQty2);
            this.grpGeneral.Controls.Add(this.txtQty1);
            this.grpGeneral.Controls.Add(this.cdvLotType);
            this.grpGeneral.Controls.Add(this.cdvOperation);
            this.grpGeneral.Controls.Add(this.lblQty1);
            this.grpGeneral.Controls.Add(this.lblLotType);
            this.grpGeneral.Controls.Add(this.lblOperation);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(3, 3);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(716, 380);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 106;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(12, 39);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(306, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 200;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_FlowButtonPress);
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(12, 15);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(306, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 106;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            this.cdvMaterial.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            // 
            // btnCalculation
            // 
            this.btnCalculation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCalculation.Location = new System.Drawing.Point(584, 111);
            this.btnCalculation.Name = "btnCalculation";
            this.btnCalculation.Size = new System.Drawing.Size(74, 22);
            this.btnCalculation.TabIndex = 23;
            this.btnCalculation.Text = "Calculation";
            this.btnCalculation.Click += new System.EventHandler(this.btnCalculation_Click);
            // 
            // cdvCarrier
            // 
            this.cdvCarrier.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCarrier.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCarrier.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCarrier.BtnToolTipText = "";
            this.cdvCarrier.DescText = "";
            this.cdvCarrier.DisplaySubItemIndex = -1;
            this.cdvCarrier.DisplayText = "";
            this.cdvCarrier.Focusing = null;
            this.cdvCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCarrier.Index = 0;
            this.cdvCarrier.IsViewBtnImage = false;
            this.cdvCarrier.Location = new System.Drawing.Point(458, 136);
            this.cdvCarrier.MaxLength = 20;
            this.cdvCarrier.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCarrier.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCarrier.Name = "cdvCarrier";
            this.cdvCarrier.ReadOnly = false;
            this.cdvCarrier.SearchSubItemIndex = 0;
            this.cdvCarrier.SelectedDescIndex = -1;
            this.cdvCarrier.SelectedSubItemIndex = -1;
            this.cdvCarrier.SelectionStart = 0;
            this.cdvCarrier.Size = new System.Drawing.Size(200, 20);
            this.cdvCarrier.SmallImageList = null;
            this.cdvCarrier.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCarrier.TabIndex = 25;
            this.cdvCarrier.TextBoxToolTipText = "";
            this.cdvCarrier.TextBoxWidth = 200;
            this.cdvCarrier.Visible = false;
            this.cdvCarrier.VisibleButton = true;
            this.cdvCarrier.VisibleColumnHeader = false;
            this.cdvCarrier.VisibleDescription = false;
            this.cdvCarrier.ButtonPress += new System.EventHandler(this.cdvCarrier_ButtonPress);
            // 
            // lblCarrier
            // 
            this.lblCarrier.AutoSize = true;
            this.lblCarrier.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCarrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrier.Location = new System.Drawing.Point(352, 140);
            this.lblCarrier.Name = "lblCarrier";
            this.lblCarrier.Size = new System.Drawing.Size(51, 13);
            this.lblCarrier.TabIndex = 24;
            this.lblCarrier.Text = "Carrier ID";
            this.lblCarrier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCarrier.Visible = false;
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(458, 113);
            this.txtDueDate.MaxLength = 30;
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(124, 20);
            this.txtDueDate.TabIndex = 22;
            this.txtDueDate.TabStop = false;
            // 
            // lblUnit3
            // 
            this.lblUnit3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit3.Location = new System.Drawing.Point(218, 139);
            this.lblUnit3.Name = "lblUnit3";
            this.lblUnit3.Size = new System.Drawing.Size(100, 14);
            this.lblUnit3.TabIndex = 12;
            this.lblUnit3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUnit2
            // 
            this.lblUnit2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit2.Location = new System.Drawing.Point(218, 115);
            this.lblUnit2.Name = "lblUnit2";
            this.lblUnit2.Size = new System.Drawing.Size(100, 14);
            this.lblUnit2.TabIndex = 9;
            this.lblUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUnit1
            // 
            this.lblUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit1.Location = new System.Drawing.Point(218, 91);
            this.lblUnit1.Name = "lblUnit1";
            this.lblUnit1.Size = new System.Drawing.Size(100, 14);
            this.lblUnit1.TabIndex = 6;
            this.lblUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDueDate
            // 
            this.chkDueDate.AutoSize = true;
            this.chkDueDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDueDate.Location = new System.Drawing.Point(352, 114);
            this.chkDueDate.Name = "chkDueDate";
            this.chkDueDate.Size = new System.Drawing.Size(86, 18);
            this.chkDueDate.TabIndex = 21;
            this.chkDueDate.Text = "Due Date";
            this.chkDueDate.CheckedChanged += new System.EventHandler(this.chkDueDate_CheckedChanged);
            // 
            // lblQty3
            // 
            this.lblQty3.AutoSize = true;
            this.lblQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty3.Location = new System.Drawing.Point(12, 140);
            this.lblQty3.Name = "lblQty3";
            this.lblQty3.Size = new System.Drawing.Size(32, 13);
            this.lblQty3.TabIndex = 10;
            this.lblQty3.Text = "Qty 3";
            this.lblQty3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQty2
            // 
            this.lblQty2.AutoSize = true;
            this.lblQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty2.Location = new System.Drawing.Point(12, 116);
            this.lblQty2.Name = "lblQty2";
            this.lblQty2.Size = new System.Drawing.Size(32, 13);
            this.lblQty2.TabIndex = 7;
            this.lblQty2.Text = "Qty 2";
            this.lblQty2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPriority
            // 
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriority.Items.AddRange(new object[] {
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1"});
            this.cboPriority.Location = new System.Drawing.Point(458, 88);
            this.cboPriority.MaxDropDownItems = 9;
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(200, 21);
            this.cboPriority.TabIndex = 20;
            // 
            // lblCreateCode
            // 
            this.lblCreateCode.AutoSize = true;
            this.lblCreateCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCode.Location = new System.Drawing.Point(352, 20);
            this.lblCreateCode.Name = "lblCreateCode";
            this.lblCreateCode.Size = new System.Drawing.Size(77, 13);
            this.lblCreateCode.TabIndex = 13;
            this.lblCreateCode.Text = "Create Code";
            this.lblCreateCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "";
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(458, 113);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(124, 20);
            this.dtpDueDate.TabIndex = 24;
            // 
            // cdvOwnerCode
            // 
            this.cdvOwnerCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOwnerCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOwnerCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOwnerCode.BtnToolTipText = "";
            this.cdvOwnerCode.DescText = "";
            this.cdvOwnerCode.DisplaySubItemIndex = -1;
            this.cdvOwnerCode.DisplayText = "";
            this.cdvOwnerCode.Focusing = null;
            this.cdvOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOwnerCode.Index = 0;
            this.cdvOwnerCode.IsViewBtnImage = false;
            this.cdvOwnerCode.Location = new System.Drawing.Point(458, 40);
            this.cdvOwnerCode.MaxLength = 10;
            this.cdvOwnerCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOwnerCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOwnerCode.Name = "cdvOwnerCode";
            this.cdvOwnerCode.ReadOnly = false;
            this.cdvOwnerCode.SearchSubItemIndex = 0;
            this.cdvOwnerCode.SelectedDescIndex = -1;
            this.cdvOwnerCode.SelectedSubItemIndex = -1;
            this.cdvOwnerCode.SelectionStart = 0;
            this.cdvOwnerCode.Size = new System.Drawing.Size(200, 20);
            this.cdvOwnerCode.SmallImageList = null;
            this.cdvOwnerCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOwnerCode.TabIndex = 16;
            this.cdvOwnerCode.TextBoxToolTipText = "";
            this.cdvOwnerCode.TextBoxWidth = 200;
            this.cdvOwnerCode.VisibleButton = true;
            this.cdvOwnerCode.VisibleColumnHeader = false;
            this.cdvOwnerCode.VisibleDescription = false;
            this.cdvOwnerCode.ButtonPress += new System.EventHandler(this.cdvOwnerCode_ButtonPress);
            // 
            // cdvCreateCode
            // 
            this.cdvCreateCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCode.BtnToolTipText = "";
            this.cdvCreateCode.DescText = "";
            this.cdvCreateCode.DisplaySubItemIndex = -1;
            this.cdvCreateCode.DisplayText = "";
            this.cdvCreateCode.Focusing = null;
            this.cdvCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCode.Index = 0;
            this.cdvCreateCode.IsViewBtnImage = false;
            this.cdvCreateCode.Location = new System.Drawing.Point(458, 16);
            this.cdvCreateCode.MaxLength = 10;
            this.cdvCreateCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCode.Name = "cdvCreateCode";
            this.cdvCreateCode.ReadOnly = false;
            this.cdvCreateCode.SearchSubItemIndex = 0;
            this.cdvCreateCode.SelectedDescIndex = -1;
            this.cdvCreateCode.SelectedSubItemIndex = -1;
            this.cdvCreateCode.SelectionStart = 0;
            this.cdvCreateCode.Size = new System.Drawing.Size(200, 20);
            this.cdvCreateCode.SmallImageList = null;
            this.cdvCreateCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCode.TabIndex = 14;
            this.cdvCreateCode.TextBoxToolTipText = "";
            this.cdvCreateCode.TextBoxWidth = 200;
            this.cdvCreateCode.VisibleButton = true;
            this.cdvCreateCode.VisibleColumnHeader = false;
            this.cdvCreateCode.VisibleDescription = false;
            this.cdvCreateCode.ButtonPress += new System.EventHandler(this.cdvCreateCode_ButtonPress);
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(352, 92);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(38, 13);
            this.lblPriority.TabIndex = 19;
            this.lblPriority.Text = "Priority";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOwnerCode
            // 
            this.lblOwnerCode.AutoSize = true;
            this.lblOwnerCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerCode.Location = new System.Drawing.Point(352, 44);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(76, 13);
            this.lblOwnerCode.TabIndex = 15;
            this.lblOwnerCode.Text = "Owner Code";
            this.lblOwnerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty3
            // 
            this.txtQty3.Location = new System.Drawing.Point(118, 136);
            this.txtQty3.MaxLength = 11;
            this.txtQty3.Name = "txtQty3";
            this.txtQty3.ReadOnly = true;
            this.txtQty3.Size = new System.Drawing.Size(88, 20);
            this.txtQty3.TabIndex = 11;
            this.txtQty3.TabStop = false;
            // 
            // txtQty2
            // 
            this.txtQty2.Location = new System.Drawing.Point(118, 112);
            this.txtQty2.MaxLength = 11;
            this.txtQty2.Name = "txtQty2";
            this.txtQty2.ReadOnly = true;
            this.txtQty2.Size = new System.Drawing.Size(88, 20);
            this.txtQty2.TabIndex = 8;
            this.txtQty2.TabStop = false;
            // 
            // txtQty1
            // 
            this.txtQty1.Location = new System.Drawing.Point(118, 88);
            this.txtQty1.MaxLength = 11;
            this.txtQty1.Name = "txtQty1";
            this.txtQty1.ReadOnly = true;
            this.txtQty1.Size = new System.Drawing.Size(88, 20);
            this.txtQty1.TabIndex = 5;
            this.txtQty1.TabStop = false;
            this.txtQty1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty1_KeyPress);
            // 
            // cdvLotType
            // 
            this.cdvLotType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLotType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLotType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLotType.BtnToolTipText = "";
            this.cdvLotType.DescText = "";
            this.cdvLotType.DisplaySubItemIndex = -1;
            this.cdvLotType.DisplayText = "";
            this.cdvLotType.Focusing = null;
            this.cdvLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLotType.Index = 0;
            this.cdvLotType.IsViewBtnImage = false;
            this.cdvLotType.Location = new System.Drawing.Point(458, 64);
            this.cdvLotType.MaxLength = 1;
            this.cdvLotType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLotType.Name = "cdvLotType";
            this.cdvLotType.ReadOnly = false;
            this.cdvLotType.SearchSubItemIndex = 0;
            this.cdvLotType.SelectedDescIndex = -1;
            this.cdvLotType.SelectedSubItemIndex = -1;
            this.cdvLotType.SelectionStart = 0;
            this.cdvLotType.Size = new System.Drawing.Size(200, 20);
            this.cdvLotType.SmallImageList = null;
            this.cdvLotType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLotType.TabIndex = 18;
            this.cdvLotType.TextBoxToolTipText = "";
            this.cdvLotType.TextBoxWidth = 200;
            this.cdvLotType.VisibleButton = true;
            this.cdvLotType.VisibleColumnHeader = false;
            this.cdvLotType.VisibleDescription = false;
            this.cdvLotType.ButtonPress += new System.EventHandler(this.cdvLotType_ButtonPress);
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
            this.cdvOperation.Location = new System.Drawing.Point(118, 64);
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
            this.cdvOperation.TabIndex = 3;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 200;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOperation_SelectedItemChanged);
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            this.cdvOperation.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvOperation_TextBoxKeyPress);
            this.cdvOperation.TextBoxTextChanged += new System.EventHandler(this.cdvOperation_TextBoxTextChanged);
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty1.Location = new System.Drawing.Point(12, 92);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(37, 13);
            this.lblQty1.TabIndex = 4;
            this.lblQty1.Text = "Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLotType
            // 
            this.lblLotType.AutoSize = true;
            this.lblLotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotType.Location = new System.Drawing.Point(352, 68);
            this.lblLotType.Name = "lblLotType";
            this.lblLotType.Size = new System.Drawing.Size(57, 13);
            this.lblLotType.TabIndex = 17;
            this.lblLotType.Text = "Lot Type";
            this.lblLotType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(12, 68);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(62, 13);
            this.lblOperation.TabIndex = 2;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCreateCmf
            // 
            this.tbpCreateCmf.Controls.Add(this.grpCrtCmf);
            this.tbpCreateCmf.Location = new System.Drawing.Point(4, 22);
            this.tbpCreateCmf.Name = "tbpCreateCmf";
            this.tbpCreateCmf.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCreateCmf.Size = new System.Drawing.Size(728, 422);
            this.tbpCreateCmf.TabIndex = 2;
            this.tbpCreateCmf.Text = "Create Customized Field";
            // 
            // grpCrtCmf
            // 
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf19);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf18);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf17);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf16);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf15);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf14);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf13);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf12);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf20);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf11);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf20);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf19);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf18);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf17);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf16);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf15);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf14);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf13);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf12);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf11);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf9);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf8);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf7);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf6);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf5);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf4);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf3);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf2);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf10);
            this.grpCrtCmf.Controls.Add(this.cdvCrtCmf1);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf10);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf9);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf8);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf7);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf6);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf5);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf4);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf3);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf2);
            this.grpCrtCmf.Controls.Add(this.lblCrtCmf1);
            this.grpCrtCmf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCrtCmf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCrtCmf.Location = new System.Drawing.Point(3, 3);
            this.grpCrtCmf.Name = "grpCrtCmf";
            this.grpCrtCmf.Size = new System.Drawing.Size(722, 416);
            this.grpCrtCmf.TabIndex = 1;
            this.grpCrtCmf.TabStop = false;
            // 
            // cdvCrtCmf19
            // 
            this.cdvCrtCmf19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf19.BtnToolTipText = "";
            this.cdvCrtCmf19.DescText = "";
            this.cdvCrtCmf19.DisplaySubItemIndex = -1;
            this.cdvCrtCmf19.DisplayText = "";
            this.cdvCrtCmf19.Focusing = null;
            this.cdvCrtCmf19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf19.Index = 0;
            this.cdvCrtCmf19.IsViewBtnImage = false;
            this.cdvCrtCmf19.Location = new System.Drawing.Point(519, 208);
            this.cdvCrtCmf19.MaxLength = 30;
            this.cdvCrtCmf19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf19.Name = "cdvCrtCmf19";
            this.cdvCrtCmf19.ReadOnly = false;
            this.cdvCrtCmf19.SearchSubItemIndex = 0;
            this.cdvCrtCmf19.SelectedDescIndex = -1;
            this.cdvCrtCmf19.SelectedSubItemIndex = -1;
            this.cdvCrtCmf19.SelectionStart = 0;
            this.cdvCrtCmf19.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf19.SmallImageList = null;
            this.cdvCrtCmf19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf19.TabIndex = 37;
            this.cdvCrtCmf19.TextBoxToolTipText = "";
            this.cdvCrtCmf19.TextBoxWidth = 180;
            this.cdvCrtCmf19.VisibleButton = true;
            this.cdvCrtCmf19.VisibleColumnHeader = false;
            this.cdvCrtCmf19.VisibleDescription = false;
            this.cdvCrtCmf19.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf18
            // 
            this.cdvCrtCmf18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf18.BtnToolTipText = "";
            this.cdvCrtCmf18.DescText = "";
            this.cdvCrtCmf18.DisplaySubItemIndex = -1;
            this.cdvCrtCmf18.DisplayText = "";
            this.cdvCrtCmf18.Focusing = null;
            this.cdvCrtCmf18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf18.Index = 0;
            this.cdvCrtCmf18.IsViewBtnImage = false;
            this.cdvCrtCmf18.Location = new System.Drawing.Point(519, 184);
            this.cdvCrtCmf18.MaxLength = 30;
            this.cdvCrtCmf18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf18.Name = "cdvCrtCmf18";
            this.cdvCrtCmf18.ReadOnly = false;
            this.cdvCrtCmf18.SearchSubItemIndex = 0;
            this.cdvCrtCmf18.SelectedDescIndex = -1;
            this.cdvCrtCmf18.SelectedSubItemIndex = -1;
            this.cdvCrtCmf18.SelectionStart = 0;
            this.cdvCrtCmf18.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf18.SmallImageList = null;
            this.cdvCrtCmf18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf18.TabIndex = 35;
            this.cdvCrtCmf18.TextBoxToolTipText = "";
            this.cdvCrtCmf18.TextBoxWidth = 180;
            this.cdvCrtCmf18.VisibleButton = true;
            this.cdvCrtCmf18.VisibleColumnHeader = false;
            this.cdvCrtCmf18.VisibleDescription = false;
            this.cdvCrtCmf18.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf17
            // 
            this.cdvCrtCmf17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf17.BtnToolTipText = "";
            this.cdvCrtCmf17.DescText = "";
            this.cdvCrtCmf17.DisplaySubItemIndex = -1;
            this.cdvCrtCmf17.DisplayText = "";
            this.cdvCrtCmf17.Focusing = null;
            this.cdvCrtCmf17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf17.Index = 0;
            this.cdvCrtCmf17.IsViewBtnImage = false;
            this.cdvCrtCmf17.Location = new System.Drawing.Point(519, 160);
            this.cdvCrtCmf17.MaxLength = 30;
            this.cdvCrtCmf17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf17.Name = "cdvCrtCmf17";
            this.cdvCrtCmf17.ReadOnly = false;
            this.cdvCrtCmf17.SearchSubItemIndex = 0;
            this.cdvCrtCmf17.SelectedDescIndex = -1;
            this.cdvCrtCmf17.SelectedSubItemIndex = -1;
            this.cdvCrtCmf17.SelectionStart = 0;
            this.cdvCrtCmf17.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf17.SmallImageList = null;
            this.cdvCrtCmf17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf17.TabIndex = 33;
            this.cdvCrtCmf17.TextBoxToolTipText = "";
            this.cdvCrtCmf17.TextBoxWidth = 180;
            this.cdvCrtCmf17.VisibleButton = true;
            this.cdvCrtCmf17.VisibleColumnHeader = false;
            this.cdvCrtCmf17.VisibleDescription = false;
            this.cdvCrtCmf17.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf16
            // 
            this.cdvCrtCmf16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf16.BtnToolTipText = "";
            this.cdvCrtCmf16.DescText = "";
            this.cdvCrtCmf16.DisplaySubItemIndex = -1;
            this.cdvCrtCmf16.DisplayText = "";
            this.cdvCrtCmf16.Focusing = null;
            this.cdvCrtCmf16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf16.Index = 0;
            this.cdvCrtCmf16.IsViewBtnImage = false;
            this.cdvCrtCmf16.Location = new System.Drawing.Point(519, 136);
            this.cdvCrtCmf16.MaxLength = 30;
            this.cdvCrtCmf16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf16.Name = "cdvCrtCmf16";
            this.cdvCrtCmf16.ReadOnly = false;
            this.cdvCrtCmf16.SearchSubItemIndex = 0;
            this.cdvCrtCmf16.SelectedDescIndex = -1;
            this.cdvCrtCmf16.SelectedSubItemIndex = -1;
            this.cdvCrtCmf16.SelectionStart = 0;
            this.cdvCrtCmf16.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf16.SmallImageList = null;
            this.cdvCrtCmf16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf16.TabIndex = 31;
            this.cdvCrtCmf16.TextBoxToolTipText = "";
            this.cdvCrtCmf16.TextBoxWidth = 180;
            this.cdvCrtCmf16.VisibleButton = true;
            this.cdvCrtCmf16.VisibleColumnHeader = false;
            this.cdvCrtCmf16.VisibleDescription = false;
            this.cdvCrtCmf16.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf15
            // 
            this.cdvCrtCmf15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf15.BtnToolTipText = "";
            this.cdvCrtCmf15.DescText = "";
            this.cdvCrtCmf15.DisplaySubItemIndex = -1;
            this.cdvCrtCmf15.DisplayText = "";
            this.cdvCrtCmf15.Focusing = null;
            this.cdvCrtCmf15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf15.Index = 0;
            this.cdvCrtCmf15.IsViewBtnImage = false;
            this.cdvCrtCmf15.Location = new System.Drawing.Point(519, 112);
            this.cdvCrtCmf15.MaxLength = 30;
            this.cdvCrtCmf15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf15.Name = "cdvCrtCmf15";
            this.cdvCrtCmf15.ReadOnly = false;
            this.cdvCrtCmf15.SearchSubItemIndex = 0;
            this.cdvCrtCmf15.SelectedDescIndex = -1;
            this.cdvCrtCmf15.SelectedSubItemIndex = -1;
            this.cdvCrtCmf15.SelectionStart = 0;
            this.cdvCrtCmf15.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf15.SmallImageList = null;
            this.cdvCrtCmf15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf15.TabIndex = 29;
            this.cdvCrtCmf15.TextBoxToolTipText = "";
            this.cdvCrtCmf15.TextBoxWidth = 180;
            this.cdvCrtCmf15.VisibleButton = true;
            this.cdvCrtCmf15.VisibleColumnHeader = false;
            this.cdvCrtCmf15.VisibleDescription = false;
            this.cdvCrtCmf15.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf14
            // 
            this.cdvCrtCmf14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf14.BtnToolTipText = "";
            this.cdvCrtCmf14.DescText = "";
            this.cdvCrtCmf14.DisplaySubItemIndex = -1;
            this.cdvCrtCmf14.DisplayText = "";
            this.cdvCrtCmf14.Focusing = null;
            this.cdvCrtCmf14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf14.Index = 0;
            this.cdvCrtCmf14.IsViewBtnImage = false;
            this.cdvCrtCmf14.Location = new System.Drawing.Point(519, 88);
            this.cdvCrtCmf14.MaxLength = 30;
            this.cdvCrtCmf14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf14.Name = "cdvCrtCmf14";
            this.cdvCrtCmf14.ReadOnly = false;
            this.cdvCrtCmf14.SearchSubItemIndex = 0;
            this.cdvCrtCmf14.SelectedDescIndex = -1;
            this.cdvCrtCmf14.SelectedSubItemIndex = -1;
            this.cdvCrtCmf14.SelectionStart = 0;
            this.cdvCrtCmf14.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf14.SmallImageList = null;
            this.cdvCrtCmf14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf14.TabIndex = 27;
            this.cdvCrtCmf14.TextBoxToolTipText = "";
            this.cdvCrtCmf14.TextBoxWidth = 180;
            this.cdvCrtCmf14.VisibleButton = true;
            this.cdvCrtCmf14.VisibleColumnHeader = false;
            this.cdvCrtCmf14.VisibleDescription = false;
            this.cdvCrtCmf14.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf13
            // 
            this.cdvCrtCmf13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf13.BtnToolTipText = "";
            this.cdvCrtCmf13.DescText = "";
            this.cdvCrtCmf13.DisplaySubItemIndex = -1;
            this.cdvCrtCmf13.DisplayText = "";
            this.cdvCrtCmf13.Focusing = null;
            this.cdvCrtCmf13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf13.Index = 0;
            this.cdvCrtCmf13.IsViewBtnImage = false;
            this.cdvCrtCmf13.Location = new System.Drawing.Point(519, 64);
            this.cdvCrtCmf13.MaxLength = 30;
            this.cdvCrtCmf13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf13.Name = "cdvCrtCmf13";
            this.cdvCrtCmf13.ReadOnly = false;
            this.cdvCrtCmf13.SearchSubItemIndex = 0;
            this.cdvCrtCmf13.SelectedDescIndex = -1;
            this.cdvCrtCmf13.SelectedSubItemIndex = -1;
            this.cdvCrtCmf13.SelectionStart = 0;
            this.cdvCrtCmf13.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf13.SmallImageList = null;
            this.cdvCrtCmf13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf13.TabIndex = 25;
            this.cdvCrtCmf13.TextBoxToolTipText = "";
            this.cdvCrtCmf13.TextBoxWidth = 180;
            this.cdvCrtCmf13.VisibleButton = true;
            this.cdvCrtCmf13.VisibleColumnHeader = false;
            this.cdvCrtCmf13.VisibleDescription = false;
            this.cdvCrtCmf13.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf12
            // 
            this.cdvCrtCmf12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf12.BtnToolTipText = "";
            this.cdvCrtCmf12.DescText = "";
            this.cdvCrtCmf12.DisplaySubItemIndex = -1;
            this.cdvCrtCmf12.DisplayText = "";
            this.cdvCrtCmf12.Focusing = null;
            this.cdvCrtCmf12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf12.Index = 0;
            this.cdvCrtCmf12.IsViewBtnImage = false;
            this.cdvCrtCmf12.Location = new System.Drawing.Point(519, 40);
            this.cdvCrtCmf12.MaxLength = 30;
            this.cdvCrtCmf12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf12.Name = "cdvCrtCmf12";
            this.cdvCrtCmf12.ReadOnly = false;
            this.cdvCrtCmf12.SearchSubItemIndex = 0;
            this.cdvCrtCmf12.SelectedDescIndex = -1;
            this.cdvCrtCmf12.SelectedSubItemIndex = -1;
            this.cdvCrtCmf12.SelectionStart = 0;
            this.cdvCrtCmf12.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf12.SmallImageList = null;
            this.cdvCrtCmf12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf12.TabIndex = 23;
            this.cdvCrtCmf12.TextBoxToolTipText = "";
            this.cdvCrtCmf12.TextBoxWidth = 180;
            this.cdvCrtCmf12.VisibleButton = true;
            this.cdvCrtCmf12.VisibleColumnHeader = false;
            this.cdvCrtCmf12.VisibleDescription = false;
            this.cdvCrtCmf12.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf20
            // 
            this.cdvCrtCmf20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf20.BtnToolTipText = "";
            this.cdvCrtCmf20.DescText = "";
            this.cdvCrtCmf20.DisplaySubItemIndex = -1;
            this.cdvCrtCmf20.DisplayText = "";
            this.cdvCrtCmf20.Focusing = null;
            this.cdvCrtCmf20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf20.Index = 0;
            this.cdvCrtCmf20.IsViewBtnImage = false;
            this.cdvCrtCmf20.Location = new System.Drawing.Point(519, 232);
            this.cdvCrtCmf20.MaxLength = 30;
            this.cdvCrtCmf20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf20.Name = "cdvCrtCmf20";
            this.cdvCrtCmf20.ReadOnly = false;
            this.cdvCrtCmf20.SearchSubItemIndex = 0;
            this.cdvCrtCmf20.SelectedDescIndex = -1;
            this.cdvCrtCmf20.SelectedSubItemIndex = -1;
            this.cdvCrtCmf20.SelectionStart = 0;
            this.cdvCrtCmf20.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf20.SmallImageList = null;
            this.cdvCrtCmf20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf20.TabIndex = 39;
            this.cdvCrtCmf20.TextBoxToolTipText = "";
            this.cdvCrtCmf20.TextBoxWidth = 180;
            this.cdvCrtCmf20.VisibleButton = true;
            this.cdvCrtCmf20.VisibleColumnHeader = false;
            this.cdvCrtCmf20.VisibleDescription = false;
            this.cdvCrtCmf20.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf11
            // 
            this.cdvCrtCmf11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf11.BtnToolTipText = "";
            this.cdvCrtCmf11.DescText = "";
            this.cdvCrtCmf11.DisplaySubItemIndex = -1;
            this.cdvCrtCmf11.DisplayText = "";
            this.cdvCrtCmf11.Focusing = null;
            this.cdvCrtCmf11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf11.Index = 0;
            this.cdvCrtCmf11.IsViewBtnImage = false;
            this.cdvCrtCmf11.Location = new System.Drawing.Point(519, 16);
            this.cdvCrtCmf11.MaxLength = 30;
            this.cdvCrtCmf11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf11.Name = "cdvCrtCmf11";
            this.cdvCrtCmf11.ReadOnly = false;
            this.cdvCrtCmf11.SearchSubItemIndex = 0;
            this.cdvCrtCmf11.SelectedDescIndex = -1;
            this.cdvCrtCmf11.SelectedSubItemIndex = -1;
            this.cdvCrtCmf11.SelectionStart = 0;
            this.cdvCrtCmf11.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf11.SmallImageList = null;
            this.cdvCrtCmf11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf11.TabIndex = 21;
            this.cdvCrtCmf11.TextBoxToolTipText = "";
            this.cdvCrtCmf11.TextBoxWidth = 180;
            this.cdvCrtCmf11.VisibleButton = true;
            this.cdvCrtCmf11.VisibleColumnHeader = false;
            this.cdvCrtCmf11.VisibleDescription = false;
            this.cdvCrtCmf11.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // lblCrtCmf20
            // 
            this.lblCrtCmf20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf20.Location = new System.Drawing.Point(373, 236);
            this.lblCrtCmf20.Name = "lblCrtCmf20";
            this.lblCrtCmf20.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf20.TabIndex = 38;
            this.lblCrtCmf20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf19
            // 
            this.lblCrtCmf19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf19.Location = new System.Drawing.Point(373, 212);
            this.lblCrtCmf19.Name = "lblCrtCmf19";
            this.lblCrtCmf19.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf19.TabIndex = 36;
            this.lblCrtCmf19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf18
            // 
            this.lblCrtCmf18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf18.Location = new System.Drawing.Point(373, 188);
            this.lblCrtCmf18.Name = "lblCrtCmf18";
            this.lblCrtCmf18.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf18.TabIndex = 34;
            this.lblCrtCmf18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf17
            // 
            this.lblCrtCmf17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf17.Location = new System.Drawing.Point(373, 164);
            this.lblCrtCmf17.Name = "lblCrtCmf17";
            this.lblCrtCmf17.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf17.TabIndex = 32;
            this.lblCrtCmf17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf16
            // 
            this.lblCrtCmf16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf16.Location = new System.Drawing.Point(373, 140);
            this.lblCrtCmf16.Name = "lblCrtCmf16";
            this.lblCrtCmf16.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf16.TabIndex = 30;
            this.lblCrtCmf16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf15
            // 
            this.lblCrtCmf15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf15.Location = new System.Drawing.Point(373, 116);
            this.lblCrtCmf15.Name = "lblCrtCmf15";
            this.lblCrtCmf15.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf15.TabIndex = 28;
            this.lblCrtCmf15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf14
            // 
            this.lblCrtCmf14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf14.Location = new System.Drawing.Point(373, 92);
            this.lblCrtCmf14.Name = "lblCrtCmf14";
            this.lblCrtCmf14.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf14.TabIndex = 26;
            this.lblCrtCmf14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf13
            // 
            this.lblCrtCmf13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf13.Location = new System.Drawing.Point(373, 68);
            this.lblCrtCmf13.Name = "lblCrtCmf13";
            this.lblCrtCmf13.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf13.TabIndex = 24;
            this.lblCrtCmf13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf12
            // 
            this.lblCrtCmf12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf12.Location = new System.Drawing.Point(373, 44);
            this.lblCrtCmf12.Name = "lblCrtCmf12";
            this.lblCrtCmf12.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf12.TabIndex = 22;
            this.lblCrtCmf12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf11
            // 
            this.lblCrtCmf11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf11.Location = new System.Drawing.Point(373, 20);
            this.lblCrtCmf11.Name = "lblCrtCmf11";
            this.lblCrtCmf11.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf11.TabIndex = 20;
            this.lblCrtCmf11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCrtCmf9
            // 
            this.cdvCrtCmf9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf9.BtnToolTipText = "";
            this.cdvCrtCmf9.DescText = "";
            this.cdvCrtCmf9.DisplaySubItemIndex = -1;
            this.cdvCrtCmf9.DisplayText = "";
            this.cdvCrtCmf9.Focusing = null;
            this.cdvCrtCmf9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf9.Index = 0;
            this.cdvCrtCmf9.IsViewBtnImage = false;
            this.cdvCrtCmf9.Location = new System.Drawing.Point(169, 208);
            this.cdvCrtCmf9.MaxLength = 30;
            this.cdvCrtCmf9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf9.Name = "cdvCrtCmf9";
            this.cdvCrtCmf9.ReadOnly = false;
            this.cdvCrtCmf9.SearchSubItemIndex = 0;
            this.cdvCrtCmf9.SelectedDescIndex = -1;
            this.cdvCrtCmf9.SelectedSubItemIndex = -1;
            this.cdvCrtCmf9.SelectionStart = 0;
            this.cdvCrtCmf9.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf9.SmallImageList = null;
            this.cdvCrtCmf9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf9.TabIndex = 17;
            this.cdvCrtCmf9.TextBoxToolTipText = "";
            this.cdvCrtCmf9.TextBoxWidth = 180;
            this.cdvCrtCmf9.VisibleButton = true;
            this.cdvCrtCmf9.VisibleColumnHeader = false;
            this.cdvCrtCmf9.VisibleDescription = false;
            this.cdvCrtCmf9.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf8
            // 
            this.cdvCrtCmf8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf8.BtnToolTipText = "";
            this.cdvCrtCmf8.DescText = "";
            this.cdvCrtCmf8.DisplaySubItemIndex = -1;
            this.cdvCrtCmf8.DisplayText = "";
            this.cdvCrtCmf8.Focusing = null;
            this.cdvCrtCmf8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf8.Index = 0;
            this.cdvCrtCmf8.IsViewBtnImage = false;
            this.cdvCrtCmf8.Location = new System.Drawing.Point(169, 184);
            this.cdvCrtCmf8.MaxLength = 30;
            this.cdvCrtCmf8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf8.Name = "cdvCrtCmf8";
            this.cdvCrtCmf8.ReadOnly = false;
            this.cdvCrtCmf8.SearchSubItemIndex = 0;
            this.cdvCrtCmf8.SelectedDescIndex = -1;
            this.cdvCrtCmf8.SelectedSubItemIndex = -1;
            this.cdvCrtCmf8.SelectionStart = 0;
            this.cdvCrtCmf8.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf8.SmallImageList = null;
            this.cdvCrtCmf8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf8.TabIndex = 15;
            this.cdvCrtCmf8.TextBoxToolTipText = "";
            this.cdvCrtCmf8.TextBoxWidth = 180;
            this.cdvCrtCmf8.VisibleButton = true;
            this.cdvCrtCmf8.VisibleColumnHeader = false;
            this.cdvCrtCmf8.VisibleDescription = false;
            this.cdvCrtCmf8.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf7
            // 
            this.cdvCrtCmf7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf7.BtnToolTipText = "";
            this.cdvCrtCmf7.DescText = "";
            this.cdvCrtCmf7.DisplaySubItemIndex = -1;
            this.cdvCrtCmf7.DisplayText = "";
            this.cdvCrtCmf7.Focusing = null;
            this.cdvCrtCmf7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf7.Index = 0;
            this.cdvCrtCmf7.IsViewBtnImage = false;
            this.cdvCrtCmf7.Location = new System.Drawing.Point(169, 160);
            this.cdvCrtCmf7.MaxLength = 30;
            this.cdvCrtCmf7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf7.Name = "cdvCrtCmf7";
            this.cdvCrtCmf7.ReadOnly = false;
            this.cdvCrtCmf7.SearchSubItemIndex = 0;
            this.cdvCrtCmf7.SelectedDescIndex = -1;
            this.cdvCrtCmf7.SelectedSubItemIndex = -1;
            this.cdvCrtCmf7.SelectionStart = 0;
            this.cdvCrtCmf7.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf7.SmallImageList = null;
            this.cdvCrtCmf7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf7.TabIndex = 13;
            this.cdvCrtCmf7.TextBoxToolTipText = "";
            this.cdvCrtCmf7.TextBoxWidth = 180;
            this.cdvCrtCmf7.VisibleButton = true;
            this.cdvCrtCmf7.VisibleColumnHeader = false;
            this.cdvCrtCmf7.VisibleDescription = false;
            this.cdvCrtCmf7.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf6
            // 
            this.cdvCrtCmf6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf6.BtnToolTipText = "";
            this.cdvCrtCmf6.DescText = "";
            this.cdvCrtCmf6.DisplaySubItemIndex = -1;
            this.cdvCrtCmf6.DisplayText = "";
            this.cdvCrtCmf6.Focusing = null;
            this.cdvCrtCmf6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf6.Index = 0;
            this.cdvCrtCmf6.IsViewBtnImage = false;
            this.cdvCrtCmf6.Location = new System.Drawing.Point(169, 136);
            this.cdvCrtCmf6.MaxLength = 30;
            this.cdvCrtCmf6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf6.Name = "cdvCrtCmf6";
            this.cdvCrtCmf6.ReadOnly = false;
            this.cdvCrtCmf6.SearchSubItemIndex = 0;
            this.cdvCrtCmf6.SelectedDescIndex = -1;
            this.cdvCrtCmf6.SelectedSubItemIndex = -1;
            this.cdvCrtCmf6.SelectionStart = 0;
            this.cdvCrtCmf6.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf6.SmallImageList = null;
            this.cdvCrtCmf6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf6.TabIndex = 11;
            this.cdvCrtCmf6.TextBoxToolTipText = "";
            this.cdvCrtCmf6.TextBoxWidth = 180;
            this.cdvCrtCmf6.VisibleButton = true;
            this.cdvCrtCmf6.VisibleColumnHeader = false;
            this.cdvCrtCmf6.VisibleDescription = false;
            this.cdvCrtCmf6.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf5
            // 
            this.cdvCrtCmf5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf5.BtnToolTipText = "";
            this.cdvCrtCmf5.DescText = "";
            this.cdvCrtCmf5.DisplaySubItemIndex = -1;
            this.cdvCrtCmf5.DisplayText = "";
            this.cdvCrtCmf5.Focusing = null;
            this.cdvCrtCmf5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf5.Index = 0;
            this.cdvCrtCmf5.IsViewBtnImage = false;
            this.cdvCrtCmf5.Location = new System.Drawing.Point(169, 112);
            this.cdvCrtCmf5.MaxLength = 30;
            this.cdvCrtCmf5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf5.Name = "cdvCrtCmf5";
            this.cdvCrtCmf5.ReadOnly = false;
            this.cdvCrtCmf5.SearchSubItemIndex = 0;
            this.cdvCrtCmf5.SelectedDescIndex = -1;
            this.cdvCrtCmf5.SelectedSubItemIndex = -1;
            this.cdvCrtCmf5.SelectionStart = 0;
            this.cdvCrtCmf5.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf5.SmallImageList = null;
            this.cdvCrtCmf5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf5.TabIndex = 9;
            this.cdvCrtCmf5.TextBoxToolTipText = "";
            this.cdvCrtCmf5.TextBoxWidth = 180;
            this.cdvCrtCmf5.VisibleButton = true;
            this.cdvCrtCmf5.VisibleColumnHeader = false;
            this.cdvCrtCmf5.VisibleDescription = false;
            this.cdvCrtCmf5.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf4
            // 
            this.cdvCrtCmf4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf4.BtnToolTipText = "";
            this.cdvCrtCmf4.DescText = "";
            this.cdvCrtCmf4.DisplaySubItemIndex = -1;
            this.cdvCrtCmf4.DisplayText = "";
            this.cdvCrtCmf4.Focusing = null;
            this.cdvCrtCmf4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf4.Index = 0;
            this.cdvCrtCmf4.IsViewBtnImage = false;
            this.cdvCrtCmf4.Location = new System.Drawing.Point(169, 88);
            this.cdvCrtCmf4.MaxLength = 30;
            this.cdvCrtCmf4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf4.Name = "cdvCrtCmf4";
            this.cdvCrtCmf4.ReadOnly = false;
            this.cdvCrtCmf4.SearchSubItemIndex = 0;
            this.cdvCrtCmf4.SelectedDescIndex = -1;
            this.cdvCrtCmf4.SelectedSubItemIndex = -1;
            this.cdvCrtCmf4.SelectionStart = 0;
            this.cdvCrtCmf4.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf4.SmallImageList = null;
            this.cdvCrtCmf4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf4.TabIndex = 7;
            this.cdvCrtCmf4.TextBoxToolTipText = "";
            this.cdvCrtCmf4.TextBoxWidth = 180;
            this.cdvCrtCmf4.VisibleButton = true;
            this.cdvCrtCmf4.VisibleColumnHeader = false;
            this.cdvCrtCmf4.VisibleDescription = false;
            this.cdvCrtCmf4.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf3
            // 
            this.cdvCrtCmf3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf3.BtnToolTipText = "";
            this.cdvCrtCmf3.DescText = "";
            this.cdvCrtCmf3.DisplaySubItemIndex = -1;
            this.cdvCrtCmf3.DisplayText = "";
            this.cdvCrtCmf3.Focusing = null;
            this.cdvCrtCmf3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf3.Index = 0;
            this.cdvCrtCmf3.IsViewBtnImage = false;
            this.cdvCrtCmf3.Location = new System.Drawing.Point(169, 64);
            this.cdvCrtCmf3.MaxLength = 30;
            this.cdvCrtCmf3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf3.Name = "cdvCrtCmf3";
            this.cdvCrtCmf3.ReadOnly = false;
            this.cdvCrtCmf3.SearchSubItemIndex = 0;
            this.cdvCrtCmf3.SelectedDescIndex = -1;
            this.cdvCrtCmf3.SelectedSubItemIndex = -1;
            this.cdvCrtCmf3.SelectionStart = 0;
            this.cdvCrtCmf3.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf3.SmallImageList = null;
            this.cdvCrtCmf3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf3.TabIndex = 5;
            this.cdvCrtCmf3.TextBoxToolTipText = "";
            this.cdvCrtCmf3.TextBoxWidth = 180;
            this.cdvCrtCmf3.VisibleButton = true;
            this.cdvCrtCmf3.VisibleColumnHeader = false;
            this.cdvCrtCmf3.VisibleDescription = false;
            this.cdvCrtCmf3.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf2
            // 
            this.cdvCrtCmf2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf2.BtnToolTipText = "";
            this.cdvCrtCmf2.DescText = "";
            this.cdvCrtCmf2.DisplaySubItemIndex = -1;
            this.cdvCrtCmf2.DisplayText = "";
            this.cdvCrtCmf2.Focusing = null;
            this.cdvCrtCmf2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf2.Index = 0;
            this.cdvCrtCmf2.IsViewBtnImage = false;
            this.cdvCrtCmf2.Location = new System.Drawing.Point(169, 40);
            this.cdvCrtCmf2.MaxLength = 30;
            this.cdvCrtCmf2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf2.Name = "cdvCrtCmf2";
            this.cdvCrtCmf2.ReadOnly = false;
            this.cdvCrtCmf2.SearchSubItemIndex = 0;
            this.cdvCrtCmf2.SelectedDescIndex = -1;
            this.cdvCrtCmf2.SelectedSubItemIndex = -1;
            this.cdvCrtCmf2.SelectionStart = 0;
            this.cdvCrtCmf2.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf2.SmallImageList = null;
            this.cdvCrtCmf2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf2.TabIndex = 3;
            this.cdvCrtCmf2.TextBoxToolTipText = "";
            this.cdvCrtCmf2.TextBoxWidth = 180;
            this.cdvCrtCmf2.VisibleButton = true;
            this.cdvCrtCmf2.VisibleColumnHeader = false;
            this.cdvCrtCmf2.VisibleDescription = false;
            this.cdvCrtCmf2.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf10
            // 
            this.cdvCrtCmf10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf10.BtnToolTipText = "";
            this.cdvCrtCmf10.DescText = "";
            this.cdvCrtCmf10.DisplaySubItemIndex = -1;
            this.cdvCrtCmf10.DisplayText = "";
            this.cdvCrtCmf10.Focusing = null;
            this.cdvCrtCmf10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf10.Index = 0;
            this.cdvCrtCmf10.IsViewBtnImage = false;
            this.cdvCrtCmf10.Location = new System.Drawing.Point(169, 232);
            this.cdvCrtCmf10.MaxLength = 30;
            this.cdvCrtCmf10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf10.Name = "cdvCrtCmf10";
            this.cdvCrtCmf10.ReadOnly = false;
            this.cdvCrtCmf10.SearchSubItemIndex = 0;
            this.cdvCrtCmf10.SelectedDescIndex = -1;
            this.cdvCrtCmf10.SelectedSubItemIndex = -1;
            this.cdvCrtCmf10.SelectionStart = 0;
            this.cdvCrtCmf10.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf10.SmallImageList = null;
            this.cdvCrtCmf10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf10.TabIndex = 19;
            this.cdvCrtCmf10.TextBoxToolTipText = "";
            this.cdvCrtCmf10.TextBoxWidth = 180;
            this.cdvCrtCmf10.VisibleButton = true;
            this.cdvCrtCmf10.VisibleColumnHeader = false;
            this.cdvCrtCmf10.VisibleDescription = false;
            this.cdvCrtCmf10.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // cdvCrtCmf1
            // 
            this.cdvCrtCmf1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtCmf1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtCmf1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtCmf1.BtnToolTipText = "";
            this.cdvCrtCmf1.DescText = "";
            this.cdvCrtCmf1.DisplaySubItemIndex = -1;
            this.cdvCrtCmf1.DisplayText = "";
            this.cdvCrtCmf1.Focusing = null;
            this.cdvCrtCmf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtCmf1.Index = 0;
            this.cdvCrtCmf1.IsViewBtnImage = false;
            this.cdvCrtCmf1.Location = new System.Drawing.Point(169, 16);
            this.cdvCrtCmf1.MaxLength = 30;
            this.cdvCrtCmf1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtCmf1.Name = "cdvCrtCmf1";
            this.cdvCrtCmf1.ReadOnly = false;
            this.cdvCrtCmf1.SearchSubItemIndex = 0;
            this.cdvCrtCmf1.SelectedDescIndex = -1;
            this.cdvCrtCmf1.SelectedSubItemIndex = -1;
            this.cdvCrtCmf1.SelectionStart = 0;
            this.cdvCrtCmf1.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtCmf1.SmallImageList = null;
            this.cdvCrtCmf1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtCmf1.TabIndex = 1;
            this.cdvCrtCmf1.TextBoxToolTipText = "";
            this.cdvCrtCmf1.TextBoxWidth = 180;
            this.cdvCrtCmf1.VisibleButton = true;
            this.cdvCrtCmf1.VisibleColumnHeader = false;
            this.cdvCrtCmf1.VisibleDescription = false;
            this.cdvCrtCmf1.ButtonPress += new System.EventHandler(this.cdvCrtCmf_ButtonPress);
            this.cdvCrtCmf1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtCmf_TextBoxKeyPress);
            // 
            // lblCrtCmf10
            // 
            this.lblCrtCmf10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf10.Location = new System.Drawing.Point(23, 235);
            this.lblCrtCmf10.Name = "lblCrtCmf10";
            this.lblCrtCmf10.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf10.TabIndex = 18;
            this.lblCrtCmf10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf9
            // 
            this.lblCrtCmf9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf9.Location = new System.Drawing.Point(23, 211);
            this.lblCrtCmf9.Name = "lblCrtCmf9";
            this.lblCrtCmf9.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf9.TabIndex = 16;
            this.lblCrtCmf9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf8
            // 
            this.lblCrtCmf8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf8.Location = new System.Drawing.Point(23, 187);
            this.lblCrtCmf8.Name = "lblCrtCmf8";
            this.lblCrtCmf8.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf8.TabIndex = 14;
            this.lblCrtCmf8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf7
            // 
            this.lblCrtCmf7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf7.Location = new System.Drawing.Point(23, 163);
            this.lblCrtCmf7.Name = "lblCrtCmf7";
            this.lblCrtCmf7.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf7.TabIndex = 12;
            this.lblCrtCmf7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf6
            // 
            this.lblCrtCmf6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf6.Location = new System.Drawing.Point(23, 139);
            this.lblCrtCmf6.Name = "lblCrtCmf6";
            this.lblCrtCmf6.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf6.TabIndex = 10;
            this.lblCrtCmf6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf5
            // 
            this.lblCrtCmf5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf5.Location = new System.Drawing.Point(23, 115);
            this.lblCrtCmf5.Name = "lblCrtCmf5";
            this.lblCrtCmf5.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf5.TabIndex = 8;
            this.lblCrtCmf5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf4
            // 
            this.lblCrtCmf4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf4.Location = new System.Drawing.Point(23, 91);
            this.lblCrtCmf4.Name = "lblCrtCmf4";
            this.lblCrtCmf4.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf4.TabIndex = 6;
            this.lblCrtCmf4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf3
            // 
            this.lblCrtCmf3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf3.Location = new System.Drawing.Point(23, 67);
            this.lblCrtCmf3.Name = "lblCrtCmf3";
            this.lblCrtCmf3.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf3.TabIndex = 4;
            this.lblCrtCmf3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf2
            // 
            this.lblCrtCmf2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf2.Location = new System.Drawing.Point(23, 43);
            this.lblCrtCmf2.Name = "lblCrtCmf2";
            this.lblCrtCmf2.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf2.TabIndex = 2;
            this.lblCrtCmf2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtCmf1
            // 
            this.lblCrtCmf1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtCmf1.Location = new System.Drawing.Point(23, 20);
            this.lblCrtCmf1.Name = "lblCrtCmf1";
            this.lblCrtCmf1.Size = new System.Drawing.Size(140, 14);
            this.lblCrtCmf1.TabIndex = 0;
            this.lblCrtCmf1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnGenerate
            // 
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGenerate.Location = new System.Drawing.Point(324, 11);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(74, 22);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate ID";
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // frmWIPTranCreateLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranCreateLot";
            this.Text = "Create Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranCreateLot_Activated);
            this.Load += new System.EventHandler(this.frmWIPTranCreateLot_Load);
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
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCarrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            this.tbpCreateCmf.ResumeLayout(false);
            this.grpCrtCmf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtCmf1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        private bool b_load_flag = false;
        private string sQty1 = "";
        private string sQty2 = "";
        private string sQty3 = "";
        private bool bMFOCheckFlag = false;

        #endregion

        #region " Function Definition "

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(string ProcStep)
        {

            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this);
                    cboPriority.SelectedIndex = 4;
                    txtDueDate.Visible = !chkDueDate.Checked;
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
        private bool CheckCondition(string FuncName, char c_step)
        {
            string sQtyChk = "";

            switch (MPCF.Trim(FuncName))
            {
                case "CREATE_LOT":

                    tabTran.SelectedTab = tbpGeneral;
                    if (c_step == '1')
                    {
                        if (MPCF.CheckValue(txtLotID, 1) == false)
                        {
                            return false;
                        }
                    }
                    if (cdvMaterial.CheckValue() == false)
                    {
                        return false;
                    }
                    //Transit Í≥µÏ†ï??Lot ?ùÏÑ±??flowÍ∞Ä ?ÜÏùÑ ???àÏúºÎØÄÎ°?check ?òÏ? ?äÏùå.
                    //If modCommonFunction.CheckValue(cdvFlow, 1, false, false, "", "", "") = False Then Return False
                    if (MPCF.CheckValue(cdvOperation, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvLotType, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCreateCode, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvOwnerCode, 1) == false)
                    {
                        return false;
                    }

                    if (c_step == '2')
                    {
                        return true;
                    }

                    if (txtQty1.ReadOnly == false)
                    {
                        if (txtQty1.Text == "" || MPCF.ToDbl(txtQty1.Text) == 0)
                        {
                            if (MPGO.ProcessZeroQtyLot() == true)
                            {
                                sQtyChk = "Qty1";
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                txtQty1.Focus();
                                return false;
                            }
                        }
                        if (txtQty1.Text == "")
                        {
                            txtQty1.Text = "0";
                        }
                        if (MPCF.CheckValue(txtQty1, 2) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty1.Focus();
                            return false;
                        }
                    }
                    if (txtQty2.ReadOnly == false)
                    {
                        if (txtQty2.Text == "" || MPCF.ToDbl(txtQty2.Text) == 0)
                        {
                            if (MPGO.ProcessZeroQtyLot() == true)
                            {
                                if (sQtyChk == "")
                                    sQtyChk = "Qty2";
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                txtQty2.Focus();
                                return false;
                            }
                        }
                        if (txtQty2.Text == "")
                        {
                            txtQty2.Text = "0";
                        }
                        if (MPCF.CheckValue(txtQty2, 2) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty2.Focus();
                            return false;
                        }
                    }
                    if (txtQty3.ReadOnly == false)
                    {
                        if (txtQty3.Text == "" || MPCF.ToDbl(txtQty3.Text) == 0)
                        {
                            if (MPGO.ProcessZeroQtyLot() == true)
                            {
                                if (sQtyChk == "")
                                    sQtyChk = "Qty3";
                            }
                            else
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                txtQty3.Focus();
                                return false;
                            }
                        }
                        if (txtQty3.Text == "")
                        {
                            txtQty3.Text = "0";
                        }
                        if (MPCF.CheckValue(txtQty3, 2) == false)
                        {
                            tabTran.SelectedTab = tbpGeneral;
                            txtQty3.Focus();
                            return false;
                        }
                    }

                    if (sQtyChk != "")
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(190), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.No)
                        {
                            switch (sQtyChk)
                            {
                                case "Qty1":
                                    txtQty1.Focus();
                                    break;

                                case "Qty2":
                                    txtQty2.Focus();
                                    break;

                                case "Qty3":
                                    txtQty3.Focus();
                                    break;

                                default:
                                    break;
                            }

                            return false;
                        }                        
                    }

                    if (MPGO.AutoCalDueDate() == false)
                    {
                        if (chkDueDate.Checked == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            chkDueDate.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        if (chkDueDate.Checked == false)
                        {
                            if (txtDueDate.Text == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                txtDueDate.Focus();
                                return false;
                            }
                        }
                    }

                    if (CheckCMFItemValue() == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCrtCMF", "cdvCrtCMF", grpCrtCmf) == false)
                    {
                        tabTran.SelectedTab = tbpCreateCmf;
                        return false;
                    }
                    break;
            }

            return true;

        }
        //
        // GetOperationList()
        //       - Get Operation List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sFlow As String : Flow Name
        //
        private bool GetOperationList(string sFlow)
        {

            try
            {
                cdvOperation.Init();
                MPCF.InitListView(cdvOperation.GetListView);
                cdvOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvOperation.SelectedSubItemIndex = 0;

                if (WIPLIST.ViewOperationList(cdvOperation.GetListView, '2', "", 0, sFlow, "", null, "") == false)
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
        // View_Material()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Material()
        {

            TRSNode in_node = new TRSNode("View_Material_In");
            TRSNode out_node = new TRSNode("View_Material_Out");

            bMFOCheckFlag = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);

            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            bMFOCheckFlag = true;

            sQty1 = out_node.GetDouble("DEF_QTY_1").ToString();
            sQty2 = out_node.GetDouble("DEF_QTY_2").ToString();
            sQty3 = out_node.GetDouble("DEF_QTY_3").ToString();

            cdvFlow.Text = MPCF.Trim(out_node.GetString("FIRST_FLOW"));
            cdvFlow.Sequence = out_node.GetInt("FIRST_FLOW_SEQ_NUM");
            cdvOperation.Text = MPCF.Trim(out_node.GetString("FIRST_OPER"));

            if (MPCF.Trim(cdvOperation.Text) != "")
            {
                if (View_Operation() == false)
                {
                    return false;
                }
            }

            return true;

        }

        //
        // View_Flow()
        //       - View Flow Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Flow()
        {

            TRSNode in_node = new TRSNode("View_Flow_In");
            TRSNode out_node = new TRSNode("View_Flow_Out");

            bMFOCheckFlag = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            bMFOCheckFlag = true;

            cdvOperation.Text = MPCF.Trim(out_node.GetString("FIRST_OPER"));

            if (View_Operation() == false)
            {
                return false;
            }

            return true;

        }

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

            bMFOCheckFlag = false;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            bMFOCheckFlag = true;

            if (MPCF.Trim(out_node.GetString("UNIT_1")) != "")
            {
                txtQty1.ReadOnly = false;
                txtQty1.Text = sQty1;
                lblUnit1.Text = MPCF.Trim(out_node.GetString("UNIT_1"));
            }
            else
            {
                txtQty1.ReadOnly = true;
                txtQty1.Text = "";
                lblUnit1.Text = "";
            }
            if (MPCF.Trim(out_node.GetString("UNIT_2")) != "")
            {
                txtQty2.ReadOnly = false;
                txtQty2.Text = sQty2;
                lblUnit2.Text = MPCF.Trim(out_node.GetString("UNIT_2"));
            }
            else
            {
                txtQty2.ReadOnly = true;
                txtQty2.Text = "";
                lblUnit2.Text = "";
            }
            if (MPCF.Trim(out_node.GetString("UNIT_3")) != "")
            {
                txtQty3.ReadOnly = false;
                txtQty3.Text = sQty3;
                lblUnit3.Text = MPCF.Trim(out_node.GetString("UNIT_3"));
            }
            else
            {
                txtQty3.ReadOnly = true;
                txtQty3.Text = "";
                lblUnit3.Text = "";
            }

            return true;

        }


        //
        // SetDueDate()
        //       - Due Date Auto Calculation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SetDueDate()
        {

            double dSumQueueTime = 0;
            double dSumProcTime = 0;
            double dSumQueueProcTime = 0;
            double dQty1 = 0;

            if (bMFOCheckFlag == false)
            {
                return false;
            }

            if (txtQty1.Text == "")
            {
                txtQty1.Text = "0";
            }

            if (cdvMaterial.CheckValue() == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvFlow, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvOperation, 1) == false)
            {
                return false;
            }

            dQty1 = MPCF.ToDbl(txtQty1.Text);

            if (MPCR.GetProcTime(cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvFlow.Sequence, cdvOperation.Text, dQty1, ref dSumQueueTime, ref dSumProcTime, ref dSumQueueProcTime) == false)
            {
                txtDueDate.Text = "";
                return false;
            }

            //2006.04.25. CM Koo. CycleTime Unit???∞Îùº ?îÌïò???úÍ∞Ñ ?®ÏúÑÎ•??¨Î¶¨ ?ÅÏö©
            if (MPGO.CycleTimeUnit() == "M")
            {
                dtpDueDate.Value = DateTime.Now.AddMinutes(dSumQueueProcTime);
            }
            else
            {
                dtpDueDate.Value = DateTime.Now.AddHours(dSumQueueProcTime);
            }
            txtDueDate.Text = MPCF.MakeDateFormat(MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT), DATE_TIME_FORMAT.DATE);
            
            return true;

        }

        //
        // Create_Lot()
        //       - Create New Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Create_Lot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("CREATE_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("LOT_DESC", MPCF.Trim(txtLotDesc.Text));
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddInt("FLOW_SEQ_NUM", cdvFlow.Sequence);
                in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
                in_node.AddChar("LOT_TYPE", MPCF.ToChar(cdvLotType.Text));
                if (txtQty1.Text != "")
                {
                    in_node.AddDouble("QTY_1", MPCF.ToDbl(txtQty1.Text));
                }
                else
                {
                    in_node.AddDouble("QTY_1", 0);
                }
                if (txtQty2.Text != "")
                {
                    in_node.AddDouble("QTY_2", MPCF.ToDbl(txtQty2.Text));
                }
                else
                {
                    in_node.AddDouble("QTY_2", 0);
                }
                if (txtQty3.Text != "")
                {
                    in_node.AddDouble("QTY_3", MPCF.ToDbl(txtQty3.Text));
                }
                else
                {
                    in_node.AddDouble("QTY_3", 0);
                }
                in_node.AddString("CREATE_CODE", MPCF.Trim(cdvCreateCode.Text));
                in_node.AddString("OWNER_CODE", MPCF.Trim(cdvOwnerCode.Text));
#if _CRR
                in_node.AddString("CRR_ID", MPCF.Trim(cdvCarrier.Text));
#endif
                in_node.AddChar("LOT_PRIORITY", MPCF.ToChar(cboPriority.Text));
                in_node.AddString("DUE_TIME", MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));
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

                in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvCrtCmf1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvCrtCmf2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvCrtCmf3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvCrtCmf4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvCrtCmf5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvCrtCmf6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvCrtCmf7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvCrtCmf8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvCrtCmf9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvCrtCmf10.Text));
                in_node.AddString("LOT_CMF_11", MPCF.Trim(cdvCrtCmf11.Text));
                in_node.AddString("LOT_CMF_12", MPCF.Trim(cdvCrtCmf12.Text));
                in_node.AddString("LOT_CMF_13", MPCF.Trim(cdvCrtCmf13.Text));
                in_node.AddString("LOT_CMF_14", MPCF.Trim(cdvCrtCmf14.Text));
                in_node.AddString("LOT_CMF_15", MPCF.Trim(cdvCrtCmf15.Text));
                in_node.AddString("LOT_CMF_16", MPCF.Trim(cdvCrtCmf16.Text));
                in_node.AddString("LOT_CMF_17", MPCF.Trim(cdvCrtCmf17.Text));
                in_node.AddString("LOT_CMF_18", MPCF.Trim(cdvCrtCmf18.Text));
                in_node.AddString("LOT_CMF_19", MPCF.Trim(cdvCrtCmf19.Text));
                in_node.AddString("LOT_CMF_20", MPCF.Trim(cdvCrtCmf20.Text));

                if (MPCR.CallService("WIP", "WIP_Create_Lot", in_node, ref out_node) == false)
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

        private bool Generate_ID()
        {

            TRSNode in_node = new TRSNode("GENERATE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
                in_node.AddChar("REL_LEVEL", '1');
                in_node.AddString("TRAN_CODE", "CREATE");
                
                if (MPCR.CallService("WIP", "WIP_Generate_ID", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtLotID.Text = MPCF.Trim(out_node.GetString("GEN_ID"));

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion

        private void frmWIPTranCreateLot_Load(object sender, System.EventArgs e)
        {
            this.tabTran.TabPages.Remove(this.tbpCMF);
            this.tabTran.Controls.Add(this.tbpCMF);
#if _CRR
            lblCarrier.Visible = true;
            cdvCarrier.Visible = true;
#endif
        }

        private void frmWIPTranCreateLot_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    SetCMFItem(MPGC.MP_CMF_TRN_CREATE);
                    MPCR.SetCMFItem(MPGC.MP_CMF_LOT, "lblCrtCMF", "cdvCrtCMF", grpCrtCmf);
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvCrtCmf_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);

        }

        private void cdvCrtCmf_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);

        }

        private void cdvMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            cdvFlow.Text = "";
            cdvOperation.Text = "";

            cdvFlow.ListCond_MatID = cdvMaterial.Text;
            cdvFlow.ListCond_MatVersion = cdvMaterial.Version;

            if (View_Material() == false)
            {
                return;
            }

        }

        private void cdvMaterial_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

        }

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            if (cdvMaterial.CheckValue() == false)
            {
                cdvFlow.ListCond_MatID = "";
                cdvFlow.ListCond_MatVersion = 0;
            }
            else
            {
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;
            }
        }

        private void cdvFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            View_Flow();

        }

        private void cdvFlow_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

        }

        private void cdvOperation_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {

            if (View_Operation() == false)
            {
                return;
            }

        }

        private void cdvOperation_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvMaterial.CheckValue() == false)
            {
                return;
            }
            if (cdvFlow.CheckValue() == false)
            {
                return;
            }
            if (GetOperationList(cdvFlow.Text) == false)
            {
                return;
            }

        }

        private void cdvOperation_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            chkDueDate.Checked = false;
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

        }

        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (bMFOCheckFlag == false) return;
                if (CheckCondition("CREATE_LOT", '1') == false) return;
                
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_CREATE, cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOperation.Text, 'B') == false) return;
                if (Create_Lot('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_CREATE, MPCF.Trim(txtLotID.Text), "", "", 'A') == false) return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void chkDueDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            txtDueDate.Visible = !chkDueDate.Checked;
        }

        private void txtQty1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (MPGO.AutoCalDueDate() == true)
                {
                    if (SetDueDate() == false)
                    {
                        return;
                    }
                }
            }

        }

        private void cdvCarrier_ButtonPress(object sender, System.EventArgs e)
        {
#if _CRR
            try
            {
                cdvCarrier.Init();
                MPCF.InitListView(cdvCarrier.GetListView);
                cdvCarrier.Columns.Add("Code", 50, HorizontalAlignment.Left);
                cdvCarrier.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCarrier.SelectedSubItemIndex = 0;

                if (RASLIST.ViewCarrierList(cdvCarrier.GetListView, '2', "", "", "", ' ', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOperation.Text, "", "", cdvCarrier.Text, null, "") == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
#endif
        }

        private void btnCalculation_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (SetDueDate() == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvCreateCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCreateCode.Init();
            MPCF.InitListView(cdvCreateCode.GetListView);
            cdvCreateCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvCreateCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCreateCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvCreateCode.GetListView, '1', MPGC.MP_WIP_CREATE_CODE);
        }

        private void cdvOwnerCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOwnerCode.Init();
            MPCF.InitListView(cdvOwnerCode.GetListView);
            cdvOwnerCode.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvOwnerCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOwnerCode.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvOwnerCode.GetListView, '1', MPGC.MP_WIP_OWNER_CODE);
        }
        private void cdvLotType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvLotType.Init();
            MPCF.InitListView(cdvLotType.GetListView);
            cdvLotType.Columns.Add("LotType", 50, HorizontalAlignment.Left);
            cdvLotType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvLotType.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvLotType.GetListView, '1', MPGC.MP_WIP_LOT_TYPE);
        }

        private void cdvOperation_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cdvOperation.Text != "")
                {
                    if (View_Operation() == false)
                    {
                        return;
                    }
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (CheckCondition("CREATE_LOT", '2') == false) return;
            Generate_ID();
        }

    }


}
