using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.MESCore;

namespace Miracom.RTDCore
{
    public partial class frmRTDViewPreDispatchedHistory : Miracom.MESCore.ViewForm01
    {
        public frmRTDViewPreDispatchedHistory()
        {
            InitializeComponent();
        }

        private void frmRTDViewPreDispatchedHistory_Load(object sender, EventArgs e)
        {
            MPCF.ClearList(spdHistory, true);

            dtpFrom.Value = DateTime.Today.AddDays(-1);
            dtpTo.Value = DateTime.Today;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string sFromTime;
            string sToTime;

            sFromTime = MPCF.FromDate(dtpFrom);
            sToTime = MPCF.ToDate(dtpTo);

            RTDLIST.ViewPreDispatchedHistory(spdHistory, '1', sFromTime, sToTime, txtLot.Text);
            MPCF.FitColumnHeader(spdHistory);
        }
    }
}

