using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx.SPCBaseForm
{
    public partial class SPCBaseForm02 : SPCBaseForm01
    {
        public SPCBaseForm02()
        {
            InitializeComponent();
        }

        private void SPCBaseForm02_Load(object sender, EventArgs e)
        {
            MPOF.ToClientLanguage(this);
        }
    }
}
