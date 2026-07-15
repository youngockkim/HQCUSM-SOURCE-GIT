using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx;
using Miracom.TRSCore;
using Miracom.MESCore;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using SOI.DNM;
using BOI.OIFrx;

namespace SOI.Solar
{
    public partial class frmCUSViewLotListOfShippingStock : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        #endregion



        #region [Constant Definition]

        private enum LOT_COL : int
        {
            MAT_ID = 0,
            MODEL_NAME,
            PALLET_ID,
            FG_ID,
            STOCK_IN_DATE,
            QTY,
            SHIP_STATUS,
            CONTRACT_NO
        }

        #endregion



        #region [Variable Definition]

        #endregion



        #region [FormDefinition]

        public frmCUSViewLotListOfShippingStock()
        {
            InitializeComponent();
        }

        #endregion



        #region " Control Event Definition "

        #endregion



        #region Event Handler

        private void frmCUSViewLotListOfShippingStock_Load(object sender, EventArgs e)
        {
            try
            {
                dtFrDate.Value = DateTime.Now.AddDays(-7);
                dtToDate.Value = DateTime.Now;

                // Caption 변환
                MPCF.ConvertCaption(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion



        #region [Function Definition]

        private bool View_Lot_List()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                spdLotList_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$FROM_DATE";
                dvcArgu[1].sCondition_Value = MPCF.Trim(this.dtFrDate.GetValueAsString(8));

                dvcArgu[2].sCondtion_ID = "$TO_DATE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(this.dtToDate.GetValueAsString(8));

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_OF_SHIPPING_STOCK", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    // 출고 전
                    if (this.chkShippingUncompleted.Checked)
                    {
                        // 출고여부
                        if (dt.Rows[i]["SHIP_STATUS"].ToString() == " ")
                        {
                            spdLotList_Sheet1.RowCount++;
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.MODEL_NAME].Value = dt.Rows[i]["MODEL_NAME"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.PALLET_ID].Value = dt.Rows[i]["PALLET_ID"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.FG_ID].Value = dt.Rows[i]["FG_ID"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.STOCK_IN_DATE].Value = dt.Rows[i]["STOCK_IN_DATE"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.QTY].Value = dt.Rows[i]["QTY"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.SHIP_STATUS].Value = dt.Rows[i]["SHIP_STATUS"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.CONTRACT_NO].Value = dt.Rows[i]["CONTRACT_NO"].ToString();
                        }
                    }
                    // 출고 후
                    if (this.chkShippingCompleted.Checked)
                    {
                        // 출고여부
                        if (dt.Rows[i]["SHIP_STATUS"].ToString() == "Y")
                        {
                            spdLotList_Sheet1.RowCount++;
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.MODEL_NAME].Value = dt.Rows[i]["MODEL_NAME"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.PALLET_ID].Value = dt.Rows[i]["PALLET_ID"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.FG_ID].Value = dt.Rows[i]["FG_ID"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.STOCK_IN_DATE].Value = dt.Rows[i]["STOCK_IN_DATE"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.QTY].Value = dt.Rows[i]["QTY"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.SHIP_STATUS].Value = dt.Rows[i]["SHIP_STATUS"].ToString();
                            spdLotList_Sheet1.Cells[spdLotList_Sheet1.RowCount - 1, (int)LOT_COL.CONTRACT_NO].Value = dt.Rows[i]["CONTRACT_NO"].ToString();
                        }
                    }
                }

                MPCF.FitColumnHeader(spdLotList);

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        #endregion



        #region " Button Event Definition "

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                View_Lot_List();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion


    }
}
