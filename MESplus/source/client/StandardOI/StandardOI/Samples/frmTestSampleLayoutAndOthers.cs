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

namespace StandardOI.Samples
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmTestSampleLayoutAndOthers : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmTestSampleLayoutAndOthers()
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


        /// <summary>
        /// Show Information Message 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfoMsgBox_Click(object sender, EventArgs e)
        {
            // Show Information Message Box
            MPCF.ShowMessage("This is Information Message.", SOI.CliFrx.MSG_LEVEL.INFO, true);
        }

        /// <summary>
        /// Show Warning Message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWarnMsgBox_Click(object sender, EventArgs e)
        {
            // Show Warning Message
            MPCF.ShowMessage("This is Warning Message.", SOI.CliFrx.MSG_LEVEL.WARNING, true);

            // OK Cancel Message
            // ShowMsgBox는 하단에 메시지를 표시하지 않고 팝업창으로만 표현합니다.
            // MessageBoxButtons Enum에서 AbortRetryIgnore와 Retry Cancel은 사용되지 않습니다.
            DialogResult dr = MPCF.ShowMsgBox("This is Warning Message with OK and Cancel Button.", MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // Show Warning Message with other caption
                DialogResult dr2 = MPCF.ShowMsgBox("This is Warning Message.", MessageBoxButtons.OKCancel, SOI.CliFrx.MSG_LEVEL.WARNING, "Caption can be changed.");
                if (dr2 == System.Windows.Forms.DialogResult.OK)
                {
                    // Show Warning Message without Popup
                    MPCF.ShowMessage("This is Warning Message without Popup.", SOI.CliFrx.MSG_LEVEL.WARNING, false);
                }
            }

            // ** MessageBoxButtons.AbortRetryIgnore and MessageBoxButtons.RetryCancel is not allowed.
            // MessageBoxButtons Enum에서 AbortRetryIgnore와 Retry Cancel은 사용되지 않습니다.
            //MPCF.ShowMsgBox("Not used.", MessageBoxButtons.AbortRetryIgnore, SOI.CliFrx.MSG_LEVEL.WARNING);
            //MPCF.ShowMsgBox("Not used.", MessageBoxButtons.RetryCancel, SOI.CliFrx.MSG_LEVEL.WARNING);
        }

        /// <summary>
        /// Show Error Message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnErrMsgBox_Click(object sender, EventArgs e)
        {
            // Show Error Message
            MPCF.ShowMessage("This is Error Message.", SOI.CliFrx.MSG_LEVEL.ERROR, true);
        }

        /// <summary>
        /// Show None Message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoneMsgBox_Click(object sender, EventArgs e)
        {
            // Show None Message
            MPCF.ShowMessage("This is None Message.", SOI.CliFrx.MSG_LEVEL.NONE, true);

            // Yes No Message
            // ShowMsgBox는 하단에 메시지를 표시하지 않고 팝업창으로만 표현합니다.
            MPCF.ShowMsgBox("This is None Message with Yes and No Button.", MessageBoxButtons.YesNo, SOI.CliFrx.MSG_LEVEL.NONE);
        }

        /// <summary>
        /// SOITabControl Selected Tab Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soiTabControl2_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            // Selected Tab이 변경되었을 때, 발생합니다.
            MPCF.ShowMessage(e.Tab.Text, SOI.CliFrx.MSG_LEVEL.INFO, false);
        }

        /// <summary>
        /// (Option) SOIButtonImageViewer Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewImage_Click(object sender, EventArgs e)
        {
            // (Option) Run Image Viewer by Common Method
            // 해당 버튼이 아닌 로직만으로도 동일한 이미지 뷰어를 실행할 수 있습니다.
            //MPCF.RunImageViewer(Properties.Resources.SettingsImage);

            // (Option) Byte Array Data to Image 
            // Byte Array Data를 받은 경우에는 아래 함수를 통해 Image로 변환하고 실행합니다.
            //MPCF.RunImageViewer(MPCF.ByteArrayToImage(new byte[] { }));
        }

        /// <summary>
        /// (Option) SOIButtonPDFView Click Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewPDF_Click(object sender, EventArgs e)
        {
            // (Option) Run PDF View
            // 이벤트 핸들러를 할당 후, 파일 경로를 추가해야 합니다.
            //btnViewPDF.RunPDFView(@"D:\MESplusOI.pdf");

            // (Option) Run PDF View
            // 파일 경로를 미리 설정해 놓은뒤, 나중에 실행만 할 수도 있습니다.
            //btnViewPDF.PDFFilePath = @"D:\MESplusOI.pdf"
            //btnViewPDF.RunPDFView();
        }

        #endregion

        #region Function

        #endregion
    }
}
