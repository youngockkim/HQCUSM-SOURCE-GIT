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
    public partial class udcMaterial : UserControl, intCodeListControl
    {

        private char m_cond_c_material_step;
        private char m_cond_c_version_step;
        private string m_cond_s_mat_type;
        private string m_cond_s_filter;
        private char m_cond_c_delete_flag;
        private char m_cond_c_deactive_flag;
        private string m_cond_s_ext_factory;

        public udcMaterial()
        {
            InitializeComponent();

            Init();

            VisibleDescription = false;
        }

        #region "Variables"
        
        private bool b_visible_description = false;
        private int i_description_index = -1;
        private bool b_refuse_event_exec = false;
        private bool b_add_empty_row_to_top = false;
        private bool b_add_empty_row_to_last = false;
        /* 2013.06.12. Aiden. Filter 를 필요로 하는지 정의할 수 있도록 변경 */
        private bool b_require_default_filter = false;

        #endregion

        #region "Control Events"

        private MCCodeViewSelChangedHandler MaterialSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler MaterialSelectedItemChanged
        {
            add
            {
                MaterialSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(MaterialSelectedItemChangedEvent, value);
            }
            remove
            {
                MaterialSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(MaterialSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler MaterialButtonPressEvent;
        public event System.EventHandler MaterialButtonPress
        {
            add
            {
                MaterialButtonPressEvent = (System.EventHandler)System.Delegate.Combine(MaterialButtonPressEvent, value);
            }
            remove
            {
                MaterialButtonPressEvent = (System.EventHandler)System.Delegate.Remove(MaterialButtonPressEvent, value);
            }
        }

        private System.EventHandler MaterialButtonPressAfterEvent;
        public event System.EventHandler MaterialButtonPressAfter
        {
            add
            {
                MaterialButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(MaterialButtonPressAfterEvent, value);
            }
            remove
            {
                MaterialButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(MaterialButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler MaterialTextKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler MaterialTextKeyPress
        {
            add
            {
                MaterialTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(MaterialTextKeyPressEvent, value);
            }
            remove
            {
                MaterialTextKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(MaterialTextKeyPressEvent, value);
            }
        }

        private System.EventHandler MaterialTextChangedEvent;
        public event System.EventHandler MaterialTextChanged
        {
            add
            {
                MaterialTextChangedEvent = (System.EventHandler)System.Delegate.Combine(MaterialTextChangedEvent, value);
            }
            remove
            {
                MaterialTextChangedEvent = (System.EventHandler)System.Delegate.Remove(MaterialTextChangedEvent, value);
            }
        }

        private System.EventHandler MaterialTextLostFocusEvent;
        public event System.EventHandler MaterialTextLostFocus
        {
            add
            {
                MaterialTextLostFocusEvent = (System.EventHandler)System.Delegate.Combine(MaterialTextLostFocusEvent, value);
            }
            remove
            {
                MaterialTextLostFocusEvent = (System.EventHandler)System.Delegate.Remove(MaterialTextLostFocusEvent, value);
            }
        }

        private System.EventHandler MaterialTextGotFocusEvent;
        public event System.EventHandler MaterialTextGotFocus
        {
            add
            {
                MaterialTextGotFocusEvent = (System.EventHandler)System.Delegate.Combine(MaterialTextGotFocusEvent, value);
            }
            remove
            {
                MaterialTextGotFocusEvent = (System.EventHandler)System.Delegate.Remove(MaterialTextGotFocusEvent, value);
            }
        }

        private MCCodeViewSelChangedHandler VersionSelectedItemChangedEvent;
        public event MCCodeViewSelChangedHandler VersionSelectedItemChanged
        {
            add
            {
                VersionSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Combine(VersionSelectedItemChangedEvent, value);
            }
            remove
            {
                VersionSelectedItemChangedEvent = (MCCodeViewSelChangedHandler)System.Delegate.Remove(VersionSelectedItemChangedEvent, value);
            }
        }

        private System.EventHandler VersionButtonPressEvent;
        public event System.EventHandler VersionButtonPress
        {
            add
            {
                VersionButtonPressEvent = (System.EventHandler)System.Delegate.Combine(VersionButtonPressEvent, value);
            }
            remove
            {
                VersionButtonPressEvent = (System.EventHandler)System.Delegate.Remove(VersionButtonPressEvent, value);
            }
        }

        private System.EventHandler VersionButtonPressAfterEvent;
        public event System.EventHandler VersionButtonPressAfter
        {
            add
            {
                VersionButtonPressAfterEvent = (System.EventHandler)System.Delegate.Combine(VersionButtonPressAfterEvent, value);
            }
            remove
            {
                VersionButtonPressAfterEvent = (System.EventHandler)System.Delegate.Remove(VersionButtonPressAfterEvent, value);
            }
        }

        private System.Windows.Forms.KeyPressEventHandler VersionKeyPressEvent;
        public event System.Windows.Forms.KeyPressEventHandler VersionKeyPress
        {
            add
            {
                VersionKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Combine(VersionKeyPressEvent, value);
            }
            remove
            {
                VersionKeyPressEvent = (System.Windows.Forms.KeyPressEventHandler)System.Delegate.Remove(VersionKeyPressEvent, value);
            }
        }

        private System.EventHandler VersionChangedEvent;
        public event System.EventHandler VersionChanged
        {
            add
            {
                VersionChangedEvent = (System.EventHandler)System.Delegate.Combine(VersionChangedEvent, value);
            }
            remove
            {
                VersionChangedEvent = (System.EventHandler)System.Delegate.Remove(VersionChangedEvent, value);
            }
        }

        private System.EventHandler VersionLostFocusEvent;
        public event System.EventHandler VersionLostFocus
        {
            add
            {
                VersionLostFocusEvent = (System.EventHandler)System.Delegate.Combine(VersionLostFocusEvent, value);
            }
            remove
            {
                VersionLostFocusEvent = (System.EventHandler)System.Delegate.Remove(VersionLostFocusEvent, value);
            }
        }

        private System.EventHandler VersionGotFocusEvent;
        public event System.EventHandler VersionGotFocus
        {
            add
            {
                VersionGotFocusEvent = (System.EventHandler)System.Delegate.Combine(VersionGotFocusEvent, value);
            }
            remove
            {
                VersionGotFocusEvent = (System.EventHandler)System.Delegate.Remove(VersionGotFocusEvent, value);
            }
        }
        

        private void cdvMat_ButtonPress(object sender, EventArgs e)
        {
            if (MaterialButtonPressEvent != null)
                MaterialButtonPressEvent(this, e);

            if (b_refuse_event_exec == true)
            {
                b_refuse_event_exec = false;
                return;
            }

            /* 2013.06.12. Aiden. Filter 를 필요로하는 경우 cdvMat.Text 에 값이 있어야 한다. */
            if (b_require_default_filter == true)
            {
                ListCond_Filter = cdvMat.Text;
                if (MPCF.Trim(ListCond_Filter) == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(258));
                    cdvMat.GetTextBox.Focus();
                    return;
                }
            }

            if (ListCond_StepMaterial == 'x')
                /* 2013.06.12. Aiden. Step 'x' 인 경우 ListCond_Filter 에 지정된 SQL 에 의해 리스트를 가져오도록 하는 기능 추가 */
                BASLIST.ViewQueryList(cdvMat.GetListView, '1', ListCond_Filter, (int)SMALLICON_INDEX.IDX_MATERIAL, null);
            else if (ListCond_StepMaterial == 'z')
                /* 2013.06.12. Aiden. Step 'z' 인 경우 외부에서 리스트를 채울수 있도록 리턴함. */
                return;
            else
            	WIPLIST.ViewMaterialList(cdvMat.GetListView, ListCond_StepMaterial, ListCond_MatType, ListCond_DeleteFlag, ListCond_DeactiveFlag, ListCond_Filter, true, null, ListCond_ExtFactory);

            if (b_add_empty_row_to_top == true)
            {
                cdvMat.InsertEmptyRow(0, 1);
            }
            if (b_add_empty_row_to_last == true)
            {
                cdvMat.AddEmptyRow(1);
            }

            if (MaterialButtonPressAfterEvent != null)
                MaterialButtonPressAfterEvent(this, e);
        }

        private void cdvMat_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (VisibleDescription == true)
            {
                if (i_description_index > -1)
                {
                    if (cdvMat.Columns.Count > i_description_index)
                    {
                        txtDesc.Text = e.SelectedItem.SubItems[i_description_index].Text;
                    }
                    else
                    {
                        txtDesc.Text = cdvMat.Text;
                    }
                }
            }
            cdvVersion.Text = e.SelectedItem.SubItems[1].Text;

            if (MaterialSelectedItemChangedEvent != null)
                MaterialSelectedItemChangedEvent(this, e);
        }

        private void cdvMat_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (MaterialTextGotFocusEvent != null)
                MaterialTextGotFocusEvent(this, e);
        }

        private void cdvMat_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (MaterialTextKeyPressEvent != null)
                MaterialTextKeyPressEvent(this, e);
        }

        private void cdvMat_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (MaterialTextLostFocusEvent != null)
                MaterialTextLostFocusEvent(this, e);
        }

        private void cdvMat_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (MaterialTextChangedEvent != null)
                MaterialTextChangedEvent(this, e);

            if (MPCF.Trim(Text) == "")
            {
                Version = 0;
                txtDesc.Text = "";
            }
        }


        private void cdvVersion_ButtonPress(object sender, EventArgs e)
        {
            if (VersionButtonPressEvent != null)
                VersionButtonPressEvent(this, e);

            if (b_refuse_event_exec == true)
            {
                b_refuse_event_exec = false;
                return;
            }

            WIPLIST.ViewMaterialVersionList(cdvVersion.GetListView, ListCond_StepVersion, Text, ListCond_MatType, ListCond_DeleteFlag, ListCond_DeactiveFlag, null, ListCond_ExtFactory);

            if (VersionButtonPressAfterEvent != null)
                VersionButtonPressAfterEvent(this, e);
        }

        private void cdvVersion_SelectedItemChanged(object sender, MCCodeViewSelChanged_EventArgs e)
        {
            if (VisibleDescription == true)
            {
                if (i_description_index > -1)
                {
                    txtDesc.Text = e.SelectedItem.SubItems[1].Text;
                }
            }

            if (VersionSelectedItemChangedEvent != null)
                VersionSelectedItemChangedEvent(this, e);
        }

        private void cdvVersion_TextBoxGotFocus(object sender, EventArgs e)
        {
            if (VersionGotFocusEvent != null)
                VersionGotFocusEvent(this, e);
        }

        private void cdvVersion_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (VersionKeyPressEvent != null)
                VersionKeyPressEvent(this, e);
        }

        private void cdvVersion_TextBoxLostFocus(object sender, EventArgs e)
        {
            if (VersionLostFocusEvent != null)
                VersionLostFocusEvent(this, e);
        }

        private void cdvVersion_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (VersionChangedEvent != null)
                VersionChangedEvent(this, e);
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
        public ListView.ListViewItemCollection MaterialItems
        {
            get
            {
                return cdvMat.Items;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ColumnHeaderCollection MaterialColumns
        {
            get
            {
                return cdvMat.Columns;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem MaterialSelectedItem
        {
            get
            {
                return cdvMat.SelectedItem;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool MaterialIsPopup
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
        public string MaterialDisplayText
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
        public ListView MaterialGetListView
        {
            get
            {
                return cdvMat.GetListView;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView.ListViewItemCollection VersionItems
        {
            get
            {
                return cdvVersion.Items;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListViewItem VersionSelectedItem
        {
            get
            {
                return cdvVersion.SelectedItem;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool VersionIsPopup
        {
            get
            {
                return cdvVersion.IsPopup;
            }
            set
            {
                cdvVersion.IsPopup = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Version
        {
            get
            {
                if (MPCF.Trim(cdvVersion.Text) == "") return 0;
                else                                        return MPCF.ToInt(cdvVersion.Text);
            }
            set
            {
                if (value < 1) cdvVersion.Text = "";
                else           cdvVersion.Text = value.ToString();
            }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListView VersionGetListView
        {
            get
            {
                return cdvVersion.GetListView;
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
                return pnlMaterial.BackColor;
            }
            set
            {
                pnlMaterial.BackColor = value;
                cdvMat.BackColor = value;
                cdvVersion.BackColor = value;
                txtDesc.BackColor = value;
                lblMat.BackColor = value;
            }
        }

        public Color LabelBackColor
        {
            get
            {
                return lblMat.BackColor;
            }
            set
            {
                lblMat.BackColor = value;
            }
        }

        public Color CodeViewBackColor
        {
            get
            {
                return cdvMat.BackColor;
            }
            set
            {
                cdvMat.BackColor = value;
                cdvVersion.BackColor = value;
                txtDesc.BackColor = value;
            }
        }

        public int WidthButton
        {
            get
            {
                return cdvMat.ButtonWidth;
            }
            set
            {
                cdvMat.ButtonWidth = value;
                cdvVersion.ButtonWidth = value;
            }
        }

        public int WidthMaterialAndVersion
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

        public int WidthVersion
        {
            get
            {
                return pnlVersion.Width;
            }
            set
            {
                pnlVersion.Width = value;
            }
        }

        public int WidthLabel
        {
            get
            {
                return lblMat.Width;
            }
            set
            {
                lblMat.Width = value;
                pnlLabel.Width = value;
            }
        }

        public int MaterialMaxLength
        {
            get
            {
                return cdvMat.MaxLength;
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
                return cdvMat.SearchSubItemIndex;
            }
            set
            {
                cdvMat.SearchSubItemIndex = value;
            }
        }




        public bool VisibleMaterialButton
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

        public bool VisibleVersionButton
        {
            get
            {
                return cdvVersion.VisibleButton;
            }
            set
            {
                cdvVersion.VisibleButton = value;
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
                return cdvMat.VisibleColumnHeader;
            }
            set
            {
                cdvMat.VisibleColumnHeader = value;
                cdvVersion.VisibleColumnHeader = value;
            }
        }

        /* 2013.06.12. Aiden. RequireDefaultFilter Property 추가 */
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RequireDefaultFilter
        {
            get
            {
                return b_require_default_filter;
            }
            set
            {
                b_require_default_filter = value;
            }
        }

        public bool MaterialReadOnly
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

        public bool VersionReadOnly
        {
            get
            {
                return cdvVersion.ReadOnly;
            }
            set
            {
                if (value == true)
                    cdvVersion.BackColor = this.BackColor;
                else
                    cdvVersion.BackColor = SystemColors.Window;

                cdvVersion.ReadOnly = value;
            }
        }

        public bool MaterialEnabled
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


        public bool VersionEnabled
        {
            get
            {
                return cdvVersion.Enabled;
            }
            set
            {
                cdvVersion.Enabled = value;
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

        public char ListCond_StepMaterial
        {
            get
            {
                return m_cond_c_material_step;
            }
            set
            {
                m_cond_c_material_step = value;
            }
        }
        public char ListCond_StepVersion
        {
            get
            {
                return m_cond_c_version_step;
            }
            set
            {
                m_cond_c_version_step = value;
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
        public string ListCond_MatType
        {
            get
            {
                if (m_cond_s_mat_type == null) m_cond_s_mat_type = "";
                return m_cond_s_mat_type;
            }
            set
            {
                m_cond_s_mat_type = value;
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
        public char ListCond_DeleteFlag
        {
            get
            {
                return m_cond_c_delete_flag;
            }
            set
            {
                m_cond_c_delete_flag = value;
            }
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public char ListCond_DeactiveFlag
        {
            get
            {
                return m_cond_c_deactive_flag;
            }
            set
            {
                m_cond_c_deactive_flag = value;
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

        private void udcMaterial_FontChanged(object sender, EventArgs e)
        {
            cdvMat.Font = this.Font;
            cdvVersion.Font = this.Font;
        }

        private void udcMaterial_Resize(object sender, EventArgs e)
        {
            if (VisibleDescription == false)
            {
                pnlLeft.Width = this.Width;
            }
        }

        public void Init()
        {

            m_cond_c_material_step = '1';
            m_cond_c_version_step = m_cond_c_material_step;
            m_cond_s_ext_factory = "";
            m_cond_s_mat_type = "";
            m_cond_s_filter = "";
            m_cond_c_delete_flag = ' ';
            m_cond_c_deactive_flag = ' ';

            /* 2013.06.17. Aiden. Material Filter 가 필요한지 Global Option 확인 */
            if (MPCR.IsInDesignMode(this) == false)
            {
                b_require_default_filter = MPGO.RequireMaterialFilter();
            }

            SelectedDescIndex = 2;
            SearchSubItemIndex = 0;
            
            cdvMat.Init();
            MPCF.InitListView(cdvMat.GetListView);
            cdvMat.Columns.Add("Material", 100, HorizontalAlignment.Left);
            cdvMat.Columns.Add("Version", 100, HorizontalAlignment.Left);
            cdvMat.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvMat.SelectedSubItemIndex = 0;
            cdvMat.MaxLength = 30;

            cdvVersion.Init();
            MPCF.InitListView(cdvVersion.GetListView);
            cdvVersion.Columns.Add("Version", 100, HorizontalAlignment.Left);
            cdvVersion.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvVersion.SelectedSubItemIndex = 0;
            cdvVersion.MaxLength = 6;
        }

        public void MaterialFocus()
        {
            cdvMat.Focus();           
        }

        public void VersionFocus()
        {
            cdvVersion.Focus();
        }

        //public bool MaterialAddEmptyRow(int iRowCount)
        //{

        //     try
        //    {
        //        cdvMat.AddEmptyRow(iRowCount);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "MaterialAddEmptyRow()", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    return true;

        //}

        //public bool VersionAddEmptyRow(int iRowCount)
        //{

        //    try
        //    {
        //        cdvVersion.AddEmptyRow(iRowCount);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "VersionAddEmptyRow()", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }

        //    return true;

        //}

        public bool CheckValue()
        {
            if (MPCF.CheckValue(this.cdvMat, 1) == false) return false;
            if (MPCF.CheckValue(this.cdvVersion, 2) == false) return false;

            return true;
        }

        public void ClearField()
        {
            cdvMat.Text = "";
            cdvVersion.Text = "";
        }

    }
}
