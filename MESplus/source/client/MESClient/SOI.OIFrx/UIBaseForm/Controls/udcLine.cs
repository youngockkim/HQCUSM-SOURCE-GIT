/*---------------------------------------------------------------------------------------------------*/
//
//  Program Id      : udcLine.cs
//  Creator         : YG SON
//  Create Date     : 2015.08.26
//  Description     : Line 목록
//  History         : 2015.08.26 - Create
//
/*---------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.UI;
using Miracom.CliFrx;
using Miracom.MESCore;

namespace SOI.OIFrx
{
    [DefaultEvent("SelectedItemChanged")]
    public partial class udcLine : UserControl, intCodeListControl
    {

        public udcLine()
        {
            InitializeComponent();

            Init();
        }

        #region " Variable Definition " 

        private char m_cond_c_step;
        private string m_cond_s_plant;
        private string m_cond_s_shop;
        private string m_cond_s_filter;
        private string m_cond_s_ext_factory;

        private char m_cond_c_use_flag;
        private char m_cond_c_line_type;

        private bool b_refuse_event_exec = false;
        private bool b_add_empty_row_to_top = false;
        private bool b_add_empty_row_to_last = false;

        #endregion

        #region " Control Events "

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

        private void cdvLine_ButtonPress(object sender, EventArgs e)
        {
            if (ButtonPressEvent != null)
                ButtonPressEvent(this, e);

            if (b_refuse_event_exec == true)
            {
                b_refuse_event_exec = false;
                return;
            }

            cdvLine.Init();
            MPCF.InitListView(cdvLine.GetListView);
            cdvLine.Columns.Add("Line", 100, HorizontalAlignment.Left);
            cdvLine.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvLine.SelectedSubItemIndex = 0;

            MPOF.MFillData(cdvLine.GetListView, "WIP_View_Line_List", new string[] { " ", " ", MPCF.Trim(ListCond_Shop), " ", MPCF.Trim(ListCond_Plant), " ", " " });

            if (b_add_empty_row_to_top == true)
            {
                cdvLine.InsertEmptyRow(0, 1);
            }
            if (b_add_empty_row_to_last == true)
            {
                cdvLine.AddEmptyRow(1);
            }

            if (ButtonPressAfterEvent != null)
                ButtonPressAfterEvent(this, e);
        }

        private void cdvLine_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (SelectedItemChangedEvent != null)
                SelectedItemChangedEvent(this, e);
        }

        private void cdvLine_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (TextBoxGotFocusEvent != null)
                TextBoxGotFocusEvent(this, e);
        }

        private void cdvLine_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            cdvLine_ButtonPress(null, null);
        }

        private void cdvLine_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (TextBoxLostFocusEvent != null)
                TextBoxLostFocusEvent(this, e);
        }

        private void cdvLine_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (TextBoxTextChangedEvent != null)
                TextBoxTextChangedEvent(this, e);
        }


        #endregion

        #region " Properties Definition "

        public new bool Enabled
        {
            get
            {
                return cdvLine.Enabled;
            }
            set
            {
                cdvLine.Enabled = value;
            }
        }

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
                return cdvLine.Items;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ColumnHeaderCollection Columns
        {
            get
            {
                return cdvLine.Columns;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem SelectedItem
        {
            get
            {
                return cdvLine.SelectedItem;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPopup
        {
            get
            {
                return cdvLine.IsPopup;
            }
            set
            {
                cdvLine.IsPopup = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return cdvLine.Text;
            }
            set
            {
                cdvLine.Text = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DisplayText
        {
            get
            {
                return cdvLine.DisplayText;
            }
            set
            {
                cdvLine.DisplayText = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DescText
        {
            get
            {
                return cdvLine.DescText;
            }
            set
            {
                cdvLine.DescText = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView GetListView
        {
            get
            {
                return cdvLine.GetListView;
            }
        }



        public new Color BackColor
        {
            get
            {
                return cdvLine.BackColor;
            }
            set
            {
                cdvLine.BackColor = value;
                lblLine.BackColor = value;
            }
        }

        public int ButtonWidth
        {
            get
            {
                return cdvLine.ButtonWidth;
            }
            set
            {
                cdvLine.ButtonWidth = value;
            }
        }

        public int TextBoxWidth
        {
            get
            {
                return cdvLine.TextBoxWidth;
            }
            set
            {
                cdvLine.TextBoxWidth = value;
            }
        }

        public int LabelWidth
        {
            get
            {
                return lblLine.Width;
            }
            set
            {
                lblLine.Width = value;
                pnlLeft.Width = value;
            }
        }

        public int MaxLength
        {
            get
            {
                return cdvLine.MaxLength;
            }
            set
            {
                cdvLine.MaxLength = value;
            }
        }

        public string LabelText
        {
            get
            {
                return lblLine.Text;
            }
            set
            {
                lblLine.Text = value;
            }
        }




        public int SelectedSubItemIndex
        {
            get
            {
                return cdvLine.SelectedSubItemIndex;
            }
            set
            {
                cdvLine.SelectedSubItemIndex = value;
            }
        }

        public int DisplaySubItemIndex
        {
            get
            {
                return cdvLine.DisplaySubItemIndex;
            }
            set
            {
                cdvLine.DisplaySubItemIndex = value;
            }
        }

        public int SelectedDescIndex
        {
            get
            {
                return cdvLine.SelectedDescIndex;
            }
            set
            {
                cdvLine.SelectedDescIndex = value;
            }
        }

        public int SearchSubItemIndex
        {
            get
            {
                return cdvLine.SearchSubItemIndex;
            }
            set
            {
                cdvLine.SearchSubItemIndex = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return cdvLine.ReadOnly;
            }
            set
            {
                if (value == true)
                    cdvLine.BackColor = this.BackColor;
                else
                    cdvLine.BackColor = SystemColors.Window;
                cdvLine.ReadOnly = value;
            }
        }

        public bool VisibleButton
        {
            get
            {
                return cdvLine.VisibleButton;
            }
            set
            {
                cdvLine.VisibleButton = value;
            }
        }

        public bool VisibleDescription
        {
            get
            {
                return cdvLine.VisibleDescription;
            }
            set
            {
                cdvLine.VisibleDescription = value;
            }
        }

        public bool VisibleColumnHeader
        {
            get
            {
                return cdvLine.VisibleColumnHeader;
            }
            set
            {
                cdvLine.VisibleColumnHeader = value;
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
        public string ListCond_Shop
        {
            get
            {
                if (m_cond_s_shop == null) m_cond_s_shop = "";
                return m_cond_s_shop;
            }
            set
            {
                m_cond_s_shop = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char ListCond_LineType
        {
            get
            {
                if (m_cond_c_line_type == ' ') m_cond_c_line_type = ' ';
                return m_cond_c_line_type;
            }
            set
            {
                m_cond_c_line_type = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char ListCond_UseFlag
        {
            get
            {
                if (m_cond_c_use_flag == ' ') m_cond_c_use_flag = ' ';
                return m_cond_c_use_flag;
            }
            set
            {
                m_cond_c_use_flag = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font LabelFont
        {
            get
            {
                return lblLine.Font;
            }
            set
            {
                lblLine.Font = value;
            }
        }

        #endregion

        private void udcLine_FontChanged(object sender, EventArgs e)
        {
            cdvLine.Font = this.Font;
        }

        public void Init()
        {
            m_cond_c_step = '1';
            m_cond_s_ext_factory = "";
            m_cond_s_shop = "";
            m_cond_s_filter = "";

            m_cond_c_line_type = ' ';
            m_cond_c_use_flag = ' ';

            DisplaySubItemIndex = 1;
            SelectedDescIndex = 1;
            SearchSubItemIndex = 0;
            SelectedSubItemIndex = 0;

            cdvLine.Init();
            MPCF.InitListView(cdvLine.GetListView);
            cdvLine.Columns.Add("Line", 100, HorizontalAlignment.Left);
            cdvLine.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvLine.SelectedSubItemIndex = 0;
        }

        public bool CheckValue()
        {
            return MPCF.CheckValue(this.cdvLine, 1);
        }

        public void ClearField()
        {
            cdvLine.Text = "";
            cdvLine.DescText = "";
            cdvLine.DisplayText = "";
        }

        private void cdvLine_MouseClick(object sender, MouseEventArgs e)
        {
            cdvLine_ButtonPress(null, null);
        }

        private void cdvLine_MouseDown(object sender, MouseEventArgs e)
        {
            cdvLine_ButtonPress(null, null);
        }

        public void GetLineList()
        {
            MPOF.MFillData(cdvLine.GetListView, "WIP_View_Line_List", new string[] { " ", " ", MPCF.Trim(ListCond_Shop), " ", " ", " ", " " });
        }
    }
}
