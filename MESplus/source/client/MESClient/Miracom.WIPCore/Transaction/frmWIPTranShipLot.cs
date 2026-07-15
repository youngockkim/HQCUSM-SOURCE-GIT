
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranShipLot.vb
//   Description : Shipping Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - View_Lot_Info() : View Lot Information
//       - Ship_Lot() : Ship Lot transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-22 : Created by CM Koo
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
    public class frmWIPTranShipLot : Miracom.MESCore.TranForm07
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranShipLot()
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
        



        private System.Windows.Forms.GroupBox grpShip;
        private System.Windows.Forms.TextBox txtToOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvShipCode;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToFactory;
        private System.Windows.Forms.Label lblToOper;
        private System.Windows.Forms.Label lblShipCode;
        private System.Windows.Forms.Label lblToFactory;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.grpShip = new System.Windows.Forms.GroupBox();
            this.txtToOper = new System.Windows.Forms.TextBox();
            this.cdvShipCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvToFactory = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToOper = new System.Windows.Forms.Label();
            this.lblShipCode = new System.Windows.Forms.Label();
            this.lblToFactory = new System.Windows.Forms.Label();
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
            this.grpShip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShipCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToFactory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpShip);
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
            this.lblFormTitle.Text = "Ship Lot";
            // 
            // grpShip
            // 
            this.grpShip.Controls.Add(this.txtToOper);
            this.grpShip.Controls.Add(this.cdvShipCode);
            this.grpShip.Controls.Add(this.cdvToFactory);
            this.grpShip.Controls.Add(this.lblToOper);
            this.grpShip.Controls.Add(this.lblShipCode);
            this.grpShip.Controls.Add(this.lblToFactory);
            this.grpShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpShip.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpShip.Location = new System.Drawing.Point(0, 0);
            this.grpShip.Name = "grpShip";
            this.grpShip.Size = new System.Drawing.Size(722, 235);
            this.grpShip.TabIndex = 0;
            this.grpShip.TabStop = false;
            // 
            // txtToOper
            // 
            this.txtToOper.Location = new System.Drawing.Point(118, 63);
            this.txtToOper.MaxLength = 10;
            this.txtToOper.Name = "txtToOper";
            this.txtToOper.ReadOnly = true;
            this.txtToOper.Size = new System.Drawing.Size(200, 20);
            this.txtToOper.TabIndex = 5;
            this.txtToOper.TabStop = false;
            // 
            // cdvShipCode
            // 
            this.cdvShipCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvShipCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvShipCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvShipCode.BtnToolTipText = "";
            this.cdvShipCode.DescText = "";
            this.cdvShipCode.DisplaySubItemIndex = -1;
            this.cdvShipCode.DisplayText = "";
            this.cdvShipCode.Focusing = null;
            this.cdvShipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvShipCode.Index = 0;
            this.cdvShipCode.IsViewBtnImage = false;
            this.cdvShipCode.Location = new System.Drawing.Point(118, 39);
            this.cdvShipCode.MaxLength = 10;
            this.cdvShipCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvShipCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvShipCode.Name = "cdvShipCode";
            this.cdvShipCode.ReadOnly = false;
            this.cdvShipCode.SearchSubItemIndex = 0;
            this.cdvShipCode.SelectedDescIndex = -1;
            this.cdvShipCode.SelectedSubItemIndex = -1;
            this.cdvShipCode.SelectionStart = 0;
            this.cdvShipCode.Size = new System.Drawing.Size(200, 20);
            this.cdvShipCode.SmallImageList = null;
            this.cdvShipCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvShipCode.TabIndex = 3;
            this.cdvShipCode.TextBoxToolTipText = "";
            this.cdvShipCode.TextBoxWidth = 200;
            this.cdvShipCode.VisibleButton = true;
            this.cdvShipCode.VisibleColumnHeader = false;
            this.cdvShipCode.VisibleDescription = false;
            this.cdvShipCode.ButtonPress += new System.EventHandler(this.cdvShipCode_ButtonPress);
            // 
            // cdvToFactory
            // 
            this.cdvToFactory.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToFactory.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToFactory.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToFactory.BtnToolTipText = "";
            this.cdvToFactory.DescText = "";
            this.cdvToFactory.DisplaySubItemIndex = -1;
            this.cdvToFactory.DisplayText = "";
            this.cdvToFactory.Focusing = null;
            this.cdvToFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToFactory.Index = 0;
            this.cdvToFactory.IsViewBtnImage = false;
            this.cdvToFactory.Location = new System.Drawing.Point(118, 16);
            this.cdvToFactory.MaxLength = 10;
            this.cdvToFactory.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToFactory.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToFactory.Name = "cdvToFactory";
            this.cdvToFactory.ReadOnly = false;
            this.cdvToFactory.SearchSubItemIndex = 0;
            this.cdvToFactory.SelectedDescIndex = -1;
            this.cdvToFactory.SelectedSubItemIndex = -1;
            this.cdvToFactory.SelectionStart = 0;
            this.cdvToFactory.Size = new System.Drawing.Size(200, 20);
            this.cdvToFactory.SmallImageList = null;
            this.cdvToFactory.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToFactory.TabIndex = 1;
            this.cdvToFactory.TextBoxToolTipText = "";
            this.cdvToFactory.TextBoxWidth = 200;
            this.cdvToFactory.VisibleButton = true;
            this.cdvToFactory.VisibleColumnHeader = false;
            this.cdvToFactory.VisibleDescription = false;
            this.cdvToFactory.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToFactory_SelectedItemChanged);
            this.cdvToFactory.ButtonPress += new System.EventHandler(this.cdvToFactory_ButtonPress);
            // 
            // lblToOper
            // 
            this.lblToOper.AutoSize = true;
            this.lblToOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToOper.Location = new System.Drawing.Point(12, 66);
            this.lblToOper.Name = "lblToOper";
            this.lblToOper.Size = new System.Drawing.Size(88, 13);
            this.lblToOper.TabIndex = 4;
            this.lblToOper.Text = "Transit Operation";
            // 
            // lblShipCode
            // 
            this.lblShipCode.AutoSize = true;
            this.lblShipCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipCode.Location = new System.Drawing.Point(12, 41);
            this.lblShipCode.Name = "lblShipCode";
            this.lblShipCode.Size = new System.Drawing.Size(65, 13);
            this.lblShipCode.TabIndex = 2;
            this.lblShipCode.Text = "Ship Code";
            // 
            // lblToFactory
            // 
            this.lblToFactory.AutoSize = true;
            this.lblToFactory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToFactory.Location = new System.Drawing.Point(12, 18);
            this.lblToFactory.Name = "lblToFactory";
            this.lblToFactory.Size = new System.Drawing.Size(78, 13);
            this.lblToFactory.TabIndex = 0;
            this.lblToFactory.Text = "Ship Factory";
            // 
            // frmWIPTranShipLot
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmWIPTranShipLot";
            this.Text = "Ship Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranShipLot_Activated);
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
            this.grpShip.ResumeLayout(false);
            this.grpShip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShipCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToFactory)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
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
                case 1:

                    MPCF.FieldClear(this, txtLotID);
                    txtLotID.Focus();
                    break;
            }
        }
        
        // ViewLotInfo()
        //       -   View Lot Information
        // Return Value
        //       -
        // Arguments
        //       -
        protected override bool ViewLotInfo(string s_lot_id)
        {
            MPCF.FieldClear(this, txtLotID);
             base.ViewLotInfo(s_lot_id);
            txtLotID.Focus();

            return true;
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
            if (MPCF.CheckValue(cdvToFactory, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvToFactory.Focus();
                return false;
            }
            if (MPCF.CheckValue(cdvShipCode, 1) == false)
            {
                tabTran.SelectedTab = tbpGeneral;
                cdvShipCode.Focus();
                return false;
            }
            if (CheckCMFItemValue() == false)
            {
                tabTran.SelectedTab = tbpCMF;
                return false;
            }
            
            return true;
        }
        // Ship_Lot()
        //       -   Ship Lot transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Ship_Lot()
        {
            TRSNode in_node = new TRSNode("SHIP_LOT_IN");
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
                in_node.AddString("SHIP_CODE", MPCF.Trim(cdvShipCode.Text));
                in_node.AddString("TO_FACTORY", MPCF.Trim(cdvToFactory.Text));
                in_node.AddString("TO_OPER", MPCF.Trim(txtToOper.Text));

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

                if (MPCR.CallService("WIP", "WIP_Ship_Lot", in_node, ref out_node) == false)
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
        
        private void frmWIPTranShipLot_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                
                ClearData(0);
                SetCMFItem(MPGC.MP_CMF_TRN_SHIP);
                
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewLotInfo(txtLotID.Text);
                }
                
                b_load_flag = true;
            }
            
        }
        
        private void cdvToFactory_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            txtToOper.Text = MPCF.Trim(e.SelectedItem.SubItems[1].Text);
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
            
            if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_SHIP, LOT.GetString("LOT_ID"), "", "", 'B') == false) return;
            if (Ship_Lot() == false) return;
            if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_SHIP, LOT.GetString("LOT_ID"), "", "", 'A') == false) return;

            ClearData(1);
        }
        
        private void cdvToFactory_ButtonPress(object sender, System.EventArgs e)
        {
            cdvToFactory.Init();
            MPCF.InitListView(cdvToFactory.GetListView);
            cdvToFactory.Columns.Add("ToFactory", 150, HorizontalAlignment.Left);
            cdvToFactory.Columns.Add("Oper", 200, HorizontalAlignment.Left);
            cdvToFactory.SelectedSubItemIndex = 0;
            WIPLIST.ViewShipFacList(cdvToFactory.GetListView, '1', null, "");
            
        }
        
        private void cdvShipCode_ButtonPress(object sender, System.EventArgs e)
        {
            cdvShipCode.Init();
            MPCF.InitListView(cdvShipCode.GetListView);
            cdvShipCode.Columns.Add("Code", 150, HorizontalAlignment.Left);
            cdvShipCode.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvShipCode.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvShipCode.GetListView, '1', MPGC.MP_WIP_SHIP_CODE);
        }
    }
    
}
