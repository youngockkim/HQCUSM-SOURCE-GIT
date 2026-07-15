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
    public partial class udcMat : UserControl, intCodeListControl
    {

        public udcMat()
        {
            InitializeComponent();

            Init();
        }

        #region " Variable Definition " 

        private char m_cond_c_step;
        private string m_cond_s_type;
        private string m_cond_s_cate;
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

        private void cdvMat_ButtonPress(object sender, EventArgs e)
        {
            if (ButtonPressEvent != null)
                ButtonPressEvent(this, e);

            if (b_refuse_event_exec == true)
            {
                b_refuse_event_exec = false;
                return;
            }

            MPOF.MFillData(cdvMat.GetListView, "WIP_Material_List", new string[] { MPCF.Trim(cdvMat.Text), " ", " ", " ", MPCF.Trim(ListCond_Type), MPCF.Trim(ListCond_Cate) });

            if (b_add_empty_row_to_top == true)
            {
                cdvMat.InsertEmptyRow(0, 1);
            }
            if (b_add_empty_row_to_last == true)
            {
                cdvMat.AddEmptyRow(1);
            }

            if (ButtonPressAfterEvent != null)
                ButtonPressAfterEvent(this, e);
        }

        private void cdvMat_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (SelectedItemChangedEvent != null)
                SelectedItemChangedEvent(this, e);
        }

        private void cdvMat_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (TextBoxGotFocusEvent != null)
                TextBoxGotFocusEvent(this, e);
        }

        private void cdvMat_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            cdvMat_ButtonPress(null, null);
        }

        private void cdvMat_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (TextBoxLostFocusEvent != null)
                TextBoxLostFocusEvent(this, e);
        }

        private void cdvMat_TextBoxTextChanged(object sender, EventArgs e)
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
                return cdvMat.Enabled;
            }
            set
            {
                cdvMat.Enabled = value;
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
                return cdvMat.Items;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ColumnHeaderCollection Columns
        {
            get
            {
                return cdvMat.Columns;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem SelectedItem
        {
            get
            {
                return cdvMat.SelectedItem;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPopup
        {
            get
            {
                return cdvMat.IsPopup;
            }
            set
            {
                cdvMat.IsPopup = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return cdvMat.Text;
            }
            set
            {
                cdvMat.Text = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DisplayText
        {
            get
            {
                return cdvMat.DisplayText;
            }
            set
            {
                cdvMat.DisplayText = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DescText
        {
            get
            {
                return cdvMat.DescText;
            }
            set
            {
                cdvMat.DescText = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView GetListView
        {
            get
            {
                return cdvMat.GetListView;
            }
        }


        public new Color BackColor
        {
            get
            {
                return cdvMat.BackColor;
            }
            set
            {
                cdvMat.BackColor = value;
                lblMat.BackColor = value;
            }
        }

        public int ButtonWidth
        {
            get
            {
                return cdvMat.ButtonWidth;
            }
            set
            {
                cdvMat.ButtonWidth = value;
            }
        }

        public int TextBoxWidth
        {
            get
            {
                return cdvMat.TextBoxWidth;
            }
            set
            {
                cdvMat.TextBoxWidth = value;
            }
        }

        public int LabelWidth
        {
            get
            {
                return lblMat.Width;
            }
            set
            {
                lblMat.Width = value;
                pnlLeft.Width = value;
            }
        }

        public int MaxLength
        {
            get
            {
                return cdvMat.MaxLength;
            }
            set
            {
                cdvMat.MaxLength = value;
            }
        }

        public string LabelText
        {
            get
            {
                return lblMat.Text;
            }
            set
            {
                lblMat.Text = value;
            }
        }




        public int SelectedSubItemIndex
        {
            get
            {
                return cdvMat.SelectedSubItemIndex;
            }
            set
            {
                cdvMat.SelectedSubItemIndex = value;
            }
        }

        public int DisplaySubItemIndex
        {
            get
            {
                return cdvMat.DisplaySubItemIndex;
            }
            set
            {
                cdvMat.DisplaySubItemIndex = value;
            }
        }

        public int SelectedDescIndex
        {
            get
            {
                return cdvMat.SelectedDescIndex;
            }
            set
            {
                cdvMat.SelectedDescIndex = value;
            }
        }

        public int SearchSubItemIndex
        {
            get
            {
                return cdvMat.SearchSubItemIndex;
            }
            set
            {
                cdvMat.SearchSubItemIndex = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return cdvMat.ReadOnly;
            }
            set
            {
                if (value == true)
                    cdvMat.BackColor = this.BackColor;
                else
                    cdvMat.BackColor = SystemColors.Window;
                cdvMat.ReadOnly = value;
            }
        }

        public bool VisibleButton
        {
            get
            {
                return cdvMat.VisibleButton;
            }
            set
            {
                cdvMat.VisibleButton = value;
            }
        }

        public bool VisibleDescription
        {
            get
            {
                return cdvMat.VisibleDescription;
            }
            set
            {
                cdvMat.VisibleDescription = value;
            }
        }

        public bool VisibleColumnHeader
        {
            get
            {
                return cdvMat.VisibleColumnHeader;
            }
            set
            {
                cdvMat.VisibleColumnHeader = value;
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
        public string ListCond_Type
        {
            get
            {
                if (m_cond_s_type == null) m_cond_s_type = "";
                return m_cond_s_type;
            }
            set
            {
                m_cond_s_type = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Cate
        {
            get
            {
                if (m_cond_s_cate == null) m_cond_s_cate = "";
                return m_cond_s_cate;
            }
            set
            {
                m_cond_s_cate = value;
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
                return lblMat.Font;
            }
            set
            {
                lblMat.Font = value;
            }
        }

        #endregion

        private void udcLine_FontChanged(object sender, EventArgs e)
        {
            cdvMat.Font = this.Font;
        }

        public void Init()
        {
            m_cond_c_step = '1';
            m_cond_s_ext_factory = "";
            m_cond_s_type = "";
            m_cond_s_cate = "";
            m_cond_s_filter = "";

            m_cond_c_line_type = ' ';
            m_cond_c_use_flag = ' ';

            DisplaySubItemIndex = 1;
            SelectedDescIndex = 1;
            SearchSubItemIndex = 0;
            SelectedSubItemIndex = 0;

            cdvMat.Init();
            MPCF.InitListView(cdvMat.GetListView);
            cdvMat.Columns.Add("Mat", 100, HorizontalAlignment.Left);
            cdvMat.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvMat.SelectedSubItemIndex = 0;
        }

        public bool CheckValue()
        {
            return MPCF.CheckValue(this.cdvMat, 1);
        }

        public void ClearField()
        {
            cdvMat.Text = "";
        }

        private void cdvMat_MouseClick(object sender, MouseEventArgs e)
        {
            cdvMat_ButtonPress(null, null);
        }

        private void cdvMat_MouseDown(object sender, MouseEventArgs e)
        {
            cdvMat_ButtonPress(null, null);
        }

        public void GetMaterialList()
        {
            MPOF.MFillData(cdvMat.GetListView, "WIP_Material_List", new string[] { " ", " ", " ", " ", MPCF.Trim(ListCond_Type), MPCF.Trim(ListCond_Cate) });
        }
    }
}
