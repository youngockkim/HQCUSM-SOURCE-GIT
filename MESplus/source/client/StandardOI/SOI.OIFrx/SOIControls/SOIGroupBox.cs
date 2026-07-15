using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.Misc;
using SOI.OIFrx.SOIThemes;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIGroupBox : UltraGroupBox
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

        private SOIGroupBoxStyle _useStyle = SOIGroupBoxStyle.DefaultStyle;
        public SOIGroupBoxStyle _UseStyle
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

        public SOIGroupBox()
        {
            InitializeComponent();
        }

        public SOIGroupBox(IContainer container)
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
                this.ViewStyle = GroupBoxViewStyle.VisualStudio2005;
                this.BorderStyle = GroupBoxBorderStyle.None;
                this.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // 공통 색상
                this.Appearance.BackColor = MPGV.gTheme.GroupBoxBorder;

                if (_UseStyle == SOIGroupBoxStyle.DefaultStyle)
                {                    
                    // 속성
                    this.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    this.CaptionAlignment = GroupBoxCaptionAlignment.Default;

                    // 색상
                    this.ContentAreaAppearance.BackColor = MPGV.gTheme.GroupBoxBackground;
                    this.ContentAreaAppearance.BackColor2 = MPGV.gTheme.GroupBoxBackground;                    
                    this.Appearance.BorderColor = MPGV.gTheme.GroupBoxHeaderBackground;
                    this.HeaderAppearance.BackColor = MPGV.gTheme.GroupBoxHeaderBackground;
                    this.HeaderAppearance.BackColor2 = MPGV.gTheme.GroupBoxHeaderBackground;
                    this.HeaderAppearance.ForeColor = MPGV.gTheme.GroupBoxHeaderForeground;
                }
                else if (_UseStyle == SOIGroupBoxStyle.NumberStyle)
                {
                    // 속성
                    this.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    this.CaptionAlignment = GroupBoxCaptionAlignment.Center;

                    // 색상
                    this.ContentAreaAppearance.BackColor = MPGV.gTheme.GroupBoxNumberStyleBackground;
                    this.ContentAreaAppearance.BackColor2 = MPGV.gTheme.GroupBoxNumberStyleBackground;
                    this.Appearance.BorderColor = MPGV.gTheme.GroupBoxNumberStyleHeaderBackground;
                    this.HeaderAppearance.BackColor = MPGV.gTheme.GroupBoxNumberStyleHeaderBackground;
                    this.HeaderAppearance.BackColor2 = MPGV.gTheme.GroupBoxNumberStyleHeaderBackground;
                    this.HeaderAppearance.ForeColor = MPGV.gTheme.GroupBoxNumberStyleHeaderForeground;
                }
            }
        }

        #endregion
    }
}
