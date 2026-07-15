
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranEndLotForIT.vb
//   Description : End Lot Transaction
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
//       - End_Lot() : End Lot transaction
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
using System.Globalization;

namespace Miracom.WIPCore
{
    public class frmWIPTranEndLotForIT : Miracom.MESCore.TranForm97
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranEndLotForIT()
        {
            
            
            InitializeComponent();
            
            
            this.spdResInfo.Tag = "Change Cell";
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
        



        private System.Windows.Forms.Panel pnlResInfo;
        private System.Windows.Forms.GroupBox grpResInfo;
        private System.Windows.Forms.GroupBox grpTranInfo;
        private Miracom.UI.Controls.MCListView.MCListView lisProcOperList;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRetOperation;
        private System.Windows.Forms.Label lblRetOper;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToOperation;
        private System.Windows.Forms.Label lblToOper;
        private System.Windows.Forms.ColumnHeader colOper;
        protected FarPoint.Win.Spread.FpSpread spdResInfo;
        protected FarPoint.Win.Spread.SheetView spdResInfo_LotInfo;
        private System.Windows.Forms.Label lblQty23;
        private System.Windows.Forms.TextBox txtNewQty3;
        private System.Windows.Forms.TextBox txtNewQty2;
        private System.Windows.Forms.TextBox txtNewQty1;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvToFlow;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvReturnFlow;
        private CheckBox chkForceEndSublot;
        private System.Windows.Forms.Label lblQty1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder2 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder1 = new FarPoint.Win.CompoundBorder(bevelBorder1, bevelBorder2);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.BevelBorder bevelBorder3 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Lowered);
            FarPoint.Win.BevelBorder bevelBorder4 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.CompoundBorder compoundBorder2 = new FarPoint.Win.CompoundBorder(bevelBorder3, bevelBorder4);
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlResInfo = new System.Windows.Forms.Panel();
            this.grpResInfo = new System.Windows.Forms.GroupBox();
            this.spdResInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdResInfo_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.grpTranInfo = new System.Windows.Forms.GroupBox();
            this.chkForceEndSublot = new System.Windows.Forms.CheckBox();
            this.cdvToFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.lblQty23 = new System.Windows.Forms.Label();
            this.txtNewQty3 = new System.Windows.Forms.TextBox();
            this.txtNewQty2 = new System.Windows.Forms.TextBox();
            this.txtNewQty1 = new System.Windows.Forms.TextBox();
            this.lblQty1 = new System.Windows.Forms.Label();
            this.lisProcOperList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvRetOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRetOper = new System.Windows.Forms.Label();
            this.cdvToOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToOper = new System.Windows.Forms.Label();
            this.cdvReturnFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
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
            this.pnlResInfo.SuspendLayout();
            this.grpResInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).BeginInit();
            this.grpTranInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRetOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOperation)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpTranInfo);
            this.pnlTranInfo.Controls.Add(this.pnlResInfo);
            this.pnlTranInfo.Location = new System.Drawing.Point(0, 174);
            this.pnlTranInfo.Size = new System.Drawing.Size(1268, 450);
            this.pnlTranInfo.TabIndex = 1;
            // 
            // pnlGeneralTop
            // 
            this.pnlGeneralTop.Size = new System.Drawing.Size(1268, 174);
            // 
            // spdLotInfo
            // 
            this.spdLotInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.HorizontalScrollBar.Name = "";
            this.spdLotInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdLotInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdLotInfo.Location = new System.Drawing.Point(3, 19);
            this.spdLotInfo.Size = new System.Drawing.Size(1262, 152);
            this.spdLotInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotInfo.VerticalScrollBar.Name = "";
            this.spdLotInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdLotInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // grpLotInfo
            // 
            this.grpLotInfo.Size = new System.Drawing.Size(1268, 174);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Location = new System.Drawing.Point(4, 26);
            this.tbpGeneral.Size = new System.Drawing.Size(1274, 672);
            // 
            // pnlTran
            // 
            this.pnlTran.Size = new System.Drawing.Size(1268, 624);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 627);
            this.pnlComment.Size = new System.Drawing.Size(1268, 45);
            this.pnlComment.TabIndex = 3;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Location = new System.Drawing.Point(4, 26);
            this.tbpCMF.Size = new System.Drawing.Size(1265, 660);
            // 
            // grpComment
            // 
            this.grpComment.Size = new System.Drawing.Size(1268, 45);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(168, 15);
            this.txtComment.Size = new System.Drawing.Size(1083, 23);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(21, 17);
            this.lblComment.Size = new System.Drawing.Size(67, 17);
            // 
            // grpCMF
            // 
            this.grpCMF.Size = new System.Drawing.Size(1259, 657);
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.Location = new System.Drawing.Point(228, 256);
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF9.TextBoxWidth = 353;
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.Location = new System.Drawing.Point(228, 226);
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF8.TextBoxWidth = 353;
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.Location = new System.Drawing.Point(228, 197);
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF7.TextBoxWidth = 353;
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.Location = new System.Drawing.Point(228, 167);
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF6.TextBoxWidth = 353;
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.Location = new System.Drawing.Point(228, 138);
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Size = new System.Drawing.Size(252, 24);
            this.cdvCMF5.TextBoxWidth = 353;
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.Location = new System.Drawing.Point(228, 108);
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF4.TextBoxWidth = 353;
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.Location = new System.Drawing.Point(228, 79);
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Size = new System.Drawing.Size(252, 24);
            this.cdvCMF3.TextBoxWidth = 353;
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.Location = new System.Drawing.Point(228, 49);
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF2.TextBoxWidth = 353;
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.Location = new System.Drawing.Point(228, 286);
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Size = new System.Drawing.Size(252, 24);
            this.cdvCMF10.TextBoxWidth = 353;
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.Location = new System.Drawing.Point(228, 20);
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Size = new System.Drawing.Size(252, 24);
            this.cdvCMF1.TextBoxWidth = 353;
            // 
            // lblCMF10
            // 
            this.lblCMF10.Location = new System.Drawing.Point(24, 290);
            this.lblCMF10.Size = new System.Drawing.Size(196, 18);
            // 
            // lblCMF9
            // 
            this.lblCMF9.Location = new System.Drawing.Point(24, 261);
            this.lblCMF9.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF8
            // 
            this.lblCMF8.Location = new System.Drawing.Point(24, 231);
            this.lblCMF8.Size = new System.Drawing.Size(196, 18);
            // 
            // lblCMF7
            // 
            this.lblCMF7.Location = new System.Drawing.Point(24, 202);
            this.lblCMF7.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF6
            // 
            this.lblCMF6.Location = new System.Drawing.Point(24, 172);
            this.lblCMF6.Size = new System.Drawing.Size(196, 18);
            // 
            // lblCMF5
            // 
            this.lblCMF5.Location = new System.Drawing.Point(24, 143);
            this.lblCMF5.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF4
            // 
            this.lblCMF4.Location = new System.Drawing.Point(24, 113);
            this.lblCMF4.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF3
            // 
            this.lblCMF3.Location = new System.Drawing.Point(24, 84);
            this.lblCMF3.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF2
            // 
            this.lblCMF2.Location = new System.Drawing.Point(24, 54);
            this.lblCMF2.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF1
            // 
            this.lblCMF1.Location = new System.Drawing.Point(24, 25);
            this.lblCMF1.Size = new System.Drawing.Size(196, 17);
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.Location = new System.Drawing.Point(742, 256);
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF19.TextBoxWidth = 353;
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.Location = new System.Drawing.Point(742, 226);
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF18.TextBoxWidth = 353;
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.Location = new System.Drawing.Point(742, 197);
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF17.TextBoxWidth = 353;
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.Location = new System.Drawing.Point(742, 167);
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF16.TextBoxWidth = 353;
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.Location = new System.Drawing.Point(742, 138);
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.Size = new System.Drawing.Size(252, 24);
            this.cdvCMF15.TextBoxWidth = 353;
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.Location = new System.Drawing.Point(742, 108);
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF14.TextBoxWidth = 353;
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.Location = new System.Drawing.Point(742, 79);
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.Size = new System.Drawing.Size(252, 24);
            this.cdvCMF13.TextBoxWidth = 353;
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.Location = new System.Drawing.Point(742, 49);
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.Size = new System.Drawing.Size(252, 25);
            this.cdvCMF12.TextBoxWidth = 353;
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.Location = new System.Drawing.Point(742, 286);
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.Size = new System.Drawing.Size(252, 24);
            this.cdvCMF20.TextBoxWidth = 353;
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.Location = new System.Drawing.Point(742, 20);
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.Size = new System.Drawing.Size(252, 24);
            this.cdvCMF11.TextBoxWidth = 353;
            // 
            // lblCMF20
            // 
            this.lblCMF20.Location = new System.Drawing.Point(538, 290);
            this.lblCMF20.Size = new System.Drawing.Size(196, 18);
            // 
            // lblCMF19
            // 
            this.lblCMF19.Location = new System.Drawing.Point(538, 261);
            this.lblCMF19.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF18
            // 
            this.lblCMF18.Location = new System.Drawing.Point(538, 231);
            this.lblCMF18.Size = new System.Drawing.Size(196, 18);
            // 
            // lblCMF17
            // 
            this.lblCMF17.Location = new System.Drawing.Point(538, 202);
            this.lblCMF17.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF16
            // 
            this.lblCMF16.Location = new System.Drawing.Point(538, 172);
            this.lblCMF16.Size = new System.Drawing.Size(196, 18);
            // 
            // lblCMF15
            // 
            this.lblCMF15.Location = new System.Drawing.Point(538, 143);
            this.lblCMF15.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF14
            // 
            this.lblCMF14.Location = new System.Drawing.Point(538, 113);
            this.lblCMF14.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF13
            // 
            this.lblCMF13.Location = new System.Drawing.Point(538, 84);
            this.lblCMF13.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF12
            // 
            this.lblCMF12.Location = new System.Drawing.Point(538, 54);
            this.lblCMF12.Size = new System.Drawing.Size(196, 17);
            // 
            // lblCMF11
            // 
            this.lblCMF11.Location = new System.Drawing.Point(538, 25);
            this.lblCMF11.Size = new System.Drawing.Size(196, 17);
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Location = new System.Drawing.Point(850, 15);
            this.pnlTranTime.Size = new System.Drawing.Size(415, 24);
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.Location = new System.Drawing.Point(195, 0);
            this.txtTranDateTime.MaxLength = 30;
            this.txtTranDateTime.Size = new System.Drawing.Size(219, 23);
            this.txtTranDateTime.TabStop = true;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.Location = new System.Drawing.Point(315, 0);
            this.dtpTranTime.Size = new System.Drawing.Size(99, 23);
            this.dtpTranTime.TabStop = false;            
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.Location = new System.Drawing.Point(195, 0);
            this.dtpTranDate.Size = new System.Drawing.Size(120, 23);
            this.dtpTranDate.TabStop = false;
            // 
            // tabTran
            // 
            this.tabTran.Size = new System.Drawing.Size(1282, 702);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Location = new System.Drawing.Point(21, 17);
            this.lblLotID.Size = new System.Drawing.Size(51, 17);
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.Location = new System.Drawing.Point(21, 47);
            this.lblLotDesc.Size = new System.Drawing.Size(79, 17);
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(168, 15);
            this.txtLotID.Size = new System.Drawing.Size(280, 23);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.Location = new System.Drawing.Point(168, 44);
            this.txtLotDesc.Size = new System.Drawing.Size(1097, 23);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(11, 10);
            this.btnRefresh.Size = new System.Drawing.Size(34, 29);
            this.btnRefresh.TabIndex = 2;
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(1288, 76);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 76);
            this.pnlTranCenter.Size = new System.Drawing.Size(1288, 705);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Size = new System.Drawing.Size(1282, 76);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(1030, 9);
            this.btnProcess.Size = new System.Drawing.Size(124, 32);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1158, 9);
            this.btnClose.Size = new System.Drawing.Size(123, 32);
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 781);
            this.pnlBottom.Size = new System.Drawing.Size(1288, 50);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(1288, 781);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(1281, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Size = new System.Drawing.Size(1277, 0);
            this.lblFormTitle.Text = "End Lot";
            // 
            // pnlResInfo
            // 
            this.pnlResInfo.Controls.Add(this.grpResInfo);
            this.pnlResInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResInfo.Location = new System.Drawing.Point(0, 315);
            this.pnlResInfo.Name = "pnlResInfo";
            this.pnlResInfo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlResInfo.Size = new System.Drawing.Size(1268, 135);
            this.pnlResInfo.TabIndex = 2;
            // 
            // grpResInfo
            // 
            this.grpResInfo.Controls.Add(this.spdResInfo);
            this.grpResInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResInfo.Location = new System.Drawing.Point(0, 3);
            this.grpResInfo.Name = "grpResInfo";
            this.grpResInfo.Size = new System.Drawing.Size(1268, 132);
            this.grpResInfo.TabIndex = 0;
            this.grpResInfo.TabStop = false;
            this.grpResInfo.Text = "Resource Information";
            // 
            // spdResInfo
            // 
            this.spdResInfo.AccessibleDescription = "";
            this.spdResInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdResInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdResInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResInfo.HorizontalScrollBar.Name = "";
            this.spdResInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdResInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdResInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdResInfo.Location = new System.Drawing.Point(3, 19);
            this.spdResInfo.MoveActiveOnFocus = false;
            this.spdResInfo.Name = "spdResInfo";
            this.spdResInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdResInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdResInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResInfo_LotInfo});
            this.spdResInfo.Size = new System.Drawing.Size(1262, 110);
            this.spdResInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResInfo.TabIndex = 0;
            this.spdResInfo.TabStop = false;
            this.spdResInfo.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdResInfo.TextTipDelay = 200;
            this.spdResInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdResInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResInfo.VerticalScrollBar.Name = "";
            this.spdResInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdResInfo.VerticalScrollBar.TabIndex = 3;
            this.spdResInfo.Resize += new System.EventHandler(this.spdResInfo_Resize);
            // 
            // spdResInfo_LotInfo
            // 
            this.spdResInfo_LotInfo.Reset();
            spdResInfo_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdResInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdResInfo_LotInfo.ColumnCount = 4;
            spdResInfo_LotInfo.RowCount = 6;
            this.spdResInfo_LotInfo.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(0, 0).ParseFormatString = "G";
            this.spdResInfo_LotInfo.Cells.Get(0, 0).Value = "Up/Down Flag";
            this.spdResInfo_LotInfo.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(0, 2).ParseFormatString = "G";
            this.spdResInfo_LotInfo.Cells.Get(0, 2).Value = "Primary Status";
            this.spdResInfo_LotInfo.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(4, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Cells.Get(5, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdResInfo_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdResInfo_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdResInfo_LotInfo.ColumnHeader.Visible = false;
            this.spdResInfo_LotInfo.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdResInfo_LotInfo.Columns.Get(0).Border = compoundBorder1;
            this.spdResInfo_LotInfo.Columns.Get(0).CellType = textCellType1;
            this.spdResInfo_LotInfo.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(0).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(0).Width = 148F;
            this.spdResInfo_LotInfo.Columns.Get(1).CellType = textCellType2;
            this.spdResInfo_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Columns.Get(1).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(1).Width = 199F;
            this.spdResInfo_LotInfo.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdResInfo_LotInfo.Columns.Get(2).Border = compoundBorder2;
            this.spdResInfo_LotInfo.Columns.Get(2).CellType = textCellType3;
            this.spdResInfo_LotInfo.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(2).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(2).Width = 148F;
            this.spdResInfo_LotInfo.Columns.Get(3).CellType = textCellType4;
            this.spdResInfo_LotInfo.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Columns.Get(3).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(3).Width = 199F;
            this.spdResInfo_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdResInfo_LotInfo.RowHeader.Columns.Default.Resizable = false;
            this.spdResInfo_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdResInfo_LotInfo.RowHeader.Visible = false;
            this.spdResInfo_LotInfo.Rows.Get(0).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(1).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(2).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(3).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(4).Height = 17F;
            this.spdResInfo_LotInfo.Rows.Get(5).Height = 17F;
            this.spdResInfo_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResInfo_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdResInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpTranInfo
            // 
            this.grpTranInfo.Controls.Add(this.chkForceEndSublot);
            this.grpTranInfo.Controls.Add(this.cdvToFlow);
            this.grpTranInfo.Controls.Add(this.lblQty23);
            this.grpTranInfo.Controls.Add(this.txtNewQty3);
            this.grpTranInfo.Controls.Add(this.txtNewQty2);
            this.grpTranInfo.Controls.Add(this.txtNewQty1);
            this.grpTranInfo.Controls.Add(this.lblQty1);
            this.grpTranInfo.Controls.Add(this.lisProcOperList);
            this.grpTranInfo.Controls.Add(this.cdvResID);
            this.grpTranInfo.Controls.Add(this.lblResID);
            this.grpTranInfo.Controls.Add(this.cdvRetOperation);
            this.grpTranInfo.Controls.Add(this.lblRetOper);
            this.grpTranInfo.Controls.Add(this.cdvToOperation);
            this.grpTranInfo.Controls.Add(this.lblToOper);
            this.grpTranInfo.Controls.Add(this.cdvReturnFlow);
            this.grpTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTranInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTranInfo.Location = new System.Drawing.Point(0, 0);
            this.grpTranInfo.Name = "grpTranInfo";
            this.grpTranInfo.Size = new System.Drawing.Size(1268, 315);
            this.grpTranInfo.TabIndex = 0;
            this.grpTranInfo.TabStop = false;
            // 
            // chkForceEndSublot
            // 
            this.chkForceEndSublot.AutoSize = true;
            this.chkForceEndSublot.Location = new System.Drawing.Point(497, 113);
            this.chkForceEndSublot.Name = "chkForceEndSublot";
            this.chkForceEndSublot.Size = new System.Drawing.Size(235, 21);
            this.chkForceEndSublot.TabIndex = 14;
            this.chkForceEndSublot.Text = "Forcibly End Sublots with the Lot";
            this.chkForceEndSublot.UseVisualStyleBackColor = true;
            this.chkForceEndSublot.Visible = false;
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
            this.cdvToFlow.LabelWidth = 148;
            this.cdvToFlow.ListCond_ExtFactory = "";
            this.cdvToFlow.ListCond_Step = '1';
            this.cdvToFlow.Location = new System.Drawing.Point(17, 21);
            this.cdvToFlow.Name = "cdvToFlow";
            this.cdvToFlow.SearchSubItemIndex = 0;
            this.cdvToFlow.SelectedDescIndex = -1;
            this.cdvToFlow.SelectedSubItemIndex = 0;
            this.cdvToFlow.SequenceReadOnly = false;
            this.cdvToFlow.Size = new System.Drawing.Size(428, 25);
            this.cdvToFlow.TabIndex = 0;
            this.cdvToFlow.VisibleColumnHeader = false;
            this.cdvToFlow.VisibleDescription = false;
            this.cdvToFlow.VisibleFlowButton = true;
            this.cdvToFlow.VisibleSequenceButton = true;
            this.cdvToFlow.WidthButton = 20;
            this.cdvToFlow.WidthFlowAndSequence = 451;
            this.cdvToFlow.WidthSequence = 70;
            this.cdvToFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToFlow_SelectedItemChanged);
            this.cdvToFlow.FlowButtonPress += new System.EventHandler(this.cdvToFlow_FlowButtonPress);
            // 
            // lblQty23
            // 
            this.lblQty23.AutoSize = true;
            this.lblQty23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty23.Location = new System.Drawing.Point(90, 116);
            this.lblQty23.Name = "lblQty23";
            this.lblQty23.Size = new System.Drawing.Size(40, 17);
            this.lblQty23.TabIndex = 6;
            this.lblQty23.Text = "/ 2/ 3";
            this.lblQty23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNewQty3
            // 
            this.txtNewQty3.Location = new System.Drawing.Point(353, 111);
            this.txtNewQty3.MaxLength = 11;
            this.txtNewQty3.Name = "txtNewQty3";
            this.txtNewQty3.Size = new System.Drawing.Size(92, 23);
            this.txtNewQty3.TabIndex = 9;
            this.txtNewQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewQty2
            // 
            this.txtNewQty2.Location = new System.Drawing.Point(259, 111);
            this.txtNewQty2.MaxLength = 11;
            this.txtNewQty2.Name = "txtNewQty2";
            this.txtNewQty2.Size = new System.Drawing.Size(92, 23);
            this.txtNewQty2.TabIndex = 8;
            this.txtNewQty2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNewQty1
            // 
            this.txtNewQty1.Location = new System.Drawing.Point(165, 111);
            this.txtNewQty1.MaxLength = 11;
            this.txtNewQty1.Name = "txtNewQty1";
            this.txtNewQty1.Size = new System.Drawing.Size(93, 23);
            this.txtNewQty1.TabIndex = 7;
            this.txtNewQty1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQty1
            // 
            this.lblQty1.AutoSize = true;
            this.lblQty1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty1.Location = new System.Drawing.Point(17, 116);
            this.lblQty1.Name = "lblQty1";
            this.lblQty1.Size = new System.Drawing.Size(73, 17);
            this.lblQty1.TabIndex = 5;
            this.lblQty1.Text = "New Qty 1";
            this.lblQty1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisProcOperList
            // 
            this.lisProcOperList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lisProcOperList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOper});
            this.lisProcOperList.EnableSort = true;
            this.lisProcOperList.EnableSortIcon = true;
            this.lisProcOperList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisProcOperList.FullRowSelect = true;
            this.lisProcOperList.Location = new System.Drawing.Point(1092, 11);
            this.lisProcOperList.Name = "lisProcOperList";
            this.lisProcOperList.Size = new System.Drawing.Size(165, 107);
            this.lisProcOperList.TabIndex = 13;
            this.lisProcOperList.TabStop = false;
            this.lisProcOperList.UseCompatibleStateImageBehavior = false;
            this.lisProcOperList.View = System.Windows.Forms.View.Details;
            this.lisProcOperList.Visible = false;
            // 
            // colOper
            // 
            this.colOper.Text = "Processed Operation";
            this.colOper.Width = 101;
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.ButtonWidth = 20;
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(165, 81);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MultiSelect = false;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SameWidthHeightOfButton = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedDescToQueryText = "";
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectedValueToQueryText = "";
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(280, 25);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 4;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 392;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResID_TextBoxKeyPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(17, 86);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(97, 17);
            this.lblResID.TabIndex = 3;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvRetOperation
            // 
            this.cdvRetOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRetOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRetOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRetOperation.BtnToolTipText = "";
            this.cdvRetOperation.ButtonWidth = 20;
            this.cdvRetOperation.DescText = "";
            this.cdvRetOperation.DisplaySubItemIndex = -1;
            this.cdvRetOperation.DisplayText = "";
            this.cdvRetOperation.Focusing = null;
            this.cdvRetOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRetOperation.Index = 0;
            this.cdvRetOperation.IsViewBtnImage = false;
            this.cdvRetOperation.Location = new System.Drawing.Point(641, 52);
            this.cdvRetOperation.MaxLength = 10;
            this.cdvRetOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRetOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRetOperation.MultiSelect = false;
            this.cdvRetOperation.Name = "cdvRetOperation";
            this.cdvRetOperation.ReadOnly = false;
            this.cdvRetOperation.SameWidthHeightOfButton = false;
            this.cdvRetOperation.SearchSubItemIndex = 0;
            this.cdvRetOperation.SelectedDescIndex = -1;
            this.cdvRetOperation.SelectedDescToQueryText = "";
            this.cdvRetOperation.SelectedSubItemIndex = -1;
            this.cdvRetOperation.SelectedValueToQueryText = "";
            this.cdvRetOperation.SelectionStart = 0;
            this.cdvRetOperation.Size = new System.Drawing.Size(280, 24);
            this.cdvRetOperation.SmallImageList = null;
            this.cdvRetOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRetOperation.TabIndex = 12;
            this.cdvRetOperation.TextBoxToolTipText = "";
            this.cdvRetOperation.TextBoxWidth = 392;
            this.cdvRetOperation.VisibleButton = true;
            this.cdvRetOperation.VisibleColumnHeader = false;
            this.cdvRetOperation.VisibleDescription = false;
            this.cdvRetOperation.ButtonPress += new System.EventHandler(this.cdvRetOperation_ButtonPress);
            // 
            // lblRetOper
            // 
            this.lblRetOper.AutoSize = true;
            this.lblRetOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRetOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetOper.Location = new System.Drawing.Point(493, 57);
            this.lblRetOper.Name = "lblRetOper";
            this.lblRetOper.Size = new System.Drawing.Size(118, 17);
            this.lblRetOper.TabIndex = 11;
            this.lblRetOper.Text = "Return Operation";
            this.lblRetOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvToOperation
            // 
            this.cdvToOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToOperation.BtnToolTipText = "";
            this.cdvToOperation.ButtonWidth = 20;
            this.cdvToOperation.DescText = "";
            this.cdvToOperation.DisplaySubItemIndex = -1;
            this.cdvToOperation.DisplayText = "";
            this.cdvToOperation.Focusing = null;
            this.cdvToOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToOperation.Index = 0;
            this.cdvToOperation.IsViewBtnImage = false;
            this.cdvToOperation.Location = new System.Drawing.Point(165, 52);
            this.cdvToOperation.MaxLength = 10;
            this.cdvToOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToOperation.MultiSelect = false;
            this.cdvToOperation.Name = "cdvToOperation";
            this.cdvToOperation.ReadOnly = false;
            this.cdvToOperation.SameWidthHeightOfButton = false;
            this.cdvToOperation.SearchSubItemIndex = 0;
            this.cdvToOperation.SelectedDescIndex = -1;
            this.cdvToOperation.SelectedDescToQueryText = "";
            this.cdvToOperation.SelectedSubItemIndex = -1;
            this.cdvToOperation.SelectedValueToQueryText = "";
            this.cdvToOperation.SelectionStart = 0;
            this.cdvToOperation.Size = new System.Drawing.Size(280, 24);
            this.cdvToOperation.SmallImageList = null;
            this.cdvToOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToOperation.TabIndex = 2;
            this.cdvToOperation.TextBoxToolTipText = "";
            this.cdvToOperation.TextBoxWidth = 392;
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
            this.lblToOper.Location = new System.Drawing.Point(17, 57);
            this.lblToOper.Name = "lblToOper";
            this.lblToOper.Size = new System.Drawing.Size(92, 17);
            this.lblToOper.TabIndex = 1;
            this.lblToOper.Text = "To Operation";
            this.lblToOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvReturnFlow.LabelWidth = 148;
            this.cdvReturnFlow.ListCond_ExtFactory = "";
            this.cdvReturnFlow.ListCond_Step = '1';
            this.cdvReturnFlow.Location = new System.Drawing.Point(493, 21);
            this.cdvReturnFlow.Name = "cdvReturnFlow";
            this.cdvReturnFlow.SearchSubItemIndex = 0;
            this.cdvReturnFlow.SelectedDescIndex = -1;
            this.cdvReturnFlow.SelectedSubItemIndex = 0;
            this.cdvReturnFlow.SequenceReadOnly = false;
            this.cdvReturnFlow.Size = new System.Drawing.Size(428, 25);
            this.cdvReturnFlow.TabIndex = 10;
            this.cdvReturnFlow.VisibleColumnHeader = false;
            this.cdvReturnFlow.VisibleDescription = false;
            this.cdvReturnFlow.VisibleFlowButton = true;
            this.cdvReturnFlow.VisibleSequenceButton = true;
            this.cdvReturnFlow.WidthButton = 20;
            this.cdvReturnFlow.WidthFlowAndSequence = 451;
            this.cdvReturnFlow.WidthSequence = 70;
            this.cdvReturnFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRetFlow_SelectedItemChanged);
            this.cdvReturnFlow.FlowButtonPress += new System.EventHandler(this.cdvReturnFlow_FlowButtonPress);
            // 
            // frmWIPTranEndLotForIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.ClientSize = new System.Drawing.Size(1288, 831);
            this.MinimumSize = new System.Drawing.Size(1306, 878);
            this.Name = "frmWIPTranEndLotForIT";
            this.Text = "End Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranEndLotForIT_Activated);
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
            this.pnlResInfo.ResumeLayout(false);
            this.grpResInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).EndInit();
            this.grpTranInfo.ResumeLayout(false);
            this.grpTranInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRetOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToOperation)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "

        private const string MFO_OPT_SUBLOT_PROCESS_OPT = "SUBLOT_PROCESS_OPT";

        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private const int COL_LOT_ID = 1;
        private const int COL_MAT_ID = 2;
        private const int COL_FLOW = 3;
        private const int COL_OPERATION = 4;
        private const int COL_ACTIVE_LAST_HIST_SEQ = 94;
        public bool bDispatcherFlag = false;
        public string sLotID = "";
        public string sResourceID = "";
        
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

            if (base.ViewLotInfo(txtLotID.Text) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

            GetResourceIDList();
            
            ViewProcOperList();
            cdvResID.Text = LOT.GetString("START_RES_ID");

            if (cdvResID.Text != "")
            {
                if (View_Resource() == false)
                {
                    txtLotID.Focus();
                    return false;
                }
            }

            if (ViewSublotProcessOption() == false)
            {
                return false;
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
        // GetResourceIDList()
        //       - Get ResourceID List by Operation
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

#if _RAS
                if (RASLIST.ViewResourceList(cdvResID.GetListView, LOT.GetString("MAT_ID"), LOT.GetInt("MAT_VER"), LOT.GetString("FLOW"), LOT.GetString("OPER"), false) == false)
                {
                    return false;
                }
#endif
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
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
                case "END_LOT":

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
                    if (cdvReturnFlow.Text == "" && cdvRetOperation.Text != "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvReturnFlow.FlowFocus();
                        return false;
                    }
                    if (cdvReturnFlow.Text != "" && cdvRetOperation.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabTran.SelectedTab = tbpGeneral;
                        cdvRetOperation.Focus();
                        return false;
                    }
                    if (cdvReturnFlow.Text != "" && cdvRetOperation.Text != "")
                    {
                        if (cdvToFlow.Text == "" || cdvToOperation.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            tabTran.SelectedTab = tbpGeneral;
                            if (cdvToFlow.Text == "")
                            {
                                cdvToFlow.Focus();
                                return false;
                            }
                            if (cdvToOperation.Text == "")
                            {
                                cdvToOperation.Focus();
                                return false;
                            }
                        }
                    }
                    if (LOT.GetDouble("QTY_1") > 0 || LOT.GetDouble("QTY_2") > 0 || LOT.GetDouble("QTY_3") > 0)
                    {
                        if (cdvResID.Items.Count > 0)
                        {
                            if (MPCF.CheckValue(cdvResID, 1) == false)
                            {
                                tabTran.SelectedTab = tbpGeneral;
                                cdvResID.Focus();
                                return false;
                            }
                        }
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
                cdvRetOperation.Init();
                MPCF.InitListView(cdvRetOperation.GetListView);
                cdvRetOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvRetOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvRetOperation.SelectedSubItemIndex = 0;
                
                if (WIPLIST.ViewOperationList(cdvRetOperation.GetListView, '2', "", 0,sFlow, "", null, "") == false)
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
        
        private void InitResInfo()
        {
            
            //Initilize spdResInfo
            spdResInfo.Sheets[0].Cells[0, 1].Text = "";
            spdResInfo.Sheets[0].Cells[0, 3].Text = "";
            spdResInfo.Sheets[0].Cells[1, 0].Text = "";
            spdResInfo.Sheets[0].Cells[1, 1].Text = "";
            spdResInfo.Sheets[0].Cells[1, 2].Text = "";
            spdResInfo.Sheets[0].Cells[1, 3].Text = "";
            spdResInfo.Sheets[0].Cells[2, 0].Text = "";
            spdResInfo.Sheets[0].Cells[2, 1].Text = "";
            spdResInfo.Sheets[0].Cells[2, 2].Text = "";
            spdResInfo.Sheets[0].Cells[2, 3].Text = "";
            spdResInfo.Sheets[0].Cells[3, 0].Text = "";
            spdResInfo.Sheets[0].Cells[3, 1].Text = "";
            spdResInfo.Sheets[0].Cells[3, 2].Text = "";
            spdResInfo.Sheets[0].Cells[3, 3].Text = "";
            spdResInfo.Sheets[0].Cells[4, 0].Text = "";
            spdResInfo.Sheets[0].Cells[4, 1].Text = "";
            spdResInfo.Sheets[0].Cells[4, 2].Text = "";
            spdResInfo.Sheets[0].Cells[4, 3].Text = "";
            spdResInfo.Sheets[0].Cells[5, 0].Text = "";
            spdResInfo.Sheets[0].Cells[5, 1].Text = "";
            spdResInfo.Sheets[0].Cells[5, 2].Text = "";
            spdResInfo.Sheets[0].Cells[5, 3].Text = "";
            
        }
        
        private void ViewProcOperList()
        {
            
            WIPLIST.ViewProcessedOperationList(lisProcOperList, '1', txtLotID.Text, null);
            if (lisProcOperList.Items.Count > 0)
            {
                
                cdvToFlow.Size = new Size(279, 20);
                cdvToOperation.Size = new Size(172, 20);
                cdvResID.Size = new Size(172, 20);
                
                txtNewQty1.Size = new Size(57, 20);
                txtNewQty2.Size = new Size(57, 20);
                txtNewQty3.Size = new Size(57, 20);
                
                lblRetOper.Location = new Point(308, 46);
                cdvReturnFlow.Location = new Point(307, 17);
                cdvRetOperation.Location = new Point(414, 42);
                cdvReturnFlow.Size = new Size(279, 20);
                cdvRetOperation.Size = new Size(172, 20);
                
                txtNewQty1.Location = new Point(118, 90);
                txtNewQty2.Location = new Point(176, 90);
                txtNewQty3.Location = new Point(234, 90);
                
                lisProcOperList.Visible = true;
                
            }
            else
            {
                
                cdvToFlow.Size = new Size(307, 20);
                cdvToOperation.Size = new Size(200, 20);
                cdvResID.Size = new Size(200, 20);
                
                txtNewQty1.Size = new Size(66, 20);
                txtNewQty2.Size = new Size(66, 20);
                txtNewQty3.Size = new Size(66, 20);
                
                lblRetOper.Location = new Point(352, 46);
                cdvReturnFlow.Location = new Point(352, 17);
                cdvRetOperation.Location = new Point(458, 42);
                cdvReturnFlow.Size = new Size(307, 20);
                cdvRetOperation.Size = new Size(200, 20);
                
                txtNewQty1.Location = new Point(118, 90);
                txtNewQty2.Location = new Point(185, 90);
                txtNewQty3.Location = new Point(252, 90);
                
                lisProcOperList.Visible = false;
                
            }
            
        }
        
        
        //
        // View_Resource()
        //       - Get ResourceID Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Resource()
        {

#if _RAS
            TRSNode in_node = new TRSNode("VIEW_RESOURCE_IN");
            TRSNode out_node = new TRSNode("VIEW_RESOURCE_OUT");

            try
            {
                InitResInfo();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));

                if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("RES_UP_DOWN_FLAG") == 'U')
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "UP";
                }
                else if (out_node.GetChar("RES_UP_DOWN_FLAG") == 'D')
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "DOWN";
                }
                spdResInfo.Sheets[0].Cells[0, 3].Text = out_node.GetString("RES_PRI_STS");

                spdResInfo.Sheets[0].Cells[1, 1].Text = out_node.GetString("RES_STS_1");
                spdResInfo.Sheets[0].Cells[1, 3].Text = out_node.GetString("RES_STS_2");
                spdResInfo.Sheets[0].Cells[2, 1].Text = out_node.GetString("RES_STS_3");
                spdResInfo.Sheets[0].Cells[2, 3].Text = out_node.GetString("RES_STS_4");
                spdResInfo.Sheets[0].Cells[3, 1].Text = out_node.GetString("RES_STS_5");
                spdResInfo.Sheets[0].Cells[3, 3].Text = out_node.GetString("RES_STS_6");
                spdResInfo.Sheets[0].Cells[4, 1].Text = out_node.GetString("RES_STS_7");
                spdResInfo.Sheets[0].Cells[4, 3].Text = out_node.GetString("RES_STS_8");
                spdResInfo.Sheets[0].Cells[5, 1].Text = out_node.GetString("RES_STS_9");
                spdResInfo.Sheets[0].Cells[5, 3].Text = out_node.GetString("RES_STS_10");

                //if (MPCF.Trim(out_node.GetString("USE_FAC_PRT_FLAG")) == "Y")
                if (out_node.GetChar("USE_FAC_PRT_FLAG") == 'Y')
                {
                    View_Factory_ResStatus();
                }
                else
                {
                    spdResInfo.Sheets[0].Cells[1, 0].Text = out_node.GetString("RES_STS_PRT_1");
                    spdResInfo.Sheets[0].Cells[1, 2].Text = out_node.GetString("RES_STS_PRT_2");
                    spdResInfo.Sheets[0].Cells[2, 0].Text = out_node.GetString("RES_STS_PRT_3");
                    spdResInfo.Sheets[0].Cells[2, 2].Text = out_node.GetString("RES_STS_PRT_4");
                    spdResInfo.Sheets[0].Cells[3, 0].Text = out_node.GetString("RES_STS_PRT_5");
                    spdResInfo.Sheets[0].Cells[3, 2].Text = out_node.GetString("RES_STS_PRT_6");
                    spdResInfo.Sheets[0].Cells[4, 0].Text = out_node.GetString("RES_STS_PRT_7");
                    spdResInfo.Sheets[0].Cells[4, 2].Text = out_node.GetString("RES_STS_PRT_8");
                    spdResInfo.Sheets[0].Cells[5, 0].Text = out_node.GetString("RES_STS_PRT_9");
                    spdResInfo.Sheets[0].Cells[5, 2].Text = out_node.GetString("RES_STS_PRT_10");
                }


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
#endif

            return true;

        }

        //
        // View_Factory_ResStatus()
        //       - Get Resource Status Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Factory_ResStatus()
        {

            TRSNode in_node = new TRSNode("VIEW_FACTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_FACTORY_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (MPCR.CallService("WIP", "WIP_View_Factory", in_node, ref out_node) == false)
                {
                    return false;
                }

                spdResInfo.Sheets[0].Cells[1, 0].Text = out_node.GetString("RES_STS_1");
                spdResInfo.Sheets[0].Cells[1, 2].Text = out_node.GetString("RES_STS_2");
                spdResInfo.Sheets[0].Cells[2, 0].Text = out_node.GetString("RES_STS_3");
                spdResInfo.Sheets[0].Cells[2, 2].Text = out_node.GetString("RES_STS_4");
                spdResInfo.Sheets[0].Cells[3, 0].Text = out_node.GetString("RES_STS_5");
                spdResInfo.Sheets[0].Cells[3, 2].Text = out_node.GetString("RES_STS_6");
                spdResInfo.Sheets[0].Cells[4, 0].Text = out_node.GetString("RES_STS_7");
                spdResInfo.Sheets[0].Cells[4, 2].Text = out_node.GetString("RES_STS_8");
                spdResInfo.Sheets[0].Cells[5, 0].Text = out_node.GetString("RES_STS_9");
                spdResInfo.Sheets[0].Cells[5, 2].Text = out_node.GetString("RES_STS_10");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        
        //
        // End_Lot()
        //       - End Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool End_Lot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("END_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            bool b_proc_alarm_action;
            string formatString = "yyyyMMddHHmmss";
            DateTime backTime = DateTime.Now;                    

            try
            {
                /***** Start Check Input Port and Change Carrier *****/
                if (CheckResourcePortAndCarrierChange(ref in_node) == false) return false;
                if(in_node.GetList("CHANGE_PORT_STATUS").Count > 0)
                {
                    in_node.AddString("SUBRES_ID", in_node.GetList("CHANGE_PORT_STATUS")[0].GetString("SUBRES_ID"));
                    in_node.AddString("PORT_ID", in_node.GetList("CHANGE_PORT_STATUS")[0].GetString("PORT_ID"));                    

                    
                    if (DateTime.TryParseExact(MPCF.Trim(txtTranDateTime.Text), formatString, CultureInfo.InvariantCulture, DateTimeStyles.None, out backTime) == false)
                    {
                        MPCF.ShowMsgBox("Check Tran Time");
                        return false;
                    }
                    in_node.GetList("CHANGE_PORT_STATUS")[0].AddString("BACK_TIME", MPCF.Trim(txtTranDateTime.Text));                    
                }
                if (in_node.GetList("CHANGE_CARRIER").Count > 0)
                {
                    if (DateTime.TryParseExact(MPCF.Trim(txtTranDateTime.Text), formatString, CultureInfo.InvariantCulture, DateTimeStyles.None, out backTime) == false)
                    {
                        MPCF.ShowMsgBox("Check Tran Time");
                        return false;
                    }
                    in_node.GetList("CHANGE_PORT_STATUS")[0].AddString("BACK_TIME", MPCF.Trim(txtTranDateTime.Text));       

                }
                /***** End Check Input Port and Change Carrier *****/


                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                if (MPCR.CheckTranAlarmRelation(this,
                                                MPGC.MP_ALM_TRAN_END,
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

                if (DateTime.TryParseExact(MPCF.Trim(txtTranDateTime.Text), formatString, CultureInfo.InvariantCulture, DateTimeStyles.None, out backTime) == false)
                {
                    MPCF.ShowMsgBox("Check Tran Time");
                    return false;
                }
                in_node.AddString("BACK_TIME", MPCF.Trim(txtTranDateTime.Text));

                in_node.AddString("TO_FLOW", MPCF.Trim(cdvToFlow.Text));
                in_node.AddInt("TO_FLOW_SEQ_NUM", cdvToFlow.Sequence);
                in_node.AddString("TO_OPER", MPCF.Trim(cdvToOperation.Text));
                in_node.AddString("RET_FLOW", MPCF.Trim(cdvReturnFlow.Text));
                in_node.AddInt("RET_FLOW_SEQ_NUM", cdvReturnFlow.Sequence);
                in_node.AddString("RET_OPER", MPCF.Trim(cdvRetOperation.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
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

                in_node.AddChar("FORCIBLY_END_WITH_SUBLOT_FLAG", chkForceEndSublot.Checked == true ? 'Y' : ' ');

                /***** Start Collect BIN Data *****/
                bool b_proc_end_lot_by_bin_flag = false;
                if (CollectBinData(ref b_proc_end_lot_by_bin_flag, in_node) == false)
                {
                    return false;
                }
                /***** End Collect BIN Data *****/

                if (b_proc_end_lot_by_bin_flag == false)
                {
                    if (MPCR.CallService("WIP", "WIP_End_Lot", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    MPCR.ShowSuccessMsg(out_node);
                }

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

        private bool ViewSublotProcessOption()
        {
            TRSNode in_node = new TRSNode("VIEW_MFO_OPTION_IN");
            TRSNode out_node = new TRSNode("VIEW_MFO_OPTION_OUT");

            try
            {
                chkForceEndSublot.Checked = false;
                chkForceEndSublot.Visible = false;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddString("OPTION_NAME", MFO_OPT_SUBLOT_PROCESS_OPT);
                in_node.AddString("KEY_1", "Y");

                in_node.AddInt("OPTION_SEQ", 0);
                in_node.AddChar("BASE_FLAG", 'M');
                in_node.AddChar("ORDER_FLAG", 'A');
                in_node.AddChar("FIRST_LAST_FLAG", 'L');

                if (MPCR.CallService("WIP", "WIP_View_MFO_Option_Value", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList("VALUE_LIST").Count > 0 && out_node.GetList("VALUE_LIST")[0].GetString("DATA_1") == "Y")
                {
                    chkForceEndSublot.Visible = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CollectBinData(ref bool b_proc_end_lot_by_bin_flag, TRSNode end_lot_in)
        {
            if (MPGO.UseBinManagement() == false) return true;
            if (MPCR.IsBinCollectionOper(txtLotID.Text) == false) return true;

            MPGV.gsCurrentLot_ID = txtLotID.Text;
            frmWIPTranCollectBinData f = new frmWIPTranCollectBinData();
            f.Width = this.Width;
            f.Height = this.Height;
            f.SetPopupAction(true, end_lot_in);
            f.StartPosition = FormStartPosition.CenterParent;

            if (f.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
            {
                return false;
            }

            if (MPGV.gtBinLot.low_yield_flag == true) return false;

            b_proc_end_lot_by_bin_flag = true;

            return true;
        }
        #endregion
        
        private void frmWIPTranEndLotForIT_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    SetCMFItem(MPGC.MP_CMF_TRN_END);
                    if (bDispatcherFlag == true)
                    {
                        if (sLotID != "")
                        {
                            txtLotID.Text = sLotID;
                            ViewLotInfo(txtLotID.Text);
                        }
                        if (sResourceID != "")
                        {
                            cdvResID.Text = sResourceID;
                            View_Resource();
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
                        if (MPCF.Trim(MPGV.gsCurrentRes_ID) != "")
                        {
                            cdvResID.Text = MPGV.gsCurrentRes_ID;
                            View_Resource();
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
        
        private void cdvToFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvToOperation.Text = "";
            if (MPCF.Trim(cdvToFlow.Text) != "")
            {
                cdvToFlow.ListCond_Step = '2';
                cdvToFlow.ListCond_MatID = LOT.GetString("MAT_ID");
                cdvToFlow.ListCond_MatVersion = LOT.GetInt("MAT_VER");
            }
        }

        private void cdvReturnFlow_FlowButtonPress(object sender, EventArgs e)
        {
            cdvReturnFlow.ListCond_Step = '1';
            cdvReturnFlow.ListCond_MatID = "";
            cdvReturnFlow.ListCond_MatVersion = 0;
        }
        
        private void cdvRetFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvRetOperation.Text = "";
            if (MPCF.Trim(cdvReturnFlow.Text) != "")
            {
                cdvReturnFlow.ListCond_Step = '2';
                cdvReturnFlow.ListCond_MatID = LOT.GetString("MAT_ID");
                cdvReturnFlow.ListCond_MatVersion = LOT.GetInt("MAT_VER");
            }
            
        }
        
        private void cdvToOperation_ButtonPress(System.Object sender, System.EventArgs e)
        {
            if (cdvToFlow.Text.Trim() == "" && LOT.GetString("FLOW").Trim() == "")
            {
                cdvToOperation.Init();
                cdvToOperation.Text = "";
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvToFlow.Focus();
                return;
            }

            if (cdvToFlow.Text.Trim() == "")
            {
                if (GetToOperationList(LOT.GetString("FLOW")) == false)
                {
                    return;
                }
            }
            else
            {
                if (GetToOperationList(cdvToFlow.Text) == false)
                {
                    return;
                }
            }
        }
        
        private void cdvRetOperation_ButtonPress(System.Object sender, System.EventArgs e)
        {

            if (cdvReturnFlow.CheckValue() == false) return;
            
            if (GetRetOperationList(cdvReturnFlow.Text) == false)
            {
                return;
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("END_LOT") == false) return;

                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_END, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "END_LOT", 'B') == false) return;
                if (End_Lot('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_END, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "END_LOT", 'A') == false) return;

                ViewLotInfo(txtLotID.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (MPCF.Trim(LOT.GetString("OPER")) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                txtLotID.Focus();
                return;
            }
            GetResourceIDList();
        }
        
        private void cdvResID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvResID.Text != "")
            {
                if (View_Resource() == false)
                {
                    return;
                }
            }
            
        }       
         
        private void cdvResID_TextBoxTextChanged(System.Object sender, System.EventArgs e)
        {
            
            if (cdvResID.Text == "")
            {
                InitResInfo();
            }
            
        }
        
        private void spdResInfo_Resize(System.Object sender, System.EventArgs e)
        {
            
            int iDiffSize;
            
            try
            {
                iDiffSize = (spdResInfo.Width - 716) / 2;
                if (iDiffSize >= 0)
                {
                    spdResInfo.Sheets[0].Columns[1].Width = 199 + iDiffSize;
                    spdResInfo.Sheets[0].Columns[3].Width = 199 + iDiffSize;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void cdvResID_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cdvResID.Text != "")
                {
                    if (View_Resource() == false)
                    {
                        return;
                    }
                }
            }
        }
    
    }
    
}
