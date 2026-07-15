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
    public partial class frmTestSampleImageFileUpload : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmTestSampleImageFileUpload()
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
        /// File을 찾는다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            try
            {
                txtImageFilePath.Text = string.Empty;
                pbSelectedImage.Image = null;

                if (SearchFile() == false)
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
        /// Upload File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(txtImageFilePath, false) == false)
                {
                    return;
                }

                if (UploadFile() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// File을 찾는 로직
        /// </summary>
        /// <returns></returns>
        private bool SearchFile()
        {
            try
            {
                byte[] data;
                string fileName;

                using(OpenFileDialog ofd = new OpenFileDialog())
                {
                    if(ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        return false;
                    }

                    fileName = ofd.FileName;
                    data = File.ReadAllBytes(fileName);

                    txtImageFilePath.Text = fileName;
                     pbSelectedImage.Image = MPCF.ByteArrayToImage(data);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        /// <summary>
        /// File Upload
        /// </summary>
        /// <returns></returns>
        private bool UploadFile()
        {
            try
            {
#if _Http
                TRSNode in_node = new TRSNode("UPDATE_ALARM_IN");
                TRSNode out_node = new TRSNode("UPDATE_ALARM_OUT");

                MPCF.SetInMsg(in_node);
                byte[] file = File.ReadAllBytes(txtImageFilePath.Text);
                //in_node.AddBlob(MPGC.MP_BIN_DATA_1, file);
                MPCF.SetInFile(ref in_node, file, "ABC.JPG");

                in_node.AddString("ALARM_ID", "CMN-0002");
                
                if (MPCF.CallService("ALM", "ALM_UPDATE_ALARM_MSG", in_node, ref out_node) == false)
                {
                    return false;
                }
#endif

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
