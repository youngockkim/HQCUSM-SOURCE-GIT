using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Miracom.CliFrx;

namespace SOI.OIFrx
{
    public partial class DNMSpread : UserControl
    {
        public DNMSpread()
        {
            InitializeComponent();
        }

        private void ExcelExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ExportExcel(spdData, "", false, "Data");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void customizeColumnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmDNMColumnSetupPopup frm = new frmDNMColumnSetupPopup();
            //frm.model.ViewID = TPDR.MP_VL_INV_LOT_LIST_02;
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();
        }

        private void spdData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ContextMenuStrip = SortcontextMenuStrip;
            }
        }
    }
}
