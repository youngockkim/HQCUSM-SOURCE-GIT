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
    public partial class udcGroupTypeOper : UserControl, intCodeListControl
    {
        private char m_cond_c_step;
        private string m_cond_s_filter;
        private string m_cond_s_ext_factory;
        private string m_cond_s_group;

        private bool m_b_visible_desc = false;
        private bool b_empty_chk_group = false;
        private bool b_empty_chk_type = false;
        private bool b_empty_chk_oper = false;

        //private int m_SelectedSubItemIndex = 0;
        //private int m_DisplaySubItemIndex = 1;
        //private int m_SelectedDescIndex = -1; 

        public udcGroupTypeOper()
        {
            InitializeComponent();
        }

        #region " Constant Definition "

        #endregion

        #region " Variable Definition "

        #endregion

        #region " Properties "

        public bool ValidationEmptyToGroup
        {
            get
            {
                return b_empty_chk_group;
            }
            set
            {
                b_empty_chk_group = value;
            }
        }

        public bool ValidationEmptyToType
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

        public bool ValidationEmptyToOper
        {
            get
            {
                return b_empty_chk_oper;
            }
            set
            {
                b_empty_chk_oper = value;
            }
        }

        public string ListCond_Group
        {
            get
            {
                if (m_cond_s_group == null) m_cond_s_group = "";
                return m_cond_s_group;
            }
            set
            {
                m_cond_s_group = value;
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
        public udcGCMCode GetGroup
        {
            get
            {
                return ctrlGroup;
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
        public udcOper GetOper
        {
            get
            {
                return ctrlOper;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string GroupText
        {
            get
            {
                return ctrlGroup.Text;
            }
            set
            {
                ctrlGroup.Text = value;
            }
        }
        public string GroupDisplayText
        {
            get
            {
                return ctrlGroup.DisplayText;
            }
            set
            {
                ctrlGroup.DisplayText = value;
            }
        }
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
        public string OperText
        {
            get
            {
                return ctrlOper.Text;
            }
            set
            {
                ctrlOper.Text = value;
            }
        }
        public string OperDisplayText
        {
            get
            {
                return ctrlOper.DisplayText;
            }
            set
            {
                ctrlOper.DisplayText = value;
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

        public int OperWidth
        {
            get
            {
                return ctrlOper.Width;
            }
            set
            {
                int i_width = value;
                pnlControl1.Width = ctrlType.Width + pnlMargin1.Width + i_width;
                ctrlOper.Width = i_width;
            }
        }

        public int GroupWidth
        {
            get
            {
                return ctrlGroup.Width;
            }
            set
            {
                ctrlGroup.Width = value;
            }
        }
       
        public int SelectedSubItemIndex
        {
            get
            {
                return ctrlOper.SelectedSubItemIndex;
            }
            set
            {
                ctrlType.SelectedSubItemIndex = value;
                ctrlGroup.SelectedSubItemIndex = value;
                ctrlOper.SelectedSubItemIndex = value;
            }
        }

        public int DisplaySubItemIndex
        {
            get
            {
                return ctrlOper.DisplaySubItemIndex;
            }
            set
            {
                ctrlType.DisplaySubItemIndex = value;
                ctrlGroup.DisplaySubItemIndex = value;
                ctrlOper.DisplaySubItemIndex = value;
            }
        }

        public int SelectedDescIndex
        {
            get
            {
                return ctrlOper.SelectedDescIndex;
            }
            set
            {
                ctrlType.SelectedDescIndex = value;
                ctrlGroup.SelectedDescIndex = value;
                ctrlOper.SelectedDescIndex = value;
            }
        }

        public int SearchSubItemIndex
        {
            get
            {
                return ctrlOper.SearchSubItemIndex;
            }
            set
            {
                ctrlType.SearchSubItemIndex = value;
                ctrlGroup.SearchSubItemIndex = value;
                ctrlOper.SearchSubItemIndex = value;
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

            ctrlGroup.Init();
            ctrlType.Init();
            ctrlOper.Init();

            DisplaySubItemIndex = 1;
            SelectedDescIndex = 1;
            SearchSubItemIndex = 0;
            SelectedSubItemIndex = 0;

            DisplayDesc();
        }

        public bool CheckValue()
        {
            if (MPCF.CheckValue(ctrlGroup, 1) == true && 
                MPCF.CheckValue(ctrlType, 1) == true &&
                MPCF.CheckValue(ctrlOper, 1) == true) return true;
            else return false;
        }

        public void ClearField()
        {
            ctrlOper.ClearField();
            ctrlType.ClearField();
            ctrlGroup.ClearField();
            txtDesc1.Text = "";
        }

        private void DisplayDesc()
        {
            if (MPCF.Trim(ctrlGroup.Text) != "" &&
                MPCF.Trim(ctrlType.Text) != "" &&
                MPCF.Trim(ctrlOper.Text) != "")
            {
                txtDesc1.Text = string.Format("{0}/{1}/{2}", MPCF.Trim(ctrlGroup.DescText), MPCF.Trim(ctrlType.DescText), MPCF.Trim(ctrlOper.DescText));
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
                    if (((udcGCMCode)sender).Name.ToString().Equals("ctrlGroup"))
                    {
                        if (ctrlGroup.DisplayText.Length == 0)
                        {
                            ctrlGroup.ClearField();
                        }
                        ctrlOper.ClearField();
                        ctrlType.ClearField();

                        bChk = true;
                    }
                }
                else if (sender is udcGCMCode)
                {
                    if (((udcGCMCode)sender).Name.ToString().Equals("ctrlType"))
                    {
                        if (ctrlType.DisplayText.Length == 0)
                        {
                            ctrlType.ClearField();
                        }
                        ctrlOper.ClearField();

                        bChk = true;
                    }
                }
                else if (sender is udcOper)
                {
                    if (((udcOper)sender).Name.ToString().Equals("ctrlOper"))
                    {
                        if (ctrlOper.DisplayText.Length == 0)
                        {
                            ctrlOper.ClearField();
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
        //Group
        private MCCodeViewSelChangedHandler GroupSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler GroupSelectedItemChanged
        {
            add
            {
                GroupSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(GroupSelectedItemChangedEvent, value);
            }
            remove
            {
                GroupSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(GroupSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler GroupButtonPressAfterEvent;
        public event System.EventHandler GroupButtonPressAfter
        {
            add
            {
                GroupButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(GroupButtonPressAfterEvent, value);
            }
            remove
            {
                GroupButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(GroupButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler GroupTextKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler GroupTextKeyPress
        {
            add
            {
                GroupTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(GroupTextKeyPressEvent, value);
            }
            remove
            {
                GroupTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(GroupTextKeyPressEvent, value);
            }
        }

        private System.EventHandler GroupTextChangedEvent;
        public event System.EventHandler GroupTextChanged
        {
            add
            {
                GroupTextChangedEvent = (System.EventHandler)System.Delegate.Combine(GroupTextChangedEvent, value);
            }
            remove
            {
                GroupTextChangedEvent = (System.EventHandler)System.Delegate.Remove(GroupTextChangedEvent, value);
            }
        }

        private System.EventHandler GroupTextLostFocusEvent;
        public event System.EventHandler GroupTextLostFocus
        {
            add
            {
                GroupTextLostFocusEvent = (System.EventHandler)System.Delegate.Combine(GroupTextLostFocusEvent, value);
            }
            remove
            {
                GroupTextLostFocusEvent = (System.EventHandler)System.Delegate.Remove(GroupTextLostFocusEvent, value);
            }
        }

        private System.EventHandler GroupTextGotFocusEvent;
        public event System.EventHandler GroupTextGotFocus
        {
            add
            {
                GroupTextGotFocusEvent = (System.EventHandler)System.Delegate.Combine(GroupTextGotFocusEvent, value);
            }
            remove
            {
                GroupTextGotFocusEvent = (System.EventHandler)System.Delegate.Remove(GroupTextGotFocusEvent, value);
            }
        }
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

        private System.EventHandler TypeButtonPressEvent;
        public event System.EventHandler TypeButtonPress
        {
            add
            {
                TypeButtonPressEvent = (System.EventHandler)System.Delegate.Combine(TypeButtonPressEvent, value);
            }
            remove
            {
                TypeButtonPressEvent = (System.EventHandler)System.Delegate.Remove(TypeButtonPressEvent, value);
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
        //Oper
        private MCCodeViewSelChangedHandler OperSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler OperSelectedItemChanged
        {
            add
            {
                OperSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(OperSelectedItemChangedEvent, value);
            }
            remove
            {
                OperSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(OperSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler OperButtonPressEvent;
        public event System.EventHandler OperButtonPress
        {
            add
            {
                OperButtonPressEvent = (System.EventHandler)System.Delegate.Combine(OperButtonPressEvent, value);
            }
            remove
            {
                OperButtonPressEvent = (System.EventHandler)System.Delegate.Remove(OperButtonPressEvent, value);
            }
        }

        private System.EventHandler OperButtonPressAfterEvent;
        public event System.EventHandler OperButtonPressAfter
        {
            add
            {
                OperButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(OperButtonPressAfterEvent, value);
            }
            remove
            {
                OperButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(OperButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler OperTextKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler OperTextKeyPress
        {
            add
            {
                OperTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(OperTextKeyPressEvent, value);
            }
            remove
            {
                OperTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(OperTextKeyPressEvent, value);
            }
        }

        private System.EventHandler OperTextChangedEvent;
        public event System.EventHandler OperTextChanged
        {
            add
            {
                OperTextChangedEvent = (System.EventHandler)System.Delegate.Combine(OperTextChangedEvent, value);
            }
            remove
            {
                OperTextChangedEvent = (System.EventHandler)System.Delegate.Remove(OperTextChangedEvent, value);
            }
        }

        private System.EventHandler OperTextLostFocusEvent;
        public event System.EventHandler OperTextLostFocus
        {
            add
            {
                OperTextLostFocusEvent = (System.EventHandler)System.Delegate.Combine(OperTextLostFocusEvent, value);
            }
            remove
            {
                OperTextLostFocusEvent = (System.EventHandler)System.Delegate.Remove(OperTextLostFocusEvent, value);
            }
        }

        private System.EventHandler OperTextGotFocusEvent;
        public event System.EventHandler OperTextGotFocus
        {
            add
            {
                OperTextGotFocusEvent = (System.EventHandler)System.Delegate.Combine(OperTextGotFocusEvent, value);
            }
            remove
            {
                OperTextGotFocusEvent = (System.EventHandler)System.Delegate.Remove(OperTextGotFocusEvent, value);
            }
        }

        private void ctrlGroup_ButtonPressAfter(object sender, EventArgs e)
        {
            if (GroupButtonPressAfterEvent != null)
                GroupButtonPressAfterEvent(this, e);
        }

        private void ctrlGroup_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            CheckValue(sender, e);

            if (GroupSelectedItemChangedEvent != null)
                GroupSelectedItemChangedEvent(this, e);
        }

        private void ctrlGroup_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (GroupTextGotFocusEvent != null)
                GroupTextGotFocusEvent(this, e);
        }

        private void ctrlGroup_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (GroupTextKeyPressEvent != null)
                GroupTextKeyPressEvent(this, e);
        }

        private void ctrlGroup_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (GroupTextLostFocusEvent != null)
                GroupTextLostFocusEvent(this, e);
        }

        private void ctrlGroup_TextBoxTextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, null);

            if (GroupTextChangedEvent != null)
                GroupTextChangedEvent(this, e);
        }

        //Type
        private void ctrlType_ButtonPress(object sender, EventArgs e)
        {
            //if (b_empty_chk_MGrp)
            //{
            //    if (!GetMatGrp1.CheckValue())
            //    {
            //        return;
            //    }
            //}

            if (TypeButtonPressEvent != null)
                TypeButtonPressEvent(this, e);
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

        //Oper
        private void ctrlOper_ButtonPress(object sender, EventArgs e)
        {
            //if (b_empty_chk_shop)
            //{
            //    if (!GetType.CheckValue())
            //    {
            //        return;
            //        //
            //    }
            //}

            if (MPCF.CheckValue(ctrlGroup, 1) == false) return;
            if (MPCF.CheckValue(ctrlType, 1) == false) return;

            ctrlOper.ListCond_Step = '2';
            ctrlOper.ListCond_Group = MPCF.Trim(ctrlGroup.Text);
            ctrlOper.ListCond_Type = MPCF.Trim(ctrlType.Text);

            if (OperButtonPressEvent != null)
                OperButtonPressEvent(this, e);
        }

        private void ctrlOper_ButtonPressAfter(object sender, EventArgs e)
        {
            if (OperButtonPressAfterEvent != null)
                OperButtonPressAfterEvent(this, e);
        }

        private void ctrlOper_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            CheckValue(sender, e);

            if (OperSelectedItemChangedEvent != null)
                OperSelectedItemChangedEvent(this, e);
        }

        private void ctrlOper_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (OperTextGotFocusEvent != null)
                OperTextGotFocusEvent(this, e);
        }

        private void ctrlOper_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (OperTextKeyPressEvent != null)
                OperTextKeyPressEvent(this, e);
        }

        private void ctrlOper_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (OperTextLostFocusEvent != null)
                OperTextLostFocusEvent(this, e);
        }

        private void ctrlOper_TextBoxTextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, null);

            if (OperTextChangedEvent != null)
                OperTextChangedEvent(this, e);
        }
        
        #endregion

        #region " Event Definition "
        private void udcGroupTypeOper_FontChanged(object sender, EventArgs e)
        {
            ctrlGroup.Font = this.Font;
            ctrlType.Font = this.Font;
            ctrlOper.Font = this.Font;
        }

        #endregion
    }
}
