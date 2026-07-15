/*---------------------------------------------------------------------------------------------------
--  Program Id      : udcFromToDate.cs
--  Creator         : Miracom
--  Create Date     : 2012.07.25
--  Description     : Miracom Date Selection Control
--  History         : Created by Miracom at 2012.07.25
---------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Miracom.UI;
using Miracom.CliFrx;
using Miracom.MESCore;

namespace SOI.OIFrx
{
    public partial class udcFromToDate : UserControl
    {
        public udcFromToDate()
        {
            InitializeComponent();

             
        }

        public enum DateConditionType
        {
            금일, 전일, 전전일, 금주, 전주, 금월, 전월,
            기간
                , CurrD, PrevD, PPrevD, CurrW, PrevW, CurrM, PrevM, Period
        };

        public enum DateType { 기간, 일자 };

        public enum LayoutType { Horizontal, Vertical };

        //  DataTimePicker 의 타입
        private DateConditionType _ConditionType = DateConditionType.금일;
        private DateType _DurationType = DateType.기간;
        private LayoutType _FlowLayout = LayoutType.Horizontal;

        private string _Key = string.Empty;
        private bool b_mandatory_flag = false;

        private Size _LabelSize = new System.Drawing.Size(80, 20);
        //private Font _LabelFont = new System.Drawing.Font("Tahoma", 8.25F);

        private int _VerticalOrder;
        private bool _IsVertical = false;

        #region Add by mhim on MNT

        //2012.08.16
        private string _CalendarID = "";
        
        private WeekInforTag _Week;

        #endregion

        #region "Properties"

        public new bool Enabled
        {
            get
            {
                return cboConditionType.Enabled;
            }
            set
            {
                cboConditionType.Enabled = value;
                dtpFromDate.Enabled = value;
                dtpToDate.Enabled = value;
            }
        }

        [Browsable(true), Category("Custom.DYENP.COM.Controls"), Description("세로 방향")]
        public bool IsVertical
        {
            get
            {
                return _IsVertical;
            }
            set
            {
                _IsVertical = value;

                if (_IsVertical)
                {
                    this.Size = new Size(200, 70);

                    pnlCondition.Width = 90;

                    dtpFromDate.Location = new Point(1, 1);
                    dtpToDate.Location = new Point(1, 24);
                    cboConditionType.Location = new Point(1, 47);

                    dtpFromDate.Size = new Size(109, 21);
                    dtpToDate.Size = new Size(109, 21);
                    cboConditionType.Size = new Size(109, 21);

                    pnlCondition.Controls.Add(lblTo);
                    lblTo.Location = new Point(57, 25);
                    lblTo.BringToFront();
                }
                else
                {
                    //this.Size = new Size(pnlCondition.Width + pnlFromToDate.Width, 22);

                    pnlFromToDate.Controls.Add(lblTo);
                    lblTo.Location = new Point(94, 4);

                    dtpFromDate.Location = new Point(2, 1);
                    dtpToDate.Location = new Point(110, 1);
                    cboConditionType.Location = new Point(205, 1);

                    dtpFromDate.Size = new Size(92, 21);
                    dtpToDate.Size = new Size(92, 21);
                    cboConditionType.Size = new Size(75, 21);
                }
            }
        }

        [Browsable(true), Category("Custom.DYENP.COM.Controls"), Description("세로 순서")]
        public int VerticalOrder
        {
            get
            {
                return _VerticalOrder;
            }
            set
            {
                _VerticalOrder = value;
            }
        }

        [Browsable(true)
        , DefaultValue(LayoutType.Horizontal)
        , Category("Custom.DYENP.COM.Controls"), Description("라벨 Size")]
        public Size LabelSize
        {
            get
            {
                return _LabelSize;
            }
            set
            {
                _LabelSize = value;
                pnlCondition.Size = _LabelSize;
                lblCondition.Width = value.Width;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , DefaultValue(LayoutType.Horizontal)
        , Category("Custom.DYENP.COM.Controls"), Description("라벨 Font")]
        public Font LabelFont
        {
            get
            {
                return lblCondition.Font;
            }
            set
            {
                lblCondition.Font = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , DefaultValue(LayoutType.Horizontal)
        , Category("Custom.DYENP.COM.Controls"), Description("언어 옵션")]
        public string LanguageKey
        {
            get
            {
                return _Key;
            }
            set
            {
                _Key = value;
                lblCondition.AccessibleDescription = _Key;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        , Category("Custom.DYENP.COM.Controls")]
        public string FromDate
        {
            get
            {
                return this.dtpFromDate.Value.ToString("yyyyMMdd");
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , Category("Custom.DYENP.COM.Controls")]
        public int FromDateWidth
        {
            get
            {
                return this.dtpFromDate.Width;
            }
            set
            {
                this.dtpFromDate.Width = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        , Category("Custom.DYENP.COM.Controls")]
        public DateTime FromDateValue
        {
            get
            {
                return dtpFromDate.Value;
            }
            set
            {
                this.dtpFromDate.Value = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        , Category("Custom.DYENP.COM.Controls")]
        public string ToDate
        {
            get
            {
                return this.dtpToDate.Value.ToString("yyyyMMdd");
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , Category("Custom.DYENP.COM.Controls")]
        public int ToDateWidth
        {
            get
            {
                return this.dtpToDate.Width;
            }
            set
            {
                this.dtpToDate.Width = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        , Category("Custom.DYENP.COM.Controls")]
        public DateTime ToDateValue
        {
            get
            {
                return dtpToDate.Value;
            }
            set
            {
                this.dtpToDate.Value = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , Category("Custom.DYENP.COM.Controls")]
        public int ButtonWidth
        {
            get
            {
                return this.cboConditionType.Width;
            }
            set
            {
                this.cboConditionType.Width = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        , Category("Custom.DYENP.COM.Controls")]
        public string FromDateTime
        {
            get
            {
                if (MPCF.Trim(MPGV.gShiftInfor.sShift1StartTime) != "")
                {
                    return this.dtpFromDate.Value.ToString("yyyyMMdd") + MPCF.Trim(MPGV.gShiftInfor.sShift1StartTime);
                }
                else
                {
                    return this.dtpFromDate.Value.ToString("yyyyMMdd") + "080000";
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        , Category("Custom.DYENP.COM.Controls")]
        public string ToDateTime
        {
            get
            {
                if (MPCF.Trim(MPGV.gShiftInfor.sShift1StartTime) != "")
                {
                    return MPCF.ToDate(dtpToDate.Value.ToString("yyyyMMdd") + MPCF.Trim(MPGV.gShiftInfor.sShift1StartTime)).AddDays(1).AddSeconds(-1).ToString("yyyyMMddHHmmss");
                }
                else
                {
                    return this.dtpToDate.Value.AddDays(1).ToString("yyyyMMdd") + "075959";
                }

            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , DefaultValue(LayoutType.Horizontal)
        , Category("Custom.DYENP.COM.Controls")
        , Description("화면배치구분")]
        public LayoutType FlowLayout
        {
            get
            {
                return _FlowLayout;
            }
            set
            {
                _FlowLayout = value;
                if (_FlowLayout == LayoutType.Horizontal)
                {

                    this.pnlCondition.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    this.pnlCondition.Dock = DockStyle.None;
                    this.pnlFromToDate.Dock = DockStyle.Right;

                    this.pnlCondition.SendToBack();
                    //this.Size = new Size(pnlCondition.Width + pnlFromToDate.Width, 22);

                }
                else if (_FlowLayout == LayoutType.Vertical)
                {
                    this.pnlCondition.Anchor = AnchorStyles.None;
                    this.pnlCondition.Dock = DockStyle.Top;
                    this.pnlFromToDate.Dock = DockStyle.Fill;

                    this.pnlCondition.SendToBack();
                    this.Size = new Size(275, 44);
                }
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , Category("Custom.DYENP.COM.Controls")
        , Description("조건명")]
        public string ConditionText
        {
            get
            {
                return lblCondition.Text;
            }
            set
            {
                lblCondition.Text = value;
            }
        }

        bool _conditionTypeChanging;

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , Category("Custom.DYENP.COM.Controls")
        , Description("기간조건 구분")]
        public DateConditionType ConditionType
        {
            get
            {
                return _ConditionType;
            }
            set
            {
                _ConditionType = value;
                _conditionTypeChanging = true;

                if (_ConditionType == DateConditionType.금일)
                {
                    this.dtpToDate.Value = DateTime.Today;
                    this.dtpFromDate.Value = DateTime.Today;
                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.전일)
                {
                    this.dtpToDate.Value = DateTime.Today.AddDays(-1);
                    this.dtpFromDate.Value = DateTime.Today.AddDays(-1);
                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.전전일)
                {
                    this.dtpToDate.Value = DateTime.Today.AddDays(-2);
                    this.dtpFromDate.Value = DateTime.Today.AddDays(-2);
                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.금주)
                {
                    if (_CalendarID == "")
                    {
                        int addFromDay = (int)DateTime.Today.DayOfWeek - 1;
                        this.dtpFromDate.Value = DateTime.Today.AddDays(addFromDay * -1);
                        int addToDay = 7 - (int)DateTime.Today.DayOfWeek;
                        this.dtpToDate.Value = DateTime.Today.AddDays(addToDay);
                    }
                    else
                    {
                        DateTime today = DateTime.Today;
                        WeekInfo = MPCR.GetWeekInfor(_CalendarID, today.Year, today.Month, today.Day);

                        this.dtpFromDate.Value = MPCF.ToDate(WeekInfo.WeekStartDate);
                        this.dtpToDate.Value = MPCF.ToDate(WeekInfo.WeekEndDate);
                    }

                    this.dtpToDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.전주)
                {
                    if (_CalendarID == "")
                    {
                        int addFromDay = (int)DateTime.Today.DayOfWeek - 1;
                        this.dtpFromDate.Value = DateTime.Today.AddDays(addFromDay * -1).AddDays(-7);
                        int addToDay = 7 - (int)DateTime.Today.DayOfWeek;
                        this.dtpToDate.Value = DateTime.Today.AddDays(addToDay).AddDays(-7);
                    }
                    else
                    {
                        DateTime today = DateTime.Today;
                        WeekInfo = MPCR.GetWeekInfor(_CalendarID, today.Year, today.Month, today.Day);

                        this.dtpFromDate.Value = MPCF.ToDate(WeekInfo.WeekStartDate);
                        this.dtpToDate.Value = MPCF.ToDate(WeekInfo.WeekEndDate);
                    }

                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.금월)
                {

                    //2009.12.01 YJH8318 날짜오류 수정 
                    //this.dtpToDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(+1).Month, 1).AddDays(-1);
                    this.dtpToDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(+1).AddDays(-1);
                    this.dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.전월)
                {
                    this.dtpToDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
                    //2009.12.01 YJH8318 날짜오류 수정 
                    //this.dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(-1).Month, 1);
                    this.dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.기간)
                {
                    this.dtpFromDate.Enabled = true;
                    this.dtpToDate.Enabled = true;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }

                //English
                if (_ConditionType == DateConditionType.CurrD)
                {
                    this.dtpToDate.Value = DateTime.Today;
                    this.dtpFromDate.Value = DateTime.Today;
                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.PrevD)
                {
                    this.dtpToDate.Value = DateTime.Today.AddDays(-1);
                    this.dtpFromDate.Value = DateTime.Today.AddDays(-1);
                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.PPrevD)
                {
                    this.dtpToDate.Value = DateTime.Today.AddDays(-2);
                    this.dtpFromDate.Value = DateTime.Today.AddDays(-2);
                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.CurrW)
                {
                    if (_CalendarID == "")
                    {
                        int addFromDay = (int)DateTime.Today.DayOfWeek - 1;
                        this.dtpFromDate.Value = DateTime.Today.AddDays(addFromDay * -1);
                        int addToDay = 7 - (int)DateTime.Today.DayOfWeek;
                        this.dtpToDate.Value = DateTime.Today.AddDays(addToDay);
                    }
                    else
                    {
                        DateTime today = DateTime.Today;
                        WeekInfo = MPCR.GetWeekInfor(_CalendarID, today.Year, today.Month, today.Day);

                        this.dtpFromDate.Value = MPCF.ToDate(WeekInfo.WeekStartDate);
                        this.dtpToDate.Value = MPCF.ToDate(WeekInfo.WeekEndDate);
                    }
                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.PrevW)
                {
                    if (_CalendarID == "")
                    {
                        int addFromDay = (int)DateTime.Today.DayOfWeek - 1;
                        this.dtpFromDate.Value = DateTime.Today.AddDays(addFromDay * -1).AddDays(-7);
                        int addToDay = 7 - (int)DateTime.Today.DayOfWeek;
                        this.dtpToDate.Value = DateTime.Today.AddDays(addToDay).AddDays(-7);
                    }
                    else
                    {
                        DateTime today = DateTime.Today;
                        WeekInfo = MPCR.GetWeekInfor(_CalendarID, today.Year, today.Month, today.Day);

                        this.dtpFromDate.Value = MPCF.ToDate(WeekInfo.WeekStartDate);
                        this.dtpToDate.Value = MPCF.ToDate(WeekInfo.WeekEndDate);
                    }

                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.CurrM)
                {
                    string sTmp = string.Empty;
                    DateTime date = DateTime.Now;
                    date = date.AddMonths(1);
                    sTmp = date.ToString("yyyy-MM-01");
                    date = Convert.ToDateTime(sTmp);
                    date = date.AddDays(-1);

                    this.dtpToDate.Value = date;
                    this.dtpFromDate.Value = Convert.ToDateTime(date.ToString("yyyy-MM-01"));

                    //this.dtpToDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(+1).Month, 1).AddDays(-1);
                    //this.dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);                    
                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.PrevM)
                {
                    this.dtpToDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
                    this.dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(-1).Month, 1);
                    this.dtpFromDate.Enabled = false;
                    this.dtpToDate.Enabled = false;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }
                else if (_ConditionType == DateConditionType.Period)
                {
                    this.dtpFromDate.Enabled = true;
                    this.dtpToDate.Enabled = true;
                    this.cboConditionType.Text = _ConditionType.ToString();
                }

                _conditionTypeChanging = false;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , Category("Custom.DYENP.COM.Controls")
        , Description("일자/기간 구분")]
        public DateType DurationType
        {
            get
            {
                return _DurationType;
            }
            set
            {
                _DurationType = value;

                if (this._DurationType == DateType.일자)
                {
                    this.lblTo.Visible = false;
                    this.dtpToDate.Visible = false;
                    this.cboConditionType.Visible = false;
                }
                else if (this._DurationType == DateType.기간)
                {
                    this.lblTo.Visible = true;
                    this.dtpToDate.Visible = true;
                    this.cboConditionType.Visible = true;
                }
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , DefaultValue(true)
        , Category("Custom.DYENP.COM.Controls")
        , Description("조회조건의 라벨 보이기 유무")]
        public bool VisibleConditionText
        {
            get
            {
                return lblCondition.Visible;
            }
            set
            {
                this.pnlCondition.Visible = value;
                lblCondition.Visible = value;
                lblPlus.Visible = value;

                //163, 338
                if (this._DurationType == DateType.일자)
                {
                    this.Size = new Size(163, 22);
                }
                else if (this._DurationType == DateType.기간)
                {
                    //this.Size = new Size(pnlCondition.Width + pnlFromToDate.Width, 22);
                }

            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , DefaultValue(true)
        , Category("Custom.DYENP.COM.Controls")
        , Description("필수조회유무")]
        public bool MandatoryFlag
        {
            get
            {
                return b_mandatory_flag;
            }
            set
            {
                b_mandatory_flag = value;

                if (b_mandatory_flag == true)
                {
                    lblCondition.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                }
                else
                {
                    lblCondition.Font = new System.Drawing.Font(this.Font, FontStyle.Regular);
                }
            }
        }


        #region Add by mhim on MNT

        //2012.08.16
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , DefaultValue(true)
        , Category("Custom.DYENP.COM.Controls")
        , Description("칼렌다 ID")]
        public string CanlendarID
        {
            get
            {
                return _CalendarID;
            }
            set
            {
                _CalendarID = value;
            }
        }

        //2012.08.16
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , DefaultValue(true)
        , Category("Custom.DYENP.COM.Controls")
        , Description("주차")]
        public WeekInforTag WeekInfo
        {
            get
            {
                if (_Week.Equals(null))
                {
                    _Week = new WeekInforTag();
                }
                return _Week;
            }
            set
            {
                _Week = value;
            }
        }
        #endregion


        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            int idx = 0;
            try
            {  
                this.cboConditionType.Items.Clear();

                this.cboConditionType.Items.Add("금일");
                this.cboConditionType.Items.Add("전일");
                this.cboConditionType.Items.Add("전전일");
                this.cboConditionType.Items.Add("금주");
                this.cboConditionType.Items.Add("전주");
                this.cboConditionType.Items.Add("금월");
                this.cboConditionType.Items.Add("전월");
                this.cboConditionType.Items.Add("기간");

                idx = this.cboConditionType.FindString(ConditionType.ToString());

                this.cboConditionType.Items.Clear();

                if (MPGV.gcLanguage == '1' || MPGV.gcLanguage == '3')
                {
                    this.cboConditionType.Items.Add("Curr.D");
                    this.cboConditionType.Items.Add("Prev.D");
                    this.cboConditionType.Items.Add("PPrev.D");
                    this.cboConditionType.Items.Add("Curr.W");
                    this.cboConditionType.Items.Add("Prev.W");
                    this.cboConditionType.Items.Add("Curr.M");
                    this.cboConditionType.Items.Add("Prev.M");
                    this.cboConditionType.Items.Add("Period");

                }
                else if (MPGV.gcLanguage == '2')
                {
                    this.cboConditionType.Items.Add("금일");
                    this.cboConditionType.Items.Add("전일");
                    this.cboConditionType.Items.Add("전전일");
                    this.cboConditionType.Items.Add("금주");
                    this.cboConditionType.Items.Add("전주");
                    this.cboConditionType.Items.Add("금월");
                    this.cboConditionType.Items.Add("전월");
                    this.cboConditionType.Items.Add("기간");
                }

                this.cboConditionType.SelectedIndex = idx;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.ToString());
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        private void cboConditionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cboBox = sender as ComboBox;

            if (cboBox.SelectedItem != null)
            {
                if (!_conditionTypeChanging)
                    ConditionType = (DateConditionType)cboBox.SelectedIndex;
            }

        }


        /// <summary>
        /// FromDate Validation
        /// FromDate는 ToDate의 미래 날짜일 수 없음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpToDate.Value < dtpFromDate.Value)
            {
                dtpToDate.Value = dtpFromDate.Value;
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpToDate.Value < dtpFromDate.Value)
            {
                dtpFromDate.Value = dtpToDate.Value;
            }
        }

        private void udcFromToDate_FontChanged(object sender, EventArgs e)
        {
            lblCondition.Font = this.Font;
            dtpFromDate.Font = this.Font;
            dtpToDate.Font = this.Font;
            cboConditionType.Font = this.Font;
        }

        public ListView GetListView()
        {
            ListView lv = new ListView();

            DateTime from = dtpFromDate.Value;
            DateTime to = dtpToDate.Value;

            int iCnt = to.DayOfYear - from.DayOfYear;

            while (from <= to)
            {
                lv.Items.Add(from.ToString("yyyyMMdd"));
                from = from.AddDays(1);
            }

            return lv;
        }

        private void udcFromToDate_Load(object sender, EventArgs e)
        {
        }

    }
}
