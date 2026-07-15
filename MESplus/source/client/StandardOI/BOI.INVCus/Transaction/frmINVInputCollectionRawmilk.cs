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
using System.Collections;
using BOI.OIFrx;
using BOI.INVCus.Popup;

namespace BOI.INVCus
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmINVInputCollectionRawmilk : BOIBasePopup02
    {
        #region Enum

        public enum ColWeightList
        {
            ISSUE_PLACE = 0,
            CAR_NO,
            SEQ,
            WEIGHT_DATE,
            CAR_MAT_TYPE,
            RAWMILK_MAT_ID,
            RAWMILK_MAT_VER,
            WEIGHT_IN,
            WEIGHT_OUT,
            WEIGHT_MEASURE,
            WEIGHT_REAL,
            WEIGHT_GAP,
            CAR_IN_TIME,
            CAR_OUT_TIME,
            WEIGHT_PUT,
            IQC_FLAG,
            INV_LOT_ID,
            DRIVER,
            IO_TYPE,
            INV_REQ_NO
        }
        public enum ColDetailList
        {
            SELECT = 0,
            CAR_NO,
            DAIRY_CODE,
            DAIRY_DESC,
            WEIGHT_REAL,
            WEIGHT_TIME,
            AREA_CODE,
            AREA_DESC,
            TRAN_USER_ID,
            INV_REQ_NO,
            INV_REQ_SEQ,
            WHT_SEQ,
            STATION_CODE,
            STATION_DESC

        }
        public enum tabNameList
        {
            TAB_FARM = 0,
            TAB_ASSO,
            TAB_BUY,
            TAB_TO_FACTORY,
            TAB_TEAM
        }

        #endregion

        #region Property

        // (Required) 
        private bool bIsShown = false;
        private string inv_req_no;
        private int inv_req_seq;
        //private int wht_seq;
        private string s_ioType;
        private string s_to_fac_inv_req_no;
        private string s_to_fac_factory;
        private string s_to_fac_lot_id;
        private int i_to_fac_inv_req_seq = 0;
        private double _weightSlip = 0.0d;

        public double WeightSlip
        {
            get { return _weightSlip; }
            set { _weightSlip = value; }
        }

        #endregion

        #region Constructor

        public frmINVInputCollectionRawmilk()
        {
            InitializeComponent();
        }
        public frmINVInputCollectionRawmilk(string s_arg)
        {
            InitializeComponent();
            inv_req_no = MPCF.Trim(s_arg.Split(':')[0]);
            inv_req_seq = MPCF.ToInt(s_arg.Split(':')[1]);
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

            if (!inv_req_no.Equals(null))
            {
                loadInventoryMasterInfo();
                viewInventoryDetailList(2);

            }
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


        private void boiCodeView1_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(cdvAreaCode.Text) == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(415), MSG_LEVEL.WARNING, true);
                    cdvAreaCode.Focus();
                    return;
                }

                TRSNode in_node = new TRSNode("BAS_View_Data_In");
                TRSNode out_node = new TRSNode("BAS_View_Data_Out");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_DAIRY_FARM));
                in_node.AddString("DATA_8", MPCF.Trim(((List<string>)cdvAreaCode.Tag)[3]));
                in_node.AddString("DATA_9", MPCF.Trim(((List<string>)cdvAreaCode.Tag)[0]));
                in_node.AddString("DATA_10", MPCF.Trim(((List<string>)cdvAreaCode.Tag)[1]));

                // CodeView Column Header Setup
                string[] header = new string[] { "Dairy Farm Code", "Description", "Owner" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_2" };

                // Show
                cdvDairyCode.Text = cdvDairyCode.Show(cdvDairyCode, "Dairy Farm", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvDairyCode.Text) != "")
                {
                    if (cdvDairyCode.returnDatas.Count > 0)
                    {
                        cdvDairyCode.Tag = cdvDairyCode.returnDatas[0];
                        txtFarmDairyDesc.Text = cdvDairyCode.returnDatas[1];
                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;

            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(373), MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    btnAdd.Enabled = true;
                    return;
                }
                if (updateDetailInformation('I') == false)
                {

                    return;
                }

                btnAdd.Enabled = true;
                //차량별 집유정보 목록 조회
                loadInventoryMasterInfo();
                viewInventoryDetailList(1);

            }
            catch (Exception ex)
            {
                btnAdd.Enabled = true;
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {

                if (MPCF.ShowMsgBox(MPCF.GetMessage(53), MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                if (spdInventoryDetail.Sheets[0].ActiveRowIndex < 0)
                {
                    return;
                }

                if (updateDetailInformation('D') == false)
                {
                    return;
                }
                //차량별 집유정보 목록 조회
                viewInventoryDetailList(1);
                loadInventoryMasterInfo();

                MPCF.FieldClear(tabInputType);
                if (spdInventoryDetail.Sheets[0].RowCount > 0)
                {
                    spdInventoryDetail_RowFocusChanged(0, 0);
                }

                //for (int i = 0; i < spdInventoryDetail.Sheets[0].RowCount; i++)
                //{
                //    if (Convert.ToBoolean(spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.SELECT)))
                //    {

                //        int sDelInvReqSeq = (int)spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.INV_REQ_SEQ);

                //        TRSNode in_node = new TRSNode("UPDATE_INVENTORY_DETAIL_IN");
                //        TRSNode out_node = new TRSNode("UPDATE_INVENTORY_DETAIL_OUT");
                //        in_node.Init();
                //        MPCF.SetInMsg(in_node);
                //        in_node.ProcStep = 'D';
                //        in_node.AddString("INV_REQ_NO", MPCF.Trim((string)spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.INV_REQ_NO)));
                //        in_node.AddInt("INV_REQ_SEQ", (int)spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.INV_REQ_SEQ));

                //        if (MPCF.CallService("BINV", "BINV_Update_Collection_Rawmilk", in_node, ref out_node) == false)
                //        {
                //            return;
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvAreaCode_CodeViewButtonClick(object sender, EventArgs e)
        {

            try
            {
                if (MPCF.Trim(cdvStationCode.Text) == "")
                {
                    MPCF.ShowMessage(MPCF.GetMessage(414), MSG_LEVEL.WARNING, true);
                    cdvStationCode.Focus();
                    return;
                }
                TRSNode in_node = new TRSNode("BAS_View_Data_In");
                TRSNode out_node = new TRSNode("BAS_View_Data_Out");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_DAIRY_DIRECTION));
                in_node.AddString("KEY_1", MPCF.Trim(((List<string>)cdvStationCode.Tag)[1]));

                string[] header = new string[] { "Direction Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_2", "DATA_1" };
                // Show
                cdvAreaCode.Text = cdvAreaCode.Show(cdvAreaCode, "Area Code", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                if (MPCF.Trim(cdvAreaCode.Text) != "")
                {
                    if (cdvAreaCode.returnDatas.Count > 0)
                    {
                        cdvAreaCode.Tag = cdvAreaCode.returnDatas;
                        txtFarmAreaDesc.Text = cdvAreaCode.returnDatas[2];
                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
                MPCF.FieldClear(tblFarm);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvAssoDairyCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("BAS_View_Data_In");
                TRSNode out_node = new TRSNode("BAS_View_Data_Out");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_DAIRY_COMMITTEE)); // 테이블 명 수정 필요.

                // CodeView Column Header Setup
                string[] header = new string[] { "Association Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvAssoDairyCode.Text = cdvAssoDairyCode.Show(cdvAssoDairyCode, "Association Code", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvAssoDairyCode.Text) != "")
                {
                    if (cdvAssoDairyCode.returnDatas.Count > 0)
                    {
                        cdvAssoDairyCode.Tag = cdvAssoDairyCode.returnDatas[0];
                        txtAssoDairyDesc.Text = cdvAssoDairyCode.returnDatas[1];
                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void cdvBuyAreaCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("BAS_View_Data_In");
                TRSNode out_node = new TRSNode("BAS_View_Data_Out");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_AREA)); //  const 형태로 수정

                // CodeView Column Header Setup
                string[] header = new string[] { "Area Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvBuyAreaCode.Text = cdvBuyAreaCode.Show(cdvBuyAreaCode, "Area", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvBuyAreaCode.Text) != "")
                {
                    if (cdvBuyAreaCode.returnDatas.Count > 0)
                    {
                        cdvBuyAreaCode.Tag = cdvBuyAreaCode.returnDatas[0];
                        txtBuyAreaDesc.Text = cdvBuyAreaCode.returnDatas[1];
                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void cdvFacAreaCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("WIP_View_Data_In");
                TRSNode out_node = new TRSNode("WIP_View_Data_Out");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", BIGC.B_GCM_B_FACTORY_LIST);


                // CodeView Column Header Setup
                string[] header = new string[] { "Factory", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvFacAreaCode.Text = cdvFacAreaCode.Show(cdvFacAreaCode, "Factory List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvFacAreaCode.Text) != "")
                {
                    if (cdvFacAreaCode.returnDatas.Count > 0)
                    {
                        cdvFacAreaCode.Tag = cdvFacAreaCode.returnDatas[0];
                        txtFacAreaDesc.Text = cdvFacAreaCode.returnDatas[1];
                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void cdvTeamAreaCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("BAS_View_Data_In");
                TRSNode out_node = new TRSNode("BAS_View_Data_Out");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_DEPT_TEAM)); //  const 형태로 수정

                // CodeView Column Header Setup
                string[] header = new string[] { "Team Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvTeamAreaCode.Text = cdvTeamAreaCode.Show(cdvTeamAreaCode, "From Team", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_1");

                if (MPCF.Trim(cdvTeamAreaCode.Text) != "")
                {
                    if (cdvTeamAreaCode.returnDatas.Count > 0)
                    {
                        cdvTeamAreaCode.Tag = cdvTeamAreaCode.returnDatas[0];
                        txtTeamAreaDesc.Text = cdvTeamAreaCode.returnDatas[1];
                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                if (spdInventoryDetail.Sheets[0].ActiveRowIndex < 0)
                {
                    return;
                }
                int selectRowIndex = spdInventoryDetail.Sheets[0].ActiveRowIndex;

                if (updateDetailInformation('U') == false)
                {
                    return;
                }
                //차량별 집유정보 목록 조회
                if (viewInventoryDetailList(1) != false)
                {
                    spdInventoryDetail.Sheets[0].ActiveRowIndex = selectRowIndex;
                    //spdInventoryDetail.SetActiveViewport(selectRowIndex, 0);
                    //spdInventoryDetail.selection
                };
                // DETAIL TABLE 정보 리로드.
                loadInventoryMasterInfo();

                /* 그리드에서 직접 수정하여 변경하는 소스 주석처리 */
                //for (int i = 0; i < spdInventoryDetail.Sheets[0].RowCount; i++)
                //{
                //    if (Convert.ToBoolean(spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.SELECT)))
                //    {

                //        int sDelInvReqSeq = (int)spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.INV_REQ_SEQ);


                //        TRSNode in_node = new TRSNode("UPDATE_INVENTORY_DETAIL_IN");
                //        TRSNode out_node = new TRSNode("UPDATE_INVENTORY_DETAIL_OUT");
                //        in_node.Init();
                //        MPCF.SetInMsg(in_node);
                //        in_node.ProcStep = 'U';
                //        in_node.AddString("INV_REQ_NO", MPCF.Trim((string)spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.INV_REQ_NO)));
                //        in_node.AddInt("INV_REQ_SEQ", (int)spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.INV_REQ_SEQ));
                //        //in_node.AddString("CAR_NO", MPCF.Trim(spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.CAR_NO)));
                //        in_node.AddString("DAIRY_CODE", MPCF.Trim(spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.DAIRY_CODE)));
                //        in_node.AddDouble("WEIGHT_REAL", Convert.ToDouble(spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.WEIGHT_REAL)));
                //        in_node.AddDouble("RESULT_QTY_1", Convert.ToDouble(spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.WEIGHT_REAL)));
                //        in_node.AddString("WEIGHT_TIME", MPCF.Trim(Convert.ToDateTime(spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.WEIGHT_TIME)).ToString("yyyyMMddHHmmss")));
                //        in_node.AddString("TRAN_USER_ID", MPCF.Trim(spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.TRAN_USER_ID)));
                //        in_node.AddString("AREA_CODE", MPCF.Trim(spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.AREA_CODE)));

                //        if (MPCF.CallService("BINV", "BINV_Update_Collection_Rawmilk", in_node, ref out_node) == false)
                //        {
                //            return;
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void spdInventoryDetail_RowFocusChanged(int iprvRow, int icurRow)
        {
            try
            {
                if (icurRow >= 0)
                {
                    spdInventoryDetail.Sheets[0].ActiveRowIndex = icurRow;
                    spdInventoryDetail.Sheets[0].SetActiveCell(icurRow, 0, true);
                    MPCF.FieldClear(tabInputType);

                    TRSNode row_data = new TRSNode("Row_Data_In");
                    row_data.Init();

                    row_data.AddString("DAIRY_CODE", MPCF.Trim(spdInventoryDetail.Sheets[0].GetValue(icurRow, (int)ColDetailList.DAIRY_CODE)));
                    row_data.AddString("DAIRY_DESC", MPCF.Trim(spdInventoryDetail.Sheets[0].GetValue(icurRow, (int)ColDetailList.DAIRY_DESC)));
                    row_data.AddDouble("WEIGHT_REAL", Convert.ToDouble(spdInventoryDetail.Sheets[0].GetValue(icurRow, (int)ColDetailList.WEIGHT_REAL)));
                    row_data.AddString("WEIGHT_TIME", MPCF.Trim(Convert.ToDateTime(spdInventoryDetail.Sheets[0].GetValue(icurRow, (int)ColDetailList.WEIGHT_TIME)).ToString("yyyyMMddHHmmss")));
                    row_data.AddString("TRAN_USER_ID", MPCF.Trim(spdInventoryDetail.Sheets[0].GetValue(icurRow, (int)ColDetailList.TRAN_USER_ID)));
                    row_data.AddString("AREA_CODE", MPCF.Trim(spdInventoryDetail.Sheets[0].GetValue(icurRow, (int)ColDetailList.AREA_CODE)));
                    row_data.AddString("AREA_DESC", MPCF.Trim(spdInventoryDetail.Sheets[0].GetValue(icurRow, (int)ColDetailList.AREA_DESC)));
                    row_data.AddString("STATION_CODE", MPCF.Trim(spdInventoryDetail.Sheets[0].GetValue(icurRow, (int)ColDetailList.STATION_CODE)));
                    row_data.AddString("STATION_DESC", MPCF.Trim(spdInventoryDetail.Sheets[0].GetValue(icurRow, (int)ColDetailList.STATION_DESC)));
                    inv_req_seq = MPCF.ToInt(spdInventoryDetail.Sheets[0].GetValue(icurRow, (int)ColDetailList.INV_REQ_SEQ));


                    // 선택한 로우의 정보를 데이터 입력 필드로 이동
                    viewDetailInformation(row_data);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (cdvFacAreaCode.Text == "")
                {
                    return;
                }
                frmINVOutRawmilkToOtherFacPopup frm = new frmINVOutRawmilkToOtherFacPopup();
                frm.S_factory = MPCF.Trim(cdvFacAreaCode.Text);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    dtpCollectTime2.Value = MPCF.ToDate(frm.S_weightTime);
                    numFacQty1.Value = frm.I_reqQty1;
                    s_to_fac_inv_req_no = frm.S_to_fac_inv_req_no;
                    i_to_fac_inv_req_seq = frm.I_to_fac_inv_req_seq;
                    s_to_fac_lot_id = frm.S_to_fac_lot_id;
                    s_to_fac_factory = frm.S_to_fac_factory;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void frmINVInputCollectionRawmilk_FormClosing(object sender, FormClosingEventArgs e)
        {
            GetWeightSlip();
        }

        #endregion

        #region Function

        private string viewGcmDesc(string sTableName, string sKey1)
        {
            try
            {
                TRSNode in_node = new TRSNode("BAS_View_Data_In");
                TRSNode out_node = new TRSNode("BAS_View_Data_Out");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(sTableName));
                in_node.AddString("KEY_1", MPCF.Trim(sKey1));

                if (MPCF.CallService("BAS", "BAS_View_Data", in_node, ref out_node) == false)
                {
                    return "";
                }

                string desc = out_node.GetString("DATA_1");
                return desc;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return "";
            }
        }

        private bool viewInventoryDetailList(int viewProcstep)
        {
            try
            {
                //if (!CheckConditions("VIEW"))
                //{
                //    return;
                //}

                MPCF.ClearList(this.spdInventoryDetail);

                TRSNode in_node = new TRSNode("View_Inventory_Request_Weight_List_In");
                TRSNode out_node;
                ArrayList lisDetail = new ArrayList();

                string sCarNo = string.Empty;
                string sCarFullNo = string.Empty;
                string sDairyCode = string.Empty;
                string sDairyDesc = string.Empty;
                double dReqQty = 0.0d;
                string sWeightDate = string.Empty;
                string sAreaCode = string.Empty;
                string sAreaDesc = string.Empty;
                string sTranUserId = string.Empty;
                string sInvReqNo = string.Empty;
                int iInvReqSeq = 0;
                int iWhtSeq = 0;
                string sStationCode = string.Empty;
                string sStationDesc = string.Empty;

                //sweightDate = dtpWeightDate.GetValueAsString(8);

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                if (viewProcstep == 1)
                {
                    in_node.AddString("INV_REQ_NO", MPCF.Trim(spdWeightListByCar.Sheets[0].GetValue(0, (int)ColWeightList.INV_REQ_NO)));
                }
                else if (viewProcstep == 2)
                {
                    in_node.AddString("INV_REQ_NO", inv_req_no);
                }
                in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].GetValue(0, (int)ColWeightList.SEQ)));
                //in_node.AddString("IO_TYPE", s_ioType);
                out_node = new TRSNode("View_Inventory_Request_Weight_List_Out");

                if (MPCF.CallService("BINV", "BINV_View_Inventory_Request_Weight_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                lisDetail.Add(out_node);

                int iRow = 0;
                foreach (object obj in lisDetail)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdInventoryDetail.Sheets[0].Rows.Count++;

                        sCarNo = MPCF.Trim(spdWeightListByCar.Sheets[0].GetValue(0, (int)ColWeightList.CAR_NO));
                        sDairyCode = MPCF.Trim(out_node.GetList(0)[i].GetString("DAIRY_CODE"));
                        sAreaCode = MPCF.Trim(out_node.GetList(0)[i].GetString("AREA_CODE"));
                        dReqQty = out_node.GetList(0)[i].GetDouble("WEIGHT_REAL");
                        sWeightDate = MPCF.Trim(out_node.GetList(0)[i].GetString("WEIGHT_TIME"));
                        sTranUserId = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));
                        sInvReqNo = MPCF.Trim(out_node.GetList(0)[i].GetString("INV_REQ_NO"));
                        iInvReqSeq = out_node.GetList(0)[i].GetInt("INV_REQ_SEQ");
                        sDairyDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("DAIRY_DESC"));
                        sAreaDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("AREA_DESC"));
                        iWhtSeq = out_node.GetList(0)[i].GetInt("WHT_SEQ");
                        sStationCode = MPCF.Trim(out_node.GetList(0)[i].GetString("STATION_CODE"));
                        sStationDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("STATION_DESC"));

                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.SELECT, 0);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.CAR_NO, sCarNo);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.DAIRY_CODE, sDairyCode);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.DAIRY_DESC, sDairyDesc);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.WEIGHT_REAL, dReqQty);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.WEIGHT_TIME, MPCF.ToDate(sWeightDate));
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.AREA_CODE, sAreaCode);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.AREA_DESC, sAreaDesc);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.TRAN_USER_ID, sTranUserId);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.INV_REQ_NO, sInvReqNo);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.INV_REQ_SEQ, iInvReqSeq);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.WHT_SEQ, iWhtSeq);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.STATION_CODE, sStationCode);
                        spdInventoryDetail.Sheets[0].SetValue(iRow, (int)ColDetailList.STATION_DESC, sStationDesc);

                    }
                }
                if (viewProcstep == 2 && out_node.GetList(0).Count > 0)
                {
                    spdInventoryDetail_RowFocusChanged(0, 0);
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void loadInventoryMasterInfo()
        {
            try
            {
                //if (!CheckConditions("VIEW"))
                //{
                //    return;
                //}

                MPCF.ClearList(this.spdWeightListByCar);
                TRSNode in_node = new TRSNode("View_Weight_Rawmilk_In");
                TRSNode out_node;
                ArrayList lisWeight = new ArrayList();
                string steamCode = string.Empty;
                string steamDesc = string.Empty;
                string scarMatType = string.Empty;
                string scarNo = string.Empty;
                string scarFullNo = string.Empty;
                string sioType = string.Empty;
                string sioTypeDesc = string.Empty;
                string srawMilkMatId = string.Empty;
                string srawMilkMatDesc = string.Empty;
                int irawMilkMatVer = 0;
                string sinvLotId = string.Empty;
                string sweightDate = string.Empty;
                int icarSeq = 0;
                double dweightIn = 0.0d;
                double dweightOut = 0.0d;
                double dweightMeasure = 0.0d;
                double dweightGap = 0.0d;
                double dweightReal = 0.0d;
                double dweightPut = 0.0d;
                string sinTime = string.Empty;
                string soutTime = string.Empty;
                string scarDriverId = string.Empty;
                string scarDriverName = string.Empty;
                //char ciqcFlag = ' ';
                string sinoutFlagDesc = string.Empty;
                string sinoutFlag = string.Empty;
                string sinvReqNo = string.Empty;
                string spoNo = string.Empty;
                string sinoutType = string.Empty;
                //int ipoSeq = 0;
                //sweightDate = dtpWeightDate.GetValueAsString(8);  


                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_REQ_NO", MPCF.Trim(inv_req_no));
                in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(inv_req_seq));
                out_node = new TRSNode("View_Weight_Rawmilk_Out");

                if (MPCF.CallService("BINV", "BINV_View_Weight_Rawmilk", in_node, ref out_node) == false)
                {
                    return;
                }
                lisWeight.Add(out_node);

                int iRow = 0;
                foreach (object obj in lisWeight)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdWeightListByCar.Sheets[0].Rows.Count++;

                        scarNo = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_NO"));
                        scarFullNo = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_FULL_NO"));
                        icarSeq = out_node.GetList(0)[i].GetInt("CAR_SEQ");
                        scarMatType = MPCF.Trim(out_node.GetList(0)[i].GetString("REQ_CMF_1"));
                        dweightIn = out_node.GetList(0)[i].GetDouble("WEIGHT_IN");
                        dweightOut = out_node.GetList(0)[i].GetDouble("WEIGHT_OUT");
                        dweightMeasure = Math.Abs(dweightIn - dweightOut);
                        dweightReal = out_node.GetList(0)[i].GetDouble("WEIGHT_REAL");
                        srawMilkMatId = MPCF.Trim(out_node.GetList(0)[i].GetString("RAWMILK_MAT_ID"));
                        irawMilkMatVer = out_node.GetList(0)[i].GetInt("MAT_VER");
                        srawMilkMatDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("RAWMILK_MAT_DESC"));
                        dweightGap = Math.Abs(dweightMeasure - dweightReal);
                        dweightPut = out_node.GetList(0)[i].GetDouble("WEIGHT_PUT");
                        sinTime = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_IN_TIME"));
                        soutTime = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_OUT_TIME"));
                        scarDriverId = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_DRIVER_ID"));
                        scarDriverName = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_DRIVER_NAME"));
                        sinoutType = MPCF.Trim(out_node.GetList(0)[i].GetString("IO_TYPE"));
                        //sinvLotId = MPCF.Trim(out_node.GetString("INV_LOT_ID"));
                        sinvReqNo = MPCF.Trim(out_node.GetList(0)[i].GetString("INV_REQ_NO"));
                        sweightDate = MPCF.Trim(out_node.GetList(0)[i].GetString("REQ_DATE"));

                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.ISSUE_PLACE, steamCode);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_NO, scarFullNo);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.SEQ, icarSeq);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_DATE, MPCF.ToDate(sweightDate));
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_MAT_TYPE, srawMilkMatDesc);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.RAWMILK_MAT_ID, srawMilkMatId);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.RAWMILK_MAT_VER, irawMilkMatVer);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_IN, dweightIn);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_OUT, dweightOut);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_MEASURE, dweightMeasure);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_REAL, dweightReal);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_GAP, dweightGap);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_IN_TIME, MPCF.ToDate(sinTime));
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_OUT_TIME, MPCF.ToDate(soutTime));
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_PUT, dweightPut);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.IQC_FLAG, 'Y');
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.INV_LOT_ID, sinvLotId);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.DRIVER, scarDriverName);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.IO_TYPE, sinoutType);
                        spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.INV_REQ_NO, sinvReqNo);
                    }
                }


                //spdWeightListByCar.Tag = out_node;
                //spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.ISSUE_PLACE, steamDesc);
                //spdWeightListByCar.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_NO, scarFullNo);
                //if (i == 0)
                //{
                //    spdWeightListByCar_RowFocusChanged(0, i);
                //}

                /* 입고 유형에 따른 탭 활성화 */

                tabChanegeByInOutType(MPCF.Trim(out_node.GetList(0)[0].GetString("IO_TYPE")), in_node.UserID);
                s_ioType = MPCF.Trim(out_node.GetList(0)[0].GetString("IO_TYPE"));

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }

        private void viewDetailInformation(TRSNode dataNode)
        {

            try
            {
                string ioType = spdWeightListByCar.Sheets[0].GetValue(0, (int)ColWeightList.IO_TYPE).ToString();
                MPCF.FieldClear(tabInputType);

                if (ioType == BIGC.B_INV_ACC_DETAIL_DAIRY_COMMITTEE)
                {
                    cdvAssoDairyCode.Text = dataNode.GetString("DAIRY_CODE");
                    txtAssoDairyDesc.Text = dataNode.GetString("DAIRY_DESC");
                    numAssoQty.Value = dataNode.GetDouble("WEIGHT_REAL");
                    txtTranUser2.Text = dataNode.GetString("TRAN_USER_ID");
                }
                else if (ioType == BIGC.B_INV_ACC_DETAIL_BUY)
                {
                    cdvBuyAreaCode.Text = dataNode.GetString("AREA_CODE");
                    txtBuyAreaDesc.Text = dataNode.GetString("AREA_DESC");
                    numBuyQty.Value = dataNode.GetDouble("WEIGHT_REAL");
                    txtTranUser3.Text = dataNode.GetString("TRAN_USER_ID");
                }
                else if (ioType == BIGC.B_INV_ACC_DETAIL_OTHER_FACTORY)
                {
                    cdvFacAreaCode.Text = dataNode.GetString("AREA_CODE");
                    txtFacAreaDesc.Text = dataNode.GetString("AREA_DESC");
                    dtpCollectTime2.Value = MPCF.ToDate(dataNode.GetString("WEIGHT_TIME").ToString());
                    numFacQty1.Value = dataNode.GetDouble("WEIGHT_REAL");
                    txtTranUser4.Text = dataNode.GetString("TRAN_USER_ID");
                }
                else if (ioType == BIGC.B_INV_ACC_DETAIL_TEAM)
                {
                    cdvTeamAreaCode.Text = dataNode.GetString("AREA_CODE");
                    txtTeamAreaDesc.Text = dataNode.GetString("AREA_DESC");
                    dtpCollectTime3.Value = MPCF.ToDate(dataNode.GetString("WEIGHT_TIME").ToString());
                    numTeamQty.Value = dataNode.GetDouble("WEIGHT_REAL");
                    txtTranUser5.Text = dataNode.GetString("TRAN_USER_ID");
                }
                else
                { //(ioType == BIGC.B_INV_ACC_DETAIL_DAIRY_FARM)
                    cdvAreaCode.Text = dataNode.GetString("AREA_CODE");

                    txtFarmAreaDesc.Text = dataNode.GetString("AREA_DESC");
                    cdvDairyCode.Text = dataNode.GetString("DAIRY_CODE");
                    txtFarmDairyDesc.Text = dataNode.GetString("DAIRY_DESC");
                    dtpCollectTime.Value = MPCF.ToDate(dataNode.GetString("WEIGHT_TIME").ToString());
                    numReqQty1.Value = dataNode.GetDouble("WEIGHT_REAL");
                    txtTranUser1.Text = dataNode.GetString("TRAN_USER_ID");
                    cdvStationCode.Text = MPCF.Trim(dataNode.GetString("STATION_CODE"));
                    txtStationDesc.Text = MPCF.Trim(dataNode.GetString("STATION_DESC"));
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }

        }

        private void tabChanegeByInOutType(string ioType, string tranUserId)
        {
            TRSNode dataNode = new TRSNode("Detail_Info");


            int activeTabNum = 0;
            for (int i = 0; i < tabInputType.Tabs.Count; i++)
            {
                tabInputType.Tabs[i].Visible = false;
                tabInputType.Tabs[i].Enabled = false;
            }

            if (ioType == BIGC.B_INV_ACC_DETAIL_DAIRY_COMMITTEE)
            {
                activeTabNum = (int)tabNameList.TAB_ASSO;
                txtTranUser2.Text = tranUserId;
                spdInventoryDetail.Sheets[0].Columns[(int)ColDetailList.AREA_CODE].Visible = false;
                spdInventoryDetail.Sheets[0].Columns[(int)ColDetailList.AREA_DESC].Visible = false;
            }
            else if (ioType == BIGC.B_INV_ACC_DETAIL_BUY)
            {
                activeTabNum = (int)tabNameList.TAB_BUY;
                txtTranUser3.Text = tranUserId;
                spdInventoryDetail.Sheets[0].Columns[(int)ColDetailList.DAIRY_CODE].Visible = false;
                spdInventoryDetail.Sheets[0].Columns[(int)ColDetailList.DAIRY_DESC].Visible = false;
            }
            else if (ioType == BIGC.B_INV_ACC_DETAIL_OTHER_FACTORY)
            {
                activeTabNum = (int)tabNameList.TAB_TO_FACTORY;
                dtpCollectTime2.SetValueAsDateTime(DateTime.Now);
                txtTranUser4.Text = tranUserId;
                spdInventoryDetail.Sheets[0].Columns[(int)ColDetailList.DAIRY_CODE].Visible = false;
                spdInventoryDetail.Sheets[0].Columns[(int)ColDetailList.DAIRY_DESC].Visible = false;
            }
            else if (ioType == BIGC.B_INV_ACC_DETAIL_TEAM)
            {
                activeTabNum = (int)tabNameList.TAB_TEAM;
                dtpCollectTime3.SetValueAsDateTime(DateTime.Now);
                txtTranUser5.Text = tranUserId;
                spdInventoryDetail.Sheets[0].Columns[(int)ColDetailList.DAIRY_CODE].Visible = false;
                spdInventoryDetail.Sheets[0].Columns[(int)ColDetailList.DAIRY_DESC].Visible = false;
            }
            else
            { //(ioType == BIGC.B_INV_ACC_DETAIL_DAIRY_FARM)
                activeTabNum = (int)tabNameList.TAB_FARM;
                dtpCollectTime.SetValueAsDateTime(DateTime.Now);
                txtTranUser1.Text = tranUserId;
            }
            tabInputType.Tabs[activeTabNum].Visible = true;
            tabInputType.Tabs[activeTabNum].Enabled = true;
        }

        private bool CheckConditions(int inOutType)
        {
            try
            {
                if (inOutType.Equals((int)tabNameList.TAB_FARM))
                {
                    if (!MPCF.CheckValue(cdvAreaCode, true))
                    {
                        return false;
                    }
                    if (!MPCF.CheckValue(cdvDairyCode, true))
                    {
                        return false;
                    }
                    if (!MPCF.CheckValue(dtpCollectTime, true))
                    {
                        return false;
                    }
                    if (MPCF.ToDbl(numReqQty1.Value) <= 0.0d)
                    {
                        numReqQty1.Focus();
                        return false;
                    }
                    if (!MPCF.CheckValue(txtTranUser1, true))
                    {
                        return false;
                    }
                }
                else if (inOutType.Equals((int)tabNameList.TAB_ASSO))
                {
                    if (!MPCF.CheckValue(cdvAssoDairyCode, true))
                    {
                        return false;
                    }
                    if (MPCF.ToDbl(numAssoQty.Value) <= 0.0d)
                    {
                        numAssoQty.Focus();
                        return false;
                    }
                    if (!MPCF.CheckValue(txtTranUser2, true))
                    {
                        return false;
                    }

                }
                else if (inOutType.Equals((int)tabNameList.TAB_BUY))
                {
                    if (!MPCF.CheckValue(cdvBuyAreaCode, true))
                    {
                        return false;
                    }
                    if (MPCF.ToDbl(numBuyQty.Value) <= 0.0d)
                    {
                        numBuyQty.Focus();
                        return false;
                    }
                    if (!MPCF.CheckValue(txtTranUser3, true))
                    {
                        return false;
                    }
                }
                else if (inOutType.Equals((int)tabNameList.TAB_TO_FACTORY))
                {
                    if (!MPCF.CheckValue(cdvFacAreaCode, true))
                    {
                        return false;
                    }
                    if (!MPCF.CheckValue(dtpCollectTime2, true))
                    {
                        return false;
                    }
                    if (MPCF.ToDbl(numFacQty1.Value) <= 0.0d)
                    {
                        numFacQty1.Focus();
                        return false;
                    }
                    if (!MPCF.CheckValue(txtTranUser4, true))
                    {
                        return false;
                    }
                }
                else if (inOutType.Equals((int)tabNameList.TAB_TEAM))
                {
                    if (!MPCF.CheckValue(cdvTeamAreaCode, true))
                    {
                        return false;
                    }
                    if (!MPCF.CheckValue(dtpCollectTime3, true))
                    {
                        return false;
                    }
                    if (MPCF.ToDbl(numTeamQty.Value) <= 0.0d)
                    {
                        numTeamQty.Focus();
                        return false;
                    }
                    if (!MPCF.CheckValue(txtTranUser5, true))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool updateDetailInformation(char cStep)
        {
            try
            {
                TRSNode in_node = new TRSNode("UPDATE_INVENTORY_DETAIL_IN");
                TRSNode out_node = new TRSNode("UPDATE_INVENTORY_DETAIL_OUT");
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = cStep;
                in_node.AddString("INV_REQ_NO", MPCF.Trim(spdWeightListByCar.Sheets[0].GetValue(0, (int)ColWeightList.INV_REQ_NO)));
                in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(spdWeightListByCar.Sheets[0].GetValue(0, (int)ColWeightList.SEQ)));
                in_node.AddString("MAT_ID", MPCF.Trim(spdWeightListByCar.Sheets[0].GetValue(0, (int)ColWeightList.RAWMILK_MAT_ID)));
                in_node.AddInt("MAT_VER", MPCF.ToInt(spdWeightListByCar.Sheets[0].GetValue(0, (int)ColWeightList.RAWMILK_MAT_VER)));
                in_node.AddString("IO_TYPE", MPCF.Trim(spdWeightListByCar.Sheets[0].GetValue(0, (int)ColWeightList.IO_TYPE)));

                if (MPGC.MP_STEP_UPDATE == cStep || MPGC.MP_STEP_DELETE == cStep)
                {
                    in_node.AddInt("WHT_SEQ", spdInventoryDetail.Sheets[0].Cells[spdInventoryDetail.Sheets[0].ActiveRowIndex, (int)ColDetailList.WHT_SEQ].Value);
                }
                if (tabInputType.ActiveTab.Index == (int)tabNameList.TAB_FARM)
                {
                    if (!CheckConditions((int)tabNameList.TAB_FARM))
                    {
                        btnAdd.Enabled = true;
                        return false;
                    }
                    in_node.AddString("AREA_CODE", MPCF.Trim(cdvAreaCode.Text));
                    in_node.AddString("DAIRY_CODE", MPCF.Trim(cdvDairyCode.Text));
                    in_node.AddString("WEIGHT_TIME", MPCF.Trim(dtpCollectTime.GetValueAsString(8)) + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
                    in_node.AddDouble("WEIGHT_REAL", MPCF.ToDbl(numReqQty1.Value));
                    in_node.AddString("TRAN_USER_ID", txtTranUser1.Text);
                    in_node.AddString("REQ_WHT_CMF_1", MPCF.Trim((cdvStationCode.Text)));
                }
                else if (tabInputType.ActiveTab.Index == (int)tabNameList.TAB_ASSO)
                {
                    if (!CheckConditions((int)tabNameList.TAB_ASSO))
                    {
                        btnAdd.Enabled = true;
                        return false;
                    }
                    in_node.AddString("DAIRY_CODE", MPCF.Trim(cdvAssoDairyCode.Text));
                    in_node.AddDouble("WEIGHT_REAL", MPCF.ToDbl(numAssoQty.Value));
                    in_node.AddString("TRAN_USER_ID", txtTranUser2.Text);
                }
                else if (tabInputType.ActiveTab.Index == (int)tabNameList.TAB_BUY)
                {
                    if (!CheckConditions((int)tabNameList.TAB_BUY))
                    {
                        btnAdd.Enabled = true;
                        return false;
                    }
                    in_node.AddString("AREA_CODE", MPCF.Trim(cdvBuyAreaCode.Text));
                    in_node.AddDouble("WEIGHT_REAL", MPCF.ToDbl(numBuyQty.Value));
                    in_node.AddString("TRAN_USER_ID", txtTranUser3.Text);
                }
                else if (tabInputType.ActiveTab.Index == (int)tabNameList.TAB_TO_FACTORY)
                {
                    if (!CheckConditions((int)tabNameList.TAB_TO_FACTORY))
                    {
                        btnAdd.Enabled = true;
                        return false;
                    }
                    in_node.AddString("AREA_CODE", MPCF.Trim(cdvFacAreaCode.Text));
                    in_node.AddString("WEIGHT_TIME", MPCF.Trim(dtpCollectTime2.GetValueAsString(8)) + "000000");
                    in_node.AddDouble("WEIGHT_REAL", MPCF.ToDbl(numFacQty1.Value));
                    in_node.AddString("TRAN_USER_ID", txtTranUser4.Text);
                    in_node.AddChar("TO_FAC_FLAG", 'Y');
                    in_node.AddString("TO_FAC_FACTORY", MPCF.Trim(s_to_fac_factory));
                    in_node.AddString("TO_FAC_LOT_ID", MPCF.Trim(s_to_fac_lot_id));
                    in_node.AddString("TO_FAC_INV_REQ_NO", MPCF.Trim(s_to_fac_inv_req_no));
                    in_node.AddInt("TO_FAC_INV_REQ_SEQ", i_to_fac_inv_req_seq);
                }
                else if (tabInputType.ActiveTab.Index == (int)tabNameList.TAB_TEAM)
                {
                    if (!CheckConditions((int)tabNameList.TAB_TEAM))
                    {
                        btnAdd.Enabled = true;
                        return false;
                    }
                    in_node.AddString("AREA_CODE", MPCF.Trim(cdvTeamAreaCode.Text));
                    in_node.AddString("WEIGHT_TIME", MPCF.Trim(dtpCollectTime3.GetValueAsString(8)) + "000000");
                    in_node.AddDouble("WEIGHT_REAL", MPCF.ToDbl(numTeamQty.Value));
                    in_node.AddString("TRAN_USER_ID", txtTranUser5.Text);
                }

                if (MPCF.CallService("BINV", "BINV_Update_Collection_Rawmilk", in_node, ref out_node, false, true) == false)
                {
                    btnAdd.Enabled = true;
                    return false;
                }

                btnAdd.Enabled = true;
                return true;
            }
            catch (Exception ex)
            {
                btnAdd.Enabled = true;
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void GetWeightSlip()
        {
            _weightSlip = 0.0;
            for (int i = 0; i < spdInventoryDetail.Sheets[0].RowCount; i++)
            {
                _weightSlip += MPCF.ToDbl(spdInventoryDetail.Sheets[0].GetValue(i, (int)ColDetailList.WEIGHT_REAL));
            }
        }


        #endregion

        private void cdvStationCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("BAS_View_Data_In");
                TRSNode out_node = new TRSNode("BAS_View_Data_Out");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_DAIRY_MILK_STATION));

                // CodeView Column Header Setup
                string[] header = new string[] { "Factory Code", "Station Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "KEY_2", "DATA_1" };

                // Show
                cdvStationCode.Text = cdvStationCode.Show(cdvStationCode, "Area", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "KEY_2");

                if (MPCF.Trim(cdvStationCode.Text) != "")
                {
                    if (cdvStationCode.returnDatas.Count > 0)
                    {
                        cdvStationCode.Tag = cdvStationCode.returnDatas;
                        txtStationDesc.Text = cdvStationCode.returnDatas[2];

                    }

                    //MPCF.SetFocus(txtWeightIn);
                    MPCF.FieldClear(tblAreaCode);
                    MPCF.FieldClear(tblFarm);
                }
                /// 여기입력.
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }
    }
}
