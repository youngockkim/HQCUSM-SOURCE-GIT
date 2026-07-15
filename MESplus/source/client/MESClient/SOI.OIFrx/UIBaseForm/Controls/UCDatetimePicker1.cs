using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SOI.OIFrx
{
    public partial class UCDatetimePicker1 : DateTimePicker
    {
        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);

            this.BackColor = System.Drawing.Color.FromArgb(20, 37, 60);            
            // 컨트롤 갱신
            this.Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            this.BackColor = System.Drawing.Color.FromArgb(20, 37, 60);
            this.Invalidate();
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled)
            {
                if (!Application.RenderWithVisualStyles)
                {
                    this.SetStyle(ControlStyles.UserPaint, false);
                }
                else
                {
                    this.SetStyle(ControlStyles.UserPaint, true);
                }
                this.BackColor = System.Drawing.Color.FromArgb(20, 37, 60);
            }
            else
            {
                if (!Application.RenderWithVisualStyles)
                {
                    this.SetStyle(ControlStyles.UserPaint, false);
                }
                else
                {
                    this.SetStyle(ControlStyles.UserPaint, true);
                }
                this.BackColor = System.Drawing.Color.FromArgb(20, 37, 60);
            }
            // 컨트롤 갱신
            this.Invalidate();
        }

        // DateTimePicker를 그리면서 색상 변경
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 콤보박스의 역삼각형 아이콘의 가로 : 17 높이 : 16
            Rectangle dropDownRectangle = new Rectangle(this.Width - 21, 2, 20, 25);

            // 콤보박스 렌더러
            ComboBoxRenderer.DrawDropDownButton(e.Graphics, dropDownRectangle, System.Windows.Forms.VisualStyles.ComboBoxState.Normal);

            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            //문자열 그림
            e.Graphics.DrawString(this.Text, this.Font, b, -1, 1);
            b.Dispose();
        }

    }
}
