using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx.SOIControls
{
    public partial class SOIDateTimeComboBox : UserControl
    {
        #region Property

        private string _const_default_year = "1999";
        private string _const_default_month = "01";
        private string _const_default_day = "01";
        private string _const_default_hour = "00";
        private string _const_default_minute = "00";
        private string _const_default_second = "00";
        private List<string> _const_default_year_list = new List<string>();
        private List<string> _const_default_month_list = new List<string>();
        private List<string> _const_default_day_list = new List<string>();

        private enum COL_DATETIME_TLP_OUTLINE
        {
            FIRST_MARGIN,
            YEAR,
            MONTH_MARGIN,
            MONTH,
            DAY_MARGIN,
            DAY,
            HOUR_MARGIN,
            HOUR,
            MINUTE_MARGIN,
            MINUTE,
            SECOND_MARGIN,
            SECOND,
            LAST_MARGIN
        }

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

        [Browsable(true)]
        private SOIDateTimeComboBoxFormat format = SOIDateTimeComboBoxFormat.YYYY_MM_DD_HH_MM_SS;
        public SOIDateTimeComboBoxFormat Format
        {
            get 
            { 
                return format; 
            }
            set 
            { 
                format = value;
                SetFormat();
            }
        }

        private List<string> yearList = new List<string>();
        public List<string> YearList
        {
            get { return yearList; }
            set
            {
                yearList = value;
                SetYearList();
            }
        }

        private List<string> monthList = new List<string>();
        public List<string> MonthList
        {
            get { return monthList; }
            set
            {
                monthList = value;
                SetMonthList();
            }
        }

        private string value;
        public string Value
        {
            get { return GetValue(14); }
            set { this.value = SetValue(value); }
        }

        #endregion

        #region Constructor

        public SOIDateTimeComboBox()
        {
            InitializeComponent();

            this.SetValue(DateTime.Now);
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

        private void cboMonth_ValueChanged(object sender, EventArgs e)
        {
            SetDayList();
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
                              
            }
        }

        /// <summary>
        /// Validation을 합니다.
        /// </summary>
        public void SetValidation()
        {
            if (format == SOIDateTimeComboBoxFormat.YYYY)
            {
                if (string.IsNullOrEmpty(this.cboYear.Text) == true)
                {
                    this.cboYear.SetValidation();
                }
            }
            else if (format == SOIDateTimeComboBoxFormat.YYYY_MM)
            {
                if (string.IsNullOrEmpty(this.cboYear.Text) == true)
                {
                    this.cboYear.SetValidation();
                }
                else
                {
                    if (string.IsNullOrEmpty(this.cboMonth.Text) == true)
                    {
                        this.cboMonth.SetValidation();
                    }
                }
            }
            else if (format == SOIDateTimeComboBoxFormat.YYYY_MM_DD)
            {
                if (string.IsNullOrEmpty(this.cboYear.Text) == true)
                {
                    this.cboYear.SetValidation();
                }
                else
                {
                    if (string.IsNullOrEmpty(this.cboMonth.Text) == true)
                    {
                        this.cboMonth.SetValidation();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(this.cboDay.Text) == true)
                        {
                            this.cboDay.SetValidation();
                        }
                    }
                }
            }
            else if (format == SOIDateTimeComboBoxFormat.YYYY_MM_DD_HH_MM_SS)
            {
                if (string.IsNullOrEmpty(this.cboYear.Text) == true)
                {
                    this.cboYear.SetValidation();
                }
                else
                {
                    if (string.IsNullOrEmpty(this.cboMonth.Text) == true)
                    {
                        this.cboMonth.SetValidation();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(this.cboDay.Text) == true)
                        {
                            this.cboDay.SetValidation();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(this.txtHour.Text) == true)
                            {
                                this.txtHour.SetValidation();
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(this.txtMinute.Text) == true)
                                {
                                    this.txtMinute.SetValidation();
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(this.txtSecond.Text) == true)
                                    {
                                        this.txtSecond.SetValidation();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (format == SOIDateTimeComboBoxFormat.HH_MM)
            {
                if (string.IsNullOrEmpty(txtHour.Text) == true)
                {
                    this.txtHour.SetValidation();
                }
                else
                {
                    if (string.IsNullOrEmpty(txtMinute.Text) == true)
                    {
                        this.txtMinute.SetValidation();
                    }
                }
            }
            else if (format == SOIDateTimeComboBoxFormat.HH_MM_SS)
            {
                if (string.IsNullOrEmpty(this.txtHour.Text) == true)
                {
                    this.txtHour.SetValidation();
                }
                else
                {
                    if (string.IsNullOrEmpty(this.txtMinute.Text) == true)
                    {
                        this.txtMinute.SetValidation();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(this.txtSecond.Text) == true)
                        {
                            this.txtSecond.SetValidation();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Format에 따라 화면을 수정합니다.
        /// </summary>
        private void SetFormat()
        {
            if (format == SOIDateTimeComboBoxFormat.YYYY)
            {
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.YEAR].Width = 100;                
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH].Width = 0;                
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY].Width = 0;                
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR].Width = 0;                
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE].Width = 0;                
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND].Width = 0;
                
                this.cboYear.Visible = true;
                this.cboMonth.Visible = false;
                this.cboDay.Visible = false;
                this.txtHour.Visible = false;
                this.txtMinute.Visible = false;
                this.txtSecond.Visible = false;
            }
            else if(format == SOIDateTimeComboBoxFormat.YYYY_MM)
            {                
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.YEAR].Width = 70;                
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH_MARGIN].Width = 5;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH].Width = 30;                
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY].Width = 0;                
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND].Width = 0;

                this.cboYear.Visible = true;
                this.cboMonth.Visible = true;
                this.cboDay.Visible = false;
                this.txtHour.Visible = false;
                this.txtMinute.Visible = false;
                this.txtSecond.Visible = false;
            }
            else if (format == SOIDateTimeComboBoxFormat.YYYY_MM_DD)
            {
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.YEAR].Width = 50;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH_MARGIN].Width = 5;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH].Width = 25;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY_MARGIN].Width = 5;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY].Width = 25;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR_MARGIN].Width = 0.0F;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE_MARGIN].Width = 0.0F;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND_MARGIN].Width = 0.0F;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND].Width = 0;

                this.cboYear.Visible = true;
                this.cboMonth.Visible = true;
                this.cboDay.Visible = true;
                this.txtHour.Visible = false;
                this.txtMinute.Visible = false;
                this.txtSecond.Visible = false;
            }
            else if (format == SOIDateTimeComboBoxFormat.YYYY_MM_DD_HH_MM_SS)
            {
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.YEAR].Width = 25;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH_MARGIN].Width = 5;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH].Width = 15;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY_MARGIN].Width = 5;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY].Width = 15;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR_MARGIN].Width = 20;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR].Width = 15;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE_MARGIN].Width = 5;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE].Width = 15;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND_MARGIN].Width = 5;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND].Width = 15;

                this.cboYear.Visible = true;
                this.cboMonth.Visible = true;
                this.cboDay.Visible = true;
                this.txtHour.Visible = true;
                this.txtMinute.Visible = true;
                this.txtSecond.Visible = true;
            }
            else if (format == SOIDateTimeComboBoxFormat.HH_MM)
            {
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.YEAR].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR].Width = 50;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE_MARGIN].Width = 15;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE].Width = 50;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND].Width = 0;

                this.cboYear.Visible = false;
                this.cboMonth.Visible = false;
                this.cboDay.Visible = false;
                this.txtHour.Visible = true;
                this.txtMinute.Visible = true;
                this.txtSecond.Visible = false;
            }
            else if (format == SOIDateTimeComboBoxFormat.HH_MM_SS)
            {
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.YEAR].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MONTH].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.DAY].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR_MARGIN].Width = 0;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.HOUR].Width = 33;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE_MARGIN].Width = 10;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.MINUTE].Width = 33;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND_MARGIN].Width = 10;
                tlpOutline.ColumnStyles[(int)COL_DATETIME_TLP_OUTLINE.SECOND].Width = 33;

                this.cboYear.Visible = false;
                this.cboMonth.Visible = false;
                this.cboDay.Visible = false;
                this.txtHour.Visible = true;
                this.txtMinute.Visible = true;
                this.txtSecond.Visible = true;
            }
        }

        /// <summary>
        /// Year, Month, Day List를 갱신합니다.
        /// </summary>
        private void SetYearList()
        {
            if (this.YearList == null || this.YearList.Count < 1)
            {
                this.cboYear.Items.Clear();
                for (int i = 0; i < 99; i++)
                {
                    this.cboYear.Items.Add(2000 + i, (2000 + i).ToString());
                }
            }
        }

        /// <summary>
        /// Year, Month, Day List를 갱신합니다.
        /// </summary>
        private void SetMonthList()
        {
            if (this.MonthList == null || this.MonthList.Count < 1)
            {
                this.cboMonth.Items.Clear();
                string sFormatString = string.Empty;
                for (int i = 0; i < 12; i++)
                {
                    sFormatString = MonthFormatString(1 + i);
                    this.cboMonth.Items.Add(sFormatString, sFormatString);
                }
            }
        }

        /// <summary>
        /// Year, Month, Day List를 갱신합니다.
        /// </summary>
        private void SetDayList()
        {
            if (string.IsNullOrEmpty(this.cboYear.Text) == true || string.IsNullOrEmpty(this.cboMonth.Text) == true)
            {
                this.cboDay.Items.Clear();
            }
            else
            {
                int daysInMonth = DateTime.DaysInMonth(MPCF.ToInt(this.cboYear.Text), MPCF.ToInt(this.cboMonth.Text));
                this.cboDay.Items.Clear();
                string sFormatString = string.Empty;
                for (int i = 0; i < daysInMonth; i++)
                {
                    sFormatString = DayFormatString(1 + i);
                    this.cboDay.Items.Add(sFormatString, sFormatString);
                }
            }            
        }

        /// <summary>
        /// 년도에 대한 값에 0을 붙입니다.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string YearFormatString(int i)
        {
            string sValue = i.ToString();

            if (sValue.Length < 2)
            {
                sValue = "000" + sValue;
            }
            else if (sValue.Length < 3)
            {
                sValue = "00" + sValue;
            }
            else if (sValue.Length < 4)
            {
                sValue = "0" + sValue;
            }

            return sValue;
        }

        /// <summary>
        /// 월에 대한 값에 0를 붙입니다.
        /// </summary>
        /// <param name="i"></param>
        private string MonthFormatString(int i)
        {
            // Min, Max
            if(i < 1)
            {
                i = 1;
            }
            else if(i > 12)
            {
                i = 12;
            }

            string sValue = i.ToString();
            if (sValue.Length < 2)
            {
                sValue = "0" + sValue;
            }

            return sValue;
        }

        /// <summary>
        /// 일에 대한 값에 0을 붙입니다.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string DayFormatString(int i)
        {
            // Min, Max
            if(i < 1)
            {
                i = 1;
            }
            else if (i > 31)
            {
                i = 31;
            }

            string sValue = i.ToString();
            if(sValue.Length < 2)
            {
                sValue = "0" + sValue;                
            }

            return sValue;
        }

        /// <summary>
        /// 시간에 대한 값에 0을 붙입니다.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private string HourFormatString(int i)
        {
            if (i < 0)
            {
                i = 0;
            }
            else if (i > 24)
            {
                i = 24;
            }

            string sValue = i.ToString();
            if (sValue.Length < 2)
            {
                sValue = "0" + sValue;
            }

            return sValue;
        }

        /// <summary>
        /// 분에 대한 값에 0을 붙입니다.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private string MinuteFormatString(int i)
        {
            if (i < 0)
            {
                i = 0;
            }
            else if (i > 59)
            {
                i = 59;
            }

            string sValue = i.ToString();
            if (sValue.Length < 2)
            {
                sValue = "0" + sValue;
            }

            return sValue;
        }

        /// <summary>
        /// 초에 대한 값에 0을 붙입니다.
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private string SecondFormatString(int i)
        {
            if (i < 0)
            {
                i = 0;
            }
            else if (i > 59)
            {
                i = 59;
            }

            string sValue = i.ToString();
            if (sValue.Length < 2)
            {
                sValue = "0" + sValue;
            }

            return sValue;
        }

        /// <summary>
        /// value를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public string GetValue(int digit)
        {
            string sReturn = string.Empty;

            if (digit == 14)
            {
                sReturn = this.cboYear.Text + this.cboMonth.Text + this.cboDay.Text + this.txtHour.Text + this.txtMinute.Text + this.txtSecond.Text;
            }
            else if (digit == 8)
            {
                sReturn = this.cboYear.Text + this.cboMonth.Text + this.cboDay.Text;
            }
            else if (digit == 6)
            {
                sReturn = this.txtHour.Text + this.txtMinute.Text + this.txtSecond.Text;
            }

            //if (format == SOIDateTimeComboBoxFormat.YYYY)
            //{
            //    value = this.cboYear.Text;
            //}
            //else if (format == SOIDateTimeComboBoxFormat.YYYY_MM)
            //{
            //    value = this.cboYear.Text + this.cboMonth.Text;
            //}
            //else if (format == SOIDateTimeComboBoxFormat.YYYY_MM_DD)
            //{
            //    value = this.cboYear.Text + this.cboMonth.Text + this.cboDay.Text;
            //}
            //else if (format == SOIDateTimeComboBoxFormat.YYYY_MM_DD_HH_MM_SS)
            //{
            //    value = this.cboYear.Text + this.cboMonth.Text + this.cboDay.Text + this.txtHour.Text + this.txtMinute.Text + this.txtSecond.Text;
            //}
            //else if (format == SOIDateTimeComboBoxFormat.HH_MM)
            //{
            //    value = this.txtHour.Text + this.txtMinute.Text;
            //}
            //else if (format == SOIDateTimeComboBoxFormat.HH_MM_SS)
            //{
            //    value = this.txtHour.Text + this.txtMinute.Text + this.txtSecond.Text;
            //}
            //else
            //{
            //    // Error
            //    value = string.Empty;
            //}

            return sReturn;
        }

        /// <summary>
        /// value에 따라 화면을 설정합니다.
        /// </summary>
        /// <param name="sValue"></param>
        /// <returns></returns>
        private string SetValue(string sValue)
        {
            string sReturn = string.Empty;

            if (string.IsNullOrEmpty(sValue) == true)
            {
                return sReturn;
            }
            else if (sValue.Length == 14)
            {
                this.cboYear.Text = sValue.Substring(0, 4);
                this.cboMonth.Text = sValue.Substring(4, 2);
                this.cboDay.Text = sValue.Substring(6, 2);
                this.txtHour.Text = sValue.Substring(8, 2);
                this.txtMinute.Text = sValue.Substring(10, 2);
                this.txtSecond.Text = sValue.Substring(12, 2);
                sReturn = sValue;

                SetYearList();
                SetMonthList();
                SetDayList();
            }
            else if (sValue.Length == 8)
            {
                this.cboYear.Text = sValue.Substring(0, 4);
                this.cboMonth.Text = sValue.Substring(4, 2);
                this.cboDay.Text = sValue.Substring(6, 2);
                this.txtHour.Text = _const_default_hour;
                this.txtMinute.Text = _const_default_minute;
                this.txtSecond.Text = _const_default_second;
                sReturn = sValue;

                SetYearList();
                SetMonthList();
                SetDayList();
            }
            else if (sValue.Length == 6)
            {
                this.cboYear.Text = _const_default_year;
                this.cboMonth.Text = _const_default_month;
                this.cboDay.Text = _const_default_day;
                this.txtHour.Text = sValue.Substring(0, 2);
                this.txtMinute.Text = sValue.Substring(2, 2);
                this.txtSecond.Text = sValue.Substring(4, 2);
                sReturn = sValue;
            }
            else
            {
                return sReturn;
            }

            return sReturn;
        }

        /// <summary>
        /// value에 따라 화면을 설정합니다.
        /// </summary>
        /// <param name="sValue"></param>
        /// <returns></returns>
        public void SetValue(DateTime dateTimeValue)
        {
            this.Value = ConvertDateTimeToString(dateTimeValue);
        }

        /// <summary>
        /// DateTime Value를 14자리 String으로 변환합니다.
        /// </summary>
        /// <param name="dateTimeValue"></param>
        /// <returns></returns>
        private string ConvertDateTimeToString(DateTime dateTimeValue)
        {
            return dateTimeValue.ToString("yyyyMMddhhmmss");
        }

        /// <summary>
        /// Year를 변경합니다.
        /// </summary>
        /// <param name="year"></param>
        public void SetValueYear(int year)
        {       
            this.cboYear.Text = YearFormatString(year); 
        }

        /// <summary>
        /// Month를 변경합니다.
        /// </summary>
        /// <param name="year"></param>
        public void SetValueMonth(int month)
        {
            this.cboMonth.Text = MonthFormatString(month);
        }

        /// <summary>
        /// Day를 변경합니다.
        /// </summary>
        /// <param name="year"></param>
        public void SetValueDay(int day)
        {
            this.cboDay.Text = DayFormatString(day);
        }

        /// <summary>
        /// 시간을 변경합니다.
        /// </summary>
        /// <param name="year"></param>
        public void SetValueHour(int hour)
        {
            this.txtHour.Text = HourFormatString(hour);
        }

        /// <summary>
        /// 분을 변경합니다.
        /// </summary>
        /// <param name="year"></param>
        public void SetValueMinute(int min)
        {
            this.txtMinute.Text = MinuteFormatString(min);
        }

        /// <summary>
        /// 초를 변경합니다.
        /// </summary>
        /// <param name="year"></param>
        public void SetValueSecond(int sec)
        {
            this.txtSecond.Text = SecondFormatString(sec);
        }

        /// <summary>
        /// Year를 조회합니다.
        /// </summary>
        /// <param name="year"></param>
        public string GetValueYear()
        {
            return this.cboYear.Text;
        }

        /// <summary>
        /// Month를 변경합니다.
        /// </summary>
        /// <param name="year"></param>
        public string GetValueMonth()
        {
            return this.cboMonth.Text;
        }

        /// <summary>
        /// Day를 변경합니다.
        /// </summary>
        /// <param name="year"></param>
        public string GetValueDay()
        {
            return this.cboDay.Text;
        }

        /// <summary>
        /// 시간을 변경합니다.
        /// </summary>
        /// <param name="year"></param>
        public string GetValueHour()
        {
            return this.txtHour.Text;
        }

        /// <summary>
        /// 분을 변경합니다.
        /// </summary>
        /// <param name="year"></param>
        public string GetValueMinute()
        {
            return this.txtMinute.Text;
        }

        /// <summary>
        /// 초를 변경합니다.
        /// </summary>
        /// <param name="year"></param>
        public string GetValueSecond()
        {
            return this.txtSecond.Text;
        }

        #endregion
    }
}
