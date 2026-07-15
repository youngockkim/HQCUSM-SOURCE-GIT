using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections;
using Miracom.MESCore;
using Miracom.CliFrx;

namespace SOI.OIFrx
{
    public partial class frmFileDownPopup : Form
    {
        public frmFileDownPopup()
        {
            InitializeComponent();
        }

        public frmFileDownPopup(string sUrl)
        {
            InitializeComponent();
            sURL = sUrl;
        }

        #region " Constant Definition "
        string sURL = string.Empty;
        #endregion

        #region " Variable Definition "
        
        #endregion


        #region " Event Function Definition "
        private void frmFileDownPopup_Load(object sender, EventArgs e)
        {
            wbFileDown.Navigate(sURL);
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
