using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SOI.OIFrx
{
    public partial class UcButton : Control
    {
        Image imgNormalBackGround = global::SOI.OIFrx.Properties.Resources.toggle_off;
        Image imgEnterBackGround = global::SOI.OIFrx.Properties.Resources.toggle_off;
        Image imgDisableBackGround = global::SOI.OIFrx.Properties.Resources.toggle_off;
        Image imgClickBackGround = global::SOI.OIFrx.Properties.Resources.toggle_on_green;
        Image image = null;
        StringAlignment sAlign = StringAlignment.Center;
        StringAlignment sLineAlign = StringAlignment.Center;
        string sShopId = string.Empty;
        string sLineId = string.Empty;
        bool bOnMouse = false;
        bool bOnMouseToggle = false;
        int iRMargin = 20;

        string strText = "UcButton";
        bool m_bOnMouseEnter = false;

        public UcButton()
        {
            this.Cursor = Cursors.Hand;
        }
        public string sShopCode
        {
            get { return sShopId; }
            set { sShopId = value; }
        }
        public string sLineCode
        {
            get { return sLineId; }
            set { sLineId = value; }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , DefaultValue(false)
        , Category("Mouse Flag")
        , Description("마우스 선택 여부를 설정")]
        public bool bMouseFlag
        {
            get { return bOnMouse; }
            set { bOnMouse = value; }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        , DefaultValue(false)
        , Category("Mouse Toggle Flag")
        , Description("마우스 클릭 여부를 설정")]
        public bool bMouseToggleFlag
        {
            get { return bOnMouseToggle; }
            set { bOnMouseToggle = value; }
        }

        public int iLabelRightMargin
        {
            get { return iRMargin; }
            set { iRMargin = value; }
        }

        public StringAlignment sAlignment
        {
            get
            {
                return sAlign;
            }
            set
            {
                sAlign = value;
                this.Invalidate();
            }
        }

        public StringAlignment sLineAlignment
        {
            get
            {
                return sLineAlign;
            }
            set
            {
                sLineAlign = value;
                this.Invalidate();
            }
        }

        public Image Image
        {
            get
            {
                return imgNormalBackGround;
            }
            set
            {
                imgNormalBackGround = value;
                this.Invalidate();
            }
        }

        public Image EnterImage
        {
            get
            {
                return imgEnterBackGround;
            }
            set
            {
                imgEnterBackGround = value;
                this.Invalidate();
            }
        }

        public Image DisableImage
        {
            get
            {
                return imgDisableBackGround;
            }
            set
            {
                imgDisableBackGround = value;
                this.Invalidate();
            }
        }

        public override string Text
        {
            get
            {
                return strText;
            }
            set
            {
                strText = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (this.Enabled == false)
                image = DisableImage;
            else
            {
                if (m_bOnMouseEnter == false)
                    image = Image;
                else
                    image = EnterImage;
            }

            Graphics g = pe.Graphics;
            g.DrawImage(image, new Rectangle(1, 1, this.Width - 3, this.Height - 3));
            Font fnt = new Font("Arial", 8F, FontStyle.Regular);
            AddLabel(g, new Rectangle(0, 0, this.Width - iRMargin, this.Height));
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            //m_bOnMouseEnter = true;
            //this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_bOnMouseEnter = false;
            this.Invalidate();
        }

        private void AddLabel(Graphics g, Rectangle r)
        {
            SolidBrush b = new SolidBrush(Color.Black);
            StringFormat sf = new StringFormat();
            sf.Alignment = sAlign;
            sf.LineAlignment = sLineAlign;
            Font f = this.Font;
            if (!bOnMouse) b = new SolidBrush(Color.White);
            g.DrawString(Text, f, b, r, sf);
        }
    }

}
