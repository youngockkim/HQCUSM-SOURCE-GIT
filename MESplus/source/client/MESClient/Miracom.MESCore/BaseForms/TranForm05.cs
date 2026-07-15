using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Miracom.MESCore
{
    public partial class TranForm05 : Miracom.MESCore.TranForm04
    {
        public TranForm05()
        {
            InitializeComponent();
        }

        private void cdvCMF_ButtonPress(System.Object sender, System.EventArgs e)
        {
            MPCR.ProcGRPCMFButtonPress(sender);
        }

        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MPCR.CheckCMFKeyPress(sender, e);
        }

        protected void SetCMFItem(string s_item_name)
        {
            MPCR.SetCMFItem(s_item_name, "lblCMF", "cdvCMF", grpCMF);
        }

        protected bool CheckCMFItemValue()
        {
            return MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF);
        }
    }
}

