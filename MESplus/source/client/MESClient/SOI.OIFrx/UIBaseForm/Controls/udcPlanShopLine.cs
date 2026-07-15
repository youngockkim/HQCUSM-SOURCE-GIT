using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Miracom.UI;
using Miracom.CliFrx;
using Miracom.MESCore;

namespace SOI.OIFrx
{
    public partial class udcPlantShopLine : UserControl, intCodeListControl
    {
        private char m_cond_c_step;
        private string m_cond_s_filter;
        private string m_cond_s_ext_factory;
        private string m_cond_s_plant;

        private bool m_b_visible_desc = false;
        private bool b_empty_chk_plan = false;
        private bool b_empty_chk_shop = false;
        private bool b_empty_chk_line = false;

        //private int m_SelectedSubItemIndex = 0;
        //private int m_DisplaySubItemIndex = 1;
        //private int m_SelectedDescIndex = -1; 

        public udcPlantShopLine()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        #endregion

        #region " Properties "

        public bool ValidationEmptyToPlan
        {
            get
            {
                return b_empty_chk_plan;
            }
            set
            {
                b_empty_chk_plan = value;
            }
        }

        public bool ValidationEmptyToShop
        {
            get
            {
                return b_empty_chk_shop;
            }
            set
            {
                b_empty_chk_shop = value;
            }
        }

        public bool ValidationEmptyToLine
        {
            get
            {
                return b_empty_chk_line;
            }
            set
            {
                b_empty_chk_line = value;
            }
        }

        public string ListCond_Plant
        {
            get
            {
                if (m_cond_s_plant == null) m_cond_s_plant = "";
                return m_cond_s_plant;
            }
            set
            {
                m_cond_s_plant = value;
            }
        }
        public char ListCond_Step
        {
            get
            {
                return m_cond_c_step;
            }
            set
            {
                m_cond_c_step = value;
            }
        }
        public string ListCond_ExtFactory
        {
            get
            {
                if (m_cond_s_ext_factory == null) m_cond_s_ext_factory = "";
                return m_cond_s_ext_factory;
            }
            set
            {
                m_cond_s_ext_factory = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Filter
        {
            get
            {
                if (m_cond_s_filter == null) m_cond_s_filter = "";
                return m_cond_s_filter;
            }
            set
            {
                m_cond_s_filter = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public udcGCMCode GetPlant
        {
            get
            {
                return ctrlPlant;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public udcShop GetShop
        {
            get
            {
                return ctrlShop;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public udcLine GetLine
        {
            get
            {
                return ctrlLine;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PlantText
        {
            get
            {
                return ctrlPlant.Text;
            }
            set
            {
                ctrlPlant.Text = value;
            }
        }
        public string PlantDisplayText
        {
            get
            {
                return ctrlPlant.DisplayText;
            }
            set
            {
                ctrlPlant.DisplayText = value;
            }
        }
        public string ShopText
        {
            get
            {
                return ctrlShop.Text;
            }
            set
            {
                ctrlShop.Text = value;
            }
        }
        public string ShopDisplayText
        {
            get
            {
                return ctrlShop.DisplayText;
            }
            set
            {
                ctrlShop.DisplayText = value;
            }
        }
        public string LineText
        {
            get
            {
                return ctrlLine.Text;
            }
            set
            {
                ctrlLine.Text = value;
            }
        }
        public string LineDisplayText
        {
            get
            {
                return ctrlLine.DisplayText;
            }
            set
            {
                ctrlLine.DisplayText = value;
            }
        }
        public string LabelText1
        {
            get
            {
                return lblLabel1.Text;
            }
            set
            {
                lblLabel1.Text = value;
            }
        }

        public int LabelWidth1
        {
            get
            {
                return lblLabel1.Width;
            }
            set
            {
                pnlLabel1.Width = value;
                lblLabel1.Width = value;
            }
        }

        public int ShopWidth
        {
            get
            {
                return ctrlShop.Width;
            }
            set
            {
                ctrlShop.Width = value;
            }
        }

        public int LineWidth
        {
            get
            {
                return ctrlLine.Width;
            }
            set
            {
                int i_width = value;
                pnlControl1.Width = ctrlShop.Width + pnlMargin1.Width + i_width;
                ctrlLine.Width = i_width;
            }
        }

        public int PlantWidth
        {
            get
            {
                return ctrlPlant.Width;
            }
            set
            {
                ctrlPlant.Width = value;
            }
        }
       
        public int SelectedSubItemIndex
        {
            get
            {
                return ctrlLine.SelectedSubItemIndex;
            }
            set
            {
                ctrlShop.SelectedSubItemIndex = value;
                ctrlPlant.SelectedSubItemIndex = value;
                ctrlLine.SelectedSubItemIndex = value;
            }
        }

        public int DisplaySubItemIndex
        {
            get
            {
                return ctrlLine.DisplaySubItemIndex;
            }
            set
            {
                ctrlShop.DisplaySubItemIndex = value;
                ctrlPlant.DisplaySubItemIndex = value;
                ctrlLine.DisplaySubItemIndex = value;
            }
        }

        public int SelectedDescIndex
        {
            get
            {
                return ctrlLine.SelectedDescIndex;
            }
            set
            {
                ctrlShop.SelectedDescIndex = value;
                ctrlPlant.SelectedDescIndex = value;
                ctrlLine.SelectedDescIndex = value;
            }
        }

        public int SearchSubItemIndex
        {
            get
            {
                return ctrlLine.SearchSubItemIndex;
            }
            set
            {
                ctrlShop.SearchSubItemIndex = value;
                ctrlPlant.SearchSubItemIndex = value;
                ctrlLine.SearchSubItemIndex = value;
            }
        }

        #endregion

        #region " Function Definition "
        public void Init()
        {
            m_cond_c_step = '1';
            m_cond_s_ext_factory = "";
            m_cond_s_filter = "";

            VisibleDesc = false;

            ctrlPlant.Init();
            ctrlShop.Init();
            ctrlLine.Init();

            DisplaySubItemIndex = 1;
            SelectedDescIndex = 1;
            SearchSubItemIndex = 0;
            SelectedSubItemIndex = 0;

            DisplayDesc();
        }

        public bool CheckValue()
        {
            if (MPCF.CheckValue(ctrlPlant, 1) == true && 
                MPCF.CheckValue(ctrlShop, 1) == true &&
                MPCF.CheckValue(ctrlLine, 1) == true) return true;
            else return false;
        }

        public void ClearField()
        {
            ctrlLine.ClearField();
            ctrlShop.ClearField();
            ctrlPlant.ClearField();
            txtDesc1.Text = "";
        }

        private void DisplayDesc()
        {
            if (MPCF.Trim(ctrlPlant.Text) != "" &&
                MPCF.Trim(ctrlShop.Text) != "" &&
                MPCF.Trim(ctrlLine.Text) != "")
            {
                txtDesc1.Text = string.Format("{0}/{1}/{2}", MPCF.Trim(ctrlPlant.DescText), MPCF.Trim(ctrlShop.DescText), MPCF.Trim(ctrlLine.DescText));
            }
        }

        public bool VisibleDesc
        {
            get
            {
                return m_b_visible_desc;
            }
            set
            {
                m_b_visible_desc = value;
                txtDesc1.Visible = value;

                if (m_b_visible_desc)
                {
                    txtDesc1.Dock = DockStyle.Fill;
                    pnlControl1.Dock = DockStyle.Left;
                }
                else
                {
                    txtDesc1.Width = 0;
                    txtDesc1.Dock = DockStyle.None;
                    pnlControl1.Dock = DockStyle.Fill;
                }
            }
        }

        private bool CheckValue(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            bool bChk = false;

            try
            {
                if (sender is udcGCMCode)
                {
                    if (((udcGCMCode)sender).Name.ToString().Equals("ctrlPlant"))
                    {
                        if (ctrlPlant.DisplayText.Length == 0)
                        {
                            ctrlPlant.ClearField();
                        }
                        ctrlLine.ClearField();
                        ctrlShop.ClearField();

                        bChk = true;
                    }
                }
                else if (sender is udcShop)
                {
                    if (((udcShop)sender).Name.ToString().Equals("ctrlShop"))
                    {
                        if (ctrlShop.DisplayText.Length == 0)
                        {
                            ctrlShop.ClearField();
                        }
                        ctrlLine.ClearField();

                        bChk = true;
                    }
                }
                else if (sender is udcLine)
                {
                    if (((udcLine)sender).Name.ToString().Equals("ctrlLine"))
                    {
                        if (ctrlLine.DisplayText.Length == 0)
                        {
                            ctrlLine.ClearField();
                        }

                        bChk = true;
                    }
                }

                DisplayDesc();
                if (bChk)
                {
                    return true;
                }
            }
            catch { }
            finally { }

            return false;
        }
        #endregion

        #region " Form Event Definition "

        #endregion

        #region " Main Button Event "

        #endregion

        #region " Main Control Event "
        //Plant
        private MCCodeViewSelChangedHandler PlantSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler PlantSelectedItemChanged
        {
            add
            {
                PlantSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(PlantSelectedItemChangedEvent, value);
            }
            remove
            {
                PlantSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(PlantSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler PlantButtonPressAfterEvent;
        public event System.EventHandler PlantButtonPressAfter
        {
            add
            {
                PlantButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(PlantButtonPressAfterEvent, value);
            }
            remove
            {
                PlantButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(PlantButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler PlantTextKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler PlantTextKeyPress
        {
            add
            {
                PlantTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(PlantTextKeyPressEvent, value);
            }
            remove
            {
                PlantTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(PlantTextKeyPressEvent, value);
            }
        }

        private System.EventHandler PlantTextChangedEvent;
        public event System.EventHandler PlantTextChanged
        {
            add
            {
                PlantTextChangedEvent = (System.EventHandler)System.Delegate.Combine(PlantTextChangedEvent, value);
            }
            remove
            {
                PlantTextChangedEvent = (System.EventHandler)System.Delegate.Remove(PlantTextChangedEvent, value);
            }
        }

        private System.EventHandler PlantTextLostFocusEvent;
        public event System.EventHandler PlantTextLostFocus
        {
            add
            {
                PlantTextLostFocusEvent = (System.EventHandler)System.Delegate.Combine(PlantTextLostFocusEvent, value);
            }
            remove
            {
                PlantTextLostFocusEvent = (System.EventHandler)System.Delegate.Remove(PlantTextLostFocusEvent, value);
            }
        }

        private System.EventHandler PlantTextGotFocusEvent;
        public event System.EventHandler PlantTextGotFocus
        {
            add
            {
                PlantTextGotFocusEvent = (System.EventHandler)System.Delegate.Combine(PlantTextGotFocusEvent, value);
            }
            remove
            {
                PlantTextGotFocusEvent = (System.EventHandler)System.Delegate.Remove(PlantTextGotFocusEvent, value);
            }
        }
        //Shop
        private MCCodeViewSelChangedHandler ShopSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler ShopSelectedItemChanged
        {
            add
            {
                ShopSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(ShopSelectedItemChangedEvent, value);
            }
            remove
            {
                ShopSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(ShopSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler ShopButtonPressEvent;
        public event System.EventHandler ShopButtonPress
        {
            add
            {
                ShopButtonPressEvent = (System.EventHandler)System.Delegate.Combine(ShopButtonPressEvent, value);
            }
            remove
            {
                ShopButtonPressEvent = (System.EventHandler)System.Delegate.Remove(ShopButtonPressEvent, value);
            }
        }

        private System.EventHandler ShopButtonPressAfterEvent;
        public event System.EventHandler ShopButtonPressAfter
        {
            add
            {
                ShopButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(ShopButtonPressAfterEvent, value);
            }
            remove
            {
                ShopButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(ShopButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler ShopTextKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler ShopTextKeyPress
        {
            add
            {
                ShopTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(ShopTextKeyPressEvent, value);
            }
            remove
            {
                ShopTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(ShopTextKeyPressEvent, value);
            }
        }

        private System.EventHandler ShopTextChangedEvent;
        public event System.EventHandler ShopTextChanged
        {
            add
            {
                ShopTextChangedEvent = (System.EventHandler)System.Delegate.Combine(ShopTextChangedEvent, value);
            }
            remove
            {
                ShopTextChangedEvent = (System.EventHandler)System.Delegate.Remove(ShopTextChangedEvent, value);
            }
        }

        private System.EventHandler ShopTextLostFocusEvent;
        public event System.EventHandler ShopTextLostFocus
        {
            add
            {
                ShopTextLostFocusEvent = (System.EventHandler)System.Delegate.Combine(ShopTextLostFocusEvent, value);
            }
            remove
            {
                ShopTextLostFocusEvent = (System.EventHandler)System.Delegate.Remove(ShopTextLostFocusEvent, value);
            }
        }

        private System.EventHandler ShopTextGotFocusEvent;
        public event System.EventHandler ShopTextGotFocus
        {
            add
            {
                ShopTextGotFocusEvent = (System.EventHandler)System.Delegate.Combine(ShopTextGotFocusEvent, value);
            }
            remove
            {
                ShopTextGotFocusEvent = (System.EventHandler)System.Delegate.Remove(ShopTextGotFocusEvent, value);
            }
        }
        //Line
        private MCCodeViewSelChangedHandler LineSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler LineSelectedItemChanged
        {
            add
            {
                LineSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(LineSelectedItemChangedEvent, value);
            }
            remove
            {
                LineSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(LineSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler LineButtonPressEvent;
        public event System.EventHandler LineButtonPress
        {
            add
            {
                LineButtonPressEvent = (System.EventHandler)System.Delegate.Combine(LineButtonPressEvent, value);
            }
            remove
            {
                LineButtonPressEvent = (System.EventHandler)System.Delegate.Remove(LineButtonPressEvent, value);
            }
        }

        private System.EventHandler LineButtonPressAfterEvent;
        public event System.EventHandler LineButtonPressAfter
        {
            add
            {
                LineButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(LineButtonPressAfterEvent, value);
            }
            remove
            {
                LineButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(LineButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler LineTextKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler LineTextKeyPress
        {
            add
            {
                LineTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(LineTextKeyPressEvent, value);
            }
            remove
            {
                LineTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(LineTextKeyPressEvent, value);
            }
        }

        private System.EventHandler LineTextChangedEvent;
        public event System.EventHandler LineTextChanged
        {
            add
            {
                LineTextChangedEvent = (System.EventHandler)System.Delegate.Combine(LineTextChangedEvent, value);
            }
            remove
            {
                LineTextChangedEvent = (System.EventHandler)System.Delegate.Remove(LineTextChangedEvent, value);
            }
        }

        private System.EventHandler LineTextLostFocusEvent;
        public event System.EventHandler LineTextLostFocus
        {
            add
            {
                LineTextLostFocusEvent = (System.EventHandler)System.Delegate.Combine(LineTextLostFocusEvent, value);
            }
            remove
            {
                LineTextLostFocusEvent = (System.EventHandler)System.Delegate.Remove(LineTextLostFocusEvent, value);
            }
        }

        private System.EventHandler LineTextGotFocusEvent;
        public event System.EventHandler LineTextGotFocus
        {
            add
            {
                LineTextGotFocusEvent = (System.EventHandler)System.Delegate.Combine(LineTextGotFocusEvent, value);
            }
            remove
            {
                LineTextGotFocusEvent = (System.EventHandler)System.Delegate.Remove(LineTextGotFocusEvent, value);
            }
        }

        private void ctrlPlant_ButtonPressAfter(object sender, EventArgs e)
        {
            if (PlantButtonPressAfterEvent != null)
                PlantButtonPressAfterEvent(this, e);
        }

        private void ctrlPlant_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            CheckValue(sender, e);

            if (PlantSelectedItemChangedEvent != null)
                PlantSelectedItemChangedEvent(this, e);
        }

        private void ctrlPlant_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (PlantTextGotFocusEvent != null)
                PlantTextGotFocusEvent(this, e);
        }

        private void ctrlPlant_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (PlantTextKeyPressEvent != null)
                PlantTextKeyPressEvent(this, e);
        }

        private void ctrlPlant_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (PlantTextLostFocusEvent != null)
                PlantTextLostFocusEvent(this, e);
        }

        private void ctrlPlant_TextBoxTextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, null);

            if (PlantTextChangedEvent != null)
                PlantTextChangedEvent(this, e);
        }

        //Shop
        private void ctrlShop_ButtonPress(object sender, EventArgs e)
        {
            //if (b_empty_chk_MGrp)
            //{
            //    if (!GetMatGrp1.CheckValue())
            //    {
            //        return;
            //    }
            //}
            ctrlShop.ListCond_Filter = MPCF.Trim(ctrlPlant.Text);
            if (ShopButtonPressEvent != null)
                ShopButtonPressEvent(this, e);
        }

        private void ctrlShop_ButtonPressAfter(object sender, EventArgs e)
        {
            if (ShopButtonPressAfterEvent != null)
                ShopButtonPressAfterEvent(this, e);
        }

        private void ctrlShop_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            CheckValue(sender, e);

            if (ShopSelectedItemChangedEvent != null)
                ShopSelectedItemChangedEvent(this, e);
        }

        private void ctrlShop_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (ShopTextGotFocusEvent != null)
                ShopTextGotFocusEvent(this, e);
        }

        private void ctrlShop_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (ShopTextKeyPressEvent != null)
                ShopTextKeyPressEvent(this, e);
        }

        private void ctrlShop_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (ShopTextLostFocusEvent != null)
                ShopTextLostFocusEvent(this, e);
        }

        private void ctrlShop_TextBoxTextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, null);

            if (ShopTextChangedEvent != null)
                ShopTextChangedEvent(this, e);
        }

        //Line
        private void ctrlLine_ButtonPress(object sender, EventArgs e)
        {
            //if (b_empty_chk_shop)
            //{
            //    if (!GetShop.CheckValue())
            //    {
            //        return;
            //        //
            //    }
            //}
            ctrlLine.ListCond_Step = '2';
            ctrlLine.ListCond_Shop = MPCF.Trim(ctrlShop.Text);
            ctrlLine.ListCond_Plant = MPCF.Trim(ctrlPlant.Text);

            if (LineButtonPressEvent != null)
                LineButtonPressEvent(this, e);
        }

        private void ctrlLine_ButtonPressAfter(object sender, EventArgs e)
        {
            if (LineButtonPressAfterEvent != null)
                LineButtonPressAfterEvent(this, e);
        }

        private void ctrlLine_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            CheckValue(sender, e);

            if (LineSelectedItemChangedEvent != null)
                LineSelectedItemChangedEvent(this, e);
        }

        private void ctrlLine_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (LineTextGotFocusEvent != null)
                LineTextGotFocusEvent(this, e);
        }

        private void ctrlLine_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (LineTextKeyPressEvent != null)
                LineTextKeyPressEvent(this, e);
        }

        private void ctrlLine_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (LineTextLostFocusEvent != null)
                LineTextLostFocusEvent(this, e);
        }

        private void ctrlLine_TextBoxTextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, null);

            if (LineTextChangedEvent != null)
                LineTextChangedEvent(this, e);
        }
        
        #endregion

        #region " Event Definition "
        private void udcMGrpShopLine_FontChanged(object sender, EventArgs e)
        {
            ctrlPlant.Font = this.Font;
            ctrlShop.Font = this.Font;
            ctrlLine.Font = this.Font;
        }

        #endregion
    }
}
