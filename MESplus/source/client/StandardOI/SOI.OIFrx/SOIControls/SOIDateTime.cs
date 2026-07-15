using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Infragistics.Win.UltraWinSchedule;
using Infragistics.Win.UltraWinSchedule.CalendarCombo;
using System.Drawing;
using System.Globalization;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIDateTime : UltraCalendarCombo
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

        [Browsable(false)]
        public new string Format
        {
            get { return base.Format; }
            set { base.Format = value; }
        }

        [Browsable(false)]
        public new object Value
        {
            get { return base.Value; }
            set { base.Value = value; }
        }

        [Browsable(false)]
        public new string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private SOIDateTimeFormat _formatPattern = SOIDateTimeFormat.DATE_SHORT;
        public SOIDateTimeFormat FormatPattern
        {
            get 
            {
                return _formatPattern;
            }
            set
            {
                _formatPattern = value;
                base.Format = ConvertDateTimeFormat(_formatPattern);
            }
        }

        #endregion

        #region Constructor

        public SOIDateTime()
        {
            InitializeComponent();
        }

        public SOIDateTime(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Event Handler

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (this.DateButtons.Exists("TodayButton"))
            {
                return;
            }

            DateButton btnDateButton = new DateButton();
            btnDateButton.Key = "TodayButton";
            this.DateButtons.Add(btnDateButton);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            // 디자인 모드에서만 적용
            if (DesignMode == true)
            {
                SetOITheme();
            }

            base.OnPaint(pe);
        }

        private void SOIDateTime_MouseEnter(object sender, EventArgs e)
        {
            bMouseOver = true;
            SetOITheme();
        }

        private void SOIDateTime_MouseLeave(object sender, EventArgs e)
        {
            bMouseOver = false;
            SetOITheme();
        }

        private void SOIDateTime_ValueChanged(object sender, EventArgs e)
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
                this.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                this.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // 공통 색상
                this.Appearance.BackColor = MPGV.gTheme.DateTimeBackground;
                this.Appearance.ForeColor = MPGV.gTheme.DateTimeForeground;                
                this.Appearance.ForeColorDisabled = MPGV.gTheme.ControlCommonDisabledForeground;
                this.Appearance.BackColorDisabled = MPGV.gTheme.ControlCommonDisabledBackground;
                this.Appearance.BackColorDisabled2 = MPGV.gTheme.ControlCommonDisabledBackground;
                this.DateButtonAppearance.BackColor = MPGV.gTheme.DateTimeBackground;
                this.DateButtonAppearance.ForeColor = MPGV.gTheme.DateTimeCalendarDayForeground;
                this.ScrollButtonAppearance.BackColor = MPGV.gTheme.DateTimeButtonBackground;
                this.ScrollButtonAppearance.BorderColor = MPGV.gTheme.DateTimeButtonBackground;
                this.uclDateTime.MonthHeaderAppearance.BackColor = MPGV.gTheme.DateTimeCalendarHeaderBackground;
                this.uclDateTime.MonthHeaderAppearance.BorderColor = MPGV.gTheme.DateTimeCalendarHeaderBackground;
                this.uclDateTime.MonthHeaderAppearance.ForeColor = MPGV.gTheme.DateTimeCalendarHeaderForeground;
                this.MonthPopupAppearance.BackColor = MPGV.gTheme.DateTimeCalendarHeaderBackground;
                this.MonthPopupAppearance.ForeColor = MPGV.gTheme.DateTimeCalendarHeaderForeground;
                this.uclDateTime.DayAppearance.ForeColor = MPGV.gTheme.DateTimeCalendarDayForeground;
                this.uclDateTime.TrailingDayAppearance.ForeColor = MPGV.gTheme.DateTimeCalendarTrailDayForeground;
                this.uclDateTime.ActiveDayAppearance.BackColor = MPGV.gTheme.DateTimeCalendarActivaDayBackground;
                this.uclDateTime.ActiveDayAppearance.ForeColor = MPGV.gTheme.DateTimeForeground;

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
                            this.Appearance.BorderColor = MPGV.gTheme.DateTimeMouseOverBorder;
                        }
                        else
                        {
                            this.Appearance.BorderColor = MPGV.gTheme.DateTimeBorder;
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

        /// <summary>
        /// SOI Date Time Format에 맞도록 설정합니다.
        /// </summary>
        /// <param name="format"></param>
        private string ConvertDateTimeFormat(SOIDateTimeFormat format)
        {
            string sReturn = string.Empty;

            try
            {
                DateTimeFormatInfo info = CultureInfo.CurrentCulture.DateTimeFormat;

                // Short Patten인 경우
                if (format == SOIDateTimeFormat.DATE_SHORT)
                {
                    sReturn = info.ShortDatePattern;
                }
                else if (format == SOIDateTimeFormat.DATE_LONG)
                {
                    sReturn = info.LongDatePattern;
                }
                else if (format == SOIDateTimeFormat.TIME_SHORT)
                {
                    sReturn = info.ShortTimePattern;
                }
                else if (format == SOIDateTimeFormat.TIME_LONG)
                {
                    sReturn = info.LongTimePattern;
                }
                else if (format == SOIDateTimeFormat.TIME_HH_MM)
                {
                    sReturn = "HH:mm";
                }
                else if (format == SOIDateTimeFormat.TIME_HH_MM_SS)
                {
                    sReturn = "HH:mm:ss";
                }
                else if (format == SOIDateTimeFormat.DATE_SHORT_TT_HH_MM_SS)
                {
                    sReturn = info.ShortDatePattern + " tt hh:mm:ss";
                }
                else if (format == SOIDateTimeFormat.DATE_SHORT_HH_MM_SS)
                {
                    sReturn = info.ShortDatePattern + " HH:mm:ss";
                }
                else if (format == SOIDateTimeFormat.DATE_SHORT_HH_MM)
                {
                    sReturn = info.ShortDatePattern + " HH:mm";
                }
                else if (format == SOIDateTimeFormat.DATE_SHORT_HH)
                {
                    sReturn = info.ShortDatePattern + " HH";
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMessage("ConvertDateTimeFormat \n" + ex.Message, CliFrx.MSG_LEVEL.ERROR, false);                
            }

            return sReturn;
        }

        /// <summary>
        /// 입력한 string을 Format에 맞게 변환합니다.
        /// </summary>
        /// <param name="sText"></param>
        /// <returns></returns>
        private object ConvertDateTimeTextString(string sText)
        {
            try
            {
                object oValue = string.Empty;

                // 비어있는 경우
                if (string.IsNullOrEmpty(sText) == true)
                {
                    oValue = string.Empty;
                }
                // 년월일시분초
                else if (sText.Length == 14)
                {
                    DateTime dt = DateTime.ParseExact(sText, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                    oValue = dt;
                }
                // 년월일
                else if (sText.Length == 8)
                {
                    DateTime dt = DateTime.ParseExact(sText, "yyyyMMdd", CultureInfo.InvariantCulture);
                    oValue = dt;
                }
                // 시분초
                else if (sText.Length == 6)
                {
                    DateTime dt = DateTime.ParseExact(sText, "HHmmss", CultureInfo.InvariantCulture);
                    oValue = dt;
                }

                return oValue;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 입력한 String 값을 Value로 저장합니다.
        /// 14자리: yyyyMMddHHmmss
        /// 8자리: yyyyMMdd
        /// 6자리: HHmmss
        /// </summary>
        /// <param name="sValue"></param>
        /// <returns></returns>
        public bool SetValueAsString(string sValue)
        {
            try
            {
                if (string.IsNullOrEmpty(sValue) == true)
                {
                    this.Value = string.Empty;
                    return false;
                }

                if (sValue.Length != 14
                    && sValue.Length != 8
                    && sValue.Length != 6)
                {
                    this.Value = string.Empty;
                    return false;
                }

                if (sValue.Length == 14)
                {
                    DateTime dt = DateTime.ParseExact(sValue, "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                    this.Value = dt;
                }
                // 년월일
                else if (sValue.Length == 8)
                {
                    DateTime dt = DateTime.ParseExact(sValue, "yyyyMMdd", CultureInfo.InvariantCulture);
                    this.Value = dt;
                }
                // 시분초
                else if (sValue.Length == 6)
                {
                    DateTime dt = DateTime.ParseExact(sValue, "HHmmss", CultureInfo.InvariantCulture);
                    this.Value = dt;
                }

                return true;
            }
            catch (Exception)
            {
                this.Value = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// 현재 값을 String으로 반환합니다.
        /// 입력자리수에 따라 반환되는 string이 다릅니다.
        /// </summary>
        /// <returns></returns>
        public string GetValueAsString(int i)
        {
            string sReturn;

            try
            {
                sReturn = string.Empty;

                if (this.Value == null)
                {
                    return sReturn;
                }

                if (i == 14)
                {
                    if (DateTime.Parse(this.Value.ToString()) != null)
                    {
                        sReturn = DateTime.Parse(this.Value.ToString()).ToString("yyyyMMddHHmmss");
                    };
                }
                else if (i == 8)
                {
                    if (DateTime.Parse(this.Value.ToString()) != null)
                    {
                        sReturn = DateTime.Parse(this.Value.ToString()).ToString("yyyyMMdd");
                    }
                }
                else if (i == 6)
                {
                    if (DateTime.Parse(this.Value.ToString()) != null)
                    {
                        sReturn = DateTime.Parse(this.Value.ToString()).ToString("HHmmss");
                    }
                }

                return sReturn;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 입력한 DateTime 값을 Value로 저장합니다.
        /// </summary>
        /// <param name="sValue"></param>
        /// <returns></returns>
        public bool SetValueAsDateTime(DateTime dtValue)
        {
            try
            {
                if (dtValue == null)
                {
                    this.Value = string.Empty;
                    return false;
                }

                this.Value = dtValue;

                return true;
            }
            catch (Exception)
            {
                this.Value = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// 현재 값을 DateTime으로 반환합니다.
        /// </summary>
        /// <returns></returns>
        public DateTime GetValueAsDateTime()
        {
            try
            {
                if (this.Value == null)
                {
                    return new DateTime();
                }

                return DateTime.Parse(this.Value.ToString());
            }
            catch (Exception)
            {
                return new DateTime();
            }
        }

        #endregion
    }
}
