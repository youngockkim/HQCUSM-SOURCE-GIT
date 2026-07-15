
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
//   File Name   : frmSPCTranControlChart.vb
//   Description : View Control Chart
//
//   SPC Version : 1.0.0
//
//   Function List
//       - CheckCondition : Check the conditions before transaction
//       - View_Chart : View Chart Information
//       - View_Spec : View Spec Information
//       - ClearChartInfo : Clear Chart Information Control
//       - InitChart : Initialize Chart Options
//       - SetChartOptions : Set Chart Options
//       - SetChartTitle : Set Chart Titles
//       - View_ControlChart : View Control Chart
//       - Set_Data : Set data by graph type
//       - ChartIDSelected : Action after Chart ID Selected
//
//   Detail Description
//       -
//
//   History
//       - 2005-05-09 : Created by LaverWon
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCTranControlChart : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranControlChart()
        {
            
            
            InitializeComponent();
            
            
            this.spdChartInfo.Tag = "Change Cell";
            
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
        



        internal System.Windows.Forms.Panel pnlBottom;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewChartOptions;
        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.Button btnView;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlFill;
        internal System.Windows.Forms.Panel pnlFillTop;
        internal System.Windows.Forms.GroupBox grpTop;
        internal System.Windows.Forms.Label lblGraphType;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboGraphType;
        internal System.Windows.Forms.Label lblPeriod;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartID;
        internal System.Windows.Forms.Label lblChartID;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtStart;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccStart;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtEnd;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccEnd;
        internal System.Windows.Forms.Panel pnlFillBottom;
        internal System.Windows.Forms.GroupBox grpEDCInfo;
        internal FarPoint.Win.Spread.FpSpread spdDataInfo;
        internal FarPoint.Win.Spread.SheetView spdDataInfo_Sheet1;
        internal System.Windows.Forms.Button btnHistogram;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button btnViewRawData;
        internal System.Windows.Forms.Button btnCopyImage;
        internal System.Windows.Forms.Button btnSaveImage;
        internal System.Windows.Forms.Button btnPrint;
        private Panel pnlFillChart;
        internal Panel pnlFillMiddle;
        internal Panel pnlFillRight;
        internal GroupBox grpChartOptions;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkBasedOnTime;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewRuleCheck;
        internal Button btnRedraw;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewRChart;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewCZone;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewBZone;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewAZone;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtMaxLotCount;
        internal Label lblMaxLotCount;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewSpecLimit;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewDate;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewLotID;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAutoCalControlLimit;
        internal GroupBox grpChartInfo;
        internal FarPoint.Win.Spread.FpSpread spdChartInfo;
        internal FarPoint.Win.Spread.SheetView spdChartInfo_Sheet1;
        internal Panel pnlFillFill;
        internal Panel pnlChart;
        internal SPCControlChart.SPCControlChart Chart;
        private Splitter splChart;
        internal System.Windows.Forms.Button btnFiltering;
        
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranControlChart));
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1010 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1011 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1012 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1013 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1014 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1015 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnCopyImage = new System.Windows.Forms.Button();
            this.btnViewRawData = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkViewChartOptions = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.pnlFillBottom = new System.Windows.Forms.Panel();
            this.grpEDCInfo = new System.Windows.Forms.GroupBox();
            this.spdDataInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdDataInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splChart = new System.Windows.Forms.Splitter();
            this.pnlFillChart = new System.Windows.Forms.Panel();
            this.pnlFillFill = new System.Windows.Forms.Panel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.Chart = new SPCControlChart.SPCControlChart();
            this.pnlFillMiddle = new System.Windows.Forms.Panel();
            this.pnlFillRight = new System.Windows.Forms.Panel();
            this.grpChartOptions = new System.Windows.Forms.GroupBox();
            this.chkBasedOnTime = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewRuleCheck = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.chkViewRChart = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewCZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewBZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewAZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtMaxLotCount = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblMaxLotCount = new System.Windows.Forms.Label();
            this.chkViewSpecLimit = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewLotID = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkAutoCalControlLimit = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.grpChartInfo = new System.Windows.Forms.GroupBox();
            this.spdChartInfo = new FarPoint.Win.Spread.FpSpread();
            this.spdChartInfo_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlFillTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.btnFiltering = new System.Windows.Forms.Button();
            this.lblGraphType = new System.Windows.Forms.Label();
            this.cboGraphType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.cdvChartID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartID = new System.Windows.Forms.Label();
            this.udtStart = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccStart = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.udtEnd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccEnd = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewChartOptions)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.pnlFillBottom.SuspendLayout();
            this.grpEDCInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdDataInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDataInfo_Sheet1)).BeginInit();
            this.pnlFillChart.SuspendLayout();
            this.pnlFillFill.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlFillRight.SuspendLayout();
            this.grpChartOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBasedOnTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewRuleCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewRChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewCZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewBZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewAZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxLotCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewSpecLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewLotID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoCalControlLimit)).BeginInit();
            this.grpChartInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo_Sheet1)).BeginInit();
            this.pnlFillTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccEnd)).BeginInit();
            this.SuspendLayout();
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("±¼¸²", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("±¼¸²", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("±¼¸²", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("±¼¸²", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer2.Name = "rowHeaderRenderer2";
            rowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer2.TextRotationAngle = 0D;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnSaveImage);
            this.pnlBottom.Controls.Add(this.btnCopyImage);
            this.pnlBottom.Controls.Add(this.btnViewRawData);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnHistogram);
            this.pnlBottom.Controls.Add(this.btnReset);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Controls.Add(this.chkViewChartOptions);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 596);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(792, 40);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(92, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(24, 24);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveImage.Image")));
            this.btnSaveImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveImage.Location = new System.Drawing.Point(64, 8);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(24, 24);
            this.btnSaveImage.TabIndex = 7;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnCopyImage
            // 
            this.btnCopyImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCopyImage.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyImage.Image")));
            this.btnCopyImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCopyImage.Location = new System.Drawing.Point(36, 8);
            this.btnCopyImage.Name = "btnCopyImage";
            this.btnCopyImage.Size = new System.Drawing.Size(24, 24);
            this.btnCopyImage.TabIndex = 6;
            this.btnCopyImage.Click += new System.EventHandler(this.btnCopyImage_Click);
            // 
            // btnViewRawData
            // 
            this.btnViewRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewRawData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnViewRawData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnViewRawData.Location = new System.Drawing.Point(608, 7);
            this.btnViewRawData.Name = "btnViewRawData";
            this.btnViewRawData.Size = new System.Drawing.Size(88, 26);
            this.btnViewRawData.TabIndex = 3;
            this.btnViewRawData.Text = "Raw Data";
            this.btnViewRawData.Click += new System.EventHandler(this.btnViewRawData_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHistogram
            // 
            this.btnHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistogram.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHistogram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHistogram.Location = new System.Drawing.Point(516, 7);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(88, 26);
            this.btnHistogram.TabIndex = 2;
            this.btnHistogram.Text = "Histogram";
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Enabled = false;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReset.Location = new System.Drawing.Point(424, 7);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 26);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(332, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(700, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkViewChartOptions
            // 
            this.chkViewChartOptions.AutoSize = true;
            this.chkViewChartOptions.Checked = true;
            this.chkViewChartOptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewChartOptions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewChartOptions.Location = new System.Drawing.Point(124, 13);
            this.chkViewChartOptions.Name = "chkViewChartOptions";
            this.chkViewChartOptions.Size = new System.Drawing.Size(132, 17);
            this.chkViewChartOptions.TabIndex = 9;
            this.chkViewChartOptions.Text = "View Chart Options";
            this.chkViewChartOptions.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewChartOptions.CheckedChanged += new System.EventHandler(this.chkViewChartOptions_CheckedChanged);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlFillBottom);
            this.pnlFill.Controls.Add(this.splChart);
            this.pnlFill.Controls.Add(this.pnlFillChart);
            this.pnlFill.Controls.Add(this.pnlFillTop);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(792, 596);
            this.pnlFill.TabIndex = 0;
            // 
            // pnlFillBottom
            // 
            this.pnlFillBottom.Controls.Add(this.grpEDCInfo);
            this.pnlFillBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFillBottom.Location = new System.Drawing.Point(0, 475);
            this.pnlFillBottom.Name = "pnlFillBottom";
            this.pnlFillBottom.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlFillBottom.Size = new System.Drawing.Size(792, 121);
            this.pnlFillBottom.TabIndex = 1;
            // 
            // grpEDCInfo
            // 
            this.grpEDCInfo.Controls.Add(this.spdDataInfo);
            this.grpEDCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEDCInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpEDCInfo.Location = new System.Drawing.Point(3, 0);
            this.grpEDCInfo.Name = "grpEDCInfo";
            this.grpEDCInfo.Size = new System.Drawing.Size(786, 121);
            this.grpEDCInfo.TabIndex = 0;
            this.grpEDCInfo.TabStop = false;
            this.grpEDCInfo.Text = "Data Collection Information";
            // 
            // spdDataInfo
            // 
            this.spdDataInfo.AccessibleDescription = "spdDataInfo, Sheet1";
            this.spdDataInfo.BackColor = System.Drawing.SystemColors.Control;
            this.spdDataInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdDataInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdDataInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDataInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDataInfo.HorizontalScrollBar.Name = "";
            this.spdDataInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdDataInfo.HorizontalScrollBar.TabIndex = 6;
            this.spdDataInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdDataInfo.Location = new System.Drawing.Point(3, 16);
            this.spdDataInfo.Name = "spdDataInfo";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer2;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer2;
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
            this.spdDataInfo.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdDataInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdDataInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdDataInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdDataInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdDataInfo_Sheet1});
            this.spdDataInfo.Size = new System.Drawing.Size(780, 102);
            this.spdDataInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdDataInfo.TabIndex = 0;
            this.spdDataInfo.TabStop = false;
            this.spdDataInfo.TextTipDelay = 200;
            this.spdDataInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdDataInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdDataInfo.VerticalScrollBar.Name = "";
            this.spdDataInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdDataInfo.VerticalScrollBar.TabIndex = 7;
            this.spdDataInfo.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdDataInfo.SetViewportLeftColumn(0, 0, 2);
            this.spdDataInfo.SetActiveViewport(0, -1, -1);
            // 
            // spdDataInfo_Sheet1
            // 
            this.spdDataInfo_Sheet1.Reset();
            spdDataInfo_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDataInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDataInfo_Sheet1.ColumnCount = 1036;
            spdDataInfo_Sheet1.ColumnHeader.RowCount = 2;
            spdDataInfo_Sheet1.RowCount = 0;
            spdDataInfo_Sheet1.RowHeader.ColumnCount = 0;
            this.spdDataInfo_Sheet1.ActiveColumnIndex = -1;
            this.spdDataInfo_Sheet1.ActiveRowIndex = -1;
            this.spdDataInfo_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdDataInfo_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDataInfo_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdDataInfo_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDataInfo_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Chart ID";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Hist Seq";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Unit Seq";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Tran Time";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "L/R";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Lot ID";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Mat ID";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Mat Desc";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Mat Ver";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 9).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Flow";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 10).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Oper";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 11).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Proc Oper";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 12).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 12).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Res ID";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 13).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Sub Resource";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 14).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 14).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Proc Res ID";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 15).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 15).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Event ID";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 16).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Unit ID";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 17).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Nominal";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 18).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Process Sigma";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 19).ColumnSpan = 1000;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "      Value";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1019).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1020).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1020).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1020).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1020).Value = "Average";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1020).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1021).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1021).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1021).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1021).Value = "Sigma";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1021).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1022).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1022).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1022).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1022).Value = "Range";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1022).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1023).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1023).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1023).Value = "Max Value";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1023).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1024).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1024).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1024).Value = "Min Value";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1024).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1025).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1025).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1025).Value = "USL";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1025).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1026).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1026).Value = "Target";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1027).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1027).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1027).Value = "LSL";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1027).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1028).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1028).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1028).Value = "UCL";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1028).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1029).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1029).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1029).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1029).Value = "CL";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1029).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1030).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1030).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1030).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1030).Value = "LCL";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1030).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1031).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1031).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1031).Value = "UCL2";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1031).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1032).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1032).Locked = false;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1032).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1032).Value = "CL2";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1032).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1033).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1033).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1033).Value = "LCL2";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1033).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1034).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1034).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1034).Value = "OOC Type";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1034).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1035).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1035).RowSpan = 2;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1035).Value = "OOC Type2";
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(0, 1035).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.ColumnHeader.Cells.Get(1, 19).Value = "1";
            this.spdDataInfo_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDataInfo_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdDataInfo_Sheet1.ColumnHeader.Rows.Get(0).Height = 16F;
            this.spdDataInfo_Sheet1.ColumnHeader.Rows.Get(1).Height = 16F;
            this.spdDataInfo_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDataInfo_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(0).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(0).Width = 100F;
            this.spdDataInfo_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdDataInfo_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1).Width = 30F;
            this.spdDataInfo_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(2).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(2).Width = 30F;
            this.spdDataInfo_Sheet1.Columns.Get(3).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(3).Width = 140F;
            this.spdDataInfo_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(4).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(4).Width = 30F;
            this.spdDataInfo_Sheet1.Columns.Get(5).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(5).Width = 100F;
            this.spdDataInfo_Sheet1.Columns.Get(6).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(6).Width = 100F;
            this.spdDataInfo_Sheet1.Columns.Get(7).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(7).Width = 100F;
            this.spdDataInfo_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(8).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(8).Width = 30F;
            this.spdDataInfo_Sheet1.Columns.Get(9).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(9).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDataInfo_Sheet1.Columns.Get(10).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(10).Width = 40F;
            this.spdDataInfo_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDataInfo_Sheet1.Columns.Get(11).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(11).Width = 40F;
            this.spdDataInfo_Sheet1.Columns.Get(12).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(12).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(13).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(13).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(14).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(14).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(15).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(15).Width = 100F;
            this.spdDataInfo_Sheet1.Columns.Get(16).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(16).Width = 100F;
            this.spdDataInfo_Sheet1.Columns.Get(17).CellType = textCellType1;
            this.spdDataInfo_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(17).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(17).Width = 55F;
            this.spdDataInfo_Sheet1.Columns.Get(18).CellType = textCellType2;
            this.spdDataInfo_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(18).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(18).Width = 80F;
            this.spdDataInfo_Sheet1.Columns.Get(19).CellType = textCellType3;
            this.spdDataInfo_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(19).Label = "1";
            this.spdDataInfo_Sheet1.Columns.Get(19).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(20).CellType = textCellType4;
            this.spdDataInfo_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(20).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(20).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(21).CellType = textCellType5;
            this.spdDataInfo_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(21).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(21).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(22).CellType = textCellType6;
            this.spdDataInfo_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(22).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(22).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(23).CellType = textCellType7;
            this.spdDataInfo_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(23).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(23).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(24).CellType = textCellType8;
            this.spdDataInfo_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(24).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(24).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(25).CellType = textCellType9;
            this.spdDataInfo_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(25).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(25).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(26).CellType = textCellType10;
            this.spdDataInfo_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(26).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(26).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(27).CellType = textCellType11;
            this.spdDataInfo_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(27).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(27).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(28).CellType = textCellType12;
            this.spdDataInfo_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(28).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(28).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(29).CellType = textCellType13;
            this.spdDataInfo_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(29).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(29).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(30).CellType = textCellType14;
            this.spdDataInfo_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(30).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(30).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(31).CellType = textCellType15;
            this.spdDataInfo_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(31).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(31).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(32).CellType = textCellType16;
            this.spdDataInfo_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(32).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(32).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(33).CellType = textCellType17;
            this.spdDataInfo_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(33).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(33).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(34).CellType = textCellType18;
            this.spdDataInfo_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(34).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(34).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(35).CellType = textCellType19;
            this.spdDataInfo_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(35).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(35).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(36).CellType = textCellType20;
            this.spdDataInfo_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(36).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(36).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(37).CellType = textCellType21;
            this.spdDataInfo_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(37).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(37).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(38).CellType = textCellType22;
            this.spdDataInfo_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(38).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(38).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(39).CellType = textCellType23;
            this.spdDataInfo_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(39).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(39).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(40).CellType = textCellType24;
            this.spdDataInfo_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(40).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(40).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(41).CellType = textCellType25;
            this.spdDataInfo_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(41).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(41).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(42).CellType = textCellType26;
            this.spdDataInfo_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(42).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(42).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(43).CellType = textCellType27;
            this.spdDataInfo_Sheet1.Columns.Get(43).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(43).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(43).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(44).CellType = textCellType28;
            this.spdDataInfo_Sheet1.Columns.Get(44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(44).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(44).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(45).CellType = textCellType29;
            this.spdDataInfo_Sheet1.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(45).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(45).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(46).CellType = textCellType30;
            this.spdDataInfo_Sheet1.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(46).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(46).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(47).CellType = textCellType31;
            this.spdDataInfo_Sheet1.Columns.Get(47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(47).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(47).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(48).CellType = textCellType32;
            this.spdDataInfo_Sheet1.Columns.Get(48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(48).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(48).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(49).CellType = textCellType33;
            this.spdDataInfo_Sheet1.Columns.Get(49).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(49).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(49).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(50).CellType = textCellType34;
            this.spdDataInfo_Sheet1.Columns.Get(50).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(50).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(50).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(51).CellType = textCellType35;
            this.spdDataInfo_Sheet1.Columns.Get(51).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(51).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(51).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(52).CellType = textCellType36;
            this.spdDataInfo_Sheet1.Columns.Get(52).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(52).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(52).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(53).CellType = textCellType37;
            this.spdDataInfo_Sheet1.Columns.Get(53).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(53).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(53).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(54).CellType = textCellType38;
            this.spdDataInfo_Sheet1.Columns.Get(54).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(54).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(54).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(55).CellType = textCellType39;
            this.spdDataInfo_Sheet1.Columns.Get(55).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(55).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(55).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(56).CellType = textCellType40;
            this.spdDataInfo_Sheet1.Columns.Get(56).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(56).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(56).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(57).CellType = textCellType41;
            this.spdDataInfo_Sheet1.Columns.Get(57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(57).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(57).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(58).CellType = textCellType42;
            this.spdDataInfo_Sheet1.Columns.Get(58).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(58).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(58).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(59).CellType = textCellType43;
            this.spdDataInfo_Sheet1.Columns.Get(59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(59).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(59).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(60).CellType = textCellType44;
            this.spdDataInfo_Sheet1.Columns.Get(60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(60).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(60).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(61).CellType = textCellType45;
            this.spdDataInfo_Sheet1.Columns.Get(61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(61).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(61).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(62).CellType = textCellType46;
            this.spdDataInfo_Sheet1.Columns.Get(62).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(62).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(62).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(63).CellType = textCellType47;
            this.spdDataInfo_Sheet1.Columns.Get(63).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(63).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(63).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(64).CellType = textCellType48;
            this.spdDataInfo_Sheet1.Columns.Get(64).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(64).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(64).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(65).CellType = textCellType49;
            this.spdDataInfo_Sheet1.Columns.Get(65).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(65).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(65).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(66).CellType = textCellType50;
            this.spdDataInfo_Sheet1.Columns.Get(66).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(66).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(66).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(67).CellType = textCellType51;
            this.spdDataInfo_Sheet1.Columns.Get(67).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(67).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(67).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(68).CellType = textCellType52;
            this.spdDataInfo_Sheet1.Columns.Get(68).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(68).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(68).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(69).CellType = textCellType53;
            this.spdDataInfo_Sheet1.Columns.Get(69).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(69).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(69).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(70).CellType = textCellType54;
            this.spdDataInfo_Sheet1.Columns.Get(70).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(70).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(70).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(71).CellType = textCellType55;
            this.spdDataInfo_Sheet1.Columns.Get(71).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(71).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(71).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(72).CellType = textCellType56;
            this.spdDataInfo_Sheet1.Columns.Get(72).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(72).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(72).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(73).CellType = textCellType57;
            this.spdDataInfo_Sheet1.Columns.Get(73).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(73).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(73).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(74).CellType = textCellType58;
            this.spdDataInfo_Sheet1.Columns.Get(74).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(74).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(74).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(75).CellType = textCellType59;
            this.spdDataInfo_Sheet1.Columns.Get(75).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(75).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(75).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(76).CellType = textCellType60;
            this.spdDataInfo_Sheet1.Columns.Get(76).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(76).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(76).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(77).CellType = textCellType61;
            this.spdDataInfo_Sheet1.Columns.Get(77).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(77).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(77).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(78).CellType = textCellType62;
            this.spdDataInfo_Sheet1.Columns.Get(78).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(78).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(78).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(79).CellType = textCellType63;
            this.spdDataInfo_Sheet1.Columns.Get(79).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(79).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(79).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(80).CellType = textCellType64;
            this.spdDataInfo_Sheet1.Columns.Get(80).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(80).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(80).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(81).CellType = textCellType65;
            this.spdDataInfo_Sheet1.Columns.Get(81).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(81).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(81).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(82).CellType = textCellType66;
            this.spdDataInfo_Sheet1.Columns.Get(82).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(82).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(82).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(83).CellType = textCellType67;
            this.spdDataInfo_Sheet1.Columns.Get(83).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(83).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(83).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(84).CellType = textCellType68;
            this.spdDataInfo_Sheet1.Columns.Get(84).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(84).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(84).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(85).CellType = textCellType69;
            this.spdDataInfo_Sheet1.Columns.Get(85).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(85).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(85).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(85).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(86).CellType = textCellType70;
            this.spdDataInfo_Sheet1.Columns.Get(86).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(86).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(86).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(86).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(87).CellType = textCellType71;
            this.spdDataInfo_Sheet1.Columns.Get(87).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(87).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(87).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(87).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(88).CellType = textCellType72;
            this.spdDataInfo_Sheet1.Columns.Get(88).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(88).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(88).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(88).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(89).CellType = textCellType73;
            this.spdDataInfo_Sheet1.Columns.Get(89).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(89).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(89).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(89).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(90).CellType = textCellType74;
            this.spdDataInfo_Sheet1.Columns.Get(90).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(90).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(90).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(90).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(91).CellType = textCellType75;
            this.spdDataInfo_Sheet1.Columns.Get(91).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(91).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(91).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(91).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(92).CellType = textCellType76;
            this.spdDataInfo_Sheet1.Columns.Get(92).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(92).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(92).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(92).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(93).CellType = textCellType77;
            this.spdDataInfo_Sheet1.Columns.Get(93).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(93).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(93).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(93).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(94).CellType = textCellType78;
            this.spdDataInfo_Sheet1.Columns.Get(94).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(94).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(94).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(94).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(95).CellType = textCellType79;
            this.spdDataInfo_Sheet1.Columns.Get(95).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(95).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(95).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(95).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(96).CellType = textCellType80;
            this.spdDataInfo_Sheet1.Columns.Get(96).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(96).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(96).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(96).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(97).CellType = textCellType81;
            this.spdDataInfo_Sheet1.Columns.Get(97).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(97).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(97).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(97).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(98).CellType = textCellType82;
            this.spdDataInfo_Sheet1.Columns.Get(98).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(98).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(98).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(98).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(99).CellType = textCellType83;
            this.spdDataInfo_Sheet1.Columns.Get(99).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(99).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(99).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(99).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(100).CellType = textCellType84;
            this.spdDataInfo_Sheet1.Columns.Get(100).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(100).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(100).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(100).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(101).CellType = textCellType85;
            this.spdDataInfo_Sheet1.Columns.Get(101).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(101).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(101).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(101).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(102).CellType = textCellType86;
            this.spdDataInfo_Sheet1.Columns.Get(102).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(102).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(102).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(102).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(103).CellType = textCellType87;
            this.spdDataInfo_Sheet1.Columns.Get(103).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(103).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(103).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(103).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(104).CellType = textCellType88;
            this.spdDataInfo_Sheet1.Columns.Get(104).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(104).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(104).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(104).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(105).CellType = textCellType89;
            this.spdDataInfo_Sheet1.Columns.Get(105).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(105).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(105).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(105).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(106).CellType = textCellType90;
            this.spdDataInfo_Sheet1.Columns.Get(106).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(106).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(106).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(106).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(107).CellType = textCellType91;
            this.spdDataInfo_Sheet1.Columns.Get(107).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(107).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(107).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(107).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(108).CellType = textCellType92;
            this.spdDataInfo_Sheet1.Columns.Get(108).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(108).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(108).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(108).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(109).CellType = textCellType93;
            this.spdDataInfo_Sheet1.Columns.Get(109).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(109).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(109).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(109).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(110).CellType = textCellType94;
            this.spdDataInfo_Sheet1.Columns.Get(110).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(110).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(110).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(110).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(111).CellType = textCellType95;
            this.spdDataInfo_Sheet1.Columns.Get(111).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(111).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(111).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(111).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(112).CellType = textCellType96;
            this.spdDataInfo_Sheet1.Columns.Get(112).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(112).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(112).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(112).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(113).CellType = textCellType97;
            this.spdDataInfo_Sheet1.Columns.Get(113).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(113).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(113).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(113).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(114).CellType = textCellType98;
            this.spdDataInfo_Sheet1.Columns.Get(114).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(114).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(114).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(114).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(115).CellType = textCellType99;
            this.spdDataInfo_Sheet1.Columns.Get(115).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(115).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(115).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(115).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(116).CellType = textCellType100;
            this.spdDataInfo_Sheet1.Columns.Get(116).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(116).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(116).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(116).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(117).CellType = textCellType101;
            this.spdDataInfo_Sheet1.Columns.Get(117).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(117).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(117).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(117).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(118).CellType = textCellType102;
            this.spdDataInfo_Sheet1.Columns.Get(118).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(118).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(118).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(118).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(119).CellType = textCellType103;
            this.spdDataInfo_Sheet1.Columns.Get(119).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(119).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(119).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(119).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(120).CellType = textCellType104;
            this.spdDataInfo_Sheet1.Columns.Get(120).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(120).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(120).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(120).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(121).CellType = textCellType105;
            this.spdDataInfo_Sheet1.Columns.Get(121).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(121).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(121).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(121).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(122).CellType = textCellType106;
            this.spdDataInfo_Sheet1.Columns.Get(122).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(122).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(122).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(122).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(123).CellType = textCellType107;
            this.spdDataInfo_Sheet1.Columns.Get(123).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(123).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(123).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(123).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(124).CellType = textCellType108;
            this.spdDataInfo_Sheet1.Columns.Get(124).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(124).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(124).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(124).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(125).CellType = textCellType109;
            this.spdDataInfo_Sheet1.Columns.Get(125).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(125).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(125).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(125).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(126).CellType = textCellType110;
            this.spdDataInfo_Sheet1.Columns.Get(126).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(126).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(126).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(126).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(127).CellType = textCellType111;
            this.spdDataInfo_Sheet1.Columns.Get(127).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(127).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(127).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(127).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(128).CellType = textCellType112;
            this.spdDataInfo_Sheet1.Columns.Get(128).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(128).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(128).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(128).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(129).CellType = textCellType113;
            this.spdDataInfo_Sheet1.Columns.Get(129).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(129).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(129).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(129).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(130).CellType = textCellType114;
            this.spdDataInfo_Sheet1.Columns.Get(130).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(130).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(130).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(130).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(131).CellType = textCellType115;
            this.spdDataInfo_Sheet1.Columns.Get(131).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(131).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(131).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(131).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(132).CellType = textCellType116;
            this.spdDataInfo_Sheet1.Columns.Get(132).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(132).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(132).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(132).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(133).CellType = textCellType117;
            this.spdDataInfo_Sheet1.Columns.Get(133).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(133).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(133).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(133).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(134).CellType = textCellType118;
            this.spdDataInfo_Sheet1.Columns.Get(134).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(134).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(134).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(134).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(135).CellType = textCellType119;
            this.spdDataInfo_Sheet1.Columns.Get(135).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(135).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(135).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(135).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(136).CellType = textCellType120;
            this.spdDataInfo_Sheet1.Columns.Get(136).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(136).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(136).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(136).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(137).CellType = textCellType121;
            this.spdDataInfo_Sheet1.Columns.Get(137).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(137).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(137).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(137).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(138).CellType = textCellType122;
            this.spdDataInfo_Sheet1.Columns.Get(138).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(138).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(138).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(138).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(139).CellType = textCellType123;
            this.spdDataInfo_Sheet1.Columns.Get(139).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(139).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(139).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(139).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(140).CellType = textCellType124;
            this.spdDataInfo_Sheet1.Columns.Get(140).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(140).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(140).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(140).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(141).CellType = textCellType125;
            this.spdDataInfo_Sheet1.Columns.Get(141).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(141).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(141).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(141).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(142).CellType = textCellType126;
            this.spdDataInfo_Sheet1.Columns.Get(142).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(142).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(142).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(142).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(143).CellType = textCellType127;
            this.spdDataInfo_Sheet1.Columns.Get(143).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(143).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(143).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(143).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(144).CellType = textCellType128;
            this.spdDataInfo_Sheet1.Columns.Get(144).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(144).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(144).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(144).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(145).CellType = textCellType129;
            this.spdDataInfo_Sheet1.Columns.Get(145).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(145).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(145).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(145).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(146).CellType = textCellType130;
            this.spdDataInfo_Sheet1.Columns.Get(146).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(146).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(146).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(146).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(147).CellType = textCellType131;
            this.spdDataInfo_Sheet1.Columns.Get(147).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(147).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(147).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(147).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(148).CellType = textCellType132;
            this.spdDataInfo_Sheet1.Columns.Get(148).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(148).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(148).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(148).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(149).CellType = textCellType133;
            this.spdDataInfo_Sheet1.Columns.Get(149).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(149).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(149).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(149).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(150).CellType = textCellType134;
            this.spdDataInfo_Sheet1.Columns.Get(150).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(150).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(150).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(150).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(151).CellType = textCellType135;
            this.spdDataInfo_Sheet1.Columns.Get(151).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(151).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(151).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(151).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(152).CellType = textCellType136;
            this.spdDataInfo_Sheet1.Columns.Get(152).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(152).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(152).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(152).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(153).CellType = textCellType137;
            this.spdDataInfo_Sheet1.Columns.Get(153).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(153).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(153).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(153).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(154).CellType = textCellType138;
            this.spdDataInfo_Sheet1.Columns.Get(154).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(154).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(154).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(154).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(155).CellType = textCellType139;
            this.spdDataInfo_Sheet1.Columns.Get(155).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(155).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(155).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(155).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(156).CellType = textCellType140;
            this.spdDataInfo_Sheet1.Columns.Get(156).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(156).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(156).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(156).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(157).CellType = textCellType141;
            this.spdDataInfo_Sheet1.Columns.Get(157).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(157).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(157).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(157).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(158).CellType = textCellType142;
            this.spdDataInfo_Sheet1.Columns.Get(158).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(158).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(158).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(158).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(159).CellType = textCellType143;
            this.spdDataInfo_Sheet1.Columns.Get(159).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(159).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(159).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(159).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(160).CellType = textCellType144;
            this.spdDataInfo_Sheet1.Columns.Get(160).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(160).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(160).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(160).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(161).CellType = textCellType145;
            this.spdDataInfo_Sheet1.Columns.Get(161).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(161).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(161).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(161).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(162).CellType = textCellType146;
            this.spdDataInfo_Sheet1.Columns.Get(162).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(162).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(162).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(162).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(163).CellType = textCellType147;
            this.spdDataInfo_Sheet1.Columns.Get(163).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(163).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(163).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(163).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(164).CellType = textCellType148;
            this.spdDataInfo_Sheet1.Columns.Get(164).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(164).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(164).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(164).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(165).CellType = textCellType149;
            this.spdDataInfo_Sheet1.Columns.Get(165).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(165).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(165).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(165).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(166).CellType = textCellType150;
            this.spdDataInfo_Sheet1.Columns.Get(166).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(166).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(166).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(166).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(167).CellType = textCellType151;
            this.spdDataInfo_Sheet1.Columns.Get(167).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(167).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(167).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(167).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(168).CellType = textCellType152;
            this.spdDataInfo_Sheet1.Columns.Get(168).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(168).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(168).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(168).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(169).CellType = textCellType153;
            this.spdDataInfo_Sheet1.Columns.Get(169).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(169).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(169).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(169).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(170).CellType = textCellType154;
            this.spdDataInfo_Sheet1.Columns.Get(170).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(170).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(170).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(170).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(171).CellType = textCellType155;
            this.spdDataInfo_Sheet1.Columns.Get(171).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(171).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(171).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(171).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(172).CellType = textCellType156;
            this.spdDataInfo_Sheet1.Columns.Get(172).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(172).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(172).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(172).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(173).CellType = textCellType157;
            this.spdDataInfo_Sheet1.Columns.Get(173).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(173).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(173).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(173).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(174).CellType = textCellType158;
            this.spdDataInfo_Sheet1.Columns.Get(174).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(174).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(174).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(174).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(175).CellType = textCellType159;
            this.spdDataInfo_Sheet1.Columns.Get(175).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(175).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(175).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(175).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(176).CellType = textCellType160;
            this.spdDataInfo_Sheet1.Columns.Get(176).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(176).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(176).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(176).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(177).CellType = textCellType161;
            this.spdDataInfo_Sheet1.Columns.Get(177).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(177).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(177).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(177).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(178).CellType = textCellType162;
            this.spdDataInfo_Sheet1.Columns.Get(178).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(178).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(178).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(178).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(179).CellType = textCellType163;
            this.spdDataInfo_Sheet1.Columns.Get(179).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(179).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(179).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(179).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(180).CellType = textCellType164;
            this.spdDataInfo_Sheet1.Columns.Get(180).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(180).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(180).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(180).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(181).CellType = textCellType165;
            this.spdDataInfo_Sheet1.Columns.Get(181).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(181).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(181).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(181).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(182).CellType = textCellType166;
            this.spdDataInfo_Sheet1.Columns.Get(182).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(182).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(182).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(182).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(183).CellType = textCellType167;
            this.spdDataInfo_Sheet1.Columns.Get(183).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(183).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(183).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(183).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(184).CellType = textCellType168;
            this.spdDataInfo_Sheet1.Columns.Get(184).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(184).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(184).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(184).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(185).CellType = textCellType169;
            this.spdDataInfo_Sheet1.Columns.Get(185).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(185).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(185).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(185).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(186).CellType = textCellType170;
            this.spdDataInfo_Sheet1.Columns.Get(186).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(186).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(186).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(186).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(187).CellType = textCellType171;
            this.spdDataInfo_Sheet1.Columns.Get(187).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(187).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(187).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(187).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(188).CellType = textCellType172;
            this.spdDataInfo_Sheet1.Columns.Get(188).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(188).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(188).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(188).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(189).CellType = textCellType173;
            this.spdDataInfo_Sheet1.Columns.Get(189).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(189).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(189).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(189).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(190).CellType = textCellType174;
            this.spdDataInfo_Sheet1.Columns.Get(190).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(190).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(190).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(190).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(191).CellType = textCellType175;
            this.spdDataInfo_Sheet1.Columns.Get(191).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(191).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(191).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(191).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(192).CellType = textCellType176;
            this.spdDataInfo_Sheet1.Columns.Get(192).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(192).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(192).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(192).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(193).CellType = textCellType177;
            this.spdDataInfo_Sheet1.Columns.Get(193).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(193).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(193).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(193).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(194).CellType = textCellType178;
            this.spdDataInfo_Sheet1.Columns.Get(194).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(194).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(194).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(194).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(195).CellType = textCellType179;
            this.spdDataInfo_Sheet1.Columns.Get(195).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(195).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(195).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(195).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(196).CellType = textCellType180;
            this.spdDataInfo_Sheet1.Columns.Get(196).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(196).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(196).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(196).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(197).CellType = textCellType181;
            this.spdDataInfo_Sheet1.Columns.Get(197).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(197).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(197).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(197).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(198).CellType = textCellType182;
            this.spdDataInfo_Sheet1.Columns.Get(198).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(198).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(198).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(198).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(199).CellType = textCellType183;
            this.spdDataInfo_Sheet1.Columns.Get(199).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(199).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(199).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(199).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(200).CellType = textCellType184;
            this.spdDataInfo_Sheet1.Columns.Get(200).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(200).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(200).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(200).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(201).CellType = textCellType185;
            this.spdDataInfo_Sheet1.Columns.Get(201).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(201).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(201).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(201).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(202).CellType = textCellType186;
            this.spdDataInfo_Sheet1.Columns.Get(202).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(202).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(202).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(202).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(203).CellType = textCellType187;
            this.spdDataInfo_Sheet1.Columns.Get(203).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(203).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(203).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(203).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(204).CellType = textCellType188;
            this.spdDataInfo_Sheet1.Columns.Get(204).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(204).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(204).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(204).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(205).CellType = textCellType189;
            this.spdDataInfo_Sheet1.Columns.Get(205).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(205).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(205).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(205).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(206).CellType = textCellType190;
            this.spdDataInfo_Sheet1.Columns.Get(206).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(206).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(206).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(206).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(207).CellType = textCellType191;
            this.spdDataInfo_Sheet1.Columns.Get(207).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(207).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(207).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(207).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(208).CellType = textCellType192;
            this.spdDataInfo_Sheet1.Columns.Get(208).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(208).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(208).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(208).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(209).CellType = textCellType193;
            this.spdDataInfo_Sheet1.Columns.Get(209).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(209).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(209).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(209).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(210).CellType = textCellType194;
            this.spdDataInfo_Sheet1.Columns.Get(210).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(210).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(210).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(210).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(211).CellType = textCellType195;
            this.spdDataInfo_Sheet1.Columns.Get(211).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(211).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(211).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(211).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(212).CellType = textCellType196;
            this.spdDataInfo_Sheet1.Columns.Get(212).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(212).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(212).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(212).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(213).CellType = textCellType197;
            this.spdDataInfo_Sheet1.Columns.Get(213).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(213).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(213).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(213).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(214).CellType = textCellType198;
            this.spdDataInfo_Sheet1.Columns.Get(214).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(214).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(214).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(214).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(215).CellType = textCellType199;
            this.spdDataInfo_Sheet1.Columns.Get(215).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(215).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(215).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(215).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(216).CellType = textCellType200;
            this.spdDataInfo_Sheet1.Columns.Get(216).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(216).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(216).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(216).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(217).CellType = textCellType201;
            this.spdDataInfo_Sheet1.Columns.Get(217).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(217).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(217).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(217).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(218).CellType = textCellType202;
            this.spdDataInfo_Sheet1.Columns.Get(218).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(218).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(218).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(218).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(219).CellType = textCellType203;
            this.spdDataInfo_Sheet1.Columns.Get(219).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(219).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(219).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(219).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(220).CellType = textCellType204;
            this.spdDataInfo_Sheet1.Columns.Get(220).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(220).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(220).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(220).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(221).CellType = textCellType205;
            this.spdDataInfo_Sheet1.Columns.Get(221).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(221).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(221).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(221).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(222).CellType = textCellType206;
            this.spdDataInfo_Sheet1.Columns.Get(222).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(222).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(222).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(222).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(223).CellType = textCellType207;
            this.spdDataInfo_Sheet1.Columns.Get(223).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(223).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(223).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(223).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(224).CellType = textCellType208;
            this.spdDataInfo_Sheet1.Columns.Get(224).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(224).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(224).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(224).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(225).CellType = textCellType209;
            this.spdDataInfo_Sheet1.Columns.Get(225).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(225).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(225).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(225).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(226).CellType = textCellType210;
            this.spdDataInfo_Sheet1.Columns.Get(226).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(226).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(226).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(226).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(227).CellType = textCellType211;
            this.spdDataInfo_Sheet1.Columns.Get(227).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(227).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(227).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(227).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(228).CellType = textCellType212;
            this.spdDataInfo_Sheet1.Columns.Get(228).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(228).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(228).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(228).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(229).CellType = textCellType213;
            this.spdDataInfo_Sheet1.Columns.Get(229).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(229).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(229).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(229).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(230).CellType = textCellType214;
            this.spdDataInfo_Sheet1.Columns.Get(230).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(230).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(230).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(230).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(231).CellType = textCellType215;
            this.spdDataInfo_Sheet1.Columns.Get(231).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(231).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(231).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(231).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(232).CellType = textCellType216;
            this.spdDataInfo_Sheet1.Columns.Get(232).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(232).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(232).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(232).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(233).CellType = textCellType217;
            this.spdDataInfo_Sheet1.Columns.Get(233).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(233).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(233).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(233).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(234).CellType = textCellType218;
            this.spdDataInfo_Sheet1.Columns.Get(234).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(234).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(234).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(234).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(235).CellType = textCellType219;
            this.spdDataInfo_Sheet1.Columns.Get(235).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(235).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(235).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(235).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(236).CellType = textCellType220;
            this.spdDataInfo_Sheet1.Columns.Get(236).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(236).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(236).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(236).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(237).CellType = textCellType221;
            this.spdDataInfo_Sheet1.Columns.Get(237).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(237).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(237).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(237).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(238).CellType = textCellType222;
            this.spdDataInfo_Sheet1.Columns.Get(238).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(238).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(238).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(238).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(239).CellType = textCellType223;
            this.spdDataInfo_Sheet1.Columns.Get(239).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(239).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(239).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(239).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(240).CellType = textCellType224;
            this.spdDataInfo_Sheet1.Columns.Get(240).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(240).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(240).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(240).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(241).CellType = textCellType225;
            this.spdDataInfo_Sheet1.Columns.Get(241).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(241).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(241).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(241).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(242).CellType = textCellType226;
            this.spdDataInfo_Sheet1.Columns.Get(242).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(242).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(242).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(242).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(243).CellType = textCellType227;
            this.spdDataInfo_Sheet1.Columns.Get(243).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(243).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(243).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(243).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(244).CellType = textCellType228;
            this.spdDataInfo_Sheet1.Columns.Get(244).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(244).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(244).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(244).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(245).CellType = textCellType229;
            this.spdDataInfo_Sheet1.Columns.Get(245).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(245).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(245).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(245).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(246).CellType = textCellType230;
            this.spdDataInfo_Sheet1.Columns.Get(246).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(246).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(246).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(246).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(247).CellType = textCellType231;
            this.spdDataInfo_Sheet1.Columns.Get(247).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(247).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(247).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(247).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(248).CellType = textCellType232;
            this.spdDataInfo_Sheet1.Columns.Get(248).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(248).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(248).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(248).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(249).CellType = textCellType233;
            this.spdDataInfo_Sheet1.Columns.Get(249).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(249).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(249).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(249).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(250).CellType = textCellType234;
            this.spdDataInfo_Sheet1.Columns.Get(250).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(250).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(250).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(250).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(251).CellType = textCellType235;
            this.spdDataInfo_Sheet1.Columns.Get(251).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(251).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(251).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(251).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(252).CellType = textCellType236;
            this.spdDataInfo_Sheet1.Columns.Get(252).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(252).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(252).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(252).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(253).CellType = textCellType237;
            this.spdDataInfo_Sheet1.Columns.Get(253).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(253).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(253).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(253).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(254).CellType = textCellType238;
            this.spdDataInfo_Sheet1.Columns.Get(254).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(254).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(254).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(254).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(255).CellType = textCellType239;
            this.spdDataInfo_Sheet1.Columns.Get(255).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(255).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(255).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(255).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(256).CellType = textCellType240;
            this.spdDataInfo_Sheet1.Columns.Get(256).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(256).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(256).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(256).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(257).CellType = textCellType241;
            this.spdDataInfo_Sheet1.Columns.Get(257).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(257).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(257).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(257).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(258).CellType = textCellType242;
            this.spdDataInfo_Sheet1.Columns.Get(258).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(258).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(258).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(258).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(259).CellType = textCellType243;
            this.spdDataInfo_Sheet1.Columns.Get(259).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(259).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(259).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(259).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(260).CellType = textCellType244;
            this.spdDataInfo_Sheet1.Columns.Get(260).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(260).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(260).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(260).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(261).CellType = textCellType245;
            this.spdDataInfo_Sheet1.Columns.Get(261).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(261).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(261).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(261).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(262).CellType = textCellType246;
            this.spdDataInfo_Sheet1.Columns.Get(262).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(262).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(262).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(262).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(263).CellType = textCellType247;
            this.spdDataInfo_Sheet1.Columns.Get(263).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(263).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(263).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(263).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(264).CellType = textCellType248;
            this.spdDataInfo_Sheet1.Columns.Get(264).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(264).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(264).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(264).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(265).CellType = textCellType249;
            this.spdDataInfo_Sheet1.Columns.Get(265).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(265).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(265).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(265).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(266).CellType = textCellType250;
            this.spdDataInfo_Sheet1.Columns.Get(266).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(266).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(266).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(266).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(267).CellType = textCellType251;
            this.spdDataInfo_Sheet1.Columns.Get(267).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(267).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(267).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(267).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(268).CellType = textCellType252;
            this.spdDataInfo_Sheet1.Columns.Get(268).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(268).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(268).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(268).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(269).CellType = textCellType253;
            this.spdDataInfo_Sheet1.Columns.Get(269).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(269).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(269).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(269).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(270).CellType = textCellType254;
            this.spdDataInfo_Sheet1.Columns.Get(270).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(270).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(270).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(270).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(271).CellType = textCellType255;
            this.spdDataInfo_Sheet1.Columns.Get(271).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(271).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(271).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(271).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(272).CellType = textCellType256;
            this.spdDataInfo_Sheet1.Columns.Get(272).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(272).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(272).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(272).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(273).CellType = textCellType257;
            this.spdDataInfo_Sheet1.Columns.Get(273).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(273).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(273).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(273).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(274).CellType = textCellType258;
            this.spdDataInfo_Sheet1.Columns.Get(274).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(274).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(274).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(274).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(275).CellType = textCellType259;
            this.spdDataInfo_Sheet1.Columns.Get(275).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(275).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(275).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(275).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(276).CellType = textCellType260;
            this.spdDataInfo_Sheet1.Columns.Get(276).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(276).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(276).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(276).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(277).CellType = textCellType261;
            this.spdDataInfo_Sheet1.Columns.Get(277).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(277).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(277).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(277).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(278).CellType = textCellType262;
            this.spdDataInfo_Sheet1.Columns.Get(278).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(278).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(278).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(278).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(279).CellType = textCellType263;
            this.spdDataInfo_Sheet1.Columns.Get(279).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(279).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(279).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(279).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(280).CellType = textCellType264;
            this.spdDataInfo_Sheet1.Columns.Get(280).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(280).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(280).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(280).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(281).CellType = textCellType265;
            this.spdDataInfo_Sheet1.Columns.Get(281).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(281).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(281).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(281).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(282).CellType = textCellType266;
            this.spdDataInfo_Sheet1.Columns.Get(282).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(282).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(282).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(282).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(283).CellType = textCellType267;
            this.spdDataInfo_Sheet1.Columns.Get(283).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(283).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(283).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(283).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(284).CellType = textCellType268;
            this.spdDataInfo_Sheet1.Columns.Get(284).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(284).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(284).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(284).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(285).CellType = textCellType269;
            this.spdDataInfo_Sheet1.Columns.Get(285).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(285).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(285).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(285).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(286).CellType = textCellType270;
            this.spdDataInfo_Sheet1.Columns.Get(286).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(286).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(286).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(286).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(287).CellType = textCellType271;
            this.spdDataInfo_Sheet1.Columns.Get(287).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(287).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(287).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(287).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(288).CellType = textCellType272;
            this.spdDataInfo_Sheet1.Columns.Get(288).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(288).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(288).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(288).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(289).CellType = textCellType273;
            this.spdDataInfo_Sheet1.Columns.Get(289).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(289).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(289).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(289).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(290).CellType = textCellType274;
            this.spdDataInfo_Sheet1.Columns.Get(290).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(290).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(290).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(290).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(291).CellType = textCellType275;
            this.spdDataInfo_Sheet1.Columns.Get(291).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(291).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(291).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(291).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(292).CellType = textCellType276;
            this.spdDataInfo_Sheet1.Columns.Get(292).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(292).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(292).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(292).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(293).CellType = textCellType277;
            this.spdDataInfo_Sheet1.Columns.Get(293).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(293).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(293).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(293).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(294).CellType = textCellType278;
            this.spdDataInfo_Sheet1.Columns.Get(294).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(294).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(294).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(294).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(295).CellType = textCellType279;
            this.spdDataInfo_Sheet1.Columns.Get(295).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(295).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(295).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(295).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(296).CellType = textCellType280;
            this.spdDataInfo_Sheet1.Columns.Get(296).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(296).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(296).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(296).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(297).CellType = textCellType281;
            this.spdDataInfo_Sheet1.Columns.Get(297).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(297).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(297).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(297).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(298).CellType = textCellType282;
            this.spdDataInfo_Sheet1.Columns.Get(298).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(298).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(298).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(298).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(299).CellType = textCellType283;
            this.spdDataInfo_Sheet1.Columns.Get(299).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(299).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(299).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(299).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(300).CellType = textCellType284;
            this.spdDataInfo_Sheet1.Columns.Get(300).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(300).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(300).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(300).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(301).CellType = textCellType285;
            this.spdDataInfo_Sheet1.Columns.Get(301).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(301).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(301).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(301).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(302).CellType = textCellType286;
            this.spdDataInfo_Sheet1.Columns.Get(302).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(302).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(302).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(302).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(303).CellType = textCellType287;
            this.spdDataInfo_Sheet1.Columns.Get(303).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(303).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(303).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(303).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(304).CellType = textCellType288;
            this.spdDataInfo_Sheet1.Columns.Get(304).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(304).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(304).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(304).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(305).CellType = textCellType289;
            this.spdDataInfo_Sheet1.Columns.Get(305).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(305).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(305).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(305).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(306).CellType = textCellType290;
            this.spdDataInfo_Sheet1.Columns.Get(306).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(306).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(306).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(306).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(307).CellType = textCellType291;
            this.spdDataInfo_Sheet1.Columns.Get(307).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(307).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(307).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(307).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(308).CellType = textCellType292;
            this.spdDataInfo_Sheet1.Columns.Get(308).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(308).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(308).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(308).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(309).CellType = textCellType293;
            this.spdDataInfo_Sheet1.Columns.Get(309).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(309).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(309).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(309).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(310).CellType = textCellType294;
            this.spdDataInfo_Sheet1.Columns.Get(310).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(310).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(310).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(310).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(311).CellType = textCellType295;
            this.spdDataInfo_Sheet1.Columns.Get(311).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(311).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(311).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(311).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(312).CellType = textCellType296;
            this.spdDataInfo_Sheet1.Columns.Get(312).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(312).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(312).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(312).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(313).CellType = textCellType297;
            this.spdDataInfo_Sheet1.Columns.Get(313).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(313).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(313).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(313).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(314).CellType = textCellType298;
            this.spdDataInfo_Sheet1.Columns.Get(314).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(314).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(314).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(314).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(315).CellType = textCellType299;
            this.spdDataInfo_Sheet1.Columns.Get(315).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(315).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(315).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(315).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(316).CellType = textCellType300;
            this.spdDataInfo_Sheet1.Columns.Get(316).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(316).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(316).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(316).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(317).CellType = textCellType301;
            this.spdDataInfo_Sheet1.Columns.Get(317).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(317).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(317).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(317).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(318).CellType = textCellType302;
            this.spdDataInfo_Sheet1.Columns.Get(318).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(318).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(318).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(318).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(319).CellType = textCellType303;
            this.spdDataInfo_Sheet1.Columns.Get(319).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(319).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(319).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(319).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(320).CellType = textCellType304;
            this.spdDataInfo_Sheet1.Columns.Get(320).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(320).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(320).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(320).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(321).CellType = textCellType305;
            this.spdDataInfo_Sheet1.Columns.Get(321).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(321).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(321).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(321).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(322).CellType = textCellType306;
            this.spdDataInfo_Sheet1.Columns.Get(322).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(322).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(322).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(322).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(323).CellType = textCellType307;
            this.spdDataInfo_Sheet1.Columns.Get(323).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(323).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(323).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(323).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(324).CellType = textCellType308;
            this.spdDataInfo_Sheet1.Columns.Get(324).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(324).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(324).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(324).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(325).CellType = textCellType309;
            this.spdDataInfo_Sheet1.Columns.Get(325).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(325).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(325).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(325).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(326).CellType = textCellType310;
            this.spdDataInfo_Sheet1.Columns.Get(326).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(326).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(326).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(326).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(327).CellType = textCellType311;
            this.spdDataInfo_Sheet1.Columns.Get(327).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(327).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(327).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(327).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(328).CellType = textCellType312;
            this.spdDataInfo_Sheet1.Columns.Get(328).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(328).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(328).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(328).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(329).CellType = textCellType313;
            this.spdDataInfo_Sheet1.Columns.Get(329).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(329).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(329).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(329).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(330).CellType = textCellType314;
            this.spdDataInfo_Sheet1.Columns.Get(330).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(330).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(330).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(330).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(331).CellType = textCellType315;
            this.spdDataInfo_Sheet1.Columns.Get(331).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(331).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(331).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(331).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(332).CellType = textCellType316;
            this.spdDataInfo_Sheet1.Columns.Get(332).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(332).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(332).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(332).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(333).CellType = textCellType317;
            this.spdDataInfo_Sheet1.Columns.Get(333).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(333).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(333).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(333).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(334).CellType = textCellType318;
            this.spdDataInfo_Sheet1.Columns.Get(334).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(334).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(334).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(334).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(335).CellType = textCellType319;
            this.spdDataInfo_Sheet1.Columns.Get(335).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(335).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(335).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(335).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(336).CellType = textCellType320;
            this.spdDataInfo_Sheet1.Columns.Get(336).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(336).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(336).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(336).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(337).CellType = textCellType321;
            this.spdDataInfo_Sheet1.Columns.Get(337).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(337).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(337).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(337).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(338).CellType = textCellType322;
            this.spdDataInfo_Sheet1.Columns.Get(338).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(338).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(338).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(338).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(339).CellType = textCellType323;
            this.spdDataInfo_Sheet1.Columns.Get(339).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(339).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(339).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(339).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(340).CellType = textCellType324;
            this.spdDataInfo_Sheet1.Columns.Get(340).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(340).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(340).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(340).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(341).CellType = textCellType325;
            this.spdDataInfo_Sheet1.Columns.Get(341).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(341).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(341).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(341).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(342).CellType = textCellType326;
            this.spdDataInfo_Sheet1.Columns.Get(342).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(342).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(342).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(342).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(343).CellType = textCellType327;
            this.spdDataInfo_Sheet1.Columns.Get(343).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(343).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(343).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(343).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(344).CellType = textCellType328;
            this.spdDataInfo_Sheet1.Columns.Get(344).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(344).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(344).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(344).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(345).CellType = textCellType329;
            this.spdDataInfo_Sheet1.Columns.Get(345).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(345).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(345).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(345).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(346).CellType = textCellType330;
            this.spdDataInfo_Sheet1.Columns.Get(346).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(346).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(346).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(346).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(347).CellType = textCellType331;
            this.spdDataInfo_Sheet1.Columns.Get(347).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(347).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(347).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(347).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(348).CellType = textCellType332;
            this.spdDataInfo_Sheet1.Columns.Get(348).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(348).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(348).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(348).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(349).CellType = textCellType333;
            this.spdDataInfo_Sheet1.Columns.Get(349).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(349).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(349).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(349).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(350).CellType = textCellType334;
            this.spdDataInfo_Sheet1.Columns.Get(350).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(350).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(350).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(350).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(351).CellType = textCellType335;
            this.spdDataInfo_Sheet1.Columns.Get(351).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(351).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(351).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(351).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(352).CellType = textCellType336;
            this.spdDataInfo_Sheet1.Columns.Get(352).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(352).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(352).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(352).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(353).CellType = textCellType337;
            this.spdDataInfo_Sheet1.Columns.Get(353).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(353).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(353).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(353).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(354).CellType = textCellType338;
            this.spdDataInfo_Sheet1.Columns.Get(354).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(354).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(354).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(354).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(355).CellType = textCellType339;
            this.spdDataInfo_Sheet1.Columns.Get(355).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(355).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(355).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(355).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(356).CellType = textCellType340;
            this.spdDataInfo_Sheet1.Columns.Get(356).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(356).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(356).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(356).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(357).CellType = textCellType341;
            this.spdDataInfo_Sheet1.Columns.Get(357).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(357).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(357).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(357).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(358).CellType = textCellType342;
            this.spdDataInfo_Sheet1.Columns.Get(358).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(358).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(358).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(358).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(359).CellType = textCellType343;
            this.spdDataInfo_Sheet1.Columns.Get(359).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(359).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(359).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(359).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(360).CellType = textCellType344;
            this.spdDataInfo_Sheet1.Columns.Get(360).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(360).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(360).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(360).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(361).CellType = textCellType345;
            this.spdDataInfo_Sheet1.Columns.Get(361).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(361).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(361).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(361).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(362).CellType = textCellType346;
            this.spdDataInfo_Sheet1.Columns.Get(362).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(362).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(362).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(362).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(363).CellType = textCellType347;
            this.spdDataInfo_Sheet1.Columns.Get(363).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(363).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(363).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(363).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(364).CellType = textCellType348;
            this.spdDataInfo_Sheet1.Columns.Get(364).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(364).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(364).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(364).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(365).CellType = textCellType349;
            this.spdDataInfo_Sheet1.Columns.Get(365).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(365).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(365).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(365).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(366).CellType = textCellType350;
            this.spdDataInfo_Sheet1.Columns.Get(366).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(366).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(366).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(366).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(367).CellType = textCellType351;
            this.spdDataInfo_Sheet1.Columns.Get(367).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(367).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(367).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(367).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(368).CellType = textCellType352;
            this.spdDataInfo_Sheet1.Columns.Get(368).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(368).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(368).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(368).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(369).CellType = textCellType353;
            this.spdDataInfo_Sheet1.Columns.Get(369).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(369).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(369).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(369).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(370).CellType = textCellType354;
            this.spdDataInfo_Sheet1.Columns.Get(370).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(370).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(370).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(370).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(371).CellType = textCellType355;
            this.spdDataInfo_Sheet1.Columns.Get(371).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(371).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(371).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(371).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(372).CellType = textCellType356;
            this.spdDataInfo_Sheet1.Columns.Get(372).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(372).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(372).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(372).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(373).CellType = textCellType357;
            this.spdDataInfo_Sheet1.Columns.Get(373).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(373).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(373).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(373).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(374).CellType = textCellType358;
            this.spdDataInfo_Sheet1.Columns.Get(374).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(374).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(374).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(374).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(375).CellType = textCellType359;
            this.spdDataInfo_Sheet1.Columns.Get(375).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(375).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(375).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(375).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(376).CellType = textCellType360;
            this.spdDataInfo_Sheet1.Columns.Get(376).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(376).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(376).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(376).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(377).CellType = textCellType361;
            this.spdDataInfo_Sheet1.Columns.Get(377).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(377).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(377).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(377).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(378).CellType = textCellType362;
            this.spdDataInfo_Sheet1.Columns.Get(378).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(378).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(378).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(378).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(379).CellType = textCellType363;
            this.spdDataInfo_Sheet1.Columns.Get(379).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(379).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(379).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(379).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(380).CellType = textCellType364;
            this.spdDataInfo_Sheet1.Columns.Get(380).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(380).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(380).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(380).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(381).CellType = textCellType365;
            this.spdDataInfo_Sheet1.Columns.Get(381).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(381).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(381).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(381).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(382).CellType = textCellType366;
            this.spdDataInfo_Sheet1.Columns.Get(382).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(382).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(382).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(382).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(383).CellType = textCellType367;
            this.spdDataInfo_Sheet1.Columns.Get(383).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(383).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(383).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(383).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(384).CellType = textCellType368;
            this.spdDataInfo_Sheet1.Columns.Get(384).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(384).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(384).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(384).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(385).CellType = textCellType369;
            this.spdDataInfo_Sheet1.Columns.Get(385).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(385).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(385).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(385).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(386).CellType = textCellType370;
            this.spdDataInfo_Sheet1.Columns.Get(386).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(386).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(386).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(386).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(387).CellType = textCellType371;
            this.spdDataInfo_Sheet1.Columns.Get(387).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(387).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(387).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(387).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(388).CellType = textCellType372;
            this.spdDataInfo_Sheet1.Columns.Get(388).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(388).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(388).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(388).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(389).CellType = textCellType373;
            this.spdDataInfo_Sheet1.Columns.Get(389).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(389).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(389).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(389).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(390).CellType = textCellType374;
            this.spdDataInfo_Sheet1.Columns.Get(390).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(390).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(390).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(390).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(391).CellType = textCellType375;
            this.spdDataInfo_Sheet1.Columns.Get(391).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(391).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(391).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(391).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(392).CellType = textCellType376;
            this.spdDataInfo_Sheet1.Columns.Get(392).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(392).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(392).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(392).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(393).CellType = textCellType377;
            this.spdDataInfo_Sheet1.Columns.Get(393).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(393).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(393).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(393).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(394).CellType = textCellType378;
            this.spdDataInfo_Sheet1.Columns.Get(394).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(394).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(394).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(394).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(395).CellType = textCellType379;
            this.spdDataInfo_Sheet1.Columns.Get(395).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(395).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(395).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(395).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(396).CellType = textCellType380;
            this.spdDataInfo_Sheet1.Columns.Get(396).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(396).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(396).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(396).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(397).CellType = textCellType381;
            this.spdDataInfo_Sheet1.Columns.Get(397).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(397).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(397).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(397).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(398).CellType = textCellType382;
            this.spdDataInfo_Sheet1.Columns.Get(398).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(398).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(398).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(398).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(399).CellType = textCellType383;
            this.spdDataInfo_Sheet1.Columns.Get(399).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(399).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(399).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(399).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(400).CellType = textCellType384;
            this.spdDataInfo_Sheet1.Columns.Get(400).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(400).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(400).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(400).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(401).CellType = textCellType385;
            this.spdDataInfo_Sheet1.Columns.Get(401).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(401).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(401).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(401).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(402).CellType = textCellType386;
            this.spdDataInfo_Sheet1.Columns.Get(402).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(402).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(402).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(402).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(403).CellType = textCellType387;
            this.spdDataInfo_Sheet1.Columns.Get(403).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(403).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(403).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(403).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(404).CellType = textCellType388;
            this.spdDataInfo_Sheet1.Columns.Get(404).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(404).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(404).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(404).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(405).CellType = textCellType389;
            this.spdDataInfo_Sheet1.Columns.Get(405).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(405).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(405).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(405).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(406).CellType = textCellType390;
            this.spdDataInfo_Sheet1.Columns.Get(406).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(406).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(406).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(406).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(407).CellType = textCellType391;
            this.spdDataInfo_Sheet1.Columns.Get(407).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(407).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(407).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(407).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(408).CellType = textCellType392;
            this.spdDataInfo_Sheet1.Columns.Get(408).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(408).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(408).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(408).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(409).CellType = textCellType393;
            this.spdDataInfo_Sheet1.Columns.Get(409).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(409).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(409).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(409).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(410).CellType = textCellType394;
            this.spdDataInfo_Sheet1.Columns.Get(410).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(410).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(410).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(410).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(411).CellType = textCellType395;
            this.spdDataInfo_Sheet1.Columns.Get(411).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(411).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(411).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(411).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(412).CellType = textCellType396;
            this.spdDataInfo_Sheet1.Columns.Get(412).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(412).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(412).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(412).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(413).CellType = textCellType397;
            this.spdDataInfo_Sheet1.Columns.Get(413).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(413).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(413).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(413).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(414).CellType = textCellType398;
            this.spdDataInfo_Sheet1.Columns.Get(414).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(414).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(414).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(414).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(415).CellType = textCellType399;
            this.spdDataInfo_Sheet1.Columns.Get(415).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(415).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(415).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(415).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(416).CellType = textCellType400;
            this.spdDataInfo_Sheet1.Columns.Get(416).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(416).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(416).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(416).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(417).CellType = textCellType401;
            this.spdDataInfo_Sheet1.Columns.Get(417).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(417).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(417).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(417).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(418).CellType = textCellType402;
            this.spdDataInfo_Sheet1.Columns.Get(418).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(418).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(418).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(418).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(419).CellType = textCellType403;
            this.spdDataInfo_Sheet1.Columns.Get(419).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(419).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(419).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(419).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(420).CellType = textCellType404;
            this.spdDataInfo_Sheet1.Columns.Get(420).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(420).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(420).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(420).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(421).CellType = textCellType405;
            this.spdDataInfo_Sheet1.Columns.Get(421).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(421).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(421).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(421).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(422).CellType = textCellType406;
            this.spdDataInfo_Sheet1.Columns.Get(422).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(422).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(422).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(422).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(423).CellType = textCellType407;
            this.spdDataInfo_Sheet1.Columns.Get(423).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(423).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(423).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(423).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(424).CellType = textCellType408;
            this.spdDataInfo_Sheet1.Columns.Get(424).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(424).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(424).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(424).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(425).CellType = textCellType409;
            this.spdDataInfo_Sheet1.Columns.Get(425).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(425).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(425).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(425).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(426).CellType = textCellType410;
            this.spdDataInfo_Sheet1.Columns.Get(426).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(426).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(426).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(426).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(427).CellType = textCellType411;
            this.spdDataInfo_Sheet1.Columns.Get(427).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(427).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(427).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(427).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(428).CellType = textCellType412;
            this.spdDataInfo_Sheet1.Columns.Get(428).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(428).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(428).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(428).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(429).CellType = textCellType413;
            this.spdDataInfo_Sheet1.Columns.Get(429).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(429).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(429).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(429).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(430).CellType = textCellType414;
            this.spdDataInfo_Sheet1.Columns.Get(430).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(430).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(430).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(430).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(431).CellType = textCellType415;
            this.spdDataInfo_Sheet1.Columns.Get(431).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(431).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(431).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(431).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(432).CellType = textCellType416;
            this.spdDataInfo_Sheet1.Columns.Get(432).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(432).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(432).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(432).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(433).CellType = textCellType417;
            this.spdDataInfo_Sheet1.Columns.Get(433).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(433).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(433).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(433).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(434).CellType = textCellType418;
            this.spdDataInfo_Sheet1.Columns.Get(434).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(434).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(434).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(434).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(435).CellType = textCellType419;
            this.spdDataInfo_Sheet1.Columns.Get(435).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(435).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(435).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(435).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(436).CellType = textCellType420;
            this.spdDataInfo_Sheet1.Columns.Get(436).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(436).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(436).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(436).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(437).CellType = textCellType421;
            this.spdDataInfo_Sheet1.Columns.Get(437).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(437).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(437).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(437).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(438).CellType = textCellType422;
            this.spdDataInfo_Sheet1.Columns.Get(438).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(438).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(438).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(438).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(439).CellType = textCellType423;
            this.spdDataInfo_Sheet1.Columns.Get(439).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(439).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(439).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(439).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(440).CellType = textCellType424;
            this.spdDataInfo_Sheet1.Columns.Get(440).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(440).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(440).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(440).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(441).CellType = textCellType425;
            this.spdDataInfo_Sheet1.Columns.Get(441).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(441).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(441).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(441).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(442).CellType = textCellType426;
            this.spdDataInfo_Sheet1.Columns.Get(442).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(442).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(442).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(442).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(443).CellType = textCellType427;
            this.spdDataInfo_Sheet1.Columns.Get(443).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(443).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(443).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(443).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(444).CellType = textCellType428;
            this.spdDataInfo_Sheet1.Columns.Get(444).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(444).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(444).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(444).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(445).CellType = textCellType429;
            this.spdDataInfo_Sheet1.Columns.Get(445).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(445).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(445).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(445).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(446).CellType = textCellType430;
            this.spdDataInfo_Sheet1.Columns.Get(446).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(446).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(446).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(446).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(447).CellType = textCellType431;
            this.spdDataInfo_Sheet1.Columns.Get(447).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(447).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(447).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(447).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(448).CellType = textCellType432;
            this.spdDataInfo_Sheet1.Columns.Get(448).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(448).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(448).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(448).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(449).CellType = textCellType433;
            this.spdDataInfo_Sheet1.Columns.Get(449).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(449).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(449).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(449).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(450).CellType = textCellType434;
            this.spdDataInfo_Sheet1.Columns.Get(450).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(450).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(450).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(450).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(451).CellType = textCellType435;
            this.spdDataInfo_Sheet1.Columns.Get(451).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(451).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(451).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(451).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(452).CellType = textCellType436;
            this.spdDataInfo_Sheet1.Columns.Get(452).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(452).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(452).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(452).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(453).CellType = textCellType437;
            this.spdDataInfo_Sheet1.Columns.Get(453).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(453).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(453).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(453).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(454).CellType = textCellType438;
            this.spdDataInfo_Sheet1.Columns.Get(454).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(454).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(454).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(454).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(455).CellType = textCellType439;
            this.spdDataInfo_Sheet1.Columns.Get(455).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(455).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(455).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(455).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(456).CellType = textCellType440;
            this.spdDataInfo_Sheet1.Columns.Get(456).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(456).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(456).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(456).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(457).CellType = textCellType441;
            this.spdDataInfo_Sheet1.Columns.Get(457).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(457).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(457).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(457).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(458).CellType = textCellType442;
            this.spdDataInfo_Sheet1.Columns.Get(458).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(458).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(458).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(458).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(459).CellType = textCellType443;
            this.spdDataInfo_Sheet1.Columns.Get(459).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(459).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(459).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(459).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(460).CellType = textCellType444;
            this.spdDataInfo_Sheet1.Columns.Get(460).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(460).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(460).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(460).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(461).CellType = textCellType445;
            this.spdDataInfo_Sheet1.Columns.Get(461).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(461).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(461).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(461).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(462).CellType = textCellType446;
            this.spdDataInfo_Sheet1.Columns.Get(462).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(462).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(462).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(462).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(463).CellType = textCellType447;
            this.spdDataInfo_Sheet1.Columns.Get(463).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(463).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(463).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(463).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(464).CellType = textCellType448;
            this.spdDataInfo_Sheet1.Columns.Get(464).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(464).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(464).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(464).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(465).CellType = textCellType449;
            this.spdDataInfo_Sheet1.Columns.Get(465).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(465).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(465).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(465).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(466).CellType = textCellType450;
            this.spdDataInfo_Sheet1.Columns.Get(466).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(466).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(466).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(466).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(467).CellType = textCellType451;
            this.spdDataInfo_Sheet1.Columns.Get(467).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(467).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(467).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(467).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(468).CellType = textCellType452;
            this.spdDataInfo_Sheet1.Columns.Get(468).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(468).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(468).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(468).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(469).CellType = textCellType453;
            this.spdDataInfo_Sheet1.Columns.Get(469).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(469).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(469).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(469).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(470).CellType = textCellType454;
            this.spdDataInfo_Sheet1.Columns.Get(470).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(470).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(470).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(470).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(471).CellType = textCellType455;
            this.spdDataInfo_Sheet1.Columns.Get(471).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(471).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(471).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(471).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(472).CellType = textCellType456;
            this.spdDataInfo_Sheet1.Columns.Get(472).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(472).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(472).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(472).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(473).CellType = textCellType457;
            this.spdDataInfo_Sheet1.Columns.Get(473).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(473).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(473).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(473).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(474).CellType = textCellType458;
            this.spdDataInfo_Sheet1.Columns.Get(474).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(474).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(474).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(474).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(475).CellType = textCellType459;
            this.spdDataInfo_Sheet1.Columns.Get(475).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(475).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(475).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(475).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(476).CellType = textCellType460;
            this.spdDataInfo_Sheet1.Columns.Get(476).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(476).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(476).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(476).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(477).CellType = textCellType461;
            this.spdDataInfo_Sheet1.Columns.Get(477).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(477).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(477).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(477).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(478).CellType = textCellType462;
            this.spdDataInfo_Sheet1.Columns.Get(478).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(478).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(478).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(478).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(479).CellType = textCellType463;
            this.spdDataInfo_Sheet1.Columns.Get(479).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(479).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(479).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(479).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(480).CellType = textCellType464;
            this.spdDataInfo_Sheet1.Columns.Get(480).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(480).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(480).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(480).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(481).CellType = textCellType465;
            this.spdDataInfo_Sheet1.Columns.Get(481).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(481).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(481).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(481).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(482).CellType = textCellType466;
            this.spdDataInfo_Sheet1.Columns.Get(482).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(482).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(482).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(482).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(483).CellType = textCellType467;
            this.spdDataInfo_Sheet1.Columns.Get(483).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(483).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(483).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(483).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(484).CellType = textCellType468;
            this.spdDataInfo_Sheet1.Columns.Get(484).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(484).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(484).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(484).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(485).CellType = textCellType469;
            this.spdDataInfo_Sheet1.Columns.Get(485).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(485).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(485).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(485).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(486).CellType = textCellType470;
            this.spdDataInfo_Sheet1.Columns.Get(486).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(486).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(486).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(486).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(487).CellType = textCellType471;
            this.spdDataInfo_Sheet1.Columns.Get(487).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(487).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(487).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(487).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(488).CellType = textCellType472;
            this.spdDataInfo_Sheet1.Columns.Get(488).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(488).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(488).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(488).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(489).CellType = textCellType473;
            this.spdDataInfo_Sheet1.Columns.Get(489).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(489).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(489).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(489).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(490).CellType = textCellType474;
            this.spdDataInfo_Sheet1.Columns.Get(490).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(490).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(490).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(490).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(491).CellType = textCellType475;
            this.spdDataInfo_Sheet1.Columns.Get(491).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(491).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(491).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(491).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(492).CellType = textCellType476;
            this.spdDataInfo_Sheet1.Columns.Get(492).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(492).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(492).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(492).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(493).CellType = textCellType477;
            this.spdDataInfo_Sheet1.Columns.Get(493).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(493).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(493).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(493).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(494).CellType = textCellType478;
            this.spdDataInfo_Sheet1.Columns.Get(494).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(494).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(494).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(494).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(495).CellType = textCellType479;
            this.spdDataInfo_Sheet1.Columns.Get(495).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(495).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(495).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(495).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(496).CellType = textCellType480;
            this.spdDataInfo_Sheet1.Columns.Get(496).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(496).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(496).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(496).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(497).CellType = textCellType481;
            this.spdDataInfo_Sheet1.Columns.Get(497).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(497).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(497).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(497).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(498).CellType = textCellType482;
            this.spdDataInfo_Sheet1.Columns.Get(498).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(498).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(498).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(498).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(499).CellType = textCellType483;
            this.spdDataInfo_Sheet1.Columns.Get(499).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(499).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(499).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(499).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(500).CellType = textCellType484;
            this.spdDataInfo_Sheet1.Columns.Get(500).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(500).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(500).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(500).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(501).CellType = textCellType485;
            this.spdDataInfo_Sheet1.Columns.Get(501).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(501).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(501).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(501).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(502).CellType = textCellType486;
            this.spdDataInfo_Sheet1.Columns.Get(502).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(502).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(502).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(502).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(503).CellType = textCellType487;
            this.spdDataInfo_Sheet1.Columns.Get(503).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(503).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(503).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(503).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(504).CellType = textCellType488;
            this.spdDataInfo_Sheet1.Columns.Get(504).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(504).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(504).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(504).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(505).CellType = textCellType489;
            this.spdDataInfo_Sheet1.Columns.Get(505).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(505).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(505).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(505).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(506).CellType = textCellType490;
            this.spdDataInfo_Sheet1.Columns.Get(506).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(506).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(506).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(506).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(507).CellType = textCellType491;
            this.spdDataInfo_Sheet1.Columns.Get(507).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(507).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(507).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(507).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(508).CellType = textCellType492;
            this.spdDataInfo_Sheet1.Columns.Get(508).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(508).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(508).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(508).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(509).CellType = textCellType493;
            this.spdDataInfo_Sheet1.Columns.Get(509).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(509).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(509).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(509).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(510).CellType = textCellType494;
            this.spdDataInfo_Sheet1.Columns.Get(510).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(510).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(510).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(510).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(511).CellType = textCellType495;
            this.spdDataInfo_Sheet1.Columns.Get(511).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(511).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(511).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(511).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(512).CellType = textCellType496;
            this.spdDataInfo_Sheet1.Columns.Get(512).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(512).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(512).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(512).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(513).CellType = textCellType497;
            this.spdDataInfo_Sheet1.Columns.Get(513).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(513).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(513).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(513).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(514).CellType = textCellType498;
            this.spdDataInfo_Sheet1.Columns.Get(514).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(514).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(514).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(514).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(515).CellType = textCellType499;
            this.spdDataInfo_Sheet1.Columns.Get(515).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(515).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(515).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(515).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(516).CellType = textCellType500;
            this.spdDataInfo_Sheet1.Columns.Get(516).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(516).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(516).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(516).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(517).CellType = textCellType501;
            this.spdDataInfo_Sheet1.Columns.Get(517).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(517).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(517).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(517).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(518).CellType = textCellType502;
            this.spdDataInfo_Sheet1.Columns.Get(518).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(518).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(518).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(518).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(519).CellType = textCellType503;
            this.spdDataInfo_Sheet1.Columns.Get(519).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(519).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(519).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(519).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(520).CellType = textCellType504;
            this.spdDataInfo_Sheet1.Columns.Get(520).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(520).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(520).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(520).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(521).CellType = textCellType505;
            this.spdDataInfo_Sheet1.Columns.Get(521).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(521).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(521).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(521).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(522).CellType = textCellType506;
            this.spdDataInfo_Sheet1.Columns.Get(522).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(522).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(522).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(522).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(523).CellType = textCellType507;
            this.spdDataInfo_Sheet1.Columns.Get(523).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(523).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(523).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(523).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(524).CellType = textCellType508;
            this.spdDataInfo_Sheet1.Columns.Get(524).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(524).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(524).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(524).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(525).CellType = textCellType509;
            this.spdDataInfo_Sheet1.Columns.Get(525).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(525).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(525).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(525).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(526).CellType = textCellType510;
            this.spdDataInfo_Sheet1.Columns.Get(526).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(526).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(526).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(526).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(527).CellType = textCellType511;
            this.spdDataInfo_Sheet1.Columns.Get(527).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(527).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(527).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(527).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(528).CellType = textCellType512;
            this.spdDataInfo_Sheet1.Columns.Get(528).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(528).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(528).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(528).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(529).CellType = textCellType513;
            this.spdDataInfo_Sheet1.Columns.Get(529).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(529).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(529).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(529).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(530).CellType = textCellType514;
            this.spdDataInfo_Sheet1.Columns.Get(530).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(530).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(530).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(530).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(531).CellType = textCellType515;
            this.spdDataInfo_Sheet1.Columns.Get(531).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(531).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(531).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(531).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(532).CellType = textCellType516;
            this.spdDataInfo_Sheet1.Columns.Get(532).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(532).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(532).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(532).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(533).CellType = textCellType517;
            this.spdDataInfo_Sheet1.Columns.Get(533).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(533).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(533).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(533).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(534).CellType = textCellType518;
            this.spdDataInfo_Sheet1.Columns.Get(534).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(534).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(534).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(534).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(535).CellType = textCellType519;
            this.spdDataInfo_Sheet1.Columns.Get(535).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(535).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(535).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(535).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(536).CellType = textCellType520;
            this.spdDataInfo_Sheet1.Columns.Get(536).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(536).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(536).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(536).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(537).CellType = textCellType521;
            this.spdDataInfo_Sheet1.Columns.Get(537).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(537).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(537).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(537).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(538).CellType = textCellType522;
            this.spdDataInfo_Sheet1.Columns.Get(538).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(538).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(538).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(538).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(539).CellType = textCellType523;
            this.spdDataInfo_Sheet1.Columns.Get(539).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(539).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(539).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(539).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(540).CellType = textCellType524;
            this.spdDataInfo_Sheet1.Columns.Get(540).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(540).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(540).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(540).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(541).CellType = textCellType525;
            this.spdDataInfo_Sheet1.Columns.Get(541).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(541).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(541).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(541).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(542).CellType = textCellType526;
            this.spdDataInfo_Sheet1.Columns.Get(542).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(542).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(542).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(542).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(543).CellType = textCellType527;
            this.spdDataInfo_Sheet1.Columns.Get(543).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(543).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(543).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(543).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(544).CellType = textCellType528;
            this.spdDataInfo_Sheet1.Columns.Get(544).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(544).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(544).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(544).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(545).CellType = textCellType529;
            this.spdDataInfo_Sheet1.Columns.Get(545).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(545).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(545).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(545).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(546).CellType = textCellType530;
            this.spdDataInfo_Sheet1.Columns.Get(546).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(546).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(546).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(546).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(547).CellType = textCellType531;
            this.spdDataInfo_Sheet1.Columns.Get(547).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(547).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(547).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(547).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(548).CellType = textCellType532;
            this.spdDataInfo_Sheet1.Columns.Get(548).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(548).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(548).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(548).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(549).CellType = textCellType533;
            this.spdDataInfo_Sheet1.Columns.Get(549).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(549).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(549).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(549).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(550).CellType = textCellType534;
            this.spdDataInfo_Sheet1.Columns.Get(550).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(550).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(550).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(550).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(551).CellType = textCellType535;
            this.spdDataInfo_Sheet1.Columns.Get(551).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(551).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(551).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(551).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(552).CellType = textCellType536;
            this.spdDataInfo_Sheet1.Columns.Get(552).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(552).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(552).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(552).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(553).CellType = textCellType537;
            this.spdDataInfo_Sheet1.Columns.Get(553).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(553).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(553).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(553).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(554).CellType = textCellType538;
            this.spdDataInfo_Sheet1.Columns.Get(554).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(554).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(554).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(554).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(555).CellType = textCellType539;
            this.spdDataInfo_Sheet1.Columns.Get(555).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(555).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(555).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(555).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(556).CellType = textCellType540;
            this.spdDataInfo_Sheet1.Columns.Get(556).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(556).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(556).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(556).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(557).CellType = textCellType541;
            this.spdDataInfo_Sheet1.Columns.Get(557).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(557).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(557).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(557).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(558).CellType = textCellType542;
            this.spdDataInfo_Sheet1.Columns.Get(558).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(558).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(558).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(558).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(559).CellType = textCellType543;
            this.spdDataInfo_Sheet1.Columns.Get(559).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(559).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(559).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(559).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(560).CellType = textCellType544;
            this.spdDataInfo_Sheet1.Columns.Get(560).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(560).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(560).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(560).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(561).CellType = textCellType545;
            this.spdDataInfo_Sheet1.Columns.Get(561).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(561).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(561).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(561).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(562).CellType = textCellType546;
            this.spdDataInfo_Sheet1.Columns.Get(562).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(562).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(562).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(562).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(563).CellType = textCellType547;
            this.spdDataInfo_Sheet1.Columns.Get(563).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(563).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(563).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(563).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(564).CellType = textCellType548;
            this.spdDataInfo_Sheet1.Columns.Get(564).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(564).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(564).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(564).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(565).CellType = textCellType549;
            this.spdDataInfo_Sheet1.Columns.Get(565).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(565).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(565).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(565).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(566).CellType = textCellType550;
            this.spdDataInfo_Sheet1.Columns.Get(566).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(566).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(566).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(566).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(567).CellType = textCellType551;
            this.spdDataInfo_Sheet1.Columns.Get(567).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(567).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(567).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(567).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(568).CellType = textCellType552;
            this.spdDataInfo_Sheet1.Columns.Get(568).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(568).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(568).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(568).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(569).CellType = textCellType553;
            this.spdDataInfo_Sheet1.Columns.Get(569).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(569).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(569).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(569).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(570).CellType = textCellType554;
            this.spdDataInfo_Sheet1.Columns.Get(570).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(570).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(570).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(570).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(571).CellType = textCellType555;
            this.spdDataInfo_Sheet1.Columns.Get(571).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(571).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(571).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(571).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(572).CellType = textCellType556;
            this.spdDataInfo_Sheet1.Columns.Get(572).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(572).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(572).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(572).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(573).CellType = textCellType557;
            this.spdDataInfo_Sheet1.Columns.Get(573).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(573).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(573).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(573).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(574).CellType = textCellType558;
            this.spdDataInfo_Sheet1.Columns.Get(574).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(574).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(574).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(574).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(575).CellType = textCellType559;
            this.spdDataInfo_Sheet1.Columns.Get(575).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(575).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(575).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(575).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(576).CellType = textCellType560;
            this.spdDataInfo_Sheet1.Columns.Get(576).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(576).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(576).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(576).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(577).CellType = textCellType561;
            this.spdDataInfo_Sheet1.Columns.Get(577).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(577).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(577).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(577).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(578).CellType = textCellType562;
            this.spdDataInfo_Sheet1.Columns.Get(578).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(578).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(578).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(578).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(579).CellType = textCellType563;
            this.spdDataInfo_Sheet1.Columns.Get(579).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(579).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(579).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(579).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(580).CellType = textCellType564;
            this.spdDataInfo_Sheet1.Columns.Get(580).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(580).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(580).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(580).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(581).CellType = textCellType565;
            this.spdDataInfo_Sheet1.Columns.Get(581).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(581).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(581).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(581).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(582).CellType = textCellType566;
            this.spdDataInfo_Sheet1.Columns.Get(582).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(582).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(582).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(582).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(583).CellType = textCellType567;
            this.spdDataInfo_Sheet1.Columns.Get(583).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(583).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(583).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(583).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(584).CellType = textCellType568;
            this.spdDataInfo_Sheet1.Columns.Get(584).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(584).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(584).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(584).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(585).CellType = textCellType569;
            this.spdDataInfo_Sheet1.Columns.Get(585).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(585).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(585).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(585).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(586).CellType = textCellType570;
            this.spdDataInfo_Sheet1.Columns.Get(586).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(586).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(586).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(586).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(587).CellType = textCellType571;
            this.spdDataInfo_Sheet1.Columns.Get(587).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(587).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(587).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(587).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(588).CellType = textCellType572;
            this.spdDataInfo_Sheet1.Columns.Get(588).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(588).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(588).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(588).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(589).CellType = textCellType573;
            this.spdDataInfo_Sheet1.Columns.Get(589).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(589).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(589).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(589).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(590).CellType = textCellType574;
            this.spdDataInfo_Sheet1.Columns.Get(590).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(590).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(590).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(590).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(591).CellType = textCellType575;
            this.spdDataInfo_Sheet1.Columns.Get(591).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(591).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(591).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(591).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(592).CellType = textCellType576;
            this.spdDataInfo_Sheet1.Columns.Get(592).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(592).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(592).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(592).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(593).CellType = textCellType577;
            this.spdDataInfo_Sheet1.Columns.Get(593).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(593).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(593).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(593).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(594).CellType = textCellType578;
            this.spdDataInfo_Sheet1.Columns.Get(594).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(594).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(594).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(594).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(595).CellType = textCellType579;
            this.spdDataInfo_Sheet1.Columns.Get(595).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(595).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(595).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(595).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(596).CellType = textCellType580;
            this.spdDataInfo_Sheet1.Columns.Get(596).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(596).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(596).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(596).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(597).CellType = textCellType581;
            this.spdDataInfo_Sheet1.Columns.Get(597).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(597).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(597).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(597).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(598).CellType = textCellType582;
            this.spdDataInfo_Sheet1.Columns.Get(598).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(598).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(598).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(598).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(599).CellType = textCellType583;
            this.spdDataInfo_Sheet1.Columns.Get(599).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(599).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(599).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(599).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(600).CellType = textCellType584;
            this.spdDataInfo_Sheet1.Columns.Get(600).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(600).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(600).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(600).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(601).CellType = textCellType585;
            this.spdDataInfo_Sheet1.Columns.Get(601).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(601).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(601).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(601).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(602).CellType = textCellType586;
            this.spdDataInfo_Sheet1.Columns.Get(602).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(602).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(602).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(602).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(603).CellType = textCellType587;
            this.spdDataInfo_Sheet1.Columns.Get(603).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(603).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(603).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(603).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(604).CellType = textCellType588;
            this.spdDataInfo_Sheet1.Columns.Get(604).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(604).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(604).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(604).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(605).CellType = textCellType589;
            this.spdDataInfo_Sheet1.Columns.Get(605).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(605).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(605).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(605).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(606).CellType = textCellType590;
            this.spdDataInfo_Sheet1.Columns.Get(606).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(606).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(606).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(606).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(607).CellType = textCellType591;
            this.spdDataInfo_Sheet1.Columns.Get(607).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(607).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(607).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(607).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(608).CellType = textCellType592;
            this.spdDataInfo_Sheet1.Columns.Get(608).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(608).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(608).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(608).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(609).CellType = textCellType593;
            this.spdDataInfo_Sheet1.Columns.Get(609).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(609).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(609).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(609).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(610).CellType = textCellType594;
            this.spdDataInfo_Sheet1.Columns.Get(610).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(610).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(610).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(610).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(611).CellType = textCellType595;
            this.spdDataInfo_Sheet1.Columns.Get(611).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(611).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(611).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(611).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(612).CellType = textCellType596;
            this.spdDataInfo_Sheet1.Columns.Get(612).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(612).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(612).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(612).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(613).CellType = textCellType597;
            this.spdDataInfo_Sheet1.Columns.Get(613).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(613).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(613).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(613).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(614).CellType = textCellType598;
            this.spdDataInfo_Sheet1.Columns.Get(614).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(614).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(614).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(614).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(615).CellType = textCellType599;
            this.spdDataInfo_Sheet1.Columns.Get(615).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(615).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(615).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(615).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(616).CellType = textCellType600;
            this.spdDataInfo_Sheet1.Columns.Get(616).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(616).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(616).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(616).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(617).CellType = textCellType601;
            this.spdDataInfo_Sheet1.Columns.Get(617).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(617).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(617).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(617).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(618).CellType = textCellType602;
            this.spdDataInfo_Sheet1.Columns.Get(618).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(618).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(618).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(618).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(619).CellType = textCellType603;
            this.spdDataInfo_Sheet1.Columns.Get(619).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(619).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(619).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(619).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(620).CellType = textCellType604;
            this.spdDataInfo_Sheet1.Columns.Get(620).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(620).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(620).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(620).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(621).CellType = textCellType605;
            this.spdDataInfo_Sheet1.Columns.Get(621).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(621).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(621).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(621).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(622).CellType = textCellType606;
            this.spdDataInfo_Sheet1.Columns.Get(622).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(622).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(622).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(622).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(623).CellType = textCellType607;
            this.spdDataInfo_Sheet1.Columns.Get(623).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(623).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(623).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(623).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(624).CellType = textCellType608;
            this.spdDataInfo_Sheet1.Columns.Get(624).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(624).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(624).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(624).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(625).CellType = textCellType609;
            this.spdDataInfo_Sheet1.Columns.Get(625).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(625).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(625).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(625).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(626).CellType = textCellType610;
            this.spdDataInfo_Sheet1.Columns.Get(626).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(626).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(626).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(626).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(627).CellType = textCellType611;
            this.spdDataInfo_Sheet1.Columns.Get(627).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(627).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(627).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(627).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(628).CellType = textCellType612;
            this.spdDataInfo_Sheet1.Columns.Get(628).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(628).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(628).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(628).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(629).CellType = textCellType613;
            this.spdDataInfo_Sheet1.Columns.Get(629).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(629).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(629).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(629).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(630).CellType = textCellType614;
            this.spdDataInfo_Sheet1.Columns.Get(630).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(630).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(630).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(630).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(631).CellType = textCellType615;
            this.spdDataInfo_Sheet1.Columns.Get(631).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(631).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(631).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(631).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(632).CellType = textCellType616;
            this.spdDataInfo_Sheet1.Columns.Get(632).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(632).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(632).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(632).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(633).CellType = textCellType617;
            this.spdDataInfo_Sheet1.Columns.Get(633).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(633).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(633).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(633).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(634).CellType = textCellType618;
            this.spdDataInfo_Sheet1.Columns.Get(634).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(634).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(634).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(634).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(635).CellType = textCellType619;
            this.spdDataInfo_Sheet1.Columns.Get(635).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(635).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(635).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(635).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(636).CellType = textCellType620;
            this.spdDataInfo_Sheet1.Columns.Get(636).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(636).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(636).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(636).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(637).CellType = textCellType621;
            this.spdDataInfo_Sheet1.Columns.Get(637).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(637).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(637).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(637).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(638).CellType = textCellType622;
            this.spdDataInfo_Sheet1.Columns.Get(638).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(638).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(638).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(638).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(639).CellType = textCellType623;
            this.spdDataInfo_Sheet1.Columns.Get(639).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(639).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(639).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(639).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(640).CellType = textCellType624;
            this.spdDataInfo_Sheet1.Columns.Get(640).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(640).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(640).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(640).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(641).CellType = textCellType625;
            this.spdDataInfo_Sheet1.Columns.Get(641).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(641).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(641).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(641).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(642).CellType = textCellType626;
            this.spdDataInfo_Sheet1.Columns.Get(642).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(642).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(642).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(642).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(643).CellType = textCellType627;
            this.spdDataInfo_Sheet1.Columns.Get(643).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(643).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(643).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(643).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(644).CellType = textCellType628;
            this.spdDataInfo_Sheet1.Columns.Get(644).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(644).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(644).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(644).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(645).CellType = textCellType629;
            this.spdDataInfo_Sheet1.Columns.Get(645).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(645).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(645).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(645).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(646).CellType = textCellType630;
            this.spdDataInfo_Sheet1.Columns.Get(646).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(646).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(646).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(646).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(647).CellType = textCellType631;
            this.spdDataInfo_Sheet1.Columns.Get(647).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(647).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(647).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(647).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(648).CellType = textCellType632;
            this.spdDataInfo_Sheet1.Columns.Get(648).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(648).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(648).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(648).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(649).CellType = textCellType633;
            this.spdDataInfo_Sheet1.Columns.Get(649).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(649).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(649).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(649).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(650).CellType = textCellType634;
            this.spdDataInfo_Sheet1.Columns.Get(650).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(650).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(650).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(650).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(651).CellType = textCellType635;
            this.spdDataInfo_Sheet1.Columns.Get(651).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(651).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(651).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(651).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(652).CellType = textCellType636;
            this.spdDataInfo_Sheet1.Columns.Get(652).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(652).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(652).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(652).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(653).CellType = textCellType637;
            this.spdDataInfo_Sheet1.Columns.Get(653).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(653).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(653).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(653).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(654).CellType = textCellType638;
            this.spdDataInfo_Sheet1.Columns.Get(654).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(654).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(654).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(654).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(655).CellType = textCellType639;
            this.spdDataInfo_Sheet1.Columns.Get(655).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(655).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(655).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(655).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(656).CellType = textCellType640;
            this.spdDataInfo_Sheet1.Columns.Get(656).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(656).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(656).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(656).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(657).CellType = textCellType641;
            this.spdDataInfo_Sheet1.Columns.Get(657).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(657).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(657).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(657).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(658).CellType = textCellType642;
            this.spdDataInfo_Sheet1.Columns.Get(658).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(658).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(658).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(658).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(659).CellType = textCellType643;
            this.spdDataInfo_Sheet1.Columns.Get(659).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(659).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(659).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(659).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(660).CellType = textCellType644;
            this.spdDataInfo_Sheet1.Columns.Get(660).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(660).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(660).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(660).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(661).CellType = textCellType645;
            this.spdDataInfo_Sheet1.Columns.Get(661).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(661).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(661).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(661).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(662).CellType = textCellType646;
            this.spdDataInfo_Sheet1.Columns.Get(662).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(662).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(662).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(662).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(663).CellType = textCellType647;
            this.spdDataInfo_Sheet1.Columns.Get(663).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(663).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(663).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(663).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(664).CellType = textCellType648;
            this.spdDataInfo_Sheet1.Columns.Get(664).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(664).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(664).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(664).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(665).CellType = textCellType649;
            this.spdDataInfo_Sheet1.Columns.Get(665).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(665).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(665).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(665).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(666).CellType = textCellType650;
            this.spdDataInfo_Sheet1.Columns.Get(666).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(666).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(666).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(666).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(667).CellType = textCellType651;
            this.spdDataInfo_Sheet1.Columns.Get(667).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(667).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(667).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(667).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(668).CellType = textCellType652;
            this.spdDataInfo_Sheet1.Columns.Get(668).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(668).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(668).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(668).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(669).CellType = textCellType653;
            this.spdDataInfo_Sheet1.Columns.Get(669).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(669).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(669).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(669).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(670).CellType = textCellType654;
            this.spdDataInfo_Sheet1.Columns.Get(670).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(670).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(670).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(670).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(671).CellType = textCellType655;
            this.spdDataInfo_Sheet1.Columns.Get(671).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(671).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(671).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(671).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(672).CellType = textCellType656;
            this.spdDataInfo_Sheet1.Columns.Get(672).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(672).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(672).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(672).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(673).CellType = textCellType657;
            this.spdDataInfo_Sheet1.Columns.Get(673).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(673).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(673).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(673).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(674).CellType = textCellType658;
            this.spdDataInfo_Sheet1.Columns.Get(674).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(674).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(674).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(674).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(675).CellType = textCellType659;
            this.spdDataInfo_Sheet1.Columns.Get(675).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(675).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(675).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(675).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(676).CellType = textCellType660;
            this.spdDataInfo_Sheet1.Columns.Get(676).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(676).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(676).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(676).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(677).CellType = textCellType661;
            this.spdDataInfo_Sheet1.Columns.Get(677).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(677).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(677).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(677).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(678).CellType = textCellType662;
            this.spdDataInfo_Sheet1.Columns.Get(678).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(678).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(678).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(678).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(679).CellType = textCellType663;
            this.spdDataInfo_Sheet1.Columns.Get(679).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(679).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(679).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(679).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(680).CellType = textCellType664;
            this.spdDataInfo_Sheet1.Columns.Get(680).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(680).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(680).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(680).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(681).CellType = textCellType665;
            this.spdDataInfo_Sheet1.Columns.Get(681).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(681).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(681).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(681).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(682).CellType = textCellType666;
            this.spdDataInfo_Sheet1.Columns.Get(682).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(682).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(682).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(682).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(683).CellType = textCellType667;
            this.spdDataInfo_Sheet1.Columns.Get(683).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(683).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(683).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(683).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(684).CellType = textCellType668;
            this.spdDataInfo_Sheet1.Columns.Get(684).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(684).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(684).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(684).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(685).CellType = textCellType669;
            this.spdDataInfo_Sheet1.Columns.Get(685).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(685).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(685).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(685).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(686).CellType = textCellType670;
            this.spdDataInfo_Sheet1.Columns.Get(686).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(686).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(686).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(686).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(687).CellType = textCellType671;
            this.spdDataInfo_Sheet1.Columns.Get(687).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(687).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(687).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(687).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(688).CellType = textCellType672;
            this.spdDataInfo_Sheet1.Columns.Get(688).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(688).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(688).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(688).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(689).CellType = textCellType673;
            this.spdDataInfo_Sheet1.Columns.Get(689).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(689).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(689).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(689).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(690).CellType = textCellType674;
            this.spdDataInfo_Sheet1.Columns.Get(690).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(690).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(690).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(690).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(691).CellType = textCellType675;
            this.spdDataInfo_Sheet1.Columns.Get(691).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(691).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(691).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(691).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(692).CellType = textCellType676;
            this.spdDataInfo_Sheet1.Columns.Get(692).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(692).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(692).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(692).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(693).CellType = textCellType677;
            this.spdDataInfo_Sheet1.Columns.Get(693).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(693).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(693).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(693).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(694).CellType = textCellType678;
            this.spdDataInfo_Sheet1.Columns.Get(694).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(694).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(694).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(694).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(695).CellType = textCellType679;
            this.spdDataInfo_Sheet1.Columns.Get(695).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(695).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(695).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(695).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(696).CellType = textCellType680;
            this.spdDataInfo_Sheet1.Columns.Get(696).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(696).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(696).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(696).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(697).CellType = textCellType681;
            this.spdDataInfo_Sheet1.Columns.Get(697).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(697).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(697).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(697).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(698).CellType = textCellType682;
            this.spdDataInfo_Sheet1.Columns.Get(698).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(698).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(698).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(698).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(699).CellType = textCellType683;
            this.spdDataInfo_Sheet1.Columns.Get(699).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(699).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(699).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(699).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(700).CellType = textCellType684;
            this.spdDataInfo_Sheet1.Columns.Get(700).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(700).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(700).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(700).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(701).CellType = textCellType685;
            this.spdDataInfo_Sheet1.Columns.Get(701).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(701).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(701).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(701).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(702).CellType = textCellType686;
            this.spdDataInfo_Sheet1.Columns.Get(702).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(702).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(702).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(702).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(703).CellType = textCellType687;
            this.spdDataInfo_Sheet1.Columns.Get(703).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(703).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(703).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(703).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(704).CellType = textCellType688;
            this.spdDataInfo_Sheet1.Columns.Get(704).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(704).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(704).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(704).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(705).CellType = textCellType689;
            this.spdDataInfo_Sheet1.Columns.Get(705).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(705).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(705).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(705).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(706).CellType = textCellType690;
            this.spdDataInfo_Sheet1.Columns.Get(706).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(706).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(706).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(706).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(707).CellType = textCellType691;
            this.spdDataInfo_Sheet1.Columns.Get(707).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(707).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(707).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(707).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(708).CellType = textCellType692;
            this.spdDataInfo_Sheet1.Columns.Get(708).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(708).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(708).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(708).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(709).CellType = textCellType693;
            this.spdDataInfo_Sheet1.Columns.Get(709).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(709).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(709).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(709).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(710).CellType = textCellType694;
            this.spdDataInfo_Sheet1.Columns.Get(710).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(710).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(710).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(710).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(711).CellType = textCellType695;
            this.spdDataInfo_Sheet1.Columns.Get(711).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(711).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(711).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(711).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(712).CellType = textCellType696;
            this.spdDataInfo_Sheet1.Columns.Get(712).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(712).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(712).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(712).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(713).CellType = textCellType697;
            this.spdDataInfo_Sheet1.Columns.Get(713).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(713).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(713).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(713).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(714).CellType = textCellType698;
            this.spdDataInfo_Sheet1.Columns.Get(714).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(714).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(714).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(714).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(715).CellType = textCellType699;
            this.spdDataInfo_Sheet1.Columns.Get(715).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(715).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(715).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(715).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(716).CellType = textCellType700;
            this.spdDataInfo_Sheet1.Columns.Get(716).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(716).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(716).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(716).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(717).CellType = textCellType701;
            this.spdDataInfo_Sheet1.Columns.Get(717).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(717).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(717).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(717).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(718).CellType = textCellType702;
            this.spdDataInfo_Sheet1.Columns.Get(718).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(718).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(718).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(718).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(719).CellType = textCellType703;
            this.spdDataInfo_Sheet1.Columns.Get(719).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(719).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(719).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(719).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(720).CellType = textCellType704;
            this.spdDataInfo_Sheet1.Columns.Get(720).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(720).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(720).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(720).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(721).CellType = textCellType705;
            this.spdDataInfo_Sheet1.Columns.Get(721).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(721).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(721).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(721).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(722).CellType = textCellType706;
            this.spdDataInfo_Sheet1.Columns.Get(722).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(722).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(722).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(722).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(723).CellType = textCellType707;
            this.spdDataInfo_Sheet1.Columns.Get(723).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(723).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(723).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(723).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(724).CellType = textCellType708;
            this.spdDataInfo_Sheet1.Columns.Get(724).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(724).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(724).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(724).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(725).CellType = textCellType709;
            this.spdDataInfo_Sheet1.Columns.Get(725).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(725).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(725).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(725).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(726).CellType = textCellType710;
            this.spdDataInfo_Sheet1.Columns.Get(726).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(726).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(726).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(726).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(727).CellType = textCellType711;
            this.spdDataInfo_Sheet1.Columns.Get(727).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(727).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(727).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(727).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(728).CellType = textCellType712;
            this.spdDataInfo_Sheet1.Columns.Get(728).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(728).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(728).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(728).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(729).CellType = textCellType713;
            this.spdDataInfo_Sheet1.Columns.Get(729).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(729).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(729).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(729).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(730).CellType = textCellType714;
            this.spdDataInfo_Sheet1.Columns.Get(730).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(730).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(730).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(730).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(731).CellType = textCellType715;
            this.spdDataInfo_Sheet1.Columns.Get(731).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(731).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(731).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(731).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(732).CellType = textCellType716;
            this.spdDataInfo_Sheet1.Columns.Get(732).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(732).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(732).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(732).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(733).CellType = textCellType717;
            this.spdDataInfo_Sheet1.Columns.Get(733).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(733).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(733).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(733).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(734).CellType = textCellType718;
            this.spdDataInfo_Sheet1.Columns.Get(734).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(734).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(734).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(734).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(735).CellType = textCellType719;
            this.spdDataInfo_Sheet1.Columns.Get(735).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(735).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(735).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(735).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(736).CellType = textCellType720;
            this.spdDataInfo_Sheet1.Columns.Get(736).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(736).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(736).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(736).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(737).CellType = textCellType721;
            this.spdDataInfo_Sheet1.Columns.Get(737).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(737).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(737).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(737).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(738).CellType = textCellType722;
            this.spdDataInfo_Sheet1.Columns.Get(738).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(738).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(738).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(738).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(739).CellType = textCellType723;
            this.spdDataInfo_Sheet1.Columns.Get(739).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(739).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(739).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(739).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(740).CellType = textCellType724;
            this.spdDataInfo_Sheet1.Columns.Get(740).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(740).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(740).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(740).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(741).CellType = textCellType725;
            this.spdDataInfo_Sheet1.Columns.Get(741).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(741).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(741).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(741).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(742).CellType = textCellType726;
            this.spdDataInfo_Sheet1.Columns.Get(742).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(742).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(742).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(742).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(743).CellType = textCellType727;
            this.spdDataInfo_Sheet1.Columns.Get(743).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(743).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(743).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(743).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(744).CellType = textCellType728;
            this.spdDataInfo_Sheet1.Columns.Get(744).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(744).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(744).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(744).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(745).CellType = textCellType729;
            this.spdDataInfo_Sheet1.Columns.Get(745).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(745).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(745).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(745).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(746).CellType = textCellType730;
            this.spdDataInfo_Sheet1.Columns.Get(746).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(746).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(746).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(746).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(747).CellType = textCellType731;
            this.spdDataInfo_Sheet1.Columns.Get(747).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(747).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(747).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(747).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(748).CellType = textCellType732;
            this.spdDataInfo_Sheet1.Columns.Get(748).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(748).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(748).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(748).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(749).CellType = textCellType733;
            this.spdDataInfo_Sheet1.Columns.Get(749).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(749).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(749).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(749).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(750).CellType = textCellType734;
            this.spdDataInfo_Sheet1.Columns.Get(750).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(750).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(750).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(750).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(751).CellType = textCellType735;
            this.spdDataInfo_Sheet1.Columns.Get(751).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(751).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(751).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(751).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(752).CellType = textCellType736;
            this.spdDataInfo_Sheet1.Columns.Get(752).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(752).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(752).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(752).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(753).CellType = textCellType737;
            this.spdDataInfo_Sheet1.Columns.Get(753).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(753).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(753).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(753).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(754).CellType = textCellType738;
            this.spdDataInfo_Sheet1.Columns.Get(754).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(754).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(754).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(754).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(755).CellType = textCellType739;
            this.spdDataInfo_Sheet1.Columns.Get(755).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(755).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(755).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(755).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(756).CellType = textCellType740;
            this.spdDataInfo_Sheet1.Columns.Get(756).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(756).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(756).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(756).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(757).CellType = textCellType741;
            this.spdDataInfo_Sheet1.Columns.Get(757).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(757).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(757).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(757).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(758).CellType = textCellType742;
            this.spdDataInfo_Sheet1.Columns.Get(758).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(758).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(758).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(758).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(759).CellType = textCellType743;
            this.spdDataInfo_Sheet1.Columns.Get(759).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(759).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(759).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(759).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(760).CellType = textCellType744;
            this.spdDataInfo_Sheet1.Columns.Get(760).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(760).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(760).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(760).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(761).CellType = textCellType745;
            this.spdDataInfo_Sheet1.Columns.Get(761).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(761).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(761).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(761).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(762).CellType = textCellType746;
            this.spdDataInfo_Sheet1.Columns.Get(762).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(762).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(762).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(762).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(763).CellType = textCellType747;
            this.spdDataInfo_Sheet1.Columns.Get(763).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(763).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(763).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(763).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(764).CellType = textCellType748;
            this.spdDataInfo_Sheet1.Columns.Get(764).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(764).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(764).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(764).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(765).CellType = textCellType749;
            this.spdDataInfo_Sheet1.Columns.Get(765).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(765).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(765).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(765).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(766).CellType = textCellType750;
            this.spdDataInfo_Sheet1.Columns.Get(766).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(766).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(766).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(766).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(767).CellType = textCellType751;
            this.spdDataInfo_Sheet1.Columns.Get(767).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(767).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(767).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(767).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(768).CellType = textCellType752;
            this.spdDataInfo_Sheet1.Columns.Get(768).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(768).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(768).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(768).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(769).CellType = textCellType753;
            this.spdDataInfo_Sheet1.Columns.Get(769).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(769).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(769).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(769).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(770).CellType = textCellType754;
            this.spdDataInfo_Sheet1.Columns.Get(770).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(770).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(770).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(770).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(771).CellType = textCellType755;
            this.spdDataInfo_Sheet1.Columns.Get(771).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(771).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(771).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(771).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(772).CellType = textCellType756;
            this.spdDataInfo_Sheet1.Columns.Get(772).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(772).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(772).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(772).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(773).CellType = textCellType757;
            this.spdDataInfo_Sheet1.Columns.Get(773).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(773).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(773).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(773).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(774).CellType = textCellType758;
            this.spdDataInfo_Sheet1.Columns.Get(774).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(774).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(774).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(774).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(775).CellType = textCellType759;
            this.spdDataInfo_Sheet1.Columns.Get(775).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(775).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(775).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(775).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(776).CellType = textCellType760;
            this.spdDataInfo_Sheet1.Columns.Get(776).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(776).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(776).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(776).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(777).CellType = textCellType761;
            this.spdDataInfo_Sheet1.Columns.Get(777).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(777).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(777).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(777).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(778).CellType = textCellType762;
            this.spdDataInfo_Sheet1.Columns.Get(778).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(778).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(778).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(778).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(779).CellType = textCellType763;
            this.spdDataInfo_Sheet1.Columns.Get(779).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(779).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(779).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(779).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(780).CellType = textCellType764;
            this.spdDataInfo_Sheet1.Columns.Get(780).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(780).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(780).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(780).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(781).CellType = textCellType765;
            this.spdDataInfo_Sheet1.Columns.Get(781).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(781).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(781).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(781).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(782).CellType = textCellType766;
            this.spdDataInfo_Sheet1.Columns.Get(782).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(782).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(782).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(782).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(783).CellType = textCellType767;
            this.spdDataInfo_Sheet1.Columns.Get(783).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(783).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(783).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(783).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(784).CellType = textCellType768;
            this.spdDataInfo_Sheet1.Columns.Get(784).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(784).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(784).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(784).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(785).CellType = textCellType769;
            this.spdDataInfo_Sheet1.Columns.Get(785).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(785).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(785).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(785).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(786).CellType = textCellType770;
            this.spdDataInfo_Sheet1.Columns.Get(786).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(786).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(786).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(786).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(787).CellType = textCellType771;
            this.spdDataInfo_Sheet1.Columns.Get(787).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(787).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(787).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(787).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(788).CellType = textCellType772;
            this.spdDataInfo_Sheet1.Columns.Get(788).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(788).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(788).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(788).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(789).CellType = textCellType773;
            this.spdDataInfo_Sheet1.Columns.Get(789).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(789).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(789).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(789).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(790).CellType = textCellType774;
            this.spdDataInfo_Sheet1.Columns.Get(790).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(790).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(790).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(790).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(791).CellType = textCellType775;
            this.spdDataInfo_Sheet1.Columns.Get(791).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(791).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(791).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(791).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(792).CellType = textCellType776;
            this.spdDataInfo_Sheet1.Columns.Get(792).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(792).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(792).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(792).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(793).CellType = textCellType777;
            this.spdDataInfo_Sheet1.Columns.Get(793).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(793).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(793).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(793).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(794).CellType = textCellType778;
            this.spdDataInfo_Sheet1.Columns.Get(794).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(794).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(794).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(794).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(795).CellType = textCellType779;
            this.spdDataInfo_Sheet1.Columns.Get(795).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(795).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(795).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(795).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(796).CellType = textCellType780;
            this.spdDataInfo_Sheet1.Columns.Get(796).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(796).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(796).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(796).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(797).CellType = textCellType781;
            this.spdDataInfo_Sheet1.Columns.Get(797).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(797).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(797).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(797).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(798).CellType = textCellType782;
            this.spdDataInfo_Sheet1.Columns.Get(798).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(798).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(798).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(798).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(799).CellType = textCellType783;
            this.spdDataInfo_Sheet1.Columns.Get(799).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(799).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(799).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(799).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(800).CellType = textCellType784;
            this.spdDataInfo_Sheet1.Columns.Get(800).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(800).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(800).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(800).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(801).CellType = textCellType785;
            this.spdDataInfo_Sheet1.Columns.Get(801).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(801).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(801).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(801).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(802).CellType = textCellType786;
            this.spdDataInfo_Sheet1.Columns.Get(802).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(802).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(802).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(802).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(803).CellType = textCellType787;
            this.spdDataInfo_Sheet1.Columns.Get(803).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(803).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(803).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(803).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(804).CellType = textCellType788;
            this.spdDataInfo_Sheet1.Columns.Get(804).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(804).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(804).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(804).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(805).CellType = textCellType789;
            this.spdDataInfo_Sheet1.Columns.Get(805).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(805).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(805).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(805).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(806).CellType = textCellType790;
            this.spdDataInfo_Sheet1.Columns.Get(806).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(806).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(806).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(806).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(807).CellType = textCellType791;
            this.spdDataInfo_Sheet1.Columns.Get(807).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(807).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(807).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(807).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(808).CellType = textCellType792;
            this.spdDataInfo_Sheet1.Columns.Get(808).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(808).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(808).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(808).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(809).CellType = textCellType793;
            this.spdDataInfo_Sheet1.Columns.Get(809).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(809).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(809).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(809).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(810).CellType = textCellType794;
            this.spdDataInfo_Sheet1.Columns.Get(810).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(810).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(810).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(810).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(811).CellType = textCellType795;
            this.spdDataInfo_Sheet1.Columns.Get(811).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(811).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(811).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(811).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(812).CellType = textCellType796;
            this.spdDataInfo_Sheet1.Columns.Get(812).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(812).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(812).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(812).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(813).CellType = textCellType797;
            this.spdDataInfo_Sheet1.Columns.Get(813).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(813).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(813).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(813).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(814).CellType = textCellType798;
            this.spdDataInfo_Sheet1.Columns.Get(814).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(814).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(814).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(814).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(815).CellType = textCellType799;
            this.spdDataInfo_Sheet1.Columns.Get(815).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(815).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(815).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(815).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(816).CellType = textCellType800;
            this.spdDataInfo_Sheet1.Columns.Get(816).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(816).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(816).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(816).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(817).CellType = textCellType801;
            this.spdDataInfo_Sheet1.Columns.Get(817).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(817).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(817).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(817).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(818).CellType = textCellType802;
            this.spdDataInfo_Sheet1.Columns.Get(818).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(818).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(818).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(818).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(819).CellType = textCellType803;
            this.spdDataInfo_Sheet1.Columns.Get(819).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(819).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(819).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(819).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(820).CellType = textCellType804;
            this.spdDataInfo_Sheet1.Columns.Get(820).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(820).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(820).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(820).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(821).CellType = textCellType805;
            this.spdDataInfo_Sheet1.Columns.Get(821).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(821).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(821).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(821).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(822).CellType = textCellType806;
            this.spdDataInfo_Sheet1.Columns.Get(822).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(822).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(822).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(822).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(823).CellType = textCellType807;
            this.spdDataInfo_Sheet1.Columns.Get(823).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(823).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(823).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(823).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(824).CellType = textCellType808;
            this.spdDataInfo_Sheet1.Columns.Get(824).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(824).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(824).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(824).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(825).CellType = textCellType809;
            this.spdDataInfo_Sheet1.Columns.Get(825).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(825).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(825).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(825).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(826).CellType = textCellType810;
            this.spdDataInfo_Sheet1.Columns.Get(826).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(826).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(826).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(826).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(827).CellType = textCellType811;
            this.spdDataInfo_Sheet1.Columns.Get(827).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(827).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(827).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(827).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(828).CellType = textCellType812;
            this.spdDataInfo_Sheet1.Columns.Get(828).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(828).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(828).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(828).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(829).CellType = textCellType813;
            this.spdDataInfo_Sheet1.Columns.Get(829).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(829).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(829).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(829).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(830).CellType = textCellType814;
            this.spdDataInfo_Sheet1.Columns.Get(830).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(830).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(830).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(830).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(831).CellType = textCellType815;
            this.spdDataInfo_Sheet1.Columns.Get(831).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(831).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(831).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(831).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(832).CellType = textCellType816;
            this.spdDataInfo_Sheet1.Columns.Get(832).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(832).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(832).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(832).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(833).CellType = textCellType817;
            this.spdDataInfo_Sheet1.Columns.Get(833).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(833).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(833).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(833).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(834).CellType = textCellType818;
            this.spdDataInfo_Sheet1.Columns.Get(834).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(834).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(834).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(834).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(835).CellType = textCellType819;
            this.spdDataInfo_Sheet1.Columns.Get(835).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(835).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(835).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(835).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(836).CellType = textCellType820;
            this.spdDataInfo_Sheet1.Columns.Get(836).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(836).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(836).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(836).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(837).CellType = textCellType821;
            this.spdDataInfo_Sheet1.Columns.Get(837).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(837).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(837).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(837).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(838).CellType = textCellType822;
            this.spdDataInfo_Sheet1.Columns.Get(838).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(838).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(838).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(838).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(839).CellType = textCellType823;
            this.spdDataInfo_Sheet1.Columns.Get(839).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(839).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(839).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(839).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(840).CellType = textCellType824;
            this.spdDataInfo_Sheet1.Columns.Get(840).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(840).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(840).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(840).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(841).CellType = textCellType825;
            this.spdDataInfo_Sheet1.Columns.Get(841).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(841).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(841).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(841).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(842).CellType = textCellType826;
            this.spdDataInfo_Sheet1.Columns.Get(842).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(842).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(842).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(842).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(843).CellType = textCellType827;
            this.spdDataInfo_Sheet1.Columns.Get(843).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(843).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(843).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(843).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(844).CellType = textCellType828;
            this.spdDataInfo_Sheet1.Columns.Get(844).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(844).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(844).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(844).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(845).CellType = textCellType829;
            this.spdDataInfo_Sheet1.Columns.Get(845).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(845).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(845).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(845).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(846).CellType = textCellType830;
            this.spdDataInfo_Sheet1.Columns.Get(846).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(846).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(846).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(846).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(847).CellType = textCellType831;
            this.spdDataInfo_Sheet1.Columns.Get(847).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(847).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(847).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(847).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(848).CellType = textCellType832;
            this.spdDataInfo_Sheet1.Columns.Get(848).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(848).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(848).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(848).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(849).CellType = textCellType833;
            this.spdDataInfo_Sheet1.Columns.Get(849).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(849).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(849).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(849).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(850).CellType = textCellType834;
            this.spdDataInfo_Sheet1.Columns.Get(850).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(850).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(850).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(850).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(851).CellType = textCellType835;
            this.spdDataInfo_Sheet1.Columns.Get(851).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(851).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(851).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(851).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(852).CellType = textCellType836;
            this.spdDataInfo_Sheet1.Columns.Get(852).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(852).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(852).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(852).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(853).CellType = textCellType837;
            this.spdDataInfo_Sheet1.Columns.Get(853).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(853).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(853).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(853).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(854).CellType = textCellType838;
            this.spdDataInfo_Sheet1.Columns.Get(854).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(854).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(854).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(854).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(855).CellType = textCellType839;
            this.spdDataInfo_Sheet1.Columns.Get(855).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(855).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(855).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(855).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(856).CellType = textCellType840;
            this.spdDataInfo_Sheet1.Columns.Get(856).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(856).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(856).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(856).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(857).CellType = textCellType841;
            this.spdDataInfo_Sheet1.Columns.Get(857).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(857).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(857).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(857).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(858).CellType = textCellType842;
            this.spdDataInfo_Sheet1.Columns.Get(858).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(858).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(858).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(858).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(859).CellType = textCellType843;
            this.spdDataInfo_Sheet1.Columns.Get(859).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(859).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(859).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(859).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(860).CellType = textCellType844;
            this.spdDataInfo_Sheet1.Columns.Get(860).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(860).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(860).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(860).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(861).CellType = textCellType845;
            this.spdDataInfo_Sheet1.Columns.Get(861).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(861).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(861).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(861).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(862).CellType = textCellType846;
            this.spdDataInfo_Sheet1.Columns.Get(862).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(862).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(862).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(862).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(863).CellType = textCellType847;
            this.spdDataInfo_Sheet1.Columns.Get(863).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(863).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(863).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(863).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(864).CellType = textCellType848;
            this.spdDataInfo_Sheet1.Columns.Get(864).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(864).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(864).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(864).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(865).CellType = textCellType849;
            this.spdDataInfo_Sheet1.Columns.Get(865).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(865).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(865).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(865).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(866).CellType = textCellType850;
            this.spdDataInfo_Sheet1.Columns.Get(866).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(866).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(866).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(866).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(867).CellType = textCellType851;
            this.spdDataInfo_Sheet1.Columns.Get(867).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(867).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(867).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(867).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(868).CellType = textCellType852;
            this.spdDataInfo_Sheet1.Columns.Get(868).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(868).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(868).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(868).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(869).CellType = textCellType853;
            this.spdDataInfo_Sheet1.Columns.Get(869).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(869).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(869).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(869).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(870).CellType = textCellType854;
            this.spdDataInfo_Sheet1.Columns.Get(870).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(870).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(870).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(870).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(871).CellType = textCellType855;
            this.spdDataInfo_Sheet1.Columns.Get(871).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(871).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(871).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(871).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(872).CellType = textCellType856;
            this.spdDataInfo_Sheet1.Columns.Get(872).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(872).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(872).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(872).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(873).CellType = textCellType857;
            this.spdDataInfo_Sheet1.Columns.Get(873).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(873).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(873).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(873).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(874).CellType = textCellType858;
            this.spdDataInfo_Sheet1.Columns.Get(874).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(874).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(874).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(874).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(875).CellType = textCellType859;
            this.spdDataInfo_Sheet1.Columns.Get(875).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(875).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(875).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(875).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(876).CellType = textCellType860;
            this.spdDataInfo_Sheet1.Columns.Get(876).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(876).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(876).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(876).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(877).CellType = textCellType861;
            this.spdDataInfo_Sheet1.Columns.Get(877).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(877).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(877).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(877).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(878).CellType = textCellType862;
            this.spdDataInfo_Sheet1.Columns.Get(878).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(878).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(878).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(878).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(879).CellType = textCellType863;
            this.spdDataInfo_Sheet1.Columns.Get(879).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(879).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(879).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(879).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(880).CellType = textCellType864;
            this.spdDataInfo_Sheet1.Columns.Get(880).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(880).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(880).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(880).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(881).CellType = textCellType865;
            this.spdDataInfo_Sheet1.Columns.Get(881).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(881).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(881).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(881).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(882).CellType = textCellType866;
            this.spdDataInfo_Sheet1.Columns.Get(882).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(882).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(882).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(882).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(883).CellType = textCellType867;
            this.spdDataInfo_Sheet1.Columns.Get(883).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(883).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(883).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(883).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(884).CellType = textCellType868;
            this.spdDataInfo_Sheet1.Columns.Get(884).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(884).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(884).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(884).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(885).CellType = textCellType869;
            this.spdDataInfo_Sheet1.Columns.Get(885).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(885).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(885).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(885).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(886).CellType = textCellType870;
            this.spdDataInfo_Sheet1.Columns.Get(886).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(886).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(886).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(886).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(887).CellType = textCellType871;
            this.spdDataInfo_Sheet1.Columns.Get(887).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(887).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(887).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(887).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(888).CellType = textCellType872;
            this.spdDataInfo_Sheet1.Columns.Get(888).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(888).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(888).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(888).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(889).CellType = textCellType873;
            this.spdDataInfo_Sheet1.Columns.Get(889).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(889).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(889).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(889).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(890).CellType = textCellType874;
            this.spdDataInfo_Sheet1.Columns.Get(890).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(890).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(890).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(890).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(891).CellType = textCellType875;
            this.spdDataInfo_Sheet1.Columns.Get(891).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(891).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(891).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(891).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(892).CellType = textCellType876;
            this.spdDataInfo_Sheet1.Columns.Get(892).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(892).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(892).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(892).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(893).CellType = textCellType877;
            this.spdDataInfo_Sheet1.Columns.Get(893).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(893).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(893).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(893).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(894).CellType = textCellType878;
            this.spdDataInfo_Sheet1.Columns.Get(894).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(894).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(894).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(894).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(895).CellType = textCellType879;
            this.spdDataInfo_Sheet1.Columns.Get(895).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(895).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(895).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(895).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(896).CellType = textCellType880;
            this.spdDataInfo_Sheet1.Columns.Get(896).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(896).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(896).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(896).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(897).CellType = textCellType881;
            this.spdDataInfo_Sheet1.Columns.Get(897).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(897).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(897).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(897).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(898).CellType = textCellType882;
            this.spdDataInfo_Sheet1.Columns.Get(898).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(898).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(898).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(898).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(899).CellType = textCellType883;
            this.spdDataInfo_Sheet1.Columns.Get(899).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(899).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(899).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(899).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(900).CellType = textCellType884;
            this.spdDataInfo_Sheet1.Columns.Get(900).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(900).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(900).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(900).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(901).CellType = textCellType885;
            this.spdDataInfo_Sheet1.Columns.Get(901).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(901).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(901).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(901).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(902).CellType = textCellType886;
            this.spdDataInfo_Sheet1.Columns.Get(902).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(902).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(902).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(902).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(903).CellType = textCellType887;
            this.spdDataInfo_Sheet1.Columns.Get(903).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(903).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(903).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(903).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(904).CellType = textCellType888;
            this.spdDataInfo_Sheet1.Columns.Get(904).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(904).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(904).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(904).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(905).CellType = textCellType889;
            this.spdDataInfo_Sheet1.Columns.Get(905).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(905).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(905).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(905).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(906).CellType = textCellType890;
            this.spdDataInfo_Sheet1.Columns.Get(906).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(906).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(906).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(906).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(907).CellType = textCellType891;
            this.spdDataInfo_Sheet1.Columns.Get(907).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(907).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(907).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(907).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(908).CellType = textCellType892;
            this.spdDataInfo_Sheet1.Columns.Get(908).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(908).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(908).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(908).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(909).CellType = textCellType893;
            this.spdDataInfo_Sheet1.Columns.Get(909).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(909).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(909).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(909).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(910).CellType = textCellType894;
            this.spdDataInfo_Sheet1.Columns.Get(910).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(910).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(910).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(910).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(911).CellType = textCellType895;
            this.spdDataInfo_Sheet1.Columns.Get(911).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(911).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(911).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(911).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(912).CellType = textCellType896;
            this.spdDataInfo_Sheet1.Columns.Get(912).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(912).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(912).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(912).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(913).CellType = textCellType897;
            this.spdDataInfo_Sheet1.Columns.Get(913).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(913).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(913).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(913).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(914).CellType = textCellType898;
            this.spdDataInfo_Sheet1.Columns.Get(914).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(914).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(914).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(914).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(915).CellType = textCellType899;
            this.spdDataInfo_Sheet1.Columns.Get(915).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(915).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(915).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(915).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(916).CellType = textCellType900;
            this.spdDataInfo_Sheet1.Columns.Get(916).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(916).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(916).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(916).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(917).CellType = textCellType901;
            this.spdDataInfo_Sheet1.Columns.Get(917).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(917).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(917).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(917).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(918).CellType = textCellType902;
            this.spdDataInfo_Sheet1.Columns.Get(918).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(918).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(918).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(918).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(919).CellType = textCellType903;
            this.spdDataInfo_Sheet1.Columns.Get(919).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(919).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(919).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(919).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(920).CellType = textCellType904;
            this.spdDataInfo_Sheet1.Columns.Get(920).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(920).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(920).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(920).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(921).CellType = textCellType905;
            this.spdDataInfo_Sheet1.Columns.Get(921).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(921).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(921).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(921).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(922).CellType = textCellType906;
            this.spdDataInfo_Sheet1.Columns.Get(922).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(922).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(922).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(922).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(923).CellType = textCellType907;
            this.spdDataInfo_Sheet1.Columns.Get(923).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(923).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(923).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(923).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(924).CellType = textCellType908;
            this.spdDataInfo_Sheet1.Columns.Get(924).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(924).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(924).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(924).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(925).CellType = textCellType909;
            this.spdDataInfo_Sheet1.Columns.Get(925).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(925).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(925).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(925).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(926).CellType = textCellType910;
            this.spdDataInfo_Sheet1.Columns.Get(926).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(926).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(926).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(926).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(927).CellType = textCellType911;
            this.spdDataInfo_Sheet1.Columns.Get(927).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(927).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(927).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(927).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(928).CellType = textCellType912;
            this.spdDataInfo_Sheet1.Columns.Get(928).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(928).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(928).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(928).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(929).CellType = textCellType913;
            this.spdDataInfo_Sheet1.Columns.Get(929).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(929).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(929).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(929).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(930).CellType = textCellType914;
            this.spdDataInfo_Sheet1.Columns.Get(930).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(930).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(930).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(930).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(931).CellType = textCellType915;
            this.spdDataInfo_Sheet1.Columns.Get(931).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(931).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(931).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(931).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(932).CellType = textCellType916;
            this.spdDataInfo_Sheet1.Columns.Get(932).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(932).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(932).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(932).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(933).CellType = textCellType917;
            this.spdDataInfo_Sheet1.Columns.Get(933).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(933).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(933).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(933).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(934).CellType = textCellType918;
            this.spdDataInfo_Sheet1.Columns.Get(934).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(934).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(934).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(934).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(935).CellType = textCellType919;
            this.spdDataInfo_Sheet1.Columns.Get(935).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(935).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(935).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(935).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(936).CellType = textCellType920;
            this.spdDataInfo_Sheet1.Columns.Get(936).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(936).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(936).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(936).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(937).CellType = textCellType921;
            this.spdDataInfo_Sheet1.Columns.Get(937).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(937).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(937).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(937).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(938).CellType = textCellType922;
            this.spdDataInfo_Sheet1.Columns.Get(938).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(938).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(938).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(938).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(939).CellType = textCellType923;
            this.spdDataInfo_Sheet1.Columns.Get(939).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(939).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(939).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(939).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(940).CellType = textCellType924;
            this.spdDataInfo_Sheet1.Columns.Get(940).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(940).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(940).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(940).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(941).CellType = textCellType925;
            this.spdDataInfo_Sheet1.Columns.Get(941).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(941).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(941).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(941).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(942).CellType = textCellType926;
            this.spdDataInfo_Sheet1.Columns.Get(942).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(942).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(942).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(942).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(943).CellType = textCellType927;
            this.spdDataInfo_Sheet1.Columns.Get(943).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(943).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(943).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(943).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(944).CellType = textCellType928;
            this.spdDataInfo_Sheet1.Columns.Get(944).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(944).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(944).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(944).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(945).CellType = textCellType929;
            this.spdDataInfo_Sheet1.Columns.Get(945).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(945).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(945).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(945).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(946).CellType = textCellType930;
            this.spdDataInfo_Sheet1.Columns.Get(946).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(946).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(946).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(946).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(947).CellType = textCellType931;
            this.spdDataInfo_Sheet1.Columns.Get(947).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(947).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(947).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(947).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(948).CellType = textCellType932;
            this.spdDataInfo_Sheet1.Columns.Get(948).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(948).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(948).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(948).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(949).CellType = textCellType933;
            this.spdDataInfo_Sheet1.Columns.Get(949).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(949).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(949).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(949).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(950).CellType = textCellType934;
            this.spdDataInfo_Sheet1.Columns.Get(950).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(950).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(950).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(950).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(951).CellType = textCellType935;
            this.spdDataInfo_Sheet1.Columns.Get(951).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(951).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(951).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(951).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(952).CellType = textCellType936;
            this.spdDataInfo_Sheet1.Columns.Get(952).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(952).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(952).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(952).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(953).CellType = textCellType937;
            this.spdDataInfo_Sheet1.Columns.Get(953).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(953).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(953).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(953).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(954).CellType = textCellType938;
            this.spdDataInfo_Sheet1.Columns.Get(954).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(954).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(954).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(954).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(955).CellType = textCellType939;
            this.spdDataInfo_Sheet1.Columns.Get(955).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(955).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(955).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(955).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(956).CellType = textCellType940;
            this.spdDataInfo_Sheet1.Columns.Get(956).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(956).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(956).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(956).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(957).CellType = textCellType941;
            this.spdDataInfo_Sheet1.Columns.Get(957).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(957).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(957).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(957).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(958).CellType = textCellType942;
            this.spdDataInfo_Sheet1.Columns.Get(958).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(958).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(958).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(958).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(959).CellType = textCellType943;
            this.spdDataInfo_Sheet1.Columns.Get(959).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(959).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(959).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(959).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(960).CellType = textCellType944;
            this.spdDataInfo_Sheet1.Columns.Get(960).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(960).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(960).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(960).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(961).CellType = textCellType945;
            this.spdDataInfo_Sheet1.Columns.Get(961).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(961).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(961).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(961).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(962).CellType = textCellType946;
            this.spdDataInfo_Sheet1.Columns.Get(962).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(962).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(962).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(962).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(963).CellType = textCellType947;
            this.spdDataInfo_Sheet1.Columns.Get(963).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(963).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(963).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(963).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(964).CellType = textCellType948;
            this.spdDataInfo_Sheet1.Columns.Get(964).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(964).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(964).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(964).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(965).CellType = textCellType949;
            this.spdDataInfo_Sheet1.Columns.Get(965).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(965).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(965).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(965).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(966).CellType = textCellType950;
            this.spdDataInfo_Sheet1.Columns.Get(966).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(966).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(966).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(966).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(967).CellType = textCellType951;
            this.spdDataInfo_Sheet1.Columns.Get(967).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(967).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(967).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(967).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(968).CellType = textCellType952;
            this.spdDataInfo_Sheet1.Columns.Get(968).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(968).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(968).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(968).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(969).CellType = textCellType953;
            this.spdDataInfo_Sheet1.Columns.Get(969).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(969).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(969).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(969).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(970).CellType = textCellType954;
            this.spdDataInfo_Sheet1.Columns.Get(970).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(970).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(970).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(970).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(971).CellType = textCellType955;
            this.spdDataInfo_Sheet1.Columns.Get(971).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(971).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(971).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(971).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(972).CellType = textCellType956;
            this.spdDataInfo_Sheet1.Columns.Get(972).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(972).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(972).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(972).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(973).CellType = textCellType957;
            this.spdDataInfo_Sheet1.Columns.Get(973).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(973).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(973).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(973).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(974).CellType = textCellType958;
            this.spdDataInfo_Sheet1.Columns.Get(974).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(974).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(974).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(974).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(975).CellType = textCellType959;
            this.spdDataInfo_Sheet1.Columns.Get(975).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(975).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(975).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(975).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(976).CellType = textCellType960;
            this.spdDataInfo_Sheet1.Columns.Get(976).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(976).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(976).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(976).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(977).CellType = textCellType961;
            this.spdDataInfo_Sheet1.Columns.Get(977).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(977).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(977).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(977).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(978).CellType = textCellType962;
            this.spdDataInfo_Sheet1.Columns.Get(978).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(978).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(978).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(978).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(979).CellType = textCellType963;
            this.spdDataInfo_Sheet1.Columns.Get(979).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(979).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(979).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(979).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(980).CellType = textCellType964;
            this.spdDataInfo_Sheet1.Columns.Get(980).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(980).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(980).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(980).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(981).CellType = textCellType965;
            this.spdDataInfo_Sheet1.Columns.Get(981).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(981).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(981).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(981).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(982).CellType = textCellType966;
            this.spdDataInfo_Sheet1.Columns.Get(982).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(982).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(982).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(982).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(983).CellType = textCellType967;
            this.spdDataInfo_Sheet1.Columns.Get(983).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(983).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(983).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(983).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(984).CellType = textCellType968;
            this.spdDataInfo_Sheet1.Columns.Get(984).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(984).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(984).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(984).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(985).CellType = textCellType969;
            this.spdDataInfo_Sheet1.Columns.Get(985).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(985).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(985).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(985).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(986).CellType = textCellType970;
            this.spdDataInfo_Sheet1.Columns.Get(986).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(986).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(986).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(986).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(987).CellType = textCellType971;
            this.spdDataInfo_Sheet1.Columns.Get(987).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(987).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(987).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(987).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(988).CellType = textCellType972;
            this.spdDataInfo_Sheet1.Columns.Get(988).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(988).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(988).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(988).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(989).CellType = textCellType973;
            this.spdDataInfo_Sheet1.Columns.Get(989).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(989).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(989).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(989).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(990).CellType = textCellType974;
            this.spdDataInfo_Sheet1.Columns.Get(990).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(990).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(990).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(990).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(991).CellType = textCellType975;
            this.spdDataInfo_Sheet1.Columns.Get(991).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(991).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(991).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(991).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(992).CellType = textCellType976;
            this.spdDataInfo_Sheet1.Columns.Get(992).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(992).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(992).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(992).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(993).CellType = textCellType977;
            this.spdDataInfo_Sheet1.Columns.Get(993).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(993).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(993).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(993).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(994).CellType = textCellType978;
            this.spdDataInfo_Sheet1.Columns.Get(994).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(994).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(994).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(994).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(995).CellType = textCellType979;
            this.spdDataInfo_Sheet1.Columns.Get(995).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(995).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(995).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(995).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(996).CellType = textCellType980;
            this.spdDataInfo_Sheet1.Columns.Get(996).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(996).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(996).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(996).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(997).CellType = textCellType981;
            this.spdDataInfo_Sheet1.Columns.Get(997).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(997).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(997).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(997).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(998).CellType = textCellType982;
            this.spdDataInfo_Sheet1.Columns.Get(998).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(998).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(998).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(998).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(999).CellType = textCellType983;
            this.spdDataInfo_Sheet1.Columns.Get(999).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(999).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(999).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(999).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1000).CellType = textCellType984;
            this.spdDataInfo_Sheet1.Columns.Get(1000).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1000).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1000).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1000).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1001).CellType = textCellType985;
            this.spdDataInfo_Sheet1.Columns.Get(1001).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1001).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1001).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1001).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1002).CellType = textCellType986;
            this.spdDataInfo_Sheet1.Columns.Get(1002).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1002).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1002).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1002).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1003).CellType = textCellType987;
            this.spdDataInfo_Sheet1.Columns.Get(1003).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1003).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1003).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1003).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1004).CellType = textCellType988;
            this.spdDataInfo_Sheet1.Columns.Get(1004).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1004).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1004).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1004).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1005).CellType = textCellType989;
            this.spdDataInfo_Sheet1.Columns.Get(1005).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1005).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1005).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1005).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1006).CellType = textCellType990;
            this.spdDataInfo_Sheet1.Columns.Get(1006).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1006).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1006).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1006).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1007).CellType = textCellType991;
            this.spdDataInfo_Sheet1.Columns.Get(1007).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1007).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1007).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1007).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1008).CellType = textCellType992;
            this.spdDataInfo_Sheet1.Columns.Get(1008).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1008).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1008).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1008).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1009).CellType = textCellType993;
            this.spdDataInfo_Sheet1.Columns.Get(1009).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1009).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1009).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1009).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1010).CellType = textCellType994;
            this.spdDataInfo_Sheet1.Columns.Get(1010).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1010).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1010).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1010).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1011).CellType = textCellType995;
            this.spdDataInfo_Sheet1.Columns.Get(1011).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1011).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1011).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1011).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1012).CellType = textCellType996;
            this.spdDataInfo_Sheet1.Columns.Get(1012).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1012).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1012).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1012).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1013).CellType = textCellType997;
            this.spdDataInfo_Sheet1.Columns.Get(1013).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1013).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1013).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1013).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1014).CellType = textCellType998;
            this.spdDataInfo_Sheet1.Columns.Get(1014).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1014).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1014).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1014).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1015).CellType = textCellType999;
            this.spdDataInfo_Sheet1.Columns.Get(1015).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1015).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1015).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1015).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1016).CellType = textCellType1000;
            this.spdDataInfo_Sheet1.Columns.Get(1016).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1016).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1016).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1016).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1017).CellType = textCellType1001;
            this.spdDataInfo_Sheet1.Columns.Get(1017).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1017).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1017).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1017).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1018).CellType = textCellType1002;
            this.spdDataInfo_Sheet1.Columns.Get(1018).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1018).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1018).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1018).Visible = false;
            this.spdDataInfo_Sheet1.Columns.Get(1019).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1019).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1019).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1019).Width = 80F;
            this.spdDataInfo_Sheet1.Columns.Get(1020).CellType = textCellType1003;
            this.spdDataInfo_Sheet1.Columns.Get(1020).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1020).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1020).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1020).Width = 80F;
            this.spdDataInfo_Sheet1.Columns.Get(1021).CellType = textCellType1004;
            this.spdDataInfo_Sheet1.Columns.Get(1021).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1021).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1021).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1021).Width = 80F;
            this.spdDataInfo_Sheet1.Columns.Get(1022).CellType = textCellType1005;
            this.spdDataInfo_Sheet1.Columns.Get(1022).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1022).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1022).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1022).Width = 80F;
            this.spdDataInfo_Sheet1.Columns.Get(1023).CellType = textCellType1006;
            this.spdDataInfo_Sheet1.Columns.Get(1023).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1023).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1023).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1023).Width = 80F;
            this.spdDataInfo_Sheet1.Columns.Get(1024).CellType = textCellType1007;
            this.spdDataInfo_Sheet1.Columns.Get(1024).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1024).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1024).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1024).Width = 80F;
            this.spdDataInfo_Sheet1.Columns.Get(1025).CellType = textCellType1008;
            this.spdDataInfo_Sheet1.Columns.Get(1025).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1025).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1025).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1025).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(1026).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1026).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1026).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1026).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(1027).CellType = textCellType1009;
            this.spdDataInfo_Sheet1.Columns.Get(1027).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1027).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1027).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1027).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(1028).CellType = textCellType1010;
            this.spdDataInfo_Sheet1.Columns.Get(1028).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1028).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1028).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1028).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(1029).CellType = textCellType1011;
            this.spdDataInfo_Sheet1.Columns.Get(1029).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1029).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1029).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1029).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(1030).CellType = textCellType1012;
            this.spdDataInfo_Sheet1.Columns.Get(1030).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1030).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1030).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1030).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(1031).CellType = textCellType1013;
            this.spdDataInfo_Sheet1.Columns.Get(1031).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1031).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1031).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1031).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(1032).CellType = textCellType1014;
            this.spdDataInfo_Sheet1.Columns.Get(1032).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1032).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1032).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1032).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(1033).CellType = textCellType1015;
            this.spdDataInfo_Sheet1.Columns.Get(1033).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDataInfo_Sheet1.Columns.Get(1033).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1033).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1033).Width = 70F;
            this.spdDataInfo_Sheet1.Columns.Get(1034).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1034).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1034).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1035).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1035).Locked = true;
            this.spdDataInfo_Sheet1.Columns.Get(1035).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDataInfo_Sheet1.Columns.Get(1035).Width = 70F;
            this.spdDataInfo_Sheet1.FrozenColumnCount = 2;
            this.spdDataInfo_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdDataInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdDataInfo_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDataInfo_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdDataInfo_Sheet1.RowHeader.Visible = false;
            this.spdDataInfo_Sheet1.Rows.Default.Height = 18F;
            this.spdDataInfo_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdDataInfo_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdDataInfo_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdDataInfo_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdDataInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splChart
            // 
            this.splChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.splChart.Location = new System.Drawing.Point(0, 472);
            this.splChart.Name = "splChart";
            this.splChart.Size = new System.Drawing.Size(792, 3);
            this.splChart.TabIndex = 5;
            this.splChart.TabStop = false;
            // 
            // pnlFillChart
            // 
            this.pnlFillChart.Controls.Add(this.pnlFillFill);
            this.pnlFillChart.Controls.Add(this.pnlFillMiddle);
            this.pnlFillChart.Controls.Add(this.pnlFillRight);
            this.pnlFillChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFillChart.Location = new System.Drawing.Point(0, 75);
            this.pnlFillChart.MinimumSize = new System.Drawing.Size(0, 260);
            this.pnlFillChart.Name = "pnlFillChart";
            this.pnlFillChart.Size = new System.Drawing.Size(792, 397);
            this.pnlFillChart.TabIndex = 4;
            // 
            // pnlFillFill
            // 
            this.pnlFillFill.Controls.Add(this.pnlChart);
            this.pnlFillFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFillFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFillFill.Name = "pnlFillFill";
            this.pnlFillFill.Padding = new System.Windows.Forms.Padding(3);
            this.pnlFillFill.Size = new System.Drawing.Size(569, 397);
            this.pnlFillFill.TabIndex = 0;
            // 
            // pnlChart
            // 
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlChart.Controls.Add(this.Chart);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(3, 3);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(563, 391);
            this.pnlChart.TabIndex = 0;
            // 
            // Chart
            // 
            this.Chart.AZoneColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(115)))), ((int)(((byte)(0)))));
            this.Chart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Chart.BGColor = System.Drawing.Color.WhiteSmoke;
            this.Chart.BottomTitle = "";
            this.Chart.BottomTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(39)))), ((int)(((byte)(116)))));
            this.Chart.BZoneColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.Chart.ChartType = SPCControlChart.modEnums.GRAPH_TYPE.NONE;
            this.Chart.CLLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(15)))));
            this.Chart.ControlLimitColor = System.Drawing.Color.Black;
            this.Chart.CZoneColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(255)))), ((int)(((byte)(33)))));
            this.Chart.DateColor = System.Drawing.Color.Black;
            this.Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chart.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chart.IsAutoRuleCheck = false;
            this.Chart.IsDrawGroupLine = false;
            this.Chart.IsOnLineChart = false;
            this.Chart.IsOnLineStop = false;
            this.Chart.IsPoint3D = true;
            this.Chart.IsSimpleChart = false;
            this.Chart.IsTimeBasedChart = false;
            this.Chart.IsUserInputCL = false;
            this.Chart.IsViewAZone = true;
            this.Chart.IsViewBZone = true;
            this.Chart.IsViewContextMenu = true;
            this.Chart.IsViewCZone = true;
            this.Chart.IsViewDate = true;
            this.Chart.IsViewDisable = false;
            this.Chart.IsViewLotID = false;
            this.Chart.IsViewLSL = false;
            this.Chart.IsViewPoint = true;
            this.Chart.IsViewRChart = true;
            this.Chart.IsViewRCL = true;
            this.Chart.IsViewRLCL = true;
            this.Chart.IsViewRUCL = true;
            this.Chart.IsViewRunTestText = false;
            this.Chart.IsViewSpecLimit = false;
            this.Chart.IsViewTarget = false;
            this.Chart.IsViewUSL = false;
            this.Chart.IsViewXCL = true;
            this.Chart.IsViewXLCL = true;
            this.Chart.IsViewXUCL = true;
            this.Chart.LCLLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(15)))));
            this.Chart.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.Chart.Location = new System.Drawing.Point(0, 0);
            this.Chart.LotIDColor = System.Drawing.Color.Black;
            this.Chart.LSLLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Chart.MainTitle = "";
            this.Chart.MainTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Chart.MaxLotCount = 100;
            this.Chart.Name = "Chart";
            this.Chart.NormalPointColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Chart.OOCPointColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.Chart.OOSPointColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Chart.PointSize = 3;
            this.Chart.Precision = 4;
            this.Chart.RRegionColor = System.Drawing.Color.White;
            this.Chart.RRuleType = "";
            this.Chart.RunTestColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.Chart.SampleSize = 0;
            this.Chart.Size = new System.Drawing.Size(559, 387);
            this.Chart.SpecLimitColor = System.Drawing.Color.Black;
            this.Chart.SubTitle = "";
            this.Chart.SubTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(39)))), ((int)(((byte)(116)))));
            this.Chart.TabIndex = 0;
            this.Chart.UCLLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(15)))));
            this.Chart.UnitTitle = "";
            this.Chart.UnitTitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(39)))), ((int)(((byte)(116)))));
            this.Chart.USLLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Chart.XRegionColor = System.Drawing.Color.White;
            this.Chart.XRuleType = "";
            this.Chart.YAxisColor = System.Drawing.Color.Black;
            this.Chart.MouseButtonDown += new SPCControlChart.MouseButtonDownEventHandler(this.Chart_MouseButtonDown);
            this.Chart.ChartZoomed += new SPCControlChart.ChartZoomedEventHandler(this.Chart_ChartZoomed);
            this.Chart.ViewOOCInfo += new SPCControlChart.ViewOOCInfoEventHandler(this.Chart_ViewOOCInfo);
            this.Chart.ChangeEDCData += new SPCControlChart.ChangeEDCDataEventHandler(this.Chart_ChangeEDCData);
            // 
            // pnlFillMiddle
            // 
            this.pnlFillMiddle.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFillMiddle.Location = new System.Drawing.Point(569, 0);
            this.pnlFillMiddle.Name = "pnlFillMiddle";
            this.pnlFillMiddle.Size = new System.Drawing.Size(3, 397);
            this.pnlFillMiddle.TabIndex = 4;
            // 
            // pnlFillRight
            // 
            this.pnlFillRight.Controls.Add(this.grpChartOptions);
            this.pnlFillRight.Controls.Add(this.grpChartInfo);
            this.pnlFillRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlFillRight.Location = new System.Drawing.Point(572, 0);
            this.pnlFillRight.Name = "pnlFillRight";
            this.pnlFillRight.Padding = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.pnlFillRight.Size = new System.Drawing.Size(220, 397);
            this.pnlFillRight.TabIndex = 3;
            // 
            // grpChartOptions
            // 
            this.grpChartOptions.Controls.Add(this.chkBasedOnTime);
            this.grpChartOptions.Controls.Add(this.chkViewRuleCheck);
            this.grpChartOptions.Controls.Add(this.btnRedraw);
            this.grpChartOptions.Controls.Add(this.chkViewRChart);
            this.grpChartOptions.Controls.Add(this.chkViewCZone);
            this.grpChartOptions.Controls.Add(this.chkViewBZone);
            this.grpChartOptions.Controls.Add(this.chkViewAZone);
            this.grpChartOptions.Controls.Add(this.txtMaxLotCount);
            this.grpChartOptions.Controls.Add(this.lblMaxLotCount);
            this.grpChartOptions.Controls.Add(this.chkViewSpecLimit);
            this.grpChartOptions.Controls.Add(this.chkViewDate);
            this.grpChartOptions.Controls.Add(this.chkViewLotID);
            this.grpChartOptions.Controls.Add(this.chkAutoCalControlLimit);
            this.grpChartOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChartOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartOptions.Location = new System.Drawing.Point(0, 169);
            this.grpChartOptions.Name = "grpChartOptions";
            this.grpChartOptions.Size = new System.Drawing.Size(217, 225);
            this.grpChartOptions.TabIndex = 1;
            this.grpChartOptions.TabStop = false;
            this.grpChartOptions.Text = "Chart Options";
            // 
            // chkBasedOnTime
            // 
            this.chkBasedOnTime.AutoSize = true;
            this.chkBasedOnTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkBasedOnTime.Location = new System.Drawing.Point(10, 190);
            this.chkBasedOnTime.Name = "chkBasedOnTime";
            this.chkBasedOnTime.Size = new System.Drawing.Size(109, 17);
            this.chkBasedOnTime.TabIndex = 12;
            this.chkBasedOnTime.Text = "Based on Time";
            this.chkBasedOnTime.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewRuleCheck
            // 
            this.chkViewRuleCheck.AutoSize = true;
            this.chkViewRuleCheck.Checked = true;
            this.chkViewRuleCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewRuleCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewRuleCheck.Location = new System.Drawing.Point(10, 129);
            this.chkViewRuleCheck.Name = "chkViewRuleCheck";
            this.chkViewRuleCheck.Size = new System.Drawing.Size(118, 17);
            this.chkViewRuleCheck.TabIndex = 9;
            this.chkViewRuleCheck.Text = "View Rule Check";
            this.chkViewRuleCheck.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewRuleCheck.CheckedChanged += new System.EventHandler(this.chkViewRuleCheck_CheckedChanged);
            // 
            // btnRedraw
            // 
            this.btnRedraw.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRedraw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRedraw.Location = new System.Drawing.Point(140, 41);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(56, 22);
            this.btnRedraw.TabIndex = 5;
            this.btnRedraw.Text = "Redraw";
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // chkViewRChart
            // 
            this.chkViewRChart.AutoSize = true;
            this.chkViewRChart.Checked = true;
            this.chkViewRChart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewRChart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewRChart.Location = new System.Drawing.Point(10, 149);
            this.chkViewRChart.Name = "chkViewRChart";
            this.chkViewRChart.Size = new System.Drawing.Size(99, 17);
            this.chkViewRChart.TabIndex = 10;
            this.chkViewRChart.Text = "View R-Chart";
            this.chkViewRChart.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewRChart.CheckedChanged += new System.EventHandler(this.chkViewRChart_CheckedChanged);
            // 
            // chkViewCZone
            // 
            this.chkViewCZone.AutoSize = true;
            this.chkViewCZone.Checked = true;
            this.chkViewCZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewCZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewCZone.Location = new System.Drawing.Point(140, 20);
            this.chkViewCZone.Name = "chkViewCZone";
            this.chkViewCZone.Size = new System.Drawing.Size(64, 17);
            this.chkViewCZone.TabIndex = 2;
            this.chkViewCZone.Text = "C Zone";
            this.chkViewCZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewCZone.CheckedChanged += new System.EventHandler(this.chkViewCZone_CheckedChanged);
            // 
            // chkViewBZone
            // 
            this.chkViewBZone.AutoSize = true;
            this.chkViewBZone.Checked = true;
            this.chkViewBZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewBZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewBZone.Location = new System.Drawing.Point(75, 20);
            this.chkViewBZone.Name = "chkViewBZone";
            this.chkViewBZone.Size = new System.Drawing.Size(63, 17);
            this.chkViewBZone.TabIndex = 1;
            this.chkViewBZone.Text = "B Zone";
            this.chkViewBZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewBZone.CheckedChanged += new System.EventHandler(this.chkViewBZone_CheckedChanged);
            // 
            // chkViewAZone
            // 
            this.chkViewAZone.AutoSize = true;
            this.chkViewAZone.Checked = true;
            this.chkViewAZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewAZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewAZone.Location = new System.Drawing.Point(10, 20);
            this.chkViewAZone.Name = "chkViewAZone";
            this.chkViewAZone.Size = new System.Drawing.Size(63, 17);
            this.chkViewAZone.TabIndex = 0;
            this.chkViewAZone.Text = "A Zone";
            this.chkViewAZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewAZone.CheckedChanged += new System.EventHandler(this.chkViewAZone_CheckedChanged);
            // 
            // txtMaxLotCount
            // 
            this.txtMaxLotCount.Location = new System.Drawing.Point(100, 41);
            this.txtMaxLotCount.MaxLength = 20;
            this.txtMaxLotCount.Name = "txtMaxLotCount";
            this.txtMaxLotCount.Size = new System.Drawing.Size(40, 21);
            this.txtMaxLotCount.TabIndex = 4;
            this.txtMaxLotCount.Text = "500";
            // 
            // lblMaxLotCount
            // 
            this.lblMaxLotCount.AutoSize = true;
            this.lblMaxLotCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxLotCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLotCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxLotCount.Location = new System.Drawing.Point(10, 44);
            this.lblMaxLotCount.Name = "lblMaxLotCount";
            this.lblMaxLotCount.Size = new System.Drawing.Size(91, 13);
            this.lblMaxLotCount.TabIndex = 3;
            this.lblMaxLotCount.Text = "Max Point Count :";
            // 
            // chkViewSpecLimit
            // 
            this.chkViewSpecLimit.AutoSize = true;
            this.chkViewSpecLimit.Checked = true;
            this.chkViewSpecLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewSpecLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewSpecLimit.Location = new System.Drawing.Point(10, 109);
            this.chkViewSpecLimit.Name = "chkViewSpecLimit";
            this.chkViewSpecLimit.Size = new System.Drawing.Size(113, 17);
            this.chkViewSpecLimit.TabIndex = 8;
            this.chkViewSpecLimit.Text = "View Spec Limit";
            this.chkViewSpecLimit.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewSpecLimit.CheckedChanged += new System.EventHandler(this.chkViewSpecLimit_CheckedChanged);
            // 
            // chkViewDate
            // 
            this.chkViewDate.AutoSize = true;
            this.chkViewDate.Checked = true;
            this.chkViewDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewDate.Location = new System.Drawing.Point(10, 89);
            this.chkViewDate.Name = "chkViewDate";
            this.chkViewDate.Size = new System.Drawing.Size(79, 17);
            this.chkViewDate.TabIndex = 7;
            this.chkViewDate.Text = "View Date";
            this.chkViewDate.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewDate.CheckedChanged += new System.EventHandler(this.chkViewDate_CheckedChanged);
            // 
            // chkViewLotID
            // 
            this.chkViewLotID.AutoSize = true;
            this.chkViewLotID.Checked = true;
            this.chkViewLotID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewLotID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewLotID.Location = new System.Drawing.Point(10, 69);
            this.chkViewLotID.Name = "chkViewLotID";
            this.chkViewLotID.Size = new System.Drawing.Size(119, 17);
            this.chkViewLotID.TabIndex = 6;
            this.chkViewLotID.Text = "View XAxis Label";
            this.chkViewLotID.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewLotID.CheckedChanged += new System.EventHandler(this.chkViewLotID_CheckedChanged);
            // 
            // chkAutoCalControlLimit
            // 
            this.chkAutoCalControlLimit.AutoSize = true;
            this.chkAutoCalControlLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAutoCalControlLimit.Location = new System.Drawing.Point(10, 169);
            this.chkAutoCalControlLimit.Name = "chkAutoCalControlLimit";
            this.chkAutoCalControlLimit.Size = new System.Drawing.Size(193, 17);
            this.chkAutoCalControlLimit.TabIndex = 11;
            this.chkAutoCalControlLimit.Text = "Auto Calculation Control Limit";
            this.chkAutoCalControlLimit.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkAutoCalControlLimit.CheckedChanged += new System.EventHandler(this.chkAutoCalControlLimit_CheckedChanged);
            // 
            // grpChartInfo
            // 
            this.grpChartInfo.Controls.Add(this.spdChartInfo);
            this.grpChartInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChartInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartInfo.Location = new System.Drawing.Point(0, 0);
            this.grpChartInfo.Name = "grpChartInfo";
            this.grpChartInfo.Size = new System.Drawing.Size(217, 169);
            this.grpChartInfo.TabIndex = 0;
            this.grpChartInfo.TabStop = false;
            this.grpChartInfo.Text = "Chart Information";
            // 
            // spdChartInfo
            // 
            this.spdChartInfo.AccessibleDescription = "spdChartInfo, Sheet1, Row 0, Column 0, Material ID";
            this.spdChartInfo.BackColor = System.Drawing.SystemColors.Control;
            this.spdChartInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdChartInfo.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdChartInfo.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdChartInfo.HorizontalScrollBar.Name = "";
            this.spdChartInfo.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdChartInfo.HorizontalScrollBar.TabIndex = 2;
            this.spdChartInfo.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdChartInfo.Location = new System.Drawing.Point(3, 16);
            this.spdChartInfo.Name = "spdChartInfo";
            this.spdChartInfo.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdChartInfo.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdChartInfo.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdChartInfo_Sheet1});
            this.spdChartInfo.Size = new System.Drawing.Size(211, 150);
            this.spdChartInfo.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdChartInfo.TabIndex = 0;
            this.spdChartInfo.TabStop = false;
            this.spdChartInfo.TextTipDelay = 200;
            this.spdChartInfo.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdChartInfo.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdChartInfo.VerticalScrollBar.Name = "";
            this.spdChartInfo.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdChartInfo.VerticalScrollBar.TabIndex = 3;
            // 
            // spdChartInfo_Sheet1
            // 
            this.spdChartInfo_Sheet1.Reset();
            spdChartInfo_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdChartInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdChartInfo_Sheet1.ColumnCount = 2;
            spdChartInfo_Sheet1.RowCount = 19;
            this.spdChartInfo_Sheet1.Cells.Get(0, 0).Value = "Material ID";
            this.spdChartInfo_Sheet1.Cells.Get(1, 0).Value = "Mat Ver";
            this.spdChartInfo_Sheet1.Cells.Get(1, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdChartInfo_Sheet1.Cells.Get(2, 0).Value = "Flow";
            this.spdChartInfo_Sheet1.Cells.Get(3, 0).Value = "Operation";
            this.spdChartInfo_Sheet1.Cells.Get(4, 0).Value = "Resource ID";
            this.spdChartInfo_Sheet1.Cells.Get(5, 0).Value = "Character ID";
            this.spdChartInfo_Sheet1.Cells.Get(6, 0).Value = "Lot or Res";
            this.spdChartInfo_Sheet1.Cells.Get(7, 0).Value = "Unit Use";
            this.spdChartInfo_Sheet1.Cells.Get(8, 0).Value = "Unit Count";
            this.spdChartInfo_Sheet1.Cells.Get(9, 0).Value = "Sample Size";
            this.spdChartInfo_Sheet1.Cells.Get(10, 0).Value = "USL";
            this.spdChartInfo_Sheet1.Cells.Get(10, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(11, 0).Value = "TARGET";
            this.spdChartInfo_Sheet1.Cells.Get(11, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(12, 0).Value = "LSL";
            this.spdChartInfo_Sheet1.Cells.Get(12, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(13, 0).Value = "UCL";
            this.spdChartInfo_Sheet1.Cells.Get(13, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(14, 0).Value = "CL";
            this.spdChartInfo_Sheet1.Cells.Get(14, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(15, 0).Value = "LCL";
            this.spdChartInfo_Sheet1.Cells.Get(15, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(16, 0).Value = "UCL2";
            this.spdChartInfo_Sheet1.Cells.Get(16, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(17, 0).Value = "CL2";
            this.spdChartInfo_Sheet1.Cells.Get(17, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Cells.Get(18, 0).Value = "LCL2";
            this.spdChartInfo_Sheet1.Cells.Get(18, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChartInfo_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdChartInfo_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChartInfo_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdChartInfo_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChartInfo_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdChartInfo_Sheet1.ColumnHeader.Visible = false;
            this.spdChartInfo_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdChartInfo_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdChartInfo_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(0).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(0).Width = 71F;
            this.spdChartInfo_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdChartInfo_Sheet1.Columns.Get(1).Locked = true;
            this.spdChartInfo_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Columns.Get(1).Width = 118F;
            this.spdChartInfo_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdChartInfo_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdChartInfo_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChartInfo_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdChartInfo_Sheet1.RowHeader.Visible = false;
            this.spdChartInfo_Sheet1.Rows.Get(0).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(1).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(2).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(3).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(4).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(5).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(6).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(7).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(8).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(9).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(10).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(12).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(13).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(14).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(15).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(16).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(17).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.Rows.Get(18).Height = 18F;
            this.spdChartInfo_Sheet1.Rows.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdChartInfo_Sheet1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.spdChartInfo_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdChartInfo_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdChartInfo_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdChartInfo_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdChartInfo_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlFillTop
            // 
            this.pnlFillTop.Controls.Add(this.grpTop);
            this.pnlFillTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFillTop.Location = new System.Drawing.Point(0, 0);
            this.pnlFillTop.Name = "pnlFillTop";
            this.pnlFillTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlFillTop.Size = new System.Drawing.Size(792, 75);
            this.pnlFillTop.TabIndex = 0;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.btnFiltering);
            this.grpTop.Controls.Add(this.lblGraphType);
            this.grpTop.Controls.Add(this.cboGraphType);
            this.grpTop.Controls.Add(this.lblPeriod);
            this.grpTop.Controls.Add(this.cdvChartID);
            this.grpTop.Controls.Add(this.lblChartID);
            this.grpTop.Controls.Add(this.udtStart);
            this.grpTop.Controls.Add(this.uccStart);
            this.grpTop.Controls.Add(this.udtEnd);
            this.grpTop.Controls.Add(this.uccEnd);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(3, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(786, 72);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // btnFiltering
            // 
            this.btnFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering.Image")));
            this.btnFiltering.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering.Location = new System.Drawing.Point(300, 15);
            this.btnFiltering.Name = "btnFiltering";
            this.btnFiltering.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering.TabIndex = 2;
            this.btnFiltering.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // lblGraphType
            // 
            this.lblGraphType.AutoSize = true;
            this.lblGraphType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGraphType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGraphType.Location = new System.Drawing.Point(15, 44);
            this.lblGraphType.Name = "lblGraphType";
            this.lblGraphType.Size = new System.Drawing.Size(63, 13);
            this.lblGraphType.TabIndex = 3;
            this.lblGraphType.Text = "Graph Type";
            // 
            // cboGraphType
            // 
            this.cboGraphType.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.cboGraphType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboGraphType.Location = new System.Drawing.Point(117, 42);
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.ReadOnly = true;
            this.cboGraphType.Size = new System.Drawing.Size(179, 19);
            this.cboGraphType.TabIndex = 4;
            this.cboGraphType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPeriod.Location = new System.Drawing.Point(552, 20);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 5;
            this.lblPeriod.Text = "Period";
            // 
            // cdvChartID
            // 
            this.cdvChartID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChartID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChartID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChartID.BtnToolTipText = "";
            this.cdvChartID.ButtonWidth = 20;
            this.cdvChartID.DescText = "";
            this.cdvChartID.DisplaySubItemIndex = -1;
            this.cdvChartID.DisplayText = "";
            this.cdvChartID.Focusing = null;
            this.cdvChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChartID.Index = 0;
            this.cdvChartID.IsViewBtnImage = false;
            this.cdvChartID.Location = new System.Drawing.Point(117, 17);
            this.cdvChartID.MaxLength = 30;
            this.cdvChartID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.MultiSelect = false;
            this.cdvChartID.Name = "cdvChartID";
            this.cdvChartID.ReadOnly = false;
            this.cdvChartID.SameWidthHeightOfButton = false;
            this.cdvChartID.SearchSubItemIndex = 0;
            this.cdvChartID.SelectedDescIndex = -1;
            this.cdvChartID.SelectedDescToQueryText = "";
            this.cdvChartID.SelectedSubItemIndex = -1;
            this.cdvChartID.SelectedValueToQueryText = "";
            this.cdvChartID.SelectionStart = 0;
            this.cdvChartID.Size = new System.Drawing.Size(179, 20);
            this.cdvChartID.SmallImageList = null;
            this.cdvChartID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartID.TabIndex = 1;
            this.cdvChartID.TextBoxToolTipText = "";
            this.cdvChartID.TextBoxWidth = 179;
            this.cdvChartID.VisibleButton = true;
            this.cdvChartID.VisibleColumnHeader = false;
            this.cdvChartID.VisibleDescription = false;
            this.cdvChartID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartID_SelectedItemChanged);
            this.cdvChartID.ButtonPress += new System.EventHandler(this.cdvChartID_ButtonPress);
            this.cdvChartID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvChartID_TextBoxKeyPress);
            // 
            // lblChartID
            // 
            this.lblChartID.AutoSize = true;
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(15, 20);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(54, 13);
            this.lblChartID.TabIndex = 0;
            this.lblChartID.Text = "Chart ID";
            // 
            // udtStart
            // 
            this.udtStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.udtStart.DateTime = new System.DateTime(2005, 5, 26, 0, 0, 0, 0);
            this.udtStart.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtStart.FormatString = "";
            this.udtStart.Location = new System.Drawing.Point(705, 17);
            this.udtStart.MaskInput = "hh:mm:ss";
            this.udtStart.Name = "udtStart";
            this.udtStart.Size = new System.Drawing.Size(72, 21);
            this.udtStart.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtStart.SpinWrap = true;
            this.udtStart.TabIndex = 7;
            this.udtStart.Value = new System.DateTime(2005, 5, 26, 0, 0, 0, 0);
            // 
            // uccStart
            // 
            this.uccStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uccStart.DateButtons.Add(dateButton1);
            this.uccStart.Location = new System.Drawing.Point(617, 17);
            this.uccStart.Name = "uccStart";
            this.uccStart.NonAutoSizeHeight = 21;
            this.uccStart.Size = new System.Drawing.Size(88, 21);
            this.uccStart.TabIndex = 6;
            this.uccStart.Value = new System.DateTime(2005, 5, 26, 0, 0, 0, 0);
            // 
            // udtEnd
            // 
            this.udtEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.udtEnd.DateTime = new System.DateTime(2005, 5, 4, 23, 59, 59, 0);
            this.udtEnd.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtEnd.FormatString = "";
            this.udtEnd.Location = new System.Drawing.Point(705, 41);
            this.udtEnd.MaskInput = "hh:mm:ss";
            this.udtEnd.Name = "udtEnd";
            this.udtEnd.Size = new System.Drawing.Size(72, 21);
            this.udtEnd.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtEnd.SpinWrap = true;
            this.udtEnd.TabIndex = 9;
            this.udtEnd.Value = new System.DateTime(2005, 5, 4, 23, 59, 59, 0);
            // 
            // uccEnd
            // 
            this.uccEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uccEnd.DateButtons.Add(dateButton2);
            this.uccEnd.Location = new System.Drawing.Point(617, 41);
            this.uccEnd.Name = "uccEnd";
            this.uccEnd.NonAutoSizeHeight = 21;
            this.uccEnd.Size = new System.Drawing.Size(88, 21);
            this.uccEnd.TabIndex = 8;
            this.uccEnd.Value = new System.DateTime(2005, 5, 26, 0, 0, 0, 0);
            // 
            // frmSPCTranControlChart
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 636);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(800, 670);
            this.Name = "frmSPCTranControlChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "View Control Chart";
            this.Activated += new System.EventHandler(this.frmSPCTranControlChart_Activated);
            this.Load += new System.EventHandler(this.frmSPCTranControlChart_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewChartOptions)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlFillBottom.ResumeLayout(false);
            this.grpEDCInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdDataInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdDataInfo_Sheet1)).EndInit();
            this.pnlFillChart.ResumeLayout(false);
            this.pnlFillFill.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.pnlFillRight.ResumeLayout(false);
            this.grpChartOptions.ResumeLayout(false);
            this.grpChartOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkBasedOnTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewRuleCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewRChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewCZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewBZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewAZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxLotCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewSpecLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewLotID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoCalControlLimit)).EndInit();
            this.grpChartInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdChartInfo_Sheet1)).EndInit();
            this.pnlFillTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccEnd)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        
        bool b_load_flag;
        private ArrayList DisabledFormControls = new ArrayList();

        int giPrecision = 4;
        private const int MAT_ID_COL = 0;
        private const int MAT_VER_COL = 1;
        private const int FLOW_COL = 2;
        private const int OPER_COL = 3;
        private const int RES_COL = 4;
        private const int CHAR_COL = 5;
        private const int LOT_OR_RES_COL = 6;
        private const int USE_UNIT_COL = 7;
        private const int UNIT_COUNT_COL = 8;
        private const int SAMPLE_SIZE_COL = 9;
        private const int USL_COL = 10;
        private const int TARGET_COL = 11;
        private const int LSL_COL = 12;
        private const int UCL_COL = 13;
        private const int CL_COL = 14;
        private const int LCL_COL = 15;
        private const int UCL2_COL = 16;
        private const int CL2_COL = 17;
        private const int LCL2_COL = 18;

        private const int LOTID_COL = 5;
        private const int MATID_COL = 6;
        private const int MATDESC_COL = 7;
        private const int MATVER_COL = 8;
        private const int FLOW = 9;
        private const int OPER = 10;
        private const int PROCOPER_COL = 11;
        private const int RESID_COL = 12;
        private const int SUBRES_COL = 13;
        private const int PROCRES_COL = 14;
        private const int EVENT_COL = 15;

        private const int VALUE_START_COL = 19;
        private const int VALUE_END_COL = 1018;
        private const int WEIGHT_COL = 1019;
        private const int AVERAGE_COL = 1020;
        private const int SIGMA_COL = 1021;
        private const int RANGE_COL = 1022;
        private const int MAX_COL = 1023;
        private const int MIN_COL = 1024;
        private const int RAW_COL_UCL2 = 1031;
        private const int RAW_COL_OOC_TYPE_2 = 1035;

        
        #endregion
        
        #region " Functions Implementation"
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool CheckCondition()
        {
            
            try
            {
                if (cdvChartID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvChartID.Focus();
                    return false;
                }
                if (cboGraphType.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cboGraphType.Focus();
                    return false;
                }
                if (MPCF.CheckNumeric(this.txtMaxLotCount.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                    this.txtMaxLotCount.SelectAll();
                    this.txtMaxLotCount.Focus();
                    return false;
                }
                else
                {
                    if (MPCF.ToInt(this.txtMaxLotCount.Text) <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        this.txtMaxLotCount.SelectAll();
                        this.txtMaxLotCount.Focus();
                        return false;
                    }
                }
                if (this.uccStart.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccStart.Focus();
                    return false;
                }
                if (this.udtStart.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    udtStart.Focus();
                    return false;
                }
                if (this.uccEnd.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccEnd.Focus();
                    return false;
                }
                if (this.udtEnd.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    udtEnd.Focus();
                    return false;
                }
                if (MPCF.ToDate((((DateTime)uccStart.Value).ToString("yyyyMMdd")) + (((DateTime)udtStart.Value).ToString("HHmmss"))) >=
                    MPCF.ToDate((((DateTime)uccEnd.Value).ToString("yyyyMMdd")) + (((DateTime)udtEnd.Value).ToString("HHmmss"))))
                
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(214));
                    return false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Chart()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Chart()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node = new TRSNode("View_Chart_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", cdvChartID.Text);

                if (MPCR.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "")
                {
                    cboGraphType.SelectedIndex = - 1;
                }
                else
                {
                    cboGraphType.SelectedIndex = (int)Enum.Parse(typeof(eGraphType), MPCF.Trim(out_node.GetString("GRAPH_TYPE")));
                }

                spdChartInfo.Sheets[0].SetValue(MAT_ID_COL, 1, MPCF.Trim(out_node.GetString("MAT_ID")));
                spdChartInfo.Sheets[0].SetValue(MAT_VER_COL, 1, MPCF.Trim(out_node.GetInt("MAT_VER")));
                spdChartInfo.Sheets[0].SetValue(FLOW_COL, 1, MPCF.Trim(out_node.GetString("FLOW")));
                spdChartInfo.Sheets[0].SetValue(OPER_COL, 1, MPCF.Trim(out_node.GetString("OPER")));
                spdChartInfo.Sheets[0].SetValue(RES_COL, 1, MPCF.Trim(out_node.GetString("RES_ID")));
                spdChartInfo.Sheets[0].SetValue(CHAR_COL, 1, MPCF.Trim(out_node.GetString("CHAR_ID")));
                spdChartInfo.Sheets[0].SetValue(LOT_OR_RES_COL, 1, MPCF.Trim(out_node.GetChar("LOT_RES_FLAG")));
                spdChartInfo.Sheets[0].SetValue(USE_UNIT_COL, 1, MPCF.Trim(out_node.GetChar("UNIT_USE_FLAG")));
                spdChartInfo.Sheets[0].SetValue(UNIT_COUNT_COL, 1, MPCF.Trim(out_node.GetInt("UNIT_COUNT")));
                spdChartInfo.Sheets[0].SetValue(SAMPLE_SIZE_COL, 1, MPCF.Trim(out_node.GetInt("SAMPLE_SIZE")));

                giPrecision = out_node.GetInt("PRECISION_LIMIT");
                
                Chart.XRuleType = MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL"));
                Chart.RRuleType = MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL"));

                cdvChartID.DescText = MPCF.Trim(out_node.GetString("CHART_DESC"));
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.View_Chart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Spec()
        //       - View Spec
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iVer As Integer : Version
        //
        private bool View_Spec(int iVer)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Spec_In");
                TRSNode out_node = new TRSNode("View_Spec_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", cdvChartID.Text);
                in_node.AddInt("VERSION", iVer);
               
                if (MPCR.CallService("SPC", "SPC_View_Spec", in_node, ref out_node,true) == false)
                {
                    return false;
                }

                spdChartInfo.Sheets[0].SetValue(USL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("USL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(TARGET_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("TARGET")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(LSL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LSL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(UCL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(CL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(LCL_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(UCL2_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL2")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(CL2_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL2")), giPrecision));
                spdChartInfo.Sheets[0].SetValue(LCL2_COL, 1, MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL2")), giPrecision));
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.View_Spec()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ClearChartInfo()
        //       - Clear spdChartInfo
        // Return Value
        //       -
        // Arguments
        //       -
        //
        public void ClearChartInfo()
        {
            
            try
            {
                int i;
                for (i = 0; i <= spdChartInfo.Sheets[0].RowCount - 1; i++)
                {
                    spdChartInfo.Sheets[0].SetValue(i, 1, "");
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.ClearChartInfo()\n" + ex.Message);
            }
            
        }
        
        // InitChart()
        //       - Initialize Chart Options
        // Return Value
        //       -
        // Arguments
        //       -
        //
        public void InitChart()
        {
            
            try
            {
                Chart.InitDataSet();
                Chart.IsViewRChart = this.chkViewRChart.Checked;
                Chart.IsViewLotID = this.chkViewLotID.Checked;
                Chart.IsViewDate = this.chkViewDate.Checked;
                Chart.IsViewSpecLimit = this.chkViewSpecLimit.Checked;
                Chart.IsViewXUCL = true;
                Chart.IsViewXCL = true;
                Chart.IsViewXLCL = true;
                Chart.IsViewRUCL = true;
                Chart.IsViewRCL = true;
                Chart.IsViewRLCL = true;
                Chart.IsViewRunTestText = this.chkViewRuleCheck.Checked;
                Chart.IsViewAZone = this.chkViewAZone.Checked;
                Chart.IsViewBZone = this.chkViewBZone.Checked;
                Chart.IsViewCZone = this.chkViewCZone.Checked;
                Chart.IsUserInputCL = !(this.chkAutoCalControlLimit.Checked);
                Chart.IsTimeBasedChart = this.chkBasedOnTime.Checked;
                
                if (MPCF.CheckNumeric(this.txtMaxLotCount.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                    this.txtMaxLotCount.SelectAll();
                    this.txtMaxLotCount.Focus();
                    return;
                }
                else
                {
                    if (MPCF.ToInt(this.txtMaxLotCount.Text) <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        this.txtMaxLotCount.SelectAll();
                        this.txtMaxLotCount.Focus();
                        return;
                    }
                }
                
                Chart.Precision = giPrecision;
                Chart.MaxLotCount = MPCF.ToInt(this.txtMaxLotCount.Text);
                Chart.ChartType = SPCControlChart.modEnums.GRAPH_TYPE.NONE;
                
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.InitChart()\n" + ex.Message);
            }
            
        }
        
        // SetChartOptions()
        //       - Set Chart Options
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool SetChartOptions()
        {
            
            try
            {
                switch (this.cboGraphType.SelectedIndex)
                {
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.XBARR:
                        
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.XBARS:
                        
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.XRS:
                        
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.P:
                        
                        this.chkViewRChart.Checked = false;
                        this.chkViewRChart.Visible = false;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.PN:
                        
                        this.chkViewRChart.Checked = false;
                        this.chkViewRChart.Visible = false;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.C:
                        
                        this.chkViewRChart.Checked = false;
                        this.chkViewRChart.Visible = false;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.U:
                        
                        this.chkViewRChart.Checked = false;
                        this.chkViewRChart.Visible = false;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.ZBARS:
                        
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                    case (int)SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:
                        
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = false;
                        this.chkViewSpecLimit.Checked = false;
                        break;
                    default:
                        
                        this.chkViewRChart.Checked = true;
                        this.chkViewRChart.Visible = true;
                        this.chkViewSpecLimit.Enabled = true;
                        this.chkViewSpecLimit.Checked = true;
                        break;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.SetChartOptions()\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetChartTitle()
        //       - Set Chart Title
        // Return Value
        //       -
        // Arguments
        //       -
        //
        public bool SetChartTitle()
        {
            
            try
            {
                switch (Chart.ChartType)
                {
                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARR:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "XBAR-CHART";
                        Chart.BottomTitle = "R-CHART";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARS:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "XBAR-CHART";
                        Chart.BottomTitle = "S-CHART";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.XRS:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "X-CHART";
                        Chart.BottomTitle = "R-CHART";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.P:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "P-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.PN:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "PN-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.C:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "C-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.U:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "U-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.ZBARS:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "ZBAR-CHART";
                        Chart.BottomTitle = "S-CHART";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:

                        Chart.MainTitle = this.cdvChartID.Text + " : " + this.cdvChartID.DescText;
                        Chart.SubTitle = "DELTA-CHART";
                        Chart.BottomTitle = "S-CHART";
                        Chart.UnitTitle = "";
                        break;
                    default:
                        
                        Chart.MainTitle = "";
                        Chart.SubTitle = "";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.SetChartTitle()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_ControlChart()
        //       - Set Chart Title
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool View_ControlChart()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_ControlChart_In");
                TRSNode out_node;
                int i;
                int j;
                int iGroupIndex;
                int iLotIndex;
                string sGroupIndex = string.Empty;
                string sLotIndex;
                double dUSL;
                double dLSL;
                double dUCL;
                double dCL;
                double dLCL;
                double dUCL2;
                double dCL2;
                double dLCL2;
                double dPrevUSL;
                double dPrevLSL;
                double dPrevUCL;
                double dPrevCL;
                double dPrevLCL;
                double dPrevUCL2;
                double dPrevCL2;
                double dPrevLCL2;
                double dValue;
                double dXData;
                double dRdata;
                double dTarget;
                string sTranTime;
                string sXAxis;
                ArrayList a_list = new ArrayList();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", cdvChartID.Text);
                in_node.AddString("FROM_TIME", ((DateTime)(uccStart.Value)).ToString("yyyyMMdd") + ((DateTime)(udtStart.Value)).ToString("HHmmss"));
                in_node.AddString("TO_TIME", ((DateTime)(uccEnd.Value)).ToString("yyyyMMdd") + ((DateTime)(udtEnd.Value)).ToString("HHmmss"));
                in_node.AddInt("NEXT_HIST_SEQ", 0);
                in_node.AddInt("NEXT_UNIT_SEQ", 0);
                
                InitChart();
                
                Chart.ChartType = (SPCControlChart.modEnums.GRAPH_TYPE)this.cboGraphType.SelectedIndex;
                Chart.SampleSize = MPCF.ToInt(this.spdChartInfo.Sheets[0].Cells[SAMPLE_SIZE_COL, 1].Text);
                
                if (SetChartTitle() == false)
                {
                    return false;
                }
                
                iGroupIndex = - 1;
                iLotIndex = 0;
                
                dPrevUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevUCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevLCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevUCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dPrevLCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                
                dUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dUCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dLCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                dUCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dLCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                dTarget = StatGlobalVariable.DOUBLE_NULL_DATA;
                
                if (this.chkAutoCalControlLimit.Checked == true)
                {
                    if (MPCF.Trim(this.spdChartInfo.Sheets[0].Cells[USL_COL, 1].Text) == "")
                    {
                        dUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                    }
                    else
                    {
                        dUSL = MPCF.ToDbl(this.spdChartInfo.Sheets[0].Cells[USL_COL, 1].Text);
                    }
                    if (MPCF.Trim(this.spdChartInfo.Sheets[0].Cells[LSL_COL, 1].Text) == "")
                    {
                        dLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                    }
                    else
                    {
                        dLSL = MPCF.ToDbl(this.spdChartInfo.Sheets[0].Cells[LSL_COL, 1].Text);
                    }
                }
                
                do
                {
                    out_node = new TRSNode("SPC_View_ControlChart_Out");
                    if (MPCR.CallService("SPC", "SPC_View_ControlChart", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                     a_list.Add(out_node);
                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                    in_node.SetInt("NEXT_UNIT_SEQ", out_node.GetInt("NEXT_UNIT_SEQ"));

                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0 || in_node.GetInt("NEXT_UNIT_SEQ") > 0);
                    //If View_ControlChart_Out.count = 0 Then
                    //    ShowMsgBox(GetMessage(244))
                    //    Return True
                    //End If
                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        if (Chart.IsUserInputCL == true)
                        {
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("USL")) == "")
                            {
                                dUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dUSL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("USL"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("LSL")) == "")
                            {
                                dLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dLSL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("LSL"));
                            }

                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("UCL")) == "")
                            {
                                dUCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dUCL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("UCL"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("CL")) == "")
                            {
                                dCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dCL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("CL"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("LCL")) == "")
                            {
                                dLCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dLCL = MPCF.ToDbl(out_node.GetList(0)[i].GetString("LCL"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")) == "")
                            {
                                dUCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dUCL2 = MPCF.ToDbl(out_node.GetList(0)[i].GetString("UCL2"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("CL2")) == "")
                            {
                                dCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dCL2 = MPCF.ToDbl(out_node.GetList(0)[i].GetString("CL2"));
                            }
                            if (MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")) == "")
                            {
                                dLCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dLCL2 = MPCF.ToDbl(out_node.GetList(0)[i].GetString("LCL2"));
                            }
                        }

                        if (Chart.IsUserInputCL == false && (Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.P && Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.U))
                        {
                            if (iGroupIndex == -1 || dUSL != dPrevUSL || dLSL != dPrevLSL || dUCL != dPrevUCL || dCL != dPrevCL || dLCL != dPrevLCL || dUCL2 != dPrevUCL2 || dCL2 != dPrevCL2 || dLCL2 != dPrevLCL2)
                            {
                                iGroupIndex++;
                            }
                        }
                        else
                        {
                            iGroupIndex++;
                        }

                        sGroupIndex = "Group" + iGroupIndex.ToString("0000");
                        if (Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.DELTAS)
                        {
                            if (Chart.SetSpecLimit(sGroupIndex, dUSL, dLSL, dTarget) == false)
                            {
                                return false;
                            }
                        }

                        if (Chart.SetXControlLimit(sGroupIndex, dUCL, dCL, dLCL) == false)
                        {
                            return false;
                        }
                        if (Chart.SetRControlLimit(sGroupIndex, dUCL2, dCL2, dLCL2) == false)
                        {
                            return false;
                        }

                        sLotIndex = "Lot" + iLotIndex.ToString("0000");
                        sTranTime = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME"));


                        if (MPCF.Trim(Chart.ResvField1) == "L")
                        {
                            sXAxis = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID"));
                        }
                        else
                        {
                            sXAxis = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));
                        }

                        switch (Chart.ChartType)
                        {
                            case SPCControlChart.modEnums.GRAPH_TYPE.XBARR:
                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")) : "") == "")
                                {
                                    dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("RANGE"));
                                }
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.XBARS:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) : "") == "")
                                {
                                    dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                                }
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.XRS:
                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")) : "") == "")
                                {
                                    dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("RANGE"));
                                }
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.P:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.PN:


                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.C:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.U:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) : "") == "")
                                {
                                    dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                                }
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.ZBARS:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")) : "") == "")
                                {
                                    dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"));
                                }

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) : "") == "")
                                {
                                    dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                                }
                                break;
                            case SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")) : "") == "")
                                {
                                    dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"));
                                }

                                if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) : "") == "")
                                {
                                    dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                                }
                                else
                                {
                                    dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                                }
                                break;
                            default:

                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                                break;
                        }

                        if (Chart.AddChartData(sGroupIndex, sLotIndex, MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")), dXData, dRdata) == false)
                        {
                            return false;
                        }

                        if (sTranTime != "")
                        {
                            if (Chart.AddDate(sGroupIndex, sLotIndex, MPCF.ToInt(sTranTime.Substring(0, 4)), MPCF.ToInt(sTranTime.Substring(4, 2)), MPCF.ToInt(sTranTime.Substring(6, 2)), MPCF.ToInt(sTranTime.Substring(8, 2)), MPCF.ToInt(sTranTime.Substring(10, 2)), MPCF.ToInt(sTranTime.Substring(12, 2))) == false)
                            {
                                return false;
                            }
                        }

                        if (Chart.SetSequence(sGroupIndex, sLotIndex, out_node.GetList(0)[i].GetInt("HIST_SEQ"), out_node.GetList(0)[i].GetInt("UNIT_SEQ"), out_node.GetList(0)[i].GetInt("EDC_COL_SEQ")) == false)
                        {
                            return false;
                        }

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE")) != "" || MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE2")) != "")
                        {
                            if (Chart.SetRunTestFlag(sLotIndex, MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE")), MPCF.Trim(out_node.GetList(0)[i].GetChar("OOC_TYPE2"))) == false)
                            {
                                return false;
                            }
                        }
                        for (j = 0; j <= out_node.GetList(0)[i].GetList(0).Count - 1; j++)
                        {
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetList(0)[j].GetString("VALUE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetList(0)[j].GetString("VALUE")) : "") == "")
                            {
                                dValue = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dValue = MPCF.ToDbl(out_node.GetList(0)[i].GetList(0)[j].GetString("VALUE"));
                            }
                            if (Chart.AddChartRawData(sGroupIndex, sLotIndex, sXAxis, dValue) == false)
                            {
                                return false;
                            }
                        }

                        dPrevUSL = dUSL;
                        dPrevLSL = dLSL;
                        dPrevUCL = dUCL;
                        dPrevCL = dCL;
                        dPrevLCL = dLCL;
                        dPrevUCL2 = dUCL2;
                        dPrevCL2 = dCL2;
                        dPrevLCL2 = dLCL2;

                        iLotIndex++;

                    }
                }
                if (Chart.RefreshChartData() == false)
                {
                    return false;
                }
                
                Chart.Refresh();
                
                this.btnReset.Enabled = false;
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.View_ControlChart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // Set_Data()
        //       - Set data by graph type
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void Set_Data()
        {
            
            try
            {
                modSPCFunctions.SetDatabyGraphType(spdDataInfo, (Miracom.CliFrx.eGraphType)this.cboGraphType.SelectedIndex, 
                                                   MPCF.ToInt(this.spdChartInfo.Sheets[0].Cells[SAMPLE_SIZE_COL, 1].Text),
                                                   VALUE_START_COL, AVERAGE_COL);
                modSPCFunctions.SetValuePrompt(spdDataInfo, cdvChartID.Text, MPCF.ToInt(this.spdChartInfo.Sheets[0].Cells[SAMPLE_SIZE_COL, 1].Text), VALUE_START_COL);
                
                if (this.cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.XBARR) || 
                    this.cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.XBARS) || 
                    this.cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.XRS) || 
                    cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.ZBARS) || 
                    this.cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.DELTAS))
                {
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2].Visible = true;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2 + 1].Visible = true;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2 + 2].Visible = true;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_OOC_TYPE_2].Visible = true;
                }
                else
                {
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2].Visible = false;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2 + 1].Visible = false;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_UCL2 + 2].Visible = false;
                    spdDataInfo.Sheets[0].Columns[RAW_COL_OOC_TYPE_2].Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.Set_Data()\n" + ex.Message);
            }
            
        }
        
        // SetControlChartSampleData()
        //       - Sample Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool SetControlChartSampleData()
        {
            
            try
            {
                // Control Chart
                Chart.InitDataSet();
                
                Random rand = new Random();
                double dRandomValue;
                
                Chart.SampleSize = 5;
                Chart.ChartType = SPCControlChart.modEnums.GRAPH_TYPE.XBARR;
                
                string sGroupIndexKey;
                string sIndexKey;
                int i;
                int j;
                int k;
                int iIndex;
                DateTime dtDate = DateTime.Now;
                
                iIndex = 1;
                for (i = 1; i <= 100; i++)
                {
                    sGroupIndexKey = "Group" + i.ToString();
                    for (j = 1; j <= 50; j++)
                    {
                        sIndexKey = "Lot" + iIndex.ToString();
                        for (k = 1; k <= Chart.SampleSize; k++)
                        {
                            dRandomValue = rand.Next(48, 52);
                            dRandomValue += rand.NextDouble();
                            Chart.AddChartRawData(sGroupIndexKey, sIndexKey, sIndexKey, dRandomValue);
                        }
                        dtDate = dtDate.AddSeconds(75);
                        Chart.AddDate(sGroupIndexKey, sIndexKey, dtDate.Year, dtDate.Month, dtDate.Day, dtDate.Hour, dtDate.Minute, dtDate.Second);
                        iIndex++;
                    }
                }
                
                if (Chart.SetSpecLimit(52, 48, 0) == false)
                {
                    return false;
                }
                
                // Title
                Chart.MainTitle = "Xbar-R Chart";
                Chart.SubTitle = "Sample Data Test";
                Chart.UnitTitle = "mm";
                Chart.BottomTitle = "R - Chart";
                
                // Options
                Chart.IsViewRChart = true;
                Chart.IsViewLotID = true;
                Chart.IsViewDate = true;
                Chart.IsUserInputCL = false;
                Chart.IsViewSpecLimit = true;
                Chart.IsViewXUCL = true;
                Chart.IsViewXCL = true;
                Chart.IsViewXLCL = true;
                Chart.IsViewRUCL = true;
                Chart.IsViewRCL = true;
                Chart.IsViewRLCL = true;
                Chart.IsViewRunTestText = true;
                Chart.MaxLotCount = 100;
                
                // Run Test
                if (Chart.SetXRunTestFlag("Lot3", "A") == false)
                {
                    return false;
                }
                if (Chart.SetXRunTestFlag("Lot24", "B") == false)
                {
                    return false;
                }
                if (Chart.SetXRunTestFlag("Lot48", "D") == false)
                {
                    return false;
                }
                
                if (Chart.SetRRunTestFlag("Lot5", "F") == false)
                {
                    return false;
                }
                if (Chart.SetRRunTestFlag("Lot36", "B") == false)
                {
                    return false;
                }
                if (Chart.SetRRunTestFlag("Lot67", "D") == false)
                {
                    return false;
                }
                
                if (Chart.RefreshChartData() == false)
                {
                    return false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.SetControlChartSampleData()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ChartIDSelected()
        //       - Action after Char ID Selected
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool ChartIDSelected()
        {
            
            try
            {
                int iVer = StatGlobalVariable.INTEGER_NULL_DATA;
                
                InitChart();
                ClearChartInfo();
                MPCF.ClearList(spdDataInfo, true);
                if (cdvChartID.Text == "")
                {
                    return false;
                }
                if (View_Chart() == false)
                {
                    return false;
                }
                if (SetChartOptions() == false)
                {
                    return false;
                }
                if (MPCR.Find_Spec_Version('1', cdvChartID.Text, ref iVer, true) == true)
                {
                    if (View_Spec(iVer) == false)
                    {
                        return false;
                    }
                }
                Set_Data();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.ChartIDSelected()\n" + ex.Message);
                return false;
            }

            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvChartID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        private void ChartInfo()
        {
            
            try
            {
                if (ChartIDSelected() == true)
                {
                    btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.ChartInfo()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        private void frmSPCTranControlChart_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);

                MPCF.FieldClear(this.pnlFillTop);

                //uccStart.Value = DateTime.Now.AddMonths(- 1);
                uccStart.Value = DateTime.Now;
                //udtStart.Value = "000000";
                udtStart.Value = DateTime.Now.AddHours(-4);

                uccEnd.Value = DateTime.Now;
                //udtEnd.Value = "235959";
                udtEnd.Value = DateTime.Now;

                //.ToString("HHmmss")

                modSPCFunctions.SetGraphList(cboGraphType);
                InitChart();
                
                pnlFillRight.Visible = chkViewChartOptions.Checked;
                cdvChartID.Text = modSPCFunctions.GetFilterKey();
                
                int i;
                for (i = 0; i <= modSPCConstants.VALUE_COUNT - 1; i++)
                {
                    spdDataInfo.Sheets[0].ColumnHeader.Cells[1, VALUE_START_COL + i].Value = i + 1;
                }
                
                Chart.ContextMenu.MenuItems[1].Enabled = modSPCFunctions.CheckAvailableFunction("SPC5001");
                Chart.ContextMenu.MenuItems[0].Enabled = modSPCFunctions.CheckAvailableFunction("SPC4003");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.frmSPCTranControlChart_Load()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCTranControlChart_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    if(MPCF.Trim(MPGV.gsChartID) != "")
                    {
                        cdvChartID.Text = MPGV.gsChartID;
                        ChartInfo();
                    }

                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.frmSPCTranControlChart_Activated()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvChartID.Init();
                MPCF.InitListView(cdvChartID.GetListView);
                cdvChartID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("GraphType", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartID.SelectedSubItemIndex = 0;
                cdvChartID.SelectedDescIndex = 2;
                SPCLIST.ViewChartList(cdvChartID.GetListView, '2', "", 0,"", "", "", ' ', ' ', MPCF.Trim(cdvChartID.Text), "", -1, -1, null, "");
                cdvChartID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.cdvChartID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                if (ChartIDSelected() == true)
                {
                    btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.cdvChartID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                /* Added By YJJUNG 140617 Control Chart ÀÇ PrecisionÀÌ View ¹öÆ° Å¬¸¯½Ã Àû¿ë ¾ÈµÇ´Â bug Fix */
                if (View_Chart() == false)
                {
                    return;
                }
                /* Added End */
                MPCF.ClearList(spdDataInfo, true);
                if (CheckCondition() == false)
                {
                    return;
                }
                if (View_ControlChart() == false)
                {
                    InitChart();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void Chart_ChartZoomed(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCR.ChangeControlEnabled(this, btnReset, true);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.Chart_ChartZoomed()\n" + ex.Message);
            }
            
        }
        
        private void btnReset_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (Chart.RestoreChart() == false)
                {
                    return;
                }
                this.btnReset.Enabled = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.btnReset_Click()\n" + ex.Message);
            }
            
        }
        
        private void chkViewLotID_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewLotID = chkViewLotID.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.chkViewLotID_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkViewDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewDate = chkViewDate.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.chkViewDate_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkViewSpecLimit_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewSpecLimit = chkViewSpecLimit.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.chkViewSpecLimit_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkViewRChart_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewRChart = chkViewRChart.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.chkViewRChart_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkViewAZone_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewAZone = chkViewAZone.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.chkViewAZone_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkViewBZone_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewBZone = chkViewBZone.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.chkViewBZone_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkViewCZone_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewCZone = chkViewCZone.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.chkViewCZone_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkViewRuleCheck_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewRunTestText = chkViewRuleCheck.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.chkViewRuleCheck_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkAutoCalControlLimit_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsUserInputCL = !(chkAutoCalControlLimit.Checked);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.chkViewRuleCheck_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnRedraw_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.CheckNumeric(this.txtMaxLotCount.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                    this.txtMaxLotCount.SelectAll();
                    this.txtMaxLotCount.Focus();
                    return;
                }
                else
                {
                    if (MPCF.ToInt(this.txtMaxLotCount.Text) <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        this.txtMaxLotCount.SelectAll();
                        this.txtMaxLotCount.Focus();
                        return;
                    }
                }
                
                this.btnReset.Enabled = false;
                Chart.MaxLotCount = MPCF.ToInt(this.txtMaxLotCount.Text);
                Chart.StartLotPos = 0;
                Chart.IsZoomChart = false;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("frmSPCTranControlChart.btnRedraw_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void Chart_MouseButtonDown(object sender, SPCControlChart.MouseButtonDown_EventArgs e)
        {
            
            try
            {
                string sFromTime;
                string sToTime;
                char c_step;
                sFromTime = ((DateTime)(uccStart.Value)).ToString("yyyyMMdd") + ((DateTime)(udtStart.Value)).ToString("HHmmss");
                sToTime = ((DateTime)(uccEnd.Value)).ToString("yyyyMMdd") + ((DateTime)(udtEnd.Value)).ToString("HHmmss");
                
                if (e.UnitSeq == 0)
                {
                    c_step = '2';
                }
                else
                {
                    c_step = '3';
                }
                
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (SPCLIST.ViewSPCEDCData(spdDataInfo, c_step, cdvChartID.Text, sFromTime, sToTime, giPrecision, AVERAGE_COL, MPCF.ToInt(this.spdChartInfo.Sheets[0].Cells[UNIT_COUNT_COL, 1].Text), MPCF.ToChar(this.spdChartInfo.Sheets[0].Cells[USE_UNIT_COL, 1].Text), "N", e.HistSeq, e.UnitSeq, false, ' ') == false)
                    {
                        return;
                    }
                }
                
                if (this.spdChartInfo.Sheets[0].Cells[LOT_OR_RES_COL, 1].Text == "L")
                {
                    spdDataInfo.Sheets[0].Columns[LOTID_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[MATID_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[MATDESC_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[MATVER_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[FLOW].Visible = true;
                    spdDataInfo.Sheets[0].Columns[OPER].Visible = true;
                    spdDataInfo.Sheets[0].Columns[PROCOPER_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[PROCRES_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[SUBRES_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[EVENT_COL].Visible = false;
                }
                else if (this.spdChartInfo.Sheets[0].Cells[LOT_OR_RES_COL, 1].Text == "R")
                {
                    spdDataInfo.Sheets[0].Columns[LOTID_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[MATID_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[MATDESC_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[MATVER_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[FLOW].Visible = false;
                    spdDataInfo.Sheets[0].Columns[OPER].Visible = false;
                    spdDataInfo.Sheets[0].Columns[PROCOPER_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[PROCRES_COL].Visible = false;
                    spdDataInfo.Sheets[0].Columns[SUBRES_COL].Visible = true;
                    spdDataInfo.Sheets[0].Columns[EVENT_COL].Visible = true;
                }
                
                if (Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.P || Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.PN || Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.C || Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.U)
                {
                    int i;
                    int iCol;
                    double dUCL;
                    double dCL;
                    double dLCL;
                    if (e.UnitSeq == 0)
                    {
                        for (i = 0; i <= spdDataInfo.Sheets[0].RowCount - 1; i++)
                        {
                            dUCL = e.UCL;
                            if (dUCL != StatGlobalVariable.DOUBLE_NULL_DATA)
                            {
                                iCol = MPCF.GetSpreadCol(spdDataInfo, "UCL", 0);
                                if (iCol != - 1)
                                {
                                    spdDataInfo.Sheets[0].SetValue(i, MPCF.GetSpreadCol(spdDataInfo, "UCL", 0), MPCF.SetPrecision(dUCL.ToString(), giPrecision));
                                }
                            }
                            dCL = e.CL;
                            if (dCL != StatGlobalVariable.DOUBLE_NULL_DATA)
                            {
                                iCol = MPCF.GetSpreadCol(spdDataInfo, "CL", 0);
                                if (iCol != - 1)
                                {
                                    spdDataInfo.Sheets[0].SetValue(i, MPCF.GetSpreadCol(spdDataInfo, "CL", 0), MPCF.SetPrecision(dCL.ToString(), giPrecision));
                                }
                            }
                            dLCL = e.LCL;
                            if (dLCL != StatGlobalVariable.DOUBLE_NULL_DATA)
                            {
                                iCol = MPCF.GetSpreadCol(spdDataInfo, "LCL", 0);
                                if (iCol != - 1)
                                {
                                    spdDataInfo.Sheets[0].SetValue(i, MPCF.GetSpreadCol(spdDataInfo, "LCL", 0), MPCF.SetPrecision(dLCL.ToString(), giPrecision));
                                }
                            }
                        }
                    }
                    else
                    {
                        dUCL = e.UCL;
                        if (dUCL != StatGlobalVariable.DOUBLE_NULL_DATA)
                        {
                            iCol = MPCF.GetSpreadCol(spdDataInfo, "UCL", 0);
                            if (iCol != - 1)
                            {
                                spdDataInfo.Sheets[0].SetValue(0, MPCF.GetSpreadCol(spdDataInfo, "UCL", 0), MPCF.SetPrecision(dUCL.ToString(), giPrecision));
                            }
                        }
                        dCL = e.CL;
                        if (dCL != StatGlobalVariable.DOUBLE_NULL_DATA)
                        {
                            iCol = MPCF.GetSpreadCol(spdDataInfo, "CL", 0);
                            if (iCol != - 1)
                            {
                                spdDataInfo.Sheets[0].SetValue(0, MPCF.GetSpreadCol(spdDataInfo, "CL", 0), MPCF.SetPrecision(dCL.ToString(), giPrecision));
                            }
                        }
                        dLCL = e.LCL;
                        if (dLCL != StatGlobalVariable.DOUBLE_NULL_DATA)
                        {
                            iCol = MPCF.GetSpreadCol(spdDataInfo, "LCL", 0);
                            if (iCol != - 1)
                            {
                                spdDataInfo.Sheets[0].SetValue(0, MPCF.GetSpreadCol(spdDataInfo, "LCL", 0), MPCF.SetPrecision(dLCL.ToString(), giPrecision));
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.Chart_MouseButtonDown()\n" + ex.Message);
            }
            
        }
        
        private void chkViewChartOptions_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                pnlFillRight.Visible = chkViewChartOptions.Checked;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.chkViewChartOptions_CheckedChanged()\n" + ex.Message);
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

                ((frmSPCTranCapability) form).uccStart.Value = this.uccStart.Value;
                ((frmSPCTranCapability) form).udtStart.Value = this.udtStart.Value;
                ((frmSPCTranCapability) form).uccEnd.Value = this.uccEnd.Value;
                ((frmSPCTranCapability) form).udtEnd.Value = this.udtEnd.Value;
                ((frmSPCTranCapability) form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCTranCapability) form).cdvChartID.Text != "")
                {
                    ((frmSPCTranCapability) form).ChartIDSelected();
                    ((frmSPCTranCapability) form).btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.btnHistogram_Click()\n" + ex.Message);
            }
            
        }
        
        private void Chart_ViewOOCInfo(object sender, SPCControlChart.MouseButtonDown_EventArgs e)
        {
            
            try
            {
                frmSPCTranUpdateOOCHistory form = new frmSPCTranUpdateOOCHistory();
                form.gcStep = '2';
                form.txtChart.Text = cdvChartID.Text;
                form.giEDCHistSeq = e.HistSeq;
                form.giUnitSeq = e.UnitSeq;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // Nothing
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.Chart_ViewOOCInfo()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            try
            {
                int iVer = StatGlobalVariable.INTEGER_NULL_DATA;
                
                InitChart();
                ClearChartInfo();
                MPCF.ClearList(spdDataInfo, true);
                if (cdvChartID.Text == "")
                {
                    return;
                }
                if (View_Chart() == false)
                {
                    return;
                }
                if (SetChartOptions() == false)
                {
                    return;
                }
                if (MPCR.Find_Spec_Version('1', cdvChartID.Text, ref iVer, true) == true)
                {
                    if (View_Spec(iVer) == false)
                    {
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnViewRawData_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
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

                
                ((frmSPCViewEDCData) form).uccStart.Value = this.uccStart.Value;
                ((frmSPCViewEDCData) form).udtStart.Value = this.udtStart.Value;
                ((frmSPCViewEDCData) form).uccEnd.Value = this.uccEnd.Value;
                ((frmSPCViewEDCData) form).udtEnd.Value = this.udtEnd.Value;
                ((frmSPCViewEDCData) form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCViewEDCData) form).cdvChartID.Text != "")
                {
                    ((frmSPCViewEDCData) form).Set_Data();
                    ((frmSPCViewEDCData) form).btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.btnViewRawData_Click()\n" + ex.Message);
            }
            
        }
        
        private void Chart_ChangeEDCData(object sender, SPCControlChart.MouseButtonDown_EventArgs e)
        {
            try
            {
                int i;
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCTranChangeEDCData");
                    if (form == null)
                    {
                        form = new frmSPCTranChangeEDCData();
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

                DateTime dtTranTime = new DateTime(MPCF.ToInt(MPCF.Mid(e.TransTime, 0, 4)), MPCF.ToInt(MPCF.Mid(e.TransTime, 4, 2)), MPCF.ToInt(MPCF.Mid(e.TransTime, 6, 2))
                    ,MPCF.ToInt(MPCF.Mid(e.TransTime, 8, 2)), MPCF.ToInt(MPCF.Mid(e.TransTime, 10, 2)),MPCF.ToInt(MPCF.Mid(e.TransTime, 12, 2))) ;
                
                ((frmSPCTranChangeEDCData)form).uccStart.Value = dtTranTime;
                ((frmSPCTranChangeEDCData) form).udtStart.Value = "000000";
                ((frmSPCTranChangeEDCData)form).uccEnd.Value = dtTranTime;
                ((frmSPCTranChangeEDCData) form).udtEnd.Value = "235959";
                ((frmSPCTranChangeEDCData) form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCTranChangeEDCData) form).cdvChartID.Text != "")
                {
                    ((frmSPCTranChangeEDCData) form).cdvChartID.Text = cdvChartID.Text;
                    ((frmSPCTranChangeEDCData) form).ChartSelected();
                    ((frmSPCTranChangeEDCData) form).btnView.PerformClick();
                    
                    for (i = 0; i <= ((frmSPCTranChangeEDCData) form).spdData.Sheets[0].RowCount - 1; i++)
                    {
                        if ((int)((frmSPCTranChangeEDCData)form).spdData.Sheets[0].Cells[i, 1].Value == e.HistSeq
                            && (int)((frmSPCTranChangeEDCData)form).spdData.Sheets[0].Cells[i, 2].Value == e.UnitSeq)
                        {
                            ((frmSPCTranChangeEDCData)form).spdData.Sheets[0].ActiveRowIndex = i;
                            ((frmSPCTranChangeEDCData)form).spdData.Sheets[0].AddSelection(i, 0, 1, ((frmSPCTranChangeEDCData)form).spdData.Sheets[0].ColumnCount);
                            ((frmSPCTranChangeEDCData)form).spdData.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
                            ((frmSPCTranChangeEDCData)form).ViewSelectData(i);
                            return;                            
                        }
                    }
                    
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.Chart_ChangeEDCData()\n" + ex.Message);
            }
            
        }
        
        private void btnCopyImage_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (Chart.CopyImage() == true)
                {
                    //Do Nothing
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.btnCopyImage_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnSaveImage_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Png Image|*.png";
                dlg.Title = "Save an Image File";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Chart.SaveImage(dlg.FileName);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.btnSaveImage_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnPrint_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (Chart.Print() == true)
                {
                    //Do Nothing
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.btnPrint_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnFiltering_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                frmSPCViewChartList form = new frmSPCViewChartList();
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.lisChart.SelectedItems.Count > 0)
                    {
                        cdvChartID.Text = form.lisChart.SelectedItems[0].SubItems[1].Text;
                        ChartInfo();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.btnFiltering_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (cdvChartID.Text != "")
                    {
                        if (ChartIDSelected() == true)
                        {
                            btnView.PerformClick();
                        }
                    }
                }
               

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.cdvChartID_TextBoxKeyPress()\n" + ex.Message);
            }

        }
        
    }
    
    
    //#End If
    
}
