using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Miracom.UI;
using Miracom.CliFrx;

namespace Miracom.MESCore.Controls
{
    [DefaultEvent("SelectedItemChanged")]
    public partial class udcFlow : UserControl, intCodeListControl
    {

        private char m_cond_c_step;
        private string m_cond_s_mat_id;
        private int m_cond_i_mat_ver;
        private string m_cond_s_filter;
        private string m_cond_s_ext_factory;

        private bool b_refuse_event_exec = false;
        private bool b_add_empty_row_to_top = false;
        private bool b_add_empty_row_to_last = false;
        
        public udcFlow()
        {
            InitializeComponent();

            Init();
        }
        

        #region "Control Events"
        
        private MCCodeViewSelChangedHandler SelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler SelectedItemChanged
        {
            add
            {
                SelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(SelectedItemChangedEvent, value);
            }
            remove
            {
                SelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(SelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler ButtonPressEvent;
        public event System.EventHandler ButtonPress
        {
            add
            {
                ButtonPressEvent = (System.EventHandler)System.Delegate.Combine(ButtonPressEvent, value);
            }
            remove
            {
                ButtonPressEvent = (System.EventHandler)System.Delegate.Remove(ButtonPressEvent, value);
            }
        }

        private System.EventHandler ButtonPressAfterEvent;
        public event System.EventHandler ButtonPressAfter
        {
            add
            {
                ButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(ButtonPressAfterEvent, value);
            }
            remove
            {
                ButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(ButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler TextBoxKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler TextBoxKeyPress
        {
            add
            {
                TextBoxKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(TextBoxKeyPressEvent, value);
            }
            remove
            {
                TextBoxKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(TextBoxKeyPressEvent, value);
            }
        }

        private System.EventHandler TextBoxTextChangedEvent;
        public event System.EventHandler TextBoxTextChanged
        {
            add
            {
                TextBoxTextChangedEvent = (System.EventHandler)System.Delegate.Combine(TextBoxTextChangedEvent, value);
            }
            remove
            {
                TextBoxTextChangedEvent = (System.EventHandler)System.Delegate.Remove(TextBoxTextChangedEvent, value);
            }
        }

        private System.EventHandler TextBoxLostFocusEvent;
        public event System.EventHandler TextBoxLostFocus
        {
            add
            {
                TextBoxLostFocusEvent = (System.EventHandler)System.Delegate.Combine(TextBoxLostFocusEvent, value);
            }
            remove
            {
                TextBoxLostFocusEvent = (System.EventHandler)System.Delegate.Remove(TextBoxLostFocusEvent, value);
            }
        }

        private System.EventHandler TextBoxGotFocusEvent;
        public event System.EventHandler TextBoxGotFocus
        {
            add
            {
                TextBoxGotFocusEvent = (System.EventHandler)System.Delegate.Combine(TextBoxGotFocusEvent, value);
            }
            remove
            {
                TextBoxGotFocusEvent = (System.EventHandler)System.Delegate.Remove(TextBoxGotFocusEvent, value);
            }
        }

        private void cdvFlow_ButtonPress(object sender, EventArgs e)
        {
            if (ButtonPressEvent != null)
                ButtonPressEvent(this, e);

            if (b_refuse_event_exec == true)
            {
                b_refuse_event_exec = false;
                return;
            }

            WIPLIST.ViewFlowList(cdvFlow.GetListView, ListCond_Step, ListCond_MatID, ListCond_MatVersion, ListCond_Filter, null, ListCond_ExtFactory);
            if (b_add_empty_row_to_top == true)
            {
                cdvFlow.InsertEmptyRow(0, 1);
            }
            if (b_add_empty_row_to_last == true)
            {
                cdvFlow.AddEmptyRow(1);
            }

            if (ButtonPressAfterEvent != null)
                ButtonPressAfterEvent(this, e);
        }

        private void cdvFlow_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (SelectedItemChangedEvent != null)
                SelectedItemChangedEvent(this, e);
        }

        private void cdvFlow_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (TextBoxGotFocusEvent != null)
                TextBoxGotFocusEvent(this, e);
        }

        private void cdvFlow_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (TextBoxKeyPressEvent != null)
                TextBoxKeyPressEvent(this, e);
        }

        private void cdvFlow_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (TextBoxLostFocusEvent != null)
                TextBoxLostFocusEvent(this, e);
        }

        private void cdvFlow_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (TextBoxTextChangedEvent != null)
                TextBoxTextChangedEvent(this, e);
        }


        #endregion

        #region "Properties"

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RefuseEventExec
        {
            get
            {
                return b_refuse_event_exec;
            }
            set
            {
                b_refuse_event_exec = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ListViewItemCollection Items
        {
            get
            {
                return cdvFlow.Items;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ColumnHeaderCollection Columns
        {
            get
            {
                return cdvFlow.Columns;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem SelectedItem
        {
            get
            {
                return cdvFlow.SelectedItem;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPopup
        {
            get
            {
                return cdvFlow.IsPopup;
            }
            set
            {
                cdvFlow.IsPopup = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return cdvFlow.Text;
            }
            set
            {
                cdvFlow.Text = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DisplayText
        {
            get
            {
                return cdvFlow.DisplayText;
            }
            set
            {
                cdvFlow.DisplayText = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DescText
        {
            get
            {
                return cdvFlow.DescText;
            }
            set
            {
                cdvFlow.DescText = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView GetListView
        {
            get
            {
                return cdvFlow.GetListView;
            }
        }



        public new Color BackColor
        {
            get
            {
                return cdvFlow.BackColor;
            }
            set
            {
                cdvFlow.BackColor = value;
                lblFlow.BackColor = value;
            }
        }

        public Color LabelBackColor
        {
            get
            {
                return lblFlow.BackColor;
            }
            set
            {
                lblFlow.BackColor = value;
            }
        }

        public Color CodeViewBackColor
        {
            get
            {
                return cdvFlow.BackColor;
            }
            set
            {
                cdvFlow.BackColor = value;
            }
        }

        public int ButtonWidth
        {
            get
            {
                return cdvFlow.ButtonWidth;
            }
            set
            {
                cdvFlow.ButtonWidth = value;
            }
        }

        public int TextBoxWidth
        {
            get
            {
                return cdvFlow.TextBoxWidth;
            }
            set
            {
                cdvFlow.TextBoxWidth = value;
            }
        }

        public int LabelWidth
        {
            get
            {
                return lblFlow.Width;
            }
            set
            {
                lblFlow.Width = value;
                pnlLeft.Width = value;
            }
        }

        public int MaxLength
        {
            get
            {
                return cdvFlow.MaxLength;
            }
        }

        public string LabelText
        {
            get
            {
                return lblFlow.Text;
            }
            set
            {
                lblFlow.Text = value;
            }
        }



        public int SelectedSubItemIndex
        {
            get
            {
                return cdvFlow.SelectedSubItemIndex;
            }
            set
            {
                cdvFlow.SelectedSubItemIndex = value;
            }
        }

        public int DisplaySubItemIndex
        {
            get
            {
                return cdvFlow.DisplaySubItemIndex;
            }
            set
            {
                cdvFlow.DisplaySubItemIndex = value;
            }
        }

        public int SelectedDescIndex
        {
            get
            {
                return cdvFlow.SelectedDescIndex;
            }
            set
            {
                cdvFlow.SelectedDescIndex = value;
            }
        }

        public int SearchSubItemIndex
        {
            get
            {
                return cdvFlow.SearchSubItemIndex;
            }
            set
            {
                cdvFlow.SearchSubItemIndex = value;
            }
        }


        public bool ReadOnly
        {
            get
            {
                return cdvFlow.ReadOnly;
            }
            set
            {
                if (value == true)
                    cdvFlow.BackColor = this.BackColor;
                else
                    cdvFlow.BackColor = SystemColors.Window;
                cdvFlow.ReadOnly = value;
            }
        }

        public bool VisibleButton
        {
            get
            {
                return cdvFlow.VisibleButton;
            }
            set
            {
                cdvFlow.VisibleButton = value;
            }
        }

        public bool VisibleDescription
        {
            get
            {
                return cdvFlow.VisibleDescription;
            }
            set
            {
                cdvFlow.VisibleDescription = value;
            }
        }

        public bool VisibleColumnHeader
        {
            get
            {
                return cdvFlow.VisibleColumnHeader;
            }
            set
            {
                cdvFlow.VisibleColumnHeader = value;
            }
        }

        public bool AddEmptyRowToTop
        {
            get
            {
                return b_add_empty_row_to_top;
            }
            set
            {
                b_add_empty_row_to_top = value;
            }
        }

        public bool AddEmptyRowToLast
        {
            get
            {
                return b_add_empty_row_to_last;
            }
            set
            {
                b_add_empty_row_to_last = value;
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
        public string ListCond_MatID
        {
            get
            {
                if (m_cond_s_mat_id == null) m_cond_s_mat_id = "";
                return m_cond_s_mat_id;
            }
            set
            {
                m_cond_s_mat_id = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ListCond_MatVersion
        {
            get
            {
                return m_cond_i_mat_ver;
            }
            set
            {
                m_cond_i_mat_ver = value;
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

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font LabelFont
        {
            get
            {
                return lblFlow.Font;
            }
            set
            {
                lblFlow.Font = value;
            }
        }

#endregion

        private void udcFlow_FontChanged(object sender, EventArgs e)
        {
            cdvFlow.Font = this.Font;
        }
        
        public void Init()
        {
            m_cond_c_step = '1';
            m_cond_s_ext_factory = "";
            m_cond_s_mat_id = "";
            m_cond_i_mat_ver = 0;
            m_cond_s_filter = "";

            SelectedDescIndex = 1;
            SearchSubItemIndex = 0;

            cdvFlow.Init();
            MPCF.InitListView(cdvFlow.GetListView);
            cdvFlow.Columns.Add("Flow", 100, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvFlow.SelectedSubItemIndex = 0;
            cdvFlow.MaxLength = 20;
        }
        
        public bool CheckValue()
        {
            return MPCF.CheckValue(this.cdvFlow, 1);
        }

        public void ClearField()
        {
            cdvFlow.Text = "";
        }
        
    }
}
