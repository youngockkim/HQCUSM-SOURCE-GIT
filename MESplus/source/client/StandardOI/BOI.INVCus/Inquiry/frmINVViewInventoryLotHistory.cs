using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using BOI.OIFrx.BOIBaseForm;
using SOI.DNM;

namespace BOI.INVCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVViewInventoryLotHistory : BOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        private enum INV_LOT_COL
        {
            HIST_SEQ = 0,
            TRAN_TIME,
            TRAN_CODE,
            INV_ACCT,
            MAT_ID,
            MAT_DESC,
            OPER_DESC,
            QTY_1,
            CHANGE_QTY,
            UNIT_1,
            FROM_TO_FLAG,
            FROM_TO_LOT_ID,
            INV_CMF_1,
            INV_CMF_2,
            INV_CMF_3,
            INV_CMF_4,
            INV_CMF_5,
            INV_CMF_6,
            INV_CMF_7,
            INV_CMF_8
        }

        #endregion

        #region Constructor

        public frmINVViewInventoryLotHistory()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Load(object sender, EventArgs e)
        {
            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);

            MPCF.ClearList(spdInvLot);

            InvisibleColumn();
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("VIEW_LOT_HIS") == true)
                {
                    ViewLotHis();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void txtInvLotID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //string tempLotId;
            //int indexValue;

            try
            {
                if (e.KeyChar == (char)13)
                {
                    //tempLotId = txtInvLotID.Text.Trim();
                    //indexValue = tempLotId.IndexOf(":");

                    //txtInvLotID.Text = tempLotId.Substring(0, indexValue);
                    //txtUnitQty.Value = MPCF.ToDbl(tempLotId.Substring(indexValue + 1));

                    btnView.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        //View Inventory Lot History
        private bool ViewLotHis()
        {
            try
            {
                MPCF.ClearList(spdInvLot);

                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];
                DataTable dt = null;
                string s_column = "";

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LOT_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(txtInvLotID.Text);

                if (TPDR.GetDataOne(s_column, ref dt, "BINV1001-001", dvcArgu, false, false) == false)
                {
                    if (dt != null)
                        dt.Dispose();

                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdInvLot.Sheets[0].RowCount += 1;
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.HIST_SEQ].Value = dt.Rows[i]["HIST_SEQ"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.TRAN_TIME].Value = dt.Rows[i]["TRAN_TIME"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.TRAN_CODE].Value = dt.Rows[i]["TRAN_CODE"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_ID].Value = dt.Rows[i]["MAT_ID"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.MAT_DESC].Value = dt.Rows[i]["MAT_DESC"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.OPER_DESC].Value = dt.Rows[i]["OPER_DESC"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.QTY_1].Value = dt.Rows[i]["QTY_1"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.CHANGE_QTY].Value = dt.Rows[i]["CHANGE_QTY"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.UNIT_1].Value = dt.Rows[i]["INV_UNIT"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.FROM_TO_FLAG].Value = dt.Rows[i]["FROM_TO_FLAG"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.FROM_TO_LOT_ID].Value = dt.Rows[i]["FROM_TO_LOT_ID"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.INV_CMF_1].Value = dt.Rows[i]["LOT_CMF_1"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.INV_CMF_2].Value = dt.Rows[i]["LOT_CMF_2"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.INV_CMF_3].Value = dt.Rows[i]["LOT_CMF_3"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.INV_CMF_4].Value = dt.Rows[i]["LOT_CMF_4"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.INV_CMF_5].Value = dt.Rows[i]["LOT_CMF_5"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.INV_CMF_6].Value = dt.Rows[i]["LOT_CMF_6"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.INV_CMF_7].Value = dt.Rows[i]["LOT_CMF_7"].ToString();
                    spdInvLot.Sheets[0].Cells[spdInvLot.Sheets[0].RowCount - 1, (int)INV_LOT_COL.INV_CMF_8].Value = dt.Rows[i]["LOT_CMF_8"].ToString();
                }

                MPCF.FitColumnHeader(spdInvLot);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
            return true;
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case "VIEW_LOT_HIS":
                        //INV LOT ID
                        if (MPCF.Trim(txtInvLotID.Text) == "")
                        {
                            MPCF.ShowMessage(MPCF.GetMessage(108), MSG_LEVEL.WARNING, true);
                            txtInvLotID.Focus();
                            return false;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }

            return true;
        }

        private void InvisibleColumn()
        {
            try
            {
                spdInvLot.Sheets[0].Columns[(int)INV_LOT_COL.INV_CMF_3].Visible = false;
                spdInvLot.Sheets[0].Columns[(int)INV_LOT_COL.INV_CMF_4].Visible = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion
    }
}
