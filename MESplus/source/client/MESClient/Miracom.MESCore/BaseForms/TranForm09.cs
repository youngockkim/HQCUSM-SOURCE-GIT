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
    public partial class TranForm09 : Miracom.MESCore.TranForm02
    {
        public TranForm09()
        {
            InitializeComponent();
        }

        private void TranForm09_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == true)
                pnlTranTime.Visible = true;
            else
                pnlTranTime.Visible = MPGO.UseBackDate();

            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
        }

        private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            txtTranDateTime.Visible = !chkTranDateTime.Checked;

            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;

            txtTranDateTime.TabStop = !chkTranDateTime.Checked;
            dtpTranDate.TabStop = chkTranDateTime.Checked;
            dtpTranTime.TabStop = chkTranDateTime.Checked;
        }

        protected override void OnDeactivate(System.EventArgs e)
        {
            if (btnProcess.Focused == true)
            {
                cdvMatID.Focus();
                cdvMatID.SelectionStart = cdvMatID.Text.Length;
            }

            base.OnDeactivate(e);
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.cdvMatID;

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

