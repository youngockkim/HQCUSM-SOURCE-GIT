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
    public partial class TranForm03 : Miracom.MESCore.TranForm02
    {
        public TranForm03()
        {
            InitializeComponent();
        }
    
        protected override void OnDeactivate(System.EventArgs e)
        {

            if (btnProcess.Focused == true)
            {
                txtLotID.Focus();
                txtLotID.SelectionStart = txtLotID.TextLength;
            }

            base.OnDeactivate(e);

        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.txtLotID;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }
    }
}

