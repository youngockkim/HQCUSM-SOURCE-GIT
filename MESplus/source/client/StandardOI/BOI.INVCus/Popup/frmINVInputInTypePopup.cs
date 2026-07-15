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
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using BOI.OIFrx;

using SOI.DNM;

namespace BOI.INVCus
{

    #region Enum

   

    #endregion


    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmINVInputInTypePopup : frmPopupBase
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

        private string receiptStore;

        public string ReceiptStore
        {
            get { return receiptStore; }
            set { receiptStore = value; }
        }

        private string receiptStoreDesc;

        public string ReceiptStoreDesc
        {
            get { return receiptStoreDesc; }
            set { receiptStoreDesc = value; }
        }

        private string vendorId;

        public string VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        private string vendorDesc;

        public string VendorDesc
        {
            get { return vendorDesc; }
            set { vendorDesc = value; }
        }


        #endregion

        #region Constructor

        public frmINVInputInTypePopup()
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

            SetDataToControl();
        }
        

        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;            
            // 종료
            this.Close();
        }

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
                    this.ioFlag = MPCF.ToChar(txtInOutFlag.Tag);
                    this.ioFlagDesc = MPCF.Trim(txtInOutFlag.Text);
                    this.inType = MPCF.Trim(cdvInType.Tag);
                    this.InTypeDesc = MPCF.Trim(cdvInType.Text);
                    this.RawmilkMaterial = MPCF.Trim(cdvMaterial.Tag);
                    this.RawmilkMaterialDesc = MPCF.Trim(cdvMaterial.Text);
                    this.PoNo = MPCF.Trim(txtPoNo.Text);
                    this.PoSeq = MPCF.ToInt(txtPoSeq.Text);
                    this.CarCode = MPCF.Trim(cdvCarCode.Tag);
                    this.CarCodeDesc = MPCF.Trim(cdvCarCode.Text);
                    this.ReceiptStore = MPCF.Trim(cdvVendorId.Tag);
                    this.ReceiptStoreDesc = MPCF.Trim(cdvVendorId.Text);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvInType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_INTYPE_IN");
                TRSNode out_node = new TRSNode("VIEW_INTYPE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_INV_ACC_DETAIL));
                in_node.AddString("DATA_2", MPCF.Trim(BIGC.B_INV_ACC_TYPE_RECEIVE));
                in_node.AddString("DATA_6", MPCF.Trim(BIGC.B_REQ_TYPE_RAWMILK));

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1"};

                // Show
                cdvInType.Text = cdvInType.Show(cdvInType, "Account Detail", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvInType.Text) != "")
                {
                    if (cdvInType.returnDatas.Count > 0)
                    {
                        cdvInType.Tag = cdvInType.returnDatas[0];
                        
                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvMaterial_CodeViewButtonClick(object sender, EventArgs e)
        {
            
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[6];

            try
            {  
                /*
                R21			구매(매입)입고
                R22  		낙농가입고
                R23			낙진회입고
                R41	    	이송(타공장)입고
                R42			팀간입고
                R51		    기타입고
                */

                string param_1 = "";
                string param_2 = "";
                string param_3 = "";
                string param_4 = "";
                string param_5 = "";
                

                switch (MPCF.Trim(this.cdvInType.Tag))
                {
                    case "R21": //구매(매입)입고

                        param_1 = "Y";
                        param_2 = "%";
                        param_3 = "%";
                        param_4 = "%";
                        param_5 = "%";


                        break;
                    case "R22": //낙농가입고
                        param_1 = "%";
                        param_2 = "Y";
                        param_3 = "%";
                        param_4 = "%";
                        param_5 = "%";
                        break;
                    case "R23":
                        param_1 = "%";
                        param_2 = "%";
                        param_3 = "Y";
                        param_4 = "%";
                        param_5 = "%";

                        break;


                    case "R41":
                        param_1 = "%";
                        param_2 = "%";
                        param_3 = "%";
                        param_4 = "Y";
                        param_5 = "%";

                        break;

                    case "R42":
                        param_1 = "%";
                        param_2 = "%";
                        param_3 = "%";
                        param_4 = "%";
                        param_5 = "Y";

                        break;


                }

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "DATA_1";
                dvcArgu[1].sCondition_Value = param_1;

                dvcArgu[2].sCondtion_ID = "DATA_2";
                dvcArgu[2].sCondition_Value = param_2;
                   
                dvcArgu[3].sCondtion_ID = "DATA_3";
                dvcArgu[3].sCondition_Value = param_3;

                dvcArgu[4].sCondtion_ID = "DATA_4";
                dvcArgu[4].sCondition_Value = param_4;

                dvcArgu[5].sCondtion_ID = "DATA_5";
                dvcArgu[5].sCondition_Value = param_5;

               

                // Show
                //cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");
                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", "ORMK1002-001", dvcArgu, "MAT_DESC", -1);
                cdvMaterial.Tag = "";

                if (MPCF.Trim(cdvMaterial.Text) != "")
                {
                    if (cdvMaterial.returnDatas.Count > 0)
                    {
                        cdvMaterial.Tag = cdvMaterial.returnDatas[0];

                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
                
                
                /*
                TRSNode in_node = new TRSNode("VIEW_MATERIAL_IN");
                TRSNode out_node = new TRSNode("VIEW_MATERIAL_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_RMK_MAT_TYPE));                

                // CodeView Column Header Setup
                string[] header = new string[] { "Material", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvMaterial.Text) != "")
                {
                    if (cdvMaterial.returnDatas.Count > 0)
                    {
                        cdvMaterial.Tag = cdvMaterial.returnDatas[0];

                    }

                    //MPCF.SetFocus(txtWeightIn);
                } */
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnViewPo_Click(object sender, EventArgs e)
        {
            try
            {               

                TRSNode in_node = new TRSNode("VIEW_PO_IN");
                TRSNode out_node = new TRSNode("VIEW_PO_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("FROM_DATE", MPCF.Trim(DateTime.Now.AddMonths(-1).ToString("yyyyMMdd")));
                in_node.AddString("TO_DATE", MPCF.Trim(DateTime.Now.ToString("yyyyMMdd")));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Tag));
                in_node.AddChar("DLV_STATUS", BIGC.B_DLV_STATUS_RUNNING);
                //in_node.AddString("NEXT_DLV_NO", MPCF.Trim(BIGC.B_GCM_B_INV_ACC_DETAIL));
                //in_node.AddInt("NEXT_DLV_SEQ", MPCF.Trim(BIGC.B_GCM_B_INV_ACC_DETAIL));

                // CodeView Column Header Setup
                string[] header = new string[] { "Purchase Order No", "Purchase Order Seq", "Purchase Order Date", "Material", "Material Desc", "Weight" };

                // CodeView Display Column Setup
                string[] display = new string[] { "DLV_NO", "DLV_SEQ", "DLV_DATE", "MAT_ID", "MAT_DESC", "DLV_QTY_1" };

                // Show
                cdvPo.Text = cdvPo.Show(cdvPo, "Purchase Order List", "BINV", "BINV_View_Inventory_Purchase_Order_List", in_node, "INVENTORY_PURCHASE_ORDER_LIST", display, header, "DLV_NO");
                if (cdvPo.drResult == System.Windows.Forms.DialogResult.No)
                {
                    txtPoNo.Text = string.Empty;
                    txtPoSeq.Text = string.Empty;
                }
                else
                {

                    if (MPCF.Trim(cdvPo.Text) != "")
                    {
                        if (cdvPo.returnDatas.Count > 0)
                        {
                            txtPoNo.Text = cdvPo.returnDatas[0];
                            txtPoSeq.Text = cdvPo.returnDatas[1];
                        }

                        //MPCF.SetFocus(txtWeightIn);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvCarCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_MILK_CAR_IN");
                TRSNode out_node = new TRSNode("VIEW_MILK_CAR_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '3';
                in_node.Factory = MPGV.gsFactory;
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_MILKCAR_TANK));
                in_node.AddString("DATA_8", " ");
                // CodeView Column Header Setup
                string[] header = new string[] { "Car Code", "Material", "Driver", "Car No" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1", "DATA_2", "DATA_3" };

                // Show
                cdvCarCode.Text = cdvCarCode.Show(cdvCarCode, "Tank Lorry", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_3");

                if (MPCF.Trim(cdvCarCode.Text) != "")
                {
                    if (cdvCarCode.returnDatas.Count > 0)
                    {
                        cdvCarCode.Tag = cdvCarCode.returnDatas[0];                        
                    }                    
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

      
        #endregion

        #region Function

        private bool CheckConditions(string scheckFlag)
        {
            try
            {
                if (scheckFlag == "SAVE")
                {
                    if (!MPCF.CheckValue(cdvInType, true))
                    {
                        return false;
                    }
                    //2017.03.20 1차 계근시 품목이 ti-gate에서 넘어오도록 변경되어 주석 처리.
                    if (!MPCF.CheckValue(cdvMaterial, true))
                    {
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
                in_node.ProcStep = 'U';
                in_node.AddChar("SUB_STEP", '2');
                in_node.AddString("INV_REQ_NO", MPCF.Trim(invReqNo));
                in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(invReqSeq));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Tag));
                in_node.AddInt("MAT_VER", BIGC.B_MATERIAL_DEFAULT_VERSION);
                
                in_node.AddString("IO_FLAG", MPCF.Trim(txtInOutFlag.Tag));
                in_node.AddString("IO_TYPE", MPCF.Trim(cdvInType.Tag));
                in_node.AddString("ERP_REQ_NO", MPCF.Trim(txtPoNo.Text));
                in_node.AddInt("ERP_REQ_SEQ", MPCF.ToInt(txtPoSeq.Text));

                //차량코드
                in_node.AddString("REQ_DTL_CMF_1", MPCF.Trim(cdvCarCode.Tag));
                //업체
                in_node.AddString("REQ_DTL_CMF_3", MPCF.Trim(cdvVendorId.Tag));

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
                txtCarNo.Tag = carNo;
                txtCarNo.Text = carFullNo;
                txtWeightDate.Text = String.Format(@"{0:yyyy-MM-dd}", weightDate);
                txtWeightIn.Text = String.Format("{0:#,###.##}", weightIn);
                txtWeightOut.Text = String.Format("{0:#,###.##}", weightOut);
                txtInOutFlag.Tag = MPCF.Trim(BIGC.B_IO_FLAG_IN);
                txtInOutFlag.Text = BIGC.B_IO_FLAG_IN_DESC;
                cdvInType.Tag = MPCF.Trim(inType);
                cdvInType.Text = MPCF.Trim(inTypeDesc);
                cdvMaterial.Tag = MPCF.Trim(rawmilkMaterial);
                cdvMaterial.Text = MPCF.Trim(rawmilkMaterialDesc);
                txtPoNo.Text = MPCF.Trim(poNo);
                txtPoSeq.Text = MPCF.Trim(poSeq);
                cdvCarCode.Tag = MPCF.Trim(carCode);
                cdvCarCode.Text = MPCF.Trim(carCodeDesc);
                cdvVendorId.Tag = MPCF.Trim(vendorId);
                cdvVendorId.Text = MPCF.Trim(vendorDesc);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                
            }
        }
       
        #endregion

        private void cdvMaterial_CodeViewButtonClick_1(object sender, EventArgs e)
        {

        }

        private void cdvVendorId_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                //TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                //dvcArgu[0].sCondtion_ID = "FACTORY";
                //dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                //dvcArgu[1].sCondtion_ID = "KEY_1";
                //dvcArgu[1].sCondition_Value = "원유업체";

                //// CodeView Column Header Setup
                //string[] header = new string[] { "Vendor", "Biz No" };

                //// CodeView Display Column Setup
                //string[] display = new string[] { "Vendor", "Biz No" };

                //// Show
                //cdvVendorId.Text = cdvVendorId.Show(cdvVendorId, "Oper", "COM0000-008", dvcArgu, display, header, "OPER_SHORT_DESC", -1);

                //if (MPCF.Trim(cdvVendorId.Text) != "")
                //{
                //    if (cdvVendorId.returnDatas.Count > 0)
                //    {
                //        cdvVendorId.Tag = cdvVendorId.returnDatas[0];
                //    }
                //    else
                //    {
                //        cdvVendorId.Tag = "";
                //    }
                //}
                //else
                //{
                //    cdvVendorId.Tag = "";
                //}
                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_OPERATION_LIST_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_VENDOR));
                in_node.AddString("KEY_1", MPCF.Trim("원유업체"));

                // CodeView Column Header Setup
                string[] header = new string[] { "Vendor", "Biz No" };

                // CodeView Display Column Setup
                string[] display = new string[] { "DATA_1", "DATA_2" };

                // Show
                cdvVendorId.Text = cdvVendorId.Show(cdvVendorId, "Vendor List", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvVendorId.Text) != "")
                {
                    if (cdvVendorId.returnDatas.Count > 0)
                    {
                        cdvVendorId.Tag = cdvVendorId.returnDatas[0];
                        cdvVendorId.Text = cdvVendorId.returnDatas[1];
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvVendorId_ValueChanged(object sender, EventArgs e)
        {

        }

        

        

       

        

        

      

        
    }
}
