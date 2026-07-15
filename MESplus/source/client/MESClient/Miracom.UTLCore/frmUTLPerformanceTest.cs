using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.MsgHandler;
using Miracom.TRSCore;

namespace Miracom.UTLCore
{
    public partial class frmUTLPerformanceTest : TranForm01
    {
        public frmUTLPerformanceTest()
        {
            InitializeComponent();
        }

        private List<clsPerformanceTestRunner> TR_LIST;

        private void frmUTLPerformanceTest_Load(object sender, EventArgs e)
        {
            TR_LIST = new List<clsPerformanceTestRunner>();
            lblPrgTotal.Text = "";

            MPIF.gInit.IsShowProgressBar = false;
        }

        private void frmUTLPerformanceTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            MPIF.gInit.IsShowProgressBar = true;
        }

        private delegate void setTranTimeCallback(ListViewItem itm);
        public void setTranTimeData(ListViewItem itm)
        {
            if (this.lisLotList.InvokeRequired)
            {
                setTranTimeCallback d = new setTranTimeCallback(setTranTimeData);
                this.Invoke(d, new object[] { itm });
            }
            else
            {
                lisLotList.Items.Add(itm);
                lisLotList.EnsureVisible(lisLotList.Items.Count - 1);
            }
        }

        private delegate void setStartTimeCallback(string s_time);
        public void setStartTime(string s_time)
        {
            if (this.txtStartTime.InvokeRequired)
            {
                setStartTimeCallback d = new setStartTimeCallback(setStartTime);
                this.Invoke(d, new object[] { s_time });
            }
            else
            {
                txtStartTime.Text = s_time;
            }
        }

        private delegate void setEndTimeCallback(string s_time);
        public void setEndTime(string s_time)
        {
            if (this.txtEndTime.InvokeRequired)
            {
                setEndTimeCallback d = new setEndTimeCallback(setEndTime);
                this.Invoke(d, new object[] { s_time });
            }
            else
            {
                txtEndTime.Text = s_time;
            }
        }

        private delegate void setElapsedTimeCallback(string s_time);
        public void setElapsedTime(string s_time)
        {
            if (this.txtElapsedTime.InvokeRequired)
            {
                setElapsedTimeCallback d = new setElapsedTimeCallback(setElapsedTime);
                this.Invoke(d, new object[] { s_time });
            }
            else
            {
                txtElapsedTime.Text = s_time;
            }
        }

        private delegate void setMinTimeCallback(double d_time);
        public void setMinTime(double d_time)
        {
            if (this.txtMinTime.InvokeRequired)
            {
                setMinTimeCallback d = new setMinTimeCallback(setMinTime);
                this.Invoke(d, new object[] { d_time });
            }
            else
            {
                double d = MPCF.ToDbl(txtMinTime.Text);
                if (d < 0.0000001) d = 9999999;

                if (d_time < d)
                {
                    txtMinTime.Text = d_time.ToString("#############,##0.###");
                }
            }
        }

        private delegate void setMaxTimeCallback(double d_time);
        public void setMaxTime(double d_time)
        {
            if (this.txtMaxTime.InvokeRequired)
            {
                setMaxTimeCallback d = new setMaxTimeCallback(setMaxTime);
                this.Invoke(d, new object[] { d_time });
            }
            else
            {
                double d = MPCF.ToDbl(txtMaxTime.Text);

                if (d_time > d)
                {
                    txtMaxTime.Text = d_time.ToString("#############,##0.###");
                }
            }
        }

        private delegate void setAvgTimeCallback(double d_time);
        public void setAvgTime(double d_time)
        {
            if (this.txtAvgTime.InvokeRequired)
            {
                setAvgTimeCallback d = new setAvgTimeCallback(setAvgTime);
                this.Invoke(d, new object[] { d_time });
            }
            else
            {
                txtAvgTime.Text = d_time.ToString("#############,##0.###");
            }
        }

        private delegate void setNowTimeCallback(double d_time);
        public void setNowTime(double d_time)
        {
            if (this.txtNowTime.InvokeRequired)
            {
                setNowTimeCallback d = new setNowTimeCallback(setNowTime);
                this.Invoke(d, new object[] { d_time });
            }
            else
            {
                txtNowTime.Text = d_time.ToString("#############,##0.###");
            }
        }

        private delegate void setServiceCountCallback(int i_count);
        public void setServiceCount(int i_count)
        {
            if (this.txtServiceCount.InvokeRequired)
            {
                setServiceCountCallback d = new setServiceCountCallback(setServiceCount);
                this.Invoke(d, new object[] { i_count });
            }
            else
            {
                txtServiceCount.Text = (MPCF.ToInt(txtServiceCount.Text) + i_count).ToString("################,##0");
            }
        }

        private delegate void setTotalProgressCallback(int i_value);
        public void setTotalProgress(int i_value)
        {
            if (this.prgTotal.InvokeRequired)
            {
                setTotalProgressCallback d = new setTotalProgressCallback(setTotalProgress);
                this.Invoke(d, new object[] { i_value });
            }
            else
            {
                prgTotal.Value = prgTotal.Value + i_value;
                lblPrgTotal.Text = prgTotal.Value.ToString() + " / " + txtTotalLotCount.Text;
            }
        }

        private delegate void setFinishTestRunnerCallback();
        public void setFinishTestRunner()
        {
            if (this.btnProcess.InvokeRequired)
            {
                setFinishTestRunnerCallback d = new setFinishTestRunnerCallback(setFinishTestRunner);
                this.Invoke(d);
            }
            else
            {
                btnProcess.Enabled = true;
                btnStop.Enabled = false;
                prgRunning.Enabled = false;
                prgRunning.Visible = false;
            }
        }


        
        private void btnStop_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TR_LIST.Count; i++)
            {
                TR_LIST[i].setStopFlag(true);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(txtThreadCount, 1) == false) return;
            if (MPCF.CheckValue(cboLotID, 1) == false) return;
            if (MPCF.CheckValue(txtLotCount, 1) == false) return;
            if (chkRandomQty.Checked == false && MPCF.CheckValue(txtLotQty, 1) == false) return;
            if (MPCF.ToInt(txtLotCount.Text) > 999999)
            {
                txtLotCount.Text = "";
                txtLotCount.Focus();
                MPCF.ShowMsgBox(MPCF.GetMessage(189));
                return;
            }
            if (chkRandomQty.Checked == false && MPCF.ToInt(txtLotQty.Text) > 999999)
            {
                txtLotQty.Text = "";
                txtLotQty.Focus();
                MPCF.ShowMsgBox(MPCF.GetMessage(189));
                return;
            }

            btnProcess.Enabled = false;
            btnStop.Enabled = true;
            prgRunning.Enabled = true;
            prgRunning.Visible = true;

            txtStartTime.Text = "";
            txtEndTime.Text = "";
            txtElapsedTime.Text = "";

            txtMinTime.Text = "";
            txtMaxTime.Text = "";
            txtAvgTime.Text = "";
            txtServiceCount.Text = "";
            txtNowTime.Text = "";
            txtTotalLotCount.Text = "";

            MPCF.InitListView(lisLotList);

            prgTotal.Value = 0;
            lblPrgTotal.Text = "";


            int i;
            int i_thread_count;
            int i_test_lot_count;
            Thread proc;
            clsPerformanceTestRunner TR;

            for (i = 0; i < TR_LIST.Count; i++)
            {
                TR = TR_LIST[i];
                TR = null;
            }

            TR_LIST.Clear();

            i_thread_count = MPCF.ToInt(txtThreadCount.Text);
            i_test_lot_count = MPCF.ToInt(txtLotCount.Text);

            prgTotal.Maximum = i_thread_count * i_test_lot_count;
            txtTotalLotCount.Text = prgTotal.Maximum.ToString("################,##0");

            for (i = 0; i < i_thread_count; i++)
            {
                TR = new clsPerformanceTestRunner();
                TR.setTestThread(this, i, chkIgnoreError.Checked);
                TR.setTestLotInfo(cboLotID.Text, i_test_lot_count, MPCF.ToInt(txtLotQty.Text), chkRandomQty.Checked);

                TR_LIST.Add(TR);

                proc = new Thread(new ThreadStart(TR.ProcessTest));
                proc.Name = "PerformanceTestRunner #" + i.ToString();

                try
                {
                    proc.Start();
                }
                catch (ThreadStateException ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
                catch (ThreadInterruptedException ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                }
            }

        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            string sCond = "";

            try
            {
                sCond = "Lot ID :" + MPCF.Trim(cboLotID.Text);
                sCond += "\rLot Count :" + MPCF.Trim(txtLotCount.Text);
                sCond += "\rLot Qty :" + MPCF.Trim(txtLotQty.Text);

                MPCF.ExportToExcel(lisLotList, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            //int i;

            //for (i = 0; i < 100; i++)
            //{
            //    if (A08_Resource_Event("EVENT_1") == false) return;
            //    if (A08_Resource_Event("EVENT_2") == false) return;
            //}
        }

        private void lisLotList_Click(System.Object sender, System.EventArgs e)
        {
            int i;

            MPGV.gaSelectLot_ID.Clear();
            MPGV.gsCurrentLot_ID = "";

            if (lisLotList.SelectedItems.Count > 0)
            {
                for (i = 0; i < lisLotList.SelectedItems.Count; i++)
                {
                    MPGV.gaSelectLot_ID.Add(lisLotList.SelectedItems[i].SubItems[1].Text);
                }

                MPGV.gsCurrentLot_ID = lisLotList.FocusedItem.SubItems[1].Text;

            }

        }

        private void lisLotList_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                ListView lisList;
                lisList = (ListView)sender;
                if (lisList.SelectedItems.Count == 0)
                {
                    Clipboard.SetDataObject("", true);
                }
                else
                {
                    Clipboard.SetDataObject(lisList.SelectedItems[0].SubItems[1].Text, true);
                }
            }
        }

        private void chkRandomQty_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRandomQty.Checked == true)
            {
                txtLotQty.Text = "";
                txtLotQty.Enabled = false;
            }
            else
            {
                txtLotQty.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (prgRunning.Enabled == true)
            {
                if (prgRunning.Value == prgRunning.Maximum)
                {
                    prgRunning.Value = 0;
                }

                prgRunning.PerformStep();
            }
        }




    }

}
