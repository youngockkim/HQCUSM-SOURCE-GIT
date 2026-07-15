using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;

namespace SOI.OIFrx
{
    public partial class UIBaseForm11 : Form
    {
        public UIBaseForm11()
        {
            InitializeComponent();
        }

        private void UIBaseForm11_Load(object sender, EventArgs e)
        {
            MOGV.gsQueryStatementLong = "";
            MOGV.gsQueryStatementLong = "[ " + this.Name + " ]\r";

            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }

            //this.Text = MPCF.FindLanguage(this.Text, 1);
        }

        private void UIBaseForm11_Activated(object sender, System.EventArgs e)
        {

            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Activated(this, e);
            }

        }

        private void UIBaseForm11_Closed(object sender, FormClosedEventArgs e)
        {
            MOGV.gsQueryStatementLong = "";

            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Closed(this, e);
            }

            if (this.MdiParent == null)
            {

            }
            else
            {
                if (this.MdiParent.IsMdiContainer == true)
                {
                    this.Dispose();
                }
            }

            MPCF.FlushMemory();
        }
    }
}
