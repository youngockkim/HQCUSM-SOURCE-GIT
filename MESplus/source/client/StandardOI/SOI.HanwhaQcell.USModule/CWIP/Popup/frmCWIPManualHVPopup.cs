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
    public partial class frmCWIPManualHVPopup : frmPopupBase
    {
        //ISSUE-07-011 : FQC 재판정 OI수정
        #region Property

        public string ReturnValue;

        #endregion


        #region Constructor

        public frmCWIPManualHVPopup()
        {
            InitializeComponent();
        }

        #endregion


        #region Event Handler

        private void frmCWIPManualHVPopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            lblPopupTitle.Text = "Manual Packing H/V";
            soiLabel1.Text = MPCF.GetMessage(559);
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
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.ReturnValue = string.Empty;

            this.Close();
        }

        
        #endregion

        private void btnVertical_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ReturnValue = string.Empty;

            this.Close();
        }
    }
}