using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Miracom.MESCore
{
    public partial class TranForm94 : Miracom.MESCore.TranForm03
    {
        public TranForm94()
        {
            InitializeComponent();
        }

        private void TranForm94_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == true)
                pnlTranTime.Visible = true;
            else
                pnlTranTime.Visible = MPGO.UseBackDate();
        }
    }
}

