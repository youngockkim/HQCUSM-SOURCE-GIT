using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.Misc;
using SOI.OIFrx.SOIPopup;
using System.Drawing;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIButtonImageViewer : UltraButton
    {
        #region Property

        private frmImageViewerPopup frmImage;

        private bool _useOITheme = true; // 최초 컨트롤 Add시 Default로 테마 적용
        public bool _UseOITheme
        {
            get
            {
                return _useOITheme;
            }
            set
            {
                _useOITheme = value;
                SetOITheme();
            }
        }

        private SOIButtonImageViewerStyle _useStyle = SOIButtonImageViewerStyle.DefaultStyle;
        public SOIButtonImageViewerStyle _UseStyle
        {
            get
            {
                return _useStyle;
            }
            set
            {
                _useStyle = value;
                SetOITheme();
            }
        }

        public new bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
                SetOITheme();
            }
        }

        private Image targetImage;
        public Image TargetImage
        {
            get
            {
                return targetImage;
            }
            set
            {
                targetImage = value;
            }
        }

        #endregion

        #region Constructor

        public SOIButtonImageViewer()
        {
            InitializeComponent();
        }

        public SOIButtonImageViewer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Event Handler

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            // 디자인 모드에서만 적용
            if (DesignMode == true)
            {
                SetOITheme();
            }

            base.OnPaint(pe);
        }

        protected override void OnClick(EventArgs e)
        {
            RunImageViewer();

            base.OnClick(e);
        }

        #endregion

        #region Function

        /// <summary>
        /// 테마를 적용합니다.
        /// 화면 로드할 때, Design Mode에서 OnPaint할 때, Use OI Theme 속성 변경 시 실행됩니다.
        /// </summary>
        public void SetOITheme()
        {
            if (_UseOITheme == true)
            {
                // 공통 속성
                this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // 공통 색상
                this.Appearance.ForeColor = MOGV.gTheme.Foreground;
                this.Appearance.ForeColorDisabled = MOGV.gTheme.ControlCommonDisabledForeground;
                this.Appearance.BackColorDisabled = MOGV.gTheme.ControlCommonDisabledBackground;
                this.Appearance.BackColorDisabled2 = MOGV.gTheme.ControlCommonDisabledBackground;

                if (base.Enabled == false)
                {
                    this.Appearance.BorderColor = MOGV.gTheme.ControlCommonDisabledBorder;
                    this.Appearance.BorderColor2 = MOGV.gTheme.ControlCommonDisabledBorder;
                }
                else
                {
                    // Default Style인 경우
                    if (_UseStyle == SOIButtonImageViewerStyle.DefaultStyle)
                    {
                        this.Appearance.BackColor = MOGV.gTheme.ButtonImageDefaultBackground;
                        this.Appearance.BackColor2 = MOGV.gTheme.ButtonImageDefaultBackground;
                        this.Appearance.BorderColor = MOGV.gTheme.ButtonImageDefaultBackground;
                        this.Appearance.BorderColor2 = MOGV.gTheme.ButtonImageDefaultBackground;
                        this.HotTrackAppearance.BackColor = MOGV.gTheme.ButtonImageDefaultHoverBackground;
                        this.HotTrackAppearance.BackColor2 = MOGV.gTheme.ButtonImageDefaultHoverBackground;
                        this.HotTrackAppearance.BorderColor = MOGV.gTheme.ButtonImageDefaultHoverBackground;
                        this.HotTrackAppearance.BorderColor2 = MOGV.gTheme.ButtonImageDefaultHoverBackground;
                        this.HotTrackAppearance.ForeColor = MOGV.gTheme.Foreground;
                        this.PressedAppearance.BackColor = MOGV.gTheme.ButtonImageDefaultPressBackground;
                        this.PressedAppearance.BackColor2 = MOGV.gTheme.ButtonImageDefaultPressBackground;
                        this.PressedAppearance.BorderColor = MOGV.gTheme.ButtonImageDefaultPressBackground;
                        this.PressedAppearance.BorderColor2 = MOGV.gTheme.ButtonImageDefaultPressBackground;
                    }
                    // Transparent Style인 경우
                    else if (_UseStyle == SOIButtonImageViewerStyle.TransparentStyle)
                    {
                        this.Appearance.BackColor = MOGV.gTheme.ButtonImageTransparentBackground;
                        this.Appearance.BackColor2 = MOGV.gTheme.ButtonImageTransparentBackground;
                        this.Appearance.BorderColor = MOGV.gTheme.ButtonImageTransparentBackground;
                        this.Appearance.BorderColor2 = MOGV.gTheme.ButtonImageTransparentBackground;
                        this.HotTrackAppearance.BackColor = MOGV.gTheme.ButtonImageTransparentBackground;
                        this.HotTrackAppearance.BackColor2 = MOGV.gTheme.ButtonImageTransparentBackground;
                        this.HotTrackAppearance.BorderColor = MOGV.gTheme.ButtonImageTransparentBackground;
                        this.HotTrackAppearance.BorderColor2 = MOGV.gTheme.ButtonImageTransparentBackground;
                        this.HotTrackAppearance.ForeColor = MOGV.gTheme.ButtonImageTransparentHoverForeground;
                        this.PressedAppearance.BackColor = MOGV.gTheme.ButtonImageTransparentBackground;
                        this.PressedAppearance.BackColor2 = MOGV.gTheme.ButtonImageTransparentBackground;
                        this.PressedAppearance.BorderColor = MOGV.gTheme.ButtonImageTransparentBackground;
                        this.PressedAppearance.BorderColor2 = MOGV.gTheme.ButtonImageTransparentBackground;
                    }
                }
            }
        }

        /// <summary>
        /// Image Viewere를 실행합니다.
        /// </summary>
        public void RunImageViewer()
        {
            try
            {
                frmImage = new frmImageViewerPopup();

                if (TargetImage != null)
                {
                    frmImage.SetImageSource(TargetImage);
                }

                frmImage.ShowDialog();
            }
            catch (Exception ex)
            {
                MPOF.ShowMessage(ex.Message, MSSAG_LEVEL.ERROR, false);
            }
        }

        /// <summary>
        /// Image Viewere를 실행합니다.
        /// </summary>
        public bool RunImageViewer(Image imgSource)
        {
            try
            {
                TargetImage = imgSource;

                frmImage = new frmImageViewerPopup();

                frmImage.SetImageSource(TargetImage);

                frmImage.ShowDialog();

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
