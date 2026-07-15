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
    public partial class udcFlowAndSeq : UserControl, intCodeListControl
    {
        private char m_cond_c_step;
        private string m_cond_s_mat_id;
        private int m_cond_i_mat_version;
        private string m_cond_s_fillter;
        private string m_cond_s_ext_factory;

        public udcFlowAndSeq()
        {
            InitializeComponent();

            Init();
        }

        #region "Variables"

        private bool b_visible_description = false;
        private int i_description_index = -1;
        private bool b_refuse_event_exec = false;
        private bool b_add_empty_row_to_top = false;
        private bool b_add_empty_row_to_last = false;

        #endregion

        #region "Control Events"

        private MCCodeViewSelChangedHandler FlowSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler FlowSelectedItemChanged
        {
            add
            {
                FlowSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(FlowSelectedItemChangedEvent, value);
            }
            remove
            {
                FlowSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(FlowSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler FlowButtonPressEvent;
        public event System.EventHandler FlowButtonPress
        {
            add
            {
                FlowButtonPressEvent = (System.EventHandler)System.Delegate.Combine(FlowButtonPressEvent, value);
            }
            remove
            {
                FlowButtonPressEvent = (System.EventHandler)System.Delegate.Remove(FlowButtonPressEvent, value);
            }
        }

        private System.EventHandler FlowButtonPressAfterEvent;
        public event System.EventHandler FlowButtonPressAfter
        {
            add
            {
                FlowButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(FlowButtonPressAfterEvent, value);
            }
            remove
            {
                FlowButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(FlowButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler FlowTextKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler FlowTextKeyPress
        {
            add
            {
                FlowTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(FlowTextKeyPressEvent, value);
            }
            remove
            {
                FlowTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(FlowTextKeyPressEvent, value);
            }
        }

        private System.EventHandler FlowTextChangedEvent;
        public event System.EventHandler FlowTextChanged
        {
            add
            {
                FlowTextChangedEvent = (System.EventHandler)System.Delegate.Combine(FlowTextChangedEvent, value);
            }
            remove
            {
                FlowTextChangedEvent = (System.EventHandler)System.Delegate.Remove(FlowTextChangedEvent, value);
            }
        }

        private System.EventHandler FlowTextLostFocusEvent;
        public event System.EventHandler FlowTextLostFocus
        {
            add
            {
                FlowTextLostFocusEvent = (System.EventHandler)System.Delegate.Combine(FlowTextLostFocusEvent, value);
            }
            remove
            {
                FlowTextLostFocusEvent = (System.EventHandler)System.Delegate.Remove(FlowTextLostFocusEvent, value);
            }
        }

        private System.EventHandler FlowTextGotFocusEvent;
        public event System.EventHandler FlowTextGotFocus
        {
            add
            {
                FlowTextGotFocusEvent = (System.EventHandler)System.Delegate.Combine(FlowTextGotFocusEvent, value);
            }
            remove
            {
                FlowTextGotFocusEvent = (System.EventHandler)System.Delegate.Remove(FlowTextGotFocusEvent, value);
            }
        }

        private MCCodeViewSelChangedHandler SeqSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler SeqSelectedItemChanged
        {
            add
            {
                SeqSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(SeqSelectedItemChangedEvent, value);
            }
            remove
            {
                SeqSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(SeqSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler SeqButtonPressEvent;
        public event System.EventHandler SeqButtonPress
        {
            add
            {
                SeqButtonPressEvent = (System.EventHandler)System.Delegate.Combine(SeqButtonPressEvent, value);
            }
            remove
            {
                SeqButtonPressEvent = (System.EventHandler)System.Delegate.Remove(SeqButtonPressEvent, value);
            }
        }

        private System.EventHandler SeqButtonPressAfterEvent;
        public event System.EventHandler SeqButtonAfterPress
        {
            add
            {
                SeqButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(SeqButtonPressAfterEvent, value);
            }
            remove
            {
                SeqButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(SeqButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler SeqKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler SeqKeyPress
        {
            add
            {
                SeqKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(SeqKeyPressEvent, value);
            }
            remove
            {
                SeqKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(SeqKeyPressEvent, value);
            }
        }

        private System.EventHandler SeqChangedEvent;
        public event System.EventHandler SeqChanged
        {
            add
            {
                SeqChangedEvent = (System.EventHandler)System.Delegate.Combine(SeqChangedEvent, value);
            }
            remove
            {
                SeqChangedEvent = (System.EventHandler)System.Delegate.Remove(SeqChangedEvent, value);
            }
        }

        private System.EventHandler SeqLostFocusEvent;
        public event System.EventHandler SeqLostFocus
        {
            add
            {
                SeqLostFocusEvent = (System.EventHandler)System.Delegate.Combine(SeqLostFocusEvent, value);
            }
            remove
            {
                SeqLostFocusEvent = (System.EventHandler)System.Delegate.Remove(SeqLostFocusEvent, value);
            }
        }

        private System.EventHandler SeqGotFocusEvent;
        public event System.EventHandler SeqGotFocus
        {
            add
            {
                SeqGotFocusEvent = (System.EventHandler)System.Delegate.Combine(SeqGotFocusEvent, value);
            }
            remove
            {
                SeqGotFocusEvent = (System.EventHandler)System.Delegate.Remove(SeqGotFocusEvent, value);
            }
        }


        private void cdvFlow_ButtonPress(object sender, EventArgs e)
        {
            if (FlowButtonPressEvent != null)
                FlowButtonPressEvent(this, e);

            if (b_refuse_event_exec == true)
            {
                b_refuse_event_exec = false;
                return;
            }

            // 2010.12.07 이 로직은 필요 없을것으로 보임. 메세지 출력 형식도 스탠다드에 맞지 않음
            //if (ListCond_Step == '2')
            //{
            //    if (String.IsNullOrEmpty(ListCond_MatID) == true)
            //    {
            //        MessageBox.Show("Required material id.");
            //        return;
            //    }
            //    if (ListCond_MatVersion == 0)
            //    {
            //        MessageBox.Show("Required material version.");
            //        return;
            //    }
            //}

            WIPLIST.ViewFlowList(cdvFlow.GetListView, ListCond_Step, ListCond_MatID, ListCond_MatVersion, ListCond_Fillter, null, ListCond_ExtFactory);
            if (b_add_empty_row_to_top == true)
            {
                cdvFlow.InsertEmptyRow(0, 1);
            }
            if (b_add_empty_row_to_last == true)
            {
                cdvFlow.AddEmptyRow(1);
            }

            if (FlowButtonPressAfterEvent != null)
                FlowButtonPressAfterEvent(this, e);
        }

        private void cdvFlow_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (VisibleDescription == true)
            {
                if (i_description_index > -1)
                {
                    if (cdvFlow.Columns.Count > i_description_index)
                    {
                        txtDesc.Text = e.SelectedItem.SubItems[i_description_index].Text;
                    }
                    else
                    {
                        txtDesc.Text = cdvFlow.Text;
                    }
                }
            }

            if (ListCond_Step == '2')
            {
                cdvSeq.Text = e.SelectedItem.SubItems[1].Text;
            }

            if (FlowSelectedItemChangedEvent != null)
                FlowSelectedItemChangedEvent(this, e);
        }

        private void cdvFlow_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (FlowTextGotFocusEvent != null)
                FlowTextGotFocusEvent(this, e);
        }

        private void cdvFlow_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (FlowTextKeyPressEvent != null)
                FlowTextKeyPressEvent(this, e);
        }

        private void cdvFlow_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (FlowTextLostFocusEvent != null)
                FlowTextLostFocusEvent(this, e);
        }

        private void cdvFlow_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (FlowTextChangedEvent != null)
                FlowTextChangedEvent(this, e);

            if (MPCF.Trim(Text) == "")
            {
                Sequence = 0;
            }
        }


        private void cdvSeq_ButtonPress(object sender, EventArgs e)
        {
            if (SeqButtonPressEvent != null)
                SeqButtonPressEvent(this, e);

            if (b_refuse_event_exec == true)
            {
                b_refuse_event_exec = false;
                return;
            }

            WIPLIST.ViewFlowSequenceList(cdvSeq.GetListView, '1', ListCond_MatID, ListCond_MatVersion, Text, null, ListCond_ExtFactory);

            if (SeqButtonPressAfterEvent != null)
                SeqButtonPressAfterEvent(this, e);
        }

        private void cdvSeq_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (SeqSelectedItemChangedEvent != null)
                SeqSelectedItemChangedEvent(this, e);
        }

        private void cdvSeq_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (SeqGotFocusEvent != null)
                SeqGotFocusEvent(this, e);
        }

        private void cdvSeq_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (SeqKeyPressEvent != null)
                SeqKeyPressEvent(this, e);
        }

        private void cdvSeq_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (SeqLostFocusEvent != null)
                SeqLostFocusEvent(this, e);
        }

        private void cdvSeq_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (SeqChangedEvent != null)
                SeqChangedEvent(this, e);
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
        public ListView.ListViewItemCollection FlowItems
        {
            get
            {
                return cdvFlow.Items;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ColumnHeaderCollection FlowColumns
        {
            get
            {
                return cdvFlow.Columns;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem FlowSelectedItem
        {
            get
            {
                return cdvFlow.SelectedItem;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool FlowIsPopup
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
        public string FlowDisplayText
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
        public ListView FlowGetListView
        {
            get
            {
                return cdvFlow.GetListView;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ListViewItemCollection SeqItems
        {
            get
            {
                return cdvSeq.Items;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem SeqSelectedItem
        {
            get
            {
                return cdvSeq.SelectedItem;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SeqIsPopup
        {
            get
            {
                return cdvSeq.IsPopup;
            }
            set
            {
                cdvSeq.IsPopup = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Sequence
        {
            get
            {
                if (MPCF.Trim(cdvSeq.Text) == "") return 0;
                else return MPCF.ToInt(cdvSeq.Text);
            }
            set
            {
                if (value < 1) cdvSeq.Text = "";
                else cdvSeq.Text = value.ToString();
            }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView SeqGetListView
        {
            get
            {
                return cdvSeq.GetListView;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DescText
        {
            get
            {
                return txtDesc.Text;
            }
            set
            {
                txtDesc.Text = value;
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
                cdvSeq.BackColor = value;
             }
        }

        public int WidthButton
        {
            get
            {
                return cdvFlow.ButtonWidth;
            }
            set
            {
                cdvFlow.ButtonWidth = value;
                cdvSeq.ButtonWidth = value;
            }
        }

        public int WidthFlowAndSequence
        {
            get
            {
                return pnlLeft.Width - pnlLabel.Width;
            }
            set
            {
                if (VisibleDescription == false)
                {
                    this.Width = value + pnlLabel.Width;
                }
                else
                {
                    pnlLeft.Width = value + pnlLabel.Width;
                }
            }
        }

        public int WidthSequence
        {
            get
            {
                return pnlSeq.Width;
            }
            set
            {
                pnlSeq.Width = value;
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
                pnlLabel.Width = value;
            }
        }

        public int FlowMaxLength
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
                return i_description_index;
            }
            set
            {
                i_description_index = value;
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




        public bool VisibleFlowButton
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

        public bool VisibleSequenceButton
        {
            get
            {
                return cdvSeq.VisibleButton;
            }
            set
            {
                cdvSeq.VisibleButton = value;
            }
        }

        public bool VisibleDescription
        {
            get
            {
                return b_visible_description;
            }
            set
            {
                b_visible_description = value;
                pnlMid.Visible = value;

                if (value == false)
                {
                    i_description_index = -1;
                }
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
                cdvSeq.VisibleColumnHeader = value;
            }
        }

        public bool FlowReadOnly
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

        public bool SequenceReadOnly
        {
            get
            {
                return cdvSeq.ReadOnly;
            }
            set
            {
                if (value == true)
                    cdvSeq.BackColor = this.BackColor;
                else
                    cdvSeq.BackColor = SystemColors.Window;
                cdvSeq.ReadOnly = value;
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
                if (value == '1')
                {
                    if (cdvFlow.Columns.Count != 2)
                    {
                        cdvFlow.Init();
                        cdvFlow.Columns.Clear();
                        cdvFlow.Columns.Add("Flow", 100, HorizontalAlignment.Left);
                        cdvFlow.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                        cdvFlow.SelectedSubItemIndex = 0;
                    }

                    cdvSeq.Text = "";
                    cdvSeq.Enabled = false;
                    cdvSeq.BackColor = SystemColors.Control;
                }
                else if (value == '2')
                {
                    if (cdvFlow.Columns.Count != 3)
                    {
                        cdvFlow.Init();
                        cdvFlow.Columns.Clear();
                        cdvFlow.Columns.Add("Flow", 100, HorizontalAlignment.Left);
                        cdvFlow.Columns.Add("Sequence", 100, HorizontalAlignment.Left);
                        cdvFlow.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                        cdvFlow.SelectedSubItemIndex = 0;
                    }

                    cdvSeq.Enabled = true;
                    cdvSeq.BackColor = SystemColors.Window;
                }

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
                return m_cond_i_mat_version;
            }
            set
            {
                m_cond_i_mat_version = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Fillter
        {
            get
            {
                if (m_cond_s_fillter == null) m_cond_s_fillter = "";
                return m_cond_s_fillter;
            }
            set
            {
                m_cond_s_fillter = value;
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

        private void ucFlowAndSeq_FontChanged(object sender, EventArgs e)
        {
            cdvFlow.Font = this.Font;
            cdvSeq.Font = this.Font;
        }

        private void ucFlowAndSeq_Resize(object sender, EventArgs e)
        {
            if (VisibleDescription == false)
            {
                pnlLeft.Width = this.Width;
            }
        }

        public void Init()
        {

            m_cond_c_step = '2';
            m_cond_s_ext_factory = "";
            m_cond_s_mat_id = "";
            m_cond_i_mat_version = 0;
            m_cond_s_fillter = "";

            SelectedDescIndex = 2;
            SearchSubItemIndex = 0;

            cdvFlow.Init();
            MPCF.InitListView(cdvFlow.GetListView);
            cdvFlow.Columns.Add("Flow", 100, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Sequence", 100, HorizontalAlignment.Left);
            cdvFlow.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvFlow.SelectedSubItemIndex = 0;
            cdvFlow.MaxLength = 20;

            cdvSeq.Init();
            MPCF.InitListView(cdvSeq.GetListView);
            cdvSeq.Columns.Add("Sequence", 100, HorizontalAlignment.Left);
            cdvSeq.SelectedSubItemIndex = 0;
            cdvSeq.MaxLength = 6;
        }

        public void FlowFocus()
        {
            cdvFlow.Focus();
        }

        public void SequenceFocus()
        {
            cdvSeq.Focus();
        }

        public bool CheckValue()
        {
            if (MPCF.CheckValue(this.cdvFlow, 1) == false) return false;

            // Flow Seq 가 없을수 있으므로 체크하지 않음.
            //if (MPCF.CheckValue(this.cdvSeq, 2) == false) return false;

            return true;
        }

        public void ClearField()
        {
            cdvFlow.Text = "";
            cdvSeq.Text = "";
            txtDesc.Text = "";
        }
    }
}
