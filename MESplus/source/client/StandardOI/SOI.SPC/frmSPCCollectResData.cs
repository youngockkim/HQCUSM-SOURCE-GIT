using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using FarPoint.Win.Spread;

namespace SOI.SPC
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmSPCCollectResData : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;
        public const int VALUE_COUNT = 1000;
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
        public const char MP_STEP_PEND = 'P';
        public const char MP_STEP_CONT = 'N';
        public const char MP_STEP_VIEW = 'V';
        public string USL
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[0, 1].Value);
            }
        }

        public string UCL
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[0, 3].Value);
            }
        }

        public string CL
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[1, 3].Value);
            }
        }

        public string LCL
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[2, 3].Value);
            }
        }

        public string UCL2
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[0, 5].Value);
            }
        }

        public string CL2
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[1, 5].Value);
            }
        }

        public string LCL2
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[2, 5].Value);
            }
        }

        public string LSL
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[2, 1].Value);
            }
        }

        public string Target
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[1, 1].Value);
            }
        }

        public int SampleSize
        {
            get
            {
                if (spdChartInfo.Sheets[0].Cells[2, 7].Text == "")
                {
                    return 0;
                }
                else
                {
                    return MPCF.ToInt(spdChartInfo.Sheets[0].Cells[2, 7].Value);
                }
            }
        }

        public int UnitCount
        {
            get
            {
                return MPCF.ToInt(spdChartInfo.Sheets[0].Cells[1, 7].Value);
            }
        }

        public char UseUnit
        {
            get
            {
                return MPCF.ToChar(spdChartInfo.Sheets[0].Cells[0, 7].Value);
            }
        }

        public string Character
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[0, 11].Value);
            }
        }

        public string Material
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[0, 9].Value);
            }
        }

        public int MaterialVer
        {
            get
            {
                return MPCF.ToInt(spdChartInfo.Sheets[0].Cells[1, 9].Value);
            }
        }

        public string Operation
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[2, 9].Value);
            }
        }

        public string Resource
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[1, 11].Value);
            }
        }

        public string RuleType
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[2, 11].Value);
            }
        }

        public string ChartGraphType
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[3, 1].Value);
            }
        }

        public string LotorRes
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[3, 3].Value);
            }
        }

        public int Precision
        {
            get
            {
                return MPCF.ToInt(spdChartInfo.Sheets[0].Cells[3, 5].Value);
            }
        }


        public string ValueType
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[3, 7].Value);
            }
        }

        public string SpecCheckType
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[3, 9].Value);
            }
        }

        public int SpecOutCount
        {
            get
            {
                return (int)spdChartInfo.Sheets[0].Cells[3, 11].Value;
            }
        }

        public string DefaultUnitFlag
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[4, 1].Value);
            }
        }

        public string DefaultUnitOvrFlag
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[4, 3].Value);
            }
        }

        public string DefaultValue
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[4, 5].Value);
            }
        }

        public string UnitTable
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[4, 7].Value);
            }
        }

        public string ValueTable
        {
            get
            {
                return MPCF.Trim(spdChartInfo.Sheets[0].Cells[4, 9].Value);
            }
        }
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
        private int m_iGraphType = -1;
        private int m_iGroupIndex = -1;
        private int m_iLotIndex = -1;
        private string m_sUserID = "";
        //private char m_sSelectMFOFlag = ' ';
        //private string m_sViewChart = "";
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

        #endregion

        #region Constructor

        public frmSPCCollectResData()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }
        /// <summary>
        /// Code View 버튼 클릭시 Chart ID 조회.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvChartID_CodeViewButtonClick(object sender, EventArgs e)
        {
            // In Node Setup
            TRSNode in_node = new TRSNode("VIEW_CHART_LIST_IN");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("RES_ID", cdvResID.Text);
            //in_node.AddString("CHAR_ID", sCharID);
            in_node.AddChar("LOT_RES_FLAG", 'R');
            /* Need To Fix */
            //in_node.AddChar("SYNC_EDC_FLAG", ' ');
            // Display and Header Text Setup
            string[] display = new string[] { "CHART_ID", "CHART_DESC" };
            string[] header = new string[] { "Chart ID", "Chart Desc" };

            // Show CodeView and Get Return
            cdvChartID.Text = cdvChartID.Show(cdvChartID, "SPC", "View Chart List", "SPC_View_Chart_List", in_node, "CHART_LIST", display, header, "Chart ID");

            /* Added By YJJUNG 140617 Control Chart 의 Precision이 View 버튼 클릭시 적용 안되는 bug Fix */
            if (View_Chart() == false)
            {
                return;
            }
            if (MPCF.Trim(cdvChartID.Text) != "")
            {
                ChartID = MPCF.Trim(cdvChartID.Text);
                ViewChartInfo(true);

                //cboGraphType.SelectedIndex = GraphTypeIndex;
                //cdvResID.Text = Resource;
                //cdvCharID.Text = Character;
                //btnOK.Enabled = true;
                //if (ViewChart == "Y")
                //{
                //    InitChart();
                //    ViewControlChart(true);
                //}
            }
        }
        /// <summary>
        /// Code View 버튼 클릭시 Character ID 조회.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvCharID_CodeViewButtonClick(object sender, EventArgs e)
        {
            // In Node Setup
            TRSNode in_node = new TRSNode("VIEW_CHART_LIST_IN");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';

            // Display and Header Text Setup
            string[] display = new string[] { "CHAR_ID", "CHAR_DESC" };
            string[] header = new string[] { "Char ID", "Char Desc" };

            // Show CodeView and Get Return
            cdvCharID.Text = cdvCharID.Show(cdvChartID, "SPC", "View Character List", "SPC_View_Char_List", in_node, "CHAR_LIST", display, header, "Char ID");
        }

        /// <summary>
        /// Code View Button Click        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvEventID_CodeViewButtonClick(object sender, EventArgs e)
        {
            // Check Required Value
            if (MPCF.CheckValue(cdvResID, false) == false)
            {
                return;
            }

            // In Node Setup
            TRSNode in_node = new TRSNode("VIEW_RESEVENT_LIST_IN");
            MPCF.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("NEXT_RES_ID", cdvResID.Text);
            in_node.AddChar("RES_TYPE", 'M');

            // Display and Header Text Setup
            string[] display = new string[] { "EVENT_ID", "EVENT_DESC" };
            string[] header = new string[] { "Event ID", "Event Desc" };

            // Show CodeView and Get Return
            cdvEventID.Text = cdvEventID.Show(cdvEventID, "RAS", "View Resource Event", "RAS_View_ResEvent_List", in_node, "EVENT_LIST", display, header, "Event ID");
        }
        /// <summary>
        /// Resource ID CodeViewButtonClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                //// Check Required Value
                //if (MPCF.CheckValue(txtLotID, false) == false)
                //{
                //    return;
                //}

                //if (LOT == null)
                //{
                //    MPCF.SetFocus(txtLotID);
                //    txtLotID.SelectAll();
                //    return;
                //}

                // In Node Setup
                TRSNode in_node = new TRSNode("VIEW_RESOURCE_LIST_IN");
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("MAT_ID", "");
                in_node.AddString("FLOW", "");
                in_node.AddString("OPER", "");

                // CodeView Column Header Setup
                string[] header = new string[] { "Resource ID", "Resource Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "RES_ID", "RES_DESC" };

                // Show
                cdvResID.Text = cdvResID.Show(cdvResID, "Resource ID", "RAS", "RAS_View_Resource_List", in_node, "RES_LIST", display, header, "RES_ID");

                View_Resource();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
        /// <summary>
        /// Control Chart Button Click Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnControlChart_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvChartID, false) == false) return;
            frmSPCViewControlChart frm = new frmSPCViewControlChart();
            // Menu Info
            MenuInfoTag menuInfo = new MenuInfoTag();
            menuInfo.c_func_type = 'F';
            menuInfo.s_assembly_file = "SOI.SPC.dll";
            menuInfo.s_assembly_name = "SOI.SPC.frmSPCViewControlChart";
            menuInfo.s_func_desc = "Control Chart";
            menuInfo.s_func_name = "";
            frm._chartID = cdvChartID.Text;
            // Open Form
            MPGV.gIMdiForm.OpenMenu(menuInfo, frm);
        }
        /// <summary>
        /// Button Click event at 'Process'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckCondition() == false)
                //{
                //    return;
                //}
                ClearBackColor();
                SetCollectData();
                if (CollectEDCData(MPGC.MP_STEP_TRAN) == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.btnOK_Click()\n" + ex.Message);
            }

        }

        #endregion

        #region Function
        // View_Resource()
        //       - View Resource Information
        // Return Value
        //       - Boolean : True / False
        // Arguments
        //       -
        //
        private bool View_Resource()
        {
            TRSNode in_node = new TRSNode("View_Resource_In");
            TRSNode out_node = new TRSNode("View_Resource_Out");

            try
            {

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", cdvResID.Text);

                if (MPCF.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtResDesc.Text = out_node.GetString("RES_DESC");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.View_Resource()\n" + ex.Message);
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

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", cdvChartID.Text);

                if (MPCF.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "")
                {
                    txtGraphType.Text = "";
                }
                else
                {
                    txtGraphType.Text = MPCF.Trim(out_node.GetString("GRAPH_TYPE"));
                }
                cdvCharID.Text = MPCF.Trim(out_node.GetString("CHAR_ID"));
                if (cdvCharID.Text != "")
                {
                    cdvCharID.Enabled = false;
                }
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranControlChart.View_Chart()\n" + ex.Message);
                return false;
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
                ClearChartInfo();
                if (cdvCharID.Text == "")
                {
                    return false;
                }
                //if (ViewChartInformation(cdvCharID.Text, modSPCFunctions.GetIsIgnoreSpecError()) == false)
                if (ViewChartInformation(cdvChartID.Text, true) == false)
                {
                    return false;
                }
                iGraphType = (int)Enum.Parse(typeof(eGraphType), txtGraphType.Text);
                GraphTypeIndex = iGraphType;
                SetDatabyGraphType(spdData, (eGraphType)iGraphType, SampleSize, VALUE_1_COL, AVERAGE_COL);
                SetValuePrompt(spdData, ChartID, SampleSize, VALUE_1_COL);
                if (iGraphType == MPCF.ToInt(eGraphType.XBARR) || iGraphType == MPCF.ToInt(eGraphType.XBARS) ||
                    iGraphType == MPCF.ToInt(eGraphType.XRS) || iGraphType == MPCF.ToInt(eGraphType.ZBARS) ||
                    iGraphType == MPCF.ToInt(eGraphType.DELTAS) || iGraphType == MPCF.ToInt(eGraphType.NULL))
                {
                    spdData.Sheets[0].RowCount = UnitCount;
                }
                else
                {
                    spdData.Sheets[0].RowCount = 1;
                }

                if (iGraphType == MPCF.ToInt(eGraphType.ZBARS))
                {
                    spdData.Sheets[0].Cells[0, NOMINAL_COL].RowSpan = UnitCount;
                    spdData.Sheets[0].Cells[0, PROCSIGMA_COL].RowSpan = UnitCount;
                }
                else if (iGraphType == MPCF.ToInt(eGraphType.DELTAS))
                {
                    spdData.Sheets[0].Cells[0, NOMINAL_COL].RowSpan = UnitCount;
                }

                SetDefaultUnit();
                SetDefaultValue();

                //if (ViewChart == "Y" && bViewChart == true)
                //{
                //    grpControlChart.Visible = true;
                //    splMid.Visible = true;
                //    grpData.Dock = DockStyle.Left;
                //    Chart.ContextMenu.MenuItems[1].Enabled = modSPCFunctions.CheckAvailableFunction("SPC5001");
                //    Chart.ContextMenu.MenuItems[0].Enabled = modSPCFunctions.CheckAvailableFunction("SPC4003");
                //}
                //else
                //{
                //    grpControlChart.Visible = false;
                //    splMid.Visible = false;
                //    grpData.Dock = DockStyle.Fill;
                //}

                string sRuleType = MPCF.Trim(spdChartInfo.Sheets[0].Cells[2, 11].Value);
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
                    //Chart.XRuleType = sXRuleType;
                    //Chart.RRuleType = sRRuleType;
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
        // ClearChartInfo()
        //       - Clear Chart Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public void ClearChartInfo()
        {

            try
            {
                //cdvChartID.Text = "";
                spdChartInfo.Sheets[0].ClearRange(0, 1, 6, 1, true);
                spdChartInfo.Sheets[0].ClearRange(0, 3, 6, 1, true);
                spdChartInfo.Sheets[0].ClearRange(0, 5, 6, 1, true);
                spdChartInfo.Sheets[0].ClearRange(0, 7, 6, 1, true);
                spdChartInfo.Sheets[0].ClearRange(0, 9, 6, 1, true);
                spdChartInfo.Sheets[0].ClearRange(0, 11, 6, 1, true);
                //spdChartInfo.Sheets[0].ClearRange(5, 0, 1, 8, true);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.ClearChartInfo()\n" + ex.Message);
            }

        }

        // ViewChartInformation()
        //       - View Chart Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sChartID As String : 李⑦듃 紐?
        //       - Optional ByVal bIgnoreError As Boolean = False : ?먮윭硫붿떆吏 臾댁떆 ?щ?
        //
        public bool ViewChartInformation(string sChartID, bool bIgnoreError)
        {

            try
            {
                int iVer = 0;

                if (View_Chart(sChartID) == false)
                {
                    return false;
                }
                if (MPCF.Find_Spec_Version('1', sChartID, ref iVer, bIgnoreError) == true)
                {
                    if (View_Spec(iVer, sChartID) == false)
                    {
                        return false;
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.ViewChartInformation()\n" + ex.Message);
                return false;
            }

        }
        // View_Chart()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sChartID As String : 李⑦듃 紐?
        //
        private bool View_Chart(string sChartID)
        {

            try
            {
                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node = new TRSNode("View_Chart_Out");

                string sRuleType;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));


                if (MPCF.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return false;
                }

                //cdvChartID.Text = " " + sChartID + " : " + out_node.GetString("CHART_DESC");

                if (out_node.GetInt("SAMPLE_SIZE") == 0)
                {
                    spdChartInfo.Sheets[0].Cells[2, 7].Value = "";
                }
                else
                {
                    spdChartInfo.Sheets[0].Cells[2, 7].Value = out_node.GetInt("SAMPLE_SIZE");
                }
                if (out_node.GetInt("UNIT_COUNT") == 0)
                {
                    spdChartInfo.Sheets[0].Cells[1, 7].Value = 1;
                }
                else
                {
                    spdChartInfo.Sheets[0].Cells[1, 7].Value = out_node.GetInt("UNIT_COUNT");
                }
                spdChartInfo.Sheets[0].Cells[0, 7].Value = out_node.GetChar("UNIT_USE_FLAG");


                spdChartInfo.Sheets[0].Cells[0, 9].Value = out_node.GetString("MAT_ID");
                spdChartInfo.Sheets[0].Cells[1, 9].Value = out_node.GetInt("MAT_VER");
                spdChartInfo.Sheets[0].Cells[2, 9].Value = out_node.GetString("OPER");

                spdChartInfo.Sheets[0].Cells[0, 11].Value = out_node.GetString("CHAR_ID");
                spdChartInfo.Sheets[0].Cells[1, 11].Value = out_node.GetString("RES_ID");

                sRuleType = "";
                sRuleType = (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(0, 1) == "Y") ? "A" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(1, 1) == "Y") ? "B" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(2, 1) == "Y") ? "C" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(3, 1) == "Y") ? "D" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(4, 1) == "Y") ? "E" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(5, 1) == "Y") ? "F" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(6, 1) == "Y") ? "G" : "_";
                sRuleType += (MPCF.Trim(out_node.GetString("X_RULE_CHECK_TBL")).Substring(7, 1) == "Y") ? "H" : "_";

                if (MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "XBARR" ||
                    MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "XRS" ||
                    MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "XBARS")
                {

                    sRuleType += " / ";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(0, 1) == "Y") ? "A" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(1, 1) == "Y") ? "B" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(2, 1) == "Y") ? "C" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(3, 1) == "Y") ? "D" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(4, 1) == "Y") ? "E" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(5, 1) == "Y") ? "F" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(6, 1) == "Y") ? "G" : "_";
                    sRuleType += (MPCF.Trim(out_node.GetString("R_RULE_CHECK_TBL")).Substring(7, 1) == "Y") ? "H" : "_";

                }

                spdChartInfo.Sheets[0].Cells[2, 11].Value = sRuleType;
                spdChartInfo.Sheets[0].Cells[3, 1].Value = MPCF.Trim(out_node.GetString("GRAPH_TYPE"));
                spdChartInfo.Sheets[0].Cells[3, 3].Value = MPCF.Trim(out_node.GetChar("LOT_RES_FLAG"));
                spdChartInfo.Sheets[0].Cells[3, 5].Value = out_node.GetInt("PRECISION_LIMIT");
                spdChartInfo.Sheets[0].Cells[3, 7].Value = MPCF.Trim(out_node.GetString("VALUE_TYPE"));
                spdChartInfo.Sheets[0].Cells[3, 9].Value = MPCF.Trim(out_node.GetChar("SPEC_CHECK_TYPE"));
                spdChartInfo.Sheets[0].Cells[3, 11].Value = out_node.GetInt("SPEC_OUT_COUNT");

                //SyncEDCFlag = out_node.GetChar("SYNC_EDC_FLAG");
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.View_Chart()\n" + ex.Message);
                return false;
            }

        }

        // SetDatabyGraphType()
        //       - Set data by graph type
        // Return Value
        //       -
        // Arguments
        //       -
        //
        public static void SetDatabyGraphType(FarPoint.Win.Spread.FpSpread spddata, eGraphType eType, int iSampleSize, int iValueCol1, int iAverageCol)
        {
            try
            {
                int i;
                switch (eType)
                {
                    case eGraphType.XBARR:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;
                    case eGraphType.XBARS:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;
                    case eGraphType.XRS:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "   " + MPCF.FindLanguage("Value");
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                    case eGraphType.P:

                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Sample Size") + " (n)";
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + 1].Value = MPCF.FindLanguage("Defect Count") + " (Pn)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 100;
                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + 2; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "P";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                    case eGraphType.PN:

                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Defect Count") + " (Pn)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;
                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1]);

                        for (i = iValueCol1 + 1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "Pn";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                    case eGraphType.C:

                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Defect Count") + " (C)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;
                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1]);

                        for (i = iValueCol1 + 1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "C";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                    case eGraphType.U:

                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1].Value = MPCF.FindLanguage("Sample Size") + " (n)";
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + 1].Value = MPCF.FindLanguage("Defect Count") + " (C)";
                        spddata.Sheets[0].Columns[iValueCol1].Width = 100;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 100;
                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1]);
                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 + 1]);

                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                        }
                        for (i = iValueCol1 + 2; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = "U";
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                    case eGraphType.ZBARS:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = true;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = true;
                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 - 1]);
                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 - 2]);
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = true;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol - 1].Value = MPCF.FindLanguage("Zbar");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;
                    case eGraphType.DELTAS:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetNumberCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = true;
                        MPCF.SetNumberCell(spddata.Sheets[0].Columns[iValueCol1 - 2]);
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = true;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol - 1].Value = MPCF.FindLanguage("Delta");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = true;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = true;
                        break;
                    case eGraphType.NULL:

                        spddata.Sheets[0].Columns[iValueCol1].Width = 60;
                        spddata.Sheets[0].Columns[iValueCol1 + 1].Width = 60;
                        for (i = iValueCol1; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = true;
                            MPCF.SetAsciiCell(spddata.Sheets[0].Columns[i]);
                        }
                        for (i = iValueCol1 + iSampleSize; i <= iValueCol1 + VALUE_COUNT - 1; i++)
                        {
                            spddata.Sheets[0].Columns[i].Visible = false;
                        }
                        for (i = 0; i <= iSampleSize - 1; i++)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = i + 1;
                        }
                        spddata.Sheets[0].Columns[iValueCol1 - 1].Visible = false;
                        spddata.Sheets[0].Columns[iValueCol1 - 2].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = MPCF.FindLanguage("Value");
                        /*
                        if (iSampleSize == 1)
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0);
                        }
                        else
                        {
                            spddata.Sheets[0].ColumnHeader.Cells[0, iValueCol1].Value = "       " + MPCF.FindLanguage("Value", 0) + "(1 ~ " + iSampleSize.ToString() + ")";
                        }
                         */
                        spddata.Sheets[0].Columns[iAverageCol - 1].Visible = false;
                        spddata.Sheets[0].ColumnHeader.Cells[0, iAverageCol].Value = MPCF.FindLanguage("Average");
                        spddata.Sheets[0].Columns[iAverageCol].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 1].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 2].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 3].Visible = false;
                        spddata.Sheets[0].Columns[iAverageCol + 4].Visible = false;
                        break;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.SetDatabyGraphType()\n" + ex.Message);
            }

        }

        public static void SetValuePrompt(FarPoint.Win.Spread.FpSpread spddata, string sChartID, int iSampleSize, int iValueCol1)
        {

            try
            {
                TRSNode in_node = new TRSNode("View_Prompt_In");
                TRSNode out_node = new TRSNode("View_Prompt_Out");

                int i = 0;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));

                if (MPCF.CallService("SPC", "SPC_View_Prompt", in_node, ref out_node, true) == false)
                {
                    return;
                }

                if (out_node.GetList("PRT_LIST").Count > 0)
                {
                    for (i = 0; i <= iSampleSize - 1; i++)
                    {
                        spddata.Sheets[0].ColumnHeader.Cells[1, iValueCol1 + i].Value = out_node.GetList("PRT_LIST")[i].GetString("PROMPT");
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("modSPCFunctions.SetValuePrompt()\n" + ex.Message);
            }

        }


        // View_Spec()
        //       - View Spec
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal iVer As Integer : 踰꾩쟾
        //       - ByVal sChartID As String : 李⑦듃 紐?
        //
        private bool View_Spec(int iVer, string sChartID)
        {

            try
            {
                TRSNode in_node = new TRSNode("View_Spec_In");
                TRSNode out_node = new TRSNode("View_Spec_Out");

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));
                in_node.AddInt("VERSION", iVer);

                if (MPCF.CallService("SPC", "SPC_View_Spec", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                spdChartInfo.Sheets[0].Cells[0, 1].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("USL")), Precision);
                spdChartInfo.Sheets[0].Cells[1, 1].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("TARGET")), Precision);
                spdChartInfo.Sheets[0].Cells[2, 1].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LSL")), Precision);
                spdChartInfo.Sheets[0].Cells[0, 3].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL")), Precision);
                spdChartInfo.Sheets[0].Cells[1, 3].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL")), Precision);
                spdChartInfo.Sheets[0].Cells[2, 3].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL")), Precision);
                spdChartInfo.Sheets[0].Cells[0, 5].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL2")), Precision);
                spdChartInfo.Sheets[0].Cells[1, 5].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL2")), Precision);
                spdChartInfo.Sheets[0].Cells[2, 5].Value = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL2")), Precision);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChart.View_Spec()\n" + ex.Message);
                return false;
            }

        }
        // SetDefaultUnit()
        //       - Set Default Unit
        //
        private void SetDefaultUnit()
        {

            //try
            //{
            //    if (DefaultUnitFlag == "Y")
            //    {
            //        SPCLIST.ViewSPCDefaultUnitList(spdData, "1", ChartID, UNIT_COL, 0, spdData.Sheets[0].RowCount, -1);
            //    }

            //    if ((DefaultUnitFlag == "Y" && DefaultUnitOvrFlag == "Y" && UnitTable != "") || (DefaultUnitFlag == "" && UnitTable != ""))
            //    {
            //        if (BASLIST.ViewGCMDataList(spdData, '1', UnitTable, -1, null, "", false, UNIT_COL, -1, null) == false)
            //        {
            //            return;
            //        }
            //    }
            //    else if (UnitTable == "")
            //    {
            //        spdData.Sheets[0].Columns[UNIT_COL].CellType = new FarPoint.Win.Spread.CellType.TextCellType();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMsgBox("udcChartInfo.SetDefaultUnit()\n" + ex.Message);
            //}

        }

        // SetDefaultValue()
        //       - Set Default Value
        //
        private void SetDefaultValue()
        {

            //try
            //{
            //    int j;
            //    int k;

            //    if (DefaultValue != "" || ValueTable != "")
            //    {
            //        for (j = VALUE_1_COL; j <= VALUE_1_COL + VALUE_COUNT - 1; j++)
            //        {
            //            if (spdData.Sheets[0].Columns[j].Visible == true)
            //            {
            //                if (DefaultValue != "")
            //                {
            //                    for (k = 0; k <= spdData.Sheets[0].RowCount - 1; k++)
            //                    {
            //                        spdData.Sheets[0].SetValue(k, j, DefaultValue);
            //                    }
            //                }
            //                if (ValueTable != "")
            //                {
            //                    if (BASLIST.ViewGCMDataList(spdData, '1', ValueTable, -1, null, "", false, j, -1, null) == false)
            //                    {
            //                        return;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MPCF.ShowMsgBox("udcChartInfo.SetDefaultValue()\n" + ex.Message);
            //}

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
                    for (j = VALUE_1_COL; j <= VALUE_1_COL + VALUE_COUNT - 1; j++)
                    {
                        spdData.Sheets[0].Cells[i, j].BackColor = Color.Lime;
                    }
                    spdData.Sheets[0].Cells[i, AVERAGE_COL].BackColor = MPGV.gTheme.SpreadCellEditableBackColor;
                    spdData.Sheets[0].Cells[i, WEIGHT_COL].BackColor = MPGV.gTheme.SpreadCellEditableBackColor;
                }


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("udcChartInfo.BackColorClear()\n" + ex.Message);
            }

        }
        // SetCollectData()
        //       - Set Collection Data
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void SetCollectData()
        {

            try
            {
     
                ChartID = MPCF.Trim(cdvChartID.Text);
                LotResFlag = 'R';
                ResID = MPCF.Trim(cdvResID.Text);
                EventID = MPCF.Trim(cdvEventID.Text);
                CharID = MPCF.Trim(cdvCharID.Text);
                //TranTime = ((DateTime)uccTranDate.Value).ToString("yyyyMMdd") + ((DateTime)udtTranTime.Value).ToString("HHmmss");
                //UserID = MPCF.Trim(cdvUserID.Text);
                
                //if (chkTranDateTime.Checked == true)
                //{
                //    IsBackTime = true;
                //}
                //else
                //{
                //    IsBackTime = false;
                //}
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.SetCollectData()\n" + ex.Message);
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
                DialogResult dResult = DialogResult.None;
                int i;
                int j;
                int k;
                int iValueCount;

                MPCF.SetInMsg(in_node);
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
                //in_node.AddString("EDC_COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddInt("UNIT_COUNT", UnitCount);
                in_node.AddInt("SAMPLE_SIZE", SampleSize);
                in_node.AddString("GRAPH_TYPE", MPCF.Trim(Enum.GetName(typeof(eGraphType), GraphTypeIndex)));
                in_node.AddString("USL", USL);
                in_node.AddString("LSL", LSL);
                in_node.AddString("UCL", UCL);
                in_node.AddString("CL", CL);
                in_node.AddString("LCL", LCL);
                in_node.AddString("UCL2", UCL2);
                in_node.AddString("CL2", CL2);
                in_node.AddString("LCL2", LCL2);
                in_node.AddChar("UNIT_USE_FLAG", UseUnit);
                //in_node.AddChar("SELECT_MFO_FLAG", SelectMFOFlag);

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
                            TRSNode value_item = list.AddNode("VALUE_LIST");
                            value_item.AddString("VALUE", MPCF.Trim(with_1.GetValue(i, k + VALUE_1_COL)));
                        }
                    }

                }

                if (MPCF.CallService("SPC", "SPC_Collect_EDC_Data", in_node, ref out_node) == false)
                {
                    if (out_node.MsgCode == "EDC-0054")
                    {
                        //MPCF.ShowMessage("EDC-0054 : Spec out occurred, do you want to proceed?", MSG_LEVEL.WARNING, true);
                        dResult = CMNF.ShowMsgBox("Rule Violation occurred, do you want to proceed?", MessageBoxButtons.YesNo, MSG_LEVEL.WARNING);
                        if (dResult == DialogResult.No || dResult == DialogResult.Cancel)
                        {
                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }
                }
                if (out_node.StatusValue == MPGC.MP_FAIL_STATUS)
                {
                    //MPCF.CheckContinueProc(out_node);
                    return false;
                }
                if (UseUnit == 'Y')
                {
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        spdData.Sheets[0].Cells[i, WEIGHT_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("WEIGHT_VALUE"), Precision);
                        spdData.Sheets[0].Cells[i, AVERAGE_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("AVERAGE"), Precision);
                        spdData.Sheets[0].Cells[i, SIGMA_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("STDDEV"), Precision);
                        spdData.Sheets[0].Cells[i, RANGE_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("RANGE"), Precision);
                        spdData.Sheets[0].Cells[i, MAX_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("MAX_VALUE"), Precision);
                        spdData.Sheets[0].Cells[i, MIN_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[i].GetString("MIN_VALUE"), Precision);
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
                            if (ChartGraphType == eGraphType.XBARR.ToString() ||
                                ChartGraphType == eGraphType.XBARS.ToString() ||
                                ChartGraphType == eGraphType.XRS.ToString())
                            {
                                for (k = 0; k <= SampleSize - 1; k++)
                                {
                                    if (oos_array.GetChar(k.ToString()) == 'Y')
                                    {
                                        spdData.Sheets[0].Cells[i, VALUE_1_COL + k].BackColor = Color.Red;
                                    }
                                }
                            }
                            else if (ChartGraphType == eGraphType.P.ToString() ||
                                     ChartGraphType == eGraphType.U.ToString())
                            {
                                if (oos_array.GetChar("0") == 'Y')
                                {
                                    spdData.Sheets[0].Cells[0, AVERAGE_COL].BackColor = Color.Red;
                                }
                            }
                            else if (ChartGraphType == eGraphType.ZBARS.ToString() || ChartGraphType == eGraphType.DELTAS.ToString())
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
                        else if (out_node.GetList(0)[i].GetChar("X_CHECK_RESULT") == 'B' && SpecCheckType == "V")
                        {
                            oos_array = out_node.GetList("OOS_LIST")[i].GetArray("OOS_CHECK_RESULT");
                            if (ChartGraphType == eGraphType.XBARR.ToString() || ChartGraphType == eGraphType.XBARS.ToString() || ChartGraphType == eGraphType.XRS.ToString())
                            {
                                for (k = 0; k <= SampleSize - 1; k++)
                                {
                                    if (oos_array.GetChar(k.ToString()) == 'Y')
                                    {
                                        spdData.Sheets[0].Cells[i, VALUE_1_COL + k].BackColor = Color.Orange;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    spdData.Sheets[0].Cells[0, WEIGHT_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("WEIGHT_VALUE"), Precision);
                    spdData.Sheets[0].Cells[0, WEIGHT_COL].RowSpan = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].Cells[0, AVERAGE_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("AVERAGE"), Precision);
                    spdData.Sheets[0].Cells[0, AVERAGE_COL].RowSpan = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].Cells[0, SIGMA_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("STDDEV"), Precision);
                    spdData.Sheets[0].Cells[0, SIGMA_COL].RowSpan = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].Cells[0, RANGE_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("RANGE"), Precision);
                    spdData.Sheets[0].Cells[0, RANGE_COL].RowSpan = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].Cells[0, MAX_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("MAX_VALUE"), Precision);
                    spdData.Sheets[0].Cells[0, MAX_COL].RowSpan = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].Cells[0, MIN_COL].Value = MPCF.SetPrecision(out_node.GetList(0)[0].GetString("MIN_VALUE"), Precision);
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
                        if (ChartGraphType == eGraphType.ZBARS.ToString() || ChartGraphType == eGraphType.DELTAS.ToString())
                        {
                            spdData.Sheets[0].Cells[0, WEIGHT_COL].BackColor = Color.Red;
                        }
                        else
                        {
                            for (i = 0; i <= spdData.Sheets[0].RowCount - 1; i++)
                            {
                                oos_array = out_node.GetList("OOS_LIST")[i].GetArray("OOS_CHECK_RESULT");
                                for (k = 0; k <= SampleSize - 1; k++)
                                {
                                    if (oos_array.GetChar(k.ToString()) == 'Y')
                                    {
                                        spdData.Sheets[0].Cells[i, VALUE_1_COL + k].BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                    else if (out_node.GetList(0)[0].GetChar("X_CHECK_RESULT") == 'B' && SpecCheckType == "V")
                    {
                        for (i = 0; i <= spdData.Sheets[0].RowCount - 1; i++)
                        {
                            oos_array = out_node.GetList("OOS_LIST")[i].GetArray("OOS_CHECK_RESULT");
                            for (k = 0; k <= SampleSize - 1; k++)
                            {
                                if (oos_array.GetChar(k.ToString()) == 'Y')
                                {
                                    spdData.Sheets[0].Cells[i, VALUE_1_COL + k].BackColor = Color.Orange;
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
                    
                    if (ParentForm is frmSPCCollectLotData)
                    {
                        ((frmSPCCollectLotData)this.ParentForm).btnProcess.Enabled = false;
                    }
                    else if (ParentForm is frmSPCCollectResData)
                    {
                        ((frmSPCCollectResData)this.ParentForm).btnProcess.Enabled = false;
                    }
                    //else if (ParentForm is frmSPCTranCollectLotDatabyCharacter)
                    //{
                    //    ((frmSPCTranCollectLotDatabyCharacter)this.ParentForm).btnOK.Enabled = false;
                    //    ((frmSPCTranCollectLotDatabyCharacter)this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                    //}
                    //else if (ParentForm is frmSPCTranCollectResDatabyCharacter)
                    //{
                    //    ((frmSPCTranCollectResDatabyCharacter)this.ParentForm).btnOK.Enabled = false;
                    //    ((frmSPCTranCollectResDatabyCharacter)this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                    //}
                    SetLockSpread(true);
                }
                MPCF.ShowSuccessMessage(out_node, false);
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.btnProcess_Click()\n" + ex.Message);
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
                    //frmSPCTranOOCHistory f1;
                    f.spdResult.Sheets[0].Columns[1].Visible = false;

                    View_Result(f.spdResult, out_node, "1");
                    f.ShowDialog(this);

                    //Pending
                    if (f.DialogResult == System.Windows.Forms.DialogResult.Ignore)
                    {
                        //Data Commit
                        //OOC History Insert
                        if (CollectEDCData(MP_STEP_PEND) == false)
                        {
                            return false;
                        }
                        if (ParentForm is frmSPCCollectLotData)
                        {
                            ((frmSPCCollectLotData)this.ParentForm).btnProcess.Enabled = false;
                        }
                        else if (ParentForm is frmSPCCollectResData)
                        {
                            ((frmSPCCollectResData)this.ParentForm).btnProcess.Enabled = false;
                        }
                        //else if (ParentForm is frmSPCTranCollectLotDatabyCharacter)
                        //{
                        //    ((frmSPCTranCollectLotDatabyCharacter)this.ParentForm).btnOK.Enabled = false;
                        //    ((frmSPCTranCollectLotDatabyCharacter)this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                        //}
                        //else if (ParentForm is frmSPCTranCollectResDatabyCharacter)
                        //{
                        //    ((frmSPCTranCollectResDatabyCharacter)this.ParentForm).btnOK.Enabled = false;
                        //    ((frmSPCTranCollectResDatabyCharacter)this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                        //}
                        SetLockSpread(true);

                        //Continue
                    }
                    else if (f.DialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        f.Dispose();
                        if (CollectEDCData(MP_STEP_CONT) == false)
                        {
                            return false;
                        }
                        //f1 = new frmSPCTranOOCHistory(out_node.GetInt("HIST_SEQ"), out_node.GetString("TRAN_TIME"), -1);
                        //f1.spdResult.Sheets[0].Columns[1].Visible = false;
                        //View_Result(f1.spdResult, out_node, "2");
                        //f1.txtChart.Text = ChartID;
                        //f1.txtGraphType.Text = ChartGraphType;
                        //f1.ShowDialog(this);
                        //if (ParentForm is frmSPCTranCollectLotData)
                        //{
                        //    ((frmSPCTranCollectLotData)this.ParentForm).btnOK.Enabled = false;
                        //}
                        //else if (ParentForm is frmSPCTranCollectResourceData)
                        //{
                        //    ((frmSPCTranCollectResourceData)this.ParentForm).btnOK.Enabled = false;
                        //}
                        //else if (ParentForm is frmSPCTranCollectLotDatabyCharacter)
                        //{
                        //    ((frmSPCTranCollectLotDatabyCharacter)this.ParentForm).btnOK.Enabled = false;
                        //    ((frmSPCTranCollectLotDatabyCharacter)this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                        //}
                        //else if (ParentForm is frmSPCTranCollectResDatabyCharacter)
                        //{
                        //    ((frmSPCTranCollectResDatabyCharacter)this.ParentForm).btnOK.Enabled = false;
                        //    ((frmSPCTranCollectResDatabyCharacter)this.ParentForm).tabChart.SelectedTab.Tag = "Y";
                        //}
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
        // View_Result()
        //       - View Result of Data Collection
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef spdResult As FpSpread - 寃곌낵 ?쒖떆 ?ㅽ봽?덈뱶
        //       - ByVal Result_Out As SPC_Collect_EDC_Data_Out_Tag : Data Collection Out ?쒓렇
        //       - ByVal c_step As String
        //
        public void View_Result(FpSpread spdResult, TRSNode out_node, string c_step)
        {

            try
            {
                int i;
                MPCF.ClearList(spdResult, true);
                if (UseUnit != 'Y')
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
        #endregion

       

        
    }
}
