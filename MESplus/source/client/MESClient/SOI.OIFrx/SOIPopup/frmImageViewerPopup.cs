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
    public partial class frmImageViewerPopup : frmPopupBase
    {
        #region Property

        private bool bDragging = false;
        private int iDragX;
        private int iDragY;
        private int iZoomPixel = 50;
        private int iZoomMaxPixel = 1200;
        private int iZoomMinPixel = 100;

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

        public frmImageViewerPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handler

        /// <summary>
        /// Image Viewer Popup 화면 로드 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmImageViewerPopup_Load(object sender, EventArgs e)
        {
            // Check Image Is Null
            if (CheckImageSourceExist() == true)
            {
                //ImageToReset();
                ImageToFit();
            }

            // Caption 변경
            MPOF.ConvertCaption(this);

            // 활성화
            this.Activate();
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
                btnReset.Enabled = false;
                btnFit.Enabled = false;
                btnZoomOut.Enabled = false;
                btnZoomIn.Enabled = false;

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
        /// Image Picture Box의 크기를 Fit 합니다.
        /// pnlImageBack과 동일한 크기로 설정합니다.
        /// </summary>
        private void btnFit_Click(object sender, EventArgs e)
        {
            ImageToFit();
        }

        /// <summary>
        /// Image Picture Box의 크기를 Zoom In 합니다.
        /// 50pixel 단위로 10회까지 확장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (pbImage.Width < iZoomMaxPixel
                && pbImage.Height < iZoomMaxPixel)
            {
                pbImage.Width = pbImage.Width + iZoomPixel;
                pbImage.Height = pbImage.Height + iZoomPixel;
            }
        }

        /// <summary>
        /// Image Picture Box의 크기를 Zoom Out 합니다.
        /// 50pixel 단위로 Fit 크기까지 줄입니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (pbImage.Width > iZoomMinPixel
                && pbImage.Height > iZoomMinPixel)
            {
                pbImage.Width = pbImage.Width - iZoomPixel;
                pbImage.Height = pbImage.Height - iZoomPixel;
            }
        }

        /// <summary>
        /// Image Size를 기준으로 초기화 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ImageToReset();
        }

        private void pbImage_MouseDown(object sender, MouseEventArgs e)
        {
            //if (pnlImageBack.VerticalScrollProperties.Visible == true
            //    || pnlImageBack.HorizontalScrollProperties.Visible == true)
            //{
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    this.Cursor = Cursors.Hand;
                    bDragging = true;
                    iDragX = e.X;
                    iDragY = e.Y;
                }
            //}
        }

        private void pbImage_MouseUp(object sender, MouseEventArgs e)
        {
            bDragging = false;
            this.Cursor = Cursors.Default;
        }

        private void pbImage_MouseMove(object sender, MouseEventArgs e)
        {
            Control con = sender as Control;
            if (bDragging == true && con != null)
            {
                //if(pnlImageBack.HorizontalScrollProperties.Value + iDragX < pnlImageBack.HorizontalScrollProperties.Maximum
                //    && pnlImageBack.HorizontalScrollProperties.Value + iDragX > pnlImageBack.HorizontalScrollProperties.Minimum)
                //{
                //    pnlImageBack.HorizontalScrollProperties.Value = pnlImageBack.HorizontalScrollProperties.Value+iDragX;
                //}

                //if(pnlImageBack.VerticalScrollProperties.Value + iDragY < pnlImageBack.VerticalScrollProperties.Maximum
                //    && pnlImageBack.VerticalScrollProperties.Value + iDragY > pnlImageBack.VerticalScrollProperties.Minimum)
                //{
                //    pnlImageBack.VerticalScrollProperties.Value = pnlImageBack.VerticalScrollProperties.Value + iDragY;
                //}

                con.Top = e.Y + con.Top - iDragY;
                con.Left = e.X + con.Left - iDragX;
            }
        }

        #endregion
    }
}
