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
    public partial class frmINVInputOutTypePopup : frmPopupBase
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

        #endregion

        #region Constructor

        public frmINVInputOutTypePopup()
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
                    this.inType = MPCF.Trim(cdvOutType.Tag);
                    this.InTypeDesc = MPCF.Trim(cdvOutType.Text);
                    this.RawmilkMaterial = MPCF.Trim(cdvMaterial.Tag);
                    this.RawmilkMaterialDesc = MPCF.Trim(cdvMaterial.Text);
                   
                   
                    this.issuePlace = MPCF.Trim(cdvIssuePlace.Tag);
                    this.issuePlaceDesc = MPCF.Trim(cdvIssuePlace.Text);
                    this.CarCode = MPCF.Trim(cdvCarCode.Tag);
                    this.CarCodeDesc = MPCF.Trim(cdvCarCode.Text);
                   
                   
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvOutType_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_OUTTYPE_IN");
                TRSNode out_node = new TRSNode("VIEW_OUTTYPE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_INV_ACC_DETAIL));
                in_node.AddString("DATA_2", MPCF.Trim(BIGC.B_INV_ACC_TYPE_ISSUE));
                in_node.AddString("DATA_6", MPCF.Trim(BIGC.B_REQ_TYPE_RAWMILK));

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1"};

                // Show
                cdvOutType.Text = cdvOutType.Show(cdvOutType, "Account Detail", "BCOM", "BCOM_View_Gcm_Data_List", in_node, "GCM_DATA_LIST", display, header, "DATA_1");

                if (cdvOutType.drResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                if (MPCF.Trim(cdvOutType.Text) != "")
                {
                    if (cdvOutType.returnDatas.Count > 0)
                    {
                        cdvOutType.Tag = cdvOutType.returnDatas[0];

                        cdvIssuePlace.Tag = null;
                        cdvIssuePlace.Text = string.Empty;

                        string sCondition = "";

                        if (MPCF.Trim(cdvOutType.Tag) == BIGC.B_INV_ACC_DETAIL_ISS_TEAM)
                        {
                            lblIssuePlace.Text = MPCF.FindLanguage("Team");
                            ShowIssuePlace(BIGC.B_GCM_B_DEPT_TEAM, sCondition, "Team", "Team Desc", "KEY_1", "DATA_1", MPCF.FindLanguage("Team List"), "BAS", "BAS_View_Data_List", "DATA_LIST", "DATA_1");
                        }
                        else if (MPCF.Trim(cdvOutType.Tag) == BIGC.B_INV_ACC_DETAIL_ISS_FACTORY)
                        {
                            lblIssuePlace.Text =  MPCF.FindLanguage("Factory");
                            ShowIssuePlace(BIGC.B_GCM_B_FACTORY_LIST, sCondition, "Factory", "Factory Desc", "KEY_1", "DATA_1", MPCF.FindLanguage("Factory List"), "BAS", "BAS_View_Data_List", "DATA_LIST", "DATA_1");
                        }
                        else if (MPCF.Trim(cdvOutType.Tag) == BIGC.B_INV_ACC_DETAIL_ISS_SELL)
                        {
                            lblIssuePlace.Text = MPCF.FindLanguage("Vendor");
                            sCondition = "원유업체";                            
                            //ShowIssuePlace(BIGC.B_GCM_B_VENDOR, sCondition, "Vendor", "Vendor Desc", "KEY_2", "DATA_1", "Vendor List", "BAS", "BAS_View_Data_List", "DATA_LIST", "DATA_1");
                            SellCodeView(sCondition);
                        }
                        
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
            TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[4];

            try
            {   /*
                I27		팀간출고
                I33		이송(타공장)출고
                I37		매각출고
                */
                string param_1 = "";
                string param_2 = "";
                string param_3 = "";

                switch ( MPCF.Trim(this.cdvOutType.Tag) )
                {
                    case "I27":

                        param_1 = "%";
                        param_2 = "%";
                        param_3 = "Y";


                        break;
                    case "I33":
                        param_1 = "Y";
                        param_2 = "%";
                        param_3 = "%";
                        break;
                    case "I37":
                        param_1 = "%";
                        param_2 = "Y";
                        param_3 = "%";

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

               

                // Show
                //cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");
                cdvMaterial.Text = cdvMaterial.Show(cdvMaterial, "Material List", "ORMK1003-001", dvcArgu, "MAT_DESC", -1);
                cdvMaterial.Tag = "";

                if (MPCF.Trim(cdvMaterial.Text) != "")
                {
                    if (cdvMaterial.returnDatas.Count > 0)
                    {
                        cdvMaterial.Tag = cdvMaterial.returnDatas[0];

                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvIssuePlace_CodeViewButtonClick(object sender, EventArgs e)
        {
            string sCondition = "";
            if (MPCF.Trim(cdvOutType.Tag) == BIGC.B_INV_ACC_DETAIL_ISS_TEAM)
            {
                lblIssuePlace.Text = "Team";
                ShowIssuePlace(BIGC.B_GCM_B_DEPT_TEAM, sCondition, "Team", "Team Desc", "KEY_1", "DATA_1", "Team List", "BAS", "BAS_View_Data_List", "DATA_LIST", "DATA_1");
            }
            else if (MPCF.Trim(cdvOutType.Tag) == BIGC.B_INV_ACC_DETAIL_ISS_FACTORY)
            {
                lblIssuePlace.Text = "Factory";                
                ShowIssuePlace(BIGC.B_GCM_B_FACTORY_LIST, sCondition, "Factory", "Factory Desc", "KEY_1", "DATA_1", "Factory List", "BAS", "BAS_View_Data_List", "DATA_LIST", "DATA_1");
            }
            else if (MPCF.Trim(cdvOutType.Tag) == BIGC.B_INV_ACC_DETAIL_ISS_SELL)
            {
                lblIssuePlace.Text = "Vendor";
                sCondition = "원유업체";
                //ShowIssuePlace(BIGC.B_GCM_B_VENDOR, sCondition, "Vendor Desc", "Biz No", "DATA_1", "DATA_2", "Vendor List", "BAS", "BAS_View_Data_List", "DATA_LIST", "DATA_1");
                SellCodeView(sCondition);
             
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

        private bool SellCodeView(string sCond) {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_ISSUE_PLACE_IN");
                TRSNode out_node = new TRSNode("VIEW_ISSUE_PLACE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(BIGC.B_GCM_B_VENDOR));
                if (sCond != "")
                {
                    in_node.AddString("KEY_1", MPCF.Trim(sCond));
                }

                // CodeView Column Header Setup
                string[] header = new string[] { "Vendor Desc", "Biz No", "Vendor" };

                // CodeView Display Column Setup
                string[] display = new string[] { "DATA_1", "DATA_2", "KEY_2" };

                // Show
                cdvIssuePlace.Text = cdvIssuePlace.Show(cdvIssuePlace, MPCF.FindLanguage("Vendor List"), "BAS", "BAS_View_Data_List", in_node, "DATA_LIST", display, header, "DATA_1");

                if (MPCF.Trim(cdvIssuePlace.Text) != "")
                {
                    if (cdvIssuePlace.returnDatas.Count > 0)
                    {
                        cdvIssuePlace.Tag = cdvIssuePlace.returnDatas[2];

                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }
        private bool CheckConditions(string scheckFlag)
        {
            try
            {
                if (scheckFlag == "SAVE")
                {
                    if (!MPCF.CheckValue(cdvOutType, true))
                    {
                        return false;
                    }
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
                in_node.AddChar("SUB_STEP", '3');
                in_node.AddString("INV_REQ_NO", MPCF.Trim(invReqNo));
                in_node.AddInt("INV_REQ_SEQ", MPCF.ToInt(invReqSeq));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Tag));
                in_node.AddInt("MAT_VER", BIGC.B_MATERIAL_DEFAULT_VERSION);                
                in_node.AddString("IO_FLAG", MPCF.Trim(txtInOutFlag.Tag));
                in_node.AddString("IO_TYPE", MPCF.Trim(cdvOutType.Tag));                
                in_node.AddString("CUST_ID", MPCF.Trim(cdvIssuePlace.Tag));
                //차량코드
                in_node.AddString("REQ_DTL_CMF_1", MPCF.Trim(cdvCarCode.Tag));
    
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
                txtInOutFlag.Tag = BIGC.B_IO_FLAG_OUT;
                txtInOutFlag.Text = BIGC.B_IO_FLAG_OUT_DESC;
                cdvOutType.Tag = MPCF.Trim(inType);
                cdvOutType.Text = MPCF.Trim(inTypeDesc);
                cdvMaterial.Tag = MPCF.Trim(rawmilkMaterial);
                cdvMaterial.Text = MPCF.Trim(rawmilkMaterialDesc);

                if (MPCF.Trim(cdvOutType.Tag) == BIGC.B_INV_ACC_DETAIL_ISS_TEAM)
                {
                    lblIssuePlace.Text = "Team";                    
                }
                else if (MPCF.Trim(cdvOutType.Tag) == BIGC.B_INV_ACC_DETAIL_ISS_FACTORY)
                {
                    lblIssuePlace.Text = "Factory";
                }
                else if (MPCF.Trim(cdvOutType.Tag) == BIGC.B_INV_ACC_DETAIL_ISS_SELL)
                {
                    lblIssuePlace.Text = "Vendor";
                }
                else
                {
                    lblIssuePlace.Text = "";
                }
                cdvIssuePlace.Tag = MPCF.Trim(issuePlace);
                cdvIssuePlace.Text = MPCF.Trim(issuePlaceDesc);
                cdvCarCode.Tag = MPCF.Trim(carCode);
                cdvCarCode.Text = MPCF.Trim(carCodeDesc);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                
            }
        }

        private void ShowIssuePlace(string sTableName, string sCondition_1, string sColumn_1, string sColumn_2, string sPopupTitle)
        {
            ShowIssuePlace(sTableName, sCondition_1, sColumn_1, sColumn_2, "KEY_1", "DATA_1", sPopupTitle, "BCOM", "BCOM_View_Gcm_Data_List", "GCM_DATA_LIST", "DATA_1");            
        }


        private void ShowIssuePlace(string sTableName, string sCondition_1, string sColumn_1, string sColumn_2, string sData_1, string sData2
            ,  string sPopupTitle, string sModule, string sService, string sListName, string sOutValue)
        {
            try
            {
                TRSNode in_node = new TRSNode("VIEW_ISSUE_PLACE_IN");
                TRSNode out_node = new TRSNode("VIEW_ISSUE_PLACE_OUT");

                // In Node Setup
                in_node.Init();
                MPCF.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", MPCF.Trim(sTableName));
                if (sCondition_1 != "")
                {
                    in_node.AddString("KEY_1", MPCF.Trim(sCondition_1));
                }

                // CodeView Column Header Setup
                string[] header = new string[] { sColumn_1, sColumn_2 };

                // CodeView Display Column Setup
                string[] display = new string[] { sData_1, sData2 };                

                // Show
                cdvIssuePlace.Text = cdvIssuePlace.Show(cdvIssuePlace, sPopupTitle, sModule, sService, in_node, sListName, display, header, sOutValue);

                if (MPCF.Trim(cdvIssuePlace.Text) != "")
                {
                    if (cdvIssuePlace.returnDatas.Count > 0)
                    {
                        cdvIssuePlace.Tag = cdvIssuePlace.returnDatas[0];

                    }

                    //MPCF.SetFocus(txtWeightIn);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        private void cdvOutType_ValueChanged(object sender, EventArgs e)
        {
            //출고 유형 바뀌면 선택 자재 초기화
            //this.cdvMaterial.Clear();
        }

     
        


       
       

        

        

      

        
    }
}
