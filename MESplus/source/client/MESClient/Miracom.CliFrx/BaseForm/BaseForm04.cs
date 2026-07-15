using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Miracom.CliFrx
{
    public partial class BaseForm04 : Miracom.CliFrx.BaseForm03
    {
        public BaseForm04()
        {
            InitializeComponent();
        }

        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}

