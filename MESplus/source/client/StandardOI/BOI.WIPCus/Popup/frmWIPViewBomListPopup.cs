using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOI.OIFrx;
using SOI.DNM;

namespace BOI.WIPCus
{
    public partial class frmWIPViewBomListPopup : SOI.OIFrx.SOIPopup.frmPopupBase
    {
        public frmWIPViewBomListPopup()
        {
            InitializeComponent();
        }

        public string ms_p_mat_id;
        public string ms_mat_bom_type;

        private enum BOM
        {
            MAT_ID,
            MAT_DESC,
            BOM_TYPE,
            QTY,
            UNIT
        }

        private void frmWIPViewBomListPopup_Load(object sender, EventArgs e)
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;

            string s_sql = "";
            int i = 0;

            try
            {
                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "MAT_ID";
                dvcArgu[1].sCondition_Value = ms_p_mat_id;

                dvcArgu[2].sCondtion_ID = "BOM_TYPE";
                dvcArgu[2].sCondition_Value = ms_mat_bom_type;

                if (TPDR.DirectViewOne(spdBOMList, "CWIP2402-001", ref dt, false, false, dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                    {
                        dt.Dispose();
                    }

                    GC.Collect();
                    return;
                }

                for (i = 0; i < spdBOMList_Sheet1.ColumnCount; i++)
                {
                    spdBOMList_Sheet1.Columns[i].Locked = true;
                    spdBOMList_Sheet1.Columns[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                }

                spdBOMList_Sheet1.Columns[(int)BOM.MAT_ID].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                spdBOMList_Sheet1.Columns[(int)BOM.BOM_TYPE].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                spdBOMList_Sheet1.Columns[(int)BOM.QTY].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                spdBOMList_Sheet1.Columns[(int)BOM.UNIT].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            }
            catch (System.Exception ex)
            {
                MPCF.ShowErrorMessage("frmWIPViewBomListPopup_Load()" + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
