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
    public partial class TranMessageBox : Form
    {
        public bool isEnd = false;
        private int iMaxCnt = 6;//36초후에 자동 닫힘
        public TranMessageBox()
        {
            InitializeComponent();
            TopMost = true;
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

        private void TranMessageBox_Load(object sender, EventArgs e)
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

            this.Refresh();
        }

        private void TranMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
