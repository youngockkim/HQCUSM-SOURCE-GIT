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

namespace SOI.Solar
{
    public partial class frmCUSViewIVTest : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        #endregion



        #region [Constant Definition]

        private enum LOT_COL : int
        {
            TRAN_TIME,
            LOT_ID,
            FG_ID,
            JUDGMENT,
            TMEAS,
            FF,
            IPM,
            VPM,
            PMAX,
            RSH,
            RS,
            VOC,
            ISC
        }

        #endregion



        #region [Variable Definition]

        #endregion



        #region [FormDefinition]

        public frmCUSViewIVTest()
        {
            InitializeComponent();
        }

        private void frmCUSViewIVTest_Load(object sender, EventArgs e)
        {
            try
            {
                dtFrDate.Value = DateTime.Today;

                txtLotID.Focus();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion



        #region [Function Definition]

        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    txtLotID.Text = string.Empty;
                    MPCF.ClearList(spdLotList);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private bool View_Lot_List()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                spdLotList_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;
                
                dvcArgu[1].sCondtion_ID = "$LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtLotID.Text);

                dvcArgu[2].sCondtion_ID = "$FROM_DATE";
                dvcArgu[2].sCondition_Value = MPCF.Trim(this.dtFrDate.GetValueAsString(8) + "080000");

                dvcArgu[3].sCondtion_ID = "$TO_DATE";
                dvcArgu[3].sCondition_Value = DateTime.Parse(dtFrDate.Value.ToString()).AddDays(1).ToString("yyyyMMdd") + "080000";

                if (TPDR.GetDataOne("", ref dt, "VIEW_IV_TEST_BY_REAR_EL_TEST", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdLotList_Sheet1.RowCount++;
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.TRAN_TIME].Value = dt.Rows[i]["TEST_TIME"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.FG_ID].Value = dt.Rows[i]["FG_ID"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.JUDGMENT].Value = dt.Rows[i]["JUDGMENT"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.TMEAS].Value = dt.Rows[i]["TMEAS"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.FF].Value = dt.Rows[i]["FF"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.IPM].Value = dt.Rows[i]["IPM"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.VPM].Value = dt.Rows[i]["VPM"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.PMAX].Value = dt.Rows[i]["PMAX"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.RSH].Value = dt.Rows[i]["RSH"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.RS].Value = dt.Rows[i]["RS"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.VOC].Value = dt.Rows[i]["VOC"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.ISC].Value = dt.Rows[i]["ISC"].ToString();
                }

                MPCF.FitColumnHeader(spdLotList);

                txtLotID.Focus();
                txtLotID.SelectAll();
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        #endregion



        #region [Event Definition]

        private void btnView_Click(object sender, EventArgs e)
        {
            View_Lot_List();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (chkAutoView.Checked == true)
                {
                    View_Lot_List();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ExcelExportToFile(spdLotList);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

    }
}
