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
                MPCF.ShowMessage("", CliFrx.MSG_LEVEL.NONE, false);
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
                //this.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
                this.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;

                // 공통 색상
                this.Appearance.BackColor = MPGV.gTheme.ComboBoxBackground;
                this.Appearance.ForeColor = MPGV.gTheme.ComboBoxForeground;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.ButtonAppearance.BackColor = MPGV.gTheme.ComboBoxBackground;
                this.ButtonAppearance.BorderColor = MPGV.gTheme.ComboBoxBackground;
                this.ButtonAppearance.ForeColor = MPGV.gTheme.ComboBoxArrow;
                this.ItemAppearance.BackColor = MPGV.gTheme.ComboBoxBackground;
                this.ItemAppearance.BorderColor = MPGV.gTheme.ComboBoxBorder;
                this.ItemAppearance.ForeColor = MPGV.gTheme.ComboBoxForeground;
                this.Appearance.ForeColorDisabled = MPGV.gTheme.ControlCommonDisabledForeground;
                this.Appearance.BackColorDisabled = MPGV.gTheme.ControlCommonDisabledBackground;
                this.Appearance.BackColorDisabled2 = MPGV.gTheme.ControlCommonDisabledBackground;
                this.ButtonAppearance.BackColorDisabled = MPGV.gTheme.ControlCommonDisabledBackground;

                if (base.Enabled == false)
                {
                    this.Appearance.BorderColor = MPGV.gTheme.ControlCommonDisabledBorder;
                }
                else
                {
                    if (bValidation == false)
                    {
                        // 마우스가 올라간 경우
                        if (bMouseOver)
                        {
                            this.Appearance.BorderColor = MPGV.gTheme.ComboBoxMouseOverBorder;
                        }
                        else
                        {
                            this.Appearance.BorderColor = MPGV.gTheme.ComboBoxBorder;
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
            this.Appearance.BorderColor = MPGV.gTheme.TextBoxValidationBorder;
        }

        #endregion

        public string Show(SOIComboBox soiSilType, string p, string p_2, string p_3, Miracom.TRSCore.TRSNode in_node, string p_4, string[] display, string[] header, string p_5)
        {
            throw new NotImplementedException();
        }
    }
}
