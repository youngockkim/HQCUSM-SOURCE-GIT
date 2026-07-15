using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using SOI.OIFrx.SOIThemes;
using Infragistics.Win;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIRadioButton : UltraOptionSet
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

        public SOIRadioButton()
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
                // 공통 속성                
                this.GlyphInfo = UIElementDrawParams.StandardRadioButtonGlyphInfo;
                this.DrawFilter = noFocusRect;

                // 공통 색상
                this.Appearance.ForeColor = MOGV.gTheme.RadioButtonForeground;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.Appearance.BackColor = MOGV.gTheme.RadioButtonBackground;
                this.Appearance.BackColorDisabled = MOGV.gTheme.RadioButtonBackground;
                this.Appearance.ForeColorDisabled = MOGV.gTheme.ControlCommonDisabledForeground;
            }
        }

        #endregion
    }
}
