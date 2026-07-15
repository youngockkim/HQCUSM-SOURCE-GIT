using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;
using SOI.DNM;

namespace SOI.Solar
{
    public partial class frmCUSViewMatShipManagement : BOI.OIFrx.BOIBaseForm.BOIBaseForm02
    {
        #region [Property]

        SaveValues saveValues;

        #endregion



        #region [Constant Definition]

        public struct SaveValues
        {
            public string MAT_ID;
            public string ORDER_DATE;
            public string ORDER_ID;
            public string APP_NUM;
            public string ORDER_SEQ;
            public string SHP_REQ_DATE; // 요청일자
            public string SHP_DATE; // 출고일자
            public string SHP_NUM; // BOX_ID
            public string SHP_QTY; // BOX_ID Qty
            public string VC_NUM;
            public string VC_DESC;
            public string ETC_DESC;
            public string CUSTOMER;
            public string CONTRACT_NO;
            public string CONTRACT_SEQ;
            public string SHP_MONEY;
            public string ST_DATE;
            public string DUE_DATE;
            public string SHIP_QTY;
        }

        private enum TAB_CASE
        {
            SHIPMENT,
            PALLET
        }

        private enum SHIP_LIST
        {
            FACTORY,
            ORDER_DATE,
            ORDER_ID,
            APP_NUM,
            IN_OUT_CODE,
            CONTRACT_NO,
            CUSTOMER,
            QTY,
            MAT_ID,
            MAT_SHORT_DESC,
            DLV_LOCATION,
            SHP_REQ_DATE,
            DLV_REQ_DATE,
            RECEIVER,
            RECEIVER_PHONE
        }

        private enum VALIDATION_CASE
        {
            VIEW,
            CHECK
        }

        private enum SHIP_MAT_LIST
        {
            FACTORY,
            CONTRACT_SEQ,
            SHP_REQ_DATE,
            CONTRACT_NO,
            CUSTOMER,
            MAT_ID,
            MAT_DESC,
            MAT_SHORT_DESC,
            SHP_QTY,
            MAT_STATUS,
            ACC_QTY,
            RES_QTY,
            REQUEST_DATE,
            ORDER_ID,
            APP_NUM,
            ORDER_SEQ,
        }

        private enum PALLET_LIST
        {
            PALLET_NO,
            QTY,
            SHIP_ID
        }

        #endregion



        #region [Variable Definition]

        #endregion



        #region [FormDefinition]

        public frmCUSViewMatShipManagement()
        {
            InitializeComponent();
        }

        private void frmCUSViewMatShipManagement_Load(object sender, EventArgs e)
        {
            try
            {
                saveValues = new SaveValues();

                this.dtpFrom.Value = DateTime.Now.AddDays(-1);
                this.dtpTo.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion



        #region [Function Definition]

        private bool ViewShipmentList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdShipList);

            try
            {
                if (chkFinishFlag.Checked)
                {
                    //sViewID = "VIEW_SHIPMENT_LIST_ALL";
                    sViewID = "VIEW_SHIPMENT_LIST_ALL_01";
                }
                else
                {
                    //sViewID = "VIEW_SHIPMENT_LIST";
                    sViewID = "VIEW_SHIPMENT_LIST_01";
                }

                i_cond_cnt = 5;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$FROM_DATE";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.dtpFrom.GetValueAsString(8));

                ArrDVC[2].sCondtion_ID = "$TO_DATE";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.dtpTo.GetValueAsString(8));

                ArrDVC[3].sCondtion_ID = "$MAT_ID";
                ArrDVC[3].sCondition_Value = MPCF.Trim(this.cdvMaterial.Text);

                ArrDVC[4].sCondtion_ID = "$CONTRACT_NO";
                ArrDVC[4].sCondition_Value = MPCF.Trim(this.txtContractNo.Text.Replace("-", ""));

                if (TPDR.DirectViewOne(this.spdShipList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                spdShipList.ActiveSheet.Columns[(int)SHIP_LIST.FACTORY].Visible = false;
                spdShipList.ActiveSheet.Columns[(int)SHIP_LIST.APP_NUM].Visible = false;

                MPCF.FitColumnHeader(spdShipList);

                spdShipList.Sheets[0].ColumnHeader.Cells[0, (int)SHIP_LIST.FACTORY].Text = MPCF.FindLanguage("Shipment Request Information");
                spdShipList.Sheets[0].AddColumnHeaderSpanCell(0, (int)SHIP_LIST.FACTORY, 1, 4);

                spdShipList.Sheets[0].ColumnHeader.Cells[0, (int)SHIP_LIST.IN_OUT_CODE].Text = MPCF.FindLanguage("Contract Information");
                spdShipList.Sheets[0].AddColumnHeaderSpanCell(0, (int)SHIP_LIST.IN_OUT_CODE, 1, 11);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewShipmentMaterialList(VALIDATION_CASE valCase, bool deleteFlag = true)
        {
            int iRow;
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            iRow = spdShipList.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return false;

            try
            {
                sViewID = "VIEW_SHIP_MAT_LIST_01";
                i_cond_cnt = 5;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$ORDER_DATE";
                ArrDVC[1].sCondition_Value = MPCF.Trim(saveValues.ORDER_DATE);

                ArrDVC[2].sCondtion_ID = "$ORDER_ID";
                ArrDVC[2].sCondition_Value = MPCF.Trim(saveValues.ORDER_ID);

                ArrDVC[3].sCondtion_ID = "$APP_NUM";
                ArrDVC[3].sCondition_Value = MPCF.Trim(saveValues.APP_NUM);

                ArrDVC[4].sCondtion_ID = "$CONTRACT_NO";
                ArrDVC[4].sCondition_Value = MPCF.Trim(saveValues.CONTRACT_NO);

                if (valCase == VALIDATION_CASE.VIEW)
                {
                    MPCF.ClearList(this.spdShipMatList);

                    if (TPDR.DirectViewOne(this.spdShipMatList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                    {
                        if (dt != null) { dt.Dispose(); }
                        GC.Collect();
                        return false;
                    }

                    spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.FACTORY].Visible = false;
                    spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.REQUEST_DATE].Visible = false;
                    spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.ORDER_ID].Visible = false;
                    spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.APP_NUM].Visible = false;
                    spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.ORDER_SEQ].Visible = false;

                    MPCF.FitColumnHeader(spdShipMatList);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewShipmentMaterialList_02(VALIDATION_CASE valCase, bool deleteFlag = true)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_SHIP_MAT_LIST_02";
                i_cond_cnt = 5;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$FROM_DATE";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.dtpFrom.GetValueAsString(8));

                ArrDVC[2].sCondtion_ID = "$TO_DATE";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.dtpTo.GetValueAsString(8));

                ArrDVC[3].sCondtion_ID = "$MAT_ID";
                ArrDVC[3].sCondition_Value = MPCF.Trim(this.cdvMaterial.Text);

                ArrDVC[4].sCondtion_ID = "$CONTRACT_NO";
                ArrDVC[4].sCondition_Value = MPCF.Trim(this.txtContractNo.Text.Replace("-", ""));

                if (valCase == VALIDATION_CASE.VIEW)
                {
                    MPCF.ClearList(this.spdShipMatList);

                    if (TPDR.DirectViewOne(this.spdShipMatList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                    {
                        if (dt != null) { dt.Dispose(); }
                        GC.Collect();
                        return false;
                    }

                    spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.FACTORY].Visible = false;
                    spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.REQUEST_DATE].Visible = false;
                    spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.ORDER_ID].Visible = false;
                    spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.APP_NUM].Visible = false;
                    spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.ORDER_SEQ].Visible = false;

                    MPCF.FitColumnHeader(spdShipMatList);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewShipPalletList()
        {
            int iRow;
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            iRow = spdShipMatList.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return false;

            try
            {
                sViewID = "VIEW_SHIP_PALLET_LIST";
                i_cond_cnt = 3;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                
                // 공장
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;
                // 출고 요청일자
                ArrDVC[1].sCondtion_ID = "$SHP_DATE";
                ArrDVC[1].sCondition_Value = MPCF.Trim(spdShipMatList.ActiveSheet.Cells[iRow, (int)SHIP_MAT_LIST.SHP_REQ_DATE].Value.ToString().Replace("-", ""));
                // 계약번호
                ArrDVC[2].sCondtion_ID = "$CONTRACT_NO";
                ArrDVC[2].sCondition_Value = MPCF.Trim(spdShipMatList.ActiveSheet.Cells[iRow, (int)SHIP_MAT_LIST.CONTRACT_NO].Value.ToString().Replace("-", ""));

                if (TPDR.DirectViewOne(this.spdPalletList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                MPCF.FitColumnHeader(spdPalletList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewShipFGLotList()
        {
            int iRow;
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            iRow = spdShipMatList.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return false;

            try
            {
                sViewID = "VIEW_SHIP_FG_LOT_LIST";
                i_cond_cnt = 3;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                
                // 공장
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;
                // 출고 요청일자
                ArrDVC[1].sCondtion_ID = "$SHP_DATE";
                ArrDVC[1].sCondition_Value = MPCF.Trim(spdShipMatList.ActiveSheet.Cells[iRow, (int)SHIP_MAT_LIST.SHP_REQ_DATE].Value.ToString().Replace("-", ""));
                // 계약번호
                ArrDVC[2].sCondtion_ID = "$CONTRACT_NO";
                ArrDVC[2].sCondition_Value = MPCF.Trim(spdShipMatList.ActiveSheet.Cells[iRow, (int)SHIP_MAT_LIST.CONTRACT_NO].Value.ToString().Replace("-", ""));

                if (TPDR.DirectViewOne(this.spdLotList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                MPCF.FitColumnHeader(spdLotList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewShipPalletLot()
        {
            int iRow;
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            iRow = spdPalletList.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return false;

            try
            {
                sViewID = "VIEW_PALLET_LOT";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                
                // 공장
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;
                // Box ID
                ArrDVC[1].sCondtion_ID = "$BOX_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(spdPalletList.ActiveSheet.Cells[iRow, (int)PALLET_LIST.PALLET_NO].Value.ToString());

                if (TPDR.DirectViewOne(this.spdLotList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                MPCF.FitColumnHeader(spdLotList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        #endregion



        #region [Event Definition]

        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_WORK_ORDER_MAT_LIST";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$MAT_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.cdvMaterial.Text);

                string[] header = new string[] { "Material ID", "Material Desc" };
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", sViewID, ArrDVC, display, header, "MAT_ID", -1);

                if (cdvMaterial.returnDatas != null && cdvMaterial.returnDatas.Count > 0)
                {
                    cdvMaterial.Text = cdvMaterial.returnDatas[0];
                    this.txtMaterialDesc.Text = cdvMaterial.returnDatas[1];
                }
                else
                {
                    this.txtMaterialDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.SHIPMENT)
                {
                    MPCF.ClearList(this.spdShipList);
                    MPCF.ClearList(this.spdShipMatList);

                    ViewShipmentList();
                }
                else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.PALLET)
                {
                    MPCF.ClearList(this.spdShipMatList);
                    MPCF.ClearList(this.spdPalletList);
                    MPCF.ClearList(this.pnlBottomMargin);

                    ViewShipmentMaterialList_02(VALIDATION_CASE.VIEW);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdShipList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                saveValues.ORDER_DATE = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.ORDER_DATE].Value.ToString().Replace("-", "");
                saveValues.ORDER_ID = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.ORDER_ID].Value.ToString();
                saveValues.APP_NUM = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.APP_NUM].Value.ToString();
                saveValues.SHP_REQ_DATE = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.SHP_REQ_DATE].Value.ToString().Replace("-", "");
                saveValues.CUSTOMER = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.CUSTOMER].Value.ToString();
                saveValues.CONTRACT_NO = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.CONTRACT_NO].Value.ToString().Replace("-", "");

                utbShipTap.Tabs[(int)TAB_CASE.PALLET].Selected = true;

                ViewShipmentMaterialList(VALIDATION_CASE.VIEW);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdShipMatList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                if (spdShipMatList.ActiveSheet.RowCount > 0)
                {
                    ViewShipPalletList();
                    ViewShipFGLotList();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdPalletList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            try
            {
                if (spdShipMatList.ActiveSheet.RowCount > 0)
                {
                    ViewShipPalletLot();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        #endregion

    }
}
