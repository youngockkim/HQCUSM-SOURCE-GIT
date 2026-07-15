
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranEndBatch.vb
//   Description : End Batch
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetResourceIDList() :Get ResourceID List
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
    public class frmWIPTranEndBatch : Miracom.MESCore.TranForm11
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranEndBatch()
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
        



        protected System.Windows.Forms.TextBox txtBatchID;
        protected System.Windows.Forms.Label lblBatchID;
        protected System.Windows.Forms.TabControl tabTran;
        protected System.Windows.Forms.TabPage tbpGeneral;
        protected System.Windows.Forms.Panel pnlTranInfo;
        private System.Windows.Forms.GroupBox grpLotList;
        private System.Windows.Forms.GroupBox grpResInfo;
        private System.Windows.Forms.Panel pnlResInfoMain;
        private System.Windows.Forms.Panel pnlResIDMid;
        protected FarPoint.Win.Spread.FpSpread spdResInfo;
        private System.Windows.Forms.Panel pnlResID;
        protected System.Windows.Forms.Panel pnlTranTime;
        protected System.Windows.Forms.TextBox txtTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranTime;
        protected System.Windows.Forms.CheckBox chkTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        protected System.Windows.Forms.Panel pnlComment;
        protected System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.Label lblComment;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.Panel pnlCMF;
        protected FarPoint.Win.Spread.SheetView spdResInfo_LotInfo;
        private Miracom.UI.Controls.MCListView.MCListView lisLotListTemp;
        private System.Windows.Forms.ColumnHeader ColumnHeader97;
        private System.Windows.Forms.ColumnHeader ColumnHeader98;
        private System.Windows.Forms.ColumnHeader ColumnHeader99;
        private System.Windows.Forms.ColumnHeader ColumnHeader100;
        private System.Windows.Forms.ColumnHeader ColumnHeader101;
        private System.Windows.Forms.ColumnHeader ColumnHeader102;
        private System.Windows.Forms.ColumnHeader ColumnHeader103;
        private System.Windows.Forms.ColumnHeader ColumnHeader104;
        private System.Windows.Forms.ColumnHeader ColumnHeader105;
        private System.Windows.Forms.ColumnHeader ColumnHeader106;
        private System.Windows.Forms.ColumnHeader ColumnHeader107;
        private System.Windows.Forms.ColumnHeader ColumnHeader108;
        private System.Windows.Forms.ColumnHeader ColumnHeader109;
        private System.Windows.Forms.ColumnHeader ColumnHeader110;
        private System.Windows.Forms.ColumnHeader ColumnHeader111;
        private System.Windows.Forms.ColumnHeader ColumnHeader112;
        private System.Windows.Forms.ColumnHeader ColumnHeader113;
        private System.Windows.Forms.ColumnHeader ColumnHeader114;
        private System.Windows.Forms.ColumnHeader ColumnHeader115;
        private System.Windows.Forms.ColumnHeader ColumnHeader116;
        private System.Windows.Forms.ColumnHeader ColumnHeader117;
        private System.Windows.Forms.ColumnHeader ColumnHeader118;
        private System.Windows.Forms.ColumnHeader ColumnHeader119;
        private System.Windows.Forms.ColumnHeader ColumnHeader120;
        private System.Windows.Forms.ColumnHeader ColumnHeader121;
        private System.Windows.Forms.ColumnHeader ColumnHeader122;
        private System.Windows.Forms.ColumnHeader ColumnHeader123;
        private System.Windows.Forms.ColumnHeader ColumnHeader124;
        private System.Windows.Forms.ColumnHeader ColumnHeader125;
        private System.Windows.Forms.ColumnHeader ColumnHeader126;
        private System.Windows.Forms.ColumnHeader ColumnHeader127;
        private System.Windows.Forms.ColumnHeader ColumnHeader128;
        private System.Windows.Forms.ColumnHeader ColumnHeader129;
        private System.Windows.Forms.ColumnHeader ColumnHeader130;
        private System.Windows.Forms.ColumnHeader ColumnHeader131;
        private System.Windows.Forms.ColumnHeader ColumnHeader132;
        private System.Windows.Forms.ColumnHeader ColumnHeader133;
        private System.Windows.Forms.ColumnHeader ColumnHeader134;
        private System.Windows.Forms.ColumnHeader ColumnHeader135;
        private System.Windows.Forms.ColumnHeader ColumnHeader136;
        private System.Windows.Forms.ColumnHeader ColumnHeader137;
        private System.Windows.Forms.ColumnHeader ColumnHeader138;
        private System.Windows.Forms.ColumnHeader ColumnHeader139;
        private System.Windows.Forms.ColumnHeader ColumnHeader140;
        private System.Windows.Forms.ColumnHeader ColumnHeader141;
        private System.Windows.Forms.ColumnHeader ColumnHeader142;
        private System.Windows.Forms.ColumnHeader ColumnHeader143;
        private System.Windows.Forms.ColumnHeader ColumnHeader144;
        private System.Windows.Forms.ColumnHeader ColumnHeader145;
        private System.Windows.Forms.ColumnHeader ColumnHeader146;
        private System.Windows.Forms.ColumnHeader ColumnHeader147;
        private System.Windows.Forms.ColumnHeader ColumnHeader148;
        private System.Windows.Forms.ColumnHeader ColumnHeader149;
        private System.Windows.Forms.ColumnHeader ColumnHeader150;
        private System.Windows.Forms.ColumnHeader ColumnHeader151;
        private System.Windows.Forms.ColumnHeader ColumnHeader152;
        private System.Windows.Forms.ColumnHeader ColumnHeader153;
        private System.Windows.Forms.ColumnHeader ColumnHeader154;
        private System.Windows.Forms.ColumnHeader ColumnHeader155;
        private System.Windows.Forms.ColumnHeader ColumnHeader156;
        private System.Windows.Forms.ColumnHeader ColumnHeader157;
        private System.Windows.Forms.ColumnHeader ColumnHeader158;
        private System.Windows.Forms.ColumnHeader ColumnHeader159;
        private System.Windows.Forms.ColumnHeader ColumnHeader160;
        private System.Windows.Forms.ColumnHeader ColumnHeader161;
        private System.Windows.Forms.ColumnHeader ColumnHeader162;
        private System.Windows.Forms.ColumnHeader ColumnHeader163;
        private System.Windows.Forms.ColumnHeader ColumnHeader164;
        private System.Windows.Forms.ColumnHeader ColumnHeader165;
        private System.Windows.Forms.ColumnHeader ColumnHeader166;
        private System.Windows.Forms.ColumnHeader ColumnHeader167;
        private System.Windows.Forms.ColumnHeader ColumnHeader168;
        private System.Windows.Forms.ColumnHeader ColumnHeader169;
        private System.Windows.Forms.ColumnHeader ColumnHeader170;
        private System.Windows.Forms.ColumnHeader ColumnHeader171;
        private System.Windows.Forms.ColumnHeader ColumnHeader172;
        private System.Windows.Forms.ColumnHeader ColumnHeader173;
        private System.Windows.Forms.ColumnHeader ColumnHeader174;
        private System.Windows.Forms.ColumnHeader ColumnHeader175;
        private System.Windows.Forms.ColumnHeader ColumnHeader176;
        private System.Windows.Forms.ColumnHeader ColumnHeader177;
        private System.Windows.Forms.ColumnHeader ColumnHeader178;
        private System.Windows.Forms.ColumnHeader ColumnHeader179;
        private System.Windows.Forms.ColumnHeader ColumnHeader180;
        private System.Windows.Forms.ColumnHeader ColumnHeader181;
        private System.Windows.Forms.ColumnHeader ColumnHeader182;
        private System.Windows.Forms.ColumnHeader ColumnHeader183;
        private System.Windows.Forms.ColumnHeader ColumnHeader184;
        private System.Windows.Forms.ColumnHeader ColumnHeader185;
        private System.Windows.Forms.ColumnHeader ColumnHeader186;
        private System.Windows.Forms.ColumnHeader ColumnHeader187;
        private System.Windows.Forms.ColumnHeader ColumnHeader188;
        private System.Windows.Forms.ColumnHeader ColumnHeader189;
        private System.Windows.Forms.ColumnHeader ColumnHeader190;
        private System.Windows.Forms.ColumnHeader ColumnHeader191;
        private ColumnHeader columnHeader195;
        private ColumnHeader columnHeader196;
        protected GroupBox grpCMF;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF19;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF18;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF17;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF16;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF15;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF14;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF13;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF12;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF20;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF11;
        protected Label lblCMF20;
        protected Label lblCMF19;
        protected Label lblCMF18;
        protected Label lblCMF17;
        protected Label lblCMF16;
        protected Label lblCMF15;
        protected Label lblCMF14;
        protected Label lblCMF13;
        protected Label lblCMF12;
        protected Label lblCMF11;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        protected Label lblCMF10;
        protected Label lblCMF9;
        protected Label lblCMF8;
        protected Label lblCMF7;
        protected Label lblCMF6;
        protected Label lblCMF5;
        protected Label lblCMF4;
        protected Label lblCMF3;
        protected Label lblCMF2;
        protected Label lblCMF1;
        private Miracom.UI.Controls.MCListView.MCListView lisLotList;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader colMatVersion;
        private ColumnHeader columnHeader4;
        private ColumnHeader colFlowSeq;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader23;
        private ColumnHeader columnHeader24;
        private ColumnHeader columnHeader25;
        private ColumnHeader columnHeader26;
        private ColumnHeader columnHeader27;
        private ColumnHeader columnHeader28;
        private ColumnHeader columnHeader29;
        private ColumnHeader columnHeader30;
        private ColumnHeader columnHeader31;
        private ColumnHeader columnHeader32;
        private ColumnHeader columnHeader33;
        private ColumnHeader columnHeader34;
        private ColumnHeader columnHeader35;
        private ColumnHeader columnHeader36;
        private ColumnHeader columnHeader37;
        private ColumnHeader columnHeader38;
        private ColumnHeader colRepFlag;
        private ColumnHeader colRepOper;
        private ColumnHeader colStrRetFlow;
        private ColumnHeader colStrRetFlowSeq;
        private ColumnHeader colStrRetOper;
        private ColumnHeader columnHeader39;
        private ColumnHeader columnHeader40;
        private ColumnHeader columnHeader41;
        private ColumnHeader columnHeader42;
        private ColumnHeader columnHeader43;
        private ColumnHeader columnHeader44;
        private ColumnHeader columnHeader45;
        private ColumnHeader columnHeader46;
        private ColumnHeader columnHeader47;
        private ColumnHeader columnHeader48;
        private ColumnHeader columnHeader49;
        private ColumnHeader columnHeader50;
        private ColumnHeader columnHeader51;
        private ColumnHeader columnHeader52;
        private ColumnHeader columnHeader53;
        private ColumnHeader columnHeader54;
        private ColumnHeader columnHeader55;
        private ColumnHeader columnHeader56;
        private ColumnHeader columnHeader57;
        private ColumnHeader columnHeader58;
        private ColumnHeader columnHeader59;
        private ColumnHeader columnHeader60;
        private ColumnHeader columnHeader61;
        private ColumnHeader columnHeader62;
        private ColumnHeader columnHeader63;
        private ColumnHeader columnHeader64;
        private ColumnHeader columnHeader65;
        private ColumnHeader columnHeader66;
        private ColumnHeader columnHeader67;
        private ColumnHeader columnHeader68;
        private ColumnHeader columnHeader69;
        private ColumnHeader columnHeader70;
        private ColumnHeader columnHeader71;
        private ColumnHeader columnHeader72;
        private ColumnHeader columnHeader73;
        private ColumnHeader columnHeader74;
        private ColumnHeader columnHeader75;
        private ColumnHeader columnHeader76;
        private ColumnHeader columnHeader77;
        private ColumnHeader columnHeader78;
        private ColumnHeader columnHeader79;
        private ColumnHeader columnHeader80;
        private ColumnHeader columnHeader81;
        private ColumnHeader columnHeader82;
        private ColumnHeader columnHeader83;
        private ColumnHeader columnHeader84;
        private ColumnHeader columnHeader85;
        private ColumnHeader columnHeader86;
        private ColumnHeader columnHeader87;
        private ColumnHeader columnHeader88;
        private ColumnHeader columnHeader89;
        private ColumnHeader columnHeader90;
        private ColumnHeader columnHeader91;
        private ColumnHeader columnHeader92;
        private ColumnHeader columnHeader93;
        private ColumnHeader columnHeader94;
        private ColumnHeader columnHeader95;
        private ColumnHeader columnHeader96;
        private Button btnView;
        protected TextBox txtLotID;
        protected Label lblLotID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPortID;
        private Label lblPortID;
        private System.Windows.Forms.ColumnHeader ColumnHeader192;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
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
            this.txtBatchID = new System.Windows.Forms.TextBox();
            this.lblBatchID = new System.Windows.Forms.Label();
            this.tabTran = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlTranInfo = new System.Windows.Forms.Panel();
            this.grpLotList = new System.Windows.Forms.GroupBox();
            this.lisLotList = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRepFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRepOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStrRetFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStrRetFlowSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStrRetOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader56 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader57 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader58 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader59 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader60 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader61 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader62 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader63 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader64 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader65 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader66 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader67 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader68 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader69 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader70 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader71 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader72 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader73 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader74 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader75 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader76 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader77 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader78 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader79 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader80 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader81 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader82 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader83 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader84 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader85 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader86 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader87 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader88 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader89 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader90 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader91 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader92 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader93 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader94 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader95 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader96 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lisLotListTemp = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader97 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader98 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader99 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader100 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader101 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader102 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader103 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader104 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader105 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader106 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader107 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader108 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader109 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader110 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader111 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader112 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader113 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader114 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader115 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader116 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader117 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader118 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader119 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader120 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader121 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader122 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader123 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader124 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader125 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader126 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader127 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader128 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader129 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader130 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader131 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader132 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader133 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader134 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader135 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader136 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader137 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader138 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader139 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader140 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader141 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader142 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader143 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader144 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader145 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader146 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader147 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader148 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader149 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader150 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader151 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader152 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader153 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader154 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader155 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader156 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader157 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader158 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader159 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader160 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader161 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader162 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader163 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader164 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader165 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader166 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader167 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader168 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader169 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader170 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader171 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader172 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader173 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader174 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader175 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader176 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader177 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader178 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader179 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader180 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader181 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader182 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader183 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader184 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader185 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader186 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader187 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader188 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader189 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader190 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader191 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader192 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader195 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader196 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpResInfo = new System.Windows.Forms.GroupBox();
            this.pnlResInfoMain = new System.Windows.Forms.Panel();
            this.pnlResIDMid = new System.Windows.Forms.Panel();
            this.spdResInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdResInfo_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.pnlResID = new System.Windows.Forms.Panel();
            this.cdvPortID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPortID = new System.Windows.Forms.Label();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranDateTime = new System.Windows.Forms.TextBox();
            this.dtpTranTime = new System.Windows.Forms.DateTimePicker();
            this.chkTranDateTime = new System.Windows.Forms.CheckBox();
            this.dtpTranDate = new System.Windows.Forms.DateTimePicker();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.pnlCMF = new System.Windows.Forms.Panel();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvCMF19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF20 = new System.Windows.Forms.Label();
            this.lblCMF19 = new System.Windows.Forms.Label();
            this.lblCMF18 = new System.Windows.Forms.Label();
            this.lblCMF17 = new System.Windows.Forms.Label();
            this.lblCMF16 = new System.Windows.Forms.Label();
            this.lblCMF15 = new System.Windows.Forms.Label();
            this.lblCMF14 = new System.Windows.Forms.Label();
            this.lblCMF13 = new System.Windows.Forms.Label();
            this.lblCMF12 = new System.Windows.Forms.Label();
            this.lblCMF11 = new System.Windows.Forms.Label();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.grpLotList.SuspendLayout();
            this.grpResInfo.SuspendLayout();
            this.pnlResInfoMain.SuspendLayout();
            this.pnlResIDMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).BeginInit();
            this.pnlResID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPortID)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.pnlCMF.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(742, 44);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.tabTran);
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 44);
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 469);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.btnView);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            this.grpOption.Controls.Add(this.txtBatchID);
            this.grpOption.Controls.Add(this.lblBatchID);
            this.grpOption.Size = new System.Drawing.Size(736, 44);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
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
            this.lblFormTitle.Text = "End Batch";
            // 
            // txtBatchID
            // 
            this.txtBatchID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtBatchID.Location = new System.Drawing.Point(102, 16);
            this.txtBatchID.MaxLength = 25;
            this.txtBatchID.Name = "txtBatchID";
            this.txtBatchID.Size = new System.Drawing.Size(200, 20);
            this.txtBatchID.TabIndex = 1;
            this.txtBatchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchID_KeyPress);
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchID.Location = new System.Drawing.Point(22, 20);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(57, 13);
            this.lblBatchID.TabIndex = 0;
            this.lblBatchID.Text = "Batch ID";
            this.lblBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpGeneral);
            this.tabTran.Controls.Add(this.tbpCMF);
            this.tabTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTran.ItemSize = new System.Drawing.Size(60, 18);
            this.tabTran.Location = new System.Drawing.Point(3, 3);
            this.tabTran.Name = "tabTran";
            this.tabTran.SelectedIndex = 0;
            this.tabTran.Size = new System.Drawing.Size(736, 466);
            this.tabTran.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlTranInfo);
            this.tbpGeneral.Controls.Add(this.pnlComment);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(728, 440);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.grpLotList);
            this.pnlTranInfo.Controls.Add(this.grpResInfo);
            this.pnlTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlTranInfo.Name = "pnlTranInfo";
            this.pnlTranInfo.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 399);
            this.pnlTranInfo.TabIndex = 0;
            // 
            // grpLotList
            // 
            this.grpLotList.Controls.Add(this.lisLotList);
            this.grpLotList.Controls.Add(this.lisLotListTemp);
            this.grpLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotList.Location = new System.Drawing.Point(3, 3);
            this.grpLotList.Name = "grpLotList";
            this.grpLotList.Size = new System.Drawing.Size(722, 222);
            this.grpLotList.TabIndex = 0;
            this.grpLotList.TabStop = false;
            this.grpLotList.Text = "Lot List";
            // 
            // lisLotList
            // 
            this.lisLotList.AllowColumnReorder = true;
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.colMatVersion,
            this.columnHeader4,
            this.colFlowSeq,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader33,
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38,
            this.colRepFlag,
            this.colRepOper,
            this.colStrRetFlow,
            this.colStrRetFlowSeq,
            this.colStrRetOper,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader41,
            this.columnHeader42,
            this.columnHeader43,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader48,
            this.columnHeader49,
            this.columnHeader50,
            this.columnHeader51,
            this.columnHeader52,
            this.columnHeader53,
            this.columnHeader54,
            this.columnHeader55,
            this.columnHeader56,
            this.columnHeader57,
            this.columnHeader58,
            this.columnHeader59,
            this.columnHeader60,
            this.columnHeader61,
            this.columnHeader62,
            this.columnHeader63,
            this.columnHeader64,
            this.columnHeader65,
            this.columnHeader66,
            this.columnHeader67,
            this.columnHeader68,
            this.columnHeader69,
            this.columnHeader70,
            this.columnHeader71,
            this.columnHeader72,
            this.columnHeader73,
            this.columnHeader74,
            this.columnHeader75,
            this.columnHeader76,
            this.columnHeader77,
            this.columnHeader78,
            this.columnHeader79,
            this.columnHeader80,
            this.columnHeader81,
            this.columnHeader82,
            this.columnHeader83,
            this.columnHeader84,
            this.columnHeader85,
            this.columnHeader86,
            this.columnHeader87,
            this.columnHeader88,
            this.columnHeader89,
            this.columnHeader90,
            this.columnHeader91,
            this.columnHeader92,
            this.columnHeader93,
            this.columnHeader94,
            this.columnHeader95,
            this.columnHeader96});
            this.lisLotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotList.EnableSort = true;
            this.lisLotList.EnableSortIcon = true;
            this.lisLotList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLotList.FullRowSelect = true;
            this.lisLotList.Location = new System.Drawing.Point(3, 16);
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(716, 203);
            this.lisLotList.TabIndex = 0;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Seq";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Lot ID";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Material";
            this.columnHeader3.Width = 100;
            // 
            // colMatVersion
            // 
            this.colMatVersion.Text = "Mat Ver";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Flow";
            this.columnHeader4.Width = 90;
            // 
            // colFlowSeq
            // 
            this.colFlowSeq.Text = "Flow Seq";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Operation";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Qty 1";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Qty 2";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Qty3";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Lot Type";
            this.columnHeader9.Width = 70;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Owner Code";
            this.columnHeader10.Width = 90;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Create Code";
            this.columnHeader11.Width = 90;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Priority";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Lot Status";
            this.columnHeader13.Width = 80;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Hold Flag";
            this.columnHeader14.Width = 80;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Hold Code";
            this.columnHeader15.Width = 80;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Create Qty 1";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader16.Width = 100;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Create Qty 2";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader17.Width = 100;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Create Qty 3";
            this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader18.Width = 100;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Oper In Qty 1";
            this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader19.Width = 100;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Oper In Qty 2";
            this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader20.Width = 100;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Oper In Qty 3";
            this.columnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader21.Width = 100;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Inventory Flag";
            this.columnHeader22.Width = 100;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Transit Flag";
            this.columnHeader23.Width = 100;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Unit Exist Flag";
            this.columnHeader24.Width = 100;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Inv Unit";
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Rework Flag";
            this.columnHeader26.Width = 120;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Rework Code";
            this.columnHeader27.Width = 120;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Rework Count";
            this.columnHeader28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader28.Width = 120;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "Rework Ret Flow";
            this.columnHeader29.Width = 120;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Rework Ret Oper";
            this.columnHeader30.Width = 120;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Rework End Flow";
            this.columnHeader31.Width = 120;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "Rework End Oper";
            this.columnHeader32.Width = 120;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "Rework Ret Clear Flag";
            this.columnHeader33.Width = 155;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Rework Time";
            this.columnHeader34.Width = 120;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "NSTD Flag";
            this.columnHeader35.Width = 120;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "NSTD Ret Flow";
            this.columnHeader36.Width = 120;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "NSTD Ret Oper";
            this.columnHeader37.Width = 120;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "NSTD Time";
            this.columnHeader38.Width = 120;
            // 
            // colRepFlag
            // 
            this.colRepFlag.Text = "Repair Flag";
            this.colRepFlag.Width = 100;
            // 
            // colRepOper
            // 
            this.colRepOper.Text = "Repair Return Oper";
            this.colRepOper.Width = 120;
            // 
            // colStrRetFlow
            // 
            this.colStrRetFlow.Text = "Store Return Flow";
            this.colStrRetFlow.Width = 120;
            // 
            // colStrRetFlowSeq
            // 
            this.colStrRetFlowSeq.Text = "Store Return Flow Seq";
            this.colStrRetFlowSeq.Width = 120;
            // 
            // colStrRetOper
            // 
            this.colStrRetOper.Text = "Store Return Oper";
            this.colStrRetOper.Width = 120;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "Start Flag";
            this.columnHeader39.Width = 70;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "Start Time";
            this.columnHeader40.Width = 120;
            // 
            // columnHeader41
            // 
            this.columnHeader41.Text = "Start Res ID";
            this.columnHeader41.Width = 80;
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "End Flag";
            this.columnHeader42.Width = 70;
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "End Time";
            this.columnHeader43.Width = 120;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "End Res ID";
            this.columnHeader44.Width = 80;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "Sample Flag";
            this.columnHeader45.Width = 100;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "Sample Wait Flag";
            this.columnHeader46.Width = 110;
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "Sample Result";
            this.columnHeader47.Width = 100;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Text = "From To Lot ID";
            this.columnHeader48.Width = 120;
            // 
            // columnHeader49
            // 
            this.columnHeader49.Text = "Ship Code";
            this.columnHeader49.Width = 80;
            // 
            // columnHeader50
            // 
            this.columnHeader50.Text = "Ship Time";
            this.columnHeader50.Width = 120;
            // 
            // columnHeader51
            // 
            this.columnHeader51.Text = "Original Due Time";
            this.columnHeader51.Width = 120;
            // 
            // columnHeader52
            // 
            this.columnHeader52.Text = "Scheduled Due Time";
            this.columnHeader52.Width = 145;
            // 
            // columnHeader53
            // 
            this.columnHeader53.Text = "Create Time";
            this.columnHeader53.Width = 120;
            // 
            // columnHeader54
            // 
            this.columnHeader54.Text = "Factory In Time";
            this.columnHeader54.Width = 120;
            // 
            // columnHeader55
            // 
            this.columnHeader55.Text = "Flow In Time";
            this.columnHeader55.Width = 120;
            // 
            // columnHeader56
            // 
            this.columnHeader56.Text = "Oper In Time";
            this.columnHeader56.Width = 120;
            // 
            // columnHeader57
            // 
            this.columnHeader57.Text = "Reserve Res ID";
            this.columnHeader57.Width = 120;
            // 
            // columnHeader58
            // 
            this.columnHeader58.Text = "Batch ID";
            // 
            // columnHeader59
            // 
            this.columnHeader59.Text = "Batch Seq";
            this.columnHeader59.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader59.Width = 70;
            // 
            // columnHeader60
            // 
            this.columnHeader60.Text = "Order ID";
            this.columnHeader60.Width = 100;
            // 
            // columnHeader61
            // 
            this.columnHeader61.Text = "Add Order ID 1";
            this.columnHeader61.Width = 100;
            // 
            // columnHeader62
            // 
            this.columnHeader62.Text = "Add Order ID 2";
            this.columnHeader62.Width = 100;
            // 
            // columnHeader63
            // 
            this.columnHeader63.Text = "Add Order ID 3";
            this.columnHeader63.Width = 100;
            // 
            // columnHeader64
            // 
            this.columnHeader64.Text = "Location";
            this.columnHeader64.Width = 80;
            // 
            // columnHeader65
            // 
            this.columnHeader65.Text = "Lot Cmf 1";
            this.columnHeader65.Width = 100;
            // 
            // columnHeader66
            // 
            this.columnHeader66.Text = "Lot Cmf 2";
            this.columnHeader66.Width = 100;
            // 
            // columnHeader67
            // 
            this.columnHeader67.Text = "Lot Cmf 3";
            this.columnHeader67.Width = 100;
            // 
            // columnHeader68
            // 
            this.columnHeader68.Text = "Lot Cmf 4";
            this.columnHeader68.Width = 100;
            // 
            // columnHeader69
            // 
            this.columnHeader69.Text = "Lot Cmf 5";
            this.columnHeader69.Width = 100;
            // 
            // columnHeader70
            // 
            this.columnHeader70.Text = "Lot Cmf 6";
            this.columnHeader70.Width = 100;
            // 
            // columnHeader71
            // 
            this.columnHeader71.Text = "Lot Cmf 7";
            this.columnHeader71.Width = 100;
            // 
            // columnHeader72
            // 
            this.columnHeader72.Text = "Lot Cmf 8";
            this.columnHeader72.Width = 100;
            // 
            // columnHeader73
            // 
            this.columnHeader73.Text = "Lot Cmf 9";
            this.columnHeader73.Width = 100;
            // 
            // columnHeader74
            // 
            this.columnHeader74.Text = "Lot Cmf 10";
            this.columnHeader74.Width = 100;
            // 
            // columnHeader75
            // 
            this.columnHeader75.Text = "Lot Cmf 11";
            this.columnHeader75.Width = 100;
            // 
            // columnHeader76
            // 
            this.columnHeader76.Text = "Lot Cmf 12";
            this.columnHeader76.Width = 100;
            // 
            // columnHeader77
            // 
            this.columnHeader77.Text = "Lot Cmf 13";
            this.columnHeader77.Width = 100;
            // 
            // columnHeader78
            // 
            this.columnHeader78.Text = "Lot Cmf 14";
            this.columnHeader78.Width = 100;
            // 
            // columnHeader79
            // 
            this.columnHeader79.Text = "Lot Cmf 15";
            this.columnHeader79.Width = 100;
            // 
            // columnHeader80
            // 
            this.columnHeader80.Text = "Lot Cmf 16";
            this.columnHeader80.Width = 100;
            // 
            // columnHeader81
            // 
            this.columnHeader81.Text = "Lot Cmf 17";
            this.columnHeader81.Width = 100;
            // 
            // columnHeader82
            // 
            this.columnHeader82.Text = "Lot Cmf 18";
            this.columnHeader82.Width = 100;
            // 
            // columnHeader83
            // 
            this.columnHeader83.Text = "Lot Cmf 19";
            this.columnHeader83.Width = 100;
            // 
            // columnHeader84
            // 
            this.columnHeader84.Text = "Lot Cmf 20";
            this.columnHeader84.Width = 100;
            // 
            // columnHeader85
            // 
            this.columnHeader85.Text = "BOM Set ID";
            this.columnHeader85.Width = 100;
            // 
            // columnHeader86
            // 
            this.columnHeader86.Text = "BOM Set Version";
            this.columnHeader86.Width = 120;
            // 
            // columnHeader87
            // 
            this.columnHeader87.Text = "BOM Act Hist Seq";
            this.columnHeader87.Width = 120;
            // 
            // columnHeader88
            // 
            this.columnHeader88.Text = "BOM Hist Seq";
            this.columnHeader88.Width = 100;
            // 
            // columnHeader89
            // 
            this.columnHeader89.Text = "Lot Delete Flag";
            this.columnHeader89.Width = 100;
            // 
            // columnHeader90
            // 
            this.columnHeader90.Text = "Lot Delete Time";
            this.columnHeader90.Width = 120;
            // 
            // columnHeader91
            // 
            this.columnHeader91.Text = "Lot Delete Reason";
            this.columnHeader91.Width = 150;
            // 
            // columnHeader92
            // 
            this.columnHeader92.Text = "Last Trans Code";
            this.columnHeader92.Width = 120;
            // 
            // columnHeader93
            // 
            this.columnHeader93.Text = "Last Trans Time";
            this.columnHeader93.Width = 120;
            // 
            // columnHeader94
            // 
            this.columnHeader94.Text = "Last Comment";
            this.columnHeader94.Width = 200;
            // 
            // columnHeader95
            // 
            this.columnHeader95.Text = "Last Active Hist Seq";
            this.columnHeader95.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader95.Width = 140;
            // 
            // columnHeader96
            // 
            this.columnHeader96.Text = "Last Hist Seq";
            this.columnHeader96.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader96.Width = 120;
            // 
            // lisLotListTemp
            // 
            this.lisLotListTemp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader97,
            this.ColumnHeader98,
            this.ColumnHeader99,
            this.ColumnHeader100,
            this.ColumnHeader101,
            this.ColumnHeader102,
            this.ColumnHeader103,
            this.ColumnHeader104,
            this.ColumnHeader105,
            this.ColumnHeader106,
            this.ColumnHeader107,
            this.ColumnHeader108,
            this.ColumnHeader109,
            this.ColumnHeader110,
            this.ColumnHeader111,
            this.ColumnHeader112,
            this.ColumnHeader113,
            this.ColumnHeader114,
            this.ColumnHeader115,
            this.ColumnHeader116,
            this.ColumnHeader117,
            this.ColumnHeader118,
            this.ColumnHeader119,
            this.ColumnHeader120,
            this.ColumnHeader121,
            this.ColumnHeader122,
            this.ColumnHeader123,
            this.ColumnHeader124,
            this.ColumnHeader125,
            this.ColumnHeader126,
            this.ColumnHeader127,
            this.ColumnHeader128,
            this.ColumnHeader129,
            this.ColumnHeader130,
            this.ColumnHeader131,
            this.ColumnHeader132,
            this.ColumnHeader133,
            this.ColumnHeader134,
            this.ColumnHeader135,
            this.ColumnHeader136,
            this.ColumnHeader137,
            this.ColumnHeader138,
            this.ColumnHeader139,
            this.ColumnHeader140,
            this.ColumnHeader141,
            this.ColumnHeader142,
            this.ColumnHeader143,
            this.ColumnHeader144,
            this.ColumnHeader145,
            this.ColumnHeader146,
            this.ColumnHeader147,
            this.ColumnHeader148,
            this.ColumnHeader149,
            this.ColumnHeader150,
            this.ColumnHeader151,
            this.ColumnHeader152,
            this.ColumnHeader153,
            this.ColumnHeader154,
            this.ColumnHeader155,
            this.ColumnHeader156,
            this.ColumnHeader157,
            this.ColumnHeader158,
            this.ColumnHeader159,
            this.ColumnHeader160,
            this.ColumnHeader161,
            this.ColumnHeader162,
            this.ColumnHeader163,
            this.ColumnHeader164,
            this.ColumnHeader165,
            this.ColumnHeader166,
            this.ColumnHeader167,
            this.ColumnHeader168,
            this.ColumnHeader169,
            this.ColumnHeader170,
            this.ColumnHeader171,
            this.ColumnHeader172,
            this.ColumnHeader173,
            this.ColumnHeader174,
            this.ColumnHeader175,
            this.ColumnHeader176,
            this.ColumnHeader177,
            this.ColumnHeader178,
            this.ColumnHeader179,
            this.ColumnHeader180,
            this.ColumnHeader181,
            this.ColumnHeader182,
            this.ColumnHeader183,
            this.ColumnHeader184,
            this.ColumnHeader185,
            this.ColumnHeader186,
            this.ColumnHeader187,
            this.ColumnHeader188,
            this.ColumnHeader189,
            this.ColumnHeader190,
            this.ColumnHeader191,
            this.ColumnHeader192,
            this.columnHeader195,
            this.columnHeader196});
            this.lisLotListTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLotListTemp.EnableSort = true;
            this.lisLotListTemp.EnableSortIcon = true;
            this.lisLotListTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLotListTemp.FullRowSelect = true;
            this.lisLotListTemp.Location = new System.Drawing.Point(3, 16);
            this.lisLotListTemp.MultiSelect = false;
            this.lisLotListTemp.Name = "lisLotListTemp";
            this.lisLotListTemp.Size = new System.Drawing.Size(716, 203);
            this.lisLotListTemp.TabIndex = 1;
            this.lisLotListTemp.UseCompatibleStateImageBehavior = false;
            this.lisLotListTemp.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader97
            // 
            this.ColumnHeader97.Text = "Seq";
            this.ColumnHeader97.Width = 40;
            // 
            // ColumnHeader98
            // 
            this.ColumnHeader98.Text = "Lot ID";
            this.ColumnHeader98.Width = 120;
            // 
            // ColumnHeader99
            // 
            this.ColumnHeader99.Text = "Material";
            this.ColumnHeader99.Width = 100;
            // 
            // ColumnHeader100
            // 
            this.ColumnHeader100.DisplayIndex = 4;
            this.ColumnHeader100.Text = "Flow";
            this.ColumnHeader100.Width = 90;
            // 
            // ColumnHeader101
            // 
            this.ColumnHeader101.DisplayIndex = 6;
            this.ColumnHeader101.Text = "Operation";
            this.ColumnHeader101.Width = 80;
            // 
            // ColumnHeader102
            // 
            this.ColumnHeader102.DisplayIndex = 7;
            this.ColumnHeader102.Text = "Qty 1";
            this.ColumnHeader102.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader103
            // 
            this.ColumnHeader103.DisplayIndex = 8;
            this.ColumnHeader103.Text = "Qty 2";
            this.ColumnHeader103.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader104
            // 
            this.ColumnHeader104.DisplayIndex = 9;
            this.ColumnHeader104.Text = "Qty3";
            this.ColumnHeader104.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader105
            // 
            this.ColumnHeader105.DisplayIndex = 10;
            this.ColumnHeader105.Text = "Lot Type";
            this.ColumnHeader105.Width = 70;
            // 
            // ColumnHeader106
            // 
            this.ColumnHeader106.DisplayIndex = 11;
            this.ColumnHeader106.Text = "Owner Code";
            this.ColumnHeader106.Width = 90;
            // 
            // ColumnHeader107
            // 
            this.ColumnHeader107.DisplayIndex = 12;
            this.ColumnHeader107.Text = "Create Code";
            this.ColumnHeader107.Width = 90;
            // 
            // ColumnHeader108
            // 
            this.ColumnHeader108.DisplayIndex = 13;
            this.ColumnHeader108.Text = "Priority";
            // 
            // ColumnHeader109
            // 
            this.ColumnHeader109.DisplayIndex = 14;
            this.ColumnHeader109.Text = "Lot Status";
            this.ColumnHeader109.Width = 80;
            // 
            // ColumnHeader110
            // 
            this.ColumnHeader110.DisplayIndex = 15;
            this.ColumnHeader110.Text = "Hold Flag";
            this.ColumnHeader110.Width = 80;
            // 
            // ColumnHeader111
            // 
            this.ColumnHeader111.DisplayIndex = 16;
            this.ColumnHeader111.Text = "Hold Code";
            this.ColumnHeader111.Width = 80;
            // 
            // ColumnHeader112
            // 
            this.ColumnHeader112.DisplayIndex = 17;
            this.ColumnHeader112.Text = "Create Qty 1";
            this.ColumnHeader112.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader112.Width = 100;
            // 
            // ColumnHeader113
            // 
            this.ColumnHeader113.DisplayIndex = 18;
            this.ColumnHeader113.Text = "Create Qty 2";
            this.ColumnHeader113.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader113.Width = 100;
            // 
            // ColumnHeader114
            // 
            this.ColumnHeader114.DisplayIndex = 19;
            this.ColumnHeader114.Text = "Create Qty 3";
            this.ColumnHeader114.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader114.Width = 100;
            // 
            // ColumnHeader115
            // 
            this.ColumnHeader115.DisplayIndex = 20;
            this.ColumnHeader115.Text = "Oper In Qty 1";
            this.ColumnHeader115.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader115.Width = 100;
            // 
            // ColumnHeader116
            // 
            this.ColumnHeader116.DisplayIndex = 21;
            this.ColumnHeader116.Text = "Oper In Qty 2";
            this.ColumnHeader116.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader116.Width = 100;
            // 
            // ColumnHeader117
            // 
            this.ColumnHeader117.DisplayIndex = 22;
            this.ColumnHeader117.Text = "Oper In Qty 3";
            this.ColumnHeader117.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader117.Width = 100;
            // 
            // ColumnHeader118
            // 
            this.ColumnHeader118.DisplayIndex = 23;
            this.ColumnHeader118.Text = "Inventory Flag";
            this.ColumnHeader118.Width = 100;
            // 
            // ColumnHeader119
            // 
            this.ColumnHeader119.DisplayIndex = 24;
            this.ColumnHeader119.Text = "Transit Flag";
            this.ColumnHeader119.Width = 100;
            // 
            // ColumnHeader120
            // 
            this.ColumnHeader120.DisplayIndex = 25;
            this.ColumnHeader120.Text = "Unit Exist Flag";
            this.ColumnHeader120.Width = 100;
            // 
            // ColumnHeader121
            // 
            this.ColumnHeader121.DisplayIndex = 26;
            this.ColumnHeader121.Text = "Inv Unit";
            // 
            // ColumnHeader122
            // 
            this.ColumnHeader122.DisplayIndex = 27;
            this.ColumnHeader122.Text = "Rework Flag";
            this.ColumnHeader122.Width = 120;
            // 
            // ColumnHeader123
            // 
            this.ColumnHeader123.DisplayIndex = 28;
            this.ColumnHeader123.Text = "Rework Code";
            this.ColumnHeader123.Width = 120;
            // 
            // ColumnHeader124
            // 
            this.ColumnHeader124.DisplayIndex = 29;
            this.ColumnHeader124.Text = "Rework Count";
            this.ColumnHeader124.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader124.Width = 120;
            // 
            // ColumnHeader125
            // 
            this.ColumnHeader125.DisplayIndex = 30;
            this.ColumnHeader125.Text = "Rework Ret Flow";
            this.ColumnHeader125.Width = 120;
            // 
            // ColumnHeader126
            // 
            this.ColumnHeader126.DisplayIndex = 31;
            this.ColumnHeader126.Text = "Rework Ret Oper";
            this.ColumnHeader126.Width = 120;
            // 
            // ColumnHeader127
            // 
            this.ColumnHeader127.DisplayIndex = 32;
            this.ColumnHeader127.Text = "Rework End Flow";
            this.ColumnHeader127.Width = 120;
            // 
            // ColumnHeader128
            // 
            this.ColumnHeader128.DisplayIndex = 33;
            this.ColumnHeader128.Text = "Rework End Oper";
            this.ColumnHeader128.Width = 120;
            // 
            // ColumnHeader129
            // 
            this.ColumnHeader129.DisplayIndex = 34;
            this.ColumnHeader129.Text = "Rework Ret Clear Flag";
            this.ColumnHeader129.Width = 155;
            // 
            // ColumnHeader130
            // 
            this.ColumnHeader130.DisplayIndex = 35;
            this.ColumnHeader130.Text = "Rework Time";
            this.ColumnHeader130.Width = 120;
            // 
            // ColumnHeader131
            // 
            this.ColumnHeader131.DisplayIndex = 36;
            this.ColumnHeader131.Text = "NSTD Flag";
            this.ColumnHeader131.Width = 120;
            // 
            // ColumnHeader132
            // 
            this.ColumnHeader132.DisplayIndex = 37;
            this.ColumnHeader132.Text = "NSTD Ret Flow";
            this.ColumnHeader132.Width = 120;
            // 
            // ColumnHeader133
            // 
            this.ColumnHeader133.DisplayIndex = 38;
            this.ColumnHeader133.Text = "NSTD Ret Oper";
            this.ColumnHeader133.Width = 120;
            // 
            // ColumnHeader134
            // 
            this.ColumnHeader134.DisplayIndex = 39;
            this.ColumnHeader134.Text = "NSTD Time";
            this.ColumnHeader134.Width = 120;
            // 
            // ColumnHeader135
            // 
            this.ColumnHeader135.DisplayIndex = 40;
            this.ColumnHeader135.Text = "Start Flag";
            this.ColumnHeader135.Width = 70;
            // 
            // ColumnHeader136
            // 
            this.ColumnHeader136.DisplayIndex = 41;
            this.ColumnHeader136.Text = "Start Time";
            this.ColumnHeader136.Width = 120;
            // 
            // ColumnHeader137
            // 
            this.ColumnHeader137.DisplayIndex = 42;
            this.ColumnHeader137.Text = "Start Res ID";
            this.ColumnHeader137.Width = 80;
            // 
            // ColumnHeader138
            // 
            this.ColumnHeader138.DisplayIndex = 43;
            this.ColumnHeader138.Text = "End Flag";
            this.ColumnHeader138.Width = 70;
            // 
            // ColumnHeader139
            // 
            this.ColumnHeader139.DisplayIndex = 44;
            this.ColumnHeader139.Text = "End Time";
            this.ColumnHeader139.Width = 120;
            // 
            // ColumnHeader140
            // 
            this.ColumnHeader140.DisplayIndex = 45;
            this.ColumnHeader140.Text = "End Res ID";
            this.ColumnHeader140.Width = 80;
            // 
            // ColumnHeader141
            // 
            this.ColumnHeader141.DisplayIndex = 46;
            this.ColumnHeader141.Text = "Sample Flag";
            this.ColumnHeader141.Width = 100;
            // 
            // ColumnHeader142
            // 
            this.ColumnHeader142.DisplayIndex = 47;
            this.ColumnHeader142.Text = "Sample Wait Flag";
            this.ColumnHeader142.Width = 110;
            // 
            // ColumnHeader143
            // 
            this.ColumnHeader143.DisplayIndex = 48;
            this.ColumnHeader143.Text = "Sample Result";
            this.ColumnHeader143.Width = 100;
            // 
            // ColumnHeader144
            // 
            this.ColumnHeader144.DisplayIndex = 49;
            this.ColumnHeader144.Text = "From To Lot ID";
            this.ColumnHeader144.Width = 120;
            // 
            // ColumnHeader145
            // 
            this.ColumnHeader145.DisplayIndex = 50;
            this.ColumnHeader145.Text = "Ship Code";
            this.ColumnHeader145.Width = 80;
            // 
            // ColumnHeader146
            // 
            this.ColumnHeader146.DisplayIndex = 51;
            this.ColumnHeader146.Text = "Ship Time";
            this.ColumnHeader146.Width = 120;
            // 
            // ColumnHeader147
            // 
            this.ColumnHeader147.DisplayIndex = 52;
            this.ColumnHeader147.Text = "Original Due Time";
            this.ColumnHeader147.Width = 120;
            // 
            // ColumnHeader148
            // 
            this.ColumnHeader148.DisplayIndex = 53;
            this.ColumnHeader148.Text = "Scheduled Due Time";
            this.ColumnHeader148.Width = 145;
            // 
            // ColumnHeader149
            // 
            this.ColumnHeader149.DisplayIndex = 54;
            this.ColumnHeader149.Text = "Create Time";
            this.ColumnHeader149.Width = 120;
            // 
            // ColumnHeader150
            // 
            this.ColumnHeader150.DisplayIndex = 55;
            this.ColumnHeader150.Text = "Factory In Time";
            this.ColumnHeader150.Width = 120;
            // 
            // ColumnHeader151
            // 
            this.ColumnHeader151.DisplayIndex = 56;
            this.ColumnHeader151.Text = "Flow In Time";
            this.ColumnHeader151.Width = 120;
            // 
            // ColumnHeader152
            // 
            this.ColumnHeader152.DisplayIndex = 57;
            this.ColumnHeader152.Text = "Oper In Time";
            this.ColumnHeader152.Width = 120;
            // 
            // ColumnHeader153
            // 
            this.ColumnHeader153.DisplayIndex = 58;
            this.ColumnHeader153.Text = "Reserve Res ID";
            this.ColumnHeader153.Width = 120;
            // 
            // ColumnHeader154
            // 
            this.ColumnHeader154.DisplayIndex = 59;
            this.ColumnHeader154.Text = "Batch ID";
            // 
            // ColumnHeader155
            // 
            this.ColumnHeader155.DisplayIndex = 60;
            this.ColumnHeader155.Text = "Batch Seq";
            this.ColumnHeader155.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader155.Width = 70;
            // 
            // ColumnHeader156
            // 
            this.ColumnHeader156.DisplayIndex = 61;
            this.ColumnHeader156.Text = "Order ID";
            this.ColumnHeader156.Width = 100;
            // 
            // ColumnHeader157
            // 
            this.ColumnHeader157.DisplayIndex = 62;
            this.ColumnHeader157.Text = "Add Order ID 1";
            this.ColumnHeader157.Width = 100;
            // 
            // ColumnHeader158
            // 
            this.ColumnHeader158.DisplayIndex = 63;
            this.ColumnHeader158.Text = "Add Order ID 2";
            this.ColumnHeader158.Width = 100;
            // 
            // ColumnHeader159
            // 
            this.ColumnHeader159.DisplayIndex = 64;
            this.ColumnHeader159.Text = "Add Order ID 3";
            this.ColumnHeader159.Width = 100;
            // 
            // ColumnHeader160
            // 
            this.ColumnHeader160.DisplayIndex = 65;
            this.ColumnHeader160.Text = "Location";
            this.ColumnHeader160.Width = 80;
            // 
            // ColumnHeader161
            // 
            this.ColumnHeader161.DisplayIndex = 66;
            this.ColumnHeader161.Text = "Lot Cmf 1";
            this.ColumnHeader161.Width = 100;
            // 
            // ColumnHeader162
            // 
            this.ColumnHeader162.DisplayIndex = 67;
            this.ColumnHeader162.Text = "Lot Cmf 2";
            this.ColumnHeader162.Width = 100;
            // 
            // ColumnHeader163
            // 
            this.ColumnHeader163.DisplayIndex = 68;
            this.ColumnHeader163.Text = "Lot Cmf 3";
            this.ColumnHeader163.Width = 100;
            // 
            // ColumnHeader164
            // 
            this.ColumnHeader164.DisplayIndex = 69;
            this.ColumnHeader164.Text = "Lot Cmf 4";
            this.ColumnHeader164.Width = 100;
            // 
            // ColumnHeader165
            // 
            this.ColumnHeader165.DisplayIndex = 70;
            this.ColumnHeader165.Text = "Lot Cmf 5";
            this.ColumnHeader165.Width = 100;
            // 
            // ColumnHeader166
            // 
            this.ColumnHeader166.DisplayIndex = 71;
            this.ColumnHeader166.Text = "Lot Cmf 6";
            this.ColumnHeader166.Width = 100;
            // 
            // ColumnHeader167
            // 
            this.ColumnHeader167.DisplayIndex = 72;
            this.ColumnHeader167.Text = "Lot Cmf 7";
            this.ColumnHeader167.Width = 100;
            // 
            // ColumnHeader168
            // 
            this.ColumnHeader168.DisplayIndex = 73;
            this.ColumnHeader168.Text = "Lot Cmf 8";
            this.ColumnHeader168.Width = 100;
            // 
            // ColumnHeader169
            // 
            this.ColumnHeader169.DisplayIndex = 74;
            this.ColumnHeader169.Text = "Lot Cmf 9";
            this.ColumnHeader169.Width = 100;
            // 
            // ColumnHeader170
            // 
            this.ColumnHeader170.DisplayIndex = 75;
            this.ColumnHeader170.Text = "Lot Cmf 10";
            this.ColumnHeader170.Width = 100;
            // 
            // ColumnHeader171
            // 
            this.ColumnHeader171.DisplayIndex = 76;
            this.ColumnHeader171.Text = "Lot Cmf 11";
            this.ColumnHeader171.Width = 100;
            // 
            // ColumnHeader172
            // 
            this.ColumnHeader172.DisplayIndex = 77;
            this.ColumnHeader172.Text = "Lot Cmf 12";
            this.ColumnHeader172.Width = 100;
            // 
            // ColumnHeader173
            // 
            this.ColumnHeader173.DisplayIndex = 78;
            this.ColumnHeader173.Text = "Lot Cmf 13";
            this.ColumnHeader173.Width = 100;
            // 
            // ColumnHeader174
            // 
            this.ColumnHeader174.DisplayIndex = 79;
            this.ColumnHeader174.Text = "Lot Cmf 14";
            this.ColumnHeader174.Width = 100;
            // 
            // ColumnHeader175
            // 
            this.ColumnHeader175.DisplayIndex = 80;
            this.ColumnHeader175.Text = "Lot Cmf 15";
            this.ColumnHeader175.Width = 100;
            // 
            // ColumnHeader176
            // 
            this.ColumnHeader176.DisplayIndex = 81;
            this.ColumnHeader176.Text = "Lot Cmf 16";
            this.ColumnHeader176.Width = 100;
            // 
            // ColumnHeader177
            // 
            this.ColumnHeader177.DisplayIndex = 82;
            this.ColumnHeader177.Text = "Lot Cmf 17";
            this.ColumnHeader177.Width = 100;
            // 
            // ColumnHeader178
            // 
            this.ColumnHeader178.DisplayIndex = 83;
            this.ColumnHeader178.Text = "Lot Cmf 18";
            this.ColumnHeader178.Width = 100;
            // 
            // ColumnHeader179
            // 
            this.ColumnHeader179.DisplayIndex = 84;
            this.ColumnHeader179.Text = "Lot Cmf 19";
            this.ColumnHeader179.Width = 100;
            // 
            // ColumnHeader180
            // 
            this.ColumnHeader180.DisplayIndex = 85;
            this.ColumnHeader180.Text = "Lot Cmf 20";
            this.ColumnHeader180.Width = 100;
            // 
            // ColumnHeader181
            // 
            this.ColumnHeader181.DisplayIndex = 86;
            this.ColumnHeader181.Text = "BOM Set ID";
            this.ColumnHeader181.Width = 100;
            // 
            // ColumnHeader182
            // 
            this.ColumnHeader182.DisplayIndex = 87;
            this.ColumnHeader182.Text = "BOM Set Version";
            this.ColumnHeader182.Width = 120;
            // 
            // ColumnHeader183
            // 
            this.ColumnHeader183.DisplayIndex = 88;
            this.ColumnHeader183.Text = "BOM Act Hist Seq";
            this.ColumnHeader183.Width = 120;
            // 
            // ColumnHeader184
            // 
            this.ColumnHeader184.DisplayIndex = 89;
            this.ColumnHeader184.Text = "BOM Hist Seq";
            this.ColumnHeader184.Width = 100;
            // 
            // ColumnHeader185
            // 
            this.ColumnHeader185.DisplayIndex = 90;
            this.ColumnHeader185.Text = "Lot Delete Flag";
            this.ColumnHeader185.Width = 100;
            // 
            // ColumnHeader186
            // 
            this.ColumnHeader186.DisplayIndex = 91;
            this.ColumnHeader186.Text = "Lot Delete Time";
            this.ColumnHeader186.Width = 120;
            // 
            // ColumnHeader187
            // 
            this.ColumnHeader187.DisplayIndex = 92;
            this.ColumnHeader187.Text = "Lot Delete Reason";
            this.ColumnHeader187.Width = 150;
            // 
            // ColumnHeader188
            // 
            this.ColumnHeader188.DisplayIndex = 93;
            this.ColumnHeader188.Text = "Last Trans Code";
            this.ColumnHeader188.Width = 120;
            // 
            // ColumnHeader189
            // 
            this.ColumnHeader189.DisplayIndex = 94;
            this.ColumnHeader189.Text = "Last Trans Time";
            this.ColumnHeader189.Width = 120;
            // 
            // ColumnHeader190
            // 
            this.ColumnHeader190.DisplayIndex = 95;
            this.ColumnHeader190.Text = "Last Comment";
            this.ColumnHeader190.Width = 200;
            // 
            // ColumnHeader191
            // 
            this.ColumnHeader191.DisplayIndex = 96;
            this.ColumnHeader191.Text = "Last Active Hist Seq";
            this.ColumnHeader191.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader191.Width = 140;
            // 
            // ColumnHeader192
            // 
            this.ColumnHeader192.DisplayIndex = 97;
            this.ColumnHeader192.Text = "Last Hist Seq";
            this.ColumnHeader192.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader192.Width = 120;
            // 
            // columnHeader195
            // 
            this.columnHeader195.DisplayIndex = 3;
            this.columnHeader195.Text = "Mat Ver";
            // 
            // columnHeader196
            // 
            this.columnHeader196.DisplayIndex = 5;
            this.columnHeader196.Text = "Flow Seq";
            // 
            // grpResInfo
            // 
            this.grpResInfo.Controls.Add(this.pnlResInfoMain);
            this.grpResInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpResInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResInfo.Location = new System.Drawing.Point(3, 225);
            this.grpResInfo.Name = "grpResInfo";
            this.grpResInfo.Size = new System.Drawing.Size(722, 174);
            this.grpResInfo.TabIndex = 1;
            this.grpResInfo.TabStop = false;
            this.grpResInfo.Text = "Resource Information";
            // 
            // pnlResInfoMain
            // 
            this.pnlResInfoMain.Controls.Add(this.pnlResIDMid);
            this.pnlResInfoMain.Controls.Add(this.pnlResID);
            this.pnlResInfoMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResInfoMain.Location = new System.Drawing.Point(3, 16);
            this.pnlResInfoMain.Name = "pnlResInfoMain";
            this.pnlResInfoMain.Size = new System.Drawing.Size(716, 155);
            this.pnlResInfoMain.TabIndex = 1;
            // 
            // pnlResIDMid
            // 
            this.pnlResIDMid.Controls.Add(this.spdResInfo);
            this.pnlResIDMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResIDMid.Location = new System.Drawing.Point(0, 48);
            this.pnlResIDMid.Name = "pnlResIDMid";
            this.pnlResIDMid.Size = new System.Drawing.Size(716, 107);
            this.pnlResIDMid.TabIndex = 0;
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
            this.spdResInfo.Location = new System.Drawing.Point(0, 0);
            this.spdResInfo.MoveActiveOnFocus = false;
            this.spdResInfo.Name = "spdResInfo";
            this.spdResInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdResInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdResInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResInfo_LotInfo});
            this.spdResInfo.Size = new System.Drawing.Size(716, 107);
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
            this.spdResInfo_LotInfo.Columns.Get(0).Width = 150F;
            this.spdResInfo_LotInfo.Columns.Get(1).CellType = textCellType2;
            this.spdResInfo_LotInfo.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Columns.Get(1).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(1).Width = 197F;
            this.spdResInfo_LotInfo.Columns.Get(2).BackColor = System.Drawing.SystemColors.Control;
            this.spdResInfo_LotInfo.Columns.Get(2).Border = compoundBorder2;
            this.spdResInfo_LotInfo.Columns.Get(2).CellType = textCellType3;
            this.spdResInfo_LotInfo.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(2).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(2).Width = 150F;
            this.spdResInfo_LotInfo.Columns.Get(3).CellType = textCellType4;
            this.spdResInfo_LotInfo.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdResInfo_LotInfo.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdResInfo_LotInfo.Columns.Get(3).Locked = true;
            this.spdResInfo_LotInfo.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResInfo_LotInfo.Columns.Get(3).Width = 197F;
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
            this.spdResInfo_LotInfo.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdResInfo_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlResID
            // 
            this.pnlResID.Controls.Add(this.cdvPortID);
            this.pnlResID.Controls.Add(this.lblPortID);
            this.pnlResID.Controls.Add(this.pnlTranTime);
            this.pnlResID.Controls.Add(this.cdvResID);
            this.pnlResID.Controls.Add(this.lblResID);
            this.pnlResID.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResID.Location = new System.Drawing.Point(0, 0);
            this.pnlResID.Name = "pnlResID";
            this.pnlResID.Size = new System.Drawing.Size(716, 48);
            this.pnlResID.TabIndex = 0;
            // 
            // cdvPortID
            // 
            this.cdvPortID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPortID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPortID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPortID.BtnToolTipText = "";
            this.cdvPortID.DescText = "";
            this.cdvPortID.DisplaySubItemIndex = -1;
            this.cdvPortID.DisplayText = "";
            this.cdvPortID.Focusing = null;
            this.cdvPortID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPortID.Index = 0;
            this.cdvPortID.IsViewBtnImage = false;
            this.cdvPortID.Location = new System.Drawing.Point(118, 24);
            this.cdvPortID.MaxLength = 20;
            this.cdvPortID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPortID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPortID.Name = "cdvPortID";
            this.cdvPortID.ReadOnly = false;
            this.cdvPortID.SearchSubItemIndex = 0;
            this.cdvPortID.SelectedDescIndex = -1;
            this.cdvPortID.SelectedSubItemIndex = -1;
            this.cdvPortID.SelectionStart = 0;
            this.cdvPortID.Size = new System.Drawing.Size(200, 20);
            this.cdvPortID.SmallImageList = null;
            this.cdvPortID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPortID.TabIndex = 6;
            this.cdvPortID.TextBoxToolTipText = "";
            this.cdvPortID.TextBoxWidth = 200;
            this.cdvPortID.VisibleButton = true;
            this.cdvPortID.VisibleColumnHeader = false;
            this.cdvPortID.VisibleDescription = false;
            this.cdvPortID.ButtonPress += new System.EventHandler(this.cdvPortID_ButtonPress);
            // 
            // lblPortID
            // 
            this.lblPortID.AutoSize = true;
            this.lblPortID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPortID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortID.Location = new System.Drawing.Point(12, 27);
            this.lblPortID.Name = "lblPortID";
            this.lblPortID.Size = new System.Drawing.Size(40, 13);
            this.lblPortID.TabIndex = 5;
            this.lblPortID.Text = "Port ID";
            this.lblPortID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranTime.Controls.Add(this.txtTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranTime);
            this.pnlTranTime.Controls.Add(this.chkTranDateTime);
            this.pnlTranTime.Controls.Add(this.dtpTranDate);
            this.pnlTranTime.Location = new System.Drawing.Point(408, -1);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 23);
            this.pnlTranTime.TabIndex = 2;
            // 
            // txtTranDateTime
            // 
            this.txtTranDateTime.Location = new System.Drawing.Point(139, 1);
            this.txtTranDateTime.MaxLength = 30;
            this.txtTranDateTime.Name = "txtTranDateTime";
            this.txtTranDateTime.ReadOnly = true;
            this.txtTranDateTime.Size = new System.Drawing.Size(157, 20);
            this.txtTranDateTime.TabIndex = 1;
            this.txtTranDateTime.TabStop = false;
            // 
            // dtpTranTime
            // 
            this.dtpTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTranTime.Checked = false;
            this.dtpTranTime.CustomFormat = "HH:mm:ss";
            this.dtpTranTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTranTime.Location = new System.Drawing.Point(225, 1);
            this.dtpTranTime.Name = "dtpTranTime";
            this.dtpTranTime.ShowUpDown = true;
            this.dtpTranTime.Size = new System.Drawing.Size(71, 20);
            this.dtpTranTime.TabIndex = 2;
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 4);
            this.chkTranDateTime.Name = "chkTranDateTime";
            this.chkTranDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
            this.chkTranDateTime.TabIndex = 0;
            this.chkTranDateTime.Text = "Transaction Time";
            this.chkTranDateTime.CheckedChanged += new System.EventHandler(this.chkTranDateTime_CheckedChanged);
            // 
            // dtpTranDate
            // 
            this.dtpTranDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTranDate.Checked = false;
            this.dtpTranDate.CustomFormat = "";
            this.dtpTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTranDate.Location = new System.Drawing.Point(139, 1);
            this.dtpTranDate.Name = "dtpTranDate";
            this.dtpTranDate.Size = new System.Drawing.Size(86, 20);
            this.dtpTranDate.TabIndex = 9;
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
            this.cdvResID.Location = new System.Drawing.Point(118, 0);
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
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(12, 3);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.grpComment);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComment.Location = new System.Drawing.Point(0, 399);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlComment.Size = new System.Drawing.Size(728, 38);
            this.pnlComment.TabIndex = 1;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Location = new System.Drawing.Point(3, 0);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(722, 38);
            this.grpComment.TabIndex = 0;
            this.grpComment.TabStop = false;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 14);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(120, 12);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(590, 20);
            this.txtComment.TabIndex = 1;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.pnlCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Size = new System.Drawing.Size(728, 440);
            this.tbpCMF.TabIndex = 1;
            this.tbpCMF.Text = "Customized Field";
            this.tbpCMF.Visible = false;
            // 
            // pnlCMF
            // 
            this.pnlCMF.Controls.Add(this.grpCMF);
            this.pnlCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCMF.Location = new System.Drawing.Point(0, 0);
            this.pnlCMF.Name = "pnlCMF";
            this.pnlCMF.Padding = new System.Windows.Forms.Padding(3);
            this.pnlCMF.Size = new System.Drawing.Size(728, 440);
            this.pnlCMF.TabIndex = 0;
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.cdvCMF19);
            this.grpCMF.Controls.Add(this.cdvCMF18);
            this.grpCMF.Controls.Add(this.cdvCMF17);
            this.grpCMF.Controls.Add(this.cdvCMF16);
            this.grpCMF.Controls.Add(this.cdvCMF15);
            this.grpCMF.Controls.Add(this.cdvCMF14);
            this.grpCMF.Controls.Add(this.cdvCMF13);
            this.grpCMF.Controls.Add(this.cdvCMF12);
            this.grpCMF.Controls.Add(this.cdvCMF20);
            this.grpCMF.Controls.Add(this.cdvCMF11);
            this.grpCMF.Controls.Add(this.lblCMF20);
            this.grpCMF.Controls.Add(this.lblCMF19);
            this.grpCMF.Controls.Add(this.lblCMF18);
            this.grpCMF.Controls.Add(this.lblCMF17);
            this.grpCMF.Controls.Add(this.lblCMF16);
            this.grpCMF.Controls.Add(this.lblCMF15);
            this.grpCMF.Controls.Add(this.lblCMF14);
            this.grpCMF.Controls.Add(this.lblCMF13);
            this.grpCMF.Controls.Add(this.lblCMF12);
            this.grpCMF.Controls.Add(this.lblCMF11);
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF5);
            this.grpCMF.Controls.Add(this.cdvCMF4);
            this.grpCMF.Controls.Add(this.cdvCMF3);
            this.grpCMF.Controls.Add(this.cdvCMF2);
            this.grpCMF.Controls.Add(this.cdvCMF10);
            this.grpCMF.Controls.Add(this.cdvCMF1);
            this.grpCMF.Controls.Add(this.lblCMF10);
            this.grpCMF.Controls.Add(this.lblCMF9);
            this.grpCMF.Controls.Add(this.lblCMF8);
            this.grpCMF.Controls.Add(this.lblCMF7);
            this.grpCMF.Controls.Add(this.lblCMF6);
            this.grpCMF.Controls.Add(this.lblCMF5);
            this.grpCMF.Controls.Add(this.lblCMF4);
            this.grpCMF.Controls.Add(this.lblCMF3);
            this.grpCMF.Controls.Add(this.lblCMF2);
            this.grpCMF.Controls.Add(this.lblCMF1);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.Location = new System.Drawing.Point(3, 3);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(722, 434);
            this.grpCMF.TabIndex = 1;
            this.grpCMF.TabStop = false;
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF19.BtnToolTipText = "";
            this.cdvCMF19.DescText = "";
            this.cdvCMF19.DisplaySubItemIndex = -1;
            this.cdvCMF19.DisplayText = "";
            this.cdvCMF19.Focusing = null;
            this.cdvCMF19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF19.Index = 0;
            this.cdvCMF19.IsViewBtnImage = false;
            this.cdvCMF19.Location = new System.Drawing.Point(530, 208);
            this.cdvCMF19.MaxLength = 30;
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.Name = "cdvCMF19";
            this.cdvCMF19.ReadOnly = false;
            this.cdvCMF19.SearchSubItemIndex = 0;
            this.cdvCMF19.SelectedDescIndex = -1;
            this.cdvCMF19.SelectedSubItemIndex = -1;
            this.cdvCMF19.SelectionStart = 0;
            this.cdvCMF19.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF19.SmallImageList = null;
            this.cdvCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF19.TabIndex = 37;
            this.cdvCMF19.TextBoxToolTipText = "";
            this.cdvCMF19.TextBoxWidth = 180;
            this.cdvCMF19.VisibleButton = true;
            this.cdvCMF19.VisibleColumnHeader = false;
            this.cdvCMF19.VisibleDescription = false;
            this.cdvCMF19.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF18.BtnToolTipText = "";
            this.cdvCMF18.DescText = "";
            this.cdvCMF18.DisplaySubItemIndex = -1;
            this.cdvCMF18.DisplayText = "";
            this.cdvCMF18.Focusing = null;
            this.cdvCMF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF18.Index = 0;
            this.cdvCMF18.IsViewBtnImage = false;
            this.cdvCMF18.Location = new System.Drawing.Point(530, 184);
            this.cdvCMF18.MaxLength = 30;
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.Name = "cdvCMF18";
            this.cdvCMF18.ReadOnly = false;
            this.cdvCMF18.SearchSubItemIndex = 0;
            this.cdvCMF18.SelectedDescIndex = -1;
            this.cdvCMF18.SelectedSubItemIndex = -1;
            this.cdvCMF18.SelectionStart = 0;
            this.cdvCMF18.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF18.SmallImageList = null;
            this.cdvCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF18.TabIndex = 35;
            this.cdvCMF18.TextBoxToolTipText = "";
            this.cdvCMF18.TextBoxWidth = 180;
            this.cdvCMF18.VisibleButton = true;
            this.cdvCMF18.VisibleColumnHeader = false;
            this.cdvCMF18.VisibleDescription = false;
            this.cdvCMF18.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF17.BtnToolTipText = "";
            this.cdvCMF17.DescText = "";
            this.cdvCMF17.DisplaySubItemIndex = -1;
            this.cdvCMF17.DisplayText = "";
            this.cdvCMF17.Focusing = null;
            this.cdvCMF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF17.Index = 0;
            this.cdvCMF17.IsViewBtnImage = false;
            this.cdvCMF17.Location = new System.Drawing.Point(530, 160);
            this.cdvCMF17.MaxLength = 30;
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.Name = "cdvCMF17";
            this.cdvCMF17.ReadOnly = false;
            this.cdvCMF17.SearchSubItemIndex = 0;
            this.cdvCMF17.SelectedDescIndex = -1;
            this.cdvCMF17.SelectedSubItemIndex = -1;
            this.cdvCMF17.SelectionStart = 0;
            this.cdvCMF17.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF17.SmallImageList = null;
            this.cdvCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF17.TabIndex = 33;
            this.cdvCMF17.TextBoxToolTipText = "";
            this.cdvCMF17.TextBoxWidth = 180;
            this.cdvCMF17.VisibleButton = true;
            this.cdvCMF17.VisibleColumnHeader = false;
            this.cdvCMF17.VisibleDescription = false;
            this.cdvCMF17.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF16.BtnToolTipText = "";
            this.cdvCMF16.DescText = "";
            this.cdvCMF16.DisplaySubItemIndex = -1;
            this.cdvCMF16.DisplayText = "";
            this.cdvCMF16.Focusing = null;
            this.cdvCMF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF16.Index = 0;
            this.cdvCMF16.IsViewBtnImage = false;
            this.cdvCMF16.Location = new System.Drawing.Point(530, 136);
            this.cdvCMF16.MaxLength = 30;
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.Name = "cdvCMF16";
            this.cdvCMF16.ReadOnly = false;
            this.cdvCMF16.SearchSubItemIndex = 0;
            this.cdvCMF16.SelectedDescIndex = -1;
            this.cdvCMF16.SelectedSubItemIndex = -1;
            this.cdvCMF16.SelectionStart = 0;
            this.cdvCMF16.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF16.SmallImageList = null;
            this.cdvCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF16.TabIndex = 31;
            this.cdvCMF16.TextBoxToolTipText = "";
            this.cdvCMF16.TextBoxWidth = 180;
            this.cdvCMF16.VisibleButton = true;
            this.cdvCMF16.VisibleColumnHeader = false;
            this.cdvCMF16.VisibleDescription = false;
            this.cdvCMF16.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF15.BtnToolTipText = "";
            this.cdvCMF15.DescText = "";
            this.cdvCMF15.DisplaySubItemIndex = -1;
            this.cdvCMF15.DisplayText = "";
            this.cdvCMF15.Focusing = null;
            this.cdvCMF15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF15.Index = 0;
            this.cdvCMF15.IsViewBtnImage = false;
            this.cdvCMF15.Location = new System.Drawing.Point(530, 112);
            this.cdvCMF15.MaxLength = 30;
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.Name = "cdvCMF15";
            this.cdvCMF15.ReadOnly = false;
            this.cdvCMF15.SearchSubItemIndex = 0;
            this.cdvCMF15.SelectedDescIndex = -1;
            this.cdvCMF15.SelectedSubItemIndex = -1;
            this.cdvCMF15.SelectionStart = 0;
            this.cdvCMF15.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF15.SmallImageList = null;
            this.cdvCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF15.TabIndex = 29;
            this.cdvCMF15.TextBoxToolTipText = "";
            this.cdvCMF15.TextBoxWidth = 180;
            this.cdvCMF15.VisibleButton = true;
            this.cdvCMF15.VisibleColumnHeader = false;
            this.cdvCMF15.VisibleDescription = false;
            this.cdvCMF15.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF14.BtnToolTipText = "";
            this.cdvCMF14.DescText = "";
            this.cdvCMF14.DisplaySubItemIndex = -1;
            this.cdvCMF14.DisplayText = "";
            this.cdvCMF14.Focusing = null;
            this.cdvCMF14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF14.Index = 0;
            this.cdvCMF14.IsViewBtnImage = false;
            this.cdvCMF14.Location = new System.Drawing.Point(530, 88);
            this.cdvCMF14.MaxLength = 30;
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.Name = "cdvCMF14";
            this.cdvCMF14.ReadOnly = false;
            this.cdvCMF14.SearchSubItemIndex = 0;
            this.cdvCMF14.SelectedDescIndex = -1;
            this.cdvCMF14.SelectedSubItemIndex = -1;
            this.cdvCMF14.SelectionStart = 0;
            this.cdvCMF14.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF14.SmallImageList = null;
            this.cdvCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF14.TabIndex = 27;
            this.cdvCMF14.TextBoxToolTipText = "";
            this.cdvCMF14.TextBoxWidth = 180;
            this.cdvCMF14.VisibleButton = true;
            this.cdvCMF14.VisibleColumnHeader = false;
            this.cdvCMF14.VisibleDescription = false;
            this.cdvCMF14.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF13.BtnToolTipText = "";
            this.cdvCMF13.DescText = "";
            this.cdvCMF13.DisplaySubItemIndex = -1;
            this.cdvCMF13.DisplayText = "";
            this.cdvCMF13.Focusing = null;
            this.cdvCMF13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF13.Index = 0;
            this.cdvCMF13.IsViewBtnImage = false;
            this.cdvCMF13.Location = new System.Drawing.Point(530, 64);
            this.cdvCMF13.MaxLength = 30;
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.Name = "cdvCMF13";
            this.cdvCMF13.ReadOnly = false;
            this.cdvCMF13.SearchSubItemIndex = 0;
            this.cdvCMF13.SelectedDescIndex = -1;
            this.cdvCMF13.SelectedSubItemIndex = -1;
            this.cdvCMF13.SelectionStart = 0;
            this.cdvCMF13.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF13.SmallImageList = null;
            this.cdvCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF13.TabIndex = 25;
            this.cdvCMF13.TextBoxToolTipText = "";
            this.cdvCMF13.TextBoxWidth = 180;
            this.cdvCMF13.VisibleButton = true;
            this.cdvCMF13.VisibleColumnHeader = false;
            this.cdvCMF13.VisibleDescription = false;
            this.cdvCMF13.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF12.BtnToolTipText = "";
            this.cdvCMF12.DescText = "";
            this.cdvCMF12.DisplaySubItemIndex = -1;
            this.cdvCMF12.DisplayText = "";
            this.cdvCMF12.Focusing = null;
            this.cdvCMF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF12.Index = 0;
            this.cdvCMF12.IsViewBtnImage = false;
            this.cdvCMF12.Location = new System.Drawing.Point(530, 40);
            this.cdvCMF12.MaxLength = 30;
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.Name = "cdvCMF12";
            this.cdvCMF12.ReadOnly = false;
            this.cdvCMF12.SearchSubItemIndex = 0;
            this.cdvCMF12.SelectedDescIndex = -1;
            this.cdvCMF12.SelectedSubItemIndex = -1;
            this.cdvCMF12.SelectionStart = 0;
            this.cdvCMF12.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF12.SmallImageList = null;
            this.cdvCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF12.TabIndex = 23;
            this.cdvCMF12.TextBoxToolTipText = "";
            this.cdvCMF12.TextBoxWidth = 180;
            this.cdvCMF12.VisibleButton = true;
            this.cdvCMF12.VisibleColumnHeader = false;
            this.cdvCMF12.VisibleDescription = false;
            this.cdvCMF12.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF20.BtnToolTipText = "";
            this.cdvCMF20.DescText = "";
            this.cdvCMF20.DisplaySubItemIndex = -1;
            this.cdvCMF20.DisplayText = "";
            this.cdvCMF20.Focusing = null;
            this.cdvCMF20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF20.Index = 0;
            this.cdvCMF20.IsViewBtnImage = false;
            this.cdvCMF20.Location = new System.Drawing.Point(530, 232);
            this.cdvCMF20.MaxLength = 30;
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.Name = "cdvCMF20";
            this.cdvCMF20.ReadOnly = false;
            this.cdvCMF20.SearchSubItemIndex = 0;
            this.cdvCMF20.SelectedDescIndex = -1;
            this.cdvCMF20.SelectedSubItemIndex = -1;
            this.cdvCMF20.SelectionStart = 0;
            this.cdvCMF20.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF20.SmallImageList = null;
            this.cdvCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF20.TabIndex = 39;
            this.cdvCMF20.TextBoxToolTipText = "";
            this.cdvCMF20.TextBoxWidth = 180;
            this.cdvCMF20.VisibleButton = true;
            this.cdvCMF20.VisibleColumnHeader = false;
            this.cdvCMF20.VisibleDescription = false;
            this.cdvCMF20.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF11.BtnToolTipText = "";
            this.cdvCMF11.DescText = "";
            this.cdvCMF11.DisplaySubItemIndex = -1;
            this.cdvCMF11.DisplayText = "";
            this.cdvCMF11.Focusing = null;
            this.cdvCMF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF11.Index = 0;
            this.cdvCMF11.IsViewBtnImage = false;
            this.cdvCMF11.Location = new System.Drawing.Point(530, 16);
            this.cdvCMF11.MaxLength = 30;
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.Name = "cdvCMF11";
            this.cdvCMF11.ReadOnly = false;
            this.cdvCMF11.SearchSubItemIndex = 0;
            this.cdvCMF11.SelectedDescIndex = -1;
            this.cdvCMF11.SelectedSubItemIndex = -1;
            this.cdvCMF11.SelectionStart = 0;
            this.cdvCMF11.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF11.SmallImageList = null;
            this.cdvCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF11.TabIndex = 21;
            this.cdvCMF11.TextBoxToolTipText = "";
            this.cdvCMF11.TextBoxWidth = 180;
            this.cdvCMF11.VisibleButton = true;
            this.cdvCMF11.VisibleColumnHeader = false;
            this.cdvCMF11.VisibleDescription = false;
            this.cdvCMF11.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.Location = new System.Drawing.Point(384, 236);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(140, 14);
            this.lblCMF20.TabIndex = 38;
            this.lblCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.Location = new System.Drawing.Point(384, 212);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(140, 14);
            this.lblCMF19.TabIndex = 36;
            this.lblCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.Location = new System.Drawing.Point(384, 188);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(140, 14);
            this.lblCMF18.TabIndex = 34;
            this.lblCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.Location = new System.Drawing.Point(384, 164);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(140, 14);
            this.lblCMF17.TabIndex = 32;
            this.lblCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.Location = new System.Drawing.Point(384, 140);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(140, 14);
            this.lblCMF16.TabIndex = 30;
            this.lblCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.Location = new System.Drawing.Point(384, 116);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(140, 14);
            this.lblCMF15.TabIndex = 28;
            this.lblCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.Location = new System.Drawing.Point(384, 92);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(140, 14);
            this.lblCMF14.TabIndex = 26;
            this.lblCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.Location = new System.Drawing.Point(384, 68);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(140, 14);
            this.lblCMF13.TabIndex = 24;
            this.lblCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.Location = new System.Drawing.Point(384, 44);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(140, 14);
            this.lblCMF12.TabIndex = 22;
            this.lblCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.Location = new System.Drawing.Point(384, 20);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(140, 14);
            this.lblCMF11.TabIndex = 20;
            this.lblCMF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 0;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(163, 208);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 180;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            this.cdvCMF9.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF8.BtnToolTipText = "";
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 0;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(163, 184);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 180;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            this.cdvCMF8.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF7.BtnToolTipText = "";
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 0;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(163, 160);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 180;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            this.cdvCMF7.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF6.BtnToolTipText = "";
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 0;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(163, 136);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 180;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 0;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(163, 112);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 180;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 0;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(163, 88);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 180;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            this.cdvCMF4.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF3.BtnToolTipText = "";
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 0;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(163, 64);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 180;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            this.cdvCMF3.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF2.BtnToolTipText = "";
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 0;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(163, 40);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 180;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 0;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(163, 232);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 180;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF1.BtnToolTipText = "";
            this.cdvCMF1.DescText = "";
            this.cdvCMF1.DisplaySubItemIndex = -1;
            this.cdvCMF1.DisplayText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(163, 16);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(180, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 180;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(17, 236);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(140, 14);
            this.lblCMF10.TabIndex = 18;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(17, 212);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(140, 14);
            this.lblCMF9.TabIndex = 16;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(17, 188);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(140, 14);
            this.lblCMF8.TabIndex = 14;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(17, 164);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(140, 14);
            this.lblCMF7.TabIndex = 12;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(17, 140);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(140, 14);
            this.lblCMF6.TabIndex = 10;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(17, 116);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(140, 14);
            this.lblCMF5.TabIndex = 8;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(17, 92);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(140, 14);
            this.lblCMF4.TabIndex = 6;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(17, 68);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(140, 14);
            this.lblCMF3.TabIndex = 4;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(17, 44);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(140, 14);
            this.lblCMF2.TabIndex = 2;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(17, 20);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(140, 14);
            this.lblCMF1.TabIndex = 0;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(308, 15);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(80, 22);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(516, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(180, 20);
            this.txtLotID.TabIndex = 4;
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(438, 20);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 3;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmWIPTranEndBatch
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranEndBatch";
            this.Text = "End Batch";
            this.Activated += new System.EventHandler(this.frmWIPTranEndtBatch_Activated);
            this.Load += new System.EventHandler(this.frmWIPTranEndBatch_Load);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.grpLotList.ResumeLayout(false);
            this.grpResInfo.ResumeLayout(false);
            this.pnlResInfoMain.ResumeLayout(false);
            this.pnlResIDMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResInfo_LotInfo)).EndInit();
            this.pnlResID.ResumeLayout(false);
            this.pnlResID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPortID)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.tbpCMF.ResumeLayout(false);
            this.pnlCMF.ResumeLayout(false);
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
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        private const int COL_LOT_ID = 1;
        private const int COL_MAT_ID = 2;
        private const int COL_MAT_VER = 3;
        private const int COL_FLOW = 4;
        private const int COL_FLOW_SEQ = 5;
        private const int COL_OPERATION = 6;
        private const int QTY_1 = 7;
        private const int QTY_2 = 8;
        private const int QTY_3 = 9;
        private const int COL_RES_ID = 42;
        private const int COL_LAST_HIST_SEQ = 101;
        
        
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
                switch (ProcStep)
                {
                    case "1":

                        MPCF.FieldClear(this);
                        lisLotList.Items.Clear();
                        break;
                    case "2":
                        
                        //Lot ?…ë ¥ ???”í„° ???„ë“œ ì´ˆê¸°??ë°?Lot Information ì¶œë ¥
                        MPCF.FieldClear(this, txtBatchID, null, null, null, null, false);
                        lisLotList.Items.Clear();
                        
                        if (txtBatchID.Text != "")
                        {
                            View_Batch_Lot_List();
                            if (lisLotList.Items.Count > 0)
                            {
                                cdvResID.Text = GetResID(0);
                                if (MPCF.Trim(cdvResID.Text) != "")
                                {
                                    View_Resource();
                                }
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
                case "END_BATCH":


                    if (MPCF.CheckValue(txtBatchID, 1) == false)
                    {
                        txtBatchID.Focus();
                        return false;
                    }
                    
                    if (lisLotList.Items.Count == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(199));
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
                    
            }
            
            return true;
            
        }

        //
        // GetActiveLastHistSeq()
        //       - Get Active Last Hist Seq by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetLastHistSeq(int iRow)
        {
            
            string sActiveLastHistSeq = "";
            try
            {
                sActiveLastHistSeq = lisLotList.Items[iRow].SubItems[COL_LAST_HIST_SEQ].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sActiveLastHistSeq;
            
        }
        
        //
        // GetMaterial()
        //       - Get Material by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetMaterial(int iRow)
        {
            
            string sMaterial = "";
            try
            {
                sMaterial = lisLotList.Items[iRow].SubItems[COL_MAT_ID].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sMaterial;
            
        }

        //
        // GetMaterial()
        //       - Get Material by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private int GetMaterialVer(int iRow)
        {

            int iMatVer = 0;
            try
            {
                iMatVer = System.Convert.ToInt32(lisLotList.Items[iRow].SubItems[COL_MAT_VER].Text);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return iMatVer;

        }
        
        //
        // GetFlow()
        //       - Get Flow by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetFlow(int iRow)
        {
            
            string sFlow = "";
            try
            {
                sFlow = lisLotList.Items[iRow].SubItems[COL_FLOW].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sFlow;
            
        }

        private int GetFlowSeq(int iRow)
        {

            int iFlowSeq = 0;
            try
            {
                iFlowSeq = System.Convert.ToInt32(lisLotList.Items[iRow].SubItems[COL_FLOW_SEQ].Text);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return iFlowSeq;

        }

        //
        // GetOperation()
        //       - Get Operation Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetOperation(int iRow)
        {
            
            string sOperation = "";
            
            if (lisLotList.Items.Count < 1)
            {
                return sOperation;
            }
            
            try
            {
                sOperation = lisLotList.Items[iRow].SubItems[COL_OPERATION].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sOperation;
            
        }
        
        //
        // GetLotID()
        //       - Get Operation Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetLotID(int iRow)
        {
            
            string sLotID = "";
            
            if (lisLotList.Items.Count < 1)
            {
                return sLotID;
            }
            
            try
            {
                sLotID = lisLotList.Items[iRow].SubItems[COL_LOT_ID].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sLotID;
            
        }
        
        //
        // GetResID()
        //       - Get Operation Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetResID(int iRow)
        {
            
            string sResID = "";
            
            if (lisLotList.Items.Count < 1)
            {
                return sResID;
            }
            
            try
            {
                sResID = lisLotList.Items[iRow].SubItems[COL_RES_ID].Text;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sResID;
            
        }
        
        //
        // GetQty()
        //       - Get Qty by Selected Row of LotList
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iRow As Integer : Selected Row
        //
        private string GetQty(int iRow, int iQtyType)
        {
            
            string sQty = "";
            try
            {
                switch (iQtyType)
                {
                    case 1:
                        
                        sQty = lisLotList.Items[iRow].SubItems[QTY_1].Text;
                        break;
                    case 2:
                        
                        sQty = lisLotList.Items[iRow].SubItems[QTY_2].Text;
                        break;
                    case 3:
                        
                        sQty = lisLotList.Items[iRow].SubItems[QTY_3].Text;
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return sQty;
            
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
                if (RASLIST.ViewResourceList(cdvResID.GetListView, GetMaterial(0), GetMaterialVer(0), GetFlow(0), GetOperation(0), false) == false)
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
        // GetPortIDList()
        //       - Get Port ID List by Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool GetPortIDList()
        {

            try
            {
                cdvPortID.Init();
                MPCF.InitListView(cdvPortID.GetListView);
                cdvPortID.Columns.Add("Port ID", 50, HorizontalAlignment.Left);
                cdvPortID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvPortID.SelectedSubItemIndex = 0;

                if (RASLIST.ViewPortList(cdvPortID.GetListView, '1', cdvResID.Text, "") == false)
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

        // View_Batch_Lot_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_Batch_Lot_List()
        {

            int i;
            string[] lot_list;

            TRSNode in_node = new TRSNode("VIEW_BATCH_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_LOT_LIST_OUT");

            try
            {
                lisLotList.Items.Clear();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));

                if (MPCR.CallService("WIP", "WIP_View_Batch_Item_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetList(0).Count < 1)
                {
                    return false;
                }

                lot_list = new string[out_node.GetList(0).Count];

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    WIPLIST.DisplayLotListDetail(lisLotList, out_node.GetList(0)[i], 0);
                    //lot_list[i] = out_node.GetList(0)[i].GetString("ITEM_ID");
                }

                //if (WIPLIST.ViewLotListDetail(lisLotList, '1', lot_list, "", "", "", "", "", "", "", "", "", "", "", "", ' ', ' ') == false)
                //{
                //    return false;
                //}

                MPCF.FitColumnHeader(lisLotList);
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        private bool View_Lot()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", txtLotID.Text);

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            txtBatchID.Text = out_node.GetString("BATCH_ID");

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

                if (out_node.GetChar("RES_UP_DOWN_FLAG") =='U')
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "UP";
                }
                else if (out_node.GetChar("RES_UP_DOWN_FLAG") == 'D')
                {
                    spdResInfo.Sheets[0].Cells[0, 1].Text = "DOWN";
                }
                spdResInfo.Sheets[0].Cells[0, 3].Value = out_node.GetString("RES_PRI_STS");

                spdResInfo.Sheets[0].Cells[1, 1].Value = out_node.GetString("RES_STS_1");
                spdResInfo.Sheets[0].Cells[1, 3].Value = out_node.GetString("RES_STS_2");
                spdResInfo.Sheets[0].Cells[2, 1].Value = out_node.GetString("RES_STS_3");
                spdResInfo.Sheets[0].Cells[2, 3].Value = out_node.GetString("RES_STS_4");
                spdResInfo.Sheets[0].Cells[3, 1].Value = out_node.GetString("RES_STS_5");
                spdResInfo.Sheets[0].Cells[3, 3].Value = out_node.GetString("RES_STS_6");
                spdResInfo.Sheets[0].Cells[4, 1].Value = out_node.GetString("RES_STS_7");
                spdResInfo.Sheets[0].Cells[4, 3].Value = out_node.GetString("RES_STS_8");
                spdResInfo.Sheets[0].Cells[5, 1].Value = out_node.GetString("RES_STS_9");
                spdResInfo.Sheets[0].Cells[5, 3].Value = out_node.GetString("RES_STS_10");

                if (out_node.GetChar("USE_FAC_PRT_FLAG") == 'Y')
                {
                    View_Factory_ResStatus();
                }
                else
                {
                    spdResInfo.Sheets[0].Cells[1, 0].Value = out_node.GetString("RES_STS_PRT_1");
                    spdResInfo.Sheets[0].Cells[1, 2].Value = out_node.GetString("RES_STS_PRT_2");
                    spdResInfo.Sheets[0].Cells[2, 0].Value = out_node.GetString("RES_STS_PRT_3");
                    spdResInfo.Sheets[0].Cells[2, 2].Value = out_node.GetString("RES_STS_PRT_4");
                    spdResInfo.Sheets[0].Cells[3, 0].Value = out_node.GetString("RES_STS_PRT_5");
                    spdResInfo.Sheets[0].Cells[3, 2].Value = out_node.GetString("RES_STS_PRT_6");
                    spdResInfo.Sheets[0].Cells[4, 0].Value = out_node.GetString("RES_STS_PRT_7");
                    spdResInfo.Sheets[0].Cells[4, 2].Value = out_node.GetString("RES_STS_PRT_8");
                    spdResInfo.Sheets[0].Cells[5, 0].Value = out_node.GetString("RES_STS_PRT_9");
                    spdResInfo.Sheets[0].Cells[5, 2].Value = out_node.GetString("RES_STS_PRT_10");
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

                spdResInfo.Sheets[0].Cells[1, 0].Value = out_node.GetString("RES_STS_1");
                spdResInfo.Sheets[0].Cells[1, 2].Value = out_node.GetString("RES_STS_2");
                spdResInfo.Sheets[0].Cells[2, 0].Value = out_node.GetString("RES_STS_3");
                spdResInfo.Sheets[0].Cells[2, 2].Value = out_node.GetString("RES_STS_4");
                spdResInfo.Sheets[0].Cells[3, 0].Value = out_node.GetString("RES_STS_5");
                spdResInfo.Sheets[0].Cells[3, 2].Value = out_node.GetString("RES_STS_6");
                spdResInfo.Sheets[0].Cells[4, 0].Value = out_node.GetString("RES_STS_7");
                spdResInfo.Sheets[0].Cells[4, 2].Value = out_node.GetString("RES_STS_8");
                spdResInfo.Sheets[0].Cells[5, 0].Value = out_node.GetString("RES_STS_9");
                spdResInfo.Sheets[0].Cells[5, 2].Value = out_node.GetString("RES_STS_10");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // End Batch()
        //       - End Batch
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool End_Batch(char ProcStep)
        {
            TRSNode in_node = new TRSNode("END_BATCH_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddString("OPER", GetOperation(0));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                in_node.AddString("PORT_ID", MPCF.Trim(cdvPortID.Text));

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

                if (MPCR.CallService("WIP", "WIP_End_Batch", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtBatchID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPTranEndBatch_Load(object sender, System.EventArgs e)
        {
            pnlTranTime.Visible = MPGO.UseBackDate();
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
            lisLotListTemp.Visible = false;
            
        }
        
        private void frmWIPTranEndtBatch_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    ClearData("1");
                    MPCR.SetCMFItem(MPGC.MP_CMF_TRN_END, "lblCMF", "cdvCMF", grpCMF);
                    MPCF.InitListView(lisLotList);
                    
                    if (MPGV.gaSelectLot_ID.Count > 0)
                    {
                        txtBatchID.Text = MPGV.gaSelectLot_ID[0].ToString();
                    }
                    
                    if (MPGV.gaSelectLot_ID.Count > 0)
                    {
                        View_Batch_Lot_List();
                        if (lisLotList.Items.Count > 0)
                        {
                            cdvResID.Text = GetResID(0);
                            if (MPCF.Trim(cdvResID.Text) != "")
                            {
                                View_Resource();
                            }
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
                if (CheckCondition("END_BATCH") == true)
                {
                    if (End_Batch('1') == false)
                    {
                        return;
                    }
                    ClearData("1");
                    lisLotList.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void txtBatchID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnView.PerformClick();
            }
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
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            if (GetOperation(0) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(154) + " [Operation]");
                return;
            }
            
            if (GetResourceIDList() == false)
            {
                return;
            }
        }
        
        private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            txtTranDateTime.Visible = ! chkTranDateTime.Checked;
            
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
        }

        private void cdvCMF_ButtonPress(object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        private void txtLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (View_Lot() == false) return;

                btnView.PerformClick();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (txtBatchID.Text == "" && txtLotID.Text != "")
            {
                if (View_Lot() == false) return;
            }

            if (txtBatchID.Text != "")
            {
                ClearData("2");
            }
        }

        private void cdvPortID_ButtonPress(object sender, EventArgs e)
        {
            if (cdvResID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108) + " [Reousrce ID]");
                cdvResID.Focus();
                return;
            }

            if (GetPortIDList() == false)
            {
                return;
            }
        }

    }
    
}
