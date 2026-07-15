using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOI.OIFrx.SOIThemes;

namespace SOI.OIFrx.SOIBaseForm
{
    public partial class SOIDefaultBackgroundForm : Form
    {
        #region Property

        private Image _ImgMain;

        #endregion

        #region Constructor

        public SOIDefaultBackgroundForm()
        {
            InitializeComponent();
            this.BackColor = MOGV.gTheme.MainFormBackground;
        }

        #endregion

        #region Function

        public void SetOITheme()
        {
            // 이미지 변환
            //if (MPGV.gTheme is clsLightColors)
            //{
            //    this.BackgroundImage = Properties.Resources.Light_Main_Image;
            //}
            //else
            //{
            //    this.BackgroundImage = Properties.Resources.Dark_Main_Image;
            //}

            // 색상
            this.BackColor = MOGV.gTheme.MainFormBackground;

            // 이미지 로드
            try
            {
                _ImgMain = Image.FromFile(@"MainImage.png");
            }
            catch (Exception)
            {
                _ImgMain = Properties.Resources.MainImage;
            }

            if (_ImgMain != null)
            {
                this.BackgroundImage = _ImgMain;
            }
        }

        #endregion
    }
}
