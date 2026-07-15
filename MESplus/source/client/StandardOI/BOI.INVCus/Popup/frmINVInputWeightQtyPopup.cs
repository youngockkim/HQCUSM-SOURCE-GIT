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
using BOI.OIFrx;

namespace BOI.INVCus.Popup
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmINVInputWeightQtyPopup : frmPopupBase
    {
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
        private string invReqNo;

        public string InvReqNo
        {
            get { return invReqNo; }
            set { invReqNo = value; }
        }
        private int invReqSeq;

        public int InvReqSeq
        {
            get { return invReqSeq; }
            set { invReqSeq = value; }
        }

        private double weightReal;

        public double WeightReal
        {
            get { return weightReal; }
            set { weightReal = value; }
        }

        private string carNo;

        public string CarNo
        {
            get { return carNo; }
            set { carNo = value; }
        }
        private string carFullNo;

        public string CarFullNo
        {
            get { return carFullNo; }
            set { carFullNo = value; }
        }
        private DateTime weightDate;

        public DateTime WeightDate
        {
            get { return weightDate; }
            set { weightDate = value; }
        }
        private double weightIn;

        public double WeightIn
        {
            get { return weightIn; }
            set { weightIn = value; }
        }
        private double weightOut;

        public double WeightOut
        {
            get { return weightOut; }
            set { weightOut = value; }
        }
        private char ioFlag;

        public char IoFlag
        {
            get { return ioFlag; }
            set { ioFlag = value; }
        }
        private string ioFlagDesc;

        public string IoFlagDesc
        {
            get { return ioFlagDesc; }
            set { ioFlagDesc = value; }
        }
        private string inType;

        public string InType
        {
            get { return inType; }
            set { inType = value; }
        }
        private string inTypeDesc;

        public string InTypeDesc
        {
            get { return inTypeDesc; }
            set { inTypeDesc = value; }
        }

        private string rawmilkMaterial;

        public string RawmilkMaterial
        {
            get { return rawmilkMaterial; }
            set { rawmilkMaterial = value; }
        }
        private string rawmilkMaterialDesc;

        public string RawmilkMaterialDesc
        {
            get { return rawmilkMaterialDesc; }
            set { rawmilkMaterialDesc = value; }
        }
        private string poNo;

        public string PoNo
        {
            get { return poNo; }
            set { poNo = value; }
        }
        private int poSeq;

        public int PoSeq
        {
            get { return poSeq; }
            set { poSeq = value; }
        }
        private string issuePlace;

        public string IssuePlace
        {
            get { return issuePlace; }
            set { issuePlace = value; }
        }
        private string issuePlaceDesc;

        public string IssuePlaceDesc
        {
            get { return issuePlaceDesc; }
            set { issuePlaceDesc = value; }
        }

        private string carCode;

        public string CarCode
        {
            get { return carCode; }
            set { carCode = value; }
        }

        private string carCodeDesc;

        public string CarCodeDesc
        {
            get { return carCodeDesc; }
            set { carCodeDesc = value; }
        }

        private string issueStore;

        public string IssueStore
        {
            get { return issueStore; }
            set { issueStore = value; }
        }

        private string issueStoreDesc;

        public string IssueStoreDesc
        {
            get { return issueStoreDesc; }
            set { issueStoreDesc = value; }
        }

        private string sPrevInvReqNo;

        public string SPrevInvReqNo
        {
            get { return sPrevInvReqNo; }
            set { sPrevInvReqNo = value; }
        }

        private int iPrevInvReqSeq;

        public int IPrevInvReqSeq
        {
            get { return iPrevInvReqSeq; }
            set { iPrevInvReqSeq = value; }
        }

        private string sPrevInvLotId;

        public string SPrevInvLotId
        {
            get { return sPrevInvLotId; }
            set { sPrevInvLotId = value; }
        }
        private string sPreInvFactory;

        public string SPreInvFactory
        {
            get { return sPreInvFactory; }
            set { sPreInvFactory = value; }
        }


        private char cToFacFlag= ' ';
        private double dRegstryQty = 0.0;

        #endregion

        #region Constructor

        public frmINVInputWeightQtyPopup()
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

            SetDataToControl();
            //numInQty.Focus();
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

        private void loadInventoryMasterInfo()
        {
            try
            {
                //if (!CheckConditions("VIEW"))
                //{
                //    return;
                //}

             
                TRSNode in_node = new TRSNode("View_Weight_Rawmilk_In");
                TRSNode out_node;
               
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
                double dweightPut = 0.0d;
                double dWeightReal = 0.0d;
                
                double dReqQty1 = 0.0d; //총물류요청량
                double dReqQty2 = 0.0d; //총량중 집유대행량
                double dReqQty3 = 0.0d; //집유량
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

                string srawMilkMatUnit1 = string.Empty;
                string srawMilkMatUnit2 = string.Empty;
                string srawMilkMatUnit3 = string.Empty;
                string srawMilkMatExchange = string.Empty;
                //int ipoSeq = 0;
                //sweightDate = dtpWeightDate.GetValueAsString(8);  


                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INV_REQ_NO", MPCF.Trim(invReqNo));
                in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(invReqSeq));
                out_node = new TRSNode("View_Weight_Rawmilk_Out");

                if (MPCF.CallService("BINV", "BINV_View_Weight_Rawmilk", in_node, ref out_node) == false)
                {
                    return;
                }
 
                scarNo = MPCF.Trim(out_node.GetList(0)[0].GetString("CAR_NO"));
                scarFullNo = MPCF.Trim(out_node.GetList(0)[0].GetString("CAR_FULL_NO"));
                icarSeq = out_node.GetList(0)[0].GetInt("CAR_SEQ");
                scarMatType = MPCF.Trim(out_node.GetList(0)[0].GetString("REQ_CMF_1"));
                dweightIn = out_node.GetList(0)[0].GetDouble("WEIGHT_IN");
                dweightOut = out_node.GetList(0)[0].GetDouble("WEIGHT_OUT");
                dWeightReal = out_node.GetList(0)[0].GetDouble("WEIGHT_REAL");
                srawMilkMatId = MPCF.Trim(out_node.GetList(0)[0].GetString("RAWMILK_MAT_ID"));
                irawMilkMatVer = out_node.GetList(0)[0].GetInt("MAT_VER");
                srawMilkMatDesc = MPCF.Trim(out_node.GetList(0)[0].GetString("RAWMILK_MAT_DESC"));
                dweightPut = out_node.GetList(0)[0].GetDouble("WEIGHT_PUT");
                sinoutType = MPCF.Trim(out_node.GetList(0)[0].GetString("IO_TYPE"));
                sinvReqNo = MPCF.Trim(out_node.GetList(0)[0].GetString("INV_REQ_NO"));
                sweightDate = MPCF.Trim(out_node.GetList(0)[0].GetString("REQ_DATE"));
                srawMilkMatUnit1 = MPCF.Trim(out_node.GetList(0)[0].GetString("RAWMILK_UNIT_1"));
                srawMilkMatUnit2 = MPCF.Trim(out_node.GetList(0)[0].GetString("RAWMILK_UNIT_2"));
                srawMilkMatUnit3 = MPCF.Trim(out_node.GetList(0)[0].GetString("RAWMILK_UNIT_3"));
                srawMilkMatExchange = MPCF.Trim(out_node.GetList(0)[0].GetString("RAWMILK_MAT_CMF_5"));
                //dWeightProxy = out_node.GetList(0)[0].GetDouble("REQ_QTY_2");
                dReqQty1 = out_node.GetList(0)[0].GetDouble("REQ_QTY_1");
                dReqQty2 = out_node.GetList(0)[0].GetDouble("REQ_QTY_2");
                dReqQty3 = out_node.GetList(0)[0].GetDouble("REQ_QTY_3");
                sinvLotId = MPCF.Trim(out_node.GetList(0)[0].GetString("LOT_ID"));
                txtExchange.Text = srawMilkMatExchange;
                txtWeightUnit.Text = srawMilkMatUnit1;
                txtInUnit.Text = srawMilkMatUnit2;
                txtProxyUnit.Text = srawMilkMatUnit2; ;
                numInQty.Value = dReqQty3;
                numProxyQty.Value = dReqQty2;
                numWeightQty.Value = dReqQty1;
                dRegstryQty = dReqQty3;
                if (sinoutType.Equals(BIGC.B_INV_ACC_DETAIL_DAIRY_COMMITTEE))
                {
                  
                }
                else if (sinoutType.Equals(BIGC.B_INV_ACC_DETAIL_BUY))
                {
                 
                }
                else if (sinoutType.Equals(BIGC.B_INV_ACC_DETAIL_OTHER_FACTORY))
                {
                    btnLoad.Visible = true;
                    if(string.IsNullOrWhiteSpace(sinvLotId)== false) // LOT_ID가 추가된경우에 버튼이 보이지 않도록 처리
                    {
                        btnLoad.Visible = false;
                    }
                    //numInQty.Enabled = false;
                    numInQty.ReadOnly = true;
                    numInQty.ShowKeyPadControl = false;
                }
                else if (sinoutType.Equals(BIGC.B_INV_ACC_DETAIL_TEAM))
                {
                
                }
                else
                { //(ioType == BIGC.B_INV_ACC_DETAIL_DAIRY_FARM)
                    //tblProxyQty.Visible = true;
                    //tblProxyDesc.Visible = true;
                    tblProxyQty.Visible = true;
                    lblProcxyDesc.Visible = true;
                 
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return;
            }
        }


        private bool CheckConditions(string scheckFlag)
        {
            try
            {
                if (scheckFlag == "SAVE")
                {
                    if (MPCF.ToDbl(numInQty.Value) <= 0.0d)
                    {
                        numInQty.Focus();
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool UpdateWeightRawmilk()
        {
            TRSNode in_node = new TRSNode("UPDATE_WEIGHT_RAWMILK_IN");
            TRSNode out_node = new TRSNode("UPDATE_WEIGHT_RAWMILK_OUT");

            try
            {
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("INV_REQ_NO", MPCF.Trim(invReqNo));
                in_node.SetInt("INV_REQ_SEQ", MPCF.ToInt(invReqSeq));
                in_node.SetDouble("WEIGHT_REAL", MPCF.ToDbl(numWeightQty.Value));
                in_node.SetDouble("REQ_QTY_1", MPCF.ToDbl(numWeightQty.Value));
                in_node.SetDouble("REQ_QTY_2", MPCF.ToDbl(numProxyQty.Value));
                in_node.SetDouble("REQ_QTY_3", MPCF.ToDbl(numInQty.Value));
                if (dRegstryQty == MPCF.ToDbl(numInQty.Value))
                {
                    MPCF.ShowMessage(MPCF.GetMessage(451), MSG_LEVEL.ERROR, false);
                    return false;
                }
                if(cToFacFlag == 'Y'){
                    in_node.SetChar("TO_FAC_FLAG", 'Y');
                    in_node.SetString("TO_FAC_FACTORY", MPCF.Trim(sPreInvFactory));
                    in_node.SetString("TO_FAC_LOT_ID", MPCF.Trim(sPrevInvLotId));
                    in_node.SetString("TO_FAC_INV_REQ_NO", MPCF.Trim(sPrevInvReqNo));
                    in_node.SetInt("TO_FAC_INV_REQ_SEQ", iPrevInvReqSeq);
                }
                if (MPCF.CallService("BINV", "BINV_Update_Weight_Rawmilk", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCF.ShowSuccessMessage(out_node, false);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        private void SetDataToControl()
        {
            try
            {
                txtCarNo.Tag = carFullNo;
                txtCarNo.Text = carNo;
                txtWeightDate.Text = String.Format(@"{0:yyyy-MM-dd}", weightDate);
                txtWeightIn.Text = String.Format("{0:#,###.##}", weightIn);
                txtWeightOut.Text = String.Format("{0:#,###.##}", weightOut);
                txtInOutFlag.Tag = MPCF.Trim(BIGC.B_IO_FLAG_IN);
                txtInOutFlag.Text = BIGC.B_IO_FLAG_IN_DESC;

                loadInventoryMasterInfo();
               
       
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);

            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckConditions("SAVE"))
                {
                    return;
                }

                if (UpdateWeightRawmilk() == true)
                {
                    this.WeightReal = MPCF.ToDbl(numWeightQty.Value);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else {
                    MPCF.ShowMessage(MPCF.GetMessage(477), MSG_LEVEL.ERROR, false);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                frmINVOutRawmilkToOtherFacPopup frm = new frmINVOutRawmilkToOtherFacPopup();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    numWeightQty.Value = frm.I_reqQty1;
                    numInQty.Value = MPCF.ToDbl(frm.I_reqQty1) / 1.03;
                    SPreInvFactory = frm.S_to_fac_factory;
                    SPrevInvReqNo = frm.S_to_fac_inv_req_no;
                    IPrevInvReqSeq = frm.I_to_fac_inv_req_seq;
                    SPrevInvLotId = frm.S_to_fac_lot_id;
                    cToFacFlag = 'Y';
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void numInQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                numWeightQty.Value = MPCF.ToDbl(numInQty.Value) * 1.03;
            }

        }

    }
}
