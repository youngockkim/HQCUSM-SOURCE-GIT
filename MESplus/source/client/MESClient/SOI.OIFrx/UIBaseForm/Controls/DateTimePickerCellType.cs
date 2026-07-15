using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI;
using Miracom.TRSCore;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using FarPoint.Win;
using System.Globalization;
using System.Drawing.Drawing2D;

namespace SOI.OIFrx
{
    #region [ Class Functions ]
    #region < DateTimePicker >
    public class MyDateTimePicker : DateTimePicker
    {
        private FarPoint.Win.Spread.FpSpread fpSpread1;
        private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
        private bool dropped = false;
        protected override void OnCloseUp(EventArgs e)
        {
            dropped = false;
            OnLostFocus(EventArgs.Empty);
        }
        protected override void OnDropDown(EventArgs e)
        {
            dropped = true;
        }

        private void InitializeComponent()
        {
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            // 
            // fpSpread1
            // 
            this.fpSpread1.Location = new System.Drawing.Point(17, 17);
            this.fpSpread1.Name = "fpSpread1";
            this.fpSpread1.Sheets.Add(this.fpSpread1_Sheet1);
            this.fpSpread1.TabIndex = 0;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // 
            // MyDateTimePicker
            // 
            this.CustomFormat = "yyyy-MM-dd";
            this.Format = DateTimePickerFormat.Custom;
            this.Value = new System.DateTime(2009, 10, 30);
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();

        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (!dropped)
                base.OnLostFocus(e);
        }
    }

    public class DateTimePickerCellType : ICellType
    {
        internal MyDateTimePicker editBox = null;
        private StringTrimming trimming = StringTrimming.None;
        private StringAlignment valign = StringAlignment.Near;
        private StringAlignment halign = StringAlignment.Near;
        private TextOrientation mtextOrientation = TextOrientation.TextHorizontal;

        /// <summary>
        /// Creates a new cell.
        /// </summary>
        public DateTimePickerCellType()
        {
        }

        public event EventHandler EditingCanceled;

        protected virtual void FireEditingCanceled()
        {
            if (EditingCanceled != null)
                EditingCanceled(this, EventArgs.Empty);
        }

        /// <summary>
        /// Occurs when editing (the editor control) has been stopped by the user.
        /// </summary>
        public event EventHandler EditingStopped;

        protected virtual void FireEditingStopped()
        {
            if (EditingStopped != null)
                EditingStopped(this, EventArgs.Empty);
        }
        /// <summary>
        /// Gets whether the specified value is valid.
        /// </summary>
        public bool IsValid(object value)
        {
            return true;
        }
        /// <summary>
        /// Shows the subeditor control associated with the cell.
        /// </summary>
        public void ShowSubEditor()
        {
        }

        /// <summary>
        /// Gets or sets how text orients itself when painting the cell.
        /// </summary>
        [
        DefaultValue(TextOrientation.TextHorizontal),
        Description("Gets or sets how text orients itself when painting the cell.")
        ]
        public TextOrientation TextOrientation
        {
            get { return mtextOrientation; }
            set { mtextOrientation = value; }
        }
        /// <summary>
        /// Gets or sets how to trim characters that do not fit into the cell.
        /// </summary>
        [
        DefaultValue(StringTrimming.None),
        Description("Gets or sets how to trim characters that do not fit into the cell."),
        ]
        public StringTrimming StringTrim
        {
            get { return trimming; }
            set { trimming = value; }
        }


        /// <summary>
        /// Formats the object to a string.
        /// </summary>
        public string Format(object obj)
        {
            return obj.ToString();
        }

        /// <summary>
        /// Parses the specified string to the return value.
        /// </summary>
        public object Parse(string s)
        {
            return Convert.ToDateTime(s);
        }


        protected virtual FarPoint.Win.HorizontalAlignment ToHorizontalAlignment(CellHorizontalAlignment alignment)
        {
            switch (alignment)
            {
                case CellHorizontalAlignment.Left: return FarPoint.Win.HorizontalAlignment.Left;
                case CellHorizontalAlignment.Center: return FarPoint.Win.HorizontalAlignment.Center;
                case CellHorizontalAlignment.Right: return FarPoint.Win.HorizontalAlignment.Right;
                default: return FarPoint.Win.HorizontalAlignment.Center;
            }
        }

        protected virtual FarPoint.Win.VerticalAlignment ToVerticalAlignment(CellVerticalAlignment alignment)
        {
            switch (alignment)
            {
                case CellVerticalAlignment.Top: return FarPoint.Win.VerticalAlignment.Top;
                case CellVerticalAlignment.Center: return FarPoint.Win.VerticalAlignment.Center;
                case CellVerticalAlignment.Bottom: return FarPoint.Win.VerticalAlignment.Bottom;
                default: return FarPoint.Win.VerticalAlignment.Top;
            }
        }

        /// <summary>
        /// Gets the control used by the given cell type.
        /// </summary>
        public Control GetEditorControl(FarPoint.Win.Spread.Appearance appearance, float zoomFactor)
        {
            editBox = new MyDateTimePicker();

            if (appearance != null)
            {
                if (appearance.BackColor != Color.Transparent)
                    editBox.BackColor = appearance.BackColor;
                if (appearance.ForeColor != Color.Transparent)
                    editBox.ForeColor = appearance.ForeColor;

                Font f = appearance.Font;
                if (zoomFactor != 1.0f)
                {
                    float fs = appearance.Font.Size * zoomFactor;
                    f = new Font(appearance.Font.FontFamily, fs, appearance.Font.Style);
                }
                editBox.Font = f;

            }

            return editBox;
        }

        /// <summary>
        /// Gets the unformatted value in the editor control.
        /// </summary>
        public object GetEditorValue()
        {
            object retVal = null;

            if (editBox != null)
            {
                editBox.CustomFormat = "yyyy-MM-dd";
                editBox.Format = DateTimePickerFormat.Custom;
                retVal = editBox.Value.ToString("yyyy-MM-dd");
            }
            return retVal;
        }

        /// <summary>
        /// Sets the value of the editor control.
        /// </summary>
        public void SetEditorValue(object value)
        {
            if (editBox == null)
                return;

            if (value == null)
            {
                editBox.Text = null;
            }
            else
            {
                editBox.CustomFormat = "yyyy-MM-dd";
                editBox.Format = DateTimePickerFormat.Custom;
            }
            if (value != null)
            {
                if (!string.IsNullOrEmpty(value.ToString().Trim()))
                {
                    editBox.Text = value.ToString();
                }
                else
                {
                    editBox.Text = DateTime.Now.ToString();
                }
            }
            else
            {
                editBox.Text = DateTime.Now.ToString();
            }

        }

        /// <summary>
        /// Starts the editing of a cell.
        /// </summary>
        public void StartEditing(EventArgs e, bool selectAll, bool autoClip)
        {
        }

        /// <summary>
        /// Cancels the editing of a cell.
        /// </summary>
        public void CancelEditing()
        {
            FireEditingCanceled();
        }

        /// <summary>
        /// Stops the editing of a cell.
        /// </summary>
        public bool StopEditing()
        {
            if (editBox != null)
                FireEditingStopped();
            return true;
        }

        /// <summary>
        /// Specifies if the given key has special meaning to the editor control.
        /// </summary>
        public bool IsReservedKey(KeyEventArgs e)
        {
            return false;
        }

        /// <summary>
        /// Specifies if the given cursor location has special meaning to the editor control.
        /// </summary>
        public object IsReservedLocation(Graphics g, int x, int y, Rectangle rc, FarPoint.Win.Spread.Appearance appearance, object value, float zoomFactor)
        {
            return null;
        }

        /// <summary>
        /// Gets the cursor reserved for this celltype.
        /// </summary>
        public System.Windows.Forms.Cursor GetReservedCursor(object o)
        {
            return null;
        }

        protected void GetTextRectangle(Graphics g, Rectangle r, Font f, FarPoint.Win.Spread.Appearance appearance, ref Rectangle rText, string paintString)
        {
            int textWidth = 0;
            int textHeight = 0;

            Rectangle drawRect = new Rectangle(r.X, r.Y, r.Width, r.Height);
            Font drawFont = f;

            if (paintString != null)
            {
                StringFormat fmt = new StringFormat();

                fmt.FormatFlags |= StringFormatFlags.NoWrap;

                fmt.Alignment = StringAlignment.Near;
                fmt.LineAlignment = StringAlignment.Center;

                int width = 0;
                switch (mtextOrientation)
                {
                    case TextOrientation.TextHorizontal:
                    case TextOrientation.TextHorizontalFlipped:
                        width = r.Width;
                        break;

                    case TextOrientation.TextVertical:
                    case TextOrientation.TextVerticalFlipped:
                    case TextOrientation.TextTopDown:
                        width = r.Height;
                        break;
                }

                SizeF textSize = g.MeasureString(paintString, drawFont, width, fmt);

                switch (mtextOrientation)
                {
                    case TextOrientation.TextHorizontal:
                    case TextOrientation.TextHorizontalFlipped:
                        textWidth = (int)Math.Ceiling(textSize.Width);
                        textHeight = (int)Math.Ceiling(textSize.Height);
                        break;

                    case TextOrientation.TextVertical:
                    case TextOrientation.TextVerticalFlipped:
                        textWidth = (int)Math.Ceiling(textSize.Height);
                        textHeight = (int)Math.Ceiling(textSize.Width);
                        break;

                    case TextOrientation.TextTopDown:
                        textWidth = 0;
                        textHeight = 0;
                        for (int i = 0; i < paintString.Length; i++)
                        {
                            SizeF textSize2 = g.MeasureString(paintString[i].ToString(CultureInfo.InvariantCulture), drawFont);
                            textWidth = Math.Max(textWidth, (int)Math.Ceiling(textSize2.Width));
                            textHeight += (int)Math.Ceiling(textSize2.Height);
                        }
                        break;
                }
            }

            rText = new Rectangle(r.X, r.Y, textWidth, textHeight);


            rText = Rectangle.Intersect(r, rText);

        }

        public void PaintCell(Graphics g, Rectangle r, FarPoint.Win.Spread.Appearance appearance, object value, bool isSelected, bool isLocked, float zoomFactor)
        {
            string s = null;
            StringFormat sf = new StringFormat(/*StringFormatFlags.FitBlackBox*/);
            sf.FormatFlags |= StringFormatFlags.NoClip;
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            Rectangle rText = new Rectangle(r.X, r.Y, r.Width, r.Height);

            Color backColor = appearance.BackColor;
            Color foreColor = appearance.ForeColor;
            if (isSelected)
            {
                if (!appearance.SelectionBackColor.IsEmpty)
                    backColor = appearance.SelectionBackColor;
                if (!appearance.SelectionForeColor.IsEmpty)
                    foreColor = appearance.SelectionForeColor;
            }
            if (isLocked)
            {
                if (!appearance.LockBackColor.IsEmpty)
                    backColor = appearance.LockBackColor;
                if (!appearance.LockForeColor.IsEmpty)
                    foreColor = appearance.LockForeColor;
            }


            SolidBrush backBrush, foreBrush;
            GraphicsState state = g.Save();

            g.IntersectClip(r);

            if (value != null)
            {
                s = this.Format(value);
                s = s.Substring(0, 10);
            }

            sf.FormatFlags |= StringFormatFlags.NoWrap;

            sf.Trimming = trimming;
            if (appearance.Font == null)
                appearance.Font = new Font("System", 10);

            backBrush = new SolidBrush(backColor);
            g.FillRectangle(backBrush, r);
            backBrush.Dispose();

            if (s != null && s.Length > 0)
            {
                foreBrush = new SolidBrush(foreColor);

                Font f = (Font)appearance.Font;
                if (zoomFactor != 1.0f)
                {
                    float fs = f.Size * zoomFactor;
                    f = new Font(f.FontFamily, fs, f.Style);
                }

                GetTextRectangle(g, r, f, appearance, ref rText, s);

                switch (mtextOrientation)
                {
                    case TextOrientation.TextHorizontal:
                        g.DrawString(s, f, foreBrush, rText, sf);
                        break;

                    case TextOrientation.TextHorizontalFlipped:
                        g.TranslateTransform(rText.Width, rText.Height / 2);
                        g.RotateTransform(180);
                        g.DrawString(s, f, foreBrush, new Rectangle(-rText.X, -(rText.Y + 1 + (rText.Height / 2)), rText.Width, rText.Height), sf);
                        break;

                    case TextOrientation.TextVertical:
                        g.TranslateTransform(rText.Width / 2, 0);
                        g.RotateTransform(90);
                        g.DrawString(s, f, foreBrush, new Rectangle(rText.Y, -rText.X - (rText.Width / 2), r.Height, rText.Width), sf);
                        break;

                    case TextOrientation.TextVerticalFlipped:
                        g.TranslateTransform(rText.Width / 2, rText.Height);
                        g.RotateTransform(-90);
                        g.DrawString(s, f, foreBrush, new Rectangle(-rText.Y, rText.X - (r.Width / 2), r.Height, r.Width), sf);
                        break;

                    case TextOrientation.TextTopDown:
                        for (int i = 0; i < s.Length; i++)
                        {
                            SizeF textSize = g.MeasureString(s[i].ToString(CultureInfo.InvariantCulture), f);
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Near;
                            g.DrawString(s[i].ToString(CultureInfo.InvariantCulture), f, foreBrush, rText, sf);
                            rText.Y += (int)Math.Ceiling(textSize.Height);
                        }
                        break;
                }

                g.ResetTransform();

                foreBrush.Dispose();
                if (zoomFactor != 1.0f) f.Dispose();
            }
            g.Restore(state);
        }

        /// <summary>
        /// Gets the preferred size of the editor control.
        /// </summary>
        public Size GetPreferredSize(Graphics g, Size size, FarPoint.Win.Spread.Appearance appearance, object value, float zoomFactor)
        {
            string s = null;
            Font f = appearance.Font != null ? appearance.Font : new Font("System", 10.0F);
            StringFormat sf = new StringFormat();

            if (value != null)
                s = this.Format(value);

            sf.Trimming = trimming;
            sf.LineAlignment = valign;
            sf.Alignment = halign;

            if (zoomFactor != 1.0f)
            {
                float fs = f.Size * zoomFactor;
                f = new Font(f.FontFamily, fs, f.Style);
            }

            sf.FormatFlags |= StringFormatFlags.NoWrap;
            size = g.MeasureString(s, f, new Point(0, 0), sf).ToSize();

            if (zoomFactor != 1.0f) f.Dispose();

            return size;
        }

        /// <summary>
        /// Gets the preferred size of the editor control.
        /// </summary>
        public Size GetPreferredSize(Control editor)
        {
            DateTimePicker textBox = (DateTimePicker)editor;
            Graphics g = textBox.CreateGraphics();
            string text = textBox.Text;
            Font f = textBox.Font;
            SizeF s = g.MeasureString(text, f, 1000, StringFormat.GenericTypographic);

            return new Size((int)s.Width, (int)s.Height);
        }

        /// <summary>
        /// Specifies whether the cell can overflow into adjacent cells.
        /// </summary>
        public bool CanOverflow()
        {
            return true;
        }

        /// <summary>
        /// Specifies whether data from another cell can overflow into this cell 
        /// (whether this cell can be overflowed into].
        /// </summary>
        public bool CanBeOverflown()
        {
            return true;
        }

    }

    #endregion

    #region < weekInfo >
    /// <summary>
    /// 주차 정보 클래스
    /// </summary>
    public class WeekInfo
    {
        private DateTime curDateTime;
        private DateTime WeekStartDate;
        private DateTime WeekEndDate;
        private int WeekNumber;

        /// <summary>
        /// 날짜를 8자리 문자로 세팅한다. 
        /// WeekInfo wi = new WeekInfo("20040101");
        /// wi.getWeekNumber();
        /// wi.getWeekStartDate();
        /// wi.getWeekEndDate();
        /// </summary>
        /// <param name="pCurDate">년월일 8 자리</param>
        public WeekInfo(string pCurDate)
        {
            int mYear = Convert.ToInt16(pCurDate.Substring(0, 4));
            int mMonth = Convert.ToInt16(pCurDate.Substring(4, 2));
            int mDay = Convert.ToInt16(pCurDate.Substring(6, 2));

            curDateTime = new DateTime(mYear, mMonth, mDay);

            initDate();
        }
        /// <summary>
        /// 년도 4 자리와 년도의 원하는 주차를 입력
        /// WeekInfo wi = new WeekInfo("2004","2"); // 2004 년의 2 주차 
        /// wi.getWeekNumber();
        /// wi.getWeekStartDate();
        /// wi.getWeekEndDate();
        /// </summary>
        /// <param name="pDate">년도 문자 4자리</param>
        /// <param name="pWeekNumber">원하느 주차</param>
        public WeekInfo(string pYear, int pWeekNumber)
        {
            int mYear = Convert.ToInt16(pYear);
            int mMonth = 1;
            int mDay = 1;

            curDateTime = new DateTime(mYear, mMonth, mDay);
            initDate();
            if (pWeekNumber > 1)
            {
                // 재계산
                curDateTime = this.WeekEndDate.AddDays((pWeekNumber - 1) * 7 - 1);
                initDate();
            }
        }
        private void initDate()
        {
            int intDayNumber = curDateTime.DayOfYear;
            int intDayStartNumber = 0;

            switch (curDateTime.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    intDayStartNumber = intDayNumber;
                    WeekStartDate = curDateTime;
                    WeekEndDate = curDateTime.AddDays(6);
                    break;
                case DayOfWeek.Monday:
                    intDayStartNumber = intDayNumber - 1;
                    WeekStartDate = curDateTime.AddDays(-1);
                    WeekEndDate = curDateTime.AddDays(5);
                    break;
                case DayOfWeek.Tuesday:
                    intDayStartNumber = intDayNumber - 2;
                    WeekStartDate = curDateTime.AddDays(-2);
                    WeekEndDate = curDateTime.AddDays(4);
                    break;
                case DayOfWeek.Wednesday:
                    intDayStartNumber = intDayNumber - 3;
                    WeekStartDate = curDateTime.AddDays(-3);
                    WeekEndDate = curDateTime.AddDays(3);
                    break;
                case DayOfWeek.Thursday:
                    intDayStartNumber = intDayNumber - 4;
                    WeekStartDate = curDateTime.AddDays(-4);
                    WeekEndDate = curDateTime.AddDays(2);
                    break;
                case DayOfWeek.Friday:
                    intDayStartNumber = intDayNumber - 5;
                    WeekStartDate = curDateTime.AddDays(-5);
                    WeekEndDate = curDateTime.AddDays(1);
                    break;
                case DayOfWeek.Saturday:
                    intDayStartNumber = intDayNumber - 6;
                    WeekStartDate = curDateTime.AddDays(-6);
                    WeekEndDate = curDateTime;
                    break;
            }

            this.WeekNumber = intDayStartNumber / 7;

            if (WeekStartDate.Year > curDateTime.AddYears(-1).Year)
            {
                this.WeekNumber += 1;

                int intDivideWeekNumber = intDayStartNumber % 7;

                if (intDivideWeekNumber != 0)
                    this.WeekNumber += 1;

                if (curDateTime.Year == WeekEndDate.AddYears(-1).Year)
                {
                    WeekEndDate = WeekEndDate.AddDays((-1) * WeekEndDate.DayOfYear);
                }
            }
            else
            {
                this.WeekNumber = 1;
                intDayStartNumber = (-1) * intDayStartNumber + 1;
                WeekStartDate = WeekStartDate.AddDays(intDayStartNumber);
            }
        }
        /// <summary>
        /// 주차 정보
        /// </summary>
        /// <returns></returns>
        public int getWeekNumber()
        {
            return this.WeekNumber;
        }
        /// <summary>
        /// 주차의 시작날짜 8 자리(일요일)
        /// </summary>
        /// <returns>20040101</returns>
        public string getWeekStartDate()
        {
            string strDate;
            strDate = setZero(WeekStartDate.Year.ToString(), 4);
            strDate += setZero(WeekStartDate.Month.ToString(), 2);
            strDate += setZero(WeekStartDate.Day.ToString(), 2);
            return strDate;

        }
        /// <summary>
        /// 주차의 마지막 날짜 8 자리(토요일)
        /// </summary>
        /// <returns>20040103</returns>
        public string getWeekEndDate()
        {
            string strDate;
            strDate = setZero(WeekEndDate.Year.ToString(), 4);
            strDate += setZero(WeekEndDate.Month.ToString(), 2);
            strDate += setZero(WeekEndDate.Day.ToString(), 2);
            return strDate;
        }
        private string setZero(string pValue, int pCount)
        {
            if (pValue.Length == pCount)
            {
                return pValue;
            }
            else
            {
                return pValue.PadLeft(pCount, '0');
            }
        }
    }

    /// <summary>
    /// 월 주차 정보 클래스
    /// </summary>
    public class MonthWeekInfo
    {
        private DateTime curDateTime;
        private DateTime WeekStartDate;
        private DateTime WeekEndDate;
        private int WeekNumber;


        /// <summary>
        /// 년도 4자리와 월 2자리와 원하는 주차 입력
        /// </summary>
        /// <param name="pYear"></param>
        /// <param name="pMonth"></param>
        /// <param name="pWeekNo"></param>
        public MonthWeekInfo(string pYear, string pMonth, string pWeekNo)
        {
            WeekNumber = Convert.ToInt16(pWeekNo);

            int mYear = Convert.ToInt16(pYear);
            int mMonth = Convert.ToInt16(pMonth);

            curDateTime = new DateTime(mYear, mMonth, 1);
            initDate();
        }

        private void initDate()
        {
            int intDayStartNumber = 0;
            DateTime MonthEndDate;

            switch (curDateTime.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    intDayStartNumber = 1;
                    break;
                case DayOfWeek.Monday:
                    intDayStartNumber = 2;
                    break;
                case DayOfWeek.Tuesday:
                    intDayStartNumber = 3;
                    break;
                case DayOfWeek.Wednesday:
                    intDayStartNumber = 4;
                    break;
                case DayOfWeek.Thursday:
                    intDayStartNumber = 5;
                    break;
                case DayOfWeek.Friday:
                    intDayStartNumber = 6;
                    break;
                case DayOfWeek.Saturday:
                    intDayStartNumber = 7;
                    break;
            }

            if (WeekNumber == 1)
            {
                this.WeekStartDate = this.curDateTime;
                if (this.WeekStartDate.DayOfWeek == DayOfWeek.Sunday) this.WeekStartDate = this.WeekStartDate.AddDays(1);
            }
            else
            {
                this.WeekStartDate = this.curDateTime.AddDays((WeekNumber * 7) - (intDayStartNumber + 4));
            }

            this.WeekEndDate = this.WeekStartDate.AddDays(5);
            if (this.WeekStartDate.Month != this.WeekEndDate.Month)
            {
                this.WeekEndDate = new DateTime(this.WeekEndDate.Year, this.WeekEndDate.Month, 1);
                this.WeekEndDate = this.WeekEndDate.AddDays(-1);
                if (this.WeekEndDate.DayOfWeek == DayOfWeek.Sunday) this.WeekEndDate = this.WeekEndDate.AddDays(-1);
            }

            MonthEndDate = new DateTime(this.curDateTime.Year, this.curDateTime.Month + 1, 1);
            MonthEndDate = MonthEndDate.AddDays(-1);
            if (MonthEndDate.DayOfWeek == DayOfWeek.Sunday) MonthEndDate = MonthEndDate.AddDays(-1);
        }

        /// <summary>
        /// 주차 정보
        /// </summary>
        /// <returns></returns>
        public int getWeekNumber()
        {
            return this.WeekNumber;
        }
        /// <summary>
        /// 주차의 시작날짜 8 자리(일요일)
        /// </summary>
        /// <returns>20040101</returns>
        public string getWeekStartDate()
        {
            string strDate;
            strDate = setZero(WeekStartDate.Year.ToString(), 4);
            strDate += setZero(WeekStartDate.Month.ToString(), 2);
            strDate += setZero(WeekStartDate.Day.ToString(), 2);
            return strDate;

        }
        /// <summary>
        /// 주차의 마지막 날짜 8 자리(토요일)
        /// </summary>
        /// <returns>20040103</returns>
        public string getWeekEndDate()
        {
            string strDate;
            strDate = setZero(WeekEndDate.Year.ToString(), 4);
            strDate += setZero(WeekEndDate.Month.ToString(), 2);
            strDate += setZero(WeekEndDate.Day.ToString(), 2);
            return strDate;
        }
        private string setZero(string pValue, int pCount)
        {
            if (pValue.Length == pCount)
            {
                return pValue;
            }
            else
            {
                return pValue.PadLeft(pCount, '0');
            }
        }
    }

    #endregion

    #endregion

}
