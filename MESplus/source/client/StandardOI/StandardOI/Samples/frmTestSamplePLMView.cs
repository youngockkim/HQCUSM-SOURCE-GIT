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
using System.Net;
using System.IO;

namespace StandardOI.Samples
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmTestSamplePLMView : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmTestSamplePLMView()
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
        /// Clear TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (clearLog() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// (Option) Button Click
        /// Show Browser with PLM Document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPLMView_Click(object sender, EventArgs e)
        {
            try
            {
                //RunBrowser("http://google.com");

                string url = "http://samco.stage.sdsplm.com/plm3/viewer/openViewer/com.sdsplm.productinfo.api.domain.model.drawing.Drawing:1013671";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Read Response
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream/*, UTF8Encoding.UTF8*/);

                    addLog("CODE : " + response.StatusCode);
                    addLog("Description : " + response.StatusDescription);
                    addLog(reader.ReadToEnd());
                }

                RunBrowser("http://samco.stage.sdsplm.com/plm3/viewer/openViewer/com.sdsplm.productinfo.api.domain.model.drawing.Drawing:1013671");
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// 해당 url로 Browser를 실행합니다.
        /// </summary>
        /// <param name="url"></param>
        public bool RunBrowser(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }            
        }

        /// <summary>
        /// Log를 TextBox에 Add 합니다.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool addLog(string text)
        {
            return addLog(true, text);
        }

        /// <summary>
        /// Log를 TextBox에 Add 합니다.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool addLog(bool newLine, string text)
        {
            try
            {
                StringBuilder sb = new StringBuilder(txtLogBox.Text);
                if (newLine == true)
                {
                    sb.Append("\n");
                    sb.Append(text);
                }
                else
                {
                    sb.Append(text);
                }

                txtLogBox.Text = sb.ToString();

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// Log를 클리어 합니다.
        /// </summary>
        /// <returns></returns>
        private bool clearLog()
        {
            try
            {
                txtLogBox.Text = string.Empty;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }
}
