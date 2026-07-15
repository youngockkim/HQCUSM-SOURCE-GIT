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
using Infragistics.Win;
using Infragistics.Win.Design;
using BOI.OIFrx.BOIControls;
using System.Security.Policy;

namespace SOI.HanwhaQcell.USModule
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmCWIPStringCellImagePopup : frmPopupBase
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

        #endregion

        #region Constructor
        
        private Bitmap moduleImage = null;

        public String _Type;

        public string img;

        public string number2;

        public frmCWIPStringCellImagePopup(String url)
        {
            InitializeComponent();
            /*
            var request = System.Net.HttpWebRequest.Create(url);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                soiPictureBox1.Image = Bitmap.FromStream(stream);
            }
            */

            var request = System.Net.HttpWebRequest.Create(url);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                moduleImage = new Bitmap(stream);
                soiPictureBox1.Image = moduleImage;
            }

            /*
            System.Net.WebClient client = new System.Net.WebClient();
            client.DownloadFile(url, "test.jpg");
            moduleImage = new Bitmap("test.jpg");
            soiPictureBox1.Image = moduleImage;
            */
        }

        public frmCWIPStringCellImagePopup(String url, String type, String number)
        {
            InitializeComponent();

            soiPictureBox1.Image = null;

            lblPopupTitle.Text = "MODULE IMAGE " + "String Number ( " + number + " )";

            if (!String.IsNullOrEmpty(url))
            {
                var request = System.Net.HttpWebRequest.Create(url);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    moduleImage = new Bitmap(stream);
                    soiPictureBox1.Image = moduleImage;
                }
            }

            img = url;
            number = number2;
        }

        #endregion


        #region [Constant Definition]



        #endregion

        #region [Variable Definition]

        public bool outTimerEnabled = true;

        #endregion


        #region Event Handler

        /// <summary>
        /// (Required) Form Load
        /// - Convert Caption
        /// - Form Activate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCWIPFullCellImagePopup_Load(object sender, EventArgs e)
        {
            // Caption 변경
            MPCF.ConvertCaption(this);

            // (Required) Grid Initialize


            // 활성화
            this.Activate();

            //if (img == null || img == "" || img == " ")
            //{

            //    string strViewError;
            //    string strErrorMsg = "The string does not have an image.";
            //    strViewError =
            //                   "String Number ( " + number2 + " )" + "\r\n"
            //                 + "----------------------------------\r\n"
            //                 + strErrorMsg;

            //    // 기본 dll ShowMessage
            //    MPCF.ShowMessage(strViewError, MSG_LEVEL.ERROR, true);
            //}
        }

        /// <summary>
        /// (Required) Close Button Click
        /// - Form Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (moduleImage != null)
            {
                moduleImage.Dispose();
            }
            soiPictureBox1.Image = "";

            _Type = "2"; // 1 next , 2 close

            this.Close();
        }

        /// <summary>
        /// Next IMG 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (moduleImage != null)
            {
                moduleImage.Dispose();
            }
            soiPictureBox1.Image = "";

            _Type = "1"; // 1 next , 2 close

            this.Close();
        }

        #endregion


        #region Functions

        public void setPic(string url)
        {
            soiPictureBox1.Image = null;

            if (!String.IsNullOrEmpty(url))
            {
                var request = System.Net.HttpWebRequest.Create(url);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    moduleImage = new Bitmap(stream);
                    soiPictureBox1.Image = moduleImage;
                }
            }
        }


        #endregion

        
    }
}
