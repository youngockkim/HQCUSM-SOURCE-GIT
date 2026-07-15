
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
//   File Name   : frmINVTranConvToLot.vb
//   Description : Convert Inventory To Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - Conv_To_Lot() : Inventory Convert Inventory To Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-12 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _INV = True Then

namespace Miracom.INVCore
{
    public class frmINVTranConvToLot : Miracom.MESCore.TranForm09
    {
        
        #region " Windows Form ?îÏûê?¥ÎÑà?êÏÑú ?ùÏÑ±??ÏΩîÎìú "
        
        public frmINVTranConvToLot()
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
        



        internal System.Windows.Forms.GroupBox grpToLotID;
        internal System.Windows.Forms.GroupBox grpTransInfo;
        internal System.Windows.Forms.TextBox txtDueDate;
        internal System.Windows.Forms.Label lblConvertUnit3;
        internal System.Windows.Forms.Label lblConvertUnit2;
        internal System.Windows.Forms.Label lblConvertUnit1;
        internal System.Windows.Forms.CheckBox chkDueDate;
        internal System.Windows.Forms.Label lblConvetQty3;
        internal System.Windows.Forms.Label lblConvetQty2;
        internal System.Windows.Forms.ComboBox cboPriority;
        internal System.Windows.Forms.Label lblCreateCode;
        internal System.Windows.Forms.DateTimePicker dtpDueDate;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvOwnerCode;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCode;
        internal System.Windows.Forms.Label lblPriority;
        internal System.Windows.Forms.Label lblOwnerCode;
        internal System.Windows.Forms.TextBox txtConvertQty3;
        internal System.Windows.Forms.TextBox txtConvertQty2;
        internal System.Windows.Forms.TextBox txtConvertQty1;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvLotType;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        internal System.Windows.Forms.Label lblConvetQty1;
        internal System.Windows.Forms.Label lblLotType;
        internal System.Windows.Forms.Label lblOperation;
        protected System.Windows.Forms.TextBox txtLotID;
        protected System.Windows.Forms.Label lblLotID;
        internal System.Windows.Forms.TabPage tbpCreateCMF;
        protected System.Windows.Forms.Panel pnlCreateCMF;
        protected System.Windows.Forms.GroupBox grpCreateCMF;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF1;
        protected System.Windows.Forms.Label lblCreateCMF10;
        protected System.Windows.Forms.Label lblCreateCMF9;
        protected System.Windows.Forms.Label lblCreateCMF8;
        protected System.Windows.Forms.Label lblCreateCMF7;
        protected System.Windows.Forms.Label lblCreateCMF6;
        protected System.Windows.Forms.Label lblCreateCMF5;
        protected System.Windows.Forms.Label lblCreateCMF4;
        protected System.Windows.Forms.Label lblCreateCMF3;
        protected System.Windows.Forms.Label lblCreateCMF2;
        protected System.Windows.Forms.Label lblCreateCMF1;
        protected System.Windows.Forms.TextBox txtLotDesc;
        protected System.Windows.Forms.Label lblLotDesc;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF17;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF16;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF15;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF14;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF13;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF12;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF11;
        protected System.Windows.Forms.Label lblCreateCMF20;
        protected System.Windows.Forms.Label lblCreateCMF19;
        protected System.Windows.Forms.Label lblCreateCMF18;
        protected System.Windows.Forms.Label lblCreateCMF17;
        protected System.Windows.Forms.Label lblCreateCMF16;
        protected System.Windows.Forms.Label lblCreateCMF15;
        protected System.Windows.Forms.Label lblCreateCMF14;
        protected System.Windows.Forms.Label lblCreateCMF13;
        protected System.Windows.Forms.Label lblCreateCMF12;
        protected System.Windows.Forms.Label lblCreateCMF11;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF19;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF18;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCreateCMF20;
        internal System.Windows.Forms.TabPage tbpCreateTrnCMF;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf1;
        protected System.Windows.Forms.Label lblCrtTranCmf10;
        protected System.Windows.Forms.Label lblCrtTranCmf9;
        protected System.Windows.Forms.Label lblCrtTranCmf8;
        protected System.Windows.Forms.Label lblCrtTranCmf7;
        protected System.Windows.Forms.Label lblCrtTranCmf6;
        protected System.Windows.Forms.Label lblCrtTranCmf5;
        protected System.Windows.Forms.Label lblCrtTranCmf4;
        protected System.Windows.Forms.Label lblCrtTranCmf3;
        protected System.Windows.Forms.Label lblCrtTranCmf2;
        protected System.Windows.Forms.Label lblCrtTranCmf1;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf19;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf18;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf17;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf16;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf15;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf14;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf13;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf12;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf20;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrtTranCmf11;
        protected Label lblCrtTranCmf20;
        protected Label lblCrtTranCmf19;
        protected Label lblCrtTranCmf18;
        protected Label lblCrtTranCmf17;
        protected Label lblCrtTranCmf16;
        protected Label lblCrtTranCmf15;
        protected Label lblCrtTranCmf14;
        protected Label lblCrtTranCmf13;
        protected Label lblCrtTranCmf12;
        protected Label lblCrtTranCmf11;
        protected System.Windows.Forms.GroupBox grpCrtTranCmf;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpToLotID = new System.Windows.Forms.GroupBox();
            this.txtLotDesc = new System.Windows.Forms.TextBox();
            this.lblLotDesc = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.grpTransInfo = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.lblConvertUnit3 = new System.Windows.Forms.Label();
            this.lblConvertUnit2 = new System.Windows.Forms.Label();
            this.lblConvertUnit1 = new System.Windows.Forms.Label();
            this.chkDueDate = new System.Windows.Forms.CheckBox();
            this.lblConvetQty3 = new System.Windows.Forms.Label();
            this.lblConvetQty2 = new System.Windows.Forms.Label();
            this.cboPriority = new System.Windows.Forms.ComboBox();
            this.lblCreateCode = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.cdvOwnerCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblOwnerCode = new System.Windows.Forms.Label();
            this.txtConvertQty3 = new System.Windows.Forms.TextBox();
            this.txtConvertQty2 = new System.Windows.Forms.TextBox();
            this.txtConvertQty1 = new System.Windows.Forms.TextBox();
            this.cdvLotType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblConvetQty1 = new System.Windows.Forms.Label();
            this.lblLotType = new System.Windows.Forms.Label();
            this.lblOperation = new System.Windows.Forms.Label();
            this.tbpCreateCMF = new System.Windows.Forms.TabPage();
            this.pnlCreateCMF = new System.Windows.Forms.Panel();
            this.grpCreateCMF = new System.Windows.Forms.GroupBox();
            this.cdvCreateCMF19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCreateCMF20 = new System.Windows.Forms.Label();
            this.lblCreateCMF19 = new System.Windows.Forms.Label();
            this.lblCreateCMF18 = new System.Windows.Forms.Label();
            this.lblCreateCMF17 = new System.Windows.Forms.Label();
            this.lblCreateCMF16 = new System.Windows.Forms.Label();
            this.lblCreateCMF15 = new System.Windows.Forms.Label();
            this.lblCreateCMF14 = new System.Windows.Forms.Label();
            this.lblCreateCMF13 = new System.Windows.Forms.Label();
            this.lblCreateCMF12 = new System.Windows.Forms.Label();
            this.lblCreateCMF11 = new System.Windows.Forms.Label();
            this.cdvCreateCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCreateCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCreateCMF10 = new System.Windows.Forms.Label();
            this.lblCreateCMF9 = new System.Windows.Forms.Label();
            this.lblCreateCMF8 = new System.Windows.Forms.Label();
            this.lblCreateCMF7 = new System.Windows.Forms.Label();
            this.lblCreateCMF6 = new System.Windows.Forms.Label();
            this.lblCreateCMF5 = new System.Windows.Forms.Label();
            this.lblCreateCMF4 = new System.Windows.Forms.Label();
            this.lblCreateCMF3 = new System.Windows.Forms.Label();
            this.lblCreateCMF2 = new System.Windows.Forms.Label();
            this.lblCreateCMF1 = new System.Windows.Forms.Label();
            this.tbpCreateTrnCMF = new System.Windows.Forms.TabPage();
            this.grpCrtTranCmf = new System.Windows.Forms.GroupBox();
            this.cdvCrtTranCmf19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrtTranCmf20 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf19 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf18 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf17 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf16 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf15 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf14 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf13 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf12 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf11 = new System.Windows.Forms.Label();
            this.cdvCrtTranCmf9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCrtTranCmf1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrtTranCmf10 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf9 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf8 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf7 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf6 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf5 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf4 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf3 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf2 = new System.Windows.Forms.Label();
            this.lblCrtTranCmf1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatID)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.pnlInventoryInfo.SuspendLayout();
            this.grpInventoryInfo.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatVersion)).BeginInit();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpToLotID.SuspendLayout();
            this.grpTransInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            this.tbpCreateCMF.SuspendLayout();
            this.pnlCreateCMF.SuspendLayout();
            this.grpCreateCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF1)).BeginInit();
            this.tbpCreateTrnCMF.SuspendLayout();
            this.grpCrtTranCmf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf1)).BeginInit();
            this.SuspendLayout();
            // 
            // cdvInvOper
            // 
            this.cdvInvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvInvOper_SelectedItemChanged);
            this.cdvInvOper.ButtonPress += new System.EventHandler(this.cdvInvOper_ButtonPress);
            // 
            // cdvMatID
            // 
            this.cdvMatID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_SelectedItemChanged);
            this.cdvMatID.ButtonPress += new System.EventHandler(this.cdvMatID_ButtonPress);
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.MaxLength = 30;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            // 
            // lblInvOper
            // 
            this.lblInvOper.AutoSize = true;
            this.lblInvOper.Size = new System.Drawing.Size(91, 13);
            // 
            // lblMatID
            // 
            this.lblMatID.AutoSize = true;
            this.lblMatID.Size = new System.Drawing.Size(52, 13);
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpCreateTrnCMF);
            this.tabTran.Controls.Add(this.tbpCreateCMF);
            this.tabTran.Size = new System.Drawing.Size(736, 448);
            this.tabTran.Controls.SetChildIndex(this.tbpCreateCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpCreateTrnCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpCMF, 0);
            this.tabTran.Controls.SetChildIndex(this.tbpGeneral, 0);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Size = new System.Drawing.Size(728, 422);
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpTransInfo);
            this.pnlTranInfo.Controls.Add(this.grpToLotID);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 382);
            this.pnlTranInfo.Controls.SetChildIndex(this.pnlInventoryInfo, 0);
            this.pnlTranInfo.Controls.SetChildIndex(this.grpToLotID, 0);
            this.pnlTranInfo.Controls.SetChildIndex(this.grpTransInfo, 0);
            // 
            // lblLastHistSeq
            // 
            this.lblLastHistSeq.AutoSize = true;
            this.lblLastHistSeq.Size = new System.Drawing.Size(70, 13);
            // 
            // txtLastTranTime
            // 
            this.txtLastTranTime.MaxLength = 30;
            // 
            // lblLastTranTime
            // 
            this.lblLastTranTime.AutoSize = true;
            this.lblLastTranTime.Size = new System.Drawing.Size(78, 13);
            // 
            // lblLastTranCode
            // 
            this.lblLastTranCode.AutoSize = true;
            this.lblLastTranCode.Size = new System.Drawing.Size(80, 13);
            // 
            // lblAllocQty
            // 
            this.lblAllocQty.AutoSize = true;
            this.lblAllocQty.Size = new System.Drawing.Size(49, 13);
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.Size = new System.Drawing.Size(23, 13);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(0, 382);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Size = new System.Drawing.Size(728, 422);
            // 
            // grpCMF
            // 
            this.grpCMF.Size = new System.Drawing.Size(722, 419);
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
            // cdvMatVersion
            // 
            this.cdvMatVersion.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMatVersion.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMatVersion.ButtonPress += new System.EventHandler(this.cdvMatVersion_ButtonPress);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 451);
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
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Convert Inventory To Lot";
            // 
            // grpToLotID
            // 
            this.grpToLotID.Controls.Add(this.txtLotDesc);
            this.grpToLotID.Controls.Add(this.lblLotDesc);
            this.grpToLotID.Controls.Add(this.txtLotID);
            this.grpToLotID.Controls.Add(this.lblLotID);
            this.grpToLotID.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpToLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpToLotID.Location = new System.Drawing.Point(3, 96);
            this.grpToLotID.Name = "grpToLotID";
            this.grpToLotID.Size = new System.Drawing.Size(722, 71);
            this.grpToLotID.TabIndex = 0;
            this.grpToLotID.TabStop = false;
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotDesc.Location = new System.Drawing.Point(120, 40);
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.Name = "txtLotDesc";
            this.txtLotDesc.Size = new System.Drawing.Size(596, 20);
            this.txtLotDesc.TabIndex = 3;
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotDesc.Location = new System.Drawing.Point(15, 43);
            this.lblLotDesc.Name = "lblLotDesc";
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            this.lblLotDesc.TabIndex = 2;
            this.lblLotDesc.Text = "Description";
            this.lblLotDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 1;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 20);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(45, 15);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpTransInfo
            // 
            this.grpTransInfo.Controls.Add(this.cdvFlow);
            this.grpTransInfo.Controls.Add(this.cdvMaterial);
            this.grpTransInfo.Controls.Add(this.txtDueDate);
            this.grpTransInfo.Controls.Add(this.lblConvertUnit3);
            this.grpTransInfo.Controls.Add(this.lblConvertUnit2);
            this.grpTransInfo.Controls.Add(this.lblConvertUnit1);
            this.grpTransInfo.Controls.Add(this.chkDueDate);
            this.grpTransInfo.Controls.Add(this.lblConvetQty3);
            this.grpTransInfo.Controls.Add(this.lblConvetQty2);
            this.grpTransInfo.Controls.Add(this.cboPriority);
            this.grpTransInfo.Controls.Add(this.lblCreateCode);
            this.grpTransInfo.Controls.Add(this.dtpDueDate);
            this.grpTransInfo.Controls.Add(this.cdvOwnerCode);
            this.grpTransInfo.Controls.Add(this.cdvCreateCode);
            this.grpTransInfo.Controls.Add(this.lblPriority);
            this.grpTransInfo.Controls.Add(this.lblOwnerCode);
            this.grpTransInfo.Controls.Add(this.txtConvertQty3);
            this.grpTransInfo.Controls.Add(this.txtConvertQty2);
            this.grpTransInfo.Controls.Add(this.txtConvertQty1);
            this.grpTransInfo.Controls.Add(this.cdvLotType);
            this.grpTransInfo.Controls.Add(this.cdvOperation);
            this.grpTransInfo.Controls.Add(this.lblConvetQty1);
            this.grpTransInfo.Controls.Add(this.lblLotType);
            this.grpTransInfo.Controls.Add(this.lblOperation);
            this.grpTransInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTransInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTransInfo.Location = new System.Drawing.Point(3, 167);
            this.grpTransInfo.Name = "grpTransInfo";
            this.grpTransInfo.Size = new System.Drawing.Size(722, 215);
            this.grpTransInfo.TabIndex = 1;
            this.grpTransInfo.TabStop = false;
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
            this.cdvFlow.LabelWidth = 107;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(13, 40);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(307, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 200;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
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
            this.cdvMaterial.Location = new System.Drawing.Point(13, 15);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(307, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 107;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            this.cdvMaterial.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            // 
            // txtDueDate
            // 
            this.txtDueDate.Location = new System.Drawing.Point(458, 113);
            this.txtDueDate.MaxLength = 30;
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.ReadOnly = true;
            this.txtDueDate.Size = new System.Drawing.Size(200, 20);
            this.txtDueDate.TabIndex = 22;
            this.txtDueDate.TabStop = false;
            // 
            // lblConvertUnit3
            // 
            this.lblConvertUnit3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblConvertUnit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvertUnit3.Location = new System.Drawing.Point(213, 139);
            this.lblConvertUnit3.Name = "lblConvertUnit3";
            this.lblConvertUnit3.Size = new System.Drawing.Size(100, 14);
            this.lblConvertUnit3.TabIndex = 12;
            this.lblConvertUnit3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConvertUnit2
            // 
            this.lblConvertUnit2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblConvertUnit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvertUnit2.Location = new System.Drawing.Point(213, 115);
            this.lblConvertUnit2.Name = "lblConvertUnit2";
            this.lblConvertUnit2.Size = new System.Drawing.Size(100, 14);
            this.lblConvertUnit2.TabIndex = 9;
            this.lblConvertUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConvertUnit1
            // 
            this.lblConvertUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblConvertUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvertUnit1.Location = new System.Drawing.Point(213, 91);
            this.lblConvertUnit1.Name = "lblConvertUnit1";
            this.lblConvertUnit1.Size = new System.Drawing.Size(100, 14);
            this.lblConvertUnit1.TabIndex = 6;
            this.lblConvertUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDueDate
            // 
            this.chkDueDate.AutoSize = true;
            this.chkDueDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDueDate.Location = new System.Drawing.Point(352, 115);
            this.chkDueDate.Name = "chkDueDate";
            this.chkDueDate.Size = new System.Drawing.Size(78, 18);
            this.chkDueDate.TabIndex = 21;
            this.chkDueDate.Text = "Due Date";
            this.chkDueDate.CheckedChanged += new System.EventHandler(this.chkDueDate_CheckedChanged);
            // 
            // lblConvetQty3
            // 
            this.lblConvetQty3.AutoSize = true;
            this.lblConvetQty3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblConvetQty3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvetQty3.Location = new System.Drawing.Point(13, 139);
            this.lblConvetQty3.Name = "lblConvetQty3";
            this.lblConvetQty3.Size = new System.Drawing.Size(72, 13);
            this.lblConvetQty3.TabIndex = 10;
            this.lblConvetQty3.Text = "Convert Qty 3";
            this.lblConvetQty3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConvetQty2
            // 
            this.lblConvetQty2.AutoSize = true;
            this.lblConvetQty2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblConvetQty2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvetQty2.Location = new System.Drawing.Point(13, 115);
            this.lblConvetQty2.Name = "lblConvetQty2";
            this.lblConvetQty2.Size = new System.Drawing.Size(72, 13);
            this.lblConvetQty2.TabIndex = 7;
            this.lblConvetQty2.Text = "Convert Qty 2";
            this.lblConvetQty2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblCreateCode.Location = new System.Drawing.Point(352, 19);
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
            this.dtpDueDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDueDate.TabIndex = 45;
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
            this.lblPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriority.Location = new System.Drawing.Point(352, 91);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(46, 13);
            this.lblPriority.TabIndex = 19;
            this.lblPriority.Text = "Priority";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOwnerCode
            // 
            this.lblOwnerCode.AutoSize = true;
            this.lblOwnerCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOwnerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnerCode.Location = new System.Drawing.Point(352, 43);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(76, 13);
            this.lblOwnerCode.TabIndex = 15;
            this.lblOwnerCode.Text = "Owner Code";
            this.lblOwnerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtConvertQty3
            // 
            this.txtConvertQty3.Location = new System.Drawing.Point(120, 136);
            this.txtConvertQty3.MaxLength = 11;
            this.txtConvertQty3.Name = "txtConvertQty3";
            this.txtConvertQty3.ReadOnly = true;
            this.txtConvertQty3.Size = new System.Drawing.Size(88, 20);
            this.txtConvertQty3.TabIndex = 11;
            this.txtConvertQty3.TabStop = false;
            // 
            // txtConvertQty2
            // 
            this.txtConvertQty2.Location = new System.Drawing.Point(120, 112);
            this.txtConvertQty2.MaxLength = 11;
            this.txtConvertQty2.Name = "txtConvertQty2";
            this.txtConvertQty2.ReadOnly = true;
            this.txtConvertQty2.Size = new System.Drawing.Size(88, 20);
            this.txtConvertQty2.TabIndex = 8;
            this.txtConvertQty2.TabStop = false;
            // 
            // txtConvertQty1
            // 
            this.txtConvertQty1.Location = new System.Drawing.Point(120, 88);
            this.txtConvertQty1.MaxLength = 11;
            this.txtConvertQty1.Name = "txtConvertQty1";
            this.txtConvertQty1.ReadOnly = true;
            this.txtConvertQty1.Size = new System.Drawing.Size(88, 20);
            this.txtConvertQty1.TabIndex = 5;
            this.txtConvertQty1.TabStop = false;
            this.txtConvertQty1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConvertQty1_KeyPress);
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
            this.cdvOperation.Location = new System.Drawing.Point(120, 64);
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
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            this.cdvOperation.TextBoxTextChanged += new System.EventHandler(this.cdvOperation_TextBoxTextChanged);
            // 
            // lblConvetQty1
            // 
            this.lblConvetQty1.AutoSize = true;
            this.lblConvetQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblConvetQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvetQty1.Location = new System.Drawing.Point(13, 91);
            this.lblConvetQty1.Name = "lblConvetQty1";
            this.lblConvetQty1.Size = new System.Drawing.Size(85, 13);
            this.lblConvetQty1.TabIndex = 4;
            this.lblConvetQty1.Text = "Convert Qty 1";
            this.lblConvetQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLotType
            // 
            this.lblLotType.AutoSize = true;
            this.lblLotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotType.Location = new System.Drawing.Point(352, 67);
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
            this.lblOperation.Location = new System.Drawing.Point(13, 67);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(62, 13);
            this.lblOperation.TabIndex = 2;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCreateCMF
            // 
            this.tbpCreateCMF.Controls.Add(this.pnlCreateCMF);
            this.tbpCreateCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCreateCMF.Name = "tbpCreateCMF";
            this.tbpCreateCMF.Size = new System.Drawing.Size(728, 415);
            this.tbpCreateCMF.TabIndex = 2;
            this.tbpCreateCMF.Text = "Create Customized Field";
            // 
            // pnlCreateCMF
            // 
            this.pnlCreateCMF.Controls.Add(this.grpCreateCMF);
            this.pnlCreateCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCreateCMF.Location = new System.Drawing.Point(0, 0);
            this.pnlCreateCMF.Name = "pnlCreateCMF";
            this.pnlCreateCMF.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCreateCMF.Size = new System.Drawing.Size(728, 415);
            this.pnlCreateCMF.TabIndex = 1;
            // 
            // grpCreateCMF
            // 
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF19);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF18);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF17);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF16);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF15);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF14);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF13);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF12);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF20);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF11);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF20);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF19);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF18);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF17);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF16);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF15);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF14);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF13);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF12);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF11);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF9);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF8);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF7);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF6);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF5);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF4);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF3);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF2);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF10);
            this.grpCreateCMF.Controls.Add(this.cdvCreateCMF1);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF10);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF9);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF8);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF7);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF6);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF5);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF4);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF3);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF2);
            this.grpCreateCMF.Controls.Add(this.lblCreateCMF1);
            this.grpCreateCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCreateCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreateCMF.Location = new System.Drawing.Point(3, 3);
            this.grpCreateCMF.Name = "grpCreateCMF";
            this.grpCreateCMF.Size = new System.Drawing.Size(722, 409);
            this.grpCreateCMF.TabIndex = 0;
            this.grpCreateCMF.TabStop = false;
            // 
            // cdvCreateCMF19
            // 
            this.cdvCreateCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF19.BtnToolTipText = "";
            this.cdvCreateCMF19.DescText = "";
            this.cdvCreateCMF19.DisplaySubItemIndex = -1;
            this.cdvCreateCMF19.DisplayText = "";
            this.cdvCreateCMF19.Focusing = null;
            this.cdvCreateCMF19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF19.Index = 0;
            this.cdvCreateCMF19.IsViewBtnImage = false;
            this.cdvCreateCMF19.Location = new System.Drawing.Point(519, 208);
            this.cdvCreateCMF19.MaxLength = 30;
            this.cdvCreateCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF19.Name = "cdvCreateCMF19";
            this.cdvCreateCMF19.ReadOnly = false;
            this.cdvCreateCMF19.SearchSubItemIndex = 0;
            this.cdvCreateCMF19.SelectedDescIndex = -1;
            this.cdvCreateCMF19.SelectedSubItemIndex = -1;
            this.cdvCreateCMF19.SelectionStart = 0;
            this.cdvCreateCMF19.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF19.SmallImageList = null;
            this.cdvCreateCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF19.TabIndex = 37;
            this.cdvCreateCMF19.TextBoxToolTipText = "";
            this.cdvCreateCMF19.TextBoxWidth = 180;
            this.cdvCreateCMF19.VisibleButton = true;
            this.cdvCreateCMF19.VisibleColumnHeader = false;
            this.cdvCreateCMF19.VisibleDescription = false;
            this.cdvCreateCMF19.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF18
            // 
            this.cdvCreateCMF18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF18.BtnToolTipText = "";
            this.cdvCreateCMF18.DescText = "";
            this.cdvCreateCMF18.DisplaySubItemIndex = -1;
            this.cdvCreateCMF18.DisplayText = "";
            this.cdvCreateCMF18.Focusing = null;
            this.cdvCreateCMF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF18.Index = 0;
            this.cdvCreateCMF18.IsViewBtnImage = false;
            this.cdvCreateCMF18.Location = new System.Drawing.Point(519, 184);
            this.cdvCreateCMF18.MaxLength = 30;
            this.cdvCreateCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF18.Name = "cdvCreateCMF18";
            this.cdvCreateCMF18.ReadOnly = false;
            this.cdvCreateCMF18.SearchSubItemIndex = 0;
            this.cdvCreateCMF18.SelectedDescIndex = -1;
            this.cdvCreateCMF18.SelectedSubItemIndex = -1;
            this.cdvCreateCMF18.SelectionStart = 0;
            this.cdvCreateCMF18.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF18.SmallImageList = null;
            this.cdvCreateCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF18.TabIndex = 35;
            this.cdvCreateCMF18.TextBoxToolTipText = "";
            this.cdvCreateCMF18.TextBoxWidth = 180;
            this.cdvCreateCMF18.VisibleButton = true;
            this.cdvCreateCMF18.VisibleColumnHeader = false;
            this.cdvCreateCMF18.VisibleDescription = false;
            this.cdvCreateCMF18.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF17
            // 
            this.cdvCreateCMF17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF17.BtnToolTipText = "";
            this.cdvCreateCMF17.DescText = "";
            this.cdvCreateCMF17.DisplaySubItemIndex = -1;
            this.cdvCreateCMF17.DisplayText = "";
            this.cdvCreateCMF17.Focusing = null;
            this.cdvCreateCMF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF17.Index = 0;
            this.cdvCreateCMF17.IsViewBtnImage = false;
            this.cdvCreateCMF17.Location = new System.Drawing.Point(519, 160);
            this.cdvCreateCMF17.MaxLength = 30;
            this.cdvCreateCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF17.Name = "cdvCreateCMF17";
            this.cdvCreateCMF17.ReadOnly = false;
            this.cdvCreateCMF17.SearchSubItemIndex = 0;
            this.cdvCreateCMF17.SelectedDescIndex = -1;
            this.cdvCreateCMF17.SelectedSubItemIndex = -1;
            this.cdvCreateCMF17.SelectionStart = 0;
            this.cdvCreateCMF17.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF17.SmallImageList = null;
            this.cdvCreateCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF17.TabIndex = 33;
            this.cdvCreateCMF17.TextBoxToolTipText = "";
            this.cdvCreateCMF17.TextBoxWidth = 180;
            this.cdvCreateCMF17.VisibleButton = true;
            this.cdvCreateCMF17.VisibleColumnHeader = false;
            this.cdvCreateCMF17.VisibleDescription = false;
            this.cdvCreateCMF17.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF16
            // 
            this.cdvCreateCMF16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF16.BtnToolTipText = "";
            this.cdvCreateCMF16.DescText = "";
            this.cdvCreateCMF16.DisplaySubItemIndex = -1;
            this.cdvCreateCMF16.DisplayText = "";
            this.cdvCreateCMF16.Focusing = null;
            this.cdvCreateCMF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF16.Index = 0;
            this.cdvCreateCMF16.IsViewBtnImage = false;
            this.cdvCreateCMF16.Location = new System.Drawing.Point(519, 136);
            this.cdvCreateCMF16.MaxLength = 30;
            this.cdvCreateCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF16.Name = "cdvCreateCMF16";
            this.cdvCreateCMF16.ReadOnly = false;
            this.cdvCreateCMF16.SearchSubItemIndex = 0;
            this.cdvCreateCMF16.SelectedDescIndex = -1;
            this.cdvCreateCMF16.SelectedSubItemIndex = -1;
            this.cdvCreateCMF16.SelectionStart = 0;
            this.cdvCreateCMF16.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF16.SmallImageList = null;
            this.cdvCreateCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF16.TabIndex = 31;
            this.cdvCreateCMF16.TextBoxToolTipText = "";
            this.cdvCreateCMF16.TextBoxWidth = 180;
            this.cdvCreateCMF16.VisibleButton = true;
            this.cdvCreateCMF16.VisibleColumnHeader = false;
            this.cdvCreateCMF16.VisibleDescription = false;
            this.cdvCreateCMF16.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF15
            // 
            this.cdvCreateCMF15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF15.BtnToolTipText = "";
            this.cdvCreateCMF15.DescText = "";
            this.cdvCreateCMF15.DisplaySubItemIndex = -1;
            this.cdvCreateCMF15.DisplayText = "";
            this.cdvCreateCMF15.Focusing = null;
            this.cdvCreateCMF15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF15.Index = 0;
            this.cdvCreateCMF15.IsViewBtnImage = false;
            this.cdvCreateCMF15.Location = new System.Drawing.Point(519, 112);
            this.cdvCreateCMF15.MaxLength = 30;
            this.cdvCreateCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF15.Name = "cdvCreateCMF15";
            this.cdvCreateCMF15.ReadOnly = false;
            this.cdvCreateCMF15.SearchSubItemIndex = 0;
            this.cdvCreateCMF15.SelectedDescIndex = -1;
            this.cdvCreateCMF15.SelectedSubItemIndex = -1;
            this.cdvCreateCMF15.SelectionStart = 0;
            this.cdvCreateCMF15.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF15.SmallImageList = null;
            this.cdvCreateCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF15.TabIndex = 29;
            this.cdvCreateCMF15.TextBoxToolTipText = "";
            this.cdvCreateCMF15.TextBoxWidth = 180;
            this.cdvCreateCMF15.VisibleButton = true;
            this.cdvCreateCMF15.VisibleColumnHeader = false;
            this.cdvCreateCMF15.VisibleDescription = false;
            this.cdvCreateCMF15.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF14
            // 
            this.cdvCreateCMF14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF14.BtnToolTipText = "";
            this.cdvCreateCMF14.DescText = "";
            this.cdvCreateCMF14.DisplaySubItemIndex = -1;
            this.cdvCreateCMF14.DisplayText = "";
            this.cdvCreateCMF14.Focusing = null;
            this.cdvCreateCMF14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF14.Index = 0;
            this.cdvCreateCMF14.IsViewBtnImage = false;
            this.cdvCreateCMF14.Location = new System.Drawing.Point(519, 88);
            this.cdvCreateCMF14.MaxLength = 30;
            this.cdvCreateCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF14.Name = "cdvCreateCMF14";
            this.cdvCreateCMF14.ReadOnly = false;
            this.cdvCreateCMF14.SearchSubItemIndex = 0;
            this.cdvCreateCMF14.SelectedDescIndex = -1;
            this.cdvCreateCMF14.SelectedSubItemIndex = -1;
            this.cdvCreateCMF14.SelectionStart = 0;
            this.cdvCreateCMF14.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF14.SmallImageList = null;
            this.cdvCreateCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF14.TabIndex = 27;
            this.cdvCreateCMF14.TextBoxToolTipText = "";
            this.cdvCreateCMF14.TextBoxWidth = 180;
            this.cdvCreateCMF14.VisibleButton = true;
            this.cdvCreateCMF14.VisibleColumnHeader = false;
            this.cdvCreateCMF14.VisibleDescription = false;
            this.cdvCreateCMF14.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF13
            // 
            this.cdvCreateCMF13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF13.BtnToolTipText = "";
            this.cdvCreateCMF13.DescText = "";
            this.cdvCreateCMF13.DisplaySubItemIndex = -1;
            this.cdvCreateCMF13.DisplayText = "";
            this.cdvCreateCMF13.Focusing = null;
            this.cdvCreateCMF13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF13.Index = 0;
            this.cdvCreateCMF13.IsViewBtnImage = false;
            this.cdvCreateCMF13.Location = new System.Drawing.Point(519, 64);
            this.cdvCreateCMF13.MaxLength = 30;
            this.cdvCreateCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF13.Name = "cdvCreateCMF13";
            this.cdvCreateCMF13.ReadOnly = false;
            this.cdvCreateCMF13.SearchSubItemIndex = 0;
            this.cdvCreateCMF13.SelectedDescIndex = -1;
            this.cdvCreateCMF13.SelectedSubItemIndex = -1;
            this.cdvCreateCMF13.SelectionStart = 0;
            this.cdvCreateCMF13.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF13.SmallImageList = null;
            this.cdvCreateCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF13.TabIndex = 25;
            this.cdvCreateCMF13.TextBoxToolTipText = "";
            this.cdvCreateCMF13.TextBoxWidth = 180;
            this.cdvCreateCMF13.VisibleButton = true;
            this.cdvCreateCMF13.VisibleColumnHeader = false;
            this.cdvCreateCMF13.VisibleDescription = false;
            this.cdvCreateCMF13.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF12
            // 
            this.cdvCreateCMF12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF12.BtnToolTipText = "";
            this.cdvCreateCMF12.DescText = "";
            this.cdvCreateCMF12.DisplaySubItemIndex = -1;
            this.cdvCreateCMF12.DisplayText = "";
            this.cdvCreateCMF12.Focusing = null;
            this.cdvCreateCMF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF12.Index = 0;
            this.cdvCreateCMF12.IsViewBtnImage = false;
            this.cdvCreateCMF12.Location = new System.Drawing.Point(519, 40);
            this.cdvCreateCMF12.MaxLength = 30;
            this.cdvCreateCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF12.Name = "cdvCreateCMF12";
            this.cdvCreateCMF12.ReadOnly = false;
            this.cdvCreateCMF12.SearchSubItemIndex = 0;
            this.cdvCreateCMF12.SelectedDescIndex = -1;
            this.cdvCreateCMF12.SelectedSubItemIndex = -1;
            this.cdvCreateCMF12.SelectionStart = 0;
            this.cdvCreateCMF12.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF12.SmallImageList = null;
            this.cdvCreateCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF12.TabIndex = 23;
            this.cdvCreateCMF12.TextBoxToolTipText = "";
            this.cdvCreateCMF12.TextBoxWidth = 180;
            this.cdvCreateCMF12.VisibleButton = true;
            this.cdvCreateCMF12.VisibleColumnHeader = false;
            this.cdvCreateCMF12.VisibleDescription = false;
            this.cdvCreateCMF12.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF20
            // 
            this.cdvCreateCMF20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF20.BtnToolTipText = "";
            this.cdvCreateCMF20.DescText = "";
            this.cdvCreateCMF20.DisplaySubItemIndex = -1;
            this.cdvCreateCMF20.DisplayText = "";
            this.cdvCreateCMF20.Focusing = null;
            this.cdvCreateCMF20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF20.Index = 0;
            this.cdvCreateCMF20.IsViewBtnImage = false;
            this.cdvCreateCMF20.Location = new System.Drawing.Point(519, 232);
            this.cdvCreateCMF20.MaxLength = 30;
            this.cdvCreateCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF20.Name = "cdvCreateCMF20";
            this.cdvCreateCMF20.ReadOnly = false;
            this.cdvCreateCMF20.SearchSubItemIndex = 0;
            this.cdvCreateCMF20.SelectedDescIndex = -1;
            this.cdvCreateCMF20.SelectedSubItemIndex = -1;
            this.cdvCreateCMF20.SelectionStart = 0;
            this.cdvCreateCMF20.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF20.SmallImageList = null;
            this.cdvCreateCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF20.TabIndex = 39;
            this.cdvCreateCMF20.TextBoxToolTipText = "";
            this.cdvCreateCMF20.TextBoxWidth = 180;
            this.cdvCreateCMF20.VisibleButton = true;
            this.cdvCreateCMF20.VisibleColumnHeader = false;
            this.cdvCreateCMF20.VisibleDescription = false;
            this.cdvCreateCMF20.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF11
            // 
            this.cdvCreateCMF11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF11.BtnToolTipText = "";
            this.cdvCreateCMF11.DescText = "";
            this.cdvCreateCMF11.DisplaySubItemIndex = -1;
            this.cdvCreateCMF11.DisplayText = "";
            this.cdvCreateCMF11.Focusing = null;
            this.cdvCreateCMF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF11.Index = 0;
            this.cdvCreateCMF11.IsViewBtnImage = false;
            this.cdvCreateCMF11.Location = new System.Drawing.Point(519, 16);
            this.cdvCreateCMF11.MaxLength = 30;
            this.cdvCreateCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF11.Name = "cdvCreateCMF11";
            this.cdvCreateCMF11.ReadOnly = false;
            this.cdvCreateCMF11.SearchSubItemIndex = 0;
            this.cdvCreateCMF11.SelectedDescIndex = -1;
            this.cdvCreateCMF11.SelectedSubItemIndex = -1;
            this.cdvCreateCMF11.SelectionStart = 0;
            this.cdvCreateCMF11.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF11.SmallImageList = null;
            this.cdvCreateCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF11.TabIndex = 21;
            this.cdvCreateCMF11.TextBoxToolTipText = "";
            this.cdvCreateCMF11.TextBoxWidth = 180;
            this.cdvCreateCMF11.VisibleButton = true;
            this.cdvCreateCMF11.VisibleColumnHeader = false;
            this.cdvCreateCMF11.VisibleDescription = false;
            this.cdvCreateCMF11.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // lblCreateCMF20
            // 
            this.lblCreateCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF20.Location = new System.Drawing.Point(373, 236);
            this.lblCreateCMF20.Name = "lblCreateCMF20";
            this.lblCreateCMF20.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF20.TabIndex = 38;
            this.lblCreateCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF19
            // 
            this.lblCreateCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF19.Location = new System.Drawing.Point(373, 212);
            this.lblCreateCMF19.Name = "lblCreateCMF19";
            this.lblCreateCMF19.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF19.TabIndex = 36;
            this.lblCreateCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF18
            // 
            this.lblCreateCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF18.Location = new System.Drawing.Point(373, 188);
            this.lblCreateCMF18.Name = "lblCreateCMF18";
            this.lblCreateCMF18.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF18.TabIndex = 34;
            this.lblCreateCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF17
            // 
            this.lblCreateCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF17.Location = new System.Drawing.Point(373, 164);
            this.lblCreateCMF17.Name = "lblCreateCMF17";
            this.lblCreateCMF17.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF17.TabIndex = 32;
            this.lblCreateCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF16
            // 
            this.lblCreateCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF16.Location = new System.Drawing.Point(373, 140);
            this.lblCreateCMF16.Name = "lblCreateCMF16";
            this.lblCreateCMF16.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF16.TabIndex = 30;
            this.lblCreateCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF15
            // 
            this.lblCreateCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF15.Location = new System.Drawing.Point(373, 116);
            this.lblCreateCMF15.Name = "lblCreateCMF15";
            this.lblCreateCMF15.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF15.TabIndex = 28;
            this.lblCreateCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF14
            // 
            this.lblCreateCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF14.Location = new System.Drawing.Point(373, 92);
            this.lblCreateCMF14.Name = "lblCreateCMF14";
            this.lblCreateCMF14.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF14.TabIndex = 26;
            this.lblCreateCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF13
            // 
            this.lblCreateCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF13.Location = new System.Drawing.Point(373, 68);
            this.lblCreateCMF13.Name = "lblCreateCMF13";
            this.lblCreateCMF13.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF13.TabIndex = 24;
            this.lblCreateCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF12
            // 
            this.lblCreateCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF12.Location = new System.Drawing.Point(373, 44);
            this.lblCreateCMF12.Name = "lblCreateCMF12";
            this.lblCreateCMF12.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF12.TabIndex = 22;
            this.lblCreateCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF11
            // 
            this.lblCreateCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF11.Location = new System.Drawing.Point(373, 20);
            this.lblCreateCMF11.Name = "lblCreateCMF11";
            this.lblCreateCMF11.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF11.TabIndex = 20;
            this.lblCreateCMF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCreateCMF9
            // 
            this.cdvCreateCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF9.BtnToolTipText = "";
            this.cdvCreateCMF9.DescText = "";
            this.cdvCreateCMF9.DisplaySubItemIndex = -1;
            this.cdvCreateCMF9.DisplayText = "";
            this.cdvCreateCMF9.Focusing = null;
            this.cdvCreateCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF9.Index = 0;
            this.cdvCreateCMF9.IsViewBtnImage = false;
            this.cdvCreateCMF9.Location = new System.Drawing.Point(169, 208);
            this.cdvCreateCMF9.MaxLength = 30;
            this.cdvCreateCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF9.Name = "cdvCreateCMF9";
            this.cdvCreateCMF9.ReadOnly = false;
            this.cdvCreateCMF9.SearchSubItemIndex = 0;
            this.cdvCreateCMF9.SelectedDescIndex = -1;
            this.cdvCreateCMF9.SelectedSubItemIndex = -1;
            this.cdvCreateCMF9.SelectionStart = 0;
            this.cdvCreateCMF9.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF9.SmallImageList = null;
            this.cdvCreateCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF9.TabIndex = 17;
            this.cdvCreateCMF9.TextBoxToolTipText = "";
            this.cdvCreateCMF9.TextBoxWidth = 180;
            this.cdvCreateCMF9.VisibleButton = true;
            this.cdvCreateCMF9.VisibleColumnHeader = false;
            this.cdvCreateCMF9.VisibleDescription = false;
            this.cdvCreateCMF9.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF8
            // 
            this.cdvCreateCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF8.BtnToolTipText = "";
            this.cdvCreateCMF8.DescText = "";
            this.cdvCreateCMF8.DisplaySubItemIndex = -1;
            this.cdvCreateCMF8.DisplayText = "";
            this.cdvCreateCMF8.Focusing = null;
            this.cdvCreateCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF8.Index = 0;
            this.cdvCreateCMF8.IsViewBtnImage = false;
            this.cdvCreateCMF8.Location = new System.Drawing.Point(169, 184);
            this.cdvCreateCMF8.MaxLength = 30;
            this.cdvCreateCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF8.Name = "cdvCreateCMF8";
            this.cdvCreateCMF8.ReadOnly = false;
            this.cdvCreateCMF8.SearchSubItemIndex = 0;
            this.cdvCreateCMF8.SelectedDescIndex = -1;
            this.cdvCreateCMF8.SelectedSubItemIndex = -1;
            this.cdvCreateCMF8.SelectionStart = 0;
            this.cdvCreateCMF8.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF8.SmallImageList = null;
            this.cdvCreateCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF8.TabIndex = 15;
            this.cdvCreateCMF8.TextBoxToolTipText = "";
            this.cdvCreateCMF8.TextBoxWidth = 180;
            this.cdvCreateCMF8.VisibleButton = true;
            this.cdvCreateCMF8.VisibleColumnHeader = false;
            this.cdvCreateCMF8.VisibleDescription = false;
            this.cdvCreateCMF8.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF7
            // 
            this.cdvCreateCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF7.BtnToolTipText = "";
            this.cdvCreateCMF7.DescText = "";
            this.cdvCreateCMF7.DisplaySubItemIndex = -1;
            this.cdvCreateCMF7.DisplayText = "";
            this.cdvCreateCMF7.Focusing = null;
            this.cdvCreateCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF7.Index = 0;
            this.cdvCreateCMF7.IsViewBtnImage = false;
            this.cdvCreateCMF7.Location = new System.Drawing.Point(169, 160);
            this.cdvCreateCMF7.MaxLength = 30;
            this.cdvCreateCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF7.Name = "cdvCreateCMF7";
            this.cdvCreateCMF7.ReadOnly = false;
            this.cdvCreateCMF7.SearchSubItemIndex = 0;
            this.cdvCreateCMF7.SelectedDescIndex = -1;
            this.cdvCreateCMF7.SelectedSubItemIndex = -1;
            this.cdvCreateCMF7.SelectionStart = 0;
            this.cdvCreateCMF7.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF7.SmallImageList = null;
            this.cdvCreateCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF7.TabIndex = 13;
            this.cdvCreateCMF7.TextBoxToolTipText = "";
            this.cdvCreateCMF7.TextBoxWidth = 180;
            this.cdvCreateCMF7.VisibleButton = true;
            this.cdvCreateCMF7.VisibleColumnHeader = false;
            this.cdvCreateCMF7.VisibleDescription = false;
            this.cdvCreateCMF7.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF6
            // 
            this.cdvCreateCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF6.BtnToolTipText = "";
            this.cdvCreateCMF6.DescText = "";
            this.cdvCreateCMF6.DisplaySubItemIndex = -1;
            this.cdvCreateCMF6.DisplayText = "";
            this.cdvCreateCMF6.Focusing = null;
            this.cdvCreateCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF6.Index = 0;
            this.cdvCreateCMF6.IsViewBtnImage = false;
            this.cdvCreateCMF6.Location = new System.Drawing.Point(169, 136);
            this.cdvCreateCMF6.MaxLength = 30;
            this.cdvCreateCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF6.Name = "cdvCreateCMF6";
            this.cdvCreateCMF6.ReadOnly = false;
            this.cdvCreateCMF6.SearchSubItemIndex = 0;
            this.cdvCreateCMF6.SelectedDescIndex = -1;
            this.cdvCreateCMF6.SelectedSubItemIndex = -1;
            this.cdvCreateCMF6.SelectionStart = 0;
            this.cdvCreateCMF6.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF6.SmallImageList = null;
            this.cdvCreateCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF6.TabIndex = 11;
            this.cdvCreateCMF6.TextBoxToolTipText = "";
            this.cdvCreateCMF6.TextBoxWidth = 180;
            this.cdvCreateCMF6.VisibleButton = true;
            this.cdvCreateCMF6.VisibleColumnHeader = false;
            this.cdvCreateCMF6.VisibleDescription = false;
            this.cdvCreateCMF6.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF5
            // 
            this.cdvCreateCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF5.BtnToolTipText = "";
            this.cdvCreateCMF5.DescText = "";
            this.cdvCreateCMF5.DisplaySubItemIndex = -1;
            this.cdvCreateCMF5.DisplayText = "";
            this.cdvCreateCMF5.Focusing = null;
            this.cdvCreateCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF5.Index = 0;
            this.cdvCreateCMF5.IsViewBtnImage = false;
            this.cdvCreateCMF5.Location = new System.Drawing.Point(169, 112);
            this.cdvCreateCMF5.MaxLength = 30;
            this.cdvCreateCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF5.Name = "cdvCreateCMF5";
            this.cdvCreateCMF5.ReadOnly = false;
            this.cdvCreateCMF5.SearchSubItemIndex = 0;
            this.cdvCreateCMF5.SelectedDescIndex = -1;
            this.cdvCreateCMF5.SelectedSubItemIndex = -1;
            this.cdvCreateCMF5.SelectionStart = 0;
            this.cdvCreateCMF5.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF5.SmallImageList = null;
            this.cdvCreateCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF5.TabIndex = 9;
            this.cdvCreateCMF5.TextBoxToolTipText = "";
            this.cdvCreateCMF5.TextBoxWidth = 180;
            this.cdvCreateCMF5.VisibleButton = true;
            this.cdvCreateCMF5.VisibleColumnHeader = false;
            this.cdvCreateCMF5.VisibleDescription = false;
            this.cdvCreateCMF5.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF4
            // 
            this.cdvCreateCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF4.BtnToolTipText = "";
            this.cdvCreateCMF4.DescText = "";
            this.cdvCreateCMF4.DisplaySubItemIndex = -1;
            this.cdvCreateCMF4.DisplayText = "";
            this.cdvCreateCMF4.Focusing = null;
            this.cdvCreateCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF4.Index = 0;
            this.cdvCreateCMF4.IsViewBtnImage = false;
            this.cdvCreateCMF4.Location = new System.Drawing.Point(169, 88);
            this.cdvCreateCMF4.MaxLength = 30;
            this.cdvCreateCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF4.Name = "cdvCreateCMF4";
            this.cdvCreateCMF4.ReadOnly = false;
            this.cdvCreateCMF4.SearchSubItemIndex = 0;
            this.cdvCreateCMF4.SelectedDescIndex = -1;
            this.cdvCreateCMF4.SelectedSubItemIndex = -1;
            this.cdvCreateCMF4.SelectionStart = 0;
            this.cdvCreateCMF4.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF4.SmallImageList = null;
            this.cdvCreateCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF4.TabIndex = 7;
            this.cdvCreateCMF4.TextBoxToolTipText = "";
            this.cdvCreateCMF4.TextBoxWidth = 180;
            this.cdvCreateCMF4.VisibleButton = true;
            this.cdvCreateCMF4.VisibleColumnHeader = false;
            this.cdvCreateCMF4.VisibleDescription = false;
            this.cdvCreateCMF4.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF3
            // 
            this.cdvCreateCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF3.BtnToolTipText = "";
            this.cdvCreateCMF3.DescText = "";
            this.cdvCreateCMF3.DisplaySubItemIndex = -1;
            this.cdvCreateCMF3.DisplayText = "";
            this.cdvCreateCMF3.Focusing = null;
            this.cdvCreateCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF3.Index = 0;
            this.cdvCreateCMF3.IsViewBtnImage = false;
            this.cdvCreateCMF3.Location = new System.Drawing.Point(169, 64);
            this.cdvCreateCMF3.MaxLength = 30;
            this.cdvCreateCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF3.Name = "cdvCreateCMF3";
            this.cdvCreateCMF3.ReadOnly = false;
            this.cdvCreateCMF3.SearchSubItemIndex = 0;
            this.cdvCreateCMF3.SelectedDescIndex = -1;
            this.cdvCreateCMF3.SelectedSubItemIndex = -1;
            this.cdvCreateCMF3.SelectionStart = 0;
            this.cdvCreateCMF3.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF3.SmallImageList = null;
            this.cdvCreateCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF3.TabIndex = 5;
            this.cdvCreateCMF3.TextBoxToolTipText = "";
            this.cdvCreateCMF3.TextBoxWidth = 180;
            this.cdvCreateCMF3.VisibleButton = true;
            this.cdvCreateCMF3.VisibleColumnHeader = false;
            this.cdvCreateCMF3.VisibleDescription = false;
            this.cdvCreateCMF3.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF2
            // 
            this.cdvCreateCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF2.BtnToolTipText = "";
            this.cdvCreateCMF2.DescText = "";
            this.cdvCreateCMF2.DisplaySubItemIndex = -1;
            this.cdvCreateCMF2.DisplayText = "";
            this.cdvCreateCMF2.Focusing = null;
            this.cdvCreateCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF2.Index = 0;
            this.cdvCreateCMF2.IsViewBtnImage = false;
            this.cdvCreateCMF2.Location = new System.Drawing.Point(169, 40);
            this.cdvCreateCMF2.MaxLength = 30;
            this.cdvCreateCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF2.Name = "cdvCreateCMF2";
            this.cdvCreateCMF2.ReadOnly = false;
            this.cdvCreateCMF2.SearchSubItemIndex = 0;
            this.cdvCreateCMF2.SelectedDescIndex = -1;
            this.cdvCreateCMF2.SelectedSubItemIndex = -1;
            this.cdvCreateCMF2.SelectionStart = 0;
            this.cdvCreateCMF2.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF2.SmallImageList = null;
            this.cdvCreateCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF2.TabIndex = 3;
            this.cdvCreateCMF2.TextBoxToolTipText = "";
            this.cdvCreateCMF2.TextBoxWidth = 180;
            this.cdvCreateCMF2.VisibleButton = true;
            this.cdvCreateCMF2.VisibleColumnHeader = false;
            this.cdvCreateCMF2.VisibleDescription = false;
            this.cdvCreateCMF2.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF10
            // 
            this.cdvCreateCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF10.BtnToolTipText = "";
            this.cdvCreateCMF10.DescText = "";
            this.cdvCreateCMF10.DisplaySubItemIndex = -1;
            this.cdvCreateCMF10.DisplayText = "";
            this.cdvCreateCMF10.Focusing = null;
            this.cdvCreateCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF10.Index = 0;
            this.cdvCreateCMF10.IsViewBtnImage = false;
            this.cdvCreateCMF10.Location = new System.Drawing.Point(169, 232);
            this.cdvCreateCMF10.MaxLength = 30;
            this.cdvCreateCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF10.Name = "cdvCreateCMF10";
            this.cdvCreateCMF10.ReadOnly = false;
            this.cdvCreateCMF10.SearchSubItemIndex = 0;
            this.cdvCreateCMF10.SelectedDescIndex = -1;
            this.cdvCreateCMF10.SelectedSubItemIndex = -1;
            this.cdvCreateCMF10.SelectionStart = 0;
            this.cdvCreateCMF10.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF10.SmallImageList = null;
            this.cdvCreateCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF10.TabIndex = 19;
            this.cdvCreateCMF10.TextBoxToolTipText = "";
            this.cdvCreateCMF10.TextBoxWidth = 180;
            this.cdvCreateCMF10.VisibleButton = true;
            this.cdvCreateCMF10.VisibleColumnHeader = false;
            this.cdvCreateCMF10.VisibleDescription = false;
            this.cdvCreateCMF10.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // cdvCreateCMF1
            // 
            this.cdvCreateCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCreateCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCreateCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCreateCMF1.BtnToolTipText = "";
            this.cdvCreateCMF1.DescText = "";
            this.cdvCreateCMF1.DisplaySubItemIndex = -1;
            this.cdvCreateCMF1.DisplayText = "";
            this.cdvCreateCMF1.Focusing = null;
            this.cdvCreateCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCreateCMF1.Index = 0;
            this.cdvCreateCMF1.IsViewBtnImage = false;
            this.cdvCreateCMF1.Location = new System.Drawing.Point(169, 16);
            this.cdvCreateCMF1.MaxLength = 30;
            this.cdvCreateCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCreateCMF1.Name = "cdvCreateCMF1";
            this.cdvCreateCMF1.ReadOnly = false;
            this.cdvCreateCMF1.SearchSubItemIndex = 0;
            this.cdvCreateCMF1.SelectedDescIndex = -1;
            this.cdvCreateCMF1.SelectedSubItemIndex = -1;
            this.cdvCreateCMF1.SelectionStart = 0;
            this.cdvCreateCMF1.Size = new System.Drawing.Size(180, 20);
            this.cdvCreateCMF1.SmallImageList = null;
            this.cdvCreateCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCreateCMF1.TabIndex = 1;
            this.cdvCreateCMF1.TextBoxToolTipText = "";
            this.cdvCreateCMF1.TextBoxWidth = 180;
            this.cdvCreateCMF1.VisibleButton = true;
            this.cdvCreateCMF1.VisibleColumnHeader = false;
            this.cdvCreateCMF1.VisibleDescription = false;
            this.cdvCreateCMF1.ButtonPress += new System.EventHandler(this.cdvCreateCMF_ButtonPress);
            this.cdvCreateCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCreateCMF_TextBoxKeyPress);
            // 
            // lblCreateCMF10
            // 
            this.lblCreateCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF10.Location = new System.Drawing.Point(23, 235);
            this.lblCreateCMF10.Name = "lblCreateCMF10";
            this.lblCreateCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF10.TabIndex = 18;
            this.lblCreateCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF9
            // 
            this.lblCreateCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF9.Location = new System.Drawing.Point(23, 211);
            this.lblCreateCMF9.Name = "lblCreateCMF9";
            this.lblCreateCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF9.TabIndex = 16;
            this.lblCreateCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF8
            // 
            this.lblCreateCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF8.Location = new System.Drawing.Point(23, 187);
            this.lblCreateCMF8.Name = "lblCreateCMF8";
            this.lblCreateCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF8.TabIndex = 14;
            this.lblCreateCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF7
            // 
            this.lblCreateCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF7.Location = new System.Drawing.Point(23, 163);
            this.lblCreateCMF7.Name = "lblCreateCMF7";
            this.lblCreateCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF7.TabIndex = 12;
            this.lblCreateCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF6
            // 
            this.lblCreateCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF6.Location = new System.Drawing.Point(23, 139);
            this.lblCreateCMF6.Name = "lblCreateCMF6";
            this.lblCreateCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF6.TabIndex = 10;
            this.lblCreateCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF5
            // 
            this.lblCreateCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF5.Location = new System.Drawing.Point(23, 115);
            this.lblCreateCMF5.Name = "lblCreateCMF5";
            this.lblCreateCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF5.TabIndex = 8;
            this.lblCreateCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF4
            // 
            this.lblCreateCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF4.Location = new System.Drawing.Point(23, 91);
            this.lblCreateCMF4.Name = "lblCreateCMF4";
            this.lblCreateCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF4.TabIndex = 6;
            this.lblCreateCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF3
            // 
            this.lblCreateCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF3.Location = new System.Drawing.Point(23, 67);
            this.lblCreateCMF3.Name = "lblCreateCMF3";
            this.lblCreateCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF3.TabIndex = 4;
            this.lblCreateCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF2
            // 
            this.lblCreateCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF2.Location = new System.Drawing.Point(23, 43);
            this.lblCreateCMF2.Name = "lblCreateCMF2";
            this.lblCreateCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF2.TabIndex = 2;
            this.lblCreateCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreateCMF1
            // 
            this.lblCreateCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateCMF1.Location = new System.Drawing.Point(23, 19);
            this.lblCreateCMF1.Name = "lblCreateCMF1";
            this.lblCreateCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCreateCMF1.TabIndex = 0;
            this.lblCreateCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCreateTrnCMF
            // 
            this.tbpCreateTrnCMF.Controls.Add(this.grpCrtTranCmf);
            this.tbpCreateTrnCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCreateTrnCMF.Name = "tbpCreateTrnCMF";
            this.tbpCreateTrnCMF.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCreateTrnCMF.Size = new System.Drawing.Size(728, 415);
            this.tbpCreateTrnCMF.TabIndex = 3;
            this.tbpCreateTrnCMF.Text = "Create Transaction Customized Field";
            // 
            // grpCrtTranCmf
            // 
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf19);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf18);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf17);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf16);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf15);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf14);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf13);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf12);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf20);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf11);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf20);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf19);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf18);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf17);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf16);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf15);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf14);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf13);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf12);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf11);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf9);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf8);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf7);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf6);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf5);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf4);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf3);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf2);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf10);
            this.grpCrtTranCmf.Controls.Add(this.cdvCrtTranCmf1);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf10);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf9);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf8);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf7);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf6);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf5);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf4);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf3);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf2);
            this.grpCrtTranCmf.Controls.Add(this.lblCrtTranCmf1);
            this.grpCrtTranCmf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCrtTranCmf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCrtTranCmf.Location = new System.Drawing.Point(3, 3);
            this.grpCrtTranCmf.Name = "grpCrtTranCmf";
            this.grpCrtTranCmf.Size = new System.Drawing.Size(722, 409);
            this.grpCrtTranCmf.TabIndex = 1;
            this.grpCrtTranCmf.TabStop = false;
            // 
            // cdvCrtTranCmf19
            // 
            this.cdvCrtTranCmf19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf19.BtnToolTipText = "";
            this.cdvCrtTranCmf19.DescText = "";
            this.cdvCrtTranCmf19.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf19.DisplayText = "";
            this.cdvCrtTranCmf19.Focusing = null;
            this.cdvCrtTranCmf19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf19.Index = 0;
            this.cdvCrtTranCmf19.IsViewBtnImage = false;
            this.cdvCrtTranCmf19.Location = new System.Drawing.Point(530, 208);
            this.cdvCrtTranCmf19.MaxLength = 30;
            this.cdvCrtTranCmf19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf19.Name = "cdvCrtTranCmf19";
            this.cdvCrtTranCmf19.ReadOnly = false;
            this.cdvCrtTranCmf19.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf19.SelectedDescIndex = -1;
            this.cdvCrtTranCmf19.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf19.SelectionStart = 0;
            this.cdvCrtTranCmf19.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf19.SmallImageList = null;
            this.cdvCrtTranCmf19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf19.TabIndex = 37;
            this.cdvCrtTranCmf19.TextBoxToolTipText = "";
            this.cdvCrtTranCmf19.TextBoxWidth = 180;
            this.cdvCrtTranCmf19.VisibleButton = true;
            this.cdvCrtTranCmf19.VisibleColumnHeader = false;
            this.cdvCrtTranCmf19.VisibleDescription = false;
            this.cdvCrtTranCmf19.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf18
            // 
            this.cdvCrtTranCmf18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf18.BtnToolTipText = "";
            this.cdvCrtTranCmf18.DescText = "";
            this.cdvCrtTranCmf18.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf18.DisplayText = "";
            this.cdvCrtTranCmf18.Focusing = null;
            this.cdvCrtTranCmf18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf18.Index = 0;
            this.cdvCrtTranCmf18.IsViewBtnImage = false;
            this.cdvCrtTranCmf18.Location = new System.Drawing.Point(530, 184);
            this.cdvCrtTranCmf18.MaxLength = 30;
            this.cdvCrtTranCmf18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf18.Name = "cdvCrtTranCmf18";
            this.cdvCrtTranCmf18.ReadOnly = false;
            this.cdvCrtTranCmf18.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf18.SelectedDescIndex = -1;
            this.cdvCrtTranCmf18.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf18.SelectionStart = 0;
            this.cdvCrtTranCmf18.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf18.SmallImageList = null;
            this.cdvCrtTranCmf18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf18.TabIndex = 35;
            this.cdvCrtTranCmf18.TextBoxToolTipText = "";
            this.cdvCrtTranCmf18.TextBoxWidth = 180;
            this.cdvCrtTranCmf18.VisibleButton = true;
            this.cdvCrtTranCmf18.VisibleColumnHeader = false;
            this.cdvCrtTranCmf18.VisibleDescription = false;
            this.cdvCrtTranCmf18.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf17
            // 
            this.cdvCrtTranCmf17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf17.BtnToolTipText = "";
            this.cdvCrtTranCmf17.DescText = "";
            this.cdvCrtTranCmf17.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf17.DisplayText = "";
            this.cdvCrtTranCmf17.Focusing = null;
            this.cdvCrtTranCmf17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf17.Index = 0;
            this.cdvCrtTranCmf17.IsViewBtnImage = false;
            this.cdvCrtTranCmf17.Location = new System.Drawing.Point(530, 160);
            this.cdvCrtTranCmf17.MaxLength = 30;
            this.cdvCrtTranCmf17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf17.Name = "cdvCrtTranCmf17";
            this.cdvCrtTranCmf17.ReadOnly = false;
            this.cdvCrtTranCmf17.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf17.SelectedDescIndex = -1;
            this.cdvCrtTranCmf17.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf17.SelectionStart = 0;
            this.cdvCrtTranCmf17.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf17.SmallImageList = null;
            this.cdvCrtTranCmf17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf17.TabIndex = 33;
            this.cdvCrtTranCmf17.TextBoxToolTipText = "";
            this.cdvCrtTranCmf17.TextBoxWidth = 180;
            this.cdvCrtTranCmf17.VisibleButton = true;
            this.cdvCrtTranCmf17.VisibleColumnHeader = false;
            this.cdvCrtTranCmf17.VisibleDescription = false;
            this.cdvCrtTranCmf17.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf16
            // 
            this.cdvCrtTranCmf16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf16.BtnToolTipText = "";
            this.cdvCrtTranCmf16.DescText = "";
            this.cdvCrtTranCmf16.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf16.DisplayText = "";
            this.cdvCrtTranCmf16.Focusing = null;
            this.cdvCrtTranCmf16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf16.Index = 0;
            this.cdvCrtTranCmf16.IsViewBtnImage = false;
            this.cdvCrtTranCmf16.Location = new System.Drawing.Point(530, 136);
            this.cdvCrtTranCmf16.MaxLength = 30;
            this.cdvCrtTranCmf16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf16.Name = "cdvCrtTranCmf16";
            this.cdvCrtTranCmf16.ReadOnly = false;
            this.cdvCrtTranCmf16.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf16.SelectedDescIndex = -1;
            this.cdvCrtTranCmf16.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf16.SelectionStart = 0;
            this.cdvCrtTranCmf16.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf16.SmallImageList = null;
            this.cdvCrtTranCmf16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf16.TabIndex = 31;
            this.cdvCrtTranCmf16.TextBoxToolTipText = "";
            this.cdvCrtTranCmf16.TextBoxWidth = 180;
            this.cdvCrtTranCmf16.VisibleButton = true;
            this.cdvCrtTranCmf16.VisibleColumnHeader = false;
            this.cdvCrtTranCmf16.VisibleDescription = false;
            this.cdvCrtTranCmf16.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf15
            // 
            this.cdvCrtTranCmf15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf15.BtnToolTipText = "";
            this.cdvCrtTranCmf15.DescText = "";
            this.cdvCrtTranCmf15.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf15.DisplayText = "";
            this.cdvCrtTranCmf15.Focusing = null;
            this.cdvCrtTranCmf15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf15.Index = 0;
            this.cdvCrtTranCmf15.IsViewBtnImage = false;
            this.cdvCrtTranCmf15.Location = new System.Drawing.Point(530, 112);
            this.cdvCrtTranCmf15.MaxLength = 30;
            this.cdvCrtTranCmf15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf15.Name = "cdvCrtTranCmf15";
            this.cdvCrtTranCmf15.ReadOnly = false;
            this.cdvCrtTranCmf15.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf15.SelectedDescIndex = -1;
            this.cdvCrtTranCmf15.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf15.SelectionStart = 0;
            this.cdvCrtTranCmf15.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf15.SmallImageList = null;
            this.cdvCrtTranCmf15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf15.TabIndex = 29;
            this.cdvCrtTranCmf15.TextBoxToolTipText = "";
            this.cdvCrtTranCmf15.TextBoxWidth = 180;
            this.cdvCrtTranCmf15.VisibleButton = true;
            this.cdvCrtTranCmf15.VisibleColumnHeader = false;
            this.cdvCrtTranCmf15.VisibleDescription = false;
            this.cdvCrtTranCmf15.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf14
            // 
            this.cdvCrtTranCmf14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf14.BtnToolTipText = "";
            this.cdvCrtTranCmf14.DescText = "";
            this.cdvCrtTranCmf14.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf14.DisplayText = "";
            this.cdvCrtTranCmf14.Focusing = null;
            this.cdvCrtTranCmf14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf14.Index = 0;
            this.cdvCrtTranCmf14.IsViewBtnImage = false;
            this.cdvCrtTranCmf14.Location = new System.Drawing.Point(530, 88);
            this.cdvCrtTranCmf14.MaxLength = 30;
            this.cdvCrtTranCmf14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf14.Name = "cdvCrtTranCmf14";
            this.cdvCrtTranCmf14.ReadOnly = false;
            this.cdvCrtTranCmf14.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf14.SelectedDescIndex = -1;
            this.cdvCrtTranCmf14.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf14.SelectionStart = 0;
            this.cdvCrtTranCmf14.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf14.SmallImageList = null;
            this.cdvCrtTranCmf14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf14.TabIndex = 27;
            this.cdvCrtTranCmf14.TextBoxToolTipText = "";
            this.cdvCrtTranCmf14.TextBoxWidth = 180;
            this.cdvCrtTranCmf14.VisibleButton = true;
            this.cdvCrtTranCmf14.VisibleColumnHeader = false;
            this.cdvCrtTranCmf14.VisibleDescription = false;
            this.cdvCrtTranCmf14.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf13
            // 
            this.cdvCrtTranCmf13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf13.BtnToolTipText = "";
            this.cdvCrtTranCmf13.DescText = "";
            this.cdvCrtTranCmf13.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf13.DisplayText = "";
            this.cdvCrtTranCmf13.Focusing = null;
            this.cdvCrtTranCmf13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf13.Index = 0;
            this.cdvCrtTranCmf13.IsViewBtnImage = false;
            this.cdvCrtTranCmf13.Location = new System.Drawing.Point(530, 64);
            this.cdvCrtTranCmf13.MaxLength = 30;
            this.cdvCrtTranCmf13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf13.Name = "cdvCrtTranCmf13";
            this.cdvCrtTranCmf13.ReadOnly = false;
            this.cdvCrtTranCmf13.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf13.SelectedDescIndex = -1;
            this.cdvCrtTranCmf13.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf13.SelectionStart = 0;
            this.cdvCrtTranCmf13.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf13.SmallImageList = null;
            this.cdvCrtTranCmf13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf13.TabIndex = 25;
            this.cdvCrtTranCmf13.TextBoxToolTipText = "";
            this.cdvCrtTranCmf13.TextBoxWidth = 180;
            this.cdvCrtTranCmf13.VisibleButton = true;
            this.cdvCrtTranCmf13.VisibleColumnHeader = false;
            this.cdvCrtTranCmf13.VisibleDescription = false;
            this.cdvCrtTranCmf13.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf12
            // 
            this.cdvCrtTranCmf12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf12.BtnToolTipText = "";
            this.cdvCrtTranCmf12.DescText = "";
            this.cdvCrtTranCmf12.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf12.DisplayText = "";
            this.cdvCrtTranCmf12.Focusing = null;
            this.cdvCrtTranCmf12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf12.Index = 0;
            this.cdvCrtTranCmf12.IsViewBtnImage = false;
            this.cdvCrtTranCmf12.Location = new System.Drawing.Point(530, 40);
            this.cdvCrtTranCmf12.MaxLength = 30;
            this.cdvCrtTranCmf12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf12.Name = "cdvCrtTranCmf12";
            this.cdvCrtTranCmf12.ReadOnly = false;
            this.cdvCrtTranCmf12.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf12.SelectedDescIndex = -1;
            this.cdvCrtTranCmf12.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf12.SelectionStart = 0;
            this.cdvCrtTranCmf12.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf12.SmallImageList = null;
            this.cdvCrtTranCmf12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf12.TabIndex = 23;
            this.cdvCrtTranCmf12.TextBoxToolTipText = "";
            this.cdvCrtTranCmf12.TextBoxWidth = 180;
            this.cdvCrtTranCmf12.VisibleButton = true;
            this.cdvCrtTranCmf12.VisibleColumnHeader = false;
            this.cdvCrtTranCmf12.VisibleDescription = false;
            this.cdvCrtTranCmf12.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf20
            // 
            this.cdvCrtTranCmf20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf20.BtnToolTipText = "";
            this.cdvCrtTranCmf20.DescText = "";
            this.cdvCrtTranCmf20.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf20.DisplayText = "";
            this.cdvCrtTranCmf20.Focusing = null;
            this.cdvCrtTranCmf20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf20.Index = 0;
            this.cdvCrtTranCmf20.IsViewBtnImage = false;
            this.cdvCrtTranCmf20.Location = new System.Drawing.Point(530, 232);
            this.cdvCrtTranCmf20.MaxLength = 30;
            this.cdvCrtTranCmf20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf20.Name = "cdvCrtTranCmf20";
            this.cdvCrtTranCmf20.ReadOnly = false;
            this.cdvCrtTranCmf20.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf20.SelectedDescIndex = -1;
            this.cdvCrtTranCmf20.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf20.SelectionStart = 0;
            this.cdvCrtTranCmf20.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf20.SmallImageList = null;
            this.cdvCrtTranCmf20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf20.TabIndex = 39;
            this.cdvCrtTranCmf20.TextBoxToolTipText = "";
            this.cdvCrtTranCmf20.TextBoxWidth = 180;
            this.cdvCrtTranCmf20.VisibleButton = true;
            this.cdvCrtTranCmf20.VisibleColumnHeader = false;
            this.cdvCrtTranCmf20.VisibleDescription = false;
            this.cdvCrtTranCmf20.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf11
            // 
            this.cdvCrtTranCmf11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf11.BtnToolTipText = "";
            this.cdvCrtTranCmf11.DescText = "";
            this.cdvCrtTranCmf11.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf11.DisplayText = "";
            this.cdvCrtTranCmf11.Focusing = null;
            this.cdvCrtTranCmf11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf11.Index = 0;
            this.cdvCrtTranCmf11.IsViewBtnImage = false;
            this.cdvCrtTranCmf11.Location = new System.Drawing.Point(530, 16);
            this.cdvCrtTranCmf11.MaxLength = 30;
            this.cdvCrtTranCmf11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf11.Name = "cdvCrtTranCmf11";
            this.cdvCrtTranCmf11.ReadOnly = false;
            this.cdvCrtTranCmf11.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf11.SelectedDescIndex = -1;
            this.cdvCrtTranCmf11.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf11.SelectionStart = 0;
            this.cdvCrtTranCmf11.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf11.SmallImageList = null;
            this.cdvCrtTranCmf11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf11.TabIndex = 21;
            this.cdvCrtTranCmf11.TextBoxToolTipText = "";
            this.cdvCrtTranCmf11.TextBoxWidth = 180;
            this.cdvCrtTranCmf11.VisibleButton = true;
            this.cdvCrtTranCmf11.VisibleColumnHeader = false;
            this.cdvCrtTranCmf11.VisibleDescription = false;
            this.cdvCrtTranCmf11.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // lblCrtTranCmf20
            // 
            this.lblCrtTranCmf20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf20.Location = new System.Drawing.Point(384, 235);
            this.lblCrtTranCmf20.Name = "lblCrtTranCmf20";
            this.lblCrtTranCmf20.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf20.TabIndex = 38;
            this.lblCrtTranCmf20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf19
            // 
            this.lblCrtTranCmf19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf19.Location = new System.Drawing.Point(384, 211);
            this.lblCrtTranCmf19.Name = "lblCrtTranCmf19";
            this.lblCrtTranCmf19.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf19.TabIndex = 36;
            this.lblCrtTranCmf19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf18
            // 
            this.lblCrtTranCmf18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf18.Location = new System.Drawing.Point(384, 187);
            this.lblCrtTranCmf18.Name = "lblCrtTranCmf18";
            this.lblCrtTranCmf18.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf18.TabIndex = 34;
            this.lblCrtTranCmf18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf17
            // 
            this.lblCrtTranCmf17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf17.Location = new System.Drawing.Point(384, 163);
            this.lblCrtTranCmf17.Name = "lblCrtTranCmf17";
            this.lblCrtTranCmf17.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf17.TabIndex = 32;
            this.lblCrtTranCmf17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf16
            // 
            this.lblCrtTranCmf16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf16.Location = new System.Drawing.Point(384, 139);
            this.lblCrtTranCmf16.Name = "lblCrtTranCmf16";
            this.lblCrtTranCmf16.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf16.TabIndex = 30;
            this.lblCrtTranCmf16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf15
            // 
            this.lblCrtTranCmf15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf15.Location = new System.Drawing.Point(384, 115);
            this.lblCrtTranCmf15.Name = "lblCrtTranCmf15";
            this.lblCrtTranCmf15.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf15.TabIndex = 28;
            this.lblCrtTranCmf15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf14
            // 
            this.lblCrtTranCmf14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf14.Location = new System.Drawing.Point(384, 91);
            this.lblCrtTranCmf14.Name = "lblCrtTranCmf14";
            this.lblCrtTranCmf14.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf14.TabIndex = 26;
            this.lblCrtTranCmf14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf13
            // 
            this.lblCrtTranCmf13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf13.Location = new System.Drawing.Point(384, 67);
            this.lblCrtTranCmf13.Name = "lblCrtTranCmf13";
            this.lblCrtTranCmf13.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf13.TabIndex = 24;
            this.lblCrtTranCmf13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf12
            // 
            this.lblCrtTranCmf12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf12.Location = new System.Drawing.Point(384, 43);
            this.lblCrtTranCmf12.Name = "lblCrtTranCmf12";
            this.lblCrtTranCmf12.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf12.TabIndex = 22;
            this.lblCrtTranCmf12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf11
            // 
            this.lblCrtTranCmf11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf11.Location = new System.Drawing.Point(384, 20);
            this.lblCrtTranCmf11.Name = "lblCrtTranCmf11";
            this.lblCrtTranCmf11.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf11.TabIndex = 20;
            this.lblCrtTranCmf11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCrtTranCmf9
            // 
            this.cdvCrtTranCmf9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf9.BtnToolTipText = "";
            this.cdvCrtTranCmf9.DescText = "";
            this.cdvCrtTranCmf9.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf9.DisplayText = "";
            this.cdvCrtTranCmf9.Focusing = null;
            this.cdvCrtTranCmf9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf9.Index = 0;
            this.cdvCrtTranCmf9.IsViewBtnImage = false;
            this.cdvCrtTranCmf9.Location = new System.Drawing.Point(163, 208);
            this.cdvCrtTranCmf9.MaxLength = 30;
            this.cdvCrtTranCmf9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf9.Name = "cdvCrtTranCmf9";
            this.cdvCrtTranCmf9.ReadOnly = false;
            this.cdvCrtTranCmf9.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf9.SelectedDescIndex = -1;
            this.cdvCrtTranCmf9.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf9.SelectionStart = 0;
            this.cdvCrtTranCmf9.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf9.SmallImageList = null;
            this.cdvCrtTranCmf9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf9.TabIndex = 17;
            this.cdvCrtTranCmf9.TextBoxToolTipText = "";
            this.cdvCrtTranCmf9.TextBoxWidth = 180;
            this.cdvCrtTranCmf9.VisibleButton = true;
            this.cdvCrtTranCmf9.VisibleColumnHeader = false;
            this.cdvCrtTranCmf9.VisibleDescription = false;
            this.cdvCrtTranCmf9.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf8
            // 
            this.cdvCrtTranCmf8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf8.BtnToolTipText = "";
            this.cdvCrtTranCmf8.DescText = "";
            this.cdvCrtTranCmf8.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf8.DisplayText = "";
            this.cdvCrtTranCmf8.Focusing = null;
            this.cdvCrtTranCmf8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf8.Index = 0;
            this.cdvCrtTranCmf8.IsViewBtnImage = false;
            this.cdvCrtTranCmf8.Location = new System.Drawing.Point(163, 184);
            this.cdvCrtTranCmf8.MaxLength = 30;
            this.cdvCrtTranCmf8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf8.Name = "cdvCrtTranCmf8";
            this.cdvCrtTranCmf8.ReadOnly = false;
            this.cdvCrtTranCmf8.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf8.SelectedDescIndex = -1;
            this.cdvCrtTranCmf8.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf8.SelectionStart = 0;
            this.cdvCrtTranCmf8.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf8.SmallImageList = null;
            this.cdvCrtTranCmf8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf8.TabIndex = 15;
            this.cdvCrtTranCmf8.TextBoxToolTipText = "";
            this.cdvCrtTranCmf8.TextBoxWidth = 180;
            this.cdvCrtTranCmf8.VisibleButton = true;
            this.cdvCrtTranCmf8.VisibleColumnHeader = false;
            this.cdvCrtTranCmf8.VisibleDescription = false;
            this.cdvCrtTranCmf8.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf7
            // 
            this.cdvCrtTranCmf7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf7.BtnToolTipText = "";
            this.cdvCrtTranCmf7.DescText = "";
            this.cdvCrtTranCmf7.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf7.DisplayText = "";
            this.cdvCrtTranCmf7.Focusing = null;
            this.cdvCrtTranCmf7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf7.Index = 0;
            this.cdvCrtTranCmf7.IsViewBtnImage = false;
            this.cdvCrtTranCmf7.Location = new System.Drawing.Point(163, 160);
            this.cdvCrtTranCmf7.MaxLength = 30;
            this.cdvCrtTranCmf7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf7.Name = "cdvCrtTranCmf7";
            this.cdvCrtTranCmf7.ReadOnly = false;
            this.cdvCrtTranCmf7.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf7.SelectedDescIndex = -1;
            this.cdvCrtTranCmf7.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf7.SelectionStart = 0;
            this.cdvCrtTranCmf7.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf7.SmallImageList = null;
            this.cdvCrtTranCmf7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf7.TabIndex = 13;
            this.cdvCrtTranCmf7.TextBoxToolTipText = "";
            this.cdvCrtTranCmf7.TextBoxWidth = 180;
            this.cdvCrtTranCmf7.VisibleButton = true;
            this.cdvCrtTranCmf7.VisibleColumnHeader = false;
            this.cdvCrtTranCmf7.VisibleDescription = false;
            this.cdvCrtTranCmf7.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf6
            // 
            this.cdvCrtTranCmf6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf6.BtnToolTipText = "";
            this.cdvCrtTranCmf6.DescText = "";
            this.cdvCrtTranCmf6.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf6.DisplayText = "";
            this.cdvCrtTranCmf6.Focusing = null;
            this.cdvCrtTranCmf6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf6.Index = 0;
            this.cdvCrtTranCmf6.IsViewBtnImage = false;
            this.cdvCrtTranCmf6.Location = new System.Drawing.Point(163, 136);
            this.cdvCrtTranCmf6.MaxLength = 30;
            this.cdvCrtTranCmf6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf6.Name = "cdvCrtTranCmf6";
            this.cdvCrtTranCmf6.ReadOnly = false;
            this.cdvCrtTranCmf6.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf6.SelectedDescIndex = -1;
            this.cdvCrtTranCmf6.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf6.SelectionStart = 0;
            this.cdvCrtTranCmf6.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf6.SmallImageList = null;
            this.cdvCrtTranCmf6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf6.TabIndex = 11;
            this.cdvCrtTranCmf6.TextBoxToolTipText = "";
            this.cdvCrtTranCmf6.TextBoxWidth = 180;
            this.cdvCrtTranCmf6.VisibleButton = true;
            this.cdvCrtTranCmf6.VisibleColumnHeader = false;
            this.cdvCrtTranCmf6.VisibleDescription = false;
            this.cdvCrtTranCmf6.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf5
            // 
            this.cdvCrtTranCmf5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf5.BtnToolTipText = "";
            this.cdvCrtTranCmf5.DescText = "";
            this.cdvCrtTranCmf5.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf5.DisplayText = "";
            this.cdvCrtTranCmf5.Focusing = null;
            this.cdvCrtTranCmf5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf5.Index = 0;
            this.cdvCrtTranCmf5.IsViewBtnImage = false;
            this.cdvCrtTranCmf5.Location = new System.Drawing.Point(163, 112);
            this.cdvCrtTranCmf5.MaxLength = 30;
            this.cdvCrtTranCmf5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf5.Name = "cdvCrtTranCmf5";
            this.cdvCrtTranCmf5.ReadOnly = false;
            this.cdvCrtTranCmf5.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf5.SelectedDescIndex = -1;
            this.cdvCrtTranCmf5.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf5.SelectionStart = 0;
            this.cdvCrtTranCmf5.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf5.SmallImageList = null;
            this.cdvCrtTranCmf5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf5.TabIndex = 9;
            this.cdvCrtTranCmf5.TextBoxToolTipText = "";
            this.cdvCrtTranCmf5.TextBoxWidth = 180;
            this.cdvCrtTranCmf5.VisibleButton = true;
            this.cdvCrtTranCmf5.VisibleColumnHeader = false;
            this.cdvCrtTranCmf5.VisibleDescription = false;
            this.cdvCrtTranCmf5.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf4
            // 
            this.cdvCrtTranCmf4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf4.BtnToolTipText = "";
            this.cdvCrtTranCmf4.DescText = "";
            this.cdvCrtTranCmf4.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf4.DisplayText = "";
            this.cdvCrtTranCmf4.Focusing = null;
            this.cdvCrtTranCmf4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf4.Index = 0;
            this.cdvCrtTranCmf4.IsViewBtnImage = false;
            this.cdvCrtTranCmf4.Location = new System.Drawing.Point(163, 88);
            this.cdvCrtTranCmf4.MaxLength = 30;
            this.cdvCrtTranCmf4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf4.Name = "cdvCrtTranCmf4";
            this.cdvCrtTranCmf4.ReadOnly = false;
            this.cdvCrtTranCmf4.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf4.SelectedDescIndex = -1;
            this.cdvCrtTranCmf4.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf4.SelectionStart = 0;
            this.cdvCrtTranCmf4.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf4.SmallImageList = null;
            this.cdvCrtTranCmf4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf4.TabIndex = 7;
            this.cdvCrtTranCmf4.TextBoxToolTipText = "";
            this.cdvCrtTranCmf4.TextBoxWidth = 180;
            this.cdvCrtTranCmf4.VisibleButton = true;
            this.cdvCrtTranCmf4.VisibleColumnHeader = false;
            this.cdvCrtTranCmf4.VisibleDescription = false;
            this.cdvCrtTranCmf4.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf3
            // 
            this.cdvCrtTranCmf3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf3.BtnToolTipText = "";
            this.cdvCrtTranCmf3.DescText = "";
            this.cdvCrtTranCmf3.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf3.DisplayText = "";
            this.cdvCrtTranCmf3.Focusing = null;
            this.cdvCrtTranCmf3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf3.Index = 0;
            this.cdvCrtTranCmf3.IsViewBtnImage = false;
            this.cdvCrtTranCmf3.Location = new System.Drawing.Point(163, 64);
            this.cdvCrtTranCmf3.MaxLength = 30;
            this.cdvCrtTranCmf3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf3.Name = "cdvCrtTranCmf3";
            this.cdvCrtTranCmf3.ReadOnly = false;
            this.cdvCrtTranCmf3.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf3.SelectedDescIndex = -1;
            this.cdvCrtTranCmf3.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf3.SelectionStart = 0;
            this.cdvCrtTranCmf3.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf3.SmallImageList = null;
            this.cdvCrtTranCmf3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf3.TabIndex = 5;
            this.cdvCrtTranCmf3.TextBoxToolTipText = "";
            this.cdvCrtTranCmf3.TextBoxWidth = 180;
            this.cdvCrtTranCmf3.VisibleButton = true;
            this.cdvCrtTranCmf3.VisibleColumnHeader = false;
            this.cdvCrtTranCmf3.VisibleDescription = false;
            this.cdvCrtTranCmf3.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf2
            // 
            this.cdvCrtTranCmf2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf2.BtnToolTipText = "";
            this.cdvCrtTranCmf2.DescText = "";
            this.cdvCrtTranCmf2.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf2.DisplayText = "";
            this.cdvCrtTranCmf2.Focusing = null;
            this.cdvCrtTranCmf2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf2.Index = 0;
            this.cdvCrtTranCmf2.IsViewBtnImage = false;
            this.cdvCrtTranCmf2.Location = new System.Drawing.Point(163, 40);
            this.cdvCrtTranCmf2.MaxLength = 30;
            this.cdvCrtTranCmf2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf2.Name = "cdvCrtTranCmf2";
            this.cdvCrtTranCmf2.ReadOnly = false;
            this.cdvCrtTranCmf2.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf2.SelectedDescIndex = -1;
            this.cdvCrtTranCmf2.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf2.SelectionStart = 0;
            this.cdvCrtTranCmf2.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf2.SmallImageList = null;
            this.cdvCrtTranCmf2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf2.TabIndex = 3;
            this.cdvCrtTranCmf2.TextBoxToolTipText = "";
            this.cdvCrtTranCmf2.TextBoxWidth = 180;
            this.cdvCrtTranCmf2.VisibleButton = true;
            this.cdvCrtTranCmf2.VisibleColumnHeader = false;
            this.cdvCrtTranCmf2.VisibleDescription = false;
            this.cdvCrtTranCmf2.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf10
            // 
            this.cdvCrtTranCmf10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf10.BtnToolTipText = "";
            this.cdvCrtTranCmf10.DescText = "";
            this.cdvCrtTranCmf10.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf10.DisplayText = "";
            this.cdvCrtTranCmf10.Focusing = null;
            this.cdvCrtTranCmf10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf10.Index = 0;
            this.cdvCrtTranCmf10.IsViewBtnImage = false;
            this.cdvCrtTranCmf10.Location = new System.Drawing.Point(163, 232);
            this.cdvCrtTranCmf10.MaxLength = 30;
            this.cdvCrtTranCmf10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf10.Name = "cdvCrtTranCmf10";
            this.cdvCrtTranCmf10.ReadOnly = false;
            this.cdvCrtTranCmf10.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf10.SelectedDescIndex = -1;
            this.cdvCrtTranCmf10.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf10.SelectionStart = 0;
            this.cdvCrtTranCmf10.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf10.SmallImageList = null;
            this.cdvCrtTranCmf10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf10.TabIndex = 19;
            this.cdvCrtTranCmf10.TextBoxToolTipText = "";
            this.cdvCrtTranCmf10.TextBoxWidth = 180;
            this.cdvCrtTranCmf10.VisibleButton = true;
            this.cdvCrtTranCmf10.VisibleColumnHeader = false;
            this.cdvCrtTranCmf10.VisibleDescription = false;
            this.cdvCrtTranCmf10.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // cdvCrtTranCmf1
            // 
            this.cdvCrtTranCmf1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrtTranCmf1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrtTranCmf1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrtTranCmf1.BtnToolTipText = "";
            this.cdvCrtTranCmf1.DescText = "";
            this.cdvCrtTranCmf1.DisplaySubItemIndex = -1;
            this.cdvCrtTranCmf1.DisplayText = "";
            this.cdvCrtTranCmf1.Focusing = null;
            this.cdvCrtTranCmf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrtTranCmf1.Index = 0;
            this.cdvCrtTranCmf1.IsViewBtnImage = false;
            this.cdvCrtTranCmf1.Location = new System.Drawing.Point(163, 16);
            this.cdvCrtTranCmf1.MaxLength = 30;
            this.cdvCrtTranCmf1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrtTranCmf1.Name = "cdvCrtTranCmf1";
            this.cdvCrtTranCmf1.ReadOnly = false;
            this.cdvCrtTranCmf1.SearchSubItemIndex = 0;
            this.cdvCrtTranCmf1.SelectedDescIndex = -1;
            this.cdvCrtTranCmf1.SelectedSubItemIndex = -1;
            this.cdvCrtTranCmf1.SelectionStart = 0;
            this.cdvCrtTranCmf1.Size = new System.Drawing.Size(180, 20);
            this.cdvCrtTranCmf1.SmallImageList = null;
            this.cdvCrtTranCmf1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrtTranCmf1.TabIndex = 1;
            this.cdvCrtTranCmf1.TextBoxToolTipText = "";
            this.cdvCrtTranCmf1.TextBoxWidth = 180;
            this.cdvCrtTranCmf1.VisibleButton = true;
            this.cdvCrtTranCmf1.VisibleColumnHeader = false;
            this.cdvCrtTranCmf1.VisibleDescription = false;
            this.cdvCrtTranCmf1.ButtonPress += new System.EventHandler(this.cdvCrtTranCMF_ButtonPress);
            this.cdvCrtTranCmf1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrtTranCMF_TextBoxKeyPress);
            // 
            // lblCrtTranCmf10
            // 
            this.lblCrtTranCmf10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf10.Location = new System.Drawing.Point(17, 235);
            this.lblCrtTranCmf10.Name = "lblCrtTranCmf10";
            this.lblCrtTranCmf10.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf10.TabIndex = 18;
            this.lblCrtTranCmf10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf9
            // 
            this.lblCrtTranCmf9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf9.Location = new System.Drawing.Point(17, 211);
            this.lblCrtTranCmf9.Name = "lblCrtTranCmf9";
            this.lblCrtTranCmf9.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf9.TabIndex = 16;
            this.lblCrtTranCmf9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf8
            // 
            this.lblCrtTranCmf8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf8.Location = new System.Drawing.Point(17, 187);
            this.lblCrtTranCmf8.Name = "lblCrtTranCmf8";
            this.lblCrtTranCmf8.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf8.TabIndex = 14;
            this.lblCrtTranCmf8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf7
            // 
            this.lblCrtTranCmf7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf7.Location = new System.Drawing.Point(17, 163);
            this.lblCrtTranCmf7.Name = "lblCrtTranCmf7";
            this.lblCrtTranCmf7.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf7.TabIndex = 12;
            this.lblCrtTranCmf7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf6
            // 
            this.lblCrtTranCmf6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf6.Location = new System.Drawing.Point(17, 139);
            this.lblCrtTranCmf6.Name = "lblCrtTranCmf6";
            this.lblCrtTranCmf6.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf6.TabIndex = 10;
            this.lblCrtTranCmf6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf5
            // 
            this.lblCrtTranCmf5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf5.Location = new System.Drawing.Point(17, 115);
            this.lblCrtTranCmf5.Name = "lblCrtTranCmf5";
            this.lblCrtTranCmf5.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf5.TabIndex = 8;
            this.lblCrtTranCmf5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf4
            // 
            this.lblCrtTranCmf4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf4.Location = new System.Drawing.Point(17, 91);
            this.lblCrtTranCmf4.Name = "lblCrtTranCmf4";
            this.lblCrtTranCmf4.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf4.TabIndex = 6;
            this.lblCrtTranCmf4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf3
            // 
            this.lblCrtTranCmf3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf3.Location = new System.Drawing.Point(17, 67);
            this.lblCrtTranCmf3.Name = "lblCrtTranCmf3";
            this.lblCrtTranCmf3.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf3.TabIndex = 4;
            this.lblCrtTranCmf3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf2
            // 
            this.lblCrtTranCmf2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf2.Location = new System.Drawing.Point(17, 43);
            this.lblCrtTranCmf2.Name = "lblCrtTranCmf2";
            this.lblCrtTranCmf2.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf2.TabIndex = 2;
            this.lblCrtTranCmf2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCrtTranCmf1
            // 
            this.lblCrtTranCmf1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrtTranCmf1.Location = new System.Drawing.Point(17, 20);
            this.lblCrtTranCmf1.Name = "lblCrtTranCmf1";
            this.lblCrtTranCmf1.Size = new System.Drawing.Size(140, 14);
            this.lblCrtTranCmf1.TabIndex = 0;
            this.lblCrtTranCmf1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmINVTranConvToLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmINVTranConvToLot";
            this.Text = "Tran Convert Inventory Type To Lot";
            this.Activated += new System.EventHandler(this.frmINVTranOutInventory_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.cdvInvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatID)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlInventoryInfo.ResumeLayout(false);
            this.grpInventoryInfo.ResumeLayout(false);
            this.grpInventoryInfo.PerformLayout();
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvMatVersion)).EndInit();
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpToLotID.ResumeLayout(false);
            this.grpToLotID.PerformLayout();
            this.grpTransInfo.ResumeLayout(false);
            this.grpTransInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOwnerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            this.tbpCreateCMF.ResumeLayout(false);
            this.pnlCreateCMF.ResumeLayout(false);
            this.grpCreateCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCreateCMF1)).EndInit();
            this.tbpCreateTrnCMF.ResumeLayout(false);
            this.grpCrtTranCmf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrtTranCmf1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private string sQty1 = "";
        private string sQty2 = "";
        private string sQty3 = "";
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        private void ClearData(char ProcStep)
        {
            
            try
            {
                switch (ProcStep)
                {
                    case '1':
                        
                        MPCF.FieldClear(this);
                        cboPriority.SelectedIndex = 4;
                        txtDueDate.Visible = ! chkDueDate.Checked;
                        break;
                    case '2':
                        
                        MPCF.FieldClear(this, cdvMatID, cdvInvOper, cdvMatVersion, null, null, false);
                        if (View_Inventory_Info('1', cdvMatID.Text, MPCF.ToInt(cdvMatVersion.Text), cdvInvOper.Text) == false)
                        {
                            if (cdvMatID.Text == "")
                            {
                                cdvMatID.Focus();
                            }
                            else if (cdvInvOper.Text == "")
                            {
                                cdvInvOper.Focus();
                            }
                        }
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
                case "CONV_TO_LOT":

                    if (MPCF.CheckValue(cdvMatID, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvInvOper, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtLotID, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    //if (MPCF.CheckValue(cdvMaterial, 1, false, false, "", "", "") == false)
                    if (cdvMaterial.CheckValue() == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvFlow, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvOperation, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvLotType, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvCreateCode, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvOwnerCode, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvLotType, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (txtConvertQty1.ReadOnly == false)
                    {
                        if (txtConvertQty1.Text == "" || txtConvertQty1.Text == "0")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtConvertQty1.Focus();
                            return false;
                        }
                        if (txtConvertQty1.Text != "" && txtConvertQty1.Text != "0")
                        {
                            if (MPCF.ToDbl(txtConvertQty1.Text) > MPCF.ToDbl(txtQty1.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(171));
                                tabTran.SelectedTab = tbpGeneral;
                                txtConvertQty1.Text = "0";
                                txtConvertQty1.Focus();
                                return false;
                            }
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
                    if (MPCR.CheckGRPCMFValue("lblCrtTrnCMF", "cdvCrtTrnCMF", grpCrtTranCmf) == false)
                    {
                        tabTran.SelectedTab = tbpCreateTrnCMF;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCreateCMF", "cdvCreateCMF", grpCreateCMF) == false)
                    {
                        tabTran.SelectedTab = tbpCreateCMF;
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
        // View_Inventory_Info()
        //       - Get Inventory Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Inventory_Info(char c_step, string sMatID, int iMatVer, string sOper)
        {
            TRSNode in_node = new TRSNode("View_Inventory_Info_In");
            TRSNode out_node = new TRSNode("View_Inventory_Info_Out");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("MAT_ID", sMatID);
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("OPER", sOper);
                
                if (MPCR.CallService("INV", "INV_View_Inventory_Info", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtQty1.Text =  MPCF.Format("#####,##0.###", out_node.GetDouble("QTY_1"));
                txtAllocQty.Text = MPCF.Format("#####,##0.###", out_node.GetDouble("ALLOC_QTY"));
                txtLastTranCode.Text = out_node.GetString("LAST_TRAN_CODE");
                txtLastTranTime.Text =  MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));
                txtLastHistSeq.Text = MPCF.Trim(out_node.GetInt("LAST_HIST_SEQ"));
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        //
        // View_Material_Info()
        //       - View Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sMatID As String : Material
        //
        private bool View_Material_Info(char c_step, string sMatID, int iMatVer)
        {
            TRSNode in_node = new TRSNode("View_Material_In");
            TRSNode out_node = new TRSNode("View_Material_Out");
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);
        
            if (MPCR.CallService("WIP", "WIP_View_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            if (c_step == '1')
            {
                if (out_node.GetString("UNIT1") != "")
                {
                    lblUnit1.Text = out_node.GetString("UNIT1");
                }
                else
                {
                    lblUnit1.Text = "";
                }
            }
            else if (c_step == '2')
            {
                txtConvertQty1.Text = MPCF.Format("#####,##0.###",out_node.GetDouble("DEF_QTY_1"));
                txtConvertQty2.Text = MPCF.Format("#####,##0.###",out_node.GetDouble("DEF_QTY_2"));
                txtConvertQty3.Text = MPCF.Format("#####,##0.###",out_node.GetDouble("DEF_QTY_3"));
                sQty1 = txtConvertQty1.Text;
                sQty2 = txtConvertQty2.Text;
                sQty3 = txtConvertQty3.Text;
                cdvFlow.Text = out_node.GetString("FIRST_FLOW");
                cdvFlow.Sequence = out_node.GetInt("FIRST_FLOW_SEQ_NUM");
                cdvOperation.Text = out_node.GetString("FIRST_OPER");
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
                        
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            cdvOperation.Text = out_node.GetString("FIRST_OPER");
            
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
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            
            
            
            
            
            in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
            
            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }
            
            
            if (out_node.GetString("UNIT_1") != "")
            {
                txtConvertQty1.ReadOnly = false;
                txtConvertQty1.Text = sQty1;
                lblConvertUnit1.Text = out_node.GetString("UNIT_1");
            }
            else
            {
                txtConvertQty1.ReadOnly = true;
                txtConvertQty1.Text = "";
                lblConvertUnit1.Text = "";
            }
            if (out_node.GetString("UNIT_2") != "")
            {
                txtConvertQty2.ReadOnly = false;
                txtConvertQty2.Text = sQty2;
                lblConvertUnit2.Text = out_node.GetString("UNIT_2");
            }
            else
            {
                txtConvertQty2.ReadOnly = true;
                txtConvertQty2.Text = "";
                lblConvertUnit2.Text = "";
            }
            if (out_node.GetString("UNIT_3") != "")
            {
                txtConvertQty3.ReadOnly = false;
                txtConvertQty3.Text = sQty3;
                lblConvertUnit3.Text = out_node.GetString("UNIT_3");
            }
            else
            {
                txtConvertQty3.ReadOnly = true;
                txtConvertQty3.Text = "";
                lblConvertUnit3.Text = "";
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
            
            txtDueDate.Text = "";
            dtpDueDate.Value = DateTime.Now;

            if (cdvMaterial.CheckValue() == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvFlow, 1, false, false, "", "", "") == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvOperation, 1, false, false, "", "", "") == false)
            {
                return false;
            }
            
            if (txtConvertQty1.Text == "")
            {
                dQty1 = 0;
            }
            else
            {
                dQty1 = MPCF.ToDbl(txtConvertQty1.Text);
            }
            
            if (MPCR.GetProcTime(cdvMaterial.Text, cdvMaterial.Version,  cdvFlow.Text, cdvFlow.Sequence, cdvOperation.Text, dQty1,ref dSumQueueTime, ref dSumProcTime, ref dSumQueueProcTime) == false)
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
        // Conv_To_Lot()
        //       - Inventory In Store
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Conv_To_Lot(char ProcStep)
        {
            TRSNode in_node = new TRSNode("Conv_To_Lot_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            try
            {   
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_HIST_SEQ", MPCF.ToInt(MPCF.ToDbl(txtLastHistSeq.Text)));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("MAT_VER", MPCF.ToInt(cdvMatVersion.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvInvOper.Text));

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
                
                in_node.AddString("TRAN_COMMENT", MPCF.Trim(txtComment.Text));

                in_node.AddString("TO_LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("TO_LOT_DESC", MPCF.Trim(txtLotDesc.Text));
                in_node.AddString("TO_MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("TO_MAT_VER", cdvMaterial.Version);
                in_node.AddString("TO_FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddInt("TO_FLOW_SEQ_NUM", cdvFlow.Sequence);
                in_node.AddString("TO_OPER", MPCF.Trim(cdvOperation.Text));
                in_node.AddChar("TO_LOT_TYPE", MPCF.ToChar(MPCF.Trim(cdvLotType.Text)));

                if (txtConvertQty1.Text != "")
                {
                    in_node.AddDouble("TO_QTY_1", MPCF.ToDbl(txtConvertQty1.Text));
                }
                else
                {
                    in_node.AddDouble("TO_QTY_1",0);
                }
                if (txtConvertQty2.Text != "")
                {
                    in_node.AddDouble("TO_QTY_2", MPCF.ToDbl(txtConvertQty2.Text));
                }
                else
                {
                    in_node.AddDouble("TO_QTY_2", 0);
                }
                if (txtConvertQty3.Text != "")
                {
                    in_node.AddDouble("TO_QTY_3", MPCF.ToDbl(txtConvertQty3.Text));
                }
                else
                {
                    in_node.AddDouble("TO_QTY_3", 0);
                }
                                
                in_node.AddString("TO_CREATE_CODE", MPCF.Trim(cdvCreateCode.Text));
                in_node.AddString("TO_OWNER_CODE", MPCF.Trim(cdvOwnerCode.Text));
                in_node.AddChar("TO_PRIORITY", MPCF.ToChar(MPCF.Trim(cboPriority.Text)));
                in_node.AddString("TO_DUE_TIME", MPCF.ToStandardTime(dtpDueDate.Value, MPGC.MP_CONVERT_DATE_FORMAT));

                in_node.AddString("CRT_TRAN_CMF_1", MPCF.Trim(cdvCrtTranCmf1.Text));
                in_node.AddString("CRT_TRAN_CMF_2", MPCF.Trim(cdvCrtTranCmf2.Text));
                in_node.AddString("CRT_TRAN_CMF_3", MPCF.Trim(cdvCrtTranCmf3.Text));
                in_node.AddString("CRT_TRAN_CMF_4", MPCF.Trim(cdvCrtTranCmf4.Text));
                in_node.AddString("CRT_TRAN_CMF_5", MPCF.Trim(cdvCrtTranCmf5.Text));
                in_node.AddString("CRT_TRAN_CMF_6", MPCF.Trim(cdvCrtTranCmf6.Text));
                in_node.AddString("CRT_TRAN_CMF_7", MPCF.Trim(cdvCrtTranCmf7.Text));
                in_node.AddString("CRT_TRAN_CMF_8", MPCF.Trim(cdvCrtTranCmf8.Text));
                in_node.AddString("CRT_TRAN_CMF_9", MPCF.Trim(cdvCrtTranCmf9.Text));
                in_node.AddString("CRT_TRAN_CMF_10", MPCF.Trim(cdvCrtTranCmf10.Text));
                in_node.AddString("CRT_TRAN_CMF_11", MPCF.Trim(cdvCrtTranCmf11.Text));
                in_node.AddString("CRT_TRAN_CMF_12", MPCF.Trim(cdvCrtTranCmf12.Text));
                in_node.AddString("CRT_TRAN_CMF_13", MPCF.Trim(cdvCrtTranCmf13.Text));
                in_node.AddString("CRT_TRAN_CMF_14", MPCF.Trim(cdvCrtTranCmf14.Text));
                in_node.AddString("CRT_TRAN_CMF_15", MPCF.Trim(cdvCrtTranCmf15.Text));
                in_node.AddString("CRT_TRAN_CMF_16", MPCF.Trim(cdvCrtTranCmf16.Text));
                in_node.AddString("CRT_TRAN_CMF_17", MPCF.Trim(cdvCrtTranCmf17.Text));
                in_node.AddString("CRT_TRAN_CMF_18", MPCF.Trim(cdvCrtTranCmf18.Text));
                in_node.AddString("CRT_TRAN_CMF_19", MPCF.Trim(cdvCrtTranCmf19.Text));
                in_node.AddString("CRT_TRAN_CMF_20", MPCF.Trim(cdvCrtTranCmf20.Text));

                in_node.AddString("LOT_CMF_1", MPCF.Trim(cdvCreateCMF1.Text));
                in_node.AddString("LOT_CMF_2", MPCF.Trim(cdvCreateCMF2.Text));
                in_node.AddString("LOT_CMF_3", MPCF.Trim(cdvCreateCMF3.Text));
                in_node.AddString("LOT_CMF_4", MPCF.Trim(cdvCreateCMF4.Text));
                in_node.AddString("LOT_CMF_5", MPCF.Trim(cdvCreateCMF5.Text));
                in_node.AddString("LOT_CMF_6", MPCF.Trim(cdvCreateCMF6.Text));
                in_node.AddString("LOT_CMF_7", MPCF.Trim(cdvCreateCMF7.Text));
                in_node.AddString("LOT_CMF_8", MPCF.Trim(cdvCreateCMF8.Text));
                in_node.AddString("LOT_CMF_9", MPCF.Trim(cdvCreateCMF9.Text));
                in_node.AddString("LOT_CMF_10", MPCF.Trim(cdvCreateCMF10.Text));
                in_node.AddString("LOT_CMF_11", MPCF.Trim(cdvCreateCMF11.Text));
                in_node.AddString("LOT_CMF_12", MPCF.Trim(cdvCreateCMF12.Text));
                in_node.AddString("LOT_CMF_13", MPCF.Trim(cdvCreateCMF13.Text));
                in_node.AddString("LOT_CMF_14", MPCF.Trim(cdvCreateCMF14.Text));
                in_node.AddString("LOT_CMF_15", MPCF.Trim(cdvCreateCMF15.Text));
                in_node.AddString("LOT_CMF_16", MPCF.Trim(cdvCreateCMF16.Text));
                in_node.AddString("LOT_CMF_17", MPCF.Trim(cdvCreateCMF17.Text));
                in_node.AddString("LOT_CMF_18", MPCF.Trim(cdvCreateCMF18.Text));
                in_node.AddString("LOT_CMF_19", MPCF.Trim(cdvCreateCMF19.Text));
                in_node.AddString("LOT_CMF_20", MPCF.Trim(cdvCreateCMF20.Text));
                
                if (MPCR.CallService("INV", "INV_Conv_To_Lot", in_node, ref out_node) == false)
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
        
        private void frmINVTranOutInventory_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    ClearData('1');
                    SetCMFItem(MPGC.MP_CMF_TRN_CONV_TO_LOT);
                    MPCR.SetCMFItem(MPGC.MP_CMF_TRN_CREATE, "lblCrtTranCMF", "cdvCrtTranCMF", grpCrtTranCmf);
                    MPCR.SetCMFItem(MPGC.MP_CMF_LOT, "lblCreateCMF", "cdvCreateCMF", grpCreateCMF);
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCrtTranCMF_ButtonPress(object sender, System.EventArgs e)
        {
            
            MPCR.ProcGRPCMFButtonPress(sender);
            
        }
        
        private void cdvCrtTranCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            MPCR.CheckCMFKeyPress(sender, e);
            
        }
        
        private void cdvCreateCMF_ButtonPress(object sender, System.EventArgs e)
        {
            
            MPCR.ProcGRPCMFButtonPress(sender);
            
        }
        
        private void cdvCreateCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            MPCR.CheckCMFKeyPress(sender, e);
            
        }
        
        private void cdvMatID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            if (cdvMatID.Text == "")
            {
                return;
            }
            cdvMatVersion.Text = e.SelectedItem.SubItems[1].Text;
            if (View_Material_Info('1', cdvMatID.Text, MPCF.ToInt(cdvMatVersion.Text)) == false)
            {
                return;
            }
            if (cdvInvOper.Text == "")
            {
                return;
            }
            ClearData('2');
           
            
        }
        
        private void cdvInvOper_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvInvOper.Text == "")
            {
                return;
            }
            if (cdvMatID.Text == "")
            {
                return;
            }
            ClearData('2');
            
        }

        private void cdvMaterial_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvFlow.Text = "";
            cdvOperation.Text = "";

            if (View_Material_Info('2', cdvMaterial.Text, cdvMaterial.Version) == false)
            {
                return;
            }
            
        }


        
        private void cdvFlow_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (View_Flow() == false)
            {
                return;
            }
            
        }
        
        private void cdvOperation_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            if (cdvOperation.Text != "")
            {
                if (View_Operation() == false)
                {
                    return;
                }
                if (MPGO.AutoCalDueDate() == true)
                {
                    if (SetDueDate() == false)
                    {
                        return;
                    }
                }
            }
            else
            {
                txtDueDate.Text = "";
                dtpDueDate.Value = DateTime.Now;
            }
            
        }
        
        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvMaterial.CheckValue() == false) return;

            cdvFlow.ListCond_MatID = cdvMaterial.Text;
            cdvFlow.ListCond_MatVersion = cdvMaterial.Version;
        }
        
        private void cdvOperation_ButtonPress(object sender, System.EventArgs e)
        {

            if (cdvMaterial.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvMaterial.MaterialFocus();
                return;
            }
            if (cdvFlow.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvFlow.Focus();
                return;
            }
            
            if (GetOperationList(cdvFlow.Text) == false)
            {
                return;
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("CONV_TO_LOT") == false) return;
                if (Conv_To_Lot('1') == false) return;

                ClearData('2');
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void chkDueDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            txtDueDate.Visible = ! chkDueDate.Checked;
            
        }
        
        private void txtConvertQty1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)13)
            {
                if (txtQty1.Text == "")
                {
                    txtQty1.Text = "0";
                }
                
                if (MPGO.AutoCalDueDate() == true)
                {
                    if (SetDueDate() == false)
                    {
                        return;
                    }
                }
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            ClearData('2');
            
        }
        
        private void cdvMatID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvMatID.Init();
            MPCF.InitListView(cdvMatID.GetListView);
            cdvMatID.Columns.Add("Material", 100, HorizontalAlignment.Left);
            cdvMatID.Columns.Add("Version", 100, HorizontalAlignment.Left);
            cdvMatID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvMatID.SelectedSubItemIndex = 0;

            WIPLIST.ViewMaterialList(cdvMatID.GetListView, '1', "", ' ', ' ', "", true, null, "");
            //WIPLIST.ViewMaterialList(cdvMatID.GetListView, '1');
        }
        
        private void cdvInvOper_ButtonPress(object sender, System.EventArgs e)
        {
            cdvInvOper.Init();
            MPCF.InitListView(cdvInvOper.GetListView);
            cdvInvOper.Columns.Add("Oper", 100, HorizontalAlignment.Left);
            cdvInvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvInvOper.SelectedSubItemIndex = 0;
            
            WIPLIST.ViewOperationList(cdvInvOper.GetListView, '6', cdvMatID.Text, MPCF.ToInt(cdvMatVersion.Text),"", "", null, "");
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

        private void cdvMatVersion_ButtonPress(object sender, EventArgs e)
        {
            WIPLIST.ViewMaterialVersionList(cdvMatVersion.GetListView, '1', cdvMatID.Text, "", ' ', ' ', null, "");
        }
    }
    //#End If
}
