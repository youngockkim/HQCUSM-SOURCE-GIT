using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.Misc;
using SOI.OIFrx.SOIThemes;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIButton : UltraButton
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

        private SOIButtonStyle _useStyle = SOIButtonStyle.DefaultStyle;
        public SOIButtonStyle _UseStyle
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

        public SOIButton()
        {
            InitializeComponent();
        }

        public SOIButton(IContainer container)
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

                // 공통 색상
                this.Appearance.ForeColor = MPGV.gTheme.Foreground;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.Appearance.ForeColorDisabled = MPGV.gTheme.ControlCommonDisabledForeground;
                this.Appearance.BackColorDisabled = MPGV.gTheme.ControlCommonDisabledBackground;
                this.Appearance.BackColorDisabled2 = MPGV.gTheme.ControlCommonDisabledBackground;

                if (base.Enabled == false)
                {
                    this.Appearance.BorderColor = MPGV.gTheme.ControlCommonDisabledBorder;
                    this.Appearance.BorderColor = MPGV.gTheme.ControlCommonDisabledBorder;
                }
                else
                {
                    // Default Style인 경우
                    if (_UseStyle == SOIButtonStyle.DefaultStyle)
                    {
                        this.Appearance.BackColor = MPGV.gTheme.ButtonDefaultBackground;
                        this.Appearance.BackColor2 = MPGV.gTheme.ButtonDefaultBackground;
                        this.Appearance.BorderColor = MPGV.gTheme.ButtonDefaultBackground;
                        this.Appearance.BorderColor2 = MPGV.gTheme.ButtonDefaultBackground;
                        this.HotTrackAppearance.BackColor = MPGV.gTheme.ButtonDefaultHoverBackground;
                        this.HotTrackAppearance.BackColor2 = MPGV.gTheme.ButtonDefaultHoverBackground;
                        this.HotTrackAppearance.BorderColor = MPGV.gTheme.ButtonDefaultHoverBackground;
                        this.HotTrackAppearance.BorderColor2 = MPGV.gTheme.ButtonDefaultHoverBackground;
                        this.PressedAppearance.BackColor = MPGV.gTheme.ButtonDefaultPressBackground;
                        this.PressedAppearance.BackColor2 = MPGV.gTheme.ButtonDefaultPressBackground;
                        this.PressedAppearance.BorderColor = MPGV.gTheme.ButtonDefaultPressBackground;
                        this.PressedAppearance.BorderColor2 = MPGV.gTheme.ButtonDefaultPressBackground;
                    }
                    // Cancel Style인 경우
                    else if (_UseStyle == SOIButtonStyle.CancelStyle)
                    {
                        this.Appearance.BackColor = MPGV.gTheme.ButtonCancelBackground;
                        this.Appearance.BackColor2 = MPGV.gTheme.ButtonCancelBackground;
                        this.Appearance.BorderColor = MPGV.gTheme.ButtonCancelBackground;
                        this.Appearance.BorderColor2 = MPGV.gTheme.ButtonCancelBackground;
                        this.HotTrackAppearance.BackColor = MPGV.gTheme.ButtonCancelHoverBackground;
                        this.HotTrackAppearance.BackColor2 = MPGV.gTheme.ButtonCancelHoverBackground;
                        this.HotTrackAppearance.BorderColor = MPGV.gTheme.ButtonCancelHoverBackground;
                        this.HotTrackAppearance.BorderColor2 = MPGV.gTheme.ButtonCancelHoverBackground;
                        this.PressedAppearance.BackColor = MPGV.gTheme.ButtonCancelPressBackground;
                        this.PressedAppearance.BackColor2 = MPGV.gTheme.ButtonCancelPressBackground;
                        this.PressedAppearance.BorderColor = MPGV.gTheme.ButtonCancelPressBackground;
                        this.PressedAppearance.BorderColor2 = MPGV.gTheme.ButtonCancelPressBackground;
                    }
                }
            }
        }

        #endregion
    }
}
