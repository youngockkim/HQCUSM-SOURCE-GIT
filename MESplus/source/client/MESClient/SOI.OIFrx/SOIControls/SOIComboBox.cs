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
    public partial class SOIComboBox : UltraComboEditor
    {
        #region Property

        private bool bMouseOver = false;
        private bool bValidation = false;

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

        public SOIComboBox()
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

        private void SOIComboBox_MouseEnter(object sender, EventArgs e)
        {
            bMouseOver = true;
            SetOITheme();
        }

        private void SOIComboBox_MouseLeave(object sender, EventArgs e)
        {
            bMouseOver = false;
            SetOITheme();
        }

        private void SOIComboBox_ValueChanged(object sender, EventArgs e)
        {
            if (bValidation == true)
            {
                bValidation = false;
                MPOF.ShowMessage("", MSSAG_LEVEL.NONE, false);
                SetOITheme();
            }
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
                this.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
                this.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;

                // 공통 색상
                this.Appearance.BackColor = MOGV.gTheme.ComboBoxBackground;
                this.Appearance.ForeColor = MOGV.gTheme.ComboBoxForeground;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.ButtonAppearance.BackColor = MOGV.gTheme.ComboBoxBackground;
                this.ButtonAppearance.BorderColor = MOGV.gTheme.ComboBoxBackground;
                this.ButtonAppearance.ForeColor = MOGV.gTheme.ComboBoxArrow;
                this.ItemAppearance.BackColor = MOGV.gTheme.ComboBoxBackground;
                this.ItemAppearance.BorderColor = MOGV.gTheme.ComboBoxBorder;
                this.ItemAppearance.ForeColor = MOGV.gTheme.ComboBoxForeground;
                this.Appearance.ForeColorDisabled = MOGV.gTheme.ControlCommonDisabledForeground;
                this.Appearance.BackColorDisabled = MOGV.gTheme.ControlCommonDisabledBackground;
                this.Appearance.BackColorDisabled2 = MOGV.gTheme.ControlCommonDisabledBackground;
                this.ButtonAppearance.BackColorDisabled = MOGV.gTheme.ControlCommonDisabledBackground;

                if (base.Enabled == false)
                {
                    this.Appearance.BorderColor = MOGV.gTheme.ControlCommonDisabledBorder;
                }
                else
                {
                    if (bValidation == false)
                    {
                        // 마우스가 올라간 경우
                        if (bMouseOver)
                        {
                            this.Appearance.BorderColor = MOGV.gTheme.ComboBoxMouseOverBorder;
                        }
                        else
                        {
                            this.Appearance.BorderColor = MOGV.gTheme.ComboBoxBorder;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Validation을 설정합니다.
        /// </summary>
        public void SetValidation()
        {
            bValidation = true;
            this.Appearance.BorderColor = MOGV.gTheme.TextBoxValidationBorder;
        }

        #endregion
    }
}
