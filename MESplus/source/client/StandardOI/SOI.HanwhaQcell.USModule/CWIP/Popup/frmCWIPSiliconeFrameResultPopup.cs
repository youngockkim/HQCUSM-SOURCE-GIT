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
    public partial class frmCWIPSiliconeFrameResultPopup : frmPopupBase
    {
        //ISSUE-07-011 : FQC 재판정 OI수정
        #region Property

        public string ReturnValue;
        public string frame_short_rs = "NG";
        public string frame_long_rs = "NG";
        public string title = string.Empty;

        #endregion


        #region Constructor

        public frmCWIPSiliconeFrameResultPopup()
        {
            InitializeComponent();

        }

        #endregion


        #region Event Handler

        private void frmCWIPSiliconeFrameResultPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            frameSW.Text = frame_short_rs;
            frameLW.Text = frame_long_rs;
            
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