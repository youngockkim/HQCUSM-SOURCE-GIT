using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;

namespace Miracom.ALMCore
{
    public partial class frmALMPublishMessageSub : Form
    {
        public frmALMPublishMessageSub()
        {
            InitializeComponent();
        }

        public void SetImage(MemoryStream ms_buffer)
        {
            picImage.Image = Image.FromStream(ms_buffer);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmALMPublishMessageSub_Load(object sender, EventArgs e)
        {
            if (MPGV.gIBaseFormEvent != null)
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
            }
        }
    }
}
