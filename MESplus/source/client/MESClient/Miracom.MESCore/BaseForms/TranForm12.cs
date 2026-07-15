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
    public partial class TranForm12 : Miracom.MESCore.TranForm01
    {
        public TranForm12()
        {
            InitializeComponent();
        }

        protected override void OnDeactivate(System.EventArgs e)
        {
            if (btnProcess.Focused == true)
            {
                tabTran.Focus();
            }

            base.OnDeactivate(e);
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.tabTran;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
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
