using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.Misc;
using System.IO;
using SOI.OIFrx.SOIControls;
using System.Windows.Forms;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIButtonImportExcel : UltraButton
    {
        #region Property

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

        private SOIButtonImportExcelStyle _useStyle = SOIButtonImportExcelStyle.DefaultStyle;
        public SOIButtonImportExcelStyle _UseStyle
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

        #endregion

        #region Constructor

        public SOIButtonImportExcel()
        {
            InitializeComponent();
        }

        public SOIButtonImportExcel(IContainer container)
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
                this.Appearance.ForeColor = MPGV.gTheme.Foreground;
                this.Appearance.ForeColorDisabled = MPGV.gTheme.ControlCommonDisabledForeground;
                this.Appearance.BackColorDisabled = MPGV.gTheme.ControlCommonDisabledBackground;
                this.Appearance.BackColorDisabled2 = MPGV.gTheme.ControlCommonDisabledBackground;

                if (base.Enabled == false)
                {
                    this.Appearance.BorderColor = MPGV.gTheme.ControlCommonDisabledBorder;
                    this.Appearance.BorderColor2 = MPGV.gTheme.ControlCommonDisabledBorder;
                }
                else
                {
                    // Default Style인 경우
                    if (_UseStyle == SOIButtonImportExcelStyle.DefaultStyle)
                    {
                        this.Appearance.BackColor = MPGV.gTheme.ButtonImageDefaultBackground;
                        this.Appearance.BackColor2 = MPGV.gTheme.ButtonImageDefaultBackground;
                        this.Appearance.BorderColor = MPGV.gTheme.ButtonImageDefaultBackground;
                        this.Appearance.BorderColor2 = MPGV.gTheme.ButtonImageDefaultBackground;
                        this.HotTrackAppearance.BackColor = MPGV.gTheme.ButtonImageDefaultHoverBackground;
                        this.HotTrackAppearance.BackColor2 = MPGV.gTheme.ButtonImageDefaultHoverBackground;
                        this.HotTrackAppearance.BorderColor = MPGV.gTheme.ButtonImageDefaultHoverBackground;
                        this.HotTrackAppearance.BorderColor2 = MPGV.gTheme.ButtonImageDefaultHoverBackground;
                        this.HotTrackAppearance.ForeColor = MPGV.gTheme.Foreground;
                        this.PressedAppearance.BackColor = MPGV.gTheme.ButtonImageDefaultPressBackground;
                        this.PressedAppearance.BackColor2 = MPGV.gTheme.ButtonImageDefaultPressBackground;
                        this.PressedAppearance.BorderColor = MPGV.gTheme.ButtonImageDefaultPressBackground;
                        this.PressedAppearance.BorderColor2 = MPGV.gTheme.ButtonImageDefaultPressBackground;
                    }
                    // Transparent Style인 경우
                    else if (_UseStyle == SOIButtonImportExcelStyle.TransparentStyle)
                    {
                        this.Appearance.BackColor = MPGV.gTheme.ButtonImageTransparentBackground;
                        this.Appearance.BackColor2 = MPGV.gTheme.ButtonImageTransparentBackground;
                        this.Appearance.BorderColor = MPGV.gTheme.ButtonImageTransparentBackground;
                        this.Appearance.BorderColor2 = MPGV.gTheme.ButtonImageTransparentBackground;
                        this.HotTrackAppearance.BackColor = MPGV.gTheme.ButtonImageTransparentBackground;
                        this.HotTrackAppearance.BackColor2 = MPGV.gTheme.ButtonImageTransparentBackground;
                        this.HotTrackAppearance.BorderColor = MPGV.gTheme.ButtonImageTransparentBackground;
                        this.HotTrackAppearance.BorderColor2 = MPGV.gTheme.ButtonImageTransparentBackground;
                        this.HotTrackAppearance.ForeColor = MPGV.gTheme.ButtonImageTransparentHoverForeground;
                        this.PressedAppearance.BackColor = MPGV.gTheme.ButtonImageTransparentBackground;
                        this.PressedAppearance.BackColor2 = MPGV.gTheme.ButtonImageTransparentBackground;
                        this.PressedAppearance.BorderColor = MPGV.gTheme.ButtonImageTransparentBackground;
                        this.PressedAppearance.BorderColor2 = MPGV.gTheme.ButtonImageTransparentBackground;
                    }
                }
            }
        }

        /// <summary>
        /// Import를 실행합니다.
        /// </summary>
        /// <param name="spread"></param>
        public bool RunImport(SOISpread spread)
        {
            return RunImport(string.Empty, spread);
        }

        /// <summary>
        /// Import를 실행합니다.
        /// </summary>
        public bool RunImport(string sExcelFilePath, SOISpread spread)
        {
            try
            {
                // 설정하지 않은 경우
                if (string.IsNullOrEmpty(sExcelFilePath) == true)
                {
                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        spread.OpenExcel(openFileDialog1.FileName);
                    }
                }
                // 설정한 경우
                else
                {
                    spread.OpenExcel(sExcelFilePath);
                }

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage(ex.Message, CliFrx.MSG_LEVEL.ERROR, false);
                return false;
            }
        }

        #endregion
    }
}
