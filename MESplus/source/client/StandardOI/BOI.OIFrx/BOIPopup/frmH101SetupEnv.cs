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

namespace BOI.OIFrx.Popup
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmH101SetupEnv : frmPopupBase
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

        private string _line = string.Empty;

        public string Line
        {
            get { return _line; }
            set 
            { 
                _line = value;
                cdvLineID.Text = _line;
            }
        }

        private string _lineDesc = string.Empty;

        public string LineDesc
        {
            get { return _lineDesc; }
            set 
            { 
                _lineDesc = value;
                txtLineDesc.Text = _lineDesc;
            }
        }

        private string _oper = string.Empty;

        public string Oper
        {
            get { return _oper; }
            set 
            { 
                _oper = value;
                cdvOper.Text = _oper;
            }
        }

        private string _operDesc = string.Empty;

        public string OperDesc
        {
            get { return _operDesc; }
            set 
            { 
                _operDesc = value;
                txtOperDesc.Text = _operDesc;
            }
        }

        private string _resId = string.Empty;

        public string ResId
        {
            get { return _resId; }
            set 
            { 
                _resId = value;
                cdvResID.Text = _resId;
            }
        }

        private string _resDesc = string.Empty;

        public string ResDesc
        {
            get { return _resDesc; }
            set 
            { 
                _resDesc = value;
                txtResDesc.Text = _resDesc;
            }
        }

        private bool _useIpAddress = false;

        public bool UseIpAddress
        {
            get { return _useIpAddress; }
            set 
            { 
                _useIpAddress = value;
                if (_useIpAddress == true)
                {
                    chkUseIPAddress.OnOffState = SOICheckBoxOnOffState.OnState;
                }
                else
                {
                    chkUseIPAddress.OnOffState = SOICheckBoxOnOffState.OffState;
                }
            }
        }  



        #endregion

        #region Constructor

        public frmH101SetupEnv()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _line = MPCF.Trim(cdvLineID.Text);
                _lineDesc = MPCF.Trim(txtLineDesc.Text);
                _oper = MPCF.Trim(cdvOper.Text);
                _operDesc = MPCF.Trim(txtOperDesc.Text);
                _resId = MPCF.Trim(cdvResID.Text);
                _resDesc = MPCF.Trim(txtResDesc.Text);
                _useIpAddress = chkUseIPAddress.OnOffState == SOICheckBoxOnOffState.OnState ? true : false;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvOper_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                TPDR.DirectViewCond[] dvcArgu = new TPDR.DirectViewCond[3];

                dvcArgu[0].sCondtion_ID = "FACTORY";
                dvcArgu[0].sCondition_Value = MPGV.gsFactory;

                dvcArgu[1].sCondtion_ID = "LINE_ID";
                dvcArgu[1].sCondition_Value = MPCF.Trim(cdvLineID.Text);

                dvcArgu[2].sCondtion_ID = "OPER_CMF_3";
                dvcArgu[2].sCondition_Value = "";

                // CodeView Column Header Setup
                string[] header = new string[] { "Oper", "Description" };

                // CodeView Display Column Setup
                string[] display = new string[] { "OPER", "OPER_SHORT_DESC" };

                // Show
                cdvOper.Text = cdvOper.Show(cdvOper, "Code", "COM0000-020", dvcArgu, display, header, "OPER", -1);

                if (MPCF.Trim(cdvOper.Text) != "")
                {
                    if (cdvOper.returnDatas != null && cdvOper.returnDatas.Count > 0)
                    {
                        txtOperDesc.Text = cdvOper.returnDatas[1];
                    }
                    else
                    {
                        txtOperDesc.Text = "";
                    }
                }
                else
                {
                    txtOperDesc.Text = "";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        private void cdvResID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (BICF.ViewResource(cdvResID, "", MPCF.Trim(cdvLineID.Text), MPCF.Trim(cdvOper.Text)) == true)
                {
                    if (cdvResID.Text != string.Empty)
                    {
                        txtResDesc.Text = cdvResID.Text;
                    }
                    cdvResID.Text = MPCF.Trim(cdvResID.Tag);
                }

                
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        private void cdvLineID_CodeViewButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (BICF.ViewLine(cdvLineID, "") == true)
                {
                    if (cdvLineID.Text != string.Empty)
                    {
                        txtLineDesc.Text = cdvLineID.Text;
                    }
                    cdvLineID.Text = MPCF.Trim(cdvLineID.Tag);
                }
                
            }
            catch (System.Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        

        #region Function

        #endregion        
    }
}
