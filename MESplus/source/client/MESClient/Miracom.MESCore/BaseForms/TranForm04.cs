using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Miracom.MESCore
{
    public partial class TranForm04 : Miracom.MESCore.TranForm03
    {
        public TranForm04()
        {
            InitializeComponent();
        }

        private void TranForm04_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == true)
                pnlTranTime.Visible = true;
            else
                pnlTranTime.Visible = MPGO.UseBackDate();

            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
        }

        private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            txtTranDateTime.Visible = !chkTranDateTime.Checked;
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;

            txtTranDateTime.TabStop = !chkTranDateTime.Checked;
            dtpTranDate.TabStop = chkTranDateTime.Checked;
            dtpTranTime.TabStop = chkTranDateTime.Checked;
        }
    }
}

