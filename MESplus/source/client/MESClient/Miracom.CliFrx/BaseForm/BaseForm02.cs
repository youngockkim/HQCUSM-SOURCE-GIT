using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Miracom.CliFrx
{
    public partial class BaseForm02 : Miracom.CliFrx.BaseForm01
    {
        public BaseForm02()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, System.EventArgs e)
        {
            lblFormTitle.Text = this.Text;
        }

        private void BaseForm_Resize(object sender, System.EventArgs e)
        {

            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                if (this.MdiParent != null)
                {
                    pnlTop.Size = new System.Drawing.Size(pnlTop.Size.Width, 22);
                    pnlTop.Visible = true;
                }
                else
                {
                    pnlTop.Size = new System.Drawing.Size(pnlTop.Size.Width, 0);
                    pnlTop.Visible = false;
                }
            }
            else
            {
                pnlTop.Size = new System.Drawing.Size(pnlTop.Size.Width, 0);
                pnlTop.Visible = false;
            }

        }

        private void lblFormTitle_DoubleClick(System.Object sender, System.EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
}

