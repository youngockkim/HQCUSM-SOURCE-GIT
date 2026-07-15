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
using SOI.DNM;

namespace BOI.WIPCus.Popup
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmWIPSelectHoldReleasePopup : frmPopupBase
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

        public string _sCode
        {
            get;
            set;
        }

        public string _sCodeValue = string.Empty;
        public string _sComment = string.Empty;

        #endregion

        #region Constructor

        public frmWIPSelectHoldReleasePopup()
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
            if (_sCode == "R")
            {
                lblCode.Text = "Release Code";
                lblCode.Tag = "R";
            }
            else
            {
                lblCode.Text = "Hold Code";
                lblCode.Tag = "H";
            }

            cdvCode.Text = string.Empty;
            cdvCode.Tag = string.Empty;
            txtComment.Text = string.Empty;

            // Caption 변경
            MPCF.ConvertCaption(this);

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
            //this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                _sCodeValue = cdvCode.Tag.ToString();
                _sComment = txtComment.Text;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvCode_CodeViewButtonClick(object sender, EventArgs e)
        {
            string sTableName = string.Empty;

            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[2];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                if (lblCode.Tag.ToString() == "H")
                {
                    sTableName = "HOLD_CODE";
                }
                else
                {
                    sTableName = "RELEASE_CODE";
                }

                dvcArgu[1].sCondtion_ID = "TABLE_NAME";
                dvcArgu[1].sCondition_Value = sTableName;

                // CodeView Column Header Setup
                string[] header = new string[] { "Code", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "KEY_1", "DATA_1" };

                // Show
                cdvCode.Text = cdvCode.Show(cdvCode, "Code", "COM0000-001", dvcArgu, display, header, "DATA_1", -1);

                if (MPCF.Trim(cdvCode.Text) != "")
                {
                    if (cdvCode.returnDatas != null && cdvCode.returnDatas.Count > 0)
                    {
                        cdvCode.Tag = cdvCode.returnDatas[0];
                    }
                    else
                    {
                        //cdvCode.Tag = "";
                    }
                }
                else
                {
                    cdvCode.Tag = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        #endregion        
    }
}
