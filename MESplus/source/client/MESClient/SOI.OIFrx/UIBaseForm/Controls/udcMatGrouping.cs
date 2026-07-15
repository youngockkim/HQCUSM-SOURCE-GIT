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
    public partial class udcMatGrouping : UserControl, intCodeListControl
    {
        private char m_cond_c_step;
        private string m_cond_s_filter;
        private string m_cond_s_ext_factory;
        private string m_cond_s_plant;

        private bool m_b_visible_desc = false;
        private bool b_empty_chk_type = false;
        private bool b_empty_chk_cate = false;
        private bool b_empty_chk_mat = false;
        private bool b_product_flag = false;

        //private int m_SelectedSubItemIndex = 0;
        //private int m_DisplaySubItemIndex = 1;
        //private int m_SelectedDescIndex = -1; 

        public udcMatGrouping()
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
                return b_empty_chk_type;
            }
            set
            {
                b_empty_chk_type = value;
            }
        }

        public bool ValidationEmptyToCate
        {
            get
            {
                return b_empty_chk_cate;
            }
            set
            {
                b_empty_chk_cate = value;
            }
        }

        public bool ValidationEmptyToMat
        {
            get
            {
                return b_empty_chk_mat;
            }
            set
            {
                b_empty_chk_mat = value;
            }
        }

        public string ListCond_Type
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

        //[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public udcGCMCode GetType
        //{
        //    get
        //    {
        //        return ctrlType;
        //    }
        //}

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public udcGCMCode GetCate
        {
            get
            {
                return ctrlCate;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public udcMat GetMat
        {
            get
            {
                return ctrlMat;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TypeText
        {
            get
            {
                return ctrlType.Text;
            }
            set
            {
                ctrlType.Text = value;
            }
        }
        public string TypeDisplayText
        {
            get
            {
                return ctrlType.DisplayText;
            }
            set
            {
                ctrlType.DisplayText = value;
            }
        }
        public string CateText
        {
            get
            {
                return ctrlCate.Text;
            }
            set
            {
                ctrlCate.Text = value;
            }
        }
        public string CateDisplayText
        {
            get
            {
                return ctrlCate.DisplayText;
            }
            set
            {
                ctrlCate.DisplayText = value;
            }
        }
        public string MatText
        {
            get
            {
                return ctrlMat.Text;
            }
            set
            {
                ctrlMat.Text = value;
            }
        }
        public string MatDisplayText
        {
            get
            {
                return ctrlMat.DisplayText;
            }
            set
            {
                ctrlMat.DisplayText = value;
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

        public int CateWidth
        {
            get
            {
                return ctrlCate.Width;
            }
            set
            {
                ctrlCate.Width = value;
            }
        }

        public int MatWidth
        {
            get
            {
                return ctrlMat.Width;
            }
            set
            {
                int i_width = value;
                pnlControl1.Width = ctrlCate.Width + pnlMargin1.Width + i_width;
                ctrlMat.Width = i_width;
            }
        }

        public int TypeWidth
        {
            get
            {
                return ctrlType.Width;
            }
            set
            {
                ctrlType.Width = value;
            }
        }
       
        public int SelectedSubItemIndex
        {
            get
            {
                return ctrlMat.SelectedSubItemIndex;
            }
            set
            {
                ctrlCate.SelectedSubItemIndex = value;
                ctrlType.SelectedSubItemIndex = value;
                ctrlMat.SelectedSubItemIndex = value;
            }
        }

        public int DisplaySubItemIndex
        {
            get
            {
                return ctrlMat.DisplaySubItemIndex;
            }
            set
            {
                ctrlCate.DisplaySubItemIndex = value;
                ctrlType.DisplaySubItemIndex = value;
                ctrlMat.DisplaySubItemIndex = value;
            }
        }

        public int SelectedDescIndex
        {
            get
            {
                return ctrlMat.SelectedDescIndex;
            }
            set
            {
                ctrlCate.SelectedDescIndex = value;
                ctrlType.SelectedDescIndex = value;
                ctrlMat.SelectedDescIndex = value;
            }
        }

        public int SearchSubItemIndex
        {
            get
            {
                return ctrlMat.SearchSubItemIndex;
            }
            set
            {
                ctrlCate.SearchSubItemIndex = value;
                ctrlType.SearchSubItemIndex = value;
                ctrlMat.SearchSubItemIndex = value;
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

            ctrlType.Init();
            ctrlCate.Init();
            ctrlMat.Init();

            DisplaySubItemIndex = 1;
            SelectedDescIndex = 1;
            SearchSubItemIndex = 0;
            SelectedSubItemIndex = 0;

            DisplayDesc();
        }

        public bool CheckValue()
        {
            if (MPCF.CheckValue(ctrlType, 1) == true && 
                MPCF.CheckValue(ctrlCate, 1) == true &&
                MPCF.CheckValue(ctrlMat, 1) == true) return true;
            else return false;
        }

        public void ClearField()
        {
            ctrlMat.ClearField();
            ctrlCate.ClearField();
            ctrlType.ClearField();
            txtDesc1.Text = "";
        }

        private void DisplayDesc()
        {
            if (MPCF.Trim(ctrlType.Text) != "" &&
                MPCF.Trim(ctrlCate.Text) != "" &&
                MPCF.Trim(ctrlMat.Text) != "")
            {
                txtDesc1.Text = string.Format("{0}/{1}/{2}", MPCF.Trim(ctrlType.DescText), MPCF.Trim(ctrlCate.DescText), MPCF.Trim(ctrlMat.DescText));
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
                    if (((udcGCMCode)sender).Name.ToString().Equals("ctrlType"))
                    {
                        if (ctrlType.DisplayText.Length == 0)
                        {
                            ctrlType.ClearField();
                        }
                        ctrlMat.ClearField();
                        ctrlCate.ClearField();

                        bChk = true;
                    }
                }
                else if (sender is udcGCMCode)
                {
                    if (((udcGCMCode)sender).Name.ToString().Equals("ctrlCate"))
                    {
                        if (ctrlCate.DisplayText.Length == 0)
                        {
                            ctrlCate.ClearField();
                        }
                        ctrlMat.ClearField();

                        bChk = true;
                    }
                }
                else if (sender is udcMat)
                {
                    if (((udcMat)sender).Name.ToString().Equals("ctrlMat"))
                    {
                        if (ctrlMat.DisplayText.Length == 0)
                        {
                            ctrlMat.ClearField();
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
        //Type
        private MCCodeViewSelChangedHandler TypeSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler TypeSelectedItemChanged
        {
            add
            {
                TypeSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(TypeSelectedItemChangedEvent, value);
            }
            remove
            {
                TypeSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(TypeSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler TypeButtonPressAfterEvent;
        public event System.EventHandler TypeButtonPressAfter
        {
            add
            {
                TypeButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(TypeButtonPressAfterEvent, value);
            }
            remove
            {
                TypeButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(TypeButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler TypeTextKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler TypeTextKeyPress
        {
            add
            {
                TypeTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(TypeTextKeyPressEvent, value);
            }
            remove
            {
                TypeTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(TypeTextKeyPressEvent, value);
            }
        }

        private System.EventHandler TypeTextChangedEvent;
        public event System.EventHandler TypeTextChanged
        {
            add
            {
                TypeTextChangedEvent = (System.EventHandler)System.Delegate.Combine(TypeTextChangedEvent, value);
            }
            remove
            {
                TypeTextChangedEvent = (System.EventHandler)System.Delegate.Remove(TypeTextChangedEvent, value);
            }
        }

        private System.EventHandler TypeTextLostFocusEvent;
        public event System.EventHandler TypeTextLostFocus
        {
            add
            {
                TypeTextLostFocusEvent = (System.EventHandler)System.Delegate.Combine(TypeTextLostFocusEvent, value);
            }
            remove
            {
                TypeTextLostFocusEvent = (System.EventHandler)System.Delegate.Remove(TypeTextLostFocusEvent, value);
            }
        }

        private System.EventHandler TypeTextGotFocusEvent;
        public event System.EventHandler TypeTextGotFocus
        {
            add
            {
                TypeTextGotFocusEvent = (System.EventHandler)System.Delegate.Combine(TypeTextGotFocusEvent, value);
            }
            remove
            {
                TypeTextGotFocusEvent = (System.EventHandler)System.Delegate.Remove(TypeTextGotFocusEvent, value);
            }
        }
        //Cate
        private MCCodeViewSelChangedHandler CateSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler CateSelectedItemChanged
        {
            add
            {
                CateSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(CateSelectedItemChangedEvent, value);
            }
            remove
            {
                CateSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(CateSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler CateButtonPressEvent;
        public event System.EventHandler CateButtonPress
        {
            add
            {
                CateButtonPressEvent = (System.EventHandler)System.Delegate.Combine(CateButtonPressEvent, value);
            }
            remove
            {
                CateButtonPressEvent = (System.EventHandler)System.Delegate.Remove(CateButtonPressEvent, value);
            }
        }

        private System.EventHandler CateButtonPressAfterEvent;
        public event System.EventHandler CateButtonPressAfter
        {
            add
            {
                CateButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(CateButtonPressAfterEvent, value);
            }
            remove
            {
                CateButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(CateButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler CateTextKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler CateTextKeyPress
        {
            add
            {
                CateTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(CateTextKeyPressEvent, value);
            }
            remove
            {
                CateTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(CateTextKeyPressEvent, value);
            }
        }

        private System.EventHandler CateTextChangedEvent;
        public event System.EventHandler CateTextChanged
        {
            add
            {
                CateTextChangedEvent = (System.EventHandler)System.Delegate.Combine(CateTextChangedEvent, value);
            }
            remove
            {
                CateTextChangedEvent = (System.EventHandler)System.Delegate.Remove(CateTextChangedEvent, value);
            }
        }

        private System.EventHandler CateTextLostFocusEvent;
        public event System.EventHandler CateTextLostFocus
        {
            add
            {
                CateTextLostFocusEvent = (System.EventHandler)System.Delegate.Combine(CateTextLostFocusEvent, value);
            }
            remove
            {
                CateTextLostFocusEvent = (System.EventHandler)System.Delegate.Remove(CateTextLostFocusEvent, value);
            }
        }

        private System.EventHandler CateTextGotFocusEvent;
        public event System.EventHandler CateTextGotFocus
        {
            add
            {
                CateTextGotFocusEvent = (System.EventHandler)System.Delegate.Combine(CateTextGotFocusEvent, value);
            }
            remove
            {
                CateTextGotFocusEvent = (System.EventHandler)System.Delegate.Remove(CateTextGotFocusEvent, value);
            }
        }
        //Mat
        private MCCodeViewSelChangedHandler MatSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler MatSelectedItemChanged
        {
            add
            {
                MatSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(MatSelectedItemChangedEvent, value);
            }
            remove
            {
                MatSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(MatSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler MatButtonPressEvent;
        public event System.EventHandler MatButtonPress
        {
            add
            {
                MatButtonPressEvent = (System.EventHandler)System.Delegate.Combine(MatButtonPressEvent, value);
            }
            remove
            {
                MatButtonPressEvent = (System.EventHandler)System.Delegate.Remove(MatButtonPressEvent, value);
            }
        }

        private System.EventHandler MatButtonPressAfterEvent;
        public event System.EventHandler MatButtonPressAfter
        {
            add
            {
                MatButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(MatButtonPressAfterEvent, value);
            }
            remove
            {
                MatButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(MatButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler MatTextKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler MatTextKeyPress
        {
            add
            {
                MatTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(MatTextKeyPressEvent, value);
            }
            remove
            {
                MatTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(MatTextKeyPressEvent, value);
            }
        }

        private System.EventHandler MatTextChangedEvent;
        public event System.EventHandler MatTextChanged
        {
            add
            {
                MatTextChangedEvent = (System.EventHandler)System.Delegate.Combine(MatTextChangedEvent, value);
            }
            remove
            {
                MatTextChangedEvent = (System.EventHandler)System.Delegate.Remove(MatTextChangedEvent, value);
            }
        }

        private System.EventHandler MatTextLostFocusEvent;
        public event System.EventHandler MatTextLostFocus
        {
            add
            {
                MatTextLostFocusEvent = (System.EventHandler)System.Delegate.Combine(MatTextLostFocusEvent, value);
            }
            remove
            {
                MatTextLostFocusEvent = (System.EventHandler)System.Delegate.Remove(MatTextLostFocusEvent, value);
            }
        }

        private System.EventHandler MatTextGotFocusEvent;
        public event System.EventHandler MatTextGotFocus
        {
            add
            {
                MatTextGotFocusEvent = (System.EventHandler)System.Delegate.Combine(MatTextGotFocusEvent, value);
            }
            remove
            {
                MatTextGotFocusEvent = (System.EventHandler)System.Delegate.Remove(MatTextGotFocusEvent, value);
            }
        }

        private void ctrlType_ButtonPressAfter(object sender, EventArgs e)
        {
            if (TypeButtonPressAfterEvent != null)
                TypeButtonPressAfterEvent(this, e);
        }

        private void ctrlType_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            CheckValue(sender, e);

            if (TypeSelectedItemChangedEvent != null)
                TypeSelectedItemChangedEvent(this, e);

            if (MPCF.Trim(e.SelectedItem.SubItems[2].Text).Equals("Y") == true)
                b_product_flag = true;
            else b_product_flag = false;
        }

        private void ctrlType_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (TypeTextGotFocusEvent != null)
                TypeTextGotFocusEvent(this, e);
        }

        private void ctrlType_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (TypeTextKeyPressEvent != null)
                TypeTextKeyPressEvent(this, e);
        }

        private void ctrlType_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (TypeTextLostFocusEvent != null)
                TypeTextLostFocusEvent(this, e);
        }

        private void ctrlType_TextBoxTextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, null);

            if (TypeTextChangedEvent != null)
                TypeTextChangedEvent(this, e);
        }

        //Cate
        private void ctrlCate_ButtonBeforePress(object sender, EventArgs e)
        {
            if (b_product_flag == true) ctrlCate.Custom_TableName = MOGV.MP_GCM_CMAT_CATE_TYPE;
            else ctrlCate.Custom_TableName = MOGV.MP_GCM_CMAT_CATE_CODE;
        }

        private void ctrlCate_ButtonPress(object sender, EventArgs e)
        {
            //if (b_empty_chk_MGrp)
            //{
            //    if (!GetMatGrp1.CheckValue())
            //    {
            //        return;
            //    }
            //}
            if (CateButtonPressEvent != null)
                CateButtonPressEvent(this, e);
        }

        private void ctrlCate_ButtonPressAfter(object sender, EventArgs e)
        {
            if (CateButtonPressAfterEvent != null)
                CateButtonPressAfterEvent(this, e);
        }

        private void ctrlCate_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            CheckValue(sender, e);

            if (CateSelectedItemChangedEvent != null)
                CateSelectedItemChangedEvent(this, e);
        }

        private void ctrlCate_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (CateTextGotFocusEvent != null)
                CateTextGotFocusEvent(this, e);
        }

        private void ctrlCate_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (CateTextKeyPressEvent != null)
                CateTextKeyPressEvent(this, e);
        }

        private void ctrlCate_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (CateTextLostFocusEvent != null)
                CateTextLostFocusEvent(this, e);
        }

        private void ctrlCate_TextBoxTextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, null);

            if (CateTextChangedEvent != null)
                CateTextChangedEvent(this, e);
        }

        //Mat
        private void ctrlMat_ButtonPress(object sender, EventArgs e)
        {
            //if (b_empty_chk_cate)
            //{
            //    if (!GetCate.CheckValue())
            //    {
            //        return;
            //        //
            //    }
            //}
            ctrlMat.ListCond_Step = '2';
            ctrlMat.ListCond_Type = MPCF.Trim(ctrlType.Text);
            ctrlMat.ListCond_Cate = MPCF.Trim(ctrlCate.Text);

            if (MatButtonPressEvent != null)
                MatButtonPressEvent(this, e);
        }

        private void ctrlMat_ButtonPressAfter(object sender, EventArgs e)
        {
            if (MatButtonPressAfterEvent != null)
                MatButtonPressAfterEvent(this, e);
        }

        private void ctrlMat_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            CheckValue(sender, e);

            if (MatSelectedItemChangedEvent != null)
                MatSelectedItemChangedEvent(this, e);
        }

        private void ctrlMat_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (MatTextGotFocusEvent != null)
                MatTextGotFocusEvent(this, e);
        }

        private void ctrlMat_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (MatTextKeyPressEvent != null)
                MatTextKeyPressEvent(this, e);
        }

        private void ctrlMat_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (MatTextLostFocusEvent != null)
                MatTextLostFocusEvent(this, e);
        }

        private void ctrlMat_TextBoxTextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, null);

            if (MatTextChangedEvent != null)
                MatTextChangedEvent(this, e);
        }
        
        #endregion

        #region " Event Definition "
        private void udcMatGrouping_FontChanged(object sender, EventArgs e)
        {
            ctrlType.Font = this.Font;
            ctrlCate.Font = this.Font;
            ctrlMat.Font = this.Font;
        }

        #endregion
    }
}
