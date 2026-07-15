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

namespace BOI.WIPCus
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmWIPInputEndQty : frmPopupBase
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

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

        private double _endQty = 0.0d;

        public double EndQty
        {
            get { return _endQty; }
            set 
            { 
                _endQty = value;
                numEndQty.Value = _endQty;
            }
        }

        #endregion

        #region Constructor

        public frmWIPInputEndQty()
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

        private void frmWIPInputEndQty_Activated(object sender, EventArgs e)
        {
             // (Required) 
            if (bIsShown == false)
            {
                this.btnClose.Focus();

                bIsShown = true;
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
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            _endQty = MPCF.ToDbl(numEndQty.Value);
            if (_endQty <= 0)
            {
                MPCF.ShowMessage(MPCF.GetMessage(114), MSG_LEVEL.ERROR, true);
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

       
        #endregion

       

        

        #region Function

        #endregion
    }
}
