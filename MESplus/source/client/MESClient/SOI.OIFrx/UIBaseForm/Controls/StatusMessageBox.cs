using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx
{
    public partial class StatusMessageBox : Form
    {
        public bool isEnd = false;
        private int iMaxCnt = 6;//36초후에 자동 닫힘
        public StatusMessageBox()
        {
            InitializeComponent();
            TopMost = true;
        }
        public StatusMessageBox(int iMaxCnt)
        {
            InitializeComponent();
            TopMost = true;
            this.iMaxCnt = iMaxCnt;
        }
        public int iMaxTime
        {
            get { return iMaxCnt; }
            set { iMaxCnt = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sMsg"></param>
        public void SetMessage(string sMsg)
        {
            StatusLabel.Text = sMsg;
        }
        /// <summary>
        /// 
        /// </summary>
        public void ClearMessage()
        {
            StatusLabel.Text = string.Empty;
        }

        private void StatusMessageBox_Load(object sender, EventArgs e)
        {
            tmrWait.Enabled = true;
        }

        private void tmrWait_Tick(object sender, EventArgs e)
        {
            if (isEnd || iMaxCnt == 0)
            {
                this.Hide();
                this.tmrWait.Stop();
            }

            if (pgbWait.Value >= 300)
            {
                pgbWait.Value = 0;
                iMaxCnt--;
            }
            pgbWait.PerformStep();
            this.Refresh();
        }

        private void StatusMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
