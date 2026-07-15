
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;
using Miracom.TRSCore;
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCTranCollectLotDataType3.vb
//   Description : Collect EDC Data by Character
//
//   SPC Version : 1.0.0
//
//   Function List
//       - CheckCondition : Check the conditions before transaction
//       - View_Lot : View Lot Information
//       - SetChartControl : Set Chart Control
//       - SetCollectData : Set Collection Information
//       - EnableInput : Set Enable Property
//
//   Detail Description
//       -
//
//   History
//       - 2005-05-09 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCTranCollectLotDataType3 : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranCollectLotDataType3()
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
        



        protected System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnRawData;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlCenter;
        internal System.Windows.Forms.GroupBox grpLot;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvProcResID;
        internal System.Windows.Forms.Label lblProcResID;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvProcOper;
        internal System.Windows.Forms.Label lblProcOper;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        internal System.Windows.Forms.Label lblResID;
        internal System.Windows.Forms.Label lblOper;
        protected System.Windows.Forms.GroupBox grpLotID;
        protected System.Windows.Forms.Panel pnlTranTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtTranTime;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtTranTime;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccTranDate;
        protected Infragistics.Win.UltraWinEditors.UltraCheckEditor chkTranDateTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDesc;
        protected System.Windows.Forms.Label lblLotDesc;
        protected System.Windows.Forms.Label lblLotID;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartSetID;
        internal System.Windows.Forms.Label lblChartSetID;
        internal System.Windows.Forms.GroupBox grpChartSet;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtLot;
        internal System.Windows.Forms.Panel pnlChartSet;
        internal System.Windows.Forms.Button btnGraph;
        internal System.Windows.Forms.Button btnHistogram;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvUserID;
        internal System.Windows.Forms.Label lblUserID;
        internal System.Windows.Forms.GroupBox grpComment;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtComment;
        internal System.Windows.Forms.Label lblComment;
        internal FarPoint.Win.Spread.FpSpread spdData;
        internal FarPoint.Win.Spread.SheetView spdData_Sheet1;
        internal System.Windows.Forms.Button btnReset;
        protected Infragistics.Win.UltraWinEditors.UltraCheckEditor chkSelectMFO;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranCollectLotDataType3));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType7 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType8 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType9 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType10 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType11 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType12 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType13 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType14 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType15 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType16 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType17 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType18 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType19 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType20 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType21 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType22 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType23 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType24 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType25 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType26 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType27 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType28 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType29 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType30 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType31 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType32 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType33 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType34 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType35 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType36 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType37 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType38 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType39 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType40 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType41 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType42 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType43 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType44 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType45 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType46 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType47 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType48 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType49 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType50 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType51 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType52 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType53 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType54 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType55 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType56 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType57 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType58 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType59 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType60 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType61 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType62 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType63 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType64 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType65 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType66 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType67 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType68 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType69 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType70 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType71 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType72 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType73 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType74 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType75 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType76 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType77 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType78 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType79 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType80 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType81 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType82 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType83 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType84 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType85 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType86 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType87 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType88 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType89 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType90 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType91 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType92 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType93 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType94 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType95 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType96 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType97 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType98 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType99 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType100 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType101 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType102 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType103 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType104 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType105 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType106 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType107 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType108 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType109 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType110 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType111 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType112 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType113 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType114 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType115 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType116 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType117 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType118 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType119 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType120 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType121 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType122 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType123 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType124 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType125 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType126 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType127 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType128 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType129 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType130 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType131 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType132 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType133 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType134 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType135 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType136 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType137 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType138 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType139 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType140 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType141 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType142 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType143 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType144 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType145 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType146 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType147 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType148 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType149 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType150 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType151 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType152 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType153 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType154 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType155 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType156 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType157 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType158 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType159 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType160 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType161 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType162 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType163 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType164 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType165 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType166 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType167 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType168 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType169 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType170 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType171 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType172 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType173 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType174 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType175 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType176 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType177 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType178 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType179 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType180 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType181 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType182 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType183 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType184 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType185 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType186 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType187 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType188 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType189 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType190 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType191 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType192 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType193 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType194 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType195 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType196 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType197 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType198 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType199 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType200 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType201 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType202 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType203 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType204 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType205 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType206 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType207 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType208 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType209 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType210 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType211 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType212 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType213 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType214 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType215 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType216 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType217 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType218 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType219 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType220 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType221 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType222 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType223 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType224 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType225 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType226 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType227 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType228 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType229 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType230 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType231 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType232 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType233 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType234 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType235 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType236 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType237 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType238 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType239 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType240 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType241 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType242 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType243 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType244 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType245 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType246 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType247 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType248 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType249 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType250 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType251 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType252 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType253 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType254 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType255 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType256 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType257 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType258 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType259 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType260 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType261 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType262 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType263 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType264 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType265 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType266 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType267 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType268 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType269 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType270 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType271 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType272 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType273 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType274 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType275 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType276 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType277 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType278 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType279 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType280 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType281 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType282 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType283 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType284 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType285 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType286 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType287 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType288 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType289 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType290 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType291 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType292 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType293 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType294 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType295 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType296 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType297 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType298 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType299 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType300 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType301 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType302 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType303 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType304 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType305 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType306 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType307 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType308 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType309 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType310 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType311 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType312 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType313 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType314 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType315 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType316 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType317 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType318 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType319 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType320 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType321 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType322 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType323 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType324 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType325 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType326 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType327 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType328 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType329 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType330 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType331 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType332 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType333 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType334 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType335 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType336 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType337 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType338 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType339 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType340 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType341 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType342 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType343 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType344 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType345 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType346 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType347 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType348 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType349 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType350 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType351 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType352 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType353 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType354 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType355 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType356 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType357 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType358 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType359 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType360 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType361 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType362 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType363 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType364 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType365 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType366 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType367 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType368 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType369 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType370 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType371 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType372 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType373 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType374 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType375 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType376 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType377 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType378 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType379 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType380 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType381 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType382 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType383 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType384 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType385 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType386 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType387 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType388 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType389 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType390 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType391 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType392 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType393 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType394 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType395 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType396 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType397 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType398 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType399 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType400 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType401 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType402 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType403 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType404 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType405 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType406 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType407 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType408 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType409 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType410 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType411 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType412 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType413 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType414 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType415 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType416 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType417 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType418 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType419 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType420 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType421 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType422 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType423 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType424 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType425 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType426 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType427 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType428 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType429 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType430 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType431 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType432 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType433 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType434 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType435 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType436 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType437 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType438 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType439 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType440 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType441 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType442 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType443 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType444 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType445 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType446 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType447 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType448 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType449 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType450 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType451 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType452 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType453 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType454 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType455 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType456 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType457 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType458 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType459 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType460 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType461 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType462 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType463 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType464 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType465 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType466 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType467 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType468 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType469 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType470 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType471 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType472 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType473 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType474 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType475 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType476 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType477 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType478 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType479 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType480 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType481 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType482 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType483 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType484 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType485 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType486 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType487 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType488 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType489 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType490 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType491 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType492 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType493 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType494 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType495 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType496 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType497 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType498 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType499 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType500 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType501 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType502 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType503 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType504 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType505 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType506 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType507 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType508 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType509 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType510 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType511 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType512 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType513 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType514 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType515 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType516 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType517 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType518 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType519 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType520 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType521 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType522 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType523 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType524 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType525 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType526 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType527 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType528 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType529 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType530 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType531 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType532 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType533 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType534 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType535 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType536 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType537 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType538 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType539 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType540 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType541 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType542 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType543 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType544 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType545 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType546 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType547 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType548 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType549 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType550 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType551 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType552 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType553 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType554 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType555 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType556 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType557 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType558 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType559 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType560 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType561 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType562 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType563 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType564 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType565 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType566 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType567 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType568 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType569 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType570 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType571 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType572 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType573 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType574 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType575 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType576 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType577 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType578 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType579 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType580 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType581 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType582 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType583 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType584 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType585 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType586 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType587 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType588 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType589 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType590 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType591 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType592 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType593 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType594 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType595 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType596 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType597 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType598 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType599 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType600 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType601 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType602 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType603 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType604 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType605 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType606 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType607 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType608 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType609 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType610 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType611 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType612 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType613 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType614 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType615 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType616 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType617 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType618 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType619 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType620 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType621 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType622 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType623 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType624 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType625 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType626 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType627 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType628 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType629 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType630 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType631 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType632 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType633 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType634 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType635 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType636 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType637 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType638 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType639 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType640 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType641 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType642 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType643 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType644 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType645 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType646 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType647 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType648 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType649 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType650 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType651 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType652 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType653 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType654 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType655 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType656 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType657 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType658 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType659 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType660 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType661 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType662 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType663 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType664 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType665 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType666 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType667 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType668 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType669 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType670 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType671 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType672 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType673 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType674 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType675 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType676 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType677 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType678 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType679 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType680 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType681 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType682 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType683 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType684 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType685 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType686 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType687 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType688 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType689 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType690 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType691 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType692 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType693 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType694 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType695 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType696 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType697 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType698 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType699 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType700 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType701 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType702 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType703 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType704 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType705 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType706 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType707 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType708 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType709 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType710 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType711 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType712 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType713 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType714 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType715 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType716 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType717 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType718 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType719 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType720 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType721 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType722 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType723 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType724 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType725 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType726 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType727 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType728 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType729 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType730 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType731 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType732 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType733 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType734 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType735 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType736 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType737 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType738 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType739 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType740 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType741 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType742 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType743 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType744 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType745 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType746 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType747 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType748 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType749 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType750 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType751 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType752 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType753 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType754 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType755 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType756 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType757 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType758 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType759 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType760 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType761 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType762 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType763 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType764 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType765 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType766 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType767 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType768 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType769 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType770 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType771 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType772 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType773 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType774 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType775 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType776 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType777 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType778 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType779 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType780 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType781 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType782 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType783 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType784 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType785 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType786 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType787 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType788 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType789 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType790 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType791 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType792 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType793 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType794 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType795 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType796 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType797 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType798 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType799 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType800 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType801 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType802 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType803 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType804 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType805 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType806 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType807 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType808 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType809 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType810 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType811 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType812 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType813 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType814 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType815 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType816 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType817 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType818 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType819 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType820 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType821 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType822 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType823 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType824 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType825 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType826 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType827 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType828 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType829 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType830 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType831 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType832 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType833 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType834 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType835 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType836 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType837 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType838 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType839 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType840 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType841 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType842 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType843 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType844 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType845 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType846 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType847 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType848 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType849 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType850 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType851 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType852 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType853 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType854 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType855 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType856 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType857 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType858 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType859 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType860 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType861 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType862 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType863 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType864 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType865 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType866 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType867 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType868 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType869 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType870 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType871 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType872 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType873 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType874 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType875 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType876 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType877 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType878 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType879 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType880 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType881 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType882 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType883 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType884 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType885 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType886 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType887 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType888 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType889 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType890 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType891 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType892 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType893 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType894 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType895 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType896 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType897 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType898 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType899 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType900 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType901 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType902 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType903 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType904 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType905 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType906 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType907 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType908 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType909 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType910 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType911 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType912 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType913 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType914 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType915 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType916 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType917 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType918 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType919 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType920 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType921 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType922 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType923 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType924 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType925 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType926 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType927 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType928 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType929 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType930 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType931 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType932 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType933 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType934 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType935 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType936 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType937 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType938 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType939 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType940 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType941 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType942 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType943 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType944 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType945 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType946 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType947 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType948 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType949 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType950 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType951 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType952 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType953 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType954 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType955 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType956 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType957 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType958 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType959 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType960 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType961 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType962 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType963 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType964 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType965 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType966 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType967 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType968 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType969 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType970 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType971 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType972 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType973 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType974 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType975 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType976 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType977 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType978 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType979 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType980 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType981 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType982 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType983 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType984 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType985 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType986 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType987 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType988 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType989 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType990 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType991 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType992 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType993 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType994 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType995 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType996 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType997 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType998 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType999 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1000 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1001 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1002 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1003 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1004 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1005 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1006 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1007 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1008 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1009 = new FarPoint.Win.Spread.CellType.TextCellType();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.btnRawData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlChartSet = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblComment = new System.Windows.Forms.Label();
            this.grpChartSet = new System.Windows.Forms.GroupBox();
            this.cdvUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUserID = new System.Windows.Forms.Label();
            this.cdvChartSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartSetID = new System.Windows.Forms.Label();
            this.grpLot = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkSelectMFO = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cdvProcResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcResID = new System.Windows.Forms.Label();
            this.cdvProcOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcOper = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblOper = new System.Windows.Forms.Label();
            this.grpLotID = new System.Windows.Forms.GroupBox();
            this.txtLot = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.udtTranTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccTranDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.chkTranDateTime = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtDesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblLotDesc = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlChartSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.grpComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            this.grpChartSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).BeginInit();
            this.grpLot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectMFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.grpLotID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLot)).BeginInit();
            this.pnlTranTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTranTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTranTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTranDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTranDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            this.SuspendLayout();
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnReset);
            this.pnlBottom.Controls.Add(this.btnHistogram);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnGraph);
            this.pnlBottom.Controls.Add(this.btnRawData);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 596);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.pnlBottom.Size = new System.Drawing.Size(792, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReset.Location = new System.Drawing.Point(330, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 26);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnHistogram
            // 
            this.btnHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistogram.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHistogram.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistogram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHistogram.Location = new System.Drawing.Point(424, 8);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(88, 26);
            this.btnHistogram.TabIndex = 2;
            this.btnHistogram.Text = "Histogram";
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(237, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 26);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraph.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraph.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGraph.Location = new System.Drawing.Point(516, 8);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(88, 26);
            this.btnGraph.TabIndex = 3;
            this.btnGraph.Text = "Control Chart";
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // btnRawData
            // 
            this.btnRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRawData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRawData.Location = new System.Drawing.Point(608, 8);
            this.btnRawData.Name = "btnRawData";
            this.btnRawData.Size = new System.Drawing.Size(88, 26);
            this.btnRawData.TabIndex = 4;
            this.btnRawData.Text = "Raw Data";
            this.btnRawData.Click += new System.EventHandler(this.btnRawData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(700, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlChartSet);
            this.pnlCenter.Controls.Add(this.grpChartSet);
            this.pnlCenter.Controls.Add(this.grpLot);
            this.pnlCenter.Controls.Add(this.grpLotID);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(792, 596);
            this.pnlCenter.TabIndex = 0;
            // 
            // pnlChartSet
            // 
            this.pnlChartSet.AutoScroll = true;
            this.pnlChartSet.Controls.Add(this.spdData);
            this.pnlChartSet.Controls.Add(this.grpComment);
            this.pnlChartSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartSet.Location = new System.Drawing.Point(3, 240);
            this.pnlChartSet.Name = "pnlChartSet";
            this.pnlChartSet.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlChartSet.Size = new System.Drawing.Size(786, 356);
            this.pnlChartSet.TabIndex = 3;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.EditModeReplace = true;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 4;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 2);
            this.spdData.Name = "spdData";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer1;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer1;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.SystemColors.Control;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = cornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle4.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle4.Renderer = generalCellType1;
            this.spdData.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(786, 314);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 14;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 5;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.EditModeOff += new System.EventHandler(this.spdData_EditModeOff);
            this.spdData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spdData_KeyDown);
            this.spdData.SetViewportLeftColumn(0, 0, 1);
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 1019;
            spdData_Sheet1.ColumnHeader.RowCount = 2;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Chart ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Chart Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Locked = false;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Result";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Unit ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Nominal";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Process Sigma";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).ColumnSpan = 1000;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "      Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1007).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1007).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1007).Value = "Weight Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1007).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1008).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1008).Locked = false;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1008).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1008).Value = "Average";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1008).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1009).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1009).Locked = false;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1009).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1009).Value = "Sigma";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1009).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1010).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1010).Locked = false;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1010).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1010).Value = "Range";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1010).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1011).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1011).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1011).Value = "Max Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1011).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1012).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1012).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1012).Value = "Min Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1012).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 100F;
            this.spdData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 100F;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 80F;
            this.spdData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Locked = true;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(4).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 80F;
            this.spdData_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(5).CellType = textCellType2;
            this.spdData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Width = 80F;
            this.spdData_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(6).CellType = textCellType3;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 80F;
            this.spdData_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(7).CellType = textCellType4;
            this.spdData_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(8).CellType = textCellType5;
            this.spdData_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(9).CellType = textCellType6;
            this.spdData_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(10).CellType = textCellType7;
            this.spdData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(11).CellType = textCellType8;
            this.spdData_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(12).CellType = textCellType9;
            this.spdData_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(13).CellType = textCellType10;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(14).CellType = textCellType11;
            this.spdData_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(15).CellType = textCellType12;
            this.spdData_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(16).CellType = textCellType13;
            this.spdData_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(17).CellType = textCellType14;
            this.spdData_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(18).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(18).CellType = textCellType15;
            this.spdData_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(19).CellType = textCellType16;
            this.spdData_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(20).CellType = textCellType17;
            this.spdData_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(21).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(21).CellType = textCellType18;
            this.spdData_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(22).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(22).CellType = textCellType19;
            this.spdData_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(23).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(23).CellType = textCellType20;
            this.spdData_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(24).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(24).CellType = textCellType21;
            this.spdData_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(25).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(25).CellType = textCellType22;
            this.spdData_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(26).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(26).CellType = textCellType23;
            this.spdData_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(27).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(27).CellType = textCellType24;
            this.spdData_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(28).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(28).CellType = textCellType25;
            this.spdData_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(29).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(29).CellType = textCellType26;
            this.spdData_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(30).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(30).CellType = textCellType27;
            this.spdData_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(31).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(31).CellType = textCellType28;
            this.spdData_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(32).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(32).CellType = textCellType29;
            this.spdData_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(33).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(33).CellType = textCellType30;
            this.spdData_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(34).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(34).CellType = textCellType31;
            this.spdData_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(35).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(35).CellType = textCellType32;
            this.spdData_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(36).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(36).CellType = textCellType33;
            this.spdData_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(37).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(37).CellType = textCellType34;
            this.spdData_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(38).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(38).CellType = textCellType35;
            this.spdData_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(39).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(39).CellType = textCellType36;
            this.spdData_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(40).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(40).CellType = textCellType37;
            this.spdData_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(41).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(41).CellType = textCellType38;
            this.spdData_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(42).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(42).CellType = textCellType39;
            this.spdData_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(43).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(43).CellType = textCellType40;
            this.spdData_Sheet1.Columns.Get(43).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(44).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(44).CellType = textCellType41;
            this.spdData_Sheet1.Columns.Get(44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(45).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(45).CellType = textCellType42;
            this.spdData_Sheet1.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(46).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(46).CellType = textCellType43;
            this.spdData_Sheet1.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(47).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(47).CellType = textCellType44;
            this.spdData_Sheet1.Columns.Get(47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(48).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(48).CellType = textCellType45;
            this.spdData_Sheet1.Columns.Get(48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(49).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(49).CellType = textCellType46;
            this.spdData_Sheet1.Columns.Get(49).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(50).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(50).CellType = textCellType47;
            this.spdData_Sheet1.Columns.Get(50).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(51).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(51).CellType = textCellType48;
            this.spdData_Sheet1.Columns.Get(51).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(52).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(52).CellType = textCellType49;
            this.spdData_Sheet1.Columns.Get(52).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(53).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(53).CellType = textCellType50;
            this.spdData_Sheet1.Columns.Get(53).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(54).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(54).CellType = textCellType51;
            this.spdData_Sheet1.Columns.Get(54).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(55).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(55).CellType = textCellType52;
            this.spdData_Sheet1.Columns.Get(55).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(56).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(56).CellType = textCellType53;
            this.spdData_Sheet1.Columns.Get(56).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(57).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(57).CellType = textCellType54;
            this.spdData_Sheet1.Columns.Get(57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(58).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(58).CellType = textCellType55;
            this.spdData_Sheet1.Columns.Get(58).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(59).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(59).CellType = textCellType56;
            this.spdData_Sheet1.Columns.Get(59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(60).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(60).CellType = textCellType57;
            this.spdData_Sheet1.Columns.Get(60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(61).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(61).CellType = textCellType58;
            this.spdData_Sheet1.Columns.Get(61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(62).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(62).CellType = textCellType59;
            this.spdData_Sheet1.Columns.Get(62).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(63).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(63).CellType = textCellType60;
            this.spdData_Sheet1.Columns.Get(63).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(64).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(64).CellType = textCellType61;
            this.spdData_Sheet1.Columns.Get(64).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(65).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(65).CellType = textCellType62;
            this.spdData_Sheet1.Columns.Get(65).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(66).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(66).CellType = textCellType63;
            this.spdData_Sheet1.Columns.Get(66).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(67).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(67).CellType = textCellType64;
            this.spdData_Sheet1.Columns.Get(67).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(68).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(68).CellType = textCellType65;
            this.spdData_Sheet1.Columns.Get(68).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(69).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(69).CellType = textCellType66;
            this.spdData_Sheet1.Columns.Get(69).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(70).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(70).CellType = textCellType67;
            this.spdData_Sheet1.Columns.Get(70).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(71).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(71).CellType = textCellType68;
            this.spdData_Sheet1.Columns.Get(71).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(72).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(72).CellType = textCellType69;
            this.spdData_Sheet1.Columns.Get(72).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(73).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(73).CellType = textCellType70;
            this.spdData_Sheet1.Columns.Get(73).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(74).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(74).CellType = textCellType71;
            this.spdData_Sheet1.Columns.Get(74).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(75).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(75).CellType = textCellType72;
            this.spdData_Sheet1.Columns.Get(75).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(76).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(76).CellType = textCellType73;
            this.spdData_Sheet1.Columns.Get(76).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(77).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(77).CellType = textCellType74;
            this.spdData_Sheet1.Columns.Get(77).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(78).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(78).CellType = textCellType75;
            this.spdData_Sheet1.Columns.Get(78).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(79).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(79).CellType = textCellType76;
            this.spdData_Sheet1.Columns.Get(79).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(80).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(80).CellType = textCellType77;
            this.spdData_Sheet1.Columns.Get(80).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(81).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(81).CellType = textCellType78;
            this.spdData_Sheet1.Columns.Get(81).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(82).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(82).CellType = textCellType79;
            this.spdData_Sheet1.Columns.Get(82).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(83).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(83).CellType = textCellType80;
            this.spdData_Sheet1.Columns.Get(83).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(84).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(84).CellType = textCellType81;
            this.spdData_Sheet1.Columns.Get(84).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(85).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(85).CellType = textCellType82;
            this.spdData_Sheet1.Columns.Get(85).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(85).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(86).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(86).CellType = textCellType83;
            this.spdData_Sheet1.Columns.Get(86).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(86).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(87).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(87).CellType = textCellType84;
            this.spdData_Sheet1.Columns.Get(87).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(87).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(88).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(88).CellType = textCellType85;
            this.spdData_Sheet1.Columns.Get(88).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(88).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(89).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(89).CellType = textCellType86;
            this.spdData_Sheet1.Columns.Get(89).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(89).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(90).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(90).CellType = textCellType87;
            this.spdData_Sheet1.Columns.Get(90).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(90).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(91).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(91).CellType = textCellType88;
            this.spdData_Sheet1.Columns.Get(91).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(91).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(92).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(92).CellType = textCellType89;
            this.spdData_Sheet1.Columns.Get(92).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(92).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(93).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(93).CellType = textCellType90;
            this.spdData_Sheet1.Columns.Get(93).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(93).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(94).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(94).CellType = textCellType91;
            this.spdData_Sheet1.Columns.Get(94).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(94).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(95).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(95).CellType = textCellType92;
            this.spdData_Sheet1.Columns.Get(95).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(95).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(96).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(96).CellType = textCellType93;
            this.spdData_Sheet1.Columns.Get(96).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(96).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(97).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(97).CellType = textCellType94;
            this.spdData_Sheet1.Columns.Get(97).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(97).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(98).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(98).CellType = textCellType95;
            this.spdData_Sheet1.Columns.Get(98).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(98).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(99).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(99).CellType = textCellType96;
            this.spdData_Sheet1.Columns.Get(99).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(99).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(100).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(100).CellType = textCellType97;
            this.spdData_Sheet1.Columns.Get(100).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(100).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(101).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(101).CellType = textCellType98;
            this.spdData_Sheet1.Columns.Get(101).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(101).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(102).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(102).CellType = textCellType99;
            this.spdData_Sheet1.Columns.Get(102).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(102).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(103).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(103).CellType = textCellType100;
            this.spdData_Sheet1.Columns.Get(103).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(103).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(104).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(104).CellType = textCellType101;
            this.spdData_Sheet1.Columns.Get(104).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(104).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(105).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(105).CellType = textCellType102;
            this.spdData_Sheet1.Columns.Get(105).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(105).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(106).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(106).CellType = textCellType103;
            this.spdData_Sheet1.Columns.Get(106).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(106).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(107).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(107).CellType = textCellType104;
            this.spdData_Sheet1.Columns.Get(107).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(107).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(108).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(108).CellType = textCellType105;
            this.spdData_Sheet1.Columns.Get(108).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(108).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(109).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(109).CellType = textCellType106;
            this.spdData_Sheet1.Columns.Get(109).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(109).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(110).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(110).CellType = textCellType107;
            this.spdData_Sheet1.Columns.Get(110).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(110).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(111).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(111).CellType = textCellType108;
            this.spdData_Sheet1.Columns.Get(111).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(111).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(112).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(112).CellType = textCellType109;
            this.spdData_Sheet1.Columns.Get(112).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(112).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(113).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(113).CellType = textCellType110;
            this.spdData_Sheet1.Columns.Get(113).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(113).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(114).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(114).CellType = textCellType111;
            this.spdData_Sheet1.Columns.Get(114).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(114).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(115).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(115).CellType = textCellType112;
            this.spdData_Sheet1.Columns.Get(115).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(115).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(116).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(116).CellType = textCellType113;
            this.spdData_Sheet1.Columns.Get(116).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(116).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(117).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(117).CellType = textCellType114;
            this.spdData_Sheet1.Columns.Get(117).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(117).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(118).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(118).CellType = textCellType115;
            this.spdData_Sheet1.Columns.Get(118).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(118).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(119).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(119).CellType = textCellType116;
            this.spdData_Sheet1.Columns.Get(119).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(119).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(120).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(120).CellType = textCellType117;
            this.spdData_Sheet1.Columns.Get(120).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(120).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(121).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(121).CellType = textCellType118;
            this.spdData_Sheet1.Columns.Get(121).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(121).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(122).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(122).CellType = textCellType119;
            this.spdData_Sheet1.Columns.Get(122).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(122).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(123).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(123).CellType = textCellType120;
            this.spdData_Sheet1.Columns.Get(123).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(123).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(124).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(124).CellType = textCellType121;
            this.spdData_Sheet1.Columns.Get(124).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(124).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(125).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(125).CellType = textCellType122;
            this.spdData_Sheet1.Columns.Get(125).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(125).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(126).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(126).CellType = textCellType123;
            this.spdData_Sheet1.Columns.Get(126).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(126).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(127).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(127).CellType = textCellType124;
            this.spdData_Sheet1.Columns.Get(127).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(127).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(128).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(128).CellType = textCellType125;
            this.spdData_Sheet1.Columns.Get(128).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(128).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(129).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(129).CellType = textCellType126;
            this.spdData_Sheet1.Columns.Get(129).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(129).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(130).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(130).CellType = textCellType127;
            this.spdData_Sheet1.Columns.Get(130).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(130).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(131).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(131).CellType = textCellType128;
            this.spdData_Sheet1.Columns.Get(131).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(131).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(132).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(132).CellType = textCellType129;
            this.spdData_Sheet1.Columns.Get(132).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(132).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(133).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(133).CellType = textCellType130;
            this.spdData_Sheet1.Columns.Get(133).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(133).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(134).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(134).CellType = textCellType131;
            this.spdData_Sheet1.Columns.Get(134).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(134).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(135).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(135).CellType = textCellType132;
            this.spdData_Sheet1.Columns.Get(135).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(135).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(136).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(136).CellType = textCellType133;
            this.spdData_Sheet1.Columns.Get(136).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(136).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(137).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(137).CellType = textCellType134;
            this.spdData_Sheet1.Columns.Get(137).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(137).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(138).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(138).CellType = textCellType135;
            this.spdData_Sheet1.Columns.Get(138).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(138).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(139).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(139).CellType = textCellType136;
            this.spdData_Sheet1.Columns.Get(139).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(139).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(140).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(140).CellType = textCellType137;
            this.spdData_Sheet1.Columns.Get(140).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(140).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(141).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(141).CellType = textCellType138;
            this.spdData_Sheet1.Columns.Get(141).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(141).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(142).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(142).CellType = textCellType139;
            this.spdData_Sheet1.Columns.Get(142).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(142).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(143).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(143).CellType = textCellType140;
            this.spdData_Sheet1.Columns.Get(143).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(143).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(144).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(144).CellType = textCellType141;
            this.spdData_Sheet1.Columns.Get(144).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(144).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(145).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(145).CellType = textCellType142;
            this.spdData_Sheet1.Columns.Get(145).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(145).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(146).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(146).CellType = textCellType143;
            this.spdData_Sheet1.Columns.Get(146).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(146).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(147).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(147).CellType = textCellType144;
            this.spdData_Sheet1.Columns.Get(147).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(147).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(148).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(148).CellType = textCellType145;
            this.spdData_Sheet1.Columns.Get(148).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(148).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(149).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(149).CellType = textCellType146;
            this.spdData_Sheet1.Columns.Get(149).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(149).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(150).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(150).CellType = textCellType147;
            this.spdData_Sheet1.Columns.Get(150).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(150).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(151).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(151).CellType = textCellType148;
            this.spdData_Sheet1.Columns.Get(151).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(151).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(152).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(152).CellType = textCellType149;
            this.spdData_Sheet1.Columns.Get(152).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(152).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(153).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(153).CellType = textCellType150;
            this.spdData_Sheet1.Columns.Get(153).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(153).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(154).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(154).CellType = textCellType151;
            this.spdData_Sheet1.Columns.Get(154).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(154).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(155).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(155).CellType = textCellType152;
            this.spdData_Sheet1.Columns.Get(155).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(155).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(156).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(156).CellType = textCellType153;
            this.spdData_Sheet1.Columns.Get(156).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(156).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(157).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(157).CellType = textCellType154;
            this.spdData_Sheet1.Columns.Get(157).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(157).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(158).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(158).CellType = textCellType155;
            this.spdData_Sheet1.Columns.Get(158).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(158).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(159).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(159).CellType = textCellType156;
            this.spdData_Sheet1.Columns.Get(159).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(159).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(160).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(160).CellType = textCellType157;
            this.spdData_Sheet1.Columns.Get(160).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(160).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(161).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(161).CellType = textCellType158;
            this.spdData_Sheet1.Columns.Get(161).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(161).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(162).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(162).CellType = textCellType159;
            this.spdData_Sheet1.Columns.Get(162).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(162).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(163).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(163).CellType = textCellType160;
            this.spdData_Sheet1.Columns.Get(163).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(163).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(164).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(164).CellType = textCellType161;
            this.spdData_Sheet1.Columns.Get(164).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(164).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(165).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(165).CellType = textCellType162;
            this.spdData_Sheet1.Columns.Get(165).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(165).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(166).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(166).CellType = textCellType163;
            this.spdData_Sheet1.Columns.Get(166).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(166).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(167).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(167).CellType = textCellType164;
            this.spdData_Sheet1.Columns.Get(167).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(167).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(168).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(168).CellType = textCellType165;
            this.spdData_Sheet1.Columns.Get(168).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(168).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(169).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(169).CellType = textCellType166;
            this.spdData_Sheet1.Columns.Get(169).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(169).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(170).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(170).CellType = textCellType167;
            this.spdData_Sheet1.Columns.Get(170).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(170).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(171).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(171).CellType = textCellType168;
            this.spdData_Sheet1.Columns.Get(171).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(171).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(172).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(172).CellType = textCellType169;
            this.spdData_Sheet1.Columns.Get(172).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(172).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(173).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(173).CellType = textCellType170;
            this.spdData_Sheet1.Columns.Get(173).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(173).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(174).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(174).CellType = textCellType171;
            this.spdData_Sheet1.Columns.Get(174).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(174).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(175).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(175).CellType = textCellType172;
            this.spdData_Sheet1.Columns.Get(175).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(175).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(176).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(176).CellType = textCellType173;
            this.spdData_Sheet1.Columns.Get(176).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(176).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(177).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(177).CellType = textCellType174;
            this.spdData_Sheet1.Columns.Get(177).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(177).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(178).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(178).CellType = textCellType175;
            this.spdData_Sheet1.Columns.Get(178).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(178).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(179).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(179).CellType = textCellType176;
            this.spdData_Sheet1.Columns.Get(179).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(179).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(180).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(180).CellType = textCellType177;
            this.spdData_Sheet1.Columns.Get(180).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(180).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(181).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(181).CellType = textCellType178;
            this.spdData_Sheet1.Columns.Get(181).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(181).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(182).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(182).CellType = textCellType179;
            this.spdData_Sheet1.Columns.Get(182).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(182).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(183).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(183).CellType = textCellType180;
            this.spdData_Sheet1.Columns.Get(183).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(183).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(184).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(184).CellType = textCellType181;
            this.spdData_Sheet1.Columns.Get(184).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(184).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(185).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(185).CellType = textCellType182;
            this.spdData_Sheet1.Columns.Get(185).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(185).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(186).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(186).CellType = textCellType183;
            this.spdData_Sheet1.Columns.Get(186).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(186).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(187).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(187).CellType = textCellType184;
            this.spdData_Sheet1.Columns.Get(187).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(187).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(188).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(188).CellType = textCellType185;
            this.spdData_Sheet1.Columns.Get(188).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(188).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(189).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(189).CellType = textCellType186;
            this.spdData_Sheet1.Columns.Get(189).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(189).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(190).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(190).CellType = textCellType187;
            this.spdData_Sheet1.Columns.Get(190).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(190).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(191).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(191).CellType = textCellType188;
            this.spdData_Sheet1.Columns.Get(191).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(191).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(192).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(192).CellType = textCellType189;
            this.spdData_Sheet1.Columns.Get(192).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(192).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(193).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(193).CellType = textCellType190;
            this.spdData_Sheet1.Columns.Get(193).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(193).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(194).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(194).CellType = textCellType191;
            this.spdData_Sheet1.Columns.Get(194).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(194).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(195).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(195).CellType = textCellType192;
            this.spdData_Sheet1.Columns.Get(195).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(195).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(196).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(196).CellType = textCellType193;
            this.spdData_Sheet1.Columns.Get(196).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(196).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(197).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(197).CellType = textCellType194;
            this.spdData_Sheet1.Columns.Get(197).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(197).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(198).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(198).CellType = textCellType195;
            this.spdData_Sheet1.Columns.Get(198).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(198).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(199).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(199).CellType = textCellType196;
            this.spdData_Sheet1.Columns.Get(199).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(199).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(200).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(200).CellType = textCellType197;
            this.spdData_Sheet1.Columns.Get(200).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(200).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(201).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(201).CellType = textCellType198;
            this.spdData_Sheet1.Columns.Get(201).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(201).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(202).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(202).CellType = textCellType199;
            this.spdData_Sheet1.Columns.Get(202).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(202).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(203).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(203).CellType = textCellType200;
            this.spdData_Sheet1.Columns.Get(203).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(203).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(204).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(204).CellType = textCellType201;
            this.spdData_Sheet1.Columns.Get(204).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(204).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(205).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(205).CellType = textCellType202;
            this.spdData_Sheet1.Columns.Get(205).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(205).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(206).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(206).CellType = textCellType203;
            this.spdData_Sheet1.Columns.Get(206).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(206).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(207).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(207).CellType = textCellType204;
            this.spdData_Sheet1.Columns.Get(207).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(207).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(208).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(208).CellType = textCellType205;
            this.spdData_Sheet1.Columns.Get(208).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(208).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(209).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(209).CellType = textCellType206;
            this.spdData_Sheet1.Columns.Get(209).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(209).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(210).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(210).CellType = textCellType207;
            this.spdData_Sheet1.Columns.Get(210).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(210).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(211).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(211).CellType = textCellType208;
            this.spdData_Sheet1.Columns.Get(211).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(211).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(212).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(212).CellType = textCellType209;
            this.spdData_Sheet1.Columns.Get(212).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(212).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(213).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(213).CellType = textCellType210;
            this.spdData_Sheet1.Columns.Get(213).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(213).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(214).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(214).CellType = textCellType211;
            this.spdData_Sheet1.Columns.Get(214).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(214).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(215).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(215).CellType = textCellType212;
            this.spdData_Sheet1.Columns.Get(215).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(215).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(216).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(216).CellType = textCellType213;
            this.spdData_Sheet1.Columns.Get(216).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(216).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(217).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(217).CellType = textCellType214;
            this.spdData_Sheet1.Columns.Get(217).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(217).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(218).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(218).CellType = textCellType215;
            this.spdData_Sheet1.Columns.Get(218).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(218).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(219).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(219).CellType = textCellType216;
            this.spdData_Sheet1.Columns.Get(219).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(219).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(220).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(220).CellType = textCellType217;
            this.spdData_Sheet1.Columns.Get(220).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(220).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(221).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(221).CellType = textCellType218;
            this.spdData_Sheet1.Columns.Get(221).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(221).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(222).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(222).CellType = textCellType219;
            this.spdData_Sheet1.Columns.Get(222).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(222).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(223).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(223).CellType = textCellType220;
            this.spdData_Sheet1.Columns.Get(223).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(223).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(224).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(224).CellType = textCellType221;
            this.spdData_Sheet1.Columns.Get(224).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(224).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(225).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(225).CellType = textCellType222;
            this.spdData_Sheet1.Columns.Get(225).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(225).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(226).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(226).CellType = textCellType223;
            this.spdData_Sheet1.Columns.Get(226).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(226).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(227).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(227).CellType = textCellType224;
            this.spdData_Sheet1.Columns.Get(227).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(227).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(228).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(228).CellType = textCellType225;
            this.spdData_Sheet1.Columns.Get(228).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(228).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(229).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(229).CellType = textCellType226;
            this.spdData_Sheet1.Columns.Get(229).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(229).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(230).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(230).CellType = textCellType227;
            this.spdData_Sheet1.Columns.Get(230).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(230).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(231).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(231).CellType = textCellType228;
            this.spdData_Sheet1.Columns.Get(231).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(231).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(232).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(232).CellType = textCellType229;
            this.spdData_Sheet1.Columns.Get(232).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(232).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(233).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(233).CellType = textCellType230;
            this.spdData_Sheet1.Columns.Get(233).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(233).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(234).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(234).CellType = textCellType231;
            this.spdData_Sheet1.Columns.Get(234).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(234).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(235).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(235).CellType = textCellType232;
            this.spdData_Sheet1.Columns.Get(235).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(235).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(236).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(236).CellType = textCellType233;
            this.spdData_Sheet1.Columns.Get(236).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(236).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(237).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(237).CellType = textCellType234;
            this.spdData_Sheet1.Columns.Get(237).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(237).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(238).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(238).CellType = textCellType235;
            this.spdData_Sheet1.Columns.Get(238).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(238).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(239).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(239).CellType = textCellType236;
            this.spdData_Sheet1.Columns.Get(239).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(239).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(240).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(240).CellType = textCellType237;
            this.spdData_Sheet1.Columns.Get(240).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(240).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(241).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(241).CellType = textCellType238;
            this.spdData_Sheet1.Columns.Get(241).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(241).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(242).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(242).CellType = textCellType239;
            this.spdData_Sheet1.Columns.Get(242).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(242).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(243).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(243).CellType = textCellType240;
            this.spdData_Sheet1.Columns.Get(243).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(243).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(244).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(244).CellType = textCellType241;
            this.spdData_Sheet1.Columns.Get(244).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(244).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(245).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(245).CellType = textCellType242;
            this.spdData_Sheet1.Columns.Get(245).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(245).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(246).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(246).CellType = textCellType243;
            this.spdData_Sheet1.Columns.Get(246).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(246).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(247).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(247).CellType = textCellType244;
            this.spdData_Sheet1.Columns.Get(247).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(247).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(248).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(248).CellType = textCellType245;
            this.spdData_Sheet1.Columns.Get(248).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(248).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(249).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(249).CellType = textCellType246;
            this.spdData_Sheet1.Columns.Get(249).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(249).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(250).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(250).CellType = textCellType247;
            this.spdData_Sheet1.Columns.Get(250).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(250).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(251).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(251).CellType = textCellType248;
            this.spdData_Sheet1.Columns.Get(251).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(251).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(252).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(252).CellType = textCellType249;
            this.spdData_Sheet1.Columns.Get(252).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(252).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(253).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(253).CellType = textCellType250;
            this.spdData_Sheet1.Columns.Get(253).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(253).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(254).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(254).CellType = textCellType251;
            this.spdData_Sheet1.Columns.Get(254).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(254).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(255).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(255).CellType = textCellType252;
            this.spdData_Sheet1.Columns.Get(255).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(255).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(256).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(256).CellType = textCellType253;
            this.spdData_Sheet1.Columns.Get(256).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(256).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(257).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(257).CellType = textCellType254;
            this.spdData_Sheet1.Columns.Get(257).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(257).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(258).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(258).CellType = textCellType255;
            this.spdData_Sheet1.Columns.Get(258).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(258).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(259).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(259).CellType = textCellType256;
            this.spdData_Sheet1.Columns.Get(259).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(259).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(260).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(260).CellType = textCellType257;
            this.spdData_Sheet1.Columns.Get(260).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(260).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(261).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(261).CellType = textCellType258;
            this.spdData_Sheet1.Columns.Get(261).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(261).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(262).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(262).CellType = textCellType259;
            this.spdData_Sheet1.Columns.Get(262).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(262).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(263).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(263).CellType = textCellType260;
            this.spdData_Sheet1.Columns.Get(263).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(263).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(264).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(264).CellType = textCellType261;
            this.spdData_Sheet1.Columns.Get(264).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(264).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(265).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(265).CellType = textCellType262;
            this.spdData_Sheet1.Columns.Get(265).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(265).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(266).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(266).CellType = textCellType263;
            this.spdData_Sheet1.Columns.Get(266).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(266).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(267).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(267).CellType = textCellType264;
            this.spdData_Sheet1.Columns.Get(267).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(267).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(268).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(268).CellType = textCellType265;
            this.spdData_Sheet1.Columns.Get(268).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(268).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(269).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(269).CellType = textCellType266;
            this.spdData_Sheet1.Columns.Get(269).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(269).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(270).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(270).CellType = textCellType267;
            this.spdData_Sheet1.Columns.Get(270).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(270).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(271).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(271).CellType = textCellType268;
            this.spdData_Sheet1.Columns.Get(271).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(271).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(272).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(272).CellType = textCellType269;
            this.spdData_Sheet1.Columns.Get(272).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(272).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(273).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(273).CellType = textCellType270;
            this.spdData_Sheet1.Columns.Get(273).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(273).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(274).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(274).CellType = textCellType271;
            this.spdData_Sheet1.Columns.Get(274).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(274).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(275).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(275).CellType = textCellType272;
            this.spdData_Sheet1.Columns.Get(275).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(275).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(276).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(276).CellType = textCellType273;
            this.spdData_Sheet1.Columns.Get(276).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(276).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(277).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(277).CellType = textCellType274;
            this.spdData_Sheet1.Columns.Get(277).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(277).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(278).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(278).CellType = textCellType275;
            this.spdData_Sheet1.Columns.Get(278).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(278).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(279).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(279).CellType = textCellType276;
            this.spdData_Sheet1.Columns.Get(279).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(279).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(280).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(280).CellType = textCellType277;
            this.spdData_Sheet1.Columns.Get(280).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(280).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(281).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(281).CellType = textCellType278;
            this.spdData_Sheet1.Columns.Get(281).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(281).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(282).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(282).CellType = textCellType279;
            this.spdData_Sheet1.Columns.Get(282).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(282).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(283).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(283).CellType = textCellType280;
            this.spdData_Sheet1.Columns.Get(283).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(283).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(284).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(284).CellType = textCellType281;
            this.spdData_Sheet1.Columns.Get(284).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(284).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(285).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(285).CellType = textCellType282;
            this.spdData_Sheet1.Columns.Get(285).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(285).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(286).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(286).CellType = textCellType283;
            this.spdData_Sheet1.Columns.Get(286).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(286).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(287).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(287).CellType = textCellType284;
            this.spdData_Sheet1.Columns.Get(287).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(287).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(288).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(288).CellType = textCellType285;
            this.spdData_Sheet1.Columns.Get(288).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(288).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(289).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(289).CellType = textCellType286;
            this.spdData_Sheet1.Columns.Get(289).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(289).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(290).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(290).CellType = textCellType287;
            this.spdData_Sheet1.Columns.Get(290).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(290).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(291).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(291).CellType = textCellType288;
            this.spdData_Sheet1.Columns.Get(291).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(291).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(292).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(292).CellType = textCellType289;
            this.spdData_Sheet1.Columns.Get(292).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(292).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(293).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(293).CellType = textCellType290;
            this.spdData_Sheet1.Columns.Get(293).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(293).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(294).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(294).CellType = textCellType291;
            this.spdData_Sheet1.Columns.Get(294).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(294).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(295).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(295).CellType = textCellType292;
            this.spdData_Sheet1.Columns.Get(295).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(295).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(296).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(296).CellType = textCellType293;
            this.spdData_Sheet1.Columns.Get(296).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(296).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(297).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(297).CellType = textCellType294;
            this.spdData_Sheet1.Columns.Get(297).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(297).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(298).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(298).CellType = textCellType295;
            this.spdData_Sheet1.Columns.Get(298).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(298).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(299).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(299).CellType = textCellType296;
            this.spdData_Sheet1.Columns.Get(299).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(299).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(300).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(300).CellType = textCellType297;
            this.spdData_Sheet1.Columns.Get(300).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(300).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(301).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(301).CellType = textCellType298;
            this.spdData_Sheet1.Columns.Get(301).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(301).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(302).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(302).CellType = textCellType299;
            this.spdData_Sheet1.Columns.Get(302).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(302).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(303).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(303).CellType = textCellType300;
            this.spdData_Sheet1.Columns.Get(303).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(303).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(304).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(304).CellType = textCellType301;
            this.spdData_Sheet1.Columns.Get(304).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(304).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(305).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(305).CellType = textCellType302;
            this.spdData_Sheet1.Columns.Get(305).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(305).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(306).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(306).CellType = textCellType303;
            this.spdData_Sheet1.Columns.Get(306).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(306).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(307).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(307).CellType = textCellType304;
            this.spdData_Sheet1.Columns.Get(307).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(307).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(308).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(308).CellType = textCellType305;
            this.spdData_Sheet1.Columns.Get(308).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(308).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(309).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(309).CellType = textCellType306;
            this.spdData_Sheet1.Columns.Get(309).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(309).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(310).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(310).CellType = textCellType307;
            this.spdData_Sheet1.Columns.Get(310).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(310).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(311).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(311).CellType = textCellType308;
            this.spdData_Sheet1.Columns.Get(311).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(311).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(312).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(312).CellType = textCellType309;
            this.spdData_Sheet1.Columns.Get(312).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(312).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(313).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(313).CellType = textCellType310;
            this.spdData_Sheet1.Columns.Get(313).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(313).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(314).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(314).CellType = textCellType311;
            this.spdData_Sheet1.Columns.Get(314).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(314).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(315).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(315).CellType = textCellType312;
            this.spdData_Sheet1.Columns.Get(315).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(315).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(316).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(316).CellType = textCellType313;
            this.spdData_Sheet1.Columns.Get(316).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(316).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(317).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(317).CellType = textCellType314;
            this.spdData_Sheet1.Columns.Get(317).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(317).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(318).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(318).CellType = textCellType315;
            this.spdData_Sheet1.Columns.Get(318).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(318).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(319).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(319).CellType = textCellType316;
            this.spdData_Sheet1.Columns.Get(319).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(319).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(320).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(320).CellType = textCellType317;
            this.spdData_Sheet1.Columns.Get(320).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(320).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(321).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(321).CellType = textCellType318;
            this.spdData_Sheet1.Columns.Get(321).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(321).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(322).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(322).CellType = textCellType319;
            this.spdData_Sheet1.Columns.Get(322).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(322).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(323).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(323).CellType = textCellType320;
            this.spdData_Sheet1.Columns.Get(323).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(323).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(324).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(324).CellType = textCellType321;
            this.spdData_Sheet1.Columns.Get(324).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(324).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(325).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(325).CellType = textCellType322;
            this.spdData_Sheet1.Columns.Get(325).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(325).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(326).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(326).CellType = textCellType323;
            this.spdData_Sheet1.Columns.Get(326).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(326).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(327).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(327).CellType = textCellType324;
            this.spdData_Sheet1.Columns.Get(327).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(327).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(328).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(328).CellType = textCellType325;
            this.spdData_Sheet1.Columns.Get(328).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(328).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(329).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(329).CellType = textCellType326;
            this.spdData_Sheet1.Columns.Get(329).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(329).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(330).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(330).CellType = textCellType327;
            this.spdData_Sheet1.Columns.Get(330).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(330).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(331).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(331).CellType = textCellType328;
            this.spdData_Sheet1.Columns.Get(331).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(331).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(332).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(332).CellType = textCellType329;
            this.spdData_Sheet1.Columns.Get(332).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(332).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(333).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(333).CellType = textCellType330;
            this.spdData_Sheet1.Columns.Get(333).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(333).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(334).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(334).CellType = textCellType331;
            this.spdData_Sheet1.Columns.Get(334).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(334).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(335).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(335).CellType = textCellType332;
            this.spdData_Sheet1.Columns.Get(335).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(335).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(336).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(336).CellType = textCellType333;
            this.spdData_Sheet1.Columns.Get(336).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(336).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(337).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(337).CellType = textCellType334;
            this.spdData_Sheet1.Columns.Get(337).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(337).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(338).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(338).CellType = textCellType335;
            this.spdData_Sheet1.Columns.Get(338).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(338).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(339).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(339).CellType = textCellType336;
            this.spdData_Sheet1.Columns.Get(339).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(339).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(340).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(340).CellType = textCellType337;
            this.spdData_Sheet1.Columns.Get(340).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(340).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(341).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(341).CellType = textCellType338;
            this.spdData_Sheet1.Columns.Get(341).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(341).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(342).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(342).CellType = textCellType339;
            this.spdData_Sheet1.Columns.Get(342).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(342).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(343).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(343).CellType = textCellType340;
            this.spdData_Sheet1.Columns.Get(343).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(343).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(344).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(344).CellType = textCellType341;
            this.spdData_Sheet1.Columns.Get(344).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(344).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(345).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(345).CellType = textCellType342;
            this.spdData_Sheet1.Columns.Get(345).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(345).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(346).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(346).CellType = textCellType343;
            this.spdData_Sheet1.Columns.Get(346).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(346).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(347).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(347).CellType = textCellType344;
            this.spdData_Sheet1.Columns.Get(347).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(347).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(348).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(348).CellType = textCellType345;
            this.spdData_Sheet1.Columns.Get(348).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(348).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(349).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(349).CellType = textCellType346;
            this.spdData_Sheet1.Columns.Get(349).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(349).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(350).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(350).CellType = textCellType347;
            this.spdData_Sheet1.Columns.Get(350).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(350).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(351).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(351).CellType = textCellType348;
            this.spdData_Sheet1.Columns.Get(351).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(351).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(352).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(352).CellType = textCellType349;
            this.spdData_Sheet1.Columns.Get(352).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(352).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(353).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(353).CellType = textCellType350;
            this.spdData_Sheet1.Columns.Get(353).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(353).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(354).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(354).CellType = textCellType351;
            this.spdData_Sheet1.Columns.Get(354).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(354).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(355).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(355).CellType = textCellType352;
            this.spdData_Sheet1.Columns.Get(355).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(355).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(356).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(356).CellType = textCellType353;
            this.spdData_Sheet1.Columns.Get(356).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(356).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(357).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(357).CellType = textCellType354;
            this.spdData_Sheet1.Columns.Get(357).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(357).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(358).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(358).CellType = textCellType355;
            this.spdData_Sheet1.Columns.Get(358).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(358).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(359).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(359).CellType = textCellType356;
            this.spdData_Sheet1.Columns.Get(359).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(359).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(360).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(360).CellType = textCellType357;
            this.spdData_Sheet1.Columns.Get(360).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(360).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(361).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(361).CellType = textCellType358;
            this.spdData_Sheet1.Columns.Get(361).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(361).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(362).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(362).CellType = textCellType359;
            this.spdData_Sheet1.Columns.Get(362).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(362).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(363).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(363).CellType = textCellType360;
            this.spdData_Sheet1.Columns.Get(363).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(363).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(364).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(364).CellType = textCellType361;
            this.spdData_Sheet1.Columns.Get(364).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(364).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(365).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(365).CellType = textCellType362;
            this.spdData_Sheet1.Columns.Get(365).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(365).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(366).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(366).CellType = textCellType363;
            this.spdData_Sheet1.Columns.Get(366).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(366).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(367).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(367).CellType = textCellType364;
            this.spdData_Sheet1.Columns.Get(367).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(367).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(368).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(368).CellType = textCellType365;
            this.spdData_Sheet1.Columns.Get(368).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(368).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(369).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(369).CellType = textCellType366;
            this.spdData_Sheet1.Columns.Get(369).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(369).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(370).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(370).CellType = textCellType367;
            this.spdData_Sheet1.Columns.Get(370).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(370).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(371).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(371).CellType = textCellType368;
            this.spdData_Sheet1.Columns.Get(371).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(371).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(372).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(372).CellType = textCellType369;
            this.spdData_Sheet1.Columns.Get(372).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(372).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(373).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(373).CellType = textCellType370;
            this.spdData_Sheet1.Columns.Get(373).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(373).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(374).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(374).CellType = textCellType371;
            this.spdData_Sheet1.Columns.Get(374).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(374).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(375).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(375).CellType = textCellType372;
            this.spdData_Sheet1.Columns.Get(375).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(375).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(376).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(376).CellType = textCellType373;
            this.spdData_Sheet1.Columns.Get(376).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(376).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(377).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(377).CellType = textCellType374;
            this.spdData_Sheet1.Columns.Get(377).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(377).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(378).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(378).CellType = textCellType375;
            this.spdData_Sheet1.Columns.Get(378).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(378).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(379).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(379).CellType = textCellType376;
            this.spdData_Sheet1.Columns.Get(379).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(379).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(380).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(380).CellType = textCellType377;
            this.spdData_Sheet1.Columns.Get(380).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(380).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(381).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(381).CellType = textCellType378;
            this.spdData_Sheet1.Columns.Get(381).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(381).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(382).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(382).CellType = textCellType379;
            this.spdData_Sheet1.Columns.Get(382).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(382).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(383).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(383).CellType = textCellType380;
            this.spdData_Sheet1.Columns.Get(383).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(383).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(384).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(384).CellType = textCellType381;
            this.spdData_Sheet1.Columns.Get(384).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(384).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(385).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(385).CellType = textCellType382;
            this.spdData_Sheet1.Columns.Get(385).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(385).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(386).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(386).CellType = textCellType383;
            this.spdData_Sheet1.Columns.Get(386).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(386).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(387).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(387).CellType = textCellType384;
            this.spdData_Sheet1.Columns.Get(387).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(387).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(388).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(388).CellType = textCellType385;
            this.spdData_Sheet1.Columns.Get(388).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(388).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(389).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(389).CellType = textCellType386;
            this.spdData_Sheet1.Columns.Get(389).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(389).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(390).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(390).CellType = textCellType387;
            this.spdData_Sheet1.Columns.Get(390).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(390).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(391).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(391).CellType = textCellType388;
            this.spdData_Sheet1.Columns.Get(391).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(391).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(392).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(392).CellType = textCellType389;
            this.spdData_Sheet1.Columns.Get(392).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(392).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(393).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(393).CellType = textCellType390;
            this.spdData_Sheet1.Columns.Get(393).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(393).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(394).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(394).CellType = textCellType391;
            this.spdData_Sheet1.Columns.Get(394).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(394).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(395).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(395).CellType = textCellType392;
            this.spdData_Sheet1.Columns.Get(395).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(395).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(396).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(396).CellType = textCellType393;
            this.spdData_Sheet1.Columns.Get(396).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(396).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(397).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(397).CellType = textCellType394;
            this.spdData_Sheet1.Columns.Get(397).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(397).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(398).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(398).CellType = textCellType395;
            this.spdData_Sheet1.Columns.Get(398).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(398).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(399).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(399).CellType = textCellType396;
            this.spdData_Sheet1.Columns.Get(399).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(399).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(400).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(400).CellType = textCellType397;
            this.spdData_Sheet1.Columns.Get(400).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(400).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(401).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(401).CellType = textCellType398;
            this.spdData_Sheet1.Columns.Get(401).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(401).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(402).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(402).CellType = textCellType399;
            this.spdData_Sheet1.Columns.Get(402).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(402).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(403).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(403).CellType = textCellType400;
            this.spdData_Sheet1.Columns.Get(403).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(403).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(404).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(404).CellType = textCellType401;
            this.spdData_Sheet1.Columns.Get(404).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(404).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(405).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(405).CellType = textCellType402;
            this.spdData_Sheet1.Columns.Get(405).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(405).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(406).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(406).CellType = textCellType403;
            this.spdData_Sheet1.Columns.Get(406).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(406).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(407).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(407).CellType = textCellType404;
            this.spdData_Sheet1.Columns.Get(407).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(407).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(408).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(408).CellType = textCellType405;
            this.spdData_Sheet1.Columns.Get(408).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(408).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(409).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(409).CellType = textCellType406;
            this.spdData_Sheet1.Columns.Get(409).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(409).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(410).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(410).CellType = textCellType407;
            this.spdData_Sheet1.Columns.Get(410).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(410).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(411).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(411).CellType = textCellType408;
            this.spdData_Sheet1.Columns.Get(411).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(411).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(412).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(412).CellType = textCellType409;
            this.spdData_Sheet1.Columns.Get(412).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(412).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(413).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(413).CellType = textCellType410;
            this.spdData_Sheet1.Columns.Get(413).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(413).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(414).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(414).CellType = textCellType411;
            this.spdData_Sheet1.Columns.Get(414).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(414).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(415).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(415).CellType = textCellType412;
            this.spdData_Sheet1.Columns.Get(415).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(415).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(416).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(416).CellType = textCellType413;
            this.spdData_Sheet1.Columns.Get(416).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(416).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(417).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(417).CellType = textCellType414;
            this.spdData_Sheet1.Columns.Get(417).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(417).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(418).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(418).CellType = textCellType415;
            this.spdData_Sheet1.Columns.Get(418).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(418).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(419).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(419).CellType = textCellType416;
            this.spdData_Sheet1.Columns.Get(419).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(419).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(420).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(420).CellType = textCellType417;
            this.spdData_Sheet1.Columns.Get(420).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(420).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(421).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(421).CellType = textCellType418;
            this.spdData_Sheet1.Columns.Get(421).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(421).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(422).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(422).CellType = textCellType419;
            this.spdData_Sheet1.Columns.Get(422).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(422).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(423).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(423).CellType = textCellType420;
            this.spdData_Sheet1.Columns.Get(423).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(423).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(424).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(424).CellType = textCellType421;
            this.spdData_Sheet1.Columns.Get(424).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(424).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(425).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(425).CellType = textCellType422;
            this.spdData_Sheet1.Columns.Get(425).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(425).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(426).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(426).CellType = textCellType423;
            this.spdData_Sheet1.Columns.Get(426).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(426).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(427).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(427).CellType = textCellType424;
            this.spdData_Sheet1.Columns.Get(427).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(427).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(428).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(428).CellType = textCellType425;
            this.spdData_Sheet1.Columns.Get(428).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(428).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(429).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(429).CellType = textCellType426;
            this.spdData_Sheet1.Columns.Get(429).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(429).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(430).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(430).CellType = textCellType427;
            this.spdData_Sheet1.Columns.Get(430).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(430).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(431).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(431).CellType = textCellType428;
            this.spdData_Sheet1.Columns.Get(431).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(431).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(432).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(432).CellType = textCellType429;
            this.spdData_Sheet1.Columns.Get(432).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(432).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(433).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(433).CellType = textCellType430;
            this.spdData_Sheet1.Columns.Get(433).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(433).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(434).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(434).CellType = textCellType431;
            this.spdData_Sheet1.Columns.Get(434).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(434).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(435).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(435).CellType = textCellType432;
            this.spdData_Sheet1.Columns.Get(435).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(435).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(436).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(436).CellType = textCellType433;
            this.spdData_Sheet1.Columns.Get(436).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(436).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(437).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(437).CellType = textCellType434;
            this.spdData_Sheet1.Columns.Get(437).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(437).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(438).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(438).CellType = textCellType435;
            this.spdData_Sheet1.Columns.Get(438).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(438).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(439).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(439).CellType = textCellType436;
            this.spdData_Sheet1.Columns.Get(439).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(439).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(440).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(440).CellType = textCellType437;
            this.spdData_Sheet1.Columns.Get(440).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(440).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(441).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(441).CellType = textCellType438;
            this.spdData_Sheet1.Columns.Get(441).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(441).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(442).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(442).CellType = textCellType439;
            this.spdData_Sheet1.Columns.Get(442).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(442).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(443).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(443).CellType = textCellType440;
            this.spdData_Sheet1.Columns.Get(443).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(443).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(444).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(444).CellType = textCellType441;
            this.spdData_Sheet1.Columns.Get(444).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(444).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(445).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(445).CellType = textCellType442;
            this.spdData_Sheet1.Columns.Get(445).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(445).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(446).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(446).CellType = textCellType443;
            this.spdData_Sheet1.Columns.Get(446).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(446).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(447).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(447).CellType = textCellType444;
            this.spdData_Sheet1.Columns.Get(447).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(447).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(448).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(448).CellType = textCellType445;
            this.spdData_Sheet1.Columns.Get(448).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(448).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(449).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(449).CellType = textCellType446;
            this.spdData_Sheet1.Columns.Get(449).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(449).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(450).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(450).CellType = textCellType447;
            this.spdData_Sheet1.Columns.Get(450).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(450).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(451).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(451).CellType = textCellType448;
            this.spdData_Sheet1.Columns.Get(451).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(451).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(452).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(452).CellType = textCellType449;
            this.spdData_Sheet1.Columns.Get(452).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(452).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(453).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(453).CellType = textCellType450;
            this.spdData_Sheet1.Columns.Get(453).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(453).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(454).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(454).CellType = textCellType451;
            this.spdData_Sheet1.Columns.Get(454).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(454).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(455).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(455).CellType = textCellType452;
            this.spdData_Sheet1.Columns.Get(455).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(455).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(456).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(456).CellType = textCellType453;
            this.spdData_Sheet1.Columns.Get(456).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(456).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(457).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(457).CellType = textCellType454;
            this.spdData_Sheet1.Columns.Get(457).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(457).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(458).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(458).CellType = textCellType455;
            this.spdData_Sheet1.Columns.Get(458).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(458).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(459).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(459).CellType = textCellType456;
            this.spdData_Sheet1.Columns.Get(459).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(459).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(460).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(460).CellType = textCellType457;
            this.spdData_Sheet1.Columns.Get(460).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(460).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(461).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(461).CellType = textCellType458;
            this.spdData_Sheet1.Columns.Get(461).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(461).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(462).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(462).CellType = textCellType459;
            this.spdData_Sheet1.Columns.Get(462).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(462).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(463).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(463).CellType = textCellType460;
            this.spdData_Sheet1.Columns.Get(463).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(463).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(464).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(464).CellType = textCellType461;
            this.spdData_Sheet1.Columns.Get(464).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(464).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(465).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(465).CellType = textCellType462;
            this.spdData_Sheet1.Columns.Get(465).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(465).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(466).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(466).CellType = textCellType463;
            this.spdData_Sheet1.Columns.Get(466).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(466).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(467).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(467).CellType = textCellType464;
            this.spdData_Sheet1.Columns.Get(467).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(467).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(468).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(468).CellType = textCellType465;
            this.spdData_Sheet1.Columns.Get(468).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(468).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(469).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(469).CellType = textCellType466;
            this.spdData_Sheet1.Columns.Get(469).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(469).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(470).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(470).CellType = textCellType467;
            this.spdData_Sheet1.Columns.Get(470).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(470).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(471).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(471).CellType = textCellType468;
            this.spdData_Sheet1.Columns.Get(471).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(471).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(472).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(472).CellType = textCellType469;
            this.spdData_Sheet1.Columns.Get(472).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(472).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(473).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(473).CellType = textCellType470;
            this.spdData_Sheet1.Columns.Get(473).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(473).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(474).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(474).CellType = textCellType471;
            this.spdData_Sheet1.Columns.Get(474).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(474).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(475).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(475).CellType = textCellType472;
            this.spdData_Sheet1.Columns.Get(475).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(475).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(476).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(476).CellType = textCellType473;
            this.spdData_Sheet1.Columns.Get(476).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(476).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(477).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(477).CellType = textCellType474;
            this.spdData_Sheet1.Columns.Get(477).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(477).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(478).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(478).CellType = textCellType475;
            this.spdData_Sheet1.Columns.Get(478).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(478).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(479).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(479).CellType = textCellType476;
            this.spdData_Sheet1.Columns.Get(479).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(479).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(480).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(480).CellType = textCellType477;
            this.spdData_Sheet1.Columns.Get(480).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(480).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(481).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(481).CellType = textCellType478;
            this.spdData_Sheet1.Columns.Get(481).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(481).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(482).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(482).CellType = textCellType479;
            this.spdData_Sheet1.Columns.Get(482).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(482).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(483).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(483).CellType = textCellType480;
            this.spdData_Sheet1.Columns.Get(483).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(483).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(484).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(484).CellType = textCellType481;
            this.spdData_Sheet1.Columns.Get(484).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(484).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(485).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(485).CellType = textCellType482;
            this.spdData_Sheet1.Columns.Get(485).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(485).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(486).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(486).CellType = textCellType483;
            this.spdData_Sheet1.Columns.Get(486).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(486).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(487).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(487).CellType = textCellType484;
            this.spdData_Sheet1.Columns.Get(487).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(487).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(488).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(488).CellType = textCellType485;
            this.spdData_Sheet1.Columns.Get(488).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(488).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(489).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(489).CellType = textCellType486;
            this.spdData_Sheet1.Columns.Get(489).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(489).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(490).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(490).CellType = textCellType487;
            this.spdData_Sheet1.Columns.Get(490).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(490).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(491).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(491).CellType = textCellType488;
            this.spdData_Sheet1.Columns.Get(491).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(491).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(492).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(492).CellType = textCellType489;
            this.spdData_Sheet1.Columns.Get(492).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(492).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(493).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(493).CellType = textCellType490;
            this.spdData_Sheet1.Columns.Get(493).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(493).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(494).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(494).CellType = textCellType491;
            this.spdData_Sheet1.Columns.Get(494).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(494).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(495).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(495).CellType = textCellType492;
            this.spdData_Sheet1.Columns.Get(495).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(495).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(496).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(496).CellType = textCellType493;
            this.spdData_Sheet1.Columns.Get(496).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(496).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(497).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(497).CellType = textCellType494;
            this.spdData_Sheet1.Columns.Get(497).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(497).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(498).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(498).CellType = textCellType495;
            this.spdData_Sheet1.Columns.Get(498).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(498).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(499).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(499).CellType = textCellType496;
            this.spdData_Sheet1.Columns.Get(499).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(499).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(500).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(500).CellType = textCellType497;
            this.spdData_Sheet1.Columns.Get(500).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(500).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(501).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(501).CellType = textCellType498;
            this.spdData_Sheet1.Columns.Get(501).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(501).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(502).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(502).CellType = textCellType499;
            this.spdData_Sheet1.Columns.Get(502).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(502).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(503).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(503).CellType = textCellType500;
            this.spdData_Sheet1.Columns.Get(503).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(503).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(504).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(504).CellType = textCellType501;
            this.spdData_Sheet1.Columns.Get(504).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(504).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(505).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(505).CellType = textCellType502;
            this.spdData_Sheet1.Columns.Get(505).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(505).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(506).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(506).CellType = textCellType503;
            this.spdData_Sheet1.Columns.Get(506).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(506).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(507).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(507).CellType = textCellType504;
            this.spdData_Sheet1.Columns.Get(507).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(507).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(508).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(508).CellType = textCellType505;
            this.spdData_Sheet1.Columns.Get(508).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(508).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(509).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(509).CellType = textCellType506;
            this.spdData_Sheet1.Columns.Get(509).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(509).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(510).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(510).CellType = textCellType507;
            this.spdData_Sheet1.Columns.Get(510).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(510).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(511).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(511).CellType = textCellType508;
            this.spdData_Sheet1.Columns.Get(511).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(511).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(512).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(512).CellType = textCellType509;
            this.spdData_Sheet1.Columns.Get(512).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(512).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(513).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(513).CellType = textCellType510;
            this.spdData_Sheet1.Columns.Get(513).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(513).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(514).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(514).CellType = textCellType511;
            this.spdData_Sheet1.Columns.Get(514).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(514).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(515).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(515).CellType = textCellType512;
            this.spdData_Sheet1.Columns.Get(515).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(515).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(516).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(516).CellType = textCellType513;
            this.spdData_Sheet1.Columns.Get(516).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(516).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(517).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(517).CellType = textCellType514;
            this.spdData_Sheet1.Columns.Get(517).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(517).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(518).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(518).CellType = textCellType515;
            this.spdData_Sheet1.Columns.Get(518).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(518).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(519).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(519).CellType = textCellType516;
            this.spdData_Sheet1.Columns.Get(519).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(519).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(520).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(520).CellType = textCellType517;
            this.spdData_Sheet1.Columns.Get(520).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(520).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(521).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(521).CellType = textCellType518;
            this.spdData_Sheet1.Columns.Get(521).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(521).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(522).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(522).CellType = textCellType519;
            this.spdData_Sheet1.Columns.Get(522).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(522).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(523).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(523).CellType = textCellType520;
            this.spdData_Sheet1.Columns.Get(523).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(523).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(524).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(524).CellType = textCellType521;
            this.spdData_Sheet1.Columns.Get(524).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(524).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(525).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(525).CellType = textCellType522;
            this.spdData_Sheet1.Columns.Get(525).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(525).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(526).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(526).CellType = textCellType523;
            this.spdData_Sheet1.Columns.Get(526).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(526).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(527).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(527).CellType = textCellType524;
            this.spdData_Sheet1.Columns.Get(527).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(527).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(528).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(528).CellType = textCellType525;
            this.spdData_Sheet1.Columns.Get(528).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(528).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(529).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(529).CellType = textCellType526;
            this.spdData_Sheet1.Columns.Get(529).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(529).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(530).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(530).CellType = textCellType527;
            this.spdData_Sheet1.Columns.Get(530).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(530).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(531).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(531).CellType = textCellType528;
            this.spdData_Sheet1.Columns.Get(531).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(531).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(532).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(532).CellType = textCellType529;
            this.spdData_Sheet1.Columns.Get(532).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(532).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(533).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(533).CellType = textCellType530;
            this.spdData_Sheet1.Columns.Get(533).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(533).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(534).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(534).CellType = textCellType531;
            this.spdData_Sheet1.Columns.Get(534).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(534).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(535).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(535).CellType = textCellType532;
            this.spdData_Sheet1.Columns.Get(535).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(535).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(536).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(536).CellType = textCellType533;
            this.spdData_Sheet1.Columns.Get(536).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(536).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(537).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(537).CellType = textCellType534;
            this.spdData_Sheet1.Columns.Get(537).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(537).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(538).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(538).CellType = textCellType535;
            this.spdData_Sheet1.Columns.Get(538).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(538).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(539).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(539).CellType = textCellType536;
            this.spdData_Sheet1.Columns.Get(539).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(539).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(540).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(540).CellType = textCellType537;
            this.spdData_Sheet1.Columns.Get(540).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(540).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(541).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(541).CellType = textCellType538;
            this.spdData_Sheet1.Columns.Get(541).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(541).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(542).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(542).CellType = textCellType539;
            this.spdData_Sheet1.Columns.Get(542).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(542).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(543).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(543).CellType = textCellType540;
            this.spdData_Sheet1.Columns.Get(543).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(543).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(544).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(544).CellType = textCellType541;
            this.spdData_Sheet1.Columns.Get(544).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(544).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(545).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(545).CellType = textCellType542;
            this.spdData_Sheet1.Columns.Get(545).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(545).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(546).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(546).CellType = textCellType543;
            this.spdData_Sheet1.Columns.Get(546).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(546).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(547).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(547).CellType = textCellType544;
            this.spdData_Sheet1.Columns.Get(547).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(547).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(548).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(548).CellType = textCellType545;
            this.spdData_Sheet1.Columns.Get(548).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(548).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(549).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(549).CellType = textCellType546;
            this.spdData_Sheet1.Columns.Get(549).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(549).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(550).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(550).CellType = textCellType547;
            this.spdData_Sheet1.Columns.Get(550).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(550).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(551).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(551).CellType = textCellType548;
            this.spdData_Sheet1.Columns.Get(551).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(551).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(552).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(552).CellType = textCellType549;
            this.spdData_Sheet1.Columns.Get(552).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(552).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(553).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(553).CellType = textCellType550;
            this.spdData_Sheet1.Columns.Get(553).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(553).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(554).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(554).CellType = textCellType551;
            this.spdData_Sheet1.Columns.Get(554).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(554).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(555).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(555).CellType = textCellType552;
            this.spdData_Sheet1.Columns.Get(555).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(555).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(556).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(556).CellType = textCellType553;
            this.spdData_Sheet1.Columns.Get(556).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(556).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(557).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(557).CellType = textCellType554;
            this.spdData_Sheet1.Columns.Get(557).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(557).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(558).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(558).CellType = textCellType555;
            this.spdData_Sheet1.Columns.Get(558).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(558).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(559).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(559).CellType = textCellType556;
            this.spdData_Sheet1.Columns.Get(559).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(559).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(560).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(560).CellType = textCellType557;
            this.spdData_Sheet1.Columns.Get(560).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(560).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(561).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(561).CellType = textCellType558;
            this.spdData_Sheet1.Columns.Get(561).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(561).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(562).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(562).CellType = textCellType559;
            this.spdData_Sheet1.Columns.Get(562).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(562).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(563).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(563).CellType = textCellType560;
            this.spdData_Sheet1.Columns.Get(563).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(563).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(564).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(564).CellType = textCellType561;
            this.spdData_Sheet1.Columns.Get(564).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(564).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(565).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(565).CellType = textCellType562;
            this.spdData_Sheet1.Columns.Get(565).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(565).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(566).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(566).CellType = textCellType563;
            this.spdData_Sheet1.Columns.Get(566).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(566).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(567).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(567).CellType = textCellType564;
            this.spdData_Sheet1.Columns.Get(567).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(567).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(568).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(568).CellType = textCellType565;
            this.spdData_Sheet1.Columns.Get(568).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(568).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(569).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(569).CellType = textCellType566;
            this.spdData_Sheet1.Columns.Get(569).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(569).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(570).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(570).CellType = textCellType567;
            this.spdData_Sheet1.Columns.Get(570).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(570).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(571).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(571).CellType = textCellType568;
            this.spdData_Sheet1.Columns.Get(571).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(571).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(572).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(572).CellType = textCellType569;
            this.spdData_Sheet1.Columns.Get(572).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(572).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(573).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(573).CellType = textCellType570;
            this.spdData_Sheet1.Columns.Get(573).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(573).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(574).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(574).CellType = textCellType571;
            this.spdData_Sheet1.Columns.Get(574).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(574).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(575).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(575).CellType = textCellType572;
            this.spdData_Sheet1.Columns.Get(575).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(575).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(576).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(576).CellType = textCellType573;
            this.spdData_Sheet1.Columns.Get(576).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(576).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(577).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(577).CellType = textCellType574;
            this.spdData_Sheet1.Columns.Get(577).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(577).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(578).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(578).CellType = textCellType575;
            this.spdData_Sheet1.Columns.Get(578).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(578).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(579).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(579).CellType = textCellType576;
            this.spdData_Sheet1.Columns.Get(579).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(579).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(580).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(580).CellType = textCellType577;
            this.spdData_Sheet1.Columns.Get(580).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(580).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(581).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(581).CellType = textCellType578;
            this.spdData_Sheet1.Columns.Get(581).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(581).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(582).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(582).CellType = textCellType579;
            this.spdData_Sheet1.Columns.Get(582).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(582).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(583).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(583).CellType = textCellType580;
            this.spdData_Sheet1.Columns.Get(583).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(583).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(584).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(584).CellType = textCellType581;
            this.spdData_Sheet1.Columns.Get(584).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(584).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(585).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(585).CellType = textCellType582;
            this.spdData_Sheet1.Columns.Get(585).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(585).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(586).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(586).CellType = textCellType583;
            this.spdData_Sheet1.Columns.Get(586).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(586).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(587).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(587).CellType = textCellType584;
            this.spdData_Sheet1.Columns.Get(587).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(587).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(588).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(588).CellType = textCellType585;
            this.spdData_Sheet1.Columns.Get(588).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(588).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(589).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(589).CellType = textCellType586;
            this.spdData_Sheet1.Columns.Get(589).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(589).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(590).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(590).CellType = textCellType587;
            this.spdData_Sheet1.Columns.Get(590).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(590).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(591).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(591).CellType = textCellType588;
            this.spdData_Sheet1.Columns.Get(591).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(591).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(592).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(592).CellType = textCellType589;
            this.spdData_Sheet1.Columns.Get(592).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(592).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(593).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(593).CellType = textCellType590;
            this.spdData_Sheet1.Columns.Get(593).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(593).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(594).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(594).CellType = textCellType591;
            this.spdData_Sheet1.Columns.Get(594).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(594).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(595).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(595).CellType = textCellType592;
            this.spdData_Sheet1.Columns.Get(595).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(595).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(596).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(596).CellType = textCellType593;
            this.spdData_Sheet1.Columns.Get(596).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(596).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(597).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(597).CellType = textCellType594;
            this.spdData_Sheet1.Columns.Get(597).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(597).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(598).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(598).CellType = textCellType595;
            this.spdData_Sheet1.Columns.Get(598).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(598).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(599).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(599).CellType = textCellType596;
            this.spdData_Sheet1.Columns.Get(599).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(599).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(600).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(600).CellType = textCellType597;
            this.spdData_Sheet1.Columns.Get(600).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(600).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(601).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(601).CellType = textCellType598;
            this.spdData_Sheet1.Columns.Get(601).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(601).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(602).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(602).CellType = textCellType599;
            this.spdData_Sheet1.Columns.Get(602).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(602).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(603).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(603).CellType = textCellType600;
            this.spdData_Sheet1.Columns.Get(603).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(603).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(604).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(604).CellType = textCellType601;
            this.spdData_Sheet1.Columns.Get(604).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(604).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(605).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(605).CellType = textCellType602;
            this.spdData_Sheet1.Columns.Get(605).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(605).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(606).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(606).CellType = textCellType603;
            this.spdData_Sheet1.Columns.Get(606).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(606).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(607).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(607).CellType = textCellType604;
            this.spdData_Sheet1.Columns.Get(607).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(607).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(608).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(608).CellType = textCellType605;
            this.spdData_Sheet1.Columns.Get(608).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(608).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(609).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(609).CellType = textCellType606;
            this.spdData_Sheet1.Columns.Get(609).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(609).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(610).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(610).CellType = textCellType607;
            this.spdData_Sheet1.Columns.Get(610).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(610).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(611).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(611).CellType = textCellType608;
            this.spdData_Sheet1.Columns.Get(611).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(611).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(612).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(612).CellType = textCellType609;
            this.spdData_Sheet1.Columns.Get(612).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(612).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(613).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(613).CellType = textCellType610;
            this.spdData_Sheet1.Columns.Get(613).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(613).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(614).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(614).CellType = textCellType611;
            this.spdData_Sheet1.Columns.Get(614).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(614).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(615).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(615).CellType = textCellType612;
            this.spdData_Sheet1.Columns.Get(615).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(615).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(616).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(616).CellType = textCellType613;
            this.spdData_Sheet1.Columns.Get(616).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(616).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(617).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(617).CellType = textCellType614;
            this.spdData_Sheet1.Columns.Get(617).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(617).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(618).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(618).CellType = textCellType615;
            this.spdData_Sheet1.Columns.Get(618).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(618).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(619).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(619).CellType = textCellType616;
            this.spdData_Sheet1.Columns.Get(619).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(619).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(620).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(620).CellType = textCellType617;
            this.spdData_Sheet1.Columns.Get(620).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(620).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(621).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(621).CellType = textCellType618;
            this.spdData_Sheet1.Columns.Get(621).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(621).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(622).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(622).CellType = textCellType619;
            this.spdData_Sheet1.Columns.Get(622).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(622).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(623).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(623).CellType = textCellType620;
            this.spdData_Sheet1.Columns.Get(623).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(623).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(624).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(624).CellType = textCellType621;
            this.spdData_Sheet1.Columns.Get(624).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(624).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(625).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(625).CellType = textCellType622;
            this.spdData_Sheet1.Columns.Get(625).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(625).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(626).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(626).CellType = textCellType623;
            this.spdData_Sheet1.Columns.Get(626).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(626).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(627).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(627).CellType = textCellType624;
            this.spdData_Sheet1.Columns.Get(627).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(627).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(628).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(628).CellType = textCellType625;
            this.spdData_Sheet1.Columns.Get(628).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(628).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(629).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(629).CellType = textCellType626;
            this.spdData_Sheet1.Columns.Get(629).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(629).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(630).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(630).CellType = textCellType627;
            this.spdData_Sheet1.Columns.Get(630).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(630).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(631).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(631).CellType = textCellType628;
            this.spdData_Sheet1.Columns.Get(631).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(631).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(632).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(632).CellType = textCellType629;
            this.spdData_Sheet1.Columns.Get(632).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(632).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(633).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(633).CellType = textCellType630;
            this.spdData_Sheet1.Columns.Get(633).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(633).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(634).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(634).CellType = textCellType631;
            this.spdData_Sheet1.Columns.Get(634).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(634).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(635).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(635).CellType = textCellType632;
            this.spdData_Sheet1.Columns.Get(635).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(635).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(636).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(636).CellType = textCellType633;
            this.spdData_Sheet1.Columns.Get(636).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(636).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(637).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(637).CellType = textCellType634;
            this.spdData_Sheet1.Columns.Get(637).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(637).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(638).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(638).CellType = textCellType635;
            this.spdData_Sheet1.Columns.Get(638).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(638).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(639).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(639).CellType = textCellType636;
            this.spdData_Sheet1.Columns.Get(639).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(639).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(640).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(640).CellType = textCellType637;
            this.spdData_Sheet1.Columns.Get(640).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(640).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(641).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(641).CellType = textCellType638;
            this.spdData_Sheet1.Columns.Get(641).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(641).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(642).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(642).CellType = textCellType639;
            this.spdData_Sheet1.Columns.Get(642).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(642).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(643).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(643).CellType = textCellType640;
            this.spdData_Sheet1.Columns.Get(643).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(643).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(644).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(644).CellType = textCellType641;
            this.spdData_Sheet1.Columns.Get(644).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(644).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(645).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(645).CellType = textCellType642;
            this.spdData_Sheet1.Columns.Get(645).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(645).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(646).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(646).CellType = textCellType643;
            this.spdData_Sheet1.Columns.Get(646).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(646).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(647).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(647).CellType = textCellType644;
            this.spdData_Sheet1.Columns.Get(647).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(647).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(648).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(648).CellType = textCellType645;
            this.spdData_Sheet1.Columns.Get(648).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(648).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(649).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(649).CellType = textCellType646;
            this.spdData_Sheet1.Columns.Get(649).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(649).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(650).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(650).CellType = textCellType647;
            this.spdData_Sheet1.Columns.Get(650).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(650).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(651).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(651).CellType = textCellType648;
            this.spdData_Sheet1.Columns.Get(651).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(651).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(652).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(652).CellType = textCellType649;
            this.spdData_Sheet1.Columns.Get(652).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(652).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(653).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(653).CellType = textCellType650;
            this.spdData_Sheet1.Columns.Get(653).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(653).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(654).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(654).CellType = textCellType651;
            this.spdData_Sheet1.Columns.Get(654).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(654).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(655).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(655).CellType = textCellType652;
            this.spdData_Sheet1.Columns.Get(655).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(655).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(656).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(656).CellType = textCellType653;
            this.spdData_Sheet1.Columns.Get(656).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(656).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(657).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(657).CellType = textCellType654;
            this.spdData_Sheet1.Columns.Get(657).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(657).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(658).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(658).CellType = textCellType655;
            this.spdData_Sheet1.Columns.Get(658).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(658).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(659).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(659).CellType = textCellType656;
            this.spdData_Sheet1.Columns.Get(659).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(659).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(660).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(660).CellType = textCellType657;
            this.spdData_Sheet1.Columns.Get(660).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(660).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(661).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(661).CellType = textCellType658;
            this.spdData_Sheet1.Columns.Get(661).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(661).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(662).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(662).CellType = textCellType659;
            this.spdData_Sheet1.Columns.Get(662).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(662).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(663).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(663).CellType = textCellType660;
            this.spdData_Sheet1.Columns.Get(663).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(663).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(664).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(664).CellType = textCellType661;
            this.spdData_Sheet1.Columns.Get(664).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(664).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(665).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(665).CellType = textCellType662;
            this.spdData_Sheet1.Columns.Get(665).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(665).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(666).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(666).CellType = textCellType663;
            this.spdData_Sheet1.Columns.Get(666).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(666).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(667).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(667).CellType = textCellType664;
            this.spdData_Sheet1.Columns.Get(667).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(667).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(668).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(668).CellType = textCellType665;
            this.spdData_Sheet1.Columns.Get(668).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(668).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(669).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(669).CellType = textCellType666;
            this.spdData_Sheet1.Columns.Get(669).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(669).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(670).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(670).CellType = textCellType667;
            this.spdData_Sheet1.Columns.Get(670).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(670).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(671).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(671).CellType = textCellType668;
            this.spdData_Sheet1.Columns.Get(671).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(671).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(672).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(672).CellType = textCellType669;
            this.spdData_Sheet1.Columns.Get(672).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(672).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(673).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(673).CellType = textCellType670;
            this.spdData_Sheet1.Columns.Get(673).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(673).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(674).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(674).CellType = textCellType671;
            this.spdData_Sheet1.Columns.Get(674).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(674).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(675).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(675).CellType = textCellType672;
            this.spdData_Sheet1.Columns.Get(675).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(675).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(676).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(676).CellType = textCellType673;
            this.spdData_Sheet1.Columns.Get(676).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(676).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(677).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(677).CellType = textCellType674;
            this.spdData_Sheet1.Columns.Get(677).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(677).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(678).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(678).CellType = textCellType675;
            this.spdData_Sheet1.Columns.Get(678).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(678).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(679).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(679).CellType = textCellType676;
            this.spdData_Sheet1.Columns.Get(679).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(679).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(680).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(680).CellType = textCellType677;
            this.spdData_Sheet1.Columns.Get(680).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(680).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(681).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(681).CellType = textCellType678;
            this.spdData_Sheet1.Columns.Get(681).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(681).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(682).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(682).CellType = textCellType679;
            this.spdData_Sheet1.Columns.Get(682).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(682).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(683).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(683).CellType = textCellType680;
            this.spdData_Sheet1.Columns.Get(683).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(683).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(684).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(684).CellType = textCellType681;
            this.spdData_Sheet1.Columns.Get(684).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(684).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(685).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(685).CellType = textCellType682;
            this.spdData_Sheet1.Columns.Get(685).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(685).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(686).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(686).CellType = textCellType683;
            this.spdData_Sheet1.Columns.Get(686).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(686).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(687).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(687).CellType = textCellType684;
            this.spdData_Sheet1.Columns.Get(687).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(687).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(688).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(688).CellType = textCellType685;
            this.spdData_Sheet1.Columns.Get(688).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(688).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(689).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(689).CellType = textCellType686;
            this.spdData_Sheet1.Columns.Get(689).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(689).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(690).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(690).CellType = textCellType687;
            this.spdData_Sheet1.Columns.Get(690).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(690).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(691).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(691).CellType = textCellType688;
            this.spdData_Sheet1.Columns.Get(691).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(691).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(692).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(692).CellType = textCellType689;
            this.spdData_Sheet1.Columns.Get(692).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(692).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(693).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(693).CellType = textCellType690;
            this.spdData_Sheet1.Columns.Get(693).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(693).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(694).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(694).CellType = textCellType691;
            this.spdData_Sheet1.Columns.Get(694).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(694).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(695).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(695).CellType = textCellType692;
            this.spdData_Sheet1.Columns.Get(695).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(695).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(696).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(696).CellType = textCellType693;
            this.spdData_Sheet1.Columns.Get(696).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(696).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(697).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(697).CellType = textCellType694;
            this.spdData_Sheet1.Columns.Get(697).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(697).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(698).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(698).CellType = textCellType695;
            this.spdData_Sheet1.Columns.Get(698).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(698).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(699).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(699).CellType = textCellType696;
            this.spdData_Sheet1.Columns.Get(699).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(699).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(700).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(700).CellType = textCellType697;
            this.spdData_Sheet1.Columns.Get(700).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(700).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(701).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(701).CellType = textCellType698;
            this.spdData_Sheet1.Columns.Get(701).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(701).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(702).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(702).CellType = textCellType699;
            this.spdData_Sheet1.Columns.Get(702).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(702).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(703).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(703).CellType = textCellType700;
            this.spdData_Sheet1.Columns.Get(703).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(703).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(704).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(704).CellType = textCellType701;
            this.spdData_Sheet1.Columns.Get(704).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(704).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(705).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(705).CellType = textCellType702;
            this.spdData_Sheet1.Columns.Get(705).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(705).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(706).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(706).CellType = textCellType703;
            this.spdData_Sheet1.Columns.Get(706).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(706).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(707).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(707).CellType = textCellType704;
            this.spdData_Sheet1.Columns.Get(707).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(707).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(708).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(708).CellType = textCellType705;
            this.spdData_Sheet1.Columns.Get(708).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(708).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(709).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(709).CellType = textCellType706;
            this.spdData_Sheet1.Columns.Get(709).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(709).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(710).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(710).CellType = textCellType707;
            this.spdData_Sheet1.Columns.Get(710).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(710).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(711).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(711).CellType = textCellType708;
            this.spdData_Sheet1.Columns.Get(711).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(711).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(712).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(712).CellType = textCellType709;
            this.spdData_Sheet1.Columns.Get(712).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(712).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(713).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(713).CellType = textCellType710;
            this.spdData_Sheet1.Columns.Get(713).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(713).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(714).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(714).CellType = textCellType711;
            this.spdData_Sheet1.Columns.Get(714).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(714).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(715).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(715).CellType = textCellType712;
            this.spdData_Sheet1.Columns.Get(715).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(715).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(716).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(716).CellType = textCellType713;
            this.spdData_Sheet1.Columns.Get(716).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(716).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(717).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(717).CellType = textCellType714;
            this.spdData_Sheet1.Columns.Get(717).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(717).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(718).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(718).CellType = textCellType715;
            this.spdData_Sheet1.Columns.Get(718).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(718).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(719).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(719).CellType = textCellType716;
            this.spdData_Sheet1.Columns.Get(719).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(719).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(720).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(720).CellType = textCellType717;
            this.spdData_Sheet1.Columns.Get(720).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(720).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(721).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(721).CellType = textCellType718;
            this.spdData_Sheet1.Columns.Get(721).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(721).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(722).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(722).CellType = textCellType719;
            this.spdData_Sheet1.Columns.Get(722).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(722).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(723).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(723).CellType = textCellType720;
            this.spdData_Sheet1.Columns.Get(723).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(723).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(724).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(724).CellType = textCellType721;
            this.spdData_Sheet1.Columns.Get(724).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(724).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(725).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(725).CellType = textCellType722;
            this.spdData_Sheet1.Columns.Get(725).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(725).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(726).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(726).CellType = textCellType723;
            this.spdData_Sheet1.Columns.Get(726).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(726).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(727).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(727).CellType = textCellType724;
            this.spdData_Sheet1.Columns.Get(727).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(727).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(728).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(728).CellType = textCellType725;
            this.spdData_Sheet1.Columns.Get(728).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(728).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(729).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(729).CellType = textCellType726;
            this.spdData_Sheet1.Columns.Get(729).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(729).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(730).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(730).CellType = textCellType727;
            this.spdData_Sheet1.Columns.Get(730).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(730).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(731).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(731).CellType = textCellType728;
            this.spdData_Sheet1.Columns.Get(731).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(731).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(732).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(732).CellType = textCellType729;
            this.spdData_Sheet1.Columns.Get(732).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(732).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(733).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(733).CellType = textCellType730;
            this.spdData_Sheet1.Columns.Get(733).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(733).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(734).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(734).CellType = textCellType731;
            this.spdData_Sheet1.Columns.Get(734).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(734).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(735).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(735).CellType = textCellType732;
            this.spdData_Sheet1.Columns.Get(735).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(735).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(736).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(736).CellType = textCellType733;
            this.spdData_Sheet1.Columns.Get(736).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(736).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(737).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(737).CellType = textCellType734;
            this.spdData_Sheet1.Columns.Get(737).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(737).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(738).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(738).CellType = textCellType735;
            this.spdData_Sheet1.Columns.Get(738).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(738).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(739).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(739).CellType = textCellType736;
            this.spdData_Sheet1.Columns.Get(739).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(739).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(740).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(740).CellType = textCellType737;
            this.spdData_Sheet1.Columns.Get(740).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(740).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(741).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(741).CellType = textCellType738;
            this.spdData_Sheet1.Columns.Get(741).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(741).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(742).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(742).CellType = textCellType739;
            this.spdData_Sheet1.Columns.Get(742).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(742).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(743).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(743).CellType = textCellType740;
            this.spdData_Sheet1.Columns.Get(743).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(743).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(744).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(744).CellType = textCellType741;
            this.spdData_Sheet1.Columns.Get(744).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(744).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(745).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(745).CellType = textCellType742;
            this.spdData_Sheet1.Columns.Get(745).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(745).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(746).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(746).CellType = textCellType743;
            this.spdData_Sheet1.Columns.Get(746).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(746).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(747).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(747).CellType = textCellType744;
            this.spdData_Sheet1.Columns.Get(747).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(747).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(748).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(748).CellType = textCellType745;
            this.spdData_Sheet1.Columns.Get(748).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(748).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(749).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(749).CellType = textCellType746;
            this.spdData_Sheet1.Columns.Get(749).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(749).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(750).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(750).CellType = textCellType747;
            this.spdData_Sheet1.Columns.Get(750).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(750).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(751).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(751).CellType = textCellType748;
            this.spdData_Sheet1.Columns.Get(751).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(751).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(752).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(752).CellType = textCellType749;
            this.spdData_Sheet1.Columns.Get(752).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(752).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(753).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(753).CellType = textCellType750;
            this.spdData_Sheet1.Columns.Get(753).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(753).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(754).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(754).CellType = textCellType751;
            this.spdData_Sheet1.Columns.Get(754).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(754).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(755).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(755).CellType = textCellType752;
            this.spdData_Sheet1.Columns.Get(755).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(755).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(756).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(756).CellType = textCellType753;
            this.spdData_Sheet1.Columns.Get(756).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(756).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(757).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(757).CellType = textCellType754;
            this.spdData_Sheet1.Columns.Get(757).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(757).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(758).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(758).CellType = textCellType755;
            this.spdData_Sheet1.Columns.Get(758).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(758).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(759).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(759).CellType = textCellType756;
            this.spdData_Sheet1.Columns.Get(759).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(759).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(760).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(760).CellType = textCellType757;
            this.spdData_Sheet1.Columns.Get(760).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(760).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(761).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(761).CellType = textCellType758;
            this.spdData_Sheet1.Columns.Get(761).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(761).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(762).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(762).CellType = textCellType759;
            this.spdData_Sheet1.Columns.Get(762).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(762).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(763).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(763).CellType = textCellType760;
            this.spdData_Sheet1.Columns.Get(763).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(763).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(764).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(764).CellType = textCellType761;
            this.spdData_Sheet1.Columns.Get(764).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(764).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(765).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(765).CellType = textCellType762;
            this.spdData_Sheet1.Columns.Get(765).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(765).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(766).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(766).CellType = textCellType763;
            this.spdData_Sheet1.Columns.Get(766).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(766).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(767).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(767).CellType = textCellType764;
            this.spdData_Sheet1.Columns.Get(767).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(767).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(768).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(768).CellType = textCellType765;
            this.spdData_Sheet1.Columns.Get(768).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(768).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(769).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(769).CellType = textCellType766;
            this.spdData_Sheet1.Columns.Get(769).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(769).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(770).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(770).CellType = textCellType767;
            this.spdData_Sheet1.Columns.Get(770).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(770).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(771).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(771).CellType = textCellType768;
            this.spdData_Sheet1.Columns.Get(771).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(771).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(772).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(772).CellType = textCellType769;
            this.spdData_Sheet1.Columns.Get(772).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(772).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(773).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(773).CellType = textCellType770;
            this.spdData_Sheet1.Columns.Get(773).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(773).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(774).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(774).CellType = textCellType771;
            this.spdData_Sheet1.Columns.Get(774).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(774).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(775).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(775).CellType = textCellType772;
            this.spdData_Sheet1.Columns.Get(775).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(775).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(776).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(776).CellType = textCellType773;
            this.spdData_Sheet1.Columns.Get(776).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(776).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(777).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(777).CellType = textCellType774;
            this.spdData_Sheet1.Columns.Get(777).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(777).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(778).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(778).CellType = textCellType775;
            this.spdData_Sheet1.Columns.Get(778).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(778).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(779).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(779).CellType = textCellType776;
            this.spdData_Sheet1.Columns.Get(779).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(779).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(780).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(780).CellType = textCellType777;
            this.spdData_Sheet1.Columns.Get(780).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(780).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(781).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(781).CellType = textCellType778;
            this.spdData_Sheet1.Columns.Get(781).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(781).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(782).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(782).CellType = textCellType779;
            this.spdData_Sheet1.Columns.Get(782).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(782).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(783).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(783).CellType = textCellType780;
            this.spdData_Sheet1.Columns.Get(783).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(783).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(784).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(784).CellType = textCellType781;
            this.spdData_Sheet1.Columns.Get(784).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(784).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(785).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(785).CellType = textCellType782;
            this.spdData_Sheet1.Columns.Get(785).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(785).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(786).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(786).CellType = textCellType783;
            this.spdData_Sheet1.Columns.Get(786).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(786).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(787).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(787).CellType = textCellType784;
            this.spdData_Sheet1.Columns.Get(787).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(787).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(788).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(788).CellType = textCellType785;
            this.spdData_Sheet1.Columns.Get(788).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(788).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(789).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(789).CellType = textCellType786;
            this.spdData_Sheet1.Columns.Get(789).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(789).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(790).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(790).CellType = textCellType787;
            this.spdData_Sheet1.Columns.Get(790).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(790).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(791).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(791).CellType = textCellType788;
            this.spdData_Sheet1.Columns.Get(791).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(791).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(792).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(792).CellType = textCellType789;
            this.spdData_Sheet1.Columns.Get(792).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(792).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(793).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(793).CellType = textCellType790;
            this.spdData_Sheet1.Columns.Get(793).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(793).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(794).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(794).CellType = textCellType791;
            this.spdData_Sheet1.Columns.Get(794).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(794).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(795).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(795).CellType = textCellType792;
            this.spdData_Sheet1.Columns.Get(795).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(795).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(796).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(796).CellType = textCellType793;
            this.spdData_Sheet1.Columns.Get(796).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(796).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(797).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(797).CellType = textCellType794;
            this.spdData_Sheet1.Columns.Get(797).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(797).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(798).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(798).CellType = textCellType795;
            this.spdData_Sheet1.Columns.Get(798).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(798).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(799).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(799).CellType = textCellType796;
            this.spdData_Sheet1.Columns.Get(799).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(799).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(800).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(800).CellType = textCellType797;
            this.spdData_Sheet1.Columns.Get(800).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(800).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(801).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(801).CellType = textCellType798;
            this.spdData_Sheet1.Columns.Get(801).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(801).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(802).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(802).CellType = textCellType799;
            this.spdData_Sheet1.Columns.Get(802).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(802).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(803).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(803).CellType = textCellType800;
            this.spdData_Sheet1.Columns.Get(803).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(803).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(804).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(804).CellType = textCellType801;
            this.spdData_Sheet1.Columns.Get(804).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(804).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(805).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(805).CellType = textCellType802;
            this.spdData_Sheet1.Columns.Get(805).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(805).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(806).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(806).CellType = textCellType803;
            this.spdData_Sheet1.Columns.Get(806).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(806).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(807).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(807).CellType = textCellType804;
            this.spdData_Sheet1.Columns.Get(807).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(807).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(808).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(808).CellType = textCellType805;
            this.spdData_Sheet1.Columns.Get(808).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(808).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(809).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(809).CellType = textCellType806;
            this.spdData_Sheet1.Columns.Get(809).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(809).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(810).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(810).CellType = textCellType807;
            this.spdData_Sheet1.Columns.Get(810).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(810).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(811).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(811).CellType = textCellType808;
            this.spdData_Sheet1.Columns.Get(811).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(811).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(812).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(812).CellType = textCellType809;
            this.spdData_Sheet1.Columns.Get(812).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(812).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(813).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(813).CellType = textCellType810;
            this.spdData_Sheet1.Columns.Get(813).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(813).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(814).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(814).CellType = textCellType811;
            this.spdData_Sheet1.Columns.Get(814).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(814).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(815).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(815).CellType = textCellType812;
            this.spdData_Sheet1.Columns.Get(815).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(815).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(816).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(816).CellType = textCellType813;
            this.spdData_Sheet1.Columns.Get(816).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(816).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(817).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(817).CellType = textCellType814;
            this.spdData_Sheet1.Columns.Get(817).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(817).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(818).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(818).CellType = textCellType815;
            this.spdData_Sheet1.Columns.Get(818).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(818).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(819).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(819).CellType = textCellType816;
            this.spdData_Sheet1.Columns.Get(819).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(819).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(820).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(820).CellType = textCellType817;
            this.spdData_Sheet1.Columns.Get(820).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(820).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(821).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(821).CellType = textCellType818;
            this.spdData_Sheet1.Columns.Get(821).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(821).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(822).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(822).CellType = textCellType819;
            this.spdData_Sheet1.Columns.Get(822).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(822).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(823).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(823).CellType = textCellType820;
            this.spdData_Sheet1.Columns.Get(823).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(823).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(824).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(824).CellType = textCellType821;
            this.spdData_Sheet1.Columns.Get(824).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(824).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(825).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(825).CellType = textCellType822;
            this.spdData_Sheet1.Columns.Get(825).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(825).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(826).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(826).CellType = textCellType823;
            this.spdData_Sheet1.Columns.Get(826).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(826).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(827).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(827).CellType = textCellType824;
            this.spdData_Sheet1.Columns.Get(827).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(827).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(828).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(828).CellType = textCellType825;
            this.spdData_Sheet1.Columns.Get(828).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(828).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(829).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(829).CellType = textCellType826;
            this.spdData_Sheet1.Columns.Get(829).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(829).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(830).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(830).CellType = textCellType827;
            this.spdData_Sheet1.Columns.Get(830).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(830).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(831).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(831).CellType = textCellType828;
            this.spdData_Sheet1.Columns.Get(831).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(831).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(832).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(832).CellType = textCellType829;
            this.spdData_Sheet1.Columns.Get(832).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(832).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(833).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(833).CellType = textCellType830;
            this.spdData_Sheet1.Columns.Get(833).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(833).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(834).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(834).CellType = textCellType831;
            this.spdData_Sheet1.Columns.Get(834).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(834).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(835).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(835).CellType = textCellType832;
            this.spdData_Sheet1.Columns.Get(835).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(835).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(836).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(836).CellType = textCellType833;
            this.spdData_Sheet1.Columns.Get(836).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(836).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(837).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(837).CellType = textCellType834;
            this.spdData_Sheet1.Columns.Get(837).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(837).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(838).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(838).CellType = textCellType835;
            this.spdData_Sheet1.Columns.Get(838).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(838).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(839).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(839).CellType = textCellType836;
            this.spdData_Sheet1.Columns.Get(839).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(839).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(840).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(840).CellType = textCellType837;
            this.spdData_Sheet1.Columns.Get(840).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(840).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(841).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(841).CellType = textCellType838;
            this.spdData_Sheet1.Columns.Get(841).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(841).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(842).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(842).CellType = textCellType839;
            this.spdData_Sheet1.Columns.Get(842).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(842).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(843).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(843).CellType = textCellType840;
            this.spdData_Sheet1.Columns.Get(843).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(843).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(844).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(844).CellType = textCellType841;
            this.spdData_Sheet1.Columns.Get(844).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(844).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(845).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(845).CellType = textCellType842;
            this.spdData_Sheet1.Columns.Get(845).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(845).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(846).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(846).CellType = textCellType843;
            this.spdData_Sheet1.Columns.Get(846).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(846).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(847).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(847).CellType = textCellType844;
            this.spdData_Sheet1.Columns.Get(847).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(847).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(848).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(848).CellType = textCellType845;
            this.spdData_Sheet1.Columns.Get(848).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(848).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(849).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(849).CellType = textCellType846;
            this.spdData_Sheet1.Columns.Get(849).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(849).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(850).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(850).CellType = textCellType847;
            this.spdData_Sheet1.Columns.Get(850).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(850).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(851).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(851).CellType = textCellType848;
            this.spdData_Sheet1.Columns.Get(851).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(851).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(852).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(852).CellType = textCellType849;
            this.spdData_Sheet1.Columns.Get(852).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(852).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(853).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(853).CellType = textCellType850;
            this.spdData_Sheet1.Columns.Get(853).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(853).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(854).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(854).CellType = textCellType851;
            this.spdData_Sheet1.Columns.Get(854).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(854).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(855).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(855).CellType = textCellType852;
            this.spdData_Sheet1.Columns.Get(855).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(855).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(856).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(856).CellType = textCellType853;
            this.spdData_Sheet1.Columns.Get(856).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(856).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(857).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(857).CellType = textCellType854;
            this.spdData_Sheet1.Columns.Get(857).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(857).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(858).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(858).CellType = textCellType855;
            this.spdData_Sheet1.Columns.Get(858).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(858).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(859).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(859).CellType = textCellType856;
            this.spdData_Sheet1.Columns.Get(859).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(859).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(860).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(860).CellType = textCellType857;
            this.spdData_Sheet1.Columns.Get(860).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(860).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(861).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(861).CellType = textCellType858;
            this.spdData_Sheet1.Columns.Get(861).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(861).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(862).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(862).CellType = textCellType859;
            this.spdData_Sheet1.Columns.Get(862).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(862).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(863).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(863).CellType = textCellType860;
            this.spdData_Sheet1.Columns.Get(863).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(863).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(864).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(864).CellType = textCellType861;
            this.spdData_Sheet1.Columns.Get(864).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(864).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(865).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(865).CellType = textCellType862;
            this.spdData_Sheet1.Columns.Get(865).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(865).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(866).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(866).CellType = textCellType863;
            this.spdData_Sheet1.Columns.Get(866).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(866).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(867).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(867).CellType = textCellType864;
            this.spdData_Sheet1.Columns.Get(867).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(867).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(868).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(868).CellType = textCellType865;
            this.spdData_Sheet1.Columns.Get(868).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(868).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(869).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(869).CellType = textCellType866;
            this.spdData_Sheet1.Columns.Get(869).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(869).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(870).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(870).CellType = textCellType867;
            this.spdData_Sheet1.Columns.Get(870).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(870).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(871).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(871).CellType = textCellType868;
            this.spdData_Sheet1.Columns.Get(871).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(871).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(872).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(872).CellType = textCellType869;
            this.spdData_Sheet1.Columns.Get(872).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(872).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(873).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(873).CellType = textCellType870;
            this.spdData_Sheet1.Columns.Get(873).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(873).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(874).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(874).CellType = textCellType871;
            this.spdData_Sheet1.Columns.Get(874).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(874).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(875).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(875).CellType = textCellType872;
            this.spdData_Sheet1.Columns.Get(875).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(875).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(876).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(876).CellType = textCellType873;
            this.spdData_Sheet1.Columns.Get(876).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(876).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(877).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(877).CellType = textCellType874;
            this.spdData_Sheet1.Columns.Get(877).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(877).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(878).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(878).CellType = textCellType875;
            this.spdData_Sheet1.Columns.Get(878).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(878).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(879).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(879).CellType = textCellType876;
            this.spdData_Sheet1.Columns.Get(879).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(879).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(880).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(880).CellType = textCellType877;
            this.spdData_Sheet1.Columns.Get(880).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(880).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(881).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(881).CellType = textCellType878;
            this.spdData_Sheet1.Columns.Get(881).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(881).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(882).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(882).CellType = textCellType879;
            this.spdData_Sheet1.Columns.Get(882).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(882).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(883).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(883).CellType = textCellType880;
            this.spdData_Sheet1.Columns.Get(883).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(883).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(884).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(884).CellType = textCellType881;
            this.spdData_Sheet1.Columns.Get(884).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(884).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(885).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(885).CellType = textCellType882;
            this.spdData_Sheet1.Columns.Get(885).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(885).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(886).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(886).CellType = textCellType883;
            this.spdData_Sheet1.Columns.Get(886).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(886).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(887).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(887).CellType = textCellType884;
            this.spdData_Sheet1.Columns.Get(887).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(887).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(888).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(888).CellType = textCellType885;
            this.spdData_Sheet1.Columns.Get(888).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(888).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(889).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(889).CellType = textCellType886;
            this.spdData_Sheet1.Columns.Get(889).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(889).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(890).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(890).CellType = textCellType887;
            this.spdData_Sheet1.Columns.Get(890).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(890).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(891).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(891).CellType = textCellType888;
            this.spdData_Sheet1.Columns.Get(891).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(891).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(892).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(892).CellType = textCellType889;
            this.spdData_Sheet1.Columns.Get(892).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(892).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(893).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(893).CellType = textCellType890;
            this.spdData_Sheet1.Columns.Get(893).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(893).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(894).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(894).CellType = textCellType891;
            this.spdData_Sheet1.Columns.Get(894).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(894).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(895).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(895).CellType = textCellType892;
            this.spdData_Sheet1.Columns.Get(895).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(895).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(896).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(896).CellType = textCellType893;
            this.spdData_Sheet1.Columns.Get(896).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(896).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(897).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(897).CellType = textCellType894;
            this.spdData_Sheet1.Columns.Get(897).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(897).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(898).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(898).CellType = textCellType895;
            this.spdData_Sheet1.Columns.Get(898).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(898).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(899).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(899).CellType = textCellType896;
            this.spdData_Sheet1.Columns.Get(899).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(899).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(900).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(900).CellType = textCellType897;
            this.spdData_Sheet1.Columns.Get(900).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(900).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(901).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(901).CellType = textCellType898;
            this.spdData_Sheet1.Columns.Get(901).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(901).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(902).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(902).CellType = textCellType899;
            this.spdData_Sheet1.Columns.Get(902).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(902).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(903).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(903).CellType = textCellType900;
            this.spdData_Sheet1.Columns.Get(903).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(903).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(904).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(904).CellType = textCellType901;
            this.spdData_Sheet1.Columns.Get(904).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(904).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(905).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(905).CellType = textCellType902;
            this.spdData_Sheet1.Columns.Get(905).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(905).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(906).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(906).CellType = textCellType903;
            this.spdData_Sheet1.Columns.Get(906).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(906).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(907).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(907).CellType = textCellType904;
            this.spdData_Sheet1.Columns.Get(907).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(907).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(908).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(908).CellType = textCellType905;
            this.spdData_Sheet1.Columns.Get(908).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(908).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(909).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(909).CellType = textCellType906;
            this.spdData_Sheet1.Columns.Get(909).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(909).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(910).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(910).CellType = textCellType907;
            this.spdData_Sheet1.Columns.Get(910).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(910).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(911).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(911).CellType = textCellType908;
            this.spdData_Sheet1.Columns.Get(911).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(911).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(912).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(912).CellType = textCellType909;
            this.spdData_Sheet1.Columns.Get(912).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(912).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(913).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(913).CellType = textCellType910;
            this.spdData_Sheet1.Columns.Get(913).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(913).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(914).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(914).CellType = textCellType911;
            this.spdData_Sheet1.Columns.Get(914).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(914).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(915).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(915).CellType = textCellType912;
            this.spdData_Sheet1.Columns.Get(915).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(915).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(916).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(916).CellType = textCellType913;
            this.spdData_Sheet1.Columns.Get(916).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(916).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(917).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(917).CellType = textCellType914;
            this.spdData_Sheet1.Columns.Get(917).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(917).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(918).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(918).CellType = textCellType915;
            this.spdData_Sheet1.Columns.Get(918).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(918).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(919).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(919).CellType = textCellType916;
            this.spdData_Sheet1.Columns.Get(919).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(919).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(920).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(920).CellType = textCellType917;
            this.spdData_Sheet1.Columns.Get(920).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(920).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(921).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(921).CellType = textCellType918;
            this.spdData_Sheet1.Columns.Get(921).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(921).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(922).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(922).CellType = textCellType919;
            this.spdData_Sheet1.Columns.Get(922).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(922).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(923).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(923).CellType = textCellType920;
            this.spdData_Sheet1.Columns.Get(923).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(923).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(924).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(924).CellType = textCellType921;
            this.spdData_Sheet1.Columns.Get(924).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(924).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(925).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(925).CellType = textCellType922;
            this.spdData_Sheet1.Columns.Get(925).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(925).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(926).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(926).CellType = textCellType923;
            this.spdData_Sheet1.Columns.Get(926).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(926).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(927).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(927).CellType = textCellType924;
            this.spdData_Sheet1.Columns.Get(927).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(927).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(928).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(928).CellType = textCellType925;
            this.spdData_Sheet1.Columns.Get(928).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(928).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(929).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(929).CellType = textCellType926;
            this.spdData_Sheet1.Columns.Get(929).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(929).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(930).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(930).CellType = textCellType927;
            this.spdData_Sheet1.Columns.Get(930).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(930).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(931).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(931).CellType = textCellType928;
            this.spdData_Sheet1.Columns.Get(931).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(931).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(932).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(932).CellType = textCellType929;
            this.spdData_Sheet1.Columns.Get(932).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(932).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(933).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(933).CellType = textCellType930;
            this.spdData_Sheet1.Columns.Get(933).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(933).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(934).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(934).CellType = textCellType931;
            this.spdData_Sheet1.Columns.Get(934).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(934).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(935).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(935).CellType = textCellType932;
            this.spdData_Sheet1.Columns.Get(935).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(935).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(936).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(936).CellType = textCellType933;
            this.spdData_Sheet1.Columns.Get(936).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(936).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(937).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(937).CellType = textCellType934;
            this.spdData_Sheet1.Columns.Get(937).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(937).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(938).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(938).CellType = textCellType935;
            this.spdData_Sheet1.Columns.Get(938).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(938).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(939).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(939).CellType = textCellType936;
            this.spdData_Sheet1.Columns.Get(939).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(939).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(940).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(940).CellType = textCellType937;
            this.spdData_Sheet1.Columns.Get(940).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(940).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(941).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(941).CellType = textCellType938;
            this.spdData_Sheet1.Columns.Get(941).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(941).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(942).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(942).CellType = textCellType939;
            this.spdData_Sheet1.Columns.Get(942).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(942).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(943).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(943).CellType = textCellType940;
            this.spdData_Sheet1.Columns.Get(943).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(943).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(944).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(944).CellType = textCellType941;
            this.spdData_Sheet1.Columns.Get(944).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(944).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(945).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(945).CellType = textCellType942;
            this.spdData_Sheet1.Columns.Get(945).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(945).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(946).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(946).CellType = textCellType943;
            this.spdData_Sheet1.Columns.Get(946).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(946).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(947).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(947).CellType = textCellType944;
            this.spdData_Sheet1.Columns.Get(947).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(947).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(948).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(948).CellType = textCellType945;
            this.spdData_Sheet1.Columns.Get(948).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(948).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(949).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(949).CellType = textCellType946;
            this.spdData_Sheet1.Columns.Get(949).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(949).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(950).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(950).CellType = textCellType947;
            this.spdData_Sheet1.Columns.Get(950).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(950).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(951).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(951).CellType = textCellType948;
            this.spdData_Sheet1.Columns.Get(951).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(951).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(952).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(952).CellType = textCellType949;
            this.spdData_Sheet1.Columns.Get(952).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(952).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(953).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(953).CellType = textCellType950;
            this.spdData_Sheet1.Columns.Get(953).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(953).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(954).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(954).CellType = textCellType951;
            this.spdData_Sheet1.Columns.Get(954).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(954).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(955).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(955).CellType = textCellType952;
            this.spdData_Sheet1.Columns.Get(955).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(955).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(956).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(956).CellType = textCellType953;
            this.spdData_Sheet1.Columns.Get(956).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(956).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(957).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(957).CellType = textCellType954;
            this.spdData_Sheet1.Columns.Get(957).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(957).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(958).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(958).CellType = textCellType955;
            this.spdData_Sheet1.Columns.Get(958).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(958).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(959).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(959).CellType = textCellType956;
            this.spdData_Sheet1.Columns.Get(959).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(959).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(960).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(960).CellType = textCellType957;
            this.spdData_Sheet1.Columns.Get(960).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(960).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(961).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(961).CellType = textCellType958;
            this.spdData_Sheet1.Columns.Get(961).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(961).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(962).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(962).CellType = textCellType959;
            this.spdData_Sheet1.Columns.Get(962).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(962).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(963).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(963).CellType = textCellType960;
            this.spdData_Sheet1.Columns.Get(963).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(963).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(964).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(964).CellType = textCellType961;
            this.spdData_Sheet1.Columns.Get(964).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(964).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(965).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(965).CellType = textCellType962;
            this.spdData_Sheet1.Columns.Get(965).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(965).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(966).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(966).CellType = textCellType963;
            this.spdData_Sheet1.Columns.Get(966).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(966).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(967).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(967).CellType = textCellType964;
            this.spdData_Sheet1.Columns.Get(967).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(967).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(968).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(968).CellType = textCellType965;
            this.spdData_Sheet1.Columns.Get(968).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(968).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(969).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(969).CellType = textCellType966;
            this.spdData_Sheet1.Columns.Get(969).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(969).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(970).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(970).CellType = textCellType967;
            this.spdData_Sheet1.Columns.Get(970).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(970).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(971).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(971).CellType = textCellType968;
            this.spdData_Sheet1.Columns.Get(971).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(971).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(972).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(972).CellType = textCellType969;
            this.spdData_Sheet1.Columns.Get(972).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(972).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(973).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(973).CellType = textCellType970;
            this.spdData_Sheet1.Columns.Get(973).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(973).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(974).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(974).CellType = textCellType971;
            this.spdData_Sheet1.Columns.Get(974).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(974).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(975).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(975).CellType = textCellType972;
            this.spdData_Sheet1.Columns.Get(975).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(975).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(976).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(976).CellType = textCellType973;
            this.spdData_Sheet1.Columns.Get(976).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(976).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(977).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(977).CellType = textCellType974;
            this.spdData_Sheet1.Columns.Get(977).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(977).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(978).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(978).CellType = textCellType975;
            this.spdData_Sheet1.Columns.Get(978).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(978).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(979).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(979).CellType = textCellType976;
            this.spdData_Sheet1.Columns.Get(979).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(979).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(980).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(980).CellType = textCellType977;
            this.spdData_Sheet1.Columns.Get(980).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(980).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(981).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(981).CellType = textCellType978;
            this.spdData_Sheet1.Columns.Get(981).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(981).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(982).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(982).CellType = textCellType979;
            this.spdData_Sheet1.Columns.Get(982).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(982).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(983).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(983).CellType = textCellType980;
            this.spdData_Sheet1.Columns.Get(983).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(983).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(984).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(984).CellType = textCellType981;
            this.spdData_Sheet1.Columns.Get(984).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(984).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(985).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(985).CellType = textCellType982;
            this.spdData_Sheet1.Columns.Get(985).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(985).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(986).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(986).CellType = textCellType983;
            this.spdData_Sheet1.Columns.Get(986).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(986).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(987).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(987).CellType = textCellType984;
            this.spdData_Sheet1.Columns.Get(987).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(987).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(988).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(988).CellType = textCellType985;
            this.spdData_Sheet1.Columns.Get(988).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(988).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(989).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(989).CellType = textCellType986;
            this.spdData_Sheet1.Columns.Get(989).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(989).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(990).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(990).CellType = textCellType987;
            this.spdData_Sheet1.Columns.Get(990).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(990).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(991).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(991).CellType = textCellType988;
            this.spdData_Sheet1.Columns.Get(991).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(991).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(992).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(992).CellType = textCellType989;
            this.spdData_Sheet1.Columns.Get(992).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(992).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(993).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(993).CellType = textCellType990;
            this.spdData_Sheet1.Columns.Get(993).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(993).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(994).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(994).CellType = textCellType991;
            this.spdData_Sheet1.Columns.Get(994).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(994).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(995).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(995).CellType = textCellType992;
            this.spdData_Sheet1.Columns.Get(995).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(995).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(996).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(996).CellType = textCellType993;
            this.spdData_Sheet1.Columns.Get(996).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(996).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(997).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(997).CellType = textCellType994;
            this.spdData_Sheet1.Columns.Get(997).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(997).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(998).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(998).CellType = textCellType995;
            this.spdData_Sheet1.Columns.Get(998).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(998).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(999).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(999).CellType = textCellType996;
            this.spdData_Sheet1.Columns.Get(999).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(999).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1000).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1000).CellType = textCellType997;
            this.spdData_Sheet1.Columns.Get(1000).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1000).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1001).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1001).CellType = textCellType998;
            this.spdData_Sheet1.Columns.Get(1001).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1001).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1002).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1002).CellType = textCellType999;
            this.spdData_Sheet1.Columns.Get(1002).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1002).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1003).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1003).CellType = textCellType1000;
            this.spdData_Sheet1.Columns.Get(1003).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1003).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1004).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1004).CellType = textCellType1001;
            this.spdData_Sheet1.Columns.Get(1004).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1004).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1005).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1005).CellType = textCellType1002;
            this.spdData_Sheet1.Columns.Get(1005).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1005).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1006).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1006).CellType = textCellType1003;
            this.spdData_Sheet1.Columns.Get(1006).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1006).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1007).CellType = textCellType1004;
            this.spdData_Sheet1.Columns.Get(1007).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1007).Locked = true;
            this.spdData_Sheet1.Columns.Get(1007).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1007).Width = 80F;
            this.spdData_Sheet1.Columns.Get(1008).CellType = textCellType1005;
            this.spdData_Sheet1.Columns.Get(1008).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1008).Locked = true;
            this.spdData_Sheet1.Columns.Get(1008).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1008).Width = 80F;
            this.spdData_Sheet1.Columns.Get(1009).CellType = textCellType1006;
            this.spdData_Sheet1.Columns.Get(1009).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1009).Locked = true;
            this.spdData_Sheet1.Columns.Get(1009).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1009).Width = 80F;
            this.spdData_Sheet1.Columns.Get(1010).CellType = textCellType1007;
            this.spdData_Sheet1.Columns.Get(1010).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1010).Locked = true;
            this.spdData_Sheet1.Columns.Get(1010).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1010).Width = 80F;
            this.spdData_Sheet1.Columns.Get(1011).CellType = textCellType1008;
            this.spdData_Sheet1.Columns.Get(1011).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1011).Locked = true;
            this.spdData_Sheet1.Columns.Get(1011).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1011).Width = 80F;
            this.spdData_Sheet1.Columns.Get(1012).CellType = textCellType1009;
            this.spdData_Sheet1.Columns.Get(1012).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1012).Locked = true;
            this.spdData_Sheet1.Columns.Get(1012).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1012).Width = 80F;
            this.spdData_Sheet1.Columns.Get(1013).Visible = false;
            this.spdData_Sheet1.Columns.Get(1014).Visible = false;
            this.spdData_Sheet1.Columns.Get(1015).Visible = false;
            this.spdData_Sheet1.Columns.Get(1016).Visible = false;
            this.spdData_Sheet1.Columns.Get(1017).Visible = false;
            this.spdData_Sheet1.Columns.Get(1018).Visible = false;
            this.spdData_Sheet1.FrozenColumnCount = 1;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpComment.Location = new System.Drawing.Point(0, 316);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(786, 40);
            this.grpComment.TabIndex = 12;
            this.grpComment.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(120, 12);
            this.txtComment.MaxLength = 200;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(652, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 15);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpChartSet
            // 
            this.grpChartSet.Controls.Add(this.cdvUserID);
            this.grpChartSet.Controls.Add(this.lblUserID);
            this.grpChartSet.Controls.Add(this.cdvChartSetID);
            this.grpChartSet.Controls.Add(this.lblChartSetID);
            this.grpChartSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChartSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartSet.Location = new System.Drawing.Point(3, 192);
            this.grpChartSet.Name = "grpChartSet";
            this.grpChartSet.Size = new System.Drawing.Size(786, 48);
            this.grpChartSet.TabIndex = 2;
            this.grpChartSet.TabStop = false;
            // 
            // cdvUserID
            // 
            this.cdvUserID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUserID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUserID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUserID.BtnToolTipText = "";
            this.cdvUserID.DescText = "";
            this.cdvUserID.DisplaySubItemIndex = -1;
            this.cdvUserID.DisplayText = "";
            this.cdvUserID.Focusing = null;
            this.cdvUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUserID.Index = 0;
            this.cdvUserID.IsViewBtnImage = false;
            this.cdvUserID.Location = new System.Drawing.Point(574, 16);
            this.cdvUserID.MaxLength = 20;
            this.cdvUserID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.Name = "cdvUserID";
            this.cdvUserID.ReadOnly = false;
            this.cdvUserID.SearchSubItemIndex = 0;
            this.cdvUserID.SelectedDescIndex = -1;
            this.cdvUserID.SelectedSubItemIndex = -1;
            this.cdvUserID.SelectionStart = 0;
            this.cdvUserID.Size = new System.Drawing.Size(200, 20);
            this.cdvUserID.SmallImageList = null;
            this.cdvUserID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUserID.TabIndex = 1;
            this.cdvUserID.TextBoxToolTipText = "";
            this.cdvUserID.TextBoxWidth = 200;
            this.cdvUserID.VisibleButton = true;
            this.cdvUserID.VisibleColumnHeader = false;
            this.cdvUserID.VisibleDescription = false;
            this.cdvUserID.ButtonPress += new System.EventHandler(this.cdvUserID_ButtonPress);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(464, 19);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(50, 13);
            this.lblUserID.TabIndex = 16;
            this.lblUserID.Text = "User ID";
            this.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvChartSetID
            // 
            this.cdvChartSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChartSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChartSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChartSetID.BtnToolTipText = "";
            this.cdvChartSetID.DescText = "";
            this.cdvChartSetID.DisplaySubItemIndex = -1;
            this.cdvChartSetID.DisplayText = "";
            this.cdvChartSetID.Focusing = null;
            this.cdvChartSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChartSetID.Index = 0;
            this.cdvChartSetID.IsViewBtnImage = false;
            this.cdvChartSetID.Location = new System.Drawing.Point(124, 16);
            this.cdvChartSetID.MaxLength = 30;
            this.cdvChartSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.Name = "cdvChartSetID";
            this.cdvChartSetID.ReadOnly = false;
            this.cdvChartSetID.SearchSubItemIndex = 0;
            this.cdvChartSetID.SelectedDescIndex = -1;
            this.cdvChartSetID.SelectedSubItemIndex = -1;
            this.cdvChartSetID.SelectionStart = 0;
            this.cdvChartSetID.Size = new System.Drawing.Size(200, 20);
            this.cdvChartSetID.SmallImageList = null;
            this.cdvChartSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartSetID.TabIndex = 0;
            this.cdvChartSetID.TextBoxToolTipText = "";
            this.cdvChartSetID.TextBoxWidth = 200;
            this.cdvChartSetID.VisibleButton = true;
            this.cdvChartSetID.VisibleColumnHeader = false;
            this.cdvChartSetID.VisibleDescription = false;
            this.cdvChartSetID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartSetID_SelectedItemChanged);
            this.cdvChartSetID.ButtonPress += new System.EventHandler(this.cdvChartSetID_ButtonPress);
            this.cdvChartSetID.TextBoxTextChanged += new System.EventHandler(this.cdvChartSetID_TextBoxTextChanged);
            // 
            // lblChartSetID
            // 
            this.lblChartSetID.AutoSize = true;
            this.lblChartSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartSetID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartSetID.Location = new System.Drawing.Point(15, 19);
            this.lblChartSetID.Name = "lblChartSetID";
            this.lblChartSetID.Size = new System.Drawing.Size(77, 13);
            this.lblChartSetID.TabIndex = 0;
            this.lblChartSetID.Text = "Chart Set ID";
            // 
            // grpLot
            // 
            this.grpLot.Controls.Add(this.cdvFlow);
            this.grpLot.Controls.Add(this.cdvMaterial);
            this.grpLot.Controls.Add(this.cdvOper);
            this.grpLot.Controls.Add(this.chkSelectMFO);
            this.grpLot.Controls.Add(this.cdvProcResID);
            this.grpLot.Controls.Add(this.lblProcResID);
            this.grpLot.Controls.Add(this.cdvProcOper);
            this.grpLot.Controls.Add(this.lblProcOper);
            this.grpLot.Controls.Add(this.cdvResID);
            this.grpLot.Controls.Add(this.lblResID);
            this.grpLot.Controls.Add(this.lblOper);
            this.grpLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLot.Location = new System.Drawing.Point(3, 73);
            this.grpLot.Name = "grpLot";
            this.grpLot.Size = new System.Drawing.Size(786, 119);
            this.grpLot.TabIndex = 1;
            this.grpLot.TabStop = false;
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 113;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = ' ';
            this.cdvFlow.Location = new System.Drawing.Point(461, 40);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(312, 20);
            this.cdvFlow.TabIndex = 2;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 199;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_FlowSelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_FlowButtonPress);
            this.cdvFlow.FlowTextChanged += new System.EventHandler(this.cdvFlow_FlowTextChanged);
            this.cdvFlow.SeqButtonPress += new System.EventHandler(this.cdvFlow_SeqButtonPress);
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.DisplaySubItemIndex = -1;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(14, 40);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = true;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = -1;
            this.cdvMaterial.Size = new System.Drawing.Size(310, 20);
            this.cdvMaterial.TabIndex = 1;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = true;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = false;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 110;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // cdvOper
            // 
            this.cdvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOper.BtnToolTipText = "";
            this.cdvOper.DescText = "";
            this.cdvOper.DisplaySubItemIndex = -1;
            this.cdvOper.DisplayText = "";
            this.cdvOper.Focusing = null;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.Index = 0;
            this.cdvOper.IsViewBtnImage = false;
            this.cdvOper.Location = new System.Drawing.Point(124, 64);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(200, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 4;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 200;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            this.cdvOper.TextBoxTextChanged += new System.EventHandler(this.cdvOper_TextBoxTextChanged);
            // 
            // chkSelectMFO
            // 
            this.chkSelectMFO.AutoSize = true;
            this.chkSelectMFO.Location = new System.Drawing.Point(15, 18);
            this.chkSelectMFO.Name = "chkSelectMFO";
            this.chkSelectMFO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSelectMFO.Size = new System.Drawing.Size(110, 17);
            this.chkSelectMFO.TabIndex = 0;
            this.chkSelectMFO.Text = "Select Lot MFO";
            this.chkSelectMFO.CheckedChanged += new System.EventHandler(this.chkSelectMFO_CheckedChanged);
            // 
            // cdvProcResID
            // 
            this.cdvProcResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcResID.BtnToolTipText = "";
            this.cdvProcResID.DescText = "";
            this.cdvProcResID.DisplaySubItemIndex = -1;
            this.cdvProcResID.DisplayText = "";
            this.cdvProcResID.Focusing = null;
            this.cdvProcResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcResID.Index = 0;
            this.cdvProcResID.IsViewBtnImage = false;
            this.cdvProcResID.Location = new System.Drawing.Point(574, 88);
            this.cdvProcResID.MaxLength = 20;
            this.cdvProcResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvProcResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvProcResID.Name = "cdvProcResID";
            this.cdvProcResID.ReadOnly = false;
            this.cdvProcResID.SearchSubItemIndex = 0;
            this.cdvProcResID.SelectedDescIndex = -1;
            this.cdvProcResID.SelectedSubItemIndex = -1;
            this.cdvProcResID.SelectionStart = 0;
            this.cdvProcResID.Size = new System.Drawing.Size(200, 20);
            this.cdvProcResID.SmallImageList = null;
            this.cdvProcResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcResID.TabIndex = 10;
            this.cdvProcResID.TextBoxToolTipText = "";
            this.cdvProcResID.TextBoxWidth = 200;
            this.cdvProcResID.VisibleButton = true;
            this.cdvProcResID.VisibleColumnHeader = false;
            this.cdvProcResID.VisibleDescription = false;
            this.cdvProcResID.ButtonPress += new System.EventHandler(this.cdvProcResID_ButtonPress);
            // 
            // lblProcResID
            // 
            this.lblProcResID.AutoSize = true;
            this.lblProcResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcResID.Location = new System.Drawing.Point(462, 92);
            this.lblProcResID.Name = "lblProcResID";
            this.lblProcResID.Size = new System.Drawing.Size(108, 13);
            this.lblProcResID.TabIndex = 9;
            this.lblProcResID.Text = "Process Resource ID";
            this.lblProcResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvProcOper
            // 
            this.cdvProcOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcOper.BtnToolTipText = "";
            this.cdvProcOper.DescText = "";
            this.cdvProcOper.DisplaySubItemIndex = -1;
            this.cdvProcOper.DisplayText = "";
            this.cdvProcOper.Focusing = null;
            this.cdvProcOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcOper.Index = 0;
            this.cdvProcOper.IsViewBtnImage = false;
            this.cdvProcOper.Location = new System.Drawing.Point(574, 64);
            this.cdvProcOper.MaxLength = 10;
            this.cdvProcOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvProcOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvProcOper.Name = "cdvProcOper";
            this.cdvProcOper.ReadOnly = false;
            this.cdvProcOper.SearchSubItemIndex = 0;
            this.cdvProcOper.SelectedDescIndex = -1;
            this.cdvProcOper.SelectedSubItemIndex = -1;
            this.cdvProcOper.SelectionStart = 0;
            this.cdvProcOper.Size = new System.Drawing.Size(200, 20);
            this.cdvProcOper.SmallImageList = null;
            this.cdvProcOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcOper.TabIndex = 6;
            this.cdvProcOper.TextBoxToolTipText = "";
            this.cdvProcOper.TextBoxWidth = 200;
            this.cdvProcOper.VisibleButton = true;
            this.cdvProcOper.VisibleColumnHeader = false;
            this.cdvProcOper.VisibleDescription = false;
            this.cdvProcOper.ButtonPress += new System.EventHandler(this.cdvProcOper_ButtonPress);
            // 
            // lblProcOper
            // 
            this.lblProcOper.AutoSize = true;
            this.lblProcOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcOper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcOper.Location = new System.Drawing.Point(462, 68);
            this.lblProcOper.Name = "lblProcOper";
            this.lblProcOper.Size = new System.Drawing.Size(94, 13);
            this.lblProcOper.TabIndex = 5;
            this.lblProcOper.Text = "Process Operation";
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
            this.cdvResID.Location = new System.Drawing.Point(124, 88);
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
            this.cdvResID.TabIndex = 8;
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
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 92);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 7;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Location = new System.Drawing.Point(15, 68);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 3;
            this.lblOper.Text = "Operation";
            // 
            // grpLotID
            // 
            this.grpLotID.Controls.Add(this.txtLot);
            this.grpLotID.Controls.Add(this.pnlTranTime);
            this.grpLotID.Controls.Add(this.txtDesc);
            this.grpLotID.Controls.Add(this.lblLotDesc);
            this.grpLotID.Controls.Add(this.lblLotID);
            this.grpLotID.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotID.Location = new System.Drawing.Point(3, 0);
            this.grpLotID.Name = "grpLotID";
            this.grpLotID.Size = new System.Drawing.Size(786, 73);
            this.grpLotID.TabIndex = 0;
            this.grpLotID.TabStop = false;
            // 
            // txtLot
            // 
            this.txtLot.Location = new System.Drawing.Point(124, 16);
            this.txtLot.MaxLength = 25;
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(200, 20);
            this.txtLot.TabIndex = 0;
            this.txtLot.TextChanged += new System.EventHandler(this.txtLot_TextChanged);
            this.txtLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLot_KeyPress);
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranTime.Controls.Add(this.txtTranTime);
            this.pnlTranTime.Controls.Add(this.udtTranTime);
            this.pnlTranTime.Controls.Add(this.uccTranDate);
            this.pnlTranTime.Controls.Add(this.chkTranDateTime);
            this.pnlTranTime.Location = new System.Drawing.Point(478, 15);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 23);
            this.pnlTranTime.TabIndex = 1;
            // 
            // txtTranTime
            // 
            this.txtTranTime.Location = new System.Drawing.Point(128, 1);
            this.txtTranTime.MaxLength = 30;
            this.txtTranTime.Name = "txtTranTime";
            this.txtTranTime.ReadOnly = true;
            this.txtTranTime.Size = new System.Drawing.Size(168, 20);
            this.txtTranTime.TabIndex = 1;
            // 
            // udtTranTime
            // 
            this.udtTranTime.DateTime = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            this.udtTranTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtTranTime.FormatString = "";
            this.udtTranTime.Location = new System.Drawing.Point(220, 1);
            this.udtTranTime.MaskInput = "hh:mm:ss";
            this.udtTranTime.Name = "udtTranTime";
            this.udtTranTime.Size = new System.Drawing.Size(72, 21);
            this.udtTranTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtTranTime.SpinWrap = true;
            this.udtTranTime.TabIndex = 2;
            this.udtTranTime.Value = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            // 
            // uccTranDate
            // 
            this.uccTranDate.DateButtons.Add(dateButton1);
            this.uccTranDate.Location = new System.Drawing.Point(128, 1);
            this.uccTranDate.Name = "uccTranDate";
            this.uccTranDate.NonAutoSizeHeight = 21;
            this.uccTranDate.Size = new System.Drawing.Size(88, 21);
            this.uccTranDate.TabIndex = 3;
            this.uccTranDate.Value = new System.DateTime(2005, 5, 9, 0, 0, 0, 0);
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(3, 3);
            this.chkTranDateTime.Name = "chkTranDateTime";
            this.chkTranDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTranDateTime.Size = new System.Drawing.Size(121, 17);
            this.chkTranDateTime.TabIndex = 0;
            this.chkTranDateTime.Text = "Transaction Time";
            this.chkTranDateTime.CheckedChanged += new System.EventHandler(this.chkTranDateTime_CheckedChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(124, 41);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(650, 20);
            this.txtDesc.TabIndex = 2;
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotDesc.Location = new System.Drawing.Point(15, 44);
            this.lblLotDesc.Name = "lblLotDesc";
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            this.lblLotDesc.TabIndex = 3;
            this.lblLotDesc.Text = "Description";
            this.lblLotDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSPCTranCollectLotDataType3
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 636);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 670);
            this.Name = "frmSPCTranCollectLotDataType3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Collect Lot Data by Chart Set (Type 3)";
            this.Activated += new System.EventHandler(this.frmSPCTranCollectLotDataType3_Activated);
            this.Load += new System.EventHandler(this.frmSPCTranCollectLotDataType3_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlChartSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            this.grpChartSet.ResumeLayout(false);
            this.grpChartSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).EndInit();
            this.grpLot.ResumeLayout(false);
            this.grpLot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectMFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.grpLotID.ResumeLayout(false);
            this.grpLotID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLot)).EndInit();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTranTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTranTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTranDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTranDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition"
        private const int CHART_COL = 0;
        private const int CHART_DESC_COL = 1;
        private const int SPEC_COL = 2;
        private const int RESULT_COL = 3;
        private const int UNIT_COL = 4;
        private const int NOMINAL_COL = 5;
        private const int PROCSIGMA_COL = 6;
        private const int VALUE_1_COL = 7;
        private const int WEIGHT_COL = 1007;
        private const int AVERAGE_COL = 1008;
        private const int SIGMA_COL = 1009;
        private const int RANGE_COL = 1010;
        private const int MAX_COL = 1011;
        private const int MIN_COL = 1012;
        
        private const int UNIT_COUNT_COL = 1013;
        private const int SAMPLE_SIZE_COL = 1014;
        private const int GRAPH_TYPE_COL = 1015;
        private const int UNIT_USE_COL = 1016;
        private const int PRECISION_COL = 1017;
        private const int SPEC_CHECK_COL = 1018;
        #endregion
        
        #region " Variable Definition"
        private bool b_load_flag = false;
        private ArrayList DisabledFormControls = new ArrayList();
        //Private giGroupIndex As Integer = -1
        //Private giLotIndex As Integer = -1
        #endregion
        
        #region " Function Implementations"
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef ctrlChartInfo As frmSPCTranCollectLotDataType3
        //
        private bool CheckCondition()
        {
            
            try
            {
                int i;
                int j;
                if (txtLot.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtLot.Focus();
                    return false;
                }
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMaterial.MaterialFocus();
                    return false;
                }
                if (cdvFlow.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvFlow.Focus();
                    return false;
                }
                if (cdvOper.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvOper.Focus();
                    return false;
                }
                if (MPCF.CheckValue(cdvUserID, 1) == false)
                {
                    return false;
                }
                
                for (i = 0; i <= spdData.Sheets[0].RowCount - 1; i++)
                {
                    if (MPCF.Trim(spdData.Sheets[0].Cells[i, UNIT_COL].Tag) != "NULL")
                    {
                        if (MPCF.Trim(spdData.Sheets[0].Cells[i, UNIT_COL].Value) == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            spdData.Sheets[0].SetActiveCell(i, UNIT_COL);
                            spdData.Select();
                            return false;
                        }
                    }
                }
                
                for (i = 0; i <= spdData.Sheets[0].RowCount - 1; i++)
                {
                    for (j = VALUE_1_COL; j <= VALUE_1_COL + modSPCConstants.VALUE_COUNT - 1; j++)
                    {
                        if (spdData.Sheets[0].Cells[i, j].Locked == false)
                        {
                            if (MPCF.Trim(spdData.Sheets[0].Cells[i, j].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdData.Sheets[0].SetActiveCell(i, j);
                                spdData.Select();
                                return false;
                            }
                            else
                            {
                                if (MPCF.Trim(spdData.Sheets[0].Cells[i, GRAPH_TYPE_COL].Value) != eGraphType.NULL.ToString())
                                {
                                    if (MPCF.CheckNumeric(MPCF.Trim(spdData.Sheets[0].Cells[i, j].Value)) == false)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                        spdData.Sheets[0].SetActiveCell(i, j);
                                        spdData.Select();
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Lot()
        //       - View Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Lot()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Lot_In");
                TRSNode out_node = new TRSNode("View_Lot_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLot.Text);                
                
                if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }
                txtDesc.Text = out_node.GetString("LOT_DESC");
                cdvMaterial.Text = out_node.GetString("MAT_ID");
                cdvMaterial.Version = out_node.GetInt("MAT_VER");
                cdvFlow.Text = out_node.GetString("FLOW");
                cdvFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
                cdvOper.Text = out_node.GetString("OPER");
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.View_Lot()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Chart()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sChartID As String : 차트 �?
        //
        private bool View_Chart(string sChartID, ref int iSampleSize, ref string sZbarFlag)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node = new TRSNode("View_Chart_Out");
                int i;
                int j;
                int iGraphType;
                int iStartIndex;
                int iVer = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));

                if (MPCR.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return false;
                }

                iSampleSize = out_node.GetInt("SAMPLE_SIZE");
                iGraphType = (int)Enum.Parse(typeof(eGraphType), out_node.GetString("GRAPH_TYPE"));
                if (iGraphType == MPCF.ToInt(eGraphType.XBARR) || iGraphType == MPCF.ToInt(eGraphType.XBARS) || 
                    iGraphType == MPCF.ToInt(eGraphType.XRS) || iGraphType == MPCF.ToInt(eGraphType.ZBARS) || 
                    iGraphType == MPCF.ToInt(eGraphType.DELTAS) || iGraphType == MPCF.ToInt(eGraphType.NULL))
                {
                    spdData.Sheets[0].RowCount += out_node.GetInt("UNIT_COUNT");
                }
                else
                {
                    spdData.Sheets[0].RowCount++;
                }
                
                //sDefUnitFlag = MPCF.Trim(View_Chart_Out.def_unit_flag);
                //sDefUnitOvrFlag = MPCF.Trim(View_Chart_Out.def_unit_ovr_flag);
                //sUnitTable = MPCF.Trim(View_Chart_Out.unit_tbl);
                //sValueTable = MPCF.Trim(View_Chart_Out.value_tbl);
                //sDefaultValue = MPCF.Trim(View_Chart_Out.def_value);
                
                if (iGraphType == MPCF.ToInt(eGraphType.P) || iGraphType == MPCF.ToInt(eGraphType.U) || 
                    iGraphType == MPCF.ToInt(eGraphType.PN) || iGraphType == MPCF.ToInt(eGraphType.C))
                {
                    if (iGraphType == MPCF.ToInt(eGraphType.P) || iGraphType == MPCF.ToInt(eGraphType.U))
                    {
                        iSampleSize = 2;
                        MPCR.SetNumberCell(spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, VALUE_1_COL + 1]);
                        iStartIndex = VALUE_1_COL + 2;
                    }
                    else
                    {
                        iSampleSize = 1;
                        iStartIndex = VALUE_1_COL + 1;
                    }
                    
                    for (j = iStartIndex; j <= VALUE_1_COL + modSPCConstants.VALUE_COUNT - 1; j++)
                    {
                        spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, j].Locked = true;
                        spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, j].BackColor = Color.White;
                    }
                    
                    MPCR.SetNumberCell(spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, VALUE_1_COL]);
                    
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, PROCSIGMA_COL].Locked = true;
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, PROCSIGMA_COL].BackColor = Color.White;
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, NOMINAL_COL].Locked = true;
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, NOMINAL_COL].BackColor = Color.White;
                    
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, CHART_COL].Value = sChartID;
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, CHART_DESC_COL].Value = out_node.GetString("CHART_DESC");
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, UNIT_COUNT_COL].Value = out_node.GetInt("UNIT_COUNT");
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, SAMPLE_SIZE_COL].Value = out_node.GetInt("SAMPLE_SIZE");
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, GRAPH_TYPE_COL].Value = out_node.GetString("GRAPH_TYPE");
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, UNIT_USE_COL].Value = out_node.GetChar("UNIT_USE_FLAG");
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, PRECISION_COL].Value = out_node.GetInt("PRECISION_LIMIT");
                    spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - 1, SPEC_CHECK_COL].Value = out_node.GetChar("SPEC_CHECK_TYPE");
                    
                }
                else
                {
                    
                    for (i = spdData.Sheets[0].RowCount - out_node.GetInt("UNIT_COUNT"); i <= spdData.Sheets[0].RowCount - 1; i++)
                    {
                        for (j = VALUE_1_COL; j <= VALUE_1_COL + modSPCConstants.VALUE_COUNT - 1; j++)
                        {
                            if (iGraphType == MPCF.ToInt(eGraphType.NULL))
                            {
                                MPCR.SetAsciiCell(spdData.Sheets[0].Cells[i, j]);
                            }
                            else
                            {
                                MPCR.SetNumberCell(spdData.Sheets[0].Cells[i, j]);
                            }
                        }
                        for (j = VALUE_1_COL + iSampleSize; j <= VALUE_1_COL + modSPCConstants.VALUE_COUNT - 1; j++)
                        {
                            spdData.Sheets[0].Cells[i, j].Locked = true;
                            spdData.Sheets[0].Cells[i, j].BackColor = Color.White;
                        }
                        if (iGraphType == MPCF.ToInt(eGraphType.ZBARS))
                        {
                            sZbarFlag = "Z";
                            MPCR.SetNumberCell(spdData.Sheets[0].Cells[i, PROCSIGMA_COL]);
                            MPCR.SetNumberCell(spdData.Sheets[0].Cells[i, NOMINAL_COL]);
                            if (i == spdData.Sheets[0].RowCount - out_node.GetInt("UNIT_COUNT"))
                            {
                                spdData.Sheets[0].Cells[i, NOMINAL_COL].RowSpan = out_node.GetInt("UNIT_COUNT");
                                spdData.Sheets[0].Cells[i, PROCSIGMA_COL].RowSpan = out_node.GetInt("UNIT_COUNT");
                            }
                        }
                        else if (iGraphType == MPCF.ToInt(eGraphType.DELTAS))
                        {
                            if (sZbarFlag != "Z")
                            {
                                sZbarFlag = "D";
                            }
                            MPCR.SetNumberCell(spdData.Sheets[0].Cells[i, NOMINAL_COL]);
                            spdData.Sheets[0].Cells[i, PROCSIGMA_COL].Locked = true;
                            spdData.Sheets[0].Cells[i, PROCSIGMA_COL].BackColor = Color.White;
                            if (i == spdData.Sheets[0].RowCount - out_node.GetInt("UNIT_COUNT"))
                            {
                                spdData.Sheets[0].Cells[i, NOMINAL_COL].RowSpan = out_node.GetInt("UNIT_COUNT");
                            }
                        }
                        else
                        {
                            spdData.Sheets[0].Cells[i, PROCSIGMA_COL].Locked = true;
                            spdData.Sheets[0].Cells[i, PROCSIGMA_COL].BackColor = Color.White;
                            spdData.Sheets[0].Cells[i, NOMINAL_COL].Locked = true;
                            spdData.Sheets[0].Cells[i, NOMINAL_COL].BackColor = Color.White;
                        }
                        spdData.Sheets[0].Cells[i, CHART_COL].Value = sChartID;
                        spdData.Sheets[0].Cells[i, CHART_DESC_COL].Value = out_node.GetString("CHART_DESC");
                        spdData.Sheets[0].Cells[i, UNIT_COUNT_COL].Value = out_node.GetInt("UNIT_COUNT");
                        spdData.Sheets[0].Cells[i, SAMPLE_SIZE_COL].Value = out_node.GetInt("SAMPLE_SIZE");
                        spdData.Sheets[0].Cells[i, GRAPH_TYPE_COL].Value = out_node.GetString("GRAPH_TYPE");
                        spdData.Sheets[0].Cells[i, UNIT_USE_COL].Value = out_node.GetChar("UNIT_USE_FLAG");
                        spdData.Sheets[0].Cells[i, PRECISION_COL].Value = out_node.GetInt("PRECISION_LIMIT");
                        spdData.Sheets[0].Cells[i, SPEC_CHECK_COL].Value = out_node.GetChar("SPEC_CHECK_TYPE");
                        if (i == spdData.Sheets[0].RowCount - out_node.GetInt("UNIT_COUNT"))
                        {
                            spdData.Sheets[0].Cells[i, CHART_DESC_COL].RowSpan = out_node.GetInt("UNIT_COUNT");
                        }
                        
                        
                    }
                    
                }
                
                if (MPCR.Find_Spec_Version('1', sChartID, ref iVer, true) == true)
                {
                    View_Spec(iVer, sChartID, spdData.Sheets[0].RowCount - out_node.GetInt("UNIT_COUNT"));
                }
                spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - out_node.GetInt("UNIT_COUNT"), SPEC_COL].RowSpan = (int)spdData.Sheets[0].Cells[spdData.Sheets[0].RowCount - out_node.GetInt("UNIT_COUNT"), UNIT_COUNT_COL].Value;
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.View_Chart()\n" + ex.Message);
                return false;
            }
            
        }
        
        
        // View_Spec()
        //       - View Spec
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iVer As Integer : 버전
        //       - ByVal sChartID As String : 차트 �?
        //
        private bool View_Spec(int iVer, string sChartID, int iRow)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Spec_In");
                TRSNode out_node = new TRSNode("View_Spec_Out");
                int iPrecision;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));
                in_node.AddInt("VERSION", iVer);

                if (MPCR.CallService("SPC", "SPC_View_Spec", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                iPrecision = (int)spdData.Sheets[0].Cells[iRow, PRECISION_COL].Value;
                spdData.Sheets[0].Cells[iRow, SPEC_COL].Value = MPCF.GetSpecInfo(MPCF.Trim(out_node.GetString("USL")), MPCF.Trim(out_node.GetString("LSL")), MPCF.Trim(out_node.GetString("TARGET")));
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.View_Spec()\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetChartControl()
        //       - Set Chart Control
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SetChartControl()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Attach_Chart_Set_List_In");
                TRSNode out_node;
                ArrayList a_list = new ArrayList();
                int i; //
                int iSampleSize = 0;
                int iMaxSize;
                string sZbarFlag = "";

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("CHART_SET_ID", MPCF.Trim(cdvChartSetID.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
                in_node.AddString("NEXT_CHART_ID", "");
                
                iMaxSize = 0;
                
                for (i = 0; i <= AVERAGE_COL + 4; i++)
                {
                    spdData.Sheets[0].Columns[i].Visible = true;
                }
                
                do
                {
                    out_node = new TRSNode("View_Attach_Chart_Set_List_Out");
                    if (MPCR.CallService("SPC", "SPC_View_Attach_Chart_Set_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    a_list.Add(out_node);

                    in_node.SetString("NEXT_CHART_ID", out_node.GetString("NEXT_CHART_ID"));

                } while (in_node.GetString("NEXT_CHART_ID") != "");
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        View_Chart(out_node.GetList(0)[i].GetString("CHART_ID"), ref iSampleSize, ref sZbarFlag);
                        if (iMaxSize < iSampleSize)
                        {
                            iMaxSize = iSampleSize;
                        }
                    }
                }
                
                for (i = 0; i <= iMaxSize - 1; i++)
                {
                    spdData.Sheets[0].ColumnHeader.Cells[1, VALUE_1_COL + i].Value = i + 1;
                }
                if (iMaxSize == 1)
                {
                    spdData.Sheets[0].ColumnHeader.Cells[0, VALUE_1_COL].Value = "       " + MPCF.FindLanguage("Value", 0);
                }
                else
                {
                    spdData.Sheets[0].ColumnHeader.Cells[0, VALUE_1_COL].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iMaxSize.ToString() + ")";
                }
                
                for (i = VALUE_1_COL + iMaxSize; i <= VALUE_1_COL + modSPCConstants.VALUE_COUNT - 1; i++)
                {
                    spdData.Sheets[0].Columns[i].Visible = false;
                }
                
                if (sZbarFlag == "")
                {
                    spdData.Sheets[0].Columns[PROCSIGMA_COL].Visible = false;
                    spdData.Sheets[0].Columns[NOMINAL_COL].Visible = false;
                    spdData.Sheets[0].Columns[WEIGHT_COL].Visible = false;
                }
                else if (sZbarFlag == "D")
                {
                    spdData.Sheets[0].Columns[PROCSIGMA_COL].Visible = false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.SetChartControl()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ClearBackColor()
        //       - Clear Back Color of Spread
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void ClearBackColor()
        {
            
            try
            {
                int i;
                int j;
                int iGraphType;
                for (i = 0; i <= spdData.Sheets[0].RowCount - 1; i++)
                {
                    iGraphType = (int)Enum.Parse(typeof(eGraphType), MPCF.Trim(spdData.Sheets[0].Cells[i, GRAPH_TYPE_COL].Value));
                    
                    if (iGraphType == MPCF.ToInt(eGraphType.P) || iGraphType == MPCF.ToInt(eGraphType.U))
                    {
                        spdData.Sheets[0].Cells[i, AVERAGE_COL].BackColor = Color.White;
                    }
                    else if (iGraphType == MPCF.ToInt(eGraphType.PN) || 
                             iGraphType == MPCF.ToInt(eGraphType.C))
                    {
                        spdData.Sheets[0].Cells[i, VALUE_1_COL].BackColor = Color.Lime;
                    }
                    else if (iGraphType == MPCF.ToInt(eGraphType.ZBARS) || iGraphType == MPCF.ToInt(eGraphType.DELTAS))
                    {
                        spdData.Sheets[0].Cells[i, WEIGHT_COL].BackColor = Color.White;
                    }
                    else
                    {
                        for (j = VALUE_1_COL; j <= VALUE_1_COL + (int)spdData.Sheets[0].Cells[i, SAMPLE_SIZE_COL].Value - 1; j++)
                        {
                            spdData.Sheets[0].Cells[i, j].BackColor = Color.Lime;
                        }
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.BackColorClear()\n" + ex.Message);
            }
            
        }
        
        // Collect_EDC_Data_by_ChartSet()
        //       - Collect EDC Data
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String
        //
        private bool Collect_EDC_Data_by_ChartSet(char c_step)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("Collect_ChartSet_Data_In");
                TRSNode out_node = new TRSNode("Collect_ChartSet_Data_Out");
                TRSNode list;
                TRSNode value_item;
                TRSNode unit_item;
                TRSNode oos_array;
                int i;
                int j;
                int k, m;
                int iValueCount;
                int iChartCount;
                int iUnitSeq = 0;
                int i_row;
                string sNewChart = "";
                string sOldChart = "";

                MPCR.SetInMsg(in_node);
                in_node.UserID = MPCF.Trim(cdvUserID.Text);                
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddChar("SUB_STEP", c_step);

                in_node.AddChar("LOT_RES_FLAG", 'L');
                in_node.AddString("LOT_ID", MPCF.Trim(txtLot.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);
                in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
                in_node.AddInt("FLOW_SEQ_NUM", cdvFlow.Sequence);
                in_node.AddString("OPER", MPCF.Trim(cdvOper.Text));
                in_node.AddString("PROC_OPER", MPCF.Trim(cdvProcOper.Text));
                in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                in_node.AddString("PROC_RES_ID", MPCF.Trim(cdvProcResID.Text));
                in_node.AddChar("SELECT_MFO_FLAG", (chkSelectMFO.Checked ? 'Y' : ' '));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("TRAN_TIME", ((DateTime)uccTranDate.Value).ToString("yyyyMMdd") + ((DateTime)udtTranTime.Value).ToString("HHmmss"));
                }
                
                iChartCount = spdData.Sheets[0].RowCount;
                FarPoint.Win.Spread.SheetView with_1 = spdData.Sheets[0];
                list = in_node.AddNode("CHART_LIST");
                for (i = 0; i <= spdData.Sheets[0].RowCount - 1; i++)
                {
                    sNewChart = MPCF.Trim(with_1.GetValue(i, CHART_COL));
                    if (sOldChart != sNewChart)
                    {
                        sOldChart = sNewChart;
                        iUnitSeq = 1;
                        if (i != 0)
                        {
                            list = in_node.AddNode("CHART_LIST");
                        }
                        list.AddString("CHART_ID", MPCF.Trim(with_1.Cells[i, CHART_COL].Value));
                        list.AddInt("UNIT_COUNT", MPCF.ToInt(with_1.Cells[i, UNIT_COUNT_COL].Value));
                        list.AddInt("SAMPLE_SIZE", MPCF.ToInt(with_1.Cells[i, SAMPLE_SIZE_COL].Value));
                        list.AddString("GRAPH_TYPE", MPCF.Trim(with_1.Cells[i, GRAPH_TYPE_COL].Value));
                        list.AddChar("UNIT_USE_FLAG", MPCF.ToChar(with_1.Cells[i, UNIT_USE_COL].Value));
                        list.AddString("EDC_COMMENT", MPCF.Trim(txtComment.Text));
                    }
                    else
                    {
                        iUnitSeq++;
                    }
                    unit_item = list.AddNode("UNIT_LIST");
                    
                    iValueCount = 0;
                    for (j = VALUE_1_COL; j <= VALUE_1_COL + modSPCConstants.VALUE_COUNT - 1; j++)
                    {
                        if (MPCF.Trim(with_1.GetValue(i, j)) != "" && with_1.Cells[i, j].Locked == false)
                        {
                            iValueCount++;
                        }
                    }
                    if (with_1.Cells[i, NOMINAL_COL].BackColor.Equals(Color.White) == false)
                    {
                        unit_item.AddString("NOMINAL", MPCF.Trim(with_1.GetValue(i - (iUnitSeq - 1), NOMINAL_COL)));
                    }
                    if (with_1.Cells[i, PROCSIGMA_COL].BackColor.Equals(Color.White) == false)
                    {
                        unit_item.AddString("PROCESS_SIGMA", MPCF.Trim(with_1.GetValue(i - (iUnitSeq - 1), PROCSIGMA_COL)));
                    }
                    unit_item.AddString("UNIT_ID", MPCF.Trim(with_1.GetValue(i, UNIT_COL)));
                    unit_item.AddInt("VALUE_COUNT", iValueCount);
                    unit_item.AddInt("UNIT_SEQ", iUnitSeq);
                    
                    for (k = 0; k <= iValueCount - 1; k++)
                    {
                        value_item = unit_item.AddNode("VALUE_LIST");
                        value_item.AddString("VALUE", MPCF.Trim(with_1.GetValue(i, k + VALUE_1_COL)));
                    }
                }

                if (MessageCaster.CallService("SPC", "SPC_Collect_ChartSet_Data", in_node, ref out_node) == false)
                {
                    MPCF.ShowMsgBox(MPMH.StatusMessage);
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    MPCR.CheckContinueProc(out_node);
                    return false;
                }
                
                i = 0;
                i_row = 0;
                while (i < out_node.GetList(0).Count)
                {
                    TRSNode chart_item_out = out_node.GetList("CHART_LIST")[i];
                    for (j = 0; j < chart_item_out.GetList("UNIT_LIST").Count; j++)
                    {                        
                        with_1.Cells[i_row, WEIGHT_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("WEIGHT_VALUE"), MPCF.ToInt(with_1.Cells[i_row, PRECISION_COL].Value));
                        with_1.Cells[i_row, AVERAGE_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("AVERAGE"), MPCF.ToInt(with_1.Cells[i_row, PRECISION_COL].Value));
                        with_1.Cells[i_row, SIGMA_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("STDDEV"), MPCF.ToInt(with_1.Cells[i_row, PRECISION_COL].Value));
                        with_1.Cells[i_row, RANGE_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("RANGE"), MPCF.ToInt(with_1.Cells[i_row, PRECISION_COL].Value));
                        with_1.Cells[i_row, MAX_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("MAX_VALUE"), MPCF.ToInt(with_1.Cells[i_row, PRECISION_COL].Value));
                        with_1.Cells[i_row, MIN_COL].Value = MPCF.SetPrecision(chart_item_out.GetList(0)[j].GetString("MIN_VALUE"), MPCF.ToInt(with_1.Cells[i_row, PRECISION_COL].Value));
                        if (chart_item_out.GetList(0)[j].GetChar("R_CHECK_RESULT") == ' ' && chart_item_out.GetList(0)[j].GetChar("X_CHECK_RESULT") == ' ')
                        {
                            with_1.Cells[i_row, RESULT_COL].Value = "OK";
                        }
                        else
                        {
                            with_1.Cells[i_row, RESULT_COL].Value = "FAIL";
                        }
                        if (MPCF.Trim(with_1.Cells[i_row, UNIT_USE_COL].Value) == "Y")
                        {
                            if (chart_item_out.GetList(0)[j].GetChar("X_CHECK_RESULT") == 'A')
                            {
                                oos_array = chart_item_out.GetList("OOS_LIST")[j].GetArray("OOS_CHECK_RESULT");
                                if (MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.XBARR.ToString() ||
                                    MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.XBARS.ToString() ||
                                    MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.XRS.ToString())
                                {
                                    for (k = 0; k <= (int)with_1.Cells[i_row, SAMPLE_SIZE_COL].Value - 1; k++)
                                    {
                                        if (oos_array.GetChar(k.ToString()) == 'Y')
                                        {
                                            with_1.Cells[i_row, VALUE_1_COL + k].BackColor = Color.Red;
                                        }
                                    }
                                }
                                else if (MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.P.ToString() ||
                                         MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.U.ToString())
                                {
                                    if (oos_array.GetChar("0") == 'Y')
                                    {
                                        with_1.Cells[0, AVERAGE_COL].BackColor = Color.Red;
                                    }
                                }
                                else if (MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.ZBARS.ToString() || MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.DELTAS.ToString())
                                {
                                    with_1.Cells[0, WEIGHT_COL].BackColor = Color.Red;
                                }
                                else
                                {
                                    if (oos_array.GetChar("0") == 'Y')
                                    {
                                        with_1.Cells[0, VALUE_1_COL].BackColor = Color.Red;
                                    }
                                }
                            }
                            else if (chart_item_out.GetList(0)[j].GetChar("X_CHECK_RESULT") == 'B' && MPCF.Trim(with_1.Cells[i_row, SPEC_CHECK_COL].Value) == "V")
                            {
                                oos_array = chart_item_out.GetList("OOS_LIST")[j].GetArray("OOS_CHECK_RESULT");
                                if (MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.XBARR.ToString() || MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.XBARS.ToString() || MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.XRS.ToString())
                                {
                                    for (k = 0; k <= (int)with_1.Cells[i_row, SAMPLE_SIZE_COL].Value - 1; k++)
                                    {
                                        if (oos_array.GetChar(k.ToString()) == 'Y')
                                        {
                                            with_1.Cells[i_row, VALUE_1_COL + k].BackColor = Color.Yellow;
                                        }
                                    }
                                }
                            }
                            i_row++;
                        }
                        else
                        {
                            with_1.Cells[i_row, WEIGHT_COL].RowSpan = MPCF.ToInt(with_1.Cells[i_row, UNIT_COUNT_COL].Value);
                            with_1.Cells[i_row, AVERAGE_COL].RowSpan = MPCF.ToInt(with_1.Cells[i_row, UNIT_COUNT_COL].Value);
                            with_1.Cells[i_row, SIGMA_COL].RowSpan = MPCF.ToInt(with_1.Cells[i_row, UNIT_COUNT_COL].Value);
                            with_1.Cells[i_row, RANGE_COL].RowSpan = MPCF.ToInt(with_1.Cells[i_row, UNIT_COUNT_COL].Value);
                            with_1.Cells[i_row, MAX_COL].RowSpan = MPCF.ToInt(with_1.Cells[i_row, UNIT_COUNT_COL].Value);
                            with_1.Cells[i_row, MIN_COL].RowSpan = MPCF.ToInt(with_1.Cells[i_row, UNIT_COUNT_COL].Value);
                            with_1.Cells[i_row, RESULT_COL].RowSpan = MPCF.ToInt(with_1.Cells[i_row, UNIT_COUNT_COL].Value);

                            if (chart_item_out.GetList(0)[j].GetChar("X_CHECK_RESULT") == 'A')
                            {
                                if (MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.ZBARS.ToString() || MPCF.Trim(with_1.Cells[i_row, GRAPH_TYPE_COL].Value) == eGraphType.DELTAS.ToString())
                                {
                                    with_1.Cells[i_row, WEIGHT_COL].BackColor = Color.Red;
                                }
                                else
                                {
                                    for (m = 0; m <= MPCF.ToInt(with_1.Cells[i_row, UNIT_COUNT_COL].Value) - 1; m++)
                                    {
                                        oos_array = chart_item_out.GetList("OOS_LIST")[m].GetArray("OOS_CHECK_RESULT");
                                        for (k = 0; k <= MPCF.ToInt(with_1.Cells[i_row, SAMPLE_SIZE_COL].Value) - 1; k++)
                                        {
                                            if (oos_array.GetChar(k.ToString()) == 'Y')
                                            {
                                                with_1.Cells[i_row + m, VALUE_1_COL + k].BackColor = Color.Red;
                                            }
                                        }
                                    }
                                }
                            }
                            else if (chart_item_out.GetList(0)[0].GetChar("X_CHECK_RESULT") == 'B' && MPCF.Trim(with_1.Cells[i_row, SPEC_CHECK_COL].Value) == "V")
                            {
                                for (m = 0; m <= MPCF.ToInt(with_1.Cells[i_row, UNIT_COUNT_COL].Value) - 1; m++)
                                {
                                    oos_array = chart_item_out.GetList("OOS_LIST")[m].GetArray("OOS_CHECK_RESULT");
                                    for (k = 0; k <= MPCF.ToInt(with_1.Cells[i_row, SAMPLE_SIZE_COL].Value) - 1; k++)
                                    {
                                        if (oos_array.GetChar(k.ToString()) == 'Y')
                                        {
                                            with_1.Cells[i_row + m, VALUE_1_COL + k].BackColor = Color.Yellow;
                                        }
                                    }
                                }
                            }
                            i_row += MPCF.ToInt(with_1.Cells[i_row, UNIT_COUNT_COL].Value);
                        }
                    }
                    i++;
                }
                
                if (c_step == MPGC.MP_STEP_TRAN && out_node.StatusValue == MPGC.MP_TRBL_STATUS)
                {
                    Result_Management(out_node);
                }
                else if (c_step == MPGC.MP_STEP_TRAN && out_node.StatusValue == MPGC.MP_SUCCESS_STATUS)
                {
                    MPCR.ShowSuccessMsg(out_node);
                    btnOK.Enabled = false;
                    SetLockSpread(true);
                }
              
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.CollectEDCData()\n" + ex.Message);
                return false;
            }
            
        }
        
        // Result_Management()
        //       - Manage result of data collection
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal Collect_EDC_Data_Out As SPC_Collect_EDC_Data_Out_Tag
        //
        private void Result_Management(TRSNode  out_node)
        {
            
            try
            {
                if (out_node.StatusValue == MPGC.MP_TRBL_STATUS)
                {
                    frmSPCSubCollectData f = new frmSPCSubCollectData();
                    frmSPCTranOOCHistory f1 = new frmSPCTranOOCHistory();
                    f.spdResult.Sheets[0].Columns[1].Visible = true;

                    View_Result(f.spdResult, out_node, "1");
                    f.ShowDialog(this);
                    
                    //Pending
                    if (f.DialogResult == System.Windows.Forms.DialogResult.Ignore)
                    {
                        //Data Commit
                        //OOC History Insert
                        if (Collect_EDC_Data_by_ChartSet(modSPCConstants.MP_STEP_PEND) == false)
                        {
                            return;
                        }
                        btnOK.Enabled = false;
                        SetLockSpread(true);
                        MPCR.ShowSuccessMsg(out_node);
                        
                        //Continue
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        //f.Dispose()
                        if (Collect_EDC_Data_by_ChartSet(modSPCConstants.MP_STEP_CONT) == false)
                        {
                            return;
                        }
                        f1.spdResult.Sheets[0].Columns[1].Visible = true;
                        View_Result(f1.spdResult, out_node, "2");
                        f1.pnlTop.Visible = false;
                        f1.pnlResult.Height = 214;
                        f1.ShowDialog(this);
                        btnOK.Enabled = false;
                        SetLockSpread(true);
                        
                        //Data Change
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        f.Dispose();
                        
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        f.Dispose();
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.Result_Management()\n" + ex.Message);
                
            }
            
        }
        
        // View_Result()
        //       - View Result of Data Collection
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef spdResult As FpSpread - 결과 ?�시 ?�프?�드
        //       - ByVal Result_Out As SPC_Collect_EDC_Data_Out_Tag : Data Collection Out ?�그
        //       - ByVal c_step As String
        //
        public void View_Result(FarPoint.Win.Spread.FpSpread spdResult,TRSNode out_node, string c_step)
        {
            
            try
            {
                int i;
                int j, i_row;
                MPCF.ClearList(spdResult, true);
                j = 0;
                i_row = 0;
                while (j < out_node.GetList(0).Count)
                {
                    TRSNode chart_item = out_node.GetList("CHART_LIST")[j];
                    for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdData.Sheets[0].Cells[i, CHART_COL].Value) == chart_item.GetString("CHART_ID"))
                        {
                            i_row = i;
                            break;
                        }
                    }
                    FarPoint.Win.Spread.SheetView with_1 = spdResult.Sheets[0];
                    if (MPCF.Trim(spdData.Sheets[0].Cells[i_row, UNIT_USE_COL].Value) != "Y")
                    {
                        if (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT") != ' ' && chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT") != ' ')
                        {
                            with_1.RowCount += 2;
                            with_1.Cells[with_1.RowCount - 2, 0].Value = 1;
                            with_1.Cells[with_1.RowCount - 1, 0].Value = 1;
                            with_1.Cells[with_1.RowCount - 2, 0].RowSpan = 2;
                            with_1.Cells[with_1.RowCount - 2, 1].Value = spdData.Sheets[0].Cells[i_row, CHART_COL].Value;
                            with_1.Cells[with_1.RowCount - 1, 1].Value = spdData.Sheets[0].Cells[i_row, CHART_COL].Value;
                            with_1.Cells[with_1.RowCount - 2, 2].Value = spdData.Sheets[0].Cells[i_row, UNIT_COL].Value;
                            with_1.Cells[with_1.RowCount - 2, 2].RowSpan = 2;
                            with_1.Cells[with_1.RowCount - 2, 3].Value = "X";
                            with_1.Cells[with_1.RowCount - 1, 3].Value = "R";
                            with_1.Cells[with_1.RowCount - 2, 4].Value = chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT");
                            with_1.Cells[with_1.RowCount - 1, 4].Value = chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT");
                            with_1.Cells[with_1.RowCount - 2, 5].Value = MPCF.SetRuleDescription(chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT"), out_node, 'X');
                            with_1.Cells[with_1.RowCount - 1, 5].Value = MPCF.SetRuleDescription(chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT"), out_node, 'R');
                            if (c_step == "2")
                            {
                                with_1.Cells[0, 6].RowSpan = 2;
                                with_1.Cells[with_1.RowCount - 2, 7].Value = chart_item.GetInt("HIST_SEQ");
                                with_1.Cells[with_1.RowCount - 1, 7].Value = chart_item.GetInt("HIST_SEQ");
                                with_1.Cells[with_1.RowCount - 2, 8].Value = chart_item.GetString("TRAN_TIME");
                                with_1.Cells[with_1.RowCount - 1, 8].Value = chart_item.GetString("TRAN_TIME");
                            }
                        }
                        else if (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ' && chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT") == ' ')
                        {
                        }
                        else
                        {
                            with_1.RowCount++;
                            with_1.Cells[with_1.RowCount - 1, 0].Value = 1;
                            with_1.Cells[with_1.RowCount - 1, 1].Value = spdData.Sheets[0].Cells[i_row, CHART_COL].Value;
                            with_1.Cells[with_1.RowCount - 1, 2].Value = spdData.Sheets[0].Cells[i_row, UNIT_COL].Value;
                            with_1.Cells[with_1.RowCount - 1, 3].Value = (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ') ? "X" : "R";
                            with_1.Cells[with_1.RowCount - 1, 4].Value = (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ') ? (chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT")) : (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT"));
                            with_1.Cells[with_1.RowCount - 1, 5].Value = (chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ') ? (MPCF.SetRuleDescription(chart_item.GetList(0)[0].GetChar("X_CHECK_RESULT"), out_node, 'X')) : (MPCF.SetRuleDescription(chart_item.GetList(0)[0].GetChar("R_CHECK_RESULT"), out_node, 'R'));
                            if (c_step == "2")
                            {
                                with_1.Cells[with_1.RowCount - 1, 7].Value = chart_item.GetInt("HIST_SEQ");
                                with_1.Cells[with_1.RowCount - 1, 8].Value = chart_item.GetString("TRAN_TIME");
                            }
                        }
                        j++;
                    }
                    else
                    {
                        for (i = 0; i <= chart_item.GetList("UNIT_LIST").Count - 1; i++)
                        {
                            if (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT") != ' ' && chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT") != ' ')
                            {
                                with_1.RowCount += 2;
                                with_1.Cells[with_1.RowCount - 2, 0].Value = i + 1;
                                with_1.Cells[with_1.RowCount - 1, 0].Value = i + 1;
                                with_1.Cells[with_1.RowCount - 2, 0].RowSpan = 2;
                                with_1.Cells[with_1.RowCount - 2, 1].Value = spdData.Sheets[0].Cells[i + i_row, CHART_COL].Value;
                                with_1.Cells[with_1.RowCount - 1, 1].Value = spdData.Sheets[0].Cells[i + i_row, CHART_COL].Value;
                                with_1.Cells[with_1.RowCount - 2, 2].Value = spdData.Sheets[0].Cells[i + i_row, UNIT_COL].Value;
                                with_1.Cells[with_1.RowCount - 2, 2].RowSpan = 2;
                                with_1.Cells[with_1.RowCount - 2, 3].Value = "X";
                                with_1.Cells[with_1.RowCount - 1, 3].Value = "R";
                                with_1.Cells[with_1.RowCount - 2, 4].Value = chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT");
                                with_1.Cells[with_1.RowCount - 1, 4].Value = chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT");
                                with_1.Cells[with_1.RowCount - 2, 5].Value = MPCF.SetRuleDescription(chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT"), out_node, 'X');
                                with_1.Cells[with_1.RowCount - 1, 5].Value = MPCF.SetRuleDescription(chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT"), out_node, 'R');
                                if (c_step == "2")
                                {
                                    with_1.Cells[with_1.RowCount - 2, 6].RowSpan = 2;
                                    with_1.Cells[with_1.RowCount - 2, 7].Value = chart_item.GetInt("HIST_SEQ");
                                    with_1.Cells[with_1.RowCount - 1, 7].Value = chart_item.GetInt("HIST_SEQ");
                                    with_1.Cells[with_1.RowCount - 2, 8].Value = chart_item.GetString("TRAN_TIME");
                                    with_1.Cells[with_1.RowCount - 1, 8].Value = chart_item.GetString("TRAN_TIME");
                                }
                            }
                            else if (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ' && chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT") == ' ')
                            {
                            }
                            else
                            {
                                with_1.RowCount++;
                                with_1.Cells[with_1.RowCount - 1, 0].Value = i + 1;
                                with_1.Cells[with_1.RowCount - 1, 1].Value = spdData.Sheets[0].Cells[i + i_row, CHART_COL].Value;
                                with_1.Cells[with_1.RowCount - 1, 2].Value = spdData.Sheets[0].Cells[i + i_row, UNIT_COL].Value;
                                with_1.Cells[with_1.RowCount - 1, 3].Value = (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ') ? "X" : "R";
                                with_1.Cells[with_1.RowCount - 1, 4].Value = (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ') ? (chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT")) : (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT"));
                                with_1.Cells[with_1.RowCount - 1, 5].Value = (chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ') ? (MPCF.SetRuleDescription(chart_item.GetList(0)[i].GetChar("X_CHECK_RESULT"), out_node, 'X')) : (MPCF.SetRuleDescription(chart_item.GetList(0)[i].GetChar("R_CHECK_RESULT"), out_node, 'R'));
                                if (c_step == "2")
                                {
                                    with_1.Cells[with_1.RowCount - 1, 7].Value = chart_item.GetInt("HIST_SEQ");
                                    with_1.Cells[with_1.RowCount - 1, 8].Value = chart_item.GetString("TRAN_TIME");
                                }
                            }
                        }
                        j++;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.View_Result()\n" + ex.Message);
            }
            
        }
        
        // SetLockSpread()
        //       - Set spread's lock property
        // Return Value
        //       -
        // Arguments
        //       - ByVal bLockFlag As Boolean : lock flag
        //
        public void SetLockSpread(bool bLockFlag)
        {
            
            try
            {
                int i;
                int j;
                
                for (j = 0; j <= spdData.Sheets[0].RowCount - 1; j++)
                {
                    for (i = UNIT_COL; i <= VALUE_1_COL + modSPCConstants.VALUE_COUNT - 1; i++)
                    {
                        if (i == UNIT_COL)
                        {
                            spdData.Sheets[0].Cells[j, i].Locked = bLockFlag;
                        }
                        else
                        {
                            if (spdData.Sheets[0].Cells[j, i].BackColor.Equals(Color.White) == false)
                            {
                                spdData.Sheets[0].Cells[j, i].Locked = bLockFlag;
                            }
                        }
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.SetLockSpread()\n" + ex.Message);
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtLot;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void cdvProcOper_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvProcOper.Init();
                MPCF.InitListView(cdvProcOper.GetListView);
                cdvProcOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvProcOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvProcOper.SelectedSubItemIndex = 0;
                if (WIPLIST.ViewOperationList(cdvProcOper.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "") == false)
                {
                    return;
                }
                cdvProcOper.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvProcOper_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvResID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvResID.Init();
                MPCF.InitListView(cdvResID.GetListView);
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;
                if (RASLIST.ViewResourceList(cdvResID.GetListView, MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, MPCF.Trim(cdvFlow.Text), MPCF.Trim(cdvOper.Text), false) == false)
                {
                    return;
                }
                cdvResID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvResID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvProcResID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvProcResID.Init();
                MPCF.InitListView(cdvProcResID.GetListView);
                cdvProcResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvProcResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvProcResID.SelectedSubItemIndex = 0;
                if (RASLIST.ViewResourceList(cdvProcResID.GetListView, MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, MPCF.Trim(cdvFlow.Text), MPCF.Trim(cdvOper.Text), false) == false)
                {
                    return;
                }
                cdvProcResID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvProcResID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                txtTranTime.Visible = ! chkTranDateTime.Checked;
                uccTranDate.Enabled = chkTranDateTime.Checked;
                udtTranTime.Enabled = chkTranDateTime.Checked;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.chkTranDateTime_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCTranCollectLotDataType3_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLot.Text = MPGV.gsCurrentLot_ID;
                        if (View_Lot() == false)
                        {
                            return;
                        }
                    }

                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.frmSPCTranCollectLotDataType3_Activated()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCTranCollectLotDataType3_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                
                MPCF.SetTextboxStyle(this.Controls);
                uccTranDate.Value = DateTime.Now;
                udtTranTime.Value = DateTime.Now;
                pnlTranTime.Visible = MPGO.UseBackDate();

                cdvMaterial.BackColor = SystemColors.Control;

                cdvFlow.VisibleFlowButton = false;
                cdvFlow.FlowReadOnly = true;
                cdvFlow.VisibleSequenceButton = false;
                cdvFlow.SequenceReadOnly = true;
                cdvFlow.BackColor = SystemColors.Control;
                
                cdvOper.VisibleButton = false;
                cdvOper.ReadOnly = true;
                cdvOper.BackColor = SystemColors.Control;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.frmSPCTranCollectLotDataType3_Load()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154));
                    cdvMaterial.MaterialFocus();
                    return;
                }
                cdvChartSetID.Init();
                MPCF.InitListView(cdvChartSetID.GetListView);
                cdvChartSetID.Columns.Add("ChartSetID", 50, HorizontalAlignment.Left);
                cdvChartSetID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartSetID.SelectedSubItemIndex = 0;

                if (SPCLIST.ViewChartSetList(cdvChartSetID.GetListView, '2', MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, MPCF.Trim(cdvOper.Text), MPCF.Trim(cdvResID.Text), 'L', cdvFlow.Text, -1, -1, "") == false)
                {
                    return;
                }
                
                cdvChartSetID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvChartSetID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                cdvUserID.Text = "";
                this.SuspendLayout();
                MPCF.ClearList(spdData, true);
                SetChartControl();
                SetLockSpread(false);
                this.ResumeLayout(false);
                MPCR.ChangeControlEnabled(this, btnOK, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvChartSetID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void txtLot_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                char sChartFlag = ' ';
                string sChartSetID = string.Empty;
                char sOvrFlag= ' ';
                if (e.KeyChar == (char)13)
                {
                    if (txtLot.Text != "")
                    {
                        MPCF.FieldClear(this.pnlCenter, txtLot, null, null, null, null, false);
                        if (View_Lot() == false)
                        {
                            return;
                        }
                        if (MPCR.ViewMFOChart('2', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOper.Text, ref sChartFlag, ref sChartSetID, ref sOvrFlag, true) == false)
                        {
                            return;
                        }
                        if (sChartFlag == 'S' && sChartSetID != "")
                        {
                            if (sOvrFlag == 'Y')
                            {
                                cdvChartSetID.BackColor = System.Drawing.Color.White;
                                cdvChartSetID.ReadOnly = false;
                                cdvChartSetID.VisibleButton = true;
                                cdvChartSetID.Text = sChartSetID;
                            }
                            else
                            {
                                cdvChartSetID.BackColor = SystemColors.Control;
                                cdvChartSetID.ReadOnly = true;
                                cdvChartSetID.VisibleButton = false;
                                cdvChartSetID.Text = sChartSetID;
                            }
                            cdvChartSetID_SelectedItemChanged(sender, null);
                        }
                        else
                        {
                            cdvChartSetID.BackColor = System.Drawing.Color.White;
                            cdvChartSetID.ReadOnly = false;
                            cdvChartSetID.VisibleButton = true;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.txtLot_KeyPress()\n" + ex.Message);
            }
            
        }
        
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                
                if (CheckCondition() == false)
                {
                    return;
                }
                ClearBackColor();
                if (Collect_EDC_Data_by_ChartSet(MPGC.MP_STEP_TRAN) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.btnOK_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtLot_TextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlCenter, txtLot, null, null, null, null, false);
                MPCF.ClearList(spdData, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.txtLot_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnGraph_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (pnlChartSet.Controls.Count == 0)
                {
                    return;
                }
                
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCTranControlChart");
                    if (form == null)
                    {
                        form = new frmSPCTranControlChart();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
                    }
                    else
                    {
                        form.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }

                ((frmSPCTranControlChart) form).uccStart.Value = DateTime.Now;
                ((frmSPCTranControlChart) form).udtStart.Value = "000000";
                ((frmSPCTranControlChart) form).uccEnd.Value = DateTime.Now;
                ((frmSPCTranControlChart) form).udtEnd.Value = "235959";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.btnGraph_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnRawData_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (pnlChartSet.Controls.Count == 0)
                {
                    return;
                }
                
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCViewEDCData");
                    if (form == null)
                    {
                        form = new frmSPCViewEDCData();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
                    }
                    else
                    {
                        form.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }

                ((frmSPCViewEDCData) form).uccStart.Value = DateTime.Now;
                ((frmSPCViewEDCData) form).udtStart.Value = "000000";
                ((frmSPCViewEDCData) form).uccEnd.Value = DateTime.Now;
                ((frmSPCViewEDCData) form).udtEnd.Value = "235959";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.btnRawData_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Close();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnHistogram_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCTranCapability");
                    if (form == null)
                    {
                        form = new frmSPCTranCapability();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
                    }
                    else
                    {
                        form.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }

                ((frmSPCTranCapability) form).uccStart.Value = DateTime.Now;
                ((frmSPCTranCapability) form).udtStart.Value = "000000";
                ((frmSPCTranCapability) form).uccEnd.Value = DateTime.Now;
                ((frmSPCTranCapability) form).udtEnd.Value = "235959";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.btnHistogram_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvUserID.Text = "";
                MPCF.ClearList(spdData, true);
                SetLockSpread(false);
                MPCR.ChangeControlEnabled(this, btnOK, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvChartSetID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvUserID.Text = "";
                this.SuspendLayout();
                MPCF.ClearList(spdData, true);
                SetChartControl();
                SetLockSpread(false);
                this.ResumeLayout(false);
                MPCR.ChangeControlEnabled(this, btnOK, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvUserID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvUserID.Init();
                MPCF.InitListView(cdvUserID.GetListView);
                cdvUserID.Columns.Add("UserID", 50, HorizontalAlignment.Left);
                cdvUserID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvUserID.SelectedSubItemIndex = 0;
                SECLIST.ViewSECUserList(cdvUserID.GetListView, '1', -1, null, "", "");
                cdvUserID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvUserID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void spdData_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
            try
            {
                int i;
                int iColumn;
                int iRow;
                
                iColumn = spdData.Sheets[0].ActiveColumnIndex;
                iRow = spdData.Sheets[0].ActiveRowIndex;
                
                if (e.KeyCode == Keys.Delete)
                {
                    for (i = 0; i <= spdData.Sheets[0].GetSelections().Length - 1; i++)
                    {
                        FarPoint.Win.Spread.Model.CellRange selRange = spdData.Sheets[0].GetSelection(i);
                        spdData.Sheets[0].ClearRange(selRange.Row, selRange.Column, selRange.RowCount, selRange.ColumnCount, true);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.spdData_KeyDown()\n" + ex.Message);
            }
            
        }
        
        private void spdData_EditModeOff(object sender, System.EventArgs e)
        {
            
            try
            {
                int iColumn;
                int iRow;
                
                iColumn = spdData.Sheets[0].ActiveColumnIndex;
                iRow = spdData.Sheets[0].ActiveRowIndex;
                
                if ((spdData.Sheets[0].Cells[iRow, iColumn + 1].Locked == false && spdData.Sheets[0].Columns[iColumn + 1].Visible == true) ||(iColumn + 1 == NOMINAL_COL || iColumn + 1 == PROCSIGMA_COL))
                {
                    if (iColumn + 1 == NOMINAL_COL && spdData.Sheets[0].Cells[iRow, iColumn + 1].Locked == true)
                    {
                        spdData.Sheets[0].SetActiveCell(iRow, iColumn + 3);
                    }
                    else if (iColumn + 1 == PROCSIGMA_COL && spdData.Sheets[0].Cells[iRow, iColumn + 1].Locked == true)
                    {
                        spdData.Sheets[0].SetActiveCell(iRow, iColumn + 2);
                    }
                    else
                    {
                        spdData.Sheets[0].SetActiveCell(iRow, iColumn + 1);
                    }
                }
                else
                {
                    if (iRow + 1 == spdData.Sheets[0].RowCount)
                    {
                        return;
                    }
                    spdData.Sheets[0].SetActiveCell(iRow + 1, UNIT_COL);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.spdData_EditModeOff()\n" + ex.Message);
            }
            
        }
        
        private void btnReset_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                //cdvUserID.Text = ""
                //Me.SuspendLayout()
                //spdData.Sheets[0].ClearRange(0, RESULT_COL, spdData.Sheets[0].RowCount, 110, True)
                //SetLockSpread(False)
                //Me.ResumeLayout(False)
                //btnOK.Enabled = True
                cdvUserID.Text = "";
                this.SuspendLayout();
                MPCF.ClearList(spdData, true);
                SetChartControl();
                SetLockSpread(false);
                this.ResumeLayout(false);
                MPCR.ChangeControlEnabled(this, btnOK, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.btnReset_Click()\n" + ex.Message);
            }
            
        }
        
        private void chkSelectMFO_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (chkSelectMFO.Checked == true)
                {
                    cdvFlow.VisibleFlowButton = true;
                    cdvFlow.FlowReadOnly = false;
                    cdvFlow.VisibleSequenceButton = true;
                    cdvFlow.SequenceReadOnly = false;
                    cdvFlow.BackColor = Color.White;
                    cdvOper.VisibleButton = true;
                    cdvOper.ReadOnly = false;
                    cdvOper.BackColor = Color.White;
                }
                else
                {
                    cdvFlow.Text = "";
                    cdvOper.Text = "";
                    cdvFlow.VisibleFlowButton = false;
                    cdvFlow.FlowReadOnly = true;
                    cdvFlow.VisibleSequenceButton = false;
                    cdvFlow.SequenceReadOnly = true;
                    cdvFlow.BackColor = SystemColors.Control;
                    cdvOper.VisibleButton = false;
                    cdvOper.ReadOnly = true;
                    cdvOper.BackColor = SystemColors.Control;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.chkSelectMFO_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvOper_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
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
                cdvOper.Init();
                MPCF.InitListView(cdvOper.GetListView);
                cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvOper.SelectedSubItemIndex = 0;
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "") == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvOper_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        
        private void cdvOper_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                char sChartFlag = ' ';
                string sChartSetID = string.Empty;
                char sOvrFlag= ' ';

                MPCF.ClearList(spdData, true);
                cdvResID.Text = "";
                cdvChartSetID.Text = "";
                cdvChartSetID.Init();
                if (MPCF.Trim(cdvOper.Text) != "")
                {
                    if (MPCR.ViewMFOChart('2', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOper.Text, ref sChartFlag, ref sChartSetID, ref sOvrFlag, true) == false)
                    {
                        return;
                    }
                    if (sChartFlag == 'S' && sChartSetID != "")
                    {
                        if (sOvrFlag == 'Y')
                        {
                            cdvChartSetID.BackColor = System.Drawing.Color.White;
                            cdvChartSetID.ReadOnly = false;
                            cdvChartSetID.VisibleButton = true;
                            cdvChartSetID.Text = sChartSetID;
                        }
                        else
                        {
                            cdvChartSetID.BackColor = SystemColors.Control;
                            cdvChartSetID.ReadOnly = true;
                            cdvChartSetID.VisibleButton = false;
                            cdvChartSetID.Text = sChartSetID;
                        }
                        cdvChartSetID_SelectedItemChanged(sender, null);
                    }
                    else
                    {
                        cdvChartSetID.BackColor = System.Drawing.Color.White;
                        cdvChartSetID.ReadOnly = false;
                        cdvChartSetID.VisibleButton = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvOper_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
                
        private void cdvOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                cdvResID.Text = "";
                cdvChartSetID.Text = "";
                cdvChartSetID.Init();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvOper_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        #endregion

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            try
            {
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMaterial.MaterialFocus();
                    return;
                }
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvFlow_FlowButtonPress()\n" + ex.Message);
            }
        }

        private void cdvFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                MPCF.ClearList(spdData, true);
                cdvOper.Text = "";
                cdvOper.Init();
                cdvResID.Text = "";
                cdvChartSetID.Text = "";
                cdvChartSetID.Init();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvFlow_FlowSelectedItemChanged()\n" + ex.Message);
            }
        }

        private void cdvFlow_FlowTextChanged(object sender, EventArgs e)
        {
            try
            {
                MPCF.ClearList(spdData, true);
                cdvOper.Text = "";
                cdvOper.Init();
                cdvResID.Text = "";
                cdvChartSetID.Text = "";
                cdvChartSetID.Init();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvFlow_TextBoxTextChanged()\n" + ex.Message);
            }
        }

        private void cdvFlow_SeqButtonPress(object sender, EventArgs e)
        {
            try
            {
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMaterial.MaterialFocus();
                    return;
                }
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotDataType3.cdvFlow_FlowButtonPress()\n" + ex.Message);
            }
        }

       
        
    }
    
    
    //#End If
    
}
