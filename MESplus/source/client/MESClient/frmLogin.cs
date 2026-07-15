using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.CliFrx;

namespace MESClient
{
    public partial class frmLogin : Miracom.MESCore.frmLogInCore
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, System.EventArgs e)
        {
            MPGV.gsHelpURL = "http://localhost/MESHelp/";
            MPGV.gsDefaultHelpURL = "Manual_1";
            MPGV.gsDownloadFileList = "DownloadFile.xml";
            MPGV.gsUpgradeFile = "MESplusUpgradeFtp.exe";

            MPGV.gsClientVersion = "MES_V5.3.6.22";
        }

    }
}