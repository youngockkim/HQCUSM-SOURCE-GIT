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
    public partial class frmRTDViewDispatcherEventHistory : Miracom.MESCore.ViewForm01
    {
        public frmRTDViewDispatcherEventHistory()
        {
            InitializeComponent();
        }

 
        private void frmRTDViewDispatcherEventHistory_Load(object sender, EventArgs e)
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

            RTDLIST.ViewDispatcherEventHistory(spdHistory, '1', sFromTime, sToTime, txtLot.Text, cdvResource.Text);
            MPCF.FitColumnHeader(spdHistory);
        }

        private void cdvResource_ButtonPress(object sender, EventArgs e)
        {
            cdvResource.Init();
            MPCF.InitListView(cdvResource.GetListView);
            cdvResource.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvResource.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResource.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResource.GetListView, false);

        }

        private void cdvResource_TextBoxTextChanged(object sender, EventArgs e)
        {
            MPCF.ClearList(spdHistory);
        }

        private void txtLot_TextChanged(object sender, EventArgs e)
        {
            MPCF.ClearList(spdHistory);
        }
    }
}

