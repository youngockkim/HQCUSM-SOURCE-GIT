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
using SOI.OIFrx.SOIContorls;
using SOI.OIFrx.SOIControls;
using SOI.OIFrx.SOIPopup;
using SOI.OIFrx.SOIModel;
using SOI.CliFrx;
using Infragistics.Win.UltraWinGrid;

namespace SOI.ATP
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmATPPurchaseInspection : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmATPPurchaseInspection()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Load(object sender, EventArgs e)
        {
            // TEST DATA
            txtDeliveryDocu.Text = "DGV004716126016";
            txtDeliveryDate.Text = "2016-01-26";
            txtCustomer.Text = "DM";
            txtReqQty.Text = "72";
            txtMatCode.Text = "88370-4H000KD";
            txtMatDesc.Text = "BACK COVER ASSY-FR SEA";
            txtDeliveryStatus.Text = "Complete";

            for (int i = 0; i < 1; i++)
            {
                if (i > 0)
                {
                    spdMatSum.Sheets[0].Rows.Count++;
                }

                spdMatSum.Sheets[0].Cells[i, 0].Value = (i + 1).ToString();
                spdMatSum.Sheets[0].Cells[i, 1].Value = "88370-4H000KD";
                spdMatSum.Sheets[0].Cells[i, 2].Value = "BACK COVER ASSY-FR SEAT";
                spdMatSum.Sheets[0].Cells[i, 3].Value = "72";
                spdMatSum.Sheets[0].Cells[i, 4].Value = "36";
                spdMatSum.Sheets[0].Cells[i, 5].Value = "36";
            }

            for (int i = 0; i < 5; i++)
            {
                if (i > 0)
                {
                    spdPartIDTagList.Sheets[0].Rows.Count++;
                }

                spdPartIDTagList.Sheets[0].Cells[i, 0].Value = true;
                spdPartIDTagList.Sheets[0].Cells[i, 1].Value = "PGP161260000657" + i.ToString();
                spdPartIDTagList.Sheets[0].Cells[i, 2].Value = "88370-4H000KD";
                spdPartIDTagList.Sheets[0].Cells[i, 3].Value = "12";
            }

            // (Required) Convert Caption
            // 모든 로드가 완료되면 Caption 변환을 위해 아래 구문을 추가해야 합니다.
            MPCF.ConvertCaption(this);
        }

        /// <summary>
        /// (Required) Form Shown
        /// - Focus Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempSOIBaseForm02_Shown(object sender, EventArgs e)
        {
            // (Required) 
            if (bIsShown == false)
            {
                // (Required) Init Focus Control
                // MPCF.SetFocus(control);                

                // (Required) 
                bIsShown = true;
            }
        }

        #endregion

        #region Function

        #endregion
    }
}
