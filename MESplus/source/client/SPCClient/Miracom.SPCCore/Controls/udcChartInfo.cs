
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
using FarPoint.Win.Spread;
using Miracom.TRSCore;
//#If _SPC = True Then
//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : udcChartInfo.vb
//   Description : View Chart Information Control
//
//   SPC Version : 1.0.0
//
//   Function List
//       - ViewControlChartEvent : View Control Chart mashaling
//       - ViewChartInfo : View Chart Information
//       - CheckCondition : Check the conditions before transaction
//       - View_Result : View Result of Data Collection
//       - CollectEDCData : Collect EDC Data
//       - Result_Management : Manage Result of Data Collection
//       - SetLockSpread : Set Lock Property of Spread
//       - ClearControl : Clear Controls
//       - ViewControlChart : View Control Chart
//       - ResetChart :Reset Chart
//       - SetChartTitle :Set Chart Title
//       - InitChart :Set Chart Title
//       - ClearBackColor :Clear Back Color of Spread
//       - SetChartOption :Set Chart Option
//
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-11-01 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.SPCCore
{
    public class udcChartInfo : System.Windows.Forms.UserControl
    {
        
        
        #region " Windows Form auto generated code "
        
        delegate bool ViewControlChartDelegate();
        delegate void ChartRefreshDelegate();
        
        private ViewControlChartDelegate _ViewControlChartDelegate;
        private ChartRefreshDelegate _ChartRefreshDelegate;
        
        public udcChartInfo()
        {
            
            
            InitializeComponent();
            
            
            
            _ViewControlChartDelegate = new ViewControlChartDelegate( ViewControlChart);
            _ChartRefreshDelegate = new ChartRefreshDelegate(ChartRefresh);
            
        }
        
        //UserControl?Ä DisposeÎ•??¨Ï†ï?òÌïò??Íµ¨ÏÑ± ?îÏÜå Î™©Î°ù???ïÎ¶¨?©Îãà??
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
        



        internal System.Windows.Forms.Panel pnlCenter;
        internal System.Windows.Forms.GroupBox grpComment;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtComment;
        internal System.Windows.Forms.Label lblComment;
        internal System.Windows.Forms.Panel pnlData;
        internal System.Windows.Forms.GroupBox grpData;
        internal FarPoint.Win.Spread.FpSpread spdData;
        internal FarPoint.Win.Spread.SheetView spdData_Sheet1;
        internal System.Windows.Forms.GroupBox grpControlChart;
        internal System.Windows.Forms.Splitter splMid;
        internal System.Windows.Forms.Panel pnlChart;
        internal SPCControlChart.SPCControlChart Chart;
        internal System.Windows.Forms.GroupBox grpChartInfo;
        internal System.Windows.Forms.Button btnChartOption;
        internal System.Windows.Forms.Panel pnlChartOption;
        internal System.Windows.Forms.GroupBox grpChartOption;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewRuleCheck;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewCZone;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewBZone;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewAZone;
        internal Miracom.SPCCore.udcChart ctrlChartData;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewSpec;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAutoCalControlLimit;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2019 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2020 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2021 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2022 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2023 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2024 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2025 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2026 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2027 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2028 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2029 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2030 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2031 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2032 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2033 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2034 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2035 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2036 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2037 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2038 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2039 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2040 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2041 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2042 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2043 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2044 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2045 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2046 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2047 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2048 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2049 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2050 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2051 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2052 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2053 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2054 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2055 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2056 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2057 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2058 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2059 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2060 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2061 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2062 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2063 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2064 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2065 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2066 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2067 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2068 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2069 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2070 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2071 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2072 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2073 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2074 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2075 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2076 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2077 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2078 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2079 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2080 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2081 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2082 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2083 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2084 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2085 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2086 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2087 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2088 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2089 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2090 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2091 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2092 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2093 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2094 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2095 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2096 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2097 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2098 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2099 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2100 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2101 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2102 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2103 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2104 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2105 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2106 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2107 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2108 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2109 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2110 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2111 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2112 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2113 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2114 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2115 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2116 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2117 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2118 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2119 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2120 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2121 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2122 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2123 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2124 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2125 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2126 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2127 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2128 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2129 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2130 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2131 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2132 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2133 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2134 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2135 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2136 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2137 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2138 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2139 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2140 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2141 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2142 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2143 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2144 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2145 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2146 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2147 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2148 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2149 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2150 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2151 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2152 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2153 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2154 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2155 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2156 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2157 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2158 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2159 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2160 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2161 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2162 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2163 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2164 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2165 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2166 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2167 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2168 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2169 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2170 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2171 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2172 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2173 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2174 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2175 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2176 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2177 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2178 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2179 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2180 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2181 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2182 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2183 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2184 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2185 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2186 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2187 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2188 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2189 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2190 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2191 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2192 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2193 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2194 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2195 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2196 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2197 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2198 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2199 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2200 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2201 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2202 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2203 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2204 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2205 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2206 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2207 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2208 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2209 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2210 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2211 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2212 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2213 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2214 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2215 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2216 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2217 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2218 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2219 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2220 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2221 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2222 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2223 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2224 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2225 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2226 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2227 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2228 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2229 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2230 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2231 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2232 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2233 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2234 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2235 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2236 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2237 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2238 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2239 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2240 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2241 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2242 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2243 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2244 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2245 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2246 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2247 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2248 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2249 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2250 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2251 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2252 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2253 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2254 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2255 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2256 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2257 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2258 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2259 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2260 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2261 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2262 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2263 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2264 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2265 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2266 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2267 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2268 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2269 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2270 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2271 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2272 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2273 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2274 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2275 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2276 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2277 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2278 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2279 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2280 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2281 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2282 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2283 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2284 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2285 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2286 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2287 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2288 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2289 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2290 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2291 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2292 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2293 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2294 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2295 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2296 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2297 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2298 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2299 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2300 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2301 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2302 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2303 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2304 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2305 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2306 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2307 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2308 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2309 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2310 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2311 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2312 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2313 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2314 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2315 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2316 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2317 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2318 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2319 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2320 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2321 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2322 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2323 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2324 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2325 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2326 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2327 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2328 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2329 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2330 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2331 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2332 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2333 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2334 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2335 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2336 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2337 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2338 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2339 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2340 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2341 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2342 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2343 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2344 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2345 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2346 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2347 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2348 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2349 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2350 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2351 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2352 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2353 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2354 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2355 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2356 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2357 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2358 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2359 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2360 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2361 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2362 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2363 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2364 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2365 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2366 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2367 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2368 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2369 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2370 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2371 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2372 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2373 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2374 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2375 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2376 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2377 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2378 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2379 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2380 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2381 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2382 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2383 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2384 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2385 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2386 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2387 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2388 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2389 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2390 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2391 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2392 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2393 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2394 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2395 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2396 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2397 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2398 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2399 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2400 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2401 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2402 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2403 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2404 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2405 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2406 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2407 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2408 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2409 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2410 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2411 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2412 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2413 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2414 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2415 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2416 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2417 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2418 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2419 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2420 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2421 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2422 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2423 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2424 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2425 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2426 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2427 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2428 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2429 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2430 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2431 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2432 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2433 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2434 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2435 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2436 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2437 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2438 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2439 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2440 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2441 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2442 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2443 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2444 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2445 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2446 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2447 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2448 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2449 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2450 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2451 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2452 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2453 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2454 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2455 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2456 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2457 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2458 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2459 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2460 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2461 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2462 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2463 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2464 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2465 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2466 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2467 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2468 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2469 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2470 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2471 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2472 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2473 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2474 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2475 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2476 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2477 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2478 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2479 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2480 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2481 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2482 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2483 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2484 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2485 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2486 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2487 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2488 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2489 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2490 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2491 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2492 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2493 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2494 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2495 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2496 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2497 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2498 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2499 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2500 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2501 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2502 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2503 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2504 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2505 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2506 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2507 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2508 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2509 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2510 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2511 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2512 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2513 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2514 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2515 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2516 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2517 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2518 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2519 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2520 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2521 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2522 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2523 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2524 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2525 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2526 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2527 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2528 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2529 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2530 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2531 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2532 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2533 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2534 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2535 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2536 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2537 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2538 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2539 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2540 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2541 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2542 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2543 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2544 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2545 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2546 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2547 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2548 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2549 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2550 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2551 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2552 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2553 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2554 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2555 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2556 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2557 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2558 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2559 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2560 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2561 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2562 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2563 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2564 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2565 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2566 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2567 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2568 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2569 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2570 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2571 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2572 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2573 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2574 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2575 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2576 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2577 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2578 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2579 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2580 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2581 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2582 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2583 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2584 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2585 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2586 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2587 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2588 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2589 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2590 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2591 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2592 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2593 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2594 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2595 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2596 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2597 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2598 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2599 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2600 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2601 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2602 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2603 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2604 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2605 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2606 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2607 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2608 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2609 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2610 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2611 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2612 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2613 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2614 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2615 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2616 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2617 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2618 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2619 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2620 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2621 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2622 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2623 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2624 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2625 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2626 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2627 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2628 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2629 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2630 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2631 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2632 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2633 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2634 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2635 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2636 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2637 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2638 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2639 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2640 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2641 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2642 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2643 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2644 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2645 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2646 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2647 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2648 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2649 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2650 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2651 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2652 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2653 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2654 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2655 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2656 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2657 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2658 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2659 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2660 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2661 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2662 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2663 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2664 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2665 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2666 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2667 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2668 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2669 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2670 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2671 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2672 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2673 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2674 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2675 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2676 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2677 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2678 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2679 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2680 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2681 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2682 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2683 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2684 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2685 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2686 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2687 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2688 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2689 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2690 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2691 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2692 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2693 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2694 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2695 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2696 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2697 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2698 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2699 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2700 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2701 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2702 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2703 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2704 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2705 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2706 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2707 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2708 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2709 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2710 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2711 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2712 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2713 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2714 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2715 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2716 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2717 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2718 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2719 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2720 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2721 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2722 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2723 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2724 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2725 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2726 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2727 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2728 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2729 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2730 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2731 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2732 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2733 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2734 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2735 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2736 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2737 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2738 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2739 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2740 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2741 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2742 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2743 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2744 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2745 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2746 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2747 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2748 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2749 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2750 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2751 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2752 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2753 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2754 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2755 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2756 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2757 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2758 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2759 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2760 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2761 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2762 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2763 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2764 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2765 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2766 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2767 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2768 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2769 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2770 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2771 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2772 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2773 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2774 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2775 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2776 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2777 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2778 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2779 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2780 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2781 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2782 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2783 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2784 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2785 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2786 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2787 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2788 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2789 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2790 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2791 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2792 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2793 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2794 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2795 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2796 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2797 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2798 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2799 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2800 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2801 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2802 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2803 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2804 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2805 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2806 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2807 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2808 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2809 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2810 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2811 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2812 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2813 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2814 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2815 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2816 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2817 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2818 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2819 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2820 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2821 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2822 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2823 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2824 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2825 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2826 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2827 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2828 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2829 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2830 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2831 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2832 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2833 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2834 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2835 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2836 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2837 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2838 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2839 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2840 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2841 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2842 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2843 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2844 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2845 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2846 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2847 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2848 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2849 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2850 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2851 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2852 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2853 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2854 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2855 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2856 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2857 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2858 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2859 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2860 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2861 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2862 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2863 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2864 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2865 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2866 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2867 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2868 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2869 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2870 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2871 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2872 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2873 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2874 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2875 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2876 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2877 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2878 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2879 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2880 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2881 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2882 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2883 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2884 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2885 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2886 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2887 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2888 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2889 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2890 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2891 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2892 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2893 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2894 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2895 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2896 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2897 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2898 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2899 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2900 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2901 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2902 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2903 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2904 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2905 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2906 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2907 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2908 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2909 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2910 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2911 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2912 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2913 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2914 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2915 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2916 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2917 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2918 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2919 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2920 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2921 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2922 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2923 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2924 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2925 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2926 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2927 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2928 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2929 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2930 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2931 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2932 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2933 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2934 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2935 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2936 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2937 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2938 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2939 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2940 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2941 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2942 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2943 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2944 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2945 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2946 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2947 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2948 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2949 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2950 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2951 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2952 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2953 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2954 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2955 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2956 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2957 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2958 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2959 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2960 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2961 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2962 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2963 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2964 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2965 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2966 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2967 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2968 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2969 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2970 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2971 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2972 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2973 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2974 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2975 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2976 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2977 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2978 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2979 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2980 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2981 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2982 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2983 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2984 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2985 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2986 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2987 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2988 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2989 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2990 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2991 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2992 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2993 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2994 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2995 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2996 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2997 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2998 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2999 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3000 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3001 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3002 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3003 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3004 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3005 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3006 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3007 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3008 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3009 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3010 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3011 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3012 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3013 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3014 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3015 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3016 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3017 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3018 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3019 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3020 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3021 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3022 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3023 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3024 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3025 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3026 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3027 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlData = new System.Windows.Forms.Panel();
            this.splMid = new System.Windows.Forms.Splitter();
            this.grpControlChart = new System.Windows.Forms.GroupBox();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.btnChartOption = new System.Windows.Forms.Button();
            this.pnlChartOption = new System.Windows.Forms.Panel();
            this.grpChartOption = new System.Windows.Forms.GroupBox();
            this.chkAutoCalControlLimit = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewSpec = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewRuleCheck = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewCZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewBZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewAZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.Chart = new SPCControlChart.SPCControlChart();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpChartInfo = new System.Windows.Forms.GroupBox();
            this.ctrlChartData = new Miracom.SPCCore.udcChart();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblComment = new System.Windows.Forms.Label();
            this.pnlCenter.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.grpControlChart.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlChartOption.SuspendLayout();
            this.grpChartOption.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.grpChartInfo.SuspendLayout();
            this.grpComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            this.SuspendLayout();
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("±º∏≤", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("±º∏≤", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlData);
            this.pnlCenter.Controls.Add(this.grpChartInfo);
            this.pnlCenter.Controls.Add(this.grpComment);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(3, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(736, 268);
            this.pnlCenter.TabIndex = 0;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.splMid);
            this.pnlData.Controls.Add(this.grpControlChart);
            this.pnlData.Controls.Add(this.grpData);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(0, 98);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(736, 130);
            this.pnlData.TabIndex = 13;
            // 
            // splMid
            // 
            this.splMid.Location = new System.Drawing.Point(470, 0);
            this.splMid.MinExtra = 300;
            this.splMid.Name = "splMid";
            this.splMid.Size = new System.Drawing.Size(2, 130);
            this.splMid.TabIndex = 15;
            this.splMid.TabStop = false;
            // 
            // grpControlChart
            // 
            this.grpControlChart.Controls.Add(this.pnlChart);
            this.grpControlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControlChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpControlChart.Location = new System.Drawing.Point(470, 0);
            this.grpControlChart.Name = "grpControlChart";
            this.grpControlChart.Size = new System.Drawing.Size(266, 130);
            this.grpControlChart.TabIndex = 14;
            this.grpControlChart.TabStop = false;
            // 
            // pnlChart
            // 
            this.pnlChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlChart.Controls.Add(this.btnChartOption);
            this.pnlChart.Controls.Add(this.pnlChartOption);
            this.pnlChart.Controls.Add(this.Chart);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(3, 16);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(260, 111);
            this.pnlChart.TabIndex = 65;
            // 
            // btnChartOption
            // 
            this.btnChartOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChartOption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChartOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChartOption.Location = new System.Drawing.Point(243, 1);
            this.btnChartOption.Name = "btnChartOption";
            this.btnChartOption.Size = new System.Drawing.Size(14, 15);
            this.btnChartOption.TabIndex = 67;
            this.btnChartOption.TabStop = false;
            this.btnChartOption.Tag = "VIEW";
            this.btnChartOption.Text = "¢∑";
            this.btnChartOption.Click += new System.EventHandler(this.btnChartOption_Click);
            this.btnChartOption.GotFocus += new System.EventHandler(this.btnChartOption_GotFocus);
            // 
            // pnlChartOption
            // 
            this.pnlChartOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChartOption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlChartOption.Controls.Add(this.grpChartOption);
            this.pnlChartOption.Location = new System.Drawing.Point(120, 1);
            this.pnlChartOption.Name = "pnlChartOption";
            this.pnlChartOption.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlChartOption.Size = new System.Drawing.Size(136, 127);
            this.pnlChartOption.TabIndex = 66;
            this.pnlChartOption.Visible = false;
            // 
            // grpChartOption
            // 
            this.grpChartOption.Controls.Add(this.chkAutoCalControlLimit);
            this.grpChartOption.Controls.Add(this.chkViewSpec);
            this.grpChartOption.Controls.Add(this.chkViewRuleCheck);
            this.grpChartOption.Controls.Add(this.chkViewCZone);
            this.grpChartOption.Controls.Add(this.chkViewBZone);
            this.grpChartOption.Controls.Add(this.chkViewAZone);
            this.grpChartOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChartOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartOption.Location = new System.Drawing.Point(5, 0);
            this.grpChartOption.Name = "grpChartOption";
            this.grpChartOption.Size = new System.Drawing.Size(122, 118);
            this.grpChartOption.TabIndex = 0;
            this.grpChartOption.TabStop = false;
            // 
            // chkAutoCalControlLimit
            // 
            this.chkAutoCalControlLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAutoCalControlLimit.Location = new System.Drawing.Point(8, 103);
            this.chkAutoCalControlLimit.Name = "chkAutoCalControlLimit";
            this.chkAutoCalControlLimit.Size = new System.Drawing.Size(112, 14);
            this.chkAutoCalControlLimit.TabIndex = 19;
            this.chkAutoCalControlLimit.Text = "Auto Control Limit";
            this.chkAutoCalControlLimit.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkAutoCalControlLimit.CheckedChanged += new System.EventHandler(this.chkAutoCalControlLimit_CheckedChanged);
            // 
            // chkViewSpec
            // 
            this.chkViewSpec.Checked = true;
            this.chkViewSpec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewSpec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewSpec.Location = new System.Drawing.Point(8, 85);
            this.chkViewSpec.Name = "chkViewSpec";
            this.chkViewSpec.Size = new System.Drawing.Size(112, 14);
            this.chkViewSpec.TabIndex = 18;
            this.chkViewSpec.Text = "View Spec Limit";
            this.chkViewSpec.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewSpec.CheckedChanged += new System.EventHandler(this.chkViewSpec_CheckedChanged);
            // 
            // chkViewRuleCheck
            // 
            this.chkViewRuleCheck.Checked = true;
            this.chkViewRuleCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewRuleCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewRuleCheck.Location = new System.Drawing.Point(8, 67);
            this.chkViewRuleCheck.Name = "chkViewRuleCheck";
            this.chkViewRuleCheck.Size = new System.Drawing.Size(112, 14);
            this.chkViewRuleCheck.TabIndex = 17;
            this.chkViewRuleCheck.Text = "View Rule Check";
            this.chkViewRuleCheck.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewRuleCheck.CheckedChanged += new System.EventHandler(this.chkViewRuleCheck_CheckedChanged);
            // 
            // chkViewCZone
            // 
            this.chkViewCZone.Checked = true;
            this.chkViewCZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewCZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewCZone.Location = new System.Drawing.Point(8, 49);
            this.chkViewCZone.Name = "chkViewCZone";
            this.chkViewCZone.Size = new System.Drawing.Size(58, 14);
            this.chkViewCZone.TabIndex = 16;
            this.chkViewCZone.Text = "C Zone";
            this.chkViewCZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewCZone.CheckedChanged += new System.EventHandler(this.chkViewCZone_CheckedChanged);
            // 
            // chkViewBZone
            // 
            this.chkViewBZone.Checked = true;
            this.chkViewBZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewBZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewBZone.Location = new System.Drawing.Point(8, 31);
            this.chkViewBZone.Name = "chkViewBZone";
            this.chkViewBZone.Size = new System.Drawing.Size(58, 14);
            this.chkViewBZone.TabIndex = 15;
            this.chkViewBZone.Text = "B Zone";
            this.chkViewBZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewBZone.CheckedChanged += new System.EventHandler(this.chkViewBZone_CheckedChanged);
            // 
            // chkViewAZone
            // 
            this.chkViewAZone.Checked = true;
            this.chkViewAZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewAZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewAZone.Location = new System.Drawing.Point(8, 13);
            this.chkViewAZone.Name = "chkViewAZone";
            this.chkViewAZone.Size = new System.Drawing.Size(58, 14);
            this.chkViewAZone.TabIndex = 14;
            this.chkViewAZone.Text = "A Zone";
            this.chkViewAZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkViewAZone.CheckedChanged += new System.EventHandler(this.chkViewAZone_CheckedChanged);
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
            this.Chart.Size = new System.Drawing.Size(256, 107);
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
            this.Chart.ChangeEDCData += new SPCControlChart.ChangeEDCDataEventHandler(this.Chart_ChangeEDCData);
            this.Chart.ViewOOCInfo += new SPCControlChart.ViewOOCInfoEventHandler(this.Chart_ViewOOCInfo);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.spdData);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpData.Location = new System.Drawing.Point(0, 0);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(470, 130);
            this.grpData.TabIndex = 13;
            this.grpData.TabStop = false;
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
            this.spdData.Location = new System.Drawing.Point(3, 16);
            this.spdData.Name = "spdData";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.Renderer = columnHeaderRenderer1;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.Renderer = rowHeaderRenderer1;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.SystemColors.Control;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.Renderer = cornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
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
            this.spdData.Size = new System.Drawing.Size(464, 111);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 2;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 5;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spdData_KeyDown);
            this.spdData.EditModeOff += new System.EventHandler(this.spdData_EditModeOff);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            this.spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdData_Sheet1.ColumnCount = 1010;
            this.spdData_Sheet1.ColumnHeader.RowCount = 2;
            this.spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Result";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Unit ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Nominal";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Process Sigma";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).ColumnSpan = 1000;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "      Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1004).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1005).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1005).Locked = false;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1005).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1005).Value = "Average";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1005).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1006).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1006).Locked = false;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1006).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1006).Value = "Sigma";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1006).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1007).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1007).Locked = false;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1007).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1007).Value = "Range";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1007).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1008).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1008).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1008).Value = "Max Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1008).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1009).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1009).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1009).Value = "Min Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1009).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 50F;
            this.spdData_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1).CellType = textCellType2019;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 80F;
            this.spdData_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(2).CellType = textCellType2020;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 80F;
            this.spdData_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(3).CellType = textCellType2021;
            this.spdData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Width = 80F;
            this.spdData_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(4).CellType = textCellType2022;
            this.spdData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(5).CellType = textCellType2023;
            this.spdData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(6).CellType = textCellType2024;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(7).CellType = textCellType2025;
            this.spdData_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(8).CellType = textCellType2026;
            this.spdData_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(9).CellType = textCellType2027;
            this.spdData_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(10).CellType = textCellType2028;
            this.spdData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(11).CellType = textCellType2029;
            this.spdData_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(12).CellType = textCellType2030;
            this.spdData_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(13).CellType = textCellType2031;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(14).CellType = textCellType2032;
            this.spdData_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(15).CellType = textCellType2033;
            this.spdData_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(16).CellType = textCellType2034;
            this.spdData_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(17).CellType = textCellType2035;
            this.spdData_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(18).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(18).CellType = textCellType2036;
            this.spdData_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(19).CellType = textCellType2037;
            this.spdData_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(20).CellType = textCellType2038;
            this.spdData_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(21).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(21).CellType = textCellType2039;
            this.spdData_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(22).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(22).CellType = textCellType2040;
            this.spdData_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(23).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(23).CellType = textCellType2041;
            this.spdData_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(24).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(24).CellType = textCellType2042;
            this.spdData_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(25).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(25).CellType = textCellType2043;
            this.spdData_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(26).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(26).CellType = textCellType2044;
            this.spdData_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(27).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(27).CellType = textCellType2045;
            this.spdData_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(28).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(28).CellType = textCellType2046;
            this.spdData_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(29).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(29).CellType = textCellType2047;
            this.spdData_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(30).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(30).CellType = textCellType2048;
            this.spdData_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(31).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(31).CellType = textCellType2049;
            this.spdData_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(32).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(32).CellType = textCellType2050;
            this.spdData_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(33).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(33).CellType = textCellType2051;
            this.spdData_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(34).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(34).CellType = textCellType2052;
            this.spdData_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(35).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(35).CellType = textCellType2053;
            this.spdData_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(36).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(36).CellType = textCellType2054;
            this.spdData_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(37).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(37).CellType = textCellType2055;
            this.spdData_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(38).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(38).CellType = textCellType2056;
            this.spdData_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(39).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(39).CellType = textCellType2057;
            this.spdData_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(40).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(40).CellType = textCellType2058;
            this.spdData_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(41).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(41).CellType = textCellType2059;
            this.spdData_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(42).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(42).CellType = textCellType2060;
            this.spdData_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(43).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(43).CellType = textCellType2061;
            this.spdData_Sheet1.Columns.Get(43).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(44).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(44).CellType = textCellType2062;
            this.spdData_Sheet1.Columns.Get(44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(45).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(45).CellType = textCellType2063;
            this.spdData_Sheet1.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(46).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(46).CellType = textCellType2064;
            this.spdData_Sheet1.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(47).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(47).CellType = textCellType2065;
            this.spdData_Sheet1.Columns.Get(47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(48).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(48).CellType = textCellType2066;
            this.spdData_Sheet1.Columns.Get(48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(49).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(49).CellType = textCellType2067;
            this.spdData_Sheet1.Columns.Get(49).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(50).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(50).CellType = textCellType2068;
            this.spdData_Sheet1.Columns.Get(50).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(51).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(51).CellType = textCellType2069;
            this.spdData_Sheet1.Columns.Get(51).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(52).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(52).CellType = textCellType2070;
            this.spdData_Sheet1.Columns.Get(52).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(53).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(53).CellType = textCellType2071;
            this.spdData_Sheet1.Columns.Get(53).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(54).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(54).CellType = textCellType2072;
            this.spdData_Sheet1.Columns.Get(54).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(55).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(55).CellType = textCellType2073;
            this.spdData_Sheet1.Columns.Get(55).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(56).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(56).CellType = textCellType2074;
            this.spdData_Sheet1.Columns.Get(56).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(57).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(57).CellType = textCellType2075;
            this.spdData_Sheet1.Columns.Get(57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(58).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(58).CellType = textCellType2076;
            this.spdData_Sheet1.Columns.Get(58).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(59).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(59).CellType = textCellType2077;
            this.spdData_Sheet1.Columns.Get(59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(60).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(60).CellType = textCellType2078;
            this.spdData_Sheet1.Columns.Get(60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(61).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(61).CellType = textCellType2079;
            this.spdData_Sheet1.Columns.Get(61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(62).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(62).CellType = textCellType2080;
            this.spdData_Sheet1.Columns.Get(62).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(63).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(63).CellType = textCellType2081;
            this.spdData_Sheet1.Columns.Get(63).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(64).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(64).CellType = textCellType2082;
            this.spdData_Sheet1.Columns.Get(64).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(65).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(65).CellType = textCellType2083;
            this.spdData_Sheet1.Columns.Get(65).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(66).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(66).CellType = textCellType2084;
            this.spdData_Sheet1.Columns.Get(66).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(67).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(67).CellType = textCellType2085;
            this.spdData_Sheet1.Columns.Get(67).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(68).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(68).CellType = textCellType2086;
            this.spdData_Sheet1.Columns.Get(68).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(69).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(69).CellType = textCellType2087;
            this.spdData_Sheet1.Columns.Get(69).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(70).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(70).CellType = textCellType2088;
            this.spdData_Sheet1.Columns.Get(70).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(71).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(71).CellType = textCellType2089;
            this.spdData_Sheet1.Columns.Get(71).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(72).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(72).CellType = textCellType2090;
            this.spdData_Sheet1.Columns.Get(72).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(73).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(73).CellType = textCellType2091;
            this.spdData_Sheet1.Columns.Get(73).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(74).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(74).CellType = textCellType2092;
            this.spdData_Sheet1.Columns.Get(74).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(75).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(75).CellType = textCellType2093;
            this.spdData_Sheet1.Columns.Get(75).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(76).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(76).CellType = textCellType2094;
            this.spdData_Sheet1.Columns.Get(76).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(77).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(77).CellType = textCellType2095;
            this.spdData_Sheet1.Columns.Get(77).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(78).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(78).CellType = textCellType2096;
            this.spdData_Sheet1.Columns.Get(78).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(79).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(79).CellType = textCellType2097;
            this.spdData_Sheet1.Columns.Get(79).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(80).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(80).CellType = textCellType2098;
            this.spdData_Sheet1.Columns.Get(80).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(81).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(81).CellType = textCellType2099;
            this.spdData_Sheet1.Columns.Get(81).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(82).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(82).CellType = textCellType2100;
            this.spdData_Sheet1.Columns.Get(82).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(83).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(83).CellType = textCellType2101;
            this.spdData_Sheet1.Columns.Get(83).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(84).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(84).CellType = textCellType2102;
            this.spdData_Sheet1.Columns.Get(84).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(85).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(85).CellType = textCellType2103;
            this.spdData_Sheet1.Columns.Get(85).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(85).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(86).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(86).CellType = textCellType2104;
            this.spdData_Sheet1.Columns.Get(86).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(86).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(87).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(87).CellType = textCellType2105;
            this.spdData_Sheet1.Columns.Get(87).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(87).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(88).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(88).CellType = textCellType2106;
            this.spdData_Sheet1.Columns.Get(88).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(88).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(89).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(89).CellType = textCellType2107;
            this.spdData_Sheet1.Columns.Get(89).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(89).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(90).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(90).CellType = textCellType2108;
            this.spdData_Sheet1.Columns.Get(90).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(90).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(91).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(91).CellType = textCellType2109;
            this.spdData_Sheet1.Columns.Get(91).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(91).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(92).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(92).CellType = textCellType2110;
            this.spdData_Sheet1.Columns.Get(92).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(92).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(93).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(93).CellType = textCellType2111;
            this.spdData_Sheet1.Columns.Get(93).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(93).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(94).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(94).CellType = textCellType2112;
            this.spdData_Sheet1.Columns.Get(94).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(94).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(95).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(95).CellType = textCellType2113;
            this.spdData_Sheet1.Columns.Get(95).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(95).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(96).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(96).CellType = textCellType2114;
            this.spdData_Sheet1.Columns.Get(96).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(96).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(97).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(97).CellType = textCellType2115;
            this.spdData_Sheet1.Columns.Get(97).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(97).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(98).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(98).CellType = textCellType2116;
            this.spdData_Sheet1.Columns.Get(98).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(98).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(99).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(99).CellType = textCellType2117;
            this.spdData_Sheet1.Columns.Get(99).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(99).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(100).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(100).CellType = textCellType2118;
            this.spdData_Sheet1.Columns.Get(100).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(100).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(101).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(101).CellType = textCellType2119;
            this.spdData_Sheet1.Columns.Get(101).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(101).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(102).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(102).CellType = textCellType2120;
            this.spdData_Sheet1.Columns.Get(102).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(102).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(103).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(103).CellType = textCellType2121;
            this.spdData_Sheet1.Columns.Get(103).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(103).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(104).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(104).CellType = textCellType2122;
            this.spdData_Sheet1.Columns.Get(104).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(104).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(105).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(105).CellType = textCellType2123;
            this.spdData_Sheet1.Columns.Get(105).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(105).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(106).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(106).CellType = textCellType2124;
            this.spdData_Sheet1.Columns.Get(106).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(106).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(107).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(107).CellType = textCellType2125;
            this.spdData_Sheet1.Columns.Get(107).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(107).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(108).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(108).CellType = textCellType2126;
            this.spdData_Sheet1.Columns.Get(108).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(108).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(109).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(109).CellType = textCellType2127;
            this.spdData_Sheet1.Columns.Get(109).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(109).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(110).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(110).CellType = textCellType2128;
            this.spdData_Sheet1.Columns.Get(110).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(110).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(111).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(111).CellType = textCellType2129;
            this.spdData_Sheet1.Columns.Get(111).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(111).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(112).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(112).CellType = textCellType2130;
            this.spdData_Sheet1.Columns.Get(112).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(112).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(113).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(113).CellType = textCellType2131;
            this.spdData_Sheet1.Columns.Get(113).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(113).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(114).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(114).CellType = textCellType2132;
            this.spdData_Sheet1.Columns.Get(114).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(114).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(115).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(115).CellType = textCellType2133;
            this.spdData_Sheet1.Columns.Get(115).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(115).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(116).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(116).CellType = textCellType2134;
            this.spdData_Sheet1.Columns.Get(116).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(116).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(117).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(117).CellType = textCellType2135;
            this.spdData_Sheet1.Columns.Get(117).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(117).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(118).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(118).CellType = textCellType2136;
            this.spdData_Sheet1.Columns.Get(118).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(118).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(119).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(119).CellType = textCellType2137;
            this.spdData_Sheet1.Columns.Get(119).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(119).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(120).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(120).CellType = textCellType2138;
            this.spdData_Sheet1.Columns.Get(120).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(120).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(121).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(121).CellType = textCellType2139;
            this.spdData_Sheet1.Columns.Get(121).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(121).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(122).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(122).CellType = textCellType2140;
            this.spdData_Sheet1.Columns.Get(122).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(122).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(123).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(123).CellType = textCellType2141;
            this.spdData_Sheet1.Columns.Get(123).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(123).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(124).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(124).CellType = textCellType2142;
            this.spdData_Sheet1.Columns.Get(124).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(124).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(125).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(125).CellType = textCellType2143;
            this.spdData_Sheet1.Columns.Get(125).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(125).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(126).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(126).CellType = textCellType2144;
            this.spdData_Sheet1.Columns.Get(126).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(126).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(127).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(127).CellType = textCellType2145;
            this.spdData_Sheet1.Columns.Get(127).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(127).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(128).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(128).CellType = textCellType2146;
            this.spdData_Sheet1.Columns.Get(128).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(128).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(129).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(129).CellType = textCellType2147;
            this.spdData_Sheet1.Columns.Get(129).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(129).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(130).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(130).CellType = textCellType2148;
            this.spdData_Sheet1.Columns.Get(130).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(130).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(131).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(131).CellType = textCellType2149;
            this.spdData_Sheet1.Columns.Get(131).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(131).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(132).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(132).CellType = textCellType2150;
            this.spdData_Sheet1.Columns.Get(132).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(132).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(133).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(133).CellType = textCellType2151;
            this.spdData_Sheet1.Columns.Get(133).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(133).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(134).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(134).CellType = textCellType2152;
            this.spdData_Sheet1.Columns.Get(134).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(134).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(135).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(135).CellType = textCellType2153;
            this.spdData_Sheet1.Columns.Get(135).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(135).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(136).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(136).CellType = textCellType2154;
            this.spdData_Sheet1.Columns.Get(136).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(136).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(137).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(137).CellType = textCellType2155;
            this.spdData_Sheet1.Columns.Get(137).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(137).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(138).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(138).CellType = textCellType2156;
            this.spdData_Sheet1.Columns.Get(138).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(138).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(139).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(139).CellType = textCellType2157;
            this.spdData_Sheet1.Columns.Get(139).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(139).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(140).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(140).CellType = textCellType2158;
            this.spdData_Sheet1.Columns.Get(140).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(140).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(141).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(141).CellType = textCellType2159;
            this.spdData_Sheet1.Columns.Get(141).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(141).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(142).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(142).CellType = textCellType2160;
            this.spdData_Sheet1.Columns.Get(142).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(142).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(143).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(143).CellType = textCellType2161;
            this.spdData_Sheet1.Columns.Get(143).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(143).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(144).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(144).CellType = textCellType2162;
            this.spdData_Sheet1.Columns.Get(144).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(144).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(145).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(145).CellType = textCellType2163;
            this.spdData_Sheet1.Columns.Get(145).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(145).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(146).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(146).CellType = textCellType2164;
            this.spdData_Sheet1.Columns.Get(146).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(146).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(147).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(147).CellType = textCellType2165;
            this.spdData_Sheet1.Columns.Get(147).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(147).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(148).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(148).CellType = textCellType2166;
            this.spdData_Sheet1.Columns.Get(148).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(148).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(149).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(149).CellType = textCellType2167;
            this.spdData_Sheet1.Columns.Get(149).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(149).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(150).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(150).CellType = textCellType2168;
            this.spdData_Sheet1.Columns.Get(150).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(150).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(151).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(151).CellType = textCellType2169;
            this.spdData_Sheet1.Columns.Get(151).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(151).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(152).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(152).CellType = textCellType2170;
            this.spdData_Sheet1.Columns.Get(152).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(152).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(153).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(153).CellType = textCellType2171;
            this.spdData_Sheet1.Columns.Get(153).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(153).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(154).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(154).CellType = textCellType2172;
            this.spdData_Sheet1.Columns.Get(154).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(154).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(155).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(155).CellType = textCellType2173;
            this.spdData_Sheet1.Columns.Get(155).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(155).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(156).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(156).CellType = textCellType2174;
            this.spdData_Sheet1.Columns.Get(156).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(156).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(157).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(157).CellType = textCellType2175;
            this.spdData_Sheet1.Columns.Get(157).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(157).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(158).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(158).CellType = textCellType2176;
            this.spdData_Sheet1.Columns.Get(158).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(158).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(159).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(159).CellType = textCellType2177;
            this.spdData_Sheet1.Columns.Get(159).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(159).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(160).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(160).CellType = textCellType2178;
            this.spdData_Sheet1.Columns.Get(160).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(160).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(161).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(161).CellType = textCellType2179;
            this.spdData_Sheet1.Columns.Get(161).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(161).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(162).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(162).CellType = textCellType2180;
            this.spdData_Sheet1.Columns.Get(162).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(162).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(163).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(163).CellType = textCellType2181;
            this.spdData_Sheet1.Columns.Get(163).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(163).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(164).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(164).CellType = textCellType2182;
            this.spdData_Sheet1.Columns.Get(164).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(164).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(165).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(165).CellType = textCellType2183;
            this.spdData_Sheet1.Columns.Get(165).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(165).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(166).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(166).CellType = textCellType2184;
            this.spdData_Sheet1.Columns.Get(166).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(166).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(167).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(167).CellType = textCellType2185;
            this.spdData_Sheet1.Columns.Get(167).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(167).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(168).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(168).CellType = textCellType2186;
            this.spdData_Sheet1.Columns.Get(168).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(168).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(169).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(169).CellType = textCellType2187;
            this.spdData_Sheet1.Columns.Get(169).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(169).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(170).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(170).CellType = textCellType2188;
            this.spdData_Sheet1.Columns.Get(170).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(170).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(171).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(171).CellType = textCellType2189;
            this.spdData_Sheet1.Columns.Get(171).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(171).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(172).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(172).CellType = textCellType2190;
            this.spdData_Sheet1.Columns.Get(172).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(172).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(173).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(173).CellType = textCellType2191;
            this.spdData_Sheet1.Columns.Get(173).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(173).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(174).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(174).CellType = textCellType2192;
            this.spdData_Sheet1.Columns.Get(174).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(174).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(175).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(175).CellType = textCellType2193;
            this.spdData_Sheet1.Columns.Get(175).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(175).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(176).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(176).CellType = textCellType2194;
            this.spdData_Sheet1.Columns.Get(176).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(176).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(177).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(177).CellType = textCellType2195;
            this.spdData_Sheet1.Columns.Get(177).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(177).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(178).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(178).CellType = textCellType2196;
            this.spdData_Sheet1.Columns.Get(178).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(178).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(179).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(179).CellType = textCellType2197;
            this.spdData_Sheet1.Columns.Get(179).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(179).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(180).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(180).CellType = textCellType2198;
            this.spdData_Sheet1.Columns.Get(180).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(180).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(181).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(181).CellType = textCellType2199;
            this.spdData_Sheet1.Columns.Get(181).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(181).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(182).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(182).CellType = textCellType2200;
            this.spdData_Sheet1.Columns.Get(182).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(182).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(183).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(183).CellType = textCellType2201;
            this.spdData_Sheet1.Columns.Get(183).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(183).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(184).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(184).CellType = textCellType2202;
            this.spdData_Sheet1.Columns.Get(184).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(184).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(185).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(185).CellType = textCellType2203;
            this.spdData_Sheet1.Columns.Get(185).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(185).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(186).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(186).CellType = textCellType2204;
            this.spdData_Sheet1.Columns.Get(186).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(186).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(187).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(187).CellType = textCellType2205;
            this.spdData_Sheet1.Columns.Get(187).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(187).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(188).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(188).CellType = textCellType2206;
            this.spdData_Sheet1.Columns.Get(188).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(188).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(189).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(189).CellType = textCellType2207;
            this.spdData_Sheet1.Columns.Get(189).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(189).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(190).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(190).CellType = textCellType2208;
            this.spdData_Sheet1.Columns.Get(190).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(190).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(191).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(191).CellType = textCellType2209;
            this.spdData_Sheet1.Columns.Get(191).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(191).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(192).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(192).CellType = textCellType2210;
            this.spdData_Sheet1.Columns.Get(192).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(192).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(193).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(193).CellType = textCellType2211;
            this.spdData_Sheet1.Columns.Get(193).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(193).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(194).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(194).CellType = textCellType2212;
            this.spdData_Sheet1.Columns.Get(194).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(194).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(195).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(195).CellType = textCellType2213;
            this.spdData_Sheet1.Columns.Get(195).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(195).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(196).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(196).CellType = textCellType2214;
            this.spdData_Sheet1.Columns.Get(196).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(196).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(197).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(197).CellType = textCellType2215;
            this.spdData_Sheet1.Columns.Get(197).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(197).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(198).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(198).CellType = textCellType2216;
            this.spdData_Sheet1.Columns.Get(198).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(198).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(199).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(199).CellType = textCellType2217;
            this.spdData_Sheet1.Columns.Get(199).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(199).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(200).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(200).CellType = textCellType2218;
            this.spdData_Sheet1.Columns.Get(200).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(200).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(201).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(201).CellType = textCellType2219;
            this.spdData_Sheet1.Columns.Get(201).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(201).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(202).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(202).CellType = textCellType2220;
            this.spdData_Sheet1.Columns.Get(202).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(202).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(203).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(203).CellType = textCellType2221;
            this.spdData_Sheet1.Columns.Get(203).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(203).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(204).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(204).CellType = textCellType2222;
            this.spdData_Sheet1.Columns.Get(204).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(204).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(205).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(205).CellType = textCellType2223;
            this.spdData_Sheet1.Columns.Get(205).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(205).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(206).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(206).CellType = textCellType2224;
            this.spdData_Sheet1.Columns.Get(206).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(206).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(207).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(207).CellType = textCellType2225;
            this.spdData_Sheet1.Columns.Get(207).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(207).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(208).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(208).CellType = textCellType2226;
            this.spdData_Sheet1.Columns.Get(208).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(208).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(209).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(209).CellType = textCellType2227;
            this.spdData_Sheet1.Columns.Get(209).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(209).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(210).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(210).CellType = textCellType2228;
            this.spdData_Sheet1.Columns.Get(210).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(210).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(211).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(211).CellType = textCellType2229;
            this.spdData_Sheet1.Columns.Get(211).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(211).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(212).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(212).CellType = textCellType2230;
            this.spdData_Sheet1.Columns.Get(212).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(212).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(213).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(213).CellType = textCellType2231;
            this.spdData_Sheet1.Columns.Get(213).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(213).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(214).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(214).CellType = textCellType2232;
            this.spdData_Sheet1.Columns.Get(214).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(214).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(215).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(215).CellType = textCellType2233;
            this.spdData_Sheet1.Columns.Get(215).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(215).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(216).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(216).CellType = textCellType2234;
            this.spdData_Sheet1.Columns.Get(216).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(216).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(217).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(217).CellType = textCellType2235;
            this.spdData_Sheet1.Columns.Get(217).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(217).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(218).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(218).CellType = textCellType2236;
            this.spdData_Sheet1.Columns.Get(218).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(218).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(219).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(219).CellType = textCellType2237;
            this.spdData_Sheet1.Columns.Get(219).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(219).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(220).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(220).CellType = textCellType2238;
            this.spdData_Sheet1.Columns.Get(220).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(220).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(221).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(221).CellType = textCellType2239;
            this.spdData_Sheet1.Columns.Get(221).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(221).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(222).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(222).CellType = textCellType2240;
            this.spdData_Sheet1.Columns.Get(222).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(222).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(223).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(223).CellType = textCellType2241;
            this.spdData_Sheet1.Columns.Get(223).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(223).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(224).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(224).CellType = textCellType2242;
            this.spdData_Sheet1.Columns.Get(224).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(224).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(225).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(225).CellType = textCellType2243;
            this.spdData_Sheet1.Columns.Get(225).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(225).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(226).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(226).CellType = textCellType2244;
            this.spdData_Sheet1.Columns.Get(226).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(226).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(227).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(227).CellType = textCellType2245;
            this.spdData_Sheet1.Columns.Get(227).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(227).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(228).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(228).CellType = textCellType2246;
            this.spdData_Sheet1.Columns.Get(228).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(228).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(229).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(229).CellType = textCellType2247;
            this.spdData_Sheet1.Columns.Get(229).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(229).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(230).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(230).CellType = textCellType2248;
            this.spdData_Sheet1.Columns.Get(230).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(230).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(231).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(231).CellType = textCellType2249;
            this.spdData_Sheet1.Columns.Get(231).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(231).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(232).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(232).CellType = textCellType2250;
            this.spdData_Sheet1.Columns.Get(232).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(232).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(233).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(233).CellType = textCellType2251;
            this.spdData_Sheet1.Columns.Get(233).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(233).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(234).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(234).CellType = textCellType2252;
            this.spdData_Sheet1.Columns.Get(234).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(234).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(235).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(235).CellType = textCellType2253;
            this.spdData_Sheet1.Columns.Get(235).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(235).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(236).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(236).CellType = textCellType2254;
            this.spdData_Sheet1.Columns.Get(236).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(236).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(237).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(237).CellType = textCellType2255;
            this.spdData_Sheet1.Columns.Get(237).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(237).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(238).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(238).CellType = textCellType2256;
            this.spdData_Sheet1.Columns.Get(238).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(238).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(239).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(239).CellType = textCellType2257;
            this.spdData_Sheet1.Columns.Get(239).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(239).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(240).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(240).CellType = textCellType2258;
            this.spdData_Sheet1.Columns.Get(240).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(240).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(241).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(241).CellType = textCellType2259;
            this.spdData_Sheet1.Columns.Get(241).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(241).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(242).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(242).CellType = textCellType2260;
            this.spdData_Sheet1.Columns.Get(242).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(242).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(243).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(243).CellType = textCellType2261;
            this.spdData_Sheet1.Columns.Get(243).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(243).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(244).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(244).CellType = textCellType2262;
            this.spdData_Sheet1.Columns.Get(244).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(244).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(245).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(245).CellType = textCellType2263;
            this.spdData_Sheet1.Columns.Get(245).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(245).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(246).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(246).CellType = textCellType2264;
            this.spdData_Sheet1.Columns.Get(246).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(246).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(247).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(247).CellType = textCellType2265;
            this.spdData_Sheet1.Columns.Get(247).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(247).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(248).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(248).CellType = textCellType2266;
            this.spdData_Sheet1.Columns.Get(248).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(248).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(249).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(249).CellType = textCellType2267;
            this.spdData_Sheet1.Columns.Get(249).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(249).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(250).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(250).CellType = textCellType2268;
            this.spdData_Sheet1.Columns.Get(250).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(250).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(251).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(251).CellType = textCellType2269;
            this.spdData_Sheet1.Columns.Get(251).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(251).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(252).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(252).CellType = textCellType2270;
            this.spdData_Sheet1.Columns.Get(252).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(252).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(253).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(253).CellType = textCellType2271;
            this.spdData_Sheet1.Columns.Get(253).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(253).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(254).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(254).CellType = textCellType2272;
            this.spdData_Sheet1.Columns.Get(254).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(254).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(255).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(255).CellType = textCellType2273;
            this.spdData_Sheet1.Columns.Get(255).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(255).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(256).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(256).CellType = textCellType2274;
            this.spdData_Sheet1.Columns.Get(256).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(256).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(257).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(257).CellType = textCellType2275;
            this.spdData_Sheet1.Columns.Get(257).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(257).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(258).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(258).CellType = textCellType2276;
            this.spdData_Sheet1.Columns.Get(258).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(258).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(259).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(259).CellType = textCellType2277;
            this.spdData_Sheet1.Columns.Get(259).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(259).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(260).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(260).CellType = textCellType2278;
            this.spdData_Sheet1.Columns.Get(260).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(260).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(261).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(261).CellType = textCellType2279;
            this.spdData_Sheet1.Columns.Get(261).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(261).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(262).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(262).CellType = textCellType2280;
            this.spdData_Sheet1.Columns.Get(262).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(262).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(263).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(263).CellType = textCellType2281;
            this.spdData_Sheet1.Columns.Get(263).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(263).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(264).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(264).CellType = textCellType2282;
            this.spdData_Sheet1.Columns.Get(264).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(264).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(265).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(265).CellType = textCellType2283;
            this.spdData_Sheet1.Columns.Get(265).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(265).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(266).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(266).CellType = textCellType2284;
            this.spdData_Sheet1.Columns.Get(266).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(266).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(267).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(267).CellType = textCellType2285;
            this.spdData_Sheet1.Columns.Get(267).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(267).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(268).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(268).CellType = textCellType2286;
            this.spdData_Sheet1.Columns.Get(268).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(268).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(269).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(269).CellType = textCellType2287;
            this.spdData_Sheet1.Columns.Get(269).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(269).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(270).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(270).CellType = textCellType2288;
            this.spdData_Sheet1.Columns.Get(270).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(270).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(271).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(271).CellType = textCellType2289;
            this.spdData_Sheet1.Columns.Get(271).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(271).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(272).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(272).CellType = textCellType2290;
            this.spdData_Sheet1.Columns.Get(272).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(272).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(273).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(273).CellType = textCellType2291;
            this.spdData_Sheet1.Columns.Get(273).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(273).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(274).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(274).CellType = textCellType2292;
            this.spdData_Sheet1.Columns.Get(274).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(274).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(275).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(275).CellType = textCellType2293;
            this.spdData_Sheet1.Columns.Get(275).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(275).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(276).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(276).CellType = textCellType2294;
            this.spdData_Sheet1.Columns.Get(276).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(276).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(277).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(277).CellType = textCellType2295;
            this.spdData_Sheet1.Columns.Get(277).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(277).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(278).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(278).CellType = textCellType2296;
            this.spdData_Sheet1.Columns.Get(278).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(278).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(279).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(279).CellType = textCellType2297;
            this.spdData_Sheet1.Columns.Get(279).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(279).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(280).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(280).CellType = textCellType2298;
            this.spdData_Sheet1.Columns.Get(280).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(280).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(281).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(281).CellType = textCellType2299;
            this.spdData_Sheet1.Columns.Get(281).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(281).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(282).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(282).CellType = textCellType2300;
            this.spdData_Sheet1.Columns.Get(282).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(282).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(283).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(283).CellType = textCellType2301;
            this.spdData_Sheet1.Columns.Get(283).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(283).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(284).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(284).CellType = textCellType2302;
            this.spdData_Sheet1.Columns.Get(284).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(284).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(285).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(285).CellType = textCellType2303;
            this.spdData_Sheet1.Columns.Get(285).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(285).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(286).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(286).CellType = textCellType2304;
            this.spdData_Sheet1.Columns.Get(286).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(286).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(287).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(287).CellType = textCellType2305;
            this.spdData_Sheet1.Columns.Get(287).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(287).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(288).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(288).CellType = textCellType2306;
            this.spdData_Sheet1.Columns.Get(288).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(288).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(289).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(289).CellType = textCellType2307;
            this.spdData_Sheet1.Columns.Get(289).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(289).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(290).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(290).CellType = textCellType2308;
            this.spdData_Sheet1.Columns.Get(290).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(290).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(291).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(291).CellType = textCellType2309;
            this.spdData_Sheet1.Columns.Get(291).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(291).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(292).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(292).CellType = textCellType2310;
            this.spdData_Sheet1.Columns.Get(292).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(292).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(293).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(293).CellType = textCellType2311;
            this.spdData_Sheet1.Columns.Get(293).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(293).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(294).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(294).CellType = textCellType2312;
            this.spdData_Sheet1.Columns.Get(294).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(294).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(295).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(295).CellType = textCellType2313;
            this.spdData_Sheet1.Columns.Get(295).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(295).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(296).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(296).CellType = textCellType2314;
            this.spdData_Sheet1.Columns.Get(296).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(296).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(297).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(297).CellType = textCellType2315;
            this.spdData_Sheet1.Columns.Get(297).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(297).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(298).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(298).CellType = textCellType2316;
            this.spdData_Sheet1.Columns.Get(298).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(298).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(299).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(299).CellType = textCellType2317;
            this.spdData_Sheet1.Columns.Get(299).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(299).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(300).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(300).CellType = textCellType2318;
            this.spdData_Sheet1.Columns.Get(300).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(300).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(301).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(301).CellType = textCellType2319;
            this.spdData_Sheet1.Columns.Get(301).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(301).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(302).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(302).CellType = textCellType2320;
            this.spdData_Sheet1.Columns.Get(302).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(302).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(303).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(303).CellType = textCellType2321;
            this.spdData_Sheet1.Columns.Get(303).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(303).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(304).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(304).CellType = textCellType2322;
            this.spdData_Sheet1.Columns.Get(304).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(304).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(305).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(305).CellType = textCellType2323;
            this.spdData_Sheet1.Columns.Get(305).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(305).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(306).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(306).CellType = textCellType2324;
            this.spdData_Sheet1.Columns.Get(306).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(306).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(307).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(307).CellType = textCellType2325;
            this.spdData_Sheet1.Columns.Get(307).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(307).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(308).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(308).CellType = textCellType2326;
            this.spdData_Sheet1.Columns.Get(308).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(308).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(309).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(309).CellType = textCellType2327;
            this.spdData_Sheet1.Columns.Get(309).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(309).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(310).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(310).CellType = textCellType2328;
            this.spdData_Sheet1.Columns.Get(310).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(310).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(311).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(311).CellType = textCellType2329;
            this.spdData_Sheet1.Columns.Get(311).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(311).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(312).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(312).CellType = textCellType2330;
            this.spdData_Sheet1.Columns.Get(312).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(312).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(313).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(313).CellType = textCellType2331;
            this.spdData_Sheet1.Columns.Get(313).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(313).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(314).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(314).CellType = textCellType2332;
            this.spdData_Sheet1.Columns.Get(314).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(314).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(315).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(315).CellType = textCellType2333;
            this.spdData_Sheet1.Columns.Get(315).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(315).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(316).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(316).CellType = textCellType2334;
            this.spdData_Sheet1.Columns.Get(316).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(316).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(317).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(317).CellType = textCellType2335;
            this.spdData_Sheet1.Columns.Get(317).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(317).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(318).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(318).CellType = textCellType2336;
            this.spdData_Sheet1.Columns.Get(318).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(318).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(319).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(319).CellType = textCellType2337;
            this.spdData_Sheet1.Columns.Get(319).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(319).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(320).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(320).CellType = textCellType2338;
            this.spdData_Sheet1.Columns.Get(320).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(320).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(321).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(321).CellType = textCellType2339;
            this.spdData_Sheet1.Columns.Get(321).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(321).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(322).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(322).CellType = textCellType2340;
            this.spdData_Sheet1.Columns.Get(322).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(322).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(323).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(323).CellType = textCellType2341;
            this.spdData_Sheet1.Columns.Get(323).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(323).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(324).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(324).CellType = textCellType2342;
            this.spdData_Sheet1.Columns.Get(324).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(324).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(325).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(325).CellType = textCellType2343;
            this.spdData_Sheet1.Columns.Get(325).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(325).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(326).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(326).CellType = textCellType2344;
            this.spdData_Sheet1.Columns.Get(326).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(326).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(327).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(327).CellType = textCellType2345;
            this.spdData_Sheet1.Columns.Get(327).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(327).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(328).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(328).CellType = textCellType2346;
            this.spdData_Sheet1.Columns.Get(328).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(328).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(329).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(329).CellType = textCellType2347;
            this.spdData_Sheet1.Columns.Get(329).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(329).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(330).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(330).CellType = textCellType2348;
            this.spdData_Sheet1.Columns.Get(330).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(330).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(331).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(331).CellType = textCellType2349;
            this.spdData_Sheet1.Columns.Get(331).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(331).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(332).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(332).CellType = textCellType2350;
            this.spdData_Sheet1.Columns.Get(332).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(332).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(333).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(333).CellType = textCellType2351;
            this.spdData_Sheet1.Columns.Get(333).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(333).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(334).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(334).CellType = textCellType2352;
            this.spdData_Sheet1.Columns.Get(334).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(334).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(335).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(335).CellType = textCellType2353;
            this.spdData_Sheet1.Columns.Get(335).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(335).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(336).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(336).CellType = textCellType2354;
            this.spdData_Sheet1.Columns.Get(336).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(336).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(337).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(337).CellType = textCellType2355;
            this.spdData_Sheet1.Columns.Get(337).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(337).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(338).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(338).CellType = textCellType2356;
            this.spdData_Sheet1.Columns.Get(338).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(338).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(339).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(339).CellType = textCellType2357;
            this.spdData_Sheet1.Columns.Get(339).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(339).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(340).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(340).CellType = textCellType2358;
            this.spdData_Sheet1.Columns.Get(340).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(340).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(341).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(341).CellType = textCellType2359;
            this.spdData_Sheet1.Columns.Get(341).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(341).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(342).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(342).CellType = textCellType2360;
            this.spdData_Sheet1.Columns.Get(342).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(342).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(343).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(343).CellType = textCellType2361;
            this.spdData_Sheet1.Columns.Get(343).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(343).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(344).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(344).CellType = textCellType2362;
            this.spdData_Sheet1.Columns.Get(344).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(344).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(345).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(345).CellType = textCellType2363;
            this.spdData_Sheet1.Columns.Get(345).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(345).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(346).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(346).CellType = textCellType2364;
            this.spdData_Sheet1.Columns.Get(346).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(346).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(347).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(347).CellType = textCellType2365;
            this.spdData_Sheet1.Columns.Get(347).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(347).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(348).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(348).CellType = textCellType2366;
            this.spdData_Sheet1.Columns.Get(348).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(348).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(349).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(349).CellType = textCellType2367;
            this.spdData_Sheet1.Columns.Get(349).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(349).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(350).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(350).CellType = textCellType2368;
            this.spdData_Sheet1.Columns.Get(350).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(350).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(351).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(351).CellType = textCellType2369;
            this.spdData_Sheet1.Columns.Get(351).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(351).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(352).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(352).CellType = textCellType2370;
            this.spdData_Sheet1.Columns.Get(352).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(352).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(353).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(353).CellType = textCellType2371;
            this.spdData_Sheet1.Columns.Get(353).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(353).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(354).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(354).CellType = textCellType2372;
            this.spdData_Sheet1.Columns.Get(354).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(354).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(355).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(355).CellType = textCellType2373;
            this.spdData_Sheet1.Columns.Get(355).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(355).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(356).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(356).CellType = textCellType2374;
            this.spdData_Sheet1.Columns.Get(356).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(356).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(357).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(357).CellType = textCellType2375;
            this.spdData_Sheet1.Columns.Get(357).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(357).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(358).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(358).CellType = textCellType2376;
            this.spdData_Sheet1.Columns.Get(358).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(358).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(359).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(359).CellType = textCellType2377;
            this.spdData_Sheet1.Columns.Get(359).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(359).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(360).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(360).CellType = textCellType2378;
            this.spdData_Sheet1.Columns.Get(360).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(360).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(361).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(361).CellType = textCellType2379;
            this.spdData_Sheet1.Columns.Get(361).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(361).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(362).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(362).CellType = textCellType2380;
            this.spdData_Sheet1.Columns.Get(362).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(362).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(363).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(363).CellType = textCellType2381;
            this.spdData_Sheet1.Columns.Get(363).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(363).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(364).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(364).CellType = textCellType2382;
            this.spdData_Sheet1.Columns.Get(364).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(364).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(365).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(365).CellType = textCellType2383;
            this.spdData_Sheet1.Columns.Get(365).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(365).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(366).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(366).CellType = textCellType2384;
            this.spdData_Sheet1.Columns.Get(366).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(366).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(367).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(367).CellType = textCellType2385;
            this.spdData_Sheet1.Columns.Get(367).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(367).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(368).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(368).CellType = textCellType2386;
            this.spdData_Sheet1.Columns.Get(368).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(368).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(369).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(369).CellType = textCellType2387;
            this.spdData_Sheet1.Columns.Get(369).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(369).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(370).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(370).CellType = textCellType2388;
            this.spdData_Sheet1.Columns.Get(370).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(370).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(371).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(371).CellType = textCellType2389;
            this.spdData_Sheet1.Columns.Get(371).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(371).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(372).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(372).CellType = textCellType2390;
            this.spdData_Sheet1.Columns.Get(372).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(372).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(373).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(373).CellType = textCellType2391;
            this.spdData_Sheet1.Columns.Get(373).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(373).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(374).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(374).CellType = textCellType2392;
            this.spdData_Sheet1.Columns.Get(374).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(374).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(375).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(375).CellType = textCellType2393;
            this.spdData_Sheet1.Columns.Get(375).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(375).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(376).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(376).CellType = textCellType2394;
            this.spdData_Sheet1.Columns.Get(376).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(376).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(377).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(377).CellType = textCellType2395;
            this.spdData_Sheet1.Columns.Get(377).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(377).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(378).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(378).CellType = textCellType2396;
            this.spdData_Sheet1.Columns.Get(378).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(378).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(379).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(379).CellType = textCellType2397;
            this.spdData_Sheet1.Columns.Get(379).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(379).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(380).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(380).CellType = textCellType2398;
            this.spdData_Sheet1.Columns.Get(380).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(380).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(381).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(381).CellType = textCellType2399;
            this.spdData_Sheet1.Columns.Get(381).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(381).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(382).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(382).CellType = textCellType2400;
            this.spdData_Sheet1.Columns.Get(382).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(382).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(383).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(383).CellType = textCellType2401;
            this.spdData_Sheet1.Columns.Get(383).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(383).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(384).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(384).CellType = textCellType2402;
            this.spdData_Sheet1.Columns.Get(384).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(384).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(385).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(385).CellType = textCellType2403;
            this.spdData_Sheet1.Columns.Get(385).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(385).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(386).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(386).CellType = textCellType2404;
            this.spdData_Sheet1.Columns.Get(386).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(386).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(387).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(387).CellType = textCellType2405;
            this.spdData_Sheet1.Columns.Get(387).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(387).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(388).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(388).CellType = textCellType2406;
            this.spdData_Sheet1.Columns.Get(388).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(388).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(389).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(389).CellType = textCellType2407;
            this.spdData_Sheet1.Columns.Get(389).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(389).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(390).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(390).CellType = textCellType2408;
            this.spdData_Sheet1.Columns.Get(390).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(390).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(391).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(391).CellType = textCellType2409;
            this.spdData_Sheet1.Columns.Get(391).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(391).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(392).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(392).CellType = textCellType2410;
            this.spdData_Sheet1.Columns.Get(392).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(392).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(393).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(393).CellType = textCellType2411;
            this.spdData_Sheet1.Columns.Get(393).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(393).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(394).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(394).CellType = textCellType2412;
            this.spdData_Sheet1.Columns.Get(394).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(394).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(395).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(395).CellType = textCellType2413;
            this.spdData_Sheet1.Columns.Get(395).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(395).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(396).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(396).CellType = textCellType2414;
            this.spdData_Sheet1.Columns.Get(396).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(396).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(397).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(397).CellType = textCellType2415;
            this.spdData_Sheet1.Columns.Get(397).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(397).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(398).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(398).CellType = textCellType2416;
            this.spdData_Sheet1.Columns.Get(398).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(398).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(399).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(399).CellType = textCellType2417;
            this.spdData_Sheet1.Columns.Get(399).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(399).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(400).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(400).CellType = textCellType2418;
            this.spdData_Sheet1.Columns.Get(400).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(400).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(401).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(401).CellType = textCellType2419;
            this.spdData_Sheet1.Columns.Get(401).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(401).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(402).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(402).CellType = textCellType2420;
            this.spdData_Sheet1.Columns.Get(402).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(402).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(403).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(403).CellType = textCellType2421;
            this.spdData_Sheet1.Columns.Get(403).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(403).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(404).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(404).CellType = textCellType2422;
            this.spdData_Sheet1.Columns.Get(404).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(404).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(405).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(405).CellType = textCellType2423;
            this.spdData_Sheet1.Columns.Get(405).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(405).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(406).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(406).CellType = textCellType2424;
            this.spdData_Sheet1.Columns.Get(406).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(406).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(407).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(407).CellType = textCellType2425;
            this.spdData_Sheet1.Columns.Get(407).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(407).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(408).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(408).CellType = textCellType2426;
            this.spdData_Sheet1.Columns.Get(408).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(408).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(409).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(409).CellType = textCellType2427;
            this.spdData_Sheet1.Columns.Get(409).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(409).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(410).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(410).CellType = textCellType2428;
            this.spdData_Sheet1.Columns.Get(410).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(410).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(411).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(411).CellType = textCellType2429;
            this.spdData_Sheet1.Columns.Get(411).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(411).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(412).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(412).CellType = textCellType2430;
            this.spdData_Sheet1.Columns.Get(412).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(412).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(413).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(413).CellType = textCellType2431;
            this.spdData_Sheet1.Columns.Get(413).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(413).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(414).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(414).CellType = textCellType2432;
            this.spdData_Sheet1.Columns.Get(414).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(414).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(415).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(415).CellType = textCellType2433;
            this.spdData_Sheet1.Columns.Get(415).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(415).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(416).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(416).CellType = textCellType2434;
            this.spdData_Sheet1.Columns.Get(416).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(416).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(417).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(417).CellType = textCellType2435;
            this.spdData_Sheet1.Columns.Get(417).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(417).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(418).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(418).CellType = textCellType2436;
            this.spdData_Sheet1.Columns.Get(418).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(418).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(419).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(419).CellType = textCellType2437;
            this.spdData_Sheet1.Columns.Get(419).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(419).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(420).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(420).CellType = textCellType2438;
            this.spdData_Sheet1.Columns.Get(420).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(420).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(421).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(421).CellType = textCellType2439;
            this.spdData_Sheet1.Columns.Get(421).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(421).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(422).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(422).CellType = textCellType2440;
            this.spdData_Sheet1.Columns.Get(422).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(422).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(423).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(423).CellType = textCellType2441;
            this.spdData_Sheet1.Columns.Get(423).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(423).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(424).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(424).CellType = textCellType2442;
            this.spdData_Sheet1.Columns.Get(424).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(424).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(425).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(425).CellType = textCellType2443;
            this.spdData_Sheet1.Columns.Get(425).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(425).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(426).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(426).CellType = textCellType2444;
            this.spdData_Sheet1.Columns.Get(426).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(426).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(427).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(427).CellType = textCellType2445;
            this.spdData_Sheet1.Columns.Get(427).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(427).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(428).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(428).CellType = textCellType2446;
            this.spdData_Sheet1.Columns.Get(428).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(428).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(429).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(429).CellType = textCellType2447;
            this.spdData_Sheet1.Columns.Get(429).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(429).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(430).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(430).CellType = textCellType2448;
            this.spdData_Sheet1.Columns.Get(430).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(430).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(431).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(431).CellType = textCellType2449;
            this.spdData_Sheet1.Columns.Get(431).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(431).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(432).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(432).CellType = textCellType2450;
            this.spdData_Sheet1.Columns.Get(432).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(432).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(433).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(433).CellType = textCellType2451;
            this.spdData_Sheet1.Columns.Get(433).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(433).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(434).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(434).CellType = textCellType2452;
            this.spdData_Sheet1.Columns.Get(434).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(434).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(435).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(435).CellType = textCellType2453;
            this.spdData_Sheet1.Columns.Get(435).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(435).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(436).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(436).CellType = textCellType2454;
            this.spdData_Sheet1.Columns.Get(436).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(436).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(437).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(437).CellType = textCellType2455;
            this.spdData_Sheet1.Columns.Get(437).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(437).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(438).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(438).CellType = textCellType2456;
            this.spdData_Sheet1.Columns.Get(438).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(438).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(439).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(439).CellType = textCellType2457;
            this.spdData_Sheet1.Columns.Get(439).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(439).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(440).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(440).CellType = textCellType2458;
            this.spdData_Sheet1.Columns.Get(440).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(440).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(441).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(441).CellType = textCellType2459;
            this.spdData_Sheet1.Columns.Get(441).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(441).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(442).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(442).CellType = textCellType2460;
            this.spdData_Sheet1.Columns.Get(442).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(442).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(443).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(443).CellType = textCellType2461;
            this.spdData_Sheet1.Columns.Get(443).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(443).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(444).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(444).CellType = textCellType2462;
            this.spdData_Sheet1.Columns.Get(444).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(444).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(445).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(445).CellType = textCellType2463;
            this.spdData_Sheet1.Columns.Get(445).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(445).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(446).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(446).CellType = textCellType2464;
            this.spdData_Sheet1.Columns.Get(446).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(446).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(447).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(447).CellType = textCellType2465;
            this.spdData_Sheet1.Columns.Get(447).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(447).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(448).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(448).CellType = textCellType2466;
            this.spdData_Sheet1.Columns.Get(448).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(448).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(449).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(449).CellType = textCellType2467;
            this.spdData_Sheet1.Columns.Get(449).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(449).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(450).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(450).CellType = textCellType2468;
            this.spdData_Sheet1.Columns.Get(450).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(450).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(451).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(451).CellType = textCellType2469;
            this.spdData_Sheet1.Columns.Get(451).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(451).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(452).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(452).CellType = textCellType2470;
            this.spdData_Sheet1.Columns.Get(452).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(452).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(453).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(453).CellType = textCellType2471;
            this.spdData_Sheet1.Columns.Get(453).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(453).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(454).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(454).CellType = textCellType2472;
            this.spdData_Sheet1.Columns.Get(454).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(454).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(455).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(455).CellType = textCellType2473;
            this.spdData_Sheet1.Columns.Get(455).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(455).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(456).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(456).CellType = textCellType2474;
            this.spdData_Sheet1.Columns.Get(456).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(456).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(457).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(457).CellType = textCellType2475;
            this.spdData_Sheet1.Columns.Get(457).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(457).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(458).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(458).CellType = textCellType2476;
            this.spdData_Sheet1.Columns.Get(458).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(458).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(459).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(459).CellType = textCellType2477;
            this.spdData_Sheet1.Columns.Get(459).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(459).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(460).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(460).CellType = textCellType2478;
            this.spdData_Sheet1.Columns.Get(460).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(460).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(461).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(461).CellType = textCellType2479;
            this.spdData_Sheet1.Columns.Get(461).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(461).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(462).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(462).CellType = textCellType2480;
            this.spdData_Sheet1.Columns.Get(462).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(462).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(463).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(463).CellType = textCellType2481;
            this.spdData_Sheet1.Columns.Get(463).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(463).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(464).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(464).CellType = textCellType2482;
            this.spdData_Sheet1.Columns.Get(464).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(464).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(465).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(465).CellType = textCellType2483;
            this.spdData_Sheet1.Columns.Get(465).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(465).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(466).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(466).CellType = textCellType2484;
            this.spdData_Sheet1.Columns.Get(466).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(466).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(467).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(467).CellType = textCellType2485;
            this.spdData_Sheet1.Columns.Get(467).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(467).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(468).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(468).CellType = textCellType2486;
            this.spdData_Sheet1.Columns.Get(468).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(468).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(469).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(469).CellType = textCellType2487;
            this.spdData_Sheet1.Columns.Get(469).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(469).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(470).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(470).CellType = textCellType2488;
            this.spdData_Sheet1.Columns.Get(470).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(470).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(471).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(471).CellType = textCellType2489;
            this.spdData_Sheet1.Columns.Get(471).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(471).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(472).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(472).CellType = textCellType2490;
            this.spdData_Sheet1.Columns.Get(472).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(472).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(473).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(473).CellType = textCellType2491;
            this.spdData_Sheet1.Columns.Get(473).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(473).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(474).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(474).CellType = textCellType2492;
            this.spdData_Sheet1.Columns.Get(474).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(474).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(475).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(475).CellType = textCellType2493;
            this.spdData_Sheet1.Columns.Get(475).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(475).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(476).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(476).CellType = textCellType2494;
            this.spdData_Sheet1.Columns.Get(476).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(476).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(477).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(477).CellType = textCellType2495;
            this.spdData_Sheet1.Columns.Get(477).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(477).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(478).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(478).CellType = textCellType2496;
            this.spdData_Sheet1.Columns.Get(478).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(478).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(479).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(479).CellType = textCellType2497;
            this.spdData_Sheet1.Columns.Get(479).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(479).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(480).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(480).CellType = textCellType2498;
            this.spdData_Sheet1.Columns.Get(480).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(480).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(481).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(481).CellType = textCellType2499;
            this.spdData_Sheet1.Columns.Get(481).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(481).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(482).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(482).CellType = textCellType2500;
            this.spdData_Sheet1.Columns.Get(482).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(482).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(483).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(483).CellType = textCellType2501;
            this.spdData_Sheet1.Columns.Get(483).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(483).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(484).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(484).CellType = textCellType2502;
            this.spdData_Sheet1.Columns.Get(484).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(484).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(485).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(485).CellType = textCellType2503;
            this.spdData_Sheet1.Columns.Get(485).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(485).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(486).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(486).CellType = textCellType2504;
            this.spdData_Sheet1.Columns.Get(486).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(486).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(487).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(487).CellType = textCellType2505;
            this.spdData_Sheet1.Columns.Get(487).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(487).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(488).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(488).CellType = textCellType2506;
            this.spdData_Sheet1.Columns.Get(488).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(488).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(489).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(489).CellType = textCellType2507;
            this.spdData_Sheet1.Columns.Get(489).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(489).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(490).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(490).CellType = textCellType2508;
            this.spdData_Sheet1.Columns.Get(490).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(490).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(491).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(491).CellType = textCellType2509;
            this.spdData_Sheet1.Columns.Get(491).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(491).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(492).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(492).CellType = textCellType2510;
            this.spdData_Sheet1.Columns.Get(492).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(492).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(493).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(493).CellType = textCellType2511;
            this.spdData_Sheet1.Columns.Get(493).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(493).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(494).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(494).CellType = textCellType2512;
            this.spdData_Sheet1.Columns.Get(494).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(494).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(495).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(495).CellType = textCellType2513;
            this.spdData_Sheet1.Columns.Get(495).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(495).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(496).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(496).CellType = textCellType2514;
            this.spdData_Sheet1.Columns.Get(496).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(496).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(497).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(497).CellType = textCellType2515;
            this.spdData_Sheet1.Columns.Get(497).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(497).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(498).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(498).CellType = textCellType2516;
            this.spdData_Sheet1.Columns.Get(498).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(498).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(499).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(499).CellType = textCellType2517;
            this.spdData_Sheet1.Columns.Get(499).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(499).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(500).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(500).CellType = textCellType2518;
            this.spdData_Sheet1.Columns.Get(500).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(500).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(501).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(501).CellType = textCellType2519;
            this.spdData_Sheet1.Columns.Get(501).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(501).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(502).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(502).CellType = textCellType2520;
            this.spdData_Sheet1.Columns.Get(502).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(502).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(503).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(503).CellType = textCellType2521;
            this.spdData_Sheet1.Columns.Get(503).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(503).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(504).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(504).CellType = textCellType2522;
            this.spdData_Sheet1.Columns.Get(504).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(504).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(505).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(505).CellType = textCellType2523;
            this.spdData_Sheet1.Columns.Get(505).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(505).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(506).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(506).CellType = textCellType2524;
            this.spdData_Sheet1.Columns.Get(506).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(506).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(507).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(507).CellType = textCellType2525;
            this.spdData_Sheet1.Columns.Get(507).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(507).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(508).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(508).CellType = textCellType2526;
            this.spdData_Sheet1.Columns.Get(508).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(508).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(509).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(509).CellType = textCellType2527;
            this.spdData_Sheet1.Columns.Get(509).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(509).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(510).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(510).CellType = textCellType2528;
            this.spdData_Sheet1.Columns.Get(510).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(510).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(511).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(511).CellType = textCellType2529;
            this.spdData_Sheet1.Columns.Get(511).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(511).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(512).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(512).CellType = textCellType2530;
            this.spdData_Sheet1.Columns.Get(512).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(512).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(513).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(513).CellType = textCellType2531;
            this.spdData_Sheet1.Columns.Get(513).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(513).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(514).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(514).CellType = textCellType2532;
            this.spdData_Sheet1.Columns.Get(514).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(514).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(515).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(515).CellType = textCellType2533;
            this.spdData_Sheet1.Columns.Get(515).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(515).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(516).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(516).CellType = textCellType2534;
            this.spdData_Sheet1.Columns.Get(516).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(516).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(517).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(517).CellType = textCellType2535;
            this.spdData_Sheet1.Columns.Get(517).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(517).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(518).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(518).CellType = textCellType2536;
            this.spdData_Sheet1.Columns.Get(518).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(518).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(519).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(519).CellType = textCellType2537;
            this.spdData_Sheet1.Columns.Get(519).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(519).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(520).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(520).CellType = textCellType2538;
            this.spdData_Sheet1.Columns.Get(520).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(520).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(521).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(521).CellType = textCellType2539;
            this.spdData_Sheet1.Columns.Get(521).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(521).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(522).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(522).CellType = textCellType2540;
            this.spdData_Sheet1.Columns.Get(522).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(522).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(523).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(523).CellType = textCellType2541;
            this.spdData_Sheet1.Columns.Get(523).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(523).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(524).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(524).CellType = textCellType2542;
            this.spdData_Sheet1.Columns.Get(524).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(524).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(525).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(525).CellType = textCellType2543;
            this.spdData_Sheet1.Columns.Get(525).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(525).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(526).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(526).CellType = textCellType2544;
            this.spdData_Sheet1.Columns.Get(526).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(526).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(527).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(527).CellType = textCellType2545;
            this.spdData_Sheet1.Columns.Get(527).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(527).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(528).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(528).CellType = textCellType2546;
            this.spdData_Sheet1.Columns.Get(528).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(528).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(529).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(529).CellType = textCellType2547;
            this.spdData_Sheet1.Columns.Get(529).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(529).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(530).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(530).CellType = textCellType2548;
            this.spdData_Sheet1.Columns.Get(530).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(530).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(531).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(531).CellType = textCellType2549;
            this.spdData_Sheet1.Columns.Get(531).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(531).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(532).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(532).CellType = textCellType2550;
            this.spdData_Sheet1.Columns.Get(532).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(532).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(533).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(533).CellType = textCellType2551;
            this.spdData_Sheet1.Columns.Get(533).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(533).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(534).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(534).CellType = textCellType2552;
            this.spdData_Sheet1.Columns.Get(534).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(534).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(535).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(535).CellType = textCellType2553;
            this.spdData_Sheet1.Columns.Get(535).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(535).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(536).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(536).CellType = textCellType2554;
            this.spdData_Sheet1.Columns.Get(536).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(536).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(537).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(537).CellType = textCellType2555;
            this.spdData_Sheet1.Columns.Get(537).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(537).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(538).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(538).CellType = textCellType2556;
            this.spdData_Sheet1.Columns.Get(538).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(538).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(539).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(539).CellType = textCellType2557;
            this.spdData_Sheet1.Columns.Get(539).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(539).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(540).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(540).CellType = textCellType2558;
            this.spdData_Sheet1.Columns.Get(540).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(540).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(541).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(541).CellType = textCellType2559;
            this.spdData_Sheet1.Columns.Get(541).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(541).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(542).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(542).CellType = textCellType2560;
            this.spdData_Sheet1.Columns.Get(542).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(542).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(543).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(543).CellType = textCellType2561;
            this.spdData_Sheet1.Columns.Get(543).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(543).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(544).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(544).CellType = textCellType2562;
            this.spdData_Sheet1.Columns.Get(544).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(544).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(545).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(545).CellType = textCellType2563;
            this.spdData_Sheet1.Columns.Get(545).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(545).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(546).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(546).CellType = textCellType2564;
            this.spdData_Sheet1.Columns.Get(546).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(546).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(547).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(547).CellType = textCellType2565;
            this.spdData_Sheet1.Columns.Get(547).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(547).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(548).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(548).CellType = textCellType2566;
            this.spdData_Sheet1.Columns.Get(548).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(548).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(549).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(549).CellType = textCellType2567;
            this.spdData_Sheet1.Columns.Get(549).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(549).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(550).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(550).CellType = textCellType2568;
            this.spdData_Sheet1.Columns.Get(550).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(550).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(551).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(551).CellType = textCellType2569;
            this.spdData_Sheet1.Columns.Get(551).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(551).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(552).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(552).CellType = textCellType2570;
            this.spdData_Sheet1.Columns.Get(552).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(552).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(553).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(553).CellType = textCellType2571;
            this.spdData_Sheet1.Columns.Get(553).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(553).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(554).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(554).CellType = textCellType2572;
            this.spdData_Sheet1.Columns.Get(554).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(554).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(555).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(555).CellType = textCellType2573;
            this.spdData_Sheet1.Columns.Get(555).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(555).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(556).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(556).CellType = textCellType2574;
            this.spdData_Sheet1.Columns.Get(556).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(556).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(557).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(557).CellType = textCellType2575;
            this.spdData_Sheet1.Columns.Get(557).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(557).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(558).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(558).CellType = textCellType2576;
            this.spdData_Sheet1.Columns.Get(558).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(558).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(559).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(559).CellType = textCellType2577;
            this.spdData_Sheet1.Columns.Get(559).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(559).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(560).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(560).CellType = textCellType2578;
            this.spdData_Sheet1.Columns.Get(560).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(560).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(561).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(561).CellType = textCellType2579;
            this.spdData_Sheet1.Columns.Get(561).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(561).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(562).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(562).CellType = textCellType2580;
            this.spdData_Sheet1.Columns.Get(562).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(562).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(563).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(563).CellType = textCellType2581;
            this.spdData_Sheet1.Columns.Get(563).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(563).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(564).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(564).CellType = textCellType2582;
            this.spdData_Sheet1.Columns.Get(564).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(564).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(565).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(565).CellType = textCellType2583;
            this.spdData_Sheet1.Columns.Get(565).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(565).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(566).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(566).CellType = textCellType2584;
            this.spdData_Sheet1.Columns.Get(566).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(566).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(567).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(567).CellType = textCellType2585;
            this.spdData_Sheet1.Columns.Get(567).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(567).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(568).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(568).CellType = textCellType2586;
            this.spdData_Sheet1.Columns.Get(568).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(568).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(569).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(569).CellType = textCellType2587;
            this.spdData_Sheet1.Columns.Get(569).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(569).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(570).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(570).CellType = textCellType2588;
            this.spdData_Sheet1.Columns.Get(570).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(570).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(571).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(571).CellType = textCellType2589;
            this.spdData_Sheet1.Columns.Get(571).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(571).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(572).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(572).CellType = textCellType2590;
            this.spdData_Sheet1.Columns.Get(572).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(572).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(573).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(573).CellType = textCellType2591;
            this.spdData_Sheet1.Columns.Get(573).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(573).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(574).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(574).CellType = textCellType2592;
            this.spdData_Sheet1.Columns.Get(574).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(574).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(575).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(575).CellType = textCellType2593;
            this.spdData_Sheet1.Columns.Get(575).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(575).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(576).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(576).CellType = textCellType2594;
            this.spdData_Sheet1.Columns.Get(576).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(576).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(577).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(577).CellType = textCellType2595;
            this.spdData_Sheet1.Columns.Get(577).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(577).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(578).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(578).CellType = textCellType2596;
            this.spdData_Sheet1.Columns.Get(578).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(578).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(579).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(579).CellType = textCellType2597;
            this.spdData_Sheet1.Columns.Get(579).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(579).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(580).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(580).CellType = textCellType2598;
            this.spdData_Sheet1.Columns.Get(580).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(580).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(581).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(581).CellType = textCellType2599;
            this.spdData_Sheet1.Columns.Get(581).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(581).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(582).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(582).CellType = textCellType2600;
            this.spdData_Sheet1.Columns.Get(582).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(582).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(583).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(583).CellType = textCellType2601;
            this.spdData_Sheet1.Columns.Get(583).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(583).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(584).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(584).CellType = textCellType2602;
            this.spdData_Sheet1.Columns.Get(584).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(584).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(585).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(585).CellType = textCellType2603;
            this.spdData_Sheet1.Columns.Get(585).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(585).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(586).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(586).CellType = textCellType2604;
            this.spdData_Sheet1.Columns.Get(586).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(586).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(587).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(587).CellType = textCellType2605;
            this.spdData_Sheet1.Columns.Get(587).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(587).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(588).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(588).CellType = textCellType2606;
            this.spdData_Sheet1.Columns.Get(588).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(588).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(589).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(589).CellType = textCellType2607;
            this.spdData_Sheet1.Columns.Get(589).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(589).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(590).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(590).CellType = textCellType2608;
            this.spdData_Sheet1.Columns.Get(590).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(590).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(591).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(591).CellType = textCellType2609;
            this.spdData_Sheet1.Columns.Get(591).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(591).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(592).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(592).CellType = textCellType2610;
            this.spdData_Sheet1.Columns.Get(592).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(592).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(593).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(593).CellType = textCellType2611;
            this.spdData_Sheet1.Columns.Get(593).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(593).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(594).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(594).CellType = textCellType2612;
            this.spdData_Sheet1.Columns.Get(594).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(594).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(595).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(595).CellType = textCellType2613;
            this.spdData_Sheet1.Columns.Get(595).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(595).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(596).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(596).CellType = textCellType2614;
            this.spdData_Sheet1.Columns.Get(596).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(596).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(597).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(597).CellType = textCellType2615;
            this.spdData_Sheet1.Columns.Get(597).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(597).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(598).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(598).CellType = textCellType2616;
            this.spdData_Sheet1.Columns.Get(598).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(598).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(599).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(599).CellType = textCellType2617;
            this.spdData_Sheet1.Columns.Get(599).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(599).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(600).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(600).CellType = textCellType2618;
            this.spdData_Sheet1.Columns.Get(600).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(600).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(601).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(601).CellType = textCellType2619;
            this.spdData_Sheet1.Columns.Get(601).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(601).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(602).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(602).CellType = textCellType2620;
            this.spdData_Sheet1.Columns.Get(602).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(602).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(603).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(603).CellType = textCellType2621;
            this.spdData_Sheet1.Columns.Get(603).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(603).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(604).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(604).CellType = textCellType2622;
            this.spdData_Sheet1.Columns.Get(604).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(604).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(605).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(605).CellType = textCellType2623;
            this.spdData_Sheet1.Columns.Get(605).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(605).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(606).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(606).CellType = textCellType2624;
            this.spdData_Sheet1.Columns.Get(606).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(606).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(607).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(607).CellType = textCellType2625;
            this.spdData_Sheet1.Columns.Get(607).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(607).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(608).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(608).CellType = textCellType2626;
            this.spdData_Sheet1.Columns.Get(608).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(608).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(609).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(609).CellType = textCellType2627;
            this.spdData_Sheet1.Columns.Get(609).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(609).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(610).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(610).CellType = textCellType2628;
            this.spdData_Sheet1.Columns.Get(610).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(610).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(611).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(611).CellType = textCellType2629;
            this.spdData_Sheet1.Columns.Get(611).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(611).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(612).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(612).CellType = textCellType2630;
            this.spdData_Sheet1.Columns.Get(612).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(612).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(613).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(613).CellType = textCellType2631;
            this.spdData_Sheet1.Columns.Get(613).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(613).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(614).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(614).CellType = textCellType2632;
            this.spdData_Sheet1.Columns.Get(614).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(614).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(615).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(615).CellType = textCellType2633;
            this.spdData_Sheet1.Columns.Get(615).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(615).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(616).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(616).CellType = textCellType2634;
            this.spdData_Sheet1.Columns.Get(616).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(616).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(617).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(617).CellType = textCellType2635;
            this.spdData_Sheet1.Columns.Get(617).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(617).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(618).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(618).CellType = textCellType2636;
            this.spdData_Sheet1.Columns.Get(618).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(618).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(619).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(619).CellType = textCellType2637;
            this.spdData_Sheet1.Columns.Get(619).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(619).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(620).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(620).CellType = textCellType2638;
            this.spdData_Sheet1.Columns.Get(620).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(620).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(621).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(621).CellType = textCellType2639;
            this.spdData_Sheet1.Columns.Get(621).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(621).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(622).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(622).CellType = textCellType2640;
            this.spdData_Sheet1.Columns.Get(622).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(622).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(623).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(623).CellType = textCellType2641;
            this.spdData_Sheet1.Columns.Get(623).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(623).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(624).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(624).CellType = textCellType2642;
            this.spdData_Sheet1.Columns.Get(624).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(624).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(625).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(625).CellType = textCellType2643;
            this.spdData_Sheet1.Columns.Get(625).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(625).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(626).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(626).CellType = textCellType2644;
            this.spdData_Sheet1.Columns.Get(626).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(626).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(627).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(627).CellType = textCellType2645;
            this.spdData_Sheet1.Columns.Get(627).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(627).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(628).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(628).CellType = textCellType2646;
            this.spdData_Sheet1.Columns.Get(628).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(628).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(629).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(629).CellType = textCellType2647;
            this.spdData_Sheet1.Columns.Get(629).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(629).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(630).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(630).CellType = textCellType2648;
            this.spdData_Sheet1.Columns.Get(630).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(630).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(631).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(631).CellType = textCellType2649;
            this.spdData_Sheet1.Columns.Get(631).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(631).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(632).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(632).CellType = textCellType2650;
            this.spdData_Sheet1.Columns.Get(632).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(632).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(633).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(633).CellType = textCellType2651;
            this.spdData_Sheet1.Columns.Get(633).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(633).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(634).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(634).CellType = textCellType2652;
            this.spdData_Sheet1.Columns.Get(634).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(634).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(635).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(635).CellType = textCellType2653;
            this.spdData_Sheet1.Columns.Get(635).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(635).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(636).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(636).CellType = textCellType2654;
            this.spdData_Sheet1.Columns.Get(636).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(636).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(637).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(637).CellType = textCellType2655;
            this.spdData_Sheet1.Columns.Get(637).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(637).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(638).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(638).CellType = textCellType2656;
            this.spdData_Sheet1.Columns.Get(638).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(638).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(639).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(639).CellType = textCellType2657;
            this.spdData_Sheet1.Columns.Get(639).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(639).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(640).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(640).CellType = textCellType2658;
            this.spdData_Sheet1.Columns.Get(640).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(640).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(641).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(641).CellType = textCellType2659;
            this.spdData_Sheet1.Columns.Get(641).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(641).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(642).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(642).CellType = textCellType2660;
            this.spdData_Sheet1.Columns.Get(642).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(642).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(643).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(643).CellType = textCellType2661;
            this.spdData_Sheet1.Columns.Get(643).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(643).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(644).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(644).CellType = textCellType2662;
            this.spdData_Sheet1.Columns.Get(644).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(644).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(645).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(645).CellType = textCellType2663;
            this.spdData_Sheet1.Columns.Get(645).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(645).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(646).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(646).CellType = textCellType2664;
            this.spdData_Sheet1.Columns.Get(646).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(646).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(647).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(647).CellType = textCellType2665;
            this.spdData_Sheet1.Columns.Get(647).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(647).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(648).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(648).CellType = textCellType2666;
            this.spdData_Sheet1.Columns.Get(648).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(648).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(649).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(649).CellType = textCellType2667;
            this.spdData_Sheet1.Columns.Get(649).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(649).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(650).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(650).CellType = textCellType2668;
            this.spdData_Sheet1.Columns.Get(650).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(650).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(651).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(651).CellType = textCellType2669;
            this.spdData_Sheet1.Columns.Get(651).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(651).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(652).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(652).CellType = textCellType2670;
            this.spdData_Sheet1.Columns.Get(652).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(652).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(653).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(653).CellType = textCellType2671;
            this.spdData_Sheet1.Columns.Get(653).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(653).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(654).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(654).CellType = textCellType2672;
            this.spdData_Sheet1.Columns.Get(654).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(654).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(655).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(655).CellType = textCellType2673;
            this.spdData_Sheet1.Columns.Get(655).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(655).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(656).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(656).CellType = textCellType2674;
            this.spdData_Sheet1.Columns.Get(656).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(656).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(657).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(657).CellType = textCellType2675;
            this.spdData_Sheet1.Columns.Get(657).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(657).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(658).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(658).CellType = textCellType2676;
            this.spdData_Sheet1.Columns.Get(658).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(658).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(659).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(659).CellType = textCellType2677;
            this.spdData_Sheet1.Columns.Get(659).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(659).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(660).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(660).CellType = textCellType2678;
            this.spdData_Sheet1.Columns.Get(660).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(660).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(661).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(661).CellType = textCellType2679;
            this.spdData_Sheet1.Columns.Get(661).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(661).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(662).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(662).CellType = textCellType2680;
            this.spdData_Sheet1.Columns.Get(662).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(662).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(663).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(663).CellType = textCellType2681;
            this.spdData_Sheet1.Columns.Get(663).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(663).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(664).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(664).CellType = textCellType2682;
            this.spdData_Sheet1.Columns.Get(664).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(664).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(665).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(665).CellType = textCellType2683;
            this.spdData_Sheet1.Columns.Get(665).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(665).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(666).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(666).CellType = textCellType2684;
            this.spdData_Sheet1.Columns.Get(666).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(666).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(667).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(667).CellType = textCellType2685;
            this.spdData_Sheet1.Columns.Get(667).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(667).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(668).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(668).CellType = textCellType2686;
            this.spdData_Sheet1.Columns.Get(668).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(668).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(669).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(669).CellType = textCellType2687;
            this.spdData_Sheet1.Columns.Get(669).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(669).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(670).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(670).CellType = textCellType2688;
            this.spdData_Sheet1.Columns.Get(670).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(670).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(671).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(671).CellType = textCellType2689;
            this.spdData_Sheet1.Columns.Get(671).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(671).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(672).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(672).CellType = textCellType2690;
            this.spdData_Sheet1.Columns.Get(672).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(672).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(673).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(673).CellType = textCellType2691;
            this.spdData_Sheet1.Columns.Get(673).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(673).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(674).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(674).CellType = textCellType2692;
            this.spdData_Sheet1.Columns.Get(674).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(674).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(675).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(675).CellType = textCellType2693;
            this.spdData_Sheet1.Columns.Get(675).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(675).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(676).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(676).CellType = textCellType2694;
            this.spdData_Sheet1.Columns.Get(676).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(676).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(677).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(677).CellType = textCellType2695;
            this.spdData_Sheet1.Columns.Get(677).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(677).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(678).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(678).CellType = textCellType2696;
            this.spdData_Sheet1.Columns.Get(678).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(678).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(679).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(679).CellType = textCellType2697;
            this.spdData_Sheet1.Columns.Get(679).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(679).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(680).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(680).CellType = textCellType2698;
            this.spdData_Sheet1.Columns.Get(680).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(680).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(681).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(681).CellType = textCellType2699;
            this.spdData_Sheet1.Columns.Get(681).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(681).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(682).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(682).CellType = textCellType2700;
            this.spdData_Sheet1.Columns.Get(682).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(682).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(683).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(683).CellType = textCellType2701;
            this.spdData_Sheet1.Columns.Get(683).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(683).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(684).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(684).CellType = textCellType2702;
            this.spdData_Sheet1.Columns.Get(684).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(684).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(685).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(685).CellType = textCellType2703;
            this.spdData_Sheet1.Columns.Get(685).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(685).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(686).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(686).CellType = textCellType2704;
            this.spdData_Sheet1.Columns.Get(686).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(686).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(687).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(687).CellType = textCellType2705;
            this.spdData_Sheet1.Columns.Get(687).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(687).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(688).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(688).CellType = textCellType2706;
            this.spdData_Sheet1.Columns.Get(688).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(688).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(689).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(689).CellType = textCellType2707;
            this.spdData_Sheet1.Columns.Get(689).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(689).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(690).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(690).CellType = textCellType2708;
            this.spdData_Sheet1.Columns.Get(690).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(690).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(691).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(691).CellType = textCellType2709;
            this.spdData_Sheet1.Columns.Get(691).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(691).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(692).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(692).CellType = textCellType2710;
            this.spdData_Sheet1.Columns.Get(692).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(692).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(693).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(693).CellType = textCellType2711;
            this.spdData_Sheet1.Columns.Get(693).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(693).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(694).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(694).CellType = textCellType2712;
            this.spdData_Sheet1.Columns.Get(694).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(694).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(695).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(695).CellType = textCellType2713;
            this.spdData_Sheet1.Columns.Get(695).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(695).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(696).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(696).CellType = textCellType2714;
            this.spdData_Sheet1.Columns.Get(696).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(696).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(697).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(697).CellType = textCellType2715;
            this.spdData_Sheet1.Columns.Get(697).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(697).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(698).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(698).CellType = textCellType2716;
            this.spdData_Sheet1.Columns.Get(698).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(698).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(699).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(699).CellType = textCellType2717;
            this.spdData_Sheet1.Columns.Get(699).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(699).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(700).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(700).CellType = textCellType2718;
            this.spdData_Sheet1.Columns.Get(700).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(700).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(701).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(701).CellType = textCellType2719;
            this.spdData_Sheet1.Columns.Get(701).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(701).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(702).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(702).CellType = textCellType2720;
            this.spdData_Sheet1.Columns.Get(702).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(702).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(703).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(703).CellType = textCellType2721;
            this.spdData_Sheet1.Columns.Get(703).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(703).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(704).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(704).CellType = textCellType2722;
            this.spdData_Sheet1.Columns.Get(704).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(704).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(705).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(705).CellType = textCellType2723;
            this.spdData_Sheet1.Columns.Get(705).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(705).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(706).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(706).CellType = textCellType2724;
            this.spdData_Sheet1.Columns.Get(706).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(706).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(707).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(707).CellType = textCellType2725;
            this.spdData_Sheet1.Columns.Get(707).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(707).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(708).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(708).CellType = textCellType2726;
            this.spdData_Sheet1.Columns.Get(708).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(708).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(709).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(709).CellType = textCellType2727;
            this.spdData_Sheet1.Columns.Get(709).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(709).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(710).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(710).CellType = textCellType2728;
            this.spdData_Sheet1.Columns.Get(710).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(710).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(711).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(711).CellType = textCellType2729;
            this.spdData_Sheet1.Columns.Get(711).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(711).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(712).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(712).CellType = textCellType2730;
            this.spdData_Sheet1.Columns.Get(712).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(712).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(713).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(713).CellType = textCellType2731;
            this.spdData_Sheet1.Columns.Get(713).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(713).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(714).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(714).CellType = textCellType2732;
            this.spdData_Sheet1.Columns.Get(714).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(714).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(715).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(715).CellType = textCellType2733;
            this.spdData_Sheet1.Columns.Get(715).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(715).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(716).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(716).CellType = textCellType2734;
            this.spdData_Sheet1.Columns.Get(716).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(716).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(717).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(717).CellType = textCellType2735;
            this.spdData_Sheet1.Columns.Get(717).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(717).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(718).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(718).CellType = textCellType2736;
            this.spdData_Sheet1.Columns.Get(718).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(718).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(719).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(719).CellType = textCellType2737;
            this.spdData_Sheet1.Columns.Get(719).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(719).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(720).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(720).CellType = textCellType2738;
            this.spdData_Sheet1.Columns.Get(720).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(720).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(721).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(721).CellType = textCellType2739;
            this.spdData_Sheet1.Columns.Get(721).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(721).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(722).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(722).CellType = textCellType2740;
            this.spdData_Sheet1.Columns.Get(722).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(722).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(723).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(723).CellType = textCellType2741;
            this.spdData_Sheet1.Columns.Get(723).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(723).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(724).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(724).CellType = textCellType2742;
            this.spdData_Sheet1.Columns.Get(724).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(724).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(725).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(725).CellType = textCellType2743;
            this.spdData_Sheet1.Columns.Get(725).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(725).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(726).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(726).CellType = textCellType2744;
            this.spdData_Sheet1.Columns.Get(726).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(726).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(727).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(727).CellType = textCellType2745;
            this.spdData_Sheet1.Columns.Get(727).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(727).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(728).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(728).CellType = textCellType2746;
            this.spdData_Sheet1.Columns.Get(728).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(728).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(729).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(729).CellType = textCellType2747;
            this.spdData_Sheet1.Columns.Get(729).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(729).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(730).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(730).CellType = textCellType2748;
            this.spdData_Sheet1.Columns.Get(730).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(730).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(731).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(731).CellType = textCellType2749;
            this.spdData_Sheet1.Columns.Get(731).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(731).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(732).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(732).CellType = textCellType2750;
            this.spdData_Sheet1.Columns.Get(732).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(732).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(733).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(733).CellType = textCellType2751;
            this.spdData_Sheet1.Columns.Get(733).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(733).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(734).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(734).CellType = textCellType2752;
            this.spdData_Sheet1.Columns.Get(734).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(734).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(735).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(735).CellType = textCellType2753;
            this.spdData_Sheet1.Columns.Get(735).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(735).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(736).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(736).CellType = textCellType2754;
            this.spdData_Sheet1.Columns.Get(736).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(736).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(737).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(737).CellType = textCellType2755;
            this.spdData_Sheet1.Columns.Get(737).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(737).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(738).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(738).CellType = textCellType2756;
            this.spdData_Sheet1.Columns.Get(738).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(738).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(739).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(739).CellType = textCellType2757;
            this.spdData_Sheet1.Columns.Get(739).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(739).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(740).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(740).CellType = textCellType2758;
            this.spdData_Sheet1.Columns.Get(740).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(740).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(741).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(741).CellType = textCellType2759;
            this.spdData_Sheet1.Columns.Get(741).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(741).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(742).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(742).CellType = textCellType2760;
            this.spdData_Sheet1.Columns.Get(742).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(742).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(743).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(743).CellType = textCellType2761;
            this.spdData_Sheet1.Columns.Get(743).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(743).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(744).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(744).CellType = textCellType2762;
            this.spdData_Sheet1.Columns.Get(744).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(744).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(745).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(745).CellType = textCellType2763;
            this.spdData_Sheet1.Columns.Get(745).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(745).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(746).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(746).CellType = textCellType2764;
            this.spdData_Sheet1.Columns.Get(746).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(746).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(747).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(747).CellType = textCellType2765;
            this.spdData_Sheet1.Columns.Get(747).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(747).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(748).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(748).CellType = textCellType2766;
            this.spdData_Sheet1.Columns.Get(748).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(748).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(749).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(749).CellType = textCellType2767;
            this.spdData_Sheet1.Columns.Get(749).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(749).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(750).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(750).CellType = textCellType2768;
            this.spdData_Sheet1.Columns.Get(750).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(750).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(751).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(751).CellType = textCellType2769;
            this.spdData_Sheet1.Columns.Get(751).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(751).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(752).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(752).CellType = textCellType2770;
            this.spdData_Sheet1.Columns.Get(752).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(752).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(753).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(753).CellType = textCellType2771;
            this.spdData_Sheet1.Columns.Get(753).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(753).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(754).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(754).CellType = textCellType2772;
            this.spdData_Sheet1.Columns.Get(754).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(754).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(755).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(755).CellType = textCellType2773;
            this.spdData_Sheet1.Columns.Get(755).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(755).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(756).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(756).CellType = textCellType2774;
            this.spdData_Sheet1.Columns.Get(756).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(756).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(757).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(757).CellType = textCellType2775;
            this.spdData_Sheet1.Columns.Get(757).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(757).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(758).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(758).CellType = textCellType2776;
            this.spdData_Sheet1.Columns.Get(758).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(758).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(759).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(759).CellType = textCellType2777;
            this.spdData_Sheet1.Columns.Get(759).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(759).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(760).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(760).CellType = textCellType2778;
            this.spdData_Sheet1.Columns.Get(760).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(760).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(761).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(761).CellType = textCellType2779;
            this.spdData_Sheet1.Columns.Get(761).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(761).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(762).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(762).CellType = textCellType2780;
            this.spdData_Sheet1.Columns.Get(762).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(762).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(763).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(763).CellType = textCellType2781;
            this.spdData_Sheet1.Columns.Get(763).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(763).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(764).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(764).CellType = textCellType2782;
            this.spdData_Sheet1.Columns.Get(764).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(764).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(765).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(765).CellType = textCellType2783;
            this.spdData_Sheet1.Columns.Get(765).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(765).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(766).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(766).CellType = textCellType2784;
            this.spdData_Sheet1.Columns.Get(766).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(766).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(767).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(767).CellType = textCellType2785;
            this.spdData_Sheet1.Columns.Get(767).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(767).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(768).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(768).CellType = textCellType2786;
            this.spdData_Sheet1.Columns.Get(768).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(768).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(769).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(769).CellType = textCellType2787;
            this.spdData_Sheet1.Columns.Get(769).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(769).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(770).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(770).CellType = textCellType2788;
            this.spdData_Sheet1.Columns.Get(770).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(770).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(771).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(771).CellType = textCellType2789;
            this.spdData_Sheet1.Columns.Get(771).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(771).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(772).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(772).CellType = textCellType2790;
            this.spdData_Sheet1.Columns.Get(772).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(772).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(773).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(773).CellType = textCellType2791;
            this.spdData_Sheet1.Columns.Get(773).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(773).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(774).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(774).CellType = textCellType2792;
            this.spdData_Sheet1.Columns.Get(774).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(774).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(775).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(775).CellType = textCellType2793;
            this.spdData_Sheet1.Columns.Get(775).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(775).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(776).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(776).CellType = textCellType2794;
            this.spdData_Sheet1.Columns.Get(776).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(776).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(777).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(777).CellType = textCellType2795;
            this.spdData_Sheet1.Columns.Get(777).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(777).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(778).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(778).CellType = textCellType2796;
            this.spdData_Sheet1.Columns.Get(778).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(778).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(779).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(779).CellType = textCellType2797;
            this.spdData_Sheet1.Columns.Get(779).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(779).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(780).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(780).CellType = textCellType2798;
            this.spdData_Sheet1.Columns.Get(780).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(780).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(781).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(781).CellType = textCellType2799;
            this.spdData_Sheet1.Columns.Get(781).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(781).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(782).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(782).CellType = textCellType2800;
            this.spdData_Sheet1.Columns.Get(782).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(782).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(783).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(783).CellType = textCellType2801;
            this.spdData_Sheet1.Columns.Get(783).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(783).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(784).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(784).CellType = textCellType2802;
            this.spdData_Sheet1.Columns.Get(784).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(784).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(785).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(785).CellType = textCellType2803;
            this.spdData_Sheet1.Columns.Get(785).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(785).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(786).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(786).CellType = textCellType2804;
            this.spdData_Sheet1.Columns.Get(786).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(786).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(787).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(787).CellType = textCellType2805;
            this.spdData_Sheet1.Columns.Get(787).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(787).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(788).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(788).CellType = textCellType2806;
            this.spdData_Sheet1.Columns.Get(788).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(788).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(789).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(789).CellType = textCellType2807;
            this.spdData_Sheet1.Columns.Get(789).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(789).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(790).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(790).CellType = textCellType2808;
            this.spdData_Sheet1.Columns.Get(790).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(790).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(791).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(791).CellType = textCellType2809;
            this.spdData_Sheet1.Columns.Get(791).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(791).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(792).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(792).CellType = textCellType2810;
            this.spdData_Sheet1.Columns.Get(792).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(792).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(793).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(793).CellType = textCellType2811;
            this.spdData_Sheet1.Columns.Get(793).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(793).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(794).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(794).CellType = textCellType2812;
            this.spdData_Sheet1.Columns.Get(794).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(794).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(795).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(795).CellType = textCellType2813;
            this.spdData_Sheet1.Columns.Get(795).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(795).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(796).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(796).CellType = textCellType2814;
            this.spdData_Sheet1.Columns.Get(796).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(796).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(797).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(797).CellType = textCellType2815;
            this.spdData_Sheet1.Columns.Get(797).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(797).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(798).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(798).CellType = textCellType2816;
            this.spdData_Sheet1.Columns.Get(798).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(798).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(799).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(799).CellType = textCellType2817;
            this.spdData_Sheet1.Columns.Get(799).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(799).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(800).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(800).CellType = textCellType2818;
            this.spdData_Sheet1.Columns.Get(800).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(800).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(801).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(801).CellType = textCellType2819;
            this.spdData_Sheet1.Columns.Get(801).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(801).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(802).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(802).CellType = textCellType2820;
            this.spdData_Sheet1.Columns.Get(802).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(802).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(803).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(803).CellType = textCellType2821;
            this.spdData_Sheet1.Columns.Get(803).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(803).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(804).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(804).CellType = textCellType2822;
            this.spdData_Sheet1.Columns.Get(804).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(804).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(805).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(805).CellType = textCellType2823;
            this.spdData_Sheet1.Columns.Get(805).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(805).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(806).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(806).CellType = textCellType2824;
            this.spdData_Sheet1.Columns.Get(806).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(806).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(807).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(807).CellType = textCellType2825;
            this.spdData_Sheet1.Columns.Get(807).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(807).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(808).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(808).CellType = textCellType2826;
            this.spdData_Sheet1.Columns.Get(808).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(808).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(809).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(809).CellType = textCellType2827;
            this.spdData_Sheet1.Columns.Get(809).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(809).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(810).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(810).CellType = textCellType2828;
            this.spdData_Sheet1.Columns.Get(810).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(810).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(811).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(811).CellType = textCellType2829;
            this.spdData_Sheet1.Columns.Get(811).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(811).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(812).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(812).CellType = textCellType2830;
            this.spdData_Sheet1.Columns.Get(812).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(812).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(813).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(813).CellType = textCellType2831;
            this.spdData_Sheet1.Columns.Get(813).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(813).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(814).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(814).CellType = textCellType2832;
            this.spdData_Sheet1.Columns.Get(814).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(814).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(815).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(815).CellType = textCellType2833;
            this.spdData_Sheet1.Columns.Get(815).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(815).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(816).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(816).CellType = textCellType2834;
            this.spdData_Sheet1.Columns.Get(816).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(816).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(817).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(817).CellType = textCellType2835;
            this.spdData_Sheet1.Columns.Get(817).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(817).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(818).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(818).CellType = textCellType2836;
            this.spdData_Sheet1.Columns.Get(818).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(818).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(819).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(819).CellType = textCellType2837;
            this.spdData_Sheet1.Columns.Get(819).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(819).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(820).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(820).CellType = textCellType2838;
            this.spdData_Sheet1.Columns.Get(820).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(820).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(821).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(821).CellType = textCellType2839;
            this.spdData_Sheet1.Columns.Get(821).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(821).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(822).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(822).CellType = textCellType2840;
            this.spdData_Sheet1.Columns.Get(822).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(822).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(823).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(823).CellType = textCellType2841;
            this.spdData_Sheet1.Columns.Get(823).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(823).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(824).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(824).CellType = textCellType2842;
            this.spdData_Sheet1.Columns.Get(824).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(824).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(825).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(825).CellType = textCellType2843;
            this.spdData_Sheet1.Columns.Get(825).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(825).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(826).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(826).CellType = textCellType2844;
            this.spdData_Sheet1.Columns.Get(826).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(826).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(827).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(827).CellType = textCellType2845;
            this.spdData_Sheet1.Columns.Get(827).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(827).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(828).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(828).CellType = textCellType2846;
            this.spdData_Sheet1.Columns.Get(828).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(828).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(829).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(829).CellType = textCellType2847;
            this.spdData_Sheet1.Columns.Get(829).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(829).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(830).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(830).CellType = textCellType2848;
            this.spdData_Sheet1.Columns.Get(830).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(830).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(831).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(831).CellType = textCellType2849;
            this.spdData_Sheet1.Columns.Get(831).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(831).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(832).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(832).CellType = textCellType2850;
            this.spdData_Sheet1.Columns.Get(832).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(832).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(833).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(833).CellType = textCellType2851;
            this.spdData_Sheet1.Columns.Get(833).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(833).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(834).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(834).CellType = textCellType2852;
            this.spdData_Sheet1.Columns.Get(834).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(834).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(835).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(835).CellType = textCellType2853;
            this.spdData_Sheet1.Columns.Get(835).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(835).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(836).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(836).CellType = textCellType2854;
            this.spdData_Sheet1.Columns.Get(836).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(836).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(837).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(837).CellType = textCellType2855;
            this.spdData_Sheet1.Columns.Get(837).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(837).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(838).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(838).CellType = textCellType2856;
            this.spdData_Sheet1.Columns.Get(838).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(838).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(839).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(839).CellType = textCellType2857;
            this.spdData_Sheet1.Columns.Get(839).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(839).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(840).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(840).CellType = textCellType2858;
            this.spdData_Sheet1.Columns.Get(840).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(840).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(841).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(841).CellType = textCellType2859;
            this.spdData_Sheet1.Columns.Get(841).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(841).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(842).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(842).CellType = textCellType2860;
            this.spdData_Sheet1.Columns.Get(842).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(842).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(843).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(843).CellType = textCellType2861;
            this.spdData_Sheet1.Columns.Get(843).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(843).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(844).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(844).CellType = textCellType2862;
            this.spdData_Sheet1.Columns.Get(844).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(844).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(845).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(845).CellType = textCellType2863;
            this.spdData_Sheet1.Columns.Get(845).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(845).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(846).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(846).CellType = textCellType2864;
            this.spdData_Sheet1.Columns.Get(846).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(846).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(847).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(847).CellType = textCellType2865;
            this.spdData_Sheet1.Columns.Get(847).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(847).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(848).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(848).CellType = textCellType2866;
            this.spdData_Sheet1.Columns.Get(848).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(848).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(849).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(849).CellType = textCellType2867;
            this.spdData_Sheet1.Columns.Get(849).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(849).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(850).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(850).CellType = textCellType2868;
            this.spdData_Sheet1.Columns.Get(850).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(850).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(851).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(851).CellType = textCellType2869;
            this.spdData_Sheet1.Columns.Get(851).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(851).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(852).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(852).CellType = textCellType2870;
            this.spdData_Sheet1.Columns.Get(852).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(852).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(853).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(853).CellType = textCellType2871;
            this.spdData_Sheet1.Columns.Get(853).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(853).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(854).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(854).CellType = textCellType2872;
            this.spdData_Sheet1.Columns.Get(854).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(854).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(855).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(855).CellType = textCellType2873;
            this.spdData_Sheet1.Columns.Get(855).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(855).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(856).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(856).CellType = textCellType2874;
            this.spdData_Sheet1.Columns.Get(856).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(856).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(857).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(857).CellType = textCellType2875;
            this.spdData_Sheet1.Columns.Get(857).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(857).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(858).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(858).CellType = textCellType2876;
            this.spdData_Sheet1.Columns.Get(858).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(858).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(859).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(859).CellType = textCellType2877;
            this.spdData_Sheet1.Columns.Get(859).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(859).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(860).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(860).CellType = textCellType2878;
            this.spdData_Sheet1.Columns.Get(860).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(860).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(861).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(861).CellType = textCellType2879;
            this.spdData_Sheet1.Columns.Get(861).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(861).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(862).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(862).CellType = textCellType2880;
            this.spdData_Sheet1.Columns.Get(862).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(862).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(863).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(863).CellType = textCellType2881;
            this.spdData_Sheet1.Columns.Get(863).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(863).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(864).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(864).CellType = textCellType2882;
            this.spdData_Sheet1.Columns.Get(864).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(864).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(865).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(865).CellType = textCellType2883;
            this.spdData_Sheet1.Columns.Get(865).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(865).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(866).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(866).CellType = textCellType2884;
            this.spdData_Sheet1.Columns.Get(866).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(866).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(867).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(867).CellType = textCellType2885;
            this.spdData_Sheet1.Columns.Get(867).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(867).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(868).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(868).CellType = textCellType2886;
            this.spdData_Sheet1.Columns.Get(868).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(868).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(869).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(869).CellType = textCellType2887;
            this.spdData_Sheet1.Columns.Get(869).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(869).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(870).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(870).CellType = textCellType2888;
            this.spdData_Sheet1.Columns.Get(870).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(870).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(871).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(871).CellType = textCellType2889;
            this.spdData_Sheet1.Columns.Get(871).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(871).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(872).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(872).CellType = textCellType2890;
            this.spdData_Sheet1.Columns.Get(872).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(872).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(873).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(873).CellType = textCellType2891;
            this.spdData_Sheet1.Columns.Get(873).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(873).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(874).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(874).CellType = textCellType2892;
            this.spdData_Sheet1.Columns.Get(874).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(874).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(875).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(875).CellType = textCellType2893;
            this.spdData_Sheet1.Columns.Get(875).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(875).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(876).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(876).CellType = textCellType2894;
            this.spdData_Sheet1.Columns.Get(876).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(876).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(877).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(877).CellType = textCellType2895;
            this.spdData_Sheet1.Columns.Get(877).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(877).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(878).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(878).CellType = textCellType2896;
            this.spdData_Sheet1.Columns.Get(878).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(878).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(879).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(879).CellType = textCellType2897;
            this.spdData_Sheet1.Columns.Get(879).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(879).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(880).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(880).CellType = textCellType2898;
            this.spdData_Sheet1.Columns.Get(880).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(880).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(881).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(881).CellType = textCellType2899;
            this.spdData_Sheet1.Columns.Get(881).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(881).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(882).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(882).CellType = textCellType2900;
            this.spdData_Sheet1.Columns.Get(882).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(882).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(883).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(883).CellType = textCellType2901;
            this.spdData_Sheet1.Columns.Get(883).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(883).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(884).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(884).CellType = textCellType2902;
            this.spdData_Sheet1.Columns.Get(884).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(884).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(885).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(885).CellType = textCellType2903;
            this.spdData_Sheet1.Columns.Get(885).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(885).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(886).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(886).CellType = textCellType2904;
            this.spdData_Sheet1.Columns.Get(886).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(886).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(887).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(887).CellType = textCellType2905;
            this.spdData_Sheet1.Columns.Get(887).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(887).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(888).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(888).CellType = textCellType2906;
            this.spdData_Sheet1.Columns.Get(888).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(888).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(889).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(889).CellType = textCellType2907;
            this.spdData_Sheet1.Columns.Get(889).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(889).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(890).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(890).CellType = textCellType2908;
            this.spdData_Sheet1.Columns.Get(890).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(890).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(891).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(891).CellType = textCellType2909;
            this.spdData_Sheet1.Columns.Get(891).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(891).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(892).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(892).CellType = textCellType2910;
            this.spdData_Sheet1.Columns.Get(892).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(892).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(893).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(893).CellType = textCellType2911;
            this.spdData_Sheet1.Columns.Get(893).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(893).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(894).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(894).CellType = textCellType2912;
            this.spdData_Sheet1.Columns.Get(894).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(894).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(895).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(895).CellType = textCellType2913;
            this.spdData_Sheet1.Columns.Get(895).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(895).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(896).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(896).CellType = textCellType2914;
            this.spdData_Sheet1.Columns.Get(896).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(896).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(897).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(897).CellType = textCellType2915;
            this.spdData_Sheet1.Columns.Get(897).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(897).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(898).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(898).CellType = textCellType2916;
            this.spdData_Sheet1.Columns.Get(898).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(898).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(899).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(899).CellType = textCellType2917;
            this.spdData_Sheet1.Columns.Get(899).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(899).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(900).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(900).CellType = textCellType2918;
            this.spdData_Sheet1.Columns.Get(900).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(900).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(901).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(901).CellType = textCellType2919;
            this.spdData_Sheet1.Columns.Get(901).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(901).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(902).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(902).CellType = textCellType2920;
            this.spdData_Sheet1.Columns.Get(902).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(902).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(903).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(903).CellType = textCellType2921;
            this.spdData_Sheet1.Columns.Get(903).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(903).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(904).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(904).CellType = textCellType2922;
            this.spdData_Sheet1.Columns.Get(904).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(904).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(905).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(905).CellType = textCellType2923;
            this.spdData_Sheet1.Columns.Get(905).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(905).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(906).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(906).CellType = textCellType2924;
            this.spdData_Sheet1.Columns.Get(906).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(906).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(907).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(907).CellType = textCellType2925;
            this.spdData_Sheet1.Columns.Get(907).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(907).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(908).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(908).CellType = textCellType2926;
            this.spdData_Sheet1.Columns.Get(908).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(908).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(909).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(909).CellType = textCellType2927;
            this.spdData_Sheet1.Columns.Get(909).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(909).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(910).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(910).CellType = textCellType2928;
            this.spdData_Sheet1.Columns.Get(910).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(910).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(911).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(911).CellType = textCellType2929;
            this.spdData_Sheet1.Columns.Get(911).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(911).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(912).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(912).CellType = textCellType2930;
            this.spdData_Sheet1.Columns.Get(912).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(912).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(913).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(913).CellType = textCellType2931;
            this.spdData_Sheet1.Columns.Get(913).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(913).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(914).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(914).CellType = textCellType2932;
            this.spdData_Sheet1.Columns.Get(914).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(914).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(915).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(915).CellType = textCellType2933;
            this.spdData_Sheet1.Columns.Get(915).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(915).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(916).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(916).CellType = textCellType2934;
            this.spdData_Sheet1.Columns.Get(916).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(916).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(917).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(917).CellType = textCellType2935;
            this.spdData_Sheet1.Columns.Get(917).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(917).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(918).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(918).CellType = textCellType2936;
            this.spdData_Sheet1.Columns.Get(918).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(918).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(919).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(919).CellType = textCellType2937;
            this.spdData_Sheet1.Columns.Get(919).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(919).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(920).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(920).CellType = textCellType2938;
            this.spdData_Sheet1.Columns.Get(920).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(920).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(921).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(921).CellType = textCellType2939;
            this.spdData_Sheet1.Columns.Get(921).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(921).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(922).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(922).CellType = textCellType2940;
            this.spdData_Sheet1.Columns.Get(922).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(922).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(923).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(923).CellType = textCellType2941;
            this.spdData_Sheet1.Columns.Get(923).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(923).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(924).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(924).CellType = textCellType2942;
            this.spdData_Sheet1.Columns.Get(924).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(924).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(925).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(925).CellType = textCellType2943;
            this.spdData_Sheet1.Columns.Get(925).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(925).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(926).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(926).CellType = textCellType2944;
            this.spdData_Sheet1.Columns.Get(926).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(926).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(927).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(927).CellType = textCellType2945;
            this.spdData_Sheet1.Columns.Get(927).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(927).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(928).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(928).CellType = textCellType2946;
            this.spdData_Sheet1.Columns.Get(928).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(928).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(929).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(929).CellType = textCellType2947;
            this.spdData_Sheet1.Columns.Get(929).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(929).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(930).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(930).CellType = textCellType2948;
            this.spdData_Sheet1.Columns.Get(930).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(930).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(931).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(931).CellType = textCellType2949;
            this.spdData_Sheet1.Columns.Get(931).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(931).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(932).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(932).CellType = textCellType2950;
            this.spdData_Sheet1.Columns.Get(932).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(932).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(933).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(933).CellType = textCellType2951;
            this.spdData_Sheet1.Columns.Get(933).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(933).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(934).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(934).CellType = textCellType2952;
            this.spdData_Sheet1.Columns.Get(934).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(934).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(935).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(935).CellType = textCellType2953;
            this.spdData_Sheet1.Columns.Get(935).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(935).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(936).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(936).CellType = textCellType2954;
            this.spdData_Sheet1.Columns.Get(936).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(936).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(937).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(937).CellType = textCellType2955;
            this.spdData_Sheet1.Columns.Get(937).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(937).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(938).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(938).CellType = textCellType2956;
            this.spdData_Sheet1.Columns.Get(938).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(938).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(939).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(939).CellType = textCellType2957;
            this.spdData_Sheet1.Columns.Get(939).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(939).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(940).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(940).CellType = textCellType2958;
            this.spdData_Sheet1.Columns.Get(940).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(940).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(941).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(941).CellType = textCellType2959;
            this.spdData_Sheet1.Columns.Get(941).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(941).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(942).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(942).CellType = textCellType2960;
            this.spdData_Sheet1.Columns.Get(942).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(942).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(943).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(943).CellType = textCellType2961;
            this.spdData_Sheet1.Columns.Get(943).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(943).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(944).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(944).CellType = textCellType2962;
            this.spdData_Sheet1.Columns.Get(944).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(944).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(945).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(945).CellType = textCellType2963;
            this.spdData_Sheet1.Columns.Get(945).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(945).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(946).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(946).CellType = textCellType2964;
            this.spdData_Sheet1.Columns.Get(946).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(946).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(947).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(947).CellType = textCellType2965;
            this.spdData_Sheet1.Columns.Get(947).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(947).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(948).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(948).CellType = textCellType2966;
            this.spdData_Sheet1.Columns.Get(948).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(948).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(949).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(949).CellType = textCellType2967;
            this.spdData_Sheet1.Columns.Get(949).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(949).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(950).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(950).CellType = textCellType2968;
            this.spdData_Sheet1.Columns.Get(950).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(950).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(951).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(951).CellType = textCellType2969;
            this.spdData_Sheet1.Columns.Get(951).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(951).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(952).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(952).CellType = textCellType2970;
            this.spdData_Sheet1.Columns.Get(952).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(952).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(953).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(953).CellType = textCellType2971;
            this.spdData_Sheet1.Columns.Get(953).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(953).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(954).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(954).CellType = textCellType2972;
            this.spdData_Sheet1.Columns.Get(954).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(954).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(955).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(955).CellType = textCellType2973;
            this.spdData_Sheet1.Columns.Get(955).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(955).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(956).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(956).CellType = textCellType2974;
            this.spdData_Sheet1.Columns.Get(956).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(956).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(957).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(957).CellType = textCellType2975;
            this.spdData_Sheet1.Columns.Get(957).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(957).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(958).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(958).CellType = textCellType2976;
            this.spdData_Sheet1.Columns.Get(958).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(958).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(959).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(959).CellType = textCellType2977;
            this.spdData_Sheet1.Columns.Get(959).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(959).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(960).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(960).CellType = textCellType2978;
            this.spdData_Sheet1.Columns.Get(960).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(960).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(961).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(961).CellType = textCellType2979;
            this.spdData_Sheet1.Columns.Get(961).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(961).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(962).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(962).CellType = textCellType2980;
            this.spdData_Sheet1.Columns.Get(962).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(962).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(963).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(963).CellType = textCellType2981;
            this.spdData_Sheet1.Columns.Get(963).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(963).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(964).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(964).CellType = textCellType2982;
            this.spdData_Sheet1.Columns.Get(964).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(964).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(965).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(965).CellType = textCellType2983;
            this.spdData_Sheet1.Columns.Get(965).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(965).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(966).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(966).CellType = textCellType2984;
            this.spdData_Sheet1.Columns.Get(966).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(966).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(967).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(967).CellType = textCellType2985;
            this.spdData_Sheet1.Columns.Get(967).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(967).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(968).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(968).CellType = textCellType2986;
            this.spdData_Sheet1.Columns.Get(968).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(968).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(969).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(969).CellType = textCellType2987;
            this.spdData_Sheet1.Columns.Get(969).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(969).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(970).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(970).CellType = textCellType2988;
            this.spdData_Sheet1.Columns.Get(970).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(970).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(971).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(971).CellType = textCellType2989;
            this.spdData_Sheet1.Columns.Get(971).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(971).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(972).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(972).CellType = textCellType2990;
            this.spdData_Sheet1.Columns.Get(972).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(972).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(973).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(973).CellType = textCellType2991;
            this.spdData_Sheet1.Columns.Get(973).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(973).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(974).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(974).CellType = textCellType2992;
            this.spdData_Sheet1.Columns.Get(974).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(974).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(975).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(975).CellType = textCellType2993;
            this.spdData_Sheet1.Columns.Get(975).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(975).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(976).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(976).CellType = textCellType2994;
            this.spdData_Sheet1.Columns.Get(976).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(976).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(977).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(977).CellType = textCellType2995;
            this.spdData_Sheet1.Columns.Get(977).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(977).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(978).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(978).CellType = textCellType2996;
            this.spdData_Sheet1.Columns.Get(978).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(978).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(979).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(979).CellType = textCellType2997;
            this.spdData_Sheet1.Columns.Get(979).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(979).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(980).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(980).CellType = textCellType2998;
            this.spdData_Sheet1.Columns.Get(980).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(980).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(981).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(981).CellType = textCellType2999;
            this.spdData_Sheet1.Columns.Get(981).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(981).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(982).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(982).CellType = textCellType3000;
            this.spdData_Sheet1.Columns.Get(982).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(982).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(983).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(983).CellType = textCellType3001;
            this.spdData_Sheet1.Columns.Get(983).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(983).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(984).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(984).CellType = textCellType3002;
            this.spdData_Sheet1.Columns.Get(984).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(984).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(985).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(985).CellType = textCellType3003;
            this.spdData_Sheet1.Columns.Get(985).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(985).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(986).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(986).CellType = textCellType3004;
            this.spdData_Sheet1.Columns.Get(986).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(986).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(987).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(987).CellType = textCellType3005;
            this.spdData_Sheet1.Columns.Get(987).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(987).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(988).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(988).CellType = textCellType3006;
            this.spdData_Sheet1.Columns.Get(988).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(988).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(989).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(989).CellType = textCellType3007;
            this.spdData_Sheet1.Columns.Get(989).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(989).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(990).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(990).CellType = textCellType3008;
            this.spdData_Sheet1.Columns.Get(990).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(990).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(991).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(991).CellType = textCellType3009;
            this.spdData_Sheet1.Columns.Get(991).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(991).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(992).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(992).CellType = textCellType3010;
            this.spdData_Sheet1.Columns.Get(992).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(992).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(993).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(993).CellType = textCellType3011;
            this.spdData_Sheet1.Columns.Get(993).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(993).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(994).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(994).CellType = textCellType3012;
            this.spdData_Sheet1.Columns.Get(994).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(994).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(995).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(995).CellType = textCellType3013;
            this.spdData_Sheet1.Columns.Get(995).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(995).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(996).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(996).CellType = textCellType3014;
            this.spdData_Sheet1.Columns.Get(996).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(996).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(997).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(997).CellType = textCellType3015;
            this.spdData_Sheet1.Columns.Get(997).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(997).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(998).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(998).CellType = textCellType3016;
            this.spdData_Sheet1.Columns.Get(998).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(998).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(999).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(999).CellType = textCellType3017;
            this.spdData_Sheet1.Columns.Get(999).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(999).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1000).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1000).CellType = textCellType3018;
            this.spdData_Sheet1.Columns.Get(1000).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1000).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1001).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1001).CellType = textCellType3019;
            this.spdData_Sheet1.Columns.Get(1001).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1001).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1002).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1002).CellType = textCellType3020;
            this.spdData_Sheet1.Columns.Get(1002).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1002).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1003).BackColor = System.Drawing.Color.Lime;
            this.spdData_Sheet1.Columns.Get(1003).CellType = textCellType3021;
            this.spdData_Sheet1.Columns.Get(1003).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1003).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1004).CellType = textCellType3022;
            this.spdData_Sheet1.Columns.Get(1004).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1004).Locked = true;
            this.spdData_Sheet1.Columns.Get(1004).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1004).Width = 80F;
            this.spdData_Sheet1.Columns.Get(1005).CellType = textCellType3023;
            this.spdData_Sheet1.Columns.Get(1005).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1005).Locked = true;
            this.spdData_Sheet1.Columns.Get(1005).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1005).Width = 80F;
            this.spdData_Sheet1.Columns.Get(1006).CellType = textCellType3024;
            this.spdData_Sheet1.Columns.Get(1006).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1006).Locked = true;
            this.spdData_Sheet1.Columns.Get(1006).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1006).Width = 80F;
            this.spdData_Sheet1.Columns.Get(1007).CellType = textCellType3025;
            this.spdData_Sheet1.Columns.Get(1007).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1007).Locked = true;
            this.spdData_Sheet1.Columns.Get(1007).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1007).Width = 80F;
            this.spdData_Sheet1.Columns.Get(1008).CellType = textCellType3026;
            this.spdData_Sheet1.Columns.Get(1008).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1008).Locked = true;
            this.spdData_Sheet1.Columns.Get(1008).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1008).Width = 80F;
            this.spdData_Sheet1.Columns.Get(1009).CellType = textCellType3027;
            this.spdData_Sheet1.Columns.Get(1009).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(1009).Locked = true;
            this.spdData_Sheet1.Columns.Get(1009).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1009).Width = 80F;
            this.spdData_Sheet1.FrozenColumnCount = 1;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            this.spdData.SetViewportLeftColumn(0, 0, 1);
            this.spdData.SetActiveViewport(0, 1, -1);
            // 
            // grpChartInfo
            // 
            this.grpChartInfo.Controls.Add(this.ctrlChartData);
            this.grpChartInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChartInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChartInfo.Location = new System.Drawing.Point(0, 0);
            this.grpChartInfo.Name = "grpChartInfo";
            this.grpChartInfo.Size = new System.Drawing.Size(736, 98);
            this.grpChartInfo.TabIndex = 10;
            this.grpChartInfo.TabStop = false;
            // 
            // ctrlChartData
            // 
            this.ctrlChartData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlChartData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlChartData.Location = new System.Drawing.Point(3, 16);
            this.ctrlChartData.Name = "ctrlChartData";
            this.ctrlChartData.Size = new System.Drawing.Size(730, 79);
            this.ctrlChartData.SyncEDCFlag = ' ';
            this.ctrlChartData.TabIndex = 0;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpComment.Location = new System.Drawing.Point(0, 228);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(736, 40);
            this.grpComment.TabIndex = 11;
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
            this.txtComment.Size = new System.Drawing.Size(602, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 15);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(100, 14);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udcChartInfo
            // 
            this.AutoScroll = true;
            this.Controls.Add(this.pnlCenter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "udcChartInfo";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Size = new System.Drawing.Size(742, 271);
            this.pnlCenter.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.grpControlChart.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.pnlChartOption.ResumeLayout(false);
            this.grpChartOption.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.grpChartInfo.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition"
        private const int UNIT_COL = 1;
        private const int NOMINAL_COL = 2;
        private const int PROCSIGMA_COL = 3;
        private const int VALUE_1_COL = 4;
        private const int WEIGHT_COL = 1004;
        private const int AVERAGE_COL = 1005;
        private const int SIGMA_COL = 1006;
        private const int RANGE_COL = 1007;
        private const int MAX_COL = 1008;
        private const int MIN_COL = 1009;
        #endregion
        
        #region " Properties Definition"
        private string m_sChartID = "";
        private char m_sLotResFlag = ' ';
        private string m_sLotID = "";
        private string m_sMatID = "";
        private int m_iMatVer = 0;
        private string m_sFlow = "";
        private int m_iFlowSeq = 0;
        private string m_sOper = "";
        private string m_sProcOper = "";
        private string m_sResID = "";
        private string m_sProcResID = "";
        private string m_sEventID = "";
        private string m_sCharID = "";
        private string m_sTranTime = "";
        private bool m_bBackTimeFlag = false;
        private int m_iGraphType = - 1;
        private int m_iGroupIndex = - 1;
        private int m_iLotIndex = - 1;
        private string m_sUserID = "";
        private char m_sSelectMFOFlag = ' ';
        private string m_sViewChart = "";        
        public string ChartID
        {
            get
            {
                return m_sChartID;
            }
            set
            {
                if (m_sChartID.Equals(value) == false)
                {
                    m_sChartID = value;
                }
            }
        }
        
        public char LotResFlag
        {
            get
            {
                return m_sLotResFlag;
            }
            set
            {
                if (m_sLotResFlag.Equals(value) == false)
                {
                    m_sLotResFlag = value;
                }
            }
        }
        
        public string LotID
        {
            get
            {
                return m_sLotID;
            }
            set
            {
                if (m_sLotID.Equals(value) == false)
                {
                    m_sLotID = value;
                }
            }
        }
        
        public string MatID
        {
            get
            {
                return m_sMatID;
            }
            set
            {
                if (m_sMatID.Equals(value) == false)
                {
                    m_sMatID = value;
                }
            }
        }

        public int MatVer
        {
            get
            {
                return m_iMatVer;
            }
            set
            {
                if (m_iMatVer.Equals(value) == false)
                {
                    m_iMatVer = value;
                }
            }
        }
        
        public string Flow
        {
            get
            {
                return m_sFlow;
            }
            set
            {
                if (m_sFlow.Equals(value) == false)
                {
                    m_sFlow = value;
                }
            }
        }

        public int FlowSeq
        {
            get
            {
                return m_iFlowSeq;
            }
            set
            {
                if (m_iFlowSeq.Equals(value) == false)
                {
                    m_iFlowSeq = value;
                }
            }
        }
        
        public string Oper
        {
            get
            {
                return m_sOper;
            }
            set
            {
                if (m_sOper.Equals(value) == false)
                {
                    m_sOper = value;
                }
            }
        }
        
        public string ProcOper
        {
            get
            {
                return m_sProcOper;
            }
            set
            {
                if (m_sProcOper.Equals(value) == false)
                {
                    m_sProcOper = value;
                }
            }
        }
        
        public string ResID
        {
            get
            {
                return m_sResID;
            }
            set
            {
                if (m_sResID.Equals(value) == false)
                {
                    m_sResID = value;
                }
            }
        }
        
        public string ProcResID
        {
            get
            {
                return m_sProcResID;
            }
            set
            {
                if (m_sProcResID.Equals(value) == false)
                {
                    m_sProcResID = value;
                }
            }
        }
        
        public string EventID
        {
            get
            {
                return m_sEventID;
            }
            set
            {
                if (m_sEventID.Equals(value) == false)
                {
                    m_sEventID = value;
                }
            }
        }
        
        public string CharID
        {
            get
            {
                return m_sCharID;
            }
            set
            {
                if (m_sCharID.Equals(value) == false)
                {
                    m_sCharID = value;
                }
            }
        }
        
        public string TranTime
        {
            get
            {
                return m_sTranTime;
            }
            set
            {
                if (m_sTranTime.Equals(value) == false)
                {
                    m_sTranTime = value;
                }
            }
        }
        
        public bool IsBackTime
        {
            get
            {
                return m_bBackTimeFlag;
            }
            set
            {
                if (m_bBackTimeFlag.Equals(value) == false)
                {
                    m_bBackTimeFlag = value;
                }
            }
        }
        
        public int GraphTypeIndex
        {
            get
            {
                return m_iGraphType;
            }
            set
            {
                if (m_iGraphType.Equals(value) == false)
                {
                    m_iGraphType = value;
                }
            }
        }
        
        public int GroupIndex
        {
            get
            {
                return m_iGroupIndex;
            }
            set
            {
                if (m_iGroupIndex.Equals(value) == false)
                {
                    m_iGroupIndex = value;
                }
            }
        }
        
        public string UserID
        {
            get
            {
                return m_sUserID;
            }
            set
            {
                if (m_sUserID.Equals(value) == false)
                {
                    m_sUserID = value;
                }
            }
        }
        
        public int LotIndex
        {
            get
            {
                return m_iLotIndex;
            }
            set
            {
                if (m_iLotIndex.Equals(value) == false)
                {
                    m_iLotIndex = value;
                }
            }
        }

        public string Comment
        {
            get
            {
                return txtComment.Text;
            }
        }
        
        public FarPoint.Win.Spread.FpSpread GetSpreadData
        {
            get
            {
                return spdData;
            }
        }
        
        public string ViewChart
        {
            get
            {
                return m_sViewChart;
            }
            set
            {
                if (m_sViewChart.Equals(value) == false)
                {
                    m_sViewChart = value;
                }
                if (value == "Y")
                {
                    grpControlChart.Visible = true;
                    splMid.Visible = true;
                    grpData.Dock = DockStyle.Left;
                    Chart.ContextMenu.MenuItems[1].Enabled = modSPCFunctions.CheckAvailableFunction("SPC5001");
                    Chart.ContextMenu.MenuItems[0].Enabled = modSPCFunctions.CheckAvailableFunction("SPC4003");
                }
                else
                {
                    grpControlChart.Visible = false;
                    splMid.Visible = false;
                    grpData.Dock = DockStyle.Fill;
                }
            }
        }
        
        public string ValueType
        {
            get
            {
                return ctrlChartData.ValueType;
            }
        }
        
        public int SampleSize
        {
            get
            {
                return ctrlChartData.SampleSize;
            }
        }
        
        public int UnitCount
        {
            get
            {
                return ctrlChartData.UnitCount;
            }
        }
        
        public char UseUnit
        {
            get
            {
                return ctrlChartData.UseUnit;
            }
        }
        
        public int Precision
        {
            get
            {
                return ctrlChartData.Precision;
            }
        }
        
        public string SpecCheckType
        {
            get
            {
                return ctrlChartData.SpecCheckType;
            }
        }
        
        public string ChartGraphType
        {
            get
            {
                return ctrlChartData.ChartGraphType;
            }
        }
        
        public string DefaultUnitFlag
        {
            get
            {
                return ctrlChartData.DefaultUnitFlag;
            }
        }
        
        public string DefaultUnitOvrFlag
        {
            get
            {
                return ctrlChartData.DefaultUnitOvrFlag;
            }
        }
        
        public string DefaultValue
        {
            get
            {
                return ctrlChartData.DefaultValue;
            }
        }
        
        public string UnitTable
        {
            get
            {
                return ctrlChartData.UnitTable;
            }
        }
        
        public string ValueTable
        {
            get
            {
                return ctrlChartData.ValueTable;
            }
        }
        
        public char SelectMFOFlag
        {
            get
            {
                return m_sSelectMFOFlag;
            }
            set
            {
                if (m_sSelectMFOFlag.Equals(value) == false)
                {
                    m_sSelectMFOFlag = value;
                }
            }
        }

        public char SyncEDCFlag
        {
            get
            {
                return ctrlChartData.SyncEDCFlag;
            }
        }
        
        #endregion
        
        #region " Function Implementations"
        
        // ViewControlChartEvent()
        //       - ÎßàÏÉ¨Îß?
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool ViewControlChartEvent()
        {
            
            try
            {
                IAsyncResult r = BeginInvoke(_ViewControlChartDelegate, null);
                bool bReturn = (bool)EndInvoke(r);
                
                return bReturn;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.ViewControlChartEvent()\n" + ex.Message);
                return false;
            }
            
        }
        private void ChartRefresh()
        {
            try
            {
                Chart.Refresh();
               
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.SetChartOption()\n" + ex.Message);
            }
        }
        public void ChartRefreshEvent()
        {

            try
            {
                IAsyncResult r = BeginInvoke(_ChartRefreshDelegate, null);
                EndInvoke(r);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.ChartRefreshEvent()\n" + ex.Message);
            }

        }
        
        // ViewChartInfo()
        //       - View Chart Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool ViewChartInfo(bool bViewChart)
        {
            
            try
            {
                int iGraphType;
                MPCF.ClearList(spdData, true);
                ctrlChartData.ClearChartInfo();
                if (ChartID == "")
                {
                    return false;
                }
                if (ctrlChartData.ViewChartInformation(ChartID, modSPCFunctions.GetIsIgnoreSpecError()) == false)
                {
                    return false;
                }
                iGraphType = (int)Enum.Parse(typeof(eGraphType), ctrlChartData.ChartGraphType);
                GraphTypeIndex = iGraphType;
                modSPCFunctions.SetDatabyGraphType(spdData, (Miracom.CliFrx.eGraphType)iGraphType, ctrlChartData.SampleSize, VALUE_1_COL, AVERAGE_COL);
                modSPCFunctions.SetValuePrompt(spdData, ChartID, ctrlChartData.SampleSize, VALUE_1_COL);
                if (iGraphType == MPCF.ToInt(eGraphType.XBARR) || iGraphType == MPCF.ToInt(eGraphType.XBARS) || 
                    iGraphType == MPCF.ToInt(eGraphType.XRS) || iGraphType == MPCF.ToInt(eGraphType.ZBARS) || 
                    iGraphType == MPCF.ToInt(eGraphType.DELTAS) || iGraphType == MPCF.ToInt(eGraphType.NULL))
                {
                    spdData.Sheets[0].RowCount = ctrlChartData.UnitCount;
                }
                else
                {
                    spdData.Sheets[0].RowCount = 1;
                }
                
                if (iGraphType == MPCF.ToInt(eGraphType.ZBARS))
                {
                    spdData.Sheets[0].Cells[0, NOMINAL_COL].RowSpan = ctrlChartData.UnitCount;
                    spdData.Sheets[0].Cells[0, PROCSIGMA_COL].RowSpan = ctrlChartData.UnitCount;
                }
                else if (iGraphType == MPCF.ToInt(eGraphType.DELTAS))
                {
                    spdData.Sheets[0].Cells[0, NOMINAL_COL].RowSpan = ctrlChartData.UnitCount;
                }
                
                SetDefaultUnit();
                SetDefaultValue();
                
                if (ViewChart == "Y" && bViewChart == true)
                {
                    grpControlChart.Visible = true;
                    splMid.Visible = true;
                    grpData.Dock = DockStyle.Left;
                    Chart.ContextMenu.MenuItems[1].Enabled = modSPCFunctions.CheckAvailableFunction("SPC5001");
                    Chart.ContextMenu.MenuItems[0].Enabled = modSPCFunctions.CheckAvailableFunction("SPC4003");
                }
                else
                {
                    grpControlChart.Visible = false;
                    splMid.Visible = false;
                    grpData.Dock = DockStyle.Fill;
                }
                
                string sRuleType = MPCF.Trim(ctrlChartData.spdChartInfo.Sheets[0].Cells[4, 5].Value);
                if (sRuleType != "")
                {
                    string[] arrRuleType = sRuleType.Split('/');
                    string sXRuleType;
                    string sRRuleType;
                    int i;
                    sXRuleType = "";
                    sRRuleType = "";
                    for (i = 0; i <= arrRuleType[0].Length - 1; i++)
                    {
                        string sRule = arrRuleType[0].Substring(i, 1);
                        if (sRule != "_" && sRule != " ")
                        {
                            sXRuleType += "Y";
                        }
                        else
                        {
                            sXRuleType += " ";
                        }
                    }
                    if (arrRuleType.Length > 1)
                    {
                        for (i = 0; i <= arrRuleType[1].Length - 1; i++)
                        {
                            string sRule = arrRuleType[1].Substring(i, 1);
                            if (sRule != "_" && sRule != " ")
                            {
                                sRRuleType += "Y";
                            }
                            else
                            {
                                sXRuleType += " ";
                            }
                        }
                    }
                    Chart.XRuleType = sXRuleType;
                    Chart.RRuleType = sRRuleType;
                }
                
                SetLockSpread(false);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.ViewChartInfo()\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetDefaultUnit()
        //       - Set Default Unit
        //
        private void SetDefaultUnit()
        {
            
            try
            {
                if (DefaultUnitFlag == "Y")
                {
                    SPCLIST.ViewSPCDefaultUnitList(spdData, "1", ChartID, UNIT_COL, 0, spdData.Sheets[0].RowCount, -1);
                }
                
                if ((DefaultUnitFlag == "Y" && DefaultUnitOvrFlag == "Y" && UnitTable != "") ||(DefaultUnitFlag == "" && UnitTable != ""))
                {
                    if (BASLIST.ViewGCMDataList(spdData, '1', UnitTable, -1, null, "", false, UNIT_COL, -1, null) == false)
                    {
                        return;
                    }
                }
                else if (UnitTable == "")
                {
                    spdData.Sheets[0].Columns[UNIT_COL].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.SetDefaultUnit()\n" + ex.Message);
            }
            
        }
        
        // SetDefaultValue()
        //       - Set Default Value
        //
        private void SetDefaultValue()
        {
            
            try
            {
                int j;
                int k;
                
                if (DefaultValue != "" || ValueTable != "")
                {
                    for (j = VALUE_1_COL; j <= VALUE_1_COL + modSPCConstants.VALUE_COUNT - 1; j++)
                    {
                        if (spdData.Sheets[0].Columns[j].Visible == true)
                        {
                            if (DefaultValue != "")
                            {
                                for (k = 0; k <= spdData.Sheets[0].RowCount - 1; k++)
                                {
                                    spdData.Sheets[0].SetValue(k, j, DefaultValue);
                                }
                            }
                            if (ValueTable != "")
                            {
                                if (BASLIST.ViewGCMDataList(spdData, '1', ValueTable, -1, null, "", false, j, -1, null) == false)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.SetDefaultValue()\n" + ex.Message);
            }
            
        }
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool CheckCondition()
        {
            
            try
            {
                int i;
                int j;
                
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
                        if (spdData.ActiveSheet.Columns[NOMINAL_COL].Visible == true)
                        {
                            if (MPCF.Trim(spdData.Sheets[0].Cells[0, NOMINAL_COL].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdData.Sheets[0].SetActiveCell(0, NOMINAL_COL);
                                spdData.Select();
                                return false;
                            }
                        }
                        if (spdData.ActiveSheet.Columns[PROCSIGMA_COL].Visible == true)
                        {
                            if (MPCF.Trim(spdData.Sheets[0].Cells[0, PROCSIGMA_COL].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdData.Sheets[0].SetActiveCell(0, PROCSIGMA_COL);
                                spdData.Select();
                                return false;
                            }
                        }
                        if (spdData.Sheets[0].Columns[j].Visible == true)
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
                                if (ctrlChartData.ValueType == "N")
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
                MPCF.ShowMsgBox("udcChartInfo.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Result()
        //       - View Result of Data Collection
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef spdResult As FpSpread - Í≤∞Í≥º ?úÏãú ?§ÌîÑ?àÎìú
        //       - ByVal Result_Out As SPC_Collect_EDC_Data_Out_Tag : Data Collection Out ?úÍ∑∏
        //       - ByVal c_step As String
        //
        public void View_Result(FpSpread spdResult, TRSNode out_node, string c_step)
        {
            
            try
            {
                int i;
                MPCF.ClearList(spdResult, true);
                if (ctrlChartData.UseUnit != 'Y')
                {
                    if (out_node.GetList(0)[0].GetChar("R_CHECK_RESULT") != ' ' && out_node.GetList(0)[0].GetChar("X_CHECK_RESULT") != ' ')
                    {
                        spdResult.Sheets[0].RowCount = 2;
                        spdResult.Sheets[0].Cells[0, 0].Value = 1;
                        spdResult.Sheets[0].Cells[1, 0].Value = 1;
                        spdResult.Sheets[0].Cells[0, 0].RowSpan = 2;
                        spdResult.Sheets[0].Cells[0, 2].Value = spdData.Sheets[0].Cells[0, 1].Value;
                        spdResult.Sheets[0].Cells[0, 2].RowSpan = 2;
                        spdResult.Sheets[0].Cells[0, 3].Value = "X";
                        spdResult.Sheets[0].Cells[1, 3].Value = "R";
                        spdResult.Sheets[0].Cells[0, 4].Value = out_node.GetList(0)[0].GetChar("X_CHECK_RESULT");
                        spdResult.Sheets[0].Cells[1, 4].Value = out_node.GetList(0)[0].GetChar("R_CHECK_RESULT");
                        spdResult.Sheets[0].Cells[0, 5].Value = MPCF.SetRuleDescription(out_node.GetList(0)[0].GetChar("X_CHECK_RESULT"), out_node, 'X');
                        spdResult.Sheets[0].Cells[1, 5].Value = MPCF.SetRuleDescription(out_node.GetList(0)[0].GetChar("R_CHECK_RESULT"), out_node, 'R');
                        if (c_step == "2")
                        {
                            spdResult.Sheets[0].Cells[0, 6].RowSpan = 2;
                        }
                    }
                    else if (out_node.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ' && out_node.GetList(0)[0].GetChar("X_CHECK_RESULT") == ' ')
                    {
                    }
                    else
                    {
                        spdResult.Sheets[0].RowCount = 1;
                        spdResult.Sheets[0].Cells[0, 0].Value = 1;
                        spdResult.Sheets[0].Cells[0, 2].Value = spdData.Sheets[0].Cells[0, 1].Value;
                        spdResult.Sheets[0].Cells[0, 3].Value = (out_node.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ') ? "X" : "R";
                        spdResult.Sheets[0].Cells[0, 4].Value = (out_node.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ') ? (out_node.GetList(0)[0].GetChar("X_CHECK_RESULT")) : (out_node.GetList(0)[0].GetChar("R_CHECK_RESULT"));
                        spdResult.Sheets[0].Cells[0, 5].Value = (out_node.GetList(0)[0].GetChar("R_CHECK_RESULT") == ' ') ? (MPCF.SetRuleDescription(out_node.GetList(0)[0].GetChar("X_CHECK_RESULT"), out_node, 'X')) : (MPCF.SetRuleDescription(out_node.GetList(0)[0].GetChar("R_CHECK_RESULT"), out_node, 'R'));
                    }
                }
                else
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        if (out_node.GetList(0)[i].GetChar("R_CHECK_RESULT") != ' ' && out_node.GetList(0)[i].GetChar("X_CHECK_RESULT") != ' ')
                        {
                            spdResult.Sheets[0].RowCount += 2;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 2, 0].Value = i + 1;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, 0].Value = i + 1;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 2, 0].RowSpan = 2;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 2, 2].Value = spdData.Sheets[0].Cells[i, 1].Value;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 2, 2].RowSpan = 2;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 2, 3].Value = "X";
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, 3].Value = "R";
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 2, 4].Value = out_node.GetList(0)[i].GetChar("X_CHECK_RESULT");
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, 4].Value = out_node.GetList(0)[i].GetChar("R_CHECK_RESULT");
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 2, 5].Value = MPCF.SetRuleDescription(out_node.GetList(0)[i].GetChar("X_CHECK_RESULT"), out_node, 'X');
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, 5].Value = MPCF.SetRuleDescription(out_node.GetList(0)[i].GetChar("R_CHECK_RESULT"), out_node, 'R');
                            if (c_step == "2")
                            {
                                spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 2, 6].RowSpan = 2;
                            }
                        }
                        else if (out_node.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ' && out_node.GetList(0)[i].GetChar("X_CHECK_RESULT") == ' ')
                        {
                        }
                        else
                        {
                            spdResult.Sheets[0].RowCount++;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, 0].Value = i + 1;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, 2].Value = spdData.Sheets[0].Cells[i, 1].Value;
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, 3].Value = (out_node.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ') ? "X" : "R";
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, 4].Value = (out_node.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ') ? (out_node.GetList(0)[i].GetChar("X_CHECK_RESULT")) : (out_node.GetList(0)[i].GetChar("R_CHECK_RESULT"));
                            spdResult.Sheets[0].Cells[spdResult.Sheets[0].RowCount - 1, 5].Value = (out_node.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ') ? (MPCF.SetRuleDescription(out_node.GetList(0)[i].GetChar("X_CHECK_RESULT"), out_node, 'X')) : (MPCF.SetRuleDescription(out_node.GetList(0)[i].GetChar("R_CHECK_RESULT"), out_node, 'R'));
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.View_Result()\n" + ex.Message);
            }
            
        }
        
        // CollectEDCData()
        //       - Collect EDC Data
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String
        //
        public bool CollectEDCData(char c_step)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("Collect_EDC_Data_In");
                TRSNode out_node = new TRSNode("Collect_EDC_Data_Out");
                TRSNode oos_array;
                int i;
                int j;
                int k;
                int iValueCount;

                MPCR.SetInMsg(in_node);
                in_node.UserID = UserID;
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddChar("SUB_STEP", c_step);

                in_node.AddChar("LOT_RES_FLAG", LotResFlag);
                in_node.AddString("LOT_ID", LotID);
                in_node.AddString("MAT_ID", MatID);
                in_node.AddInt("MAT_VER", MatVer);
                in_node.AddString("FLOW", Flow);
                in_node.AddInt("FLOW_SEQ_NUM", FlowSeq);
                in_node.AddString("OPER", Oper);
                in_node.AddString("PROC_OPER", ProcOper);
                in_node.AddString("RES_ID", ResID);
                in_node.AddString("EVENT_ID", EventID);
                in_node.AddString("PROC_RES_ID", ProcResID);
                in_node.AddString("CHAR_ID", CharID);
                in_node.AddString("CHART_ID", ChartID);
                in_node.AddString("EDC_COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddInt("UNIT_COUNT", ctrlChartData.UnitCount);
                in_node.AddInt("SAMPLE_SIZE", ctrlChartData.SampleSize);
                in_node.AddString("GRAPH_TYPE", MPCF.Trim(Enum.GetName(typeof(eGraphType), GraphTypeIndex)));
                in_node.AddString("USL", ctrlChartData.USL);
                in_node.AddString("LSL", ctrlChartData.LSL);
                in_node.AddString("UCL", ctrlChartData.UCL);
                in_node.AddString("CL", ctrlChartData.CL);
                in_node.AddString("LCL", ctrlChartData.LCL);
                in_node.AddString("UCL2", ctrlChartData.UCL2);
                in_node.AddString("CL2", ctrlChartData.CL2);
                in_node.AddString("LCL2", ctrlChartData.LCL2);
                in_node.AddChar("UNIT_USE_FLAG", ctrlChartData.UseUnit);
                in_node.AddChar("SELECT_MFO_FLAG", SelectMFOFlag);
                
                if (IsBackTime == true)
                {
                    in_node.AddString("TRAN_TIME", TranTime);

                }
                FarPoint.Win.Spread.SheetView with_1 = spdData.Sheets[0];
                for (i = 0; i <= (with_1.RowCount - 1); i++)
                {
                    TRSNode list = in_node.AddNode("UNIT_LIST");
                    iValueCount = 0;
                    
                    for (j = VALUE_1_COL; j <= (with_1.ColumnCount - 7); j++)
                    {
                        if (MPCF.Trim(with_1.GetValue(i, j)) != "" && with_1.Columns[j].Visible == true)
                        {
                            iValueCount++;                            
                        }
                    }
                    if (with_1.Columns[NOMINAL_COL].Visible == true)
                    {
                        list.AddString("NOMINAL", MPCF.Trim(with_1.GetValue(0, NOMINAL_COL)));
                    }
                    if (with_1.Columns[PROCSIGMA_COL].Visible == true)
                    {
                        list.AddString("PROCESS_SIGMA", MPCF.Trim(with_1.GetValue(0, PROCSIGMA_COL)));
                    }
                    list.AddString("UNIT_ID", MPCF.Trim(with_1.GetValue(i, UNIT_COL)));
                    list.AddInt("VALUE_COUNT", iValueCount);
                    list.AddInt("UNIT_SEQ", i + 1);
                    

                    for (k = 0; k <= iValueCount - 1; k++)
                    {
                        if (with_1.Columns[k + VALUE_1_COL].Visible == true)
                        {
                            TRSNode value_item =  list.AddNode("VALUE_LIST");
                            value_item.AddString("VALUE", MPCF.Trim(with_1.GetValue(i, k + VALUE_1_COL)));
                        }
                    }

                }

                if (MessageCaster.CallService("SPC", "SPC_Collect_EDC_Data", in_node, ref out_node) == false)
                {
                    MPCF.ShowMsgBox(MPMH.StatusMessage);
                    return false;
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    MPCR.CheckContinueProc(out_node);
                    return false;
                }

                if (ctrlChartData.UseUnit == 'Y')
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        spdData.Sheets[0].Cells[i, WEIGHT_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"), ctrlChartData.Precision);
                        spdData.Sheets[0].Cells[i, AVERAGE_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("AVERAGE"), ctrlChartData.Precision);
                        spdData.Sheets[0].Cells[i, SIGMA_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("STDDEV"), ctrlChartData.Precision);
                        spdData.Sheets[0].Cells[i, RANGE_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("RANGE"), ctrlChartData.Precision);
                        spdData.Sheets[0].Cells[i, MAX_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("MAX_VALUE"), ctrlChartData.Precision);
                        spdData.Sheets[0].Cells[i, MIN_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("MIN_VALUE"), ctrlChartData.Precision);
                        if (out_node.GetList(0)[i].GetChar("R_CHECK_RESULT") == ' ' && out_node.GetList(0)[i].GetChar("X_CHECK_RESULT") == ' ')
                        {
                            spdData.Sheets[0].Cells[i, 0].Value = "OK";
                        }
                        else
                        {
                            spdData.Sheets[0].Cells[i, 0].Value = "FAIL";
                        }
                        if (out_node.GetList(0)[i].GetChar("X_CHECK_RESULT") == 'A')
                        {
                            oos_array = out_node.GetList("OOS_LIST")[i].GetArray("OOS_CHECK_RESULT");
                            if (ctrlChartData.ChartGraphType == eGraphType.XBARR.ToString() ||
                                ctrlChartData.ChartGraphType == eGraphType.XBARS.ToString() ||
                                ctrlChartData.ChartGraphType == eGraphType.XRS.ToString())
                            {
                                for (k = 0; k <= ctrlChartData.SampleSize - 1; k++)
                                {
                                    if (oos_array.GetChar(k.ToString()) == 'Y')
                                    {
                                        spdData.Sheets[0].Cells[i, VALUE_1_COL + k].BackColor = Color.Red;
                                    }
                                }
                            }
                            else if (ctrlChartData.ChartGraphType == eGraphType.P.ToString() ||
                                     ctrlChartData.ChartGraphType == eGraphType.U.ToString())
                            {
                                if (oos_array.GetChar("0") == 'Y')
                                {
                                    spdData.Sheets[0].Cells[0, AVERAGE_COL].BackColor = Color.Red;
                                }
                            }
                            else if (ctrlChartData.ChartGraphType == eGraphType.ZBARS.ToString() || ctrlChartData.ChartGraphType == eGraphType.DELTAS.ToString())
                            {
                                spdData.Sheets[0].Cells[0, WEIGHT_COL].BackColor = Color.Red;
                            }
                            else
                            {
                                if (oos_array.GetChar("0") == 'Y')
                                {
                                    spdData.Sheets[0].Cells[0, VALUE_1_COL].BackColor = Color.Red;
                                }
                            }
                        }
                        else if (out_node.GetList(0)[i].GetChar("X_CHECK_RESULT") == 'B' && ctrlChartData.SpecCheckType == "V")
                        {
                            oos_array = out_node.GetList("OOS_LIST")[i].GetArray("OOS_CHECK_RESULT");
                            if (ctrlChartData.ChartGraphType == eGraphType.XBARR.ToString() || ctrlChartData.ChartGraphType == eGraphType.XBARS.ToString() || ctrlChartData.ChartGraphType == eGraphType.XRS.ToString())
                            {
                                for (k = 0; k <= ctrlChartData.SampleSize - 1; k++)
                                {
                                    if (oos_array.GetChar(k.ToString()) == 'Y')
                                    {
                                        spdData.Sheets[0].Cells[i, VALUE_1_COL + k].BackColor = Color.Yellow;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    spdData.Sheets[0].Cells[0, WEIGHT_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("WEIGHT_VALUE"), ctrlChartData.Precision);
                    spdData.Sheets[0].Cells[0, WEIGHT_COL].RowSpan = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].Cells[0, AVERAGE_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("AVERAGE"), ctrlChartData.Precision);
                    spdData.Sheets[0].Cells[0, AVERAGE_COL].RowSpan = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].Cells[0, SIGMA_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("STDDEV"), ctrlChartData.Precision);
                    spdData.Sheets[0].Cells[0, SIGMA_COL].RowSpan = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].Cells[0, RANGE_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("RANGE"), ctrlChartData.Precision);
                    spdData.Sheets[0].Cells[0, RANGE_COL].RowSpan = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].Cells[0, MAX_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("MAX_VALUE"), ctrlChartData.Precision);
                    spdData.Sheets[0].Cells[0, MAX_COL].RowSpan = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].Cells[0, MIN_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("MIN_VALUE"), ctrlChartData.Precision);
                    spdData.Sheets[0].Cells[0, MIN_COL].RowSpan = spdData.Sheets[0].RowCount;
                    if (out_node.StatusValue == MPGC.MP_SUCCESS_STATUS)
                    {
                        spdData.Sheets[0].Cells[0, 0].Value = "OK";
                    }
                    else
                    {
                        spdData.Sheets[0].Cells[0, 0].Value = "FAIL";
                    }
                    spdData.Sheets[0].Cells[0, 0].RowSpan = spdData.Sheets[0].RowCount;
                    if (out_node.GetList(0)[0].GetChar("X_CHECK_RESULT") == 'A')
                    {
                        if (ctrlChartData.ChartGraphType == eGraphType.ZBARS.ToString() || ctrlChartData.ChartGraphType == eGraphType.DELTAS.ToString())
                        {
                            spdData.Sheets[0].Cells[0, WEIGHT_COL].BackColor = Color.Red;
                        }
                        else
                        {
                            for (i = 0; i <= spdData.Sheets[0].RowCount - 1; i++)
                            {
                                oos_array = out_node.GetList("OOS_LIST")[i].GetArray("OOS_CHECK_RESULT");
                                for (k = 0; k <= ctrlChartData.SampleSize - 1; k++)
                                {
                                    if (oos_array.GetChar(k.ToString()) == 'Y')
                                    {
                                        spdData.Sheets[0].Cells[i, VALUE_1_COL + k].BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    else if (out_node.GetList(0)[0].GetChar("X_CHECK_RESULT") == 'B' && ctrlChartData.SpecCheckType == "V")
                    {
                        for (i = 0; i <= spdData.Sheets[0].RowCount - 1; i++)
                        {
                            oos_array = out_node.GetList("OOS_LIST")[i].GetArray("OOS_CHECK_RESULT");
                            for (k = 0; k <= ctrlChartData.SampleSize - 1; k++)
                            {
                                if (oos_array.GetChar(k.ToString()) == 'Y')
                                {
                                    spdData.Sheets[0].Cells[i, VALUE_1_COL + k].BackColor = Color.Yellow;
                                }
                            }
                        }
                    }
                }
                if (c_step == MPGC.MP_STEP_TRAN && out_node.StatusValue == MPGC.MP_TRBL_STATUS)
                {
                    if (Result_Management(out_node) == false)
                    {
                        return false;
                    }
                }
                else if (c_step == MPGC.MP_STEP_TRAN && out_node.StatusValue == MPGC.MP_SUCCESS_STATUS)
                {
                    MPCR.ShowSuccessMsg(out_node);
                    if (ParentForm is frmSPCTranCollectLotData)
                    {
                        ((frmSPCTranCollectLotData)this.ParentForm).btnOK.Enabled = false;
                    }
                    else if (ParentForm is frmSPCTranCollectResourceData)
                    {
                        ((frmSPCTranCollectResourceData)this.ParentForm).btnOK.Enabled = false;
                    }
                    else if (ParentForm is frmSPCTranCollectLotDatabyCharacter)
                    {
                        ((frmSPCTranCollectLotDatabyCharacter)this.ParentForm).btnOK.Enabled = false;
                        ((frmSPCTranCollectLotDatabyCharacter)this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                    }
                    else if (ParentForm is frmSPCTranCollectResDatabyCharacter)
                    {
                        ((frmSPCTranCollectResDatabyCharacter)this.ParentForm).btnOK.Enabled = false;
                        ((frmSPCTranCollectResDatabyCharacter)this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                    }
                    SetLockSpread(true);
                }

             
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.CollectEDCData()\n" + ex.Message);
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
        private bool Result_Management(TRSNode out_node)
        {
            
            try
            {
                if (out_node.StatusValue == MPGC.MP_TRBL_STATUS)
                {
                    frmSPCSubCollectData f = new frmSPCSubCollectData();
                    frmSPCTranOOCHistory f1;
                    f.spdResult.Sheets[0].Columns[1].Visible = false;

                    View_Result(f.spdResult, out_node, "1");
                    f.ShowDialog(this);
                    
                    //Pending
                    if (f.DialogResult == System.Windows.Forms.DialogResult.Ignore)
                    {
                        //Data Commit
                        //OOC History Insert
                        if (CollectEDCData(modSPCConstants.MP_STEP_PEND) == false)
                        {
                            return false;
                        }
                        if (ParentForm is frmSPCTranCollectLotData)
                        {
                            ((frmSPCTranCollectLotData) this.ParentForm).btnOK.Enabled = false;
                        }
                        else if (ParentForm is frmSPCTranCollectResourceData)
                        {
                            ((frmSPCTranCollectResourceData) this.ParentForm).btnOK.Enabled = false;
                        }
                        else if (ParentForm is frmSPCTranCollectLotDatabyCharacter)
                        {
                            ((frmSPCTranCollectLotDatabyCharacter) this.ParentForm).btnOK.Enabled = false;
                            ((frmSPCTranCollectLotDatabyCharacter) this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                        }
                        else if (ParentForm is frmSPCTranCollectResDatabyCharacter)
                        {
                            ((frmSPCTranCollectResDatabyCharacter) this.ParentForm).btnOK.Enabled = false;
                            ((frmSPCTranCollectResDatabyCharacter) this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                        }
                        SetLockSpread(true);
                        
                        //Continue
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        f.Dispose();
                        if (CollectEDCData(modSPCConstants.MP_STEP_CONT) == false)
                        {
                            return false;
                        }
                        f1 = new frmSPCTranOOCHistory(out_node.GetInt("HIST_SEQ"), out_node.GetString("TRAN_TIME"), -1);
                        f1.spdResult.Sheets[0].Columns[1].Visible = false;
                        View_Result(f1.spdResult, out_node, "2");
                        f1.txtChart.Text = ChartID;
                        f1.txtGraphType.Text = ctrlChartData.ChartGraphType;
                        f1.ShowDialog(this);
                        if (ParentForm is frmSPCTranCollectLotData)
                        {
                            ((frmSPCTranCollectLotData) this.ParentForm).btnOK.Enabled = false;
                        }
                        else if (ParentForm is frmSPCTranCollectResourceData)
                        {
                            ((frmSPCTranCollectResourceData) this.ParentForm).btnOK.Enabled = false;
                        }
                        else if (ParentForm is frmSPCTranCollectLotDatabyCharacter)
                        {
                            ((frmSPCTranCollectLotDatabyCharacter) this.ParentForm).btnOK.Enabled = false;
                            ((frmSPCTranCollectLotDatabyCharacter) this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                        }
                        else if (ParentForm is frmSPCTranCollectResDatabyCharacter)
                        {
                            ((frmSPCTranCollectResDatabyCharacter) this.ParentForm).btnOK.Enabled = false;
                            ((frmSPCTranCollectResDatabyCharacter) this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                        }
                        SetLockSpread(true);
                        
                        //Data Change
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        f.Dispose();
                        spdData.Select();
                        return false;
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        f.Dispose();
                        spdData.Select();
                        return false;
                    }
                }
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.Result_Management()\n" + ex.Message);
                return false;
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
                
                for (i = 1; i <= spdData.Sheets[0].ColumnCount - 7; i++)
                {
                    spdData.Sheets[0].Columns[i].Locked = bLockFlag;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.SetLockSpread()\n" + ex.Message);
            }
            
        }
        
        // ClearControl()
        //       - Clear controls
        // Return Value
        //       -
        // Arguments
        //       -
        //
        public void ClearControl()
        {
            
            try
            {
                ChartID = "";
                ChartID = "";
                LotResFlag = ' ';
                LotID = "";
                MatID = "";
                Flow = "";
                Oper = "";
                ProcOper = "";
                ResID = "";
                ProcResID = "";
                EventID = "";
                CharID = "";
                TranTime = "";
                IsBackTime = false;
                GraphTypeIndex = - 1;
                GroupIndex = - 1;
                LotIndex = - 1;
                UserID = "";
                SelectMFOFlag = ' ';
                
                if (ViewChart == "Y")
                {
                    ViewControlChart(false);
                }
                ctrlChartData.ClearChartInfo();
                MPCF.ClearList(spdData, true);
                ResetChart();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.ClearControl()\n" + ex.Message);
            }
            
        }
        
        // ViewControlChart()
        //       - Set control chart monitoring
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal bMonitering As Boolean : monitoring flag
        //
        public bool ViewControlChart(bool bMonitering)
        {
            
            try
            {
                string sPublishChannel;
                
                if (ChartID == "")
                {
                    return false;
                }
                
                if (bMonitering == true)
                {
                    modSPCVariables.giTune++;
                    sPublishChannel = "/" + MPGV.gsSiteID;
                    sPublishChannel += "/SPC";
                    sPublishChannel += "/" + MPGV.gsFactory;
                    sPublishChannel += "/" + modSPCFunctions.ConvertAscii(MPCF.Trim(ChartID));
                    sPublishChannel += "/" + modSPCVariables.giTune.ToString();
                    Chart.PublishChannel = sPublishChannel;

                    if (MPMH.tune(Chart.PublishChannel, true, false) == false)
                    {
                        Chart.PublishChannel = "";
                        MPCF.ShowMsgBox("Message Tuning " + MPMH.StatusMessage);
                        return false;
                    }
                    
                    if (ViewControlChart() == false)
                    {
                        ViewControlChart(false);
                        return false;
                    }
                }
                else
                {
                    if (Chart.PublishChannel != null && Chart.PublishChannel != "")
                    {
                        if (false != MPMH.untune(Chart.PublishChannel, true, false))
                        {
                            return false;
                        }
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.ViewControlChart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_ControlChart()
        //       - View ControlChart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool ViewControlChart()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_ControlChart_In");
                TRSNode out_node = new TRSNode("View_ControlChart_Out");
                
                int i;
                int j;
                string sGroupIndex;
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
                
                if (ChartID == "")
                {
                    return false;
                }
                if (ResetChart() == false)
                {
                    return false;
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("CHART_ID", ChartID);
                in_node.AddInt("MAX_LOT_COUNT", 20);
                in_node.AddInt("NEXT_HIST_SEQ", 0);
                in_node.AddInt("NEXT_UNIT_SEQ", 0);
                
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
                    if (MPCF.Trim(ctrlChartData.USL) == "")
                    {
                        dUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                    }
                    else
                    {
                        dUSL = MPCF.ToDbl(MPCF.Trim(ctrlChartData.USL));
                    }
                    if (MPCF.Trim(ctrlChartData.LSL) == "")
                    {
                        dLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                    }
                    else
                    {
                        dLSL = MPCF.ToDbl(MPCF.Trim(ctrlChartData.LSL));
                    }
                }
                if (MPCR.CallService("SPC", "SPC_View_ControlChart", in_node, ref out_node) == false)
                {
                    return false;
                }

            
                for (i = out_node.GetList(0).Count - 1; i >= 0; i--)
                {
                    
                    if (this.chkAutoCalControlLimit.Checked == false)
                    {
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("USL")) == "")
                        {
                            dUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dUSL = MPCF.ToDbl(MPCF.Trim(out_node.GetList(0)[i].GetString("USL")));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("LSL")) == "")
                        {
                            dLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dLSL = MPCF.ToDbl(MPCF.Trim(out_node.GetList(0)[i].GetString("LSL")));
                        }
                        
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("UCL")) == "")
                        {
                            dUCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dUCL = MPCF.ToDbl(MPCF.Trim(out_node.GetList(0)[i].GetString("UCL")));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("CL")) == "")
                        {
                            dCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dCL = MPCF.ToDbl(MPCF.Trim(out_node.GetList(0)[i].GetString("CL")));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("LCL")) == "")
                        {
                            dLCL = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dLCL = MPCF.ToDbl(MPCF.Trim(out_node.GetList(0)[i].GetString("LCL")));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")) == "")
                        {
                            dUCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dUCL2 = MPCF.ToDbl(MPCF.Trim(out_node.GetList(0)[i].GetString("UCL2")));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("CL2")) == "")
                        {
                            dCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dCL2 = MPCF.ToDbl(MPCF.Trim(out_node.GetList(0)[i].GetString("CL2")));
                        }
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("LCL2")) == "")
                        {
                            dLCL2 = StatGlobalVariable.DOUBLE_NULL_DATA;
                        }
                        else
                        {
                            dLCL2 = MPCF.ToDbl(MPCF.Trim(out_node.GetList(0)[i].GetString("LCL2")));
                        }
                    }
                    
                    if (this.chkAutoCalControlLimit.Checked == true &&(Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.P && Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.U))
                    {
                        if (GroupIndex == - 1 || dUSL != dPrevUSL || dLSL != dPrevLSL || dUCL != dPrevUCL || dCL != dPrevCL || dLCL != dPrevLCL || dUCL2 != dPrevUCL2 || dCL2 != dPrevCL2 || dLCL2 != dPrevLCL2)
                        {
                            GroupIndex++;
                        }
                    }
                    else
                    {
                        GroupIndex++;
                    }

                    sGroupIndex = "Group" + GroupIndex.ToString("0000"); //GroupIndex);
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
                    
                    sLotIndex = "Lot" + LotIndex.ToString("0000");
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
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) :"") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            }
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")) :"") == "")
                            {
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("RANGE"));
                            }
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.XBARS:
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) :"") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            }
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) :"") == "")
                            {
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                            }
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.XRS:
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) :"") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("AVERAGE"));
                            }
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("RANGE")) :"") == "")
                            {
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("RANGE"));
                            }
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.P:
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) :"") == "")
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
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) :"") == "")
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
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) :"") == "")
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
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("AVERAGE")) :"") == "")
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
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")) :"") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"));
                            }
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) :"") == "")
                            {
                                dRdata = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dRdata = MPCF.ToDbl(out_node.GetList(0)[i].GetString("STDDEV"));
                            }
                            break;
                        case SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_VALUE")) :"") == "")
                            {
                                dXData = StatGlobalVariable.DOUBLE_NULL_DATA;
                            }
                            else
                            {
                                dXData = MPCF.ToDbl(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"));
                            }
                            
                            if ((MPCF.CheckNumeric(MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV"))) == true ? MPCF.Trim(out_node.GetList(0)[i].GetString("STDDEV")) :"") == "")
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
                    for (j = 0; j <= out_node.GetList(0)[i].GetInt("VALUE_COUNT") - 1; j++)
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
                    
                    LotIndex++;
                    
                }
                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                in_node.SetInt("NEXT_UNIT_SEQ", out_node.GetInt("NEXT_UNIT_SEQ"));

                Chart.ResvField2 = GroupIndex.ToString();
                Chart.ResvField3 = LotIndex.ToString();
                
                if (Chart.RefreshChartData() == false)
                {
                    return false;
                }
                
                Chart.Refresh();
                
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.ViewControlChart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ResetChart()
        //       - Reset Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool ResetChart()
        {
            
            try
            {
                Chart.InitDataSet();
                if (SetChartTitle(Chart, ChartID) == false)
                {
                    return false;
                }
                
                GroupIndex = - 1;
                LotIndex = - 1;
                
                Chart.Refresh();
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.ResetChart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetChartTitle()
        //       - Set Chart Title
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef Chart As SPCControlChart.SPCControlChart : Ï∞®Ìä∏
        //       - ByVal sChartID As String : Ï∞®Ìä∏ Î™?
        //
        public bool SetChartTitle(SPCControlChart.SPCControlChart Chart, string sChartID)
        {
            
            try
            {
                switch (Chart.ChartType)
                {
                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARR:
                        
                        Chart.MainTitle = sChartID;
                        Chart.SubTitle = "XBAR-CHART";
                        Chart.BottomTitle = "R-CHART";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARS:
                        
                        Chart.MainTitle = sChartID;
                        Chart.SubTitle = "XBAR-CHART";
                        Chart.BottomTitle = "S-CHART";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.XRS:
                        
                        Chart.MainTitle = sChartID;
                        Chart.SubTitle = "X-CHART";
                        Chart.BottomTitle = "R-CHART";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.P:
                        
                        Chart.MainTitle = sChartID;
                        Chart.SubTitle = "P-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.PN:
                        
                        Chart.MainTitle = sChartID;
                        Chart.SubTitle = "PN-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.C:
                        
                        Chart.MainTitle = sChartID;
                        Chart.SubTitle = "C-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.U:
                        
                        Chart.MainTitle = sChartID;
                        Chart.SubTitle = "U-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.ZBARS:
                        
                        Chart.MainTitle = sChartID;
                        Chart.SubTitle = "ZBAR-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:
                        
                        Chart.MainTitle = sChartID;
                        Chart.SubTitle = "DELTA-CHART";
                        Chart.BottomTitle = "";
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
                MPCF.ShowMsgBox("udcChartInfo.SetChartTitle()\n" + ex.Message);
                return false;
            }
            
        }
        
        // InitChart()
        //       - Chart initialize
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
                Chart.IsSimpleChart = true;
                Chart.IsDrawGroupLine = false;
                Chart.IsOnLineChart = true;
                Chart.IsOnLineStop = false;
                Chart.IsViewRChart = true;
                Chart.IsViewLotID = false;
                Chart.IsViewDate = false;
                Chart.IsUserInputCL = true;
                Chart.IsViewSpecLimit = chkViewSpec.Checked;
                Chart.IsViewXUCL = true;
                Chart.IsViewXCL = true;
                Chart.IsViewXLCL = true;
                Chart.IsViewRUCL = true;
                Chart.IsViewRCL = true;
                Chart.IsViewRLCL = true;
                Chart.IsViewRunTestText = chkViewRuleCheck.Checked;
                Chart.IsViewAZone = chkViewAZone.Checked;
                Chart.IsViewBZone = chkViewBZone.Checked;
                Chart.IsViewCZone = chkViewCZone.Checked;
                Chart.IsUserInputCL = ! chkAutoCalControlLimit.Checked;
                Chart.MaxLotCount = 20;
                
                Chart.SampleSize = ctrlChartData.SampleSize;
                Chart.ChartType = (SPCControlChart.modEnums.GRAPH_TYPE)Enum.Parse(typeof(eGraphType), ctrlChartData.ChartGraphType);
                Chart.Precision = ctrlChartData.Precision;
                Chart.ResvField1 = ctrlChartData.LotorRes;
                Chart.ResvField4 = ChartID;
                
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.InitChart()\n" + ex.Message);
            }
            
        }
        
        // ClearBackColor()
        //       - Clear Back Color of Spread
        // Return Value
        //       -
        // Arguments
        //       -
        //
        public void ClearBackColor()
        {
            
            try
            {
                int i;
                int j;
                for (i = 0; i <= spdData.Sheets[0].RowCount - 1; i++)
                {
                    for (j = VALUE_1_COL; j <= VALUE_1_COL + modSPCConstants.VALUE_COUNT - 1; j++)
                    {
                        spdData.Sheets[0].Cells[i, j].BackColor = Color.Lime;
                    }
                    spdData.Sheets[0].Cells[i, AVERAGE_COL].BackColor = Color.White;
                    spdData.Sheets[0].Cells[i, WEIGHT_COL].BackColor = Color.White;
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.BackColorClear()\n" + ex.Message);
            }
            
        }
        
        // SetChartOption()
        //       - Set chart option
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void SetChartOption()
        {
            
            try
            {
                if (MPCF.Trim(btnChartOption.Tag) == "VIEW")
                {
                    btnChartOption.Tag = "CLOSE";
                    btnChartOption.Text = "¢π";
                    pnlChartOption.Visible = true;
                    chkViewAZone.Checked = Chart.IsViewAZone;
                    chkViewBZone.Checked = Chart.IsViewBZone;
                    chkViewCZone.Checked = Chart.IsViewCZone;
                    chkViewRuleCheck.Checked = Chart.IsViewRunTestText;
                    chkViewSpec.Checked = Chart.IsViewSpecLimit;
                    chkAutoCalControlLimit.Checked = ! Chart.IsUserInputCL;
                }
                else
                {
                    btnChartOption.Tag = "VIEW";
                    btnChartOption.Text = "¢∑";
                    pnlChartOption.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.SetChartOption()\n" + ex.Message);
            }
            
        }
        
           
        #endregion
        
        #region " Event Implematations"
        
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
                MPCF.ShowMsgBox("udcChartInfo.spdData_KeyDown()\n" + ex.Message);
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
                
                if ((spdData.Sheets[0].Columns[iColumn + 1].Locked == false && spdData.Sheets[0].Columns[iColumn + 1].Visible == true) ||(iColumn + 1 == NOMINAL_COL || iColumn + 1 == PROCSIGMA_COL))
                {
                    if (iColumn + 1 == NOMINAL_COL && spdData.Sheets[0].Columns[iColumn + 1].Visible == false)
                    {
                        spdData.Sheets[0].SetActiveCell(iRow, iColumn + 3);
                    }
                    else if (iColumn + 1 == PROCSIGMA_COL && spdData.Sheets[0].Columns[iColumn + 1].Visible == false)
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
                    spdData.Sheets[0].SetActiveCell(iRow + 1, 1);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.spdData_EditModeOff()\n" + ex.Message);
            }
            
        }
        
        protected override void OnLoad(System.EventArgs e)
        {
            
            try
            {
                MPCF.ConvertMessage(this.Controls);
                MPCF.SetTextboxStyle(this.Controls);
                
                int i;
                for (i = 0; i <= modSPCConstants.VALUE_COUNT - 1; i++)
                {
                    spdData.Sheets[0].ColumnHeader.Cells[1, VALUE_1_COL + i].Value = i + 1;
                }
                ViewChart = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.OnLoad()\n" + ex.Message);
            }
            
        }
        
        private void Chart_ViewOOCInfo(object sender, SPCControlChart.MouseButtonDown_EventArgs e)
        {
            
            try
            {
                frmSPCTranUpdateOOCHistory form = new frmSPCTranUpdateOOCHistory();
                form.gcStep = '2';
                form.txtChart.Text = ChartID;
                form.giEDCHistSeq = e.HistSeq;
                form.giUnitSeq = e.UnitSeq;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // Nothing
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.Chart_ViewOOCInfo()\n" + ex.Message);
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


                ((frmSPCTranChangeEDCData)form).uccStart.Value = MPCF.ToDate(e.TransTime);
                ((frmSPCTranChangeEDCData) form).udtStart.Value = "000000";
                ((frmSPCTranChangeEDCData)form).uccEnd.Value = MPCF.ToDate(e.TransTime);
                ((frmSPCTranChangeEDCData) form).udtEnd.Value = "235959";
                ((frmSPCTranChangeEDCData) form).cdvChartID.Text = ChartID;
                if (((frmSPCTranChangeEDCData) form).cdvChartID.Text != "")
                {
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
                MPCF.ShowMsgBox("udcChartInfo.Chart_ChangeEDCData()\n" + ex.Message);
            }
            
        }
        
        private void btnChartOption_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                SetChartOption();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.btnChartOption_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnChartOption_GotFocus(object sender, System.EventArgs e)
        {
            
            try
            {
                this.Chart.Focus();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.btnChartOption_GotFocus()\n" + ex.Message);
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
                MPCF.ShowMsgBox("udcChartInfo.chkViewAZone_CheckedChanged()\n" + ex.Message);
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
                MPCF.ShowMsgBox("udcChartInfo.chkViewBZone_CheckedChanged()\n" + ex.Message);
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
                MPCF.ShowMsgBox("udcChartInfo.chkViewCZone_CheckedChanged()\n" + ex.Message);
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
                MPCF.ShowMsgBox("udcChartInfo.chkViewRuleCheck_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkViewSpec_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsViewSpecLimit = chkViewSpec.Checked;
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.chkViewSpec_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void chkAutoCalControlLimit_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                Chart.IsUserInputCL = !(chkAutoCalControlLimit.Checked);
                ViewControlChart(false);
                ViewControlChart(true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.chkAutoCalControlLimit_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
