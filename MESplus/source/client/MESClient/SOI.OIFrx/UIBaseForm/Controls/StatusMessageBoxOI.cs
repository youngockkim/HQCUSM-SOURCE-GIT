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
    public partial class StatusMessageBoxOI : Form
    {
        public bool isEnd = false;
        private int iWait = 0;
        private int iMaxCnt = 3;
        public StatusMessageBoxOI()
        {
            InitializeComponent();
            TopMost = true;
        }
        public StatusMessageBoxOI(int iMaxCnt)
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
        /// <summary>
        /// 
        /// </summary>
        public void ScreenPosition()
        {
            int ScreenHeight = 0;
            System.Windows.Forms.Screen[] screens = System.Windows.Forms.Screen.AllScreens;

            if (screens.Length > 1)
            {
                foreach (Screen screen in screens)
                {
                    if (screen.Primary)
                    {
                        ScreenHeight = screen.Bounds.Height;
                    }
                }
            }
            else
            {
                ScreenHeight = screens[0].Bounds.Height;
            }

            //this.Height = ScreenHeight - 60;
            this.StartPosition = FormStartPosition.CenterParent;
            //this.Location‍ = new Point(200, 0);
        }

        private void StatusMessageBoxOI_Load(object sender, EventArgs e)
        {
            tmrWait.Enabled = true;
            //ScreenPosition();
        }

        private void tmrWait_Tick(object sender, EventArgs e)
        {
            if (isEnd || iMaxCnt == 0)
            {
                this.Hide();
                this.tmrWait.Stop();
            }

            if (iWait >= 100)
            {
                iWait = 0;
                iMaxCnt--;
            }
            else
            {
                iWait += 10;
            }
            //this.Refresh();
        }

        private void StatusMessageBoxOI_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
