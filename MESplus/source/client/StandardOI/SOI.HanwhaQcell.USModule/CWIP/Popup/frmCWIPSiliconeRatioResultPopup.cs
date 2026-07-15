using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.TRSCore;
using SOI.OIFrx;
using SOI.OIFrx.SOIBaseForm;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.HanwhaQcell.USModule.CWIP.Popup
{
    public partial class frmCWIPSiliconeRatioResultPopup : frmPopupBase
    {
        //ISSUE-07-011 : FQC 재판정 OI수정
        #region Property

        public string ReturnValue;
        public string ratio_rs = "NG";
        public string ratio_rs2 = "NG";

        #endregion


        #region Constructor

        public frmCWIPSiliconeRatioResultPopup()
        {
            InitializeComponent();
        }

        #endregion


        #region Event Handler

        private void frmCWIPSiliconeWeightResultPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            lblPopupTitle.Text = "Potting Silicone Weight";
            ratioRs.Text = ratio_rs;
            ratioRs2.Text = ratio_rs2;
            // 활성화
            this.Activate();
        }
        
        private void spdCellMap_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            /*
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.ReturnValue = string.Empty;

            this.Close();
             * */
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ReturnValue = string.Empty;

            this.Close();
        }

        
        #endregion

        private void btnVertical_Click(object sender, EventArgs e)
        {
            /*
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ReturnValue = string.Empty;

            this.Close();
             * */
        }

    }
}