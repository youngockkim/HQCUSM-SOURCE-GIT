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

namespace SOI.OIFrx.SOIPopup
{
    // (Required) Inherit Popup Base Form
    // frmPopupBase Common Role    
    // - Convert Theme 
    // - Show and Hide Background Shadow Form when popup form is loaded.
    // - Default Bottom Button : Close 
    public partial class frmStdOperSelectPopup : frmPopupBase
    {
        #region Property

        List<DownloadFileInfo> _infoList = new List<DownloadFileInfo>();

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

        public frmStdOperSelectPopup()
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
        private void frmTempSOIPopup_Load(object sender, EventArgs e)
        {
            // Set Grid by List<DownloadFileInfo>
            gridData.InitDataSource();
            SetGrid();

            // Caption 변경
            MPOF.ConvertCaption(this);

            // 활성화
            this.Activate();
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
            this.Close();
        }

        /// <summary>
        /// Ok Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                bool bFound = false;
                DataTable dt = gridData.GetDataSource();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToBoolean(dr[0]) == true)
                        {
                            bFound = true;
                            break;
                        }
                    }
                }
                if (bFound == false)
                {
                    // Please, select at least one item.
                    MPOF.ShowMsgBox(MPOF.GetMessage(71), MessageBoxButtons.OK, MSSAG_LEVEL.ERROR);
                    return;
                }

                // Return Data Bind
                if (ReturnDataBind() == false)
                {
                    return;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        #endregion

        #region Function

        /// <summary>
        /// Show Dialog 파라미터 받습니다.
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowDialog(ref List<DownloadFileInfo> infoList)
        {
            _infoList = infoList;

            return base.ShowDialog();
        }

        /// <summary>
        /// Grid를 설정합니다.
        /// </summary>
        private void SetGrid()
        {
            try
            {                
                DataTable dt = gridData.GetDataSource();

                DataRow dr = null;
                foreach (DownloadFileInfo info in _infoList)
                {
                    dr = dt.NewRow();

                    dr[0] = false;
                    dr[1] = info.optionSeq;
                    dr[2] = info.fileType;
                    dr[3] = info.fileId;

                    dt.Rows.Add(dr);
                }

                gridData.DataBind();
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Return Data를 재구성합니다.
        /// </summary>
        /// <returns></returns>
        private bool ReturnDataBind()
        {
            try
            {
                _infoList.Clear();
                DownloadFileInfo info = new DownloadFileInfo();
                DataTable dt = gridData.GetDataSource();

                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToBoolean(dr[0]) == true)
                    {
                        info.optionSeq = Convert.ToInt32(dr[1]);
                        info.fileType = Convert.ToString(dr[2]);
                        info.fileId = Convert.ToString(dr[3]);

                        _infoList.Add(info);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }
}
