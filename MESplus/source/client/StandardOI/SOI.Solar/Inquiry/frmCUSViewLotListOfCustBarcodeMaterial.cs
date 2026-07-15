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
    public partial class frmCUSViewLotListOfCustBarcodeMaterial : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        const int ENTER = 13;

        #endregion



        #region [Constant Definition]

        private enum LOT_COL : int
        {
            BOX_ID,
            FG_ID,
            OPER,
            LOT_ID,
            CUST_BARCODE,
            MAT_ID
        }

        #endregion



        #region [Variable Definition]

        #endregion



        #region [FormDefinition]

        public frmCUSViewLotListOfCustBarcodeMaterial()
        {
            InitializeComponent();
        }

        private void frmCUSViewLotListOfCustBarcodeMaterial_Load(object sender, EventArgs e)
        {
            try
            {
                txtCustBarcode.Focus();
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
                    txtCustBarcode.Text = string.Empty;
                    MPCF.ClearList(spdLotList);

                    txtCustBarcode.Focus();
                    txtCustBarcode.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private bool View_Lot_List_Of_Cust_Barcode_Material()
        {
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
            DataTable dt = null;
            string s_sql = "";

            int i = 0;

            try
            {
                spdLotList_Sheet1.RowCount = 0;

                dvcArgu[0].sCondtion_ID = "$FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "$CUST_BARCODE";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtCustBarcode.Text);

                if (TPDR.GetDataOne("", ref dt, "VIEW_LOT_OF_CUST_BARCODE", dvcArgu, false, false, ref s_sql) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    spdLotList_Sheet1.RowCount++;
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.BOX_ID].Value = dt.Rows[i]["BOX_ID"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.FG_ID].Value = dt.Rows[i]["FG_ID"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.OPER].Value = dt.Rows[i]["OPER"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.LOT_ID].Value = dt.Rows[i]["LOT_ID"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.CUST_BARCODE].Value = dt.Rows[i]["CUST_BARCODE"].ToString();
                    spdLotList_Sheet1.Cells[i, (int)LOT_COL.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                }

                MPCF.FitColumnHeader(spdLotList);

                MPCF.SetFocusAndSelectAll(txtCustBarcode);
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private bool CheckCondition(string FuncName)
        {
            switch (MPCF.Trim(FuncName))
            {
                case "VIEW":

                    if (txtCustBarcode.Text == string.Empty && txtCustBarcode.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        MPCF.SetFocusAndSelectAll(txtCustBarcode);
                        return false;
                    }

                    break;

            }

            return true;
        }
        #endregion



        #region [Event Definition]

        private void txtCustBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    btnView.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }

                txtCustBarcode.Text = MPCF.ToUpper(txtCustBarcode.Text); // 일괄 대문자
                View_Lot_List_Of_Cust_Barcode_Material();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (spdLotList.ActiveSheet.RowCount < 1)
                {
                    return;
                }

                string sCond = string.Empty;

                if (MPCF.ExportToExcel(spdLotList, this.Text, sCond, true, true, true, -1, -1) == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

    }
}
