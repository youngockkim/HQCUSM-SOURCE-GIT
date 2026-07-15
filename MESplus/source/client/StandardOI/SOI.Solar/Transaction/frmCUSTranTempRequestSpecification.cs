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
    public partial class frmCUSTranTempRequestSpecification : SOIBaseForm03
    {
        #region [Property]

        SaveValues saveValues;
        SaveCarryValues saveCarryValues;

        private bool bIsShown = false;

        #endregion

        public frmCUSTranTempRequestSpecification()
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
            FACTORY,
            SHIP_ID,
            SHP_DATE,
            CONTRACT_NO,
            MAT_ID,
            MAT_VER,
            SHIP_QTY,
            ORDER_DATE,
            ORDER_ID,
            APP_NUM,
            ORDER_SEQ
        }

        #endregion

        #region [Variable Definition]

        #endregion

        #region [FormDefinition]

        private void initCtrl()
        {
            try
            {
                MPCF.ConvertCaption(this);
                MPCF.FieldClear(this);
                this.dtpFrom.Value = DateTime.Now.AddDays(-1);
                this.dtpTo.Value = DateTime.Now;
                this.dtpTemFrom.Value = DateTime.Now.AddDays(-1);
                this.dtpTemTo.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        #region [Function Definition]

        private void Initialize()
        {
            MPCF.ClearList(this.spdShipList);
            MPCF.ClearList(this.spdShipMatList);
            saveValues = new SaveValues();
        }

        private void InitializeCarry()
        {
            MPCF.ClearList(this.spdTargetMatList);
            saveCarryValues = new SaveCarryValues();
        }

        private bool CheckCondition(string FuncName)
        {
            try
            {
                switch (FuncName)
                {
                    case CSGC.MP_CHECK_VIEW:

                        DateTime dtpFromOut = new DateTime();

                        if (dtpFrom.Value != null)
                        {
                            if (DateTime.TryParse(dtpFrom.Value.ToString(), out dtpFromOut) == true){}
                        }

                        DateTime dtpToOut = new DateTime();

                        if (dtpTo.Value != null)
                        {
                            if (DateTime.TryParse(dtpTo.Value.ToString(), out dtpToOut) == true){}
                        }

                        if (this.dtpFrom.GetValueAsDateTime() > this.dtpTo.GetValueAsDateTime())
                        {
                            this.dtpFrom.SetValueAsDateTime(dtpToOut.AddDays(-1));
                            MPCF.ShowMsgBox(MPCF.GetMessage(371));
                        }

                        break;

                    case CSGC.MP_CHECK_CREATE:

                        if (spdShipList.ActiveSheet.RowCount == 0 || saveValues.CONTRACT_NO == null || saveValues.ORDER_ID == null)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(393));
                            return false;
                        }

                        //if (spdTargetMatList.ActiveSheet.RowCount == 0 || saveCarryValues.CONTRACT_NO == null || saveCarryValues.ORDER_ID == null)
                        //{
                        //    MPCF.ShowMsgBox(MPCF.GetMessage(394));
                        //    return false;
                        //}

                        if (!saveValues.CONTRACT_NO.ToString().Equals(saveCarryValues.CONTRACT_NO.ToString()))
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(395));
                            return false;
                        }

                        break;

                    case CSGC.MP_CHECK_UPDATE:

                        break;

                    case CSGC.MP_CHECK_DELETE:

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

        private void SetShipSpreadLabel()
        {
            //ORDER_DATE, ORDER_ID는 MESCaption을 사용하지 않음 -> ORDER_ID는 작업 지시로 번역됨
            spdShipList.ActiveSheet.Columns[(int)SHIP_LIST.ORDER_DATE].Label = "의뢰일자";
            spdShipList.ActiveSheet.Columns[(int)SHIP_LIST.ORDER_ID].Label = "일련번호";
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

        private bool ViewShipmentMaterialList()
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

                if (spdShipMatList.ActiveSheet.RowCount == 1)
                {
                    saveValues.ORDER_SEQ = spdShipMatList.ActiveSheet.Cells[0, (int)SHIP_MAT_LIST.ORDER_SEQ].Value.ToString().Replace("-", "");
                    saveValues.CONTRACT_SEQ = spdShipMatList.ActiveSheet.Cells[0, (int)SHIP_MAT_LIST.CONTRACT_SEQ].Value.ToString();
                    saveValues.SHP_REQ_DATE = spdShipMatList.ActiveSheet.Cells[0, (int)SHIP_MAT_LIST.SHP_REQ_DATE].Value.ToString().Replace("-", "");
                }
                else
                {
                    saveValues.ORDER_SEQ = "";
                    saveValues.CONTRACT_SEQ = "";
                    saveValues.SHP_REQ_DATE = "";
                }

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

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            MPCF.ClearList(this.spdTargetMatList);

            try
            {
                //sViewID = "VIEW_TEMPORARY_TARGET_MAT_LIST";
                sViewID = "VIEW_TEMP_TARGET_MAT_LIST_01";
                i_cond_cnt = 5;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$FROM_DATE";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.dtpTemFrom.GetValueAsString(8));

                ArrDVC[2].sCondtion_ID = "$TO_DATE";
                ArrDVC[2].sCondition_Value = MPCF.Trim(this.dtpTemTo.GetValueAsString(8));

                ArrDVC[3].sCondtion_ID = "$CONTRACT_NO";
                ArrDVC[3].sCondition_Value = MPCF.Trim(txtContractSecNo.Text.Replace("-", ""));

                ArrDVC[4].sCondtion_ID = "$MAT_ID";
                ArrDVC[4].sCondition_Value = MPCF.Trim(cdvMaterialSec.Text);

                if (TPDR.DirectViewOne(this.spdTargetMatList, sViewID, ref dt, false, false, ArrDVC, true) == false)
                {
                    if (dt != null) { dt.Dispose(); }
                    GC.Collect();
                    return false;
                }

                spdTargetMatList.ActiveSheet.Columns[(int)TARGET_MAT_LIST.FACTORY].Visible = false;
                spdTargetMatList.ActiveSheet.Columns[(int)TARGET_MAT_LIST.ORDER_DATE].Visible = false;
                spdTargetMatList.ActiveSheet.Columns[(int)TARGET_MAT_LIST.ORDER_ID].Visible = false;
                spdTargetMatList.ActiveSheet.Columns[(int)TARGET_MAT_LIST.APP_NUM].Visible = false;     // MES 결재 순번은 항상 값으므로 필요 없음
                spdTargetMatList.ActiveSheet.Columns[(int)TARGET_MAT_LIST.ORDER_SEQ].Visible = false;

                MPCF.FitColumnHeader(spdTargetMatList);

                if (spdTargetMatList.ActiveSheet.RowCount == 1)
                {
                    saveCarryValues.FACTORY = spdTargetMatList.ActiveSheet.Cells[0, (int)TARGET_MAT_LIST.FACTORY].Value.ToString();
                    saveCarryValues.SHIP_ID = spdTargetMatList.ActiveSheet.Cells[0, (int)TARGET_MAT_LIST.SHIP_ID].Value.ToString();
                    saveCarryValues.ORDER_DATE = spdTargetMatList.ActiveSheet.Cells[0, (int)TARGET_MAT_LIST.ORDER_DATE].Value.ToString().Replace("-", "");
                    saveCarryValues.SHP_DATE = spdTargetMatList.ActiveSheet.Cells[0, (int)TARGET_MAT_LIST.SHP_DATE].Value.ToString().Replace("-", "");
                    saveCarryValues.CONTRACT_NO = spdTargetMatList.ActiveSheet.Cells[0, (int)TARGET_MAT_LIST.CONTRACT_NO].Value.ToString().Replace("-", "");
                }
                else
                {
                    saveCarryValues.FACTORY = "";
                    saveCarryValues.SHIP_ID = "";
                    saveCarryValues.ORDER_DATE = "";
                    saveCarryValues.SHP_DATE = "";
                    saveCarryValues.CONTRACT_NO = "";
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }

        private bool SaveProductShipment()
        {
            TRSNode in_node = new TRSNode("CUS_UPDATE_SHIPMENT_PRODUCT_IN");
            TRSNode out_node = new TRSNode("CUS_UPDATE_SHIPMENT_PRODUCT_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_CONFIRM;

                //긴급 제품 출고 리스트 KEY
                in_node.AddString("TEMP_SHIP_ID", MPCF.Trim(saveCarryValues.SHIP_ID));
                in_node.AddString("TEMP_ORDER_DATE", MPCF.Trim(saveCarryValues.ORDER_DATE).Replace("-", ""));
                in_node.AddString("TEMP_SHP_DATE", MPCF.Trim(saveCarryValues.SHP_DATE).Replace("-", ""));
                in_node.AddString("TEMP_CONTRACT_NO", MPCF.Trim(saveCarryValues.CONTRACT_NO).Replace("-", ""));

                //출고의뢰 항목 값
                in_node.AddString("ORDER_DATE", MPCF.Trim(saveValues.ORDER_DATE));
                in_node.AddString("ORDER_ID", MPCF.Trim(saveValues.ORDER_ID));
                in_node.AddString("SHP_REQ_DATE", MPCF.Trim(saveValues.SHP_REQ_DATE));
                in_node.AddString("CONTRACT_NO", MPCF.Trim(saveValues.CONTRACT_NO));
                in_node.AddInt("ORDER_SEQ", MPCF.Trim(saveValues.ORDER_SEQ));
                in_node.AddString("CONTRACT_SEQ", MPCF.Trim(saveValues.CONTRACT_SEQ));

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
        
        #endregion

        #region [Event Definition]

        private void frmCUSTranTempRequestSpecification_Load(object sender, EventArgs e)
        {
            initCtrl();
        }

        private void frmCUSTranTempRequestSpecification_Shown(object sender, EventArgs e)
        {
            if (bIsShown == false)
            {
                bIsShown = true;

                MPCF.SetFocus(txtContractNo);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!CheckCondition(CSGC.MP_CHECK_VIEW)) { return; }

            if (sender.Equals(btnView))
            {
                Initialize();
                ViewShipmentList();
            }
            else if (sender.Equals(btnCarryView))
            {
                ViewTargetMatList();
            }
        }

        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

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

        private void cdvMaterialSec_CodeViewButtonClick(object sender, EventArgs e)
        {
            int i_cond_cnt;
            string sViewID = string.Empty;

            TPDR.DirectViewCond[] ArrDVC;
            DataTable dt = new DataTable();
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

            try
            {
                sViewID = "VIEW_WORK_ORDER_MAT_LIST";
                i_cond_cnt = 2;

                ArrDVC = new TPDR.DirectViewCond[i_cond_cnt];
                ArrDVC[0].sCondtion_ID = "$FACTORY";
                ArrDVC[0].sCondition_Value = MPGV.gsFactory;

                ArrDVC[1].sCondtion_ID = "$MAT_ID";
                ArrDVC[1].sCondition_Value = MPCF.Trim(this.cdvMaterialSec.Text);

                string[] header = new string[] { "Material ID", "Material Desc" };
                string[] display = new string[] { "MAT_ID", "MAT_DESC" };

                cdvMaterialSec.Text = cdvMaterialSec.Show(cdvMaterial, "Material List", sViewID, ArrDVC, display, header, "MAT_ID", -1);

                if (cdvMaterialSec.returnDatas != null && cdvMaterialSec.returnDatas.Count > 0)
                {
                    cdvMaterialSec.Text = cdvMaterialSec.returnDatas[0];
                    this.txtMaterialSecDesc.Text = cdvMaterialSec.returnDatas[1];
                }
                else
                {
                    this.txtMaterialSecDesc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void spdShipList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            saveValues.ORDER_DATE = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.ORDER_DATE].Value.ToString().Replace("-", "");
            saveValues.ORDER_ID = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.ORDER_ID].Value.ToString();
            saveValues.SHP_REQ_DATE = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.SHP_REQ_DATE].Value.ToString().Replace("-", "");
            saveValues.CONTRACT_NO = spdShipList.ActiveSheet.Cells[spdShipList.ActiveSheet.ActiveRowIndex, (int)SHIP_LIST.CONTRACT_NO].Value.ToString().Replace("-", "");

            ViewShipmentMaterialList();
        }

        private void spdShipMatList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            saveValues.ORDER_SEQ = spdShipMatList.ActiveSheet.Cells[spdShipMatList.ActiveSheet.ActiveRowIndex, (int)SHIP_MAT_LIST.ORDER_SEQ].Value.ToString().Replace("-", "");
            saveValues.CONTRACT_SEQ = spdShipMatList.ActiveSheet.Cells[spdShipMatList.ActiveSheet.ActiveRowIndex, (int)SHIP_MAT_LIST.CONTRACT_SEQ].Value.ToString();
            saveValues.SHP_REQ_DATE = spdShipMatList.ActiveSheet.Cells[spdShipMatList.ActiveSheet.ActiveRowIndex, (int)SHIP_MAT_LIST.SHP_REQ_DATE].Value.ToString().Replace("-", "");
        }

        private void spdTargetMatList_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            saveCarryValues.FACTORY = spdTargetMatList.ActiveSheet.Cells[spdTargetMatList.ActiveSheet.ActiveRowIndex, (int)TARGET_MAT_LIST.FACTORY].Value.ToString();
            saveCarryValues.SHIP_ID = spdTargetMatList.ActiveSheet.Cells[spdTargetMatList.ActiveSheet.ActiveRowIndex, (int)TARGET_MAT_LIST.SHIP_ID].Value.ToString();
            saveCarryValues.ORDER_DATE = spdTargetMatList.ActiveSheet.Cells[spdTargetMatList.ActiveSheet.ActiveRowIndex, (int)TARGET_MAT_LIST.ORDER_DATE].Value.ToString().Replace("-", "");
            saveCarryValues.SHP_DATE = spdTargetMatList.ActiveSheet.Cells[spdTargetMatList.ActiveSheet.ActiveRowIndex, (int)TARGET_MAT_LIST.SHP_DATE].Value.ToString().Replace("-", "");
            saveCarryValues.CONTRACT_NO = spdTargetMatList.ActiveSheet.Cells[spdTargetMatList.ActiveSheet.ActiveRowIndex, (int)TARGET_MAT_LIST.CONTRACT_NO].Value.ToString().Replace("-", "");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (CheckCondition(CSGC.MP_CHECK_CREATE))
            {
                if (SaveProductShipment())
                {
                    saveCarryValues = new SaveCarryValues();
                    Initialize();
                    ViewTargetMatList();
                    ViewShipmentList();
                }
            }
        }

        #endregion        

    } 
}
