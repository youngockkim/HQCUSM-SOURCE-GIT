using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinEditors;
using SOI.OIFrx.SOIPopup;
using System.Drawing;
using System.Windows.Forms;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOITextBoxNumber : UltraNumericEditor
    {
        #region Property

        private bool bFocused = false;
        private bool bMouseOver = false;
        private bool bValidation = false;

        private frmKeyPad keyPad;

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

        public new bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;
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

        private int _defaultIntegerValue = 0;
        public int DefaultIntegerValue
        {
            get 
            {
                return _defaultIntegerValue;
            }
            set
            {
                _defaultIntegerValue = value;
                if (this.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Integer)
                {
                    this.Value = _defaultIntegerValue;
                }
            }
        }

        private double _defaultDoubleValue = 0;
        public double DefaultDoubleValue
        {
            get
            {
                return _defaultDoubleValue;
            }
            set
            {
                _defaultDoubleValue = value;
                if (this.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Double)
                {
                    this.Value = _defaultDoubleValue;
                }
            }
        }

        private bool _showKeyPad = true;
        public bool ShowKeyPadControl
        {
            get { return _showKeyPad; }
            set { _showKeyPad = value; }
        }

        public event EventHandler AfterKeyPadEnterClick;
        private void OnAfterKeyPadEnterClick(object sender, EventArgs e)
        {
            if (AfterKeyPadEnterClick != null)
            {
                AfterKeyPadEnterClick(this, e);
            }
        }

        #endregion

        #region Contructor

        public SOITextBoxNumber()
        {
            InitializeComponent();
        }

        public SOITextBoxNumber(IContainer container)
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

        private void SOITextBoxNumber_Enter(object sender, EventArgs e)
        {
            bFocused = true;
            SetOITheme();
            ShowKeyPad();
        }

        private void SOITextBoxNumber_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ShowKeyPad();
        }

        private void SOITextBoxNumber_Leave(object sender, EventArgs e)
        {
            bFocused = false;
            SetOITheme();
        }

        private void SOITextBoxNumber_MouseEnter(object sender, EventArgs e)
        {
            bMouseOver = true;
            SetOITheme();
        }

        private void SOITextBoxNumber_MouseLeave(object sender, EventArgs e)
        {
            bMouseOver = false;
            SetOITheme();
        }

        private void SOITextBoxNumber_ValueChanged(object sender, EventArgs e)
        {
            if (bValidation == true)
            {
                bValidation = false;
                MPCF.ShowMessage("", CliFrx.MSG_LEVEL.NONE, false);
                SetOITheme();
            }

            if (this.Value == null
                || string.IsNullOrEmpty(this.Value.ToString()) == true)
            {
                if (this.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Integer)
                {
                    this.Value = this.DefaultIntegerValue;
                }
                else if (this.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Double)
                {
                    this.Value = this.DefaultDoubleValue;
                }
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
                this.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // 공통 색상
                this.Appearance.ForeColor = MPGV.gTheme.TextBoxForeground;
                this.Appearance.ForeColorDisabled = MPGV.gTheme.ControlCommonDisabledForeground;
                this.Appearance.BackColorDisabled = MPGV.gTheme.ControlCommonDisabledBackground;

                // Enable 상태가 아닌 경우
                if (base.Enabled == false)
                {
                    this.Appearance.BorderColor = MPGV.gTheme.ControlCommonDisabledBorder;
                }
                // 읽기 전용인 경우
                else if (base.ReadOnly == true)
                {
                    this.Appearance.BackColor = MPGV.gTheme.TextBoxReadOnlyBackground;
                    this.Appearance.ForeColor = MPGV.gTheme.TextBoxForeground;
                    this.Appearance.BorderColor = MPGV.gTheme.TextBoxBorder;
                }
                else
                {
                    // Focus 상태인 경우
                    if (bFocused == true)
                    {
                        this.Appearance.BackColor = MPGV.gTheme.TextBoxFocusedBackground;
                        this.Appearance.ForeColor = MPGV.gTheme.TextBoxFocusedForeground;
                        if (bValidation == false)
                        {
                            this.Appearance.BorderColor = MPGV.gTheme.TextBoxBorder;
                        }
                    }
                    // Mouse Over 상태인 경우
                    else if (bMouseOver == true)
                    {
                        this.Appearance.BackColor = MPGV.gTheme.TextBoxBackground;
                        this.Appearance.ForeColor = MPGV.gTheme.TextBoxForeground;
                        if (bValidation == false)
                        {
                            this.Appearance.BorderColor = MPGV.gTheme.TextBoxMouseOverBorder;
                        }
                    }
                    // 일반상태인 경우
                    else
                    {
                        this.Appearance.BackColor = MPGV.gTheme.TextBoxBackground;
                        this.Appearance.ForeColor = MPGV.gTheme.TextBoxForeground;
                        if (bValidation == false)
                        {
                            this.Appearance.BorderColor = MPGV.gTheme.TextBoxBorder;
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

        private void ShowKeyPad()
        {
            try
            {
                if (this.ShowKeyPadControl == true)
                {
                    if (keyPad == null
                        || keyPad.IsDisposed == true)
                    {
                        keyPad = new frmKeyPad();
                        keyPad.Owner = MPGV.gfrmMDI;

                        Point controlLocation = this.PointToScreen(new Point(0, 0));

                        keyPad.Left = controlLocation.X + this.Width - keyPad.Width;
                        keyPad.Top = controlLocation.Y + this.Height + 3;

                        // Mouse 클릭 위치를 확인
                        Rectangle rect = Screen.GetWorkingArea(Control.MousePosition);

                        // 우측 하단에 표시되는 경우 컨트롤 상단에 표시.
                        // 우측화면 넘어 컨트롤 자체가 보이지 않는 경우는 없다고 가정.
                        if (controlLocation.Y + keyPad.Height > rect.Top + rect.Height)
                        {
                            keyPad.Left = controlLocation.X + this.Width - keyPad.Width;
                            keyPad.Top = controlLocation.Y - keyPad.Height - 3;
                        }

                        keyPad.Tag = this;
                        keyPad.ShowDialog();

                        this.Update();

                        if (keyPad.bEntered == true)
                        {
                            OnAfterKeyPadEnterClick(this, new EventArgs());
                        }
                    }
                }
            }
            finally
            {
                if (keyPad != null)
                {
                    keyPad.Dispose();
                }
            }
        }

        public void AddValue(object oValue)
        {
            // 현재 Value가 null인 경우
            if (this.Value == null)
            {
                this.Value = oValue;
            }
            else
            {
                // 0으로 시작하는 경우 0 제거
                if (this.Value.ToString().StartsWith("0") == true)
                {
                    this.Value = (this.Value.ToString().Remove(0) + oValue.ToString());
                }
                // 0으로 시작하지 않는 경우 추가
                else
                {
                    try
                    {
                        this.Value = (this.Value.ToString() + oValue.ToString());
                    }
                    catch (OverflowException)
                    {
                        return;
                    }
                }
            }
        }

        public void RemoveLastValue()
        {
            if (this.Value != null)
            {
                if (this.Value.ToString().Length == 1)
                {
                    if (this.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Integer)
                    {
                        if (Convert.ToInt32(this.Value) != 0)
                        {
                            this.Value = 0;
                        }
                    }
                    else if (this.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Double)
                    {
                        if (Convert.ToDouble(this.Value) != 0)
                        {
                            this.Value = 0;
                        }
                    }
                }
                else
                {
                    this.Value = this.Value.ToString().Remove(this.Value.ToString().Length - 1);
                }
            }
        }

        #endregion
    }
}
