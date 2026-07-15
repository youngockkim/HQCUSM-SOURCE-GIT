using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;
using Miracom.MESCore;
using Miracom.TRSCore;
namespace Miracom.RTDCore
{
    public partial class frmRTDViewDispatchedResourceList : Miracom.MESCore.ViewForm01
    {
        public frmRTDViewDispatchedResourceList()
        {
            InitializeComponent();
        }
        private bool CheckCondition()
        {
            if (MPCF.CheckValue(txtLot, 1) == false)
            {
                return false;
            }
            return true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            RTDLIST.ViewDispatchedResourceList(lisResourceList, '1', txtLot.Text, chkUnselect.Checked, chkUncapable.Checked);
            MPCF.FitColumnHeader(lisResourceList);
        }

        private void frmRTDViewDispatchedResourceList_Load(object sender, EventArgs e)
        {
            MPCF.InitListView(lisResourceList);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            sCond = "";
            if (txtLot.Text != "")
            {
                sCond = sCond + "Lot ID    : " + txtLot.Text + "\r";
            }

            if (MPCF.ExportToExcel(lisResourceList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }
    }
}

