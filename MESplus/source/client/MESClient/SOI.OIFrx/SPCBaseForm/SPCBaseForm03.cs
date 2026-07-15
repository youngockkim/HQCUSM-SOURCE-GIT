using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;

namespace SOI.OIFrx.SPCBaseForm
{
    public partial class SPCBaseForm03 : Form
    {
        public SPCBaseForm03()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                MPOF.ConvertCaption(this);

                if (MPGV.gIBaseFormEvent != null)
                {
                    MPGV.gIBaseFormEvent.Form_Load(this, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
