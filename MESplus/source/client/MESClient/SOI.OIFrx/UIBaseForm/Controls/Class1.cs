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
    public class class1 : DateTimePicker
    {
        private SolidBrush _backBrush;

        public class1() : base()
        {
            BackColor = base.BackColor;
        }
        
        [Browsable(true),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
         public override Color BackColor {
         get { return base.BackColor; }
         set { base.BackColor = value;
             DestroyBrush();
             Invalidate(); 
         }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 20;
            if (m.Msg == WM_ERASEBKGND)
            {
                using (Graphics g = Graphics.FromHdc(m.WParam))
                {
                    if (_backBrush == null)
                    {
                        _backBrush = new SolidBrush(BackColor);
                    }
                    g.FillRectangle(_backBrush, ClientRectangle);
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        protected override void Dispose(bool disposing)
        {
            DestroyBrush();
            base.Dispose(disposing);
        }

        private void DestroyBrush()
        {
            if (_backBrush != null)
            {
                _backBrush.Dispose();
                _backBrush = null;
            }
        }
    }
}
