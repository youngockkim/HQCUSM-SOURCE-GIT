using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SOI.OIFrx
{
    public class dtpControl : DateTimePicker
    {
        private bool _hasFocus = false;
        private Color _originalColor;
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                Invalidate();
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (this.BackColor != Color.Pink)
            {
                _originalColor = this.BackColor;
            }
            this.BackColor = Color.White;
            _hasFocus = true;
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            _hasFocus = false;
            this.BackColor = _originalColor;

            base.OnLostFocus(e);
        }

        protected override void WndProc(ref Message m)
        {
            if ((!_hasFocus) && (m.Msg == 20))
            {
                Graphics g = Graphics.FromHwnd(m.HWnd);
                g.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);
                g.Dispose();
                return;
            }
            base.WndProc(ref m);
        }

    }
}
