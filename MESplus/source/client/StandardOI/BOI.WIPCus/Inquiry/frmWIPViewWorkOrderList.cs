using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOI.CliFrx;
using SOI.DNM;
using SOI.OIFrx;
using BOI.OIFrx;
using Miracom.TRSCore;

namespace BOI.WIPCus
{
    public partial class frmWIPViewWorkOrderList : SOI.OIFrx.SOIPopup.frmPopupBase
    {
        public frmWIPViewWorkOrderList()
        {
            InitializeComponent();
        }

        public enum ORD
        {
            ORDER_DATE,
            ORDER_ID,
            MAT_ID,
            MAT_DESC,
            BOM_TYPE,
            ORDER_QTY,
            RLT_QTY,
            UNIT,
            LINE_ID,
            RES_ID,
            STATUS,
            BOX_QTY
        }

        public FarPoint.Win.Spread.SheetView mspdWorkOrder;
        public string s_mold_pack_flag = "N";
        public bool b_show_reset_buttom = false;

        /// <summary>
        /// 작업지시 조회
        /// </summary>
        /// <returns></returns>
        private bool View_Work_Order()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[7];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                spdWorkOrder_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "FR_DATE";
                dvcArgu[1].sCondition_Value = dtFrDate.GetValueAsDateTime().ToString("yyyyMMdd");

                dvcArgu[2].sCondtion_ID = "TO_DATE";
                dvcArgu[2].sCondition_Value = dtToDate.GetValueAsDateTime().ToString("yyyyMMdd");

                dvcArgu[3].sCondtion_ID = "LINE_ID";
                dvcArgu[3].sCondition_Value = MPCF.Trim(cdvLine.Tag);

                dvcArgu[4].sCondtion_ID = "RES_ID";
                dvcArgu[4].sCondition_Value = MPCF.Trim(cdvResource.Tag);

                dvcArgu[5].sCondtion_ID = "ORDER_STATUS";
                dvcArgu[5].sCondition_Value = MPCF.Trim(rbStatus.Items[rbStatus.CheckedIndex].DataValue) == "A" ? "" : MPCF.Trim(rbStatus.Items[rbStatus.CheckedIndex].DataValue);

                dvcArgu[6].sCondtion_ID = "MAT_ID";
                dvcArgu[6].sCondition_Value = "";

                if (TPDR.GetDataOne("", ref dt, "COM0000-005", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdWorkOrder_Sheet1.RowCount++;

                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.ORDER_DATE].Value = MPCF.MakeDateFormat(dt.Rows[i]["ORD_DATE"].ToString(), DATE_TIME_FORMAT.DATE);
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.ORDER_ID].Value = dt.Rows[i]["ORDER_ID"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.BOM_TYPE].Value = dt.Rows[i]["MAT_BOM_TYPE"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.ORDER_QTY].Value = dt.Rows[i]["ORD_QTY"];
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.RLT_QTY].Value = dt.Rows[i]["PROD_QTY"];
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.UNIT].Value = dt.Rows[i]["UNIT_1"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.LINE_ID].Tag = dt.Rows[i]["LINE_ID"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.LINE_ID].Value = dt.Rows[i]["LINE_DESC"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.RES_ID].Tag = dt.Rows[i]["RES_ID"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.RES_ID].Value = dt.Rows[i]["RES_DESC"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.STATUS].Value = dt.Rows[i]["ORDER_STATUS_DESC"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.STATUS].Tag = dt.Rows[i]["ORDER_STATUS"].ToString();
                    spdWorkOrder_Sheet1.Cells[i, (int)ORD.BOX_QTY].Value = dt.Rows[i]["PACK_LOT_COUNT"];
                }
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void cdvLineGroup_CodeViewButtonClick(object sender, EventArgs e)
        {
            BICF.ViewLineGroup(cdvLineGroup);
        }

        private void cdvLine_CodeViewButtonClick(object sender, EventArgs e)
        {
            BICF.ViewLine(cdvLine, MPCF.Trim(cdvLineGroup.Tag));
        }

        /// <summary>
        /// 설비 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cdvResource_CodeViewButtonClick(object sender, EventArgs e)
        {
            BICF.ViewResource(cdvResource, MPCF.Trim(cdvLineGroup.Tag), MPCF.Trim(cdvLine.Tag), "", s_mold_pack_flag);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View_Work_Order();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (spdWorkOrder_Sheet1.RowCount == 0)
            {
                MPCF.ShowMessage(MPCF.GetMessage(401), MSG_LEVEL.ERROR, false);
                return;
            }

            mspdWorkOrder = spdWorkOrder_Sheet1.Clone();

            DialogResult = DialogResult.OK;
        }

        private void frmWIPViewWorkOrderList_Load(object sender, EventArgs e)
        {
            dtFrDate.Value = DateTime.Now.AddDays(-7);
            dtToDate.Value = DateTime.Now.AddDays(7);

            btnFieldsReset.Visible = b_show_reset_buttom;
        }

        private void btnFieldsReset_Click(object sender, EventArgs e)
        {
            mspdWorkOrder = null;
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}
