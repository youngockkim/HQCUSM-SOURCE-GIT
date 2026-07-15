using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Miracom.TRSCore;
using Miracom.UI;
using Miracom.CliFrx;
using Miracom.MESCore;

namespace SOI.OIFrx
{
    [DefaultEvent("SelectedItemChanged")]
    public partial class udcCustomCodeViewGCM : UserControl, intCodeListControl
    {
        private char m_cond_c_step;
        private string m_cond_s_filter;
        private string m_cond_s_ext_factory;
        private string m_cond_s_table_name;
        private string m_cond_s_module_name;
        private string m_cond_s_list_name;

        private string[] m_cond_list_key;
        private object[] m_cond_list_argument;

        private ArrayList m_cond_list_filter_name;
        private ArrayList m_cond_list_filter_value;

        private TRSNode m_cond_param_node;

        private bool b_refuse_event_exec = false;
        private bool b_add_empty_row_to_top = false;
        private bool b_add_empty_row_to_last = false;

        public udcCustomCodeViewGCM()
        {
            InitializeComponent();

            Init();
        }
        #region Properties

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font LabelFont
        {
            get
            {

                return this.lblLabel.Font;
            }
            set
            {
                this.lblLabel.Font = value;
            }
        }
        #endregion

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

        private void cdvData_ButtonPress(object sender, EventArgs e)
        {
            if (ButtonPressEvent != null)
                ButtonPressEvent(this, e);

            if (b_refuse_event_exec == true)
            {
                b_refuse_event_exec = false;
                return;
            }

            if (ListCond_ListName == "")
            {
                ViewGCMDataList_Ex(cdvData.GetListView, ListCond_Step, ListCond_TableName, ListCond_ListKey, ListCond_ArguList);
            }
            else
            {
                ViewList(cdvData.GetListView, ListCond_Step, -1, ListCond_ExtFactory, true, ListCond_ParamNode);
            }
            switch (ListCond_ListName)
            {
                default:
                    break;
            }

            if (b_add_empty_row_to_top == true)
            {
                cdvData.InsertEmptyRow(0, 1);
            }
            if (b_add_empty_row_to_last == true)
            {
                cdvData.AddEmptyRow(1);
            }

            if (ButtonPressAfterEvent != null)
                ButtonPressAfterEvent(this, e);
        }

        private void cdvData_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (SelectedItemChangedEvent != null)
                SelectedItemChangedEvent(this, e);
        }

        private void cdvData_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (TextBoxGotFocusEvent != null)
                TextBoxGotFocusEvent(this, e);
        }

        private void cdvData_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (TextBoxKeyPressEvent != null)
                TextBoxKeyPressEvent(this, e);
        }

        private void cdvData_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (TextBoxLostFocusEvent != null)
                TextBoxLostFocusEvent(this, e);
        }

        private void cdvData_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (TextBoxTextChangedEvent != null)
                TextBoxTextChangedEvent(this, e);
        }

        #endregion

        #region "Properties"

        public new bool Enabled
        {
            get
            {
                return cdvData.Enabled;
            }
            set
            {
                cdvData.Enabled = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Code_Text_ReadOnly
        {
            get
            {
                return cdvData.ReadOnly;
            }
            set
            {
                cdvData.ReadOnly = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color Code_Text_BackColor
        {
            get
            {
                return cdvData.BackColor;
            }
            set
            {
                cdvData.BackColor = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color Code_Text_ForeColor
        {
            get
            {
                return cdvData.ForeColor;
            }
            set
            {
                cdvData.ForeColor = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ListViewItemCollection Items
        {
            get
            {
                return cdvData.Items;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ColumnHeaderCollection Columns
        {
            get
            {
                return cdvData.Columns;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem SelectedItem
        {
            get
            {
                return cdvData.SelectedItem;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPopup
        {
            get
            {
                return cdvData.IsPopup;
            }
            set
            {
                cdvData.IsPopup = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return cdvData.Text;
            }
            set
            {
                cdvData.Text = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DisplayText
        {
            get
            {
                return cdvData.DisplayText;
            }
            set
            {
                cdvData.DisplayText = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DescText
        {
            get
            {
                return cdvData.DescText;
            }
            set
            {
                cdvData.DescText = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView GetListView
        {
            get
            {
                return cdvData.GetListView;
            }
        }

        public new Color BackColor
        {
            get
            {
                return cdvData.BackColor;
            }
            set
            {
                cdvData.BackColor = value;
                lblLabel.BackColor = value;
            }
        }

        public int ButtonWidth
        {
            get
            {
                return cdvData.ButtonWidth;
            }
            set
            {
                cdvData.ButtonWidth = value;
            }
        }

        public int TextBoxWidth
        {
            get
            {
                return cdvData.TextBoxWidth;
            }
            set
            {
                cdvData.TextBoxWidth = value;
            }
        }

        public int LabelWidth
        {
            get
            {
                return lblLabel.Width;
            }
            set
            {
                lblLabel.Width = value;
                pnlLeft.Width = value;
            }
        }

        public int MaxLength
        {
            get
            {
                return cdvData.MaxLength;
            }
            set
            {
                cdvData.MaxLength = value;
            }
        }

        public string LabelText
        {
            get
            {
                return lblLabel.Text;
            }
            set
            {
                lblLabel.Text = value;
            }
        }

        public int SelectedSubItemIndex
        {
            get
            {
                return cdvData.SelectedSubItemIndex;
            }
            set
            {
                cdvData.SelectedSubItemIndex = value;
            }
        }

        public int DisplaySubItemIndex
        {
            get
            {
                return cdvData.DisplaySubItemIndex;
            }
            set
            {
                cdvData.DisplaySubItemIndex = value;
            }
        }

        public int SelectedDescIndex
        {
            get
            {
                return cdvData.SelectedDescIndex;
            }
            set
            {
                cdvData.SelectedDescIndex = value;
            }
        }

        public int SearchSubItemIndex
        {
            get
            {
                return cdvData.SearchSubItemIndex;
            }
            set
            {
                cdvData.SearchSubItemIndex = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return cdvData.ReadOnly;
            }
            set
            {
                if (value == true)
                    cdvData.BackColor = this.BackColor;
                else
                    cdvData.BackColor = SystemColors.Window;
                cdvData.ReadOnly = value;
            }
        }

        public bool VisibleButton
        {
            get
            {
                return cdvData.VisibleButton;
            }
            set
            {
                cdvData.VisibleButton = value;
            }
        }

        public bool VisibleDescription
        {
            get
            {
                return cdvData.VisibleDescription;
            }
            set
            {
                cdvData.VisibleDescription = value;
            }
        }

        public bool VisibleColumnHeader
        {
            get
            {
                return cdvData.VisibleColumnHeader;
            }
            set
            {
                cdvData.VisibleColumnHeader = value;
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
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        public string ListCond_TableName
        {
            get
            {
                if (m_cond_s_table_name == null) m_cond_s_table_name = "";
                return m_cond_s_table_name;
            }
            set
            {
                m_cond_s_table_name = value;
            }
        }
        public string ListCond_ListName
        {
            get
            {
                if (m_cond_s_list_name == null) m_cond_s_list_name = "";
                return m_cond_s_list_name;
            }
            set
            {
                m_cond_s_list_name = value;
            }
        }
        public string ListCond_ModuleName
        {
            get
            {
                if (m_cond_s_module_name == null) m_cond_s_module_name = "";
                return m_cond_s_module_name;
            }
            set
            {
                m_cond_s_module_name = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] ListCond_ListKey
        {
            get
            {
                if (m_cond_list_key == null) m_cond_list_key = new string[10];
                return m_cond_list_key;
            }
            set
            {
                m_cond_list_key = value;
            }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Key1
        {
            get
            {
                return ListCond_ListKey[0];
            }
            set
            {
                ListCond_ListKey[0] = value;
            }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Key2
        {
            get
            {
                return ListCond_ListKey[1];
            }
            set
            {
                ListCond_ListKey[1] = value;
            }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Key3
        {
            get
            {
                return ListCond_ListKey[2];
            }
            set
            {
                ListCond_ListKey[2] = value;
            }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Key4
        {
            get
            {
                return ListCond_ListKey[3];
            }
            set
            {
                ListCond_ListKey[3] = value;
            }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Key5
        {
            get
            {
                return ListCond_ListKey[4];
            }
            set
            {
                ListCond_ListKey[4] = value;
            }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Key6
        {
            get
            {
                return ListCond_ListKey[5];
            }
            set
            {
                ListCond_ListKey[5] = value;
            }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Key7
        {
            get
            {
                return ListCond_ListKey[6];
            }
            set
            {
                ListCond_ListKey[6] = value;
            }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Key8
        {
            get
            {
                return ListCond_ListKey[7];
            }
            set
            {
                ListCond_ListKey[7] = value;
            }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Key9
        {
            get
            {
                return ListCond_ListKey[8];
            }
            set
            {
                ListCond_ListKey[8] = value;
            }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ListCond_Key10
        {
            get
            {
                return ListCond_ListKey[9];
            }
            set
            {
                ListCond_ListKey[9] = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object[] ListCond_ArguList
        {
            get
            {
                if (m_cond_list_argument == null)
                {
                    m_cond_list_argument = new object[0];
                }
                return m_cond_list_argument;
            }
            set
            {
                m_cond_list_argument = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ArrayList ListCond_FilterNameList
        {
            get
            {
                if (m_cond_list_filter_name == null) m_cond_list_filter_name = new ArrayList();
                return m_cond_list_filter_name;
            }
            set
            {
                m_cond_list_filter_name = value;
            }
        }
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ArrayList ListCond_FilterValueList
        {
            get
            {
                if (m_cond_list_filter_value == null) m_cond_list_filter_value = new ArrayList();
                return m_cond_list_filter_value;
            }
            set
            {
                m_cond_list_filter_value = value;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TRSNode ListCond_ParamNode
        {
            get
            {
                if (m_cond_param_node == null) m_cond_param_node = new TRSNode("");
                return m_cond_param_node;
            }
            set
            {
                m_cond_param_node = value;
            }
        }
         

        #endregion

        private void udcCustomCodeViewGCM_FontChanged(object sender, EventArgs e)
        {
            cdvData.Font = this.Font;
        }

        public void Init()
        {
            m_cond_c_step = '1';
            m_cond_s_ext_factory = "";
            m_cond_s_filter = "";

            m_cond_list_key = null;
            m_cond_list_argument = null;

            m_cond_list_filter_name = null;
            m_cond_list_filter_value = null;

            SelectedDescIndex = 1;
            SearchSubItemIndex = 0;

            cdvData.Init();
            MPCF.InitListView(cdvData.GetListView);
            cdvData.Columns.Add("Key", 100, HorizontalAlignment.Left);
            cdvData.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvData.Columns[0].Tag = "KEY_1";

            switch (MPGV.gcLanguage)
            {
                case '1':
                    cdvData.Columns[1].Tag = "DATA_1";
                    break;
                case '2':
                    cdvData.Columns[1].Tag = "DATA_2";
                    break;
                case '3':
                    cdvData.Columns[1].Tag = "DATA_3";
                    break;
            } 
            cdvData.SelectedSubItemIndex = 0;
        }

        public bool CheckValue()
        {
            return MPCF.CheckValue(this.cdvData, 1);
        }

        public void ClearField()
        {
            MPCF.FieldClear(cdvData);
        }

        public void Clear()
        {
            m_cond_list_key = null;
            m_cond_list_argument = null;

            ListCond_FilterNameList.Clear();
            ListCond_FilterValueList.Clear();

            MPCF.ClearList(cdvData.GetListView);
            MPCF.FieldClear(cdvData);
        }

        public bool ViewGCMDataList_Ex(Control Form_control, char c_step, string table_name, string[] keys, params object[] argu_list)
        {
            return ViewGCMDataList_Ex(Form_control, c_step, table_name, keys, -1, null, "", false, argu_list);
        }
        public bool ViewGCMDataList_Ex(Control Form_control, char c_step, string table_name, string[] keys, int Image_idx, TreeNode parentNode, string Ext_Factory, bool bIgnoreError, params object[] argu_list)
        {

            ListViewItem itmX;
            int i;
            int j;
            List<string> sList = new List<string>();
            ArrayList a_list;
            DataTable dt;

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;
            TRSNode list_item;

            string member_name;

            a_list = new ArrayList();

            if (Form_control is ListView)
            {
                MPCF.InitListView((ListView)Form_control);
            }

            if (Image_idx == -1)
            {
                Image_idx = (int)SMALLICON_INDEX.IDX_CODE_DATA;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[Image_idx] == null)
                {
                    if (bIgnoreError == false)
                    {
                        MPCF.ShowMsgBox("Invalid Image Index");
                    }
                    return false;
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (Ext_Factory != "")
            {
                in_node.Factory = Ext_Factory;
            }

            in_node.AddString("TABLE_NAME", table_name);

            //Key Member
            if (keys != null)
            {
                for (i = 0; i < keys.Length; i++)
                {
                    in_node.AddString(string.Format("KEY_{0}", i + 1), keys[i]);
                }
            }
            //Argument Member for SQL
            if (argu_list != null)
            {
                for (i = 0; i < argu_list.Length; i++)
                {
                    list_item = in_node.AddNode("ARGU_LIST");
                    list_item.AddString("ARGUMENT", MPCF.Trim(argu_list[i]));

                }
            }

            do
            {
                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node, bIgnoreError) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                in_node.SetString("NEXT_KEY_3", out_node.GetString("NEXT_KEY_3"));
                in_node.SetString("NEXT_KEY_4", out_node.GetString("NEXT_KEY_4"));
                in_node.SetString("NEXT_KEY_5", out_node.GetString("NEXT_KEY_5"));
                in_node.SetString("NEXT_KEY_6", out_node.GetString("NEXT_KEY_6"));
                in_node.SetString("NEXT_KEY_7", out_node.GetString("NEXT_KEY_7"));
                in_node.SetString("NEXT_KEY_8", out_node.GetString("NEXT_KEY_8"));
                in_node.SetString("NEXT_KEY_9", out_node.GetString("NEXT_KEY_9"));
                in_node.SetString("NEXT_KEY_10", out_node.GetString("NEXT_KEY_10"));
                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));

            } while (in_node.GetString("NEXT_KEY_1") != "" ||
                in_node.GetString("NEXT_KEY_2") != "" ||
                in_node.GetString("NEXT_KEY_3") != "" ||
                in_node.GetString("NEXT_KEY_4") != "" ||
                in_node.GetString("NEXT_KEY_5") != "" ||
                in_node.GetString("NEXT_KEY_6") != "" ||
                in_node.GetString("NEXT_KEY_7") != "" ||
                in_node.GetString("NEXT_KEY_8") != "" ||
                in_node.GetString("NEXT_KEY_9") != "" ||
                in_node.GetString("NEXT_KEY_10") != "" ||
                in_node.GetInt("NEXT_ROW") > 0);

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;
                dt = null;
                if (out_node.GetList("SQL_OUT").Count > 0)
                {
                    dt = MPCR.ConvertToDataTable(out_node.GetList("SQL_OUT")[0]);
                }
                else
                {
                    dt = FillDataTable(dt, out_node);
                }

                if (dt == null || dt.Columns.Count == 0 || dt.Rows.Count == 0) continue;

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    if (Form_control is ListView)
                    {
                        if (DataFilter(dt.Rows[i]) == false)
                        {
                            continue;
                        }

                        /*
                         * Key Column 순위
                         * 1. ListView 컬럼 Tag
                         * 2. List결과의 첫번째 컬럼
                         */
                        member_name = MPCF.Trim(((ListView)Form_control).Columns[0].Tag);
                        if (member_name == "" || dt.Columns.Contains(member_name) == false)
                        {
                            member_name = dt.Columns[0].ColumnName;
                        }

                        if (MPCF.Trim(dt.Rows[i][member_name]) == "") continue;
                        itmX = new ListViewItem(MPCF.Trim(dt.Rows[i][member_name]), Image_idx);

                        if (((ListView)Form_control).Columns.Count > 1)
                        {
                            for (j = 1; j <= ((ListView)Form_control).Columns.Count - 1; j++)
                            {
                                /*
                                 * SubItem 컬럼명 순위
                                 * 1. ListView 컬럼 Tag
                                 * 2. DATA_1....DATA_10
                                 * 3. List결과의 두번째 컬럼...
                                 */
                                member_name = MPCF.Trim(((ListView)Form_control).Columns[j].Tag);
                                if (member_name == "" || dt.Columns.Contains(member_name) == false)
                                {
                                    if (dt.Columns.Contains(string.Format("DATA_{0}", j)) == true)
                                    {
                                        member_name = string.Format("DATA_{0}", j);
                                    }
                                    else if (dt.Columns.Count > j)
                                    {
                                        member_name = dt.Columns[j].ColumnName;
                                    }
                                }
                                itmX.SubItems.Add(MPCF.Trim(dt.Rows[i][member_name]));
                            }
                        }
                        ((ListView)Form_control).Items.Add(itmX);
                    }
                }
            }
            return true;
        }

        public bool ViewList(Control Form_control, char c_step, int Image_idx, string Ext_Factory, bool bIgnoreError, TRSNode param_node)
        {
            ListViewItem itmX;
            int i;
            int j;
            List<string> sList = new List<string>();
            ArrayList a_list;
            DataTable dt;

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");

            string member_name;

            a_list = new ArrayList();

            if (Form_control is ListView)
            {
                MPCF.InitListView((ListView)Form_control);
            }

            if (Image_idx == -1)
            {
                Image_idx = (int)SMALLICON_INDEX.IDX_CODE_DATA;
            }
            else
            {
                if (MPGV.gIMdiForm.GetSmallIconList().Images[Image_idx] == null)
                {
                    if (bIgnoreError == false)
                    {
                        MPCF.ShowMsgBox("Invalid Image Index");
                    }
                    return false;
                }
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            if (Ext_Factory != "")
            {
                in_node.Factory = Ext_Factory;
            }

            for (i = 0; i < param_node.MemberCount; i++)
            {
                in_node.AddMember(param_node.GetMember(i).Name, param_node.GetMember(i).Value, param_node.GetMember(i).ValueType);
            }

            if (MPCR.CallService(ListCond_ModuleName, ListCond_ListName, in_node, ref out_node, bIgnoreError) == false)
            {
                return false;
            }

            dt = null;
            if (out_node.GetList("SQL_OUT").Count > 0)
            {
                dt = MPCR.ConvertToDataTable(out_node.GetList("SQL_OUT")[0]);
            }
            else
            {
                dt = FillDataTable(dt, out_node);
            }

            if (dt == null || dt.Columns.Count == 0 || dt.Rows.Count == 0) return true;

            for (i = 0; i < dt.Rows.Count; i++)
            {
                if (Form_control is ListView)
                {
                    if (DataFilter(dt.Rows[i]) == false)
                    {
                        continue;
                    }

                    /*
                     * Key Column 순위
                     * 1. ListView 컬럼 Tag
                     * 2. List결과의 첫번째 컬럼
                     */
                    member_name = MPCF.Trim(((ListView)Form_control).Columns[0].Tag);
                    if (member_name == "" || dt.Columns.Contains(member_name) == false)
                    {
                        member_name = dt.Columns[0].ColumnName;
                    }

                    if (MPCF.Trim(dt.Rows[i][member_name]) == "") continue;
                    itmX = new ListViewItem(MPCF.Trim(dt.Rows[i][member_name]), Image_idx);

                    if (((ListView)Form_control).Columns.Count > 1)
                    {
                        for (j = 1; j <= ((ListView)Form_control).Columns.Count - 1; j++)
                        {
                            /*
                             * SubItem 컬럼명 순위
                             * 1. ListView 컬럼 Tag
                             * 2. DATA_1....DATA_10
                             * 3. List결과의 두번째 컬럼...
                             */
                            member_name = MPCF.Trim(((ListView)Form_control).Columns[j].Tag);
                            if (member_name == "" || dt.Columns.Contains(member_name) == false)
                            {
                                if (dt.Columns.Contains(string.Format("DATA_{0}", j)) == false)
                                {
                                    member_name = string.Format("DATA_{0}", j);
                                }
                                else if (dt.Columns.Count > j)
                                {
                                    member_name = dt.Columns[j].ColumnName;
                                }
                            }
                            itmX.SubItems.Add(MPCF.Trim(dt.Rows[i][member_name]));
                        }
                    }
                    ((ListView)Form_control).Items.Add(itmX);
                }
            }

            return true;
        }

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="row_item"></param>
        /// <returns></returns>
        private bool DataFilter(DataRow row_item)
        {
            string filter_name, filter_data;
            int i;
            if (ListCond_FilterNameList.Count == 0) return true;

            //Data배열 체크
            for (i = 0; i < ListCond_FilterNameList.Count; i++)
            {
                filter_name = MPCF.Trim(ListCond_FilterNameList[i]);
                filter_data = MPCF.Trim(ListCond_FilterValueList[i]);

                if (row_item.Table.Columns.Contains(filter_name) == false) continue;
                //Data배열 값과 GCM Data값이 다른 경우 filter_out = true로
                if (filter_data.Equals(row_item[filter_name]) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private DataTable FillDataTable(DataTable dt, TRSNode out_node)
        {
            int c;
            int r;
            DataColumn dc;
            DataRow dr;

            /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
            if (dt == null)
            {
                if (out_node.GetList(0).Count < 1) return null;

                dt = new DataTable("DataTable");

                for (c = 0; c < out_node.GetList(0)[0].MemberCount; c++)
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dc.DefaultValue = "";
                    dc.ColumnName = out_node.GetList(0)[0].GetMember(c).Name;

                    dt.Columns.Add(dc);
                }
            }

            for (r = 0; r < out_node.GetList(0).Count; r++)
            {
                dr = dt.NewRow();

                for (c = 0; c < dt.Columns.Count; c++)
                {
                    dr[c] = out_node.GetList(0)[r].GetString(dt.Columns[c].ColumnName);
                }
                //dr[n++] = out_node.GetList(0)[r].GetString("KEY_2");
                //dr[n++] = out_node.GetList(0)[r].GetString("KEY_3");
                //dr[n++] = out_node.GetList(0)[r].GetString("KEY_4");
                //dr[n++] = out_node.GetList(0)[r].GetString("KEY_5");
                //dr[n++] = out_node.GetList(0)[r].GetString("KEY_6");
                //dr[n++] = out_node.GetList(0)[r].GetString("KEY_7");
                //dr[n++] = out_node.GetList(0)[r].GetString("KEY_8");
                //dr[n++] = out_node.GetList(0)[r].GetString("KEY_9");
                //dr[n++] = out_node.GetList(0)[r].GetString("KEY_10");

                //dr[n++] = out_node.GetList(0)[r].GetString("DATA_1");
                //dr[n++] = out_node.GetList(0)[r].GetString("DATA_2");
                //dr[n++] = out_node.GetList(0)[r].GetString("DATA_3");
                //dr[n++] = out_node.GetList(0)[r].GetString("DATA_4");
                //dr[n++] = out_node.GetList(0)[r].GetString("DATA_5");
                //dr[n++] = out_node.GetList(0)[r].GetString("DATA_6");
                //dr[n++] = out_node.GetList(0)[r].GetString("DATA_7");
                //dr[n++] = out_node.GetList(0)[r].GetString("DATA_8");
                //dr[n++] = out_node.GetList(0)[r].GetString("DATA_9");
                //dr[n++] = out_node.GetList(0)[r].GetString("DATA_10");

                dt.Rows.Add(dr);
            }
            /*** End of Modification (2012.04.04) ***/

            return dt;
        }

        public void SetFilter(string member_name, string value)
        {
            for (int i = 0; i < ListCond_FilterNameList.Count; i++)
            {
                if (MPCF.Trim(ListCond_FilterNameList[i]).Equals(member_name))
                {
                    ListCond_FilterValueList[i] = value;
                    return;
                }
            }

            ListCond_FilterNameList.Add(member_name);
            ListCond_FilterValueList.Add(value);
        }

        public void GetGCMData()
        {
            if (ListCond_ListName == "")
            {
                ViewGCMDataList_Ex(cdvData.GetListView, ListCond_Step, ListCond_TableName, ListCond_ListKey, ListCond_ArguList);
            }
            else
            {
                ViewList(cdvData.GetListView, ListCond_Step, -1, ListCond_ExtFactory, true, ListCond_ParamNode);
            }
            switch (ListCond_ListName)
            {
                default:
                    break;
            }

            if (b_add_empty_row_to_top == true)
            {
                cdvData.InsertEmptyRow(0, 1);
            }
            if (b_add_empty_row_to_last == true)
            {
                cdvData.AddEmptyRow(1);
            }
        }

    }
}
