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
    public partial class frmUTLGenerateLotData : TranForm01
    {
        public frmUTLGenerateLotData()
        {
            InitializeComponent();
        }


        private List<clsGenerateLotDataRunner> TR_LIST;

        private void frmUTLGenerateLotData_Load(object sender, EventArgs e)
        {
            TR_LIST = new List<clsGenerateLotDataRunner>();

            MPIF.gInit.IsShowProgressBar = false;

            dtpStart.Value = DateTime.Now.AddDays(-10);
            dtpEnd.Value = DateTime.Now;
        }

        private void frmUTLGenerateLotData_FormClosed(object sender, FormClosedEventArgs e)
        {
            MPIF.gInit.IsShowProgressBar = true;
        }

        private delegate void addLotCallback(ListViewItem itm);
        public void addLot(ListViewItem itm)
        {
            if (this.lisLotList.InvokeRequired)
            {
                addLotCallback d = new addLotCallback(addLot);
                this.Invoke(d, new object[] { itm });
            }
            else
            {
                lisLotList.Items.Add(itm);
                lisLotList.EnsureVisible(lisLotList.Items.Count - 1);
            }
        }

        private delegate void setFinishRunnerCallback();
        public void setFinishRunner()
        {
            if (this.btnProcess.InvokeRequired)
            {
                setFinishRunnerCallback d = new setFinishRunnerCallback(setFinishRunner);
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

        private delegate void setProgressCallback(int i_value);
        public void setProgress(int i_value)
        {
            if (this.prgRunning.InvokeRequired)
            {
                setProgressCallback d = new setProgressCallback(setProgress);
                this.Invoke(d, new object[] { i_value });
            }
            else
            {
                prgRunning.Value = i_value;
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

            btnProcess.Enabled = false;
            btnStop.Enabled = true;
            prgRunning.Enabled = true;
            prgRunning.Visible = true;

            MPCF.InitListView(lisLotList);

            int i;
            int i_thread_count;
            Thread proc;
            clsGenerateLotDataRunner TR;

            for (i = 0; i < TR_LIST.Count; i++)
            {
                TR = TR_LIST[i];
                TR = null;
            }

            TR_LIST.Clear();

            i_thread_count = MPCF.ToInt(txtThreadCount.Text);

            for (i = 0; i < i_thread_count; i++)
            {
                TR = new clsGenerateLotDataRunner();
                TR.setThread(this, i, chkIgnoreError.Checked, dtpStart.Value, dtpEnd.Value);

                TR_LIST.Add(TR);

                proc = new Thread(new ThreadStart(TR.ProcessTest));
                proc.Name = "LotDataGenerator #" + i.ToString();

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


    }
}
