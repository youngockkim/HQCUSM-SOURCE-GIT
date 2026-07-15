using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOICheckBoxOnOff : UserControl
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

        private string onStateKey;
        public string OnStateKey
        {
            get { return onStateKey; }
            set { onStateKey = value; }
        }

        private string onStateText;
        public string OnStateText
        {
            get { return onStateText; }
            set 
            { 
                onStateText = value;
                this.lblOnText.Text = onStateText;
            }
        }

        private string offStateKey;
        public string OffStateKey
        {
            get { return offStateKey; }
            set { offStateKey = value; }
        }

        private string offStateText;
        public string OffStateText
        {
            get { return offStateText; }
            set 
            { 
                offStateText = value;
                this.lblOffText.Text = offStateText;
            }
        }

        private SOICheckBoxOnOffState onOffState = SOICheckBoxOnOffState.OnState;
        public SOICheckBoxOnOffState OnOffState
        {
            get { return onOffState; }
            set
            {
                onOffState = value;
                ChangeState(onOffState);
            }
        }

        [Browsable(false)]
        public string SelectedKey
        {
            get 
            { 
                return GetSelectedKey(); 
            }
        }

        [Browsable(false)]
        public string SelectedText
        {
            get
            {
                return GetSelectedText();
            }
        }

        [Browsable(true)]
        public event EventHandler OnOffStateChanged;
        private void OnOnOffStateChanged(object sender, EventArgs e)
        {
            if (OnOffStateChanged != null)
            {
                OnOffStateChanged(this, e);
            }
        }
        
        #endregion

        #region Constructor

        public SOICheckBoxOnOff()
        {
            InitializeComponent();
        }

        public SOICheckBoxOnOff(IContainer container)
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

        private void lblOnText_Click(object sender, EventArgs e)
        {
            this.OnOffState = SOICheckBoxOnOffState.OffState;
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            this.OnOffState = SOICheckBoxOnOffState.OffState;
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            this.OnOffState = SOICheckBoxOnOffState.OnState;
        }

        private void lblOffText_Click(object sender, EventArgs e)
        {
            this.OnOffState = SOICheckBoxOnOffState.OnState;
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
                this.lblOnText.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.lblOnText.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                this.btnOff.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.btnOff.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                this.btnOn.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                this.btnOn.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                this.lblOnText.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                this.lblOffText.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // 공통 색상
                this.pnlOutBorder.BackColor = MPGV.gTheme.CheckBoxOnOffBorder;
                this.lblOnText.Appearance.BackColor = MPGV.gTheme.CheckBoxOnOffOnBackground;
                this.lblOnText.Appearance.ForeColor = MPGV.gTheme.CheckBoxOnOffOnForeground;
                this.lblOffText.Appearance.BackColor = MPGV.gTheme.CheckBoxOnOffOffBackground;
                this.lblOffText.Appearance.ForeColor = MPGV.gTheme.CheckBoxOnOffOffForeground;
                this.btnOff.Appearance.BackColor = MPGV.gTheme.CheckBoxOnOffButtonBackground;
                this.btnOff.Appearance.BorderColor = MPGV.gTheme.CheckBoxOnOffButtonBorder;
                this.btnOn.Appearance.BackColor = MPGV.gTheme.CheckBoxOnOffButtonBackground;
                this.btnOn.Appearance.BorderColor = MPGV.gTheme.CheckBoxOnOffButtonBorder;

                // Enable 상태가 아닌 경우
                if (base.Enabled == false)
                {
                    this.lblOnText.Appearance.BackColor = MPGV.gTheme.ControlCommonDisabledBackground;
                    this.lblOnText.Appearance.ForeColor = MPGV.gTheme.ControlCommonDisabledForeground;
                    this.lblOffText.Appearance.BackColor = MPGV.gTheme.ControlCommonDisabledBackground;
                    this.lblOffText.Appearance.ForeColor = MPGV.gTheme.ControlCommonDisabledForeground;
                    this.btnOff.Appearance.BackColor = MPGV.gTheme.ControlCommonDisabledBackground;
                    this.btnOn.Appearance.BackColor = MPGV.gTheme.ControlCommonDisabledBackground;
                }
            }
        }

        /// <summary>
        /// On Off State에 따라 모양을 변경합니다.
        /// </summary>
        /// <param name="state"></param>
        private void ChangeState(SOICheckBoxOnOffState state)
        {
            // On State인 경우
            if (state == SOICheckBoxOnOffState.OnState)
            {
                this.lblOnText.Visible = true;
                this.btnOn.Visible = false;
                this.lblOffText.Visible = false;
                this.btnOff.Visible = true;

                if (OnOffStateChanged != null)
                {
                    OnOffStateChanged(this, new EventArgs());
                }
            }
            // Off State인 경우
            else if (state == SOICheckBoxOnOffState.OffState)
            {
                this.lblOnText.Visible = false;
                this.btnOn.Visible = true;
                this.lblOffText.Visible = true;
                this.btnOff.Visible = false;

                if (OnOffStateChanged != null)
                {
                    OnOffStateChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// 현재 보여지는 상태의 Key를 리턴합니다.
        /// </summary>
        /// <returns></returns>
        private string GetSelectedKey()
        {
            if (this.onOffState == SOICheckBoxOnOffState.OnState)
            {
                return this.onStateKey;
            }
            else
            {
                return this.offStateKey;
            }
        }

        /// <summary>
        /// 현재 보여지는 상태의 Text를 리턴합니다.
        /// </summary>
        /// <returns></returns>
        private string GetSelectedText()
        {
            if (this.onOffState == SOICheckBoxOnOffState.OnState)
            {
                return this.onStateText;
            }
            else
            {
                return this.offStateText;
            }
        }

        #endregion
    }
}
