#if _H101
using SOI.MsgHandlerH101;
#endif
#if _Http
using SOI.MsgHandlerHTTP;
#endif
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
using System.Collections;

namespace StandardOI.Samples
{
    // (Required) Inherit Base Form
    // SOIBaseForm02 Common Role    
    // - Convert Theme 
    // - Register Favorite 
    // - Default Bottom Button : Process, Cancel 
    // - (option) Help Information Button
    // - (option for SE) Standard Operation Button
    public partial class frmTestSampleMessageFromHttp : SOIBaseForm02
    {
        #region Property

        // (Required) 
        private bool bIsShown = false;

        #endregion

        #region Constructor

        public frmTestSampleMessageFromHttp()
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
            // 사전작업
            // 1) Server에 Channel을 추가합니다.
            // 2) Login 서비스에서 해당 채널 명을 전송받아 전역변수에 등록합니다.
            // 3) 해당 채널에 대한 Tuner, TunerImpl, Model을 생성합니다.
            // 4) Message Handler 초기화 시, 해당 채널을 등록합니다.
            // 5) 해당 채널에 대한 dispatcher를 등록/등록 해제하는 함수를 생성합니다.
            // 6) Dispatcher를 등록/등록해제하여 채널을 사용하거나 사용하지 않을 수 있습니다.

            // Initialize
            // (Option) 필드를 초기화 합니다.
            if (CheckTuneStatus("ALM") == true)
            {
                txtStatus.Text = MPCF.FindLanguage("Tune");
            }
            else
            {
                txtStatus.Text = MPCF.FindLanguage("Untune");
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

        /// <summary>
        /// (Option) Tune
        /// Tune Message Channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // 해당 채널이 Tune되어 있는지 확인
                if (CheckTuneStatus("ALM") == true)
                {
                    
                }
                else
                {
                    // 해당 채널에 대한 Dispatcher를 등록
                    if (PublishMsgTune.PublishALMMsgTune() == false)
                    {
                        return;
                    }

                    txtStatus.Text = MPCF.FindLanguage("Tune");
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, MSG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// (Option) Untune
        /// Untune Message Channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUntune_Click(object sender, EventArgs e)
        {
            try
            {
                // 해당 채널이 Tune되어 있는지 확인
                if (CheckTuneStatus("ALM") == true)
                {
                    // 해당 채널에 대한 Dispatcher를 등록해제
                    MPMH.unregisterDispatcher("ALM");

                    txtStatus.Text = MPCF.FindLanguage("Untune");
                }
                else
                {
                    
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
        /// 채널 명(module)으로 등록된 Dispatcher를 검색합니다.
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        private bool CheckTuneStatus(string module)
        {
            try
            {
                Hashtable ht = MPMH.Instance.getDispatcher();

                if (ht.Count > 0
                    && ht.Contains(module))
                {
                    
                }
                else
                {
                    return false;
                }

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
