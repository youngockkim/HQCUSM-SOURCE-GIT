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
using SOI.DNM;

namespace BOI.WIPCus.Popup
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmWIPNonmovingResourcePopup : frmPopupBase
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

        public string _sTypeCode = string.Empty;
        public string _sTypeDesc = string.Empty;

        public string _sCodeLCode = string.Empty;
        public string _sCodeLDesc = string.Empty;

        public string _sCodeMCode = string.Empty;
        public string _sCodeMDesc = string.Empty;

        public string _sCodeSCode = string.Empty;
        public string _sCodeSDesc = string.Empty;

        public string _sLineId = string.Empty;

        private string _sStatus = string.Empty;

        #endregion

        #region Constructor

        public frmWIPNonmovingResourcePopup()
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
        private void frmTempSOIPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            if(_sTypeDesc != "" && _sTypeCode != "")
            {
                txtNonmovingType.Text = _sTypeDesc;
                txtNonmovingType.Tag = _sTypeCode;

                RegisterButton("L");
            }

            // 활성화
            this.Activate();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (_sStatus == "L")
                {
                    _sTypeCode = string.Empty;
                    _sTypeDesc = string.Empty;

                    _sCodeLCode = string.Empty;
                    _sCodeLDesc = string.Empty;

                    _sCodeMCode = string.Empty;
                    _sCodeMDesc = string.Empty;

                    _sCodeSCode = string.Empty;
                    _sCodeSDesc = string.Empty;

                    DialogResult = DialogResult.OK;

                    this.Close();
                }
                else if(_sStatus == "M")
                {
                    _sCodeMCode = string.Empty;
                    _sCodeMDesc = string.Empty;

                    txtCodeM.Text = "";
                    txtCodeM.Tag = "";

                    BackVisibleInfo(_sStatus);
                }
                else if (_sStatus == "S")
                {
                    _sCodeSCode = string.Empty;
                    _sCodeSDesc = string.Empty;

                    txtCodeS.Text = "";
                    txtCodeS.Tag = "";

                    BackVisibleInfo(_sStatus);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void btnCodeL1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (((SOIButton)sender).Name)
                {
                    //대
                    case "btnCodeL1":

                        _sCodeLCode = btnCodeL1.Tag.ToString();
                        _sCodeLDesc = btnCodeL1.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL2":

                        _sCodeLCode = btnCodeL2.Tag.ToString();
                        _sCodeLDesc = btnCodeL2.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL3":

                        _sCodeLCode = btnCodeL3.Tag.ToString();
                        _sCodeLDesc = btnCodeL3.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL4":

                        _sCodeLCode = btnCodeL4.Tag.ToString();
                        _sCodeLDesc = btnCodeL4.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL5":

                        _sCodeLCode = btnCodeL5.Tag.ToString();
                        _sCodeLDesc = btnCodeL5.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL6":

                        _sCodeLCode = btnCodeL6.Tag.ToString();
                        _sCodeLDesc = btnCodeL6.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL7":

                        _sCodeLCode = btnCodeL7.Tag.ToString();
                        _sCodeLDesc = btnCodeL7.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL8":

                        _sCodeLCode = btnCodeL8.Tag.ToString();
                        _sCodeLDesc = btnCodeL8.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL9":

                        _sCodeLCode = btnCodeL9.Tag.ToString();
                        _sCodeLDesc = btnCodeL9.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL10":

                        _sCodeLCode = btnCodeL10.Tag.ToString();
                        _sCodeLDesc = btnCodeL10.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL11":

                        _sCodeLCode = btnCodeL11.Tag.ToString();
                        _sCodeLDesc = btnCodeL11.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL12":

                        _sCodeLCode = btnCodeL12.Tag.ToString();
                        _sCodeLDesc = btnCodeL12.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL13":

                        _sCodeLCode = btnCodeL13.Tag.ToString();
                        _sCodeLDesc = btnCodeL13.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL14":

                        _sCodeLCode = btnCodeL14.Tag.ToString();
                        _sCodeLDesc = btnCodeL14.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL15":

                        _sCodeLCode = btnCodeL15.Tag.ToString();
                        _sCodeLDesc = btnCodeL15.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL16":

                        _sCodeLCode = btnCodeL16.Tag.ToString();
                        _sCodeLDesc = btnCodeL16.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL17":

                        _sCodeLCode = btnCodeL17.Tag.ToString();
                        _sCodeLDesc = btnCodeL17.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL18":

                        _sCodeLCode = btnCodeL18.Tag.ToString();
                        _sCodeLDesc = btnCodeL18.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL19":

                        _sCodeLCode = btnCodeL19.Tag.ToString();
                        _sCodeLDesc = btnCodeL19.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL20":

                        _sCodeLCode = btnCodeL20.Tag.ToString();
                        _sCodeLDesc = btnCodeL20.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL21":

                        _sCodeLCode = btnCodeL21.Tag.ToString();
                        _sCodeLDesc = btnCodeL21.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL22":

                        _sCodeLCode = btnCodeL22.Tag.ToString();
                        _sCodeLDesc = btnCodeL22.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL23":

                        _sCodeLCode = btnCodeL23.Tag.ToString();
                        _sCodeLDesc = btnCodeL23.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    case "btnCodeL24":

                        _sCodeLCode = btnCodeL24.Tag.ToString();
                        _sCodeLDesc = btnCodeL24.Text;

                        txtCodeL.Text = _sCodeLDesc;
                        txtCodeL.Tag = _sCodeLCode;

                        RegisterButton("M");

                        break;

                    //중
                    case "btnCodeM1":

                        _sCodeMCode = btnCodeM1.Tag.ToString();
                        _sCodeMDesc = btnCodeM1.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM2":

                        _sCodeMCode = btnCodeM2.Tag.ToString();
                        _sCodeMDesc = btnCodeM2.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM3":

                        _sCodeMCode = btnCodeM3.Tag.ToString();
                        _sCodeMDesc = btnCodeM3.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM4":

                        _sCodeMCode = btnCodeM4.Tag.ToString();
                        _sCodeMDesc = btnCodeM4.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM5":

                        _sCodeMCode = btnCodeM5.Tag.ToString();
                        _sCodeMDesc = btnCodeM5.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM6":

                        _sCodeMCode = btnCodeM6.Tag.ToString();
                        _sCodeMDesc = btnCodeM6.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM7":

                        _sCodeMCode = btnCodeM7.Tag.ToString();
                        _sCodeMDesc = btnCodeM7.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM8":

                        _sCodeMCode = btnCodeM8.Tag.ToString();
                        _sCodeMDesc = btnCodeM8.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM9":

                        _sCodeMCode = btnCodeM9.Tag.ToString();
                        _sCodeMDesc = btnCodeM9.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM10":

                        _sCodeMCode = btnCodeM10.Tag.ToString();
                        _sCodeMDesc = btnCodeM10.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM11":

                        _sCodeMCode = btnCodeM11.Tag.ToString();
                        _sCodeMDesc = btnCodeM11.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM12":

                        _sCodeMCode = btnCodeM12.Tag.ToString();
                        _sCodeMDesc = btnCodeM12.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM13":

                        _sCodeMCode = btnCodeM13.Tag.ToString();
                        _sCodeMDesc = btnCodeM13.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM14":

                        _sCodeMCode = btnCodeM14.Tag.ToString();
                        _sCodeMDesc = btnCodeM14.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM15":

                        _sCodeMCode = btnCodeM15.Tag.ToString();
                        _sCodeMDesc = btnCodeM15.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM16":

                        _sCodeMCode = btnCodeM16.Tag.ToString();
                        _sCodeMDesc = btnCodeM16.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM17":

                        _sCodeMCode = btnCodeM17.Tag.ToString();
                        _sCodeMDesc = btnCodeM17.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM18":

                        _sCodeMCode = btnCodeM18.Tag.ToString();
                        _sCodeMDesc = btnCodeM18.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM19":

                        _sCodeMCode = btnCodeM19.Tag.ToString();
                        _sCodeMDesc = btnCodeM19.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM20":

                        _sCodeMCode = btnCodeM20.Tag.ToString();
                        _sCodeMDesc = btnCodeM20.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM21":

                        _sCodeMCode = btnCodeM21.Tag.ToString();
                        _sCodeMDesc = btnCodeM21.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM22":

                        _sCodeMCode = btnCodeM22.Tag.ToString();
                        _sCodeMDesc = btnCodeM22.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM23":

                        _sCodeMCode = btnCodeM23.Tag.ToString();
                        _sCodeMDesc = btnCodeM23.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    case "btnCodeM24":

                        _sCodeMCode = btnCodeM24.Tag.ToString();
                        _sCodeMDesc = btnCodeM24.Text;

                        txtCodeM.Text = _sCodeMDesc;
                        txtCodeM.Tag = _sCodeMCode;

                        RegisterButton("S");

                        break;

                    //소
                    case "btnCodeS1":

                        _sCodeSCode = btnCodeS1.Tag.ToString();
                        _sCodeSDesc = btnCodeS1.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS2":

                        _sCodeSCode = btnCodeS2.Tag.ToString();
                        _sCodeSDesc = btnCodeS2.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS3":

                        _sCodeSCode = btnCodeS3.Tag.ToString();
                        _sCodeSDesc = btnCodeS3.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS4":

                        _sCodeSCode = btnCodeS4.Tag.ToString();
                        _sCodeSDesc = btnCodeS4.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS5":

                        _sCodeSCode = btnCodeS5.Tag.ToString();
                        _sCodeSDesc = btnCodeS5.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS6":

                        _sCodeSCode = btnCodeS6.Tag.ToString();
                        _sCodeSDesc = btnCodeS6.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS7":

                        _sCodeSCode = btnCodeS7.Tag.ToString();
                        _sCodeSDesc = btnCodeS7.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS8":

                        _sCodeSCode = btnCodeS8.Tag.ToString();
                        _sCodeSDesc = btnCodeS8.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS9":

                        _sCodeSCode = btnCodeS9.Tag.ToString();
                        _sCodeSDesc = btnCodeS9.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS10":

                        _sCodeSCode = btnCodeS10.Tag.ToString();
                        _sCodeSDesc = btnCodeS10.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS11":

                        _sCodeSCode = btnCodeS11.Tag.ToString();
                        _sCodeSDesc = btnCodeS11.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS12":

                        _sCodeSCode = btnCodeS12.Tag.ToString();
                        _sCodeSDesc = btnCodeS12.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS13":

                        _sCodeSCode = btnCodeS13.Tag.ToString();
                        _sCodeSDesc = btnCodeS13.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS14":

                        _sCodeSCode = btnCodeS14.Tag.ToString();
                        _sCodeSDesc = btnCodeS14.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS15":

                        _sCodeSCode = btnCodeS15.Tag.ToString();
                        _sCodeSDesc = btnCodeS15.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS16":

                        _sCodeSCode = btnCodeS16.Tag.ToString();
                        _sCodeSDesc = btnCodeS16.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS17":

                        _sCodeSCode = btnCodeS17.Tag.ToString();
                        _sCodeSDesc = btnCodeS17.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS18":

                        _sCodeSCode = btnCodeS18.Tag.ToString();
                        _sCodeSDesc = btnCodeS18.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS19":

                        _sCodeSCode = btnCodeS19.Tag.ToString();
                        _sCodeSDesc = btnCodeS19.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS20":

                        _sCodeSCode = btnCodeS20.Tag.ToString();
                        _sCodeSDesc = btnCodeS20.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS21":

                        _sCodeSCode = btnCodeS21.Tag.ToString();
                        _sCodeSDesc = btnCodeS21.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS22":

                        _sCodeSCode = btnCodeS22.Tag.ToString();
                        _sCodeSDesc = btnCodeS22.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS23":

                        _sCodeSCode = btnCodeS23.Tag.ToString();
                        _sCodeSDesc = btnCodeS23.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;

                    case "btnCodeS24":

                        _sCodeSCode = btnCodeS24.Tag.ToString();
                        _sCodeSDesc = btnCodeS24.Text;

                        txtCodeS.Text = _sCodeSDesc;
                        txtCodeS.Tag = _sCodeSCode;

                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        private void RegisterButton(string sScreenStatus)
        {
            TPDR.DirectViewCond[] dvcArgu;
            DataTable dt = null;
            string sPreFix = string.Empty;

            try
            {
                if (sScreenStatus == "L")
                {                  
                    dvcArgu = new TPDR.DirectViewCond[3];

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "DOWN_TYPE";
                    dvcArgu[1].sCondition_Value = _sTypeCode;

                    if (_sTypeCode == "TR")
                    {
                        dvcArgu[2].sCondtion_ID = "LINE_ID";
                        dvcArgu[2].sCondition_Value = _sLineId;
                    }
                    else
                    {
                        dvcArgu[2].sCondtion_ID = "LINE_ID";
                        dvcArgu[2].sCondition_Value = "";
                    }

                    if (TPDR.GetDataOne("", ref dt, "COM0000-022", dvcArgu, false, false) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return;
                    }

                    sPreFix = "btnCodeL";
                    VisibleInfo(sScreenStatus);
                }
                else if (sScreenStatus == "M")
                {
                    dvcArgu = new TPDR.DirectViewCond[2];

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "CODE_L";
                    dvcArgu[1].sCondition_Value = _sCodeLCode;

                    if (TPDR.GetDataOne("", ref dt, "COM0000-023", dvcArgu, false, false) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return;
                    }

                    sPreFix = "btnCodeM";
                    VisibleInfo(sScreenStatus);
                }
                else if (sScreenStatus == "S")
                {
                    dvcArgu = new TPDR.DirectViewCond[2];

                    dvcArgu[0].sCondtion_ID = "FACTORY";
                    dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                    dvcArgu[1].sCondtion_ID = "CODE_M";
                    dvcArgu[1].sCondition_Value = _sCodeMCode;

                    if (TPDR.GetDataOne("", ref dt, "COM0000-024", dvcArgu, false, false) == false)
                    {
                        if (dt != null)
                            dt.Dispose();

                        GC.Collect();
                        return;
                    }

                    sPreFix = "btnCodeS";
                    VisibleInfo(sScreenStatus);
                }

                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    BtnInfo(sPreFix + i.ToString(), dt.Rows[i - 1]["DATA_1"].ToString(), dt.Rows[i - 1]["KEY_1"].ToString());
                }

            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage("" + ex.Message, MSG_LEVEL.ERROR, true);
                return;
            }
        }

        private void BtnInfo(string btnName, string btnText, string btnTag)
        {
            try
            {
                switch (btnName)
                {
                    //대
                    case "btnCodeL1":

                        btnCodeL1.Visible = true;
                        btnCodeL1.Text = btnText;
                        btnCodeL1.Tag = btnTag;

                        break;

                    case "btnCodeL2":

                        btnCodeL2.Visible = true;
                        btnCodeL2.Text = btnText;
                        btnCodeL2.Tag = btnTag;

                        break;

                    case "btnCodeL3":

                        btnCodeL3.Visible = true;
                        btnCodeL3.Text = btnText;
                        btnCodeL3.Tag = btnTag;

                        break;

                    case "btnCodeL4":

                        btnCodeL4.Visible = true;
                        btnCodeL4.Text = btnText;
                        btnCodeL4.Tag = btnTag;

                        break;

                    case "btnCodeL5":

                        btnCodeL5.Visible = true;
                        btnCodeL5.Text = btnText;
                        btnCodeL5.Tag = btnTag;

                        break;

                    case "btnCodeL6":

                        btnCodeL6.Visible = true;
                        btnCodeL6.Text = btnText;
                        btnCodeL6.Tag = btnTag;

                        break;

                    case "btnCodeL7":

                        btnCodeL7.Visible = true;
                        btnCodeL7.Text = btnText;
                        btnCodeL7.Tag = btnTag;

                        break;

                    case "btnCodeL8":

                        btnCodeL8.Visible = true;
                        btnCodeL8.Text = btnText;
                        btnCodeL8.Tag = btnTag;

                        break;

                    case "btnCodeL9":

                        btnCodeL9.Visible = true;
                        btnCodeL9.Text = btnText;
                        btnCodeL9.Tag = btnTag;

                        break;

                    case "btnCodeL10":

                        btnCodeL10.Visible = true;
                        btnCodeL10.Text = btnText;
                        btnCodeL10.Tag = btnTag;

                        break;

                    case "btnCodeL11":

                        btnCodeL11.Visible = true;
                        btnCodeL11.Text = btnText;
                        btnCodeL11.Tag = btnTag;

                        break;

                    case "btnCodeL12":

                        btnCodeL12.Visible = true;
                        btnCodeL12.Text = btnText;
                        btnCodeL12.Tag = btnTag;

                        break;

                    case "btnCodeL13":

                        btnCodeL13.Visible = true;
                        btnCodeL13.Text = btnText;
                        btnCodeL13.Tag = btnTag;

                        break;

                    case "btnCodeL14":

                        btnCodeL14.Visible = true;
                        btnCodeL14.Text = btnText;
                        btnCodeL14.Tag = btnTag;

                        break;

                    case "btnCodeL15":

                        btnCodeL15.Visible = true;
                        btnCodeL15.Text = btnText;
                        btnCodeL15.Tag = btnTag;

                        break;

                    case "btnCodeL16":

                        btnCodeL16.Visible = true;
                        btnCodeL16.Text = btnText;
                        btnCodeL16.Tag = btnTag;

                        break;

                    case "btnCodeL17":

                        btnCodeL17.Visible = true;
                        btnCodeL17.Text = btnText;
                        btnCodeL17.Tag = btnTag;

                        break;

                    case "btnCodeL18":

                        btnCodeL18.Visible = true;
                        btnCodeL18.Text = btnText;
                        btnCodeL18.Tag = btnTag;

                        break;

                    case "btnCodeL19":

                        btnCodeL19.Visible = true;
                        btnCodeL19.Text = btnText;
                        btnCodeL19.Tag = btnTag;

                        break;

                    case "btnCodeL20":

                        btnCodeL20.Visible = true;
                        btnCodeL20.Text = btnText;
                        btnCodeL20.Tag = btnTag;

                        break;

                    case "btnCodeL21":

                        btnCodeL21.Visible = true;
                        btnCodeL21.Text = btnText;
                        btnCodeL21.Tag = btnTag;

                        break;

                    case "btnCodeL22":

                        btnCodeL22.Visible = true;
                        btnCodeL22.Text = btnText;
                        btnCodeL22.Tag = btnTag;

                        break;

                    case "btnCodeL23":

                        btnCodeL23.Visible = true;
                        btnCodeL23.Text = btnText;
                        btnCodeL23.Tag = btnTag;

                        break;

                    case "btnCodeL24":

                        btnCodeL24.Visible = true;
                        btnCodeL24.Text = btnText;
                        btnCodeL24.Tag = btnTag;

                        break;

                    //중
                    case "btnCodeM1":

                        btnCodeM1.Visible = true;
                        btnCodeM1.Text = btnText;
                        btnCodeM1.Tag = btnTag;

                        break;

                    case "btnCodeM2":

                        btnCodeM2.Visible = true;
                        btnCodeM2.Text = btnText;
                        btnCodeM2.Tag = btnTag;

                        break;

                    case "btnCodeM3":

                        btnCodeM3.Visible = true;
                        btnCodeM3.Text = btnText;
                        btnCodeM3.Tag = btnTag;

                        break;

                    case "btnCodeM4":

                        btnCodeM4.Visible = true;
                        btnCodeM4.Text = btnText;
                        btnCodeM4.Tag = btnTag;

                        break;

                    case "btnCodeM5":

                        btnCodeM5.Visible = true;
                        btnCodeM5.Text = btnText;
                        btnCodeM5.Tag = btnTag;

                        break;

                    case "btnCodeM6":

                        btnCodeM6.Visible = true;
                        btnCodeM6.Text = btnText;
                        btnCodeM6.Tag = btnTag;

                        break;

                    case "btnCodeM7":

                        btnCodeM7.Visible = true;
                        btnCodeM7.Text = btnText;
                        btnCodeM7.Tag = btnTag;

                        break;

                    case "btnCodeM8":

                        btnCodeM8.Visible = true;
                        btnCodeM8.Text = btnText;
                        btnCodeM8.Tag = btnTag;

                        break;

                    case "btnCodeM9":

                        btnCodeM9.Visible = true;
                        btnCodeM9.Text = btnText;
                        btnCodeM9.Tag = btnTag;

                        break;

                    case "btnCodeM10":

                        btnCodeM10.Visible = true;
                        btnCodeM10.Text = btnText;
                        btnCodeM10.Tag = btnTag;

                        break;

                    case "btnCodeM11":

                        btnCodeM11.Visible = true;
                        btnCodeM11.Text = btnText;
                        btnCodeM11.Tag = btnTag;

                        break;

                    case "btnCodeM12":

                        btnCodeM12.Visible = true;
                        btnCodeM12.Text = btnText;
                        btnCodeM12.Tag = btnTag;

                        break;

                    case "btnCodeM13":

                        btnCodeM13.Visible = true;
                        btnCodeM13.Text = btnText;
                        btnCodeM13.Tag = btnTag;

                        break;

                    case "btnCodeM14":

                        btnCodeM14.Visible = true;
                        btnCodeM14.Text = btnText;
                        btnCodeM14.Tag = btnTag;

                        break;

                    case "btnCodeM15":

                        btnCodeM15.Visible = true;
                        btnCodeM15.Text = btnText;
                        btnCodeM15.Tag = btnTag;

                        break;

                    case "btnCodeM16":

                        btnCodeM16.Visible = true;
                        btnCodeM16.Text = btnText;
                        btnCodeM16.Tag = btnTag;

                        break;

                    case "btnCodeM17":

                        btnCodeM17.Visible = true;
                        btnCodeM17.Text = btnText;
                        btnCodeM17.Tag = btnTag;

                        break;

                    case "btnCodeM18":

                        btnCodeM18.Visible = true;
                        btnCodeM18.Text = btnText;
                        btnCodeM18.Tag = btnTag;

                        break;

                    case "btnCodeM19":

                        btnCodeM19.Visible = true;
                        btnCodeM19.Text = btnText;
                        btnCodeM19.Tag = btnTag;

                        break;

                    case "btnCodeM20":

                        btnCodeM20.Visible = true;
                        btnCodeM20.Text = btnText;
                        btnCodeM20.Tag = btnTag;

                        break;

                    case "btnCodeM21":

                        btnCodeM21.Visible = true;
                        btnCodeM21.Text = btnText;
                        btnCodeM21.Tag = btnTag;

                        break;

                    case "btnCodeM22":

                        btnCodeM22.Visible = true;
                        btnCodeM22.Text = btnText;
                        btnCodeM22.Tag = btnTag;

                        break;

                    case "btnCodeM23":

                        btnCodeM23.Visible = true;
                        btnCodeM23.Text = btnText;
                        btnCodeM23.Tag = btnTag;

                        break;

                    case "btnCodeM24":

                        btnCodeM24.Visible = true;
                        btnCodeM24.Text = btnText;
                        btnCodeM24.Tag = btnTag;

                        break;

                    //소
                    case "btnCodeS1":

                        btnCodeS1.Visible = true;
                        btnCodeS1.Text = btnText;
                        btnCodeS1.Tag = btnTag;

                        break;

                    case "btnCodeS2":

                        btnCodeS2.Visible = true;
                        btnCodeS2.Text = btnText;
                        btnCodeS2.Tag = btnTag;

                        break;

                    case "btnCodeS3":

                        btnCodeS3.Visible = true;
                        btnCodeS3.Text = btnText;
                        btnCodeS3.Tag = btnTag;

                        break;

                    case "btnCodeS4":

                        btnCodeS4.Visible = true;
                        btnCodeS4.Text = btnText;
                        btnCodeS4.Tag = btnTag;

                        break;

                    case "btnCodeS5":

                        btnCodeS5.Visible = true;
                        btnCodeS5.Text = btnText;
                        btnCodeS5.Tag = btnTag;

                        break;

                    case "btnCodeS6":

                        btnCodeS6.Visible = true;
                        btnCodeS6.Text = btnText;
                        btnCodeS6.Tag = btnTag;

                        break;

                    case "btnCodeS7":

                        btnCodeS7.Visible = true;
                        btnCodeS7.Text = btnText;
                        btnCodeS7.Tag = btnTag;

                        break;

                    case "btnCodeS8":

                        btnCodeS8.Visible = true;
                        btnCodeS8.Text = btnText;
                        btnCodeS8.Tag = btnTag;

                        break;

                    case "btnCodeS9":

                        btnCodeS9.Visible = true;
                        btnCodeS9.Text = btnText;
                        btnCodeS9.Tag = btnTag;

                        break;

                    case "btnCodeS10":

                        btnCodeS10.Visible = true;
                        btnCodeS10.Text = btnText;
                        btnCodeS10.Tag = btnTag;

                        break;

                    case "btnCodeS11":

                        btnCodeS11.Visible = true;
                        btnCodeS11.Text = btnText;
                        btnCodeS11.Tag = btnTag;

                        break;

                    case "btnCodeS12":

                        btnCodeS12.Visible = true;
                        btnCodeS12.Text = btnText;
                        btnCodeS12.Tag = btnTag;

                        break;

                    case "btnCodeS13":

                        btnCodeS13.Visible = true;
                        btnCodeS13.Text = btnText;
                        btnCodeS13.Tag = btnTag;

                        break;

                    case "btnCodeS14":

                        btnCodeS14.Visible = true;
                        btnCodeS14.Text = btnText;
                        btnCodeS14.Tag = btnTag;

                        break;

                    case "btnCodeS15":

                        btnCodeS15.Visible = true;
                        btnCodeS15.Text = btnText;
                        btnCodeS15.Tag = btnTag;

                        break;

                    case "btnCodeS16":

                        btnCodeS16.Visible = true;
                        btnCodeS16.Text = btnText;
                        btnCodeS16.Tag = btnTag;

                        break;

                    case "btnCodeS17":

                        btnCodeS17.Visible = true;
                        btnCodeS17.Text = btnText;
                        btnCodeS17.Tag = btnTag;

                        break;

                    case "btnCodeS18":

                        btnCodeS18.Visible = true;
                        btnCodeS18.Text = btnText;
                        btnCodeS18.Tag = btnTag;

                        break;

                    case "btnCodeS19":

                        btnCodeS19.Visible = true;
                        btnCodeS19.Text = btnText;
                        btnCodeS19.Tag = btnTag;

                        break;

                    case "btnCodeS20":

                        btnCodeS20.Visible = true;
                        btnCodeS20.Text = btnText;
                        btnCodeS20.Tag = btnTag;

                        break;

                    case "btnCodeS21":

                        btnCodeS21.Visible = true;
                        btnCodeS21.Text = btnText;
                        btnCodeS21.Tag = btnTag;

                        break;

                    case "btnCodeS22":

                        btnCodeS22.Visible = true;
                        btnCodeS22.Text = btnText;
                        btnCodeS22.Tag = btnTag;

                        break;

                    case "btnCodeS23":

                        btnCodeS23.Visible = true;
                        btnCodeS23.Text = btnText;
                        btnCodeS23.Tag = btnTag;

                        break;

                    case "btnCodeS24":

                        btnCodeS24.Visible = true;
                        btnCodeS24.Text = btnText;
                        btnCodeS24.Tag = btnTag;

                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void VisibleInfo(string sScreenStatus)
        {
            try
            {
                if (sScreenStatus == "L")
                {
                    grpCode.Text = "Nonmoving Code(L)";
                    _sStatus = "L";

                    pnlCodeL.Visible = true;
                    pnlCodeM.Visible = false;
                    pnlCodeS.Visible = false;
                }
                else if (sScreenStatus == "M")
                {
                    grpCode.Text = "Nonmoving Code(M)";
                    _sStatus = "M";

                    pnlCodeL.Visible = false;
                    pnlCodeM.Visible = true;
                    pnlCodeS.Visible = false;
                }
                else if (sScreenStatus == "S")
                {
                    grpCode.Text = "Nonmoving Code(S)";
                    _sStatus = "S";

                    pnlCodeL.Visible = false;
                    pnlCodeM.Visible = false;
                    pnlCodeS.Visible = true;
                }

                MPCF.ConvertCaption(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void BackVisibleInfo(string sScreenStatus)
        {
            try
            {
                if (sScreenStatus == "M")
                {
                    grpCode.Text = "Nonmoving Code(L)";
                    _sStatus = "L";

                    pnlCodeL.Visible = true;
                    pnlCodeM.Visible = false;
                    pnlCodeS.Visible = false;
                }
                else if (sScreenStatus == "S")
                {
                    grpCode.Text = "Nonmoving Code(M)";
                    _sStatus = "M";

                    pnlCodeL.Visible = false;
                    pnlCodeM.Visible = true;
                    pnlCodeS.Visible = false;
                }

                MPCF.ConvertCaption(this);
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }


        #endregion

    }
}
