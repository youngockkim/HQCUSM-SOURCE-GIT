using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinTabControl;
using SOI.OIFrx.SOIThemes;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOITabControl : UltraTabControl
    {
        #region Property

        private NoFocusRect noFocusRect = new NoFocusRect();        

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

        private bool _useConvertLanguage = true; // Convert를 강제로 하지 않는 경우 사용
        public bool _UseConvertLanguage
        {
            get
            {
                return _useConvertLanguage;
            }
            set
            {
                _useConvertLanguage = value;
            }
        }

        private SOITabControlStyle _useStyle = SOITabControlStyle.DefaultStyle;
        public SOITabControlStyle _UseStyle
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

        #endregion

        #region Constructor

        public SOITabControl()
        {
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
                // 속성
                this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                this.DrawFilter = noFocusRect;

                // Default Style인 경우
                if (_UseStyle == SOITabControlStyle.DefaultStyle)
                {
                    // 색상
                    this.ActiveTabAppearance.BackColor = MPGV.gTheme.TabControlActiveTabBackground;
                    this.ActiveTabAppearance.BackColor2 = MPGV.gTheme.TabControlActiveTabBackground;
                    this.ActiveTabAppearance.BorderColor = MPGV.gTheme.TabControlActiveTabBackground;
                    //this.ActiveTabAppearance.BackColor = MPGV.gTheme.TabControlBackground;
                    //this.ActiveTabAppearance.BackColor2 = MPGV.gTheme.TabControlBackground;
                    //this.ActiveTabAppearance.BorderColor = MPGV.gTheme.TabControlBackground;
                    this.ActiveTabAppearance.ForeColor = MPGV.gTheme.TabControlActiveTabForeground;                    
                    //this.ActiveTabAppearance.ForeColor = MPGV.gTheme.TabControlForeground;
                    this.Appearance.BackColor = MPGV.gTheme.TabControlBackground;
                    this.Appearance.BackColor2 = MPGV.gTheme.TabControlBackground;
                    this.Appearance.BorderColor = MPGV.gTheme.TabControlBackground;
                    //this.Appearance.BackColor = MPGV.gTheme.TabControlActiveTabBackground;
                    //this.Appearance.BackColor2 = MPGV.gTheme.TabControlActiveTabBackground;
                    //this.Appearance.BorderColor = MPGV.gTheme.TabControlActiveTabBackground;
                    this.Appearance.ForeColor = MPGV.gTheme.TabControlForeground;
                    //this.Appearance.ForeColor = MPGV.gTheme.TabControlActiveTabForeground;
                    this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    this.ClientAreaAppearance.BackColor = MPGV.gTheme.TabControlActiveTabBackground;
                    this.ClientAreaAppearance.BackColor2 = MPGV.gTheme.TabControlActiveTabBackground;
                    this.TabHeaderAreaAppearance.BackColor = MPGV.gTheme.TabControlActiveTabBackground;                    
                }
                // Menu Style인 경우
                else if (_UseStyle == SOITabControlStyle.MenuStyle)
                {
                    // 색상
                    this.ActiveTabAppearance.BackColor = MPGV.gTheme.TabControlMenuActiveTabBackground;
                    this.ActiveTabAppearance.BackColor2 = MPGV.gTheme.TabControlMenuActiveTabBackground;
                    this.ActiveTabAppearance.BorderColor = MPGV.gTheme.TabControlMenuActiveTabBackground;
                    this.ActiveTabAppearance.ForeColor = MPGV.gTheme.TabControlMenuActiveTabForeground;
                    this.Appearance.BackColor = MPGV.gTheme.TabControlMenuBackground;
                    this.Appearance.BackColor2 = MPGV.gTheme.TabControlMenuBackground;
                    this.Appearance.BorderColor = MPGV.gTheme.TabControlMenuBackground;
                    this.Appearance.ForeColor = MPGV.gTheme.TabControlMenuForeground;
                    this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    this.ClientAreaAppearance.BackColor = MPGV.gTheme.TabControlMenuActiveTabBackground;
                    this.ClientAreaAppearance.BackColor2 = MPGV.gTheme.TabControlMenuActiveTabBackground;
                    this.TabHeaderAreaAppearance.BackColor = MPGV.gTheme.TabControlMenuActiveTabBackground;
                }
            }
        }

        #endregion
    }
}
