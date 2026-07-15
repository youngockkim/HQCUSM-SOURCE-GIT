using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Miracom.CliFrx
{
    public partial class frmExportProgress : Form
    {

        public int Maximum
        {
            get
            {
                return progress.Maximum;
            }
            set
            {
                progress.Maximum = value;
            }
        }

        public int minimum
        {
            get
            {
                return progress.Minimum;
            }
            set
            {
                progress.Minimum = value;
            }
        }

        public String CurrentTitle
        {
            get
            {
                return lblCurrentMessage.Text;
            }
            set
            {
                lblCurrentMessage.Text = value;
            }
        }

        public frmExportProgress()
        {
            InitializeComponent();
        }

        public void Increment(int value)
        {
            progress.Increment(value);            
            this.Refresh();
        }

        private void frmExportProgress_Load(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            
        }        
    }
}