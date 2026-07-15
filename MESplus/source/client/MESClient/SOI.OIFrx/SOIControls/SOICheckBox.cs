using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinEditors;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOICheckBox : UltraCheckEditor
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

        public SOICheckBox()
        {
            InitializeComponent();
        }

        public SOICheckBox(IContainer container)
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
                // 속성
                this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;

                // 공통 색상
                this.Appearance.ForeColor = MOGV.gTheme.CheckBoxForeground;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.BackColor = MOGV.gTheme.CheckBoxBackground;
                this.Appearance.BackColorDisabled = MOGV.gTheme.CheckBoxBackground;
                this.Appearance.ForeColorDisabled = MOGV.gTheme.ControlCommonDisabledForeground;
            }
        }

        #endregion
    }
}
