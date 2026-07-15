using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public partial class frmWIPViewFlexibleLotStatus : ViewForm01
    {
        public frmWIPViewFlexibleLotStatus()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "Lot ID : " + MPCF.Trim(txtLotID.Text);
            MPCF.ExportToExcel(udcLotInfor.ScreenSpread, this.Text, sCond);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", txtLotID.Text);

            udcLotInfor.ScreenSpread.Tag = "Change Cell";
            udcLotInfor.ProcStep = '1';
            udcLotInfor.LotID = txtLotID.Text;
            if (udcLotInfor.LoadDesign() == false) return;
            if (udcLotInfor.SetServiceData(in_node) == false) return;
        }
    }
}
