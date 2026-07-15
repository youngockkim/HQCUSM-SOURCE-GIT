using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using SOI.OIFrx.SOIThemes;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIPasswordBox : UltraTextEditor
    {
         #region Property

        private bool bFocused = false;
        private bool bMouseOver = false;

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

        public SOIPasswordBox()
        {
            InitializeComponent();

            this.PasswordChar = (char)0x25CF;
        }

        public SOIPasswordBox(IContainer container)
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

        private void SOIPasswordBox_Enter(object sender, EventArgs e)
        {
            bFocused = true;
            SetOITheme();
        }

        private void SOIPasswordBox_Leave(object sender, EventArgs e)
        {
            bFocused = false;
            SetOITheme();
        }

        private void SOIPasswordBox_MouseEnter(object sender, EventArgs e)
        {
            bMouseOver = true;
            SetOITheme();
        }

        private void SOIPasswordBox_MouseLeave(object sender, EventArgs e)
        {
            bMouseOver = false;
            SetOITheme();
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
                this.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
                this.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // 공통 색상
                this.Appearance.ForeColor = MOGV.gTheme.TextBoxForeground;
                this.Appearance.ForeColorDisabled = MOGV.gTheme.ControlCommonDisabledForeground;
                this.Appearance.BackColorDisabled = MOGV.gTheme.ControlCommonDisabledBackground;                

                // Enable 상태가 아닌 경우
                if (base.Enabled == false)
                {
                    this.Appearance.BorderColor = MOGV.gTheme.ControlCommonDisabledBorder;
                }
                else
                {
                    // Focus인 경우
                    if (bFocused == true)
                    {
                        this.Appearance.BackColor = MOGV.gTheme.TextBoxFocusedBackground;
                        this.Appearance.ForeColor = MOGV.gTheme.TextBoxFocusedForeground;
                        this.Appearance.BorderColor = MOGV.gTheme.TextBoxBorder;
                    }
                    // Mouse Over인 경우
                    else if (bMouseOver == true)
                    {
                        this.Appearance.BackColor = MOGV.gTheme.TextBoxBackground;
                        this.Appearance.ForeColor = MOGV.gTheme.TextBoxForeground;
                        this.Appearance.BorderColor = MOGV.gTheme.TextBoxMouseOverBorder;
                    }
                    // 기타의 경우
                    else
                    {
                        this.Appearance.BackColor = MOGV.gTheme.TextBoxBackground;
                        this.Appearance.ForeColor = MOGV.gTheme.TextBoxForeground;
                        this.Appearance.BorderColor = MOGV.gTheme.TextBoxBorder;
                    }
                }
            }
        }

        #endregion
    }
}
