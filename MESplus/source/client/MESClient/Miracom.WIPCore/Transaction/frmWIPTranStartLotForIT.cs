
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranStartLotForIT.vb
//   Description : Start Lot Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetResourceIDList() :Get ResourceID List
//       - Start_Lot() : Start Lot transaction
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
    public class frmWIPTranStartLotForIT : Miracom.MESCore.TranForm97
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranStartLotForIT()
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




        private System.Windows.Forms.GroupBox grpResID;
        private System.Windows.Forms.Panel pnlResInfo;
        private System.Windows.Forms.GroupBox grpResInfo;
        protected FarPoint.Win.Spread.FpSpread spdResInfo;
        private Miracom.MESCore.Controls.udcResource cdvResID;
        private CheckBox chkNoStartWithSublot;
        protected FarPoint.Win.Spread.SheetView spdResInfo_LotInfo;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
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
            this.grpResID = new System.Windows.Forms.GroupBox();
            this.chkNoStartWithSublot = new System.Windows.Forms.CheckBox();
            this.cdvResID = new Miracom.MESCore.Controls.udcResource();
            this.pnlResInfo = new System.Windows.Forms.Panel();
            this.grpResInfo = new System.Windows.Forms.GroupBox();
            this.spdResInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdResInfo_LotInfo = new FarPoint.Win.Spread.SheetView();
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
            this.grpResID.SuspendLayout();
            this.pnlResInfo.SuspendLayout();
            this.grpResInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpResID);
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
            this.pnlTranTime.Location = new System.Drawing.Point(608, 15);
            this.pnlTranTime.Size = new System.Drawing.Size(415, 24);
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.Location = new System.Drawing.Point(195, 0);
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
            this.btnRefresh.TabIndex = 3;
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
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1158, 9);
            this.btnClose.Size = new System.Drawing.Size(123, 32);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 781);
            this.pnlBottom.Size = new System.Drawing.Size(1288, 50);
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
            this.lblFormTitle.Text = "Start Lot";
            // 
            // grpResID
            // 
            this.grpResID.Controls.Add(this.chkNoStartWithSublot);
            this.grpResID.Controls.Add(this.cdvResID);
            this.grpResID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResID.Location = new System.Drawing.Point(0, 0);
            this.grpResID.Name = "grpResID";
            this.grpResID.Size = new System.Drawing.Size(1268, 290);
            this.grpResID.TabIndex = 0;
            this.grpResID.TabStop = false;
            // 
            // chkNoStartWithSublot
            // 
            this.chkNoStartWithSublot.AutoSize = true;
            this.chkNoStartWithSublot.Location = new System.Drawing.Point(589, 17);
            this.chkNoStartWithSublot.Name = "chkNoStartWithSublot";
            this.chkNoStartWithSublot.Size = new System.Drawing.Size(252, 21);
            this.chkNoStartWithSublot.TabIndex = 1;
            this.chkNoStartWithSublot.Text = "Start Lot alone, do not start sublots";
            this.chkNoStartWithSublot.UseVisualStyleBackColor = true;
            this.chkNoStartWithSublot.Visible = false;
            // 
            // cdvResID
            // 
            this.cdvResID.AddEmptyRowToLast = false;
            this.cdvResID.AddEmptyRowToTop = false;
            this.cdvResID.ButtonWidth = 21;
            this.cdvResID.DisplaySubItemIndex = 0;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.LabelText = "Resource";
            this.cdvResID.LabelWidth = 133;
            this.cdvResID.ListCond_ExtFactory = "";
            this.cdvResID.ListCond_IncludeDeleteResource = false;
            this.cdvResID.ListCond_Step = '1';
            this.cdvResID.Location = new System.Drawing.Point(25, 15);
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = 1;
            this.cdvResID.SelectedSubItemIndex = 0;
            this.cdvResID.Size = new System.Drawing.Size(413, 24);
            this.cdvResID.TabIndex = 0;
            this.cdvResID.TextBoxWidth = 280;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResID_TextBoxKeyPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // pnlResInfo
            // 
            this.pnlResInfo.Controls.Add(this.grpResInfo);
            this.pnlResInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResInfo.Location = new System.Drawing.Point(0, 290);
            this.pnlResInfo.Name = "pnlResInfo";
            this.pnlResInfo.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.pnlResInfo.Size = new System.Drawing.Size(1268, 160);
            this.pnlResInfo.TabIndex = 1;
            // 
            // grpResInfo
            // 
            this.grpResInfo.Controls.Add(this.spdResInfo);
            this.grpResInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResInfo.Location = new System.Drawing.Point(3, 5);
            this.grpResInfo.Name = "grpResInfo";
            this.grpResInfo.Size = new System.Drawing.Size(1262, 155);
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
            this.spdResInfo.Size = new System.Drawing.Size(1256, 133);
            this.spdResInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResInfo.TabIndex = 0;
            this.spdResInfo.TabStop = false;
            this.spdResInfo.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdResInfo.TextTipAppearance = tipAppearance1;
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
            // frmWIPTranStartLotForIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.ClientSize = new System.Drawing.Size(1288, 831);
            this.MinimumSize = new System.Drawing.Size(1306, 878);
            this.Name = "frmWIPTranStartLotForIT";
            this.Text = "Start Lot";
            this.Activated += new System.EventHandler(this.frmWIPTranStartLotForIT_Activated);
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
            this.grpResID.ResumeLayout(false);
            this.grpResID.PerformLayout();
            this.pnlResInfo.ResumeLayout(false);
            this.grpResInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "

        private const string MFO_OPT_SUBLOT_PROCESS_OPT = "SUBLOT_PROCESS_OPT";

        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
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

            if (base.ViewLotInfo(s_lot_id) == false)
            {
                txtLotID.Focus();
                return false;
            }
            txtLotDesc.Text = LOT.GetString("LOT_DESC");

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
        //       - Optional ByVal ProcStep As String ("1")
        //
        private void ClearData(string ProcStep)
        {
            
            try
            {
                switch (ProcStep)
                {
                    case "1":

                        MPCF.FieldClear(this);
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
                case "START_LOT":

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

                    if (LOT.GetDouble("QTY_1") > 0 || LOT.GetDouble("QTY_2") > 0 || LOT.GetDouble("QTY_3") > 0)
                    {
                        if (cdvResID.Items.Count > 0)
                        {
                            if (cdvResID.CheckValue() == false)
                            {
                                tabTran.SelectedTab = tbpGeneral;
                                cdvResID.Focus();
                                return false;
                            }
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
        
        //
        // View_Resource()
        //       - Get ResourceID Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewResource()
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
                spdResInfo.Sheets[0].Cells[0, 3].Text = MPCF.Trim(out_node.GetString("RES_PRI_STS"));

                spdResInfo.Sheets[0].Cells[1, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_1"));
                spdResInfo.Sheets[0].Cells[1, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_2"));
                spdResInfo.Sheets[0].Cells[2, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_3"));
                spdResInfo.Sheets[0].Cells[2, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_4"));
                spdResInfo.Sheets[0].Cells[3, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_5"));
                spdResInfo.Sheets[0].Cells[3, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_6"));
                spdResInfo.Sheets[0].Cells[4, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_7"));
                spdResInfo.Sheets[0].Cells[4, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_8"));
                spdResInfo.Sheets[0].Cells[5, 1].Text = MPCF.Trim(out_node.GetString("RES_STS_9"));
                spdResInfo.Sheets[0].Cells[5, 3].Text = MPCF.Trim(out_node.GetString("RES_STS_10"));

                if (out_node.GetChar("USE_FAC_PRT_FLAG") == 'Y')
                {
                    ViewFactoryResStatus();
                }
                else
                {
                    spdResInfo.Sheets[0].Cells[1, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_1"));
                    spdResInfo.Sheets[0].Cells[1, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_2"));
                    spdResInfo.Sheets[0].Cells[2, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_3"));
                    spdResInfo.Sheets[0].Cells[2, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_4"));
                    spdResInfo.Sheets[0].Cells[3, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_5"));
                    spdResInfo.Sheets[0].Cells[3, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_6"));
                    spdResInfo.Sheets[0].Cells[4, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_7"));
                    spdResInfo.Sheets[0].Cells[4, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_8"));
                    spdResInfo.Sheets[0].Cells[5, 0].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_9"));
                    spdResInfo.Sheets[0].Cells[5, 2].Text = MPCF.Trim(out_node.GetString("RES_STS_PRT_10"));
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
        private bool ViewFactoryResStatus()
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
        // Start_Lot()
        //       - Start Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool StartLot(char ProcStep)
        {

            TRSNode in_node = new TRSNode("START_LOT_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            bool b_proc_alarm_action;
            string formatString = "yyyyMMddHHmmss";
            DateTime backTime = DateTime.Now;      

            try
            {
                MPCR.SetInMsg(in_node);

                /***** Start Check Input Port and Change Carrier *****/
                if (CheckResourcePortAndCarrierChange(ref in_node) == false) return false;
                if (in_node.GetList("CHANGE_PORT_STATUS").Count > 0)
                {
                    in_node.AddString("SUBRES_ID", in_node.GetList("CHANGE_PORT_STATUS")[0].GetString("SUBRES_ID"));
                    in_node.AddString("PORT_ID", in_node.GetList("CHANGE_PORT_STATUS")[0].GetString("PORT_ID"));
                }
                /***** End Check Input Port and Change Carrier *****/

                /***** Start Check Transaction Confirm Message *****/
                b_proc_alarm_action = false;
                if (MPCR.CheckTranAlarmRelation(this,
                                                MPGC.MP_ALM_TRAN_START, 
                                                LOT.GetString("MAT_ID"), 
                                                LOT.GetInt("MAT_VER"), 
                                                LOT.GetString("FLOW"), 
                                                LOT.GetString("OPER"), 
                                                LOT.GetString("LOT_ID"), 
                                                "START_LOT", 
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
                
                if (DateTime.TryParseExact(MPCF.Trim(txtTranDateTime.Text), formatString, CultureInfo.InvariantCulture, DateTimeStyles.None, out backTime) == false)
                {
                    MPCF.ShowMsgBox("Check Tran Time");
                    return false;
                }
                in_node.AddString("BACK_TIME", MPCF.Trim(txtTranDateTime.Text));

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

                in_node.AddChar("NO_CHECK_QUEUE_TIME_FLAG", 'Y');
                in_node.AddChar("NO_START_WITH_SUBLOT_FLAG", chkNoStartWithSublot.Checked == true ? 'Y' : ' ');

                if (MPCR.CallService("WIP", "WIP_Start_Lot", in_node, ref out_node) == false)
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

        //
        // Check_Queue_Time()
        //       - Check Queue Time
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool CheckQueueTime(char ProcStep)
        {

            TRSNode in_node = new TRSNode("CHECK_QUEUE_TIME_IN");
            TRSNode out_node = new TRSNode("CHECK_QUEUE_TIME_OUT");
            DialogResult dr;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddChar("CHECK_POINT_FLAG", 'S');

                if (MPCR.CallService("WIP", "WIP_Check_Queue_Time", in_node, ref out_node, true) == false)
                {
                    if(out_node.MsgCode == "WIP-0302")
                    {
                        dr = MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, MPCF.GetMessage(58), out_node.DBErrMsg, out_node.FieldMsg), MessageBoxButtons.YesNoCancel, 1);
                        if (dr == System.Windows.Forms.DialogResult.No)
                        {
                            in_node.ProcStep = '2';
                            in_node.SetString("LOT_ID", MPCF.Trim(txtLotID.Text));

                            if (MessageCaster.CallService("WIP", "WIP_Check_Queue_Time", in_node, ref out_node) == false)
                            {
                                MPCF.ShowMsgBox(MPMH.StatusMessage);
                                return false;
                            }
                            if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                            {
                                if (MPCR.CheckContinueProc(out_node) == false)
                                {
                                    return false;
                                }
                            }
                        }
                        else if (dr == System.Windows.Forms.DialogResult.Cancel)
                        {
                            return false;
                        }

                    }
                    else
                    {
                        MPCR.CheckContinueProc(out_node);
                        return false;
                    }                    
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
                                               'S',
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

            frmChangePortCarrier.SetInformation(LOT.GetString("LOT_ID"), 
                                                LOT.GetString("LOT_DESC"), 
                                                LOT.GetString("MAT_ID"), 
                                                LOT.GetInt("MAT_VER"), 
                                                LOT.GetString("FLOW"), 
                                                LOT.GetString("OPER"), 
                                                cdvResID.Text, 
                                                'S', 
                                                "", 
                                                ref port_in, 
                                                ref crr_in);

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
                chkNoStartWithSublot.Checked = false;
                chkNoStartWithSublot.Visible = false;

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
                    chkNoStartWithSublot.Visible = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion
        
        private void frmWIPTranStartLotForIT_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    SetCMFItem(MPGC.MP_CMF_TRN_START);
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
                            ViewResource();
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
                            ViewResource();
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
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("START_LOT") == false) return;
                if (CheckQueueTime('1') == false) return;
                if (base.ViewLotInfo(txtLotID.Text, false) == false) return;

                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_START, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "START_LOT", 'B') == false) return;
                if (StartLot('1') == false) return;
                if (BASCore.BASCR.CheckListPopup(this, MPGC.MP_TRAN_CODE_START, LOT.GetString("LOT_ID"), MPCF.Trim(cdvResID.Text), "START_LOT", 'A') == false) return;

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
                cdvResID.RefuseEventExec = true;
                
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                txtLotID.Focus();
                return;
            }

            cdvResID.ListCond_Step = '2';
            cdvResID.ListCond_MatID = LOT.GetString("MAT_ID");
            cdvResID.ListCond_MatVersion = LOT.GetInt("MAT_VER");
            cdvResID.ListCond_Flow = LOT.GetString("FLOW");
            cdvResID.ListCond_Oper = LOT.GetString("OPER");
            cdvResID.ListCond_IncludeDeleteResource = false;
        }
        
        private void cdvResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvResID.Text != "")
            {
                if (ViewResource() == false)
                {
                    return;
                }
                MPCR.PopupInformNote(null, "", "", "", "", "", cdvResID.Text);
            }
            
        }

        private void cdvResID_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cdvResID.Text != "")
                {
                    if (ViewResource() == false)
                    {
                        return;
                    }
                }
            }
        }

        private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            if (cdvResID.Text == "")
            {
                InitResInfo();
            }
            
        }
        
        private void spdResInfo_Resize(object sender, System.EventArgs e)
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
    }
    
}
