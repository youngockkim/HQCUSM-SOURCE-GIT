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
    public partial class udcResource : UserControl, intCodeListControl
    {

        private char m_cond_c_step;
        private string m_cond_s_resg_id;
        private string m_cond_s_res_type;
        private string m_cond_s_area;
        private string m_cond_s_subarea;
        private string m_cond_s_mat_id;
        private int m_cond_i_mat_ver;
        private string m_cond_s_flow;
        private string m_cond_s_oper;
        private string m_cond_s_filter;
        private bool m_cond_b_include_delete_resource;
        private string m_cond_s_ext_factory;

        private bool b_refuse_event_exec = false;
        private bool b_add_empty_row_to_top = false;
        private bool b_add_empty_row_to_last = false;

        public udcResource()
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

        private void cdvResID_ButtonPress(object sender, EventArgs e)
        {
            if (ButtonPressEvent != null)
                ButtonPressEvent(this, e);

            if (b_refuse_event_exec == true)
            {
                b_refuse_event_exec = false;
                return;
            }

            RASLIST.ViewResourceList(cdvResID.GetListView, 
                                     ListCond_Step, 
                                     ListCond_ResGroupID, 
                                     ListCond_ResType, 
                                     ListCond_Area, 
                                     ListCond_SubArea, 
                                     ListCond_MatID, 
                                     ListCond_MatVersion, 
                                     ListCond_Flow, 
                                     ListCond_Oper, 
                                     ' ',
                                     ListCond_Filter,
                                     ListCond_IncludeDeleteResource,
                                     null, 
                                     ListCond_ExtFactory);

            if (b_add_empty_row_to_top == true)
            {
                cdvResID.InsertEmptyRow(0, 1);
            }
            if (b_add_empty_row_to_last == true)
            {
                cdvResID.AddEmptyRow(1);
            }

            if (ButtonPressAfterEvent != null)
                ButtonPressAfterEvent(this, e);
        }

        private void cdvResID_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (SelectedItemChangedEvent != null)
                SelectedItemChangedEvent(this, e);
        }

        private void cdvResID_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (TextBoxGotFocusEvent != null)
                TextBoxGotFocusEvent(this, e);
        }

        private void cdvResID_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (TextBoxKeyPressEvent != null)
                TextBoxKeyPressEvent(this, e);
        }

        private void cdvResID_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (TextBoxLostFocusEvent != null)
                TextBoxLostFocusEvent(this, e);
        }

        private void cdvResID_TextBoxTextChanged(object sender, EventArgs e)
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
                return cdvResID.Items;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ColumnHeaderCollection Columns
        {
            get
            {
                return cdvResID.Columns;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem SelectedItem
        {
            get
            {
                return cdvResID.SelectedItem;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPopup
        {
            get
            {
                return cdvResID.IsPopup;
            }
            set
            {
                cdvResID.IsPopup = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return cdvResID.Text;
            }
            set
            {
                cdvResID.Text = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DisplayText
        {
            get
            {
                return cdvResID.DisplayText;
            }
            set
            {
                cdvResID.DisplayText = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DescText
        {
            get
            {
                return cdvResID.DescText;
            }
            set
            {
                cdvResID.DescText = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView GetListView
        {
            get
            {
                return cdvResID.GetListView;
            }
        }



        public new Color BackColor
        {
            get
            {
                return cdvResID.BackColor;
            }
            set
            {
                cdvResID.BackColor = value;
                lblResID.BackColor = value;
            }
        }

        public int ButtonWidth
        {
            get
            {
                return cdvResID.ButtonWidth;
            }
            set
            {
                cdvResID.ButtonWidth = value;
            }
        }

        public int TextBoxWidth
        {
            get
            {
                return cdvResID.TextBoxWidth;
            }
            set
            {
                cdvResID.TextBoxWidth = value;
            }
        }

        public int LabelWidth
        {
            get
            {
                return lblResID.Width;
            }
            set
            {
                lblResID.Width = value;
                pnlLeft.Width = value;
            }
        }

        public int MaxLength
        {
            get
            {
                return cdvResID.MaxLength;
            }
        }

        public string LabelText
        {
            get
            {
                return lblResID.Text;
            }
            set
            {
                lblResID.Text = value;
            }
        }




        public int SelectedSubItemIndex
        {
            get
            {
                return cdvResID.SelectedSubItemIndex;
            }
            set
            {
                cdvResID.SelectedSubItemIndex = value;
            }
        }

        public int DisplaySubItemIndex
        {
            get
            {
                return cdvResID.DisplaySubItemIndex;
            }
            set
            {
                cdvResID.DisplaySubItemIndex = value;
            }
        }

        public int SelectedDescIndex
        {
            get
            {
                return cdvResID.SelectedDescIndex;
            }
            set
            {
                cdvResID.SelectedDescIndex = value;
            }
        }

        public int SearchSubItemIndex
        {
            get
            {
                return cdvResID.SearchSubItemIndex;
            }
            set
            {
                cdvResID.SearchSubItemIndex = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return cdvResID.ReadOnly;
            }
            set
            {
                if (value == true)
                    cdvResID.BackColor = this.BackColor;
                else
                    cdvResID.BackColor = SystemColors.Window;
                cdvResID.ReadOnly = value;
            }
        }



        public bool VisibleButton
        {
            get
            {
                return cdvResID.VisibleButton;
            }
            set
            {
                cdvResID.VisibleButton = value;
            }
        }

        public bool VisibleDescription
        {
            get
            {
                return cdvResID.VisibleDescription;
            }
            set
            {
                cdvResID.VisibleDescription = value;
            }
        }

        public bool VisibleColumnHeader
        {
            get
            {
                return cdvResID.VisibleColumnHeader;
            }
            set
            {
                cdvResID.VisibleColumnHeader = value;
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
        public bool ListCond_IncludeDeleteResource
        {
            get
            {
                return m_cond_b_include_delete_resource;
            }
            set
            {
                m_cond_b_include_delete_resource = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_ResGroupID
        {
            get
            {
                if (m_cond_s_resg_id == null) m_cond_s_resg_id = "";
                return m_cond_s_resg_id;
            }
            set
            {
                m_cond_s_resg_id = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_ResType
        {
            get
            {
                if (m_cond_s_res_type == null) m_cond_s_res_type = "";
                return m_cond_s_res_type;
            }
            set
            {
                m_cond_s_res_type = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Area
        {
            get
            {
                if (m_cond_s_area == null) m_cond_s_area = "";
                return m_cond_s_area;
            }
            set
            {
                m_cond_s_area = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_SubArea
        {
            get
            {
                if (m_cond_s_subarea == null) m_cond_s_subarea = "";
                return m_cond_s_subarea;
            }
            set
            {
                m_cond_s_subarea = value;
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
                return lblResID.Font;
            }
            set
            {
                lblResID.Font = value;
            }
        }

        #endregion

        private void udcResource_FontChanged(object sender, EventArgs e)
        {
            cdvResID.Font = this.Font;
        }

        public void Init()
        {
            m_cond_c_step = '1';
            m_cond_s_resg_id = "";
            m_cond_s_res_type = "";
            m_cond_s_area = "";
            m_cond_s_subarea = "";
            m_cond_s_mat_id = "";
            m_cond_i_mat_ver = 0;
            m_cond_s_flow = "";
            m_cond_s_oper = "";
            m_cond_s_filter = "";
            m_cond_b_include_delete_resource = false;
            m_cond_s_ext_factory = "";

            SelectedDescIndex = 1;
            SearchSubItemIndex = 0;

            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("Operation", 100, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            cdvResID.MaxLength = 20;
        }

        public bool CheckValue()
        {
            return MPCF.CheckValue(this.cdvResID, 1);
        }

        public void ClearField()
        {
            cdvResID.Text = "";
        }

        public void GetResourceList()
        {
            RASLIST.ViewResourceList(cdvResID.GetListView,
                                     ListCond_Step,
                                     ListCond_ResGroupID,
                                     ListCond_ResType,
                                     ListCond_Area,
                                     ListCond_SubArea,
                                     ListCond_MatID,
                                     ListCond_MatVersion,
                                     ListCond_Flow,
                                     ListCond_Oper,
                                     ' ',
                                     ListCond_Filter,
                                     ListCond_IncludeDeleteResource,
                                     null,
                                     ListCond_ExtFactory);
        }
    }
}
