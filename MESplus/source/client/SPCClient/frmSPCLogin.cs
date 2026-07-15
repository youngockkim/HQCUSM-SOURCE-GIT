using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;

namespace Miracom.SPCClient
{
    public partial class frmSPCLogin : Miracom.MESCore.frmLogInCore
    {
        public frmSPCLogin()
        {
            InitializeComponent();
        }

        #region " Function Implematations"

        protected override void ShowOptionWindow(bool bRestart)
        {

            try
            {
                frmSPCOption f = new frmSPCOption(bRestart);
                if (f.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLogin.ShowOptionWindow()" + "\r\n" + ex.Message);
            }
        }

        #endregion

        private void frmSPCLogin_Load(object sender, System.EventArgs e)
        {

            try
            {
                MPGV.gsDownloadFileList = "DownloadFile_SPC.xml";
                MPGV.gsUpgradeFile = "MESplusUpgradeFtp.exe";
                MPGV.gsServerName = "MESServer";

                MPGV.gsClientVersion = "SPC_V5.3.6.1";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCLogin.frmSPCLogin_Load()" + "\r\n" + ex.Message);
            }

        }

    }
}
