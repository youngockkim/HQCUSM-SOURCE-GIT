using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx.SOIPopup
{
    public partial class frmStandardOperationView : frmModalessPopupBase
    {
        #region Property

        /// <summary>
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

        public frmStandardOperationView()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Standard Operation View Popup 로드 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmStandardOperationView_Load(object sender, EventArgs e)
        {
            // Check Image Is Null
            if (CheckImageSourceExist() == true)
            {
                SetFormSize();
            }
            else
            {
                SetDefaultLocation();
            }

            // Check PLM Url
            if (string.IsNullOrEmpty(MPGC.PLM_VIEWER_URL) == true)
            {
                btnPLMViewer.Visible = false;
            }
            else
            {
                btnPLMViewer.Visible = true;
            }

            // Caption 변경
            MPCF.ConvertCaption(this);

            this.Activate();
        }

        /// <summary>
        /// PLM Viewer를 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPLMViewer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(MPGC.PLM_VIEWER_URL);
        }

        /// <summary>
        /// Close 버튼 클릭 시 화면을 닫습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Function

        /// <summary>
        /// String Root 경로에 있는 이미지 파일을 엽니다.
        /// Root가 비어있는 경우 No Image 텍스트를 보여줍니다.
        /// </summary>
        /// <param name="sRoot"></param>
        /// <returns></returns>
        public bool SetImageSource(Image img)
        {
            pbImage.Image = img;
            return true;
        }

        /// <summary>
        /// Image Source가 있는지 확인합니다.
        /// </summary>
        /// <returns></returns>
        private bool CheckImageSourceExist()
        {
            if (pbImage.Image != null)
            {
                return true;
            }
            else
            {
                lblNoImage.Visible = true;
                pbImage.Visible = false;

                return false;
            }
        }

        /// <summary>
        /// Image Picture Box의 크기를 Fit 합니다.
        /// pnlImageBack과 동일한 크기로 설정합니다.
        /// </summary>
        private void ImageToFit()
        {
            if (pbImage.Image != null)
            {
                pbImage.Left = 0;
                pbImage.Top = 0;
                pbImage.Width = pnlImageBack.Width;
                pbImage.Height = pnlImageBack.Height;
            }
        }

        /// <summary>
        /// Image Picture Box의 크기를 이미지 크기로 설정합니다.
        /// </summary>
        private void ImageToReset()
        {
            if (pbImage.Image != null)
            {
                pbImage.Left = 0;
                pbImage.Top = 0;
                pbImage.Width = pbImage.Image.Size.Width;
                pbImage.Height = pbImage.Image.Size.Height;
            }
        }

        /// <summary>
        /// 지정된 이미지의 크기로 Form Size를 설정합니다.
        /// MDI Main Form의 중앙에서 화면이 표시될 수 있도록 location을 수정합니다.
        /// </summary>
        private void SetFormSize()
        {
            // 이미지의 사이즈를 최대화 
            ImageToReset();

            // 이미지 사이즈에 따라 Form의 크기 설정
            this.Width = pbImage.Image.Size.Width + (this.Width - pnlImageBack.Width);
            if (this.Width > MPGV.gfrmMDI.Width)
            {
                this.Width = MPGV.gfrmMDI.Width;
            }
            this.Height = pbImage.Image.Size.Height + (this.Height - pnlImageBack.Height);
            if (this.Height > MPGV.gfrmMDI.Height)
            {
                this.Height = MPGV.gfrmMDI.Height;
            }

            SetDefaultLocation();
        }

        /// <summary>
        /// Default Location을 설정합니다.
        /// 메인 화면의 중앙에 위치합니다.
        /// </summary>
        private void SetDefaultLocation()
        {
            this.Left = MPGV.gfrmMDI.Left + (MPGV.gfrmMDI.Width / 2) - (this.Width / 2);
            this.Top = MPGV.gfrmMDI.Top + (MPGV.gfrmMDI.Height / 2) - (this.Height / 2);
        }

        #endregion
    }
}
