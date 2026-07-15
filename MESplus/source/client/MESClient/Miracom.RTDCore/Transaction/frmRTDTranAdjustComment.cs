using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;

namespace Miracom.RTDCore
{
    public partial class frmRTDTranAdjustComment : Form
    {
        public frmRTDTranAdjustComment()
        {
            InitializeComponent();
        }

        private void frmRTDTranAdjustComment_Load(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }
        }
    }
}