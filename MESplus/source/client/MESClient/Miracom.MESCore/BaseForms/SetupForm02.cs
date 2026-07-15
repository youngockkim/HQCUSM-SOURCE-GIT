using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;

namespace Miracom.MESCore
{
    public partial class SetupForm02 : Miracom.MESCore.SetupForm01
    {
        public SetupForm02()
        {
            InitializeComponent();
        }

        [DefaultValue(false)]
        public bool VisibleFilterBox
        {
            get
            {
                return pnlFilter.Visible;
            }
            set
            {
                pnlFilter.Visible = value;
            }
        }

        private void SetupForm02_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == true)
                VisibleFilterBox = false;
        }

        private void rbnNoFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnNoFilter.Checked == true)
            {
                txtFilter.Text = "";
                txtFilter.Enabled = false;
            }
        }

        private void rbnFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnFilter.Checked == true)
            {
                txtFilter.Enabled = true;
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13)
            {
                if (MPCF.Trim(txtFilter.Text) != "")
                {
                    btnFilterView.PerformClick();
                }
            }
        }


    }
}

