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
    public partial class udcStep : UserControl, intCodeListControl
    {
        
        private char m_cond_c_step;
        private string m_cond_s_mat_id;
        private int m_cond_i_mat_ver;
        private string m_cond_s_flow;
        private string m_cond_s_oper;
        private string m_cond_s_lot_id;
        private string m_cond_s_ext_factory;

        private bool b_refuse_event_exec = false;
        private bool b_add_empty_row_to_top = false;
        private bool b_add_empty_row_to_last = false;

        public udcStep()
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

        private void cdvStep_ButtonPress(object sender, EventArgs e)
        {
            if (ButtonPressEvent != null)
                ButtonPressEvent(this, e);

            if (b_refuse_event_exec == true)
            {
                b_refuse_event_exec = false;
                return;
            }

            //WIPLIST.ViewOperationList(cdvStep.GetListView, ListCond_Step, ListCond_MatID, ListCond_MatVersion, ListCond_Flow, ListCond_Filter, null, ListCond_ExtFactory);
            WIPLIST.ViewStepList(cdvStep.GetListView, ListCond_Step, ListCond_MatID, ListCond_MatVersion, ListCond_Flow, ListCond_Oper, ListCond_LotID, null, ListCond_ExtFactory);
            if (b_add_empty_row_to_top == true)
            {
                cdvStep.InsertEmptyRow(0, 1);
            }
            if (b_add_empty_row_to_last == true)
            {
                cdvStep.AddEmptyRow(1);
            }

            if (ButtonPressAfterEvent != null)
                ButtonPressAfterEvent(this, e);
        }

        private void cdvStep_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (SelectedItemChangedEvent != null)
                SelectedItemChangedEvent(this, e);
        }

        private void cdvStep_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (TextBoxGotFocusEvent != null)
                TextBoxGotFocusEvent(this, e);
        }

        private void cdvStep_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (TextBoxKeyPressEvent != null)
                TextBoxKeyPressEvent(this, e);
        }

        private void cdvStep_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (TextBoxLostFocusEvent != null)
                TextBoxLostFocusEvent(this, e);
        }

        private void cdvStep_TextBoxTextChanged(object sender, EventArgs e)
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
                return cdvStep.Items;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ColumnHeaderCollection Columns
        {
            get
            {
                return cdvStep.Columns;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem SelectedItem
        {
            get
            {
                return cdvStep.SelectedItem;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPopup
        {
            get
            {
                return cdvStep.IsPopup;
            }
            set
            {
                cdvStep.IsPopup = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return cdvStep.Text;
            }
            set
            {
                cdvStep.Text = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DisplayText
        {
            get
            {
                return cdvStep.DisplayText;
            }
            set
            {
                cdvStep.DisplayText = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DescText
        {
            get
            {
                return cdvStep.DescText;
            }
            set
            {
                cdvStep.DescText = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView GetListView
        {
            get
            {
                return cdvStep.GetListView;
            }
        }



        public new Color BackColor
        {
            get
            {
                return cdvStep.BackColor;
            }
            set
            {
                cdvStep.BackColor = value;
                lblStep.BackColor = value;
            }
        }

        public int ButtonWidth
        {
            get
            {
                return cdvStep.ButtonWidth;
            }
            set
            {
                cdvStep.ButtonWidth = value;
            }
        }

        public int TextBoxWidth
        {
            get
            {
                return cdvStep.TextBoxWidth;
            }
            set
            {
                cdvStep.TextBoxWidth = value;
            }
        }

        public int LabelWidth
        {
            get
            {
                return lblStep.Width;
            }
            set
            {
                lblStep.Width = value;
                pnlLeft.Width = value;
            }
        }

        public int MaxLength
        {
            get
            {
                return cdvStep.MaxLength;
            }
        }

        public string LabelText
        {
            get
            {
                return lblStep.Text;
            }
            set
            {
                lblStep.Text = value;
            }
        }




        public int SelectedSubItemIndex
        {
            get
            {
                return cdvStep.SelectedSubItemIndex;
            }
            set
            {
                cdvStep.SelectedSubItemIndex = value;
            }
        }

        public int DisplaySubItemIndex
        {
            get
            {
                return cdvStep.DisplaySubItemIndex;
            }
            set
            {
                cdvStep.DisplaySubItemIndex = value;
            }
        }

        public int SelectedDescIndex
        {
            get
            {
                return cdvStep.SelectedDescIndex;
            }
            set
            {
                cdvStep.SelectedDescIndex = value;
            }
        }

        public int SearchSubItemIndex
        {
            get
            {
                return cdvStep.SearchSubItemIndex;
            }
            set
            {
                cdvStep.SearchSubItemIndex = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return cdvStep.ReadOnly;
            }
            set
            {
                if (value == true)
                    cdvStep.BackColor = this.BackColor;
                else
                    cdvStep.BackColor = SystemColors.Window;
                cdvStep.ReadOnly = value;
            }
        }



        public bool VisibleButton
        {
            get
            {
                return cdvStep.VisibleButton;
            }
            set
            {
                cdvStep.VisibleButton = value;
            }
        }

        public bool VisibleDescription
        {
            get
            {
                return cdvStep.VisibleDescription;
            }
            set
            {
                cdvStep.VisibleDescription = value;
            }
        }

        public bool VisibleColumnHeader
        {
            get
            {
                return cdvStep.VisibleColumnHeader;
            }
            set
            {
                cdvStep.VisibleColumnHeader = value;
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
        public string ListCond_Flow
        {
            get
            {
                if (m_cond_s_flow == null) m_cond_s_flow = "";
                return m_cond_s_flow;
            }
            set
            {
                m_cond_s_flow = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Oper
        {
            get
            {
                if (m_cond_s_oper == null) m_cond_s_oper = "";
                return m_cond_s_oper;
            }
            set
            {
                m_cond_s_oper = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_LotID
        {
            get
            {
                if (m_cond_s_lot_id == null) m_cond_s_lot_id = "";
                return m_cond_s_lot_id;
            }
            set
            {
                m_cond_s_lot_id = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string ListCond_Filter
        //{
        //    get
        //    {
        //        if (m_cond_s_filter == null) m_cond_s_filter = "";
        //        return m_cond_s_filter;
        //    }
        //    set
        //    {
        //        m_cond_s_filter = value;
        //    }
        //}

        //[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font LabelFont
        {
            get
            {
                return lblStep.Font;
            }
            set
            {
                lblStep.Font = value;
            }
        }

#endregion

        private void udcStep_FontChanged(object sender, EventArgs e)
        {
            cdvStep.Font = this.Font;
        }
        
        public void Init()
        {
            m_cond_c_step = '1';
            m_cond_s_ext_factory = "";
            m_cond_s_mat_id = "";
            m_cond_i_mat_ver = 0;
            m_cond_s_flow = "";
            m_cond_s_oper = "";
            
            //m_cond_s_filter = "";

            SelectedDescIndex = 1;
            SearchSubItemIndex = 0;

            cdvStep.Init();
            MPCF.InitListView(cdvStep.GetListView);
            cdvStep.Columns.Add("Step", 100, HorizontalAlignment.Left);
            cdvStep.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvStep.SelectedSubItemIndex = 0;
            cdvStep.MaxLength = 10;
        }
        
        public bool CheckValue()
        {
            return MPCF.CheckValue(this.cdvStep, 1);
        }

        public void ClearField()
        {
            cdvStep.Text = "";
        }
    }
}
