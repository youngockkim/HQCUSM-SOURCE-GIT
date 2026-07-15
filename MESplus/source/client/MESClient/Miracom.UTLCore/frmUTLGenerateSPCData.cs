using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.UTLCore
{
    public partial class frmUTLGenerateSPCData : TranForm01
    {
        public frmUTLGenerateSPCData()
        {
            InitializeComponent();
        }

        #region " Variable Definition"

        private TRSNode gLOT;
        private TRSNode gRES;
        private List<TRSNode> gCHART;

        #endregion

        #region " Function Implementations"

        private bool ViewLot(string s_lot_id, TRSNode LOT)
        {
            TRSNode in_node = new TRSNode("View_Lot_In");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '3';
            in_node.AddString("LOT_ID", MPCF.Trim(s_lot_id));

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref LOT) == false)
            {
                return false;
            }

            return true;
        }

        private bool ViewResource(string s_res_id, TRSNode RES)
        {
            TRSNode in_node = new TRSNode("View_Resource_In");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RES_ID", MPCF.Trim(s_res_id));

            if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref RES) == false)
            {
                return false;
            }

            return true;
        }

        private bool ViewChart(string s_chart_id, TRSNode CHART)
        {
            TRSNode in_node = new TRSNode("View_Chart_In");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("CHART_ID", MPCF.Trim(s_chart_id));

            if (MPCR.CallService("SPC", "SPC_View_Chart", in_node, ref CHART) == false)
            {
                return false;
            }

            return true;
        }

        private bool CollectData(int index, TextBox txtFrom, TextBox txtTo)
        {
            TRSNode CHART;
            double d_from;
            double d_to;
            double d_from1;
            double d_to1;
            double d_from2;
            double d_to2;

            if (gCHART[index] == null) return false;

            CHART = gCHART[index];

            d_from = MPCF.ToDbl(txtFrom.Text);
            d_to = MPCF.ToDbl(txtTo.Text);

            d_from1 = ((d_to - d_from) / 3) + d_from;
            d_to1 = d_to - ((d_to - d_from) / 3);

            d_from2 = ((d_to1 - d_from1) / 3) + d_from1;
            d_to2 = d_to1 - ((d_to1 - d_from1) / 3);

            if (MPCF.Trim(txtFrom.Text) == "") d_from = 0;
            if (MPCF.Trim(txtTo.Text) == "") d_to = 100;

            TRSNode DATA = new TRSNode("COLLECT_DATA");
            TRSNode unitItem;
            TRSNode valueItem;

            int i_sample_size;
            int i_unit_count;
            Random rd = new Random();
            double d_value;
            int i_random;

            i_unit_count = CHART.GetInt("UNIT_COUNT");
            if (i_unit_count < 1) i_unit_count = 1;

            if (CHART.GetString("GRAPH_TYPE") == "P") i_sample_size = 2;
            else if (CHART.GetString("GRAPH_TYPE") == "U") i_sample_size = 2;
            else if (CHART.GetString("GRAPH_TYPE") == "PN") i_sample_size = 1;
            else
            {
                i_sample_size = CHART.GetInt("SAMPLE_SIZE");
                if (i_sample_size < 1) i_sample_size = 1;
            }

            for (int k = 0; k < i_unit_count; k++)
            {
                unitItem = DATA.AddNode("UNIT_LIST");
                unitItem.AddString("UNIT_ID", "*");

                if (CHART.GetString("GRAPH_TYPE") == "ZBARS")
                {
                    d_value = ((d_to - d_from) / 2) + d_from;
                    unitItem.AddString("NOMINAL", d_value.ToString("#0.##"));

                    d_value = rd.NextDouble();
                    unitItem.AddString("PROCESS_SIGMA", d_value.ToString("#0.##"));
                }
                if (CHART.GetString("GRAPH_TYPE") == "DELTAS")
                {
                    d_value = ((d_to - d_from) / 2) + d_from;
                    unitItem.AddString("NOMINAL", d_value.ToString("#0.##"));
                }

                for (int i = 0; i < i_sample_size; i++)
                {
                    valueItem = unitItem.AddNode("VALUE_LIST");

                    d_value = 0;

                    if (CHART.GetString("GRAPH_TYPE") == "P" ||
                        CHART.GetString("GRAPH_TYPE") == "U" ||
                        CHART.GetString("GRAPH_TYPE") == "PN" ||
                        CHART.GetString("GRAPH_TYPE") == "C")
                    {
                        if (CHART.GetString("GRAPH_TYPE") == "P")
                        {
                            if (i == 0) d_value = rd.Next((int)(d_to * 80), (int)(d_to * 100));
                            else d_value = rd.Next((int)d_from, (int)d_to);
                        }
                        else if (CHART.GetString("GRAPH_TYPE") == "U")
                        {
                            if (i == 0) d_value = rd.Next((int)(d_to * 40), (int)(d_to * 50));
                            else d_value = rd.Next((int)d_from, (int)d_to);
                        }
                        else if (CHART.GetString("GRAPH_TYPE") == "PN")
                        {
                            d_value = rd.Next((int)d_from, (int)d_to);
                        }
                        else if (CHART.GetString("GRAPH_TYPE") == "C")
                        {
                            d_value = rd.Next((int)d_from, (int)d_to);
                        }
                    }
                    else
                    {
                        i_random = rd.Next(1, 9);
                        if (i_random % 3 == 0)
                        {
                            d_value = rd.NextDouble() * (d_to - d_from) + d_from;
                        }
                        else if (i_random % 2 == 0)
                        {
                            d_value = rd.NextDouble() * (d_to1 - d_from1) + d_from1;
                        }
                        else
                        {
                            d_value = rd.NextDouble() * (d_to2 - d_from2) + d_from2;
                        }
                    }

                    valueItem.AddString("VALUE", d_value.ToString("#0.##"));
                }
            }

            if (CollectEDCData(DATA, CHART, gLOT, gRES) == false) return false;

            return true;
        }
        
        private bool CollectEDCData(TRSNode DATA, TRSNode CHART, TRSNode LOT, TRSNode RES)
        {
            try
            {
                TRSNode in_node = new TRSNode("Collect_EDC_Data_In");
                TRSNode out_node = new TRSNode("Collect_EDC_Data_Out");
                List<TRSNode> unitList;
                List<TRSNode> valueList;

                int i;
                int k;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;
                in_node.AddChar("SUB_STEP", 'N');

                in_node.AddChar("LOT_RES_FLAG", CHART.GetChar("LOT_RES_FLAG"));
                in_node.AddString("LOT_ID", LOT.GetString("LOT_ID"));
                in_node.AddString("MAT_ID", LOT.GetString("MAT_ID"));
                in_node.AddInt("MAT_VER", LOT.GetInt("MAT_VER"));
                in_node.AddString("FLOW", LOT.GetString("FLOW"));
                in_node.AddInt("FLOW_SEQ_NUM", LOT.GetInt("FLOW_SEQ_NUM"));
                in_node.AddString("OPER", LOT.GetString("OPER"));
                //in_node.AddString("PROC_OPER", ProcOper);
                in_node.AddString("RES_ID", RES.GetString("RES_ID"));
                //in_node.AddString("EVENT_ID", EventID);
                //in_node.AddString("PROC_RES_ID", ProcResID);
                in_node.AddString("CHAR_ID", CHART.GetString("CHAR_ID"));
                in_node.AddString("CHART_ID", CHART.GetString("CHART_ID"));
                //in_node.AddString("EDC_COMMENT", MPCF.Trim(txtComment.Text));
                //in_node.AddInt("SAMPLE_SIZE", ctrlChartData.SampleSize);
                in_node.AddString("GRAPH_TYPE", CHART.GetString("GRAPH_TYPE"));
                //in_node.AddString("USL", ctrlChartData.USL);
                //in_node.AddString("LSL", ctrlChartData.LSL);
                //in_node.AddString("UCL", ctrlChartData.UCL);
                //in_node.AddString("CL", ctrlChartData.CL);
                //in_node.AddString("LCL", ctrlChartData.LCL);
                //in_node.AddString("UCL2", ctrlChartData.UCL2);
                //in_node.AddString("CL2", ctrlChartData.CL2);
                //in_node.AddString("LCL2", ctrlChartData.LCL2);
                in_node.AddChar("UNIT_USE_FLAG", CHART.GetChar("UNIT_USE_FLAG"));
                //in_node.AddChar("SELECT_MFO_FLAG", SelectMFOFlag);

                unitList = DATA.GetList("UNIT_LIST");
                in_node.AddInt("UNIT_COUNT", unitList.Count);

                for (i = 0; i < unitList.Count; i++)
                {
                    TRSNode unitItem = in_node.AddNode("UNIT_LIST");

                    unitItem.AddInt("UNIT_SEQ", i + 1);
                    unitItem.AddString("UNIT_ID", unitList[i].GetString("UNIT_ID"));
                    unitItem.AddString("NOMINAL", unitList[i].GetString("NOMINAL"));
                    unitItem.AddString("PROCESS_SIGMA", unitList[i].GetString("PROCESS_SIGMA"));

                    valueList = unitList[i].GetList("VALUE_LIST");
                    unitItem.AddInt("VALUE_COUNT", valueList.Count);

                    for (k = 0; k < valueList.Count; k++)
                    {
                        TRSNode valueItem = unitItem.AddNode("VALUE_LIST");
                        valueItem.AddString("VALUE", valueList[k].GetString("VALUE"));
                    }
                }

                if (MPCR.CallService("SPC", "SPC_Collect_EDC_Data", in_node, ref out_node) == false)
                {
                    return false;
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

        private void cdvChartID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdv = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            try
            {
                cdv.Init();
                MPCF.InitListView(cdv.GetListView);
                cdv.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdv.Columns.Add("GraphType", 50, HorizontalAlignment.Left);
                cdv.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdv.SelectedSubItemIndex = 0;
                cdv.SelectedDescIndex = 2;
                SPCLIST.ViewChartList(cdv.GetListView, '2', "", 0, "", "", "", ' ', ' ', MPCF.Trim(cdv.Text), "", -1, -1, null, "");
                cdv.AddEmptyRow(1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private bool setTimer(CheckBox chk, Timer tmr, TextBox txtInterval, Miracom.UI.Controls.MCCodeView.MCCodeView cdv, int index)
        {
            tmr.Enabled = false;
            gCHART[index] = null;

            int i_interval = MPCF.ToInt(txtInterval.Text);
            if (chk.Checked == true && i_interval > 0 && MPCF.Trim(cdv.Text) != "")
            {
                TRSNode CHART = new TRSNode("CHART");
                if (ViewChart(cdv.Text, CHART) == false) return false;

                tmr.Interval = i_interval * 1000;
                tmr.Enabled = true;

                chk.Enabled = false;
                cdv.Enabled = false;
                cdv.ReadOnly = true;
                txtInterval.Enabled = false;

                gCHART[index] = CHART;
            }

            return true;
        }
        
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtLotID, 1) == false) return;
            if (MPCF.CheckValue(txtResID, 1) == false) return;

            if (gLOT == null) gLOT = new TRSNode("View_Lot_Out");
            else              gLOT.Init();

            if (gRES == null) gRES = new TRSNode("View_Resource_Out");
            else              gRES.Init();

            if (gCHART == null)
            {
                gCHART = new List<TRSNode>();

                for (int i = 0; i < 9; i++)
                {
                    gCHART.Add(null);
                }
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    gCHART[i] = null;
                }
            }
            
            if (ViewLot(txtLotID.Text, gLOT) == false) return;
            if (ViewResource(txtResID.Text, gRES) == false) return;

            if (setTimer(chkChart1, tmrChart1, txtInterval1, cdvChartID1, 0) == false) return;
            if (setTimer(chkChart2, tmrChart2, txtInterval2, cdvChartID2, 1) == false) return;
            if (setTimer(chkChart3, tmrChart3, txtInterval3, cdvChartID3, 2) == false) return;
            if (setTimer(chkChart4, tmrChart4, txtInterval4, cdvChartID4, 3) == false) return;
            if (setTimer(chkChart5, tmrChart5, txtInterval5, cdvChartID5, 4) == false) return;
            if (setTimer(chkChart6, tmrChart6, txtInterval6, cdvChartID6, 5) == false) return;
            if (setTimer(chkChart7, tmrChart7, txtInterval7, cdvChartID7, 6) == false) return;
            if (setTimer(chkChart8, tmrChart8, txtInterval8, cdvChartID8, 7) == false) return;
            if (setTimer(chkChart9, tmrChart9, txtInterval9, cdvChartID9, 8) == false) return;

            btnStop.Enabled = true;
            btnProcess.Enabled = false;
            chkCheckAll.Enabled = false;
        }

        private void tmrChart1_Tick(object sender, EventArgs e)
        {
            if (CollectData(0, txtFrom1, txtTo1) == false)
            {
                tmrChart1.Enabled = false;
                chkChart1.Enabled = true;
                cdvChartID1.Enabled = true;
                cdvChartID1.ReadOnly = false;
                txtInterval1.Enabled = true;
                return;
            }
        }
        private void tmrChart2_Tick(object sender, EventArgs e)
        {
            if (CollectData(1, txtFrom2, txtTo2) == false)
            {
                tmrChart2.Enabled = false;
                chkChart2.Enabled = true;
                cdvChartID2.Enabled = true;
                cdvChartID2.ReadOnly = false;
                txtInterval2.Enabled = true;
                return;
            }
        }
        private void tmrChart3_Tick(object sender, EventArgs e)
        {
            if (CollectData(2, txtFrom3, txtTo3) == false)
            {
                tmrChart3.Enabled = false;
                chkChart3.Enabled = true;
                cdvChartID3.Enabled = true;
                cdvChartID3.ReadOnly = false;
                txtInterval3.Enabled = true;
                return;
            }
        }
        private void tmrChart4_Tick(object sender, EventArgs e)
        {
            if (CollectData(3, txtFrom4, txtTo4) == false)
            {
                tmrChart4.Enabled = false;
                chkChart4.Enabled = true;
                cdvChartID4.Enabled = true;
                cdvChartID4.ReadOnly = false;
                txtInterval4.Enabled = true;
                return;
            }
        }
        private void tmrChart5_Tick(object sender, EventArgs e)
        {
            if (CollectData(4, txtFrom5, txtTo5) == false)
            {
                tmrChart5.Enabled = false;
                chkChart5.Enabled = true;
                cdvChartID5.Enabled = true;
                cdvChartID5.ReadOnly = false;
                txtInterval5.Enabled = true;
                return;
            }
        }
        private void tmrChart6_Tick(object sender, EventArgs e)
        {
            if (CollectData(5, txtFrom6, txtTo6) == false)
            {
                tmrChart6.Enabled = false;
                chkChart6.Enabled = true;
                cdvChartID6.Enabled = true;
                cdvChartID6.ReadOnly = false;
                txtInterval6.Enabled = true;
                return;
            }
        }
        private void tmrChart7_Tick(object sender, EventArgs e)
        {
            if (CollectData(6, txtFrom7, txtTo7) == false)
            {
                tmrChart7.Enabled = false;
                chkChart7.Enabled = true;
                cdvChartID7.Enabled = true;
                cdvChartID7.ReadOnly = false;
                txtInterval7.Enabled = true;
                return;
            }
        }
        private void tmrChart8_Tick(object sender, EventArgs e)
        {
            if (CollectData(7, txtFrom8, txtTo8) == false)
            {
                tmrChart8.Enabled = false;
                chkChart8.Enabled = true;
                cdvChartID8.Enabled = true;
                cdvChartID8.ReadOnly = false;
                txtInterval8.Enabled = true;
                return;
            }
        }
        private void tmrChart9_Tick(object sender, EventArgs e)
        {
            if (CollectData(8, txtFrom9, txtTo9) == false)
            {
                tmrChart9.Enabled = false;
                chkChart9.Enabled = true;
                cdvChartID9.Enabled = true;
                cdvChartID9.ReadOnly = false;
                txtInterval9.Enabled = true;
                return;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnProcess.Enabled = true;
            chkCheckAll.Enabled = true;

            tmrChart1.Enabled = false;
            tmrChart2.Enabled = false;
            tmrChart3.Enabled = false;
            tmrChart4.Enabled = false;
            tmrChart5.Enabled = false;
            tmrChart6.Enabled = false;
            tmrChart7.Enabled = false;
            tmrChart8.Enabled = false;
            tmrChart9.Enabled = false;

            chkChart1.Enabled = true;
            chkChart2.Enabled = true;
            chkChart3.Enabled = true;
            chkChart4.Enabled = true;
            chkChart5.Enabled = true;
            chkChart6.Enabled = true;
            chkChart7.Enabled = true;
            chkChart8.Enabled = true;
            chkChart9.Enabled = true;
            cdvChartID1.Enabled = true;
            cdvChartID2.Enabled = true;
            cdvChartID3.Enabled = true;
            cdvChartID4.Enabled = true;
            cdvChartID5.Enabled = true;
            cdvChartID6.Enabled = true;
            cdvChartID7.Enabled = true;
            cdvChartID8.Enabled = true;
            cdvChartID9.Enabled = true;
            cdvChartID1.ReadOnly = false;
            cdvChartID2.ReadOnly = false;
            cdvChartID3.ReadOnly = false;
            cdvChartID4.ReadOnly = false;
            cdvChartID5.ReadOnly = false;
            cdvChartID6.ReadOnly = false;
            cdvChartID7.ReadOnly = false;
            cdvChartID8.ReadOnly = false;
            cdvChartID9.ReadOnly = false;
            txtInterval1.Enabled = true;
            txtInterval2.Enabled = true;
            txtInterval3.Enabled = true;
            txtInterval4.Enabled = true;
            txtInterval5.Enabled = true;
            txtInterval6.Enabled = true;
            txtInterval7.Enabled = true;
            txtInterval8.Enabled = true;
            txtInterval9.Enabled = true;

        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            chkChart1.Checked = chkCheckAll.Checked;
            chkChart2.Checked = chkCheckAll.Checked;
            chkChart3.Checked = chkCheckAll.Checked;
            chkChart4.Checked = chkCheckAll.Checked;
            chkChart5.Checked = chkCheckAll.Checked;
            chkChart6.Checked = chkCheckAll.Checked;
            chkChart7.Checked = chkCheckAll.Checked;
            chkChart8.Checked = chkCheckAll.Checked;
            chkChart9.Checked = chkCheckAll.Checked;
        }




    }
}
