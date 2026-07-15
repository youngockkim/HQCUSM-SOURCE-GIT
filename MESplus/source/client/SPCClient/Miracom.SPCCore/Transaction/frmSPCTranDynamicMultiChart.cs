
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
using Miracom.UI.Controls.MCCodeView;
using SPCControlChart.ControlChart;
using Miracom.TRSCore;
//#If _SPC = True Then
//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCTranDynamicMultiChart.vb
//   Description : Multi Realtime Monitoring
//
//   SPC Version : 1.0.0
//
//   Function List
//       - ViewControlChartEvent : View Control Chart Mashaling
//       - GetChartOption : Get Chart Option
//       - GetChartInfo : Get Chart Information
//       - SetLayOut : Set Layout
//       - PanelResize : Resize Panel
//       - SetPanelLevel2 : Set Panel
//       - SetPanelLevel3 : Set Panel
//       - WidthAdjust : Adjust Width
//       - HeightAdjust : Adjust Height
//       - ViewControlChart : View Control Chart
//       - View_Chart : View Chart Information
//       - ResetChart : Reset Chart
//       - SetChartTitle : Set Chart Title
//       - InitChart : Initialize Chart
//       - View_Spec : View Spec Information
//       - SetChartInfo : Set Chart Information
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
    public class frmSPCTranDynamicMultiChart : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "

        delegate bool ViewControlChartDelegate(string sChartID, SPCControlChart.SPCControlChart Chart);
        delegate void ChartRefreshDelegate(SPCControlChart.SPCControlChart Chart);

        private ViewControlChartDelegate _ViewControlChartDelegate;
        private ChartRefreshDelegate _ChartRefreshDelegate;
        
        public frmSPCTranDynamicMultiChart()
        {
            
            
            InitializeComponent();
            
            
            
            _ViewControlChartDelegate = new ViewControlChartDelegate( ViewControlChart);
            _ChartRefreshDelegate = new ChartRefreshDelegate(ChartRefresh);
            
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
        internal System.Windows.Forms.Button btnMonitoring;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlCenter;
        internal System.Windows.Forms.Button btnOptions;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnMonitoring = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnOptions);
            this.pnlBottom.Controls.Add(this.btnMonitoring);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 596);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(792, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOptions.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOptions.Location = new System.Drawing.Point(516, 7);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(88, 26);
            this.btnOptions.TabIndex = 0;
            this.btnOptions.Tag = "";
            this.btnOptions.Text = "Options";
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnMonitoring
            // 
            this.btnMonitoring.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMonitoring.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMonitoring.Location = new System.Drawing.Point(608, 7);
            this.btnMonitoring.Name = "btnMonitoring";
            this.btnMonitoring.Size = new System.Drawing.Size(88, 26);
            this.btnMonitoring.TabIndex = 1;
            this.btnMonitoring.Tag = "M";
            this.btnMonitoring.Text = "Monitoring";
            this.btnMonitoring.Click += new System.EventHandler(this.btnMonitoring_Click);
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
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(2);
            this.pnlCenter.Size = new System.Drawing.Size(792, 596);
            this.pnlCenter.TabIndex = 0;
            this.pnlCenter.Resize += new System.EventHandler(this.pnlCenter_Resize);
            // 
            // frmSPCTranDynamicMultiChart
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 636);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(800, 670);
            this.Name = "frmSPCTranDynamicMultiChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Multi Realtime Monitoring Control Chart";
            this.Load += new System.EventHandler(this.frmSPCTranDynamicMultiChart_Load);
            this.Closed += new System.EventHandler(this.frmSPCTranDynamicMultiChart_Closed);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        private ArrayList DisabledFormControls = new ArrayList();

        public int giCount = - 1;
        private string gsChart1 = "";
        private string gsChart2 = "";
        private string gsChart3 = "";
        private string gsChart4 = "";
        private string gsChart5 = "";
        private string gsChart6 = "";
        private string gsChart7 = "";
        private string gsChart8 = "";
        private string gsChart9 = "";
        private string gsViewAZone = "";
        private string gsViewBZone = "";
        private string gsViewCZone = "";
        private string gsViewLotID = "";
        private string gsViewDate = "";
        private string gsViewSpecLimit = "";
        private string gsViewRuleCheck = "";
        private string gsViewRChart = "";
        private string gsSimpleChart = "";
        private string gsAutoCalControlLimit = "";
        public int giMaxLotCount = - 1;
        
        private int giGroupIndex = - 1;
        private int giLotIndex = - 1;
        
        public struct ChartInfo
        {
            public string ChartID;
            public string ChartName;
            public SPCControlChart.SPCControlChart ChartObj;
        }
        
        public ChartInfo[] ChartList = new ChartInfo[9];
        #endregion
        
        #region " Function Implementations"
        
        // ViewControlChartEvent()
        //       - View Control Chart Mashaling
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sChartID As String : Chart ID
        //       - ByRef Chart As SPCControlChart.SPCControlChart : Chart
        //
        public bool ViewControlChartEvent(string sChartID, SPCControlChart.SPCControlChart Chart)
        {
            
            try
            {
                IAsyncResult r = BeginInvoke(_ViewControlChartDelegate, new object[] { sChartID, Chart });
                bool bReturn = (bool)EndInvoke(r);
                
                return bReturn;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.ViewControlChartEvent()\n" + ex.Message);
                return false;
            }
            
        }
        private void ChartRefresh(SPCControlChart.SPCControlChart Chart)
        {
            try
            {
                Chart.Refresh();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.SetChartOption()\n" + ex.Message);
                
            }
        }
        public void ChartRefreshEvent(SPCControlChart.SPCControlChart Chart)
        {

            try
            {
                IAsyncResult r = BeginInvoke(_ChartRefreshDelegate, new object[] { Chart });
                EndInvoke(r);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.ChartRefreshEvent()\n" + ex.Message);
            }

        }
        
        // GetChartOption()
        //       - Get Chart Option
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool GetChartOption()
        {
            
            try
            {
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartCount", "") == "")
                {
                    return false;
                }
                else
                {
                    giCount = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartCount", ""));
                }
                gsChart1 = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID1", "");
                gsChart2 = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID2", "");
                gsChart3 = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID3", "");
                gsChart4 = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID4", "");
                gsChart5 = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID5", "");
                gsChart6 = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID6", "");
                gsChart7 = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID7", "");
                gsChart8 = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID8", "");
                gsChart9 = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID9", "");
                gsViewAZone = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewAZone", "");
                gsViewBZone = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewBZone", "");
                gsViewCZone = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewCZone", "");
                gsViewLotID = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewLotID", "");
                gsViewDate = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewDate", "");
                gsViewSpecLimit = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewSpecLimit", "");
                gsViewRuleCheck = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewRuleCheck", "");
                gsViewRChart = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewRChart", "");
                gsSimpleChart = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsSimpleChart", "");
                gsAutoCalControlLimit = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsAutoCalControlLimit", "");
                giMaxLotCount = MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "MultiOption", "MaxLotCount", ""));
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.GetChartOption()\n" + ex.Message);
                return false;
            }
            
        }
        
        // GetChartInfo()
        //       - Get Chart Information
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void GetChartInfo()
        {
            
            try
            {
                ChartInfo[] TmpList = new ChartInfo[9];
                Control Chart;
                Panel pnlLevel2;
                Panel pnlLevel3;
                int i = 0;
                ChartList[0].ChartID = gsChart1;
                ChartList[1].ChartID = gsChart2;
                ChartList[2].ChartID = gsChart3;
                ChartList[3].ChartID = gsChart4;
                ChartList[4].ChartID = gsChart5;
                ChartList[5].ChartID = gsChart6;
                ChartList[6].ChartID = gsChart7;
                ChartList[7].ChartID = gsChart8;
                ChartList[8].ChartID = gsChart9;
                
                foreach (Panel tempLoopVar_pnlLevel2 in pnlCenter.Controls)
                {
                    pnlLevel2 = tempLoopVar_pnlLevel2;
                    foreach (Panel tempLoopVar_pnlLevel3 in pnlLevel2.Controls)
                    {
                        pnlLevel3 = tempLoopVar_pnlLevel3;
                        foreach (Control tempLoopVar_Chart in pnlLevel3.Controls)
                        {
                            Chart = tempLoopVar_Chart;
                            if (Chart is SPCControlChart.SPCControlChart)
                            {
                                TmpList[i].ChartObj = (SPCControlChart.SPCControlChart)Chart;
                                TmpList[i].ChartName = Chart.Name;
                                i++;
                            }
                        }
                    }
                }
                for (i = giCount - 1; i >= 0; i--)
                {
                    ChartList[giCount - i - 1].ChartObj = TmpList[i].ChartObj;
                    ChartList[giCount - i - 1].ChartName = TmpList[i].ChartName;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.GetChartInfo()\n" + ex.Message);
            }
            
        }
        
        // SetLayOut()
        //       - Set LayOut by Chart Count
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void SetLayOut()
        {
            try
            {
                switch (giCount)
                {
                    case 2:
                        
                        SetPanelLevel2(pnlCenter, 2, 1);
                        break;
                    case 4:
                        
                        SetPanelLevel2(pnlCenter, 2, 2);
                        break;
                    case 6:
                        
                        SetPanelLevel2(pnlCenter, 2, 3);
                        break;
                    case 9:
                        
                        SetPanelLevel2(pnlCenter, 3, 3);
                        break;
                }
                
                PanelResize();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.SetLayOut()\n" + ex.Message);
            }
            
        }
        
        // PanelResize()
        //       - Resize Panel
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void PanelResize()
        {
            
            try
            {
                Panel pnlLevel2;
                Panel pnlLevel3;
                
                foreach (Panel tempLoopVar_pnlLevel2 in pnlCenter.Controls)
                {
                    pnlLevel2 = tempLoopVar_pnlLevel2;
                    switch (giCount)
                    {
                        case 2:
                            HeightAdjust(pnlLevel2, 2);
                            break;
                            
                        case 4:
                            HeightAdjust(pnlLevel2, 2);
                            break;
                            
                        case 6:
                            
                            HeightAdjust(pnlLevel2, 2);
                            break;
                        case 9:
                            
                            HeightAdjust(pnlLevel2, 3);
                            break;
                    }
                    foreach (Panel tempLoopVar_pnlLevel3 in pnlLevel2.Controls)
                    {
                        pnlLevel3 = tempLoopVar_pnlLevel3;
                        switch (giCount)
                        {
                            case 4:
                                
                                WidthAdjust(pnlLevel3, 2);
                                break;
                            case 6:
                                WidthAdjust(pnlLevel3, 3);
                                break;
                                
                            case 9:
                                
                                WidthAdjust(pnlLevel3, 3);
                                break;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.PanelResize()\n" + ex.Message);
            }
            
        }
        
        // SetPanelLevel2()
        //       - Set Panel
        // Return Value
        //       -
        // Arguments
        //       - ByRef pnlMid As Panel : Main Panel
        //       - ByVal iLayOutLevel2 As Integer : 2nd Panel Count
        //       - ByVal iLayOutLevel3 As Integer : 3rd Panel Count
        //
        private void SetPanelLevel2(Panel pnlMid, int iLayOutLevel2, int iLayOutLevel3)
        {
            
            try
            {
                int i;
                
                for (i = iLayOutLevel2; i >= 1; i--)
                {
                    Panel pnlLayOut = new Panel();
                    pnlLayOut.Name = "LEVEL_2_" + i.ToString();
                    pnlLayOut.Dock = DockStyle.Top;
                    pnlMid.Controls.Add(pnlLayOut);
                    SetPanelLevel3(pnlLayOut, i, iLayOutLevel3);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.SetPanelLevel2()\n" + ex.Message);
            }
            
        }
        
        // SetPanelLevel3()
        //       - Set Panel
        // Return Value
        //       -
        // Arguments
        //       - ByRef pnlMid As Panel : Main Panel
        //       - ByVal iLayOutLevel2 As Integer : 2nd Panel Count
        //       - ByVal iLayOutLevel3 As Integer : 3rd Panel Count
        //
        private void SetPanelLevel3(Panel pnlMid, int iLayOutLevel2, int iLayOutLevel3)
        {
            
            try
            {
                int i;
                
                for (i = iLayOutLevel3; i >= 1; i--)
                {
                    Panel pnlLayOut = new Panel();
                    pnlLayOut.Name = "LEVEL_3_" + iLayOutLevel2.ToString() + "_" + i.ToString();
                    pnlLayOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    if (giCount == 2)
                    {
                        pnlLayOut.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        pnlLayOut.Dock = DockStyle.Left;
                    }
                    pnlLayOut.Tag = i + (iLayOutLevel3 *(iLayOutLevel2 - 1));
                    pnlMid.Controls.Add(pnlLayOut);
                    SPCControlChart.SPCControlChart SPCChart = new SPCControlChart.SPCControlChart();
                    SPCChart.Name = "CHART_" + ((int)(i + (iLayOutLevel3 * (iLayOutLevel2 - 1)))).ToString();
                    SPCChart.Font = this.pnlCenter.Font;
                    SPCChart.ViewOOCInfo += new SPCControlChart.ViewOOCInfoEventHandler(Chart_ViewOOCInfo);
                    SPCChart.ChangeEDCData += new SPCControlChart.ChangeEDCDataEventHandler(Chart_ChangeEDCData);
                    SPCChart.Dock = DockStyle.Fill;
                    pnlLayOut.Controls.Add(SPCChart);

                    Button btnGraph = new Button();
                    btnGraph.Height = 23;
                    btnGraph.Width = 23;
                    btnGraph.ImageList = MPGV.gIMdiForm.GetSmallIconList();
                    btnGraph.ImageIndex = (int)SMALLICON_INDEX.IDX_CHART_LINE;
                    btnGraph.Left = SPCChart.Width - 24;
                    btnGraph.Top = SPCChart.Height - 24;
                    btnGraph.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                    SPCChart.Controls.Add(btnGraph);
                    btnGraph.Click += new System.EventHandler(btnGraph_Click);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.SetPanelLevel3()\n" + ex.Message);
            }
            
        }
        
        // WidthAdjust()
        //       - Adjust Width of Panel
        // Return Value
        //       -
        // Arguments
        //       - ByRef pnlMid As Panel : Main Panel
        //       - ByVal iLayOut As Integer : Panel Count
        //
        private void WidthAdjust(Panel pnlMid, int iLayOut)
        {
            
            try
            {
                pnlMid.Width = (pnlCenter.Width - pnlCenter.DockPadding.Left * 2) / iLayOut;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.WidthAdjust()\n" + ex.Message);
            }
            
        }
        
        // HeightAdjust()
        //       - Adjust Height of Panel
        // Return Value
        //       -
        // Arguments
        //       - ByRef pnlMid As Panel : Main Panel
        //       - ByVal iLayOut As Integer : Panel Count
        //
        private void HeightAdjust(Panel pnlMid, int iLayOut)
        {
            
            try
            {
                pnlMid.Height = (pnlCenter.Height - pnlCenter.DockPadding.Top * 2) / iLayOut;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.HeightAdjust()\n" + ex.Message);
            }
            
        }
        
        //
        // ViewControlChart()
        //       - View ControlChart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef Chart As SPCControlChart.SPCControlChart
        //       - ByVal sChartID As String
        //       - ByVal bMonitering As Boolean : Monitoring Flag
        //
        public bool ViewControlChart(bool bMonitering, SPCControlChart.SPCControlChart Chart, string sChartID)
        {
            
            try
            {
                string sPublishChannel;
                
                if (sChartID == "")
                {
                    return false;
                }
                
                if (bMonitering == true)
                {
                    modSPCVariables.giTune++;
                    sPublishChannel = "/" + MPGV.gsSiteID;
                    sPublishChannel += "/SPC";
                    sPublishChannel += "/" + MPGV.gsFactory;
                    sPublishChannel += "/" + modSPCFunctions.ConvertAscii(MPCF.Trim(sChartID));
                    sPublishChannel += "/" + modSPCVariables.giTune.ToString();
                    Chart.PublishChannel = sPublishChannel;

                    if (MPMH.tune(Chart.PublishChannel, true, false) == false)
                    {
                        Chart.PublishChannel = "";
                        MPCF.ShowMsgBox("Message Tuning " + MPMH.StatusMessage);
                        return false;
                    }
                    
                    if (ViewControlChart(sChartID, Chart) == false)
                    {
                        ViewControlChart(false, Chart, sChartID);
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
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.ViewControlChart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ViewControlChart()
        //       - View ControlChart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sChartID As String
        //       - ByRef Chart As SPCControlChart.SPCControlChart
        //
        public bool ViewControlChart(string sChartID, SPCControlChart.SPCControlChart Chart)
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
                
                if (sChartID == "")
                {
                    return false;
                }
                if (ResetChart(sChartID, Chart) == false)
                {
                    return false;
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("CHART_ID", sChartID);
                in_node.AddInt("MAX_LOT_COUNT", MPCF.ToInt(giMaxLotCount));
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
                
                
                if (Chart.IsUserInputCL == false)
                {
                    int iVer =0;
                    if (MPCR.Find_Spec_Version('1', sChartID, ref iVer, true) == true)
                    {
                        View_Spec(iVer, sChartID, ref dUSL, ref dLSL);
                    }
                }
                
                System.Threading.Thread.Sleep(200);

                if (MPCR.CallService("SPC", "SPC_View_ControlChart", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                for (i = out_node.GetList(0).Count - 1; i >= 0; i--)
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
                    
                    if (Chart.IsUserInputCL == false &&(Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.P && Chart.ChartType != SPCControlChart.modEnums.GRAPH_TYPE.U))
                    {
                        if (giGroupIndex == - 1 || dUSL != dPrevUSL || dLSL != dPrevLSL || dUCL != dPrevUCL || dCL != dPrevCL || dLCL != dPrevLCL || dUCL2 != dPrevUCL2 || dCL2 != dPrevCL2 || dLCL2 != dPrevLCL2)
                        {
                            giGroupIndex++;
                        }
                    }
                    else
                    {
                        giGroupIndex++;
                    }
                    
                    sGroupIndex = "Group" + giGroupIndex.ToString("0000");
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
                    
                    sLotIndex = "Lot" + giLotIndex.ToString("0000");
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
                    
                    giLotIndex++;
                    
                }

                in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                in_node.SetInt("NEXT_UNIT_SEQ", out_node.GetInt("NEXT_UNIT_SEQ"));
                
                Chart.ResvField2 = giGroupIndex.ToString();
                Chart.ResvField3 = giLotIndex.ToString();

                if (Chart.ChartType == SPCControlChart.modEnums.GRAPH_TYPE.DELTAS)
                {
                    Chart.IsViewSpecLimit = false;
                }
                
                if (Chart.RefreshChartData() == false)
                {
                    return false;
                }
                
                Chart.Refresh();
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.ViewControlChart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Chart()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef ChartObj As SPCControlChart.SPCControlChart
        //       - ByVal sChartID As String
        //
        private bool View_Chart(SPCControlChart.SPCControlChart ChartObj, string sChartID)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node = new TRSNode("View_Chart_Out");
                
                if (sChartID == "")
                {
                    return true;
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));

                if (MPCR.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return false;
                }

                ChartObj.Tag = sChartID;
                ChartObj.SampleSize = out_node.GetInt("SAMPLE_SIZE");
                ChartObj.ChartType = (SPCControlChart.modEnums.GRAPH_TYPE)Enum.Parse(typeof(eGraphType), MPCF.Trim(out_node.GetString("GRAPH_TYPE")));
                ChartObj.Precision = out_node.GetInt("PRECISION_LIMIT");
                ChartObj.ResvField1 = MPCF.Trim(out_node.GetChar("LOT_RES_FLAG"));
                ChartObj.ResvField4 = MPCF.Trim(out_node.GetChar("UNIT_USE_FLAG"));
                ChartObj.ResvField5 = MPCF.Trim(out_node.GetString("CHART_DESC"));

                ChartObj.XRuleType = MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL"));
                ChartObj.RRuleType = MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL"));
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.View_Chart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // ResetChart()
        //       - Reset Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sChartID As String
        //       - ByRef Chart As SPCControlChart.SPCControlChart
        //
        public bool ResetChart(string sChartID, SPCControlChart.SPCControlChart Chart)
        {
            
            try
            {
                Chart.InitDataSet();
                if (SetChartTitle(Chart, sChartID) == false)
                {
                    return false;
                }
                
                giGroupIndex = - 1;
                giLotIndex = - 1;
                
                Chart.Refresh();
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.ResetChart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetChartTitle()
        //       - Set Chart Title
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef Chart As SPCControlChart.SPCControlChart
        //       - ByVal sChartID As String
        //
        public bool SetChartTitle(SPCControlChart.SPCControlChart Chart, string sChartID)
        {
            
            try
            {
                switch (Chart.ChartType)
                {
                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARR:

                        Chart.MainTitle = sChartID + " : " + Chart.ResvField5;
                        Chart.SubTitle = "XBAR-CHART";
                        if (gsViewRChart == "Y")
                        {
                            Chart.BottomTitle = "R-CHART";
                        }
                        else
                        {
                            Chart.BottomTitle = "";
                        }
                        
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.XBARS:

                        Chart.MainTitle = sChartID + " : " + Chart.ResvField5;
                        Chart.SubTitle = "XBAR-CHART";
                        if (gsViewRChart == "Y")
                        {
                            Chart.BottomTitle = "S-CHART";
                        }
                        else
                        {
                            Chart.BottomTitle = "";
                        }
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.XRS:

                        Chart.MainTitle = sChartID + " : " + Chart.ResvField5;
                        Chart.SubTitle = "X-CHART";
                        if (gsViewRChart == "Y")
                        {
                            Chart.BottomTitle = "R-CHART";
                        }
                        else
                        {
                            Chart.BottomTitle = "";
                        }
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.P:

                        Chart.MainTitle = sChartID + " : " + Chart.ResvField5;
                        Chart.SubTitle = "P-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.PN:

                        Chart.MainTitle = sChartID + " : " + Chart.ResvField5;
                        Chart.SubTitle = "PN-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.C:

                        Chart.MainTitle = sChartID + " : " + Chart.ResvField5;
                        Chart.SubTitle = "C-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.U:

                        Chart.MainTitle = sChartID + " : " + Chart.ResvField5;
                        Chart.SubTitle = "U-CHART";
                        Chart.BottomTitle = "";
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.ZBARS:

                        Chart.MainTitle = sChartID + " : " + Chart.ResvField5;
                        Chart.SubTitle = "ZBAR-CHART";
                        if (gsViewRChart == "Y")
                        {
                            Chart.BottomTitle = "S-CHART";
                        }
                        else
                        {
                            Chart.BottomTitle = "";
                        }
                        Chart.UnitTitle = "";
                        break;
                    case SPCControlChart.modEnums.GRAPH_TYPE.DELTAS:

                        Chart.MainTitle = sChartID + " : " + Chart.ResvField5;
                        Chart.SubTitle = "DELTA-CHART";
                        if (gsViewRChart == "Y")
                        {
                            Chart.BottomTitle = "S-CHART";
                        }
                        else
                        {
                            Chart.BottomTitle = "";
                        }
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
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.SetChartTitle()\n" + ex.Message);
                return false;
            }
            
        }
        
        // InitChart()
        //       - Initialize Chart
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void InitChart()
        {
            
            try
            {
                int i;
                for (i = 0; i <= giCount - 1; i++)
                {
                    ChartList[i].ChartObj.InitDataSet();
                    ChartList[i].ChartObj.IsDrawGroupLine = false;
                    ChartList[i].ChartObj.IsOnLineChart = true;
                    ChartList[i].ChartObj.IsOnLineStop = false;
                    ChartList[i].ChartObj.IsViewRChart = gsViewRChart == "Y" ? true : false;
                    ChartList[i].ChartObj.IsViewLotID = gsViewLotID == "Y" ? true : false;
                    ChartList[i].ChartObj.IsViewDate = gsViewDate == "Y" ? true : false;
                    ChartList[i].ChartObj.IsUserInputCL = true;
                    ChartList[i].ChartObj.IsViewSpecLimit = gsViewSpecLimit == "Y" ? true : false;
                    ChartList[i].ChartObj.IsViewXUCL = true;
                    ChartList[i].ChartObj.IsViewXCL = true;
                    ChartList[i].ChartObj.IsViewXLCL = true;
                    ChartList[i].ChartObj.IsViewRUCL = true;
                    ChartList[i].ChartObj.IsViewRCL = true;
                    ChartList[i].ChartObj.IsViewRLCL = true;
                    ChartList[i].ChartObj.IsViewRunTestText = gsViewRuleCheck == "Y" ? true : false;
                    ChartList[i].ChartObj.IsViewAZone = gsViewAZone == "Y" ? true : false;
                    ChartList[i].ChartObj.IsViewBZone = gsViewBZone == "Y" ? true : false;
                    ChartList[i].ChartObj.IsViewCZone = gsViewCZone == "Y" ? true : false;
                    ChartList[i].ChartObj.IsSimpleChart = gsSimpleChart == "Y" ? true : false;
                    ChartList[i].ChartObj.IsUserInputCL = gsAutoCalControlLimit == "Y" ? false : true;

                    ChartList[i].ChartObj.MaxLotCount = MPCF.ToInt(giMaxLotCount);
                    ChartList[i].ChartObj.ChartType = SPCControlChart.modEnums.GRAPH_TYPE.NONE;
                    ChartList[i].ChartObj.SampleSize = 0;
                
                    ChartList[i].ChartObj.Refresh();
                }
                
                for (i = 0; i <= giCount - 1; i++)
                {
                    ChartList[i].ChartObj.ContextMenu.MenuItems[1].Enabled = modSPCFunctions.CheckAvailableFunction("SPC5001");
                }
                
                for (i = 0; i <= giCount - 1; i++)
                {
                    ChartList[i].ChartObj.ContextMenu.MenuItems[0].Enabled = modSPCFunctions.CheckAvailableFunction("SPC4003");
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.InitChart()\n" + ex.Message);
            }
            
        }
        
        // View_Spec()
        //       - View Spec
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iVer As Integer
        //       - ByVal sChartID As String
        //       - ByRef dUSL As Double
        //       - ByRef dLSL As Double
        //
        private bool View_Spec(int iVer, string sChartID, ref double dUSL, ref double dLSL)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Spec_In");
                TRSNode out_node = new TRSNode("View_Spec_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));
                in_node.AddInt("VERSION", iVer);

                if (MPCR.CallService("SPC", "SPC_View_Spec", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                if (MPCF.Trim(out_node.GetString("USL")) == "")
                {
                    dUSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                }
                else
                {
                    dUSL = MPCF.ToDbl(out_node.GetString("USL"));
                }
                if (MPCF.Trim(out_node.GetString("LSL")) == "")
                {
                    dLSL = StatGlobalVariable.DOUBLE_NULL_DATA;
                }
                else
                {
                    dLSL = MPCF.ToDbl(out_node.GetString("LSL"));
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.View_Spec()\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetChartInfo()
        //       - Set Chart Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool SetChartInfo()
        {
            try
            {
                int i;
                GetChartInfo();
                InitChart();
                for (i = 0; i <= giCount - 1; i++)
                {
                    if (View_Chart(ChartList[i].ChartObj, ChartList[i].ChartID) == false)
                    {
                        return false;
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.SetChartInfo()\n" + ex.Message);
                return false;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.btnOptions;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }

        public void FormInit()
        {
            int i;

            try
            {
                for (i = 0; i <= giCount - 1; i++)
                {
                    if (ChartList[i].ChartObj != null)
                    {
                        ViewControlChart(false, ChartList[i].ChartObj, ChartList[i].ChartID);
                    }
                }

                btnMonitoring.Text = MPCF.FindLanguage("Monitoring", 1);
                btnMonitoring.Tag = "M";
                btnMonitoring.Enabled = false;

                pnlCenter.Controls.Clear();

                if (GetChartOption() == false)
                {
                    return;
                }

                SetLayOut();
                SetChartInfo();
                MPCR.ChangeControlEnabled(this, btnMonitoring, true);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void frmSPCTranDynamicMultiChart_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);

                FormInit();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.frmSPCTranDynamicMultiChart_Load()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void pnlCenter_Resize(object sender, System.EventArgs e)
        {
            
            try
            {
                PanelResize();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.pnlCenter_Resize()\n" + ex.Message);
            }
            
        }
        
        private void btnOptions_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                //this.Hide();
                frmSPCTranDynamicChartOptions form = new frmSPCTranDynamicChartOptions();
                if (form.ShowDialog(MPGV.gfrmMDI) == DialogResult.OK)
                {
                    //this.Show();
                    FormInit();
                }
                else
                {
                    //this.Close();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.btnOptions_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnMonitoring_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                int i;
                if (MPCF.Trim(btnMonitoring.Tag) == "M")
                {
                    for (i = 0; i <= giCount - 1; i++)
                    {
                        ViewControlChart(true, ChartList[i].ChartObj, ChartList[i].ChartID);
                    }
                    btnMonitoring.Text = MPCF.FindLanguage("Stop", 1);
                    btnMonitoring.Tag = "S";
                    
                }
                else if (MPCF.Trim(btnMonitoring.Tag) == "S")
                {
                    for (i = 0; i <= giCount - 1; i++)
                    {
                        ViewControlChart(false, ChartList[i].ChartObj, ChartList[i].ChartID);
                    }
                    for (i = 0; i <= giCount - 1; i++)
                    {
                        ChartList[i].ChartObj.IsOnLineStop = true;
                    }
                    btnMonitoring.Text = MPCF.FindLanguage("Monitoring", 1);
                    btnMonitoring.Tag = "M";
                    
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.btnMonitoring_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCTranDynamicMultiChart_Closed(object sender, System.EventArgs e)
        {
            
            try
            {
                int i;
                for (i = 0; i <= giCount - 1; i++)
                {
                    ViewControlChart(false, ChartList[i].ChartObj, ChartList[i].ChartID);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.frmSPCTranDynamicMultiChart_Closed()\n" + ex.Message);
            }
            
        }
        
        private void Chart_ViewOOCInfo(object sender, SPCControlChart.MouseButtonDown_EventArgs e)
        {
            
            try
            {
                frmSPCTranUpdateOOCHistory form = new frmSPCTranUpdateOOCHistory();
                form.gcStep = '2';
                form.txtChart.Text = ((SPCControlChart.SPCControlChart) sender).Tag.ToString();
                form.giEDCHistSeq = e.HistSeq;
                form.giUnitSeq = e.UnitSeq;
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    // Nothing
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.Chart_ViewOOCInfo()\n" + ex.Message);
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
                    , MPCF.ToInt(MPCF.Mid(e.TransTime, 8, 2)), MPCF.ToInt(MPCF.Mid(e.TransTime, 10, 2)), MPCF.ToInt(MPCF.Mid(e.TransTime, 12, 2)));


                ((frmSPCTranChangeEDCData)form).uccStart.Value = dtTranTime;
                ((frmSPCTranChangeEDCData) form).udtStart.Value = "000000";
                ((frmSPCTranChangeEDCData)form).uccEnd.Value = dtTranTime;
                ((frmSPCTranChangeEDCData) form).udtEnd.Value = "235959";
                ((frmSPCTranChangeEDCData)form).cdvChartID.Text = ((SPCControlChart.SPCControlChart)sender).Tag.ToString();
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
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.Chart_ChangeEDCData()\n" + ex.Message);
            }
            
        }
        
        private void btnGraph_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (((SPCControlChart.SPCControlChart)(((Button)sender).Parent)).Tag.ToString() == "")
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


                ((frmSPCTranControlChart)form).cdvChartID.Text = ((SPCControlChart.SPCControlChart)(((Button)sender).Parent)).Tag.ToString();
                if (((frmSPCTranControlChart) form).cdvChartID.Text != "")
                {
                    ((frmSPCTranControlChart) form).ChartIDSelected();
                    ((frmSPCTranControlChart) form).btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicMultiChart.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
