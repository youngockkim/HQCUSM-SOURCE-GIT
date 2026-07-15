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
    public partial class frmCUSTranMatShipManagement : SOIBaseForm03
    {
        #region [Property]

        private bool bIsShown = false;
        const int ROW = 100;
        const int ENTER = 13;

        const string PALLET = "Pallet ID";
        const string FG_ID = "FG ID";
        const string LOT = "Lot ID";
        const string CREATE_DATE = "Create Date";
        const string ORDER_ID = "Order ID";
        const string APP_NUM = "App Num"; 
        const string ORDER_SEQ = "Order Seq";
        const string MAT_ID = "Mat ID";
        const string STATUS = "Status";
        const string MAT_VER = "Mat Ver";

        SaveValues saveValues;
        SaveCarryValues saveCarryValues;
        ModulePrintValues modulePrintValues;
        DataTable modulePrintDetailValues;
        DataTable productPrintDetailValues;

        #endregion

        public frmCUSTranMatShipManagement()
        {
            InitializeComponent();
        }
        
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
            public string REQ_QTY;
            public string ACCRUE_QTY;
            public string RESIDUAL_QTY;
        }

        public struct SaveCarryValues
        {
            public string FACTORY; 
            public string SHIP_ID;
            public string ORDER_DATE;
            public string SHP_DATE;
            public string CONTRACT_NO;
            public string CUSTOMER_ID;
            public string SHIP_MONEY;
            public string VC_DESC;
            public string VC_NUM;
            public string ST_DATE;
            public string DUE_DATE;
            public string ETC_DESC;
            public string CUSTOMER_DESC;
        }

        public struct ModulePrintValues
        {
            public string FACTORY;
            public string DLV_LOCATION;
            public string RECEIVER;
            public string RECEIVER_PHONE;
            public string MAT_ID;
            public string MAT_DESC;
            public string UNIT;
            public string CNT;
            public string WP;
            public string MAT_SHORT_DESC;
        }

        private enum MODULE_PRINT_MASTER
        {
            FACTORY,
            DLV_LOCATION,
            RECEIVER,
            RECEIVER_PHONE
        }

        private enum MODULE_PRINT_DETAIL
        {
            MAT_ID,
            MAT_DESC,
            UNIT,
            CNT,
            WP,
            MAT_SHORT_DESC
        }

        private enum PRODUCT_PRINT_DETAIL
        {
            SEQ,
            SERIAL_NUMBER,
            VOC,
            ISC,
            PMAX,
            VMP,
            IMP,
            NOTE
        }

        private enum SHIP_LIST
        {
            FACTORY,
            ORDER_DATE,
            ORDER_ID,
            IN_OUT_CODE,
            CONTRACT_NO,
            CUSTOMER,
            MAT_ID,
            MAT_SHORT_DESC,
            REQ_QTY,
            ACCRUE_QTY,
            RESIDUAL_QTY,
            DLV_LOCATION,
            SHP_REQ_DATE,
            DLV_REQ_DATE,
            RECEIVER,
            RECEIVER_PHONE,
            SHIP_STATUS
        }

        private enum PALLET_LIST
        {
            CHECKBOX,
            PALLET_NO,
            CREATE_DATE,
            ORDER_ID,
            APP_NUM,
            ORDER_SEQ,
            MAT_ID,
            STATUS
        }

        private enum NO_PALLET_LIST
        {
            CHECKBOX,
            FG_ID,
            LOT_ID,
            CREATE_DATE,
            ORDER_ID,
            APP_NUM,
            ORDER_SEQ,
            MAT_ID,
            STATUS
        }

        private enum LOT_LIST
        {
            PALLET_NO,
            LOT_ID,
            FG_ID,
            MAT_ID,
            MAT_VER
        }

        private enum NO_LOT_LIST
        {
            LOT_ID,
            FG_ID,
            MAT_ID,
            MAT_VER,
            CNT
        }

        private enum SHIP_MAT_LIST
        {
            FACTORY,
            ORDER_SEQ,
            CONTRACT_SEQ,
            SHP_REQ_DATE,
            CONTRACT_NO,
            CUSTOMER,
            MAT_ID,
            MAT_DESC,
            MAT_SHORT_DESC,
            REQ_QTY,
            MAT_STATUS,
            ACCRUE_QTY,
            RESIDUAL_QTY,
            REQUEST_DATE,
            ORDER_ID
        }

        private enum TARGET_MAT_LIST
        {
            CHECKBOX,
            FACTORY,
            SHIP_ID,
            ORDER_DATE,
            SHP_DATE,
            CONTRACT_NO,
            CUSTOMER_ID,
            SHIP_MONEY,
            VC_DESC,
            VC_NUM,
            ST_DATE,
            DUE_DATE,
            ETC_DESC,
            STATUS
        }

        private enum SCAN_LIST
        {
            CONTRACT_NO,
            SCAN_ID
        }

        private enum TAB_CASE
        {
            SHIPMENT,
            PALLET,
            CARRY,
            SCAN
        }

        private enum VALIDATION_CASE
        {
            VIEW,
            CHECK
        }

        #endregion

        #region [Variable Definition]

        #endregion

        #region [FormDefinition]

        private void initCtrl()
        {
            try
            {
                saveValues = new SaveValues();

                MPCF.ConvertCaption(this);
                MPCF.FieldClear(this);
                SetPrintVisible(false);
                this.dtpFrom.Value = DateTime.Now.AddDays(-1);
                this.dtpTo.Value = DateTime.Now;
                SetShipSpreadLabel();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        #region [Function Definition]

        private void SetShipSpreadLabel()
        {
            //ORDER_DATE, ORDER_ID는 MESCaption을 사용하지 않음 -> ORDER_ID는 작업 지시로 번역됨
            spdShipList.ActiveSheet.Columns[(int)SHIP_LIST.ORDER_DATE].Label = "의뢰일자";
            spdShipList.ActiveSheet.Columns[(int)SHIP_LIST.ORDER_ID].Label = "일련번호";
        }

        private void Initialize()
        {
            InitShip();
            InitPallet();
            InitCarry();

            saveValues = new SaveValues();

            this.dtpStDate.Value = DateTime.Now;
            this.dtpDueDate.Value = DateTime.Now.AddDays(1);
        }

        private void InitShip()
        {
            MPCF.ClearList(this.spdShipList);
            MPCF.ClearList(this.spdShipMatList);
        }

        private void InitPallet()
        {
            MPCF.ClearList(this.spdPalletList);
            MPCF.ClearList(this.spdLotList);

            InitPalletDetail();
        }

        private void InitPalletDetail()
        {
            txtPalletID.Text = string.Empty;
            txtCurMatID.Text = string.Empty;
            txtScanCount.Text = string.Empty;
            txtTotalCount.Text = string.Empty;
            txtAccrueCount.Text = string.Empty;
        }

        private void InitCarry()
        {
            MPCF.ClearList(this.spdTargetMatList);

            cdvCustomer.Text = string.Empty;
            txtCustomerDesc.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtCarInfo.Text = string.Empty;
            txtCarNum.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        private void InitScan()
        {
            MPCF.ClearList(this.spdScanList);

            txtScanOnlyContractNo.Text = string.Empty;
            txtScanOnlyID.Text = string.Empty;
            txtScanOnlyQty.Text = string.Empty;
        }

        private bool CheckCondition(string FuncName, int Case = 0)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_VIEW:

                        if (Case.Equals(0))
                        {
                            DateTime dtpFromOut = new DateTime();

                            if (dtpFrom.Value != null)
                            {
                                if (DateTime.TryParse(dtpFrom.Value.ToString(), out dtpFromOut)) { }
                            }

                            DateTime dtpToOut = new DateTime();

                            if (dtpTo.Value != null)
                            {
                                if (DateTime.TryParse(dtpTo.Value.ToString(), out dtpToOut)) { }
                            }

                            if (this.dtpFrom.GetValueAsDateTime() > this.dtpTo.GetValueAsDateTime())
                            {
                                this.dtpFrom.SetValueAsDateTime(dtpToOut.AddDays(-1));
                                MPCF.ShowMsgBox(MPCF.GetMessage(371));
                            }
                        }
                        else if (Case.Equals(1))
                        {
                            if (spdTargetMatList.ActiveSheet.SelectionCount < 1)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(389));
                                return false;
                            }

                            if (spdTargetMatList.ActiveSheet.Cells[spdTargetMatList.ActiveSheet.ActiveRowIndex, (int)TARGET_MAT_LIST.ST_DATE].Value.ToString() == " ")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                return false;
                            }

                            if (!CheckSaveCarry())
                                return false;

                            if(!GetTransportationInfo()) //MODULE_PRINT MASTER INFO
                                return false;

                            if (!GetShipmentDetailInfo()) //MODULE_PRINT DETAIL INFO
                                return false;
                        }
                        else if (Case.Equals(2))
                        {
                            if (spdTargetMatList.ActiveSheet.SelectionCount < 1)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(389));
                                return false;
                            }

                            if (spdTargetMatList.ActiveSheet.Cells[spdTargetMatList.ActiveSheet.ActiveRowIndex, (int)TARGET_MAT_LIST.ST_DATE].Value.ToString() == " ")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                                return false;
                            }

                            if (!CheckSaveCarry())
                                return false;

                            if (!GetTransportationInfo()) //MODULE_PRINT MASTER INFO
                                return false;

                            if (!GetShipmentDetailInfo()) //MODULE_PRINT DETAIL INFO
                                return false;

                            if (!GetProductDetailInfo()) //PRODUCT_PRINT DETAIL INFO
                                return false;
                        }

                        break;

                    case CSGC.MP_CHECK_CREATE:

                        if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.PALLET)
                        {
                            if (chkInputType.Checked) //팔레트 구성일때만 체크
                            {
                                if (spdLotList.ActiveSheet.RowCount == 0)
                                    return false;

                                if (!CheckShipmentExist(VALIDATION_CASE.CHECK)) //출고여부
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(399));
                                    return false;
                                }
                            }
                            else //LOT 아이디 스캔시 팔레트가 구성되거나 LOT 존재여부가 바뀔 수도 있어서 최종 저장시 다시 체크
                            {
                                if (!CheckCreateBoxExist(VALIDATION_CASE.CHECK))//CWIPBOXLOT 팔레트 구성여부 확인
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(414));
                                    return false;
                                }
                            }
                        }
                        else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.CARRY)
                        {
                            DateTime dtpDueOut = new DateTime();

                            if (dtpDueDate.Value != null)
                            {
                                if (DateTime.TryParse(dtpDueDate.Value.ToString(), out dtpDueOut)) { }
                            }

                            if (this.dtpStDate.GetValueAsDateTime() > this.dtpDueDate.GetValueAsDateTime()) //일
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(371));
                                return false;
                            }

                            if (!CheckSaveCarry())
                                return false;
                        }
                        else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.SCAN)
                        {
                            if (spdScanList.ActiveSheet.RowCount < 1)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(122));
                                return false;
                            }
                        }

                        break;

                    case CSGC.MP_CHECK_UPDATE:

                        if (saveValues.MAT_ID == null || saveValues.MAT_ID == string.Empty)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(389));
                            return false;
                        }

                        if (!CheckDuplication()) //중복여부
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(390));
                            return false;
                        }

                        if (!CheckSaveExist()) //출하처리 이전 저장여부
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(391));
                            return false;
                        }

                        if (chkInputType.Checked) //팔레트 구성일때만 체크
                        {
                            if (!CheckShipmentExist(VALIDATION_CASE.VIEW)) //출고여부
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(399));
                                return false;
                            }

                            if (!CheckSaveLotExist()) //출하처리 이전 저장여부 팔레트 내의 Lot으로 재조회
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(391));
                                return false;
                            }
                        }
                        else //LOT 구성일때만 체크
                        {
                            if (!CheckShipLotExist()) //MWIPLOTSTS 존재여부 확인
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(154));
                                return false;
                            }

                            //if (!CheckCreateBoxExist(VALIDATION_CASE.VIEW))//CWIPBOXLOT 팔레트 구성여부 확인
                            //{
                            //    MPCF.ShowMsgBox(MPCF.GetMessage(414));
                            //    return false;
                            //}
                        }

                        break;

                    case CSGC.MP_CHECK_DELETE:

                        if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.PALLET)
                        {
                            if (spdPalletList.ActiveSheet.RowCount == 0)
                                return false;
                        }
                        else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.CARRY)
                        {
                            if (spdTargetMatList.ActiveSheet.RowCount == 0)
                                return false;
                        }
                        else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.SCAN)
                        {
                            if (spdScanList.ActiveSheet.RowCount == 0)
                                return false;
                        }

                        break;

                    default:
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckSaveCarry()
        {
            if (string.IsNullOrEmpty(MPCF.Trim(cdvCustomer.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(cdvCustomer);
                return false;
            }
                
            if(string.IsNullOrEmpty(MPCF.Trim(txtAmount.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(txtAmount);
                return false;
            }
            
            if(string.IsNullOrEmpty(MPCF.Trim(txtCarInfo.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(txtCarInfo);
                return false;
            }
            
            if(string.IsNullOrEmpty(MPCF.Trim(txtCarNum.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(txtCarNum);
                return false;
            }
            
            if(string.IsNullOrEmpty(MPCF.Trim(cbxStHour.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(cbxStHour);
                return false;
            }
            
            if(string.IsNullOrEmpty(MPCF.Trim(cbxStMin.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(cbxStMin);
                return false;
            }
            
            if(string.IsNullOrEmpty(MPCF.Trim(cbxDueHour.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(cbxDueHour);
                return false;
            }
            
            if(string.IsNullOrEmpty(MPCF.Trim(cbxDueMin.Text)))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(107));
                MPCF.SetFocus(cbxDueMin);
                return false;
            }

            return true;
        }

        private bool CheckDuplication()
        {
            for (int i = 0; i < spdPalletList.ActiveSheet.RowCount; i++)
            {
                if (chkInputType.Checked) // 팔레트 중복체크
                {
                    if (txtPalletID.Text.ToString().Equals(spdPalletList.ActiveSheet.Cells[i, (int)PALLET_LIST.PALLET_NO].Value.ToString()))
                        return false;
                }
                else // LOT 중복체크
                {
                    if (txtPalletID.Text.ToString().Equals(spdPalletList.ActiveSheet.Cells[i, (int)NO_PALLET_LIST.LOT_ID].Value.ToString()))
                        return false;
                }
            }

            return true;
        }

        private bool CheckSaveExist()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                if (chkInputType.Checked)
                    sViewID = "VIEW_BOX_ID_EXIST";
                else
                    sViewID = "VIEW_LOT_ID_EXIST";

                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$BOX_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(txtPalletID.Text);

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return true;
                }
                else
                {
                    if (int.Parse(dt.Rows[0]["CNT"].ToString()) == 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckSaveLotExist()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_LOT_IN_BOX_EXIST";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$BOX_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(txtPalletID.Text);

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return true;
                }
                else
                {
                    if (int.Parse(dt.Rows[0]["CNT"].ToString()) == 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckShipLotExist()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_SHIP_LOT_ID_EXIST";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$LOT_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(txtPalletID.Text);

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }
                else
                {
                    if (int.Parse(dt.Rows[0]["CNT"].ToString()) == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckCreateBoxExist(VALIDATION_CASE valCase)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_CREATE_BOX_EXIST";
                i_cond_cnt = 1;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$LOT_ID";

                if (valCase == VALIDATION_CASE.VIEW)
                    ArrDVC[0].sCondition_Value = string.Format("('{0}')", txtPalletID.Text);
                else if (valCase == VALIDATION_CASE.CHECK)
                    ArrDVC[0].sCondition_Value = GetPalletList();

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return true;
                }
                else
                {
                    if (int.Parse(dt.Rows[0]["CNT"].ToString()) == 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool CheckShipmentExist(VALIDATION_CASE valCase)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_SHIPMENT_LOT_LIST";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$INPUT";

                if (valCase == VALIDATION_CASE.VIEW)
                    ArrDVC[1].sCondition_Value = string.Format("('{0}')", txtPalletID.Text);
                else if (valCase == VALIDATION_CASE.CHECK)
                    ArrDVC[1].sCondition_Value = GetPalletList();

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return true;
                }
                else
                {
                    if (int.Parse(dt.Rows[0]["CNT"].ToString()) == 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewShipmentList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdShipList);

            try
            {
				//if (chkFinishFlag.Checked)
				//{
				//    sViewID = "VIEW_SHIPMENT_LIST_ALL_02";
				//}
				//else
				//{
				//    //sViewID = "VIEW_SHIPMENT_LIST";
				//    sViewID = "VIEW_SHIPMENT_LIST_02";
				//}
				sViewID = "VIEW_SHIPMENT_LIST_ALL_02";

                i_cond_cnt = 6;

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

				ArrDVC[5].sCondtion_ID = "$SHIP_STATUS_FLAG";
				if (chkFinishFlag.Checked == true)
				{
					ArrDVC[5].sCondition_Value = "";
				}
				else
				{
					ArrDVC[5].sCondition_Value = "N";
				}

                if (TPDR.DirectViewOne(this.spdShipList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                SetShipSpreadLabel();

                spdShipList.ActiveSheet.Columns[(int)SHIP_LIST.FACTORY].Visible = false;

                MPCF.FitColumnHeader(spdShipList);

                spdShipList.Sheets[0].ColumnHeader.Cells[0, (int)SHIP_LIST.FACTORY].Text = MPCF.FindLanguage("Shipment Request Information");
                spdShipList.Sheets[0].AddColumnHeaderSpanCell(0, (int)SHIP_LIST.FACTORY, 1, 3);

                spdShipList.Sheets[0].ColumnHeader.Cells[0, (int)SHIP_LIST.IN_OUT_CODE].Text = MPCF.FindLanguage("Contract Information");
                spdShipList.Sheets[0].AddColumnHeaderSpanCell(0, (int)SHIP_LIST.IN_OUT_CODE, 1, 14);

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
            bool statusFlag = false;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            iRow = spdShipList.ActiveSheet.ActiveRowIndex;
            if (iRow < 0) return false;

            try
            {
                sViewID = "VIEW_SHIP_MAT_LIST_02";
                i_cond_cnt = 7;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$ORDER_DATE";
                ArrDVC[1].sCondition_Value = MPCF.Trim(saveValues.ORDER_DATE);

                ArrDVC[2].sCondtion_ID = "$ORDER_ID";
                ArrDVC[2].sCondition_Value = MPCF.Trim(saveValues.ORDER_ID);

                ArrDVC[3].sCondtion_ID = "$FROM_DATE";
                ArrDVC[3].sCondition_Value = string.Empty;

                ArrDVC[4].sCondtion_ID = "$TO_DATE";
                ArrDVC[4].sCondition_Value = string.Empty;

                ArrDVC[5].sCondtion_ID = "$MAT_ID";
                ArrDVC[5].sCondition_Value = string.Empty;

                ArrDVC[6].sCondtion_ID = "$CONTRACT_NO";
                ArrDVC[6].sCondition_Value = MPCF.Trim(saveValues.CONTRACT_NO);

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
                    spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.ORDER_SEQ].Visible = false;

                    MPCF.FitColumnHeader(spdShipMatList);
                }
                else if (valCase == VALIDATION_CASE.CHECK)
                {
                    if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                    {
                        if (dt != null) { dt.Dispose(); }
                        GC.Collect();
                        return false;
                    }

                    DataTable lotListSpread = (DataTable)spdLotList.DataSource;

                    if (lotListSpread == null)
                        return false;

                    if (chkInputType.Checked) // 팔레트 처리 로직
                    {
                        //팔레트 별 LOT 리스트 갯수를 각각 추출하여 의뢰수량을 넘는지 체크한다.
                        for (int s = 0; s < spdPalletList.ActiveSheet.RowCount; s++)
                        {
                            int lotCnt = 0;

                            string orderID = spdPalletList.ActiveSheet.Cells[s, (int)PALLET_LIST.ORDER_ID].Value.ToString();
                            //string appNum = spdPalletList.ActiveSheet.Cells[s, (int)PALLET_LIST.APP_NUM].Value.ToString();
                            string appNum = "";
                            string orderSeq = spdPalletList.ActiveSheet.Cells[s, (int)PALLET_LIST.ORDER_SEQ].Value.ToString();
                            string matID = spdPalletList.ActiveSheet.Cells[s, (int)PALLET_LIST.MAT_ID].Value.ToString();

                            for (int i = 0; i < spdPalletList.ActiveSheet.RowCount; i++)
                            {
                                string subOrderID = spdPalletList.ActiveSheet.Cells[i, (int)PALLET_LIST.ORDER_ID].Value.ToString();
                                //string subAppNum = spdPalletList.ActiveSheet.Cells[i, (int)PALLET_LIST.APP_NUM].Value.ToString();
                                string subAppNum = "";
                                string subOrderSeq = spdPalletList.ActiveSheet.Cells[i, (int)PALLET_LIST.ORDER_SEQ].Value.ToString();
                                string subMatID = spdPalletList.ActiveSheet.Cells[i, (int)PALLET_LIST.MAT_ID].Value.ToString();
                                string subPalletID = spdPalletList.ActiveSheet.Cells[i, (int)PALLET_LIST.PALLET_NO].Value.ToString();

                                if (subOrderID.Equals(orderID) && subAppNum.Equals(appNum) && subOrderSeq.Equals(orderSeq) && subMatID.Equals(matID))
                                {
                                    for (int j = 0; j < lotListSpread.Rows.Count; j++)
                                    {
                                        string lotPalletID = lotListSpread.Rows[j]["PALLET_ID"].ToString();

                                        if (subPalletID.Equals(lotPalletID))
                                            lotCnt++;
                                    }
                                }
                            }

                            //DataTable resultDt = dt.Select(string.Format("ORDER_ID='{0}' AND APP_NUM='{1}' AND ORDER_SEQ='{2}' AND MAT_ID='{3}'", orderID, appNum, orderSeq, matID)).CopyToDataTable<DataRow>();
                            DataTable resultDt = dt.Select(string.Format("ORDER_ID='{0}' AND ORDER_SEQ='{1}' AND MAT_ID='{2}'", orderID, orderSeq, matID)).CopyToDataTable<DataRow>();

                            // 20171208-출고 대상 팔레트 정보 저장 시에 출고 정보 완료 처리를 하지 않음
                            //if (int.Parse(resultDt.Rows[0]["REQ_QTY"].ToString()) <= lotCnt + int.Parse(resultDt.Rows[0]["QTY"].ToString()))
                            //{
                            //    if (int.Parse(resultDt.Rows[0]["REQ_QTY"].ToString()) < lotCnt + int.Parse(resultDt.Rows[0]["QTY"].ToString()))
                            //        statusFlag = true;
                            //    spdPalletList.ActiveSheet.Cells[s, (int)PALLET_LIST.STATUS].Value = 'Y';
                            //}
                            //else
                            //{
                            //    spdPalletList.ActiveSheet.Cells[s, (int)PALLET_LIST.STATUS].Value = string.Empty;
                            //}
                            //if (int.Parse(resultDt.Rows[0]["REQ_QTY"].ToString()) < lotCnt + int.Parse(resultDt.Rows[0]["QTY"].ToString()))
                            if (int.Parse(resultDt.Rows[0]["REQ_QTY"].ToString()) < lotCnt + int.Parse(resultDt.Rows[0]["ACCRUE_QTY"].ToString()))
                                statusFlag = true;
                        }
                    }
                    else //LOT 처리 로직
                    {
                        for (int s = 0; s < spdPalletList.ActiveSheet.RowCount; s++)
                        {
                            int lotCnt = 0;

                            string orderID = spdPalletList.ActiveSheet.Cells[s, (int)NO_PALLET_LIST.ORDER_ID].Value.ToString();
                            //string appNum = spdPalletList.ActiveSheet.Cells[s, (int)NO_PALLET_LIST.APP_NUM].Value.ToString();
                            string appNum = "";
                            string orderSeq = spdPalletList.ActiveSheet.Cells[s, (int)NO_PALLET_LIST.ORDER_SEQ].Value.ToString();
                            string matID = spdPalletList.ActiveSheet.Cells[s, (int)NO_PALLET_LIST.MAT_ID].Value.ToString();

                            for (int i = 0; i < spdPalletList.ActiveSheet.RowCount; i++)
                            {
                                string subOrderID = spdPalletList.ActiveSheet.Cells[i, (int)NO_PALLET_LIST.ORDER_ID].Value.ToString();
                                //string subAppNum = spdPalletList.ActiveSheet.Cells[i, (int)NO_PALLET_LIST.APP_NUM].Value.ToString();
                                string subAppNum = "";
                                string subOrderSeq = spdPalletList.ActiveSheet.Cells[i, (int)NO_PALLET_LIST.ORDER_SEQ].Value.ToString();
                                string subMatID = spdPalletList.ActiveSheet.Cells[i, (int)NO_PALLET_LIST.MAT_ID].Value.ToString();
                                string subLotID = spdPalletList.ActiveSheet.Cells[i, (int)NO_PALLET_LIST.LOT_ID].Value.ToString();

                                if (subOrderID.Equals(orderID) && subAppNum.Equals(appNum) && subOrderSeq.Equals(orderSeq) && subMatID.Equals(matID))
                                {
                                    for (int j = 0; j < lotListSpread.Rows.Count; j++)
                                    {
                                        string lotID = lotListSpread.Rows[j]["LOT_ID"].ToString();

                                        if (subLotID.Equals(lotID))
                                            lotCnt++;
                                    }
                                }
                            }

                            //DataTable resultDt = dt.Select(string.Format("ORDER_ID='{0}' AND APP_NUM='{1}' AND ORDER_SEQ='{2}' AND MAT_ID='{3}'", orderID, appNum, orderSeq, matID)).CopyToDataTable<DataRow>();
                            DataTable resultDt = dt.Select(string.Format("ORDER_ID='{0}' AND ORDER_SEQ='{1}' AND MAT_ID='{2}'", orderID, orderSeq, matID)).CopyToDataTable<DataRow>();

                            // 20171208-출고 대상 팔레트 정보 저장 시에 출고 정보 완료 처리를 하지 않음
                            //if (int.Parse(resultDt.Rows[0]["REQ_QTY"].ToString()) <= lotCnt + int.Parse(resultDt.Rows[0]["QTY"].ToString()))
                            //{
                            //    if (int.Parse(resultDt.Rows[0]["REQ_QTY"].ToString()) < lotCnt + int.Parse(resultDt.Rows[0]["QTY"].ToString()))
                            //        statusFlag = true;
                            //    spdPalletList.ActiveSheet.Cells[s, (int)NO_PALLET_LIST.STATUS].Value = 'Y';
                            //}
                            //else
                            //{
                            //    spdPalletList.ActiveSheet.Cells[s, (int)NO_PALLET_LIST.STATUS].Value = string.Empty;
                            //}
                            //if (int.Parse(resultDt.Rows[0]["REQ_QTY"].ToString()) < lotCnt + int.Parse(resultDt.Rows[0]["QTY"].ToString()))
                            if (int.Parse(resultDt.Rows[0]["REQ_QTY"].ToString()) < lotCnt + int.Parse(resultDt.Rows[0]["ACCRUE_QTY"].ToString()))
                                statusFlag = true;
                        }
                    }

                    if (statusFlag && deleteFlag)
                    {
                        DialogResult dr = MPCF.ShowMsgBox(string.Format("{0} {1}", MPCF.GetMessage(392), MPCF.GetMessage(377)), MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);
                        if (dr != System.Windows.Forms.DialogResult.OK)
                            return false;
                    }
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
                    //spdShipMatList.ActiveSheet.Columns[(int)SHIP_MAT_LIST.APP_NUM].Visible = false;
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

        private bool ViewPalletLotList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;
            txtScanCount.Text = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdLotList);

            try
            {
                if (spdPalletList.ActiveSheet.RowCount == 0)
                    return false;

                
				if (chkInputType.Checked)
                {
                    sViewID = "VIEW_PALLET_LOT_ID_LIST_01";
                    i_cond_cnt = 1;

                    ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                    ArrDVC[0].sCondtion_ID = "$BOX_ID";
                    ArrDVC[0].sCondition_Value = GetPalletList();
                }
                else
                {
                    sViewID = "VIEW_NO_PALLET_LOT_ID_LIST_02";
                    i_cond_cnt = 2;

                    ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                    ArrDVC[0].sCondtion_ID = "$FACTORY";
                    ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                    ArrDVC[1].sCondtion_ID = "$FG_ID";
                    ArrDVC[1].sCondition_Value = GetPalletList();
                }

                if (TPDR.DirectViewOne(this.spdLotList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                // ?????
                //spdLotList.ActiveSheet.Columns[(int)LOT_LIST.LOT_ID].Visible = false;

                txtScanCount.Text = saveValues.SHIP_QTY = spdLotList.ActiveSheet.RowCount.ToString();
                MPCF.FitColumnHeader(spdLotList);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool ViewTargetMatList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;
            txtScanCount.Text = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdTargetMatList);

            try
            {
                if (chkFinishFlag.Checked)
                    sViewID = "VIEW_TARGET_MAT_LIST_ALL";
                else
                    sViewID = "VIEW_TARGET_MAT_LIST";

                i_cond_cnt = 3;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$FROM_DATE";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.dtpFrom.GetValueAsString(8));

                ArrDVC[2].sCondtion_ID = "$TO_DATE";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.dtpTo.GetValueAsString(8));

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    spdTargetMatList.ActiveSheet.RowCount++;
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.CHECKBOX].Value = false;
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.FACTORY].Value = dt.Rows[i]["FACTORY"].ToString();
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.SHIP_ID].Value = dt.Rows[i]["SHIP_ID"].ToString();
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.ORDER_DATE].Value = dt.Rows[i]["REQUEST_DATE"].ToString().Replace("-", "");
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.SHP_DATE].Value = dt.Rows[i]["SHIPMENT_DATE"].ToString();
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.CONTRACT_NO].Value = dt.Rows[i]["CONTRACT_NO"].ToString().Replace("-", "");
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.CUSTOMER_ID].Value = dt.Rows[i]["CUSTOMER_ID"].ToString();
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.SHIP_MONEY].Value = dt.Rows[i]["TRANSPORTATION_FEE"].ToString();
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.VC_DESC].Value = dt.Rows[i]["VEHICLE_INFORMATION"].ToString();
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.VC_NUM].Value = dt.Rows[i]["VEHICLE_NUMBER"].ToString();
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.ST_DATE].Value = dt.Rows[i]["START_DATE"].ToString();
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.DUE_DATE].Value = dt.Rows[i]["ARRIVAL_DUE_DATE"].ToString();
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.ETC_DESC].Value = dt.Rows[i]["NOTE"].ToString();
                    spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.STATUS].Value = dt.Rows[i]["SHIP_STATUS_FLAG"].ToString();

                    if (spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.STATUS].Value.Equals("Y"))
                        spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.CHECKBOX].Locked = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool SavePalletLotList()
        {
            TRSNode in_node = new TRSNode("CUS_CREATE_LOTLIST_IN");
            TRSNode out_node = new TRSNode("CUS_CREATE_LOTLIST_OUT");
            TRSNode list_item;

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CREATE;

                in_node.AddString("ORDER_DATE", MPCF.Trim(saveValues.ORDER_DATE));
                in_node.AddString("SHP_DATE", MPCF.Trim(DateTime.Now.ToString("yyyyMMdd")));
                in_node.AddString("SHIP_QTY", MPCF.Trim(saveValues.SHIP_QTY));
                in_node.AddString("CONTRACT_NO", MPCF.Trim(saveValues.CONTRACT_NO));

                for (int i = 0; i < spdLotList.ActiveSheet.RowCount; i++)
                {
                    list_item = in_node.AddNode("LOT_LIST");

                    if (chkInputType.Checked) //팔레트 정보 구성
                    {
                        string strPalletID = MPCF.Trim(spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.PALLET_NO].Value);

                        list_item.AddString("BOX_ID", strPalletID);
                        list_item.AddString("LOT_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.LOT_ID].Value));
                        list_item.AddString("MAT_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.MAT_ID].Value));
                        list_item.AddInt("MAT_VER", MPCF.Trim(spdLotList.ActiveSheet.Cells[i, (int)LOT_LIST.MAT_VER].Value));

                        for (int j = 0; j < spdPalletList.ActiveSheet.RowCount; j++)
                        {
                            if (spdPalletList.ActiveSheet.Cells[j, (int)PALLET_LIST.PALLET_NO].Value.Equals(strPalletID))
                            {
                                list_item.AddString("ORDER_ID", MPCF.Trim(spdPalletList.ActiveSheet.Cells[j, (int)PALLET_LIST.ORDER_ID].Value));
                                list_item.AddInt("APP_NUM", MPCF.Trim(spdPalletList.ActiveSheet.Cells[j, (int)PALLET_LIST.APP_NUM].Value));
                                list_item.AddInt("ORDER_SEQ", MPCF.Trim(spdPalletList.ActiveSheet.Cells[j, (int)PALLET_LIST.ORDER_SEQ].Value));
                                // 20171208-출고 대상 팔레트 정보 저장 시에 출고 정보 완료 처리를 하지 않음
                                //list_item.AddChar("SHIP_STATUS_FLAG", MPCF.Trim(spdPalletList.ActiveSheet.Cells[j, (int)PALLET_LIST.STATUS].Value));
								break;
                            }
                        }
                    }
                    else //LOT 정보 구성
                    {
                        string strLotID = MPCF.Trim(spdLotList.ActiveSheet.Cells[i, (int)NO_LOT_LIST.LOT_ID].Value);

                        list_item.AddString("LOT_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[i, (int)NO_LOT_LIST.LOT_ID].Value));
                        list_item.AddString("MAT_ID", MPCF.Trim(spdLotList.ActiveSheet.Cells[i, (int)NO_LOT_LIST.MAT_ID].Value));
                        list_item.AddInt("MAT_VER", MPCF.Trim(spdLotList.ActiveSheet.Cells[i, (int)NO_LOT_LIST.MAT_VER].Value));

                        for (int j = 0; j < spdPalletList.ActiveSheet.RowCount; j++)
                        {
                            if (spdPalletList.ActiveSheet.Cells[j, (int)NO_PALLET_LIST.LOT_ID].Value.Equals(strLotID))
                            {
                                list_item.AddString("ORDER_ID", MPCF.Trim(spdPalletList.ActiveSheet.Cells[j, (int)NO_PALLET_LIST.ORDER_ID].Value));
                                list_item.AddInt("APP_NUM", MPCF.Trim(spdPalletList.ActiveSheet.Cells[j, (int)NO_PALLET_LIST.APP_NUM].Value));
                                list_item.AddInt("ORDER_SEQ", MPCF.Trim(spdPalletList.ActiveSheet.Cells[j, (int)NO_PALLET_LIST.ORDER_SEQ].Value));
                                // 20171208-출고 대상 팔레트 정보 저장 시에 출고 정보 완료 처리를 하지 않음
                                //list_item.AddChar("SHIP_STATUS_FLAG", MPCF.Trim(spdPalletList.ActiveSheet.Cells[j, (int)NO_PALLET_LIST.STATUS].Value));
								break;
                            }
                        }
                    }
                }

                if (MPCF.CallService("CUS", "CSHP_Create_Pallet_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool SaveCarryInfo()
        {
            TRSNode in_node = new TRSNode("CUS_UPDATE_CARRY_IN");
            TRSNode out_node = new TRSNode("CUS_UPDATE_CARRY_OUT");
            TRSNode list_item;

            try
            {
                bool chkFlag = false;

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_UPDATE;

                for (int i = 0; i < spdTargetMatList.ActiveSheet.RowCount; i++)
                {
                    if (Convert.ToBoolean(spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.CHECKBOX].Value) == true)
                    {
                        list_item = in_node.AddNode("PALLET_LIST");

                        //SELECT
                        list_item.AddString("SHIP_ID", MPCF.Trim(spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.SHIP_ID].Value));
                        list_item.AddString("ORDER_DATE", MPCF.Trim(spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.ORDER_DATE].Value).Replace("-", ""));
                        list_item.AddString("SHP_DATE", MPCF.Trim(spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.SHP_DATE].Value));
                        list_item.AddString("CONTRACT_NO", MPCF.Trim(spdTargetMatList.ActiveSheet.Cells[i, (int)TARGET_MAT_LIST.CONTRACT_NO].Value).Replace("-", ""));
                        //UPDATE
                        list_item.AddString("CUSTOMER_ID", MPCF.Trim(cdvCustomer.Text));
                        list_item.AddString("SHIP_MONEY", MPCF.Trim(double.Parse(txtAmount.Text.ToString())));
                        list_item.AddString("VC_DESC", MPCF.Trim(txtCarInfo.Text));
                        list_item.AddString("VC_NUM", MPCF.Trim(txtCarNum.Text));
                        list_item.AddString("ST_DATE", MPCF.Trim(dtpStDate.GetValueAsString(8) + cbxStHour.Text + cbxStMin.Text));
                        list_item.AddString("DUE_DATE", MPCF.Trim(dtpDueDate.GetValueAsString(8) + cbxDueHour.Text + cbxDueMin.Text));
                        list_item.AddString("ETC_DESC", MPCF.Trim(txtNote.Text));

                        chkFlag = true;
                    }
                }

                if (!chkFlag)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(71));
                    return false;
                }


                if (MPCF.CallService("CUS", "CSHP_Update_Carry_Data", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool DeleteProccess(TAB_CASE DeleteCase)
        {
            try
            {
                switch (DeleteCase)
                {
                    case TAB_CASE.PALLET:

                        DeletePallet();

                        break;

                    case TAB_CASE.CARRY:

                        if (DeleteCarryData())
                            ViewTargetMatList();

                        break;

                    case TAB_CASE.SCAN:

                        if (spdScanList.ActiveSheet.Rows.Count > 0)
                        {
                            spdScanList.Sheets[0].Rows[spdScanList.ActiveSheet.ActiveRowIndex].Remove();
                            ExportScanInfoText(utbShipTap.ActiveTab.Key); // 데이터 저장
                        }

                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool AddPalletList()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                if (chkInputType.Checked)
                {
					sViewID = "VIEW_PALLET_LOT_ID_LIST_01";
                    i_cond_cnt = 1;

                    ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                    ArrDVC[0].sCondtion_ID = "$BOX_ID";
                    ArrDVC[0].sCondition_Value = string.Format("('{0}')", txtPalletID.Text);
                }
                else
                {
                    sViewID = "VIEW_SHIP_LOT_ID_EXIST";
                    i_cond_cnt = 2;

                    ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                    ArrDVC[0].sCondtion_ID = "$FACTORY";
                    ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                    ArrDVC[1].sCondtion_ID = "$LOT_ID";
                    ArrDVC[1].sCondition_Value = MPCF.Trim(txtPalletID.Text);
                }

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(122));
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (chkInputType.Checked)
                    {
                        if (!saveValues.MAT_ID.Equals(dt.Rows[i][(int)LOT_LIST.MAT_ID].ToString()))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(388));
                            return false;
                        }
                    }
                    else
                    {
                        if (!saveValues.MAT_ID.Equals(dt.Rows[i]["MAT_ID"].ToString()))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(388));
                            return false;
                        }
                    }
                }

                spdPalletList.ActiveSheet.RowCount++;

                if (chkInputType.Checked)
                {
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.CHECKBOX].Value = false;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.PALLET_NO].Value = txtPalletID.Text;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.CREATE_DATE].Value = DateTime.Now.ToString("yyyyMMdd");
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.ORDER_ID].Value = saveValues.ORDER_ID;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.APP_NUM].Value = saveValues.APP_NUM;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.ORDER_SEQ].Value = saveValues.ORDER_SEQ;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.MAT_ID].Value = saveValues.MAT_ID;

                    spdPalletList.ActiveSheet.Columns[(int)PALLET_LIST.ORDER_ID].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)PALLET_LIST.APP_NUM].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)PALLET_LIST.ORDER_SEQ].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)PALLET_LIST.MAT_ID].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)PALLET_LIST.STATUS].Visible = false;
                }
                else
                {
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.CHECKBOX].Value = false;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.FG_ID].Value = txtPalletID.Text;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.LOT_ID].Value = dt.Rows[0]["LOT_ID"].ToString();
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.CREATE_DATE].Value = DateTime.Now.ToString("yyyy-MM-dd");
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.ORDER_ID].Value = saveValues.ORDER_ID;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.APP_NUM].Value = saveValues.APP_NUM;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.ORDER_SEQ].Value = saveValues.ORDER_SEQ;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.MAT_ID].Value = saveValues.MAT_ID;

                    spdPalletList.ActiveSheet.Columns[(int)NO_PALLET_LIST.ORDER_ID].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)NO_PALLET_LIST.APP_NUM].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)NO_PALLET_LIST.ORDER_SEQ].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)NO_PALLET_LIST.MAT_ID].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)NO_PALLET_LIST.STATUS].Visible = false;
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

        private bool MinusPalletList()
        {
            try
            {
                spdPalletList_Sheet1.RemoveRows(spdPalletList_Sheet1.RowCount - 1, 1);
                return true;
            }
            catch
            {
                return true;
            }
        }

        private bool GetTransportationInfo()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_MODULE_PRINT_INFO";
                i_cond_cnt = 3;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$ORDER_DATE";
                ArrDVC[1].sCondition_Value = saveCarryValues.ORDER_DATE;

                ArrDVC[2].sCondtion_ID = "$CONTRACT_NO";
                ArrDVC[2].sCondition_Value = saveCarryValues.CONTRACT_NO;

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                modulePrintValues.FACTORY = dt.Rows[0][(int)MODULE_PRINT_MASTER.FACTORY].ToString();
                modulePrintValues.DLV_LOCATION = dt.Rows[0][(int)MODULE_PRINT_MASTER.DLV_LOCATION].ToString();
                modulePrintValues.RECEIVER = dt.Rows[0][(int)MODULE_PRINT_MASTER.RECEIVER].ToString();
                modulePrintValues.RECEIVER_PHONE = dt.Rows[0][(int)MODULE_PRINT_MASTER.RECEIVER_PHONE].ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool GetShipmentDetailInfo()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_MODULE_PRINT_DETAIL_INFO";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$SHIP_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(saveCarryValues.SHIP_ID);

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                modulePrintDetailValues = dt;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool GetProductDetailInfo()
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_PRODUCT_PRINT_INFO_01";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$SHIP_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(saveCarryValues.SHIP_ID);

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                productPrintDetailValues = dt;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private string GetPalletList()
        {
            List<string> palletList = new List<string>();
            string[] arrPalletID = null;

            for (int i = 0; i < spdPalletList.ActiveSheet.Rows.Count; i++)
            {
                if (chkInputType.Checked)
                    palletList.Add(spdPalletList.ActiveSheet.Cells[i, (int)PALLET_LIST.PALLET_NO].Value.ToString());
                else
                    palletList.Add(spdPalletList.ActiveSheet.Cells[i, (int)NO_PALLET_LIST.FG_ID].Value.ToString());
            }

            if (palletList.Count == 0)
                return string.Empty;

            arrPalletID = palletList.ToArray();
            return string.Format("('{0}')", string.Join("','", arrPalletID));
        }

        private void DeletePallet()
        {
            bool searchFlag = false;

            for (int i = spdPalletList.ActiveSheet.RowCount - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(spdPalletList.ActiveSheet.Cells[i, (int)PALLET_LIST.CHECKBOX].Value))
                {
                    searchFlag = true;
                    spdPalletList_Sheet1.RemoveRows(i, 1);
                }
            }

            if (searchFlag)
            {
                ViewPalletLotList();
                ViewShipmentMaterialList(VALIDATION_CASE.CHECK, false);
            }
        }

        private bool DeleteCarryData()
        {
            TRSNode in_node = new TRSNode("CUS_DELETE_CARRY_IN");
            TRSNode out_node = new TRSNode("CUS_DELETE_CARRY_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_DELETE;
                //SELECT
                in_node.AddString("SHIP_ID", MPCF.Trim(saveCarryValues.SHIP_ID));
                in_node.AddString("ORDER_DATE", MPCF.Trim(saveCarryValues.ORDER_DATE));
                in_node.AddString("SHP_DATE", MPCF.Trim(saveCarryValues.SHP_DATE));

                if (MPCF.CallService("CUS", "CSHP_Update_Carry_Data", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, true);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private void SetPrintVisible(bool visibleFlag)
        {
            btnPrintOption.Visible = visibleFlag;
            btnModule.Visible = visibleFlag;
            btnMaterial.Visible = visibleFlag;
        }

        private void SetPalletSpread()
        {
            MPCF.ClearList(this.spdPalletList);
            MPCF.ClearList(this.spdLotList);

            spdPalletList.ActiveSheet.ColumnCount = 8;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[1].Label = PALLET;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[2].Label = CREATE_DATE;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[3].Label = ORDER_ID;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[4].Label = APP_NUM;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[5].Label = ORDER_SEQ;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[6].Label = MAT_ID;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[7].Label = STATUS;

            spdLotList.ActiveSheet.ColumnCount = 4;
            spdLotList.ActiveSheet.ColumnHeader.Columns[0].Label = PALLET;
            spdLotList.ActiveSheet.ColumnHeader.Columns[1].Label = LOT;
            spdLotList.ActiveSheet.ColumnHeader.Columns[2].Label = MAT_ID;
            spdLotList.ActiveSheet.ColumnHeader.Columns[3].Label = MAT_VER;

            MPCF.ConvertCaption(spdPalletList);
            MPCF.ConvertCaption(spdLotList);
        }

        private void SetNoPalletSpread()
        {
            MPCF.ClearList(this.spdPalletList);
            MPCF.ClearList(this.spdLotList);

            spdPalletList.ActiveSheet.ColumnCount = 9;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[1].Label = FG_ID;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[2].Label = LOT;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[3].Label = CREATE_DATE;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[4].Label = ORDER_ID;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[5].Label = APP_NUM;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[6].Label = ORDER_SEQ;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[7].Label = MAT_ID;
            spdPalletList.ActiveSheet.ColumnHeader.Columns[8].Label = STATUS;

            spdLotList.ActiveSheet.ColumnCount = 4;
            spdLotList.ActiveSheet.ColumnHeader.Columns[0].Label = FG_ID;
            spdLotList.ActiveSheet.ColumnHeader.Columns[1].Label = LOT;
            spdLotList.ActiveSheet.ColumnHeader.Columns[2].Label = MAT_ID;
            spdLotList.ActiveSheet.ColumnHeader.Columns[3].Label = MAT_VER;

            MPCF.ConvertCaption(spdPalletList);
            MPCF.ConvertCaption(spdLotList);
        }

        #endregion

        #region [Event Definition]

        private void frmCUSTranMatShipManagement_Load(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void frmCUSTranMatShipManagement_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtContractNo);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Initialize();

            //조회 조건 확인
            if (!CheckCondition(CSGC.MP_CHECK_VIEW)) { return; }

            if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.SHIPMENT)
                ViewShipmentList();
            else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.PALLET)
                ViewShipmentMaterialList_02(VALIDATION_CASE.VIEW);
            else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.CARRY)
                ViewTargetMatList();
        }

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

        private void cdvCustomer_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_GCM_DATA";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$TABLE_NAME";
                ArrDVC[1].sCondition_Value = "CUST_CODE";

                string[] header = new string[] { "Customer ID", "Customer Desc" };
                string[] display = new string[] { "KEY_1", "DATA_1" };

                cdvCustomer.Text = cdvCustomer.Show(cdvCustomer, "Customer List", sViewID, ArrDVC, display, header, "KEY_1", -1);

                if (cdvCustomer.returnDatas != null && cdvCustomer.returnDatas.Count > 0)
                {
                    cdvCustomer.Text = cdvCustomer.returnDatas[0];
                    this.txtCustomerDesc.Text = cdvCustomer.returnDatas[1];
                }
                else
                {
                    this.txtCustomerDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvCustomer_ValueChanged(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                sViewID = "VIEW_CUST_CODE_LIST";
                i_cond_cnt = 3;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$TABLE_NAME";
                ArrDVC[1].sCondition_Value = "CUST_CODE";

                ArrDVC[2].sCondtion_ID = "$KEY_1";
                ArrDVC[2].sCondition_Value = cdvCustomer.Text;

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    txtCustomerDesc.Text = string.Empty;

                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return;
                }

                txtCustomerDesc.Text = dt.Rows[0]["DATA_1"].ToString();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdShipList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            saveValues.ORDER_DATE = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.ORDER_DATE].Value.ToString().Replace("-", "");
            saveValues.ORDER_ID = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.ORDER_ID].Value.ToString();
            saveValues.SHP_REQ_DATE = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.SHP_REQ_DATE].Value.ToString().Replace("-", "");
            saveValues.CONTRACT_NO = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.CONTRACT_NO].Value.ToString().Replace("-", "");

            utbShipTap.Tabs[(int)TAB_CASE.PALLET].Selected = true;

            ViewShipmentMaterialList(VALIDATION_CASE.VIEW);
        }

        private void spdShipMatList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            //saveValues.CONTRACT_SEQ = spdShipMatList.ActiveSheet.Cells[spdShipMatList.ActiveSheet.ActiveRowIndex, (int)SHIP_MAT_LIST.CONTRACT_SEQ].Value.ToString();
            saveValues.MAT_ID = txtCurMatID.Text = spdShipMatList.ActiveSheet.Cells[spdShipMatList.ActiveSheet.ActiveRowIndex, (int)SHIP_MAT_LIST.MAT_ID].Value.ToString();
            //saveValues.SHP_QTY = txtTotalCount.Text = spdShipMatList.ActiveSheet.Cells[spdShipMatList.ActiveSheet.ActiveRowIndex, (int)SHIP_MAT_LIST.SHP_QTY].Value.ToString();
            saveValues.REQ_QTY = txtTotalCount.Text = spdShipMatList.ActiveSheet.Cells[spdShipMatList.ActiveSheet.ActiveRowIndex, (int)SHIP_MAT_LIST.REQ_QTY].Value.ToString();
            saveValues.ORDER_ID = spdShipMatList.ActiveSheet.Cells[spdShipMatList.ActiveSheet.ActiveRowIndex, (int)SHIP_MAT_LIST.ORDER_ID].Value.ToString();
            //saveValues.APP_NUM = spdShipMatList.ActiveSheet.Cells[spdShipMatList.ActiveSheet.ActiveRowIndex, (int)SHIP_MAT_LIST.APP_NUM].Value.ToString();
            saveValues.ORDER_SEQ = spdShipMatList.ActiveSheet.Cells[spdShipMatList.ActiveSheet.ActiveRowIndex, (int)SHIP_MAT_LIST.ORDER_SEQ].Value.ToString();
            txtAccrueCount.Text =  spdShipMatList.ActiveSheet.Cells[spdShipMatList.ActiveSheet.ActiveRowIndex, (int)SHIP_MAT_LIST.ACCRUE_QTY].Value.ToString();

            MPCF.SetFocus(txtPalletID);
        }

        private void spdTargetMatList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                if (e.Column == 0)
                {
                    if (e.ColumnHeader == true && e.Column == (int)PALLET_LIST.CHECKBOX)
                    {
                        if (spdTargetMatList.ActiveSheet.RowCount < 1) return;

                        bool allChecked = (spdTargetMatList.Tag == null || spdTargetMatList.Tag.ToString() == "0") ? false : true;

                        if (allChecked == true) spdTargetMatList.Tag = "0";
                        else spdTargetMatList.Tag = "1";

                        for (int r = 0; r < spdTargetMatList.ActiveSheet.RowCount; r++)
                            spdTargetMatList.ActiveSheet.Cells[r, e.Column].Value = allChecked;
                    }
                }
                else
                {
                    saveCarryValues = new SaveCarryValues();

                    saveCarryValues.FACTORY = spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.FACTORY].Value.ToString();
                    saveCarryValues.SHIP_ID = spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.SHIP_ID].Value.ToString();
                    saveCarryValues.ORDER_DATE = spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.ORDER_DATE].Value.ToString().Replace("-", "");
                    saveCarryValues.SHP_DATE = spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.SHP_DATE].Value.ToString();
                    saveCarryValues.CONTRACT_NO = spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.CONTRACT_NO].Value.ToString().Replace("-", "");
                    saveCarryValues.CUSTOMER_ID = cdvCustomer.Text = MPCF.Trim(spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.CUSTOMER_ID].Value.ToString());
                    saveCarryValues.SHIP_MONEY = txtAmount.Text = MPCF.Trim(spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.SHIP_MONEY].Value.ToString());
                    saveCarryValues.VC_DESC = txtCarInfo.Text = MPCF.Trim(spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.VC_DESC].Value.ToString());
                    saveCarryValues.VC_NUM = txtCarNum.Text = MPCF.Trim(spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.VC_NUM].Value.ToString());
                    saveCarryValues.CUSTOMER_DESC = MPCF.Trim(txtCustomerDesc.Text);

                    saveCarryValues.ST_DATE = spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.ST_DATE].Value.ToString();
                    if (saveCarryValues.ST_DATE != " ")
                    {
                        dtpStDate.Value = MPCF.ToDate(saveCarryValues.ST_DATE.Substring(0, 8));
                        cbxStHour.Text = saveCarryValues.ST_DATE.Substring(8, 2);
                        cbxStMin.Text = saveCarryValues.ST_DATE.Substring(10, 2);
                    }

                    saveCarryValues.DUE_DATE = spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.DUE_DATE].Value.ToString();
                    if (saveCarryValues.DUE_DATE != " ")
                    {
                        dtpDueDate.Value = MPCF.ToDate(saveCarryValues.DUE_DATE.Substring(0, 8));
                        cbxDueHour.Text = saveCarryValues.DUE_DATE.Substring(8, 2);
                        cbxDueMin.Text = saveCarryValues.DUE_DATE.Substring(10, 2);
                    }

                    saveCarryValues.ETC_DESC = txtNote.Text = MPCF.Trim(spdTargetMatList.ActiveSheet.Cells[e.Row, (int)TARGET_MAT_LIST.ETC_DESC].Value.ToString());
                    cdvCustomer_ValueChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_DELETE)) { return; }

            if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.PALLET)
            {
                DeleteProccess(TAB_CASE.PALLET);
            }
            else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.CARRY)
            {
                DeleteProccess(TAB_CASE.CARRY);
            }
            else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.SCAN)
            {
                DeleteProccess(TAB_CASE.SCAN);
            }
        }

        private void txtPalletID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ENTER)
            {
                txtPalletID.Text = MPCF.ToUpper(txtPalletID.Text);

                if (CheckCondition(CSGC.MP_CHECK_UPDATE)) //중복체크
                {
                    if (AddPalletList()) //제품체크
                    {
                        ViewPalletLotList(); //LOT LIST 조회

                        if (!ViewShipmentMaterialList(VALIDATION_CASE.CHECK)) //의뢰수량 초과시 팝업 띄움, 팔레트 추가 여부 결정
                        {
                            if (MinusPalletList()) //팔레트 추가 취소시 팔레트 삭제 후 LOT LIST 재조회
                                ViewPalletLotList(); //LOT LIST 조회
                        }

                        MPCF.SetFocus(txtPalletID);
                    }
                }

                txtPalletID.Text = string.Empty;
                MPCF.SetFocus(txtPalletID);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_CREATE)) return;

            if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.PALLET)
            {
                if (SavePalletLotList())
                {
                    InitShip();
                    InitPallet();
                    saveValues = new SaveValues();
                    utbShipTap.Tabs[(int)TAB_CASE.CARRY].Selected = true;
                    ViewTargetMatList();
                }
            }
            else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.CARRY)
            {
                if (SaveCarryInfo())
                {
                    saveCarryValues = new SaveCarryValues();
                    ViewTargetMatList();
                }
            }
            else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.SCAN)
            {
                ExportScanInfoText(utbShipTap.ActiveTab.Key); // 데이터 저장
            }
        }

        private void utbShipTap_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.SHIPMENT)
            {
                SetPrintVisible(false);
                btnDelete.Visible = false;
                btnClear.Visible = false;

                InitPallet();
                lblRequest.Visible = true;
                lblShipDate.Visible = false;

                ViewShipmentList();

                MPCF.SetFocus(txtContractNo);
            }
            else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.PALLET)
            {
                SetPrintVisible(false);
                btnDelete.Visible = true;
                btnClear.Visible = false;

                MPCF.SetFocus(txtPalletID);
            }
            else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.CARRY)
            {
                SetPrintVisible(true);
                btnDelete.Visible = false;
                btnClear.Visible = true;

                saveCarryValues = new SaveCarryValues();
                lblRequest.Visible = false;
                lblShipDate.Visible = true;

                ViewTargetMatList();

                cbxStHour.SelectedIndex = 0;
                cbxStMin.SelectedIndex = 0;
                cbxDueHour.SelectedIndex = 0;
                cbxDueMin.SelectedIndex = 0;
            }
            else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.SCAN)
            {
                SetPrintVisible(false);
                btnDelete.Visible = true;
                btnClear.Visible = true;

                MPCF.SetFocus(txtScanOnlyContractNo);
                InitScan();
            }
        }

        private void spdPalletList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == true && e.Column == (int)PALLET_LIST.CHECKBOX)
            {
                if (spdPalletList.ActiveSheet.RowCount < 1) return;

                bool allChecked = (spdPalletList.Tag == null || spdPalletList.Tag.ToString() == "0") ? false : true;

                if (allChecked == true) spdPalletList.Tag = "0";
                else spdPalletList.Tag = "1";

                for (int r = 0; r < spdPalletList.ActiveSheet.RowCount; r++)
                    spdPalletList.ActiveSheet.Cells[r, e.Column].Value = allChecked;
            }
        }

        private void chkInputType_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInputType.Checked)
            {
                lblType.Text = PALLET;
                SetPalletSpread();
            }
            else
            {
                lblType.Text = FG_ID;
                SetNoPalletSpread();
            }

            InitPalletDetail();
            saveValues.MAT_ID = string.Empty;
            MPCF.ConvertCaption(lblType);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.CARRY)
            {
                InitCarry();
            }
            else if (utbShipTap.SelectedTab.Index == (int)TAB_CASE.SCAN)
            {
                InitScan();
            }
        }

        private void txtNumeric_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete ||
                 e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                 e.KeyCode == Keys.End || e.KeyCode == Keys.Home ||
                 e.KeyCode == Keys.Tab || e.KeyCode == Keys.ShiftKey ||
                 e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.OemMinus ||
                 e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Decimal ||
                 e.KeyCode == Keys.Enter))
            {
                if (!(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) && !char.IsDigit(System.Convert.ToChar(e.KeyValue)))
                {
                    e.SuppressKeyPress = true;
                    return;
                }
            }
        }

        private void btnModule_Click(object sender, EventArgs e)
        {
            frmCUSModulePrintPopup frm = new frmCUSModulePrintPopup();
            CUSModulePrintPopupList list;
            modulePrintValues = new ModulePrintValues();
            modulePrintDetailValues = new DataTable();

            try
            {
                if (!CheckCondition(CSGC.MP_CHECK_VIEW, 1)) { return; }

                frm.Owner = this;

                // Bind
                frm.module.FormName = this.Name;
                frm.module.ContractNo = saveCarryValues.CONTRACT_NO;
                frm.module.CustomerID = string.Format("{0} {1}", saveCarryValues.CUSTOMER_ID, saveCarryValues.CUSTOMER_DESC);
                frm.module.OrderID = saveCarryValues.SHIP_ID;
                frm.module.Receiver = modulePrintValues.RECEIVER;
                frm.module.DlvLocation = modulePrintValues.DLV_LOCATION;
                frm.module.ReceiverPhone = modulePrintValues.RECEIVER_PHONE;
                frm.module.StDate = saveCarryValues.ST_DATE;
                frm.module.DueDate = saveCarryValues.DUE_DATE;
                frm.module.VehicleDesc = saveCarryValues.VC_DESC;
                frm.module.VehicleNum = saveCarryValues.VC_NUM;

                for (int i = 0; i < modulePrintDetailValues.Rows.Count; i++)
                {
                    list = new CUSModulePrintPopupList();

                    list.MatID = modulePrintDetailValues.Rows[i][(int)MODULE_PRINT_DETAIL.MAT_ID].ToString();
                    list.MatDesc = modulePrintDetailValues.Rows[i][(int)MODULE_PRINT_DETAIL.MAT_DESC].ToString();
                    list.Unit = modulePrintDetailValues.Rows[i][(int)MODULE_PRINT_DETAIL.UNIT].ToString();
                    list.Qty = modulePrintDetailValues.Rows[i][(int)MODULE_PRINT_DETAIL.CNT].ToString();
                    list.Wp = modulePrintDetailValues.Rows[i][(int)MODULE_PRINT_DETAIL.WP].ToString();
                    list.Model = modulePrintDetailValues.Rows[i][(int)MODULE_PRINT_DETAIL.MAT_SHORT_DESC].ToString();

                    if (frm.module.List == null)
                        frm.module.List = new List<CUSModulePrintPopupList>();

                    frm.module.List.Add(list);
                }

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            finally
            {
                if (frm != null)
                {
                    frm.Dispose();
                }
            }
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            frmCUSProductPrintPopup frm = new frmCUSProductPrintPopup();
            CUSProductPrintPopupList list;
            modulePrintValues = new ModulePrintValues();
            modulePrintDetailValues = new DataTable();
            productPrintDetailValues = new DataTable();

            try
            {
                if (!CheckCondition(CSGC.MP_CHECK_VIEW, 2)) 
				{
					MPCF.ShowMsgBox(MPCF.GetMessage(458));
					return; 
				}

                frm.Owner = this;

                frm.product.FormName = this.Name;
                // Bind
                frm.product.Date = string.Format(MPCF.GetMessage(409), DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                frm.product.ContractNo = saveCarryValues.CONTRACT_NO;
                frm.product.DlvLocation = modulePrintValues.DLV_LOCATION;
                frm.product.Model = modulePrintDetailValues.Rows[0][(int)MODULE_PRINT_DETAIL.MAT_SHORT_DESC].ToString();
                frm.product.Qty = productPrintDetailValues.Rows.Count.ToString();

                for (int i = 0; i < productPrintDetailValues.Rows.Count; i++)
                {
                    list = new CUSProductPrintPopupList();

                    list.Seq = productPrintDetailValues.Rows[i][(int)PRODUCT_PRINT_DETAIL.SEQ].ToString();
                    list.SerialNumber = productPrintDetailValues.Rows[i][(int)PRODUCT_PRINT_DETAIL.SERIAL_NUMBER].ToString();
                    list.Voc = productPrintDetailValues.Rows[i][(int)PRODUCT_PRINT_DETAIL.VOC].ToString();
                    list.Isc = productPrintDetailValues.Rows[i][(int)PRODUCT_PRINT_DETAIL.ISC].ToString();
                    list.Pmax = productPrintDetailValues.Rows[i][(int)PRODUCT_PRINT_DETAIL.PMAX].ToString();
                    list.Vmp = productPrintDetailValues.Rows[i][(int)PRODUCT_PRINT_DETAIL.VMP].ToString();
                    list.Imp = productPrintDetailValues.Rows[i][(int)PRODUCT_PRINT_DETAIL.IMP].ToString();

                    if (frm.product.List == null)
                    {
                        frm.product.List = new List<CUSProductPrintPopupList>();
                    }

                    frm.product.List.Add(list);
                }

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
            finally
            {
                if (frm != null)
                {
                    frm.Dispose();
                }
            }
        }

        #endregion

        #region [ONLY SCAN]

        private void txtScanOnlyID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    if (string.IsNullOrEmpty(MPCF.Trim(txtScanOnlyContractNo.Text))) // 계약번호 없을 때
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(435));
                        MPCF.SetFocus(txtScanOnlyContractNo); // 포커스
                        return;
                    }

                    for (int i = 0; i < spdScanList.ActiveSheet.RowCount; i++) // 중복일 때
                    {
                        if (txtScanOnlyID.Text.ToString().Equals(spdScanList.ActiveSheet.Cells[i, (int)SCAN_LIST.SCAN_ID].Value.ToString()))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(111));
                            MPCF.SetFocus(txtScanOnlyID); // 포커스
                            txtScanOnlyID.SelectAll();
                            return;
                        }
                    }

                    spdScanList.ActiveSheet.RowCount++;
                    spdScanList.ActiveSheet.Cells[spdScanList.ActiveSheet.RowCount - 1, (int)SCAN_LIST.CONTRACT_NO].Value = MPCF.Trim(txtScanOnlyContractNo.Text);
                    spdScanList.ActiveSheet.Cells[spdScanList.ActiveSheet.RowCount - 1, (int)SCAN_LIST.SCAN_ID].Value = MPCF.Trim(txtScanOnlyID.Text);

                    txtScanOnlyQty.Text = spdScanList.ActiveSheet.RowCount.ToString(); // 스캔 수량

                    ExportScanInfoText(utbShipTap.ActiveTab.Key); // 데이터 저장

                    MPCF.SetFocus(txtScanOnlyID); // 포커스
                    txtScanOnlyID.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                MPCF.SetFocus(txtScanOnlyID); // 포커스
                txtScanOnlyID.SelectAll();
            }
        }

        private void txtScanOnlyContractNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == ENTER)
                {
                    MPCF.SetFocus(txtScanOnlyID);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                // 1.SCAN 전용 체크로직
                if (!CheckScanOnly()) return;

                // 2.초기화
                InitImport();

                // 3.데이터 저장소 초기화
                InitScan();

                // 4.데이터 호출
                ImportScanInfoText();

                // 5.데이터 입력 / 오류 데이터 무시
                InputScanList();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private bool CheckScanOnly()
        {
            if (saveValues.CONTRACT_NO == null || saveValues.CONTRACT_NO == string.Empty)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(436));
                return false;
            }

            if (saveValues.MAT_ID == null || saveValues.MAT_ID == string.Empty)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(389));
                return false;
            }

            return true;
        }

        private bool CheckScanOnlyErrorMessage(ref string message)
        {
            try
            {
                if (!CheckSaveExist()) //출하처리 이전 저장여부
                {
                    message = MPCF.GetMessage(391);
                    return false;
                }

                if (chkInputType.Checked) //팔레트 구성일때만 체크
                {
                    if (!CheckShipmentExist(VALIDATION_CASE.VIEW)) //출고여부
                    {
                        message = MPCF.GetMessage(399);
                        return false;
                    }

                    if (!CheckSaveLotExist()) //출하처리 이전 저장여부 팔레트 내의 Lot으로 재조회
                    {
                        message = MPCF.GetMessage(391);
                        return false;
                    }
                }
                else //LOT 구성일때만 체크
                {
                    if (!CheckShipLotExist()) //MWIPLOTSTS 존재여부 확인
                    {
                        message = MPCF.GetMessage(154);
                        return false;
                    }

                    //if (!CheckCreateBoxExist(VALIDATION_CASE.VIEW))//CWIPBOXLOT 팔레트 구성여부 확인
                    //{
                    //    message = MPCF.GetMessage(414);
                    //    return false;
                    //}
                }

                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        private bool AddPalletListOnlyScan(ref string message)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();

            try
            {
                if (chkInputType.Checked)
                {
                    sViewID = "VIEW_PALLET_LOT_ID_LIST";
                    i_cond_cnt = 1;

                    ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                    ArrDVC[0].sCondtion_ID = "$BOX_ID";
                    ArrDVC[0].sCondition_Value = string.Format("('{0}')", txtPalletID.Text);
                }
                else
                {
                    sViewID = "VIEW_SHIP_LOT_ID_EXIST";
                    i_cond_cnt = 2;

                    ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                    ArrDVC[0].sCondtion_ID = "$FACTORY";
                    ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                    ArrDVC[1].sCondtion_ID = "$LOT_ID";
                    ArrDVC[1].sCondition_Value = MPCF.Trim(txtPalletID.Text);
                }

                if (TPDR.DirectViewOne(null, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    message = MPCF.GetMessage(122);
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (chkInputType.Checked)
                    {
                        if (!saveValues.MAT_ID.Equals(dt.Rows[i][(int)LOT_LIST.MAT_ID].ToString()))
                        {
                            message = MPCF.GetMessage(388);
                            return false;
                        }
                    }
                    else
                    {
                        if (!saveValues.MAT_ID.Equals(dt.Rows[i][(int)NO_LOT_LIST.MAT_ID].ToString()))
                        {
                            message = MPCF.GetMessage(388);
                            return false;
                        }
                    }
                }

                spdPalletList.ActiveSheet.RowCount++;

                if (chkInputType.Checked)
                {
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.CHECKBOX].Value = false;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.PALLET_NO].Value = txtPalletID.Text;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.CREATE_DATE].Value = DateTime.Now.ToString("yyyyMMdd");
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.ORDER_ID].Value = saveValues.ORDER_ID;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.APP_NUM].Value = saveValues.APP_NUM;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.ORDER_SEQ].Value = saveValues.ORDER_SEQ;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)PALLET_LIST.MAT_ID].Value = saveValues.MAT_ID;

                    spdPalletList.ActiveSheet.Columns[(int)PALLET_LIST.ORDER_ID].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)PALLET_LIST.APP_NUM].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)PALLET_LIST.ORDER_SEQ].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)PALLET_LIST.MAT_ID].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)PALLET_LIST.STATUS].Visible = false;
                }
                else
                {
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.CHECKBOX].Value = false;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.LOT_ID].Value = txtPalletID.Text;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.CREATE_DATE].Value = DateTime.Now.ToString("yyyyMMdd");
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.ORDER_ID].Value = saveValues.ORDER_ID;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.APP_NUM].Value = saveValues.APP_NUM;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.ORDER_SEQ].Value = saveValues.ORDER_SEQ;
                    spdPalletList.ActiveSheet.Cells[spdPalletList.ActiveSheet.RowCount - 1, (int)NO_PALLET_LIST.MAT_ID].Value = saveValues.MAT_ID;

                    spdPalletList.ActiveSheet.Columns[(int)NO_PALLET_LIST.ORDER_ID].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)NO_PALLET_LIST.APP_NUM].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)NO_PALLET_LIST.ORDER_SEQ].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)NO_PALLET_LIST.MAT_ID].Visible = false;
                    spdPalletList.ActiveSheet.Columns[(int)NO_PALLET_LIST.STATUS].Visible = false;
                }

                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        private void InputScanList()
        {
            try
            {
                string message = string.Empty;
                StringBuilder sb = new StringBuilder();

                for (int r = 0; r < spdScanList.ActiveSheet.RowCount; r++)
                {
                    if (spdScanList.ActiveSheet.Cells[r, (int)SCAN_LIST.SCAN_ID].Value != null)
                    {
                        txtPalletID.Text = string.Empty;
                        txtPalletID.Text = MPCF.ToUpper(MPCF.Trim(spdScanList.ActiveSheet.Cells[r, (int)SCAN_LIST.SCAN_ID].Value.ToString()));

                        if (CheckScanOnlyErrorMessage(ref message))
                        {
                            if (AddPalletListOnlyScan(ref message)) //제품체크
                            {
                                ViewPalletLotList(); //LOT LIST 조회
                                MPCF.SetFocus(txtPalletID);
                            }
                            else
                            {
                                sb.AppendLine(string.Format("ERROR SCAN_ID : {0} / {1}", txtPalletID.Text, message));
                                MPCF.SetFocus(txtPalletID);
                                continue;
                            }
                        }
                        else
                        {
                            sb.AppendLine(string.Format("ERROR SCAN_ID : {0} / {1}", txtPalletID.Text, message));
                            MPCF.SetFocus(txtPalletID);
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (sb.Length != 0)
                    MPCF.ShowMessage(sb.ToString(), MSG_LEVEL.WARNING, true);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void InitImport()
        {
            MPCF.ClearList(this.spdPalletList);
            MPCF.ClearList(this.spdLotList);

            txtPalletID.Text = string.Empty;
            txtScanCount.Text = string.Empty;
        }

        private void ExportScanInfoText(string FileName)
        {
            File.WriteAllText(Path.Combine(Path.GetTempPath(), FileName), GetTextFromSpread(spdScanList_Sheet1, 2));
        }

        private void ImportScanInfoText()
        {
            string str = System.IO.File.ReadAllText(Path.Combine(Path.GetTempPath(), utbShipTap.Tabs[3].Key));

            spdScanList_Sheet1.Rows.Add(0, ROW); // Row 저장소 설정

            Clipboard.SetText(str);
            spdScanList_Sheet1.SetActiveCell(0, 0);
            spdScanList_Sheet1.ClipboardPaste();
        }

        private string GetTextFromSpread(FarPoint.Win.Spread.SheetView sheet, int columnCount)
        {
            int row;

            for (row = 0; row < sheet.RowCount; row++)
            {
                if (String.IsNullOrEmpty(sheet.Cells[row, 0].Text))
                    break;
            }

            if (row == 0)
                return null;

            FarPoint.Win.Spread.Model.CellRange range = new FarPoint.Win.Spread.Model.CellRange(0, 0, row, columnCount);
            sheet.ClipboardCopy(range);
            return Clipboard.GetText();
        }

        #endregion
    } 
}
