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
using System.Collections;
using BOI.OIFrx;

namespace BOI.INVCus.Popup
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmINVOutRawmilkToOtherFacPopup : frmPopupBase
    {


        #region enum
        public enum ColWeightList
        {
            SELECT = 0,
            ISSUE_PLACE,
            CAR_NO,
            SEQ,
            WEIGHT_DATE,
            CAR_MAT_TYPE,
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
            INOUT_FLAG,
            INV_REQ_NO,
            INV_REQ_SEQ,
            PO_NO,
            PO_SEQ,
            IO_TYPE,
            IUD_FLAG
        }
        #endregion

        #region Property

        /// <summary>
        /// (Required) Show form after drawing is finished.
        /// Form 내에 있는 모든 컨트롤들의 Rendering을 완료한 이후에 Form을 표시한다.
        /// Load Event 이후에 발생하므로 Focus 등의 이벤트들은 Activated 이벤트에 할당해야 한다.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x02000000;
                return createParams;
            }
        }

        private string s_areaCode;

        public string S_areaCode
        {
            get { return s_areaCode; }
            set { s_areaCode = value; }
        }
        private string s_weightTime;

        public string S_weightTime
        {
            get { return s_weightTime; }
            set { s_weightTime = value; }
        }
        private double i_reqQty1;

        public double I_reqQty1
        {
            get { return i_reqQty1; }
            set { i_reqQty1 = value; }
        }
        private string s_tranUserId;

        public string S_tranUserId
        {
            get { return s_tranUserId; }
            set { s_tranUserId = value; }
        }
        private string s_factory;

        public string S_factory
        {
            get { return s_factory; }
            set { s_factory = value; }
        }
        private string s_to_fac_inv_req_no;

        public string S_to_fac_inv_req_no
        {
            get { return s_to_fac_inv_req_no; }
            set { s_to_fac_inv_req_no = value; }
        }

        private int i_to_fac_inv_req_seq;

        public int I_to_fac_inv_req_seq
        {
            get { return i_to_fac_inv_req_seq; }
            set { i_to_fac_inv_req_seq = value; }
        }

        private string s_to_fac_lot_id;

        public string S_to_fac_lot_id
        {
            get { return s_to_fac_lot_id; }
            set { s_to_fac_lot_id = value; }
        }

        private string s_to_fac_factory;

        public string S_to_fac_factory
        {
            get { return s_to_fac_factory; }
            set { s_to_fac_factory = value; }
        }




        #endregion

        #region Constructor

        public frmINVOutRawmilkToOtherFacPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// - Form Activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempBOIPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            // 활성화
            this.Activate();
            if (this.viewInventoryReqMasterList() == false) {
                return;
            }
        }

        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 종료
            this.Close();
        }

        #endregion

        #region Function

        //private bool viewInventoryReqMasterList(string sFactory) {
        private bool viewInventoryReqMasterList()
        {    
            try
            {
                //if (!CheckConditions("VIEW"))
                //{
                //    return false;
                //}

                MPCF.ClearList(this.spdWeightListOfFactory);

                TRSNode in_node = new TRSNode("View_Weight_Rawmilk_List_In");
                TRSNode out_node;
                ArrayList lisWeight = new ArrayList();
                string sfactory = string.Empty;
                string sissuePlace = string.Empty;
                string sissuePalceDesc = string.Empty;
                string scarNo = string.Empty;
                string scarFullNo = string.Empty;
                
                string sioType = string.Empty;
                string sioTypeDesc = string.Empty;

                string sweightDate = string.Empty;
                string srawMilkMatId = string.Empty;
                string srawMilkMatDesc = string.Empty;
                string sinvLotId = string.Empty;
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
                char ciqcFlag = ' ';
                string sinoutFlagDesc = string.Empty;
                string sinoutFlag = string.Empty;
                string sinvReqNo = string.Empty;
                int iinvReqSeq = 0;
                string spoNo = string.Empty;
                int ipoSeq = 0;
                //sweightDate = dtpWeightDate.GetValueAsString(8);                                   

                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '2';
                
                in_node.AddString("REQ_TYPE", MPCF.Trim(BIGC.B_REQ_TYPE_RAWMILK));
                in_node.AddString("IO_TYPE", MPCF.Trim(BIGC.B_INV_ACC_DETAIL_ISS_FACTORY));
                in_node.AddChar("REQ_STATUS", BIGC.B_REQ_STATUS_CONFIRM);
                in_node.AddChar("IO_FLAG", BIGC.B_IO_FLAG_OUT);
                in_node.AddString("CUST_ID", MPCF.Trim(in_node.Factory));
                //in_node.Factory = MPCF.Trim(sFactory);

                out_node = new TRSNode("View_Weight_Rawmilk_List_Out");

                if (MPCF.CallService("BINV", "BINV_View_Weight_Rawmilk_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                lisWeight.Add(out_node);

                int iRow = 0;
                foreach (object obj in lisWeight)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    for (int i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        iRow = spdWeightListOfFactory.Sheets[0].Rows.Count++;
                        sfactory = MPCF.Trim(out_node.GetList(0)[i].GetString("FACTORY"));
                        sissuePlace = MPCF.Trim(out_node.GetList(0)[i].GetString("CUST_ID"));
                        sissuePalceDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("CUST_DESC"));
                        scarNo = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_NO"));
                        scarFullNo = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_FULL_NO"));
                        icarSeq = out_node.GetList(0)[i].GetInt("CAR_SEQ");
                        sioType = MPCF.Trim(out_node.GetList(0)[i].GetString("IO_TYPE"));
                        sioTypeDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("IO_TYPE_DESC"));
                        srawMilkMatId = MPCF.Trim(out_node.GetList(0)[i].GetString("RAWMILK_MAT_ID"));
                        srawMilkMatDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("RAWMILK_MAT_DESC"));
                        dweightIn = out_node.GetList(0)[i].GetDouble("WEIGHT_IN");
                        dweightOut = out_node.GetList(0)[i].GetDouble("WEIGHT_OUT");
                        dweightMeasure = out_node.GetList(0)[i].GetDouble("WEIGHT_MEASURE");
                        dweightReal = out_node.GetList(0)[i].GetDouble("WEIGHT_REAL");
                        dweightGap = Math.Abs(dweightMeasure - dweightReal);
                        dweightPut = out_node.GetList(0)[i].GetDouble("WEIGHT_PUT");
                        sinTime = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_IN_TIME"));
                        soutTime = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_OUT_TIME"));
                        scarDriverId = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_DRIVER_ID"));
                        scarDriverName = MPCF.Trim(out_node.GetList(0)[i].GetString("CAR_DRIVER_NAME"));
                        ciqcFlag = out_node.GetList(0)[i].GetChar("IQC_FLAG");
                        sinoutFlagDesc = MPCF.Trim(out_node.GetList(0)[i].GetString("IO_FLAG_DESC"));
                        sinoutFlag = MPCF.Trim(out_node.GetList(0)[i].GetChar("IO_FLAG"));
                        sinvLotId = MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID"));
                        sinvReqNo = MPCF.Trim(out_node.GetList(0)[i].GetString("INV_REQ_NO"));
                        iinvReqSeq = out_node.GetList(0)[i].GetInt("INV_REQ_SEQ");
                        spoNo = MPCF.Trim(out_node.GetList(0)[i].GetString("ERP_REQ_NO"));
                        ipoSeq = out_node.GetList(0)[i].GetInt("ERP_REQ_SEQ");


                        spdWeightListOfFactory.Sheets[0].SetTag(iRow, (int)ColWeightList.ISSUE_PLACE, sfactory); // 출고한 공장
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.ISSUE_PLACE, sissuePalceDesc); //변경 필요.
                        spdWeightListOfFactory.Sheets[0].SetTag(iRow, (int)ColWeightList.CAR_NO, scarNo);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_NO, scarFullNo);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.SEQ, icarSeq);
                        //spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_DATE, MPCF.ToDate(dtpWeightDate.GetValueAsString(8)));
                        spdWeightListOfFactory.Sheets[0].SetTag(iRow, (int)ColWeightList.IO_TYPE, sioType);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.IO_TYPE, sioTypeDesc);
                        spdWeightListOfFactory.Sheets[0].SetTag(iRow, (int)ColWeightList.CAR_MAT_TYPE, srawMilkMatId);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_MAT_TYPE, srawMilkMatDesc);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_IN, dweightIn);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_OUT, dweightOut);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_MEASURE, dweightMeasure);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_REAL, dweightReal);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_GAP, dweightGap);
                        //spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_IN_TIME, MPCF.ToDate(dtpCarInTime.GetValueAsString(8) + cmbInHour.Text + cmbInMinute.Text + "00"));
                        //spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.CAR_OUT_TIME, MPCF.ToDate(dtpCarOutTime.GetValueAsString(8) + cmbOutHour.Text + cmbOutMinute.Text + "00"));
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.WEIGHT_PUT, dweightPut);
                        spdWeightListOfFactory.Sheets[0].SetTag(iRow, (int)ColWeightList.IQC_FLAG, ciqcFlag);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.IQC_FLAG, ciqcFlag);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.INV_LOT_ID, sinvLotId);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.DRIVER, scarDriverName);
                        spdWeightListOfFactory.Sheets[0].SetTag(iRow, (int)ColWeightList.INOUT_FLAG, sinoutFlag);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.INOUT_FLAG, sinoutFlagDesc);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.INV_REQ_NO, sinvReqNo);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.INV_REQ_SEQ, iinvReqSeq);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.PO_NO, spoNo);
                        spdWeightListOfFactory.Sheets[0].SetValue(iRow, (int)ColWeightList.PO_SEQ, ipoSeq);

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {
         
            try
            {
                if (spdWeightListOfFactory.Sheets[0].ActiveRowIndex >= 0)
                {
                    int selectRowIndex = spdWeightListOfFactory.Sheets[0].ActiveRowIndex;
                    //S_weightTime = MPCF.Trim(spdWeightListOfFactory.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.WEIGHT_DATE].Value);
                    I_reqQty1 = MPCF.ToDbl(spdWeightListOfFactory.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.WEIGHT_MEASURE].Value);
                    I_to_fac_inv_req_seq = MPCF.ToInt(spdWeightListOfFactory.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_REQ_SEQ].Value);
                    S_to_fac_inv_req_no = MPCF.Trim(spdWeightListOfFactory.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_REQ_NO].Value);
                    S_to_fac_lot_id = MPCF.Trim(spdWeightListOfFactory.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.INV_LOT_ID].Value);
                    S_to_fac_factory = MPCF.Trim(spdWeightListOfFactory.Sheets[0].Cells[selectRowIndex, (int)ColWeightList.ISSUE_PLACE].Tag);
                }
                else {
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
                    return;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
}
